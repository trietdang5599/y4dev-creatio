namespace Terrasoft.Configuration {
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Linq;
	using System.Net;
	using global::Common.Logging;
	using Terrasoft.Messaging.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.Entities;

	public abstract class BaseGoogleSynchronizer {

		#region Constants: Private

		private const string GoogleApisUrl = "https://www.googleapis.com";

		#endregion

		#region Constants: Public

		public const int RecordsPerPortion = 40;

		#endregion

		#region Constructors: Protected

		protected BaseGoogleSynchronizer(UserConnection userConnection) {
			_userConnection = userConnection;
			SetCurrenUserGoogleSettings();
		}

		#endregion

		#region Properties: Public

		public int AddedRecordsInBPMonlineCount {
			get;
			set;
		}

		public int UpdatedRecordsInBPMonlineCount {
			get;
			set;
		}

		public int DeletedRecordsInBPMonlineCount {
			get;
			set;
		}

		public int AddedRecordsInGoogleCount {
			get;
			set;
		}

		public int UpdatedRecordsInGoogleCount {
			get;
			set;
		}

		public int DeletedRecordsInGoogleCount {
			get;
			set;
		}

		public DateTime LastSynchronizationDate {
			get;
			set;
		}

		public DateTime LastSynchronizationEndDate {
			get;
			set;
		}

		public DateTime CurrentSynchronizationDate {
			get;
			set;
		}

		public string SocialAccountName {
			get;
			set;
		}

		public string MessageSender {
			get;
			set;
		}

		public Guid MailServerId {
			get;
			set;
		}

		#endregion

		#region Properties: Protected

		private readonly UserConnection _userConnection;

		protected UserConnection UserConnection {
			get {
				return _userConnection;
			}
		}

		private Guid _sourceAccountId;

		protected Guid SourceAccountId {
			get {
				return _sourceAccountId;
			}
		}

		private string _accessToken;

		protected string AccessToken {
			get {
				return _accessToken;
			}
		}

		protected ServicePoint GoogleApisServicePoint =>
			ServicePointManager.FindServicePoint(new Uri(GoogleApisUrl));

		#endregion

		#region Methods: Private

		private void SetCurrenUserGoogleSettings() {
			Guid currentUserId = UserConnection.CurrentUser.Id;
			var socialAccountSchema = UserConnection.EntitySchemaManager.GetInstanceByName("SocialAccount");
			var socialAccountEntity = socialAccountSchema.CreateEntity(UserConnection);
			var fetchFilters = new Dictionary<string, object> {
				{"Type", CommunicationConsts.GoogleTypeUId},
				{"User", currentUserId}
			};
			if (UserConnection.GetIsFeatureEnabled("GoogleMultidomain")) {
				fetchFilters.Add("Enable", true);
			}
			if (socialAccountEntity.FetchFromDB(fetchFilters)) {
				_sourceAccountId = socialAccountEntity.PrimaryColumnValue;
				_accessToken = socialAccountEntity.GetTypedColumnValue<string>("AccessToken");
				SocialAccountName = socialAccountEntity.GetTypedColumnValue<string>("Login");
				MailServerId = socialAccountEntity.GetTypedColumnValue<Guid>("MailServerId");
			}
		}

		private string GetSocialAccountLogin(Guid contactId) {
			string login = string.Empty;
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "SocialAccount");
			var loginColumn = esq.AddColumn("Login");
			if (UserConnection.GetIsFeatureEnabled("GoogleMultidomain")) {
				esq.AddColumn("Enable").OrderByDesc();
			}
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "[SysAdminUnit:Id:User].Contact.Id", contactId));
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Type", CommunicationConsts.GoogleTypeUId));
			var collection = esq.GetEntityCollection(UserConnection);
			if (collection.Count > 0) {
				Entity contact = collection.First();
				login = contact.GetTypedColumnValue<string>(loginColumn.Name);
			}
			return login;
		}

		#endregion

		#region Methods: Protected

		protected DateTime GetUtcDateTime(DateTime rawDate) {
			DateTime dateToConvert = rawDate;
			if (rawDate.Kind != DateTimeKind.Unspecified) {
				dateToConvert = DateTime.SpecifyKind(rawDate, DateTimeKind.Unspecified);
			}
			TimeZoneInfo info = UserConnection.CurrentUser.TimeZone;
			DateTime utcDate = TimeZoneInfo.ConvertTimeToUtc(dateToConvert, info);
			return utcDate;
		}

		protected static void LogMessage(String messageBody, UserConnection userConnection, string sender) {
			var log = LogManager.GetLogger("Terrasoft.Sync");
			log.Info(string.Format("[{0}] - {1}", sender, messageBody));
			Guid sysAdminUnitId = userConnection.CurrentUser.Id;
			try {
				IMsgChannel channel = MsgChannelManager.Instance.FindItemByUId(sysAdminUnitId);
				if (channel == null) {
					return;
				}
				var simpleMessage = new SimpleMessage { Id = sysAdminUnitId, Body = messageBody };
				simpleMessage.Header.Sender = sender;
				channel.PostMessage(simpleMessage);
			} catch (InvalidOperationException) {
			}
		}

		protected void GetLastSyncDate(string sysSettingsCodeStartDate, string sysSettingsCodeEndDate) {
			LastSynchronizationDate = (DateTime) Core.Configuration.SysSettings.GetValue(UserConnection,
				sysSettingsCodeStartDate);
			LastSynchronizationEndDate = (DateTime) Core.Configuration.SysSettings.GetValue(UserConnection,
				sysSettingsCodeEndDate);
		}

		protected void SetLastSyncDate(string sysSettingsCodeStartDate, string sysSettingsCodeEndDate) {
			Core.Configuration.SysSettings.SetValue(UserConnection, sysSettingsCodeStartDate,
				UserConnection.CurrentUser.GetCurrentDateTime());
			Core.Configuration.SysSettings.SetValue(UserConnection, sysSettingsCodeEndDate,
				UserConnection.CurrentUser.GetCurrentDateTime());
		}

		protected void SetLastSyncDate(string sysSettingsCodeStartDate, string sysSettingsCodeEndDate,
			DateTime dateStart, DateTime dateEnd) {
			Core.Configuration.SysSettings.SetValue(UserConnection, sysSettingsCodeStartDate,
				dateStart);
			Core.Configuration.SysSettings.SetValue(UserConnection, sysSettingsCodeEndDate,
				dateEnd);
		}

		protected Guid GetIdByName(string name, string entityName) {
			if (String.IsNullOrEmpty(name)) {
				return Guid.Empty;
			}
			var select = new Select(UserConnection).
				Column("Id").
				From(entityName).
				Where("Name").IsEqual(Column.Parameter(name)) as Select;
			using (DBExecutor dbExecutor = UserConnection.EnsureDBConnection()) {
				using (IDataReader dataReader = select.ExecuteReader(dbExecutor)) {
					if (dataReader.Read()) {
						return dataReader.GetGuid(0);
					}
				}
			}
			return Guid.Empty;
		}

		protected void LogSyncDates(string methodName) {
			const string messageTpl = "{0}: LastSynchronizationDate = {1}, LastSynchronizationEndDate = {2}";
			LogMessage(
				String.Format(messageTpl, methodName, LastSynchronizationDate, LastSynchronizationEndDate), UserConnection,
				MessageSender);
		}

		protected string GetGoogleSyncContactEmail(Guid contactId) {
			string email = GetSocialAccountLogin(contactId);
			if (String.IsNullOrEmpty(email)) {
				email = Terrasoft.Configuration.ContactUtilities.FindContactEmail(UserConnection,
					contactId, "gmail.com");
			}
			return email;
		}

		#endregion

		#region Methods: Public

		public virtual void Synchronize() {
			try {
				LogSyncDates("Synchronize");
				PrepareGoogleSynchronization();
				LogSyncDates($"PrepareGoogleSynchronization. Locked connections: {GoogleApisServicePoint.CurrentConnections}");
				ProcessGoogleChangedEntities();
				LogSyncDates("ProcessGoogleChangedEntities");
				ProcessBPMonlineAddedEntities();
				LogSyncDates("ProcessBPMonlineAddedEntities");
				ProcessBPMonlineChangedEntities();
				LogSyncDates("ProcessBPMonlineChangedEntities");
				ProcessBPMonlineDeletedEntities();
				LogSyncDates("PrepareDeletedBPMRecords");
				FinalizeSynchronization();
				LogSyncDates($"FinalizeSynchronization. Locked connections: {GoogleApisServicePoint.CurrentConnections}");
			} catch (Exception e) {
				LogMessage(e.ToString(), UserConnection, MessageSender);
			}
		}

		#endregion

		#region Methods: Abstract

		public abstract void PrepareGoogleSynchronization();

		public abstract void ProcessGoogleChangedEntities();

		public abstract void ProcessBPMonlineAddedEntities();

		public abstract void ProcessBPMonlineChangedEntities();

		public abstract void ProcessBPMonlineDeletedEntities();

		public abstract void FinalizeSynchronization();

		#endregion

	}
}
