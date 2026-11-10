  define("ActivityPageV2", ["JoinLinkGenerationMixin", "css!JoinLinkGenerationMixin"], function() {
	return {
		entitySchemaName: "Activity",
		mixins: {
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
			 * Notify about setting meeting service link
			 */
			"SetMeetingServiceLink": {
				"mode": Terrasoft.MessageMode.PTP,
				"direction": Terrasoft.MessageDirectionType.PUBLISH
			}
		},
		methods: {

			//region Methods: Private

			/**
			 * @private
			 * Initialize join link
			 */
			_initJoinLink: function(){
				this.initMeetingServicesJoinLink(function(joinLink){
					this.set("MeetingServiceLink", joinLink);
					this.sandbox.publish("SetMeetingServiceLink", joinLink);
				}, this);
			},

			//endregion

			//region Methods: Protected

			/**
			 * @inheritdoc Terrasoft.BasePageV2#onEntityInitialized
			 * @overridden
			 */
			onEntityInitialized: function () {
				this.callParent(arguments);
				this._initJoinLink();
			},

			/**
			 * @inheritdoc Terrasoft.BasePageV2#onSaved
			 * @overridden
			 */
			onSaved: function(){
				this._initJoinLink();
				this.callParent(arguments);
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
				"parentName": "LeftContainer",
				"propertyName": "items",
				"values": {
					"itemType": Terrasoft.ViewItemType.BUTTON,
					"style": Terrasoft.controls.ButtonEnums.style.GREEN,
					"classes": {
						"wrapperClass": "join-btn-wrapper",
						"textClass": "join-button-text",
						"imageClass": "join-button-icon"
					},
					"caption": {
						"bindTo": "Resources.Strings.JoinMeetingButtonCaption"
					},
					"hint": {
						"bindTo": "Resources.Strings.JoinMeetingButtonHint"
					},
					"imageConfig" : {"bindTo": "Resources.Images.JoinCameraIcon"},
					"click": {
						"bindTo": "openMeetingServiceLink"
					},
					"visible": {
						"bindTo": "getJoinBtnVisible"
					}
				},
				"index": 99
			}
		]/**SCHEMA_DIFF*/
	};
});
