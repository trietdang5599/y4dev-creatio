namespace Terrasoft.Configuration
{
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Data;
	using System.Linq;
	using System.Security.Cryptography;
	using System.Text;
	using Terrasoft.Common;
	using Terrasoft.Common.Json;
	using Terrasoft.Common.Messaging;
	using Terrasoft.Configuration.Workplace;
	using Terrasoft.Configuration.WorkplaceSectionAccess;
	using Terrasoft.Core;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Factories;
	using Terrasoft.Core.FeatureToggling;
	using Terrasoft.Core.Process;
	using Terrasoft.Core.RelatedPages.Interfaces;
	using Terrasoft.Core.RelatedPages.Models;
	using Terrasoft.Core.Store;
	using Terrasoft.Nui;
	using Terrasoft.UI.WebControls;
	using Terrasoft.Web.Http.Abstractions;
	using Terrasoft.Core.RelatedPages;
	using WorkplaceApi;
	using CoreSysSettings = Terrasoft.Core.Configuration.SysSettings;
	using HttpUtility = System.Web.HttpUtility;

	#region Class: ConfigurationSectionHelper

	public class ConfigurationSectionHelper : ISectionHelper
	{

		#region Constants: Private

		private const string WorkplaceCacheKeyTemplate = "SysWorkplaceId_{0}";
		private const string GuidTypeName = "Guid";
		private const string LocalCacheGroupName = "LoginLocalCache";
		private const string ConfigurationScriptCacheKeyTemplate = "ConfigurationScript_{0}_{1}";
		private const string ShellConfigurationScriptCacheKeyTemplate = "ShellConfigurationScript_{0}_{1}";
		private const string ModuleStructureCacheKeyTemplate = "ModuleStructure_{0}_{1}";
		private const string EntityStructureCacheKeyTemplate = "EntityStructure_{0}_{1}";
		//TODO https://creatio.atlassian.net/browse/RND-37733
		private const string RootSchemaDescriptorsCacheKeyTemplate = "RootSchemaDescriptors_{0}_{1}";
		private const string EnvironmentInitializationHandlerCacheKeyTemplate = "EnvironmentInitializationScript_{0}_{1}";
		private const string RootSchemaDescriptors = "RootSchemaDescriptors";
		private const string IsFirstLoginKey = "IsFirstLogin";
		private const string MiniPageAddModeCode = "Has{0}MiniPageAddMode";
		private const string DoNotUseMultiLanguageData = "DoNotUseMultilanguageData";
		private const string DisableGetTypedColumnToModuleStructureFromAddon = "DisableGetTypedColumnToModuleStructureFromAddon";
		private const string FreedomUISectionModuleSchemaName = "SectionSchemaViewModule";

		#endregion

		#region Fields: Private

		private static readonly object _lockObject = new object();
		private UserConnection _userConnection;
		private readonly IHttpContextAccessor _httpContextAccessor;
		private readonly IClientUnitSchemaDecorator _clientUnitSchemaDecorator;
		private Select _moduleStructureSelect;
		private readonly IConfigurationDataRelatedPagesApplier _configurationDataRelatedPagesApplier;
		private readonly IBaseWorkplaceSectionAccessManager _workplaceSectionAccessManager;

		#endregion

		#region Constructors: Public

		public ConfigurationSectionHelper(UserConnection userConnection)
			: this(userConnection, HttpContext.HttpContextAccessor) {
		}

		public ConfigurationSectionHelper(UserConnection userConnection, IHttpContextAccessor httpContextAccessor)
			: this(userConnection, httpContextAccessor, ClassFactory.Get<IClientUnitSchemaDecorator>()) {
		}

		public ConfigurationSectionHelper(UserConnection userConnection, IHttpContextAccessor httpContextAccessor,
				IClientUnitSchemaDecorator clientUnitSchemaDecorator)
			: this(userConnection, httpContextAccessor, clientUnitSchemaDecorator,
				ClassFactory.Get<IConfigurationDataRelatedPagesApplier>()) {
		}

		public ConfigurationSectionHelper(UserConnection userConnection, IHttpContextAccessor httpContextAccessor,
				IClientUnitSchemaDecorator clientUnitSchemaDecorator,
				IConfigurationDataRelatedPagesApplier configurationDataRelatedPagesApplier)
			: this(userConnection, httpContextAccessor, clientUnitSchemaDecorator, configurationDataRelatedPagesApplier,
				ClassFactory.Get<IClassicUiWorkplaceSectionAccessManager>()) {
		}

		public ConfigurationSectionHelper(UserConnection userConnection, IHttpContextAccessor httpContextAccessor,
				IClientUnitSchemaDecorator clientUnitSchemaDecorator,
				IConfigurationDataRelatedPagesApplier configurationDataRelatedPagesApplier,
				IBaseWorkplaceSectionAccessManager workplaceSectionAccessManager) {
			_userConnection = userConnection;
			_httpContextAccessor = httpContextAccessor;
			_clientUnitSchemaDecorator = clientUnitSchemaDecorator;
			_configurationDataRelatedPagesApplier = configurationDataRelatedPagesApplier;
			_workplaceSectionAccessManager = workplaceSectionAccessManager;
		}

		#endregion

		#region Properties: Private

		private UserConnection SystemUserConnection => _userConnection.AppConnection.SystemUserConnection;

		#endregion
		
		#region Properties: Protected

		protected virtual bool UseShellConfigurationScript => false;

		#endregion

		#region Methods: Private

		private static ClientUnitSchemaType GetClientUnitSchemaType(UserConnection userConnection, Guid cardSchemaUId) {
			ClientUnitSchemaType schemaType = ClientUnitSchemaType.None;
			if (!cardSchemaUId.IsNotEmpty()) {
				return schemaType;
			}
			ClientUnitSchemaManager clientUnitSchemaManager = userConnection.ClientUnitSchemaManager;
			ISchemaManagerItem<ClientUnitSchema> cardSchemaManagerItem = clientUnitSchemaManager
				.FindItemByUId(cardSchemaUId);
			ExtraProperty cardSchemaTypeProperty = cardSchemaManagerItem?.ExtraProperties?.FindByName("SchemaType");
			string cardSchemaTypePropertyValue = cardSchemaTypeProperty?.Value?.ToString();
			if (cardSchemaTypePropertyValue.IsNullOrEmpty() ||
					!Enum.TryParse(cardSchemaTypePropertyValue, out schemaType)) {
				schemaType = ClientUnitSchemaType.None;
			}
			return schemaType;
		}

		private static string GetLczSchemaName(string schemaName, UserConnection userConnection) {
			if (!GlobalAppSettings.UseEntitySchemaLczNaming) {
				return schemaName.StartsWith("Sys")
					? string.Concat(schemaName, "Lcz")
					: string.Concat("Sys", schemaName, "Lcz");
			}
			EntitySchema entitySchema = userConnection.EntitySchemaManager.FindInstanceByName(schemaName);
			return entitySchema.LocalizationSchemaName;
		}

		private static string GetLessConstantsScript(UserConnection userConnection) {
			var sysSettingsList = new List<string> {"SectionPanelBackgroundColor", "SectionPanelFontColor",
				"SectionPanelSelectedBackgroundColor", "SectionPanelSelectedFontColor"};
			var sysSettingsDictionary = new Dictionary<string, string>();
			foreach (string sysSetting in sysSettingsList) {
				if (CoreSysSettings.TryGetValue(userConnection, sysSetting, out object sysSettingValue)) {
					sysSettingsDictionary.Add(sysSetting, sysSettingValue.ToString());
				}
			}
			string json = Json.Serialize(sysSettingsDictionary);
			return $"Terrasoft.Resources.LessConstants={json};";
		}

		private static string GetSysSettingsHashScript(UserConnection userConnection) {
			var sysSettingsList = new List<string> {
				"LogoImage",
				"MenuLogoImage",
				"HeaderLogoImage"
			};
			var sysSettingsValueHash = new Dictionary<string, string>();
			foreach (string sysSetting in sysSettingsList) {
				if (CoreSysSettings.TryGetValue(userConnection, sysSetting, out object sysSettingValue)) {
					using (MD5 md5Hash = MD5.Create()) {
						byte[] hash = md5Hash.ComputeHash((byte[])sysSettingValue);
						var sb = new StringBuilder();
						foreach (byte hashByte in hash) {
							sb.Append(hashByte.ToString("x2"));
						}
						string hashString = sb.ToString();
						sysSettingsValueHash.Add(sysSetting, hashString);
					}
				}
			}
			string json = Json.Serialize(sysSettingsValueHash);
			return $"Terrasoft.SysSettingsImageHash={json};";
		}

		private static string GetWorkplaceCacheKey(UserConnection userConnection) {
			return string.Format(WorkplaceCacheKeyTemplate, userConnection.CurrentUser.Id);
		}

		private static Guid? GetWorkplaceCashedValue(UserConnection userConnection) {
			string key = GetWorkplaceCacheKey(userConnection);
			object cachedValue = userConnection.SessionCache[key];
			Guid? result = null;
			if (cachedValue != null) {
				result = new Guid(cachedValue.ToString());
			}
			return result;
		}

		private static string GetDefaultIntroPageNameScript(UserConnection userConnection) {
			if (!CoreSysSettings.TryGetValue(userConnection, "DefaultIntroPage", out object defaultIntroPageId) ||
					defaultIntroPageId == null) {
				return string.Empty;
			}
			using (DBExecutor dbExecutor = userConnection.EnsureDBConnection()) {
				var query = (Select)new Select(userConnection)
						.Column("SysSchema", "Name")
					.From("ApplicationMainMenu")
					.InnerJoin("SysSchema").On("ApplicationMainMenu", "IntroPageUId").IsEqual("SysSchema", "UId")
					.Where("ApplicationMainMenu", "Id").IsEqual(Column.Parameter(defaultIntroPageId));
				string defaultIntroPageName = query.ExecuteScalar<string>(dbExecutor);
				if (defaultIntroPageName.IsNotNullOrEmpty()) {
					return $"Terrasoft.configuration.defaultIntroPageName=\"{defaultIntroPageName}\";";
				}
			}
			return string.Empty;
		}

		private static string GetValidUserTasksByDefault(UserConnection userConnection) {
			var validUserTasksByDefault = new[] {
				"ActivityUserTask",
				"AutoGeneratedPageUserTask"
			};
			ProcessUserTaskSchemaManager userTaskSchemaManager = userConnection.ProcessUserTaskSchemaManager;
			string validUserTasksByDefaultString = string.Join(",", validUserTasksByDefault
				.Select(x => '\'' + userTaskSchemaManager.FindItemByName(x).UId.ToString() + '\''));
			return $"Terrasoft.configuration.validUserTasksByDefault=[{validUserTasksByDefaultString}];";
		}

		private static Select GetQuickAddMenuItemsSelect(UserConnection userConnection) {
			Guid userId = userConnection.CurrentUser.Id;
			bool useMultiLanguageData = !userConnection.GetIsFeatureEnabled(DoNotUseMultiLanguageData);
			var select = new Select(userConnection).Distinct()
				.Column("QuickAddMenuItem", "Id")
				.Column("QuickAddMenuItem", "Position")
				.Column("QuickAddMenuItem", "Name");
			if (useMultiLanguageData) {
				string lczSchemaName = GetLczSchemaName("QuickAddMenuItem", userConnection);
				Guid sysCultureId = userConnection.CurrentUser.SysCultureId;
				select
					.Column(lczSchemaName, "Name").As("Caption")
					.LeftOuterJoin(lczSchemaName)
						.On(lczSchemaName, "RecordId").IsEqual("QuickAddMenuItem", "Id")
						.And(lczSchemaName, "SysCultureId").IsEqual(Column.Parameter(sysCultureId));
			}
			select
					.Column("QuickAddMenuItem", "SysModuleEditId")
					.Column("SysModuleEntity", "SysEntitySchemaUId").As("SysEntitySchemaUId")
					.Column("SysModuleEntity", "TypeColumnUId").As("TypeColumnUId")
					.Column("VwSysModuleSchemaEdit", "TypeColumnValue").As("TypeColumnValue")
					.Column("VwSysModuleSchemaEdit", "SysModuleEntityId").As("SysModuleEntityId")
					.Column("VwSysModuleSchemaEdit", "EditPageName").As("EditPageName")
					.Column("VwSysModuleSchemaEdit", "MiniPageSchemaUId").As("MiniPageSchemaUId")
					.Column("VwSysModuleSchemaEdit", "MiniPageModes").As("MiniPageModes")
					.Column("SysSchema", "Name").As("EntityName")
					.Column("QuickAddMenuSettings", "Position").As("SettingPosition")
					.Column("ssModule", "Name").As("ModuleName")
				.From("QuickAddMenuItem")
				.Join(JoinType.LeftOuter, "QuickAddMenuSettings").On("QuickAddMenuSettings", "SysAdminUnitId")
					.IsEqual("QuickAddMenuItem", "QuickAddMenuSettingsId")
				.Join(JoinType.LeftOuter, "VwSysModuleSchemaEdit")
					.On("VwSysModuleSchemaEdit", "Id").IsEqual("QuickAddMenuItem", "SysModuleEditId")
				.Join(JoinType.LeftOuter, "SysModuleEntity")
					.On("SysModuleEntity", "Id").IsEqual("VwSysModuleSchemaEdit", "SysModuleEntityId")
				.Join(JoinType.LeftOuter, "SysSchema")
					.On("SysSchema", "UId").IsEqual("SysModuleEntity", "SysEntitySchemaUId")
				.Join(JoinType.LeftOuter, "SysSchema").As("ssModule")
					.On("ssModule", "UId").IsEqual("QuickAddMenuItem", "ModuleUId")
				.Where("QuickAddMenuItem", "QuickAddMenuSettingsId")
					.IsEqual(new Select(userConnection).Top(1)
						.Column("Id")
						.From("QuickAddMenuSettings")
						.Where().Exists(new Select(userConnection)
								.Column(Column.Const(1))
							.From("SysAdminUnitInRole")
							.Where("SysAdminUnitInRole", "SysAdminUnitId").IsEqual(Column.Parameter(userId))
								.And("QuickAddMenuSettings", "SysAdminUnitId")
									.IsEqual("SysAdminUnitInRole", "SysAdminUnitRoleId") as Select)
						.OrderByAsc("Position"))
				.OrderByAsc("QuickAddMenuItem", "Position");
			return select;
		}

		private static bool HasSchemaEditAddMiniPage(UserConnection userConnection, string entityName,
				string miniPageModes) {
			return string.IsNullOrEmpty(miniPageModes)
				? GetMiniPageAddModeSysSetting(userConnection, entityName)
				: miniPageModes.Split(';').Contains("add");
		}

		private static bool GetMiniPageAddModeSysSetting(UserConnection userConnection, string entityName) {
			string sysSettingCode = string.Format(MiniPageAddModeCode, entityName);
			return CoreSysSettings.GetValue(userConnection, sysSettingCode, false);
		}

		private static Guid GetWorkplaceId(UserConnection userConnection) {
			Guid? cachedValue = GetWorkplaceCashedValue(userConnection);
			if (cachedValue.HasValue) {
				return cachedValue.Value;
			}
			Guid workplaceId = Guid.Empty;
			var workplaceSelect = (Select)new Select(userConnection).Top(1)
					.Column("Id")
					.Column("Position")
				.From("SysWorkplace")
				.Where().Exists(
					new Select(userConnection)
						.Column(Column.Const(1))
					.From("SysAdminUnitInWorkplace")
					.Where().Exists(
						new Select(userConnection)
							.Column(Column.Const(1))
						.From("SysAdminUnitInRole")
						.Where("SysAdminUnitInRole", "SysAdminUnitId")
							.IsEqual(Column.Parameter(userConnection.CurrentUser.Id))
								.And("SysAdminUnitInRole", "SysAdminUnitRoleId")
							.IsEqual("SysAdminUnitInWorkplace", "SysAdminUnitId"))
					.And("SysWorkplace", "Id")
						.IsEqual("SysAdminUnitInWorkplace", "SysWorkplaceId")
				)
				.OrderByAsc("Position");
			workplaceSelect.ExecuteReader(dataReader => {
				workplaceId = dataReader.GetColumnValue<Guid>("Id");
			});
			return workplaceId;
		}

		private static string GetLczColumnValue(bool useMultiLanguageData, IDataReader dataReader, string columnName) {
			string value = dataReader.GetColumnValue<string>(columnName);
			if (!useMultiLanguageData) {
				return value;
			}
			columnName += "Lcz";
			string lczValue = dataReader.GetColumnValue<string>(columnName);
			return !string.IsNullOrEmpty(lczValue) ? lczValue : value;
		}

		private static ICacheStore GetLocalCache(UserConnection userConnection) {
			return userConnection.SessionCache.WithLocalCaching(LocalCacheGroupName);
		}

		private static string GetSessionCacheKey(UserConnection userConnection, string keyTemplate) {
			return string.Format(keyTemplate, userConnection.CurrentUser.Culture.Name,
				userConnection.SessionId);
		}

		private static void RemoveNewLine(StringBuilder sb) {
			sb.Length -= Environment.NewLine.Length;
		}

		private IEnumerable<Func<UserConnection, string>> GetScriptFunctions(bool skipFeaturesScript) {
			yield return GetLessConstantsScript;
			yield return GetSysSettingsHashScript;
			yield return GetValidUserTasksByDefault;
			if (!skipFeaturesScript) {
				yield return GetPreloadedFeatures;
			}
			yield return GetGoogleTagManagerScript;
			yield return GetDefaultIntroPageNameScript;
			yield return GetCustomConfigurationScript;
		}

		private string GetConfigScript(UserConnection userConnection, bool skipFeaturesScript) {
			Dictionary<string, string> config = GetConfigurationStructuresScripts(userConnection);
			var sb = new StringBuilder();
			foreach (KeyValuePair<string, string> configProperty in config) {
				sb.Append("Terrasoft.configuration.");
				sb.Append(configProperty.Key);
				sb.Append("=");
				sb.Append(configProperty.Value);
				sb.Append(";");
				sb.AppendLine();
			}
			AppendRequestsCachingOptions(sb);
			AppendMinSearchCharsCountSetting(sb);
			if (GlobalAppSettings.FeatureUseViewModuleCaching) {
				return GetScriptToConfigure(userConnection, sb, skipFeaturesScript);
			}
			RemoveNewLine(sb);
			return sb.ToString();
		}

		private string GetScriptToConfigure(UserConnection userConnection, StringBuilder sb, bool skipFeaturesScript) {
			foreach (Func<UserConnection, string> scriptFunction in GetScriptFunctions(skipFeaturesScript)) {
				string value = scriptFunction(userConnection);
				if (!string.IsNullOrWhiteSpace(value)) {
					sb.AppendLine(value);
				}
			}
			RemoveNewLine(sb);
			return sb.ToString();
		}

		private string GetScriptToConfigure(UserConnection userConnection, bool skipFeaturesScript) {
			var sb = new StringBuilder();
			return GetScriptToConfigure(userConnection, sb, skipFeaturesScript);
		}

		private IEnumerable<string> GetConfigurationScripts(UserConnection userConnection) {
			bool useFeatureService = GlobalAppSettings.UseFeatureService;
			bool useViewModuleCaching = GlobalAppSettings.FeatureUseViewModuleCaching;
			yield return GetClientUnitSchemaDescriptorsScript(userConnection);
			yield return GetCachedScript(userConnection, useFeatureService);
			if (useViewModuleCaching) {
				if (useFeatureService) {
					yield return GetPreloadedFeatures(userConnection);
				}
			} else {
				yield return GetScriptToConfigure(userConnection, false);
			}
			yield return GetIsFirstLoginScript();
			yield return GetEnableSanitizeHtmlScript(userConnection);
		}

		private string GetCachedScript(UserConnection userConnection, bool skipFeaturesScript) {
			ICacheStore localCache = GetLocalCache(userConnection);
			string key = GetSessionCacheKey(userConnection, 
				UseShellConfigurationScript ? ShellConfigurationScriptCacheKeyTemplate : ConfigurationScriptCacheKeyTemplate);
			string cachedScript = (string)localCache[key];
			if (cachedScript.IsNullOrEmpty()) {
				cachedScript = GetConfigScript(userConnection, skipFeaturesScript);
				localCache[key] = cachedScript;
			}
			return cachedScript;
		}

		private Select GetModuleStructureSelect() {
			if (_moduleStructureSelect == null) {
				InitializeModuleStructureSelect();
			}
			return _moduleStructureSelect;
		}

		private void InitializeModuleStructureSelectJoins(Guid workplaceId, Guid? cultureId) {
			string sysModuleLczSchemaName = GetLczSchemaName("SysModule");
			string sysModuleEditLczSchemaName = GetLczSchemaName("SysModuleEdit");
			if (cultureId.HasValue) {
				_moduleStructureSelect
					.Column("SysModule", "Caption").As("ModuleCaption")
					.Column("SysModule", "ModuleHeader").As("ModuleHeader")
					.Column("SysModuleEdit", "ActionKindCaption").As("ActionCaption")
					.Column("SysModuleEdit", "PageCaption").As("PageCaption")
					.Column(sysModuleLczSchemaName, "Caption").As("ModuleCaptionLcz")
					.Column(sysModuleLczSchemaName, "ModuleHeader").As("ModuleHeaderLcz")
					.Column(sysModuleEditLczSchemaName, "ActionKindCaption").As("ActionCaptionLcz")
					.Column(sysModuleEditLczSchemaName, "PageCaption").As("PageCaptionLcz");
			}
			_moduleStructureSelect.From("SysModule");
			bool isWorkplaceIdNotEmpty = workplaceId.IsNotEmpty();
			if (isWorkplaceIdNotEmpty) {
				_moduleStructureSelect.LeftOuterJoin("SysModuleInWorkplace")
					.On("SysModuleInWorkplace", "SysModuleId").IsEqual("SysModule", "Id")
					.And("SysModuleInWorkplace", "SysWorkplaceId").IsEqual(Column.Parameter(workplaceId));
			} else {
				_moduleStructureSelect.LeftOuterJoin("SysModuleInSysModuleFolder")
					.On("SysModuleInSysModuleFolder", "SysModuleId").IsEqual("SysModule", "Id");
			}
			_moduleStructureSelect.LeftOuterJoin("SysModuleEdit")
					.On("SysModuleEdit", "SysModuleEntityId").IsEqual("SysModule", "SysModuleEntityId")
				.LeftOuterJoin("SysModuleEntity")
					.On("SysModuleEntity", "Id").IsEqual("SysModule", "SysModuleEntityId");
			_moduleStructureSelect.LeftOuterJoin("SysModuleVisa")
				.On("SysModuleVisa", "Id").IsEqual("SysModule", "SysModuleVisaId");
			if (cultureId.HasValue) {
				_moduleStructureSelect
					.LeftOuterJoin(sysModuleLczSchemaName)
						.On(sysModuleLczSchemaName, "RecordId").IsEqual("SysModule", "Id")
						.And(sysModuleLczSchemaName, "SysCultureId").IsEqual(Column.Parameter(cultureId))
					.LeftOuterJoin(sysModuleEditLczSchemaName)
						.On(sysModuleEditLczSchemaName, "RecordId").IsEqual(
							isWorkplaceIdNotEmpty ? "SysModuleEdit" : "SysModule", "Id")
						.And(sysModuleEditLczSchemaName, "SysCultureId").IsEqual(Column.Parameter(cultureId));
			}
			if (isWorkplaceIdNotEmpty) {
				_moduleStructureSelect.Where("SysModule", "SectionModuleSchemaUId").Not().IsNull()
					.OrderBy(OrderDirectionStrict.Ascending, "SysModuleInWorkplace", "Position")
					.OrderBy(OrderDirectionStrict.Ascending, "SysModuleEdit", "Position");
			} else {
				var rootSysModuleFolderId = new Guid("F330F0C2-3EE4-4A73-9AC9-8439543CA19B");
				_moduleStructureSelect.Where("SysModuleInSysModuleFolder", "SysModuleFolderId")
						.IsEqual(new QueryParameter("SysModuleFolderId", rootSysModuleFolderId, GuidTypeName))
					.OrderBy(OrderDirectionStrict.Ascending, "SysModuleInSysModuleFolder", "Position")
					.OrderBy(OrderDirectionStrict.Ascending, "SysModuleEdit", "Position");
			}
		}

		private string GetLczSchemaName(string schemaName) {
			return GetLczSchemaName(schemaName, _userConnection);
		}

		private void AppendRequestsCachingOptions(StringBuilder sb) {
			sb.AppendLine("Terrasoft.RequestsCachingSettings={};");
			AppendValueFromSysSettings(sb, "RequestsCachingTtl", "Terrasoft.RequestsCachingSettings.ttl");
			AppendValueFromSysSettings(sb, "RequestsCachingOptions", "Terrasoft.RequestsCachingSettings.options");
		}

		private void AppendValueFromSysSettings(StringBuilder sb, string settingsCode, string propPath) {
			if (!CoreSysSettings.TryGetValue(_userConnection, settingsCode, out object propValue)) {
				return;
			}
			bool isOptionsEmpty = string.IsNullOrWhiteSpace(propValue?.ToString());
			if (!isOptionsEmpty) {
				sb.AppendFormat("{0}={1};{2}", propPath, Json.Serialize(propValue), Environment.NewLine);
			}
		}

		private void AppendMinSearchCharsCountSetting(StringBuilder sb) {
			if (CoreSysSettings.TryGetValue(_userConnection, "StringColumnSearchMinCharCount", out object value)) {
				sb.AppendFormat("Terrasoft.ControlsSettings={{lookupMinSearchCharsCount:{0}}};{1}", value,
					Environment.NewLine);
			}
		}

		private string GetIsFirstLoginScript() {
			HttpContext httpContext = _httpContextAccessor.GetInstance();
			object sessionParameter = httpContext.Session[IsFirstLoginKey];
			string isFirstLogin = bool.FalseString.ToLower();
			if (sessionParameter == null) {
				httpContext.Session[IsFirstLoginKey] = false;
				isFirstLogin = bool.TrueString.ToLower();
			}
			return $"Terrasoft.isFirstLogin={isFirstLogin};";
		}

		private Select GetClientUnitSchemaNameSelect(string sourceAlias, string sourceColumnAlias) {
			var clientUnitSchemaNameSelect = (Select)new Select(SystemUserConnection)
					.Column("Name")
				.From("SysSchema")
				.Where("ManagerName")
					.IsEqual(Column.Parameter(_userConnection.ClientUnitSchemaManager.Name))
					.And("UId").IsEqual(sourceAlias, sourceColumnAlias);
			return clientUnitSchemaNameSelect;
		}

		private string GetClientUnitSchemaDescriptorsScript(UserConnection userConnection) {
			string descriptors = GlobalAppSettings.UseStaticFileContent ? "{}" :
				GetClientUnitSchemaDescriptors(userConnection);
			return $"Terrasoft.configuration.{RootSchemaDescriptors}={descriptors};";
		}


		private IEnumerable<ISectionStructureBuilder> GetCustomSelectConditions() {
			return ClassFactory.GetAll<ISectionStructureBuilder>(_userConnection.CurrentUser.ConnectionType.ToString());
		}

		private void ApplyCustomSelectConditions(string schemaName, Select select) {
			foreach (ISectionStructureBuilder customSelectCondition in GetCustomSelectConditions()) {
				customSelectCondition.ApplyCustomConditions(schemaName, select);
			}
		}

		private IEnumerable<ICustomConfigurationScriptBuilder> GetCustomConfigurationScriptBuilders() {
			IEnumerable<ICustomConfigurationScriptBuilder> scriptBuilders =
				ClassFactory.GetAll<ICustomConfigurationScriptBuilder>();
			return scriptBuilders.ToList();
		}

		private string GetCustomConfigurationScript(UserConnection userConnection) {
			return string.Join(Environment.NewLine,
				GetCustomConfigurationScriptBuilders().AsParallel().Select(s => s.BuildScript(userConnection))) +
				Environment.NewLine;
		}

		private void InitializeModuleStructureSelect() {
			Select sectionModuleSelect = GetClientUnitSchemaNameSelect("SysModule", "SectionModuleSchemaUId");
			Select sectionSchemaSelect = GetClientUnitSchemaNameSelect("SysModule", "SectionSchemaUId");
			Select cardModuleSelect = GetClientUnitSchemaNameSelect("SysModule", "CardModuleUId");
			Select cardSchemaSelect = GetClientUnitSchemaNameSelect("SysModule", "CardSchemaUId");
			Select cardSchemaPageSelect = GetClientUnitSchemaNameSelect("SysModuleEdit", "CardSchemaUId");
			Select miniPageSchemaSelect = GetClientUnitSchemaNameSelect("SysModuleEdit", "MiniPageSchemaUId");
			_moduleStructureSelect = new Select(SystemUserConnection)
				.Column("SysModule", "Id").As("ModuleId")
				.Column("SysModule", "Image32Id").As("ImageId")
				.Column("SysModule", "LogoId").As("LogoId")
				.Column("SysModule", "Code").As("Module")
				.Column(sectionModuleSelect).As("SectionModule")
				.Column(sectionSchemaSelect).As("SectionSchema")
				.Column(cardModuleSelect).As("CardModule")
				.Column(cardSchemaSelect).As("CardSchema")
				.Column("SysModule", "Attribute").As("Attribute")
				.Column("SysModule", "TypeColumnValue").As("ModuleTypeColumnValue")
				.Column(cardSchemaPageSelect).As("CardSchemaPage")
				.Column(miniPageSchemaSelect).As("MiniPageSchema")
				.Column("SysModuleEdit", "Id").As("ModuleEditId")
				.Column("SysModuleEdit", "ActionKindName").As("ActionName")
				.Column("SysModuleEdit", "TypeColumnValue").As("TypeColumnValue")
				.Column("SysModuleEntity", "SysEntitySchemaUId").As("SysEntitySchemaUId")
				.Column("SysModuleVisa", "VisaSchemaUId").As("VisaSchemaUId");
			Guid workplaceId = GetWorkplaceId(_userConnection);
			if (workplaceId.IsNotEmpty()) {
				_moduleStructureSelect.Column("SysModuleInWorkplace", "SysWorkplaceId").As("ShowInWorkplace");
			} else {
				_moduleStructureSelect.Column(Column.Const(string.Empty)).As("ShowInWorkplace");
			}
			bool useMultiLanguageData = !_userConnection.GetIsFeatureEnabled(DoNotUseMultiLanguageData);
			Guid cultureId = _userConnection.CurrentUser.SysCultureId;
			InitializeModuleStructureSelectJoins(workplaceId, useMultiLanguageData ? (Guid?)cultureId : null);
			AddEntityNamesCondition(null, _moduleStructureSelect);
			ApplyCustomSelectConditions("SysModule", _moduleStructureSelect);
			if (!useMultiLanguageData) {
				string cultureName = _userConnection.CurrentUser.SysCultureName;
				CommonUtilities.AddLczColumn(SystemUserConnection, cultureId, cultureName, _moduleStructureSelect,
					"SysModule", "SysModule", "Id", "Caption", false, "ModuleCaption", "SysModuleLcz_ModuleCaption");
				CommonUtilities.AddLczColumn(SystemUserConnection, cultureId, cultureName, _moduleStructureSelect,
					"SysModule", "SysModule", "Id", "ModuleHeader", false, "ModuleHeader", "SysModuleLcz_ModuleHeader");
				CommonUtilities.AddLczColumn(SystemUserConnection, cultureId, cultureName, _moduleStructureSelect,
					"SysModuleEdit", "SysModuleEdit", "Id", "ActionKindCaption", false, "ActionCaption",
					"SysModuleEditLcz_ActionCaption");
				CommonUtilities.AddLczColumn(SystemUserConnection, cultureId, cultureName, _moduleStructureSelect,
					"SysModuleEdit", "SysModuleEdit", "Id", "PageCaption", false, "PageCaption",
					"SysModuleEditLcz_PageCaption");
			}
			_moduleStructureSelect.InitializeParameters();
		}

		private string FixGuidForOracle(string uid) {
			return string.IsNullOrEmpty(uid) ? string.Empty : uid.ToLower().Replace("{", "").Replace("}", "");
		}

		private Select GetPortalSchemaAccessSelect() {
			return
				(Select)new Select(SystemUserConnection)
					.Column("PortalSchemaAccessList", "AccessEntitySchemaName")
					.Column("PortalSchemaAccessList", "SchemaUId")
					.Column("PortalColumnAccessList", "ColumnUId")
				.From("PortalSchemaAccessList")
				.LeftOuterJoin("PortalColumnAccessList")
					.On("PortalColumnAccessList", "PortalSchemaListId").IsEqual("PortalSchemaAccessList", "Id")
				.Where("PortalSchemaAccessList", "SchemaUId").Not().IsNull()
				.OrderByAsc("AccessEntitySchemaName");
		}

		private string BuildEntitiesStructureString(Dictionary<Guid, EntityStructure> entitiesStructure) {
			var entityStructureSb = new StringBuilder("{");
			foreach (KeyValuePair<Guid, EntityStructure> entityStructure in entitiesStructure) {
				EntityStructure structure = entityStructure.Value;
				entityStructureSb.Append(structure.EntityName);
				AppendEntityStructureObject(entityStructureSb, structure);
				if (structure is OverridingEntityStructure overridingStructure) {
					entityStructureSb.Append("\"");
					entityStructureSb.Append(overridingStructure.OverridenEntityStructure.EntitySchemaUId);
					entityStructureSb.Append("\"");
					AppendEntityStructureObject(entityStructureSb, overridingStructure.OverridenEntityStructure);
				}
			}
			if (entityStructureSb.Length > 2) {
				entityStructureSb = entityStructureSb.Remove(entityStructureSb.Length - 1, 1);
			}
			entityStructureSb.Append("}");
			return entityStructureSb.ToString();
		}

		private bool GetIsUserPage(PageStructure pageStructure) {
			if (pageStructure.Role != null && pageStructure.Role != Guid.Empty) {
				Guid currentRole = _userConnection.CurrentUser.ConnectionType == UserType.SSP ? BaseConsts.PortalUsersSysAdminUnitUId : BaseConsts.AllEmployersSysAdminUnitUId;
				return pageStructure.Role == currentRole;
			}
			return true;
		}

		private void AppendEntityStructureObject(StringBuilder entityStructureSb, EntityStructure structure) {
			entityStructureSb.Append(":{");
			if (!string.IsNullOrEmpty(structure.Attribute)) {
				entityStructureSb.Append($"attribute:{Json.Serialize(structure.Attribute)},");
			}
			entityStructureSb.Append($"entitySchemaName:{Json.Serialize(structure.EntityName)},");
			entityStructureSb.Append($"entitySchemaUId:{Json.Serialize(structure.EntitySchemaUId)},");
			entityStructureSb.Append($"searchRowSchema:{Json.Serialize(structure.SearchRowSchema)},");
			entityStructureSb.Append($"cardModuleName:{Json.Serialize(structure.CardModuleName)},");
			entityStructureSb.Append($"primary:{Json.Serialize(structure.Primary)},");
			entityStructureSb.Append($"page8X:{Json.Serialize(structure.Page8X)}");
			if (structure.PagesStructure != null) {
				entityStructureSb.Append(",pages:[");
				foreach (PageStructure pageStructure in structure.PagesStructure) {
					entityStructureSb.Append("{");
					entityStructureSb.Append($"cardSchema:{Json.Serialize(pageStructure.CardSchema)}");
					entityStructureSb.Append($",cardSchemaUId:{Json.Serialize(pageStructure.CardSchemaUId)}");
					if (!string.IsNullOrEmpty(pageStructure.MiniPageSchema)) {
						entityStructureSb.Append($",miniPageSchema:{Json.Serialize(pageStructure.MiniPageSchema)}");
						entityStructureSb.Append($",miniPageModes:{Json.Serialize(pageStructure.MiniPageModes)}");
						bool hasAddMiniPage = HasSchemaEditAddMiniPage(_userConnection, structure.EntityName,
							pageStructure.MiniPageModes);
						if (hasAddMiniPage) {
							entityStructureSb.Append(",hasAddMiniPage:true");
						}
					}
					entityStructureSb.Append($",UId:{Json.Serialize(pageStructure.UId)}");
					entityStructureSb.Append($",caption:{Json.Serialize(pageStructure.Caption)}");
					entityStructureSb.Append($",captionLcz:{Json.Serialize(pageStructure.CaptionLcz)}");
					if (!string.IsNullOrEmpty(structure.Attribute)) {
						entityStructureSb.Append($",typeColumnName:{Json.Serialize(structure.Attribute)}");
					}
					entityStructureSb.Append($",moduleEditId:{Json.Serialize(pageStructure.ModuleEditId)}");
					entityStructureSb.Append($",schemaType:{Json.Serialize(pageStructure.ClientUnitSchemaType)}");
					entityStructureSb.Append($",schemaGroup:{Json.Serialize(pageStructure.SchemaGroup)}");
					if (pageStructure.Actions != null) {
						entityStructureSb.Append($",actions:{pageStructure.Actions}");
					}
					if (pageStructure.IsDefault) {
						entityStructureSb.Append($",isDefault:{Json.Serialize(pageStructure.IsDefault)}");
					}
					if (pageStructure.Role != null) {
						entityStructureSb.Append($",role:{Json.Serialize(pageStructure.Role)}");
					}
					if (pageStructure.CardModuleName != null) {
						entityStructureSb.Append($",cardModuleName:{Json.Serialize(pageStructure.CardModuleName)}");
					}
					entityStructureSb.Append("},");
				}
				if (structure.PagesStructure.Count > 0) {
					entityStructureSb = entityStructureSb.Remove(entityStructureSb.Length - 1, 1);
				}
				entityStructureSb.Append("]");
			}
			entityStructureSb.Append("},");
		}

		private string BuildModulesStructureString(Dictionary<string, ModuleStructure> modulesStructure) {
			string scriptContent = string.Join(",", modulesStructure.Values.OrderBy(m => m.Primary).Select(
				m => {
					string moduleStructureString = m.ToString();
					moduleStructureString = ModifyModuleStructureString(m, moduleStructureString);
					return moduleStructureString;
				}));
			return "{" + scriptContent + "}";
		}

		private void AddItemDescriptors<T>(StringBuilder descriptorsStringBuilder,
				IEnumerable<ISchemaManagerItem<T>> schemaManagerItems)
				where T : Schema, ISchemaManagerSchema<T> {
			foreach (ISchemaManagerItem<T> item in schemaManagerItems) {
				string descriptor = _clientUnitSchemaDecorator.GetSchemaDescriptor(item);
				if ((GlobalAppSettings.UseStaticFileContent && !string.IsNullOrEmpty(descriptor)) ||
						!GlobalAppSettings.UseStaticFileContent) {
					descriptorsStringBuilder.AppendFormat("{0}:{1},", item.Name, descriptor).AppendLine();
				}
			}
		}

		private bool GetAccessFromSspLicense(UserConnection userConnection, string moduleName) {
			return userConnection.CurrentUser.ConnectionType != UserType.SSP ||
				userConnection.DBSecurityEngine.GetIsAvailableOnSsp(moduleName);
		}

		private string GetEnableSanitizeHtmlScript(UserConnection userConnection) {
			bool featureState = userConnection.GetIsFeatureEnabled("SanitizeHtml");
			return $"Terrasoft.enableSanitizeHtml = {featureState.ToString().ToLower()};";
		}

		private Dictionary<Guid, EntityStructure> InnerGetEntitiesStructure(UserConnection userConnection) {
			bool useMultiLanguageData = !_userConnection.GetIsFeatureEnabled(DoNotUseMultiLanguageData);
			EntitySchemaManager entitySchemaManager = userConnection.EntitySchemaManager;
			Guid cultureId = _userConnection.CurrentUser.SysCultureId;
			string cultureName = _userConnection.CurrentUser.SysCultureName;
			Select cardSchemaPageSelect = GetClientUnitSchemaNameSelect("SysModuleEdit", "CardSchemaUId");
			Select miniPageSchemaSelect = GetClientUnitSchemaNameSelect("SysModuleEdit", "MiniPageSchemaUId");
			Select searchRowSchemaSelect = GetClientUnitSchemaNameSelect("SysModuleEdit", "SearchRowSchemaUId");
			var entityEditPageSelect = new Select(SystemUserConnection)
				.Column("SysModuleEdit", "ActionKindName").As("ActionName")
				.Column("SysModuleEdit", "TypeColumnValue").As("TypeColumnValue")
				.Column("SysModuleEdit", "CardSchemaUId").As("CardSchemaUId")
				.Column("SysModuleEdit", "MiniPageSchemaUId").As("MiniPageSchemaUId")
				.Column("SysModuleEdit", "MiniPageModes").As("MiniPageModes")
				.Column("SysModuleEdit", "Id").As("SysModuleEditId")
				.Column("SysModuleEntity", "SysEntitySchemaUId").As("SysEntitySchemaUId")
				.Column("SysModuleEntity", "TypeColumnUId").As("TypeColumnUId")
				.Column("SysModuleEntity", "Id").As("SysModuleEntityId")
				.Column(cardSchemaPageSelect).As("CardSchemaPage")
				.Column(searchRowSchemaSelect).As("SearchRowSchema")
				.Column(miniPageSchemaSelect).As("MiniPageSchema")
				.Column("CardModuleSchema", "Name").As("CardModuleName");
			if (!useMultiLanguageData) {
				CommonUtilities.AddLczColumn(_userConnection, cultureId, cultureName, entityEditPageSelect,
					"SysModuleEdit", "SysModuleEdit", "Id", "ActionKindCaption", false, "ActionCaption",
					"SysModuleEditLcz_ActionCaption");
				CommonUtilities.AddLczColumn(_userConnection, cultureId, cultureName, entityEditPageSelect,
					"SysModuleEdit", "SysModuleEdit", "Id", "PageCaption", false, "PageCaption",
					"SysModuleEditLcz_PageCaption");
			} else {
				string sysModuleEditLczName = GetLczSchemaName("SysModuleEdit", userConnection);
				entityEditPageSelect
					.Column("SysModuleEdit", "ActionKindCaption").As("ActionCaption")
					.Column("SysModuleEdit", "PageCaption").As("PageCaption")
					.Column(sysModuleEditLczName, "ActionKindCaption").As("ActionCaptionLcz")
					.Column(sysModuleEditLczName, "PageCaption").As("PageCaptionLcz")
					.LeftOuterJoin(sysModuleEditLczName)
						.On(sysModuleEditLczName, "RecordId").IsEqual("SysModuleEdit", "Id")
						.And(sysModuleEditLczName, "SysCultureId").IsEqual(Column.Parameter(cultureId));
			}
			entityEditPageSelect
				.From("SysModuleEdit")
				.Join(JoinType.Inner, "SysModuleEntity")
					.On("SysModuleEntity", "Id").IsEqual("SysModuleEdit", "SysModuleEntityId")
				.LeftOuterJoin("SysModule")
					.On("SysModule", "SysModuleEntityId").IsEqual("SysModuleEntity", "Id")
				.LeftOuterJoin("SysSchema").As("CardModuleSchema")
					.On("CardModuleSchema", "UId").IsEqual("SysModule", "CardModuleUId");
			AddEntityNamesCondition(null, entityEditPageSelect);
			entityEditPageSelect.OrderBy(OrderDirectionStrict.Ascending, "SysModuleEdit", "Position");
			ApplyCustomSelectConditions("SysModuleEdit", entityEditPageSelect);
			entityEditPageSelect.InitializeParameters();
			var entitiesStructure = new Dictionary<Guid, EntityStructure>();
			using (DBExecutor dbExecutor = _userConnection.EnsureDBConnection()) {
				using (IDataReader dataReader = entityEditPageSelect.ExecuteReader(dbExecutor)) {
					while (dataReader.Read()) {
						string cardSchemaPage = dataReader.GetColumnValue<string>("CardSchemaPage");
						if (string.IsNullOrEmpty(cardSchemaPage)) {
							continue;
						}
						Guid sysEntitySchemaUId = dataReader.GetColumnValue<Guid>("SysEntitySchemaUId");
						if (!entitiesStructure.TryGetValue(sysEntitySchemaUId, out EntityStructure entityStructure)) {
							ISchemaManagerItem<EntitySchema> item =
								entitySchemaManager.FindItemByUId(sysEntitySchemaUId);
							if (item == null) {
								continue;
							}
							entityStructure = new EntityStructure {
								EntityName = item.Name,
								SearchRowSchema = dataReader.GetColumnValue<string>("SearchRowSchema"),
								EntitySchemaUId = sysEntitySchemaUId.ToString(),
								CardModuleName = dataReader.GetColumnValue<string>("CardModuleName"),
								Page8X = false,
								PagesStructure = new List<PageStructure>()
							};
							Guid columnUId = dataReader.GetColumnValue<Guid>("TypeColumnUId");
							if (columnUId.IsNotEmpty()) {
								EntitySchema entitySchema;
								try {
									entitySchema = entitySchemaManager.GetInstanceByUId(sysEntitySchemaUId);
								} catch (Exception) {
									continue;
								}
								EntitySchemaColumn column = entitySchema.Columns.FindByUId(columnUId);
								if (column != null) {
									entityStructure.Attribute = column.Name;
								}
							}
							entitiesStructure.Add(sysEntitySchemaUId, entityStructure);
						}
						string sysModuleEditId = FixGuidForOracle(dataReader.GetColumnValue<string>("SysModuleEditId"));
						if (entityStructure.PagesStructure.Any(p => p.ModuleEditId == sysModuleEditId)) {
							continue;
						}
						Guid cardSchemaUId = dataReader.GetColumnValue<Guid>("CardSchemaUId");
						ClientUnitSchemaType schemaType = GetClientUnitSchemaType(userConnection, cardSchemaUId);
						var miniPageModes = dataReader.GetColumnValue<string>("MiniPageModes");
						var pageStructure = new PageStructure {
							Caption = GetLczColumnValue(useMultiLanguageData, dataReader, "ActionCaption"),
							CaptionLcz = GetLczColumnValue(useMultiLanguageData, dataReader, "PageCaption"),
							Name = dataReader.GetColumnValue<string>("ActionName"),
							UId = FixGuidForOracle(dataReader.GetColumnValue<string>("TypeColumnValue")),
							CardSchema = dataReader.GetColumnValue<string>("CardSchemaPage"),
							CardSchemaUId = FixGuidForOracle(cardSchemaUId.ToString()),
							MiniPageSchema = dataReader.GetColumnValue<string>("MiniPageSchema"),
							MiniPageModes = miniPageModes,
							ModuleEditId = sysModuleEditId,
							ClientUnitSchemaType = schemaType,
							IsDefault = true,
							HasAddMiniPage = HasSchemaEditAddMiniPage(_userConnection, entityStructure.EntityName, miniPageModes)
						};
						entityStructure.PagesStructure.Add(pageStructure);
					}
				}
			}
			_configurationDataRelatedPagesApplier.ApplyRelatedPagesToEntityStructure(entitiesStructure);
			entitiesStructure.ForEach(entityStructure => FilterPagesInEntityStructure(entityStructure.Value));
			return entitiesStructure;
		}

		private Dictionary<string, ModuleStructure> InnerGetModulesStructure(UserConnection userConnection) {
			_userConnection = userConnection;
			bool isExternal = userConnection is SSPUserConnection;
			bool useMultiLanguageData = !_userConnection.GetIsFeatureEnabled(DoNotUseMultiLanguageData);
			bool useFixGuidForOracle = _userConnection.GetIsFeatureEnabled("ReplaceOracleGuid");
			bool useGetTypedColumnToModuleStructureFromAddon = !_userConnection.GetIsFeatureEnabled(DisableGetTypedColumnToModuleStructureFromAddon);
			EntitySchemaManager entitySchemaManager = userConnection.EntitySchemaManager;
			var modulesStructure = new Dictionary<string, ModuleStructure>();
			using (DBExecutor dbExecutor = _userConnection.EnsureDBConnection()) {
				using (IDataReader dataReader = GetModuleStructureSelect().ExecuteReader(dbExecutor)) {
					while (dataReader.Read()) {
						var moduleName = dataReader.GetColumnValue<string>("Module");
						var moduleId = dataReader.GetColumnValue<Guid>("ModuleId").ToString();
						if (!GetAccessFromSspLicense(userConnection, moduleName)) {
							continue;
						}
						if (!modulesStructure.TryGetValue(moduleId, out ModuleStructure moduleStructure)) {
							var imageId = dataReader.GetColumnValue<string>("ImageId");
							var logoId = dataReader.GetColumnValue<string>("LogoId");
							var entitySchemaUId = dataReader.GetColumnValue<string>("SysEntitySchemaUId");
							if (entitySchemaUId.IsNullOrEmpty()) {
								continue;
							}
							string entitySchemaName = entitySchemaManager.FindItemByUId(new Guid(entitySchemaUId))?.Name;
							if (useFixGuidForOracle) {
								entitySchemaUId = FixGuidForOracle(entitySchemaUId);
							}
							string sectionModule = dataReader.GetColumnValue<string>("SectionModule");
							bool isSection8X = sectionModule == FreedomUISectionModuleSchemaName;
							if (isExternal && isSection8X &&
								!_configurationDataRelatedPagesApplier.IsEntityHasExternalPages(entitySchemaName)) {
								continue;
							}
							moduleStructure = new ModuleStructure {
								Module = moduleName,
								EntitySchemaUId = entitySchemaUId,
								ModuleId = moduleId,
								EntitySchemaName = entitySchemaName,
								ImageId = useFixGuidForOracle ? FixGuidForOracle(imageId) : imageId,
								LogoId = useFixGuidForOracle ? FixGuidForOracle(logoId) : logoId,
								ModuleCaption = GetLczColumnValue(useMultiLanguageData, dataReader, "ModuleCaption"),
								ModuleHeader = GetLczColumnValue(useMultiLanguageData, dataReader, "ModuleHeader"),
								SectionModule = sectionModule,
								SectionSchema = dataReader.GetColumnValue<string>("SectionSchema"),
								CardModule = dataReader.GetColumnValue<string>("CardModule"),
								CardSchema = dataReader.GetColumnValue<string>("CardSchemaPage"),
								MiniPageSchema = dataReader.GetColumnValue<string>("MiniPageSchema"),
								Attribute = dataReader.GetColumnValue<string>("Attribute"),
								Section8X = isSection8X
							};
							object showInWorkplace = dataReader.GetColumnValue("ShowInWorkplace");
							moduleStructure.Workplace = showInWorkplace?.ToString() ?? "";
							moduleStructure.Hide = "true";
							moduleStructure.TypeColumnValue = dataReader
								.GetColumnValue<string>("ModuleTypeColumnValue");
							moduleStructure.PagesStructure = new List<PageStructure>();
							moduleStructure.VisaSchemaUId = dataReader.GetColumnValue<string>("VisaSchemaUId");
							if (!string.IsNullOrEmpty(moduleStructure.VisaSchemaUId)) {
								var visaSchemaUId = new Guid(moduleStructure.VisaSchemaUId);
								var item = entitySchemaManager.FindItemByUId(visaSchemaUId);
								if (item != null) {
									moduleStructure.VisaSchemaName = item.Name;
								}
							}
							if (!string.IsNullOrEmpty(moduleStructure.Attribute)) {
								PageStructure pageStructure = new PageStructure {
									CaptionLcz = GetLczColumnValue(useMultiLanguageData, dataReader, "PageCaption"),
									Caption = GetLczColumnValue(useMultiLanguageData, dataReader, "ActionCaption"),
									Name = dataReader.GetColumnValue<string>("ActionName"),
									UId = FixGuidForOracle(dataReader.GetColumnValue<string>("TypeColumnValue")),
									CardSchema = dataReader.GetColumnValue<string>("CardSchemaPage"),
									MiniPageSchema = dataReader.GetColumnValue<string>("MiniPageSchema"),
									ModuleEditId = FixGuidForOracle(dataReader.GetColumnValue<string>("ModuleEditId")),
									IsDefault = true,
								};
								moduleStructure.PagesStructure.Add(pageStructure);
							}
							if (isSection8X && useGetTypedColumnToModuleStructureFromAddon) {
								moduleStructure.Attribute = _configurationDataRelatedPagesApplier.GetTypedColumnName(moduleName);
							}
							modulesStructure.Add(moduleId, moduleStructure);
						} else {
							PageStructure pageStructure = new PageStructure {
								CaptionLcz = GetLczColumnValue(useMultiLanguageData, dataReader, "PageCaption"),
								Caption = GetLczColumnValue(useMultiLanguageData, dataReader, "ActionCaption"),
								Name = dataReader.GetColumnValue<string>("ActionName"),
								UId = FixGuidForOracle(dataReader.GetColumnValue<string>("TypeColumnValue")),
								CardSchema = dataReader.GetColumnValue<string>("CardSchemaPage"),
								MiniPageSchema = dataReader.GetColumnValue<string>("MiniPageSchema"),
								ModuleEditId = FixGuidForOracle(dataReader.GetColumnValue<string>("ModuleEditId")),
								IsDefault = true,
							};
							moduleStructure.PagesStructure.Add(pageStructure);
						}
					}
				}
			}
			return GetNormalizeModuleStructure(modulesStructure);
		}

		private Dictionary<string, ModuleStructure> GetNormalizeModuleStructure(
				Dictionary<string, ModuleStructure> sourceModulesStructure) {
			List<string> uniqueModuleCodes = sourceModulesStructure.Values
				.GroupBy(x => x.Module)
				.Where(x => x.Count() == 1)
				.Select(x => x.Key)
				.ToList();
			var usedModuleCodes = new List<string>();
			foreach (ModuleStructure moduleStructure in sourceModulesStructure.Values) {
				bool use7XSectionForEntity =
					_configurationDataRelatedPagesApplier.Use7XSection(moduleStructure.EntitySchemaName);
				bool is7XSection = !moduleStructure.Section8X;
				string moduleCode = moduleStructure.Module;
				bool isPrimarySection = !usedModuleCodes.Contains(moduleCode) &&
					(uniqueModuleCodes.Contains(moduleCode) ||
						(use7XSectionForEntity && is7XSection) ||
						(!use7XSectionForEntity && !is7XSection));
				moduleStructure.ModuleKey = isPrimarySection ? moduleCode : moduleStructure.ModuleId;
				moduleStructure.Primary = isPrimarySection;
				if (isPrimarySection) {
					usedModuleCodes.Add(moduleCode);
				}
			}
			SetPrimaryForSkippedModules(sourceModulesStructure);
			return sourceModulesStructure.Values.ToDictionary(x => x.ModuleKey, x => x);
		}

		private void SetPrimaryForSkippedModules(Dictionary<string, ModuleStructure> sourceModulesStructure) {
			sourceModulesStructure.Values
				.GroupBy(x => x.Module)
				.Where(x => x.All(y => !y.Primary))
				.ForEach(x => {
					ModuleStructure moduleStructure = x.First();
					moduleStructure.Primary = true;
					moduleStructure.ModuleKey = moduleStructure.Module;
				});
		}

		private Dictionary<string, ModuleStructure> GetModulesStructureCached(UserConnection userConnection) {
			return GetCachedValues(userConnection, ModuleStructureCacheKeyTemplate, InnerGetModulesStructure);
		}

		private Dictionary<Guid, EntityStructure> GetEntityStructureCached(UserConnection userConnection) {
			return GetCachedValues(userConnection, EntityStructureCacheKeyTemplate, InnerGetEntitiesStructure);
		}

		//TODO https://creatio.atlassian.net/browse/RND-37733
		private void AddSchemaDescriptors<T>(IEnumerable<ISchemaManagerItem<T>> clientUnitSchemaItems,
			IDictionary<string, string> descriptors)
			where T : Schema, ISchemaManagerSchema<T> {
			foreach (ISchemaManagerItem<T> item in clientUnitSchemaItems) {
				string name = item.Name;
				if (descriptors.ContainsKey(name)) {
					continue;
				}
				string descriptorPath = _clientUnitSchemaDecorator.GetSchemaPathForFileContent(item);
				descriptors.Add(item.Name, descriptorPath);
			}
		}

		private T GetCachedValues<T>(UserConnection userConnection, string keyTemplate, Func<UserConnection, T> factoryMethod)
			where T : class, IEnumerable {
			ICacheStore localCache = GetLocalCache(userConnection);
			string key = GetSessionCacheKey(userConnection, keyTemplate);
			var cached = localCache[key] as T;
			if (!cached.IsNullOrEmpty()) {
				return cached;
			}
			cached = factoryMethod(userConnection);
			localCache[key] = cached;
			return cached;
		}

		//TODO https://creatio.atlassian.net/browse/RND-37733
		private Dictionary<string, string> GetRootSchemaDescriptorsCached(UserConnection userConnection) {
			return GetCachedValues(userConnection, RootSchemaDescriptorsCacheKeyTemplate, InnerGetRootSchemaDescriptors);
		}

		//TODO https://creatio.atlassian.net/browse/RND-37733
		private Dictionary<string, string> InnerGetRootSchemaDescriptors(UserConnection userConnection) {
			var descriptors = new Dictionary<string, string>();
			ClientUnitSchemaManager clientUnitSchemaManager = userConnection.ClientUnitSchemaManager;
			IEnumerable<ISchemaManagerItem<ClientUnitSchema>> clientUnitSchemaItems = clientUnitSchemaManager.GetItems();
			AddSchemaDescriptors(clientUnitSchemaItems, descriptors);
			EntitySchemaManager entitySchemaManager = userConnection.EntitySchemaManager;
			IEnumerable<ISchemaManagerItem<EntitySchema>> entitySchemaItems = entitySchemaManager.GetItems();
			AddSchemaDescriptors(entitySchemaItems, descriptors);
			return descriptors;
		}

		private void FilterPagesInEntityStructure(EntityStructure entityStructure) {
			entityStructure.PagesStructure = entityStructure.PagesStructure.Where(GetIsUserPage).ToList();
		}

		private bool GetNeedAddWorkplaceWithoutModules(IReadOnlyDictionary<Guid, List<string>> modules, Guid workplaceId,
				UserConnection userConnection) {
			return !modules.ContainsKey(workplaceId) && userConnection.CurrentUser.ConnectionType != UserType.SSP;
		}

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Returns workspace select by <paramref name="applicationClientTypeId"/>.
		/// <param name="userConnection">User connection.</param>
		/// <param name="applicationClientTypeId">Application client type id.</param>
		/// </summary>
		/// <returns>Workspace select.</returns>
		protected virtual Select GetWorkspaceSelect(UserConnection userConnection, Guid applicationClientTypeId) {
			if (applicationClientTypeId == Guid.Empty) {
				applicationClientTypeId = BaseConsts.BrowserClientTypeId;
			}
			bool useMultiLanguageData = !userConnection.GetIsFeatureEnabled(DoNotUseMultiLanguageData);
			Select sectionSchemaSelect = GetClientUnitSchemaNameSelect("SysModule", "SectionSchemaUId");
			Select sectionModuleSchemaSelect = GetClientUnitSchemaNameSelect("SysModule", "SectionModuleSchemaUId");
			Select loaderSchemaSelect = GetClientUnitSchemaNameSelect("SysWorkplace", "LoaderId");
			var workplaceSelect = new Select(userConnection)
				.Column("SysWorkplace", "Id")
				.Column("SysWorkplace", "Position")
				.Column("SysWorkplace", "Name");
			workplaceSelect
				.Column("SysWorkplace", "IsPersonal")
				.Column("SysWorkplace", "LoaderId")
				.Column("SysWorkplace", "UseOnlyShell")
				.Column(loaderSchemaSelect).As("LoaderName")
				.Column("SysModuleInWorkplace", "SysModuleId")
				.Column("SysModuleInWorkplace", "Position").As("ModulePosition")
				.Column("SysModule", "Caption").As("SysModuleCaption")
				.Column("SysModule", "Code").As("SysModuleName")
				.Column(sectionSchemaSelect).As("SectionModule")
				.Column(sectionModuleSchemaSelect).As("SectionModuleSchema")
				.From("SysWorkplace")
				.Join(JoinType.LeftOuter, "SysModuleInWorkplace")
					.On("SysModuleInWorkplace", "SysWorkplaceId").IsEqual("SysWorkplace", "Id")
				.Join(JoinType.LeftOuter, "SysModule")
					.On("SysModule", "Id").IsEqual("SysModuleInWorkplace", "SysModuleId");
			workplaceSelect
				.Column("SysSchema", "Name").As("HomePageSchemaName")
				.Column("SysSchemaProperty", "Value").As("HomePageSchemaType")
				.Join(JoinType.LeftOuter, "SysSchema").On("SysSchema", "UId")
					.IsEqual("SysWorkplace", "HomePageUId")
				.Join(JoinType.LeftOuter, "SysSchemaProperty")
					.On("SysSchemaProperty", "SysSchemaId").IsEqual("SysSchema", "Id")
					.And("SysSchemaProperty", "Name").IsEqual(Column.Const("SchemaType"));

			if (useMultiLanguageData) {
				Guid sysCultureId = userConnection.CurrentUser.SysCultureId;
				string sysWorkplaceLczName = GetLczSchemaName("SysWorkplace", userConnection);
				workplaceSelect.Column(sysWorkplaceLczName, "Name").As("NameLcz")
					.LeftOuterJoin(sysWorkplaceLczName)
						.On(sysWorkplaceLczName, "RecordId").IsEqual("SysWorkplace", "Id")
						.And(sysWorkplaceLczName, "SysCultureId").IsEqual(Column.Parameter(sysCultureId));
			}
			workplaceSelect
				.Where().Exists(
					new Select(userConnection)
					.Column(Column.Parameter(1))
					.From("SysAdminUnitInWorkplace")
					.Where().Exists(
						new Select(userConnection)
						.Column(Column.Parameter(1))
						.From("SysAdminUnitInRole")
						.InnerJoin("SysAdminUnit").On("SysAdminUnit", "Id")
							.IsEqual("SysAdminUnitInRole", "SysAdminUnitRoleId")
						.Where("SysAdminUnitInRole", "SysAdminUnitId")
							.IsEqual(Column.Parameter(userConnection.CurrentUser.Id))
						.And("SysAdminUnitInWorkplace", "SysAdminUnitId")
							.IsEqual("SysAdminUnit", "Id") as Select
					)
					.And("SysWorkplace", "Id")
					.IsEqual("SysAdminUnitInWorkplace", "SysWorkplaceId") as Select
				)
				.And("SysWorkplace", "SysApplicationClientTypeId")
					.IsEqual(Column.Parameter(applicationClientTypeId))
				.OrderByAsc("SysWorkplace", "Position")
				.OrderByAsc("SysWorkplace", "Name")
				.OrderByAsc("SysModuleInWorkplace", "Position");
			return workplaceSelect;
		}

		protected virtual string ModifyModuleStructureString(ModuleStructure moduleStructure, string moduleStructureString) {
			return moduleStructureString;
		}

		/// <summary>
		/// Returns true, if current user has rights for <paramref name="sysModuleName"/> module, and module not disabled.
		/// </summary>
		/// <param name="userConnection"><see cref="UserConnection"/> instance.</param>
		/// <param name="sysModuleName">Module name.</param>
		/// <returns> True, if module active and allowed for user.</returns>
		protected virtual bool GetIsModuleAllowed(UserConnection userConnection, string sysModuleName) {
			var securityEngine = userConnection.DBSecurityEngine;
			return securityEngine.GetIsEntitySchemaReadingAllowed(sysModuleName) &&
					!userConnection.GetIsFeatureEnabled("Disable" + sysModuleName) &&
					GetAccessFromSspLicense(userConnection, sysModuleName);
		}

		/// <summary>
		/// Gets Google tag manager script.
		/// </summary>
		/// <param name="userConnection">User connection.</param>
		/// <returns>Google tag manager script.</returns>
		protected string GetGoogleTagManagerScript(UserConnection userConnection) {
			string script = string.Empty;
			bool useGoogleTagManager = CoreSysSettings.GetValue(userConnection, "UseGoogleTagManager", false);
			if (!useGoogleTagManager) {
				return script;
			}
			string googleTagManagerScript = CoreSysSettings.GetValue(userConnection, "GoogleTagManagerScript",
				string.Empty);
			if (googleTagManagerScript.IsNotEmpty()) {
				string gtmScript = googleTagManagerScript.Replace("'", @"""").Replace("/script", @"\/script");
				gtmScript = gtmScript.Replace("&amp;", "&");
				if (_userConnection.GetIsFeatureEnabled("DecodeGoogleTagManagerScript")) {
					string gtmScriptEncoded = HttpUtility.HtmlDecode(gtmScript);
					gtmScript = gtmScriptEncoded.Replace("'", @"\'");
				}
				script = GenerateHeadGoogleTagManagerScript(gtmScript);
			}
			return script;
		}

		private string GenerateHeadGoogleTagManagerScript(string gtmScript) {
			return $"document.head.insertAdjacentHTML(\"afterbegin\", '{gtmScript}');" +
				"eval(document.head.getElementsByTagName(\"script\")[0].innerHTML);";
		}

		/// <summary>
		/// Gets configuration structures scripts.
		/// </summary>
		/// <param name="userConnection">User connection.</param>
		/// <returns>Configuration structures scripts.</returns>
		protected Dictionary<string, string> GetConfigurationStructuresScripts(UserConnection userConnection) {
			_userConnection = userConnection;
			var modulesStructure = GetModulesStructure(userConnection);
			var entitiesStructure = GetEntitiesStructure(userConnection);
			string modulesStructureString = BuildModulesStructureString(modulesStructure);
			string entitiesStructureString = BuildEntitiesStructureString(entitiesStructure);
			string quickAddMenuStructureConfig = GetQuickAddConfig(userConnection);
			string columnsInfoConfig = GetColumnsInfoConfig(userConnection);
			string workplacesStructureConfig = GetWorkplacesConfig(userConnection);
			string portalSchemaAccessConfig = "{}";
			if (userConnection is SSPUserConnection && userConnection.GetIsFeatureEnabled("PortalColumnConfig")) {
				portalSchemaAccessConfig = GetPortalSchemaAccessConfig();
			}
			var result = new Dictionary<string, string> {
				{ "WorkplacesStructure", workplacesStructureConfig },
				{ "Storage", @"{}" },
				{ "QuickAddMenu", quickAddMenuStructureConfig },
				{ "ColumnsInfo", columnsInfoConfig },
				{ "PortalSchemaAccessList", portalSchemaAccessConfig }
			};
			if (modulesStructure.Count > 0) {
				result.Add("ModuleStructure", modulesStructureString);
			}
			if (entitiesStructure.Count > 0) {
				result.Add("EntityStructure", entitiesStructureString);
			}
			return result;
		}

		protected virtual Dictionary<string, ModuleStructure> GetModulesStructure(UserConnection userConnection) {
			return GetModulesStructureCached(userConnection);
		}

		//TODO https://creatio.atlassian.net/browse/RND-37733
		protected Dictionary<string, string> GetRootSchemaDescriptors(UserConnection userConnection) {
			return GetRootSchemaDescriptorsCached(userConnection);
		}

		protected Dictionary<string, ModuleStructure> GetModulesStructure(UserConnection userConnection,
				IEnumerable<string> entityNames) {
			Dictionary<string, ModuleStructure> structure = GetModulesStructureCached(userConnection);
			return entityNames?
				.Distinct()
				.Where(entityName => structure.ContainsKey(entityName))
				.Select(entityName => structure[entityName])
				.ToDictionary(x => x.Module, x => x);
		}

		protected Dictionary<Guid, EntityStructure> GetEntitiesStructure(UserConnection userConnection,
				IEnumerable<string> entityNames) {
			Dictionary<Guid, EntityStructure> structure = GetEntityStructureCached(userConnection);
			return entityNames
				.Distinct()
				.Where(entityName => structure.Count(x => x.Value.EntityName == entityName && x.Value.Primary) > 0)
				.Select(entityName => structure.First(x => x.Value.EntityName == entityName && x.Value.Primary))
				.ToDictionary(x => x.Key, x => x.Value);
		}

		protected virtual Dictionary<Guid, EntityStructure> GetEntitiesStructure(UserConnection userConnection) {
			return GetEntityStructureCached(userConnection);
		}

		protected void AddEntityNamesCondition(IEnumerable<string> entityNames, Select select) {
			if (!entityNames.IsNullOrEmpty()) {
				select.InnerJoin("SysSchema").On("SysSchema", "UId")
					.IsEqual("SysModuleEntity", "SysEntitySchemaUId");
				select.AddCondition("SysSchema", "Name", LogicalOperation.And)
					.In(Column.Parameters(entityNames));
			}
		}

		#endregion

		#region Methods: Public

		public static void ResetWorkplaceCache(UserConnection userConnection) {
			ClearWorkplaceCache(userConnection);
			var workplaceManager = ClassFactory.Get<IWorkplaceManager>(new ConstructorArgument("uc", userConnection));
			workplaceManager.ReloadWorkplaces();
		}

		public static void ClearWorkplaceCache(UserConnection userConnection) {
			string key = GetWorkplaceCacheKey(userConnection);
			userConnection.SessionCache.Remove(key);
		}

		public static void SetWorkplaceCache(UserConnection userConnection, Guid workplaceId) {
			string key = GetWorkplaceCacheKey(userConnection);
			userConnection.SessionCache[key] = workplaceId;
		}

		/// <summary>
		/// Returns workplace config by <paramref name="applicationClientTypeId"/>.
		/// <param name="userConnection"> User connection.</param>
		/// <param name="isScript">Is script mode.</param>
		/// <param name="applicationClientTypeId">Application client type id.</param>
		/// </summary>
		/// <returns>Workplace config.</returns>
		public string GetWorkplacesConfig(UserConnection userConnection, bool isScript = false,
				Guid applicationClientTypeId = default(Guid)) {
			Dictionary<Guid, string> workplaces = new Dictionary<Guid, string>();
			Dictionary<Guid, string> currentUserWorkplaces = new Dictionary<Guid, string>();
			Dictionary<Guid, List<string>> modules = new Dictionary<Guid, List<string>>();
			bool useMultiLanguageData = !userConnection.GetIsFeatureEnabled(DoNotUseMultiLanguageData);
			string tmpl = @"{{Workplaces:[{0}], CurrentUserWorkplaces:[{1}]}}";
			string itemTmpl = "{{workplaceId:'{0}',name:'{1}',position:{2},loaderId:'{3}',loaderName:'{4}',isPersonal:{5}";
			itemTmpl += ",homePageSchemaName:'{6}',homePageSchemaType:'{7}'";
			var modulesItem = @",modules:[{0}]}}";
			var modulesConfig = @"{{moduleId:'{0}',moduleName:'{1}',moduleCaption:{2},position:'{3}',sectionName:'{4}'}}";
			if (isScript) {
				tmpl = @"{{""Workplaces"":[{0}]}}";
				itemTmpl = @"{{""workplaceId"":""{0}"",""name"":""{1}"",""position"":""{2}"",""loaderId"":""{3}"",""loaderName"":""{4}"",""isPersonal"":""{5}""";
				modulesItem = @",""modules"":[{0}]}}";
				modulesConfig = @"{{""moduleId"":""{0}"",""moduleName"":""{1}"",""moduleCaption"":{2},""position"":""{3}"",""sectionName"":""{4}""}}";
				itemTmpl += @",""homePageSchemaName"":""{6}"",""homePageSchemaType"":""{7}""";
			}
			var workplaceSelect = GetWorkspaceSelect(userConnection, applicationClientTypeId);
			_workplaceSectionAccessManager.ClearCache();
			List<AllowedWorkplaceStructureInfo> allowedWorkplaceStructureInfos =
				GetAllowedWorkplaceStructureInfos(userConnection);
			var checkedModules = new Dictionary<string, bool>();
			using (DBExecutor dbExecutor = userConnection.EnsureDBConnection()) {
				using (IDataReader dataReader = workplaceSelect.ExecuteReader(dbExecutor)) {
					while (dataReader.Read()) {
						Guid workplaceId = dataReader.GetColumnValue<Guid>("Id");
						AllowedWorkplaceStructureInfo currentWorkplaceInfo =
							allowedWorkplaceStructureInfos.Find(info => info.Workplace.Id == workplaceId);
						if (currentWorkplaceInfo == null) {
							continue;
						}
						Guid[] currentWorkplaceSectionsIds = currentWorkplaceInfo.AllowedSections
							.Select(section => section.Id).ToArray();
						Guid sysModuleId = dataReader.GetColumnValue<Guid>("SysModuleId");
						bool isModuleAllowedById = currentWorkplaceSectionsIds.Contains(sysModuleId);
						if (isModuleAllowedById) {
							string sysModuleName = dataReader.GetColumnValue<string>("SysModuleName") ?? string.Empty;
							if (!checkedModules.TryGetValue(sysModuleName, out bool isModuleAllowedByName)) {
								isModuleAllowedByName = GetIsModuleAllowed(userConnection, sysModuleName);
								checkedModules.Add(sysModuleName, isModuleAllowedByName);
							}
							if (isModuleAllowedByName) {
								int modulePosition = dataReader.GetColumnValue<int>("ModulePosition");
								string sysModuleCaption =
									Json.Serialize(dataReader.GetColumnValue<string>("SysModuleCaption"));
								string sectionName = dataReader.GetColumnValue<string>("SectionModule");
								string sectionModuleSchemaName =
									dataReader.GetColumnValue<string>("SectionModuleSchema");
								sectionName = string.IsNullOrEmpty(sectionName) &&
									!string.IsNullOrEmpty(sectionModuleSchemaName)
										? sectionModuleSchemaName
										: sectionName;
								if (modules.TryGetValue(workplaceId, out List<string> moduleStrings)) {
									moduleStrings.Add(string.Format(modulesConfig, sysModuleId, sysModuleName,
										sysModuleCaption, modulePosition, sectionName));
								} else {
									modules.Add(workplaceId, new List<string> {
										string.Format(modulesConfig, sysModuleId, sysModuleName, sysModuleCaption,
											modulePosition, sectionName)
									});
								}
							}
						}
						if (!workplaces.ContainsKey(workplaceId)) {
							string workplaceName = dataReader.GetColumnValue<string>("Name");
							string workplaceNameLcz = useMultiLanguageData
								? dataReader.GetColumnValue<string>("NameLcz")
								: string.Empty;
							workplaceName = workplaceNameLcz.IsNullOrEmpty() ? workplaceName : workplaceNameLcz;
							int position = dataReader.GetColumnValue<int>("Position");
							Guid workplaceLoaderId = dataReader.GetColumnValue<Guid>("LoaderId");
							string loaderName = dataReader.GetColumnValue<string>("LoaderName");
							string homePageSchemaName = dataReader.GetColumnValue<string>("HomePageSchemaName");
							string homePageSchemaType = dataReader.GetColumnValue<string>("HomePageSchemaType");
							string isPersonal = dataReader.GetColumnValue<bool>("IsPersonal") ? "true" : "false";
							string workplaceNameValidate = workplaceName.EscapeBackslash().EscapeSingleQuotes();
							if (!currentUserWorkplaces.ContainsKey(workplaceId)) {
								currentUserWorkplaces.Add(workplaceId, string.Format(itemTmpl, workplaceId, workplaceNameValidate,
								position, workplaceLoaderId, loaderName, isPersonal, homePageSchemaName,
								homePageSchemaType));
							}
							if (!dataReader.GetColumnValue<bool>("UseOnlyShell")) {
								workplaces.Add(workplaceId, string.Format(itemTmpl, workplaceId, workplaceNameValidate,
								position, workplaceLoaderId, loaderName, isPersonal, homePageSchemaName,
								homePageSchemaType));
							}
							if (GetNeedAddWorkplaceWithoutModules(modules, workplaceId, userConnection)) {
								modules.Add(workplaceId, new List<string>());
							}
						}
					}
				}
			}
			var itemsStringBuilder = new StringBuilder();
			foreach (KeyValuePair<Guid, string> item in workplaces) {
				if (modules.TryGetValue(item.Key, out List<string> workplaceModules)) {
					itemsStringBuilder.Append(item.Value);
					itemsStringBuilder.AppendFormat(modulesItem, string.Join(",", workplaceModules));
					itemsStringBuilder.Append(",");
				}
			}
			var currentUserWorkplacesStringBuilder = new StringBuilder();
			foreach (KeyValuePair<Guid, string> item in currentUserWorkplaces) {
				if (modules.TryGetValue(item.Key, out List<string> workplaceModules)) {
					currentUserWorkplacesStringBuilder.Append(item.Value);
					currentUserWorkplacesStringBuilder.AppendFormat(modulesItem, string.Join(",", workplaceModules));
					currentUserWorkplacesStringBuilder.Append(",");
				}
			}
			return string.Format(tmpl, itemsStringBuilder.ToString().TrimEnd(','), currentUserWorkplacesStringBuilder.ToString().TrimEnd(','));
		}

		private List<AllowedWorkplaceStructureInfo> GetAllowedWorkplaceStructureInfos(UserConnection userConnection) {
			WorkplacesInfo allowedWorkplacesInfo = _workplaceSectionAccessManager.GetAllowedWorkplaces(
				new AllowedWorkplacesInfoRequest {
					UserId = userConnection.CurrentUser.Id,
					ApplicationClientTypeId = BaseConsts.BrowserClientTypeId
				});
			return allowedWorkplacesInfo?.AllowedWorkplaceStructureInfos == null
				? new List<AllowedWorkplaceStructureInfo>()
				: allowedWorkplacesInfo.AllowedWorkplaceStructureInfos.ToList();
		}

		public virtual string GetColumnsInfoConfig(UserConnection userConnection) {
			var lookupImages = new Dictionary<string, string>();
			string itemTmpl = @"{0}:{{ImageId:'{1}'}}";
			var lookupImagesSelect = new Select(userConnection).Distinct()
					.Column("MultiLookupImage", "Code")
					.Column("MultiLookupImage", "LookupImageId")
				.From("MultiLookupImage");
			using (DBExecutor dbExecutor = userConnection.EnsureDBConnection()) {
				using (IDataReader dataReader = lookupImagesSelect.ExecuteReader(dbExecutor)) {
					while (dataReader.Read()) {
						Guid lookupImageId = dataReader.GetColumnValue<Guid>("LookupImageId");
						string code = dataReader.GetColumnValue<string>("Code");
						lookupImages.Add(code, string.Format(itemTmpl, code, lookupImageId));
					}
				}
			}
			string items = string.Join(",", lookupImages.Select(x => x.Value));
			return "{" + items + "}";
		}

		/// <summary>
		/// Get config of portal schema access restrictions.
		/// </summary>
		/// <returns>JSON string config</returns>
		public virtual string GetPortalSchemaAccessConfig() {
			Select schemaAccessListSelect = GetPortalSchemaAccessSelect();
			string wrapperTpl = "{{{0}\n}}";
			string entityTpl =
				"\n\t{0}:{{\n\t\tuId:\"{1}\",\n\t\tname:\"{0}\",\n\t\texplorerAllowedColumns:[{2}]\n\t}},";
			string fieldTpl = "{{\"uId\":\"{0}\"}},";
			StringBuilder fieldsBuilder = new StringBuilder();
			StringBuilder entityBuilder = new StringBuilder();
			string lastSchemaName = "";
			Guid lastSchemaUId = new Guid();
			using (DBExecutor dbExecutor = SystemUserConnection.EnsureDBConnection()) {
				using (IDataReader dataReader = schemaAccessListSelect.ExecuteReader(dbExecutor)) {
					int dataReaderColumnUIdOrdinal = dataReader.GetOrdinal("ColumnUId");
					while (dataReader.Read()) {
						string currentSchemaName = dataReader
							.GetString(dataReader.GetOrdinal("AccessEntitySchemaName"));
						if (currentSchemaName == lastSchemaName) {
							if (dataReader[dataReaderColumnUIdOrdinal] != DBNull.Value) {
								fieldsBuilder.Append(string.Format(fieldTpl,
									dataReader.GetGuid(dataReaderColumnUIdOrdinal).ToString()));
							}
						} else {
							if (!string.IsNullOrEmpty(lastSchemaName)) {
								entityBuilder.Append(string.Format(entityTpl, lastSchemaName, lastSchemaUId.ToString(),
									fieldsBuilder.ToString().TrimEnd(',')));
								fieldsBuilder.Clear();
							}
							if (dataReader[dataReaderColumnUIdOrdinal] != DBNull.Value) {
								fieldsBuilder.Append(string.Format(fieldTpl,
									dataReader.GetGuid(dataReaderColumnUIdOrdinal).ToString()));
							}
							lastSchemaName = currentSchemaName;
							lastSchemaUId = dataReader.GetGuid(dataReader.GetOrdinal("SchemaUId"));
						}
					}
				}
			}
			if (!lastSchemaUId.Equals(Guid.Empty)) {
				entityBuilder.Append(string.Format(entityTpl, lastSchemaName, lastSchemaUId.ToString(),
					fieldsBuilder.ToString().TrimEnd(',')));
			}
			return String.Format(wrapperTpl, entityBuilder.ToString().TrimEnd(','));
		}

		/// <summary>
		/// Gets quick add menu items configuration.
		/// </summary>
		/// <param name="userConnection">User connection.</param>
		/// <returns>Quick add menu items configuration.</returns>
		public virtual string GetQuickAddConfig(UserConnection userConnection) {
			Dictionary<Guid, string> quickItems = new Dictionary<Guid, string>();
			string tpl = @"{{QuickAddMenu: [{0}]}}";
			string itemTpl = @"{{itemId:'{0}',SysEditId:'{1}',name:{2},EditPageName:'{3}',TypeColumnValue:'{4}',TypeColumnName:{5},ModuleName:'{6}',EntitySchemaName:'{7}',miniPageSchema:'{8}',hasAddMiniPage:{9}}}";
			bool useMultiLanguageData = !userConnection.GetIsFeatureEnabled(DoNotUseMultiLanguageData);
			Select quickAddMenuItemsSelect = GetQuickAddMenuItemsSelect(userConnection);
			using (DBExecutor dbExecutor = userConnection.EnsureDBConnection()) {
				using (IDataReader dataReader = quickAddMenuItemsSelect.ExecuteReader(dbExecutor)) {
					while (dataReader.Read()) {
						Guid itemId = dataReader.GetColumnValue<Guid>("Id");
						Guid sysModuleEditId = dataReader.GetColumnValue<Guid>("SysModuleEditId");
						Guid typeColumnValue = dataReader.GetColumnValue<Guid>("TypeColumnValue");
						string editPageName = dataReader.GetColumnValue<string>("EditPageName");
						string name = dataReader.GetColumnValue<string>("Name");
						string caption = useMultiLanguageData ? dataReader.GetColumnValue<string>("Caption") : string.Empty;
						name = Json.Serialize(caption.IsNullOrEmpty() ? name : caption);
						string typeColumnName = Json.Serialize(String.Empty);
						Guid sysEntitySchemaUId = dataReader.GetColumnValue<Guid>("SysEntitySchemaUId");
						string entitySchemaName = dataReader.GetColumnValue<string>("EntityName");
						string moduleName = dataReader.GetColumnValue<string>("ModuleName");

						// TODO CRM-53025
						bool rightLevel = string.IsNullOrEmpty(entitySchemaName) ||
							userConnection.DBSecurityEngine.GetIsEntitySchemaAppendingAllowed(entitySchemaName);
						Guid columnUId = dataReader.GetColumnValue<Guid>("TypeColumnUId");
						Guid miniPageSchemaUId = dataReader.GetColumnValue<Guid>("MiniPageSchemaUId");
						string miniPageModes = dataReader.GetColumnValue<string>("MiniPageModes");
						bool hasAddMiniPage = HasSchemaEditAddMiniPage(userConnection, entitySchemaName, miniPageModes);
						if (columnUId.IsNotEmpty()) {
							typeColumnName = Json.Serialize(userConnection.EntitySchemaManager
								.GetInstanceByUId(sysEntitySchemaUId).Columns.GetByUId(columnUId).Name);
						}
						if (!quickItems.ContainsKey(itemId) && rightLevel) {
							quickItems.Add(itemId, string.Format(itemTpl, itemId, sysModuleEditId, name, editPageName,
								typeColumnValue, typeColumnName, moduleName, entitySchemaName, miniPageSchemaUId,
								hasAddMiniPage.ToString().ToLower()));
						}
					}
				}
			}
			string items = string.Join(",", quickItems.Select(x => x.Value));
			return string.Format(tpl, items);
		}

		public virtual string GetClientUnitSchemaDescriptors(UserConnection userConnection) {
			userConnection.CheckArgumentNull("userConnection");
			ClientUnitSchemaManager clientUnitSchemaManager = userConnection.ClientUnitSchemaManager;
			EntitySchemaManager entitySchemaManager = userConnection.EntitySchemaManager;
			var localCache = GetLocalCache(userConnection);
			string clientUnitSchemaManagerHash = clientUnitSchemaManager.GetHash();
			string entitySchemaManagerHash = entitySchemaManager.GetHash();
			string key = string.Concat(clientUnitSchemaManagerHash, entitySchemaManagerHash,
				userConnection.CurrentUser.Culture.Name);
			string descriptors;
			lock (_lockObject) {
				descriptors = (string)localCache[key];
				if (descriptors.IsNullOrEmpty()) {
					var sb = new StringBuilder();
					sb.AppendLine("{");
					IEnumerable<ISchemaManagerItem<ClientUnitSchema>> clientUnitSchemaItems =
						clientUnitSchemaManager.GetItems();
					AddItemDescriptors(sb, clientUnitSchemaItems);
					IEnumerable<ISchemaManagerItem<EntitySchema>> entitySchemaItems = entitySchemaManager.GetItems();
					AddItemDescriptors(sb, entitySchemaItems);
					sb.AppendLine("}");
					descriptors = sb.ToString();
					localCache[key] = descriptors;
				}
			}
			return descriptors;
		}

		/// <summary>
		/// Returns string that represents JSON object to configure a structure.
		/// </summary>
		/// <param name="userConnection">User connection.</param>
		/// <returns>String that represents JSON object.</returns>
		public virtual string GetConfigurationScript(UserConnection userConnection) {
			userConnection.CheckArgumentNull(nameof(userConnection));
			IEnumerable<string> configurationScripts = GetConfigurationScripts(userConnection);
			string resultScript = string.Join(Environment.NewLine, configurationScripts);
			return resultScript;
		}

		/// <summary>
		/// Returns configuration data.
		/// </summary>
		/// <param name="userConnection">User connection.</param>
		/// <param name="forceGet">Flag, that skips cache.</param>
		/// <returns>Configuration structure data.</returns>
		public virtual ConfigurationData GetConfigurationData(UserConnection userConnection, bool forceGet = false) {
			if (forceGet) {
				ClearCache(userConnection);
			}
			return new ConfigurationData(GetRootSchemaDescriptors(userConnection)) {
				ModulesStructure = GetModulesStructure(userConnection),
				EntitiesStructure = GetEntitiesStructure(userConnection),
			};
		}

		/// <summary>
		/// Returns module structures using cache.
		/// </summary>
		/// <param name="userConnection">User connection.</param>
		/// <returns>Entity schemas module structure.</returns>
		public virtual IEnumerable<ModuleStructure> GetSchemaModuleStructures(UserConnection userConnection) =>
			GetModulesStructure(userConnection).Values;

		/// <summary>
		/// Forms structure data based filtered by entity names collection.
		/// </summary>
		/// <param name="userConnection">User connection.</param>
		/// <param name="entityNames">Collection of entity names.</param>
		/// <returns>Filtered structures data.</returns>
		public virtual ConfigurationData GetConfigurationData(UserConnection userConnection,
				IEnumerable<string> entityNames) {
			return new ConfigurationData {
				ModulesStructure = GetModulesStructure(userConnection, entityNames),
				EntitiesStructure = GetEntitiesStructure(userConnection, entityNames)
			};
		}

		/// <summary>
		/// Returns information about schema UId by name.
		/// </summary>
		/// <param name="userConnection">User connection.</param>
		/// <param name="entityNames">Collection of entity names.</param>
		/// <returns>Name/UId value pairs dictionary.</returns>
		public virtual List<EntityUIdInfo> GetEntityUIds(UserConnection userConnection, IEnumerable<string> entityNames)
		{
			var entityUIds = new List<EntityUIdInfo>();
			var entityUIdsSelect = (Select)new Select(userConnection)
				.Column("Name")
				.Column("UId")
				.From("SysSchema")
				.Where("ExtendParent").IsEqual(Column.Parameter(false))
				.And("Name").In(Column.Parameters(entityNames));
			entityUIdsSelect.ExecuteReader(dataReader => {
				entityUIds.Add(new EntityUIdInfo(dataReader.GetColumnValue<string>("Name"),
					dataReader.GetColumnValue<Guid>("UId")));
			});
			return entityUIds;
		}

		/// <summary>
		/// Returns preloaded features configuration script.
		/// </summary>
		/// <param name="userConnection">User connection.</param>
		/// <returns>Preloaded features string.</returns>
		public virtual string GetPreloadedFeatures(UserConnection userConnection) {
			Dictionary<string, int> featureStates = userConnection.GetFeatureStates();
			const string template = "{1}:{{state:{0},code:{1}}}";
			string preLoadedFeaturesString = string.Join(",", featureStates.Select(f =>
				string.Format(template, Json.Serialize(f.Value), Json.Serialize(f.Key))));
			return $"Terrasoft.preLoadedFeatures={{{preLoadedFeaturesString}}};";
		}

		public virtual string GetModuleItemsDescriptors(UserConnection userConnection) {
			var moduleItems = new List<Guid>();
			var moduleItemsSelect = (Select)new Select(userConnection)
					.Column("SysModuleEntity", "SysEntitySchemaUId")
					.Column("CardModuleUId")
					.Column("CardSchemaUId")
					.Column("SectionModuleSchemaUId")
					.Column("SectionSchemaUId")
				.From("SysModule")
					.InnerJoin("SysModuleEntity").On("SysModule", "SysModuleEntityId").IsEqual("SysModuleEntity", "Id");
			var rootSchemaPaths = new StringBuilder();
			var columns = new List<string> {
				"SysEntitySchemaUId",
				"CardModuleUId",
				"CardSchemaUId",
				"SectionModuleSchemaUId",
				"SectionSchemaUId"
			};
			ClientUnitSchemaManager clientUnitSchemaManager = userConnection.ClientUnitSchemaManager;
			EntitySchemaManager entitySchemaManager = userConnection.EntitySchemaManager;
			var clientUnitSchemaDecorator = new ClientUnitSchemaDecorator(userConnection.AppConnection);
			using (DBExecutor dbExecutor = userConnection.EnsureDBConnection()) {
				using (IDataReader dataReader = moduleItemsSelect.ExecuteReader(dbExecutor)) {
					while (dataReader.Read()) {
						foreach (string columnName in columns) {
							var columnValue = dataReader.GetColumnValue<Guid>(columnName);
							if (!columnValue.Equals(Guid.Empty) && !moduleItems.Contains(columnValue)) {
								moduleItems.Add(columnValue);
								switch (columnName) {
									case "SysEntitySchemaUId":
										EntitySchema entitySchema = entitySchemaManager.GetInstanceByUId(columnValue);
										rootSchemaPaths.AppendLine(entitySchema.Name + ":" + clientUnitSchemaDecorator
											.GetSchemaDescriptor(entitySchema) + ",");
										break;
									default:
										ClientUnitSchema clientUnitSchema = clientUnitSchemaManager
											.GetInstanceByUId(columnValue);
										rootSchemaPaths.AppendLine(clientUnitSchema.Name + ":" +
											clientUnitSchemaDecorator.GetSchemaDescriptor(clientUnitSchema) + ",");
										break;
								}
							}
						}
					}
				}
			}
			ClientUnitSchema viewModuleSchema = clientUnitSchemaManager.GetInstanceByName("ViewModule");
			rootSchemaPaths.AppendLine(viewModuleSchema.Name + ":" + clientUnitSchemaDecorator.GetSchemaDescriptor(
				viewModuleSchema));
			return "{" + Environment.NewLine + rootSchemaPaths + "}";
		}

		public static void ClearCache(UserConnection userConnection) {
			string[] templates = {
				ConfigurationScriptCacheKeyTemplate,
				ShellConfigurationScriptCacheKeyTemplate,
				ModuleStructureCacheKeyTemplate,
				EntityStructureCacheKeyTemplate,
				EnvironmentInitializationHandlerCacheKeyTemplate,
				RootSchemaDescriptorsCacheKeyTemplate
			};
			ICacheStore localCache = GetLocalCache(userConnection);
			foreach (string template in templates) {
				string key = GetSessionCacheKey(userConnection, template);
				localCache.Remove(key);
			}
			ResetWorkplaceCache(userConnection);
			new ConfigurationCacheHashUpdater().UpdateCacheHash();
		}

		public static void ClearCache() {
			UserConnection userConnection = (UserConnection)HttpContext.Current?.Session["UserConnection"];
			if (userConnection != null) {
				var configurationSectionHelper = new ConfigurationSectionHelper(userConnection);
				configurationSectionHelper.ExpireLoginLocalCache();
			}
		}

		public void ExpireLoginLocalCache() {
			ICacheStore localCache = GetLocalCache(_userConnection);
			localCache.ExpireGroup(LocalCacheGroupName);
		}

		#endregion

	}

	#endregion

	#region Class: ConfigurationData

	public class ConfigurationData
	{

		public ConfigurationData() { }

		//TODO https://creatio.atlassian.net/browse/RND-37733
		public ConfigurationData(Dictionary<string, string> rootSchemaDescriptors) {
			_rootSchemaDescriptors = rootSchemaDescriptors;
		}
		public Dictionary<string, ModuleStructure> ModulesStructure {
			get;
			set;
		}

		public Dictionary<Guid, EntityStructure> EntitiesStructure {
			get;
			set;
		}

		private readonly Dictionary<string, string> _rootSchemaDescriptors;

		//TODO https://creatio.atlassian.net/browse/RND-37733
		[Obsolete("8.1 | The property is not in use and will be removed in the upcoming releases.")]
		public Dictionary<string, string> RootSchemaDescriptors => _rootSchemaDescriptors;
	}

	#endregion

	#region Class: ModuleStructure

	[Serializable]
	public class ModuleStructure
	{

		#region Properties: Public

		public string ImageId { get; set; }

		public string LogoId { get; set; }

		public string ModuleId { get; set; }

		public string Module { get; set; }

		public string EntitySchemaUId { get; set; }

		public string ModuleCaption { get; set; }

		public string ModuleHeader { get; set; }

		public string SectionModule { get; set; }

		public string SectionSchema { get; set; }

		public string CardModule { get; set; }

		public string CardSchema { get; set; }

		public string MiniPageSchema { get; set; }

		public string Attribute { get; set; }

		public string Hide { get; set; }

		public string Workplace { get; set; }

		public string TypeColumnValue { get; set; }

		public List<PageStructure> PagesStructure { get; set; }

		public string VisaSchemaUId { get; set; }

		public string VisaSchemaName { get; set; }

		public string EntitySchemaName { get; set; }


		public string ModuleKey { get; set; }


		public bool Primary { get; set; }


		public bool Section8X { get; set; }

		#endregion


		#region Methods: Public

		public override string ToString() {
			var moduleStructure = new StringBuilder($"\"{ModuleKey}\"");
			moduleStructure.Append(":{");
			AddProperty(moduleStructure, "imageId", ImageId);
			AddProperty(moduleStructure, "logoId", LogoId);
			AddProperty(moduleStructure, "moduleId", ModuleId);
			AddProperty(moduleStructure, "moduleCaption", ModuleCaption);
			AddProperty(moduleStructure, "moduleHeader", ModuleHeader);
			AddProperty(moduleStructure, "entitySchemaName", EntitySchemaName);
			AddProperty(moduleStructure, "entitySchemaUId", EntitySchemaUId);
			AddProperty(moduleStructure, "sectionModule", SectionModule);
			AddProperty(moduleStructure, "sectionSchema", SectionSchema);
			AddProperty(moduleStructure, "cardModule", CardModule);
			AddProperty(moduleStructure, "cardSchema", CardSchema);
			AddProperty(moduleStructure, "miniPageSchema", MiniPageSchema);
			AddProperty(moduleStructure, "attribute", Attribute);
			AddProperty(moduleStructure, "workplace", Workplace);
			AddProperty(moduleStructure, "visaSchemaUId", VisaSchemaUId);
			AddProperty(moduleStructure, "visaSchemaName", VisaSchemaName);
			AddProperty(moduleStructure, "hide", SectionSchema == "SysProcessLogSection" ? "true" : Hide);
			AddProperty(moduleStructure, "typeColumnValue", TypeColumnValue);
			AddProperty(moduleStructure, "primary", Primary);
			AddProperty(moduleStructure, "section8X", Section8X);
			if (PagesStructure?.Count > 0) {
				moduleStructure.Append("pages:[");
				var index = 0;
				foreach (PageStructure pageStructure in PagesStructure) {
					moduleStructure.Append("{");
					bool added = AddProperty(moduleStructure, "captionLcz", pageStructure.CaptionLcz);
					added = AddProperty(moduleStructure, "caption", pageStructure.Caption) || added;
					added = AddProperty(moduleStructure, "name", pageStructure.Name) || added;
					added = AddProperty(moduleStructure, "UId", pageStructure.UId) || added;
					added = AddProperty(moduleStructure, "cardSchema", pageStructure.CardSchema) || added;
					added = AddProperty(moduleStructure, "miniPageSchema", pageStructure.MiniPageSchema) || added;
					added = AddProperty(moduleStructure, "moduleEditId", pageStructure.ModuleEditId) || added;
					if (added) {
						moduleStructure.Length -= 1;
						moduleStructure.Append("}");
						if (index == PagesStructure.Count - 1) {
							continue;
						}
						moduleStructure.Append(",");
						index++;
					} else {
						moduleStructure.Length -= 1;
					}
				}
				moduleStructure.Append("]");
			} else {
				moduleStructure.Length -= 1;
			}
			moduleStructure.Append("}");
			return moduleStructure.ToString();
		}

		/// <summary>
		/// Adds "propertyName: propertyValue, " - formatted string.
		/// </summary>
		/// <param name="destination">Destination string.</param>
		/// <param name="propertyName">Property name.</param>
		/// <param name="propertyValue">Property value.</param>
		/// <returns>True, if formatted string was added.</returns>
		private bool AddProperty(StringBuilder destination, string propertyName, string propertyValue) {
			if (propertyValue.IsNullOrEmpty()) {
				return false;
			}
			InnerAddProperty(destination, propertyName, Json.Serialize(propertyValue));
			return true;
		}

		private void AddProperty(StringBuilder destination, string propertyName, bool propertyValue) {
			InnerAddProperty(destination, propertyName, propertyValue ? "true" : "false");
		}

		private void InnerAddProperty(StringBuilder destination, string propertyName, object propertyValue) {
			destination.Append(propertyName)
				.Append(":")
				.Append(propertyValue)
				.Append(",");
		}

		#endregion

	}

	#endregion

	#region Class: EntityStructure

	[Serializable]
	public class EntityStructure
	{

		#region Properties: Public

		public string EntityName { get; set; }

		public string SearchRowSchema { get; set; }

		public string Attribute { get; set; }

		public string EntitySchemaUId { get; set; }

		public List<PageStructure> PagesStructure { get; set; }

		public string CardModuleName { get; set; }

		public bool Primary { get; set; } = true;

		public bool Page8X { get; set; }

		#endregion

	}

	#endregion

	#region Class: OverridingEntityStructure

	/// <summary>
	/// Class that used to override default primary instance of <see cref="EntityStructure"/>, but leave it accessible
	/// through additional property.
	/// </summary>
	[Serializable]
	public class OverridingEntityStructure : EntityStructure
	{

		#region Constructors: Public

		public OverridingEntityStructure(EntityStructure originalEntityStructure) {
			EntityName = originalEntityStructure.EntityName;
			SearchRowSchema = originalEntityStructure.SearchRowSchema;
			Attribute = originalEntityStructure.Attribute;
			EntitySchemaUId = originalEntityStructure.EntitySchemaUId;
			PagesStructure = originalEntityStructure.PagesStructure?.Select(x => (PageStructure)x.Clone()).ToList();
			CardModuleName = originalEntityStructure.CardModuleName;
			OverridenEntityStructure = originalEntityStructure;
			originalEntityStructure.Primary = false;
			Primary = true;
		}

		#endregion

		#region Properties: Public

		public EntityStructure OverridenEntityStructure { get; }

		#endregion

	}

	#endregion

	#region Class: PageStructure

	[Serializable]
	public class PageStructure : ICloneable
	{

		#region Constructors: Public

		public PageStructure() {
			UId = Guid.NewGuid().ToString();
			Actions = new PageActions();
		}

		#endregion

		#region Properties: Public

		public string CaptionLcz { get; set; }

		public string Caption { get; set; }

		public string Name { get; set; }

		public string UId { get; set; }

		public string SchemaGroup { get; set; }

		public string ModuleEditId { get; set; }

		public string CardSchema { get; set; }

		public string CardSchemaUId { get; set; }

		public string MiniPageSchema { get; set; }

		public string MiniPageModes { get; set; }

		public ClientUnitSchemaType ClientUnitSchemaType { get; set; }

		public PageActions Actions { get; set; }

		public bool IsDefault { get; set; }

		public Guid? Role { get; set; }

		public string CardModuleName { get; set; }
		
		public bool HasAddMiniPage { get; set; } = false;

		#endregion

		#region Methods: Public

		public object Clone() => MemberwiseClone();

		#endregion

	}

	#endregion

	#region Interface: IConfigurationDataRelatedPagesApplier

	public interface IConfigurationDataRelatedPagesApplier
	{

		#region Methods: Public

		/// <summary>
		/// Applies related page structures to entity structures.
		/// </summary>
		/// <param name="entityStructures">Module structures.</param>
		void ApplyRelatedPagesToEntityStructure(Dictionary<Guid, EntityStructure> entityStructures,
			string[] entityNames = null);

		/// <summary>
		/// Gets a flag indicating for use 7X section.
		/// </summary>
		/// <param name="entityName">Name of entity.</param>
		bool Use7XSection(string entityName);

		/// <summary>
		/// Gets a flag indicating for has external pages for entity.
		/// </summary>
		/// <param name="entityName">Name of entity.</param>
		bool IsEntityHasExternalPages(string entityName);

		/// <summary>
		/// Returns typed column name by entity name.
		/// </summary>
		/// <param name="entityName">Name of entity.</param>
		string GetTypedColumnName(string entityName);

		#endregion

	}

	#endregion

	#region Class: ConfigurationDataRelatedPagesApplier

	[DefaultBinding(typeof(IConfigurationDataRelatedPagesApplier))]
	public class ConfigurationDataRelatedPagesApplier : IConfigurationDataRelatedPagesApplier
	{

		#region Constants: Private

		private const string DisableTypedRelatedPages = "DisableTypedRelatedPages";
		private const string RelatedPagesCardSchemaViewModuleName = "CardSchemaViewModule";

		#endregion

		#region Fields: Private

		private static readonly Guid _uiType8X = Guid.Parse("f4d757e1-2aeb-496f-b751-3d5b39708ea3");
		private static readonly Guid _uiType7X = Guid.Parse("d823260d-75be-44ee-8e3a-669bb83a5ce4");
		private readonly UserConnection _userConnection;
		private readonly IRelatedPagesManager _pagesManager;
		private readonly IEntityPageMetadataProvider _entityPageMetadataProvider;

		#endregion

		#region Constructors: Internal

		/// <summary>
		/// Initializes a new instance of the <see cref="ConfigurationDataRelatedPagesApplier"/> class.
		/// </summary>
		/// <param name="entityPageMetadataProvider">The entity page metadata provider.</param>
		internal ConfigurationDataRelatedPagesApplier(IEntityPageMetadataProvider entityPageMetadataProvider) {
			_entityPageMetadataProvider = entityPageMetadataProvider;
		}

		#endregion

		#region Constructors: Public

		public ConfigurationDataRelatedPagesApplier(UserConnection userConnection, IRelatedPagesManager pagesManager)
			: this(new EntityPageMetadataProvider()) {
			_userConnection = userConnection;
			_pagesManager = pagesManager;
		}

		#endregion

		#region Properties: Private

		private bool? _useNewShell;

		private bool UseNewShell =>
			_useNewShell ?? (_useNewShell = CoreSysSettings.GetValue(_userConnection, "UseNewShell", false)).Value;

		private IEnumerable<SchemaRelatedPage> _entitiesRelatedPages;

		private IEnumerable<SchemaRelatedPage> EntitiesRelatedPages =>
			_entitiesRelatedPages ?? (_entitiesRelatedPages =
				_pagesManager.GetRelatedPages(nameof(EntitySchemaManager)) ?? new List<SchemaRelatedPage>());


		private Dictionary<string, Guid> _entitiesEditPagesUITypes;

		private Dictionary<string, Guid> EntitiesEditPagesUITypes =>
			_entitiesEditPagesUITypes ?? (_entitiesEditPagesUITypes = GetEntitiesEditPagesUITypes());

		#endregion

		#region Methods: Private

		private Dictionary<string, Guid> GetEntitiesEditPagesUITypes() {
			var esq = new EntitySchemaQuery(_userConnection.EntitySchemaManager, "EntityEditPagesUITypes");
			esq.AddColumn("EntitySchemaName");
			var createdOn = esq.AddColumn("CreatedOn");
			createdOn.OrderByAsc();
			string uiTypeColumnName = UseNewShell ? "Freedom" : "EXT";
			esq.AddColumn($"{uiTypeColumnName}.Id").Name = uiTypeColumnName;
			return esq.GetEntityCollection(_userConnection)
				.Select(x => new {
					EntitySchemaName = x.GetTypedColumnValue<string>("EntitySchemaName"),
					Id = x.GetTypedColumnValue<Guid>(uiTypeColumnName)
					})
				.GroupBy(item => item.EntitySchemaName)
				.Select(grp => grp.First())
				.ToDictionary(
					x => x.EntitySchemaName,
					x => x.Id);
		}

		private static bool HasRelatedPages(SchemaRelatedPage schemaRelatedPage) {
			return schemaRelatedPage.RelatedPages != null && schemaRelatedPage.RelatedPages.Count != 0;
		}

		private static string GetRelatedPageGroup(UserConnection userConnection, Guid relatedPageUId) {
			if (relatedPageUId.IsEmpty()) {
				return string.Empty;
			}
			return userConnection.ClientUnitSchemaManager.FindItemByUId(relatedPageUId)?.GetPropertyValue(i => i.Group);
		}

		private Guid[] GetRelatedPagesTypes(SchemaRelatedPage schemaRelatedPage) {
			return schemaRelatedPage.RelatedPages.Where(x => x.TypeColumnValue.HasValue)
				.Select(x => x.TypeColumnValue.Value).Distinct().ToArray();
		}

		private IDictionary<Guid, string> GetTypeColumnReferenceSchemaRecords(SchemaRelatedPage schemaRelatedPage) {
			if (_userConnection.GetIsFeatureEnabled(DisableTypedRelatedPages)) {
				return null;
			}
			if (!schemaRelatedPage.TypeColumnUId.HasValue) {
				return null;
			}
			Guid[] typeIDs = GetRelatedPagesTypes(schemaRelatedPage);
			if (typeIDs.Length == 0) {
				return null;
			}
			EntitySchema referenceSchema = GetRelatedPageTypeColumn(schemaRelatedPage)?.ReferenceSchema;
			if (referenceSchema?.PrimaryColumn == null || referenceSchema?.PrimaryDisplayColumn == null) {
				return null;
			}
			return _entityPageMetadataProvider.LoadSchemaDisplayValues(_userConnection, referenceSchema, typeIDs);
		}

		private string GetTypeCaption(IDictionary<Guid, string> types, RelatedPageInfo relatedPageInfo) {
			if (types == null || !relatedPageInfo.TypeColumnValue.HasValue) {
				return string.Empty;
			}
			Guid typeId = relatedPageInfo.TypeColumnValue.Value;
			return types.TryGetValue(typeId, out string typeCaption) ? typeCaption : string.Empty;
		}

		private List<PageStructure> GetPagesStructure(IEnumerable<RelatedPageInfo> relatedPagesInfo,
				SchemaRelatedPage schemaRelatedPage, string caption = "") {
			IDictionary<Guid, string> types = schemaRelatedPage.TypeColumnUId.IsNullOrEmpty()
				? new Dictionary<Guid, string>()
				: GetTypeColumnReferenceSchemaRecords(schemaRelatedPage);
			var pages = relatedPagesInfo.Select(relatedPageInfo => {
				var schemaGroup = GetRelatedPageGroup(_userConnection, relatedPageInfo.UId);
				var typeCaption = GetTypeCaption(types, relatedPageInfo);
				var typeColumnValue = relatedPageInfo.TypeColumnValue;
				return new PageStructure {
					UId = typeColumnValue.IsNullOrEmpty() ? String.Empty : typeColumnValue.ToString(),
					SchemaGroup = schemaGroup,
					CardSchema = relatedPageInfo.Name,
					CardSchemaUId = relatedPageInfo.UId.ToString(),
					ClientUnitSchemaType = ClientUnitSchemaType.AngularSchema,
					Actions = relatedPageInfo.Actions ?? new PageActions(),
					IsDefault = relatedPageInfo.IsDefault,
					Role = relatedPageInfo.Role,
					Caption = string.IsNullOrEmpty(typeCaption) ? caption: typeCaption,
					CaptionLcz = typeCaption,
				};
			}).ToList();
			return pages;
		}

		private void MergePagesStructure(List<PageStructure> pages, EntityStructure structure) {
			var oldPages = structure.PagesStructure;
			var oldTypedPages = oldPages.Where(oldPage => pages.All(page => page.UId != oldPage.UId)).ToArray();
			oldTypedPages.ForEach(x => x.CardModuleName = structure.CardModuleName);
			var defaultPages = oldTypedPages.Select(x => (PageStructure)x.Clone()).ToList();
			defaultPages.ForEach(x => x.IsDefault = true);
			pages.AddRange(defaultPages);
			var hasAddPages = pages.Exists(x => x.Actions?.Add == true);
			if (hasAddPages) {
				var addPages = oldTypedPages.Select(x => (PageStructure)x.Clone()).ToList();
				addPages.ForEach(x => x.Actions = new PageActions { Add = true });
				pages.AddRange(addPages);
			}
		}

		private OverridingEntityStructure OverrideEntityStructure(EntityStructure entityStructureToOverride,
				IEnumerable<RelatedPageInfo> relatedPageInfos, SchemaRelatedPage schemaRelatedPage) {
			var overridingStructure = new OverridingEntityStructure(entityStructureToOverride);
			var useRelatedPages = UseEntityRelatedPages(entityStructureToOverride.EntityName);
			var structure = useRelatedPages ? overridingStructure : entityStructureToOverride;
			var caption = structure.PagesStructure?.FirstOrDefault()?.Caption ?? string.Empty;
			var typeColumnName = GetRelatedPageTypeColumn(schemaRelatedPage)?.Name;
			var pages = GetPagesStructure(relatedPageInfos, schemaRelatedPage, caption);
			if (typeColumnName != null && typeColumnName == structure.Attribute) {
				MergePagesStructure(pages, structure);
			}
			structure.PagesStructure = pages;
			structure.CardModuleName = RelatedPagesCardSchemaViewModuleName;
			structure.Page8X = true;
			structure.Attribute = typeColumnName;
			return overridingStructure;
		}

		private void ApplyRelatedPagesToExistsEntityStructure(IDictionary<Guid, EntityStructure> entityStructures) {
			foreach (var schemaRelatedPage in EntitiesRelatedPages) {
				if (!HasRelatedPages(schemaRelatedPage)) {
					continue;
				}
				if (!entityStructures.TryGetValue(schemaRelatedPage.UId, out EntityStructure entityStructure)) {
					continue;
				}
				var relatedPageInfos = GetRelatedPageInfo(schemaRelatedPage);
				if (!relatedPageInfos.Any()) {
					continue;
				}
				var structure = OverrideEntityStructure(entityStructure, relatedPageInfos, schemaRelatedPage);
				entityStructures[schemaRelatedPage.UId] = structure;
			}
		}

		private Guid GetPagesUITypeForCurrentShell() {
			string pagesUITypeForShellSettingCode =
				UseNewShell ? "EditPagesUITypeForFreedomHost" : "EditPagesUITypeForEXTHost";
			Guid defaultValue = UseNewShell ? _uiType8X : _uiType7X;
			return CoreSysSettings.GetValue(_userConnection, pagesUITypeForShellSettingCode, defaultValue);
		}

		private bool UseEntityRelatedPages(string entityName) {
			var resultUIType = EntitiesEditPagesUITypes.TryGetValue(entityName, out Guid pagesUITypeForEntity)
				? pagesUITypeForEntity
				: GetPagesUITypeForCurrentShell();
			return resultUIType == _uiType8X;
		}

		private List<RelatedPageInfo> GetRelatedPageInfo(SchemaRelatedPage schemaRelatedPage) {
			bool isSsp = _userConnection is SSPUserConnection;
			return schemaRelatedPage.RelatedPages.Where(
				x => (isSsp && (x.IsSspDefault || GetIsExternalPage(x))) || (!isSsp && !x.IsSspDefault)).ToList();
		}

		private bool GetIsExternalPage(RelatedPageInfo page) {
			return page.Role == BaseConsts.PortalUsersSysAdminUnitUId;
		}

		private void CreateEntityStructureByRelatedPages(Dictionary<Guid, EntityStructure> entityStructures,
				string[] entityNames = null) {
			foreach (SchemaRelatedPage schemaRelatedPage in EntitiesRelatedPages) {
				if (entityNames?.Contains(schemaRelatedPage.Name) == false) {
					continue;
				}
				if (!HasRelatedPages(schemaRelatedPage)) {
					continue;
				}
				if (entityStructures.ContainsKey(schemaRelatedPage.UId)) {
					continue;
				}
				var relatedPageInfos = GetRelatedPageInfo(schemaRelatedPage);
				if (!relatedPageInfos.Any()) {
					continue;
				}
				var typeColumnName = GetRelatedPageTypeColumn(schemaRelatedPage)?.Name;
				var pagesStructure = GetPagesStructure(relatedPageInfos, schemaRelatedPage);
				var entityStructure = new EntityStructure {
					EntityName = schemaRelatedPage.Name,
					EntitySchemaUId = schemaRelatedPage.UId.ToString(),
					PagesStructure = pagesStructure,
					CardModuleName = RelatedPagesCardSchemaViewModuleName,
					Attribute = typeColumnName,
					Page8X = true,
				};
				entityStructures.Add(schemaRelatedPage.UId, entityStructure);
			}
		}

		private EntitySchemaColumn GetRelatedPageTypeColumn(SchemaRelatedPage schemaRelatedPage) {
			if (schemaRelatedPage.TypeColumnUId.HasValue && !_userConnection.GetIsFeatureEnabled(DisableTypedRelatedPages)) {
				EntitySchema entitySchema = _userConnection.EntitySchemaManager.FindInstanceByUId(schemaRelatedPage.UId);
				return entitySchema?.Columns.FindByUId(schemaRelatedPage.TypeColumnUId.Value);
			}
			return null;
		}

		#endregion

		#region Methods: Public

		/// <inheritdoc cref="IConfigurationDataRelatedPagesApplier.ApplyRelatedPagesToEntityStructure"/>
		public void ApplyRelatedPagesToEntityStructure(Dictionary<Guid, EntityStructure> entityStructures,
				string[] entityNames = null) {
			ApplyRelatedPagesToExistsEntityStructure(entityStructures);
			CreateEntityStructureByRelatedPages(entityStructures, entityNames);
		}


		/// <inheritdoc cref="IConfigurationDataRelatedPagesApplier.GetTypedColumnName"/>
		public string GetTypedColumnName(string entityName) {
			var schemaRelatedPage = EntitiesRelatedPages.Where(e => e.Name == entityName).FirstOrDefault();
			return schemaRelatedPage == null ? string.Empty : GetRelatedPageTypeColumn(schemaRelatedPage)?.Name;
		}

		/// <inheritdoc cref="IConfigurationDataRelatedPagesApplier.Use7XSection"/>
		public bool Use7XSection(string entityName) {
			return string.IsNullOrEmpty(entityName)
				? GetPagesUITypeForCurrentShell() == _uiType7X
				: !UseEntityRelatedPages(entityName);

		}

		/// <inheritdoc cref="IConfigurationDataRelatedPagesApplier.IsEntityHasExternalPages"/>
		public bool IsEntityHasExternalPages(string entityName) {
			return EntitiesRelatedPages
				.Where(erp => erp.Name.Equals(entityName) && HasRelatedPages(erp))
				.Any(erp => GetRelatedPageInfo(erp).Any());
		}

		#endregion

	}

	#endregion

}

