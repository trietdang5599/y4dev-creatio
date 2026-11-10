define("AppLoadWatcherSchema", [],
	function() {
		return {
			messages: {
				/**
				 * @message ReloadApplication
				 * Notification that has been received information about reloading application.
				 */
				"ReloadApplication": {
					"mode": this.Terrasoft.MessageMode.BROADCAST,
					"direction": this.Terrasoft.MessageDirectionType.SUBSCRIBE
				}
			},
			methods: {

				/**
				 * @private
				 */
				_reloadBrowser: function() {
					window.location.reload(true);
				},

				/**
				 * @private
				 */
				_getMaskConfig: function(caption) {
					var config = {
						clearMasks: true,
						timeout: 0,
						caption: caption
					};
					return config;
				},

				/**
				 * Subscribes for the messages.
				 * @private
				 */
				_subscribeMessages: function() {
					this.sandbox.subscribe("ReloadApplication", this.reloadClientApplication, this);
				},

				/**
				 * Inform client about reloading application and reload client window.
				 * @protected
				 */
				reloadClientApplication: function() {
					this.showBodyMask(this._getMaskConfig(this.get("Resources.Strings.ApplicationReloading")));
					this._reloadBrowser();
				},

				/**
				 * @inheritDoc Terrasoft.BaseViewModel#init
				 * @overridden
				 */
				init: function() {
					this.callParent(arguments);
					this._subscribeMessages();
				}

			}
		};
	});
