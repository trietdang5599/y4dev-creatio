/**
 */
Ext.define("Terrasoft.Designers.EmbeddedProcessSchemaDesignerNew", {
	extend: "Terrasoft.Designers.ProcessSchemaDesignerNew",
	alternateClassName: "Terrasoft.EmbeddedProcessSchemaDesignerNew",

	mixins: {
		embeddedProcessSchemaDesignerMixin: "Terrasoft.EmbeddedProcessSchemaDesignerMixin"
	},

	/**
	 * @inheritdoc Terrasoft.ProcessSchemaDesigner#designerViewModelClassName
	 * @override
	 */
	designerViewModelClassName: "Terrasoft.EmbeddedProcessSchemaDesignerViewModelNew",

	/**
	 * @inheritdoc Terrasoft.ProcessSchemaDesigner#createToolBarLefContainerItems
	 * @override
	 */
	createToolBarLefContainerItems: function(actionButtonMenuItems) {
		return this.mixins.embeddedProcessSchemaDesignerMixin.createToolBarLefContainerItems.apply(this, arguments);
	},

	/**
	 * @inheritdoc Terrasoft.ProcessSchemaDesignerNew#showImportButton
	 * @override
	 */
	showImportButton: false,

	/**
	 * @inheritdoc Terrasoft.ProcessSchemaDesigner#createToolbarLeftContainer
	 * @override
	 */
	createToolbarLeftContainer: function() {
		return this.mixins.embeddedProcessSchemaDesignerMixin.createToolbarLeftContainer.apply(this, arguments);
	},

	/**
	 * @inheritdoc Terrasoft.ProcessSchemaDesigner#getDiagramConfig
	 * @override
	 */
	getDiagramConfig: function () {
		const config = this.callParent(arguments);
		config.canImport = false;
		return config;
	}

});
