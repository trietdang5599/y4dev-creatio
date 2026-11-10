namespace Terrasoft.Configuration.Tagging
{
	using Terrasoft.Configuration.RelatedRecords;
	using Terrasoft.Core;
	using Terrasoft.Core.Factories;

	#region Interface: ITaggingHandler

	/// <summary>
	/// Interface of tagging handler.
	/// </summary>
	public interface ITaggingHandler : IRelatedRecordsHandler
	{

		#region Methods: Public

		/// <summary>
		/// Adds tags to records.
		/// </summary>
		/// <param name="handlerData"><see cref="RelatedRecordsHandlerData"/> for adding tags.</param>
		/// <returns><see cref="RelatedRecordsHandlerResult"/> of added tags.</returns>
		RelatedRecordsHandlerResult AddTags(RelatedRecordsHandlerData handlerData);

		/// <summary>
		/// Removes tags from records.
		/// </summary>
		/// <param name="handlerData"><see cref="RelatedRecordsHandlerData"/> of removing tags.</param>
		/// <returns><see cref="RelatedRecordsHandlerResult"/> of removed tags.</returns>
		RelatedRecordsHandlerResult RemoveTags(RelatedRecordsHandlerData handlerData);

		#endregion

	}

	#endregion

	#region Class: TaggingHandler

	/// <summary>
	/// Tagging handler.
	/// </summary>
	[DefaultBinding(typeof(ITaggingHandler), Name = nameof(TaggingHandler))]
	public class TaggingHandler : RelatedRecordsHandler, ITaggingHandler
	{

		#region Constants: Private

		private const string DefaultTagInRecordSourceSchemaName = "TagInRecord";

		#endregion

		#region Constructors: Public

		public TaggingHandler(UserConnection userConnection)
			: base(userConnection) { }

		#endregion

		#region Methods: Private

		private bool HasAdditionalParameters(RelatedRecordsManagerData managerData) {
			return !string.IsNullOrEmpty(managerData.RelatedInMainRecordsSchemaName) &&
				!string.IsNullOrEmpty(managerData.MainRecordColumnName) &&
				!string.IsNullOrEmpty(managerData.RelatedRecordColumnName);
		}

		private IRelatedRecordsProvider GetTaggingProvider() {
			return ClassFactory.Get<IEntityTaggingProvider>(new ConstructorArgument("userConnection", UserConnection));
		}

		#endregion

		#region Methods: Protected

		/// <inheritdoc />
		protected override RelatedRecordsManagerData CreateRelatedRecordsManagerData(
			RelatedRecordsHandlerData handlerData) {
			var managerData = base.CreateRelatedRecordsManagerData(handlerData);
			if (HasAdditionalParameters(managerData)) {
				return managerData;
			}
			managerData.RelatedInMainRecordsSchemaName = DefaultTagInRecordSourceSchemaName;
			managerData.MainRecordColumnName = "Tag";
			managerData.RelatedRecordColumnName = "RecordId";
			return managerData;
		}

		/// <inheritdoc />
		protected override IRelatedRecordsProvider GetAddRelatedRecordsProvider() {
			return GetTaggingProvider();
		}

		/// <inheritdoc />
		protected override IRelatedRecordsProvider GetRemoveRelatedRecordsProvider() {
			return GetTaggingProvider();
		}

		/// <inheritdoc />
		protected override IRelatedRecordsManager GetRelatedRecordsManager(
			IRelatedRecordsProvider relatedRecordsProvider) {
			return ClassFactory.Get<ITaggingManager>(new ConstructorArgument("userConnection", UserConnection),
				new ConstructorArgument("relatedRecordsProvider", relatedRecordsProvider));
		}

		#endregion

		#region Methods: Public

		/// <inheritdoc />
		public RelatedRecordsHandlerResult AddTags(RelatedRecordsHandlerData handlerData) {
			return AddRelatedRecords(handlerData);
		}

		/// <inheritdoc />
		public RelatedRecordsHandlerResult RemoveTags(RelatedRecordsHandlerData handlerData) {
			return RemoveRelatedRecords(handlerData);
		}

		#endregion

	}

	#endregion

}

