namespace Terrasoft.Core.Process.Configuration
{
	using System;
	using Newtonsoft.Json.Linq;
	using Terrasoft.Common;
	using Terrasoft.Configuration;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Process;

	#region Class: WebhookToEntityUserTask

	/// <exclude/>
	public partial class WebhookToEntityUserTask
	{

		#region Fields: Private

		private readonly WebhookDescriptionProvider _webhookDescriptionProvider = new WebhookDescriptionProvider();

		#endregion

		#region Methods: Private

		private void FillOutputParameters(Entity webhookEntity, WebhookDescription webhookDescription) {
			var trackingIdText = webhookDescription.RequestBody["TrackingId"]?.Value<string>();
			Guid.TryParse(trackingIdText, out var trackingId);
			var compositeObject = new CompositeObject {
				{ "EntityId", webhookEntity.PrimaryColumnValue },
				{ "EntityName", webhookEntity.SchemaName },
				{ "TrackingUserId", webhookDescription.RequestBody["TrackingUserId"]?.Value<string>() },
				{ "TrackingId", trackingId },
				{ "LandingPageUrl", webhookDescription.RequestBody["PageUrl"]?.Value<string>() }
			};
			((CompositeObjectList<CompositeObject>)EntityIdentifiers).Add(compositeObject);
		}

		private WebhookObj GetWebhookObj(ICompositeObject webhookObject) {
			webhookObject.TryGetValue("ContentType", out string contentType);
			webhookObject.TryGetValue("Headers", out string headers);
			webhookObject.TryGetValue("QueryParameters", out string queryParameters);
			webhookObject.TryGetValue("RequestBody", out string requestBody);
			webhookObject.TryGetValue("Id", out Guid id);
			webhookObject.TryGetValue("WebhookSource", out string webhookSource);
			webhookObject.TryGetValue("SourceUrl", out string sourceUrl);
			return new WebhookObj {
				ContentType = contentType,
				Headers = headers,
				QueryParameters = queryParameters,
				RequestBody = requestBody,
				UId = id,
				WebhookSource = webhookSource,
				SourceUrl = sourceUrl
			};
		}

		private void UpdateWebhookStatus(ICompositeObjectList<ICompositeObject> webhooks, string webhookStatus) {
			foreach (ICompositeObject webhookObject in webhooks) {
				webhookObject.TryGetValue("Id", out Guid webhookId);
				UpdateWebhookStatus(webhookId, webhookStatus);
			}
		}

		private void UpdateWebhookStatus(Guid webhookId, string webhookStatus) {
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "Webhook");
			IEntitySchemaQueryFilterItem filter =
				esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Id", webhookId);
			esq.Filters.Add(filter);
			esq.AddColumn("Id");
			esq.AddColumn("Status");
			esq.PrimaryQueryColumn.IsAlwaysSelect = true;
			Entity webhookEntity = esq.GetEntity(UserConnection, webhookId);
			webhookEntity.SetColumnValue("StatusId", webhookStatus);
			webhookEntity.UpdateInDB();
		}

		#endregion

		#region Methods: Protected

		protected override bool InternalExecute(ProcessExecutingContext context) {
			var webhookLogWriter = new WebhookLogWriter(UserConnection);
			var entityProviderFactory = new EntityProviderFactory(UserConnection);
			UpdateWebhookStatus(Webhooks, WebhookServiceConstants.ProcessingWebhookStatus);
			foreach (ICompositeObject webhookObject in Webhooks) {
				WebhookObj webhook = GetWebhookObj(webhookObject);
				if (webhook.ContentType.IsNullOrEmpty()) {
					webhookLogWriter.LogWebhookError(webhook.UId,
						"An error occurred while processing the webhook. " +
						"Exception: The parameter \"{Content type}\" should be existing and not empty.");
					UpdateWebhookStatus(webhook.UId, WebhookServiceConstants.FailedWebhookStatus);
					continue;
				}
				if (!_webhookDescriptionProvider.TryGetWebhookDescription(webhook,
					out WebhookDescription webhookDescription, out string descriptionErrorMessage)) {
					webhookLogWriter.LogWebhookError(webhook.UId,
						$"An error occurred while processing the webhook. Exception: {descriptionErrorMessage}");
					UpdateWebhookStatus(webhook.UId, WebhookServiceConstants.FailedWebhookStatus);
					continue;
				}
				var entityName = webhookDescription.GetEntityType();
				if (string.IsNullOrEmpty(entityName)) {
					webhookLogWriter.LogWebhookError(webhook.UId,
						"An error occurred while processing the webhook. " +
						"The parameter \"{Entity name}\" should be existing and not empty.");
					UpdateWebhookStatus(webhook.UId, WebhookServiceConstants.FailedWebhookStatus);
					continue;
				}
				if (!entityProviderFactory.TryGetWebhookEntityProvider(entityName,
					out IWebhookEntityProvider entityProvider, out string entityErrorMessage, true)) {
					webhookLogWriter.LogWebhookError(webhook.UId,
						$"An error occurred while processing the webhook. Entity name: \"{entityName}\". " +
						$"Exception: {entityErrorMessage}");
					UpdateWebhookStatus(webhook.UId, WebhookServiceConstants.FailedWebhookStatus);
					continue;
				}
				try {
					Entity webhookEntity = entityProvider.GetEntity(webhookDescription);
					webhookEntity.Save(validateRequired: false);
					UpdateWebhookStatus(webhook.UId, WebhookServiceConstants.DoneWebhookStatus);
					FillOutputParameters(webhookEntity, webhookDescription);
				} catch (Exception e) {
					UpdateWebhookStatus(webhook.UId, WebhookServiceConstants.FailedWebhookStatus);
					webhookLogWriter.LogWebhookError(webhook.UId,
						$"An error occurred while processing the webhook. Entity name: \"{entityName}\"; " +
						$"Exception: {e.Message}; " +
						$"Inner exception: {e.InnerException?.Message}; " +
						$"Stack trace: {e.StackTrace}");
				}
			}
			return true;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Returns the data required to display the execution page.
		/// </summary>
		/// <returns>
		/// String that represents the data needed for showing execution page.
		/// </returns>
		public override string GetExecutionData() {
			return string.Empty;
		}
		
		#endregion

	}

	#endregion

}
