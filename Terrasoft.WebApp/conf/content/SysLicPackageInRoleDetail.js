Terrasoft.configuration.Structures["SysLicPackageInRoleDetail"] = {innerHierarchyStack: ["SysLicPackageInRoleDetail"], structureParent: "BaseGridDetailV2"};
define('SysLicPackageInRoleDetailStructure', ['SysLicPackageInRoleDetailResources'], function(resources) {return {schemaUId:'c3591cd6-fb5e-465a-963f-93e5fc366cd4',schemaCaption: "SysLicPackageInRoleDetail", parentSchemaName: "BaseGridDetailV2", packageName: "CrtUIv2", schemaName:'SysLicPackageInRoleDetail',parentSchemaUId:'01eb38ee-668a-42f0-999d-c2534f979089',extendParent:false,type:Terrasoft.SchemaType.GRID_DETAIL_VIEW_MODEL_SCHEMA,entitySchema:'',name:'',extend:'Terrasoft.model.BaseViewModel',schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},schemaDifferences:function(){

}};});
define("SysLicPackageInRoleDetail", ["terrasoft", "ConfigurationEnums", "ProcessModuleUtilities", "ConfigurationConstants"],
	function(Terrasoft, enums, ProcessModuleUtilities, ConfigurationConstants) {
		return {
			entitySchemaName: "SysLicPackageInRole",
			methods: {
				/**
				 * @inheritdoc Terrasoft.BaseGridDetailV2#getCopyRecordMenuItem
				 * @overridden
				 */
				getCopyRecordMenuItem: Terrasoft.emptyFn,
				
				/**
				 * @inheritdoc Terrasoft.BaseGridDetailV2#getEditRecordMenuItem
				 * @overridden
				 */
				getEditRecordMenuItem: Terrasoft.emptyFn,
				
				/**
				 * @inheritdoc Terrasoft.BaseGridDetailV2#getAddRecordButtonVisible
				 * @overridden
				 */
				getAddRecordButtonVisible: function() {
					return true;
				},
				
				/**
				 * @inheritdoc Terrasoft.BaseGridDetailV2#getAddRecordButtonEnabled
				 * @overridden
				 */
				getAddRecordButtonEnabled: function() {
					return true;
				},
				
				/**
				 * @inheritdoc Terrasoft.BaseGridDetailV2#addDetailWizardMenuItems
				 * @overridden
				 */
				addDetailWizardMenuItems: this.Terrasoft.emptyFn,
				
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

				/**
				 * Handles lookup page selection.
				 * @protected
				 * @param {Object} args Function arguments.
				 */		
				addCallback: function(args) {
					var bq = this.Ext.create("Terrasoft.BatchQuery");
					var sysRoleId = this.get("MasterRecordId");
					this.selectedRows = args.selectedRows.getItems();
					this.selectedItems = [];
					this.selectedRows.forEach(function(item) {
						item.SysRoleId = sysRoleId;
						item.SysLicPackageId = item.value;
						bq.add(this.getItemInsertQuery(item));
						this.selectedItems.push(item.value);
					}, this);
					if (bq.queries.length) {
						this.showBodyMask.call(this);
						bq.execute(this.onItemInsert, this);
					}
				},

				/**
				 * Returns lookupPage config.
				 * @private
				 * @return {Object} config for lookupPage.
				 */
				getLookupPageConfig: function() {
					var filters = this.Terrasoft.createFilterGroup();
					filters.addItem(this.getRoleLookupFilter());
					var config = {
						entitySchemaName: "SysLicPackage",
						multiSelect: true,
						columns: ["Name"],
						filters: filters,
						hideActions: true
					};
					return config;
				},

				/**
				 * @private
				 */
				getRoleLookupFilter: function() {
					var filters = this.Terrasoft.createFilterGroup();
					var notExistsFilter = this.Terrasoft.createNotExistsFilter(
						"[SysLicPackageInRole:SysLicPackage:Id].Id");
					var subFilter = this.Terrasoft.createColumnFilterWithParameter(
						this.Terrasoft.ComparisonType.EQUAL,
						"SysRole",
						this.get("MasterRecordId"));
					notExistsFilter.subFilters.addItem(subFilter);
					filters.addItem(notExistsFilter);
					var licTypeFilter = this.Terrasoft.createColumnFilterWithParameter(
						this.Terrasoft.ComparisonType.EQUAL, "[SysLic:SysLicPackage:Id].LicType", 0);
					filters.addItem(licTypeFilter);
					var operationsFilter = this.Terrasoft.createColumnFilterWithParameter(
						this.Terrasoft.ComparisonType.NOT_CONTAIN, "Operations", "IsServerLicPackage");
					filters.addItem(operationsFilter);
					return filters;
				},
				
				/**
				 * @private
				 */
				getItemInsertQuery: function(item) {
					var insert = Ext.create("Terrasoft.InsertQuery", {
						rootSchemaName: this.entitySchemaName
					});
					insert.setParameterValue("SysRole", item.SysRoleId, this.Terrasoft.DataValueType.GUID);
					insert.setParameterValue("SysLicPackage", item.SysLicPackageId, this.Terrasoft.DataValueType.GUID);
					return insert;
				},

				/**
				 * @private
				 */
				onItemInsert: function(response) {
					this.hideBodyMask.call(this);
					this.beforeLoadGridData();
					var filterCollection = [];
					response.queryResults.forEach(function(item) {
						filterCollection.push(item.id);
					});
					var esq = Ext.create("Terrasoft.EntitySchemaQuery", {
						rootSchemaName: this.entitySchemaName
					});
					this.initQueryColumns(esq);
					esq.filters.add("recordId", Terrasoft.createColumnInFilterWithParameters("Id", filterCollection));
					esq.getEntityCollection(function(response) {
						this.afterLoadGridData();
						if (response.success) {
							var responseCollection = response.collection;
							this.prepareResponseCollection(responseCollection);
							this.getGridData().loadAll(responseCollection);
							this.runRedistribution();
						}
					}, this);
				},

				/**
				* @inheritdoc
				* @overridden
				*/
				onDeleted: function(result) {
					if (result.Success) {
						this.runRedistribution();
					}
				},

				/**
				 * @private
				 */
				runRedistribution: function() {
					Terrasoft.SysSettings.querySysSettings("RedistributeLicensesOnRoleChanges", function(sysSetting) {
						if (sysSetting.RedistributeLicensesOnRoleChanges) {
							this.runRedistributeLicensesProcess();
						}
					}, this);
				},

				/**
				 * @private
				 */
				runRedistributeLicensesProcess: function() {
					var processToBeExecuted = {
						sysProcessName: "ScheduleLicensesRedistribution",
						parameters: {
							RedistributeManuallyAssignedLicences: false,
							RedistributeLicencesForSpecificRole: true,
							RoleId: this.get("MasterRecordId")
						}
					};
					ProcessModuleUtilities.executeProcess(processToBeExecuted);
				},
			}
		};
	}
);


