define("ActivitySyncSettingsEdit", ["ActivitySyncSettingsEditResources", "SyncSettingsEditMixin",
	"ExchangeNUIConstants"],
	function(resources, SyncSettingsEditMixin, ExchangeNUIConstants) {
			return {
				mixins: {
					/**
					 * Base logic synchronization mixin.
					 */
					"SyncSettingsEditMixin": "Terrasoft.SyncSettingsEditMixin"
				},
				messages: {
					/**
					 * @message ShowSyncSettingsSetTip
					 * Notify to show tip about completed set sync settings.
					 */
					"ShowSyncSettingsSetTip": {
						mode: Terrasoft.MessageMode.PTP,
						direction: Terrasoft.MessageDirectionType.PUBLISH
					}
				},
				methods: {
					/**
					 * @inheritdoc Terrasoft.SyncSettingsEditMixin#getEntitySchemaName
					 * @overridden
					 */
					getEntitySchemaName: function() {
						return "ActivitySyncSettings";
					},

					/**
					 * @inheritdoc Terrasoft.BaseSyncSettingsEdit#setFiltersToServerListEsq
					 * @overridden
					 */
					setFiltersToServerListEsq: function(esq) {
						this.callParent(arguments);
						this.addFiltersToServerListEsq(esq);
					},

					/**
					 * @inheritDoc Terrasoft.BaseSyncSettingsEdit#onSaved
					 * @overridden
					 */
					onSaved: function() {
						this.publishSyncSettingsIsSet();
						this.callParent(arguments);
					},

					/**
					 * @inheritdoc Terrasoft.BaseSyncSettingsEdit#onServerListItemClick
					 * @overridden
					 */
					onServerListItemClick: function(itemId) {
						var collection = this.get("ServerListCollection");
						const mailServer = collection?.get(itemId);
						const isGoogleOAuthsServer =
							mailServer?.$Type?.value === ExchangeNUIConstants.MailServer.Type.Imap &&
							mailServer?.$OAuthApplicaiton?.value !== null;
						if (this.isGoogleMultidomainEnabled() && isGoogleOAuthsServer){
							this.callParent(arguments);
							return;
						} else if (itemId === ExchangeNUIConstants.MailServer.Gmail) {
							this.startGoogleAuth();
							this.onCancel();
							return;
						}
						this.callParent(arguments);
					},

					/**
					 * @inheritdoc Terrasoft.BaseSyncSettingsEdit#getMailboxInsert
					 * @overridden
					 */
					getMailboxInsert: function() {
						var insert = this.callParent(arguments);
						insert.setParameterValue("ExchangeAutoSynchronization", 1,
								Terrasoft.DataValueType.BOOLEAN);
						return insert;
					},

					/**
					 * @inheritdoc Terrasoft.BaseSyncSettingsEdit#getActivitySyncSettingsInsert
					 * @overridden
					 */
					getActivitySyncSettingsInsert: function() {
						return this.getEntitySyncSettingInsert();
					},

					/**
					 * @inheritdoc Terrasoft.SyncSettingsEditMixin#setParametersToInsertEntitySyncSetting
					 * @overridden
					 */
					setParametersToInsertEntitySyncSetting: function(insert) {
						var importDate = new Date();
						importDate.setDate(importDate.getDate() - 30);
						insert.setParameterValue("ImportTasks", 0,
								this.Terrasoft.DataValueType.BOOLEAN);
						insert.setParameterValue("ImportTasksAll", 1,
								this.Terrasoft.DataValueType.BOOLEAN);
						insert.setParameterValue("ImportTasksFromFolders", 0,
								this.Terrasoft.DataValueType.BOOLEAN);
						insert.setParameterValue("ImportTasksFolders", "",
								this.Terrasoft.DataValueType.TEXT);
						insert.setParameterValue("ImportAppointments", 0,
								this.Terrasoft.DataValueType.BOOLEAN);
						insert.setParameterValue("ImportAppointmentsAll", 1,
								this.Terrasoft.DataValueType.BOOLEAN);
						insert.setParameterValue("ImpAppointmentsFromCalendars", 0,
								this.Terrasoft.DataValueType.BOOLEAN);
						insert.setParameterValue("ImportAppointmentsCalendars", "",
								this.Terrasoft.DataValueType.TEXT);
						insert.setParameterValue("ExportActivities", 0,
								this.Terrasoft.DataValueType.BOOLEAN);
						insert.setParameterValue("ExportActivitiesAll", 1,
								this.Terrasoft.DataValueType.BOOLEAN);
						insert.setParameterValue("ExportTasks", 1,
								this.Terrasoft.DataValueType.BOOLEAN);
						insert.setParameterValue("ExportActivitiesFromGroups", 0,
								this.Terrasoft.DataValueType.BOOLEAN);
						insert.setParameterValue("ImportActivitiesFrom", importDate,
								this.Terrasoft.DataValueType.DATE);
						insert.setParameterValue("ExportActivitiesGroups", "",
								this.Terrasoft.DataValueType.TEXT);
						insert.setParameterValue("MailboxSyncSettings", this.get("MailboxSyncSettingsId"),
								Terrasoft.DataValueType.GUID);
					},

					/**
					 * @inheritdoc Terrasoft.BaseSyncSettingsEdit#addNewMailServerToList
					 * @overridden
					 */
					addNewMailServerToList: function(response) {
						var newEntity = response.entity;
						var addedServerTypeId = newEntity.get("Type").value;
						if (addedServerTypeId === ExchangeNUIConstants.MailServer.Type.Exchange) {
							var collection = this.get("ServerListCollection");
							var newEntityId = newEntity.get("Id");
							collection.add(newEntityId, newEntity);
						}
					}
				}
			};
		});