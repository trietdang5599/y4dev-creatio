/**
 * The channel for exchanging messages with the BPMonline server, the messages are encoded in the JSON format
 */
Ext.define("Terrasoft.core.ServerChannel", {
	extend: "Terrasoft.MsgChannel",
	alternateClassName: "Terrasoft.ServerChannel",
	singleton: true,

	/**
	 * A timeout (ms) between reconnection attempts.
	 * @type {Number}
	 */
	reconnectTimeout: Terrasoft.reconnectTimeout,
	/**
	 * Maximum number of re-connections.
	 * @type {Number}
	*/
	maxReconnectCount: Terrasoft.maxReconnectCount,

	/**
	 * Current number of re-connections.
	 * @type {Number}
	*/
	reconnectCount: 0,

	/**
	 * Flag to track if session end notification is already in progress.
	 * @type {Boolean}
	 * @private
	 */
	_sessionEndNotificationInProgress: false,

	/**
	 * Default class for msg provider.
	 * @private
	 * @type {String}
	 */
	_defaultMsgProviderClass: "Terrasoft.WebSocketChannel",

	/**
	 * Class of the message provider that is when the server channel is disabled.
	 * @private
	 * @type {String}
	 */
	_stubMsgProviderClass: "Terrasoft.MessageChannelStub",

	/**
	 * Checks if the system is running in the embedded mode. When true, the server channel should be turned off.
	 */
	_isEmbeddedMode: function() {
		if (window.parent === window) {
			return false;
		}
		const urlParams = new URLSearchParams(window.location.search);
		return urlParams.has('embedded');
	},

	/**
	* Handles command message.
	* @private
	* @param {Object} msg Server channel message.
	*/
	commandMsgHandler: function(msg) {
		try {
			this.log("Server said: " + msg.Body);
			this.fireEvent(Terrasoft.EventName.ON_MESSAGE, this, msg);
		} catch (catchedException) {
			this.log("Error in command handler:" + catchedException);
		}
	},

	/**
	 * Handles broadcast messages.
	 * @private
	 * @param {Object} channelMsg Server channel message.
	 */
	broadcastMsgHandler: function(channelMsg) {
		const broadcastMessage = Terrasoft.decode(channelMsg.Body);
		this.fireEvent(Terrasoft.ServerChannelSender.BROADCAST_MESSAGE, this, broadcastMessage);
	},

	/**
	 * @private
	 */
	_ptpMsgHandler: function(channelMsg) {
		const message = Terrasoft.decode(channelMsg.Body);
		this.fireEvent(Terrasoft.ServerChannelSender.PTP_MESSAGE, this, message);
	},

	/**
	 * Makes routing of received message.
	 * @private
	 * @param {Object} msg Server channel message.
	 */
	_translateDecodedMessage: function(msg) {
		const senderName = this.getSenderName(msg);
		switch (senderName) {
			case Terrasoft.ServerChannelSender.COMMAND_SERVICE:
				this.commandMsgHandler(msg);
				break;
			case Terrasoft.ServerChannelSender.BROADCAST_MESSAGE:
				this.broadcastMsgHandler(msg);
				break;
			case Terrasoft.ServerChannelSender.PTP_MESSAGE:
				this._ptpMsgHandler(msg);
				break;
			default:
				this.fireEvent(Terrasoft.EventName.ON_MESSAGE, this, msg);
		}
	},

	/**
	 * Internal message handler called by messaging provider.
	 * @param {String/Object} msg A server message.
	 * @private
	 */
	_channelMsgHandler: function(msg) {
		if (this.msgProvider.hasOwnSerializer) {
			this._translateDecodedMessage(msg);
			return;
		}
		let jsonMsg;
		try {
			jsonMsg = Ext.decode(msg);
		} catch (caughtException) {
			this.log("Error on server msg decoding:" + caughtException);
		} finally {
			this._translateDecodedMessage(jsonMsg);
		}
	},

	/**
	 * Returns sender name.
	 * @param {Object} channelMessage Server channel message.
	 * @return {String|null}
	 */
	getSenderName: function(channelMessage) {
		return channelMessage && channelMessage.Header.Sender;
	},

	_getAccessToken: function() {
		return localStorage.getItem('accessToken');
	},

	_getAccessTokenFactory: function() {
		return Terrasoft.isAngularHost && this._getAccessToken()
			? () => this._getAccessToken()
			: null;
	},

	/**
	 * Creates server bi-directional communication channel.
	 */
	constructor: function() {
		const providerConfig = {
			serviceUrl: Terrasoft.serviceUrl,
			accessTokenFactory: this._getAccessTokenFactory(),
		};
		this.reconnectCount = 0;
		const msgProviderClass = this.isEnabled()
			? Terrasoft.serverChannelMsgProviderClass || this._defaultMsgProviderClass
			: this._stubMsgProviderClass;
		const msgProvider = Ext.create(msgProviderClass, providerConfig);
		const config = {
			msgProvider: msgProvider
		};
		this.callParent([config]);
		msgProvider.on(Terrasoft.EventName.ON_CHANNEL_CLOSED, this.providerChannelClosedHandler, this);
		msgProvider.on(Terrasoft.EventName.ON_CONNECTION_INITIALIZED, this.providerChannelOpenedHandler, this);
		msgProvider.on(Terrasoft.EventName.ON_MESSAGE, this.providerChannelMsgEventHandler, this);
	},

	checkAuth: function (tryReconnect) {
		const baseUrl = Terrasoft.loaderBaseUrl.endsWith("/") ? Terrasoft.loaderBaseUrl.slice(0, -1) : Terrasoft.loaderBaseUrl;
		const options = {
			url: baseUrl + "/ServiceModel/AuthService.svc/GetIsAuthenticated",
			headers: {
				"Content-Type": "application/json",
				"Accept": "application/json"
			},
			method: "POST",
			scope: this,
			callback: function (request, success, response) {
				if (success) {
					const responseData = Ext.decode(response.responseText);
					if (responseData.isAuthenticated) {
						tryReconnect();
					} else {
						if (this._sessionEndNotificationInProgress) {
							this.log("Session end notification already in progress, skipping duplicate call");
							return;
						}
						this._sessionEndNotificationInProgress = true;
						if (!Terrasoft.isAngularHost) {
							Terrasoft.SessionEndUserNotification.notifySessionEnd();
						} else {
							const observable = window.SessionEndNotifier.notifySessionEnd(
								Terrasoft.Resources.SessionEndUserNotification.Message);
							if (observable && typeof observable.subscribe === 'function') {
								observable.subscribe({
									error: function(error) {
										console.error('Session end notification error:', error);
										this._sessionEndNotificationInProgress = false;
									}.bind(this),
									complete: function() {
										this._sessionEndNotificationInProgress = false;
										console.log('Session end notification observable completed');
									}.bind(this)
								});
							} else {
								this._sessionEndNotificationInProgress = false;
							}
						}
					}
				}
			},
			jsonData: {},
			securitySensitiveFields: []
		};
		if (!this._sessionEndNotificationInProgress) {
			Terrasoft.AjaxProvider.request(options);
		} else {
			this.log("Session end notification in progress, skipping reconnect attempt");
		}
	},

	tryReconnect: function () {
		if (this.reconnectCount < this.maxReconnectCount) {
			const action = () => {
				this.init();
				this.reconnectCount++;
			};
			Terrasoft.checkAuthOnTryReconnect ? this.checkAuth(action) : action();
		} else {
			this.log("Max reconnect count exceeded. Reload page after the server will be available");
		}
	},

	/**
	 * Internal handler for closing the connection. Initializes an attempt to reconnect to the server.
	 * @protected
	 */
	providerChannelClosedHandler: function() {
		const currentMoment = new Date();
		this.log(currentMoment + " Channel closed. Reconnect..");
		if (Terrasoft.useReconnectWithTimeout) {
			setTimeout(() => this.tryReconnect(), this.reconnectTimeout)
		} else {
			this.tryReconnect();
		}
	},

	/**
	 * Channel opened event handler.
	 * @protected
	 */
	providerChannelOpenedHandler: function() {
		this.reconnectCount = 0;
	},

	/**
	 * Internal message handler called by messaging provider.
	 * @param {String/Object} msg A server message.
	 * @deprecated 7.14.2
	 * @protected
	 */
	channelMsgHandler: function(msg) {
		this._channelMsgHandler(msg);
	},

	/**
	 * Provider message event handler.
	 * @param {Object} scope The scope.
	 * @param {String|Object} msg The object that contains the server message.
	 * @protected
	 * @override
	 */
	providerChannelMsgEventHandler: function(scope, msg) {
		this._channelMsgHandler(msg);
	},

	/**
	 * Returns provider connection state.
	 * @return {Terrasoft.SocketConnectionState}
	 */
	getConnectionState: function() {
		return this.msgProvider.getConnectionState();
	},

	/**
	 * Creates a message object.
	 * @return {Object} The message object of the established basic format.
	 */
	createMessageObject: function() {
		return {
			Id: Terrasoft.generateGUID(),
			Header: {
				Sender: "",
				BodyTypeName: ""
			},
			Body: null
		};
	},

	/**
	 * Sends the ping command.
	 */
	ping: function() {
		this.msgProvider.ping();
	},

	/**
	 * Sends the channel message in OneWay mode.
	 * @param {Object} msg A message to send.
	  */
	postMessage: function(msg) {
		const encodedMsg = this.msgProvider.hasOwnSerializer ? msg : Terrasoft.encode(msg);
		this.callParent([encodedMsg]);
	},

	/**
	 * Sends broadcast message.
	 * @param {Object} msg Message config.
	 */
	broadcastMessage: function(msg) {
		const msgToSend = {
			Id: Terrasoft.generateGUID(),
			Header: {
				Sender: Terrasoft.ServerChannelSender.BROADCAST_MESSAGE,
				BodyTypeName: "System.String"
			},
			Body: Terrasoft.encode(msg)
		};
		this.postMessage(msgToSend);
	},

	/**
	 * Returns broadcast message.
	 * @param {String} channelMessage Server channel message.
	 * @return {Object|null}
	 * @deprecated
	 */
	getBroadcastMessage: function(channelMessage) {
		let message = null;
		const senderName = this.getSenderName(channelMessage);
		if (senderName === Terrasoft.ServerChannelSender.BROADCAST_MESSAGE) {
			const bodyObject = Terrasoft.decode(channelMessage.Body);
			if (!Terrasoft.isEmptyObject(bodyObject)) {
				message = bodyObject;
			}
		}
		return message;
	},

	/**
	 * Initializes server connection.
	 */
	init: function() {
		try {
			const accessTokenFactory = this._getAccessTokenFactory();
			this.msgProvider.init(accessTokenFactory);
		} catch (error) {
			this.log(error);
		}
	},

	/**
	 * Determines whether the server channel should be enabled.
	 */
	isEnabled: function() {
		return !this._isEmbeddedMode();
	}
});
