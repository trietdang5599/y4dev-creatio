define(["ext-base", "terrasoft", "login-view-utils", "qrcode"], function(Ext, Terrasoft, loginUtils) {
	var _OTPAuthUrl = "otpauth://totp/Creatio?secret=";
	var _loginUrl = "/Login/NuiLogin.aspx";
	var _sspLoginUrl = "/Login/SspLogin.aspx";
	var _module = {};

	var init = function() {
	};

	var renderInfoView = function() {
		var labelSupport = Ext.create("Terrasoft.HtmlControl", {
			htmlContent: Terrasoft.Resources.TotpSetup.Info
		});

		var container = Ext.create("Terrasoft.Container", {
			classes: {
				wrapClassName: ["login-totp-info"]
			},
			items: [labelSupport]
		});

		return container;
	};

	var getBorderContainer = function(name, wrapClassName) {
		var cellLine = loginUtils.createCellContainer(name);
		cellLine.classes.wrapClassName.push(wrapClassName);
		return cellLine;
	};

	var renderView = function(renderTo) {
		var headClass = "login-label-logo";
		var smallCaptionClass = "login-label-smallCaption";
		var loginBtnClass = "login-button-login";
		var versionClass = "login-label-version";
		var containerFooterClass = "login-container-footer";
		var loginBorderLeftClass = "login-border-left";
		var loginBorderRightClass = "login-border-right";
		var loginEmptyCellClass = "login-empty-cell";
		var loginInsideContainerClass = "login-inside-container";
		var loginOutsideContainerClass = "login-outside-container";
		var loginPasswordEditClass = "login-textedit-login-password";
		var qrCodeContainerClass = "qrcode-container";
		var qrCodeClass = "qrcode";
		var smallMarginClass = "login-label-smallMargin";
		var logoImageUrl = Terrasoft.appFramework === "NETFRAMEWORK"
			? window.loginImageUrl
			: "/Login/logo.svg";
		logoImageUrl = Ext.String.format("{0}{1}", Terrasoft.workspaceBaseUrl, logoImageUrl);
		var logo = Ext.create("Terrasoft.ImageEdit", {
			readonly: true,
			classes: {
				wrapClass: [headClass]
			},
			imageSrc: logoImageUrl
		});
		var qrCode = Ext.create("Terrasoft.Container", {
			id: "qrCode",
			selectors: {
				wrapEl: "#qrCode"
			},
			classes: {
				wrapClassName: [qrCodeClass]
			},
			items: []
		});
		var secretCaption = Ext.create("Terrasoft.Label", {
			caption: Terrasoft.Resources.TotpSetup.Secret,
			classes: {
				labelClass: [smallCaptionClass]
			}
		});
		var secretEdit = Ext.create("Terrasoft.TextEdit", {
			id: "secretEdit",
			readonly: true,
			classes: {
				wrapClass: [loginPasswordEditClass]
			},
			keyup: {
				bindTo: "onKeyUp"
			},
			value: {
				bindTo: "Secret"
			},
			markerValue: "secretEdit"
		});
		var totpCaption = Ext.create("Terrasoft.Label", {
			caption: Terrasoft.Resources.TotpSetup.Totp,
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
				bindTo: "TotpCode"
			},
			markerValue: "totpCodeEdit"
		});
		var qrCodeCotainer = Ext.create("Terrasoft.Container", {
			id: "qrCodeContainer",
			selectors: {
				wrapEl: "#qrCodeContainer"
			},
			classes: {
				wrapClassName: [qrCodeContainerClass]
			},
			items: [qrCode, secretCaption, secretEdit, totpCaption, totpCodeEdit]
		});
		var btnValidate = Ext.create("Terrasoft.Button", {
			caption: Terrasoft.Resources.TotpSetup.Validate,
			pressed: true,
			style: Terrasoft.controls.ButtonEnums.style.GREEN,
			classes: {
				textClass: [loginBtnClass]
			},
			click: {
				bindTo: "onValidateButtonClick"
			},
			markerValue: "btnValidate",
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
			items: [btnValidate]
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
			items: [qrCodeCotainer, btnCotainer, contFooter]
		});
		var contCellLogo = loginUtils.createCellContainer("cellLogoContainer");
		contCellLogo.items.add(logo);
		var infoContainer = renderInfoView(renderTo);
		var contRowLogo = loginUtils.createRowContainer("rowLogoContainer");

		contRowLogo.items.add(contCellLogo);
		var contCellLogin = loginUtils.createCellContainer("cellLoginContainer");
		contCellLogin.items.add(contLogin);
		var contRowMain = loginUtils.createRowContainer("rowMainContainer");
		contRowMain.items.add(contCellLogin);
		if (infoContainer) {
			contRowMain.items.add(getBorderContainer("cellLineRight-info", loginBorderRightClass));
			contRowMain.items.add(getBorderContainer("cellLineLeft-info", loginBorderLeftClass));
			contRowMain.items.add(infoContainer);
		}
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
		btnValidate.setVisible(true);
	};

	var prepareModel = function() {
		_module.model = Ext.create("Terrasoft.BaseViewModel", {
			values: {
				productVersion: Terrasoft.Resources.LoginPage.Version + " " + window.productVersion
			},
			columns: {
				Secret: {
					dataValueType: Terrasoft.DataValueType.TEXT,
					isRequired: true
				},
				TotpCode: {
					dataValueType: Terrasoft.DataValueType.TEXT,
					isRequired: true
				},
				Loading: {
					dataValueType: Terrasoft.DataValueType.BOOLEAN
				},
				BodyMaskId: {
					dataValueType: Terrasoft.DataValueType.TEXT
				}
			},
			methods: {

				//region Fields: Private

				_setUp2FAErrorFlow: {
					"1": function(response, responseData) {
						Terrasoft.utils.showMessage({
							caption: Terrasoft.Resources.TotpSetup.TokenExpired,
							buttons: ["ok"],
							defaultButton: 0,
							style: Terrasoft.MessageBoxStyles.BLUE,
							handler: function(buttonCode) {
								if (buttonCode === "ok") {
									this.redirectToPreviousPage(response);
								}
							}.bind(this)
						});
					},
					"2": function(response, responseData) {
						this.showInfoMessage(Terrasoft.Resources.TotpSetup.InvalidTotp);
					}
				},

				//endregion

				//region Methods: Private

				displayQrCode: function(userSecret) {
					const qrcode = new QRCode(document.getElementById("qrCode"), {
						width: 310,
						height: 310
					});
					const url = _OTPAuthUrl + userSecret;
					qrcode.makeCode(url);
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

				onValidateButtonClick: function() {
					this.setUpTotp();
				},

				onKeyUp: function(e) {
					if (e && e.keyCode === e.ENTER) {
						this.onValidateButtonClick();
					}
				},

				redirectToPreviousPage: function (response) {
					var baseUrl = this._getLocationFromHeaders(response);
					baseUrl = baseUrl.length ? baseUrl : (Terrasoft.loaderBaseUrl.endsWith("/") ? Terrasoft.loaderBaseUrl.slice(0, -1) : Terrasoft.loaderBaseUrl);
					var params = new URLSearchParams(window.location.search);
					var loginUrl = _loginUrl;
					if (params.has('referrer')) {
						const referrer = params.get('referrer');
						switch (referrer) {
							case 'SspLogin':
								loginUrl = _sspLoginUrl;
								break;
							case 'userprofile':
								history.back();
								return;
						}
						params.delete('referrer');
					}
					window.location.replace(baseUrl + loginUrl + "?" + params.toString());
				},

				onSecretReceivedCallback: function(request, success, response) {
					this.hideBodyMask();
					if (success && response.status === 200) {
						var responseData = Ext.decode(response.responseText);
						this.set("Secret", responseData);
						this.displayQrCode(this.get("Secret"));
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

				onSetUpTotpCallback: function(request, success, response) {
					this.hideLoginMask();
					if (success && response.status === 200) {
						var responseData = Ext.decode(response.responseText);
						if (responseData.success) {
							Terrasoft.utils.showMessage({
								caption: Terrasoft.Resources.TotpSetup.Success,
								buttons: ["ok"],
								defaultButton: 0,
								style: Terrasoft.MessageBoxStyles.BLUE,
								handler: function(buttonCode) {
									if (buttonCode === "ok") {
										this.redirectToPreviousPage(response);
									}
								}.bind(this)
							});
						} else {
							const processingErrorFunction = this._setUp2FAErrorFlow[responseData.code];
							if (Ext.isFunction(processingErrorFunction)) {
								processingErrorFunction.call(this, response, responseData);
							} else {
								this.showInfoMessage(Terrasoft.Resources.TotpSetup.Error);
							}
						}
					}
				},

				getBaseUrl: function() {
					return Terrasoft.loaderBaseUrl.endsWith("/") ? Terrasoft.loaderBaseUrl.slice(0, -1) : Terrasoft.loaderBaseUrl;
				},

				setUpTotp: function() {
					this.showLoginMask();
					var options = {
						url: this.getBaseUrl() + "/ServiceModel/TotpSetupService.svc/SetUpTotp",
						headers: {
							"Content-Type": "application/json",
							"Accept": "application/json"
						},
						method: "POST",
						scope: this,
						callback: this.onSetUpTotpCallback,
						jsonData: {
							"totpCode": this.get("TotpCode"),
						},
						securitySensitiveFields: []
					};
					if (window.loginTimeout) {
						options.timeout = window.loginTimeout;
					}
					Terrasoft.AjaxProvider.request(options);
				},

				updateSecret: function() {
					this.showBodyMask();
					var options = {
						url: this.getBaseUrl() + "/ServiceModel/TotpSetupService.svc/GenerateSecret",
						headers: {
							"Content-Type": "application/json",
							"Accept": "application/json"
						},
						method: "POST",
						scope: this,
						callback: this.onSecretReceivedCallback,
						jsonData: null,
						securitySensitiveFields: []
					};
					if (window.loginTimeout) {
						options.timeout = window.loginTimeout;
					}
					Terrasoft.AjaxProvider.request(options);
				},

				init: function() {
				},

				onRender: function() {
					this.updateSecret();
				}
			}
		});
	};

	return {
		renderTo: Ext.getBody(),
		init: init,
		render: function(renderTo) {
			prepareModel();
			_module.model.init();
			renderView(renderTo);
			_module.view.bind(_module.model);
			_module.model.onRender();
		}
	};
});
