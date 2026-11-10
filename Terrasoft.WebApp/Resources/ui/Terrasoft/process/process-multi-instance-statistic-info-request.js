Ext.define("Terrasoft.process.ProcessMultiInstanceStatisticInfoRequest", {
	extend: "Terrasoft.BaseRequest",
	alternateClassName: "Terrasoft.ProcessMultiInstanceStatisticInfoRequest",

	contractName: "ProcessMultiInstanceStatisticInfoRequest",

	//region Properties: Public

	/**
	 * SysProcessLog identifier.
	 */
	sysProcessLogId: null,

	//endregion

	//region Methods: Protected

	/**
	 * @inheritdoc Terrasoft.Serializable#getSerializableObject.
	 * @protected
	 * @override
	 */
	getSerializableObject: function(serializableObject) {
		this.callParent(arguments);
		serializableObject.sysProcessLogId = this.sysProcessLogId;
	}

	//endregion

});
