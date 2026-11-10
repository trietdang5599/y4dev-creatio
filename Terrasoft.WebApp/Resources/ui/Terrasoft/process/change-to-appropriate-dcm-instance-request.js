/**
 * Class represents request that changes DCM process instance for the specified record.
 */
Ext.define("Terrasoft.process.ChangeToAppropriateDcmInstanceRequest", {
	extend: "Terrasoft.BaseProcessRequest",
	alternateClassName: "Terrasoft.ChangeToAppropriateDcmInstanceRequest",

	//region Properties: Protected

	/**
	 * @inheritdoc Terrasoft.BaseRequest#contractName
	 * @protected
	 * @override
	 */
	contractName: "ChangeToAppropriateDcmInstance",

	//endregion

	//region Properties: Public

	/**
	 * Schema name.
	 * @type {String}
	 */
	entitySchemaName: null,

	/**
	 * Identifier of the record.
	 * @type {Guid}
	 */
	recordId: null,

	/**
	 * Identifier of the current DCM stage.
	 * @type {Guid}
	 */
	currentStageId: null,

	//endregion

	//region Methods: Protected

	/**
	 * @inheritdoc Terrasoft.Serializable#getSerializableObject.
	 * @protected
	 * @override
	 */
	getSerializableObject: function(serializableObject) {
		this.callParent(arguments);
		serializableObject.entitySchemaName = this.entitySchemaName;
		serializableObject.recordId = this.recordId;
		serializableObject.currentStageId = this.currentStageId;
	}

	//endregion

});
