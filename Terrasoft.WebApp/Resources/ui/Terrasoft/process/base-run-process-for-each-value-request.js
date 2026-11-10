/**
 * Class represents base request that runs processes on multiple records from a section.
 */
Ext.define("Terrasoft.process.BaseRunProcessForEachValueRequest", {
	extend: "Terrasoft.RunProcessRequest",
	alternateClassName: "Terrasoft.BaseRunProcessForEachValueRequest",

	//region Properties: Public

	/**
	 * Name of input parameter in process that runs for the record from the section.
	 */
	inputParameterName: null,

	/**
	 * UId of input parameter in process that runs for the record from the section.
	 */
	inputParameterUId: null,

	//endregion

	/**
	 * @inheritdoc Terrasoft.Serializable#getSerializableObject.
	 * @protected
	 * @override
	 */
	getSerializableObject: function() {
		const config = this.callParent(arguments);
		config.inputParameterName = this.inputParameterName;
		config.inputParameterUId = this.inputParameterUId;
		return config;
	},

	/**
	 * @inheritdoc Terrasoft.BaseRequest#getSerializableObject.
	 * @protected
	 * @override
	 */
	getRequestConfig: function() {
		const config = this.callParent(arguments);
		config.batchStart = true;
		return config;
	}

	//endregion

});
