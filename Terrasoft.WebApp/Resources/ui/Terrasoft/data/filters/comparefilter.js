/**
 * Comparison filter class
 */
Ext.define("Terrasoft.data.filters.CompareFilter", {
	extend: "Terrasoft.BaseFilter",
	alternateClassName: "Terrasoft.CompareFilter",

	/**
	 * Type of filter.
	 * @type {Terrasoft.FilterType}
	 */
	filterType: Terrasoft.FilterType.COMPARE,

	/**
	 * Filter expression.
	 * @type {Terrasoft.BaseExpression}
	 */
	rightExpression: null,

	/**
	 * Subquery filters. Cannot contain filters with other subqueries
	 * @type {Terrasoft.FilterGroup}
	 */
	subFilters: null,

	/**
	 * Creates and initializes the {@link Terrasoft.CompareFilter} object.
	 */
	constructor: function() {
		this.callParent(arguments);
		this.addEvents(
			/**
		 	* @event rightExpressionChange
		 	* Is triggered after changing the right part of the filter {@link #setRightExpression}.
		 	* @param {Terrasoft.BaseExpression} filter
		 	*/
			"rightExpressionChange"
		);
		this.setRightExpression(this.rightExpression);
		this.setSubFilter(this.leftExpression);
	},

	/**
	 * Copies the properties for serialization to the serialized object. Implements the mixin interface.
	 * {@link Terrasoft.Serializable}.
	 * @protected
	 * @override
	 * @param {Object} serializableObject Serialized object.
	 */
	getSerializableObject: function(serializableObject) {
		this.callParent(arguments);
		if (this.leftExpression && this.leftExpression.datePartType &&
				this.leftExpression.datePartType !== Terrasoft.DatePartType.NONE) {
			serializableObject.leftExpression.datePartType = this.leftExpression.datePartType;
		}
		serializableObject.rightExpression = this.getSerializableProperty(this.rightExpression);
		if (Terrasoft.Features.getIsDisabled("DisableForceUpdateCaptionForLeftExpression") && this.subFilters) {
			serializableObject.subFilters = this.getSerializableProperty(this.subFilters);
		}
	},

	/**
	 * Get sub filter from left expresion.
	 * @param leftExpression
	 */
	setSubFilter: function(leftExpression) {
		if (!leftExpression || !leftExpression.subFilters) {
			return;
		}
		this.subFilters = leftExpression.subFilters;
	},

	/**
	 * Check that the filter is full, valid and ready for use.
	 * @protected
	 * @override
	 * @return {Boolean} Returns true if the filter is fully populated and can be applied,
	 * otherwise returns false.
	 */
	getIsCompleted: function() {
		let result = this.callParent(arguments);
		if (result) {
			const rightExpression = this.rightExpression;
			result = result && Ext.isObject(rightExpression);
			if (rightExpression instanceof Terrasoft.ParameterExpression) {
				const parameter = rightExpression.parameter;
				const value = parameter.getValue();
				const isEmpty = value === null || value === undefined;
				result = result && isEmpty === false;
			}
		}
		return result;
	},

	/**
	 * Sets the filter expression {@link #rightExpression}.
	 * @param {Terrasoft.BaseExpression} expression Filter expression.
	 */
	setRightExpression: function(expression) {
		if (expression) {
			expression.parentFilter = this;
		}
		this.rightExpression = expression;
		this.fireEvent("rightExpressionChange", this, this);
	},

	/**
	 * @override
	 * @param filterMetaData
	 */
	updateLeftExpressionCaption: function(filterMetaData) {
		this.callParent(arguments);
		if (!this.subFilters || !filterMetaData.subFilters) {
			return;
		}
		this.updateCaptionForInnerCollection(this.subFilters, filterMetaData.subFilters.items);
	}

});
