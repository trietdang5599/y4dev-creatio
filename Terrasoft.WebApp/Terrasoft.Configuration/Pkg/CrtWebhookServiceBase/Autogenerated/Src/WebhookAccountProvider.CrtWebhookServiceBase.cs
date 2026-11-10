namespace Terrasoft.Configuration.LandingiIntegration
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Factories;
	using CoreConfig = Terrasoft.Core.Configuration;

	#region Interface: IWebhookAccountProvider

	/// <summary>
	/// Provides a root account from the external account service.
	/// </summary>
	public interface IWebhookAccountProvider
	{
		/// <summary>
		/// Gets or create the webhook service subaccount.
		/// </summary>
		/// <param name="webhookSource">The webhooks source.</param>
		/// <param name="integrationInfo"></param>
		/// <returns>The key to webhook service api.</returns>
		string GetOrCreateWebhookServiceApiKey(string webhookSource, IntegrationInfo integrationInfo);

		/// <summary>
		/// Gets or create the webhook service subaccount.
		/// </summary>
		/// <param name="webhookSource">The webhooks source.</param>
		/// <param name="integrationInfo"></param>
		/// <returns>The webhook account response.</returns>
		BaseWebhookAccountResponse GetOrCreateWebhookAccount(string webhookSource, IntegrationInfo integrationInfo);

		/// <summary>
		/// Enables HMAC for the webhook account.
		/// </summary>
		/// <param name="webhookAccount">The webhook account.</param>
		BaseWebhookAccountResponse EnableHmac(string apiKey);

		/// <summary>
		/// Gets the Supported webhook sources by this provider.
		/// </summary>
		IEnumerable<string> WebhookSources
		{
			get;
		}
	}

	#endregion

	#region Class: WebhookAccountProvider

	/// <inheritdoc cref="IWebhookAccountProvider"/>
	[DefaultBinding(typeof(IWebhookAccountProvider))]
	public class WebhookAccountProvider : IWebhookAccountProvider
	{

		#region Constants: Private

		private const string IdentityClientSysCode = "IdentityServerClientId";
		private const int RateLimit = 100;

		#endregion

		#region Fields: Private

		private readonly UserConnection _userConnection;
		private IWebhookAccountServiceApi _webhookAccountServiceApi;

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Initializes a new instance of the <see cref="WebhookAccountProvider"/> class.
		/// </summary>
		/// <param name="userConnection">The user connection.</param>
		public WebhookAccountProvider(UserConnection userConnection) {
			_userConnection = userConnection;
		}

		#endregion

		#region Properties: Private

		private string IdentityServerClientId =>
			CoreConfig.SysSettings.GetValue(_userConnection, IdentityClientSysCode, "");

		#endregion

		#region Properties: Public

		/// <summary>
		/// The webhooks account service api.
		/// </summary>
		public IWebhookAccountServiceApi WebhookAccountServiceApi {
			get =>
				_webhookAccountServiceApi ??
				(_webhookAccountServiceApi = new WebhookAccountServiceApi(_userConnection));
			set => _webhookAccountServiceApi = value;
		}

		/// <inheritdoc cref="IWebhookAccountProvider.WebhookSources"/>
		public IEnumerable<string> WebhookSources => Enumerable.Empty<string>();

		#endregion

		#region Methods: Private

		private BaseWebhookAccountResponse CreateNewWebhookAccount(string webhookSource, IntegrationInfo integrationInfo) {
			var createRequest = new WebhookAccountRequest {
				CreatedBy = _userConnection.CurrentUser.Name,
				CreatedOn = DateTime.UtcNow,
				IsActive = true,
				RateLimit = RateLimit,
				WebhookSource = webhookSource,
				IdentityClientId = IdentityServerClientId,
				CreatioClientId = integrationInfo.ClientId,
				CreatioClientSecret = integrationInfo.ClientSecret,
				BatchingEnabled = true
			};
			BaseWebhookAccountResponse createdSubAccount = WebhookAccountServiceApi.CreateAccount(createRequest);
			return createdSubAccount;
		}

		#endregion

		#region Methods: Public

		/// <inheritdoc cref="IWebhookAccountProvider.GetOrCreateWebhookServiceApiKey"/>
		public string GetOrCreateWebhookServiceApiKey(string webhookSource, IntegrationInfo integrationInfo) {
			WebhookSubAccountsResponse webhookSubAccounts = WebhookAccountServiceApi.GetSubAccounts();
			string apiKeyBySource = webhookSubAccounts?.SubAccounts
				?.FirstOrDefault(x => x.WebhookSource == webhookSource)?.ApiKey;
			return apiKeyBySource ?? CreateNewWebhookAccount(webhookSource, integrationInfo).ApiKey;
		}

		/// <inheritdoc cref="IWebhookAccountProvider.GetOrCreateWebhook"/>
		public BaseWebhookAccountResponse GetOrCreateWebhookAccount(string webhookSource, IntegrationInfo integrationInfo) {
			WebhookSubAccountsResponse webhookSubAccounts = WebhookAccountServiceApi.GetSubAccounts();
			BaseWebhookAccountResponse accountBySource = webhookSubAccounts?.SubAccounts
				?.FirstOrDefault(x => x.WebhookSource == webhookSource);
			return accountBySource ?? CreateNewWebhookAccount(webhookSource, integrationInfo);
		}

		/// <inheritdoc cref="IWebhookAccountProvider.EnableHmac"/>
		public BaseWebhookAccountResponse EnableHmac(string apiKey) {
			var updateRequest = new WebhookHmacUpdateRequest {
				ApiKey = apiKey,
				HmacEnabled = true
			};
			var response = WebhookAccountServiceApi.UpdateHmac(updateRequest);
			return response;
		}

		#endregion

	}

	#endregion

}

