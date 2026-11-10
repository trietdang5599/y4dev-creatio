/**
 *  Class represents request that runs processes on multiple records from a section.
 */
Ext.define("Terrasoft.process.RunProcessForEachValueRequest", {
	extend: "Terrasoft.BaseRunProcessForEachValueRequest",
	alternateClassName: "Terrasoft.RunProcessForEachValueRequest",

	//region Properties: Protected

	/**
	 * @inheritdoc Terrasoft.BaseRequest#contractName
	 * @protected
	 * @override
	 */
	contractName: "RunProcessForEachValue",

	//endregion

	/**
	 * Collection of input parameter values by which the process run.
	 */
	values: null,

	//endregion

	/**
	 * @inheritdoc Terrasoft.Serializable#getSerializableObject.
	 * @protected
	 * @override
	 */
	getSerializableObject: function() {
		const config = this.callParent(arguments);
		config.values = this.values;
		return config;
	}

	//endregion

});
