/**
 */
Ext.define("Terrasoft.Designers.ProcessSchemaDesignerLogViewModel", {
	extend: "Terrasoft.ProcessSchemaDesignerViewModel",
	alternateClassName: "Terrasoft.ProcessSchemaDesignerLogViewModel",

	mixins: {
		processSchemaDesignerLogMixin: "Terrasoft.ProcessSchemaDesignerLogMixin"
	},

	/**
	 * @inheritdoc Terrasoft.ProcessSchemaDesignerViewModel#init
	 * @override
	 */
	constructor: function() {
		this.callParent(arguments);
		this.mixins.processSchemaDesignerLogMixin.initColumns.apply(this, arguments);
	},

	/**
	 * @inheritdoc Terrasoft.ProcessSchemaDesignerViewModel#init
	 * @override
	 */
	init: function() {
		this.mixins.processSchemaDesignerLogMixin.init.apply(this, arguments);
	}
});
