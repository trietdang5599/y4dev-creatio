/**
 */
Ext.define("Terrasoft.manager.ProcessExclusiveEventBasedGatewaySchema", {
	extend: "Terrasoft.ProcessBaseGatewaySchema",
	alternateClassName: "Terrasoft.ProcessExclusiveEventBasedGatewaySchema",

	//region Properties: Protected

	/**
	 * @inheritdoc Terrasoft.ProcessBaseElementSchema#managerItemUId
	 */
	managerItemUId: "7a3d548c-e994-4d07-b1c0-f471e2ce5687",

	/**
	 * @inheritdoc Terrasoft.manager.ProcessBaseElementSchema#name
	 */
	name: "ExclusiveEventBasedGateway",

	/**
	 * @inheritdoc Terrasoft.BaseProcessSchemaItem#typeName
	 * @override
	 */
	typeName: "Terrasoft.Core.Process.ProcessExclusiveEventBasedGateway",

	/**
	 * @inheritdoc Terrasoft.manager.BaseSchema#caption
	 * @override
	 */
	caption: Terrasoft.Resources.ProcessSchemaDesigner.Elements.ExclusiveEventBasedGatewayCaption,

	/**
	 * @inheritdoc Terrasoft.manager.ProcessBaseElementSchema#smallImageName
	 * @override
	 */
	smallImageName: "EventBasedGatewaySmall.svg",

	/**
	 * @inheritdoc Terrasoft.manager.ProcessBaseElementSchema#largeImageName
	 * @override
	 */
	largeImageName: "EventBasedGatewayLarge.svg",

	/**
	 * @inheritdoc Terrasoft.manager.ProcessBaseElementSchema#titleImageName
	 * @override
	 */
	titleImageName: "exclusiveEventBasedGateway_title.svg",

	/**
	 * @inheritdoc Terrasoft.manager.ProcessFlowElementSchema#getConnectionUserHandles
	 * @override
	 */
	getConnectionUserHandles: function() {
		return ["SequenceFlow"];
	},

	/**
	 * @inheritdoc Terrasoft.manager.ProcessBaseElementSchema#isDeprecated
	 * @override
	 */
	isDeprecated: true

	//endregion

});
