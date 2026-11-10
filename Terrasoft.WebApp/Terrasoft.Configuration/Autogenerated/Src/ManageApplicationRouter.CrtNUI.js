define("ManageApplicationRouter", ["ServiceHelper", "NavigationHelper"], function(ServiceHelper) {
	Ext.define("Terrasoft.configuration.mixins.ManageApplicationRouter", {
		alternateClassName: "Terrasoft.ManageApplicationRouter",

		almPortalUrl: '',
		useNewApplicationManagement: false,

		//@private
		_getUrlFromSysSetting: function(callback, scope) {
			Terrasoft.SysSettings.querySysSettings(["AlmPortalEnvironmentManagementUrl"],
				(sysSettings) => {
					Ext.callback(callback, scope, [{ url: sysSettings?.AlmPortalEnvironmentManagementUrl }]);
				}, this);
		},
		
		//@private
		_getUrlFromService: function(callback, scope) {
			var serviceConfig = {
				serviceName: "ApplicationHubService",
				methodName: "GetExternalInfo",
				scope: scope
			};
			serviceConfig.callback = function(response) {
				Ext.callback(callback, scope || this, [response]);
			};
			ServiceHelper.callService(serviceConfig);
		},
		
		//@private
		_getExternalHubUrl: function(callback, scope) {
			if (Terrasoft.Features.getIsEnabled("UseAlmUrlSysSettingOnlyForExternalHubUrl")) {
				this._getUrlFromSysSetting(callback, scope);
				return;
			}
			this._getUrlFromService(callback, scope);
		},

		init: function(callback, scope) {
			if (Terrasoft.CurrentUser.userType === Terrasoft.UserType.SSP) {
				this.Ext.callback(callback, scope || this);
				return;
			}
			Terrasoft.chain(
				function(next) {
					Terrasoft.SysSettings.querySysSettings(["UseNewApplicationManagement"],
						(sysSettings) => {
							this.useNewApplicationManagement = sysSettings?.UseNewApplicationManagement;
							next();
						}, this);
				},
				function(next) {
					this._getExternalHubUrl((response) => {
						this.almPortalUrl = response?.url;
						Ext.callback(callback, scope);
					}, this);
				},
				this
			);
		},

		openUrl: function (url) {
			const navigationHelper = this.Ext.create("Terrasoft.NavigationHelper", {
				Ext: this.Ext,
				sandbox: this.sandbox
			});
			const navigationConfig = {
				target: 'Url',
				options: {
					'url': url,
					'newTab': true,
					'newTabId': 'ApplicationManagement',
				}
			};
			navigationHelper.navigateTo(navigationConfig);
		},

		openApplicationManagement: function() {
			let url = '';
			if (!Ext.isEmpty(this.almPortalUrl)) {
				const siteName = window.location.hostname.split('.')[0];
				const delimiter = this.almPortalUrl.endsWith('/') ? '' : '/';
				url = this.Ext.String.format("{0}{1}{2}", this.almPortalUrl, delimiter, siteName);
			} else {
				url = Terrasoft.workspaceBaseUrl + "/ClientApp/#/ApplicationManagement";
			}
			this.openUrl(url);
		},

		openInstaledApplications: function() {
			if (this.useNewApplicationManagement) {
				this.openApplicationManagement();
			} else {
				this.openSection("InstalledAppSection");
			}
		}
	});
	return Ext.create("Terrasoft.ManageApplicationRouter");
});
