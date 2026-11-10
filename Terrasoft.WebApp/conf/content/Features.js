Terrasoft.configuration.Structures["Features"] = {innerHierarchyStack: ["Features"]};
define("Features", ["BaseSchemaModuleV2"], function() {

	Ext.define("Terrasoft.configuration.FeaturesModule", {
		alternateClassName: "Terrasoft.FeaturesModule",
		extend: "Terrasoft.BaseSchemaModule",

		useHistoryState: false,

		/**
		 * @inheritdoc Terrasoft.BaseSchemaModule#init
		 * @overridden
		 */
		init: function(callback, scope) {
			this.sandbox.registerMessages({
				"ReplaceHistoryState": {
					direction: Terrasoft.MessageDirectionType.PUBLISH,
					mode: Terrasoft.MessageMode.BROADCAST
				}
			});
			if (Terrasoft.Features.getIsEnabled("UseFeatureService")) {
				Terrasoft.MaskHelper.showBodyMask();
				this.sandbox.publish("ReplaceHistoryState", {hash: "Section/AppFeature_ListPage"});
				return;
			}
			this.callParent(arguments);
		},

		destroy: function() {
			this.sandbox.unRegisterMessages(["ReplaceHistoryState"]);
		},

		initSchemaName: function() {
			this.schemaName = "FeaturesPage";
		}

	});

	return Terrasoft.FeaturesModule;
});


