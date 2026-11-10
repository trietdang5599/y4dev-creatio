 define("MainHeader8xModule", ["MainHeaderModule", "css!MainHeaderModule", "css!MainHeader8xModule"], function() {
	Ext.define("Terrasoft.configuration.MainHeader8xModule", {
			extend: "Terrasoft.configuration.MainHeaderModule",
			alternateClassName: "Terrasoft.MainHeader8xModule",
			Ext: null,
			sandbox: null,
			Terrasoft: null,
		
			/**
			 * @inheritDoc Terrasoft.BaseSchemaModule#initSchemaName
			 * @override
			 */
			initSchemaName: function() {
					this.schemaName = "MainHeader8xSchema";
			}
	});
	 return Terrasoft.MainHeader8xModule;
 });