/**
 */
Ext.define("Terrasoft.manager.TabBusinessRuleExpression", {
	extend: "Terrasoft.BaseBusinessRuleExpression",
	alternateClassName: "Terrasoft.TabBusinessRuleExpression",

	// region Properties: Private

	/**
	 * Tab name.
	 * @private
	 * @type {String}
	 */
	tabName: null,

	// endregion

	// region Methods: Public

	/**
	 * @inheritdoc Terrasoft.BaseBusinessRuleExpression#getExpressionValue
	 * @override
	 */
	getExpressionValue: function() {
		return this.tabName;
	},

	/**
	 * @inheritdoc Terrasoft.BaseBusinessRuleExpression#setExpressionValue
	 * @override
	 */
	setExpressionValue: function(value) {
		this.tabName = value;
	}

	// endregion

});
