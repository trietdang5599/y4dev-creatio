namespace Terrasoft.Configuration.OAuth20
{
	using System;
	using global::Common.Logging;
	using Terrasoft.Common;
	using Terrasoft.Configuration.BpmonlineCloudIntegration;
	using Terrasoft.Configuration.LandingiIntegration;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Entities.Events;

	[EntityEventListener(SchemaName = "OAuthClientApp")]
	public class WebhookIdentityListener : BaseEntityEventListener
	{

		private const string WebhookAccountServiceIdentityName = "Webhook Account Service Identity";
		private const string Scope = "webhook.creatio.full_access";
		private const string SyncErrorResourceName = "WebhookIdentitySyncErrorMessage";
		private static ILog _logger;
		private static ILog Logger => _logger ?? (_logger = LogManager.GetLogger("WebhookIdentityListener"));

		private string GetLczString(UserConnection userConnection, string lczName) {
			string localizableStringName = string.Format("LocalizableStrings.{0}.Value", lczName);
			return new LocalizableString(userConnection.Workspace.ResourceStorage, nameof(WebhookIdentityListener),
				localizableStringName
			);
		}

		private UpdateWebhookSubAccountsRequest FillUpdateWebhookAccountRequest(Entity entity, UserConnection userConnection) {
			return new UpdateWebhookSubAccountsRequest {
				CreatedBy = userConnection.CurrentUser.Name,
				CreatedOn = DateTime.UtcNow,
				CreatioClientId = entity.GetTypedColumnValue<string>("ClientId"),
				CreatioClientSecret = entity.GetTypedColumnValue<string>("ClientSecret")
			};
		}

		private void UpdateWebhookSubAccounts(UserConnection userConnection, UpdateWebhookSubAccountsRequest updateRequest) {
			var webhookAccountServiceApi = new WebhookAccountServiceApi(userConnection);
			var response = webhookAccountServiceApi.UpdateSubAccounts(updateRequest);
			if (!string.IsNullOrEmpty(response.ErrorMessage)) {
				throw new ApplicationException(GetLczString(userConnection, SyncErrorResourceName));
			}
		}

		private RootAccountInfoResponse GetRootAccount(UserConnection userConnection) {
			var rootAccountProvider = new RootAccountProvider(userConnection, Scope);
			RootAccountInfoResponse rootAccount = null;
			try {
				rootAccount = rootAccountProvider.GetSocialRootAccount();
				if (rootAccount != null && !string.IsNullOrEmpty(rootAccount.ErrorMessage)) {
					throw new ApplicationException(GetLczString(userConnection, SyncErrorResourceName));
				}
			} catch (ApplicationException) {
				throw;
			} catch (Exception e) {
				Logger.Error("Error when get root account from account service.", e);
			}
			return rootAccount;
		}

		private void UpdateRelatedAccountsData(Entity entity) {
			string entityName = entity.GetTypedColumnValue<string>("Name");
			if (!entityName.Equals(WebhookAccountServiceIdentityName)) {
				return;
			}
			var userConnection = entity.UserConnection;
			var rootAccount = GetRootAccount(userConnection);
			if (rootAccount is null) {
				return;
			}
			var updateRequest = FillUpdateWebhookAccountRequest(entity, userConnection);
			UpdateWebhookSubAccounts(userConnection, updateRequest);
		}

		/// <summary>
		/// Handles entity Saved event.
		/// </summary>
		/// <param name="sender">Event sender.</param>
		/// <param name="e">The <see cref="T:Terrasoft.Core.Entities.EntityAfterEventArgs" /> instance containing the
		/// event data.</param>
		public override void OnInserting(object sender, EntityBeforeEventArgs e) {
			var entity = sender as Entity;
			UpdateRelatedAccountsData(entity);
			base.OnInserting(sender, e);
		}


		/// <summary>Handles entity Updating event.</summary>
		/// <param name="sender">Event sender.</param>
		/// <param name="e">The <see cref="T:Terrasoft.Core.Entities.EntityBeforeEventArgs" /> instance containing the event data.</param>
		public override void OnUpdating(object sender, EntityBeforeEventArgs e) {
			var entity = sender as Entity;
			UpdateRelatedAccountsData(entity);
			base.OnUpdating(sender, e);
		}

	}

}

