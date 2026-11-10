define("MainHeaderSchema", ["PortalClientConstants"], function(PortalConstants) {
	return {
		attributes: {
			/**
			 * Binding attribute for "Company profile" menu item visibility.
			 */
			"canGoToSspAccountPage": {
				"dataValueType": this.Terrasoft.DataValueType.BOOLEAN,
				"value": false
			},

			"OrganizationId": {
				"dataValueType": this.Terrasoft.DataValueType.GUID,
				"type": this.Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN
			}
		},

		methods: {
			/**
			 * @inheritDoc Terrasoft.BaseViewModel#init
			 * @override
			 */
			init: function() {
				this.initAttributes();
				this.callParent(arguments);
			},

			/**
			 * Initialize schema attributes.
			 */
			initAttributes: function() {
				if (this.getIsFeatureEnabled("PortalUserManagementV2")) {
					this.initCanGoToSspAccountPage();
				}
			},

			/**
			 * Set up canGoToSspAccountPage attribute.
			 */
			initCanGoToSspAccountPage: function() {
				if (!Terrasoft.isCurrentUserSsp() || !Terrasoft.SysValue.CURRENT_USER_ACCOUNT.value) {
					this.set("canGoToSspAccountPage", false);
					return;
				}
				const serviceConfig = {serviceName: "SspUserManagementService", methodName: "GetSspAccountInfo"};
				this.callService(serviceConfig, this.switchCanGoToSspAccountPage, this);
			},

			/**
			 * @inheritdoc Terrasoft.MainHeaderSchema#loadProfileButtonMenu
			 * @override
			 */
			loadProfileButtonMenu: function() {
				this.callParent(arguments);
				if (Terrasoft.isCurrentUserSsp() && this.getIsFeatureEnabled("SSPUserContactPage")) {
					this.addExtendedUserProfileButtonMenu();
					this.changeProfileIcon();
				}
				if (this.getIsFeatureEnabled("PortalUserManagementV2") && Terrasoft.isCurrentUserSsp()) {
					this.addSspAccountButtonsToProfileButtonMenu();
				}
				if (Terrasoft.isCurrentUserSsp()) {
					this.changeExitIcon();
				}
			},

			/**
			 * Change User profile button icon to portal user profile icon.
			 * @protected
			 */
			changeProfileIcon: function() {
				const profileMenuCollection = this.get("ProfileMenuCollection");
				const userProfile = profileMenuCollection.findByFn(function(item) {
					return item.$Id === "profile-menu-item";
				});
				if (userProfile) {
					profileMenuCollection.remove(userProfile);
					profileMenuCollection.addItem(this.Ext.create("Terrasoft.BaseViewModel", {
						values: {
							Id: "profile-menu-item",
							Caption: this.get("Resources.Strings.SspProfileCaption"),
							Click: {
								bindTo: "onProfileMenuItemClick"
							},
							ImageConfig: this.get("Resources.Images.SspProfileIcon"),
							MarkerValue: this.get("Resources.Strings.SspProfileCaption")
						}
					}), 0);
				}
			},

			/**
			 * Change Exit button icon to portal exit icon.
			 * @protected
			 */
			changeExitIcon: function() {
				const profileMenuCollection = this.get("ProfileMenuCollection");
				const exit = profileMenuCollection.findByFn(function(item) {
					return item.$Id === "exit-menu-item";
				});
				if (exit) {
					profileMenuCollection.remove(exit);
					profileMenuCollection.addItem(this.Ext.create("Terrasoft.BaseViewModel", {
						values: {
							Id: "exit-menu-item",
							Caption: this.get("Resources.Strings.ExitMenuItemCaption"),
							Click: {
								bindTo: "onExitMenuItemClick"
							},
							ImageConfig: this.get("Resources.Images.SspExitButton"),
							MarkerValue: this.get("Resources.Strings.ExitMenuItemCaption")
						}
					}));
				}
			},

			/**
			 * Add menu item for open SSP account page to profile menu button.
			 * @protected
			 */
			addSspAccountButtonsToProfileButtonMenu: function() {
				const profileMenuCollection = this.get("ProfileMenuCollection");
				profileMenuCollection.addItem(this.Ext.create("Terrasoft.BaseViewModel", {
					values: {
						Id: "company-profile-menu-item",
						Caption: this.get("Resources.Strings.CompanyProfileCaption"),
						Click: {
							bindTo: "onGoToSspAccountPageMenuItemClick"
						},
						ImageConfig: this.get("Resources.Images.CompanyProfileIcon"),
						Visible: {
							bindTo: "canGoToSspAccountPage"
						},
						MarkerValue: this.get("Resources.Strings.CompanyProfileCaption")
					}
				}), 1);
			},

			/**
			 * Forward user to SSP account profile.
			 * @protected
			 */
			onGoToSspAccountPageMenuItemClick: function() {
				const path = this.Terrasoft.combinePath("CardModuleV2",
					PortalConstants.DesignerPagesName.OrganizationPageSchema,
					"edit", this.get("OrganizationId"));
				const historyStateConfig = {hash: path};
				this.sandbox.publish("PushHistoryState", historyStateConfig);
			},

			/**
			 * Switch visibility of "Company profile" menu item based on service response.
			 * @protected
			 * @param {Object} response SspUserManagementService/GetSspAccountInfo service response.
			 */
			switchCanGoToSspAccountPage: function(response) {
				const result = response && response.GetSspAccountInfoResult;
				if (result && result.success && result.SspAccountId && !Terrasoft.isEmptyGUID(result.SspAccountId)) {
					this.set("canGoToSspAccountPage", true);
					this.set("OrganizationId", result.SspAccountId);
				}
			},

			/**
			 * Add menu item for open SSP account page to profile menu button.
			 * @protected
			 */
			addExtendedUserProfileButtonMenu: function() {
				const profileMenuCollection = this.get("ProfileMenuCollection");
				const pmi = profileMenuCollection.filter(function(item) {
					return item.$Id === "profile-menu-item";
				});
				if (pmi && pmi.getCount() > 0) {
					profileMenuCollection.addItem(this.Ext.create("Terrasoft.BaseViewModel", {
						values: {
							Id: "extended-user-profile-menu-item",
							Caption: this.get("Resources.Strings.ExtendedUserProfileCaption"),
							ImageConfig: this.get("Resources.Images.UserSettingsIcon"),
							Click: {
								bindTo: "openSettingsProfile"
							}
						}
					}), 1);
				}
			},

			/**
			 * Forward user to SSP account profile.
			 * @protected
			 */
			openSettingsProfile: function() {
				this.onProfileMenuItemClick(true);
			},

			/**
			 * Open page which is related with user contact.
			 * @protected
			 */
			openUserProfilePage: function() {
				const path = this.Terrasoft.combinePath("CardModuleV2",
					PortalConstants.DesignerPagesName.ProfileContactPageSchema, "edit",
					Terrasoft.SysValue.CURRENT_USER_CONTACT.value);
				const historyStateConfig = {hash: path};
				this.sandbox.publish("PushHistoryState", historyStateConfig);
			},

			/**
			 * @inheritdoc Terrasoft.MainHeaderSchema#onProfileMenuItemClick.
			 * @override
			 */
			onProfileMenuItemClick: function(callParent) {
				if (this.getIsFeatureEnabled("SSPUserContactPage") && this.Terrasoft.isCurrentUserSsp() &&
					!callParent) {
					this.openUserProfilePage();
				} else {
					this.callParent(arguments);
				}
			}
		}
	};
});
