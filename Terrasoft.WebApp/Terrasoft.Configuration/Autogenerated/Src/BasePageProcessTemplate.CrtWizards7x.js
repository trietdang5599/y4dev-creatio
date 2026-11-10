/**
 * Base page template with process as source of data for page designer.
 * Parent: BasePageV2 => BaseEntityPage => BaseSchemaViewModel => BaseViewModel => BaseModel
 */
define("BasePageProcessTemplate", ["LookupUtilities", "BasePageProcessTemplateResources", "RightUtilities", "CustomProcessPageV2Utilities"
], function(LookupUtilities, resources, RightUtilities) {
	return {
		mixins: {
			BaseProcessViewModel: "Terrasoft.CustomProcessPageV2Utilities"
		},
		messages: {

			/**
			 * @message InitDataViews
			 * Changes current page header.
			 */
			"InitDataViews": {
				mode: Terrasoft.MessageMode.PTP,
				direction: Terrasoft.MessageDirectionType.PUBLISH
			}
		},
		details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
		businessRules: /**SCHEMA_BUSINESS_RULES*/{}/**SCHEMA_BUSINESS_RULES*/,
		methods: {

			// region Methods: Private

			/**
			 * @private
			 */
			_getDefaultButtonInfo: function(tag) {
				switch (tag) {
					case "SaveData":
						return {
							caption: resources.localizableStrings.SaveButtonCaption,
							performClosePage: true,
							performSaveData: true
						};
					case "ClosePage":
						return {
							caption: resources.localizableStrings.CloseButtonCaption,
							performClosePage: false,
							performSaveData: false
						};
					default:
						const message = "Button with tag " + tag + " not found";
						const error = new Terrasoft.ItemNotFoundException({message: message});
						this.warning(error.toString());
						return {
							caption: resources.localizableStrings.NoCaptionButtonCaption,
							performClosePage: false,
							performSaveData: false
						};
				}
			},

			/**
			 * @private
			 */
			_getButtonInfo: function(tag) {
				var buttonsParameterValue = this.get("Buttons");
				var buttons = buttonsParameterValue && Terrasoft.decode(buttonsParameterValue).$values;
				var button = _.find(buttons, function(item) {
					return item.Tag.value === tag;
				}, this);
				if (!button) {
					return this._getDefaultButtonInfo(tag);
				}
				return {
					performClosePage: !!button.PerformClosePage && button.PerformClosePage.value === "True",
					performSaveData: !!button.PerformSaveData && button.PerformSaveData.value === "True",
					caption: button.Caption ? button.Caption.value : resources.localizableStrings.NoCaptionButtonCaption
				};
			},

			/**
			 * @private
			 */
			_checkCanEdit: function(callback, scope) {
				this.dataModelCollection.eachAsync(function(dataModel, next) {
					const primaryColumnName = dataModel.getPrimaryColumnName();
					const primaryColumnValue = this.get(primaryColumnName);
					const config = {
						schemaName: dataModel.schema.name,
						primaryColumnValue: primaryColumnValue,
						isNew: dataModel.isNew
					};
					RightUtilities.checkCanEdit(config, function(result) {
						const resultObject = this.processCheckCanEditResponse(result);
						this.set("CanEditResponse", result);
						if (resultObject.success) {
							next.call(this);
						} else {
							Ext.callback(callback, scope, [resultObject]);
						}
					}, this);
				}, function() {
					Ext.callback(callback, scope, [{success: true}]);
				}, this);
			},

			// endregion

			// region Methods: Protected

			/**
			 * @inheritdoc Terrasoft.BaseViewModel#validateColumn
			 * @override
			 */
			validateColumn: function(columnName, options) {
				if (options && options.skipValidation) {
					return this.callParent(arguments);
				}
				if (Terrasoft.Features.getIsDisabled("ValidateRequiredFields") &&
					Terrasoft.Features.getIsDisabled("DisablePreconfiguredPageValidateRequiredFields")) {
					this.fireEvent("validate:" + columnName, this);
				}
				return this.callParent(arguments);
			},

			/**
			 * @inheritdoc Terrasoft.BasePageV2.mixins.PrintReportUtilities#initCardPrintForms
			 * @override
			 */
			initCardPrintForms: function(callback, scope) {
				this.set(this.moduleCardPrintFormsCollectionName, new Terrasoft.BaseViewModelCollection());
				Ext.callback(callback, scope || this);
			},

			/**
			 * @inheritdoc Terrasoft.BasePageV2#onCloseClick
			 * @override
			 */
			onCloseClick: function() {
				this.onCloseCardButtonClick.apply(this, arguments);
			},

			/**
			 * @inheritdoc Terrasoft.BasePageV2#initHeader
			 * @overridden
			 */
			initHeader: function() {
				const headerValue = this.getHeader();
				this.sandbox.publish("InitDataViews", {
					caption: headerValue,
					markerValue: headerValue
				});
			},

			/**
			 * @inheritdoc Terrasoft.BasePageV2#getHeader
			 * @override
			 */
			getHeader: function() {
				const processData = this.get("ProcessData");
				return processData.header;
			},

			/**
			 * @inheritdoc Terrasoft.BasePageV2#initContainersVisibility
			 * @override
			 */
			initContainersVisibility: function() {
				this.callParent(arguments);
				this.set("IsPageHeaderVisible", false);
			},

			/**
			 * @inheritdoc Terrasoft.BaseSchemaViewModel#init
			 * @override
			 */
			init: function(callback, scope) {
				this.set("IsSeparateMode", true);
				this.callParent([function() {
					if (Terrasoft.Features.getIsEnabled("LegacyLoadingOfProcessPageLookupsTypedColumnValues")) {
						callback.call(scope);
					} else {
						this.loadLookupAttributeTypeValues(callback, scope);
					}
				}, this])
			},

			/**
			 * @inheritdoc Terrasoft.BasePage#initEntity
			 * @override
			 */
			initEntity: function(callback, scope) {
				this.callParent([function() {
					this.loadDataModels({}, callback, scope);
				}, this]);
			},

			/**
			 * @inheritdoc Terrasoft.BaseViewModel.mixins.EntityBaseViewModelMixin#findEntityColumn
			 * @override
			 */
			findEntityColumn: function(columnName) {
				return this.getColumnByName(columnName);
			},

			/**
			 * @inheritdoc Terrasoft.BaseEntityPage#saveEntityInChain
			 * @override
			 */
			saveEntityInChain: function(callback, scope) {
				this.cardSaveResponse = {success: true};
				Ext.callback(callback, scope);
			},

			/**
			 * Performs validation. Call callback when validation was successful.
			 * @protected
			 * @param {Function} [callback] The callback function.
			 * @param {Object} [scope] The scope of callback function.
			 */
			validation: function(callback, scope) {
				this.asyncValidate(function(result) {
					if (result.success) {
						Ext.callback(callback, scope);
					} else {
						this.showInformationDialog(result.message);
					}
				}, this);
			},

			/**
			 * Handler for button click with verification. Accept element of process when validation success.
			 * @protected
			 */
			completeProcessElementWithVerification: function(code) {
				this.set("CanEditResponse", null);
				Terrasoft.chain(
					this.validation.bind(this),
					this.saveCheckCanEditRight.bind(this),
					this.saveDataModels.bind(this),
					function(next, response) {
						this.validateSaveEntityResponse(response, next, this);
					},
					function() {
						this.acceptProcessElement(code);
					},
					this
				);
			},

			/**
			 * Handler for SaveButton click.
			 * @protected
			 */
			onSaveButtonClick: function(eventName, modelMethod, model, tag) {
				this.completeProcessElementWithVerification(tag);
			},

			// endregion

			// region Methods: Public

			/**
			 * Handler for process action buttons click.
			 * Using in PageDesignerSchema for binding.
			 */
			onProcessActionButtonClick: function(eventName, modelMethod, model, tag) {
				const info = this._getButtonInfo(tag);
				if (info.performClosePage) {
					if (info.performSaveData) {
						this.onSaveButtonClick.apply(this, arguments);
					} else {
						this.cancelProcessElement(tag);
					}
				} else {
					this.onCloseClick.apply(this, arguments);
				}
			},

			/**
			 * @protected
			 */
			onCancelProcessElementClick: function(eventName, modelMethod, model, tag) {
				this.cancelProcessElement(tag);
			},

			/**
			 * Returns caption for user defined buttons. Get resource from parameter Buttons.
			 * Using in PageDesignerSchema for binding.
			 */
			getProcessActionButtonCaption: function(tag) {
				var info = this._getButtonInfo(tag);
				return info.caption;
			},

			/**
			 * @inheritdoc Terrasoft.BasePageV2#isChanged
			 * @override
			 */
			isChanged: function() {
				return this.isParametersChanged() || this.callParent(arguments);
			},

			/**
			 * Check user edit rights.
			 * @protected
			 * @override
			 * @param {Function} callback Callback-function.
			 * @param {Terrasoft.BaseSchemaViewModel} scope Callback execution context.
			 */
			checkCanEditRight: function(callback, scope) {
				var resultObject;
				var canEditResponse = this.get("CanEditResponse");
				if (this.Ext.isString(canEditResponse)) {
					resultObject = this.processCheckCanEditResponse(canEditResponse);
					this.Ext.callback(callback, scope, [resultObject]);
				} else {
					this._checkCanEdit(callback, scope);
				}
			},

			// endregion

		},
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "merge",
				"name": "ActionButtonsContainer",
				"values": {
					"visible": true
				}
			},
			{
				"operation": "remove",
				"name": "LeftContainer"
			},
			{
				"operation": "remove",
				"name": "RightContainer"
			},
			{
				"operation": "insert",
				"parentName": "ActionButtonsContainer",
				"propertyName": "items",
				"name": "ProcessActionButtons",
				"alias": {
					"name": "LeftContainer"
				},
				"values": {
					"itemType": Terrasoft.ViewItemType.CONTAINER,
					"wrapClass": ["process-action-buttons"],
					"items": []
				}
			},
			{
				"operation": "insert",
				"parentName": "ProcessActionButtons",
				"propertyName": "items",
				"index": 0,
				"name": "Button-be6148b819154a0791eaee8f1635d859",
				"alias": {
					"name": "SaveButton"
				},
				"values": {
					"itemType": Terrasoft.ViewItemType.BUTTON,
					"id": "f073e66a-36ec-47d7-9c6a-e5952dbf05a3",
					"style": "green",
					"tag": "SaveData",
					"caption": {"bindTo": "getProcessActionButtonCaption"},
					"click": {"bindTo": "onProcessActionButtonClick"}
				}
			},
			{
				"operation": "insert",
				"parentName": "ProcessActionButtons",
				"propertyName": "items",
				"index": 1,
				"name": "Button-3a8ac667899d4aa68021a07eb1c7c49c",
				"alias": {
					"name": "CloseButton"
				},
				"values": {
					"itemType": Terrasoft.ViewItemType.BUTTON,
					"id": "c4841740-ff8c-406f-8626-1c78f78608bf",
					"style": "blue",
					"tag": "ClosePage",
					"caption": {"bindTo": "getProcessActionButtonCaption"},
					"click": {"bindTo": "onProcessActionButtonClick"}
				}
			},
			{
				"operation": "merge",
				"name": "HeaderCaptionContainer",
				"values": {
					"visible": true
				}
			},
			{
				"operation": "insert",
				"parentName": "Tabs",
				"propertyName": "tabs",
				"name": "NewTab1",
				"values": {
					"caption": {"bindTo": "Resources.Strings.NewTab1Caption"},
					"items": []
				}
			},
			{
				"operation": "insert",
				"parentName": "NewTab1",
				"propertyName": "items",
				"name": "NewTab1Group1",
				"values": {
					"itemType": Terrasoft.ViewItemType.CONTROL_GROUP,
					"caption": {"bindTo": "Resources.Strings.NewTab1Group1Caption"},
					"items": []
				}
			},
			{
				"operation": "insert",
				"parentName": "NewTab1Group1",
				"propertyName": "items",
				"name": "NewTab1GridLayout1",
				"values": {
					"itemType": Terrasoft.ViewItemType.GRID_LAYOUT,
					"items": []
				}
			},
			{
				"operation": "merge",
				"name": "LeftModulesContainer",
				"values": {
					"visible": false
				}
			}
		]/**SCHEMA_DIFF*/
	};
});
