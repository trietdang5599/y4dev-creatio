/**
 * Returns count of the running process instances by schema Id or UId.
 */
Ext.define("Terrasoft.process.BaseRunningProcessCountRequest", {
	extend: "Terrasoft.BaseRequest",
	alternateClassName: "Terrasoft.BaseRunningProcessCountRequest",

	//region Properties: Protected

	/**
	 * Base URI.
	 * @protected
	 * @type {String}
	 */
	baseUri: "../ServiceModel/ProcessEngineService.svc",

	/**
	 * Response query class name.
	 * @protected
	 * @type {String}
	 */
	responseClassName: "Terrasoft.GetRunningProcessCountResponse",

	//endregion

	//region Properties: Protected

	/**
	 * @inheritdoc Terrasoft.BaseRequest#contractName
	 * @protected
	 * @override
	 */
	contractName: "GetRunningProcessesCount",

	//endregion

	//region Properties: Public

	/**
	 * Determines whether to count for specified version or not.
	 * @type {Boolean}
	 */
	countSpecifiedVersion: false,

	/**
	 * Manager name to get search schema in.
	 * @type {String}
	 */
	managerName: "ProcessSchemaManager",

	//endregion

	//region Methods: Protected

	/**
	 * @inheritdoc Terrasoft.BaseRequest#getRequestConfig
	 * @protected
	 * @override
	 * @return {Object}
	 */
	getRequestConfig: function() {
		const config = this.callParent(arguments);
		config.url = this.baseUri + "/" + this.contractName;
		return config;
	},

	/**
	 * @inheritdoc Terrasoft.Serializable#getSerializableObject.
	 * @protected
	 * @override
	 */
	getSerializableObject: function(serializableObject) {
		this.callParent(arguments);
		serializableObject.countSpecifiedVersion = this.countSpecifiedVersion;
		serializableObject.managerName = this.managerName;
	},

	/**
	 * Validates schema identifier.
	 * @param {String} value Value to validate.
	 * @param {String} name Name of the value.
	 */
	validateSchemaIdentifier: function(value, name) {
		if (Ext.isEmpty(value) || Terrasoft.isEmptyGUID(value)) {
			throw new Terrasoft.NullOrEmptyException({
				argumentName: name
			});
		}
	}

	//endregion

});
