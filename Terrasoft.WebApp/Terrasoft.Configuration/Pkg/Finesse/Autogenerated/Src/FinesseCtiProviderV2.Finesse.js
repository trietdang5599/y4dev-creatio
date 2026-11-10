define("FinesseCtiProviderV2", ["ext-base", "terrasoft", "StropheModule"], function(Ext, Terrasoft, StropheModule) {

	Ext.ns("Terrasoft.integration");
	Ext.ns("Terrasoft.integration.telephony");
	Ext.ns("Terrasoft.integration.telephony.finesse");

	//region Class: FinesseCtiProviderV2

	Ext.require("Terrasoft.integration.telephony.finesse.FinesseCtiProvider", function() {

		/**
		 * Provider class to the Finesse service (for version 11.5+).
		 */
		Ext.define("Terrasoft.integration.telephony.finesse.FinesseCtiProviderV2", {
			extend: "Terrasoft.integration.telephony.finesse.FinesseCtiProvider.self",
			alternateClassName: "Terrasoft.FinesseCtiProviderV2",
			singleton: true,

			//region Properties: Private

			/**
			 * Path to Finesse websocket service.
			 * @private
			 * @type {String}
			 */
			_websocketServiceUrl: "",

			/**
			 * Strophe eventing object.
			 * @private
			 * @type {Object}
			 */
			_xmppClient: null,

			/**
			 * Worker for setInterval ping-pong session.
			 * @private
			 * @type {Object}
			 */
			_worker: null,

			/**
			 * Finesse session logout called.
			 * @private
			 * @type {Boolean}
			 */
			_loggedOut: false,

			/**
			 * True when websocket sys settings were already loaded for the current page lifetime.
			 * @private
			 * @type {Boolean}
			 */
			_sysSettingsInitialized: false,

			/**
			 * Prevents parallel websocket connection attempts.
			 * @private
			 * @type {Boolean}
			 */
			_isServiceChannelConnecting: false,

			/**
			 * Prevents duplicate transport reconnect attempts.
			 * @private
			 * @type {Boolean}
			 */
			_isTransportReconnectInProgress: false,

			/**
			 * Monotonically increasing websocket connection attempt id.
			 * Stale callbacks from previous attempts are ignored.
			 * @private
			 * @type {Number}
			 */
			_serviceChannelGeneration: 0,

			/**
			 * Prevents duplicate disconnected notifications for the same transport outage.
			 * @private
			 * @type {Boolean}
			 */
			_transportDisconnectNotified: false,

			/**
			 * True after the first successful loginFinesse for the current page lifetime.
			 * Subsequent transport reconnects must not re-issue Sign-In on Finesse REST,
			 * to honour the ENG-88596 intent of "rebuild socket, do not recreate session".
			 * Cleared on AUTHFAIL (the Cisco-side session may have been invalidated, so the
			 * next successful CONNECTED must re-establish it), on init, and on logoutFinesse.
			 * @private
			 * @type {Boolean}
			 */
			_finesseSessionEstablished: false,

			/**
			 * Generation of the XMPP connection currently being intentionally torn down by
			 * disconnectServiceChannel(). Only DISCONNECTED callbacks for this exact generation
			 * are suppressed. A DISCONNECTED of any OTHER generation (e.g. the replacement
			 * connection failing CONNFAIL → DISCONNECTED before reaching CONNECTED) MUST clear
			 * the reconnect-in-progress flag and notify CtiModel so its retry timer re-arms.
			 * Default -1 never matches a real generation (which start at 1 via ++pre-increment).
			 * @private
			 * @type {Number}
			 */
			_solicitedDisconnectGeneration: -1,

			//endregion

			//region Methods: Private

			/**
			 * Converts input string to base64 encoded string.
			 * @private
			 * @param {String} input Input string.
			 * @return {String} Base64 representation of input string.
			 */
			_base64Encode: function(input) {
				let output = "", idx, data;
				const table = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/=";
				for (idx = 0; idx < input.length; idx += 3) {
					data =  input.charCodeAt(idx) << 16 |
								input.charCodeAt(idx + 1) << 8 |
								input.charCodeAt(idx + 2);
					output += table.charAt((data >>> 18) & 0x003f) +
								table.charAt((data >>> 12) & 0x003f);
					output += ((idx + 1) < input.length) ?
								table.charAt((data >>> 6) & 0x003f) :
								"=";
					output += ((idx + 2) < input.length) ?
								table.charAt(data & 0x003f) :
								"=";
				}
				return output;
			},

			/**
			 * Adds strophe.ping plugin (external) to XMPP client connection.
			 * @private
			 */
			_addPingXmppClientConnectionPlugin: function() {
				StropheModule.Strophe.addConnectionPlugin("ping", {
					_c: null,

					// called by the Strophe.Connection constructor
					init: function(conn) {
						this._c = conn;
						StropheModule.Strophe.addNamespace("PING", "urn:xmpp:ping");
					},

					/**
					 * Function: ping
					 *
					 * Parameters:
					 * (String) to - The JID you want to ping
					 * (Function) success - Callback function on success
					 * (Function) error - Callback function on error
					 * (Integer) timeout - Timeout in milliseconds
					 */
					ping: function(jid, success, error, timeout) {
						var id = this._c.getUniqueId("ping");
						var iq = StropheModule.$iq({type: "get", to: jid, id: id}).c("ping", {xmlns: StropheModule.Strophe.NS.PING});
						this._c.sendIQ(iq, success, error, timeout);
					},

					/**
					 * Function: pong
					 *
					 * Parameters:
					 * (Object) ping - The ping stanza from the server.
					 */
					pong: function(ping) {
						var from = ping.getAttribute("from");
						var id = ping.getAttribute("id");
						var iq = StropheModule.$iq({type: "result", to: from,id: id});
						this._c.sendIQ(iq);
					},

					/**
					 * Function: addPingHandler
					 
					 * Parameters:
					 * (Function) handler - Ping handler
					 *
					 * Returns:
					 * A reference to the handler that can be used to remove it.
					 */
					addPingHandler: function(handler) {
						return this._c.addHandler(handler, StropheModule.Strophe.NS.PING, "iq", "get");
					}
				});
			},

			/**
			 * Recreates XMPP client connection.
			 * @private
			 */
			 _reconnectServiceChannel: function() {
				if (this._loggedOut || this._isTransportReconnectInProgress) {
					return;
				}
				this._isTransportReconnectInProgress = true;
				this._terminateWorker();
				try{
					this.disconnectServiceChannel();
					this.initServiceChannel();
				} catch(ex){
					console.error(ex);
					this._isTransportReconnectInProgress = false;
					this.disconnectServiceChannel();
					this.fireEvent("error", {
						data: ex.message,
						errorType: Terrasoft.MsgErrorType.OPEN_CONNECTION_ERROR
					});
				}
			},

			/**
			 * Creates Web Worker to avoid browser throttling
			 * @private
			 */
			_createWebWorker: function() {
				const intervalFunc = function() {
					let interval = null;
					self.addEventListener("message", function(event) {
						if(event.data.command === 'setInterval'){
							if(interval !== null){
								clearInterval(interval);
							}
							interval = setInterval(function () {
								self.postMessage('');
							}, event.data.pingPeriod);
						} else {
							console.error('Unknown command');
						}
					}, false);
					
				};
				this._worker = new Worker(URL.createObjectURL(new Blob([
					`(${intervalFunc.toString()})();`
				], {type: 'application/javascript'})));
		
			},

			/**
			 * Calls finesse session logout on Creatio user session end.
			 * @private
			 */
			_handleServerChannelMessage: function(channel, message) {
				if (!message || message.Header.Sender !== "WebApp" || message.Header.BodyTypeName !== "SessionEnd") {
					return;
				}
				var body;
				try {
					body = JSON.parse(message.Body);
				} catch (exception) {
					return;
				}
				var currentSessionId = Terrasoft.sessionId;
				var sessionIdPropertyName = "SessionId";
				var receivedSessionId = body[sessionIdPropertyName];
				if (currentSessionId && receivedSessionId !== currentSessionId) {
					return;
				}
				Terrasoft.ServerChannel.un(Terrasoft.EventName.ON_MESSAGE, this._handleServerChannelMessage, this);
				this.logoutFinesse();
			},

			_notifyTransportDisconnected: function(reason) {
				// Note: solicited-vs-unsolicited gating lives in the DISCONNECTED branch of
				// onConnected (via _solicitedDisconnectGeneration). This method's only job
				// is to dedupe duplicate notifications for the same outage.
				if (this._transportDisconnectNotified) {
					return;
				}
				this._transportDisconnectNotified = true;
				this.fireEvent("disconnected", reason);
			},

			_terminateWorker: function() {
				if (this._worker) {
					this._worker.terminate();
					this._worker = null;
				}
			},

			_setupWorker() {
				const xmppClient = this._xmppClient;
				xmppClient.addHandler(this.eventHandler.bind(this), null, "message", null, null, null);
				xmppClient.send(StropheModule.$pres().tree());
				const jid = this.agentId + "@" + this.domain + "/" + this.deviceId;
				const xmppClientPingMillisecondsPeriod = 10000;
				this._createWebWorker();
				this._worker.postMessage({command: 'setInterval', pingPeriod: xmppClientPingMillisecondsPeriod});
				const that = this;
				this._worker.addEventListener('message', function (e) {
					try {
						xmppClient.ping.ping(jid,
							Terrasoft.emptyFn,
							Terrasoft.emptyFn,
							xmppClientPingMillisecondsPeriod);
					} catch (ex) {
						Terrasoft.Logger.log('Retrying...');
						that._terminateWorker();
						that._notifyTransportDisconnected("XMPP ping failed");
					}
				}, false);
			},

			//endregion

			//region Methods: Protected

			/**
			 * @inheritdoc BaseCtiProvider#init
			 * @overriden
			 */
			init: function(callback, scope) {
				this._loggedOut = false;
				this._finesseSessionEstablished = false;
				this._solicitedDisconnectGeneration = -1;
				Terrasoft.ServerChannel.on(Terrasoft.EventName.ON_MESSAGE, this._handleServerChannelMessage, this);
				this.callParent(arguments);
				this._addPingXmppClientConnectionPlugin();
			},

			/**
			 * @inheritdoc BaseCtiProvider#reConnect
			 * @overriden
			 */
			reConnect: function() {
				if (this._loggedOut) {
					return;
				}
				if (!this._sysSettingsInitialized) {
					this.callParent(arguments);
					return;
				}
				this._reconnectServiceChannel();
			},

			/**
			 * @inheritdoc BaseCtiProvider#setFinesseAgentState
			 * @overriden
			 * Adds micro delay to avoid simultaneous request to Finesse after reconnecting
			 */
			setFinesseAgentState: function(stateCode, reasonCode, callback) {
				const parentMethod = this.getParentMethod();
				setTimeout(function(){
					parentMethod.call(this, stateCode, reasonCode, callback);
				}.bind(this), 100);
			},

			/**
			 * Sets required dependensies.
			 * @protected
			 * @param {Function} callback Callback function.
			 */
			initDependencies: function(callback) {
				if (!Ext.global.jabberwerx.util.crypto) {
					Ext.global.jabberwerx.util.crypto = {
						b64Encode: this._base64Encode
					};
				}
				Ext.callback(callback, this);
			},

			/**
			 * Opens connection to Finesse sever.
			 * @protected
			 * @param {Object} config Connection parameters.
			 */
			connect: function(config) {
				Terrasoft.chain(
					this.initDependencies,
					this.initSysSettings,
					function() {
						this.agentId = config.AgentID;
						this.password = config.Password;
						this.deviceId = config.Extension;
						this.initServiceChannel();
					}, this);
			},

			/**
			 * Initializes finesse settings.
			 * @protected
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback function scope.
			 */
			initSysSettings: function(callback, scope) {
				if (this._sysSettingsInitialized && this.domain && this._websocketServiceUrl) {
					Ext.callback(callback, scope || this);
					return;
				}
				Terrasoft.SysSettings.querySysSettings(["FinesseServerAddress", "FinesseWebsocketAddress"],
					function(sysSettingsValue) {
						this.finesseApiPath = new URL(this.finesseApiPath, sysSettingsValue.FinesseServerAddress).href;
						this.domain = new URL(sysSettingsValue.FinesseServerAddress).hostname;
						this._websocketServiceUrl = sysSettingsValue.FinesseWebsocketAddress +"/ws/";
						this._sysSettingsInitialized = true;
						Ext.callback(callback, scope || this);
				}, this);
			},

			/**
			 * Processes the connection event on the Cisco Finesse server side.
			 * @protected
			 * @param {String} status Strophe eventing object connection status.
			 */
			onConnected: function (generation, status) {
				if (generation !== this._serviceChannelGeneration) {
					return;
				}
				this._isServiceChannelConnecting = false;
				const connectionStatuses = StropheModule.Strophe.Status;
				let statusString = Object.keys(connectionStatuses)
					.find(k=>connectionStatuses[k] === status);
				Terrasoft.Logger.log("onConnect() - XMPP client onConnected fired with status " + statusString);
				switch (status) {
					case connectionStatuses.CONNECTED:
						this._isTransportReconnectInProgress = false;
						this._setupWorker();
						if (!this._finesseSessionEstablished) {
							this._finesseSessionEstablished = true;
							this.loginFinesse();
						}
						break;
					case connectionStatuses.ERROR:
						this._isTransportReconnectInProgress = false;
						var errorMsg = Ext.String.format(
							"onConnect() - XMPP client about to reset because of error, statusString = {0}", 
							Terrasoft.encode(statusString));
						Terrasoft.Logger.error(errorMsg);
						break;
					case connectionStatuses.AUTHFAIL:
						this._isTransportReconnectInProgress = false;
						// AUTHFAIL on the XMPP layer often correlates with the underlying
						// Finesse REST session being invalidated server-side (long outage,
						// IM&P session aged out, or operator-side reset). Force the next
						// successful CONNECTED to re-issue loginFinesse so the agent does
						// not stay attached at the transport layer with no live REST session.
						this._finesseSessionEstablished = false;
						var errorMsg = Ext.String.format(
							"onConnect() - XMPP client about to reset because of authorization failed, statusString = {0}",
							Terrasoft.encode(statusString));
						Terrasoft.Logger.error(errorMsg);
						break;
					case connectionStatuses.CONNFAIL:
						// CONNFAIL is reached when the new transport never opened (TCP/TLS
						// failure, websocket upgrade rejected, etc.). Strophe will follow
						// with DISCONNECTED for the same generation, but clearing the
						// reconnect-in-progress flag here makes the design invariant
						// explicit and resilient to ordering changes upstream.
						this._isTransportReconnectInProgress = false;
						var errorMsg = Ext.String.format(
							"onConnect() - XMPP client about to reset because of connection failure, statusString = {0}",
							Terrasoft.encode(statusString));
						Terrasoft.Logger.error(errorMsg);
						break;
					case connectionStatuses.DISCONNECTED:
						Terrasoft.Logger.log("onConnect() - XMPP client was disconnected");
						this._terminateWorker();
						this._xmppClient = null;
						if (generation === this._solicitedDisconnectGeneration) {
							// Synchronous DISCONNECTED of the connection we just deliberately
							// tore down (from _reconnectServiceChannel or logoutFinesse).
							// Suppress: we either spin up the replacement transport ourselves
							// or are actually logging out; do not race CtiModel's retry timer.
							this._solicitedDisconnectGeneration = -1;
							break;
						}
						// Unsolicited DISCONNECTED: either steady-state network drop or the
						// replacement connection (after _reconnectServiceChannel rebuilt the
						// transport) failed to come up. Release the reconnect-in-progress
						// flag so a subsequent reConnect() can take over, and forward the
						// notification to CtiModel for normal retry-timer handling.
						this._isTransportReconnectInProgress = false;
						this._notifyTransportDisconnected("XMPP client was disconnected");
						break;
					default:
						// Intermediate Strophe statuses (CONNECTING, AUTHENTICATING,
						// ATTACHED, BINDREQUIRED, REDIRECT) require no action here.
						// Every terminal failure status (ERROR, AUTHFAIL, CONNFAIL,
						// DISCONNECTED) has its own case above and is responsible for
						// clearing _isTransportReconnectInProgress.
						break;
				}
			},

			/**
			 * Processes the event when event occurs on the Cisco Finesse server side.
			 * @protected
			 * @param {Object} data Event handler parameters.
			 */
			eventHandler: function (data) {
				if (this.processFinesseEvent) {
					const messageText = data.textContent;
					this.processFinesseEvent(messageText);
				} else {
					this.onFinesseEvent({selected: data});
				}
				return true;
			},

			/**
			 * Initializes service channel settings.
			 * @protected
			 */
			initServiceChannel: function() {
				if (this._loggedOut || this._isServiceChannelConnecting) {
					return;
				}
				this._transportDisconnectNotified = false;
				this._isServiceChannelConnecting = true;
				const connectionGeneration = ++this._serviceChannelGeneration;
				this._xmppClient = new StropheModule.Strophe.Connection(this._websocketServiceUrl);
				const jid = this.agentId + "@" + this.domain + "/" + this.deviceId;
				this._xmppClient.connect(jid, this.password, this.onConnected.bind(this, connectionGeneration));
			},

			/**
			 * Dispose service channel settings.
			 * @protected
			 */
			 disconnectServiceChannel: function() {
				const xmppClient = this._xmppClient;
				this._xmppClient = null;
				this._isServiceChannelConnecting = false;
				if (xmppClient) {
					// Mark the upcoming DISCONNECTED for this generation as solicited.
					// The DISCONNECTED branch in onConnected will use this to suppress the
					// notification only for that exact generation; a later DISCONNECTED on
					// a different generation (e.g. the new connection we are about to spin
					// up failing CONNFAIL → DISCONNECTED) must NOT be suppressed, otherwise
					// the reconnect-in-progress flag wedges and CtiModel's retry stops.
					this._solicitedDisconnectGeneration = this._serviceChannelGeneration;
					xmppClient.disconnect();
				}
			},

			/**
			 * @inheritdoc FinesseCtiProvider#logoutFinesse
			 * @overriden
			 */
			logoutFinesse: function() {
				this._loggedOut = true;
				this._finesseSessionEstablished = false;
				this._terminateWorker();
				this.disconnectServiceChannel();
				this.callParent(arguments);
			},

			/**
			* @inheritdoc Terrasoft.BaseCtiProvider#closeConnection.
			* @overriden
			*/
			closeConnection: function() {
				this.logoutFinesse();
			},

			//endregion

		});
	});
});

//endregion
