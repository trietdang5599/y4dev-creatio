define("BaseProcessFlowElementSchemaItemInitializer", [],
	function () {
		/**
		 * @class Terrasoft.configuration.BaseProcessFlowElementSchemaItemInitializer
		 */
		Terrasoft.BaseProcessFlowElementSchemaItemInitializer = class BaseProcessFlowElementSchemaItemInitializer {

			//region Constructors

			/**
			 * @inheritdoc Terrasoft.BaseObject#constructor.
			 * @override
			 */
			constructor(element, sandbox) {
				this.element = element;
				this.sandbox = sandbox;
			}

			//endregion

			//region Methods: Private

			/**
			 * Initializes element entity parameter.
			 * @private
			 */
			_initElementParameter(name, value) {
				const entityParam = this.element.findParameterByName(name);
				if (!entityParam) {
					return;
				}
				if (!value) {
					return;
				}
				entityParam.isResult = true;
				entityParam.setMappingValue(value);
			}

			//endregion

			//region Methods: Protected

			/**
			 * Get element entity parameter name.
			 * @protected
			 * @virtual
			 */
			getElementEntityParameterName() {
				return '';
			}

			/**
			 * Get element entity parameter value.
			 * @protected
			 * @virtual
			 */
			getElementEntityParameterValue(defaultParamValues) {
				const referenceSchemaUId = defaultParamValues["referenceSchemaUId"];
				return {
					source: Terrasoft.ProcessSchemaParameterValueSource.ConstValue,
					value: referenceSchemaUId
				};
			}

			/**
			 * Initializes element after it's created.
			 * @protected
			 * @virtual
			 */
			initElement(callback, scope) {
				if (this.element.defaultParamValues) {
					this.initDefaultParamValues(this.element.defaultParamValues, callback, scope);
					return;
				}
				callback.call(scope);
			}

			/**
			 * Initializes element's parameters.
			 * @protected
			 * @virtual
			 */
			initDefaultParamValues(defaultParamValues, callback, scope) {
				const entityParameterSourceValue = this.getElementEntityParameterValue(defaultParamValues);
				const entityParameterName = this.getElementEntityParameterName();
				this._initElementParameter(entityParameterName, entityParameterSourceValue);
				callback.call(scope);
			}

			//endregion
		}
	});