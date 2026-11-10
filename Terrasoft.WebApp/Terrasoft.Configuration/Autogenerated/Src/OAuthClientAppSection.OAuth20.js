define("OAuthClientAppSection", [],
	function() {
		// ENG-78572: id of the OAuthClientAppStatus "Not installed" record. Not installed integrations are
		// hidden from the section unless the install lifecycle feature (OAuthClientAppInstallStatus, F1) is on.
		var notInstalledStatusId = "273670c2-d2ef-4c6a-b0f4-44b43e08bab7";
		return {
			entitySchemaName: "OAuthClientApp",
			attributes: {
				"SecurityOperationName": {
					dataValueType: Terrasoft.DataValueType.TEXT,
					value: "CanManageOAuth"
				}
			},
			methods: {
				getDefaultDataViews: function() {
					var dataViews = this.callParent(arguments);
					delete dataViews.AnalyticsDataView;
					return dataViews;
				},

				getModuleCaption: function() {
					return this.get("Resources.Strings.SectionCaption");
				},

				/**
				 * Whether the install lifecycle feature (F1) is enabled on the client (ENG-78572).
				 * Falls back to false (hide Not installed) when the feature toggle client is unavailable.
				 * @protected
				 */
				isInstallStatusFeatureEnabled: function() {
					var features = this.Terrasoft && this.Terrasoft.Features;
					return !!(features && features.getIsEnabled &&
						features.getIsEnabled("OAuthClientAppInstallStatus"));
				},

				/**
				 * @inheritdoc Terrasoft.BaseGridDataViewV2#getFilters
				 * @overridden
				 * Hides Not installed integrations from the section while the install lifecycle feature (F1)
				 * is off, so the legacy experience never surfaces records it cannot manage (ENG-78572).
				 */
				getFilters: function() {
					var filters = this.callParent(arguments);
					if (!this.isInstallStatusFeatureEnabled() && filters) {
						filters.addItem(this.Terrasoft.createColumnFilterWithParameter(
							this.Terrasoft.ComparisonType.NOT_EQUAL, "Status", notInstalledStatusId));
					}
					return filters;
				},

				initEditPages: function() {
					this.callParent(arguments);
					var editPages = this.get("EditPages");
					var typeUId = this.Terrasoft.GUID_EMPTY;
					if (this.Ext.isEmpty(editPages.find(typeUId))) {
						editPages.add(typeUId, this.Ext.create("Terrasoft.BaseViewModel", {
							values: {
								Id: typeUId,
								Caption: this.get("Resources.Strings.EditPageCaption"),
								Click: {bindTo: "addRecord"},
								Tag: typeUId,
								SchemaName: "OAuthClientAppPage"
							}
						}));
					}
				},

				addDefaultResource: function() {
					this.callService({
						serviceName: "OAuthConfigService",
						methodName: "AddDefaultResource",
					}, function(response) {
						if (!response.AddDefaultResourceResult.success) {
							Terrasoft.showMessage(response.AddDefaultResourceResult.errorInfo.message);
						} else {
							var message = this.get("Resources.Strings.DefaultResourceSuccessMessage");
							Terrasoft.showMessage(message);
						}
					}, this);
				},

				/**
				 * @inheritdoc Terrasoft.BaseSectionV2#getSectionActions
				 * @overridden
				 */
				getSectionActions: function() {
					var actions = this.callParent(arguments);
					actions.clear();
					actions.addItem(this.createAddDefaultResourceButton());
					actions.addItem(this.createInstallButton());
					return actions;
				},

				/**
				 * Creates add default resource button.
				 * @protected
				 */
				createAddDefaultResourceButton: function() {
					return this.getButtonMenuItem({
						"Caption": {"bindTo": "Resources.Strings.AddDefaultResourceButtonCaption"},
						"Click": {"bindTo": "addDefaultResource"},
						"Visible": true,
						"Enabled": true,
						"IsEnabledForSelectedAll": true
					});
				},

				/**
				 * Creates the "Install" action that promotes the selected Not installed integration (ENG-78572).
				 * @protected
				 */
				createInstallButton: function() {
					return this.getButtonMenuItem({
						"Caption": {"bindTo": "Resources.Strings.InstallButtonCaption"},
						"Click": {"bindTo": "installSelectedClientApp"},
						// Only offered while the install lifecycle feature (F1) is on (ENG-78572).
						"Visible": this.isInstallStatusFeatureEnabled(),
						"Enabled": {"bindTo": "ActiveRow"},
						"IsEnabledForSelectedAll": false
					});
				},

				/**
				 * Installs the selected OAuthClientApp via OAuthClientAppInstallService. The service flips
				 * Status to Installed and saves; the listener validates, registers in the Identity Service and
				 * activates. Backend rejects invalid transitions, so the action is safe on any selection.
				 * @protected
				 */
				installSelectedClientApp: function() {
					var recordId = this.get("ActiveRow");
					if (!recordId) {
						return;
					}
					this.showBodyMask();
					this.callService({
						serviceName: "OAuthClientAppInstallService",
						methodName: "Install",
						data: {recordId: recordId}
					}, function(response) {
						this.hideBodyMask();
						var result = response && response.InstallResult;
						if (result && result.success) {
							this.showInformationDialog(this.Ext.String.format(
								this.get("Resources.Strings.InstallSuccessMessage"), result.clientId));
							this.reloadGridColumnsAndData();
						} else {
							this.showInformationDialog((result && result.errorMessage) ||
								this.get("Resources.Strings.InstallFailedMessage"));
						}
					}, this);
				}
			},
			diff: /**SCHEMA_DIFF*/[
			{
				"operation": "merge",
				"name": "DataGridActiveRowCopyAction",
				"values": {
					"visible": false
				}
			}
			]/**SCHEMA_DIFF*/
		};
	});