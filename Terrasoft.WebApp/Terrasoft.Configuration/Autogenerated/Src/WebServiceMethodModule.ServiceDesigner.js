define("WebServiceMethodModule", ["BaseSchemaModuleV2",  "css!WebServiceMethodModule"], function() {
	/**
	 * @class Terrasoft.configuration.WebServiceMethodModule
	 */
	Ext.define("Terrasoft.configuration.WebServiceMethodModule", {
		alternateClassName: "Terrasoft.WebServiceMethodModule",
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
			this.schemaName = "RestWebServiceMethodPage";
		}
	});
	return Terrasoft.WebServiceMethodModule;
});
