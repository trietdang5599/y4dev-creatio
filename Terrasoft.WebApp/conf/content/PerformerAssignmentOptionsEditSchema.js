Terrasoft.configuration.Structures["PerformerAssignmentOptionsEditSchema"] = {innerHierarchyStack: ["PerformerAssignmentOptionsEditSchema"]};
define('PerformerAssignmentOptionsEditSchemaStructure', ['PerformerAssignmentOptionsEditSchemaResources'], function(resources) {return {schemaUId:'e8287284-31ce-41f3-8298-e82f33b5fc90',schemaCaption: "PerformerAssignmentOptionsEditSchema", parentSchemaName: "", packageName: "CrtProcessDesigner", schemaName:'PerformerAssignmentOptionsEditSchema',parentSchemaUId:'',extendParent:false,type:Terrasoft.SchemaType.EDIT_VIEW_MODEL_SCHEMA,entitySchema:'',name:'',extend:'Terrasoft.model.BaseViewModel',schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},schemaDifferences:function(){

}};});
define("PerformerAssignmentOptionsEditSchema", ["PerformerAssignmentOptionsEditSchemaResources",
		"ProcessSchemaUserTaskUtilities", "BaseFiltersGenerateModule",
		"EntitySchemaDesignerUtilities", "PackageAwareEntitySchemaDesignerUtilities",
		"MappingEditMixin", "MappingMenuBuilder"],
	function(resources, userTaskUtilities, baseFiltersGenerateModule) {
		return {
			messages: {
				/**
				 * @message GetProcessElementInfo
				 * Returns process element and package unique identifier.
				 */
				"GetProcessElementInfo": {
					"direction": Terrasoft.MessageDirectionType.PUBLISH,
					"mode": Terrasoft.MessageMode.PTP
				},
				/**
				 * @message ValidateProcessElement
				 * Validates process element.
				 */
				"ValidateProcessElement": {
					mode: Terrasoft.MessageMode.PTP,
					direction: Terrasoft.MessageDirectionType.SUBSCRIBE
				},
				/**
				 * @message SaveProcessElement
				 * Saves process element.
				 */
				"SaveProcessElement": {
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
				/**
				 * @message AssignmentTypeChanged
				 * Sends when assignment type changes.
				 */
				"AssignmentTypeChanged": {
					mode: Terrasoft.MessageMode.PTP,
					direction: Terrasoft.MessageDirectionType.PUBLISH
				}
			},
			properties: {
				/**
				 * Actions to invoke when the assignment type changes from one value to another.
				 */
				changeActions: [
					{
						from: [Terrasoft.process.enums.AssignmentType.USER,
								Terrasoft.process.enums.AssignmentType.MANAGER],
						to: [Terrasoft.process.enums.AssignmentType.ROLE],
						methodName: "_initAssigneeValueForRole"
					}, {
						from: [Terrasoft.process.enums.AssignmentType.ROLE],
						to: [Terrasoft.process.enums.AssignmentType.MANAGER,
								Terrasoft.process.enums.AssignmentType.USER],
						methodName: "_initAssigneeValueForUserOrManager"
					}
				]
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
				 * Performer assignment types list.
				 */
				"AssignmentTypeList": {
					dataValueType: Terrasoft.DataValueType.COLLECTION,
					type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN
				},
				/**
				 * Assignment type select.
				 */
				"AssignmentTypeSelect": {
					dataValueType: Terrasoft.DataValueType.ENUM,
					type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
					isRequired: true
				},
				/**
				 * Assignment type.
				 */
				"AssignmentType": {
					dataValueType: Terrasoft.DataValueType.INTEGER,
					type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN
				},
				/**
				 * Assignee value.
				 */
				"AssigneeValue": {
					dataValueType: Terrasoft.DataValueType.MAPPING,
					type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
					isRequired: true
				},
				/**
				 * Assignee value's reference schema unique identifier.
				 */
				"AssigneeValueReferenceSchemaUId" : {
					dataValueType: Terrasoft.DataValueType.GUID,
					type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN
				}
			},
			mixins: {
				mappingEditMixin: "Terrasoft.MappingEditMixin"
			},
			methods: {

				// region Methods: Public

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
						sandbox.subscribe("SaveProcessElement", this._savePerformer, this, tags);
						sandbox.subscribe("ValidateProcessElement", this._validateProcessElement, this, tags);
						this.set("AssignmentTypeList", Ext.create("Terrasoft.Collection"));
						this._initPerformer(callback, scope);
					}, this]);
				},

				/**
				 * @inheritdoc Terrasoft.MenuItemsMappingMixin#getParameterReferenceSchemaUId
				 * @override
				 */
				getParameterReferenceSchemaUId: function() {
					return this.get("AssigneeValueReferenceSchemaUId");
				},

				/**
				 * @inheritdoc Terrasoft.configuration.MenuItemsMappingMixin#getMenuItemsCollection
				 * @override
				 */
				getMenuItemsCollection: function(config) {
					this.tag = config.attributeName || this.get("Name");
					const dataValueType = Terrasoft.DataValueType.LOOKUP;
					const referenceSchemaUId = this.get("AssigneeValueReferenceSchemaUId");
					const mappingMenuBuilder = Ext.create("Terrasoft.MappingMenuBuilder", {
						_isProcessDesigner: this.getIsProcessDesigner(),
						_dataValueType: dataValueType,
						_referenceSchemaUId: referenceSchemaUId,
						_dateTimeValueType: this.getDataValueTypeForDateTimeMenuItem(dataValueType),
						_sourceColumns: this.getSourceColumns(),
						_mainRecordMappingConfig: this.getMainRecordMappingConfig()
					});
					return mappingMenuBuilder.buildMenu(config.typeMappingMenu);
				},

				/**
				 * @inheritdoc Terrasoft.configuration.EntitySchemaSelectMixin#getPackageUId
				 * @override
				 */
				getPackageUId: function() {
					return this.get("PackageUId");
				},

				/**
				 * @inheritdoc Terrasoft.BaseSchemaViewModel#setValidationConfig
				 * @overridden
				 */
				setValidationConfig: function() {
					this.callParent(arguments);
					this.addColumnValidator("AssignmentTypeSelect", userTaskUtilities.validateSelectValue);
					this.addColumnValidator("AssigneeValue", userTaskUtilities.validateMappingValue);
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
					this.set("EntitySchema", config.entitySchema);
				},

				/**
				 * @private
				 */
				_initPerformer: function(callback, scope) {
					const processElement = this.get("ProcessElement");
					const options = processElement.performerAssignmentOptions;
					if (options) {
						const assignmentType = options.assignmentType;
						this._setAssignmentTypeControlValue(assignmentType);
						this.set("AssignmentType", assignmentType, {silent: true});
						const assigneeParameterValue = this._getAssigneeParameterValue(processElement, options);
						const schemaName = assignmentType === Terrasoft.process.enums.AssignmentType.ROLE
							? "VwSysRole"
							: "Contact";
						const schemaUId = this._getReferenceSchemaUId(schemaName);
						this.set("AssigneeValueReferenceSchemaUId", schemaUId);
						this._setAssigneeControlValue(assigneeParameterValue);
						Ext.callback(callback, scope);
					} else {
						const assignmentType = Terrasoft.process.enums.AssignmentType.USER;
						this.set("AssignmentType", assignmentType, {silent: true});
						this._setAssignmentTypeControlValue(assignmentType);
						this._getDefAssigneeControlValue(processElement, function(defaultValue) {
							this._setAssigneeControlValue(defaultValue);
							Ext.callback(callback, scope);
						}, this);
					}
				},

				/**
				 * @private
				 */
				_getReferenceSchemaUId: function(schemaName) {
					const utils = this.getEntitySchemaDesignerUtilities();
					return utils.getEntitySchemaUIdByName(schemaName);
				},

				/**
				 * @private
				 */
				_getPerformerParameterValue: function(processElement) {
					const performerParameter = processElement.findPerformerParameter();
					if (performerParameter && performerParameter.hasValue()) {
						return performerParameter.getMappingValue();
					}
				},

				/**
				 * @private
				 */
				_getCurrentUserContactMappingValue: function(processElement, callback, scope) {
					const macros = Terrasoft.FormulaMacros.prepareSysVariableValue(
						Terrasoft.SystemValueType.CURRENT_USER_CONTACT);
					const mappingValue = {
						value: macros.toString(),
						source: Terrasoft.ProcessSchemaParameterValueSource.Script,
						dataValueType: Terrasoft.DataValueType.LOOKUP
					};
					const value = mappingValue.value;
					const schema = processElement.parentSchema;
					const referenceSchemaUId = this._getReferenceSchemaUId("Contact");
					this.set("AssigneeValueReferenceSchemaUId", referenceSchemaUId);
					mappingValue.referenceSchemaUId = referenceSchemaUId;
					Terrasoft.FormulaParserUtils.getFormulaDisplayValue(value, schema, function(displayValue) {
						mappingValue.displayValue = displayValue;
						Ext.callback(callback, scope, [mappingValue]);
					}, this);
				},

				/**
				 * @private
				 */
				_getDefAssigneeControlValue: function(processElement, callback, scope) {
					const performerParameterValue = this._getPerformerParameterValue(processElement);
					if (performerParameterValue) {
						Ext.callback(callback, scope, [performerParameterValue]);
						return;
					}
					this._getCurrentUserContactMappingValue(processElement, callback, scope);
				},

				/**
				 * @private
				 */
				_setAssignmentTypeControlValue: function(assignmentType) {
					const config = this._getPerformerAssignmentTypeConfig(assignmentType);
					this.set("AssignmentTypeSelect", config);
				},

				/**
				 * @private
				 */
				_setAssigneeControlValue: function(value) {
					this.set("AssigneeValue", value);
				},

				/**
				 * @private
				 */
				_applyChangeAction: function(oldAssignmentType, newAssignmentType) {
					const changeAction = Terrasoft.find(this.changeActions, function(initAction) {
						return Terrasoft.contains(initAction.from, oldAssignmentType) &&
							Terrasoft.contains(initAction.to, newAssignmentType);
						}, this);
					if (changeAction) {
						this[changeAction.methodName].apply(this);
					}
				},

				/**
				 * @private
				 */
				_getAssigneeParameterValue: function(processElement, options) {
					const parameterUId = options.assignmentType === Terrasoft.process.enums.AssignmentType.ROLE
						? options.roleParameterUId
						: options.performerParameterUId;
					const parameter = processElement.findParameterByUId(parameterUId);
					return parameter.getMappingValue();
				},

				/**
				 * @private
				 */
				_savePerformer: function() {
					const processElement = this.get("ProcessElement");
					const assignmentType = this.get("AssignmentType");
					if (!Ext.isEmpty(assignmentType)) {
						const assigneeValue = this.get("AssigneeValue");
						processElement.setPerformerAssigmentOptions({
							assignmentType: assignmentType,
							assigneeValue: assigneeValue
						});
					}
				},

				/**
				 * @private
				 */
				_validateProcessElement: function() {
					this.validate();
					const validationInfo = this.validationInfo.get("AssigneeValue");
					return [validationInfo];
				},

				/**
				 * @private
				 */
				_preparePerformerAssignmentTypesList: function(filter, list) {
					if (!list) {
						return;
					}
					const assignmentTypes = this._getPerformerAssignmentTypesConfig();
					list.clear();
					list.loadAll(assignmentTypes);
				},

				/**
				 * @private
				 */
				_getPerformerAssignmentTypeConfig: function(type) {
					const assignmentTypeCaption = Ext.String.format("AssignmentType{0}Caption", type);
					return {
						value: type,
						displayValue: resources.localizableStrings[assignmentTypeCaption]
					};
				},

				/**
				 * @private
				 */
				_getAllowedAssignmentTypes: function() {
					return [
						Terrasoft.process.enums.AssignmentType.USER,
						Terrasoft.process.enums.AssignmentType.MANAGER,
						Terrasoft.process.enums.AssignmentType.ROLE
					];
				},

				/**
				 * @private
				 */
				_getPerformerAssignmentTypesConfig: function() {
					const assignmentTypes = Terrasoft.process.enums.AssignmentType;
					const assignmentTypesConfig = Ext.create("Terrasoft.Collection");
					const allowedAssignmentTypes = this._getAllowedAssignmentTypes();
					Terrasoft.each(assignmentTypes, function(type) {
						if (Terrasoft.contains(allowedAssignmentTypes, type)) {
							const config = this._getPerformerAssignmentTypeConfig(type);
							assignmentTypesConfig.add(type, config);
						}
					}, this);
					return assignmentTypesConfig;
				},

				/**
				 * @private
				 */
				_getAllUsersFilter: function() {
					return baseFiltersGenerateModule.AllUsersFilter();
				},

				/**
				 * @private
				 */
				_applyMappingWindowConfig: function(assignmentType) {
					const column = this.columns["AssigneeValue"];
					let mappingWindowConfig = null;
					if (assignmentType !== Terrasoft.process.enums.AssignmentType.ROLE) {
						mappingWindowConfig = {
							filterMethod: "_getAllUsersFilter"
						};
					}
					column.mappingWindowConfig = mappingWindowConfig;
				},

				/**
				 * @private
				 */
				_setAssignmentType: function(assignmentType) {
					this.set("AssignmentType", assignmentType);
					this.sandbox.publish("AssignmentTypeChanged", assignmentType, [this.sandbox.id]);
					this._applyMappingWindowConfig(assignmentType);
				},

				/**
				 * @private
				 */
				_onPerformerAssignmentTypeChanged: function(value) {
					const oldAssignmentType = this.get("AssignmentType");
					const newAssignmentType = value ? value.value : null;
					if (Ext.isEmpty(oldAssignmentType) && !Ext.isEmpty(newAssignmentType)) {
						this._setAssignmentType(newAssignmentType);
						return;
					}
					if (oldAssignmentType === newAssignmentType || Ext.isEmpty(newAssignmentType)) {
						return;
					}
					this._applyChangeAction(oldAssignmentType, newAssignmentType);
					this._setAssignmentType(newAssignmentType);
				},

				/**
				 * @private
				 */
				_getMappingControlCaption: function() {
					const assignmentType = this.get("AssignmentType");
					const localizableStrings = resources.localizableStrings;
					const resourceName = Ext.String.format("AssignmentType{0}LabelCaption", assignmentType);
					return localizableStrings[resourceName];
				},
				/**
				 * @private
				 */
				_initAssigneeValueForRole: function() {
					const uId = this._getReferenceSchemaUId("VwSysRole");
					this.set("AssigneeValueReferenceSchemaUId", uId);
					this._setAssigneeControlValue({
						value: null,
						displayValue: null,
						source: Terrasoft.ProcessSchemaParameterValueSource.None,
						dataValueType: Terrasoft.DataValueType.LOOKUP,
						referenceSchemaUId: uId
					});
				},

				/**
				 * @private
				 */
				_initAssigneeValueForUserOrManager: function() {
					const processElement = this.get("ProcessElement");
					this._getCurrentUserContactMappingValue(processElement, function(defaultValue) {
						this._setAssigneeControlValue(defaultValue);
					}, this);
				}

				// endregion

			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "insert",
					"name": "PerformerAssignmentContainer",
					"values": {
						"itemType": this.Terrasoft.ViewItemType.CONTAINER,
						"visible": true,
						"items": []
					}
				},
				{
					"operation": "insert",
					"parentName": "PerformerAssignmentContainer",
					"propertyName": "items",
					"name": "AssignmentTypeSelect",
					"values": {
						"layout": {
							"column": 0,
							"row": 0,
							"colSpan": 24
						},
						"classes": {
							"labelClass": ["t-title-label-proc"]
						},
						"contentType": Terrasoft.ContentType.ENUM,
						"controlConfig": {
							"prepareList": { "bindTo": "_preparePerformerAssignmentTypesList" },
							"change": { "bindTo": "_onPerformerAssignmentTypeChanged" },
							"list": { "bindTo": "AssignmentTypeList" }
						},
						"labelConfig": {
							"visible": false
						},
						"wrapClass": ["no-caption-control"],
						"visible": true
					}
				},
				{
					"operation": "insert",
					"name": "AssignmentTypeLabel",
					"parentName": "PerformerAssignmentContainer",
					"propertyName": "items",
					"values": {
						"layout": {
							"column": 0,
							"row": 1,
							"colSpan": 24
						},
						"itemType": Terrasoft.ViewItemType.LABEL,
						"caption": { "bindTo": "_getMappingControlCaption" },
						"classes": {
							"labelClass": ["t-label-proc"]
						}
					}
				},
				{
					"operation": "insert",
					"name": "AssignmentTypeValue",
					"parentName": "PerformerAssignmentContainer",
					"propertyName": "items",
					"values": {
						"id": "AssigneeValue",
						"layout": {
							"column": 0,
							"row": 2,
							"colSpan": 24
						},
						"itemType": Terrasoft.ViewItemType.COMPONENT,
						"className": "Terrasoft.MappingEdit",
						"tag": {
							"attributeName": "AssigneeValue"
						},
						"value": {
							"bindTo": "AssigneeValue"
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
				}
			]/**SCHEMA_DIFF*/
		};
});


