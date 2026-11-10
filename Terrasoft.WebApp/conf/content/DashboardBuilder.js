Terrasoft.configuration.Structures["DashboardBuilder"] = {innerHierarchyStack: ["DashboardBuilder"]};
define("DashboardBuilder", ["ext-base", "DashboardBuilderResources", "RightUtilities", "MaskHelper", "DashboardManager",
	"DashboardManagerItem", "jQuery", "ContextHelpMixin", "css!DashboardBuilder", "FilterableList",
	"FavoriteTabsDecorator"],
		function(Ext, resources, RightUtilities, MaskHelper) {

	/**
	 * @class Terrasoft.configuration.DashboardViewsConfig
	 * Class that generates dashboards view config.
	 */
	Ext.define("Terrasoft.configuration.DashboardsViewConfig", {
		extend: "Terrasoft.BaseObject",
		alternateClassName: "Terrasoft.DashboardsViewConfig",

		/**
		 * Generates view config.
		 * @return {Object[]} View config.
		 */
		generate: function() {
			const dashboardClasses = ["dashboard-el", "dashboard-listed-grid-module", "dashboard-loading-mask"];
			return [{
				name: "Tabs",
				itemType: Terrasoft.ViewItemType.TAB_PANEL,
				activeTabChange: {bindTo: "onActiveTabChange"},
				activeTabName: {bindTo: "ActiveTabName"},
				classes: {wrapClass: ["tab-panel-margin-bottom", "dashboard-el"]},
				collection: {bindTo: "TabsCollection"},
				markerValue: "mainDashboardPage",
				defaultMarkerValueColumnName: "Caption",
				controlConfig: {
					items: [
						{
							className: "Terrasoft.Button",
							style: Terrasoft.controls.ButtonEnums.style.TRANSPARENT,
							imageConfig: {bindTo: "Resources.Images.SearchDashboard"},
							markerValue: "SearchDashboardButton",
							classes: { wrapperClass: "search-dashboard-button"},
							hint: {bindTo: "Resources.Strings.SearchDashboardButtonHint"},
							tips:[{
								tip: {
									"style": Terrasoft.TipStyle.WHITE,
									"hideOnScroll": false,
									"displayMode": Terrasoft.TipDisplayMode.NARROW,
									"markerValue": "dashboards-filterable-list",
									"items": [{
										"className": "Terrasoft.FilterableList",
										"items": {bindTo: "TabsFilterableCollection"},
										"itemSelected": {bindTo: "onTabListItemClick"},
										"favoriteStateChanged": {bindTo: "onFavoriteStateChanged"}
									}],
									"tools": []
								},
								settings: {
									displayEvent: Terrasoft.TipDisplayEvent.CLICK
								}
							}]
						},
						{
						className: "Terrasoft.Button",
						style: Terrasoft.controls.ButtonEnums.style.TRANSPARENT,
						imageConfig: {bindTo: "Resources.Images.Settings"},
						markerValue: "SettingsButton",
						hint: {bindTo: "Resources.Strings.SettingsButtonHint"},
						menu: {
							items: [{
								caption: {bindTo: "Resources.Strings.AddButtonCaption"},
								click: {bindTo: "addDashboard"},
								markerValue: "SettingsButtonAdd",
								enabled: {
									bindTo: "SysDashboardRightLevel",
									bindConfig: {converter: "canAppendSchemaData"}
								}
							}, {
								caption: {bindTo: "Resources.Strings.EditButtonCaption"},
								click: {bindTo: "editCurrentDashboard"},
								markerValue: "SettingsButtonEdit",
								enabled: {bindTo: "canEdit"}
							}, {
								caption: {bindTo: "Resources.Strings.CopyButtonCaption"},
								click: {bindTo: "copyCurrentDashboard"},
								markerValue: "SettingsButtonCopy",
								enabled: {bindTo: "canCopy"}
							}, {
								caption: {bindTo: "Resources.Strings.DeleteButtonCaption"},
								click: {bindTo: "deleteCurrentDashboard"},
								markerValue: "SettingsButtonDelete",
								enabled: {bindTo: "canDelete"}
							}, {
								caption: "",
								className: "Terrasoft.MenuSeparator",
								visible: !(Ext.isIE || Ext.isSafari)
							}, {
								caption: {bindTo: "Resources.Strings.ScreenshotButtonCaption"},
								click: {bindTo: "onScreenshotButtonClick"},
								markerValue: "SettingsButtonScreenshot",
								visible: !(Ext.isIE || Ext.isSafari),
								enabled: {bindTo: "getScreenshotButtonEnabled"}
							}, {
								caption: "",
								className: "Terrasoft.MenuSeparator"
							}, {
								caption: {bindTo: "Resources.Strings.RightsButtonCaption"},
								click: {bindTo: "manageCurrentDashboardRights"},
								markerValue: "ManageRights",
								enabled: {bindTo: "canManageRights"}
							}]
						}
					}],
					imageTabClass: "is-favorite"
				}
			}, {
				name: "NoDashboardLabel",
				itemType: Terrasoft.ViewItemType.LABEL,
				caption: {bindTo: "Resources.Strings.NoDashboardsAvailable"},
				labelConfig: {
					classes: ["dashboard-message-empty"],
					visible: {
						bindTo: "isTabsEmpty"
					}
				}
			}, {
				name: "DashboardModule",
				itemType: Terrasoft.ViewItemType.CONTAINER,
				classes: {wrapClassName: dashboardClasses}
			}];
		}
	});

	/**
	 * @class Terrasoft.configuration.BaseDashboardsViewModel
	 * Dashboards base view model class.
	 */
	Ext.define("Terrasoft.configuration.BaseDashboardsViewModel", {
		extend: "Terrasoft.BaseModel",
		alternateClassName: "Terrasoft.BaseDashboardsViewModel",
		mixins: {
			rightsUtilities: "Terrasoft.RightUtilitiesMixin",
			ContextHelpMixin: "Terrasoft.ContextHelpMixin"
		},

		Ext: null,
		sandbox: null,
		Terrasoft: null,
		
		/**
		 * @private
		 */
		_initialHistoryStateHash: null,

		constructor: function() {
			this.callParent(arguments);
			this.initResourcesValues(resources);
		},

		/**
		 * Initializes view model resources.
		 * @protected
		 * @param {Object} resourcesObj Resource object.
		 */
		initResourcesValues: function(resourcesObj) {
			const resourcesSuffix = "Resources";
			Terrasoft.each(resourcesObj, function(resourceGroup, resourceGroupName) {
				resourceGroupName = resourceGroupName.replace("localizable", "");
				Terrasoft.each(resourceGroup, function(resourceValue, resourceName) {
					const viewModelResourceName = [resourcesSuffix, resourceGroupName, resourceName].join(".");
					this.set(viewModelResourceName, resourceValue);
				}, this);
			}, this);
		},

		/**
		 * Initializes active tab.
		 * @protected
		 */
		initActiveTab: function() {
			const defaultTabName = this.getDefaultTabName();
			const activeTabName = this.get("ActiveTabName");
			const tabsCollection = this.get("TabsCollection");
			if (!activeTabName || tabsCollection.isEmpty()) {
				this.setActiveTab(defaultTabName);
			}
			const tab = tabsCollection.find(activeTabName);
			const dashboardItem = Terrasoft.DashboardManager.findItem(activeTabName);
			if (tab && dashboardItem) {
				this.setActiveTab(activeTabName);
			} else {
				this.setActiveTab(defaultTabName);
			}
		},

		/**
		 * Initializes tabs values.
		 * @protected
		 */
		initTabs: function() {
			this.initData();
			const defaultTabName = this.getDefaultTabName();
			if (!defaultTabName) {
				this.setActiveTab(defaultTabName);
				this.reloadRecordRights();
				const dashboardModuleId = this.getDashboardModuleId();
				this.sandbox.unloadModule(dashboardModuleId);
				return;
			}
			this.initActiveTab();
			this.reloadRecordRights();
		},

		/**
		 * Returns default tab name.
		 * @protected
		 * @return {String} Default tab name.
		 */
		getDefaultTabName: function() {
			const tabsCollection = this.get("TabsCollection");
			if (tabsCollection.isEmpty()) {
				return "";
			}
			const defaultTab = tabsCollection.getByIndex(0);
			return defaultTab.get("Name");
		},

		/**
		 * Sets active tab name.
		 * @protected
		 * @param {String} tabName Tab name.
		 */
		setActiveTab: function(tabName) {
			this.set("ActiveTabName", tabName);
		},

		/**
		 * Removes tab from a collection by a specified tab name.
		 * @protected
		 * @param {String} tabName The name of tab to remove.
		 */
		removeTabFromCollection: function(tabName) {
			const tabsCollection = this.get("TabsCollection");
			tabsCollection.removeByKey(tabName);
		},

		/**
		 * Removes filterable tab from a collection by a specified tab name.
		 * @protected
		 * @param {String} tabName The name of tab to remove.
		 */
		removeTabFromFilterableCollection: function(tabName) {
			const tabsFilterableCollection = this.get("TabsFilterableCollection");
			const removedTabIndex = tabsFilterableCollection.findIndex(function(tab) {
				return tab.id === tabName;
			});
			tabsFilterableCollection.splice(removedTabIndex, 1);
		},

		/**
		 * @param {String} tabName
		 * @private
		 */
		_removeTabFromDashboardsCollection: function(tabName) {
			const collection = this.get("Dashboards");
			collection.removeByKey(tabName);
		},

		/**
		 * Active tab change handler.
		 * @param {Terrasoft.BaseViewModel} activeTab Tab.
		 */
		onActiveTabChange: function(activeTab) {
			const currentDashboardName = activeTab.get("Name");
			this.setActiveTab(currentDashboardName);
			this._updateFavoriteTabsState();
			this.initTabsFilterableCollection();
			this.reloadRecordRights();
			this.loadDashboardModule();
		},

		/**
		 * Handles an event of selecting a tab in the list.
		 * @param {Function} tabListItem The item of selected tab from the list.
		 */
		onTabListItemClick: function(tabListItem) {
			const tabId = tabListItem && tabListItem.id;
			if (tabId) {
				this.setActiveTab(tabId);
			}
		},

		/**
		 * Handle favorite tab changed.
		 * @param {{id: string, isFavorite: Boolean}} favoriteTabChanged
		 */
		onFavoriteStateChanged: function(favoriteTabChanged) {
			const tab = favoriteTabChanged || {};
			const tabId = tab.id;
			if (!tabId) {
				return;
			}
			this._updateFavoriteTabsState(favoriteTabChanged);
			this.initData();
		},

		/**
		 * @private
		 * @param {{id: String, isFavorite: Boolean}} [tabChanged]
		 */
		_updateFavoriteTabsState: function(tabChanged) {
			const favoriteTabsDecorator = this.get("FavoriteTabsDecorator");
			const activeTabName = this.get("ActiveTabName");
			const profileState = {activeTabName: activeTabName};
			favoriteTabsDecorator.updateTabsState(profileState, this.getDashboards(), tabChanged);
		},

		/**
		 * Returns profile key.
		 * @protected
		 * @return {String} Profile key.
		 */
		getProfileKey: function() {
			return this.$ProfileKey;
		},

		/**
		 * Updates active tab rights.
		 */
		reloadRecordRights: function() {
			const currentDashboardName = this.get("ActiveTabName");
			this.set("CurrentRecordRightLevel", 0);
			if (currentDashboardName) {
				RightUtilities.getSchemaRecordRightLevel("SysDashboard", currentDashboardName, function(rightLevel) {
					this.set("CurrentRecordRightLevel", rightLevel);
				}, this);
			}
		},

		/**
		 * Removes tab.
		 * @param {String} tabName Tab name.
		 */
		removeTab: function(tabName) {
			this.removeTabFromCollection(tabName);
			this.removeTabFromFilterableCollection(tabName);
			this._removeTabFromDashboardsCollection(tabName);
		},

		/**
		 * Initializes page header.
		 */
		initHeader: function() {
			const pageCaption = this.get("Resources.Strings.Caption");
			this.sandbox.publish("InitDataViews", {caption: pageCaption});
			this.initContextHelp();
		},

		/**
		 * @inheritDoc Terrasoft.ContextHelpMixin#getContextHelpId
		 * @override
		 */
		getContextHelpId: function() {
			return "1013";
		},

		/**
		 * Loads dashboard module.
		 * @protected
		 */
		loadDashboardModule: function() {
			const dashboardModuleId = this.getDashboardModuleId();
			if (!this.sandbox.publish("ReloadDashboard", null, [dashboardModuleId])) {
				this.sandbox.loadModule("DashboardModule", {
					renderTo: "DashboardModuleContainer",
					id: dashboardModuleId
				});
			}
		},

		/**
		 * Generates dashboard module id.
		 * @protected
		 * @return {String} Generated id.
		 */
		getDashboardModuleId: function() {
			return this.sandbox.id + "DashboardModule";
		},

		/**
		 * Initializes view model data.
		 * @protected
		 */
		initData: function() {
			this.initTabsCollection();
			this.initTabsFilterableCollection();
		},

		/**
		 * Gets displayed dashboard tabs.
		 * @protected
		 * @return {Array<{Id: String, Caption: String, IsFavorite: Boolean, IsActive: Boolean, SortPosition: Number}>}
		 */
		getFavoriteDashboardTabs: function() {
			const dashboards = this.getDashboards();
			const favoriteTabsDecorator = this.get("FavoriteTabsDecorator");
			const tabs = favoriteTabsDecorator.getTabs(dashboards);
			this._markActiveTab(tabs);
			return tabs;
		},

		/**
		 * @param {Array<Object>} tabs
		 * @private
		 */
		_markActiveTab: function(tabs) {
			if (Terrasoft.isEmpty(tabs)) {
				return;
			}
			const activeTab = this.get("ActiveTabName");
			tabs.forEach(function(tab) {
				if (tab.Id === activeTab) {
					tab.IsActive = true;
				}
			});
			const hasActive = Terrasoft.findWhere(tabs, {IsActive: true});
			if (!hasActive) {
				tabs[0].IsActive = true;
			}
		},

		/**
		 * Initializes view model tabs collection by a specified tabs.
		 * @protected
		 */
		initTabsCollection: function() {
			const favoriteTabs = this.getFavoriteDashboardTabs();
			const sortedFavoriteTabs = _.sortBy(favoriteTabs, "SortPosition");
			const tabsCollection = this.get("TabsCollection");
			const tabs = sortedFavoriteTabs.map(function(tab) {
				const isFavorite = Boolean(tab.IsFavorite);
				return {
					Name: tab.Id,
					Caption: tab.Caption,
					ImageSrc: isFavorite
						? Terrasoft.ImageUrlBuilder.getUrl(resources.localizableImages.Favorite)
						: null
				};
			});
			tabsCollection.loadFromColumnValues(tabs);
		},

		/**
		 * Initializes view model tabs filterable collection by a specified tabs.
		 * @protected
		 */
		initTabsFilterableCollection: function() {
			const favoriteTabs = this.getFavoriteDashboardTabs();
			const tabs = favoriteTabs.map(function(tab) {
				return {
					id: tab.Id,
					caption: tab.Caption,
					isFavorite: Boolean(tab.IsFavorite),
					isActive:  Boolean(tab.IsActive)
				};
			});
			this.set("TabsFilterableCollection", tabs);
		},

		/**
		 * Subscribes on dashboard designer messages.
		 * @protected
		 */
		subscribeDesignerMessage: function() {
			const designerModuleId = this.getDesignerModuleId();
			const addDesignerModuleId = this.getAddDesignerModuleId();
			const copyDesignerModuleId = this.getCopyDesignerModuleId();
			const dashboardModuleId = this.getDashboardModuleId();
			this.sandbox.subscribe("GetDashboardInfo", this.onGetDashboardInfo, this,
				[designerModuleId, dashboardModuleId]);
			this.sandbox.subscribe("GetDashboardInfo", this.onGetDashboardAddInfo, this,
				[addDesignerModuleId]);
			this.sandbox.subscribe("GetDashboardInfo", this.onGetDashboardCopyInfo, this,
				[copyDesignerModuleId]);
			this.sandbox.subscribe("SetDesignerResult", this.onSetDesignerResult, this,
				[designerModuleId, addDesignerModuleId, copyDesignerModuleId]);
			this.sandbox.subscribe("HistoryStateChanged", this.onHistoryStateChanged, this);
			this.sandbox.subscribe("ReloadDataOnRestore", function() {
				this.set("ReloadNestedModules", true);
			}, this);
		},

		/**
		 * Processes state changes. Unload dashboards if hash changed.
		 * @protected
		 * @param {Object} state Browser new state object.
		 */
		onHistoryStateChanged: function(state) {
			const oldHash = this._initialHistoryStateHash;
			const newHash = state.hash && state.hash.historyState;
			const isHashChanged = this._isHashChanged(oldHash, newHash);
			if (isHashChanged) {
				this.unloadNestedModules();
			}
		},

		/**
		 * @private
		 */
		_isHashChanged: function(oldHash, newHash) {
			return this._trimHash(oldHash) !== this._trimHash(newHash);
		},

		/**
		 * @private
		 */
		_trimHash: function(hash) {
			return hash && hash.replace(/\/$/, "");
		},

		/**
		 * Saves current history state hash.
		 * @protected
		 */
		saveHistoryStateHash: function() {
			const currentHistoryState = this.sandbox.publish("GetHistoryState") || {};
			this._initialHistoryStateHash = currentHistoryState.hash && currentHistoryState.hash.historyState;
		},

		/**
		 * Return default tab sorting function.
		 * @param {Terrasoft.DashboardManagerItem} a Dashboard.
		 * @param {Terrasoft.DashboardManagerItem} b Dashboard.
		 * @return {Number} Result
		 */
		defaultDashboardsSortFn: function(a, b) {
			const valueA = a.getCaption();
			const valueB = b.getCaption();
			return valueA.localeCompare(valueB);
		},

		/**
		 * Handles dashboard designer result.
		 * @protected
		 * @param {Object} result Dashboard designer result object.
		 */
		onSetDesignerResult: function(result) {
			const config = {
				useFilterFn: true
			};
			const dashboards = Terrasoft.DashboardManager.getItems(config);
			dashboards.sortByFn(this.defaultDashboardsSortFn);
			this.set("Dashboards", dashboards);
			this.unloadNestedModules();
			this.set("ReloadNestedModules", true);
			this.setActiveTab(result.dashboardId);
			this._updateFavoriteTabsState();
			this.initData();
			this.reloadRecordRights();
		},

		/**
		 * Unloads nested modules.
		 * @protected
		 */
		unloadNestedModules: function() {
			this.set("ReloadNestedModules", true);
			const moduleId = this.getDashboardModuleId();
			this.sandbox.unloadModule(moduleId);
		},

		/**
		 * Add new dashboard handler.
		 * @protected
		 * @return {Object} Dashboard config.
		 */
		onGetDashboardAddInfo: function() {
			return {
				"createNew": true
			};
		},

		/**
		 * Copy dashboard handler.
		 * @protected
		 * @return {Object} Dashboard config.
		 */
		onGetDashboardCopyInfo: function() {
			return {
				"copyItem": true,
				"dashboardId": this.get("ActiveTabName")
			};
		},

		/**
		 * Get dashboard config handler.
		 * @protected
		 * @return {Object} Dashboard config.
		 */
		onGetDashboardInfo: function() {
			return {
				"dashboardId": this.get("ActiveTabName")
			};
		},

		/**
		 * Returns dashboard designer module id.
		 * @protected
		 * @return {String} Id.
		 */
		getDesignerModuleId: function() {
			return this.sandbox.id + "_Designer";
		},

		/**
		 * Returns dashboard designer module id for new dashboard.
		 * @protected
		 * @return {String} Id.
		 */
		getAddDesignerModuleId: function() {
			return this.sandbox.id + "_Designer_Add";
		},

		/**
		 * Returns dashboard designer module id for dashboard copy.
		 * @protected
		 * @return {String} Id.
		 */
		getCopyDesignerModuleId: function() {
			return this.sandbox.id + "_Designer_Copy";
		},

		/**
		 * Loads dashboard designer.
		 * @protected
		 */
		openDesigner: function(moduleId) {
			let designerModuleName = "DashboardDesigner";
			const designerModuleConfig = {
				id: (moduleId || this.getDesignerModuleId()),
				renderTo: "centerPanel",
				keepAlive: true
			};
			if (Terrasoft.Features.getIsEnabled("DashboardDesignerV2")) {
				Ext.apply(designerModuleConfig, {
					instanceConfig: {
						schemaName: "DashboardDesignerV2",
						useHistoryState: true,
						isSchemaConfigInitialized: true
					}
				});
				designerModuleName = "BaseSchemaModuleV2";
			}
			const historyState = this.sandbox.publish("GetHistoryState");
			this.sandbox.publish("PushHistoryState", {hash: historyState.hash.historyState});
			this.sandbox.loadModule(designerModuleName, designerModuleConfig);
		},

		/**
		 * Checks user's edit rights.
		 * @protected
		 * @return {Boolean} Checking result.
		 */
		canEdit: function() {
			const rightLevel = this.get("SysDashboardRightLevel");
			const dashboardId = this.get("ActiveTabName");
			let result = this.canEditSchemaData(rightLevel) && dashboardId;
			if (dashboardId) {
				const dashboard = this.getDashboard(dashboardId);
				result = result && dashboard.isValid;
			}
			return result;
		},

		/**
		 * Checks user's copy rights.
		 * @protected
		 * @return {Boolean} Checking result.
		 */
		canCopy: function() {
			const rightLevel = this.get("SysDashboardRightLevel");
			const dashboardId = this.get("ActiveTabName");
			let result = this.canAppendSchemaData(rightLevel) && dashboardId;
			if (dashboardId) {
				const dashboard = this.getDashboard(dashboardId);
				result = result && dashboard.isValid;
			}
			return result;
		},

		/**
		 * Checks user's delete rights.
		 * @protected
		 * @return {Boolean} Checking result.
		 */
		canDelete: function() {
			const rightLevel = this.get("SysDashboardRightLevel");
			return this.canDeleteSchemaData(rightLevel) && this.get("ActiveTabName");
		},

		/**
		 * Is empty collection converter.
		 * @protected
		 * @param {Terrasoft.Collection} value Collection.
		 * @return {Boolean} Checking result.
		 */
		isCollectionEmptyConverter: function(value) {
			return !value || value.isEmpty();
		},

		/**
		 * Check is tab empty.
		 * @protected
		 * @return {Boolean} Checking result.
		 */
		isTabsEmpty: function() {
			return this.isCollectionEmptyConverter(this.get("TabsCollection"));
		},

		/**
		 * Checks record's operation rights.
		 * @protected
		 * @param {String} operation Operation.
		 * @return {Boolean} Checking result.
		 */
		checkRecordOperationRights: function(operation) {
			const rights = this.get("CurrentRecordRightLevel");
			const result =
				(operation === Terrasoft.RightsEnums.operationTypes.read &&
					this.isSchemaRecordCanReadRightConverter(rights)) ||
				(operation === Terrasoft.RightsEnums.operationTypes.edit &&
					this.isSchemaRecordCanEditRightConverter(rights)) ||
				(operation === Terrasoft.RightsEnums.operationTypes.delete &&
					this.isSchemaRecordCanDeleteRightConverter(rights));
			if (!result) {
				Terrasoft.utils.showInformation(this.get("Resources.Strings.NotEnoughRightsMessage"));
			}
			return result;
		},

		/**
		 * Checks managing rights.
		 * @protected
		 * @return {Boolean} Checking result.
		 */
		canManageRights: function() {
			const currentRecordRightLevel = this.get("CurrentRecordRightLevel");
			return this.isSchemaRecordCanChangeReadRightConverter(currentRecordRightLevel) ||
					this.isSchemaRecordCanChangeEditRightConverter(currentRecordRightLevel) ||
					this.isSchemaRecordCanChangeDeleteRightConverter(currentRecordRightLevel);
		},

		/**
		 * Opens active dashboard edit page.
		 * @protected
		 */
		editCurrentDashboard: function() {
			if (!this.checkRecordOperationRights(Terrasoft.RightsEnums.operationTypes.edit)) {
				return;
			}
			this.openDesigner();
		},

		/**
		 * Copies active dashboard.
		 * @protected
		 */
		copyCurrentDashboard: function() {
			const moduleId = this.getCopyDesignerModuleId();
			this.openDesigner(moduleId);
		},

		/**
		 * Opens new tab page.
		 * @protected
		 */
		addDashboard: function() {
			const moduleId = this.getAddDesignerModuleId();
			this.openDesigner(moduleId);
		},

		/**
		 * Deletes active dashboard.
		 * @protected
		 */
		deleteCurrentDashboard: function() {
			if (!this.checkRecordOperationRights(Terrasoft.RightsEnums.operationTypes.delete)) {
				return;
			}
			Terrasoft.utils.showConfirmation(this.get("Resources.Strings.DeleteConfirmationMessage"),
				function(returnCode) {
					if (returnCode === this.Terrasoft.MessageBoxButtons.YES.returnCode) {
						this.onDeleteAccept();
					}
				},
				[
					this.Terrasoft.MessageBoxButtons.YES.returnCode,
					this.Terrasoft.MessageBoxButtons.NO.returnCode
				],
				this
			);
		},

		/**
		 * Screenshot button click handler.
		 */
		onScreenshotButtonClick: function() {
			MaskHelper.ShowBodyMask();
			Terrasoft.convertElementToCanvas("DashboardModuleContainer", {scale: 0.75}, function(canvas) {
				const currentDashboardName = this.get("ActiveTabName");
				const currentDashboard = Terrasoft.DashboardManager.getItem(currentDashboardName);
				const fileName = currentDashboard.getCaption() + ".png";
				//BrowserSupport: Edge does not support data url.
				if (canvas.msToBlob) {
					window.navigator.msSaveBlob(canvas.msToBlob(), fileName);
				} else {
					Terrasoft.download(canvas.toDataURL(), fileName);
				}
				MaskHelper.HideBodyMask();
			}, this);
		},

		/**
		 * Returns screenshot button enabled.
		 * @protected
		 * @return {Boolean} Screenshot button enabled.
		 */
		getScreenshotButtonEnabled: function() {
			return !this.Ext.isEmpty(this.get("ActiveTabName")) && !this.Terrasoft.isCurrentUserSsp();
		},

		/**
		 * Handles delete confirmation.
		 * @protected
		 */
		onDeleteAccept: function() {
			const currentTab = this.get("ActiveTabName");
			Terrasoft.DashboardManager.remove(currentTab);
			Terrasoft.DashboardManager.save(function(response) {
				if (response.success) {
					this.removeTab(currentTab);
					this.setActiveTab(null);
					this._updateFavoriteTabsState();
					this.initTabs();
				}
			}, this);
		},

		/**
		 * Open rights managing page for active dashboard.
		 * @protected
		 */
		manageCurrentDashboardRights: function() {
			this.openRightsModule();
		},

		/**
		 * Return rights module id.
		 * @protected
		 * @return {String} Id.
		 */
		getRightsModuleId: function() {
			return this.sandbox.id + "_Rights";
		},

		/**
		 * Opens rights managing page.
		 * @protected
		 */
		openRightsModule: function() {
			MaskHelper.ShowBodyMask();
			this.sandbox.loadModule("Rights", {
				renderTo: "centerPanel",
				id: this.getRightsModuleId(),
				keepAlive: true
			});
		},

		/**
		 * Returns dashboard designer module messages.
		 * @protected
		 * @return {Object} Dashboard designer module messages.
		 */
		getMessages: function() {
			return {
				/**
				 * @message HistoryStateChanged
				 * Subscribe of the state changed.
				 */
				HistoryStateChanged: {
					mode: Terrasoft.MessageMode.BROADCAST,
					direction: Terrasoft.MessageDirectionType.SUBSCRIBE
				},
				/**
				 * @message ReloadDataOnRestore
			 	 * Indicates need to reload data on next init.
				 */
				ReloadDataOnRestore: {
					mode: this.Terrasoft.MessageMode.BROADCAST,
					direction: this.Terrasoft.MessageDirectionType.BIDIRECTIONAL
				}
			};
		},

		/**
		 * Subscribes sandbox messages.
		 * @protected
		 */
		subscribeSandboxMessages: function() {
			this.subscribeDesignerMessage();
			const rightsModuleId = this.getRightsModuleId();
			this.sandbox.subscribe("GetRecordInfo", function() {
				const dashboards = this.getDashboards();
				const currentDashboardName = this.get("ActiveTabName");
				const currentDashboard = dashboards.get(currentDashboardName);
				const dashboardManagerItem = currentDashboard.getDataManagerItem();
				const result = {
					entitySchemaName: dashboardManagerItem.getEntitySchemaName(),
					entitySchemaCaption: dashboardManagerItem.getEntitySchemaCaption(),
					primaryColumnValue: currentDashboard.getId(),
					primaryDisplayColumnValue: currentDashboard.getCaption()
				};
				return result;
			}, this, [rightsModuleId]);
			this.subscribeContextHelpMessage();
		},

		/**
		 * Initializes model data.
		 * @protected
		 * @param {Function} callback Callback function.
		 * @param {Terrasoft.BaseModel} scope Callback function scope.
		 */
		init: function(callback, scope) {
			Terrasoft.chain(
				this._initProfileState,
				function() {
					this._initCollections();
					this._registerMessages();
					this.subscribeSandboxMessages();
					this.initHeader();
					this.initTabs();
					this.saveHistoryStateHash();
					RightUtilities.getSchemaOperationRightLevel("SysDashboard", function(rightLevel) {
						this.set("SysDashboardRightLevel", rightLevel);
						callback.call(scope || this);
					}, this);
				},
				this
			);
		},

		/**
		 * After render handler.
		 * @protected
		 */
		onRender: function() {
			MaskHelper.HideBodyMask();
			if (this.get("Restored")) {
				this.initHeader();
			}
			if (!this.get("Restored") || this.get("ReloadNestedModules")) {
				this.loadDashboardModule();
				this.set("ReloadNestedModules", false);
			}
		},

		/**
		 * @private
		 */
		_initCollections: function() {
			const tabsCollection = Ext.create("Terrasoft.BaseViewModelCollection", {
				entitySchema: Ext.create("Terrasoft.BaseEntitySchema", {
					columns: {},
					primaryColumnName: "Name"
				})
			});
			this.set("TabsCollection", tabsCollection);
		},

		/**
		 * @private
		 * @param {Function} callback Callback function.
		 * @param {Object} scope Callback function scope.
		 */
		_initProfileState: function(callback, scope) {
			const key = this.getProfileKey();
			Terrasoft.require(["profile!" + key], function(profile) {
				this.setActiveTab(profile.activeTabName);
				Ext.callback(callback, scope);
			}, this);
		},

		/**
		 * @private
		 */
		_registerMessages: function() {
			const messages = this.getMessages();
			this.sandbox.registerMessages(messages);
		}

	});

	/**
	 * @class Terrasoft.configuration.DashboardBuilder
	 * Dashboard builder class.
	 */
	const dashboardBuilder = Ext.define("Terrasoft.configuration.DashboardBuilder", {
		extend: "Terrasoft.BaseObject",
		alternateClassName: "Terrasoft.DashboardBuilder",

		/**
		 * View model class name.
		 * @type {String}
		 */
		viewModelClass: "Terrasoft.BaseDashboardsViewModel",

		/**
		 * View config class name.
		 * @type {String}
		 */
		viewConfigClass: "Terrasoft.DashboardViewConfig",

		/**
		 * View generator class name.
		 * @type {String}
		 */
		viewGeneratorClass: "Terrasoft.ViewGenerator",

		/**
		 * Generator config.
		 * @type {Object}
		 */
		generatorConfig: null,

		/**
		 * Requires dashboards.
		 * @protected
		 * @param {Object} config Config.
		 * @param {String} config.dashboardId Dashboard id.
		 * @param {Boolean} config.createNew Is new.
		 * @param {Function} config.sortFn Sorting function.
		 * @param {Function} callback Callback function.
		 * @param {Terrasoft.BaseModel} scope Callback function scope.
		 */
		requireDashboards: function(config, callback, scope) {
			Terrasoft.DashboardManager.initialize(config, function() {
				if (config && config.dashboardId) {
					const dashboard = Terrasoft.DashboardManager.getItem(config.dashboardId);
					const dashboardCollection = Ext.create("Terrasoft.Collection");
					dashboardCollection.add(dashboard.getId(), dashboard);
					callback.call(scope, dashboardCollection);
					return;
				}
				if (config && config.createNew) {
					Terrasoft.DashboardManager.createItem(null, function(item) {
						const items = Ext.create("Terrasoft.Collection");
						items.add(item.getId(), item);
						callback.call(scope, items);
					}, this);
					return;
				}
				Terrasoft.DashboardManager.filterFn = function(item) {
					return item.sectionId && item.sectionId.value === config.sectionId;
				};
				const getItemsConfig = {
					useFilterFn: true
				};
				const dashboards = Terrasoft.DashboardManager.getItems(getItemsConfig);
				if (Ext.isFunction(config.sortFn)) {
					dashboards.sortByFn(config.sortFn);
				}
				callback.call(scope, dashboards);
			}, this);
		},

		/**
		 * Returns dashboard sorting function.
		 * @param {Terrasoft.DashboardManagerItem} a Dashboard.
		 * @param {Terrasoft.DashboardManagerItem} b Dashboard.
		 * @return {Number} Result.
		 */
		defaultDashboardsSortFn: function(a, b) {
			const valueA = a.getCaption();
			const valueB = b.getCaption();
			return valueA.localeCompare(valueB);
		},

		/**
		 * Creates object of Terrasoft.ViewGenerator.
		 * @return {Terrasoft.ViewGenerator} Returns Terrasoft.ViewGenerator.
		 */
		createViewGenerator: function() {
			return Ext.create(this.viewGeneratorClass);
		},

		/**
		 * Builds view model object.
		 * @protected
		 * @param {Object} config Config.
		 * @param {Function} callback Callback function.
		 * @param {Terrasoft.BaseModel} scope Callback function scope.
		 */
		buildViewModel: function(config, callback, scope) {
			const viewModelColumns = {
				Dashboards: {
					type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
					dataValueType: Terrasoft.DataValueType.COLLECTION,
					value: config.dashboards
				},
				ProfileKey: {
					type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
					dataValueType: Terrasoft.DataValueType.TEXT,
					value: config.dashboardProfileKey
				},
				FavoriteTabsDecorator: {
					type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
					dataValueType: Terrasoft.DataValueType.CUSTOM_OBJECT,
					value: null
				},
			};
			const viewModelClass = Ext.define("Terrasoft.configuration.DashboardViewModel", {
				extend: this.viewModelClass,
				alternateClassName: "Terrasoft.DashboardViewModel",
				columns: viewModelColumns,
				init: function(callback, scope) {
					const parentFn = this.getParentMethod(this, [callback, scope]);
					this.$FavoriteTabsDecorator = Ext.create("Terrasoft.FavoriteTabsDecorator", {
						userProfileKey: this.$ProfileKey
					});
					this.$FavoriteTabsDecorator
						.init()
						.then(parentFn);
				},
				getDashboards: function() {
					return this.get("Dashboards");
				},
				getDashboard: function(dashboardId) {
					const dashboards = this.getDashboards();
					return dashboards.get(dashboardId);
				}
			});
			callback.call(scope, viewModelClass);
		},

		/**
		 * Builds view config.
		 * @protected
		 * @param {Object} config Config.
		 * @param {Terrasoft.Collection} config.dashboards Dashboard collection.
		 * @param {Function} callback Callback function.
		 * @param {Object} scope Callback function scope.
		 */
		buildView: function(config, callback, scope) {
			if (Ext.isFunction(config)) {
				scope = callback;
				callback = config;
				config = this.generatorConfig;
			} else {
				Ext.apply(config, this.generatorConfig);
			}
			let viewGenerator = this.createViewGenerator();
			const viewClass = Ext.create(this.viewConfigClass);
			const schema = {
				viewConfig: viewClass.generate(config.dashboards)
			};
			const viewConfig = Ext.apply({
				schema: schema
			}, config);
			viewGenerator.generate(viewConfig, function(view) {
				callback.call(scope, view);
				viewGenerator.destroy();
				viewGenerator = null;
			});
		},

		/**
		 * Builds dashboard module.
		 * @param {Object} config Build config.
		 * @param {Function} callback Callback function.
		 * @param {Object} scope Callback function scope.
		 */
		build: function(config, callback, scope) {
			const defaultConfig = {
				sortFn: this.defaultDashboardsSortFn
			};
			const generatorConfig = this.generatorConfig = Ext.apply({}, config, defaultConfig);
			this.requireDashboards(generatorConfig, function(dashboardCollection) {
				Ext.apply(generatorConfig, {
					dashboards: dashboardCollection,
					dashboardProfileKey: generatorConfig.dashboardProfileKey
				});
				this.buildViewModel(generatorConfig, function(viewModelClass) {
					generatorConfig.viewModelClass = viewModelClass;
					this.buildView(generatorConfig, function(view) {
						callback.call(scope, viewModelClass, view);
					}, this);
				}, this);
			}, this);
		},

		/**
		 * Destroys module.
		 */
		destroy: function() {
			this.generatorConfig = null;
			this.callParent(arguments);
		}
	});

	return dashboardBuilder;
});


