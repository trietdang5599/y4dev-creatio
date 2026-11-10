define("SysAdminUnitGrantedRightDetailV2", ["ConfigurationConstants"],
	function(ConfigurationConstants) {
		return {
			entitySchemaName: "SysAdminUnitGrantedRight",
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "merge",
					"name": "DataGrid",
					"values": {
						"rowDataItemMarkerColumnName": "GranteeSysAdminUnit"
					}
				},
				{
					"operation": "merge",
					"name": "AddRecordButton",
					"values": {
						"caption": {"bindTo": "Resources.Strings.AddButtonCaption"}
					},
					"index": 0
				},
				{
					"operation": "insert",
					"name": "GetRightsButton",
					"parentName": "Detail",
					"propertyName": "tools",
					"values": {
						"itemType": this.Terrasoft.ViewItemType.BUTTON,
						"click": {"bindTo": "getRights"},
						"visible": {"bindTo": "getAddRecordButtonVisible"},
						"enabled": {"bindTo": "getAddRecordButtonEnabled"},
						"style": this.Terrasoft.controls.ButtonEnums.style.TRANSPARENT,
						"caption": {"bindTo": "Resources.Strings.GetRightsButtonCaption"}
					},
					"index": 1
				},
				{
					"operation": "merge",
					"name": "ToolsButton",
					"index": 2,
					"values": {
					}
				}
			]/**SCHEMA_DIFF*/,
			methods: {

				/**
				 * @inheritdoc Terrasoft.BaseGridDetailV2#onDeleted
				 * @overridden
				 */
				onDeleted: function() {
					this.callParent(arguments);
				},

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
				 * @inheritdoc Terrasoft.BaseGridDetailV2#addDetailWizardMenuItems
				 * @overridden
				 */
				addDetailWizardMenuItems: this.Terrasoft.emptyFn,

				/**
				 * @inheritdoc Terrasoft.BaseGridDetailV2#getSwitchGridModeMenuItem
				 * @overridden
				 */
				getSwitchGridModeMenuItem: this.Terrasoft.emptyFn,

				/**
				 * ######### ########## ######## #################.
				 * @protected
				 * @param {Boolean} isDelegate ####, ########### ########### ############# ####. #### true, ## #######
				 * ############ ########## ##### ########## ######### ## ###########. #### false, ## ########
				 * ############ ############ ##### ## ########## #########.
				 */
				openUsersLookup: function(isDelegate) {
					var config = this.prepareLookupConfig(isDelegate);
					this.openLookup(config, this.addCallback.bind(this, isDelegate), this);
				},

				/**
				 * ######## onInsertSysAdminUnitGrantedRightComplete.
				 * @virtual
				 * @param {Boolean} isDelegate ####, ########### ########### ############# ####. #### true, ## #######
				 * ############ ########## ##### ########## ######### ## ###########. #### false, ## ########
				 * ############ ############ ##### ## ########## #########.
				 * @param {Object} args ######, ########## ######### ######### #######.
				 */
				addCallback: function(isDelegate, args) {
					this.onInsertSysAdminUnitGrantedRight(isDelegate, args, this.get("MasterRecordId"));
				},

				/**
				 * Callback-#######, ####### ########## ##### ########## ############.
				 * @protected
				 * @param {Boolean} isDelegate ####, ########### ########### ############# ####. #### true, ## #######
				 * ############ ########## ##### ########## ######### ## ###########. #### false, ## ########
				 * ############ ############ ##### ## ########## #########.
				 * @param {Object} args ######, ########## ######### ######### #######.
				 */
				onInsertSysAdminUnitGrantedRight: function(isDelegate, args) {
					var selectedIds = args.selectedRows.getKeys();
					var dataSend = {
						masterRecordId: this.get("MasterRecordId"),
						selectedRecords: this.Ext.JSON.encode(selectedIds)
					};
					var config = {
						serviceName: "AdministrationService",
						methodName: isDelegate
							? "AddSysAdminUnitGrantedRights"
							: "AddSysAdminUnitGrantedRightsFromSelectedRecords",
						data: dataSend
					};
					this.callService(config, function(response) {
						const errorMessage = Ext.isEmpty(response) ? "" : response[config.methodName + "Result"];
						if (!Ext.isEmpty(errorMessage)) {
							this.showInformationDialog(errorMessage);
							return;
						}
						this.onInsertCompleted();
					});
				},

				/**
				 * ######### #######, ###### ######### ########## ############ ####### # ######.
				 * @private
				 * @param {Boolean} isDelegate ####, ########### ########### ############# ####. #### true, ## #######
				 * ############ ########## ##### ########## ######### ## ###########. #### false, ## ########
				 * ############ ############ ##### ## ########## #########.
				 * @return {Terrasoft.FilterGroup} ########## ###### ########.
				 */
				getLookupFilter: function(isDelegate) {
					var filters = this.Terrasoft.createFilterGroup();
					var parentFilter =  this.Terrasoft.createColumnFilterWithParameter(
						this.Terrasoft.ComparisonType.EQUAL,
						isDelegate ? "GrantorSysAdminUnit.Id" : "GranteeSysAdminUnit.Id",
						this.get("MasterRecordId"));
					var sameIdFilter = this.Terrasoft.createColumnFilterWithParameter(
						this.Terrasoft.ComparisonType.NOT_EQUAL,
						"Id",
						this.get("MasterRecordId"));
					var excludeTechnicalUsersFilter = this.Terrasoft.createColumnFilterWithParameter(
						this.Terrasoft.ComparisonType.NOT_EQUAL,
						"SysAdminUnitTypeValue",
						ConfigurationConstants.SysAdminUnit.Type.TechnicalUser);
					var notExistsFilter = this.Terrasoft.createNotExistsFilter(
						this.Ext.String.format("[SysAdminUnitGrantedRight:{0}:Id].Id", isDelegate
							? "GranteeSysAdminUnit"
							: "GrantorSysAdminUnit"));
					notExistsFilter.subFilters.addItem(parentFilter);
					filters.addItem(notExistsFilter);
					filters.addItem(sameIdFilter);
                    filters.addItem(excludeTechnicalUsersFilter);
					return filters;
				},

				/**
				 * ########## ########## ### ######## #### ###### ## #############.
				 * @return {Object} Config ######## #### ###### ## ###########.
				 */
				prepareLookupConfig: function() {
					var filters = this.getLookupFilter();
					var config = {
						entitySchemaName: "SysAdminUnit",
						multiSelect: true,
						columns: ["Contact", "Name"],
						hideActions: true,
						filters: filters
					};
					return config;
				},

				/**
				 * ########## ####### ## ###### ############ #####.
				 * @inheritdoc BaseGridDetailV2#addRecord
				 * @overridden
				 */
				addRecord: function() {
					this.openUsersLookup(true);
				},

				/**
				 * ########## ####### ## ###### ######## #####.
				 * @protected
				 */
				getRights: function() {
					this.openUsersLookup(false);
				},

				/**
				 * @inheritdoc BaseGridDetailV2#getAddRecordButtonVisible
				 * @overridden
				 */
				getAddRecordButtonVisible: function() {
					return true;
				},

				/**
				 * ######## ########### ############# # ######.
				 * @private
				 */
				onInsertCompleted: function() {
					this.hideBodyMask();
					this.reloadGridData();
				},

                /**
                 * @overridden
                 * @return {String} ### #######.
                 */
                getFilterDefaultColumnName: function() {
                    return "GranteeSysAdminUnit";
                }
			}
		};
	});
