Terrasoft.configuration.Structures["SectionBindingColumnMixin"] = {innerHierarchyStack: ["SectionBindingColumnMixin"]};
define("SectionBindingColumnMixin", ["ext-base", "terrasoft", "ConfigurationEnums"], function(Ext, Terrasoft, ConfigurationEnums) {
	/**
	 * @class Terrasoft.configuration.mixins.SectionBindingColumnMixin
	 * Mixin represents methods to support section binding column functionality.
	 */    
	Ext.define("Terrasoft.configuration.mixins.SectionBindingColumnMixin", {
		alternateClassName: "Terrasoft.SectionBindingColumnMixin",

		/**
		 * Initializes section binding column value.
		 * @protected
		 * @virtual
		 */
		initSectionBindingColumn: function() {
			Terrasoft.chain(
				this.getSectionBindingColumn,
				function(next, sectionBindingColumn) {
					if(!this.$sectionBindingColumn) {
						this.$sectionBindingColumn = sectionBindingColumn;
					}
				}, this);
		},

		/**
		 * Returns section binding column.
		 * @protected
		 * @virtual
		 */
		getSectionBindingColumn: function(callback, scope) {
			let result = null;
			const isAngularPage = this.isAngularPage();
			const hasIdAttributeInSchema = this.hasIdAttributeInSchema();
			if(isAngularPage && !hasIdAttributeInSchema) {
				Ext.callback(callback, scope, [result]);
			}
			let selectedObjectSchemaName = this.$entitySchemaName;
			selectedObjectSchemaName = (selectedObjectSchemaName && selectedObjectSchemaName.Name) || selectedObjectSchemaName;
			const sectionSchemaName = this.getSectionSchemaName();
			if (selectedObjectSchemaName && sectionSchemaName) {
				if (selectedObjectSchemaName === sectionSchemaName) {
					result = {
						value: "Id",
						displayValue: "Id",
						dataValueType: Terrasoft.DataValueType.GUID
					};
				} else {
					var config = {
						selectedObjectSchemaName: selectedObjectSchemaName,
						sectionSchemaName: sectionSchemaName
					};
					this.findEntitySchemaColumnsBySectionSchemaName(config, function(filteredColumns) {
						result = filteredColumns.length === 1 ? filteredColumns[0] : null;
					}, this);
				}
			}
			Ext.callback(callback, scope, [result]);
		},

		/**
		 * Returns section schema name.
		 * @protected
		 * @virtual
		 * @return {String[]} Returns section schema name.
		 */
		getSectionSchemaName: function() {
			if (this.$dataSourceConfig && this.$dataSourceConfig.entitySchemaName) {
				return this.$dataSourceConfig.entitySchemaName;
			} else {
				var designEntitySchemaName = this.get("DesignEntitySchemaName");
				if (designEntitySchemaName) {
					return designEntitySchemaName;
				} else {
					var sectionSchema = this.sandbox.publish("GetSectionEntitySchema");
					return sectionSchema && sectionSchema.name;
				}
			}
		},

		/**
		 * Finds entity schema columns by section schema.
		 * @protected
		 * @param {String} config Configuration object.
		 * @param {String} config.selectedObjectSchemaName Selected object schema name.
		 * @param {String} config.sectionSchemaName Section schema name.
		 * @param {Function} callback Callback function.
		 * @param {Object} scope Callback function context.
		 */
		findEntitySchemaColumnsBySectionSchemaName: function(config, callback, scope) {
			var selectedObjectSchema;
			Terrasoft.chain(
				function(next) {
					Terrasoft.require([config.selectedObjectSchemaName], function(schema) {
						selectedObjectSchema = schema;
						next();
					}, this);
				},
				function() {
					var filteredColumnArray = [];
					Terrasoft.each(selectedObjectSchema.columns, function(column) {
						if (column.dataValueType === Terrasoft.DataValueType.LOOKUP &&
								column.referenceSchemaName === config.sectionSchemaName) {
							filteredColumnArray.push({
								value: column.name,
								displayValue: column.caption,
								dataValueType: column.dataValueType
							});
						}
					}, this);
					callback.call(scope, filteredColumnArray);
				},
				this
			);
		},

		/**
		 * Generates a Filter to request a list of object schemes in the current configuration.
		 * @virtual
		 * @return {Terrasoft.FilterGroup} Returns a Filter for querying a list of object schemas.
		 */
		getSchemasFilter: function() {
			const filters = this.Ext.create("Terrasoft.FilterGroup");
			filters.addItem(Terrasoft.createColumnFilterWithParameter(
				Terrasoft.ComparisonType.EQUAL,
				"SysWorkspace",
				Terrasoft.SysValue.CURRENT_WORKSPACE.value
			));
			const notInFilter = Terrasoft.createColumnInFilterWithParameters("Name",
				Terrasoft.DataServiceSettings.RestrictedSelectSchemaAccessNames || []);
			notInFilter.comparisonType = Terrasoft.ComparisonType.NOT_EQUAL;
			filters.addItem(notInFilter);
			if (this.getIsFeatureDisabled("UseVwWorkspaceObjects")) {
				filters.addItem(Terrasoft.createColumnFilterWithParameter(
					Terrasoft.ComparisonType.EQUAL,
					"ManagerName",
					"EntitySchemaManager"
				));
			}
			return filters;
		},

		/**
		 * Returns if viewmodel has id attribute.
		 * @returns {Boolean} if viewmodel has id attribute.
		 */
		hasIdAttributeInSchema: function() {
			const searchParams = new URLSearchParams(window.location.search);
			return searchParams.get('hasIdAttributeInViewModel') === 'true';
		},

		/**
		 * Returns if widget was rendered from angular page.
		 * @returns {Boolean} if widget was rendered from angular page.
		 */
		isAngularPage: function() {
			const searchParams = new URLSearchParams(window.location.search);
			return searchParams.get('isAngularPage') === 'true';
		},

		/**
		 * Returns visibility of section binding column.
		 * @return {Boolean} Visibility of section binding column.
		 */
		getSectionBindingGroupVisible: function() {
			const isAngularPage = this.isAngularPage();
			const res = !!this.$dataSourceConfig || !!this.get("sectionId");
			if(isAngularPage) {
				const isSupportWidgetDataSource = this.getIsFeatureDisabled("DisableSupportWidgetDataSource");
				if(isSupportWidgetDataSource) {
					return false;
				}
				const hasIdAttributeInSchema = this.hasIdAttributeInSchema();
				return res && hasIdAttributeInSchema;
			}
			return res;
		},

		/**
		 * Generates object schema names list for section.
		 * @protected
		 * @virtual
		 * @return {String[]} Returns object schema names list for section.
		 */
		getAllowedReferenceSchemas: function() {
			var sectionSchema = this.getSectionSchemaName();
			return sectionSchema && [sectionSchema];
		},

		/**
		 * Filters columns.
		 * @protected
		 * @virtual
		 */
		 columnsFiltrationMethod: function(column) {
			if (column.usageType === ConfigurationEnums.EntitySchemaColumnUsageType.None) {
				return false;
			}
			if (Terrasoft.isGUIDDataValueType(column.dataValueType)) {
				return true;
			}
			var allowedReferenceSchemas = this.getAllowedReferenceSchemas();
			return Terrasoft.isLookupDataValueType(column.dataValueType) &&
				Terrasoft.contains(allowedReferenceSchemas, column.referenceSchemaName);
		},

		/**
		 * Generates header for section binding group.
		 * @protected
		 * @virtual
		 * @return {String} Returns section binding group header.
		 */
		getSectionBindingColumnCaption: function() {
			var moduleCaption = "";
			var sectionBindingColumnFormat = this.get("Resources.Strings.SectionBindingColumnFormat");
			var entitySchemaNameInfo = this.get("entitySchemaName");
			var entitySchemaNameLookupValue = (entitySchemaNameInfo && entitySchemaNameInfo.displayValue) || "";
			if (!this.$dataSourceConfig?.entitySchemaName) {
				const moduleInfo = this.get("sectionId");
				var moduleId = (moduleInfo && moduleInfo.value) || moduleInfo;
				Terrasoft.each(Terrasoft.configuration.ModuleStructure, function(moduleConfig) {
					if (moduleConfig.moduleId === moduleId) {
						moduleCaption = moduleConfig.moduleCaption;
						return false;
					}
				}, this);
			} else {
				const moduleInfo = Terrasoft.configuration.ModuleStructure[this.$dataSourceConfig.entitySchemaName];
				moduleCaption = moduleInfo?.moduleCaption || this.get("sectionCaption");
			}
			return this.Ext.String.format(sectionBindingColumnFormat, entitySchemaNameLookupValue, moduleCaption);
		},
	});
	return Terrasoft.SectionBindingColumnMixin;
});

