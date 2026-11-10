Terrasoft.configuration.Structures["ConfigurationViewModule"] = {innerHierarchyStack: ["ConfigurationViewModule"]};
define("ConfigurationViewModule", [
	"ext-base",
	"sandbox",
	"terrasoft",
	"ConfigurationViewModuleResources",
	"LookupUtilities",
	"ViewModuleHelper",
	"ConfigurationConstants",
	"ConfigurationEnums",
	"LeftPanelUtilitiesV2",
	"ModalBox",
	"@creatio/utils",
	"WelcomeScreenModule",
	"SspReadOnlyModeModule",
	"BaseViewModule",
	"BaseSchemaModuleV2",
	"NavigationHelper",
	"css!LeftPanelCSS",
	"WindowUnloadWatcher",
	"ImageView"
], function(
	Ext,
	sandbox,
	Terrasoft,
	resources,
	LookupUtilities,
	ViewModuleHelper,
	ConfigurationConstants,
	ConfigurationEnums,
	LeftPanelUtilities,
	ModalBox,
	creatioUtils) {

	/**
	 * @class Terrasoft.configuration.ViewModule
	 * Class of the visual view module.
	 */
	var viewModule = Ext.define("Terrasoft.configuration.ConfigurationViewModule", {
		extend: "Terrasoft.BaseViewModule",
		alternateClassName: "Terrasoft.ConfigurationViewModule",

		Ext: null,
		sandbox: null,
		Terrasoft: null,

		mixins: {
			customEvent: "Terrasoft.mixins.CustomEventDomMixin"
		},

		/**
		 * Default home page schema.
		 * @type {String}
		 */
		defaultIntroPage: "SimpleIntro",

		diff: [],

		/**
		 * Checks, that SspReadOnlyModeModule should be rendered.
		 * @protected
		 * @returns {boolean} True, if module should be rendered.
		 */
		isNeedToShowReadOnlyButton: function() {
			return this.Terrasoft.CurrentUser.userType === this.Terrasoft.UserType.SSP &&
				this.Terrasoft.isSspInReadonlyMode;
		},

		/**
		 * Loads SspReadOnlyModeModule.
		 * @protected
		 */
		loadReadOnlyModule: function() {
			var moduleName = "SspReadOnlyModeModule";
			var moduleId = this.sandbox.id + "_" + moduleName;
			this.sandbox.loadModule(moduleName, {
				id: moduleId,
				renderTo: Ext.getBody()
			});
		},

		/**
		 * @inheritDoc Terrasoft.configuration.BaseViewModule#init
		 * @overridden
		 */
		init: function(callback, scope) {
			this.diff = this._getDiff();
			const parentMethod = this.getParentMethod();
			Terrasoft.chain(
				function(next) {
					this._tryRedirectToFreedomUI().then(next);
				},
				function(next) {
					parentMethod.call(this, next, this);
				},
				function() {
					this.initIntroPage();
					if (Ext.isFunction(ViewModuleHelper.initSettings)) {
						ViewModuleHelper.initSettings();
					}
					LeftPanelUtilities.initCollapsedState();
					if (this.isNeedToShowReadOnlyButton()) {
						this.loadReadOnlyModule();
					}
					callback.call(scope);
				}, this
			);
		},

		/**
		 * @inheritdoc Terrasoft.BaseSchemaModule#render
		 * @protected
		 * @overridden
		 */
		render: function() {
			this.callParent(arguments);
			this._addClass();
		},

		/**
		 * @inheritdoc Terrasoft.BaseSchemaModule#getMessages
		 * @protected
		 * @overridden
		 */
		getMessages: function() {
			const messages = {
				"NavigateTo": {
					mode: Terrasoft.MessageMode.BROADCAST,
					direction: Terrasoft.MessageDirectionType.SUBSCRIBE
				}
			};
			const parentMessages = this.callParent(arguments);
			return Ext.apply(messages, parentMessages);
		},

		/**
		 * @inheritDoc Terrasoft.configuration.BaseViewModule#loadNonVisibleModules
		 * @overridden
		 */
		loadNonVisibleModules: function() {
			this.callParent(arguments);
			var sandbox = this.sandbox;
			sandbox.loadModule("ProcessListener");
			sandbox.loadModule("HotkeysModule");
			sandbox.loadModule("SyncModule");
			sandbox.loadModule("MiniPageListener");
			sandbox.loadModule("ImportNotifierClientModule");
			sandbox.loadModule("AsyncReportNotifier");
			sandbox.loadModule("BaseSchemaModuleV2", {
				id: this.sandbox.id + "_clientMessageBridge",
				instanceConfig: {
					generateViewContainerId: false,
					useHistoryState: false,
					schemaName: "ClientMessageBridge",
					isSchemaConfigInitialized: true
				}
			});
			sandbox.loadModule("OutdatedModuleWatcher");
			sandbox.loadModule("ConfigurationBuildWatcher");
			sandbox.loadModule("BaseSchemaModuleV2", {
				id: this.sandbox.id + "_multiDeleteResultModule",
				instanceConfig: {
					generateViewContainerId: false,
					useHistoryState: false,
					schemaName: "MultiDeleteResultSchema",
					isSchemaConfigInitialized: true
				},
				keepAlive: true
			});
			sandbox.loadModule("BaseSchemaModuleV2", {
				id: this.sandbox.id + "_appLoadWatcherModule",
				instanceConfig: {
					generateViewContainerId: false,
					useHistoryState: false,
					schemaName: "AppLoadWatcherSchema",
					isSchemaConfigInitialized: true
				},
				keepAlive: true
			});
			sandbox.loadModule("BaseSchemaModuleV2", {
				id: this.sandbox.id + "_windowUnloadWatcherModule",
				instanceConfig: {
					generateViewContainerId: false,
					useHistoryState: false,
					schemaName: "WindowUnloadWatcher",
					isSchemaConfigInitialized: true
				},
				keepAlive: true
			});
		},

		/**
		 * @inheritDoc Terrasoft.configuration.BaseViewModule#subscribeMessages
		 * @overridden
		 */
		subscribeMessages: function() {
			this.callParent(arguments);
			const sandbox = this.sandbox;
			sandbox.subscribe("SideBarModuleDefInfo", this.onSideBarModuleDefInfo, this);
			sandbox.subscribe("ShowHideRightSidePanel", this.onShowHideRightPanel, this);
			sandbox.subscribe("SideBarVisibilityChanged", this.onSideBarVisibilityChanged, this);
			const navigationHelper = this.Ext.create("Terrasoft.NavigationHelper", {
				Ext: this.Ext,
				sandbox: sandbox
			});
			sandbox.subscribe("NavigateTo", navigationHelper.navigateTo, navigationHelper);
		},

		/**
		 * Initializes intro page.
		 * @protected
		 */
		initIntroPage: function() {
			this.defaultIntroPage = Terrasoft.configuration.defaultIntroPageName || this.defaultIntroPage;
		},

		/**
		 * Generates configuration for the left panel module.
		 * @protected
		 * @virtual
		 */
		onSideBarModuleDefInfo: function() {
			var sideBarConfig = this.sandbox.publish("GetSideBarConfig");
			if (sideBarConfig) {
				this.sandbox.publish("PushSideBarModuleDefInfo", sideBarConfig.items);
			} else {
				var me = this;
				ViewModuleHelper.getSideBarDefaultConfig(function(config) {
					var menuItems = Ext.isObject(config) ? config.items : config;
					me.sandbox.publish("PushSideBarModuleDefInfo", menuItems);
				});
			}
		},

		/**
		 * Changes css class of the element.
		 * @protected
		 * @virtual
		 * @param {String} elementName Element name.
		 * @param {String} oldCssClass Old css class.
		 * @param {String} cssClass New css class.
		 */
		changeItemClass: function(elementName, oldCssClass, cssClass) {
			var element = Ext.get(elementName);
			if (element.hasCls(oldCssClass)) {
				element.removeCls(oldCssClass);
				element.addCls(cssClass);
			}
		},

		/**
		 * Shows or hides left panel.
		 * @protected
		 * @virtual
		 * @param {Object} config Configuration of the action.
		 * @param {Boolean} config.forceShow Flag of the right panel state. If true panel will show,
		 * if false panel will hide.
		 */
		onShowHideRightPanel: function(config) {
			var forceShow = config && config.forceShow;
			var centerPanelClasses = ["center-panel-content", "default-center-panel-content"];
			var rightPanelClasses = ["right-panel", "default-right-panel"];
			var mainHeaderEl = Ext.get("mainHeaderContainer");
			var centerPanelContainerEl = Ext.get("centerPanelContainer");
			var communicationPanelEl = Ext.get("communicationPanel");
			if (Ext.isEmpty(mainHeaderEl) || Ext.isEmpty(centerPanelContainerEl) || Ext.isEmpty(communicationPanelEl)) {
				Terrasoft.delay(this.onShowHideRightPanel, this, 500, [config]);
				return;
			}
			mainHeaderEl.removeCls("opened-right-panel");
			centerPanelContainerEl.removeCls("opened-right-panel");
			communicationPanelEl.removeCls("opened-right-panel");
			if (forceShow) {
				rightPanelClasses.reverse();
				centerPanelClasses.reverse();
				mainHeaderEl.addCls("opened-right-panel");
				communicationPanelEl.addCls("opened-right-panel");
				centerPanelContainerEl.addCls("opened-right-panel");
			}
			this.changeItemClass("rightPanel", rightPanelClasses[0], rightPanelClasses[1]);
			this.changeItemClass("centerPanel", centerPanelClasses[0], centerPanelClasses[1]);
			this.sandbox.publish("ChangeGridUtilitiesContainerSize");
		},

		/**
		 * Hides or loads module into the specified panel.
		 * @pretected
		 * @virtual
		 * @param {Object} args Parameters for the changes visibility.
		 * @param {String} args.panel Panel name.
		 * @param {String} args.moduleName Module name.
		 */
		onSideBarVisibilityChanged: function(args) {
			var panelName = args.panel || "centerPanel";
			if (args.moduleName) {
				this.sandbox.loadModule(args.moduleName, {
					renderTo: panelName
				});
			} else {
				var panel = Ext.getCmp(panelName);
				var panelEl = panel.getWrapEl().el;
				panelEl.setVisibilityMode(Ext.dom.AbstractElement.DISPLAY);
				panelEl.setVisible(false);
			}
		},

		/**
		 * @inheritDoc Terrasoft.configuration.BaseViewModule#onLoadModule
		 * @overridden
		 */
		onLoadModule: function(config) {
			if (config.moduleName === "ProcessExecute") {
				this.loadProcessModule();
			} else {
				this.callParent(arguments);
			}
		},

		/**
		 * Loads lookup module with the process list for start.
		 * @protected
		 * @virtual
		 */
		loadProcessModule: function() {
			var vwSysProcessFilters = Terrasoft.createFilterGroup();
			vwSysProcessFilters.name = "vwSysProcessFiler";
			var sysWorkspaceFilter = Terrasoft.createColumnFilterWithParameter(
					Terrasoft.ComparisonType.EQUAL, "SysWorkspace",
					Terrasoft.SysValue.CURRENT_WORKSPACE.value);
			vwSysProcessFilters.addItem(sysWorkspaceFilter);
			var isMaxVersionFilter = Terrasoft.createColumnFilterWithParameter(
					Terrasoft.ComparisonType.EQUAL, "IsMaxVersion", 1);
			vwSysProcessFilters.addItem(isMaxVersionFilter);
			var businessProcessTagFilter = Terrasoft.createColumnFilterWithParameter(
					Terrasoft.ComparisonType.EQUAL, "TagProperty",
					ConfigurationConstants.SysProcess.BusinessProcessTag);
			vwSysProcessFilters.addItem(businessProcessTagFilter);
			var config = {
				entitySchemaName: "VwSysProcess",
				mode: "processMode",
				captionLookup: resources.localizableStrings.ProcessPageCaption,
				multiSelect: false,
				columnName: "Caption",
				filters: vwSysProcessFilters,
				commandLineEnabled: true
			};
			var handler = Terrasoft.emptyFn;
			LookupUtilities.OpenLookupPage(this.sandbox, {config: config, handler: handler}, this, null, false);
		},

		/**
		 * Loads the welcome window when log in.
		 * @private
		 */
		loadWelcomeScreen: function() {
			var isFirstLogin = this.Terrasoft.isFirstLogin;
			if (!isFirstLogin) {
				return;
			}
			this.Terrasoft.SysSettings.querySysSettings([
				"UseWelcomeScreen", "BuildType"
			], function(sysSettings) {
				var useWelcomeScreen = sysSettings.UseWelcomeScreen;
				if (!useWelcomeScreen) {
					return;
				}
				var buildType = sysSettings.BuildType;
				if (buildType.value === ConfigurationConstants.BuildType.Public) {
					this.loadWelcomeScreenModule();
				} else {
					this.Terrasoft.require(["profile!WelcomeScreenModule"], function(profile) {
						if (profile && profile.isShown) {
							return;
						}
						this.loadWelcomeScreenModule();
						this.Terrasoft.saveUserProfile("WelcomeScreenModule", {isShown: true});
					}, this);
				}
			}, this);
		},

		/**
		 * Loads module of the welcome screen.
		 * @private
		 */
		loadWelcomeScreenModule: function() {
			var config = {
				minWidth: 100,
				minHeight: 100,
				boxClasses: ["welcome-screen-modal-box"]
			};
			var moduleName = "WelcomeScreenModule";
			var moduleId = this.sandbox.id + "_" + moduleName;
			var renderTo = ModalBox.show(config, function() {
				this.sandbox.unloadModule(moduleId, renderTo);
			}.bind(this));
			this.sandbox.loadModule(moduleName, {
				id: moduleId,
				renderTo: renderTo
			});
		},

		/**
		 * @private
		 */
		_addClass: function() {
			if (Terrasoft.isAngularHost) {
				const centerPanelContainerEl = Ext.get("centerPanelContainer");
				centerPanelContainerEl.addCls("is-angular-host");
			}
		},

		/**
		 * @private
		 */
		_getDiff: function() {
			const diff = [];
			if (!Terrasoft.isAngularHost) {
				diff.push( {
					"operation": "insert",
					"name": "leftPanel",
					"values": {
						"itemType": Terrasoft.ViewItemType.MODULE,
						"moduleName": "SideBarModule",
						"classes": {
							"wrapClassName": ["left-panel", "left-panel-scroll", "fixed"]
						}
					}
				}, {
					"operation": "insert",
					"name": "mainHeader",
					"values": {
						"itemType": Terrasoft.ViewItemType.MODULE,
						"moduleName": "MainHeaderModule",
					}
				});
			}
			if (Terrasoft.isAngularHost) {
				diff.push({
					"operation": "insert",
					"name": "mainHeader",
					"values": {
						"itemType": Terrasoft.ViewItemType.MODULE,
						"moduleName": "MainHeader8xModule",
					}
				});
			}
			diff.push({
				"operation": "insert",
				"name": "centerPanelContainer",
				"values": {
					"itemType": Terrasoft.ViewItemType.CONTAINER,
					"wrapClass": ["center-panel"],
					"id": "centerPanelContainer",
					"selectors": {"wrapEl": "#centerPanelContainer"},
					"items": []
				}
			}, {
				"operation": "move",
				"name": "centerPanel",
				"parentName": "centerPanelContainer",
				"propertyName": "items",
				"index": 0
			}, );
			if (!Terrasoft.isAngularHost) {
				diff.push({
					"operation": "insert",
					"name": "communicationPanel",
					"values": {
						"itemType": Terrasoft.ViewItemType.MODULE,
						"moduleName": "CommunicationPanelModule",
						"classes": {
							"wrapClassName": ["communication-panel", "communication-panel-scroll", "fixed"]
						}
					}
				}, {
					"operation": "insert",
					"parentName": "centerPanelContainer",
					"propertyName": "items",
					"name": "rightPanel",
					"index": 1,
					"values": {
						"itemType": Terrasoft.ViewItemType.MODULE,
						"moduleName": "RightSideBarModule",
						"classes": {
							"wrapClassName": ["default-right-panel", "fixed"]
						}
					}
				});
			}
			return diff;
		},

		/**
		 * @private
		 */
		_tryRedirectToFreedomUI: async function() {
			const search = location.search?.toLowerCase();
			if (search?.indexOf("classicui") > 0) {
				return;
			}
			const hash = location.hash;
			const hashArray = hash?.split("/") || [];
			const redirected = await this._tryRedirectToFreedomUIFormPage(hashArray);
			if (!redirected) {
				this._tryRedirectToFreedomUIListPage(hashArray);
			}
		},

		/**
		 * @private
		 */
		_tryRedirectToFreedomUIFormPage: async function(hashArray) {
			if (Terrasoft.Features.getIsEnabled("DisableRedirectToFreedomUIFormPage")) {
				return false;
			}
			const cardState = ConfigurationEnums.CardStateV2
			const [_moduleName, editPage, operation, recordId] = hashArray;
			if (editPage && recordId && (operation === cardState.EDIT || operation === cardState.COPY)) {
				const pageInfo = await this._findFreedomUIFormPage(editPage, operation, recordId);
				if (pageInfo) {
					this._replaceHash(hashArray, pageInfo.cardModuleName, pageInfo.cardSchema);
					return true;
				}
			}
			return false;
		},

		/**
		 * @private
		 */
		_findFreedomUIFormPage: async function(classicUIPage, action, recordId) {
			const structure7x = Terrasoft.ModuleUtils.getEntityStructureBySchemaName(classicUIPage);
			const entityName = structure7x?.entitySchemaName;
			const structure8x = Terrasoft.ModuleUtils.getEntityStructureByName(entityName);
			const hasPageInStructure8x = structure8x?.pages?.some((x) => x.cardSchema === classicUIPage);
			if (hasPageInStructure8x) {
				return null;
			}
			const uiTypePriority = creatioUtils.UITypePriority.PreferFreedomUI;
			const options = { action, uiTypePriority, entityName, recordId };
			const page = await creatioUtils.NavigationUtils.getPageForActionAsync(options);
			if (!page || page.cardSchema === classicUIPage) {
				return null;
			}
			return {
				cardSchema: page.cardSchema,
				cardModuleName: page.cardModuleName || structure8x?.cardModuleName
			}
		},

		/**
		 * @private
		 */
		_tryRedirectToFreedomUIListPage: function(hashArray) {
			if (Terrasoft.Features.getIsDisabled("EnableRedirectToFreedomUIListPage")) {
				return false;
			}
			if (hashArray.length > 1 ) {
				const sectionPage = hashArray[1];
				const pageInfo = this._findFreedomUIListPage(sectionPage);
				if (pageInfo && sectionPage !== pageInfo.sectionSchema) {
					this._replaceHash(hashArray, pageInfo.sectionModule, pageInfo.sectionSchema);
					return true;
				}
			}
			return false;
		},

		/**
		 * @private
		 */
		_replaceHash: function(hashArray, moduleName, schemaName) {
			hashArray[0] = "#" + moduleName;
			hashArray[1] = schemaName;
			location.hash = hashArray.join("/");
		},

		/**
		 * @private
		 */
		_findFreedomUIListPage: function(classicUISection) {
			const structure = Terrasoft.ModuleUtils.getModuleStructureBySectionSchema(classicUISection);
			const moduleStructure = Terrasoft.ModuleUtils.getModuleStructure(structure?.entitySchemaName);
			if (moduleStructure?.section8X) {
				return {
					sectionModule: moduleStructure.sectionModule,
					sectionSchema: moduleStructure.sectionSchema
				};
			}
			return null;
		},

		/**
		 * @inheritDoc Terrasoft.configuration.BaseViewModule#getHomeModulePath
		 * @overridden
		 */
		getHomeModulePath: function() {
			return this.Terrasoft.combinePath(this.homeModule, this.defaultIntroPage);
		},

		/**
		 * @inheritDoc Terrasoft.configuration.BaseViewModule#initHistoryState
		 * @overridden
		 */
		initHistoryState: function() {
			if (Terrasoft.isAngularHost) {
				this.mixins.customEvent.publish.call(this, "ConfigurationViewModuleLoaded");
			}
			this.callParent(arguments);
		},
	});
	return viewModule;

});


