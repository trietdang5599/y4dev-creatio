Ext.define("Terrasoft.data.expressions.DateAddFunctionExpression", {
	extend: "Terrasoft.FunctionExpression",
	alternateClassName: "Terrasoft.DateAddFunctionExpression",

	/**
	 * @inheritdoc
	 * @overridden
	 */
	functionType: Terrasoft.FunctionType.DATE_ADD,

	/**
	 * @inheritdoc
	 * @overridden
	 */
	datePartType: Terrasoft.DatePartType.NONE,

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
	 * @inheritdoc
	 * @overridden
	 */
	getSerializableObject: function(serializableObject) {
		this.callParent(arguments);
		serializableObject.datePartType = this.datePartType;
		serializableObject.functionArguments = serializableObject.functionArguments || [];
		if (this.numberExpression) {
			serializableObject.functionArguments.push(
				this.getSerializableProperty(this.numberExpression)
			);
		}
		if (this.dateTimeExpression) {
			serializableObject.functionArguments.push(
				this.getSerializableProperty(this.dateTimeExpression)
			);
		}
	}
});
