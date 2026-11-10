define("ExpressionEnums", [], function() {

	Ext.ns("Terrasoft.ExpressionEnums");

	/**
	 * Expression type.
	 * @enum [Terrasoft.ExpressionEnums.ExpressionType]
	 */
	Terrasoft.ExpressionEnums.ExpressionType = {
		CONSTANT: "ConstantBusinessRuleExpression",
		ATTRIBUTE: "AttributeBusinessRuleExpression",
		SYSSETTING: "SysSettingBusinessRuleExpression",
		SYSVALUE: "SysValueBusinessRuleExpression",
		COLUMN: "ColumnBusinessRuleExpression",
		PARAMETER: "ParameterBusinessRuleExpression",
		DATASOURCE: "DataSourceBusinessRuleExpression",
		DETAIL: "DetailBusinessRuleExpression",
		MODULE: "ModuleBusinessRuleExpression",
		GROUP: "GroupBusinessRuleExpression",
		TAB: "TabBusinessRuleExpression",
		FORMULA: "FormulaBusinessRuleExpression"
	};

});
