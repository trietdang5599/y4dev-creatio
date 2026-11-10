define("ChatTimelineItemViewModel", ["OmniChatUtilities", "BaseTimelineItemViewModel", "ChatTimelineItemViewModelResources"],
	function(OmniChatUtilities) {
		/**
		 * @class Terrasoft.configuration.ChatTimelineItemViewModel
		 * Chat timeline item view model class.
		 */
		Ext.define("Terrasoft.configuration.ChatTimelineItemViewModel", {
			alternateClassName: "Terrasoft.ChatTimelineItemViewModel",
			extend: "Terrasoft.BaseTimelineItemViewModel",

			// region Methods: Protected

			/**
			 * @inheritdoc Terrasoft.BaseTimelineItemViewModel#captionLinkMouseOver
			 * @override
			 */
			captionLinkMouseOver: Terrasoft.emptyFn,

			/**
			 * @inheritdoc Terrasoft.BaseTimelineItemViewModel#onCaptionClick
			 * @override
			 */
			onCaptionClick: function () {
				var historyState = this.sandbox.publish("GetHistoryState");
				if (historyState.hash.entityName !== "ContactPageV2") {
					this.openEntityCard("Contact", this.$Author.value, this.getEntityTypeColumnValue());
				}
				return false;
			},

			/**
			 * Toggles chat visibility.
			 */
			toggleChat: function() {
				const isShown = !this.$IsChatShown;
				this.set("IsChatShown", isShown);
				var omniEl =  Ext.select("ts-omnichannel-messaging-chat-history").elements[0];
				if (omniEl && isShown) {
					omniEl.addEventListener("contactClick", OmniChatUtilities.openContactCard.bind(this));
				}
				this.setShowMoreLessIconUrl();
			},

			/**
			 * Sets button image depends on container collapsing.
			 */
			setShowMoreLessIconUrl: function() {
				const image = !this.$IsChatShown ?
					this.get("Resources.Images.ShowMoreImage")
					: this.get("Resources.Images.ShowLessImage");
				this.set("ShowMoreLessImage", Terrasoft.ImageUrlBuilder.getUrl(image));
			},

			/**
			 * Returns chat identifier.
			 */
			getChatId: function() {
				return this.$Id;
			},

			// endregion

			// region Methods: Public

			/**
			 * @inheritdoc Terrasoft.BaseTimelineItemViewModel#initDefaultValues
			 * @override
			 */
			initDefaultValues: function() {
				this.callParent(arguments);
				this.set("ShowAuthorIcon", true);
				this.setShowMoreLessIconUrl()
			}

			// endregion

		});
	});
