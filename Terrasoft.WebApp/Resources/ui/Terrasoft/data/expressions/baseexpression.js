/**
 * @abstract
 * The base class of the expression
 */
Ext.define("Terrasoft.data.expressions.BaseExpression", {
	extend: "Terrasoft.core.collections.ObjectCollectionItem",
	alternateClassName: "Terrasoft.BaseExpression",

	/**
	 * Type of expression
	 * @type {Terrasoft.ExpressionType}
	 */
	expressionType: Terrasoft.ExpressionType.SCHEMA_COLUMN,

	/**
	 * Type of date fragment
	 * @type {Terrasoft.DatePartType}
	 */
	datePartType: Terrasoft.DatePartType.NONE,

	/**
	 * True if expression has brackets.
	 * @type {Boolean}
	 */
	isBlock: false,

	/**
	 * Copies the properties for serialization to the serialized object. Implements the mixin interface
	 * {@link Terrasoft.Serializable}
	 * @protected
	 * @override
	 * @param {Object} serializableObject Serialized object
	 */
	getSerializableObject: function(serializableObject) {
		this.callParent(arguments);
		serializableObject.expressionType = this.expressionType;
		if (this.isBlock) {
			serializableObject.isBlock = this.isBlock;
		}
	}

});
