define("BusinessRuleFilterActionConditionDesignerViewModel",
	["BusinessRuleFilterActionConditionDesignerViewModelResources", "BusinessRuleConditionDesignerViewModel",
	"ExpressionEnums", "css!BusinessRuleFilterActionConditionDesignerViewModel"], function(resources) {

	/**
	 * @class Terrasoft.Designers.BusinessRuleFilterActionConditionDesignerViewModel
	 */
	Ext.define("Terrasoft.Designers.BusinessRuleFilterActionConditionDesignerViewModel", {
		extend: "Terrasoft.BusinessRuleConditionDesignerViewModel",
		alternateClassName: "Terrasoft.BusinessRuleFilterActionConditionDesignerViewModel",

		// region Methods: Protected

		/**
		 * @inheritdoc Terrasoft.BusinessRuleConditionDesignerViewModel#getExpressionsConfig
		 * @overridden
		 */
		getExpressionsConfig: function(metaItem) {
			const config = this.callParent(arguments);
			config.autoComplete = metaItem.rightExpression.autocomplete
			config.autoClean = metaItem.leftExpression.autoClean
			return config;
		},

		/**
		 * @inheritdoc Terrasoft.BusinessRuleConditionDesignerViewModel#setPreparedPropertiesIntoViewModel
		 * @overridden
		 */
		setPreparedPropertiesIntoViewModel: function(config) {
			this.callParent(arguments);
			this.set("AutoComplete", config.autoComplete);
			this.set("AutoClean", config.autoClean);
		},

		getIsAutoCleanOrAutoCompleteVisible: function() {
			const leftExpression = this.$LeftExpressionValue
			const rightExpression = this.$RightExpressionValue
			const leftExpressionType = this.$LeftExpressionType;
			const rightExpressionType = this.$RightExpressionType;
			if (!leftExpression || !rightExpression) {
				return false;
			}
			const rightExpressionValue = rightExpression.value || "";
			const rightExpressionValueMetapthLength = rightExpressionValue.split(".").length;
			if (rightExpressionValueMetapthLength !== 1) {
				return false;
			}
			return leftExpressionType === Terrasoft.ExpressionEnums.ExpressionType.COLUMN &&
				rightExpressionType === Terrasoft.ExpressionEnums.ExpressionType.COLUMN;
		},

		getLeftExpressionAdditionalCheckboxCaption: function() {
			const rightExpression = this.$RightExpressionValue;
			const dataModelName = this.$RightExpressionDataModelName;
			if (!rightExpression || !dataModelName) {
				return "";
			}
			const entitySchema = Terrasoft.BusinessRuleSchemaManager.getEntitySchemaByDataModel(dataModelName,
				this.pageSchemaUId);
			const columnUId = rightExpression.value.split(".")[0];
			const column = entitySchema.findColumnByUId(columnUId);
			if (!column) {
				return "";
			}
			return Terrasoft.getFormattedString(resources.localizableStrings.AutoCleanCaption, column.caption);
		},

		getRightExpressionAdditionalCheckboxCaption: function() {
			const leftExpression = this.$LeftExpressionValue;
			const dataModelName = this.$LeftExpressionDataModelName;
			if (!leftExpression || !dataModelName) {
				return "";
			}
			const entitySchema = Terrasoft.BusinessRuleSchemaManager.getEntitySchemaByDataModel(dataModelName,
				this.pageSchemaUId);
			const columnUId = leftExpression.value.split(".")[0];
			const column = entitySchema.findColumnByUId(columnUId);
			if (!column) {
				return "";
			}
			return Terrasoft.getFormattedString(resources.localizableStrings.AutoCompleteCaption, column.caption);
		},

		/**
		 * @inheritdoc Terrasoft.BusinessRuleConditionDesignerViewModel#createLeftExpressionMetaItem
		 * @overridden
		 */
		createLeftExpressionMetaItem: function() {
			const leftExpression = this.callParent(arguments);
			leftExpression.setPropertyValue("autoClean", this.get("AutoClean"));
			return leftExpression;
		},

		/**
		 * @inheritdoc Terrasoft.BusinessRuleConditionDesignerViewModel#createRightExpressionMetaItem
		 * @overridden
		 */
		createRightExpressionMetaItem: function() {
			const rightExpression = this.callParent(arguments);
			if (rightExpression) {
				rightExpression.setPropertyValue("autocomplete", this.get("AutoComplete"));
			}
			return rightExpression;
		},

		/**
		 * @inheritdoc Terrasoft.BusinessRuleConditionDesignerViewModel#getAvailableComparisonTypeNames
		 * @overridden
		 */
		getAvailableComparisonTypeNames: function() {
			return ["EQUAL", "NOT_EQUAL", "GREATER", "GREATER_OR_EQUAL", "LESS", "LESS_OR_EQUAL"];
		},

		/**
		 * @inheritdoc Terrasoft.BusinessRuleConditionDesignerViewModel#getViewConfig
		 * @overridden
		 */
		getViewConfig: function() {
			var config = this.callParent(arguments);
			var classes = config.classes = (config.classes || {});
			var wrapClassName = classes.wrapClassName = (classes.wrapClassName || []);
			wrapClassName.push("business-rules-filter-action-condition");
			return config;
		},

		/**
		 * Left expression sync validator
		 * @protected
		 * @param {Mixed} value Left expression value.
		 * @return {Object} Validation info.
		 */
		validateLeftExpressionValue: function(value) {
			return this.validateColumnPathCodeSymbolValue(value && value.name, {
				"minPartCount": 2,
				"invalidMessage": resources.localizableStrings.InvalidLeftExpressionFormatMessage
			});
		},

		/**
		 * @inheritdoc Terrasoft.BusinessRuleConditionDesignerViewModel#onLeftExpressionTypeChanged
		 * @overridden
		 */
		onLeftExpressionTypeChanged: function(model, expressionType) {
			if (expressionType === Terrasoft.ExpressionEnums.ExpressionType.PARAMETER) {
				this.loadLeftExpressionEntitySchemaColumnVocabulary();
			}
			this.callParent(arguments);
		},

		/**
		 * @inheritdoc Terrasoft.BusinessRuleConditionDesignerViewModel#getAsyncValidateLeftExpressionConfig
		 * @overridden
		 */
		getAsyncValidateLeftExpressionConfig: function() {
			var config = this.callParent(arguments);
			return Ext.apply(config, {
				"columnCaption": this.get("DefaultExpressionCaption"),
				"minPartCount": 2,
				"invalidFormatMessage": resources.localizableStrings.InvalidLeftExpressionFormatMessage
			});
		},

		/**
		 * @inheritdoc Terrasoft.BusinessRuleConditionDesignerViewModel#getAsyncValidateRightExpressionConfig
		 * @overridden
		 */
		getAsyncValidateRightExpressionConfig: function() {
			var config = this.callParent(arguments);
			return Ext.apply(config, {
				"autocomplete": this.get("AutoComplete"),
				"autoClean": this.get("AutoClean"),
				"columnCaption": this.get("DefaultExpressionCaption"),
				"maxPartCount": 1
			});
		},

		/**
		 * @inheritdoc Terrasoft.BusinessRuleConditionDesignerViewModel#getLeftExpressionControlConfig
		 * @overridden
		 */
		getLeftExpressionControlConfig: function() {
			const config = this.callParent(arguments);
			return Ext.apply(config, {
				"placeholder": resources.localizableStrings.LeftExpressionPlaceholder,
				"typeVisible": !this.isEntitySchemaBased(),
				"showAdditionalCheckbox": {"bindTo": "getIsAutoCleanOrAutoCompleteVisible"},
				"additionalCheckboxValue": {"bindTo": "AutoClean"},
				"additionalCheckboxCaption": {"bindTo": "getLeftExpressionAdditionalCheckboxCaption"},
				"wrapClass": "filter-left-expression",
				"contentType": Terrasoft.ContentType.LOOKUP
			});
		},

		/**
		 * @inheritdoc Terrasoft.BusinessRuleConditionDesignerViewModel#getRightExpressionControlConfig
		 * @overridden
		 */
		getRightExpressionControlConfig: function() {
			var config = this.callParent(arguments);
			return Ext.apply(config, {
				"placeholder": resources.localizableStrings.RightExpressionPlaceholder,
				"showAdditionalCheckbox": {"bindTo": "getIsAutoCleanOrAutoCompleteVisible"},
				"additionalCheckboxValue": {"bindTo": "AutoComplete"},
				"additionalCheckboxCaption": {"bindTo": "getRightExpressionAdditionalCheckboxCaption"},
				"wrapClass": "filter-right-expression"
			});
		},

		/**
		 * @inheritdoc Terrasoft.BusinessRuleConditionDesignerViewModel#getLeftExpressionTypeList
		 * @overridden
		 */
		getLeftExpressionTypeList: function() {
			const Type = Terrasoft.ExpressionEnums.ExpressionType;
			const types = [];
			if (this.isEntitySchemaBased()) {
				types.push(Type.COLUMN);
			} else {
				types.push(Type.PARAMETER);
				const dataSource = Terrasoft.BusinessRuleSchemaManager.getDataSourcesConfig(this.pageSchemaUId);
				if (!Terrasoft.isEmptyObject(dataSource)) {
					types.push(Type.DATASOURCE);
				}
			}
			return types;
		},

		// endregion

		// region Methods: Public

		/**
		 * @inheritdoc Terrasoft.BaseObject#constructor
		 * @overridden
		 */
		constructor: function() {
			this.callParent(arguments);
			this.validationConfig.LeftExpressionValue = [this.validateLeftExpressionValue];
		},

		/**
		 * @inheritdoc Terrasoft.BaseModel#getModelColumns
		 * @override
		 */
		getModelColumns: function() {
			const columns = this.callParent(arguments);
			columns.AutoComplete = {
				type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				dataValueType: Terrasoft.DataValueType.BOOLEAN,
				value: false
			};
			columns.AutoClean = {
				type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				dataValueType: Terrasoft.DataValueType.BOOLEAN,
				value: false
			};
			return columns;
		},

		// endregion

	});
	return Terrasoft.BusinessRuleFilterActionConditionDesignerViewModel;
});
