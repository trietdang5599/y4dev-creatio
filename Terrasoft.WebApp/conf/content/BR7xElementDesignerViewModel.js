Terrasoft.configuration.Structures["BR7xElementDesignerViewModel"] = {innerHierarchyStack: ["BR7xElementDesignerViewModel"]};
 define("BR7xElementDesignerViewModel", ["BR7xElementDesignerViewModelResources", "ExpressionEnums"
 ], function(resources) {

	Ext.define("Terrasoft.Designers.BR7xElementDesignerViewModel", {
		extend: "Terrasoft.model.BaseViewModel",
		alternateClassName: "Terrasoft.BR7xElementDesignerViewModel",

		/**
		 * Ext framework.
		 * @type {Object}
		 */
		Ext: null,

		/**
		 * Terrasoft framework.
		 * @type {Object}
		 */
		Terrasoft: null,

		/**
		 * sandbox.
		 * @type {Object}
		 */
		sandbox: null,

		// region Methods: Protected

		/**
		 * Entity schema identifier
		 * @type {String}
		 */
		entitySchemaUId: null,

		/**
		 * Business rules element utils instance
		 * @type {Terrasoft.BusinessRuleElementUtils}
		 */
		businessRuleElementUtils: null,

		/**
		 * Page schema identifier
		 * @type {String}
		 */
		pageSchema: null,

		/**
		 * Current package identifier.
		 * @type {String}
		 */
		packageUId: null,

		// region Methods: Protected

		/**
		 * Return business rule element util class instance.
		 * @protected
		 * @return {Terrasoft.BusinessRuleElementUtils} Business rule element util class instance.
		 */
		getBusinessRuleElementUtils: function() {
			if (!this.businessRuleElementUtils) {
				this.businessRuleElementUtils = Ext.create("Terrasoft.BusinessRuleElementUtils");
			}
			return this.businessRuleElementUtils;
		},

		/**
		 * @inheritdoc Terrasoft.BaseModel#getModelColumns
		 * @override
		 */
		getModelColumns: function() {
			var baseColumns = this.callParent(arguments);
			return this.Ext.apply(baseColumns, {
				"Id": {
					type: Terrasoft.core.enums.ViewModelColumnType.VIRTUAL_COLUMN,
					dataValueType: Terrasoft.core.enums.DataValueType.GUID
				},
				"MetaItem": {
					type: Terrasoft.core.enums.ViewModelColumnType.VIRTUAL_COLUMN,
					dataValueType: Terrasoft.core.enums.DataValueType.CUSTOM_OBJECT
				},
				"MetaItemType": {
					type: Terrasoft.core.enums.ViewModelColumnType.VIRTUAL_COLUMN,
					dataValueType: Terrasoft.core.enums.DataValueType.TEXT
				},
				"Loaded": {
					type: Terrasoft.core.enums.ViewModelColumnType.VIRTUAL_COLUMN,
					dataValueType: Terrasoft.core.enums.DataValueType.CUSTOM_OBJECT
				}
			});
		},

		/**
		 * Creates instance of class by class name with specified properties.
		 * @protected
		 * @param {String} className Name of class.
		 * @param {Object} columnValues Column values.
		 * @return {Terrasoft.BaseViewModel} Instance.
		 */
		createItemViewModel: function(className, columnValues) {
			this.updateMetaItemTypeFromMetaItem(columnValues);
			var viewModel = this.Ext.create(className, {
				Terrasoft: this.Terrasoft,
				sandbox: this.sandbox,
				Ext: this.Ext,
				entitySchemaUId: this.entitySchemaUId,
				pageSchema: this.pageSchema,
				packageUId: this.packageUId,
				values: this.Ext.apply({Id: Terrasoft.generateGUID()}, columnValues)
			});
			viewModel.on("change", this.onItemViewModelChange, this);
			return viewModel;
		},

		/**
		 * Item view model change handler.
		 * @protected
		 */
		onItemViewModelChange: function() {
			this.fireEvent("change");
		},

		/**
		 * Update meta item type from meta item.
		 * @protected
		 * @param  {Object} columnValues Column values.
		 */
		updateMetaItemTypeFromMetaItem: function(columnValues) {
			if (!Ext.isEmpty(columnValues)) {
				var metaItem = columnValues.MetaItem;
				if (!columnValues.MetaItemType && metaItem) {
					var typeInfo = metaItem.getTypeInfo();
					columnValues.MetaItemType = typeInfo.typeName;
				}
			}
		},

		/**
		 * Create meta item.
		 * @protected
		 * @return {Terrasoft.BaseBusinessRuleElement} Meta item.
		 */
		createMetaItem: function() {
			var metaItemType = this.get("MetaItemType");
			var utils = this.getBusinessRuleElementUtils();
			var config = this.getConfigForEmptyMetaItem();
			Ext.apply(config, {"type": metaItemType});
			return utils.createItem(config);
		},

		/**
		 * Return config for new meta item.
		 * @protected
		 * @return {Object} Config.
		 */
		getConfigForEmptyMetaItem: function() {
			return {};
		},

		/**
		 * Returns column path by column meta path.
		 * @protected
		 * @param {Object|String} config Config object or column uid.
		 * @param {String} config.entitySchemaUId Entity schema uid.
		 * @param {String} config.schemaColumnMetaPath Column uid.
		 * @param {Function} callback Callback function.
		 * @param {Object} scope Callback scope.
		 */
		getPathByMetaPath: function(config, callback, scope) {
			if (Ext.isString(config)) {
				config = {
					entitySchemaUId: this.entitySchemaUId,
					schemaColumnMetaPath: config
				};
			}
			Terrasoft.SchemaDesignerUtilities.getEntitySchemaColumnPathByMetaPath(config, function(response) {
				const dataValueType = Terrasoft.ServerDataValueType[response.columnDataValueTypeUId];
				const baseDataValueType = Terrasoft.getBaseDataValueType(dataValueType);
				callback.call(scope, {
					columnPath: response.columnPath,
					columnCaptionPath: response.columnCaptionPath,
					dataValueType: baseDataValueType,
					referenceSchemaUId: response.referenceSchemaUId
				});
			});
		},

		/**
		 * Return empty validate info.
		 * @protected
		 * @return {Object} Empty validate info.
		 */
		generateValidateInfo: function() {
			return {
				"isValid": true,
				"messageList": []
			};
		},

		/**
		 * Returns validators for async validate view model.
		 * @protected
		 * @return {Array} Async validators.
		 */
		getAsyncValidators: function() {
			return [];
		},

		/**
		 * Async validate items.
		 * @protected
		 * @param {Array} items Items for async validate.
		 * @param {Object} validateInfo Validate info.
		 * @param {Function} callback Callback method.
		 * @param {Object} scope Callback method scope.
		 */
		asyncValidateItems: function(items, validateInfo, callback, scope) {
			validateInfo = Ext.isEmpty(validateInfo)
				? this.generateValidateInfo()
				: validateInfo;
			if (items.length > 0) {
				Terrasoft.eachAsync(
					items,
					function(item, next) {
						item.asyncValidate(function(itemValidateInfo) {
							this.applyValidationInfo(validateInfo, itemValidateInfo);
							next(validateInfo);
						}, this);
					},
					function() {
						callback.call(scope, validateInfo);
					}, this);
			} else {
				callback.call(scope, validateInfo);
			}
		},

		/**
		 * Sync update meta item properties.
		 * @protected
		 * @param {Object} metaItem Meta item.
		 */
		syncUpdateMetaItem: Ext.emptyFn,

		/**
		 * Return meta item updaters.
		 * @protected
		 * @return {Array} Meta item updaters.
		 */
		getMetaItemUpdaters: function() {
			return [];
		},

		/**
		 * Async validate items.
		 * @protected
		 * @param {Array} items Items for update meta item.
		 * @param {Function} callback Callback method.
		 * @param {Object} scope Callback method scope.
		 */
		updateMetaItems: function(items, callback, scope) {
			Terrasoft.eachAsync(
				items,
				function(item, next) {
					item.updateMetaItem(next, this);
				},
				function() {
					callback.call(scope);
				}, this);
		},

		/**
		 * Apply two validation info.
		 * @protected
		 * @param {Object} validationInfo Validation info.
		 * @param {Object} sourceValidationInfo Source validation info.
		 */
		applyValidationInfo: function(validationInfo, sourceValidationInfo) {
			if (Ext.isEmpty(validationInfo) || Ext.isEmpty(sourceValidationInfo)) {
				return;
			}
			if (!sourceValidationInfo.isValid) {
				validationInfo.isValid = false;
				validationInfo.messageList = validationInfo.messageList.concat(sourceValidationInfo.messageList);
			}
		},

		/**
		 * Async validate expression.
		 * @protected
		 * @param {Object} config Expression config.
		 * @param {String} config.expressionType Expression type.
		 * @param {Function} callback Callback method.
		 * @param {Object} scope Callback method context.
		 */
		asyncValidateExpression: function(config, callback, scope) {
			if (!this.validateEmptyValue(config)) {
				callback.call(scope);
			} else {
				var validator = this.getAsyncExpressionValidatorByExpressionType(config.expressionType);
				if (Ext.isFunction(validator)) {
					validator.call(this, config, callback, scope);
				} else {
					callback.call(scope);
				}
			}
		},

		/**
		 * Return validator method by expression type.
		 * @protected
		 * @param {String} expressionType Expression type.
		 * @return {Function} Validator.
		 */
		getAsyncExpressionValidatorByExpressionType: function(expressionType) {
			var validator;
			switch (expressionType) {
				case Terrasoft.ExpressionEnums.ExpressionType.CONSTANT:
					validator = this.asyncConstantExpressionValidator;
					break;
				case Terrasoft.ExpressionEnums.ExpressionType.ATTRIBUTE:
					validator = this.asyncAttributeExpressionValidator;
					break;
				case Terrasoft.ExpressionEnums.ExpressionType.SYSSETTING:
					validator = this.asyncSysSettingExpressionValidator;
					break;
				case Terrasoft.ExpressionEnums.ExpressionType.SYSVALUE:
					validator = this.asyncSysValueExpressionValidator;
					break;
				case Terrasoft.ExpressionEnums.ExpressionType.COLUMN:
					validator = this.asyncColumnExpressionValidator;
					break;
				default:
					validator = null;
			}
			return validator;
		},

		/**
		 * Validate empty expression value.
		 * @protected
		 * @param {Object} config Expression config.
		 * @param {Object} config.validationInfo Validation info.
		 * @param {Mixed} config.value Expression value.
		 * @return {Boolean} True, when expression value is not empty, false - otherwise.
		 */
		validateEmptyValue: function(config) {
			if (!config) {
				return;
			}
			var validationInfo = config.validationInfo;
			var isValid = !Ext.isEmpty(config.value);
			if (!isValid) {
				validationInfo.isValid = false;
				var message = Ext.String.format("{0}: {1}",
					config.columnCaption, Terrasoft.Resources.BaseViewModel.columnRequiredValidationMessage);
				validationInfo.messageList.push(message);
			}
			return isValid;
		},

		/**
		 * Validate constant expression type expression.
		 * @protected
		 * @param {Object} config Expression config.
		 * @param {Function} callback Callback method.
		 * @param {Object} scope Callback method context.
		 */
		asyncConstantExpressionValidator: function(config, callback, scope) {
			callback.call(scope);
		},

		/**
		 * Validate attribute expression type expression.
		 * @protected
		 * @param {Object} config Expression config.
		 * @param {Function} callback Callback method.
		 * @param {Object} scope Callback method context.
		 */
		asyncAttributeExpressionValidator: function(config, callback, scope) {
			callback.call(scope);
		},

		/**
		 * Validate system setting expression type expression.
		 * @protected
		 * @param {Object} config Expression config.
		 * @param {Function} callback Callback method.
		 * @param {Object} scope Callback method context.
		 */
		asyncSysSettingExpressionValidator: function(config, callback, scope) {
			var validationInfo = config.validationInfo;
			var sysSettingCode = config.value;
			var querySysSettingsRequest = {sysSettingsNameCollection: [sysSettingCode]};
			Terrasoft.ServiceProvider.executeRequest("QuerySysSettings", querySysSettingsRequest, function(responce) {
				var sysSettings = responce.values && responce.values[sysSettingCode];
				if (sysSettings) {
					if (!sysSettings.isCacheable) {
						validationInfo.isValid = false;
						validationInfo.messageList.push(
							Ext.String.format(resources.localizableStrings.SysSettingIsNotCacheable, sysSettingCode));
					}
				} else {
					validationInfo.isValid = false;
					validationInfo.messageList.push(
						Ext.String.format(resources.localizableStrings.WrongSysSettingMessageMask, sysSettingCode));
				}
				callback.call(scope);
			}, this);
		},

		/**
		 * Validate system value expression type expression.
		 * @protected
		 * @param {Object} config Expression config.
		 * @param {Function} callback Callback method.
		 * @param {Object} scope Callback method context.
		 */
		asyncSysValueExpressionValidator: function(config, callback, scope) {
			Ext.callback(callback, scope);
		},

		/**
		 * Validates column expression type of expression.
		 * @protected
		 * @param {Object} config Expression config.
		 * @param {Function} callback Callback method.
		 * @param {Object} scope Callback method context.
		 */
		asyncColumnExpressionValidator: function(config, callback, scope) {
			if (config.value && !config.value.dataValueType) {
				config.validationInfo.isValid = false;
			}
			Ext.callback(callback, scope);
		},

		/**
		 * Validates column code symbol value.
		 * @protected
		 * @param {String} value Column value.
		 * @return {Object} Validation information.
		 */
		validateColumnCodeSymbolValue: function(value) {
			var result = {
				invalidMessage: "",
				isValid: true
			};
			var length = value && value.length;
			var regExp = new RegExp("^[a-zA-Z]{1}[a-zA-Z0-9]{0," + length + "}$");
			result.isValid = regExp.test(value);
			if (!result.isValid) {
				result.invalidMessage = resources.localizableStrings.WrongColumnNameMessage;
			}
			return result;
		},

		/**
		 * Validates column code symbol value.
		 * @protected
		 * @param {String} value Column value.
		 * @param {Object} config Validate config.
		 * @param {String} config.invalidMessage Custom invalid message.
		 * @return {Object} Validation information.
		 */
		validateColumnPathCodeSymbolValue: function(value, config) {
			var result = {
				invalidMessage: "",
				isValid: true
			};
			var invalidMessage = config && config.invalidMessage;
			var limitMin = this.getValidateColumnPathMinLimit(config);
			var limitMax = this.getValidateColumnPathMaxLimit(config);
			var limit = Ext.String.format("{{0},{1}}", limitMin, limitMax);
			var regExp = new RegExp("^([a-zA-Z]{1}[a-zA-Z0-9_]*){1}(\\.([a-zA-Z]{1}[a-zA-Z0-9_]*))" + limit + "$");
			result.isValid = regExp.test(value);
			if (!result.isValid) {
				result.invalidMessage = invalidMessage || resources.localizableStrings.WrongColumnNameMessage;
			}
			return result;
		},

		/**
		 * Return validate limit min parameter.
		 * @protected
		 * @param {Object} config Column part limit config.
		 * @param {Integer} config.minPartCount Minimum part count of value.
		 * @return {Integer} Validate limit min parameter.
		 */
		getValidateColumnPathMinLimit: function(config) {
			var minPartCount = config && config.minPartCount;
			return Ext.isEmpty(minPartCount) || !Ext.isNumber(minPartCount) || minPartCount < 1
				? 0
				: minPartCount - 1;
		},

		/**
		 * Return validate limit max parameter.
		 * @protected
		 * @param {Object} config Column part limit config.
		 * @param {Integer} config.maxPartCount Maximum part count of value.
		 * @return {Mixed} Validate limit max parameter.
		 */
		getValidateColumnPathMaxLimit: function(config) {
			var maxPartCount = config && config.maxPartCount;
			return Ext.isEmpty(maxPartCount) || !Ext.isNumber(maxPartCount)
				? ""
				: maxPartCount - 1;
		},

		/**
		 * Returns true if business rule based on entity schema.
		 * @protected
		 * @return {Boolean} True if business rule based on entity schema.
		 */
		isEntitySchemaBased: function() {
			return Boolean(this.entitySchemaUId);
		},

		/**
		 * Pulls changes from parent view model.
		 * @protected
		 * @param {Object} config Configuration object.
		 * @param {String} config.actionType Changing action type name.
		 */
		pullChanges: function(config) {
			this.fireEvent("pullChanges", {
				actionType: config.actionType,
				sourceElement: this
			});
		},

		/**
		 * Unsubscribes pull changes event.
		 * @protected
		 */
		unsubscribePullChangesEvent: Terrasoft.emptyFn,

		/**
		 * @inheritdoc Terrasoft.BaseObject#onDestroy
		 * @override
		 */
		onDestroy: function() {
			this.unsubscribePullChangesEvent();
			this.callParent(arguments);
		},

		/**
		 * @inheritdoc Terrasoft.BaseObject#constructor
		 * @override
		 */
		constructor: function() {
			this.callParent(arguments);
			this.addEvents(
				/**
				 * @event pullChanges
				 * Fires when element designer needs in parent view model changes.
				 */
				"pullChanges"
			);
			this.set("Loaded", new Terrasoft.RX.Subject());
		},

		/**
		 * Returns meta item.
		 * @return {Object} MetaItem.
		 */
		getMetaItem: function() {
			var metaItem = this.get("MetaItem");
			return metaItem ? metaItem : this.initMetaItem();
		},

		/**
		 * Initialize new meta item.
		 * @return {*|Terrasoft.BaseBusinessRuleElement}
		 */
		initMetaItem: function() {
			var metaItem = this.createMetaItem();
			this.set("MetaItem", metaItem);
			return metaItem;
		},

		/**
		 * Update meta item by view model.
		 * @param  {Function} callback Callback method.
		 * @param  {Object} scope Callback method.
		 */
		updateMetaItem: function(callback, scope) {
			var metaItem = this.getMetaItem();
			var updaters = this.getMetaItemUpdaters();
			this.syncUpdateMetaItem(metaItem);
			Terrasoft.eachAsync(
				updaters,
				function(updater, next) {
					updater.call(this, next, metaItem);
				},
				function() {
					callback.call(scope);
				}, this);
		},

		/**
		 * Async validate view model.
		 * @param  {Function} callback Callback method.
		 * @param  {Object} scope Callback method context.
		 */
		asyncValidate: function(callback, scope) {
			var validateInfo = {
				"isValid": this.validate(),
				"messageList": []
			};
			var asyncValidators = this.getAsyncValidators();
			Terrasoft.eachAsync(
				asyncValidators,
				function(validator, next) {
					validator.call(this, next, validateInfo);
				},
				function(validateInfoResult) {
					callback.call(scope, validateInfoResult);
				}, this);
		},

		getAttributes: function() {
			return this.pageSchema.attributes;
		},

		getAttributeByName: function(name) {
			const attributes = this.getAttributes();
			const attribute = name ? attributes.find(item => item.value === name) : null;
			return attribute;
		},

		completeLoaded: function() {
			this.$Loaded.next();
			this.$Loaded.complete();
		},

		waitLoaded: function(callback, scope) {
			const {finalize} = Terrasoft.RX.operators;
			this.$Loaded.pipe(finalize(() => callback.call(scope))).subscribe();
		},

		waitLoadedCollection: function(collection, callback, scope) {
			const loaded = collection.getItems().map(x => x.$Loaded);
			const {combineLatest, operators: {finalize}} = Terrasoft.RX;
			combineLatest(...loaded).pipe(finalize(() => callback.call(scope))).subscribe();
		},
	});

	return Terrasoft.BR7xElementDesignerViewModel;
});


