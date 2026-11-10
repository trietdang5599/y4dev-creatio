/**
 */
Ext.define("Terrasoft.manager.ProcessSchemaManager", {
	extend: "Terrasoft.manager.BaseProcessSchemaManager",
	alternateClassName: "Terrasoft.ProcessSchemaManager",
	singleton: true,

	// region Properties: Protected

	/**
	 * @inheritdoc Terrasoft.BaseManager#itemClassName
	 * @override
	 */
	itemClassName: "Terrasoft.ProcessSchemaManagerItem",

	/**
	 * @inheritdoc Terrasoft.BaseSchemaManager#managerName
	 * @override
	 */
	managerName: "ProcessSchemaManager",

	/**
	 * @inheritdoc Terrasoft.BaseSchemaManager#schemaManagerServiceName
	 * @protected
	 * @override
	 */
	schemaManagerServiceName: "ServiceModel/ProcessSchemaManagerService.svc",

	/**
	 * @inheritdoc Terrasoft.BaseProcessSchemaManager#ProcessSchemaManagerService
	 * @override
	 */
	serviceName: "ProcessSchemaManagerService",

	/**
	 * @inheritdoc Terrasoft.BaseSchemaManager#outdatedEventName
	 * @override
	 */
	outdatedEventName: "ProcessSchema_Outdated",

	/**
	 * @inheritdoc Terrasoft.BaseSchemaManager#useNotification
	 * @override
	 */
	useNotification: true,

	/**
	 * @inheritdoc Terrasoft.BaseProcessSchemaManager#schemaElementsInitializerClassName
	 * @override
	 */
	schemaElementsInitializerClassName: "Terrasoft.ProcessSchemaElementsInitializer",

	// endregion

	// region Properties: Public

	/**
	 * @inheritdoc Terrasoft.BaseSchemaManager#defSchemaUId
	 * @override
	 */
	defSchemaUId: "bb4d6607-026b-4b27-b640-8f5c77c1e89d",

	//endregion

	// region Methods: Public

	/**
	 * @inheritdoc Terrasoft.BaseSchemaManager#createSchema
	 * @override
	 */
	createSchema: function() {
		var schema = this.callParent(arguments);
		schema.name = "";
		schema.parentSchemaUId = this.defSchemaUId;
		schema.isCreatedInSvg = true;
		schema.isInterpretable = true;
		schema.serializeToDB = true;
		schema.tag = "Business Process";
		return schema;
	},

	/**
	 * Queries new schema instance by UId, not need manager initialization.
	 * @override
	 * @param {String} schemaUId Schema identifier.
	 * @param {Function} callback Callback function.
	 * @param {Function} callback.itemInstance Item instance.
	 * @param {Object} scope Execution context.
	 */
	forceGetInstanceByUId: function(schemaUId, callback, scope) {
		var item = this.createManagerItem({uId: schemaUId});
		item.forceGetInstance(function(itemInstance) {
			callback.call(scope, itemInstance);
		}, this);
	},

	/**
	 * Queries new sub process schema instance by UId.
	 * @override
	 * @param {String} schemaUId Schema identifier.
	 * @param {Function} callback Callback function.
	 * @param {Terrasoft.ProcessSchema} callback.schema Schema instance.
	 * @param {Object} scope Execution context.
	 */
	getSubProcessSchemaInstanceByUId: function(schemaUId, callback, scope) {
		if (Terrasoft.isEmpty(schemaUId)) {
			Ext.callback(callback, scope, [null]);
			return;
		}
		var itemConfig = {uId: schemaUId};
		var item = this.createManagerItem(itemConfig);
		var config = {convertLocalizableStringToParameter: false};
		item.forceGetInstanceByConfig(config, callback, scope);
	},

	/**
	 * @inheritdoc Terrasoft.BaseProcessSchemaManager#getCanUseProcessVersions
	 * @override
	 * @return {Boolean} True
	 */
	getCanUseProcessVersions: function() {
		return true;
	}

	// endregion

});
