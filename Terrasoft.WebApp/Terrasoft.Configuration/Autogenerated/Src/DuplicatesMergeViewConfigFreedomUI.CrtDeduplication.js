define("DuplicatesMergeViewConfigFreedomUI", ["css!DuplicatesMergeViewConfigFreedomUI", "DuplicatesMergeViewConfigV2"],
	function() {
		Ext.define("Terrasoft.configuration.DuplicatesMergeViewConfigFreedomUI", {
			extend: "Terrasoft.DuplicatesMergeViewConfig",
			alternateClassName: "Terrasoft.DuplicatesMergeViewConfigFreedomUI",

			generate: function(config) {
				const content = this.generateContent(config);
				return [
					{
						"name": "ModuleContainer",
						"itemType": Terrasoft.ViewItemType.CONTAINER,
						"classes": {wrapClassName: ["duplicates-merge-container", "duplicates-merge-container-freedom-ui"]},
						"items": [
							...(content ? [content] : []),
						]
					}
				];
			},

			generateRadioButton: function() {
				const config = this.callParent(arguments);
				config.click = {
					bindTo: "onDataChanged"
				};
				return config;
			}
		});
	});