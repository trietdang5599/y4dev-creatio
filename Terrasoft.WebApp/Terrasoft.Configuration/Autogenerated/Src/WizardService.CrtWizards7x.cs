namespace Terrasoft.Configuration
{
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using Terrasoft.Web.Common;
	using Terrasoft.Core.Store;

	#region Class: WizardService

	/// <summary>
	/// Utility service class for working with Wizard.
	/// </summary>
	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class WizardService : BaseService
	{
		#region Constants: Private

		private const string EnvironmentInitializerCacheKeyTemplate = "EnvironmentInitializationScript_{0}_{1}";

		#endregion
		
		#region Methods: Public

		/// <summary>
		/// Clear configuration script from cash.
		/// </summary>
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public void ClearConfigurationScript() {

			// TODO: RND-32352
			string cacheKey = string.Format(EnvironmentInitializerCacheKeyTemplate, UserConnection.CurrentUser.Culture.Name,
				UserConnection.SessionId);
			ICacheStore environmentInitializationHandlerCacheStore =
				UserConnection.SessionCache.WithLocalCaching("EnvironmentInitializationHandler");
			environmentInitializationHandlerCacheStore.Remove(cacheKey);
			ConfigurationSectionHelper.ClearCache(UserConnection);
		}

		#endregion
	}

	#endregion

}

