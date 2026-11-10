namespace Terrasoft.Configuration
{
	using System;
	using System.Linq;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Entities.Events;
	using Terrasoft.Core.Factories;

	#region Class: ActivityEmailParticipantEventListener

	/// <summary>
	/// Handles email participant creation for Activity entity.
	/// Moved from <see cref="Activity_CrtCoreBaseEventsProcess{TEntity}.OnActivitySaved"/> to gain access
	/// to changed column values, which are not available in the entity events process after save.
	/// </summary>
	[EntityEventListener(SchemaName = "Activity")]
	public class ActivityEmailParticipantEventListener : BaseEntityEventListener
	{

		#region Fields: Private

		/// <summary>
		/// Activity columns whose changes require email participant synchronization.
		/// </summary>
		private static readonly string[] _participantRelevantColumns = {
			"Sender", "Recepient", "CopyRecepient", "BlindCopyRecepient", "ContactId"
		};

		#endregion

		#region Methods: Private

		private static bool IsEmailActivity(Entity activity) {
			return activity.GetTypedColumnValue<Guid>("TypeId") == ActivityConsts.EmailTypeUId;
		}

		private static bool HasAnyColumnChanged(Entity activity, string[] columns) {
			return activity.GetChangedColumnValues().Any(c => columns.Contains(c.Name));
		}

		private static void SyncEmailParticipants(Entity activity, UserConnection userConnection, bool isNew) {
			var helper = ClassFactory.Get<EmailParticipantHelper>(
				new ConstructorArgument("userConnection", userConnection));
			helper.IsNew = isNew;
			helper.InitializeParameters(activity);
			helper.SetEmailParticipants();
		}

		#endregion

		#region Methods: Public

		/// <inheritdoc/>
		public override void OnInserted(object sender, EntityAfterEventArgs e) {
			var activity = (Entity)sender;
			if (IsEmailActivity(activity)) {
				SyncEmailParticipants(activity, activity.UserConnection, isNew: true);
			}
			base.OnInserted(sender, e);
		}

		/// <inheritdoc/>
		public override void OnUpdated(object sender, EntityAfterEventArgs e) {
			var activity = (Entity)sender;
			if (IsEmailActivity(activity) && HasAnyColumnChanged(activity, _participantRelevantColumns)) {
				SyncEmailParticipants(activity, activity.UserConnection, isNew: false);
			}
			base.OnUpdated(sender, e);
		}

		#endregion

	}

	#endregion

}

