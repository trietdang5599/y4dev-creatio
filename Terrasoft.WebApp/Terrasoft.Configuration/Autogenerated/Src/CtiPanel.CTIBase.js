define("CtiPanel", ["terrasoft", "CtiProviderInitializer", "CtiBaseHelper", "CtiPanelResources", "CtiConstants", "Call",
		"AcademyUtilities", "CtiPanelModelUtilities", "CtiPanelUtils", "CtiPanelIdentificationUtilities",
		"CtiContainerListGenerator", "CtiContainerList", "SearchEdit", "CtiPanelCommunicationHistoryUtilities",
		"PanelEmptyListMixin", "EntityConnectionLinksUtilities", "css!EntityConnectionLinksUtilities",
		"CtiAgentStateMixin", "CtiLinkColumnUtility", "CallDirection"],
	function(Terrasoft, CtiProviderInitializer, CtiBaseHelper, resources, ctiConstants, callSchema, AcademyUtilities) {
		return {
			messages: {
				/**
				 * @message CallCustomer`
				 * Notifies about the necessity to call the customer.
				 * @param {Object} Call parameters information.
				 */
				"CallCustomer": {
					mode: Terrasoft.MessageMode.PTP,
					direction: Terrasoft.MessageDirectionType.SUBSCRIBE
				},

				/**
				 * @message GetCallRecords
				 * Notifies about the necessity to get call records.
				 * @param {Object} Call parameters information.
				 */
				"GetCallRecords": {
					"mode": Terrasoft.MessageMode.PTP,
					"direction": Terrasoft.MessageDirectionType.SUBSCRIBE
				},

				/**
				 * @message SelectCommunicationPanelItem
				 * ######## ##### # ################ ######.
				 * @param {Object} ########## # ######### ###### ################ ######.
				 */
				"SelectCommunicationPanelItem": {
					"mode": Terrasoft.MessageMode.PTP,
					"direction": Terrasoft.MessageDirectionType.PUBLISH
				},

				/**
				 * @message CallDurationChanged
				 * ######## ###### # ############# ################ ######.
				 * @param {String} ############ ######.
				 */
				"CallDurationChanged": {
					"mode": Terrasoft.MessageMode.PTP,
					"direction": Terrasoft.MessageDirectionType.PUBLISH
				},

				/**
				 * @message CtiPanelConnected
				 * ########## ######### # ######## cti ######.
				 */
				"CtiPanelConnected": {
					"mode": Terrasoft.MessageMode.PTP,
					"direction": Terrasoft.MessageDirectionType.PUBLISH
				},

				/**
				 * @message PushHistoryState
				 * ########## ######### ######### #########.
				 * @param {Object} ################ ###### ###### #########.
				 */
				"PushHistoryState": {
					"mode": Terrasoft.MessageMode.BROADCAST,
					"direction": Terrasoft.MessageDirectionType.PUBLISH
				},

				/**
				 * @message AgentStateChanged
				 * ######### ######### ######## ####### #########.
				 * @param {String} ############ ######.
				 */
				"AgentStateChanged": {
					"mode": Terrasoft.MessageMode.PTP,
					"direction": Terrasoft.MessageDirectionType.PUBLISH
				}
			},
			mixins: {
				/**
				 * ###### ###### #############.
				 */
				CtiPanelModelUtilities: Terrasoft.CtiPanelModelUtilities,

				/**
				 * ###### ###### ########### ############ ####### Cti ######.
				 */
				CtiPanelUtils: Terrasoft.CtiPanelUtils,

				/**
				 * ###### ############# ########.
				 */
				CtiPanelIdentificationUtilities: Terrasoft.CtiPanelIdentificationUtilities,

				/**
				 * ###### ####### #######.
				 */
				CtiPanelCommunicationHistoryUtilities: Terrasoft.CtiPanelCommunicationHistoryUtilities,

				/**
				 * ###### ### ###### ######### ### ###### ####### #######.
				 */
				PanelEmptyListMixin: Terrasoft.PanelEmptyListMixin,

				/**
				 * Entity connection lookup columns mixin.
				 */
				EntityConnectionLinksUtilities: Terrasoft.EntityConnectionLinksUtilities,

				/**
				 * @class Terrasoft.mixins.CustomEventDomMixin Provides methods for publish message by websockets.
				 */
				CustomEvent: "Terrasoft.mixins.CustomEventDomMixin",

				/**
				 * @class Terrasoft.configuration.mixins.CtiAgentStateMixin Provides methods for agent state operations.
				 */
				CtiAgentStateMixin: Terrasoft.CtiAgentStateMixin,

				/**
				 * @class Terrasoft.configuration.CtiLinkColumnUtility Provides methods for cti links.
				 */
				CtiLinkColumnUtility: Terrasoft.CtiLinkColumnUtility
			},
			attributes: {
				/**
				 * Profile button menu collection.
				 * @private
				 * @type {Terrasoft.BaseViewModelCollection}
				 */
				"OperatorStatusMenuCollection": {
					dataValueType: this.Terrasoft.DataValueType.COLLECTION,
					value: this.Ext.create("Terrasoft.BaseViewModelCollection")
				},

				/**
				 * ######### ##### ########.
				 * @private
				 * @type {String}
				 */
				"PhoneNumber": {
					"dataValueType": Terrasoft.DataValueType.TEXT,
					"type": Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"value": ""
				},

				/**
				 * ########## ######## # #### ##### ########. ##########, ##### ######## ########### ##### ############
				 * ############ ######### ######## ###### ########.
				 * @private
				 * @type {String}
				 */
				"PhoneNumberOldValue": {
					"dataValueType": Terrasoft.DataValueType.TEXT,
					"type": Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"value": ""
				},

				/**
				 * ######### ## ####### ####### # ## ############, ## ####### ######### ########
				 * ### ######## ##########.
				 * @private
				 * @type {Object[]}
				 */
				"SubscribedEvents": {
					"value": null
				},

				/**
				 * ######### ######### # ####### ############# ### ######### ##### #########.
				 * #### - ### ########, ######## - ###### ######### #############, ####### ####### ##########.
				 * @private
				 * @type {Object}
				 */
				"IdentificationDataLabels": {
					"dataValueType": Terrasoft.DataValueType.CUSTOM_OBJECT,
					"value": {
						"Contact": ["AccountName", "Job"],
						"Account": ["AccountType", "City"],
						"Employee": ["Department"]
					}
				},

				/**
				 * ########## ################## ######### ######### ######.
				 * @private
				 * @type {Number}
				 */
				"IdentifiedSubscribersCount": {
					"dataValueType": Terrasoft.DataValueType.INTEGER,
					"value": 0
				},

				/**
				 * #### ################### ######## ######### ###### # ######### # ####### ##################
				 * #########.
				 * @private
				 * @type {String}
				 */
				"IdentifiedSubscriberKey": {
					"dataValueType": Terrasoft.DataValueType.TEXT,
					"value": ""
				},

				/**
				 * ########## ################## ######### ################# ######.
				 * @private
				 * @type {Number}
				 */
				"IdentifiedConsultSubscribersCount": {
					"dataValueType": Terrasoft.DataValueType.INTEGER,
					"value": 0
				},

				/**
				 * #### ################### ######## ################# ###### # ######### # ####### ##################
				 * #########.
				 * @private
				 * @type {String}
				 */
				"IdentifiedConsultSubscriberKey": {
					"dataValueType": Terrasoft.DataValueType.TEXT,
					"value": ""
				},

				/**
				 * ###### ############ ############ ######### ######### ###### # ####### mm:ss.
				 * @private
				 * @type {String}
				 */
				"CallDuration": {
					"dataValueType": Terrasoft.DataValueType.TEXT,
					"type": Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"value": null
				},

				/**
				 * ##### ###### #########.
				 * @private
				 * @type {String}
				 */
				"CommutationStartedOn": {
					"dataValueType": Terrasoft.DataValueType.DATE_TIME,
					"type": Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"value": null
				},

				/**
				 * ############# #######.
				 * @private
				 * @type {String}
				 */
				"DurationTimerIntervalId": {
					"dataValueType": Terrasoft.DataValueType.TEXT,
					"type": Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"value": ""
				},

				/**
				 * ###### ############ ############ ######### ################# ###### # ####### mm:ss.
				 * @private
				 * @type {String}
				 */
				"ConsultCallDuration": {
					"dataValueType": Terrasoft.DataValueType.TEXT,
					"type": Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"value": "00:00"
				},

				/**
				 * #### ######### ########## # ###### ########.
				 * @private
				 * @type {Boolean}
				 */
				"IsTransferPrepared": {
					"dataValueType": Terrasoft.DataValueType.BOOLEAN,
					"value": false
				},

				/**
				 * @property {Object} AdvisedIdentifiedSubscriberInfo Information about identified subscriber.
				 * @property {String} AdvisedIdentifiedSubscriberInfo.customerId Record Id of the identified subscriber.
				 * @property {String} AdvisedIdentifiedSubscriberInfo.entitySchemaName Subscriber entity schema name.
				 * @property {String} AdvisedIdentifiedSubscriberInfo.number Subscriber phone number.
				 * @property {Terrasoft.Collection} AdvisedIdentifiedSubscriberInfo.callRelationFields Call relation
				 * fields.
				 * @private
				 */
				"AdvisedIdentifiedSubscriberInfo": {
					"dataValueType": Terrasoft.DataValueType.CUSTOM_OBJECT,
					"type": Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN
				},

				/**
				 * ######### ####### ################## ######### ######### ######.
				 * @private
				 * @type {Terrasoft.Collection}
				 */
				"IdentifiedSubscriberPanelCollection": {
					"dataValueType": Terrasoft.DataValueType.COLLECTION
				},

				/**
				 * ######### ####### ################## ######### ################# ######.
				 * @private
				 * @type {Terrasoft.Collection}
				 */
				"IdentifiedConsultSubscriberPanelCollection": {
					"dataValueType": Terrasoft.DataValueType.COLLECTION
				},

				/**
				 * ######### ####### # ############ ###### ########.
				 * @private
				 * @type {Terrasoft.Collection}
				 */
				"SearchResultPanelCollection": {
					"dataValueType": Terrasoft.DataValueType.COLLECTION
				},

				/**
				 * ######### ####### # ######## #######.
				 * @private
				 * @type {Terrasoft.Collection}
				 */
				"CommunicationHistoryPanelCollection": {
					"dataValueType": Terrasoft.DataValueType.COLLECTION
				},

				/**
				 * #######, ### ##### ######### ######## #
				 * ## ###### #######, ############### ############# ########.
				 * @private
				 * @type {Boolean}
				 */
				"IsSearchFinishedAndResultEmpty": {
					"dataValueType": Terrasoft.DataValueType.BOOLEAN,
					"value": false
				},

				/**
				 * ####### ####, ### ######## #########, ######### # ########## ######, ######.
				 * @private
				 * @type {Boolean}
				 */
				"IsSearchResultPanelCollectionEmpty": {
					"dataValueType": Terrasoft.DataValueType.BOOLEAN,
					"value": true
				},

				/**
				 * ###### ########, ####### #### ########## ##### DTMF #####.
				 * @private
				 * @type {String}
				 */
				"DtmfDigits": {
					"dataValueType": Terrasoft.DataValueType.TEXT,
					"type": Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"value": ""
				},

				/**
				 * #### ######### ########## # ###### DTMF ######.
				 * @private
				 * @type {Boolean}
				 */
				"IsDtmfPrepared": {
					"dataValueType": Terrasoft.DataValueType.BOOLEAN,
					"value": false
				},

				/**
				 * ######### #########.
				 * @private
				 * @type {Object}
				 */
				"CtiSettings": {
					"dataValueType": Terrasoft.DataValueType.Object,
					"value": null
				},

				/**
				 * ############ ## ######### ######### ######## #####.
				 * @private
				 * @type {Boolean}
				 */
				"IsVideoSupported": {
					"dataValueType": Terrasoft.DataValueType.BOOLEAN,
					"value": false
				},

				/**
				 * ##### ## ######### # #####.
				 * @private
				 * @type {Boolean}
				 */
				"IsVideoHidden": {
					"dataValueType": Terrasoft.DataValueType.BOOLEAN,
					"value": false
				},

				/**
				 * #######, ########### ## ############# ########### ######### # ###### #######.
				 * @private
				 * @type {Boolean}
				 */
				"DisplayEmptyHistoryMessage": {
					"dataValueType": Terrasoft.DataValueType.BOOLEAN,
					"value": false
				},

				/**
				 * Schema for call relations. Used for call history relation fields.
				 * @private
				 * @type {Object}
				 */
				"EntityConnectionSchema": {
					"dataValueType": Terrasoft.DataValueType.Object,
					"value": callSchema
				},

				/**
				 * Array of the call relation columns. Used for call history relation fields.
				 * @type {String[]}
				 */
				"EntityConnectionColumnList": {
					dataValueType: this.Terrasoft.DataValueType.CUSTOM_OBJECT
				},

				/**
				 * Sign that indicates is connection to telephony server available.
				 * @private
				 * @type {Boolean}
				 */
				"IsTelephonyAvailable": {
					"dataValueType": Terrasoft.DataValueType.BOOLEAN,
					"value": true
				},

				/**
				 * Sign that indicates is connection to telephony server not available.
				 * @private
				 * @type {Boolean}
				 */
				"IsTelephonyNotAvailable": {
					"dataValueType": Terrasoft.DataValueType.BOOLEAN,
					"value": false
				},

				/**
				 * Sign that indicates if academy message is visible.
				 * @private
				 * @type {Boolean}
				 */
				"IsAcademyMessageVisible": {
					"dataValueType": Terrasoft.DataValueType.BOOLEAN,
					"value": true
				},

				/**
				 * Academy message.
				 * @private
				 * @type {String}
				 */
				"AcademyHelpMessage": {
					"dataValueType": Terrasoft.DataValueType.TEXT,
					"value": ""
				},

				/**
				 * Telephony emulator id.
				 * @private
				 * @type {String}
				 */
				"TelephonyEmulatorId": {
					"dataValueType": Terrasoft.DataValueType.GUID,
					"value": "fa5097af-c625-4e4a-a5f9-7ba0dd594066"
				},

				/**
				 * Search subscribers rows offset.
				 * @private
				 * @type {Number}
				 */
				"SearchSubscribersRowsOffset": {
					"dataValueType": Terrasoft.DataValueType.INTEGER,
					"value": 0
				},

				/**
				 * Sign that indicates CTI panel initialized.
				 * @private
				 * @type {Boolean}
				 */
				"IsCtiPanelInitialized": {
					"dataValueType": Terrasoft.DataValueType.BOOLEAN,
					"value": false
				},

				/**
				 * Sign that indicates CTI provider initialized.
				 * @private
				 * @type {Boolean}
				 */
				"IsCtiProviderInitialized": {
					"dataValueType": Terrasoft.DataValueType.BOOLEAN,
					"value": false
				},

				/**
				 * Sign that indicates CTI communication history initialized.
				 * @private
				 * @type {Boolean}
				 */
				"IsCtiCommunicationHistoryInitialized": {
					"dataValueType": Terrasoft.DataValueType.BOOLEAN,
					"value": false
				}
			},
			properties: {
				abonentInfo: ""
			},
			methods: {

				//region Methods: Private

				/**
				 * Initialize custom event object.
				 * @private
				 */
				_initCustomEvent: function() {
					if (!Terrasoft.isAngularHost) {
						this.mixins.CustomEvent.destroy.call(this);
					}
					this.mixins.CustomEvent.init.call(this);
					this.mixins.CustomEvent.subscribe.call(this, "PhoneLinkClick").subscribe(this.callByNumber.bind(this));
					this.mixins.CustomEvent.subscribe.call(this, "FreedomCtiAction")
						.subscribe((args) => {
							this._handleFreedomCtiAction(args);
						});
				},

				_handleCtiAgentStateChange: function(payload) {
					const isTelephonyEnabled = this.isTelephonyEnabled();
					if (isTelephonyEnabled) {
						if (payload.agentStateReasonCode) {
							this.setAgentState(payload.agentState, payload.agentStateReasonCode);
						} else {
							this.setAgentState(payload.agentState);
						}
					}
				},

				/**
				 * Handles CTI actions sent from freedom UI to CTI model.
				 * @private
				 *  @param {Array} args action parameters. First element of this array is action name,
				 * all following elements are reserved for action-specific parameters.
				 */
				_handleFreedomCtiAction: function(args) {
					var action = args && args[0];
					switch(action) {
						case "HandleCtiAgentStateChange":
							this._handleCtiAgentStateChange(args[1]);
							return;
						case "answer":
							this.answerCall();
							return;
						case "decline":
							this.dropCall();
							return;
						case "toggleHold":
							this.holdOrUnholdCall();
							return;
						case "toggleMute":
							this.onMuteButtonClick();
							return;
						case "start_transfer":
							this.onPrepareTransferButtonClick();
							return;
						case "end_transfer":
							this.transferCall();
							return;
						case "cancel_transfer":
							this.cancelTransfer();
							return;
						case "dtmf":
							var digit = args[1];
							this.sendDtmf(digit);
							return;
						case "make_call":
							var number = args[1];
							this.makeCall(number);
							return;
						case "make_consult_call":
							var number = args[1];
							this.makeConsultCall(number);
							return;
						case "blind_transfer":
							var number = args[1];
							this.blindTransferCall(number);
							return;
						case "get_cti_state":
							const ctiStateInfos = [];
							const subscribersCollection = this.get('IdentifiedSubscriberPanelCollection')?.getItems().map(s => s.values);
							const consultSubscribersCollection = this.get('IdentifiedConsultSubscriberPanelCollection').getItems().map(s => s.values);
							const consultCall = this.findConsultCall();
							Terrasoft.each(this.activeCalls, function(call) {
								const ctiStateInfo = call.getCtiStateInfo();
								ctiStateInfo.commutationStartedOn = call.commutationStartedOn;
								ctiStateInfo.subscribers = consultCall?.id === call.id ? consultSubscribersCollection : subscribersCollection;
								ctiStateInfo.dtmfInput = consultCall?.id !== call.id ? this.get('DtmfDigits') : null;
  								ctiStateInfos.push(ctiStateInfo);
							}.bind(this));
							const settings = this.get("CtiSettings");
							this.proxyEventArguments("ctiState", [ctiStateInfos, settings]);
							return;
						case "update_call_identity":
							var callId = args[1];
							var subsciberId = args[2];
							if (subsciberId) {
								this.setIdentifiedSubscriberForCall(callId, subsciberId);
							} else {
								this.clearSubscriberForCall(callId);
							}
							return;
						case "apply_call_identity_changes": 
							var callId = args[1];
							var subscriberId = args[2];
							var subscriberData = args[3];
							if(!this.activeCalls.find(callId)) {
								return;
							}
							//Required to trigger subscriber key change if identity data was modified.
							var key = this.getIdentifiedSubscriberKeyForCall(callId);
							if(this.get(key) === subscriberId) {
								this.set(key, null, { silent: true });
							}
							if(subscriberData) {
								this.addSubscriberToCollection(callId, subscriberData);
							}
							if(subscriberId) {
								this.setIdentifiedSubscriberForCall(callId, subscriberId, { dataSaved: true });
							}
							else {
								this.clearSubscriberForCall(callId, { dataSaved: true } );
							}
							return;
					}
				},

				/**
				 * Sends message for select CTI tab in 8x right panel.
				 * @private
				 */
				_sendSelectTabEvent: function() {
					this.mixins.CustomEvent.publish.call(this, 'RightPanelSetSelectedTabEvent', {
						tabName: "CtiTab",
						panelName: 'CommunicationPanel'
					});
				},

				/**
				 * Loads next subscribers page.
				 */
				onLoadNext: function() {
					this.$SearchSubscribersRowsOffset += ctiConstants.IdentificationMaxRowCount;
					this.updateSearchResults(true);
				},

				/**
				 * ############## cti-######, ####### #######.
				 */
				constructor: function() {
					this.callParent(arguments);
					this.addEvents(
						/**
						 * @event subscriberIdentified
						 * ###########, ##### ####### ### ###############.
						 * @param {String} callId ############# ######.
						 * @param {Object} [data] ########## ## ########. #### ########## # ###### ## ######## #######,
						 * ## null.
						 * @param {String} data.Id ############# ########.
						 * @param {String} data.Name ###.
						 * @param {String} data.Number #####.
						 * @param {CtiConstants.SubscriberTypes} data.Type ### ########.
						 * @param {String} data.AccountName ######## ###########.
						 * @param {String} data.AccountType ### ###########.
						 * @param {String} data.City ##### ###########.
						 * @param {String} data.CommunicationType ######## #### ######## #####.
						 * @param {String} data.Department #####.
						 * @param {String} data.Job #########.
						 * @param {String} data.Photo ###########.
						 */
						"subscriberIdentified",

						/**
						 * @event callIdentificationSaved
						 * ########### ##### ########## # #### ###### ############# ######## ######.
						 * @param {String} callId ############# ######.
						 * @param {Terrasoft.Collection} data ################# ###### ######.
						 * ##. {@link Terrasoft.integration.telephony.Call#identificationFieldsData}
						 * @param {String} [error] ###### ########## ######.
						 */
						"callIdentificationSaved"
					);
				},

				/**
				 * ####### ######### ## ###### # #######.
				 * @private
				 * @param {Object} message #########.
				 */
				logError: function(message) {
					var console = Ext.global.console;
					if (console && console.error) {
						console.error(message);
					}
				},

				/**
				 * ####### ############## ######### # #######.
				 * @private
				 * @param {Object} message #########.
				 */
				logInfo: function(message) {
					var console = Ext.global.console;
					if (console && console.info) {
						console.info(message);
					}
				},

				/**
				 * @private
				 * @returns {Object} Current call changed event data.
				 */
				_getCurrentCallChangedEventData: function() {
					return {
						caller: this.abonentInfo,
						communicationStartedOn: this.get("CommutationStartedOn")
					};
				},

				/**
				 * @param eventData
				 * @private
				 */
				_sendCurrentCallChangedEvent: function(eventData) {
					this.mixins.CustomEvent.publish.call(this, 'CurrentCallChanged', eventData);
				},

				//endregion

				//region Methods: Protected

				/**
				 * Initializes schemes of collection.
				 * @protected
				 */
				initCollections: function() {
					this.set({
						SearchResultPanelCollection: this.Ext.create("Terrasoft.BaseViewModelCollection"),
						IdentifiedSubscriberPanelCollection: this.Ext.create("Terrasoft.BaseViewModelCollection"),
						IdentifiedConsultSubscriberPanelCollection: this.Ext.create("Terrasoft.BaseViewModelCollection")
					});
					this.initCallHistoryCollection();
				},

				/**
				 * ############## ######### ####### ####### # ######### ######## ## ## #########.
				 * @protected
				 */
				initCallHistoryCollection: function() {
					let collection = this.get("CommunicationHistoryPanelCollection");
					if(!collection) {
						collection = this.Ext.create("Terrasoft.Collection");
						collection.on("add", this.onCallHistoryChanged, this);
						collection.on("dataLoaded", this.onCallHistoryChanged, this);
						collection.on("remove", this.onCallHistoryChanged, this);
						collection.on("clear", this.onCallHistoryChanged, this);
						this.set("CommunicationHistoryPanelCollection", collection);
					}
				},


				/**
				 * Initializes call relation history view configuration.
				 * @protected
				 * @param {Array|*} [viewConfigItems] View configuration items.
				 * @param {Array|*} [parentContainerItems] Parent container view configuration items.
				 */
				initCallRelationHistoryViewConfig: function(viewConfigItems, parentContainerItems) {
					if (viewConfigItems) {
						this.createEntityConnectionPanelConfig(viewConfigItems);
						var linkIcons = viewConfigItems.filter(function(item) {
							return item.markerValue == "EntityLinkedIconsContainer";
						});
						if (this.isNotEmpty(linkIcons)) {
							var linkIcons = linkIcons[0];
							parentContainerItems.push(Ext.apply(linkIcons, {
								"visible": {
									"bindTo": "IsCallConnectionsVisible",
									"bindConfig": {"converter": "invertBooleanValue"}
								}
							}));
							Ext.Array.remove(viewConfigItems, linkIcons);
						}
					}
					this.initialize();
				},

				/**
				 * Processes change of calls history.
				 * @protected
				 */
				onCallHistoryChanged: function() {
					var collection = this.get("CommunicationHistoryPanelCollection");
					this.set("DisplayEmptyHistoryMessage", collection.isEmpty());
				},

				/**
				 * Initializes cti settings, cti provider, cti model and load communication history.
				 * @protected
				 */
				initialize: function() {
					CtiBaseHelper.queryCtiSettings(function(ctiSettings) {
						this.set("CtiSettings", ctiSettings);
						this.loadAgentStatesMenu();
						CtiProviderInitializer.initializeCtiProvider(ctiSettings.ctiProviderName,
							this.initializeCtiModel.bind(this));
						this.loadCommunicationHistory(() => {
							this.set("IsCtiCommunicationHistoryInitialized", true);
							this.hideBodyMaskInternal();
						});
					}.bind(this));
				},

				/**
				 * Initializes Cti model.
				 * @param {Terrasoft.BaseCtiProvider} provider Telephony functions provider.
				 * @protected
				 */
				initializeCtiModel: function(provider) {
					this.ctiProvider = provider;
					this.createConnection();
				},

				/**
				 * Creates connection to telephony.
				 * @protected
				 */
				createConnection: function() {
					this.subscribeEvents();
					if (this.ctiProvider.serviceChannel?.isOpened) {
						this.set("IsCtiProviderInitialized", true);
						this.set("IsCtiPanelInitialized", true);
						this.hideBodyMaskInternal();
						this.ctiProvider.on("initialized", this.onCtiProviderInitialized, this);
						this.ctiProvider.on("disconnected", this.onCtiProviderInitialized, this);
					} else {
						this.connect(null, function(success, error) {
							this.set("IsCtiPanelInitialized", true);
							this.hideBodyMaskInternal();
							this.ctiProvider.on("initialized", this.onCtiProviderInitialized, this);
							this.ctiProvider.on("disconnected", this.onCtiProviderInitialized, this);
							if (error) {
								this.onConnectError(error);
							}
							this.mixins.CustomEvent.publish.call(this, "CTIPanelInitialized", this.isTelephonyEnabled());
						}.bind(this));
					}
				},

				/**
				 * Event when indicating CTI provider initialization.
				 */
				onCtiProviderInitialized: function() {
					this.set("IsCtiProviderInitialized", true);
					this.mixins.CustomEvent.publish.call(this, "CTIPanelInitialized", this.isTelephonyEnabled());
					this.hideBodyMaskInternal();
				},

				/**
				 * Hide CTI mask configuration.
				 */
				hideBodyMaskInternal: function() {
					if (this.get("IsCtiPanelInitialized") && this.get("IsCtiProviderInitialized")
							&& this.get("IsCtiCommunicationHistoryInitialized")) {
						this.hideBodyMask(this.getMaskConfig());
					}
				},

				/**
				 * Show CTI mask configuration.
				 */
				showBodyMaskInternal: function() {
					if(Ext.isElement(this.getMaskConfig().selector)) {
						this.showBodyMask(this.getMaskConfig());
					}
				},

				/**
				 * Gets CTI mask configuration.
				 * @returns {{selector: (string), timeout: number}} CTI mask configuration.
				 */
				getMaskConfig: function() {
					return {
						"timeout": 0,
						"selector": Terrasoft.isAngularHost
							? ".communications-panel-items-tab-panel"
							: ".right-panel-modules-container"
					}
				},

				/**
				 * Subscribes to Cti model events.
				 * @protected
				 */
				subscribeEvents: function() {
					var ctiPanelEvents = [
						{
							eventName: "connected",
							eventHandler: this.onConnected
						},
						{
							eventName: "disconnected",
							eventHandler: this.onDisconnected
						},
						{
							eventName: "callStarted",
							eventHandler: this.onCallStarted
						},
						{
							eventName: "commutationStarted",
							eventHandler: this.onCommutationStarted
						},
						{
							eventName: "change:CurrentCallNumber",
							eventHandler: this.onChangeCurrentCallNumber
						},
						{
							eventName: "change:CurrentCall",
							eventHandler: this.onChangeCurrentCall
						},
						{
							eventName: "change:CallDuration",
							eventHandler: this.onChangeCallDuration
						},
						{
							eventName: "change:ConsultCallNumber",
							eventHandler: this.onChangeConsultCallNumber
						},
						{
							eventName: "change:AgentState",
							eventHandler: this.onAgentStateCodeChanged
						},
						{
							eventName: "change:IdentifiedSubscriberKey",
							eventHandler: this.onIdentifiedSubscriberKeyChanged
						},
						{
							eventName: "change:IdentifiedConsultSubscriberKey",
							eventHandler: this.onIdentifiedConsultSubscriberKeyChanged
						},
						{
							eventName: "callSaved",
							eventHandler: this.onCallSavedEvent
						},
						{
							eventName: "dtmfEntered",
							eventHandler: this.onDtmfEntered
						},
						{
							eventName: "webRtcStarted",
							eventHandler: this.onWebRtcStarted
						},
						{
							eventName: "webRtcVideoStarted",
							eventHandler: this.onWebRtcVideoStarted
						},
						{
							eventName: "webRtcDestroyed",
							eventHandler: this.onWebRtcDestroyed
						},
						{
							eventName: "change:IsVideoHidden",
							eventHandler: this.onVideoHidden
						},
						{
							eventName: "subscriberIdentified",
							eventHandler: this.onSubscriberIdentified
						}
					];
					Terrasoft.each(ctiPanelEvents, function(item) {
						this.on(item.eventName, item.eventHandler, this);
					}, this);
					this.set("SubscribedEvents", ctiPanelEvents);
					this.sandbox.subscribe("CallCustomer", this.onCallCustomer.bind(this));
					this.sandbox.subscribe("GetCallRecords", this.onGetCallRecords.bind(this),
						[ctiConstants.CallRecordsContextMessageId]);
					var activeCalls = this.activeCalls;
					activeCalls.on("add", this.onCtiPanelActiveCallAdded, this);
					activeCalls.on("clear", this.onCtiPanelActiveCallsEmpty, this);
					activeCalls.on("remove", this.onCtiPanelActiveCallRemoved, this);
				},

				/**
				 * @inheritdoc Terrasoft.CtiModel#commutationStarted
				 * @private
				 */
				onCallStarted: function(call) {
					this._sendSelectTabEvent();
					this.abonentInfo = this.abonentInfo || call.getAbonentNumber();
					this._sendCurrentCallChangedEvent(this._getCurrentCallChangedEventData());
				},

				/**
				 * ############ ###### ### ########### # #########.
				 * @protected
				 * @param {Object} error ###### ######.
				 * @param {Terrasoft.MsgErrorType} error.errorType ### ######.
				 * @param {String} error.internalErrorCode ### ######.
				 * @param {String} error.data ##### ######.
				 * @param {String} error.source ######## ######.
				 */
				onConnectError: function(error) {
					if (error.errorType === Terrasoft.MsgErrorType.CONNECTION_CONFIG_ERROR) {
						this.logError(this.get("Resources.Strings.ConnectionConfigEmptyError"));
					}
				},

				/**
				 * ########## ############# ###### ######### # ###### ####### #######.
				 * @return {Boolean} #### ####### ####### ############ # ### ######, ## true.
				 * @protected
				 */
				isEmptyCallHistoryMessageVisible: function() {
					return this.getIsCommunicationHistoryVisible() && this.get("DisplayEmptyHistoryMessage");
				},

				/**
				 * Returns academy message visibility.
				 * @return {boolean}
				 * @protected
				 */
				getIsAcademyMessageVisible: function() {
					var isNotEmptyCollection = !this.get("DisplayEmptyHistoryMessage");
					var IsDefaultTelephony = this.get("IsDefaultTelephony");
					var isAcademyMessageVisible = this.get("IsAcademyMessageVisible");
					return !this.getIsCallExists() && IsDefaultTelephony && isNotEmptyCollection &&
						isAcademyMessageVisible && !this.getIsEmptySearchResultContainerVisible();
				},

				/**
				 * Checks if current connector is Telephony emulator.
				 * @protected
				 * @param {Function} callback Callback function.
				 * @param {Object} scope Callback function scope.
				 */
				initIsDefaultTelephony: function(callback, scope) {
					Terrasoft.SysSettings.querySysSettings(["SysMsgLib"], function(sysSettings) {
						var IsDefaultTelephony = sysSettings.SysMsgLib.value.toLowerCase() === this.get("TelephonyEmulatorId");
						this.set("IsDefaultTelephony", IsDefaultTelephony);
						Ext.callback(callback, scope);
					}, this);
				},

				/**
				 * Hides academy message if cti panel is scrollable.
				 * @protected
				 */
				setAcademyMessageVisibility: function() {
					var ctiPanelWrapper = Ext.get(this.renderTo);
					if (ctiPanelWrapper && (ctiPanelWrapper.dom.scrollHeight > ctiPanelWrapper.dom.clientHeight)) {
						this.set("IsAcademyMessageVisible", false);
					} else {
						this.set("IsAcademyMessageVisible", true);
					}
				},

				/**
				 * Forms academy message content.
				 * @return {string}
				 * @protected
				 */
				getHelpUrl: function() {
					var callback = function(helpUrl) {
						var startTagPart = "";
						var endTagPart = "";
						var description = this.get("Resources.Strings.EmptyHistoryMessage");
						if (!this.Ext.isEmpty(helpUrl)) {
							startTagPart = "<a target=\"_blank\" href=\"" + helpUrl + "\">";
							endTagPart = "</a>";
						}
						description = this.Ext.String.format(description, startTagPart, endTagPart);
						this.set("AcademyHelpMessage", description);
					}.bind(this);
					var config = {
						callback: callback,
						scope: this,
						contextHelpId: 1024,
						contextHelpCode: "CallPageV2"
					};
					AcademyUtilities.getUrl(config);
				},

				/**
				 * Returns main subscriber button additional styles.
				 * @protected
				 * @return {Object}
				 */
				 getMainSubscriberNameButtonStyle: function() {
					var subscriberPanel = this.getIdentifiedSubscriberPanel("IdentifiedSubscriberPanelCollection", "IdentifiedSubscriberKey");
					return this.getSubscriberNameButtonStyle(subscriberPanel);
				},

				/**
				 * Returns consult subscriber button additional styles.
				 * @protected
				 * @return {Object}
				 */
				 getConsultSubscriberNameButtonStyle: function() {
					var subscriberPanel = this.getIdentifiedSubscriberPanel("IdentifiedConsultSubscriberPanelCollection", "IdentifiedConsultSubscriberKey");
					return this.getSubscriberNameButtonStyle(subscriberPanel);
				},


				/**
				 * Returns subscriber button additional styles.
				 * @protected
				 * @param {Object} subscriberPanel Subscriber panel.
				 * @return {Object} Additional styles.
				 */
				getSubscriberNameButtonStyle: function(subscriberPanel) {
					if (!subscriberPanel) {
						return;
					}
					var schemaName = this.getEntitySchemaNameBySubscriberType(subscriberPanel.get("Type"));
					if (!this.hasEntityEditPage(schemaName)) {
						return {
							"style": {
								"color": "#444",
								cursor: "auto"
							}
						};
					}
				},

				generateAgentStateMenuItems: function(agentStates, callback) {
					var menuCollection = this.get("OperatorStatusMenuCollection");
					menuCollection.clear();
					this.generateAgentStateMenuItemsInternal(agentStates, menuCollection);
					Ext.callback(callback, this);
				},

				onSettingsButtonClick: function() {
					var callCentreParametersModule = "SetupTelephonyParametersPageModule";
					this.sandbox.publish("PushHistoryState", {hash: callCentreParametersModule});
				},

				//endregion

				//region Methods: Public

				/**
				 * Initializes the schema.
				 */
				init: function(callback, scope) {
					Terrasoft.CallDirection = Ext.merge(Terrasoft.CallDirection,
						Terrasoft.integration.telephony.enums.CallDirection);
					if (Terrasoft.isCurrentUserSsp()) {
						Ext.callback(callback, scope);
						return;
					}
					this.showBodyMaskInternal();
					this.callParent([function() {
						this.initIsDefaultTelephony(callback, scope);
					}, this]);
					if (this.get("Restored") !== true) {
						this.initCollections();
						this._initCustomEvent();
						Terrasoft.chain(
							this.generateIdentifiedSubscriberPanelItemConfig,
							this.generateCommunicationPanelItemConfig,
							this.generateSearchResultPanelItemConfig,
							this.loadEntityConnectionColumns,
							function(next) {
								this.generateCommunicationHistoryItemPanelItemConfig(
									this.initCallRelationHistoryViewConfig.bind(this));
								next();
							},
							this
						);
					} else {
						this.hideBodyMaskInternal();
					}
					this.on("destroyed", this.onDestroyed);
					this.initHelpUrl("CallPageV2", 1024);
					this.getHelpUrl();
					this.emptyMessageConfig = {
						title: this.get("Resources.Strings.EmptyHistoryTitleLabel"),
						description: this.get("Resources.Strings.EmptyHistoryMessage"),
						image: this.get("Resources.Images.EmptySearchResultImage")
					};
				},

				/**
				 * ######### ####### ########### #####.
				 * Schema destroying event handler.
				 */
				onDestroyed: function() {
					var ctiPanelEvents = this.get("SubscribedEvents");
					Terrasoft.each(ctiPanelEvents, function(item) {
						this.un(item.eventName, item.eventHandler, this);
					}, this);
					this.set("SubscribedEvents", "");
					var activeCalls = this.activeCalls;
					activeCalls.un("add", this.onCtiPanelActiveCallAdded, this);
					activeCalls.un("clear", this.onCtiPanelActiveCallsEmpty, this);
					activeCalls.un("remove", this.onCtiPanelActiveCallRemoved, this);
					var collection = this.get("CommunicationHistoryPanelCollection");
					collection.un("add", this.onCallHistoryChanged, this);
					collection.un("dataLoaded", this.onCallHistoryChanged, this);
					collection.un("clear", this.onCallHistoryChanged, this);
					collection.un("remove", this.onCallHistoryChanged, this);
				},

				onCommutationStarted: function(call) {
					this.mixins.CtiPanelModelUtilities.onCommutationStarted.call(this, call);
					this.abonentInfo = this.abonentInfo || call.getAbonentNumber();
					this._sendCurrentCallChangedEvent(this._getCurrentCallChangedEventData());
				},

				onCtiPanelActiveCallRemoved: function(call) {
					this.mixins.CtiPanelModelUtilities.onCtiPanelActiveCallRemoved.call(this, call);
					this._sendCurrentCallChangedEvent(null);
					if (this.activeCalls.getCount() === 0 || !this.get("IdentifiedConsultSubscriberKeyOldValue")) {
						this.abonentInfo = null;
					}
				},

				afterSubscriberIdentified: function(subscriberInfo) {
					if (subscriberInfo?.Name) {
						this.abonentInfo = subscriberInfo?.Name;
					}
					this._sendCurrentCallChangedEvent(this._getCurrentCallChangedEventData());
				}

				//endregion

			},
			diff: [
				{
					"operation": "insert",
					"name": "ctiPanelHeaderContainer",
					"values": {
						"itemType": Terrasoft.ViewItemType.CONTAINER,
						"items": [],
						"wrapClass": ["ctiPanelHeader"],
					}
				},
				{
					"operation": "insert",
					"name": "OperatorStatusButton",
					"parentName": "ctiPanelHeaderContainer",
					"propertyName": "items",
					"index": 0,
					"values": {
						"itemType": Terrasoft.ViewItemType.BUTTON,
						"classes": {
							"wrapperClass": ["settings-button","operator-status-button-wrapper"],
						},
						"controlConfig": {
							"style": Terrasoft.controls.ButtonEnums.style.TRANSPARENT,
							"iconAlign": Terrasoft.controls.ButtonEnums.iconAlign.LEFT,
							"imageConfig": {
								"bindTo": "AgentState",
								"bindConfig": { "converter": "getProfileMenuStatusIcon"}
							},
							"caption": {
								"bindTo": "AgentState",
								"bindConfig": { "converter": "getAgentStateDisplayValue"}
							},
							"menu": {
								"items": {
									"bindTo": "OperatorStatusMenuCollection"
								},
								"ulClass": "operator-status-menu"
							}
						},
						"markerValue": "OperatorStatusButton"
					}
				},
				{
					"operation": "insert",
					"index": 1,
					"name": "SettingsButton",
					"parentName": "ctiPanelHeaderContainer",
					"propertyName": "items",
					"values": {
						"click": {"bindTo": "onSettingsButtonClick"},
						"classes": {"wrapperClass": ["settings-button", "cti-settings-btn-wrapper"]},
						"itemType": Terrasoft.ViewItemType.BUTTON,
						"imageConfig": {"bindTo": "Resources.Images.SettingsButtonIcon"},
						"style": Terrasoft.controls.ButtonEnums.style.TRANSPARENT,
						"markerValue": "SettingsButton",
						"hint": {"bindTo": "Resources.Strings.SettingsButtonHint"},
					}
				},
				{
					"operation": "insert",
					"name": "ctiPanelMainContainer",
					"values": {
						"id": "ctiPanelMainContainer",
						"selectors": {"wrapEl": "#ctiPanelMainContainer"},
						"itemType": Terrasoft.ViewItemType.CONTAINER,
						"wrapClass": ["ctiPanelMain"],
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "ctiPanelVideoContainer",
					"parentName": "ctiPanelMainContainer",
					"propertyName": "items",
					"index": 0,
					"values": {
						"id": "ctiPanelVideoContainer",
						"selectors": {"wrapEl": "#ctiPanelVideoContainer"},
						"itemType": Terrasoft.ViewItemType.CONTAINER,
						"wrapClass": ["ctiPanelVideo"],
						"items": []
					}
				},

				//region current call identification controls

				{
					"operation": "insert",
					"name": "IdentificationPanel",
					"parentName": "ctiPanelMainContainer",
					"index": 1,
					"propertyName": "items",
					"values": {
						"id": "IdentificationPanel",
						"markerValue": {"bindTo": "CurrentCallNumber"},
						"selectors": {"wrapEl": "#IdentificationPanel"},
						"itemType": Terrasoft.ViewItemType.CONTAINER,
						"wrapClass": ["identification-panel"],
						"visible": {"bindTo": "getIsCallExists"},
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "IdentificationPanelLeft",
					"parentName": "IdentificationPanel",
					"propertyName": "items",
					"values": {
						"id": "IdentificationPanelLeft",
						"selectors": {"wrapEl": "#IdentificationPanelLeft"},
						"itemType": Terrasoft.ViewItemType.CONTAINER,
						"wrapClass": ["identification-panel-left"],
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "IdentificationPanelRight",
					"parentName": "IdentificationPanel",
					"propertyName": "items",
					"values": {
						"id": "IdentificationPanelRight",
						"selectors": {"wrapEl": "#IdentificationPanelRight"},
						"itemType": Terrasoft.ViewItemType.CONTAINER,
						"wrapClass": ["identification-panel-right"],
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "IdentificationDataPanel",
					"parentName": "IdentificationPanelRight",
					"propertyName": "items",
					"values": {
						"id": "IdentificationDataPanel",
						"selectors": {"wrapEl": "#IdentificationDataPanel"},
						"itemType": Terrasoft.ViewItemType.CONTAINER,
						"wrapClass": ["identification-data-panel"],
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "SubscriberPhoto",
					"parentName": "IdentificationPanelLeft",
					"propertyName": "items",
					"values": {
						"id": "SubscriberPhoto",
						"itemType": Terrasoft.ViewItemType.BUTTON,
						"imageConfig": {"bindTo": "getSubscriberPhoto"},
						"classes": {"wrapperClass": ["subscriber-photo"]},
						"markerValue": "SubscriberPhoto",
						"selectors": {"wrapEl": "#SubscriberPhoto"},
						"style": Terrasoft.controls.ButtonEnums.style.TRANSPARENT,
						"tag": "Photo"
					}
				},
				{
					"operation": "insert",
					"name": "TransferringArrows",
					"parentName": "IdentificationPanelLeft",
					"propertyName": "items",
					"values": {
						"id": "TransferringArrows",
						"itemType": Terrasoft.ViewItemType.BUTTON,
						"imageConfig": {"bindTo": "Resources.Images.TransferringArrows"},
						"classes": {"wrapperClass": ["transferring-arrows"]},
						"markerValue": "TransferringArrows",
						"selectors": {"wrapEl": "#TransferringArrows"},
						"style": Terrasoft.controls.ButtonEnums.style.TRANSPARENT,
						"visible": {"bindTo": "IsConsulting"}
					}
				},
				{
					"operation": "insert",
					"name": "PrimaryCallInfo",
					"parentName": "IdentificationPanelRight",
					"propertyName": "items",
					"values": {
						"id": "PrimaryCallInfo",
						"itemType": Terrasoft.ViewItemType.LABEL,
						"caption": {"bindTo": "CurrentCallNumber"},
						"markerValue": "PrimaryCallInfo",
						"classes": {"labelClass": "primary-call-info"},
						"visible": {"bindTo": "getIsSubscriberUnknown"}
					}
				},

				{
					"operation": "insert",
					"name": "SubscriberName",
					"parentName": "IdentificationDataPanel",
					"propertyName": "items",
					"values": {
						"id": "SubscriberName",
						"markerValue": {"bindTo": "getSubscriberData"},
						"itemType": Terrasoft.ViewItemType.BUTTON,
						"caption": {"bindTo": "getSubscriberData"},
						"hint": {"bindTo": "getSubscriberData"},
						"tag": "Name",
						"visible": {
							"bindTo": "IdentifiedSubscriberKey",
							"bindConfig": {"converter": "getIsSubscriberIdentified"}
						},
						"click": {"bindTo": "onSubscriberNameClick"},
						"classes": {"wrapperClass": ["subsciber-menu-button"]},
						"style": Terrasoft.controls.ButtonEnums.style.TRANSPARENT,
						"domAttributes": {
							"bindTo": "getMainSubscriberNameButtonStyle"
						},
						"menu": {
							"items": [
								{
									"id": "SelectAnotherSubscriberMenuItem",
									"caption": {"bindTo": "Resources.Strings.SelectAnotherSubscriberCaption"},
									"markerValue": "SelectAnotherSubscriberMenuItem",
									"click": {"bindTo": "clearSubscriber"}
								}
							]
						}
					}
				},
				{
					"operation": "insert",
					"name": "SubscriberNumberInfo",
					"parentName": "IdentificationPanelRight",
					"propertyName": "items",
					"values": {
						"id": "SubscriberNumberInfo",
						"selectors": {"wrapEl": "#SubscriberNumberInfo"},
						"itemType": Terrasoft.ViewItemType.CONTAINER,
						"markerValue": "SubscriberNumberInfo",
						"visible": {"bindTo": "getIsCommunicationTypeKnown"},
						"items": [
							{
								"id": "CommunicationTypeLabel",
								"itemType": Terrasoft.ViewItemType.LABEL,
								"classes": {"labelClass": ["label-caption"]},
								"markerValue": {"bindTo": "getSubscriberData"},
								"selectors": {"wrapEl": "#CommunicationTypeLabel"},
								"caption": {"bindTo": "getSubscriberData"},
								"tag": "CommunicationType"
							},
							{
								"id": "CallNumber",
								"itemType": Terrasoft.ViewItemType.LABEL,
								"classes": {"labelClass": ["subscriber-info"]},
								"markerValue": {"bindTo": "getSubscriberData"},
								"selectors": {"wrapEl": "#CallNumber"},
								"caption": {"bindTo": "getSubscriberData"},
								"tag": "Number"
							}
						]
					}
				},
				{
					"operation": "insert",
					"name": "AccountName",
					"parentName": "IdentificationDataPanel",
					"propertyName": "items",
					"values": {
						"generator": "CtiBaseHelper.getIdentificationDataLabel"
					}
				},
				{
					"operation": "insert",
					"name": "SubscriberJob",
					"parentName": "IdentificationDataPanel",
					"propertyName": "items",
					"values": {
						"tag": "Job",
						"generator": "CtiBaseHelper.getIdentificationDataLabel"
					}
				},
				{
					"operation": "insert",
					"name": "SubscriberDepartment",
					"parentName": "IdentificationDataPanel",
					"propertyName": "items",
					"values": {
						"tag": "Department",
						"generator": "CtiBaseHelper.getIdentificationDataLabel"
					}
				},
				{
					"operation": "insert",
					"name": "AccountType",
					"parentName": "IdentificationDataPanel",
					"propertyName": "items",
					"values": {
						"generator": "CtiBaseHelper.getIdentificationDataLabel"
					}
				},
				{
					"operation": "insert",
					"name": "AccountCity",
					"parentName": "IdentificationDataPanel",
					"propertyName": "items",
					"values": {
						"tag": "City",
						"generator": "CtiBaseHelper.getIdentificationDataLabel"
					}
				},
				{
					"operation": "insert",
					"name": "CallDurationInfo",
					"parentName": "IdentificationPanelRight",
					"propertyName": "items",
					"values": {
						"id": "CallDurationInfo",
						"selectors": {"wrapEl": "#CallDurationInfo"},
						"itemType": Terrasoft.ViewItemType.CONTAINER,
						"visible": {"bindTo": "getIsCallDurationVisible"},
						"classes": {
							wrapClassName: ["call-duration-container"]
						},
						"items": [
							{
								"id": "CallDurationLabel",
								"itemType": Terrasoft.ViewItemType.LABEL,
								"classes": {"labelClass": ["label-caption"]},
								"markerValue": "CallDurationLabel",
								"selectors": {"wrapEl": "#CallDurationLabel"},
								"caption": {"bindTo": "Resources.Strings.CallDurationLabelCaption"}
							},
							{
								"id": "CallDuration",
								"itemType": Terrasoft.ViewItemType.LABEL,
								"classes": {"labelClass": ["call-duration"]},
								"markerValue": "CallDuration",
								"selectors": {"wrapEl": "#CallDuration"},
								"caption": {"bindTo": "CallDuration"}
							}
						]
					}
				},
				{
					"operation": "insert",
					"name": "AdditionalSubscriberInfoContainer",
					"parentName": "IdentificationPanelRight",
					"propertyName": "items",
					"values": {
						"id": "AdditionalSubscriberInfoContainer",
						"selectors": {"wrapEl": "#AdditionalSubscriberInfoContainer"},
						"itemType": Terrasoft.ViewItemType.CONTAINER,
						"visible": {"bindTo": "getIsAdditionalSubscriberInfoContainerVisible"},
						"classes": {
							wrapClassName: ["additional-subscriber-info-container"]
						},
						"items": []
					}
				},

				//endregion

				//region consult call identification controls

				{
					"operation": "insert",
					"name": "ConsultIdentificationPanel",
					"parentName": "ctiPanelMainContainer",
					"index": 2,
					"propertyName": "items",
					"values": {
						"id": "ConsultIdentificationPanel",
						"markerValue": {"bindTo": "ConsultCallNumber"},
						"selectors": {"wrapEl": "#ConsultIdentificationPanel"},
						"itemType": Terrasoft.ViewItemType.CONTAINER,
						"wrapClass": ["identification-panel", "consult-identification-panel"],
						"visible": {"bindTo": "IsConsulting"},
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "ConsultIdentificationPanelLeft",
					"parentName": "ConsultIdentificationPanel",
					"propertyName": "items",
					"values": {
						"id": "ConsultIdentificationPanelLeft",
						"selectors": {"wrapEl": "#ConsultIdentificationPanelLeft"},
						"itemType": Terrasoft.ViewItemType.CONTAINER,
						"wrapClass": ["identification-panel-left"],
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "ConsultIdentificationPanelRight",
					"parentName": "ConsultIdentificationPanel",
					"propertyName": "items",
					"values": {
						"id": "ConsultIdentificationPanelRight",
						"selectors": {"wrapEl": "#ConsultIdentificationPanelRight"},
						"itemType": Terrasoft.ViewItemType.CONTAINER,
						"wrapClass": ["identification-panel-right"],
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "ConsultIdentificationDataPanel",
					"parentName": "ConsultIdentificationPanelRight",
					"propertyName": "items",
					"values": {
						"id": "ConsultIdentificationDataPanel",
						"selectors": {"wrapEl": "#ConsultIdentificationDataPanel"},
						"itemType": Terrasoft.ViewItemType.CONTAINER,
						"wrapClass": ["identification-data-panel"],
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "ConsultSubscriberPhoto",
					"parentName": "ConsultIdentificationPanelLeft",
					"propertyName": "items",
					"values": {
						"id": "ConsultSubscriberPhoto",
						"itemType": Terrasoft.ViewItemType.BUTTON,
						"imageConfig": {"bindTo": "getConsultSubscriberPhoto"},
						"classes": {"wrapperClass": ["subscriber-photo"]},
						"markerValue": "ConsultSubscriberPhoto",
						"selectors": {"wrapEl": "#ConsultSubscriberPhoto"},
						"style": Terrasoft.controls.ButtonEnums.style.TRANSPARENT,
						"tag": "Photo"
					}
				},
				{
					"operation": "insert",
					"name": "ConsultCallInfo",
					"parentName": "ConsultIdentificationPanelRight",
					"propertyName": "items",
					"values": {
						"id": "ConsultCallInfo",
						"itemType": Terrasoft.ViewItemType.LABEL,
						"caption": {"bindTo": "ConsultCallNumber"},
						"markerValue": "ConsultCallInfo",
						"classes": {"labelClass": "primary-call-info"},
						"visible": {"bindTo": "getIsConsultSubscriberUnknown"}
					}
				},
				{
					"operation": "insert",
					"name": "ConsultSubscriberName",
					"parentName": "ConsultIdentificationDataPanel",
					"propertyName": "items",
					"values": {
						"id": "ConsultSubscriberName",
						"markerValue": {"bindTo": "getConsultSubscriberData"},
						"itemType": Terrasoft.ViewItemType.BUTTON,
						"caption": {"bindTo": "getConsultSubscriberData"},
						"hint": {"bindTo": "getConsultSubscriberData"},
						"tag": "Name",
						"visible": {
							"bindTo": "IdentifiedConsultSubscriberKey",
							"bindConfig": {"converter": "getIsSubscriberIdentified"}
						},
						"click": {"bindTo": "onConsultSubscriberNameClick"},
						"classes": {"wrapperClass": ["subsciber-menu-button"]},
						"style": Terrasoft.controls.ButtonEnums.style.TRANSPARENT,
						"domAttributes": {
							"bindTo": "getConsultSubscriberNameButtonStyle"
						},
						"menu": {
							"items": [
								{
									"id": "SelectAnotherConsultSubscriberMenuItem",
									"caption": {"bindTo": "Resources.Strings.SelectAnotherSubscriberCaption"},
									"markerValue": "SelectAnotherConsultSubscriberMenuItem",
									"click": {"bindTo": "clearConsultSubscriber"}
								}
							]
						}
					}
				},
				{
					"operation": "insert",
					"name": "ConsultSubscriberNumberInfo",
					"parentName": "ConsultIdentificationPanelRight",
					"propertyName": "items",
					"values": {
						"id": "ConsultSubscriberNumberInfo",
						"selectors": {"wrapEl": "#ConsultSubscriberNumberInfo"},
						"itemType": Terrasoft.ViewItemType.CONTAINER,
						"markerValue": "SubscriberNumberInfo",
						"visible": {"bindTo": "getIsConsultCommunicationTypeKnown"},
						"items": [
							{
								"id": "ConsultCommunicationTypeLabel",
								"itemType": Terrasoft.ViewItemType.LABEL,
								"classes": {"labelClass": ["label-caption"]},
								"markerValue": {"bindTo": "getConsultSubscriberData"},
								"selectors": {"wrapEl": "#ConsultCommunicationTypeLabel"},
								"caption": {"bindTo": "getConsultSubscriberData"},
								"tag": "CommunicationType"
							},
							{
								"id": "ConsultCallNumber",
								"itemType": Terrasoft.ViewItemType.LABEL,
								"classes": {"labelClass": ["subscriber-info"]},
								"markerValue": {"bindTo": "getConsultSubscriberData"},
								"selectors": {"wrapEl": "#ConsultCallNumber"},
								"caption": {"bindTo": "getConsultSubscriberData"},
								"tag": "Number"
							}
						]
					}
				},
				{
					"operation": "insert",
					"name": "ConsultAccountName",
					"parentName": "ConsultIdentificationDataPanel",
					"propertyName": "items",
					"values": {
						"tag": "AccountName",
						"visible": {"bindTo": "getIsConsultInfoLabelVisible"},
						"value": {"bindTo": "getConsultSubscriberData"},
						"generator": "CtiBaseHelper.getIdentificationDataLabel"
					}
				},
				{
					"operation": "insert",
					"name": "ConsultSubscriberJob",
					"parentName": "ConsultIdentificationDataPanel",
					"propertyName": "items",
					"values": {
						"tag": "Job",
						"visible": {"bindTo": "getIsConsultInfoLabelVisible"},
						"value": {"bindTo": "getConsultSubscriberData"},
						"generator": "CtiBaseHelper.getIdentificationDataLabel"
					}
				},
				{
					"operation": "insert",
					"name": "ConsultSubscriberDepartment",
					"parentName": "ConsultIdentificationDataPanel",
					"propertyName": "items",
					"values": {
						"tag": "Department",
						"visible": {"bindTo": "getIsConsultInfoLabelVisible"},
						"value": {"bindTo": "getConsultSubscriberData"},
						"generator": "CtiBaseHelper.getIdentificationDataLabel"
					}
				},
				{
					"operation": "insert",
					"name": "ConsultAccountType",
					"parentName": "ConsultIdentificationDataPanel",
					"propertyName": "items",
					"values": {
						"tag": "AccountType",
						"visible": {"bindTo": "getIsConsultInfoLabelVisible"},
						"value": {"bindTo": "getConsultSubscriberData"},
						"generator": "CtiBaseHelper.getIdentificationDataLabel"
					}
				},
				{
					"operation": "insert",
					"name": "ConsultAccountCity",
					"parentName": "ConsultIdentificationDataPanel",
					"propertyName": "items",
					"values": {
						"tag": "City",
						"visible": {"bindTo": "getIsConsultInfoLabelVisible"},
						"value": {"bindTo": "getConsultSubscriberData"},
						"generator": "CtiBaseHelper.getIdentificationDataLabel"
					}
				},

				//endregion

				//region call buttons controls

				{
					"operation": "insert",
					"name": "ButtonsPanelWrapper",
					"parentName": "ctiPanelMainContainer",
					"index": 3,
					"propertyName": "items",
					"values": {
						"markerValue": "ButtonsPanelWrapper",
						"itemType": Terrasoft.ViewItemType.CONTAINER,
						"visible": {"bindTo": "getIsCallExists"},
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "AdditionalCallInfoContainer",
					"parentName": "ctiPanelMainContainer",
					"index": 4,
					"propertyName": "items",
					"values": {
						"markerValue": "AdditionalCallInfoContainer",
						"itemType": Terrasoft.ViewItemType.CONTAINER,
						"visible": {"bindTo": "getIsAdditionalCallInfoContainerVisible"},
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "DtmfButtonsContainer",
					"parentName": "ButtonsPanelWrapper",
					"propertyName": "items",
					"values": {
						"onButtonClick": {"bindTo": "enterDtmf"},
						"dtmfDigitsLabel": {"bindTo": "DtmfDigits"},
						"visible": {"bindTo": "getCanMakeDtmf"},
						"generator": "CtiBaseHelper.getDtmfButtonsContainer"
					}
				},
				{
					"operation": "insert",
					"name": "ButtonsPanel",
					"parentName": "ButtonsPanelWrapper",
					"propertyName": "items",
					"values": {
						"markerValue": "ButtonsPanel",
						"itemType": Terrasoft.ViewItemType.CONTAINER,
						"wrapClass": ["buttons-panel"],
						"items": []
					}
				},
				{
					"operation": "insert",
					"index": 1,
					"name": "HoldButton",
					"parentName": "ButtonsPanel",
					"propertyName": "items",
					"values": {
						"id": "HoldButton",
						"itemType": Terrasoft.ViewItemType.BUTTON,
						"click": {"bindTo": "holdOrUnholdCall"},
						"visible": {"bindTo": "getCanHoldOrUnhold"},
						"imageConfig": {"bindTo": "getHoldButtonImageConfig"},
						"classes": {"wrapperClass": ["call-hold-button"]},
						"selectors": {"wrapEl": "#HoldButton"},
						"style": Terrasoft.controls.ButtonEnums.style.TRANSPARENT,
						"hint": {"bindTo": "getHoldButtonHint"},
						"markerValue": {"bindTo": "getHoldButtonHint"},
						"tag": "HoldButton"
					}
				},
				{
					"operation": "insert",
					"index": 2,
					"name": "PrepareTransferButton",
					"parentName": "ButtonsPanel",
					"propertyName": "items",
					"values": {
						"id": "PrepareTransferButton",
						"itemType": Terrasoft.ViewItemType.BUTTON,
						"click": {"bindTo": "onPrepareTransferButtonClick"},
						"visible": {"bindTo": "getCanStartTransfer"},
						"imageConfig": {"bindTo": "getPrepareTransferButtonImageConfig"},
						"classes": {"wrapperClass": ["call-prepare-transfer-button"]},
						"selectors": {"wrapEl": "#PrepareTransferButton"},
						"style": Terrasoft.controls.ButtonEnums.style.TRANSPARENT,
						"hint": {"bindTo": "Resources.Strings.PrepareTransferButtonHint"},
						"markerValue": "PrepareTransferButton",
						"tag": "PrepareTransferButton"
					}
				},
				{
					"operation": "insert",
					"index": 3,
					"name": "CompleteTransferButton",
					"parentName": "ButtonsPanel",
					"propertyName": "items",
					"values": {
						"id": "CompleteTransferButton",
						"itemType": Terrasoft.ViewItemType.BUTTON,
						"click": {"bindTo": "transferCall"},
						"visible": {"bindTo": "getCanTransfer"},
						"imageConfig": {"bindTo": "Resources.Images.CompleteTransferButtonIcon"},
						"classes": {
							"wrapperClass": ["call-complete-transfer-button",
								"t-btn-style-call-button-middle"]
						},
						"selectors": {"wrapEl": "#CompleteTransferButton"},
						"style": Terrasoft.controls.ButtonEnums.style.TRANSPARENT,
						"hint": {"bindTo": "Resources.Strings.CompleteTransferTip"},
						"markerValue": "CompleteTransferButton",
						"tag": "CompleteTransferButton"
					}
				},
				{
					"operation": "insert",
					"index": 4,
					"name": "DtmfButton",
					"parentName": "ButtonsPanel",
					"propertyName": "items",
					"values": {
						"id": "DtmfButton",
						"itemType": Terrasoft.ViewItemType.BUTTON,
						"click": {"bindTo": "onDtmfButtonClick"},
						"visible": {"bindTo": "getCanDtmf"},
						"imageConfig": {"bindTo": "getDtmfButtonImageConfig"},
						"selectors": {"wrapEl": "#DtmfButton"},
						"style": Terrasoft.controls.ButtonEnums.style.TRANSPARENT,
						"markerValue": {"bindTo": "Resources.Strings.DtmfButtonHint"},
						"tag": "DtmfButton"
					}
				},
				{
					"operation": "insert",
					"index": 5,
					"name": "MuteButton",
					"parentName": "ButtonsPanel",
					"propertyName": "items",
					"values": {
						"id": "MuteButton",
						"itemType": Terrasoft.ViewItemType.BUTTON,
						"click": {"bindTo": "onMuteButtonClick"},
						"visible": {"bindTo": "getIsMuteButtonVisible"},
						"enabled": {"bindTo": "getIsMuteButtonEnabled"},
						"imageConfig": {"bindTo": "getMuteButtonImageConfig"},
						"classes": {"wrapperClass": ["call-mute-button"]},
						"selectors": {"wrapEl": "#MuteButton"},
						"style": Terrasoft.controls.ButtonEnums.style.TRANSPARENT,
						"hint": {"bindTo": "getMuteButtonHint"},
						"markerValue": {"bindTo": "getMuteButtonHint"},
						"tag": "MuteButton"
					}
				},
				{
					"operation": "insert",
					"index": 6,
					"name": "VideoButton",
					"parentName": "ButtonsPanel",
					"propertyName": "items",
					"values": {
						"id": "VideoButton",
						"itemType": Terrasoft.ViewItemType.BUTTON,
						"click": {"bindTo": "onVideoButtonClick"},
						"visible": {"bindTo": "getIsAdditionalButtonsVisible"},
						"enabled": {"bindTo": "IsVideoSupported"},
						"imageConfig": {"bindTo": "getVideoButtonImageConfig"},
						"classes": {"wrapperClass": ["call-video-button"]},
						"selectors": {"wrapEl": "#VideoButton"},
						"style": Terrasoft.controls.ButtonEnums.style.TRANSPARENT,
						"hint": {"bindTo": "getVideoButtonHint"},
						"markerValue": {"bindTo": "getVideoButtonHint"},
						"tag": "VideoOffButton"
					}
				},
				{
					"operation": "insert",
					"index": 7,
					"name": "CancelTransferButton",
					"parentName": "ButtonsPanel",
					"propertyName": "items",
					"values": {
						"id": "CancelTransferButton",
						"itemType": Terrasoft.ViewItemType.BUTTON,
						"click": {"bindTo": "cancelTransfer"},
						"visible": {"bindTo": "getCanCancelTransfer"},
						"imageConfig": {"bindTo": "Resources.Images.CancelTransferButtonIcon"},
						"classes": {"wrapperClass": ["call-cancel-transfer-button", "t-btn-style-call-button-middle"]},
						"selectors": {"wrapEl": "#CancelTransferButton"},
						"style": Terrasoft.controls.ButtonEnums.style.TRANSPARENT,
						"hint": {"bindTo": "Resources.Strings.CancelTransferButtonHint"},
						"markerValue": {"bindTo": "Resources.Strings.CancelTransferButtonHint"},
						"tag": "TransferButton"
					}
				},
				{
					"operation": "insert",
					"index": 8,
					"name": "AnswerButton",
					"parentName": "ButtonsPanel",
					"propertyName": "items",
					"values": {
						"id": "AnswerButton",
						"itemType": Terrasoft.ViewItemType.BUTTON,
						"click": {"bindTo": "answerCall"},
						"visible": {"bindTo": "getCanAnswer"},
						"imageConfig": {"bindTo": "Resources.Images.AnswerButtonLongIcon"},
						"classes": {"wrapperClass": ["call-answer-button", "t-btn-style-call-button-long"]},
						"selectors": {"wrapEl": "#AnswerButton"},
						"style": Terrasoft.controls.ButtonEnums.style.TRANSPARENT,
						"hint": {"bindTo": "Resources.Strings.AnswerButtonHint"},
						"markerValue": {"bindTo": "Resources.Strings.AnswerButtonHint"},
						"tag": "AnswerButton"
					}
				},
				{
					"operation": "insert",
					"index": 9,
					"name": "DropButton",
					"parentName": "ButtonsPanel",
					"propertyName": "items",
					"values": {
						"id": "DropButton",
						"itemType": Terrasoft.ViewItemType.BUTTON,
						"click": {"bindTo": "dropCall"},
						"visible": {"bindTo": "getCanDrop"},
						"imageConfig": {"bindTo": "getDropButtonImageConfig"},
						"classes": {"wrapperClass": ["call-drop-button"]},
						"selectors": {"wrapEl": "#DropButton"},
						"style": {"bindTo": "getDropButtonStyle"},
						"hint": {"bindTo": "Resources.Strings.DropButtonHint"},
						"markerValue": {"bindTo": "Resources.Strings.DropButtonHint"},
						"tag": "DropButton"
					}
				},

				//endregion

				{
					"operation": "insert",
					"parentName": "ctiPanelMainContainer",
					"index": 5,
					"propertyName": "items",
					"name": "PhoneNumber",
					"values": {
						"id": "PhoneNumber",
						"className": "Terrasoft.SearchEdit",
						"placeholder": {"bindTo": "Resources.Strings.PhoneNumberPlaceholderCaption"},
						"contentType": Terrasoft.ContentType.SHORT_TEXT,
						"labelConfig": {"visible": false},
						"bindTo": "PhoneNumber",
						"enterkeypressed": {"bindTo": "callPhoneNumber"},
						"change": {"bindTo": "onPhoneNumberChanged"},
						"searchValueChanged": {"bindTo": "onPhoneNumberChanged"},
						"visible": {"bindTo": "getCanMakeCallOrMakeConsultCallOrGetIsOffline"},
						"controlConfig": {
							"classes": ["placeholderOpacity"]
						},
						"classes": {
							"wrapClass": ["phone-number-edit"]
						},
						"rightIconClick": {
							"bindTo": "callPhoneNumber"
						},
						"rightIconConfig": {
							"source": Terrasoft.ImageSources.URL,
							"url": Terrasoft.ImageUrlBuilder.getUrl(resources.localizableImages.MakeCallButtonIcon)
						}
					}
				},
				{
					"operation": "insert",
					"name": "NoConnectionMessageContainer",
					"parentName": "ctiPanelMainContainer",
					"index": 6,
					"propertyName": "items",
					"values": {
						"id": "NoConnectionMessage",
						"selectors": {"wrapEl": "#NoConnectionMessage"},
						"itemType": Terrasoft.ViewItemType.CONTAINER,
						"markerValue": "NoConnectionMessage",
						"items": [
							{
								"visible": {"bindTo": "getIsInternalTelephonyNotAvailable"},
								"id": "NoConnectionMessageLabel",
								"itemType": Terrasoft.ViewItemType.LABEL,
								"classes": {"labelClass": ["no-connection-msg"]},
								"caption": {"bindTo": "Resources.Strings.NoConnectionToTelephonyErrorMessage"}
							},
							{
								"visible": {"bindTo": "getIsTelephonyNotEnabled"},
								"id": "NotEnabledMessageLabel",
								"itemType": Terrasoft.ViewItemType.LABEL,
								"classes": {"labelClass": ["no-connection-msg"]},
								"caption": {"bindTo": "Resources.Strings.NotEnabledTelephonyErrorMessage"}
							}
						]
					}
				},
				{
					"operation": "insert",
					"name": "demoNoConnectionMessageContainer",
					"parentName": "NoConnectionMessageContainer",
					"propertyName": "items",
					"values": {
						"id": "demoNoConnectionMessageContainer",
						"selectors": {"wrapEl": "#demoNoConnectionMessageContainer"},
						"itemType": Terrasoft.ViewItemType.CONTAINER,
						"classes": {wrapClassName: ["no-connection-msg"]},
						"markerValue": "demoNoConnectionMessageContainer",
						"visible": {"bindTo": "getIsDemoTelephonyNotAvailable"},
						"items": [
							{
								"id": "demoNoConnectionMessageLabel",
								"itemType": Terrasoft.ViewItemType.LABEL,
								"caption": {"bindTo": "Resources.Strings.DemoNoConnectionMessageCaption"},
								"classes": {"labelClass": ["demo-no-connection-message-label"]}
							}
						]
					}
				},

				//region search and identification panels

				{
					"operation": "insert",
					"name": "SearchResultItemsListContainer",
					"parentName": "ctiPanelMainContainer",
					"index": 7,
					"propertyName": "items",
					"values": {
						"id": "SearchResultItemsListContainer",
						"itemType": Terrasoft.ViewItemType.CONTAINER,
						"markerValue": "SearchResultItemsListContainer",
						"selectors": {"wrapEl": "#SearchResultItemsListContainer"},
						"idProperty": "Id",
						"collection": {"bindTo": "SearchResultPanelCollection"},
						"onGetItemConfig": {"bindTo": "getSearchResultPanelViewConfig"},
						"classes": {"wrapClassName": ["search-result-items-list-container"]},
						"visible": {"bindTo": "getIsSearchResultItemsListContainerVisible"},
						"generator": "ContainerListGenerator.generateGrid",
						"observableRowNumber": 1,
						"observableRowVisible": {"bindTo": "onLoadNext"},
						"items": [],
						"itemFadeOutDuration": 20,
						"keepScrollOnItemsChanged": true
					}
				},
				{
					"operation": "insert",
					"parentName": "ctiPanelMainContainer",
					"index": 8,
					"name": "IdentificationItemsControlGroup",
					"propertyName": "items",
					"values": {
						"id": "IdentificationItemsControlGroup",
						"itemType": Terrasoft.ViewItemType.CONTROL_GROUP,
						"markerValue": "IdentificationItemsControlGroup",
						"selectors": {"wrapEl": "#IdentificationItemsControlGroup"},
						"caption": {"bindTo": "Resources.Strings.IdentificationItemsControlGroupCaption"},
						"visible": {"bindTo": "getIsIdentificationGroupContainerVisible"},
						"controlConfig": {"collapsed": false},
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "IdentificationItemsListContainer",
					"parentName": "IdentificationItemsControlGroup",
					"propertyName": "items",
					"values": {
						"id": "IdentificationItemsListContainer",
						"itemType": Terrasoft.ViewItemType.GRID,
						"markerValue": "IdentificationItemsListContainer",
						"selectors": {"wrapEl": "#IdentificationItemsListContainer"},
						"idProperty": "Id",
						"collection": {"bindTo": "IdentifiedSubscriberPanelCollection"},
						"onGetItemConfig": {"bindTo": "getIdentifiedSubscriberPanelViewConfig"},
						"classes": {"wrapClassName": ["identification-items-list-container"]},
						"onItemClick": {"bindTo": "setIdentifiedSubscriber"},
						"visible": {"bindTo": "getIsCurrentCallIdentificationContainerVisible"},
						"generator": "CtiContainerListGenerator.generatePartial"
					}
				},
				{
					"operation": "insert",
					"name": "IdentificationConsultItemsListContainer",
					"parentName": "IdentificationItemsControlGroup",
					"propertyName": "items",
					"values": {
						"id": "IdentificationConsultItemsListContainer",
						"itemType": Terrasoft.ViewItemType.GRID,
						"markerValue": "IdentificationConsultItemsListContainer",
						"selectors": {"wrapEl": "#IdentificationConsultItemsListContainer"},
						"idProperty": "Id",
						"collection": {"bindTo": "IdentifiedConsultSubscriberPanelCollection"},
						"onGetItemConfig": {"bindTo": "getIdentifiedSubscriberPanelViewConfig"},
						"classes": {"wrapClassName": ["identification-items-list-container"]},
						"onItemClick": {"bindTo": "setIdentifiedSubscriber"},
						"visible": {"bindTo": "getIsConsultCallIdentificationContainerVisible"},
						"generator": "CtiContainerListGenerator.generatePartial"
					}
				},

				//endregion

				//region empty panel elements

				{
					"operation": "insert",
					"name": "EmptySearchResultContainer",
					"parentName": "ctiPanelMainContainer",
					"index": 9,
					"propertyName": "items",
					"values": {
						"itemType": Terrasoft.ViewItemType.CONTAINER,
						"visible": {"bindTo": "getIsEmptySearchResultContainerVisible"},
						"classes": {
							"wrapClassName": ["empty-search-result-container"]
						},
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "EmptySearchResultImage",
					"parentName": "EmptySearchResultContainer",
					"propertyName": "items",
					"values": {
						"generator": "ImageCustomGeneratorV2.generateSimpleCustomImage",
						"onPhotoChange": Terrasoft.emptyFn,
						"getSrcMethod": "getEmptySearchResultImageUrl",
						"classes": {
							"wrapClass": ["image-container"]
						},
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "EmptySearchResultLabel",
					"parentName": "EmptySearchResultContainer",
					"propertyName": "items",
					"values": {
						"itemType": Terrasoft.ViewItemType.LABEL,
						"classes": {
							"labelClass": [
								"description-label"
							]
						},
						"caption": {"bindTo": "Resources.Strings.EmptySearchResultMessage"}
					}
				},

				//endregion

				//region communication history panels

				{
					"operation": "insert",
					"name": "CommunicationHistoryContainerList",
					"parentName": "ctiPanelMainContainer",
					"index": 10,
					"propertyName": "items",
					"values": {
						"id": "CommunicationHistoryContainerList",
						"itemType": Terrasoft.ViewItemType.GRID,
						"markerValue": "CommunicationHistoryContainerList",
						"selectors": {"wrapEl": "#CommunicationHistoryContainerList"},
						"idProperty": "Id",
						"collection": {"bindTo": "CommunicationHistoryPanelCollection"},
						"onGetItemConfig": {"bindTo": "getCommunicationHistoryPanelViewConfig"},
						"classes": {"wrapClassName": ["communication-history-items-list-container"]},
						"visible": {"bindTo": "getIsCommunicationHistoryVisible"},
						"generator": "CtiContainerListGenerator.generatePartial",
						"getEmptyMessageConfig": {"bindTo": "prepareEmptyGridMessageConfig"},
						"isEmpty": {"bindTo": "isEmptyCallHistoryMessageVisible"},
						"renderFinished": {"bindTo": "setAcademyMessageVisibility"}
					}
				},

				//endregion

				//region academy message
				{
					"operation": "insert",
					"name": "AcademyMessageContainerWrap",
					"parentName": "ctiPanelMainContainer",
					"index": 11,
					"propertyName": "items",
					"values": {
						"itemType": Terrasoft.ViewItemType.CONTAINER,
						"classes": {"wrapClassName": ["academy-message-container"]},
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "AcademyMessageContainer",
					"parentName": "AcademyMessageContainerWrap",
					"propertyName": "items",
					"values": {
						"itemType": Terrasoft.ViewItemType.CONTAINER,
						"classes": {"wrapClassName": ["academy-grid-message"]},
						"items": [],
						"visible": {"bindTo": "getIsAcademyMessageVisible"}
					}
				},
				{
					"operation": "insert",
					"name": "AcademyMessageDescription",
					"parentName": "AcademyMessageContainer",
					"propertyName": "items",
					"values": {
						"itemType": Terrasoft.ViewItemType.CONTAINER,
						"classes": {"wrapClassName": ["description t-label"]},
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "AcademyMessageElement",
					"parentName": "AcademyMessageDescription",
					"propertyName": "items",
					"values": {
						"itemType": Terrasoft.ViewItemType.COMPONENT,
						"className": "Terrasoft.HtmlControl",
						"htmlContent": {"bindTo": "AcademyHelpMessage"}
					}
				}

				//endregion

			]
		};
	}
);
