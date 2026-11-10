namespace Terrasoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Linq;
	using System.Security;
	using Google.Apis.Calendar.v3.Data;
	using Newtonsoft.Json.Linq;
	using Terrasoft.Common;
	using Terrasoft.Common.Json;
	using Terrasoft.Core;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Factories;
	using Terrasoft.GoogleServices;
	using Terrasoft.Sync;
	using SystemSettings = Terrasoft.Core.Configuration.SysSettings;

	#region Class: GCalendarSynchronizer

	public class GCalendarSynchronizer : BaseGoogleSynchronizer
	{

		#region Constants: Private

		private const int IdleTimeoutValue = 5000;

		private const int DefaultThresholdValue = 0;

		private const string MetadataModifiedOnColumnName = "MetaDataModifiedOn";

		private const string ParticipantModifiedOnColumnName = "ParticipantModifiedOn";

		#endregion

		#region Constants: Public

		public const string ResponseStatusDeclined = "declined";

		public const string ResponseStatusAccepted = "accepted";

		public const string ResponseStatusNeedsAction = "needsAction";

		public const string ResponseStatusTentative = "tentative";

		#endregion

		#region Properties: Private

		private Object ModifiedGEntities {
			get;
			set;
		}

		private Object ResolvedConflictUIds {
			get;
			set;
		}

		private Object UpdGRecordsList {
			get;
			set;
		}

		private List<string> DelGRecordsList {
			get;
			set;
		}

		private DateTime Today {
			get {
				return new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day);
			}
		}

		private bool IsFirstSync {
			get {
				return LastSynchronizationDate.Year == 1900;
			}
		}

		#endregion

		#region Properties: Protected

		/// <summary>
		/// Created in bpm'online google events list.
		/// </summary>
		protected List<GoogleActivity> NewGRecordsList {
			get;
			set;
		}

		#endregion

		#region Properties: Public

		public GActivitySyncProvider SyncProvider {
			get;
			set;
		}

		#endregion

		#region Constructors: Public

		public GCalendarSynchronizer(UserConnection userConnection)
			: base(userConnection) {
			NewGRecordsList = new List<GoogleActivity>();
			UpdGRecordsList = new List<GoogleActivity>();
			DelGRecordsList = new List<string>();
			SyncProvider = new GActivitySyncProvider() {
				UserConnection = userConnection,
				MailServerId = MailServerId
			};
			ResolvedConflictUIds = new List<Guid>();
			MessageSender = "GoogleCalendar";
		}

		#endregion

		#region Methods: Private

		private void SetSyncDate() {
			if (SyncProvider.ProcessedEntities.Count != 0) {
				DateTime maxDate = SyncProvider.ProcessedEntities[0].UpdatedUTC;
				foreach (var entity in SyncProvider.ProcessedEntities) {
					if (entity.UpdatedUTC > maxDate) {
						maxDate = entity.UpdatedUTC;
					}
				}
				var date = maxDate.AddSeconds(1);
				SetLastSyncDate("GoogleCalendarLastSynchronization", "GoogleCalendarLastSynchronizationEnd", date, date);
			}
		}

		private void AddToModifyList(Terrasoft.Configuration.Activity activity, string entryId) {
			if (!activity.ShowInScheduler) {
				return;
			}
			var updList = (List<GoogleActivity>)UpdGRecordsList;
			var entry = new GoogleActivity();
			if (!entry.Load(SyncProvider, entryId)) {
				return;
			}
			entry.AuthorEmail = SocialAccountName;
			ActivityToGEvent(activity, ref entry, false);
			updList.Add(entry);
		}

		private void AddToModifyList(Terrasoft.Configuration.Activity activity) {
			if (!activity.ShowInScheduler) {
				return;
			}
			var updList = (List<GoogleActivity>)UpdGRecordsList;
			string entryId = activity.GetTypedColumnValue<string>("ActivityCorrespondence_Activity_SourceActivityId");
			var entry = new GoogleActivity();
			if (!entry.Load(SyncProvider, entryId)) {
				return;
			}
			entry.AuthorEmail = SocialAccountName;
			ActivityToGEvent(activity, ref entry, false);
			updList.Add(entry);
		}

		private void UpdCorrespondenceForTransfferredRecords(IList<GoogleActivity> processedEntities) {
			var newList = NewGRecordsList as List<GoogleActivity>;
			var helper = ClassFactory.Get<EntitySynchronizerHelper>();
			foreach (GoogleActivity gActivity in processedEntities) {
				var activityId = new Guid(gActivity.ExtId);
				helper.UnlockEntity(activityId, UserConnection.CurrentUser.ContactId, "GoogleCalendar", UserConnection);
				if (newList.All(nle => nle.ExtId != gActivity.ExtId)) {
					continue;
				}
				var correspondence = GetActivityCorrespondence(gActivity);
				correspondence.SetDefColumnValues();
				correspondence.SetColumnValue("ActivityId", activityId);
				correspondence.Save();
			}
		}

		private Select GetDeletedGeventActivityCorrespondenceSelect(GoogleActivity gActivity) {
			var sel = new Select(UserConnection)
				.Column("ActivityId")
				.Column("IsDeleted")
				.Column("ActivityCorrespondence", "Id")
				.Column("Activity", "ModifiedOn").As("ActivityModifiedOn")
				.From("ActivityCorrespondence")
				.LeftOuterJoin("Activity").On("Activity", "Id").IsEqual("ActivityCorrespondence", "ActivityId")
				.Where("SourceActivityId").IsEqual(new QueryParameter(gActivity.SourceId));
			if (UserConnection.GetIsFeatureEnabled("GoogleMultidomain")) {
				sel = sel.And("SourceAccountId").IsEqual(Column.Parameter(SourceAccountId));
			} else {
				sel = sel.And("Activity", "OwnerId").IsEqual(Column.Parameter(UserConnection.CurrentUser.ContactId));
			}
			return sel as Select;
		}

		private void TryDeleteActivity(Guid activityId, Guid correspondenceId) {
			try {
				var activitySchema = UserConnection.EntitySchemaManager.GetInstanceByName("Activity");
				var activity = activitySchema.CreateEntity(UserConnection);
				var fetchFilter = new Dictionary<string, object> {
						{"Id", activityId}
					};
				if (!UserConnection.GetIsFeatureEnabled("GoogleMultidomain")) {
					fetchFilter["Owner"] = UserConnection.CurrentUser.ContactId;
				}
				if (activity.FetchFromDB(fetchFilter)) {
					activity.Delete(activityId);
					if (UserConnection.GetIsFeatureEnabled("GoogleMultidomain")) {
						var upd = new Update(UserConnection, "ActivityCorrespondence")
						.Set("ActivityId", Column.Const(null))
						.Where("ActivityId").IsEqual(Column.Parameter(activityId));
						upd.Execute();
					}
				}
			} catch (DbOperationException) {
				var upd = new Update(UserConnection, "ActivityCorrespondence")
					.Set("IsDeleted", new QueryParameter(true))
					.Where("Id").IsEqual(new QueryParameter(correspondenceId)) as Update;
				upd.Execute();
			} catch (SecurityException) {
				var upd = new Update(UserConnection, "ActivityCorrespondence")
					.Set("IsDeleted", new QueryParameter(true))
					.Where("Id").IsEqual(new QueryParameter(correspondenceId)) as Update;
				upd.Execute();
			} catch (Terrasoft.Core.Process.EntityUsedByProcessException) {
				var upd = new Update(UserConnection, "ActivityCorrespondence")
					.Set("IsDeleted", new QueryParameter(true))
					.Where("Id").IsEqual(new QueryParameter(correspondenceId)) as Update;
				upd.Execute();
			} catch (Exception e) {
				LogMessage(e.ToString(), UserConnection, "GoogleCalendar");
				throw;
			}
		}

		private void ProcessDeletedInGoogleActivity(GoogleActivity gActivity) {
			LogMessage("ProcessDeletedInGoogleActivity started", UserConnection, "GoogleCalendar");
			var sel = GetDeletedGeventActivityCorrespondenceSelect(gActivity);
			var needDelete = false;
			Guid correspondenceId = Guid.Empty;
			Guid activityId = Guid.Empty;
			using (DBExecutor dbExecutor = UserConnection.EnsureDBConnection()) {
				using (IDataReader dataReader = sel.ExecuteReader(dbExecutor)) {
					if (dataReader.Read()) {
						correspondenceId = dataReader.GetGuid(dataReader.GetOrdinal("Id"));
						if (dataReader.IsDBNull(dataReader.GetOrdinal("ActivityId"))) {
							var del = new Delete(UserConnection).From("ActivityCorrespondence")
								.Where("Id").IsEqual(new QueryParameter(correspondenceId)) as Delete;
							del.Execute(dbExecutor);
							DeletedRecordsInBPMonlineCount++;
							LogMessage($"ActivityId is null for {correspondenceId}", UserConnection, "GoogleCalendar");
							return;
						}
						if (dataReader.GetDateTime(dataReader.GetOrdinal("ActivityModifiedOn")) > gActivity.UpdatedUTC) {
							LogMessage($"ActivityModifiedOn is greater for {correspondenceId}", UserConnection, "GoogleCalendar");
							return;
						}
						DeletedRecordsInBPMonlineCount++;
						activityId = dataReader.GetGuid(dataReader.GetOrdinal("ActivityId"));
						needDelete = true;
					} else {
						LogMessage($"no correcpondense for {gActivity.SourceId}", UserConnection, "GoogleCalendar");
						return;
					}
				}
			}
			if (!needDelete) {
				LogMessage("ProcessDeletedInGoogleActivity ended 2", UserConnection, "GoogleCalendar");
				return;
			}
			LogMessage($"Delete is needed for {correspondenceId}", UserConnection, "GoogleCalendar");
			sel = new Select(UserConnection)
				.Column("IsDeleted")
				.From("ActivityCorrespondence")
				.Where("ActivityId").IsEqual(new QueryParameter(activityId)) as Select;
			if (UserConnection.GetIsFeatureEnabled("GoogleMultidomain")) {
				sel = sel.And("SourceAccountId").IsEqual(Column.Parameter(SourceAccountId)) as Select;
			}
			var notDeletedCount = 0;
			var recordsCount = 0;
			string isDeletedColumnName = "IsDeleted";
			using (DBExecutor dbExecutor = UserConnection.EnsureDBConnection()) {
				using (IDataReader dataReader = sel.ExecuteReader(dbExecutor)) {
					while (dataReader.Read()) {
						recordsCount++;
						var isDeletedNumber = dataReader.GetOrdinal(isDeletedColumnName);
						notDeletedCount = (dataReader.IsDBNull(isDeletedNumber) || !dataReader.GetColumnValue<bool>(isDeletedColumnName))
							? notDeletedCount + 1
							: notDeletedCount;
					}
				}
			}
			if (recordsCount == 1 || (recordsCount > 1 && notDeletedCount < 2)) {
				LogMessage($"recordsCount for delete is 1 for {correspondenceId}", UserConnection, "GoogleCalendar");
				TryDeleteActivity(activityId, correspondenceId);
				var del = new Delete(UserConnection).From("ActivityCorrespondence")
					.Where("Id").IsEqual(new QueryParameter(correspondenceId)) as Delete;
				del.Execute();
				LogMessage("ProcessDeletedInGoogleActivity ended 1", UserConnection, "GoogleCalendar");
				return;
			}
			if (recordsCount > 1 && notDeletedCount > 1) {
				LogMessage($"recordsCount for delete is more than 1 for {correspondenceId}", UserConnection, "GoogleCalendar");
				var up = new Update(UserConnection, "ActivityCorrespondence")
					.Set("IsDeleted", new QueryParameter(true))
					.Where("Id").IsEqual(new QueryParameter(correspondenceId)) as Update;
				up.Execute();
			}
		}

		private bool CheckIsSetupGSync(Guid contactId) {
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "SocialAccount");
			esq.PrimaryQueryColumn.IsAlwaysSelect = true;
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "[SysAdminUnit:Id:User].Contact",
				contactId));
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Type",
				CommunicationConsts.GoogleTypeUId));
			if (UserConnection.GetIsFeatureEnabled("GoogleMultidomain")) {
				esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Enable", true));
			}
			var socialAccounts = esq.GetEntityCollection(UserConnection);
			return socialAccounts.Count > 0;
		}

		private void SetActivityMembersFromBpm(Entity activity) {
			var organizerId = activity.GetTypedColumnValue<Guid>("OrganizerId");
			if (organizerId.IsNotEmpty() || UserConnection.GetIsFeatureEnabled("GoogleMultidomain")) {
				return;
			}
			var ownerId = activity.GetTypedColumnValue<Guid>("OwnerId");
			var newOrganizerId = CheckIsSetupGSync(ownerId)
				? ownerId
				: UserConnection.CurrentUser.ContactId;
			activity.SetColumnValue("OrganizerId", newOrganizerId);
			activity.CreateUpdate().Execute();
		}

		private Guid GetGoogleSyncContactRecordId(string email) {
			Guid contactId = Guid.Empty;
			if (UserConnection.GetIsFeatureEnabled("GoogleMultidomain")) {
				var meetingService = ClassFactory.Get<IMeetingService>(new ConstructorArgument("uc", UserConnection));
				contactId = meetingService.GetCalendarOwnerId(email);
			} else {
				var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "SocialAccount");
				var contactIdColumn = esq.AddColumn("[SysAdminUnit:Id:User].Contact.Id");
				esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Login", email));
				esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Type", CommunicationConsts.GoogleTypeUId));
				var collection = esq.GetEntityCollection(UserConnection);
				if (collection.Count > 0) {
					Entity contact = collection.First();
					contactId = contact.GetTypedColumnValue<Guid>(contactIdColumn.Name);
				}
			}
			return contactId;
		}

		private EntitySchemaQuery GetActivityParticipantSchemaQuery(Guid activityId, bool usersOnly = true) {
			var participantSchemaQuery = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "ActivityParticipant");
			participantSchemaQuery.AddAllSchemaColumns();
			participantSchemaQuery.Filters.Add(participantSchemaQuery.CreateFilterWithParameters(FilterComparisonType.Equal,
				"Activity",
				activityId));
			if (usersOnly || UserConnection.GetIsFeatureEnabled("GoogleCalendarUsersOnly")) {
				var activeUserFilter = participantSchemaQuery.CreateFilterWithParameters(FilterComparisonType.Equal,
					"Participant.[SysAdminUnit:Contact].Active", true);
				participantSchemaQuery.Filters.Add(activeUserFilter);
				var userFilter = participantSchemaQuery.CreateFilterWithParameters(FilterComparisonType.Equal,
					"Participant.[SysAdminUnit:Contact].SysAdminUnitTypeValue", Core.DB.SysAdminUnitType.User);
				participantSchemaQuery.Filters.Add(userFilter);
				var generalUserFilter = participantSchemaQuery.CreateFilterWithParameters(FilterComparisonType.Equal,
					"Participant.[SysAdminUnit:Contact].ConnectionType", 0);
				participantSchemaQuery.Filters.Add(generalUserFilter);
			}
			return participantSchemaQuery;
		}

		private void SetResponseStatusParticipant(GoogleActivityParticipant gParticipant, Entity participant) {
			if (UserConnection.GetIsFeatureEnabled("GoogleMultidomain") && gParticipant == null) {
				return;
			}
			string gResponseStatus = gParticipant == null ? ResponseStatusAccepted : gParticipant.ResponseStatus;
			switch (gResponseStatus) {
				case ResponseStatusNeedsAction:
				case ResponseStatusTentative: {
						participant.SetColumnValue("InviteResponseId", ActivityConsts.ParticipantResponseInDoubtId);
						participant.SetColumnValue("InviteParticipant", true);
						break;
					}
				case ResponseStatusAccepted: {
						participant.SetColumnValue("InviteResponseId", ActivityConsts.ParticipantResponseConfirmedId);
						participant.SetColumnValue("InviteParticipant", true);
						break;
					}
				default: {
						participant.SetColumnValue("InviteResponseId", ActivityConsts.ParticipantResponseDeclinedId);
						participant.SetColumnValue("InviteParticipant", false);
						break;
					}
			}
		}

		/// <summary>
		/// Creates existing Activity query for <paramref name="googleActivities"/>.
		/// </summary>
		/// <param name="googleActivities">Google activities collection.</param>
		/// <returns><see cref="EntitySchemaQuery"/> instance.</returns>
		private EntitySchemaQuery GetExistingActivitiesMetadataQuery(IEnumerable<SyncEntity<GoogleActivity>> googleActivities) {
			string[] sourceIds = googleActivities.Where(a => !string.IsNullOrEmpty(a.Item.SourceId))
				.Select(a => a.Item.SourceId).ToArray();
			IEnumerable<string> extIds = googleActivities.Where(a => HasExtId(a.Item)).Select(a => a.Item.ExtId);
			string logSourceIds = string.Format("GetExistingActivitiesMetadataQuery sourceIds=[{0}]; extIds=[{1}]",
			StringUtilities.Concat(sourceIds), StringUtilities.Concat(extIds));
			LogMessage(logSourceIds, UserConnection, "GoogleCalendar");
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "ActivityCorrespondence");
			esq.AddColumn("Activity");
			esq.AddColumn("SourceActivityId");
			esq.AddColumn("ModifiedOn").Name = MetadataModifiedOnColumnName;
			var participantModifiedOnColumn = esq.AddColumn("[ActivityParticipant:Activity:Activity].ModifiedOn");
			participantModifiedOnColumn.OrderByDesc();
			participantModifiedOnColumn.Name = ParticipantModifiedOnColumnName;
			esq.PrimaryQueryColumn.IsAlwaysSelect = true;
			var sourceActivityIdfilter = esq.CreateFilterWithParameters(FilterComparisonType.Equal,
					"SourceActivityId", sourceIds);
			extIds = extIds.Where(extId => extId.IsNotEmpty());
			if (extIds.IsEmpty()) {
				esq.Filters.Add(sourceActivityIdfilter);
			} else {
				var filtersGroup = new EntitySchemaQueryFilterCollection(esq, LogicalOperationStrict.Or) {
					sourceActivityIdfilter,
					esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Activity", extIds.ToArray()),
				};
				esq.Filters.Add(filtersGroup);
			}
			return esq;
		}

		private IEnumerable<Entity> GetExistingMetadata(IEnumerable<SyncEntity<GoogleActivity>> googleActivities) {
			EntitySchemaQuery esq = GetExistingActivitiesMetadataQuery(googleActivities);
			var result = esq.GetEntityCollection(UserConnection).ToList();
			if (UserConnection.GetIsFeatureEnabled("GoogleMultidomain")) {
				var ssmdEsq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "SysSyncMetaData");
				ssmdEsq.AddColumn("LocalId").Name = "ActivityId";
				ssmdEsq.AddColumn("RemoteId").Name = "SourceActivityId";
				ssmdEsq.AddColumn("ModifiedOn").Name = MetadataModifiedOnColumnName;
				ssmdEsq.AddColumn(DateTime.UtcNow, UserConnection.DataValueTypeManager.GetInstanceByName("DateTime")).Name = ParticipantModifiedOnColumnName;//todo conflict resolve logic check
				ssmdEsq.PrimaryQueryColumn.IsAlwaysSelect = true;
				string[] iCalUIds = googleActivities.Where(a => !string.IsNullOrEmpty(a.Item.ICalUId))
				.Select(a => a.Item.ICalUId).ToArray();
				ssmdEsq.Filters.Add(ssmdEsq.CreateFilterWithParameters(FilterComparisonType.Equal,
					"RemoteId", iCalUIds));
				ssmdEsq.Filters.Add(ssmdEsq.CreateFilterWithParameters(FilterComparisonType.Equal,
					"SyncSchemaName", "Activity"));
				result.AddRange(ssmdEsq.GetEntityCollection(UserConnection).ToList());
			}
			return result;
		}

		/// <summary>
		/// Creates new Activity instance by <paramref name="gActivity"/>
		/// </summary>
		/// <param name="gActivity"><see cref="GoogleActivity"/> instance.</param>
		private void CreateNewActivity(GoogleActivity gActivity) {
			EntitySchema activitySchema = UserConnection.EntitySchemaManager.GetInstanceByName("Activity");
			Entity activity = activitySchema.CreateEntity(UserConnection);
			SetActivityDefColumnValues(ref activity);
			activity.SetColumnValue("TypeId", ActivityConsts.TaskTypeUId);
			activity.SetColumnValue("ActivityCategoryId", ActivityConsts.AppointmentActivityCategoryId);
			activity.SetColumnValue("ShowInScheduler", true);
			bool isNeedSync = IsNeedActivitySyncFromGoogle(gActivity, activity, true);
			if (!isNeedSync) {
				LogMessage(string.Format("CreateNewActivity. google event id={0}, {1} need no sync", gActivity.SourceId,
					gActivity.AuthorEmail), UserConnection, "GoogleCalendar");
				return;
			}
			GEventToActivity(gActivity, ref activity);
			var correspondence = GetActivityCorrespondence(gActivity);
			using (DBExecutor dbExecutor = UserConnection.EnsureDBConnection()) {
				dbExecutor.StartTransaction();
				try {
					SaveEntity(correspondence);
					SetActivityMembersFromGoogle(gActivity, activity);
					SaveEntity(activity);
					correspondence.SetColumnValue("ActivityId", activity.PrimaryColumnValue);
					SaveEntity(correspondence);
					dbExecutor.CommitTransaction();
					GoogleEventParticipantsToActivity(gActivity, activity.PrimaryColumnValue);
					SetGEventExtId(gActivity, activity);
					AddedRecordsInBPMonlineCount++;
					if (gActivity.UpdatedUTC > GetUtcDateTime(LastSynchronizationDate)) {
						LastSynchronizationEndDate = TimeZoneInfo.ConvertTimeFromUtc(gActivity.UpdatedUTC,
							UserConnection.CurrentUser.TimeZone).AddSeconds(1);
					}
					var updList = (List<GoogleActivity>)UpdGRecordsList;
					((List<EventReminder>)GetGoogleActivityReminders(gActivity)).Clear();
					updList.Add(gActivity);
				} catch (DbOperationException e) {
					dbExecutor.RollbackTransaction();
					LogMessage($"Failed to create new activity for google event with id '{gActivity.SourceId}. " +
						$"Exception: {e}", UserConnection, "GoogleCalendar");
				}
			}
		}

		/// <summary>
		/// Changes activity instance. Last modify date used for conflict resolution.
		/// </summary>
		/// <param name="gActivity"><see cref="GoogleActivity"/> instance.</param>
		/// <param name="metadata">Activity metadata instance</param>
		/// <param name="resolvedConflictUIds">Activity ids that changed in google and bpmonline.</param>
		private void EditActivity(GoogleActivity gActivity, Entity metadata, List<Guid> resolvedConflictIds) {
			EntitySchema activitySchema = UserConnection.EntitySchemaManager.GetInstanceByName("Activity");
			Entity activity = activitySchema.CreateEntity(UserConnection);
			if (!activity.FetchFromDB(metadata.GetTypedColumnValue<Guid>("ActivityId"))) {
				return;
			}
			bool isNeedSync = IsNeedActivitySyncFromGoogle(gActivity, activity, false);
			if (!isNeedSync) {
				return;
			}
			var activityModifiedOn = activity.GetTypedColumnValue<DateTime>("ModifiedOn");
			var metadataModifiedOn = metadata.GetTypedColumnValue<DateTime>(MetadataModifiedOnColumnName);
			var activityParticipantModifiedOn = metadata.GetTypedColumnValue<DateTime>(ParticipantModifiedOnColumnName);
			var isConflictRecord = IsConflictRecord(activityModifiedOn, activityParticipantModifiedOn, metadataModifiedOn);
			var BPMIsAConflictResolver = ResolveUpdateConflict(gActivity, activity, activityParticipantModifiedOn);
			Action<GoogleActivity, Entity> UpdAndSaveActivityByGEvent =
				(GoogleActivity googleActivity, Entity act) => {
					if (!act.GetTypedColumnValue<bool>("ShowInScheduler")) {
						return;
					}
					if (GetUtcDateTime(activityModifiedOn) > gActivity.UpdatedUTC) {
						AddCorrespondenceIfNotExists(googleActivity, act.PrimaryColumnValue);
						return;
					}
					GEventToActivity(googleActivity, ref act);
					act.Save();
					var organizerId = activity.GetTypedColumnValue<Guid>("OrganizerId");
					if (organizerId == UserConnection.CurrentUser.ContactId || organizerId.IsEmpty()) {
						GoogleEventParticipantsToActivity(googleActivity, act.PrimaryColumnValue, !organizerId.IsEmpty());
					}
					var upd = new Update(UserConnection, "ActivityCorrespondence")
						.Set("ModifiedOn", new QueryParameter("Now", DateTime.UtcNow, "DateTime"))
						.Set("ExtraParameters", new QueryParameter(GetExtraParameters(gActivity)))
						.Where("SourceActivityId").IsEqual(new QueryParameter(gActivity.SourceId)) as Update;
					upd.Execute();
					AddCorrespondenceIfNotExists(googleActivity, act.PrimaryColumnValue);
					UpdatedRecordsInBPMonlineCount++;
				};
			if (isConflictRecord) {
				if (!BPMIsAConflictResolver) {
					UpdAndSaveActivityByGEvent(gActivity, activity);
				} else {
					AddToModifyList((Activity)activity, metadata.GetTypedColumnValue<string>("SourceActivityId"));
				}
				resolvedConflictIds.Add(metadata.GetTypedColumnValue<Guid>("Id"));
			} else {
				UpdAndSaveActivityByGEvent(gActivity, activity);
			}
			if (gActivity.UpdatedUTC > GetUtcDateTime(LastSynchronizationDate)) {
				LastSynchronizationEndDate = TimeZoneInfo.ConvertTimeFromUtc(gActivity.UpdatedUTC,
					UserConnection.CurrentUser.TimeZone).AddSeconds(1);
			}
		}

		/// <summary>
		/// Process changed and added google activities.
		/// </summary>
		/// <param name="syncEntities">List of <see cref="SyncEntity"/> instances.</param>
		private void ProcessAddedAndUpdatedGoogleActivities(IEnumerable<SyncEntity<GoogleActivity>> syncEntities) {
			if (ResolvedConflictUIds == null) {
				ResolvedConflictUIds = new List<Guid>();
			}
			var resolvedConflictIds = ResolvedConflictUIds as List<Guid>;
			IEnumerable<Entity> activitiesMetadata = GetExistingMetadata(syncEntities);
			var updatedEntities = syncEntities.Where(se => activitiesMetadata.Any(m =>
				m.GetTypedColumnValue<string>("SourceActivityId") == se.Item.SourceId ||
				m.GetTypedColumnValue<string>("SourceActivityId") == se.Item.ICalUId ||
				m.GetTypedColumnValue<string>("ActivityId") == se.Item.ExtId));
			var newEntities = syncEntities.Where(item => !updatedEntities.Contains(item));
			string logMsg = string.Format("ProcessAddedAndUpdatedGoogleActivities newEntities=[{0}], updatedEntities=[{1}]",
				StringUtilities.Concat(newEntities.Select(ne => ne.Item.SourceId)),
				StringUtilities.Concat(updatedEntities.Select(ue => ue.Item.SourceId)));
			LogMessage(logMsg, UserConnection, "GoogleCalendar");
			foreach (var entity in newEntities) {
				CreateNewActivity(entity.Item);
				LogMessage($"Created from Google {entity.Item.Title}", UserConnection, "GoogleCalendar");
			}
			foreach (var entity in updatedEntities) {
				var gActivity = entity.Item;
				var metadata = activitiesMetadata.First(m =>
					m.GetTypedColumnValue<string>("SourceActivityId") == gActivity.SourceId ||
					m.GetTypedColumnValue<string>("SourceActivityId") == gActivity.ICalUId ||
					m.GetTypedColumnValue<string>("ActivityId") == gActivity.ExtId);
				EditActivity(gActivity, metadata, resolvedConflictIds);
				LogMessage($"Updated from Google {entity.Item.Title}", UserConnection, "GoogleCalendar");
			}
		}

		private void ProcessDeclinedGActivityParticipants(IEnumerable<GoogleActivityParticipant> gParticipants,
			List<Entity> existingParticipants) {
			foreach (var googleActivityParticipant in gParticipants) {
				var contacts = Terrasoft.Configuration.ContactUtilities.FindContactsByEmail(googleActivityParticipant.Email,
					UserConnection);
				if(contacts.Count == 0) {
					LogMessage($"Participant with email: {googleActivityParticipant.Email} was not found in Creatio",
						UserConnection, "GoogleCalendar");
					continue;
				}
				var participantExisted = contacts.Any(contactId => existingParticipants.Any(e => e.GetTypedColumnValue<Guid>("ParticipantId") == contactId));
				if(!participantExisted) {
					googleActivityParticipant.ResponseStatus = ResponseStatusDeclined;
					var contactsIds = string.Join(",", contacts.Select(c => c.ToString()));
					LogMessage($"Decline participant ${googleActivityParticipant.Email}, creatio contacts: {contactsIds}, " +
						$"reason: any contact with participant's email is not in ActivityParticipant",
						UserConnection, "GoogleCalendar");
				}
			}
		}

		/// <summary>
		/// Sets google events to <paramref name="activity"/>.
		/// </summary>
		/// <param name="entry"><see cref="GoogleActivity"/></param>
		/// <param name="activity">Activity</param>
		private void GEventToActivity(GoogleActivity entry, ref Entity activity) {
			TimeZoneInfo currentUserTimeZone = UserConnection.CurrentUser.TimeZone;
			activity.SetColumnValue("StartDate", TimeZoneInfo.ConvertTime(entry.StartDate.ToUniversalTime(),
				TimeZoneInfo.Utc, currentUserTimeZone));
			activity.SetColumnValue("DueDate", TimeZoneInfo.ConvertTime(entry.DueDate.ToUniversalTime(),
				TimeZoneInfo.Utc, currentUserTimeZone));
			if (UserConnection.GetIsFeatureEnabled("PrivateMeetings") && entry.IsPrivate) {
				activity.SetColumnValue("Title", ActivityUtils.GetLczPrivateMeeting(UserConnection));
				activity.SetColumnValue("Notes", string.Empty);
			} else {
				activity.SetColumnValue("Title", entry.Title);
				activity.SetColumnValue("Notes", entry.Description);
			}
			SetActivityRemindToOwner(activity, entry);
			LogMessage("GEventToActivity: activity Id=" + activity.PrimaryColumnValue + ", Title=" + 
					activity.GetTypedColumnValue<String>("Title") + ", From-To=" + 
					activity.GetTypedColumnValue<DateTime>("StartDate") + "-" + 
					activity.GetTypedColumnValue<DateTime>("DueDate"), UserConnection, "GoogleCalendar");
		}

		private void ActivityParticipantsToGoogleEvent(GoogleActivity entry, Entity activity) {
			var usersEsq = GetActivityParticipantSchemaQuery(activity.PrimaryColumnValue);
			var allParticipantsEsq = GetActivityParticipantSchemaQuery(activity.PrimaryColumnValue, false);
			List<Entity> usersActivityParticipants = new List<Entity>(usersEsq.GetEntityCollection(UserConnection));
			List<Entity> allActivityParticipants = new List<Entity>(allParticipantsEsq.GetEntityCollection(UserConnection));
			List<GoogleActivityParticipant> gParticipants = entry.Participants == null
				? new List<GoogleActivityParticipant>()
				: new List<GoogleActivityParticipant>(entry.Participants);
			if (gParticipants.Count > 0) {
				ProcessDeclinedGActivityParticipants(gParticipants, allActivityParticipants);
			}
			var bpmParticipantEmails = new List<string>();
			foreach (ActivityParticipant participant in allActivityParticipants) {
				string email = GetGoogleSyncContactEmail(participant.ParticipantId);
				if (email.IsNullOrEmpty()) {
					continue;
				}
				List<string> contactEmails = Terrasoft.Configuration.ContactUtilities.GetContactEmails(UserConnection,
					participant.ParticipantId);
				bpmParticipantEmails.AddRange(contactEmails);
				if (!usersActivityParticipants.Any(p => p.GetTypedColumnValue<Guid>("ParticipantId") == participant.ParticipantId)) {
					continue;
				}
				var contactExistInGoogle = gParticipants.Any(
					p => contactEmails.Any(e => e.Equals(p.Email, StringComparison.CurrentCultureIgnoreCase)) &&
						p.ResponseStatus != ResponseStatusDeclined);
				var contactIsOrganizer = UserConnection.GetIsFeatureEnabled("GoogleMultidomain")
					? contactEmails.Any(ce => ce.Equals(entry.AuthorEmail, StringComparison.CurrentCultureIgnoreCase))
					: false;
				if (participant.InviteParticipant && !contactExistInGoogle && !contactIsOrganizer) {
					gParticipants.Add(new GoogleActivityParticipant {
						Email = email,
						ResponseStatus = ResponseStatusNeedsAction
					});
				} else if (!participant.InviteParticipant && contactExistInGoogle && !contactIsOrganizer) {
					gParticipants.Remove(
						gParticipants.First(p => String.Equals(p.Email, email, StringComparison.CurrentCultureIgnoreCase)));
				}
			}
			for (int i = gParticipants.Count - 1; i >= 0; i--) {
				if (bpmParticipantEmails.Any(e => e.Equals(gParticipants[i].Email, StringComparison.CurrentCultureIgnoreCase))) {
					continue;
				}
				var contactsByEmail = Terrasoft.Configuration.ContactUtilities.FindContactsByEmail(gParticipants[i].Email,
					UserConnection);
				if (contactsByEmail.Count > 0) {
					gParticipants.RemoveAt(i);
				}
			}
			entry.Participants = gParticipants;
		}

		private void ActivityToGEvent(Entity activity, ref GoogleActivity entry, bool isNewGActivity) {
			var id = activity.PrimaryColumnValue;
			var title = activity.GetTypedColumnValue<string>("Title");
			var startDate = activity.GetTypedColumnValue<DateTime>("StartDate");
			var dueDate = activity.GetTypedColumnValue<DateTime>("DueDate");
			LogMessage($"ActivityToGEvent: activity Id={id}, Title={title}, From-To={startDate}-{dueDate}",
				UserConnection, "GoogleCalendar");
			if(!UserConnection.GetIsFeatureEnabled("PrivateMeetings") || !entry.IsPrivate) {
				entry.Title = title;
			}
			var dataValueTypeManager = UserConnection.DataValueTypeManager.GetInstanceByName("DateTime");
			entry.StartDate = (DateTime)dataValueTypeManager.GetValueForSave(UserConnection, startDate);
			entry.DueDate = (DateTime)dataValueTypeManager.GetValueForSave(UserConnection, dueDate);
			if (isNewGActivity || !HasExtId(entry)) {
				SetGEventExtId(entry, activity);
			}
			LogMessage($"ActivityToGEvent: entry ExtId={entry.ExtId}, Title={entry.Title}, " +
				$"From-To={entry.StartDate}-{entry.DueDate}", UserConnection, "GoogleCalendar");
			if (activity.GetTypedColumnValue<Guid>("OrganizerId") == UserConnection.CurrentUser.ContactId) {
				ActivityParticipantsToGoogleEvent(entry, activity);
			}
		}

		private bool HasExtId( GoogleActivity entry) {
			try {
				return !string.IsNullOrEmpty(entry.ExtId);
			} catch (KeyNotFoundException) {
				entry.ExtId = string.Empty;
			}
			return false;
		}

		private EntitySchemaQuery GetActivityEntitySchemaQuery() {
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "Activity");
			esq.PrimaryQueryColumn.IsAlwaysSelect = true;
			esq.AddColumn("Organizer");
			esq.AddColumn("Owner");
			esq.AddColumn("Title");
			esq.AddColumn("StartDate");
			esq.AddColumn("DueDate");
			esq.AddColumn("ShowInScheduler");
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "ShowInScheduler", true));
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.NotEqual, "Type", ActivityConsts.EmailTypeUId));
			return esq;
		}

		private void SetDefaultServicePointProperties() {
			GoogleApisServicePoint.MaxIdleTime = IdleTimeoutValue;
		}

		private string GetExtraParameters(GoogleActivity gActivity) {
			var extraParameters = new JObject();
			extraParameters["ICalUId"] = gActivity.ICalUId;
			extraParameters["InvitesSent"] = gActivity.Participants?.Any(p => !p.Organizer) ?? false;
			return Json.Serialize(extraParameters);
		}

		private void AddCorrespondenceIfNotExists(GoogleActivity gActivity, Guid activityId) {
			if (!UserConnection.GetIsFeatureEnabled("GoogleMultidomain")) {
				return;
			}
			var correspondence = UserConnection.EntitySchemaManager.GetEntityByName("ActivityCorrespondence", UserConnection);
			if (!correspondence.FetchFromDB(new Dictionary<string, object> {
						{"SourceActivityId", gActivity.SourceId},
						{"Activity", activityId},
						{"SourceAccount", SourceAccountId }
					})) {
				correspondence = GetActivityCorrespondence(gActivity);
				correspondence.SetColumnValue("ActivityId", activityId);
				correspondence.Save();
			}
		}

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Sets members from <paramref name="gActivity"/> in <paramref name="activity"/>
		/// </summary>
		/// <param name="gActivity"><see cref="GoogleActivity"/> instance.</param>
		/// <param name="activity">Activity</param> instance.
		protected virtual void SetActivityMembersFromGoogle(GoogleActivity gActivity, Entity activity) {
			Guid currentContactId = UserConnection.CurrentUser.ContactId;
			string authorEmail = gActivity.AuthorEmail;
			Guid googleSyncContactId = GetGoogleSyncContactRecordId(authorEmail);
			if (googleSyncContactId.IsEmpty()) {
				List<Guid> contactsByEmail = ContactUtilities.FindContactsByEmail(authorEmail, UserConnection);
				if (UserConnection.GetIsFeatureEnabled("GoogleMultidomain")) {
					activity.SetColumnValue("OrganizerId", null);
				} else {
					activity.SetColumnValue("OrganizerId", currentContactId);
				}
				activity.SetColumnValue("OwnerId", contactsByEmail.Count == 0 ? currentContactId : contactsByEmail.First());
			} else {
				activity.SetColumnValue("OwnerId", googleSyncContactId);
				activity.SetColumnValue("OrganizerId", googleSyncContactId);
			}
			activity.SetColumnValue("AuthorId", currentContactId);
		}

		/// <summary>
		/// Saves <paramref name="entity"/> instance.
		/// </summary>
		/// <param name="entity"><see cref="Entity"/> instance.</param>
		protected virtual void SaveEntity(Entity entity) {
			entity.Save();
		}

		/// <summary>
		/// Gets reminders from <paramref name="gActivity"/>
		/// </summary>
		/// <param name="gActivity"><see cref="GoogleActivity"/> instance.</param>
		/// <returns> List <see cref="EventReminder"/> instances.</returns>
		protected virtual IEnumerable<EventReminder> GetGoogleActivityReminders(GoogleActivity gActivity) {
			return gActivity.Reminders ?? new List<EventReminder>();
		}

		/// <summary>
		/// Sets reminder to Activity owner instance by <paramref name="gActivity"/>.
		/// </summary>
		/// <param name="activity">Activity instance.</param>
		/// <param name="gActivity"><see cref="GoogleActivity"/> instance.</param>
		protected virtual void SetActivityRemindToOwner(Entity activity, GoogleActivity gActivity) {
			IEnumerable<EventReminder> reminders = GetGoogleActivityReminders(gActivity);
			if (reminders != null && reminders.Any()) {
				long interval = long.MaxValue;
				foreach (var reminder in reminders) {
					if (reminder.Method == "popup" && reminder.Minutes.HasValue && interval > reminder.Minutes.Value) {
						interval = reminder.Minutes.Value;
					}
				}
				if (interval != long.MaxValue) {
					activity.SetColumnValue("RemindToOwner", true);
					activity.SetColumnValue("RemindToOwnerDate",
						activity.GetTypedColumnValue<DateTime>("StartDate").AddMinutes(-interval));
				} else {
					activity.SetColumnValue("RemindToOwner", false);
					activity.SetColumnValue("RemindToOwnerDate", null);
				}
			} else {
				activity.SetColumnValue("RemindToOwner", false);
				activity.SetColumnValue("RemindToOwnerDate", null);
			}
		}

		/// <summary>
		/// Sets activity participants from <paramref name="gActivity"/>.
		/// </summary>
		/// <param name="gActivity"><see cref="GoogleActivity"/></param> instance.
		/// <param name="activityId"> Activity unique identifier.</param>
		protected virtual void GoogleEventParticipantsToActivity(GoogleActivity gActivity, Guid activityId, bool deleteParticipants = true) {
			var entitySchema = UserConnection.EntitySchemaManager.GetInstanceByName("ActivityParticipant");
			var query = GetActivityParticipantSchemaQuery(activityId, false);
			EntityCollection bpmActivityParticipants = query.GetEntityCollection(UserConnection);
			Dictionary<Guid, string> foundContactsInBpm = new Dictionary<Guid, string>();
			if (gActivity.Participants != null) {
				foundContactsInBpm = Terrasoft.Configuration.ContactUtilities.GetContactsByEmails(UserConnection,
					gActivity.Participants.Select(p => p.Email).ToList());
			}
			if (!foundContactsInBpm.ContainsKey(UserConnection.CurrentUser.ContactId)) {
				foundContactsInBpm.Add(UserConnection.CurrentUser.ContactId, SocialAccountName);
			}
			var bpmActivityParticipantsCopy = bpmActivityParticipants.ToList();
			foreach (var activityParticipant in bpmActivityParticipantsCopy) {
				Guid bmpContactId = activityParticipant.GetTypedColumnValue<Guid>("ParticipantId");
				string bpmContactEmail = Terrasoft.Configuration.ContactUtilities.FindContactEmail(UserConnection, bmpContactId, "");
				if (bpmContactEmail.IsEmpty()) {
					continue;
				}
				bool inviteParticipant = activityParticipant.GetTypedColumnValue<bool>("InviteParticipant");
				if (deleteParticipants && !foundContactsInBpm.ContainsKey(bmpContactId) && inviteParticipant) {
					activityParticipant.Delete();
				}
			}
			foreach (var kvp in foundContactsInBpm) {
				Guid contactId = kvp.Key;
				var activityParticipant = bpmActivityParticipants.Find(e => e.GetTypedColumnValue<Guid>("ParticipantId") == contactId);
				if (activityParticipant == null) {
					activityParticipant = entitySchema.CreateEntity(UserConnection);
					activityParticipant.SetDefColumnValues();
				}
				activityParticipant.SetColumnValue("ActivityId", activityId);
				activityParticipant.SetColumnValue("ParticipantId", contactId);
				GoogleActivityParticipant gParticipant = null;
				if (gActivity.Participants != null) {
					gParticipant = gActivity.Participants.FirstOrDefault(p => string.Equals(p.Email, kvp.Value, StringComparison.CurrentCultureIgnoreCase));
					if (gParticipant == null) {
						LogMessage($"{kvp.Value} not found in {gActivity.SourceId} participants", UserConnection, "GoogleCalendar");
					}
				}
				SetResponseStatusParticipant(gParticipant, activityParticipant);
				activityParticipant.Save();
			}
		}

		/// <summary>
		/// Sets activity default values.
		/// </summary>
		/// <param name="activity">Activity instance.</param>
		protected virtual void SetActivityDefColumnValues(ref Entity activity) {
			activity.SetDefColumnValues();
		}

		/// <summary>
		/// Gets new ActivityCorrespondence <see cref="Entity"/> instance.
		/// </summary>
		/// <param name="gActivity"><see cref="GoogleActivity"/> instance.</param>
		/// <returns>New ActivityCorrespondence <see cref="Entity"/> instance.</returns>
		protected virtual Entity GetActivityCorrespondence(GoogleActivity gActivity) {
			var correspondence = UserConnection.EntitySchemaManager.GetEntityByName("ActivityCorrespondence", UserConnection);
			correspondence.SetDefColumnValues();
			correspondence.SetColumnValue("SourceActivityId", gActivity.SourceId);
			correspondence.SetColumnValue("SourceAccountId", SourceAccountId);
			correspondence.SetColumnValue("ExtraParameters", GetExtraParameters(gActivity));
			return correspondence;
		}

		protected virtual bool IsConflictRecord(DateTime activityModifiedOn, DateTime activityParticipantModifiedOn,
			DateTime activityCorModifiedOn) {
			return ((activityModifiedOn > LastSynchronizationDate) || (activityParticipantModifiedOn > LastSynchronizationDate)) &&
					((activityCorModifiedOn < activityModifiedOn) || (activityCorModifiedOn < activityParticipantModifiedOn));
		}

		/// <summary>
		/// Checks if need to synchronize activity from google.
		/// </summary>
		/// <param name="gActivity"><see cref="GoogleActivity"/> instance.</param>
		/// <param name="activity">Activity instance.</param>
		/// <param name="isNewActivity"> Flag, true if is a new activity.</param>
		/// <returns><c>true</c> if need to synchronize activity from google; otherwise - <c>false</c>.
		/// </returns>
		protected virtual bool IsNeedActivitySyncFromGoogle(GoogleActivity gActivity, Entity activity, bool isNewActivity) {
			Guid currentContactId = UserConnection.CurrentUser.ContactId;
			if (!isNewActivity) {
				var organizerId = activity.GetTypedColumnValue<Guid>("OrganizerId");
				if (currentContactId.Equals(organizerId) || organizerId.IsEmpty()) {
					return true;
				}
				if (UserConnection.GetIsFeatureEnabled("GoogleMultidomain")) {
					var meetingService = ClassFactory.Get<IMeetingService>(new ConstructorArgument("uc", UserConnection));
					return !meetingService.HasActiveCalendar(organizerId);
				}
				return false;
			}
			List<Guid> contactsByEmail = ContactUtilities.FindContactsByEmail(gActivity.AuthorEmail, UserConnection);
			if (contactsByEmail.Find(id => id.Equals(currentContactId)).IsNotEmpty()) {
				return true;
			}
			return !GetGoogleSyncContactRecordId(gActivity.AuthorEmail).IsNotEmpty();
		}

		/// <summary>
		/// Resolves update conflict between <paramref name="gActivity"/> and <paramref name="activity"/>.
		/// </summary>
		/// <param name="gActivity"><see cref="GoogleActivity"/> instance.</param>
		/// <param name="activity">Activity instance.</param>
		/// <param name="participantModifiedOnColumn"><see cref="EntitySchemaQueryColumn"/> instance.</param>
		/// <returns><c>True</c> if <paramref name="activity"/> modify date greater than <paramref name="gActivity"/>
		/// modify date, <c>false</c> otherwise.</returns>
		/// <remarks>Activity participants last modify date can be used as activity modify date.</remarks>
		protected virtual bool ResolveUpdateConflict(GoogleActivity gActivity, Entity activity,
				EntitySchemaQueryColumn participantModifiedOnColumn) {
			var activityModifiedOn = activity.GetTypedColumnValue<DateTime>("ModifiedOn");
			var activityParticipantModifiedOn = activity.GetTypedColumnValue<DateTime>(participantModifiedOnColumn.Name);
			return gActivity.UpdatedUTC < GetUtcDateTime(activityModifiedOn) ||
					gActivity.UpdatedUTC < GetUtcDateTime(activityParticipantModifiedOn);
		}

		/// <summary>
		/// Resolves update conflict between <paramref name="gActivity"/> and <paramref name="activity"/>.
		/// </summary>
		/// <param name="gActivity"><see cref="GoogleActivity"/> instance.</param>
		/// <param name="activity">Activity instance.</param>
		/// <param name="participantModifiedOnColumn"><see cref="EntitySchemaQueryColumn"/> instance.</param>
		/// <returns><c>True</c> if <paramref name="activity"/> modify date greater than <paramref name="gActivity"/>
		/// modify date, <c>false</c> otherwise.</returns>
		/// <remarks>Activity participants last modify date can be used as activity modify date.</remarks>
		protected virtual bool ResolveUpdateConflict(GoogleActivity gActivity, Entity activity,
				DateTime activityParticipantModifiedOn) {
			var activityModifiedOn = activity.GetTypedColumnValue<DateTime>("ModifiedOn");
			var organizerId = activity.GetTypedColumnValue<Guid>("OrganizerId");
			if (UserConnection.GetIsFeatureEnabled("GoogleMultidomain") && organizerId.IsEmpty()) { 
				return false;
			}
			return gActivity.UpdatedUTC < GetUtcDateTime(activityModifiedOn) ||
					gActivity.UpdatedUTC < GetUtcDateTime(activityParticipantModifiedOn);
		}

		/// <summary>
		/// Sets google activity extended id property.
		/// </summary>
		/// <param name="gActivity"><see cref="GoogleActivity"/> instance.</param>
		/// <param name="activity"><see cref="Entity"/> instance.</param>
		protected virtual void SetGEventExtId(GoogleActivity gActivity, Entity activity) {
			if (gActivity.ExtId.IsEmpty()) {
				gActivity.ExtId = activity.PrimaryColumnValue.ToString();
				string msg = string.Format("SetGEventExtId: gActivity {0} ({1}-{2}) recived ExtId = {3}",
					gActivity.Title, gActivity.StartDate, gActivity.DueDate, gActivity.ExtId);
				LogMessage(msg, UserConnection, "GoogleCalendar");
			}
		}

		#endregion

		#region Methods: Public

		public override void PrepareGoogleSynchronization() {
			try {
				SyncProvider.Authenticate(AccessToken);
			} catch (Exception e) {
				throw new GoogleSynchronizationException(e.Message, e);
			}
			SetDefaultServicePointProperties();
			CurrentSynchronizationDate = UserConnection.CurrentUser.GetCurrentDateTime();
			GetLastSyncDate("GoogleCalendarLastSynchronization", "GoogleCalendarLastSynchronizationEnd");
			var helper = ClassFactory.Get<EntitySynchronizerHelper>();
			helper.ClearEntitySynchronizer(UserConnection);
		}

		public override void ProcessGoogleChangedEntities() {
			LogMessage("ProcessGoogleChangedEntities started", UserConnection, "GoogleCalendar");
			IEnumerable<SyncEntity<GoogleActivity>> modifiedGEntities =
				SyncProvider.GetModifiedEntities(LastSynchronizationEndDate);
			ModifiedGEntities = modifiedGEntities;
			LogMessage("ProcessGoogleChangedEntities ModifiedGEntities selected", UserConnection, "GoogleCalendar");
			var deletedGActivities =
				modifiedGEntities.Where(
					item => (int)item.State == 0 && ((IsFirstSync && item.Item.DueDate > Today) || !IsFirstSync));
			LogMessage("ProcessGoogleChangedEntities deletedGActivities selected", UserConnection, "GoogleCalendar");
			var newUpdatedGActivities =
				modifiedGEntities.Where(
					item => item.State != GoogleServices.SyncState.Deleted
						&& ((IsFirstSync && item.Item.DueDate > Today) || !IsFirstSync)
						&& (item.State != GoogleServices.SyncState.Modified
							|| item.Item.UpdatedUTC >= GetUtcDateTime(LastSynchronizationDate)));
			LogMessage("ProcessGoogleChangedEntities newUpdatedGActivities selected", UserConnection, "GoogleCalendar");
			foreach (var syncEntity in deletedGActivities) {
				ProcessDeletedInGoogleActivity(syncEntity.Item);
			}
			LogMessage("ProcessGoogleChangedEntities deletedGActivities processed", UserConnection, "GoogleCalendar");
			var portion = new List<SyncEntity<GoogleActivity>>();
			var i = 1;
			foreach (var item in newUpdatedGActivities) {
				LogMessage($"ProcessGoogleChangedEntities google item {item.Item.Title}, {item.Item.UpdatedUTC}, {item.State}",
					UserConnection, "GoogleCalendar");
				portion.Add(item);
				if (i % RecordsPerPortion == 0) {
					ProcessAddedAndUpdatedGoogleActivities(portion);
					portion.Clear();
				}
				i++;
			}
			if (portion.Count > 0) {
				ProcessAddedAndUpdatedGoogleActivities(portion);
				portion.Clear();
			}
			LogMessage("ProcessGoogleChangedEntities ended", UserConnection, "GoogleCalendar");
		}

		public override void ProcessBPMonlineAddedEntities() {
			var currentUserId = UserConnection.CurrentUser.ContactId;
			var esq = GetActivityEntitySchemaQuery();
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal,
				"[ActivityParticipant:Activity].Participant", currentUserId));
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Greater, "ModifiedOn", LastSynchronizationDate));
			if (IsFirstSync) {
				esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Greater, "DueDate", Today));
			}
			var filtersByExisting = new EntitySchemaQueryFilterCollection(esq) {
				IsNot = true
			};
			var notExFilter = esq.CreateFilterWithParameters(FilterComparisonType.IsNotNull,
				"[ActivityCorrespondence:Activity].SourceActivityId");
			filtersByExisting.Add(notExFilter);
			if (UserConnection.GetIsFeatureEnabled("GoogleMultidomain")) {
				var currentCalendarFilter = esq.CreateFilterWithParameters(FilterComparisonType.Equal,
					"[ActivityCorrespondence:Activity].SourceAccount", SourceAccountId);
				filtersByExisting.Add(currentCalendarFilter);
			}
			esq.Filters.Add(filtersByExisting);
			var entityCollection = esq.GetEntityCollection(UserConnection);
			if (entityCollection.Count > 0) {
				var selectQuery = esq.GetSelectQuery(UserConnection);
				selectQuery.BuildParametersAsValue = true;
				LogMessage(
					"CreateNewBPMRecords selecting Activities:\n" + selectQuery.GetSqlText(), UserConnection, "GoogleCalendar");
			}
			LogMessage($"activity count = {entityCollection.Count}", UserConnection, "GoogleCalendar");
			foreach (Activity activity in entityCollection) {
				LogMessage($"New activities: Owner = {activity.GetTypedColumnValue<Guid>("OwnerId")}; " +
						$"Organizer = {activity.GetTypedColumnValue<Guid>("OrganizerId")}; " +
						$"Title = {activity.Title}", UserConnection, "GoogleCalendar");
				var helper = ClassFactory.Get<EntitySynchronizerHelper>();
				if (!helper.CanCreateEntityInRemoteStore(activity.Id, UserConnection, "GoogleCalendar")) {
					LogMessage($"CanCreateEntityInRemoteStore continue", UserConnection, "GoogleCalendar");
					continue;
				}
				SetActivityMembersFromBpm(activity);
				LogMessage($"New activities after set OrganizerId: Owner = {activity.GetTypedColumnValue<Guid>("OwnerId")}; " +
						$"Organizer = {activity.GetTypedColumnValue<Guid>("OrganizerId")}; " +
						$"Title = {activity.Title}", UserConnection, "GoogleCalendar");
				if (!currentUserId.Equals(activity.OrganizerId)) {
					var skipActivity = true;
					if (UserConnection.GetIsFeatureEnabled("GoogleMultidomain")) {
						var meetingService = ClassFactory.Get<IMeetingService>(new ConstructorArgument("uc", UserConnection));
						skipActivity = meetingService.HasActiveCalendar(activity.OrganizerId);
					}
					if (skipActivity) {
						LogMessage($"currentUserId != activity.OrganizerId continue", UserConnection, "GoogleCalendar");
						helper.UnlockEntity(activity.Id, UserConnection.CurrentUser.ContactId, "GoogleCalendar", UserConnection);
						continue;
					}
				}
				var entry = new GoogleActivity {
					AuthorEmail = SocialAccountName
				};
				ActivityToGEvent(activity, ref entry, true);
				NewGRecordsList.Add(entry);
				LogMessage($"Activity \"{activity.Title}\" added to synchronize", UserConnection, "GoogleCalendar");
			}
		}

		public override void ProcessBPMonlineChangedEntities() {
			var currentUserId = UserConnection.CurrentUser.ContactId;
			var esq = GetActivityEntitySchemaQuery();
			esq.AddColumn("[ActivityCorrespondence:Activity].SourceActivityId");
			if (UserConnection.GetIsFeatureEnabled("GoogleMultidomain")) {
				var organizerFilterGroup = new EntitySchemaQueryFilterCollection(esq, LogicalOperationStrict.Or) {
					esq.CreateFilterWithParameters(FilterComparisonType.Equal, "[ActivityCorrespondence:Activity].SourceAccount", SourceAccountId),
					esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Organizer", currentUserId)
				};
				esq.Filters.Add(organizerFilterGroup);
			} else {
				esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Organizer", currentUserId));
			}
			var modifiedOnFilterGroup = new EntitySchemaQueryFilterCollection(esq, LogicalOperationStrict.Or);
			var activityModifiedOnFilterGroup = new EntitySchemaQueryFilterCollection(esq, LogicalOperationStrict.And) {
				esq.CreateFilterWithParameters(FilterComparisonType.Greater, "ModifiedOn", LastSynchronizationDate),
				esq.CreateFilterWithParameters(FilterComparisonType.LessOrEqual, "ModifiedOn", CurrentSynchronizationDate)
			};
			var participantModifiedOnFilterGroup = new EntitySchemaQueryFilterCollection(esq, LogicalOperationStrict.And) {
				esq.CreateFilterWithParameters(FilterComparisonType.Greater, "[ActivityParticipant:Activity].ModifiedOn",
					LastSynchronizationDate),
				esq.CreateFilterWithParameters(FilterComparisonType.LessOrEqual, "[ActivityParticipant:Activity].ModifiedOn",
					CurrentSynchronizationDate)
			};
			modifiedOnFilterGroup.Add(activityModifiedOnFilterGroup);
			modifiedOnFilterGroup.Add(participantModifiedOnFilterGroup);
			esq.Filters.Add(modifiedOnFilterGroup);
			if (IsFirstSync) {
				esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Greater, "DueDate", Today));
			}
			var resolvedConflictUIds = ResolvedConflictUIds as List<Guid>;
			if (resolvedConflictUIds.Count > 0) {
				List<object> list = resolvedConflictUIds.ConvertAll<object>(new Converter<Guid, object>(g => (object)g));
				esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.NotEqual, "Id", list.ToArray()));
			}
			var entityCollection = esq.GetEntityCollection(UserConnection);
			foreach (Activity activity in entityCollection) {
				AddToModifyList(activity);
			}
		}

		public override void ProcessBPMonlineDeletedEntities() {
			using (var dbExecutor = UserConnection.EnsureDBConnection()) {
				new Delete(UserConnection).From("ActivityCorrespondence")
					.Where("IsDeleted").IsEqual(Column.Parameter(true))
					.And("ActivityId").IsNull().Execute(dbExecutor);
				Select select = new Select(UserConnection)
					.Column("SourceActivityId")
					.From("ActivityCorrespondence")
					.Where("ActivityId").IsNull()
					.And("SourceAccountId").IsEqual(Column.Parameter(SourceAccountId))
					.And("IsDeleted").IsNotEqual(Column.Parameter(true)) as Select;
				using (var reader = select.ExecuteReader(dbExecutor)) {
					while (reader.Read()) {
						DelGRecordsList.Add(reader.GetString(0));
					}
				}
				var deletionThreshold = SystemSettings.GetValue(UserConnection, "GCalendarDeletionThreshold", DefaultThresholdValue);
				if (deletionThreshold != DefaultThresholdValue && DelGRecordsList != null && DelGRecordsList.Count > deletionThreshold) {
					LogMessage($"Skipped Google records deletion. Threshold:\"{deletionThreshold}\", Pending records:\"{DelGRecordsList.Count}\"", UserConnection, "GoogleCalendar");
					DelGRecordsList.Clear();
				}
			}
		}

		public override void FinalizeSynchronization() {
			var updList = (List<GoogleActivity>)UpdGRecordsList;
			foreach (var updActivity in updList) {
				LogMessage($"Updated from Bpm {updActivity.Title}", UserConnection, "GoogleCalendar");
			}
			foreach (var addActivity in NewGRecordsList) {
				LogMessage($"Created from Bpm {addActivity.Title}", UserConnection, "GoogleCalendar");
			}
			foreach (var delGRecord in DelGRecordsList) {
				LogMessage($"Deleted from Bpm {delGRecord}", UserConnection, "GoogleCalendar");
			}
			var syncProvider = SyncProvider;
			if (NewGRecordsList != null && NewGRecordsList.Count > 0) {
				SyncProvider.CreateEntities(NewGRecordsList);
				AddedRecordsInGoogleCount = NewGRecordsList.Count;
			}
			if (updList != null && updList.Count > 0) {
				syncProvider.UpdateEntities(updList);
				UpdatedRecordsInGoogleCount = updList.Count;
			}
			if (DelGRecordsList != null && DelGRecordsList.Count > 0) {
				SyncProvider.DeleteEntities(DelGRecordsList);
				List<QueryColumnExpression> delIds = DelGRecordsList.Select(delId => Column.Parameter(delId)).ToList();
				new Delete(UserConnection).From("ActivityCorrespondence")
					.Where("SourceActivityId").In(delIds).Execute();
				DeletedRecordsInGoogleCount = DelGRecordsList.Count;
			}
			syncProvider.Commit();
			if (syncProvider.CommitErrors.IsNotEmpty()) {
				string errors = "";
				using (AdaptiveStringBuilder builder = new AdaptiveStringBuilder("Commit errors")) {
					foreach (string error in syncProvider.CommitErrors) {
						builder.Append(error);
						builder.Append("\n");
					}
					errors = builder.ToString();
				}
				LogMessage(string.Format("Errors on commit: {0}", errors), UserConnection, "GoogleCalendar");
			}
			UpdCorrespondenceForTransfferredRecords(syncProvider.ProcessedEntities);
			SetSyncDate();
		}

		#endregion

	}

	#endregion

}
