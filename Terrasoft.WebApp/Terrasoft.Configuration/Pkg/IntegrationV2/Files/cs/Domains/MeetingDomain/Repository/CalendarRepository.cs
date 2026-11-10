namespace IntegrationV2.Files.cs.Domains.MeetingDomain.Repository
{
	using System;
	using System.Linq;
	using System.Collections.Generic;
	using Newtonsoft.Json.Linq;
	using Terrasoft.Core;
	using Terrasoft.Core.Factories;
	using IntegrationV2.Files.cs.Domains.MeetingDomain.Repository.Interfaces;
	using IntegrationV2.Files.cs.Domains.MeetingDomain.Model;
	using Terrasoft.Configuration;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Store;
	using Terrasoft.IntegrationV2.Utils;
	using Terrasoft.EmailDomain;
	using Terrasoft.Common;
	using Terrasoft.Common.Json;
	using IntegrationApi.MailboxDomain.Interfaces;
	using IntegrationApi.Calendar;
	using IntegrationApi.MailboxDomain.Model;
	using Terrasoft.Sync;

	#region Class: CalendarRepository
	/// <summary>
	/// <see cref="ICalendarRepository"/> implementation.
	/// </summary>
	[DefaultBinding(typeof(ICalendarRepository), Name = nameof(CalendarRepository))]
	public class CalendarRepository : ICalendarRepository
	{

		#region Constants: Private

		private const string GraphMeetingsDeltaLinkExtraParameterName = "GraphMeetingsDeltaLink";

		private const string GraphMeetingsDeltaCreatedOnUtcExtraParameterName = "GraphMeetingsDeltaCreatedOnUtc";

		private const string GraphMeetingsDeltaCreatedOnDateFormat = "yyyy-MM-dd";

		private const string GraphMeetingsStateRemoteItemName = "GraphCalendarMeetingsState";

		private const string GraphMeetingsStateSchemaName = "ActivitySyncSettings";

		#endregion

		#region Fields: Private

		/// <summary>
		/// <see cref="UserConnection"/> instance.
		/// </summary>
		private readonly UserConnection _userConnection;

		/// <summary>
		/// Synchronization session identifier.
		private readonly string _sessionId;

		#endregion

		#region Constructors: Public

		/// <summary>
		/// .ctor.
		/// </summary>
		/// <param name="uc"><see cref="UserConnection"/> instance.</param>
		/// <param name="sessionId">Session identifier.</param>
		public CalendarRepository(UserConnection uc, string sessionId) {
			_userConnection = uc;
			_sessionId = sessionId;
		}

		#endregion

		#region Methods: Private

		private List<CalendarModel> GetCalendarsFromCache(ICacheStore applicationCache) {
			object store = applicationCache[IntegrationConsts.Calendar.CacheItemName];
			if (ListenerUtils.GetIsFeatureEnabled("IsCalendarCached") && store != null) {
				return store as List<CalendarModel>;
			}
			return null;
		}

		private List<CalendarModel> ConvertEntitiesToModels(EntityCollection calendarsEntities) {
			var result = new List<CalendarModel>();
			var mailboxService = ClassFactory.Get<IMailboxService>(new ConstructorArgument("uc", _userConnection));
			foreach (var calendarEntity in calendarsEntities) {
				var senderEmailAddress = calendarEntity.GetTypedColumnValue<string>("SenderEmailAddress");
				var mailbox = mailboxService.GetMailboxBySenderEmailAddress(senderEmailAddress, false, true);
				var emails = mailboxService.GetEmails(mailbox.Id);
				var calendarType = GetCalendarType(calendarEntity);
				var calendar = new CalendarModel(calendarEntity, _sessionId, emails, calendarType);
				var calendarSettings = CreateCalendarSettings(calendarEntity, mailbox);
				var isSyncPeriodSet = calendar.SyncSinceDate != DateTime.MinValue && calendar.SyncTillDate != DateTime.MinValue;
				var isCalendarSyncEnabled = calendarEntity.GetTypedColumnValue<bool>("ImportAppointments") ||
						calendarEntity.GetTypedColumnValue<bool>("ExportActivities");
				calendarSettings.SyncEnabled = isCalendarSyncEnabled && isSyncPeriodSet &&
						!calendarEntity.GetTypedColumnValue<bool>("SynchronizationStopped") &&
						CanUseCalendarSync(mailbox);
				calendar.OldSyncEnabled = ListenerUtils.GetIsFeatureDisabled("NewMeetingIntegration", mailbox.OwnerId);
				calendar.SetOwner(calendarEntity.GetTypedColumnValue<Guid>("CreatedById"));
				calendar.SetCalendarSettings(calendarSettings);
				calendar.SetGraphMeetingsDeltaLink(GetGraphMeetingsDeltaLink(calendar));
				result.Add(calendar);
			}
			return result;
		}

		/// <summary>
		/// Returns whether calendar synchronization stays enabled for the mailbox.
		/// </summary>
		/// <param name="mailbox"><see cref="Mailbox"/> instance.</param>
		/// <returns><c>True</c> when calendar synchronization is allowed for the mailbox.</returns>
		private static bool CanUseCalendarSync(Mailbox mailbox) {
			return mailbox.CanUseExchangeActivitySync();
		}

		private static CalendarType GetCalendarType(Entity calendarEntity) {
			var mailServerType = calendarEntity.GetTypedColumnValue<Guid>("MailServerTypeId");
			if (mailServerType == IntegrationConsts.GraphMailServerTypeId) {
				return CalendarType.Graph;
			} else if (mailServerType == IntegrationConsts.ImapMailServerTypeId) {
				return CalendarType.Google;
			}
			return CalendarType.Exchange;
		}

		private CalendarSettings CreateCalendarSettings(Entity calendarEntity, Mailbox mailbox) {
			return new CalendarSettings(calendarEntity.GetTypedColumnValue<string>("OAuthClassName")) {
				Id = mailbox.Id,
				OAuthApplicationId = calendarEntity.GetTypedColumnValue<Guid>("OAuthApplicationId"),
				Login = mailbox.Login,
				Password = mailbox.Password,
				UserId = mailbox.OwnerId,
				UserName = mailbox.OwnerUserName,
				SenderEmailAddress = mailbox.SenderEmailAddress,
				ServiceUrl = mailbox.GetServerAddress(true),
				WarningCodeId = calendarEntity.GetTypedColumnValue<Guid>("WarningCodeId"),
				IsLimitMode = calendarEntity.GetTypedColumnValue<bool>("IsLimitMode"),
				UseImpersonation = mailbox.GetUseImpersonation()
			};
		}

		private EntitySchemaQuery GetCalendarEsq() {
			var esq = new EntitySchemaQuery(_userConnection.EntitySchemaManager, "ActivitySyncSettings");
			esq.UseAdminRights = false;
			esq.PrimaryQueryColumn.IsAlwaysSelect = true;
			esq.AddColumn("ActivitySyncPeriod");
			esq.AddColumn("ExportActivities");
			esq.AddColumn("ImportAppointments");
			esq.AddColumn("ImportTranscripts");
			esq.AddColumn("AppointmentLastSyncDate");
			esq.AddColumn("MailboxSyncSettings.SysAdminUnit.Contact").Name = "CreatedBy";
			esq.AddColumn("MailboxSyncSettings.SenderEmailAddress").Name = "SenderEmailAddress";
			esq.AddColumn("MailboxSyncSettings.MailServer.IsLimitMode").Name = "IsLimitMode";
			esq.AddColumn("MailboxSyncSettings.MailServer.OAuthApplication").Name = "OAuthApplication";
			esq.AddColumn("MailboxSyncSettings.MailServer.OAuthApplication.ClientClassName").Name = "OAuthClassName";
			esq.AddColumn("MailboxSyncSettings.MailServer.Type").Name = "MailServerType";
			esq.AddColumn("MailboxSyncSettings.SynchronizationStopped").Name = "SynchronizationStopped";
			esq.AddColumn("MailboxSyncSettings.WarningCode").Name = "WarningCode";
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "MailboxSyncSettings.SysAdminUnit.Active", true));
			return esq;
		}

		private EntitySchemaQuery GetDeletedMeetingsStateEsq() {
			var esq = new EntitySchemaQuery(_userConnection.EntitySchemaManager, "SysSyncMetaData");
			esq.UseAdminRights = false;
			esq.PrimaryQueryColumn.IsAlwaysSelect = true;
			esq.AddColumn("ExtraParameters");
			return esq;
		}

		private Entity GetGraphState(CalendarModel calendar, string remoteItemName) {
			if (calendar == null || calendar.Type != CalendarType.Graph) {
				return null;
			}
			var esq = GetDeletedMeetingsStateEsq();
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "CreatedBy", calendar.OwnerId));
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "LocalId", calendar.Id));
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "SyncSchemaName",
				GraphMeetingsStateSchemaName));
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "RemoteItemName",
				remoteItemName));
			return esq.GetEntityCollection(_userConnection).FirstOrDefault();
		}

		private static JObject GetExtraParameters(string rawExtraParameters) {
			return rawExtraParameters.IsNullOrEmpty()
				? new JObject()
				: JObject.Parse(rawExtraParameters);
		}

		private string GetGraphDeltaLink(CalendarModel calendar, string remoteItemName, string deltaLinkParameterName,
				string createdOnUtcParameterName, string createdOnDateFormat) {
			var state = GetGraphState(calendar, remoteItemName);
			if (state == null) {
				return null;
			}
			var extraParameters = GetExtraParameters(state.GetTypedColumnValue<string>("ExtraParameters"));
			var deltaLink = extraParameters.Value<string>(deltaLinkParameterName);
			if (deltaLink.IsNullOrWhiteSpace()) {
				return null;
			}
			var createdOnRawValue = extraParameters.Value<string>(createdOnUtcParameterName);
			if (!DateTime.TryParseExact(createdOnRawValue, createdOnDateFormat,
					global::System.Globalization.CultureInfo.InvariantCulture,
					global::System.Globalization.DateTimeStyles.None, out var createdOnUtcDate)) {
				return null;
			}
			return createdOnUtcDate.Date == DateTime.UtcNow.Date
				? deltaLink
				: null;
		}

		private string GetGraphMeetingsDeltaLink(CalendarModel calendar) {
			return GetGraphDeltaLink(
				calendar,
				GraphMeetingsStateRemoteItemName,
				GraphMeetingsDeltaLinkExtraParameterName,
				GraphMeetingsDeltaCreatedOnUtcExtraParameterName,
				GraphMeetingsDeltaCreatedOnDateFormat);
		}

		private void SaveGraphDeltaState(CalendarModel calendar, string remoteItemName, string deltaLink,
				string deltaLinkParameterName, string createdOnUtcParameterName, string createdOnDateFormat) {
			var state = GetGraphState(calendar, remoteItemName);
			var extraParameters = state == null
				? new JObject()
				: GetExtraParameters(state.GetTypedColumnValue<string>("ExtraParameters"));
			if (deltaLink.IsNullOrWhiteSpace()) {
				extraParameters.Remove(deltaLinkParameterName);
				extraParameters.Remove(createdOnUtcParameterName);
			} else {
				extraParameters[deltaLinkParameterName] = deltaLink;
				extraParameters[createdOnUtcParameterName] =
					DateTime.UtcNow.ToString(createdOnDateFormat,
						global::System.Globalization.CultureInfo.InvariantCulture);
			}
			var serializedExtraParameters = extraParameters.HasValues
				? Json.Serialize(extraParameters)
				: null;
			var now = DateTime.UtcNow;
			if (state != null) {
				new Update(_userConnection, "SysSyncMetaData")
					.Set("ExtraParameters", Column.Parameter(serializedExtraParameters))
					.Set("ModifiedOn", Column.Parameter(now))
					.Set("Version", Column.Parameter(now))
					.Where("Id").IsEqual(Column.Parameter(state.PrimaryColumnValue))
					.Execute();
				return;
			}
			if (serializedExtraParameters.IsNullOrWhiteSpace()) {
				return;
			}
			new Insert(_userConnection)
				.Into("SysSyncMetaData")
				.Set("Id", Column.Parameter(Guid.NewGuid()))
				.Set("CreatedById", Column.Parameter(calendar.OwnerId))
				.Set("ModifiedById", Column.Parameter(calendar.OwnerId))
				.Set("LocalId", Column.Parameter(calendar.Id))
				.Set("SyncSchemaName", Column.Parameter(GraphMeetingsStateSchemaName))
				.Set("RemoteItemName", Column.Parameter(remoteItemName))
				.Set("SchemaOrder", Column.Parameter(0))
				.Set("CreatedInStoreId", Column.Parameter(ExchangeConsts.LocalStoreId))
				.Set("ModifiedInStoreId", Column.Parameter(ExchangeConsts.LocalStoreId))
				.Set("RemoteStoreId", Column.Parameter(ExchangeConsts.AppointmentStoreId))
				.Set("RemoteId", Column.Parameter(string.Empty))
				.Set("LocalState", Column.Parameter((int)SyncState.Modified))
				.Set("RemoteState", Column.Parameter((int)SyncState.Modified))
				.Set("ModifiedOn", Column.Parameter(now))
				.Set("Version", Column.Parameter(now))
				.Set("ExtraParameters", Column.Parameter(serializedExtraParameters))
				.Execute();
		}

		private void SaveGraphMeetingsState(CalendarModel calendar) {
			SaveGraphDeltaState(
				calendar,
				GraphMeetingsStateRemoteItemName,
				calendar.GraphMeetingsDeltaLink,
				GraphMeetingsDeltaLinkExtraParameterName,
				GraphMeetingsDeltaCreatedOnUtcExtraParameterName,
				GraphMeetingsDeltaCreatedOnDateFormat);
		}

		private void DeleteGraphState(IEnumerable<Guid> calendarSettingsIds, string remoteItemName) {
			var localIds = calendarSettingsIds?
				.Where(id => id.IsNotEmpty())
				.Distinct()
				.ToList() ?? new List<Guid>();
			if (!localIds.Any()) {
				return;
			}
			new Delete(_userConnection)
				.From("SysSyncMetaData")
				.Where("SyncSchemaName").IsEqual(Column.Parameter(GraphMeetingsStateSchemaName))
				.And("RemoteItemName").IsEqual(Column.Parameter(remoteItemName))
				.And("LocalId").In(Column.Parameters(localIds))
				.Execute();
		}

		private void DeleteGraphMeetingsState(IEnumerable<Guid> calendarSettingsIds) {
			DeleteGraphState(calendarSettingsIds, GraphMeetingsStateRemoteItemName);
		}

		/// <summary>
		/// Updates appointments last synchronization date.
		/// </summary>
		/// <param name="calendar"><see cref="CalendarModel"/> instance.</param>
		private void UpdateLastSyncDate(CalendarModel calendar) {
			var update = new Update(_userConnection, "ActivitySyncSettings")
				.Set("AppointmentLastSyncDate", Column.Parameter(calendar.LastSyncDateUtc))
				.Where("Id").IsEqual(Column.Parameter(calendar.Id));
			update.Execute();
		}

		private void UpdateSyncDates(CalendarModel calendar) {
			calendar.UpdateSyncPeriodDates(_userConnection);
			UpdateLastSyncDate(calendar);
		}

		private void UpdateCache(CalendarModel calendar) {
			ICacheStore applicationCache = _userConnection.ApplicationCache;
			var calendars = GetCalendarsFromCache(applicationCache);
			if (calendars != null) {
				calendars.RemoveAll(c => c.Id == calendar.Id);
				calendars.Add(calendar);
				applicationCache[IntegrationConsts.Calendar.CacheItemName] = calendars;
			}
		}

		private List<CalendarModel> GetGoogleCalendars() {
			var result = new List<CalendarModel>();
			var esq = new EntitySchemaQuery(_userConnection.EntitySchemaManager, "SocialAccount");
			esq.UseAdminRights = false;
			esq.PrimaryQueryColumn.IsAlwaysSelect = true;
			esq.AddColumn("Login");
			esq.AddColumn("User");
			esq.AddColumn("Enable");
			esq.AddColumn("MailboxSyncSettings");
			esq.AddColumn("User.Contact").Name = "CreatedBy";
			esq.AddColumn("MailboxSyncSettings.SynchronizationStopped").Name = "SynchronizationStopped";
			esq.AddColumn("MailboxSyncSettings.MailServer.OAuthApplication").Name = "OAuthApplication";
			esq.AddColumn("MailboxSyncSettings.MailServer.OAuthApplication.ClientClassName").Name = "OAuthClassName";
			esq.AddColumn("MailboxSyncSettings.MailServer.IsLimitMode").Name = "IsLimitMode";
			esq.AddColumn("MailboxSyncSettings.WarningCode").Name = "WarningCode";
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "User.Active", true));
			var socialAccountEntities = esq.GetEntityCollection(_userConnection);
			var mailboxService = ClassFactory.Get<IMailboxService>(new ConstructorArgument("uc", _userConnection));
			foreach (var calendarEntity in socialAccountEntities) {
				var mailbox = mailboxService.GetMailbox(calendarEntity.GetTypedColumnValue<Guid>("MailboxSyncSettingsId"), false);
				var emails = mailboxService.GetEmails(mailbox.Id);
				var calendar = new CalendarModel(calendarEntity, _sessionId, emails, CalendarType.Google);
				var calendarSettings = CreateCalendarSettings(calendarEntity, mailbox);
				calendarSettings.SyncEnabled = calendarEntity.GetTypedColumnValue<bool>("Enable") &&
						!calendarEntity.GetTypedColumnValue<bool>("SynchronizationStopped");
				calendar.SetOwner(calendarEntity.GetTypedColumnValue<Guid>("CreatedById"));
				calendar.SetCalendarSettings(calendarSettings);
				result.Add(calendar);
			}
			return result;
		}

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Filter by enabled calendars.
		/// </summary>
		/// <param name="calendars">Collection of <see cref="CalendarModel"/>`s.</param>
		/// <returns>Filtered collection of <see cref="CalendarModel"/>`s by enabled.</returns>
		protected List<CalendarModel> FilterEnabledCalendars(List<CalendarModel> calendars) {
			return calendars.Where(c => c.Settings.SyncEnabled).ToList();
		}

		/// <summary>
		/// Getting a collection of users calendars.
		/// </summary>
		/// <param name="importRequired">Import must be enabled.</param>
		/// <param name="exportRequired">Export must be enabled.</param>
		/// <returns>Collection of <see cref="CalendarModel"/>`s</returns>
		protected virtual List<CalendarModel> GetCalendars(bool importRequired = true, bool exportRequired = true) {
			ICacheStore applicationCache = _userConnection.ApplicationCache;
			var calendars = GetCalendarsFromCache(applicationCache);
			if (calendars == null) {
				var esq = GetCalendarEsq();
				var calendarsEntities = esq.GetEntityCollection(_userConnection);
				calendars = ConvertEntitiesToModels(calendarsEntities);
				if (ListenerUtils.GetIsFeatureEnabled("GoogleMultidomain")) {
					var googleCalendars = GetGoogleCalendars();
					calendars.AddRange(googleCalendars);
				}
				if (ListenerUtils.GetIsFeatureEnabled("IsCalendarCached")) {
					applicationCache[IntegrationConsts.Calendar.CacheItemName] = calendars;
				}
			}
			if (importRequired || exportRequired) {
				calendars = FilterEnabledCalendars(calendars);
			}
			return calendars;
		}

		#endregion

		#region Methods: Public

		/// <inheritdoc cref="ICalendarRepository.GetAllCalendars()"/>
		public List<CalendarModel> GetAllCalendars() {
			return GetCalendars(false, false);
		}

		/// <inheritdoc cref="ICalendarRepository.GetEnabledCalendars()"/>
		public List<CalendarModel> GetEnabledCalendars() {
			return GetCalendars(true, true);
		}

		/// <inheritdoc cref="ICalendarRepository.GetOwnerCalendar(string)"/>
		public CalendarModel GetOwnerCalendar(string email) {
			if (email.IsNullOrEmpty()) {
				return default;
			}
			var calendars = GetCalendars(true, true);
			return calendars.FirstOrDefault(c => c.IsOwnerCalendar(email));
		}

		/// <inheritdoc cref="ICalendarRepository.GetOwnerCalendars(Guid)"/>
		public List<CalendarModel> GetOwnerCalendars(Guid ownerId) {
			var calendars = GetAllCalendars();
			return calendars.Where(c => c.OwnerId == ownerId).ToList();
		}

		/// <inheritdoc cref="ICalendarRepository.GetOwnerCalendar(Guid)"/>
		public CalendarModel GetOwnerCalendar(Guid ownerId) {
			var calendars = GetCalendars(true, true);
			return calendars.FirstOrDefault(c => c.OwnerId == ownerId);
		}

		/// <inheritdoc cref="ICalendarRepository.Save(CalendarModel)"/>
		public void Save(CalendarModel calendar) {
			UpdateSyncDates(calendar);
			UpdateCache(calendar);
		}

		/// <inheritdoc cref="ICalendarRepository.SaveGraphMeetingsDeltaLink(CalendarModel)"/>
		public void SaveGraphMeetingsDeltaLink(CalendarModel calendar) {
			SaveGraphMeetingsState(calendar);
			UpdateCache(calendar);
		}

		/// <inheritdoc cref="ICalendarRepository.DeleteGraphMeetingsDeltaLinkStates(IEnumerable{Guid})"/>
		public void DeleteGraphMeetingsDeltaLinkStates(IEnumerable<Guid> calendarSettingsIds) {
			DeleteGraphMeetingsState(calendarSettingsIds);
		}

		#endregion

	}

	#endregion

}
