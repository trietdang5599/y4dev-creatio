define("FullscreenHeaderModule", ["BaseSchemaModuleV2"], function() {
	Ext.define("Terrasoft.configuration.FullscreenHeaderModule", {
		extend: "Terrasoft.BaseSchemaModule",
		alternateClassName: "Terrasoft.FullscreenHeaderModule",

		/**
		 * @inheritdoc BaseSchemaModule#initSchemaName
		 * @override
		 */
		initSchemaName: function() {
			this.schemaName = "FullscreenHeaderSchema";
		}

	});
	return Terrasoft.FullscreenHeaderModule;
});
