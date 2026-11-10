 namespace Terrasoft.Configuration.ServerInfoService
{
	using System.ServiceModel;
    using System.ServiceModel.Web;
    using System.ServiceModel.Activation;
    using Terrasoft.Core.Factories;
    using Terrasoft.Web.Common;

    #region Class: ServerInfoService

    /// <summary>
    /// Service for getting information about server.
    /// </summary>
    [ServiceContract]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    public class ServerInfoService: BaseService
    {
	
		#region Fields: Private

		private readonly IServerInfoProvider _serverInfoProvider;

		#endregion

		#region Constructors: Public

		public ServerInfoService() {
			_serverInfoProvider = ClassFactory.Get<IServerInfoProvider>();
		}

		#endregion

        #region Methods: Public

        /// <summary>
		/// Get info if application is running on Linux platform.
		/// </summary>
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, 
	        ResponseFormat = WebMessageFormat.Json)]
        public bool IsLinux() {
            return _serverInfoProvider.IsLinux;
        }

        #endregion
        
    }

    #endregion

}
