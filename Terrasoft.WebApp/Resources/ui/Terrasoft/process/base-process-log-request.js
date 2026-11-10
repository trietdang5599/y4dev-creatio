Ext.define("Terrasoft.process.BaseProcessLogRequest", {
	extend: "Terrasoft.BaseRequest",
	alternateClassName: "Terrasoft.BaseProcessLogRequest",

	//region Properties: Protected

	/**
	 * Base URI.
	 * @protected
	 * @type {String}
	 */
	baseUri: "../ServiceModel/ProcessLogService.svc",

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
	}

	//endregion

});
