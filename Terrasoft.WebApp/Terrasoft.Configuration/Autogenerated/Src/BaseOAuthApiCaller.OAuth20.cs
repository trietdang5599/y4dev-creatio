using Terrasoft.Common.Threading;

namespace Terrasoft.Configuration.OAuth20
{
	using global::Common.Logging;
	using Creatio.FeatureToggling;
	using System.Collections.Concurrent;
	using System.Diagnostics;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Entities.Events;
	using Terrasoft.Core.Factories;
	using Terrasoft.Core.OAuth;
	using Terrasoft.Messaging.Common;
    using Terrasoft.OAuthIntegration;
	using Terrasoft.OAuthIntegration.DTO;
	using Terrasoft.OAuthIntegration.Enums;
	using Terrasoft.OAuthIntegration.Exception;

	#region Class: BaseOAuthApiCaller

	public abstract class BaseOAuthApiCaller : BaseEntityEventListener
	{

		#region Constants: Private

		private const string DefaultAppUrl = @"https://defaulturl.com";
		private const string ClientCredentialsGrantTypeCode = "client_credentials";
		private const string AuthorizationCodeGrantTypeCode = "authorization_code";
		private const string TokenExchangeGrantTypeCode = "urn:ietf:params:oauth:grant-type:token-exchange";

		#endregion

		#region Fields: Private

		private static readonly ILog _log = LogManager.GetLogger("OAuth20");
		private static readonly Guid ClientCredentialsGrantTypeId =
			new Guid("73f0cc6d-0634-4db3-96ab-0cb549958f91");
		private static readonly Guid AuthorizationCodeGrantTypeId =
			new Guid("ea4416f8-c13a-4dfd-8e41-e504735dcde8");
		private static readonly Guid TokenExchangeGrantTypeId =
			new Guid("de960442-76b1-4d34-bd17-7eba2db8d2d8");
		private static readonly ConcurrentDictionary<Guid, List<string>> _pendingAllowedGrantTypesByClientId =
			new ConcurrentDictionary<Guid, List<string>>();
		private static readonly ConcurrentDictionary<Guid, int> _pendingGrantTypeSyncSkipsByClientId =
			new ConcurrentDictionary<Guid, int>();
		#endregion

		#region Fields: Protected

		protected readonly Dictionary<Type, string> ExceptionMessageResourceKeys;

		#endregion

		#region Constructors: Public

		public BaseOAuthApiCaller(Dictionary<Type, string> exceptionMessageResourceKeys) {
			ExceptionMessageResourceKeys = exceptionMessageResourceKeys;
		}

		#endregion

		#region Properties: Protected

		protected IIdentityServiceWrapper IdentityServiceWrapper => GlobalAppSettings.FeatureUseSeparateSettingsForOAuth20
			? ClassFactory.Get<IIdentityServiceWrapper>("OAuth20Integration")
			: ClassFactory.Get<IIdentityServiceWrapper>();

		#endregion

		#region Methods: Private

		private static List<string> GetLegacyRedirectUrls(Entity entity) {
			string redirectUrl = entity.GetTypedColumnValue<string>("RedirectUrl");
			return redirectUrl.IsNullOrWhiteSpace()
				? new List<string>()
				: new List<string> { redirectUrl };
		}

		internal static bool IsPerfLoggingEnabled => _log.IsDebugEnabled;

		internal static void LogPerformance(string operationName, Stopwatch stopwatch, string details = null) {
			if (stopwatch == null || !_log.IsDebugEnabled) {
				return;
			}
			string suffix = details.IsNullOrWhiteSpace()
				? string.Empty
				: $" {details}";
			_log.Debug($"OAuth20 perf: {operationName} took {stopwatch.ElapsedMilliseconds} ms.{suffix}");
		}

