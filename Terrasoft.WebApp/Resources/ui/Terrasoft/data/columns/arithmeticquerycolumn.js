/**
 * The class defining the arithmetic column.
 */
Ext.define("Terrasoft.data.columns.ArithmeticQueryColumn", {
	extend: "Terrasoft.BaseQueryColumn",
	alternateClassName: "Terrasoft.ArithmeticQueryColumn",

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
	initExpression: function() {
		this.callParent(arguments);
		this.expression = Ext.create("Terrasoft.ArithmeticExpression", {
			arithmeticOperation: this.arithmeticOperation,
			leftArithmeticOperand: this.leftArithmeticOperand,
			rightArithmeticOperand: this.rightArithmeticOperand
		});
	}
});
