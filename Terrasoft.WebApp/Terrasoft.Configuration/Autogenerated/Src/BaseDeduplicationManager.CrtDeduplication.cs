namespace Terrasoft.Configuration.Deduplication
{
	using System.Text.RegularExpressions;
	using global::Common.Logging;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;
	using Terrasoft.Core.Requests;

	#region Class: BaseDeduplicationManager

	public class BaseDeduplicationManager
	{

		#region Fields: Protected

		protected readonly string DeduplicationTaskControllerPath = "api/deduplication/task/";
		protected readonly string DuplicationControllerPath = "api/duplication/duplicate";
		protected readonly string DuplicationGroupControllerPath = "api/duplication/group";
		protected readonly string DuplicatesCountControllerPath = "api/duplicates/groups/count";
		protected readonly string UniqueControllerPath = "api/duplication/unique";
		protected readonly string GetUniqueRecordsControllerPath = "api/duplicates/unique";
		protected static readonly ILog Log = LogManager.GetLogger("Deduplication");
		protected readonly string DeduplicationWebApiUrl;
		private readonly string _globalSearchUrl;
		protected readonly UserConnection UserConnection;

		#endregion

		#region Properties: Protected

		private string _indexName;
		protected string IndexName {
			get {
				if(_indexName != null) {
					return _indexName;
				}
				if(string.IsNullOrEmpty(_globalSearchUrl)) {
					Log.Error("GlobalSearchUrl is empty.");
					_indexName = string.Empty;
					return _indexName;
				}
				_indexName = new Regex("^(.*)/([^/]+)$").Replace(_globalSearchUrl, "$2");
				return _indexName;
			}
		}

		protected string BaseUrl => DeduplicationWebApiUrl.TrimEnd('/');

		private IHttpRequestClient _httpClient;
		protected IHttpRequestClient HttpClient {
			get {
				if(_httpClient != null) {
					return _httpClient;
				}
				var tag = DeduplicationEventListener.BulkDeduplicationHttpClientTag;
				if (!HttpRequestClientFactory.TryGetNamedInstance(tag, out _httpClient)) {
					_httpClient = HttpRequestClientFactory.GetInstanceFromDI();
				}
				return _httpClient;
			}
		}

		#endregion

		#region Contructors: Public

		public BaseDeduplicationManager(UserConnection userConnection) {
			UserConnection = userConnection;
			DeduplicationWebApiUrl = SysSettings.GetValue(UserConnection, "DeduplicationWebApiUrl", string.Empty);
			if (string.IsNullOrEmpty(DeduplicationWebApiUrl)) {
				Log.Error("DeduplicationWebApiUrl is empty.");
			}
			_globalSearchUrl = SysSettings.GetValue(UserConnection, "GlobalSearchUrl", string.Empty);
		}

		#endregion

	}

	#endregion

}
