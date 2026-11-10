/**
 */
Ext.define("Terrasoft.manager.ProcessBoundaryEventSchema", {
	extend: "Terrasoft.ProcessUnsupportedElementSchema",
	alternateClassName: "Terrasoft.ProcessBoundaryEventSchema",

	//region Properties: Protected

	/**
	 * @inheritdoc Terrasoft.ProcessBaseElementSchema#managerItemUId
	 */
	managerItemUId: "bae0686d-ebe6-4f1c-bf7b-fa1aee7afccd",
	/**
	 * @inheritdoc Terrasoft.manager.ProcessBaseElementSchema#name
	 */
	name: "BoundaryEventElement",

	/**
	 * @inheritdoc Terrasoft.BaseProcessSchemaItem#typeName
	 * @override
	 */
	typeName: "Terrasoft.Core.Process.ProcessSchemaBoundaryEvent",

	/**
	 * @inheritdoc Terrasoft.manager.BaseSchema#caption
	 */
	caption: Terrasoft.Resources.ProcessSchemaDesigner.Elements.BondaryEventCaption,

	/**
	 * @inheritdoc Terrasoft.manager.ProcessBaseElementSchema#editPageSchemaName
	 */
	editPageSchemaName: "ProcessBoundaryEventPropertiesPage",

		/**
	 * @inheritdoc Terrasoft.manager.ProcessBaseElementSchema#isValid
	 * @override
	 */
	isValid: true,

	/**
	 * @protected
	 * @type {Guid}
	 */
	attachedToElementUId: null,

	//endregion
	
	//region Constructors: Public

	constructor: function() {
		this.callParent(arguments);
	},

	//endregion

	//region Methods: Protected

	initializeProperties: function() {
		this.attachedToElementUId = this.containerUId;
	},
	
	/**
	 * @inheritdoc Terrasoft.manager.BaseSchema#getSerializableProperties
	 * @override
	 */
	getSerializableProperties: function() {
		const baseSerializableProperties = this.callParent(arguments);
		this.initializeProperties();
		return Ext.Array.push(baseSerializableProperties, ["attachedToElementUId"]);
	}

	//endregion

});
