define("SectionPageDesignerHeaderViewModel", ["MaskHelper", "PageDesignerHeaderViewModel"], function() {

	/**
	 * Class for SectionPageDesignerHeaderViewModel.
	 */
	Ext.define("Terrasoft.configuration.SectionPageDesignerHeaderViewModel", {
		extend: "Terrasoft.configuration.PageDesignerHeaderViewModel",
		alternateClassName: "Terrasoft.SectionPageDesignerHeaderViewModel",

		//region Methods: Protected

		/**
		 * @inheritdoc Terrasoft.WizardHeaderViewModel#saveButtonClick
		 * @override
		 */
		saveButtonClick: function() {
			this.sandbox.publish("CurrentStepChange", null, [this.sandbox.id]);
		},

		/**
		 * @inheritdoc Terrasoft.WizardHeaderViewModel#isCancelButtonVisible
		 * @override
		 */
		isCancelButtonVisible: function() {
			return false;
		}

		//endregion

	});

	return Terrasoft.SectionPageDesignerHeaderViewModel;
});
