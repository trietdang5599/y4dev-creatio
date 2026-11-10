namespace Terrasoft.Configuration.StaticFolder
{
	using System.Runtime.Serialization;
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using Terrasoft.Configuration.RelatedRecords;
	using Terrasoft.Core;
	using Terrasoft.Core.Factories;

	#region Class: StaticFolderServiceRequest

	/// <summary>
	/// Class of request of static folder service.
	/// </summary>
	[DataContract]
	public class StaticFolderServiceRequest : IRelatedRecordsServiceRequest
	{

		/// <summary>
		/// Serialized entity schema query of folders.
		/// </summary>
		[DataMember(Name = "foldersEsqSerialized", IsRequired = true)]
		public string MainRecordsEsqSerialized { get; set; }

		/// <summary>
		/// Serialized entity schema query of records.
		/// </summary>
		[DataMember(Name = "recordsEsqSerialized", IsRequired = true)]
		public string RelatedRecordsEsqSerialized { get; set; }

		/// <summary>
		/// Schema name of record in folder records.
		/// </summary>
		[DataMember(Name = "recordInFolderRecordsSchemaName", IsRequired = true)]
		public string RelatedInMainRecordsSchemaName { get; set; }

		/// <summary>
		/// Folder colummn name.
		/// </summary>
		[DataMember(Name = "folderColumnName", IsRequired = true)]
		public string MainRecordColumnName { get; set; }

		/// <summary>
		/// Record column name.
		/// </summary>
		[DataMember(Name = "recordColumnName", IsRequired = true)]
		public string RelatedRecordColumnName { get; set; }

		/// <inheritdoc />
		[DataMember(Name = "defaultValues", IsRequired = false)]
		public string DefaultValues { get; set; }
	}

	#endregion

	#region Class: StaticFolderService

	/// <summary>
	/// Provides web-service for work with records in static folders.
	/// </summary>
	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class StaticFolderService : BaseRelatedRecordsService
	{

		#region Constructors: Public

		public StaticFolderService() { }

		public StaticFolderService(UserConnection userConnection)
			: base(userConnection) { }

		#endregion

		#region Methods: Protected

		/// <inheritdoc />
		protected override IRelatedRecordsHandler GetRelatedRecordsHandler() {
			return ClassFactory.Get<IStaticFolderHandler>(new ConstructorArgument("userConnection", UserConnection));
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Adds records to static folders.
		/// </summary>
		/// <param name="request">Static folder request.</param>
		/// <returns>Static folder service responce.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "AddRecords", BodyStyle = WebMessageBodyStyle.WrappedRequest,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public RelatedRecordsServiceResponse AddRecords(StaticFolderServiceRequest request) {
			return AddRelatedRecords(request);
		}

		/// <summary>
		/// Removes records from static folders.
		/// </summary>
		/// <param name="request">Static folder request.</param>
		/// <returns>Static folder service responce.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "RemoveRecords", BodyStyle = WebMessageBodyStyle.WrappedRequest,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public RelatedRecordsServiceResponse RemoveRecords(StaticFolderServiceRequest request) {
			return RemoveRelatedRecords(request);
		}

		#endregion

	}

	#endregion

}

