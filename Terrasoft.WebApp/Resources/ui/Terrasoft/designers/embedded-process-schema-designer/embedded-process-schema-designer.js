/**
 */
Ext.define("Terrasoft.Designers.EmbeddedProcessSchemaDesigner", {
	extend: "Terrasoft.Designers.ProcessSchemaDesigner",
	alternateClassName: "Terrasoft.EmbeddedProcessSchemaDesigner",

	mixins: {
		embeddedProcessSchemaDesignerMixin: "Terrasoft.EmbeddedProcessSchemaDesignerMixin"
	},

	/**
	 * @inheritdoc Terrasoft.ProcessSchemaDesigner#designerViewModelClassName
	 * @override
	 */
	designerViewModelClassName: "Terrasoft.EmbeddedProcessSchemaDesignerViewModel",

	/**
	 * @inheritdoc Terrasoft.ProcessSchemaDesigner#leftToolbarClassName
	 * @override
	 */
	leftToolbarClassName: "Terrasoft.EmbeddedProcessSchemaDesignerLeftToolbar",

	/**
	 * @inheritdoc Terrasoft.ProcessSchemaDesigner#createToolBarLefContainerItems
	 * @override
	 */
	createToolBarLefContainerItems: function(actionButtonMenuItems) {
		return this.mixins.embeddedProcessSchemaDesignerMixin.createToolBarLefContainerItems.apply(this, arguments);
	},

	/**
	 * @inheritdoc Terrasoft.ProcessSchemaDesigner#createToolbarLeftContainer
	 * @override
	 */
	createToolbarLeftContainer: function() {
		return this.mixins.embeddedProcessSchemaDesignerMixin.createToolbarLeftContainer.apply(this, arguments);
	}
});
