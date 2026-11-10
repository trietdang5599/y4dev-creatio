/**
 */
Ext.define("Terrasoft.manager.PopulateBusinessRuleAction", {
	extend: "Terrasoft.BaseBusinessRuleAction",
	alternateClassName: "Terrasoft.PopulateBusinessRuleAction",

	// region Properties: Private

	/**
	 * @private
	 * @type {Terrasoft.BaseBusinessRuleExpression}
	 */
	leftExpression: null,

	/**
	 * @private
	 * @type {Terrasoft.BaseBusinessRuleExpression}
	 */
	rightExpression: null,

	// endregion

	// region Constructors: Protected

	/**
	 * @inheritdoc Terrasoft.BaseObject#constructor
	 * @override
	 */
	constructor: function(config) {
		this.callParent(arguments);
		config = config || {};
		if (!Ext.isEmpty(config.leftExpression)) {
			this.leftExpression = this.createItem(config.leftExpression);
		}
		if (!Ext.isEmpty(config.rightExpression)) {
			this.rightExpression = this.createItem(config.rightExpression);
		}
	}

	// endregion
});
