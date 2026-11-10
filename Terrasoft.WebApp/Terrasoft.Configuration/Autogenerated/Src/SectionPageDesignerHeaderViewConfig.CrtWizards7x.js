define("SectionPageDesignerHeaderViewConfig", [
	"SectionPageDesignerHeaderViewConfigResources",
	"SectionPageDesignerHeaderModule",
	"PageDesignerHeaderViewConfig"
], function(resources) {

	/**
	 * Class for SectionPageDesignerHeaderViewConfig.
	 */
	Ext.define("Terrasoft.configuration.SectionPageDesignerHeaderViewConfig", {
		extend: "Terrasoft.configuration.PageDesignerHeaderViewConfig",
		alternateClassName: "Terrasoft.SectionPageDesignerHeaderViewConfig",

		//region Methods: Protected

		/**
		 * @inheritdoc Terrasoft.PageDesignerHeaderViewConfig#getUtilsLeftContainerViewConfig
		 * @override
		 */
		getUtilsLeftContainerViewConfig: function() {
			const config = this.callParent();
			const saveButtonConfig = _.find(config.items, {name: "SaveButton"});
			saveButtonConfig.caption = resources.localizableStrings.SaveButtonCaption;
			saveButtonConfig.style = Terrasoft.controls.ButtonEnums.style.GREEN;
			saveButtonConfig.imageConfig = resources.localizableImages.SaveButtonImage;
			saveButtonConfig.tips[0].content = resources.localizableStrings.SaveButtonHint;
			return config;
		}

		//endregion
	});

});
