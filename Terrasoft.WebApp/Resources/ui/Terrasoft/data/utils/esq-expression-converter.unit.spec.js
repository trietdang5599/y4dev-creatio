describe("esq-expression-converter.unit.spec.js", function() {
	const testColumnPath = "Contact";
	const testFilterGroup = (function() {
		const filters = Ext.create("Terrasoft.FilterGroup");
		const isNotNullFilter = Terrasoft.createIsNotNullFilter(
			Ext.create("Terrasoft.ColumnExpression", {columnPath: "Account"})
		);
		filters.add(isNotNullFilter);
		return filters;
	})();
	const getFormulaExpressionTypeName = 
		(expressionType) => Object.getOwnPropertyNames(Terrasoft.FormulaExpressionType)[expressionType];
	let getRootTest;
	let expressionConverter;
	beforeEach(() =>
		expressionConverter = Terrasoft.EsqExpressionConverter
	);
	beforeAll(() => {
		getRootTest = window.getRootTest.bind(
			this,
			"esq-expression-converter.unit.spec.js"
		);
	});
	beforeAll(done =>
		require(["esq-expression-converter"], () => {
			done();
		})
	);
	describe("createEntitySchemaColumn", function() {
		describe("when expression is supported type", () => {
			const testCases = [
				{
					description: "when operand is of const type",
					expression: {
						type: Terrasoft.FormulaExpressionType.OPERAND,
						operandType: Terrasoft.OperandType.CONST,
						dataType: Terrasoft.DataValueType.INTEGER,
						value: 4
					},
					expectedEsqExpressionType: Terrasoft.ParameterExpression,
					expectedQueryColumnType: Terrasoft.ParameterQueryColumn,
					expectedEsqExpression: Ext.create("Terrasoft.ParameterExpression", {
						parameterDataType: Terrasoft.DataValueType.INTEGER,
						parameterValue: 4,
					})
				},
				{
					description: "when operand is of column type and column is of shema column type",
					expression: {
						type: Terrasoft.FormulaExpressionType.OPERAND,
						operandType: Terrasoft.OperandType.COLUMN,
						columnOperandType: Terrasoft.ColumnOperandType.SCHEMACOLUMN,
						columnPath: testColumnPath
					},
					expectedEsqExpressionType: Terrasoft.ColumnExpression,
					expectedQueryColumnType: Terrasoft.EntityQueryColumn,
					expectedEsqExpression: Ext.create("Terrasoft.ColumnExpression", {
						columnPath: testColumnPath,
					})
				},
				{
					description: "when operand is of column type and column is of sub query type",
					expression: {
						type: Terrasoft.FormulaExpressionType.OPERAND,
						operandType: Terrasoft.OperandType.COLUMN,
						columnOperandType: Terrasoft.ColumnOperandType.SUBQUERY,
						columnPath: testColumnPath,
						subFilters: testFilterGroup,
					},
					expectedEsqExpressionType: Terrasoft.SubQueryExpression,
					expectedQueryColumnType: Terrasoft.SubQueryColumn,
					expectedEsqExpression: Ext.create("Terrasoft.SubQueryExpression", {
						columnPath: testColumnPath,
						subFilters: testFilterGroup,
					})
				},
				{
					description: "when operand is of column type and column is of aggregation type",
					expression: {
						type: Terrasoft.FormulaExpressionType.OPERAND,
						operandType: Terrasoft.OperandType.COLUMN,
						columnOperandType: Terrasoft.ColumnOperandType.AGGREGATION,
						aggregationType: Terrasoft.AggregationType.COUNT,
						columnPath: testColumnPath,
						subFilters: testFilterGroup,
					},
					expectedEsqExpressionType: Terrasoft.AggregationQueryExpression,
					expectedQueryColumnType: Terrasoft.AggregationQueryColumn,
					expectedEsqExpression: Ext.create("Terrasoft.AggregationQueryExpression", {
						columnPath: testColumnPath,
						subFilters: testFilterGroup,
						aggregationType: Terrasoft.AggregationType.COUNT
					})
				},
				{
					description: "when operator is of parenthesse type",
					expression: {
						type: Terrasoft.FormulaExpressionType.OPERATOR,
						operatorType: Terrasoft.OperatorType.PARENTHESES,
						expression: {
							type: Terrasoft.FormulaExpressionType.OPERAND,
							operandType: Terrasoft.OperandType.CONST,
							dataType: Terrasoft.DataValueType.INTEGER,
							value: 4
						},
					},
					expectedEsqExpressionType: Terrasoft.ParameterExpression,
					expectedQueryColumnType: Terrasoft.BaseQueryColumn,
					expectedEsqExpression: (function() {
						const parameterExpression = Ext.create("Terrasoft.ParameterExpression", {
							parameterDataType: Terrasoft.DataValueType.INTEGER,
							parameterValue: 4,
						});
						parameterExpression.isBlock = true;
						return parameterExpression;
					  })(),
				},
				{
					description: "when operator is of arithmetic type",
					expression: {
						type: Terrasoft.FormulaExpressionType.OPERATOR,
						operatorType: Terrasoft.OperatorType.ARITHMETIC,
						arithmeticOperatorType: Terrasoft.ArithmeticOperation.ADDITION,
						leftExpression: {
							type: Terrasoft.FormulaExpressionType.OPERAND,
							operandType: Terrasoft.OperandType.CONST,
							dataType: Terrasoft.DataValueType.INTEGER,
							value: 2,
						},
						rightExpression: {
							type: Terrasoft.FormulaExpressionType.OPERAND,
							operandType: Terrasoft.OperandType.CONST,
							dataType: Terrasoft.DataValueType.INTEGER,
							value: 5,
						},
					},
					expectedEsqExpressionType: Terrasoft.ArithmeticExpression,
					expectedQueryColumnType: Terrasoft.ArithmeticQueryColumn,
					expectedEsqExpression: Ext.create("Terrasoft.ArithmeticExpression", {
						arithmeticOperation: Terrasoft.ArithmeticOperation.ADDITION,
						leftArithmeticOperand: Ext.create("Terrasoft.ParameterExpression", {
							parameterDataType: Terrasoft.DataValueType.INTEGER,
							parameterValue: 2,
						}),
						rightArithmeticOperand: Ext.create("Terrasoft.ParameterExpression", {
							parameterDataType: Terrasoft.DataValueType.INTEGER,
							parameterValue: 5,
						}),
					}),
				},
				{
					description: "when function is addDays",
					expression: {
						type: Terrasoft.FormulaExpressionType.FUNCTION,
						code: 'DATEADD',
						arguments: [
							{
								type: Terrasoft.FormulaExpressionType.OPERAND,
								operandType: Terrasoft.OperandType.COLUMN,
								columnOperandType: Terrasoft.ColumnOperandType.SCHEMACOLUMN,
								columnPath: testColumnPath
							},
							{
								type: Terrasoft.FormulaExpressionType.OPERAND,
								operandType: Terrasoft.OperandType.CONST,
								dataType: Terrasoft.DataValueType.INTEGER,
								value: 5,
							},
							{
								type: Terrasoft.FormulaExpressionType.OPERAND,
								operandType: Terrasoft.OperandType.CONST,
								dataType: Terrasoft.DataValueType.TEXT,
								value: 'M',
							},
						]
					},
					expectedEsqExpressionType: Terrasoft.DateAddFunctionExpression,
					expectedQueryColumnType: Terrasoft.DateAddFunctionQueryColumn,
					expectedEsqExpression: Ext.create("Terrasoft.DateAddFunctionExpression", {
						datePartType: Terrasoft.DatePartType.MONTH,
						dateTimeExpression: Ext.create("Terrasoft.ColumnExpression", {
							columnPath: testColumnPath,
						}), 
						numberExpression: Ext.create("Terrasoft.ParameterExpression", {
							parameterDataType: Terrasoft.DataValueType.INTEGER,
							parameterValue: 5,
						}),
					}),
				},
				{
					description: "when function is dateDiff",
					expression: {
						type: Terrasoft.FormulaExpressionType.FUNCTION,
						code: 'DATEDIFF',
						arguments: [
							{
								type: Terrasoft.FormulaExpressionType.OPERAND,
								operandType: Terrasoft.OperandType.COLUMN,
								columnOperandType: Terrasoft.ColumnOperandType.SCHEMACOLUMN,
								columnPath: testColumnPath
							},
							{
								type: Terrasoft.FormulaExpressionType.OPERAND,
								operandType: Terrasoft.OperandType.COLUMN,
								columnOperandType: Terrasoft.ColumnOperandType.SCHEMACOLUMN,
								columnPath: testColumnPath
							},
							{
								type: Terrasoft.FormulaExpressionType.OPERAND,
								operandType: Terrasoft.OperandType.CONST,
								dataType: Terrasoft.DataValueType.TEXT,
								value: 'M',
							},
						],
					},
					expectedEsqExpressionType: Terrasoft.DateDiffFunctionExpression,
					expectedQueryColumnType: Terrasoft.DateDiffFunctionQueryColumn,
					expectedEsqExpression: Ext.create("Terrasoft.DateDiffFunctionExpression", {				
						dateDiffInterval: Terrasoft.DateDiffInterval.MONTH,
						startDateExpression: Ext.create("Terrasoft.ColumnExpression", {
							columnPath: testColumnPath,
						}),
						endDateExpression: Ext.create("Terrasoft.ColumnExpression", {
							columnPath: testColumnPath,
						}),
					}),
				},
				{
					description: "when function is datePart",
					expression: {
						type: Terrasoft.FormulaExpressionType.FUNCTION,
						code: 'DATEPART',
						arguments: [
							{
								type: Terrasoft.FormulaExpressionType.OPERAND,
								operandType: Terrasoft.OperandType.COLUMN,
								columnOperandType: Terrasoft.ColumnOperandType.SCHEMACOLUMN,
								columnPath: testColumnPath
							},
							{
								type: Terrasoft.FormulaExpressionType.OPERAND,
								operandType: Terrasoft.OperandType.CONST,
								dataType: Terrasoft.DataValueType.TEXT,
								value: 'Y',
							},
						],
					},
					expectedEsqExpressionType: Terrasoft.FunctionExpression,
					expectedQueryColumnType: Terrasoft.FunctionQueryColumn,
					expectedEsqExpression: Ext.create("Terrasoft.FunctionExpression", {		
						functionType: Terrasoft.FunctionType.DATE_PART,
						datePartType: Terrasoft.DatePartType.YEAR,
						functionArgument: Ext.create("Terrasoft.ColumnExpression", {
							columnPath: testColumnPath,
						}),
					}),
				}
			];
			testCases.forEach(({ description, expression, expectedEsqExpressionType, expectedQueryColumnType,
					expectedEsqExpression }) => {
				const expressionTypeName = getFormulaExpressionTypeName(expression.type);
				describe(`when expression type is ${expressionTypeName}`, () => {
					describe(description, () => {
						it("should create query column of expected type", () => {
							const actualEsqColumn = expressionConverter.createEsqColumn(expression);
							expect(actualEsqColumn).toBeInstanceOf(expectedQueryColumnType);
						});
						it("should create expression of expected type", () => {
							const actualEsqColumn = expressionConverter.createEsqColumn(expression);
							const actualEsqExpression = actualEsqColumn.expression;
							expect(actualEsqExpression).toBeInstanceOf(expectedEsqExpressionType);
						});
						it("should create expected expression", () => {
							const actualEsqColumn = expressionConverter.createEsqColumn(expression);
							const actualEsqExpressionSerialized = actualEsqColumn.expression.serialize();
							const expectedEsqExpressionSerialized = expectedEsqExpression.serialize();
							expect(actualEsqExpressionSerialized).toBe(expectedEsqExpressionSerialized);
						});
					});
				})
			});
		});
		describe("when expression is of not supported type", () => {
			const testCases = [
				{
					expression: {
						type: Terrasoft.FormulaExpressionType.OPERATOR,
						operatorType: Terrasoft.OperatorType.RELATIONAL,
					},
				},
				{
					expression: {
						type: Terrasoft.FormulaExpressionType.OPERATOR,
						operatorType: Terrasoft.OperatorType.TERNARY,
					},
				},
				{
					expression: {
						type: Terrasoft.FormulaExpressionType.OPERAND,
						operandType: Terrasoft.OperandType.SYSSETTING,
					},
				},
				{
					expression: {
						type: Terrasoft.FormulaExpressionType.OPERAND,
						operandType: Terrasoft.OperandType.SYSVARIABLE,
					},
				},
				{
					expression: {
						type: "New formula expression type",
					},
				},
				{
					expression: {
						type: Terrasoft.FormulaExpressionType.OPERATOR,
						operatorType: "New operator type",
					},
				},
				{
					expression: {
						type: Terrasoft.FormulaExpressionType.OPERAND,
						operatorType: "New operand type",
					},
				},
			];
			testCases.forEach(({ expression }) => {
				const expressionTypeName = getFormulaExpressionTypeName(expression.type);
				describe(`when expression type is ${expressionTypeName}`, () => {
					it("should throw Exception with expected message", () => {
						expect(function() {
							expressionConverter.createEsqColumn();
						}).toThrow();
					});
				})
			});
		});
		describe("when additional column config is defined", () => {
			it("should set expected column caption", () => {
				const expression = {
					type: Terrasoft.FormulaExpressionType.OPERAND,
					operandType: Terrasoft.OperandType.CONST,
					dataType: Terrasoft.DataValueType.INTEGER,
					value: 4
				};
				const columnConfig = {
					caption: "COLUMN CAPTION"
				};
				const actualEsqColumn = expressionConverter.createEsqColumn(expression, columnConfig);
				expect(actualEsqColumn.caption).toBe(columnConfig.caption);
			});
		});
	});
});
