Terrasoft.configuration.Structures["MergeRecordsResolveConflictsModuleLoader"] = {innerHierarchyStack: ["MergeRecordsResolveConflictsModuleLoader"]};
  define("MergeRecordsResolveConflictsModuleLoader", ["ext-base", "terrasoft", "IFramePageLoader", "AngularPostMessageConnector",
	 "DuplicatesMergeHelper", "css!MergeRecordsResolveConflictsModuleLoader"], function () {

		Ext.define("Terrasoft.configuration.MergeRecordsResolveConflictsModuleLoader", {
			extend: "Terrasoft.IFramePageLoader",
			alternateClassName: "Terrasoft.MergeRecordsResolveConflictsModuleLoader",

			messageChannelName: "merge-records-conflicts-resolver-channel",
			requestConfigMessageName: 'RequestMergeRecordsConflicts',
			responseConfigMessageName: 'ResponseMergeRecordsConflicts',

			/**
			 * @inheritDoc
			 * @overridden
			 */
			getSandboxMessages: function () {
				const messages = this.callParent(arguments);
				return Ext.apply(messages || {}, {
					"Initialized": {
						mode: Terrasoft.MessageMode.PTP,
						direction: Terrasoft.MessageDirectionType.SUBSCRIBE
					},
					"DataChanged": {
						mode: Terrasoft.MessageMode.PTP,
						direction: Terrasoft.MessageDirectionType.SUBSCRIBE
					},
				})
			},

			/**
			 * @inheritDoc
			 * @overridden
			 */
			subscribeSandboxMessages: function () {
				const moduleId = this.getLoaderModuleId();
				this.sandbox.subscribe("Initialized", () => {
					this.messageChannel.sendMessage("DesignerLoaded");
				}, this, [moduleId]);
				this.sandbox.subscribe("DataChanged", (result) => {
					this.messageChannel.sendMessage("SaveMergeRecordsConflicts", {
						resolvedConflicts: result
					});
				}, this, [moduleId]);
			},

			/**
			 * @inheritDoc
			 * @overridden
			 */
			getLoaderModuleId: function () {
				return this.sandbox.id + "_" + "DuplicatesMergeFreedomUIModule";
			},

			/**
			 * @inheritDoc
			 * @overridden
			 */
			loadContent: function (renderTo) {
				this.callParent(arguments);
				require([this.initialConfig.schemaName], () => {
					const duplicatesMergeHelper = Ext.create("Terrasoft.DuplicatesMergeHelper");
					duplicatesMergeHelper.entitySchemaName = this.initialConfig.schemaName;
					const mergeModuleParameters = duplicatesMergeHelper.getMergeModuleConfig(this.initialConfig.conflicts);
					mergeModuleParameters.schemaName = this.initialConfig.schemaName;
					this.sandbox.loadModule("DuplicatesMergeFreedomUIModule", {
						id: this.getLoaderModuleId(),
						keepAlive: true,
						renderTo: renderTo,
						parameters: {
							config: mergeModuleParameters
						}
					});
				});
			}
		});

		return Terrasoft.MergeRecordsResolveConflictsModuleLoader;
	});


