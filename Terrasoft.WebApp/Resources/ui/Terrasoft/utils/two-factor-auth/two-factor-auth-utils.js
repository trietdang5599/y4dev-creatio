Ext.ns("Terrasoft.utils.twoFactorAuth");

Ext.define("Terrasoft.utils.twoFactorAuth.TwoFactorAuthUtils", {
    alternateClassName: "Terrasoft.TwoFactorAuthUtils",
    singleton: true,
    
    _sendTextCodeEndpointUrl: '/ServiceModel/AuthService.svc/StartTextCodeAuthFlow',
    _isTextCodeDefaultProviderUrl: "/ServiceModel/AuthService.svc/GetAuthenticationSettings",
    
    sendTextCode: function(login, password, callback, scope) {
        const requestUrl = Terrasoft.workspaceBaseUrl + this._sendTextCodeEndpointUrl;
        let authToken = {
            UserName: login,
            UserPassword: password
        };
        const options = {
            url: requestUrl,
            headers: {
                "Content-Type": "application/json",
                "Accept": "application/json"
            },
            scope: scope,
            callback: callback,
            jsonData: JSON.stringify(authToken),
            timeout: 120000,
            securitySensitiveFields: ["UserPassword"]
        };
        Terrasoft.AjaxProvider.request(options);
    },

    getAuthenticationSettings: function(callback, scope) {
        if (!Terrasoft.enabled2FAFlow) {
            callback.call(scope, {});
            return;
        }
        const requestUrl = Terrasoft.workspaceBaseUrl + this._isTextCodeDefaultProviderUrl;
        const options = {
            url: requestUrl,
            scope: scope,
            callback: function(request, success, response) {
                if (!success) {
                    return;
                }
                const isDefaultProvider = JSON.parse(response.responseText);
                callback.call(scope, isDefaultProvider)
            },
            method: 'POST'
        };
        Terrasoft.AjaxProvider.request(options);
    }
})