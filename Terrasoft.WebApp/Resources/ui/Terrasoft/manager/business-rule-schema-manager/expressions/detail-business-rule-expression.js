/**
 */
Ext.define("Terrasoft.manager.DetailBusinessRuleExpression", {
	extend: "Terrasoft.BaseBusinessRuleExpression",
	alternateClassName: "Terrasoft.DetailBusinessRuleExpression",

	// region Properties: Private

	/**
	 * Detail name.
	 * @private
	 * @type {String}
	 */
	detailName: null,

	// endregion

	// region Methods: Public

	/**
	 * @inheritdoc Terrasoft.BaseBusinessRuleExpression#getExpressionValue
	 * @override
	 */
	getExpressionValue: function() {
		return this.detailName;
	},

	/**
	 * @inheritdoc Terrasoft.BaseBusinessRuleExpression#setExpressionValue
	 * @override
	 */
	setExpressionValue: function(value) {
		this.detailName = value;
	}

	// endregion

});
