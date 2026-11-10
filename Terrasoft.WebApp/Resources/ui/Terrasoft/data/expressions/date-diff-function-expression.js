Ext.define("Terrasoft.data.expressions.DateDiffFunctionExpression", {
	extend: "Terrasoft.FunctionExpression",
	alternateClassName: "Terrasoft.DateDiffFunctionExpression",

	/**
	 * @inheritdoc
	 * @overridden
	 */
	functionType: Terrasoft.FunctionType.DATE_DIFF,

	/**
	 * @inheritdoc
	 * @overridden
	 */
	dateDiffInterval: Terrasoft.DateDiffInterval.NONE,

	/**
	 * Start date time expression.
	 * @type {Terrasoft.BaseExpression}
	 */
	startDateExpression: null,

	/**
	 * Start end time expression.
	 * @type {Terrasoft.BaseExpression}
	 */
	endDateExpression: null,

	/**
	 * @inheritdoc
	 * @overridden
	 */
	getSerializableObject: function(serializableObject) {
		this.callParent(arguments);
		serializableObject.dateDiffInterval = this.dateDiffInterval;
		serializableObject.functionArguments = serializableObject.functionArguments || [];
		if (this.startDateExpression) {
			serializableObject.functionArguments.push(
				this.getSerializableProperty(this.startDateExpression)
			);
		}
		if (this.endDateExpression) {
			serializableObject.functionArguments.push(
				this.getSerializableProperty(this.endDateExpression)
			);
		}
	}
});
