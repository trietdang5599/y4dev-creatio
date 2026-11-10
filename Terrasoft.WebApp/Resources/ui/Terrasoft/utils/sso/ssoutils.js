Ext.ns("Terrasoft.utils.sso");

/**
 * Single sign on utilities class.
 * Provides methods for single sign on sessions initialization.
 * @alias Terrasoft.SsoUtils
 */
Ext.define("Terrasoft.utils.SsoUtils", {
	alternateClassName: "Terrasoft.SsoUtils",
	singleton: true,

	/**
	 * Avaliable single sign on logout reasons.
	 * @private
	 * @type {Array}
	 */
	_logoutReasons: [{
		"code": "unauthorized",
		"isError": true
	}, {
		"code": "logout"
	}, {
		"code": "samlprovidererror",
		"isError": true
	}],

	/**
	 * Use single sign on request parameter name.
	 * @private
	 * @type {String}
	 */
	_useSsoParameterName: "use_sso",

	/**
	 * Start single sign on request parameter name.
	 * @private
	 * @type {String}
	 */
	_startSsoParameterName: "start_sso",

	/**
	 * Start single sign on request parameter name.
	 * @private
	 * @type {String}
	 */
	_errorCodeParameterName: "ErrorCode",

	/**
	 * Return url hash part request parameter name.
	 * @private
	 * @type {String}
	 */
	_returnUrlHashParameterName: "ReturnUrlHash",

	/**
	 * Return url request parameter name.
	 * @private
	 * @type {String}
	 */
	 _returnUrlParameterName: "ReturnUrl",

	/**
	 * Single sign out reason cookie name.
	 * @private
	 * @type {String}
	 */
	_ssoLogoutCookieName: "SsoLogout",

	/**
	 * OpenId reason cookie name.
	 * @private
	 * @type {String}
	 */
	_openIdLogoutCookieName: "OpenIDLogout",

	/**
	 * Single sign on requested cookie name.
	 * @private
	 * @type {String}
	 */
	_ssoLoginCookieName: "SsoRequested",

	/**
	 * Starts single logout flow endpoint.
	 * @private
	 * @type {String}
	 */
	_startSsoEndpoint: "/ServiceModel/AuthService.svc/StartSsoLogin",

	/**
	 * Checks that request query has parameter.
	 * @private
	 * @param {String} paramName Search parameter name.
	 * @return {Boolean} True if request query has parameter, false otherwise.
	 */
	_hasRequestParam: function(paramName) {
		var location = this.getWindowLocation();
		return Terrasoft.includes(location.search, paramName);
	},

	/**
	 * Returns window location object.
	 * @return {Object} Window location object.
	 */
	getWindowLocation: function() {
		var document = Ext.getDoc();
		return document.dom.location;
	},

	/**
	 * Fix Url query string.
	 * @private
	 * @param {object} location
	 * @returns {string} Fixed login Url.
	 */
	_fixRedirectUrl: function(location) {
		var resultQueryString = '';
		var search = location.search && location.search.replace('?', '') || '';
		search.split('&').forEach(function(queryStringParam) {
			var queryStringParam1 = queryStringParam.split('=');
			var queryStringParamKey = queryStringParam1[0];
			if (queryStringParamKey !== this._useSsoParameterName
				&& queryStringParamKey !== this._startSsoParameterName) {
				resultQueryString += (resultQueryString ? "&" : "?") + queryStringParam;
			}
		}, this);
		return resultQueryString;
	},

	_getBaseUrl: function() {
		return Terrasoft.loaderBaseUrl.endsWith("/") ? Terrasoft.loaderBaseUrl.slice(0, -1) : Terrasoft.loaderBaseUrl;
	},

	_clearOldSsoSession: function(callback) {
		const config = {
			url: Terrasoft.workspaceBaseUrl + "/ServiceModel/AuthService.svc/ClearSsoSession",
			jsonData: "",
			headers: {
				"Content-Type": "application/json",
				"Accept": "application/json"
			},
			method: "POST",
			callback: callback,
			scope: this
		};
		Terrasoft.AjaxProvider.request(config);
	},

	/**
	 * Starts single sign on session.
	 */
	initiateSsoLogin: function() {
		this._clearOldSsoSession(() => {
			var location = this.getWindowLocation();
			if (this._hasRequestParam(this._errorCodeParameterName)) {
				location.search = this._fixRedirectUrl(location);
				return;
			}
			if (this.isSsoUnauthorized()) {
				if (location.search != "") {
					location.search = "";
				}
				Ext.util.Cookies.clear(this._ssoLogoutCookieName);
				Ext.util.Cookies.clear(this._openIdLogoutCookieName);
				return;
			}
			if (this.getNeedStartSso()) {
				var hash = location.hash.replace("#", "");
				location.search += Ext.String.format("&{0}=true&{1}={2}", this._startSsoParameterName,
					this._returnUrlHashParameterName, hash);
			}
		});
	},

	/**
	 * Checks is login page was loaded due to cookie reasons.
	 * @param {Object} [errorInfo] Error information object.
	 * @param {String} [cookieName] Logout cookie name.
	 * @return {Boolean} True if login page was loaded due to single sign out reasons, false otherwise.
	 */
	isUnauthorized: function(errorInfo, cookieName) {
		var rawCookie = Ext.util.Cookies.get(cookieName);
		if (!rawCookie) {
			return false;
		}
		const decodedRawCookie = decodeURIComponent(rawCookie).replace(/\+/g, ' ');
		var cookie = JSON.parse(decodedRawCookie);
		var reason = Ext.Array.findBy(this._logoutReasons, function(item) {
			return item.code === cookie.reason;
		}, this);
		var result = !Ext.isEmpty(reason);
		if (result && errorInfo && (!Ext.isEmpty(reason.isError) || !Ext.isEmpty(cookie.message))) {
			errorInfo.message = decodeURIComponent(escape(cookie.message));
		}
		return result;
	},

	/**
	 * Checks is login page was loaded due to single sign out reasons.
	 * @param {Object} [errorInfo] Error infrmation object.
	 * @return {Boolean} True if login page was loaded due to single sign out reasons, false otherwise.
	 */
	isSsoUnauthorized: function(errorInfo) {
		return this.isUnauthorized(errorInfo, this._ssoLogoutCookieName);
	},

	/**
	 * Checks is login page was loaded due to OpenId reasons.
	 * @param {Object} [errorInfo] Error infrmation object.
	 * @return {Boolean} True if login page was loaded due to single sign out reasons, false otherwise.
	 */
	isOpenIdUnauthorized: function(errorInfo) {
		return this.isUnauthorized(errorInfo, this._openIdLogoutCookieName);
	},

	/**
	 * Checks is single sign on session need to be started.
	 * @return {Boolean} True if single sign on session need to be started, false otherwise.
	 */
	getNeedStartSso: function() {
		if (this._hasRequestParam(this._errorCodeParameterName)) {
			return false;
		}
		var cookie = Ext.util.Cookies.get(this._ssoLoginCookieName);
		var hasUseSsoRequestParam = this._hasRequestParam(this._useSsoParameterName);
		var hasReturnHashRequestParam = this._hasRequestParam(this._returnUrlHashParameterName);
		var hasUseSsoCookie = !Ext.isEmpty(cookie);
		return ((hasUseSsoRequestParam || hasUseSsoCookie) && !hasReturnHashRequestParam);
	},

	/**
	 * @obsolete
	 */
	getNeedShowLogin: function() {
		return this.getNeedShowSsoLogin();
	},

	/**
	 * Checks is single sign on provider login page need to be shown.
	 * @return {Boolean} True if single sign on provider login page need to be shown, false otherwise.
	 */
	getNeedShowSsoLogin: function() {
		var needStartSso = this.getNeedStartSso();
		var errorInfo = {};
		var isSsoUnauthorized = this.isSsoUnauthorized(errorInfo);
		if (isSsoUnauthorized && errorInfo.message) {
			Terrasoft.authenticationException = {
				"message": errorInfo.message
			};
		}
		Ext.util.Cookies.clear(this._ssoLogoutCookieName);
		return (needStartSso && !isSsoUnauthorized);
	},

	/**
	 * Goes to SSO identity provider login page.
	 * @param {Object} partner Partner Identity for login.
	 * @param {string|null} target Window.open target.
	*/
	startSsoLogin: function(partner, target) {
		let location = window.location;
		let hash = location.hash.replace("#", "");
		let ssoLoginUrl = new URL(this._getBaseUrl() + this._startSsoEndpoint);
		if (partner.id) {
			ssoLoginUrl.searchParams.append("partnerIdp", partner.id);
		}
		if (partner.userType) {
			ssoLoginUrl.searchParams.append("userType", partner.userType);
		}
		if (hash) {
			ssoLoginUrl.searchParams.append(this._returnUrlHashParameterName, hash);
		}
		if (this._hasRequestParam(this._returnUrlParameterName)) {
			let params = new URLSearchParams(location.search)
			ssoLoginUrl.searchParams.append(this._returnUrlParameterName, params.get(this._returnUrlParameterName));
		}
		this._clearOldSsoSession(() => {
			window.open(ssoLoginUrl.href, target || "_self");
		});
	},

	/**
	 * Creates SSO login links.
	 * @returns {Array} Array of SSO links.
	 */
	getSsoLoginLinks: function() {
		const result = [];
		const smallCaptionClass = "login-label-smallCaption";
		const blueColorClass = "login-label-blue";
		const loginHelpClass = "login-label-help";
		Terrasoft.each(window.SsoIdentityProviders, function(provider) {
			result.push(Ext.create("Terrasoft.Label", {
				caption: Terrasoft.Resources.LoginPage.SsoLogin + " ("+ provider.caption + ")",
				markerValue: "ssoLogin_" + provider.id,
				classes: {
					labelClass: [smallCaptionClass, blueColorClass, loginHelpClass]
				},
				tag: provider.id,
				click: {
					bindTo: "onSsoLoginClick"
				}
			}));
		}, this);
		return result;
	}
});
