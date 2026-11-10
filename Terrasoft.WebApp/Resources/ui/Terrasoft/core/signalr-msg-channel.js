/**
 * The transport layer of the asynchronous receive and send data to a server with SignalR abstraction.
 */
Ext.define("Terrasoft.core.SignalRChannel", {
	extend: "Terrasoft.core.MsgChannel",
	alternateClassName: "Terrasoft.SignalRChannel",

	/**
	 * SignalR hub connection instance.
	 * @type {Object}
	 */
	connection: null,

	/**
	 * Address of the SignalR hub service.
	 * @type {String}
	 */
	serviceUrl: null,

	/**
	 * Factory function to generate access tokens for WebSocket authentication.
	 * @type {Function|null}
	 */
	accessTokenFactory: null,

	/**
	 * Flag shows that SignalR automatically encode/decode messages.
	 * @override
	 * @type {Boolean}
	 */
	hasOwnSerializer: true,

	/**
	 * Known connection state of SignalR channel.
	 * @type {Terrasoft.SocketConnectionState}
	 */
	state: Terrasoft.SocketConnectionState.NOT_INITIALIZED,

	/**
	 * Guards to prevent duplicate handlers and concurrent start() calls.
	 * @private
	 */
	_startInProgress: false,
	_onCloseRegistered: false,

	/**
	 * It creates and initializes the object {@link Terrasoft.SignalRChannel}.
	 * @param {Object} config Configuration object.
	 */
	constructor: function(config) {
		this.callParent(arguments);
		this.addEvents(
			/**
			 * @event Terrasoft.EventName.ON_CONNECTION_INITIALIZED
			 * Triggered when SignalR hub connected.
			 */
			Terrasoft.EventName.ON_CONNECTION_INITIALIZED,
			/**
			 * @event Terrasoft.EventName.ON_ERROR
			 * Triggered when error connect to hub failed.
			 */
			Terrasoft.EventName.ON_ERROR
		);
		if (config.serviceUrl) {
			this.serviceUrl = config.serviceUrl;
			this.init();
		}
	},

	/**
	 * Sets inner handlers for SignalR hub.
	 * @private
	 */
	_setupSignalRHandlers: function() {
		this.connection.off("ServerMessage");
		this.connection.on("ServerMessage", this.channelMsgHandler.bind(this));
		if (!this._onCloseRegistered) {
			this.connection.onclose(this.channelClosedHandler.bind(this));
			this._onCloseRegistered = true;
		}
		if (this.state === Terrasoft.SocketConnectionState.OPEN || this._startInProgress) {
			return;
		}
		this._startInProgress = true;
		this.connection.start()
			.then(() => {
				this._startInProgress = false;
				this.onConnectionStarted();
			})
			.catch((err) => {
				this._startInProgress = false;
				this.onConnectionError(err);
			});
	},

	/**
	 * Internal handler for closing source channel.
	 * @override
	 * @protected
	 */
	channelClosedHandler: function() {
		this.state = Terrasoft.SocketConnectionState.CLOSED;
		this._startInProgress = false;
		this.connection.off("ServerMessage");
		this.callParent();
	},

	/**
	 * Inner handler for hub connection started event.
	 * @protected
	 */
	onConnectionStarted: function() {
		this.log("SignalR hub connected for url: " + this.serviceUrl);
		this.state = Terrasoft.SocketConnectionState.OPEN;
		this.fireEvent(Terrasoft.EventName.ON_CONNECTION_INITIALIZED, this);
	},

	/**
	 * Inner handler for error websocket connection event.
	 * @protected
	 */
	onConnectionError: function() {
		this.state = Terrasoft.SocketConnectionState.CLOSED;
		this.fireEvent(Terrasoft.EventName.ON_ERROR, this);
		this.fireEvent(Terrasoft.EventName.ON_CHANNEL_CLOSED, this);
	},

	/**
	 * Returns connection state.
	 * @return {Terrasoft.SocketConnectionState}
	 */
	getConnectionState: function() {
		return this.state;
	},

	/**
	 * Initializes connection.
	 */
	init: function() {
		const signalR = Ext.global.signalR;
		if (signalR) {
			this._buildSignalRConnection(signalR);
			return;
		}
		Terrasoft.require(["signalr"], this._buildSignalRConnection, this);
	},

	_buildSignalRConnection: function(signalR) {
		if (!this.connection) {
			const options= this.accessTokenFactory
				? {
					accessTokenFactory: this.accessTokenFactory,
					withCredentials: true,
				}
				: undefined;
			this.connection = new signalR.HubConnectionBuilder()
				.withUrl(this.serviceUrl, options)
				.build();
			this._onCloseRegistered = false;
			this._startInProgress = false;
		}
		this.state = Terrasoft.SocketConnectionState.CONNECTING;
		this._setupSignalRHandlers();
	},

	/**
	 * @private
	 */
	_invoke: function(methodName, msg = null) {
		// TODO RND-35574
		if (Terrasoft.isAngularHost && Zone.current.name === "navigation") {
			Zone.current.parent.run(() => {
				this.connection.invoke(...arguments);
			});
		} else {
			this.connection.invoke(...arguments);
		}
	},

	/**
	 * Stops hub connection.
	 */
	close: function() {
		if (this.connection) {
			this._startInProgress = false;
			this.connection.stop();
			this.connection.off("ServerMessage");
		}
	},

	/**
	 * Sends the ping command.
	 */
	ping: function() {
		this._invoke.call(this, "Ping");
	},

	/**
	 * Sends message to the server hub in OneWay mode.
	 * @param {String} msg Message. Data contract - IMsg.
	 */
	postMessage: function(msg) {
		this._invoke.call(this, "SendMessage", msg);
	},

	/**
	 * Sends raw message to the server hub in OneWay mode.
	 * @param {Object} msg Message.
	 */
	postRawMessage: function(msg) {
		this._invoke.call(this, "SendRawMessage", msg);
	}
});

/**
 * Returns channel state.
 * @return {Boolean}
 */
Object.defineProperty(Terrasoft.core.SignalRChannel.prototype, "isOpened", {
	get: function() {
		return this.getConnectionState() === Terrasoft.SocketConnectionState.OPEN;
	}
});