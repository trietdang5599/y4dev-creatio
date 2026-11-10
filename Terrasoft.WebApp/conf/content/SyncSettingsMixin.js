Terrasoft.configuration.Structures["SyncSettingsMixin"] = {innerHierarchyStack: ["SyncSettingsMixin"]};
define("SyncSettingsMixin", ["SyncSettingsMixinResources", "ModalBox", "ConfigurationConstants", "ServiceHelper","ExchangeNUIConstants", "SyncSettingsLicenseUtils", "NetworkUtilities"],
	function(Resources, ModalBox, ConfigurationConstants, ServiceHelper, ExchangeNUIConstants, SyncSettingsLicenseUtils, NetworkUtilities) {
	Ext.define("Terrasoft.configuration.mixins.SyncSettingsMixin", {
		alternateClassName: "Terrasoft.SyncSettingsMixin",

		/**
		 * Modal dialog height.
		 * @type {Number}
		 */
		modalHeight: 300,

		/**
		 * Modal dialog width.
		 * @type {Number}
		 */
		modalWidth: 400,

		/**
		 * Submenu items, which provide actions to synchronize.
		 */
		"SynchronizeActivitiesSubmenu": {dataValueType: this.Terrasoft.DataValueType.COLLECTION},

		// region Methods: Private

		/**
		 * Returns batch query for getting settings.
		 * @private
		 * @return {Terrasoft.BatchQuery} Batch query.
		 */
		getSettingsBatchQuery: function() {
			var batchQuery = this.Ext.create("Terrasoft.BatchQuery");
			var googleCommunicationEsq = this.getGoogleCommunicationEsq();
			var syncSettingsEsq = this.getSyncSettingsEsq();
			batchQuery.add(googleCommunicationEsq);
			batchQuery.add(syncSettingsEsq);
			return batchQuery;
		},

		/**
		 * Returns entity schema query for getting google communication.
		 * @private
		 * @return {Terrasoft.EntitySchemaQuery} Entity schema query.
		 */
		getGoogleCommunicationEsq: function() {
			var esq = this.Ext.create("Terrasoft.EntitySchemaQuery", {
				rootSchemaName: "SocialAccount"
			});
			this.addColumnsToGoogleCommunicationEsq(esq);
			this.addFiltersToGoogleCommunicationEsq(esq);
			return esq;
		},

		/**
		 * Add columns to google communication entity schema query.
		 * @private
		 * @param {Terrasoft.EntitySchemaQuery} esq Entity schema query.
		 */
		addColumnsToGoogleCommunicationEsq: function(esq) {
			esq.addColumn("Login", "SenderEmailAddress");

			if (this._isGoogleMultidomainEnabled())
			{
				esq.addColumn("Enable", "Enable");
				esq.addColumn("MailboxSyncSettings", "MailboxSyncSettings");
			}
			esq.addColumn("MailServer.Type.Id", "ServerTypeId");
		},

		/**
		 * Add filters to entity schema query for getting google communication for current user.
		 * @private
		 * @param {Terrasoft.EntitySchemaQuery} esq settings entity schema query.
		 */
		addFiltersToGoogleCommunicationEsq: function(esq) {
			esq.filters.add("typeFilter", this.Terrasoft.createColumnFilterWithParameter(
				this.Terrasoft.ComparisonType.EQUAL, "Type", ConfigurationConstants.CommunicationTypes.Google));
			esq.filters.add("currentUserFilter", this.Terrasoft.createColumnFilterWithParameter(
				this.Terrasoft.ComparisonType.EQUAL, "User", this.Terrasoft.SysValue.CURRENT_USER.value));
		},

		/**
		 * Returns entity schema query for getting sync settings collection.
		 * @private
		 * @return {Terrasoft.EntitySchemaQuery} Entity schema query.
		 */
		getSyncSettingsEsq: function() {
			var schemaName = this.getSyncSettingsSchemaName();
			var esq = this.Ext.create("Terrasoft.EntitySchemaQuery", {
				rootSchemaName: schemaName
			});
			this.addColumnsToSyncSettings(esq);
			this.addFiltersToSyncSettingsEsq(esq);
			return esq;
		},

		/**
		 * Add filters to entity schema query for getting mailbox sync settings for current user.
		 * @private
		 * @param {Terrasoft.EntitySchemaQuery} esq settings entity schema query.
		 */
		addFiltersToSyncSettingsEsq: function(esq) {
			esq.filters.add("userFilter", this.Terrasoft.createColumnFilterWithParameter(
				this.Terrasoft.ComparisonType.EQUAL, "MailboxSyncSettings.SysAdminUnit",
				this.Terrasoft.SysValue.CURRENT_USER.value));
		},

		/**
		 * Add columns to sync settings entity schema query.
		 * @private
		 * @param {Terrasoft.EntitySchemaQuery} esq Sync settings entity schema query.
		 */
		addColumnsToSyncSettings: function(esq) {
			esq.addColumn("Id");
			esq.addColumn("MailboxSyncSettings");
			esq.addColumn("MailboxSyncSettings.MailServer.Type", "MailServerType");
			esq.addColumn("MailboxSyncSettings.SenderEmailAddress", "SenderEmailAddress");
			esq.addColumn("MailboxSyncSettings.ExchangeAutoSyncActivity", "ExchangeAutoSyncActivity");
		},

		/**
		 * Returns sync settings dialog schema name.
		 * @private
		 * @return {String} Schema name.
		 */
		getDialogSchemaName: function() {
			return this.entitySchemaName + "SyncSettingsEdit";
		},

		/**
		 * Fills the action items in the synchronize submenu.
		 * @private
		 */
		initSynchronizeSubmenuActionItems: function() {
			const collection = this.Ext.create("Terrasoft.BaseViewModelCollection");
			if(SyncSettingsLicenseUtils.isCalendarSyncLicensed){
				collection.addItem(this.getButtonMenuItem({
					"Caption": {"bindTo": "Resources.Strings.SynchronizeNowCaption"},
					"Click": {"bindTo": "synchronizeNow"}
				}));
			}

			const onClickMenuButtonHandler = this._isNotAbleToAddAccountForSync()
				? "showActiveCalendarDialog"
				: "showSyncDialog";
			collection.addItem(this.getButtonMenuItem({
				"Caption": {"bindTo": "Resources.Strings.AddNewSynchronizationAccountCaption"},
				"Click": {"bindTo": onClickMenuButtonHandler},
			}));
			this.setExistsSyncSettingsActions(collection);
			this.set("SynchronizeActivitiesSubmenu", collection);
		},

		/**
		 * Check if user is not able to add account for synchronization
		 * @private
		 */
		_isNotAbleToAddAccountForSync: function() {
			if (this._isGoogleMultidomainEnabled()) {
				return this.$UserHasActiveCalendar;
			}
			const syncSettings = this.get("SyncSettings");
			if(!syncSettings){
				return false;
			}
			const isSyncOnAtleastForOneAccount =
				syncSettings.filter(sett => sett.ExchangeAutoSyncActivity === true).length >= 1;
			const isAnotherProviderAccAdded =
				syncSettings.filter(sett => sett?.MailServerType?.value !== ExchangeNUIConstants.MailServer.Type.Exchange).length >= 1;
			return isSyncOnAtleastForOneAccount || isAnotherProviderAccAdded;
		},

		/**
		 * Add synchronization actions into section action item collection for exists sync settings.
		 * @private
		 * @param {Terrasoft.Collection} actionMenuItems Section action item collection.
		 * @param {Number} position Actions position in section actions list.
		 */
		setExistsSyncSettingsActions: function(actionMenuItems) {
			var settings = this.get("SyncSettings");
			actionMenuItems.addItem(this.getButtonMenuItem({
				"Type": "Terrasoft.MenuSeparator",
				"Caption": ""
			}));
			this.Terrasoft.each(settings, function(item) {
				var settingId = item.MailboxSyncSettings ? item.MailboxSyncSettings.value : null;
				var caption = this.getSetUpExistsSyncSettingsActionCaption(item.SenderEmailAddress);
				actionMenuItems.addItem(this.getButtonMenuItem({
					"Click": {bindTo: "navigateToSyncSettings"},
					"Tag": settingId,
					"Caption": caption
				}));
			}, this);
		},

		/**
		 * Returns action caption for set up exists settings.
		 * @private
		 * @return {String} Action caption.
		 */
		getSetUpExistsSyncSettingsActionCaption: function(email) {
			return this.Ext.String.format(this.get("Resources.Strings.SetUpExistsSyncSettings")
				|| Resources.localizableStrings.SetUpExistsSyncSettings, email);
		},

		/**
		 * Open sync settings page for exchange synchronization.
		 * @private
		 * @param {Guid} mailboxSyncSettingsId Sync settings Id for exchange synchronization.
		 */
		openExchangeSettingsPage: function(mailboxSyncSettingsId) {
			var historyState = this.sandbox.publish("GetHistoryState");
			var prevHash = historyState.hash;
			var tabName = this.getSyncSettingsTabName();
			var newState = {
				recordId: mailboxSyncSettingsId,
				activeTabName: tabName
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
		},

		/**
		 * Open sync settings page for imap synchronization.
		 * @private
		 * @param {Guid} mailboxSyncSettingsId Sync settings Id for imap synchronization.
		 */
		openGoogleActivitySettingsPage: function(mailboxSyncSettingsId) {
			var historyState = this.sandbox.publish("GetHistoryState");
			var prevHash = historyState.hash;
			var tabName = "GoogleActivitySettingsTab"
			var newState = {
				recordId: mailboxSyncSettingsId,
				activeTabName: tabName
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
		},

		/**
		 * Returns sync settings tab name.
		 * @private
		 * @return {String} Tab name.
		 */
		getSyncSettingsTabName: function() {
			return this.entitySchemaName + "SettingsTab";
		},

		/**
		 * Get config for calling the service.
		 * @param {String} senderEmailAddress Sender email address.
		 * @param {String} methodName Calendar service method name.
		 * @param {Function} callback Callback function.
		 * @return {Object} Calendar service config.
		 * @private
		 */
		 _getCalendarServiceConfig: function(senderEmailAddress, methodName, callback) {
			return {
				"serviceName": "MeetingService",
				"methodName": methodName,
				"data":{
					"senderEmailAddress": senderEmailAddress
				},
				"callback": callback,
				"scope": this
			};
		},

		/**
		 * Laods boolean value for current user calendar integration state.
		 * Result will be true if current user has active calendar integration (Exchange or Google), false otherwise.
		 * Result will be set in "UserHasActiveCalendar" attribute.
		 * @param {Function} callback Request callback function.
		 * @param {Object} scope Callback function scope.
		 * @private
		 */
		_getUserHasActiveCalendar: function(callback, scope) {
			if (!this._isGoogleMultidomainEnabled()) {
				return Ext.callback(callback, scope || this);
			}
			this.Terrasoft.AjaxProvider.request({
				url: `${this.Terrasoft.workspaceBaseUrl}/rest/MeetingService/HasUserActiveCalendarAccount`,
				headers: {
					"Accept": "application/json",
					"Content-Type": "application/json"
				},
				method: "GET",
				callback: function(request, success, response) {
					var responseObject = this.Terrasoft.decode(response.responseText);
					this.$UserHasActiveCalendar = responseObject;
					Ext.callback(callback, scope || this);
				},
				scope: this
			});
		},

		
		/**
		 * Checks if google multi-domain feature is enabled.
		 * @return {Boolean} Feature is enabled or not.
		 * @private
		 */
		_isGoogleMultidomainEnabled: function() {
			return this.getIsFeatureEnabled("GoogleMultidomain");
		},

		/**
		 * Opens ActivitySyncSettingsMiniPage in 8x modal.
		 * @private
		 * @param {String} activitySyncSettingsId ActivitySyncSettings record id.
		 */
		_openCalendarSyncSettingsMiniPage: function(activitySyncSettingsId) {
			NetworkUtilities.tryNavigateTo8xMiniPage({
				miniPageSchemaName: "ActivitySyncSettingsMiniPage",
				operation: "edit",
				id: activitySyncSettingsId
			});
		},

		/**
		 * Gets ActivitySyncSettings record id by MailboxSyncSettings and opens minipage.
		 * @private
		 * @param {String} mailboxSyncSettingsId MailboxSyncSettings record id.
		 */
		_tryOpenActivitySyncSettingsMiniPage: function(mailboxSyncSettingsId) {
			const esq = this.Ext.create("Terrasoft.EntitySchemaQuery", {
				rootSchemaName: "ActivitySyncSettings"
			});
			esq.addColumn("Id");
			esq.filters.add("MailboxFilter", esq.createColumnFilterWithParameter(
				this.Terrasoft.ComparisonType.EQUAL, "MailboxSyncSettings", mailboxSyncSettingsId));
			esq.getEntityCollection(function(result) {
				if (result.success && !result.collection.isEmpty()) {
					const entity = result.collection.getByIndex(0);
					this._openCalendarSyncSettingsMiniPage(entity.get("Id"));
				}
			}, this);
		},

		//endregion

		// region Methods: Protected

		/**
		 * Navigate to set up sync settings page after updating sync settings data.
		 * @protected
		 */
		navigateToSyncSettingsWithSyncSettingsUpdate: function() {
			var itemId = this.get("SyncSettingsId");
			this.navigateToSyncSettings(itemId);
			return false;
		},

		/**
		 * Start synchronization with google account.
		 * @protected
		 */
		synchronizeGoogle: this.Terrasoft.emptyFn,

		/**
		 * Start synchronization with exchange account.
		 * @protected
		 */
		synchronizeExchange: this.Terrasoft.emptyFn,

		/**
		 * Returns set sync settings section action caption.
		 * @protected
		 * @return {String} Caption.
		 */
		getSetSyncSettingsCaption: this.Terrasoft.emptyFn,

		/**
		 * Update sync settings and than show tip.
		 * @protected
		 */
		updateSyncSettingsSetAndShowTip: function(itemId) {
			this.getSectionActions();
			this.set("SyncSettingsId", itemId);
			this.set("IsSyncSettingsSetTipVisible", true);
		},

		/**
		 * Update sync settings collection.
		 * @param {Function} callback Callback function call after getting success response.
		 * @param {Object} scope Scope for callback function.
		 * @protected
		 */
		updateSyncSettings: function(callback, scope) {
			Terrasoft.chain(
				function(next) {
					this._getUserHasActiveCalendar(next, this);
				},
				function(next) {
					const batchQuery = this.getSettingsBatchQuery();
					batchQuery.execute(function(response) {
						if (response && response.success) {
							const googleRows = response.queryResults[0].rows || [];
							const exchangeRows = response.queryResults[1].rows || [];
							const rows = googleRows.concat(exchangeRows);
							this.settingsBatchQueryCallback(rows, next, this);
						} else {
							throw new Terrasoft.UnknownException({
								message: this.get("Resources.Strings.ErrorOnGettingSyncSettings")
									|| Resources.localizableStrings.ErrorOnGettingSyncSettings
							});
						}
					}, this);
				},
				function() {
					Ext.callback(callback, scope || this);
				},
				this
			);
		},

		/**
		 * Update sync settings callback function.
		 * @param {Array} rows Calendars synchronization accounts.
		 * @param {Function} callback Callback function call after getting success response.
		 * @param {Object} scope Scope for callback function.
		 * @protected
		 */
		settingsBatchQueryCallback: function(rows, callback, scope) {
			this.set("SyncSettings", rows);
			Ext.callback(callback, scope || this);
		},

		/**
		 * Checking if user can change calendar settings.
		 * @param {String} senderEmilAddress Sender email address.
		 * @param {Function} callback Callback function.
		 * @param {Object} scope Scope function.
		 */
		canUserChangeCalendar: function(senderEmilAddress, callback, scope) {
			const config = this._getCalendarServiceConfig(senderEmilAddress, "CanUserChangeCalendar",
				function(response) {
					this.canUserChangeCalendarCallback(response, callback, scope);
				});
			return ServiceHelper.callService(config);
		},

		/**
		 * Terrasoft.SyncSettingsMixin#canUserChangeCalendar callback.
		 */
		canUserChangeCalendarCallback: Terrasoft.abstractFn,

		/**
		 * Returns sync settings entity schema name.
		 * @protected
		 * @return {String} Schema name.
		 */
		getSyncSettingsSchemaName: function() {
			return this.entitySchemaName + "SyncSettings";
		},

		/**
		 * Shows sync settings dialog.
		 * @protected
		 */
		showSyncDialog: function() {
			var modalBoxSize = {
				minHeight: "1",
				minWidth: "1",
				maxHeight: "100",
				maxWidth: "100",
				widthPixels: "425",
				heightPixels: "200"
			};
			var schemaName = this.getDialogSchemaName();
			var modalBoxContainer = ModalBox.show(modalBoxSize);
			this.sandbox.loadModule("CredentialsSyncSettingsEdit", {
				renderTo: modalBoxContainer,
				instanceConfig: {
					schemaName: schemaName,
					isSchemaConfigInitialized: true,
					useHistoryState: false
				}
			});
			ModalBox.setSize(this.modalWidth, this.modalHeight);
		},

		/**
		 * Add synchronization actions into section action item collection.
		 * @protected
		 * @param {Terrasoft.Collection} actionMenuItems Section action item collection.
		 * @param {Number} position Actions position in section actions list.
		 */
		setSyncSectionActions: function(actionMenuItems, position) {
			position = position || 0;
			this.set("SyncSettings", null);
			actionMenuItems.add(actionMenuItems.getUniqueKey(), this.getButtonMenuItem({
				"Caption": {"bindTo": "Resources.Strings.SynchronizeSubmenuCaption"},
				"Items": {"bindTo": "SynchronizeActivitiesSubmenu"}
			}), position);
			this.updateSyncSettings(function() {
				SyncSettingsLicenseUtils.initUserLicOperationsRights(function(){
					this.initSynchronizeSubmenuActionItems();
				}, this);
			}, this);
		},

		/**
		 * Show active calendar dialog.
		 * @protected
		 */
		showActiveCalendarDialog: function() {
			this.showInformationDialog(this.get("Resources.Strings.ActiveCalendarDialogMessage")
				|| Resources.localizableStrings.ActiveCalendarDialogMessage, Terrasoft.emptyFn);
		},

		/**
		 * Navigate to set up sync settings page.
		 * @protected
		 * @param {Guid} mailboxSyncSettingsId Mailbox settings id.
		 */
		navigateToSyncSettings: function(mailboxSyncSettingsId) {
			const syncSettings = this.get("SyncSettings");

			const isGoogleSycSett = syncSettings.filter(sett => 
				sett?.MailboxSyncSettings?.value === mailboxSyncSettingsId &&
			  	sett?.ServerTypeId === ExchangeNUIConstants.MailServer.Type.Imap).length > 0;

			if (isGoogleSycSett && this._isGoogleMultidomainEnabled()) {
				this.openGoogleActivitySettingsPage(mailboxSyncSettingsId);
			} else if (mailboxSyncSettingsId) {
				this.openExchangeSettingsPage(mailboxSyncSettingsId);
			} else {
				this.openGoogleSettingsPage();
			}
			return false;
		},

		/**
		 * Opens ActivitySyncSettings minipage for the given mailbox.
		 * @protected
		 * @param {Guid} mailboxSyncSettingsId Mailbox sync settings id.
		 */
		openActivitySyncSettingsMiniPage: function(mailboxSyncSettingsId) {
			if (mailboxSyncSettingsId) {
				this._tryOpenActivitySyncSettingsMiniPage(mailboxSyncSettingsId);
			}
		},

		//endregion

	});

	return Terrasoft.SyncSettingsMixin;
});


