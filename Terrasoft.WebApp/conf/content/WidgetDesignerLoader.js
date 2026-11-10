Terrasoft.configuration.Structures["WidgetDesignerLoader"] = {innerHierarchyStack: ["WidgetDesignerLoader"]};
define("WidgetDesignerLoader", ["ext-base", "terrasoft", "IFramePageLoader"], function () {
	Ext.define("Terrasoft.configuration.WidgetDesignerLoader", {
		extend: "Terrasoft.IFramePageLoader",
		alternateClassName: "Terrasoft.WidgetDesignerLoader",

		messageChannelName: "widget-designer-channel",
		requestConfigMessageName: 'RequestWidgetConfig',
		responseConfigMessageName: 'ResponseWidgetConfig',

		/**
		 * @inheritDoc
		 * @overridden
		 */
		getSandboxMessages: function () {
			const messages = this.callParent(arguments);
			return Ext.apply(messages || {}, {
				"WidgetConfigChanged": {
					"direction": Terrasoft.MessageDirectionType.SUBSCRIBE,
					"mode": Terrasoft.MessageMode.BROADCAST
				},
				"GetModuleConfig": {
					"direction": Terrasoft.MessageDirectionType.SUBSCRIBE,
					"mode": Terrasoft.MessageMode.PTP
				}
			})
		},

		/**
		 * @inheritDoc
		 * @overridden
		 */
		subscribeSandboxMessages: function () {
			this.callParent(arguments);
			const widgetDesignerModuleId = this.getLoaderModuleId();
			this.sandbox.subscribe("GetModuleConfig", () => this.initialConfig, this, [widgetDesignerModuleId]);
			this.sandbox.subscribe("WidgetConfigChanged", ({ resources, ...config }) => {
				this.initialConfig.itemConfig.config = config;
				this.initialConfig.resources = resources;
				this.messageChannel.sendMessage("SaveWidgetConfig", {
					itemConfig: this.initialConfig.itemConfig,
					dataSourceConfig: this.initialConfig?.dataSourceConfig,
					resources
				});
			}, this, [widgetDesignerModuleId]);
		},

		/**
		 * @inheritDoc
		 * @ovveriden
		 */
		initFrameConfig: function (callback, scope) {
			this.messageChannel.on(this.responseConfigMessageName, function(config) {
				if (config?.dataSourceConfig) {
					config.itemConfig.sectionBindingColumnRecordId = "$Id";
				}
				this.initialConfig = config;
				Ext.callback(callback, scope);
			}, this);
			this.messageChannel.sendMessage(this.requestConfigMessageName);
		},
		
		/**
		 * @inheritDoc
		 * @overridden
		 */
		getLoaderModuleId: function () {
			return this.sandbox.id + "_" + this._getWidgetSchemaName();
		},

		/**
		 * @private
		 */
		_getWidgetSchemaName: function () {
			const search = window.location.search;
			const parameters = new URLSearchParams(search);
			const designSchemaName = parameters.get("designSchemaName");
			if (!designSchemaName) {
				throw new Terrasoft.ArgumentNullOrEmptyException({
					argumentName: "designSchemaName"
				});
			}
			return designSchemaName;
		},

		/**
		 * @inheritDoc
		 * @overridden
		 */
		loadContent: function (renderTo) {
			this.callParent(arguments);
			this.sandbox.loadModule("ConfigurationModuleV2", {
				id: this.getLoaderModuleId(),
				instanceConfig: {
					generateViewContainerId: false,
					useHistoryState: false,
					schemaName: this._getWidgetSchemaName(),
					isSchemaConfigInitialized: true
				},
				keepAlive: true,
				renderTo: renderTo,
			});
		}
		
	});

	return Terrasoft.WidgetDesignerLoader;
});


