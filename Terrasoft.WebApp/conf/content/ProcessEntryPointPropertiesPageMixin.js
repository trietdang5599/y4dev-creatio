Terrasoft.configuration.Structures["ProcessEntryPointPropertiesPageMixin"] = {innerHierarchyStack: ["ProcessEntryPointPropertiesPageMixin"]};
define("ProcessEntryPointPropertiesPageMixin", ["ProcessModuleUtilities", "Contact"], function(Utilities, Contact) {

	/**
	 * Implements work with SchemaUId attribute in process properties page.
	 */
	Ext.define("Terrasoft.configuration.mixins.ProcessEntryPointPropertiesPageMixin", {
		alternateClassName: "Terrasoft.ProcessEntryPointPropertiesPageMixin",

		//region Methods: Protected

		/**
		 * Init entity schemas list.
		 * @protected
		 * @param {Function} callback Callback function.
		 * @param {Object} scope Callback function scope.
		 */
		initEntitySchemas: function(callback, scope) {
			const schemasFilter = this.getSchemaListFilter("EntitySchemaManager");
			Utilities.getSchemasByFilter(schemasFilter, function(schemas) {
				const entitySchemas = Ext.create("Terrasoft.Collection");
				entitySchemas.loadAll(schemas);
				this.set("EntitySchemas", entitySchemas);
				callback.call(scope);
			}, this);
		},

		/**
		 * Returns schema list filter.
		 * @protected
		 * @param {String} managerName Schema manager name.
		 * @return {Object}
		 */
		getSchemaListFilter: function(managerName) {
			const element = this.get("ProcessElement");
			const parentSchema = element.parentSchema;
			const packageUId = Terrasoft.Features.getIsEnabled("AutoAddPackageDependenciesInProcesses")
				? Terrasoft.GUID_EMPTY
				: parentSchema.packageUId;
			return  {
				ManagerName: managerName,
				PackageUId: packageUId,
				UseExtendParent: false,
				ExcludedSchemas: []
			};
		},

		/**
		 * The event handler for preparing entity schemas drop-down list.
		 * @protected
		 * @param {Object} filter Filters for data preparation.
		 * @param {Terrasoft.Collection} list The data for the drop-down list.
		 */
		onPrepareEntitySchemaList: function(filter, list) {
			if (Terrasoft.isEmptyObject(list)) {
				return;
			}
			list.clear();
			const parameterName = this.getEntitySchemaParameterName();
			const selectedSchema = this.get(parameterName);
			let entitySchemas = this.get("EntitySchemas");
			if (selectedSchema) {
				entitySchemas = entitySchemas.filterByFn(function(schema) {
					return schema.value !== selectedSchema.value;
				});
			}
			list.loadAll(entitySchemas);
		},

		/**
		 * Returns Entity schema parameter name.
		 * @protected
		 * @return {string}
		 */
		getEntitySchemaParameterName: function() {
			return "EntitySchemaUId";
		},

		/**
		 * Initializes EntitySchemaUId parameter.
		 * @protected
		 * @param {ProcessElement} element Process element.
		 * @param {Function} callback Callback function.
		 * @param {Object} scope Callback function scope.
		 */
		initEntitySchema: function(element, callback, scope) {
			const parameterName = this.getEntitySchemaParameterName();
			const parameter = element.findParameterByName(parameterName);
			const mappingValue = parameter.getMappingValue();
			const entitySchemaUId = mappingValue.value;
			const changeEventName = "change:" + parameterName;
			if (Terrasoft.isEmptyGUID(entitySchemaUId) || Ext.isEmpty(entitySchemaUId)) {
				this.on(changeEventName, this.onEntitySchemaUIdChanged, this);
				callback.call(scope);
				return;
			}
			Utilities.loadSchemaDisplayValue(entitySchemaUId, function(displayValue) {
				this.set(parameterName, {
					value: entitySchemaUId,
					displayValue: displayValue
				});
				this.on(changeEventName, this.onEntitySchemaUIdChanged, this);
				callback.call(scope);
			}, this);
		},

		/**
		 * Handles after connection object schema changed, resets connection instance object.
		 * @protected
		 * @param {Terrasoft.BaseViewModel} model Page view model.
		 * @param {Object} entitySchema New entity schema value.
		 */
		onEntitySchemaUIdChanged: function(model, entitySchema) {
			entitySchema = entitySchema || {};
			const entitySchemaUId = entitySchema.value;
			if (Ext.isEmpty(entitySchemaUId)) {
				this.set("EntityId", null);
			} else {
				const entity = this.get("EntityId") || {};
				this.set("EntityId", {
					value: null,
					displayValue: null,
					source: Terrasoft.ProcessSchemaParameterValueSource.None,
					referenceSchemaUId: entitySchemaUId,
					dataValueType: entity.dataValueType
				});
			}
		},

		/**
		 * @inheritdoc Terrasoft.MenuItemsMappingMixin#getParameterReferenceSchemaUId
		 * @override
		 */
		getParameterReferenceSchemaUId: function(elementParameter) {
			let referenceSchemaUId;
			if(elementParameter.name === "OwnerId"){
				referenceSchemaUId = Contact.uId;
			} else {
				const entitySchema = this.get("EntitySchemaUId");
				referenceSchemaUId = entitySchema ? entitySchema.value : null;
			}
			return referenceSchemaUId;
		}

		//endregion

	});
});


