/**
 */
Ext.define("Terrasoft.manager.ProcessUnsupportedTerminateEventSchema", {
	extend: "Terrasoft.ProcessUnsupportedElementSchema",
	alternateClassName: "Terrasoft.ProcessUnsupportedTerminateEventSchema",

	//region Properties: Protected

	/**
	 * @inheritdoc Terrasoft.ProcessBaseElementSchema#managerItemUId
	 */
	managerItemUId: "25fba723-099f-4b91-a491-641fd0741f08",

	/**
	 * @inheritdoc Terrasoft.manager.ProcessBaseElementSchema#name
	 */
	name: "UnsupportedTerminateEvent",

	/**
	 * @inheritdoc Terrasoft.BaseProcessSchemaItem#typeName
	 * @override
	 */
	typeName: "Terrasoft.Core.Process.ProcessSchemaUnsupportedTerminateEvent"

	//endregion

});
