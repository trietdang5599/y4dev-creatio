/**
 * Parent: BaseFileProcessingUserTaskPropertiesPage
 */
define("ProcessFileProcessingUserTaskPropertiesPage", ["ProcessFileProcessingUserTaskPropertiesPageResources",
		"ProcessSchemaUserTaskUtilities", "EntitySchemaDesignerUtilities", "ProcessUserTaskConstants"],
	function(resources, ProcessSchemaUserTaskUtilities) {
		return {
			attributes: {
				/**
				 * Source action type.
				 * @type {Integer}
				 */
				"SourceActionType": {
					dataValueType: Terrasoft.DataValueType.INTEGER,
					type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
					value: Terrasoft.ProcessUserTaskConstants.ObjectFileProcessingUserTaskSourceActionType
						.UseProcessParameter
				},
				/**
				 * Collection viewModel's controls for list of element files.
				 */
				"FilesViewModels": {
					dataValueType: this.Terrasoft.DataValueType.COLLECTION,
					type: this.Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
					isCollection: true
				},

				/**
				 * Text that is shown when changing the source action type.
				 */
				"ChangeSourceActionTypeMessage": {
					dataValueType: Terrasoft.DataValueType.TEXT,
					type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
					value: resources.localizableStrings.ChangeSourceActionTypeWarningMessage
				}
			},
			methods: {

				//region Methods: Private

				/**
				 * @private
				 */
				_initFilesParameter(element) {
					this.$FilesViewModels.clear();
					const filesParameter = element.findParameterByName("Files");
					const filesViewModel = this.createParameterViewModel(filesParameter);
					const childViewModel = filesViewModel.$ItemProperties.first();
					childViewModel.on("change:Value", this._onParameterValueChanged, this);
					childViewModel.getMainRecordMappingConfig = this.getMainRecordMappingConfig;
					this.$FilesViewModels.add(childViewModel.$Name, childViewModel);
					this._addMappingValidator(childViewModel);
					childViewModel.validate();
					if (!this.$Parameters.contains(filesParameter.name)) {
						this.$Parameters.add(filesParameter.name, filesViewModel);
					}
				},

				/**
				 * @private
				 */
				_onParameterValueChanged: function(model, value) {
					const parameterName = model.get("Name");
					const element = this.get("ProcessElement");
					const parameter = element.findParameterByName(parameterName);
					parameter.source = value.source;
					parameter.validate();
				},

				/**
				 * @private
				 */
				_saveProcessFilesMapping: function(element) {
					const viewModel = this.$FilesViewModels.first();
					const name = viewModel.get("Name");
					const parameter = element.findParameterByName(name);
					const mappingValue = viewModel.get("Value");
					parameter.setMappingValue(mappingValue);
				},

				/**
				 * Add mapping validator.
				 * @private
				 * @param {Terrasoft.ProcessSchemaParameterViewModel} viewModel View model.
				 */
				_addMappingValidator: function(viewModel) {
					let columnValidationConfig;
					const columnName = "Value";
					const viewModelColumnValidationConfig = viewModel.validationConfig[columnName];
					if (viewModelColumnValidationConfig) {
						columnValidationConfig = viewModelColumnValidationConfig;
					} else {
						columnValidationConfig = [];
						viewModel.validationConfig[columnName] = columnValidationConfig;
					}
					columnValidationConfig.push(ProcessSchemaUserTaskUtilities.validateMappingValue);
				},

				/**
				 * @private
				 */
				_removeParameter: function(parameter) {
					const filesViewModels = this.$FilesViewModels;
					const viewModel = filesViewModels.get(parameter.name);
					if (viewModel) {
						const parentParameter = parameter.getParent();
						if (this.removeParameter(parentParameter)) {
							this.$Parameters.removeByKey(parentParameter.name);
							filesViewModels.remove(viewModel);
						}
					}
				},

				/**
				 * @private
				 */
				_getHasValueInFilesParameter: function() {
					const element = this.get("ProcessElement");
					const filesParameterViewModel = element.findParameterByName("Files");
					const itemProperties = filesParameterViewModel && filesParameterViewModel.itemProperties;
					const firstItem = itemProperties && itemProperties.first();
					return Boolean(firstItem) && firstItem.hasValue();
				},

				/**
				 * @private
				 */
				_validateFilesParameter: function() {
					const isValid = this._getHasValueInFilesParameter();
					return {
						isValid: isValid,
						invalidMessage: isValid
							? null
							: Terrasoft.Resources.BaseViewModel.columnRequiredValidationMessage 
					}
				},

				//endregion

				//region Methods: Protected

				/**
				 * @inheritdoc ProcessFlowElementPropertiesPage#constructor
				 * @overridden
				 */
				constructor: function() {
					this.callParent(arguments);
					this.$FilesViewModels = Ext.create("Terrasoft.ObjectCollection");
				},

				/**
				 * @inheritdoc ProcessFlowElementPropertiesPage#saveParameters
				 * @overridden
				 */
				saveParameters: function(element) {
					this.callParent(arguments);
					this._saveProcessFilesMapping(element);
				},

				/**
				 * @inheritdoc ProcessFlowElementPropertiesPage#initParameters
				 * @protected
				 * @overridden
				 */
				initParameters: function(element) {
					this.callParent(arguments);
					this._initFilesParameter(element);
				},

				/**
				 * @inheritdoc Terrasoft.BaseFileProcessingUserTaskPropertiesPage#initResultActionType
				 * @override
				 */
				initResultActionType: function() {
					this.set("ResultActionType", Terrasoft.ProcessUserTaskConstants
						.ObjectFileProcessingUserTaskResultActionType.SaveToFiles);
				},

				/**
				 * @inheritdoc Terrasoft.BaseFileProcessingUserTaskPropertiesPage#getSelectAttributesToValidate
				 * @override
				 */
				getSelectAttributesToValidate: function() {
					const attributesToValidate = this.callParent(arguments);
					return attributesToValidate.filter(function(value) {
						return value !== "ResultActionTypeSelect";
					});
				},

				/**
				 * @inheritdoc Terrasoft.BaseFileProcessingUserTaskPropertiesPage#getIsElementConfigured
				 * @override
				 */
				getIsElementConfigured: function() {
					return this._getHasValueInFilesParameter();
				},

				/**
				 * Determines whether the result action type controls is visible or not.
				 * @protected
				 */
				getIsResultSettingsVisible: function() {
					return true;
				},

				/**
				 * @inheritdoc BaseSchemaViewModel#setValidationConfig
				 * @overridden
				 */
				setValidationConfig: function() {
					this.callParent(arguments);
					this.addColumnValidator("FilesViewModels", this._validateFilesParameter);
				},

				//endregion

			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "insert",
					"name": "ProcessFilesContainer",
					"parentName": "TargetActionParametersContainer",
					"propertyName": "items",
					"values": {
						"items": [],
						"layout": {
							"column": 0,
							"row": 0,
							"colSpan": 24
						},
						"itemType": Terrasoft.ViewItemType.CONTAINER
					}
				},
				{
					"operation": "insert",
					"name": "ProcessFilesLabel",
					"parentName": "ProcessFilesContainer",
					"propertyName": "items",
					"values": {
						"layout": {
							"column": 0,
							"row": 0,
							"colSpan": 24
						},
						"itemType": Terrasoft.ViewItemType.LABEL,
						"caption": { "bindTo": "Resources.Strings.FilesCaption" },
						"classes": {
							"labelClass": ["t-title-label-proc"]
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "ProcessFilesContainer",
					"propertyName": "items",
					"name": "ProcessFilesItemContainer",
					"values": {
						"layout": {
							"row": 1,
							"column": 0,
							"colSpan": 24
						},
						"generator": "ConfigurationItemGenerator.generateContainerList",
						"idProperty": "DataItemMarker",
						"collection": "FilesViewModels",
						"defaultItemConfig": {},
						"classes": {
							"wrapClassName": ["top-recipient-container-list"]
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "ProcessFilesItemContainer",
					"propertyName": "defaultItemConfig",
					"name": "ProcessFileItem",
					"values": {
						"id": "item",
						"itemType": Terrasoft.ViewItemType.CONTAINER,
						"items": []
					}
				},
				{
					"operation": "insert",
					"parentName": "ProcessFileItem",
					"propertyName": "items",
					"name": "ProcessFileItemView",
					"values": {
						"id": "item-view",
						"itemType": Terrasoft.ViewItemType.CONTAINER,
						"items": []
					}
				},
				{
					"operation": "insert",
					"parentName": "ProcessFileItemView",
					"propertyName": "items",
					"name": "ProcessFileValueContainer",
					"values": {
						"id": "ParameterValueContainer",
						"itemType": Terrasoft.ViewItemType.CONTAINER,
						"wrapClass": ["placeholderOpacity"],
						"items": []
					}
				},
				{
					"operation": "insert",
					"parentName": "ProcessFileValueContainer",
					"propertyName": "items",
					"name": "Value",
					"values": {
						"id": "Value",
						"itemType": Terrasoft.ViewItemType.COMPONENT,
						"className": "Terrasoft.MappingEdit",
						"value": {
							"bindTo": "Value"
						},
						"openEditWindow": {
							"bindTo": "openExtendedMappingEditWindow"
						},
						"prepareMenu": {
							"bindTo": "onPrepareMenu"
						},
						"menu": {
							"items": {
								"bindTo": "MenuItems"
							}
						},
						"cleariconclick": "$onClearIconClick"
					}
				},
				{
					"operation": "remove",
					"name": "ResultActionTypeContainer"
				}
			]/**SCHEMA_DIFF*/
		};
	}
);