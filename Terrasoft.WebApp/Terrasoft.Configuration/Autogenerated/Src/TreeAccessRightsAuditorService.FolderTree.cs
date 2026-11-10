namespace Terrasoft.Configuration
{
	using System;
	using System.Runtime.Serialization;
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using Terrasoft.Core;
	using Terrasoft.Core.Factories;
	using Terrasoft.Web.Common;
	using System.Collections.Generic;
	using System.Web.SessionState;
	using Terrasoft.Web.Common.ServiceRouting;
	using Terrasoft.Common;

	#region Class: TreeAccessRightsAuditorService

	/// <summary>
	/// Service for audit access rights in tree.
	/// </summary>
	[ServiceContract]
	[DefaultServiceRoute]
	[SspServiceRoute]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class TreeAccessRightsAuditorService : BaseService, IReadOnlySessionState
	{

		#region Fields: Private

		private ITreeAccessRightsAuditor _treeAccessRightsAuditor;

		#endregion

		#region Constructors: Public

		public TreeAccessRightsAuditorService() : base() { }

		public TreeAccessRightsAuditorService(UserConnection userConnection)
			: base(userConnection)
		{
		}

		#endregion

		#region Properties: Private

		private ITreeAccessRightsAuditor TreeAccessRightsAuditor =>
			_treeAccessRightsAuditor ?? (_treeAccessRightsAuditor = ClassFactory.Get<ITreeAccessRightsAuditor>(
					new ConstructorArgument("userConnection", UserConnection)));

		#endregion

		#region Methods: Private

		private AccessRightsParams GetAccessRightsParams(TreeAccessRightsAuditorServiceRequest request) {
			return new AccessRightsParams {
				RecordIds = request.RecordIds,
				SchemaName = request.SchemaName,
				HierarchicalColumnName = request.HierarchicalColumnName,
				AdminUnitRoleSources = request.AdminUnitRoleSources
			};
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Checks access rights for records in a specified tree.
		/// </summary>
		/// <param name="recordIds">Records Ids.</param>
		/// <param name="schemaName">Schema name.</param>
		/// <param name="hierarchicalColumnName">Hierarchical column name.</param>
		/// <returns>Returns recordId with rights.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest,
			ResponseFormat = WebMessageFormat.Json)]
		public TreeAccessRightsAuditorServiceResponse CheckTreeAccessRights(TreeAccessRightsAuditorServiceRequest request)
		{
			try {
				var accessRightsParameters = GetAccessRightsParams(request);
				var result = TreeAccessRightsAuditor.CheckTreeAccessRights(accessRightsParameters);
				return new TreeAccessRightsAuditorServiceResponse(result);
			}
			catch (Exception e)
			{
				return new TreeAccessRightsAuditorServiceResponse(e);
			}
		}

		#endregion

	}

	#endregion

	#region Class: TreeAccessRightsAuditorServiceRequest

	/// <summary>
	/// Class of request audit access rights in tree.
	/// </summary>
	[DataContract]
	public class TreeAccessRightsAuditorServiceRequest
	{
		#region Methods: Private

		[OnDeserialized]
		private void OnDeserialized(StreamingContext context) {
			if(string.IsNullOrEmpty(HierarchicalColumnName)) {
				HierarchicalColumnName = "Parent";
			}
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Records Ids.
		/// </summary>
		[DataMember(Name = "recordIds")]
		public List<Guid> RecordIds { get; set; }

		/// <summary>
		/// Schema name.
		/// </summary>
		[DataMember(Name = "schemaName")]
		public string SchemaName { get; set; }

		/// <summary>
		/// Hierarchical column name.
		/// </summary>
		[DataMember(Name = "hierarchicalColumnName")]
		public string HierarchicalColumnName { get; set; }

		/// <summary>
		/// Admin unit role sources.
		/// </summary>
		[DataMember(Name = "adminUnitRoleSources")]
		public AdminUnitRoleSources AdminUnitRoleSources { get; set; }

		#endregion

	}

	#endregion

	#region Class: TreeAccessRightsAuditorServiceResponse

	/// <summary>
	/// Class of response audit access rights in tree.
	/// </summary>
	/// <seealso cref="Terrasoft.Configuration.ConfigurationServiceResponse" />
	[DataContract]
	public class TreeAccessRightsAuditorServiceResponse : ConfigurationServiceResponse
	{

		#region Constructors: Public

		public TreeAccessRightsAuditorServiceResponse() : base() { }

		public TreeAccessRightsAuditorServiceResponse(Exception e) : base(e) { }

		public TreeAccessRightsAuditorServiceResponse(List<Guid> recordIds) : base()
		{
			this.RecordIds = recordIds;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Records with rights.
		/// </summary>
		[DataMember(Name = "recordIds")]
		public List<Guid> RecordIds
		{
			get; private set;
		}

		#endregion

	}

	#endregion
}
