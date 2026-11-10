 /**
 * Parent: EmailTemplatePageMultilingual
 */
define("PushTemplatePage", [], function() {
	return {
		methods: {

			// region Methods: Protected

			/**
			 * @inheritdoc Terrasoft.BaseMultilingualEntityLookupPage#getModuleSchemaName
			 * @override
			 */
			getModuleSchemaName: function() {
				return "PushTemplateContentEditSchema";
			}

			// endregion

		},
		diff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/
	};
});
