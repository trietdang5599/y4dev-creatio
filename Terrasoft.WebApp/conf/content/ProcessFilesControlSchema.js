Terrasoft.configuration.Structures["ProcessFilesControlSchema"] = {innerHierarchyStack: ["ProcessFilesControlSchema"]};
define('ProcessFilesControlSchemaStructure', ['ProcessFilesControlSchemaResources'], function(resources) {return {schemaUId:'2a182a61-c42f-4f3d-8964-20d1134f9522',schemaCaption: "ProcessFilesControlSchema", parentSchemaName: "", packageName: "CrtProcessDesigner", schemaName:'ProcessFilesControlSchema',parentSchemaUId:'',extendParent:false,type:Terrasoft.SchemaType.EDIT_VIEW_MODEL_SCHEMA,entitySchema:'',name:'',extend:'Terrasoft.model.BaseViewModel',schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},schemaDifferences:function(){

}};});
define("ProcessFilesControlSchema", ["ProcessFilesControlSchemaResources",
		"ProcessSchemaUserTaskUtilities", "BaseFiltersGenerateModule",
		"EntitySchemaDesignerUtilities", "PackageAwareEntitySchemaDesignerUtilities",
		"MappingEditMixin", "MappingMenuBuilder", "css!ProcessSchemaElementPropertiesEditCSS"],
	function(resources, ProcessSchemaUserTaskUtilities) {
		return {
			messages: {
				/**
				 * @message GetProcessElementInfo
				 * Returns process element and package unique identifier.
				 */
				"GetProcessElementInfo": {
					mode: Terrasoft.MessageMode.PTP,
					direction: Terrasoft.MessageDirectionType.PUBLISH
				},

				/**
				 * @message SaveProcessElementFiles
				 * Saves process element files.
				 */
				"SaveProcessElementFiles": {
					mode: Terrasoft.MessageMode.PTP,
					direction: Terrasoft.MessageDirectionType.SUBSCRIBE
				},

				/**
				 * @message GetProcessSchema
				 * Returns process schema instance.
				 */
				"GetProcessSchema": {
					mode: Terrasoft.MessageMode.PTP,
					direction: Terrasoft.MessageDirectionType.PUBLISH
				},

				/**
				 * @message SetParametersInfo
				 * Sets parameters info.
				 */
				"SetParametersInfo": {
					mode: Terrasoft.MessageMode.PTP,
					direction: Terrasoft.MessageDirectionType.SUBSCRIBE
				},

				"CreateFile": {
					mode: Terrasoft.MessageMode.PTP,
					direction: Terrasoft.MessageDirectionType.SUBSCRIBE
				},

				"GetFiles": {
					mode: Terrasoft.MessageMode.PTP,
					direction: Terrasoft.MessageDirectionType.PUBLISH
				},

				/**
				 * @message CreateParameterViewModel
				 * Creates parameter view model.
				 */
				"CreateParameterViewModel": {
					mode: Terrasoft.MessageMode.PTP,
					direction: Terrasoft.MessageDirectionType.PUBLISH
				},

				/**
				 * @message GetFileParameterConfig
				 * Returns file parameter configuration.
				 */
				"GetFileParameterConfig": {
					mode: Terrasoft.MessageMode.PTP,
					direction: Terrasoft.MessageDirectionType.PUBLISH
				},

				/**
				 * @message FileParameterAdded
				 * Sent when file parameter is added.
				 */
				"FileParameterAdded": {
					mode: Terrasoft.MessageMode.PTP,
					direction: Terrasoft.MessageDirectionType.PUBLISH
				},

				/**
				 * @message FileParameterRemoved
				 * Sent when file parameter is removed.
				 */
				"FileParameterRemoved": {
					mode: Terrasoft.MessageMode.PTP,
					direction: Terrasoft.MessageDirectionType.PUBLISH
				}
			},
			attributes: {
				/**
				 * Package unique identifier.
				 */
				"PackageUId": {
					dataValueType: Terrasoft.DataValueType.TEXT,
					type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN
				},

				/**
				 * Process element.
				 */
				"ProcessElement": {
					dataValueType: Terrasoft.DataValueType.CUSTOM_OBJECT,
					type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN
				},

				/**
				 * Collection viewModel's controls for the list of files.
				 */
				"Files": {
					"dataValueType": this.Terrasoft.DataValueType.COLLECTION,
					"type": this.Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"isCollection": true
				},

				/**
				 * Caption for the button to add files.
				 */
				"AddFileButtonCaption": {
					"dataValueType": this.Terrasoft.DataValueType.TEXT,
					"type": this.Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				},

				/**
				 * Image for the button to add files.
				 */
				"AddFileButtonImage": {
					"dataValueType": this.Terrasoft.DataValueType.IMAGE,
					"type": this.Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				},

				/**
				 * Regular expression to filter files parameters.
				 */
				"FilesFilterRegex": {
					"dataValueType": this.Terrasoft.DataValueType.TEXT,
					"type": this.Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				}
			},
			mixins: {
				mappingEditMixin: "Terrasoft.MappingEditMixin"
			},
			methods: {

				// region Methods: Public

				constructor: function() {
					this.callParent(arguments);
					this.$Files = Ext.create("Terrasoft.ObjectCollection");
				},

				/**
				 * @inheritdoc Terrasoft.configuration.BaseSchemaViewModel#init
				 * @override
				 * @param {Function} callback Callback function.
				 * @param {Object} scope Callback scope.
				 */
				init: function(callback, scope) {
					this.callParent([function() {
						const sandbox = this.sandbox;
						const tags = [sandbox.id];
						const config = sandbox.publish("GetProcessElementInfo", null, tags);
						this._setAttributes(config);
						sandbox.subscribe("SaveProcessElementFiles", this._saveFiles, this, tags);
						sandbox.subscribe("CreateFile", this._createFile, this, tags);
						this._initFiles();
						sandbox.publish("GetFiles", this.$Files, tags);
						Ext.callback(callback, scope);
					}, this]);
				},

				/**
				 * @inheritdoc Terrasoft.configuration.EntitySchemaSelectMixin#getPackageUId
				 * @override
				 */
				getPackageUId: function() {
					return this.get("PackageUId");
				},

				// endregion

				//region Methods: Protected

				/**
				 * @inheritdoc Terrasoft.configuration.EntitySchemaSelectMixin#getEntitySchemaDesignerUtilities
				 * @override
				 */
				getEntitySchemaDesignerUtilities: function() {
					if (Terrasoft.Features.getIsEnabled("AutoAddPackageDependenciesInProcesses")) {
						return Terrasoft.EntitySchemaDesignerUtilities.create();
					}
					const packageUId = this.getPackageUId();
					return Terrasoft.PackageAwareEntitySchemaDesignerUtilities.create(packageUId);
				},

				//endregion

				// region Methods: Private

				/**
				 * @private
				 */
				_setAttributes: function(config) {
					this.set("PackageUId", config.packageUId);
					this.set("ProcessElement", config.processElement);
				},

				/**
				 * @private
				 */
				_createParameterViewModel: function(parameter) {
					return this.sandbox.publish("CreateParameterViewModel", parameter, [this.sandbox.id]);
				},

				/**
				 * @private
				 */
				_addFile: function(parameter) {
					const parameterViewModel = this._createParameterViewModel(parameter);
					parameterViewModel.validate();
					this._addMappingValidator(parameterViewModel);
					const filesList = this.$Files;
					const childViewModel = parameterViewModel.$ItemProperties.first();
					this._prepareParameterViewModel(childViewModel);
					this._addMappingValidator(childViewModel);
					filesList.add(childViewModel.$Name, childViewModel);
					this.sandbox.publish("FileParameterAdded", parameterViewModel, [this.sandbox.id]);
				},

				/**
				 * @private
				 */
				_createFileParameter: function() {
					const processElement = this.get("ProcessElement");
					const parameterConfig = this._getFileParameterConfig();
					const elementParameter = Ext.create("Terrasoft.ProcessSchemaParameter", parameterConfig);
					processElement.parameters.add(elementParameter.uId, elementParameter);
					return elementParameter;
				},

				/**
				 * @private
				 */
				_generateParameterName: function(collection, prefix) {
					const filterFn = function (item, name) {
						return item.name === name;
					};
					return ProcessSchemaUserTaskUtilities.generateItemUniqueName(prefix, collection, filterFn);
				},

				/**
				 * @private
				 */
				_getFileParameterConfig: function() {
					const fileParameterConfig = this.sandbox.publish("GetFileParameterConfig", null, [this.sandbox.id]);
					const processElement = this.get("ProcessElement");
					const parentSchema = processElement.parentSchema;
					const processSchemaUId = parentSchema.uId;
					const parameters = processElement.parameters;
					const name = this._generateParameterName(parameters, fileParameterConfig.fileCollectionParameterNamePrefix);
					const caption = fileParameterConfig.fileCollectionParameterCaption;
					const fileLocatorParameterConfig = {
						uId: Terrasoft.generateGUID(),
						caption: Ext.create("Terrasoft.LocalizableString", {
							cultureValues: fileParameterConfig.fileLocatorParameterCaption
						}),
						createdInSchemaUId: processSchemaUId,
						modifiedInSchemaUId: processSchemaUId,
						name: name + "FileLocator",
						dataValueType: Terrasoft.DataValueType.FILE_LOCATOR,
						direction: Terrasoft.ProcessSchemaParameterDirection.IN,
						sourceValue: {
							source: Terrasoft.ProcessSchemaParameterValueSource.None
						},
						skipValidation: true,
						forceRemove: true,
						processFlowElementSchema: processElement,
					};
					return {
						uId: Terrasoft.generateGUID(),
						caption: Ext.create("Terrasoft.LocalizableString", {
							cultureValues: caption
						}),
						createdInSchemaUId: processSchemaUId,
						modifiedInSchemaUId: processSchemaUId,
						name: name,
						dataValueType: Terrasoft.DataValueType.COMPOSITE_OBJECT_LIST,
						direction: Terrasoft.ProcessSchemaParameterDirection.IN,
						sourceValue: {
							source: Terrasoft.ProcessSchemaParameterValueSource.None
						},
						itemProperties: [fileLocatorParameterConfig],
						processFlowElementSchema: processElement,
					};
				},

				/**
				 * @private
				 */
				_createFile: function() {
					const parameter = this._createFileParameter();
					this._addFile(parameter);
				},

				/**
				 * @private
				 */
				_findFilesParameters: function(element) {
					const pattern = this.get("FilesFilterRegex");
					const regExp = new RegExp(pattern);
					return element.parameters.filterByFn(function(parameter) {
						return parameter.getIsDynamic() && !parameter.hasParent() && regExp.test(parameter.name);
					}, this);
				},

				/**
				 * @private
				 */
				_initFiles: function() {
					const element = this.get("ProcessElement");
					this.$Files.clear();
					const parameters = this._findFilesParameters(element);
					parameters.each(this._addFile, this);
				},

				/**
				 * Prepares right data item markers for parameter item.
				 * @private
				 * @param {Terrasoft.BaseViewModel} viewModel Parameter view model.
				 */
				_prepareParameterDataItemMarker: function(viewModel) {
					const parameterName = viewModel.get("Name");
					const dataItemMarker = Ext.String.format("{0}-{1}", parameterName, Terrasoft.generateGUID());
					viewModel.set("DataItemMarker", dataItemMarker);
				},

				/**
				 * @private
				 */
				_onParameterValueChanged: function(model, recipientValue) {
					const parameterName = model.get("Name");
					const element = this.get("ProcessElement");
					const parameter = element.findParameterByName(parameterName);
					parameter.dataValueType = recipientValue.dataValueType;
					parameter.source = recipientValue.source;
				},

				/**
				 * @private
				 */
				_prepareParameterViewModel: function(viewModel) {
					this._prepareParameterDataItemMarker(viewModel);
					viewModel.on("change:Value", this._onParameterValueChanged, this);
					viewModel.getMainRecordMappingConfig = this.getMainRecordMappingConfig;
				},

				/**
				 * @private
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
				_saveFiles: function() {
					const element = this.get("ProcessElement");
					this.$Files.each(function(viewModel) {
						const name = viewModel.get("Name");
						const parameter = element.findParameterByName(name);
						const mappingValue = viewModel.get("Value");
						parameter.setMappingValue(mappingValue);
						if (Ext.isEmpty(mappingValue.value)) {
							this._removeFile(parameter);
						}
					}, this);
				},

				/**
				 * @private
				 */
				_removeParameter: function(parameter) {
					const element = this.get("ProcessElement");
					const process = element.parentSchema;
					let canRemove = false;
					if (element.getAllLazyParametersAreLoaded()) {
						const result = process.canRemoveParameter(parameter);
						if (result.canRemove) {
							element.parameters.remove(parameter);
							this.sandbox.publish("FileParameterRemoved", parameter.uId, [this.sandbox.id]);
							canRemove = true;
						}
					}
					return canRemove;
				},

				/**
				 * @private
				 */
				_removeFile: function(parameter) {
					const filesViewModels = this.$Files;
					const viewModel = filesViewModels.get(parameter.name);
					if (viewModel) {
						const parentParameter = parameter.getParent();
						if (this._removeParameter(parentParameter)) {
							filesViewModels.remove(viewModel);
						}
					}
				},

				// endregion

			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "insert",
					"propertyName": "items",
					"name": "FilesContainer",
					"values": {
						"layout": { "column": 0, "row": 11, "colSpan": 24 },
						"itemType": Terrasoft.ViewItemType.CONTAINER,
						"items": []
					}
				},
				{
					"operation": "insert",
					"parentName": "FilesContainer",
					"propertyName": "items",
					"name": "AddFileContainer",
					"values": {
						"itemType": Terrasoft.ViewItemType.CONTAINER,
						"wrapClass": ["container-list-header"],
						"items": []
					}
				},
				{
					"operation": "insert",
					"parentName": "AddFileContainer",
					"propertyName": "items",
					"name": "AddFileItemsLabel",
					"values": {
						"itemType": this.Terrasoft.ViewItemType.LABEL,
						"classes": {
							"labelClass": ["t-title-label-proc"]
						},
						"caption": {
							"bindTo": "AddFileButtonCaption"
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "AddFileContainer",
					"propertyName": "items",
					"name": "AddFileItemsToolsButton",
					"values": {
						"itemType": this.Terrasoft.ViewItemType.BUTTON,
						"classes": {
							"menuClass": ["detail-tools-button-menu"]
						},
						"imageConfig": {
							"bindTo": "AddFileButtonImage"
						},
						"style": this.Terrasoft.controls.ButtonEnums.style.TRANSPARENT,
						"click": {
							"bindTo": "_createFile"
						},
					}
				},
				{
					"operation": "insert",
					"parentName": "FilesContainer",
					"propertyName": "items",
					"name": "FileItemContainer",
					"values": {
						"generator": "ConfigurationItemGenerator.generateHierarchicalContainerList",
						"idProperty": "DataItemMarker",
						"collection": "Files",
						"defaultItemConfig": {},
						"rowCssSelector": ".paramContainer",
						"classes": {
							"wrapClassName": ["top-recipient-container-list"]
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "FileItemContainer",
					"propertyName": "defaultItemConfig",
					"name": "FileItem",
					"values": {
						"id": "item",
						"itemType": Terrasoft.ViewItemType.CONTAINER,
						"items": []
					}
				},
				{
					"operation": "insert",
					"parentName": "FileItem",
					"propertyName": "items",
					"name": "FileItemView",
					"values": {
						"id": "item-view",
						"itemType": Terrasoft.ViewItemType.CONTAINER,
						"items": []
					}
				},
				{
					"operation": "insert",
					"parentName": "FileItemView",
					"propertyName": "items",
					"name": "FileValueContainer",
					"values": {
						"id": "ParameterValueContainer",
						"itemType": Terrasoft.ViewItemType.CONTAINER,
						"wrapClass": ["placeholderOpacity"],
						"items": []
					}
				},
				{
					"operation": "insert",
					"parentName": "FileValueContainer",
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
						}
					}
				},
			]/**SCHEMA_DIFF*/
		};
});


