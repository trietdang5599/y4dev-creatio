define("MLRegressionModelPage", [], function() {
	return {
		entitySchemaName: "MLModel",
		methods: {
			/**
			 * @inheritDoc
			 * @overriden
			 */
			filterTargetColumns: function(column) {
				return this.callParent(arguments) && Terrasoft.isNumberDataValueType(column.dataValueType);
			}
		},
		diff: [
			{
				"name": "RegressionAcademyUrl",
				"operation": "insert",
				"parentName": "FaqUrls",
				"propertyName": "items",
				"values": {
					"itemType": Terrasoft.ViewItemType.BUTTON,
					"style": Terrasoft.controls.ButtonEnums.style.TRANSPARENT,
					"classes": {
						"textClass": ["faq-button", "base-edit-link"]
					},
					"click": {"bindTo": "onFaqClick"},
					"caption": "$Resources.Strings.RegressionAcademyCaption",
					"tag": {"contextHelpId": 1941}
				}
			}
		]
	};
});
