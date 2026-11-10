using System;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Web.SessionState;
using Terrasoft.Core.ServiceModelContract;
using Terrasoft.Web.Common;

namespace Terrasoft.Configuration
{

	#region Class: LinkPreviewServiceResponse

	/// <summary>
	/// Class of link preview service response.
	/// </summary>
	[DataContract]
	[Obsolete("8.2.3 | Link preview is no longer supported.")]
	public class LinkPreviewServiceResponse : ConfigurationServiceResponse
	{
		#region Properties: Public

		[DataMember(Name = "linkPreviewInfo")]
		public LinkPreviewInfo LinkPreviewInfo { get; set; }

		#endregion
	}

	#endregion

	#region Class: LinkPreviewService

	/// <summary>
	/// Class of link preview service.
	/// </summary>
	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	[Obsolete("8.2.3 | Link preview is no longer supported.")]
	public class LinkPreviewService : BaseService, IReadOnlySessionState
	{
		#region Methods: Public

		/// <summary>
		/// Gets web page link preview info.
		/// </summary>
		/// <param name="url">Url.</param>
		/// <returns>Web page link preview info.</returns>
		[OperationContract]
		[return: MessageParameter(Name = "result")]
		[WebInvoke(Method = "POST", UriTemplate = "GetWebPageLinkPreview", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		[Obsolete("8.2.3 | Link preview is no longer supported.")]
		public LinkPreviewServiceResponse GetWebPageLinkPreview(string url) {
			return new LinkPreviewServiceResponse {
				Success = false,
				ErrorInfo = new ErrorInfo {
					Message = "Link preview is no longer supported starting from version 8.2.3.",
					ErrorCode = HttpStatusCode.BadRequest.ToString()
				}
			};
		}

		#endregion
	}

	#endregion
}
