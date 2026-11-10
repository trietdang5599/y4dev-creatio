/**
 */
Ext.define("Terrasoft.manager.FormulaBusinessRuleExpression", {
	extend: "Terrasoft.BaseBusinessRuleExpression",
	alternateClassName: "Terrasoft.FormulaBusinessRuleExpression",

	// region Properties: Private

	/**
	 * Formula value.
	 * @private
	 * @type {Object}
	 */
	formula: null,

	// endregion

	// region Methods: Public

	/**
	 * @inheritDoc Terrasoft.BaseBusinessRuleExpression#getExpressionValue
	 * @override
	 */
	getExpressionValue: function() {
		return this.formula;
	},

	/**
	 * @inheritDoc Terrasoft.BaseBusinessRuleExpression#setExpressionValue
	 * @override
	 */
	setExpressionValue: function(value) {
		this.formula = value;
	}

	// endregion

});
