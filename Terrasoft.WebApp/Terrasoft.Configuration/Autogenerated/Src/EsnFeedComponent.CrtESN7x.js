define("EsnFeedComponent", ["Base7xViewElement"], function(Base7xWebComponent) {
	class CrtEsnFeed7xComponent extends Base7xWebComponent {
		_entitySchemaName;
		_esnFeedModuleId;
		_primaryColumnValue;
		_primaryDisplayColumnValue;
		_activeSocialMessageId;
		_publisherRightKind;

		constructor() {
			super("EsnFeed");
		}

		set primaryColumnValue(value) {
			this._primaryColumnValue = value;
		}

		get primaryColumnValue() {
			return this._primaryColumnValue;
		}

		set primaryDisplayColumnValue(value) {
			this._primaryDisplayColumnValue = value;
		}

		get primaryDisplayColumnValue() {
			return this._primaryDisplayColumnValue;
		}

		set activeSocialMessageId(value) {
			this._activeSocialMessageId = value;
		}

		get activeSocialMessageId() {
			return this._activeSocialMessageId;
		}

		set publisherRightKind(value) {
			this._publisherRightKind = value;
		}

		get publisherRightKind() {
			return this._publisherRightKind;
		}

		set entitySchemaName(value) {
			this._entitySchemaName = value;
			this.initContext(() => {
				require([this.entitySchemaName], (entitySchema) => {
					this.sandbox.subscribe("GetRecordInfo", () => {
						return {
								channelId: this.primaryColumnValue,
								channelName: this.primaryDisplayColumnValue,
								entitySchemaUId: entitySchema.uId,
								entitySchemaName: entitySchema.name,
								publisherRightKind: this.publisherRightKind
						};
					}, null, [this.sandbox.id + "_detail_ESNFeedModule"]);
					this._esnFeedModuleId = this.sandbox.loadModule("ESNFeedModule", {
						renderTo: this.renderTo,
						id: this.sandbox.id + "_detail_ESNFeedModule",
						instanceConfig: {
							parameters: {
								"viewModelConfig": {
									"IsSubscriptionEnabled": true
								}
							}
						}
					});
				});
			});
		}

		get entitySchemaName() {
			return this._entitySchemaName;
		}

		getMessages() {
			const messages = super.getMessages();
			return Object.assign(messages, {
				"GetRecordInfo": {
					mode: Terrasoft.MessageMode.PTP,
					direction: Terrasoft.MessageDirectionType.BIDIRECTIONAL
				}
			});
		}

		disconnectedCallback() {
			this.sandbox.unloadModule(this._esnFeedModuleId, this.renderTo);
			super.disconnectedCallback();
		}
	}

	if (!customElements.get('crt-esn-feed-7x')) {
		customElements.define('crt-esn-feed-7x', CrtEsnFeed7xComponent);
	}
});
