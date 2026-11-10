/**
 * Parent: BaseSectionPageSettings
 */
define("SectionPageSettings", [
	"SectionPageSettingsResources",
], function(resources) {
	return {
		messages: {
			"SaveSectionVisaSettings": {
				mode: Terrasoft.MessageMode.PTP,
				direction: Terrasoft.MessageDirectionType.PUBLISH
			}
		},
		methods: {

			// region Methods: Private
			// endregion

			// region Methods: Protected

			/**
			 * @inheritdoc Terrasoft.BaseSectionPageSettings#onBeforeSectionPageWiazardOpen
			 * @override
			 */
			onBeforeSectionPageWiazardOpen: function(callback, scope) {
				this.sandbox.publish("SaveSectionVisaSettings", callback);
			}

			// endregion

			// region Methods: Public
			// endregion

		},
		diff: []
	};
});
