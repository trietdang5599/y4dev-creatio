Terrasoft.configuration.Structures["MainHeaderSchema"] = {innerHierarchyStack: ["MainHeaderSchemaCrtNUI", "MainHeaderSchemaHomePage", "MainHeaderSchemaCTIBase", "MainHeaderSchemaEmailMining", "MainHeaderSchemaSSP", "MainHeaderSchema"]};
define('MainHeaderSchemaCrtNUIStructure', ['MainHeaderSchemaCrtNUIResources'], function(resources) {return {schemaUId:'52446ecf-4b3e-41ce-8962-e48c63d583f8',schemaCaption: "MainHeaderSchema", parentSchemaName: "", packageName: "OmnichannelMessaging", schemaName:'MainHeaderSchemaCrtNUI',parentSchemaUId:'',extendParent:false,type:Terrasoft.SchemaType.EDIT_VIEW_MODEL_SCHEMA,entitySchema:'',name:'',extend:'Terrasoft.model.BaseViewModel',schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},schemaDifferences:function(){

}};});
define('MainHeaderSchemaHomePageStructure', ['MainHeaderSchemaHomePageResources'], function(resources) {return {schemaUId:'6c11a9b0-0131-435a-bd84-f74412ea2cda',schemaCaption: "MainHeaderSchema", parentSchemaName: "MainHeaderSchemaCrtNUI", packageName: "OmnichannelMessaging", schemaName:'MainHeaderSchemaHomePage',parentSchemaUId:'52446ecf-4b3e-41ce-8962-e48c63d583f8',extendParent:true,type:Terrasoft.SchemaType.EDIT_VIEW_MODEL_SCHEMA,entitySchema:'',name:'',extend:"MainHeaderSchemaCrtNUI",schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},schemaDifferences:function(){

}};});
define('MainHeaderSchemaCTIBaseStructure', ['MainHeaderSchemaCTIBaseResources'], function(resources) {return {schemaUId:'73565bea-1d59-43b3-b768-c5c49217e66f',schemaCaption: "MainHeaderSchema", parentSchemaName: "MainHeaderSchemaHomePage", packageName: "OmnichannelMessaging", schemaName:'MainHeaderSchemaCTIBase',parentSchemaUId:'6c11a9b0-0131-435a-bd84-f74412ea2cda',extendParent:true,type:Terrasoft.SchemaType.EDIT_VIEW_MODEL_SCHEMA,entitySchema:'',name:'',extend:"MainHeaderSchemaHomePage",schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},schemaDifferences:function(){

}};});
define('MainHeaderSchemaEmailMiningStructure', ['MainHeaderSchemaEmailMiningResources'], function(resources) {return {schemaUId:'330b80dd-98a1-4bc3-bea1-51a6cf42d7b2',schemaCaption: "MainHeaderSchema", parentSchemaName: "MainHeaderSchemaCTIBase", packageName: "OmnichannelMessaging", schemaName:'MainHeaderSchemaEmailMining',parentSchemaUId:'73565bea-1d59-43b3-b768-c5c49217e66f',extendParent:true,type:Terrasoft.SchemaType.EDIT_VIEW_MODEL_SCHEMA,entitySchema:'',name:'',extend:"MainHeaderSchemaCTIBase",schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},schemaDifferences:function(){

}};});
define('MainHeaderSchemaSSPStructure', ['MainHeaderSchemaSSPResources'], function(resources) {return {schemaUId:'3693e993-1c10-40eb-b471-223aea3eae68',schemaCaption: "MainHeaderSchema", parentSchemaName: "MainHeaderSchemaEmailMining", packageName: "OmnichannelMessaging", schemaName:'MainHeaderSchemaSSP',parentSchemaUId:'330b80dd-98a1-4bc3-bea1-51a6cf42d7b2',extendParent:true,type:Terrasoft.SchemaType.EDIT_VIEW_MODEL_SCHEMA,entitySchema:'',name:'',extend:"MainHeaderSchemaEmailMining",schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},schemaDifferences:function(){

}};});
define('MainHeaderSchemaStructure', ['MainHeaderSchemaResources'], function(resources) {return {schemaUId:'e7a55b95-1a9c-4f58-b621-dea85c191dcc',schemaCaption: "MainHeaderSchema", parentSchemaName: "MainHeaderSchemaSSP", packageName: "OmnichannelMessaging", schemaName:'MainHeaderSchema',parentSchemaUId:'3693e993-1c10-40eb-b471-223aea3eae68',extendParent:true,type:Terrasoft.SchemaType.EDIT_VIEW_MODEL_SCHEMA,entitySchema:'',name:'',extend:"MainHeaderSchemaSSP",schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},schemaDifferences:function(){

}};});
define('MainHeaderSchemaCrtNUIResources', ['terrasoft'], function(Terrasoft) {
var localizableStrings={

};
var parametersLocalizableStrings={};
var localizableImages={

};
return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});
define("MainHeaderSchemaCrtNUI", ["IconHelper", "ConfigurationConstants", "HomePageInWorkplaceUtils",
	"MainHeaderSchemaResources", "SystemOperationsPermissionsMixinResources", "WizardUtilities",
	"css!MainHeaderCSS", "CheckModuleDestroyMixin", "MainMenuUtilities", "ManageApplicationRouter"
], function(
	iconHelper,
	ConfigurationConstants,
	HomePageInWorkplaceUtils,
	resources,
	permissionResources,
	) {
	return {
		properties: {
			/**
			 * @type {String}
			 */
			openedSchemaName: null
		},
		attributes: {
			/**
			 * Main header caption.
			 * @private
			 * @type {String}
			 */
			"HeaderCaption": {
				dataValueType: this.Terrasoft.DataValueType.TEXT,
				value: ""
			},

			/**
			 * Page header caption.
			 * @private
			 * @type {String}
			 */
			"PageHeaderCaption": {
				dataValueType: this.Terrasoft.DataValueType.TEXT,
				value: ""
			},

			/**
			 * Header caption marker value.
			 * @private
			 * @type {String}
			 */
			"HeaderCaptionMarkerValue": {
				dataValueType: this.Terrasoft.DataValueType.TEXT,
				value: ""
			},

			/**
			 * Name of current active view.
			 * @private
			 * @type {String}
			 */
			"ActiveViewName": {
				dataValueType: this.Terrasoft.DataValueType.TEXT,
				value: ""
			},

			/**
			 * Section buttons view collection.
			 * @private
			 * @type {Terrasoft.Collection}
			 */
			"ViewButtons": {
				dataValueType: this.Terrasoft.DataValueType.CUSTOM_OBJECT,
				value: this.Ext.create("Terrasoft.Collection")
			},

			/**
			 * Is main menu flag.
			 * @private
			 * @type {Boolean}
			 */
			"IsMainMenu": {
				dataValueType: this.Terrasoft.DataValueType.BOOLEAN,
				value: false
			},

			/**
			 * Is main header caption visible flag.
			 * @private
			 * @type {Boolean}
			 */
			"IsCaptionVisible": {
				dataValueType: this.Terrasoft.DataValueType.BOOLEAN,
				value: true
			},

			/**
			 * Is command line visible flag.
			 * @private
			 * @type {Boolean}
			 */
			"IsCommandLineVisible": {
				dataValueType: this.Terrasoft.DataValueType.BOOLEAN,
				value: false
			},

			/**
			 * Is current user type is SSP flag.
			 * @private
			 * @type {Boolean}
			 */
			"IsSSP": {
				dataValueType: this.Terrasoft.DataValueType.BOOLEAN,
				value: (this.Terrasoft.CurrentUser.userType === this.Terrasoft.UserType.SSP)
			},

			/**
			 * Global search feature enable .
			 * @private
			 * @type {Boolean}
			 */
			"IsGlobalSearchEnable": {
				dataValueType: this.Terrasoft.DataValueType.BOOLEAN,
				value: this.Terrasoft.Features.getIsEnabled("GlobalSearch")
			},

			/**
			 * Is context help visible flag.
			 * @private
			 * @type {Boolean}
			 */
			"IsContextHelpVisible": {
				dataValueType: this.Terrasoft.DataValueType.BOOLEAN,
				value: false
			},

			/**
			 * Is system designer button visible flag.
			 * @private
			 * @type {Boolean}
			 */
			"IsSystemDesignerVisible": {
				dataValueType: this.Terrasoft.DataValueType.BOOLEAN,
				value: false
			},

			/**
			 * Is user photo visible flag.
			 * @private
			 * @type {Boolean}
			 */
			"IsUserPhotoVisible": {
				dataValueType: this.Terrasoft.DataValueType.BOOLEAN,
				value: true
			},

			/**
			 * Is logo visible flag.
			 * @private
			 * @type {Boolean}
			 */
			"IsLogoVisible": {
				dataValueType: this.Terrasoft.DataValueType.BOOLEAN,
				value: true
			},

			/**
			 * Is main header panel visible flag.
			 * @private
			 * @type {Boolean}
			 */
			"IsMainHeaderVisible": {
				dataValueType: this.Terrasoft.DataValueType.BOOLEAN,
				value: true
			},

			/**
			 * Current user photo id.
			 * @private
			 * @type {String}
			 */
			"ContactPhotoId": {
				dataValueType: this.Terrasoft.DataValueType.TEXT,
				value: ""
			},

			/**
			 * Loaded module name.
			 * @private
			 * @type {String}
			 */
			"ModuleName": {
				dataValueType: this.Terrasoft.DataValueType.TEXT,
				value: ""
			},

			/**
			 * Profile button menu collection.
			 * @private
			 * @type {Terrasoft.BaseViewModelCollection}
			 */
			"ProfileMenuCollection": {
				dataValueType: this.Terrasoft.DataValueType.COLLECTION,
				value: this.Ext.create("Terrasoft.BaseViewModelCollection")
			},

			/**
			 * Configuration version.
			 */
			"ConfigurationVersion": {
				dataValueType: Terrasoft.DataValueType.TEXT
			},

			/**
			 * Show configuration version.
			 */
			"ShowConfigurationVersion": {
				dataValueType: Terrasoft.DataValueType.BOOLEAN
			},

			"IsSystemDesignerButtonVisible": {
				dataValueType: Terrasoft.DataValueType.BOOLEAN,
				value: true
			},

			"IsEditPageButtonVisible": {
				dataValueType: Terrasoft.DataValueType.BOOLEAN,
				value: false
 			}
		},
		messages: {
			/**
			 * @message SelectedSideBarItemChanged
			 * Change selection of current section in sections menu of left panel.
			 * @param {String} Section structure(E.c. "SectionModuleV2/AccountPageV2/" or "DashboardsModule/").
			 */
			"SelectedSideBarItemChanged": {
				mode: this.Terrasoft.MessageMode.PTP,
				direction: this.Terrasoft.MessageDirectionType.PUBLISH
			},

			/**
			 * @message ContextHelpModuleLoaded
			 * Notify about the ContextHelpModule is loaded.
			 */
			"ContextHelpModuleLoaded": {
				mode: this.Terrasoft.MessageMode.BROADCAST,
				direction: this.Terrasoft.MessageDirectionType.PUBLISH
			},

			/**
			 * @message HistoryStateChanged
			 */
			"HistoryStateChanged": {
				"direction": Terrasoft.MessageDirectionType.SUBSCRIBE,
				"mode": Terrasoft.MessageMode.BROADCAST
			},

			/**
			 * @message PushHistoryState
			 */
			"PushHistoryState": {
				mode: Terrasoft.MessageMode.BROADCAST,
				direction: Terrasoft.MessageDirectionType.PUBLISH
			},

			/**
			 * @message GetWorkplaceInfo
			 */
			"GetWorkplaceInfo": {
				mode: Terrasoft.MessageMode.PTP,
				direction: Terrasoft.MessageDirectionType.PUBLISH
			},

			/**
			 * @message SchemaViewChanged
			 */
			"SchemaViewChanged": {
				mode: Terrasoft.MessageMode.BROADCAST,
				direction: Terrasoft.MessageDirectionType.SUBSCRIBE
			},

			/**
			 * @message GetSchemaViewInfo
			 */
			"GetSchemaViewInfo": {
				mode: Terrasoft.MessageMode.PTP,
				direction: Terrasoft.MessageDirectionType.PUBLISH
			},
		},
		mixins: {
			/**
			 * @class CheckModuleDestroyMixin Implements publish and show CanBeDestroy message.
			 */
			CheckModuleDestroyMixin: "Terrasoft.CheckModuleDestroyMixin",

			/**
			 * Mixin implements work with the partition wizard.
			 */
			WizardUtilities: "Terrasoft.WizardUtilities",

			/**
			 * Mixin implements work with navigation to Application hub.
			 */
			ManageApplicationRouter: "Terrasoft.ManageApplicationRouter"
		},
		methods: {

			/**
			 * @inheritdoc Terrasoft.BaseSchemaViewModel#init
			 * @override
			 */
			init: function(callback, scope) {
				this.callParent([
					Terrasoft.chain(
						this._initShowConfigurationVersion,
						function(next) {
							this._initManageApplicationRouter(next, scope);
						},
						function() {
							this._initConfigurationVersion();
							this._initSchemaName();
							this.subscribeSandboxEvents();
							if (this.Ext.isEmpty(this.get("HeaderCaption"))) {
								this.sandbox.publish("NeedHeaderCaption");
							}
							const contactPhotoId = this.Terrasoft.SysValue.CURRENT_USER_CONTACT.primaryImageValue;
							this.set("ContactPhotoId", contactPhotoId);
							this.Ext.callback(callback, scope || this);
						},
						this
					)
				]);
			},

			/**
			 * @inheritdoc Terrasoft.BaseSchemaViewModel#onRender
			 * @override
			 */
			onRender: function() {
				this.callParent(arguments);
				this.loadCommandModule();
				this.loadContextHelpModule();
			},

			/**
			 * Subscribes for sandbox events.
			 * @protected
			 */
			subscribeSandboxEvents: function() {
				this.sandbox.subscribe("InitDataViews", function() {
					this.onInitDataViews(arguments);
					this.fixHeaderWidth();
				}, this);
				this.sandbox.subscribe("ChangeHeaderCaption", function(args) {
					this.set("HeaderCaption", args.caption);
					this.set("HeaderCaptionMarkerValue", args.markerValue || args.caption);
					this.set("ModuleName", args.moduleName ? args.moduleName : "");
					if (args.dataViews) {
						this.setButtons(args);
					}
					this.fixHeaderWidth();
					if (args.hidePageCaption) {
						Terrasoft.utils.dom.setAttributeToBody("is-card-opened", false);
					}
				}, this);
				this.sandbox.subscribe("UpdatePageHeaderCaption", function(args) {
					if (args.hasOwnProperty("pageHeaderCaption")) {
						this.set("PageHeaderCaption", args.pageHeaderCaption ||
							this.get("Resources.Strings.DefaultPageHeaderCaption"));
					}
				}, this);
				this.sandbox.subscribe("HistoryStateChanged", this.setIsEditPageButtonVisible, this);
				this.sandbox.subscribe("SchemaViewChanged", this.onSchemaViewChanged, this);
			},

			/**
			 * Loads command line module.
			 * @private
			 */
			loadCommandModule: function() {
				var commandLineContainer = this.Ext.getCmp("header-command-line-container");
				if (commandLineContainer && commandLineContainer.rendered) {
					this.sandbox.loadModule("CommandLineModule", {
						renderTo: "header-command-line-container"
					});
				}
			},

			/**
			 * Loads profile button menu items.
			 * @protected
			 */
			loadProfileButtonMenu: function() {
				var profileMenuCollection = this.get("ProfileMenuCollection");
				profileMenuCollection.addItem(this.Ext.create("Terrasoft.BaseViewModel", {
					values: {
						Id: "profile-menu-item",
						Caption: this.get("Resources.Strings.ProfileMenuItemCaption"),
						Click: {
							bindTo: "onProfileMenuItemClick"
						},
						canExecute: {
							bindTo: "canBeDestroyed"
						},
						MarkerValue: this.get("Resources.Strings.ProfileMenuItemCaption"),
						ImageConfig: this.get("Resources.Images.YourProfileIcon")
					}
				}));
				profileMenuCollection.addItem(this.Ext.create("Terrasoft.BaseViewModel", {
					values: {
						Id: "separator-profil-menu-item",
						Type: "Terrasoft.MenuSeparator",
						Caption: ""
					}
				}));
				profileMenuCollection.addItem(this.Ext.create("Terrasoft.BaseViewModel", {
					values: {
						Id: "exit-menu-item",
						Caption: this.get("Resources.Strings.ExitMenuItemCaption"),
						Click: {
							bindTo: "onExitMenuItemClick"
						},
						canExecute: {
							bindTo: "canBeDestroyed"
						},
						MarkerValue: this.get("Resources.Strings.ExitMenuItemCaption")
					}
				}));
			},

			/**
			 * Loads module of context help button.
			 * @private
			 */
			loadContextHelpModule: function() {
				const contextHelpContainer = this.Ext.getCmp("header-context-help-container");
				if (contextHelpContainer && contextHelpContainer.rendered) {
					const contextHelpModuleId = this.sandbox.loadModule("ContextHelpModule", {
						renderTo: "header-context-help-container"
					});
					let currentConfig;
					this.sandbox.subscribe("InitContextHelp", function(config) {
						currentConfig = config;
						this.sandbox.publish("ChangeContextHelpId", config, [contextHelpModuleId]);
					}, this);
					this.sandbox.subscribe("GetContextHelpId", function() {
						return currentConfig;
					}, this, [contextHelpModuleId]);
					this.sandbox.publish("ContextHelpModuleLoaded");
				}
			},

			/**
			 * Unloads command line module.
			 * @private
			 */
			unloadCommandModule: function() {
				this.sandbox.unloadModule("CommandLineModule");
			},

			/**
			 * Unloads module of context help button.
			 * @private
			 */
			unloadContextHelpModule: function() {
				this.sandbox.unloadModule("ContextHelpModule");
			},

			/**
			 * Reloads command line module.
			 * @private
			 */
			reloadCommandModule: function() {
				this.unloadCommandModule();
				this.loadCommandModule();
			},

			/**
			 * Reloads module of context help button.
			 * @private
			 */
			reloadContextHelpModule: function() {
				this.unloadContextHelpModule();
				this.loadContextHelpModule();
			},

			/**
			 * Returns View buttons visible flag.
			 * @return {boolean} View buttons visible flag.
			 */
			getIsButtonsVisible: function() {
				return (this.get("ViewButtons").getCount() > 1);
			},

			/**
			 * Returns main header dom attributes.
			 * @return {Object} Main header dom attributes.
			 */
			getMainHeaderAttributes: function() {
				return {
					"is-main-menu-header": this.get("IsMainMenu")
				};
			},

			/**
			 * Todo #CRM-21525.
			 * Change caption container width.
			 * @private
			 */
			fixHeaderWidth: function() {
				var captionContainer = this.Ext.get("caption");
				if (!captionContainer) {
					return;
				}
				var viewButtonsVisible = this.getIsButtonsVisible();
				if (viewButtonsVisible) {
					captionContainer.removeCls("fix-width");
				} else {
					captionContainer.addCls("fix-width");
				}
			},

			/**
			 * Change main header panel state.
			 * @private
			 * @param {Object[]} config Main header panel config.
			 */
			onInitDataViews: function(config) {
				var conf = (config && config[0].settings) ? config[0].settings : config[0];
				if (conf.hideMainHeader) {
					Terrasoft.utils.dom.setAttributeToBody("is-main-header-visible", false);
				}
				if (conf.hidePageCaption) {
					Terrasoft.utils.dom.setAttributeToBody("is-card-opened", false);
				}
				if (conf.dataViews) {
					this.setButtons(conf);
				} else {
					this.set("ViewButtons", new this.Terrasoft.Collection());
					this.setSettings(conf);
				}
				if (!this.Ext.isEmpty(conf.caption)) {
					this.set("HeaderCaption", conf.caption);
				}
				this.set("HeaderCaptionMarkerValue", conf.markerValue || conf.caption || "");
				this.set("ModuleName", conf.moduleName || "");
			},

			/**
			 * Sets view buttons.
			 * @param {Object} config Main header panel config.
			 */
			setButtons: function(config) {
				var buttons = new this.Terrasoft.Collection();
				var buttonsContainer = this.Ext.getCmp("button-switch");
				if (buttonsContainer) {
					this.clearContainerItems("button-switch");
					config.dataViews.each(function(item) {
						var bConfig = item.icon
							? this.createViewIconButtonConfig(item)
							: this.createButtonConfig(item);
						if (item.markerValue) {
							bConfig.markerValue = item.markerValue;
						}
						if (item.active) {
							this.set("ActiveViewName", item.name);
						}
						Ext.apply(bConfig, {
							canExecute: {
								bindTo: "canBeDestroyed"
							}
						});
						buttons.add(bConfig);
						buttonsContainer.add(bConfig);
					}, this);
					this.set("ViewButtons", buttons);
					this.setSettings(config);
					buttonsContainer.bind(this);
					this.setPressedViewButtons(this.get("ActiveViewName"));
				}
			},

			/**
			 * Handles profile menu item click.
			 * @private
			 */
			onProfileMenuItemClick: function() {
				this.sandbox.publish("PushHistoryState", {
					hash: "UserProfile",
					stateObj: {forceNotInChain: true}
				});
			},

			/**
			 * @deprecated
			 */
			replaceWindowLocation: function(location) {
				window.location.replace(location);
			},

			/**
			 * Handles exit menu item click.
			 * @private
			 */
			onExitMenuItemClick: async function() {
				await Terrasoft.MainMenuUtilities.logout();
			},

			/**
			 * Handles logo click.
			 * @private
			 */
			onLogoClick: function() {
				this.openHomePage();
			},

			/**
			 * @private
			 */
			_openPortalHomePage: function() {
				const defaultPortalHomeModule = ConfigurationConstants.DefaultPortalHomeModule;
				this.sandbox.publish("SelectedSideBarItemChanged", defaultPortalHomeModule,
					["sectionMenuModule"]);
				this.sandbox.publish("PushHistoryState", {
					hash: defaultPortalHomeModule,
					stateObj: {forceNotInChain: true}
				});
			},

			/**
			 * @private
			 */
			_openDefaultIntroPage: function() {
				const defaultIntroPageName = Terrasoft.configuration.defaultIntroPageName;
				if (defaultIntroPageName) {
					const defaultHomeModule = ConfigurationConstants.DefaultHomeModule;
					const hash = this.Terrasoft.combinePath(defaultHomeModule, defaultIntroPageName);
					this.sandbox.publish("PushHistoryState", {
						hash: hash,
						stateObj: {forceNotInChain: true}
					});
				}
			},

			/**
			 * Open home page.
			 * @protected
			 */
			openHomePage: function(callback, scope) {
				if (this.get("IsSSP")) {
					this._openPortalHomePage();
				} else {
					if (Terrasoft.Features.getIsDisabled("DisableHomePageInWorkplace")) {
						return HomePageInWorkplaceUtils
							.openCurrentWorkplaceDefaultSectionAsync(this.sandbox)
							.then(() => Ext.callback(callback, scope));
					}
					this._openDefaultIntroPage();
				}
				Ext.callback(callback, scope);
			},

			/**
			 * Handles system designer button click.
			 * @private
			 */
			onSystemDesignerClick: function() {
				const historyStateHash = this.sandbox.publish("GetHistoryState").hash.historyState;
				const systemDesignerHash = "IntroPage/SystemDesigner";
				if (historyStateHash !== systemDesignerHash) {
					Terrasoft.Mask.show();
					this.sandbox.publish("PushHistoryState", {
						hash: systemDesignerHash,
						stateObj: {forceNotInChain: true}
					});
				}
			},

			/**
			 * Handles system designer button click.
			 * @private
			 */
			onManageApplicationClick: function() {
				this.openApplicationManagement();
			},

			/**
			 * Handler dev button click.
			 * @private
			 */
			onDevButtonClick: function() {
				const url = Terrasoft.workspaceBaseUrl + "/Dev";
				window.open(url);
			},

			/**
			 * Handler shell button click.
			 * @private
			 */
			onShellButtonClick: function() {
				const url = Terrasoft.getAngularHostUrl();
				window.open(url);
			},

			/**
			 * Handles section caption click.
			 * @private
			 */
			onCaptionClick: function() {
				this.updateSection();
			},

			/**
			 * Updates section.
			 * @private
			 */
			updateSection: function() {
				this.sandbox.publish("UpdateSection", null, [this.get("ModuleName") + "_UpdateSection"]);
			},

			/**
			 * Resets filters and updates section.
			 * @private
			 */
			resetSection: function() {
				this.sandbox.publish("ResetSection", null, [this.get("ModuleName") + "_ResetSection"]);
			},

			/**
			 * Handles view button click.
			 * @private
			 */
			onViewButtonClick: function() {
				const tag = arguments[3];
				this.setPressedViewButtons(tag);
				const viewConfig = {
					tag: tag,
					moduleName: this.get("ModuleName")
				};
				this.sandbox.publish("ChangeDataView", viewConfig, [this.sandbox.id + "_" + viewConfig.moduleName]);
			},

			/**
			 * Change view buttons style.
			 * @private
			 * @param {String} viewName View name.
			 */
			setPressedViewButtons: function(viewName) {
				const buttons = this.get("ViewButtons");
				const items = buttons.getItems();
				let isPressed = false;
				this.Terrasoft.each(items, function(item) {
					if (item.tag === viewName) {
						isPressed = true;
						this.set(item.tag + "Active", true);
					} else {
						this.set(item.tag + "Active", false);
					}
				}, this);
				if (!isPressed && items.length > 0) {
					this.set(items[0].tag + "Active", true);
				}
			},

			/**
			 * Sets main header visible flag.
			 * @private
			 * @param {Object} config Main header panel config.
			 */
			setMainHeaderVisible: function(config) {
				const mainHeader = this.Ext.get("mainHeader");
				const centerPanelContainer = this.Ext.get("centerPanelContainer");
				if (!mainHeader && !centerPanelContainer) {
					return;
				}
				if (config.hasOwnProperty("isMainHeaderVisible")) {
					mainHeader.setVisible(config.isMainHeaderVisible);
					centerPanelContainer.addCls("center-panel-no-padding-top");
				} else {
					mainHeader.setVisible(true);
					centerPanelContainer.removeCls("center-panel-no-padding-top");
				}
			},

			/**
			 * Sets main header visible flag.
			 * @private
			 * @param {Object} config Main header panel config.
			 */
			setUserPhotoVisible: function(config) {
				if (config.hasOwnProperty("isUserPhotoVisible")) {
					this.set("IsUserPhotoVisible", config.isUserPhotoVisible);
				} else {
					this.set("IsUserPhotoVisible", true);
				}
			},

			/**
			 * Sets caption visible flag.
			 * @private
			 * @param {Object} config Main header panel config.
			 */
			setCaptionVisible: function(config) {
				if (config.hasOwnProperty("isCaptionVisible")) {
					this.set("IsCaptionVisible", config.isCaptionVisible);
				} else {
					this.set("IsCaptionVisible", true);
				}
			},

			/**
			 * Sets is main menu flag and logo visible flag.
			 * @private
			 * @param {Object} config Main header panel config.
			 */
			setIsMainMenuAndLogoVisible: function(config) {
				var logoVisible = true;
				if (config.hasOwnProperty("isMainMenu")) {
					this.set("IsMainMenu", config.isMainMenu);
					logoVisible = false;
					this.set("IsLogoVisible", logoVisible);
				} else {
					this.set("IsMainMenu", false);
					this.set("IsLogoVisible", logoVisible);
				}
				if (config.hasOwnProperty("isLogoVisible")) {
					this.set("IsLogoVisible", config.isLogoVisible);
				} else {
					this.set("IsLogoVisible", logoVisible);
				}
			},

			/**
			 * Sets main header panel state by config.
			 * @private
			 * @param {Object} config Main header panel config.
			 */
			setSettings: function(config) {
				this.setMainHeaderVisible(config);
				this.setCaptionVisible(config);
				this.setIsMainMenuAndLogoVisible(config);
				this.commandLineVisible(config);
				this.contextHelpVisible(config);
				this.setSystemDesignerVisible(config);
				this.setUserPhotoVisible(config);
			},

			/**
			 * Command line enabled for current user.
			 * @private
			 * @return {Boolean}
			 */
			commandLineForCurrentUserEnable: function() {
				var userTypeSSP = this.$IsSSP;
				var globalSearchEnabled = this.$IsGlobalSearchEnable;
				var isEnabledIfUserSSP = userTypeSSP && globalSearchEnabled;
				return isEnabledIfUserSSP || !userTypeSSP;
			},

			/**
			 * Sets command line visible flag.
			 * @private
			 * @param {Object} config Main header panel config.
			 */
			commandLineVisible: function(config) {
				let isCommandLineVisible = this.commandLineForCurrentUserEnable();
				if (isCommandLineVisible && config.hasOwnProperty("isCommandLineVisible")) {
					isCommandLineVisible = config.isCommandLineVisible;
				}
				if (this.get("IsCommandLineVisible") !== isCommandLineVisible) {
					this.set("IsCommandLineVisible", isCommandLineVisible);
					this.reloadCommandModule();
				}
			},

			/**
			 * Sets context help visible flag.
			 * @private
			 * @param {Object} config Main header panel config.
			 */
			contextHelpVisible: function(config) {
				let isContextHelpVisible = !this.get("IsSSP");
				if (isContextHelpVisible && config.hasOwnProperty("isContextHelpVisible")) {
					isContextHelpVisible = config.isContextHelpVisible;
				}
				if (this.get("IsContextHelpVisible") !== isContextHelpVisible) {
					this.set("IsContextHelpVisible", isContextHelpVisible);
					this.reloadContextHelpModule();
				}
			},

			/**
			 * Sets system designer button visible flag.
			 * @private
			 * @param {Object} config Main header panel config.
			 */
			setSystemDesignerVisible: function(config) {
				let isSystemDesignerVisible = !this.get("IsSSP");
				if (config.hasOwnProperty("isSystemDesignerVisible")) {
					isSystemDesignerVisible = config.isSystemDesignerVisible;
				}
				this.Terrasoft.SysSettings.querySysSettings(["BuildType"], function(sysSettings) {
					const buildType = sysSettings.BuildType;
					if (buildType && (buildType.value === ConfigurationConstants.BuildType.Public)) {
						isSystemDesignerVisible = false;
					}
					this.set("IsSystemDesignerVisible", isSystemDesignerVisible);
				}, this);
			},

			/**
			 * Clears main header caption.
			 * @private
			 */
			clearHeader: function() {
				const mainHeader = this.Ext.get("mainHeader");
				if (mainHeader && !mainHeader.isVisible()) {
					mainHeader.setVisible(true);
				}
				this.set("HeaderCaption", "");
				this.set("HeaderCaptionMarkerValue", "");
			},

			/**
			 * Todo #CRM-21525.
			 * Clears and re-render container.
			 * @param {String} containerId Containers id.
			 * @param {Boolean} needRerender Is need render flag.
			 */
			clearContainerItems: function(containerId, needRerender) {
				const container = this.Ext.getCmp(containerId);
				if (container && container.getWrapEl()) {
					if (container.getWrapEl()) {
						container.items.each(function(item) {
							container.remove(item);
							item.destroy();
						}, this);
					}
				}
				if (needRerender) {
					container.reRender();
				}
			},

			/**
			 * Creates view button config.
			 * @private
			 * @param {Object} config View config.
			 * @return {Object} View button config.
			 */
			createViewIconButtonConfig: function(config) {
				const buttonConfig = iconHelper.createIconButtonConfig(config);
				buttonConfig.imageConfig = {
					source: Terrasoft.ImageSources.URL,
					url: Terrasoft.ImageUrlBuilder.getUrl(config.icon)
				};
				return buttonConfig;
			},

			/**
			 * Creates button config.
			 * @private
			 * @param {Object} config Config
			 * @return {Object} Button config.
			 */
			createButtonConfig: function(config) {
				const buttonConfig = {
					caption: config.caption ? config.caption : config.name,
					tag: [config.name, config.caption],
					markerValue: [config.name, config.caption],
					hint: config.hint,
					className: "Terrasoft.Button",
					style: this.Terrasoft.controls.ButtonEnums.style.DEFAULT,
					pressed: {bindTo: config.name + "Active"},
					click: {bindTo: config.func ? config.func : "onViewButtonClick"},
					classes: {
						textClass: ["view-no-images-class"],
						pressedClass: ["pressed-button-view"]
					},
					menu: {
						items: {
							bindTo: "ProfileMenuCollection"
						},
						ulClass: "profile-menu"
					}
				};
				return buttonConfig;
			},

			/**
			 * Gets contact photo config.
			 * @private
			 * @return {Object} Photo config.
			 */
			getContactPhoto: function() {
				const photoId = this.get("ContactPhotoId");
				if (this.Terrasoft.isEmptyGUID(photoId)) {
					return this.get("Resources.Images.ContactEmptyPhoto");
				}
				const photoConfig = {
					source: this.Terrasoft.ImageSources.ENTITY_COLUMN,
					params: {
						schemaName: "SysImage",
						columnName: "Data",
						primaryColumnValue: photoId
					}
				};
				return {
					source: this.Terrasoft.ImageSources.URL,
					url: this.Terrasoft.ImageUrlBuilder.getUrl(photoConfig)
				};
			},

			/**
			 * Returns logo configuration.
			 * @param {String} logoName Logo name.
			 * @return {Object} Logo configuration.
			 */
			getLogoImageConfig: function(logoName) {
				const config = {
					params: {
						r: logoName
					},
					source: this.Terrasoft.ImageSources.SYS_SETTING
				};
				return this.Terrasoft.ImageUrlBuilder.getUrl(config);
			},

			/**
			 * @private
			 */
			_initConfigurationVersion: function() {
				let version = Terrasoft.coreVersion;
				if (Terrasoft.isDebug) {
					version += " Debug";
				}
				this.set("ConfigurationVersion", version);
			},

			/**
			 * @private
			 */
			_initShowConfigurationVersion: function(callback, scope) {
				Terrasoft.SysSettings.querySysSettingsItem("ShowConfigurationVersion", function(value) {
					this.$ShowConfigurationVersion = value;
					callback.call(scope);
				}, this);
			},

			_initManageApplicationRouter: function(callback, scope) {
				this.mixins.ManageApplicationRouter.init.call(this, callback, scope);
			},

			/**
			 * @private
			 */
			_callIfUrlExists: function(url, callback, scope) {
				const img = new Image();
				img.onload = function() {
					scope.Ext.callback(callback, scope, [true]);
				};
				img.onerror = function() {
					scope.Ext.callback(callback, scope, [false]);
				};
				img.src = url;
			},

			/**
			 * @private
			 */
			_initSchemaName: function() {
				if (this.openedSchemaName) {
					return;
				}
				let schemaViewInfo = this.sandbox.publish("GetSchemaViewInfo");
				this.onSchemaViewChanged(schemaViewInfo);
			},

			/**
			 * @protected
			 */
			getSchemaName: function() {
				return this.openedSchemaName;
			},

			/**
			 * @private
			 */
			_getSchemaType: function(schemaName, callback, scope) {
				const request = this._getSchemaPageEsq(schemaName);
				request.execute((response) => {
					const item = response.collection.first();
					const schemaType = item.get("SchemaType");
					callback.call(scope, schemaType);
				}, this);
			},

			/**
			 * @private
			 */
			_getSchemaPageEsq: function(schemaName) {
				const esqAngularHomePages = new Terrasoft.EntitySchemaQuery({
					rootSchemaName: "SysSchema",
					rowCount: 1,
				});
				esqAngularHomePages.addColumn("[SysSchemaProperty:SysSchema:Id].Value", "SchemaType");
				esqAngularHomePages.filters.add("SchemaNameFilter",
					Terrasoft.createColumnFilterWithParameter("Name", schemaName));
				esqAngularHomePages.filters.add("SchemaPropertyTypeFilter",
					Terrasoft.createColumnFilterWithParameter("[SysSchemaProperty:SysSchema:Id].Name", "SchemaType"));
				return esqAngularHomePages;
			},

			setIsEditPageButtonVisible: function() {
				this.set("IsEditPageButtonVisible", this.getIsEditPageButtonVisible());
			},

			/**
			 * @protected
			 */
			getIsEditPageButtonVisible: function() {
				return Boolean(this.openedSchemaName);
			},

			/**
			 * @protected
			 */
			handlingIncorrectSchemaType: this.Ext.emptyFn,

			/**
			 * Handle schema view changes.
			 * @param {Object} config changes schema view information.
			 */
			onSchemaViewChanged: function(config) {
				if (!config?.destroyed) {
					this.openedSchemaName = config?.schemaName;
				} else if (this.openedSchemaName === config?.schemaName) {
					this.openedSchemaName = null;
				}
				this.setIsEditPageButtonVisible();
			},

			_showRightsErrorMessage: function() {
				const message = permissionResources.localizableStrings.RightsErrorMessage +
						Ext.String.format(permissionResources.localizableStrings.CanNotChangeAdminOperationMessage,
								"CanManageSolution");
				Terrasoft.showInformation(message);
			},

			_getGoogleAction: function () {
				return "HomePageDesigner_OpenFromMain";
			},

			_getGoogleTagData: function (tag) {
				const sandbox = this.sandbox;
				return {
					action: tag,
					schemaName: this.name,
					moduleName: sandbox.moduleName,
					virtualUrl: Terrasoft.workspaceBaseUrl + "/" + sandbox.id
				};
			},

			_sendGoogleAnalytics: function () {
				const isGoogleTagManagerEnabled = this.get("IsGoogleTagManagerEnabled");
				if (!isGoogleTagManagerEnabled) {
					return;
				}
				const tag = this._getGoogleAction();
				const data = this._getGoogleTagData(tag);
				Terrasoft.GoogleTagManagerUtilities.actionModule(data);
			},

			/**
			 * Open home page designer.
			 * @protected
			 */
			openPageDesigner: function() {
				const schemaName = this.getSchemaName();
				Terrasoft.chain(
					(next) => this.canUseWizard(next, this),
					(next, canDesign) => {
						if (canDesign) {
							next();
						} else {
							this._showRightsErrorMessage();
						}
					},
					(next) => this._getSchemaType(schemaName, next, this),
					(next, schemaType) => {
						if (schemaType === "AngularSchema") {
							next();
						} else {
							this.handlingIncorrectSchemaType();
						}
					},
					() => {
						this._sendGoogleAnalytics();
						const baseUrl = Terrasoft.workspaceBaseUrl;
						const url = `${baseUrl}/ClientApp/#/InterfaceDesigner/${schemaName}`;
						window.open(url, "_blank");
					},
					this,
				)
			},
		},
		diff: [
			//main header
			{
				"operation": "insert",
				"name": "MainHeaderContainer",
				"values": {
					"id": "mainHeaderContainer",
					"selectors": {"wrapEl": "#mainHeaderContainer"},
					"itemType": Terrasoft.ViewItemType.CONTAINER,
					"wrapClass": ["main-header", "fixed"],
					"domAttributes": {"bindTo": "getMainHeaderAttributes"},
					"items": [],
					"tips": []
				}
			},
			//left header
			{
				"operation": "insert",
				"name": "LeftHeaderContainer",
				"parentName": "MainHeaderContainer",
				"propertyName": "items",
				"values": {
					"id": "left-header-container",
					"itemType": Terrasoft.ViewItemType.CONTAINER,
					"wrapClass": ["left-header-container-class"],
					"items": []
				}
			},
			//main header menu logo
			{
				"operation": "insert",
				"name": "MenuLogoImageContainer",
				"parentName": "LeftHeaderContainer",
				"propertyName": "items",
				"values": {
					"id": "main-header-menu-logo-image-container",
					"itemType": Terrasoft.ViewItemType.CONTAINER,
					"wrapClass": ["main-header-menu-logo-image-container-class"],
					"items": [],
					"visible": {"bindTo": "IsMainMenu"}
				}
			},
			{
				"operation": "insert",
				"name": "MenuLogoImage",
				"parentName": "MenuLogoImageContainer",
				"propertyName": "items",
				"values": {
					"id": "menuLogoImage",
					"selectors": {
						wrapEl: "#menuLogoImage"
					},
					"getSrcMethod": "getLogoImageConfig",
					"tag": "MenuLogoImage",
					"readonly": true,
					"generator": "ImageCustomGeneratorV2.generateSimpleCustomImage",
					"classes": {
						"wrapClass": ["main-header-menu-logo-image"]
					}
				}
			},
			{
				"operation": "insert",
				"name": "MenuLogoConfigurationVersionLabel",
				"parentName": "MenuLogoImageContainer",
				"propertyName": "items",
				"values": {
					"itemType": Terrasoft.ViewItemType.LABEL,
					"labelClass": ["configuration-version-label"],
					"caption": {"bindTo": "ConfigurationVersion"},
					"visible": {"bindTo": "ShowConfigurationVersion"}
				}
			},
			{
				"operation": "insert",
				"name": "MainHeaderCaption",
				"parentName": "LeftHeaderContainer",
				"propertyName": "items",
				"values": {
					"id": "caption",
					"selectors": {wrapEl: "#caption"},
					"itemType": Terrasoft.ViewItemType.CONTAINER,
					"wrapClass": ["caption-class"],
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "CaptionValue",
				"parentName": "MainHeaderCaption",
				"propertyName": "items",
				"values": {
					"itemType": Terrasoft.ViewItemType.LABEL,
					"classes": {
						"labelClass": ["header-section-caption-class", "cursor-pointer"]
					},
					"caption": {"bindTo": "HeaderCaption"},
					"markerValue": {
						"bindTo": "HeaderCaptionMarkerValue"
					},
					"visible": {
						"bindTo": "IsCaptionVisible"
					},
					"canExecute": {
						"bindTo": "canBeDestroyed"
					},
					"click": {
						"bindTo": "onCaptionClick"
					}
				}
			},
			// button switch
			{
				"operation": "insert",
				"name": "ViewButtonsContainer",
				"parentName": "LeftHeaderContainer",
				"propertyName": "items",
				"values": {
					"id": "button-switch",
					"selectors": {wrapEl: "#button-switch"},
					"itemType": Terrasoft.ViewItemType.CONTAINER,
					"wrapClass": ["button-class"],
					"items": [],
					"visible": {
						"bindTo": "getIsButtonsVisible"
					}
				}
			},
			//right header
			{
				"operation": "insert",
				"name": "RightHeaderContainer",
				"parentName": "MainHeaderContainer",
				"propertyName": "items",
				"values": {
					"id": "right-header-container",
					"itemType": Terrasoft.ViewItemType.CONTAINER,
					"wrapClass": ["right-header-container-class"],
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "PageHeaderContainer",
				"parentName": "RightHeaderContainer",
				"propertyName": "items",
				"values": {
					"id": "PageHeaderContainer",
					"selectors": {"wrapEl": "#PageHeaderContainer"},
					"itemType": Terrasoft.ViewItemType.CONTAINER,
					"wrapClass": ["page-header-container"],
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "PageHeaderCaption",
				"parentName": "PageHeaderContainer",
				"propertyName": "items",
				"values": {
					"itemType": Terrasoft.ViewItemType.LABEL,
					"caption": {"bindTo": "PageHeaderCaption"},
					"markerValue": {
						"bindTo": "HeaderCaptionMarkerValue"
					}
				}
			},
			// header right image
			{
				"operation": "insert",
				"name": "RightButtonsContainer",
				"parentName": "RightHeaderContainer",
				"propertyName": "items",
				"values": {
					"id": "header-right-image-container",
					"itemType": Terrasoft.ViewItemType.CONTAINER,
					"wrapClass": ["context-right-image-class"],
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "InnerRightButtonsContainer",
				"parentName": "RightButtonsContainer",
				"propertyName": "items",
				"values": {
					"itemType": Terrasoft.ViewItemType.CONTAINER,
					"wrapClass": ["inner-context-right-image-class"],
					"items": []
				}
			},
			// main header image
			{
				"operation": "insert",
				"name": "UserProfileContainer",
				"parentName": "InnerRightButtonsContainer",
				"propertyName": "items",
				"values": {
					"id": "main-header-image-container",
					"itemType": Terrasoft.ViewItemType.CONTAINER,
					"wrapClass": ["main-header-image-container-class"],
					"items": [],
					"visible": {"bindTo": "IsUserPhotoVisible"}
				}
			},
			{
				"operation": "insert",
				"name": "UserProfileButton",
				"parentName": "UserProfileContainer",
				"propertyName": "items",
				"values": {
					"id": "profile-user-button",
					"itemType": Terrasoft.ViewItemType.BUTTON,
					"selectors": {
						wrapEl: "#profile-user-button"
					},
					"classes": {
						"wrapperClass": ["photo-icon-wrapper"],
						"imageClass": ["photo-icon"],
						"markerClass": ["profile-photo-btn-marker-class"]
					},
					"hint": {"bindTo": "Resources.Strings.ProfileImageButtonHintCaption"},
					"controlConfig": {
						"style": this.Terrasoft.controls.ButtonEnums.style.TRANSPARENT,
						"iconAlign": this.Terrasoft.controls.ButtonEnums.iconAlign.LEFT,
						"imageConfig": {
							"bindTo": "getContactPhoto"
						},
						"menu": {
							"items": {
								"bindTo": "ProfileMenuCollection"
							},
							"ulClass": "profile-menu"
						}
					},
					"markerValue": "userProfileButton"
				}
			},
			//system designer
			{
				"operation": "insert",
				"name": "SystemDesignerContainer",
				"parentName": "InnerRightButtonsContainer",
				"propertyName": "items",
				"values": {
					"id": "header-system-designer-container",
					"itemType": Terrasoft.ViewItemType.CONTAINER,
					"wrapClass": ["context-system-designer-class"],
					"items": [],
					"visible": {"bindTo": "IsSystemDesignerVisible"}
				}
			},
			{
				"operation": "insert",
				"name": "SystemDesignerMenuButton",
				"parentName": "SystemDesignerContainer",
				"propertyName": "items",
				"values": {
					"id": "view-menu-button-system-designer",
					"itemType": Terrasoft.ViewItemType.BUTTON,
					"selectors": {
						"wrapEl": "#view-button-system-designer"
					},
					"classes": {
						"wrapperClass": ["system-designer-button"],
						"pressedClass": ["pressed-button-view"],
						"imageClass": ["system-designer-image", "view-images-class"]
					},
					"canExecute": {
						"bindTo": "canBeDestroyed"
					},
					"hint": {"bindTo": "Resources.Strings.SystemDesignerMenuButtonHint"},
					"imageConfig": {"bindTo": "Resources.Images.SystemDesignerIcon"},
					"style": this.Terrasoft.controls.ButtonEnums.style.TRANSPARENT,
					"iconAlign": this.Terrasoft.controls.ButtonEnums.iconAlign.LEFT,
					"markerValue": "system-designer",
					"tag": "system-designer",
					"menu": [],
					"menuConfig": {
						"alignType": "tr-br?",
						"offset": [4, 6],
						"ulClass": "main-header-menu"
					}
				}
			},
			{
				"operation": "insert",
				"name": "EditPageMenuItem",
				"parentName": "SystemDesignerMenuButton",
				"propertyName": "menu",
				"values": {
					"caption": {"bindTo": "Resources.Strings.EditPageCaption"},
					"itemType": this.Terrasoft.ViewItemType.MENU_ITEM,
					"markerValue": {"bindTo": "Resources.Strings.EditPageCaption"},
					"click": {"bindTo": "openPageDesigner"},
					"visible": {
						"bindTo": "IsEditPageButtonVisible",
					},
				}
			},
			{
				"operation": "insert",
				"name": "OpenSystemDesignerMenuItem",
				"parentName": "SystemDesignerMenuButton",
				"propertyName": "menu",
				"values": {
					"caption": {"bindTo": "Resources.Strings.OpenSystemDesignerCaption"},
					"itemType": this.Terrasoft.ViewItemType.MENU_ITEM,
					"markerValue": {"bindTo": "Resources.Strings.OpenSystemDesignerCaption"},
					"canExecute": {
						"bindTo": "canBeDestroyed"
					},
					"click": {"bindTo": "onSystemDesignerClick"}
				}
			},
			{
				"operation": "insert",
				"name": "OpenManageApplicationMenuItem",
				"parentName": "SystemDesignerMenuButton",
				"propertyName": "menu",
				"values": {
					"caption": {"bindTo": "Resources.Strings.OpenApplicationHubCaption"},
					"itemType": this.Terrasoft.ViewItemType.MENU_ITEM,
					"markerValue": {"bindTo": "Resources.Strings.OpenApplicationHubCaption"},
					"click": {"bindTo": "onManageApplicationClick"},
				}
			},
			// context help
			{
				"operation": "insert",
				"name": "ContextHelpContainer",
				"parentName": "InnerRightButtonsContainer",
				"propertyName": "items",
				"values": {
					"id": "header-context-help-container",
					"itemType": Terrasoft.ViewItemType.CONTAINER,
					"wrapClass": ["context-help-class"],
					"items": [],
					"visible": {"bindTo": "IsContextHelpVisible"}
				}
			},
			// dev
			{
				"operation": "insert",
				"name": "DevButtonContainer",
				"parentName": "InnerRightButtonsContainer",
				"propertyName": "items",
				"values": {
					"itemType": Terrasoft.ViewItemType.CONTAINER,
					"wrapClass": ["context-system-designer-class"],
					"items": [],
					"visible": Terrasoft.isDebug
				}
			},
			{
				"operation": "insert",
				"name": "DevButton",
				"parentName": "DevButtonContainer",
				"propertyName": "items",
				"values": {
					"itemType": Terrasoft.ViewItemType.BUTTON,
					"classes": {
						"wrapperClass": ["system-designer-button"],
						"pressedClass": ["pressed-button-view"],
						"imageClass": ["dev-button-image", "view-images-class"]
					},
					"hint": {
						"bindTo": "Resources.Strings.DevButtonCaption"
					},
					"click": {
						"bindTo": "onDevButtonClick"
					},
					"imageConfig": {
						"bindTo": "Resources.Images.DevButtonIcon"
					},
					"style": Terrasoft.controls.ButtonEnums.style.TRANSPARENT
				}
			},
			// shell
			{
				"operation": "insert",
				"name": "ShellButtonContainer",
				"parentName": "InnerRightButtonsContainer",
				"propertyName": "items",
				"values": {
					"itemType": Terrasoft.ViewItemType.CONTAINER,
					"wrapClass": ["context-system-designer-class"],
					"items": [],
					"visible": Terrasoft.isDebug
				}
			},
			{
				"operation": "insert",
				"name": "ShellButton",
				"parentName": "ShellButtonContainer",
				"propertyName": "items",
				"values": {
					"itemType": Terrasoft.ViewItemType.BUTTON,
					"classes": {
						"wrapperClass": ["system-designer-button"],
						"pressedClass": ["pressed-button-view"],
						"imageClass": ["shell-button-image", "view-images-class"]
					},
					"hint": {
						"bindTo": "Resources.Strings.ShellButtonCaption"
					},
					"click": {
						"bindTo": "onShellButtonClick"
					},
					"imageConfig": {
						"bindTo": "Resources.Images.ShellButtonIcon"
					},
					"style": Terrasoft.controls.ButtonEnums.style.TRANSPARENT
				}
			},
			//header command line
			{
				"operation": "insert",
				"name": "CommandLineContainer",
				"parentName": "RightHeaderContainer",
				"propertyName": "items",
				"values": {
					"id": "header-command-line-container",
					"itemType": Terrasoft.ViewItemType.CONTAINER,
					"wrapClass": ["command-line-class"],
					"items": [],
					"visible": {"bindTo": "IsCommandLineVisible"}
				}
			},
			//main header logo
			{
				"operation": "insert",
				"name": "RightLogoContainer",
				"parentName": "RightHeaderContainer",
				"propertyName": "items",
				"values": {
					"id": "main-header-logo-container",
					"itemType": Terrasoft.ViewItemType.CONTAINER,
					"wrapClass": ["main-header-logo-container-class"],
					"visible": {"bindTo": "IsLogoVisible"},
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "logoImage",
				"parentName": "RightLogoContainer",
				"propertyName": "items",
				"values": {
					"id": "logoImage",
					"itemType": Terrasoft.ViewItemType.COMPONENT,
					"selectors": {
						"wrapEl": "#logoImage"
					},
					"hint": {"bindTo": "Resources.Strings.LogoHint"},
					"className": "Terrasoft.ImageView",
					"imageSrc": {"bindTo": "getLogoImageConfig"},
					"tag": "HeaderLogoImage",
					"click": {"bindTo": "onLogoClick"},
					"canExecute": {
						"bindTo": "canBeDestroyed"
					},
					"classes": {
						"wrapClass": ["main-header-logo-image", "cursor-pointer"]
					}
				}
			},
			{
				"operation": "insert",
				"name": "LogonConfigurationVersionLabel",
				"parentName": "RightLogoContainer",
				"propertyName": "items",
				"values": {
					"itemType": Terrasoft.ViewItemType.LABEL,
					"labelClass": ["configuration-version-label"],
					"caption": {"bindTo": "ConfigurationVersion"},
					"visible": {"bindTo": "ShowConfigurationVersion"}
				}
			}
		]
	};
});

define('MainHeaderSchemaHomePageResources', ['terrasoft'], function(Terrasoft) {
var localizableStrings={

};
var parametersLocalizableStrings={};
var localizableImages={

};
return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});
define("MainHeaderSchemaHomePage", [], function() {
	return {
		methods: {

			/**
			 * @override
			 * @protected
			 */
			getSchemaName: function() {
				const hash = Terrasoft.router.Router.getHash();
				const pages = hash.split("/");
				const isHomePage = this._getIsHomePage();
				return isHomePage && !this.openedSchemaName ? pages[1] : this.openedSchemaName;
			},

			/**
			 * @protected
			 */
			handlingIncorrectSchemaType: function() {
				const caption = this.get("Resources.Strings.CannotEditPageMessage");
				const buttons = [
					{
						className: "Terrasoft.Button",
						returnCode: "redirect",
						caption: this.get("Resources.Strings.RedirectToWorkplaceCaption")
					},
					"cancel"
				];
				Terrasoft.showMessage({
					caption,
					scope: this,
					handler: this._navigateToWorkplace,
					style: Terrasoft.MessageBoxStyles.BLUE,
					buttons,
					defaultButton: 0
				});
			},

			/**
			 * @private
			 */
			_navigateToWorkplace: function(result) {
				if (result === "redirect") {
					const info = this.sandbox.publish("GetWorkplaceInfo", this.sandbox.id);
					this.sandbox.publish("PushHistoryState", {
						hash: "CardModuleV2/SysWorkplacePageV2/edit/" + info.workplaceId
					});
				}
			},

			/**
			 * @override
			 * @protected
			 */
			getIsEditPageButtonVisible: function() {
				const isVisible = this.callParent(arguments);
				const isHomePage = this._getIsHomePage();
				return isHomePage || isVisible;
			},

			/**
			 * @private
			 */
			_getIsHomePage: function() {
				const hash = Terrasoft.router.Router.getHash();
				const pages = hash.split("/");
				let isHomePage = false;
				if (Terrasoft.Features.getIsDisabled("DisableHomePageInWorkplace")) {
					isHomePage = pages.length > 1 &&
							(pages[0] === "HomePage" || (pages[0] === "IntroPage" && pages[1] !== "SystemDesigner"));
				}
				return isHomePage;
			}
		},
	};
});

define('MainHeaderSchemaCTIBaseResources', ['terrasoft'], function(Terrasoft) {
var localizableStrings={

};
var parametersLocalizableStrings={};
var localizableImages={

};
return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});
define("MainHeaderSchemaCTIBase", ["CtiConstants", "CtiAgentStateMixin"],
		function(CtiConstants) {
			return {
				mixins: {
					CtiAgentStateMixin: Terrasoft.CtiAgentStateMixin
				},
				attributes: {
					/**
					 * ####### ### ######### #########.
					 * @private
					 * @type {String}
					 */
					"AgentState": {
						dataValueType: this.Terrasoft.DataValueType.TEXT,
						value: ""
					},

					/**
					 * Current agent state display value.
					 * @private
					 * @type {String}
					 */
					"AgentStateDisplayValue": {
						dataValueType: this.Terrasoft.DataValueType.TEXT,
						value: ""
					},

					/**
					 * ######### ######### #########.
					 * @private
					 * @type {Terrasoft.Collection}
					 */
					"AgentStates": {
						dataValueType: this.Terrasoft.DataValueType.CUSTOM_OBJECT,
						value: null
					}
				},
				methods: {

					//region Methods: Protected

					/**
					 * @inheritdoc Terasoft.MainHeaderSchemaViewModel#init
					 * @overridden
					 */
					init: function() {
						this.callParent(arguments);
						var ctiModel = Terrasoft.CtiModel;
						if (ctiModel && ctiModel.get("IsConnected")) {
							this.onCtiPanelConnected();
						}
						this.sandbox.subscribe("AgentStateChanged", function(stateCode) {
							this.set("AgentState", stateCode);
						}, this);
						this.sandbox.subscribe("CtiPanelConnected", this.onCtiPanelConnected, this);
						this.on("change:AgentState", this.onAgentStateChanged, this);
					},

					/**
					 * ########## ############ ###### ######### ######### ### ###### #######.
					 * @protected
					 * @return {Object} ############ ###########.
					 */
					getOperatorStatusProfileIcon: function() {
						var stateCode = this.get("AgentState");
						return this.getProfileMenuStatusIcon(stateCode);
					},

					/**
					 * ############ ########## # cti #######.
					 * @protected
					 */
					onCtiPanelConnected: function() {
						this.loadAgentStatesMenu(function() {
							this.loadProfileButtonMenu();
							this.setSavedAgentState();
						});
					},

					/**
					 * Sets agent state from profile.
					 * @protected
					 */
					setSavedAgentState: function() {
						if (this.getIsFeatureDisabled("SetSavedAgentState")) {
							return;
						}
						var profile = this.getProfile() || {};
						var savedState = profile.agentState;
						if (!savedState) {
							return;
						}
						this.onOperatorStatusChange(savedState);
					},

					/**
					 * ########## ############ ########### ###### #### ######### #########.
					 * @obsolete
					 * @param {Object} image ######, # ####### ########### ########### ## #### ######.
					 * @param {String} image.value ############# ###########.
					 * @return {Object} ############ ###########.
					 */
					getAgentStateIconConfig: function(image) {
						var iconId = image && image.value;
						if (Ext.isEmpty(iconId) || this.Terrasoft.isEmptyGUID(iconId)) {
							iconId = CtiConstants.DefaultSysMsgUserStateIconId;
						}
						var iconConfig = {
							source: this.Terrasoft.ImageSources.ENTITY_COLUMN,
							params: {
								schemaName: "SysMsgUserStateIcon",
								columnName: "Image",
								primaryColumnValue: iconId
							}
						};
						return {
							source: Terrasoft.ImageSources.URL,
							url: Terrasoft.ImageUrlBuilder.getUrl(iconConfig)
						};
					},

					/**
					 * ######### ###### #### ######### ######### # #### ###### #######.
					 * @protected
					 * @param {Terrasoft.Collection} agentStates ######### ######### #########.
					 * @param {Function} callback ####### ######### ######.
					 */
					generateAgentStateMenuItems: function(agentStates, callback) {
						var profileMenuCollection = this.get("ProfileMenuCollection");
						profileMenuCollection.clear();
						profileMenuCollection.addItem(this.Ext.create("Terrasoft.BaseViewModel", {
							values: {
								Type: "Terrasoft.MenuSeparator",
								Caption: {
									bindTo: "Resources.Strings.TelephonyMenuSeparator"
								},
							}
						}));
						this.generateAgentStateMenuItemsInternal(agentStates, profileMenuCollection);
						profileMenuCollection.addItem(this.Ext.create("Terrasoft.BaseViewModel", {
							values: {
								Type: "Terrasoft.MenuSeparator",
								Caption: ""
							}
						}));
						callback.call(this);
					},

					/**
					 * Handler of the agent state attribute change event.
					 * @protected
					 * @param {Backbone.Model} model Model.
					 * @param {String} stateCode Agent state code.
					 */
					onAgentStateChanged: function(model, stateCode) {
						this.set("AgentStateDisplayValue", this.getAgentStateDisplayValue(stateCode));
						this.saveProfileData(stateCode);
					},

					/**
					 * Save agent state to profile.
					 * @protected
					 * @param {String} stateCode Agent state code.
					 */
					saveProfileData: function(stateCode) {
						if (this.getIsFeatureDisabled("SetSavedAgentState") || !stateCode
								|| stateCode === Terrasoft.FinesseAgentState.LOGOUT) {
							return;
						}
						var profileData = Ext.Object.merge(this.getProfile() || {}, {"agentState": stateCode});
						Terrasoft.utils.saveUserProfile(this.getProfileKey(), profileData, false, function() {
							this.set("Profile", profileData);
						}, this);
					},

					/**
					 * Returns schema profile key.
					 * @protected
					 */
					getProfileKey: function() {
						return "MainHeaderSchemaProfile";
					},

					/**
					 * Returns operator state display value.
					 * @protected
					 */
					getOperatorStateDisplayValue: function() {
						return this.get("AgentStateDisplayValue") || Ext.emptyString;
					}

					//endregion

				},
				diff: [
					{
						"operation": "insert",
						"name": "operatorStatusIcon",
						"parentName": "UserProfileContainer",
						"propertyName": "items",
						"values": {
							"id": "view-button-operatorStatusIcon",
							"itemType": Terrasoft.ViewItemType.BUTTON,
							"selectors": {
								wrapEl: "#view-button-operatorStatusIcon"
							},
							"classes": {
								"wrapperClass": ["operator-status-icon-wrapper"],
								"pressedClass": ["pressed-button-view"],
								"imageClass": ["operator-status-icon", "view-images-class"]
							},
							"hint": {"bindTo": "getOperatorStateDisplayValue"},
							"tips": [],
							"click": {"bindTo": "onViewButtonClick"},
							"imageConfig": {"bindTo": "getOperatorStatusProfileIcon"},
							"style": this.Terrasoft.controls.ButtonEnums.style.TRANSPARENT,
							"iconAlign": this.Terrasoft.controls.ButtonEnums.iconAlign.LEFT,
							"markerValue": {"bindTo": "AgentState"},
							"tag": "operatorStatusIcon"
						}
					}
				]
			};
		});

define('MainHeaderSchemaEmailMiningResources', ['terrasoft'], function(Terrasoft) {
var localizableStrings={

};
var parametersLocalizableStrings={};
var localizableImages={

};
return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});
define("MainHeaderSchemaEmailMining", ["ModalBox"],
	function(ModalBox) {
		return {
			messages: {
				/**
				 * Update contact enrichment page visibility.
				 */
				"ContactEnrichmentPageVisibilityChanged": {
					"mode": Terrasoft.MessageMode.PTP,
					"direction": Terrasoft.MessageDirectionType.SUBSCRIBE
				}

			},
			attributes: {

				/**
				 * Signs that contact enrichment page is visible.
				 * @type {Boolean}
				 */
				"ContactEnrichmentPageVisible": {
					"dataValueType": Terrasoft.DataValueType.BOOLEAN,
					"value": false
				},

				/**
				 * Enrich module container.
				 * @type {Boolean}
				 */
				"ContactEnrichmentModuleContainerId": {
					"dataValueType": Terrasoft.DataValueType.TEXT,
					"value": "ContactEnrichmentModuleContainer"
				},

				/**
				 * Shell enrich module container.
				 * @type {String}
				 */
				 "ShellContactEnrichmentModuleContainerId": {
					"dataValueType": Terrasoft.DataValueType.TEXT,
					"value": "ShellContainer"
				},

				/**
				 * Enrich modal identifier
				 * @type {String}
				 */
				 "ModalId": {
					"dataValueType": Terrasoft.DataValueType.TEXT,
					"value": ""
				},

			},
			methods: {

				//region Methods: Private

				/**
				 * Adapt modal window to shell container if it exists
				 * @private
				 */
					adaptToShellContainer: function() {
					var shellContainer = Ext.get(this.get("ShellContactEnrichmentModuleContainerId"));
					if(shellContainer){
						this.set("ContactEnrichmentModuleContainerId", this.get("ShellContactEnrichmentModuleContainerId"))
					}
				},
				
				//endregion

				//region Methods: Protected

				/**
				 * @inheritdoc Terrasoft.BaseSchemaViewModel#init
				 * @overridden
				 */
				init: function() {
					this.callParent(arguments);
					this.subscribeServerChannelEvents();
				},

				/**
				 * @inheritdoc Terrasoft.BaseSchemaViewModel#destroy
				 * @overridden
				 */
				destroy: function() {
					this.unsubscribeServerChannelEvents();
					this.callParent(arguments);
				},

				/**
				 * Removes viewmodel subscription to server messages.
				 * @protected
				 */
				unsubscribeServerChannelEvents: function() {
					this.Terrasoft.ServerChannel.un(this.Terrasoft.EventName.ON_MESSAGE,
						this.onServerChannelMessage, this);
				},

				/**
				 * Subscribes viewmodel to server messages.
				 * @protected
				 */
				subscribeServerChannelEvents: function() {
					this.Terrasoft.ServerChannel.on(this.Terrasoft.EventName.ON_MESSAGE,
						this.onServerChannelMessage, this);
				},

				/**
				 * Server message handler. Show enrichment error message to console, if occurred one.
				 * @protected
				 * @param {Object} scope Message scope.
				 * @param {Object} message Server messsage.
				 */
				onServerChannelMessage: function(scope, message) {
					if (message && message.Header && message.Header.Sender !== "EmailEnrichmentError") {
						return;
					}
					var receivedMessage = this.Ext.decode(message.Body);
					this.log(Ext.String.format("Global enrichment error: {0};",
							receivedMessage.errorText));
				},

				/**
				 * @inheritdoc Terrasoft.BaseSchemaViewModel#subscribeSandboxEvents
				 * @overridden
				 */
				subscribeSandboxEvents: function() {
					this.callParent(arguments);
					this.sandbox.subscribe("ContactEnrichmentPageVisibilityChanged",
						this.onContactEnrichmentPageVisibilityChanged.bind(this));
				},

				/**
				 * Handles changing contact enrichment page visibility.
				 * @protected
				 * @virtual
				 * @param {Object} tag Enrichment arguments.
				 * @param {Boolean} tag.isVisible Sign that contact enrichment page is visible or not.
				 * @param {String} tag.contactId Contact identifier.
				 * @param {String} tag.contactName Contact name.
				 * @param {String} tag.enrchTextDataId Enrichment text data identifier.
				 * @param {String} tag.source Source item for web analytics.
				 */
				onContactEnrichmentPageVisibilityChanged: function(tag) {
					this.adaptToShellContainer()
					var args = Ext.decode(tag);
					var showEnrichmentPage = args.isVisible;
					this.set("ContactEnrichmentPageVisible", showEnrichmentPage);
					if (!showEnrichmentPage) {
						this.sandbox.unloadModule(this.get("ModalId"));
						return;
					}
					var modalId = this.sandbox.loadModule("BaseSchemaModuleV2", {
						renderTo: this.get("ContactEnrichmentModuleContainerId"),
						instanceConfig: {
							parameters: {
								viewModelConfig: {
									ContactId: args.contactId,
									ContactName: args.contactName,
									EnrchTextDataId: args.enrchTextDataId,
									EnrchEmailDataId: args.enrchEmailDataId,
									CallerSource: args.source
								}
							},
							schemaName: "ContactEnrichmentSchema",
							isSchemaConfigInitialized: true,
							useHistoryState: false
						}
					});
					this.set("ModalId", modalId);
				},

				//endregion

			},
			diff: [
				{
					"operation": "insert",
					"name": "ContactEnrichmentModuleContainer",
					"parentName": "communicationPanelContent",
					"propertyName": "items",
					"values": {
						"id": "ContactEnrichmentModuleContainer",
						"itemType": Terrasoft.ViewItemType.CONTAINER,
						"visible": {
							"bindTo": "ContactEnrichmentPageVisible"
						},
						"items": []
					}
				}
			]
		};
	});

define('MainHeaderSchemaSSPResources', ['terrasoft'], function(Terrasoft) {
var localizableStrings={

};
var parametersLocalizableStrings={};
var localizableImages={

};
return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});
define("MainHeaderSchemaSSP", ["PortalClientConstants"], function(PortalConstants) {
	return {
		attributes: {
			/**
			 * Binding attribute for "Company profile" menu item visibility.
			 */
			"canGoToSspAccountPage": {
				"dataValueType": this.Terrasoft.DataValueType.BOOLEAN,
				"value": false
			},

			"OrganizationId": {
				"dataValueType": this.Terrasoft.DataValueType.GUID,
				"type": this.Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN
			}
		},

		methods: {
			/**
			 * @inheritDoc Terrasoft.BaseViewModel#init
			 * @override
			 */
			init: function() {
				this.initAttributes();
				this.callParent(arguments);
			},

			/**
			 * Initialize schema attributes.
			 */
			initAttributes: function() {
				if (this.getIsFeatureEnabled("PortalUserManagementV2")) {
					this.initCanGoToSspAccountPage();
				}
			},

			/**
			 * Set up canGoToSspAccountPage attribute.
			 */
			initCanGoToSspAccountPage: function() {
				if (!Terrasoft.isCurrentUserSsp() || !Terrasoft.SysValue.CURRENT_USER_ACCOUNT.value) {
					this.set("canGoToSspAccountPage", false);
					return;
				}
				const serviceConfig = {serviceName: "SspUserManagementService", methodName: "GetSspAccountInfo"};
				this.callService(serviceConfig, this.switchCanGoToSspAccountPage, this);
			},

			/**
			 * @inheritdoc Terrasoft.MainHeaderSchema#loadProfileButtonMenu
			 * @override
			 */
			loadProfileButtonMenu: function() {
				this.callParent(arguments);
				if (Terrasoft.isCurrentUserSsp() && this.getIsFeatureEnabled("SSPUserContactPage")) {
					this.addExtendedUserProfileButtonMenu();
					this.changeProfileIcon();
				}
				if (this.getIsFeatureEnabled("PortalUserManagementV2") && Terrasoft.isCurrentUserSsp()) {
					this.addSspAccountButtonsToProfileButtonMenu();
				}
				if (Terrasoft.isCurrentUserSsp()) {
					this.changeExitIcon();
				}
			},

			/**
			 * Change User profile button icon to portal user profile icon.
			 * @protected
			 */
			changeProfileIcon: function() {
				const profileMenuCollection = this.get("ProfileMenuCollection");
				const userProfile = profileMenuCollection.findByFn(function(item) {
					return item.$Id === "profile-menu-item";
				});
				if (userProfile) {
					profileMenuCollection.remove(userProfile);
					profileMenuCollection.addItem(this.Ext.create("Terrasoft.BaseViewModel", {
						values: {
							Id: "profile-menu-item",
							Caption: this.get("Resources.Strings.SspProfileCaption"),
							Click: {
								bindTo: "onProfileMenuItemClick"
							},
							ImageConfig: this.get("Resources.Images.SspProfileIcon"),
							MarkerValue: this.get("Resources.Strings.SspProfileCaption")
						}
					}), 0);
				}
			},

			/**
			 * Change Exit button icon to portal exit icon.
			 * @protected
			 */
			changeExitIcon: function() {
				const profileMenuCollection = this.get("ProfileMenuCollection");
				const exit = profileMenuCollection.findByFn(function(item) {
					return item.$Id === "exit-menu-item";
				});
				if (exit) {
					profileMenuCollection.remove(exit);
					profileMenuCollection.addItem(this.Ext.create("Terrasoft.BaseViewModel", {
						values: {
							Id: "exit-menu-item",
							Caption: this.get("Resources.Strings.ExitMenuItemCaption"),
							Click: {
								bindTo: "onExitMenuItemClick"
							},
							ImageConfig: this.get("Resources.Images.SspExitButton"),
							MarkerValue: this.get("Resources.Strings.ExitMenuItemCaption")
						}
					}));
				}
			},

			/**
			 * Add menu item for open SSP account page to profile menu button.
			 * @protected
			 */
			addSspAccountButtonsToProfileButtonMenu: function() {
				const profileMenuCollection = this.get("ProfileMenuCollection");
				profileMenuCollection.addItem(this.Ext.create("Terrasoft.BaseViewModel", {
					values: {
						Id: "company-profile-menu-item",
						Caption: this.get("Resources.Strings.CompanyProfileCaption"),
						Click: {
							bindTo: "onGoToSspAccountPageMenuItemClick"
						},
						ImageConfig: this.get("Resources.Images.CompanyProfileIcon"),
						Visible: {
							bindTo: "canGoToSspAccountPage"
						},
						MarkerValue: this.get("Resources.Strings.CompanyProfileCaption")
					}
				}), 1);
			},

			/**
			 * Forward user to SSP account profile.
			 * @protected
			 */
			onGoToSspAccountPageMenuItemClick: function() {
				const path = this.Terrasoft.combinePath("CardModuleV2",
					PortalConstants.DesignerPagesName.OrganizationPageSchema,
					"edit", this.get("OrganizationId"));
				const historyStateConfig = {hash: path};
				this.sandbox.publish("PushHistoryState", historyStateConfig);
			},

			/**
			 * Switch visibility of "Company profile" menu item based on service response.
			 * @protected
			 * @param {Object} response SspUserManagementService/GetSspAccountInfo service response.
			 */
			switchCanGoToSspAccountPage: function(response) {
				const result = response && response.GetSspAccountInfoResult;
				if (result && result.success && result.SspAccountId && !Terrasoft.isEmptyGUID(result.SspAccountId)) {
					this.set("canGoToSspAccountPage", true);
					this.set("OrganizationId", result.SspAccountId);
				}
			},

			/**
			 * Add menu item for open SSP account page to profile menu button.
			 * @protected
			 */
			addExtendedUserProfileButtonMenu: function() {
				const profileMenuCollection = this.get("ProfileMenuCollection");
				const pmi = profileMenuCollection.filter(function(item) {
					return item.$Id === "profile-menu-item";
				});
				if (pmi && pmi.getCount() > 0) {
					profileMenuCollection.addItem(this.Ext.create("Terrasoft.BaseViewModel", {
						values: {
							Id: "extended-user-profile-menu-item",
							Caption: this.get("Resources.Strings.ExtendedUserProfileCaption"),
							ImageConfig: this.get("Resources.Images.UserSettingsIcon"),
							Click: {
								bindTo: "openSettingsProfile"
							}
						}
					}), 1);
				}
			},

			/**
			 * Forward user to SSP account profile.
			 * @protected
			 */
			openSettingsProfile: function() {
				this.onProfileMenuItemClick(true);
			},

			/**
			 * Open page which is related with user contact.
			 * @protected
			 */
			openUserProfilePage: function() {
				const path = this.Terrasoft.combinePath("CardModuleV2",
					PortalConstants.DesignerPagesName.ProfileContactPageSchema, "edit",
					Terrasoft.SysValue.CURRENT_USER_CONTACT.value);
				const historyStateConfig = {hash: path};
				this.sandbox.publish("PushHistoryState", historyStateConfig);
			},

			/**
			 * @inheritdoc Terrasoft.MainHeaderSchema#onProfileMenuItemClick.
			 * @override
			 */
			onProfileMenuItemClick: function(callParent) {
				if (this.getIsFeatureEnabled("SSPUserContactPage") && this.Terrasoft.isCurrentUserSsp() &&
					!callParent) {
					this.openUserProfilePage();
				} else {
					this.callParent(arguments);
				}
			}
		}
	};
});

define("MainHeaderSchema", ["RightUtilities"], function (RightUtilities) {
	return {
		properties: {
			omnichannelOperatorServiceName: "OmnichannelOperatorService",
			operatorStateSchemaName: "OperatorState"
		},
		attributes: {
			/**
			 * The current operator state code.
			 * @private
			 * @type {String}
			 */
			"OperatorState": {
				dataValueType: this.Terrasoft.DataValueType.TEXT,
				value: Terrasoft.emptyString
			},

			/**
			 * A collection of operator states.
			 * @private
			 * @type {Terrasoft.Collection}
			 */
			"OperatorStates": {
				dataValueType: this.Terrasoft.DataValueType.CUSTOM_OBJECT,
				value: null
			},

			/**
			 * User has omnichannel license operation.
			 * @type {Boolean}
			 */
			"HasOmnichannelLicOperation": {
				"dataValueType": Terrasoft.DataValueType.BOOLEAN,
				"type": Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"value": false
			},

			/**
			 * Current user has omnichannel rights.
			 * @private
			 * @type {Boolean}
			 */
			"HasOmnichannelRights": {
				dataValueType: this.Terrasoft.DataValueType.BOOLEAN,
				value: null
			}
		},
		messages: {},
		mixins: {},
		methods: {

			//region Methods: Private

			/**
			 * Returns operator state info.
			 * @private
			 * @param {String} stateCode Operator status code.
			 * @return {Object} Operator info result.
			 */
			_getOperatorStateInfo: function (stateCode) {
				const operatorStates = this.get("OperatorStates");
				return operatorStates && operatorStates.find(stateCode);
			},

			/**
			 * Updates operator status on server message.
			 * @private
			 * @param {Object} scope message scope.
			 * @param {Object} message Server channel message.
			 */
			_onOperatorStatusChanged: function(scope, message) {
				if (message.Header.Sender === "OperatorStateChanged") {
					const body = this.Ext.decode(message.Body);
					this.set("OperatorState", body.StateCode);
				}
			},

			/**
			 * Check license operation for using chats.
			 */
			_checkOmnichannelLicOperation: function(callback, scope) {
				scope.callService({
					serviceName: "CtiRightsService",
					methodName: "GetUserHasOperationLicense",
					data: {
						operations: ['Chats.Use'],
						isAnyOperation: false
					}
				}, function(result) {
					this.$HasOmnichannelLicOperation = result.GetUserHasOperationLicenseResult;
					this.Ext.callback(callback, scope);
				}, this);
			},

			_hasOmnichannelRights: function(callback, scope) {
				RightUtilities.getSchemaEditRights({schemaName: "OmniChat"}, function(result) {
					this.$HasOmnichannelRights = this.Ext.isEmpty(result);
					Ext.callback(callback, scope);
				}, this);
			},

			//endregion

			//region Methods: Protected

			/**
			 * @inheritdoc Terrasoft.MainHeaderSchema#loadProfileButtonMenu
			 * @override
			 */
			loadProfileButtonMenu: function () {
				const parentMethod = this.getParentMethod();
				if (this.getIsFeatureEnabled("ShowOmniChatInCommPanel")) {
					Terrasoft.chain(
						function (next) {
							this.getCurrentUserOperatorInfo(next, this);
						},
						function (next) {
							this._hasOmnichannelRights(next, this);
						},
						function (next) {
							if (this.$HasOmnichannelRights &&
								this.isNotEmpty(this.get("OperatorState"))) {
								this.addOperatorStatesToProfileButtonMenu(next, this);
							} else {
								next();
							}
						},
						function () {
							parentMethod.call(this);
						}, this);
				} else {
					parentMethod.call(this);
				}
			},

			/**
			 * Forms a collection of operator states from the result of a selection request to the database.
			 * @protected
			 * @param {Object} operatorStatesQueryResult Result of a database query for a selection of operator states.
			 * @returns {Terrasoft.Collection} A collection of operator states.
			 */
			getOperatorStates: function (operatorStatesQueryResult) {
				const operatorStates = new Terrasoft.Collection();
				operatorStatesQueryResult.collection.each(function (item) {
					const valueCode = item.get("Code");
					let operatorState = operatorStates.find(valueCode);
					if (!operatorState) {
						operatorState = {
							value: item.get("Id"),
							displayValue: item.get("Name"),
							code: valueCode,
							operatorAvailable: item.get("OperatorAvailable"),
							iconConfig: this.getIconConfig(item.get("Id"),
								this.operatorStateSchemaName, "Image"),
						};
						operatorStates.add(valueCode, operatorState);
					}
				}, this);
				return operatorStates;
			},

			/**
			 * Sets the state of the operator.
			 * @protected
			 * @param {String} tag Element tag.
			 */
			onChatOperatorStateChange: function (tag) {
				if (this.isEmpty(tag) || tag === this.get("OperatorState")) {
					return;
				}
				this.changeOperatorState(tag, this.handleOperatorStateChange);
			},

			/**
			 * Getting the current state of the operator.
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Execution context.
			 * @protected
			 */
			getCurrentUserOperatorInfo: function (callback, scope) {
				const config = {
					serviceName: this.omnichannelOperatorServiceName,
					methodName: "GetCurrentState"
				};
				this.callService(config, function (response) {
					if (response) {
						if (response.success) {
							this.set("OperatorState", response.CurrentStateCode);
						} else if (response.errorInfo) {
							this.error(response.errorInfo.message);
						}
					}
					Ext.callback(callback, scope);
				}, this);
			},

			/**
			 * #all the service of changing the operator state.
			 * @param {String} newState New state for operator.
			 * @param {Function} callback Callback function.
			 * @protected
			 */
			changeOperatorState: function (newState, callback) {
				const config = {
					serviceName: this.omnichannelOperatorServiceName,
					methodName: "ChangeState",
					data: {
						newState: newState
					}
				};
				this.callService(config, callback, this);
			},

			/**
			 * Handles after change operator state.
			 * @param {Object} response Response from server.
			 * @protected
			 */
			handleOperatorStateChange: function (response) {
				if (response) {
					if (response.success) {
						this.set("OperatorState", response.CurrentStateCode);
					} else if (response.errorInfo) {
						this.error(response.errorInfo.message);
					}
				}
			},

			/**
			 * Add omnichannel operator statuses.
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Execution context.
			 */
			addOperatorStatesToProfileButtonMenu: function (callback, scope) {
				this.executeOperatorStateQuery(function (result) {
					const operatorStates = this.getOperatorStates(result);
					this.set("OperatorStates", operatorStates);
					this.generateOperatorStateMenuItems(operatorStates);
					Ext.callback(callback, scope);
				});
			},

			/**
			 * Request to read operator statuses
			 * @param {Function} Callback function.
			 * @protected
			 */
			executeOperatorStateQuery: function (callback) {
				const operatorStateEsq = this.getOperatorStateEsq();
				operatorStateEsq.getEntityCollection(callback, this);
			},

			/**
			 * Creates a query to select an operator state.
			 * @protected
			 * @returns {Terrasoft.EntitySchemaQuery} Operator state select query.
			 */
			getOperatorStateEsq: function () {
				const cacheKey = "OperatorState_ProfileMenuStatuses";
				const esq = Ext.create("Terrasoft.EntitySchemaQuery", {
					rootSchemaName: this.operatorStateSchemaName,
					clientESQCacheParameters: {
						cacheItemName: cacheKey
					},
					serverESQCacheParameters: {
						cacheLevel: Terrasoft.ESQServerCacheLevels.SESSION,
						cacheGroup: this.operatorStateSchemaName,
						cacheItemName: cacheKey
					}
				});
				esq.addMacrosColumn(Terrasoft.QueryMacrosType.PRIMARY_COLUMN, "Id");
				esq.addMacrosColumn(Terrasoft.QueryMacrosType.PRIMARY_DISPLAY_COLUMN, "Name");
				esq.addColumn("Code");
				esq.addColumn("Image");
				esq.addColumn("OperatorAvailable");
				return esq;
			},

			/**
			 * @inheritdoc Terrasoft.MainHeaderSchema#getOperatorStatusProfileIcon
			 * @override
			 */
			getOperatorStatusProfileIcon: function () {
				const currentOperatorStateInfo = this._getOperatorStateInfo(this.get("OperatorState"));
				const baseProfileIcon = this.callParent(arguments);
				if (this.isEmpty(currentOperatorStateInfo)) {
					return baseProfileIcon;
				}
				const resultProfileIcon = currentOperatorStateInfo.operatorAvailable && this.isNotEmpty(baseProfileIcon)
					? baseProfileIcon
					: currentOperatorStateInfo.iconConfig;
				return resultProfileIcon;
			},

			/**
			 * Forms menu items of operator states in the profile button menu.
			 * @protected
			 * @param {Terrasoft.Collection} operatorStates Operator state collection.
			 */
			generateOperatorStateMenuItems: function (operatorStates) {
				const profileMenuCollection = this.get("ProfileMenuCollection");
				profileMenuCollection.addItem(this.Ext.create("Terrasoft.BaseViewModel", {
					values: {
						Type: "Terrasoft.MenuSeparator",
						Caption: {
							bindTo: "Resources.Strings.ChatMenuSeparator"
						},
					}
				}));
				operatorStates.each(function (item) {
					const menuItem = this.Ext.create("Terrasoft.BaseViewModel", {
						values: {
							Caption: item.displayValue,
							MarkerValue: item.displayValue,
							Tag: item.code,
							ImageConfig: item.iconConfig,
							Click: { bindTo: "onChatOperatorStateChange" }
						}
					});
					profileMenuCollection.addItem(menuItem);
				}, this);
				profileMenuCollection.addItem(this.Ext.create("Terrasoft.BaseViewModel", {
					values: {
						Type: "Terrasoft.MenuSeparator",
						Caption: Terrasoft.emptyString
					}
				}));
			},

			/**
			 * Returns operator state display value.
			 * @override
			 */
			getOperatorStateDisplayValue: Terrasoft.emptyFn,

			/**
			 * @inheritdoc Terrasoft.MainHeaderSchema#init
			 * @override
			 */
			init: function(callback, scope) {
				this.callParent([function() {
					this.Terrasoft.ServerChannel.on(Terrasoft.EventName.ON_MESSAGE, this._onOperatorStatusChanged, this);
					this.Ext.callback(callback, scope || this);
				}, this]);
			}

			//endregion

		},
		diff: []
	};
});


