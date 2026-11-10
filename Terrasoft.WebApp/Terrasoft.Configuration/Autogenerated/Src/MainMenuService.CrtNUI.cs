namespace Terrasoft.Configuration
{
	using System.Linq;
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using Terrasoft.Common;
	using Terrasoft.ComponentSpace.Interfaces;
	using Terrasoft.Core;
	using Terrasoft.Core.Factories;
	using Terrasoft.Services;
	using Terrasoft.Web.Common;
	using Terrasoft.Web.Common.SSO.OpenId;
	using Terrasoft.Web.Http.Abstractions;
	using global::Common.Logging;
	using System;

	#region Class: MainMenuService

	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class MainMenuService : BaseService
	{

		#region Properties: Private

		private HttpContext Context { get; set; } = HttpContext.Current;
		private static readonly ILog _authLog = LogManager.GetLogger("Authentication");

		#endregion

		#region Methods: Public

		private void FireLogoutEvents() {
			var logoutEventHandlers = ClassFactory.GetAll<ILogoutEventHandler>();
			foreach (var logoutHandler in logoutEventHandlers) {
				logoutHandler.HandleEvent(UserConnection);
			}
		}

		private void PerformLogout() {
			FireLogoutEvents();
			var userSessionManager = ClassFactory.Get<IUserSessionManager>();
			userSessionManager.Logout();
		}

		/// <summary>
		/// Add a header 'X-Requested-With' to simulate an AJAX request. 
		/// Necessary for correct SLO case for 8x configuration (shell).
		/// </summary>
		private void AddAjaxHeaders() {
			var request = HttpContextAccessor.GetInstance().Request;
			var header = "X-Requested-With";
			if (!request.Headers.AllKeys.Contains(header)) {
				request.Headers[header] = "XMLHttpRequest";
			}
		}

		#endregion

		#region Methods: Public

		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "Logout", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		[return: MessageParameter(Name = "RedirectLocation")]
		public string Logout() {
			_authLog.Info("[SSO] Logout started.");
			var samlProviderApi = ClassFactory.Get<ISamlServiceProviderApi>();
			IOpenIdAuthorizeInitiator openIdAuthorizeInitiator = ClassFactory.Get<IOpenIdAuthorizeInitiator>();
			var result = string.Empty;
			try {
				if (samlProviderApi.GetCanDoSlo()) {
					result = samlProviderApi.InitiateSlo();
				}
				else if (openIdAuthorizeInitiator.IsAuthenticatedUsingOpenId(UserConnection)) {
					result = openIdAuthorizeInitiator.GetOpenIdEndSessionUrl(UserConnection);
					PerformLogout();
				}
			}
			catch (Exception ex) {
				_authLog.Error("[SSO] Initiate SLO failed.", ex);
			}
			if (result.IsNullOrEmpty()) {
				PerformLogout();
				var request = HttpContextAccessor.GetInstance().Request;
				var appPath = request.ApplicationPath ?? string.Empty;
				var match = System.Text.RegularExpressions.Regex.Match(appPath, @"(?<AppPath>.+)/[^/]+/?$");
				if (match.Success) {
					var loaderPath = match.Groups["AppPath"].Value.TrimEnd('/');
					if (!loaderPath.IsNullOrEmpty()) {
						result = request.Url.GetLeftPart(System.UriPartial.Authority)
							+ loaderPath + "/Login/NuiLogin.aspx";
					}
				}
			}
			_authLog.Info("[SSO] Logout ended.");
			AddAjaxHeaders();
			return result;
		}

		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "LogoutOpenId", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		[return: MessageParameter(Name = "RedirectLocation")]
		public string LogoutOpenId(string redirectUrl) {
			IOpenIdAuthorizeInitiator openIdAuthorizeInitiator = ClassFactory.Get<IOpenIdAuthorizeInitiator>();
			var result = string.Empty;
			if (openIdAuthorizeInitiator.IsAuthenticatedUsingOpenId(UserConnection)) {
				result = openIdAuthorizeInitiator.GetOpenIdEndSessionUrl(UserConnection, redirectUrl);
			}
			PerformLogout();
			return result;
		}

		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "GetCanAccessConfigurationSettings", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public bool GetCanAccessConfigurationSettings() {
			var operations = new string[] {
				"CanManageAdministration",
				"CanManageProcessDesign",
				"CanManageChangeLog",
				"CanManageSolution",
				"CanManageLookups",
				"CanViewConfiguration"
			};
			var result = false;
			foreach (var operation in operations) {
				result = result || UserConnection.DBSecurityEngine.GetCanExecuteOperation(operation);
				if (result) {
					break;
				}
			}
			return result;
		}

		#endregion

	}

	#endregion

}
