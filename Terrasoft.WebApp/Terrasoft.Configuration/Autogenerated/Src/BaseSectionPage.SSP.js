define("BaseSectionPage", ["SSPGridMixin"], function() {
	return {
		mixins: {
			/**
			 * Provides methods for grid handling in ssp sections.
			 */
			"SSPGridMixin": "Terrasoft.SSPGridMixin"
		},
		methods: {
			
			//region methods: protected

			/**
			 * @inheritdoc Terrasoft.BaseSectionPage#getEsnTabVisible
			 * @overridden
			 */
			getEsnTabVisible: function() {
				return this.getIsFeatureEnabled("ShowESNOnSSP") || !this.Terrasoft.isCurrentUserSsp();
			}

			//endregion
		},
		diff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/
	};
});
 