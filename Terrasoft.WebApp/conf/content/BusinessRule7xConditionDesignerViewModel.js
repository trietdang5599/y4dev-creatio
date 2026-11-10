Terrasoft.configuration.Structures["BusinessRule7xConditionDesignerViewModel"] = {innerHierarchyStack: ["BusinessRule7xConditionDesignerViewModel"]};
define("BusinessRule7xConditionDesignerViewModel", ["BusinessRule7xConditionDesignerViewModelResources", "ConfigurationEnums",
	"ConfigurationConstants", "BR7xElementDesignerViewModel", "BR7xExpressionEdit", "ExpressionEditVMMixin",
	"ExpressionEnums", "BusinessRuleSchemaManager"
], function(resources, ConfigurationEnums, ConfigurationConstants) {

	Ext.define("Terrasoft.Designers.BusinessRule7xConditionDesignerViewModel", {
		extend: "Terrasoft.Designers.BR7xElementDesignerViewModel",
		alternateClassName: "Terrasoft.BusinessRule7xConditionDesignerViewModel",

		mixins: {
			"ExpressionEditVMMixin": "Terrasoft.ExpressionEditVMMixin"
		},

		columns: {
			/**
			 * Comparison type list.
			 * @type {Terrasoft.BaseViewModelCollection}
			 */
			"ComparisonTypeList": {
				"type": Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"dataValueType": Terrasoft.DataValueType.COLLECTION,
				"value": null
			},
			/**
			 * Comparison type.
			 * @type {Terrasoft.ComparisonType}
			 */
			"ComparisonType": {
				"type": Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"dataValueType": Terrasoft.DataValueType.INTEGER,
				"value": null
			},
			/**
			 * Comparison type caption.
			 * @type {String}
			 */
			"ComparisonTypeCaption": {
				"type": Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"dataValueType": Terrasoft.DataValueType.TEXT,
				"value": null
			},
			/**
			 * Left expression value.
			 * @type {Object}
			 */
			"LeftExpressionValue": {
				"type": Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"dataValueType": Terrasoft.DataValueType.CUSTOM_OBJECT,
				"value": null
			},
			/**
			 * Left expression type.
			 * @type {String}
			 */
			"LeftExpressionType": {
				"type": Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"dataValueType": Terrasoft.DataValueType.TEXT,
				"value": null
			},
			/**
			 * Right expression value.
			 * @type {Object}
			 */
			"RightExpressionValue": {
				"type": Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"dataValueType": Terrasoft.DataValueType.CUSTOM_OBJECT,
				"value": null
			},
			/**
			 * Right expression type.
			 * @type {String}
			 */
			"RightExpressionType": {
				"type": Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"dataValueType": Terrasoft.DataValueType.TEXT,
				"value": null
			},
			/**
			 * Expression data value type.
			 * @type {Terrasoft.DataValueType}
			 */
			"ExpressionDataValueType": {
				"type": Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"dataValueType": Terrasoft.DataValueType.INTEGER,
				"value": null,
			},
			"RightExpressionDataValueType": {
				"type": Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"dataValueType": Terrasoft.DataValueType.INTEGER,
				"value": null,
			},
			/**
			 * Expression reference schema.
			 * @type {Object}
			 */
			"ReferenceSchema": {
				"type": Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"dataValueType": Terrasoft.DataValueType.CUSTOM_OBJECT,
				"value": null
			},
			/**
			 * Expression column map.
			 * @type {Object}
			 */
			"ExpressionMap": {
				"type": Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"dataValueType": Terrasoft.DataValueType.CUSTOM_OBJECT,
				"value": {
					"leftExpression": {
						"valuePropertyName": "LeftExpressionValue",
						"typePropertyName": "LeftExpressionType",
						"dataModelName": "LeftExpressionDataModelName",
						"dataValueTypeName": "ExpressionDataValueType"
					},
					"rightExpression": {
						"valuePropertyName": "RightExpressionValue",
						"typePropertyName": "RightExpressionType",
						"dataModelName": "RightExpressionDataModelName",
						"dataValueTypeName": "RightExpressionDataValueType"
					}
				}
			},
			/**
			 * Invalid column field message text.
			 * @type {String}
			 */
			"InvalidFieldMessage": {
				"type": Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"dataValueType": Terrasoft.DataValueType.TEXT,
				"value": resources.localizableStrings.InvalidFieldMessage
			},
			/**
			 * Left expression is empty message text.
			 * @type {String}
			 */
			"LeftExpressionIsEmptyMessage": {
				"type": Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"dataValueType": Terrasoft.DataValueType.TEXT,
				"value": resources.localizableStrings.LeftExpressionIsEmptyMessage
			},
			/**
			 * Comparion type is empty message text.
			 * @type {String}
			 */
			"ComparisonTypeIsEmptyMessage": {
				"type": Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"dataValueType": Terrasoft.DataValueType.TEXT,
				"value": resources.localizableStrings.ComparisonTypeIsEmptyMessage
			},
			/**
			 * Right expression is empty message text.
			 * @type {String}
			 */
			"RightExpressionIsEmptyMessage": {
				"type": Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"dataValueType": Terrasoft.DataValueType.TEXT,
				"value": resources.localizableStrings.RightExpressionIsEmptyMessage
			},
			/**
			 * Left expression data model name.
			 * @type {String}
			 */
			"LeftExpressionDataModelName": {
				"type": Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"dataValueType": Terrasoft.DataValueType.TEXT,
				"value": null
			},
			/**
			 * Right expression data model name.
			 * @type {String}
			 */
			"RightExpressionDataModelName": {
				"type": Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"dataValueType": Terrasoft.DataValueType.TEXT,
				"value": null
			}
		},

		_onExpressionDataValueTypeChanged: function() {
			const leftExpressionDataValueType = this.get("ExpressionDataValueType");
			const leftExpression = this.get("LeftExpressionValue");
			const leftExpressionType = this.get("LeftExpressionType");
			const rightExpressionDataValueType =
				this._getRightExpressionDataValueType(leftExpressionDataValueType, leftExpressionType, leftExpression);
			this.set("RightExpressionDataValueType", rightExpressionDataValueType);
		},

		_getRightExpressionDataValueType: function(leftExpressionDataValueType, leftExpressionType, leftExpression) {
			if (leftExpressionType === Terrasoft.ExpressionEnums.ExpressionType.SYSVALUE &&
				leftExpression?.value === Terrasoft.SystemValueType.CURRENT_USER_ROLES) {
				return Terrasoft.DataValueType.LOOKUP;
			} else {
				return leftExpressionDataValueType;
			}
		},

		_onRightExpressionDataValueTypeChanged: function() {
			const expressionDataValueType = this.get("ExpressionDataValueType");
			const rightExpressionDataValueType = this.get("RightExpressionDataValueType");
			const areTypesCompatible = Terrasoft.Features.getIsDisabled(
        		"BRules-DisableDifferentDataValueTypesCompatibility"
			)
			? this._areDataTypesCompatible(
				expressionDataValueType,
				rightExpressionDataValueType
			)
			: expressionDataValueType === rightExpressionDataValueType;
			if (!areTypesCompatible) {
				const leftExpression = this.get("LeftExpressionValue");
				const leftExpressionType = this.get("LeftExpressionType");
				const leftExpressionIsUserInRoleSysValue =
					leftExpressionType === Terrasoft.ExpressionEnums.ExpressionType.SYSVALUE &&
					leftExpression?.value === Terrasoft.SystemValueType.CURRENT_USER_ROLES;
				if (!leftExpressionIsUserInRoleSysValue) {
					this.set("ExpressionDataValueType", rightExpressionDataValueType);
				}
			}
		},
		
		/**
		 * Checks if two data value types are compatible for comparison.
		 * @private
		 * @param {Terrasoft.DataValueType} leftType Left expression data value type.
		 * @param {Terrasoft.DataValueType} rightType Right expression data value type.
		 * @return {Boolean} True if types are compatible, false otherwise.
		 */
		_areDataTypesCompatible: function(leftType, rightType) {
			if (leftType === rightType) {
				return true;
			}
			const referenceTypes = [Terrasoft.DataValueType.GUID, Terrasoft.DataValueType.LOOKUP, Terrasoft.DataValueType.IMAGELOOKUP];
			if (Terrasoft.contains(referenceTypes, leftType) && Terrasoft.contains(referenceTypes, rightType)) {
				return true;
			}
			if (Terrasoft.isTextDataValueType(leftType) && Terrasoft.isTextDataValueType(rightType)) {
				return true;
			}
			if (Terrasoft.isNumberDataValueType(leftType) && Terrasoft.isNumberDataValueType(rightType)) {
				return true;
			}
			return false;
		},

		/**
		 * Returns list of available comparison type names.
		 * @private
		 * @return {Array} List of available comparison type names.
		 */
		getAvailableComparisonTypeNames: function() {
			if (this._checkIsExpressionOfAttributeTypeWithUnSupportedDataTypes()) {
				return ["IS_NULL", "IS_NOT_NULL"];
			}
			const leftExpressionType = this.get("LeftExpressionType");
			const comparisonTypes = ["EQUAL", "NOT_EQUAL"];
			if (leftExpressionType === Terrasoft.ExpressionEnums.ExpressionType.SYSVALUE) {
				const leftExpressionValue = this.get("LeftExpressionValue");
				if (leftExpressionValue?.dataValueType === Terrasoft.DataValueType.OBJECT_LIST) {
					return ["CONTAIN", "NOT_CONTAIN"];
				}
			}
			if (leftExpressionType !== Terrasoft.ExpressionEnums.ExpressionType.CONSTANT &&
				leftExpressionType !== Terrasoft.ExpressionEnums.ExpressionType.SYSVALUE) {
				comparisonTypes.push("IS_NULL", "IS_NOT_NULL");
			}
			let dataValueType = this.get("LeftExpressionValue")?.dataValueType;
			if (!dataValueType && leftExpressionType === Terrasoft.ExpressionEnums.ExpressionType.CONSTANT) {
				dataValueType = this.get("ExpressionDataValueType");
			}
			const isEnabledFreedomUINumericAndDateComparisonTypes =
				Terrasoft.Features.getIsDisabled("BRules-DisableFreedomUINumericAndDateComparisonTypes");
			if (isEnabledFreedomUINumericAndDateComparisonTypes && 
				(Terrasoft.isNumberDataValueType(dataValueType) || Terrasoft.isDateDataValueType(dataValueType))) {
				comparisonTypes.push('GREATER', 'GREATER_OR_EQUAL', 'LESS', 'LESS_OR_EQUAL');
			}
			return comparisonTypes;
		},

		/**
		 * @private
		 */
		_getSupportedDataValueTypes: function() {
			return [
				Terrasoft.DataValueType.TEXT,
				Terrasoft.DataValueType.SHORT_TEXT,
				Terrasoft.DataValueType.MEDIUM_TEXT,
				Terrasoft.DataValueType.MAXSIZE_TEXT,
				Terrasoft.DataValueType.LONG_TEXT,
				Terrasoft.DataValueType.INTEGER,
				Terrasoft.DataValueType.FLOAT,
				Terrasoft.DataValueType.FLOAT0,
				Terrasoft.DataValueType.FLOAT1,
				Terrasoft.DataValueType.FLOAT2,
				Terrasoft.DataValueType.FLOAT3,
				Terrasoft.DataValueType.FLOAT4,
				Terrasoft.DataValueType.FLOAT8,
				Terrasoft.DataValueType.DATE_TIME,
				Terrasoft.DataValueType.DATE,
				Terrasoft.DataValueType.TIME,
				Terrasoft.DataValueType.LOOKUP,
				Terrasoft.DataValueType.BOOLEAN,
				Terrasoft.DataValueType.WEB_TEXT,
				Terrasoft.DataValueType.EMAIL_TEXT,
				Terrasoft.DataValueType.PHONE_TEXT,
				Terrasoft.DataValueType.RICH_TEXT
			];
		},

		/**
		 * @private
		 */
		_getSupportedTypesValidator: function() {
			const supportedTypes = this._getSupportedDataValueTypes();
			return function(dataValueType) {
				return Terrasoft.contains(supportedTypes, dataValueType);
			};
		},

		/**
		 * @private
		 */
		_getDefaultValidatorByDataValueType: function(dataValueType) {
			let validator;
			switch (dataValueType) {
				case Terrasoft.DataValueType.INTEGER:
				case Terrasoft.DataValueType.MONEY:
				case Terrasoft.DataValueType.MONEY0:
				case Terrasoft.DataValueType.MONEY1:
				case Terrasoft.DataValueType.MONEY3:
				case Terrasoft.DataValueType.FLOAT:
				case Terrasoft.DataValueType.FLOAT0:
				case Terrasoft.DataValueType.FLOAT1:
				case Terrasoft.DataValueType.FLOAT2:
				case Terrasoft.DataValueType.FLOAT3:
				case Terrasoft.DataValueType.FLOAT4:
				case Terrasoft.DataValueType.FLOAT8:
					validator = Terrasoft.isNumberDataValueType;
					break;
				case Terrasoft.DataValueType.DATE_TIME:
					validator = Terrasoft.isValidForMappingOnDateDataValueType;
					break;
				case Terrasoft.DataValueType.TIME:
					validator = function(itemDataValueType) {
						return itemDataValueType === Terrasoft.DataValueType.TIME;
					};
					break;
				default:
					validator = Terrasoft.findDataValueTypeValidator(dataValueType);
			}
			return validator;
		},

		/**
		 * @private
		 */
		_getDefaultValidatorByExpression: function(expressionType, expression, dataValueType) {
			let validator;
			switch (expressionType) {
				case Terrasoft.ExpressionEnums.ExpressionType.COLUMN:
				case Terrasoft.ExpressionEnums.ExpressionType.PARAMETER:
				case Terrasoft.ExpressionEnums.ExpressionType.CONSTANT:
				case Terrasoft.ExpressionEnums.ExpressionType.SYSVALUE:
					const systemValueType = expression?.value;
					if (systemValueType === Terrasoft.SystemValueType.CURRENT_USER_ROLES) {
						validator = function(itemDataValueType) {
							return itemDataValueType === Terrasoft.DataValueType.LOOKUP;
						};
					}
					validator = function(itemDataValueType) {
						return itemDataValueType === dataValueType;
					};
					break;
				case Terrasoft.ExpressionEnums.ExpressionType.ATTRIBUTE:
					validator = function(itemDataValueType) {
						return itemDataValueType === dataValueType;
					};
					break;
				default:
					validator = this._getDefaultValidatorByDataValueType(dataValueType);
			}
			return validator;
		},

		/**
		 * Returns list of comparison types.
		 * @private
		 * @return {Array} List of comparison types.
		 */
		getViewModelComparisonTypes: function() {
			const result = {};
			const availableComparisonTypeNames = this.getAvailableComparisonTypeNames();
			Terrasoft.each(availableComparisonTypeNames, function(comparisonTypeName) {
				result[Terrasoft.ComparisonType[comparisonTypeName]] =
					Terrasoft.Resources.ComparisonType[comparisonTypeName];
			}, this);
			return result;
		},

		/**
		 * Initializes comparison type list.
		 * @private
		 */
		initializeComparisonTypeList: function() {
			this.set("ComparisonTypeList", this.Ext.create("Terrasoft.BaseViewModelCollection"));
		},

		/**
		 * Prepares comparison type list.
		 */
		prepareComparisonTypeList: function() {
			const comparisonTypeList = this.get("ComparisonTypeList");
			const list = this.Ext.create("Terrasoft.BaseViewModelCollection");
			const viewModelComparisonTypes = this.getViewModelComparisonTypes();
			Terrasoft.each(viewModelComparisonTypes, function(comparisonTypeCaption, comparisonType) {
				list.addItem(this.Ext.create("Terrasoft.BaseViewModel", {
					values: {
						Caption: comparisonTypeCaption,
						Tag: {
							"type": parseInt(comparisonType, 10),
							"caption": comparisonTypeCaption
						},
						Click: {bindTo: "onComparisonTypeButtonClick"}
					}
				}));
			}, this);
			comparisonTypeList.reloadAll(list);
		},

		/**
		 * @private
		 */
		_prepareColumnExpression: function(expression, callback, scope) {
			const value = expression.getExpressionValue();
			if (Ext.isEmpty(value)) {
				Ext.callback(callback, scope, [{
					value: value,
					dataModelName: expression.dataModelName
				}]);
				return;
			}
			const dataSource = this.pageSchema.dataSources?.find(ds => ds.name === expression.dataModelName);
			const column = dataSource?.attributes?.find(attr => attr.value === expression.columnMetaPath);
			const expressionValue = {
				value: {
					value: value,
					name: expression.columnMetaPath,
					displayValue: column?.displayValue,
					dataValueType: column?.dataValueType
				},
				dataModelName: expression.dataModelName,
				referenceSchema: column?.referenceSchema
			};
			Ext.callback(callback, scope, [expressionValue]);
		},

		/**
		 * @param {Object} value SysValue.
		 * @param {Function} callback Callback function.
		 * @param {Object} scope Callback function scope.
		 * @private
		 */
		_prepareSysValueExpression: function(value, callback, scope) {
			let expressionValue;
			if (Ext.isEmpty(value)) {
				expressionValue = {value: value};
			} else {
				expressionValue = {
					value: {
						value: value,
						displayValue: this.getSysValueCaption(value),
						dataValueType: this.findSysValueDataValueType(value)
					},
					referenceSchema: this.getSysValueReferenceSchema(value)
				};
			}
			Ext.callback(callback, scope, [expressionValue]);
		},

		/**
		 * @private
		 */
		_getExpressionTypeList: function() {
			const Type = Terrasoft.ExpressionEnums.ExpressionType;
			const typeList = [Type.ATTRIBUTE];
			if (this.pageSchema?.dataSources?.length > 0) {
				typeList.push(Type.DATASOURCE);
			}
			typeList.push(Type.CONSTANT, Type.SYSSETTING, Type.SYSVALUE);
			return typeList;
		},

		/**
		 * Prepares expression from attribute.
		 * @param {Object} expression Expression value.
		 * @param {Function} callback Callback function.
		 * @param {Object} scope Callback function scope.
		 * @private
		 */
		_prepareAttributeExpression: function(expression, callback, scope) {
			let attributeName = expression.getExpressionValue();
			const attribute = this.getAttributeByName(attributeName);
			callback.call(scope, {value: attribute});
		},

        /**
		 * Check is expression type of attribute expression (column, attribute)
		 * and data value type is one of not supported.
         * @private
         */
        _checkIsExpressionOfAttributeTypeWithUnSupportedDataTypes: function() {
			if (Terrasoft.Features.getIsEnabled("BRules-EnableCompareLargeAttributeValues")) {
				return false;
			}
            const expressionDataValueType = this.get("ExpressionDataValueType");
            const leftExpressionType = this.get("LeftExpressionType");
            return ["ColumnBusinessRuleExpression", "AttributeBusinessRuleExpression"].includes(leftExpressionType) &&
                [Terrasoft.DataValueType.RICH_TEXT, Terrasoft.DataValueType.IMAGE].includes(expressionDataValueType);
        },

		/**
		 * Check whether element can be displayed in right expression elements list
		 * @private
		 */
		_canDisplayAttributeInRightExpressionList: function() {
			return function(element) {
				if (Terrasoft.Features.getIsEnabled("BRules-EnableCompareLargeAttributeValues")) {
					return true;
				}
				return ![Terrasoft.DataValueType.RICH_TEXT, Terrasoft.DataValueType.IMAGE].includes(
					element.dataValueType)
			}
		},

		/**
		 * Comparison type button click handler.
		 * @throws {Terrasoft.ArgumentNullOrEmptyException}
		 * @param  {Object} tag Tag.
		 */
		onComparisonTypeButtonClick: function(tag) {
			if (!tag) {
				throw new Terrasoft.ArgumentNullOrEmptyException({argumentName: "tag"});
			}
			this.set("ComparisonType", tag.type);
			this.set("ComparisonTypeCaption", tag.caption);
		},

		/**
		 * @inheritdoc Terrasoft.BR7xElementDesignerViewModel#getConfigForEmptyMetaItem
		 * @override
		 */
		getConfigForEmptyMetaItem: function() {
			var config = this.callParent(arguments);
			var leftExpression;
			if (this.isEntitySchemaBased()) {
				leftExpression = {
					"type": Terrasoft.ExpressionEnums.ExpressionType.COLUMN,
					"dataValueType": Terrasoft.DataValueType.TEXT,
					"columnMetaPath": null,
					"dataModelName": this.getFirstEntitySchemaName()
				};
			} else {
				leftExpression = {
					"type": Terrasoft.ExpressionEnums.ExpressionType.ATTRIBUTE,
					"dataValueType": Terrasoft.DataValueType.TEXT
				};
			}
			Ext.apply(config, {
				"type": "ComparisonBusinessRuleCondition",
				"comparisonType": Terrasoft.ComparisonType.EQUAL,
				"leftExpression": leftExpression,
				"rightExpression": {
					"type": "ConstantBusinessRuleExpression",
					"dataValueType": Terrasoft.DataValueType.TEXT,
					"value": null
				}
			});
			return config;
		},

		/**
		 * Sets comparison type.
		 * @protected
		 * @param {Terrasoft.ComparisonType} comparisonType Comparison type.
		 */
		setComparisonType: function(comparisonType) {
			this.set("ComparisonType", comparisonType);
			var comparisonTypeName = this.Ext.Object.getKey(Terrasoft.ComparisonType, comparisonType);
			this.set("ComparisonTypeCaption", Terrasoft.Resources.ComparisonType[comparisonTypeName]);
		},

		/**
		 * Prepares comparison type.
		 * @protected
		 */
		prepareComparisonType: function() {
			var metaItem = this.getMetaItem();
			var comparisonType = metaItem.getPropertyValue("comparisonType");
			this.setComparisonType(comparisonType);
		},

		/**
		 * Returns expressions data value type by  condition meta item.
		 * @protected
		 * @param  {Terrasoft.BaseBusinessRuleCondition} metaItem Condition meta item.
		 * @return {Terrasoft.DataValueType} Data value type.
		 */
		getExpressionDataValueType: function(metaItem) {
			var leftExpression = metaItem.getPropertyValue("leftExpression");
			var dataValueType = leftExpression && leftExpression.getPropertyValue("dataValueType");
			if (Ext.isEmpty(dataValueType)) {
				var rightExpression = metaItem.getPropertyValue("rightExpression");
				dataValueType = rightExpression && rightExpression.getPropertyValue("dataValueType");
				if (Ext.isEmpty(dataValueType)) {
					dataValueType = Terrasoft.DataValueType.TEXT;
				}
			}
			return dataValueType;
		},

		/**
		 * Returns expression type by expression meta item.
		 * @protected
		 * @param {Terrasoft.BaseBusinessRuleExpression} expressionMetaItem Expression meta item.
		 * @return {String} Expression type.
		 */
		getExpressionTypeFromMetaItem: function(expressionMetaItem) {
			var typeInfo = expressionMetaItem.getTypeInfo();
			return Terrasoft.BusinessRuleElementHelper.getTypeByClassName(typeInfo.fullTypeName);
		},

		/**
		 * @protected
		 * @param  {Terrasoft.BaseBusinessRuleCondition} metaItem Condition meta item.
		 */
		getExpressionsConfig: function(metaItem) {
			const expressionDataValueType = this.getExpressionDataValueType(metaItem);
			return {
				metaItem: metaItem,
				dataValueType: Terrasoft.getBaseDataValueType(expressionDataValueType)
			};
		},

		/**
		 * Prepares condition expressions.
		 * @protected
		 * @param {Function} callback Callback method.
		 * @param {Object} scope Callback method context.
		 */
		prepareExpressions: function(callback, scope) {
			const metaItem = this.getMetaItem();
			const config = this.getExpressionsConfig(metaItem);
			Terrasoft.chain(
				function(next) {
					this.prepareLeftExpression(config, next, this);
				},
				function(next) {
					this.prepareRightExpression(config, next, this);
				},
				function(next) {
					config.referenceSchema = config.leftExpressionReferenceSchema ||
						(this.isRequiredRightExpression() && config.rightExpressionReferenceSchema);
					this.prepareLeftExpressionValue(config, next, this);
				},
				function(next) {
					this.prepareRightExpressionValue(config, next, this);
				},
				function() {
					this.setPreparedPropertiesIntoViewModel(config);
					callback.call(scope);
				},
				this);
		},

		/**
		 * Sets prepared properties into condition view model.
		 * @protected
		 * @param {Object} config Prepared properties.
		 * @param {String} config.leftExpressionType Left expression type.
		 * @param {String} config.rightExpressionType Right expression type.
		 * @param {Terrasoft.DataValueType} config.dataValueType Data value type.
		 * @param {Object} config.referenceSchema Reference schema.
		 * @param {Mixed} config.leftExpressionValue Left expression value.
		 * @param {Mixed} config.rightExpressionValue Right expression value.
		 * @param {String} config.leftExpressionDataModelName Left expression data model name.
		 * @param {String} config.rightExpressionDataModelName Right expression data model name.
		 */
		setPreparedPropertiesIntoViewModel: function(config) {
			this.set("LeftExpressionDataModelName", config.leftExpressionDataModelName);
			this.set("RightExpressionDataModelName", config.rightExpressionDataModelName);
			this.set("LeftExpressionType", config.leftExpressionType);
			this.set("RightExpressionType", config.rightExpressionType);
			this.set("ExpressionDataValueType", config.dataValueType);
			this.set("RightExpressionDataValueType", config.rightExpressionDataValueType);
			this.set("ReferenceSchema", config.referenceSchema);
			this.set("LeftExpressionValue", config.leftExpressionValue);
			this.set("RightExpressionValue", config.rightExpressionValue)
		},

		/**
		 * Prepares left expression.
		 * @protected
		 * @param {Object} config Left expression prepare config.
		 * @param {Terrasoft.BaseBusinessRuleExpression} config.metaItem Left expression meta item.
		 * @param {Function} callback Callback method.
		 * @param {Object} scope Callback method context.
		 */
		prepareLeftExpression: function(config, callback, scope) {
			var metaItem = config.metaItem;
			var leftExpressionMetaItem = metaItem.getPropertyValue("leftExpression");
			this.prepareExpression(leftExpressionMetaItem, function(response) {
				if (leftExpressionMetaItem) {
					Ext.apply(config, {
						leftExpressionType: this.getExpressionTypeFromMetaItem(leftExpressionMetaItem),
						leftExpressionReferenceSchema: response.referenceSchema || response.value?.referenceSchema,
						leftExpressionValue: response.value,
						leftExpressionDataModelName: response.dataModelName
					});
				}
				callback.call(scope);
			}, this);
		},

		/**
		 * Prepares right expression.
		 * @protected
		 * @param {Object} config Right expression prepare config.
		 * @param {Terrasoft.BaseBusinessRuleExpression} config.metaItem Right expression meta item.
		 * @param {Function} next Callback method.
		 * @param {Object} scope Callback method context.
		 */
		prepareRightExpression: function(config, next, scope) {
			const metaItem = config.metaItem;
			const comparisonType = metaItem.getPropertyValue("comparisonType");
			if (comparisonType === Terrasoft.ComparisonType.IS_NULL || comparisonType === Terrasoft.ComparisonType.IS_NOT_NULL) {
				Ext.callback(next, scope, [config]);
				return;
			}
			const rightExpressionMetaItem = metaItem.getPropertyValue("rightExpression");
			this.prepareExpression(rightExpressionMetaItem, function(response) {
				if (rightExpressionMetaItem) {
					const rightExpressionDataValueType = this._getRightExpressionDataValueType(config.dataValueType,
						config.leftExpressionType, config.leftExpressionValue);
					Ext.apply(config, {
						rightExpressionDataValueType: rightExpressionDataValueType,
						rightExpressionType: this.getExpressionTypeFromMetaItem(rightExpressionMetaItem),
						rightExpressionReferenceSchema: response.referenceSchema,
						rightExpressionValue: response.value,
						rightExpressionDataModelName: response.dataModelName
					});
				}
				Ext.callback(next, scope, [config]);
			}, this);
		},

		/**
		 * Prepares expression.
		 * @protected
		 * @param {Terrasoft.BaseBusinessRuleExpression} expression Expression meta item.
		 * @param {Function} callback Callback method.
		 * @param {Object} scope Callback method context.
		 */
		prepareExpression: function(expression, callback, scope) {
			const type = expression && this.getExpressionTypeFromMetaItem(expression);
			const value = expression?.getExpressionValue();
			switch (type) {
				case Terrasoft.ExpressionEnums.ExpressionType.COLUMN:
					this._prepareColumnExpression(expression, callback, scope);
					break;
				case Terrasoft.ExpressionEnums.ExpressionType.ATTRIBUTE:
					this._prepareAttributeExpression(expression, callback, scope);
					break;
				case Terrasoft.ExpressionEnums.ExpressionType.SYSVALUE:
					this._prepareSysValueExpression(value, callback, scope);
					break;
				case Terrasoft.ExpressionEnums.ExpressionType.CONSTANT:
					const response = {
						value: value
					}
					const dataValueType = expression.dataValueType;
					if (dataValueType === Terrasoft.DataValueType.LOOKUP) {
						const referenceSchemaName = expression.referenceSchemaName;
						const referenceSchema = Terrasoft.EntitySchemaManager.findItemByName(referenceSchemaName);
						if (referenceSchema) {
							response.referenceSchema = {
								displayValue: referenceSchema.caption,
								name: referenceSchema.name,
								value: referenceSchema.uId
							};
						}
					}
					Ext.callback(callback, scope, [response]);
					break;
				default:
					Ext.callback(callback, scope, [{value: value}]);
			}
		},

		/**
		 * Prepares left expression value.
		 * @protected
		 * @param {Object} config Prepare config.
		 * @param {String} config.leftExpressionType Left expression type.
		 * @param {Terrasoft.DataValueType} config.dataValueType Data value type.
		 * @param {Object} config.referenceSchema Reference schema.
		 * @param {Mixed} config.leftExpressionValue Left expression value.
		 * @param {Function} callback Callback method.
		 * @param {Object} scope Callback method context.
		 */
		prepareLeftExpressionValue: function(config, callback, scope) {
			var internalConfig = {
				expressionType: config.leftExpressionType,
				dataValueType: config.dataValueType,
				referenceSchema: config.referenceSchema,
				value: config.leftExpressionValue
			};
			this.prepareExpressionValue(internalConfig, function(value) {
				config.leftExpressionValue = value;
				callback.call(scope);
			}, this);
		},

		/**
		 * Prepares right expression value.
		 * @protected
		 * @param {Object} config Prepare config.
		 * @param {String} config.rightExpressionType Right expression type.
		 * @param {Terrasoft.DataValueType} config.dataValueType Data value type.
		 * @param {Object} config.referenceSchema Reference schema.
		 * @param {Mixed} config.rightExpressionValue Right expression value.
		 * @param {Function} callback Callback method.
		 * @param {Object} scope Callback method context.
		 */
		prepareRightExpressionValue: function(config, callback, scope) {
			if (!this.isRequiredRightExpression()) {
				callback.call(scope);
				return;
			}
			var internalConfig = {
				expressionType: config.rightExpressionType,
				dataValueType: config.rightExpressionDataValueType,
				referenceSchema: config.referenceSchema,
				value: config.rightExpressionValue
			};
			this.prepareExpressionValue(internalConfig, function(value) {
				config.rightExpressionValue = value;
				callback.call(scope);
			}, this);
		},

		/**
		 * Prepares expression value.
		 * @protected
		 * @param {Object} config Prepare config.
		 * @param {Mixed} config.value Expression value.
		 * @param {Function} callback Callback method.
		 * @param {Object} scope Callback method context.
		 */
		prepareExpressionValue: function(config, callback, scope) {
			if (this.isLookupConstantValue(config)) {
				this.requireExpressionValue(config, callback, scope);
			} else {
				callback.call(scope, config.value);
			}
		},

		/**
		 * Requires expression lookup value.
		 * @protected
		 * @param {Object} config Require config.
		 * @param {Object} config.referenceSchema Reference schema.
		 * @param {GUID} config.value Value.
		 * @param {Function} callback Callback method.
		 * @param {Object} scope Callback method context.
		 */
		requireExpressionValue: function(config, callback, scope) {
			var referenceSchema = config.referenceSchema;
			var value = config.value;
			Terrasoft.chain(
				function(next) {
					next({"entitySchemaName": referenceSchema.name});
				},
				this.getEntitySchemaLookupQueryConfig,
				this.generateEntitySchemaLookupQuery,
				function(next, esq, queryConfig) {
					esq.rowCount = 1;
					if (Terrasoft.isGUID(value)) {
						esq.enablePrimaryColumnFilter(value);
					} else {
						var filter = Terrasoft.createColumnFilterWithParameter(Terrasoft.ComparisonType.EQUAL,
							queryConfig.primaryDisplayColumnName, value);
						esq.filters.add("displayFilter", filter);
					}
					esq.getEntityCollection(function(response) {
						var responseValue;
						var collection = response && response.collection;
						var success = response && response.success;
						if (success && collection && collection.getCount()) {
							var entity = collection.getByIndex(0);
							responseValue = {
								"value": entity.get("value"),
								"displayValue": entity.get("displayValue")
							};
						}
						callback.call(scope, responseValue);
					}, this);
				},
				this);
		},

		/**
		 * Returns true, when expression type is constant and data value type is lookup and value is GUID
		 * and reference schema is not empty, false - otherwise.
		 * @protected
		 * @param {Object} config Check config.
		 * @param {Object} config.referenceSchema Reference schema.
		 * @param {String} config.expressionType Expression type.
		 * @param {Terrasoft.DataValueType} config.dataValueType Data value type.
		 * @param {Mixed} config.value Value.
		 * @return {Boolean}
		 */
		isLookupConstantValue: function(config) {
			var referenceSchema = config.referenceSchema;
			var referenceSchemaName = referenceSchema && referenceSchema.name;
			return config.expressionType === Terrasoft.ExpressionEnums.ExpressionType.CONSTANT &&
				Terrasoft.isLookupDataValueType(config.dataValueType) &&
				!Ext.isEmpty(referenceSchemaName);
		},

		/**
		 * Prepares expression value enum list.
		 * @protected
		 * @param {String} expressionType Expression type.
		 * @param {String} filter Filter value.
		 * @param {Terrasoft.Collection} list Value collection.
		 */
		prepareExpressionValueList: function(expressionType, filter, list) {
			var referenceSchema = this.get("ReferenceSchema");
			var referenceSchemaName = referenceSchema && referenceSchema.name;
			this.mixins.ExpressionEditVMMixin.prepareValueList(filter, list, expressionType, referenceSchemaName);
		},

		/**
		 * Prepares left expression value enum list.
		 * @protected
		 * @param {String} filter Filter value.
		 * @param {Terrasoft.Collection} list Value collection.
		 */
		prepareLeftExpressionValueList: function(filter, list) {
			this.prepareExpressionValueList(this.get("LeftExpressionType"), filter, list);
		},

		/**
		 * Prepares right expression value enum list.
		 * @protected
		 * @param {String} filter Filter value.
		 * @param {Terrasoft.Collection} list Value collection.
		 */
		prepareRightExpressionValueList: function(filter, list) {
			const leftExpressionIsUserInRoleSysValue =
				this.$LeftExpressionType === Terrasoft.ExpressionEnums.ExpressionType.SYSVALUE &&
				this.$LeftExpressionValue?.value === Terrasoft.SystemValueType.CURRENT_USER_ROLES;
			if (!leftExpressionIsUserInRoleSysValue) {
				this.prepareExpressionValueList(this.get("RightExpressionType"), filter, list);
				return;
			}
			const roleFilter = this.Terrasoft.createColumnInFilterWithParameters("SysAdminUnitTypeValue", [
				ConfigurationConstants.SysAdminUnit.Type.Organisation,
				ConfigurationConstants.SysAdminUnit.Type.Department,
				ConfigurationConstants.SysAdminUnit.Type.Manager,
				ConfigurationConstants.SysAdminUnit.Type.Team,
				ConfigurationConstants.SysAdminUnit.Type.FuncRole,
			]);
			const filterConfig = {
				esqFilter: roleFilter,
				filterValue: filter
			};
			this.prepareExpressionValueList(this.get("RightExpressionType"), filterConfig, list);
		},

		/**
		 * Creates expression meta item from view model.
		 * @protected
		 * @param {String} expressionName Expression name.
		 * @return {Terrasoft.BaseBusinessRuleExpression} Business rule expression.
		 */
		createExpressionMetaItemFromViewModel: function(expressionName) {
			const expressionPropertyNameMap = this.get("ExpressionMap")[expressionName];
			const expressionType = this.get(expressionPropertyNameMap.typePropertyName);
			if (!expressionType) {
				return null;
			}
			const viewModelValue = this.get(expressionPropertyNameMap.valuePropertyName);
			let expressionDataValueType = this.get(expressionPropertyNameMap.dataValueTypeName);
			if (Terrasoft.isEmpty(viewModelValue) &&
				(expressionType !== Terrasoft.ExpressionEnums.ExpressionType.CONSTANT
				|| expressionDataValueType === Terrasoft.DataValueType.LOOKUP)) {
				return null;
			}
			const className = Terrasoft.BusinessRuleElementHelper.getClassNameByType(expressionType);
			const expression = this.Ext.create(className);
			let expressionValue, dataModelName;
			switch (expressionType) {
				case Terrasoft.ExpressionEnums.ExpressionType.COLUMN:
				case Terrasoft.ExpressionEnums.ExpressionType.ATTRIBUTE:
					expressionDataValueType = viewModelValue.dataValueType;
					expressionValue = viewModelValue.value;
					dataModelName = this.get(expressionPropertyNameMap.dataModelName);
					expression.setPropertyValue("dataModelName", dataModelName);
					break;
				case Terrasoft.ExpressionEnums.ExpressionType.SYSVALUE:
					expressionValue = viewModelValue.value;
					break;
				case Terrasoft.ExpressionEnums.ExpressionType.CONSTANT:
					if (expressionDataValueType === Terrasoft.DataValueType.LOOKUP) {
						expressionValue = viewModelValue.value;
					} else {
						expressionValue = viewModelValue;
					}
					const referenceSchema = this.get("ReferenceSchema");
					if (referenceSchema) {
						expression.setPropertyValue("referenceSchemaName", referenceSchema.name);
					}
					break;
				default:
					expressionValue = viewModelValue;
			}
			expression.setPropertyValue("dataValueType", expressionDataValueType);
			expression.setExpressionValue(expressionValue);
			return expression;
		},

		/**
		 * Returns true, if require set right expression, false - otherwise.
		 * @protected
		 * @return {Boolean} True, if require set right expression, false - otherwise.
		 */
		isRequiredRightExpression: function() {
			var comparisonType = this.get("ComparisonType");
			return comparisonType !== Terrasoft.ComparisonType.IS_NULL &&
				comparisonType !== Terrasoft.ComparisonType.IS_NOT_NULL;
		},

		/**
		 * Returns true, if can change comparison type, false - otherwise.
		 * @protected
		 * @return {Boolean} True, if can change comparison type, false - otherwise.
		 */
		canDesignComparisonType: function() {
			return !this.Ext.isEmpty(this.get("LeftExpressionValue"));
		},

		/**
		 * Returns true, if can change right expression, false - otherwise.
		 * @protected
		 * @return {Boolean} True, if can change right expression, false - otherwise.
		 */
		canDesignRightExpression: function() {
			const canDesignComparisonType = this.canDesignComparisonType();
			const isComparisonTypeEmpty = Ext.isEmpty(this.get("ComparisonType"));
			const isRequiredRightExpression = this.isRequiredRightExpression();
			return canDesignComparisonType && !isComparisonTypeEmpty && isRequiredRightExpression;
		},

		/**
		 * Returns true, if can change right expression data value type, false - otherwise.
		 * @protected
		 * @return {Boolean} True, if can change right expression data value type, false - otherwise.
		 */
		getCanChangeRightExpressionDataValueType: function() {
			var leftExpressionType = this.get("LeftExpressionType");
			var expressionTypeEnum = Terrasoft.ExpressionEnums.ExpressionType;
			var expressionList = [
				expressionTypeEnum.SYSSETTING,
				expressionTypeEnum.SYSVALUE,
				expressionTypeEnum.ATTRIBUTE
			];
			return Ext.Array.contains(expressionList, leftExpressionType);
		},

		getIsComparisonTypeInList: function(comparisonType) {
			const comparisonTypeList = this.get("ComparisonTypeList");
			return !!comparisonTypeList.findByPath('$Tag.type', comparisonType);
		},

		getDefaultComparisonType: function() {
			const defaultComparisonType = Terrasoft.ComparisonType.EQUAL;
			if (!this.getIsComparisonTypeInList(defaultComparisonType)) {
				const comparisonTypeList = this.get("ComparisonTypeList");
				return comparisonTypeList.first()?.$Tag?.type;
			}
			return defaultComparisonType;
		},

		updateComparisonType: function() {
			const comparisonTypeList = this.get("ComparisonTypeList");
			const currentComparisonType = this.get("ComparisonType");
			if (this.Ext.isEmpty(currentComparisonType)) {
				if (this._checkIsExpressionOfAttributeTypeWithUnSupportedDataTypes()) {
					this.setComparisonType(Terrasoft.ComparisonType.IS_NOT_NULL);
				} else {
					const comparisonType = this.getDefaultComparisonType();
					this.setComparisonType(comparisonType);
				}
			} else {
				const currentComparisonTypeItem = comparisonTypeList.findByPath('$Tag.type', currentComparisonType);
				if (!currentComparisonTypeItem) {
					const comparisonType = this.getDefaultComparisonType();
					this.setComparisonType(comparisonType);
				}
			}
		},

		/**
		 * Left expression value change handler.
		 * @protected
		 */
		onLeftExpressionValueChanged: function() {
			if (this.canDesignComparisonType()) {
				this.prepareComparisonTypeList();
				const value = this.get("LeftExpressionValue");
				const typeEnum = Terrasoft.ExpressionEnums.ExpressionType;
				const type = this.get("LeftExpressionType");
				this.updateComparisonType();
				switch (type) {
					case typeEnum.COLUMN:
					case typeEnum.PARAMETER:
					case typeEnum.ATTRIBUTE:
						this.set("ExpressionDataValueType", value.dataValueType);
						this.set("ReferenceSchema", value.referenceSchema);
						this.set("LeftExpressionValue", value);
						break;
					case typeEnum.SYSSETTING:
						this.getSysSettingDataValueType(value, function(dataValueType) {
							this.set("ExpressionDataValueType", dataValueType ?? Terrasoft.DataValueType.TEXT);
						}, this);
						break;
					case typeEnum.SYSVALUE:
						this.set("ExpressionDataValueType", value.dataValueType);
						this.set("ReferenceSchema", this.getSysValueReferenceSchema(value.value));
						break;
					default:
				}
			} else {
				this.setComparisonType(null);
				this.set("ReferenceSchema", null);
			}
		},

		/**
		 * Returns reference schema for system value.
		 * @private
		 * @param {Terrasoft.SystemValueType} expressionValue System value type.
		 * @return {Object} Data value type.
		 */
		getSysValueReferenceSchema: function(expressionValue) {
			var ACCOUNT_SCHEMA_UID = "25d7c1ab-1de0-4501-b402-02e0e5a72d6e";
			var CONTACT_SCHEMA_UID = "16be3651-8fe2-4159-8dd0-a803d4683dd3";
			var SYS_ADMIN_USER_SCHEMA_UID = "84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c";
			var uId;
			switch (expressionValue) {
				case Terrasoft.SystemValueType.CURRENT_USER:
				case Terrasoft.SystemValueType.CURRENT_USER_ROLES:
					uId = SYS_ADMIN_USER_SCHEMA_UID;
					break;
				case Terrasoft.SystemValueType.CURRENT_USER_CONTACT:
					uId = CONTACT_SCHEMA_UID;
					break;
				case Terrasoft.SystemValueType.CURRENT_USER_ACCOUNT:
					uId = ACCOUNT_SCHEMA_UID;
					break;
				default:
					return null;
			}
			var referenceSchema = Terrasoft.EntitySchemaManager.getItem(uId);
			return {
				displayValue: referenceSchema.caption,
				name: referenceSchema.name,
				value: referenceSchema.uId
			};
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
		 * Comparison type change handler.
		 * @protected
		 */
		onComparisonTypeChanged: function() {
			if (!this.canDesignRightExpression()) {
				this.set("RightExpressionValue", null);
				this.set("RightExpressionType", null);
			}
		},

		/**
		 * Validates condition.
		 * @protected
		 * @param  {Function} next Callback method.
		 * @param  {Object} validationInfo Validation info.
		 */
		validateCondition: function(next, validationInfo) {
			var comparisonType = this.get("ComparisonType");
			if (Ext.isEmpty(comparisonType)) {
				validationInfo.isValid = false;
				validationInfo.messageList.push(this.get("ComparisonTypeIsEmptyMessage"));
			}
			next(validationInfo);
		},

		/**
		 * Returns left expression async validate config.
		 * @param {Object} validationInfo Validation info.
		 * @return {Object} Left expression async validate config
		 */
		getAsyncValidateLeftExpressionConfig: function(validationInfo) {
			return {
				"expressionType": this.get("LeftExpressionType"),
				"referenceSchema": this.get("ReferenceSchema"),
				"dataValueType": this.get("ExpressionDataValueType"),
				"value": this.get("LeftExpressionValue"),
				"columnCaption": this.get("LeftExpressionIsEmptyMessage"),
				"validationInfo": validationInfo
			};
		},

		/**
		 * Validates left expression.
		 * @protected
		 * @param  {Function} next Callback method.
		 * @param  {Object} validationInfo Validation info.
		 */
		asyncValidateLeftExpression: function(next, validationInfo) {
			var config = this.getAsyncValidateLeftExpressionConfig(validationInfo);
			this.asyncValidateExpression(config, function() {
				next(validationInfo);
			}, this);
		},

		/**
		 * Returns right expression async validate config.
		 * @param {Object} validationInfo Validation info.
		 * @return {Object} Right expression async validate config
		 */
		getAsyncValidateRightExpressionConfig: function(validationInfo) {
			return {
				"expressionType": this.get("RightExpressionType"),
				"referenceSchema": this.get("ReferenceSchema"),
				"dataValueType": this.get("RightExpressionDataValueType"),
				"value": this.get("RightExpressionValue"),
				"columnCaption": this.get("RightExpressionIsEmptyMessage"),
				"validationInfo": validationInfo
			};
		},

		/**
		 * Validates right expression.
		 * @protected
		 * @param  {Function} next Callback method.
		 * @param  {Object} validationInfo Validation info.
		 */
		asyncValidateRightExpression: function(next, validationInfo) {
			var config = this.getAsyncValidateRightExpressionConfig(validationInfo);
			this.asyncValidateExpression(config, function() {
				next(validationInfo);
			}, this);
		},

		/**
		 * @protected
		 * @return {Terrasoft.BaseBusinessRuleExpression} Business rule expression.
		 */
		createLeftExpressionMetaItem: function() {
			return this.createExpressionMetaItemFromViewModel("leftExpression");
		},

		/**
		 * @protected
		 * @return {Terrasoft.BaseBusinessRuleExpression} Business rule expression.
		 */
		createRightExpressionMetaItem: function() {
			let rightExpression = null;
			if (this.isRequiredRightExpression()) {
				rightExpression = this.createExpressionMetaItemFromViewModel("rightExpression");
			}
			return rightExpression;
		},

		/**
		 * @inheritdoc Terrasoft.BR7xElementDesignerViewModel#getMetaItemUpdaters
		 * @override
		 */
		getMetaItemUpdaters: function() {
			var updaters = this.callParent(arguments);
			updaters.push(function(callback, metaItem) {
				metaItem.setPropertyValue("comparisonType", this.get("ComparisonType"));
				callback();
			});
			updaters.push(function(callback, metaItem) {
				const leftExpression = this.createLeftExpressionMetaItem();
				if (leftExpression) {
					leftExpression.uId = metaItem.leftExpression?.uId;
				}
				metaItem.setPropertyValue("leftExpression", leftExpression);
				callback();
			});
			updaters.push(function(callback, metaItem) {
				const rightExpression = this.createRightExpressionMetaItem();
				if (rightExpression) {
					rightExpression.uId = metaItem.rightExpression?.uId;
				}
				metaItem.setPropertyValue("rightExpression", rightExpression);
				callback();
			});
			return updaters;
		},

		/**
		 * @inheritdoc Terrasoft.BR7xElementDesignerViewModel#getAsyncValidateList
		 * @override
		 */
		getAsyncValidators: function() {
			var validationMethods = this.callParent();
			validationMethods.push(this.validateCondition, this.asyncValidateLeftExpression);
			if (this.isRequiredRightExpression()) {
				validationMethods.push(this.asyncValidateRightExpression);
			}
			return validationMethods;
		},

		/**
		 * @inheritdoc Terrasoft.BaseObject#onDestroy
		 * @override
		 */
		onDestroy: function() {
			this.un("change:LeftExpressionValue", this.onLeftExpressionValueChanged, this);
			this.un("change:ComparisonType", this.onComparisonTypeChanged, this);
			this.un("change:LeftExpressionType", this.onLeftExpressionTypeChanged, this);
			this.un("change:LeftExpressionDataModelName", this.onLeftExpressionDataModelNameChanged, this);
			this.un("change:RightExpressionDataModelName", this.onRightExpressionDataModelNameChanged, this);
			this.un("change:ExpressionDataValueType", this._onExpressionDataValueTypeChanged, this);
			this.un("change:RightExpressionDataValueType", this._onRightExpressionDataValueTypeChanged, this);
			this.callParent(arguments);
		},

		/**
		 * Prepares left expression entity schema column list.
		 * @protected
		 * @param {Object} filter Filter config.
		 * @param {Terrasoft.Collection} list List.
		 */
		prepareLeftExpressionEntitySchemaColumnList: function(filter, list) {
			const builder = Ext.create("Terrasoft.BusinessRuleExpressionDataQueryBuilder");
			this.prepareDataSourceColumnList.call(this, {
				filterValue: filter,
				filterFns: [builder.buildSupportedDataValueTypeFilter()]
			}, list, 'LeftExpressionDataModelName');
		},

		prepareDataSourceColumnList: function(filterConfig, outList, dataModelName, callback) {
			const self = this;
			this._loadToCollection(function(builder) {
				const filterValue = filterConfig.filterValue || "";
				const filterFns = filterConfig.filterFns || [];
				const filters = [
					builder.buildSimpleValueFilter({
						filterValue: filterValue,
						valueSelector: (column) => column.displayValue,
					})
				].concat(filterFns);
				return builder
					.from((callback) => {
						const items = [];
						const dataSourceName = self.changedValues[dataModelName];
						const dataSource = self.pageSchema.dataSources?.find(ds => ds.name === dataSourceName);
						const attributes = dataSource.attributes;
						attributes.forEach((attribute) => {
							items.push({
								value: attribute.value,
								displayValue: attribute.displayValue,
								dataValueType: attribute.dataValueType,
								referenceSchema: attribute.referenceSchema,
							})
						});
						callback(items);
					})
					.then(builder.filter(filters))
					.then(builder.sortByDisplayValue())
					.then(builder.toCollection());
			}, outList, callback);
		},

		/**
		 * Prepares left expression system values list.
		 * @param {Object} filter Filter config.
		 * @param {Terrasoft.core.collections.Collection} list Collection to fill with system values.
		 */
		prepareLeftExpressionSysValuesList: function(filter, list) {
			const disableCurrentUserRolesSysValue =
				Terrasoft.Features.getIsEnabled('BRules-DisableCurrentUserRolesSysValue');
			const filerFn = filter?.filterFn ?? function () { return true; };
			const filterConfig = {
				filterValue: Ext.isString(filter) ? filter : "",
				filterFn: function(sysValue) {
					if (sysValue.sysValueName === Terrasoft.SystemValueType.CURRENT_USER_ROLES &&
						disableCurrentUserRolesSysValue) {
						return false;
					}
					return filerFn(sysValue);
				}
			};
			this.mixins.ExpressionEditVMMixin.prepareSysValuesList.call(this, filterConfig, list);
		},

		/**
		 * Prepares left expression constants list.
		 * @param {String} filter Control filter.
		 * @param {Terrasoft.core.collections.Collection} list Collection to fill with constants.
		 */
		prepareLeftExpressionConstantsList: function(filter, list) {
			const filterConfig = {};
			filterConfig.filterValue = Ext.isString(filter) ? filter : "";
			filterConfig.filterFn = this._getSupportedTypesValidator();
			this.mixins.ExpressionEditVMMixin.prepareConstantList.call(this, filterConfig, list);
		},

		/**
		 * Prepares data source list.
		 * @param {Terrasoft.core.collections.Collection} list Collection to fill with data source.
		 */
		loadDataSources: function(list) {
			if (!list) {
				return;
			}
			const dataSources = this.pageSchema?.dataSources?.map((dataSource) => [
				dataSource.name,
				{
					value: dataSource.name,
					displayValue: dataSource.caption,
				},
			]) || [];
			list.reloadAll(Object.fromEntries(dataSources));
		},

		/**
		 * Prepares expression attributes list.
		 * @protected
		 * @param {String} filter Filter
		 * @param {Terrasoft.core.collections.Collection} list Collection to fill with system values.
		 */
		prepareLeftExpressionAttributesList: function(filter, list) {
			if (!list) {
				return;
			}
			const collection = new Terrasoft.Collection();
			const attributes = this.getAttributes();
			attributes.forEach((attribute) => {
				collection.add(attribute.value, attribute);
			});
			list.reloadAll(collection);
		},

		/**
		 * Prepares expression attributes list.
		 * @protected
		 * @param {String} filter Filter
		 * @param {Terrasoft.core.collections.Collection} list Collection to fill with system values.
		 */
		prepareRightExpressionAttributesList: function(filter, list) {
			if (!list) {
				return;
			}
			const builder = new Terrasoft.BusinessRuleExpressionDataQueryBuilder();
			const config = {
				dataValueType: this.$RightExpressionDataValueType,
				referenceSchemaName: this.$ReferenceSchema?.name,
			};
			const filterFn = builder.buildPageSchemaAttributeByDataValueTypeFilter(config);
			const collection = new Terrasoft.Collection();
			const attributes = this.getAttributes();
			attributes
				.filter(filterFn)
				.filter(this._canDisplayAttributeInRightExpressionList())
				.forEach((a) => {
					collection.add(a.value, a);
				});
			list.reloadAll(collection);
		},

		/**
		 * Prepares left expression entity schema column list.
		 * @protected
		 * @param {String} filter Search value.
		 * @param {Terrasoft.Collection} list List.
		 */
		prepareLeftExpressionPageSchemaParameterList: function(filter, list) {
			const builder = Ext.create("Terrasoft.BusinessRuleExpressionDataQueryBuilder");
			this.mixins.ExpressionEditVMMixin.preparePageSchemaParameterList.call(this, {
				pageSchemaUId: this.pageSchemaUId,
				packageUId: this.packageUId
			}, {
				filterValue: filter,
				filterFns: [
					builder.buildNonSystemPageSchemaParameterFilter(),
					builder.buildSupportedDataValueTypeFilter()
				]
			}, list);
		},

		/**
		 * Prepares right expression entity schema column list.
		 * @protected
		 * @param {String} filter Search value.
		 * @param {Terrasoft.Collection} list List.
		 */
		prepareRightExpressionPageSchemaParameterList: function(filter, list) {
			const builder = Ext.create("Terrasoft.BusinessRuleExpressionDataQueryBuilder");
			this.mixins.ExpressionEditVMMixin.preparePageSchemaParameterList.call(this, {
				pageSchemaUId: this.pageSchemaUId,
				packageUId: this.packageUId
			}, {
				filterValue: filter,
				filterFns: [
					builder.buildNonSystemPageSchemaParameterFilter(),
					builder.buildSupportedDataValueTypeFilter(),
					builder.buildPageSchemaParameterByDataValueTypeFilter({
						dataValueType: this.$RightExpressionDataValueType,
						referenceSchemaUId: this.$ReferenceSchema && this.$ReferenceSchema.value
					})
				]
			}, list);
		},

		/**
		 * Prepares right expression system values list.
		 * @param {String} filter Control filter.
		 * @param {Terrasoft.core.collections.Collection} list Collection to fill with system values.
		 */
		prepareRightExpressionSysValuesList: function(filter, list) {
			const builder = Ext.create("Terrasoft.BusinessRuleExpressionDataQueryBuilder");
			const filterConfig = {
				filterValue: Ext.isString(filter) ? filter : "",
				filterFn: builder.buildSysValueByDataValueTypeFilter({
					dataValueType: this.$RightExpressionDataValueType,
					referenceSchemaName: this.$ReferenceSchema && this.$ReferenceSchema.name
				})
			};
			this.mixins.ExpressionEditVMMixin.prepareSysValuesList.call(this, filterConfig, list);
		},

		/**
		 * Prepares right expression constants list.
		 * @param {String} filter Control filter.
		 * @param {Terrasoft.core.collections.Collection} list Collection to fill with constants.
		 */
		prepareRightExpressionConstantsList: function(filter, list) {
			const filterConfig = {};
			filterConfig.filterValue = Ext.isString(filter) ? filter : "";
			const leftExpressionType = this.get("LeftExpressionType");
			const leftExpression = this.get("LeftExpressionValue");
			const dataValueType = this.get("RightExpressionDataValueType");
			if (leftExpressionType && !Terrasoft.isEmpty(dataValueType)) {
				filterConfig.filterFn = this._getDefaultValidatorByExpression(leftExpressionType,
					leftExpression, dataValueType);
			} else {
				filterConfig.filterFn = this._getSupportedTypesValidator();
			}
			this.mixins.ExpressionEditVMMixin.prepareConstantList.call(this, filterConfig, list);
		},

		/**
		 * Prepares right expression entity schema column list.
		 * @protected
		 * @param {String} filter Control filter.
		 * @param {Terrasoft.Collection} list List.
		 */
		prepareRightExpressionEntitySchemaColumnList: function(filter, list) {
			const builder = Ext.create("Terrasoft.BusinessRuleExpressionDataQueryBuilder");
			this.prepareDataSourceColumnList.call(this, {
				filterValue: filter,
				filterFns: [
					builder.buildSupportedDataValueTypeFilter(),
					builder.buildPageSchemaAttributeByDataValueTypeFilter({
						dataValueType: this.$RightExpressionDataValueType,
						referenceSchemaName: this.$ReferenceSchema?.name,
					}),
					this._canDisplayAttributeInRightExpressionList()
				]
			}, list, 'RightExpressionDataModelName');
		},

		/**
		 * Left expression type change event handler.
		 * @protected
		 */
		onLeftExpressionTypeChanged: function() {
			this.prepareComparisonTypeList();
		},

		/**
		 * Left expression data model change event handler.
		 * @protected
		 */
		onLeftExpressionDataModelNameChanged: function(model, dataModelName) {},

		/**
		 * Right expression data model change event handler.
		 * @protected
		 */
		onRightExpressionDataModelNameChanged: function(model, dataModelName) {},

		/**
		 * Returns left expression type list.
		 * @protected
		 * @return {Array}
		 */
		getLeftExpressionTypeList: function() {
			return this._getExpressionTypeList();
		},

		/**
		 * Returns right expression type list.
		 * @protected
		 * @return {Array}
		 */
		getRightExpressionTypeList: function() {
			return this._getExpressionTypeList();
		},

		/**
		 * Returns left expression control config.
		 * @protected
		 * @return {Object} Left expression control config.
		 */
		getLeftExpressionControlConfig: function() {
			return {
				"className": "Terrasoft.BR7xExpressionEdit",
				"loadDataSources": {"bindTo": "loadDataSources"},
				"expressionType": {"bindTo": "LeftExpressionType"},
				"expressionTypeList": this.getLeftExpressionTypeList(),
				"dataValueType": {"bindTo": "ExpressionDataValueType"},
				"referenceSchema": {"bindTo": "ReferenceSchema"},
				"prepareReferenceSchemaList": {"bindTo": "prepareReferenceSchemaList"},
				"prepareValueList": {"bindTo": "prepareLeftExpressionValueList"},
				"prepareEntitySchemaColumnList": {"bindTo": "prepareLeftExpressionEntitySchemaColumnList"},
				"preparePageSchemaParameterList": {"bindTo": "prepareLeftExpressionPageSchemaParameterList"},
				"prepareSysValuesList": {"bindTo": "prepareLeftExpressionSysValuesList"},
				"prepareConstantList": {"bindTo": "prepareLeftExpressionConstantsList"},
				"prepareAttributesList": {"bindTo": "prepareLeftExpressionAttributesList"},
				"dataModelName": {"bindTo": "LeftExpressionDataModelName"},
				"value": {"bindTo": "LeftExpressionValue"},
				"canUseSysSettings": true,
				"wrapClass": "condition-left-expression",
			};
		},

		/**
		 * Returns right expression control config.
		 * @protected
		 * @return {Object} Right expression control config.
		 */
		getRightExpressionControlConfig: function() {
			return {
				"className": "Terrasoft.BR7xExpressionEdit",
				"loadDataSources": {"bindTo": "loadDataSources"},
				"expressionType": {"bindTo": "RightExpressionType"},
				"expressionTypeList": this.getRightExpressionTypeList(),
				"dataValueType": {"bindTo": "RightExpressionDataValueType"},
				"referenceSchema": {"bindTo": "ReferenceSchema"},
				"prepareReferenceSchemaList": {"bindTo": "prepareReferenceSchemaList"},
				"prepareValueList": {"bindTo": "prepareRightExpressionValueList"},
				"prepareEntitySchemaColumnList": {"bindTo": "prepareRightExpressionEntitySchemaColumnList"},
				"preparePageSchemaParameterList": {"bindTo": "prepareRightExpressionPageSchemaParameterList"},
				"prepareSysValuesList": {"bindTo": "prepareRightExpressionSysValuesList"},
				"prepareConstantList": {"bindTo": "prepareRightExpressionConstantsList"},
				"prepareAttributesList": {"bindTo": "prepareRightExpressionAttributesList"},
				"dataModelName": {"bindTo": "RightExpressionDataModelName"},
				"value": {"bindTo": "RightExpressionValue"},
				"canChangeReferenceSchema": false,
				"canUseSysSettings": true,
				"visible": {"bindTo": "canDesignRightExpression"},
				"wrapClass": "condition-right-expression",
			};
		},

		/**
		 * Returns comparison type control config.
		 * @protected
		 * @return {Object} Comparison type control config.
		 */
		getComparisonTypeControlConfig: function() {
			return {
				"className": "Terrasoft.Container",
				"classes": {"wrapClassName": ["case-condition-comparison-type-container"]},
				"items": [{
					"className": "Terrasoft.Button",
					"style": Terrasoft.controls.ButtonEnums.style.TRANSPARENT,
					"caption": {"bindTo": "ComparisonTypeCaption"},
					"menu": {"items": {"bindTo": "ComparisonTypeList"}},
					"markerValue": "ExpressionComparisonTypeButton"
				}],
				"visible": {"bindTo": "canDesignComparisonType"}
			};
		},

		/**
		 * @inheritdoc Terrasoft.BaseObject#constructor
		 * @override
		 */
		constructor: function() {
			this.callParent(arguments);
			this.initializeComparisonTypeList();
			this.prepareExpressions(function() {
				this.on("change:LeftExpressionValue", this.onLeftExpressionValueChanged, this);
				this.on("change:ComparisonType", this.onComparisonTypeChanged, this);
				this.on("change:LeftExpressionType", this.onLeftExpressionTypeChanged, this);
				this.on("change:LeftExpressionDataModelName", this.onLeftExpressionDataModelNameChanged, this);
				this.on("change:RightExpressionDataModelName", this.onRightExpressionDataModelNameChanged, this);
				this.on("change:ExpressionDataValueType", this._onExpressionDataValueTypeChanged, this);
				this.on("change:RightExpressionDataValueType", this._onRightExpressionDataValueTypeChanged, this);
				this.prepareComparisonTypeList();
				this.prepareComparisonType();
				this.completeLoaded();
			}, this);
		},

		/**
		 * Returns view config.
		 * @return {Object} View config.
		 */
		getViewConfig: function() {
			return {
				"className": "Terrasoft.Container",
				"items": [
					this.getLeftExpressionControlConfig(),
					this.getComparisonTypeControlConfig(),
					this.getRightExpressionControlConfig()
				]
			};
		}
	});

	return Terrasoft.BusinessRule7xConditionDesignerViewModel;
});


