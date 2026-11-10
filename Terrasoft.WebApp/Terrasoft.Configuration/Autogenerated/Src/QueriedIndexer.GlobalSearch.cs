namespace Terrasoft.Configuration.GlobalSearch
{
	using Terrasoft.Core.Entities;
	using Terrasoft.Configuration.GlobalSearchColumnUtils;
	using Terrasoft.GlobalSearch.Indexing;

	#region Class: QueriedIndexer

	public class QueriedIndexer : BaseIndexer
	{

		#region Constructors: Public

		public QueriedIndexer(IndexingRequestDataBuilder indexingRequestDataBuilder,
			IndexingEntitySender indexingEntitySender)
			: base(indexingRequestDataBuilder, indexingEntitySender) { }

		#endregion

		#region Methods: Protected

		protected override void SendIndexingEntity(Entity entity, IndexingOperationType indexingOperationType) {
			var indexingData = IndexingRequestDataBuilder.BuildQueriedRequestData(entity.UserConnection,
				indexingOperationType, entity, GlobalSearchColumnUtils.Instance.RelationColumnsFieldPattern);
			IndexingEntitySender.SendIndexingEntity(indexingData);
		}

		#endregion

	}

	#endregion

}
