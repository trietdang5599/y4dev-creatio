define(["ext-base", "terrasoft", "login-view-utils", "login-model-utils", "ssoutils",
		"open-id-start-sso-client-provider", "saml-start-sso-client-provider", "two-factor-auth-utils"],
	function(Ext, Terrasoft, loginViewUtils, loginModelUtils) {
	const _licenseManagerUrl = "/ClientApp/#/LicenseManager?mode=login";
	const _onBoardingUrl = "/Login/TotpSetup.aspx";
	const _module = {};
	const _textCodeTwoFactorAuthFlowCode = 'SMS';

	const addViewportMetaTag = function() {
		const meta = document.createElement("meta");
		meta.name = "viewport";
		meta.content = "width=device-width, initial-scale=1.0";
		document.getElementsByTagName("head")[0].appendChild(meta);
	};

	const loadConditionalDependencies = function () {
		if (Terrasoft.enable2FA && Terrasoft.enabled2FAFlow && Terrasoft.useSeparatedPage2FA) {
			require(["css-ltr!two-fa-styles", "mf!two-fa"]);
		}
	}

	const init = function() {
		addViewportMetaTag();
		loadConditionalDependencies();
	};

	const createImportantLinks = function(items) {
		return Ext.create("Terrasoft.HtmlControl", {
			tpl: [
				/*jshint quotmark: false */
				//jscs:disable
				"<ul id=\"{id}\">",
				"<tpl for=\"items\">",
				"<li class=\"login-links-list\">",
				"<a target=\"_blank\" class=\"login-important-link\" href=\"{href}\">",
				/*jshint quotmark: true */
				//jscs:enable
				"{caption}",
				"</a>",
				"</li>",
				"</tpl>",
				"</ul>"
			],
			id: "importantLinks",
			tplData: {
				items: items
			},
			selectors: {
				wrapEl: "#importantLinks"
			}
		});
	};

	const renderInfoView = function() {
		if (window.changePasswordMode === true) {
			return null;
		}
		const loginEmptyRowClass = "login-empty-row";
		const loginInfoLabelHeaderClass = "login-info-label-header";
		const loginSubcellSupportInfoLabelClass = "login-subcell-support-info-label";
		const loginSubcellSupportInfoTelClass = "login-subcell-support-tel-label";
		const loginSubcellSupportClass = "login-subcell-support";
		let contSupportData = null;
		let contImportantBaseLinks = null;
		if (window.supportInfo.length > 0) {
			const contInfoTable = loginViewUtils.createTableContainer("supportInfoTable");
			let index = 0;
			Terrasoft.each(window.supportInfo, function(elem) {
				const rowInfo = loginViewUtils.createRowContainer("infoRow_" + index);
				contInfoTable.items.add(rowInfo);
				let label = loginViewUtils.createLabel(elem.name);
				label.classes.labelClass.push(loginSubcellSupportInfoLabelClass);
				let supportInfoCell = loginViewUtils.createCellContainer("supportNameCell_" + index);
				supportInfoCell.classes.wrapClassName.push(loginSubcellSupportClass);
				supportInfoCell.items.add(label);
				rowInfo.items.add(supportInfoCell);

				label = loginViewUtils.createLabel(elem.tel);
				label.classes.labelClass.push(loginSubcellSupportInfoTelClass);
				supportInfoCell = loginViewUtils.createCellContainer("supportTelCell_" + index);
				supportInfoCell.classes.wrapClassName.push(loginSubcellSupportClass);
				supportInfoCell.items.add(label);
				rowInfo.items.add(supportInfoCell);
				index++;
			}, this);
			const labelSupport = Ext.create("Terrasoft.Label", {
				caption: window.supportInfoCaption,
				classes: {
					labelClass: [loginInfoLabelHeaderClass]
				}
			});
			contSupportData = loginViewUtils.createTableContainer("supportTable");
			let supportRow = loginViewUtils.createRowContainer("supportLogoRow");
			contSupportData.items.add(supportRow);
			let supportCell = loginViewUtils.createCellContainer("supportLogoCell");
			supportRow.items.add(supportCell);
			supportCell.items.add(labelSupport);
			supportRow = loginViewUtils.createRowContainer("supportDataRow");
			contSupportData.items.add(supportRow);
			supportCell = loginViewUtils.createCellContainer("supportNameCell");
			supportRow.items.add(supportCell);
			supportCell.items.add(contInfoTable);
		}
		if (window.importantLinks.length > 0) {
			contImportantBaseLinks = loginViewUtils.createTableContainer("linksBaseTable");
			let linksRow = loginViewUtils.createRowContainer("linksLogoRow");
			contImportantBaseLinks.items.add(linksRow);
			let linksCell = loginViewUtils.createCellContainer("linksLogoCell");
			linksRow.items.add(linksCell);
			const labelLinks = Ext.create("Terrasoft.Label", {
				caption: window.importantLinksCaption,
				classes: {
					labelClass: [loginInfoLabelHeaderClass]
				}
			});
			linksCell.items.add(labelLinks);
			linksRow = loginViewUtils.createRowContainer("linksDataRow");
			contImportantBaseLinks.items.add(linksRow);
			const itemsConfig = [];
			Terrasoft.each(window.importantLinks, function(elem) {
				itemsConfig.push({
					caption: elem.name,
					href: elem.link
				});
			}, this);
			const links = createImportantLinks(itemsConfig);
			linksCell = loginViewUtils.createCellContainer("supportLogoCell");
			linksCell.items.add(links);
			linksRow.items.add(linksCell);
		}
		if (contSupportData != null || contImportantBaseLinks != null) {
			const contExtendInfo = loginViewUtils.createCellContainer("extendInfoContainer");
			if (contSupportData != null) {
				const suppRowInfo = loginViewUtils.createRowContainer("supportRowInfo");
				suppRowInfo.items.add(contSupportData);
				contExtendInfo.items.add(suppRowInfo);
				const suppRowInfoEmpty = loginViewUtils.createRowContainer("supportRowInfoEmpty");
				suppRowInfoEmpty.classes.wrapClassName.push(loginEmptyRowClass);
				contExtendInfo.items.add(suppRowInfoEmpty);
			}
			if (contImportantBaseLinks != null) {
				contExtendInfo.items.add(contImportantBaseLinks);
			}
			return contExtendInfo;
		}
		return null;
	};

	const getWidgetView = function() {
		const loginPageWidgetInfo = window.loginPageWidgetInfo;
		if (!loginPageWidgetInfo || !loginPageWidgetInfo.visible ||
			!loginPageWidgetInfo.src) {
			return null;
		}
		const widgetIframe = Ext.create("Terrasoft.ExternalWidget", {
			"iframeSrc": window.loginPageWidgetInfo.src,
			"sandboxAttributes": window.loginPageWidgetInfo.sandboxAttributes,
			"classes": {
				"wrapClassName": ["login-widget-container"],
			}
		});
		const widgetLoginCell = Ext.create("Terrasoft.Container", {
			id: "widgetLoginCell",
			classes: {
				wrapClassName: ["widget-wrap-class"]
			}
		});
		widgetLoginCell.items.add(widgetIframe);
		return widgetLoginCell;
	};

	const getBorderContainer = function(name, wrapClassName) {
		const cellLine = loginViewUtils.createCellContainer(name);
		cellLine.classes.wrapClassName.push(wrapClassName);
		return cellLine;
	};

	const renderView = function(renderTo) {
		// Class names for elements
		const headClass = "login-label-logo";
		const smallCaptionClass = "login-label-smallCaption";
		const textCodeCaptionClass = "text-code-caption";
		const loginPasswordEditClass = "login-textedit-login-password";
		const loginBtnClass = "login-button-login";
		const blueColorClass = "login-label-blue";
		const smallMarginClass = "login-label-smallMargin";
		const loginHelpClass = "login-label-help";
		const passwordHelpClass = "password-label-help";
		const userManagementClass = "user-management-container";
		const versionClass = "login-label-version";
		const loginRememberClass = "login-label-remember";
		const checkboxClass = "login-checkbox-remember";
		const helperClass = "login-label-helper";
		const containerRememberClass = "login-container-remember";
		const containerFooterClass = "login-container-footer";
		const containerRememberClassInside = "login-container-remember-inside";
		const loginBorderLeftClass = "login-border-left";
		const loginBorderRightClass = "login-border-right";
		const loginEmptyCellClass = "login-empty-cell";
		const loginOutsideContainerClass = "login-outside-container";
		const textCodeHeaderContainerClass = "text-code-header-container";
		let logoImageUrl = Terrasoft.useConstLoginImageUrl
			? "/Login/logo.svg"
			: window.loginImageUrl;
		logoImageUrl = Ext.String.format("{0}{1}",
			Terrasoft.workspaceBaseUrl, logoImageUrl);
		// elements

		const logo = Ext.create("Terrasoft.ImageEdit", {
			readonly: true,
			classes: {
				wrapClass: [headClass]
			},
			imageSrc: logoImageUrl
		});
		const loginCaption = Ext.create("Terrasoft.Label", {
			caption: Terrasoft.Resources.LoginPage.LoginEditCaption,
			classes: {
				labelClass: [smallCaptionClass]
			}
		});
		const totpCaption = Ext.create("Terrasoft.Label", {
			caption: Terrasoft.Resources.TotpSetup.Totp,
			id: "textCodeCaption",
			classes: {
				labelClass: [smallCaptionClass, textCodeCaptionClass, smallMarginClass]
			},
			visible: false
		});
		const textCodeResendPasswordLink = Ext.create("Terrasoft.Label", {
			caption: {
				bindTo: "getSendCodeCaption"
			},
			classes: {
				labelClass: [smallCaptionClass, blueColorClass, loginHelpClass]
			},
			click: {
				bindTo: "onSendTextCodeClick"
			},
			visible: {
				bindTo: "getIsSendCodeLinkVisible"
			}
		});
		const textCodeContainer = Ext.create("Terrasoft.Container", {
			items: [
				textCodeResendPasswordLink
			],
			classes: {
				wrapClassName: [textCodeHeaderContainerClass]
			},
			visible: false
		});
		const passwordCaption = Ext.create("Terrasoft.Label", {
			caption: Terrasoft.Resources.LoginPage.PasswordEditCaption,
			classes: {
				labelClass: [smallCaptionClass, smallMarginClass]
			}
		});
		const newPasswordCaption = Ext.create("Terrasoft.Label", {
			caption: Terrasoft.Resources.LoginPage.NewPasswordEditCaption,
			classes: {
				labelClass: [smallCaptionClass, smallMarginClass]
			}
		});
		const confirmPasswordCaption = Ext.create("Terrasoft.Label", {
			caption: Terrasoft.Resources.LoginPage.ConfirmPasswordEditCaption,
			classes: {
				labelClass: [smallCaptionClass, smallMarginClass]
			}
		});
		const workspaceCaption = Ext.create("Terrasoft.Label", {
			caption: Terrasoft.Resources.LoginPage.WorkspaceEditCaption,
			classes: {
				labelClass: [smallCaptionClass, smallMarginClass]
			}
		});
		const passwordHelp = Ext.create("Terrasoft.Label", {
			caption: Terrasoft.Resources.LoginPage.ForgetPassword,
			classes: {
				labelClass: [smallCaptionClass, blueColorClass, passwordHelpClass]
			},
			click: {bindTo: "onRemindPasswordClick"}
		});
		const ntlmLoginHelp = Ext.create("Terrasoft.Label", {
			caption: Terrasoft.Resources.LoginPage.NtlmLogin,
			classes: {
				labelClass: [smallCaptionClass, blueColorClass, loginHelpClass]
			},
			click: {
				bindTo: "onNtlmLoginClick"
			},
			tips: [{
				tip: {
					content: Terrasoft.Resources.LoginPage.NtlmLoginLabelHint,
					displayMode: "narrow",
					restrictAlignType: Terrasoft.AlignType.BOTTOM,
					showDelay: 2000
				}
			}]
		});
		const openIdLoginLink = Ext.create("Terrasoft.Label", {
			caption: Terrasoft.Resources.LoginPage.OpenIdLogin,
			markerValue: "openIdLogin",
			classes: {
				labelClass: [smallCaptionClass, blueColorClass, loginHelpClass]
			},
			click: {
				bindTo: "onOpenIdLoginClick"
			}
		});
		const ssoLinks = Terrasoft.SsoUtils.getSsoLoginLinks();
		const userManagement = Ext.create("Terrasoft.Container", {
			id: "userManagementContainer",
			selectors: {
				wrapEl: "#userManagementContainer"
			},
			classes: {
				wrapClassName: [userManagementClass]
			},
			items: Ext.Array.merge([ntlmLoginHelp, openIdLoginLink], ssoLinks)
		});
		const loginEdit = Ext.create("Terrasoft.TextEdit", {
			id: "loginEdit",
			classes: {
				wrapClass: [loginPasswordEditClass]
			},
			keyup: {
				bindTo: "onKeyUp"
			},
			value: {
				bindTo: "Login"
			},
			markerValue: "loginEdit"
		});
		const passwordEdit = Ext.create("Terrasoft.TextEdit", {
			id: "passwordEdit",
			protect: true,
			classes: {
				wrapClass: [loginPasswordEditClass]
			},
			keyup: {
				bindTo: "onKeyUp"
			},
			value: {
				bindTo: "Password"
			},
			markerValue: "passwordEdit"
		});
		const totpCodeEdit = Ext.create("Terrasoft.TextEdit", {
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
			markerValue: "totpCodeEdit",
			visible: false
		});
		const newPasswordEdit = Ext.create("Terrasoft.TextEdit", {
			protect: true,
			classes: {
				wrapClass: [loginPasswordEditClass]
			},
			keyup: {
				bindTo: "onKeyUp"
			},
			value: {
				bindTo: "NewPassword"
			},
			markerValue: "newPasswordEdit"
		});
		const confirmPasswordEdit = Ext.create("Terrasoft.TextEdit", {
			protect: true,
			classes: {
				wrapClass: [loginPasswordEditClass]
			},
			keyup: {
				bindTo: "onKeyUp"
			},
			value: {
				bindTo: "ConfirmPassword"
			},
			markerValue: "confirmPasswordEdit"
		});
		const workspaceEdit = Ext.create("Terrasoft.ComboBoxEdit", {
			classes: {
				wrapClass: [loginPasswordEditClass]
			},
			keyup: {
				bindTo: "onKeyUp"
			},
			list: {
				bindTo: "workspaceList"
			},
			value: {
				bindTo: "Workspace"
			},
			markerValue: "workspaceEdit",
			prepareList: {
				bindTo: "getWorkspaceList"
			}
		});
		const btnLogin = Ext.create("Terrasoft.Button", {
			caption: Terrasoft.Resources.LoginPage.LoginButtonCaption,
			pressed: true,
			style: Terrasoft.controls.ButtonEnums.style.GREEN,
			classes: {
				textClass: [loginBtnClass]
			},
			click: {
				bindTo: "onLoginButtonClick"
			},
			markerValue: "btnLogin",
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
		const btnChangePasswordLogin = Ext.create("Terrasoft.Button", {
			caption: Terrasoft.Resources.LoginPage.LoginButtonCaption,
			pressed: true,
			style: Terrasoft.controls.ButtonEnums.style.GREEN,
			classes: {
				textClass: [loginBtnClass]
			},
			click: {
				bindTo: "onChangePasswordLoginButtonClick"
			},
			markerValue: "btnChangePasswordLogin",
		});
		const checkBox = Ext.create("Terrasoft.CheckBoxEdit", {
			id: "rememberMeCheckbox",
			classes: {
				wrapClass: [checkboxClass]
			},
			checked: {
				bindTo: "RememberMeCheckbox"
			},
			click: {
				bindTo: "onConfirmCheckboxClick"
			}
		});
		const checkBoxLabel = Ext.create("Terrasoft.Label", {
			caption: Terrasoft.Resources.LoginPage.RememberMeCaption,
			inputId: "rememberMeCheckbox-el",
			classes: {
				labelClass: [loginRememberClass, smallCaptionClass]
			}
		});
		const version = Ext.create("Terrasoft.Label", {
			caption: {
				bindTo: "productVersion"
			},
			classes: {
				labelClass: [smallCaptionClass, versionClass]
			}
		});
		const help = Ext.create("Terrasoft.Label", {
			caption: Terrasoft.Resources.LoginPage.Help,
			classes: {
				labelClass: [smallCaptionClass, blueColorClass, helperClass]
			},
			inputId: checkBox
		});
		const contRememberInside = Ext.create("Terrasoft.Container", {
			id: "loginRememberInsideContainer",
			selectors: {
				wrapEl: "#loginRememberInsideContainer"
			},
			classes: {
				wrapClassName: [containerRememberClassInside]
			},
			items: [checkBox, checkBoxLabel]
		});
		const contRememberItems = [btnLogin, btnChangePasswordLogin, contRememberInside];
		const contRemember = Ext.create("Terrasoft.Container", {
			id: "loginRememberContainer",
			selectors: {
				wrapEl: "#loginRememberContainer"
			},
			classes: {
				wrapClassName: [containerRememberClass]
			},
			items: contRememberItems
		});
		const contFooter = Ext.create("Terrasoft.Container", {
			id: "loginFooterContainer",
			selectors: {
				wrapEl: "#loginFooterContainer"
			},
			classes: {
				wrapClassName: [containerFooterClass]
			},
			items: [version, help]
		});
		const unsupportedBrowser = loginViewUtils.createUnsupportedBrowserContainer();
		const contLogin = _module.view = Ext.create("Terrasoft.Container", {
			id: "loginContainer",
			selectors: {
				wrapEl: "#loginContainer"
			},
			items: [loginCaption, loginEdit, passwordCaption, passwordEdit, newPasswordCaption, newPasswordEdit,
				confirmPasswordCaption, confirmPasswordEdit, totpCaption, totpCodeEdit, textCodeContainer,
				workspaceCaption, workspaceEdit, contRemember, userManagement, contFooter,
				unsupportedBrowser
			]
		});
		if (Boolean(Terrasoft.usePasswordRecoveryForInternalUsers)) {
			const passwordEditIndex = contLogin.items.indexOf(passwordEdit);
			contLogin.items.insert(passwordEditIndex + 1, passwordHelp.id, passwordHelp);
		}
		const contCellLogo = loginViewUtils.createCellContainer("cellLogoContainer");
		contCellLogo.items.add(logo);
		const infoContainer = renderInfoView();
		const contRowLogo = loginViewUtils.createRowContainer("rowLogoContainer");
		if (infoContainer) {
			const paddingContainer = loginViewUtils.createCellContainer("rowPaddingContainer");
			contRowLogo.items.add(paddingContainer);
			contRowLogo.items.add(getBorderContainer("cellLineRightLogo", loginEmptyCellClass));
			contRowLogo.items.add(getBorderContainer("cellLineLeftLogo", loginEmptyCellClass));
		}
		contRowLogo.items.add(contCellLogo);
		const contCellLogin = loginViewUtils.createCellContainer("cellLoginContainer");
		contCellLogin.items.add(contLogin);
		const contRowMain = loginViewUtils.createRowContainer("rowMainContainer");
		if (infoContainer) {
			contRowMain.items.add(infoContainer);
			contRowMain.items.add(getBorderContainer("cellLineRight-info", loginBorderRightClass));
			contRowMain.items.add(getBorderContainer("cellLineLeft-info", loginBorderLeftClass));
		}
		contRowMain.items.add(contCellLogin);
		const widgetInfo = getWidgetView();
		if (widgetInfo) {
			contRowMain.items.add(widgetInfo);
		}
		const contTable = loginViewUtils.createTableContainer("tableContainer");
		contTable.items.add(contRowLogo);
		contTable.items.add(contRowMain);
		const contInside = _module.view = Ext.create("Terrasoft.Container", {
			id: "insideContainer",
			selectors: {
				wrapEl: "#insideContainer"
			},
			items: [contTable]
		});
		const view = _module.view = Ext.create("Terrasoft.Container", {
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
		if (Boolean(Terrasoft.usePasswordRecoveryForInternalUsers)) {
			passwordHelp.setVisible(true);
		}
		help.setVisible(false);
		userManagement.setVisible(true);
		const isNtlmLoginVisible = window.isNtlmLoginVisible;
		const isOpenIdLoginVisible = window.isOpenIdLoginVisible;
		ntlmLoginHelp.setVisible(isNtlmLoginVisible);
		openIdLoginLink.setVisible(isOpenIdLoginVisible);
		contRememberInside.setVisible(false);
		view.hideWorkspaceEdit = function() {
			workspaceEdit.setVisible(false);
			workspaceCaption.setVisible(false);
		};
		view.setTotpEditVisible = function(value) {
			totpCaption.setVisible(value);
			totpCodeEdit.setVisible(value);
			passwordHelp.setVisible(value);
			totpCaption.setVisible(value);
			textCodeContainer.setVisible(value);
		};
		view.showLoginMode = function() {
			newPasswordCaption.setVisible(false);
			newPasswordEdit.setVisible(false);
			confirmPasswordCaption.setVisible(false);
			confirmPasswordEdit.setVisible(false);
			btnChangePasswordLogin.setVisible(false);
			if (Terrasoft.canStoreUserNameInCookie && Terrasoft.UseRememberMe){
				contRememberInside.setVisible(true);
			}
			btnLogin.setVisible(true);
			if (Terrasoft.enable2FA && !Terrasoft.enabled2FAFlow
					&& !Terrasoft.useSeparatedPage2FA) {
				view.setTotpEditVisible(true);
			}
		};
		view.showChangePasswordMode = function() {
			newPasswordCaption.setVisible(true);
			newPasswordEdit.setVisible(true);
			confirmPasswordCaption.setVisible(true);
			confirmPasswordEdit.setVisible(true);
			btnChangePasswordLogin.setVisible(true);
			btnLogin.setVisible(false);
			if (Terrasoft.enable2FA && !Terrasoft.useSeparatedPage2FA) {
				Terrasoft.firstFactorFlowPassed = true;
				view.setTotpEditVisible(true);
			}
		};
		view.showUnsupportedBrowser = function() {
			unsupportedBrowser.setVisible(true);
		}
		if (Terrasoft.useScriptsForAnonymousPage) {
			version.setVisible(false);
		}
	};

	const prepareModel = function() {
		let version = window.productVersion;
		if (Terrasoft.frameworkDescription) {
			version += " (" + Terrasoft.frameworkDescription + ")";
		}
		_module.model = Ext.create("Terrasoft.BaseViewModel", {
			values: {
				productVersion: Terrasoft.Resources.LoginPage.Version + " " + version,
				workspaceList: Ext.create("Terrasoft.Collection")
			},
			columns: {
				Login: {
					dataValueType: Terrasoft.DataValueType.TEXT,
					isRequired: true
				},
				TOTPCode: {
					dataValueType: Terrasoft.DataValueType.TEXT,
					isRequired: false
				},
				Password: {
					dataValueType: Terrasoft.DataValueType.TEXT,
					isRequired: true
				},
				NewPassword: {
					dataValueType: Terrasoft.DataValueType.TEXT,
					isRequired: window.changePasswordMode === true
				},
				ConfirmPassword: {
					dataValueType: Terrasoft.DataValueType.TEXT,
					isRequired: window.changePasswordMode === true
				},
				Workspace: {
					dataValueType: Terrasoft.DataValueType.LOOKUP,
					isRequired: (window.workspaceCount > 1) && (!window.hideWorkspace)
				},
				Loading: {
					dataValueType: Terrasoft.DataValueType.BOOLEAN
				},
				AuthSettings: {
					dataValueType: Terrasoft.DataValueType.OBJECT
				},
				RememberMeCheckbox: {
					dataValueType: Terrasoft.DataValueType.BOOLEAN
				}
			},
			methods: {

				//region Fields: Private

				_loginResponseCode: {
					/** Authentication successful. */
					SUCCESS: 0,
					/** Authentication failed. */
					ERROR: 1,
					/** Authentication successful, password change recommended. */
					CHANGEPASSWORDINFO: 2,
					/** Authentication successful, user does not have a license to login but have permissions to manage licenses. */
					NEED_GRANT_LICENSE: 3,
					/** Authentication successful, user does not have a license to login and does not have permissions to manage licenses. */
					NO_LICENSE: 4,
					PASSWORDEXPIRED: 5
				},

				_loginErrorCode: {
					GENERAL: "0",
					NOT_ALLOWED_IP_ADDRESS: "4",
					PASSWORD_EXPIRED: "5",
					CHANGE_PASSWORD: "8",
					INVALID_USER_TIMEZONE: "10",
					NOT_ALLOWED_EMAIL: "12",
					EMPTY_EMAIL: "14",
					NOT_ALLOWED_EMAIL_COMMUNICATION_OPTIONS: "15",
					NOT_ALLOWED_MOBILE_ONLY_WEB_LOGIN: "16",
					NOT_ALLOWED_INTEGRATION_USER_WEB_LOGIN: "17",
				},

				_exceptionControlFlow: {
					"System.Security.SecurityException": function(response, responseData) {
						this.showInfoMessage(responseData.Message);
					},
					"Terrasoft.Authentication.TOTP.Exceptions.TotpIsNotEnabledException": function(response, responseData) {
						this._redirectToOnBoarding(response, responseData);
					},
					"Terrasoft.Authentication.TwoFactor.Exceptions.StartAuthFlowException": function(response, responseData) {
						this._showTwoFactor();
						this.showInfoMessage(responseData.Message);
					},
					"Terrasoft.Authentication.Contract.Exceptions.TwoFactorCodeRequiredException": function(response, responseData) {
						this._showTwoFactor();
					}
				},

				//endregion

				//region Methods: Private

				_redirectToReturnUrl: function(responseData, response, windowLocation) {
					windowLocation.replace(loginModelUtils.redirectToReturnUrl(responseData, response, windowLocation));
				},

				_redirectWithPasswordChangePrompt: function(responseData) {
					Terrasoft.utils.showMessage({
						caption: responseData.Message,
						buttons: ["yes", "no"],
						defaultButton: 0,
						style: Terrasoft.MessageBoxStyles.BLUE,
						handler: function(buttonCode) {
							if (buttonCode === "no") {
								this._redirectToRequestedLocation(responseData);
							} else {
								this._redirectToPasswordChangeUrl(responseData);
							}
						}.bind(this)
					});
				},

				_redirectToRequestedLocation: function(responseData) {
					const hash = window.location.hash;
					window.location.replace(responseData.RedirectUrl + loginModelUtils.baseViewModulePath + hash);
				},

				_redirectToPasswordChangeUrl: function(responseData) {
					window.location.replace(responseData.PasswordChangeUrl);
				},

				_processLoginError: function(response) {
					this.hideLoginMask();
					if (response.status === 401) {
						this.showInfoMessage(Terrasoft.Resources.LoginPage.WrongLoginPassword);
					} else if (response.status === 403) {
						this._clearPasswordsInModel();
						this.showInfoMessage(Terrasoft.Resources.LoginPage.ChangePasswordAccessDenied);
					} else {
						throw new Terrasoft.UnauthorizedException({
							message: response.responseText
						});
					}
				},

				_clearPasswordsInModel: function() {
					const model = _module.model;
					model.set("Password", "");
					model.set("NewPassword", "");
					model.set("ConfirmPassword", "");
				},

				_initParametersFromQueryString: function() {
					const location = loginModelUtils.getWindowQueryString(window.location);
					const properies = Ext.Object.fromQueryString(location);
					const errorCode = properies && properies.ErrorCode;
					this._setErrorProperties(errorCode);
				},

				_setErrorProperties: function(errorCode) {
					loginModelUtils.setAuthenticationException(errorCode);
					const changePasswordMode = this._getIsChangePasswordError(errorCode);
					window.changePasswordMode = changePasswordMode || window.changePasswordMode;
				},

				_getIsChangePasswordError: function(errorCode) {
					const loginErrorCode = this._loginErrorCode;
					return errorCode === loginErrorCode.PASSWORD_EXPIRED ||
						errorCode === loginErrorCode.CHANGE_PASSWORD;
				},

				_showLicMessage: function(caption, showRedirectButton, handler) {
					const loginResources = Terrasoft.Resources.LoginPage;
					const buttons = [{
						className: "Terrasoft.Button",
						returnCode: "close",
						caption: loginResources.CloseLicMessage
					}];
					if (showRedirectButton) {
						buttons.unshift({
							className: "Terrasoft.Button",
							returnCode: "redirect",
							caption: loginResources.LicenseManagerLinkCaption
						});
					}
					Terrasoft.showMessage({
						caption: caption,
						scope: this,
						handler: handler,
						style: Terrasoft.MessageBoxStyles.BLUE,
						buttons: buttons,
						defaultButton: 0
					});
				},

				_createLicenseManagerRedirectHandler: function(redirectUrl) {
					return function(result) {
						if (result === "redirect") {
							window.open((redirectUrl || "") + _licenseManagerUrl, "_self");
						}
					};
				},

				//endregion

				getWorkspaceList: function(filter, list) {
					list.clear();
					list.loadAll(window.workspaceList);
				},

				doLogin: function(urlValue, jsonDataValue) {
					this.showLoginMask();
					const options = {
						url: urlValue,
						headers: {
							"Content-Type": "application/json",
							"Accept": "application/json",
							"Referer-Custom" : window.location.href,
						},
						scope: this,
						callback: this.loginRequestCallback,
						jsonData: jsonDataValue,
						securitySensitiveFields: ["UserPassword"],
						forceCallbackOn2FAFail: true
					};
					if (window.loginTimeout) {
						options.timeout = window.loginTimeout;
					}
					Terrasoft.AjaxProvider.request(options);
				},

				showLoginMask: function() {
					this.set("Loading", true);
				},

				hideLoginMask: function() {
					this.set("Loading", false);
				},

				getWorkspaceName: function() {
					let workspace = _module.model.get("Workspace");
					if (workspace) {
						workspace = workspace.value;
					}
					return workspace;
				},

				showInfoMessage: function(captionValue) {
					Terrasoft.utils.showMessage({
						caption: captionValue,
						buttons: ["ok"],
						defaultButton: 0,
						style: Terrasoft.MessageBoxStyles.BLUE
					});
				},

				onLoginButtonClick: function(skipValidation) {
					this.actualizeLoginData();
					if (!skipValidation && !this.validate()) {
						return;
					}
					let authToken = {
						UserName: _module.model.get("Login"),
						UserPassword: _module.model.get("Password"),
						WorkspaceName: this.getWorkspaceName(),
						TimeZoneOffset: new Date().getTimezoneOffset()
					};
					if (Terrasoft.totpAuthProviderName) {
						authToken.ProviderName = Terrasoft.totpAuthProviderName;
					}
					authToken.ClaimList = this.getAdditionalClaims();
					if (Terrasoft.enable2FA) {
						const additional2FaClaims = this.getAdditional2FaClaims();
						authToken.ClaimList = authToken.ClaimList.concat(additional2FaClaims);
					}
					this.doLogin(Terrasoft.loginUrl, authToken);
				},

				getAdditionalClaims: function() {
					const userClaims = [];
					if (!Terrasoft.UseRememberMe) {
						return userClaims; 
					}
					const checkboxClaim = {"Key": "rememberMeCheckbox", "Value": ""};
					checkboxClaim.Value = _module.model.get("RememberMeCheckbox") || false;
					userClaims.push(checkboxClaim);
					return userClaims;
				},

				getAdditional2FaClaims: function() {
					const userClaims = [];
					if (Terrasoft.enabled2FAFlow && !Terrasoft.firstFactorFlowPassed) {
						return userClaims;
					}
					const totpUserClaim = { "Key": "token", "Value": "" };
					let totpCodeValue = _module.model.get("TOTPCode");
					if (totpCodeValue) {
						totpUserClaim.Value = totpCodeValue;
					}
					userClaims.push(totpUserClaim);
					return userClaims;
				},

				onRemindPasswordClick: function() {
					if (!Terrasoft.isConfiguredPasswordRecovery
							&& Boolean(Terrasoft.usePasswordRecoveryForInternalUsers)) {
						this.showInfoMessage(Terrasoft.Resources.LoginPage.PasswordRecoveryIsNotConfigured);
						return;
					}
					let url = this._getBaseUrl();
					const useNewPasswordRecovery = Boolean(Terrasoft.usePasswordRecoveryForInternalUsers);
					if (useNewPasswordRecovery) {
						url += "/Login/app/#/begin-recovery?returnPage=NuiLogin";
					} else {
						url += "/Login/TotpRecoverPassword.aspx";
					}
					window.location = url;
				},

				onConfirmCheckboxClick: function () {
					if (_module.model.get("RememberMeCheckbox")) {
						let message = Terrasoft.Resources.LoginPage.RememberMeConfirmDialogBox;
						Terrasoft.utils.showMessage({
							caption: message,
							useHtmlContent: true,
							buttons: ['ok', 'cancel'],
							defaultButton: 0,
							style: Terrasoft.MessageBoxStyles.BLUE,
							handler: function (buttonCode) {
								if (buttonCode === "cancel") {
									_module.model.set("RememberMeCheckbox", false);
								}
							}.bind(this)
						});
					}
				},

				onChangePasswordLoginButtonClick: function() {
					if (!this.validate()) {
						return;
					}
					const model = _module.model;
					const password = model.get("Password");
					const newPassword = model.get("NewPassword");
					const confirmPassword = model.get("ConfirmPassword");
					if (password === newPassword) {
						this.showInfoMessage(Terrasoft.Resources.LoginPage.WrongNewPassword);
						return;
					}
					if (newPassword !== confirmPassword) {
						this.showInfoMessage(Terrasoft.Resources.LoginPage.WrongConfirmPassword);
						return;
					}
					let authToken = {
						UserName: model.get("Login"),
						UserPassword: password,
						WorkspaceName: this.getWorkspaceName(),
						TimeZoneOffset: new Date().getTimezoneOffset(),
						NewUserPassword: newPassword,
						ConfirmUserPassword: confirmPassword
					};
					if (Terrasoft.totpAuthProviderName) {
						authToken.ProviderName = Terrasoft.totpAuthProviderName;
					}
					if (Terrasoft.enable2FA) {
						authToken.ClaimList = this.getAdditionalClaims();
					}
					this.doLogin(Terrasoft.changePasswordUrl, authToken);
				},

				onKeyUp: function(e) {
					if (e && e.keyCode === e.ENTER) {
						if (window.changePasswordMode === true) {
							this.onChangePasswordLoginButtonClick();
						} else {
							this.onLoginButtonClick();
						}
					}
				},

				deleteDuplicateQueryStrings: function(url) {
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
				},

				loginRequestCallback: function(request, success, response) {
					if (success && response.status === 200) {
						const responseData = Ext.decode(response.responseText);
						switch (responseData.Code) {
							case this._loginResponseCode.SUCCESS:
							case this._loginResponseCode.PASSWORDEXPIRED:
								if (Terrasoft.enable2FA &&
									Terrasoft.enabled2FAFlow &&
									!Terrasoft.firstFactorFlowPassed &&
									!Terrasoft.useSeparatedPage2FA) {
										this._showTwoFactor();
									return;
								}
								return this._redirectToReturnUrl(responseData, response, window.location);
							case this._loginResponseCode.CHANGEPASSWORDINFO:
								return this._redirectWithPasswordChangePrompt(responseData);
							case this._loginResponseCode.NEED_GRANT_LICENSE:
								this._showLicMessage(responseData.Message, true,
									this._createLicenseManagerRedirectHandler(responseData.RedirectUrl));
								break;
							case this._loginResponseCode.NO_LICENSE:
								this._showLicMessage(responseData.Message);
								break;
							case this._loginResponseCode.ERROR:
								const processingErrorFunction = this._exceptionControlFlow[responseData.Exception.Type];
								if (Ext.isFunction(processingErrorFunction)) {
									var result = processingErrorFunction.call(this, response, responseData, request);
									if (result) {
										return;
									}
									break;
								}
							default:
								this.showInfoMessage(responseData.Message || Terrasoft.Resources.LoginPage.AuthFailed);
						}
					}
					this._processLoginError(response);
				},
				
				_getBaseUrl: function() {
					return Terrasoft.loaderBaseUrl.endsWith("/") ? Terrasoft.loaderBaseUrl.slice(0, -1) : Terrasoft.loaderBaseUrl;
				},

				_redirectToOnBoarding: function(response, responseData) {
					let baseUrl = loginModelUtils.getLocationFromHeaders(response);
					baseUrl = baseUrl.length ? baseUrl : this._getBaseUrl();
					const params = new URLSearchParams(window.location.search);
					window.location.replace(baseUrl + _onBoardingUrl + "?" + params.toString());
				},

				_showTwoFactor: function() {
					Terrasoft.firstFactorFlowPassed = true;
					if (!Terrasoft.useSeparatedPage2FA) {
						_module.view.setTotpEditVisible(true);
					}
					this.hideLoginMask();
				},

				init: function() {
					this._initParametersFromQueryString();
					const licManagerException = Terrasoft.licManagerException;
					if (licManagerException) {
						this._showLicMessage(licManagerException.message, !Ext.isEmpty(licManagerException.licManagerUrl),
							this.redirectToLicManager);
					}
					loginModelUtils.tryShowAuthenticationErrorMsg();
				},

				redirectToLicManager: function(result) {
					if (result === "redirect") {
						window.location.replace(Terrasoft.licManagerException.licManagerUrl);
					}
				},

				onNtlmLoginClick: function() {
					this.showLoginMask();
					if (Terrasoft.useDomainLogin) {
						let domainLoginUrl = "/ServiceModel/AuthService.svc/DomainLogin"
						if (Terrasoft.UseRememberMe) {
							let rememberMeCheckboxValue = _module.model.get("RememberMeCheckbox") || false;
							domainLoginUrl = domainLoginUrl + "?" + "rememberMe=" + rememberMeCheckboxValue;
						}
						this.doLogin(domainLoginUrl, {});
					} else {
						let url = Terrasoft.ntlmLoginUrl;
						if (window.location.hash) {
							url = url + window.location.hash;
						}
						if (Terrasoft.UseRememberMe) {
							let rememberMeCheckboxValue = _module.model.get("RememberMeCheckbox") || false;
							url = url + "&" + "rememberMe=" + rememberMeCheckboxValue;
						}
						window.location = url;
					}
				},

				/**
				* Goes to SSO identity provider login page.
				*/
				onSsoLoginClick: function(partnerIdp) {
					const provider = Terrasoft.find(window.SsoIdentityProviders, (item) => {
						return item.id === partnerIdp;
					});
					const startSsoClientProvider = Terrasoft[provider.startSsoClientProvider];
					if (!startSsoClientProvider) {
						console.error(`Start SSO provider with name ${provider.startSsoClientProvider} not found!`);
						return;
					}
					provider.userType = Terrasoft.UserType.GENERAL;
					startSsoClientProvider.startSso(provider);
				},

				onOpenIdLoginClick: function () {
					Terrasoft.OpenIdStartSsoClientProvider.startSso();
				},

				actualizeLoginData: function() {
					const reloadModelValue = function(componentId) {
						const el = Ext.getCmp(componentId).getEl();
						el.focus();
						el.blur();
					};
					reloadModelValue("loginEdit");
					reloadModelValue("passwordEdit");
				},

				onDocumentKeyDown: function(e) {
					if (e && e.keyCode === e.ENTER) {
						if (e.ctrlKey) {
							this.actualizeLoginData();
							const model = _module.model;
							const skipValidation = model && !model.get("Login") && !model.get("Password");
							this.onLoginButtonClick(skipValidation);
						} else if (e.altKey && window.isNtlmLoginVisible) {
							this.onNtlmLoginClick();
						}
					}
				},

				onSendTextCodeClick: function() {
					Terrasoft.TwoFactorAuthUtils.sendTextCode(_module.model.get("Login"), _module.model.get("Password"),
						function(request, success, response) {
							const responseData = JSON.parse(response.responseText);
							if (responseData.success) {
								this.set("ConfirmationSent", true);
							}
							this.showInfoMessage(responseData.message);
						}, this);
				},

				getSendCodeCaption: function() {
					const authSettings = this.get("AuthSettings") || {};
					const confirmationSent = this.get("ConfirmationSent");
					return authSettings.primaryTwoFactorAuthFlowCode ===
							_textCodeTwoFactorAuthFlowCode && !window.changePasswordMode || confirmationSent
						? Terrasoft.Resources.TwoFactorTextCode.ResendCode
						: Terrasoft.Resources.TwoFactorTextCode.SendCode;
				},

				getIsSendCodeLinkVisible: function() {
					const authSettings = this.get("AuthSettings", {}) || {};
					return Terrasoft.enabled2FAFlow && authSettings.enabledTwoFactorAuthFlows?.filter(
						x => x.code === _textCodeTwoFactorAuthFlowCode).length > 0;
				}
			}
		});
	};

	return {
		renderTo: Ext.getBody(),
		init: init,
		render: function(renderTo) {
			Terrasoft.TwoFactorAuthUtils.getAuthenticationSettings(function(authSettings) {
				if (Terrasoft.SsoUtils.getNeedShowSsoLogin()) {
					Terrasoft.SsoUtils.initiateSsoLogin();
					return;
				}
				loginModelUtils.checkOpenIdUnauthorized();
				prepareModel();
				_module.model.init();
				renderView(renderTo);
				_module.view.bind(_module.model);
				const userName = Ext.String.htmlDecode(window.userName);
				if (userName && Terrasoft.canStoreUserNameInCookie && Terrasoft.UseRememberMe) {
					_module.model.set("RememberMeCheckbox", true);
				}
				if (userName && 
						(Terrasoft.canStoreUserNameInCookie && Terrasoft.UseRememberMe || !Terrasoft.UseRememberMe)) {
					_module.model.set("Login", userName);
					if (window.isDebug === true) {
						_module.model.set("Password", userName);
					}
				}
				_module.model.set("AuthSettings", authSettings);
				if (window.workspaceCount <= 1 || window.hideWorkspace) {
					_module.view.hideWorkspaceEdit();
				} else {
					const workspace = window.workspace;
					if (workspace) {
						const modelValue = {
							value: workspace,
							displayValue: workspace
						};
						_module.model.set("Workspace", modelValue);
					}
				}
				if (window.changePasswordMode === true) {
					_module.view.showChangePasswordMode();
				} else {
					_module.view.showLoginMode();
				}
				if (loginViewUtils.checkIsBrowserUnsupported()) {
					_module.view.showUnsupportedBrowser();
				}
				const doc = Ext.getDoc();
				doc.on("keydown", _module.model.onDocumentKeyDown, _module.model);
			});
		}
	};
});
