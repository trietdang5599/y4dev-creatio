define("BaseSyncSettingsEdit", ["ModalBox", "ConfigurationConstants", "ExchangeNUIConstants", "RightUtilities",
		"NetworkUtilities", "MailServerViewModel", "OAuthAuthenticationMixin", "AcademyUtilities"],
	function(ModalBox, ConfigurationConstants, ExchangeNUIConstants, RightUtilities,
				NetworkUtilities) {
		return {
			messages: {
				/**
				 * Notifes that new email sync settings has been added.
				 * @message EmailboxSyncSettingsInserted
				 */
				"EmailboxSyncSettingsInserted": {
					mode: this.Terrasoft.MessageMode.BROADCAST,
					direction: this.Terrasoft.MessageDirectionType.PUBLISH
				},

				/**
				 * @message ReloadSettings
				 * Reloads settings.
				 */
				"ReloadSettings": {
					mode: this.Terrasoft.MessageMode.PTP,
					direction: this.Terrasoft.MessageDirectionType.PUBLISH
				},

				/**
				 * @message AddMailBoxEvent
				 * Reloads mailbox list.
				 */
				"AddMailBoxEvent": {
					mode: this.Terrasoft.MessageMode.PTP,
					direction: this.Terrasoft.MessageDirectionType.PUBLISH
				},

				/**
				 * @message PushHistoryState
				 * Post changes in the chain of states.
				 */
				"PushHistoryState": {
					mode: this.Terrasoft.MessageMode.BROADCAST,
					direction: this.Terrasoft.MessageDirectionType.PUBLISH
				}
			},
			attributes: {
				/**
				 * Servers collection.
				 * @type {Terrasoft.BaseViewModelCollection}
				 */
				"ServerListCollection": {
					dataValueType: this.Terrasoft.DataValueType.COLLECTION,
					type: this.Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN
				},
				/**
				 * Default visibility for server list container.
				 */
				"IsServerListVisible": {
					dataValueType: Terrasoft.DataValueType.BOOLEAN,
					value: false
				},
				/**
				 * Existing mail synchronization for current user.
				 */
				"IsMailSyncExists": {
					dataValueType: Terrasoft.DataValueType.BOOLEAN,
					value: false
				},
				/**
				 * Mailbox synchronization interval.
				 */
				"MailboxSyncInterval": {
					dataValueType: Terrasoft.DataValueType.INTEGER,
					value: 1
				},
				/**
				 * Default visibility for credentials container.
				 */
				"IsServerCredentialsVisible": {
					dataValueType: Terrasoft.DataValueType.BOOLEAN,
					value: false
				},
				/**
				 * Is login input focused flag.
				 */
				"IsLoginEditFocused": {
					dataValueType: Terrasoft.DataValueType.BOOLEAN,
					value: false
				},
				/**
				 * Is password input focused flag.
				 */
				"IsPasswordEditFocused": {
					dataValueType: Terrasoft.DataValueType.BOOLEAN,
					value: false
				},
				/**
				 * Sender email.
				 */
				"SenderEmailAddress": {
					dataValueType: this.Terrasoft.DataValueType.TEXT,
					isRequired: true
				},
				/**
				 * User login.
				 */
				"UserName": {
					dataValueType: this.Terrasoft.DataValueType.TEXT,
					dependencies: [
						{
							columns: ["SenderEmailAddress"],
							methodName: "setUserLogin"
						}
					]
				},
				/**
				 * User password.
				 */
				"UserPassword": {
					dataValueType: this.Terrasoft.DataValueType.TEXT,
					isRequired: true
				},
				/**
				 * Server name label value.
				 */
				"ServerName": {
					dataValueType: this.Terrasoft.DataValueType.TEXT
				},
				/**
				 * Identifier of mailbox synchronization settings.
				 */
				"MailboxSyncSettingsId": {
					dataValueType: this.Terrasoft.DataValueType.GUID
				},
				/**
				 * Selected server for new settings creation.
				 * @type {Terrasoft.BaseViewModel}
				 */
				"SelectedServer": {
					dataValueType: this.Terrasoft.DataValueType.CUSTOM_OBJECT
				},
				/**
				 * Visibility for "Back to server List" button.
				 */
				"IsBackToServerListButtonVisible": {
					dataValueType: Terrasoft.DataValueType.BOOLEAN,
					value: true
				},
				/**
				 * Visibility for credentials login input.
				 */
				"UseLogin": {
					dataValueType: Terrasoft.DataValueType.BOOLEAN,
					value: true
				},
				/**
				 * Default start panel visibility.
				 */
				"IsEnterEmailPanelVisible": {
					dataValueType: Terrasoft.DataValueType.BOOLEAN,
					value: true
				},
				/**
				 * Server domain collection. Used for automatic mail server detection.
				 * @type {Terrasoft.BaseViewModelCollection}
				 */
				"DomainCollection": {
					dataValueType: this.Terrasoft.DataValueType.COLLECTION,
					type: this.Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN
				},
				/**
				 * When this flag set to true, new synchronization settings flow will start from scheduler job creating
				 * step. Server select and user credential edit steps will be skipped. Note that SenderEmailAddress,
				 * MailBoxServerId, MailboxSyncSettingsId, MailboxSyncInterval, AutomaticallyAddNewEmails properties
				 * are required for this state.
				 */
				"ShowCreateSyncJob": {
					dataValueType: Terrasoft.DataValueType.BOOLEAN,
					value: false
				},
				/**
				 * Selected mail server unique identifier.
				 */
				"MailBoxServerId": {
					dataValueType: Terrasoft.DataValueType.GUID
				},
				/**
				 * Selected mail server UseUserNameAsLogin column value.
				 */
				"UseUserNameAsLogin": {
					dataValueType: Terrasoft.DataValueType.BOOLEAN
				},
				/**
				 * Selected mail server UseEmailAddressAsLogin column value.
				 */
				"UseEmailAddressAsLogin": {
					dataValueType: Terrasoft.DataValueType.BOOLEAN
				},
				/**
				 * Selected mail server AllowEmailDownloading column value.
				 */
				"AllowEmailDownloading": {
					dataValueType: Terrasoft.DataValueType.BOOLEAN,
					value: true
				},
				/**
				 * Can manage mail server list flag.
				 * @type {Boolean}
				 */
				"CanManageMailServers": {
					dataValueType: Terrasoft.DataValueType.BOOLEAN,
					value: true
				},
				/**
				 * Credentials validation error text.
				 * @type {String}
				 */
				"ErrorContent": {
					dataValueType: this.Terrasoft.DataValueType.TEXT
				}
			},
			properties: {

				/**
				 * Id of the article about ExchangeListener at the academy.
				 * @type {Number}
				 */
				exchangeListenerAcademyArticleId: 2074,

				/**
				 * Id of the article about Email troubleshoot at the academy.
				 * @type {Number}
				 */
				emailTroupleshootAcademyArticleId: 2394
				
			},
			mixins: {
				/**
				 * @class OAuthAuthenticationMixin The mixin to work with OAuth authentication.
				 */
				OAuthAuthenticationMixin: "Terrasoft.OAuthAuthenticationMixin"
			},
			methods: {

				//region Methods: Private

				/**
				 * Updates mailbox synchronization settings.
				 * @private
				 */
				updateMailboxSyncSettings: function() {
					this.sandbox.publish("ReloadSettings", {
						recordId: this.get("MailboxSyncSettingsId")
					});
				},

				/**
				 * Clears {@link Terrasoft.EntitySchemaQuery#cache} item for passed cache key.
				 * @private
				 * @param {String} cacheItemKey Cache key.
				 */
				_clearEsqCache: function(cacheItemKey) {
					if (!Ext.isEmpty(cacheItemKey)) {
						delete Terrasoft.EntitySchemaQuery.cache[cacheItemKey];
					}
				},

				/**
				 * Save button handler.
				 * @private
				 * @param {Function} callback Callback function.
				 * @param {Object} scope Callback function context.
				 */
				onSave: function(callback, scope) {
					this.showBodyMask({
						selector: ".credantials-modal-box"
					});
					this.setUserLogin();
					Terrasoft.chain(
						this.asyncValidate,
						this.checkContactEmail,
						this.save,
						this.createOrDeleteSyncJob,
						function() {
							if (callback) {
								callback.call(scope || this);
							}
						}, this);
				},

				/**
				 * Executes insert or update queries.
				 * @private
				 * @param {Function} callback Callback function.
				 * @param {Object} scope Callback function context.
				 */
				save: function(callback, scope) {
					var itemId = this.get("MailboxSyncSettingsId");
					var query;
					var requestCallback;
					if (itemId) {
						query = this.getUpdateQuery();
						requestCallback = this.onUpdated;
					} else {
						query = this.getInsertQuery();
						requestCallback = this.onSaved;
					}
					query.execute(function(response) {
						if (response.success) {
							requestCallback.call(this, callback, scope);
						}
					}, this);
				},

				/**
				 * Loads server domains list from database.
				 * @private
				 * @param {Function} callback Callback function.
				 * @param {Object} scope Callback function scope.
				 */
				_initDomainList: function(callback, scope) {
					this.set("DomainCollection", this.Ext.create("Terrasoft.BaseViewModelCollection"));
					var esq = this.Ext.create("Terrasoft.EntitySchemaQuery", {
						rootSchemaName: "MailServerDomain"
					});
					this.addDomainCacheParameters(esq);
					this.addDomainEsqColumns(esq);
					esq.getEntityCollection(function(response) {
						if (response.success) {
							var collection = response.collection;
							var domainCollection = this.get("DomainCollection");
							domainCollection.loadAll(collection);
						}
						this.Ext.callback(callback, scope);
					}, this);
				},

				/**
				 * Initializes can manage mail servers list flag.
				 * @private
				 * @param {Function} callback Callback function.
				 * @param {Object} scope Callback function scope.
				 */
				_initCanManageMailServers: function(callback, scope) {
					RightUtilities.checkCanExecuteOperation({
						"operation": "CanManageMailServers"
					}, function(permission) {
						this.$CanManageMailServers = permission;
						this.Ext.callback(callback, scope || this);
					}, this);
				},

				/**
				 * Open add mail server page window.
				 * @private
				 */
				_openMailServerWindow: function () {
					let url = Terrasoft.workspaceBaseUrl;
					const parameterString = ["editMode=true", "Id=e24018bf-4ef6-49ef-a331-4fdb6b742e4c"];
					url += "/ViewPage.aspx?" + parameterString.join("&");
					const width = 600;
					const height = 400;
					const left = screen.availLeft + (screen.availWidth - width) / 2;
					const top = screen.availTop + (screen.availHeight - height) / 2;
					const windowParams = Ext.String.format("resizable,width={0},height={1},left={2},top={3}",
						width, height, left, top);
					this.openWindow(url, "_blank", windowParams);
				},

				/**
				 * Creates Creatio academy link url for passed context help page code.
				 * @private
				 * @param {Number} contextHelpId Context help page code.
				 * @param {Function} callback Callback function.
				 * @param {Object} scope Callback function scope.
				 */
				_getAcademyUrl: function(contextHelpId, callback, scope) {
					const config = {
						contextHelpId: contextHelpId,
						scope: scope || this,
						callback: callback
					};
					Terrasoft.AcademyUtilities.getUrl(config);
				},

				/**
				 * Open an article about Exchange Listener at the Creatio academy.
				 * @private
				 */
				_openExchangeListenerAcademy: function() {
					this._getAcademyUrl(this.exchangeListenerAcademyArticleId,
						function(url) {
							window.open(url, "_blank");
						}, this);
				},

				/**
				 * Creates current schema image resource url.
				 * @private
				 * @param {String} resourceName Image resource name.
				 * @return {String} Image resource url.
				 */
				_getImageUrl: function(resourceName) {
					return Terrasoft.ImageUrlBuilder.getUrl({
						source: Terrasoft.ImageSources.SOURCE_CODE_SCHEMA,
						"params": {
							"schemaName": "BaseSyncSettingsEdit",
							"resourceItemName": resourceName
						}
					});
				},

				/**
				 * Creates error pannel template.
				 * @private
				 * @param {Function} callback Callback function.
				 * @param {Object} scope Callback function scope.
				 */
				_initErrorPanelTpl: function(callback, scope) {
					const iconUrl = this._getImageUrl("ErrorIcon");
					this.set("ErrorMsgTpl", "<div data-item-marker='error-panel' class='credentials-error'>" + 
							"<img src='img_src'/><div data-item-marker='error-text'>{0}</div></div>"
							.replace("img_src", iconUrl));
					this.Ext.callback(callback, scope || this);
				},

				/**
				 * Creates information link for current error.
				 * @private
				 * @param {Function} callback Callback function.
				 */
				_getInfoLink: function(callback) {
					const validateInfo = this.get("ValidateInfo");
					const data = validateInfo.data;
					if (data) {
						switch (data) {
							case "LinkToExchangeListenerServiceAcademy":
								this._getAcademyUrl(this.exchangeListenerAcademyArticleId, callback, this);
								return;
							case "EmailTroubleShoot":
								this._getAcademyUrl(this.emailTroupleshootAcademyArticleId, callback, this);
								return; 
						}
					}
					this.Ext.callback(callback, this);
				},

				/**
				 * Creates error text for current error.
				 * @private
				 * @param {Function} callback Callback function.
				 * @param {String} infoLink Information link for current error.
				 */
				_getErrorMessage: function(callback, infoLink) {
					const validateInfo = this.get("ValidateInfo");
					const messageTpl = validateInfo.errorType;
					const message = Ext.String.format(messageTpl, infoLink);
					this.Ext.callback(callback, this, [message]);
				},

				_showStepAfterServerSelected: function(serverInfo) {
					if (serverInfo.$UseImpersonation) {
						this.$UserName = this.$SenderEmailAddress;
						this.$UserPassword = "Impersonated";
						return this.onSave();
					}
					if (serverInfo.$OAuthApplication.value !== undefined) {
						this.useOAuthAuthentication(this.$SenderEmailAddress, 
							serverInfo.get("OAuthApplication.AppClassName"), serverInfo.$Id);
					} else {
						this.showServerCredentials();
						ModalBox.updateSizeByContent();
					}
				},

				//endregion

				//region Methods: Protected

				/**
				 * @inheritdoc Terrasoft.BaseSchemaViewModel#init
				 * @protected
				 * @overridden
				 */
				init: function(callback, scope) {
					this.setWrapMarkerValue(false);
					this.callParent([function() {
						Terrasoft.chain(
							this._initCanManageMailServers,
							this.initCollection,
							this.initServersList,
							this.setMailSyncExist,
							this.setSyncInterval,
							this._initDomainList,
							this._initErrorPanelTpl,
							function() {
								this.initEventsSubscription();
								if (callback) {
									callback.call(scope || this);
									ModalBox.updateSizeByContent();
								}
							},
							this
						);
					}, this]);
				},

				/**
				 * Sets wrap container marker value.
				 * @protected
				 * @param {Boolean} isReady Is module loaded and ready.
				 */
				setWrapMarkerValue: function(isReady) {
					var markerValue = isReady ? "AddSyncSettingsModule" : "Loading";
					this.set("WrapMarkerValue", markerValue);
				},

				/**
				 * Initializes servers list collection.
				 * @protected
				 * @param {Function} callback Callback function.
				 * @param {Object} scope Callback function context.
				 */
				initCollection: function(callback, scope) {
					var collection = this.Ext.create("Terrasoft.BaseViewModelCollection");
					this.set("ServerListCollection", collection);
					if (callback) {
						callback.call(scope || this);
					}
				},

				/**
				 * Initializes servers list.
				 * @protected
				 * @param {Function} callback Callback function.
				 * @param {Object} scope Callback function context.
				 */
				initServersList: function(callback, scope) {
					var esq = this.Ext.create("Terrasoft.EntitySchemaQuery", {
						rootSchemaName: "MailServer",
						rowViewModelClassName: "Terrasoft.MailServerViewModel"
					});
					this.setServerSelectColumns(esq);
					this.setFiltersToServerListEsq(esq);
					esq.getEntityCollection(function(response) {
						if (response.success) {
							var collection = response.collection;
							collection.each(function(item) {
								item.Id = item.get("Id");
							});
							var serverListCollection = this.get("ServerListCollection");
							serverListCollection.loadAll(collection);
						}
						if (callback) {
							callback.call(scope || this);
						}
					}, this);
				},

				/**
				 * Display credential container.
				 * @protected
				 * @virtual
				 */
				showServerCredentials: function() {
					this.set("IsEnterEmailPanelVisible", false);
					this.set("IsServerListVisible", false);
					this.set("IsServerCredentialsVisible", true);
				},

				/**
				 * Display server list container.
				 * @protected
				 * @virtual
				 */
				showServerList: function() {
					this.hideErrorInfo();
					this.set("IsEnterEmailPanelVisible", false);
					this.set("IsServerListVisible", true);
					this.set("IsServerCredentialsVisible", false);
					ModalBox.updateSizeByContent();
				},

				/**
				 * Calls window.open function with parameters.
				 * @protected
				 * @param {String} url Url to open.
				 * @param {String} target Target to open url.
				 * @param {String} parameters Open parameters.
				 */
				openWindow: function(url, target, parameters) {
					window.open(url, target, parameters);
				},

				/**
				 * Async validate mail settings.
				 * @protected
				 * @param {Function} callback Callback function.
				 * @param {Object} scope Callback execution scope.
				 */
				asyncValidate: function(callback, scope) {
					if (!this.validate()) {
						this.hideBodyMask();
						return;
					}
					this.hideErrorInfo();
					Terrasoft.chain(
						this.checkMailAccountExist,
						function(next, success) {
							this.checkLoginPasswordCorrect(success, next);
						},
						function() {
							var validateInfo = this.get("ValidateInfo");
							if (validateInfo && validateInfo.success) {
								if (callback) {
									callback.call(scope || this);
								}
							} else {
								this.showErrorInfo();
							}
						},
						this
					);
				},

				/**
				 * Hides error information.
				 * @protected
				 */
				hideErrorInfo: function() {
					this.set("ValidateInfo", {
						success: true
					});
					this.set("ErrorContent", "");
					ModalBox.updateSizeByContent();
				},

				/**
				 * Shows error information.
				 * @protected
				 */
				showErrorInfo: function() {
					this.hideBodyMask();
					Terrasoft.chain(
						this._getInfoLink,
						this._getErrorMessage,
						function(next, errorText) {
							var tpl = this.get("ErrorMsgTpl");
							this.set("ErrorContent", Ext.String.format(tpl, errorText));
							ModalBox.updateSizeByContent();
						}, this
					);
				},

				/**
				 * Returns configuration object for academy link button.
				 * @param {String} data Code of the clicked button.
				 * @return {Object} Configuration object for academy link button.
				 * @private
				 */
				getButtonsConfigs: function(data) {
					var caption = this.get("Resources.Strings.LinkToExchangeListenerServiceAcademyCaption");
					const linkButton = Terrasoft.getButtonConfig(data, caption);
					linkButton.style = Terrasoft.controls.ButtonEnums.style.GREY;
					var okButton = this.Terrasoft.deepClone(this.Terrasoft.MessageBoxButtons.OK);
					okButton.style = Terrasoft.controls.ButtonEnums.style.BLUE;
					return [linkButton, okButton];
				},

				/**
				 * Handler for the information dialog click event.
				 * @param {String} returnCode Code of the clicked button.
				 * @protected
				 */
				onDialogButtonClick: function(returnCode) {
					switch (returnCode) {
						case "LinkToExchangeListenerServiceAcademy":
							this._openExchangeListenerAcademy();
							break;
					}
				},

				/**
				 * Sets mailbox synchronization interval.
				 * @protected
				 * @param {Function} callback Callback function.
				 * @param {Object} scope Callback execution scope.
				 */
				setSyncInterval: function(callback, scope) {
					this.Terrasoft.SysSettings.querySysSettingsItem("MailboxSyncInterval", function(value) {
							this.set("MailboxSyncInterval", value);
							this.Ext.callback(callback, scope || this);
						},
						this);
				},

				/**
				 * Sets existence email synchronization for current account.
				 * @protected
				 * @param {Function} callback Callback function.
				 * @param {Object} scope Callback execution scope.
				 */
				setMailSyncExist: function(callback, scope) {
					var sysAdminUnitId = this.Terrasoft.SysValue.CURRENT_USER.value;
					var selectMailboxSyncSettings = Ext.create("Terrasoft.EntitySchemaQuery", {
						rootSchemaName: "MailboxSyncSettings"
					});
					selectMailboxSyncSettings.addColumn("Id");
					selectMailboxSyncSettings.filters.add(selectMailboxSyncSettings.createColumnFilterWithParameter(
						Terrasoft.ComparisonType.EQUAL, "SysAdminUnit", sysAdminUnitId));
					selectMailboxSyncSettings.getEntityCollection(function(response) {
						var isMailSyncExists = response.success && response.collection.getCount() > 0;
						this.set("IsMailSyncExists", isMailSyncExists);
						callback.call(scope || this);
					}, this);
				},

				/**
				 * Checks mail account exist.
				 * @protected
				 * @param {Function} callback Callback function.
				 * @param {Object} scope Callback execution scope.
				 */
				checkMailAccountExist: function(callback, scope) {
					var itemId = this.get("MailboxSyncSettingsId");
					if (itemId) {
						if (callback) {
							callback.call(scope || this, true);
						}
						return;
					}
					var config = {
						serviceName: "MailboxSettingsService",
						methodName: "GetMailboxOwners",
						data: {
							senderEmailAddress: this.getSenderEmailAddress()
						}
					};
					this.callService(config, function(response) {
						let isValid = true;
						if (this.isEmpty(response)) {
							this.set("ValidateInfo", {
								success: false,
								errorType: this.get("Resources.Strings.Other")
							});
							isValid = false;
						}
						var owners =  response && response.GetMailboxOwnersResult;
						if (!this.isEmpty(owners)) {
							var messageTpl = this.get("Resources.Strings.MailboxExist");
							this.set("ValidateInfo", {
								success: false,
								errorType: this.Ext.String.format(messageTpl, owners.join(", "))
							});
							isValid = false;
						}
						this.Ext.callback(callback, scope || this, [isValid]);
					}, this);
				},

				/**
				 * Checks login and password correct.
				 * @protected
				 * @param {Boolean} success Previous validation result.
				 * @param {Function} callback Callback function.
				 * @param {Object} scope Callback execution scope.
				 */
				checkLoginPasswordCorrect: function(success, callback, scope) {
					var selectedServer = this.get("SelectedServer");
					var serverType = selectedServer && selectedServer.get("Type");
					var shouldValidateImpersonatedMailbox = this.getIsFeatureEnabled("ApplicationAsServiceAccount")
						&& this.Ext.isEmpty(this.get("MailboxSyncSettingsId"))
						&& selectedServer?.$UseImpersonation
						&& serverType?.value === ExchangeNUIConstants.MailServer.Type.Graph;
					if (!success || (selectedServer?.$UseImpersonation && !shouldValidateImpersonatedMailbox)) {
						if (callback) {
							callback.call(scope || this, success);
						}
						return;
					}
					var config = {
						serviceName: "MailboxSettingsService",
						methodName: "IsServerValid",
						data: {
							id: this.get("MailBoxServerId"),
							userName: this.get("UserName"),
							userPassword: this.get("UserPassword"),
							enableSync: true,
							sendEmail: !shouldValidateImpersonatedMailbox,
							senderEmailAddress: this.getSenderEmailAddress(),
							isAnonymousAuthentication: false
						}
					};
					this.callService(config, function(response) {
						if (response && response.IsServerValidResult) {
							var result = response.IsServerValidResult;
							var mailboxName = "";
							var userName = this.get("UserName");
							var validationData = this.Ext.isEmpty(result.Data) ? null : this.Ext.decode(result.Data, true);
							if (!result.IsValid) {
								this.set("ValidateInfo", {
									success: false,
									errorType: this.getLoginErrorMessage(result),
									data: result.Data || "EmailTroubleShoot",
									errorMessage: result.Message
								});
							} else if (validationData) {
								mailboxName = validationData.MailboxName || mailboxName;
								userName = validationData.UserName || userName;
							}
							this.set("SenderDisplayValue", mailboxName);
							this.set("UserName", userName);
						} else {
							this.set("ValidateInfo", {
								success: false,
								errorType: this.get("Resources.Strings.Other")
							});
						}
						callback.call(scope || this);
					}, this);
				},

				/**
				 * Gets login error message.
				 * @protected
				 * @return {String} Incorrect login error message.
				 */
				getLoginErrorMessage: function(loginInfo) {
					const message = loginInfo.Message;
					const data = loginInfo.Data;
					if (data === "LinkToExchangeListenerServiceAcademy") {
						return this.get("Resources.Strings.ExchangeListenerNotDeployed");
					}
					if (message) {
						return message;
					}
					const mailBoxServerId = this.get("MailBoxServerId");
					switch(mailBoxServerId) {
						case ExchangeNUIConstants.MailServer.Gmail:
							return this.get("Resources.Strings.CheckGoogleSettingsMessage");
						case ExchangeNUIConstants.MailServer.Office365:
							return this.get("Resources.Strings.CheckOfficeSettingsMessage");
						default:
							return this.get("Resources.Strings.LoginError");
					}
				},

				/**
				 * Returns current sender email address.
				 * @protected
				 * @return {String} Current sender email address.
				 */
				getSenderEmailAddress: function() {
					let senderEmailAddress = this.$SenderEmailAddress;
					return this.isEmpty(senderEmailAddress)
						? senderEmailAddress
						: this.Ext.String.trim(senderEmailAddress);
				},

				/**
				 * Generates MailboxSyncSettings insert query.
				 * @protected
				 * @virtual
				 * @return {Terrasoft.InsertQuery} MailboxSyncSettings insert query.
				 */
				getMailboxInsert: function() {
					let insert = this.Ext.create("Terrasoft.InsertQuery", {
						rootSchemaName: "MailboxSyncSettings"
					});
					const id = Terrasoft.utils.generateGUID();
					const senderEmailAddress = this.getSenderEmailAddress();
					const dataValueType = Terrasoft.DataValueType;
					const textDataValue = dataValueType.TEXT;
					const guidDataValue = dataValueType.GUID;
					const booleanDataValue = dataValueType.BOOLEAN;
					this.set("MailboxSyncSettingsId", id);
					insert.setParameterValue("Id", id, guidDataValue);
					insert.setParameterValue("MailServer", this.$MailBoxServerId, guidDataValue);
					insert.setParameterValue("UserName", this.$UserName, textDataValue);
					insert.setParameterValue("UserPassword", this.$UserPassword, textDataValue);
					insert.setParameterValue("SenderEmailAddress", senderEmailAddress, textDataValue);
					insert.setParameterValue("MailboxName", senderEmailAddress, textDataValue);
					insert.setParameterValue("SenderDisplayValue", this.$SenderDisplayValue, textDataValue);
					insert.setParameterValue("AutomaticallyAddNewEmails", true, booleanDataValue);
					insert.setParameterValue("EnableMailSynhronization", false, booleanDataValue);
					insert.setParameterValue("LoadAllEmailsFromMailBox", true, booleanDataValue);
					insert.setParameterValue("SendEmailsViaThisAccount", true, booleanDataValue);
					insert.setParameterValue("LoadEmailsFromDate", this.getMailSyncPeriodDefault(), dataValueType.DATE);
					insert.setParameterValue("MailSyncPeriod", ExchangeNUIConstants.MailSyncPeriod.Week, guidDataValue);
					insert.setParameterValue("IsDefault", !this.$IsMailSyncExists, booleanDataValue);
					return insert;
				},

				/**
				 * Edits existing email account synchronization settings.
				 * @protected
				 * @param {Function} callback Callback function.
				 * @param {Object} scope Callback function context.
				 */
				editEmailAccount: function(callback, scope) {
					var itemId = this.get("MailboxSyncSettingsId");
					var historyState = this.sandbox.publish("GetHistoryState");
					var prevHash = historyState.hash;
					var newState = {
						recordId: itemId
					};
					var hash = "BaseSchemaModuleV2/SyncSettings";
					if (prevHash && prevHash.historyState === hash) {
						this.sandbox.publish("ReloadSettings", newState);
					} else {
						this.sandbox.publish("PushHistoryState", {
							hash: hash,
							stateObj: newState
						});
					}
					this.Ext.callback(callback, scope || this);
				},

				/**
				 * Creates auto synchronization jobs.
				 * @protected
				 * @param {Function} callback Callback function.
				 * @param {Object} scope Callback function context.
				 */
				createOrDeleteSyncJob: function(callback, scope) {
					if (!this.$IsBackToServerListButtonVisible) {
						return this.Ext.callback(this.updateSyncJobs, this, [callback, scope]);
					}
					if (!this.$AllowEmailDownloading || !this.$EnableMailSynhronization) {
						this.Ext.callback(callback, scope || this);
						return;
					}
					var interval = this.get("MailboxSyncInterval");
					var data = {
						create: true,
						mailboxName: this.getSenderEmailAddress(),
						serverId: this.get("MailBoxServerId"),
						interval: interval,
						senderEmailAddress: this.getSenderEmailAddress(),
						createContactJob: false,
						createActivityJob: false,
						contactActivityInterval: interval
					};
					var changeSettingsButtonCaption = this.get("Resources.Strings.ChangeSettingsButtonCaption");
					var changeSettingsButton = {
						className: "Terrasoft.Button",
						caption: changeSettingsButtonCaption,
						markerValue: changeSettingsButtonCaption,
						returnCode: "no"
					};
					const messageTpl = this.get("Resources.Strings.ChangeSettingsMessage");
					const changeSettingsMessage = this.Ext.String.format(messageTpl, this.$SenderEmailAddress);
					this.Terrasoft.utils.showConfirmation(changeSettingsMessage,
						function(returnCode) {
							if (returnCode === Terrasoft.MessageBoxButtons.YES.returnCode) {
								let query = this.getUpdateEnableMailSynhronizationQuery();
								query.execute(function(response) {
									if (response.success) {
										this.callCreateOrDeleteSyncJob(callback, scope, data);
									}
								}, this);
							} else {
								this.editEmailAccount(callback, scope);
							}
						}, ["yes", changeSettingsButton], this);
				},

				/**
				 * Returns MailboxSyncSettings update query with EnableMailSynhronization column enabled.
				 * @return {Terrasoft.UpdateQuery} MailboxSyncSettings update query
				 * with EnableMailSynhronization column enabled.
				 */
				getUpdateEnableMailSynhronizationQuery: function() {
					const mailboxSyncSettingsId = this.$MailboxSyncSettingsId;
					let update = this.Ext.create("Terrasoft.UpdateQuery", {
						rootSchemaName: "MailboxSyncSettings"
					});
					update.filters.addItem(update.createColumnFilterWithParameter(Terrasoft.ComparisonType.EQUAL,
						"Id", mailboxSyncSettingsId));
					update.setParameterValue("EnableMailSynhronization", this.$AllowEmailDownloading,
						Terrasoft.DataValueType.BOOLEAN);
					return update;
				},

				/**
				 * Calls service for create or delete synchronization job.
				 * @protected
				 * @param {Function} callback Callback function.
				 * @param {Object} scope Callback function context.
				 * @param {Object} data Configuration for synchronization job.
				 */
				callCreateOrDeleteSyncJob: function(callback, scope, data) {
					var automaticallyAddNewEmails = this.get("AutomaticallyAddNewEmails");
					var isAutoSynchronization = this.isEmpty(automaticallyAddNewEmails) ||
						automaticallyAddNewEmails;
					if (isAutoSynchronization) {
						this.setAutomaticallyAddNewEmails(true);
						this.callService({
							serviceName: "MailboxSettingsService",
							methodName: "CreateDeleteSyncJob",
							data: data
						}, function(response) {
							if (!this.Ext.isEmpty(response.CreateDeleteSyncJobResult)) {
								this.showInformationDialog(response.CreateDeleteSyncJobResult);
							} else {
								this.Ext.callback(callback, scope || this);
							}
						});
					} else {
						this.Ext.callback(callback, scope || this);
					}
				},

				/**
				 * Calls update synchronization jobs for current mailbox.
				 * @protected
				 * @param {Function} callback Callback function.
				 * @param {Object} scope Callback function context.
				 */
				updateSyncJobs: function(callback, scope) {
					this.callService({
						serviceName: "MailboxSettingsService",
						methodName: "UpdateSyncJobs",
						data: {
							"senderEmailAddress": this.$SenderEmailAddress
						}
					}, function(response) {
						if (!this.Ext.isEmpty(response.UpdateSyncJobsResult)) {
							this.showInformationDialog(response.UpdateSyncJobsResult);
						} else {
							this.Ext.callback(callback, scope || this);
						}
					});
				},

				/**
				 * Saves AutomaticallyAddNewEmails column value to current mailbox record.
				 * @protected
				 * @param {Boolean} value AutomaticallyAddNewEmails column value.
				 */
				setAutomaticallyAddNewEmails: function(value) {
					var itemId = this.get("MailboxSyncSettingsId");
					var update = this.Ext.create("Terrasoft.UpdateQuery", {
						rootSchemaName: "MailboxSyncSettings"
					});
					var filters = update.filters;
					var idFilter = update.createColumnFilterWithParameter(this.Terrasoft.ComparisonType.EQUAL,
						"Id", itemId);
					filters.add("IdFilter", idFilter);
					update.setParameterValue("AutomaticallyAddNewEmails", value,
						this.Terrasoft.DataValueType.BOOLEAN);
					update.execute(this.updateMailboxSyncSettings, this);
				},

				/**
				 * Send message to show tooltip on email communication panel for new settings.
				 * @protected
				 */
				showTooltip: function() {
					var config = {
						userEmail: this.getSenderEmailAddress(),
						mailboxSyncSettingsId: this.get("MailboxSyncSettingsId")
					};
					this.sandbox.publish("EmailboxSyncSettingsInserted", config);
				},

				/**
				 * Returns mails server domain.
				 * @protected
				 * @param {String} domain Domain name.
				 * @return {Object} Mail server lookup value.
				 */
				getServerByDomain: function(domain) {
					var domainList = this.get("DomainCollection");
					var filteredDomains = domainList.filterByFn(function(item) {
						return domain === item.get("Domain");
					}, this);
					if (!filteredDomains.isEmpty()) {
						return filteredDomains.first();
					}
					return null;
				},

				/**
				 * Returns sender email address domain.
				 * @protected
				 * @return {String} Sender email address domain.
				 */
				getEmailDomain: function() {
					var email = this.getSenderEmailAddress();
					return email.split("@")[1];
				},

				/**
				 * Adds columns to mail server domain query.
				 * @protected
				 * @virtual
				 * @param {Terrasoft.EntitySchemaQuery} esq Mail server domain query instance.
				 */
				addDomainEsqColumns: function(esq) {
					esq.addMacrosColumn(this.Terrasoft.QueryMacrosType.PRIMARY_COLUMN, "Id");
					esq.addColumn("Domain");
					esq.addColumn("MailServer");
					esq.addColumn("MailServer.UseImpersonation");
				},

				/**
				 * Adds query cache parameters to mail server domain query.
				 * @protected
				 * @virtual
				 * @param {Terrasoft.EntitySchemaQuery} esq Mail server domain query instance.
				 */
				addDomainCacheParameters: function(esq) {
					this.Ext.apply(esq, {
						clientESQCacheParameters: {
							cacheItemName: "MailServerDomain"
						}
					});
				},

				/**
				 * Switches window to scheduler job creaton mode.
				 * @protected
				 * @return {Boolean} True when window switched to scheduler job creaton mode, false otherwise.
				 */
				switchToNonVisualState: function() {
					var result = this.get("ShowCreateSyncJob");
					if(result) {
						this.createOrDeleteSyncJob(this.Terrasoft.emptyFn, this);
						this.onSaved();
					}
					return result;
				},


				/**
				 * Add new item on the ServerListCollection.
				 * @protected
				 * @virtual
				 * @param {Object} response from server.
				 */
				addNewMailServerToList: function(response) {
					var collection = this.get("ServerListCollection");
					var newEntity = response.entity;
					var newEntityId = newEntity.get("Id");
					collection.add(newEntityId, newEntity);
				},

				//endregion

				//region Methods: Public

				/**
				 * Processes enter key down event. Calls {@link #onSave } method.
				 */
				onKeyDown: function() {
					this.onSave();
				},

				/**
				 * Subscribes for server messages and view model events.
				 */
				initEventsSubscription: function() {
					this.Terrasoft.ServerChannel.on(Terrasoft.EventName.ON_MESSAGE, this.onMailServersListChanged,
							this);
					this.on("change:SenderEmailAddress", function() {
						this.setUserLogin();
					}, this);
				},

				/**
				 * Actualizes mail servers list on change.
				 * @param {Object} scope Scope.
				 * @param {Object} message Changes info.
				 */
				onMailServersListChanged: function(scope, message) {
					var collection = this.get("ServerListCollection");
					var serverInfo;
					switch (message.Header.Sender) {
						case "MailServerAdded":
						case "MailServerEdited":
							serverInfo = this.Ext.decode(message.Body);
							var serverId = serverInfo.Id;
							var esq = this.Ext.create("Terrasoft.EntitySchemaQuery", {
								rootSchemaName: "MailServer",
								rowViewModelClassName: "Terrasoft.MailServerViewModel"
							});
							this.setServerSelectColumns(esq);
							esq.getEntity(serverId, function(response) {
								var existedEntity = collection.find(serverId);
								var newEntity = response.entity;
								if (this.isNotEmpty(existedEntity)) {
									this.Terrasoft.each(existedEntity.columns, function(column, columnName) {
										existedEntity.set(columnName, newEntity.get(columnName));
									});
								} else {
									this.addNewMailServerToList(response);
								}
							}, this);
							break;
						case "MailServerDeleted":
							serverInfo = this.Ext.decode(message.Body);
							var existedEntity = collection.find(serverInfo.Id);
							if (!this.Ext.isEmpty(existedEntity)) {
								collection.remove(existedEntity);
							}
							break;
						default:
							break;
					}
					ModalBox.updateSizeByContent();
				},

				/**
				 * @inheritdoc Terrasoft.configuration.BaseSchemaViewModel#onRender
				 * @overridden
				 */
				onRender: function() {
					this.callParent(arguments);
					if(this.switchToNonVisualState()) {
						return;
					}
					ModalBox.updateSizeByContent();
					this.setWrapMarkerValue(true);
				},

				/**
				 * Add filters to servers query.
				 * @virtual
				 */
				 setFiltersToServerListEsq: function(esq) {
					if (!this.$CanManageMailServers) {
						const filter = esq.createColumnFilterWithParameter(Terrasoft.ComparisonType.EQUAL,
							"UseImpersonation", false);
						esq.filters.add("UseImpersonationFilter", filter);
					}
				 },

				/**
				 * Generates view configuration of item.
				 * @param {Object} itemConfig ContainerList item config.
				 * @param {Terrasoft.BaseViewModel} item ContainerList item.
				 */
				getMailItemViewConfig: function(itemConfig, item) {
					var itemId = item.get("Id");
					var viewConfig = {
						"id": "mailServer",
						"className": "Terrasoft.Container",
						"classes": {"wrapClassName": ["server-list-item"]},
						"items": [
							{
								"className": "Terrasoft.Button",
								"imageConfig": {
									"bindTo": "getMailServerImage"
								},
								"style": Terrasoft.controls.ButtonEnums.style.TRANSPARENT,
								"classes": {
									"wrapperClass": ["mail-server-button"],
									"imageClass": ["mail-server-icon"]
								},
								"markerValue": "MailServerIcon"
							},
							{
								"className": "Terrasoft.Container",
								"classes": {
									"wrapClassName": ["server-list-item-container"]
								},
								"items": [{
									"id": "mail-button-item-" + itemId,
									"className": "Terrasoft.Label",
									"classes": {"labelClass": ["server-list-item-label"]},
									"caption": {"bindTo": "Name"},
									"markerValue": {"bindTo": "Name"}
								}]
							}
						]
					};
					itemConfig.config = viewConfig;
				},

				/**
				 * Display credential container and set name for server name.
				 * @param {Guid} itemId Collection item id.
				 */
				onServerListItemClick: function(itemId) {
					var serverListCollection = this.$ServerListCollection;
					var item = serverListCollection.get(itemId);
					this.$ServerName = item.$Name;
					this.$MailBoxServerId = itemId;
					this.$SelectedServer = item;
					this.$UseLogin = item.$UseLogin;
					this.$UseUserNameAsLogin = item.$UseUserNameAsLogin;
					this.$UseEmailAddressAsLogin = item.$UseEmailAddressAsLogin;
					this.$AllowEmailDownloading = item.$AllowEmailDownloading;
					this.$IsPasswordEditFocused = true;
					this.$IsLoginEditFocused = false;
					this._showStepAfterServerSelected(item);
				},

				/**
				 * Close modal window.
				 * @virtual
				 */
				onCancel: function() {
					ModalBox.close();
				},

				/**
				 * Adds new server item to server list button handler.
				 */
				onAddMailServer: function() {
					if(this.getIsFeatureDisabled("NewMailboxSettingsUI")){
						this._openMailServerWindow();
					} else {
						NetworkUtilities.openSectionInNewUI({
							entitySchemaName: "MailboxSettings"
						});
					}
				},

				/**
				 * Set user login if user login empty.
				 */
				setUserLogin: function() {
					var userLogin,
						userEmail = this.getSenderEmailAddress(),
						useUserNameAsLogin = this.get("UseUserNameAsLogin"),
						useLogin = this.get("UseLogin");
					if (!this.Ext.isEmpty(userEmail)) {
						if (useUserNameAsLogin) {
							var index = userEmail.indexOf("@");
							userLogin = userEmail.substring(0, index !== -1 ? index : index.length);
							this.set("UserName", userLogin);
						} else if (!useLogin) {
							this.set("UserName", userEmail);
						}
					} else {
						this.set("UserName", userEmail);
					}
				},

				/**
				 * Generates mailbox settings insert batch query.
				 * @return {Terrasoft.BatchQuery} Batch query.
				 */
				getInsertQuery: function() {
					let createSettingsBQ = this.Ext.create("Terrasoft.BatchQuery");
					const insert = this.getMailboxInsert();
					createSettingsBQ.add(insert);
					const server = this.get("SelectedServer");
					const type = server.get("Type");
					const emailDomain = this.getEmailDomain();
					const serverByDomain = this.getServerByDomain(emailDomain);
					if (type.value === ExchangeNUIConstants.MailServer.Type.Exchange) {
						createSettingsBQ.add(this.getContactSyncSettingsInsert());
					}
					if (type.value === ExchangeNUIConstants.MailServer.Type.Exchange ||
							type.value === ExchangeNUIConstants.MailServer.Type.Graph) {
						createSettingsBQ.add(this.getActivitySyncSettingsInsert());
					}
					if (Ext.isEmpty(serverByDomain)) {
						const mailDomainInsert = this.getMailServerDomainInsert(emailDomain);
						createSettingsBQ.add(mailDomainInsert);
					}
					return createSettingsBQ;
				},

				/**
				 * Generates ContactSyncSettings insert query.
				 * @virtual
				 * @return {Terrasoft.InsertQuery} ContactSyncSettings insert query.
				 */
				getContactSyncSettingsInsert: function() {
					var insert = this.Ext.create("Terrasoft.InsertQuery", {
						rootSchemaName: "ContactSyncSettings"
					});
					insert.setParameterValue("MailboxSyncSettings", this.get("MailboxSyncSettingsId"),
						Terrasoft.DataValueType.GUID);
					insert.setParameterValue("ExportContactsAll", true,
						Terrasoft.DataValueType.BOOLEAN);
					insert.setParameterValue("ImportContactsAll", true,
						Terrasoft.DataValueType.BOOLEAN);
					return insert;
				},

				/**
				 * Generates ActivitySyncSettings insert query.
				 * @virtual
				 * @return {Terrasoft.InsertQuery} ActivitySyncSettings insert query.
				 */
				getActivitySyncSettingsInsert: function() {
					var insert = this.Ext.create("Terrasoft.InsertQuery", {
						rootSchemaName: "ActivitySyncSettings"
					});
					insert.setParameterValue("MailboxSyncSettings", this.get("MailboxSyncSettingsId"),
						Terrasoft.DataValueType.GUID);
					insert.setParameterValue("ImportAppointmentsAll", true,
						Terrasoft.DataValueType.BOOLEAN);
					insert.setParameterValue("ImportTasksAll", true,
						Terrasoft.DataValueType.BOOLEAN);
					insert.setParameterValue("ExportActivitiesAll", true,
						Terrasoft.DataValueType.BOOLEAN);
					return insert;
				},

				/**
				 * Generates MailServerDomain insert query and clear exist esq cache.
				 * @virtual
				 * @return {Terrasoft.InsertQuery} MailServerDomain insert query.
				 */
				getMailServerDomainInsert: function(emailDomain) {
					const schemaName = "MailServerDomain";
					this._clearEsqCache(schemaName);
					const insert = this.Ext.create("Terrasoft.InsertQuery", {
						rootSchemaName: schemaName
					});
					const id = Terrasoft.utils.generateGUID();
					insert.setParameterValue("Id", id, Terrasoft.DataValueType.GUID);
					insert.setParameterValue("Domain", emailDomain, Terrasoft.DataValueType.TEXT);
					insert.setParameterValue("MailServer", this.$MailBoxServerId, Terrasoft.DataValueType.GUID);
					return insert;
				},

				/**
				 * Checks is contact communication with entered email exists.
				 * @param {Function} callback Callback function.
				 * @param {Object} scope Callback function context.
				 */
				checkContactEmail: function(callback, scope) {
					var userEmailAddress = this.getSenderEmailAddress();
					if (userEmailAddress.indexOf("@") === -1) {
						callback.call(scope || this);
					} else {
						this.checkEditContactRights(function(result) {
							if (!this.Ext.isEmpty(result)) {
								callback.call(scope || this);
								return;
							}
							var select = this.Ext.create("Terrasoft.EntitySchemaQuery", {
								rootSchemaName: "ContactCommunication"
							});
							select.addColumn("Id");
							this.contactEmailFilters(select, userEmailAddress);
							select.getEntityCollection(function(response) {
								var collection = response.success ? response.collection : null;
								if (collection && collection.getCount() === 0) {
									this.addEmailToContactCommunications(callback, scope);
								} else {
									if (callback) {
										callback.call(scope || this);
									}
								}
							}, this);
						}, this);
					}
				},

				/**
				 * Adds filters for contact communication select.
				 * @param {Terrasoft.EntitySchemaQuery} select Select contact communication query.
				 * @param {String} userEmailAddress Entered email address.
				 */
				contactEmailFilters: function(select, userEmailAddress) {
					select.filters.add("CommunicationType", Terrasoft.createColumnFilterWithParameter(
						Terrasoft.ComparisonType.EQUAL, "CommunicationType",
						ConfigurationConstants.CommunicationType.Email));
					select.filters.add("Number", Terrasoft.createColumnFilterWithParameter(
						Terrasoft.ComparisonType.EQUAL, "Number", userEmailAddress));
					select.filters.add("Contact", Terrasoft.createColumnFilterWithParameter(
						Terrasoft.ComparisonType.EQUAL, "Contact",
						Terrasoft.SysValue.CURRENT_USER_CONTACT.value));
				},

				/**
				 * Checks if current user can edit contact.
				 * @param {Function} callback Callback function.
				 * @param {Object} scope Callback function context.
				 */
				checkEditContactRights: function(callback, scope) {
					RightUtilities.checkCanEdit({
						schemaName: "Contact",
						primaryColumnValue: Terrasoft.SysValue.CURRENT_USER_CONTACT.value,
						isNew: false
					}, function(result) {
						if (callback) {
							callback.call(scope, result);
						}
					}, this);
				},

				/**
				 * Inserts contact communication.
				 * @param {Function} callback Callback function.
				 * @param {Object} scope Callback function context.
				 */
				insertContactCommunication: function(callback, scope) {
					var insert = this.Ext.create("Terrasoft.InsertQuery", {
						rootSchemaName: "ContactCommunication"
					});
					var id = this.Terrasoft.utils.generateGUID();
					this.contactCommunicationInsertParameters(insert, id);
					insert.execute(callback, scope || this);
				},

				/**
				 * Creates contact communication.
				 * @param {Function} callback Callback function.
				 * @param {Object} scope Callback function context.
				 */
				addEmailToContactCommunications: function(callback, scope) {
					this.insertContactCommunication(callback, scope);
				},

				/**
				 * Sets new contact communication parameters.
				 * @param {Terrasoft.InsertQuery} insert Contact communication insert query.
				 * @param {Guid} id New contact communication id.
				 */
				contactCommunicationInsertParameters: function(insert, id) {
					insert.setParameterValue("Id", id, Terrasoft.DataValueType.GUID);
					insert.setParameterValue("CommunicationType",
						ConfigurationConstants.CommunicationType.Email,
						Terrasoft.DataValueType.GUID);
					insert.setParameterValue("Contact",
						Terrasoft.SysValue.CURRENT_USER_CONTACT.value,
						Terrasoft.DataValueType.GUID);
					insert.setParameterValue("Number", this.getSenderEmailAddress(),
						Terrasoft.DataValueType.TEXT);
				},

				/**
				 * Returns MailboxSyncSettings update query.
				 * @virtual
				 * @return {Terrasoft.UpdateQuery} MailboxSyncSettings update query.
				 */
				getUpdateQuery: function() {
					const itemId = this.$MailboxSyncSettingsId;
					let update = this.Ext.create("Terrasoft.UpdateQuery", {
						rootSchemaName: "MailboxSyncSettings"
					});
					let filters = update.filters;
					let idFilter = update.createColumnFilterWithParameter(Terrasoft.ComparisonType.EQUAL,
						"Id", itemId);
					const senderEmailAddress = this.getSenderEmailAddress();
					const dataValueType = Terrasoft.DataValueType;
					const textDataValue = dataValueType.TEXT;
					const guidDataValue = dataValueType.GUID;
					const booleanDataValue = dataValueType.BOOLEAN;
					filters.add("IdFilter", idFilter);
					update.setParameterValue("Id", itemId, guidDataValue);
					update.setParameterValue("MailServer", this.$MailBoxServerId, guidDataValue);
					update.setParameterValue("UserName", this.$UserName, textDataValue);
					update.setParameterValue("UserPassword", this.$UserPassword, textDataValue);
					update.setParameterValue("SenderEmailAddress", senderEmailAddress, textDataValue);
					update.setParameterValue("MailboxName", senderEmailAddress, textDataValue);
					update.setParameterValue("SendEmailsViaThisAccount", this.$SendEmailsViaThisAccount,
						booleanDataValue);
					update.setParameterValue("ErrorCode", this.$ErrorCode, guidDataValue);
					update.setParameterValue("SynchronizationStopped", this.$SynchronizationStopped, booleanDataValue);
					return update;
				},

				/**
				 * Gets default mail synchronization date.
				 * @return {Date} Default mail synchronization date.
				 */
				getMailSyncPeriodDefault: function() {
					var currentDate = this.Ext.Date.clearTime(new Date());
					return this.Ext.Date.add(currentDate, Ext.Date.DAY, -7);
				},

				/**
				 * Shows tips and closes modal box after save.
				 * @virtual
				 * @param {Function} callback Callback function.
				 * @param {Object} scope Callback function context.
				 */
				onSaved: function(callback, scope) {
					this.sandbox.publish("AddMailBoxEvent");
					this.showTooltip();
					this.onCancel();
					this.hideBodyMask();
					if (callback) {
						callback.call(scope || this);
					}
				},

				/**
				 * Closes modal box after save.
				 * @param {Function} callback Callback function.
				 * @param {Object} scope Callback function context.
				 */
				onUpdated: function(callback, scope) {
					this.updateMailboxSyncSettings();
					this.onCancel();
					this.hideBodyMask();
					if (callback) {
						callback.call(scope || this);
					}
				},

				/**
				 * Set columns for query select
				 * @virtual
				 * @param {Terrasoft.EntitySchemaQuery} esq Select list query.
				 */
				setServerSelectColumns: function(esq) {
					esq.addColumn("Id");
					esq.addColumn("Type");
					esq.addColumn("UseLogin");
					esq.addColumn("UseUserNameAsLogin");
					esq.addColumn("UseEmailAddressAsLogin");
					esq.addColumn("Logo");
					esq.addColumn("OAuthApplication");
					esq.addColumn("OAuthApplication.AppClassName");
					esq.addColumn("AllowEmailDownloading");
					esq.addColumn("Name");
					esq.addColumn("UseImpersonation");
				},

				/**
				 * Gets authorization label value. This value used for credentials frame header.
				 * @return {String} Authorization label value.
				 */
				getAuthorizationLabel: function() {
					return this.get("ServerName");
				},

				/**
				 * Unsubscribes events handlers.
				 */
				destroy: function() {
					this.Terrasoft.ServerChannel.un(Terrasoft.EventName.ON_MESSAGE, this.onMailServersListChanged,
							this);
					this.un("change:SenderEmailAddress", function() {
						this.setUserLogin();
					}, this);
					this.callParent(arguments);
				},

				/**
				 * Calls next authorization step for the entered email address.
				 * When the sender email address is empty method will do nothing.
				 * If mail server was found by the domain, credentials step will be shown
				 * using {@link #onServerListItemClick} method.
				 * Mail servers list will be shown otherwise.
				 */
				goToAuthorization: function() {
					if (!this.validateColumn("SenderEmailAddress")) {
						return;
					}
					var emailDomain = this.getEmailDomain();
					var server = this.getServerByDomain(emailDomain);
					var mailServer = server && server.get("MailServer");
					if (this.isNotEmpty(mailServer) && !server.get("MailServer.UseImpersonation")) {
						this.onServerListItemClick(mailServer.value);
					} else {
						this.showServerList();
					}
				}

				//endregion

			},
			diff: /**SCHEMA_DIFF*/ [
			{
				"operation": "insert",
				"name": "WrapContainer",
				"propertyName": "items",
				"values": {
					"itemType": Terrasoft.ViewItemType.CONTAINER,
					"markerValue": {"bindTo": "WrapMarkerValue"},
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "MailBoxEditSettings",
				"parentName": "WrapContainer",
				"propertyName": "items",
				"values": {
					"itemType": Terrasoft.ViewItemType.CONTAINER,
					"classes": {
						"wrapClassName": ["email-settings-main-container"]
					},
					"items": [],
					"visible": {
						"bindTo": "IsServerListVisible"
					},
					"markerValue": "ServerListContainer"
				}
			}, {
				"operation": "insert",
				"name": "EmailSettingsCancelTop",
				"propertyName": "items",
				"values": {
					"itemType": Terrasoft.ViewItemType.BUTTON,
					"imageConfig": {"bindTo": "Resources.Images.CloseModal"},
					"click": {
						"bindTo": "onCancel"
					},
					"classes": {
						"textClass": ["cancel-button-top"],
						"wrapperClass": ["cancel-button-top"]
					},
					"items": [],
					"style": Terrasoft.controls.ButtonEnums.style.TRANSPARENT
				},
				"index": 0
			}, {
				"operation": "insert",
				"name": "EmailSettingsTabHeader",
				"parentName": "MailBoxEditSettings",
				"propertyName": "items",
				"values": {
					"itemType": Terrasoft.ViewItemType.LABEL,
					"caption": {"bindTo": "Resources.Strings.SelectMailService"},
					"classes": {
						"labelClass": ["emails-header-caption"]
					},
					"items": []
				},
				"index": 1
			}, {
				"operation": "insert",
				"name": "ServerList",
				"parentName": "MailBoxEditSettings",
				"propertyName": "items",
				"values": {
					"generator": "ConfigurationItemGenerator.generateContainerList",
					"idProperty": "Id",
					"classes": {
						"wrapClassName": ["server-container-list"]
					},
					"dataItemIdPrefix": "entity-mailbox-item",
					"collection": "ServerListCollection",
					"itemPrefix": "_Servers_ContainerList",
					"onGetItemConfig": "getMailItemViewConfig",
					"selectedItemCssClass": "selected-item-class",
					"rowCssSelector": ".server-list-item",
					"onItemClick": {
						"bindTo": "onServerListItemClick"
					}
				},
				"index": 2
			}, {
				"operation": "insert",
				"name": "AddNewServer",
				"parentName": "MailBoxEditSettings",
				"propertyName": "items",
				"values": {
					"itemType": Terrasoft.ViewItemType.BUTTON,
					"caption": {"bindTo": "Resources.Strings.AddNewServer"},
					"click": {
						"bindTo": "onAddMailServer"
					},
					"classes": {
						"labelClass": ["add-new-server-button"]
					},
					"visible": {
						"bindTo": "CanManageMailServers"
					},
					"items": []
				},
				"index": 3
			}, {
				"operation": "insert",
				"name": "EmailSettingsCancel",
				"parentName": "MailBoxEditSettings",
				"propertyName": "items",
				"values": {
					"itemType": Terrasoft.ViewItemType.BUTTON,
					"caption": {"bindTo": "Resources.Strings.Cancel"},
					"click": {
						"bindTo": "onCancel"
					},
					"style": Terrasoft.controls.ButtonEnums.style.BLUE,
					"classes": {
						"textClass": ["cancel-button"],
						"wrapperClass": ["cancel-button"]
					},
					"items": []
				},
				"index": 4
			}, {
				"operation": "insert",
				"name": "ServerListErrorPanel",
				"parentName": "MailBoxEditSettings",
				"propertyName": "items",
				"values": {
					"itemType": Terrasoft.ViewItemType.COMPONENT,
					"className": "Terrasoft.HtmlControl",
					"htmlContent": {
						"bindTo": "ErrorContent"
					}
				},
				"index": 5
			},
			{
				"operation": "insert",
				"name": "SetupCredentials",
				"parentName": "WrapContainer",
				"propertyName": "items",
				"values": {
					"itemType": Terrasoft.ViewItemType.CONTAINER,
					"classes": {
						"wrapClassName": ["email-credentials-main-container"]
					},
					"items": [],
					"visible": {
						"bindTo": "IsServerCredentialsVisible"
					},
					"markerValue": "SetupCredentials"
				}
			}, {
				"operation": "insert",
				"name": "CredentialsCaption",
				"parentName": "SetupCredentials",
				"propertyName": "items",
				"values": {
					"itemType": Terrasoft.ViewItemType.LABEL,
					"caption": {
						"bindTo": "getAuthorizationLabel"
					},
					"classes": {
						"labelClass": ["autorization-label", "label-credentials"]
					},
					"items": []
				}
			}, {
				"operation": "insert",
				"name": "SenderEmailAddress",
				"parentName": "SetupCredentials",
				"propertyName": "items",
				"values": {
					"id": "new-mailbox",
					"selectors": {
						"wrapEl": "#email"
					},
					"value": {
						"bindTo": "SenderEmailAddress"
					},
					"enabled": {
						"bindTo": "IsBackToServerListButtonVisible"
					},
					"controlConfig": {
						"placeholder": {"bindTo": "Resources.Strings.TypeEmailAddress"},
						"classes": ["placeholderOpacity"],
						"enterkeypressed": {
							"bindTo": "onKeyDown"
						}
					},
					"layout": {
						"column": 0,
						"row": 1,
						"colSpan": 24
					},
					"labelConfig": {
						"visible": false
					},
					"focused": {
						"bindTo": "IsLoginEditFocused"
					}
				}
			}, {
				"operation": "insert",
				"name": "UserName",
				"parentName": "SetupCredentials",
				"propertyName": "items",
				"values": {
					"id": "new-login",
					"selectors": {
						"wrapEl": "#login"
					},
					"value": {
						"bindTo": "UserName"
					},
					"placeholder": "Something",
					"layout": {
						"column": 0,
						"row": 1,
						"colSpan": 24
					},
					"labelConfig": {
						"visible": false
					},
					"controlConfig": {
						"placeholder": {"bindTo": "Resources.Strings.TypeUserName"},
						"classes": ["placeholderOpacity"],
						"enterkeypressed": {
							"bindTo": "onKeyDown"
						}
					},
					"isRequired": {
						"bindTo": "isRequiredFieldsVisible"
					},
					"visible": {
						"bindTo": "UseLogin"
					}
				}
			}, {
				"operation": "insert",
				"name": "UserPassword",
				"parentName": "SetupCredentials",
				"propertyName": "items",
				"values": {
					"id": "new-password",
					"selectors": {
						"wrapEl": "#password"
					},
					"value": {
						"bindTo": "UserPassword"
					},
					"layout": {
						"column": 0,
						"row": 1,
						"colSpan": 12
					},
					"labelConfig": {
						"visible": false
					},
					"controlConfig": {
						"placeholder": {"bindTo": "Resources.Strings.TypePassword"},
						"classes": ["placeholderOpacity"],
						"protect": true,
						"enterkeypressed": {
							"bindTo": "onKeyDown"
						}
					},
					"isRequired": {
						"bindTo": "isRequiredFieldsVisible"
					},
					"focused": {
						"bindTo": "IsPasswordEditFocused"
					}
				}
			}, {
				"operation": "insert",
				"name": "ErrorPanel",
				"parentName": "SetupCredentials",
				"propertyName": "items",
				"values": {
					"itemType": Terrasoft.ViewItemType.COMPONENT,
					"className": "Terrasoft.HtmlControl",
					"htmlContent": {
						"bindTo": "ErrorContent"
					}
				}
			}, {
				"operation": "insert",
				"name": "Save",
				"parentName": "SetupCredentials",
				"propertyName": "items",
				"values": {
					"itemType": Terrasoft.ViewItemType.BUTTON,
					"caption": {"bindTo": "Resources.Strings.SignIn"},
					"click": {
						"bindTo": "onSave"
					},
					"style": Terrasoft.controls.ButtonEnums.style.GREEN,
					"classes": {
						"textClass": ["login-button"],
						"wrapperClass": ["login-button "]
					},
					"markerValue": "SignIn",
					"items": []
				}
			}, {
				"operation": "insert",
				"name": "ShowServerListButton",
				"parentName": "SetupCredentials",
				"propertyName": "items",
				"values": {
					"itemType": Terrasoft.ViewItemType.BUTTON,
					"caption": {"bindTo": "Resources.Strings.BackToServerList"},
					"click": {
						"bindTo": "showServerList"
					},
					"classes": {
						"textClass": ["back-to-list-button"],
						"wrapperClass": ["cancel-button"]
					},
					"visible": {
						"bindTo": "IsBackToServerListButtonVisible"
					},
					"items": []
				}
			}, {
				"operation": "insert",
				"name": "EnterEmail",
				"parentName": "WrapContainer",
				"propertyName": "items",
				"values": {
					"itemType": Terrasoft.ViewItemType.CONTAINER,
					"classes": {
						"wrapClassName": ["email-credentials-first-container"]
					},
					"items": [],
					"visible": {"bindTo": "IsEnterEmailPanelVisible"},
					"markerValue": "EnterEmail"
				}
			}, {
				"operation": "insert",
				"name": "EnterEmailCaption",
				"parentName": "EnterEmail",
				"propertyName": "items",
				"values": {
					"itemType": Terrasoft.ViewItemType.LABEL,
					"caption": {"bindTo": "Resources.Strings.EnterEmail"},
					"classes": {
						"labelClass": ["autorization-label", "label-credentials"]
					},
					"items": []
				},
				"index": 1
			}, {
				"operation": "insert",
				"name": "StartSenderEmailAddress",
				"parentName": "EnterEmail",
				"propertyName": "items",
				"values": {
					"bindTo": "SenderEmailAddress",
					"controlConfig": {
						"placeholder": {"bindTo": "Resources.Strings.TypeEmailAddress"},
						"classes": ["placeholderOpacity"],
						"enterkeypressed": {"bindTo": "goToAuthorization"}
					},
					"layout": {
						"column": 0,
						"row": 1,
						"colSpan": 24
					},
					"labelConfig": {"visible": false},
					"focused": true
				},
				"index": 2
			}, {
				"operation": "insert",
				"name": "NextStepButton",
				"parentName": "EnterEmail",
				"propertyName": "items",
				"values": {
					"itemType": Terrasoft.ViewItemType.BUTTON,
					"caption": {"bindTo": "Resources.Strings.Next"},
					"click": {"bindTo": "goToAuthorization"},
					"style": Terrasoft.controls.ButtonEnums.style.BLUE,
					"classes": {
						"textClass": ["login-button"],
						"wrapperClass": ["login-button"]
					},
					"markerValue": "NextStep",
					"items": []
				},
				"index": 3
			}, {
				"operation": "insert",
				"name": "NewEmailSettingsCancel",
				"parentName": "EnterEmail",
				"propertyName": "items",
				"values": {
					"itemType": Terrasoft.ViewItemType.BUTTON,
					"caption": {"bindTo": "Resources.Strings.Cancel"},
					"click": {
						"bindTo": "onCancel"
					},
					"classes": {
						"textClass": ["back-to-list-button"],
						"wrapperClass": ["cancel-button"]
					},
					"items": []
				},
				"index": 4
			}]/**SCHEMA_DIFF*/
		};
	});
