define("RawResponseBuilder", ["JsonServiceMetaDataConverter", "RawResponseJsonConverter"], function() {
	return {
		attributes: {
			SetupRequestParameters: {value: false},
			SetupResponseParameters: {value: true}
		},
		methods: {

			// region Methods: Protected

			/**
			 * @inheritdoc Terrasoft.ServiceMethodBuilder#getMergeOptions
			 * @override
			 */
			getMergeOptions: function() {
				return {
					skipUri: true,
					skipHttpMethodType: true
				};
			},

			/**
			 * @inheritdoc Terrasoft.ServiceMethodBuilder#parseMethod
			 * @override
			 */
			parseMethod: function() {
				var result;
				if (this.$InputData) {
					var rawToJsonConverter = this.Ext.create("Terrasoft.RawResponseJsonConverter");
					var json = rawToJsonConverter.convert(this.$InputData);
					if (json) {
						var jsonToParametersConverter = this.Ext.create("Terrasoft.JsonServiceMetaDataConverter", {
							codePrefix: Terrasoft.ServiceSchemaManager.schemaNamePrefix
						});
						result = jsonToParametersConverter.convert(json);
					}
				}
				return result;
			},

			/**
			 * @inheritdoc Terrasoft.ServiceMethodBuilder#getServiceBuilderTags
			 * @override
			 */
			getServiceBuilderTags: function() {
				return ["ServiceResponseMethodBuilder"];
			}

			// endregion

		}
	};
});
