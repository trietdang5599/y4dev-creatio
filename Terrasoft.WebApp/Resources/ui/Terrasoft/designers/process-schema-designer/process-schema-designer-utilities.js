/**
 */
Ext.define("Terrasoft.manager.ProcessSchemaDesignerUtilities", {
	extend: "Terrasoft.BaseObject",
	alternateClassName: "Terrasoft.ProcessSchemaDesignerUtilities",
	singleton: true,

	/**
	 * @private
	 */
	_getCanSafelyChangeDataValueType: function(parameter, dataValueType) {
		return !parameter.hasNestedParameters() ||
			this.getValueTypeSupportsNestedParameters(dataValueType) ||
			!this.getValueTypeSupportsNestedParameters(parameter.dataValueType);
	},

	/**
	 * @private
	 */
	_validateCanRemoveNestedParameters: function(parameter, schema) {
		let result = true;
		const validationInfoItems = [];
		parameter.itemProperties.each(function(innerParameter) {
			const {canRemove, validationInfo} = schema.canRemoveParameter(innerParameter);
			if (!canRemove) {
				result = false;
				validationInfoItems.push(validationInfo);
			}
		});
		return {canRemove: result, validationInfo: validationInfoItems.join("\n")};
	},

	/**
	 * Returns image Url.
	 * @param {String} imageName Image name.
	 * @return {String}
	 */
	getCoreImageUrl: function(imageName) {
		return Terrasoft.ImageUrlBuilder.getUrl({
			source: Terrasoft.ImageSources.RESOURCE_MANAGER,
			params: {
				resourceManagerName: "Terrasoft.Nui",
				resourceItemName: "ProcessSchemaDesigner." + imageName
			}
		});
	},

	/**
	 * Returns dataValueType image Url.
	 * @param {Terrasoft.DataValueType} dataValueType DataValueType.
	 * @return {String}
	 */
	getDataValueTypeImageUrl: function(dataValueType) {
		const imageName = Terrasoft.getImageNameByDataValueType(dataValueType);
		return this.getCoreImageUrl(imageName);
	},

	/**
	 * Returns Parameter direction image Url.
	 * @param {Terrasoft.ProcessSchemaParameterDirection} direction Parameter direction.
	 * @return {String}
	 */
	getDirectionImageUrl: function(direction) {
		let imageName;
		switch (direction) {
			case Terrasoft.ProcessSchemaParameterDirection.IN:
				imageName = "ParameterDirection.In.svg";
				break;
			case Terrasoft.ProcessSchemaParameterDirection.OUT:
				imageName = "ParameterDirection.Out.svg";
				break;
			case Terrasoft.ProcessSchemaParameterDirection.VARIABLE:
				imageName = "ParameterDirection.Variable.svg";
				break;
			case Terrasoft.ProcessSchemaParameterDirection.INTERNAL:
				imageName = "ParameterDirection.Internal.svg";
				break;

			default:
				this.warning(`Unknown direction value ${direction}`);
				return null;
		}
		return this.getCoreImageUrl(imageName);
	},

	/**
	 * Returns element caption.
	 * @param {Terrasoft.ProcessBaseElementSchema} element Process schema element.
	 * @return {String}
	 */
	getElementCaption: function(element) {
		if (!element) {
			return null;
		}
		var elementCaption = element.caption;
		if (elementCaption instanceof Terrasoft.LocalizableString) {
			elementCaption = elementCaption.getValue();
		}
		elementCaption = elementCaption || element.name;
		return elementCaption;
	},

	/**
	 * Adds parameter mask.
	 * @param {String} value Value.
	 * @return {String} Value in business process engine format.
	 */
	addParameterMask: function(value) {
		var constants = Terrasoft.process.constants;
		return constants.LEFT_MACROS_BRACKET + value + constants.RIGHT_MACROS_BRACKET;
	},

	/**
	 * Removes parameter mask.
	 * @param {String} value Macros value.
	 * @returns {String} Macros without mask.
	 */
	removeParameterMask: function(value) {
		return value.slice(2, -2);
	},

	/**
	 * Returns UId of the package.
	 * @param {Terrasoft.ProcessBaseElementSchema} element Process element.
	 * @return {String}
	 */
	getPackageUId: function(element) {
		var parentSchema = element.parentSchema;
		return parentSchema.packageUId;
	},

	/**
	 * Returns modal box settings.
	 * @return {Object} Modal box settings.
	 */
	getModalBoxConfig: function() {
		return {
			heightPixels: 800,
			widthPixels: 1280,
			boxClasses: ["formula-modal-box"]
		};
	},

	/**
	 * Returns modal box settings.
	 * @return {Object} Modal box settings.
	 */
	getDateTimeModalBoxConfig: function() {
		return {
			heightPixels: 230,
			widthPixels: 460,
			boxClasses: ["date-time-modal-box"]
		};
	},

	/**
	 * Returns config object of controls to display message box.
	 * @param {String} message Message.
	 * @private
	 * @return {Object} config.
	 */
	getProcessMessageBoxControlConfig: function(message) {
		return  {
			memo: {
				dataValueType: Terrasoft.DataValueType.TEXT,
				value: message,
				customConfig: {
					className: "Terrasoft.MemoEdit",
					height: "235px",
					readonly: true,
					markerValue: "validationMessage"
				}
			}
		};
	},

	/**
	 * Shows dialog window.
	 * @param {Object} cfg Configuration object
	 * @param {String} cfg.caption Window caption.
	 * @param {String} cfg.message Window message.
	 * @param {String} cfg.customWrapClass Custom wrap class.
	 * @param {Object} cfg.controlConfig Custom control elements configuration.
	 * Example:
	 {
		 link: {
			 dataValueType: Terrasoft.DataValueType.TEXT,
			 caption: 'Text',
			 value: 'Text'
		 },
		 checkbox: {
			 dataValueType: Terrasoft.DataValueType.BOOLEAN,
			 caption: 'Boolean',
			 value: true
		 },
		 date: {
			 dataValueType: Terrasoft.DataValueType.DATE,
			 caption: 'Date',
			 value: new Date(Date.now())
		 }
	 * @param  {Array} cfg.buttons Control buttons array, {@link Terrasoft.MessageBox#buttons}.
	 * Example:
	 * buttons: ['yes', 'no', {
	 *	className: 'Terrasoft.Button',
	 *	returnCode: 'customButton',
	 *	style: 'green',
	 *	caption: 'myButton'
	 * }]
	 * @param {Number} cfg.defaultButton Buttons array index for default button. Numeration starts from zero.
	 * @param {Function} cfg.handler ESC button press handler.
	 * @param {Object} cfg.scope Handler execution context.
	 * @param {Terrasoft.controls.MessageBoxEnums.Styles} cfg.style Control element style.
	 */
	showProcessMessageBox: function(cfg) {
		if (cfg.message) {
			cfg.customWrapClass = cfg.customWrapClass || "ts-process-message-box";
			cfg.controlConfig = cfg.controlConfig || this.getProcessMessageBoxControlConfig(cfg.message);
		}
		Terrasoft.utils.showMessage(cfg);
	},

	/**
	 * Returns parameter value source.
	 * @param {Object} parameterValue parameter source value.
	 * @return {Terrasoft.process.enums.ProcessSchemaParameterValueSource}
	 */
	getParameterValueSource: function(parameterValue) {
		var value = parameterValue || {};
		return value.source || Terrasoft.ProcessSchemaParameterValueSource.None;
	},

	/**
	 * Checks whether parameter value is mapping.
	 * @param {Object} parameterValue parameter source value.
	 * @return {Boolean}
	 */
	getIsMappingParameterValue: function(parameterValue) {
		var valueSource = this.getParameterValueSource(parameterValue);
		var noneMappingValues = [
			Terrasoft.ProcessSchemaParameterValueSource.ConstValue,
			Terrasoft.ProcessSchemaParameterValueSource.None
		];
		return !Terrasoft.contains(noneMappingValues, valueSource);
	},

	/**
	 * Checks if elements can be removed, if not invalid remove dialog will be shown.
	 * @param {Terrasoft.BaseProcessSchema} schema Process schema tha invokes deletion.
	 * @param {Array} elements Process elements to check.
	 * @param {Function} callback Callback after check or dialog ends.
	 * @param {Object} scope Callback scope.
	 */
	validateElementRemoval: function(schema, elements, callback, scope) {
		this.processRemovalConfig(schema.canRemoveElements(elements), callback, scope);
	},

	/**
	 * Checks if elements can be replaced, if not invalid replace dialog will be shown.
	 * @param {Terrasoft.BaseProcessSchema} schema Process schema tha invokes deletion.
	 * @param {Array} elements Process elements to check.
	 * @param {Function} callback Callback after check or dialog ends.
	 * @param {Object} scope Callback scope.
	 */
	validateElementReplace: function(schema, elements, callback, scope) {
		this.processRemovalConfig({
			...schema.canRemoveElements(elements),
			caption: Terrasoft.Resources.ProcessSchemaDesigner.Messages.InvalidReplaceElement
		}, callback, scope);
	},

	/**
	 * Checks if parameter can be removed, if not invalid remove dialog will be shown.
	 * @param {Terrasoft.BaseProcessSchema} schema Process schema tha invokes deletion.
	 * @param {Object} parameter Process element parameter to check.
	 * @param {Function} callback Callback after check or dialog ends.
	 * @param {Object} scope Callback scope.
	 */
	validateParameterRemoval: function(schema, parameter, callback, scope) {
		this.processRemovalConfig(schema.canRemoveParameter(parameter), callback, scope);
	},

	/**
	 * Processes removal config.
	 * @private
	 * @param {Object} config Removal config.
	 * @param {Function} callback Callback of the check.
	 * @param {Object} scope Callback scope.
	 */
	processRemovalConfig: function({canRemove, caption, validationInfo}, callback, scope) {
		if (canRemove) {
			callback.call(scope, true);
		} else {
			caption = caption || Terrasoft.Resources.ProcessSchemaDesigner.Messages.InvalidRemoveElement;
			this.showValidateDialog({caption, validationInfo, callback: () => callback.call(scope, false), scope});
		}
	},

	/**
	 * Checks if parameter dataValueType can be safely changed, if not error dialog will be shown.
	 * @param {Object} config Options.
	 * @param {Terrasoft.BaseProcessSchema} config.schema Process schema that invokes deletion.
	 * @param {Object} config.parameterUId Process element parameter to check.
	 * @param {Object} config.newDataValueType
	 * @param {Function} config.callback Callback after check or dialog ends.
	 * @param {Object} config.scope Callback scope.
	 * @returns {boolean} Flag indicates whether that parameter dataValueType can be safely changed.
	 */
	validateCanChangeParameterDataValueType: function(config) {
		const parameter = config.schema.parameters.find(config.parameterUId);
		if (!parameter || this._getCanSafelyChangeDataValueType(parameter, config.newDataValueType)) {
			return true;
		}
		const validationResult = this._validateCanRemoveNestedParameters(parameter, config.schema);
		this.processRemovalConfig(validationResult, config.callback || Terrasoft.emptyFn, config.scope);
		return validationResult.canRemove;
	},

	/**
	 * Checks if lazy properties are loaded, if not lazy load it will load them.
	 * @param {Terrasoft.BaseProcessSchema} schema Process schema tha invokes check.
	 * @param {Function} callback Callback after check or dialog ends.
	 * @param {Object} scope Callback scope.
	 */
	validateAllLazyPropertiesAreLoaded: function(schema, callback, scope) {
		if (schema.getAllLazyPropertiesAreLoaded()) {
			callback.call(scope, true);
		} else {
			const bodyMaskId = Terrasoft.Mask.show({timeout: 0});
			schema.loadAllLazyProperties(() => {
				Terrasoft.Mask.hide(bodyMaskId);
				callback.call(scope, true);
			}, schema);
		}
	},

	/**
	 * Shows schema lazy load dialog.
	 * @private
	 * @param {Terrasoft.BaseProcessSchema} schema Process schema tha invokes deletion.
	 * @param {Function} callback Handler for dialog events. Called after default dialog handler.
	 * @param {Object} scope Scope for dialog handler.
	 */
	showLoadLazyParametersDialog: function(schema, callback, scope) {
		var message = Terrasoft.Resources.ProcessSchemaDesigner.Messages.LazyLoadMessage;
		Terrasoft.utils.showConfirmation(message, function(returnCode) {
			if (returnCode === "yes") {
				var bodyMaskId = Terrasoft.Mask.show({timeout: 0});
				schema.loadAllLazyProperties(function() {
					Terrasoft.Mask.hide(bodyMaskId);
					Ext.callback(callback, scope, [true]);
				}, schema);
			} else {
				Ext.callback(callback, scope, [false]);
			}
		}, ["yes", "no"], this, {defaultButton: 0});
	},

	/**
	 * Shows validate dialog.
	 * @private
	 * @param {String} caption Window caption.
	 * @param {String} validationInfo Error text message.
	 * @param {Function} callback Handler for dialog events.
	 * @param {Object} scope Scope for dialog handler.
	 */
	showValidateDialog: function({caption, validationInfo, callback, scope}) {
		this.showProcessMessageBox({
			caption,
			message: validationInfo,
			handler: callback,
			scope: scope
		});
	},

	/**
	 * Returns flag that indicates if parameter value has mapping.
	 * @param {Object} value Parameter value
	 * @returns {Boolean}
	 */
	hasMapping: function(value) {
		if (value && value.source) {
			var SourceEnum = Terrasoft.ProcessSchemaParameterValueSource;
			return value.source !== SourceEnum.None && value.source !== SourceEnum.ConstValue;
		}
		return false;
	},

	/**
	 * Mapping field validator.
	 * @param {Object} value Mappign value.
	 * @returns {{invalidMessage: string}}
	 */
	mappingValidator: function(value) {
		var result = {invalidMessage: ""};
		if (value && value.isValid === false && Terrasoft.ProcessSchemaDesignerUtilities.hasMapping(value)) {
			var messages = Terrasoft.Resources.ProcessSchemaDesigner.Messages;
			result.invalidMessage = messages.InvalidMappingColumn || "Invalid formula";
		}
		return result;
	},

	getSchemaIdByUId: function(schemaUId, callback, scope) {
		const select = Ext.create("Terrasoft.EntitySchemaQuery", {
			rootSchemaName: "SysSchema"
		});
		select.addColumn("Id");
		select.filters.add("UId", select.createColumnFilterWithParameter(Terrasoft.ComparisonType.EQUAL,
			"UId", schemaUId));
		select.getEntityCollection(function(response) {
			let schemaId;
			if (response.success && !response.collection.isEmpty()) {
				schemaId = response.collection.first().$Id;
			}
			Ext.callback(callback, scope, [schemaId]);
		}, this);
	},

	/**
	 * Determines whether a parameter  with specified dataValueType supports nested parameters.
	 * @param {Terrasoft.DataValueType} dataValueType DataValueType to check.
	 */
	getValueTypeSupportsNestedParameters: function(dataValueType) {
		return dataValueType === Terrasoft.DataValueType.COMPOSITE_OBJECT_LIST ||
			dataValueType === Terrasoft.DataValueType.COMPOSITE_OBJECT;
	}

});
