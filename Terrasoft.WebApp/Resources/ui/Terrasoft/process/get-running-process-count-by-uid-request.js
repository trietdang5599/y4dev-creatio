/**
 * Returns count of the running process instances by schema unique identifier (UId).
 */
Ext.define("Terrasoft.process.GetRunningProcessCountByUIdRequest", {
	extend: "Terrasoft.BaseRunningProcessCountRequest",
	alternateClassName: "Terrasoft.GetRunningProcessCountByUIdRequest",

	//region Constructors: Public

	/**
	 * @inheritdoc Terrasoft.BaseObject#constructor
	 * @override
	 */
	constructor: function() {
		this.callParent(arguments);
	},

	//endregion

	//region Properties: Public

	/**
	 * Process schema unique identifier.
	 * @protected
	 * @type {String}
	 */
	schemaUId: null,

	//endregion

	//region Methods: Protected

	/**
	 * @inheritdoc Terrasoft.Serializable#getSerializableObject.
	 * @protected
	 * @override
	 */
	getSerializableObject: function(serializableObject) {
		this.callParent(arguments);
		serializableObject.schemaUId = this.schemaUId;
	},

	/**
	 * @inheritdoc Terrasoft.BaseRequest#validate.
	 * @override
	 */
	validate: function() {
		this.callParent(arguments);
		this.validateSchemaIdentifier(this.schemaUId, "schemaUId");
		return true;
	}

	//endregion

});
