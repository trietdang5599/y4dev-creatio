define("BaseWidgetDesigner", ["terrasoft", "ColumnEditMixin",
	"SectionBindingColumnMixin", "css!BaseWidgetDesignerCSS"],
function(Terrasoft) {
	return {
		messages: {

			/**
			 * ######## ## ######### ################# ####### ###### ########.
			 */
			"GetFilterModuleConfig": {
				mode: Terrasoft.MessageMode.PTP,
				direction: Terrasoft.MessageDirectionType.SUBSCRIBE
			},

			/**
			 * ######## ## ######### #######.
			 */
			"OnFiltersChanged": {
				mode: Terrasoft.MessageMode.BROADCAST,
				direction: Terrasoft.MessageDirectionType.SUBSCRIBE
			},

			/**
			 * ########## ######### ######## ###### ########.
			 */
			"SetFilterModuleConfig": {
				mode: Terrasoft.MessageMode.BROADCAST,
				direction: Terrasoft.MessageDirectionType.PUBLISH
			},

			/**
			 * ######### ###### ##### #######.
			 */
			"GetSectionEntitySchema": {
				mode: Terrasoft.MessageMode.PTP,
				direction: Terrasoft.MessageDirectionType.PUBLISH
			}

		},
		mixins: {
			ColumnEditMixin: "Terrasoft.ColumnEditMixin",
			SectionBindingColumnMixin: "Terrasoft.SectionBindingColumnMixin"
		},
		attributes: {

			/**
			 * ####### ##### # ########.
			 */
			sectionBindingColumn: {
				dataValueType: Terrasoft.DataValueType.LOOKUP,
				type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				isLookup: true,
				entityStructureConfig: {
					useBackwards: false,
					displayId: true,
					lookupsColumnsOnly: true,
					allowedReferenceSchemas: "getAllowedReferenceSchemas",
					schemaColumnName: "entitySchemaName"
				}
			},

			/**
			 * ####### # ########### # #######.
			 */
			sectionId: {
				dataValueType: Terrasoft.DataValueType.LOOKUP,
				type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN
			},

			/**
			 * ######## #####.
			 */
			entitySchemaName: {
				dataValueType: Terrasoft.DataValueType.LOOKUP,
				type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				isRequired: true,
				isLookup: true,
				lookupListConfig: {
					columns: ["Name", "Caption"],
					filter: "getSchemasFilter"
				},
				referenceSchema: {
					name: Terrasoft.Features.getIsEnabled("UseVwWorkspaceObjects") ?
						"VwWorkspaceObjects" :
						"VwSysSchemaInfo",
					primaryColumnName: "Name",
					primaryDisplayColumnName: "Caption"
				},
				referenceSchemaName: Terrasoft.Features.getIsEnabled("UseVwWorkspaceObjects") ?
					"VwWorkspaceObjects" :
					"VwSysSchemaInfo"
			},

			/**
			 * ###### #######.
			 */
			filterData: {
				dataValueType: Terrasoft.DataValueType.CUSTOM_OBJECT,
				type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN
			},
			Dependencies: {
				dataValueType: Terrasoft.DataValueType.CUSTOM_OBJECT,
				type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN
			},
			FilterAttributes: {
				dataValueType: Terrasoft.DataValueType.CUSTOM_OBJECT,
				type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN
			},
			HierarchyConfig: {
				dataValueType: Terrasoft.DataValueType.CUSTOM_OBJECT,
				type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN
			},
		},
		methods: {

			/**
			 * @inheritDoc Terrasoft.BaseWidgetPreviewDesigner#getWidgetModulePropertiesTranslator
			 */
			getWidgetModulePropertiesTranslator: function() {
				var result = this.callParent(arguments);
				var config = {
					"filterData": "filterData",
					"entitySchemaName": "entitySchemaName",
					"sectionBindingColumn": "sectionBindingColumn",
					"sectionId": "sectionId",
					"Dependencies": "dependencies",
					"FilterAttributes": "filterAttributes",
					"HierarchyConfig": "hierarchyConfig"
				};
				this.Ext.apply(result, config);
				return result;
			},

			/**
			 * @inheritDoc Terrasoft.BaseWidgetPreviewDesigner#canRefreshWidget
			 */
			canRefreshWidget: function() {
				var canRefresh = this.callParent(arguments) && this.get("filterData");
				return Boolean(canRefresh);
			},

			/**
			 * ######### ## ###### ########.
			 * @param {*} value ########
			 * @return {boolean} ########## true, #### ####### ## ###### ######, false # ######## ######.
			 */
			isNotEmptyConverter: function(value) {
				return !Ext.isEmpty(value);
			},

			/**
			 * Returns custom filter for columns.
			 * @param {Object} columnName Column name.
			 * @return {Function} Custom column filtration method.
			 */
			getColumnsFiltrationMethod: function(columnName) {
				if (columnName === "sectionBindingColumn") {
					return this.columnsFiltrationMethod;
				}
			},
						
			/**
			 * ########## ############# ###### ##########.
			 * @protected
			 * @virtual
			 * @return {String} ########## ############# ###### ##########.
			 */
			getFilterEditModuleId: function() {
				return this.sandbox.id + "_ExtendedFilterEditModule";
			},

			/**
			 * ##### ######## ###### ##########.
			 * @protected
			 * @virtual
			 */
			loadFilterModule: function() {
				var moduleId = this.getFilterEditModuleId();
				this.sandbox.subscribe("OnFiltersChanged", function(args) {
					this.set("filterData", args.serializedFilter);
				}, this, [moduleId]);
				this.sandbox.subscribe("GetFilterModuleConfig", function() {
					var entitySchemaNameProperty = this.get("entitySchemaName");
					return {
						rootSchemaName: entitySchemaNameProperty && entitySchemaNameProperty.Name,
						filters: this.get("filterData")
					};
				}, this, [moduleId]);
				this.sandbox.loadModule("FilterEditModule", {
					renderTo: "FilterProperties",
					id: moduleId
				});
				this.set("filterModuleLoaded", true);
			},

			/**
			 * ##### ######### ####### ######### ######## #####.
			 * @protected
			 * @virtual
			 */
			onEntitySchemaNameChange: function() {
				this.set("filterData", null);
				this.set("sectionBindingColumn", null);
				this.$Dependencies = undefined;
				this.$FilterAttributes = undefined;
				var entitySchemaNameProperty = this.get("entitySchemaName");
				if (entitySchemaNameProperty) {
					this.loadFilterModule();
					var moduleId = this.getFilterEditModuleId();
					this.sandbox.publish("SetFilterModuleConfig", {
						rootSchemaName: entitySchemaNameProperty && entitySchemaNameProperty.Name
					}, [moduleId]);
				}
				this.initSectionBindingColumn();
			},

			/**
			 * ############## ######### ######## ######.
			 * @protected
			 * @virtual
			 * @param {Function} callback ####### ######### ######.
			 * @param {Object} scope ######## ####### ######### ######.
			 */
			 init: function(callback, scope) {
				this.callParent([function() {
					this.on("change:entitySchemaName", this.onEntitySchemaNameChange, this);
					const dataSourceSchemaName = this.$dataSourceConfig?.entitySchemaName;
					if (dataSourceSchemaName && 
							!Terrasoft.configuration.ModuleStructure[dataSourceSchemaName]) {
						this._initSysModuleSchema(callback);
						return;
					}
					callback.call(this);
				}, this]);
			},

			/**
			 * @private
			 */
			_initSysModuleSchema: function(callback) {
				const dataSourceSchemaName = this.$dataSourceConfig?.entitySchemaName;
				this.getDataSourceSysModule(dataSourceSchemaName, function(module) {
					this.set("sectionId", module && {value: module.get("Id")});
					this.set("sectionCaption", module && module.get("Caption"));
					this.set("DesignEntitySchemaName", dataSourceSchemaName);
					callback.call(this);
				}, this);
			},

			/**
			 * ##### ######### ####### ######### ######.
			 * @protected
			 * @virtual
			 */
			onRender: function() {
				if (!this.get("filterModuleLoaded")) {
					this.loadFilterModule();
				}
			},

			/**
			 * @inheritDoc Terrasoft.BaseWidgetPreviewDesigner#setWidgetModuleProperties
			 */
			setWidgetModuleProperties: function(widgetConfig, callback) {
				this.callParent([widgetConfig, function() {
					Terrasoft.chain(function(next) {
							var widgetModulePropertiesTranslator = this.getWidgetModulePropertiesTranslator();
							var widgetPropertyName = widgetModulePropertiesTranslator.entitySchemaName;
							var entitySchemaName = widgetConfig[widgetPropertyName];
							if (!entitySchemaName) {
								next();
								return;
							}
							this.getEntitySchemaCaption(entitySchemaName, function(entitySchemaCaption) {
								this.set("entitySchemaName", {
									value: entitySchemaName,
									Name: entitySchemaName,
									displayValue: entitySchemaCaption
								});
								next();
							}, this);
						},
						function(next) {
							this.mixins.ColumnEditMixin.init.call(this, function() {
								next();
							}, this);
						},
						function() {
							if (widgetConfig.designEntitySchemaName) {
								this.set("DesignEntitySchemaName", widgetConfig.designEntitySchemaName);
							}
							this.set("moduleLoaded", true);
							this.Ext.callback(callback, this);
						}, this);
				}, this]);
			},

			/**
			 * ######### #####, ####### ########## ######### EntitySchemaQuery ### ######### ###### ########## #######.
			 * @overridden
			 * @protected
			 * @virtual
			 * @return {Object} ########## ######### EntitySchemaQuery ### ######### ###### ########## #######.
			 */
			getLookupQuery: function(filterValue, columnName) {
				var esq = this.callParent(arguments);
				var lookupColumn = this.columns[columnName];
				var lookupListConfig = lookupColumn.lookupListConfig;
				if (!lookupListConfig) {
					return esq;
				}
				Terrasoft.each(lookupListConfig.columns, function(column) {
					if (!esq.columns.contains(column)) {
						esq.addColumn(column);
					}
				}, this);
				var filterGroup = this.getLookupQueryFilters(columnName);
				esq.filters.addItem(filterGroup);
				var columns = esq.columns;
				if (lookupListConfig.orders) {
					var orders = lookupListConfig.orders;
					Terrasoft.each(orders, function(order) {
						var orderColumnPath = order.columnPath;
						if (!columns.contains(orderColumnPath)) {
							esq.addColumn(orderColumnPath);
						}
						var sortedColumn = columns.get(orderColumnPath);
						var direction = order.direction;
						sortedColumn.orderDirection = direction ? direction : Terrasoft.OrderDirection.ASC;
						var position = order.position;
						sortedColumn.orderPosition = position ? position : 1;
						this.shiftColumnsOrderPosition(columns, sortedColumn);
					}, this);
				}
				if (Terrasoft.Features.getIsDisabled("DisableBaseWidgetDesignerExpandableListRowCount45")) {
					esq.rowCount = 45;
				}
				return esq;
			},

			/**
			 * ######### #######, ####### ############# ## ########## ####.
			 * @private
			 * @param {String} columnName ######## #######.
			 * @return {Terrasoft.FilterGroup} ########## ###### ########.
			 */
			getLookupQueryFilters: function(columnName) {
				var filterGroup = this.Ext.create("Terrasoft.FilterGroup");
				var column = this.columns[columnName];
				var lookupListConfig = column.lookupListConfig;
				if (lookupListConfig) {
					var filterArray = lookupListConfig.filters;
					Terrasoft.each(filterArray, function(item) {
						var filter;
						if (Ext.isObject(item) && Ext.isFunction(item.method)) {
							filter = item.method.call(this, item.argument);
						}
						if (Ext.isFunction(item)) {
							filter = item.call(this);
						}
						if (Ext.isEmpty(filter)) {
							throw new Terrasoft.InvalidFormatException({
								message: Ext.String.format(
									this.get("Resources.Strings.ColumnFilterInvalidFormatException"), columnName)
							});
						}
						filterGroup.addItem(filter);
					}, this);
					if (lookupListConfig.filter) {
						var filterItem = Ext.isString(lookupListConfig.filter) ? this[lookupListConfig.filter]()
							: lookupListConfig.filter.call(this);
						if (filterItem) {
							filterGroup.addItem(filterItem);
						}
					}
				}
				return filterGroup;
			},

			/**
			 * Returns query for select page schema list.
			 * @private
			 * @return {Terrasoft.EntitySchemaQuery}
			 */
			getDataSourceSysModule: function(sysModuleCode, callback, scope) {
				var esq = new Terrasoft.EntitySchemaQuery({
					rootSchemaName: "SysModule",
				});
				esq.addColumn("Id");
				esq.addColumn("Caption");
				esq.filters.addItem(Terrasoft.createColumnFilterWithParameter(this.Terrasoft.ComparisonType.EQUAL,
					"Code", sysModuleCode));
				esq.getEntityCollection(function(result) {
					let module;
					if (result.success && result.collection) {
						module = result.collection.getItems()[0];
					}
					this.Ext.callback(callback, scope, [module]);
				}, this);
			},

			/**
			 * Returns visibility of section binding column.
			 * @return {Boolean} Visibility of section binding column.
			 */
			getSectionBindingColumnVisible: function() {
				const dataSourceSchemaName = this.$dataSourceConfig?.entitySchemaName;
				if (dataSourceSchemaName) {
					if (this.$sectionId) {
						return true;
					}
					var moduleInfo = Terrasoft.configuration.ModuleStructure[dataSourceSchemaName];
					if (!moduleInfo) {
						return false;
					}
					this.set("sectionId", {value: moduleInfo.moduleId});
					this.set("DesignEntitySchemaName", moduleInfo.entitySchemaName);
					return true;
				}
				const sectionId = this.get("sectionId");
				const entitySchemaName = this.get("entitySchemaName");
				const sectionSchemaName = this.getSectionSchemaName();
				return Boolean(sectionId) && Boolean(entitySchemaName) && Boolean(sectionSchemaName);
			},

			loadAvailableEntitySchemas: function(list) {
				const request = {
					serverMethod: "EntitySchemaDesignerService.svc/GetAllAvailableSchemas",
					data: {}
				};
				Terrasoft.CoreServiceProvider.execute(request, function(response) {
					if (response.success) {
						var elements = {};
						Terrasoft.each(response.items, function(item) {
							var id = item.name;
							var element = {
								displayValue: item.caption,
								value: id,
								Name: id,
								Caption: item.caption
							};
							if (!list.contains(id)) {
								elements[id] = element;
							}
						}, this);
						list.loadAll(elements);
					}
				}, this);
			},

			onEntitySchemaNamePrepareList: function(filterValue, list) {
				if (list) {
					list.clear();
				}
				var isAdvancedObjectDisplayModeDisabled = 
					Terrasoft.Features.getIsEnabled("IsAdvancedObjectDisplayModeDisabled");
				if (isAdvancedObjectDisplayModeDisabled) {
					this.loadAvailableEntitySchemas(list);
				} else {
					this.loadLookupData(filterValue, list, "entitySchemaName", false, Terrasoft.emptyFn, this);
				}
			},

			onEntitySchemaNameLoadNextPage: function(params, columnName, isLookupEdit, callback, scope) {
				var isAdvancedObjectDisplayModeDisabled =
					Terrasoft.Features.getIsEnabled("IsAdvancedObjectDisplayModeDisabled");
				if (!isAdvancedObjectDisplayModeDisabled) {
					this.loadLookupDataWithParams(params, columnName, isLookupEdit, callback, scope);
				}
			}

		},
		diff: [
			{
				"operation": "insert",
				"name": "QueryProperties",
				"parentName": "WidgetProperties",
				"propertyName": "items",
				"values": {
					"id": "QueryProperties",
					"selectors": {
						"wrapEl": "#QueryProperties"
					},
					"itemType": Terrasoft.ViewItemType.CONTROL_GROUP,
					"controlConfig": {
						"collapsed": false,
						"caption": {
							"bindTo": "Resources.Strings.QueryPropertiesLabel"
						}
					},
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "EntitySchemaName",
				"parentName": "QueryProperties",
				"propertyName": "items",
				"values": {
					"dataValueType": Terrasoft.DataValueType.ENUM,
					"bindTo": "entitySchemaName",
					"labelConfig": {
						"visible": true,
						"caption": {
							"bindTo": "Resources.Strings.EntitySchemaNameLabel"
						}
					},
					"controlConfig": {
						"prepareList": {
							"bindTo": "onEntitySchemaNamePrepareList"
						},
						"loadNextPage": {
							"bindTo": "loadLookupDataWithParams"
						}
					}
				}
			},
			{
				"operation": "insert",
				"name": "FilterPropertiesGroup",
				"parentName": "WidgetProperties",
				"propertyName": "items",
				"values": {
					"itemType": Terrasoft.ViewItemType.CONTROL_GROUP,
					"controlConfig": {
						"collapsed": false,
						"caption": {"bindTo": "Resources.Strings.FilterPropertiesLabel"}
					},
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "FilterProperties",
				"parentName": "FilterPropertiesGroup",
				"propertyName": "items",
				"values": {
					"id": "FilterProperties",
					"itemType": Terrasoft.ViewItemType.MODULE,
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "SectionBindingGroup",
				"parentName": "WidgetProperties",
				"propertyName": "items",
				"values": {
					"itemType": Terrasoft.ViewItemType.CONTROL_GROUP,
					"controlConfig": {
						"collapsed": false,
						"caption": {"bindTo": "Resources.Strings.SectionBindingGroupCaption"}
					},
					"visible": {
						"bindTo": "getSectionBindingGroupVisible",
					},
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "sectionBindingColumn",
				"parentName": "SectionBindingGroup",
				"propertyName": "items",
				"values": {
					"itemType": Terrasoft.ViewItemType.MODEL_ITEM,
					"generator": "ColumnEditGenerator.generatePartial",
					"labelConfig": {"caption": {"bindTo": "getSectionBindingColumnCaption"}},
					"visible": {"bindTo": "getSectionBindingColumnVisible"},
					"controlConfig": {
						"placeholder": {"bindTo": "Resources.Strings.SectionBindingColumnCaption"},
						"classes": ["placeholderOpacity"]
					}
				}
			},
			{
				"operation": "insert",
				"name": "FormatProperties",
				"parentName": "WidgetProperties",
				"propertyName": "items",
				"values": {
					"id": "FormatProperties",
					"selectors": {
						"wrapEl": "#FormatProperties"
					},
					"itemType": Terrasoft.ViewItemType.CONTROL_GROUP,
					"controlConfig": {
						"collapsed": false,
						"caption": {
							"bindTo": "Resources.Strings.FormatPropertiesLabel"
						}
					},
					"items": []
				}
			}
		]
	};
});
