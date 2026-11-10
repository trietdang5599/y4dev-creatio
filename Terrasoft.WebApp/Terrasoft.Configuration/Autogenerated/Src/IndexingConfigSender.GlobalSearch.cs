namespace Terrasoft.Configuration.GlobalSearch
{
	using System;
	using System.Collections.Generic;
	using System.Text.RegularExpressions;
	using global::Common.Logging;
	using Newtonsoft.Json;
	using Terrasoft.Core;
	using SysSettingsCore = Terrasoft.Core.Configuration.SysSettings;
	using Terrasoft.Core.Factories;
	using Terrasoft.Core.Requests;
	using Terrasoft.GlobalSearch.Interfaces;
	using Terrasoft.OAuthIntegration;

	#region Class: IndexingConfigSender

	/// <summary>
	/// Sends indexed entities to the indexing service.
	/// </summary>
	public class IndexingConfigSender
	{

		#region Fields: Private

		/// <summary>
		/// Elastic delimiter pattern.
		/// </summary>
		private static readonly Regex _elasticDelimiterPattern = new Regex("(.*)/([^/]+)$");

		/// <summary>
		/// <see cref="UserConnection"/> instance.
		/// </summary>
		private readonly UserConnection _userConnection;

		/// <summary>
		/// Log manager.
		/// </summary>
		private static readonly ILog _log = LogManager.GetLogger("GlobalSearch");

		#endregion

		#region Properties: Private

		private IIdentityServiceWrapper _identityServiceWrapper;
		private IIdentityServiceWrapper IdentityServiceWrapper =>
			_identityServiceWrapper ?? (_identityServiceWrapper = IdentityServiceWrapperHelper.GetInstance());

		#endregion

		#region Properties: Protected

		/// <summary>
		/// ElasticSearch host address.
		/// </summary>
		protected string ElasticHost => _elasticDelimiterPattern.Replace(ElasticUrl, "$1");

		/// <summary>
		/// ElasticSearch index name.
		/// </summary>
		protected string ElasticIndex => _elasticDelimiterPattern.Replace(ElasticUrl, "$2");

		/// <summary>
		/// ElasticSearch full url address.
		/// </summary>
		protected string _elasticUrl;
		protected virtual string ElasticUrl => _elasticUrl ??
			SysSettingsCore.GetValue(_userConnection, "GlobalSearchUrl", string.Empty);

		/// <summary>
		/// Global search config service url address.
		/// </summary>
		protected string _globalSearchServiceUrl;
		protected virtual string GlobalSearchServiceUrl => _globalSearchServiceUrl ?? (_globalSearchServiceUrl =
			SysSettingsCore.GetValue(_userConnection, "GlobalSearchConfigServiceUrl", string.Empty));

		/// <summary>
		/// Indexing entity list manager.
		/// </summary>
		protected IndexingEntityListManager _indexingEntityListManager;
		protected virtual IndexingEntityListManager IndexingEntityListManager => 
			_indexingEntityListManager ?? (_indexingEntityListManager =
				ClassFactory.Get<IndexingEntityListManager>(
					new ConstructorArgument("userConnection", _userConnection)));

		/// <summary>
		/// Implemented instance of <see cref="IHttpRequestClient"/>.
		/// </summary>
		private IHttpRequestClient _httpClient;
		public virtual IHttpRequestClient HttpClient {
			get {
				if (_httpClient != null) {
					return _httpClient;
				}
				if (!HttpRequestClientFactory.TryGetNamedInstance("GlobalSearchServiceHttpClient", out _httpClient)) {
					_httpClient = HttpRequestClientFactory.GetInstanceFromDI();
				}
				return _httpClient;
			}
		}

		#endregion
		
		#region Constructors: Public

		/// <summary>Initializes a new instance of the <see cref="UserConnection" /> class.</summary>
		public IndexingConfigSender(UserConnection userConnection) {
			_userConnection = userConnection;
		}

		#endregion

		#region Methods: Private

		private static void SaveConfigsCallback(IHttpResponse response) {
			if (!response.IsSuccessStatusCode) {
				_log.Error(response.Exception?.GetAllMessages() ?? response.Content);
			} else {
				_log.Info("Sending indexings configs finished with " +
					$"StatusCode: {response.StatusCode}, Content: {response.Content}");
			}
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Sends indexation configs to indexing service.
		/// </summary>
		public void Send() {
			if (string.IsNullOrEmpty(GlobalSearchServiceUrl) && string.IsNullOrEmpty(ElasticUrl)) {
				_log.Info("GlobalSearch connection settings are empty.");
				return;
			}
			List<IndexingEntityConfig> indexingEntityList = IndexingEntityListManager.GetIndexingEntities();
			string url = new Uri($"{GlobalSearchServiceUrl.TrimEnd('/')}/saveConfigs").ToString();
			string scope = GlobalSearchOAuthScopes.GetScopeForCurrentUser(_userConnection);
			var request = new HttpRequestConfig {
					Method = HttpRequestMethod.POST,
					Url = new Uri(url)
				}.WithOAuth<GlobalSearchFeatures.UseOAuth>(IdentityServiceWrapper, scope);
			request.FormParams = new Dictionary<string, string> {
				{ "IndexationConfigs", JsonConvert.SerializeObject(indexingEntityList) },
				{ "IndexName", ElasticIndex }
			};
			_log.Info("Sending indexation configs started.");
			try {
				var response = HttpClient.SendWithFormEncodedContent(request);
				SaveConfigsCallback(response);
			} catch (Exception e) {
				_log.Error(e);
			}
		}

		#endregion
	}
	
	#endregion
}

