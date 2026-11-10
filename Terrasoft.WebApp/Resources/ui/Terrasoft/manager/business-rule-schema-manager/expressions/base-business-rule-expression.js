/**
 */
Ext.define("Terrasoft.manager.BaseBusinessRuleExpression", {
	extend: "Terrasoft.BaseBusinessRuleElement",
	alternateClassName: "Terrasoft.BaseBusinessRuleExpression",

	// region Properties: Private

	/**
	 * Data value type.
	 * @private
	 * @type {Integer}
	 */
	dataValueType: null,

	// TODO Do not use in angular implementation
	autoClean: false,

	// TODO Do not use in angular implementation
	autocomplete: false,

	// endregion

	// region Methods: Public

	/**
	 * Returns expression value.
	 * @return {Object} Expression value.
	 */
	getExpressionValue: Terrasoft.abstractFn,

	/**
	 * Sets expression value.
	 * @param {Object} value Expression value.
	 */
	setExpressionValue: Terrasoft.abstractFn

	// endregion

});
