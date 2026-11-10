Terrasoft.configuration.Structures["BR7xConditionModuleLoader"] = {innerHierarchyStack: ["BR7xConditionModuleLoader"]};
define("BR7xConditionModuleLoader", ["ext-base", "terrasoft", "IFramePageLoader", "AngularPostMessageConnector",
	 "css!BR7xConditionModuleLoader"], function() {

	Ext.define("Terrasoft.configuration.BR7xConditionModuleLoader", {
		extend: "Terrasoft.IFramePageLoader",
		alternateClassName: "Terrasoft.BR7xConditionModuleLoader",

		messageChannelName: "br7x-condition-designer-channel",

		requestConfigMessageName: 'RequestBR7xCondition',

		responseConfigMessageName: 'ResponseBR7xCondition',

		initFrameConfigRequests: [],

		getSandboxMessages: function() {
			const messages = this.callParent(arguments);
			return Ext.apply(messages || {}, {
				"GetModuleConfigDesigner": {
					mode: Terrasoft.MessageMode.PTP,
					direction: Terrasoft.MessageDirectionType.SUBSCRIBE
				},
				"GetModuleConfigResultDesigner": {
					mode: Terrasoft.MessageMode.PTP,
					direction: Terrasoft.MessageDirectionType.PUBLISH
				},
				"DataChanged": {
					mode: Terrasoft.MessageMode.PTP,
					direction: Terrasoft.MessageDirectionType.SUBSCRIBE
				},
			});
		},

		initFrameConfig: function(callback, scope) {
			Ext.callback(callback, scope);
			this.messageChannel.on(this.responseConfigMessageName, this.onConfigSet, this);
		},

		onConfigSet(config) {
			this.initFrameConfigRequests.push(config);
			if (this.initFrameConfigRequests.length == 1) {
				this.initialConfig = config;
				const schemaDesignerId = this.getLoaderModuleId();
				this.sandbox.publish("GetModuleConfigResultDesigner", config, [schemaDesignerId]);
			}
		},

		loadContent: function(renderTo) {
			const body = Ext.getBody();
			body.set({ "maskState": "none" });
			this.callParent(arguments);
			this.sandbox.loadModule("BaseSchemaModuleV2", {
				keepAlive: true,
				renderTo: renderTo,
				id: this.getLoaderModuleId(),
				instanceConfig: {
					useHistoryState: false,
					isSchemaConfigInitialized: true,
					schemaName: "BR7xConditionDesigner",
				}
			});
		},

		getLoaderModuleId: function() {
			return this.sandbox.id + "_BR7xConditionDesigner";
		},

		subscribeSandboxMessages: function() {
			const schemaDesignerId = this.getLoaderModuleId();
			this.sandbox.subscribe("DataChanged", function (result) {
				this.initialConfig = result;
				this.messageChannel.sendMessage("SaveWidgetConfig", this.initialConfig);
			}, this, [schemaDesignerId]);
			this.sandbox.subscribe("ModalOpening", function() {
				this.messageChannel.sendMessage("ModalOpening");
			}, this, [schemaDesignerId]);
			this.sandbox.subscribe("PageLoaded", function() {
				const request = this.initFrameConfigRequests.pop();
				if (this.initFrameConfigRequests.length === 0) {
					this.messageChannel.sendMessage("DesignerLoaded");
				} else {
					this.initFrameConfigRequests = [];
					this.onConfigSet(request);
				}
			}, this, [schemaDesignerId]);
		}
	});

	return Terrasoft.BR7xConditionModuleLoader;
});


