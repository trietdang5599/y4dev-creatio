namespace Terrasoft.Configuration.Tagging
{
	using System.Runtime.Serialization;
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using Terrasoft.Configuration.RelatedRecords;
	using Terrasoft.Core;
	using Terrasoft.Core.Factories;

	#region Class: TaggingServiceRequest

	/// <summary>
	/// Class of request of tagging service.
	/// </summary>
	[DataContract]
	public class TaggingServiceRequest : IRelatedRecordsServiceRequest
	{

		/// <summary>
		/// Serialized entity schema query of tags.
		/// </summary>
		[DataMember(Name = "tagsEsqSerialized", IsRequired = true)]
		public string MainRecordsEsqSerialized { get; set; }

		/// <summary>
		/// Serialized entity schema query of records.
		/// </summary>
		[DataMember(Name = "recordsEsqSerialized", IsRequired = true)]
		public string RelatedRecordsEsqSerialized { get; set; }

		/// <summary>
		/// Schema name of tag in record.
		/// </summary>
		[DataMember(Name = "tagInRecordSchemaName", IsRequired = false)]
		public string RelatedInMainRecordsSchemaName { get; set; }

		/// <summary>
		/// Tag column name.
		/// </summary>
		[DataMember(Name = "tagColumnName", IsRequired = false)]
		public string MainRecordColumnName { get; set; }

		/// <summary>
		/// Record colummn name.
		/// </summary>
		[DataMember(Name = "recordColumnName", IsRequired = false)]
		public string RelatedRecordColumnName { get; set; }

		/// <inheritdoc />
		[DataMember(Name = "defaultValues", IsRequired = false)]
		public string DefaultValues { get; set; }
	}

	#endregion

	#region Class: TaggingService

	/// <summary>
	/// Provides web-service for work with tags.
	/// </summary>
	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class TaggingService : BaseRelatedRecordsService
	{

		#region Constructors: Public

		public TaggingService() { }

		public TaggingService(UserConnection userConnection)
			: base(userConnection) { }

		#endregion

		#region Methods: Protected

		/// <inheritdoc />
		protected override IRelatedRecordsHandler GetRelatedRecordsHandler() {
			return ClassFactory.Get<ITaggingHandler>(new ConstructorArgument("userConnection", UserConnection));
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Adds tags to records.
		/// </summary>
		/// <param name="request">Tagging service request.</param>
		/// <returns>Tagging service response.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "AddTags", BodyStyle = WebMessageBodyStyle.WrappedRequest,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public RelatedRecordsServiceResponse AddTags(TaggingServiceRequest request) {
			return AddRelatedRecords(request);
		}

		/// <summary>
		/// Removes tags from records.
		/// </summary>
		/// <param name="request">Tagging service request.</param>
		/// <returns>Tagging service response.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "RemoveTags", BodyStyle = WebMessageBodyStyle.WrappedRequest,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public RelatedRecordsServiceResponse RemoveTags(TaggingServiceRequest request) {
			return RemoveRelatedRecords(request);
		}

		#endregion

	}

	#endregion

}

