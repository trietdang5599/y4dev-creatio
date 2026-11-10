/**
 */
Ext.define("Terrasoft.core.SessionEndUserNotification", {
	extend: "Terrasoft.BaseObject",
	alternateClassName: "Terrasoft.SessionEndUserNotification",
	singleton: true,

	sessionExpired: false,
	
	isSessionEndNotificationShown: false,

	constructor: function() {
		this.callParent(arguments);
		this._trySubsribeOnServerChannelMessage();
	},

	_trySubsribeOnServerChannelMessage: function() {
		if (!Terrasoft || Terrasoft.showSessionEndNotification === undefined
				|| Terrasoft.useExpiredSoonNotification === undefined) {
			window.setTimeout(this._trySubsribeOnServerChannelMessage.bind(this), 5 * 1000);
			return;
		}
		if (!Terrasoft.isAngularHost && Terrasoft.showSessionEndNotification) {
			Terrasoft.ServerChannel.on(Terrasoft.EventName.ON_MESSAGE, this._handleServerChannelSessionEndMessage, this);
		}
		if (!Terrasoft.isAngularHost && Terrasoft.useExpiredSoonNotification) {
			Terrasoft.ServerChannel.on(Terrasoft.EventName.ON_MESSAGE, this._handleServerChannelSessionEndSoonMessage, this);
		}
	},

	_handleServerChannelSessionEndMessage: function(channel, message) {
		if (!message || message.Header.Sender !== "WebApp" || message.Header.BodyTypeName !== "SessionEnd") {
			return;
		}
		var body;
		try {
			body = JSON.parse(message.Body);
		} catch (exception) {
			this.error("[SessionEnd]. Error occured. Message = [" + message.Body + "]");
			return;
		}
		var currentSessionId = Terrasoft.sessionId;
		var sessionIdPropertyName = "SessionId";
		var receivedSessionId = body[sessionIdPropertyName];
		this.log("[SessionEnd]. Current = [" + currentSessionId + "]. Received = [" + receivedSessionId + "]");
		if (currentSessionId && receivedSessionId !== currentSessionId) {
			return;
		}
		Terrasoft.ServerChannel.un(Terrasoft.EventName.ON_MESSAGE, this._handleServerChannelSessionEndMessage, this);
		this.sessionExpired = true;
		this._informationAndReload();
	},

	_handleServerChannelSessionEndSoonMessage: function(channel, message) {
		if (!message || message.Header.Sender !== "WebApp" || message.Header.BodyTypeName !== "SessionEndSoon") {
			return;
		}
		let body;
		try {
			body = JSON.parse(message.Body);
		} catch (exception) {
			this.error("[SessionEndSoon]. Error occured. Message = [" + message.Body + "]");
			return;
		}
		const currentSessionId = Terrasoft.sessionId;
		const sessionIdPropertyName = "SessionId";
		const receivedSessionId = body[sessionIdPropertyName];
		this.log("[SessionEndSoon]. Current = [" + currentSessionId + "]. Received = [" + receivedSessionId + "]");
		if (currentSessionId && receivedSessionId !== currentSessionId) {
			return;
		}
		this._stayOrLogout(body.Message);
	},

	_informationAndReload: function() {
		var config = {
			buttons: [
				{
					className: "Terrasoft.Button",
					caption: Terrasoft.Resources.SessionEndUserNotification.ConfirmationButtonCaption,
					markerValue: "dialogLoginBtn",
				}
			]
		};
		Terrasoft.showInformation(Terrasoft.Resources.SessionEndUserNotification.Message, function() {
			location.reload();
		}, this, config);
	},

	_logoutAndReload: function() {
		Terrasoft.AjaxProvider.request({
			url: Terrasoft.combinePath(Terrasoft.workspaceBaseUrl, "rest/MainMenuService/Logout"),
			method: "POST",
			callback: () => {
				this.sessionExpired = true;
				location.reload();
			}
		});
	},

	_stayOrLogout: function(message) {
		if (!this.isSessionEndNotificationShown) {
			this.isSessionEndNotificationShown = true;
			let logoutButton = Terrasoft.getButtonConfig("logout", Terrasoft.Resources.SessionEndSoonUserNotification.LogoutButtonCaption);
			let stayButton = Terrasoft.getBlueButtonConfig("stay", Terrasoft.Resources.SessionEndSoonUserNotification.StayLoggedInButtonCaption);
			Terrasoft.showConfirmation(message, function(returnCode) {
				this.isSessionEndNotificationShown = false;
				if (returnCode === "logout" ) {
					Terrasoft.ServerChannel.un(Terrasoft.EventName.ON_MESSAGE, this._handleServerChannelSessionEndSoonMessage, this);
					this._logoutAndReload();
				}
				return Terrasoft.AjaxProvider.request({
					url: Terrasoft.combinePath(Terrasoft.workspaceBaseUrl, "api/ShellSession/KeepAlive"),
					method: "POST",
					callback: (_, success) => {
						if (!success) {
							this.sessionExpired = true;
							location.reload();
						}
					}
				});
			}, [logoutButton, stayButton], this);
		}
	},

	notifySessionEnd: function() {
		Terrasoft.ServerChannel.un(Terrasoft.EventName.ON_MESSAGE, this._handleServerChannelSessionEndMessage, this);
		this.sessionExpired = true;
		this._informationAndReload();
	}

});
