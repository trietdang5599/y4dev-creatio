define("MainHeaderSchema", ["ModalBox"],
	function(ModalBox) {
		return {
			messages: {
				/**
				 * Update contact enrichment page visibility.
				 */
				"ContactEnrichmentPageVisibilityChanged": {
					"mode": Terrasoft.MessageMode.PTP,
					"direction": Terrasoft.MessageDirectionType.SUBSCRIBE
				}

			},
			attributes: {

				/**
				 * Signs that contact enrichment page is visible.
				 * @type {Boolean}
				 */
				"ContactEnrichmentPageVisible": {
					"dataValueType": Terrasoft.DataValueType.BOOLEAN,
					"value": false
				},

				/**
				 * Enrich module container.
				 * @type {Boolean}
				 */
				"ContactEnrichmentModuleContainerId": {
					"dataValueType": Terrasoft.DataValueType.TEXT,
					"value": "ContactEnrichmentModuleContainer"
				},

				/**
				 * Shell enrich module container.
				 * @type {String}
				 */
				 "ShellContactEnrichmentModuleContainerId": {
					"dataValueType": Terrasoft.DataValueType.TEXT,
					"value": "ShellContainer"
				},

				/**
				 * Enrich modal identifier
				 * @type {String}
				 */
				 "ModalId": {
					"dataValueType": Terrasoft.DataValueType.TEXT,
					"value": ""
				},

			},
			methods: {

				//region Methods: Private

				/**
				 * Adapt modal window to shell container if it exists
				 * @private
				 */
					adaptToShellContainer: function() {
					var shellContainer = Ext.get(this.get("ShellContactEnrichmentModuleContainerId"));
					if(shellContainer){
						this.set("ContactEnrichmentModuleContainerId", this.get("ShellContactEnrichmentModuleContainerId"))
					}
				},
				
				//endregion

				//region Methods: Protected

				/**
				 * @inheritdoc Terrasoft.BaseSchemaViewModel#init
				 * @overridden
				 */
				init: function() {
					this.callParent(arguments);
					this.subscribeServerChannelEvents();
				},

				/**
				 * @inheritdoc Terrasoft.BaseSchemaViewModel#destroy
				 * @overridden
				 */
				destroy: function() {
					this.unsubscribeServerChannelEvents();
					this.callParent(arguments);
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
				 * Server message handler. Show enrichment error message to console, if occurred one.
				 * @protected
				 * @param {Object} scope Message scope.
				 * @param {Object} message Server messsage.
				 */
				onServerChannelMessage: function(scope, message) {
					if (message && message.Header && message.Header.Sender !== "EmailEnrichmentError") {
						return;
					}
					var receivedMessage = this.Ext.decode(message.Body);
					this.log(Ext.String.format("Global enrichment error: {0};",
							receivedMessage.errorText));
				},

				/**
				 * @inheritdoc Terrasoft.BaseSchemaViewModel#subscribeSandboxEvents
				 * @overridden
				 */
				subscribeSandboxEvents: function() {
					this.callParent(arguments);
					this.sandbox.subscribe("ContactEnrichmentPageVisibilityChanged",
						this.onContactEnrichmentPageVisibilityChanged.bind(this));
				},

				/**
				 * Handles changing contact enrichment page visibility.
				 * @protected
				 * @virtual
				 * @param {Object} tag Enrichment arguments.
				 * @param {Boolean} tag.isVisible Sign that contact enrichment page is visible or not.
				 * @param {String} tag.contactId Contact identifier.
				 * @param {String} tag.contactName Contact name.
				 * @param {String} tag.enrchTextDataId Enrichment text data identifier.
				 * @param {String} tag.source Source item for web analytics.
				 */
				onContactEnrichmentPageVisibilityChanged: function(tag) {
					this.adaptToShellContainer()
					var args = Ext.decode(tag);
					var showEnrichmentPage = args.isVisible;
					this.set("ContactEnrichmentPageVisible", showEnrichmentPage);
					if (!showEnrichmentPage) {
						this.sandbox.unloadModule(this.get("ModalId"));
						return;
					}
					var modalId = this.sandbox.loadModule("BaseSchemaModuleV2", {
						renderTo: this.get("ContactEnrichmentModuleContainerId"),
						instanceConfig: {
							parameters: {
								viewModelConfig: {
									ContactId: args.contactId,
									ContactName: args.contactName,
									EnrchTextDataId: args.enrchTextDataId,
									EnrchEmailDataId: args.enrchEmailDataId,
									CallerSource: args.source
								}
							},
							schemaName: "ContactEnrichmentSchema",
							isSchemaConfigInitialized: true,
							useHistoryState: false
						}
					});
					this.set("ModalId", modalId);
				},

				//endregion

			},
			diff: [
				{
					"operation": "insert",
					"name": "ContactEnrichmentModuleContainer",
					"parentName": "communicationPanelContent",
					"propertyName": "items",
					"values": {
						"id": "ContactEnrichmentModuleContainer",
						"itemType": Terrasoft.ViewItemType.CONTAINER,
						"visible": {
							"bindTo": "ContactEnrichmentPageVisible"
						},
						"items": []
					}
				}
			]
		};
	});
