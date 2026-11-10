namespace Terrasoft.Configuration
{
	using System;
	using System.Threading;
	using System.Threading.Tasks;
	using global::Common.Logging;
	using Newtonsoft.Json;
	using Terrasoft.Common;
	using Terrasoft.Configuration.GlobalSearch;
	using Terrasoft.Core;
	using Terrasoft.Core.Factories;
	using Terrasoft.Core.Requests;
	using Terrasoft.GlobalSearch.Interfaces;
	using Terrasoft.OAuthIntegration;
	using CoreSysSetting = Core.Configuration.SysSettings;

	#region Class: IMentionRepository

	[DefaultBinding(typeof(IMentionRepository))]
	public class MentionRepository: IMentionRepository
	{

		#region Fields: Private

		private readonly string _serverUrl;
		private readonly IHttpRequestClient _httpClient;
		private readonly UserConnection _userConnection;
		private readonly ILog _log = LogManager.GetLogger("MentionRepository");

		#endregion

		#region Properties: Private

		private IIdentityServiceWrapper _identityServiceWrapper;
		private IIdentityServiceWrapper IdentityServiceWrapper =>
			_identityServiceWrapper ?? (_identityServiceWrapper = IdentityServiceWrapperHelper.GetInstance());

		#endregion

		#region Constructors: Public

		public MentionRepository(UserConnection userConnection) {
			_userConnection =  userConnection;
			_httpClient = HttpRequestClientFactory.GetInstanceFromDI();
			_serverUrl = CoreSysSetting.GetValue(userConnection, "GlobalSearchUrl", string.Empty);
			if (_serverUrl.IsNullOrEmpty()) {
				throw new ArgumentNullException("GlobalSearchUrl", "Can't find global search url for custom http request.");
			}
		}


		#endregion

		#region Methods: Private

		private Uri GetSimilarSearchUrl() {
			var uri = new Uri(_serverUrl);
			var address = uri.GetLeftPart(UriPartial.Authority);
			var index = uri.AbsolutePath;
			return new Uri($"{address}/v1/similar-search{index}");
		}

		#endregion

		#region Methods: Public

		/// <inheritdoc cref="IMentionRepository.GetAsync{T}(SearchRequest, CancellationToken)"/>
		public async Task<SearchResponse<T>> GetAsync<T>(SearchRequest query) where T : class {
			try {
				var scope = GlobalSearchOAuthScopes.GetScopeForCurrentUser(_userConnection);
				var stringDto = JsonConvert.SerializeObject(query);
				var config = new HttpRequestConfig() {
					Method = HttpRequestMethod.POST,
					Url = GetSimilarSearchUrl()
				}.WithOAuth<GlobalSearchFeatures.UseOAuth>(IdentityServiceWrapper, scope);
				var response = await _httpClient.SendWithJsonBodyAsync(config, stringDto);
				if (!response.IsSuccessStatusCode) {
					var errorMsg = $"Search request error. StatusCode: {response.StatusCode}. ReasonPhrase: {response.ReasonPhrase}. Content: {response.Content}";
					throw new Exception(errorMsg);
				}
				return JsonConvert.DeserializeObject<SearchResponse<T>>(response.Content);
			} catch (Exception e) {
				_log.Error("Error occured when contact mention.", e);
				throw;
			}
		}

		#endregion

	}

	#endregion

}
