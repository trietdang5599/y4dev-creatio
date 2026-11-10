 define("SyncSettings", [], function() {
	return {
		entitySchemaName: "MailboxSyncSettings",

		methods: {
			/**
			 * @inheritdoc SyncSettings#initTabs
			 * @overridden
			 */
			initTabs: function() {
				if(!this.isCalendarSyncLicensed) {
					var tabsCollection = this.get("TabsCollection");
					tabsCollection.removeByKey("GoogleActivitySettingsTab");
				}
				this.callParent(arguments);
			}

		},
		diff: [
			{
				"operation": "insert",
				"parentName": "TabsPanel",
				"name": "GoogleActivitySettingsTab",
				"propertyName": "tabs",
				"values": {
					"caption": {"bindTo": "Resources.Strings.ActivitySettingsTabCaption"},
					"items": []
				}
			},
			{
				"operation": "insert",
				"parentName": "GoogleActivitySettingsTab",
				"name": "GoogleActivitySettingsModule",
				"propertyName": "items",
				"values": {
					"moduleId": "SyncSettings_GoogleActivitySyncSettingsSchemaModule",
					"itemType": Terrasoft.ViewItemType.MODULE,
					"moduleName": "SyncSettingsTabModule",
					"instanceConfig": {
						"isSchemaConfigInitialized": true,
						"schemaName": "GoogleActivitySyncSettingsTab",
						"defaultValues": [{
							"name": "TabName",
							"value": "GoogleActivitySyncSettingsTab"
						}],
						"useHistoryState": false
					},
					"afterrerender": {"bindTo": "afterrerender"}
				}
			}
		]
	};
});
