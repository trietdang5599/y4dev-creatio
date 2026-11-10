define("OutdatedModuleWatcher", [], function() {
	/**
	 * Outdated module watcher.
	 */
	Ext.define("Terrasoft.OutdatedModuleWatcher", {
		extend: "Terrasoft.BaseModule",
		Ext: null,
		sandbox: null,
		Terrasoft: null,

		//region Methods: Private

		/**
		 * Requires module descriptor.
		 * @private
		 * @param {String} moduleName Module name.
		 */
		_forceRequireModuleDescriptors: function(moduleName) {
			if (Terrasoft.useStaticFileContent) {
				this._resetBundleRequireConfig();
			}
			if (Terrasoft.useParallelSchemaBuilding) {
				const structures = Terrasoft.configuration.Structures || {};
				delete structures[moduleName];
			}
			require.undef(moduleName);
			require.undef(moduleName + "Resources");
			this.sandbox.requireModuleDescriptors(["force!" + moduleName], Terrasoft.emptyFn, this);
		},

		/**
		 * Resets bundle require config.
		 * @private
		 */
		_resetBundleRequireConfig: function() {
			Terrasoft.SchemaManagerEventObserver.resetBundleRequireConfig();
		},

		//endregion

		//region Methods: Protected

		/**
		 * @inheritdoc Terrasoft.BaseViewModule#constructor
		 * @override
		 */
		constructor: function() {
			this.callParent(arguments);
			Terrasoft.ServerChannel.on(Terrasoft.ServerChannelSender.BROADCAST_MESSAGE,
				this.onBroadcastServerMessage, this);
			Terrasoft.ServerChannel.on(Terrasoft.EventName.ON_MESSAGE,
				this.onConfigurationBuildMessageReceived, this);
		},

		/**
		 * Handles the broadcast server message.
		 * @protected
		 * @param {Terrasoft.ServerChannel} channel Channel messaging server BPMonline.
		 * @param {Object} broadcastMessage Broadcast message.
		 */
		onBroadcastServerMessage: function(channel, broadcastMessage) {
			if (broadcastMessage) {
				var moduleName = broadcastMessage.name;
				switch (broadcastMessage.event) {
					case "ClientUnitSchema_Outdated":
					case "EntitySchema_Outdated":
						this._forceRequireModuleDescriptors(moduleName);
						break;
					default:
						return;
				}
			}
		},

		/**
		 * Handles the message of configuration build process.
		 * @param {Terrasoft.ServerChannel} channel Channel messaging server.
		 * @param {Object} message Channel message.
		 */
		onConfigurationBuildMessageReceived: function(channel, message) {
			if (!Terrasoft.useStaticFileContent || !message) {
				return;
			}
			if (message.Header.Sender === "ConfigurationBuildCompleted") {
				var decodedMessage = Terrasoft.decode(message.Body || "{}");
				if (decodedMessage.configurationHash) {
					Terrasoft.configurationContentHash = decodedMessage.configurationHash;
				}
			}
		}

		//endregion

	});

	return Terrasoft.OutdatedModuleWatcher;
});
