define("MLClassificationModelPage", ["MLConfigurationConsts"],
	function(MLConfigurationConsts) {
		return {
			entitySchemaName: "MLModel",
			attributes: {
			},
			methods: {
				/**
				 * @returns {Boolean} True if ConfidentValueLowEdge field should be visible.
				 */
				getIsConfidentValueLowEdgeVisible: function() {
					return this.getLookupValue("MLConfidentValueMethod")
						=== MLConfigurationConsts.ConfidentValueMethods.MaximumProbability;
				},

				/**
				 * @inheritDoc
				 * @overriden
				 */
				filterTargetColumns: function(column) {
					return this.callParent(arguments) && Terrasoft.isLookupDataValueType(column.dataValueType);
				}
			},
			diff: /**SCHEMA_DIFF*/[
				{
					"name": "ClassificationAcademyUrl",
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
						"caption": "$Resources.Strings.ClassificationAcademyCaption",
						"tag": {"contextHelpId": 1940}
					}
				},
				{
					"name": "MLConfidentValueMethod",
					"parentName": "AdvancedModelParametersGroup",
					"operation": "insert",
					"propertyName": "items"
				},
				{
					"name": "ConfidentValueLowEdge",
					"parentName": "AdvancedModelParametersGroup",
					"operation": "insert",
					"propertyName": "items",
					"values": {
						"visible": {
							"bindTo": "MLConfidentValueMethod",
							"bindConfig": {"converter": "getIsConfidentValueLowEdgeVisible"}
						}
					}
				}
			]/**SCHEMA_DIFF*/,
			userCode: {}
		};
	});
