Terrasoft.configuration.Structures["RightsModuleLoader"] = {innerHierarchyStack: ["RightsModuleLoader"]};
 define("RightsModuleLoader", ["ext-base", "terrasoft", "IFramePageLoader", "AngularPostMessageConnector","css!RightsModuleLoader"], function () {

		Ext.define("Terrasoft.configuration.RightsModuleLoader", {
			extend: "Terrasoft.IFramePageLoader",
			alternateClassName: "Terrasoft.RightsModuleLoader",

			// TODO rename channel and message names.
			messageChannelName: "widget-designer-channel",
			requestConfigMessageName: "RequestWidgetConfig",
			responseConfigMessageName: "ResponseWidgetConfig",
			pageLoadedMessageName: "DesignerLoaded",
			modalClosingMessageName: "ESCPressed",
			recordRightsWereChangedMessageName: "RecordRightsWereChanged",

			/**
			 * @inheritDoc
			 * @overridden
			 */
			getSandboxMessages: function () {
				const messages = this.callParent(arguments);
				return Ext.apply(messages || {}, {
					"GetRecordInfo": {
						mode: Terrasoft.MessageMode.PTP,
						direction: Terrasoft.MessageDirectionType.SUBSCRIBE
					},
					"BackHistoryState": {
						mode: this.Terrasoft.MessageMode.BROADCAST,
						direction: this.Terrasoft.MessageDirectionType.SUBSCRIBE
					},
					"RecordRightsWereChanged": {
						mode: this.Terrasoft.MessageMode.PTP,
						direction: this.Terrasoft.MessageDirectionType.SUBSCRIBE
					},
				})
			},

			/**
			 * @inheritDoc
			 * @overridden
			 */
			subscribeSandboxMessages: function () {
				const rightsModuleId = this.getLoaderModuleId();
				this.sandbox.subscribe("GetRecordInfo", function() {
					const {
						entitySchemaName,
						entitySchemaCaption,
						primaryColumnValue,
						primaryDisplayColumnValue,
						hideAdditionalLookupButtons
					} = this.initialConfig;
					return {
						entitySchemaName,
						entitySchemaCaption,
						primaryColumnValue,
						primaryDisplayColumnValue,
						hideAdditionalLookupButtons
					};
				}, this, [rightsModuleId]);
				this.sandbox.subscribe("PageLoaded", () => {
					this.messageChannel.sendMessage(this.pageLoadedMessageName);
				}, this);
				this.sandbox.subscribe("BackHistoryState", function() {
					this.messageChannel.sendMessage(this.modalClosingMessageName);
				}, this);
				this.sandbox.subscribe("RecordRightsWereChanged", function() {
					this.messageChannel.sendMessage(this.recordRightsWereChangedMessageName);
				}, this, [rightsModuleId]);
			},

			/**
			 * @inheritDoc
			 * @overridden
			 */
			getLoaderModuleId: function () {
				return this.sandbox.id + "_" + "Rights";
			},

			/**
			 * @inheritDoc
			 * @overridden
			 */
			loadContent: function (renderTo) {
				this.callParent(arguments);
				this.sandbox.loadModule("Rights", {
					keepAlive: true,
					renderTo: renderTo,
					id: this.getLoaderModuleId()
				});
			}
		});

		return Terrasoft.RightsModuleLoader;
	});


