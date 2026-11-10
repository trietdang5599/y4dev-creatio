namespace Terrasoft.Configuration.Tagging
{
	using System;
	using System.Collections.Generic;
	using System.Runtime.Serialization;
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using System.Web.SessionState;
	using Terrasoft.Core;
	using Terrasoft.Core.Factories;
	using Terrasoft.Web.Common;
	using Terrasoft.Web.Common.ServiceRouting;

	#region Class: TagRightsServiceResponse

	/// <summary>
	/// Class of response tag rights service.
	/// </summary>
	[DataContract]
	public class TagRightsServiceResponse : ConfigurationServiceResponse
	{

		#region Constroctors: Public

		public TagRightsServiceResponse() { }

		public TagRightsServiceResponse(Exception e)
			: base(e) { }

		public TagRightsServiceResponse(List<Guid> allowedTagAccessesForTagging) {
			this.AllowedTagAccessesForTagging = allowedTagAccessesForTagging;
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Allowed TagAccesses for tagging ids.
		/// </summary>
		[DataMember(Name = "allowedTagAccessesForTagging")]
		public List<Guid> AllowedTagAccessesForTagging { get; set; }

		#endregion

	}

	#endregion

	#region Class: TagRightsService

	/// <summary>
	/// Provides web-service for work with tags.
	/// </summary>
	[ServiceContract]
	[DefaultServiceRoute]
	[SspServiceRoute]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class TagRightsService : BaseService, IReadOnlySessionState
	{

		#region Fields: Private

		private ITagRightsHelper _tagRightsHelper;

		#endregion

		#region Properties: Private

		private ITagRightsHelper TagRightsHelper =>
			_tagRightsHelper ??
			(_tagRightsHelper =
				ClassFactory.Get<ITagRightsHelper>(new ConstructorArgument("userConnection", UserConnection)));

		#endregion

		#region Constroctors: Public

		public TagRightsService() { }

		public TagRightsService(UserConnection userConnection)
			: base(userConnection) { }

		#endregion

		#region Methods: Public

		/// <summary>
		/// Returns allowed TagAccesses for tagging.
		/// </summary>
		/// <returns>Tag rights service response.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "GetAllowedTagAccessesForTagging",
			BodyStyle = WebMessageBodyStyle.WrappedRequest, ResponseFormat = WebMessageFormat.Json)]
		public TagRightsServiceResponse GetAllowedTagAccessesForTagging() {
			try {
				return new TagRightsServiceResponse(
					TagRightsHelper.GetTaggingTagAccessesForUser(UserConnection.CurrentUser.Id));
			} catch (Exception e) {
				return new TagRightsServiceResponse(e);
			}
		}

		#endregion

	}

	#endregion

}

