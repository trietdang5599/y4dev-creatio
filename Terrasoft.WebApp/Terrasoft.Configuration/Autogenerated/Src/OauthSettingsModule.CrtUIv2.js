define("OauthSettingsModule", ["BaseModule", "CredentialsSyncSettingsMixin"], function() {
	/**
	 * @class Terrasoft.configuration.OauthSettingsModule
	 * CTI panel page class to work with calls.
	 */
	Ext.define("Terrasoft.configuration.OauthSettingsModule", {
		alternateClassName: "Terrasoft.OauthSettingsModule",
		extend: "Terrasoft.BaseModule",

		mixins: {
			CredentialsSyncSettingsMixin: Terrasoft.CredentialsSyncSettingsMixin
		},

        init: function(callback, scope) {
            this.tryProcessSettingsAddAction();
            Ext.callback(callback, scope);
        }
    });
	return Terrasoft.OauthSettingsModule;
});
