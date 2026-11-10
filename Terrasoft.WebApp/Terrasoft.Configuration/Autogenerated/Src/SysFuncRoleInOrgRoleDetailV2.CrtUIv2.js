define("SysFuncRoleInOrgRoleDetailV2", ["terrasoft", "ConfigurationConstants"],
	function(Terrasoft, ConfigurationConstants) {
		return {
			entitySchemaName: "SysFuncRoleInOrgRole",
			methods: {

				/**
				 * @inheritdoc Terrasoft.BaseGridDetailV2#addDetailWizardMenuItems
				 * @overridden
				 */
				addDetailWizardMenuItems: this.Terrasoft.emptyFn,

				/**
				 * @inheritdoc Terrasoft.BaseGridDetailV2#getAddRecordButtonEnabled
				 * @overridden
				 */
				getAddRecordButtonEnabled: function() {
					return true;
				},

				/**
				 * ######### ###### # ###### ######. ####### ####### ######.
				 * @inheritdoc SysFuncRoleChiefInOrgRoleDetailV2#loadGridData
				 * @overridden
				 */
				loadGridData: function() {
					this.beforeLoadGridData();
					var esq = this.getGridDataESQ();
					this.initQueryColumns(esq);
					this.initQuerySorting(esq);
					this.initQueryFilters(esq);
					this.initQueryOptions(esq);
					this.initQueryEvents(esq);
					esq.getEntityCollection(function(response) {
						this.destroyQueryEvents(esq);
						this.onGridDataLoaded(response);
					}, this);
				},

				/**
				 * @inheritdoc Terrasoft.SysFuncRoleChiefInOrgRoleDetailV2#getRoleLookupFilter
				 * @overridden
				 */
				getRoleLookupFilter: function() {
					var filters = Terrasoft.createFilterGroup();
					var typeFilter = this.Terrasoft.createColumnInFilterWithParameters("SysAdminUnitTypeValue",
						this.getFilterRoleType());
					var notExistsFilter = this.Terrasoft.createNotExistsFilter(
						"[SysFuncRoleInOrgRole:FuncRole:Id].Id");
					var subFilter = this.Terrasoft.createColumnFilterWithParameter(
						this.Terrasoft.ComparisonType.EQUAL,
						"OrgRole",
						this.get("MasterRecordId"));
					notExistsFilter.subFilters.addItem(subFilter);
					filters.addItem(notExistsFilter);
					filters.addItem(typeFilter);
					return filters;
				},

				/**
				 * @inheritdoc Terrasoft.SysFuncRoleChiefInOrgRoleDetailV2#addCallback
				 * @overridden
				 */
				addCallback: function(args) {
					var isOrgRoleDetail = this.isOrgRolesDetail();
					var parentRole = this.get("MasterRecordId");
					var roleIds = args.selectedRows.getKeys();
					var changeType = ConfigurationConstants.SysAdminUnit.RoleOperations.AddFuncRoleToOrgRole;
					this.showBodyMask();
					var config = this.getcheckUserLicensesConfig(isOrgRoleDetail, parentRole, roleIds, changeType);
					this.checkUserLicenses(config, parentRole, roleIds, isOrgRoleDetail);
				},

				checkUserLicenses: function(config, parentRole, roleIds, isOrgRoleDetail) {
					this.callService(config, function(response) {
						var responseBody = response[this.getCheckUsersWillHaveLicensesMethodName() + "Result"];
							if (responseBody.success === false) {
								this.confirmRedistributionIfUserWillHaveNoLicense(responseBody.errorInfo, parentRole, roleIds, isOrgRoleDetail);
							} else {
								this.includeRoleIntoAnotherRole(parentRole, roleIds, isOrgRoleDetail);
							}
					}, this);
				},

				includeRoleIntoAnotherRole: function(parentRole, roleIds, isOrgRoleDetail) {
					var config = this.getAddFuncRolesInOrgRoleConfig(parentRole, roleIds, isOrgRoleDetail);
					this.callService(config, function(response) {
						if (isOrgRoleDetail) {
							response.message = response.AddFuncRoleInOrgRolesResult;
						} else {
							response.message = response.AddFuncRolesInOrgRoleResult;
						}
						response.success = this.Ext.isEmpty(response.message);
						if (this.validateResponse(response)) {
							this.hideBodyMask();
							this.reloadGridData();
						}
					}, this);
				},

				confirmRedistributionIfUserWillHaveNoLicense: function(errorInfo, parentRole, roleIds, isOrgRoleDetail) {
					var validationMessage = errorInfo.message;
					var errorCode = errorInfo.errorCode;
					var buttonsOnException = [this.Terrasoft.MessageBoxButtons.OK];
					var buttonsOfFailedValidation = [this.Terrasoft.MessageBoxButtons.YES.returnCode, 
						this.Terrasoft.MessageBoxButtons.NO.returnCode];
					var buttons = errorCode == 'exception' ? buttonsOnException : buttonsOfFailedValidation;
					this.showConfirmationDialog(validationMessage,
						function(returnCode) {
							if (returnCode === this.Terrasoft.MessageBoxButtons.YES.returnCode) {
								this.includeRoleIntoAnotherRole(parentRole, roleIds, isOrgRoleDetail);
							} else {
								this.hideBodyMask();
							}
					}, buttons);
				},

				getAddFuncRolesInOrgRoleConfig: function(parentRole, roleIds, isOrgRoleDetail) {
					var config = {
						serviceName: "AdministrationService"
					};
					if (isOrgRoleDetail) {
						config.methodName = "AddFuncRoleInOrgRoles";
						config.data = {
							orgRoleIds: this.Ext.encode(roleIds),
							funcRoleId: parentRole
						};
					} else {
						config.methodName = "AddFuncRolesInOrgRole";
						config.data = {
							orgRoleId: parentRole,
							funcRoleIds: this.Ext.encode(roleIds)
						};
					}
					return config;
				},

                /**
                 * @overridden
                 * @return {String} ### #######.
                 */
                getFilterDefaultColumnName: function() {
					if (this.isOrgRolesDetail()) {
						return "OrgRole";
					} else {
						return "FuncRole";
					}
                },

				/**
				 * @protected
				 * @inheritdoc SysFuncRoleChiefInOrgRoleDetailV2#getFilters
				 * @overridden
				 * @return {Terrasoft.FilterGroup}
				 **/
				getFilters: function() {
					var filters = this.get("DetailFilters");
					var serializationInfo = filters.getDefSerializationInfo();
					serializationInfo.serializeFilterManagerInfo = true;
					var deserializedFilters = Terrasoft.deserialize(filters.serialize(serializationInfo));
					deserializedFilters.add("Filter", this.get("Filter"));
					return deserializedFilters;
				}
			}
		};
	});
