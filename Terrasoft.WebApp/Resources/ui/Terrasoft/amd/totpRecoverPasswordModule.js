define(["ext-base", "terrasoft", "login-view-utils"], function(Ext, Terrasoft, loginUtils) {

	var _totpSetupTokenParamName = "totpSetupToken";
	var _module = {};

	var init = function() {
	};

	var renderView = function(renderTo) {
		// Classnames for elements
		var headClass = "login-label-logo";
		var smallCaptionClass = "login-label-smallCaption";
		var submitBtnClass = "login-button-login";
		var versionClass = "login-label-version";
		var containerFooterClass = "login-container-footer";
		var loginInsideContainerClass = "login-inside-container";
		var loginOutsideContainerClass = "login-outside-container";
		var loginPasswordEditClass = "login-textedit-login-password";
		var smallMarginClass = "login-label-smallMargin";
		var logoImageUrl = Terrasoft.appFramework === "NETFRAMEWORK"
			? window.loginImageUrl
			: "/Login/logo.svg";
		logoImageUrl = Ext.String.format("{0}{1}",
			Terrasoft.workspaceBaseUrl, logoImageUrl);
		// elements

		var logo = Ext.create("Terrasoft.ImageEdit", {
			readonly: true,
			classes: {
				wrapClass: [headClass]
			},
			imageSrc: logoImageUrl
		});
		var loginCaption = Ext.create("Terrasoft.Label", {
			caption: Terrasoft.Resources.LoginPage.LoginEditCaption,
			visible: {
				bindTo: "IsLoginVisible"
			},
			classes: {
				labelClass: [smallCaptionClass]
			}
		});
		var loginEdit = Ext.create("Terrasoft.TextEdit", {
			id: "loginEdit",
			classes: {
				wrapClass: [loginPasswordEditClass]
			},
			keyup: {
				bindTo: "onKeyUp"
			},
			visible: {
				bindTo: "IsLoginVisible"
			},
			value: {
				bindTo: "Login"
			},
			markerValue: "LoginEdit"
		});
		var totpCaption = Ext.create("Terrasoft.Label", {
			caption: Terrasoft.Resources.TotpSetup.Totp,
			visible: {
				bindTo: "IsTOTPCodeVisible"
			},
			classes: {
				labelClass: [smallCaptionClass]
			}
		});
		var totpCodeEdit = Ext.create("Terrasoft.TextEdit", {
			id: "totpCodeEdit",
			classes: {
				wrapClass: [loginPasswordEditClass]
			},
			keyup: {
				bindTo: "onKeyUp"
			},
			value: {
				bindTo: "TOTPCode"
			},
			visible: {
				bindTo: "IsTOTPCodeVisible"
			},
			markerValue: "totpCodeEdit"
		});
		var btnSubmit = Ext.create("Terrasoft.Button", {
			caption: Terrasoft.Resources.TotpSetup.Submit,
			pressed: true,
			style: Terrasoft.controls.ButtonEnums.style.GREEN,
			classes: {
				textClass: [submitBtnClass]
			},
			click: {
				bindTo: "onSubmitButtonClick"
			},
			markerValue: "btnSubmit",
			tips: [{
				tip: {
					content: Terrasoft.Resources.LoginPage.LoginButtonHint,
					displayMode: "narrow",
					restrictAlignType: Terrasoft.AlignType.BOTTOM,
					showDelay: 2000
				}
			}],
			loading: {
				bindTo: "Loading"
			}
		});
		var btnCotainer = Ext.create("Terrasoft.Container", {
			id: "btnContainer",
			selectors: {
				wrapEl: "#btnContainer"
			},
			classes: {
				wrapClassName: [smallMarginClass]
			},
			items: [btnSubmit]
		});
		var version = Ext.create("Terrasoft.Label", {
			caption: {
				bindTo: "productVersion"
			},
			classes: {
				labelClass: [smallCaptionClass, versionClass]
			}
		});
		var contFooter = Ext.create("Terrasoft.Container", {
			id: "loginFooterContainer",
			selectors: {
				wrapEl: "#loginFooterContainer"
			},
			classes: {
				wrapClassName: [containerFooterClass]
			},
			items: [version]
		});
		var contLogin = _module.view = Ext.create("Terrasoft.Container", {
			id: "loginContainer",
			selectors: {
				wrapEl: "#loginContainer"
			},
			items: [loginCaption, loginEdit, totpCaption, totpCodeEdit, btnCotainer, contFooter]
		});
		var contCellLogo = loginUtils.createCellContainer("cellLogoContainer");
		contCellLogo.items.add(logo);
		var contRowLogo = loginUtils.createRowContainer("rowLogoContainer");

		contRowLogo.items.add(contCellLogo);
		var contCellLogin = loginUtils.createCellContainer("cellLoginContainer");
		contCellLogin.items.add(contLogin);
		var contRowMain = loginUtils.createRowContainer("rowMainContainer");
		contRowMain.items.add(contCellLogin);
		var contTable = loginUtils.createTableContainer("tableContainer");
		contTable.items.add(contRowLogo);
		contTable.items.add(contRowMain);
		var contInside = _module.view = Ext.create("Terrasoft.Container", {
			id: "insideContainer",
			selectors: {
				wrapEl: "#insideContainer"
			},
			classes: {
				wrapClassName: [loginInsideContainerClass]
			},
			items: [contTable]
		});
		var view = _module.view = Ext.create("Terrasoft.Container", {
			id: "viewContainer",
			selectors: {
				wrapEl: "#viewContainer"
			},
			classes: {
				wrapClassName: [loginOutsideContainerClass]
			},
			items: [contInside],
			renderTo: renderTo
		});
		btnSubmit.setVisible(true);
	};

	var prepareModel = function() {
		_module.model = Ext.create("Terrasoft.BaseViewModel", {
			values: {
				productVersion: Terrasoft.Resources.LoginPage.Version + " " + window.productVersion
			},
			columns: {
				Login: {
					dataValueType: Terrasoft.DataValueType.TEXT,
					isRequired: true
				},
				TOTPCode: {
					dataValueType: Terrasoft.DataValueType.TEXT,
					isRequired: true
				},
				Loading: {
					dataValueType: Terrasoft.DataValueType.BOOLEAN
				},
				BodyMaskId: {
					dataValueType: Terrasoft.DataValueType.TEXT
				},
				"IsLoginVisible": {
					dataValueType: Terrasoft.DataValueType.BOOLEAN,
					value: false
				},
				"IsTOTPCodeVisible": {
					dataValueType: Terrasoft.DataValueType.BOOLEAN,
					value: false
				}
			},
			methods: {

				//region Fields: Private

				_getResetPasswordLinkErrorFlow: {
					"1": function(response, responseData) {
						Terrasoft.utils.showMessage({
							caption: Terrasoft.Resources.TotpSetup.TokenExpired,
							buttons: ["ok"],
							defaultButton: 0,
							style: Terrasoft.MessageBoxStyles.BLUE,
							handler: function(buttonCode) {
								if (buttonCode === "ok") {
									window.location.replace(this.getLinkWithoutParam(_totpSetupTokenParamName));
								}
							}.bind(this)
						});
					},
					"2": function(response, responseData) {
						this.showInfoMessage(Terrasoft.Resources.TotpSetup.InvalidTotp);
					},
					"3": function(response, responseData) {
						this.showInfoMessage(Terrasoft.Resources.TotpSetup.Error);
					}
				},

				//endregion

				//region Methods: Private

				//endregion

				getLinkWithoutParam: function(paramName) {
					var sourceURL = window.location.href;
					var rtn = sourceURL.split("?")[0],
						param,
						params_arr = [],
						queryString = (sourceURL.indexOf("?") !== -1) ? sourceURL.split("?")[1] : "";
					if (queryString !== "") {
						params_arr = queryString.split("&");
						for (var i = params_arr.length - 1; i >= 0; i -= 1) {
							param = params_arr[i].split("=")[0];
							if (param === paramName) {
								params_arr.splice(i, 1);
							}
						}
						rtn = rtn + "?" + params_arr.join("&");
					}
					return rtn;
				},

				showLoginMask: function() {
					this.set("Loading", true);
				},

				hideLoginMask: function() {
					this.set("Loading", false);
				},

				showInfoMessage: function(captionValue) {
					Terrasoft.utils.showMessage({
						caption: captionValue,
						buttons: ["ok"],
						defaultButton: 0,
						style: Terrasoft.MessageBoxStyles.BLUE
					});
				},

				remindPasswordCallback: function(request, success, response) {
					this.hideLoginMask();
					if (success && response.status === 200) {
						const responseData = Ext.decode(response.responseText);
						console.log(responseData);
						if (responseData.success) {
							this.showInfoMessage(Terrasoft.Resources.TotpSetup.RemindPasswordSuccess);
						} else {
							this.showInfoMessage(Terrasoft.Resources.TotpSetup.Error);
						}
					}
				},

				remindPassword: function() {
					this.showLoginMask();
					var options = {
						url: this.getBaseUrl() + "/0/ServiceModel/TotpSendResetPasswordLinkService.svc/RemindPassword",
						headers: {
							"Content-Type": "application/json",
							"Accept": "application/json"
						},
						method: "POST",
						scope: this,
						callback: this.remindPasswordCallback,
						jsonData: {
							"userName": this.get("Login")
						},
						securitySensitiveFields: []
					};
					Terrasoft.AjaxProvider.request(options);
				},

				onSubmitButtonClick: function() {
					if (this.getIsTotpSetupTokenPassed()) {
						this.getResetPasswordLink();
					} else {
						this.remindPassword();
					}
				},

				getResetPasswordLinkCallback: function(request, success, response) {
					this.hideLoginMask();
					if (success && response.status === 200) {
						const responseData = Ext.decode(response.responseText);
						console.log(responseData);
						if (responseData.success) {
							window.location.replace(responseData.link);
						} else {
							const processingErrorFunction = this._getResetPasswordLinkErrorFlow[responseData.code];
							if (Ext.isFunction(processingErrorFunction)) {
								processingErrorFunction.call(this, response, responseData);
							} else {
								this.showInfoMessage(Terrasoft.Resources.TotpSetup.Error);
							}
						}
					}
				},

				getResetPasswordLink: function() {
					this.showLoginMask();
					const options = {
						url: this.getBaseUrl() + "/0/ServiceModel/TotpResetPasswordService.svc/GenerateRecoveryPasswordLink",
						headers: {
							"Content-Type": "application/json",
							"Accept": "application/json"
						},
						method: "POST",
						scope: this,
						callback: this.getResetPasswordLinkCallback,
						jsonData: {
							"totpCode": this.get("TOTPCode"),
							"totpSetupTokenValue": this.getTotpSetupToken()
						},
						securitySensitiveFields: []
					};
					Terrasoft.AjaxProvider.request(options);
				},

				getTotpSetupToken: function() {
					return new URLSearchParams(window.location.search).get(_totpSetupTokenParamName);
				},

				getIsTotpSetupTokenPassed : function() {
					return this.getTotpSetupToken() && this.getTotpSetupToken().length > 0;
				},

				onKeyUp: function(e) {
					if (e && e.keyCode === e.ENTER) {
						this.onSubmitButtonClick();
					}
				},

				_getLocationFromHeaders: function(response) {
					var responseHeaders = response.getAllResponseHeaders();
					return responseHeaders.location || "";
				},

				getIsBodyMaskShown: function() {
					return this.get("BodyMaskId") && this.get("BodyMaskId").length ? true : false;
				},

				showBodyMask: function() {
					if (!this.getIsBodyMaskShown()) {
						this.set("BodyMaskId", Terrasoft.Mask.show());
					}
				},

				hideBodyMask: function() {
					if (this.getIsBodyMaskShown()) {
						Terrasoft.Mask.hide(this.get("BodyMaskId"));
						this.set("BodyMaskId", "");
					}
				},

				getBaseUrl: function() {
					return Terrasoft.loaderBaseUrl.endsWith("/") ? Terrasoft.loaderBaseUrl.slice(0, -1) : Terrasoft.loaderBaseUrl;
				},

				init: function() {
					if (this.getIsTotpSetupTokenPassed()) {
						this.set("IsTOTPCodeVisible", true);
					} else {
						this.set("IsLoginVisible", true);
					}
				},

				onRender: function() {
				}
			}
		});
	};

	return {
		renderTo: Ext.getBody(),
		init: init,
		render: function (renderTo) {
			prepareModel();
			_module.model.init();
			renderView(renderTo);
			_module.view.bind(_module.model);
			_module.model.onRender();
		}
	};
});
