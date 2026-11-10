define("BaseSectionV2", ["PortalFolderManagerViewModel", "SchemaAccessControllerMixin"], function () {
	return {
		mixins: {
			"SchemaAccessControllerMixin": "Terrasoft.SchemaAccessControllerMixin"
		},
		methods: {
			/**
			 * @inheritdoc Terrasoft.BaseSectionV2#init
			 * @override
			 */
			init: function () {
				if (this.Terrasoft.isCurrentUserSsp() && !this.Terrasoft.isAngularHost) {
					const hash = this.Terrasoft.combinePath("SectionModuleV2", "sectionSchema");
					const isRedirected = this.redirectIfDenied("sectionSchema", hash);
					if (isRedirected) {
						return;
					}
				}
				this.callParent(arguments);
			},

			/**
			 * @inheritdoc Terrasoft.BaseSectionV2#getViewOptions
			 * @override
			 */
			getViewOptions: function () {
				if (!this.Terrasoft.isCurrentUserSsp()) {
					return this.callParent(arguments);
				}
				var viewOptions = this.Ext.create("Terrasoft.BaseViewModelCollection");
				viewOptions.addItem(this.getButtonMenuItem({
					"Caption": {"bindTo": "Resources.Strings.SortMenuCaption"},
					"Items": {"bindTo": "SortColumns"},
					"Visible": {"bindTo": "IsSortMenuVisible"}
				}));
				if (this.getIsFeatureEnabled("PortalColumnConfig")) {
					viewOptions.addItem(this.getButtonMenuItem({
						"Caption": {"bindTo": "Resources.Strings.OpenGridSettingsCaption"},
						"Click": {"bindTo": "openGridSettings"},
						"Visible": {"bindTo": "IsGridSettingsMenuVisible"}
					}));
				}
				return viewOptions;
			}

		}
	};
});
