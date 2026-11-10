/**
 * Module to load ContentSmartHtmlEditPage.
 */
define("ContentSmartHtmlEditModule", ["BaseSchemaModuleV2"], function() {
	Ext.define("Terrasoft.configuration.ContentSmartHtmlEditModule", {
		extend: "Terrasoft.BaseSchemaModule",
		alternateClassName: "Terrasoft.ContentSmartHtmlEditModule",

		sandbox: null,
		/**
		 * @inheritDoc Terrasoft.BaseSchemaModule#generateViewContainerId
		 * @override
		 */
		generateViewContainerId: false,

		/**
		 * @inheritDoc Terrasoft.BaseSchemaModule#initSchemaName
		 * @override
		 */
		initSchemaName: function() {
			this.schemaName = "ContentSmartHtmlEditPage";
		},

		/**
		 * @inheritDoc Terrasoft.BaseSchemaModule#initHistoryState
		 * @override
		 */
		initHistoryState: Terrasoft.emptyFn
	});
	return Terrasoft.ContentSmartHtmlEditModule;
});
