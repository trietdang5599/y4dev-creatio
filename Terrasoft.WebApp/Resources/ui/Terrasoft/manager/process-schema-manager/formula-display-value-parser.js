/**
 */
Ext.define("Terrasoft.manager.FormulaDisplayValueParser", {
	extend: "Terrasoft.FormulaParser",
	alternateClassName: "Terrasoft.FormulaDisplayValueParser",

	/**
	 * @private
	 */
	_findEntitySchemaInstance: function(findSchemaConfig, callback, scope) {
		const isEnabled = Terrasoft.Features.getIsEnabled("AutoAddPackageDependenciesInProcesses");
		if (isEnabled) {
			Terrasoft.EntitySchemaManager.findAggregatedSchemaInstance(findSchemaConfig, callback, scope);
		} else {
			Terrasoft.EntitySchemaManager.findBundleSchemaInstance(findSchemaConfig, callback, scope);
		}
	},

	/**
	 * @inheritdoc Terrasoft.FormulaParser#getMacrosHandlers
	 * @protected
	 * @override
	 */
	getMacrosHandlers: function() {
		const handlers = Ext.create("Terrasoft.Collection");
		handlers.add(this.functions.SysSettingsDisplayPrefix, this.sysSettingsMacrosHandler);
		handlers.add(this.functions.LookupValueDisplayPrefix, this.lookupMacrosHandler);
		handlers.add(this.functions.MainRecordDisplayPrefix, this.mainRecordMacrosHandler);
		handlers.add(this.functions.BooleanDisplayPrefix, this.booleanMacrosHandler);
		handlers.add(this.functions.SysVariableDisplayPrefix, this.sysVariableMacrosHandler);
		handlers.add(this.functions.CaptionPropertyValueDisplayPrefix, this.propertyValueMacrosHandler);
		handlers.add(this.functions.DateValueDisplayPrefix, this.dateMacrosHandler);
		handlers.add(this.functions.TimeValueDisplayPrefix, this.timeMacrosHandler);
		handlers.add(this.functions.DateTimeValueDisplayPrefix, this.dateTimeMacrosHandler);
		return handlers;
	},

	/**
	 * @inheritdoc Terrasoft.FormulaParser#defaultMacrosHandlerw
	 * @protected
	 * @override
	 */
	defaultMacrosHandler: function(macros) {
		this.processParameterMacrosChainHandler(macros);
	},

	/**
	 * System settings macros handler.
	 * @private
	 * @param macros {Terrasoft.FormulaMacros} Parsing macros.
	 */
	sysSettingsMacrosHandler: function(macros) {
		const service = Terrasoft.ServiceProvider;
		const sysSettingName = macros.getChainWithoutPrefix();
		const config = {
			sysSettingsNameCollection: [sysSettingName],
			columnName: "Name"
		};
		service.executeRequest(Terrasoft.SysSettings.querySettingsMethodName, config, function(response) {
			if (response.success && response.values.hasOwnProperty(sysSettingName)) {
				const sysSetting = response.values[sysSettingName];
				const sysSettingCode = sysSetting.code;
				const result = Terrasoft.FormulaMacros.prepareSysSettingValue(sysSettingCode, sysSetting.typeName);
				this.endHandler(result);
			} else {
				this.endHandlerWithError(this.exceptions.InvalidSysSettingMessage, sysSettingName);
			}
		}, this);
	},

	/**
	 * @private
	 */
	_findTopExtendedPackageItemCaption: function(items, item) {
		const extendedPackageItems = items.filter((x)=> x.getName() === item.getName());
		return extendedPackageItems.last()?.getCaption() || item.getCaption();
	},

	/**
	 * @private
	 */
	_findSchemaItemByCaption: function(items, caption) {
		return items.findByFn((item) => item.getCaption() === caption &&
			this._findTopExtendedPackageItemCaption(items, item) === caption);
	},

	/**
	 * Lookup macros handler.
	 * @private
	 * @param macros {Terrasoft.FormulaMacros} Parsing macros.
	 */
	lookupMacrosHandler: function(macros) {
		const schemaCaption = macros.getParameterAfterPrefix();
		const iterator = Terrasoft.getEnumerator(macros.getParametersWithoutPrefix());
		let lookupDisplayValue = null;
		let entitySchemaUId = null;
		Terrasoft.chain(
			function(next) {
				Terrasoft.EntitySchemaManager.initialize(next, this);
			},
			function(next) {
				Terrasoft.EntitySchemaManager.findSortedByTopologyItems({
					includeExtensionItems: true,
					callback: next,
					scope: this
				});
			},
			function(next, itemsSortByHierarchy) {
				const parameterSchemaConfig = this.findElementWithDotsInCaption(iterator,
					(caption) => this._findSchemaItemByCaption(itemsSortByHierarchy, caption), this);
				const parameterSchema = parameterSchemaConfig.element;
				if (!parameterSchema) {
					this.endHandlerWithError(this.exceptions.InvalidEntitySchemaMessage, schemaCaption);
					return;
				}
				const rootSchema = Terrasoft.EntitySchemaManager.findRootSchemaItemByName(parameterSchema.name);
				const findSchemaConfig = {
					schemaUId: rootSchema.uId,
					packageUId: rootSchema.packageUId
				};
				this._findEntitySchemaInstance(findSchemaConfig, next, this);
			},
			function(next, entitySchema) {
				if (!entitySchema) {
					this.endHandlerWithError(this.exceptions.InvalidEntitySchemaMessage, schemaCaption);
					return;
				}
				entitySchemaUId = entitySchema.uId;
				lookupDisplayValue = this.getParametersChainFromIterator(iterator);
				if (!lookupDisplayValue) {
					this.endHandlerWithError(this.exceptions.InvalidLookupEmptyValueMessage);
					return;
				}
				const query = this.prepareLookupEntitySchemaQuery(entitySchema, lookupDisplayValue);
				query.getEntityCollection(next, this);
			},
			function(next, response) {
				const lookupItem = this.getLookupItemFromResponce(response);
				if (!lookupItem) {
					if (response.errorInfo) {
						this.log(response.errorInfo.message);
					}
					this.endHandlerWithError(this.exceptions.InvalidLookupValueMessage, lookupDisplayValue);
					return;
				}
				const lookupItemId = lookupItem.get("Id");
				const resultMacros = Terrasoft.FormulaMacros.prepareLookupValue(entitySchemaUId, lookupItemId);
				this.endHandler(resultMacros);
			},
			this
		);
	},

	/**
	 * Main record macros handler.
	 * @private
	 * @param macros {Terrasoft.FormulaMacros} Parsing macros.
	 */
	mainRecordMacrosHandler: function(macros) {
		const entitySchema = this.schema.entitySchema;
		if (!entitySchema) {
			this.endHandlerWithError(this.exceptions.InvalidMainRecordUsageMessage);
			return;
		}
		const path = macros.getChainWithoutPrefix();
		entitySchema.getColumnMetaPathByCaptionPath(path, function(parametersChain) {
			if (!parametersChain) {
				this.endHandlerWithError(this.exceptions.InvalidMainRecordPathMessage);
				return;
			}
			const resultMacros = Terrasoft.FormulaMacros.prepareMainRecordValue(parametersChain);
			this.endHandler(resultMacros);
		}, this);
	},

	/**
	 * Boolean macros handler.
	 * @private
	 * @param macros {Terrasoft.FormulaMacros} Parsing macros.
	 */
	booleanMacrosHandler: function(macros) {
		let booleanValue;
		const booleanDisplayValue = macros.getParameterAfterPrefix();
		switch(booleanDisplayValue) {
			case this.functions.BooleanDisplayTrueValue:
				booleanValue = this.constants.BOOLEAN_MACROS_TRUE_VALUE;
				break;
			case this.functions.BooleanDisplayFalseValue:
				booleanValue = this.constants.BOOLEAN_MACROS_FALSE_VALUE;
				break;
			default:
				this.endHandlerWithError(this.exceptions.InvalidBooleanValueMessage, booleanDisplayValue);
				return;
		}
		const resultMacros = Terrasoft.FormulaMacros.prepareBooleanValue(booleanValue);
		this.endHandler(resultMacros);
	},

	/**
	 * Property value macros handler.
	 * @private
	 */
	propertyValueMacrosHandler: function() {
		const value = this.constants.PROPERTY_VALUE_MACROS_CAPTION;
		const resultMacros = Terrasoft.FormulaMacros.preparePropertyValue(value);
		this.endHandler(resultMacros);
	},

	/**
	 * System variable macros handler.
	 * @private
	 * @param macros {Terrasoft.FormulaMacros} Parsing macros.
	 */
	sysVariableMacrosHandler: function(macros) {
		const displayValue = macros.getChainWithoutPrefix();
		let value = "";
		this.constants.SYS_VARIABLES.some(function(sysVariable) {
			if (sysVariable.displayValue === displayValue) {
				value = sysVariable.value;
				return true;
			}
		});
		if (!value){
			this.endHandlerWithError(this.exceptions.InvalidSysVariableMessage, displayValue);
			return;
		}
		const resultMacros = Terrasoft.FormulaMacros.prepareSysVariableValue(value);
		this.endHandler(resultMacros);
	},

	/**
	 * Date macros handler.
	 * @private
	 * @param macros {Terrasoft.FormulaMacros} Parsing macros.
	 */
	dateMacrosHandler: function(macros) {
		this.baseDateTimeMacrosHandler(Terrasoft.DataValueType.DATE, macros);
	},

	/**
	 * Time macros handler.
	 * @private
	 * @param macros {Terrasoft.FormulaMacros} Parsing macros.
	 */
	timeMacrosHandler: function(macros) {
		this.baseDateTimeMacrosHandler(Terrasoft.DataValueType.TIME, macros);
	},

	/**
	 * Date time macros handler.
	 * @private
	 * @param macros {Terrasoft.FormulaMacros} Parsing macros.
	 */
	dateTimeMacrosHandler: function(macros) {
		this.baseDateTimeMacrosHandler(Terrasoft.DataValueType.DATE_TIME, macros);
	},

	/**
	 * Base date time macros handler.
	 * @param {Terrasoft.DataValueType} dataValueType Date time data value type.
	 * @param {Terrasoft.FormulaMacros} macros Parsing macros.
	 */
	baseDateTimeMacrosHandler: function(dataValueType, macros) {
		const config = Terrasoft.FormulaParserUtils.getDateTimeValueFormatConfig(dataValueType);
		const displayValue = macros.getBody().substr(config.displayPrefix.length);
		const date = Ext.Date.parse(displayValue, config.displayFormat);
		if (!date) {
			this.endHandlerWithError(config.invalidMessageTemplate, displayValue);
			return;
		}
		const dateValue = Ext.Date.format(date, config.valueFormat);
		const prefixWithoutDot = config.valuePrefix.slice(0, -1);
		const resultMacros = Ext.create("Terrasoft.FormulaMacros");
		resultMacros.addParameter(prefixWithoutDot);
		resultMacros.addParameter(dateValue);
		this.endHandler(resultMacros);
	},

	/**
	 * Process parameter macros chain handler.
	 * @private
	 * @param {Terrasoft.FormulaMacros} macros Parsing macros.
	 */
	processParameterMacrosChainHandler: function(macros) {
		const parameter = this.schema.findParameterByCaption(macros.getBody());
		if (parameter) {
			const resultMacros = Terrasoft.FormulaMacros.prepareProcessParameterValue(parameter.uId);
			this.endHandler(resultMacros);
		} else if (macros.getHasOneParameter()) {
			this.endHandlerWithError(this.exceptions.InvalidParameterMessage, macros.getPrefix());
		} else {
			this.processElementParameterMacrosChainHandler(macros);
		}
	},

	/**
	 * Process element parameter macros chain handler.
	 * @private
	 * @param {Terrasoft.FormulaMacros} macros Parsing macros.
	 */
	processElementParameterMacrosChainHandler: function(macros) {
		const config = this.prepareElementParameterConfig(macros);
		if (!config.flowElement) {
			this.endHandlerWithError(this.exceptions.InvalidFlowElementMessage, macros.getPrefix());
			return;
		}
		if (!config.parameter){
			this.endHandlerWithError(this.exceptions.InvalidParameterMessage, config.parameterCaption);
			return;
		}
		const flowElement = config.flowElement;
		if (this.getIsElementParameter(config)) {
			if (this.getIsFunctionParameter(config)) {
				this.functionResultMacrosChainHandler(flowElement);
			} else {
				const resultMacros = Terrasoft.FormulaMacros.prepareProcessElementParameterValue(flowElement.uId,
					config.parameter.uId);
				this.endHandler(resultMacros);
			}
		} else {
			this.entityColumnElementParameterMacrosChainHandler(macros, config);
		}
	},

	/**
	 * Process entity column element parameter macros chain handler.
	 * @private
	 * @param {Terrasoft.FormulaMacros} macros Parsing macros.
	 */
	entityColumnElementParameterMacrosChainHandler: function(macros, config) {
		const entitySchemaCaption = config.entitySchemaCaption;
		const flowElement = config.flowElement;
		const parameter = config.parameter;
		const schemaUId = parameter.referenceSchemaUId;
		if (!schemaUId) {
			this.endHandlerWithError(this.exceptions.InvalidSchemaUIdMessage);
			return;
		}
		const findSchemaConfig = {
			schemaUId: schemaUId,
			packageUId: this.schema.getPackageUId()
		};
		this._findEntitySchemaInstance(findSchemaConfig, function(entitySchema) {
			let resultMacros;
			if (!entitySchema) {
				resultMacros = macros;
			} else {
				const column = this.findEntityColumnByCaption(entitySchema, entitySchemaCaption);
				if (!column) {
					this.endHandlerWithError(this.exceptions.InvalidColumnMessage, entitySchemaCaption);
					return;
				}
				resultMacros = Terrasoft.FormulaMacros.prepareEntityColumnParameterValue(flowElement.uId,
					parameter.uId, column.uId);
			}
			this.endHandler(resultMacros);
		}, this);
	},

	/**
	 * Returns element parameter config.
	 * @private
	 * @param {Terrasoft.FormulaMacros} macros Parsing macros.
	 * @returns {Object} Element parameter config.
	 */
	prepareElementParameterConfig: function(macros) {
		const result = {};
		const iterator = Terrasoft.getEnumerator(macros.getParameters());
		const flowElementConfig = this.findElementWithDotsInCaption(iterator, function (caption) {
			return this.schema.findItemByCaption(caption);
		}, this);
		result.flowElement = flowElementConfig.element;
		result.flowElementCaption = flowElementConfig.caption;
		if (result.flowElement) {
			const parameterConfig = this.findElementWithDotsInCaption(iterator, function (caption) {
				return result.flowElement.findParameterByCaption(caption);
			}, this);
			result.parameter = parameterConfig.element;
			result.parameterCaption = parameterConfig.caption;
			result.entitySchemaCaption = this.getParametersChainFromIterator(iterator);
		}
		return result;
	},

	/**
	 * Returns true if macros is element parameter.
	 * @private
	 * @param {Object} config Element parameter config.
	 * @returns {Boolean} True if macros is element parameter.
	 */
	getIsElementParameter: function(config) {
		return Ext.isEmpty(config.entitySchemaCaption);
	},

	/**
	 * Returns true if macros is function parameter of read data element.
	 * @private
	 * @param {Object} config Element parameter config.
	 * @returns {Boolean} True if macros is function parameter of read data element.
	 */
	getIsFunctionParameter: function(config) {
		const readDataUserTaskSchemaUId = this.constants.READ_DATA_USER_TASK_SCHEMA_UID;
		const functionResultCaption = this.functions.FunctionResultCaption;
		const isElementReadDataUserTask = config.flowElement.managerItemUId === readDataUserTaskSchemaUId;
		const isParameterFunction = config.parameterCaption === functionResultCaption;
		return isElementReadDataUserTask && isParameterFunction;
	},

	/**
	 * Finds element by search function. Element caption can contain dots.
	 * @private
	 * @param {Object} iterator Macros iterator.
	 * @param {Function} searchFn Search function.
	 * @param {Object} scope Search function scope.
	 * @returns {Object} Search result.
	 */
	findElementWithDotsInCaption: function(iterator, searchFn, scope) {
		const macros = Ext.create("Terrasoft.FormulaMacros");
		let caption;
		let element;
		do {
			macros.addParameter(iterator.next());
			caption = macros.getBody();
			element = searchFn.call(scope, caption);
		} while(!element && iterator.hasNext());
		return {
			element: element,
			caption: element ? caption : macros.getPrefix()
		};
	},

	/**
	 * Finds entity column by caprion.
	 * @private
	 * @param {Object} entitySchema Entity schema.
	 * @param {String} entityColumnCaption Entity schema column caption.
	 * @returns {Object} Entity schema column.
	 */
	findEntityColumnByCaption: function(entitySchema, entityColumnCaption) {
		return entitySchema.columns.firstOrDefault(function(column) {
			const caption = column.caption;
			return caption && (caption.getValue() === entityColumnCaption);
		});
	},

	/**
	 * Read data function result macros handler.
	 * @private
	 * @param {Object} flowElement Process flow element.
	 */
	functionResultMacrosChainHandler: function(flowElement) {
		const functionResultCaption = this.functions.FunctionResultCaption;
		const flowElementCaption = flowElement.caption;
		const aggregateColumnNameParameter = flowElement.findParameterByName("AggregationColumnName");
		const aggregateColumnName = aggregateColumnNameParameter.getValue();
		const resultEntityParameter = flowElement.findParameterByName("ResultEntity");
		const referenceSchemaUId = resultEntityParameter.referenceSchemaUId;
		const config = {
			schemaUId: referenceSchemaUId,
			packageUId: flowElement.getPackageUId()
		};
		this._findEntitySchemaInstance(config, function(schema) {
			const dataValueType = this.findColumnDataValueType(schema, aggregateColumnName);
			const resultParameter = this.getFunctionResultParameter(flowElement, dataValueType);
			if (!resultParameter) {
				this.endHandlerWithError(this.exceptions.InvalidParameterOfFlowElementMessage, functionResultCaption,
					flowElementCaption);
				return;
			}
			const resultMacros = Terrasoft.FormulaMacros.prepareProcessElementParameterValue(flowElement.uId,
				resultParameter.uId);
			this.endHandler(resultMacros);
		}, this);
	},

	/**
	 * Returns column data value type.
	 * @private
	 * @param {Object} schema Entity schema.
	 * @param {String} columnName Entity schema column name.
	 * @returns {Terrasoft.DataValueType} Column data value type.
	 */
	findColumnDataValueType: function(schema, columnName) {
		let result = null;
		if (schema) {
			const column = schema.columns.firstOrDefault(function (currentColumn) {
				return currentColumn.name === columnName;
			}, this);
			result = column.dataValueType;
		}
		return result;
	},

	/**
	 * Returns function result parameter according to its data value type.
	 * @private
	 * @param {Object} flowElement Process flow element.
	 * @param {Terrasoft.DataValueType} dataValueType Function result data value type.
	 * @returns {Object} Function result parameter.
	 */
	getFunctionResultParameter: function(flowElement, dataValueType) {
		let resultParameter;
		if (dataValueType === Terrasoft.DataValueType.INTEGER) {
			resultParameter = flowElement.findParameterByName("ResultIntegerFunction");
		} else if (Terrasoft.isNumberDataValueType(dataValueType)) {
			resultParameter = flowElement.findParameterByName("ResultFloatFunction");
		} else if (Terrasoft.isDateDataValueType(dataValueType)) {
			resultParameter = flowElement.findParameterByName("ResultDateTimeFunction");
		} else {
			resultParameter = null;
		}
		return resultParameter;
	},

	/**
	 * Returns lookup entity schema query object.
	 * @private
	 * @param {Object} entitySchema Entity shema.
	 * @param {String} lookupDisplayValue Lookup display value.
	 * @returns {Terrasoft.EntitySchemaQuery} Lookmup entity schema query.
	 */
	prepareLookupEntitySchemaQuery: function(entitySchema, lookupDisplayValue) {
		const esq = Ext.create("Terrasoft.EntitySchemaQuery", {
			rootSchema: entitySchema
		});
		esq.addMacrosColumn(Terrasoft.QueryMacrosType.PRIMARY_COLUMN, "Id");
		esq.addMacrosColumn(Terrasoft.QueryMacrosType.PRIMARY_DISPLAY_COLUMN, "displayValue");
		const lookupId = lookupDisplayValue.split('.').pop();
		const filter = esq.createColumnFilterWithParameter(Terrasoft.ComparisonType.EQUAL,
			entitySchema.primaryColumn.name, lookupId);
		esq.filters.addItem(filter);
		return esq;
	},

	/**
	 * Returns lookup item from lookup query responce.
	 * @private
	 * @param {Object} response Lookup query responce.
	 * @returns {Object} Lookup object.
	 */
	getLookupItemFromResponce: function(response) {
		let result = null;
		const collection = response.collection;
		if (response.success && collection && !collection.isEmpty()) {
			result = collection.first();
		}
		return result;
	},

	/**
	 * Returns string chain of all remaining parameters in macros iterator.
	 * @private
	 * @param {Object} iterator Macros iterator.
	 * @returns {String} String chain of remaining macros parameters.
	 */
	getParametersChainFromIterator: function(iterator) {
		const macros = Ext.create("Terrasoft.FormulaMacros");
		do {
			macros.addParameter(iterator.next());
		} while(iterator.hasNext());
		return macros.getBody();
	}
});
