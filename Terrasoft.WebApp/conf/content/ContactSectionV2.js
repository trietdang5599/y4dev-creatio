Terrasoft.configuration.Structures["ContactSectionV2"] = {innerHierarchyStack: ["ContactSectionV2CrtUIv2", "ContactSectionV2Exchange", "ContactSectionV2OSM", "ContactSectionV2SocialNetworkIntegration", "ContactSectionV2"], structureParent: "BaseSectionV2"};
define('ContactSectionV2CrtUIv2Structure', ['ContactSectionV2CrtUIv2Resources'], function(resources) {return {schemaUId:'0557bf34-e34a-46fa-990a-36ec59df39fa',schemaCaption: "Contacts section", parentSchemaName: "BaseSectionV2", packageName: "CrtDeduplication", schemaName:'ContactSectionV2CrtUIv2',parentSchemaUId:'7912fb69-4fee-429f-8b23-93943c35d66d',extendParent:false,type:Terrasoft.SchemaType.MODULE_VIEW_MODEL_SCHEMA,entitySchema:'',name:'',extend:'Terrasoft.model.BaseViewModel',schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},schemaDifferences:function(){

}};});
define('ContactSectionV2ExchangeStructure', ['ContactSectionV2ExchangeResources'], function(resources) {return {schemaUId:'93697a27-594d-4c7d-b7e6-116c8cdbe350',schemaCaption: "Contacts section", parentSchemaName: "ContactSectionV2CrtUIv2", packageName: "CrtDeduplication", schemaName:'ContactSectionV2Exchange',parentSchemaUId:'0557bf34-e34a-46fa-990a-36ec59df39fa',extendParent:true,type:Terrasoft.SchemaType.MODULE_VIEW_MODEL_SCHEMA,entitySchema:'',name:'',extend:"ContactSectionV2CrtUIv2",schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},schemaDifferences:function(){

}};});
define('ContactSectionV2OSMStructure', ['ContactSectionV2OSMResources'], function(resources) {return {schemaUId:'1f366ff8-2924-467f-b912-ef93ac730f61',schemaCaption: "Contacts section", parentSchemaName: "ContactSectionV2Exchange", packageName: "CrtDeduplication", schemaName:'ContactSectionV2OSM',parentSchemaUId:'93697a27-594d-4c7d-b7e6-116c8cdbe350',extendParent:true,type:Terrasoft.SchemaType.MODULE_VIEW_MODEL_SCHEMA,entitySchema:'',name:'',extend:"ContactSectionV2Exchange",schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},schemaDifferences:function(){

}};});
define('ContactSectionV2SocialNetworkIntegrationStructure', ['ContactSectionV2SocialNetworkIntegrationResources'], function(resources) {return {schemaUId:'d5032786-6253-4b0a-8fbb-a0adad9df496',schemaCaption: "Contacts section", parentSchemaName: "ContactSectionV2OSM", packageName: "CrtDeduplication", schemaName:'ContactSectionV2SocialNetworkIntegration',parentSchemaUId:'1f366ff8-2924-467f-b912-ef93ac730f61',extendParent:true,type:Terrasoft.SchemaType.MODULE_VIEW_MODEL_SCHEMA,entitySchema:'',name:'',extend:"ContactSectionV2OSM",schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},schemaDifferences:function(){

}};});
define('ContactSectionV2Structure', ['ContactSectionV2Resources'], function(resources) {return {schemaUId:'870dbbfc-1397-47c0-a792-b737b87471ee',schemaCaption: "Contacts section", parentSchemaName: "ContactSectionV2SocialNetworkIntegration", packageName: "CrtDeduplication", schemaName:'ContactSectionV2',parentSchemaUId:'d5032786-6253-4b0a-8fbb-a0adad9df496',extendParent:true,type:Terrasoft.SchemaType.MODULE_VIEW_MODEL_SCHEMA,entitySchema:'',name:'',extend:"ContactSectionV2SocialNetworkIntegration",schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},schemaDifferences:function(){

}};});
define('ContactSectionV2CrtUIv2Resources', ['terrasoft'], function(Terrasoft) {
var localizableStrings={

};
var parametersLocalizableStrings={};
var localizableImages={

};
return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});
define("ContactSectionV2CrtUIv2", ["ProcessModuleUtilities", "RightUtilities", "ConfigurationConstants", "ModalBox",
		"GoogleIntegrationUtilitiesV2", "css!ContactSectionV2CSS"],
	function(ProcessModuleUtilities, RightUtilities, ConfigurationConstants, ModalBox) {
		return {
			entitySchemaName: "Contact",
			attributes: {
				/**
				 * Can run actualize contact age process value
				 */
				"CanRunActualizeContactAgeProcess": {
					dataValueType: Terrasoft.DataValueType.BOOLEAN,
					type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
					value: false
				},
				/**
				 * Actualize age system settings value
				 */
				"IsActiveActualizeContactAge": {
					dataValueType: Terrasoft.DataValueType.BOOLEAN,
					type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
					value: false
				},
				/**
				 * Run automatic age actualization daily system settings value
				 */
				"IsActiveRunAgeActualizationDaily": {
					dataValueType: Terrasoft.DataValueType.BOOLEAN,
					type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
					value: false
				},
				/**
				 * The visibility of the menu items for synchronization.
				 */
				"canUseGoogleOrSocialFeaturesByBuildType": {
					dataValueType: this.Terrasoft.DataValueType.BOOLEAN,
					value: false
				}
			},
			messages: {
				/**
				 * @message GetMapsConfig
				 * ########## #########, ########### ### ###### ###### ####### ## #####.
				 * @param {Object} #########, ############ ### ###### ###### ####### ## #####.
				 */
				"GetMapsConfig": {
					mode: Terrasoft.MessageMode.PTP,
					direction: Terrasoft.MessageDirectionType.SUBSCRIBE
				}
			},
			mixins: {
				GoogleIntegrationUtils: "Terrasoft.GoogleIntegrationUtilities"
			},
			methods: {

				//region Methods: Private

				/**
				 * @private
				 */
				_initCanRunActualizeProcess: function() {
					RightUtilities.checkCanExecuteOperation({
						operation: "CanRunActualizeContactAgeProcess"
					}, this._onCanRunActualizeAgeProcess, this);
				},

				/**
				 * @private
				 */
				_onCanRunActualizeAgeProcess: function(value) {
					this.set("CanRunActualizeContactAgeProcess", value);
				},

				/**
				 * @private
				 */
				_initActualizeAgeSysSettingsValue: function() {
					Terrasoft.SysSettings.querySysSettingsItem("ActualizeAge", this._onActualizeAgeSysSettingsValue, this);
				},

				/**
				 * @private
				 */
				_onActualizeAgeSysSettingsValue: function(value) {
					this.set("IsActiveActualizeContactAge", value);
				},

				/**
				 * @private
				 */
				_initRunAgeActualizationDailySysSettingsValue: function() {
					Terrasoft.SysSettings.querySysSettingsItem("RunAgeActualizationDaily",
						this._onRunAgeActualizationDailySysSettingsValue, this);
				},

				/**
				 * @private
				 */
				_onRunAgeActualizationDailySysSettingsValue: function(value) {
					this.set("IsActiveRunAgeActualizationDaily", value);
				},

				/**
				 * Return config for the ContactActualizeAgeProcess process.
				 * @private
				 * @return {Object} Config.
				 */
				_getContactActualizeAgeProcessConfig: function() {
					return {
						"sysProcessName": "ContactActualizeAgeProcess",
						"parameters": {
							"IsActualizeAllRecord": true,
							"IsNeedToNotifyUser": true
						}
					};
				},

				/**
				 * Return config for the ContactAgeActualizationJobRestartProcess process.
				 * @private
				 * @return {Object} Config.
				 */
				_getAgeActualizationJobRestartProcessConfig: function() {
					return {
						"sysProcessName": "ContactAgeActualizationJobRestartProcess"
					};
				},

				/**
				 * @private
				 */
				_getActualizeAgeButtonMenuItem: function() {
					return this.getButtonMenuItem({
						"Click": {"bindTo": "runActualizeAgeProcess"},
						"Caption": {"bindTo": "Resources.Strings.ActualizeContactAgeCaption"},
						"Enabled": {"BindTo": "CanRunActualizeContactAgeProcess"}
					});
				},

				/**
				 * @private
				 */
				_getRescheduleAgeActualizationButtonMenuItem: function() {
					return this.getButtonMenuItem({
						"Click": {"bindTo": "runRescheduleAgeActualization"},
						"Caption": {"bindTo": "Resources.Strings.RescheduleAgeActualizationCaption"},
						"Enabled": {"BindTo": "CanRunActualizeContactAgeProcess"}
					});
				},

				/**
				 * @private
				 */
				_getTimeEditModalBoxConfig: function(modalBoxContainer) {
					return {
						moduleName: "BaseSchemaModuleV2",
						containerId: modalBoxContainer,
						instanceConfig: {
							schemaName: "AgeActualizationModalTimeEditModuleSchema",
							useHistoryState: false,
							generateViewContainerId: false,
							isSchemaConfigInitialized: true
						}
					}
				},

				//endregion

				//region Methods: Protected

				/**
				 * @override
				 */
				initContextHelp: function() {
					this.set("ContextHelpId", 1002);
					this.callParent(arguments);
				},

				/**
				 * ######## "######## ## #####".
				 */
				openShowOnMap: function() {
					var items = this.getSelectedItems();
					var select = this.Ext.create("Terrasoft.EntitySchemaQuery", {
						rootSchemaName: "Contact"
					});
					select.addColumn("Id");
					select.addColumn("Name");
					select.addColumn("Address");
					select.addColumn("City");
					select.addColumn("Region");
					select.addColumn("Country");
					select.addColumn("GPSN");
					select.addColumn("GPSE");
					select.filters.add("ContactIdFilter", this.Terrasoft.createColumnInFilterWithParameters("Id", items));
					select.getEntityCollection(function(result) {
						if (result.success) {
							var mapsConfig = {
								mapsData: []
							};
							result.collection.each(function(item) {
								var address = [];
								var country = item.get("Country");
								if (country && country.displayValue) {
									address.push(country.displayValue);
								}
								var region = item.get("Region");
								if (region && region.displayValue) {
									address.push(region.displayValue);
								}
								var city = item.get("City");
								if (city && city.displayValue) {
									address.push(city.displayValue);
								}
								address.push(item.get("Address"));
								var name = item.get("Name");
								var dataItem = {
									caption: name,
									content: "<h2>" + name + "</h2><div>" + address.join(", ") + "</div>",
									address: item.get("Address") ? address.join(", ") : null,
									gpsN: item.get("GPSN"),
									gpsE: item.get("GPSE"),
									updateCoordinatesConfig: {
										schemaName: "Contact",
										id: item.get("Id")
									}
								};
								mapsConfig.mapsData.push(dataItem);
							});
							var mapsModuleSandboxId = this.sandbox.id + "_MapsModule" + this.Terrasoft.generateGUID();
							this.sandbox.subscribe("GetMapsConfig", function() {
								return mapsConfig;
							}, [mapsModuleSandboxId]);
							this.sandbox.loadModule("MapsModule", {
								id: mapsModuleSandboxId,
								keepAlive: true
							});
						}
					}, this);
				},

				/**
				 * Synchronizes with Google contacts.
				 * @protected
				 */
				synchronizeNow: function() {
					if (this.get("canUseGoogleOrSocialFeaturesByBuildType")) {
						this.synchronizeWithGoogleContacts();
					} else {
						if (!this.get("IsExchangeContactSyncExist")) {
							this.showConfirmationDialog(this.get("Resources.Strings.FolderNotSet"), function(result) {
								if (result === Terrasoft.MessageBoxButtons.YES.returnCode) {
									this.showSyncDialog();
								}
							}, ["yes", "no"]);
						}
					}
				},

				/**
				 * Action "Synchronize with Google Contacts".
				 * @protected
				 */
				synchronizeWithGoogleContacts: function() {
					this.checkCanUseGoogleContactsSync(function() {
						this.showBodyMask();
						if (!this.get("GoogleSyncExists") && !this.get("IsExchangeContactSyncExist")) {
							this.showConfirmationDialog(this.get("Resources.Strings.FolderNotSet"), function(result) {
								if (result === Terrasoft.MessageBoxButtons.YES.returnCode) {
									this.showSyncDialog();
								}
							}, ["yes", "no"]);
							this.hideBodyMask();
							return;
						}
						if (!this.get("GoogleSyncExists") && this.get("IsExchangeContactSyncExist")) {
							this.hideBodyMask();
							return;
						}
						this.startGoogleSynchronization();
					}, this);
				},

				/**
				 * @deprecated
				 */
				fillContactWithSocialNetworksData: function() {
					var activeRowId = this.get("ActiveRow");
					var selectedRowIds = this.get("SelectedRows");
					if (!activeRowId) {
						if (selectedRowIds.length > 0) {
							activeRowId = selectedRowIds[0];
						}
					}
					var confirmationMessage = this.get("Resources.Strings.OpenContactCardQuestion");
					var esq = this.Ext.create("Terrasoft.EntitySchemaQuery", {
						rootSchemaName: "Contact"
					});
					esq.addColumn("FacebookId");
					esq.addColumn("LinkedInId");
					esq.addColumn("TwitterId");
					var filters = this.Ext.create("Terrasoft.FilterGroup");
					filters.addItem(esq.createColumnFilterWithParameter(this.Terrasoft.ComparisonType.EQUAL,
						"Id", activeRowId));
					esq.filters = filters;
					esq.getEntity(activeRowId, function(result) {
						if (result.success && result.entity) {
							var entity = result.entity;
							var facebookId = entity.get("FacebookId");
							var linkedInId = entity.get("LinkedInId");
							var twitterId = entity.get("TwitterId");
							if (facebookId !== "" || linkedInId !== "" || twitterId !== "") {
								this.sandbox.publish("PushHistoryState", {
									hash: "FillContactWithSocialAccountDataModule",
									stateObj: {
										FacebookId: facebookId,
										LinkedInId: linkedInId,
										TwitterId: twitterId,
										ContactId: activeRowId
									}
								});
							} else {
								this.Terrasoft.utils.showConfirmation(confirmationMessage,
									function getSelectedButton(returnCode) {
										if (returnCode === this.Terrasoft.MessageBoxButtons.YES.returnCode) {
											this.editRecord(activeRowId);
											if (!this.get("ActiveRow") && selectedRowIds.length > 0) {
												this.unSetMultiSelect();
											}
										}
									}, ["yes", "no"], this, null);
							}
						}
					}, this);
				},

				/**
				 * ########## ######### ######## ####### # ###### ########### #######.
				 * @protected
				 * @override
				 * @return {Terrasoft.BaseViewModelCollection} ########## ######### ######## ####### # ######.
				 * ########### #######
				 */
				getSectionActions: function() {
					var actionMenuItems = this.callParent(arguments);
					actionMenuItems.addItem(this.getButtonMenuItem({
						Type: "Terrasoft.MenuSeparator",
						Caption: ""
					}));
					actionMenuItems.addItem(this.getButtonMenuItem({
						"Click": {"bindTo": "openShowOnMap"},
						"Caption": {"bindTo": "Resources.Strings.ShowOnMapActionCaption"},
						"Enabled": {"bindTo": "isAnySelected"}
					}));
					if (this.isCanActualizeAge()) {
						actionMenuItems.addItem(this._getActualizeAgeButtonMenuItem());
					}
					if (this.isCanRescheduleAgeActualization()) {
						actionMenuItems.addItem(this._getRescheduleAgeActualizationButtonMenuItem());
					}
					return actionMenuItems;
				},

				/**
				 * Checks if can actualize age.
				 * @protected
				 * @return {Boolean}
				 */
				isCanActualizeAge: function() {
					return this.$CanRunActualizeContactAgeProcess && this.$IsActiveActualizeContactAge;
				},

				/**
				 * Checks if can set time of daily age actualization.
				 * @protected
				 * @return {Boolean}
				 */
				isCanRescheduleAgeActualization: function() {
					return this.isCanActualizeAge() && this.$IsActiveRunAgeActualizationDaily;
				},

				/**
				 * Handles confirmation dialog return code and run process ContactActualizeAgeProcess.
				 * @protected
				 * @param {Terrasoft.MessageBoxButtons} returnCode Confirmation dialog return code.
				 *
				 */
				runActualizeAgeConfirmationCallback: function(returnCode) {
					if (returnCode !== this.Terrasoft.MessageBoxButtons.YES.returnCode) {
						return;
					}

					var processConfig = this._getContactActualizeAgeProcessConfig();
					ProcessModuleUtilities.executeProcess(processConfig);

					var jobRestartProcessConfig = this._getAgeActualizationJobRestartProcessConfig();
					ProcessModuleUtilities.executeProcess(jobRestartProcessConfig);
				},

				//endregion

				// region Methods: Public

				/**
				 * Initializes the initial values of the model.
				 * @override
				 */
				init: function() {
					this._initCanRunActualizeProcess();
					this._initActualizeAgeSysSettingsValue();
					this._initRunAgeActualizationDailySysSettingsValue();
					this.set("GridType", "tiled");
					this.callParent(arguments);
					var sysSettings = ["BuildType"];
					this.mixins.GoogleIntegrationUtils.init.call(this);
					Terrasoft.SysSettings.querySysSettings(sysSettings, function() {
						var buildType = Terrasoft.SysSettings.cachedSettings.BuildType &&
							Terrasoft.SysSettings.cachedSettings.BuildType.value;
						this.set("canUseGoogleOrSocialFeaturesByBuildType", buildType !==
							ConfigurationConstants.BuildType.Public);
					}, this);
				},

				/**
				 * Shows dialog to set up time of daily age actualization
				 * @public
				 */
				showRescheduleAgeActualizationDialog: function() {
					var modalBoxContainer = ModalBox.show({
						widthPixels: 420,
						heightPixels: 245
					});
					var timeEditModuleConfig = this._getTimeEditModalBoxConfig(modalBoxContainer);
					this.loadModule(timeEditModuleConfig);
				},

				/**
				 * Shows confirmation dialog for running process ContactActualizeAgeProcess.
				 * @virtual
				 */
				runActualizeAgeProcess: function() {
					var runActualizeAgeConfirmationMessage = this.get("Resources.Strings.RunActualizeAgeConfirmationMessage");
					var messageBoxButtons = this.Terrasoft.MessageBoxButtons;
					this.showConfirmationDialog(
						runActualizeAgeConfirmationMessage,
						this.runActualizeAgeConfirmationCallback,
						[messageBoxButtons.YES.returnCode, messageBoxButtons.NO.returnCode]
					);
				},

				/**
				 * Shows confirmation dialog for running process ContactAgeActualizationJobRestartProcess.
				 * @virtual
				 */
				runRescheduleAgeActualization: function() {
					this.showRescheduleAgeActualizationDialog();
				}

				//endregion

			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "merge",
					"name": "DataGridContainer",
					"values": {
						"controlConfig": {
							"classes": ["contact-grid"]
						}
					}
				}
			]/**SCHEMA_DIFF*/
		};
	});

