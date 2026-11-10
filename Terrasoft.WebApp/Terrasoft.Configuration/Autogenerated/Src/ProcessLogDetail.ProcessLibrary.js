define("ProcessLogDetail", ["ProcessLogDetailResources", "ConfigurationConstants", "ProcessLogActions", "BaseSectionGridRowViewModel"],
	function(resources, ConfigurationConstants) {
	return {
		mixins: {
			ProcessLogActions: "Terrasoft.ProcessLogActions"
		},
		methods: {
			/**
			 * @inheritDoc Terrasoft.BaseGridDetailV2#getSwitchGridModeMenuItem
			 * @protected
			 * @overridden
			 */
			getSwitchGridModeMenuItem: Terrasoft.emptyFn,

			/**
			 * @inheritdoc Terrasoft.GridUtilitiesV2#getGridRowViewModelClassName
			 * @overriden
			 */
			getGridRowViewModelClassName: function() {
				return "Terrasoft.BaseSectionGridRowViewModel";
			},

			/**
			 * @inheritdoc GridUtilitiesV2#createViewModel
			 * @overridden
			 */
			createViewModel: function(config) {
				this.callParent(arguments);
				this._bindItemViewModelMethods(config.viewModel);
			},

			/**
			 * Set state of the Visible parameter of DataGridActiveRowCancelExecution.
			 * @virtual
			 * @param {Boolean} flag state of the Visible parameter.
			 */
			setCancelExecutionButtonVisible: function (flag) {
				const cancelExecutionStatuses = [
					ConfigurationConstants.SysProcess.Status.Running,
					ConfigurationConstants.SysProcess.Status.Error,
				];
				const status = this.$Status;
				const canCancelProcessExecution = Terrasoft.contains(cancelExecutionStatuses, status);
				this.set("CancelExecutionButtonVisible", canCancelProcessExecution);
			},

			/**
			 * @private
			 */
			_bindItemViewModelMethods: function(viewModel) {
				viewModel.setCancelExecutionButtonVisible = this.setCancelExecutionButtonVisible.bind(viewModel);
			},

			/**
			 * @inheritdoc Terrasoft.GridUtilitiesV2#prepareResponseCollection
			 * @overriden
			 */
			prepareResponseCollection: function(collection) {
				this.mixins.GridUtilities.prepareResponseCollection.call(this, collection);
				this.initCancelExecution(collection);
			},

			/**
			 * @inheritdoc GridUtilitiesV2#onActiveRowAction
			 * @overridden
			 */
			onActiveRowAction: function(tag, primaryColumnValue) {
				switch (tag) {
					case "openProperties":
						this.editRecord();
						break;
					case "showProcessDiagram":
						this.showProcessDiagram(primaryColumnValue);
						break;
					case "cancelExecution":
						this.cancelExecutionConfirmation();
						break;
					default:
						break;
				}
			},

			/**
			 * @inheritdoc Terrasoft.BaseSchemaViewModel#init
			 * @overridden
			 */
			init: function(callback, scope) {
				this.callParent([function() {
					this.mixins.ProcessLogActions.init.call(this, callback, scope);
				}, this]);
			}
		},
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "merge",
				"name": "DataGrid",
				"values": {
					"getEmptyMessageConfig": {"bindTo": "getEmptyMessageConfig"},
					"activeRowActions": [
						{
							"className": "Terrasoft.Button",
							"style": Terrasoft.controls.ButtonEnums.style.BLUE,
							"caption": resources.localizableStrings.OpenPropertiesPageButtonCaption,
							"tag": "openProperties"
						},
						{
							"className": "Terrasoft.Button",
							"caption": resources.localizableStrings.ProcessDiagramButtonCaption,
							"tag": "showProcessDiagram"
						},
						{
							"className": "Terrasoft.Button",
							"caption": resources.localizableStrings.CancelExecutionButtonCaption,
							"tag": "cancelExecution",
							"visible": {
								"bindTo": "CancelExecutionButtonVisible"
							}
						}
					],
					"listedZebra": true,
					"activeRowAction": { bindTo: "onActiveRowAction" }
				}
			}
		]/**SCHEMA_DIFF*/
	};
});
