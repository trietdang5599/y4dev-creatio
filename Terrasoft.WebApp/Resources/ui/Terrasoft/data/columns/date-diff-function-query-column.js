Ext.define("Terrasoft.data.columns.DateDiffFunctionQueryColumn", {
	extend: "Terrasoft.FunctionQueryColumn",
	alternateClassName: "Terrasoft.DateDiffFunctionQueryColumn",

	/**
	 * @inheritdoc
	 * @overridden
	 */
	functionType: Terrasoft.FunctionType.DATE_DIFF,

	/**
	 * Start date time expression.
	 * @type {Terrasoft.BaseExpression}
	 */
	startDateExpression: null,

	/**
	 * End date time expression.
	 * @type {Terrasoft.BaseExpression}
	 */
	endDateExpression: null,

	/**
	 * Date diff interval.
	 * @type {Terrasoft.DateDiffInterval}
	 */
	dateDiffInterval: Terrasoft.DateDiffInterval.NONE,

	/**
	 * @protected
	 * @override
	 */
	initExpression: function() {
		this.callParent(arguments);
		this.expression = Ext.create("Terrasoft.DateDiffFunctionExpression", {
			startDateExpression: this.startDateExpression,
			endDateExpression: this.endDateExpression,
			dateDiffInterval: this.dateDiffInterval
		});
	}
});
