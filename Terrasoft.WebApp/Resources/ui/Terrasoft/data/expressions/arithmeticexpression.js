/**
 * A class that describes a arithmetic expression.
 */
Ext.define("Terrasoft.data.expressions.ArithmeticExpression", {
	extend: "Terrasoft.BaseExpression",
	alternateClassName: "Terrasoft.ArithmeticExpression",

	/**
	 * @inheritDoc
	 * @override
	 */
	expressionType: Terrasoft.ExpressionType.ARITHMETIC_OPERATION,

	/**
	 * Arithmetic operation.
	 * @type {Terrasoft.ArithmeticOperation}
	 */
	arithmeticOperation: null,

	/**
	 * Left operand of an arithmetic operation.
	 * @type {Terrasoft.BaseExpression}
	 */
	leftArithmeticOperand: null,

	/**
	 * Right operand of an arithmetic operation.
	 * @type {Terrasoft.BaseExpression}
	 */
	rightArithmeticOperand: null,

	/**
	 * @inheritDoc
	 * @override
	 */
	getSerializableObject: function(serializableObject) {
		this.callParent(arguments);
		serializableObject.arithmeticOperation = this.arithmeticOperation;
		serializableObject.leftArithmeticOperand = this.getSerializableProperty(this.leftArithmeticOperand);
		serializableObject.rightArithmeticOperand = this.getSerializableProperty(this.rightArithmeticOperand);
	}
});
