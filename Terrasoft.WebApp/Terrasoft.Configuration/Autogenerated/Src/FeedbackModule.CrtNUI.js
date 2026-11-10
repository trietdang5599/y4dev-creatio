define("FeedbackModule", ["ext-base", "sandbox", "terrasoft", "BaseSchemaModuleV2"],
	function(Ext, sandbox, Terrasoft) {

		Ext.define("Terrasoft.configuration.FeedbackModule", {
			extend: "Terrasoft.BaseSchemaModule",
			alternateClassName: "Terrasoft.FeedbackModule",

			initSchemaName: function() {
				this.schemaName = Terrasoft.feedbackConfig.schemaName;
			},
			
			renderTo: null,
			useHistoryState: false
		});

		return Ext.create("Terrasoft.FeedbackModule", {
			Ext: Ext,
			sandbox: sandbox,
			renderTo: Terrasoft.appFramework === "NETCOREAPP" ? this.Ext.getBody() : undefined,
			Terrasoft: Terrasoft
		});

	});
