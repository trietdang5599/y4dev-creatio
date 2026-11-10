define("SystemDesigner", [], function() {
	return {
		methods: {
			/**
			 * Opens ML model section.
			 * @private
			 */
			navigateToMLModelSection: function() {
				this.openSection("MLModelSection");
			}
		},
		diff: [
			{
				"operation": "insert",
				"propertyName": "items",
				"parentName": "SystemSettingsTile",
				"name": "MLModelSection",
				"index": 8,
				"values": {
					"itemType": Terrasoft.ViewItemType.LINK,
					"caption": {"bindTo": "Resources.Strings.MLModelSectionCaption"},
					"tag": "navigateToMLModelSection",
					"click": {"bindTo": "invokeOperation"}
				}
			}
		]
	};
});
