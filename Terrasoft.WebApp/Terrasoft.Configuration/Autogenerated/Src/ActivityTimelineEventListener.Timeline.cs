namespace Terrasoft.Configuration
{
	using System;
	using System.Linq;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Entities.Events;

	[EntityEventListener(SchemaName = "Activity")]
	public class ActivityTimelineEventListener : BaseEntityEventListener
	{

		#region Methods: Private

		private bool MetadataExists(Entity entity) {
			var resultSelect = new Select(entity.UserConnection)
				.Top(1)
				.Column("Id")
				.From("EmailMetadata")
				.Where("ActivityId").IsEqual(Column.Parameter(entity.PrimaryColumnValue))
				as Select;
			return resultSelect.ExecuteScalar<Guid>() != Guid.Empty;
		}

		#endregion

		#region Methods: Public

		/// <inheritdoc cref="BaseEntityEventListener.OnUpdated(object, EntityAfterEventArgs)"/>
		public override void OnUpdated(object sender, EntityAfterEventArgs e) {
			Entity entity = (Entity)sender;
			var userConnection = entity.UserConnection;
			if (!userConnection.GetIsFeatureEnabled("LargeEmailsInTimeline.DisableEmailPreviewLoader") 
					&& entity.GetTypedColumnValue<Guid>("TypeId") == ActivityConsts.EmailTypeUId
					&& e.ModifiedColumnValues.Any(c => c.Name == "Body")
					&& MetadataExists(entity)) {
				var del = new Delete(entity.UserConnection)
				.From("EmailMetadata")
				.Where("ActivityId").IsEqual(Column.Parameter(entity.PrimaryColumnValue));
				del.Execute();
			}

			#endregion

		}
	}
}
