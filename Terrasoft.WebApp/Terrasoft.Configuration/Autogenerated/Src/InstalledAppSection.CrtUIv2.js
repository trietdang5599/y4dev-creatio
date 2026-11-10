define("InstalledAppSection", ["InstalledAppSectionResources"],
	function(resources) {
		return {
			entitySchemaName: "SysInstalledApp",
			attributes: {
				"SecurityOperationName": {
					dataValueType: Terrasoft.DataValueType.TEXT,
					value: "CanManageAdministration"
				}
			},
			methods: {

				_getCanReloadListAfterInstallApp: function() {
					return this.Terrasoft.Features.getIsEnabled("ReloadListAfterInstallApp");
				},

				_subscribeInstallApplication: function() {
					if (!this._getCanReloadListAfterInstallApp()) {
						return;
					}
					const scope = this;
					const channel = new BroadcastChannel2('reload-list-after-install-app');
					channel.onmessage = function() {
						scope.reloadGridData();
					};
				},

				onBuy: function() {
					var esq = this.Ext.create("Terrasoft.EntitySchemaQuery", { rootSchemaName: "SysInstalledApp" });
					var nameColumn = esq.addColumn("OrderLink");
					nameColumn.orderPosition = 1;
					nameColumn.orderDirection = this.Terrasoft.OrderDirection.ASC;
					var idColumnFilter = "Id";
					esq.filters.addItem(this.Terrasoft.createColumnFilterWithParameter(
						this.Terrasoft.ComparisonType.EQUAL, idColumnFilter, this.get("ActiveRow")));
					esq.getEntityCollection(function(result) {
						var links = result.success
							? result.collection
							: this.Ext.create("Terrasoft.BaseViewModelCollection");
						links.each(function(application) {
							var orderLink = application.get("OrderLink");
							window.open(orderLink);
							return;
						}, this);
					});

				},

				onLicenses: function() {
					var url = this.getIsFeatureEnabled("NewLicenseManagerUI")
						? Terrasoft.workspaceBaseUrl + "/ClientApp/#/LicenseManager"
						: Terrasoft.loaderBaseUrl + "Lic/LicManager.aspx";
					window.open(url, "_blank");
				},

				onOpen: function() {
					const applicationId = this.get("ActiveRow");
					const routePath = "/EditApp/" + applicationId;
					this.openClientApp(routePath);
				},

				onDeleteAccept: function() {
					this.showBodyMask();
					var options = {
						url: "../ServiceModel/AppInstallerService.svc/UninstallApp",
						headers: {
							"Content-Type": "application/json",
							"Accept": "application/json"
						},
						scope: this,
						callback: this.onDeleteCallback,
						jsonData: "\"" + this.get("ActiveRow") + "\"",
						timeout: 1 * 60 * 60 * 1000
					};
					Terrasoft.AjaxProvider.request(options);
				},

				onDeleteCallback: function(options, success, response) {
					this.hideBodyMask();
					var successInfo = JSON.parse(response.responseText).success;
					if (successInfo) {
						this.reloadGridData();
					} else {
						var errorInfo = JSON.parse(response.responseText).errorInfo;
						this.showInformationDialog(errorInfo.message);
					}
				},

				onRedirectToMarketplace: function() {
					window.open(resources.localizableStrings.MarketplaceLink);
				},

				onRedirectToInstallFromFile: function() {
					window.open("ApplicationInstallation.aspx");
				},

				onRedirectToCreateApplication: function() {
					const templateCode = "AppWithSectionAndEditPage";
					const routePath = "/CreateApp?templateCode=" + templateCode;
					this.openClientApp(routePath);
				},

				openClientApp: function(routePath) {
					const clientAppURL = Terrasoft.workspaceBaseUrl +
						"/ClientApp/#/ApplicationManagement" + routePath;
					window.open(clientAppURL, "_blank");
				},

				getModuleCaption: function() {
					return this.get("Resources.Strings.SectionCaption");
				},

				getDefaultDataViews: function() {
					var dataViews = this.callParent(arguments);
					delete dataViews.AnalyticsDataView;
					return dataViews;
				},

				getSectionActions: function() {
					var actionMenuItems = this.callParent(arguments);
					actionMenuItems.clear();
					actionMenuItems.addItem(this.getButtonMenuItem({
						"Type": "Terrasoft.MenuSeparator"
					}));
					actionMenuItems.addItem(this.getButtonMenuItem({
						"Caption": { "bindTo": "Resources.Strings.InstallFromMarketplace" },
						"Click": { "bindTo": "onRedirectToMarketplace" }
					}));
					actionMenuItems.addItem(this.getButtonMenuItem({
						"Caption": { "bindTo": "Resources.Strings.InstallFromFile" },
						"Click": { "bindTo": "onRedirectToInstallFromFile" }
					}));
					if (Terrasoft.Features.getIsEnabled("InstallApplicationUIV2")) {
						actionMenuItems.addItem(this.getButtonMenuItem({
							"Caption": { "bindTo": "Resources.Strings.CreateNewApplication" },
							"Click": { "bindTo": "onRedirectToCreateApplication" }
						}));
					}
					actionMenuItems.addItem(this.getButtonMenuItem({
						"Type": "Terrasoft.MenuSeparator"
					}));
					return actionMenuItems;
				},

				onActiveRowAction: function(buttonTag) {
					if (buttonTag === "buy") {
						this.onBuy();
					} else if (buttonTag === "licenses") {
						this.onLicenses();
					} else if (buttonTag === "open") {
						this.onOpen();
					}
					else {
						this.callParent(arguments);
					}
				},

				isShowBuy: function(activeRow) {
					var orderLink = "";
					var esq = this.Ext.create("Terrasoft.EntitySchemaQuery", { rootSchemaName: "SysInstalledApp" });
					var nameColumn = esq.addColumn("OrderLink");
					nameColumn.orderPosition = 1;
					nameColumn.orderDirection = this.Terrasoft.OrderDirection.ASC;
					var idColumnFilter = "Id";
					esq.filters.addItem(this.Terrasoft.createColumnFilterWithParameter(
						this.Terrasoft.ComparisonType.EQUAL, idColumnFilter, this.get("ActiveRow")));
					esq.getEntityCollection(function(result) {
						var links = result.success
							? result.collection
							: this.Ext.create("Terrasoft.BaseViewModelCollection");
						links.each(function(application) {
							orderLink = application.get("OrderLink");
						}, this);
						if (orderLink === "") {
							activeRow.set("isShowBuyButton", false);
						} else {
							activeRow.set("isShowBuyButton", true);
						}
					});
				},

				isShowOpen: function(activeRow) {
					if (Terrasoft.Features.getIsEnabled("InstallApplicationUIV2")) {
						activeRow.set("isShowOpenButton", true);
					} else {
						activeRow.set("isShowOpenButton", false);
					}
				},

				onActiveRowChange: function() {
					var activeRow = this.getActiveRow();
					if (activeRow) {
						this.isShowBuy(activeRow);
						this.isShowOpen(activeRow);
					}
				},

				/**
				 * @inheritdoc BaseSectionV2#subscribeSandboxEvents
				 * @overridden
				 */
				subscribeSandboxEvents: function() {
					this.callParent(arguments);
					this._subscribeInstallApplication();
				},
			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "insert",
					"name": "DataGridActiveRowLicenseAction",
					"parentName": "DataGrid",
					"propertyName": "activeRowActions",
					"index": 1,
					"values": {
						"className": "Terrasoft.Button",
						"style": Terrasoft.controls.ButtonEnums.style.BLUE,
						"caption": resources.localizableStrings.LicensesCaption,
						"tag": "licenses",
						"visible": true
					}
				},
				{
					"operation": "insert",
					"name": "DataGridActiveRowBuyAction",
					"parentName": "DataGrid",
					"propertyName": "activeRowActions",
					"index": 2,
					"values": {
						"className": "Terrasoft.Button",
						"style": Terrasoft.controls.ButtonEnums.style.GREY,
						"caption": resources.localizableStrings.BuyCaption,
						"tag": "buy",
						"visible": { "bindTo": "isShowBuyButton" }
					}
				},
				{
					"operation": "insert",
					"name": "DataGridActiveRowOpenAppAction",
					"parentName": "DataGrid",
					"propertyName": "activeRowActions",
					"index": 3,
					"values": {
						"className": "Terrasoft.Button",
						"style": Terrasoft.controls.ButtonEnums.style.GREY,
						"caption": resources.localizableStrings.OpenCaption,
						"tag": "open",
						"visible": { "bindTo": "isShowOpenButton" }
					}
				},
				{
					"operation": "merge",
					"name": "DataGridActiveRowDeleteAction",
					"index": 4,
					"values": {
						"style": Terrasoft.controls.ButtonEnums.style.GREY
					}
				},
				{
					"operation": "merge",
					"name": "SeparateModeActionsButton",
					"values": {
						"style": Terrasoft.controls.ButtonEnums.style.GREEN
					}
				},
				{
					"operation": "merge",
					"name": "DataGridActiveRowOpenAction",
					"values": {
						"visible": false
					}
				},
				{
					"operation": "merge",
					"name": "DataGridActiveRowCopyAction",
					"values": {
						"visible": false
					}
				},
				{
					"operation": "merge",
					"name": "SeparateModeAddRecordButton",
					"values": {
						"visible": false
					}
				},

				{
					"operation": "merge",
					"name": "SeparateModeViewOptionsButton",
					"values": {
						"visible": true// false
					}
				}

			]/**SCHEMA_DIFF*/
		};
	});