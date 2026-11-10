define("ClientContactProfileSchema", ["ProfileSchemaMixin", "CommunicationOptionsMixin"],
	function() {
		return {
			entitySchemaName: "Contact",
			messages: {
				"ContactSaved": {
					mode: Terrasoft.MessageMode.PTP,
					direction: Terrasoft.MessageDirectionType.SUBSCRIBE
				}
			},
			attributes: {},
			mixins: {},
			methods: {
				/**
				 * @inheritDoc BaseProfileSchema#getMiniPageConfig
				 * @override
				 */
				getMiniPageConfig: function() {
					const parentConfig = this.callParent(arguments);
					if (Terrasoft.isCurrentUserSsp()) {
						parentConfig.miniPageSchemaName="PortalContactMiniPage";
						parentConfig.operation = Terrasoft.ConfigurationEnums.CardOperation.EDIT;
					}
					return parentConfig;
				},

				/**
				 * @inheritDoc BaseProfileSchema#onProfileHeaderClick
				 * @override
				 */
				onProfileHeaderClick: function(options) {
					if (Terrasoft.isCurrentUserSsp()) {
						var config = this.getMiniPageConfig(options);
						this.openMiniPage(config);
						return false;
					}
					return this.callParent(arguments);
				},

				/**
				 * @inheritDoc BaseProfileSchema#onProfileLinkMouseOver
				 * @override
				 */
				onProfileLinkMouseOver: function() {
					if (Terrasoft.isCurrentUserSsp()) {
						return;
					}
					this.callParent(arguments);
				},

				subscribeSandboxEvents: function() {
					this.callParent(arguments);
					this.subscribeUpdateProfile();
				},

				subscribeUpdateProfile: function() {
					this.sandbox.subscribe("ContactSaved", this.updateProfile, this, [this.sandbox.id]);
				},

				updateProfile: function() {
					this.initEntity();
				}
			},
			diff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/
		};
	}
);
