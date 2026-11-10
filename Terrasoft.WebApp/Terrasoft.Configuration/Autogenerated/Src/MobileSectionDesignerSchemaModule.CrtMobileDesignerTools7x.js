define("MobileSectionDesignerSchemaModule", ["BaseSchemaModuleV2"], function() {
	/**
	 * @class Terrasoft.configuration.MobileSectionDesignerSchemaModule
	 * ##### ######## ######### ########## ##########.
	 */
	Ext.define("Terrasoft.configuration.MobileSectionDesignerSchemaModule", {
		alternateClassName: "Terrasoft.MobileSectionDesignerSchemaModule",
		extend: "Terrasoft.BaseSchemaModule",

		/**
		 * ### ######## ######## ##### ########## ##########
		 * @public
		 * @type {String}
		 */
		workplace: "",

		/**
		 * ### ######## ######## ##### ########## ##########
		 * @public
		 * @type {String}
		 */
		workplaceTypeId: "",

		/**
		 * ############## ######## #####.
		 * @protected
		 * @overridden
		 */
		initSchemaName: function() {
			this.schemaName = "MobileSectionDesignerModule";
		},

		/**
		 * ####### ###### #############
		 * @protected
		 * @overridden
		 * @param {Object} viewModelClass ##### ###### ############# #####
		 * @return {Object} ########## ######### ###### ############# #####
		 */
		createViewModel: function() {
			var viewModel = this.callParent(arguments);
			viewModel.set("Workplace", this.workplace);
			viewModel.set("WorkplaceTypeId", this.workplaceTypeId);
			return viewModel;
		}

	});
	return Terrasoft.MobileSectionDesignerSchemaModule;
});
