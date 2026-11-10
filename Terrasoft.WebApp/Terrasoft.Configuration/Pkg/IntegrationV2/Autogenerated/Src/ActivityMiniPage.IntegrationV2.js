 define("ActivityMiniPage", ["JoinLinkGenerationMixin", "css!JoinLinkGenerationMixin"], function() {
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
		details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
		methods: {
			
			//region Methods: Protected

			/**
			 * @inheritdoc Terrasoft.BasePageV2#onEntityInitialized
			 * @overridden
			 */
			onEntityInitialized: function () {
				this.callParent(arguments);
				this.initMeetingServicesJoinLink(function(joinLink){
					this.set("MeetingServiceLink", joinLink);
				}, this);
			},

			/**
			 * @protected
			 * Check if join button is vissible
			 */
			getJoinBtnVisible: function(){
				return this.isNotEmpty(this.get("MeetingServiceLink"));
			},

			/**
			 * @inheritdoc BaseMiniPage#save
			 * @override
			 */
			save: function(callback, scope) {
				if(this.Ext.isFunction(this.initListenColumnsValues)){
					this.initListenColumnsValues();
				}
				this.callParent(arguments);
			},

			//endregion

		},
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "insert",
				"name": "JoinMeetingServiceButton",
				"parentName": "HeaderContainer",
				"propertyName": "items",
				"values": {
					"itemType": Terrasoft.ViewItemType.BUTTON,
					"imageConfig": {
						"bindTo": "Resources.Images.JoinCameraIcon"
					},
					"hint": {
						"bindTo": "Resources.Strings.JoinMeetingServiceButtonHint"
					},
					"click": {
						"bindTo": "openMeetingServiceLink"
					},
					"styles": {
						"textStyle": {
							"margin-top": "15px",
							"width": "max-content",
							"font-size": "small"
						}
					},
					"classes": {
						"imageClass": "join-minicard-button-icon"
					},
					"visible": {
						"bindTo": "getJoinBtnVisible"
					}
				},
				"index": 3
			}
		]/**SCHEMA_DIFF*/
	};
});
