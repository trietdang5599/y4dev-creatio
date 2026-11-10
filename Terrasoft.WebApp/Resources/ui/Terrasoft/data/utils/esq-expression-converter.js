/**
 * @enum [Terrasoft.FormulaExpressionType]
 * Type of expression.
 */
Terrasoft.FormulaExpressionType = {
	/** The expression is of operator type. */
	OPERATOR: 0,
	/** The expression is of operand type. */
	OPERAND: 1,
	/**The expression is of function type. */
	FUNCTION: 2,
};

/**
 * @enum [Terrasoft.OperatorType]
 * Type of operator.
 */
Terrasoft.OperatorType = {
	/** The operator is of parentheses type. */
	PARENTHESES: 0,
	/** The operator is of arithmetic type. */
	ARITHMETIC: 1,
	/**The operator is of relational type. */
	RELATIONAL: 2,
	/**The operator is of ternary type. */
	TERNARY: 3,
};

/**
 * @enum [Terrasoft.OperandType]
 * Type of operand.
 */
Terrasoft.OperandType = {
	/** The operand is of const type. */
	CONST: 0,
	/** The operand is of column type. */
	COLUMN: 1,
	/**The operand is of system setting type. */
	SYSSETTING: 2,
	/**The operand is of system variable type. */
	SYSVARIABLE: 3,
};

/**
 * @enum [Terrasoft.ColumnOperandType]
 * Type of column operand.
 */
Terrasoft.ColumnOperandType = {
	/** The column operand is of shema column type. */
	SCHEMACOLUMN: 0,
	/** The operand is of subquery type. */
	SUBQUERY: 1,
	/**The operand is of aggregation type. */
	AGGREGATION: 2,
};

/**
  * The class that defines the esq expression converter.
 */
