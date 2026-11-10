define("ContactSectionV2", ["ProcessModuleUtilities", "RightUtilities", "ConfigurationConstants", "ModalBox",
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
