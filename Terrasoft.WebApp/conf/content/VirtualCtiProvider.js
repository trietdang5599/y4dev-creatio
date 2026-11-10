Terrasoft.configuration.Structures["VirtualCtiProvider"] = {innerHierarchyStack: ["VirtualCtiProvider"]};
define("VirtualCtiProvider", ["ext-base", "VirtualCtiProviderResources"],
	function(Ext, resources) {
		Ext.ns("Terrasoft.integration");
		Ext.ns("Terrasoft.integration.telephony");

		/**
		 * @class Terrasoft.integration.telephony.VirtualCtiProvider
		 * Virtual provider class.
		 */
		Ext.define("Terrasoft.integration.telephony.VirtualCtiProvider", {
			extend: "Terrasoft.BaseCtiProvider",
			alternateClassName: "Terrasoft.VirtualCtiProvider",
			singleton: true,

			// region Properties: Private

			/**
			 * Device unique identifier.
			 * @private
			 * @type {String}
			 */
			deviceId: "",

			/**
			 * Active call unique identifier.
			 * @private
			 * @type {String}
			 */
			activeCallId: "",

			/**
			 * Is connection established.
			 * @private
			 * @type {Boolean}
			 */
			isConnected: false,

			/**
			 * Virtually active calls.
			 * @private
			 * @type {Terrasoft.Collection}
			 */
			activeCalls: null,

			/**
			 * Can use video.
			 * @private
			 * @type {Boolean}
			 */
			useVideo: false,

			/**
			 * Call attachment schema UId.
			 * @private
			 * @type {String}
			 */
			callFileSchemaUId: "5956808f-648a-428e-be89-f2dd71f98166",

			/**
			 * Unique identifier of the test call record.
			 * @private
			 * @type {String}
			 */
			testCallRecordId: "1cf9c84c-21ba-4554-929e-f5332f9777d0",

			/**
			 * Path of the GetFile method of the FileService.
			 * @private
			 * @type {String}
			 */
			getFilePath: Terrasoft.workspaceBaseUrl + "/rest/FileService/GetFile/",

			/**
			 * Call record url.
			 * @private
			 * @type {String}
			 */
			callRecordUrl: "",

			/**
			 * Auto answering number.
			 * @private
			 * @type {String}
			 */
			autoAnsweringNumber: "00",

			//endregion

			// region Methods: Private

			/**
			 * Sets connection and connection properties.
			 * @private
			 */
			connect: function() {
				if (this.isConnected) {
					return;
				}
				var initialConfig = this.initialConfig;
				if (initialConfig) {
					var connectionConfig = initialConfig.connectionConfig;
					if (connectionConfig) {
						this.deviceId = connectionConfig.deviceId;
						this.useVideo = connectionConfig.useVideo;
						var autoAnsweringNumber = connectionConfig.autoAnsweringNumber;
						if (!Ext.isEmpty(autoAnsweringNumber)) {
							this.autoAnsweringNumber = autoAnsweringNumber;
						}
					}
				}
				this.isConnected = true;
				this.fireEvent("initialized", this);
				this.fireEvent("agentStateChanged", {userState: "Active"});
			},

			/**
			 * Handler for active call add to collection event.
			 * @private
			 */
			onActiveCallAdded: function() {
				if (this.activeCalls.getCount() === 1) {
					var activeCall = this.activeCalls.getByIndex(0);
					this.activeCallId = activeCall.id;
				}
			},

			/**
			 * Handler for active call remove from collection event.
			 * @private
			 */
			onActiveCallRemoved: function() {
				var activeCallsCount = this.activeCalls.getCount();
				switch (activeCallsCount) {
					case 0:
						this.activeCallId = "";
						this.fireEvent("lineStateChanged", {callFeaturesSet: Terrasoft.CallFeaturesSet.CAN_DIAL});
						break;
					case 1:
						var currentCall = this.activeCalls.getByIndex(0);
						this.activeCallId = currentCall.id;
						this.updateCallFeaturesSet(currentCall);
						this.fireCallEvent(currentCall);
						break;
					default:
						if (Ext.isEmpty(this.activeCalls.find(this.activeCallId))) {
							var activeCall = this.activeCalls.getByIndex(0);
							this.activeCallId = activeCall.id;
						}
						break;
				}
			},

			/**
			 * Handler for active call collection clear event.
			 * @private
			 */
			onActiveCallsCleared: function() {
				this.activeCallId = "";
			},

			/**
			 * Creates new call object.
			 * @private
			 * @param {Object} config Default properties of new call.
			 * @return {Terrasoft.integration.telephony.Call} Call.
			 */
			createNewCall: function(config) {
				var call = Ext.create("Terrasoft.integration.telephony.Call");
				call.deviceId = this.deviceId;
				call.ctiProvider =  this;
				Ext.apply(call, config);
				return call;
			},

			/**
			 * Processes call.
			 * @private
			 * @param {Terrasoft.integration.telephony.Call} call Call.
			 */
			processCall: function(call) {
				this.updateCallFeaturesSet(call);
				this.fireCallEvent(call);
				if (this.useVideo) {
					this.fireWebRTCEvent(call);
				}
				this.updateDbCall(call, this.onUpdateDbCall.bind(this));
			},

			/**
			 * Processes drop call.
			 * @private
			 * @param {Terrasoft.integration.telephony.Call} call Call.
			 */
			processDropCall: function(call) {
				call.oldState = call.state;
				call.state = Terrasoft.GeneralizedCallState.NONE;
				this.processCall(call);
				this.activeCalls.remove(call);
			},

			/**
			 * Generates error event.
			 * @private
			 * @param {String} errorMessage Error message.
			 */
			fireErrorEvent: function(errorMessage) {
				var errorInfo = {
					internalErrorCode: "100500",
					data: errorMessage,
					source: "VirtualCtiProvider",
					errorType: Terrasoft.MsgErrorType.GENERAL_ERROR
				};
				this.fireEvent("error", errorInfo);
			},

			/**
			 * Generates call event depending on the call state.
			 * @private
			 * @param {Terrasoft.integration.telephony.Call} call Call.
			 */
			fireCallEvent: function(call) {
				var event;
				if (call.state !== call.oldState) {
					switch (call.state) {
						case Terrasoft.GeneralizedCallState.ALERTING:
							event = "callStarted";
							break;
						case Terrasoft.GeneralizedCallState.CONNECTED:
							event = (call.oldState === Terrasoft.GeneralizedCallState.HOLDED)
								? "unhold"
								: "commutationStarted";
							break;
						case Terrasoft.GeneralizedCallState.HOLDED:
							event = "hold";
							break;
						case Terrasoft.GeneralizedCallState.NONE:
							event = "callFinished";
							break;
						default:
							break;
					}
				}
				if (!Ext.isEmpty(event)) {
					this.fireEvent(event, call);
				}
			},

			/**
			 * Generates WebRTC event depending on the call state.
			 * @private
			 * @param {Terrasoft.integration.telephony.Call} call Call.
			 */
			fireWebRTCEvent: function(call) {
				if (call.state === call.oldState) {
					return;
				}
				switch (call.state) {
					case Terrasoft.GeneralizedCallState.ALERTING:
						this.fireEvent("webRtcStarted", call.id, {});
						break;
					case Terrasoft.GeneralizedCallState.CONNECTED:
						this.fireEvent("webRtcVideoStarted", call.id);
						break;
					case Terrasoft.GeneralizedCallState.HOLDED:
					case Terrasoft.GeneralizedCallState.NONE:
						this.fireEvent("webRtcDestroyed", call.id);
						break;
					default:
						break;
				}
			},

			/**
			 * Updates call features set, depending on the call state.
			 * @private
			 * @param {Terrasoft.integration.telephony.Call} call Call.
			 */
			updateCallFeaturesSet: function(call) {
				var callFeaturesSet = Terrasoft.CallFeaturesSet.CAN_NOTHING;
				/*jshint bitwise:false*/
				switch (call.state) {
					case Terrasoft.GeneralizedCallState.ALERTING:
						callFeaturesSet = callFeaturesSet | Terrasoft.CallFeaturesSet.CAN_DROP;
						if (call.direction === Terrasoft.CallDirection.IN) {
							callFeaturesSet = callFeaturesSet | Terrasoft.CallFeaturesSet.CAN_ANSWER;
						}
						break;
					case Terrasoft.GeneralizedCallState.CONNECTED:
						callFeaturesSet = callFeaturesSet | Terrasoft.CallFeaturesSet.CAN_DROP |
							Terrasoft.CallFeaturesSet.CAN_HOLD | Terrasoft.CallFeaturesSet.CAN_DTMF |
							Terrasoft.CallFeaturesSet.CAN_MAKE_CONSULT_CALL |
							Terrasoft.CallFeaturesSet.CAN_BLIND_TRANSFER | Terrasoft.CallFeaturesSet.CAN_MUTE;
						break;
					case Terrasoft.GeneralizedCallState.HOLDED:
						callFeaturesSet = callFeaturesSet | Terrasoft.CallFeaturesSet.CAN_DROP |
							Terrasoft.CallFeaturesSet.CAN_UNHOLD;
						break;
					default:
						break;
				}
				/*jshint bitwise:true*/
				call.callFeaturesSet = callFeaturesSet;
			},

			/**
			 * Handler for call saved in database event.
			 * @private
			 * @param {Object} request Request object.
			 * @param {Boolean} success Is saving successfully completed.
			 * @param {Object} response Response object.
			 */
			onUpdateDbCall: function(request, success, response) {
				const responseText = response.responseText;
				var callDatabaseUid = Terrasoft.isGUID(responseText) ? responseText : Terrasoft.decode(responseText);
				if (success && Terrasoft.isGUID(callDatabaseUid)) {
					var call = Terrasoft.decode(request.jsonData);
					call.databaseUId = callDatabaseUid;
					var activeCall = this.activeCalls.find(call.id);
					if (!Ext.isEmpty(activeCall)) {
						activeCall.databaseUId = callDatabaseUid;
					}
					this.fireEvent("callSaved", call);
				} else {
					this.fireErrorEvent(responseText);
				}
			},

			//endregion

			//region Methods: Public

			/**
			 * Constructor for virtual cti provider class.
			 */
			constructor: function() {
				this.callParent(arguments);
				this.activeCalls = Ext.create("Terrasoft.Collection");
				this.activeCalls.on("add", this.onActiveCallAdded, this);
				this.activeCalls.on("remove", this.onActiveCallRemoved, this);
				this.activeCalls.on("clear", this.onActiveCallsCleared, this);
				this.callRecordUrl = Ext.String.format("{0}{1}/{2}", this.getFilePath, this.callFileSchemaUId,
					this.testCallRecordId);
			},

			/**
			 * @inheritdoc Terrasoft.BaseCtiProvider#init
			 * @overridden
			 */
			init: function() {
				this.callParent(arguments);
				this.connect();
			},

			/**
			 * @inheritdoc Terrasoft.BaseCtiProvider#closeConnection
			 * @overridden
			 */
			closeConnection: function() {
				this.isConnected = false;
				this.activeCalls.clear();
				this.fireEvent("disconnected");
				this.fireEvent("agentStateChanged", { userState: "LOGOUT"});
			},

			/**
			 * @inheritdoc Terrasoft.BaseCtiProvider#getAgentLogoutCode.
			 */
			getAgentLogoutCode: function() {
				return 'LOGOUT';
			},

			/**
			 * @inheritdoc Terrasoft.BaseCtiProvider#makeCall
			 * @overridden
			 */
			makeCall: function(targetAddress) {
				var callId = Terrasoft.generateGUID();
				var config = {
					id: callId,
					direction: Terrasoft.CallDirection.OUT,
					callerId: this.deviceId,
					calledId: targetAddress,
					state: Terrasoft.GeneralizedCallState.ALERTING,
					oldState: Terrasoft.GeneralizedCallState.NONE
				};
				var call = this.createNewCall(config);
				this.activeCalls.add(callId, call);
				this.processCall(call);
				if (targetAddress === this.autoAnsweringNumber) {
					this.answerOutgoingCall(callId);
				}
			},

			/**
			 * @inheritdoc Terrasoft.BaseCtiProvider#answerCall
			 * @overridden
			 */
			answerCall: function(call) {
				var callId = call.id;
				var activeCall = this.activeCalls.get(callId);
				if (activeCall.state === Terrasoft.GeneralizedCallState.ALERTING) {
					activeCall.oldState = activeCall.state;
					activeCall.state = Terrasoft.GeneralizedCallState.CONNECTED;
				} else {
					var errorMessage = Ext.String.format(resources.localizableStrings.InvalidCallStateMessage,
						callId, activeCall.state, Terrasoft.GeneralizedCallState.ALERTING);
					this.fireErrorEvent(errorMessage);
					return;
				}
				this.processCall(activeCall);
			},

			/**
			 * @inheritdoc Terrasoft.BaseCtiProvider#holdCall
			 * @overridden
			 */
			holdCall: function(call) {
				var callId = call.id;
				var activeCall = this.activeCalls.get(callId);
				if (activeCall.state === Terrasoft.GeneralizedCallState.HOLDED) {
					activeCall.oldState = activeCall.state;
					activeCall.state = Terrasoft.GeneralizedCallState.CONNECTED;
				} else if (activeCall.state === Terrasoft.GeneralizedCallState.CONNECTED) {
					activeCall.oldState = activeCall.state;
					activeCall.state = Terrasoft.GeneralizedCallState.HOLDED;
				} else {
					var expectedState = Ext.String.format("{0} " + resources.localizableStrings.OrMessage + " {1}",
						Terrasoft.GeneralizedCallState.HOLDED, Terrasoft.GeneralizedCallState.CONNECTED);
					var errorMessage = Ext.String.format(resources.localizableStrings.InvalidCallStateMessage,
						callId, activeCall.state, expectedState);
					this.fireErrorEvent(errorMessage);
					return;
				}
				this.processCall(activeCall);
			},

			/**
			 * @inheritdoc Terrasoft.BaseCtiProvider#dropCall
			 * @overridden
			 */
			dropCall: function(call) {
				var activeCall = this.activeCalls.get(call.id);
				this.processDropCall(activeCall);
			},

			/**
			 * @inheritdoc Terrasoft.BaseCtiProvider#makeConsultCall
			 * @overridden
			 */
			makeConsultCall: function(call, targetAddress) {
				this.makeCall(targetAddress);
				var activeCall = this.activeCalls.get(call.id);
				activeCall.oldState = activeCall.state;
				activeCall.state = Terrasoft.GeneralizedCallState.HOLDED;
				/*jshint bitwise:false*/
				activeCall.callFeaturesSet = Terrasoft.CallFeaturesSet.CAN_DROP |
					Terrasoft.CallFeaturesSet.CAN_UNHOLD |
					Terrasoft.CallFeaturesSet.CAN_MUTE |
					Terrasoft.CallFeaturesSet.CAN_COMPLETE_TRANSFER;
				/*jshint bitwise:true*/
				this.fireCallEvent(activeCall);
				if (this.useVideo) {
					this.fireWebRTCEvent(activeCall);
				}
				this.updateDbCall(activeCall, this.onUpdateDbCall.bind(this));
			},

			/**
			 * @inheritdoc Terrasoft.BaseCtiProvider#mute
			 * @overridden
			 */
			mute: Terrasoft.emptyFn,

			/**
			 * @inheritdoc Terrasoft.BaseCtiProvider#transferCall
			 * @overridden
			 */
			transferCall: function(currentCall, consultCall) {
				var activeCurrentCall = this.activeCalls.get(currentCall.id);
				var activeConsultCall = this.activeCalls.get(consultCall.id);
				this.processDropCall(activeConsultCall);
				activeCurrentCall.redirectingId = activeConsultCall.callerId;
				activeCurrentCall.redirectionId = activeConsultCall.calledId;
				this.processDropCall(activeCurrentCall);
			},

			/**
			 * @inheritdoc Terrasoft.BaseCtiProvider#cancelTransfer
			 * @overridden
			 */
			cancelTransfer: function(currentCall, consultCall) {
				var currentCallId = currentCall.id;
				var activeCurrentCall = this.activeCalls.get(currentCallId);
				var activeConsultCall = this.activeCalls.get(consultCall.id);
				this.processDropCall(activeConsultCall);
				if (activeCurrentCall.state === Terrasoft.GeneralizedCallState.HOLDED) {
					activeCurrentCall.oldState = activeCurrentCall.state;
					activeCurrentCall.state = Terrasoft.GeneralizedCallState.CONNECTED;
				} else {
					var errorMessage = Ext.String.format(resources.localizableStrings.InvalidCallStateMessage,
						currentCallId, activeCurrentCall.state, Terrasoft.GeneralizedCallState.HOLDED);
					this.fireErrorEvent(errorMessage);
					return;
				}
				this.processCall(activeCurrentCall);
			},

			/**
			 * @inheritdoc Terrasoft.BaseCtiProvider#blindTransferCall
			 * @overridden
			 */
			blindTransferCall: function(call, targetAddress) {
				var activeCall = this.activeCalls.get(call.id);
				activeCall.redirectingId = activeCall.deviceId;
				activeCall.redirectionId = targetAddress;
				this.processDropCall(activeCall);
			},

			/**
			 * @inheritdoc Terrasoft.BaseCtiProvider#queryLineState
			 * @overridden
			 */
			queryLineState: Terrasoft.emptyFn,

			/**
			 * @inheritdoc Terrasoft.BaseCtiProvider#queryActiveCallSnapshot
			 * @overridden
			 */
			queryActiveCallSnapshot: Terrasoft.emptyFn,

			/**
			 * @inheritdoc Terrasoft.BaseCtiProvider#setUserState
			 * @overridden
			 */
			setUserState: function(code, reason) {
				this.fireEvent("agentStateChanged", {
					userState: code,
					userStateReasonCode: reason
				});
			},

			/**
			 * @inheritdoc Terrasoft.BaseCtiProvider#setVideoState
			 * @overridden
			 */
			setVideoState: function(call, isVideoActive, callback) {
				var isCallActive = this.activeCalls.contains(call.id);
				callback(isVideoActive && isCallActive);
			},

			/**
			 * @inheritdoc Terrasoft.BaseCtiProvider#queryUserState
			 * @overridden
			 */
			queryUserState: Terrasoft.emptyFn,

			/**
			 * @inheritdoc Terrasoft.BaseCtiProvider#sendDtmf
			 * @overridden
			 */
			sendDtmf: function(call, digit) {
				var activeCall = this.activeCalls.get(call.id);
				/*jshint bitwise:false */
				if ((activeCall.callFeaturesSet & Terrasoft.CallFeaturesSet.CAN_DTMF) > 0) {
					this.fireEvent("dtmfEntered", digit);
				}
				/*jshint bitwise:true */
			},

			/**
			 * @inheritdoc Terrasoft.BaseCtiProvider#queryCallRecords
			 * @overridden
			 */
			queryCallRecords: function(callId, callback) {
				callback([this.callRecordUrl]);
			},

			/**
			 * @inheritdoc Terrasoft.BaseCtiProvider#changeCallCentreState
			 * @overridden
			 */
			changeCallCentreState: Terrasoft.emptyFn,

			/**
			 * @inheritdoc Terrasoft.BaseCtiProvider#getCapabilities
			 * @overridden
			 */
			getCapabilities: function() {
				/*jshint bitwise:false */
				var callCapabilities = Terrasoft.CallFeaturesSet.CAN_RECALL | Terrasoft.CallFeaturesSet.CAN_DIAL |
					Terrasoft.CallFeaturesSet.CAN_DROP |
					Terrasoft.CallFeaturesSet.CAN_HOLD | Terrasoft.CallFeaturesSet.CAN_UNHOLD |
					Terrasoft.CallFeaturesSet.CAN_COMPLETE_TRANSFER |
					Terrasoft.CallFeaturesSet.CAN_BLIND_TRANSFER | Terrasoft.CallFeaturesSet.CAN_MAKE_CONSULT_CALL |
					Terrasoft.CallFeaturesSet.CAN_DTMF | Terrasoft.CallFeaturesSet.CAN_ANSWER |
					Terrasoft.CallFeaturesSet.CAN_VIDEO | Terrasoft.CallFeaturesSet.CAN_MUTE;
				/*jshint bitwise:true */
				return {
					callCapabilities: callCapabilities,
					agentCapabilities: Terrasoft.AgentFeaturesSet.CAN_GET_CALL_RECORDS
				};
			},

			/**
			 * Virtually answers outgoing call.
			 * @param {String} callId Unique call identifier.
			 */
			answerOutgoingCall: function(callId) {
				var activeCall = this.activeCalls.find(callId);
				var errorMessage;
				if (Ext.isEmpty(activeCall)) {
					errorMessage = Ext.String.format(resources.localizableStrings.CallNotFoundMessage, callId);
					throw new Terrasoft.ItemNotFoundException({message: errorMessage});
				}
				if (activeCall.state === Terrasoft.GeneralizedCallState.ALERTING) {
					activeCall.oldState = activeCall.state;
					activeCall.state = Terrasoft.GeneralizedCallState.CONNECTED;
					this.processCall(activeCall);
				} else {
					errorMessage = Ext.String.format(resources.localizableStrings.InvalidCallStateMessage,
						callId, activeCall.state, Terrasoft.GeneralizedCallState.ALERTING);
					throw new Terrasoft.InvalidObjectState({message: errorMessage});
				}
			},

			/**
			 * Virtually creates incoming call.
			 * @param {String} callerId Caller number.
			 */
			createIncomingCall: function(callerId) {
				const activeCallsCount = this.activeCalls.getCount();
				if (activeCallsCount === 1) {
					this.holdCall(this.activeCalls.getByIndex(0));
				}
				const callId = Terrasoft.generateGUID();
				const config = {
					id: callId,
					direction: Terrasoft.CallDirection.IN,
					callerId: callerId,
					calledId: this.deviceId,
					state: Terrasoft.GeneralizedCallState.ALERTING,
					oldState: Terrasoft.GeneralizedCallState.NONE
				};
				const call = this.createNewCall(config);
				this.activeCalls.add(callId, call);
				this.processCall(call);
			}

			//endregion

		});
	}
);


