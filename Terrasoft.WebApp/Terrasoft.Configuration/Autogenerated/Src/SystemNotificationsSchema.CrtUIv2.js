define("SystemNotificationsSchema", [], function() {
	return {
		methods: {
			/**
			 * Returns true if license generation notification.
			 * @private
			 * @returns {Boolean} True if license generation notification.
			 */
			_isLicenseNotification: function() {
				return this.get("LoaderName") === "ExpireLicenseNotificationProcess";
			},

			/**
			 * Returns true if it is notification abot app update available.
			 * @private
			 * @returns {Boolean} True if it is notification about app update available.
			 */
			_isAppUpdateAvailableNotification: function() {
				return this.get("LoaderName") === "PushNotificationAboutAppUpdateAvailableProcess";
			},

			/**
			 * Returns notification subject redirect url.
			 * @private
			 * @returns {String} Url to update app if it is single item to update otherwise app hub url.
			 */
			_getNotificationSubjectRedirectUrl: function() {
				if (this._isLicenseNotification()) {
					return Terrasoft.combinePath(Terrasoft.workspaceBaseUrl, "ClientApp/#/LicenseManager");
				}
				if (!this._isAppUpdateAvailableNotification()) {
					return undefined;
				}
				const config = this.getNotificationConfig();
				const appHubUrl = Terrasoft.combinePath(Terrasoft.workspaceBaseUrl, "ClientApp/#/ApplicationManagement");
				return config.isSingleUpdateAvailable
					? Terrasoft.combinePath(appHubUrl, "InstallFromMarketplace", config.marketplaceAppId)
					: appHubUrl;
			},

			/**
			 * @inheritdoc Terrasoft.BaseNotificationsSchema#onNotificationSubjectClick
			 * @overridden
			 */
			onNotificationSubjectClick: function() {
				const redirectUrl = this._getNotificationSubjectRedirectUrl();
				if (redirectUrl) {
					window.open(redirectUrl, "_blank");
					return;
				}
				this.callParent(arguments);
			},

			/**
			 * @inheritdoc Terrasoft.BaseNotificationsSchema#getNotificationImage
			 * @overridden
			 */
			getNotificationImage: function() {
				if (this._isAppUpdateAvailableNotification()) {
					imageResource = this.get("Resources.Images.UpdateIsAvailableIcon");
					return this.Terrasoft.ImageUrlBuilder.getUrl(imageResource);
				}
				return this.callParent(arguments);
			},

			/**
			 * @inheritdoc Terrasoft.BaseNotificationsSchema#getNotificationLinkAttributes
			 * @overridden
			 */
			getNotificationLinkAttributes: function() {
				if (!this._isLicenseNotification()) {
					return this.callParent(arguments);
				}
				return { activelink: true };
			},
		},
		diff: []
	};
});
