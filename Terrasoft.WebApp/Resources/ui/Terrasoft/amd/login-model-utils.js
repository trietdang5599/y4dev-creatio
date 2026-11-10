define("login-model-utils", ["ext-base", "terrasoft"], function (Ext, Terrasoft) {
	const _openIdLogoutCookieName = "OpenIDLogout";
	const _returnUrlCode = "?ReturnUrl=";
	const baseViewModulePath = "/" + (Terrasoft.BaseViewModulePath || window.baseViewModulePath);
	const viewModuleAddress = "/Nui/ViewModule.aspx";
	const _workspaceExplorerUrl = "/dev";

	function _deleteDuplicateQueryStrings(url) {
		let resultUrl = "";
		url.split("&").forEach(function(element, index) {
			if (resultUrl.indexOf(element.split("=")[0]) !== -1) {
				return false;
			}
			if (index === 0) {
				resultUrl = resultUrl + element;
				return;
			}
			resultUrl = resultUrl + "&" + element;
		});
		return resultUrl;
	}
	
	Terrasoft.LoginModelUtils = {

		baseViewModulePath: baseViewModulePath,

		viewModuleAddress: viewModuleAddress,

		_getRedirectUrl: function (responseData, response, windowLocation) {
			if (responseData && responseData.RedirectUrl) {
				return responseData.RedirectUrl;
			}
			const responseHeaderLocation = this.getLocationFromHeaders(response);
			let appPath = baseViewModulePath;
			// ENG-90767: a login page that suppressed auto-login via simpleLogin can still carry an
			// explicit, local ReturnUrl (e.g. the OAuth /connect/authorize URL opened by "switch user"
			// on the consent page). Honor it instead of dropping to the default workspace, so the
			// interrupted flow resumes after the user signs in as a different account. The ReturnUrl is
			// read as a parsed query parameter, so it is found regardless of its position and is not
			// mistaken for the simpleLogin flag (the legacy "?ReturnUrl=" substring check missed both).
			const explicitReturnUrl = this._getReturnUrlParam(windowLocation);
			const windowUrlHasRedirectUrl = this.containsIgnoreCase(windowLocation.href,
				_returnUrlCode);
			if (windowUrlHasRedirectUrl) {
				let queryString = this.getWindowQueryString(windowLocation);
				if (windowLocation.hash) {
					queryString = this._prepareQueryString(queryString, responseHeaderLocation);
				}
				const hasQuerystring = this.containsIgnoreCase(windowLocation.pathname, queryString);
				const hasSimpleLogin = this.containsIgnoreCase(queryString, Terrasoft.simpleLoginTag);
				if (hasSimpleLogin && explicitReturnUrl) {
					return explicitReturnUrl + (windowLocation.hash || "");
				}
				return hasQuerystring || hasSimpleLogin
					? responseHeaderLocation + appPath
					: queryString;
			} else if (explicitReturnUrl) {
				return explicitReturnUrl + (windowLocation.hash || "");
			} else {
				return responseHeaderLocation.indexOf(_workspaceExplorerUrl) === -1
					? responseHeaderLocation + appPath + windowLocation.hash
					: responseHeaderLocation;
			}
		},

		_getReturnUrlParam: function (windowLocation) {
			const search = windowLocation.search || "";
			if (!search) {
				return "";
			}
			const params = new URLSearchParams(search);
			let returnUrl = "";
			params.forEach(function (value, key) {
				if (key.toLowerCase() === "returnurl" && value) {
					returnUrl = value;
				}
			});
			return this._isLocalReturnUrl(returnUrl) ? returnUrl : "";
		},

		_isLocalReturnUrl: function (url) {
			// Mirrors server-side UrlHelper.IsSafeUrl: only application-root-relative URLs are allowed.
			// Absolute ("http://", "https://") and protocol-relative ("//", "/\") URLs are rejected so
			// the post-login redirect cannot be abused as an open-redirect vector.
			return !!url && url.charAt(0) === "/" && url.charAt(1) !== "/" && url.charAt(1) !== "\\";
		},

		_prepareQueryString: function (queryString, responseHeaderLocation) {
			const hasWorkspaceNumberRegex = new RegExp(/^\/\d+/, "g");
			const queryStartsWithAppName = queryString.startsWith(responseHeaderLocation);
			const appNameStartsWithQuery = responseHeaderLocation.startsWith(queryString);
			if (queryStartsWithAppName || appNameStartsWithQuery) {
				return queryString;
			} else if (hasWorkspaceNumberRegex.test(queryString)) {
				return responseHeaderLocation + queryString.substring(hasWorkspaceNumberRegex.lastIndex);
			} else if (queryString.startsWith("/")) {
				return responseHeaderLocation + queryString;
			}
			return responseHeaderLocation + "/" + queryString;
		},

		containsIgnoreCase: function (str, searchStr) {
			return str.toUpperCase().indexOf(searchStr.toUpperCase()) !== -1;
		},

		checkOpenIdUnauthorized: function () {
			const errorInfo = {};
			const isOpenIdUnauthorized = Terrasoft.SsoUtils.isOpenIdUnauthorized(errorInfo);
			if (isOpenIdUnauthorized && errorInfo.message) {
				Terrasoft.authenticationException = {
					"message": errorInfo.message
				};
				Ext.util.Cookies.clear(_openIdLogoutCookieName);
			}
		},

		getQueryStringSeparatedByHash: function(windowLocation) {
			const encodedQueryString = windowLocation.search.replace(_returnUrlCode, "");
			const decodedQueryString = decodeURIComponent(encodedQueryString);
			return decodedQueryString.split('#');
		},

		getWindowQueryStringWithoutHash: function(windowLocation) {
			const queryStringSeparatedByHash = this.getQueryStringSeparatedByHash(windowLocation);
			const queryStringWithoutHash = queryStringSeparatedByHash[0];
			return _deleteDuplicateQueryStrings(queryStringWithoutHash);
		},
		
		getWindowQueryStringHash: function(windowLocation) {
			if (windowLocation.hash) {
				return windowLocation.hash;
			}
			const queryStringSeparatedByHash = this.getQueryStringSeparatedByHash(windowLocation);
			if (queryStringSeparatedByHash.length > 1){
				return queryStringSeparatedByHash[1];
			}
			return "";
		},

		setAuthenticationException: function(errorCode) {
			const authenticationException = Terrasoft.authenticationException;
			if (authenticationException) {
				return;
			}
			const authErrorExceptions = Terrasoft.AuthErrorExceptions || {};
			const message = authErrorExceptions[errorCode];
			if (message) {
				Terrasoft.authenticationException = {
					"message": message
				};
			}
		},

		tryShowAuthenticationErrorMsg: function(handler) {
			const authenticationException = Terrasoft.authenticationException;
			if (authenticationException) {
				Terrasoft.showMessage({
					caption: authenticationException.message,
					style: Terrasoft.MessageBoxStyles.BLUE,
					buttons: ["ok"],
					defaultButton: 0,
					handler: handler
				});
				return true;
			}
			return false;
		},

		getWindowQueryString: function (windowLocation) {
			const queryString = this.getWindowQueryStringWithoutHash(windowLocation);
			let hashString = this.getWindowQueryStringHash(windowLocation);
			if (hashString && !hashString.startsWith("#")) {
				hashString = "#" + hashString;
			}
			return queryString + hashString;
		},
		
		getLocationFromHeaders: function (response) {
			const responseHeaders = response.getAllResponseHeaders();
			return responseHeaders.location || "";
		},


		redirectToReturnUrl: function (responseData, response, windowLocation) {
			return this._getRedirectUrl(responseData, response, windowLocation);
		},
	};

	return Terrasoft.LoginModelUtils;
});
