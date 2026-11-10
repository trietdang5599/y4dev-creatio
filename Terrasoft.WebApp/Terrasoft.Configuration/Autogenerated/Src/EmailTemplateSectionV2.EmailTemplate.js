/**
 * Parent: BaseLookupSection
 */
define("EmailTemplateSectionV2", [], function() {
	return {
		entitySchemaName: "EmailTemplate",

		methods: {

			//region Methods: Private

			_isLookupSection() {
				return this.sandbox.moduleName === "LookupSectionModule"
			},

			//endregion

			//region Methods: Protected

			/**
			 * @inheritdoc Terrasoft.BaseDataView#loadFiltersContainersVisibility
			 * @overridden
			 */
			loadFiltersContainersVisibility: function() {
				if (!this._isLookupSection()) {
					this.set("IsFoldersVisible", false);
				}
			},

			/**
			 * @inheritdoc Terrasoft.BaseDataView#showFolderTree
			 * @overridden
			 */
			showFolderTree: function() {
				if (!this._isLookupSection()) {
					this.callParent(arguments);
				}
			}

			//endregion

		},
	};
});
