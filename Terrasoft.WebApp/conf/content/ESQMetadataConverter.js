Terrasoft.configuration.Structures["ESQMetadataConverter"] = {innerHierarchyStack: ["ESQMetadataConverter"]};
 define("ESQMetadataConverter", [], function() {

	Ext.define("Terrasoft.configuration.ESQMetadataConverter", {
		extend: "Terrasoft.core.BaseObject",
		alternateClassName: "Terrasoft.ESQMetadataConverter",

		statics: {

			/**
			 * @param {Object} config
			 * @param {String} config.schemaName Entity schema name.
			 * @param {String} config.filterData Serialized esq filter group.
			 * @return {Object} Filters metadata.
			 */
			toAngularFilters: function (config) {
				const defaultFilterGroup = {
					className: "Terrasoft.FilterGroup",
					filterType: Terrasoft.FilterType.FILTER_GROUP,
					isEnabled: true,
					items: {},
					logicalOperation: Terrasoft.LogicalOperatorType.AND,
					rootSchemaName: config.schemaName,
				};
				const filter = Terrasoft.deserialize(config.filterData || defaultFilterGroup);
				const ignoredKeys = ["className", "key", "leftExpressionCaption"];
				const filterJson = {};
				filter.serializationInfo = { serializeFilterManagerInfo: true };
				filter.getSerializableObject(filterJson, {});
				let filterDataNormalized = JSON.stringify(filterJson);
				ignoredKeys.forEach(ignoredKey => {
					const regex = new RegExp(`"${ignoredKey}":"[^"]*",`, "g");
					filterDataNormalized = filterDataNormalized.replace(regex, ``);
				});
				const filterGroup = JSON.parse(filterDataNormalized);
				return filterGroup;
			},

			/**
			 * @param {Object} Angular filterGroup metadata.
			 * @return {Object} Ext filter group.
			 */
			toExtFilters: function(filterGroup) {
				this._addExtPropertiesToFilter(filterGroup);
				return filterGroup;
			},

			/**
			 * @param {Object} filter
			 * @private
			 */
			_addExtPropertiesToFilter: function(filter) {
				var filterItems = filter?.items;
				switch (filter?.filterType) {
					case Terrasoft.FilterType.BETWEEN:
						filter.className = `Terrasoft.BetweenFilter`;
						this._addExtPropertiesToExpression(filter.leftExpression);
						this._addExtPropertiesToExpression(filter.rightLessExpression);
						this._addExtPropertiesToExpression(filter.rightGreaterExpression);
						break;
					case Terrasoft.FilterType.COMPARE:
						filter.className = `Terrasoft.CompareFilter`;
						this._addExtPropertiesToExpression(filter.leftExpression);
						this._addExtPropertiesToExpression(filter.rightExpression);
						break;
					case Terrasoft.FilterType.EXISTS:
						filter.className = `Terrasoft.ExistsFilter`;
						this._addExtPropertiesToExpression(filter.leftExpression);
						this._addExtPropertiesToFilter(filter.subFilters);
						break;
					case Terrasoft.FilterType.FILTER_GROUP:
						filter.className = `Terrasoft.FilterGroup`;
						for (const [, innerFilter] of Object.entries(filterItems || {})) {
							this._addExtPropertiesToFilter(innerFilter);
						}
						break;
					case Terrasoft.FilterType.IN:
						filter.className = `Terrasoft.InFilter`;
						this._addExtPropertiesToExpression(filter.leftExpression);
						filter.rightExpressions
							.forEach(expression => this._addExtPropertiesToExpression(expression))
						break;
					case Terrasoft.FilterType.IS_NULL:
						filter.className = `Terrasoft.IsNullFilter`;
						this._addExtPropertiesToExpression(filter.leftExpression);
						break;
				}
			},

			/**
			 * @param {Terrasoft.BaseExpression} expression
			 * @private
			 */
			_addExtPropertiesToExpression: function(expression) {
				switch (expression?.expressionType) {
					case Terrasoft.ExpressionType.SCHEMA_COLUMN:
						expression.className = "Terrasoft.ColumnExpression";
						break;
					case Terrasoft.ExpressionType.PARAMETER:
						expression.className = "Terrasoft.ParameterExpression";
						if (expression.parameter) {
							expression.parameter.className = "Terrasoft.Parameter";
						}
						if (expression.parentFilter) {
							this._addExtPropertiesToFilter(expression.parentFilter);
						}
						break;
					case Terrasoft.ExpressionType.ARITHMETIC_OPERATION:
						expression.className = "Terrasoft.ArithmeticExpression";
						this._addExtPropertiesToExpression(expression.leftArithmeticOperand);
						this._addExtPropertiesToExpression(expression.rightArithmeticOperand);
						break;
					case Terrasoft.ExpressionType.FUNCTION:
						this._addExtFnPropertiesToExpression(expression);
						break;
					case Terrasoft.ExpressionType.SUBQUERY:
						if (expression.functionType === Terrasoft.FunctionType.AGGREGATION) {
							expression.className = "Terrasoft.AggregationQueryExpression";
						}
						if (expression.functionType === Terrasoft.FunctionType.NONE) {
							expression.className = "Terrasoft.SubQueryExpression";
						}
						if (expression.subFilters) {
							this._addExtPropertiesToFilter(expression.subFilters);
						}
						break;
				}
			},

			/**
			 * @param {Terrasoft.BaseExpression} expression
			 * @private
			 */
			_addExtFnPropertiesToExpression: function(expression) {
				switch (expression?.functionType) {
					case Terrasoft.FunctionType.DATE_ADD:
						expression.className = "Terrasoft.DateAddFunctionExpression";
						this._addExtPropertiesToExpression(expression?.numberExpression);
						this._addExtPropertiesToExpression(expression?.dateTimeExpression);
						break;
					case Terrasoft.FunctionType.DATE_DIFF:
						expression.className = "Terrasoft.DateDiffFunctionExpression";
						this._addExtPropertiesToExpression(expression?.startDateExpression);
						this._addExtPropertiesToExpression(expression?.endDateExpression);
						break;
					default:
						expression.className = "Terrasoft.FunctionExpression";
				}
				if (expression.functionArgument) {
					this._addExtPropertiesToExpression(expression.functionArgument);
				}
				if (expression.functionArguments) {
					expression.functionArguments
						.forEach(functionArgument => this._addExtPropertiesToExpression(functionArgument))
				}
			}
		},
	});
	return Terrasoft.ESQMetadataConverter;
});


