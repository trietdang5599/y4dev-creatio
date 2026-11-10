define("SystemDesigner", [], function() {
	return {
		methods: {

			//region Methods: Private

			/**
			 * Opens translation section.
			 * @private
			 */
			navigateToTranslationSection: function() {
				this.openSection("TranslationSection");
			},

			/**
			 * Opens language section.
			 * @private
			 */
			navigateToLanguageSection: function() {
				this.openSection("LanguageSection");
			},

			//endregion

			//region Methods: Protected

			/**
			 * @inheritdoc SystemDesigner#getOperationRightsDecoupling
			 * @overridden
			 */
			getOperationRightsDecoupling: function() {
				var operationRights = this.callParent(arguments);
				operationRights.navigateToTranslationSection = "CanManageTranslationSection";
				operationRights.navigateToLanguageSection = "CanManageLanguageSection";
				return operationRights;
			},

			//endregion

			//region Methods: Public

			/**
			 * Gets "NavigateToLanguageSection" item visibility.
			 * @return {Boolean}
			 */
			getNavigateToLanguageSectionVisible: function() {
				return true;
			},

			/**
			 * Gets "NavigateToTranslationSection" item visibility.
			 * @return {Boolean}
			 */
			getNavigateToTranslationSectionVisible: function() {
				return true;
			}

			//endregion

		},
		diff: [
			{
				"operation": "insert",
				"index": 2,
				"propertyName": "items",
				"parentName": "SystemSettingsTile",
				"name": "LanguageSection",
				"values": {
					"itemType": this.Terrasoft.ViewItemType.LINK,
					"caption": {"bindTo": "Resources.Strings.LanguageSectionCaption"},
					"tag": "navigateToLanguageSection",
					"click": {"bindTo": "invokeOperation"},
					"visible": {"bindTo": "getNavigateToLanguageSectionVisible"}
				}
			},
			{
				"operation": "insert",
				"index": 3,
				"propertyName": "items",
				"parentName": "SystemSettingsTile",
				"name": "TranslationSection",
				"values": {
					"itemType": this.Terrasoft.ViewItemType.LINK,
					"caption": {"bindTo": "Resources.Strings.TranslationSectionCaption"},
					"tag": "navigateToTranslationSection",
					"click": {"bindTo": "invokeOperation"},
					"visible": {"bindTo": "getNavigateToTranslationSectionVisible"}
				}
			}
		]
	};
});
