define("BaseSchemaViewModule", ["BaseSchemaViewModuleResources", "MaskHelper", "@creatio-devkit/common", "ConfigurationEnums",
		"BasePageV2Resources",  "@creatio/utils", "ModalBox", "BaseModule", "LookupManager", "mf!SchemaViewComponent",
		"css-ltr!SchemaViewComponentStyles", "ContextHelpMixin", "CtiLinkColumnUtility",
		"EmailLinksMixin", "LookupQuickAddMixin", "PageUtilities", "css!BaseSchemaViewModule", "LoadRightsModuleMixin", "MiniPageUtilities"],
	function (resources, MaskHelper, devkit, ConfigurationEnums, basePageResources, creatioUtils, ModalBox) {
	if (Terrasoft.isAngularHost) {
		console.error('Seems like you try to load 8x page using 7x module. '+
			'Dont use sanbox.loadModule for opening 8x page. ' +
			'Use CrtNavigationService instead.');
	}
	Ext.define("Terrasoft.configuration.BaseSchemaViewModule", {
		alternateClassName: "Terrasoft.BaseSchemaViewModule",
		extend: "Terrasoft.BaseModule",
		mixins: {
			ContextHelpMixin: "Terrasoft.ContextHelpMixin",
			EmailLinksMixin: "Terrasoft.EmailLinksMixin",
			CtiLinkColumnUtility: "Terrasoft.CtiLinkColumnUtility",
			LookupQuickAddMixin: "Terrasoft.LookupQuickAddMixin",
			PageUtilities: "Terrasoft.PageUtilities",
			MiniPageUtilities: "Terrasoft.MiniPageUtilities",
			LoadRightsModuleMixin: "Terrasoft.LoadRightsModuleMixin"
		},

		/**
		 * @protected
		 */
		componentSelector: null,
		/**
		 * @protected
		 */
		isSchemaConfigInitialized: false,
		/**
		 * @protected
		 */
		useHistoryState: true,
		/**
		 * @protected
		 */
		schemaName: "",
		/**
		 * @protected
		 */
		entitySchemaName: null,

		/**
		 * @protected
		 */
		componentWrapSelector: null,

		/**
		 * @protected
		 */
		schemaState: null,

		/**
		 * @protected
		 */
		headerCaption: null,

		/**
		 * @protected
		 */
		unsubscribesHandlers: null,

		/**
		 * @protected
		 */
		handlerChain: devkit.HandlerChainService.instance,

		/**
		 * @private
		 */
		_component: null,

		/**
		 * @private
		 * @type {Terrasoft.RX.Subscription}
		 */
		_componentEventsSubscription: null,

		/**
		 * @private
		 * @type {Object}
		 */
		_unsubscribesSchemaHandlers: {},

		/**
		 * @private
		 */
		_onScroll: function() {
			if (window.pageYOffset > 0) {
				document.body.classList.add("scroll");
			} else {
				document.body.classList.remove("scroll");
			}
		},

		/**
		 * @private
		 */
		_getComponentRealSelector: function(renderTo) {
			let selector = this.componentSelector;
			if (renderTo.id === "centerPanel" &&
				Terrasoft.Features.getIsDisabled("DisableNavigationDependentAngularComponents")) {
				selector += "-navigation";
			}
			return selector;
		},

		/**
		 * @private
		 */
		_createComponent: function(renderTo) {
			const selector = this._getComponentRealSelector(renderTo);
			const component = document.createElement(selector);
			renderTo.appendChild(component);
			return component;
		},

		/**
		 * @private
		 */
		_getExistingComponent: function(container) {
			const selector = this._getComponentRealSelector(container);
			return container.query(selector)[0];
		},

		/**
		 * @private
		 */
		_removeComponent: function() {
			this._componentEventsSubscription?.unsubscribe();
			this._component?.remove();
			this._component = null;
		},

		/**
		 * @private
		 */
		_subscribeOnSchemaStateGenerated: function () {
			const {Subscription, fromEvent} = Terrasoft.RX;
			MaskHelper.showBodyMask();
			this._componentEventsSubscription?.unsubscribe();
			this._componentEventsSubscription = new Subscription();
			this._componentEventsSubscription
				.add(
					fromEvent(this._component, "schemaStateGenerated").subscribe((event) => {
						this.onSchemaStateGenerated(event);
						MaskHelper.hideBodyMask();
					})
				);
		},

		/**
		 * @private
		 */
		_loadSchema: function() {
			this._subscribeOnSchemaStateGenerated();
			const { modelInitConfigs, parameters } = this._getComponentDataFromHistoryState();
			this._component.modelInitConfigs = modelInitConfigs;
			this._component.parameters = parameters;
			this._component.setAttribute("schema", this.schemaName);
		},

		/**
		 * @private
		 */
		_getComponentDataFromHistoryState: function() {
			const historyState = this.sandbox.publish("GetHistoryState");
			const { state, hash } = historyState;
			let modelInitConfigs = state.modelInitConfigs;
			const result = { modelInitConfigs: {}, parameters: {} };
			if (state.schemaName && state.schemaName !== this.schemaName) {
				return result;
			}
			if (!modelInitConfigs) {
				const action = state.operation || hash.operationType;
				if (action) {
					const defaultValues = this._getDefaultValues(state.valuePairs);
					modelInitConfigs = [{
						action,
						recordId: state.primaryColumnValue || hash.recordId,
						defaultValues
					}];
				}
			}
			result.modelInitConfigs = modelInitConfigs;
			result.parameters = state.parameters ?? {};
			return result;
		},

		/**
		 * @private
		 */
		_getDefaultValues: function(valuePairs) {
			const isUndefined = Terrasoft.utils.common.isUndefined;
			return valuePairs && valuePairs.map((valuePair) => {
				const value = !isUndefined(valuePair.value) && !isUndefined(valuePair.displayValue)
					? valuePair
					: valuePair.value;
				return {
					attributeName: valuePair.name,
					value
				};
			});
		},

		/**
		 * @private
		 */
		_getChainCardModuleSandboxId: function(moduleName) {
			return this.sandbox.id + moduleName + "_chain00000000-0000-0000-0000-000000000000";
		},

		/**
		 * @private
		 */
		_addValueToLookup: function(newValue, columnName, attributeName, viewModel) {
			this.setValueToLookupInfoCache(columnName, "filterValue", newValue.inputedValue);
			this.mixins.LookupQuickAddMixin.onLookupChange.call(this, newValue, columnName, attributeName, function(result) {
				console.log(result);
			}, viewModel);
		},

		/**
		 * @private
		 */
		_getReloadActionTag: function() {
			return this.schemaName + "_UpdateSection";
		},

		/**
		 * @private
		 */
		_initReloadAction: function() {
			this.sandbox.subscribe("UpdateSection", this.reloadPage, this, [this._getReloadActionTag()]);
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
				this.set(columnName, value);
				return;
			}
			const valueToSet = {};
			valueToSet[columnName] = value;
			viewModel.setValue(valueToSet);
		},

		/**
		 * @protected
		 */
		onSchemaStateGenerated: function(event) {
			this.schemaState = event.detail;
			if (Terrasoft.Features.getIsDisabled("DisableHandleFixedViewModelResumePauseRequest")) {
				const {take} = Terrasoft.RX.operators;
				this.schemaState.viewModel.resume().pipe(take(1)).subscribe();
			}
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
		onInitDataView: Terrasoft.emptyFn,

		/**
		 * Method to override dependency of BaseViewModel.
		 * @protected
		 */
		validateColumn: Terrasoft.emptyFn,

		showInformationDialog: Terrasoft.utils.showInformation,

		set: function(attr, value) {
			const valueToSet = {};
			valueToSet[attr] = value;
			this.schemaState.viewModel.setValue(valueToSet);
		},

		/**
		 * Returns message config.
		 * @returns Object
		 */
		getMessages: function() {
			return {
				"CardModuleResponse": {
					direction: this.Terrasoft.MessageDirectionType.BIDIRECTIONAL,
					mode: this.Terrasoft.MessageMode.PTP
				},
				"GetHistoryState": {
					direction: this.Terrasoft.MessageDirectionType.PUBLISH,
					mode: this.Terrasoft.MessageMode.PTP
				},
				"GetPreviousHistoryState": {
					direction: this.Terrasoft.MessageDirectionType.PUBLISH,
					mode: this.Terrasoft.MessageMode.PTP
				},
				"ReplaceHistoryState": {
					direction: this.Terrasoft.MessageDirectionType.PUBLISH,
					mode: this.Terrasoft.MessageMode.BROADCAST
				},
				"PushHistoryState": {
					mode: Terrasoft.MessageMode.BROADCAST,
					direction: Terrasoft.MessageDirectionType.PUBLISH
				},
				"InitContextHelp": {
					direction: this.Terrasoft.MessageDirectionType.PUBLISH,
					mode: this.Terrasoft.MessageMode.PTP
				},
				"BackHistoryState": {
					"mode": Terrasoft.MessageMode.BROADCAST,
					"direction": Terrasoft.MessageDirectionType.PUBLISH
				},
				"InitDataViews": {
					direction: this.Terrasoft.MessageDirectionType.PUBLISH,
					mode: this.Terrasoft.MessageMode.PTP
				},
				"SchemaViewChanged": {
					mode: Terrasoft.MessageMode.BROADCAST,
					direction: Terrasoft.MessageDirectionType.PUBLISH
				},
				"GetSchemaViewInfo": {
					mode: Terrasoft.MessageMode.PTP,
					direction: Terrasoft.MessageDirectionType.SUBSCRIBE
				},
				"CallCustomer": {
					mode: Terrasoft.MessageMode.PTP,
					direction: Terrasoft.MessageDirectionType.PUBLISH
				},
				"UpdateSection": {
					mode: Terrasoft.MessageMode.PTP,
					direction: Terrasoft.MessageDirectionType.SUBSCRIBE
				},
				"GetRecordInfo": {
					mode: Terrasoft.MessageMode.PTP,
					direction: Terrasoft.MessageDirectionType.SUBSCRIBE
				}
			};
		},

		/**
		 * @private
		 */
		_editRecord: async function ({ payload }) {
			MaskHelper.showBodyMask();
			const { entityName } = payload;
			const recordId = payload?.recordId?.value ?? payload?.recordId;
			const { state, hash: hashObject } = this.sandbox.publish("GetHistoryState");
			const currentPageSchemaName = hashObject.entityName;
			const preferFreedomUI = await this._checkNeedPreferFreedomUI(entityName, currentPageSchemaName);
			const schemaName = await this._getEditPageSchemaName(entityName, recordId, preferFreedomUI);
			if (!schemaName) {
				MaskHelper.hideBodyMask();
				return;
			}
			const moduleName = await this._getModuleName(entityName, schemaName, preferFreedomUI);
			const moduleId = [moduleName, recordId, schemaName].join("_");
			const action = "edit";
			const modelInitConfigs = [{action, recordId}];
			if (state?.isInChain) {
				// TODO RND-20385
				this.sandbox.subscribe("CardModuleResponse", this._onCardModuleResponse.bind(this, moduleId), [moduleId]);
				return this.openCardInChain({
					schemaName,
					operation: ConfigurationEnums.CardStateV2.EDIT,
					id: recordId,
					moduleId,
					moduleName,
					modelInitConfigs
				});
			} else {
				const stateObj = {moduleId, modelInitConfigs};
				const hash = Ext.String.format("{0}/{1}/{2}/{3}", moduleName, schemaName, action, recordId);
				return payload?.replaceHistoryState
					? this.sandbox.publish("ReplaceHistoryState", {hash, stateObj})
					: this.sandbox.publish("PushHistoryState", {hash, stateObj});
			}
		},

		/**
		 * @private
		 */
		_addRecord: async function ({ payload }) {
			MaskHelper.showBodyMask();
			const entityName = payload.entityName;
			const notEmptyDefaultValues = payload.defaultValues?.filter((dv) => dv.value);
			const preferFreedomUI = await this._checkNeedPreferFreedomUI(entityName);
			const addPageSchemaName = await this._getAddPageSchemaName(payload, preferFreedomUI);
			const schemaName = addPageSchemaName || await this._getEditPageSchemaName(entityName, undefined, preferFreedomUI, notEmptyDefaultValues);
			const moduleName = await this._getModuleName(entityName, schemaName, preferFreedomUI);
			const moduleId = this._getChainCardModuleSandboxId(moduleName);
			const modelInitConfigs = [{
				action: "add",
				defaultValues: notEmptyDefaultValues
			}];
			// TODO RND-20385
			this.sandbox.subscribe("CardModuleResponse", this._onCardModuleResponse.bind(this, moduleId), [moduleId]);
			return this.openCardInChain({
				entitySchemaName: entityName,
				schemaName,
				operation: ConfigurationEnums.CardStateV2.ADD,
				moduleId,
				moduleName,
				modelInitConfigs,
				valuePairs: this._getValuePairs(notEmptyDefaultValues)
			});
		},

		/**
		 * @private
		 */
		_onCardModuleResponse: function(moduleId, infoObject) {
			this.sandbox.unsubscribePtp("CardModuleResponse", [moduleId]);
			if (infoObject.isAngularPage) {
				return;
			}
			const primaryAttributesValues = [[{
				value: infoObject.uId,
				name: infoObject.primaryColumnName
			}]];
			this.handlerChain.process({
				type: "crt.7XHandleModelEventRequest",
				$context: this.schemaState.viewModel,
				entitySchemaName: infoObject.entitySchemaName,
				modelEvent: {
					type: "create",
					payload: {
						primaryAttributesValues
					}
				}
			});
		},

		/**
		 * @private
		 */
		_getValuePairs: function(defaultValues) {
			return defaultValues && defaultValues.map((defaultValue) => {
				let displayValue, value;
				if (defaultValue.value?.value) {
					value = defaultValue.value.value;
					displayValue = defaultValue.value.displayValue;
				} else {
					value = defaultValue.value;
				}
				return {
					name: defaultValue.attributeName,
					value,
					displayValue
				};
			});
		},

		/**
		 * @private
		 */
		_addRecordFromLookup: function ({ payload }, viewModel) {
			const { attributeName, entityName, displayColumn, displayValue, allowEmptyDisplayValue, defaultValues } = payload;
			this._addValueToLookup({
					entitySchemaName: entityName,
					inputedValue: displayValue,
					isNewValue: true,
					value: Terrasoft.GUID_EMPTY,
					allowEmptyDisplayValue,
					additionalDefaultValues: defaultValues
				},
				displayColumn,
				attributeName,
				viewModel);
		},

		/**
		 * @private
		 */
		_addRecordFromEditLookupCell: function ({ payload, $context }) {
			this._addRecordFromLookup({ payload }, $context);
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
		 * Handles email link click.
		 * @private
		 */
		_handleEmailLinkClick: function({$initialEvent}) {
			const emailConfig = this.getEmailConfig($initialEvent.recordId, $initialEvent.emailAddress, $initialEvent.primaryDisplayName, $initialEvent.entitySchemaName);
			const handled = this.emailLinkClicked(emailConfig);
			if (handled) {
				const {event} = $initialEvent;
				event.preventDefault();
			}
		},

		/**
		 * Handles open mini page request.
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
		_isSectionEditPage: function(schemaName) {
			return Boolean(this._getSectionEditPageModuleName(schemaName));
		},

		/**
		 * @private
		 * @returns {Object}
		 */
		_getModuleStructureBySectionSchema(sectionSchemaName) {
			return Object.values(Terrasoft.configuration.ModuleStructure).find(
				(item) => item.sectionSchema === sectionSchemaName,
			);
		},

		/**
		 * @private
		 * @returns {String}
		 */
		_getSectionModuleName: function(schemaName) {
			return this._getModuleStructureBySectionSchema(schemaName)?.sectionModule;
		},

		/**
		 * @private
		 * @returns {String}
		 */
		_getSectionEntityName: function(schemaName) {
			return this._getModuleStructureBySectionSchema(schemaName)?.entitySchemaName;
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
		_getSectionEditPageModuleName: function(schemaName) {
			const config = Object.values(Terrasoft.configuration.ModuleStructure).find((item) => (
				item.cardSchema === schemaName || item.pages?.some((page) => page.cardSchema === schemaName)
			));
			return config?.cardModule;
		},

		/**
		 * @private
		 * @returns {Object}
		 */
		_getEntityStructure: function(entitySchemaName, preferFreedomUI = false) {
			let result;
			if (preferFreedomUI) {
				result = Object.values(Terrasoft.configuration.EntityStructure).find(
					(x) => x.page8X && x.entitySchemaName === entitySchemaName,
				);
			}
			return result ?? Terrasoft.ModuleUtils.getEntityStructureByName(entitySchemaName);
		},

		/**
		 * @private
		 */
		_getUITypePriority: function(preferFreedomUI) {
			return preferFreedomUI ? creatioUtils.UITypePriority.PreferFreedomUI : creatioUtils.UITypePriority.Auto;
		},

		/**
		 * @private
		 */
		_getAddPageSchemaName: async function(payload, preferFreedomUI) {
			const action = ConfigurationEnums.CardStateV2.ADD;
			const uiTypePriority = this._getUITypePriority(preferFreedomUI);
			const page = await creatioUtils.NavigationUtils.getPageForActionAsync({ action, uiTypePriority, ...payload });
			return page?.cardSchema;
		},

		/**
		 * @private
		 */
		_getEditPageSchemaName: async function(entityName, recordId = null, preferFreedomUI = false,
				defaultValues = null) {
			const action = ConfigurationEnums.CardStateV2.EDIT;
			const uiTypePriority = this._getUITypePriority(preferFreedomUI);
			const options = { action, entityName, recordId, uiTypePriority, defaultValues };
			const page = await creatioUtils.NavigationUtils.getPageForActionAsync(options);
			return page?.cardSchema;
		},

		/**
		 * @private
		 */
		_copyRecord: async function ({ payload }) {
			const { entityName, recordId } = payload;
			MaskHelper.showBodyMask();
			const preferFreedomUI = await this._checkNeedPreferFreedomUI(entityName);
			const schemaName = await this._getEditPageSchemaName(entityName, recordId, preferFreedomUI);
			if (!schemaName) {
				MaskHelper.hideBodyMask();
				return;
			}
			const moduleName = await this._getModuleName(entityName, schemaName, preferFreedomUI);
			const moduleId = [moduleName, recordId, schemaName].join("_");
			const modelInitConfigs = [{
				action: "copy",
				recordId
			}];
			// TODO RND-20385
			this.sandbox.subscribe("CardModuleResponse", this._onCardModuleResponse.bind(this, moduleId), [moduleId]);
			this.openCardInChain({
				id: recordId,
				schemaName,
				operation: ConfigurationEnums.CardStateV2.COPY,
				moduleId,
				moduleName,
				modelInitConfigs
			});
		},

		/**
		 * @private
		 */
		_openSectionEditPage: function (payload, moduleName) {
			const { schemaName, parameters, modelInitConfigs } = payload;
			if (!modelInitConfigs || modelInitConfigs.length === 0) {
				return;
			}
			const modelInitConfig = modelInitConfigs[0];
			const recordId = modelInitConfig.recordId;
			const historyState = this.sandbox.publish("GetHistoryState");
			const {state} = historyState;
			const action = modelInitConfig.action;
			if (action === ConfigurationEnums.CardStateV2.EDIT && !state?.isInChain) {
				const moduleId = [moduleName, recordId, schemaName].join("_");
				const stateObj = {moduleId, parameters, modelInitConfigs};
				const hash = Ext.String.format("{0}/{1}/{2}/{3}", moduleName, schemaName, action, recordId);
				return this.sandbox.publish("PushHistoryState", {hash, stateObj});
			} else {
				const moduleId = this._getChainCardModuleSandboxId(moduleName);
				const valuePairs = this._getValuePairs(modelInitConfig.defaultValues);
				this.openCardInChain({
					schemaName,
					operation: action,
					moduleId,
					moduleName,
					valuePairs,
					parameters,
					modelInitConfigs,
					id: recordId
				});
			}
		},

		/**
		 * @private
		 */
		_isSchemaInheritedFrom: async function(baseSchemaName, schemaName) {
			let schemaStructure = Terrasoft.configuration.Structures[schemaName];
			if (!schemaStructure) {
				await this._getSchemaRequire(schemaName);
				schemaStructure = Terrasoft.configuration.Structures[schemaName];
			}
			const structureParent = schemaStructure?.structureParent;
			if (!structureParent) {
				return false;
			}
			return structureParent === baseSchemaName
				? true
				: this._isSchemaInheritedFrom(baseSchemaName, structureParent);
		},

		/**
		 * @private
		 * @returns {Promise<boolean>}
		 */
		_isAngularListPage: function(schemaName) {
			return this._isSchemaInheritedFrom('BaseGridSectionTemplate', schemaName)
		},

		/**
		 * @private
		 */
		_getSchemaRequire: function(schemaName) {
			return new Promise((resolve) => {
				Terrasoft.require([schemaName], (schema) => resolve(schema));
			});
		},

		/**
		 * @private
		 * @returns {Promise<boolean>}
		 */
		_checkNeedPreferFreedomUI: async function(entitySchemaName, currentPageSchemaName = null) {
			if (!currentPageSchemaName) {
				const { hash } = this.sandbox.publish("GetHistoryState");
				currentPageSchemaName = hash.entityName;
			}
			const isListPage = currentPageSchemaName && (await this._isAngularListPage(currentPageSchemaName));
			if (!isListPage) {
				return false;
			}
			const sectionEntityName = this._getSectionEntityName(currentPageSchemaName);
			return sectionEntityName === entitySchemaName;
		},

		/**
		 * @private
		 */
		_getModuleName: async function(entityName, schemaName, preferFreedomUI = false) {
			const entityStructure = this._getEntityStructure(entityName, preferFreedomUI);
			let moduleName = entityStructure?.pages.find((item) => item.cardSchema === schemaName)?.cardModuleName;
			if (moduleName) {
				return moduleName;
			}
			moduleName = entityStructure?.cardModuleName;
			if (moduleName) {
				return moduleName;
			}
			moduleName = this._getSectionModuleName(schemaName);
			if (moduleName) {
				return moduleName;
			}
			moduleName = this._getSectionEditPageModuleName(schemaName);
			if (moduleName) {
				return moduleName;
			}
			const result = await this._isSchemaInheritedFrom("BasePageV2", schemaName);
			if (result) {
				return "CardModuleV2";
			} else if (await this._isSchemaInheritedFrom("BaseHomePage", schemaName)) {
				return "HomePage";
			} else {
				return "PageSchemaViewModule";
			}
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
		_hasSection: function(entitySchemaName) {
			const moduleStructure = Terrasoft.configuration.ModuleStructure[entitySchemaName];
			return Boolean(moduleStructure?.sectionModule);
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
		_openDuplicatesPage: async function ({ payload }) {
			MaskHelper.showBodyMask();
			const { schemaName, entityName } = payload;
			const moduleName = "CardModuleV2";
			const moduleId = [moduleName, schemaName].join("_");
			const stateObj = { moduleId };
			const hash = Ext.String.format("{0}/{1}/{2}", moduleName, schemaName, entityName);
			return this.sandbox.publish("PushHistoryState", { hash, stateObj });
		},

		/**
		 * @private
		 */
		_openPage: async function ({ payload }) {
			MaskHelper.showBodyMask();
			const { schemaName, parameters, modelInitConfigs, entityName } = payload;
			const moduleName = await this._getModuleName(entityName, schemaName);
			if (this._isSectionEditPage(schemaName)) {
				return this._openSectionEditPage(payload, moduleName);
			}
			const moduleId = [moduleName, schemaName].join("_");
			const stateObj = { moduleId, parameters, modelInitConfigs };
			const hash = Ext.String.format("{0}/{1}", moduleName, schemaName);
			return this.sandbox.publish("PushHistoryState", { hash, stateObj });
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
		 * @protected
		 */
		sendRequest: async function(requestType, requestParams) {
			return await this.schemaState.viewModel.executeRequest({
				type: requestType,
				$context: this.schemaState.viewModel,
				...requestParams
			});
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
							moduleId: this.sandbox.id + "_BaseLookupConfigurationSection"
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
		 * @private
		 */
		_openLookupSectionInChain: function(config) {
			const schemaName = config.schemaName || "BaseLookupConfigurationSection";
			const newHash = Terrasoft.combinePath("LookupSectionModule", schemaName);
			if (schemaName !== "BaseLookupConfigurationSection") {
				this.openLookupUrl(newHash);
				return;
			}
			this.sandbox.publish("PushHistoryState", {
				hash: newHash,
				silent: true,
				stateObj: {
					caption: config.caption,
					entitySchemaName: config.entitySchemaName,
					isInChain: true,
					silent: true
				}
			});
			this.sandbox.loadModule("LookupSectionModule", {
				renderTo: this._renderTo,
				id: config.moduleId,
				keepAlive: true
			});
		},

		/**
		 * @private
		 */
		async _getRecordUrlHash({ payload }) {
			const { entityName, recordId } = payload;
			const preferFreedomUI = await this._checkNeedPreferFreedomUI(entityName);
			const schemaName = await this._getEditPageSchemaName(entityName, recordId, preferFreedomUI);
			const moduleName = await this._getModuleName(entityName, schemaName, preferFreedomUI);
			return moduleName && schemaName
				? Ext.String.format("{0}/{1}/{2}/{3}", moduleName, schemaName, "edit", recordId)
				: "";
		},

		/**
		 * @private
		 */
		_getEntityUrl(entityName, entityId) {
			const appBaseUrl = Terrasoft.workspaceBaseUrl.replace(/\/0\/?$|\/+$/, '');
			return `${appBaseUrl}/Navigation/Navigation.aspx?schemaName=${entityName}&recordId=${entityId}`;
		},

		/**
		 * @private
		 */
		async _getRecordUrl(request) {
			const disableFeature = Terrasoft.Features.getIsEnabled('DisableEntityRecordUrlCreation');
			if (disableFeature) {
				const hash = await this._getRecordUrlHash(request);
				return `${this.getBaseUrl()}${hash}`;
			}
			const { entityName, recordId } = request.payload;
			return this._getEntityUrl(entityName, recordId);
		},

		/**
		 * @private
		 */
		async _hasEntityEditPage({ payload }) {
			const { entityName } = payload;
			const recordId = payload?.recordId?.value ?? payload?.recordId;
			const schemaName = await this._getEditPageSchemaName(entityName, recordId);
			return Boolean(schemaName);
		},

		/**
		 * Initializes the name of the scheme.
		 * @protected
		 */
		initSchemaName: Terrasoft.abstractFn,

		/**
		 * Register handler chain handlers.
		 * @protected
		 */
		subscribeHandlers: function() {
			const moduleRef = this;
			const handlerType = class extends devkit.BaseRequestHandler {
				handle(request) {
					switch (request.action) {
						case "GetHistoryState":
							return moduleRef.sandbox.publish("GetHistoryState");
						case "BackHistoryState":
							return moduleRef.sandbox.publish("BackHistoryState");
						case "EditRecord":
							return moduleRef._editRecord(request);
						case "AddRecord":
							return moduleRef._addRecord(request);
						case "AddRecordFromLookup":
							return moduleRef._addRecordFromLookup(request);
						case "AddRecordFromEditLookupCell":
							return moduleRef._addRecordFromEditLookupCell(request);
						case "GetRecordUrl":
							return moduleRef._getRecordUrl(request);
						case "HandlePhoneLinkClick":
							return moduleRef._handlePhoneLinkClick(request);
						case "HandleEmailLinkClick":
							return moduleRef._handleEmailLinkClick(request);
						case "InitDataViews":
							return moduleRef.onInitDataView(request);
						case "LoadModuleIntoModalBox": {
							const modalBoxContainer = ModalBox.show(request.modalBoxSize);
							request.moduleParams.renderTo = modalBoxContainer;
							return moduleRef.sandbox.loadModule(request.moduleName, request.moduleParams);
						}
						case "PushHistoryState": {
							return moduleRef.sandbox.publish("PushHistoryState", {
								hash: request.hash,
								stateObj: request.stateObj,
								silent: request.silent,
							});
						}
						case "CopyRecord":
							return moduleRef._copyRecord(request);
						case "OpenPage":
							return moduleRef._openPage(request);
						case "OpenDuplicatesPage":
							return moduleRef._openDuplicatesPage(request);
						case "OpenLookupSource":
							return moduleRef.openLookupSourceList(request);
						case "HasEntityEditPage":
							return moduleRef._hasEntityEditPage(request);
						case "OpenMiniPage": 
							return moduleRef._handleOpenMiniPageRequest(request);
						case "IsTelephonyEnabled":
							return moduleRef.isTelephonyEnabled();
						case "LoadRightsModule":
							return moduleRef.loadRightsModule(request);
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
		 * @inheritdoc Terrasoft.configuration.BaseModule#init
		 * @override
		 */
		init: function(callback, scope) {
			this.unsubscribesHandlers = [];
			this.sandbox.registerMessages(this.getMessages());
			this.initHistoryState();
			this.initSyncMailboxCount();
			if (!this.isSchemaConfigInitialized) {
				this.initSchemaName();
			}
			this.sandbox.subscribe("CanBeDestroyed", this.onCanBeDestroyed, this);
			this.sandbox.subscribe("GetSchemaViewInfo", this.getSchemaViewInfo.bind(this));
			this.sandbox.publish("SchemaViewChanged", this.getSchemaViewInfo());
			this.initContextHelp();
			this.subscribeHandlers();
			Terrasoft.chain(
				this.initLookupQuickAddMixin,
				function() {
					this._initReloadAction();
					Ext.callback(callback, scope);
				},
				scope || this
			);
		},

		/**
		 * @protected
		 */
		onCanBeDestroyed: function (cacheKey) {
			var config = Terrasoft.ClientPageSessionCache.getItem(cacheKey);
			if (!Ext.isObject(config)) {
				return;
			}
			var isChanged = this.schemaState?.viewModel?.attributes?.IsChanged;
			if (isChanged) {
				this.setNotBeDestroyedConfig(config);
			}
		},

		/**
		 * @protected
		 */
		setNotBeDestroyedConfig: function (config) {
			var message = basePageResources.localizableStrings.PageContainsUnsavedChanges;
			Ext.apply(config, {
				canBeDestroyed: false,
				errorInfo: {
					message: message
				}
			});
		},

		/**
		 * Returns schema view information.
		 * @returns {Object} Schema view information.
		 */
		getSchemaViewInfo: function() {
			return {schemaName: this.schemaName};
		},

		/**
		 * @protected
		 */
		getBaseUrl: function() {
			return Terrasoft.combinePath(Terrasoft.workspaceBaseUrl, "Nui/ViewModule.aspx#");
		},

		/**
		 * @protected
		 */
		prepareHistoryState: function(currentState) {
			const newState = this.Terrasoft.deepClone(currentState);
			newState.moduleId = this.sandbox.id;
			return newState;
		},

		/**
		 * @override
		 */
		render: function(renderTo) {
			this._renderTo = renderTo;
			window.addEventListener("scroll", this._onScroll);
			document.body.classList.add(this.componentWrapSelector);
			this._component = this._getExistingComponent(renderTo) || this._createComponent(renderTo);
			if (this.schemaState) {
				this._subscribeOnSchemaStateGenerated();
				this._component.schemaState = this.schemaState;
				this.sandbox.publish("InitDataViews", {caption: this.headerCaption, moduleName: this.schemaName});
				MaskHelper.hideBodyMask();
			} else if (this._component.schema === this.schemaName) {
				this.reloadPage();
			} else {
				this._loadSchema();
			}
		},

		/**
		 * Replaces the last element in the chain of states, if the module identifier differs from the current.
		 * @protected
		 */
		initHistoryState: function() {
			const sandbox = this.sandbox;
			const state = sandbox.publish("GetHistoryState");
			const currentHash = state.hash;
			const currentState = state.state || {};
			if (currentState.moduleId === sandbox.id) {
				return;
			}
			if (currentState.hybridMode) {
				return;
			}
			const newState = this.prepareHistoryState(currentState);
			sandbox.publish("ReplaceHistoryState", {
				stateObj: newState,
				pageTitle: null,
				hash: currentHash.historyState,
				silent: true
			});
		},

		/**
		 * @protected
		 */
		reloadPage: function() {
			this._removeComponent();
			this._destroyViewModelAsync(this.schemaState?.viewModel).subscribe();
			this.schemaState = null;
			this._component = this._createComponent(this._renderTo);
			this._loadSchema();
		},

		/**
		 * Opens card in chain.
		 * @protected
		 * @param {Object} config Card configuration information
		 */
		openCardInChain: function(config) {
			const historyState = this.sandbox.publish("GetHistoryState");
			const stateObj = config.stateObj || {
				isSeparateMode: true,
				schemaName: config.schemaName,
				entitySchemaName: config.entitySchemaName,
				operation: config.action || config.operation,
				primaryColumnValue: config.id,
				valuePairs: config.valuePairs,
				isInChain: true,
				modelInitConfigs: config.modelInitConfigs
			};
			this.sandbox.publish("PushHistoryState", {
				hash: historyState.hash.historyState,
				silent: config.silent,
				stateObj
			});
			const moduleName = config.moduleName;
			const moduleParams = {
				renderTo: this.Ext.get('centerPanel'),
				id: config.moduleId,
				keepAlive: (config.keepAlive !== false)
			};
			const instanceConfig = config.instanceConfig;
			if (instanceConfig) {
				this.Ext.apply(moduleParams, {
					instanceConfig: instanceConfig
				});
			}
			this.sandbox.loadModule(moduleName, moduleParams);
		},

		/**
		 * @private
		 */
		_destroyViewModelAsync: function(viewModel) {
			const {concat, of} = Terrasoft.RX;
			const {take} = Terrasoft.RX.operators;
			if (Terrasoft.Features.getIsEnabled("DisableHandleFixedViewModelResumePauseRequest")) {
				return viewModel?.destroy().pipe(take(1)) ?? of();
			}
			return concat(
				viewModel?.pause() ?? of(),
				viewModel?.destroy() ?? of(),
			).pipe(take(2));
		},

		/**
		 * @inheritDoc Terrasoft.core.BaseObject#destroy
		 * @overridden
		 */
		destroy: function({keepAlive, nextModuleName}) {
			if (keepAlive !== true) {
				if (this.schemaState) {
					this._destroyViewModelAsync(this.schemaState.viewModel).subscribe();
					this.schemaState = null;
				}
			}
			window.removeEventListener("scroll", this._onScroll);
			this._componentEventsSubscription?.unsubscribe();
			if (Terrasoft.Features.getIsDisabled("DisableHandleFixedViewModelResumePauseRequest")) {
				this._removeComponent();
			} else if (nextModuleName !== this.Terrasoft.moduleName) {
				this._removeComponent();
			}
			document.body.classList.remove(this.componentWrapSelector);
			this.unsubscribesHandlers.forEach((handler) => handler());
			this.unsubscribesHandlers = [];
			this.sandbox.publish("SchemaViewChanged", {schemaName: this.schemaName, destroyed: true});
			this.sandbox.unsubscribePtp("UpdateSection", [this._getReloadActionTag()]);
		}
	});
	return Terrasoft.BaseSchemaViewModule;
});
