Terrasoft.configuration.Structures["ProcessLogActions"] = {innerHierarchyStack: ["ProcessLogActions"]};
define("ProcessLogActions", ["RightUtilities", "ProcessModuleUtilities", "ConfigurationConstants", "ProcessModule",
		"ProcessLogActionsResources"],
	function(RightUtilities, ProcessModuleUtilities, ConfigurationConstants, ProcessModule, resources) {
		/**
		 * Terrasoft.configuration.mixins.ProcessLogActions
		 */
		Ext.define("Terrasoft.configuration.mixins.ProcessLogActions", {
			alternateClassName: "Terrasoft.ProcessLogActions",
			statics: {

				/**
				 * Shows error description in modal page if description is not empty.
				 * @param sandbox {Object} Sandbox.
				 * @param errorDescription {String} Error description to show.
				 */
				tryShowErrorDescription: function(sandbox, errorDescription) {
					if (!errorDescription) {
						return;
					}
					sandbox.loadModule("ModalBoxSchemaModule", {
						id: sandbox.id + "_ProcessErrorDataModalBox",
						instanceConfig: {
							moduleInfo: {
								schemaName: "SimpleSourceCodeEditPage",
								content: errorDescription
							},
							initialSize: {width: "80%", height: 800}
						}
					});
				}
			},

			/**
			 * @private
			 */
			_canUserCancelProcess: false,

			// region Methods: Private

			/**
			 * @private
			 */
			_cancelExecutionByIds: function(items) {
				const maskId = Terrasoft.Mask.show();
				const responseCallback = this._cancelResponseCallback.bind(this, items, maskId);
				const processDataIds = items.join(";");
				ProcessModule.services.cancelExecution(this, {
					processDataIds: processDataIds
				}, responseCallback);
			},

			/**
			 * @private
			 */
			_cancelResponseCallback: function(items, maskId) {
				items.forEach(function(item) {
					if (Terrasoft.Features.getIsEnabled("UseBackgroundProcessMode")) {
						this._setCanceledProcessStatus(item);
					} else {
						this.reloadCanceledProcessGridData(item);
					}
				}, this);
				const hasCanceledItems = this.get("MultiSelect") && !Ext.isEmpty(items);
				this.set("HasCanceledItems", hasCanceledItems);
				Terrasoft.Mask.hide(maskId);
			},

			/**
			 * @private
			 */
			_addCommonEsqFilters: function(esq) {
				esq.filters.add("NotParent", Terrasoft.createColumnIsNullFilter("Parent"));
				const statusEnum = ConfigurationConstants.SysProcess.Status;
				const allowStatuses = [statusEnum.Running, statusEnum.Error];
				esq.filters.add("Status", Terrasoft.createColumnInFilterWithParameters("Status", allowStatuses,
					Terrasoft.DataValueType.GUID));
			},

			/**
			 * @private
			 */
			_getCancelEsq: function() {
				const entitySchema = this.getGridEntitySchema();
				const esq = new Terrasoft.EntitySchemaQuery(entitySchema.name);
				esq.addColumn(entitySchema.primaryColumnName);
				this.initQueryFilters(esq);
				const unselectedItems = this.getUnselectedItems();
				if (unselectedItems.length) {
					const unselectedFilter = Terrasoft.createColumnInFilterWithParameters("Id", unselectedItems);
					unselectedFilter.comparisonType = Terrasoft.ComparisonType.NOT_EQUAL;
					esq.filters.add("UnselectedItems", unselectedFilter);
				}
				this._addCommonEsqFilters(esq);
				return esq;
			},

			/**
			 * @private
			 */
			_getCurrentGridSortingColumns: function() {
				const currentGridDataEsq = this.getGridDataInitializedEsq();
				return currentGridDataEsq.columns.getItems().filter(function(column) {
					return column.orderPosition > -1;
				}).map(function(column) {
					return {
						path: column.columnPath,
						direction: column.orderDirection,
						position: column.orderPosition
					};
				});
			},

			/**
			 * @private
			 */
			_getCancellationProcessSettings: function(callback, scope) {
				const settingNames = ["CancellationProcessName", "CancellationProcessChunkSize"];
				Terrasoft.SysSettings.querySysSettings(settingNames, function(value) {
					Ext.callback(callback, scope, [
						value && value["CancellationProcessName"]
							? value["CancellationProcessName"]
							: "MarkProcessesToCancel",
						value && value["CancellationProcessChunkSize"]
							? value["CancellationProcessChunkSize"]
							: 1000
					]);
				});
			},

			/**
			 * @private
			 */
			_runCancellationProcess: function(esq) {
				const sortingColumns = this._getCurrentGridSortingColumns();
				Terrasoft.MaskHelper.showBodyMask();
				this._getCancellationProcessSettings(function(schemaName, chunkSize) {
					const options = {
						schemaName: schemaName,
						parameterValues: {
							"SerializedFilters": esq.filters.serialize(),
							"SerializedSortingColumns": JSON.stringify(sortingColumns),
							"ChunkSize": chunkSize
						}
					};
					Terrasoft.ProcessEngineUtilities.runProcess(options, function() {
						Terrasoft.MaskHelper.hideBodyMask();
					}, this);
				}, this);
			},

			/**
			 * @private
			 */
			_backgroundCancelAllSelected: function() {
				const esq = this._getCancelEsq();
				this._runCancellationProcess(esq);
			},

			/**
			 * @private
			 */
			_backgroundCancelSelected: function() {
				this._getAllowedToCancelItems(function(items) {
					const entitySchema = this.getGridEntitySchema();
					const esq = Ext.create("Terrasoft.EntitySchemaQuery", {
						rootSchema: entitySchema.name
					});
					const selectedFilter = Terrasoft.createColumnInFilterWithParameters("Id", items);
					selectedFilter.comparisonType = Terrasoft.ComparisonType.EQUAL;
					esq.filters.add("SelectedItems", selectedFilter);
					this._runCancellationProcess(esq);
				}, this);
			},

			/**
			 * @private
			 */
			_cancelAllSelected: function() {
				const esq = this._getCancelEsq();
				esq.execute(function(response) {
					const items = response.collection.getItems().map(function(item) {
						return item.get("Id");
					}, this);
					this._cancelExecutionByIds(items);
				}, this);
			},

			/**
			 * @private
			 */
			_getAllowedToCancelItems: function(callback, scope) {
				const selectedItems = this.getSelectedItems();
				const runningItems = this._getRunningItems(selectedItems);
				if (runningItems.length  === 0) {
					Terrasoft.showMessage(resources.localizableStrings.ProcessesCancelDeclineMessage);
					return;
				}
				const items = this._getRootItems(runningItems);
				if (items.length === 0) {
					const message = selectedItems.length === 1
						? resources.localizableStrings.SubProcessCancelDeclineMessage
						: resources.localizableStrings.SubProcessesCancelDeclineMessage;
					Terrasoft.showMessage(message);
				} else {
					Ext.callback(callback, scope, [items]);
				}
			},
			
			/**
			 * @private
			 */
			_cancelSelected: function() {
				this._getAllowedToCancelItems(this._cancelExecutionByIds, this);
			},

			/**
			 * @private
			 */
			_getRunningItems: function(items) {
				const statusEnum = ConfigurationConstants.SysProcess.Status;
				const allowStatuses = [statusEnum.Running, statusEnum.Error, statusEnum.Cancelling];
				const gridData = this.getGridData();
				return _.filter(items, function(id) {
					const row = gridData.get(id);
					const status = row.get("Status");
					return row && Terrasoft.contains(allowStatuses, status && status.value);
				}, this);
			},

			/**
			 * @private
			 */
			_getRootItems: function(items) {
				const gridData = this.getGridData();
				return _.filter(items, function(id) {
					const row = gridData.get(id);
					const parent = row.get("Parent");
					return row && !parent;
				}, this);
			},

			/**
			 * @private
			 */
			_canCancelProcessExecution: function(item) {
				let canCancelProcessExecution = false;
				if (this._canUserCancelProcess) {
					const status = item.get("Status").value;
					const cancelExecutionStatuses = [
						ConfigurationConstants.SysProcess.Status.Running,
						ConfigurationConstants.SysProcess.Status.Error,
						ConfigurationConstants.SysProcess.Status.Cancelling,
					];
					canCancelProcessExecution = Terrasoft.contains(cancelExecutionStatuses, status);
				}
				return canCancelProcessExecution;
			},

			/**
			 * @private
			 */
			_getSubProcessGridData: function(id) {
				const gridData = this.getGridData();
				return gridData.filterByFn(function(item) {
					const parent = item.values.Parent;
					return parent && parent.value === id;
				}, this);
			},

			/**
			 * @private
			 */
			_canUpdateStatus: function(currentStatus) {
				const status = ConfigurationConstants.SysProcess.Status2;
				return !currentStatus || currentStatus.value === status.Error.value ||
					currentStatus.value === status.Running.value;
			},

			/**
			 * @private
			 */
			_setCanceledProcessStatus: function(recordId) {
				const gridData = this.getGridData();
				if (gridData.contains(recordId)) {
					const status = ConfigurationConstants.SysProcess.Status2.Cancelling;
					const row = gridData.get(recordId);
					const currentStatus = row.get("Status");
					if (this._canUpdateStatus(currentStatus)) {
						row.set("Status", status);
						row.setCancelExecutionButtonVisible(false);
						setTimeout(() => {
							row.setCancelExecutionButtonVisible(true);
						}, 15000);
					}
				}
				const subProcessGridData = this._getSubProcessGridData(recordId);
				subProcessGridData.each(function(item) {
					this._setCanceledProcessStatus(item.values.Id);
				}, this);
			},

			/**
			 * @private
			 */
			_registerCancelExecutionMessages: function() {
				this.sandbox.registerMessages({
					"ExecutionCanceled": {
						mode: Terrasoft.MessageMode.PTP,
						direction: Terrasoft.MessageDirectionType.SUBSCRIBE
					}
				});
				this.sandbox.subscribe("ExecutionCanceled", this.reloadCanceledProcessGridData, this);
			},

			/**
			 * Initialize user can cancel process property.
			 * @private
			 */
			_initCanCancelProcess: function(callback, scope) {
				RightUtilities.checkCanExecuteOperation({operation: "CanCancelProcess"},
					function(result) {
						this._canUserCancelProcess = result;
						Ext.callback(callback, scope);
					}, this);
			},

			// endregion

			/**
			 * Returns can user cancel process.
			 */
			canUserCancelProcess: function() {
				return this._canUserCancelProcess;
			},

			/**
			 * ForceCancelExecution confirmation handler.
			 */
			backgroundCancelExecutionConfirmation: function() {
				this.cancelExecutionConfirmation(true);
			},
			
			/**
			 * CancelExecution confirmation handler.
			 */
			cancelExecutionConfirmation: function(isBackgroundOperation) {
				const cancellationMethod = isBackgroundOperation
					? this.backgroundCancelExecution
					: this.cancelExecution;
				if (this.isAnySelected()) {
					const message = resources.localizableStrings.CancelExecutionConfirmation;
					this.showConfirmationDialog(message, cancellationMethod, [
						Terrasoft.MessageBoxButtons.YES.returnCode,
						Terrasoft.MessageBoxButtons.NO.returnCode
					]);
				}
			},

			/**
			 * Reloads cancel process grid data.
			 * @param {String} recordId Record Id.
			 */
			reloadCanceledProcessGridData: function(recordId) {
				this.loadGridDataRecord(recordId, function() {
					const subProcessGridData = this._getSubProcessGridData(recordId);
					subProcessGridData.each(function(item) {
						this.reloadCanceledProcessGridData(item.values.Id);
					}, this);
					this.trigger("change:ActiveRow", recordId);
				}, this);
			},

			/**
			 * Shows process diagram.
			 * @param {String} primaryColumnValue Primary column value for record.
			 */
			showProcessDiagram: function(primaryColumnValue) {
				let recordId = primaryColumnValue;
				const activeRow = this.getActiveRow();
				if (!recordId && this.isSingleSelected()) {
					recordId = activeRow.get("Id");
				}
				const managerName = activeRow.get("SysSchema.ManagerName");
				if (managerName === "DcmSchemaManager") {
					ProcessModuleUtilities.showDcmDiagram(recordId);
				} else {
					ProcessModuleUtilities.showProcessDiagram(recordId);
				}
			},

			/**
			 * Forcibly cancel process execution.
			 * @param {String} result Result of the dialog, possible values: 'yes'/'no'.
			 */
			backgroundCancelExecution: function(result) {
				if (result === Terrasoft.MessageBoxButtons.YES.returnCode) {
					if (this.get("SelectAllMode")) {
						this._backgroundCancelAllSelected();
					} else {
						this._backgroundCancelSelected();
					}
				}
			},
			
			/**
			 * Cancel process execution.
			 * @param {String} result Result of the dialog, possible values: 'yes'/'no'.
			 */
			cancelExecution: function(result) {
				if (result === Terrasoft.MessageBoxButtons.YES.returnCode) {
					if (this.get("SelectAllMode")) {
						this._cancelAllSelected();
					} else {
						this._cancelSelected();
					}
				}
			},

			/**
			 * Returns whether the menu is displayed to Cancel the execution.
			 * @return {Boolean}
			 */
			getShowCancelExecutionMenuVisible: function() {
				if (!this.canUserCancelProcess()) {
					return false;
				}
				if (this.get("SelectAllMode")) {
					return true;
				}
				const selectedItems = this.getSelectedItems();
				if (!selectedItems) {
					return false;
				}
				if (selectedItems.length > 1) {
					return true;
				}
				const gridData = this.getGridData();
				const id = selectedItems[0];
				const row = gridData.find(id);
				if (!row) {
					return false;
				}
				const statusEnum = ConfigurationConstants.SysProcess.Status;
				const status = row.get("Status").value;
				return status === statusEnum.Running || status === statusEnum.Error;
			},

			/**
			 * Initialize cancel execution methods.
			 * @param {Terrasoft.Collection} collection Rows.
			 */
			initCancelExecution: function(collection) {
				collection.each(function(item) {
					const canCancelProcessExecution = this._canCancelProcessExecution.bind(this, item);
					item.getCancelExecutionVisible = canCancelProcessExecution;
					item.canCancelProcessExecution = canCancelProcessExecution;
					item.set("CancelExecutionButtonVisible", item.getCancelExecutionVisible());
				}, this);
			},

			/**
			 * Initializes mixin properties and messages.
			 */
			init: function(callback, scope) {
				this._registerCancelExecutionMessages();
				this._initCanCancelProcess(callback, scope);
			}
		});
		return Terrasoft.ProcessLogUtilities;
	});


