Terrasoft.configuration.Structures["BusinessRulesApplierV2"] = {innerHierarchyStack: ["BusinessRulesApplierV2"]};
define("BusinessRulesApplierV2", ["ext-base", "terrasoft", "BusinessRuleModule",
		"BusinessRulesApplierV2Resources", "FormulaRequest", "FormulaColumnExtractor"],
	function(Ext, Terrasoft, BusinessRuleModule, resources) {
		/**
		 * @class Terrasoft.configuration.BusinessRulesApplier
		 * #####, ####### ######### ######-####### # ############# # ###### ############# #####
		 */
		var businessRulesApplier = Ext.define("Terrasoft.configuration.BusinessRulesApplier", {
			alternateClassName: "Terrasoft.BusinessRulesApplier",
			extend: "Terrasoft.BaseObject",

			//region Properties: Private

			/**
			 * ViewModel schema class.
			 * @private
			 * @type {Object}
			 */
			viewModelClass: null,

			/**
			 * Schema view config.
			 * @private
			 * @type {Object[]}
			 */
			viewConfig: null,

			/**
			 * Visible property name.
			 * @private
			 * @type {String}
			 */
			visiblePropertyName: "visible",

			/**
			 * ######## ######## ###########
			 * @private
			 * @type {String}
			 */
			enabledPropertyName: "enabled",

			/**
			 * ######## ######## ############## ##########
			 * @private
			 * @type {String}
			 */
			isRequiredPropertyName: "isRequired",

			/**
			 * ######## ######## ########### # ###### ######
			 * @private
			 * @type {String}
			 */
			readonlyPropertyName: "readonly",

			/**
			 * ####### ####### ######## ##########
			 * @private
			 * @type {String}
			 */
			labelSuffix: "Label",

			/**
			 * ######## ##### ####### ############# ### ########## ######## ##########
			 * @private
			 * @type {String}
			 */
			requiredStyleName: "required-caption",

			/**
			 * ####### ###### ############# ######
			 * @private
			 * @type {String}
			 */
			viewModelMethodPrefix: "Is",

			/**
			 * ####### ###### ############## ########### ######## # ####
			 * @private
			 * @type {String}
			 */
			autoCompleteMethodPrefix: "AutoComplete",

			/**
			 * ####### ###### ############# ####### ####
			 * @private
			 * @type {String}
			 */
			autoCleanMethodPrefix: "AutoClean",

			/**
			 * ########### ####### #### #######
			 * @private
			 * @type {String}
			 */
			metaPathSeparator: ".",

			/**
			 * ####### ######## #######
			 * @private
			 * @type {String}
			 */
			filterSuffix: "Filter",

			//endregion

			//region Methods: Private

			/**
			 * @private
			 */
			_addColumnToLookupListConfig: function(column, columnName) {
				var lookupListConfig = column.lookupListConfig = column.lookupListConfig || {};
				var columns = lookupListConfig.columns = lookupListConfig.columns || [];
				Terrasoft.appendIf(columns, columnName);
			},

			/**
			 * @private
			 */
			_checkFiltrationRuleComparisonType: function(rule, ruleName) {
				if (Ext.isEmpty(rule.comparisonType)) {
					var template = resources.localizableStrings.InvalidRuleFormatExceptionException;
					var message = Ext.String.format(template, ruleName);
					throw new Terrasoft.InvalidFormatException({message: message});
				}
			},

			/**
			 * @private
			 */
			_setColumnLookupListConfig: function(column, attributePath) {
				if (!column) {
					return;
				}
				if (!column.lookupListConfig) {
					column.lookupListConfig = {};
				}
				const lookupListConfig = column.lookupListConfig;
				if (!lookupListConfig.columns) {
					lookupListConfig.columns = [];
				}
				const lookupColumns = lookupListConfig.columns;
				if (!Ext.Array.contains(lookupColumns, attributePath)) {
					lookupColumns.push(attributePath);
				}
			},

			/**
			 * @private
			 */
			_filterDependencyColumns: function(dependencyColumn, column) {
				return dependencyColumn.isLookup &&
					dependencyColumn.name !== column.columnName &&
					dependencyColumn.referenceSchemaName === column.referenceSchemaName;
			},

			/**
			 * @private
			 */
			_getColumnDependencies: function(column, viewModel) {
				return column?.referenceSchemaName ?
					Object.values(viewModel.columns).filter(
						(depColumn) => this._filterDependencyColumns(depColumn, column)
					) : [];
			},

			/**
			 * @private
			 */
			_setColumnDependenciesColumnLookupListConfig: function(column, attributePath, viewModel) {
				const dependenciesColumns = this._getColumnDependencies(column, viewModel);
				Terrasoft.each(dependenciesColumns, (dependency) => {
					this._setColumnLookupListConfig(dependency, attributePath);
				});
			},

			/**
			 * @private
			 */
			_setLookupListConfigColumns: function(expression) {
				const viewModel = this.viewModelClass.prototype;
				const columns = viewModel.columns;
				if (expression && expression.attribute && expression.attributePath) {
					const column = columns[expression.attribute];
					this._setColumnLookupListConfig(column, expression.attributePath);
					this._setColumnDependenciesColumnLookupListConfig(column, expression.attributePath, viewModel);
				}
			},

			/**
			 * @private
			 */
			_applyRuleConditionLookupListConfig: function(conditions) {
				Terrasoft.each(conditions, function(condition) {
					this._setLookupListConfigColumns(condition.leftExpression);
					this._setLookupListConfigColumns(condition.rightExpression);
				}, this);
			},

			/**
			 * @private
			 */
			_getViewModelColumnExtraProperties: function(viewModel, columnName) {
				const column = viewModel.columns[columnName];
				return column && column.extraProperties;
			},

			/**
			 * @private
			 */
			_isActionElementTab: function(actionElementName) {
				const viewModel = this.viewModelClass.prototype;
				const extraProperties = this._getViewModelColumnExtraProperties(viewModel, actionElementName);
				return extraProperties && extraProperties.isTabContainer;
			},

			_hasAttributeType: function(expression) {
				if (!expression) {
					return false;
				}
				return expression.type === BusinessRuleModule.enums.ValueType.ATTRIBUTE ||
					expression.type === BusinessRuleModule.enums.ValueType.PARAMETER;
			},

			/**
			 * @private
			 */
			_getConditionsResult: function(rule, viewModel) {
				return rule.conditions
					.map(function(condition) {
						const leftValue = this.getRuleValue(condition.leftExpression, viewModel);
						const rightValue = this.getRuleValue(condition.rightExpression, viewModel);
						return this.getConditionResult(leftValue, condition.comparisonType, rightValue);
					}.bind(this))
					.reduce(function(accumulatedResult, conditionResult) {
						return rule.logical === Terrasoft.LogicalOperatorType.AND
							? accumulatedResult && conditionResult
							: accumulatedResult || conditionResult;
					}.bind(this), rule.logical === Terrasoft.LogicalOperatorType.AND);
			},

			/**
			 * @private
			 */
			_getAttributesFromConditionExpressions: function(conditions) {
				return conditions
					.map(function(condition) {
						const currentResult = [];
						if (this._hasAttributeType(condition.leftExpression)) {
							currentResult.push(condition.leftExpression.attribute);
						}
						if (this._hasAttributeType(condition.rightExpression)) {
							currentResult.push(condition.rightExpression.attribute);
						}
						return currentResult;
					}.bind(this))
					.reduce(function(accumulatedResult, currentResult) {
						return _.unique(accumulatedResult.concat(currentResult));
					}.bind(this), []);
			},

			/**
			 * @private
			 */
			_createViewModelBindParameterMethod: function(rule) {
				const scope = this;
				return function() {
					const result = scope._getConditionsResult(rule, this);
					const column = this.columns[rule.columnName];
					if (column && rule.property === BusinessRuleModule.enums.Property.REQUIRED) {
						column.isRequired = result;
						if (!column.isRequired && this.$IsEntityInitialized) {
							this.validateColumn(column.name);
						}
					}
					return result;
				};
			},

			/**
			 * @private
			 */
			_applyViewModelBindParameterMethod: function(rule) {
				const viewModel = this.viewModelClass.prototype;
				const methodName = this.getMethodName(rule.property, rule.columnName);
				viewModel[methodName] = this._createViewModelBindParameterMethod(rule);
			},

			/**
			 * @private
			 */
			_createUpdateTabVisibilityMethod: function(rule) {
				const scope = this;
				return function() {
					const actionElementName = rule.columnName;
					const actionElementExtraProperties = scope._getViewModelColumnExtraProperties(this, actionElementName);
					const tabs = this.get(actionElementExtraProperties.tabCollectionName);
					const tab = tabs.find(actionElementName);
					if (!tab) {
						const errorMessage = Ext.String.format(resources.localizableStrings.InvalidTabExceptionMessage,
							actionElementName)
						this.error(errorMessage);
						return;
					}
					const visibility = scope._getConditionsResult(rule, this);
					tab.set("Visible", visibility);
					if (actionElementName === this.get("ActiveTabName")) {
						if (!visibility) {
							this.set(actionElementName, false);
							const firstTab = tabs.firstOrDefault(function(x) {
								return x.get("Visible") !== false;
							});
							if (firstTab) {
								const activeTabName = firstTab.get("Name");
								this.set("ActiveTabName", activeTabName);
								tabs.each(function(tab) {
									const tabName = tab.get("Name");
									const isTabActive = tab.get("Name") === activeTabName;
									this.set(tabName, isTabActive);
								}, this);
							}
						} else {
							const visibleTabCount = tabs
								.filter(function(x) {
									return x.get("Visible") !== false;
								})
								.getCount();
							if (visibleTabCount === 1) {
								this.set(actionElementName, true);
							}
						}
					}
				};
			},

			/**
			 * @private
			 */
			_extendOnRenderMethod: function(extensionMethodName) {
				const viewModel = this.viewModelClass.prototype;
				const onRenderMethod = viewModel.onRender;
				if (onRenderMethod) {
					viewModel.onRender = function() {
						onRenderMethod.call(this, arguments);
						if (this.get("IsEntityInitialized")) {
							this[extensionMethodName]();
						}
					};
				}
			},

			/**
			 * @private
			 */
			_applyViewModelBindParameterDependenciesForTabRule: function(rule) {
				if (rule.property === BusinessRuleModule.enums.Property.VISIBLE) {
					const viewModel = this.viewModelClass.prototype;
					const actionElementExtraProperties = this._getViewModelColumnExtraProperties(viewModel, rule.columnName);
					const column = viewModel.columns[actionElementExtraProperties.tabCollectionName];
					if (!column.dependencies) {
						column.dependencies = [];
					}
					const columns = this._getAttributesFromConditionExpressions(rule.conditions);
					const methodName = Ext.String.format("update{0}Visibility", rule.columnName);
					column.dependencies.push({
						columns: columns.concat("IsEntityInitialized"),
						methodName: methodName
					});
					viewModel[methodName] = this._createUpdateTabVisibilityMethod(rule);
					this._extendOnRenderMethod(methodName);
				}
			},

			/**
			 * @private
			 */
			_applyContainerConfig: function(containerViewItem, rule) {
				const ruleProperty = rule.property;
				if (ruleProperty === BusinessRuleModule.enums.Property.VISIBLE) {
					const actionElementName = rule.columnName;
					const bindingPropertyName = this.getBindPropertyName(ruleProperty);
					const bindingMethodName = this.getMethodName(ruleProperty, actionElementName);
					containerViewItem[bindingPropertyName] = {bindTo: bindingMethodName};
				}
			},

			/**
			 * @private
			 */
			_applyEditableElementConfig: function(viewItem, rule) {
				const actionElementName = rule.columnName;
				const ruleProperty = rule.property;
				const bindingPropertyName = this.getBindPropertyName(ruleProperty);
				const bindingMethodName = this.getMethodName(ruleProperty, actionElementName);
				const config = {
					propertyName: bindingPropertyName,
					methodName: bindingMethodName
				};
				this._applyControlConfig(viewItem, config);
				this._applyLabelConfig(viewItem, config);
			},

			/**
			 * @private
			 */
			_applyControlConfig: function(viewItem, config) {
				const propertyName = config.propertyName;
				const methodName = config.methodName;
				if (!viewItem.controlConfig) {
					viewItem.controlConfig = {};
				}
				viewItem.controlConfig[propertyName] = {bindTo: methodName};
			},

			/**
			 * @private
			 */
			_applyLabelConfig: function(viewItem, config) {
				const propertyName = config.propertyName;
				const methodName = config.methodName;
				const readOnlyPropertyName = this.getBindPropertyName(BusinessRuleModule.enums.Property.READONLY);
				const visibilityPropertyName = this.getBindPropertyName(BusinessRuleModule.enums.Property.VISIBLE);
				if (propertyName === readOnlyPropertyName) {
					return;
				}
				if (!viewItem.labelConfig) {
					viewItem.labelConfig = {};
				}
				if (propertyName === visibilityPropertyName && viewItem.labelConfig[propertyName] === false) {
					return;
				}
				viewItem.labelConfig[propertyName] = {bindTo: methodName};
			},

			/**
			 * @private
			 */
			_createPopulateAttributeRuleUpdateValueMethod: function(rule, callback, callbackScope) {
				const scope = this;
				return function(arg, changedColumnName) {
					if (scope._getConditionsResult(rule, this)) {
						const config = {
							doNotConvertDateTimeToNumber: true,
							doNotConvertLookupValueToSingleValue: true,
							changedColumnName: changedColumnName
						};
						scope._getRuleValueAsync(rule.populatingAttributeSource.expression, this, config)
							.then(function(value) {
								const oldValue = this.get(rule.columnName);
								const newValue = scope._formatToColumnValue(this, rule.columnName, value);
								if (Ext.isEmpty(oldValue) && Ext.isEmpty(newValue)) {
									return;
								}
								this.set(rule.columnName, newValue);
								Ext.callback(callback, callbackScope);
							}.bind(this))
							.catch(function(exception) {
								const value = scope._getDefaultColumnValue(this, rule.columnName);
								this.set(rule.columnName, value);
								const info = {
									invalidMessage: exception.message,
									isValid: false
								};
								this.validationInfo.set(rule.columnName, info);
								Ext.callback(callback, callbackScope);
							}.bind(this));
					}
				};
			},

			/**
			 * @private
			 */
			_formatToColumnValue: function(viewModel, columnName, value) {
				if (Ext.isEmpty(value)) {
					return this._getDefaultColumnValue(viewModel, columnName);
				}
				const column = viewModel.getColumnByName(columnName);
				if (Terrasoft.isNumberDataValueType(column.dataValueType)) {
					const precision = column.precision || 0;
					return Terrasoft.roundValue(value, precision);
				}
				if (Terrasoft.isDateDataValueType(column.dataValueType)) {
					if (!Ext.isDate(value)) {
						return Terrasoft.parseDate(value);
					}
				}
				return value;
			},

			/**
			 * @private
			 */
			_getDefaultColumnValue: function(viewModel, columnName) {
				const column = viewModel.getColumnByName(columnName);
				const dataValueType = column.dataValueType;
				if (Terrasoft.isBooleanDataValueType(dataValueType)) {
					return false;
				}
				if (Terrasoft.isNumberDataValueType(dataValueType)) {
					return 0;
				}
				if (Terrasoft.isTextDataValueType(dataValueType)) {
					return "";
				}
				return null;
			},

			/**
			 * @private
			 */
			_applyPopulateAttributeRuleDependencies: function(rule) {
				const viewModel = this.viewModelClass.prototype;
				const column = viewModel.columns[rule.columnName];
				if (!column.dependencies) {
					column.dependencies = [];
				}
				const columns = this._getAttributesFromConditionExpressions(rule.conditions);
				const methodName = Ext.String.format("populateRule{0}", Terrasoft.generateGUID());
				column.dependencies.push({
					columns: columns,
					methodName: methodName,
					isApplyingToDefaultValue: true,
					isAsync: true,
				});
				viewModel[methodName] = this._createPopulateAttributeRuleUpdateValueMethod(rule);
			},

			/**
			 * @private
			 */
			_applyPopulateAttributeRuleLookupListConfig: function(rule) {
				this._applyRuleConditionLookupListConfig(rule.conditions);
				this._setLookupListConfigColumns(rule.populatingAttributeSource.expression);
			},

			/**
			 * @private
			 */
			_validatePopulateAttributeRule: function(rule, ruleName) {
				if (!this.viewModelClass.prototype.columns[rule.columnName]) {
					return {
						success: false,
						errorMessage: Ext.String.format(resources.localizableStrings.InvalidActionColumnError, ruleName, rule.columnName)
					};
				}
				const hasRequiredRuleParts = rule.conditions &&
					rule.populatingAttributeSource &&
					rule.populatingAttributeSource.expression;
				if (!hasRequiredRuleParts) {
					return {
						success: false,
						errorMessage: Ext.String.format(resources.localizableStrings.InvalidRuleFormatExceptionException, ruleName)
					};
				}
				const attributes = this._getAttributesFromConditionExpressions(rule.conditions);
				if (attributes.indexOf(rule.columnName) >= 0) {
					return {
						success: false,
						errorMessage: Ext.String.format(resources.localizableStrings.ConditionFieldIsPresentedInActionError, ruleName)
					};
				}
				return {success: true};
			},

			/**
			 * @private
			 */
			_applyPopulateAttributeRule: function(rule, ruleName) {
				if (!Terrasoft.Features.getIsEnabled("PopulateBusinessRuleAction")) {
					return;
				}
				const validationResult = this._validatePopulateAttributeRule(rule, ruleName);
				if (validationResult.success) {
					this._applyPopulateAttributeRuleLookupListConfig(rule);
					this._applyPopulateAttributeRuleDependencies(rule);
				} else {
					this.error(validationResult.errorMessage);
				}
			},

			/**
			 * @private
			 */
			_canConvertDateTimeToNumber: function(config) {
				return !config || !config.doNotConvertDateTimeToNumber;
			},

			/**
			 * @private
			 */
			_canConvertLookupValueToSingleValue: function(config) {
				return !config || !config.doNotConvertLookupValueToSingleValue;
			},

			_getExcludedDataValueTypesForFormula: function() {
				return [
					Terrasoft.DataValueType.BLOB,
					Terrasoft.DataValueType.IMAGE,
					Terrasoft.DataValueType.CUSTOM_OBJECT,
					Terrasoft.DataValueType.COLLECTION,
					Terrasoft.DataValueType.LOCALIZABLE_STRING,
					Terrasoft.DataValueType.ENTITY,
					Terrasoft.DataValueType.ENTITY_COLLECTION,
					Terrasoft.DataValueType.ENTITY_COLUMN_MAPPING_COLLECTION,
					Terrasoft.DataValueType.FILE,
					Terrasoft.DataValueType.MAPPING,
					Terrasoft.DataValueType.LOCALIZABLE_PARAMETER_VALUES_LIST,
					Terrasoft.DataValueType.METADATA_TEXT,
					Terrasoft.DataValueType.STAGE_INDICATOR,
					Terrasoft.DataValueType.OBJECT_LIST,
					Terrasoft.DataValueType.COMPOSITE_OBJECT_LIST
				];
			},

			_extractColumnsFromFormula: function(formula) {
				const extractor = Ext.create("Terrasoft.FormulaColumnExtractor", {formula: formula});
				return extractor.extractColumns();
			},

			_prepareChangedColumnsForFormulaRequest: function(viewModel, formula, changedColumnName) {
				const changedColumns = _.unique(Object.keys(viewModel.changedValues).concat([changedColumnName]));
				const excludedDataValueTypes = this._getExcludedDataValueTypesForFormula();
				const formulaColumnPaths = this._extractColumnsFromFormula(formula);
				return Object.values(viewModel.columns)
					.filter(function(column) {
						const isInFormula = formulaColumnPaths.indexOf(column.name) >= 0;
						const isEntityColumn = column.type === Terrasoft.ViewModelColumnType.ENTITY_COLUMN;
						const hasAllowedDataValueType = Ext.isObject(column) && column.dataValueType &&
							excludedDataValueTypes.indexOf(column.dataValueType) < 0;
						const isChangedColumn = !viewModel.isNew ? changedColumns.indexOf(column.name) >= 0 : true;
						return isInFormula && isEntityColumn && hasAllowedDataValueType && isChangedColumn && !!column.name;
					})
					.map(function(column) {
						let columnValue = viewModel.get(column.name);
						if (Ext.isDate(columnValue)) {
							columnValue = Terrasoft.encodeDate(columnValue).replaceAll("\"", "");
						}
						return {
							name: column.name,
							value: (columnValue && columnValue.value) ? columnValue.value : columnValue
						};
					});
			},

			_requestFormulaValue: function(config) {
				const formulaRequest = Ext.create("Terrasoft.FormulaRequest", config);
				return formulaRequest.executeAsync().then(function(response) {
					if (!response.success) {
						throw new Terrasoft.UnknownException({message: response.errorInfo.message});
					}
					return response.result;
				});
			},

			_getRuleValueAsync: function(expression, viewModel, config) {
				if (Ext.isEmpty(expression)) {
					return Promise.resolve(null);
				}
				if (expression.type === BusinessRuleModule.enums.ValueType.FORMULA) {
					return this._requestFormulaValue({
						formula: expression.formula,
						entitySchemaName: viewModel.entitySchemaName,
						recordId: viewModel.get(viewModel.entitySchema.primaryColumnName),
						changedColumns: this._prepareChangedColumnsForFormulaRequest(viewModel, expression.formula, config.changedColumnName)
					});
				} else {
					const ruleValue = this.getRuleValue(expression, viewModel, config);
					return Promise.resolve(ruleValue);
				}
			},

			_getAttributeRuleValue: function(item, scope, config) {
				let returnValue;
				const itemAttribute = item.attribute;
				const itemAttributePath = item.attributePath;
				if (!Ext.isEmpty(itemAttribute)) {
					if (!scope.columns[itemAttribute]) {
						this.error(Ext.String.format(resources.localizableStrings.InvalidColumn, item.attribute));
					}
					returnValue = scope.get(itemAttribute);
					const dataValueType = scope.getColumnDataType(itemAttribute);
					if (!Ext.isEmpty(returnValue) && dataValueType === Terrasoft.DataValueType.LOOKUP) {
						if (Ext.isEmpty(itemAttributePath)) {
							if (this._canConvertLookupValueToSingleValue(config)) {
								returnValue = returnValue.value;
							}
						} else {
							returnValue = this.getAttributeValueByPath(returnValue, itemAttributePath);
							if (!Ext.isDefined(returnValue)) {
								this.error(Ext.String.format(resources.localizableStrings.InvalidColumn, item.attribute + "." + itemAttributePath));
							}
						}
					}
				}
				return returnValue;
			},

			_getSysSettingRuleValue: function(item) {
				if (!Ext.isDefined(Terrasoft.SysSettings.cachedSettings[item.value])) {
					this.error(Ext.String.format(resources.localizableStrings.InvalidSysSetting, item.value));
				}
				return Terrasoft.SysSettings.cachedSettings[item.value];
			},

			_getSysValueRuleValue: function(item, scope) {
				try {
					return scope.getSysDefaultValue(item.value);
				} catch {
					this.error(Ext.String.format(resources.localizableStrings.InvalidSysValue, item.value));
				}
			},

			//endregion

			/**
			 * Applies business rules to schema.
			 * @param {Object} viewModelClass View model class.
			 * @param {Object[]} viewConfig View config.
			 * @return Rules.
			 */
			applyRules: function(viewModelClass, viewConfig) {
				this.viewModelClass = viewModelClass;
				this.viewConfig = viewConfig;
				var viewModelClassPrototype = viewModelClass.prototype;
				var rules = this.mergeRules(viewModelClassPrototype.rules, viewModelClassPrototype.businessRules);
				viewModelClassPrototype.rules = rules;
				Terrasoft.each(rules, function(columnRules, columnName) {
					this.applyColumnRules(columnRules, columnName);
				}, this);
				return rules;
			},

			/**
			 * Merges rule and business rule blocks.
			 * @param {Object} rules Rule block.
			 * @param {Object} businessRules Business rule block.
			 * @return {Object} Merged rules.
			 */
			mergeRules: function(rules, businessRules) {
				rules = rules || {};
				businessRules = businessRules || {};
				var result = {};
				var columnNames = Ext.Array.merge(Ext.Object.getKeys(rules), Ext.Object.getKeys(businessRules));
				Terrasoft.each(columnNames, function(columnName) {
					result[columnName] = this.mergeColumnRules(rules[columnName], businessRules[columnName]);
				}, this);
				return result;
			},

			/**
			 * Merges column rules and column business rules.
			 * @protected
			 * @param {Object} columnRules Column rules.
			 * @param {Object} columnBusinessRules Column business rules.
			 * @return {Object} Merged column rules.
			 */
			mergeColumnRules: function(columnRules, columnBusinessRules) {
				columnRules = columnRules || {};
				columnBusinessRules = columnBusinessRules || {};
				var result = {};
				var ruleNames = Ext.Array.merge(
					Ext.Object.getKeys(columnRules),
					Ext.Object.getKeys(columnBusinessRules));
				Terrasoft.each(ruleNames, function(ruleName) {
					result[ruleName] = Ext.apply(columnRules[ruleName] || {}, columnBusinessRules[ruleName]);
				}, this);
				return result;
			},

			/**
			 * Returns ability of execution of rule.
			 * @protected
			 * @param {Object} rule Rule.
			 * @return {Boolean} Ability of execution of rule.
			 */
			canExecuteBusinessRule: function(rule) {
				return rule.removed !== true && rule.enabled !== false;
			},

			/**
			 * ######### ######-####### # ####### #####.
			 * @protected
			 * @param {Object} columnRules ######-####### #######.
			 * @param {String} columnName ######## #######.
			 */
			applyColumnRules: function(columnRules, columnName) {
				Terrasoft.each(columnRules, function(rule, ruleName) {
					if (this.canExecuteBusinessRule(rule)) {
						rule.columnName = columnName;
						this.applyRule(rule, ruleName);
					}
				}, this);
			},

			/**
			 * ######### ######-####### # ####### #####.
			 * @protected
			 * @param {Object} rule ######-#######.
			 * @param {String} ruleName ######## ######-#######.
			 */
			applyRule: function(rule, ruleName) {
				var ruleType = rule.ruleType;
				if (Ext.isEmpty(ruleType) || Ext.isEmpty(ruleName)) {
					throw new Terrasoft.InvalidFormatException({
						message: Ext.String.format(resources.localizableStrings.InvalidRuleFormatExceptionException,
							ruleName)
					});
				}
				switch (ruleType) {
					case BusinessRuleModule.enums.RuleType.BINDPARAMETER:
						this.applyBindParameterRule(rule, ruleName);
						break;
					case BusinessRuleModule.enums.RuleType.FILTRATION:
						this.applyFiltrationRule(rule, ruleName);
						break;
					case BusinessRuleModule.enums.RuleType.AUTOCOMPLETE:
						this.applyAutoCompleteRule(rule, ruleName);
						break;
					case BusinessRuleModule.enums.RuleType.POPULATE_ATTRIBUTE:
						this._applyPopulateAttributeRule(rule, ruleName);
						break;
					case BusinessRuleModule.enums.RuleType.DISABLED:
						break;
					default:
						break;
				}
			},

			/**
			 * ######### ######-####### ## ########## ######## # ###########.
			 * @protected
			 * @param {Object} rule ######-#######.
			 * @param {String} ruleName ######## ######-#######.
			 */
			applyFiltrationRule: function(rule, ruleName) {
				this._checkFiltrationRuleComparisonType(rule, ruleName);
				if (rule.autocomplete) {
					this.applyAutoCompleteRule(rule, ruleName);
				}
				if (!rule.autocomplete && rule.autoClean) {
					this.applyAutoCleanRule(rule);
				}
				var columns = this.viewModelClass.prototype.columns;
				var column = columns[rule.columnName];
				if (!column) {
					return;
				}
				var filterColumn = columns[rule.attribute];
				var relatedFilterColumnName = rule.attributePath;
				if (filterColumn && relatedFilterColumnName) {
					this._addColumnToLookupListConfig(filterColumn, relatedFilterColumnName);
				}
				var lookupListConfig = column.lookupListConfig = column.lookupListConfig || {};
				var filters = lookupListConfig.filters = lookupListConfig.filters || [];
				var ruleApplier = this;
				filters.push({
					argument: rule,
					method: function(_rule) {
						var filterGroup = Terrasoft.createFilterGroup();
						var ruleValue = ruleApplier.getRuleValue(_rule, this);
						if (!Ext.isEmpty(ruleValue)) {
							if (Terrasoft.isDateDataValueType(_rule.dataValueType)) {
								ruleValue = new Date(ruleValue);
							}
							var filterName = _rule.baseAttributePatch + ruleApplier.filterSuffix;
							var filterWithParameter = Terrasoft.createColumnFilterWithParameter(
								_rule.comparisonType, _rule.baseAttributePatch, ruleValue);
							filterGroup.add(filterName, filterWithParameter);
						}
						return filterGroup;
					}
				});
			},

			/**
			 * ######### ######-####### ## ############### ######## # ####.
			 * @protected
			 * @param {Object} rule ######-#######.
			 * @param {String} ruleName ######## ######-#######.
			 */
			applyAutoCompleteRule: function(rule, ruleName) {
				if (!ruleName) {
					return;
				}
				var viewModel = this.viewModelClass.prototype;
				var columnName = rule.columnName;
				var ruleAttribute = rule.attribute;
				var baseAttributePatch = rule.baseAttributePatch;
				var autoCompleteMethodName = this.autoCompleteMethodPrefix + Terrasoft.generateGUID() + ruleAttribute;
				var autoCompleteDependencies = [];
				if (rule.ruleType === BusinessRuleModule.enums.RuleType.AUTOCOMPLETE) {
					autoCompleteDependencies.push(rule.attribute);
				} else {
					autoCompleteDependencies.push(columnName);
				}
				var columns = viewModel.columns;
				var column = columns[columnName];
				if (!column.lookupListConfig) {
					column.lookupListConfig = {};
				}
				var lookupListConfig = column.lookupListConfig;
				if (!lookupListConfig.columns) {
					lookupListConfig.columns = [];
				}
				var lookupColumns = lookupListConfig.columns;
				if (lookupColumns.indexOf(baseAttributePatch) < 0) {
					lookupColumns.push(baseAttributePatch);
				}
				var modifyRule = Terrasoft.deepClone(rule);
				if (rule.ruleType === BusinessRuleModule.enums.RuleType.AUTOCOMPLETE) {
					modifyRule.attribute = rule.columnName;
					modifyRule.columnName = rule.attribute;
					rule = modifyRule;
				}
				if (!column.dependencies) {
					column.dependencies = [];
				}
				var dependencies = column.dependencies;
				var dependency = {
					columns: [columnName],
					methodName: autoCompleteMethodName,
					argument: rule,
					isApplyingToDefaultValue: true
				};
				if (dependencies.indexOf(dependency) < 0) {
					dependencies.push(dependency);
				}
				viewModel[autoCompleteMethodName] = function(currentRule) {
					var argAttribute = currentRule.attribute;
					var lookupValue = this.get(currentRule.columnName);
					var setValue = function(argAttribute, value) {
						if (this.get(argAttribute) !== value) {
							this.set(argAttribute, value);
						}
					};
					if (!Ext.isEmpty(lookupValue)) {
						var dependentValue = (!Ext.isEmpty(currentRule.baseAttributePatch)) ?
							lookupValue[currentRule.baseAttributePatch] : lookupValue;
						if (!Ext.isEmpty(dependentValue)) {
							switch (currentRule.autocompleteType) {
								case BusinessRuleModule.enums.AutocompleteType.DISPLAYVALUE:
									if (!Ext.isEmpty(dependentValue.displayValue)) {
										setValue.call(this, argAttribute, dependentValue.displayValue);
									}
									break;
								case BusinessRuleModule.enums.AutocompleteType.VALUE:
									if (!Ext.isEmpty(dependentValue.value)) {
										setValue.call(this, argAttribute, dependentValue.value);
									}
									break;
								default:
									setValue.call(this, argAttribute, dependentValue);
									break;
							}
						}
					}
				};
				if (rule.autoClean) {
					this.applyAutoCleanRule(rule);
				}
			},

			/**
			 * ######### ######-####### ## ############## ####### ######## # ####.
			 * @protected
			 * @param {Object} rule ######-#######.
			 */
			applyAutoCleanRule: function(rule) {
				var columnName = rule.columnName;
				var ruleAttribute = rule.attribute;
				var autoCleanMethodName = this.autoCleanMethodPrefix + columnName + ruleAttribute;
				var viewModel = this.viewModelClass.prototype;
				var columns = viewModel.columns;
				var column = columns[columnName];
				var dependencies = column.dependencies = column.dependencies || [];
				var dependency = {
					columns: [ruleAttribute],
					methodName: autoCleanMethodName,
					argument: rule,
				};
				if (dependencies.indexOf(dependency) === -1) {
					dependencies.push(dependency);
				}
				viewModel[autoCleanMethodName] = function() {
					var base = this.get(ruleAttribute);
					var dependent = this.get(columnName);
					if (!Ext.isEmpty(base) && !Ext.isEmpty(dependent)) {
						var dependentValue = dependent[rule.baseAttributePatch];
						var dependentValueIsEmpty = Ext.isEmpty(dependentValue);
						if ((!dependentValueIsEmpty && (base.value !== dependentValue.value)) ||
							(dependentValueIsEmpty && Ext.isFunction(this.canAutoCleanDependentColumns) &&
								this.canAutoCleanDependentColumns())) {
							this.set(columnName, null);
						}
					}
				};
			},

			/**
			 * @private
			 */
			_applyBindDependencyColumnsMethod: function(column, viewModel) {
				const dependencies = column.dependencies;
				Terrasoft.each(dependencies, function(dependency) {
					const dependentColumns = dependency.columns;
					Terrasoft.each(dependentColumns, function(dependentColumn) {
						viewModel.on("change:" + dependentColumn, function() {
							const isApplyingToDefaultValue = dependency.isApplyingToDefaultValue === true;

							// TODO Strict comparison on false;
							const isEntityNotInitialized = this.get("IsEntityInitialized") === false;
							if ((this.isNew && isApplyingToDefaultValue) || !isEntityNotInitialized) {
								try {
									if (dependency.isAsync) {
										viewModel.$BusinessRuleApplying = true;
										this[dependency.methodName](dependency.argument, dependentColumn, function() {
											viewModel.$BusinessRuleApplying = false;
										}, this);
									} else {
										this[dependency.methodName](dependency.argument, dependentColumn);
									}

								} catch (e) {
									this.warning(Ext.String.format(resources.localizableStrings.ThrownException,
										dependency.methodName, e.message));
								}
							}
						}, viewModel);
					}, this);
				}, this);
			},

			/**
			 * Apply model dependencies.
			 * @param {Object} viewModel View model.
			 */
			applyDependencies: function(viewModel) {
				var columns = viewModel.columns;
				Terrasoft.each(columns, function(column, columnName) {
					if (!Ext.isEmpty(column.multiLookupColumns)) {
						column.dependencies = column.dependencies || [];
						column.dependencies.push({
							columns: [columnName],
							methodName: "onSetMultiLookup"
						});
					}
					if (column.dependencies) {
						this._applyBindDependencyColumnsMethod(column, viewModel);
					}
				}, this);
			},

			/**
			 * Applies business rule by binding view properties.
			 * @protected
			 * @param {Object} rule Business rule.
			 * @param {String} ruleName Business rule name.
			 */
			applyBindParameterRule: function(rule, ruleName) {
				if (Ext.isEmpty(rule.conditions) || Ext.isEmpty(rule.property)) {
					throw new Terrasoft.InvalidFormatException({
						message: Ext.String.format(resources.localizableStrings.InvalidRuleFormatExceptionException,
							ruleName)
					});
				}
				this.applyViewBindParameter(rule, this.viewConfig);
				this.applyViewModelBindParameter(rule);
			},

			/**
			 * Applies view property to view model methods.
			 * @protected
			 * @param {Object} rule Business rule.
			 * @param {Array} viewConfig Schema view configuration array.
			 */
			applyViewBindParameter: function(rule, viewConfig) {
				Terrasoft.each(viewConfig, function(viewItem) {
					const actionElementName = rule.columnName;
					const viewItemElementName = viewItem.bindTo ? viewItem.bindTo : viewItem.name;
					const viewItems = viewItem.items ? viewItem.items : viewItem.tabs;
					if (Ext.isArray(viewItems)) {
						if (actionElementName === viewItemElementName && !this._isActionElementTab(actionElementName)) {
							this._applyContainerConfig(viewItem, rule);
						}
						this.applyViewBindParameter(rule, viewItems);
					} else {
						if (actionElementName === viewItemElementName) {
							if (viewItem.itemType === Terrasoft.ViewItemType.DETAIL || viewItem.itemType === Terrasoft.ViewItemType.MODULE) {
								this._applyContainerConfig(viewItem, rule);
							} else {
								this._applyEditableElementConfig(viewItem, rule);
							}
						}
					}
				}, this);
			},

			/**
			 * Returns bind property name.
			 * @protected
			 * @param {Number} property Business rule property code.
			 * @return {String} Returns bind property name.
			 */
			getBindPropertyName: function(property) {
				switch (property) {
					case BusinessRuleModule.enums.Property.VISIBLE:
						return this.visiblePropertyName;
					case BusinessRuleModule.enums.Property.ENABLED:
						return this.enabledPropertyName;
					case BusinessRuleModule.enums.Property.REQUIRED:
						return this.isRequiredPropertyName;
					case BusinessRuleModule.enums.Property.READONLY:
						return this.readonlyPropertyName;
					default:
						return this.visiblePropertyName;
				}
			},

			/**
			 * Returns method name by applying business rule.
			 * @protected
			 * @param {Number} property Business rule property code.
			 * @param {Object} columnName Column name.
			 * @return {String} Returns method name.
			 */
			getMethodName: function(property, columnName) {
				var rulePropertyName = this.getBindPropertyName(property);
				return this.viewModelMethodPrefix + columnName + rulePropertyName;
			},

			/**
			 * Creates viewModel methods to which the view properties will be attached.
			 * @protected
			 * @param {Object} rule Business rule.
			 */
			applyViewModelBindParameter: function(rule) {
				this._applyRuleConditionLookupListConfig(rule.conditions);
				if (!this._isActionElementTab(rule.columnName)) {
					this._applyViewModelBindParameterMethod(rule);
				} else {
					this._applyViewModelBindParameterDependenciesForTabRule(rule);
				}
			},

			/**
			 * Returns calculated business rule value.
			 * @protected
			 * @param {Object} item Business rule expression.
			 * @param {Object} scope Function scope.
			 * @param {Object?} config Configuration object.
			 * @param {Boolean} config.doNotConvertDateTimeToNumber
			 * @param {Boolean} config.doNotConvertLookupValueToSingleValue
			 * @return {Object} Calculated business rule value.
			 */
			getRuleValue: function(item, scope, config) {
				let returnValue;
				if (Ext.isEmpty(item)) {
					return null;
				}
				switch (item.type) {
					case BusinessRuleModule.enums.ValueType.CONSTANT:
						returnValue = item.value;
						break;
					case BusinessRuleModule.enums.ValueType.SYSSETTING:
						returnValue = this._getSysSettingRuleValue(item);
						break;
					case BusinessRuleModule.enums.ValueType.PARAMETER:
					case BusinessRuleModule.enums.ValueType.ATTRIBUTE:
						returnValue = this._getAttributeRuleValue(item, scope, config);
						break;
					case BusinessRuleModule.enums.ValueType.SYSVALUE:
						returnValue = this._getSysValueRuleValue(item, scope);
						break;
					case BusinessRuleModule.enums.ValueType.CARDSTATE:
						returnValue = scope.action;
						break;
					default:
						break;
				}
				if (returnValue && returnValue.value && this._canConvertLookupValueToSingleValue(config)) {
					returnValue = returnValue.value;
				}
				const itemDataValueType = item.dataValueType || scope.getColumnDataType(item.attribute);
				if (returnValue && Terrasoft.isDateDataValueType(itemDataValueType) && this._canConvertDateTimeToNumber(config)) {
					returnValue = this.getDateTimeValue(returnValue, itemDataValueType);
				}
				if (Terrasoft.isBooleanDataValueType(itemDataValueType)) {
					returnValue = Boolean(returnValue);
				}
				return returnValue;
			},

			/**
			 * Returns the numeric value of the specified date according to data value type.
			 * @param {Object} value Date value.
			 * @param {Number} dataValueType Type of specified date value.
			 * @return {Number} Returns the numeric value of the specified date.
			 */
			getDateTimeValue: function(value, dataValueType) {
				var returnValue;
				var date = new Date(value);
				switch (dataValueType) {
					case Terrasoft.DataValueType.DATE:
						date.setHours(0);
						date.setMinutes(0);
						date.setSeconds(0);
						date.setMilliseconds(0);
						returnValue = date.getTime();
						break;
					case Terrasoft.DataValueType.TIME:
						var currentDate = new Date();
						currentDate.setHours(date.getHours());
						currentDate.setMinutes(date.getMinutes());
						currentDate.setSeconds(date.getSeconds());
						currentDate.setMilliseconds(date.getMilliseconds());
						returnValue = currentDate.getTime();
						break;
					default:
						returnValue = date.getTime();
						break;
				}
				return returnValue;
			},

			/**
			 * Returns condition result.
			 * @protected
			 * @param {Object} left Left part path.
			 * @param {Object} type Comparison type.
			 * @param {Object} right Right part value.
			 * @return {Boolean} Returns condition result.
			 */
			getConditionResult: function(left, type, right) {
				var conditionResult = true;
				switch (type) {
					case Terrasoft.ComparisonType.IS_NULL:
						conditionResult = Ext.isEmpty(left);
						break;
					case Terrasoft.ComparisonType.IS_NOT_NULL:
						conditionResult = !Ext.isEmpty(left);
						break;
					case Terrasoft.ComparisonType.EQUAL:
						conditionResult = (left === right || (Ext.isEmpty(left) && Ext.isEmpty(right)));
						break;
					case Terrasoft.ComparisonType.NOT_EQUAL:
						conditionResult = (left !== right);
						break;
					case Terrasoft.ComparisonType.GREATER:
						conditionResult = (left > right);
						break;
					case Terrasoft.ComparisonType.LESS:
						conditionResult = (left < right);
						break;
					default:
						break;
				}
				return conditionResult;
			},

			/**
			 * ########## ######### ######### ######-#######.
			 * @protected
			 * @param {Object} left #### ####### ###### #####.
			 * @param {Object} type ### #########.
			 * @param {Object} right ############ ######## ###### #####.
			 * @return {Boolean} ########## ######### ######### ######-#######.
			 */
			getRuleComparingResult: function(left, type, right) {
				var rulePropertyCode = true;
				switch (type) {
					case Terrasoft.ComparisonType.IS_NULL:
						rulePropertyCode = Ext.isEmpty(left);
						break;
					case Terrasoft.ComparisonType.IS_NOT_NULL:
						rulePropertyCode = !Ext.isEmpty(left);
						break;
					case Terrasoft.ComparisonType.EQUAL:
						rulePropertyCode = (left === right);
						break;
					case Terrasoft.ComparisonType.NOT_EQUAL:
						rulePropertyCode = (left !== right);
						break;
					default:
						break;
				}
				return rulePropertyCode;
			},

			/**
			 * ########## ######## ######## ## #### #######.
			 * @protected
			 * @param {Object} object #### ####### ###### #####.
			 * @param {String} path ### #########.
			 * @return {String} ########## ######## ######## ## #### #######.
			 */
			getAttributeValueByPath: function(object, path) {
				return object[path];
			},

			/**
			 * ########## ############ #############, ## ###### ####### ##### ########### ######## ##########.
			 * @protected
			 * @param {Object[]} viewConfig ############ #############, ############ ## #### ######## ############
			 * #####.
			 * @return {Object[]} ########## ############### ############# #####.
			 */
			generateView: function(viewConfig) {
				var resultView = [];
				Terrasoft.each(viewConfig, function(item) {
					var itemView = this.generateItemView(item);
					resultView.push(itemView);
				}, this);
				return resultView;
			}
		});

		return Ext.create(businessRulesApplier);
	});