		private static List<string> GetRedirectUrls(Entity entity) {
			Stopwatch stopwatch = IsPerfLoggingEnabled ? Stopwatch.StartNew() : null;
			var esq = new EntitySchemaQuery(entity.EntitySchemaManager, "RedirectUrlInOAuthClientApp");
			esq.AddColumn("RedirectUrl");
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal,
				"OAuthClientApp", entity.PrimaryColumnValue));
			var redirectUrlEntityCollection = esq.GetEntityCollection(entity.UserConnection);
			var redirectUrls = redirectUrlEntityCollection.Select(redirectUrlEntity =>
				redirectUrlEntity.GetTypedColumnValue<string>("RedirectUrl"))
				.Where(url => !url.IsNullOrWhiteSpace())
				.Distinct()
				.ToList();
			var result = redirectUrls.Any()
				? redirectUrls
				: GetLegacyRedirectUrls(entity);
			LogPerformance("BaseOAuthApiCaller.GetRedirectUrls", stopwatch,
				$"clientAppId='{entity.PrimaryColumnValue}' count={result.Count}.");
			return result;
		}

		private static List<string> GetAllowedGrantTypes(Entity entity) {
			Stopwatch stopwatch = IsPerfLoggingEnabled ? Stopwatch.StartNew() : null;
			if (TryGetPendingAllowedGrantTypes(entity.PrimaryColumnValue, out List<string> pendingGrantTypes)) {
				LogPerformance("BaseOAuthApiCaller.GetAllowedGrantTypes", stopwatch,
					$"clientAppId='{entity.PrimaryColumnValue}' source='pending' count={pendingGrantTypes.Count}.");
				return pendingGrantTypes;
			}
			if (entity.EntitySchemaManager.FindInstanceByName("OAuthGrantTypeInClient") == null) {
				List<string> legacyGrantTypes = GetLegacyAllowedGrantTypes(entity);
				LogPerformance("BaseOAuthApiCaller.GetAllowedGrantTypes", stopwatch,
					$"clientAppId='{entity.PrimaryColumnValue}' source='legacy-schema-missing' count={legacyGrantTypes.Count}.");
				return legacyGrantTypes;
			}
			try {
				var esq = new EntitySchemaQuery(entity.EntitySchemaManager, "OAuthGrantTypeInClient");
				EntitySchemaQueryColumn grantTypeCodeColumn = esq.AddColumn("OAuthGrantType.Code");
				esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal,
					"OAuthClientApp", entity.PrimaryColumnValue));
				var grantTypeEntityCollection = esq.GetEntityCollection(entity.UserConnection);
				var grantTypes = grantTypeEntityCollection
					.Select(grantTypeEntity => grantTypeEntity.GetTypedColumnValue<string>(grantTypeCodeColumn.Name))
					.Where(grantType => !grantType.IsNullOrWhiteSpace())
					.Distinct()
					.ToList();
				List<string> result = grantTypes.Any()
					? grantTypes
					: GetLegacyAllowedGrantTypes(entity);
				LogPerformance("BaseOAuthApiCaller.GetAllowedGrantTypes", stopwatch,
					$"clientAppId='{entity.PrimaryColumnValue}' source='relations' count={result.Count}.");
				return result;
			}
			catch (ItemNotFoundException ex) {
				// Schema or column metadata missing (e.g. during package upgrade before EnsureOAuthGrantTypeRelations
				// has run). Fall back to the legacy column so identity sync still works.
				_log.Warn($"OAuthGrantTypeInClient metadata not found. Falling back to OAuthClientApp.GrantType. {ex}");
				List<string> fallbackGrantTypes = GetLegacyAllowedGrantTypes(entity);
				LogPerformance("BaseOAuthApiCaller.GetAllowedGrantTypes", stopwatch,
					$"clientAppId='{entity.PrimaryColumnValue}' source='fallback' count={fallbackGrantTypes.Count}.");
				return fallbackGrantTypes;
			}
		}

		private static List<string> GetLegacyAllowedGrantTypes(Entity entity) {
			var grantTypeId = entity.GetTypedColumnValue<Guid>("GrantTypeId");
			if (grantTypeId == ClientCredentialsGrantTypeId) {
				return new List<string> { ClientCredentialsGrantTypeCode };
			}
			if (grantTypeId == AuthorizationCodeGrantTypeId) {
				return new List<string> { AuthorizationCodeGrantTypeCode };
			}
			if (grantTypeId == TokenExchangeGrantTypeId) {
				return new List<string> { TokenExchangeGrantTypeCode };
			}
			return new List<string>();
		}

		internal static string GetGrantTypeConfigurationError(UserConnection userConnection, bool isPublic,
				bool requirePkce, IEnumerable<string> allowedGrantTypes) {
			if (!isPublic) {
				return null;
			}
			var grantTypes = allowedGrantTypes?
				.Where(grantType => !grantType.IsNullOrWhiteSpace())
				.Distinct()
				.ToList() ?? new List<string>();
			bool onlyAuthorizationCode = grantTypes.Count == 1 &&
				grantTypes.Contains(AuthorizationCodeGrantTypeCode);
			if (!onlyAuthorizationCode) {
				return new LocalizableString(userConnection.ResourceStorage, "BaseOAuthApiCaller",
					"LocalizableStrings.PublicClientGrantTypeError.Value");
			}
			return null;
		}

		internal static bool GetEffectiveRequirePkceForIdentity(bool isPublic, bool requirePkce) {
			return isPublic || requirePkce;
		}

		internal static void RememberPendingAllowedGrantTypes(Guid clientAppId, IEnumerable<string> grantTypes) {
			if (clientAppId.IsEmpty()) {
				return;
			}
			var normalizedGrantTypes = grantTypes?
				.Where(grantType => !grantType.IsNullOrWhiteSpace())
				.Distinct()
				.ToList();
			if (normalizedGrantTypes == null || !normalizedGrantTypes.Any()) {
				_pendingAllowedGrantTypesByClientId.TryRemove(clientAppId, out _);
				return;
			}
			_pendingAllowedGrantTypesByClientId[clientAppId] = normalizedGrantTypes;
		}

		internal static bool TryGetPendingAllowedGrantTypes(Guid clientAppId, out List<string> pendingGrantTypes) {
			pendingGrantTypes = null;
			if (clientAppId.IsEmpty()) {
				return false;
			}
			if (!_pendingAllowedGrantTypesByClientId.TryGetValue(clientAppId, out List<string> storedGrantTypes)
					|| storedGrantTypes == null || !storedGrantTypes.Any()) {
				return false;
			}
			pendingGrantTypes = storedGrantTypes;
			return true;
		}

		internal static List<string> TakePendingAllowedGrantTypes(Guid clientAppId) {
			if (clientAppId.IsEmpty()) {
				return null;
			}
			return _pendingAllowedGrantTypesByClientId.TryRemove(clientAppId, out List<string> pendingGrantTypes)
					&& pendingGrantTypes?.Any() == true
				? pendingGrantTypes
				: null;
		}

		internal static void ForgetPendingAllowedGrantTypes(Guid clientAppId) {
			if (!clientAppId.IsEmpty()) {
				_pendingAllowedGrantTypesByClientId.TryRemove(clientAppId, out _);
			}
		}

		internal static void RememberPendingGrantTypeSyncSkips(Guid clientAppId, int skipCount) {
			if (clientAppId.IsEmpty() || skipCount <= 0) {
				return;
			}
			_pendingGrantTypeSyncSkipsByClientId.AddOrUpdate(clientAppId, skipCount,
				(_, currentSkipCount) => currentSkipCount + skipCount);
		}

		internal static bool TryTakePendingGrantTypeSyncSkip(Guid clientAppId) {
			if (clientAppId.IsEmpty()) {
				return false;
			}
			while (_pendingGrantTypeSyncSkipsByClientId.TryGetValue(clientAppId, out int currentSkipCount)) {
				if (currentSkipCount <= 1) {
					if (_pendingGrantTypeSyncSkipsByClientId.TryRemove(clientAppId, out _)) {
						return true;
					}
					continue;
				}
				if (_pendingGrantTypeSyncSkipsByClientId.TryUpdate(clientAppId, currentSkipCount - 1,
						currentSkipCount)) {
					return true;
				}
			}
			return false;
		}

		internal static void ForgetPendingGrantTypeSyncSkips(Guid clientAppId) {
			if (clientAppId.IsEmpty()) {
				return;
			}
			_pendingGrantTypeSyncSkipsByClientId.TryRemove(clientAppId, out _);
		}

		private void NotifyUserAboutException(UserConnection userConnection, Exception exception) {
			if (!MsgChannelManager.IsRunning) {
				return;
			}
			var channel = MsgChannelManager.Instance.FindItemByUId(userConnection.CurrentUser.Id);
			if (channel == null) {
				return;
			}
			var simpleMessage = new SimpleMessage {
				Body = exception?.InnerException ?? exception,
				Id = Guid.NewGuid()
			};
			simpleMessage.Header.BodyTypeName = "ActingOnOAuthClientApplication";
			simpleMessage.Header.Sender = GetType().ToString();
			channel.PostMessage(simpleMessage);
		}

		#endregion

		#region Methods: Protected

		protected bool CanUseAuthorizationCodeFlow() {
			var identityServiceInfoProvider = ClassFactory.Get<IIdentityServiceInfoProvider>();
			return AsyncPump.Run(() => identityServiceInfoProvider.CanUseAuthorizationCodeFlow());
		}

		/// <summary>
		/// Reads a custom token lifetime (seconds) column from the client application entity. Returns <c>0</c> when
		/// the column is absent (OAuth20 package predating ENG-78573) or not configured, so the caller keeps the
		/// default lifetime.
		/// </summary>
		private static int GetCustomTokenLifetime(Entity entity, string columnName) {
			return entity.Schema.Columns.FindByName(columnName) == null
				? 0
				: entity.GetTypedColumnValue<int>(columnName);
		}

		protected ClientAppInfoRequest GetClientAppInfoFromEntity(Entity entity) {
			Stopwatch stopwatch = IsPerfLoggingEnabled ? Stopwatch.StartNew() : null;
			var userConnection = entity.UserConnection;
			var clientName = entity.GetTypedColumnValue<string>("Name");
			Stopwatch redirectUrlsStopwatch = IsPerfLoggingEnabled ? Stopwatch.StartNew() : null;
			var redirectUrls = GetRedirectUrls(entity);
			LogPerformance("BaseOAuthApiCaller.GetClientAppInfoFromEntity.RedirectUrls", redirectUrlsStopwatch,
				$"clientAppId='{entity.PrimaryColumnValue}' count={redirectUrls.Count}.");
			var applicationUrl = entity.GetTypedColumnValue<string>("ApplicationUrl");
			if (applicationUrl.IsNullOrWhiteSpace()) {
				applicationUrl = DefaultAppUrl;
			}
			var clientId = entity.GetTypedColumnValue<string>("ClientId");
			var systemUserId = entity.GetTypedColumnValue<string>("SystemUserId");
			Stopwatch allowedGrantTypesStopwatch = IsPerfLoggingEnabled ? Stopwatch.StartNew() : null;
			var allowedGrantTypes = GetAllowedGrantTypes(entity);
			LogPerformance("BaseOAuthApiCaller.GetClientAppInfoFromEntity.AllowedGrantTypes",
				allowedGrantTypesStopwatch,
				$"clientAppId='{entity.PrimaryColumnValue}' count={allowedGrantTypes.Count}.");
			bool allowsAuthorizationCode = allowedGrantTypes.Contains(AuthorizationCodeGrantTypeCode);
			bool allowsClientCredentials = allowedGrantTypes.Contains(ClientCredentialsGrantTypeCode);
			if (allowsAuthorizationCode) {
				Stopwatch canUseAuthorizationCodeFlowStopwatch = IsPerfLoggingEnabled ? Stopwatch.StartNew() : null;
				bool canUseAuthorizationCodeFlow = CanUseAuthorizationCodeFlow();
				LogPerformance("BaseOAuthApiCaller.GetClientAppInfoFromEntity.CanUseAuthorizationCodeFlow",
					canUseAuthorizationCodeFlowStopwatch,
					$"clientAppId='{entity.PrimaryColumnValue}' result='{canUseAuthorizationCodeFlow}'.");
				if (!canUseAuthorizationCodeFlow) {
					var errorMessage = new LocalizableString(userConnection.ResourceStorage, "BaseOAuthApiCaller",
						"LocalizableStrings.NeedToUpdateIdentityServiceMessage.Value");
					throw new Exception(errorMessage);
				}
			}
			if (allowsClientCredentials && systemUserId.IsNullOrEmpty()) {
				throw new RequiredColumnsEmptyValuesException(new string[] { "SystemUser" });
			}
			bool allowOfflineAccess = false;
			var accessTokenType = AccessTokenType.Jwt;
			if (allowsAuthorizationCode) {
				allowOfflineAccess = true;
				accessTokenType = AccessTokenType.Reference;
				if (!allowsClientCredentials) {
					systemUserId = null;
				}
			}
			var isActive = entity.GetTypedColumnValue<bool>("IsActive");
			var clientDescription = entity.GetTypedColumnValue<string>("Description");
			var requirePkce = entity.GetTypedColumnValue<bool>("RequirePKCE");
			var allowPlainTextPkce = entity.GetTypedColumnValue<bool>("AllowPlainTextPkce");
			var isPublic = entity.GetTypedColumnValue<bool>("IsPublic");
			string grantConfigurationError = GetGrantTypeConfigurationError(userConnection, isPublic, requirePkce,
				allowedGrantTypes);
			if (!grantConfigurationError.IsNullOrWhiteSpace()) {
				throw new OAuthClientAppException(grantConfigurationError);
			}
			var effectiveRequirePkce = GetEffectiveRequirePkceForIdentity(isPublic, requirePkce);
			var clientAppInfoReq = new ClientAppInfoRequest {
				ClientId = clientId,
				CustomerId = clientName,
				ClientAppName = clientName,
				ClientAppDescription = clientDescription,
				ClientAppUri = applicationUrl,
				Enabled = isActive,
				SystemUserId = systemUserId,
				RedirectUris = redirectUrls,
				AllowOfflineAccess = allowOfflineAccess,
				RequirePkce = effectiveRequirePkce,
				AccessTokenType = accessTokenType,
				AllowPlainTextPkce = allowPlainTextPkce,
				RequireClientSecret = !isPublic,
				AllowedGrantTypes = allowedGrantTypes
			};
			if (Features.GetIsEnabled("EnableOAuthClientDisableConsent")) {
				// ConsentMode → the single boolean RequireConsent contract Duende understands:
				// Bypass → false; AskAlways and RememberConsent → true (the per-request "remembered"
				// skip is decided Creatio-side and does not change the Identity client contract).
				var consentModeId = entity.GetTypedColumnValue<Guid>("ConsentModeId");
				clientAppInfoReq.RequireConsent =
					consentModeId != Guid.Parse(OAuthConstants.ConsentModeBypassId);
			}
			if (allowsAuthorizationCode) {
				clientAppInfoReq.AccessTokenLifetime = 15 * 60;
				clientAppInfoReq.SlidingRefreshTokenLifetime = 48 * 60 * 60;
			} else {
				// Server-to-server (client_credentials) clients must send an explicit positive access token
				// lifetime. Otherwise, after switching a client to user flow and back to s2s, the short
				// 15-minute lifetime set above stays on the Identity client: IdentityServiceWrapper.UpdateClient
				// skips AccessTokenLifetime when it is 0 (guard "> 0"), so the stale user-flow value is never
				// overwritten. Sending the s2s default here resets it on every sync.
				clientAppInfoReq.AccessTokenLifetime = 60 * 60;
			}
			// ENG-78573: honor per-client custom token lifetimes when configured (> 0); otherwise keep the
			// defaults set above. The values are set via the OAuth Registrar utility (back-end / DevOps path).
			int customAccessTokenLifetime = GetCustomTokenLifetime(entity, "AccessTokenLifetime");
			if (customAccessTokenLifetime > 0) {
				clientAppInfoReq.AccessTokenLifetime = customAccessTokenLifetime;
			}
			int customSlidingRefreshTokenLifetime = GetCustomTokenLifetime(entity, "SlidingRefreshTokenLifetime");
			if (customSlidingRefreshTokenLifetime > 0) {
				clientAppInfoReq.SlidingRefreshTokenLifetime = customSlidingRefreshTokenLifetime;
			}
			LogPerformance("BaseOAuthApiCaller.GetClientAppInfoFromEntity", stopwatch,
				$"clientAppId='{entity.PrimaryColumnValue}' grants={allowedGrantTypes.Count}.");
			return clientAppInfoReq;
		}

		protected void CheckCanManageSolution(object sender) {
			var entity = (Entity)sender;
			var userConnection = entity.UserConnection;
			userConnection.DBSecurityEngine.CheckCanExecuteOperation("CanManageSolution");
		}

		protected void CheckCanManageOAuth(object sender) {
			var entity = (Entity)sender;
			var userConnection = entity.UserConnection;
			userConnection.DBSecurityEngine.CheckCanExecuteOperation("CanManageOAuth");
		}

		protected virtual void ExecuteApiCall(Action apiCall, UserConnection userConnection, EntityBeforeEventArgs e) {
			string errorMessage = null;
			Exception oauthException = null;
			try {
				apiCall();
			}
			catch (ApiServerException ex) {
				errorMessage = new LocalizableString(userConnection.ResourceStorage, GetType().Name,
					ExceptionMessageResourceKeys[typeof(ApiServerException)]);
				oauthException = ex;
			}
			catch (ApiServerConnectivityException ex) {
				string serverUri = Core.Configuration.SysSettings.GetValue(userConnection, "OAuth20IdentityServerUrl", string.Empty);
				errorMessage = string.Format(new LocalizableString(userConnection.ResourceStorage, GetType().Name,
					ExceptionMessageResourceKeys[typeof(ApiServerConnectivityException)]), serverUri);
				oauthException = ex;
			}
			catch (Exception ex) {
				errorMessage = string.Format(new LocalizableString(userConnection.ResourceStorage, "BaseOAuthApiCaller",
					"LocalizableStrings.UnexpectedErrorMessage.Value"), ex.Message);
				oauthException = ex;
			}
			if (oauthException != null) {
				e.IsCanceled = true;
				_log.Error($"{errorMessage}: {oauthException}");
				NotifyUserAboutException(userConnection, oauthException);
			}
			if (errorMessage != null) {
				ThrowException(errorMessage);
			}
		}

		protected void ValidateRedirectUrl(string redirectUrl, UserConnection userConnection) {
			bool isValidUrl = Uri.TryCreate(redirectUrl, UriKind.Absolute, out _)
				&& IsSchemeSeparatedByDoubleSlashes(redirectUrl);
			if (!isValidUrl) {
				var errorMessage = string.Format(new LocalizableString(userConnection.ResourceStorage, "BaseOAuthApiCaller",
					"LocalizableStrings.InvalidUrlErrorMessage.Value"), redirectUrl);
				_log.Error(errorMessage);
				ThrowException(errorMessage);
			}
		}

		private static bool IsSchemeSeparatedByDoubleSlashes(string redirectUrl) {
			var schemaSeparatorIndex = redirectUrl.IndexOf("://", StringComparison.Ordinal);
			return schemaSeparatorIndex > 0 && schemaSeparatorIndex + 3 < redirectUrl.Length;
		}
		
		protected abstract void ThrowException(string errorMessage);

		#endregion

	}

	#endregion
}

