namespace Terrasoft.Configuration.OAuth20
{
	using Creatio.FeatureToggling;
	using System;
	using System.Collections.Generic;
	using System.Diagnostics;
	using System.Linq;
	using global::Common.Logging;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Entities.Events;
	using Terrasoft.Core.OAuth;
	using Terrasoft.Core.Store;
	using Terrasoft.OAuthIntegration;
	using Terrasoft.OAuthIntegration.DTO;
	using Terrasoft.OAuthIntegration.Exception;

	#region Class: OAuthClientAppListener

	[EntityEventListener(SchemaName = "OAuthClientApp")]
	public class OAuthClientAppListener : BaseOAuthApiCaller
	{

		#region Constants: Private

		private const string ClientCredentialsGrantTypeCode = "client_credentials";

		/// <summary>Feature toggle that gates the install/not-installed lifecycle (ENG-78572).</summary>
		private const string InstallStatusFeatureCode = "OAuthClientAppInstallStatus";

		/// <summary>
		/// Name of the non-stored boolean column the creation mini-page sets to request a pre-generated
		/// <c>ClientId</c> for a not-installed integration. Never persisted to the database (AC 5b).
		/// </summary>
		private const string GenerateClientIdColumnName = "GenerateClientId";

		/// <summary>Id of the <c>OAuthClientAppStatus</c> lookup record "Installed".</summary>
		private static readonly Guid InstalledStatusId = new Guid("87f2cf13-71e7-4f69-8dd8-19d3c4d2cd69");

		/// <summary>Id of the <c>OAuthClientAppStatus</c> lookup record "Not installed".</summary>
		private static readonly Guid NotInstalledStatusId = new Guid("273670c2-d2ef-4c6a-b0f4-44b43e08bab7");

		#endregion

		#region Fields: Private

		private static readonly ILog _log = LogManager.GetLogger("OAuth20");

		#endregion

		#region Constructors: Public

		public OAuthClientAppListener() : base(new Dictionary<Type, string>() {
			{ typeof(ApiServerException), "LocalizableStrings.ClientApplicationHandlingErrorMessage.Value" },
			{ typeof(ApiServerConnectivityException), "LocalizableStrings.ConnectionErrorMessage.Value" }
		}) {}

		#endregion

		#region Methods: Private

		private void CreateOAuthResourceInClient(Guid clientAppId, Guid resourceId, UserConnection userConnection) {
			var resourceInClient = new OAuthResourceInClient(userConnection);
			resourceInClient.SetDefColumnValues();
			resourceInClient.OAuthClientId = clientAppId;
			resourceInClient.OAuthResourceId = resourceId;
			resourceInClient.Save();
		}

		private static EntitySchema GetOAuthGrantTypeInClientSchema(UserConnection userConnection) {
			return userConnection.EntitySchemaManager.FindInstanceByName("OAuthGrantTypeInClient");
		}

