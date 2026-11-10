 namespace Terrasoft.Configuration
{
	using System;
	using System.ServiceModel;
	using System.ServiceModel.Web;
	using System.ServiceModel.Activation;
	using Terrasoft.Web.Common;
	using Terrasoft.Web.Http.Abstractions;
	using Terrasoft.Web.Common.ServiceRouting;

	#region Class: SysUserProfileRefreshService

	[DefaultServiceRoute]
	[ServiceContract]
	[SspServiceRoute]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class SysUserProfileRefreshService : BaseService
	{

		#region Methods: Public

		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare,
			ResponseFormat = WebMessageFormat.Json)]
		public ConfigurationServiceResponse RefreshCurrentUser() {
			try {
				UserConnection.RefreshCurrentUserInfo();
				UserConnection.SetCurrentUserCulture();
				HttpContext.Current.Session["UserConnection"] = UserConnection;
				return new ConfigurationServiceResponse();
			} catch (Exception e) {
				return new ConfigurationServiceResponse(e);
			}
			
		}

		#endregion

	}

	#endregion

}
