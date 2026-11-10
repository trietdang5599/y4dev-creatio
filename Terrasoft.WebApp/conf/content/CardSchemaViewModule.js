Terrasoft.configuration.Structures["CardSchemaViewModule"] = {innerHierarchyStack: ["CardSchemaViewModule"]};
define("CardSchemaViewModule", ["@creatio-devkit/common", "ConfigurationEnums", "BaseSchemaViewModule",
		"HistoryStateUtilities"], function(devkit, ConfigurationEnums) {
	Ext.define("Terrasoft.configuration.CardSchemaViewModule", {
		alternateClassName: "Terrasoft.CardSchemaViewModule",
		extend: "Terrasoft.BaseSchemaViewModule",

		mixins: {
			historyStateUtilities: "Terrasoft.HistoryStateUtilities"
		},

		/**
		 * @protected
		 */
		componentSelector: "crt-card-component",
		/**
		 * @protected
		 */
		componentWrapSelector: "crt-card",

		_cardResponseHandler: null,

		/**
		 * @protected
		 */
		cardState: null,

		/**
		 * @private
		 */
		_getActionDashboardPageName: function() {
			return "ActionDashboardComponentPage";
		},

		/**
		 * @private
		 */
		_onUpdateCard: async function(config) {
			const dataSourceName = await this.schemaState?.viewModel.getPrimaryModelName();
			let attributeName = this.schemaState?.viewModel.getViewModelAttributePath(dataSourceName, config.key);
			if (attributeName) {
				const values = {};
				values[attributeName] = config.value;
				this.schemaState?.viewModel.setValue(values);
			}
			if (config.options?.silent) {
				this._onSaveRecord(config);
			}
		},

		/**
		 * @private
		 */
		_onSaveRecord: function(config) {
			this.addCardResponseHandler(this.onSilentSaved, [config]);
			this.sendRequest("crt.SaveRecordRequest", {
				preventCardClose: true
			});
		},

		/**
		 * @private
		 */
		_onValidateCard: async function() {
			this.schemaState?.viewModel?.validate();
			return await this.schemaState?.viewModel?.isValid();
		},

		/**
		 * @protected
		 */
		applyCardResponseHandler: function() {
			if (this._cardResponseHandler) {
				const params = this._cardResponseHandler.params;
				this._cardResponseHandler.action.apply(this, params);
				this._cardResponseHandler = null;
			}
		},

		/**
		 * @protected
		 */
		addCardResponseHandler: function(action, params) {
			this._cardResponseHandler = {
				action: action.bind(this),
				params: params
			};
		},

		/**
		 * @inheritDoc Terrasoft.BaseSchemaViewModule#reloadPage
		 * @override
		 */
		reloadPage: function() {
			if (!this.schemaState?.viewModel ||
				this.cardState === Terrasoft.ConfigurationEnums.CardOperation.EDIT) {
				this.callParent(arguments);
			}
		},

		onCanBeDestroyed: function () {
			if (this.cardState === Terrasoft.ConfigurationEnums.CardOperation.EDIT) {
				this.callParent(arguments);
			}
		},

		/**
		 * @inheritDoc Terrasoft.BaseSchemaViewModule#getMessages
		 * @override
		 */
		getMessages: function () {
			const config = this.callParent(arguments);
			const messages = {
				"CardModuleResponse": {
					direction: this.Terrasoft.MessageDirectionType.PUBLISH,
					mode: this.Terrasoft.MessageMode.PTP
				},
				"UpdateDetail": {
					"mode": this.Terrasoft.MessageMode.PTP,
					"direction": this.Terrasoft.MessageDirectionType.PUBLISH
				},
				"UpdateParentLookupDisplayValue": {
					direction: this.Terrasoft.MessageDirectionType.PUBLISH,
					mode: this.Terrasoft.MessageMode.BROADCAST
				},
				"ValidateCard": {
					mode: this.Terrasoft.MessageMode.PTP,
					direction: this.Terrasoft.MessageDirectionType.SUBSCRIBE
				},
				"UpdateCardProperty": {
					mode: this.Terrasoft.MessageMode.PTP,
					direction: this.Terrasoft.MessageDirectionType.SUBSCRIBE
				},
				"SaveRecord": {
					mode: this.Terrasoft.MessageMode.PTP,
					direction: this.Terrasoft.MessageDirectionType.SUBSCRIBE
				},
				"GetOperation": {
					mode: Terrasoft.MessageMode.PTP,
					direction: Terrasoft.MessageDirectionType.SUBSCRIBE
				}
			};
			return Ext.apply(config, messages);
		},

		/**
		 * @protected
		 */
		onSilentSaved: function(config) {
			if (config.actions) {
				Terrasoft.each(config.actions, function(action) {
					action.fn?.call(action.scope);
				}, this);
			}
			const callback = config.callback;
			if (callback) {
				callback.call(config.scope || this, null, config);
			}
		},

		/**
		 * @inheritDoc Terrasoft.BaseSchemaViewModule#subscribeHandlers
		 * @protected
		 */
		subscribeHandlers: function () {
			this.callParent(arguments);
			const moduleRef = this;
			const handlerType = class extends devkit.BaseRequestHandler {
				handle(request) {
					switch (request.action) {
						case "CardResponse":
							const cardModuleResponse = {
								...request.payload,
								isInChain: moduleRef.isInChain
							};
							moduleRef.sandbox.publish("UpdateDetail", {
								primaryColumnValue: cardModuleResponse.primaryColumnValue
							}, [moduleRef.sandbox.id]);
							if (moduleRef.isInChain) {
								moduleRef.sandbox.publish("UpdateParentLookupDisplayValue", {
									referenceSchemaName: cardModuleResponse.referenceSchemaName,
									displayValue: cardModuleResponse.primaryDisplayColumnValue,
									value: cardModuleResponse.primaryColumnValue,
								});
							}
							if (cardModuleResponse.success) {
								moduleRef.applyCardResponseHandler();
							}
							// TODO RND-20385
							cardModuleResponse.isAngularPage = true;
							return moduleRef.sandbox.publish("CardModuleResponse", cardModuleResponse,
								[moduleRef.sandbox.id]);
						default:
							return this.next?.handle(request);
					}
				}
			};
			this.unsubscribesHandlers.push(
				this.handlerChain.register({
					requestType: "crt.7XRequest",
					createHandler: () => new handlerType(),
					source: { type: devkit.HandlerSourceType.Host },
					scopes: [],
				})
			);
		},

		/**
		 * @inheritDoc Terrasoft.BaseSchemaViewModule#onInitDataView
		 * @override
		 * @returns {Promise}
		 */
		onInitDataView: async function ({ payload }) {
			const { caption, hidePageCaption } = payload;
			this.headerCaption = caption;
			this.sandbox.publish("InitDataViews", {
				caption,
				hidePageCaption,
				moduleName: this.schemaName
			});
		},

		/**
		 * @inheritDoc Terrasoft.BaseSchemaViewModule#initSchemaName
		 * @protected
		 * @override
		 */
		initSchemaName: function() {
			const historyState = this.sandbox.publish("GetHistoryState");
			const state = historyState.state || {};
			this.isInChain = state.isInChain;
			if (this.Ext.isEmpty(state.schemaName) && !this.isInChain) {
				const historyStateInfo = this.getHistoryStateInfo();
				this.schemaName = historyStateInfo.schemas.pop();
				this.operation = historyStateInfo.operation;
				this.primaryColumnValue = historyStateInfo.primaryColumnValue;
			} else {
				if (state.entitySchemaName) {
					this.entitySchemaName = state.entitySchemaName;
				}
				this.schemaName = state.schemaName;
				this.operation = state.operation;
				this.primaryColumnValue = state.primaryColumnValue;
			}
		},

		/**
		 * @inheritDoc Terrasoft.BaseSchemaViewModule#init
		 * @override
		 */
		init: function() {
			this.callParent(arguments);
			this.sandbox.subscribe("ValidateCard", this._onValidateCard, this, [this._getActionDashboardPageName()]);
			this.sandbox.subscribe("SaveRecord", this._onSaveRecord, this, [this._getActionDashboardPageName()]);
			this.sandbox.subscribe("UpdateCardProperty", this._onUpdateCard, this,
				[this._getActionDashboardPageName()]);
		},

		/**
		 * @inheritDoc Terrasoft.BaseSchemaViewModule#destroy
		 * @override
		 */
		destroy: function() {
			this.callParent(arguments);
			this.sandbox.unsubscribePtp("UpdateCardProperty", [this._getActionDashboardPageName()]);
			this.sandbox.unsubscribePtp("SaveRecord", [this._getActionDashboardPageName()]);
			this.sandbox.unsubscribePtp("ValidateCard", [this._getActionDashboardPageName()]);
			this.sandbox.unsubscribePtp("GetOperation", []);
		},

		/**
		 * @inheritDoc Terrasoft.BaseSchemaViewModule#onSchemaStateGenerated
		 * @override
		 */
		onSchemaStateGenerated: function () {
			this.callParent(arguments);
			this.sandbox.subscribe("GetOperation", this.getOperation.bind(this.schemaState?.viewModel), this);
			const cardStatePromise = this.schemaState?.viewModel.CardState;
			if (cardStatePromise) {
				cardStatePromise.then((state) => {
					this.cardState = state;
				});
			}
		},

		/**
		 * @protected
		 */
		getOperation: async function () {
			return await this.CardState;
		}
	});
	return Terrasoft.CardSchemaViewModule;
});


