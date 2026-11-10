define(["ext-base", "terrasoft", "login-view-utils", "login-model-utils", "css-ltr!two-fa-styles", "mf!two-fa"],
function (Ext, Terrasoft, loginUtils, loginModelUtils) {

	const module = {};

	const init = function() {
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
			selectors: {wrapEl: "#importantLinks"}
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
			const contInfoTable = loginUtils.createTableContainer("supportInfoTable");
			let index = 0;
			Terrasoft.each(window.supportInfo, function(elem) {
				const rowInfo = loginUtils.createRowContainer("infoRow_" + index);
				contInfoTable.items.add(rowInfo);
				let label = loginUtils.createLabel(elem.name);
				label.classes.labelClass.push(loginSubcellSupportInfoLabelClass);
				let supportInfoCell = loginUtils.createCellContainer("supportNameCell_" + index);
				supportInfoCell.classes.wrapClassName.push(loginSubcellSupportClass);
				supportInfoCell.items.add(label);
				rowInfo.items.add(supportInfoCell);

				label = loginUtils.createLabel(elem.tel);
				label.classes.labelClass.push(loginSubcellSupportInfoTelClass);
				supportInfoCell = loginUtils.createCellContainer("supportTelCell_" + index);
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
			contSupportData = loginUtils.createTableContainer("supportTable");
			let supportRow = loginUtils.createRowContainer("supportLogoRow");
			contSupportData.items.add(supportRow);
			let supportCell = loginUtils.createCellContainer("supportLogoCell");
			supportRow.items.add(supportCell);
			supportCell.items.add(labelSupport);
			supportRow = loginUtils.createRowContainer("supportDataRow");
			contSupportData.items.add(supportRow);
			supportCell = loginUtils.createCellContainer("supportNameCell");
			supportRow.items.add(supportCell);
			supportCell.items.add(contInfoTable);
		}
		if (window.importantLinks.length > 0) {
			contImportantBaseLinks = loginUtils.createTableContainer("linksBaseTable");
			let linksRow = loginUtils.createRowContainer("linksLogoRow");
			contImportantBaseLinks.items.add(linksRow);
			let linksCell = loginUtils.createCellContainer("linksLogoCell");
			linksRow.items.add(linksCell);
			const labelLinks = Ext.create("Terrasoft.Label", {
				caption: window.importantLinksCaption,
				classes: {
					labelClass: [loginInfoLabelHeaderClass]
				}
			});
			linksCell.items.add(labelLinks);
			linksRow = loginUtils.createRowContainer("linksDataRow");
			contImportantBaseLinks.items.add(linksRow);
			const itemsConfig = [];
			Terrasoft.each(window.importantLinks, function(elem) {
				itemsConfig.push({
					caption: elem.name,
					href: elem.link
				});
			}, this);
			const links = createImportantLinks(itemsConfig);
			linksCell = loginUtils.createCellContainer("supportLogoCell");
			linksCell.items.add(links);
			linksRow.items.add(linksCell);
		}
		if (contSupportData != null || contImportantBaseLinks != null) {
			const contExtendInfo = loginUtils.createCellContainer("extendInfoContainer");
			if (contSupportData != null) {
				const suppRowInfo = loginUtils.createRowContainer("supportRowInfo");
				suppRowInfo.items.add(contSupportData);
				contExtendInfo.items.add(suppRowInfo);
				const suppRowInfoEmpty = loginUtils.createRowContainer("supportRowInfoEmpty");
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

	const renderView = function(renderTo) {
		// Classnames for elements
		const headClass = "login-label-logo";
		const smallCaptionClass = "login-label-smallCaption";
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
		const passwordHelpContainerClass = "password-help-container";
		const containerRememberClass = "login-container-remember";
		const loginRememberContainerWithRememberLink = "login-container-with-remember-link";
		const containerFooterClass = "login-container-footer";
		const containerRememberClassInside = "login-container-remember-inside";
		const loginBorderRightClass = "login-border-right";
		const loginBorderLeftClass = "login-border-left";
		const loginInsideContainerClass = "login-inside-container";
		const loginOutsideContainerClass = "login-outside-container";
		let logoImageUrl = Terrasoft.useConstLoginImageUrl
			? "/Login/logo.svg"
			: window.sspLoginImageUrl;
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
		const selfRegistrationLinkVisible = Terrasoft.showSelfRegistrationLink;
		const loginHelp = Ext.create("Terrasoft.Label", {
			caption: Terrasoft.Resources.LoginPage.Register,
			classes: {
				labelClass: [smallCaptionClass, blueColorClass, loginHelpClass]
			},
			click: {bindTo: "onRegisterClick"},
			visible: selfRegistrationLinkVisible
		});
		const passwordHelp = Ext.create("Terrasoft.Label", {
			caption: Terrasoft.Resources.LoginPage.ForgetPassword,
			classes: {
				labelClass: [smallCaptionClass, blueColorClass, passwordHelpClass]
			},
			click: {bindTo: "onRemindPasswordClick"}
		});
		const userManagement = Ext.create("Terrasoft.Container", {
			id: "userManagementContainer",
			selectors: {
				wrapEl: "#userManagementContainer"
			},
			classes: {
				wrapClassName: [userManagementClass]
			},
			items: [loginHelp]
		});
		const ssoLinks = Terrasoft.SsoUtils.getSsoLoginLinks();
		const ssoLinksContainer = Ext.create("Terrasoft.Container", {
			id: "ssoLinksContainer",
			selectors: {
				wrapEl: "#ssoLinksContainer"
			},
			classes: {
				wrapClassName: [userManagementClass]
			},
			items: ssoLinks
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
			markerValue: "btnLogin"
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
		const contRemember = Ext.create("Terrasoft.Container", {
			id: "loginRememberContainer",
			selectors: {
				wrapEl: "#loginRememberContainer"
			},
			classes: {
				wrapClassName: [containerRememberClass]
			},
			items: [btnLogin, btnChangePasswordLogin, contRememberInside]
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
		const unsupportedBrowser = loginUtils.createUnsupportedBrowserContainer();
		const contLogin = module.view = Ext.create("Terrasoft.Container", {
			id: "loginContainer",
			selectors: {
				wrapEl: "#loginContainer"
			},
			items: [loginCaption, loginEdit, passwordCaption, passwordEdit,
				newPasswordCaption, newPasswordEdit, confirmPasswordCaption, confirmPasswordEdit,
				workspaceCaption, workspaceEdit, contRemember, ssoLinksContainer, userManagement, contFooter,
				unsupportedBrowser
			]
		});
		if (Boolean(Terrasoft.useLoginAppForPortalPasswordRecovery) || selfRegistrationLinkVisible) {
			const passwordEditIndex = contLogin.items.indexOf(passwordEdit);
			contLogin.items.insert(passwordEditIndex + 1, passwordHelp.id, passwordHelp);
		} else {
			const passwordHelpContainer = Ext.create("Terrasoft.Container", {
				id: "passwordHelpContainer",
				selectors: {
					wrapEl: "#passwordHelpContainer"
				},
				classes: {
					wrapClassName: [passwordHelpContainerClass]
				},
				items: [passwordHelp]
			});
			contRemember.classes.wrapClassName.push(loginRememberContainerWithRememberLink);
			contRemember.items.add(passwordHelpContainer);
		}
		const contCellLogo = loginUtils.createCellContainer("cellLogoContainer");
		contCellLogo.items.add(logo);
		const contRowLogo = loginUtils.createRowContainer("rowLogoContainer");
		contRowLogo.items.add(contCellLogo);
		const contCellLogin = loginUtils.createCellContainer("cellLoginContainer");
		contCellLogin.items.add(contLogin);
		const contRowMain = loginUtils.createRowContainer("rowMainContainer");
		contRowMain.items.add(contCellLogin);
		const infoContainer = renderInfoView();
		if (infoContainer != null) {
			let cellLine = loginUtils.createCellContainer("cellLineRight");
			cellLine.classes.wrapClassName.push(loginBorderRightClass);
			contRowMain.items.add(cellLine);
			cellLine = loginUtils.createCellContainer("cellLineLeft");
			cellLine.classes.wrapClassName.push(loginBorderLeftClass);
			contRowMain.items.add(cellLine);
			const contCellInfo = loginUtils.createCellContainer("cellInfoContainer");
			contCellInfo.items.add(infoContainer);
			contRowMain.items.add(contCellInfo);
		}
		const contTable = loginUtils.createTableContainer("tableContainer");
		contTable.items.add(contRowLogo);
		contTable.items.add(contRowMain);
		const contInside = module.view = Ext.create("Terrasoft.Container", {
			id: "insideContainer",
			selectors: {
				wrapEl: "#insideContainer"
			},
			classes: {
				wrapClassName: [loginInsideContainerClass]
			},
			items: [contTable]
		});
		const view = module.view = Ext.create("Terrasoft.Container", {
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
		if (Boolean(Terrasoft.useLoginAppForPortalPasswordRecovery)) {
			passwordHelp.setVisible(true);
		}
		help.setVisible(false);
		userManagement.setVisible(true);
		contRememberInside.setVisible(false);
		view.hideWorkspaceEdit = function() {
			workspaceEdit.setVisible(false);
			workspaceCaption.setVisible(false);
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
		};
		view.showChangePasswordMode = function() {
			newPasswordCaption.setVisible(true);
			newPasswordEdit.setVisible(true);
			confirmPasswordCaption.setVisible(true);
			confirmPasswordEdit.setVisible(true);
			btnChangePasswordLogin.setVisible(true);
			btnLogin.setVisible(false);
		};
		view.showUnsupportedBrowser = function() {
			unsupportedBrowser.setVisible(true);
		}
		if (Terrasoft.useScriptsForAnonymousPage) {
			version.setVisible(false);
		}
	};

	const prepareModel = function() {
		module.model = Ext.create("Terrasoft.BaseViewModel", {
			values: {
				productVersion: Terrasoft.Resources.LoginPage.Version + " " + window.productVersion,
				workspaceList: Ext.create("Terrasoft.Collection")
			},
			columns: {
				Login: {
					dataValueType: Terrasoft.DataValueType.TEXT,
					isRequired: true
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
					isRequired: (window.workspaceCount > 1) && (!window.useDefaultWorkspace)
				},
				RememberMeCheckbox: {
					dataValueType: Terrasoft.DataValueType.BOOLEAN
				}
			},
			methods: {
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

				_exceptionControlFlow: {
					"Terrasoft.Authentication.TwoFactor.Exceptions.SecondFactorCodeRequiredException": function (response, responseData, request) {
						window.TwoFactorDialogService.resendRequestWithTwoFactor(request, "SspLogin", true).then(response => {
							if (response && response.resultCode === 1) {
								responseData = Ext.decode(response.response.responseText);
								return window.location.replace(loginModelUtils.redirectToReturnUrl(responseData, response.response, window.location));
							}
						});
						return true;
					}
				},

				getWorkspaceList: function (filter, list) {
					list.clear();
					list.loadAll(window.workspaceList);
				},

				doLogin: function(urlValue, jsonDataValue, callback) {
					const options = {
						url: urlValue,
						headers: {
							"Content-Type": "application/json",
							"Accept": "application/json"
						},
						scope: this,
						callback: callback || this.loginRequestCallback,
						jsonData: jsonDataValue,
						securitySensitiveFields: ["UserPassword"]
					};
					if (window.loginTimeout) {
						options.timeout = window.loginTimeout;
					}
					Terrasoft.AjaxProvider.request(options);
				},

				getWorkspaceName: function() {
					let workspace = module.model.get("Workspace");
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
						Terrasoft.Logger.error(`Start SSO provider with name ${provider.startSsoClientProvider} not found!`);
						return;
					}
					provider.userType = Terrasoft.UserType.SSP;
					startSsoClientProvider.startSso(provider);
				},

				onLoginButtonClick: function() {
					this.actualizeLoginData();
					if (!this.validate()) {
						return;
					}
					this.doLogin(Terrasoft.loginUrl, {
						UserName: module.model.get("Login"),
						UserPassword: module.model.get("Password"),
						WorkspaceName: this.getWorkspaceName(),
						TimeZoneOffset: new Date().getTimezoneOffset(),
						ClaimList: this.getAdditionalClaims(),
					});
				},

				getAdditionalClaims: function() {
					const userClaims = [];
					if (!Terrasoft.UseRememberMe) {
						return userClaims;
					}
					const checkboxClaim = {"Key": "rememberMeCheckbox", "Value": ""};
					checkboxClaim.Value = module.model.get("RememberMeCheckbox") || false;
					userClaims.push(checkboxClaim);
					return userClaims;
				},

				onConfirmCheckboxClick: function () {
					if (module.model.get("RememberMeCheckbox")) {
						let message = Terrasoft.Resources.LoginPage.RememberMeConfirmDialogBox;
						Terrasoft.utils.showMessage({
							caption: message,
							useHtmlContent: true,
							buttons: ['ok', 'cancel'],
							defaultButton: 0,
							style: Terrasoft.MessageBoxStyles.BLUE,
							handler: function (buttonCode) {
								if (buttonCode === 'cancel') {
									module.model.set("RememberMeCheckbox", false);
								}
							}.bind(this)
						});
					}
				},

				onChangePasswordLoginButtonClick: function() {
					if (!this.validate()) {
						return;
					}
					const model = module.model;
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
					this.doLogin(Terrasoft.changePasswordUrl, {
						UserName: model.get("Login"),
						UserPassword: password,
						WorkspaceName: this.getWorkspaceName(),
						TimeZoneOffset: new Date().getTimezoneOffset(),
						NewUserPassword: newPassword,
						ConfirmUserPassword: confirmPassword
					});
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

				loginRequestCallback: function(request, success, response) {
					if (success && response.status === 200) {
						const responseData = Ext.decode(response.responseText);
						if (responseData.Code != null) {
							switch (responseData.Code) {
								case this._loginResponseCode.SUCCESS:
									var location = response.getAllResponseHeaders().location || "";
									var hash = window.location.hash;
									window.location.replace(loginModelUtils.redirectToReturnUrl(responseData, response, window.location));
									break;
								case this._loginResponseCode.CHANGEPASSWORDINFO:
									Terrasoft.utils.showMessage({
										caption: responseData.Message,
										buttons: ["yes", "no"],
										defaultButton: 0,
										style: Terrasoft.MessageBoxStyles.BLUE,
										handler: function (buttonCode) {
											if (buttonCode === "no") {
												const hash = window.location.hash;
												window.location.replace(responseData.RedirectUrl + viewModuleAddress + hash);
											} else {
												window.location.replace(responseData.PasswordChangeUrl);
											}
										}
									});
									break;
								case this._loginResponseCode.ERROR:
									if (Terrasoft.useSeparatedPage2FA) {
										const processingErrorFunction = this._exceptionControlFlow[responseData.Exception.Type];
										if (Ext.isFunction(processingErrorFunction)) {
											var result = processingErrorFunction.call(this, response, responseData, request);
											if (result) {
												return;
											}
											break;
										}
									}
								default:
									this.showInfoMessage(responseData.Message);
							}
						} else {
							this.showInfoMessage(Terrasoft.Resources.LoginPage.AuthFailed);
						}
					} else if (response.status === 401) {
						this.showInfoMessage(Terrasoft.Resources.LoginPage.WrongLoginPassword);
					} else if (response.status === 403) {
						const model = module.model;
						model.set("Password", "");
						model.set("NewPassword", "");
						model.set("ConfirmPassword", "");
						this.showInfoMessage(Terrasoft.Resources.LoginPage.ChangePasswordAccessDenied);
					} else {
						throw new Terrasoft.UnauthorizedException({
							message: response.responseText
						});
					}
				},

				getQueryParameters: function() {
					const queries = location.search.match(/\?(.*)=(.{36})/);
					const requestParameters = {};
					switch (queries[1]) {
						case "PasswordRecoveryId":
							requestParameters.method = "PasswordRecovery";
							break;
						case "RegistrationId":
							requestParameters.method = "UserRegistration";
							break;
						default:
							break;
					}
					requestParameters.id = queries[2];
					return requestParameters;
				},

				handleQuery: function() {
					const params = this.getQueryParameters();
					this.doLogin("/SSPLogin/" + params.method, Terrasoft.encode(params.id),
						function(request, success, response) {
							const responseData = Ext.decode(response.responseText);
							if (responseData.Code === 1) {
								Terrasoft.authenticationException = {
									message: responseData.Message
								};
							}
							if (responseData.RedirectUrl) {
								window.location.replace(responseData.RedirectUrl);
								return;
							}
							this.showMessages();
						}.bind(this));
				},

				init: function() {
					if (location.search.length > 0 && Terrasoft.useInitHandleQuery) {
						this.handleQuery();
					} else {
						this.showMessages();
					}
				},

				showMessages: function() {
					const licManagerException = Terrasoft.licManagerException;
					if (licManagerException) {
						const loginResources = Terrasoft.Resources.LoginPage;
						const buttons = [];
						if (!Ext.isEmpty(licManagerException.licManagerUrl)) {
							buttons.push({
								className: "Terrasoft.Button",
								returnCode: "redirect",
								caption: loginResources.LicenseManagerLinkCaption
							});
						}
						buttons.push({
							className: "Terrasoft.Button",
							returnCode: "close",
							caption: loginResources.CloseLicMessage
						});
						Terrasoft.showMessage({
							caption: licManagerException.message,
							scope: this,
							handler: this.redirectToLicManager,
							style: Terrasoft.MessageBoxStyles.BLUE,
							buttons: buttons,
							defaultButton: 0
						});
					}

					const authenticationException = Terrasoft.authenticationException;
					if (authenticationException) {
						Terrasoft.showMessage({
							caption: authenticationException.message,
							style: Terrasoft.MessageBoxStyles.BLUE,
							buttons: ["ok"],
							defaultButton: 0
						});
					}
				},

				redirectToLicManager: function(result) {
					if (result === "redirect") {
						window.location.replace(Terrasoft.licManagerException.licManagerUrl);
					}
				},

				getHostUrl: function() {
					return Terrasoft.useWorkspaceBaseUrlAsHostUrl
						? Terrasoft.workspaceBaseUrl :this._getBaseUrl();
				},

				_getBaseUrl: function() {
					return Terrasoft.loaderBaseUrl.endsWith("/") ? Terrasoft.loaderBaseUrl.slice(0, -1) : Terrasoft.loaderBaseUrl;
				},

				onRegisterClick: function() {
					const url = this.getHostUrl();
					window.location = url + "/0/Nui/UserManagement.aspx?action=register";
				},

				onRemindPasswordClick: function() {
					if (!Terrasoft.isConfiguredPasswordRecovery 
							&& Boolean(Terrasoft.useLoginAppForPortalPasswordRecovery)) {
						this.showInfoMessage(Terrasoft.Resources.LoginPage.PasswordRecoveryIsNotConfigured);
						return;
					}
					let url = this.getHostUrl();
					const useNewPasswordRecovery = Boolean(Terrasoft.useLoginAppForPortalPasswordRecovery);
					if (useNewPasswordRecovery) {
						url += "/Login/app/#/begin-recovery?returnPage=SspLogin";
					} else {
						url += "/0/Nui/UserManagement.aspx?action=remindPassword";
					}
					window.location = url;
				},

				actualizeLoginData: function() {
					const reloadModelValue = function(componentId) {
						const el = Ext.getCmp(componentId).getEl();
						el.focus();
						el.blur();
					};
					reloadModelValue("loginEdit");
					reloadModelValue("passwordEdit");
				}

			}
		});
	};

	return {
		renderTo: Ext.getBody(),
		init: init,
		render: function(renderTo) {
			if (Terrasoft.SsoUtils.getNeedShowSsoLogin()) {
				Terrasoft.SsoUtils.initiateSsoLogin();
				return;
			}
			prepareModel();
			module.model.init();
			renderView(renderTo);
			module.view.bind(module.model);
			const userName = window.userName;
			if (userName && Terrasoft.canStoreUserNameInCookie && Terrasoft.UseRememberMe) {
				module.model.set("RememberMeCheckbox", true);
			}
			if (userName &&
				(Terrasoft.canStoreUserNameInCookie && Terrasoft.UseRememberMe || !Terrasoft.UseRememberMe)) {
				module.model.set("Login", userName);
				if (window.isDebug === true) {
					module.model.set("Password", userName);
				}
			}
			if (window.workspaceCount <= 1 || window.useDefaultWorkspace) {
				module.view.hideWorkspaceEdit();
			}
			if (window.changePasswordMode === true) {
				module.view.showChangePasswordMode();
			} else {
				module.view.showLoginMode();
			}
			if (loginUtils.checkIsBrowserUnsupported()) {
				module.view.showUnsupportedBrowser();
			}
		}
	};
});
