define("ChatTimelineItemView", ["BaseTimelineItemView", "ImageCustomGeneratorV2", "css!ChatTimelineItemView", "OmniChatComponent"],
	function() {
	/**
	 * @class Terrasoft.configuration.ChatTimelineItemView
	 * Chat timeline item view class.
	 */
	Ext.define("Terrasoft.configuration.ChatTimelineItemView", {
		extend: "Terrasoft.BaseTimelineItemView",
		alternateClassName: "Terrasoft.ChatTimelineItemView",

		/**
		 * @private
		 */
		_getReadMoreButton: function() {
			return {
				"name": "ShowButtonContainer",
				"itemType": Terrasoft.ViewItemType.CONTAINER,
				"wrapClass": ["chat-show-more-less-button-container"],
				"items": [
					{
						"name": "ShowMoreLessIcon",
						"itemType": Terrasoft.ViewItemType.IMAGE,
						"getSrcMethod": "ShowMoreLessImage",
						"readonly": true,
						"generator": "ImageCustomGeneratorV2.generateSimpleCustomImage",
						"classes": {
							"wrapClass": ["chat-show-more-less-image"],
						}
					},	
					{
						"itemType": Terrasoft.ViewItemType.LABEL,
						"caption": {"bindTo": "Resources.Strings.ShowChatButtonCaption"},
						"click": { "bindTo": "toggleChat"},
						"visible": {
							"bindTo": "IsChatShown",
							"bindConfig": {"converter": "invertBooleanValue"}
						},
						"id": "ShowChatButton",
						"classes": {
							"labelClass": ["chats-button"]
						},
					},
					{
						"itemType": Terrasoft.ViewItemType.LABEL,
						"caption": {"bindTo": "Resources.Strings.HideChatButtonCaption"},
						"click": { "bindTo": "toggleChat"},
						"id": "HideChatButton",
						"visible": {
							"bindTo": "IsChatShown",
						},
						"classes": {
							"labelClass": ["chats-button"]
						},
					}
				]
			};
		},

		/**
		 * @private
		 */
		_getChatContainer: function () {
			return {
				"name": "Chat",
				"itemType": Terrasoft.ViewItemType.COMPONENT,
				"className": "Terrasoft.OmniChatComponent",
				"chatId": {
					"bindTo": "getChatId"
				},
				"visible": { "bindTo": "IsChatShown" }
			};
		},

		/**
		 * @inheritdoc Terrasoft.BaseTimelineItemView#getBodyViewConfig
		 * @override
		 */
		getBodyViewConfig: function() {
			return {
				itemType: Terrasoft.ViewItemType.CONTAINER,
				id: "ChatContainer",
				items: [this._getReadMoreButton(), this._getChatContainer()],
			};
		}

	});
});