define('ContactSectionV2ExchangeResources', ['terrasoft'], function(Terrasoft) {
var localizableStrings={

};
var parametersLocalizableStrings={};
var localizableImages={

};
return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});
define("ContactSectionV2Exchange", ["SyncSettingsMixin"],
	function() {
		return {
			entitySchemaName: "Contact",
			messages: {
				/**
				 * @message ShowSyncSettingsSetTip
				 * Notify to show tip about completed set sync settings.
				 */
				"ShowSyncSettingsSetTip": {
					mode: Terrasoft.MessageMode.PTP,
					direction: Terrasoft.MessageDirectionType.SUBSCRIBE
				}
			},
			mixins: {
				/**
				 * Activity synchronization mixin.
				 */
				"SyncSettinsMixin": "Terrasoft.SyncSettingsMixin"
			},
			attributes: {
				/**
				 * Flag for visibility of the completed synchronization.
				 */
				"IsSyncSettingsSetTipVisible": {dataValueType: Terrasoft.DataValueType.BOOLEAN}
			},
			methods: {

				/**
				 * @overridden
				 */
				init: function() {
					this.callParent(arguments);
					this.initContactSyncSettings();
					this.sandbox.subscribe("ShowSyncSettingsSetTip", this.updateSyncSettingsSetAndShowTip, this);
				},

				/**
				 * ######### ####### ######## ############# ######### # Exchange
				 * # ############# ############### ######## ######.
				 * @protected
				 */
				initContactSyncSettings: function() {
					this.set("IsExchangeContactSyncExist", false);
					var select = this.getBaseContactSyncSettingsSelect();
					select.addAggregationSchemaColumn("Id", this.Terrasoft.AggregationType.COUNT, "Count");
					select.getEntityCollection(function(response) {
						if (response.success) {
							this.set("IsExchangeContactSyncExist", response.collection.getCount() > 0 &&
								response.collection.getItems()[0].get("Count") > 0);
						}
					}, this);
				},

				/**
				 * ############## ######## # Exchange.
				 * @protected
				 */
				synchronizeExchangeContacts: function() {
					var select = this.getBaseContactSyncSettingsSelect();
					select.addColumn("Id");
					select.addColumn("[MailboxSyncSettings:Id:MailboxSyncSettings].SenderEmailAddress",
						"SenderEmailAddress");
					select.getEntityCollection(function(response) {
						if (response.success) {
							if (response.collection.getCount() < 1) {
								return;
							}
							this.createSyncJobs(response.collection);
						} else {
							this.Terrasoft.utils.showInformation(
								this.get("Resources.Strings.ReadSyncSettingsBadResponse")
							);
						}
					}, this);
				},

				/**
				 * ####### # ########## ############ ###### ## ############# ######### # ####### Exchange.
				 * @private
				 * @param {Terrasoft.Collection} collection ######### ########### #########.
				 */
				createSyncJobs: function(collection) {
					var requestsCount = 0;
					var messageArray = [];
					var requestUrl = this.Terrasoft.workspaceBaseUrl +
						"/rest/MailboxSettingsService/CreateContactSyncJob";
					collection.each(function(item) {
						var data = {
							interval: 0,
							senderEmailAddress: item.get("SenderEmailAddress")
						};
						this.showBodyMask();
						requestsCount++;
						this.Terrasoft.AjaxProvider.request({
							url: requestUrl,
							headers: {
								"Content-Type": "application/json",
								"Accept": "application/json"
							},
							method: "POST",
							jsonData: data,
							scope: this,
							callback: function(request, success, response) {
								if (success) {
									var responseData = Ext.decode(response.responseText);
									if (!Ext.isEmpty(responseData.CreateContactSyncJobResult)) {
										messageArray = messageArray.concat(responseData.CreateContactSyncJobResult);
									}
								}
								if (--requestsCount <= 0) {
									var message = this.get("Resources.Strings.SynchronizeExchangeSuccessMessage");
									if (messageArray.length > 0) {
										message = "";
										this.Terrasoft.each(messageArray, function(element) {
											message = message.concat(element);
										}, this);
									}
									this.hideBodyMask();
									this.Terrasoft.utils.showInformation(message);
								}
							}
						});
					}, this);
				},

				/**
				 * ########## {Terrasoft.EntitySchemaQuery} # ######### ## ############
				 * # ####### #### ############# #########.
				 * @private
				 */
				getBaseContactSyncSettingsSelect: function() {
					var select = this.Ext.create("Terrasoft.EntitySchemaQuery", {
						rootSchemaName: "ContactSyncSettings"
					});
					select.filters.addItem(select.createColumnFilterWithParameter(this.Terrasoft.ComparisonType.EQUAL,
						"[MailboxSyncSettings:Id:MailboxSyncSettings].SysAdminUnit",
						this.Terrasoft.SysValue.CURRENT_USER.value));
					var filterGroup = select.createFilterGroup();
					filterGroup.name = "SynContactsFilterGroup";
					filterGroup.logicalOperation = this.Terrasoft.LogicalOperatorType.OR;
					filterGroup.addItem(select.createColumnFilterWithParameter(this.Terrasoft.ComparisonType.EQUAL,
						"ImportContacts", true));
					filterGroup.addItem(select.createColumnFilterWithParameter(this.Terrasoft.ComparisonType.EQUAL,
						"ExportContacts", true));
					select.filters.addItem(filterGroup);
					return select;
				},

				/**
				 * @inheritDoc Terrasoft.BaseSection#getSectionActions
				 * @overridden
				 */
				getSectionActions: function() {
					var actionMenuItems = this.callParent(arguments);
					if (this.get("canUseGoogleOrSocialFeaturesByBuildType")) {
						this.setSyncSectionActions(actionMenuItems);
					}
					return actionMenuItems;
				},

				/**
				 * @inheritdoc Terrasoft.ContactSectionV2#synchronizeNow
				 * @overridden
				 */
				synchronizeNow: function() {
					this.callParent(arguments);
					if (this.get("IsExchangeContactSyncExist")) {
						this.synchronizeExchangeContacts();
					}
				},

				/**
				 * Returns set sync settings section action caption.
				 * @overridden
				 * @return {String} Caption.
				 */
				getSetSyncSettingsCaption: function() {
					return this.get("Resources.Strings.SetUpSynchronization");
				},

				/**
				 * Start synchronization with google account.
				 */
				synchronizeGoogle: function() {
					this.synchronizeWithGoogleContacts();
				},

				/**
				 * Start synchronization with exchange account.
				 */
				synchronizeExchange: function() {
					this.synchronizeExchangeContacts();
				},

				/**
				 * @inheritDoc Terrasoft.SyncSettinsMixin#updateSyncSettingsSetAndShowTip
				 * @overridden
				 */
				updateSyncSettingsSetAndShowTip: function(itemId) {
					if (itemId) {
						this.set("IsExchangeContactSyncExist", true);
					} else {
						this.set("GoogleSyncExists", true);
					}
					this.mixins.SyncSettinsMixin.updateSyncSettingsSetAndShowTip.call(this, itemId);
				}
			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "merge",
					"name": "SeparateModeActionsButton",
					"values": {
						"tips": []
					}
				},
				{
					"operation": "insert",
					"parentName": "SeparateModeActionsButton",
					"propertyName": "tips",
					"name": "SyncSettingsSetTip",
					"values": {
						"content": {"bindTo": "Resources.Strings.SyncSettingsSetTipCaption"},
						"visible": {"bindTo": "IsSyncSettingsSetTipVisible"},
						"style": Terrasoft.TipStyle.GREEN,
						"linkClicked": {bindTo: "navigateToSyncSettingsWithSyncSettingsUpdate"},
						"behaviour": {
							"displayEvent": Terrasoft.TipDisplayEvent.NONE
						}
					}
				}
			]/**SCHEMA_DIFF*/
		};
	});

