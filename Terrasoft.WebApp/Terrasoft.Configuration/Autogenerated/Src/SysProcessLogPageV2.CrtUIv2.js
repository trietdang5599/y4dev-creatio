/**
 * Parent: BasePageV2
 */
define("SysProcessLogPageV2", [
	"ProcessModule",
	"ConfigurationConstants",
	"ProcessLogActions",
	"ProcessModuleUtilities",
	"css!SysProcessLogPageV2CSS"
], function(ProcessModule, ConfigurationConstants) {
	return {
		entitySchemaName: "VwSysProcessLog",
		attributes: {
			/**
			 * Operation name, which user should have to access to current screen.
			 */
			SecurityOperationName: {
				dataValueType: Terrasoft.DataValueType.STRING,
				value: "CanManageProcessLogSection"
			},
			"SysSchema.ManagerName": {
				"columnPath": "SysSchema.ManagerName",
				"dataValueType": this.Terrasoft.DataValueType.TEXT,
				"type": this.Terrasoft.ViewModelColumnType.ENTITY_COLUMN
			}
		},
		messages: {
			"ExecutionCanceled": {
				mode: Terrasoft.MessageMode.PTP,
				direction: Terrasoft.MessageDirectionType.PUBLISH
			},
			/**
			 * Returns Process status property.
			 */
				"GetProcessStatus": {
				mode: Terrasoft.MessageMode.PTP,
				direction: Terrasoft.MessageDirectionType.SUBSCRIBE
			},
			"NavigateTo": {
				mode: Terrasoft.MessageMode.BROADCAST,
				direction: Terrasoft.MessageDirectionType.PUBLISH
			}
		},
		details: /**SCHEMA_DETAILS*/{
			ProcessElementLog: {
				schemaName: "SysProcessElementLogDetailV2",
				filter: {
					detailColumn: "SysProcess"
				},
				subscriber: {
					methodName: "reloadEntity"
				}
			},
			ProcessEntity: {
				schemaName: "SysProcessEntityDetailV2",
				filter: {
					detailColumn: "SysProcess"
				},
				filterMethod: "entityDetailFilter"
			}
		}/**SCHEMA_DETAILS*/,
		methods: {

			/**
			 * @inheritdoc BasePageV2#initCardActionHandler
			 * @override
			 */
			initCardActionHandler: function() {
				this.callParent(arguments);
				this.on("change:Status", function(model, value) {
					this.sandbox.publish("CardChanged", {
						key: "Status",
						value: value
					}, [this.sandbox.id]);
				}, this);
			},

			/**
			 * @inheritdoc BasePageV2#getActions
			 * @override
			 */
			getActions: function() {
				const actionMenuItems = this.callParent(arguments);
				actionMenuItems.addItem(this.getButtonMenuItem({
					Type: "Terrasoft.MenuSeparator"
				}));
				actionMenuItems.addItem(this.getButtonMenuItem({
					Caption: {
						"bindTo": "Resources.Strings.CancelExecutionButtonCaption"
					},
					Tag: "cancelExecutionConfirmation",
					Visible: {
						"bindTo": "getIsVisibleCancelExecutionMenuItem"
					}
				}));
				actionMenuItems.addItem(this.getButtonMenuItem({
					Caption: {
						"bindTo": "Resources.Strings.ProcessDiagramButtonCaption"
					},
					Tag: "processDiagram"
				}));
				actionMenuItems.addItem(this.getButtonMenuItem({
					Caption: {
						"bindTo": "Resources.Strings.OpenParentProcessButtonCaption"
					},
					Tag: "_openParentPage",
					Visible: {
						"bindTo": "_getIsVisibleOpenParentMenuItem"
					}
				}));
				return actionMenuItems;
			},

			/**
			 * Returns true if cancel execution menu item is visible.
			 * @protected
			 * @result {Boolean} True when menu item is visible.
			 */
			getIsVisibleCancelExecutionMenuItem: function() {
				const parent = this.get("Parent");
				if (parent) {
					return false;
				}
				const status = this.get("Status");
				const enumStatus = ConfigurationConstants.SysProcess.Status;
				const currentStatus = status && status.value;
				return (currentStatus === enumStatus.Running || currentStatus === enumStatus.Error);
			},

			/**
			 * Display Cancel process execution dialog.
			 */
			cancelExecutionConfirmation: function() {
				this.showConfirmationDialog(this.get("Resources.Strings.CancelExecutionConfirmation"),
					this.onCancelExecution, ["yes", "no"]);
			},

			_canUpdateStatus: function(currentStatus, enumStatus) {
				return !currentStatus || currentStatus.value !== enumStatus.Canceled.value;
			},

			/**
			 * Handler for cancelling execution of the user dialog result.
			 * @protected
			 * @result {String} User dialog result.
			 */
			onCancelExecution: function(result) {
				if (result !== "yes") {
					return;
				}
				const selectedItemId = this.get(this.primaryColumnName);
				const data = {
					processDataIds: selectedItemId
				};
				const maskId = Terrasoft.Mask.show();
				ProcessModule.services.cancelExecution(this, data, function() {
					this.loadEntity(selectedItemId, function() {
						this.sandbox.publish("ExecutionCanceled", selectedItemId);
						this.updateDetails();
						const status = ConfigurationConstants.SysProcess.Status2;
						const currentStatus = this.get("Status");
						if (this._canUpdateStatus(currentStatus, status)) {
							this.set("Status", status.Cancelling);
						}
						Terrasoft.Mask.hide(maskId);
					}, this);
				});
			},

			/**
			 * Open process run diagram.
			 */
			processDiagram: function() {
				const schemaUId = this.get(this.primaryColumnName);
				const managerName = this.get("SysSchema.ManagerName");
				if (managerName === "DcmSchemaManager") {
					Terrasoft.ProcessModuleUtilities.showDcmDiagram(schemaUId);
				} else {
					Terrasoft.ProcessModuleUtilities.showProcessDiagram(schemaUId);
				}
			},

			/**
			 * @private
			 */
			_openParentPage: function () {
				this.sandbox.publish("NavigateTo", {
					target: "Page",
					options: {
						silent: false,
						replaceState: false,
						sectionSchema: "SysProcessLogSectionV2",
						mode: "edit",
						recordId: this.$Parent.value
					}
				});
			},

			/**
			 * @private
			 */
			_getIsVisibleOpenParentMenuItem: function () {
				return Boolean(this.$Parent && this.$Parent.value);
			},

			/**
			 * @inheritdoc BasePageV2#updateButtonsVisibility
			 * @override
			 */
			updateButtonsVisibility: function() {
				this.set("ShowDiscardButton", false);
				this.set("ShowSaveButton", false);
			},

			/**
			 * Create detail related filters.
			 * @private
			 */
			entityDetailFilter: function() {
				const filterGroup = Terrasoft.createFilterGroup();
				filterGroup.add("ProcessFilter", Terrasoft.createColumnFilterWithParameter(
					Terrasoft.ComparisonType.EQUAL, "SysProcess", this.get("Id")));
				filterGroup.add("WorkspaceFilter", Terrasoft.createColumnFilterWithParameter(
					Terrasoft.ComparisonType.EQUAL, "SysWorkspace",
					Terrasoft.SysValue.CURRENT_WORKSPACE.value));
				return filterGroup;
			},

			/**
			 * Get process status.
			 * @private
			 */
			onGetProcessStatus: function() {
				return this.get("Status");
			},

			/**
			 * @inheritdoc BasePageV2#init
			 * @override
			 */
			init: function() {
				this.sandbox.subscribe("GetProcessStatus", this.onGetProcessStatus, this);
				this.callParent(arguments);
			},

			/**
			 * @inheritdoc BasePageV2#addSectionDesignerViewOptions
			 * @override
			 */
			addSectionDesignerViewOptions: Terrasoft.emptyFn,

			/**
			 * @inheritdoc Terrasoft.BaseSchemaViewModel#getSectionCode
			 * @override
			 */
			getSectionCode: function() {
				return "SysProcessLog";
			},

			/**
			 * Shows process schema designer by Id.
			 */
			showProcessDesigner: function() {
				const sysSchema = this.get("SysSchema");
				const id = sysSchema && sysSchema.value;
				Terrasoft.ProcessModuleUtilities.showProcessSchemaDesignerById(id);
			},

			/**
			 * @private
			 */
			_showErrorDescription: function() {
				Terrasoft.ProcessLogActions.tryShowErrorDescription(this.sandbox, this.$ErrorDescription);
			}

		},
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "insert",
				"parentName": "LeftContainer",
				"propertyName": "items",
				"name": "ShowProcessDesignerButton",
				"values": {
					"itemType": Terrasoft.ViewItemType.BUTTON,
					"caption": {"bindTo": "Resources.Strings.ProcessDesignerButton"},
					"click": {"bindTo": "showProcessDesigner"}
				}
			},
			{
				"operation": "insert",
				"name": "GeneralInfoTab",
				"parentName": "Tabs",
				"propertyName": "tabs",
				"values": {
					"caption": {"bindTo": "Resources.Strings.GeneralInfoTabCaption"},
					"items": []
				}
			},
			{
				"operation": "insert",
				"parentName": "GeneralInfoTab",
				"name": "GeneralInfoControlGroup",
				"propertyName": "items",
				"values": {
					"itemType": Terrasoft.ViewItemType.CONTROL_GROUP,
					"items": [],
					"controlConfig": {"collapsed": false}
				}
			},
			{
				"operation": "insert",
				"parentName": "GeneralInfoControlGroup",
				"propertyName": "items",
				"name": "GeneralInfoBlock",
				"values": {
					"itemType": Terrasoft.ViewItemType.GRID_LAYOUT,
					"items": []
				}
			},
			{
				"operation": "insert",
				"parentName": "GeneralInfoBlock",
				"propertyName": "items",
				"name": "Name",
				"values": {
					"bindTo": "Name",
					"layout": {"column": 0, "row": 0, "colSpan": 24},
					"controlConfig": {"enabled": false}
				}
			},
			{
				"operation": "insert",
				"parentName": "GeneralInfoBlock",
				"propertyName": "items",
				"name": "Status",
				"values": {
					"bindTo": "Status",
					"layout": {"column": 0, "row": 1, "colSpan": 6},
					"controlConfig": {"enabled": false}
				}
			},
			{
			"operation": "insert",
			"parentName": "GeneralInfoBlock",
			"propertyName": "items",
			"name": "ShowErrorDescriptionButtonWrapper",
			"values": {
				"itemType": Terrasoft.ViewItemType.CONTAINER,
				"items": [],
				"layout": {"column": 6, "row": 1, "colSpan": 6},
				"wrapClass": ["wrapper-show-error-button"]
				}
			},
			{
				"operation": "insert",
				"parentName": "ShowErrorDescriptionButtonWrapper",
				"propertyName": "items",
				"name": "ShowErrorDescriptionButton",
				"values": {
					"itemType": Terrasoft.ViewItemType.BUTTON,
					"caption": {"bindTo": "Resources.Strings.ShowErrorDescriptionButtonCaption"},
					"visible": {
						"bindTo": "ErrorDescription",
						"bindConfig": {converter: "toBoolean"}
						},
					"click": {"bindTo": "_showErrorDescription"},
					"controlConfig": {
						"style": Terrasoft.controls.ButtonEnums.style.RED
					}
				}
			},
			{
				"operation": "insert",
				"parentName": "GeneralInfoBlock",
				"propertyName": "items",
				"name": "Owner",
				"values": {
					"bindTo": "Owner",
					"layout": {"column": 12, "row": 1, "colSpan": 12},
					"controlConfig": {"enabled": false}
				}
			},
			{
				"operation": "insert",
				"parentName": "GeneralInfoBlock",
				"propertyName": "items",
				"name": "StartDate",
				"values": {
					"bindTo": "StartDate",
					"layout": {"column": 0, "row": 2, "colSpan": 12},
					"controlConfig": {"enabled": false}
				}
			},
			{
				"operation": "insert",
				"parentName": "GeneralInfoBlock",
				"propertyName": "items",
				"name": "CompleteDate",
				"values": {
					"bindTo": "CompleteDate",
					"layout": {"column": 12, "row": 2, "colSpan": 12},
					"controlConfig": {"enabled": false}
				}
			},
			{
				"operation": "insert",
				"parentName": "GeneralInfoBlock",
				"propertyName": "items",
				"name": "HasTrace",
				"values": {
					"bindTo": "HasTraceData",
					"layout": {"column": 0, "row": 3, "colSpan": 12},
					"enabled": false
				}
			},
			{
				"operation": "insert",
				"parentName": "GeneralInfoTab",
				"propertyName": "items",
				"name": "ProcessElementLog",
				"values": {
					"itemType": Terrasoft.ViewItemType.DETAIL
				}
			},
			{
				"operation": "insert",
				"parentName": "GeneralInfoTab",
				"propertyName": "items",
				"name": "ProcessEntity",
				"values": {
					"itemType": Terrasoft.ViewItemType.DETAIL
				}
			}
		]/**SCHEMA_DIFF*/
	};
});
