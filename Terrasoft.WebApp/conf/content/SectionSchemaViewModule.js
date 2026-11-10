Terrasoft.configuration.Structures["SectionSchemaViewModule"] = {innerHierarchyStack: ["SectionSchemaViewModule"]};
define("SectionSchemaViewModule", ["BaseSchemaViewModule"], function() {
	Ext.define("Terrasoft.configuration.SectionSchemaViewModule", {
		alternateClassName: "Terrasoft.SectionSchemaViewModule",
		extend: "Terrasoft.BaseSchemaViewModule",

		// region Fields: Protected

		/**
		 * @protected
		 */
		componentSelector: "crt-section-component",

		/**
		 * @protected
		 */
		componentWrapSelector: "crt-section",

		// endregion

		// region Method: Private

		/**
		 * @private
		 */
		_getSchemaCaption: function(entitySchemaName) {
			return (
				this.schemaName &&
				Terrasoft.ModuleUtils.getModuleStructureBySectionSchema(this.schemaName)?.moduleCaption
			) || Terrasoft.ModuleUtils.getModuleStructure(entitySchemaName)?.moduleCaption;
		},

		// endregion

		// region Method: Protected

		/**
		 * @inheritDoc Terrasoft.BaseSchemaViewModule#init
		 * @overridden
		 */
		init: function(callback, scope) {
			this.callParent([
				() => {
					const historyState = this.sandbox.publish("GetHistoryState");
					const {hash} = historyState;
					this.sandbox.publish("SelectedSideBarItemChanged", hash.historyState, ["sectionMenuModule"]);
					Ext.callback(callback, scope);
				}
			]);
		},

		/**
		 * @inheritDoc Terrasoft.BaseSchemaViewModule#initHistoryState
		 * @protected
		 * @overridden
		 */
		initHistoryState: function () {
			this.callParent(arguments);
			const currentState = this.sandbox.publish("GetHistoryState");
			const previousState = this.sandbox.publish("GetPreviousHistoryState");
			if (previousState?.state?.isInChain && !currentState?.state?.isInChain) {
				const newState = {
					moduleId: currentState?.state?.moduleId,
					modelInitConfigs: currentState?.state?.modelInitConfigs
				};
				this.sandbox.publish("ReplaceHistoryState", {
					hash: currentState.hash.historyState,
					stateObj: newState,
					silent: true
				});
			}
		},

		/**
		 * @inheritDoc Terrasoft.BaseSchemaViewModule#onInitDataView
		 * @overridden
		 * @returns {Promise}
		 */
		onInitDataView: async function ({ payload }) {
			const { entityName } = payload;
			const {hash} = this.sandbox.publish("GetHistoryState");
			const caption = this._getSchemaCaption(entityName);
			this.headerCaption = caption;
			const headerConfig = {
				isMainMenu: false,
				isLogoVisible: true,
				isCaptionVisible: true,
				isContextHelpVisible: true,
				hidePageCaption: true,
				caption,
				moduleName: this.schemaName
			};
			this.sandbox.publish("InitDataViews", headerConfig);
			this.sandbox.subscribe("NeedHeaderCaption", function () {
				this.sandbox.publish("InitDataViews", headerConfig);
				this.sandbox.publish("SelectedSideBarItemChanged", hash.historyState, ["sectionMenuModule"]);
			}, this);
		},

		/**
		 * @inheritdoc Terrasoft.BaseSchemaViewModule#prepareHistoryState
		 * @overridden
		 */
		prepareHistoryState: function() {
			const newState = this.callParent(arguments);
			delete newState.isSeparateMode;
			delete newState.schemaName;
			delete newState.entitySchemaName;
			delete newState.operation;
			delete newState.primaryColumnValue;
			delete newState.isInChain;
			delete newState.modelInitConfigs;
			return newState;
		},

		/**
		 * @inheritDoc Terrasoft.BaseSchemaViewModule#getMessages
		 * @overridden
		 */
		getMessages: function() {
			const config = this.callParent(arguments);
			const messages = {
				"NeedHeaderCaption": {
					direction: this.Terrasoft.MessageDirectionType.SUBSCRIBE,
					mode: this.Terrasoft.MessageMode.BROADCAST
				},
				"SelectedSideBarItemChanged": {
					mode: this.Terrasoft.MessageMode.PTP,
					direction: this.Terrasoft.MessageDirectionType.PUBLISH
				}
			};
			return Ext.apply(config, messages);
		},

		/**
		 * @inheritDoc Terrasoft.BaseSchemaViewModule#initSchemaName
		 * @protected
		 */
		initSchemaName: function() {
			const historyState = this.sandbox.publish("GetHistoryState");
			const hash = historyState.hash;
			const state = historyState.state;
			this.schemaName = state.cardSchemaName || hash.entityName || "";
		}

		// endregion

	});
	return Terrasoft.SectionSchemaViewModule;
});


