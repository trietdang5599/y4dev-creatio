define("ContactPageV2", ["FacebookClientUtilities"], function() {
	return {
		mixins: {
			/**
			 * @class FacebookClientUtilities ######### ####### ###### ###### # ###. ##### facebook.
			 */
			FacebookClientUtilities: "Terrasoft.FacebookClientUtilities"
		},
		methods: {
			checkCanOpenSocialContactPage: function(callback, scope) {
				this.callParent([function() {
					this.checkCanFacebookConnectorOperate(callback, scope);
				}, this]);
			}
		},
		details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
		diff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/
	};
});
