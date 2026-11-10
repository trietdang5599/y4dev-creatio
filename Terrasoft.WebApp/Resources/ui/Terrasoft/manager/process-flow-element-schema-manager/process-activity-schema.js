/**
 * Schema of the process activity element.
 */
Ext.define("Terrasoft.manager.ProcessActivitySchema", {
	extend: "Terrasoft.manager.ProcessFlowElementSchema",
	alternateClassName: "Terrasoft.ProcessActivitySchema",

	mixins: {
		parametrizedProcessSchemaElement: "Terrasoft.ParametrizedProcessSchemaElement"
	},

	//region Properties: Private

	/**
	 * @private
	 */
	_parameterCaptionResources: {
		"InputRecordCollection": "InputRecordCollection",
		"OutputRecordCollection": "OutputRecordCollection",
		"CompletedIterationsCount": "CompletedIterationsCountParameter",
		"TerminatedIterationsCount": "TerminatedIterationsCountParameter",
		"TotalIterationsCount": "TotalIterationsCountParameter",
		"OwnerId": "OwnerId",
		"RoleId": "RoleId"
	},

	//endregion

	//region Properties: Protected

	/**
	 * Service contract name.
	 * @protected
	 * @type {String}
	 */
	contractName: "ContractProcessUserTaskSchema",

	/**
	 * Flag that indicates is element used for compensation.
	 * @protected
	 * @type {Boolean}
	 */
	isForCompensation: false,

	/**
	 * Flag that indicates is element user task.
	 * @protected
	 * @type {Boolean}
	 */
	isUserTask: true,

	/**
	 * Schema query filter.
	 * @protected
	 * @type {object}
	 */
	schemaFilter: null,

	/**
	 * Schema manager name.
	 * @protected
	 * @type {String}
	 */
	schemaManagerName: null,

	/**
	 * @inheritdoc Terrasoft.manager.ProcessBaseElementSchema#silverlightOffsetX
	 * @override
	 */
	silverlightOffsetX: 0,

	/**
	 * @inheritdoc Terrasoft.manager.ProcessBaseElementSchema#silverlightOffsetY
	 * @override
	 */
	silverlightOffsetY: 0,

	/**
	 * @inheritdoc Terrasoft.manager.ProcessBaseElementSchema#width
	 * @override
	 */
	width: 69,

	/**
	 * @inheritdoc Terrasoft.manager.ProcessBaseElementSchema#height
	 * @protected
	 * @override
	 */
	height: 55,

	/**
	 * Entity schema identifier.
	 * @protected
	 * @type {String}
	 */
	entitySchemaUId: null,

	/**
	 * Multi instance schema options.
	 * @type {Terrasoft.ProcessSchemaMultiInstanceOptions}
	 */
	multiInstanceOptions: null,

	/**
	 * Multi instance schema options.
	 * @type {Terrasoft.ProcessSchemaPerformerAssignmentOptions}
	 */
	performerAssignmentOptions: null,

	//endregion

	//region Constructors: Public

	constructor: function(config) {
		this.callParent(arguments);
		this.mixins.parametrizedProcessSchemaElement.constructor.call(this);
		if (config && config.multiInstanceOptions) {
			this.multiInstanceOptions = Ext.create("Terrasoft.ProcessSchemaMultiInstanceOptions",
				config.multiInstanceOptions);
		}
		if (config && config.performerAssignmentOptions) {
			this.performerAssignmentOptions = Ext.create("Terrasoft.ProcessSchemaPerformerAssignmentOptions",
				config.performerAssignmentOptions);
		}
		this.schemaFilter = {
			ManagerName: this.schemaManagerName,
			UseExtendParent: false
		};
	},

	//endregion

	//region Methods: Private

	/**
	 * @private
	 */
	_createMultiInstanceParameter: function(config) {
		const collectionParameter = this.createParameter(config);
		this._actualizeParameterCaption(collectionParameter);
		return collectionParameter;
	},

	/**
	 * @private
	 */
	_createInputRecordCollectionParameter: function() {
		return this._createMultiInstanceParameter({
			name: "InputRecordCollection",
			dataValueType: Terrasoft.DataValueType.COMPOSITE_OBJECT_LIST,
			direction: Terrasoft.ProcessSchemaParameterDirection.IN
		});
	},

	/**
	 * @private
	 */
	_createOutputRecordCollectionParameter: function() {
		return this._createMultiInstanceParameter({
			name: "OutputRecordCollection",
			dataValueType: Terrasoft.DataValueType.COMPOSITE_OBJECT_LIST,
			direction: Terrasoft.ProcessSchemaParameterDirection.OUT
		});
	},

	/**
	 * @private
	 */
	_createCompletedIterationsCountParameter: function() {
		return this._createMultiInstanceParameter({
			name: "CompletedIterationsCount",
			dataValueType: Terrasoft.DataValueType.INTEGER,
			direction: Terrasoft.ProcessSchemaParameterDirection.OUT
		});
	},

	/**
	 * @private
	 */
	_createTerminatedIterationsCountParameter: function() {
		return this._createMultiInstanceParameter({
			name: "TerminatedIterationsCount",
			dataValueType: Terrasoft.DataValueType.INTEGER,
			direction: Terrasoft.ProcessSchemaParameterDirection.OUT
		});
	},

	/**
	 * @private
	 */
	_createTotalIterationsCountParameter: function() {
		return this._createMultiInstanceParameter({
			name: "TotalIterationsCount",
			dataValueType: Terrasoft.DataValueType.INTEGER,
			direction: Terrasoft.ProcessSchemaParameterDirection.OUT
		});
	},

	/**
	 * @private
	 */
	_createRoleParameter: function() {
		const parameter = this.createParameter({
			name: "RoleId",
			dataValueType: Terrasoft.DataValueType.LOOKUP,
			referenceSchemaName: "SysAdminUnit",
			direction: Terrasoft.ProcessSchemaParameterDirection.VARIABLE
		});
		this._actualizeParameterCaption(parameter);
		return parameter;
	},

	/**
	 * @private
	 */
	_createPerformerParameter: function() {
		const parameter = this.createParameter({
			name: "OwnerId",
			dataValueType: Terrasoft.DataValueType.LOOKUP,
			referenceSchemaName: "Contact",
			direction: Terrasoft.ProcessSchemaParameterDirection.VARIABLE,
			isPerformer: true
		});
		this._actualizeParameterCaption(parameter);
		return parameter;
	},

	/**
	 * @private
	 */
	_forceGetPerformerParameter: function() {
		if (this.performerAssignmentOptions.performerParameterUId) {
			return this._getPerformerParameter();
		}
		let performerParameter = this.findPerformerParameter();
		if (!performerParameter) {
			performerParameter = this._createPerformerParameter();
			this.parameters.add(performerParameter.uId, performerParameter);
		}
		this.performerAssignmentOptions.performerParameterUId = performerParameter.uId;
		return performerParameter;
	},

	/**
	 * @private
	 */
	_forceGetRoleParameter: function() {
		if (this.performerAssignmentOptions.roleParameterUId) {
			return this._getRoleParameter();
		}
		const parameters = this.parameters;
		const roleParameter = this._createRoleParameter();
		parameters.add(roleParameter.uId, roleParameter);
		this.performerAssignmentOptions.roleParameterUId = roleParameter.uId;
		return roleParameter;
	},

	/**
	 * @private
	 */
	_getPerformerParameter: function() {
		const parameterUId = this.performerAssignmentOptions.performerParameterUId;
		return this.parameters.get(parameterUId);
	},

	/**
	 * @private
	 */
	_getRoleParameter: function() {
		const parameterUId = this.performerAssignmentOptions.roleParameterUId;
		return this.parameters.get(parameterUId);
	},

	/**
	 * @private
	 */
	_getInputCollectionParameter: function() {
		const inputCollectionParameterUId = this.multiInstanceOptions.inputCollectionParameterUId;
		return this.parameters.get(inputCollectionParameterUId);
	},

	/**
	 * @private
	 */
	_getOutputCollectionParameter: function() {
		const outputCollectionParameterUId = this.multiInstanceOptions.outputCollectionParameterUId;
		return this.parameters.get(outputCollectionParameterUId);
	},

	/**
	 * @private
	 */
	_getCompletedIterationsCountParameter: function() {
		const completedIterationsCountParameterUId = this.multiInstanceOptions.completedIterationsCountParameterUId;
		return this.parameters.get(completedIterationsCountParameterUId);
	},

	/**
	 * @private
	 */
	_getTerminatedIterationsCountParameter: function() {
		const terminatedIterationsCountParameterUId = this.multiInstanceOptions.terminatedIterationsCountParameterUId;
		return this.parameters.get(terminatedIterationsCountParameterUId);
	},

	/**
	 * @private
	 */
	_getTotalIterationsCountParameter: function() {
		const totalIterationsCountParameterUId = this.multiInstanceOptions.totalIterationsCountParameterUId;
		return this.parameters.get(totalIterationsCountParameterUId);
	},

	/**
	 * @private
	 */
	_fillCollectionParameters: function(inputCollectionParameter, outputCollectionParameter) {
		const parameters = this.getRootParameters();
		const inputItemProperties = inputCollectionParameter.itemProperties;
		const outputItemProperties = outputCollectionParameter.itemProperties;
		const variableDirectionParameterUId = outputCollectionParameter.uId;
		parameters.each(function (parameter) {
			if (parameter.direction === Terrasoft.process.enums.ProcessSchemaParameterDirection.VARIABLE) {
				inputItemProperties.add(parameter.uId, parameter);
				const clonedParameter = parameter.clone();
				clonedParameter.uId = Terrasoft.xorToGUID(parameter.uId, variableDirectionParameterUId);
				clonedParameter.clearSourceValue();
				outputItemProperties.add(clonedParameter.uId, clonedParameter);
			} else if (parameter.direction === Terrasoft.process.enums.ProcessSchemaParameterDirection.OUT) {
				outputItemProperties.add(parameter.uId, parameter);
			} else {
				inputItemProperties.add(parameter.uId, parameter);
			}
		});
		parameters.clear();
		parameters.add(inputCollectionParameter.uId, inputCollectionParameter);
		parameters.add(outputCollectionParameter.uId, outputCollectionParameter);
	},

	/**
	 * @private
	 */
	_fillIterationsCountParameters: function(completedIterationsCountParameter, terminatedIterationsCountParameter,
			totalIterationsCountParameter) {
		const parameters = this.parameters;
		parameters.add(completedIterationsCountParameter.uId, completedIterationsCountParameter);
		parameters.add(terminatedIterationsCountParameter.uId, terminatedIterationsCountParameter);
		parameters.add(totalIterationsCountParameter.uId, totalIterationsCountParameter);
	},

	/**
	 * @private
	 */
	_convertToSingleInstanceElementParameters: function() {
		const inputCollectionParameter = this._getInputCollectionParameter();
		const outputCollectionParameter = this._getOutputCollectionParameter();
		const allParameters = Ext.create("Terrasoft.ProcessSchemaParameterCollection");
		outputCollectionParameter.itemProperties.each(function (parameter) {
			if (parameter.direction === Terrasoft.process.enums.ProcessSchemaParameterDirection.OUT) {
				allParameters.add(parameter.uId, parameter);
			}
		});
		allParameters.loadAll(inputCollectionParameter.itemProperties);
		this.parameters = allParameters;
		inputCollectionParameter.itemProperties.clear();
		outputCollectionParameter.itemProperties.clear();
	},

	/**
	 * @private
	 */
	_actualizeMultiInstanceParameters: function() {
		if (!this.getIsMultiInstanceModeEnabled()) {
			return;
		}
		const multiInstanceParameters = [
			this._getInputCollectionParameter(),
			this._getOutputCollectionParameter(),
			this._getCompletedIterationsCountParameter(),
			this._getTerminatedIterationsCountParameter(),
			this._getTotalIterationsCountParameter()
		];
		Terrasoft.each(multiInstanceParameters, this._actualizeParameterCaption, this);
	},

	/**
	 * @private
	 */
	_actualizePerformerAssignmentParameterCaptions: function() {
		if (!this.performerAssignmentOptions) {
			return;
		}
		const parameters = [
			this._getPerformerParameter(),
			this._getRoleParameter()
		];
		Terrasoft.each(parameters, this._actualizeParameterCaption, this);
	},

	/**
	 * @private
	 */
	_actualizeParameterCaption: function(parameter) {
		if (!parameter) {
			return;
		}
		const resourceKey = this._parameterCaptionResources[parameter.name];
		const resourceManager = Terrasoft.Resources.ProcessSchemaDesigner;
		const currentCultureCaption = Terrasoft.findValueByPath(resourceManager,`${resourceKey}.Caption`);
		parameter.caption.setValue(currentCultureCaption);
	},

	//endregion

	//region Methods: Protected

	/**
	 * @inheritdoc Terrasoft.manager.BaseSchema#getSerializableObject
	 * @override
	 */
	getSerializableObject: function() {
		this.callParent(arguments);
		this.mixins.parametrizedProcessSchemaElement.getSerializableObject.apply(this, arguments);
	},

	/**
	 * @inheritdoc Terrasoft.manager.BaseSchema#getSerializableProperties
	 * @override
	 */
	getSerializableProperties: function() {
		const baseSerializableProperties = this.callParent(arguments);
		return Ext.Array.push(baseSerializableProperties, ["isUserTask", "isForCompensation", "entitySchemaUId",
			"multiInstanceOptions", "performerAssignmentOptions"]);
	},

	/**
	 * Returns process schema parameter.
	 * @protected
	 * @param {Object} config Parameter configuration.
	 */
	createParameter: function(config) {
		const parameterConfig = {
			...config,
			uId: Terrasoft.generateGUID(),
			sourceValue: {
				source: Terrasoft.ProcessSchemaParameterValueSource.None,
				isValid: true
			},
			createdInSchemaUId: this.parentSchema.uId,
			modifiedInSchemaUId: this.parentSchema.uId
		};
		const parameter = Ext.create("Terrasoft.ProcessSchemaParameter", parameterConfig);
		parameter.processFlowElementSchema = this;
		return parameter;
	},

	//endregion

	//region Methods: Public

	/**
	 * @inheritdoc Terrasoft.manager.ProcessBaseElementSchema#loadLocalizableValues
	 * @override
	 */
	loadLocalizableValues: function(localizableValues) {
		this.callParent(arguments);
		this.loadParametersLocalizableValues(localizableValues);
		this._actualizeMultiInstanceParameters();
		this._actualizePerformerAssignmentParameterCaptions();
	},

	/**
	 * @inheritdoc Terrasoft.manager.ProcessBaseElementSchema#loadLocalizableValuesByUIds
	 * @override
	 */
	loadLocalizableValuesByUIds: function(localizableValues) {
		this.callParent(arguments);
		this.loadParametersLocalizableValuesByUIds(localizableValues);
		this._actualizeMultiInstanceParameters();
		this._actualizePerformerAssignmentParameterCaptions();
	},

	/**
	 * @inheritdoc Terrasoft.manager.ProcessBaseElementSchema#getParametersLocalizableValues
	 * @override
	 */
	getLocalizableValues: function(localizableValues) {
		this.callParent(arguments);
		this.getParametersLocalizableValues(localizableValues);
	},

	/**
	 * @inheritdoc Terrasoft.BaseProcessSchemaElement#internalValidate
	 * Validate parameters.
	 * @override
	 */
	internalValidate: function() {
		const result = this.callParent(arguments);
		const parametersValidationResult = this.validateParameters.apply(this, arguments);
		Ext.Array.push(result, parametersValidationResult);
		return result;
	},

	/**
	 * @inheritdoc Terrasoft.ProcessFlowElementSchema#getIsMultiInstanceModeEnabled
	 * @override
	 * @returns {boolean}
	 */
	getIsMultiInstanceModeEnabled: function() {
		return Boolean(this.multiInstanceOptions);
	},

	/**
	 * Returns parameter by the specified name or unique identifier.
	 * @param {String} name Parameter name.
	 * @param {String} uId Parameter unique identifier.
	 * @return {Terrasoft.ProcessSchemaParameter}
	 */
	findParameterByNameOrByUId: function(name, uId) {
		return this.findParameterByName(name) || this.findParameterByUId(uId);
	},

	/**
	 * Converts to multi instance execution mode.
	 */
	convertToMultiInstance: function() {
		if (this.getIsMultiInstanceModeEnabled()) {
			return;
		}
		const inputCollectionParameter = this._createInputRecordCollectionParameter();
		const outputCollectionParameter = this._createOutputRecordCollectionParameter();
		const completedIterationsCountParameter = this._createCompletedIterationsCountParameter();
		const terminatedIterationsCountParameter = this._createTerminatedIterationsCountParameter();
		const totalIterationsCountParameter = this._createTotalIterationsCountParameter();
		this._fillCollectionParameters(inputCollectionParameter, outputCollectionParameter);
		this._fillIterationsCountParameters(completedIterationsCountParameter, terminatedIterationsCountParameter,
			totalIterationsCountParameter);
		this.multiInstanceOptions = Ext.create("Terrasoft.ProcessSchemaMultiInstanceOptions", {
			inputCollectionParameterUId: inputCollectionParameter.uId,
			outputCollectionParameterUId: outputCollectionParameter.uId,
			completedIterationsCountParameterUId: completedIterationsCountParameter.uId,
			terminatedIterationsCountParameterUId: terminatedIterationsCountParameter.uId,
			totalIterationsCountParameterUId: totalIterationsCountParameter.uId
		});
		const markers = this.getMarkersConfig();
		this.fireEvent("changed", {markers}, this);
	},

	/**
	 * Changes multi-instance execution mode.
	 */
	changeMultiInstanceExecutionMode: function(executionMode) {
		const multiInstanceOptions = this.multiInstanceOptions;
		if (!Boolean(multiInstanceOptions) || multiInstanceOptions.executionMode === executionMode) {
			return;
		}
		multiInstanceOptions.executionMode = executionMode;
		const markers = this.getMarkersConfig();
		this.fireEvent("changed", {markers}, this);
	},

	/**
	 * @inheritDoc Terrasoft.manager.ProcessBaseElementSchema#getMarkersConfig
	 * @override
	 */
	getMarkersConfig: function () {
		if (!this.multiInstanceOptions) {
			return {};
		}
		return this.multiInstanceOptions.executionMode === Terrasoft.process.MultiInstanceExecutionMode.PARALLEL
			? {Loops: "ParallelMultiInstance"}
			: {Loops: "SequenceMultiInstance"};
	},

	/**
	 * Resets input records parameters.
	 * @param {Object} callback Action to synchronize parameters.
	 * @param {Object} scope Scope of the schema element page.
	 */
	resetParameters: function(callback, scope) {
		const isMultiInstanceModeEnabled = this.getIsMultiInstanceModeEnabled();
		if (!isMultiInstanceModeEnabled) {
			callback.call(scope);
			return;
		}
		const inputCollectionParameter = this._getInputCollectionParameter();
		const outputCollectionParameter = this._getOutputCollectionParameter();
		const completedIterationsCountParameter = this._getCompletedIterationsCountParameter();
		const terminatedIterationsCountParameter = this._getTerminatedIterationsCountParameter();
		const totalIterationsCountParameter = this._getTotalIterationsCountParameter();
		this._convertToSingleInstanceElementParameters();
		callback.call(scope);
		this._fillCollectionParameters(inputCollectionParameter, outputCollectionParameter);
		this._fillIterationsCountParameters(completedIterationsCountParameter, terminatedIterationsCountParameter,
			totalIterationsCountParameter);
	},

	/**
	 * Converts to single instance execution mode.
	 */
	convertToSingleInstance: function() {
		if (!this.getIsMultiInstanceModeEnabled()) {
			return;
		}
		this._convertToSingleInstanceElementParameters();
		this.multiInstanceOptions = null;
		const markers = {};
		this.fireEvent("changed", {markers}, this);
	},

	/**
	 * @inheritdoc Terrasoft.ProcessFlowElementSchema#getResultParameters
	 * @override
	 */
	getResultParameters: function() {
		if (!this.getIsMultiInstanceModeEnabled()) {
			return this.mixins.parametrizedProcessSchemaElement.getResultParameters.call(this);
		}
		const outputCollectionParameter = this._getOutputCollectionParameter();
		const countParameters = [
			this._getCompletedIterationsCountParameter(),
			this._getTerminatedIterationsCountParameter(),
			this._getTotalIterationsCountParameter()
		];
		if (outputCollectionParameter.itemProperties.getCount() !== 0) {
			countParameters.push(outputCollectionParameter);
		}
		return countParameters;
	},

	/**
	 * @inheritdoc Terrasoft.ProcessFlowElementSchema#getEditableParameters
	 * @override
	 */
	getEditableParameters: function(config) {
		const parameters = this.mixins.parametrizedProcessSchemaElement.getEditableParameters.call(this);
		if (!this.getIsMultiInstanceModeEnabled()) {
			return parameters;
		}
		const inputCollectionParameterUId = this._getInputCollectionParameter().uId;
		if (!(config && config.isExtendedMode)) {
			return parameters.filter((parameter) => parameter.uId === inputCollectionParameterUId);
		}
		const outputCollectionParameter = this._getOutputCollectionParameter();
		return outputCollectionParameter.itemProperties.getCount() === 0
			? parameters.filter((parameter) => parameter.uId !== outputCollectionParameter.uId)
			: parameters;
	},

	/**
	 * Sets performer assignment options.
	 * @param {Object} config Setting options.
	 * @param {Terrasoft.process.enums.AssignmentType} config.assignmentType Performer assignment type.
	 * @param {Object} config.assigneeValue Performer assignee value.
	 * @param {Object} config.assigneeValue.value Mapping.
	 * @param {String} config.assigneeValue.value.value Mapping value.
	 * @param {String} config.assigneeValue.value.displayValue Display value.
	 * @param {String} config.assigneeValue.value.referenceSchemaUId Identifier of entity schema.
	 */
	setPerformerAssigmentOptions: function(config) {
		if (!this.performerAssignmentOptions) {
			this.performerAssignmentOptions = Ext.create("Terrasoft.ProcessSchemaPerformerAssignmentOptions");
		}
		this.performerAssignmentOptions.assignmentType = config.assignmentType;
		const performerParameter = this._forceGetPerformerParameter();
		const roleParameter = this._forceGetRoleParameter();
		if (config.assignmentType === Terrasoft.process.enums.AssignmentType.ROLE) {
			roleParameter.setMappingValue(config.assigneeValue);
			roleParameter.referenceSchemaName = "SysAdminUnit";
			performerParameter.clearSourceValue();
			return;
		}
		performerParameter.setMappingValue(config.assigneeValue);
		performerParameter.referenceSchemaName = "Contact";
		roleParameter.clearSourceValue();
	},

	/**
	 * Returns performer parameter (parameter with flag isPerformer set to true).
	 * @return {Terrasoft.ProcessSchemaParameter} Performer parameter
	 */
	findPerformerParameter: function() {
		const parameters = this.parameters;
		return parameters.findByFn(function(parameter) {
			return parameter.isPerformer === true;
		}, this);
	},

	/**
	 * Determines whether the parameter identified by the supplied parameterUId is referenced by the 
	 * performerAssignmentOptions or not.
	 * @param {Object} parameterUId Parameter unique identifier.
	 * @returns {boolean} Whether parameter is referenced or not.
	 */
	getIsAssignmentOptionsParameter: function(parameterUId) {
		const options = this.performerAssignmentOptions;
		if (!options) {
			return false;
		}
		return parameterUId === options.performerParameterUId || parameterUId === options.roleParameterUId;
	},

	/**
	 * Clears dynamic parameter and actualizes parameter values mapping.
	 */
	clearDynamicParameter: function(parameterUId) {
		if (!this.getIsAssignmentOptionsParameter(parameterUId)) {
			this.mixins.parametrizedProcessSchemaElement.clearDynamicParameter.apply(this, arguments);
		}
	}

	//endregion

});
