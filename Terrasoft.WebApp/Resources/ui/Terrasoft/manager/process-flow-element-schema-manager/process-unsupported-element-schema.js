/**
 */
Ext.define("Terrasoft.manager.ProcessUnsupportedElementSchema", {
	extend: "Terrasoft.ProcessFlowElementSchema",
	alternateClassName: "Terrasoft.ProcessUnsupportedElementSchema",

	//region Properties: Protected

	/**
	 * @inheritdoc Terrasoft.ProcessBaseElementSchema#managerItemUId
	 */
	managerItemUId: "b49a4cc3-e725-4ef2-9263-73c5a6c15059",
	/**
	 * @inheritdoc Terrasoft.manager.ProcessBaseElementSchema#name
	 */
	name: "UnsupportedElement",

	/**
	 * @inheritdoc Terrasoft.BaseProcessSchemaItem#typeName
	 * @override
	 */
	typeName: "Terrasoft.Core.Process.ProcessSchemaUnsupportedElement",

	/**
	 * @inheritdoc Terrasoft.manager.ProcessBaseElementSchema#nodeType
	 * @override
	 */
	nodeType: Terrasoft.diagram.UserHandlesConstraint.Event,

	/**
	 * @inheritdoc Terrasoft.manager.ProcessBaseElementSchema#width
	 * @override
	 */
	width: 31,

	/**
	 * @inheritdoc Terrasoft.manager.ProcessBaseElementSchema#height
	 * @override
	 */
	height: 31,

	/**
	 * @inheritdoc Terrasoft.manager.ProcessBaseElementSchema#group
	 * @override
	 */
	emptyDiagramCaption: false,

	/**
	 * @inheritdoc Terrasoft.manager.ProcessBaseElementSchema#captionWidth
	 * @override
	 */
	captionWidth: 80,

	/**
	 * @inheritdoc Terrasoft.manager.ProcessFlowElementSchema#color
	 * @override
	 */
	color: "#92A4AF",

	/**
	 * @inheritdoc Terrasoft.manager.BaseSchema#caption
	 */
	caption: Terrasoft.Resources.ProcessSchemaDesigner.Elements.UnsupportedElement,

	/**
	 * @inheritdoc Terrasoft.manager.ProcessBaseElementSchema#editPageSchemaName
	 */
	editPageSchemaName: "ProcessUnsupportedElementPropertiesPage",

	/**
	 * @inheritdoc Terrasoft.manager.ProcessBaseElementSchema#titleImageName
	 * @override
	 */
	titleImageName: "unsupportedElement_title.svg",

	/**
	 * @inheritdoc Terrasoft.manager.ProcessBaseElementSchema#isValid
	 * @override
	 */
	isValid: true,

	//endregion

	//region Methods: Protected

	/**
	 * @protected
	 * @type {String}
	 */
	unsupportedType: "",

	/**
	 * @inheritdoc Terrasoft.manager.BaseSchema#getSerializableProperties
	 * @override
	 */
	getSerializableProperties: function() {
		const baseSerializableProperties = this.callParent(arguments);
		return Ext.Array.push(baseSerializableProperties, ["unsupportedType"]);
	}

	//endregion

});
