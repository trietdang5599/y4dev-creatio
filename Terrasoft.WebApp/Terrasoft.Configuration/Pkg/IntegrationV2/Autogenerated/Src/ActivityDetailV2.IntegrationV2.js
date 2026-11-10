define("ActivityDetailV2", ["MeetingInvitationsMixin"],
	function() {
		return {
			entitySchemaName: "Activity",
			mixins: {
				"MeetingInvitationsMixin": "Terrasoft.MeetingInvitationsMixin"
			},
			methods: {
				
				//region Methods: Protected

				/**
				 * @inheritdoc Terrasoft.GridUtilities#getDeleteConfirmationMessage
				 * @overridden
				 */
				getDeleteConfirmationMessage: function(items, callback, scope) {
					this.callParent([items, function(baseMessage) {
						this.getMeetingDeleteConfirmationMessage(baseMessage, items, callback, scope);
					}, scope]);
				},

				/**
				 * @inheritdoc Terrasoft.GridUtilities#onMultiDeleteAccept
				 * @overridden
				 */
				onMultiDeleteAccept: function() {
					if (this.getIsFeatureEnabled("DoNotDeleteMeetingCurrentContactNotOrganizer")) {
						const parentMethod = this.getParentMethod();
						this.initCurrentContactOrganizerMeetingsInfo(function(needCallDeleteMethod) {
							if (needCallDeleteMethod) {
								parentMethod.call(this, arguments);
							}
						}, this);
					} else {
						this.callParent(arguments);
					}
				},

				/**
				 * @inheritdoc Terrasoft.GridUtilities#handlerAfterMultiDelete
				 * @overridden
				 */
				handlerAfterMultiDelete: function(responseObject) {
					this.callParent(arguments);
					if (this.getIsFeatureEnabled("DoNotDeleteMeetingCurrentContactNotOrganizer")) {
						this.showOrganizerDeleteResultMessage(responseObject);
					}
				}

				//endregion

			},
			diff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/
		};
	}
);