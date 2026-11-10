 namespace Terrasoft.Configuration.EntityFileDelete
{
	using System.Linq;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Entities.Events;

	#region Class: BaseEntityDeleteTagInRecordListener

	/// <summary>
	/// Listener for 'BaseEntity' entity events.
	/// </summary>
	/// <seealso cref="Terrasoft.Core.Entities.Events.BaseEntityEventListener"/>
	[EntityEventListener(SchemaName = "BaseEntity")]
	public class BaseEntityDeleteTagInRecordListener : BaseEntityEventListener
	{
		#region Constants: Private
		
		private const string TagInRecordSchemaName = "TagInRecord";
		private const string DisableClearTagInRecordAfterRecordDeleteFeatureName = "DisableClearTagInRecordAfterRecordDelete";

		#endregion

		#region Methods: Private

		private bool IsNotNeedClearTagInRecord(Entity entity) {
			var userConnection = entity.UserConnection;
			return entity.SchemaName.Equals(TagInRecordSchemaName)
				|| userConnection.GetIsFeatureEnabled(DisableClearTagInRecordAfterRecordDeleteFeatureName);
		}

		private void DeleteTagInRecord(Entity entity) {
			var tagInRecordsCollection = GetTagInRecordCollection(entity);
			if (!tagInRecordsCollection.Any()) {
				return;
			}
			tagInRecordsCollection.ToList()
				.ForEach(record => record.Delete());
		}

		private EntityCollection GetTagInRecordCollection(Entity entity) {
			var userConnection = entity.UserConnection;
			var esq = new EntitySchemaQuery(userConnection.EntitySchemaManager, TagInRecordSchemaName) {
				UseAdminRights = false
			};
			esq.PrimaryQueryColumn.IsAlwaysSelect = true;
			esq.AddAllSchemaColumns();
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "RecordId", entity.PrimaryColumnValue));
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "RecordSchemaName", entity.SchemaName));
			return esq.GetEntityCollection(userConnection);
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Handles entity Deleting event.
		/// </summary>
		/// <param name="sender">Event sender.</param>
		/// <param name="e">The <see cref="EntityBeforeEventArgs"/> instance containing the event data.</param>
		public override void OnDeleting(object sender, EntityBeforeEventArgs e) {
			var entity = (Entity)sender;
			if (!IsNotNeedClearTagInRecord(entity)) {
				DeleteTagInRecord(entity);
			}
			base.OnDeleting(sender, e);
		}

		#endregion
	}

	#endregion
}

