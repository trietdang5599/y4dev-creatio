define("OmniChatModule", ["OmniChatUtilities", "BaseSchemaModuleV2", "mf!OmnichannelMessagingComponent",
		"css-ltr!OmnichannelMessagingComponentStyles", "css!OmniChatModule"],
	function (OmniChatUtilities) {
		Ext.define("Terrasoft.configuration.OmniChatModule", {
			extend: "Terrasoft.BaseSchemaModule",
			alternateClassName: "Terrasoft.OmniChatModule",

			mixins: {
				customEvent: "Terrasoft.CustomEventDomMixin"
			},

			_omniEl: null,

			omniEventName: "OmniChatWSMessages",

			/**
			 * @inheritDoc Terrasoft.BaseSchemaModule#useHistoryState
			 * @override
			 */
			useHistoryState: false,

			_getIsOmniChatListLoaded: function () {
				this.mixins.customEvent.publish("GetIsOmniChatListLoaded", true);
			},

			/**
			 * @inheritDoc Terrasoft.BaseSchemaModule#render
			 * @override
			 */
			render: function () {
				const container = Ext.get("OmniChatModule_WrapContainer");
				_omniEl = document.createElement("ts-omnichannel-messaging-chat-list");
				_omniEl.addEventListener("contactClick", OmniChatUtilities.openContactCard.bind(this));
				_omniEl.addEventListener("accountClick", OmniChatUtilities.openAccountCard.bind(this));
				_omniEl.addEventListener("duplicatesContactsClick", this._openDuplicatesContactsCard.bind(this));
				container.el.appendChild(_omniEl);
				this.sandbox.publish("OmniChatListLoaded");
				this.mixins.customEvent.subscribe("GetIsOmniChatListLoaded").subscribe(this._getIsOmniChatListLoaded.bind(this));
				Terrasoft.ServerChannel.on(Terrasoft.EventName.ON_MESSAGE, this._onChannelMessage, this);
			},

			/**
			 * @private
			 */
			_onChannelMessage: function (scope, message) {
				if (this._isMessageValid(message)) {
					this.mixins.customEvent.publish(this.omniEventName, Terrasoft.encode(message));
				}
			},

			/**
			 * @private
			 */
			_isMessageValid: function (message) {
				return message?.Header?.BodyTypeName !== null;
			},

			/**
			 * @private
			 */
			_openDuplicatesContactsCard: function (event) {
				const contactsId = event.detail.contactsId;
				const currentContactId = event.detail.currentContactId;
				const hash = "CardModuleV2/ChatContactDuplicatesPage/Contact";
				this.sandbox.publish("PushHistoryState", {
					hash: hash,
					stateObj: {
						DuplicatesContacts: contactsId,
						CurrentContactId: currentContactId
					}
				});
			},

			/**
			 * @inheritDoc Terrasoft.BaseSchemaModule#initSchemaName
			 * @override
			 */
			initSchemaName: function () {
				this.schemaName = "OmniChatSchema";
			},

			/**
			 * @inheritDoc Terrasoft.Component#init
			 * @override
			 */
			init: function () {
				this.callParent(arguments);
				this.sandbox.registerMessages({
					"OmniChatListLoaded": {
						direction: Terrasoft.MessageDirectionType.PUBLISH,
						mode: Terrasoft.MessageMode.BROADCAST
					}
				});
				this.mixins.customEvent.init();
			},

			/**
			 * @inheritDoc Terrasoft.BaseSchemaViewModel#destroy
			 * @override
			 */
			destroy: function () {
				Terrasoft.ServerChannel.un(Terrasoft.EventName.ON_MESSAGE, this._onChannelMessage, this);
				this.callParent(arguments);
			}
		});

		return Terrasoft.OmniChatModule;
	});
