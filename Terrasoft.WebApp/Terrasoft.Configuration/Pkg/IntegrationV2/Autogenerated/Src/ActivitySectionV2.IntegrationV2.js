define("ActivitySectionV2", ["ActivitySectionSchedulerViewModel", "MeetingInvitationsMixin", "JoinLinkGenerationMixin", "css!JoinLinkGenerationMixin"],
	function() {
		return {
			entitySchemaName: "Activity",
			mixins: {
				"MeetingInvitationsMixin": "Terrasoft.MeetingInvitationsMixin",
				"JoinLinkGenerationMixin": "Terrasoft.JoinLinkGenerationMixin",
			},
			attributes: {

				/**
				 * Link to the meeting service to connect.
				 */
				"MeetingServiceLink": {
					"dataValueType": Terrasoft.DataValueType.TEXT,
					"type": Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"value": ""
				}
			},
			messages: {
				/**
				 * @message SetMeetingServiceLink
				 * Set meeting service link
				 */
				"SetMeetingServiceLink": {
					"mode": Terrasoft.MessageMode.PTP,
					"direction": Terrasoft.MessageDirectionType.SUBSCRIBE
				}
			},
			methods: {

				//region Methods: Protected

				/**
				 * @inheritdoc Terrasoft.GridUtilities#getGridRowViewModelClassName
				 * @overridden
				 */
				getGridRowViewModelClassName: function (){
					return this.isSchedulerDataView() && this.getIsFeatureEnabled("MeetingInvitation")
						? "Terrasoft.ActivitySectionSchedulerViewModel"
						: this.callParent(arguments);
				},

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
				},

				/**
				 * @inheritdoc Terrasoft.ActivitySectionV2#init
				 * @overridden
				 */
				init: function () {
					this.callParent(arguments);
					this.sandbox.subscribe("SetMeetingServiceLink", function(joinLink) {
						this.set("MeetingServiceLink", joinLink);
						this._joinLink = joinLink;
					}, this);
				},

				/**
				* @protected
				* Check if join button is vissible
				*/
				getJoinBtnVisible: function(){
					return this.isNotEmpty(this.get("MeetingServiceLink"));
				}

				//endregion

			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "insert",
					"name": "JoinMeetingButton",
					"parentName": "CombinedModeActionButtonsCardLeftContainer",
					"propertyName": "items",
					"values": {
						"itemType": Terrasoft.ViewItemType.BUTTON,
						"style": Terrasoft.controls.ButtonEnums.style.GREEN,
						"caption":{
							"bindTo":  "Resources.Strings.JoinMeetingButtonCaption"
						},
						"hint": {
							"bindTo": "Resources.Strings.JoinMeetingButtonHint"
						},
						"imageConfig" : {"bindTo": "Resources.Images.JoinCameraIcon"},
						"click": {
							"bindTo": "openMeetingServiceLink"
						},
						"classes": {
							"wrapperClass": "join-btn-wrapper",
							"textClass": "join-button-text",
							"imageClass": "join-button-icon"
						},
						"visible": {
							"bindTo": "getJoinBtnVisible"
						}
					},
					"index": 99
				}
 			]/**SCHEMA_DIFF*/
		};
	}
);
