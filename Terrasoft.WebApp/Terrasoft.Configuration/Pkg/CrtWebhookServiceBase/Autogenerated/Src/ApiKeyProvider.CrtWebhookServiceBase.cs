namespace Terrasoft.Configuration.LandingiIntegration
{
	using System;
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using global::Common.Logging;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Configuration.BpmonlineCloudIntegration;
	using Terrasoft.Core.Configuration;
	using Terrasoft.Nui.ServiceModel.DataContract;
	using Terrasoft.Web.Common;

	#region Interface: IWebhookApiKeyProvider

	/// <summary>
	/// Provides webhook API key from the external service.
	/// </summary>
	public interface IWebhookApiKeyProvider
	{

		#region Methods: Public

		/// <summary>
		/// Gets or creates webhook API key.
		/// </summary>
		/// <param name="integrationName">Name of the integration.</param>
		/// <param name="webhookSource">The webhook source.</param>
		/// <returns>Base response with API key.</returns>
		WebhookApiKeyResponse GetOrCreateWebhookApiKey(string integrationName, string webhookSource);

		/// <summary>
		/// Gets or creates webhook account info.
		/// </summary>
		/// <param name="integrationName">Name of the integration.</param>
		/// <param name="webhookSource">The webhook source.</param>
		/// <returns>Response with webhook account info.</returns>
		WebhookAccountInfoResponse GetOrCreateWebhookAccount(string integrationName, string webhookSource);

		/// <summary>
		/// Enables HMAC for the webhook account.
		/// </summary>
		/// <param name="integrationName">Name of the integration.</param>
		/// <param name="webhookSource">The webhook source.</param>
		/// <returns>Response with webhook account info.</returns>
		WebhookAccountInfoResponse EnableHmac(string integrationName, string webhookSource);

		#endregion

	}

	#endregion

	#region Class: ApiKeyProvider

	/// <summary>
	/// Api key provider.
	/// </summary>
	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class ApiKeyProvider : BaseService, IWebhookApiKeyProvider
	{

		#region Class: Private

		private class OperationResult<T>
		{

			#region Properties: Public

			public bool Success { get; }

			public T Value { get; }

			public string ErrorCode { get; }

			public string ErrorMessage { get; }

			#endregion

			#region Constructors: Private

			private OperationResult(bool success, T value, string errorCode, string errorMessage) {
				Success = success;
				Value = value;
				ErrorCode = errorCode;
				ErrorMessage = errorMessage;
			}

			#endregion

			#region Methods: Public

			public static OperationResult<T> Ok(T value) =>
				new OperationResult<T>(true, value, null, null);

			public static OperationResult<T> Fail(string errorCode, string errorMessage) =>
				new OperationResult<T>(false, default(T), errorCode, errorMessage);

			#endregion

		}

		private class WebhookInfo
		{

			#region Properties: Public

			public string ApiKey { get; set; }

			public bool HmacEnabled { get; set; }

			public string HmacSecretKey { get; set; }

			#endregion

		}

		#endregion

		#region Constants: Private

		private const string AccountServiceUrlIsNotFilledCode = "AccountServiceUrlIsNotFilledErrorMsg";
		private const string ErrorMessagePrefixCode = "ErrorMessagePrefix";
		private const string GetCreatioUrlErrorCode = "GetCreatioUrlErrorMsg";
		private const string IdentitySettingsAreNotFilledErrorCode = "IdentitySettingsAreNotFilledErrorMsg";
		private const string OtherErrorCode = "OtherErrorMsg";
		private const string WebhookAccountServiceIdentityErrorCode = "WebhookAccountServiceIdentityErrorMsg";
		private const string Scope = "webhook.creatio.full_access";
		private const string ApiKeyCacheClearIntervalCode = "ApiKeyCacheClearInterval";

		#endregion

		#region Fields: Private

		private static readonly ThreadSafeCache<string, WebhookInfo> webhookAccountCache =
			new ThreadSafeCache<string, WebhookInfo>();
		private static DateTime _lastCacheRefreshTime = DateTime.Now;
		private readonly int _cacheClearInterval = 60;
		private ILog _logger;
		private IOAuthIntegrationReader _oAuthIntegrationReader;
		private IRootAccountProvider _rootAccountProvider;
		private ISubAccountProviderFactory _subAccountProviderFactory;

		#endregion

		#region Properties: Private

		private string ErrorMessagePrefix => GetLczString(ErrorMessagePrefixCode);

		#endregion

		#region Properties: Public

		/// <summary>
		/// Gets or sets the logger.
		/// </summary>
		public ILog Logger
		{
			get => _logger ?? (_logger = LogManager.GetLogger("ApiKeyProvider"));
			set => _logger = value;
		}

		/// <summary>
		/// The root account provider.
		/// </summary>
		public IRootAccountProvider RootAccountProvider
		{
			get => _rootAccountProvider ?? (_rootAccountProvider = new RootAccountProvider(UserConnection, Scope));
			set => _rootAccountProvider = value;
		}

		/// <summary>
		/// The OAuth integration reader.
		/// </summary>
		public IOAuthIntegrationReader OAuthIntegrationReader
		{
			get => _oAuthIntegrationReader ?? (_oAuthIntegrationReader = new OAuthIntegrationReader());
			set => _oAuthIntegrationReader = value;
		}

		/// <summary>
		/// Gets or sets the sub account provider factory.
		/// </summary>
		public ISubAccountProviderFactory SubAccountProviderFactory
		{
			get =>
				_subAccountProviderFactory ??
				(_subAccountProviderFactory = new SubAccountProviderFactory());
			set => _subAccountProviderFactory = value;
		}

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Initializes new instance of <see cref="ApiKeyProvider"/>.
		/// </summary>
		public ApiKeyProvider() : base() {
		}

		/// <summary>
		/// Initializes new instance of <see cref="ApiKeyProvider"/>.
		/// </summary>
		/// <param name="userConnection">Instance of the <see cref="UserConnection"/>.</param>
		public ApiKeyProvider(UserConnection userConnection) : base(userConnection) {
		}

		#endregion

		#region Methods: Private

		private string GetLczString(string localizableCode) {
			var localizableStringName = $"LocalizableStrings.{localizableCode}.Value";
			return new LocalizableString(UserConnection.Workspace.ResourceStorage, "ApiKeyProvider",
				localizableStringName);
		}

		private T ProcessError<T>(string errorMessageCode, string message) where T : BaseResponse, new() {
			var errorMessage = $"{ErrorMessagePrefix} {GetLczString(errorMessageCode)}";
			Logger.Error($"Error message: {errorMessage} Exception message: {message}");
			var errorResponse = new T {
				RowsAffected = 1,
				ResponseStatus = new ResponseStatus("500", errorMessage),
				Success = false
			};
			return errorResponse;
		}

		private OperationResult<IntegrationInfo> GetIntegrationInfo(string integrationName) {
			try {
				var integrationInfo = OAuthIntegrationReader.GetIntegrationInfo(
					UserConnection.AppConnection.SystemUserConnection,
					integrationName
				);
				if (integrationInfo == null || !integrationInfo.Success) {
					return OperationResult<IntegrationInfo>.Fail(
						WebhookAccountServiceIdentityErrorCode,
						string.Empty
					);
				}
				return OperationResult<IntegrationInfo>.Ok(integrationInfo);
			} catch (Exception e) {
				return OperationResult<IntegrationInfo>.Fail(
					WebhookAccountServiceIdentityErrorCode,
					e.Message
				);
			}
		}

		private OperationResult<RootAccountInfoResponse> GetSocialRootAccount() {
			try {
				var account = RootAccountProvider.GetOrCreateSocialRootAccount();
				if (!string.IsNullOrEmpty(account.ErrorMessage)) {
					return OperationResult<RootAccountInfoResponse>.Fail(
						OtherErrorCode,
						account.ErrorMessage
					);
				}
				return OperationResult<RootAccountInfoResponse>.Ok(account);
			} catch (ItemNotFoundException e) {
				return OperationResult<RootAccountInfoResponse>.Fail(
					AccountServiceUrlIsNotFilledCode,
					e.Message
				);
			} catch (GetCreatioUrlException e) {
				return OperationResult<RootAccountInfoResponse>.Fail(
					GetCreatioUrlErrorCode,
					e.Message
				);
			} catch (InvalidIdentityServerSettingsException e) {
				return OperationResult<RootAccountInfoResponse>.Fail(
					IdentitySettingsAreNotFilledErrorCode,
					e.Message
				);
			} catch (Exception e) {
				return OperationResult<RootAccountInfoResponse>.Fail(
					OtherErrorCode,
					e.Message
				);
			}
		}

		private OperationResult<BaseWebhookAccountResponse> GetSubAccount(
			string webhookSource,
			IntegrationInfo integrationInfo
		) {
			try {
				IWebhookAccountProvider subAccountProvider =
					SubAccountProviderFactory.GetWebhookAccountProvider(webhookSource, true);
				var account = subAccountProvider.GetOrCreateWebhookAccount(webhookSource, integrationInfo);
				if (account == null) {
					return OperationResult<BaseWebhookAccountResponse>.Fail(
						OtherErrorCode,
						string.Empty
					);
				}
				return OperationResult<BaseWebhookAccountResponse>.Ok(account);
			} catch (Exception e) {
				return OperationResult<BaseWebhookAccountResponse>.Fail(
					OtherErrorCode,
					e.Message
				);
			}
		}

		private OperationResult<BaseWebhookAccountResponse> GetWebhookAccount(
			string integrationName,
			string webhookSource
		) {
			var integrationResult = GetIntegrationInfo(integrationName);
			if (!integrationResult.Success) {
				return OperationResult<BaseWebhookAccountResponse>.Fail(
					integrationResult.ErrorCode ?? WebhookAccountServiceIdentityErrorCode,
					integrationResult.ErrorMessage
				);
			}
			var rootResult = GetSocialRootAccount();
			if (!rootResult.Success) {
				return OperationResult<BaseWebhookAccountResponse>.Fail(
					rootResult.ErrorCode,
					rootResult.ErrorMessage
				);
			}
			var subAccountResult = GetSubAccount(webhookSource, integrationResult.Value);
			if (!subAccountResult.Success) {
				return subAccountResult;
			}
			return OperationResult<BaseWebhookAccountResponse>.Ok(subAccountResult.Value);
		}

		private OperationResult<WebhookInfo> GetWebhookFromCache(string cacheKey) {
			var cacheClearInterval = SysSettings.GetValue(
				UserConnection,
				ApiKeyCacheClearIntervalCode,
				_cacheClearInterval
			);
			bool isExpired = _lastCacheRefreshTime.AddMinutes(cacheClearInterval) <= DateTime.Now;
			var cachedWebhookAccount = isExpired
				? null
				: webhookAccountCache.Find(cacheKey);
			if (cachedWebhookAccount == null) {
				webhookAccountCache.Remove(cacheKey);
				return OperationResult<WebhookInfo>.Fail(null, null);
			}
			return OperationResult<WebhookInfo>.Ok(cachedWebhookAccount);
		}

		private OperationResult<WebhookApiKeyResponse> GetApiKeyFromCache(string cacheKey) {
			var cacheResult = GetWebhookFromCache(cacheKey);
			if (!cacheResult.Success || cacheResult.Value == null) {
				return OperationResult<WebhookApiKeyResponse>.Fail(null, null);
			}
			if (cacheResult.Value.ApiKey.IsNullOrWhiteSpace()) {
				return OperationResult<WebhookApiKeyResponse>.Fail(null, null);
			}
			var response = new WebhookApiKeyResponse {
				ApiKey = cacheResult.Value.ApiKey,
				Success = true
			};
			return OperationResult<WebhookApiKeyResponse>.Ok(response);
		}

		private OperationResult<WebhookAccountInfoResponse> GetWebhookAccountInfoFromCache(string cacheKey) {
			var cacheResult = GetWebhookFromCache(cacheKey);
			if (!cacheResult.Success || cacheResult.Value == null) {
				return OperationResult<WebhookAccountInfoResponse>.Fail(null, null);
			}

			var info = cacheResult.Value;
			var response = new WebhookAccountInfoResponse {
				ApiKey = info.ApiKey,
				HmacEnabled = info.HmacEnabled,
				HmacSecretKey = info.HmacSecretKey,
				Success = true
			};

			return OperationResult<WebhookAccountInfoResponse>.Ok(response);
		}

		private static void SetToCache(string cacheKey, BaseWebhookAccountResponse account) {
			var webhookInfo = new WebhookInfo {
				ApiKey = account.ApiKey,
				HmacEnabled = account.HmacEnabled,
				HmacSecretKey = account.HmacSecretKey
			};
			webhookAccountCache.Remove(cacheKey);
			webhookAccountCache.Add(cacheKey, webhookInfo);
			_lastCacheRefreshTime = DateTime.Now;
		}

		private static WebhookAccountInfoResponse CreateWebhookAccountInfoResponse(BaseWebhookAccountResponse account) {
			return new WebhookAccountInfoResponse {
				ApiKey = account.ApiKey,
				HmacEnabled = account.HmacEnabled,
				HmacSecretKey = account.HmacSecretKey,
				Success = true
			};
		}

		private OperationResult<BaseWebhookAccountResponse> EnableHmacForAccount(
			string webhookSource,
			string cacheKey,
			string apiKey
		) {
			try {
				IWebhookAccountProvider subAccountProvider =
					SubAccountProviderFactory.GetWebhookAccountProvider(webhookSource, true);
				var response = subAccountProvider.EnableHmac(apiKey);
				return OperationResult<BaseWebhookAccountResponse>.Ok(response);
			} catch (Exception e) {
				return OperationResult<BaseWebhookAccountResponse>.Fail(
					OtherErrorCode,
					e.Message
				);
			}
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Gets or creates webhook API key.
		/// </summary>
		/// <param name="integrationName">Name of the integration.</param>
		/// <param name="webhookSource">The webhook source.</param>
		/// <returns>Base response with API key.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
			BodyStyle = WebMessageBodyStyle.WrappedRequest)]
		public WebhookApiKeyResponse GetOrCreateWebhookApiKey(string integrationName, string webhookSource) {
			var cacheKey = $"{integrationName}_{webhookSource}";
			var cacheResult = GetApiKeyFromCache(cacheKey);
			if (cacheResult.Success && cacheResult.Value != null) {
				return cacheResult.Value;
			}
			var accountResult = GetWebhookAccount(integrationName, webhookSource);
			if (!accountResult.Success) {
				return ProcessError<WebhookApiKeyResponse>(accountResult.ErrorCode, accountResult.ErrorMessage);
			}
			SetToCache(cacheKey, accountResult.Value);
			return new WebhookApiKeyResponse {
				ApiKey = accountResult.Value.ApiKey,
				Success = true
			};
		}

		/// <summary>
		/// Gets or creates webhook account info.
		/// </summary>
		/// <param name="integrationName">Name of the integration.</param>
		/// <param name="webhookSource">The webhook source.</param>
		/// <returns>Response with webhook account info.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
			BodyStyle = WebMessageBodyStyle.WrappedRequest)]
		public WebhookAccountInfoResponse GetOrCreateWebhookAccount(string integrationName, string webhookSource) {
			var cacheKey = $"{integrationName}_{webhookSource}";
			var cacheResult = GetWebhookAccountInfoFromCache(cacheKey);
			if (cacheResult.Success && cacheResult.Value != null) {
				return cacheResult.Value;
			}
			var accountResult = GetWebhookAccount(integrationName, webhookSource);
			if (!accountResult.Success) {
				return ProcessError<WebhookAccountInfoResponse>(accountResult.ErrorCode, accountResult.ErrorMessage);
			}
			SetToCache(cacheKey, accountResult.Value);
			return CreateWebhookAccountInfoResponse(accountResult.Value);
		}

		/// <summary>
		/// Enables HMAC for the webhook account.
		/// </summary>
		/// <param name="integrationName">Name of the integration.</param>
		/// <param name="webhookSource">The webhook source.</param>
		/// <returns>Response status.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
			BodyStyle = WebMessageBodyStyle.WrappedRequest)]
		public WebhookAccountInfoResponse EnableHmac(string integrationName, string webhookSource) {
			var cacheKey = $"{integrationName}_{webhookSource}";
			var cacheResult = GetWebhookAccountInfoFromCache(cacheKey);
			if (cacheResult.Success &&
				cacheResult.Value != null &&
				cacheResult.Value.HmacEnabled) {
				return cacheResult.Value;
			}
			var accountResult = GetWebhookAccount(integrationName, webhookSource);
			if (!accountResult.Success) {
				return ProcessError<WebhookAccountInfoResponse>(accountResult.ErrorCode, accountResult.ErrorMessage);
			}
			var hmacResult = EnableHmacForAccount(webhookSource, cacheKey, accountResult.Value.ApiKey);
			if (!hmacResult.Success) {
				return ProcessError<WebhookAccountInfoResponse>(hmacResult.ErrorCode, hmacResult.ErrorMessage);
			}
			SetToCache(cacheKey, hmacResult.Value);
			return CreateWebhookAccountInfoResponse(hmacResult.Value);
		}

		#endregion

	}

	#endregion

}

