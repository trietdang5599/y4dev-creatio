namespace Terrasoft.Configuration
{
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using System.Web.SessionState;
	using Terrasoft.Web.Common.ServiceRouting;
	using Web.Common;

	#region Class: ContactInfoService

	/// <summary>
	/// ContactInfoService class provides an additional info for the Contact entity.
	/// </summary>
	[DefaultServiceRoute]
	[ServiceContract]
	[SspServiceRoute]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class ContactInfoService : BaseService, IReadOnlySessionState
	{

		#region Methods: Public

		/// <summary>
		/// Returns full name template like "F M L", where F - first name, M - middle name, L - last name.
		/// </summary>
		[OperationContract]
		[WebInvoke(Method = "GET", UriTemplate = "GetFullNameTemplate",
			BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json,
			ResponseFormat = WebMessageFormat.Json)]
		public string GetFullNameTemplate() {
			IContactFieldConverter converter = ContactUtilities.GetContactConverter(UserConnection);
			var fullNameParts = new ContactSgm {
				GivenName = "F",
				MiddleName = "M",
				Surname = "L"
			};
			return converter?.GetContactName(fullNameParts);
		}

		#endregion

	}

	#endregion

}
