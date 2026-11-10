Ext.define("Terrasoft.Designers.ProcessSchemaDesignerLogViewModelNew", {
	extend: "Terrasoft.ProcessSchemaDesignerViewModelNew",
	alternateClassName: "Terrasoft.ProcessSchemaDesignerLogViewModelNew",

	mixins: {
		processSchemaDesignerLogMixin: "Terrasoft.ProcessSchemaDesignerLogMixin"
	},

	/**
	 * @inheritdoc Terrasoft.BaseProcessSchemaDesignerViewModel#constructor
	 * @override
	 */
	constructor: function() {
		this.callParent(arguments);
		this.mixins.processSchemaDesignerLogMixin.initColumns.apply(this, arguments);
	},

	/**
	 * @inheritdoc Terrasoft.BaseProcessSchemaDesignerViewModel#init
	 * @override
	 */
	init: function() {
		this.set("DiagramConfig", this.getDiagramConfig());
		this.mixins.processSchemaDesignerLogMixin.init.apply(this, arguments);
	}
});
