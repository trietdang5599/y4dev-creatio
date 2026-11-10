namespace Terrasoft.Configuration
{
	using System;
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using Terrasoft.Core;

	/// <summary>
	/// Represents an Office365 OAuth authentication service.
	/// </summary>
	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class Office365OAuthAuthenticator : BaseOffice365OAuthAuthenticator
	{

		#region Constructors: Public

		/// <summary><see cref="OAuthAuthenticator(UserConnection)"/></summary>
		public Office365OAuthAuthenticator(UserConnection userConnection) : base(userConnection) {
		}

		/// <summary><see cref="OAuthAuthenticator()"/></summary>
		public Office365OAuthAuthenticator() : base() {
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Authentications user in the specific OAuth application.
		/// </summary>
		/// <param name="userLogin">User login to the application.</param>
		/// <param name="mailServerId">Mail server unique identifier.</param>
		/// <param name="useAsServiceAccount">Flag that indicates if current flow is used as mailbox or as service account.
		/// For service accouts none of mailbox parts are created, only token storage changes applied.</param>
		[OperationContract]
		[WebInvoke(Method = "GET", UriTemplate = "AuthenticateUser?userLogin={userLogin}&mailServerId={mailServerId}&useAsServiceAccount={useAsServiceAccount}",
			BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public string AuthenticateUser(string userLogin, Guid mailServerId, bool useAsServiceAccount) {
			State.Add("UseAsServiceAccount", useAsServiceAccount);
			return base.AuthenticateUser(userLogin, mailServerId);
		}

		/// <summary>
		/// Processes authentication code from OAuth application.
		/// </summary>
		[OperationContract]
		[WebInvoke(Method = "GET", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public override void ProcessAuthenticationCode() {
			base.ProcessAuthenticationCode();
		}

		#endregion

	}
}

