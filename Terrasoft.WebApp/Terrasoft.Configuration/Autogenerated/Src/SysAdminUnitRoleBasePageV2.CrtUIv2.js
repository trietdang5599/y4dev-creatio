define("SysAdminUnitRoleBasePageV2", ["ConfigurationConstants", "SysAdminUnitRoleBasePageV2Resources", "ProcessModuleUtilities",
									  "RightUtilities"],
	function(ConfigurationConstants, resources, ProcessModuleUtilities, RightUtilities) {
		return {
			entitySchemaName: "VwSysAdminUnit",
			details: /**SCHEMA_DETAILS*/{
				UsersDetailV2: {
					schemaName: "UsersDetailV2",
					filter: {
						masterColumn: "Id",
						detailColumn: "[SysUserInRole:SysUser:Id].[SysAdminUnit:Id:SysRole].Id"
					},
					defaultValues: {
						ConnectionType: {
							masterColumn: "ConnectionType"
						},
						IsParentRoleExist: {
							masterColumn: "IsParentRoleExist"
						}
					}
				},
				SysAdminUnitIPRangeDetailV2: {
					schemaName: "SysAdminUnitIPRangeDetailV2",
					filter: {
						masterColumn: "Id",
						detailColumn: "SysAdminUnit"
					}
				},
				SysFuncRoleInOrgRoleDetailV2: {
					schemaName: "SysFuncRoleInOrgRoleDetailV2",
					filter: {
						masterColumn: "Id"
					}
				},
				SysLicPackageInRoleDetail: {
					schemaName: "SysLicPackageInRoleDetail",
					filter: {
						masterColumn: "Id",
						detailColumn: "SysRole"
					}
				}
			}/**SCHEMA_DETAILS*/,
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "insert",
					"parentName": "Header",
					"propertyName": "items",
					"name": "Name",
					"values": {
						"layout": {"column": 0, "row": 0, "colSpan": 24}
					}
				},
				{
					"operation": "insert",
					"parentName": "Tabs",
					"propertyName": "tabs",
					"index": 0,
					"name": "UsersTab",
					"values": {
						"caption": {"bindTo": "Resources.Strings.UsersTabCaption"},
						"items": []
					}
				},
				{
					"operation": "insert",
					"parentName": "UsersTab",
					"propertyName": "items",
					"name": "UsersDetailV2",
					"values": {
						"itemType": this.Terrasoft.ViewItemType.DETAIL
					}
				},
				{
					"operation": "insert",
					"parentName": "LicensesTab",
					"propertyName": "items",
					"name": "SysLicPackageInRoleDetail",
					"values": {
						"itemType": this.Terrasoft.ViewItemType.DETAIL
					}
				},
				{
					"operation": "insert",
					"parentName": "Tabs",
					"propertyName": "tabs",
					"index": 30,
					"name": "LicensesTab",
					"values": {
						"caption": {"bindTo": "Resources.Strings.LicensesTabCaption"},
						"items": []
					}
				},
				{
					"operation": "remove",
					"name": "ESNTab"
				}
			]/**SCHEMA_DIFF*/,
			attributes: {

				/**
				 * ####### ####, ### ############ #### ##########.
				 */
				"IsParentRoleExist": {
					"dataValueType": this.Terrasoft.DataValueType.BOOLEAN
				},
				
				/**
				 * Specifies if role-based license distribution enabled.
				 */
				"RoleBasedLicenseDistributionEnabled": {
					"dataValueType": this.Terrasoft.DataValueType.BOOLEAN
				},

				/**
				 * ######## ######## ###### ## ####### ###### #### # ############ ### ############# ########.
				 */
				"SecurityOperationName": {
					"dataValueType": this.Terrasoft.DataValueType.STRING,
					"value": "CanManageUsers"
				},

				/**
				 * ######## #### ConnectionType ######, ####### ######## ######### ##
				 * ######### # #######.
				 */
				"ParentRoleConnectionType": {
					"dataValueType": this.Terrasoft.DataValueType.INTEGER,
					"type": this.Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN
				}
			},
			methods: {
				/**
				 * @inheritDoc Terrasoft.BaseModulePageV2#init
				 * @overridden
				 */
				init: function() {
					this.callParent(arguments);
					if (this.isAddMode()) {
						var result = this.sandbox.publish("SetRecordInformation", {},
							[this.sandbox.id]);
						this.set("ParentRole", {value: result.parent});
						this.set("SysAdminUnitType", {value: result.type});
						this.set("ParentRoleConnectionType", result.connectionType);
						this.set("ConnectionType", result.connectionType);
					}
					this.initRoleBasedLicenseDistributionEnabled();
					var deleteButtonEnable = this.checkOpportunityForDelete();
					this.set("DeleteButtonEnable", deleteButtonEnable);
				},

				 /**
				 * @inheritDoc BasePageV2#onRender
				 * @overridden
				 */
				onRender: function() {
				    this.callParent(arguments);
				    var tabs = this.get("TabsCollection");
					var roleBaseLicenseDistributionDisabled = !this.$RoleBasedLicenseDistributionEnabled;
				    if (roleBaseLicenseDistributionDisabled) {
				        tabs.removeByKey("LicensesTab");
				    }
				},

				/**
				 * @inheritDoc BasePageV2#onEntityInitialized
				 * @overridden
				 */
				onEntityInitialized: function() {
					this.callParent(arguments);
					var parentRole = this.get("ParentRole");
					this.set("IsParentRoleExist", !this.Ext.isEmpty(parentRole));
				},

				/**
				 * ######### ######## ## #######. #### ######## ### ########## ##### ######### ########## ######,
				 * ##### - ########## ##### ########.
				 * @param {Function} callback #######, ####### ##### ####### ### ######### ###### ## #######
				 * @param {Object} scope ########, # ####### ##### ####### ####### callback
				 * @inheritDoc Terrasoft.BaseViewModel#saveEntity
				 * @overridden
				 */
				saveEntity: function(callback, scope) {
					var changedColumns = {};
					var systemColumns = ["CreatedOn", "CreatedBy", "ModifiedOn", "ModifiedBy"];
					this.Terrasoft.each(this.entitySchema.columns,
						function(column) {
							if (this.changedValues.hasOwnProperty(column.name) && systemColumns.indexOf(column.name) < 0) {
								var columnValue = this.get(column.name);
								changedColumns[column.name] =  this.Ext.isEmpty(columnValue) ?
									null:
									columnValue.value || columnValue;
							}
						}, this);
					if (this.Terrasoft.isEmptyObject(changedColumns)) {
						this.cardSaveResponse = {success: true};
						callback.call(scope || this, {success: true});
					} else {
						if (this.Ext.isEmpty(changedColumns.Id)) {
							changedColumns.Id = this.get("Id");
						}
						if (this.Ext.isEmpty(changedColumns.SysAdminUnitType)) {
							changedColumns.SysAdminUnitType = this.get("SysAdminUnitType").value;
						}
						if (this.isAddMode()) {
							changedColumns.ConnectionType = this.get("ConnectionType");
						}
						var dataSend = {
							jsonObject: this.Ext.encode(changedColumns)
						};
						var config = {
							serviceName: "AdministrationService",
							methodName: "SaveRole",
							data: dataSend
						};
						this.callService(config, this.onSaveRoleResponse.bind(scope, callback), this);
					}
				},

				/**
				 * ######### ########### ######## ####### ###### (###### ## ######## ###### "#######" # #### ######
				 * "########").
				 * @return {boolean} ########## true, #### ##### ####### ###### ########.
				 */
				checkOpportunityForDelete: function() {
					var id = this.get("Id");
					if (this.Ext.isEmpty(id)) {
						return false;
					}
					var parent = this.get("ParentRole");
					return !this.Ext.isEmpty(parent) && id !== ConfigurationConstants.SysAdminUnit.Id.SysAdministrators;
				},

				/**
				 * ######## ########## ###### ## ####### # ######## ########## ####### ######### ######.
				 * @private
				 * @param {Function} callback ####### ######### ######.
				 * @param {Object} response ##### ## #######.
				 */
				onSaveRoleResponse: function(callback, response) {
					this.validateSaveRoleResponse(response);
					callback.call(this, response);
				},

				/**
				 * ######### ######### ###### ## #######.
				 * @private
				 * @param {Object} response ##### ## #######.
				 */
				validateSaveRoleResponse: function(response) {
					if (response && response.SaveRoleResult) {
						var result = this.Ext.decode(response.SaveRoleResult);
						response.success = result.success;
						if (result.success) {
							response.id = result.roleId;
							response.rowsAffected = 1;
							response.nextPrcElReady = false;
							this.isNew = false;
							this.changedValues = null;
						} else {
							this.showInformationDialog(result.message);
						}
					}
				},

				/**
				 * @inheritDoc Terrasoft.BaseViewModel#onSilentSaved
				 * @overridden
				 */
				onSilentSaved: function() {
					this.callParent(arguments);
					var deleteButtonEnable = this.checkOpportunityForDelete();
					this.set("DeleteButtonEnable", deleteButtonEnable);
				},

				/**
				 * ######### ######## ########### ######## ####### ######. #### ######## ######### ########,
				 * ## ######## #######, ####### ## SysAdminUnitSectionV2 ############## ####### ######## ######
				 * #######.
				 */
				canRemoveRecord: function() {
					var dataSend = {
						parentRoleId: this.get("Id")
					};
					var config = {
						serviceName: "AdministrationService",
						methodName: "GetChildAdminUnitsAndUsersCount",
						data: dataSend
					};
					this.callService(config, this.onGetChildAdminUnitsAndUsersCountResponse, this);
				},

				/**
				 * ############ ###### # GetChildAdminUnitsAndUsersCount # ########## ##### ## ######### ########
				 * ###### ### ######## ######### ############ # ############# ########.
				 * @param response {Object} ######, ########## ########.
				 */
				onGetChildAdminUnitsAndUsersCountResponse: function(response) {
					if (response && response.GetChildAdminUnitsAndUsersCountResult) {
						var result = {};
						response.GetChildAdminUnitsAndUsersCountResult.forEach(function(item) {
							result[item.Key] = item.Value;
						});
						if (result.userCount === 0) {
							this.showConfirmationDialog(this.get("Resources.Strings.DeleteConfirmationMessage"),
								function(returnCode) {
									if (returnCode === this.Terrasoft.MessageBoxButtons.YES.returnCode) {
										if (this.get("IsInChain")) {
											this.onCloseClick();
										}
										this.sandbox.publish("RemoveRecordAndGoToParent", {
												deletedItems: result.deletedItems,
												parent: this.get("ParentRole").value,
												IsConfirmedDelete: true
											},
											[this.sandbox.id]);
									}
								},
								[
									this.Terrasoft.MessageBoxButtons.YES.returnCode,
									this.Terrasoft.MessageBoxButtons.NO.returnCode
								],
								null);

						} else {
							this.showInformationDialog(this.get("Resources.Strings.DeletionErrorMessage"));
						}
						this.set("ServiceDataLoaded", true);
					}
				},

				/**
				 * #### # ###### ######### ###### ######## #### ###### ### ######## ## #####, ## ####### ## ## ######.
				 * @param {Object} actionMenuItems ###### ######### ###### ########.
				 * @protected
				 */
				removeSubscribeButton: function(actionMenuItems) {
					var subscribeButtonIndex;
					actionMenuItems.each(function(item, index) {
						if (item.values.Tag === "subscribeUser") {
							subscribeButtonIndex = index;
						}
					});
					if (subscribeButtonIndex) {
						actionMenuItems.removeByIndex(subscribeButtonIndex);
					}
				},

				/**
				 * @inheritdoc BaseModulePageV2#getActions
				 * @overridden
				 */
				getActions: function() {
					var actionMenuItems = this.callParent(arguments);
					if(this.$RoleBasedLicenseDistributionEnabled) {
						var licenseRedistributionAction = this.getRedistributeLicencesForSpecificRoleAction();
						actionMenuItems.addItem(licenseRedistributionAction);
					}
					this.removeSubscribeButton(actionMenuItems);
					actionMenuItems.addItem(this.getButtonMenuItem({
						"Caption": {"bindTo": "Resources.Strings.RemoveButtonCaption"},
						"Enabled": { "bindTo": "DeleteButtonEnable" },
						"Tag": "canRemoveRecord"
					}));
					return actionMenuItems;
				},
				
				/**
				 * Initializes state about appropriate rights for role-based license distribution
				 * @protected
				 */
				initRoleBasedLicenseDistributionEnabled: function() {
					RightUtilities.checkCanExecuteOperation({
						operation: "CanManageLicUsers"
					}, function(canExecuteOperation) {
						var featureEnabled = this.getIsFeatureEnabled("UseRoleBasedLicenseDistribution");
						this.$RoleBasedLicenseDistributionEnabled = featureEnabled && canExecuteOperation;
					}, this);
				},
				
				/**
				 * Returns license redistribution action button.
				 * @protected
				 */
				getRedistributeLicencesForSpecificRoleAction: function() {
					var licenseRedistributionAction =  this.getActionsMenuItem({
						"Caption": {"bindTo": "Resources.Strings.RedistributeLicensesCaption"},
						"Tag": "redistributeLicencesForSpecificRole"
					});
					return licenseRedistributionAction;
				},
				
				/**
				 * Executes license redistribution for specific role
				 * @protected
				 */
				redistributeLicencesForSpecificRole: function() {
					var questionText = resources.localizableStrings.RemoveManuallyIssuedLicensesQuestion;
					var removeButtonText = resources.localizableStrings.RemoveButtonText;
					var keepButtonText = resources.localizableStrings.KeepButtonText;
					var removeButton = this.createConfirmationWindowButton(removeButtonText, "remove", 
																		   Terrasoft.controls.ButtonEnums.style.DEFAULT);
					var keepButton = this.createConfirmationWindowButton(keepButtonText, "keep", 
																		 Terrasoft.controls.ButtonEnums.style.BLUE);
					var buttonsOptions = [keepButton, removeButton, this.Terrasoft.MessageBoxButtons.CANCEL.returnCode];
					this.showConfirmationDialog(questionText, this.licenseRedistributionHandler, buttonsOptions);
				},
				
				validateLicenseRedistribution: function(roleId, redistributeManuallyAssignedLicences) {
					this.showBodyMask();
					var dataSend = {
						roleId: roleId,
						keepManualLicenses: !redistributeManuallyAssignedLicences
					};
					var config = {
						serviceName: "AdministrationService",
						methodName: "ValidateLicenseDistribution",
						data: dataSend
					};
					this.callService(config, function(response) {
						this.onvalidateLicenseRedistribution(response, roleId, redistributeManuallyAssignedLicences);
    					}, this);
				},

				runRedistributeLicensesProcess: function(roleId, redistributeManuallyAssignedLicences) {
					var processName = "RedistributeLicenses";
                    var processParameters = {
						RedistributeManuallyAssignedLicences: redistributeManuallyAssignedLicences,
						RedistributeLicencesForSpecificRole: true,
						RoleId: roleId
					};
					this.runProcess(processName, processParameters);
                    var confirmationText = resources.localizableStrings.RedistributionProcessStartedMessage;
					this.Terrasoft.utils.showInformation(confirmationText, null, null);
				},
              
				onvalidateLicenseRedistribution: function(response, roleId, redistributeManuallyAssignedLicences) {
					this.hideBodyMask();
					if (!response
						|| !response.ValidateLicenseDistributionResult
						|| response.ValidateLicenseDistributionResult.success === undefined) {
						return;
					}
					var success = response.ValidateLicenseDistributionResult.success;
					if (!success) {
						var errorCode = response.ValidateLicenseDistributionResult.errorInfo?.errorCode;
						if (errorCode) {
							return;
						}
						var validationMessage = response.ValidateLicenseDistributionResult.errorInfo?.message;
						if (!validationMessage) {
							this.runRedistributeLicensesProcess(roleId, redistributeManuallyAssignedLicences);
						}
						this.confirmRedistributionIfHasNoLicensedUsers(roleId, redistributeManuallyAssignedLicences, validationMessage);
					} else {
						this.runRedistributeLicensesProcess(roleId, redistributeManuallyAssignedLicences);
					}
				},

				confirmRedistributionIfHasNoLicensedUsers: function(roleId, redistributeManuallyAssignedLicences, validationMessage) {
					this.showConfirmationDialog(validationMessage,
						function(returnCode) {
							if (returnCode === this.Terrasoft.MessageBoxButtons.YES.returnCode) {
								this.runRedistributeLicensesProcess(roleId, redistributeManuallyAssignedLicences);
							}
						},
						[this.Terrasoft.MessageBoxButtons.NO.returnCode, this.Terrasoft.MessageBoxButtons.YES.returnCode]);
				},
              
				/**
				 * License redistribution confirmation dialog handler
				 * @protected
				 */
				licenseRedistributionHandler: function(result) {
                    if (result === this.Terrasoft.MessageBoxButtons.CANCEL.returnCode){
                      return;
                    }
					var roleId = this.getPrimaryColumnValue();
					var redistributeManuallyAssignedLicences = result === "remove";
                    this.validateLicenseRedistribution(roleId, redistributeManuallyAssignedLicences);
				},
				
				/**
				 * Run process
				 * @protected
				 */
				runProcess: function(name, parameters) {
					var processToBeExecuted = {
						sysProcessName: name,
						parameters: parameters
					};
					ProcessModuleUtilities.executeProcess(processToBeExecuted);
				},

				/**
				 * Create button for confirmation dialog
				 * @protected
				 */
				createConfirmationWindowButton: function(caption, returnCode, color) {
					var button = {
							className: "Terrasoft.Button",
							style: color,
							caption: caption,
							markerValue: caption,
							returnCode: returnCode
					};
					return button;
				}
			},
			messages: {

				/**
				 * ######## ########## # ######## # #### ### ######.
				 */
				"SetRecordInformation": {
					mode: this.Terrasoft.MessageMode.PTP,
					direction: this.Terrasoft.MessageDirectionType.PUBLISH
				},

				/**
				 * ######## # ############# ####### ######## ## ####### # ####### # ############# ########.
				 */
				"RemoveRecordAndGoToParent": {
					mode: this.Terrasoft.MessageMode.PTP,
					direction: this.Terrasoft.MessageDirectionType.PUBLISH
				}
			}
		};
	});
