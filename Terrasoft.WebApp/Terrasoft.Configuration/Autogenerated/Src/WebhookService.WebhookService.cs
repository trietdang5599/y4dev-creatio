namespace Terrasoft.Configuration
{
	using global::Common.Logging;
	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Linq;
	using System.Runtime.Serialization;
	using System.Security;
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using System.Web.SessionState;
	using Terrasoft.Core;
	using Terrasoft.Core.Factories;
	using Terrasoft.Configuration.LandingiIntegration;
	using Terrasoft.Nui.ServiceModel.DataContract;
	using Terrasoft.Web.Common;

	/// <summary>
	/// Webhook receive service
	/// </summary>
	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class WebhookService : BaseService, IReadOnlySessionState
	{

		#region Fields: Private

		private readonly WebhookParametersParser _webhookParametersParser;
		private readonly IWebhookRepository _webhookRepository;
		private IWebhookExtendedServiceApi _webhookServiceApi;
		private IWebhookAccountServiceApi _webhookAccountServiceApi;
		private readonly ILog _logger = LogManager.GetLogger("Webhooks");

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Default constructor
		/// </summary>
		public WebhookService() {
			_webhookParametersParser = new WebhookParametersParser();
			_webhookRepository = new WebhookRepository(UserConnection);
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="webhookParametersParser">Parser for webhook body</param>
		/// <param name="webhookRepository">Webhook request to webhook entity adapter </param>
		public WebhookService(WebhookParametersParser webhookParametersParser,
			IWebhookRepository webhookRepository) {
			_webhookParametersParser = webhookParametersParser;
			_webhookRepository = webhookRepository;
		}

		#endregion

		#region Properties: Private

		private IWebhookJobDispatcher _webhookJobDispatcher;
		private IWebhookJobDispatcher WebhookJobDispatcher =>
			_webhookJobDispatcher ?? (_webhookJobDispatcher = ClassFactory.Get<IWebhookJobDispatcher>(
				new ConstructorArgument("userConnection", UserConnection)
			));

		#endregion

		#region Properties: Public

		/// <summary>
		/// The webhooks account service api.
		/// </summary>
		public IWebhookAccountServiceApi WebhookAccountServiceApi {
			get =>
				_webhookAccountServiceApi ??
				(_webhookAccountServiceApi = new WebhookAccountServiceApi(UserConnection));
			set => _webhookAccountServiceApi = value;
		}

		/// <summary>
		/// The webhooks service api.
		/// </summary>
		public IWebhookExtendedServiceApi WebhookServiceApi {
			get =>
				_webhookServiceApi ??
				(_webhookServiceApi = new WebhookServiceApi(UserConnection));
			set => _webhookServiceApi = value;
		}

		#endregion


		#region Methods: Private

		/// <summary>
		/// Sum of counts for provided reasons.
		/// </summary>
		/// <param name="keysToSum"></param>
		/// <param name="serviceApiResponse"></param>
		/// <returns></returns>
		private long GetCountsByReasons(Dictionary<WebhookRejectionReason, long> counts, params WebhookRejectionReason[] keysToSum) {
			var count = keysToSum
				.Where(key => counts.ContainsKey(key))
				.Sum(key => counts[key]);
			return count;
		}

		/// <summary>
		/// Sets unprocessed webhooks count to response.
		/// </summary>
		/// <param name="response"></param>
		/// <param name="serviceApiResponse"></param>
		private void SetWebhookTotalCount(UnprocessedWebhooksCountResponse response, GetUnprocessedWebhooksByReasonCountResponse serviceApiResponse) {
			var keysToSum = new[] {
				WebhookRejectionReason.Service_InvalidApiKey,
				WebhookRejectionReason.Service_RestrictedEntity,
				WebhookRejectionReason.Accounts_UnknownApiKey,
				WebhookRejectionReason.Accounts_RouteNotFound,
				WebhookRejectionReason.Creatio_IS503,
				WebhookRejectionReason.Creatio_503,
				WebhookRejectionReason.Creatio_401,
				WebhookRejectionReason.Creatio_403,
				WebhookRejectionReason.Creatio_500,
				WebhookRejectionReason.Accounts_503
			};
			response.WebhooksCount = GetCountsByReasons(serviceApiResponse.Counts, keysToSum);
		}

		/// <summary>
		/// Sets unprocessed webhooks count by reasons to response.
		/// </summary>
		/// <param name="response"></param>
		/// <param name="serviceApiResponse"></param>
		private void SetWebhookAggregatedCounts(UnprocessedWebhooksCountByReasonAggregatedResponse response, GetUnprocessedWebhooksByReasonCountResponse serviceApiResponse) {
			response.NoPermissionsProblemWebhooksCount = GetCountsByReasons(serviceApiResponse.Counts, WebhookRejectionReason.Creatio_403);
			response.RestrictedWebhooksCount = GetCountsByReasons(serviceApiResponse.Counts, WebhookRejectionReason.Service_RestrictedEntity);
			var keysToSum = new[] {
				WebhookRejectionReason.Service_InvalidApiKey,
				WebhookRejectionReason.Accounts_UnknownApiKey,
				WebhookRejectionReason.Accounts_RouteNotFound,
				WebhookRejectionReason.Accounts_503,
				WebhookRejectionReason.Creatio_503,
				WebhookRejectionReason.Creatio_IS503
			};
			response.IntegrationProblemWebhooksCount = GetCountsByReasons(serviceApiResponse.Counts, keysToSum);
			keysToSum = new[] {
				WebhookRejectionReason.Creatio_401,
				WebhookRejectionReason.Creatio_500,
			};
			response.OtherCreatioIssuesWebhooksCount = GetCountsByReasons(serviceApiResponse.Counts, keysToSum);
		}

		/// <summary>
		/// Get All ApiKeys.
		/// </summary>
		/// <returns></returns>
		private IEnumerable<string> GetWebhookIntegrationApiKeys() {
			WebhookSubAccountsResponse webhookSubAccounts = WebhookAccountServiceApi.GetSubAccounts();
			IEnumerable<string> apiKeys = webhookSubAccounts?.SubAccounts?.Select(sa => sa.ApiKey)?.ToList();
			return apiKeys ?? Array.Empty<string>();
		}

		/// <summary>
		/// GetWebhookPersistenceTypes
		/// </summary>
		/// <returns></returns>
		public List<WebhookPersistenceType> GetWebhookPersistenceTypes() {
			return new List<WebhookPersistenceType> {
				WebhookPersistenceType.Restricted,
				WebhookPersistenceType.CantBeSent,
				WebhookPersistenceType.UnknownKey
			};
		}

		/// <summary>
		/// Determines the appropriate HTTP status code based on batch save results.
		/// </summary>
		/// <param name="batchResult">The batch save result.</param>
		/// <returns>Tuple with status code and message.</returns>
		private ResponseStatus GetBatchResponseStatus(WebhookBatchSaveResult batchResult) {
			var successCount = batchResult.Results.Count(r => r.Success);
			var totalCount = batchResult.Results.Count;
			if (successCount == totalCount) {
				return new ResponseStatus("200", "OK");
			}
			if (successCount == 0) {
				return new ResponseStatus("500", "All failed");
			}
			return new ResponseStatus("207", "Multi-Status");
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Api method for receive webhook
		/// </summary>
		/// <param name="streamContent">body of POST request</param>
		/// <returns>Base responce</returns>
		[OperationContract]
		[WebInvoke(Method = "POST",
			BodyStyle = WebMessageBodyStyle.WrappedRequest, ResponseFormat = WebMessageFormat.Json)]
		public BaseResponse HandleWebhooks(Stream streamContent) {
			var httpContext = HttpContextAccessor.GetInstance();
			var webhookParameters = _webhookParametersParser.ParseWebhookParameters(streamContent, httpContext.Request);
			var response = new BaseResponse {
				RowsAffected = 1,
				Success = true,
				ResponseStatus = new ResponseStatus("200", "OK")
			};
			try {
				_webhookRepository.SaveWebhook(webhookParameters);
			} catch (SecurityException e) {
				response.RowsAffected = 0;
				response.Success = false;
				response.ResponseStatus = new ResponseStatus("403", e.Message);
			} catch (Exception e) {
				response.RowsAffected = 0;
				response.Success = false;
				response.ResponseStatus = new ResponseStatus("500", "Internal error");
			}
			return response;
		}

		/// <summary>
		/// Api method for receiving batch webhook requests.
		/// </summary>
		/// <param name="webhookBatch">Batch of webhooks to process.</param>
		/// <returns>Batch processing response with status and failed item IDs.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST",
			BodyStyle = WebMessageBodyStyle.Bare, ResponseFormat = WebMessageFormat.Json)]
		public WebhookBatchResponse HandleWebhookBatch(WebhookBatch webhookBatch) {
			var response = new WebhookBatchResponse {
				RowsAffected = 0,
				Success = false,
				ResponseStatus = new ResponseStatus("200", "OK")
			};
			if (webhookBatch?.Webhooks == null || webhookBatch.Webhooks.Count == 0) {
				response.ResponseStatus = new ResponseStatus("400", "Empty batch");
				return response;
			}
			try {
				var batchResult = _webhookRepository.SaveWebhookBatch(webhookBatch);
				var successCount = batchResult.Results.Count(r => r.Success);
				if (successCount > 0) {
					WebhookJobDispatcher.ScheduleJobs(batchResult.BatchIds);
					response.RowsAffected = successCount;
				}
				response.Success = batchResult.Results.All(r => r.Success);
				response.ResponseStatus = GetBatchResponseStatus(batchResult);
				response.FailedItemIds.AddRange(batchResult.Results.Where(r => !r.Success).Select(r => new WebhookBatchResponseItem {
					Id = r.ItemId,
					ResponseStatus = new ResponseStatus(r.ErrorCode, r.Exception.Message)
				}));
			} catch (Exception e) {
				response.ResponseStatus = new ResponseStatus("500", "Internal error");
				response.FailedItemIds.AddRange(webhookBatch.Webhooks.Select(w => new WebhookBatchResponseItem {
					Id = w.Id
				}));
				_logger.Error("WebhookService_HandleWebhookBatch: Unexpected error occurred", e);
			}
			return response;
		}

		/// <summary>
		/// Api method for receive unprocessed webhooks count.
		/// </summary>
		/// <returns>GetUprocessedWebhooksCountResponse</returns>
		[OperationContract]
		[WebInvoke(Method = "POST",
			BodyStyle = WebMessageBodyStyle.WrappedRequest, ResponseFormat = WebMessageFormat.Json)]
		public UnprocessedWebhooksCountResponse GetUnprocessedWebhooks() {
			var response = new UnprocessedWebhooksCountResponse() {
				ResponseStatus = new ResponseStatus("200", "OK"),
				Success = true,
			};
			try {
				var apiKeys = GetWebhookIntegrationApiKeys();
				if (apiKeys.Any()) {
					var request = new GetUnprocessedWebhooksCountRequest {
						ApiKeys = apiKeys.ToList(),
						Types = GetWebhookPersistenceTypes()
					};
					var serviceApiResponse = WebhookServiceApi.GetUnprocessedWebhooksByReasonCount(request);
					response.Success = serviceApiResponse.Success;
					if (response.Success) {
						SetWebhookTotalCount(response, serviceApiResponse);
					}
				}
			} catch (Exception e) {
				response.Success = false;
				_logger.Error("WebhookService_GetUnprocessedWebhooks: The error occured: ", e);
			}
			return response;
		}

		/// <summary>
		/// Api method for receive unprocessed webhooks count by reasons.
		/// </summary>
		/// <returns>GetUprocessedWebhooksCountResponse</returns>
		[OperationContract]
		[WebInvoke(Method = "POST",
			BodyStyle = WebMessageBodyStyle.WrappedRequest, ResponseFormat = WebMessageFormat.Json)]
		public UnprocessedWebhooksCountByReasonAggregatedResponse GetUnprocessedWebhooksByReason() {
			var response = new UnprocessedWebhooksCountByReasonAggregatedResponse() {
				ResponseStatus = new ResponseStatus("200", "OK"),
				Success = true,
			};
			try {
				var apiKeys = GetWebhookIntegrationApiKeys();
				if (apiKeys.Any()) {
					var request = new GetUnprocessedWebhooksCountRequest {
						ApiKeys = apiKeys.ToList(),
						Types = GetWebhookPersistenceTypes()
					};
					var serviceApiResponse = WebhookServiceApi.GetUnprocessedWebhooksByReasonCount(request);
					response.Success = serviceApiResponse.Success;
					if (response.Success) {
						SetWebhookAggregatedCounts(response, serviceApiResponse);
					}
				}
			} catch (Exception e) {
				response.Success = false;
				_logger.Error("WebhookService_GetUnprocessedWebhooksByReason: The error occured: ", e);
			}
			return response;
		}

		/// <summary>
		/// Api method for resending unprocessed webhooks.
		/// </summary>
		/// <returns>BaseResponse</returns>
		[OperationContract]
		[WebInvoke(Method = "POST",
			BodyStyle = WebMessageBodyStyle.WrappedRequest, ResponseFormat = WebMessageFormat.Json)]
		public BaseResponse ResendUnprocessedWebhooks() {
			var response = new BaseResponse() {
				Success = true,
				ResponseStatus = new ResponseStatus("202", "Accepted")
			};
			try {
				var apiKeys = GetWebhookIntegrationApiKeys();
				if (apiKeys.Any()) {
					var request = new ResendUnprocessedWebhooksRequest {
						ApiKeys = apiKeys.ToList(),
						Types = GetWebhookPersistenceTypes()
					};
					var serviceApiResponse = WebhookServiceApi.ResendUprocessedWebhooks(request);
					response.Success = serviceApiResponse.Success;
				}
			} catch (Exception e) {
				response.Success = false;
				_logger.Error("WebhookService_ResendUnprocessedWebhooks: The error occured: ", e);
			}
			return response;
		}

		/// <summary>
		/// Api method for retrieving webhook service information and capabilities.
		/// </summary>
		/// <returns>WebhookServiceInfoResponse</returns>
		[OperationContract]
		[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "Info")]
		public InfoResponse Info() {
			return new InfoResponse() {
				BatchProcessingEnabled = true
			};
		}

		#endregion

	}

	#region Class: WebhookBatch

	/// <summary>
	/// Represents a batched webhook payload sent to Creatio.
	/// </summary>
	[DataContract]
	public class WebhookBatch
	{
		/// <summary>
		/// Gets or sets the list of webhooks included in the batch.
		/// </summary>
		[DataMember(Name = "webhooks")]
		public List<WebhookBatchItem> Webhooks { get; set; } = new List<WebhookBatchItem>();
	}

	#endregion

	#region Class: WebhookBatchItem

	/// <summary>
	/// Represents a single webhook item inside a batch.
	/// </summary>
	[DataContract]
	public class WebhookBatchItem
	{
		/// <summary>
		/// Gets or sets the client-generated identifier that allows mapping the Creatio response to the original message.
		/// </summary>
		[DataMember(Name = "id")]
		public ulong Id { get; set; }

		/// <summary>
		/// Gets or sets the webhook payload converted to the Creatio contract.
		/// </summary>
		[DataMember(Name = "payload")]
		public WebhookPayload Payload { get; set; } = new WebhookPayload();
	}

	#endregion

	#region Class: WebhookPayload

	/// <summary>
	/// Represents the webhook payload data.
	/// </summary>
	[DataContract]
	public class WebhookPayload
	{
		/// <summary>
		/// Gets or sets the API key for webhook authentication.
		/// </summary>
		[DataMember(Name = "apiKey")]
		public string ApiKey { get; set; }

		/// <summary>
		/// Gets or sets the content type of the webhook payload.
		/// </summary>
		[DataMember(Name = "contentType")]
		public string ContentType { get; set; }

		/// <summary>
		/// Gets or sets the webhook payload data.
		/// </summary>
		[DataMember(Name = "data")]
		public string Data { get; set; }

		/// <summary>
		/// Gets or sets the HTTP headers from the webhook request.
		/// </summary>
		[DataMember(Name = "headers")]
		public string Headers { get; set; }

		/// <summary>
		/// Gets or sets the query parameters from the webhook request.
		/// </summary>
		[DataMember(Name = "queryParameters")]
		public string QueryParameters { get; set; }

		/// <summary>
		/// Gets or sets the source URL of the webhook.
		/// </summary>
		[DataMember(Name = "sourceUrl")]
		public string SourceUrl { get; set; }

		/// <summary>
		/// Gets or sets the webhook source identifier.
		/// </summary>
		[DataMember(Name = "webhookSource")]
		public string WebhookSource { get; set; }
	}

	#endregion

	#region Class: BatchWebhooksResponse

	/// <summary>
	/// Represents the response for batch webhook processing.
	/// </summary>
	[DataContract]
	public class WebhookBatchResponse : BaseResponse
	{
		/// <summary>
		/// Gets or sets per-item responses.
		/// </summary>
		[DataMember(Name = "failedItemIds")]
		public List<WebhookBatchResponseItem> FailedItemIds { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="WebhookBatchResponse"/> class.
		/// </summary>
		public WebhookBatchResponse() {
			FailedItemIds = new List<WebhookBatchResponseItem>();
		}
	}

	#endregion

	#region Class: BatchWebhooksResponse

	/// <summary>
	/// Represents response for a single webhook inside a batch.
	/// </summary>
	[DataContract]
	public class WebhookBatchResponseItem
	{
		/// <summary>
		/// Gets or sets identifier supplied in the request.
		/// </summary>
		[DataMember(Name = "id")]
		public ulong Id { get; set; }

		/// <summary>
		/// Gets or sets response status for logging/troubleshooting purposes.
		/// </summary>
		[DataMember(Name = "responseStatus")]
		public ResponseStatus ResponseStatus { get; set; }
	}

	#endregion

	#region Class: InfoResponse

	/// <summary>
	/// Represents the response for webhook service information request.
	/// </summary>
	[DataContract]
	public class InfoResponse
	{
		/// <summary>
		/// Gets or sets a value indicating whether the service supports batch processing.
		/// </summary>
		[DataMember(Name = "batchProcessingEnabled")]
		public bool BatchProcessingEnabled { get; set; }
	}

	#endregion

}

