namespace Terrasoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using Creatio.FeatureToggling;
	using IntegrationApi.MailboxDomain.Interfaces;
	using IntegrationApi.MailboxDomain.Model;
	using Newtonsoft.Json.Linq;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Factories;
	using Terrasoft.Social.Google;
	using Terrasoft.Social.OAuth;

	#region Class: BaseOAuthAuthenticator

	/// <summary>
	/// Class provides base OAuth authentification flow methods for existing synchronizations.
	/// </summary>
	public abstract class BaseOAuthAuthenticator : OAuthAuthenticator
	{

		#region Fields: Private

		/// <summary>
		/// Saved <see cref="MailboxSyncSettings.SysAdminUnit"/> column value. 
		/// Filled in <see cref="GetMailboxOwner"/> method.
		/// </summary>
		private Guid _mailboxOwnerId = Guid.Empty;

		/// <summary>
		/// Saved <see cref="OAuthUserCredentials"/> user credentials. 
		/// </summary>
		private OAuthUserCredentials _credentials;

		#endregion

		#region Constructors: Public

		/// <summary><see cref="OAuthAuthenticator(UserConnection)"/></summary>
		public BaseOAuthAuthenticator(UserConnection userConnection) : base(userConnection) {
		}

		/// <summary><see cref="OAuthAuthenticator()"/></summary>
		public BaseOAuthAuthenticator() : base() {
		}

		#endregion

		#region Methods: Private

		/// <summary>
		/// Creates mailbox check select body.
		/// </summary>
		/// <param name="columnPath">Selecting column path string.</param>
		/// <returns><see cref="Select"/> instance.</returns>
		private Select GetCheckMailboxSelectBody(string columnPath) {
			return new Select(UserConnection).Top(1)
				.Column(columnPath)
				.From("MailboxSyncSettings");
		}

		/// <summary>
		/// Get OAuth application id by mail server id.
		/// </summary>
		/// <param name="mailServerId">Mail server unique identifier.</param>
		/// <returns>OAuth app unique identifier.</returns>
		private Guid GetOAuthApplicationId(Guid mailServerId) {
			var mailServerService = ClassFactory.Get<IMailServerService>(new ConstructorArgument("uc", UserConnection));
			var mailServer = mailServerService.GetServer(mailServerId);
			return mailServer.OAuthApplicationId;
		}

		/// <summary>
		/// Checks if a <see cref="ContactCommunication"/> record exists for the specified email (case-insensitive).
		/// </summary>
		/// <param name="userLogin">OAuth user login (email).</param>
		/// <returns><c>true</c> if a matching record exists, <c>false</c> otherwise.</returns>
		private bool ContactCommunicationExists(string userLogin) {
			var select = new Select(UserConnection).Top(1)
				.Column("Id")
				.From("ContactCommunication")
				.Where(Func.Upper("Number")).IsEqual(Func.Upper(Column.Parameter(userLogin)))
				.And("CommunicationTypeId").IsEqual(new QueryParameter("CommunicationTypeId", CommunicationTypeConsts.EmailId, "Guid"))
				.And("ContactId").IsEqual(new QueryParameter("ContactId", UserConnection.CurrentUser.ContactId, "Guid")) as Select;
			return select.ExecuteScalar<Guid>().IsNotEmpty();
		}

		#endregion

		#region Properties: Protected

		protected virtual int TrimLength => 250;

		/// <summary>
		/// Saved <see cref="MailboxSyncSettings"/> instance unique identifier.
		/// Filled in <see cref="CreateNewMailboxSyncSettings"/> method and <see cref="SetExistingMailboxId"/> method.
		/// </summary>
		protected Guid MailboxSyncSettingsId { get; private set; }

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Checks that mailbox already exists in bpm'online.
		/// <see cref="MailboxSyncSettings.SenderEmailAddress"/> used for validation.
		/// </summary>
		/// <param name="credentials"><see cref="OAuthUserCredentials"/> instance.</param>
		/// <returns> <see cref="MailboxSyncSettings.SysAdminUnitId"/> column value when mailbax exists, 
		/// <c>Guid.Empty</c> otherwise.</returns>
		protected virtual Guid GetMailboxOwner(OAuthUserCredentials credentials) {
			if (_mailboxOwnerId.IsNotEmpty()) {
				return _mailboxOwnerId;
			}
			var existingMailboxSelect = GetCheckMailboxSelectBody("SysAdminUnitId")
				.Where(Func.Upper("SenderEmailAddress")).IsEqual(Func.Upper(Column.Parameter(credentials.UserLogin))) as Select;
			_mailboxOwnerId = existingMailboxSelect.ExecuteScalar<Guid>();
			return _mailboxOwnerId;
		}

		/// <summary>
		/// Sets existing user mailbox identifier to <see cref="MailboxSyncSettingsId"/> field.
		/// When field already set, value would not be changed.
		/// </summary>
		/// <param name="credentials"><see cref="OAuthUserCredentials"/> instance.</param>
		protected virtual void SetExistingMailboxId(OAuthUserCredentials credentials) {
			if (MailboxSyncSettingsId.IsNotEmpty()) {
				return;
			}
			var existingMailboxSelect = GetCheckMailboxSelectBody("Id")
				.Where("SenderEmailAddress").IsEqual(Column.Parameter(credentials.UserLogin))
				.And("SysAdminUnitId").IsEqual(Column.Parameter(UserConnection.CurrentUser.Id)) as Select;
			MailboxSyncSettingsId = existingMailboxSelect.ExecuteScalar<Guid>();
		}

		/// <summary>
		/// Checks if current user has default mailbox for send.
		/// </summary>
		/// <returns><c>True</c> if current user has default mailbox for send, <c>false</c> otherwise.</returns>
		protected virtual bool CheckDefaultMailboxExists() {
			var existingMailboxSelect = GetCheckMailboxSelectBody("Id")
				.Where("IsDefault").IsEqual(Column.Parameter(true))
				.And("SysAdminUnitId").IsEqual(Column.Parameter(UserConnection.CurrentUser.Id)) as Select;
			return existingMailboxSelect.ExecuteScalar<Guid>().IsNotEmpty();
		}

		/// <summary>
		/// Creates a new <see cref="Terrasoft.Configuration.MailboxSyncSettings"/> record in the DB.
		/// </summary>
		/// <param name="userLogin">User OAuth login.</param>
		/// <param name="tokenStorageId">OAuth token storage identifier.</param>
		/// <returns><see cref="Guid"/> idenifier of <see cref="Terrasoft.Configuration.MailboxSyncSettings"/>.</returns>
		protected virtual Guid CreateNewMailboxSyncSettings(string userLogin, Guid tokenStorageId) {
			EntitySchema entitySchema = UserConnection.EntitySchemaManager.GetInstanceByName("MailboxSyncSettings");
			Entity mailbox = entitySchema.CreateEntity(UserConnection);
			mailbox.SetDefColumnValues();
			mailbox.SetColumnValue("MailboxName", userLogin);
			mailbox.SetColumnValue("UserName", userLogin);
			mailbox.SetColumnValue("SenderEmailAddress", userLogin);
			mailbox.SetColumnValue("MailServerId", new Guid((string)State["MailServerId"]));
			mailbox.SetColumnValue("OAuthTokenStorageId", tokenStorageId);
			mailbox.SetColumnValue("AutomaticallyAddNewEmails", true);
			mailbox.SetColumnValue("EnableMailSynhronization", false);
			mailbox.SetColumnValue("LoadAllEmailsFromMailBox", true);
			mailbox.SetColumnValue("SendEmailsViaThisAccount", true);
			mailbox.SetColumnValue("IsDefault", !CheckDefaultMailboxExists());
			mailbox.Save();
			MailboxSyncSettingsId = mailbox.PrimaryColumnValue;
			return mailbox.PrimaryColumnValue;
		}

		protected virtual void CreateNewSocialAccount() {
			if (!Features.GetIsEnabled("GoogleMultidomain")) {
				return;
			}
			EntitySchema entitySchema = UserConnection.EntitySchemaManager.GetInstanceByName("SocialAccount");
			Entity socialAccount = entitySchema.CreateEntity(UserConnection);
			var mailServerId = new Guid((string)State["MailServerId"]);
			socialAccount.SetDefColumnValues();
			socialAccount.SetColumnValue("Public", false);
			socialAccount.SetColumnValue("Login", _credentials.UserLogin);
			socialAccount.SetColumnValue("AccessToken", _credentials.AccessToken);
			socialAccount.SetColumnValue("AccessSecretToken", _credentials.RefreshToken);
			socialAccount.SetColumnValue("ConsumerKey", ClientId);
			socialAccount.SetColumnValue("SocialId", GoogleConsumer.GetUserSocialId(_credentials.AccessToken));
			socialAccount.SetColumnValue("TypeId", CommunicationTypeConsts.GoogleId);
			socialAccount.SetColumnValue("Name", _credentials.UserLogin);
			socialAccount.SetColumnValue("IsExpired", false);
			socialAccount.SetColumnValue("UserId", UserConnection.CurrentUser.Id);
			socialAccount.SetColumnValue("MailboxSyncSettingsId", MailboxSyncSettingsId);
			socialAccount.SetColumnValue("MailServerId", mailServerId);
			socialAccount.Save();
		}

		/// <summary>
		///<see cref="OAuthAuthenticator.ProcessSavingCredentialsFinish(Guid)"/>
		/// </summary>
		protected override void ProcessSavingCredentialsFinish(Guid tokenStorageId) {
			if (!MailboxSyncSettingsId.IsNotEmpty()) {
				return;
			}

			EntitySchema entitySchema = UserConnection.EntitySchemaManager.GetInstanceByName("MailboxSyncSettings");
			Entity mailbox = entitySchema.CreateEntity(UserConnection);

			if (mailbox.FetchFromDB(MailboxSyncSettingsId)) {
				var isChanged = false;

				if (mailbox.GetTypedColumnValue<Guid>("OAuthTokenStorageId").IsEmpty() &&
				    tokenStorageId.IsNotEmpty()) {
					mailbox.SetColumnValue("OAuthTokenStorageId", tokenStorageId);
					isChanged = true;
				}

				if (State.TryGetValue("MailServerId", out var valueObj) &&
				    valueObj is string valueStr &&
				    Guid.TryParse(valueStr, out var mailServerId) &&
				    mailbox.GetTypedColumnValue<Guid>("MailServerId") != mailServerId) {
					mailbox.SetColumnValue("MailServerId", mailServerId);
					isChanged = true;
				}

				if (isChanged) {
					mailbox.Save();
				}
			}
		}

		/// <summary>
		/// Create a new <see cref="Terrasoft.Configuration.ContactCommunication"/> record for the specific OAuth user login.
		/// </summary>
		/// <param name="userLogin">OAuth user login.</param>
		protected virtual void CreateNewContactCommunications(string userLogin) {
			if (ContactCommunicationExists(userLogin)) {
				return;
			}
			EntitySchema entitySchema = UserConnection.EntitySchemaManager.GetInstanceByName("ContactCommunication");
			Entity contactCommunication = entitySchema.CreateEntity(UserConnection);
			contactCommunication.SetDefColumnValues();
			contactCommunication.SetColumnValue("CommunicationTypeId", CommunicationTypeConsts.EmailId);
			contactCommunication.SetColumnValue("ContactId", UserConnection.CurrentUser.ContactId);
			contactCommunication.SetColumnValue("Number", userLogin);
			contactCommunication.Save();
		}

		/// <summary>
		/// Returns mailbox synchronization job interval from system settings.
		/// </summary>
		/// <returns>Mailbox synchronization job interval.</returns>
		protected virtual int GetSyncInterval() {
			return Terrasoft.Core.Configuration.SysSettings.GetValue<int>(UserConnection, "MailboxSyncInterval", 1);
		}

		/// <summary>
		/// <see cref="OAuthAuthenticator.GetSuccessResultObject"/>
		/// </summary>
		protected override JObject GetSuccessResultObject(OAuthUserCredentials credentials) {
			var mailServerId = new Guid((string)State["MailServerId"]);
			return new JObject {
				{ "SenderEmailAddress", credentials.UserLogin },
				{ "MailBoxServerId", mailServerId},
				{ "MailboxSyncSettingsId", MailboxSyncSettingsId.ToString()},
				{ "MailboxSyncInterval", GetSyncInterval()},
				{ "AutomaticallyAddNewEmails", true },
				{ "AllowEmailDownloading", GetAllowEmailDownloading(mailServerId)},
				{ "AddMode", GetIsAddingMailboxSyncSettings()}
			};
		}

		/// <summary>
		/// <see cref="OAuthAuthenticator.SaveCredentials"/> 
		/// </summary>
		/// <remarks>Throws <see cref="InvalidObjectStateException"/> when <paramref name="credentials"/> contains
		/// existing mailbox credentials.</remarks>
		protected override void SaveCredentials(OAuthUserCredentials credentials) {
			_credentials = credentials;
			Guid ownerId = GetMailboxOwner(credentials);
			if (ownerId.IsNotEmpty() && !ownerId.Equals(UserConnection.CurrentUser.Id)) {
				throw new InvalidObjectStateException(string.Format("Mailbox {0} already exists!", 
					credentials.UserLogin));
			}
			base.SaveCredentials(credentials);
		}

		/// <summary>
		/// <see cref="OAuthAuthenticator.ValidateCredentials"/>
		/// </summary>
		protected override bool ValidateCredentials(OAuthUserCredentials credentials) {
			Guid ownerId = GetMailboxOwner(credentials);
			bool currentUserMailbox = ownerId.Equals(UserConnection.CurrentUser.Id);
			if (currentUserMailbox) {
				SetExistingMailboxId(credentials);
			}
			return !currentUserMailbox;
		}

		/// <summary>
		/// Checks is related <see cref="MailServer"/> allows email downloading.
		/// </summary>
		/// <param name="mailServerId">Mail server unique identifier.</param>
		/// <returns><c>True</c> if mail server allows email downloading. Otherwise returns <c>false</c>.</returns>
		protected bool GetAllowEmailDownloading(Guid mailServerId) {
			var select = new Select(UserConnection).Top(1)
				.Column("AllowEmailDownloading")
				.From("MailServer")
				.Where("Id").IsEqual(Column.Parameter(mailServerId)) as Select;
			return select.ExecuteScalar<bool>();
		}

		/// <summary>
		/// Checks is current <see cref="MailboxSyncSettings"/> is adding.
		/// </summary>
		/// <returns><c>True</c> if current mailbox is adding. Otherwise returns <c>false</c>.</returns>
		protected bool GetIsAddingMailboxSyncSettings() {
			var select = new Select(UserConnection).Top(1)
				.Column("ErrorCodeId")
				.From("MailboxSyncSettings")
				.Where("Id").IsEqual(Column.Parameter(MailboxSyncSettingsId)) as Select;
			var errorCodeId = select.ExecuteScalar<Guid>();
			return errorCodeId.IsEmpty();
		}

		/// <summary>
		/// <see cref="OAuthAuthenticator.GetResponseErrorValuesFromUrl"/> 
		/// </summary>
		protected override JObject GetResponseErrorValuesFromUrl() {
			var errorType = Request.QueryString["error"];
			var description = Request.QueryString["error_description"];
			string message;
			if (description.IsNullOrEmpty()) {
				message = new LocalizableString(UserConnection.ResourceStorage, "BaseOAuthAuthenticator",
					"LocalizableStrings.EmptyOauthErrorDescriptionTemplate.Value").ToString();
			} else {
				var template = new LocalizableString(UserConnection.ResourceStorage, "BaseOAuthAuthenticator",
					"LocalizableStrings.OauthErrorDescriptionTemplate.Value").ToString();
				message = string.Format(template, description.Truncate(TrimLength));
			}
			return GetResponseErrorValues(errorType, message, message);
		}

		/// <summary>
		/// <see cref="OAuthAuthenticator.GetResponseErrorValuesFromJObject(Exception, JObject)"/>
		/// </summary>
		protected override JObject GetResponseErrorValuesFromJObject(Exception ex, JObject jobject) {
			var error = jobject["error"]?.ToString();
			var description = jobject["error_description"]?.ToString();
			var template = new LocalizableString(UserConnection.ResourceStorage, "BaseOAuthAuthenticator",
				"LocalizableStrings.OauthErrorDescriptionTemplate.Value").ToString();
			var responseMessage = jobject?.ToString();
			var exceptionMessage = (ex.InnerException ?? ex).Message;
			var mailServerMessage = string.Format(template, description?.Truncate(TrimLength));
			return GetResponseErrorValues(error, $"{exceptionMessage} {responseMessage}", mailServerMessage);
		}

		/// <summary>
		/// Checks that <paramref name="credentials"/> is accesable.
		/// </summary>
		/// <param name="credentials"><see cref="OAuthUserCredentials"/> instance.</param>
		/// <returns><c>True</c> if mailbox accessable. Otherwise returns <c>false</c>.</returns>
		protected bool HasAccessToMailbox(OAuthUserCredentials credentials) {
			var currentUser = UserConnection.CurrentUser;
			var mailServerService = ClassFactory.Get<IMailServerService>(new ConstructorArgument("uc", UserConnection));
			var mailServer = mailServerService.GetServer(Guid.Parse((string)State["MailServerId"]));
			var mailbox = new Mailbox(credentials.UserLogin, mailServer);
			mailbox.SetOwner(currentUser.Name, currentUser.Id, currentUser.ContactName);
			mailbox.SetOauthToken(credentials.UserLogin, credentials.AccessToken);
			mailbox.SetAllowSynchronization(true);
			mailbox.SetAllowEmailSend(false);
			var result = mailbox.Validate(UserConnection);
			return result.IsValid;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Authentications user in the specific OAuth application.
		/// </summary>
		/// <param name="userLogin">User login to the application.</param>
		/// <param name="mailServerId">Mail server unique identifier.</param>
		public virtual string AuthenticateUser(string userLogin, Guid mailServerId) {
			ApplicationId = GetOAuthApplicationId(mailServerId);
			State.Add("MailServerId", mailServerId.ToString());
			return base.AuthenticateUser(userLogin);
		}

		/// <summary>
		/// Processes authentication code from OAuth application.
		/// </summary>
		public virtual void ProcessAuthenticationCode() {
			var queryString = Request.QueryString;
			var code = queryString["code"];
			if (code.IsNullOrEmpty()) {
				ProcessAuthenticationCodeError();
			} else {
				var state = GetDeserializedState(queryString["state"]);
				if (state.ContainsKey("MailServerId")) {
					ApplicationId = GetOAuthApplicationId(new Guid((string)state["MailServerId"]));
				}
				ProcessAuthenticationCode(code);
			}
		}

		#endregion

	}

	#endregion

}

