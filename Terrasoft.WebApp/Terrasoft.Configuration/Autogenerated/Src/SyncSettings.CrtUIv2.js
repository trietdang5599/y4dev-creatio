define("SyncSettings", ["ModalBox", "ExchangeNUIConstants", "RightUtilities", "ConfigurationConstants", "SyncSettingsLicenseUtils",
		"SyncSettingsResources", "css!SyncSettingsTabModule", "CredentialsSyncSettingsMixin", "SyncSettingsMixin"],
		function(ModalBox, ExchangeNUIConstants, RightUtilities, ConfigurationConstants, SyncSettingsLicenseUtils) {
	return {
		entitySchemaName: "MailboxSyncSettings",
		mixins: {
			/**
			 * @class CasePageUtilitiesV2 implements quick save cards in one click.
			 */
			CredentialsSyncSettingsMixin: "Terrasoft.CredentialsSyncSettingsMixin",
			/**
			* Implements license check for email/calendar synchronization
			*/
			SyncSettingsLicenseUtils: "Terrasoft.utilities.SyncSettingsLicenseUtils",

			SyncSettingsMixin: "Terrasoft.SyncSettingsMixin"
		},
		attributes: {
			/**
			 * Settings page tabs collection.
			 */
			"TabsCollection": {
				dataValueType: this.Terrasoft.DataValueType.COLLECTION
			},
			/**
			 * Saved tabs collection.
			 */
			"SavedTabsCollection": {
				dataValueType: this.Terrasoft.DataValueType.COLLECTION
			},
			/**
			 * Active tab name.
			 */
			"ActiveTabName": {
				dataValueType: this.Terrasoft.DataValueType.TEXT
			},
			/**
			 * Page ready state flag.
			 */
			"IsReady": {
				dataValueType: this.Terrasoft.DataValueType.BOOLEAN,
				value: false,
				dependencies: [
					{
						columns: ["RecordId"],
						methodName: "onRecordIdChanged"
					}
				]
			},
			/**
			 * Flag is page saved.
			 */
			"IsSaved": {
				dataValueType: this.Terrasoft.DataValueType.BOOLEAN,
				value: true
			},
			/**
			 * Auto synchronization contacts is enabled.
			 */
			"ExchangeAutoSynchronizationContacts": {
				dataValueType: this.Terrasoft.DataValueType.BOOLEAN,
				value: false
			},
			/**
			 * Auto synchronization activities is enabled.
			 */
			"ExchangeAutoSynchronizationActivity": {
				dataValueType: this.Terrasoft.DataValueType.BOOLEAN,
				value: false
			},
			/**
			 * MailboxSyncSettings record id.
			 */
			"RecordId": {
				dataValueType: this.Terrasoft.DataValueType.GUID
			},
			/**
			 * Mailbox synchronization interval.
			 */
			"MailboxSyncInterval": {
				dataValueType: Terrasoft.DataValueType.INTEGER,
				value: 1
			},
		},
		messages: {
			/**
			 * @message GetMailboxSyncSettingValues
			 * Returns column values of setting.
			 */
			"GetMailboxSyncSettingValues": {
				mode: this.Terrasoft.MessageMode.PTP,
				direction: this.Terrasoft.MessageDirectionType.SUBSCRIBE
			},
			/**
			 * @message TabSaved
			 * Message fires when tab saved.
			 */
			"TabSaved": {
				mode: this.Terrasoft.MessageMode.PTP,
				direction: this.Terrasoft.MessageDirectionType.SUBSCRIBE
			},
			/**
			 * @message TabInitialized
			 * Message fires when tab initialized.
			 */
			"TabInitialized": {
				mode: this.Terrasoft.MessageMode.PTP,
				direction: this.Terrasoft.MessageDirectionType.SUBSCRIBE
			},
			/**
			 * @message GetHistoryState
			 * Returns current history state.
			 */
			"GetHistoryState": {
				mode: this.Terrasoft.MessageMode.PTP,
				direction: this.Terrasoft.MessageDirectionType.PUBLISH
			},

			/**
			 * @message PushHistoryState
			 * Modifies history state.
			 */
			"PushHistoryState": {
				mode: this.Terrasoft.MessageMode.BROADCAST,
				direction: this.Terrasoft.MessageDirectionType.PUBLISH
			},

			/**
			 * @message BackHistoryState
			 * Changes current history state to the previous state.
			 */
			"BackHistoryState": {
				"mode": Terrasoft.MessageMode.BROADCAST,
				"direction": Terrasoft.MessageDirectionType.PUBLISH
			},

			/**
			 * @message SaveSettings
			 * Invoke save in tabs.
			 */
			"SaveSettings": {
				"mode": Terrasoft.MessageMode.BROADCAST,
				"direction": Terrasoft.MessageDirectionType.PUBLISH
			},

			/**
			 * @message ReloadSettings
			 * Reloads settings parameters.
			 */
			"ReloadSettings": {
				"mode": Terrasoft.MessageMode.PTP,
				"direction": Terrasoft.MessageDirectionType.SUBSCRIBE
			},

			/**
			 * @message ReloadTabs
			 * Invoke tabs reload.
			 */
			"ReloadTabs": {
				"mode": Terrasoft.MessageMode.BROADCAST,
				"direction": Terrasoft.MessageDirectionType.PUBLISH
			},

			/**
			 * @message ChangeHeaderCaption
			 * Sets header parameters.
			 */
			"ChangeHeaderCaption": {
				"mode": Terrasoft.MessageMode.PTP,
				"direction": Terrasoft.MessageDirectionType.PUBLISH
			},

			/**
			 * @message NeedHeaderCaption
			 * Gets header parameters request.
			 */
			"NeedHeaderCaption": {
				"mode": Terrasoft.MessageMode.BROADCAST,
				"direction": Terrasoft.MessageDirectionType.SUBSCRIBE
			},

			/**
			 * @message InitDataViews
			 * Sends header parameters on request.
			 */
			"InitDataViews": {
				"mode": Terrasoft.MessageMode.PTP,
				"direction": Terrasoft.MessageDirectionType.PUBLISH
			},

			/**
			 * @message InitDataViews
			 * Sends the message that the tab is rerendered.
			 */
			"RerenderTab": {
				"mode": Terrasoft.MessageMode.BROADCAST,
				"direction": Terrasoft.MessageDirectionType.PUBLISH
			},

			/**
			 * @message ShowSaveButton
			 * Shows save button.
			 */
			"ShowSaveButton": {
				"mode": Terrasoft.MessageMode.PTP,
				"direction": Terrasoft.MessageDirectionType.SUBSCRIBE
			},
			/**
			 * @message UpdateSection
			 * Page header click message.
			 */
			"UpdateSection": {
				"mode": Terrasoft.MessageMode.PTP,
				"direction": Terrasoft.MessageDirectionType.SUBSCRIBE
			}
		},
		methods: {

			//region methods: private

			/**
			 * Sets current sender email address to clipboard.
			 * @private
			 */
			_copyEmailToClipboard: function() {
				let input = document.getElementById("copyInput");
				if (input === null) {
					input = document.createElement("input");
					input.id = "copyInput";
					input.style.position = "absolute";
					input.style.top = "-100px";
					document.body.append(input);
					input = document.getElementById("copyInput");
				}
				input.value = this.get("SenderEmailAddress");
				input.select();
				document.execCommand("copy");
			},

			//endregion

			/**
			 * @inheritdoc Terrasoft.BaseSchemaViewModel#init
			 * @overridden
			 */
			init: function(callback, scope) {
				this.callParent([function() {
					this.Terrasoft.chain(
						this.initParameters,
						this.setHasGoogleAccount,
						this.initEntity,
						this.setSyncInterval,
						this.onEntityInitialized,
						SyncSettingsLicenseUtils.initUserLicOperationsRights,
						this.executeAsyncInitFunctions,
						function() {
							callback.call(scope || this);
						}, this);
				}, this]);
			},

			/**
			 * Executes async init functions.
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback function context.
			 */
			executeAsyncInitFunctions: function(callback, scope) {
				this.subscribeSandboxEvents();
				this.initTabs();
				this.initHeader();
				if (callback) {
					callback.call(scope || this);
				}
			},

			/**
			 * Sets initial parameters of mailbox settings.
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback function context.
			 */
			initParameters: function(callback, scope) {
				var historyState = this.sandbox.publish("GetHistoryState");
				var state = historyState.state || {};
				this.setParameters(state);
				this.initSaveTabsCollection();
				callback.call(scope || this);
			},

			/**
			 * Sets mailbox synchronization interval.
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback execution scope.
			 */
			setSyncInterval: function(callback, scope) {
				this.Terrasoft.SysSettings.querySysSettingsItem("MailboxSyncInterval", function(value) {
					if (this.isNotEmpty(value)) {
						this.set("MailboxSyncInterval", value);
					}
					this.Ext.callback(callback, scope || this);
				},
				this);
			},

			/**
			 * Returns entity schema query for getting google communication.
			 * @private
			 * @return {Terrasoft.EntitySchemaQuery} Entity schema query.
			 */
			setHasGoogleAccount: function(callback, scope) {
				let esq = this.mixins.SyncSettingsMixin.getGoogleCommunicationEsq.call(this);

				esq.getEntityCollection(function(response) {
					if (!response.success) {
						return;
					}
					const hasGoogleAccount = response.collection.collection.length > 0;
					this.set("HasGoogleAccount", hasGoogleAccount);
				}, this);


				if (callback) {
					callback.call(scope || this);
				}
			},

			/**
			 * Sets settings parameters from config.
			 * @param {Object} config Parameters.
			 * @param {Guid} config.recordId Settings record id.
			 * @param {String} [config.activeTabName] Tab to open.
			 */
			setParameters: function(config) {
				var recordId = config.recordId;
				var activeTabName = config.activeTabName;
				this.set("ActiveTabName", activeTabName);
				this.set("RecordId", recordId);
			},

			/**
			 * Init SaveTabsCollection for tabs.
			 * @protected
			 */
			initSaveTabsCollection: function() {
				var saveTabsCollection = this.Ext.create("Terrasoft.Collection");
				this.set("SavedTabsCollection", saveTabsCollection);
			},

			/**
			 * Sets default values for tab when it initialized.
			 * @protected
			 * @param {String} tabName Loaded tab name.
			 */
			setSaveTabCollectionItemDefaults: function(tabName) {
				var saveTabsCollection = this.get("SavedTabsCollection");
				if (!saveTabsCollection.contains(tabName)) {
					var newTab = this.Ext.create("Terrasoft.BaseViewModel", {
						values: {
							"isSaved": false
						}
					});
					saveTabsCollection.add(tabName, newTab);
				}
			},

			/**
			 * Set default values for SaveTabsCollection.
			 * @protected
			 * @param {Object} saveTabsCollection Tabs saved flags.
			 */
			setSaveTabsCollectionDefaults: function(saveTabsCollection) {
				saveTabsCollection.each(function(item) {
					item.set("isSaved", false);
				});
			},

			/**
			 * Sets ready flag false on record id change.
			 * @protected
			 */
			onRecordIdChanged: function() {
				this.set("IsReady", false);
			},

			/**
			 * Initializes schema entity.
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback function context.
			 */
			initEntity: function(callback, scope) {
				var recordId = this.get("RecordId");
				var esq = this.getSettingsEsq();
				this.setEsqFilters(esq);
				esq.getEntity(recordId, function(result) {
					this.onEntityResponse(result);
					callback.call(scope || this);
				}, this);
			},

			/**
			 * Generates entity schema query for mailbox sync settings.
			 * @return {Terrasoft.EntitySchemaQuery} Entity schema query.
			 */
			getSettingsEsq: function() {
				var settingsEsq = this.Ext.create("Terrasoft.EntitySchemaQuery", {
					rootSchemaName: "MailboxSyncSettings"
				});
				this.Terrasoft.each(this.columns, function(column, columnName) {
					if (column.type === this.Terrasoft.ViewModelColumnType.ENTITY_COLUMN &&
							columnName !== "OAuthTokenStorage" && !settingsEsq.columns.contains(columnName)) {
						settingsEsq.addColumn(columnName);
					}
				}, this);
				settingsEsq.addColumn("MailServer.Type.Id", "ServerTypeId");
				settingsEsq.addColumn("MailServer.AllowEmailDownloading", "AllowEmailDownloading");
				settingsEsq.addColumn("MailServer.AllowEmailSending", "AllowEmailSending");
				settingsEsq.addColumn("MailServer.SMTPServerAddress", "SMTPServerAddress");
				settingsEsq.addColumn("MailServer.Address", "IMAPAddress");
				settingsEsq.addColumn("MailServer.UseLogin", "UseLogin");
				settingsEsq.addColumn("MailServer.UseUserNameAsLogin", "UseUserNameAsLogin");
				settingsEsq.addColumn("MailServer.UseEmailAddressAsLogin", "UseEmailAddressAsLogin");
				settingsEsq.addColumn("MailServer.OAuthApplication", "OAuthApplication");
				settingsEsq.addColumn("MailServer.UseImpersonation", "UseImpersonation");
				return settingsEsq;
			},

			/**
			 * Sets entity schema filters.
			 * @param {Terrasoft.EntitySchemaQuery} esq Entity schema query.
			 */
			setEsqFilters: function(esq) {
				var filterSysAdminUnit = esq.createColumnFilterWithParameter(
					this.Terrasoft.ComparisonType.EQUAL, "SysAdminUnit", this.Terrasoft.SysValue.CURRENT_USER.value);
				esq.filters.add("filterSysAdminUnit", filterSysAdminUnit);
			},

			/**
			 * Sets result data in view model columns.
			 * @param {Object} response Server data response.
			 */
			onEntityResponse: function(response) {
				if (response.success) {
					var entity = response.entity;
					this.Terrasoft.each(entity.columns, function(column, columnName) {
						this.set(columnName, entity.get(columnName));
					}, this);
				}
			},

			/**
			 * Sets ready flag after entity initialized.
			 * @protected
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback function context.
			 */
			onEntityInitialized: function(callback, scope) {
				this.set("IsReady", true);
				if (callback) {
					callback.call(scope || this);
				}
			},

			/**
			 * Reloads settings state.
			 * @param {Object} config Parameters.
			 * @param {Guid} config.recordId Settings record id.
			 * @param {String} [config.activeTabName] Tab to open.
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback function context.
			 */
			reloadSettings: function(config, callback, scope) {
				this.setParameters(config);
				this.Terrasoft.chain(
					this.initEntity,
					this.onEntityInitialized,
					this.executeAsyncInitFunctions,
					function() {
						this.sandbox.publish("ReloadTabs");
						this.set("IsSaved", true);
						if (callback) {
							callback.call(scope || this);
						}
					}, this);
			},

			/**
			 * Subscribes for sandbox messages.
			 */
			subscribeSandboxEvents: function() {
				this.sandbox.subscribe("GetMailboxSyncSettingValues", this.onGetMailboxSyncSettingValues, this);
				this.sandbox.subscribe("ReloadSettings", this.reloadSettings, this);
				this.sandbox.subscribe("NeedHeaderCaption", this.sendHeaderConfig, this);
				this.sandbox.subscribe("TabSaved", this.setTabSaved, this);
				this.sandbox.subscribe("TabInitialized", this.setSaveTabCollectionItemDefaults, this);
				this.sandbox.subscribe("ShowSaveButton", this.showSaveButton, this);
				this.sandbox.subscribe("UpdateSection", this._copyEmailToClipboard, this,
					[this.sandbox.id + "_UpdateSection"]);
			},

			/**
			 * Set values in SavedTabsCollection.
			 * @protected
			 * @param {String} tabconfig Saved tab value config.
			 */
			setTabSaved: function(tabconfig) {
				var tabSavedCollection = this.get("SavedTabsCollection");
				var tab = tabSavedCollection.get(tabconfig.tabName);
				this.Terrasoft.each(tabconfig.values, function(value, itemName) {
					tab.set(itemName, value);
				}, this);
				if (this.IsAllTabsSaved(tabSavedCollection)) {
					this.updateSyncSettingsParameters(tabSavedCollection);
					this.createOrDeleteSyncJob();
					this.setSaveTabsCollectionDefaults(tabSavedCollection);
					this.set("IsSaved", true);
					this.set("IsReady", true);
				}
			},

			/**
			 * Updates sync settings parameters.
			 * @protected
			 */
			updateSyncSettingsParameters: function(collection) {
				var emailSettingsTab = collection.find("EmailSettingsTab");
				var setTabAtributes = function(settingsTabMap, settingsTab) {
					this.Terrasoft.each(settingsTabMap, function(valueName, attributeName) {
						this.set(attributeName, settingsTab.get(valueName));
					}, this);
				};
				if (!this.Ext.isEmpty(emailSettingsTab)) {
					var emailSettingsTabMap = {
						"EnableMailSynhronization": "enableMailSynhronization",
						"AutomaticallyAddNewEmails": "automaticallyAddNewEmails",
						"SendEmailsViaThisAccount": "sendEmailsViaThisAccount"
					};
					setTabAtributes.call(this, emailSettingsTabMap, emailSettingsTab);
				}
				var activitySyncSettingsTab = collection.find("ActivitySyncSettingsTab");
				if (!this.Ext.isEmpty(activitySyncSettingsTab)) {
					var activitySyncSettingsTabMap = {
						"ExchangeAutoSynchronizationActivity": "exchangeAutoSynchronizationActivity",
						"ImportAppointments": "importAppointments",
						"ImportTasks": "importTasks",
						"ExportActivities": "exportActivities"
					};
					setTabAtributes.call(this, activitySyncSettingsTabMap, activitySyncSettingsTab);
				}
				var contactSettingsTab = collection.find("ContactSettingsTab");
				if (!this.Ext.isEmpty(contactSettingsTab)) {
					var contactSettingsTabMap = {
						"ExchangeAutoSynchronizationContacts": "exchangeAutoSynchronizationContacts",
						"ImportContacts": "importContacts",
						"ExportContacts": "exportContacts"
					};
					setTabAtributes.call(this, contactSettingsTabMap, contactSettingsTab);
				}
			},

			/**
			 * Creates auto synchronization jobs.
			 * @protected
			 */
			createOrDeleteSyncJob: function() {
				const canUseExchangeActivitySync = this.canUseExchangeActivitySync();
				const interval = parseInt(this.get("EmailsCyclicallyAddingInterval"), 10);
				const data = {
					create: this.get("EnableMailSynhronization") && this.get("AutomaticallyAddNewEmails"),
					mailboxName: this.get("MailboxName"),
					interval: interval,
					serverId: this.get("MailServer").value,
					senderEmailAddress: this.get("SenderEmailAddress"),
					createContactJob: this.get("ExchangeAutoSynchronizationContacts") && (this.get("ImportContacts") ||
						this.get("ExportContacts")),
					createActivityJob: canUseExchangeActivitySync && this.get("ExchangeAutoSynchronizationActivity") &&
						(this.get("ImportAppointments") || this.get("ImportTasks") || this.get("ExportActivities")
						|| this.getIsFeatureEnabled("NewMeetingIntegration")),
					contactActivityInterval: this.get("ContactSyncInterval"),
					activityInterval: this.getIsFeatureEnabled("NewMeetingIntegration") ? this.get("MailboxSyncInterval") :
						this.get("ExchangeSyncInterval")
				};
				this.callService({
					serviceName: "MailboxSettingsService",
					methodName: "CreateDeleteSyncJob",
					data: data
				}, function(response) {
					if (!this.Ext.isEmpty(response.CreateDeleteSyncJobResult)) {
						this.showInformationDialog(response.CreateDeleteSyncJobResult);
					} else {
						this.checkContactEmail(this.checkIsProviderSMTPAddressSet, this);
					}
				});
			},

			/**
			 * Checks contact email.
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback scope.
			 * @protected
			 */
			checkContactEmail: function(callback, scope) {
				var userEmailAddress = this.get("SenderEmailAddress");
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
								callback.call(scope || this);
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
			 * Checks if provider SMTP adress set. Show message if provider SMTP adress is not exist.
			 * @protected
			 */
			checkIsProviderSMTPAddressSet: function() {
				var imapType = ExchangeNUIConstants.MailServer.Type.Imap;
				var serverType = this.get("ServerTypeId");
				if (this.get("SendEmailsViaThisAccount") && (serverType === imapType)) {
					this.getIsProviderSMTPAddressSet();
				}
			},

			/**
			 * Gets flag if provider SMTP adress set, show message if this flag is not true.
			 * @protected
			 */
			getIsProviderSMTPAddressSet: function() {
				var mailServer = this.get("MailServer");
				var mailServerId = mailServer ? mailServer.value : null;
				if (this.Ext.isEmpty(mailServerId) || this.Ext.isEmpty(this.get("SMTPServerAddress"))) {
					this.showInformationDialog("Resources.Strings.SMTPSettingsNotSetMessage");
				}
			},

			/**
			 * Checks if current user can edit contact.
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback scope.
			 * @protected
			 */
			checkEditContactRights: function(callback, scope) {
				RightUtilities.checkCanEdit({
					schemaName: "Contact",
					primaryColumnValue: Terrasoft.SysValue.CURRENT_USER_CONTACT.value,
					isNew: false
				}, function(result) {
					callback.call(scope, result);
				}, this);
			},

			/**
			 * Adds email to contact communication.
			 * @param {Function} callback Callback function.
			 * @protected
			 */
			addEmailToContactCommunications: function(callback, scope) {
				Terrasoft.utils.showConfirmation(this.get("Resources.Strings.AddToCommunicationDetail"),
					function(returnCode) {
						if (returnCode === Terrasoft.MessageBoxButtons.YES.returnCode) {
							var insert = this.Ext.create("Terrasoft.InsertQuery", {
								rootSchemaName: "ContactCommunication"
							});
							var id = this.Terrasoft.utils.generateGUID();
							this.contactCommunicationInsertParameters(insert, id);
							insert.execute(callback, scope || this);
						} else {
							callback.call(scope || this);
						}
					}, ["yes", "no"], this);
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
				insert.setParameterValue("Number", this.get("SenderEmailAddress"),
					Terrasoft.DataValueType.TEXT);
			},

			/**
			 * Check if all tabs was saved.
			 * @protected
			 * @return {Object} Flag if all tabs was saved.
			 */
			IsAllTabsSaved: function(saveTabsCollection) {
				var filteredSaveTabsCollection = saveTabsCollection.filterByFn(function(item) {
					return !item.get("isSaved");
				}, this);
				return filteredSaveTabsCollection.isEmpty();
			},

			/**
			 * Checks is password change allowed for current mailbox.
			 * @protected
			 * @return {Boolean} True if password change allowed, false otherwise.
			 */
			getChangePasswordAllowed: function() {
				return this.isEmpty(this.$OAuthApplication) && !this.$UseImpersonation;
			},

			/**
			 * Sends header init message.
			 */
			sendHeaderConfig: function() {
				var headerConfig = this.getHeaderConfig();
				this.sandbox.publish("InitDataViews", headerConfig, this);
			},

			/**
			 * Returns header config.
			 * @return {Object} Header config.
			 */
			getHeaderConfig: function() {
				var headerCaptionTpl = this.get("Resources.Strings.HeaderCaptionTpl");
				var email = this.get("SenderEmailAddress");
				return {
					"isMainMenu": false,
					"caption": this.Ext.String.format(headerCaptionTpl, email),
					"dataViews": this.Ext.create("Terrasoft.Collection"),
					"moduleName": this.sandbox.id
				};
			},

			/**
			 * Initializes page header.
			 */
			initHeader: function() {
				var headerConfig = this.getHeaderConfig();
				this.sandbox.publish("ChangeHeaderCaption", headerConfig);
			},

			/**
			 * Returns column values.
			 * @param {Object} config Values request config.
			 * @param {Array} [config.columns] Requested columns.
			 * @param {Boolean} [config.all] Request all columns flag.
			 */
			onGetMailboxSyncSettingValues: function(config) {
				var columns = config.all ? this.entitySchema.columns : config.columns;
				var result = {};
				this.Terrasoft.each(columns, function(column, columnName) {
					columnName = this.Ext.isObject(column) ? columnName : column;
					var value = this.get(columnName);
					result[columnName] = this.Terrasoft.deepClone(value);
				}, this);
				return result;
			},

			/**
			 * Initializes start tabs parameters.
			 */
			initTabs: function() {
				var activeTabName = this.get("ActiveTabName") || "EmailSettingsTab";
				this.setActiveTab(activeTabName);
				var tabsCollection = this.get("TabsCollection");
				tabsCollection.fireEvent("dataLoaded", tabsCollection, tabsCollection.getItems());
			},

			/**
			 * Check if should show calendar tab for Google configuration.
			 */
			showCalendarForGoogle: function(tabName) {
				const isGoogleTab = tabName === "GoogleActivitySettingsTab";
				const imapType = ExchangeNUIConstants.MailServer.Type.Imap;
				const hasGoogleAccount = this.get("HasGoogleAccount");
				const isGoogleMultidomainEnabled = this.getIsFeatureEnabled("GoogleMultidomain");
				return isGoogleTab && this.get("ServerTypeId") == imapType && hasGoogleAccount && isGoogleMultidomainEnabled;
			},

			/**
			 * Checks whether mailbox can use Exchange-family activity synchronization.
			 * @protected
			 * @return {Boolean} True when activity synchronization is available for Exchange or Graph mailboxes.
			 */
			canUseExchangeActivitySync: function() {
				var serverType = this.get("ServerTypeId");
				return serverType === ExchangeNUIConstants.MailServer.Type.Exchange
					|| serverType === ExchangeNUIConstants.MailServer.Type.Graph;
			},

			/**
			 * Hides calendar and contact tabs for imap settings.
			 * @protected
			 * @param {Object} tabConfig Tab config.
			 */
			onTabRender: function(tabConfig) {
				const html = tabConfig.html;
				const tabName = tabConfig.tab.get("Name");
				const showCalendarForGoogle = this.showCalendarForGoogle(tabName);
				const canUseExchangeActivitySync = this.canUseExchangeActivitySync();

				if ((!showCalendarForGoogle && tabName === "GoogleActivitySettingsTab") ||
					(!canUseExchangeActivitySync && tabName === "ActivitySettingsTab")) {
					tabConfig.html = html.replace("style=\"\"", "style=\"display: none;\"");
				}
			},

			/**
			 * Active tab change handler.
			 * @param {Terrasoft.BaseViewModel} activeTab Current active tab view model.
			 */
			onActiveTabChange: function(activeTab) {
				const activeTabName = activeTab.get("Name");
				this.setActiveTab(activeTabName);
			},

			/**
			 * Sets tabs containers visibility to false.
			 */
			closeTabs: function() {
				var tabsCollection = this.get("TabsCollection");
				tabsCollection.eachKey(function(tabName, tab) {
					var tabContainerVisibleBinding = tab.get("Name");
					this.set(tabContainerVisibleBinding, false);
				}, this);
			},

			/**
			 * Sets active tab.
			 * @param {String} activeTabName Tab name to set active.
			 */
			setActiveTab: function(activeTabName) {
				this.closeTabs();
				this.set("ActiveTabName", activeTabName);
				this.set(activeTabName, true);
			},

			/**
			 * Save button handler.
			 * @protected
			 */
			onSave: function() {
				this.set("IsReady", false);
				this.sandbox.publish("SaveSettings");
			},

			/**
			 * Cancel button handler.
			 */
			onCancel: function() {
				this.sandbox.publish("BackHistoryState");
			},

			/**
			 * Generates data item marker for page container.
			 * @return {String} Data item marker for page container.
			 */
			getReadyMarkerValue: function() {
				var email = this.get("SenderEmailAddress");
				return this.get("IsReady") ? ("SyncSettingsReady " + email) : "Loading";
			},

			/**
			 * Sends rerender message for tab modules.
			 * @protected
			 * @param {Object} config Rerender parameters.
			 */
			afterrerender: function(config) {
				this.sandbox.publish("RerenderTab", config);
			},

			/**
			 * Opens change password popup.
			 * @protected
			 */
			onChangePassword: function() {
				var mailserver = this.$MailServer;
				var mailbox = {
					id: this.$Id,
					senderEmailAddress: this.$SenderEmailAddress,
					mailServerId: mailserver.value,
					mailServerName: mailserver.displayValue,
					userName: this.$UserName,
					useLogin: this.$UseLogin,
					useEmailAddressAsLogin: this.$UseEmailAddressAsLogin,
					useUserNameAsLogin: this.$UseUserNameAsLogin,
					sendEmailsViaThisAccount: this.$SendEmailsViaThisAccount,
					enableMailSynhronization: this.$EnableMailSynhronization
				};
				this.openCredentialsSyncSettingsEdit(mailbox);
			},

			/**
			 * Get inverse value.
			 * @protected
			 * @deprecated Use {@link #Terrasoft.BaseModel.invertBooleanValue}.
			 * @param {Boolean} value Value.
			 * @return {Boolean} Inverse value.
			 */
			inverseValue: function(value) {
				return !value;
			},

			/**
			 * Shows save button.
			 */
			showSaveButton: function() {
				this.set("IsSaved", false);
			},
		},
		diff: [
			{
				"operation": "insert",
				"name": "SyncSettingsContainer",
				"values": {
					"itemType": Terrasoft.ViewItemType.CONTAINER,
					"items": [],
					"markerValue": {"bindTo": "getReadyMarkerValue"},
					"classes": {"wrapClassName": ["sync-settings-page"]}
				}
			},
			{
				"operation": "insert",
				"parentName": "SyncSettingsContainer",
				"propertyName": "items",
				"name": "SaveButton",
				"values": {
					"itemType": Terrasoft.ViewItemType.BUTTON,
					"caption": {"bindTo": "Resources.Strings.SaveButtonCaption"},
					"classes": {"textClass": "actions-button-margin-right"},
					"click": {"bindTo": "onSave"},
					"style": Terrasoft.controls.ButtonEnums.style.GREEN,
					"markerValue": "SaveButton",
					"visible": {
						"bindTo": "IsSaved",
						"bindConfig": {"converter": "invertBooleanValue"}
					}
				}
			},
			{
				"operation": "insert",
				"parentName": "SyncSettingsContainer",
				"propertyName": "items",
				"name": "CloseButton",
				"values": {
					"itemType": Terrasoft.ViewItemType.BUTTON,
					"caption": {"bindTo": "Resources.Strings.CloseButtonCaption"},
					"classes": {"textClass": "actions-button-margin-right"},
					"click": {"bindTo": "onCancel"},
					"style": Terrasoft.controls.ButtonEnums.style.BLUE,
					"markerValue": "CloseButton",
					"visible": {bindTo: "IsSaved"}
				}
			},
			{
				"operation": "insert",
				"parentName": "SyncSettingsContainer",
				"propertyName": "items",
				"name": "CancelButton",
				"values": {
					"itemType": Terrasoft.ViewItemType.BUTTON,
					"caption": {"bindTo": "Resources.Strings.CancelButtonCaption"},
					"classes": {"textClass": "actions-button-margin-right"},
					"click": {"bindTo": "onCancel"},
					"markerValue": "CancelButton",
					"visible": {
						"bindTo": "IsSaved",
						"bindConfig": {"converter": "invertBooleanValue"}
					}
				}
			},
			{
				"operation": "insert",
				"parentName": "SyncSettingsContainer",
				"propertyName": "items",
				"name": "ChangeEmailSettings",
				"values": {
					"itemType": Terrasoft.ViewItemType.BUTTON,
					"caption": {"bindTo": "Resources.Strings.ChangeEmailSettings"},
					"classes": {"textClass": "actions-button-margin-right"},
					"click": {"bindTo": "onChangePassword"},
					"markerValue": "ChangePassword",
					"visible": {"bindTo": "getChangePasswordAllowed"}
				}
			},
			{
				"operation": "insert",
				"parentName": "SyncSettingsContainer",
				"name": "TabsPanel",
				"propertyName": "items",
				"values": {
					"itemType": Terrasoft.ViewItemType.TAB_PANEL,
					"activeTabChange": {"bindTo": "onActiveTabChange"},
					"activeTabName": {"bindTo": "ActiveTabName"},
					"tabRender": {"bindTo": "onTabRender"},
					"collection": {"bindTo": "TabsCollection"},
					"tabs": []
				}
			},
			{
				"operation": "insert",
				"parentName": "TabsPanel",
				"name": "EmailSettingsTab",
				"propertyName": "tabs",
				"values": {
					caption: {"bindTo": "Resources.Strings.EmailSettingsTabCaption"},
					"items": []
				}
			},
			{
				"operation": "insert",
				"parentName": "EmailSettingsTab",
				"name": "EmailSettingsModule",
				"propertyName": "items",
				"values": {
					"moduleId": "SyncSettings_EmailSyncSettingsSchemaModule",
					"itemType": Terrasoft.ViewItemType.MODULE,
					"moduleName": "SyncSettingsTabModule",
					"instanceConfig": {
						"isSchemaConfigInitialized": true,
						"schemaName": "EmailSyncSettings",
						"defaultValues": [{
							name: "TabName",
							value: "EmailSettingsTab"
						}],
						"useHistoryState": false
					},
					"afterrerender": {"bindTo": "afterrerender"}
				}
			}
		]
	};
});
