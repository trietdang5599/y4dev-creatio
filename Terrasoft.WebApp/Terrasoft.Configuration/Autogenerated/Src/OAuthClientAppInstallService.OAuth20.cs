namespace Terrasoft.Configuration.OAuth20
{
	using System;
	using System.Runtime.Serialization;
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using global::Common.Logging;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities;
	using Terrasoft.Web.Common;

	#region Class: OAuthClientAppInstallResponse

	/// <summary>
	/// Result of an OAuthClientApp install attempt returned to the Freedom UI Install action.
	/// </summary>
	[DataContract]
	public class OAuthClientAppInstallResponse
	{

		/// <summary>Whether the integration was installed (registered in the Identity Service).</summary>
		[DataMember(Name = "success")]
		public bool Success { get; set; }

		/// <summary>ClientId persisted on the installed integration (for immediate display).</summary>
		[DataMember(Name = "clientId")]
		public string ClientId { get; set; }

		/// <summary>ClientSecret generated during installation (for immediate display).</summary>
		[DataMember(Name = "clientSecret")]
		public string ClientSecret { get; set; }

		/// <summary>Localized error message shown in a snackbar when <see cref="Success" /> is false.</summary>
		[DataMember(Name = "errorMessage")]
		public string ErrorMessage { get; set; }

	}

	#endregion

	#region Class: OAuthClientAppInstallService

	/// <summary>
	/// Thin service behind the Freedom UI "Install" action (ENG-78572). It flips
	/// <c>OAuthClientApp.Status</c> to "Installed" and saves; the <c>OAuthClientAppListener</c>
	/// performs validate -> register -> activate atomically inside the Save. Listener outcomes are
	/// translated into a structured response: success returns the freshly generated credentials,
	/// failure returns the localized error for a snackbar (the Save transaction is rolled back, so the
	/// record stays "Not installed").
	/// </summary>
	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class OAuthClientAppInstallService : BaseService
	{

		#region Constants: Private

		/// <summary>Id of the <c>OAuthClientAppStatus</c> lookup record "Installed".</summary>
		private static readonly Guid InstalledStatusId = new Guid("87f2cf13-71e7-4f69-8dd8-19d3c4d2cd69");

		#endregion

		#region Fields: Private

		private readonly ILog _log = LogManager.GetLogger("OAuth20");

		#endregion

		#region Methods: Public

		/// <summary>
		/// Installs the specified not-installed OAuthClientApp.
		/// </summary>
		/// <param name="recordId">OAuthClientApp identifier.</param>
		/// <returns>Install result with credentials on success or a localized error on failure.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
			BodyStyle = WebMessageBodyStyle.Wrapped)]
		public OAuthClientAppInstallResponse Install(string recordId) {
			var response = new OAuthClientAppInstallResponse();
			try {
				var clientAppId = Guid.Parse(recordId);
				EntitySchema schema = UserConnection.EntitySchemaManager.GetInstanceByName("OAuthClientApp");
				Entity entity = schema.CreateEntity(UserConnection);
				if (!entity.FetchFromDB(clientAppId)) {
					response.Success = false;
					response.ErrorMessage = new LocalizableString(UserConnection.ResourceStorage,
						"OAuthClientAppInstallService", "LocalizableStrings.RecordNotFoundMessage.Value");
					return response;
				}
				entity.SetColumnValue("StatusId", InstalledStatusId);
				// The listener install-transition handler validates, registers in the Identity Service
				// (reusing any pre-generated ClientId), generates the secret and activates the record.
				// Any failure throws and aborts the Save, leaving Status = Not installed.
				entity.Save();
				response.Success = true;
				response.ClientId = entity.GetTypedColumnValue<string>("ClientId");
				response.ClientSecret = entity.GetTypedColumnValue<string>("ClientSecret");
			} catch (Exception ex) {
				_log.Error($"OAuthClientApp install failed for record '{recordId}'.", ex);
				response.Success = false;
				response.ErrorMessage = ex.Message;
			}
			return response;
		}

		#endregion

	}

	#endregion

}

