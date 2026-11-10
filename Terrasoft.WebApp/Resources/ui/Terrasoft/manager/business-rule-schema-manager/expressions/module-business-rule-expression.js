/**
 */
Ext.define("Terrasoft.manager.ModuleBusinessRuleExpression", {
	extend: "Terrasoft.BaseBusinessRuleExpression",
	alternateClassName: "Terrasoft.ModuleBusinessRuleExpression",

	// region Properties: Private

	/**
	 * Module name.
	 * @private
	 * @type {String}
	 */
	moduleName: null,

	// endregion

	// region Methods: Public

	/**
	 * @inheritdoc Terrasoft.BaseBusinessRuleExpression#getExpressionValue
	 * @override
	 */
	getExpressionValue: function() {
		return this.moduleName;
	},

	/**
	 * @inheritdoc Terrasoft.BaseBusinessRuleExpression#setExpressionValue
	 * @override
	 */
	setExpressionValue: function(value) {
		this.moduleName = value;
	}

	// endregion

});
