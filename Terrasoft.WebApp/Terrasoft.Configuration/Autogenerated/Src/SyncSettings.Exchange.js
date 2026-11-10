define("SyncSettings", ["ExchangeNUIConstants", "SyncSettingsResources"], function(ExchangeNUIConstants) {
	return {
		entitySchemaName: "MailboxSyncSettings",
		methods: {

			/**
			 * Checks if Exchange-family activity synchronization is available for current mailbox.
			 * @private
			 * @return {Boolean} True when activity sync is available for Exchange or Graph mailboxes.
			 */
			_canUseExchangeActivitySync: function() {
				var serverType = this.get("ServerTypeId");
				return serverType === ExchangeNUIConstants.MailServer.Type.Exchange
					|| serverType === ExchangeNUIConstants.MailServer.Type.Graph;
			},

			/**
			 * Checks if new calendar settings UI should be used.
			 * @private
			 * @return {Boolean} True if NewCalendarSettingsUi feature is enabled.
			 */
			_useNewCalendarSettingsUi: function() {
				return Terrasoft.Features.getIsEnabled("NewCalendarSettingsUi");
			},

			/**
			 * @inheritdoc SyncSettings#initTabs
			 * @overridden
			 */
			initTabs: function() {
				if(!this.isCalendarSyncLicensed) {
					const tabsCollection = this.get("TabsCollection");
					tabsCollection.removeByKey("ActivitySettingsTab");
				}
				if(this.getIsFeatureDisabled("ContactsSyncEnabled")) {
					const tabsCollection = this.get("TabsCollection");
					tabsCollection.removeByKey("ContactSettingsTab");
				}
				this.callParent(arguments);
			},

			/**
			 * @inheritdoc SyncSettings#setActiveTab
			 * @overridden
			 */
			setActiveTab: function(activeTabName) {
				if ((this.getIsFeatureDisabled("ContactsSyncEnabled") && this.get("ActiveTabName") === "ContactSettingsTab")
						|| (!this._canUseExchangeActivitySync() && this.get("ActiveTabName") === "ActivitySettingsTab")) {
					this.set("ActiveTabName", "EmailSettingsTab");
					this.set("EmailSettingsTab", true);
				} else {
					this.callParent(arguments);
				}
			},

			/**
			 * @inheritdoc SyncSettings#onActiveTabChange
			 * @overridden
			 */
			onActiveTabChange: function(activeTab) {
				const activeTabName = activeTab.get("Name");
				if (activeTabName === "ActivitySettingsTab" && this._useNewCalendarSettingsUi()) {
					Terrasoft.defer(function() {
						this.setActiveTab("EmailSettingsTab");
					}, this);
					this.openActivitySyncSettingsMiniPage(this.get("RecordId"));
					return;
				}
				this.callParent(arguments);
			}

		},

		diff: [
			{
				"operation": "insert",
				"parentName": "TabsPanel",
				"name": "ActivitySettingsTab",
				"propertyName": "tabs",
				"values": {
					"caption": {"bindTo": "Resources.Strings.ActivitySettingsTabCaption"},
					"items": []
				}
			},
			{
				"operation": "insert",
				"parentName": "ActivitySettingsTab",
				"name": "ActivitySettingsModule",
				"propertyName": "items",
				"values": {
					"moduleId": "SyncSettings_ActivitySyncSettingsSchemaModule",
					"itemType": Terrasoft.ViewItemType.MODULE,
					"moduleName": "SyncSettingsTabModule",
					"instanceConfig": {
						"isSchemaConfigInitialized": true,
						"schemaName": "ActivitySyncSettingsTab",
						"defaultValues": [{
							"name": "TabName",
							"value": "ActivitySyncSettingsTab"
						}],
						"useHistoryState": false
					},
					"afterrerender": {"bindTo": "afterrerender"}
				}
			},
			{
				"operation": "insert",
				"parentName": "TabsPanel",
				"name": "ContactSettingsTab",
				"propertyName": "tabs",
				"values": {
					"caption": {"bindTo": "Resources.Strings.ContactSettingsTabCaption"},
					"items": []
				}
			},
			{
				"operation": "insert",
				"parentName": "ContactSettingsTab",
				"name": "ContactSettingsModule",
				"propertyName": "items",
				"values": {
					"moduleId": "SyncSettings_ContactSyncSettingsSchemaModule",
					"itemType": Terrasoft.ViewItemType.MODULE,
					"moduleName": "SyncSettingsTabModule",
					"instanceConfig": {
						"isSchemaConfigInitialized": true,
						"schemaName": "ContactSyncSettingsTab",
						"defaultValues": [{
							"name": "TabName",
							"value": "ContactSettingsTab"
						}],
						"useHistoryState": false
					},
					"afterrerender": {"bindTo": "afterrerender"}
				}
			}
		]
	};
});
