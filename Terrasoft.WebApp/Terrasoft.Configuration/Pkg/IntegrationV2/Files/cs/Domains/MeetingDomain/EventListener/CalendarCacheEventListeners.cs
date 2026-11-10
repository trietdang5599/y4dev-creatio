namespace IntegrationV2.Files.cs.Domains.MailboxDomain.EventListener
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Linq;
	using IntegrationV2.Files.cs.Domains.MeetingDomain.Repository;
	using IntegrationV2.Files.cs.Domains.MeetingDomain.Repository.Interfaces;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Entities.Events;
	using Terrasoft.Core.Store;
	using Terrasoft.EmailDomain;

	/// <summary>
	/// Class starts object updating for two entities using <see cref="BaseEntityEventListener"/> implementation.
	/// </summary>
	[EntityEventListener(SchemaName = "MailboxSyncSettings")]
	[EntityEventListener(SchemaName = "ActivitySyncSettings")]
	class CalendarCacheEventListeners : BaseEntityEventListener
	{

		#region Methods: Private

		private ICalendarRepository GetCalendarRepository(UserConnection userConnection) {
			return new CalendarRepository(userConnection, string.Empty);
		}

		private List<Guid> GetActivitySyncSettingsIdsByMailboxSyncSettingsIds(IEnumerable<Guid> mailboxSyncSettingsIds,
				UserConnection userConnection) {
			var mailboxIds = mailboxSyncSettingsIds?
				.Where(id => id.IsNotEmpty())
				.Distinct()
				.ToList() ?? new List<Guid>();
			if (!mailboxIds.Any()) {
				return new List<Guid>();
			}
			var calendarSettingsIds = new List<Guid>();
			var select = (Select)new Select(userConnection)
				.Column("Id")
				.From("ActivitySyncSettings")
				.Where("MailboxSyncSettingsId").In(Column.Parameters(mailboxIds));
			using (DBExecutor dbExecutor = userConnection.EnsureDBConnection()) {
				using (IDataReader dataReader = select.ExecuteReader(dbExecutor)) {
					while (dataReader.Read()) {
						calendarSettingsIds.Add(dataReader.GetColumnValue<Guid>("Id"));
					}
				}
			}
			return calendarSettingsIds;
		}

		private List<Guid> GetAffectedActivitySyncSettingsIds(Entity entity) {
			switch (entity.SchemaName) {
				case "ActivitySyncSettings":
					return entity.PrimaryColumnValue.IsNotEmpty()
						? new List<Guid> { entity.PrimaryColumnValue }
						: new List<Guid>();
				case "MailboxSyncSettings":
					return GetActivitySyncSettingsIdsByMailboxSyncSettingsIds(
						new[] { entity.PrimaryColumnValue }, entity.UserConnection);
				default:
					return new List<Guid>();
			}
		}

		private void ProcessEntity(object sender, EntityAfterEventArgs e) {
			var entity = (Entity)sender;
			UserConnection userConnection = entity.UserConnection;
			var calendarRepository = GetCalendarRepository(userConnection);
			var affectedIds = GetAffectedActivitySyncSettingsIds(entity);
			calendarRepository.DeleteGraphMeetingsDeltaLinkStates(affectedIds);
			ICacheStore applicationCache = userConnection.ApplicationCache;
			applicationCache.Remove(IntegrationConsts.Calendar.CacheItemName);
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Handles entity Inserted event.
		/// </summary>
		/// <param name="sender">Event sender.</param>
		/// <param name="e"><see cref="EntityAfterEventArgs"/> instance containing event data.
		/// </param>
		public override void OnInserted(object sender, EntityAfterEventArgs e) {
			base.OnInserted(sender, e);
			ProcessEntity(sender, e);
		}

		/// <summary>
		/// Handles entity Deleted event.
		/// </summary>
		/// <param name="sender">Event sender.</param>
		/// <param name="e"><see cref="EntityAfterEventArgs"/> instance containing event data.
		/// </param>
		public override void OnDeleted(object sender, EntityAfterEventArgs e) {
			base.OnDeleted(sender, e);
			ProcessEntity(sender, e);
		}

		/// <summary>
		/// Handles entity Updated event.
		/// </summary>
		/// <param name="sender">Event sender.</param>
		/// <param name="e"><see cref="EntityAfterEventArgs"/> instance containing  event data.
		/// </param>
		public override void OnUpdated(object sender, EntityAfterEventArgs e) {
			base.OnUpdated(sender, e);
			ProcessEntity(sender, e);
		}

		#endregion

	}
}
