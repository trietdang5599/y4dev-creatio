define("ChangePasswordModuleSchema", ["ServiceHelper", "ChangePasswordModuleSchemaResources"],
	function(ServiceHelper, resources) {
		return {
			attributes: {
				"currentPassword": {
					"dataValueType": Terrasoft.DataValueType.TEXT,
					"type": Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"isRequired": true
				},
				"newPassword": {
					"dataValueType": Terrasoft.DataValueType.TEXT,
					"type": Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"isRequired": true
				},
				"newPasswordConfirmation": {
					"dataValueType": Terrasoft.DataValueType.TEXT,
					"type": Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"isRequired": true
				},
				"isLdap": {
					"dataValueType": Terrasoft.DataValueType.BOOLEAN,
					"type": Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"value": false
				},
				"IsTotpEnabled": {
					"dataValueType": Terrasoft.DataValueType.BOOLEAN,
					"type": Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN
				},
				"IsConfirmationCodeEnabled": {
					"dataValueType": Terrasoft.DataValueType.BOOLEAN,
					"type": Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN
				},
				"ConfirmationCode": {
					"dataValueType": Terrasoft.DataValueType.TEXT,
					"type": Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN
				},
				"TextCodeTwoFactorAuthFlowEnabled": {
					"dataValueType": Terrasoft.DataValueType.BOOLEAN,
					"type": Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN
				},
				"IsConfirmationCodeItemEnabled": {
					"dataValueType": Terrasoft.DataValueType.BOOLEAN,
					"type": Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN
				},
				"useSeparatedPage2FA": {
					"dataValueType": Terrasoft.DataValueType.BOOLEAN,
					"type": Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN
				}
			},
			diff: [
				{
					"operation": "insert",
					"name": "RelationshipControlGroup",
					"values": {
						"id": "top-container",
						"itemType": this.Terrasoft.ViewItemType.CONTAINER,
						"items": []
					},
					"propertyName": "items",
					"index": 0
				},
				{
					"operation": "insert",
					"name": "buttonsMenu",
					"parentName": "RelationshipControlGroup",
					"values": {
						"id": "buttonsMenu",
						"itemType": this.Terrasoft.ViewItemType.CONTAINER,
						"items": []
					},
					"propertyName": "items",
					"index": 0
				},
				{
					"operation": "insert",
					"name": "main-buttons-container",
					"parentName": "buttonsMenu",
					"values": {
						"id": "main-buttons-container",
						"itemType": this.Terrasoft.ViewItemType.CONTAINER,
						"items": []
					},
					"propertyName": "items",
					"index": 0
				},
				{
					"operation": "insert",
					"name": "change-password-button",
					"parentName": "main-buttons-container",
					"propertyName": "items",
					"values": {
						"id": "change-password-button",
						"itemType": Terrasoft.ViewItemType.BUTTON,
						"style": Terrasoft.controls.ButtonEnums.style.GREEN,
						"caption": {"bindTo": "Resources.Strings.saveButtonCaption"},
						"enabled": {
							"bindTo": "isLdap",
							"bindConfig": {
								"converter": function(value) {
									return !value;
								}
							}
						},
						"click": {"bindTo": "onChangePasswordClick"},
						"classes": {"textClass": ["change-password-save-button"]}
					}
				},
				{
					"operation": "insert",
					"name": "leftPanelContainer",
					"parentName": "RelationshipControlGroup",
					"values": {
						"id": "leftPanelContainer",
						"itemType": this.Terrasoft.ViewItemType.CONTAINER,
						"items": []
					},
					"propertyName": "items",
					"index": 1
				},
				{
					"operation": "insert",
					"parentName": "leftPanelContainer",
					"propertyName": "items",
					"name": "leftPanelGridLayout",
					"values": {
						"itemType": Terrasoft.ViewItemType.GRID_LAYOUT,
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "currentPassword",
					"parentName": "leftPanelGridLayout",
					"propertyName": "items",
					"values": {
						"visible": {"bindTo": "isNotRecoveryMode"},
						"value": {
							"bindTo": "currentPassword"
						},
						"layout": {
							"column": 0,
							"row": 1,
							"colSpan": 12
						},
						"controlConfig": {
							"protect": true
						},
						"labelConfig": {
							"caption":  {"bindTo": "Resources.Strings.currentPasswordCaption"}
						},
						"markerValue": "current-password",
						"wrapClass": ["search-edit"]
					}
				},
				{
					"operation": "insert",
					"name": "newPassword",
					"parentName": "leftPanelGridLayout",
					"propertyName": "items",
					"values": {
						"id": "new-password",
						"value": {
							"bindTo": "newPassword"
						},
						"controlConfig": {
							"protect": true
						},
						"layout": {
							"column": 0,
							"row": 2,
							"colSpan": 12
						},
						"labelConfig": {
							"caption":  {"bindTo": "Resources.Strings.newPasswordCaption"}
						},
						"keyup": {
							"bindTo": "onNewPasswordKeypress"
						},
						"markerValue": "new-password",
						"wrapClass": ["search-edit"]
					}
				},
				{
					"operation": "insert",
					"name": "newPasswordConfirmation",
					"parentName": "leftPanelGridLayout",
					"propertyName": "items",
					"values": {
						"id": "new-password-confirmation",
						"value": {
							"bindTo": "newPasswordConfirmation"
						},
						"controlConfig": {
							"protect": true
						},
						"layout": {
							"column": 0,
							"row": 3,
							"colSpan": 12
						},
						"labelConfig": {
							"caption":  {"bindTo": "Resources.Strings.newPasswordConfirmationCaption"}
						},
						"keyup": {
							"bindTo": "onNewPasswordConfirmationKeypress"
						},
						"markerValue": "new-password-confirmation",
						"wrapClass": ["search-edit"]
					}
				},
				{
					"operation": "insert",
					"name": "ConfirmationCode",
					"parentName": "leftPanelGridLayout",
					"propertyName": "items",
					"values": {
						"id": "confirmation-code",
						"visible": {"bindTo": "IsConfirmationCodeItemEnabled"},
						"isRequired": {"bindTo": "IsConfirmationCodeItemEnabled"},
						"value": {
							"bindTo": "ConfirmationCode"
						},
						"controlConfig": {
							"protect": false
						},
						"layout": {
							"column": 0,
							"row": 4,
							"colSpan": 12
						},
						"labelConfig": {
							"caption": { "bindTo": "getConfirmationCodeCaption" }
						},
						"markerValue": "confirmation-code",
						"wrapClass": ["search-edit"]
					}
				},
				{
					"operation": "insert",
					"name": "send-text-code-button",
					"parentName": "leftPanelGridLayout",
					"propertyName": "items",
					"values": {
						"itemType": Terrasoft.ViewItemType.BUTTON,
						"id": "send-text-code-button",
						"caption": {"bindTo" : "Resources.Strings.sendTextCodeCaption"},
						"click": {
							"bindTo": "onSendTextCodeClick"
						},
						"visible": {"bindTo": "TextCodeTwoFactorAuthFlowEnabled"},
						"layout": {
							"column": 2,
							"row": 4,
							"colSpan": 12
						}
					}
				},
			],

			methods: {

				init: function() {
					this.callParent(arguments);
					this.actualizeColumnRequired();
					this.initIsLdap();
					const useSeparatedPage2FA = Terrasoft.Features?.getIsEnabled("UseSeparatedPage2FA") || false;
					this.set("useSeparatedPage2FA", useSeparatedPage2FA);
					this.init2FaSettings();
					this.setTotpStatus();
					this.set("IsConfirmationCodeItemEnabled", this.getIsConfirmationCodeItemEnabled());
				},

				init2FaSettings: function() {
					if (this.getUseSeparatedPage2FA()) {
						this.set("IsConfirmationCodeEnabled", false);
						this.set("TextCodeTwoFactorAuthFlowEnabled", false);
						return;
					}
					var enable2FA = Terrasoft.SysSettings?.getCachedSysSetting("Enable2FA") || false;
					var enabled2FAFlow = Terrasoft.Features?.getIsEnabled("Enabled2FAFlow") || false;
					var isConfirmationCodeEnabled = enable2FA && enabled2FAFlow;
					this.set("IsConfirmationCodeEnabled", isConfirmationCodeEnabled);
					if (!isConfirmationCodeEnabled) {
						return;
					}
					Terrasoft.AjaxProvider.request({
						url: Terrasoft.workspaceBaseUrl +
							"/../ServiceModel/AuthService.svc/GetAuthenticationSettings",
						method: "POST",
						jsonData: null,
						callback: function(options, result, response) {
							var responseObject = Terrasoft.decode(response.responseText);
							var textCodeTwoFactorAuthFlowEnabled = responseObject.enabledTwoFactorAuthFlows
								.map((x) => x.code)
								.includes(
									'SMS'
								);
							this.set("TextCodeTwoFactorAuthFlowEnabled", 
								textCodeTwoFactorAuthFlowEnabled && isConfirmationCodeEnabled);
						},
						scope: this
					});
				},

				actualizeColumnRequired: function() {
					this.columns.currentPassword.isRequired = this.isNotRecoveryMode();
				},

				isNotRecoveryMode: function() {
					var hash = this.Terrasoft.router.Router.getHash();
					return hash.indexOf("PasswordRecoveryMode") === -1;
				},

				getParameterByName: function(name) {
					name = name.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
					var hash = Terrasoft.router.Router.getHash();
					var regex = new RegExp("[\\?&]" + name + "=([^&]*)"),
						results = regex.exec(hash);
					return results === null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
				},

				/**
				 * Redirects to main page or previous state on success pasword change.
				 */
				successRedirect: function() {
					if (this.isNotRecoveryMode()) {
						this.sandbox.publish("BackHistoryState");
					} else {
						var location = window.location;
						var origin = location.origin || location.protocol + "//" + location.host;
						var url = Ext.String.format("{0}{1}", origin, location.pathname);
						this.changeUrl(url);
					}
				},

				/**
				 * Sets url to native window.location.url.
				 * @private
				 * @param {String} url Url to set.
				 */
				changeUrl: function(url) {
					window.location.href = url;
				},

				getUseSeparatedPage2FA: function() {
					const useSeparatedPage2FA  = this.get("useSeparatedPage2FA");
					return useSeparatedPage2FA;
				},

				setTotpStatus: function() {
					if (this.getUseSeparatedPage2FA()) {
						return;
					}
					if (this.get("IsConfirmationCodeEnabled")) {
						this.set("IsTotpEnabled", false);
						this.set("TotpProviderName", '');
						return;
					}
					Terrasoft.AjaxProvider.request({
						url: Terrasoft.workspaceBaseUrl +
							"/../ServiceModel/TotpSetupService.svc/GetTotpInfo",
						method: "POST",
						jsonData: null,
						callback: function(options, result, response) {
							var responseObject = Terrasoft.decode(response.responseText);
							this.set("IsTotpEnabled", responseObject.GetTotpInfoResult.isTotpEnabled);
							this.set("TotpProviderName", responseObject.GetTotpInfoResult.providerName);
							this.set("IsConfirmationCodeItemEnabled", this.getIsConfirmationCodeItemEnabled());
						},
						scope: this
					});
				},

				onChangePasswordClick: function() {
					var isValid = this.validate();
					if (!isValid) {
						return;
					}
					if (this.isTotpEnabled()) {
						this.validateTotpCode(this.changePassword);
					} else {
						this.changePassword();
					}
				},

				validateTotpCode: function(callback) {
					if (!this.isTotpEnabled()) {
						return this.Ext.callback(callback, this);
					}
					var data = {
						totpCode: this.get("ConfirmationCode")
					};
					Terrasoft.AjaxProvider.request({
						url: Terrasoft.workspaceBaseUrl +
							"/ServiceModel/TotpChangePasswordValidator.svc/VerifyOnlyTotpCode",
						method: "POST",
						jsonData: data,
						callback: function(options, result, response) {
							var responseObject = Terrasoft.decode(response.responseText);
							if (responseObject && responseObject.VerifyOnlyTotpCodeResult && responseObject.VerifyOnlyTotpCodeResult.isSuccess) {
								var isTotpValid = responseObject.VerifyOnlyTotpCodeResult.isTotpCodeValid;
								if (isTotpValid) {
									return this.Ext.callback(callback, this);
								} else {
									this.showInformationDialog(resources.localizableStrings.invalidTotpToken);
								}
							} else {
								this.log(responseObject.VerifyOnlyTotpCodeResult.additionalInfo);
								this.showInformationDialog(resources.localizableStrings.invalidTotpToken);
							}
						},
						scope: this
					});
				},

				changePassword: function() {
					var password = this.get("currentPassword");
					var newPassword = this.get("newPassword");
					var newPasswordConfirmation = this.get("newPasswordConfirmation");
					var sysValues = Terrasoft.SysValue;
					var passwordRecoveryModeKey = this.getParameterByName("PasswordRecoveryMode");
					var authToken = {
						UserName: sysValues.CURRENT_USER.displayValue,
						UserPassword: password,
						WorkspaceName: sysValues.CURRENT_WORKSPACE.displayValue,
						NewUserPassword: newPassword,
						ConfirmUserPassword: newPasswordConfirmation,
						PasswordRecoveryMode: passwordRecoveryModeKey
					};
					if (this.isTotpEnabled()) {
						authToken.ClaimList = this.getAdditionalTotpClaims();
						authToken.ProviderName = this.get("TotpProviderName");
					}
					if (this.get("IsConfirmationCodeEnabled")) {
						authToken.ClaimList = this.getAdditional2FAClaims();
					}
					var changePasswordServiceUrl = Terrasoft.workspaceBaseUrl +
						"/../ServiceModel/AuthService.svc/DoChangePasswordLogin";
					Terrasoft.AjaxProvider.request({
						url: changePasswordServiceUrl,
						method: "POST",
						jsonData: authToken,
						callback: function(options, result, response) {
							var localizableStrings = resources.localizableStrings;
							if (!result) {
								var errorMessage = localizableStrings.errorPasswordChangeMessage;
								this.showInformationDialog(errorMessage, Ext.emptyFn);
							}
							var responseObject = Terrasoft.decode(response.responseText);
							if (responseObject.Code !== 0) {
								this.showInformationDialog(responseObject.Message, Ext.emptyFn);
							} else {
								var successMessage = localizableStrings.successPasswordChangeMessage;
								this.showInformationDialog(successMessage, function() {
									this.successRedirect();
								});
							}
						},
						scope: this
					});
				},

				onSendTextCodeClick: function() {
					const authToken = {};
					const sendTextCodeUrl = Terrasoft.workspaceBaseUrl +
						"/../ServiceModel/AuthService.svc/StartTextCodeAuthFlow";
					Terrasoft.AjaxProvider.request({
						url: sendTextCodeUrl,
						method: "POST",
						jsonData: authToken,
						callback: function(options, result, response) {
							var responseObject = Terrasoft.decode(response.responseText);
							this.showInformationDialog(responseObject.message, Ext.emptyFn);
						},
						scope: this
					});
				},

				onNewPasswordKeypress: function() {
					var newPasswordTextEdit = Ext.getCmp("new-password");
					var newPasswordInputValue = newPasswordTextEdit.getTypedValue();
					this.set("newPassword", newPasswordInputValue);
				},

				onNewPasswordConfirmationKeypress: function() {
					var newPasswordConfirmationTextEdit = Ext.getCmp("new-password-confirmation");
					var newPasswordConfirmationInputValue = newPasswordConfirmationTextEdit.getTypedValue();
					this.set("newPasswordConfirmation", newPasswordConfirmationInputValue);
				},

				setValidationConfig: function() {
					this.callParent(arguments);
					this.addColumnValidator("newPassword", this.newPasswordValidator);
					this.addColumnValidator("newPasswordConfirmation", this.newPasswordConfirmationValidator);
					if (this.get("IsConfirmationCodeEnabled") && !this.getUseSeparatedPage2FA()) {
						this.addColumnValidator("ConfirmationCode", this.confirmationCodeValidator);
					}
				},

				confirmationCodeValidator: function(confirmationCode) {
					var invalidMessage = "";
					if (this.get("IsConfirmationCodeEnabled") && Ext.isEmpty(confirmationCode)) {
						invalidMessage = resources.localizableStrings.requiredConfirmationCodeMessage;
					} else {
						this.validationInfo.set("ConfirmationCode", {
							invalidMessage: invalidMessage,
							isValid: true
						});
					}
					return {
						invalidMessage: invalidMessage
					};
				},

				newPasswordValidator: function(newPassword) {
					var newPasswordConfirmation = this.get("newPasswordConfirmation");
					var invalidMessage = "";
					if (!Ext.isEmpty(newPasswordConfirmation)) {
						if (newPasswordConfirmation !== newPassword) {
							invalidMessage = resources.localizableStrings.passwordMissMatchMessageCaption;
						} else {
							this.validationInfo.set("newPasswordConfirmation", {
								invalidMessage: "",
								isValid: true
							});
						}
					}
					return {
						invalidMessage: invalidMessage
					};
				},

				newPasswordConfirmationValidator: function(newPasswordConfirmation) {
					var newPassword = this.get("newPassword");
					var invalidMessage = "";
					if (newPasswordConfirmation !== newPassword) {
						invalidMessage = resources.localizableStrings.passwordMissMatchMessageCaption;
					} else {
						this.validationInfo.set("newPassword", {
							invalidMessage: "",
							isValid: true
						});
					}
					return {
						invalidMessage: invalidMessage
					};
				},

				initIsLdap: function() {
					ServiceHelper.callService({
						serviceName: "CurrentUserService",
						methodName: "GetIsCurrentUserSynchronizedWithLdap",
						callback: function(response, success) {
							if (success && response) {
								this.set("isLdap", response.isSynchronized);
							}
						},
						scope: this
					});
				},

				isTotpEnabled : function() {
					return this.get("IsTotpEnabled");
				},

				getAdditionalTotpClaims: function() {
					var userClaims = [];
					var totpUserClaim = {
						"Key": "token",
						"Value": this.get("ConfirmationCode")
					};
					userClaims.push(totpUserClaim);
					return userClaims;
				},

				getAdditional2FAClaims: function() {
					var userClaims = [];
					var twoFAClaim = {
						"Key": "token",
						"Value": this.get("ConfirmationCode")
					};
					userClaims.push(twoFAClaim);
					return userClaims;
				},

				getIsConfirmationCodeItemEnabled: function() {
					const useSeparatedPage2FA = this.getUseSeparatedPage2FA();
					const IsConfirmationCodeEnabled = this.get("IsConfirmationCodeEnabled");
					const isTotpEnabled = this.isTotpEnabled();
					return (IsConfirmationCodeEnabled || isTotpEnabled) && !useSeparatedPage2FA;
				},

				getConfirmationCodeCaption: function() {
					return this.get("IsConfirmationCodeEnabled") ?
						this.get("Resources.Strings.confirmationCodeCaption") :
						this.get("Resources.Strings.totpCodeCaption");
				}

			}
		};
	});