Ext.define("Terrasoft.data.EsqExpressionConverter", {
	alternateClassName: "Terrasoft.EsqExpressionConverter",
	extend: "Terrasoft.BaseObject",

	singleton: true,

	_datePartMapping: {
		'Y': Terrasoft.DatePartType.YEAR,
		'M': Terrasoft.DatePartType.MONTH,
		'W': Terrasoft.DatePartType.WEEK,
		'D': Terrasoft.DatePartType.DAY,
		'H': Terrasoft.DatePartType.HOUR,
		'DW': Terrasoft.DatePartType.WEEK_DAY
	},

	_dateDiffIntervalMapping: {
		'Y': Terrasoft.DateDiffInterval.YEAR,
		'M': Terrasoft.DateDiffInterval.MONTH,
		'D': Terrasoft.DateDiffInterval.DAY,
		'H': Terrasoft.DateDiffInterval.HOUR,
		'Mi': Terrasoft.DateDiffInterval.MINUTE,
	},

	_createQueryColumn: function(expression) {
		switch (expression.type) {
			case Terrasoft.FormulaExpressionType.OPERATOR:
				return this._createOperatorQueryColumn(expression);
			case Terrasoft.FormulaExpressionType.OPERAND:
				return this._createOperandQueryColumn(expression);
			case Terrasoft.FormulaExpressionType.FUNCTION:
				return this._createFunctionQueryColumn(expression);
			default:
				throw new Error(`The expression of type ${expression.type} is not supported.`);
		}
	},

	_createFunctionQueryColumn: function(expression) {
		const code = expression.code;
		switch (code) {
			case 'DATEADD': 
				return this._createDateAddFunctionQueryColumn(expression);
			case 'DATEDIFF': 
				return this._createDateDiffFunctionQueryColumn(expression);
			case 'DATEPART': 
				return this._createDatePartFunctionQueryColumn(expression);
			default: 
				throw new Error(`The function ${code} is not supported.`);
		}
	},

	_createDateAddFunctionQueryColumn: function(expression) {
		const args = expression.arguments;
		return Ext.create("Terrasoft.DateAddFunctionQueryColumn", {	
			dateTimeExpression: this._createExpression(args[0]),
			numberExpression: this._createExpression(args[1]),
			datePartType: this._datePartMapping[args[2].value],
		});
	},

	_createDateDiffFunctionQueryColumn: function(expression) {
		const args = expression.arguments;
		return Ext.create("Terrasoft.DateDiffFunctionQueryColumn", {
			startDateExpression: this._createExpression(args[0]),
			endDateExpression: this._createExpression(args[1]),
			dateDiffInterval: this._dateDiffIntervalMapping[args[2].value],
		});
	},

	_createDatePartFunctionQueryColumn: function(expression) {
		const args = expression.arguments;
		return Ext.create("Terrasoft.FunctionQueryColumn", {
			functionType: Terrasoft.FunctionType.DATE_PART,
			functionArgument: this._createExpression(args[0]),
			datePartType: this._datePartMapping[args[1].value],
		});
	},

	_createOperatorQueryColumn: function(expression) {
		switch (expression.operatorType) {
			case Terrasoft.OperatorType.PARENTHESES:
				return this._createParenthesesQueryColumn(expression);
			case Terrasoft.OperatorType.ARITHMETIC:
				return this._createArithmeticQueryColumn(expression);
			default:
				throw new Error(`The operator type ${expression.operatorType} is not supported.`);
		}
	},

	_createOperandQueryColumn: function(expression) {
		switch (expression.operandType) {
			case Terrasoft.OperandType.CONST:
				return this._createParameterQueryColumn(expression);
			case Terrasoft.OperandType.COLUMN:
				return this._createColumnOperandQueryColumn(expression);
			default:
				throw new Error(`The operand type ${expression.operandType} is not supported.`);
		}
	},

	_createParenthesesQueryColumn: function(expression) {
		const esqExpression = this._createExpression(expression.expression);
		esqExpression.isBlock = true;
		return Ext.create("Terrasoft.BaseQueryColumn", {
			expression: esqExpression,
		});
	},

	_createArithmeticQueryColumn: function(expression) {
		return Ext.create("Terrasoft.ArithmeticQueryColumn", {
			arithmeticOperation: expression.arithmeticOperatorType,
			leftArithmeticOperand: this._createExpression(expression.leftExpression),
			rightArithmeticOperand: this._createExpression(expression.rightExpression),
		});
	},

	_createParameterQueryColumn: function(expression) {
		return Ext.create("Terrasoft.ParameterQueryColumn", {
			parameterDataType: expression.dataType,
			parameterValue: expression.value,
		});
	},

	_createColumnOperandQueryColumn: function(expression) {
		switch (expression.columnOperandType) {
			case Terrasoft.ColumnOperandType.SCHEMACOLUMN:
				return this._createEntityQueryColumn(expression);
			case Terrasoft.ColumnOperandType.SUBQUERY:
				return this._createSubQueryColumn(expression);
			case Terrasoft.ColumnOperandType.AGGREGATION:
				return this._createAggregationQueryColumn(expression);
			default:
				throw new Error(`The column operand type ${expression.columnOperandType} is not supported.`);
		}
	},

	_createEntityQueryColumn: function(expression) {
		return Ext.create("Terrasoft.EntityQueryColumn", {
			columnPath: expression.columnPath,
		});
	},

	_createSubQueryColumn: function(expression) {
		return Ext.create("Terrasoft.SubQueryColumn", {
			columnPath: expression.columnPath,
			subFilters: this._getFilters(expression.subFilters)
		});
	},

	_createAggregationQueryColumn: function(expression) {
		return Ext.create("Terrasoft.AggregationQueryColumn", {
			columnPath: expression.columnPath,
			subFilters: this._getFilters(expression.subFilters),
			aggregationType: expression.aggregationType
		});
	},

	_createExpression: function(expression) {
		switch (expression.type) {
			case Terrasoft.FormulaExpressionType.OPERATOR:
				return this._createOperatorExpression(expression);
			case Terrasoft.FormulaExpressionType.OPERAND:
				return this._createOperandExpression(expression);
			case Terrasoft.FormulaExpressionType.FUNCTION:
				return this._createFunctionExpression(expression);
			default:
				throw new Error(`The expression of type ${expression.type} is not supported.`);
		}
	},

	_createFunctionExpression: function(expression) {
		const code = expression.code;
		switch (code) {
			case 'DATEADD': 
				return this._createDateAddFunctionExpression(expression);
			case 'DATEDIFF': 
				return this._createDateDiffFunctionExpression(expression);
			case 'DATEPART': 
				return this._createDatePartFunctionExpression(expression);
			default: 
				throw new Error(`The function ${code} is not supported.`);
		}
	},

	_createDateAddFunctionExpression: function(expression) {
		const args = expression.arguments;
		return Ext.create("Terrasoft.DateAddFunctionExpression", {				
			dateTimeExpression: this._createExpression(args[0]),
			numberExpression: this._createExpression(args[1]),
			datePartType: this._datePartMapping[args[2].value],
		});
	},

	_createDateDiffFunctionExpression: function(expression) {
		const args = expression.arguments;
		return Ext.create("Terrasoft.DateDiffFunctionExpression", {
			startDateExpression: this._createExpression(args[0]),
			endDateExpression: this._createExpression(args[1]),
			dateDiffInterval: this._dateDiffIntervalMapping[args[2].value],
		});
	},

	_createDatePartFunctionExpression: function(expression) {
		const args = expression.arguments;
		return Ext.create("Terrasoft.FunctionExpression", {
			functionType: Terrasoft.FunctionType.DATE_PART,
			functionArgument: this._createExpression(args[0]),
			datePartType: this._datePartMapping[args[1].value],
		});
	},

	_createOperatorExpression: function(expression) {
		switch (expression.operatorType) {
			case Terrasoft.OperatorType.PARENTHESES:
				return this._createParenthesesOperatorExpression(expression);
			case Terrasoft.OperatorType.ARITHMETIC:
				return this._createArithmeticOperatorExpression(expression);
			default:
				throw new Error(`The operator type ${expression.operatorType} is not supported.`);
		}
	},

	_createOperandExpression: function(expression) {
		switch (expression.operandType) {
			case Terrasoft.OperandType.CONST:
				return this._createParameterOperandExpression(expression);
			case Terrasoft.OperandType.COLUMN:
				return this._createColumnOperandExpression(expression);
			default:
				throw new Error(`The operand type ${expression.operandType} is not supported.`);
		}
	},

	_createParenthesesOperatorExpression: function(expression) {
		const esqExpression = this._createExpression(expression.expression);
		esqExpression.isBlock = true;
		return esqExpression;
	},

	_createArithmeticOperatorExpression: function(expression) {
		return Ext.create("Terrasoft.ArithmeticExpression", {
			arithmeticOperation: expression.arithmeticOperatorType,
			leftArithmeticOperand: this._createExpression(expression.leftExpression),
			rightArithmeticOperand: this._createExpression(expression.rightExpression),
		});
	},

	_createParameterOperandExpression: function(expression) {
		return Ext.create("Terrasoft.ParameterExpression", {
			parameterDataType: expression.dataType,
			parameterValue: expression.value,
		});
	},

	_createColumnOperandExpression: function(expression) {
		switch (expression.columnOperandType) {
			case Terrasoft.ColumnOperandType.SCHEMACOLUMN:
				return this._createSchemaColumnOperandExpression(expression);
			case Terrasoft.ColumnOperandType.SUBQUERY:
				return this._createSubQueryOperandExpression(expression);
			case Terrasoft.ColumnOperandType.AGGREGATION:
				return this._createAggregationSubQueryOperandExpression(expression);
			default:
				throw new Error(`The column operand type ${expression.columnOperandType} is not supported.`);
		}
	},

	_createSchemaColumnOperandExpression: function(expression) {
		return Ext.create("Terrasoft.ColumnExpression", {
			columnPath: expression.columnPath,
		});
	},

	_createSubQueryOperandExpression: function(expression) {
		return Ext.create("Terrasoft.SubQueryExpression", {
			columnPath: expression.columnPath,
			subFilters: this._getFilters(expression.subFilters)
		});
	},

	_createAggregationSubQueryOperandExpression: function(expression) {
		return Ext.create("Terrasoft.AggregationQueryExpression", {
			columnPath: expression.columnPath,
			subFilters: this._getFilters(expression.subFilters),
			aggregationType: expression.aggregationType
		});
	},

	_getFilters: function(filters) {
		return Ext.isString(filters) ? Terrasoft.deserialize(filters) : filters;
	},

	/**
	 * Creates the EQS column based on the incoming expression.
	 * @public
	 * @param {Object} expression Expression.
	 * @param {Object} config The additional column config.
	 * @param {String} config.caption The column caption.
	 * @return {Terrasoft.BaseQueryColumn} Created EsqColumn.
	 */
	createEsqColumn: function (expression, config) {
		const column =  this._createQueryColumn(expression);
		if(config) {
			column.caption = config.caption;
		}
		return column;
	},
});

