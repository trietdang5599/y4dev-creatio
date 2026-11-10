define("MLangContentContainerModule", ["BusinessRulesApplierV2", "BaseSchemaModuleV2"], function(BusinessRulesApplier) {
	Ext.define("Terrasoft.configuration.MLangContentContainerModule", {
		extend: "Terrasoft.BaseSchemaModule",
		alternateClassName: "Terrasoft.MLangContentContainerModule",

		/**
		 * Set income parameters in ViewModel instance.
		 * @param {Terrasoft.BaseViewModel} viewModel ViewModel instance.
		 * @private
		 */
		_setViewModelAttributes: function(viewModel) {
			viewModel.set("parameters", this.parameters);
		},

		/**
		 * @inheritDoc Terrasoft.BaseSchemaModule#generateViewContainerId
		 * @overridden
		 */
		generateViewContainerId: false,

		/**
		 * @inheritDoc Terrasoft.BaseSchemaModule#initSchemaName
		 * @overridden
		 */
		initSchemaName: function() {
			this.schemaName = this.parameters.moduleSchemaName;
		},

		/**
		 * @inheritDoc Terrasoft.BaseSchemaModule#createViewModel
		 * @protected
		 * @overridden
		 */
		createViewModel: function() {
			var viewModel = this.callParent(arguments);
			if (viewModel.type === Terrasoft.SchemaType.EDIT_VIEW_MODEL_SCHEMA) {
				BusinessRulesApplier.applyDependencies(viewModel);
			}
			this._setViewModelAttributes(viewModel);
			return viewModel;
		},

		/**
		 * @inheritDoc Terrasoft.BaseSchemaModule#initHistoryState
		 * @overridden
		 */
		initHistoryState: Ext.emptyFn
	});
	return Terrasoft.MLangContentContainerModule;
});