define('ContactSectionV2OSMResources', ['terrasoft'], function(Terrasoft) {
var localizableStrings={

};
var parametersLocalizableStrings={};
var localizableImages={

};
return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});
define("ContactSectionV2OSM", ["MapsUtilities", "MapsHelper"],
	function(MapsUtilities, MapsHelper) {
		return {
			entitySchemaName: "Contact",
			methods: {
				/**
				 * ######## "######## ## #####".
				 */
				openShowOnMap: function() {
					MapsHelper.openShowOnMap.call(this, this.entitySchemaName, function(mapsConfig) {
						MapsUtilities.open({
							scope: this,
							mapsConfig: mapsConfig
						});
					});
				}
			},
			diff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/
		};
	});

define('ContactSectionV2SocialNetworkIntegrationResources', ['terrasoft'], function(Terrasoft) {
var localizableStrings={

};
var parametersLocalizableStrings={};
var localizableImages={

};
return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});
define("ContactSectionV2SocialNetworkIntegration", [],
		function() {
			return {
				entitySchemaName: "Contact",
				methods: {},
				diff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/
			};
		}
)

define("ContactSectionV2", [], function() {
		return {
			methods: {
				/**
				 * @inheritdoc BaseDataView#setCanSearchDuplicatesAttributes
				 * @override
				 */
				setCanSearchDuplicatesAttributes: function(canSearchDuplicatesOperation) {
					this.callParent(arguments);
					this.set("DeduplicationEnabled", this.getIsDeduplicationEnable());
					const isEnabled = canSearchDuplicatesOperation && this.$DeduplicationEnabled;
					this.set("canSearchDuplicates", this.$canSearchDuplicates || isEnabled);
				}
			}
		};
	}
);


