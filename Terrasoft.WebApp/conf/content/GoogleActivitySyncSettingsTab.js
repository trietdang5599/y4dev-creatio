Terrasoft.configuration.Structures["GoogleActivitySyncSettingsTab"] = {innerHierarchyStack: ["GoogleActivitySyncSettingsTab"], structureParent: "BaseSyncSettingsTab"};
define('GoogleActivitySyncSettingsTabStructure', ['GoogleActivitySyncSettingsTabResources'], function(resources) {return {schemaUId:'93890df9-b70b-4413-a85a-bb94a6514309',schemaCaption: "ActivitySyncSettingsTab", parentSchemaName: "BaseSyncSettingsTab", packageName: "OldGoogleIntegration", schemaName:'GoogleActivitySyncSettingsTab',parentSchemaUId:'b3e983b4-31c2-4f86-b53e-bd7d71ce32b8',extendParent:false,type:Terrasoft.SchemaType.EDIT_VIEW_MODEL_SCHEMA,entitySchema:'',name:'',extend:'Terrasoft.model.BaseViewModel',schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},schemaDifferences:function(){

}};});
Ext.ns("Terrasoft.enums.SyncSettings");
define("GoogleActivitySyncSettingsTab", ["SyncSettingsMixin", "css!FullWidthLabelViewGenerator"],
	function () {
		return {
			entitySchemaName: "SocialAccount",
			properties: {
				/**
				 * Max sync period size for google calendar (in days).
				 * @type {Number}
				 * @private
				 */
				_maxAllowedSyncPeriod: 20
			},
			attributes: {
				/**
				 * Sign that enabled adding calendar.
				 */
				"CanAddCalendar": {
					"type": Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"dataValueType": Terrasoft.DataValueType.BOOLEAN
				},

				/**
				 * Interval of google calendar synchronization.
				 */
				"CalendarSyncInterval": {
					"type": Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"dataValueType": Terrasoft.DataValueType.LOOKUP,
					"name": "CalendarSyncInterval",
					"isRequired": true
				},

				/**
				 * Start date of google calendar synchronization.
				 */
				"CalendarSyncDate": {
					"type": Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"dataValueType": Terrasoft.DataValueType.DATE,
					"name": "CalendarSyncDate",
					"isRequired": true
				},
			},
			mixins: {
				/**
				 * Provides methods for sync settings tabs.
				 */
				"SyncSettingsMixin": "Terrasoft.SyncSettingsMixin"

			},
			methods: {

				/**
				 * @inheritDoc Terrasoft.BaseSyncSettingsTab#initDefaultValues
				 * @overridden
				 */
				initDefaultValues: function(callback, scope) {
					this.initMailboxSyncSettingValues();
					this.canUserChangeCalendar(this.$MailboxName, function() {
						this.initCalendarValues(function() {
							this.on("change:Enable", this.onSchedulerSettingsChanged, this);
							this.on("change:CalendarSyncInterval", this.onSchedulerSettingsChanged, this);
							Ext.callback(callback, scope);
						}, this);
					}, this);

				},

				onSchedulerSettingsChanged: function() {
					this.set("SchedulerSettingsChanged", true);
				},

				/**
				 * Loads values into  sync interval combobox.
				 * @param {Object} filter ComboboxEdit value.
				 * @param {Terrasoft.Collection} list List of comboboxEdit values.
				 */
				prepareSyncIntervalList: function(filter, list) {
					if (list === null) {
						return;
					}
					list.clear();
					list.loadAll(this.getSyncIntervalList());
				},

				/**
				 * Returns collection of sync intervals.
				 * @return {Terrasoft.Collection} List of sync intervals.
				 */
				getSyncIntervalList: function() {
					const list = Ext.create("Terrasoft.Collection");
					const oneMinuteCaption = this.get("Resources.Strings.OneMinuteCaption");
					const multipleMinutesCaption = this.get("Resources.Strings.MultipleMinutesCaption");
					Terrasoft.each(Terrasoft.TimeScale, function(value) {
						if (value ===  Terrasoft.TimeScale.ONE_MINUTE) {
							list.add(value, {
								displayValue: oneMinuteCaption,
								value: value
							});
						} else {
							list.add(value, {
								displayValue: Ext.String.format(multipleMinutesCaption, value),
								value: value
							});
						}
					}, this);
					return list;
				},

				initCalendarValues: function(callback, scope) {
					this.set("CalendarSyncIntervalList", this.Ext.create("Terrasoft.Collection"));
					const sysSettings = [
						"GoogleCalendarSynchInterval",
						"GoogleCalendarLastSynchronization"
					];
					Terrasoft.SysSettings.querySysSettings(sysSettings, function(settings) {
						this.setCalendarSyncDate(settings.GoogleCalendarLastSynchronization);
						this.setSyncInterval("CalendarSyncInterval", settings.GoogleCalendarSynchInterval);
						this.initEntity(callback, scope || this);
					}, this);
				},

				/**
				 * Sets property with synchronization interval object.
				 * @protected
				 * @param {String} propertyName Property name.
				 * @param {Number} interval Synchronization interval value.
				 */
				setSyncInterval: function(propertyName, interval) {
					const collection = this.getSyncIntervalList();
					if (collection.contains(interval)) {
						this.set(propertyName, collection.get(interval));
					} else {
						this.set(propertyName, collection.get(Terrasoft.TimeScale.SIXTY_MINUTES));
					}
				},

				/**
				 * Sets CalendarSyncDate with parameter or default value.
				 * @protected
				 * @param {Date} syncDate Date obtained from settings.
				 */
				setCalendarSyncDate: function(syncDate) {
					if (!syncDate) {
						syncDate = new Date();
						syncDate.setDate(syncDate.getDate() - 7);
					}
					this.set("CalendarSyncDate", syncDate);
				},

				/**
				 * Checks that all required fields are filled in. In case validation is not passed 
				 * error message will be shown and callback function will not be called.
				 * @protected
				 * @param {Function} callback Callback function. Will be called only if validation passed.
				 * @param {Object} scope Callback function scope.
				 */
				validateRequiredFields: function(callback, scope) {
					if (this.get("Enable") && (
						this.get("CalendarSyncInterval") === null || this.get("CalendarSyncDate") === null)) {
						this.showInformationDialog(this.get("Resources.Strings.FieldValidationError"));
						return;
					}
					Ext.callback(callback, scope || this);
				},

				/**
				 * Checks that calendar sync since date is within allowed margin. In case validation is not passed 
				 * error message will be shown and callback function will not be called.
				 * @protected
				 * @param {Function} callback Callback function. Will be called only if validation passed.
				 * @param {Object} scope Callback function scope.
				 */
				validateSyncDate: function(callback, scope) {
					const calendarSyncDate = this.get("CalendarSyncDate");
					const diffTime = Math.abs(new Date() - calendarSyncDate);
					const diffDays = Math.floor(diffTime / (1000 * 60 * 60 * 24));
					if (diffDays > this._maxAllowedSyncPeriod) {
						this.showInformationDialog(this.get("Resources.Strings.SyncDateLiesTooFarInThePastMessage"));
						return;
					}
					Ext.callback(callback, scope || this);
				},

				/**
				 * @inheritdoc Terrasoft.SyncSettingsMixin#getSyncSettingsSchemaName
				 * @overridden
				 */
				getSyncSettingsSchemaName: function () {
					return this.entitySchemaName;
				},

				canSaveFolders: function() {
					return false;
				},

				/**
				 * @inheritdoc Terrasoft.SyncSettingsMixin#canUserChangeCalendarCallback
				 * @overridden
				 */
				canUserChangeCalendarCallback: function(canAddCalendar, callback, scope) {
					this.set("CanAddCalendar", canAddCalendar);
					Ext.callback(callback, scope);
				},

				/**
				 * @inheritDoc Terrasoft.BaseSyncSettingsTab#saveSettings
				 * @overridden
				 */
				saveSettings: function(callback, scope) {
					this.callParent([function() {
						this.saveSysSettings(callback, scope);
					}, this]);
				},

				saveSysSettings: function(callback, scope) {
					const sysSettingsData = this.createSysSettingsData();
					Terrasoft.SysSettings.postSysSettingsValues(sysSettingsData,
						function() {
							const sysSettingsValues = sysSettingsData.sysSettingsValues;
							this.prepareScheduledJob(sysSettingsValues.GoogleCalendarSynchInterval);
							Ext.callback(callback, scope);
						}, this);
				},

				/**
				 * Creates data object and scheduled job.
				 * @param {Number} syncInterval Synchronization interval in minutes.
				 */
				prepareScheduledJob: function(syncInterval) {
					if (!this.get("SchedulerSettingsChanged")) {
						return;
					}
					const jobData = {
						JobName: Ext.String.format("SyncGoogleCalendar{0}", Terrasoft.SysValue.CURRENT_USER.value),
						SyncJobGroupName: "GoogleIntegration",
						SyncProcessName: "GCalendarSynchronizationModuleProcess",
						periodInMinutes: syncInterval,
						recreate: this.get("Enable"),
						schedulerName: "GoogleIntegrationQuartzScheduler"
					};
					this.createScheduledJob(jobData);
				},

				/**
				 * @inheritDoc Terrasoft.BaseSyncSettingsTab#validateSettings.
				 * @overridden
				 */
				validateSettings: function(callback, scope) {
					Terrasoft.chain(
						this.validateRequiredFields,
						this.validateSyncDate,
						function() {
							Ext.callback(callback, scope || this);
						}, this);
				},

				/**
				 * Creates synchronization job.
				 * @protected
				 * @param {Object} data Job settings.
				 */
				createScheduledJob: function(data) {
					const provider = Terrasoft.AjaxProvider;
					const workspaceBaseUrl = Terrasoft.utils.uri.getConfigurationWebServiceBaseUrl();
					const requestUrl = workspaceBaseUrl + "/rest/SchedulerJobService/CreateSyncJob";
					provider.request({
						url: requestUrl,
						headers: {
							"Accept": "application/json",
							"Content-Type": "application/json"
						},
						method: "POST",
						jsonData: data,
						scope: this
					});
				},

				/**
				 * Creates user settings object.
				 * @protected
				 * @return {Object} User synchronization settings.
				 */
				createSysSettingsData: function() {
					let calendarSyncIntervalValue;
					const calendarSyncInterval = this.get("CalendarSyncInterval");
					if (calendarSyncInterval) {
						calendarSyncIntervalValue = calendarSyncInterval.value;
					}
					const calendarSyncDate = this.get("CalendarSyncDate");
					const sysSettingsValues = {
						"GoogleCalendarLastSynchronization": calendarSyncDate,
						"GoogleCalendarLastSynchronizationEnd": calendarSyncDate
					};
					if (calendarSyncIntervalValue) {
						Ext.apply(sysSettingsValues, {
							"GoogleCalendarSynchInterval": calendarSyncIntervalValue
						});
					}
					return {
						sysSettingsValues: sysSettingsValues,
						isPersonal: true
					};
				},
				

				/**
				 * @inheritDoc Terrasoft.BaseSyncSettingsTab#getUpdateQuery
				 * @overridden
				 */
				getUpdateQuery: function() {
					const update = this.Ext.create("Terrasoft.UpdateQuery", {
						rootSchemaName: this.entitySchemaName
					});
					const filters = update.filters;
					const socialAccountId = this.get("Id");
					const idFilter = update.createColumnFilterWithParameter(this.Terrasoft.ComparisonType.EQUAL,
						"Id", socialAccountId);
					filters.add("IdFilter", idFilter);
					update.setParameterValue("Enable", this.get("Enable"), this.Terrasoft.DataValueType.BOOLEAN);
					return update;
				},
				
				/**
				 * @inheritDoc Terrasoft.BaseSyncSettingsTab#onSaved
				 * @overridden
				 */
				onSaved: function() {
					const config = {
						tabName: this.get("TabName"),
						values: {
							isSaved: true,
							enable: this.get("Enable")
						}
					};
					this.set("TabSavedValuesConfig", config);
					this.callParent(arguments);
				}

			},
			diff: [
				{
					"operation": "insert",
					"name": "GCalendarSyncContainer",
					"values": {
						"itemType": Terrasoft.ViewItemType.CONTAINER,
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "GCalendarConfContainer",
					"values": {
						"itemType": Terrasoft.ViewItemType.CONTAINER,
						"visible": { "bindTo": "CanAddCalendar" },
						"items": [],
					}
				},
				{
					"operation": "insert",
					"name": "GoogleAutoSynchronization",
					"parentName": "GCalendarSyncContainer",
					"propertyName": "items",
					"values": {
						"caption": { "bindTo": "Resources.Strings.GoogleCalendarAutoSynchronization" },
						"bindTo": "Enable",
						"controlConfig": {
							"className": "Terrasoft.ToggleEdit"
						},
						"wrapClass": ["settings-page-reverse-toggle-edit"],
						"visible": { "bindTo": "CanAddCalendar" }
					}
				},
				{
					"operation": "insert",
					"name": "DisabledGCalendarAutoSynchronization",
					"parentName": "GCalendarSyncContainer",
					"propertyName": "items",
					"values": {
						"caption": { "bindTo": "Resources.Strings.GoogleCalendarAutoSynchronization" },
						"bindTo": "Enable",
						"controlConfig": {
							"className": "Terrasoft.ToggleEdit"
						},
						"wrapClass": ["settings-page-reverse-toggle-edit"],
						"tip": {
							"content": { "bindTo": "Resources.Strings.ActiveCalendarDialogMessage" },
							"style": Terrasoft.controls.TipEnums.style.YELLOW
						},
						"visible": {
							"bindTo": "CanAddCalendar",
							"bindConfig": { "converter": "invertBooleanValue" }
						},
						"enabled": false
					}
				},
				{
					"operation": "insert",
					"parentName": "GCalendarConfContainer",
					"propertyName": "items",
					"name": "CalendarSyncInterval",
					"values": {
						"bindTo": "CalendarSyncInterval",
						"className": "Terrasoft.ComboBoxEdit",
						"layout": { "column": 1, "row": 0, "colSpan": 23 },
						"dataValueType": Terrasoft.DataValueType.ENUM,
						"wrapClass": ["settings-page-import-from-period"],
						"labelConfig": {
							"caption": { "bindTo": "Resources.Strings.CalendarSyncIntervalCaption" },
							"classes": {
								"labelClass": ["full-width-label"],
								"wrapClass": ["initial-width-wrapper"]
							}
						},
						"wrapClasses": ["settings-wrapper"],
						"listConfig": {
							"list": {
								"bindTo": "CalendarSyncIntervalList"
							},
							"prepareList": {
								"bindTo": "prepareSyncIntervalList"
							},
							"classes": {
								"wrapClass": ["initial-width-wrapper"]
							}
						},
						"enabled": { "bindTo": "Enable" },
						"generator": "FullWidthLabelViewGenerator.generate"
					}
				},
				{
					"operation": "insert",
					"parentName": "GCalendarConfContainer",
					"propertyName": "items",
					"name": "CalendarSyncDate",
					"values": {
						"bindTo": "CalendarSyncInterval",
						"className": "Terrasoft.DateEdit",
						"layout": { "column": 1, "row": 1, "colSpan": 23 },
						"dataValueType": Terrasoft.DataValueType.DATE,
						"labelConfig": {
							"caption": { "bindTo": "Resources.Strings.CalendarSyncDateCaption" },
							"classes": {
								"labelClass": ["full-width-label"],
								"wrapClass": ["initial-width-wrapper"]
							}
						},
						"wrapClasses": ["settings-wrapper"],
						"listConfig": {
							"classes": {
								"wrapClass": ["initial-width-wrapper"]
							}
						},
						"enabled": { "bindTo": "Enable" },
						"generator": "FullWidthLabelViewGenerator.generate"
					}
				},
				{
					"operation": "remove",
					"name": "FoldersGrid",
				}
			]
		};
	});

