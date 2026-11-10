define("RestWebServiceV2Page", ["RestWebServiceV2PageResources"],
	function(resources) {
		return {
			// entitySchemaName: "VwWebServiceV2",
			mixins: {},
			properties: {},
			attributes: {
			},
			details: /**SCHEMA_DETAILS*/{
			}/**SCHEMA_DETAILS*/,
			modules: {
			},
			methods: {

				/**
				 * @private
				 */
				_getWizardUri: function() {
					var uri = this.initialConfig && this.initialConfig.values && this.initialConfig.values.wizardUri;
					return uri;
				},

				/**
				 * @private
				 */
				_parseUri: function(uri) {
					var uriConverter = new Terrasoft.UriJsonConverter();
					var json = uriConverter.convert(uri);
					var metadataConverter = new Terrasoft.JsonServiceMetaDataConverter({
						codePrefix: Terrasoft.ServiceSchemaManager.schemaNamePrefix
					});
					return metadataConverter.convert(json);
				},

				/**
				 * @private
				 */
				_applyUri: function(uri) {
					var domain = Terrasoft.getUrlDomain(uri);
					if (domain) {
						this.$Schema.setPropertyValue("baseUri", domain);
						this.$Schema.setLocalizableStringPropertyValue("caption", domain);
					}
				},

				/**
				 * @private
				 */
				_createNewMethod: function(schema, methodConfig) {
					const methodName = "Method1";
					const defaultMethodConfig = this.getDefaultMethodConfig(schema);
					const method = new Terrasoft.ServiceMethod(defaultMethodConfig);
					method.name = Terrasoft.ServiceSchemaManager.schemaNamePrefix + methodName;
					method.merge({
						method: methodConfig
					});
					const uri = method.request.uri;
					const domain = Terrasoft.getUrlDomain(uri);
					const methodPart = uri.replace(domain, "");
					method.request.setPropertyValue("uri", methodPart);
					method.setLocalizableStringPropertyValue("caption", methodPart);
					return method;
				},

				/**
				 * @private
				 */
				_applyWizardSettings: function(wizardUri) {
					var methodConfig = this._parseUri(wizardUri);
					var method = this._createNewMethod(this.$Schema, methodConfig);
					this._applyUri(methodConfig.request.uri);
					if (!Ext.isEmpty(method.request.uri) && method.request.uri !== "/") {
						this.$Schema.methods.add(method);
					}
				},

				/**
				 * @override
				 */
				getServiceType: function() {
					return this.callParent(arguments) || Terrasoft.services.enums.ServiceType.REST;
				},

				/**
				 * @override
				 */
				applyWizardData: function () {
					const wizardUri = this._getWizardUri();
					if (!Ext.isEmpty(wizardUri)) {
						this._applyWizardSettings(wizardUri);
					}
				}

			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "merge",
					"name": "Type",
					"values": {
						"enabled": false
					},
				},
			]/**SCHEMA_DIFF*/
		};
	}
);
