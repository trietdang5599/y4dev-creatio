define("LeftPanelClientWorkplaceMenu", ["LeftPanelClientWorkplaceMenuResources", "MaskHelper", "ServiceHelper",
	"RightUtilities", "profile!clientWorkplaceMenuProfile", "css!LeftPanelTopMenuModule", "ViewGeneratorV2",
	"CheckModuleDestroyMixin"],
	function(resources, MaskHelper, ServiceHelper, RightUtilities, clientWorkplaceMenuProfile) {

		Ext.define("Terrasoft.configuration.WorkplaceMenuViewModel", {
			extend: "Terrasoft.BaseViewModel",
			alternateClassName: "Terrasoft.WorkplaceMenuViewModel",
			mixins: {
				TooltipUtilitiesMixin: "Terrasoft.TooltipUtilities",
				CheckModuleDestroyMixin: "Terrasoft.CheckModuleDestroyMixin"
			},
			Ext: null,
			Terrasoft: null,
			sandbox: null,

			reloadMenu: function(workplaces, workplaceId) {
				var control = Ext.getCmp("menu-workplace-button");
				if (!control) {
					return;
				}
				var menuItems = [];
				Terrasoft.each(workplaces, function(item) {
					if (item.hide) {
						return;
					}
					var menuItemConfig = {
						caption: item.name,
						tag: item.workplaceId,
						markerValue: item.name,
						click: {
							bindTo: "menuItemClick"
						}
					};
					if (Terrasoft.Features.getIsDisabled("DisableHomePageInWorkplace")) {
						menuItemConfig.canExecute = {bindTo: "canBeDestroyed"};
					}
					menuItems.push(menuItemConfig);
					if (workplaceId === item.workplaceId) {
						control.caption = item.name;
					}
				}, this);
				if (workplaceId === undefined) {
					control.caption = workplaces[0].name;
				}
				var menu = Ext.create("Terrasoft.Menu", {
					items: menuItems,
					markerValue: "TopWorkplaceMenu"
				});
				menu.bind(this);
				control.menu = menu;
				control.reRender();
			},
			loadMenu: function(workplaces, workplaceId) {
				var collection = this.get("WorkplaceCollection");
				if (!collection.isEmpty()) {
					collection.clear();
				}
				Terrasoft.each(workplaces, function(item) {
					if (item.hide) {
						return;
					}
					const values = {
						Id: Terrasoft.generateGUID(),
						Caption: item.name,
						MarkerValue: item.name,
						Tag: item.workplaceId,
						Click: {bindTo: "menuItemClick"},
					};
					if (Terrasoft.Features.getIsDisabled("DisableHomePageInWorkplace")) {
						values.canExecute = {bindTo: "canBeDestroyed"};
					}
					collection.addItem(Ext.create("Terrasoft.BaseViewModel", {
						values,
					}));
					if (workplaceId === item.workplaceId) {
						this.set("TopWorkplaceMenuCaption", item.name);
					}
				}, this);
			},
			loadMenuItems: function(workplaceId) {
				var workplaces =
						Terrasoft.deepClone(Terrasoft.configuration.WorkplacesStructure.Workplaces);
				if (workplaces.length > 0) {
					let needCompareByName = Terrasoft.Features.getIsEnabled("UseNameForSortingWorkplace");
					workplaces.sort(function(workplace1, workplace2) {
						let comparePropertyName = "position";
						if (needCompareByName || !this._hasPosition(workplace1, workplace2)) {
							comparePropertyName = "name";
						}
						return this._compareWorkspaceOnProperty(workplace1, workplace2, comparePropertyName);
					}.bind(this));
					this.loadMenu(workplaces, workplaceId);
				}
			},
			_hasPosition: function(workplace1, workplace2) {
				return Ext.isNumeric(workplace1.position) && Ext.isNumeric(workplace2.position);
			},
			_compareWorkspaceOnProperty: function(workplace1, workplace2, propertyName) {
				let workplacePropertyValue1 = workplace1[propertyName];
				let workplacePropertyValue2 = workplace2[propertyName];
				if (workplacePropertyValue1 < workplacePropertyValue2) {
					return -1;
				}
				if (workplacePropertyValue1 > workplacePropertyValue2) {
					return 1;
				}
				return 0;
			},
			menuItemClick: function(tag) {
				if (this.get("selectedWorkplaceId") === tag) {
					return;
				}
				this.loadMenuItems(tag);
				var dataSend = {
					workplaceId: tag
				};
				Terrasoft.utils.saveUserProfile("clientWorkplaceMenuProfile", dataSend);
				ServiceHelper.callService("WorkplaceService", "SetWorkplaceCache", Terrasoft.emptyFn, dataSend, this);
				const loadFirstModule = Terrasoft.Features.getIsDisabled("DisableHomePageInWorkplace");
				this.load(tag, loadFirstModule);
				this.set("selectedWorkplaceId", tag);
			},
			load: function(tag, loadFirstModule = false) {
				var workplaceItem = this.getWorkplaceData(tag);
				if (workplaceItem) {
					var sandbox = this.get("Sandbox");
					sandbox.subscribe("GetWorkplaceInfo", function() {
						return {
							...workplaceItem,
							loadFirstModule
						};
					});
					sandbox.loadModule(workplaceItem.loaderName);
				}
			},
			getWorkplaceData: function(workplaceId) {
				var workplaces = Terrasoft.configuration.WorkplacesStructure.Workplaces;
				var workplaceItem = null;
				if (workplaces.length > 0) {
					Terrasoft.each(workplaces, function(item) {
						if (item.workplaceId === workplaceId) {
							workplaceItem = item;
						}
					}, this);
				} else {
					workplaceItem = {loaderName: "BaseWorkplaceLoader"};
				}
				return workplaceItem;
			},
			addHighlight: function() {
				this.set("TopWorkplaceMenuButtonStyle", "highlighted");
			},
			removeHighlight: function() {
				this.set("TopWorkplaceMenuButtonStyle", Terrasoft.controls.ButtonEnums.style.TRANSPARENT);
			}
		});

		function createConstructor(context) {
			var container;
			var viewModel;
			var Ext = context.Ext;
			var sandbox = context.sandbox;
			var Terrasoft = context.Terrasoft;
			var profile = clientWorkplaceMenuProfile;

			/**
			 * Returns tip view.
			 * @param {Object} config Configuration to generate tip view.
			 * @return {Object}
			 */
			function generateTip(config) {
				var viewGenerator = Ext.create("Terrasoft.ViewGenerator");
				var tip = viewGenerator.generatePartial(Ext.merge({
					itemType: Terrasoft.ViewItemType.TIP
				}, config), {
					schemaName: "LeftPanelClientWorkplaceMenu",
					schema: {},
					viewModelClass: Ext.ClassManager.get("Terrasoft.WorkplaceMenuViewModel")
				})[0];
				return tip;
			}

			var getViewConfig = function() {
				var workplaceMenuTip = generateTip({
					content: resources.localizableStrings.WorkplaceMenuTip,
					className: "Terrasoft.ContextTip",
					contextIdList: ["0", "IntroPage"],
					behaviour: {
						displayEvent: Terrasoft.TipDisplayEvent.NONE
					}
				});
				var topMenuContainer = {
					className: "Terrasoft.Container",
					id: "top-menu-workplace-button-container",
					selectors: {
						wrapEl: "#top-menu-workplace-button-container"
					},
					classes: {
						wrapClassName: ["top-menu-workplace-button-container-wrapEl"]
					},
					items: getTopMenuConfig("Default"),
					tips: [workplaceMenuTip]
				};
				return topMenuContainer;
			};

			function getTopMenuConfig() {
				var menuConfig = {
						id: "menu-workplace-button",
						selectors: {
							wrapEl: "#menu-workplace-button"
						},
						tag: "TopWorkplaceMenu",
						markerValue: "TopWorkplaceMenu",
						className: "Terrasoft.Button",
						style: {
							bindTo: "TopWorkplaceMenuButtonStyle"
						},
						caption: {
							bindTo: "TopWorkplaceMenuCaption"
						},
						menu: {
							items: {
								bindTo: "WorkplaceCollection"
							}
						},
						prepareMenu: {bindTo: "addHighlight"},
						hideMenu: {bindTo: "removeHighlight"}
					};
				return [menuConfig];
			}

			var getViewModel = function(context) {
				return Ext.create("Terrasoft.WorkplaceMenuViewModel", {
					values: {
						selectedWorkplaceId: null,
						TopWorkplaceMenuCaption: "",
						WorkplaceCollection: Ext.create("Terrasoft.BaseViewModelCollection"),
						TopWorkplaceMenuButtonStyle: Terrasoft.controls.ButtonEnums.style.TRANSPARENT,
						Sandbox: context.sandbox,
					},
					Ext: context.Ext,
					Terrasoft: context.Terrasoft,
					sandbox: context.sandbox
				});
			};
			var findWorkplace = function() {
				if (!Terrasoft.Features.getIsDisabled("DisableAutoFindWorkplace")) {
					return null;
				}
				var state = sandbox.publish("GetHistoryState");
				if (!state.hash) {
					return null;
				}
				var moduleName = state.hash.moduleName;
				var sectionName = state.hash.entityName;
				var workplaces = Terrasoft.configuration.WorkplacesStructure.Workplaces;
				const savedWorkplaceId = profile && profile.workplaceId;
				const foundWorkplace = workplaces.find(workplace => workplace.workplaceId === savedWorkplaceId);				
				if (foundWorkplace && checkWorkplaceContainsSection(foundWorkplace, moduleName, sectionName)) {
					return foundWorkplace.workplaceId;
				}
				for (let workplace of workplaces) {
					if (checkWorkplaceContainsSection(workplace, moduleName, sectionName)) {
						return workplace.workplaceId;
					}
				}
				return null;
			};
			function checkWorkplaceContainsSection(workplace, moduleName, sectionName) {
				for (let module of workplace.modules) {
					var isSuitableModuleWithAbsentSection = module.moduleName == moduleName && !sectionName;
					var isSuitableSection = module.sectionName == sectionName || module.sectionName == moduleName;
					var isSuitableModuleAndSection = module.moduleName == moduleName && module.sectionName == sectionName;
					if (isSuitableModuleWithAbsentSection || isSuitableSection || isSuitableModuleAndSection) {
						return true;
					}
				}
				return false;
			}
			var loadMenu = function(loadFirstModuleWithUnfoundWorkplace) {
				var workplaceId;
				var workplaces = Terrasoft.configuration.WorkplacesStructure.Workplaces;
				var findWorkplaceId = findWorkplace();
				if (findWorkplaceId && !viewModel.$selectedWorkplaceId) {
					viewModel.$selectedWorkplaceId = findWorkplaceId;
				}
				const selectedWorkplaceId = viewModel.$selectedWorkplaceId || (profile && profile.workplaceId);
				if (selectedWorkplaceId) {
					var isInWorkplace = workplaces.some(function(item) {
						return item.workplaceId === selectedWorkplaceId;
					});
					if (isInWorkplace) {
						workplaceId = selectedWorkplaceId;
					} else if (workplaces.length) {
						viewModel.$selectedWorkplaceId = workplaces[0].workplaceId;
						profile.workplaceId = viewModel.$selectedWorkplaceId
						workplaceId = profile.workplaceId;
					}
				} else if (workplaces.length) {
					workplaceId = profile.workplaceId = viewModel.$selectedWorkplaceId = workplaces[0].workplaceId;
				}
				if (workplaceId != null) {
					viewModel.loadMenuItems(workplaceId);
				}
				var loadFirstModule = loadFirstModuleWithUnfoundWorkplace && !findWorkplaceId;
				viewModel.load(workplaceId, loadFirstModule);
			};
			const onRefreshWorkplace = function(loadFirstModuleWithUnfoundWorkplace) {
				ServiceHelper.callService("WorkplaceService", "RefreshWorkplace", function(response) {
					Terrasoft.configuration.WorkplacesStructure = JSON.parse(response.RefreshWorkplaceResult);
					loadMenu(loadFirstModuleWithUnfoundWorkplace);
				}, null, this);
			};
			const _onMessageHandler = function(channel, message) {
				if (!message) {
					return;
				}
				var isHomePageDesignerSaved = message.event === "HomePageDesignerSaved";
				var isAppUninstall = message.event === "UninstallApplication";
				if (isHomePageDesignerSaved || isAppUninstall) {
					onRefreshWorkplace(isAppUninstall);
				}
			};
			var generate = function() {
				var view = Ext.create("Terrasoft.Container", getViewConfig());
				viewModel = getViewModel(context);
				view.bind(viewModel);
				view.render(container);
				Terrasoft.ServerChannel.on(Terrasoft.ServerChannelSender.BROADCAST_MESSAGE, _onMessageHandler, this);
				sandbox.subscribe("RefreshWorkplace", onRefreshWorkplace);
				loadMenu();
				sandbox.subscribe("ChangeCurrentWorkplace", function(args) {
					viewModel.menuItemClick(args);
				});
			};

			function render(renderTo) {
				container = renderTo;
				generate();
			}

			return Ext.define("LeftPanelClientWorkplaceMenu", {
				render: render
			});
		}

		return createConstructor;
	});
