/**
 * Returns count of the running process instances by schema identifier (Id).
 */
Ext.define("Terrasoft.process.GetRunningProcessCountByIdRequest", {
	extend: "Terrasoft.BaseRunningProcessCountRequest",
	alternateClassName: "Terrasoft.GetRunningProcessCountByIdRequest",

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
	 * Process schema identifier.
	 * @protected
	 * @type {String}
	 */
	schemaId: null,

	//endregion

	//region Methods: Protected

	/**
	 * @inheritdoc Terrasoft.Serializable#getSerializableObject.
	 * @protected
	 * @override
	 */
	getSerializableObject: function(serializableObject) {
		this.callParent(arguments);
		serializableObject.schemaId = this.schemaId;
	},

	/**
	 * @inheritdoc Terrasoft.BaseRequest#validate.
	 * @override
	 */
	validate: function() {
		this.callParent(arguments);
		this.validateSchemaIdentifier(this.schemaId, "schemaId");
		return true;
	}

	//endregion

});
