define("CommunicationPanel", ["terrasoft"],
	function(Terrasoft) {
		return {
			messages: {},
			attributes: {},
			methods: {
              	/**
				 * @inheritdoc Terrasoft.BaseSchemaViewModel#init
				 * @protected
				 * @overridden
				 */
				init: function(callback, scope) {
					this.callParent(arguments);
					this.set("ProcessDashboardVisible", this.getIsNotPortalUser());
				},
				/**
				 * Defines whether current user is portal or not.
				 * @private
				 * @return {boolean} true - if current user is not portal user
				 */
				getIsNotPortalUser: function() {
					return !Terrasoft.isCurrentUserSsp();
				},
				/**
				 * Determines whether the current user will have access to the email panel
				 * @private
				 * @return {boolean} true - if current user has access to email panel
				 */
				getIsEmailAvailable: function() {
					return !Terrasoft.isCurrentUserSsp();
				}
			},
			diff: [
				{
					"operation": "merge",
					"name": "email",
					"values": {
						"visible": {
							"bindTo": "getIsEmailAvailable"
						}
					}
				},
				{
					"operation": "merge",
					"name": "remindings",
					"values": {
						"visible": {
							"bindTo": "getIsNotPortalUser"
						}
					}
				},
				{
					"operation": "merge",
					"name": "esnFeed",
					"values": {
						"visible": {
							"bindTo": "getIsNotPortalUser"
						}
					}
				},
				{
					"operation": "merge",
					"name": "centerNotification",
					"values": {
						"visible": {
							"bindTo": "getIsNotPortalUser"
						}
					}
				}
			]
		};
	});
