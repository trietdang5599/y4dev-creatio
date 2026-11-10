namespace Terrasoft.Configuration
{
	using System.Threading;
	using System.Threading.Tasks;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Applications.Abstractions.Marketplace;
	using Terrasoft.Core.Factories;
	using Terrasoft.Services;
	using CoreServiceSchema = Terrasoft.Services.ServiceSchema;
	using CoreSysSettings = Core.Configuration.SysSettings;

	[DefaultBinding(typeof(IAppMarketplaceApiClient))]
	public class CreatioMarketplaceApiClient : IAppMarketplaceApiClient
	{

		#region Constants: Private

		private const string CreatioMarketplaceApiServiceSchemaName = "CreatioMarketplaceApi";

		#endregion

		#region Fields: Private

		private readonly UserConnection _userConnection;

		#endregion

		#region Constructor: Public

		public CreatioMarketplaceApiClient(UserConnection userConnection) {
			_userConnection = userConnection;
		}

		#endregion

		#region Methods: Private

		private static void ThrowIfInvalidSearchRequest(MarketplaceAppSearchRequest searchRequest) {
			if (searchRequest.AppCode.IsNullOrEmpty() && searchRequest.AppFileName.IsNullOrEmpty()) {
				throw new NullOrEmptyException($"Either app code or file name must be specified");
			}
		}

		private IServiceClient GetWebServiceClient() {
			ServiceSchemaManager serviceSchemaManager = _userConnection.GetServiceSchemaManager();
			CoreServiceSchema serviceSchema =
				serviceSchemaManager.GetInstanceByName(CreatioMarketplaceApiServiceSchemaName);
			return serviceSchema.CreateServiceClient(_userConnection);
		}

		#endregion

		#region Methods: Public

		/// <inheritdoc />
		public async Task<MarketplaceAppIdSearchResult> TryGetMarketplaceAppId(
				MarketplaceAppSearchRequest searchRequest, CancellationToken cancellationToken = default) {
			searchRequest.CheckArgumentNull(nameof(searchRequest));
			ThrowIfInvalidSearchRequest(searchRequest);
			IServiceClient serviceClient = GetWebServiceClient();
			IServiceClientRequest request = serviceClient.CreateRequest("GetAppPublishedVersion");
			if (searchRequest.AppCode != null) {
				request.RequestParameters["AppCode"] = searchRequest.AppCode;
			}
			if (searchRequest.AppFileName != null) {
				request.RequestParameters["FileName"] = searchRequest.AppFileName;
			}
			IServiceClientResponse response = await serviceClient.ExecuteAsync(request, cancellationToken);
			object marketplaceAppIdAsObject = null;
			bool responseSuccess = response.Success;
			bool existsOnMarketplace = responseSuccess &&
				response.ParameterValues.TryGetValue("MarketplaceAppId", out marketplaceAppIdAsObject) &&
				marketplaceAppIdAsObject is string &&
				((string)marketplaceAppIdAsObject).IsNotNullOrEmpty();
			return new MarketplaceAppIdSearchResult {
				Success = responseSuccess,
				ExistsOnMarketplace = existsOnMarketplace,
				MarketplaceAppId = existsOnMarketplace ? (string)marketplaceAppIdAsObject : null
			};
		}

		#endregion

	}
}
