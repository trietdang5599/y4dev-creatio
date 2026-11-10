define("ServiceResponseParameterGrid", [], function() {
	return {
		modules: {
			ResponseServiceParameterPage: {
				moduleId: "ResponseServiceParameterPage",
				moduleName: "ConfigurationModuleV2",
				config: {
					isSchemaConfigInitialized: false,
					schemaName: {
						getValueMethod: "getServiceParameterEditPage"
					},
					parameters: {
						viewModelConfig: {
							ServiceSchemaUId: {
								attributeValue: "ServiceSchemaUId"
							},
							MethodUId: {
								attributeValue: "MethodUId"
							},
							ParameterUId: {
								attributeValue: "ParameterUId"
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
		properties: {
			restServiceParameterEditPage: "ServiceResponseParameterPage",
			soapServiceParameterEditPage: "SoapServiceResponseParameterPage",
		},
		methods: {

			//region Methods: Private

			/**
			 * @private
			 */
			_isXmlContentType: function() {
				var method = this._serviceSchema.methods.find(this.$MethodUId);
				var contentType = method.request.contentType;
				return contentType === Terrasoft.services.enums.ServiceContentType.XML;
			},

			//endregion

			//region Methods: Protected

			/**
			 * @inheritdoc Terrasoft.BaseServiceParameterGrid#getMethodParameters
			 * @override
			 */
			getMethodParameters: function(method) {
				return method.response.parameters;
			},

			/**
			 * @inheritdoc Terrasoft.ServiceParameterGrid#createParameter
			 * @override
			 */
			createParameter: function() {
				return this.callParent([{
					type: this._serviceSchema.isRest() && this._isXmlContentType()
						? Terrasoft.services.enums.ServiceParameterType.HTTP_HEADER
						: Terrasoft.services.enums.ServiceParameterType.BODY
				}]);
			},

			/**
			 * @inheritdoc Terrasoft.ServiceParameterGrid#getParameterEditPageTag
			 * @override
			 */
			getParameterEditPageTag: function() {
				return "ResponseParameterEditPage";
			},

			/**
			 * @inheritdoc Terrasoft.ServiceParameterGrid#getParameterGridTag
			 * @override
			 */
			getParameterGridTag: function() {
				return "ServiceResponseParameterGrid";
			},

			/**
			 * @inheritdoc Terrasoft.BaseServiceParameterGrid#getServiceBuilderTags
			 * @override
			 */
			getServiceBuilderTags: function() {
				return ["ServiceResponseMethodBuilder"];
			}

			//endregion

		},
		diff: [
			{
				operation: "remove",
				name: "ServiceParameterPage"
			},
			{
				operation: "insert",
				parentName: "MainContainer",
				name: "ResponseServiceParameterPage",
				propertyName: "items",
				values: {
					itemType: Terrasoft.ViewItemType.MODULE,
					visible: {
						bindTo: "ActiveRow",
						bindConfig: {converter: "activeRowIsNotEmpty"}
					},
					classes: {wrapClassName: ["service-parameter-grid-page"]}
				}
			}
		]
	};
});
