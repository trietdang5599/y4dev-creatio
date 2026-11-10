namespace Terrasoft.Configuration.Deduplication
{
	using System;
	using System.Net;
	using global::Common.Logging;
	using DeduplicationElastic.Domain.Deduplication.Task;
	using DeduplicationElastic.WebApi.Contracts.Response;
	using Terrasoft.Core;
	using Terrasoft.Core.Factories;
	using Terrasoft.Core.Configuration;
	using Terrasoft.Core.Requests;
	using Terrasoft.Web.Http.Abstractions;

	#region class: BulkDeduplicationTaskHttpClient

	/// <summary>
	/// Rest based implementation of <see cref="IBulkDeduplicationTaskClient"/>
	/// </summary>
	[DefaultBinding(typeof(IBulkDeduplicationTaskClient))]
	public class BulkDeduplicationTaskHttpClient : IBulkDeduplicationTaskClient
	{

		#region Constants: Private

		private const string DeduplicationWebApiUrlSettingCode = "DeduplicationWebApiUrl";

		#endregion

		#region Fields: Private

		private const string DeduplicationTaskControllerPath = "api/deduplication/task/";
		private readonly string _deduplicationWebApiUrl;
		private static readonly ILog _log = LogManager.GetLogger("Deduplication");

		#endregion

		#region Properties: Private

		private string BaseUrl => _deduplicationWebApiUrl.TrimEnd('/');

		private IHttpRequestClient _httpClient;
		private IHttpRequestClient HttpClient {
			get {
				if (_httpClient != null) {
					return _httpClient;
				}
				var tag = DeduplicationEventListener.BulkDeduplicationTaskHttpClientTag;
				if (!HttpRequestClientFactory.TryGetNamedInstance(tag, out _httpClient)) {
					_httpClient = HttpRequestClientFactory.GetInstanceFromDI();
				}
				return _httpClient;
			}
		}

		#endregion

		#region Constructors: Public

		public BulkDeduplicationTaskHttpClient(UserConnection userConnection) {
			_deduplicationWebApiUrl = SysSettings.GetValue(userConnection, DeduplicationWebApiUrlSettingCode, string.Empty);
		}

		#endregion

		#region Methods: Private

		private DeduplicationTaskStatus? GetDeduplicationTaskStatus(IHttpResponse response, string entityName) {
			var deduplicationTaskResponse = response.GetResult<DeduplicationTaskResponse>();
			switch (response.StatusCode) {
				case HttpStatusCode.OK: {
					return deduplicationTaskResponse.TaskStatus;
				}
				case HttpStatusCode.NotFound: {
					if (deduplicationTaskResponse == null) {
						_log.Error($"GetDeduplicationTaskStatus for '{entityName}' failed. StatusCode: {response.StatusCode}, " +
							$"ReasonPhrase: {response.ReasonPhrase}, ErrorException: {response.Exception}, " +
							$"Content: {response.Content}, ResponseUri: {response.RequestConfig.Url}");
						throw new HttpException(HttpStatusCode.NotFound, response.Content);
					}
					return null;
				}
				default: {
					_log.Error($"GetDeduplicationTaskStatus failed. StatusCode: {response.StatusCode}, " +
						$"ReasonPhrase: {response.ReasonPhrase}, ErrorException: {response.Exception}, " +
						$"Content: {response.Content}, ResponseUri: {response.RequestConfig.Url}");
					throw new NotSupportedException($"Status code {response.StatusCode} not supported. ");
				}
			}
		}

		private IHttpResponse GetDeduplicationTaskResponse(string controllerActionName,
				string entityName, string indexName) {
			var resource = $"{DeduplicationTaskControllerPath}{controllerActionName}";
			var request = new HttpRequestConfig(new Uri(BaseUrl), resource, HttpRequestMethod.GET);
			request.AddQueryParam("sourceEntityName", entityName);
			request.AddQueryParam("elasticIndexName", indexName);
			return HttpClient.Send(request);
		}

		#endregion

		#region Methods: Public

		/// <inheritdoc/>
		public DeduplicationTaskStatus? GetDeduplicationTaskStatus(string entityName, string indexName) {
			var response = GetDeduplicationTaskResponse("status", entityName, indexName);
			return GetDeduplicationTaskStatus(response, entityName);
		}

		/// <inheritdoc/>
		public DeduplicationTaskResponse GetActualDeduplicationTask(string entityName, string indexName) {
			var response = GetDeduplicationTaskResponse("actual", entityName, indexName);
			if (response.StatusCode == HttpStatusCode.NotFound) {
				return null;
			}
			if (response.StatusCode != HttpStatusCode.OK) {
				throw new HttpException(response.StatusCode, response.Content);
			}
			return response.GetResult<DeduplicationTaskResponse>();
		}

		#endregion

	} 

	#endregion

}

