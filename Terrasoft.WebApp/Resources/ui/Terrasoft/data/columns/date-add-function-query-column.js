Ext.define("Terrasoft.data.columns.DateAddFunctionQueryColumn", {
	extend: "Terrasoft.FunctionQueryColumn",
	alternateClassName: "Terrasoft.DateAddFunctionQueryColumn",

	/**
	 * @inheritdoc
	 * @overridden
	 */
	functionType: Terrasoft.FunctionType.DATE_ADD,

	/**
	 * Number expression.
	 * @type {Terrasoft.BaseExpression}
	 */
	numberExpression: null,

	/**
	 * Date time expression.
	 * @type {Terrasoft.BaseExpression}
	 */
	dateTimeExpression: null,

	/**
	 * @protected
	 * @override
	 */
	initExpression: function() {
		this.callParent(arguments);
		this.expression = Ext.create("Terrasoft.DateAddFunctionExpression", {
			datePartType: this.datePartType,
			numberExpression: this.numberExpression,
			dateTimeExpression: this.dateTimeExpression
		});
	}
});
