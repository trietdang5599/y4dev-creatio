Terrasoft.configuration.Structures["CtiPanelModule"] = {innerHierarchyStack: ["CtiPanelModule"]};
define("CtiPanelModule", ["BaseSchemaModuleV2"], function() {
	/**
	 * @class Terrasoft.configuration.CtiPanelModule
	 * CTI panel page class to work with calls.
	 */
	Ext.define("Terrasoft.configuration.CtiPanelModule", {
		alternateClassName: "Terrasoft.CtiPanelModule",
		extend: "Terrasoft.BaseSchemaModule",

		/**
		 * Initializes the name of the scheme.
		 * @protected
		 * @overridden
		 */
		initSchemaName: function() {
			this.schemaName = "CtiPanel";
		},

		render: function(renderTo) {
			this.view = this.viewModel?.myView;
			this.callParent(arguments);
			this.viewModel.myView = this.view;
		},

		/**
		 * Creates view model. Extends model {@link Terrasoft.CtiModel} by current class model.
		 * @protected
		 * @overridden
		 */
		createViewModel: function() {
			if(Terrasoft?.CtiModel?.model.isEmpty()){
				const viewModel = this.callParent(arguments);
				const model = Ext.merge(Terrasoft.CtiModel.model, viewModel.model);
				Ext.merge(viewModel, Terrasoft.CtiModel, {
					init: viewModel.init
				});
				viewModel.model = model;
				Terrasoft.CtiModel = Terrasoft.integration.telephony.CtiModel = viewModel;
				return viewModel;
			} else {
				Terrasoft.CtiModel.set("Restored", true);
				return Terrasoft.CtiModel;
			}
		},

		/**
		 * Replaces the last element in the chain of states, if the identifier module is different from the current.
		 * @protected
		 * @overridden
		 */
		initHistoryState: Ext.emptyFn

	});
	return Terrasoft.CtiPanelModule;
});


