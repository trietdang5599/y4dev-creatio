define("BaseDataView", ["ServiceHelper", "EsnSubscriptionMixin"], function(ServiceHelper) {
	return {
		messages: {
			/**
			 * Updates user channel subscription flag.
			 * @message UpdateSubscribeAction
			 */
			"UpdateSubscribeAction": {
				mode: Terrasoft.MessageMode.PTP,
				direction: Terrasoft.MessageDirectionType.SUBSCRIBE
			}
		},
		mixins: {
			/**
			 * @class EsnSubscriptionMixin Mixin, implements common binding actions.
			 */
			EsnSubscriptionMixin: "Terrasoft.EsnSubscriptionMixin"
		},
		methods: {

			//region methods: private

			/**
			 * Returns Subscribe button visibility.
			 * @obsolete
			 * @private
			 * @param {Boolean} value IsSubscribed flag value.
			 * @return {Boolean} Subscribe button visibility.
			 */
			getSubscribeButtonVisible: function() {
				return true;
			},

			/**
			 * @obsolete
			 */
			onSubscribeButtonClick: function() {
				var entity = this.getActiveRow();
				if (!entity) {
					return;
				}
				var entityId = entity.get("Id");
				ServiceHelper.callService("SocialSubscriptionService", "SubscribeUser", function() {
					this.updateIsSubscribed(true);
				}, {
					entityId: entityId,
					entitySchemaUId: entity.entitySchema.uId
				}, this);
			},

			/**
			 * Updates user channel subscription flag.
			 * @private
			 * @param {Boolean} isSubscribed IsSubscribed flag value.
			 */
			updateIsSubscribed: function(isSubscribed) {
				this.set("IsSubscribed", isSubscribed);
				this.sandbox.publish("UpdateCardProperty", {
					key: "IsSubscribed",
					value: isSubscribed
				}, this.getCardModuleSandboxIdentifiers());
			},

			/**
			 * @obsolete
			 */
			onUnsubscribeButtonClick: function() {
				var entity = this.getActiveRow();
				if (!entity) {
					return;
				}
				var entityId = entity.get("Id");
				ServiceHelper.callService("SocialSubscriptionService", "UnsubscribeUser", function() {
					this.updateIsSubscribed(false);
				}, {entityId: entityId}, this);
			},

			//endregion

			//region methods: protected

			/**
			 * @inheritDoc Terrasoft.BaseSectionV2#subscribeSandboxEvents
			 * @overridden
			 */
			subscribeSandboxEvents: function() {
				this.callParent(arguments);
				this.sandbox.subscribe("UpdateSubscribeAction", function(config) {
					this.updateIsSubscribed(config.isSubscribed);
				}, this, this.getCardModuleSandboxIdentifiers());
			}

			//endregion
		},
		diff: /**SCHEMA_DIFF*/[{
			"operation": "merge",
			"name": "CombinedModeAddRecordButton",
			"parentName": "CombinedModeActionButtonsSectionContainer",
			"propertyName": "items",
			"values": {
				"itemType": Terrasoft.ViewItemType.BUTTON,
				"style": Terrasoft.controls.ButtonEnums.style.BLUE,
				"caption": {"bindTo": "AddRecordButtonCaption"},
				"click": {"bindTo": "addRecord"}
			}
		}]/**SCHEMA_DIFF*/
	};
});
