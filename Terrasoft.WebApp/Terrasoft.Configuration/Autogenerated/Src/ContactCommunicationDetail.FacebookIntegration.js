define("ContactCommunicationDetail", ["FacebookClientUtilities"], function() {
		return {
			attributes: {
				/**
				 * ####### ########### ######### #### Facebook # #### ########## ####.
				 */
				FacebookMenuItemEnabled: {
					type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
					dataValueType: Terrasoft.DataValueType.BOOLEAN,
					value: false
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
				/**
				 * @inheritdoc Terrasoft.BaseCommunicationDetail#updateFacebookProfileInfo
				 * @overridden
				 */
				updateFacebookProfileInfo: function() {
					this.callParent(arguments);
					var facebookMenuItemEnabled =
						this.getCanAddSeveralProfilesForOneRecord(this.canAddSeveralFacebookProfiles);
					this.set("FacebookMenuItemEnabled", facebookMenuItemEnabled);
				}
			}
		}
	});
