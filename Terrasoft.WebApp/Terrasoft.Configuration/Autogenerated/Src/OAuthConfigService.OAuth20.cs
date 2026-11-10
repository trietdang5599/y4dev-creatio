namespace Terrasoft.Configuration.OAuth20
{
	using System;
	using System.Collections.Generic;
	using System.Diagnostics;
	using System.Linq;
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using global::Common.Logging;
	using Creatio.OAuth.Handlers;
	using Terrasoft.Common;
	using Terrasoft.Common.Threading;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities;
	using Terrasoft.Web.Common;
	using Terrasoft.Core.Configuration;
	using Terrasoft.Core.Factories;
	using Terrasoft.Core.Store;
	using Terrasoft.OAuthIntegration;
	using Terrasoft.OAuthIntegration.DTO;
	using Terrasoft.OAuthIntegration.Enums;
	using Terrasoft.OAuthIntegration.TestOAuthConnection;
	using ErrorInfo = Terrasoft.Core.ServiceModelContract.ErrorInfo;

	#region Class: OAuthConfigService

	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class OAuthConfigService : BaseService
	{

		#region Fields: Private

		private readonly ILog _log = LogManager.GetLogger("OAuth20");
		private readonly object _defaultOAuthResourceLockObject = new object();
		private readonly UserConnection _userConnection;
		private readonly string ClientCredentialsGrantTypeCode = "client_credentials";
		private readonly string AuthorizationCodeGrantTypeCode = "authorization_code";
		private readonly string TokenExchangeGrantTypeCode = "urn:ietf:params:oauth:grant-type:token-exchange";

		#endregion

		#region Constructors: Public

		public OAuthConfigService() {
			_userConnection = base.UserConnection;
		}

		public OAuthConfigService(UserConnection userConnection) {
			_userConnection = userConnection;
		}

		#endregion

		#region Properties: Public

		public string OAuthDisabledMessage =>
			new LocalizableString(_userConnection.ResourceStorage, "OAuthConfigService",
				"LocalizableStrings.OAuthDisabledMessage.Value");

		#endregion

		#region Methods: Private

		private bool IsResourceInClientAlreadyExists(string clientId, string resourceName) {
			var esq = new EntitySchemaQuery(_userConnection.EntitySchemaManager, "OAuthResourceInClient");
			esq.AddColumn("Id");
			IEntitySchemaQueryFilterItem clientFilter = esq
				.CreateFilterWithParameters(FilterComparisonType.Equal, "OAuthClient.ClientId", clientId);
			IEntitySchemaQueryFilterItem resourceFilter = esq
				.CreateFilterWithParameters(FilterComparisonType.Equal, "OAuthResource.Name", resourceName);
			esq.Filters.Add(clientFilter);
			esq.Filters.Add(resourceFilter);
			EntityCollection result = esq.GetEntityCollection(_userConnection);
			return result.Count > 0;
		}

		private bool TryGetClientAppIdByClientId(string clientId, out Guid clientAppId) {
			clientAppId = Guid.Empty;
			var esq = new EntitySchemaQuery(_userConnection.EntitySchemaManager, "OAuthClientApp");
			EntitySchemaQueryColumn colId = esq.AddColumn("Id");
			IEntitySchemaQueryFilterItem clientIdFilter =
				esq.CreateFilterWithParameters(FilterComparisonType.Equal, "ClientId", clientId);
			esq.Filters.Add(clientIdFilter);
			EntityCollection entityCollection = esq.GetEntityCollection(_userConnection);
			if (entityCollection.Count == 0) {
				return false;
			}
			clientAppId = entityCollection[0].GetTypedColumnValue<Guid>(colId.Name);
			return true;
		}

		private bool IsSysAdminUnitValid(Guid sysAdminUnitId) {
			var esq = new EntitySchemaQuery(_userConnection.EntitySchemaManager, "SysAdminUnit");
			esq.AddColumn("Id");
			IEntitySchemaQueryFilterItem sysAdminUnitIdFilter =
				esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Id", sysAdminUnitId);
			var filterGroup =
				new EntitySchemaQueryFilterCollection(esq, LogicalOperationStrict.Or);
			IEntitySchemaQueryFilterItem userTypeFilter =
				esq.CreateFilterWithParameters(FilterComparisonType.Equal, "SysAdminUnitTypeValue", 4);
			IEntitySchemaQueryFilterItem techUserTypeFilter =
				esq.CreateFilterWithParameters(FilterComparisonType.Equal, "SysAdminUnitTypeValue", 7);
			filterGroup.Add(userTypeFilter);
			filterGroup.Add(techUserTypeFilter);
			esq.Filters.Add(sysAdminUnitIdFilter);
			esq.Filters.Add(filterGroup);
			EntityCollection entityCollection = esq.GetEntityCollection(_userConnection);
			return entityCollection.Count > 0;
		}

		private bool TryGetResourceIdByName(string resourceName, out Guid resourceId) {
			resourceId = Guid.Empty;
			var esq = new EntitySchemaQuery(_userConnection.EntitySchemaManager, "OAuthResource");
			EntitySchemaQueryColumn colId = esq.AddColumn("Id");
			IEntitySchemaQueryFilterItem resourceNameFilter =
				esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Name", resourceName);
			esq.Filters.Add(resourceNameFilter);
			EntityCollection entityCollection = esq.GetEntityCollection(_userConnection);
			if (entityCollection.Count > 0) {
				resourceId = entityCollection[0].GetTypedColumnValue<Guid>(colId.Name);
				return true;
			}
			return false;
		}

		private void CreateOAuthResourceInClient(Guid clientAppId, Guid resourceId) {
			var resourceInClient = new OAuthResourceInClient(_userConnection);
			resourceInClient.SetDefColumnValues();
			resourceInClient.OAuthClientId = clientAppId;
			resourceInClient.OAuthResourceId = resourceId;
			_log.Debug($"Creating OAuthResourceInClient with ClientId: {clientAppId}, ResourceId: {resourceId}");
			resourceInClient.Save();
		}

		private ConfigurationServiceResponse GetErrorConfigurationServiceResponse(string message) {
			return new ConfigurationServiceResponse() {
				Success = false,
				ErrorInfo = new ErrorInfo {
					Message = message
				}
			};
		}

		private static bool TryFetchDefaultResource(OAuthResource resource) {
			var conditions = new Dictionary<string, object> { { "IsDefault", true } };
			return resource.FetchFromDB(conditions);
		}

		private static void InitializeNewResource(OAuthResource resource) {
			resource.SetDefColumnValues();
			resource.Name = $"ApplicationAccess_{Guid.NewGuid():N}";
			resource.DisplayName = "Application access";
			resource.IsDefault = true;
			resource.Save();
		}

		private OAuthResource CreateResource() {
			var resource = new OAuthResource(_userConnection);
			lock (_defaultOAuthResourceLockObject) {
				if (!TryFetchDefaultResource(resource)) {
					InitializeNewResource(resource);
					RemoveDefaultResourceNameFromCache();
				} else {
					throw new ItemAlreadyExistException(resource.Name);
				}
			}
			return resource;
		}

		private EntityCollection GetOAuthClients() {
			var esq = new EntitySchemaQuery(_userConnection.EntitySchemaManager, "OAuthClientApp") {
					PrimaryQueryColumn = {
						IsAlwaysSelect = true
					}
				};
			return esq.GetEntityCollection(_userConnection);
		}

		private bool NeedRedistributeAccessToExistingIntegrations(EntityCollection clients) {
			return clients.Count > 0;
		}

		private void RedistributeOAuthResourceToExistingClients(OAuthResource resource) {
			var existingOAuthClients = GetOAuthClients();
			if (NeedRedistributeAccessToExistingIntegrations(existingOAuthClients)) {
				Guid defaultResourceId = resource.PrimaryColumnValue;
				foreach (var existingOAuthClient in existingOAuthClients) {
					var clientAppId = existingOAuthClient.PrimaryColumnValue;
					CreateOAuthResourceInClient(clientAppId, defaultResourceId);
				}
			}
		}

		private AddClientResponse CreateAddClientErrorResponse(string message) {
			var clientResponse = new AddClientResponse() {
				Success = false,
				ErrorInfo = new ErrorInfo() {
					Message = message
				}
			};
			return clientResponse;
		}

		private bool IsGrantTypeValid(string grantType) {
			return grantType.IsNullOrEmpty() || GetSupportedGrantTypes().Contains(grantType);
		}

		private HashSet<string> GetSupportedGrantTypes() {
			return new HashSet<string> {
				ClientCredentialsGrantTypeCode,
				AuthorizationCodeGrantTypeCode,
				TokenExchangeGrantTypeCode
			};
		}

		private List<string> GetDefaultAllowedGrantTypes() {
			return new List<string> { ClientCredentialsGrantTypeCode };
		}

		private string GetUniqueTechnicalUserName(string baseName) {
			string normalizedBaseName = baseName.IsNullOrWhiteSpace()
				? "OAuth technical user"
				: baseName.Trim();
			string candidate = normalizedBaseName;
			int suffix = 2;
			var schema = _userConnection.EntitySchemaManager.GetInstanceByName("SysAdminUnit");
			var sysAdminUnit = schema.CreateEntity(_userConnection);
			while (sysAdminUnit.FetchFromDB("Name", candidate, useDisplayValues: false)) {
				candidate = $"{normalizedBaseName}_{suffix++}";
				sysAdminUnit = schema.CreateEntity(_userConnection);
			}
			return candidate;
		}

		private (Guid SystemUserId, string SystemUserName) CreateTechnicalUserEntity(string integrationName) {
			string userName = GetUniqueTechnicalUserName(integrationName);
			var sysAdminUtilities = new SysAdminUtilities();
			Guid contactId = sysAdminUtilities.CreateContact(_userConnection, integrationName, null, null);
			var sysAdminUnit = new SysAdminUnit(_userConnection);
			sysAdminUnit.Name = userName;
			sysAdminUnit.ContactId = contactId;
			sysAdminUnit.SetColumnValue("SysAdminUnitTypeValue", Core.DB.SysAdminUnitType.TechnicalUser);
			sysAdminUnit.Active = true;
			sysAdminUnit.ConnectionType = UserType.General;
			sysAdminUnit.SetColumnValue("SysCultureId", _userConnection.CurrentUser.SysCultureId);
			sysAdminUnit.LoggedIn = false;
			sysAdminUnit.Save(validateRequired: false);
			return (sysAdminUnit.PrimaryColumnValue, userName);
		}
		private IIdentityServiceWrapper IdentityServiceWrapper => GlobalAppSettings.FeatureUseSeparateSettingsForOAuth20
			? ClassFactory.Get<IIdentityServiceWrapper>("OAuth20Integration")
			: ClassFactory.Get<IIdentityServiceWrapper>();

		private List<string> NormalizeAllowedGrantTypes(List<string> allowedGrantTypes, string legacyGrantType) {
			var grantTypes = allowedGrantTypes != null && allowedGrantTypes.Any()
				? allowedGrantTypes
				: legacyGrantType.IsNullOrEmpty()
					? GetDefaultAllowedGrantTypes()
					: new List<string> { legacyGrantType };
			return grantTypes
				.Where(grantType => !grantType.IsNullOrEmpty())
				.Distinct()
				.ToList();
		}

		private bool AreGrantTypesValid(IEnumerable<string> grantTypes) {
			if (grantTypes == null) {
				return false;
			}
			var materialized = grantTypes as ICollection<string> ?? grantTypes.ToList();
			if (materialized.Count == 0) {
				return false;
			}
			var supportedGrantTypes = GetSupportedGrantTypes();
			return materialized.All(grantType => supportedGrantTypes.Contains(grantType));
		}

		private string GetGrantTypeConfigurationError(OAuthClientApp client, IEnumerable<string> allowedGrantTypes) {
			return BaseOAuthApiCaller.GetGrantTypeConfigurationError(_userConnection, client.IsPublic,
				client.RequirePKCE, allowedGrantTypes);
		}

		private void SynchronizeClientGrantTypes(Guid clientAppId, IEnumerable<string> grantTypes) {
			var schemaManager = _userConnection.EntitySchemaManager;
			var relationSchema = schemaManager.FindInstanceByName("OAuthGrantTypeInClient");
			if (relationSchema == null) {
				return;
			}
			try {
				var esq = new EntitySchemaQuery(schemaManager, "OAuthGrantTypeInClient") {
					PrimaryQueryColumn = { IsAlwaysSelect = true }
				};
				EntitySchemaQueryColumn grantTypeCodeColumn = esq.AddColumn("OAuthGrantType.Code");
				esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "OAuthClientApp",
					clientAppId));
				// Materialize the collection before mutating — Entity.Delete() removes the row from the
				// underlying EntityCollection, which would otherwise throw "Collection was modified" mid-foreach.
				List<Entity> currentGrantTypes = esq.GetEntityCollection(_userConnection).ToList();
				var requestedGrantTypes = new HashSet<string>(grantTypes);
				var existingGrantTypes = new HashSet<string>(currentGrantTypes
					.Select(entity => entity.GetTypedColumnValue<string>(grantTypeCodeColumn.Name)));
				foreach (Entity currentGrantType in currentGrantTypes) {
					string grantTypeCode = currentGrantType.GetTypedColumnValue<string>(grantTypeCodeColumn.Name);
					if (!requestedGrantTypes.Contains(grantTypeCode)) {
						currentGrantType.Delete();
					}
				}
				foreach (string grantTypeCode in requestedGrantTypes.Except(existingGrantTypes)) {
					Guid grantTypeId = FindGrandTypeId(grantTypeCode);
					if (grantTypeId.IsEmpty()) {
						continue;
					}
					var relationEntity = relationSchema.CreateEntity(_userConnection);
					relationEntity.SetDefColumnValues();
					relationEntity.SetColumnValue("OAuthClientAppId", clientAppId);
					relationEntity.SetColumnValue("OAuthGrantTypeId", grantTypeId);
					relationEntity.Save();
				}
			}
			catch (Exception ex) {
				_log.Error($"Failed to synchronize OAuth grant type relations for client {clientAppId}.", ex);
				throw;
			}
		}

		private Guid FindGrandTypeId(string grantTypeCode) {
			var schema = _userConnection.EntitySchemaManager.GetInstanceByName("OAuthGrantType");
			var oAuthGrantType = schema.CreateEntity(_userConnection);
			if (oAuthGrantType.FetchFromDB("Code", grantTypeCode, useDisplayValues: false)) {
				return ((OAuthGrantType)oAuthGrantType).Id;
			}
			return Guid.Empty;
		}

		private string FindGrandTypeCode(Guid grantTypeId) {
			var schema = _userConnection.EntitySchemaManager.GetInstanceByName("OAuthGrantType");
			var oAuthGrantType = schema.CreateEntity(_userConnection);
			if (oAuthGrantType.FetchFromDB("Id", grantTypeId, useDisplayValues: false)) {
				return ((OAuthGrantType)oAuthGrantType).Code;
			}
			return string.Empty;
		}

		private bool IsAuthorizationCodeGrantType(Guid grantTypeId) {
			var schema = _userConnection.EntitySchemaManager.GetInstanceByName("OAuthGrantType");
			var oAuthGrantType = schema.CreateEntity(_userConnection);
			if (oAuthGrantType.FetchFromDB("Id", grantTypeId, useDisplayValues: false)) {
				string grantTypeCode = ((OAuthGrantType)oAuthGrantType).Code;
				return grantTypeCode == AuthorizationCodeGrantTypeCode;
			}
			return false;
		}

		private bool ClientAllowsAuthorizationCode(Guid clientAppId, Guid legacyGrantTypeId) {
			if (_userConnection.EntitySchemaManager.FindInstanceByName("OAuthGrantTypeInClient") == null) {
				return IsAuthorizationCodeGrantType(legacyGrantTypeId);
			}
			try {
				var allGrantTypesEsq =
					new EntitySchemaQuery(_userConnection.EntitySchemaManager, "OAuthGrantTypeInClient");
				allGrantTypesEsq.AddColumn("Id");
				allGrantTypesEsq.Filters.Add(allGrantTypesEsq.CreateFilterWithParameters(FilterComparisonType.Equal,
					"OAuthClientApp", clientAppId));
				bool hasGrantTypeRelations = allGrantTypesEsq.GetEntityCollection(_userConnection).Count > 0;
				var esq = new EntitySchemaQuery(_userConnection.EntitySchemaManager, "OAuthGrantTypeInClient");
				esq.AddColumn("Id");
				esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "OAuthClientApp",
					clientAppId));
				esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "OAuthGrantType.Code",
					AuthorizationCodeGrantTypeCode));
				EntityCollection entityCollection = esq.GetEntityCollection(_userConnection);
				return entityCollection.Count > 0 ||
					!hasGrantTypeRelations && IsAuthorizationCodeGrantType(legacyGrantTypeId);
			}
			catch (Exception ex) {
				_log.Warn($"Failed to read OAuth grant type relations for client {clientAppId}. {ex}");
				return IsAuthorizationCodeGrantType(legacyGrantTypeId);
			}
		}

		private List<string> GetAllowedGrantTypes(Guid clientAppId, Guid legacyGrantTypeId) {
			if (_userConnection.EntitySchemaManager.FindInstanceByName("OAuthGrantTypeInClient") == null) {
				string legacyGrantType = FindGrandTypeCode(legacyGrantTypeId);
				return legacyGrantType.IsNullOrEmpty()
					? GetDefaultAllowedGrantTypes()
					: new List<string> { legacyGrantType };
			}
			try {
				var esq = new EntitySchemaQuery(_userConnection.EntitySchemaManager, "OAuthGrantTypeInClient");
				EntitySchemaQueryColumn grantTypeCodeColumn = esq.AddColumn("OAuthGrantType.Code");
				esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "OAuthClientApp",
					clientAppId));
				List<string> grantTypes = esq.GetEntityCollection(_userConnection)
					.Select(entity => entity.GetTypedColumnValue<string>(grantTypeCodeColumn.Name))
					.Where(grantType => !grantType.IsNullOrWhiteSpace())
					.Distinct()
					.ToList();
				if (grantTypes.Any()) {
					return grantTypes;
				}
			}
			catch (Exception ex) {
				_log.Warn($"Failed to read OAuth grant type relations for client {clientAppId}. {ex}");
			}
			string fallbackGrantType = FindGrandTypeCode(legacyGrantTypeId);
			return fallbackGrantType.IsNullOrEmpty()
				? GetDefaultAllowedGrantTypes()
				: new List<string> { fallbackGrantType };
		}

		private EntityCollection GetClientAppAllowedUsers(Guid clientAppId, bool isDeleteAll, Guid[] idsToDelete,
				Guid[] idsToKeep) {
			var esq = new EntitySchemaQuery(_userConnection.EntitySchemaManager, "OAuthAppAllowedUser") {
				PrimaryQueryColumn = { IsAlwaysSelect = true }
			};
			esq.AddColumn("SysUser");
			esq.Filters.Add(
				esq.CreateFilterWithParameters(FilterComparisonType.Equal, "OAuthClientApp", clientAppId));
			if (!isDeleteAll && idsToDelete?.Length > 0) {
				esq.Filters.Add(
					esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Id", idsToDelete.Cast<object>()));
			} else if (isDeleteAll && idsToKeep?.Length > 0) {
				esq.Filters.Add(
					esq.CreateFilterWithParameters(FilterComparisonType.NotEqual, "Id", idsToKeep.Cast<object>()));
			}
			return esq.GetEntityCollection(_userConnection);
		}

		private void MarkUserOAuthIntegrationAsUnactive(Guid clientAppId, Guid userId) {
			var schemaManager = _userConnection.EntitySchemaManager.GetInstanceByName("UserOAuthSharedAccess");
			var entity = schemaManager.CreateEntity(_userConnection);
			entity.UseAdminRights = false;
			var fetchConditions = new Dictionary<string, object> {
				{ "SysUser", userId },
				{ "OAuthClientApp", clientAppId }
			};
			if (entity.FetchFromDB(fetchConditions)) {
				entity.SetColumnValue("Active", false);
				entity.Save(new EntitySaveConfig());
			}
		}

		private void RevokeTokens(Guid clientAppId, List<Guid> userIdList) {
			var schema = _userConnection.EntitySchemaManager.GetInstanceByName("OAuthClientApp");
			var oauthClientApp = schema.CreateEntity(_userConnection);
			if (!oauthClientApp.FetchFromDB(clientAppId, useDisplayValues: false)) {
				return;
			}
			var clientId = oauthClientApp.GetTypedColumnValue<string>("ClientId");
			var revokeTokensRequest = new RevokeClientTokensRequest {
				ClientId = clientId,
				UsersId = userIdList.Select(userId => userId.ToString()).ToArray()
			};
			var revokeTokensRequestHandler = ClassFactory.Get<IRevokeTokensRequestHandler>();
			AsyncPump.Run(() => {
				revokeTokensRequestHandler.HandleAsync(revokeTokensRequest);
			});
		}

		private HashSet<Guid> GetRemainingUsers(Guid clientAppId) {
			var esq = new EntitySchemaQuery(_userConnection.EntitySchemaManager, "OAuthAppAllowedUser") {
				PrimaryQueryColumn = { IsAlwaysSelect = true }
			};
			esq.AddColumn("SysUser");
			esq.Filters.Add(
				esq.CreateFilterWithParameters(FilterComparisonType.Equal, "OAuthClientApp", clientAppId));
			var userTypeFilterGroup = new EntitySchemaQueryFilterCollection(esq, LogicalOperationStrict.Or);
			userTypeFilterGroup.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal,
				"SysUser.SysAdminUnitTypeValue", Core.DB.SysAdminUnitType.User));
			userTypeFilterGroup.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal,
				"SysUser.SysAdminUnitTypeValue", Core.DB.SysAdminUnitType.SelfServicePortalUser));
			userTypeFilterGroup.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal,
				"SysUser.SysAdminUnitTypeValue", Core.DB.SysAdminUnitType.TechnicalUser));
			esq.Filters.Add(userTypeFilterGroup);
			var entityCollection = esq.GetEntityCollection(_userConnection);
			var userIds = new HashSet<Guid>();
			foreach (var entity in entityCollection) {
				var roleId = entity.GetTypedColumnValue<Guid>("SysUserId");
				userIds.Add(roleId);
			}
			return userIds;
		}

		private HashSet<Guid> GetUserIdsByRoles(HashSet<Guid> remainingRolesCollection) {
			var userIds = new HashSet<Guid>();
			if (remainingRolesCollection.IsEmpty()) {
				return userIds;
			}
			var esqUsers = new EntitySchemaQuery(_userConnection.EntitySchemaManager, "SysUserInRole");
			esqUsers.PrimaryQueryColumn.IsAlwaysSelect = true;
			esqUsers.AddColumn("SysUser");
			esqUsers.AddColumn("SysRole");
			var roleFilter = esqUsers.CreateFilterWithParameters(FilterComparisonType.Equal, "SysRole",
				remainingRolesCollection.ToArray().Cast<object>());
			esqUsers.Filters.Add(roleFilter);
			var usersInRolesCollection = esqUsers.GetEntityCollection(_userConnection);
			foreach (var entity in usersInRolesCollection) {
				var userId = entity.GetTypedColumnValue<Guid>("SysUserId");
				userIds.Add(userId);
			}
			return userIds;
		}

		private HashSet<Guid> GetRemainingRoles(Guid clientAppId) {
			var esq = new EntitySchemaQuery(_userConnection.EntitySchemaManager, "OAuthAppAllowedUser") {
				PrimaryQueryColumn = { IsAlwaysSelect = true }
			};
			esq.AddColumn("SysUser");
			esq.Filters.Add(
				esq.CreateFilterWithParameters(FilterComparisonType.Equal, "OAuthClientApp", clientAppId));
			var userTypeFilterGroup = new EntitySchemaQueryFilterCollection(esq, LogicalOperationStrict.Or);
			userTypeFilterGroup.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal,
				"SysUser.SysAdminUnitTypeValue", Core.DB.SysAdminUnitType.Organisation));
			userTypeFilterGroup.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal,
				"SysUser.SysAdminUnitTypeValue", Core.DB.SysAdminUnitType.Department));
			userTypeFilterGroup.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal,
				"SysUser.SysAdminUnitTypeValue", Core.DB.SysAdminUnitType.FunctionalRole));
			esq.Filters.Add(userTypeFilterGroup);
			var entityCollection = esq.GetEntityCollection(_userConnection);
			var roleIds = new HashSet<Guid>();
			foreach (var entity in entityCollection) {
				var roleId = entity.GetTypedColumnValue<Guid>("SysUserId");
				roleIds.Add(roleId);
			}
			return roleIds;
		}

		private HashSet<Guid> GetRoles(EntityCollection clientAppAllowedUsersCollection) {
			var esq = new EntitySchemaQuery(_userConnection.EntitySchemaManager, "SysAdminUnit") {
				PrimaryQueryColumn = { IsAlwaysSelect = true }
			};
			var filterGroup = new EntitySchemaQueryFilterCollection(esq, LogicalOperationStrict.Or);
			IEntitySchemaQueryFilterItem organizationFilter =
				esq.CreateFilterWithParameters(FilterComparisonType.Equal,
					"SysAdminUnitTypeValue", Core.DB.SysAdminUnitType.Organisation);
			IEntitySchemaQueryFilterItem departmentFilter =
				esq.CreateFilterWithParameters(FilterComparisonType.Equal,
					"SysAdminUnitTypeValue", Core.DB.SysAdminUnitType.Department);
			IEntitySchemaQueryFilterItem functionalRoleFilter =
				esq.CreateFilterWithParameters(FilterComparisonType.Equal,
					"SysAdminUnitTypeValue", Core.DB.SysAdminUnitType.FunctionalRole);
			filterGroup.Add(organizationFilter);
			filterGroup.Add(departmentFilter);
			filterGroup.Add(functionalRoleFilter);
			esq.Filters.Add(filterGroup);
			var userIdsFilter = esq.CreateFilterWithParameters(
				FilterComparisonType.Equal, "Id",
				clientAppAllowedUsersCollection.Select(entity => entity.GetTypedColumnValue<Guid>("SysUserId"))
					.Cast<object>());
			esq.Filters.Add(userIdsFilter);
			var entityCollection = esq.GetEntityCollection(_userConnection);
			var roleIds = new HashSet<Guid>();
			foreach (var entity in entityCollection) {
				var roleId = entity.PrimaryColumnValue;
				roleIds.Add(roleId);
			}
			return roleIds;
		}

		private HashSet<Guid> GetUsers(EntityCollection clientAppAllowedUsersCollection) {
			var esq = new EntitySchemaQuery(_userConnection.EntitySchemaManager, "SysAdminUnit") {
				PrimaryQueryColumn = { IsAlwaysSelect = true }
			};
			IEntitySchemaQueryFilterItem userFilter =
				esq.CreateFilterWithParameters(FilterComparisonType.Equal,
					"SysAdminUnitTypeValue", Core.DB.SysAdminUnitType.User);
			esq.Filters.Add(userFilter);
			var userIdsFilter = esq.CreateFilterWithParameters(
				FilterComparisonType.Equal, "Id",
				clientAppAllowedUsersCollection.Select(entity => entity.GetTypedColumnValue<Guid>("SysUserId"))
					.Cast<object>());
			esq.Filters.Add(userIdsFilter);
			var entityCollection = esq.GetEntityCollection(_userConnection);
			var userIds = new HashSet<Guid>();
			foreach (var entity in entityCollection) {
				var userId = entity.PrimaryColumnValue;
				userIds.Add(userId);
			}
			return userIds;
		}

		#endregion

		#region Methods: Internal

		internal void RemoveDefaultResourceNameFromCache() {
			ICacheStore cacheStore = _userConnection.ApplicationCache.WithLocalCaching();
			cacheStore.Remove("DefaultOAuthResourceName");
		}

		#endregion

		#region Methods: Public

		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json,
			ResponseFormat = WebMessageFormat.Json)]
		public AddResourceResponse AddDefaultResource() {
			if (!GlobalAppSettings.FeatureEnableOAuth20Integration) {
				return new AddResourceResponse {
					Success = false,
					ErrorInfo = new ErrorInfo {
						Message = OAuthDisabledMessage
					}
				};
			}
			try {
				OAuthResource resource = CreateResource();
				RedistributeOAuthResourceToExistingClients(resource);
				return new AddResourceResponse {
					Scope = resource.Name
				};
			} catch (Exception e) {
				_log.Error($"Error occured during OAth resource creation: {e}");
				return new AddResourceResponse {
					Exception = e
				};
			}
		}

		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json,
			ResponseFormat = WebMessageFormat.Json)]
		public AddClientResponse AddClient(AddClientRequest addClientRequest) {
			Stopwatch stopwatch = BaseOAuthApiCaller.IsPerfLoggingEnabled ? Stopwatch.StartNew() : null;
			if (!GlobalAppSettings.FeatureEnableOAuth20Integration) {
				return new AddClientResponse {
					Success = false,
					ErrorInfo = new ErrorInfo {
						Message = OAuthDisabledMessage
					}
				};
			}
			if (addClientRequest.InstallIntegration == false
					&& OAuthClientAppInstallStatusHelper.IsCreateNotInstalledEnabled()) {
				// ENG-78572: create the integration in the Not installed state — no Identity Service call,
				// no grant/resource relations. Grants are added later, before Install. Only honored when the
				// create-not-installed feature (F2, which requires F1) is on; otherwise install normally.
				return AddNotInstalledClient(addClientRequest);
			}
			Stopwatch grantTypeValidationStopwatch = BaseOAuthApiCaller.IsPerfLoggingEnabled ? Stopwatch.StartNew() : null;
			var allowedGrantTypes = NormalizeAllowedGrantTypes(addClientRequest.AllowedGrantTypes,
				addClientRequest.GrantType);
			if (!IsGrantTypeValid(addClientRequest.GrantType) || !AreGrantTypesValid(allowedGrantTypes)) {
				return CreateAddClientErrorResponse($"Unknown GrantType: {addClientRequest.GrantType}.");
			}
			BaseOAuthApiCaller.LogPerformance("OAuthConfigService.AddClient.GrantTypeValidation",
				grantTypeValidationStopwatch, $"grants={allowedGrantTypes.Count}.");
			string publicGrantConfigurationError = BaseOAuthApiCaller.GetGrantTypeConfigurationError(_userConnection,
				addClientRequest.IsPublic, addClientRequest.RequirePKCE, allowedGrantTypes);
			if (!publicGrantConfigurationError.IsNullOrWhiteSpace()) {
				return CreateAddClientErrorResponse(publicGrantConfigurationError);
			}
			try {
				var client = new OAuthClientApp(_userConnection);
				client.SetDefColumnValues();
				client.Name = addClientRequest.Name;
				client.ApplicationUrl = addClientRequest.ApplicationUrl;
				client.Description = addClientRequest.Description;
				client.RedirectUrl = addClientRequest.RedirectUrl;
				client.IsActive = true;
				client.IsPublic = addClientRequest.IsPublic;
				client.RequirePKCE = addClientRequest.RequirePKCE;
				string grantTypeCode = allowedGrantTypes.First();
				if (allowedGrantTypes.Contains(ClientCredentialsGrantTypeCode)) {
					if (!IsSysAdminUnitValid(addClientRequest.SystemUserId)) {
						return CreateAddClientErrorResponse("Specified system user is not valid.");
					}
					client.SystemUserId = addClientRequest.SystemUserId;
				}
				Guid grantTypeId = FindGrandTypeId(grantTypeCode);
				if (grantTypeId.IsEmpty()) {
					return CreateAddClientErrorResponse("Specified GrantType not found.");
				}
				client.GrantTypeId = grantTypeId;
				BaseOAuthApiCaller.RememberPendingAllowedGrantTypes(client.PrimaryColumnValue, allowedGrantTypes);
				try {
					Stopwatch saveStopwatch = BaseOAuthApiCaller.IsPerfLoggingEnabled ? Stopwatch.StartNew() : null;
					client.Save();
					BaseOAuthApiCaller.LogPerformance("OAuthConfigService.AddClient.ClientSave", saveStopwatch,
						$"clientAppId='{client.PrimaryColumnValue}'.");
				} finally {
					BaseOAuthApiCaller.ForgetPendingAllowedGrantTypes(client.PrimaryColumnValue);
				}
				BaseOAuthApiCaller.LogPerformance("OAuthConfigService.AddClient", stopwatch,
					$"clientAppId='{client.PrimaryColumnValue}'.");
				return new AddClientResponse {
					ClientAppId = client.PrimaryColumnValue,
					ClientId = client.ClientId,
					ClientSecret = client.ClientSecret
				};
			} catch (Exception e) {
				return new AddClientResponse() {
					Exception = e
				};
			}
		}

		/// <summary>
		/// Creates an OAuthClientApp in the Not installed state (ENG-78572): no Identity Service call, no
		/// grant/resource relations. The listener enforces IsActive=false and, when requested, pre-generates
		/// a ClientId. Grants and configuration are added later, before Install.
		/// </summary>
		private AddClientResponse AddNotInstalledClient(AddClientRequest addClientRequest) {
			try {
				var allowedGrantTypes = NormalizeAllowedGrantTypes(addClientRequest.AllowedGrantTypes,
					addClientRequest.GrantType);
				var client = new OAuthClientApp(_userConnection);
				client.SetDefColumnValues();
				client.Name = addClientRequest.Name;
				client.ApplicationUrl = addClientRequest.ApplicationUrl;
				client.Description = addClientRequest.Description;
				client.RedirectUrl = addClientRequest.RedirectUrl;
				client.IsPublic = addClientRequest.IsPublic;
				client.RequirePKCE = addClientRequest.RequirePKCE;
				if (addClientRequest.SystemUserId != Guid.Empty) {
					client.SystemUserId = addClientRequest.SystemUserId;
				}
				string grantTypeCode = allowedGrantTypes.FirstOrDefault() ?? ClientCredentialsGrantTypeCode;
				Guid grantTypeId = FindGrandTypeId(grantTypeCode);
				if (!grantTypeId.IsEmpty()) {
					client.GrantTypeId = grantTypeId;
				}
				client.SetColumnValue("StatusId", OAuthClientAppInstallStatusHelper.NotInstalledStatusId);
				client.SetColumnValue("IsActive", false);
				if (addClientRequest.GenerateClientId
						&& client.Schema.Columns.FindByName("GenerateClientId") != null) {
					client.SetColumnValue("GenerateClientId", true);
				}
				client.Save();
				return new AddClientResponse {
					ClientAppId = client.PrimaryColumnValue,
					ClientId = client.ClientId,
					ClientSecret = client.ClientSecret
				};
			} catch (Exception e) {
				return new AddClientResponse {
					Exception = e
				};
			}
		}

		/// <summary>
		/// Returns whether the OAuthClientAppInstallStatus feature is enabled (ENG-78572). The creation
		/// mini-pages call this to decide whether to show the "Install integration" / "Generate client id"
		/// controls, since the client-side feature API is not available in the Freedom UI shell.
		/// </summary>
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json,
			ResponseFormat = WebMessageFormat.Json)]
		public InstallStatusFeatureStateResponse GetInstallStatusFeatureState() {
			return new InstallStatusFeatureStateResponse {
				Enabled = OAuthClientAppInstallStatusHelper.IsFeatureEnabled(),
				CanCreateNotInstalled = OAuthClientAppInstallStatusHelper.IsCreateNotInstalledEnabled()
			};
		}

		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json,
			ResponseFormat = WebMessageFormat.Json)]
		public GetAllowedGrantTypesResponse GetAllowedGrantTypes(GetAllowedGrantTypesRequest request) {
			if (!GlobalAppSettings.FeatureEnableOAuth20Integration) {
				return new GetAllowedGrantTypesResponse {
					Success = false,
					ErrorInfo = new ErrorInfo {
						Message = OAuthDisabledMessage
					}
				};
			}
			try {
				var client = new OAuthClientApp(_userConnection);
				bool clientFound = Guid.TryParse(request.ClientAppId, out Guid clientAppId)
					? client.FetchFromDB(clientAppId)
					: client.FetchFromDB(new Dictionary<string, object> {
						{ "ClientId", request.ClientId }
					});
				if (!clientFound) {
					const string message = "Record with specified Id does not exist.";
					return new GetAllowedGrantTypesResponse {
						Success = false,
						ErrorInfo = new ErrorInfo {
							Message = message
						}
					};
				}
				return new GetAllowedGrantTypesResponse {
					AllowedGrantTypes = GetAllowedGrantTypes(client.PrimaryColumnValue, client.GrantTypeId)
				};
			}
			catch (Exception e) {
				return new GetAllowedGrantTypesResponse {
					Exception = e
				};
			}
		}

		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json,
			ResponseFormat = WebMessageFormat.Json)]
		public CreateTechnicalUserResponse CreateTechnicalUser(CreateTechnicalUserRequest createTechnicalUserRequest) {
			if (!GlobalAppSettings.FeatureEnableOAuth20Integration) {
				return new CreateTechnicalUserResponse {
					Success = false,
					ErrorInfo = new ErrorInfo {
						Message = OAuthDisabledMessage
					}
				};
			}
			if (createTechnicalUserRequest?.Name.IsNullOrWhiteSpace() != false) {
				return new CreateTechnicalUserResponse {
					Success = false,
					ErrorInfo = new ErrorInfo {
						Message = "Integration name is required."
					}
				};
			}
			try {
				_userConnection.DBSecurityEngine.CheckCanExecuteOperation("CanManageSolution");
				var technicalUser = CreateTechnicalUserEntity(createTechnicalUserRequest.Name);
				return new CreateTechnicalUserResponse {
					SystemUserId = technicalUser.SystemUserId,
					SystemUserName = technicalUser.SystemUserName
				};
			} catch (Exception e) {
				return new CreateTechnicalUserResponse {
					Exception = e
				};
			}
		}

		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json,
			ResponseFormat = WebMessageFormat.Json)]
		public ConfigurationServiceResponse UpdateClient(UpdateClientRequest updateClientRequest) {
			if (!GlobalAppSettings.FeatureEnableOAuth20Integration) {
				return GetErrorConfigurationServiceResponse(OAuthDisabledMessage);
			}
			try {
				var client = new OAuthClientApp(_userConnection);
				// A Not installed integration has no Identity Service ClientId yet, so fetch it by its local
				// record Id (ClientAppId) instead. Installed/legacy clients continue to be addressed by ClientId.
				bool clientFound;
				if (!updateClientRequest.ClientId.IsNullOrWhiteSpace()) {
					clientFound = client.FetchFromDB(new Dictionary<string, object> {
						{ "ClientId", updateClientRequest.ClientId }
					});
				} else if (updateClientRequest.ClientAppId.HasValue
						&& !updateClientRequest.ClientAppId.Value.IsEmpty()) {
					clientFound = client.FetchFromDB(updateClientRequest.ClientAppId.Value);
				} else {
					return GetErrorConfigurationServiceResponse("Neither ClientId nor ClientAppId is specified.");
				}
				if (!clientFound) {
					const string message = "Record with specified Id does not exist.";
					return GetErrorConfigurationServiceResponse(message);
				}
				var allowedGrantTypes = updateClientRequest.AllowedGrantTypes != null
					? NormalizeAllowedGrantTypes(updateClientRequest.AllowedGrantTypes, null)
					: null;
				if (allowedGrantTypes != null && !AreGrantTypesValid(allowedGrantTypes)) {
					return GetErrorConfigurationServiceResponse("Specified AllowedGrantTypes contains unknown grant type.");
				}
				var effectiveGrantTypes = allowedGrantTypes ??
					GetAllowedGrantTypes(client.PrimaryColumnValue, client.GrantTypeId);
				string grantTypeConfigurationError = GetGrantTypeConfigurationError(client, effectiveGrantTypes);
				if (!grantTypeConfigurationError.IsNullOrWhiteSpace()) {
					return GetErrorConfigurationServiceResponse(grantTypeConfigurationError);
				}
				bool allowsClientCredentials = allowedGrantTypes?.Contains(ClientCredentialsGrantTypeCode)
					?? !IsAuthorizationCodeGrantType(client.GrantTypeId);
				if (allowsClientCredentials && updateClientRequest.SystemUserId != null &&
						!IsSysAdminUnitValid((Guid)updateClientRequest.SystemUserId)) {
					const string message = "Specified system user is not valid.";
					return GetErrorConfigurationServiceResponse(message);
				}
				client.Name = updateClientRequest.Name ?? client.Name;
				client.RedirectUrl = updateClientRequest.RedirectUrl ?? client.RedirectUrl;
				client.ApplicationUrl = updateClientRequest.ApplicationUrl ?? client.ApplicationUrl;
				if (allowsClientCredentials) {
					client.SystemUserId = updateClientRequest.SystemUserId ?? client.SystemUserId;
				} else if (allowedGrantTypes != null) {
					// ENG-88521: client_credentials was removed from an explicitly provided grant-type set.
					// The technical user is only meaningful for the server-to-server flow, so unlink it here by
					// nulling the FK. This Save runs with the pending grant-type set published below
					// (RememberPendingAllowedGrantTypes), so GetClientAppInfoFromEntity already sees
					// client_credentials removed and does not raise the "SystemUser field must be filled in"
					// check. The integration then stops appearing as active in the technical user's
					// "OAuth integrations" detail (filtered by SystemUser), mirroring full deactivation.
					client.SetColumnValue("SystemUserId", null);
				}
				Guid grantTypeIdToPersist = Guid.Empty;
				if (allowedGrantTypes != null && allowedGrantTypes.Any()) {
					grantTypeIdToPersist = FindGrandTypeId(allowedGrantTypes.First());
					if (grantTypeIdToPersist.IsEmpty()) {
						return GetErrorConfigurationServiceResponse(
							"Specified AllowedGrantTypes contains unknown grant type.");
					}
					client.GrantTypeId = grantTypeIdToPersist;
				}
				client.IsActive = updateClientRequest.IsActive ?? client.IsActive;
				bool hasGrantTypesUpdate = allowedGrantTypes != null && allowedGrantTypes.Any();
				if (hasGrantTypesUpdate) {
					// Publish the new grant-type set so the OnUpdating identity sync (fired by Save)
					// receives the updated list before OAuthGrantTypeInClient rows exist.
					BaseOAuthApiCaller.RememberPendingAllowedGrantTypes(client.PrimaryColumnValue, allowedGrantTypes);
				}
				try {
					client.Save();
					if (hasGrantTypesUpdate) {
						SynchronizeClientGrantTypes(client.PrimaryColumnValue, allowedGrantTypes);
					}
				} finally {
					if (hasGrantTypesUpdate) {
						BaseOAuthApiCaller.ForgetPendingAllowedGrantTypes(client.PrimaryColumnValue);
					}
				}
				return new ConfigurationServiceResponse();
			} catch (Exception e) {
				return new ConfigurationServiceResponse(e);
			}
		}

		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public ConfigurationServiceResponse DeleteClient(DeleteClientRequest deleteClientRequest) {
			if (!GlobalAppSettings.FeatureEnableOAuth20Integration) {
				return GetErrorConfigurationServiceResponse(OAuthDisabledMessage);
			}
			try {
				var conditions = new Dictionary<string, object> {
					{ "ClientId", deleteClientRequest.ClientId }
				};
				var client = new OAuthClientApp(_userConnection);
				if (!client.FetchFromDB(conditions)) {
					const string message = "Record with specified Id does not exist.";
					return GetErrorConfigurationServiceResponse(message);
				}
				client.Delete();
				return new ConfigurationServiceResponse();
			}
			catch (Exception e) {
				return new ConfigurationServiceResponse(e);
			}
		}

		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json,
			ResponseFormat = WebMessageFormat.Json)]
		public ConfigurationServiceResponse GrantAccess(UpdateClientScopesRequest grantAccessRequest) {
			if (!GlobalAppSettings.FeatureEnableOAuth20Integration) {
				return GetErrorConfigurationServiceResponse(OAuthDisabledMessage);
			}
			try {
				if (IsResourceInClientAlreadyExists(grantAccessRequest.ClientId, grantAccessRequest.ResourceName)) {
					const string message = "Specified client application already has access to specified resource.";
					return GetErrorConfigurationServiceResponse(message);
				}
				if (!TryGetClientAppIdByClientId(grantAccessRequest.ClientId, out Guid clientAppId)) {
					const string message = "Client with specified clientId does not exist.";
					return GetErrorConfigurationServiceResponse(message);
				}
				if (!TryGetResourceIdByName(grantAccessRequest.ResourceName, out Guid resourceId)) {
					const string message = "Resource with specified name does not exist.";
					return GetErrorConfigurationServiceResponse(message);
				}
				CreateOAuthResourceInClient(clientAppId, resourceId);
				return new ConfigurationServiceResponse();
			} catch (Exception e) {
				return new ConfigurationServiceResponse(e);
			}
		}

		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json,
			ResponseFormat = WebMessageFormat.Json)]
		public ConfigurationServiceResponse DeleteScope(UpdateClientScopesRequest removeClientScopesRequest) {
			if (!GlobalAppSettings.FeatureEnableOAuth20Integration) {
				return GetErrorConfigurationServiceResponse(OAuthDisabledMessage);
			}
			try {
				if (!IsResourceInClientAlreadyExists(removeClientScopesRequest.ClientId,
						removeClientScopesRequest.ResourceName)) {
					const string message = "Specified client application already has no access to specified resource.";
					return GetErrorConfigurationServiceResponse(message);
				}
				if (!TryGetClientAppIdByClientId(removeClientScopesRequest.ClientId, out Guid clientAppId)) {
					const string message = "Client with specified clientId does not exist.";
					return GetErrorConfigurationServiceResponse(message);
				}
				if (!TryGetResourceIdByName(removeClientScopesRequest.ResourceName, out Guid resourceId)) {
					const string message = "Resource with specified name does not exist.";
					return GetErrorConfigurationServiceResponse(message);
				}
				var conditions = new Dictionary<string, object> {
					{ "OAuthClient", clientAppId },
					{ "OAuthResource", resourceId }
				};
				var client = new OAuthResourceInClient(_userConnection);
				if (!client.FetchFromDB(conditions)) {
					const string message = "Record with specified OAuthClientId and OAuthResourceId does not exist.";
					return GetErrorConfigurationServiceResponse(message);
				}
				client.Delete();
				return new ConfigurationServiceResponse();
			}
			catch (Exception e) {
				return new ConfigurationServiceResponse(e);
			}
		}

		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public ClientSecretResponse GetClientSecret(Guid clientAppId) {
			_userConnection.DBSecurityEngine.CheckCanExecuteOperation("CanManageSolution");
			var client = new OAuthClientApp(_userConnection);
			if (client.FetchFromDB(clientAppId)) {
				return new ClientSecretResponse {
					ClientSecret = client.ClientSecret
				};
			}
			const string message = "Client with specified Id does not exist.";
			return new ClientSecretResponse {
				Success = false,
				ErrorInfo = new ErrorInfo {
					Message = message
				}
			};
		}

		/// <summary>
		/// Reports whether an Identity Server client secret is currently stored, WITHOUT ever
		/// returning the secret itself (ENG-92697). Replaces the former
		/// <c>GetIdentityServerClientSecret</c>, which returned the plaintext secret to the OAuth
		/// Settings modal and thus leaked it over the network and into the browser DOM. The modal
		/// uses the flag to render a write-only field: a masked placeholder when a secret exists,
		/// an empty field otherwise. Reads the same
		/// <c>OAuth20IdentityServerClientSecret</c> / legacy <c>IdentityServerClientSecret</c>
		/// system setting (depending on <c>FeatureUseSeparateSettingsForOAuth20</c>) that the
		/// save flow writes to.
		/// </summary>
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public ClientSecretStatusResponse GetIdentityServerClientSecretStatus() {
			if (!GlobalAppSettings.FeatureEnableOAuth20Integration) {
				return new ClientSecretStatusResponse {
					Success = false,
					ErrorInfo = new ErrorInfo {
						Message = OAuthDisabledMessage
					}
				};
			}
			_userConnection.DBSecurityEngine.CheckCanExecuteOperation("CanManageSolution");
			string clientSecretSettingCode = GlobalAppSettings.FeatureUseSeparateSettingsForOAuth20
				? "OAuth20IdentityServerClientSecret"
				: "IdentityServerClientSecret";
			var secret = SysSettings.GetValue(_userConnection, clientSecretSettingCode, string.Empty);
			bool hasClientSecret = !string.IsNullOrEmpty(secret);
			_log.Debug($"GetIdentityServerClientSecretStatus invoked by '{_userConnection.CurrentUser.Name}' " +
				$"(setting code: {clientSecretSettingCode}, hasValue: {hasClientSecret})");
			return new ClientSecretStatusResponse {
				HasClientSecret = hasClientSecret
			};
		}

		/// <summary>
		/// Tests the connection to the Identity Server from the OAuth Settings modal (ENG-92697).
		/// The <c>serverUrl</c> and <c>clientId</c> come from the (non-secret) form fields. The
		/// <c>clientSecret</c> is used only when the user actually re-typed it; when it is empty
		/// (the write-only field was left untouched) the currently stored secret is used, so the
		/// admin can validate the existing configuration without the plaintext secret ever being
		/// sent to the browser. The secret never leaves the server in the response either.
		/// </summary>
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public TestConnectionResponse TestIdentityServerConnection(OAuthSettingsRequest settingsRequest) {
			if (!GlobalAppSettings.FeatureEnableOAuth20Integration) {
				return new TestConnectionResponse {
					Success = false,
					ErrorInfo = new ErrorInfo {
						Message = OAuthDisabledMessage
					}
				};
			}
			try {
				_userConnection.DBSecurityEngine.CheckCanExecuteOperation("CanManageSolution");
				string clientSecret = settingsRequest.ClientSecret;
				if (string.IsNullOrEmpty(clientSecret)) {
					string clientSecretSettingCode = GlobalAppSettings.FeatureUseSeparateSettingsForOAuth20
						? "OAuth20IdentityServerClientSecret"
						: "IdentityServerClientSecret";
					clientSecret = SysSettings.GetValue(_userConnection, clientSecretSettingCode, string.Empty);
				}
				var testService = new TestOAuthConnectionService(settingsRequest.ServerUrl,
					settingsRequest.ClientId, clientSecret);
				bool connected = testService.TestConnection();
				return new TestConnectionResponse {
					Connected = connected
				};
			} catch (Exception e) {
				return new TestConnectionResponse {
					Success = false,
					ErrorInfo = new ErrorInfo {
						Message = e.Message
					}
				};
			}
		}

		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public ConfigurationServiceResponse ConfigureIdentityProvider(OAuthSettingsRequest settingsRequest)	{
			if (!GlobalAppSettings.FeatureEnableOAuth20Integration) {
				return GetErrorConfigurationServiceResponse(OAuthDisabledMessage);
			}
			try {
				_userConnection.DBSecurityEngine.CheckCanExecuteOperation("CanManageSolution");
				string serverUrlSettingCode = GlobalAppSettings.FeatureUseSeparateSettingsForOAuth20
					? "OAuth20IdentityServerUrl"
					: "IdentityServerUrl";
				string clientIdSettingCode = GlobalAppSettings.FeatureUseSeparateSettingsForOAuth20
					? "OAuth20IdentityServerClientId"
					: "IdentityServerClientId";
				string clientSecretSettingCode = GlobalAppSettings.FeatureUseSeparateSettingsForOAuth20
					? "OAuth20IdentityServerClientSecret"
					: "IdentityServerClientSecret";
				SysSettings.SetDefValue(_userConnection, clientIdSettingCode, settingsRequest.ClientId);
				// Skip empty secret so the dirty-tracking flow on the OAuth Settings modal
				// (which sends an empty string when the user did not re-type the secret)
				// never wipes the existing value in SysSettings.
				if (!string.IsNullOrEmpty(settingsRequest.ClientSecret)) {
					SysSettings.SetDefValue(_userConnection, clientSecretSettingCode, settingsRequest.ClientSecret);
				}
				SysSettings.SetDefValue(_userConnection, serverUrlSettingCode, settingsRequest.ServerUrl);
				var resource = new OAuthResource(_userConnection);
				if (!TryFetchDefaultResource(resource)) {
					CreateResource();
				}
				return new ConfigurationServiceResponse();
			} catch (Exception e) {
				return new ConfigurationServiceResponse(e);
			}
		}

		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json,
			ResponseFormat = WebMessageFormat.Json)]
		public ConfigurationServiceResponse AddAllowedUsersToOAuthClientApp(Guid clientAppId, Guid[] userIds) {
			try {
				if (!GlobalAppSettings.FeatureEnableOAuth20Integration) {
					return GetErrorConfigurationServiceResponse(OAuthDisabledMessage);
				}
				var schemaManager = _userConnection.EntitySchemaManager;
				foreach (var userId in userIds) {
					var entity = schemaManager.GetEntityByName("OAuthAppAllowedUser", _userConnection);
					var conditions = new Dictionary<string, object> {
						{ "OAuthClientApp", clientAppId },
						{ "SysUser", userId }
					};
					if (!entity.FetchFromDB(conditions)) {
						entity.SetDefColumnValues();
						entity.SetColumnValue("OAuthClientAppId", clientAppId);
						entity.SetColumnValue("SysUserId", userId);
						entity.Save(new EntitySaveConfig());
					}
				}
				return new ConfigurationServiceResponse();
			} catch (Exception e) {
				return new ConfigurationServiceResponse(e);
			}
		}

		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json,
			ResponseFormat = WebMessageFormat.Json)]
		public ConfigurationServiceResponse RemoveUsersFromOAuthClientApp(Guid clientAppId, bool isDeleteAll,
				Guid[] idsToDelete, Guid[] idsToKeep) {
			if (!GlobalAppSettings.FeatureEnableOAuth20Integration) {
				return GetErrorConfigurationServiceResponse(OAuthDisabledMessage);
			}
			try {
				var clientAppAllowedUsersCollection = GetClientAppAllowedUsers(
					clientAppId, isDeleteAll, idsToDelete, idsToKeep);
				var schemaManager = _userConnection.EntitySchemaManager;
				var entity = schemaManager.GetEntityByName("OAuthAppAllowedUser", _userConnection);
				foreach (var clientAppAllowedUser in clientAppAllowedUsersCollection) {
					entity.Delete(clientAppAllowedUser.PrimaryColumnValue);
				}
				var rolesToRemove = GetRoles(clientAppAllowedUsersCollection);
				var usersToRemoveDirectly = GetUsers(clientAppAllowedUsersCollection);
				var usersToRemove = GetUserIdsByRoles(rolesToRemove);
				usersToRemove.UnionWith(usersToRemoveDirectly);
				var remainingUsers = GetRemainingUsers(clientAppId);
				var remainingRolesCollection = GetRemainingRoles(clientAppId);
				var userIdsInRemainingRoles = GetUserIdsByRoles(remainingRolesCollection);
				userIdsInRemainingRoles.UnionWith(remainingUsers);
				var usersToRemoveFinal = usersToRemove.Except(userIdsInRemainingRoles).ToList();
				if (usersToRemoveFinal.Any()) {
					RevokeTokens(clientAppId, usersToRemoveFinal);
					foreach (Guid userId in usersToRemoveFinal) {
						MarkUserOAuthIntegrationAsUnactive(clientAppId, userId);
					}
				}
				return new ConfigurationServiceResponse();
			} catch (Exception e) {
				return new ConfigurationServiceResponse(e);
			}
		}

		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json,
			ResponseFormat = WebMessageFormat.Json)]
		public RedirectUrlsResponse AddRedirectUrls(RedirectUrlsRequest redirectUrlsRequest) {
			if(!GlobalAppSettings.FeatureEnableOAuth20Integration) {
				return new RedirectUrlsResponse {
					Success = false,
					ErrorInfo = new ErrorInfo {
						Message = OAuthDisabledMessage
					}
				};
			}
			try {
				var conditions = new Dictionary<string, object> {
					{ "ClientId", redirectUrlsRequest.ClientId }
				};
				var client = new OAuthClientApp(_userConnection);
				if (!client.FetchFromDB(conditions)) {
					string message = $"Record with specified ClientId: {redirectUrlsRequest.ClientId} does not exist.";
					return new RedirectUrlsResponse {
						Success = false,
						ErrorInfo = new ErrorInfo {
							Message = message
						}
					};
				}
				if (!ClientAllowsAuthorizationCode(client.PrimaryColumnValue, client.GrantTypeId)) {
					string message = $"You cannot add RedirectUrls to a record without GrantType: {AuthorizationCodeGrantTypeCode}. " +
						$"It is allowed to add RedirectUrls to a record with GrantType: {AuthorizationCodeGrantTypeCode}";
					return new RedirectUrlsResponse {
						Success = false,
						ErrorInfo = new ErrorInfo {
							Message = message
						}
					};
				}
				Dictionary<Guid, string> result = new Dictionary<Guid, string>();
				foreach (var item in redirectUrlsRequest.RedirectUrls) {
					var redirectUrlInOAuthClientApp = new RedirectUrlInOAuthClientApp(_userConnection);
					redirectUrlInOAuthClientApp.SetDefColumnValues();
					redirectUrlInOAuthClientApp.OAuthClientAppId = client.PrimaryColumnValue;
					redirectUrlInOAuthClientApp.RedirectUrl = item;
					redirectUrlInOAuthClientApp.Save();
					result.Add(redirectUrlInOAuthClientApp.PrimaryColumnValue, redirectUrlInOAuthClientApp.RedirectUrl);
				}
				return new RedirectUrlsResponse {
					RedirectUrls = result
				};
			} catch (Exception e) {
				return new RedirectUrlsResponse {
					Exception = e
				};
			}
		}

		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json,
			ResponseFormat = WebMessageFormat.Json)]
		public ConfigurationServiceResponse UpdateRedirectUrl(UpdateRedirectUrlRequest updateRedirectUrlRequest) {
			if (!GlobalAppSettings.FeatureEnableOAuth20Integration) {
				return GetErrorConfigurationServiceResponse(OAuthDisabledMessage);
			}
			try {
				var conditions = new Dictionary<string, object> {
					{ "Id", updateRedirectUrlRequest.RedirectUrlId }
				};
				var redirectUrlInOAuthClientApp = new RedirectUrlInOAuthClientApp(_userConnection);
				if (!redirectUrlInOAuthClientApp.FetchFromDB(conditions)) {
					const string message = "Record with specified RedirectUrlId does not exist.";
					return GetErrorConfigurationServiceResponse(message);
				}
				redirectUrlInOAuthClientApp.RedirectUrl = updateRedirectUrlRequest.RedirectUrl ?? redirectUrlInOAuthClientApp.RedirectUrl;
				redirectUrlInOAuthClientApp.Save();
				return new ConfigurationServiceResponse();
			} catch (Exception e) {
				return new ConfigurationServiceResponse(e);
			}
		}

		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped, 
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public ConfigurationServiceResponse DeleteRedirectUrl(DeleteRedirectUrlRequest deleteRedirectUrlRequest) {
			if (!GlobalAppSettings.FeatureEnableOAuth20Integration) {
				return GetErrorConfigurationServiceResponse(OAuthDisabledMessage);
			}
			try {
				var conditions = new Dictionary<string, object> {
					{ "Id", deleteRedirectUrlRequest.RedirectUrlId }
				};
				var redirectUrlInOAuthClientApp = new RedirectUrlInOAuthClientApp(_userConnection);
				if (!redirectUrlInOAuthClientApp.FetchFromDB(conditions)) {
					const string message = "Record with specified RedirectUrlId does not exist.";
					return GetErrorConfigurationServiceResponse(message);
				}
				redirectUrlInOAuthClientApp.Delete();
				return new ConfigurationServiceResponse();
			}
			catch (Exception e) {
				return new ConfigurationServiceResponse(e);
			}
		}

		#endregion

	}

	#endregion

}


