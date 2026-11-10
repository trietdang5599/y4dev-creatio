define("OmniChatComponent", ["mf!OmnichannelMessagingComponent", "css-ltr!OmnichannelMessagingComponentStyles",
	"css!ChatTimelineItemView"], function () {
	Ext.define("Terrasoft.control.OmniChatComponent", {
		extend: "Terrasoft.controls.Component",
		alternateClassName: "Terrasoft.OmniChatComponent",

		/**
		 * @inheritDoc Terrasoft.Component#tpl
		 * @override
		 */
		tpl: [
			/*jshint white:false */
			/*jshint quotmark:true */
			//jscs:disable
			'<div id=\"{id}-wrap\" class=\"{chatWrapClass}\">',
			'<ts-omnichannel-messaging-chat-history chatId=\"{chatId}\">',
			'</ts-omnichannel-messaging-chat-history>',
			'</div>',
			//jscs:enable
			/*jshint quotmark:false */
			/*jshint white:true */
		],

		/**
		 * Chat identifier.
		 */
		chatId: null,

		/**
		 * Chat component wrap class.
		 */
		chatWrapClass: "chat-wrap-container",

		/**
		 * @inheritDoc Terrasoft.Component#getSelectors
		 * @override
		 */
		getSelectors: function () {
			return {
				wrapEl: "#" + this.id + "-wrap",
				omniChatEl: "#" + this.id
			};
		},

		/**
		 * Applies styles to the tpl.
		 * @param {Object} tpl Component template.
		 */
		applyStyles: function(tpl) {
			const styles = {
				chatWrapClass: this.chatWrapClass
			};
			Ext.apply(tpl, styles);
		},

		/**
		 * @inheritdoc Terrasoft.Component#getBindConfig
		 * @overridden
		 */
		getBindConfig: function() {
			const bindConfig = this.callParent(arguments);
			const dataBindConfig = {
				chatId: {
					changeMethod: "setChatId"
				}
			};
			Ext.apply(dataBindConfig, bindConfig);
			return dataBindConfig;
		},

		/**
		 * Initializes chat identifier.
		 * @param {Guid} chatId Chat identifier.
		 */
		setChatId: function(chatId) {
			if (chatId) {
				this.chatId = chatId;
				this.safeRerender();
			}
		},

		/**
		 * @inheritDoc Terrasoft.Component#getTplData
		 * @override
		 */
		getTplData: function () {
			const tplData = this.callParent(arguments);
			this.selectors = this.getSelectors();
			const componentTplData = {
				chatId: this.chatId
			};
			this.applyStyles(tplData);
			Ext.apply(tplData, componentTplData);
			return tplData;
		},

	});

	return Terrasoft.OmniChatComponent;
});