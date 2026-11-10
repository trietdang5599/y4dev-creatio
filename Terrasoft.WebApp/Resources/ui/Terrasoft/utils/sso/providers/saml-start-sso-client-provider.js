Ext.ns("Terrasoft.utils.sso");

Ext.define("Terrasoft.utils.sso.providers.SamlStartSsoClientProvider", {
    alternateClassName: "Terrasoft.SamlStartSsoClientProvider",
    singleton: true,

    startSso: function (provider) {
        Terrasoft.SsoUtils.startSsoLogin(provider);
    }
});