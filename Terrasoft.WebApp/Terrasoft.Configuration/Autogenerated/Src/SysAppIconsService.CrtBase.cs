 namespace Terrasoft.Configuration
{
	using System;
	using System.ServiceModel;
	using System.Runtime.Serialization;
	using System.ServiceModel.Web;
	using Terrasoft.Nui.ServiceModel.DataContract;
	using System.ServiceModel.Activation;
	using Terrasoft.Web.Common.ServiceRouting;
	using Terrasoft.Web.Common;
	using Terrasoft.Core.Factories;

	#region Class: SysAppIconsServiceResponse

	/// <summary>
	/// Response application icon service.
	/// </summary>
	[DataContract]
	public class SysAppIconsServiceResponse : BaseResponse
	{
		#region Properties: Public 

		/// <summary>
		/// SysAppIconId.
		/// </summary>
		[DataMember(Name = "sysAppIconId")]
		public Guid SysAppIconId {
			get; set;
		}

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="sysAppIconId">SysAppIconId.</param>
		public SysAppIconsServiceResponse(Guid sysAppIconId) : base() {
			SysAppIconId = sysAppIconId;
		}

		#endregion

	}

	#endregion

	#region Class: SysAppIconsService

	/// <summary>
	/// Application icons service.
	/// </summary>
	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	[DefaultServiceRoute]
	public class SysAppIconsService : BaseService 
	{

		#region Properties: Private

		private ISysAppIconsComporator SysAppIconsComporator => ClassFactory.Get<ISysAppIconsComporator>(new ConstructorArgument("userConnection", UserConnection));

		#endregion

		/// <summary>
		/// Returns related application icon id by sys image id.
		/// </summary>
		/// <param name="sysImageId">Sys image id.</param>
		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest,
		  ResponseFormat = WebMessageFormat.Json)]
		public SysAppIconsServiceResponse  GetRelatedIconBySysImage(Guid sysImageId) {
			var sysAppIconId = SysAppIconsComporator.GetRelatedIconBySysImage(sysImageId);
			return new SysAppIconsServiceResponse(sysAppIconId);
		}
	
	}
	
	#endregion
}
