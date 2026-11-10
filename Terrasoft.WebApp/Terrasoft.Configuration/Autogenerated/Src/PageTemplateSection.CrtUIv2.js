/**
 * Parent: BaseLookupSection
 */
define("PageTemplateSection", ["PageTemplate"], function(PageTemplate) {
	return {
		entitySchemaName: "VwPageTemplate",
		methods: {

			// region Methods: Protected

			/**
			 * @inheritdoc Terrasoft.GridUtilities#getEntitySchemaNameForDelete
			 * @override
			 */
			getEntitySchemaNameForDelete: function() {
				return "PageTemplate";
			},

			/**
			 * @inheritdoc Terrasoft.BaseLookupSection#getModuleCaption
			 * @override
			 */
			getModuleCaption: function() {
				return PageTemplate.caption;
			}

			// endregion

		},
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "remove",
				"name": "DataGridActiveRowCopyAction"
			}
		]/**SCHEMA_DIFF*/
	};
});
