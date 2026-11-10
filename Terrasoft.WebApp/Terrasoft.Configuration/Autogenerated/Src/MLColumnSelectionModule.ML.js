define("MLColumnSelectionModule", ["BaseSchemaModuleV2"],
	function() {
		/**
		 * @class Terrasoft.configuration.ProductSelectionModule
		 */
		Ext.define("Terrasoft.configuration.MLColumnSelectionModule", {
			alternateClassName: "Terrasoft.MLColumnSelectionModule",
			extend: "Terrasoft.BaseSchemaModule",
			schemaName: "MLColumnSelectionSchema",
			Ext: null,
			sandbox: null,
			Terrasoft: null,
			messages: null,
			useHistoryState: false,
			isSchemaConfigInitialized: true,
			entitySchemaName: "MLModelColumn",
			rootSchema: null,
			columnType: null,
			title: null,
			helpText: null,

			createViewModel: function() {
				const viewModel = this.callParent(arguments);
				viewModel.$SelectionRootSchemaAttributeName = this.rootSchema;
				viewModel.$MLColumnType = this.columnType;
				viewModel.$ModuleTitle = this.title;
				viewModel.$HelpText = this.helpText;
				return viewModel;
			}
		});

		return Terrasoft.MLColumnSelectionModule;
	});
