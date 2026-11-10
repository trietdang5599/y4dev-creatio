namespace Terrasoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Collections.Specialized;
	using System.Security;
	using global::Common.Logging;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities;

	#region Class: WebhookBatchSaveResult

	/// <summary>
	/// Represents the result of saving a batch of webhooks.
	/// </summary>
	public class WebhookBatchSaveResult
	{
		/// <summary>
		/// Gets or sets the list of batch identifiers assigned to webhooks.
		/// When the webhook count exceeds the maximum batch size, multiple batches are created.
		/// </summary>
		public List<Guid> BatchIds { get; set; }

		/// <summary>
		/// Gets or sets the list of individual webhook batch item save results.
		/// </summary>
		public List<WebhookBatchItemSaveResult> Results { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="WebhookBatchSaveResult"/> class.
		/// </summary>
		public WebhookBatchSaveResult() {
			BatchIds = new List<Guid>();
			Results = new List<WebhookBatchItemSaveResult>();
		}
	}

	#endregion

	#region Class: WebhookBatchItemSaveResult

	/// <summary>
	/// Represents the result of saving a single webhook batch item.
	/// </summary>
	public class WebhookBatchItemSaveResult
	{
		/// <summary>
		/// Gets or sets the client-provided webhook item identifier.
		/// </summary>
		public ulong ItemId { get; set; }

		/// <summary>
		/// Gets or sets the created webhook entity identifier.
		/// </summary>
		public Guid WebhookId { get; set; }

		/// <summary>
		/// Gets or sets the batch identifier this webhook item belongs to.
		/// </summary>
		public Guid BatchId { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether the webhook was saved successfully.
		/// </summary>
		public bool Success { get; set; }

		/// <summary>
		/// Gets or sets exception for logging/troubleshooting purposes.
		/// </summary>
		public Exception Exception { get; set; }

		/// <summary>
		/// Gets or sets error code for logging/troubleshooting purposes.
		/// </summary>
		public string ErrorCode { get; set; }
	}

	#endregion

	#region Interface: IWebhookRepository

	/// <summary>
	/// Represents the interface for webhook saving.
	/// </summary>
	public interface IWebhookRepository
	{
		/// <summary>
		/// Create webhook entity.
		/// </summary>
		/// <param name="webhookParameters">Webhook parameters collection.</param>
		/// <returns>Webhook entity id.</returns>
		Guid SaveWebhook(NameValueCollection webhookParameters);

		/// <summary>
		/// Save multiple webhooks as a batch with individual error handling.
		/// If the number of webhooks exceeds the maximum batch size, they will be split into multiple batches.
		/// </summary>
		/// <param name="webhookBatch">Batch of webhooks to save.</param>
		/// <returns>Batch save result with status for each webhook and list of batch IDs created.</returns>
		WebhookBatchSaveResult SaveWebhookBatch(WebhookBatch webhookBatch);
	}

	#endregion

	#region Class: WebhookRepository

	/// <summary>
	/// Webhook request to webhook entity adapter 
	/// </summary>
	public class WebhookRepository : IWebhookRepository
	{

		#region Fields: Private

		/// <summary>
		/// Instance of UserConnection.
		/// </summary>
		private readonly UserConnection UserConnection;

		/// <summary>
		/// Maximum number of webhooks that can be processed in a single batch.
		/// This is a hard limit to prevent performance issues.
		/// </summary>
		private const int MaxBatchSize = 100;

		#endregion

		#region Properties: Private

		/// <summary>
		/// Represents the logger instance used for logging within the class.
		/// </summary>
		private ILog _logger;
		private ILog Logger => _logger ?? (_logger = LogManager.GetLogger(nameof(WebhookRepository)));

		/// <summary>
		/// Gets the capped batch size, ensuring it does not exceed the maximum allowed batch size.
		/// </summary>
		private int CappedBatchSize { get; set; }

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="userConnection">Instance of UserConnection</param>
		public WebhookRepository(UserConnection userConnection) {
			UserConnection = userConnection;
			var batchSize = Core.Configuration.SysSettings.GetValue(UserConnection, "WebhookBatchProcessingSize", MaxBatchSize);
			CappedBatchSize = Math.Min(batchSize, MaxBatchSize);
		}

		#endregion

		#region Methods: Private

		private Entity BuildWebhook(NameValueCollection webhookParameters, Guid? batchId = null) {
			var webhookSchema = UserConnection.EntitySchemaManager.GetInstanceByName("Webhook");
			var webhook = webhookSchema.CreateEntity(UserConnection);
			SetWebhookValues(webhook, webhookParameters, batchId);
			return webhook;
		}

		/// <summary>
		/// Set parameters value to webhook entity
		/// </summary>
		/// <param name="webhook">Webhook entity</param>
		/// <param name="webhookParameters">Webhook parameters collection</param>
		/// <param name="batchId">Optional batch identifier</param>
		private void SetWebhookValues(Entity webhook, NameValueCollection webhookParameters, Guid? batchId = null) {
			var apiKey = webhookParameters["ApiKey"];
			var contentType = webhookParameters["ContentType"];
			var headers = webhookParameters["Headers"];
			var queryParameters = webhookParameters["QueryParameters"];
			var requestBody = webhookParameters["data"];
			var sourceUrl = webhookParameters["SourceUrl"];
			var webhookSource = webhookParameters["WebhookSource"];
			webhook.SetDefColumnValues();
			webhook.SetColumnValue("ApiKey", apiKey);
			webhook.SetColumnValue("ContentType", contentType);
			webhook.SetColumnValue("Headers", headers);
			webhook.SetColumnValue("QueryParameters", queryParameters);
			webhook.SetColumnValue("RequestBody", requestBody);
			webhook.SetColumnValue("SourceUrl", sourceUrl);
			webhook.SetColumnValue("WebhookSource", webhookSource);
			if (batchId.HasValue) {
				webhook.SetColumnValue("BatchId", batchId.Value);
			}
		}

		/// <summary>
		/// Processes and saves a single webhook item from a batch operation with error handling.
		/// </summary>
		/// <param name="batchId">The batch identifier to associate with the webhook.</param>
		/// <param name="batchItem">The webhook batch item containing the payload and identifier.</param>
		/// <returns>Result object containing save status, webhook ID, and success indicator.</returns>
		private WebhookBatchItemSaveResult SaveWebhookBatchItem(Guid batchId, WebhookBatchItem batchItem) {
			var itemResult = new WebhookBatchItemSaveResult {
				ItemId = batchItem.Id,
				BatchId = batchId,
				Success = false
			};
			try
			{
				var webhookParameters = ConvertPayloadToNameValueCollection(batchItem.Payload);
				var webhook = BuildWebhook(webhookParameters, batchId);
				webhook.Save();
				itemResult.WebhookId = webhook.PrimaryColumnValue;
				itemResult.Success = true;
			}
			catch (SecurityException e)
			{
				itemResult.Success = false;
				itemResult.Exception = e;
				itemResult.ErrorCode = "403";
				Logger.Error(e.Message, e);
			}
			catch (Exception e)
			{
				itemResult.Success = false;
				itemResult.Exception = e;
				itemResult.ErrorCode = "500";
				Logger.Error(e.Message, e);
			}
			return itemResult;
		}

		/// <summary>
		/// Processes a single chunk of webhook batch items and saves them with the specified batch ID.
		/// </summary>
		/// <param name="chunk">The chunk of webhook batch items to process.</param>
		/// <param name="batchId">The batch identifier to associate with all webhooks in this chunk.</param>
		/// <returns>List of individual webhook batch item save results.</returns>
		private List<WebhookBatchItemSaveResult> ProcessWebhookChunk(List<WebhookBatchItem> chunk, Guid batchId) {
			var results = new List<WebhookBatchItemSaveResult>();
			foreach (var batchItem in chunk) {
				var itemSaveResult = SaveWebhookBatchItem(batchId, batchItem);
				results.Add(itemSaveResult);
			}
			return results;
		}

		/// <summary>
		/// Splits a list of webhook batch items into smaller chunks of specified size.
		/// </summary>
		/// <param name="items">The list of webhook batch items to split.</param>
		/// <param name="chunkSize">The maximum size of each chunk.</param>
		/// <returns>A list of chunked webhook batch item lists.</returns>
		private List<List<WebhookBatchItem>> SplitIntoChunks(List<WebhookBatchItem> items) {
			var chunks = new List<List<WebhookBatchItem>>();
			for (var i = 0; i < items.Count; i += CappedBatchSize) {
				var chunk = items.GetRange(i, Math.Min(CappedBatchSize, items.Count - i));
				chunks.Add(chunk);
			}
			return chunks;
		}

		/// <summary>
		/// Converts WebhookPayload to NameValueCollection.
		/// </summary>
		/// <param name="payload">The webhook payload.</param>
		/// <returns>NameValueCollection with webhook parameters.</returns>
		private NameValueCollection ConvertPayloadToNameValueCollection(WebhookPayload payload) {
			var collection = new NameValueCollection();
			collection["ApiKey"] = payload.ApiKey;
			collection["ContentType"] = payload.ContentType;
			collection["data"] = payload.Data;
			collection["Headers"] = payload.Headers;
			collection["QueryParameters"] = payload.QueryParameters;
			collection["SourceUrl"] = payload.SourceUrl;
			collection["WebhookSource"] = payload.WebhookSource;
			return collection;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Create webhook entity
		/// </summary>
		/// <param name="webhookParameters">Webhook parameters collection</param>
		/// <returns>Webhook entity id</returns>
		public Guid SaveWebhook(NameValueCollection webhookParameters) {
			var webhook = BuildWebhook(webhookParameters);
			webhook.Save();
			return webhook.PrimaryColumnValue;
		}

		/// <summary>
		/// Save multiple webhooks as a batch with individual error handling.
		/// If the number of webhooks exceeds the maximum batch size, they will be split into multiple batches.
		/// </summary>
		/// <param name="webhookBatch">Batch of webhooks to save.</param>
		/// <returns>Batch save result with status for each webhook and list of batch IDs created.</returns>
		public virtual WebhookBatchSaveResult SaveWebhookBatch(WebhookBatch webhookBatch) {
			var result = new WebhookBatchSaveResult();
			var chunks = SplitIntoChunks(webhookBatch.Webhooks);
			var totalChunks = chunks.Count;
			if (totalChunks > 1) {
				Logger.Error($"Splitting {webhookBatch.Webhooks.Count} webhooks into {totalChunks} batches (batch size: {CappedBatchSize})");
			}
			foreach (var chunk in chunks) {
				var batchId = Guid.NewGuid();
				result.BatchIds.Add(batchId);
				var webhookChunkResults = ProcessWebhookChunk(chunk, batchId);
				result.Results.AddRange(webhookChunkResults);
			}
			return result;
		}

		#endregion

	}

	#endregion

}

