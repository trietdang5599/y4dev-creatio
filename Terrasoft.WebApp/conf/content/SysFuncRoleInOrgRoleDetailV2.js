Terrasoft.configuration.Structures["SysFuncRoleInOrgRoleDetailV2"] = {innerHierarchyStack: ["SysFuncRoleInOrgRoleDetailV2CrtUIv2", "SysFuncRoleInOrgRoleDetailV2"], structureParent: "SysFuncRoleChiefInOrgRoleDetailV2"};
define('SysFuncRoleInOrgRoleDetailV2CrtUIv2Structure', ['SysFuncRoleInOrgRoleDetailV2CrtUIv2Resources'], function(resources) {return {schemaUId:'4b41fa69-199e-4ae2-bd42-be6ba2119746',schemaCaption: "Detail schema - Functional role in the organizational role", parentSchemaName: "SysFuncRoleChiefInOrgRoleDetailV2", packageName: "SSP", schemaName:'SysFuncRoleInOrgRoleDetailV2CrtUIv2',parentSchemaUId:'4fae0f4a-0189-4ce6-8bdc-1e0ce3f02e86',extendParent:false,type:Terrasoft.SchemaType.GRID_DETAIL_VIEW_MODEL_SCHEMA,entitySchema:'',name:'',extend:'Terrasoft.model.BaseViewModel',schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},schemaDifferences:function(){

}};});
define('SysFuncRoleInOrgRoleDetailV2Structure', ['SysFuncRoleInOrgRoleDetailV2Resources'], function(resources) {return {schemaUId:'f1d7f527-6ddd-415d-bdad-da7b60c278d0',schemaCaption: "Detail schema - Functional role in the organizational role", parentSchemaName: "SysFuncRoleInOrgRoleDetailV2CrtUIv2", packageName: "SSP", schemaName:'SysFuncRoleInOrgRoleDetailV2',parentSchemaUId:'4b41fa69-199e-4ae2-bd42-be6ba2119746',extendParent:true,type:Terrasoft.SchemaType.GRID_DETAIL_VIEW_MODEL_SCHEMA,entitySchema:'',name:'',extend:"SysFuncRoleInOrgRoleDetailV2CrtUIv2",schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},schemaDifferences:function(){

}};});
define('SysFuncRoleInOrgRoleDetailV2CrtUIv2Resources', ['terrasoft'], function(Terrasoft) {
var localizableStrings={

};
var parametersLocalizableStrings={};
var localizableImages={

};
return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});
define("SysFuncRoleInOrgRoleDetailV2CrtUIv2", ["terrasoft", "ConfigurationConstants"],
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

define("SysFuncRoleInOrgRoleDetailV2", [],
	function() {
		return {
			entitySchemaName: "SysFuncRoleInOrgRole",
			methods: {

				/**
				 * Returns values of the ViewModel.
				 * @protected
				 * @virtual
				 * @returns {Object} ViewModel column values.
				 */
				getCardColumnValues: function() {
					return this.sandbox.publish("GetColumnsValues", ["ConnectionType"], [this.sandbox.id]);
				},

				/**
				 * Adds filter by connection type column to the existing filter.
				 * @protected
				 * @virtual
				 */
				addConnectionTypeFilter: function(filters) {
					var columnValues = this.getCardColumnValues();
					if (columnValues && columnValues.hasOwnProperty("ConnectionType")) {
						var connectionTypeFilter =  this.Terrasoft.createColumnFilterWithParameter(
							this.Terrasoft.ComparisonType.EQUAL,
							"ConnectionType",
							columnValues.ConnectionType);
						filters.addItem(connectionTypeFilter);
					}
				},

				/**
				 * @inheritdoc Terrasoft.SysFuncRoleChiefInOrgRoleDetailV2#getRoleLookupFilter
				 * @overridden
				 */
				getRoleLookupFilter: function() {
					var filters = this.callParent(arguments);
					if (this.getIsFeatureEnabled("PortalUserManagementV2")) {
						this.addConnectionTypeFilter(filters);
					}
					return filters;
				}
			}
		};
	});


