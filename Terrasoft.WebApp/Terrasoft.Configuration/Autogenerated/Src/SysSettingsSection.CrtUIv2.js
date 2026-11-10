define("SysSettingsSection", ["ConfigurationEnums"], function(ConfigurationEnums) {

	return {
		entitySchemaName: "VwSysSetting",
		messages: {
			"GetModuleSchema": {
				mode: Terrasoft.MessageMode.PTP,
				direction: Terrasoft.MessageDirectionType.SUBSCRIBE
			}
		},
		attributes: {
			/**
			 * ######## ######## ###### ## ####### ###### #### # ############ ### ############# ######
			 */
			SecurityOperationName: {
				dataValueType: Terrasoft.DataValueType.STRING,
				value: "CanManageSysSettings"
			},

			/**
			 * ########## ############# ########### #######.
			 */
			ContextHelpId: {
				dataValueType: Terrasoft.DataValueType.STRING,
				value: "269"
			}
		},
		methods: {

			/**
			 * @inheritdoc Terrasoft.BaseSectionV2#init
			 * @overridden
			 */
			init: function() {
				this.callParent(arguments);
				this.set("UseStaticFolders", true);
			},

			/**
			 * @inheritdoc Terrasoft.BaseSchemaViewModel#getEntityStructure
			 * @protected
			 * @overridden
			 */
			getEntityStructure: function() {
				return {
					"pages": [{
						"cardSchema": "SysSettingPage",
						"caption": this.get("Resources.Strings.AddButtonCaption")
					}]
				};
			},

			/**
			 * ######### ########## ######## #### ### ###### ######### #######.
			 * @inheritdoc Terrasoft.BaseSchemaViewModel#addSectionDesignerViewOptions
			 * @protected
			 * @overridden
			 */
			addSectionDesignerViewOptions: Terrasoft.emptyFn,

			/**
			 * ########## ###### ## ####### ######### ####### # ######.
			 * @protected
			 * @overridden
			 * @param {String[]} folders ###### ########## ############### #####.
			 * @param {String[]} records ###### ########## ############### #######.
			 * @return {Terrasoft.EntitySchemaQuery} ###### ## ####### ######### ####### # ######.
			 */
			createRecordsInFoldersSelectQuery: function(folders, records) {
				var select = this.Ext.create("Terrasoft.EntitySchemaQuery", {
					rootSchemaName: this.getInFolderEntityName()
				});
				var folderId = select.addColumn(this.folderColumnName, "Folder");
				var recordId = select.addColumn("[VwSysSetting:Id:SysSettings].Id", "Entity");
				select.filters.add("recordsFilter", Terrasoft.createColumnInFilterWithParameters(
					recordId.columnPath, records));
				select.filters.add("foldersFilter", Terrasoft.createColumnInFilterWithParameters(
					folderId.columnPath, folders));
				return select;
			},

			/**
			 * ########## ######## #### ######## ####### # ######## ######## ####### # ########.
			 * @protected
			 * @overridden
			 * @return {String} ######## #######.
			 */
			getEntityColumnNameInFolderEntity: function() {
				return "SysSettings";
			},

			/**
			 * ########## ### ##### #### ### ####### ########.
			 * @protected
			 * @overridden
			 * @return {String} ### ##### ####.
			 */
			getFolderEntityName: function() {
				return "SysSettingsFolder";
			},

			/**
			 * ########## ### ##### ######## ########### #### ### ####### ########.
			 * @protected
			 * @overridden
			 * @return {String} ### ##### ######## ########### ####.
			 */
			getInFolderEntityName: function() {
				return "SysSettingsInFolder";
			},

			/**
			 * ######### ######## ### ############# ########.
			 * @protected
			 * @overridden
			 */
			onDeleteAccept: function() {
				this.showBodyMask();
				var selectedItems = this.getSelectedItems();
				var request = Ext.create("Terrasoft.DeleteSysSettingRequest", {primaryColumnValues: selectedItems});
				request.execute(function(response) {
					this.hideBodyMask();
					if (response && response.success) {
						this.removeGridRecords(selectedItems);
					} else {
						this.showInformationDialog(response.errorInfo.message);
					}
					this.hideBodyMask();
					this.onDeleted(response);
				}, this);
			},

			/**
			 * @inheritodoc BaseSectionV2#getDefaultDataViews
			 * @protected
			 * @overridden
			 */
			getDefaultDataViews: function() {
				var dataViews = this.callParent(arguments);
				delete dataViews.AnalyticsDataView;
				return dataViews;
			},

			/**
			 * @inheritdoc Terrasoft.BaseSchemaViewModel#getSectionCode
			 * @override
			 */
			getSectionCode: function() {
				return "SysSettings";
			}
		},

		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "merge",
				"name": "CombinedModeActionsButton",
				"values": {
					"visible": false
				}
			}
		]/**SCHEMA_DIFF*/
	};
});
