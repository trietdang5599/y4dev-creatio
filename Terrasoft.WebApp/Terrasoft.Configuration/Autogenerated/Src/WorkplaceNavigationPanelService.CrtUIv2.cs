namespace Terrasoft.Configuration.NavigationMenu
{
	using System;
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using System.Web.SessionState;
	using Creatio.FeatureToggling;
	using global::Common.Logging;
	using Terrasoft.Core.Factories;
	using Terrasoft.Core.ServiceModelContract;
	using Terrasoft.Web.Common;
	using Terrasoft.Web.Common.ServiceRouting;
	using WorkplaceApi;

	[DefaultServiceRoute]
	[SspServiceRoute]
	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class WorkplaceNavigationPanelService : BaseService, IReadOnlySessionState
	{

		#region Fields: Private

		private ILog _log;
		private ILog Log => _log ?? (_log = LogManager.GetLogger(typeof(WorkplaceNavigationPanelService)));
		private readonly IWorkplaceNavigationPanelProvider _navigationPanelProvider;
		private readonly IWorkplaceInfoNavigationPanelProvider _infoNavigationPanelProvider;

		#endregion

		#region Constructor: Public

		public WorkplaceNavigationPanelService() {
			_navigationPanelProvider = ClassFactory.Get<IWorkplaceNavigationPanelProvider>(
				new ConstructorArgument("userConnection", UserConnection));
			_infoNavigationPanelProvider = ClassFactory.Get<IWorkplaceInfoNavigationPanelProvider>(
				new ConstructorArgument("userConnection", UserConnection));
		}

		public WorkplaceNavigationPanelService(IWorkplaceNavigationPanelProvider navigationPanelProvider) {
			_navigationPanelProvider = navigationPanelProvider;
			_infoNavigationPanelProvider = ClassFactory.Get<IWorkplaceInfoNavigationPanelProvider>(
				new ConstructorArgument("userConnection", UserConnection));
		}

		public WorkplaceNavigationPanelService(IWorkplaceNavigationPanelProvider navigationPanelProvider,
				IWorkplaceInfoNavigationPanelProvider infoNavigationPanelProvider) {
			_navigationPanelProvider = navigationPanelProvider;
			_infoNavigationPanelProvider = infoNavigationPanelProvider;
		}


		#endregion

		#region Methods: Private

		private GetNavigationMenuGroupsResponse CreateErrorResponse(Exception e) {
			Log.Error(e.Message);
			return new GetNavigationMenuGroupsResponse {
				Success = false,
				ErrorInfo = new ErrorInfo { Message = e.Message },
				LoadingResult = "InternalError"
			};
		}

		#endregion

		#region Methods: Public

		[OperationContract]
		[WebInvoke(Method = "GET", BodyStyle = WebMessageBodyStyle.WrappedRequest,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public GetNavigationMenuGroupsResponse GetGroups() {
			try {
				var response = new GetNavigationMenuGroupsResponse {
					LoadingResult = WorkplaceLoadingResult.Successful.ToString()
				};
				if (Features.GetIsEnabled("LoadNavigationMenuGroupsWithoutInfo")) {
					response.Workplaces = _navigationPanelProvider.Load();
				} else {
					NavigationMenuGroupsInfo loadInfo = _infoNavigationPanelProvider.LoadInfo();
					response.Workplaces = loadInfo.Groups;
					response.LoadingResult = loadInfo.LoadingResult.ToString();
				}
				return response;
			} catch (Exception e) {
				return CreateErrorResponse(e);
			}
		}

		[OperationContract]
		[WebInvoke(Method = "GET", BodyStyle = WebMessageBodyStyle.WrappedRequest,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public GetNavigationMenuGroupsResponse GetMobileWorkplaces() {
			try {
				NavigationMenuGroupsInfo loadInfo = _infoNavigationPanelProvider.LoadMobileWorkplaces();
				return new GetNavigationMenuGroupsResponse {
					Workplaces = loadInfo.Groups,
					LoadingResult = loadInfo.LoadingResult.ToString()
				};
			} catch (Exception e) {
				return CreateErrorResponse(e);
			}
		}

		#endregion

	}
}

