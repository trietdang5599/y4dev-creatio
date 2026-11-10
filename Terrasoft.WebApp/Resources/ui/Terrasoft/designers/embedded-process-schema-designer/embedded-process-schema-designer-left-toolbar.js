/**
 */
Ext.define("Terrasoft.controls.EmbeddedProcessSchemaDesignerLeftToolbar", {
	extend: "Terrasoft.controls.ProcessSchemaDesignerLeftToolbar",
	alternateClassName: "Terrasoft.EmbeddedProcessSchemaDesignerLeftToolbar",

	/**
	 * @inheritdoc Terrasoft.ProcessSchemaDesignerLeftToolbar#getFlowElementGroup
	 * @override
	 */
	getToolbarGroups: function() {
		const groups = this.callParent(arguments);
		return _.omit(groups, "UserTask");
	},

	/**
	 * @inheritdoc Terrasoft.ProcessSchemaDesignerLeftToolbar#getToolbarItemVisible
	 * @override
	 */
	getToolbarItemVisible: function(item) {
		return this.callParent(arguments) && item.supportEmbeddedProcess;
	}
});
