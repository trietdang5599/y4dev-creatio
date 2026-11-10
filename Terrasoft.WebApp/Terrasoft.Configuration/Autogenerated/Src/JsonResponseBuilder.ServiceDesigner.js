define("JsonResponseBuilder", [], function() {
	return {
		attributes: {
			SetupRequestParameters: { value: false },
			SetupResponseParameters: { value: true }
		},
		methods: {

			//region Methods: Protected

			/**
			 * @inheritdoc Terrasoft.JsonRequestBuilder#prepareMethodJsonStructure
			 * @override
			 */
			prepareMethodJsonStructure: function(body) {
				return { response: { body: body } };
			},

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
			 * @inheritdoc Terrasoft.ServiceMethodBuilder#getServiceBuilderTags
			 * @override
			 */
			getServiceBuilderTags: function() {
				return ["ServiceResponseMethodBuilder"];
			}

			//endregion

		}
	};
});
