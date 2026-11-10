namespace Terrasoft.Configuration.NavigationMenu
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using global::Common.Logging;
	using Terrasoft.Common;
	using Core;
	using Core.Factories;
	using Creatio.FeatureToggling;
	using Terrasoft.Configuration.Section;
	using Terrasoft.Configuration.Workplace;
	using WorkplaceApi;

	[DefaultBinding(typeof(IWorkplaceNavigationPanelProvider), Name = "WorkplaceNavigationPanelProvider")]
	[DefaultBinding(typeof(IWorkplaceInfoNavigationPanelProvider), Name = "WorkplaceNavigationPanelProvider")]
	public class WorkplaceNavigationPanelProvider : IWorkplaceNavigationPanelProvider,
		IWorkplaceInfoNavigationPanelProvider
	{

		#region Constants: Private

		private const string AllAppsGroupId = "All-apps";

		#endregion

		#region Fields: Private

		private readonly string _iconBackgroundColor = string.Empty;
		private readonly IDictionary<string, NavigationMenuItem> _allAppsMenuItems
			= new Dictionary<string, NavigationMenuItem>();
		private ILog _log;
		private readonly ConfigurationSectionHelper _configurationSectionHelper;
		private readonly IConfigurationDataRelatedPagesApplier _configurationDataRelatedPagesApplier;

		private ILog Log => _log ?? (_log = LogManager.GetLogger(typeof(WorkplaceNavigationPanelProvider)));

		#endregion

		#region Properties: Private

		private UserConnection UserConnection { get; }

		private string _homePageSideBarImage;
		private string HomePageSidebarImage {
			get {
				if (!_homePageSideBarImage.IsNullOrEmpty()) {
					return _homePageSideBarImage;
				}
				ClientUnitSchema homePageClientUnit =
					UserConnection.ClientUnitSchemaManager.FindInstanceByName("SectionMenuModule");
				_homePageSideBarImage =	ImageUrlBuilder.GetClientUnitImageUrl("SectionMenuModule",
				"HomePageSidebarImage", homePageClientUnit.SchemaManager.GetHash());
				return _homePageSideBarImage;
			}
		}

		private LocalizableString _homePageCaption;
		private LocalizableString HomePageCaption => _homePageCaption ?? (_homePageCaption = new LocalizableString(UserConnection.Workspace.ResourceStorage,
			"SectionMenuModule", "LocalizableStrings.HomePageTitle.Value"));

		private IWorkplaceManager _workplaceManager;
		private IWorkplaceManager WorkplaceManager => _workplaceManager
			?? (_workplaceManager = ClassFactory.Get<IWorkplaceManager>(new ConstructorArgument("uc", UserConnection)));

		private IEnumerable<ModuleStructure> _modulesStructureValues;

		private IEnumerable<ModuleStructure> ModulesStructureValues =>
			_modulesStructureValues ?? (_modulesStructureValues =
				_configurationSectionHelper.GetSchemaModuleStructures(UserConnection));

		#endregion

		#region Constructors: Public

		public WorkplaceNavigationPanelProvider(UserConnection userConnection) {
			UserConnection = userConnection;
			_configurationSectionHelper = ClassFactory.Get<ConfigurationSectionHelper>(
				new ConstructorArgument("userConnection", UserConnection));
			_configurationDataRelatedPagesApplier = ClassFactory.Get<IConfigurationDataRelatedPagesApplier>();
		}

		#endregion

		#region Methods: Private

		private NavigationMenuItem GetNavigationMenuItem(LocalizableString caption, Guid uid, string name, string searchCaption = null) {
			return GetNavigationMenuItem(caption, uid, _iconBackgroundColor, name, HomePageSidebarImage,
				WorkplaceNavigationItemType.Schema, searchCaption);
		}

		private NavigationMenuItem GetNavigationMenuItem(SectionDto section) {
			return GetNavigationMenuItem(section.Caption, section.Id, section.IconBackground, section.SchemaName,
				GetIconUrl(section.Image32Id), GetWorkplaceNavigationItemType(section.IsModule));
		}

		private NavigationMenuItem GetNavigationMenuItem(string caption, Guid id, string iconBackground, string name,
			string iconUrl, WorkplaceNavigationItemType type, string searchCaption = null) {
			return new NavigationMenuItem {
				Caption = caption,
				Id = id.ToString(),
				IconBackgroundColor = iconBackground,
				Name = name,
				IconUrl = iconUrl,
				Type = type.ToString().ToLower(),
				SearchCaption = searchCaption ?? caption,
			};
		}

		private bool GetIsAvailableSection(SectionDto section) {
			if (UserConnection.CurrentUser.ConnectionType != UserType.SSP) {
				return true;
			}
			return UserConnection.DBSecurityEngine.GetIsAvailableOnSsp(section.Code);
		}

		private List<NavigationMenuGroup> LoadMenuGroups() {
			List<WorkplaceDto> workplaces = GetWorkplaces().ToList();
			return CreateNavigationMenuGroups(workplaces);
		}

		private void AddAllAppsMenuItem(NavigationMenuItem menuItem) {
			string sysModuleId = menuItem.Id;
			if (!_allAppsMenuItems.ContainsKey(sysModuleId)) {
				_allAppsMenuItems.Add(sysModuleId, menuItem);
			}
		}

		private void AddHomePageMenuItem(WorkplaceDto workplace, NavigationMenuGroup menuGroup) {
			Guid? homePageUId = workplace.HomePageUId;
			if (!homePageUId.HasValue) {
				return;
			}
			ISchemaManagerItem<ClientUnitSchema> clientUnitSchema =
				UserConnection.ClientUnitSchemaManager.FindItemByUId(homePageUId.Value);
			if (clientUnitSchema == null) {
				return;
			}
			string schemaCaption = clientUnitSchema.Caption;
			NavigationMenuItem homePageMenuItem = GetNavigationMenuItem(HomePageCaption, homePageUId.Value, clientUnitSchema.Name, schemaCaption);
			menuGroup.Sections.Add(homePageMenuItem);
			NavigationMenuItem allAppsHomePageMenuItem = GetNavigationMenuItem(schemaCaption, homePageUId.Value, clientUnitSchema.Name);
			AddAllAppsMenuItem(allAppsHomePageMenuItem);
		}

		private void AddSectionsMenuItems(IEnumerable<SectionDto> sections, NavigationMenuGroup menuGroup) {
			var availableSection = sections.Where(GetIsAvailableSection).ToList();
			if (availableSection.IsNullOrEmpty()) {
				Log.Info($"Could not find sections for workplace {menuGroup.Caption} " +
					$"for user with Id {UserConnection.CurrentUser.Id}");
				return;
			}
			List<NavigationMenuItem> menuItems = availableSection.Select(GetNavigationMenuItem).ToList();
			menuGroup.Sections.AddRange(menuItems);
			menuItems.ForEach(AddAllAppsMenuItem);
		}

		private NavigationMenuGroup CreateNavigationMenuGroup(WorkplaceDto workplace) {
			Guid id = workplace.Id;
			NavigationMenuGroup menuGroup = CreateNavigationMenuGroup(workplace.Name, id);
			AddHomePageMenuItem(workplace, menuGroup);
			AddSectionsMenuItems(workplace.Sections, menuGroup);
			return menuGroup;
		}

		private static NavigationMenuGroup CreateNavigationMenuGroup(string name, Guid id) {
			var menuGroup = new NavigationMenuGroup {
				Caption = name,
				Id = id.ToString(),
				Sections = new List<NavigationMenuItem>()
			};
			return menuGroup;
		}

		private List<NavigationMenuGroup> CreateNavigationMenuGroups(List<WorkplaceDto> workplacesDtos) {
			if (workplacesDtos.IsNullOrEmpty()) {
				Log.Info($"Could not find workplaces for user with Id {UserConnection.CurrentUser.Id}");
			}
			var result = new List<NavigationMenuGroup>();
			workplacesDtos.ForEach(workplace => {
				result.Add(CreateNavigationMenuGroup(workplace));
			});
			return result;
		}

		private IEnumerable<WorkplaceDto> GetWorkplaces() {
			if (Features.GetIsEnabled("EnableReloadAppCacheForWorkplacesByDefault")) {
				WorkplaceManager.ReloadWorkplaces();
			}
			return WorkplaceManager.GetAvailableWorkplacesInfo(new AvailableWorkplacesInfoRequest {
				UserId = UserConnection.CurrentUser.Id,
				ApplicationClientTypeId = BaseConsts.BrowserClientTypeId
			})?.Workplaces ?? new List<WorkplaceDto>();
		}

		private WorkplacesInfoDto GetWorkplacesInfo(Guid applicationClientTypeId) {
			if (Features.GetIsEnabled("EnableReloadAppCacheForWorkplacesByDefault")) {
				WorkplaceManager.ReloadWorkplaces();
			}
			return WorkplaceManager.GetAvailableWorkplacesInfo(new AvailableWorkplacesInfoRequest() {
					UserId = UserConnection.CurrentUser.Id,
					ApplicationClientTypeId = applicationClientTypeId
				});
		}

		private static string GetIconUrl(Guid iconId) {
			return iconId == Guid.Empty ? string.Empty : $"/img/entity/hash/SysImage/Data/{iconId}";
		}

		private static WorkplaceNavigationItemType GetWorkplaceNavigationItemType(bool isModule) {
			return isModule
				? WorkplaceNavigationItemType.Module
				: WorkplaceNavigationItemType.Schema;
		}

		private NavigationMenuGroup CreateAllAppsMenuGroup() {
			return new NavigationMenuGroup {
				Id = AllAppsGroupId,
				Caption = new LocalizableString(UserConnection.Workspace.ResourceStorage,
					"WorkplaceNavigationPanelProvider",
					"LocalizableStrings.AllAppsTitle.Value"),
				Sections = GetAllAppsMenuItems()
			};
		}

		private IList<NavigationMenuItem> GetAllAppsMenuItems() {
			List<ModuleStructure> modulesStructureInAllApps = ModulesStructureValues.Where(x =>
				_allAppsMenuItems.ContainsKey(x.ModuleId)).ToList();
			return _allAppsMenuItems.Values
				.Where(menuItem => NeedShowMenuItemInAllApps(modulesStructureInAllApps, menuItem.Id))
				.OrderBy(menuItem => menuItem.Caption)
				.ToList();
		}

		private bool NeedShowMenuItemInAllApps(IList<ModuleStructure> modulesStructureInAllApps, string itemId) {
			ModuleStructure moduleItem =
				modulesStructureInAllApps.FirstOrDefault(module => module.ModuleId == itemId);
			if (moduleItem == null) {
				return true;
			}
			string entitySchemaName = moduleItem.EntitySchemaName;
			IEnumerable<ModuleStructure> structureByEntity =
				modulesStructureInAllApps.Where(module => module.EntitySchemaName == entitySchemaName).ToList();
			IEnumerable<ModuleStructure> duplicateModuleItems =
				structureByEntity.Where(module => module.ModuleId != itemId);
			if (!duplicateModuleItems.Any()) {
				return true;
			}
			bool use7XSection = _configurationDataRelatedPagesApplier.Use7XSection(entitySchemaName);
			if (use7XSection) {
				bool is7XSection = !moduleItem.Section8X;
				return is7XSection || structureByEntity.All(x => x.Section8X);
			} else {
				bool is8XSection = moduleItem.Section8X;
				return is8XSection || structureByEntity.All(x => !x.Section8X);
			}
		}

		private bool GetShowAllAps(int groupsCount) {
			return groupsCount > 1
				&& UserConnection.DBSecurityEngine.GetCanExecuteOperation("CanViewAllAppsWorkplace");
		}

		private void AddAllAppsMenuGroup(List<NavigationMenuGroup> menuGroups) {
			if (GetShowAllAps(menuGroups.Count)) {
				menuGroups.Insert(0, CreateAllAppsMenuGroup());
			}
		}

		private NavigationMenuGroupsInfo LoadWorkplacesByType(Guid applicationClientTypeId) {
			WorkplacesInfoDto workplacesInfo = GetWorkplacesInfo(applicationClientTypeId);
			List<WorkplaceDto> workplaces = workplacesInfo.Workplaces.ToList();
			List<NavigationMenuGroup> menuGroups = CreateNavigationMenuGroups(workplaces);
			AddAllAppsMenuGroup(menuGroups);
			return new NavigationMenuGroupsInfo {
				Groups = menuGroups,
				LoadingResult = workplacesInfo.LoadingResult
			};
		}

		#endregion

		#region Methods: Public

		/// <inheritdoc />
		public IEnumerable<NavigationMenuGroup> Load() {
			List<NavigationMenuGroup> menuGroups = LoadMenuGroups();
			AddAllAppsMenuGroup(menuGroups);
			return menuGroups;
		}

		/// <inheritdoc />
		public NavigationMenuGroupsInfo LoadInfo() {
			return LoadWorkplacesByType(BaseConsts.BrowserClientTypeId);
		}

		/// <inheritdoc />
		public NavigationMenuGroupsInfo LoadMobileWorkplaces() {
			return LoadWorkplacesByType(BaseConsts.PhoneClientTypeId);
		}

		#endregion

	}
}

