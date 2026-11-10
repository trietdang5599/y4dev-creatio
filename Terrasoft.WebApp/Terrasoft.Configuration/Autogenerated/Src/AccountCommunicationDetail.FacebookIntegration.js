define("AccountCommunicationDetail", ["FacebookClientUtilities"], function() {
		return {
			attributes: {
				/**
				 * @inheritdoc Terrasoft.BaseCommunicationDetail#FacebookSearchSchemaName
				 * @overridden
				 */
				FacebookSearchSchemaName: {
					value: "AccountFacebookSearchSchema"
				}
			},
			properties: {
				canAddSeveralFacebookProfiles: false,
			},
			mixins: {
				FacebookClientUtilities: "Terrasoft.FacebookClientUtilities"
			},
			methods: {
				init: function() {
					this.initCanAddSeveralFacebookProfiles();
					this.callParent(arguments);
				},
				updateFacebookProfileInfo: function() {
					this.callParent(arguments);
					var facebookMenuItemEnabled =
						this.getCanAddSeveralProfilesForOneRecord(this.canAddSeveralFacebookProfiles);
					this.set("FacebookMenuItemEnabled", facebookMenuItemEnabled);
				},
				modifyFacebookMenuItem: function(facebookMenuItem) {
					this.callParent(arguments);
					facebookMenuItem.set("Enabled", {
						bindTo: "FacebookMenuItemEnabled"
					});
				}
			}
		}
	});
