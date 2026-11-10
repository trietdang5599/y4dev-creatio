define("SystemDesigner", [], function() {
	return {
		methods: {
			openOAuthSection: function() {
				this.sandbox.publish("PushHistoryState", {
					hash: "Page/OAuthAuthorization_ListPage"
				}); 
			},
			/**
			 * @return {Boolean} True if OAuth integration enabled.
			 * @private
			 */
			getIsOAuthIntegrationEnabled: function() {
				return this.getIsFeatureEnabled("OAuth20Integration");
			}
		},
		diff: [
			{
				"operation": "insert",
				"index": 1,
				"propertyName": "items",
				"parentName": "IntegrationTile",
				"name": "OAuthSection",
				"values": {
					"itemType": this.Terrasoft.ViewItemType.LINK,
					"caption": {"bindTo": "Resources.Strings.OAuthSectionCaption"},
					"tag": "openOAuthSection",
					"click": {"bindTo": "invokeOperation"},
					"visible": {"bindTo": "getIsOAuthIntegrationEnabled"}
				}
			}
		]
	};
});
