Terrasoft.configuration.Structures["DuplicatesMergeViewModelFreedomUI"] = {innerHierarchyStack: ["DuplicatesMergeViewModelFreedomUI"]};
define("DuplicatesMergeViewModelFreedomUI", ["DuplicatesMergeViewModelV2"],
	function() {
		Ext.define("Terrasoft.configuration.DuplicatesMergeViewModelFreedomUI", {
			extend: "Terrasoft.DuplicatesMergeViewModel",
			alternateClassName: "Terrasoft.DuplicatesMergeViewModelFreedomUI",

			messages: {
				"Initialized": {
					mode: Terrasoft.MessageMode.PTP,
					direction: Terrasoft.MessageDirectionType.PUBLISH
				},
				"DataChanged": {
					mode: Terrasoft.MessageMode.PTP,
					direction: Terrasoft.MessageDirectionType.PUBLISH
				},
			},

			init: function() {
				this.callParent(arguments);
				this.sandbox.registerMessages(this.messages);
				this.sandbox.publish("Initialized", undefined, [this.sandbox.id]);
				this.onDataChanged();
			},

			onDataChanged: function() {
				var mergeColumns = this.get("MergeColumns");
				var mergeConfig = {};
				Terrasoft.each(mergeColumns, function(columnName) {
					mergeConfig[columnName] = this.get(columnName);
				}, this);
				this.sandbox.publish("DataChanged", mergeConfig, [this.sandbox.id]);
			},
		});
	});


