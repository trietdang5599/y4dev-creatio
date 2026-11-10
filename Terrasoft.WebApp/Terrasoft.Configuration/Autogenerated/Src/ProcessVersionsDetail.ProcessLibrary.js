define("ProcessVersionsDetail", ["ProcessModuleUtilities", "ProcessVersionsDetailResources"],
	function(processModuleUtilities) {
		return {

			/**
			 * Entity schema name.
			 * @type {String}
			 */
			entitySchemaName: "VwProcessLib",

			messages: {

				/**
				 * @message ActiveProcessSchemaVersionChanged
				 * Published when active version of the schema is changed.
				 * @param {Object} Change data object.
				 */
				"ActiveProcessSchemaVersionChanged": {
					mode: this.Terrasoft.MessageMode.BROADCAST,
					direction: this.Terrasoft.MessageDirectionType.PUBLISH
				}
			},
			attributes: {

				/**
				 * Tag for events on the process.
				 */
				ProcessActionTag: {
					dataValueType: Terrasoft.DataValueType.TEXT
				}
			},
			properties: {
				_executionTracePoints: {
					None: 0,
					Startup: 1
				}
			},
			methods: {

				/**
				 * Returns a 'Setup trace points' menu item.
				 * @protected
				 */
				addExecutionTraceOptions: function(toolsButtonMenu) {
					if (Terrasoft.isDebug || this.getIsFeatureEnabled("SetupProcessTracePoints")) {
						toolsButtonMenu.addItem(this.getButtonMenuSeparator());
						toolsButtonMenu.addItem(this.getButtonMenuItem({
							Caption: {"bindTo": "Resources.Strings.SetupTracePoints"},
							Click: {"bindTo": "_setupTracePoints"},
							Enabled: {bindTo: "isSingleSelected"}
						}));
					}
				},

				/**
				 * @private
				 */
				_displayTracePointsSetupDialog: function(currentValue, okBtnCallback, scope) {
					let controls = {
						startup: {
							dataValueType: Terrasoft.DataValueType.BOOLEAN,
							caption: 'Start',
							value: (currentValue & this._executionTracePoints.Startup) ===
								this._executionTracePoints.Startup
						}
					};
					const buttons = [
						Terrasoft.MessageBoxButtons.OK.returnCode,
						Terrasoft.MessageBoxButtons.CANCEL.returnCode
					];
					Terrasoft.showInputBox(this.get("Resources.Strings.SetupTracePoints"),
						function(returnCode, controlState) {
							if (returnCode !== Terrasoft.MessageBoxButtons.OK.returnCode) {
								return;
							}
							const newValue = Number(controlState.startup.value);
							Ext.callback(okBtnCallback, scope, [newValue])
						}, buttons, this, controls)
				},

				/**
				 * @private
				 */
				_parseTracePointsValue: function(stringValue) {
					return stringValue
						.split(',')
						.reduce((accumulator, item) => accumulator + this._executionTracePoints[item], 0);
				},

				/**
				 * @private
				 */
				_getTracePointsValue: function(sysSchemaId, callback, scope) {
					Terrasoft.SysUserPropertyHelper.getProperty({
						schemaId: sysSchemaId,
						propertyName: "ExecutionTracePoints",
						managerName: "ProcessSchemaManager"
					}, function(response) {
						const currentValue = this._parseTracePointsValue(response.value ?? '');
						Ext.callback(callback, scope, [currentValue]);
					}, this);
				},

				/**
				 * @private
				 */
				_setTracePointsValue: function(sysSchemaId, newValue, callback, scope) {
					Terrasoft.SysUserPropertyHelper.setProperty({
						schemaId: sysSchemaId,
						propertyName: "ExecutionTracePoints",
						propertyValue: newValue,
						managerName: "ProcessSchemaManager"
					}, callback, scope);
				},

				/**
				 * @private
				 */
				_setupTracePoints: function(callback, scope) {
					let activeRow = this.getActiveRow();
					let sysSchemaId = activeRow.get("SysSchemaId");
					this._getTracePointsValue(sysSchemaId, function(currentValue) {
						this._displayTracePointsSetupDialog(currentValue, function(newValue) {
							if (currentValue === newValue) {
								Ext.callback(callback, scope);
								return;
							}
							this._setTracePointsValue(sysSchemaId, newValue, function(result) {
								if (!result.success){
									Terrasoft.showInformation(this.get("Resources.Strings.FailedToExecuteOperation"),
										callback, scope);
								} else {
									Ext.callback(callback, scope);
								}
							}, this);
						}, this);
					}, this);
				},

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
				 * @inheritdoc Terrasoft.BaseGridDetailV2#getDeleteRecordMenuItem
				 * @overridden
				 */
				getDeleteRecordMenuItem: Terrasoft.emptyFn,

				/**
				 * @inheritdoc Terrasoft.BaseGridDetailV2#addDetailWizardMenuItems
				 * @overridden
				 */
				addDetailWizardMenuItems: Terrasoft.emptyFn,

				/**
				 * @inheritdoc Terrasoft.BaseGridDetailV2#addRecordOperationsMenuItems
				 * @overridden
				 */
				addRecordOperationsMenuItems: function(toolsButtonMenu) {
					this.callParent(arguments);
					var setActiveVersionMenuItem = this.getButtonMenuItem({
						Caption: {"bindTo": "Resources.Strings.SetActiveVersionMenuCaption"},
						Click: {"bindTo": "setActiveVersion"},
						Enabled: {bindTo: "getSetActiveVersionMenuEnabled"}
					});
					toolsButtonMenu.addItem(setActiveVersionMenuItem);
					var setOpenProcessDesignerMenuItem = this.getButtonMenuItem({
						Caption: {"bindTo": "Resources.Strings.OpenProcessDesignerMenuCaption"},
						Click: {"bindTo": "openProcessDesigner"},
						Enabled: {bindTo: "isSingleSelected"}
					});
					toolsButtonMenu.addItem(setOpenProcessDesignerMenuItem);
					this.addExecutionTraceOptions(toolsButtonMenu);
				},

				/**
				 * @inheritdoc Terrasoft.GridUtilitiesV2#getGridDataColumns
				 * @overridden
				 */
				getGridDataColumns: function() {
					const gridDataColumns = this.callParent(arguments);
					if (!gridDataColumns.SysSchemaId) {
						gridDataColumns.SysSchemaId = {
							path: "SysSchemaId"
						};
					}
					return gridDataColumns;
				},

				/**
				 * @inheritdoc Terrasoft.BaseGridDetailV2#openCard
				 * @overridden
				 */
				openCard: function(operation, typeColumnValue, recordId) {
					this.openProcessDesigner(recordId);
				},

				/**
				 * @inheritdoc Terrasoft.BaseSchemaViewModel#getGoogleTagManagerData.
				 * @overridden
				 */
				getGoogleTagManagerData: function() {
					var data = this.callParent(arguments);
					var processActionTag = this.get("ProcessActionTag");
					if (!this.Ext.isEmpty(processActionTag)) {
						this.Ext.apply(data, {
							action: processActionTag
						});
					}
					return data;
				},

				/**
				 * Gets is SetActiveVersion menu item enabled.
				 * @private
				 * @return {Boolean}
				 */
				getSetActiveVersionMenuEnabled: function() {
					return this.isSingleSelected() && !this.findActiveRow().get("IsActiveVersion");
				},

				/**
				 * Opens process schema in designer.
				 * @param {String} processSchemaUId Unique identifier of the process schema.
				 * @protected
				 */
				openProcessDesigner: function(processSchemaUId) {
					var schemaUId = processSchemaUId || this.get("ActiveRow");
					processModuleUtilities.showProcessSchemaDesigner(schemaUId);
					this.set("ProcessActionTag", "OpenProcess");
					this.sendGoogleTagManagerData();
				},

				/**
				 * Sets actual version of the process.
				 * @protected
				 */
				setActiveVersion: function() {
					this.showBodyMask();
					var newVersionId = this.get("ActiveRow");
					var versionChangeInfo = {
						previousVersionId: this.get("MasterRecordId"),
						activeVersionId: newVersionId
					};
					var callback = function(data, errorMessage) {
						if (errorMessage) {
							this.hideBodyMask();
							this.showInformationDialog(errorMessage);
						} else {
							this.onActiveVersionChanged(versionChangeInfo);
						}
					};
					Terrasoft.ProcessSchemaManager.setIsActualVersionByUId(newVersionId, callback, this);
				},

				/**
				 * Handles modification event of the setting active process version.
				 * @protected
				 * @param {Object} changeData Change data object.
				 */
				onActiveVersionChanged: function(changeData) {
					this.reloadGridData();
					this.hideBodyMask();
					this.sandbox.publish("ActiveProcessSchemaVersionChanged", changeData);
				}
			},

			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "merge",
					"name": "AddRecordButton",
					"values": {
						"visible": false
					}
				}
			]/**SCHEMA_DIFF*/
		};
	}
);
