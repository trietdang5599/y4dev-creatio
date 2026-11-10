define("CommunicationPanelEmailSchema", ["EmailConstants", "EmailMiningEnums"],
	function(EmailConstants) {
		return {
			entitySchemaName: EmailConstants.entitySchemaName,

			methods: {

				//region Methods: Protected

				/**
				 * @inheritdoc Terrasoft.CommunicationPanelEmailSchema#addEsqColumns
				 * @overridden
				 */
				addEsqColumns: function(esq) {
					this.callParent(arguments);
					esq.addColumn("EnrchEmailData.Status");
					esq.addColumn("EnrchEmailData");
				},

				/**
				 * Removes viewmodel subscription to server messages.
				 * @protected
				 */
				unsubscribeServerChannelEvents: function() {
					this.Terrasoft.ServerChannel.un(this.Terrasoft.EventName.ON_MESSAGE,
						this.onServerChannelMessage, this);
				},

				/**
				 * Subscribes viewmodel to server messages.
				 * @protected
				 */
				subscribeServerChannelEvents: function() {
					this.Terrasoft.ServerChannel.on(this.Terrasoft.EventName.ON_MESSAGE,
						this.onServerChannelMessage, this);
				},

				/**
				 * Server message handler. Reloads emails after enrich events.
				 * @protected
				 * @param {Object} scope Message scope.
				 * @param {Object} message Server messsage.
				 */
				onServerChannelMessage: function(scope, message) {
					if (message && message.Header && message.Header.Sender !== "EmailMining") {
						return;
					}
					var receivedMessage = this.Ext.decode(message.Body);
					var emailIds = [];
					var consts = this.Terrasoft.EmailMiningEnums;
					switch (message.Header.BodyTypeName) {
						case consts.EnrichMessageBodyType.ENRICHED:
							this.Terrasoft.each(receivedMessage, function(item) {
								if (item.enrichStatus && item.enrichStatus === consts.EmailEnrichStatus.DONE) {
									emailIds.push(item.activityId);
								}
							}, this);
							break;
						case consts.EnrichMessageBodyType.SAVED:
							this.Terrasoft.each(receivedMessage, function(item) {
								emailIds.push(item.activityId);
							}, this);
							break;
						default:
							break;
					}
					this.reloadEmailsData(emailIds);
				},

				//endregion

				//region Methods: Public

				/**
				 * @inheritdoc Terrasoft.BaseSchemaViewModel#init
				 * @overridden
				 */
				init: function() {
					this.callParent(arguments);
					this.subscribeServerChannelEvents();
				},

				/**
				 * @inheritdoc Terrasoft.CommunicationPanelEmailSchema#onLoadEntity
				 * @overridden
				 */
				onLoadEntity: function(entity, viewModel) {
					if (viewModel) {
						var actions = viewModel.get("ActionsMenuCollection");
						if (actions) {
							actions.clear();
						}
						viewModel.set("ReloadActions", true);
					}
					return this.callParent(arguments);
				},

				/**
				 * Returns first element of collection, filtered by passed function.
				 * @param {Terrasoft.BaseViewModelCollection} collection Base view model collection instance.
				 * @param {Function} filterFn Filter function.
				 * @return {Terrasoft.BaseViewModel} First element of collection, filtered by passed function.
				 */
				firstByFn: function(collection, filterFn) {
					var filteredItems = collection.filterByFn(filterFn);
					return filteredItems.findByIndex(0);
				},

				/**
				 * @inheritdoc Terrasoft.BaseSchemaViewModel#destroy
				 * @overridden
				 */
				destroy: function() {
					this.unsubscribeServerChannelEvents();
					this.callParent(arguments);
				}

				//endregion

			}
		};
	});
