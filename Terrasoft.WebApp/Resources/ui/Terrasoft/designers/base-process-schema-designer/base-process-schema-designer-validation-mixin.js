/**
 */
Ext.define("Terrasoft.core.mixins.BaseProcessSchemaDesignerValidationMixin", {
	alternateClassName: "Terrasoft.BaseProcessSchemaDesignerValidationMixin",

	/**
	 * @private
	 */
	validationErrorTypes: {
		default: 0,
		duplicateFlows: 1,
		linkedParameters: 2,
		linkedSchemaParameters: 3
	},

	//region Methods: Private

	/**
	 * Shows validation message.
	 * @param {String} validationMessage Validation message.
	 * @param {Function} callback Callback function, called after user close message box.
	 * @param {Boolean} callback.success Validation result.
	 * @param {Object} scope Callback function execution context.
	 */
	showValidationMessage: function(validationMessage, callback, scope) {
		if (!Ext.isEmpty(validationMessage)) {
			this.showInformationDialog(validationMessage, function() {
				callback.call(scope, false);
			});
			return;
		}
		const schema = this.get("Schema");
		const validationResults = schema.getValidationResults();
		Terrasoft.each(validationResults, function(validationInfo) {
			const element = schema.findItemByUId(validationInfo.uId);
			if (element) {
				this.fireEvent("itemIsValidChanged", element);
			}
		}, this);
		const message = this.getProcessSchemaValidationMessage(validationResults);
		this.showSchemaValidationMessageBox(message, callback, scope);
	},

	/**
	 * Validates SubProcess element schema.
	 * @private
	 * @param {Function} callback The callback function.
	 * @param {Object} scope The context of the callback function.
	 */
	validateSubProcessSchema: function(callback, scope) {
		this.getProcessModuleUtilities(function(utilities) {
			const chainActions = [];
			const schema = this.get("Schema");
			const consts = Terrasoft.process.constants;
			schema.flowElements.each(function(item) {
				const isSubProcess = item.managerItemUId === consts.SUBPROCESS_MANAGER_ITEM_UID;
				const hasSchema = item.schemaUId && !Terrasoft.isEmptyGUID(item.schemaUId);
				if (isSubProcess) {
					if (hasSchema) {
						chainActions.push(function(next) {
							const subProcessConfig = {
								schemaUId: item.schemaUId,
								hostProcessSchemaName: item.getDisplayValue()
							};
							utilities.getInvalidElements(subProcessConfig, function(response) {
								const invalidElements = response.message;
								item.setPropertyValue("isValid", !invalidElements);
								item.validationInfoCaption = invalidElements;
								next();
							}, scope);
						});
					} else {
						item.setPropertyValue("validationInfoCaption", null);
					}
				}
			});
			chainActions.push(function() {
				callback.call(scope);
			});
			chainActions.push(this);
			Terrasoft.chain.apply(this, chainActions);
		}, this);
	},

	/**
	 * @private
	 */
	_setElementInvalidState: function(
		element,
		{
			validationType = Terrasoft.ValidationType.ERROR,
			validationErrorType = this.validationErrorTypes.default,
			message = Terrasoft.Resources.ProcessSchemaDesigner.Messages.ProcessSchemaElementRequirePropertyValidation
		}
	) {
		element.isValid = false;
		element.validationResults = element.validationResults || [];
		element.validationResults.push({validationType, validationErrorType, message});
	},

	/**
	 * @private
	 */
	_clearElementInvalidState: function(element, validationErrorType) {
		const duplicateFlowErrorIndex = element.validationResults
			.findIndex((el) => el.validationErrorType === validationErrorType);
		if (duplicateFlowErrorIndex > -1) {
			element.validationResults.splice(duplicateFlowErrorIndex, 1);
			element.isValid = true;
			this.fireEvent("itemIsValidChanged", element);
		}
	},

	/**
	 * @private
	 */
	_findWrongEntityColumnInReferenceSchema: function(schemaUId, links, callback) {
		const packageUId = this.get("Schema").packageUId;
		Terrasoft.EntitySchemaManager.getPackageSchemaInstanceBySchemaUId(schemaUId, packageUId, (schema) => {
			const invalidLinks = links.filter((link) => {
				const parameterValue = (link.dependentParameter || link.dependentElement).getValue();
				const result = (/EntityColumn:{(.*?)}/i).exec(parameterValue);
				const entityColumnId = result[1];
				const existsColumn = schema.columns.findByFn((column) => column.uId === entityColumnId);
				return !existsColumn;
			});
			callback(invalidLinks);
		}, this);
	},

	/**
	 * @private
	 */
	_validateProcessParametersOnAbsentLinkedColumns: function(callback) {
		const schema = this.get("Schema");
		Terrasoft.eachAsync(schema.flowElements.getItems(), (element, next) => {
			const resultEntityParameter = element.parameters && element.findParameterByName("ResultEntity");
			if (!resultEntityParameter) {
				return next();
			}
			const links = schema.findLinksToSchemaParameter(resultEntityParameter);
			if (!links.length) {
				return next();
			}
			const referenceSchemaUId = resultEntityParameter.referenceSchemaUId;
			this._findWrongEntityColumnInReferenceSchema(referenceSchemaUId, links, (invalidLinks) => {
				for (const link of invalidLinks) {
					if (link) {
						if (link.dependentElement.uId === schema.uId) {
							this._setElementInvalidState(link.dependentElement, {
								validationErrorType: this.validationErrorTypes.linkedSchemaParameters,
								message: link.dependentParameter.getCaption()
							});
						} else {
							this._setElementInvalidState(link.dependentElement, {
								validationErrorType: this.validationErrorTypes.linkedParameters
							});
						}
					}
				}
				next();
			});
		}, function() {
			Ext.callback(callback);
		}, this);
	},

	/**
	 * @private
	 */
	_setFlowElementInvalidState: function(element) {
		const validationErrorType = this.validationErrorTypes.duplicateFlows;
		const isAlreadyHasFlowError = element.validationResults
			.some((result) => result.validationErrorType === validationErrorType);
		if (!isAlreadyHasFlowError) {
			this._setElementInvalidState(element, {validationErrorType});
		}
	},

	/**
	 * Validates process flows.
	 * @private
	 */
	_validateProcessFlows: function() {
		const elements = this.get("Schema").flowElements;
		const connectionsDict = {};
		elements.each((item) => {
			const source = item.sourceRefUId;
			const target = item.targetRefUId;
			const isConnection = source && target;
			if (isConnection) {
				this._clearElementInvalidState(item, "duplicateFlows");
				const key = source + target;
				const itemName = connectionsDict[key];
				if (itemName) {
					const doubledItem = elements.get(itemName);
					this._setFlowElementInvalidState(item);
					this._setFlowElementInvalidState(doubledItem);
				}
				connectionsDict[key] = item.name;
			}
		});
	},

	/**
	 * Validates Process schema.
	 * @private
	 * @param {Function} callback The callback function.
	 * @param {Object} scope The context of the callback function.
	 */
	validateProcessSchema: function(callback, scope) {
		Terrasoft.chain(
			(next) => {
				if (Terrasoft.Features.getIsDisabled("ValidateProcessParametersOnAbsentLinkedColumns")) {
					next();
					return;
				}
				this._validateProcessParametersOnAbsentLinkedColumns(next);
			},
			(next) => {
				this._validateProcessFlows();
				this.validateSubProcessSchema(next, this);
			},
			() => {
				Ext.callback(callback, scope);
			}, this
		);
	},

	/**
	 * Validator column headers process.
	 * @private
	 * @param {String} value Column value.
	 * @param {Object} column Column view model on which the validation.
	 * @return {Object} Validation result.
	 * @return {String} return.invalidMessage Validation message.
	 */
	schemaCaptionValidator: function(value, column) {
		const result = {
			invalidMessage: ""
		};
		if (Ext.isEmpty(value)) {
			result.invalidMessage = Terrasoft.Resources.BaseViewModel.columnRequiredValidationMessage;
		} else {
			const size = column.size;
			const valueSize = value.length;
			if (valueSize > size) {
				let message = Terrasoft.Resources.BaseViewModel.columnIncorrectTextRangeValidationMessage;
				message += " (" + valueSize + "/" + size + ")";
				result.invalidMessage = message;
			}
		}
		return result;
	},

	/**
	 * Returns validation message template by validationErrorType.
	 * @private
	 * @param {Number} errorType Array of items validation info.
	 * @return {String} Validation message template.
	 */
	_getProcessSchemaValidationMessageTemplate: function(errorType) {
		const messages = Terrasoft.Resources.ProcessSchemaDesigner.Messages;
		const errorTypes = this.validationErrorTypes;
		switch (errorType) {
			case errorTypes.duplicateFlows:
				return messages.SchemaInvalidElementsDuplicateFlowsMessageTemplate;
			case errorTypes.linkedParameters:
				return messages.SchemaInvalidColumnsElementsParameterMessageTemplate;
			case errorTypes.linkedSchemaParameters:
				return messages.SchemaInvalidColumnsProcessParametersMessageTemplate;
			default:
				return messages.SchemaInvalidElementsMessageTemplate;
		}
	},

	/**
	 * Returns true if validationResults has validationErrorType.
	 * @private
	 * @param {Object[]} validationResults Array of items validation info.
	 * @param {Number} validationErrorType Array of items validation info.
	 * @return {Boolean} Validation message block.
	 */
	hasProcessSchemaValidationInfoErrorType: function(validationResults, validationErrorType) {
		return validationResults.some((validationResult) => {
			const resultErrorType = validationResult.validationErrorType || this.validationErrorTypes.default;
			return resultErrorType === validationErrorType;
		});
	},

	/**
	 * Returns validation message block by validationErrorType.
	 * @private
	 * @param {Object[]} schemaValidationResults Array of items validation info.
	 * @param {Number} validationErrorType validation error type.
	 * @return {String} Validation message block.
	 */
	_getProcessSchemaValidationMessageBlock: function(schemaValidationResults, validationErrorType) {
		const messages = [];
		for (const validationResult of schemaValidationResults) {
			const validationResults = validationResult.validationResults;
			if (this.hasProcessSchemaValidationInfoErrorType(validationResults, validationErrorType)) {
				if (validationResult.uId === this.$SchemaUId) {
					for (const messageInfo of validationResult.validationResults) {
						messages.push(" - " + messageInfo.message);
					}
				} else {
					messages.push(" - " + validationResult.displayValue);
				}
			}
		}
		let messageBlock = "";
		if (messages.length) {
			const invalidElementsMessageTemplate = this._getProcessSchemaValidationMessageTemplate(validationErrorType);
			messageBlock = Terrasoft.getFormattedString(invalidElementsMessageTemplate, messages.join("\n"));
		}
		return messageBlock;
	},

	/**
	 * Returns validation message by validation info object.
	 * @private
	 * @param {Object[]} validationResults Array of items validation info
	 * (see {@link Terrasoft.ProcessSchema#forceGetItemValidationInfo}).
	 * @return {String} Validation message.
	 */
	getProcessSchemaValidationMessage: function(validationResults) {
		const message = Object.values(this.validationErrorTypes)
			.map((errorType) => this._getProcessSchemaValidationMessageBlock(validationResults, errorType))
			.filter((x) => x !== "")
			.join("\n\n");
		return message;
	},

	//endregion

	//region Methods: Protected

	/**
	 * Sets viewModel validation config.
	 * @protected
	 */
	setValidationConfig: function() {
		this.addColumnValidator("SchemaCaption", this.schemaCaptionValidator);
		this.addColumnValidator("Schema", this.validateSchema);
	},

	/**
	 * Add validator for specified column.
	 * @protected
	 * @param {String} columnName Column name for validation.
	 * @param {Function} validatorFn validation function.
	 */
	addColumnValidator: function(columnName, validatorFn) {
		this.validationConfig[columnName] = this.validationConfig[columnName] || [];
		this.validationConfig[columnName].push(validatorFn);
	},

	/**
	 * Validate process schema.
	 * @protected
	 * @return {Object} Process schema validation info.
	 * @return {String} return.invalidMessage Validation message.
	 */
	validateSchema: function() {
		const schema = this.get("Schema");
		const isValid = schema.validate();
		const validationInfo = {
			invalidMessage: ""
		};
		if (isValid !== true) {
			validationInfo.isCustomMessage = true;
			validationInfo.invalidMessage =
				Terrasoft.Resources.ProcessSchemaDesigner.Messages.InvalidProcessSchemaMessage;
		}
		return validationInfo;
	},

	/**
	 * Shows schema validation message box.
	 * @protected
	 * @param {String} validationMessage Validation message.
	 * @param {Function} callback Callback function, called after user close message box.
	 * @param {Function} callback.doSave Whether to save the schema.
	 * @param {Object} scope Callback function execution context.
	 */
	showSchemaValidationMessageBox: function(validationMessage, callback, scope) {
		const schema = this.get("Schema");
		const resources = Terrasoft.Resources.ProcessSchemaDesigner.Messages;
		const typeCaption = schema.typeCaption.toLowerCase();
		const caption = Ext.String.format(resources.SchemaValidationMessageCaption, typeCaption);
		const saveButtonCaption = Ext.String.format(resources.SaveInvalidProcessButtonCaption, schema.typeCaption);
		const saveProcessButton = Terrasoft.getBlueButtonConfig("SaveProcess", saveButtonCaption);
		Terrasoft.ProcessSchemaDesignerUtilities.showProcessMessageBox({
			caption: caption,
			message: validationMessage,
			buttons: [saveProcessButton, Terrasoft.MessageBoxButtons.CANCEL],
			defaultButton: 0,
			handler: function(returnCode) {
				const doSave = returnCode === "SaveProcess";
				callback.call(scope, doSave);
			},
			scope: this
		});
	}

	//endregion

});
