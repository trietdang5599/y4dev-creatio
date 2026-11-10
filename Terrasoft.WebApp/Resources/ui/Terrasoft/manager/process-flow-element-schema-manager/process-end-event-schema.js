/**
 */
Ext.define("Terrasoft.manager.ProcessEndEventSchema", {
	extend: "Terrasoft.ProcessTerminateEventSchema",
	alternateClassName: "Terrasoft.ProcessEndEventSchema",

	//region Properties: Protected

	/**
	 * @inheritdoc Terrasoft.ProcessBaseElementSchema#managerItemUId
	 */
	managerItemUId: "45ceaae2-4e1f-4c0c-86aa-cd4aeb4da913",

	/**
	 * @inheritdoc Terrasoft.BaseProcessSchemaItem#typeName
	 * @protected
	 * @override
	 */
	typeName: "Terrasoft.Core.Process.ProcessSchemaEndEvent",

	/**
	 * @inheritdoc Terrasoft.manager.ProcessBaseElementSchema#isDeprecated
	 * @override
	 */
	isDeprecated: true

	//endregion

});
