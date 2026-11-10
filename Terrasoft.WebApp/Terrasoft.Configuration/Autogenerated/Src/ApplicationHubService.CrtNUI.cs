namespace Terrasoft.Configuration
{
	using System;
	using System.Runtime.Serialization;
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using System.Web.SessionState;
	using global::Common.Logging;
	using Terrasoft.Core.Factories;
	using Terrasoft.Web.Common;

	#region Class: ApplicationHubService

	/// <summary>
	/// Service class for handling application hub related operations.
	/// </summary>
	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class ApplicationHubService : BaseService, IReadOnlySessionState
	{

		#region Fields: Private

		private readonly IExternalApplicationHubProvider _externalApplicationHubProvider;

		#endregion

		#region Properties: Private

		private ILog _logger;
		private ILog Logger => _logger ?? (_logger = LogManager.GetLogger("ApplicationHubService"));

		#endregion

		#region Constructors: Public

		public ApplicationHubService() {
			_externalApplicationHubProvider = ClassFactory.Get<IExternalApplicationHubProvider>();
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Gets the external application hub information.
		/// </summary>
		/// <returns>An instance of <see cref="ExternalApplicationHubInfoResponse"/>
		/// containing the URL of the external application hub.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "GetExternalInfo", ResponseFormat = WebMessageFormat.Json,
			BodyStyle = WebMessageBodyStyle.Bare)]
		public ExternalApplicationHubInfoResponse GetExternalInfo() {
			var response = new ExternalApplicationHubInfoResponse();
			try {
				response.Url = _externalApplicationHubProvider.GetUrl();
			} catch (Exception e) {
				response.Exception = e;
				Logger.Error(e);
			}
			return response;
		}

		#endregion
	}

	#endregion

	#region Class: ApplicationHubService

	/// <summary>
	/// Response class for external application hub information.
	/// </summary>
	[DataContract]
	public class ExternalApplicationHubInfoResponse : ConfigurationServiceResponse {

		#region Properties: Public

		/// <summary>
		/// Gets or sets the URL of the external application hub.
		/// </summary>
		[DataMember(Name = "url")]
		public string Url { get; set; } = string.Empty;

		#endregion

	}

	#endregion

}
