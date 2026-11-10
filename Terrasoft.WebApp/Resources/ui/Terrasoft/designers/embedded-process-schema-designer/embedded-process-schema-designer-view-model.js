Ext.define("Terrasoft.Designers.EmbeddedProcessSchemaDesignerViewModel", {
	extend: "Terrasoft.Designers.ProcessSchemaDesignerViewModel",
	alternateClassName: "Terrasoft.EmbeddedProcessSchemaDesignerViewModel",

	mixins: {
		embeddedProcessSchemaDesignerMixin: "Terrasoft.EmbeddedProcessSchemaDesignerMixin"
	},

	// region Properties: Protected

	/**
	 * @inheritdoc Terrasoft.Designers.BaseProcessSchemaDesignerViewModel#contextHelpCode
	 * @override
	 */
	contextHelpCode: "EmbeddedProcessSchemaDesigner",

	/**
	 * @inheritdoc Terrasoft.Designers.ProcessSchemaDesignerViewModel#schemaManager
	 * @override
	 */
	schemaManager: Terrasoft.EmbeddedProcessSchemaManager,

	/**
	 * @inheritdoc Terrasoft.Designers.ProcessSchemaDesignerViewModel#urlHashPrefix
	 * @override
	 */
	urlHashPrefix: "entityProcess",

	// endregion

	// region Properties: Public

	/**
	 * Flag specifying that the this schema has a parent process schema.
	 * @type {Boolean}
	 */
	hasParentProcess: false,

	// endregion

	// region Methods: Public

	/**
	 * @inheritdoc Terrasoft.ProcessSchemaDesignerViewModel#onSchemaLoaded
	 * @override
	 * @param {Terrasoft.manager.EmbeddedProcessSchema} schema Process schema.
	 */
	onSchemaLoaded: function(schema) {
		this.callParent(arguments);
		this.mixins.embeddedProcessSchemaDesignerMixin.onSchemaLoaded.apply(this, arguments);
	},

	/**
	 * @inheritdoc Terrasoft.ProcessSchemaDesignerViewModel#openSourceCode
	 * @override
	 */
	openSourceCode: function(schema) {
		Terrasoft.BaseSchemaDesignerUtilities.openEntitySourceCode(schema);
	},

	/**
	 * @inheritdoc Terrasoft.ProcessSchemaDesignerViewModel#onGenerateItemNameAndCaption
	 * @override
	 */
	onGenerateItemNameAndCaption: function(item) {
		return this.mixins.embeddedProcessSchemaDesignerMixin.onGenerateItemNameAndCaption.apply(this, arguments);
	},

	/**
	 * @inheritdoc Terrasoft.ProcessSchemaDesignerViewModel#showProcessConfirmationDialog
	 * @override
	 */
	showProcessConfirmationDialog: function(title, message, handler, buttons) {
		this.callParent([title, null, handler, buttons]);
	},

	/**
	 * @inheritdoc Terrasoft.BaseProcessSchemaDesignerViewModel#getSaveButtonMenuItems
	 * @override
	 */
	getSaveButtonMenuItems: function() {
		return [];
	}

	// endregion

});
