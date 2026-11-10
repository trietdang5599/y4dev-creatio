/**
 */
Ext.define("Terrasoft.manager.GroupBusinessRuleExpression", {
	extend: "Terrasoft.BaseBusinessRuleExpression",
	alternateClassName: "Terrasoft.GroupBusinessRuleExpression",

	// region Properties: Private

	/**
	 * Group name.
	 * @private
	 * @type {String}
	 */
	groupName: null,

	// endregion

	// region Methods: Public

	/**
	 * @inheritdoc Terrasoft.BaseBusinessRuleExpression#getExpressionValue
	 * @override
	 */
	getExpressionValue: function() {
		return this.groupName;
	},

	/**
	 * @inheritdoc Terrasoft.BaseBusinessRuleExpression#setExpressionValue
	 * @override
	 */
	setExpressionValue: function(value) {
		this.groupName = value;
	}

	// endregion

});
