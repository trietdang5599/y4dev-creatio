define("FromMetaItemBR7xConverter", ["BusinessRuleModule"], function(BusinessRuleModule) {

	/**
	 * @class Terrasoft.configuration.FromMetaItemBR7xConverter
	 * FromMetaItemBR7xConverter class.
	 */
	Ext.define("Terrasoft.configuration.FromMetaItemBR7xConverter", {
		extend: "Terrasoft.BaseObject",
		alternateClassName: "Terrasoft.FromMetaItemBR7xConverter",

		// region Properties: Private

		/**
		 * Action type map.
		 * @private
		 * @type {Object}
		 */
		actionTypeMap: null,

		/**
		 * Expression type map.
		 * @private
		 * @type {Object}
		 */
		expressionTypeMap: null,

		/**
		 * Attribute actions.
		 * @private
		 * @type {Array}
		 */
		attributeActions: null,

		/**
		 * Entity schema.
		 * @private
		 * @type {Terrasoft.BaseEntitySchema}
		 */
		entitySchema: null,

		/**
		 * Page schema UId.
		 * @private
		 * @type {String}
		 */
		pageSchema: null,

		/**
		 * Page schema.
		 * @private
		 * @type {String}
		 */
		pageSchema: null,

		// endregion

		// region Methods: Private

		/**
		 * Checks object is of className type.
		 * @private
		 * @param {Object} object Object.
		 * @param {String} className Class name.
		 * @return {Boolean} If object is of type, returns true.
		 */
		isObjectOfClass: function(object, className) {
			return Terrasoft.isInstanceOfClass(object, "Terrasoft.manager." + className);
		},

		/**
		 * Checks object is of type from classNameMap.
		 * @private
		 * @param {Object} object Object.
		 * @param {Object} classNameMap Class name map.
		 * @return {Boolean} If object is of type, returns true.
		 */
		isObjectOfClasses: function(object, classNameMap) {
			var result = false;
			Terrasoft.each(classNameMap, function(value, key) {
				if (this.isObjectOfClass(object, Ext.isArray(classNameMap) ? value : key)) {
					result = true;
					return false;
				}
			}, this);
			return result;
		},

		/**
		 * Returns old enum type by object type.
		 * @private
		 * @param {Object} classNameMap Class name map.
		 * @param {Object} object Object.
		 * @return {Object} Old enum type.
		 */
		getEnumTypeByObject: function(classNameMap, object) {
			var fullClassName = Ext.getClassName(object);
			var className = fullClassName.split(".").pop();
			var result = this[classNameMap][className];
			if (!Ext.isEmpty(result)) {
				return result;
			} else {
				throw new Terrasoft.InvalidOperationException();
			}
		},

		/**
		 * @private
		 */
		_getEntitySchemaColumnPathByMetaPath: function(entitySchemaUId, metaPath, callback, scope) {
			var request = {
				getSchemaColumnInformation: {
					entitySchemaUId: entitySchemaUId,
					schemaColumnMetaPath: metaPath
				}
			};
			Terrasoft.SchemaDesignerUtilities.execute(request, function(response) {
				var schemaColumnInformation = response && response.getSchemaColumnInformationResponse;
				if (Ext.isEmpty(schemaColumnInformation)) {
					throw new Terrasoft.InvalidOperationException();
				}
				callback.call(scope, schemaColumnInformation.columnPath);
			}, this);
		},

		/**
		 * Returns entity schema column path by metaPath.
		 * @private
		 * @param {String} metaPath Entity schema column metaPath.
		 * @param {Function} callback Callback function.
		 * @param {Object} scope Callback function scope.
		 */
		getEntitySchemaColumnPathByMetaPath: function(metaPath, modelName, callback, scope) {
			const entitySchema = this.pageSchema
				? this._getEntitySchemaByDataModel(modelName)
				: this.entitySchema;
			const entitySchemaUId = entitySchema.uId;
			this._getEntitySchemaColumnPathByMetaPath(entitySchemaUId, metaPath, callback, scope);
		},

		/**
		 * Converts business rule column expression metaItem to old business rule expression config.
		 * @private
		 * @param {Terrasoft.ColumnBusinessRuleExpression} expression Business rule column expression metaItem.
		 * @param {Function} callback Callback function.
		 * @param {Object} scope Callback function scope.
		 */
		convertFromColumnExpressionMetaItem: function(expression, callback, scope) {
			const columnMetaPath = expression.columnMetaPath;
			if (!Terrasoft.contains(columnMetaPath, ".")) {
				callback.call(scope, {attribute: columnMetaPath});
				return;
			}
			throw new Error('Not implemented method "convertFromColumnExpressionMetaItem" where columnMetaPath contains "."');
		},

		/**
		 * Converts business rule expression metaItem to old business rule expression config.
		 * @private
		 * @param {Terrasoft.BaseBusinessRuleExpression} expression Business rule expression metaItem.
		 * @param {Function} callback Callback function.
		 * @param {Object} scope Callback function scope.
		 */
		convertFromExpressionMetaItem: function(expression, callback, scope) {
			if (!expression) {
				return callback.call(scope, null);
			}
			var enumType = this.getEnumTypeByObject("expressionTypeMap", expression);
			var convertedExpression = {type: enumType, uId: expression.uId};
			Terrasoft.chain(
				function(next) {
					switch (enumType) {
						case BusinessRuleModule.enums.ValueType.CONSTANT:
							convertedExpression.value = expression.value;
							convertedExpression.dataValueType = expression.dataValueType;
							if (convertedExpression.dataValueType === Terrasoft.DataValueType.LOOKUP) {
								convertedExpression.referenceSchemaName = expression.referenceSchemaName;
							}
							next();
							break;
						case BusinessRuleModule.enums.ValueType.SYSVALUE:
							convertedExpression.value = expression.sysValueType;
							convertedExpression.dataValueType = expression.dataValueType;
							next();
							break;
						case BusinessRuleModule.enums.ValueType.SYSSETTING:
							convertedExpression.value = expression.sysSettingCode;
							convertedExpression.dataValueType = expression.dataValueType;
							next();
							break;
						case BusinessRuleModule.enums.ValueType.ATTRIBUTE:
							if (this.isObjectOfClass(expression, "AttributeBusinessRuleExpression")) {
								convertedExpression.attribute = expression.attributeName;
								convertedExpression.dataValueType = expression.dataValueType;
								next();
							}
							if (this.isObjectOfClass(expression, "ColumnBusinessRuleExpression")) {
								convertedExpression.attribute = expression.columnMetaPath;
								convertedExpression.scopeId = expression.dataModelName;
								convertedExpression.dataValueType = expression.dataValueType;
								next();
							}
							break;
						case BusinessRuleModule.enums.ValueType.FORMULA:
							convertedExpression.formula = expression.formula;
							next();
							break;
						default:
							throw new Terrasoft.UnsupportedTypeException();
					}
				},
				function() {
					callback.call(scope, convertedExpression);
				},
				this
			);
		},

		/**
		 * Converts business rule comparison condition metaItem to old business rule condition config.
		 * @private
		 * @param {Terrasoft.BusinessRuleConditionGroup} condition Business rule comparison condition metaItem.
		 * @param {Function} callback Callback function.
		 * @param {Object} scope Callback function scope.
		 */
		convertFromComparisonConditionMetaItem: function(condition, callback, scope) {
			var convertedCondition = {comparisonType: condition.comparisonType, uId: condition.uId};
			Terrasoft.chain(
				function(next) {
					this.convertFromExpressionMetaItem(condition.leftExpression, function(convertedExpression) {
						convertedCondition.leftExpression = convertedExpression;
						next();
					}, this);
				},
				function(next) {
					if (!Ext.isEmpty(condition.rightExpression)) {
						this.convertFromExpressionMetaItem(condition.rightExpression, function(convertedExpression) {
							convertedCondition.rightExpression = convertedExpression;
							next();
						}, this);
					} else {
						next();
					}
				},
				function() {
					callback.call(scope, convertedCondition);
				},
				this
			);
		},

		/**
		 * Converts business rule condition group metaItem to old business rule condition config.
		 * @private
		 * @param {Terrasoft.BusinessRuleConditionGroup} conditionGroup Business rule condition group metaItem.
		 * @param {Function} callback Callback function.
		 * @param {Object} scope Callback function scope.
		 */
		convertFromConditionGroupMetaItem: function(conditionGroup, callback, scope) {
			var items = [];
			var functions = conditionGroup.items.map(function(condition) {
				return function(next) {
					this.convertFromComparisonConditionMetaItem(condition, function(result) {
						items.push(result);
						next();
					}, this);
				};
			}, this);
			functions.push(function() {
				callback.call(scope, {
					logical: conditionGroup.operationType || Terrasoft.LogicalOperatorType.AND,
					conditions: items,
					uId: conditionGroup.uId
				});
			});
			Terrasoft.chain.apply(this, functions);
		},

		/**
		 * Validates business rule case metaItem.
		 * @private
		 * @param {Terrasoft.BusinessRuleCase} ruleCase Business rule case metaItem.
		 * @return {Boolean} If metaItem is valid, returns true.
		 */
		isRuleCaseMetaItem: function(ruleCase) {
			return this.isObjectOfClass(ruleCase, "BusinessRuleCase") && Ext.isObject(ruleCase.condition);
		},

		/**
		 * Validates business rule switch metaItem.
		 * @private
		 * @param {Terrasoft.BusinessRuleSwitch} ruleSwitch Business rule switch metaItem.
		 * @return {Boolean} If metaItem is valid, returns true.
		 */
		isRuleSwitchMetaItem: function(ruleSwitch) {
			return this.isObjectOfClass(ruleSwitch, "BusinessRuleSwitch") &&
				Ext.isArray(ruleSwitch.cases) &&
				ruleSwitch.cases.length === 1 &&
				this.isRuleCaseMetaItem(ruleSwitch.cases[0]);
		},

		/**
		 * Validates business rule schema.
		 * @private
		 * @param {Terrasoft.BusinessRuleSchema} rule Business rule schema.
		 * @return {Boolean} If schema is valid, returns true.
		 */
		isRuleSchema: function(rule) {
			return this.isObjectOfClass(rule, "BusinessRuleSchema") && this.isRuleSwitchMetaItem(rule.ruleSwitch);
		},

		/**
		 * Converts business rule schema to old business rule config.
		 * @private
		 * @param {Terrasoft.BusinessRuleSchema} rule Business rule schema.
		 * @param {Function} callback Callback function.
		 * @param {Object} scope Callback function scope.
		 */
		convertFromRuleSchema: function(rule, callback, scope) {
			if (!this.isRuleSchema(rule)) {
				throw new Terrasoft.UnsupportedTypeException();
			}
			this.convertFromConditionGroupMetaItem(rule.ruleSwitch.cases[0].condition, function(condition) {
				callback.call(scope, condition);
			}, this);
		},

		// endregion

		// region Methods: Public

		/**
		 * Converts metaItems to old business rule config.
		 * @param {Terrasoft.BusinessRuleSchema} rule Rule.
		 * @param {Function} callback Callback function.
		 * @param {Object} scope Callback function scope.
		 */
		convertFromMetaItems: function(rule, callback, scope) {
			this.convertFromRuleSchema(rule, callback, scope);
		}

		// endregion

	});
	return Terrasoft.FromMetaItemBR7xConverter;
});
