Terrasoft.configuration.Structures["PageUtilities"] = {innerHierarchyStack: ["PageUtilities"]};
define("PageUtilities", ["@creatio/utils"], function(creatioUtils) {
	/**
	 * @class Terrasoft.configuration.mixins.PageUtilities
	 * Contains utility methods used by page.
	 */
	Ext.define("Terrasoft.configuration.mixins.PageUtilities", {
		alternateClassName: "Terrasoft.PageUtilities",

		//region Properties: Private

		/**
		 * Default card module.
		 * @private
		 * @type {String}
		 */
		defaultCardModule: "CardModuleV2",

		//endregion

		//region Methods: Protected

		/**
		 * Finds lookup column attribute value.
		 * @protected
		 * @virtual
		 * @param {String} columnName Lookup column name.
		 * @param {Object} attribute Lookup column attribute.
		 * @return {Object} Value of card schema type lookup column.
		 */
		findLookupColumnAttributeValue: function(columnName, attribute) {
			return this.get && (this.get(columnName + "." + attribute) || this.get(attribute));
		},

		//endregion

		//region Methods: Public

		/**
		 * Opens target page.
		 * @param {Object} config Target page config
		 * @param {String} config.entitySchemaName Name of page entity schema.
		 * @param {String} config.columnName Column name of target record.
		 * @param {String} config.value Value of target record.
		 * @param {Object} config.historyState PushHistoryState additional config.
		 */
		openPage: function(config) {
			var entitySchemaName = config.entitySchemaName;
			var columnName = config.columnName || "";
			var value = config.value || "";
			var cardSchema = this.getCardSchemaName(entitySchemaName, columnName, value);
			var cardModule = Terrasoft.ModuleUtils.getCardModule({
				entityName: entitySchemaName,
				cardSchema: cardSchema,
				defaultModule: this.defaultCardModule,
			});
			var path = Terrasoft.combinePath(cardModule, cardSchema, "edit", value);
			var historyStateConfig = {hash: path};
			if (config.historyState) {
				Ext.apply(historyStateConfig, config.historyState);
			}
			this.sandbox.publish("PushHistoryState", historyStateConfig);
		},

		/**
		 * Returns page name from modulePages array found by type column.
		 * Retrieves type value from the view model.
		 * @private
		 * @param {String} columnName Name of the lookup column to be found.
		 * @param {String} attribute Name of the type column.
		 * @param {Array} modulePages Array of the module or entity edit pages.
		 * @param {String} entitySchemaName Name of the entity schema.
		 * @param {Array} defaultValues Default values.
		 * @param {String} operation Operation.
		 * @return {String} Typed page name.
		 */
		_getCardSchemaNameByType: function(columnName, attribute, modulePages, entitySchemaName, defaultValues, operation) {
			const cardSchemaType = (attribute || columnName) && this.findLookupColumnAttributeValue(columnName, attribute);
			const options = {
				action: operation,
				entityName: entitySchemaName,
				typeColumnValue: cardSchemaType?.value,
				defaultValues: Array.isArray(defaultValues) ? defaultValues : null,
			};
			return creatioUtils.NavigationUtils.getPageForAction(options)?.cardSchema;
		},

		/**
		 * Gets the name of the entity editing cards.
		 * @param {String} entitySchemaName Name of entity schema.
		 * @param {String} [columnName] Column Name.
		 * @param {Array} [defaultValues] Default values.
		 * @param {String} [operation] Operation.
		 * @return {String} Name of the entity editing cards.
		 */
		getCardSchemaName: function(entitySchemaName, columnName, defaultValues = [], operation) {
			const structure = this.getEntityStructure(entitySchemaName) || this.getModuleStructure(entitySchemaName);
			if (!structure) {
				throw new Terrasoft.ItemNotFoundException();
			}
			const cardSchemaName = this._getCardSchemaNameByType(
				columnName, structure.attribute, structure.pages, entitySchemaName, defaultValues, operation);
			return cardSchemaName || structure.cardSchema || structure.pages?.[0]?.cardSchema;
		},

		/**
		 * Returns structure of the module.
		 * @param {String} moduleName Name of the module.
		 * @return {Object} Structure of the module.
		 */
		getModuleStructure: function(moduleName) {
			return Terrasoft.ModuleUtils.getModuleStructureByName(moduleName || this.entitySchemaName);
		},

		/**
		 * Returns entity schema information from entity structure for entitySchemaName.
		 * If it is not specified, use entitySchemaName field of the current class instance.
		 * @protected
		 * @param {String} [entitySchemaName] Entity schema name.
		 * @return {Object} Entity schema information.
		 */
		getEntityStructure: function(entitySchemaName) {
			return Terrasoft.ModuleUtils.getEntityStructureByName(entitySchemaName || this.entitySchemaName);
		},

		/**
		 * Returns sign that exists edit page schema for subscriber entity schema.
		 * @protected
		 * @param {String} schemaName Subscriber entity schema name.
		 * @return {String} Sign that exists edit page schema for subscriber entity schema.
		 */
		hasEntityEditPage: function(schemaName) {
			const entityStructure = this.getEntityStructure(schemaName);
			if (!entityStructure) {
				return false;
			}
			const pages = entityStructure.pages;
			if (pages.length > 0) {
				return Boolean(pages[0]?.cardSchema);
			}
			return false;
		}

		//endregion
	});

	return Terrasoft.PageUtilities;
});


