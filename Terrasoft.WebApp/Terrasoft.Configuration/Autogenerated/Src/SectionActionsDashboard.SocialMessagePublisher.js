define("SectionActionsDashboard", ["SectionActionsDashboardResources", "SocialMessagePublisherModule"],
	function(resources) {
		return {
			attributes: {},
			messages: {},
			methods: {

				/**
				 * Returns ESN channel button visibility.
				 * @protected
				 * @return {Boolean} ESN channel button visibility.
				 */
				getEsnChannelVisible: function() {
					return this.getExtraActionDashboadTabVisible();
				},

				/**
				 * @inheritdoc Terrasoft.ActionsDashboard#getExtendedConfig
				 * @override
				 */
				getExtendedConfig: function() {
					var config = this.callParent(arguments);
					var lczImages = resources.localizableImages;
					config.SocialMessageTab = {
						"ImageSrc": this.Terrasoft.ImageUrlBuilder.getUrl(lczImages.SocialMessageTabImage),
						"MarkerValue": "social-message-tab",
						"Align": this.Terrasoft.Align.RIGHT,
						"Visible": this.getEsnChannelVisible(),
						"Tag": "Social"
					};
					return config;
				},

				/**
				 * @inheritdoc Terrasoft.BaseActionsDashboard#getAllowedTabs7x
				 * @override
				 */
				getAllowedTabs7x: function() {
					var result = this.callParent(arguments);
					result.push("SocialMessageTab");
					return result;
				},

				/**
				 * @inheritdoc Terrasoft.MessagePublisher.SectionActionsDashboard#getSectionPublishers
				 * @override
				 */
				getSectionPublishers: function() {
					var publishers = this.callParent(arguments);
					publishers.push("Social");
					return publishers;
				}
			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "insert",
					"name": "SocialMessageTab",
					"parentName": "Tabs",
					"propertyName": "tabs",
					"values": {
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "SocialMessageTabContainer",
					"parentName": "SocialMessageTab",
					"propertyName": "items",
					"values": {
						"itemType": this.Terrasoft.ViewItemType.CONTAINER,
						"classes": {
							"wrapClassName": ["social-message-content"]
						},
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "SocialMessageModule",
					"parentName": "SocialMessageTab",
					"propertyName": "items",
					"values": {
						"classes": {
							"wrapClassName": ["social-message-module", "message-module"]
						},
						"itemType": this.Terrasoft.ViewItemType.MODULE,
						"moduleName": "SocialMessagePublisherModule",
						"afterrender": {
							"bindTo": "onMessageModuleRendered"
						},
						"afterrerender": {
							"bindTo": "onMessageModuleRendered"
						}
					}
				}
			]/**SCHEMA_DIFF*/
		};
	}
);
