namespace Terrasoft.Configuration.Tagging
{
	using Terrasoft.Configuration.RelatedRecords;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Factories;

	#region Interface: IEntityTaggingProvider

	/// <summary>
	/// Interface of entity tagging provider.
	/// </summary>
	public interface IEntityTaggingProvider : IRelatedRecordsProvider
	{ }

	#endregion

	#region Class: EntityTaggingProvider

	/// <summary>
	/// Entity tagging provider.
	/// </summary>
	[DefaultBinding(typeof(IEntityTaggingProvider), Name = nameof(EntityTaggingProvider))]
	public class EntityTaggingProvider : EntityRelatedRecordsProvider, IEntityTaggingProvider
	{
		#region Fields: Private

		private ITagUtils _tagUtils;

		#endregion

		#region Properties: Private

		private ITagUtils TagUtils => _tagUtils ?? (_tagUtils = ClassFactory.Get<ITagUtils>());

		#endregion

		#region Constructors: Public

		public EntityTaggingProvider(UserConnection userConnection)
			: base(userConnection) { }

		#endregion

		#region Methods: Private

		private void SetUseAdminRightsForTagInRecordEntity(Entity tagInRecordEntity,
			BaseRelatedRecordsProviderData providerData) {
			tagInRecordEntity.UseAdminRights = TagUtils.IsOldStructure(providerData.RelatedInMainRecordsSchemaName);
		}

		#endregion

		#region Methods: Protected

		/// <inheritdoc />
		protected override Entity GetRelatedInMainRecordEntityForCreate(EntitySchema relatedInMainRecordSchema,
			Entity mainRecord, Entity relatedRecord, AddRelatedRecordsProviderData providerData) {
			var tagInRecordEntity = base.GetRelatedInMainRecordEntityForCreate(relatedInMainRecordSchema, mainRecord,
				relatedRecord, providerData);
			SetUseAdminRightsForTagInRecordEntity(tagInRecordEntity, providerData);
			return tagInRecordEntity;
		}

		/// <inheritdoc />
		protected override Entity GetRelatedInMainRecordEntityForRemove(Entity relatedInMainRecordEntity,
			RemoveRelatedRecordsProviderData providerData) {
			var tagInRecordEntity = base.GetRelatedInMainRecordEntityForRemove(relatedInMainRecordEntity, providerData);
			SetUseAdminRightsForTagInRecordEntity(tagInRecordEntity, providerData);
			return tagInRecordEntity;
		}

		/// <inheritdoc />
		protected override void SetEntitySchemaQueryDefaultSettings(EntitySchemaQuery esq) {
			base.SetEntitySchemaQueryDefaultSettings(esq);
			esq.ChunkSize = UserConnection.AppConnection.MaxEntityRowCount;
		}

		#endregion

	}

	#endregion

}

