Terrasoft.configuration.Structures["BusinessRulePopulateItemActionDesignerViewModel"] = {innerHierarchyStack: ["BusinessRulePopulateItemActionDesignerViewModel"]};
define("BusinessRulePopulateItemActionDesignerViewModel", ["BusinessRulePopulateItemActionDesignerViewModelResources",
	"StructureExplorerResources", "FormulaDesignerResourcesResources", 
	"BusinessRuleActionDesignerViewModel", "BusinessRulePopulateItemActionWebComponent",
	"ExpressionEditVMMixin"
], function(resources, structureExplorerResources, formulaDesignerResources) {

	Ext.define("Terrasoft.BusinessRulePopulateItemActionDesignerViewModel", {
		extend: "Terrasoft.BusinessRuleActionDesignerViewModel",
		alternateClassName: "Terrasoft.Designers.BusinessRulePopulateItemActionDesignerViewModel",

		mixins: {
			customEvent: "Terrasoft.mixins.CustomEventDomMixin",
			ExpressionEditVMMixin: "Terrasoft.ExpressionEditVMMixin"
		},

		//region Fields: Private

		setLeftExpressionsListEventName: "setLeftExpressionsList",
		getLeftExpressionsListEventName: "getLeftExpressionsList",
		setBusinessRuleActionEventName: "setBusinessRuleAction",
		getBusinessRuleActionEventName: "getBusinessRuleAction",
		setBusinessRuleActionCaptionEventName: "setBusinessRuleActionCaption",
		getBusinessRuleActionCaptionEventName: "getBusinessRuleActionCaption",
		setPageWizardLocalization: "GetPageWizardTranslation",
		getColumnExpressionDisplayValueEventName: 'getColumnExpressionDisplayValue',
		setColumnExpressionDisplayValueEventName: 'setColumnExpressionDisplayValue',

		//endregion

		//region Methods: Private

		_getBusinessRulePopulateItemActionWebComponent: function() {
			this._subscribeCustomEvents();
			return [{
				"className": "Terrasoft.BusinessRulePopulateItemActionWebComponent",
				"clear": {"bindTo": "onRemoveButtonClick"},
				"actionChanged": {"bindTo": "_onActionChanged"}
			}];
		},

		_onActionChanged: function(actionItem) {
			const leftExpressionType = actionItem.leftExpression.expressionType || Terrasoft.ExpressionEnums.ExpressionType.COLUMN;
			const rightExpressionType = actionItem.rightExpression.expressionType || Terrasoft.ExpressionEnums.ExpressionType.COLUMN;
			const leftExpression = this.$MetaItem.createItem({type: leftExpressionType});
			leftExpression.setExpressionValue(actionItem.leftExpression.expressionValue);
			leftExpression.setPropertyValue('dataValueType', actionItem.leftExpression.dataValueType);
			leftExpression.setPropertyValue('dataModelName', actionItem.leftExpression.dataModelName);
			leftExpression.setPropertyValue('dataModelId', actionItem.leftExpression.dataModelId);
			const rightExpression = this.$MetaItem.createItem({type: rightExpressionType});
			rightExpression.setExpressionValue(actionItem.rightExpression.expressionValue);
			rightExpression.setPropertyValue('dataValueType', actionItem.rightExpression.dataValueType);
			rightExpression.setPropertyValue('dataModelName', actionItem.rightExpression.dataModelName);
			rightExpression.setPropertyValue('dataModelId', actionItem.rightExpression.dataModelId);
			this.$CurrentMetaItem = {
				leftExpression: leftExpression,
				rightExpression: rightExpression
			};
		},

		_getExpressionTypeFromMetaItem: function(expressionMetaItem) {
			const typeInfo = expressionMetaItem.getTypeInfo();
			return Terrasoft.BusinessRuleElementHelper.getTypeByClassName(typeInfo.fullTypeName);
		},

		_subscribeCustomEvents: function() {
			this.mixins.customEvent.init();
			this._subscribeGetBusinessRuleActionCaption();
			this._subscribeGetBusinessRuleAction();
			this._subscribeGetFields();
			this._publishStructureExplorerLocalization();
			this._subscribeGetColumnExpressionDisplayValue();
		},
		
		_getStructureExplorerResources: function() {
			return {
				'StructureExplorerDialog.NoData': structureExplorerResources.localizableStrings.StructureExplorerNoDataCaption,
				'StructureExplorerDialog.Title': structureExplorerResources.localizableStrings.StructureExplorerTitle,
				'StructureExplorerDialog.CancelButtonCaption': structureExplorerResources.localizableStrings.StructureExplorerCancelButtonCaption,
				'StructureExplorerDialog.SelectButtonCaption': structureExplorerResources.localizableStrings.StructureExplorerSelectButtonCaption,
				'StructureExplorerDialog.FieldsTabCaption': structureExplorerResources.localizableStrings.StructureExplorerFieldsTabCaption,
				'StructureExplorerDialog.RelatedObjectsTabCaption': structureExplorerResources.localizableStrings.StructureExplorerRelatedObjectsTabCaption,
				'StructureExplorerDialog.SearchPlaceHolder': structureExplorerResources.localizableStrings.StructureExplorerSearchPlaceHolder,
				'StructureExplorerDialog.SearchClearIconTitle': structureExplorerResources.localizableStrings.StructureExplorerSearchClearIconTitle,
			};
		},
		
		_getFormulaDesignerResources: function() {
			const designerResources = {};
			Terrasoft.each(formulaDesignerResources.localizableStrings, function(value, key) {
				designerResources["localizableStrings." + key] = value;
			}, this);
			return designerResources;
		},

		_publishStructureExplorerLocalization: function() {
			this.mixins.customEvent.publish(this.setPageWizardLocalization, Ext.apply({
				'EntityColumnValuePickerProvider.ValueFromFieldCaption': resources.localizableStrings.ValueFromFieldCaption,
				'FormulaValuePickerProvider.ValueFromFieldCaption': resources.localizableStrings.FormulaValueFromFieldCaption,
				'FormulaValuePickerProvider.DialogTitleCaption': resources.localizableStrings.FormulaDialogTitleCaption,
				'FormulaValuePickerProvider.CancelButtonCaption': resources.localizableStrings.FormulaValueFromCancelButtonCaption,
				'FormulaValuePickerProvider.SelectButtonCaption': resources.localizableStrings.FormulaValueFromSelectButtonCaption,
				'BusinessRulePopulateItemActionComponent.LeftExpressionValidationMessage': resources.localizableStrings.LeftExpressionValidationMessage,
				'BusinessRulePopulateItemActionComponent.Caption': Terrasoft.BusinessRuleElementHelper.getElementByType("PopulateBusinessRuleAction").designConfig.listCaption,
				'InfoDialog.OK': Terrasoft.Resources.Controls.MessageBox.ButtonCaptionOk,
				'localizableStrings.DataValueTypeValidationErrorMessage': resources.localizableStrings.DataValueTypeValidationErrorMessage,
			}, this._getStructureExplorerResources(), this._getFormulaDesignerResources()));
		},

		_subscribeGetBusinessRuleActionCaption: function() {
			const self = this;
			const customEvent = this.mixins.customEvent;
			const subscription = customEvent
				.subscribe(this.getBusinessRuleActionCaptionEventName)
				.subscribe(function() {
					customEvent.publish(self.setBusinessRuleActionCaptionEventName, self._getBusinessRuleActionCaption());
				});
			this._addSubscription(subscription);
		},

		_subscribeGetBusinessRuleAction: function() {
			const self = this;
			const customEvent = this.mixins.customEvent;
			const subscription = customEvent
				.subscribe(this.getBusinessRuleActionEventName)
				.subscribe(function() {
					customEvent.publish(self.setBusinessRuleActionEventName, self._getBusinessRuleAction());
				});
			this._addSubscription(subscription);
		},

		_subscribeGetFields: function() {
			const self = this;
			const customEvent = this.mixins.customEvent;
			const itemsCollection = new Terrasoft.Collection();
			const subscription = customEvent
				.subscribe(this.getLeftExpressionsListEventName)
				.subscribe(function(expressionDto) {
					if (expressionDto.expressionType === Terrasoft.ExpressionEnums.ExpressionType.COLUMN) {
						Terrasoft.chain(
							function(next) {
								self._prepareExpressionEntitySchemaColumnList(expressionDto.dataModelName, '', itemsCollection, next);
							},
							function() {
								customEvent.publish(self.setLeftExpressionsListEventName, self._convertToLookupArray(itemsCollection));
							},
							this);
					}
				});
			this._addSubscription(subscription);
		},

		_subscribeGetColumnExpressionDisplayValue: function() {
			const self = this;
			const customEvent = this.mixins.customEvent;
			const subscription = customEvent
				.subscribe(this.getColumnExpressionDisplayValueEventName)
				.subscribe(function(config) {
					const path = config.rootEntitySchemaUId + "." + config.metaPath;
					Terrasoft.SchemaDesignerUtilities.getColumnCaptionPathByMetaPath(path, function(captionPath) {
						customEvent.publish(self.setColumnExpressionDisplayValueEventName, captionPath);
					}, this);
				});
			this._addSubscription(subscription);
		},

		_getSubscriptions: function() {
			if (!this._subscriptions) {
				this._subscriptions = [];
			}
			return this._subscriptions;
		},

		_addSubscription: function(subscription) {
			const subscriptions = this._getSubscriptions();
			subscriptions.push(subscription);
		},

		_getBusinessRuleActionCaption: function() {
			return this.getActionTitle();
		},

		_getBusinessRuleAction: function() {
			const leftExpression = this.$CurrentMetaItem.leftExpression;
			const rightExpression = this.$CurrentMetaItem.rightExpression;
			const leftExpressionDataModelName = leftExpression.getPropertyValue("dataModelName");
			const rightExpressionDataModelName = rightExpression.getPropertyValue("dataModelName");
			return {
				leftExpression: {
					dataValueType: leftExpression.getPropertyValue("dataValueType"),
					dataModelName: leftExpressionDataModelName,
					dataModelId: this.getEntitySchemaUId(leftExpressionDataModelName),
					expressionType: this._getExpressionTypeFromMetaItem(leftExpression),
					expressionValue: leftExpression.getExpressionValue()
				},
				rightExpression: {
					dataValueType: rightExpression.getPropertyValue("dataValueType"),
					dataModelName: rightExpressionDataModelName,
					dataModelId: this.getEntitySchemaUId(rightExpressionDataModelName),
					expressionType: this._getExpressionTypeFromMetaItem(rightExpression),
					expressionValue: rightExpression.getExpressionValue()
				}
			};
		},

		_prepareExpressionEntitySchemaColumnList: function(entitySchemaName, filter, list, callback) {
			const builder = Ext.create("Terrasoft.BusinessRuleExpressionDataQueryBuilder");
			const entitySchemaUId = this.getEntitySchemaUId(entitySchemaName);
			this.mixins.ExpressionEditVMMixin.prepareEntitySchemaColumnList.call(this, {
				entitySchemaUId: entitySchemaUId,
				packageUId: this.packageUId
			}, {
				filterValue: filter,
				filterFns: [builder.buildSupportedDataValueTypeFilter()]
			}, list, callback);
		},

		_convertToLookupArray: function(collection) {
			const result = [];
			if (!collection || collection.getCount() < 1) {
				return result;
			}
			collection.each(function(item) {
				result.push({
					value: item.value,
					name: item.name,
					displayValue: item.displayValue,
					dataValueType: item.dataValueType,
					referenceSchemaName: item.referenceSchema && item.referenceSchema.name
				});
			});
			return result;
		},

		//endregion

		//region Methods: Protected

		/**
		 * @inheritDoc Terrasoft.BaseModel#getModelColumns
		 * @overridden
		 */
		getModelColumns: function() {
			const baseColumns = this.callParent(arguments);
			return this.Ext.apply(baseColumns, {
				"CurrentMetaItem": {
					"type": Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"dataValueType": Terrasoft.DataValueType.CUSTOM_OBJECT,
					"value": null
				}
			});
		},

		onRemoveButtonClick: function() {
			this.callParent(arguments);
			const subscriptions = this._getSubscriptions();
			subscriptions.forEach(function(subscription) {
				subscription.unsubscribe();
			}, this);
		},

		/**
		 * @inheritDoc Terrasoft.BusinessRuleActionDesignerViewModel#getActionTitle
		 * @overridden
		 */
		getActionTitle: function() {
			const type = this.get("MetaItemType");
			if (this.Ext.isDefined(type)) {
				const element = Terrasoft.BusinessRuleElementHelper.getElementByType(type);
				return element.designConfig.listCaption;
			}
		},

		/**
		 * @inheritDoc Terrasoft.BusinessRuleElementDesignerViewModel#getAsyncValidateList
		 * @overridden
		 */
		getAsyncValidators: function() {
			const validationMethods = this.callParent();
			validationMethods.push(this.validateLeftExpression);
			validationMethods.push(this.validateRightExpression);
			return validationMethods;
		},

		/**
		 * Validates bind parameter action.
		 * @protected
		 * @param {Function} callback Callback function.
		 * @param {Object} validationInfo Validation information.
		 * @param {Boolean} validationInfo.isValid Is view model valid.
		 * @param {Array} validationInfo.messageList Validation message array.
		 */
		validateLeftExpression: function(callback, validationInfo) {
			const leftExpression = this.$CurrentMetaItem.leftExpression;
			const config = {
				expressionType: this._getExpressionTypeFromMetaItem(leftExpression),
				value: leftExpression.getExpressionValue(),
				columnCaption: this.get("DefaultExpressionCaption"),
				validationInfo: validationInfo
			};
			this.asyncValidateExpression(config, function() {
				callback(validationInfo);
			}, this);
		},

		/**
		 * Validates right expression.
		 * @protected
		 * @param {Function} callback Callback function.
		 * @param {Object} validationInfo Validation information.
		 * @param {Boolean} validationInfo.isValid Is view model valid.
		 * @param {Array} validationInfo.messageList Validation message array.
		 */
		validateRightExpression: function(callback, validationInfo) {
			const rightExpression = this.$CurrentMetaItem.rightExpression;
			const config = {
				expressionType: this._getExpressionTypeFromMetaItem(rightExpression),
				value: rightExpression.getExpressionValue(),
				columnCaption: this.get("DefaultExpressionCaption"),
				validationInfo: validationInfo
			};
			this.asyncValidateExpression(config, function() {
				callback(validationInfo);
			}, this);
		},

		/**
		 * @inheritDoc Terrasoft.BusinessRuleElementDesignerViewModel#getMetaItemUpdaters
		 * @overridden
		 */
		getMetaItemUpdaters: function() {
			const updaters = this.callParent(arguments);
			updaters.push(function(callback, metaItem) {
				metaItem.setPropertyValue("leftExpression", this.$CurrentMetaItem.leftExpression);
				metaItem.setPropertyValue("rightExpression", this.$CurrentMetaItem.rightExpression);
				callback();
			});
			return updaters;
		},

		/**
		 * @inheritDoc Terrasoft.BusinessRuleElementDesignerViewModel#getConfigForEmptyMetaItem
		 * @overridden
		 */
		getConfigForEmptyMetaItem: function() {
			const result = this.callParent();
			if (this.isEntitySchemaBased()) {
				Ext.apply(result, {
					leftExpression: {
						type: Terrasoft.ExpressionEnums.ExpressionType.COLUMN,
						dataModelName: this.getFirstEntitySchemaName()
					},
					rightExpression: {
						type: Terrasoft.ExpressionEnums.ExpressionType.COLUMN,
						dataModelName: this.getFirstEntitySchemaName()
					}
				});
			}
			return result;
		},

		//endregion

		//region Methods: Public

		/**
		 * @inheritDoc Terrasoft.BaseObject#constructor
		 * @overridden
		 */
		constructor: function() {
			this.callParent(arguments);
			let metaItem = this.getMetaItem();
			if (!Terrasoft.isInstanceOfClass(metaItem.getPropertyValue("leftExpression"), "Terrasoft.manager.ColumnBusinessRuleExpression")) {
				this.set("MetaItem", null);
				metaItem = this.getMetaItem();
			}
			this.$CurrentMetaItem = {
				leftExpression: metaItem.getPropertyValue("leftExpression"),
				rightExpression: metaItem.getPropertyValue("rightExpression")
			};
		},

		/**
		 * @inheritDoc Terrasoft.BusinessRuleActionDesignerViewModel#enrichViewConfig
		 * @overridden
		 */
		enrichViewConfig: function(config) {
			this.callParent(arguments);
			Ext.apply(config, {
				"businessRuleActionWebComponent": this._getBusinessRulePopulateItemActionWebComponent(),
				"populateTitleItems": [{
					"className": "Terrasoft.Container",
					"classes": {
						"wrapClassName": ["business-rule-case-action-header-item"]
					},
					"items": [{
						"className": "Terrasoft.Label",
						"caption": resources.localizableStrings.LeftExpressionGroupCaption
					}]
				}, {
					"className": "Terrasoft.Container",
					"classes": {
						"wrapClassName": ["business-rule-case-action-header-item"]
					},
					"items": [{
						"className": "Terrasoft.Label",
						"caption": resources.localizableStrings.RightExpressionGroupCaption
					}]
				}]
			});
		},

		/**
		 * @override
		 */
		onDestroy: function() {
			this.mixins.customEvent.destroy();
			this.callParent(arguments);
		}

		//endregion

	});
	return Terrasoft.BusinessRulePopulateItemActionDesignerViewModel;
});


