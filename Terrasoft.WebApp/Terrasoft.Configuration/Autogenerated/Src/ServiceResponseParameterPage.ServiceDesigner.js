define("ServiceResponseParameterPage", ["ServiceEnums"], function() {
	return {
		modules: {
			ServiceResponseParameterDefValue: {
				moduleId: "ServiceResponseParameterDefValue",
				moduleName: "ConfigurationModuleV2",
				config: {
					isSchemaConfigInitialized: false,
					schemaName: "ServiceResponseParameterValuePage",
					parameters: {
						viewModelConfig: {
							serviceUId: {
								attributeValue: "ServiceSchemaUId"
							},
							methodUId: {
								attributeValue: "MethodUId"
							},
							findParameterMethodName: {
								getValueMethod: "getFindParameterMethodName"
							},
							CanEditSchema: {
								attributeValue: "CanEditSchema"
							}
						}
					},
					useHistoryState: false
				}
			}
		},
		methods: {

			//region Methods: Private

			/**
			 * Validates if DataType is valid for ParameterType.
			 * @param {String} dataValueTypeName.
			 * @return {Boolean} Is parameter allowed.
			 * @private
			 */
			_isDataValueTypeNameAllowed: function(dataValueTypeName) {
				return dataValueTypeName !== Terrasoft.services.enums.DataValueTypeName.Object ||
						this.$ParameterType === Terrasoft.services.enums.ServiceParameterType.BODY;
			},

			//endregion

			//region Methods: Protected

			/**
			 * @inheritdoc Terrasoft.ServiceParameterPage#getMethodParameters
			 * @override
			 */
			getMethodParameters: function(method) {
				return method.response.parameters;
			},

			/**
			 * @inheritdoc Terrasoft.ServiceParameterPage#setDataTypeVisible
			 * @override
			 */
			setDataTypeVisible: function() {
				this.$IsDataTypeVisible = true;
			},

			/**
			 * @inheritdoc Terrasoft.ServiceParameterPage#parameterTypeValidator
			 * @override
			 */
			parameterTypeValidator: function() {
				var message = "";
				return {invalidMessage: message};
			},

			/**
			 * @inheritdoc Terrasoft.ServiceParameterPage#getParameterEditPageTag
			 * @override
			 */
			getParameterEditPageTag: function() {
				return "ResponseParameterEditPage";
			},

			/**
			 * @inheritdoc Terrasoft.ServiceParameterPage#getParameterGridTag
			 * @override
			 */
			getParameterGridTag: function() {
				return "ServiceResponseParameterGrid";
			},

			/**
			 * @inheritdoc Terrasoft.ServiceParameterPage#getFindParameterMethodName
			 * @override
			 */
			getFindParameterMethodName: function() {
				return "findResponseParameterByUId";
			},

			/**
			 * @inheritdoc Terrasoft.ServiceParameterPage#getFindParameterMethodName
			 * @override
			 */
			getParameterValuePageTag: function() {
				return "ServiceResponseParameterDefValue";
			},

			/**
			 * @inheritdoc Terrasoft.ServiceParameterPage#setDataTypeEnabled
			 * @override
			 */
			setDataTypeEnabled: function() {
				var hasNestedParameters = this._hasNestedParameters();
				this.$IsDataTypeEnabled = !hasNestedParameters && this.$CanEditSchema;
			},

			/**
			 * @inheritdoc Terrasoft.ServiceParameterPage#setDefaultDataType
			 * @override
			 */
			setDefaultDataType: function(model) {
				if (this.getPrevious("ParameterType") === Terrasoft.services.enums.ServiceParameterType.BODY &&
					this.$DataValueTypeName === Terrasoft.services.enums.DataValueTypeName.Object) {
					this._onDataTypeChange(model, Terrasoft.services.enums.DataValueTypeName.Text);
				}
			},

			/**
			 * @inheritdoc Terrasoft.ServiceParameterPage#getAvailableServiceParameterTypes
			 * @override
			 */
			getAvailableServiceParameterTypes: function() {
				return [
					Terrasoft.services.enums.ServiceParameterType.BODY,
					Terrasoft.services.enums.ServiceParameterType.HTTP_HEADER,
					Terrasoft.services.enums.ServiceParameterType.COOKIE
				];
			},

			/**
			 * @inheritdoc Terrasoft.ServiceParameterPage#isParameterTypeAvailable
			 * @override
			 */
			isParameterTypeAvailable: function(serviceParameterType) {
				return this.getIsFeatureEnabled("UseCustomRequestBodyBuilder") ||
					this.$Schema.type !== Terrasoft.services.enums.ServiceType.REST ||
					this.$Method.request.contentType !== Terrasoft.services.enums.ServiceContentType.XML ||
					serviceParameterType !== Terrasoft.services.enums.ServiceParameterType.BODY;
			},

			//endregion

			//region Methods: Public

			/**
			 * @inheritdoc Terrasoft.ServiceParameterPage#prepareDataValueTypeNameList
			 * @override
			 */
			prepareDataValueTypeNameList: function(filter, list) {
				var result = {};
				Terrasoft.each(Terrasoft.services.enums.DataValueTypeCaption, function(displayValue, value) {
					if (this._isDataValueTypeNameAllowed(value)) {
						result[value] = {value: value, displayValue: displayValue};
					}
				}, this);
				list.reloadAll(result);
			}

			//endregion

		},
		diff: [
			{
				"operation": "remove",
				"name": "ServiceRequestParameterDefValue"
			},
			{
				"operation": "insert",
				"index": 7,
				"parentName": "ParameterEditContainer",
				"name": "ServiceResponseParameterDefValue",
				"propertyName": "items",
				"values": {
					"classes": {"wrapClassName": ["control-width-15", "control-left", "grid-layout-row",
						"module-container"]},
					"itemType": Terrasoft.ViewItemType.MODULE,
					"visible": "$isDefaultValueVisible"
				}
			},
			{
				"operation": "remove",
				"name": "IsRequired"
			},
			{
				"operation": "remove",
				"parentName": "ParameterEditContainer",
				"propertyName": "items",
				"name": "SequenceElementName"
			}
		]
	};
});
