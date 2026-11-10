Terrasoft.configuration.Structures["ToMetaItemBR7xConverter"] = {innerHierarchyStack: ["ToMetaItemBR7xConverter"]};
define("ToMetaItemBR7xConverter", ["BusinessRuleModule", "ExpressionEnums"], function(BusinessRuleModule) {

	Ext.define("Terrasoft.configuration.ToMetaItemBR7xConverter", {
		extend: "Terrasoft.BaseObject",
		alternateClassName: "Terrasoft.ToMetaItemBR7xConverter",

		/**
		 * Expression type map.
		 * @private
		 * @type {Object}
		 */
		expressionTypeMap: null,

		/**
		 * Entity schema.
		 * @private
		 * @type {Terrasoft.BaseEntitySchema}
		 */
		entitySchema: null,

		/**
		 * Page schema.
		 * @private
		 * @type {String}
		 */
		pageSchema: null,

		// region Methods: Private

		/**
		 * Returns exception message with argument name.
		 * @private
		 * @param {String} argumentName Argument name.
		 * @return {String} Exception message.
		 */
		getArgumentNullOrEmptyExceptionMessage: function(argumentName) {
			var mask = (!Ext.isEmpty(argumentName))
				? Terrasoft.Resources.Exception.ArgumentNullOrEmptyExceptionWithArgumentName
				: Terrasoft.Resources.Exception.ArgumentNullOrEmptyException;
			return Ext.String.format(mask, argumentName);
		},

		/**
		 * Returns data value type of system setting.
		 * @private
		 * @param {String} sysSettingCode System setting code.
		 * @param {Function} callback Callback function.
		 * @param {Object} scope Callback function scope.
		 */
		getSysSettingDataValueType: function(sysSettingCode, callback, scope) {
			var request = {sysSettingsNameCollection: [sysSettingCode]};
			Terrasoft.ServiceProvider.executeRequest("QuerySysSettings", request, function(response) {
				var sysSetting = response.values[sysSettingCode];
				callback.call(scope, sysSetting && sysSetting.dataValueType);
			}, this);
		},

		/**
		 * Returns data value type of system value.
		 * @private
		 * @param {Terrasoft.SystemValueType} sysValueType System value type.
		 * @return {String|Null} Data value type.
		 */
		findSysValueDataValueType: function(sysValueType) {
			var pairs = [{
				dataValueType: Terrasoft.DataValueType.TIME,
				sysValueTypes: [Terrasoft.SystemValueType.CURRENT_TIME]
			}, {
				dataValueType: Terrasoft.DataValueType.DATE,
				sysValueTypes: [Terrasoft.SystemValueType.CURRENT_DATE]
			}, {
				dataValueType: Terrasoft.DataValueType.DATE_TIME,
				sysValueTypes: [Terrasoft.SystemValueType.CURRENT_DATE_TIME]
			}, {
				dataValueType: Terrasoft.DataValueType.LOOKUP,
				sysValueTypes: [
					Terrasoft.SystemValueType.CURRENT_USER,
					Terrasoft.SystemValueType.CURRENT_USER_CONTACT,
					Terrasoft.SystemValueType.CURRENT_USER_ACCOUNT
				]
			}, {
				dataValueType: Terrasoft.DataValueType.OBJECT_LIST,
				sysValueTypes: [
					Terrasoft.SystemValueType.CURRENT_USER_ROLES
				]
			}];
			for (var i = 0; i < pairs.length; i++) {
				if (Terrasoft.contains(pairs[i].sysValueTypes, sysValueType)) {
					return pairs[i].dataValueType;
				}
			}
			return null;
		},

		/**
		 * @private
		 */
		_getEntitySchemaColumnInformationByPath: function(entitySchemaUId, path, callback, errorback, scope) {
			var request = {
				getSchemaColumnInformation: {
					entitySchemaUId: entitySchemaUId,
					schemaColumnPath: path
				}
			};
			Terrasoft.SchemaDesignerUtilities.execute(request, function(response) {
				var schemaColumnInformation = response && response.getSchemaColumnInformationResponse;
				if (Ext.isEmpty(schemaColumnInformation)) {
					errorback.call(scope, Terrasoft.Resources.Exception.InvalidOperationException);
				} else {
					callback.call(scope, {
						columnMetaPath: schemaColumnInformation.columnMetaPath,
						dataValueType: Terrasoft.ServerDataValueType[schemaColumnInformation.columnDataValueTypeUId]
					});
				}
			}, this);
		},

		/**
		 * @private
		 */
		_getPageSchemaDataSourceByName: function(dataSourceName) {
			return this.pageSchema.dataSources?.find(item => item.name === dataSourceName);
		},

		/**
		 * Returns if entity schema column exist.
		 * @private
		 * @param {String} attributeName Attribute name.
		 * @return {Boolean} If column exist.
		 */
		isEntitySchemaColumnExists: function(attributeName) {
			const entitySchemaColumn = this._findEntitySchemaColumnByAttribute(attributeName);
			return Boolean(entitySchemaColumn);
		},

		/**
		 * Returns entity schema column.
		 * @private
		 * @param {String} attributeName Attribute name.
		 * @return {String} Entity schema column.
		 */
		getEntitySchemaColumn: function(attributeName) {
			const entitySchemaColumn = this._findEntitySchemaColumnByAttribute(attributeName);
			if (Ext.isEmpty(entitySchemaColumn)) {
				throw new Terrasoft.ItemNotFoundException();
			}
			return entitySchemaColumn;
		},

		/**
		 * Returns entity schema column UId.
		 * @private
		 * @param {String} attributeName Attribute name.
		 * @return {String} Entity schema column UId.
		 */
		getEntitySchemaColumnUId: function(attributeName) {
			var entitySchemaColumn = this.getEntitySchemaColumn(attributeName);
			return entitySchemaColumn.uId;
		},

		/**
		 * Returns entity schema column data value type.
		 * @private
		 * @param {String} attributeName Attribute name.
		 * @return {Number} Entity schema column data value type.
		 */
		getEntitySchemaColumnDataValueType: function(attributeName) {
			var entitySchemaColumn = this.getEntitySchemaColumn(attributeName);
			return entitySchemaColumn.dataValueType;
		},

		/**
		 * Converts old business rule enum type to new enum type.
		 * @private
		 * @param {String} mapName Conversion map name.
		 * @param {Object} oldEnumValue Old enum value.
		 * @return {String[]} New enum values.
		 */
		convertToMetaItemEnumType: function(mapName, oldEnumValue) {
			var result = [];
			Terrasoft.each(this[mapName], function(oldValue, newValue) {
				if (oldValue === oldEnumValue) {
					result.push(newValue);
				}
			}, this);
			return !Ext.isEmpty(result) ? result : null;
		},

		/**
		 * Converts old business rule enum type to expression enum type.
		 * @private
		 * @param {Object} expression Old expression.
		 * @return {String} New expression type.
		 */
		convertToExpressionEnumType: function(expression) {
			var expressionTypes = this.convertToMetaItemEnumType("expressionTypeMap", expression && expression.type);
			if (!expressionTypes) {
				return null;
			}
			if (expressionTypes.length === 1) {
				return expressionTypes[0];
			}
			var expressionType = Terrasoft.ExpressionEnums.ExpressionType;
			var hasExpressions = Terrasoft.contains(expressionTypes, expressionType.COLUMN) &&
				Terrasoft.contains(expressionTypes, expressionType.ATTRIBUTE);
			if (hasExpressions) {
				const dataSourceName = expression.scopeId;
				const dataSource = this._getPageSchemaDataSourceByName(dataSourceName);
				if (dataSource) {
					return expressionType.COLUMN;
				}
				const attributeName = expression.attribute;
				const attribute = this.pageSchema.attributes.find(item => item.value === attributeName);
				if (attribute) {
					return expressionType.ATTRIBUTE;
				}
				return expression.filterLeftExpression
					? expressionType.PARAMETER
					: expressionType.ATTRIBUTE;
			}
			return null;
		},

		/**
		 * @private
		 */
		_convertToPopulateAttributeActionMetaItem: function(config, callback, errorback, scope) {
			const actionColumnName = config.actionColumnName;
			const populatedAttributeSource = config.populatedAttributeSource;
			let leftExpression;
			let rightExpression;
			Terrasoft.chain(
				function(next) {
					const oldLeftExpressionConfig = {
						type: BusinessRuleModule.enums.ValueType.ATTRIBUTE,
						attribute: actionColumnName,
						filterLeftExpression: true
					};
					this.convertToExpressionMetaItem(oldLeftExpressionConfig, function(expression) {
						leftExpression = expression;
						next();
					}, errorback, this);
				},
				function(next) {
					if (!populatedAttributeSource || !populatedAttributeSource.expression) {
						errorback.call(scope, "populatedAttributeSource property is not completed");
					}
					this.convertToExpressionMetaItem(populatedAttributeSource.expression, function(expression) {
						rightExpression = expression;
						next();
					}, errorback, this);
				},
				function() {
					callback.call(scope, {
						type: "PopulateBusinessRuleAction",
						leftExpression: leftExpression,
						rightExpression: rightExpression
					});
				},
				this
			);
		},

		/**
		 * Converts old business rule expression config to system value expression metaItem config.
		 * @private
		 * @param {Object} expression Old business rule expression config.
		 * @param {Function} callback Callback function.
		 * @param {Function} errorback Errorback function.
		 * @param {Object} scope Callback function scope.
		 */
		convertToSysValueExpressionMetaItem: function(expression, callback, errorback, scope) {
			if (expression.value === Terrasoft.SystemValueType.CURRENT_MAINTAINER) {
				callback.call(scope, {
					type: Terrasoft.ExpressionEnums.ExpressionType.SYSSETTING,
					dataValueType: Terrasoft.DataValueType.TEXT,
					sysSettingCode: "Maintainer"
				});
			} else {
				var dataValueType = this.findSysValueDataValueType(expression.value);
				if (dataValueType !== null) {
					callback.call(scope, {
						dataValueType: dataValueType,
						sysValueType: expression.value
					});
				} else {
					errorback.call(scope, "Unsupported system value type");
				}
			}
		},

		/**
		 * Converts old business rule expression config to system setting expression metaItem config.
		 * @private
		 * @param {Object} expression Old business rule expression config.
		 * @param {Function} callback Callback function.
		 * @param {Function} errorback Errorback function.
		 * @param {Object} scope Callback function scope.
		 */
		convertToSysSettingExpressionMetaItem: function(expression, callback, errorback, scope) {
			this.getSysSettingDataValueType(expression.value, function(dataValueType) {
				if (Terrasoft.contains(Terrasoft.DataValueType, dataValueType)) {
					callback.call(scope, {
						dataValueType: dataValueType,
						sysSettingCode: expression.value
					});
				} else {
					callback.call(scope, {
						dataValueType: null,
						sysSettingCode: expression.value
					});
				}
			}, this);
		},

		/**
		 * Converts old business rule expression config to attribute expression metaItem config.
		 * @private
		 * @param {Object} expression Old business rule expression config.
		 * @param {Function} callback Callback function.
		 * @param {Function} errorback Errorback function.
		 * @param {Object} scope Callback function scope.
		 */
		convertToAttributeExpressionMetaItem: function(expression, callback, errorback, scope) {
			const attributes = this.pageSchema?.attributes;
			const attribute = attributes?.find((x) => x.value === expression.attribute);
			const attributeExpression = {
				type: "AttributeBusinessRuleExpression",
				attributeName: expression.attribute,
				dataValueType: attribute?.dataValueType,
			};
			callback.call(scope, attributeExpression);
		},

		/**
		 * @private
		 */
		_convertToFormulaExpressionMetaItem: function(expression, callback, errorback, scope) {
			Ext.callback(callback, scope, [{formula: expression.formula}]);
		},

		/**
		 * Converts old business rule expression config to column expression metaItem config.
		 * @private
		 * @param {Object} expression Old business rule expression config.
		 * @param {Function} callback Callback function.
		 * @param {Function} errorback Errorback function.
		 * @param {Object} scope Callback function scope.
		 */
		convertToColumnExpressionMetaItem: function(expression, callback, errorback, scope) {
			const dataSourceName = expression?.scopeId;
			const dataSource = this._getPageSchemaDataSourceByName(dataSourceName);
			const attributeName = expression?.attribute;
			const columns = dataSource?.attributes;
			const column = columns?.find((col) => col.value === attributeName);
			const columnExpression = {
				type: "ColumnBusinessRuleExpression",
				columnMetaPath: attributeName,
				dataModelName: dataSourceName,
				dataValueType: column?.dataValueType,
			};
			callback.call(scope, columnExpression);
		},

		/**
		 * Converts old business rule expression config to constant expression metaItem config.
		 * @private
		 * @param {Object} expression Old business rule expression config.
		 * @param {Function} callback Callback function.
		 * @param {Function} errorback Errorback function.
		 * @param {Object} scope Callback function scope.
		 */
		convertToConstantExpressionMetaItem: function(expression, callback, errorback, scope) {
			callback.call(scope, {
				dataValueType: expression.dataValueType,
				value: expression.value,
				referenceSchemaName: expression.referenceSchemaName
			});
		},

		/**
		 * Converts old business rule expression config to expression metaItem config.
		 * @private
		 * @param {Object} expression Old business rule expression config.
		 * @param {Function} callback Callback function.
		 * @param {Function} errorback Errorback function.
		 * @param {Object} scope Callback function scope.
		 */
		convertToExpressionMetaItem: function(expression, callback, errorback, scope) {
			if (!expression) {
				return callback.call(scope, null);
			}
			var expressionType = this.convertToExpressionEnumType(expression);
			var result = {type: expressionType};
			Terrasoft.chain(
				function(next) {
					var expressionTypeEnum = Terrasoft.ExpressionEnums.ExpressionType;
					switch (expressionType) {
						case expressionTypeEnum.CONSTANT:
							this.convertToConstantExpressionMetaItem(expression, next, errorback, this);
							break;
						case expressionTypeEnum.COLUMN:
							this.convertToColumnExpressionMetaItem(expression, next, errorback, this);
							break;
						case expressionTypeEnum.ATTRIBUTE:
							this.convertToAttributeExpressionMetaItem(expression, next, errorback, this);
							break;
						case expressionTypeEnum.SYSSETTING:
							this.convertToSysSettingExpressionMetaItem(expression, next, errorback, this);
							break;
						case expressionTypeEnum.SYSVALUE:
							this.convertToSysValueExpressionMetaItem(expression, next, errorback, this);
							break;
						case expressionTypeEnum.FORMULA:
							this._convertToFormulaExpressionMetaItem(expression, next, errorback, this);
							break;
						default:
							errorback.call(scope, Terrasoft.Resources.Exception.UnsupportedTypeException);
					}
				},
				function(next, convertedExpression) {
					callback.call(scope, Ext.apply(result, convertedExpression));
				},
				this
			);
		},

		/**
		 * Checks nullability of comparison type.
		 * @private
		 * @return {Boolean} True - if comparison type is nullable.
		 */
		isNullableComparisonType: function(comparisonType) {
			var nullableComparisonTypes = [
				Terrasoft.ComparisonType.IS_NULL,
				Terrasoft.ComparisonType.IS_NOT_NULL
			];
			return Terrasoft.contains(nullableComparisonTypes, comparisonType);
		},

		/**
		 * Converts old business rule expression config to left expression metaItem config.
		 * @private
		 * @param {Object} config Convert config.
		 * @param {Function} callback Callback function.
		 * @param {Function} errorback Errorback function.
		 * @param {Object} scope Callback function scope.
		 */
		convertToLeftExpressionMetaItem: function(config, callback, errorback, scope) {
			this.convertToExpressionMetaItem(config.expression, function(leftExpression) {
				const expression = leftExpression && Ext.apply(leftExpression, {autoClean: config.autoClean, uId: config.expression.uId});
				callback.call(scope, {leftExpression: expression});
			}, errorback, this);
		},

		/**
		 * Converts old business rule expression config to right expression metaItem config.
		 * @private
		 * @param {Object} config Convert config.
		 * @param {Object} config.expression Old business rule expression config.
		 * @param {Terrasoft.ComparisonType} config.comparisonType Comparison type.
		 * @param {Function} callback Callback function.
		 * @param {Function} errorback Errorback function.
		 * @param {Object} scope Callback function scope.
		 */
		convertToRightExpressionMetaItem: function(config, callback, errorback, scope) {
			if (this.isNullableComparisonType(config.comparisonType)) {
				callback.call(scope, {rightExpression: null, uId: config.uId});
			} else {
				this.convertToExpressionMetaItem(config.expression, function(rightExpression) {
					const expression = rightExpression && Ext.apply(rightExpression, {autocomplete: config.autocomplete, uId: config.expression.uId});
					callback.call(scope, {rightExpression: expression});
				}, errorback, this);
			}
		},

		/**
		 * Converts old business rule condition config to comparison condition metaItem config.
		 * @private
		 * @param {Object} condition Old business rule condition config.
		 * @param {Function} callback Callback function.
		 * @param {Function} errorback Errorback function.
		 * @param {Object} scope Callback function scope.
		 */
		convertToComparisonConditionMetaItem: function(condition, callback, errorback, scope) {
			if (!Terrasoft.contains(Terrasoft.ComparisonType, condition.comparisonType)) {
				errorback.call(scope, Terrasoft.Resources.Exception.UnsupportedTypeException);
				return;
			}
			const result = {
				type: "ComparisonBusinessRuleCondition",
				comparisonType: condition.comparisonType,
				uId: condition.uId
			};
			Terrasoft.chain(
				function(next) {
					const config = {
						expression: condition.leftExpression,
						autoClean: false
					};
					this.convertToLeftExpressionMetaItem(config, function(leftExpression) {
						Ext.apply(result, leftExpression);
						next();
					}, errorback, this);
				},
				function(next) {
					const config = {
						expression: condition.rightExpression,
						comparisonType: condition.comparisonType
					};
					this.convertToRightExpressionMetaItem(config, function(rightExpression) {
						Ext.apply(result, rightExpression);
						next();
					}, errorback, this);
				},
				function() {
					callback.call(scope, result);
				},
				this
			);
		},

		/**
		 * Converts old business rule condition config to condition group metaItem config.
		 * @private
		 * @param {Object} config Convert config.
		 * @param {Object[]} config.conditions Old business rule condition config.
		 * @param {Terrasoft.LogicalOperatorType} config.logicalOperation Logical operation.
		 * @param {Function} callback Callback function.
		 * @param {Function} errorback Errorback function.
		 * @param {Object} scope Callback function scope.
		 */
		convertToConditionGroupMetaItem: function(config, callback, errorback, scope) {
			var conditions = config.conditions;
			if (!Ext.isArray(conditions)) {
				errorback.call(scope, Terrasoft.Resources.Exception.UnsupportedTypeException);
				return;
			}
			var logicalOperation = config.logicalOperation;
			var items = [];
			var functions = conditions.map(function(condition) {
				return function(next) {
					this.convertToComparisonConditionMetaItem(condition, function(result) {
						items.push(result);
						next();
					}, errorback, this);
				};
			}, this);
			functions.push(function() {
				callback.call(scope, {
					type: "BusinessRuleConditionGroup",
					operationType: logicalOperation || Terrasoft.LogicalOperatorType.AND,
					items: items,
					uId: config.uId
				});
			});
			Terrasoft.chain.apply(this, functions);
		},

		/**
		 * Returns business rule switch template.
		 * @private
		 * @return {Object} Business rule switch template.
		 */
		getBusinessRuleSwitchTemplate: function() {
			return {
				ruleSwitch: {
					type: "BusinessRuleSwitch",
					cases: [{
						type: "BusinessRuleCase",
						condition: null,
					}],
					defaultCase: null
				}
			};
		},

		/**
		 * Converts old business rule config to rule schema config.
		 * @private
		 * @param {Object} caseConfig Old business rule config.
		 * @param {Function} callback Callback function.
		 * @param {Object} scope Callback function scope.
		 */
		convertToRuleSchema: function(caseConfig, callback, scope) {
			const result = this.getBusinessRuleSwitchTemplate();
			Terrasoft.chain(
				function(next) {
					const errorCallback = this._errorCallback.bind(this, next);
					this.convertToConditionGroupMetaItem(caseConfig, next, errorCallback, this);
				},
				function(next, condition) {
					result.ruleSwitch.cases[0].condition = condition;
					callback.call(scope, result);
				}, this
			);
		},

		/**
		 * @private
		 */
		_errorCallback: function(next, message) {
			if (message) {
				console.warn(message);
			}
			next({
				type: "InvalidBusinessRule",
				invalid: true,
			});
		},

		// endregion

		// region Methods: Public

		/**
		 * Converts old business rule config to metaItem config.
		 * @param {Object} config Old business rule config.
		 * @param {Function} callback Callback function.
		 * @param {Object} scope Callback function scope.
		 */
		convertToMetaItemConfig: function(caseConfig, callback, scope) {
			this.convertToRuleSchema(caseConfig, function(convertedRule) {
				callback.call(scope, convertedRule);
			}, this);
		}

		// endregion
	});

	return Terrasoft.ToMetaItemBR7xConverter;
});


