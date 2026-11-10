namespace Terrasoft.Configuration
{
	using IntegrationApi.Calendar;
	using IntegrationApi.Calendar.DTO;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.Entities;
	using Terrasoft.GoogleServices;
	using Terrasoft.Social;

	#region Enum: MessageType

	public enum IntegrationResponseCode
	{
		None,
		SettingsNotSet,
		AuthenticationFailed,
		IntegrationConditionError,
		InternalError,
		Success
	}

	#endregion

	#region Class: GoogleIntegrationHelper

	public class GoogleIntegrationHelper
	{

		#region Constants: Private

		private const string SyncProcessNameTemplate = "G{0}SynchronizationModuleProcess";
		private const string ContactEntitySchemaName = "Contact";
		private const string ActivityEntitySchemaName = "Activity";
		private const int MaxGoogleCalendarDateDiff = 21;

		#endregion

		#region Properties: Private

		private readonly UserConnection _userConnection;

		private UserConnection UserConnection {
			get {
				return _userConnection;
			}
		}

		private Entity _socialAccount { get; set; }

		#endregion

		#region Properties: Public

		public string EntitySchemaName {
			get;
			internal set;
		}

		public string IntegrationProcessName {
			get {
				return GetIntegrationProcessName(EntitySchemaName);
			}
		}

		public virtual LocalizableString SettingsNotSetMessage {
			get {
				return GetLocalizableString("SettingsNotSetMessage");
			}
		}

		public virtual LocalizableString AuthenticationFailedMessage {
			get {
				return GetLocalizableString("AuthenticationFailedMessage");
			}
		}

		public virtual LocalizableString TagNotSetMessage {
			get {
				return GetLocalizableString("TagNotSetMessage");
			}
		}

		public virtual LocalizableString SyncDateLiesTooFarInThePastMessage {
			get {
				return GetLocalizableString("SyncDateLiesTooFarInThePastMessage");
			}
		}

		public virtual LocalizableString UnsupportedIntegrationEntityMessage {
			get {
				return GetLocalizableString("UnsupportedIntegrationEntityMessage");
			}
		}

		public virtual LocalizableString UserTokenNotFoundMessage {
			get {
				return GetLocalizableString("UserTokenNotFoundMessage");
			}
		}

		#endregion

		#region Constructors: Public

		public GoogleIntegrationHelper(UserConnection userConnection):
			this(userConnection, ActivityEntitySchemaName) { 
		}

		public GoogleIntegrationHelper(UserConnection userConnection, string entitySchemaName) {
			_userConnection = userConnection;
			EntitySchemaName = entitySchemaName;
		}

		#endregion

		#region Methods: Private

		private string GetIntegrationProcessName(string entitySchemaName) {
			return string.Format(SyncProcessNameTemplate, entitySchemaName);
		}

		private LocalizableString GetLocalizableString(string name) {
			var stringName = string.Format("LocalizableStrings.{0}.Value", name);
			return new LocalizableString(UserConnection.Workspace.ResourceStorage, "GoogleIntegrationHelper", stringName);
		}

		private void CheckUserToken(Guid mailServerId) {
			var manager = BaseConsumer.GetTokenProvider(SocialNetwork.Google, mailServerId);
			var userToken = manager.FindUserTokenByUserId(UserConnection.CurrentUser.Id.ToString());
			if (userToken == null) {
				throw new GoogleIntegrationException(UserTokenNotFoundMessage, IntegrationResponseCode.InternalError);
			}
		}

		private Entity TryGetSocialAccountEntity() {
			if (_socialAccount != null) {
				return _socialAccount;
			}
			var socialAccountSchema = UserConnection.EntitySchemaManager.GetInstanceByName("SocialAccount");
			var socialAccountEntity = socialAccountSchema.CreateEntity(UserConnection);
			if (socialAccountEntity.FetchFromDB(GetSocialAccountFilterConditions())) {
				_socialAccount = socialAccountEntity;
				return socialAccountEntity;
			}
			throw new GoogleIntegrationException(SettingsNotSetMessage, IntegrationResponseCode.SettingsNotSet);
		}

		protected virtual string GetUserAccessToken() {
			return GetUserAccessToken(out var _);
		}

		protected string GetUserAccessToken(out Guid mailServerId) {
			var socialAccountEntity = TryGetSocialAccountEntity();
			var accessToken = socialAccountEntity.GetTypedColumnValue<string>("AccessToken");
			mailServerId = socialAccountEntity.GetTypedColumnValue<Guid>("MailServerId");
			CheckUserToken(mailServerId);
			return accessToken;
		}

		private void UpdateCorresondenceInfo(Guid socialAccountId, Guid oldSocialAccountId) {
			var update = new Update(UserConnection, "ContactCorrespondence")
				.Set("SourceAccountId", Column.Parameter(socialAccountId))
				.Where("SourceAccountId")
				.IsEqual(Column.Parameter(oldSocialAccountId)) as Update;
			update.Execute();
			update = new Update(UserConnection, "ActivityCorrespondence")
				.Set("SourceAccountId", Column.Parameter(socialAccountId))
				.Where("SourceAccountId")
				.IsEqual(Column.Parameter(oldSocialAccountId)) as Update;
			update.Execute();
		}

		private string GetSocialAccountLogin() {
			var socialAccountEntity = TryGetSocialAccountEntity();
			return socialAccountEntity.GetTypedColumnValue<string>("Login");
		}

		private void AddContactCommunicationForCurrentUser() {
			string login = GetSocialAccountLogin();
			if (!login.IsNullOrEmpty()) {
				var communicationSchema = UserConnection.EntitySchemaManager.GetInstanceByName("ContactCommunication");
				var communicationEntity = communicationSchema.CreateEntity(UserConnection);
				if (!communicationEntity.FetchFromDB(new Dictionary<string, object> {
					{
						"Number", login
					}, {
						"Contact", UserConnection.CurrentUser.ContactId
					}
				})) {
					communicationEntity.SetDefColumnValues();
					communicationEntity.SetColumnValue("ContactId", UserConnection.CurrentUser.ContactId);
					communicationEntity.SetColumnValue("Number", login);
					communicationEntity.SetColumnValue("CommunicationTypeId", new Guid(CommunicationTypeConsts.EmailId));
					communicationEntity.Save();
				}
			}
		}

		private EntitySchemaQuery GetGoogleSocialAccountESQ() {
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "SocialAccount");
			esq.PrimaryQueryColumn.IsAlwaysSelect = true;
			esq.AddColumn("Login");
			esq.AddColumn("AccessToken");
			esq.AddColumn("User");
			esq.AddColumn("Type");
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "User", UserConnection.CurrentUser.Id));
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Type", CommunicationConsts.GoogleTypeUId));
			return esq;
		}

		private void VerifyContactTag(Guid googleContactTagId) {
			var tagInstance = UserConnection.EntitySchemaManager.GetInstanceByName("ContactTag");
			var tagEntity = tagInstance.CreateEntity(UserConnection);
			if (!tagEntity.FetchFromDB(googleContactTagId)) {
				throw new GoogleIntegrationException(TagNotSetMessage, IntegrationResponseCode.IntegrationConditionError);
			}
		}

		#endregion

		#region Methods: Protected

		protected virtual Dictionary<string, object> GetSocialAccountFilterConditions() {
			var filters = new Dictionary<string, object> {
				{ "Type", CommunicationConsts.GoogleTypeUId },
				{ "User", UserConnection.CurrentUser.Id }
			};
			if (UserConnection.GetIsFeatureEnabled("GoogleMultidomain")) {
				filters.Add("Enable", true);
			}
			return filters;
		}

		protected virtual void TryAuthorizeGoogleServices(string accessToken) {
			TryAuthorizeGoogleServices(accessToken, Guid.Empty);
		}

		protected void TryAuthorizeGoogleServices(string accessToken, Guid mailServerId) {
			var synchronizer = new GActivitySyncProvider {
				UserConnection = UserConnection,
				MailServerId = mailServerId
			};
			try {
				synchronizer.Authenticate(accessToken);
			} catch (Exception e) {
				throw new GoogleIntegrationException(AuthenticationFailedMessage, IntegrationResponseCode.AuthenticationFailed,
					e.InnerException);
			}
		}

		protected virtual void ValidateContactTag() {
			Guid googleContactTagId = (Guid) Core.Configuration.SysSettings.GetValue(UserConnection, "GoogleContactGroup");
			if (googleContactTagId.IsEmpty()) {
				throw new GoogleIntegrationException(TagNotSetMessage, IntegrationResponseCode.IntegrationConditionError);
			}
			VerifyContactTag(googleContactTagId);
		}

		protected virtual void ValidateCalendarSyncDates() {
			var currentDate = UserConnection.CurrentUser.GetCurrentDateTime();
			var settingsSyncDate =
				(DateTime) Core.Configuration.SysSettings.GetValue(UserConnection, "GoogleCalendarLastSynchronizationEnd");
			if ((currentDate - settingsSyncDate).Days > MaxGoogleCalendarDateDiff) {
				var socialAccountEntity = TryGetSocialAccountEntity();
				throw new GoogleIntegrationException(SyncDateLiesTooFarInThePastMessage,
					IntegrationResponseCode.IntegrationConditionError, socialAccountEntity.GetTypedColumnValue<Guid>("MailboxSyncSettingsId"));
			}
		}

		public virtual void ExecuteIntegrationProcess() {
			UserConnection.RunProcess(IntegrationProcessName);
		}

		#endregion

		#region Methods: Public

		public void ValidateIntegrationConditions() {
			switch (EntitySchemaName) {
				case ContactEntitySchemaName:
					ValidateContactTag();
					break;
				case ActivityEntitySchemaName:
					ValidateCalendarSyncDates();
					break;
				default:
					throw new GoogleIntegrationException(string.Format(UnsupportedIntegrationEntityMessage, EntitySchemaName),
						IntegrationResponseCode.InternalError);
			}
		}

		public void StartGoogleIntegration() {
			ValidateSocialAccountSettings();
			ValidateIntegrationConditions();
			ExecuteIntegrationProcess();
		}

		public void ValidateSocialAccountSettings() {
			string accessToken = GetUserAccessToken(out var mailServerId);
			TryAuthorizeGoogleServices(accessToken, mailServerId);
		}

		public void UpdatePreviousGoogleSocialAccount(Guid socialAccountId) {
			var esq = GetGoogleSocialAccountESQ();
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.NotEqual, "Id", socialAccountId));
			var collection = esq.GetEntityCollection(UserConnection);
			if (collection.Count > 0) {
				List<Entity> existingAccountsCopy = collection.ToList();
				Guid oldSocialAccountId = collection[0].PrimaryColumnValue;
				foreach (var entity in existingAccountsCopy) {
					entity.Delete();
				}
				UpdateCorresondenceInfo(socialAccountId, oldSocialAccountId);
				AddContactCommunicationForCurrentUser();
			}
		}

		public bool HasGoogleSocialAccount() {
			var esq = GetGoogleSocialAccountESQ();
			return esq.GetEntityCollection(UserConnection).Count > 0;
		}

		public List<CalendarAccountInfo> GetGoogleSocialAccounts() {
			var esq = GetGoogleSocialAccountESQ();
			var socialAccountEntities = esq.GetEntityCollection(UserConnection);
			return socialAccountEntities.Select(entity => new CalendarAccountInfo {
				Id = entity.PrimaryColumnValue,
				Email = entity.GetTypedColumnValue<string>("Login"),
				Type = CalendarType.Google
			}).ToList();
		}

		#endregion

	}

	#endregion

	#region Class: GoogleIntegrationException

	public class GoogleIntegrationException : Exception
	{

		#region Properties: Public

		public IntegrationResponseCode ExceptionCode { get; set; }

		public Guid MailboxId { get; set; }

		#endregion

		#region Constructors: Public

		public GoogleIntegrationException(string message, IntegrationResponseCode exceptionCode)
			: base(message) {
			ExceptionCode = exceptionCode;
		}

		public GoogleIntegrationException(string message, IntegrationResponseCode exceptionCode, Exception innerException)
			: base(message, innerException) {
			ExceptionCode = exceptionCode;
		}

		public GoogleIntegrationException(string message, IntegrationResponseCode exceptionCode, Guid mailboxId)
			: base(message) {
			ExceptionCode = exceptionCode;
			MailboxId = mailboxId;
		}

		#endregion

	}

	#endregion

}
