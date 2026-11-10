define("SoapServiceMethodModule", ["BaseSchemaModuleV2",  "css!WebServiceMethodModule"], function() {
	/**
	 * @class Terrasoft.configuration.WebServiceMethodModule
	 */
	Ext.define("Terrasoft.configuration.SoapServiceMethodModule", {
		alternateClassName: "Terrasoft.SoapServiceMethodModule",
		extend: "Terrasoft.BaseSchemaModule",

		/**
		 * @inheritdoc Terrasoft.BaseSchemaModule#initHistoryState
		 * @overridden
		 */
		initHistoryState: Ext.emptyFn,

		/**
		 * @inheritdoc Terrasoft.BaseSchemaModule#initSchemaName
		 * @overridden
		 */
		initSchemaName: function() {
			this.schemaName = "SoapWebServiceMethodPage";
		}
	});
	return Terrasoft.SoapServiceMethodModule;
});
