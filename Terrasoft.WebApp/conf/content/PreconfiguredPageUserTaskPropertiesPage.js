Terrasoft.configuration.Structures["PreconfiguredPageUserTaskPropertiesPage"] = {innerHierarchyStack: ["PreconfiguredPageUserTaskPropertiesPage"], structureParent: "BaseUserTaskPropertiesPage"};
define('PreconfiguredPageUserTaskPropertiesPageStructure', ['PreconfiguredPageUserTaskPropertiesPageResources'], function(resources) {return {schemaUId:'2352c272-080e-4cc9-828c-f6689a45e95a',schemaCaption: "Edit page - User task parameters - \"Pre-configured page\"", parentSchemaName: "BaseUserTaskPropertiesPage", packageName: "CrtProcessDesigner", schemaName:'PreconfiguredPageUserTaskPropertiesPage',parentSchemaUId:'824a1fba-a081-4d8a-940c-6c258c298687',extendParent:false,type:Terrasoft.SchemaType.EDIT_VIEW_MODEL_SCHEMA,entitySchema:'',name:'',extend:'Terrasoft.model.BaseViewModel',schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},schemaDifferences:function(){

}};});
/**
 * Parent: BaseUserTaskPropertiesPage
 */
define("PreconfiguredPageUserTaskPropertiesPage", ["terrasoft", "PreconfiguredPageUserTaskPropertiesPageResources",
	"ProcessModuleUtilities", "ProcessEntryPointPropertiesPageMixin", "DesignTimeEnums",
	"PreconfiguredPageUserTaskButtonViewModel"
], function(Terrasoft, resources, ProcessModuleUtilities) {
	return {
		mixins: {
			processEntryPointPropertiesPageMixin: "Terrasoft.ProcessEntryPointPropertiesPageMixin"
		},
		properties: {

			/**
			 * @inheritdoc RootUserTaskPropertiesPage.properties#schemaManagerName
			 * @override
			 */
			schemaManagerName: "ClientUnitSchemaManager",

			/**
			 * @inheritdoc RootUserTaskPropertiesPage.properties#useNotification
			 * @override
			 */
			useNotification: true,

			/**
			 * @private
			 */
			_pageTemplates: [
				Terrasoft.DesignTimeEnums.BaseSchemaUId.BASE_PAGE_SIMPLE_PROCESS_TEMPLATE,
				Terrasoft.DesignTimeEnums.BaseSchemaUId.BASE_PAGE_PROCESS_TEMPLATE,
				Terrasoft.DesignTimeEnums.BaseSchemaUId.BASE_PAGE_RIGHT_CONTAINER_PROCESS_TEMPLATE,
				Terrasoft.DesignTimeEnums.BaseSchemaUId.BASE_PAGE_LEFT_CONTAINER_PROCESS_TEMPLATE
			],

			/**
			 * @private
			 */
			_pageSaveCheckInterval: null,

			/**
			 * @private
			 */
			_8XDesignerWindowHandle: null,

			/**
			 * @private
			 */
			_designedSchemaUId: null,

			/**
			 * @private
			 */
			_unsupportedSchemaTypes: [
				Terrasoft.SchemaType.MODULE,
				Terrasoft.SchemaType.DETAIL_VIEW_MODEL_SCHEMA,
				Terrasoft.SchemaType.GRID_DETAIL_VIEW_MODEL_SCHEMA,
				Terrasoft.SchemaType.EDIT_CONTROLS_DETAIL_VIEW_MODEL_SCHEMA,
				Terrasoft.SchemaType.GRID_EDIT_DETAIL_VIEW_MODEL_SCHEMA,
				Terrasoft.SchemaType.UNIT_TEST_MODULE
			],

			/**
			 * @private
			 */
			_disallow8XPagesIn7XUI: Terrasoft.Features
				.getIsEnabled("PreconfiguredPageUserTask.Disallow8XPagesIn7XUI")
		},
		messages: {},
		attributes: {

			/**
			 * Page schema to open.
			 */
			"ClientUnitSchemaUId": {
				dataValueType: Terrasoft.DataValueType.LOOKUP,
				type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				referenceSchemaName: "SysSchema",
				doAutoSave: true,
				isRequired: true
			},

			/**
			 * Previous selected page schema.
			 */
			"PreviousClientUnitSchemaUId": {
				dataValueType: Terrasoft.DataValueType.LOOKUP,
				type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				referenceSchemaName: "SysSchema"
			},

			/**
			 * Recommendations for filling out the page.
			 */
			"Recommendation": {
				dataValueType: this.Terrasoft.DataValueType.MAPPING,
				type: this.Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				caption: resources.localizableStrings.RecommendationCaption,
				initMethod: "initProperty",
				isRequired: false,
				doAutoSave: true
			},

			/**
			 * User hints.
			 */
			"InformationOnStep": {
				dataValueType: this.Terrasoft.DataValueType.MAPPING,
				type: this.Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				caption: resources.localizableStrings.InformationOnStepCaption,
				doAutoSave: true,
				initMethod: "initProperty"
			},

			/**
			 * To whom open a page.
			 */
			"OwnerId": {
				isRequired: false
			},

			/**
			 * Connection object.
			 */
			"EntitySchemaUId": {
				dataValueType: this.Terrasoft.DataValueType.LOOKUP,
				type: this.Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				caption: resources.localizableStrings.EntitySchemaCaption,
				referenceSchemaName: "SysSchema",
				doAutoSave: true
			},

			/**
			 * Instance of connection object.
			 */
			"EntityId": {
				dataValueType: this.Terrasoft.DataValueType.MAPPING,
				type: this.Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				caption: resources.localizableStrings.EntityCaption,
				doAutoSave: true,
				initMethod: "initProperty"
			},

			/**
			 * Flag that indicates page parameters visibility.
			 */
			"IsPageParametersVisible": {
				dataValueType: this.Terrasoft.DataValueType.BOOLEAN,
				type: this.Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				value: false
			},

			/**
			 * Flag that indicates element PageHasNoParametersLabel visible.
			 */
			"PageHasNoParametersLabelVisible": {
				dataValueType: this.Terrasoft.DataValueType.BOOLEAN,
				type: this.Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				value: true
			},

			/**
			 * Page parameters.
			 */
			"PageParameters": {
				dataValueType: Terrasoft.DataValueType.COLLECTION,
				type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				isCollection: true,
				value: this.Ext.create("Terrasoft.ObjectCollection")
			},

			/**
			 * Template(Parent) page.
			 */
			"Template": {
				dataValueType: Terrasoft.DataValueType.LOOKUP,
				type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				initMethod: "initProperty",
				referenceSchemaName: "VwSysSchemaInfo"
			},

			/**
			 * Cached page parameter view config.
			 */
			"PageParameterViewConfig": {
				dataValueType: Terrasoft.DataValueType.CUSTOM_OBJECT,
				type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN
			},

			/**
			 * Attribute names that triggers update of next elements suggestions.
			 * @protected
			 * @type {Object}
			 */
			"SuggestionsTriggerAttributes": {
				dataValueType: Terrasoft.DataValueType.COLLECTION,
				type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				value: [
					{
						name: "ClientUnitSchemaUId"
					}
				]
			},

			/**
			 * Determines whether an Angular schema selected or not.
			 */
			"IsAngularSchema": {
				dataValueType: Terrasoft.DataValueType.BOOLEAN,
				type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				value: false
			},

			/**
			 * Interactive elements.
			 */
			"InteractiveElements": {
				dataValueType: Terrasoft.DataValueType.COLLECTION,
				type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				isCollection: true
			},

			/**
			 * Indicates whether the current page can use Freedom user interface.
			 */
			"UseNewShell": {
				"dataValueType": Terrasoft.DataValueType.BOOLEAN,
				"value": true
			}
		},
		methods: {

			//region Methods: Private

			/**
			 * @inheritdoc Terrasoft.BaseUserTaskPropertiesPage#getSupportsTechnicalActivity
			 * @override
			 */
			getSupportsTechnicalActivity: function() {
				return false;
			},

			/**
			 * Reverts attribute ClientUnitSchemaUId if empty.
			 * @private
			 */
			revertClientUnitSchema: function() {
				const schema = this.$ClientUnitSchemaUId;
				const oldSchema = this.$PreviousClientUnitSchemaUId;
				if (!schema && oldSchema) {
					this.$ClientUnitSchemaUId = oldSchema;
				}
			},

			/**
			 * Saves page parameters values.
			 * @private
			 */
			savePageParameters: function() {
				const element = this.$ProcessElement;
				const parameters = this.$PageParameters;
				parameters.each(function(model) {
					this.saveExtendedValue(model, element);
					if (model.hasItemProperties()) {
						this._saveNestedCollection(model.$ItemProperties);
					}
				}, this);
			},

			/**
			 * @private
			 */
			_getIsAngularSchema(schemaType) {
				return schemaType === Terrasoft.SchemaType.ANGULAR_SCHEMA;
			},

			/**
			 * @private
			 */
			_getShouldSkipParameter: function(parameter, element) {
				return parameter.tag === "ActivityConnection" || element.getIsAssignmentOptionsParameter(parameter.uId);
			},

			/**
			 * @private
			 */
			_getFilterDataToSelectEditPages: function() {
				const isEnabled = Terrasoft.Features.getIsEnabled('ShowEditPagesInPreconfiguredPageUserTask');
				const filterData = {};
				if (isEnabled) {
					return filterData;
				}
				Terrasoft.each(Terrasoft.configuration.ModuleStructure, (structureItem) => {
					const cardSchemaName = structureItem.cardSchema;
					if (cardSchemaName) {
						filterData[cardSchemaName] = true;
					}
					if (!structureItem.pages) {
						return true;
					}
					Terrasoft.each(structureItem.pages, (pageItem) => {
						if (pageItem.cardSchema) {
							filterData[pageItem.cardSchema] = true;
						}
					}, this);
				});
				return filterData;
			},

			/**
			 * @private
			 */
			_getIsSchemaTypeSupported: function (schemaType) {
				if (Terrasoft.Features.getIsDisabled("OpenEditPageUserTask.AllowUnsupportedSchemaTypes")
						&& this._unsupportedSchemaTypes.indexOf(schemaType) > -1) {
					return false;
				}
				if (!this._disallow8XPagesIn7XUI) {
					return true;
				}
				const useNewShell = this.get("UseNewShell");
				if (!useNewShell && this._getIsAngularSchema(schemaType)) {
					return false;
				}
				return true;
			},

			/**
			 * @private
			 */
			_initPageSchemasInternal: function(packageItems, callback, scope) {
				const filterData = this._getFilterDataToSelectEditPages();
				const items = _.uniq(packageItems.mapArrayByPath("name"));
				const pageSchemas = new Terrasoft.Collection();
				items.forEach(function (name) {
					const item = Terrasoft.ClientUnitSchemaManager.findRootSchemaItemByName(name);
					if (!item) {
						return true;
					}
					const schemaType = item.extraProperties?.schemaType;
					if (!this._getIsSchemaTypeSupported(schemaType) || filterData[item.name]) {
						return true;
					}
					const displayValue = this._appendSchemaName(item.getDisplayValue(), item.name);
					const orderValue = displayValue.toLowerCase().replace(/["\-|]/g, "");
					pageSchemas.add(item.uId, {
						value: item.uId,
						packageUId: item.packageUId,
						name: item.name,
						displayValue: displayValue,
						orderValue: orderValue
					});
				}, this);
				pageSchemas.sort("orderValue");
				this.set("PageSchemas", pageSchemas);
				Ext.callback(callback, scope);
			},

			/**
			 * @private
			 */
			_getIsSetPageSchema: function() {
				return Boolean(this.$ClientUnitSchemaUId && this.$ClientUnitSchemaUId.value);
			},

			/**
			 * @private
			 */
			_getIsVisibleOpenSchemaDesignerMenuButton: function() {
				if (!this._disallow8XPagesIn7XUI) {
					return !this._getIsSetPageSchema();
				}
				return this.get("UseNewShell") && !this._getIsSetPageSchema();
			},

			/**
			 * @private
			 */
			_getIsVisibleOpenSchemaDesignerButton: function() {
				return !this._getIsVisibleOpenSchemaDesignerMenuButton();
			},

			/**
			 * @private
			 */
			_getIsVisibleOpenSchemaDesignerInfoButton: function() {
				if (!this._disallow8XPagesIn7XUI) {
					return false;
				}
				return !this.get("UseNewShell") && this._getIsSetPageSchema() && this.get("IsAngularSchema");
			},

			/**
			 * Initializes selected preconfigured page parameters.
			 * @private
			 * @param {Terrasoft.ProcessBaseElementSchema} element Process element.
			 */
			initPageParameters: function(element) {
				this.clearPageParameters();
				const parameters = element.getDynamicParameters().filterByFn(function(parameter) {
					const skip = this._getShouldSkipParameter(parameter, element);
					return !ProcessModuleUtilities.isSystemParameter(parameter.name) && !skip;
				}, this);
				parameters.each(function(parameter) {
					const viewModel = this.createParameterViewModel(parameter);
					viewModel.validate();
					this.$PageParameters.add(parameter.uId, viewModel);
				}, this);
				const hasParameters = !parameters.isEmpty();
				this.$PageHasNoParametersLabelVisible = !hasParameters;
				this.$IsPageParametersVisible = hasParameters;
			},

			/**
			 * @private
			 */
			_initUseNewShell: function(callback, scope) {
				Terrasoft.SysSettings.querySysSettings(["UseNewShell"], function(settings) {
					this.set("UseNewShell", settings.UseNewShell);
					Ext.callback(callback, scope);
				}, this);
			},

			/**
			 * Sets attribute "ClientUnitSchemaUId".
			 * @private
			 * @param {Function} callback The callback function.
			 * @param {Object} scope The scope of callback function.
			 */
			initClientUnitSchema: function(callback, scope) {
				const parameter = this.get("ProcessElement").getParameterByName("ClientUnitSchemaUId");
				const schemaUId = parameter.getValue();
				if (Terrasoft.isEmpty(schemaUId)) {
					callback.call(scope);
					return;
				}
				ProcessModuleUtilities.loadSchemaDisplayValue(schemaUId, function(displayValue, name) {
					if (name && displayValue) {
						const lookupDisplayValue = this._appendSchemaName(displayValue, name);
						this._initClientUnitSchemaUId({
							value: schemaUId,
							displayValue: lookupDisplayValue
						});
						this.initSchemaParameters(callback, scope);
					} else {
						callback.call(scope);
					}
				}, this);
			},

			/**
			 * The event handler for preparing page schemas drop-down list.
			 * @private
			 * @param {Object} filter Filters for data preparation.
			 * @param {Terrasoft.Collection} list The data for the drop-down list.
			 */
			onPrepareClientUnitSchemaList: function(filter, list) {
				if (Terrasoft.isEmptyObject(list)) {
					return;
				}
				list.clear();
				const selectedSchema = this.$ClientUnitSchemaUId;
				let pageSchemas = this.get("PageSchemas");
				if (selectedSchema) {
					pageSchemas = pageSchemas.filterByFn(function(schema) {
						return schema.value !== selectedSchema.value;
					});
				}
				list.loadAll(pageSchemas);
			},

			/**
			 * Clears page parameter collection and sets empty parameters group caption.
			 * @private
			 */
			clearPageParameters: function() {
				this.$PageParameterViewConfig = null;
				this.$IsPageParametersVisible = false;
				this.$PageHasNoParametersLabelVisible = false;
				this.$PageParameters.clear();
			},

			/**
			 * Returns label configuration for page parameter.
			 * @private
			 */
			getPageParameterLabelConfig: function() {
				return {
					id: "Caption",
					className: "Terrasoft.Label",
					caption: {bindTo: "Caption"},
					classes: {labelClass: ["t-label-proc", "t-label-proc-param"]}
				};
			},

			/**
			 * @private
			 */
			_showParametersLoadMask: function() {
				const config = {
					selector: ".sub-process-parameters-container:not(:first-child)",
					timeout: 0
				};
				return Terrasoft.Mask.show(config);
			},

			/**
			 * @inheritdoc Terrasoft.RootUserTaskPropertiesPage#onAfterSchemaCnahged
			 * @override
			 */
			onAfterSchemaChanged: function() {
				this.$PreviousClientUnitSchemaUId = this.$ClientUnitSchemaUId;
				const element = this.get("ProcessElement");
				element.clearDynamicParameters();
				this.synchronizeSchemaParameters();
			},

			/**
			 * @inheritdoc Terrasoft.RootUserTaskPropertiesPage#synchronizeSchemaParameters
			 * @override
			 */
			synchronizeSchemaParameters: function(callback, scope) {
				const maskId = this._showParametersLoadMask();
				Terrasoft.chain(
					function(next) {
						Terrasoft.ClientUnitSchemaManager.initialize(next, this);
					},
					function(next) {
						this.initSchemaParameters(next, this);
					},
					function() {
						Terrasoft.Mask.hide(maskId);
						Ext.callback(callback, scope);
					},
					this
				);
			},

			/**
			 * @private
			 */
			_updateTitleParameter: function(caption) {
				const element = this.get("ProcessElement");
				const parameter = element.getParameterByName("Title");
				const mappingValue = parameter.getMappingValue();
				mappingValue.value = caption;
				mappingValue.displayValue = caption;
				mappingValue.source = Terrasoft.ProcessSchemaParameterValueSource.ConstValue;
				parameter.setMappingValue(mappingValue);
			},

			/**
			 * @private
			 */
			_appendSchemaName: function(displayValue, name) {
				if (displayValue !== name) {
					return displayValue + " | " + name;
				} else {
					return displayValue;
				}
			},

			/**
			 * @private
			 */
			_subscribeClientUnitSchemaChanges: function() {
				this.on("change:ClientUnitSchemaUId", this.onBeforeSchemaChanged, this);
			},

			/**
			 * @private
			 */
			_findEqualParameter: function(parameters, sourceParameter) {
				return parameters.findByFn(function(parameter) {
					if (parameter.name !== sourceParameter.name && parameter.uId !== sourceParameter.uId) {
						return false;
					}
					if (ProcessModuleUtilities.isSystemParameter(parameter.name)) {
						return parameter.sourceValue.value === sourceParameter.sourceValue.value;
					}
					return true;
				}, this);
			},

			/**
			 * @private
			 */
			_checkParameterChanged: function(oldParameters) {
				const element = this.get("ProcessElement");
				const parameters = element.parameters;
				const parentSchema = element.parentSchema;
				if (parameters.getCount() === oldParameters.getCount()) {
					const changedParameters = [];
					parameters.each(function(parameter) {
						const equalOldParameter = this._findEqualParameter(oldParameters, parameter);
						if (!equalOldParameter) {
							changedParameters.push(parameter);
						}
					}, this);
					if (changedParameters.length) {
						parentSchema.fireEvent("changed", {parameters: changedParameters}, this);
					}
				} else {
					parentSchema.fireEvent("changed", {item: "parameters"}, this);
				}
			},

			/**
			 * @private
			 */
			_initClientUnitSchemaUId: function(lookupValue) {
				this.$ClientUnitSchemaUId = lookupValue;
				this.$PreviousClientUnitSchemaUId = lookupValue;
			},

			/**
			 * @private
			 */
			_getClientUnitSchemaInstance: function(callback, scope) {
				const config = {
					schemaUId: this.$ClientUnitSchemaUId.value,
					packageUId: this.get("packageUId"),
					useCache: false
				};
				Terrasoft.ClientUnitSchemaManager.findBundleSchemaInstance(config, function(schema) {
					const isAngularSchema = this._getIsAngularSchema(schema?.schemaType);
					this.set("IsAngularSchema", isAngularSchema);
					if (!schema) {
						schema = null;
						this._initClientUnitSchemaUId(null);
					}
					callback.call(scope, schema);
				}, this);
			},

			/**
			 * @private
			 */
			_subscribeOnParametersChanged: function() {
				const element = this.$ProcessElement;
				element.parameters.each(function(parameter) {
					parameter.on("changed", this._onParameterChanged, this);
				}, this);
			},

			/**
			 * @private
			 */
			_onParameterChanged: function(changes, parameter) {
				const parentSchema = parameter.getParentSchema();
				parentSchema.fireEvent("changed", changes, parameter);
			},

			/**
			 * @private
			 */
			_updateElementParametersBySchemaParameters: function(schema) {
				const schemaParameters = schema.parameters;
				const element = this.$ProcessElement;
				schemaParameters.each(function(schemaParameter) {
					const processParameter = schemaParameter.convertToProcessParameter();
					const uId = processParameter.uId;
					const elementParameters = element.parameters;
					const oldParameter = element.findParameterByName(processParameter.name) ||
						element.findParameterBySourceUId(uId) || element.findParameterByUId(uId);
					if (oldParameter) {
						elementParameters.removeByKey(oldParameter.uId);
						processParameter.uId = oldParameter.uId;
					} else {
						processParameter.uId = Terrasoft.generateGUID();
					}
					processParameter.sourceParameterUId = uId;
					elementParameters.add(processParameter.uId, processParameter);
					this.initPageParameter(processParameter, element);
				}, this);
			},

			/**
			 * @private
			 */
			_clearDynamicParameters: function(schema, parametersToPreserve) {
				const basePageTemplateUId = Terrasoft.DesignTimeEnums.BaseSchemaUId.BASE_PAGE_PROCESS_TEMPLATE;
				const isAngularSchema = this._getIsAngularSchema(schema.schemaType);
				const shouldClear = Terrasoft.ClientUnitSchemaManager
					.isInheritedFrom(schema.uId, basePageTemplateUId) || isAngularSchema;
				if (!shouldClear) {
					return;
				}
				const element = this.$ProcessElement;
				const dynamicParameters = element.getDynamicParameters();
				const schemaParameters = schema.parameters;
				dynamicParameters.each(function (parameter) {
					if (this._getShouldSkipParameter(parameter, element) ||
							parametersToPreserve.includes(parameter.name)) {
						return true;
					}
					const sourceParameterUId = parameter.sourceParameterUId;
					const schemaParameter = schemaParameters.find(sourceParameterUId);
					if (schemaParameter ||
						(isAngularSchema && ProcessModuleUtilities.isSystemParameter(parameter.name))) {
						return true;
					}
					element.clearDynamicParameter(parameter.uId);
				}, this);
			},

			/**
			 * @private
			 */
			_forceGetButtonsParameter: function() {
				const element = this.$ProcessElement;
				let parameter = this._findButtonsParameter();
				if (!parameter) {
					parameter = element.createParameter({
						name: "Buttons",
						isValueSerializable: true,
						direction: Terrasoft.ProcessSchemaParameterDirection.VARIABLE,
						dataValueType: Terrasoft.DataValueType.LOCALIZABLE_PARAMETER_VALUES_LIST
					});
					element.parameters.add(parameter.uId, parameter);
				}
				return parameter;
			},

			/**
			 * @private
			 */
			_saveInteractiveElements: function(){
				if (!this.get("IsAngularSchema")) {
					return;
				}
				const parameter = this._forceGetButtonsParameter();
				const values = [];
				Terrasoft.each(this.$InteractiveElements, function(elementViewModel) {
					if (!elementViewModel.get("PerformsPageCompletion")) {
						return true;
					}
					values.push({
						ItemUId: elementViewModel.get("Id"),
						Caption: {
							"isLczValue": true,
							"value": elementViewModel.get("Caption")
						},
						Name: {
							"value": elementViewModel.get("Name")
						},
						Id: {
							"value": elementViewModel.get("Id")
						},
						Tag: {
							"value": elementViewModel.get("Tag")
						},
						Event: {
							"value": elementViewModel.get("Event")
						},
						PerformClosePage: {
							"value": "True"
						},
						PerformValidation: {
							"value": elementViewModel.get("PerformsValidation") ? "True" : "False"
						}
					});
				}, this);
				parameter.setLocalizableParameterValues(values);
			},

			/**
			 * @private
			 */
			_findButtonsParameter: function() {
				const element = this.$ProcessElement;
				return element.parameters.findByPath("name", "Buttons");
			},

			/**
			 * @private
			 */
			_getButtonsParameterValue: function() {
				const parameter = this._findButtonsParameter();
				const result = Ext.create("Terrasoft.Collection");
				if (!parameter) {
					return result;
				}
				const previousValues = parameter.getLocalizableParameterValues();
				Terrasoft.each(previousValues, previousValue => {
					const buttonName = previousValue?.Name?.value;
					if (buttonName) {
						result.add(buttonName, {
							id: previousValue.Id.value,
							performsPageCompletion: true,
							performsValidation: (previousValue.PerformValidation?.value ?? "True") === "True",
						});
					}
				}, this);
				return result;
			},

			/**
			 * @private
			 */
			_getToolButtonMenuList: function(itemId) {
				const toolsButtonMenu = Ext.create("Terrasoft.Collection");
				toolsButtonMenu.add(
					"EditMenu",
					this.getButtonMenuItem({
						"id": "EditMenu",
						"tag": itemId,
						"caption": this.get("Resources.Strings.EditMenuItemCaption"),
						"click": {"bindTo": "onLoadMinEditPageClick"}
					})
				);
				return toolsButtonMenu;
			},

			/**
			 * @private
			 */
			_fillInteractiveElements: function(interactiveElementsList, previousButtonValues, buttonInfo) {
				let previousButton = previousButtonValues.find(buttonInfo.name);
				if (!previousButton) {
					previousButton = {
						id: Terrasoft.generateGUID(),
						performsPageCompletion: false,
						performsValidation: true
					};
				}
				const markerValue = 'interactive-element-' + previousButton.id + ' ' + buttonInfo.caption;
				const config = {
					values: {
						Caption: buttonInfo.caption,
						Name: buttonInfo.name,
						Id: previousButton.id,
						Tag: `${buttonInfo.name}_${buttonInfo.event}`,
						Event: buttonInfo.event,
						PerformsPageCompletion: previousButton.performsPageCompletion,
						ResultMarkerValue: markerValue,
						ParameterEditToolsButtonMenu: this._getToolButtonMenuList(previousButton.id),
						ProcessElement: this.get("ProcessElement"),
						InvokerUId: this.get("InvokerUId"),
						ParentModule: this,
						PerformsValidation: previousButton.performsValidation,
						RenderTo: `interactive-element-container-${previousButton.id}-interactiveElements`
					},
					Ext: Ext,
					Terrasoft: Terrasoft,
				};
				const elementViewModel = Ext.create(
					"Terrasoft.PreconfiguredPageUserTaskButtonViewModel",
					config
				);
				elementViewModel.sandbox = this.sandbox;
				elementViewModel.on("change", this.onChildViewModelChange, this);
				interactiveElementsList.add(previousButton.id, elementViewModel)
			},

			/**
			 * @private
			 */
			_getIsButtonAllowed: function(buttonInfo, previousButtonValues) {
				const allowedRequests = [
					'crt.SaveRecordRequest',
					'crt.ClosePageRequest',
					'crt.CancelRecordChangesRequest'
				];
				let result = false;
				const requests = buttonInfo.requests;
				if (Ext.isEmpty(requests)) {
					return true;
				}
				Terrasoft.each(allowedRequests, (allowedRequest) => {
					result = requests.indexOf(allowedRequest) > -1;
					if (result) {
						return false;
					}
				});
				return result || previousButtonValues.contains(buttonInfo.name);
			},

			/**
			 * @private
			 */
			_initInteractiveElementsCollection: function(interactiveElements) {
				this.$InteractiveElements.clear();
				const previousButtonValues = this._getButtonsParameterValue();
				Terrasoft.each(interactiveElements, function(buttonInfo) {
					if (!this._getIsButtonAllowed(buttonInfo, previousButtonValues)) {
						return;
					}
					this._fillInteractiveElements(this.$InteractiveElements, previousButtonValues, buttonInfo);
				}, this);
			},

			/**
			 * @private
			 */
			_getDataSourceParameters: async function(dataSources) {
				if (!dataSources){
					return [];
				}
				let promises = dataSources.map(dataSource => new Promise(resolve => {
					const item = Terrasoft.EntitySchemaManager.findItemByName(dataSource.config?.entitySchemaName);
					if (!item) {
						return resolve(null);
					}
					item.getInstance(function(entitySchema) {
						const primaryColumn = entitySchema.primaryColumn;
						const processParameter = new Terrasoft.ProcessSchemaParameter({
							uId: Terrasoft.generateGUID(),
							name: `DataSource_${dataSource.name}_${primaryColumn.name}`,
							caption: `${dataSource.name} (${entitySchema.caption}.${primaryColumn.caption})`,
							dataValueType: Terrasoft.DataValueType.LOOKUP,
							referenceSchemaUId: entitySchema.uId,
							tag: `DataSource:${dataSource.name}:PrimaryColumnValue`
						});
						resolve(processParameter);
					}, this);
				}));
				return Promise.all(promises).then(values => values.filter(parameter => parameter));
			},

			/**
			 * @private
			 */
			_synchronizeParameters: async function(element, oldParameters, clientUnitSchema, dataSources) {
				const oldRootsParameters = this.getRootsParameters(oldParameters);
				this._updateElementParametersBySchemaParameters(clientUnitSchema);
				const dataSourceParameterNames = await this._addElementParametersBySchemaDataSources(element, dataSources);
				this._clearDynamicParameters(clientUnitSchema, dataSourceParameterNames);
				oldRootsParameters.each(function(oldRootParameter) {
					if (ProcessModuleUtilities.isSystemParameter(oldRootParameter.name)) {
						return;
					}
					const newParameter = element.findParameterByName(oldRootParameter.name) ||
						element.findParameterByUId(oldRootParameter.uId);
					this.synchronizeSchemaParameter(element, newParameter, oldRootParameter);
				}, this);
			},

			/**
			 * @private
			 */
			_addElementParametersBySchemaDataSources: async function (element, dataSources) {
				const dataSourceParameters = await this._getDataSourceParameters(dataSources);
				const elementParameters = element.parameters;
				for (const parameter of dataSourceParameters) {
					const existingParameter = element.parameters.findByFn(p => p.name === parameter.name);
					if (existingParameter) {
						parameter.uid = existingParameter.uId;
						elementParameters.removeByKey(existingParameter.uId);
					}
					elementParameters.add(parameter.uId, parameter);
					this.initPageParameter(parameter, element);
				}
				return dataSourceParameters.map(p => p.name);
			},

			/**
			 * @private
			 */
			_onSchemaManagerOutdatedMessage: function(_, message) {
				if (Ext.isEmpty(message)) {
					return;
				}
				const header = message.Header;
				if (Ext.isEmpty(header) ||
					header.Sender !== "SchemaManagerItemEventNotifier" ||
					(header.BodyTypeName !== "ChangedSchema" && header.BodyTypeName !== "RemovedSchema")) {
					return;
				}
				const body = JSON.parse(message.Body);
				if (body.ManagerName !== "ClientUnitSchemaManager") {
					return;
				}
				const event = {
					schemaUId: body.UId,
					name: body.Name
				};
				this.onSchemaOutdated(event);
			},

			/**
			 * @private
			 */
			_initParameters: async function(clientUnitSchema, callback, scope) {
				const element = this.$ProcessElement;
				const links = element.parentSchema.findLinksToElements([element.name]);
				const oldParameters = element.parameters.clone();
				const isAngularSchema = this._getIsAngularSchema(clientUnitSchema?.schemaType);
				const metadataInfo = isAngularSchema ? await this._getMetadataInfo(clientUnitSchema) : null;
				this._initInteractiveElementsCollection(metadataInfo?.interactiveElements ?? []);
				await this._synchronizeParameters(element, oldParameters, clientUnitSchema, metadataInfo?.dataSources);
				this._subscribeOnParametersChanged();
				this.initPageParameters(element);
				this._checkParameterChanged(oldParameters);
				this._updateTitleParameter(clientUnitSchema.caption);
				this.invalidateDependentElements(links);
				this.validateDependedConditonalFlows(callback, scope);
			},

			/**
			 * @private
			 */
			_getMetadataInfo: function (clientUnitSchema){
				return Terrasoft.ProcessPageMetadataService.getMetadataInfo(clientUnitSchema.name, {
					interactiveElements: true,
					dataSources: {requiredTypes: "crt.EntityDataSource"}
				});
			},

			//endregion

			/**
			 * @inheritdoc BaseUserTaskPropertiesPage#init
			 * @overridden
			 */
			init: function(callback, scope) {
				this._designedSchemaUId = null;
				this.$InteractiveElements = Ext.create("Terrasoft.BaseViewModelCollection");
				this.callParent([function() {
					Terrasoft.ServerChannel.on(Terrasoft.EventName.ON_MESSAGE,
						this._onSchemaManagerOutdatedMessage, this);
					Ext.callback(callback, scope);
				}, this]);
			},

			/**
			 * @inheritdoc RootUserTaskPropertiesPage#onDestroy
			 * @overridden
			 */
			onDestroy: function() {
				Terrasoft.ServerChannel.un(Terrasoft.EventName.ON_MESSAGE,
					this._onSchemaManagerOutdatedMessage, this);
				this._unsubscribePopupMessage();
				this.callParent(arguments);
			},

			/**
			 * Re-initializes page parameters.
			 * @protected
			 * @param {Function} callback The callback function.
			 * @param {Object} scope The scope of callback function.
			 */
			initSchemaParameters: function(callback, scope) {
				this._getClientUnitSchemaInstance(function(clientUnitSchema) {
					if (!clientUnitSchema) {
						callback.call(scope);
						return;
					}
					Terrasoft.chain(
						(next) => Terrasoft.EntitySchemaManager.initialize(next, this),
						() => this._initParameters(clientUnitSchema, callback, scope)
						, this);
				}, this);
			},

			/**
			 * @inheritdoc Terrasoft.MenuItemsMappingMixin#getParameterReferenceSchemaUId
			 * @override
			 */
			getParameterReferenceSchemaUId: function(elementParameter) {
				return this.mixins.processEntryPointPropertiesPageMixin
					.getParameterReferenceSchemaUId.call(this, elementParameter);
			},

			/**
			 * @inheritdoc BaseProcessSchemaElementPropertiesPage#onElementDataLoad.
			 * @overridden
			 */
			onElementDataLoad: function(element, callback, scope) {
				this.callParent([element, function() {
					Terrasoft.chain(
						this._initUseNewShell,
						this.initClientUnitSchema,
						this.initPageSchemas,
						this.initEntitySchemas,
						function(next) {
							this.initEntitySchema(element, next, this);
						},
						function() {
							this._subscribeClientUnitSchemaChanges();
							Ext.callback(callback, scope);
						}, this);
				}, this]);
			},

			/**
			 * Initializes PageSchemas attribute.
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback function scope.
			 */
			initPageSchemas: function(callback, scope) {
				const isEnabled = Terrasoft.Features.getIsEnabled("AutoAddPackageDependenciesInProcesses");
				if (isEnabled) {
					const packageItems = Terrasoft.ClientUnitSchemaManager.getItems();
					this._initPageSchemasInternal(packageItems, callback, scope);
					return;
				}
				const packageUId = this.get("packageUId");
				Terrasoft.SchemaDesignerUtilities.buildPackageHierarchy(packageUId, function(hierarchy) {
					const packageItems = Terrasoft.ClientUnitSchemaManager.filterByFn(function (item) {
						return _.contains(hierarchy, item.packageUId);
					}, this);
					this._initPageSchemasInternal(packageItems, callback, scope);
				}, this);
			},

			/**
			 * @inheritdoc BaseProcessSchemaElementPropertiesPage#saveValues.
			 * @overridden
			 */
			saveValues: function() {
				this.revertClientUnitSchema();
				this.callParent(arguments);
				this._saveInteractiveElements();
				this.savePageParameters();
			},

			/**
			 * Initializes page parameter.
			 * @param {Terrasoft.ProcessSchemaParameter} parameter Parameter.
			 * @param {Terrasoft.ProcessUserTaskSchema} element Process user task schema.
			 */
			initPageParameter: function(parameter, element) {
				parameter.processFlowElementSchema = element;
				const processSchema = element.parentSchema;
				if (parameter.itemProperties.getCount() > 0) {
					this.initNestedPageParameter(parameter, element);
				}
				parameter.createdInSchemaUId = processSchema.uId;
			},

			/**
			 * Initializes nested page parameter.
			 * @protected
			 * @param {Terrasoft.ProcessSchemaParameter} parameter Parameter.
			 * @param {Terrasoft.ProcessBaseElementSchema} element Process element.
			 */
			initNestedPageParameter: function(parameter, element) {
				parameter.itemProperties.each(function(nestedParameter) {
					nestedParameter.processFlowElementSchema = element;
					if (nestedParameter.itemProperties.getCount() > 0) {
						this.initNestedPageParameter(nestedParameter, element);
					}
				}, this);
			},

			/**
			 * @protected
			 * @param {Terrasoft.ClientUnitSchema} pageSchema Page schema
			 */
			getPageDesignerButtonHint: function(pageSchema) {
				const stringName = pageSchema ? "OpenSchemaButtonHintCaption" : "AddSchemaButtonHintCaption";
				return this.get("Resources.Strings." + stringName);
			},

			/**
			 * @protected
			 * @param {Terrasoft.ClientUnitSchema} pageSchema Page schema.
			 */
			getPageDesignerButtonImage: function(pageSchema) {
				const imageName = pageSchema ? "OpenButtonImage" : "AddButtonImage32";
				return this.get("Resources.Images." + imageName);
			},

			_unsubscribePopupMessage: function() {
				this._8XDesignerWindowHandle?.removeEventListener('message', this._on8XDesignerMessagePosted);
			},
			
			/**
			 * @private
			 */
			_subscribePopupMessage: function(windowHandle) {
				this._unsubscribePopupMessage();
				this._8XDesignerWindowHandle = windowHandle;
				this._8XDesignerWindowHandle?.addEventListener("message",
					this._on8XDesignerMessagePosted.bind(this), false);
			},

			/**
			 * @private
			 */
			_on8XDesignerMessagePosted: function(event) {
				if (event.origin !== window.location.origin) {
					return;
				}
				if (event.data?.type !== 'StartSchemaDesign') {
					return;
				}
				this._designedSchemaUId = event.data.schemaUId;
			},

			/**
			 * Opens page designer, if schema is not inherited from template it opens 5.x client unit designer.
			 * @protected
			 * @param {String} tag Represents a tag value of the pressed menu item.
			 */
			openPageDesigner: function(tag) {
				const maskId = Terrasoft.Mask.show({
					selector: ".properties-container",
					timeout: 0
				});
				const manager = Terrasoft.ClientUnitSchemaManager;
				manager.reInitialize(function() {
					Terrasoft.Mask.hide(maskId);
					const templatePageUId = Terrasoft.FormulaParserUtils.getLookupValue(this.$Template);
					const pageUId = this.$ClientUnitSchemaUId && this.$ClientUnitSchemaUId.value;
					this._designedSchemaUId = pageUId;
					this.$IsAddSchemaButtonClicked = Ext.isEmpty(pageUId);
					manager.findInstanceByUId(pageUId, function(schema) {
						const isAngularSchema = schema && schema.schemaType === Terrasoft.SchemaType.ANGULAR_SCHEMA;
						let windowHandle;
						if (pageUId && !manager.isInheritedFrom(pageUId, templatePageUId) && !isAngularSchema) {
							ProcessModuleUtilities.showClientUnitSchemaDesigner(schema);
						} else if (isAngularSchema) {
							windowHandle = ProcessModuleUtilities.showInterfaceDesigner(pageUId);
						} else if (pageUId) {
							windowHandle = ProcessModuleUtilities.showPageSchemaDesigner(pageUId, templatePageUId);
						} else if (Terrasoft.Features.getIsEnabled("ProcessFeatures.Use8XPages") &&
								tag === 'useAngularPageTemplateLookup') {
							const packageUId = this.get('packageUId');
							windowHandle = ProcessModuleUtilities.showAngularPageTemplateLookup(packageUId);
						} else {
							windowHandle = ProcessModuleUtilities.showPageTemplateLookup();
						}
						this._subscribePopupMessage(windowHandle);
					}, this);
				}, this);
			},

			/**
			 * Handles before page schema change, shows confirmation message.
			 * @protected
			 * @param {Terrasoft.BaseViewModel} model Page view model.
			 * @param {Object} newSchema New schemas value.
			 */
			onBeforeSchemaChanged: function(model, newSchema) {
				const oldSchema = this.$PreviousClientUnitSchemaUId;
				const newSchemaUId = newSchema ? newSchema.value : "";
				const oldSchemaUId = oldSchema && oldSchema.value;
				if (!newSchemaUId || newSchemaUId === oldSchemaUId) {
					return;
				}
				if (Ext.isEmpty(oldSchema)) {
					Terrasoft.defer(this.onAfterSchemaChanged, this);
				} else {
					this.canChangeSchema(function(canChange) {
						if (canChange) {
							this.confirmSchemaChange(oldSchema);
						} else {
							this.$ClientUnitSchemaUId = oldSchema;
						}
					}, this);
				}
			},

			/**
			 * @inheritdoc RootUserTaskPropertiesPage#getSchema.
			 * @overridden
			 */
			getSchema: function() {
				return this.$ClientUnitSchemaUId;
			},

			/**
			 * @inheritdoc RootUserTaskPropertiesPage#getSchema
			 * @overridden
			 */
			setSchema: function(schema, options) {
				this.set("ClientUnitSchemaUId", schema, options);
			},

			/**
			 * @inheritdoc RootUserTaskPropertiesPage#onSchemaOutdated
			 * @overridden
			 */
			onSchemaOutdated: function(event) {
				const manager = Terrasoft.ClientUnitSchemaManager;
				const parentMethod = this.getParentMethod();
				const schemaUId = event.uId ?? event.schemaUId;
				const designedSchemaUId = this._designedSchemaUId ?? this.$ClientUnitSchemaUId?.value;
				if (schemaUId !== designedSchemaUId) {
					return;
				}
				manager.reInitialize(() => {
					const isInheritedFromTemplate = this._pageTemplates
						.some(templateUId => manager.isInheritedFrom(schemaUId, templateUId));
					manager.findInstanceByUId(schemaUId, function(schema) {
						if (isInheritedFromTemplate) {
							parentMethod.apply(this, arguments);
						} else if (schema.schemaType === Terrasoft.SchemaType.ANGULAR_SCHEMA) {
							const modifiedEvent = Ext.apply(event, {
								caption: schema.caption
							});
							parentMethod.apply(this, [modifiedEvent]);
						}
					}, this);
				});
			},

			/**
			 * @inheritdoc RootUserTaskPropertiesPage#getSchema
			 * @overridden
			 */
			getOutdatedSchema: function(event) {
				const result = {
					value: event.uId ?? event.schemaUId,
					displayValue: event.caption ?? event.name
				};
				result.displayValue += " | " + event.name;
				return result;
			},

			/**
			 * @inheritdoc ProcessFlowElementPropertiesPage#getResultParameterAllValues
			 * @overridden
			 */
			getResultParameterAllValues: function(callback, scope) {
				const resultParameterValues = {};
				const element = this.get("ProcessElement");
				const parameter = element.findParameterByName("Buttons");
				if (parameter) {
					const parameterValue = parameter.getValue();
					if (parameterValue) {
						const buttonsArray = Terrasoft.decode(parameterValue).$values;
						Terrasoft.each(buttonsArray, function(item) {
							if (item.PerformClosePage.value === "True") {
								const id = item.Id.value;
								resultParameterValues[id] = item.Caption.value;
							}
						}, this);
					}
				}
				callback.call(scope, resultParameterValues);
			}
		},
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "remove",
				"name": "RecommendationLabel"
			},
			{
				"operation": "insert",
				"name": "WhatPageToOpenLabelContainer",
				"parentName": "TitleTaskContainer",
				"propertyName": "items",
				"values": {
					"layout": { "column": 0, "row": 0, "colSpan": 24 },
					"itemType": Terrasoft.ViewItemType.CONTAINER,
					"items": [],
					"wrapClass": ["what-page-open-label-container"]
				}
			},
			{
				"operation": "insert",
				"name": "WhatPageToOpenLabel",
				"parentName": "WhatPageToOpenLabelContainer",
				"propertyName": "items",
				"values": {
					"itemType": Terrasoft.ViewItemType.LABEL,
					"caption": { "bindTo": "Resources.Strings.WhatPageToOpenLabelCaption" },
					"classes": { "labelClass": ["t-title-label-proc", "what-page-open-label"] }
				}
			},
			{
				"operation": "insert",
				"name": "OpenSchemaDesignerInfoButtonContainer",
				"parentName": "WhatPageToOpenLabelContainer",
				"propertyName": "items",
				"values": {
					"layout": { "column": 0, "row": 0, "colSpan": 24 },
					"itemType": Terrasoft.ViewItemType.CONTAINER,
					"items": [],
					"visible": {
						"bindTo": "_getIsVisibleOpenSchemaDesignerInfoButton"
					},
				}
			},
			{
				"operation": "insert",
				"name": "OpenSchemaDesignerInfoButton",
				"parentName": "OpenSchemaDesignerInfoButtonContainer",
				"propertyName": "items",
				"values": {
					"itemType": Terrasoft.ViewItemType.INFORMATION_BUTTON,
					"content": {
						"bindTo": "Resources.Strings.CannotEditAngularSchemaMessage"
					},
					"behaviour": {
						"displayEvent": Terrasoft.controls.TipEnums.displayEvent.CLICK
					},
					"controlConfig": {
						"classes": {
							"wrapperClass": "cannot-edit-angular-schema-info-button"
						}
					},
				}
			},
			{
				"operation": "insert",
				"parentName": "TitleTaskContainer",
				"propertyName": "items",
				"name": "ClientUnitSchemaUId",
				"values": {
					"layout": { "column": 0, "row": 1, "colSpan": 22 },
					"labelConfig": { "visible": false },
					"contentType": Terrasoft.ContentType.ENUM,
					"controlConfig": {
						"prepareList": { "bindTo": "onPrepareClientUnitSchemaList" },
						"filterComparisonType": Terrasoft.StringFilterType.CONTAIN
					},
					"wrapClass": ["no-caption-control"]
				}
			},
			{
				"operation": "insert",
				"parentName": "TitleTaskContainer",
				"propertyName": "items",
				"name": "OpenSchemaDesignerContainer",
				"values": {
					"itemType": Terrasoft.ViewItemType.CONTAINER,
					"items": [],
					"layout": { "column": 22, "row": 1, "colSpan": 2 }
				}
			},
			{
				"operation": "insert",
				"name": "OpenSchemaDesignerButton",
				"parentName": "OpenSchemaDesignerContainer",
				"propertyName": "items",
				"values": {
					"itemType": Terrasoft.ViewItemType.BUTTON,
					"hint": {
						"bindTo": "ClientUnitSchemaUId",
						"bindConfig": {
							"converter": "getPageDesignerButtonHint"
						}
					},
					"imageConfig": {
						"bindTo": "ClientUnitSchemaUId",
						"bindConfig": {
							"converter": "getPageDesignerButtonImage"
						}
					},
					"classes": {
						"wrapperClass": ["open-schema-designer-tool-button"]
					},
					"click": {
						"bindTo": "openPageDesigner"
					},
					"visible": {
						"bindTo": "_getIsVisibleOpenSchemaDesignerButton"
					}
				}
			},
			{
				"operation": "insert",
				"name": "OpenSchemaDesignerMenuButton",
				"parentName": "OpenSchemaDesignerContainer",
				"propertyName": "items",
				"values": {
					"itemType": Terrasoft.ViewItemType.BUTTON,
					"hint": {
						"bindTo": "ClientUnitSchemaUId",
						"bindConfig": {
							"converter": "getPageDesignerButtonHint"
						}
					},
					"imageConfig": {
						"bindTo": "ClientUnitSchemaUId",
						"bindConfig": {
							"converter": "getPageDesignerButtonImage"
						}
					},
					"classes": {
						"wrapperClass": ["open-schema-designer-tool-button"]
					},
					"menu": {
						"items": [
							{
								"id": 'Open8xPageDesigner',
								"caption": {
									"bindTo": "Resources.Strings.AngularPageTemplateLookupCaption"
								},
								"tag": "useAngularPageTemplateLookup",
								"click": {
									"bindTo": "openPageDesigner"
								}
							},
							{
								"id": "Open7xPageDesigner",
								"caption": {
									"bindTo": "Resources.Strings.PageTemplateLookupCaption"
								},
								"tag": "usePageTemplateLookup",
								"click": {
									"bindTo": "openPageDesigner"
								}
							}
						]
					},
					"visible": {
						"bindTo": "_getIsVisibleOpenSchemaDesignerMenuButton"
					},
					"style": Terrasoft.controls.ButtonEnums.style.TRANSPARENT
				}
			},
			{
				"operation": "insert",
				"name": "TaskPropertiesContainer",
				"propertyName": "items",
				"parentName": "UserTaskContainer",
				"className": "Terrasoft.Container",
				"values": {
					"layout": { "column": 0, "row": 1, "colSpan": 24 },
					"itemType": Terrasoft.ViewItemType.CONTAINER,
					"visible": {
						"bindTo": "ClientUnitSchemaUId",
						"bindConfig": { "converter": "toBoolean" }
					},
					"items": []
				}
			},
			{
				"operation": "insert",
				"parentName": "TaskPropertiesContainer",
				"propertyName": "items",
				"name": "Recommendation",
				"values": {
					"layout": { "column": 0, "row": 0, "colSpan": 24 },
					"wrapClass": ["top-caption-control"]
				}
			},
			{
				"operation": "insert",
				"parentName": "TaskPropertiesContainer",
				"propertyName": "items",
				"name": "InformationOnStep",
				"values": {
					"contentType": Terrasoft.ContentType.LONG_TEXT,
					"layout": { "column": 0, "row": 1, "colSpan": 24 },
					"wrapClass": ["top-caption-control"]
				}
			},
			{
				"operation": "insert",
				"name": "ConnectToObjectContainer",
				"parentName": "TaskPropertiesContainer",
				"propertyName": "items",
				"values": {
					"layout": { "column": 0, "row": 2, "colSpan": 24 },
					"itemType": Terrasoft.ViewItemType.CONTAINER,
					"items": [],
					"visible": {
						"bindTo": "IsAngularSchema",
						"bindConfig": { converter: "invertBooleanValue" }
					}
				}
			},
			{
				"operation": "insert",
				"name": "WhichRecordToConnectThePageToLabel",
				"parentName": "ConnectToObjectContainer",
				"propertyName": "items",
				"values": {
					"layout": { "column": 0, "row": 2, "colSpan": 24 },
					"itemType": Terrasoft.ViewItemType.LABEL,
					"caption": { "bindTo": "Resources.Strings.WhichRecordToConnectThePageToLabelCaption" },
					"classes": { "labelClass": ["t-title-label-proc"] }
				}
			},
			{
				"operation": "insert",
				"parentName": "ConnectToObjectContainer",
				"propertyName": "items",
				"name": "EntitySchemaUId",
				"values": {
					"contentType": Terrasoft.ContentType.ENUM,
					"layout": { "column": 0, "row": 3, "colSpan": 24 },
					"controlConfig": {
						"prepareList": { "bindTo": "onPrepareEntitySchemaList" },
						"filterComparisonType": Terrasoft.StringFilterType.CONTAIN
					},
					"wrapClass": ["top-caption-control"]
				}
			},
			{
				"operation": "insert",
				"parentName": "ConnectToObjectContainer",
				"propertyName": "items",
				"name": "EntityId",
				"values": {
					"layout": { "column": 0, "row": 4, "colSpan": 24 },
					"wrapClass": ["top-caption-control"],
					"enabled": { "bindTo": "EntitySchemaUId" }
				}
			},
			{
				"operation": "insert",
				"name": "InteractiveElementsContainer",
				"parentName": "TaskPropertiesContainer",
				"propertyName": "items",
				"values": {
					"layout": { "column": 0, "row": 2, "colSpan": 24 },
					"itemType": Terrasoft.ViewItemType.CONTAINER,
					"classes": {
						"wrapClassName": ["button-items-list"]
					},
					"items": [],
					"visible": {
						"bindTo": "IsAngularSchema"
					}
				}
			},
			{
				"operation": "insert",
				"name": "InteractiveElementsLabelCaption",
				"parentName": "InteractiveElementsContainer",
				"propertyName": "items",
				"values": {
					"itemType": Terrasoft.ViewItemType.LABEL,
					"styles": {
						"labelStyle": {
							"color": "#C5CC66"
						}
					},
					"caption": { "bindTo": "Resources.Strings.InteractiveElementsLabelCaption" },
				}
			},
			{
				"operation": "insert",
				"name": "InteractiveElements",
				"parentName": "InteractiveElementsContainer",
				"propertyName": "items",
				"values": {
					"itemType": Terrasoft.ViewItemType.GRID,
					"markerValue": "interactive-elements",
					"idProperty": "Id",
					"itemPrefix": "interactiveElements",
					"dataItemIdPrefix": "interactive-element",
					// "selectableRowCss": "button-item",
					"collection": { "bindTo": "InteractiveElements" },
					// "rowCssSelector": ".button-item",
					"defaultItemConfig": {
						"className": "Terrasoft.Container",
						"id": "interactive-element-container",
						"items": [
							{
								"className": "Terrasoft.Container",
								"id": "interactive-element",
								"markerValue": "$MarkerValue",
								"visible": {
									"bindTo": "Visible"
								},
								"classes": {
									"wrapClassName": ["button-item", "tools-container-wrapClass"]
								},
								"items": [
									{
										"className": "Terrasoft.Container",
										"items": [
											{
												"className": "Terrasoft.CheckBoxEdit",
												"checked": { "bindTo": "PerformsPageCompletion" },
												"markerValue": { "bindTo": "ResultMarkerValue" }
											},
											{
												"className": "Terrasoft.Label",
												"caption": { "bindTo": "Caption" },
												"click": { "bindTo": "_onLabelClick" }
											},
										],
									},
									{
										"className": "Terrasoft.Container",
										"classes": {
											"wrapClassName": ["tools-button-container-wrapClass"]
										},
										"items": [
											{
												"className": "Terrasoft.Button",
												"style": this.Terrasoft.controls.ButtonEnums.style.TRANSPARENT,
												"imageConfig": {
													"source": 3,
													"params": {
														"schemaName": "ProcessFlowElementPropertiesPage",
														"resourceItemName": "ParameterEditToolsButtonImage",
														"hash": "df03c3177a972b7f3b6987430f988ca3"
													}
												},
												"menu": {
													"items": { "bindTo": "ParameterEditToolsButtonMenu" }
												},
												"classes": {
													"imageClass": ["button-background-no-repeat"],
													"wrapperClass": ["detail-tools-button-wrapper"],
													"menuClass": ["detail-tools-button-menu"]
												},
												"prepareMenu": { "bindTo": "prepareToolsButtonMenu" },
												"markerValue": { "bindTo": "getMarkerValue" }
											}
										]
									}
								]
							}
						]
					},
					"generator": "ContainerListGenerator.generatePartial"
				}
			},
			{
				"operation": "insert",
				"name": "PageParametersLabel",
				"parentName": "TaskPropertiesContainer",
				"propertyName": "items",
				"values": {
					"layout": { "column": 0, "row": 5, "colSpan": 24 },
					"itemType": Terrasoft.ViewItemType.LABEL,
					"caption": { "bindTo": "Resources.Strings.PageParametersLabelCaption" },
					"classes": { "labelClass": ["t-title-label-proc"] },
					"visible": { "bindTo": "IsPageParametersVisible" }
				}
			},
			{
				"operation": "insert",
				"name": "PageHasNoParametersLabel",
				"parentName": "TaskPropertiesContainer",
				"propertyName": "items",
				"values": {
					"layout": { "column": 0, "row": 6, "colSpan": 24 },
					"itemType": Terrasoft.ViewItemType.LABEL,
					"caption": { "bindTo": "Resources.Strings.PageHasNoParametersLabelCaption" },
					"classes": { "labelClass": ["t-title-label-proc"] },
					"visible": { "bindTo": "PageHasNoParametersLabelVisible" }
				}
			},
			{
				"operation": "insert",
				"name": "PageParameters",
				"parentName": "TaskPropertiesContainer",
				"propertyName": "items",
				"values": {
					"layout": { "column": 0, "row": 7, "colSpan": 24 },
					"generator": "ConfigurationItemGenerator.generateHierarchicalContainerList",
					"idProperty": "ParameterEditKey",
					"nestedItemsAttributeName": "ItemProperties",
					"nestedItemsContainerId": "nested-parameters",
					"onItemClick": { "bindTo": "onItemClick" },
					"collection": "PageParameters",
					"defaultItemConfig": Terrasoft.ProcessSchemaParameterViewConfig.generate(),
					"rowCssSelector": ".paramContainer",
					"classes": { "wrapClassName": ["sub-process-parameters-container"] }
				}
			},
			{
				"operation": "insert",
				"parentName": "TaskPropertiesContainer",
				"propertyName": "items",
				"name": "useBackgroundMode",
				"values": {
					"wrapClass": ["t-checkbox-control"],
					"visible": { "bindTo": "canUseBackgroundProcessMode" },
					"layout": { "column": 0, "row": 8, "colSpan": 24 }
				}
			},
			{
				"operation": "move",
				"name": "BackgroundModePriorityConfig",
				"parentName": "TaskPropertiesContainer",
				"propertyName": "items"
			},
			{
				"operation": "merge",
				"name": "BackgroundModePriorityConfig",
				"parentName": "TaskPropertiesContainer",
				"values": {
					"layout": { "column": 0, "row": 9, "colSpan": 24 },
				}
			},
			{
				"operation": "move",
				"name": "ActivityControlsContainer",
				"parentName": "TaskPropertiesContainer",
				"propertyName": "items"
			},
			{
				"operation": "merge",
				"name": "ActivityControlsContainer",
				"parentName": "TaskPropertiesContainer",
				"values": {
					"layout": { "column": 0, "row": 10, "colSpan": 24 },
				}
			}
		]
	};
});


