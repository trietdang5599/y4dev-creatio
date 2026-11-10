namespace Terrasoft.Configuration.GlobalSearch
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using System.Threading;
	using System.Threading.Tasks;
	using System.Web.SessionState;
	using Core.Factories;
	using global::Common.Logging;
	using Newtonsoft.Json;
	using Terrasoft.Common;
	using Terrasoft.Configuration.GlobalSearchDto;
	using Terrasoft.Configuration.GlobalSearchHelper;
	using Terrasoft.Core.Requests;
	using Web.Common;
	using Terrasoft.GlobalSearch;
	using Terrasoft.Nui.ServiceModel.DataContract;
	using Terrasoft.Monitoring;
	using Terrasoft.GlobalSearch.Monitoring;
	using Terrasoft.OAuthIntegration;
	using Terrasoft.Web.Common.ServiceRouting;
	using Terrasoft.Web.Http.Abstractions;
	using ErrorInfo = Terrasoft.Core.ServiceModelContract.ErrorInfo;
	using Terrasoft.Core;

	#region Class: GlobalSearchService

	/// <summary>
	/// Global search service proxy.
	/// </summary>
	[ServiceContract]
	[DefaultServiceRoute]
	[SspServiceRoute]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class GlobalSearchService : BaseService, IReadOnlySessionState
	{

		#region Constants: Private

		private const string ServiceMisconfiguredErrorCode = "ServiceMisconfigured";

		#endregion

		#region Fields: Private

		private readonly IMetricReporter _metricReporter = ClassFactory.Get<IMetricReporter>();
		private GlobalSearchHelper _globalSearchHelper;
		private static readonly ILog _log = LogManager.GetLogger("GlobalSearch");

		#endregion

		#region Constructors: Public 

		public GlobalSearchService() {
		}

		public GlobalSearchService(UserConnection userConnection) {
			UserConnection = userConnection;
		}

		#endregion

		#region Properties: Private

		private GlobalSearchHelper SearchHelper {
			get {
				if (_globalSearchHelper == null) {
					_globalSearchHelper = ClassFactory.Get<GlobalSearchHelper>(new ConstructorArgument("userConnection",
						UserConnection));
				}
				return _globalSearchHelper;
			}
		}

		private string SearchServiceUrl {
			get {
				return (string)Core.Configuration.SysSettings.GetValue(UserConnection, "GlobalSearchUrl");
			}
		}

		private int RequestTimeout {
			get {
				var ms = Core.Configuration.SysSettings.GetValue(UserConnection, "DataServiceQueryTimeout", 30 * 1000);
			    return ms / 1000;
			}
		}

		private int TotalPagePerRequestTimeout {
			get {
			    return Core.Configuration.SysSettings.GetValue(UserConnection, "GlobalSearchTotalPagePerRequestTimeout", -1);
			}
		}

		private int TotalPagePerRequestLimit {
			get {
			    return Core.Configuration.SysSettings.GetValue(UserConnection, "GlobalSearchTotalPagePerRequestLimit", 10);
			}
		}

		private IHttpRequestClient _httpClient;
		private IHttpRequestClient HttpClient {
			get {
				if (!HttpRequestClientFactory.TryGetNamedInstance("GlobalSearchServiceHttpClient", out _httpClient)) {
					_httpClient = HttpRequestClientFactory.GetInstanceFromDI();
				}
				return _httpClient;
			}
		}

		private IIdentityServiceWrapper _identityServiceWrapper;

		private IIdentityServiceWrapper IdentityServiceWrapper =>
			_identityServiceWrapper ?? (_identityServiceWrapper = IdentityServiceWrapperHelper.GetInstance());

		#endregion

		#region Properties: Protected

		/// <summary>
		/// Global search connector helper instance <see cref="GlobalSearchConnectorHelper"/>.
		/// </summary>
		private GlobalSearchConnectorHelper _globalSearchConnectorHelper;
		protected virtual GlobalSearchConnectorHelper GlobalSearchConnectorHelper =>
			_globalSearchConnectorHelper ?? (_globalSearchConnectorHelper =
				ClassFactory.Get<GlobalSearchConnectorHelper>(new ConstructorArgument("userConnection", UserConnection)));

		/// <summary>
		/// Global search health checker instance <see cref="IGlobalSearchConfigurationHealthChecker"/>.
		/// </summary>
		private IGlobalSearchConfigurationHealthChecker _globalSearchConfigurationHealthChecker;
		protected virtual IGlobalSearchConfigurationHealthChecker GlobalSearchConfigurationHealthChecker =>
			_globalSearchConfigurationHealthChecker ?? (_globalSearchConfigurationHealthChecker =
				ClassFactory.Get<IGlobalSearchConfigurationHealthChecker>());

		/// <summary>
		/// Cancellation token instance <see cref="CancellationToken"/>.
		/// </summary>
		protected virtual CancellationToken CancellationToken {
			get {
				if (HttpContext.Current != null && HttpContext.Current.Response != null) {
					return HttpContext.Current.Response.ClientDisconnectedToken;
				}
				return CancellationToken.None;
			}
		}

		#endregion

		#region Methods: Private

		/// <summary>
		/// Filters passed types by access rights of current user.
		/// </summary>
		/// <param name="type">Comma-separated entity schema names.</param>
		/// <returns>Comma-separated entity schema names filtered by current user access rights.</returns>
		private string FilterTypeByAccessRights(string type) {
			var sections = type
				.Split(',')
				.Where(UserConnection.DBSecurityEngine.GetIsEntitySchemaReadingAllowed);
			return string.Join(",", sections);
		}

		private HttpRequestConfig PrepareRequest(string type) {
			var typeString = string.IsNullOrEmpty(type) ? string.Empty : $"/{FilterTypeByAccessRights(type)}";
			string url = $"{SearchServiceUrl}{typeString}/_search?search_type=dfs_query_then_fetch";
			string scope = GlobalSearchOAuthScopes.GetScopeForCurrentUser(UserConnection);
			var request = new HttpRequestConfig {
					Url = new Uri(url),
					Method = HttpRequestMethod.POST,
					RequestTimeout = RequestTimeout,
					CancellationToken = CancellationToken
				}.WithOAuth<GlobalSearchFeatures.UseOAuth>(IdentityServiceWrapper, scope);
			if (Creatio.FeatureToggling.Features.GetIsDisabled<GlobalSearchFeatures.UseOAuth>()) {
				GlobalSearchConnectorHelper.AppendCredentials(request);
			}
			return request;
		}

		private BaseResponse GetErrorResponse(IHttpResponse response, ErrorInfo errorInfo = null) {
			string errorCode;
			if (response.IsTimedOut) {
				errorCode = "TimedOut";
			} else if (response.Exception is TaskCanceledException) {
				errorCode = "Aborted";
			} else {
				errorCode = "Error";
			}
			var info = errorInfo ?? new ErrorInfo {
				Message = response.Exception?.GetAllMessages() ?? response.ReasonPhrase ?? response.Content,
				ErrorCode = errorCode
			};
			BpmSearchResponse searchResponse = new BpmSearchResponse {
				Success = false,
				ErrorInfo = info
			};
			string responseJson = JsonConvert.SerializeObject(response);
			_log.Error($@"ResponseStatus: {info.ErrorCode}
						StatusCode: {response.StatusCode}
						ErrorMessage: {info.Message}
						Content: {response.Content},
						Response: {responseJson}");
			return searchResponse;
		}

		private void SetResponseNextFrom(BpmSearchResponse bpmSearchResponse, ESSearchResponse esSearchResponse,
			SearchRequestQuery searchRequestQuery) {
			var lastNeededHitId = bpmSearchResponse.Data.Last().Id;
			var lastIndexFromElasticResponce =
				esSearchResponse.SearchResult.Hits.ToList()
					.FindIndex(x => string.Equals(x.Id, lastNeededHitId, StringComparison.InvariantCultureIgnoreCase));
			bpmSearchResponse.NextFrom = searchRequestQuery.From + lastIndexFromElasticResponce + 1;
		}

		private bool GetIsNotExpired(DateTime startedOn, int currentPage, int? totalRecords = 0) {
			if (currentPage == 0) {
				return true;
			}
			var isMaxPagesCountExceeded = IsMaxPagesCountExceeded(currentPage);
			if (isMaxPagesCountExceeded) {
				_log.Warn($"Search terminated by CurrentPage:{currentPage}. TotalPagePerRequestLimit: {TotalPagePerRequestLimit}");
			}
			var isExpiredByTimeout = IsExpiredByTimeout(startedOn);
			if (isExpiredByTimeout) {
				_log.Warn($"Search terminated by Timeout Ms:{GetTotalMilliseconds(startedOn)}. TotalPagePerRequestTimeout: {TotalPagePerRequestTimeout}");
			}
			var isExpired = isExpiredByTimeout || isMaxPagesCountExceeded;
			if (isExpired && totalRecords == 0) {
				_log.Error($@"Search results are empty because recursion was detected during the process of filtering records by access rights.
							For additional information, enable warning level logging.");
			}
			return !isExpired;
		}

		private bool GetNeedLoadRecords(int recordCount, BpmSearchResponse bpmSearchResponse) {
			int availableRecordCount = bpmSearchResponse == null ? 0 : bpmSearchResponse.Data.Count;
			return availableRecordCount < recordCount;
		}

		private bool HasAvailableElasticRecords(SearchRequestQuery searchRequestQuery, int totalFoundRecordCount) {
			return searchRequestQuery == null || searchRequestQuery.From + searchRequestQuery.Size < totalFoundRecordCount;
		}

		private bool GetNeedLoadNextPage(BpmSearchResponse bpmSearchResponse, SearchRequestQuery searchRequestQuery, int totalFoundRecordCount, int recordCount) {
            return GetNeedLoadRecords(recordCount, bpmSearchResponse) && HasAvailableElasticRecords(searchRequestQuery, totalFoundRecordCount);
		}

		private int GetTotalMilliseconds(DateTime startedOn) {
			TimeSpan diffSpan = DateTime.Now - startedOn;
			return (int)diffSpan.TotalMilliseconds;
		}

        private bool IsMaxPagesCountExceeded(int currentPage) {
			if (TotalPagePerRequestLimit <= 0) {
				return false;
			}
			return currentPage > TotalPagePerRequestLimit;
        }

        private bool IsExpiredByTimeout(DateTime startedOn) {
			if (TotalPagePerRequestTimeout <= 0) {
				return false;
			}
			int totalExecMs = GetTotalMilliseconds(startedOn);
			return totalExecMs > TotalPagePerRequestTimeout;
        }

		private IHttpResponse ExecuteRequest(HttpRequestConfig request, SearchRequestQuery searchRequestQuery) {
			var content = JsonConvert.SerializeObject(searchRequestQuery);
			IHttpResponse response = HttpClient.SendWithJsonBody(request, content);
			if (response.IsTimedOut) {
				_metricReporter.Report(new ErrorMetric { SearchErrorCode = GlobalSearchErrorCode.Timeout });
			} else if (response.Exception != null) {
				_metricReporter.Report(response.Exception is TaskCanceledException
					? new ErrorMetric { SearchErrorCode = GlobalSearchErrorCode.Aborted }
					: new ErrorMetric { SearchErrorCode = GlobalSearchErrorCode.ElasticError });
			}
			return response;
		}

		private static string GetMisconfiguredServiceResponse(string serviceSetupProblems) {
			BpmSearchResponse searchResponse = new BpmSearchResponse {
				Success = false,
				ErrorInfo = new ErrorInfo {
					Message = serviceSetupProblems,
					ErrorCode = ServiceMisconfiguredErrorCode
				}
			};
			return JsonConvert.SerializeObject(searchResponse);
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Run global search.
		/// </summary>
		/// <param name="queryString">Query string.</param>
		/// <param name="sectionEntityName">Current section entity name.</param>
		/// <param name="recordCount">Count of selected records.</param>
		/// <param name="type">Type filter.</param>
		/// <param name="from">First record index for search.</param>
		/// <returns>Serializable <see cref="BpmSearchResponse"/> instance.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped,
			ResponseFormat = WebMessageFormat.Json)]
		public string Search(string queryString, string sectionEntityName, int recordCount, string type = "", int from = 0) {
			int pageNum = 0;
			int totalFoundRecordCount = -1;
			SearchRequestQuery searchRequestQuery = null;
			BpmSearchResponse bpmSearchResponse = null;
			string serviceSetupProblems =
				GlobalSearchConfigurationHealthChecker.GetCompiledConfigurationProblems(UserConnection);
			if (serviceSetupProblems.IsNotNullOrWhiteSpace()) {
				return GetMisconfiguredServiceResponse(serviceSetupProblems);
			}
            var startedOn = DateTime.Now;
			while (GetIsNotExpired(startedOn, pageNum, bpmSearchResponse?.Data?.Count) && GetNeedLoadNextPage(bpmSearchResponse, searchRequestQuery, totalFoundRecordCount, recordCount)) {
				searchRequestQuery = SearchHelper.GetSearchScoreRequestQuery(queryString, sectionEntityName, recordCount, pageNum, from);
				var request = PrepareRequest(type);
				IHttpResponse response = ExecuteRequest(request, searchRequestQuery);
				if (!response.IsSuccessStatusCode) {
					BaseResponse errorMessage = GetErrorResponse(response);
					return JsonConvert.SerializeObject(errorMessage);
				}
				ESSearchResponse esSearchResponse;
				ErrorInfo errorInfo = null;
				try {
					esSearchResponse = JsonConvert.DeserializeObject<ESSearchResponse>(response.Content);
				} catch (JsonException e) {
					esSearchResponse = new ESSearchResponse {
						SearchResult = null
					};
					errorInfo = new ErrorInfo {
						Message = response.Content,
						ErrorCode = e.Message
					};
				}
				if (esSearchResponse.SearchResult == null) {
					_metricReporter.Report(new ErrorMetric { SearchErrorCode = GlobalSearchErrorCode.ElasticError });
					return JsonConvert.SerializeObject(GetErrorResponse(response, errorInfo ?? new ErrorInfo {
						Message = "Search result is empty",
						ErrorCode = "EmptyResult"
					}));
				}
				_metricReporter.Report(new SearchMetric { Duration = esSearchResponse.Took });
				var processedEsResponse = SearchHelper.ProcessEsSearchResponse(esSearchResponse);
				totalFoundRecordCount = processedEsResponse.Total;
				if (bpmSearchResponse == null) {
					bpmSearchResponse = processedEsResponse;
				} else {
					bpmSearchResponse.Data.AddRange(processedEsResponse.Data);
				}
				if (bpmSearchResponse.Data.Count >= recordCount) {
					bpmSearchResponse.Data = bpmSearchResponse.Data.Take(recordCount).ToList();
					SetResponseNextFrom(bpmSearchResponse, esSearchResponse, searchRequestQuery);
				}
				pageNum++;
			}
			return JsonConvert.SerializeObject(bpmSearchResponse);
		}

		/// <summary>
		/// Get aggregations by query
		/// </summary>
		/// <param name="queryString">Query string.</param>
		/// <param name="sectionEntityName">Current section entity name.</param>
		/// <returns>Serializable list of <see cref="BpmSearchAggregation"/> instance.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped,
			ResponseFormat = WebMessageFormat.Json)]
		[return: MessageParameter(Name = "sections")]
		public string GetGroupedSections(string queryString, string sectionEntityName) {
			AggsSearchRequestQuery aggsSearchRequestQuery =
				SearchHelper.GetAggsSearchScoreRequestQuery(queryString, sectionEntityName);
			var request = PrepareRequest("");
			IHttpResponse response = ExecuteRequest(request, aggsSearchRequestQuery);
			if (!response.IsSuccessStatusCode) {
				return JsonConvert.SerializeObject(GetErrorResponse(response));
			}
			var esAggsSearchResponse = JsonConvert.DeserializeObject<ESAggregationResponse>(response.Content);
			List<BpmSearchAggregation> groups = SearchHelper.ProcessEsAggregationResponse(esAggsSearchResponse);
			return JsonConvert.SerializeObject(groups);
		}

		#endregion

	}

	#endregion

}