		private static bool HasOAuthGrantTypeRelations(Guid clientAppId, UserConnection userConnection) {
			Stopwatch stopwatch = IsPerfLoggingEnabled ? Stopwatch.StartNew() : null;
			EntitySchema relationSchema = GetOAuthGrantTypeInClientSchema(userConnection);
			if (relationSchema == null) {
				return false;
			}
			var esq = new EntitySchemaQuery(relationSchema) {
				PrimaryQueryColumn = { IsAlwaysSelect = true },
				RowCount = 1
			};
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "OAuthClientApp", clientAppId));
			bool hasRelations = esq.GetEntityCollection(userConnection).Count > 0;
			BaseOAuthApiCaller.LogPerformance("OAuthClientAppListener.HasOAuthGrantTypeRelations", stopwatch,
				$"clientAppId='{clientAppId}' result={hasRelations}.");
			return hasRelations;
		}

		private static Guid GetOAuthGrantTypeIdByCode(UserConnection userConnection, string grantTypeCode) {
			Stopwatch stopwatch = IsPerfLoggingEnabled ? Stopwatch.StartNew() : null;
			var schema = userConnection.EntitySchemaManager.GetInstanceByName("OAuthGrantType");
			Entity grantType = schema.CreateEntity(userConnection);
			Guid grantTypeId = grantType.FetchFromDB("Code", grantTypeCode, useDisplayValues: false)
				? grantType.PrimaryColumnValue
				: Guid.Empty;
			BaseOAuthApiCaller.LogPerformance("OAuthClientAppListener.GetOAuthGrantTypeIdByCode", stopwatch,
				$"grantTypeCode='{grantTypeCode}' found={!grantTypeId.IsEmpty()}.");
			return grantTypeId;
		}

		private static Guid GetClientGrantTypeId(Entity entity) {
			Guid grantTypeId = entity.GetTypedColumnValue<Guid>("GrantTypeId");
			return grantTypeId.IsEmpty()
				? GetOAuthGrantTypeIdByCode(entity.UserConnection, ClientCredentialsGrantTypeCode)
				: grantTypeId;
		}

		private static void EnsureOAuthGrantTypeRelations(Entity entity, IEnumerable<string> grantTypeCodes = null) {
			Stopwatch stopwatch = IsPerfLoggingEnabled ? Stopwatch.StartNew() : null;
			EntitySchema relationSchema = GetOAuthGrantTypeInClientSchema(entity.UserConnection);
			if (relationSchema == null) {
				return;
			}
			Guid clientAppId = entity.PrimaryColumnValue;
			if (clientAppId.IsEmpty() || HasOAuthGrantTypeRelations(clientAppId, entity.UserConnection)) {
				return;
			}
			List<string> normalizedGrantTypeCodes = grantTypeCodes?
				.Where(grantTypeCode => !grantTypeCode.IsNullOrWhiteSpace())
				.Distinct()
				.ToList() ?? new List<string>();
			if (!normalizedGrantTypeCodes.Any()) {
				Guid fallbackGrantTypeId = GetClientGrantTypeId(entity);
				if (fallbackGrantTypeId.IsEmpty()) {
					_log.Warn($"Unable to create OAuth grant type relation for client {clientAppId}: grant type not found.");
					return;
				}
				Entity relation = relationSchema.CreateEntity(entity.UserConnection);
				relation.SetDefColumnValues();
				relation.SetColumnValue("OAuthClientAppId", clientAppId);
				relation.SetColumnValue("OAuthGrantTypeId", fallbackGrantTypeId);
				relation.Save();
				BaseOAuthApiCaller.LogPerformance("OAuthClientAppListener.EnsureOAuthGrantTypeRelations", stopwatch,
					$"clientAppId='{clientAppId}' created=1 source='fallback'.");
				return;
			}
			int createdRelationsCount = 0;
			foreach (string grantTypeCode in normalizedGrantTypeCodes) {
				Guid grantTypeId = GetOAuthGrantTypeIdByCode(entity.UserConnection, grantTypeCode);
				if (grantTypeId.IsEmpty()) {
					_log.Warn($"Unable to create OAuth grant type relation for client {clientAppId}: grant type '{grantTypeCode}' not found.");
					continue;
				}
				Entity relation = relationSchema.CreateEntity(entity.UserConnection);
				relation.SetDefColumnValues();
				relation.SetColumnValue("OAuthClientAppId", clientAppId);
				relation.SetColumnValue("OAuthGrantTypeId", grantTypeId);
				BaseOAuthApiCaller.RememberPendingGrantTypeSyncSkips(clientAppId, 1);
				relation.Save();
				createdRelationsCount++;
			}
			BaseOAuthApiCaller.LogPerformance("OAuthClientAppListener.EnsureOAuthGrantTypeRelations", stopwatch,
				$"clientAppId='{clientAppId}' created={createdRelationsCount} source='explicit'.");
		}

		private static void DeleteOAuthGrantTypeRelations(Entity entity) {
			EntitySchema relationSchema = GetOAuthGrantTypeInClientSchema(entity.UserConnection);
			if (relationSchema == null) {
				return;
			}
			var esq = new EntitySchemaQuery(relationSchema) {
				PrimaryQueryColumn = { IsAlwaysSelect = true }
			};
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "OAuthClientApp",
				entity.PrimaryColumnValue));
			EntityCollection relations = esq.GetEntityCollection(entity.UserConnection);
			var relationItems = new List<Entity>(relations.Count);
			foreach (Entity relation in relations) {
				relationItems.Add(relation);
			}
			foreach (Entity relation in relationItems) {
				relation.Delete();
			}
		}

		private Guid GetOAuthDefaultResourceId(UserConnection userConnection) {
			var esq = new EntitySchemaQuery(userConnection.EntitySchemaManager, "OAuthResource");
			EntitySchemaQueryColumn columnId = esq.AddColumn("Id");
			IEntitySchemaQueryFilterItem isDefaultFilter =
				esq.CreateFilterWithParameters(FilterComparisonType.Equal, "IsDefault", true);
			esq.Filters.Add(isDefaultFilter);
			EntityCollection entityCollection = esq.GetEntityCollection(userConnection);
			if (entityCollection.Count == 1) {
				return entityCollection[0].GetTypedColumnValue<Guid>(columnId.Name);
			} else if (entityCollection.Count > 1) {
				string message = new LocalizableString(userConnection.ResourceStorage, "OAuthClientAppListener",
					"LocalizableStrings.MoreThanOneDefaultResourceMessage.Value");
				throw new OAuthClientAppException(message);
			} else {
				string message = new LocalizableString(userConnection.ResourceStorage, "OAuthClientAppListener",
					"LocalizableStrings.NoDefaultResourceMessage.Value");
				throw new OAuthClientAppException(message);
			}
		}

		private OAuthDefaultResourceInfo GetOAuthDefaultResource(UserConnection userConnection) {
			Stopwatch stopwatch = IsPerfLoggingEnabled ? Stopwatch.StartNew() : null;
			var esq = new EntitySchemaQuery(userConnection.EntitySchemaManager, "OAuthResource");
			EntitySchemaQueryColumn columnId = esq.AddColumn("Id");
			EntitySchemaQueryColumn columnName = esq.AddColumn("Name");
			IEntitySchemaQueryFilterItem isDefaultFilter =
				esq.CreateFilterWithParameters(FilterComparisonType.Equal, "IsDefault", true);
			esq.Filters.Add(isDefaultFilter);
			EntityCollection entityCollection = esq.GetEntityCollection(userConnection);
			BaseOAuthApiCaller.LogPerformance("OAuthClientAppListener.GetOAuthDefaultResource", stopwatch,
				$"rows={entityCollection.Count}.");
			if (entityCollection.Count == 1) {
				return new OAuthDefaultResourceInfo {
					Id = entityCollection[0].GetTypedColumnValue<Guid>(columnId.Name),
					Name = entityCollection[0].GetTypedColumnValue<string>(columnName.Name)
				};
			} else if (entityCollection.Count > 1) {
				string message = new LocalizableString(userConnection.ResourceStorage, "OAuthClientAppListener",
					"LocalizableStrings.MoreThanOneDefaultResourceMessage.Value");
				throw new OAuthClientAppException(message);
			} else {
				string message = new LocalizableString(userConnection.ResourceStorage, "OAuthClientAppListener",
					"LocalizableStrings.NoDefaultResourceMessage.Value");
				throw new OAuthClientAppException(message);
			}
		}

		private void ClearCacheForClientId(UserConnection userConnection, string clientId) {
			ICacheStore cacheStore = userConnection.ApplicationCache.WithLocalCaching();
			string cacheKey = $"OAuth_GetActivityStatusByClientId_{clientId}";
			cacheStore.Remove(cacheKey);
		}

		private void ClearConsentModeCache(UserConnection userConnection, string clientId) {
			if (!Features.GetIsEnabled("EnableOAuthClientDisableConsent")) {
				return;
			}
			ICacheStore cacheStore = userConnection.ApplicationCache.WithLocalCaching();
			string cacheKey = string.Format(OAuthConstants.OAuthClientConsentModeCacheKeyTemplate, clientId);
			cacheStore.Remove(cacheKey);
		}

		private void RemoveClientFromIdentityService(Entity entity) {
			string clientId = entity.GetTypedColumnValue<string>("ClientId");
			if (clientId.IsNullOrWhiteSpace()) {
				_log.Warn($"Skipping Identity Service client removal for OAuth client {entity.PrimaryColumnValue}: ClientId is empty.");
				return;
			}
			try {
				IdentityServiceWrapper.RemoveClient(clientId);
			}
			catch (ApiServerException ex) {
				_log.Error($"Identity Service client removal failed for OAuth client {entity.PrimaryColumnValue}. Local delete will continue, leaving the identity-side record orphaned.", ex);
			}
			catch (ApiServerConnectivityException ex) {
				_log.Error($"Identity Service is unavailable during OAuth client {entity.PrimaryColumnValue} removal. Local delete will continue, leaving the identity-side record orphaned.", ex);
			}
		}

		#endregion

		#region Methods: Private (Install status, ENG-78572)

		private static bool IsInstallStatusFeatureEnabled() {
			return Features.GetIsEnabled(InstallStatusFeatureCode);
		}

		private static Guid GetStatusId(Entity entity) {
			return entity.Schema.Columns.FindByName("Status") == null
				? Guid.Empty
				: entity.GetTypedColumnValue<Guid>("StatusId");
		}

		private static bool IsNotInstalled(Entity entity) {
			return GetStatusId(entity) == NotInstalledStatusId;
		}

		private static bool IsStatusModified(Entity entity) {
			// EntityBeforeEventArgs has no ModifiedColumnValues, so detect the change on the entity itself.
			return entity.GetChangedColumnValues().Any(columnValue => columnValue.Name == "StatusId");
		}

		private static string GetListenerLocalizableString(Entity entity, string key) {
			return new LocalizableString(entity.UserConnection.ResourceStorage, "OAuthClientAppListener", key);
		}

		/// <summary>
		/// When the mini-page requested a pre-generated <c>ClientId</c> for a not-installed integration,
		/// fills <c>ClientId</c> using the Identity Service generator without contacting the service.
		/// <c>ClientSecret</c> is intentionally left empty (AC 5b).
		/// </summary>
		private void TryPreGenerateClientId(Entity entity) {
			if (entity.Schema.Columns.FindByName(GenerateClientIdColumnName) == null) {
				return;
			}
			bool shouldGenerate = entity.GetTypedColumnValue<bool>(GenerateClientIdColumnName);
			// The flag is transient (AC 5b): reset it so it is never persisted as true.
			entity.SetColumnValue(GenerateClientIdColumnName, false);
			if (shouldGenerate && entity.GetTypedColumnValue<string>("ClientId").IsNullOrWhiteSpace()) {
				entity.SetColumnValue("ClientId", IdentityServiceWrapper.GenerateClientId());
			}
		}

		private void ValidateInstallPrerequisites(Entity entity) {
			if (!HasOAuthGrantTypeRelations(entity.PrimaryColumnValue, entity.UserConnection)) {
				ThrowException(GetListenerLocalizableString(entity,
					"LocalizableStrings.NoGrantTypeForInstallMessage.Value"));
			}
		}

		/// <summary>
		/// Performs the Not installed -> Installed transition inside the entity Save: validates
		/// prerequisites, registers the client in the Identity Service (honoring any pre-generated
		/// <c>ClientId</c>), and persists the returned credentials with <c>IsActive = true</c>.
		/// Any exception aborts the Save so Status stays Not installed (AC 12).
		/// </summary>
		private void HandleInstallTransition(Entity entity, EntityBeforeEventArgs e) {
			// A Not installed record carries its grant type only in the GrantType column — no
			// OAuthGrantTypeInClient relations are created on insert (AC 5). Materialize the relation(s) from
			// that column now so the install has a valid flow; the sibling grant-type listener still skips the
			// Identity sync because the record is not yet committed as Installed (ENG-78572).
			EnsureOAuthGrantTypeRelations(entity);
			ValidateInstallPrerequisites(entity);
			entity.SetColumnValue("IsActive", true);
			ClientAppInfo clientAppResponse = null;
			ClientAppInfoRequest clientAppRequest = GetClientAppInfoFromEntity(entity);
			ExecuteApiCall(() => clientAppResponse = IdentityServiceWrapper.AddClient(clientAppRequest),
				entity.UserConnection, e);
			entity.SetColumnValue("RequirePKCE", clientAppRequest.RequirePkce);
			entity.SetColumnValue("ClientId", clientAppResponse.ClientId);
			entity.SetColumnValue("ClientSecret", clientAppResponse.Secret);
		}

		private static bool IsInstallTransitionCommitted(Entity entity, EntityAfterEventArgs e) {
			return e.ModifiedColumnValues != null
				&& e.ModifiedColumnValues.FindByName("StatusId") != null
				&& entity.GetTypedColumnValue<Guid>("StatusId") == InstalledStatusId;
		}

		private void EnsureDefaultResourceRelation(Entity entity) {
			OAuthDefaultResourceInfo defaultOAuthResource = GetOAuthDefaultResource(entity.UserConnection);
			CreateOAuthResourceInClient(entity.PrimaryColumnValue, defaultOAuthResource.Id, entity.UserConnection);
		}

		#endregion

		#region Methods: Protected

		protected override void ThrowException(string errorMsg) => throw new OAuthClientAppException(errorMsg);

		#endregion

		#region Methods: Public

		/// <summary>
		/// Handles entity Saved event.
		/// </summary>
		/// <param name="sender">Event sender.</param>
		/// <param name="e">The <see cref="T:Terrasoft.Core.Entities.EntityAfterEventArgs" /> instance containing the
		/// event data.</param>
		public override void OnInserting(object sender, EntityBeforeEventArgs e) {
			CheckCanManageSolution(sender);
			var entity = (Entity)sender;
			if (IsInstallStatusFeatureEnabled() && IsNotInstalled(entity)) {
				// Not installed: do not register in the Identity Service. A not-installed integration is never
				// active (AC 5); enforce it here so the invariant holds on any call path, not only the UI.
				entity.SetColumnValue("IsActive", false);
				// Optionally pre-generate a ClientId so it can be reused on a later Install (AC 5b).
				TryPreGenerateClientId(entity);
				return;
			}
			Stopwatch stopwatch = IsPerfLoggingEnabled ? Stopwatch.StartNew() : null;
			try {
				base.OnInserting(sender, e);
				ClientAppInfo clientAppResponse = null;
				ClientAppInfoRequest clientAppRequest = GetClientAppInfoFromEntity(entity);
				ExecuteApiCall(() => clientAppResponse = IdentityServiceWrapper.AddClient(clientAppRequest), entity.UserConnection, e);
				entity.SetColumnValue("RequirePKCE", clientAppRequest.RequirePkce);
				entity.SetColumnValue("ClientId", clientAppResponse.ClientId);
				entity.SetColumnValue("ClientSecret", clientAppResponse.Secret);
				BaseOAuthApiCaller.LogPerformance("OAuthClientAppListener.OnInserting", stopwatch,
					$"clientAppId='{entity.PrimaryColumnValue}'.");
			} catch {
				BaseOAuthApiCaller.ForgetPendingAllowedGrantTypes(entity.PrimaryColumnValue);
				throw;
			}
		}

		/// <inheritdoc />
		public override void OnInserted(object sender, EntityAfterEventArgs e) {
			if (IsInstallStatusFeatureEnabled() && IsNotInstalled((Entity)sender)) {
				// Not installed: no Identity sync, no default resource / grant-type relations (AC 5).
				return;
			}
			Stopwatch stopwatch = IsPerfLoggingEnabled ? Stopwatch.StartNew() : null;
			base.OnInserted(sender, e);
			var entity = (Entity)sender;
			Guid clientAppId = entity.PrimaryColumnValue;
			OAuthDefaultResourceInfo defaultOAuthResource = GetOAuthDefaultResource(entity.UserConnection);
			List<string> pendingGrantTypes = BaseOAuthApiCaller.TakePendingAllowedGrantTypes(clientAppId);
			Stopwatch grantTypesStopwatch = IsPerfLoggingEnabled ? Stopwatch.StartNew() : null;
			try {
				EnsureOAuthGrantTypeRelations(entity, pendingGrantTypes);
			} catch {
				BaseOAuthApiCaller.ForgetPendingGrantTypeSyncSkips(clientAppId);
				throw;
			}
			BaseOAuthApiCaller.LogPerformance("OAuthClientAppListener.OnInserted.GrantTypeRelations",
				grantTypesStopwatch, $"clientAppId='{clientAppId}'.");
			if (pendingGrantTypes == null || !pendingGrantTypes.Any()) {
				// Single-grant clients have no OAuthGrantTypeInClient rows queued, so the
				// OAuthGrantTypeInClientEventListener never fires a follow-up identity sync —
				// resync explicitly here using the persisted GrantTypeId.
				IdentityServiceWrapper.UpdateClient(GetClientAppInfoFromEntity(entity));
			}
			Stopwatch resourceRelationStopwatch = IsPerfLoggingEnabled ? Stopwatch.StartNew() : null;
			CreateOAuthResourceInClient(clientAppId, defaultOAuthResource.Id, entity.UserConnection);
			BaseOAuthApiCaller.LogPerformance("OAuthClientAppListener.OnInserted.DefaultResourceRelation",
				resourceRelationStopwatch, $"clientAppId='{clientAppId}' resource='{defaultOAuthResource.Name}'.");
			BaseOAuthApiCaller.LogPerformance("OAuthClientAppListener.OnInserted", stopwatch,
				$"clientAppId='{clientAppId}'.");
		}

		/// <summary>Handles entity Updating event.</summary>
		/// <param name="sender">Event sender.</param>
		/// <param name="e">The <see cref="T:Terrasoft.Core.Entities.EntityBeforeEventArgs" /> instance containing the event data.</param>
		public override void OnUpdating(object sender, EntityBeforeEventArgs e) {
			CheckCanManageSolution(sender);
			var entity = (Entity)sender;
			if (IsInstallStatusFeatureEnabled()) {
				if (IsStatusModified(entity)) {
					if (entity.GetTypedColumnValue<Guid>("StatusId") == InstalledStatusId) {
						// The only allowed Status change: Not installed -> Installed (AC 9, 10, 14).
						base.OnUpdating(sender, e);
						HandleInstallTransition(entity, e);
					} else {
						// Any other direct Status write (revert, etc.) is rejected on every call path (AC 14).
						ThrowException(GetListenerLocalizableString(entity,
							"LocalizableStrings.IllegalStatusTransitionMessage.Value"));
					}
					return;
				}
				if (IsNotInstalled(entity)) {
					// Editing a Not installed record: no Identity Service call (AC 6).
					return;
				}
			}
			base.OnUpdating(sender, e);
			ClientAppInfoRequest clientAppRequest = GetClientAppInfoFromEntity(entity);
			ExecuteApiCall(() => IdentityServiceWrapper.UpdateClient(clientAppRequest), entity.UserConnection, e);
		}

		/// <inheritdoc />
		public override void OnUpdated(object sender, EntityAfterEventArgs e)		{
			var entity = (Entity)sender;
			if (IsInstallStatusFeatureEnabled()) {
				if (IsInstallTransitionCommitted(entity, e)) {
					// Install committed: create the default OAuth resource relation, mirroring OnInserted (AC 10).
					base.OnUpdated(sender, e);
					EnsureDefaultResourceRelation(entity);
					OAuthClientGrantTypeHelper.InvalidateClientCache(entity.PrimaryColumnValue);
					return;
				}
				if (IsNotInstalled(entity)) {
					// Not installed: no Identity client exists, nothing to invalidate.
					return;
				}
			}
			base.OnUpdated(sender, e);
			UserConnection userConnection = entity.UserConnection.AppConnection.SystemUserConnection;
			string clientId = entity.GetTypedColumnValue<string>("ClientId");
			OAuthClientGrantTypeHelper.InvalidateClientCache(entity.PrimaryColumnValue);
			if (e.ModifiedColumnValues.FindByName("IsActive") != null) {
				ClearCacheForClientId(userConnection, clientId);
			}
			if (e.ModifiedColumnValues.FindByName("ConsentModeId") != null) {
				ClearConsentModeCache(userConnection, clientId);
			}
		}

		/// <summary>
		/// Handles entity Deleted event.
		/// </summary>
		/// <param name="sender">Event sender.</param>
		/// <param name="e">The <see cref="T:Terrasoft.Core.Entities.EntityAfterEventArgs" /> instance containing the
		/// event data.</param>
		public override void OnDeleting(object sender, EntityBeforeEventArgs e) {
			CheckCanManageSolution(sender);
			base.OnDeleting(sender, e);
			var entity = (Entity)sender;
			UserConnection userConnection = entity.UserConnection.AppConnection.SystemUserConnection;
			string clientId = entity.GetTypedColumnValue<string>("ClientId");
			DeleteOAuthGrantTypeRelations(entity);
			if (!(IsInstallStatusFeatureEnabled() && IsNotInstalled(entity))) {
				// A Not installed record has no Identity Service client and no cached activity state.
				RemoveClientFromIdentityService(entity);
				ClearCacheForClientId(userConnection, clientId);
				ClearConsentModeCache(userConnection, clientId);
			}
			OAuthClientGrantTypeHelper.InvalidateClientCache(entity.PrimaryColumnValue);
		}

		#endregion

		#region Class: OAuthDefaultResourceInfo

		private sealed class OAuthDefaultResourceInfo
		{

			#region Properties: Public

			public Guid Id { get; set; }

			public string Name { get; set; }

			#endregion

		}

		#endregion

	}

	#endregion

}

