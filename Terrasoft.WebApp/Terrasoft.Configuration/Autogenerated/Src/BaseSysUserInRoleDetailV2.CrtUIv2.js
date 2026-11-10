define("BaseSysUserInRoleDetailV2", [
		"terrasoft", "ConfigurationConstants", "ConfigurationEnums",
		"PortalRoleFilterUtilities"
	],
	function(Terrasoft, ConfigurationConstants, enums, PortalRoleFilterUtilities) {
		return {
			messages: {
              "RolesChanged": {
    				mode: Terrasoft.MessageMode.BROADCAST,
    				direction: Terrasoft.MessageDirectionType.PUBLISH
    			},
            },
			entitySchemaName: "SysUserInRole",
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "merge",
					"name": "DataGrid",
					"values": {
						"rowDataItemMarkerColumnName": "SysRole"
					}
				}
			]/**SCHEMA_DIFF*/,
			methods: {
				/**
				 * Validates service response.
				 * @protected
				 * @virtual
				 * @param {Object} AdministrationService response.
				 */
				validateResponse: function(response) {
					var isSuccess = response && response.success;
					if (!isSuccess) {
						this.hideBodyMask();
						var errorMessage = response.message;
						if (errorMessage) {
							this.showInformationDialog(errorMessage);
						}
					}
					return isSuccess;
				},

				/**
				 * @inheritdoc Terrasoft.BaseGridDetailV2#addDetailWizardMenuItems
				 * @overridden
				 */
				addDetailWizardMenuItems: this.Terrasoft.emptyFn,

				/**
				 * @inheritdoc Terrasoft.BaseGridDetailV2#getCopyRecordMenuItem
				 * @overridden
				 */
				getCopyRecordMenuItem: this.Terrasoft.emptyFn,

				/**
				 * @inheritdoc Terrasoft.BaseGridDetailV2#getEditRecordMenuItem
				 * @overridden
				 */
				getEditRecordMenuItem: this.Terrasoft.emptyFn,

				/**
				 * @inheritdoc Terrasoft.BaseGridDetailV2#getFilters
				 * @overridden
				 */
				getFilters: function() {
					var filters = this.Ext.create("Terrasoft.FilterGroup");
					filters = this.callParent(arguments);
					return filters;
				},

				/**
				 * Returns lookupPage config.
				 * @private
				 * @return {Object} config ### lookupPage.
				 */
				getLookupPageConfig: function() {
					var filters = this.Terrasoft.createFilterGroup();
					filters.addItem(this.getRoleLookupFilter());
					var config = {
						entitySchemaName: "SysAdminUnit",
						multiSelect: true,
						columns: ["Name", "SysAdminUnitTypeValue"],
						filters: filters,
						hideActions: true
					};
					return config;
				},

				/**
				 * Returns roles type list.
				 * @private
				 * @return {Array} Roles type list.
				 */
				getSysAdminUnitTypeList: function() {
					return [];
				},

				/**
				 * Forms roles view filters.
				 * @private
				 * @return {Terrasoft.data.filters.FilterGroup} Returns filters group.
				 */
				getRoleLookupFilter: function() {
					var filters = this.Terrasoft.createFilterGroup();
					var notExistsFilter = this.Terrasoft.createNotExistsFilter(
						"[SysUserInRole:SysRole:Id].Id");
					var subFilter = this.Terrasoft.createColumnFilterWithParameter(
						this.Terrasoft.ComparisonType.EQUAL,
						"SysUser",
						this.get("MasterRecordId"));
					notExistsFilter.subFilters.addItem(subFilter);
					filters.addItem(notExistsFilter);
					var roles = this.getSysAdminUnitTypeList();
					filters.addItem(PortalRoleFilterUtilities.getSysAdminUnitFilterGroup(roles));
					return filters;
				},

				/**
				 * @inheritdoc Terrasoft.BaseGridDetailV2#addRecord
				 * @overridden
				 */
				addRecord: function() {
					var cardState = this.sandbox.publish("GetCardState", null, [this.sandbox.id]);
					var isNew = (cardState.state === enums.CardStateV2.ADD ||
						cardState.state === enums.CardStateV2.COPY);
					if (isNew) {
						var args = {
							isSilent: true,
							messageTags: [this.sandbox.id]
						};
						this.sandbox.publish("SaveRecord", args, [this.sandbox.id]);
						return;
					}
					var config = this.getLookupPageConfig();
					this.openLookup(config, this.addCallback, this);
				},

				onMultiDeleteAccept: function() {
                  this.onDeleteAccept();
                },

				publishRolesChangedMessages: function() {
					this.sandbox.publish("RolesChanged");
				},

				/**
				 * @inheritDoc GridUtilitiesV2#onDeleteAccept
				 * @overridden
				 */
				onDeleteAccept: function() {
					this.showBodyMask();
					var changedItems = this.getChangedItems();
					var changeType = ConfigurationConstants.SysAdminUnit.RoleOperations.RemoveUserFromRoleIdentifier;
					var checkUserLicensesConfig = this.getcheckUserLicensesConfig(changedItems, changeType);
					this.checkUserLicenses(checkUserLicensesConfig, changeType, "");
				},
				
				deleteRolesForUser: function() {
					this.callService({
						serviceName: "AdministrationService",
						methodName: this.getOnDeleteAcceptMethodName(),
						data: {
							roleIds: "",
							userIds: "",
							recordIds: this.Ext.encode(this.getSelectedItems())
						}
					}, function(response) {
						var result = this.Ext.decode(response[this.getOnDeleteAcceptMethodName() + "Result"]);
						var success = result.Success;
						var deletedItems = result.DeletedItems;
						this.removeGridRecords(deletedItems);
						this.hideBodyMask();
						if (!success) {
							this.showDeleteExceptionMessage(result);
						}
						this.publishRolesChangedMessages();
						this.onDeleted(result);
					}, this);
				},

				getChangedItems: function(){
					var result = [];
					var items = this.$Collection.collection.items;
					var changedRecordIds = this.getSelectedItems();
					items.forEach(function(item) {
						if (changedRecordIds.includes(item.values.Id)) {
							var role = {
								Id: item.values.SysRole.value,
								SysAdminUnitTypeValue: item.values.SysAdminUnitTypeValue
							};
							result.push(role);
						}
					}, this);
					return result;
				},

				/**
				 * Returns delete user in role method name
				 * @protected
				 * @return {String} Method name.
				 */
				getOnDeleteAcceptMethodName: function() {
					return "RemoveUsersInRoles";
				},

				confirmRedistributionIfUserWillHaveNoLicense: function(validationMessage, selectedRows, changeType, errorCode) {
					var buttonsOnException = [this.Terrasoft.MessageBoxButtons.OK];
					var buttonsOfFailedValidation = [this.Terrasoft.MessageBoxButtons.YES.returnCode, 
						this.Terrasoft.MessageBoxButtons.NO.returnCode];
					var buttons = errorCode == 'exception' ? buttonsOnException : buttonsOfFailedValidation;
					this.showConfirmationDialog(validationMessage,
						function(returnCode) {
							if (returnCode === this.Terrasoft.MessageBoxButtons.YES.returnCode) {
								this.proceedWithUserRolesModification(changeType, selectedRows);
							} else {
								this.hideBodyMask();
							}
						}, buttons);
				},

				/**
				 * @inheritdoc Terrasoft.BaseGridDetailV2#onCardSaved
				 * @overridden
				 */
				onCardSaved: function() {
					var config = this.getLookupPageConfig();
					this.openLookup(config, this.addCallback, this);
				},

				getCheckUsersWillHaveLicensesMethodName: function(){
					return "CheckUsersWillHaveLicenses";
				},

				getOrgRoleTypesList: function() {
					return [
						ConfigurationConstants.SysAdminUnit.Type.Organisation,
						ConfigurationConstants.SysAdminUnit.Type.Department,
						ConfigurationConstants.SysAdminUnit.Type.Manager,
						ConfigurationConstants.SysAdminUnit.Type.Team
					];
				},

				getFuncRoleTypesList: function() {
					return [ConfigurationConstants.SysAdminUnit.Type.FuncRole];
				},

				getSelectedRolesByType: function(items, roleTypes) {
					var result = [];
					items.forEach(function(item) {
						if (roleTypes.includes(item.SysAdminUnitTypeValue)) {
							result.push(item.Id);
						}
					}, this);
					return result;
				},

				/**
				 * After users lookup windows closed callback function.
				 * @virtual
				 * @param {Object} args Object which contains selected records.
				 */
				addCallback: function(args) {
					var items = args.selectedRows.getItems();
					var changeType = ConfigurationConstants.SysAdminUnit.RoleOperations.AddUserToRoleIdentifier;
					var checkUserLicensesConfig = this.getcheckUserLicensesConfig(items, changeType);
					this.showBodyMask();
					this.checkUserLicenses(checkUserLicensesConfig, changeType, args);
				},

				addRolesToUser: function(args){
					var dataSend = {
						roleIds: this.Ext.encode(args.selectedRows.getKeys()),
						userId: this.get("MasterRecordId")
					};
					var config = {
						serviceName: "AdministrationService",
						methodName: this.getAddCallbackMethodName(),
						data: dataSend
					};
					this.showBodyMask();
					this.callService(config, function(response) {
						response.message = response[this.getAddCallbackMethodName() + "Result"];
						response.success = this.Ext.isEmpty(response.message);
						if (this.validateResponse(response)) {
							this.hideBodyMask();
							this.reloadGridData();
							this.publishRolesChangedMessages();
						}
					}, this);
				},

				checkUserLicenses: function(checkUserLicensesConfig, changeType, selectedRows) {
					this.callService(checkUserLicensesConfig, function(response) {
    					var responseBody = response[this.getCheckUsersWillHaveLicensesMethodName() + "Result"];
    						if (responseBody.success === false) {
    							var message = responseBody.errorInfo.message;
								var errorCode = responseBody.errorInfo.errorCode;
    							this.confirmRedistributionIfUserWillHaveNoLicense(message, selectedRows, changeType, errorCode);
    						} else {
								this.proceedWithUserRolesModification(changeType, selectedRows);
    						}
    					}, this);
				},

				proceedWithUserRolesModification: function(changeType, selectedRows) {
					if(changeType === ConfigurationConstants.SysAdminUnit.RoleOperations.AddUserToRoleIdentifier) {
						this.addRolesToUser(selectedRows);
					} else if(changeType === ConfigurationConstants.SysAdminUnit.RoleOperations.RemoveUserFromRoleIdentifier) {
						this.deleteRolesForUser();
					}
				},

				getcheckUserLicensesConfig: function(items, changeType) {
					var orgRoleTypes = this.getOrgRoleTypesList();
					var funcRoleTypes = this.getFuncRoleTypesList();
					var orgRoles = this.getSelectedRolesByType(items, orgRoleTypes);
					var funcRoles = this.getSelectedRolesByType(items, funcRoleTypes);
					var users = [this.get("MasterRecordId")];
					var body = {
						request: {
							orgRoles: orgRoles,
							funcRoles: funcRoles,
							users: users,
							changeRoleOperationType: changeType
						}
					};
					var checkUserLicensesConfig = {
						serviceName: "AdministrationService",
						methodName: this.getCheckUsersWillHaveLicensesMethodName(),
						data: body
					};
					return checkUserLicensesConfig;
				},

				/**
				 * Returns add user in role method name
				 * @protected
				 * @return {String} Method name.
				 */
				getAddCallbackMethodName: function() {
					return "AddUserRoles";
				},
				
				/**
				 * @inheritdoc Terrasoft.GridUtilitiesV2#initQueryColumns
				 * @override
				 */
				initQueryColumns: function(esq) {
					this.callParent(arguments);
					esq.addColumn("SysRole.SysAdminUnitTypeValue",  "SysAdminUnitTypeValue");
				}
			}
		};
	});