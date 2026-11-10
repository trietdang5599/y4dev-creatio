Terrasoft.configuration.Structures["AngularAdapterModule"] = {innerHierarchyStack: ["AngularAdapterModule"]};
define("AngularAdapterModule", [
	"AngularAdapterModuleResources", "MaskHelper", "@creatio-devkit/common", "NetworkUtilities", "ModalBox", "BaseModule", "LookupManager",
	"ContextHelpMixin", "CtiLinkColumnUtility", "EmailLinksMixin", "LookupQuickAddMixin", "PageUtilities",
	"LoadRightsModuleMixin", "MiniPageUtilities", "NavigationHelper",
], function (resources, MaskHelper, devkit, NetworkUtilities, ModalBox) {
	Ext.define("Terrasoft.configuration.AngularAdapterModule", {
		alternateClassName: "Terrasoft.AngularAdapterModule",
		extend: "Terrasoft.BaseModule",
		mixins: {
			LookupQuickAddMixin: "Terrasoft.LookupQuickAddMixin",
			LoadRightsModuleMixin: "Terrasoft.LoadRightsModuleMixin",
			PageUtilities: "Terrasoft.PageUtilities",
			CtiLinkColumnUtility: "Terrasoft.CtiLinkColumnUtility",
			MiniPageUtilities: "Terrasoft.MiniPageUtilities",
			EmailLinksMixin: "Terrasoft.EmailLinksMixin",
			CustomEvent: "Terrasoft.mixins.CustomEventDomMixin"
		},

		/**
		 * @protected
		 */
		unsubscribesHandlers: null,

		/**
		 * @protected
		 */
		handlerChain: devkit.HandlerChainService.instance,

		/**
		 * Method to override dependency of BaseViewModel.
		 * @protected
		 */
		validateColumn: Terrasoft.emptyFn,

		showInformationDialog: Terrasoft.utils.showInformation,

		/**
		 * @private
		 */
		_cardResponseHandler: null,

		/**
		 * @private
		 */
		_schemaStateGeneratedSubscription: null,

		/**
		 * @private
		 */
		_addRecordFromLookup: function ({ payload, $context }) {
			const { attributeName, entityName, displayColumn, displayValue, defaultValues, allowEmptyDisplayValue }
				= payload;
			this._addValueToLookup({
					entitySchemaName: entityName,
					inputedValue: displayValue,
					isNewValue: true,
					value: Terrasoft.GUID_EMPTY,
					additionalDefaultValues: defaultValues,
					allowEmptyDisplayValue
				},
				displayColumn,
				attributeName,
				$context);
		},

		/**
		 * @private
		 */
		_addValueToLookup: function(newValue, columnName, attributeName, viewModel) {
			this.setValueToLookupInfoCache(columnName, "filterValue", newValue.inputedValue);
			this.mixins.LookupQuickAddMixin.onLookupChange.call(this, newValue, columnName, attributeName, function() {}, viewModel);
		},

		/**
		 * Handles email link click.
		 * @private
		 */
		_handleEmailLinkClick: function({$initialEvent}) {
			const emailConfig = this.getEmailConfig(
				$initialEvent.recordId,
				$initialEvent.emailAddress,
				$initialEvent.primaryDisplayName,
				$initialEvent.entitySchemaName
			);
			const handled = this.emailLinkClicked(emailConfig);
			if (handled) {
				const {event} = $initialEvent;
				event.preventDefault();
			}
		},

		/**
		 * Handles phone link click.
		 * @private
		 */
		_handlePhoneLinkClick: function({$initialEvent}) {
			const isTelephonyEnabled = this.isTelephonyEnabled();
			if (isTelephonyEnabled) {
				const {event} = $initialEvent;
				event.preventDefault();
				Terrasoft.CtiModel.callByNumber($initialEvent.phoneNumber);
			}
		},

		/**
		 * @private
		 */
		_hasSection: function(entitySchemaName) {
			const moduleStructure = Terrasoft.configuration.ModuleStructure[entitySchemaName];
			return Boolean(moduleStructure?.sectionModule);
		},

		/**
		 * @private
		 */
		_openSection: function(entitySchemaName) {
			const moduleName = this._getSectionModuleNameForEntitySchema(entitySchemaName);
			const moduleSchema = this._getSectionSchemaName(entitySchemaName);
			const hash = Ext.String.format("{0}/{1}", moduleName, moduleSchema);
			this.openLookupUrl(hash);
		},

		/**
		 * @private
		 */
		_getSectionSchemaName: function(entitySchemaName) {
			const moduleStructure = Terrasoft.ModuleUtils.getModuleStructureByName(entitySchemaName);
			return moduleStructure?.sectionSchema;
		},

		/**
		 * @private
		 */
		_openLookupSectionInChain: function(config) {
			const moduleName = "LookupSectionModule";
			const schemaName = config.schemaName || "BaseLookupConfigurationSection";
			const newHash = Terrasoft.combinePath(moduleName, schemaName);
			if (schemaName !== "BaseLookupConfigurationSection") {
				this.openLookupUrl(newHash);
				return;
			}
			const moduleId = moduleName + "_" + config.entitySchemaName;
			this.sandbox.publish("PushHistoryState", {
				hash: newHash,
				stateObj: {
					caption: config.caption,
					entitySchemaName: config.entitySchemaName,
					isInChain: true,
					moduleName,
					moduleId,
					keepAlive: true
				}
			});
		},

		/**
		 * @private
		 */
		_checkLookupEditPage: function(entitySchemaName, callback, scope) {
			const result = this.tryGetValueFromLookupInfoCache(entitySchemaName +
				"Schema", "entitySchema");
			if (!result.success) {
				return callback.call(scope);
			}
			const entitySchema = result.value;
			const entitySchemaUId = entitySchema?.uId || Terrasoft.GUID_EMPTY;
			Terrasoft.LookupManager.initialize(null, function() {
				const lookupManagerItem = Terrasoft.LookupManager.findItemBySysEntitySchemaUId(entitySchemaUId);
				callback.call(scope, lookupManagerItem?.sysPageSchemaName);
			});
		},

		/**
		 * @private
		 */
		_getSectionModuleNameForEntitySchema: function(entitySchemaName) {
			const moduleStructure = Terrasoft.configuration.ModuleStructure[entitySchemaName];
			return moduleStructure?.sectionModule || "SectionModuleV2";
		},

		/**
		 * @private
		 */
		 _handleOpenMiniPageRequest: async function(request) {
			const miniPageConfig = request.payload;
			const miniPageSandboxIds = this.getMiniPagesSandboxId(miniPageConfig.entitySchemaName);
			const result = new Promise((resolve) => {
				this.sandbox.subscribe("CardModuleResponse", (response) => {
					this.sandbox.unsubscribePtp("CardModuleResponse", miniPageSandboxIds);
					resolve(response);
				}, this, miniPageSandboxIds);
			});
			this.openMiniPage(miniPageConfig);
			return result;
		},

		/**
		 * @private
		 */
		_navigateToMiniPage: async function(request) {
			const miniPageConfig = request.payload;
			var config = {
				entitySchemaName: miniPageConfig.entitySchemaName,
				id: this.Terrasoft.GUID_EMPTY,
				operation: miniPageConfig.operation,
				defaultValues: miniPageConfig.valuePairs,
				messageTags: [this.sandbox.id + "_chain_" + Terrasoft.generateGUID("N")],
			};
			NetworkUtilities.tryNavigateTo8xMiniPage(config);
		},

		/**
		 * @private
		 */
		_getCardResponseMessageTags: function(state, moduleRef) {
			const tags = this._getChildrenTags(state.children) || [];
			if (!tags.length) {
				tags.push(state.moduleId || moduleRef.sandbox.id);
			}
			return tags;
		},

		/**
		 * @private
		 */
		_getChildrenTags: function(children) {
			let tags;
			children?.forEach((child) => {
				tags = this._getChildrenTags(child.children) || child.messageTags;
			});
			return tags;
		},

		/**
		 * @protected
		 */
		openLookupSourceList: async function ({ payload }) {
			const { entitySchemaName, displayValue } = payload;
			if (this._hasSection(entitySchemaName)) {
				return this._openSection(entitySchemaName);
			}
			this.checkCanGoToLookupSchema(entitySchemaName, function(response) {
				if (response.success) {
					return this._checkLookupEditPage(entitySchemaName, function(editPageName) {
						const config = {
							caption: displayValue,
							entitySchemaName: entitySchemaName,
							schemaName: editPageName,
						};
						this._openLookupSectionInChain(config);
					}, this);
				}
				this.showInformationDialog(Ext.String.format(response.message, displayValue));
			}, this);
		},

		openLookupUrl: function(hash) {
			const navigationHelper = Ext.create("Terrasoft.NavigationHelper", {
				Ext: Ext,
				sandbox: this.sandbox
			});
			const navigationConfig = {
				target: "Url",
				options: {
					url: `${this.getBaseUrl()}${hash}`,
					newTab: true,
					newTabId: `${Terrasoft.generateGUID()}Lookup`
				}
			};
			navigationHelper.navigateTo(navigationConfig);
		},

		/**
		 * @protected
		 */
		getBaseUrl: function() {
			return location.pathname + "#";
		},

		/**
		 * Register handler chain handlers.
		 * @protected
		 */
		subscribeHandlers: function() {
			const moduleRef = this;
			const handlerType = class extends devkit.BaseRequestHandler {
				handle(request) {
					switch (request.action) {
						// Used for BC.
						case "GetHistoryState":
							return moduleRef.sandbox.publish("GetHistoryState");
						case "AddRecordFromLookup":
						case "AddRecordFromEditLookupCell":
							return moduleRef._addRecordFromLookup(request);
						case "HandleEmailLinkClick":
							return moduleRef._handleEmailLinkClick(request);
						case "OpenLookupSource":
							return moduleRef.openLookupSourceList(request);
						case "CardResponse":
							const {state} = moduleRef.sandbox.publish("GetHistoryState");
							const cardModuleResponse = {
								...request.payload,
								isInChain: state.isInChain
							};
							const tags = moduleRef._getCardResponseMessageTags(state, moduleRef);
							moduleRef.sandbox.publish("UpdateDetail", {
								primaryColumnValue: cardModuleResponse.primaryColumnValue
							}, tags);
							if (state.isInChain) {
								moduleRef.sandbox.publish("UpdateParentLookupDisplayValue", {
									referenceSchemaName: cardModuleResponse.referenceSchemaName,
									displayValue: cardModuleResponse.primaryDisplayColumnValue,
									value: cardModuleResponse.primaryColumnValue,
								});
							}
							if (cardModuleResponse.success) {
								moduleRef._applyCardResponseHandler();
							}
							return moduleRef.sandbox.publish("CardModuleResponse", cardModuleResponse, tags);
						case "LoadModuleIntoModalBox": {
							const modalBoxContainer = ModalBox.show(request.modalBoxSize);
							request.moduleParams.renderTo = modalBoxContainer;
							return moduleRef.sandbox.loadModule(request.moduleName, request.moduleParams);
						}
						case "LoadModule": {
							return moduleRef.sandbox.loadModule(request.moduleName, request.moduleParams);
						}
						case "PushHistoryState": {
							return moduleRef.sandbox.publish("PushHistoryState", {
								hash: request.hash,
								stateObj: request.stateObj,
								silent: request.silent,
							});
						}
						case "ReplaceHistoryState": {
							return moduleRef.sandbox.publish("ReplaceHistoryState", {
								hash: request.hash,
								stateObj: request.stateObj,
								silent: request.silent,
							});
						}
						case "8xHistoryStateChanged": {
							const historyState = moduleRef.sandbox.publish("GetHistoryState");
							return moduleRef.sandbox.publish("8xHistoryStateChanged", historyState);
						}
						case "RefreshCacheHash": {
							return moduleRef.sandbox.publish("RefreshCacheHash");
						}
						case "OpenMiniPage": {
							return moduleRef._handleOpenMiniPageRequest(request);
						}
						case "IsTelephonyEnabled":
							return moduleRef.isTelephonyEnabled();
						case "HandlePhoneLinkClick":
							return moduleRef._handlePhoneLinkClick(request);
						default:
							return this.next?.handle(request);
					}
				}
			};
			this.unsubscribesHandlers.push(
				this.handlerChain.register({
					requestType: "crt.7XRequest",
					createHandler: () => new handlerType(),
					scopes: [],
					source: { type: devkit.HandlerSourceType.Host },
				}),
			);
		},

		/**
		 * @private
		 */
		applyCardResponseHandler: function() {
			if (this._cardResponseHandler) {
				const params = this._cardResponseHandler.params;
				this._cardResponseHandler.action.apply(this, params);
				this._cardResponseHandler = null;
			}
		},

		/**
		 * @private
		 */
		_getActionDashboardPageName: function() {
			return "ActionDashboardComponentPage";
		},

		/**
		 * @private
		 */
		_onSaveRecord: function(config) {
			this._addCardResponseHandler(this._onSilentSaved, [config]);
			return this._sendCustomEvent("SaveCard8x", (data) => data,
				{ preventCardClose: true });
		},

		/**
		 * @private
		 */
		_onUpdateCard: async function(config) {
			return this._sendCustomEvent("UpdateCard8x", (updateResult) => {
				if (config.options?.silent) {
					this._onSaveRecord(config);
				}
				return updateResult;
			}, config);
		},

		/**
		 * @private
		 */
		_onValidateCard: async function() {
			return this._sendCustomEvent("ValidateCard8x");
		},

		/**
		 * @private
		 */
		_getOperation: async function() {
			return this._sendCustomEvent("GetOperation8x");
		},

		/**
		 * @private
		 */
		_sendCustomEvent: async function(eventName, dataMapFn = (data) => data, config = null) {
			const {operators: {map, first}} = Terrasoft.RX;
			const result = new Promise((resolve) => {
				this.mixins.CustomEvent
					.subscribe.call(this, eventName)
					.pipe(first(), map(dataMapFn))
					.subscribe((result) => resolve(result));
			})
			this.mixins.CustomEvent.publish.call(this, eventName, config);
			return result;
		},

		/**
		 * @private
		 */
		_subscribeOnSchemaStateGenerated: function () {
			this._schemaStateGeneratedSubscription = this.mixins.CustomEvent
				.subscribe.call(this, '8xSchemaStateGenerated')
				.subscribe(() => MaskHelper.hideBodyMask());
		},

		/**
		 * @private
		 */
		_addCardResponseHandler: function(action, params) {
			this._cardResponseHandler = {
				action: action.bind(this),
				params: params
			};
		},

		/**
		 * @private
		 */
		_onSilentSaved: function(config) {
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
		 * @private
		 */
		_applyCardResponseHandler: function() {
			if (this._cardResponseHandler) {
				const params = this._cardResponseHandler.params;
				this._cardResponseHandler.action.apply(this, params);
				this._cardResponseHandler = null;
			}
		},

		/**
		 * @private
		 */
		_getMessages: function () {
			const messages = {
				"CardModuleResponse": {
					direction: this.Terrasoft.MessageDirectionType.BIDIRECTIONAL,
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
				},
				"GetHistoryState": {
					"mode": this.Terrasoft.MessageMode.PTP,
					"direction": this.Terrasoft.MessageDirectionType.PUBLISH
				},
				"ReplaceHistoryState": {
					"mode": this.Terrasoft.MessageMode.BROADCAST,
					"direction": this.Terrasoft.MessageDirectionType.PUBLISH
				},
				"RefreshCacheHash": {
					"mode": this.Terrasoft.MessageMode.PTP,
					"direction": this.Terrasoft.MessageDirectionType.PUBLISH
				},
				"8xHistoryStateChanged": {
					"mode": this.Terrasoft.MessageMode.BROADCAST,
					"direction": this.Terrasoft.MessageDirectionType.PUBLISH
				},
			};
			return messages;
		},

		/**
		 * @inheritdoc Terrasoft.configuration.BaseModule#init
		 * @override
		 */
		init: function(callback, scope) {
			this.sandbox.registerMessages(this._getMessages());
			this.unsubscribesHandlers = [];
			this.subscribeHandlers();
			this.initSyncMailboxCount();
			Terrasoft.chain(
				this.initLookupQuickAddMixin,
				function() {
					Ext.callback(callback, scope);
				},
				scope || this
			);
			this.mixins.CustomEvent.init.call(this);
			this.sandbox.subscribe("ValidateCard", this._onValidateCard, this, [this._getActionDashboardPageName()]);
			this.sandbox.subscribe("SaveRecord", this._onSaveRecord, this, [this._getActionDashboardPageName()]);
			this.sandbox.subscribe("UpdateCardProperty", this._onUpdateCard, this,
				[this._getActionDashboardPageName()]);
			this.sandbox.subscribe("GetOperation", this._getOperation, this);
			this._subscribeOnSchemaStateGenerated();
		},

		/**
		 * Initializes LookupQuickAddMixin.
		 * @protected
		 * @param {Function} next The callback function.
		 * @param {Object} scope The scope of callback.
		 */
		initLookupQuickAddMixin: function(next, scope) {
			this.mixins.LookupQuickAddMixin.init.call(this, next, scope);
		},

		/**
		 * @protected
		 */
		onLookupResult: function(args, viewModel) {
			const columnName = args.columnName;
			const selectedRows = args.selectedRows;
			if (selectedRows.isEmpty()) {
				return;
			}
			const value = selectedRows.getByIndex(0);
			if (!viewModel) {
				this.set?.(columnName, value);
				return;
			}
			const valueToSet = {};
			valueToSet[columnName] = value;
			viewModel.setValue(valueToSet);
		},

		destroy: function() {
			this.callParent(arguments);
			this.sandbox.unsubscribePtp("UpdateCardProperty", [this._getActionDashboardPageName()]);
			this.sandbox.unsubscribePtp("SaveRecord", [this._getActionDashboardPageName()]);
			this.sandbox.unsubscribePtp("ValidateCard", [this._getActionDashboardPageName()]);
			this.sandbox.unsubscribePtp("GetOperation", []);
			this._schemaStateGeneratedSubscription.unsubscribe();
		},

	});
	return Terrasoft.AngularAdapterModule;
});


