namespace Terrasoft.Configuration
{
	using System;
	using System.Text;
	using EmailContract.DTO;
	using global::Common.Logging;
	using Creatio.FeatureToggling;
	using Newtonsoft.Json.Linq;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Factories;
	using Terrasoft.Social.OAuth;
	using IntegrationApi.MailboxDomain.Model;
	using IntegrationApi.MailboxDomain.Interfaces;

	/// <summary>
	/// Represents an base Office365 OAuth authenticator.
	/// </summary>
	public class BaseOffice365OAuthAuthenticator : BaseOAuthAuthenticator
	{

		#region Constructors: Public

		/// <summary><see cref="OAuthAuthenticator(UserConnection)"/></summary>
		public BaseOffice365OAuthAuthenticator(UserConnection userConnection) : base(userConnection) {
		}

		/// <summary><see cref="OAuthAuthenticator()"/></summary>
		public BaseOffice365OAuthAuthenticator() : base() {
		}

		#endregion

		#region Fields: Private

		private static readonly ILog Log = LogManager.GetLogger("Exchange");
		private string _tenantId;
		private bool? _isGraphApi;
		private string _userId;
		private string _userMailboxName;

		#endregion

		#region Properties: Protected

		/// <summary>
		/// Indicates whether current mail server is Graph API server.
		/// </summary>
		protected bool IsGraphApi => GetIsGraphApi();

		/// <summary>
		/// Indicates whether to use the OAuth 2.0 v2 flow.
		/// Returns true if TranscriptSync feature is enabled and a valid tenant ID is configured.
		/// </summary>
		protected bool UseV2Flow => IsGraphApi || Features.GetIsEnabled("TranscriptSync") && !string.IsNullOrEmpty(GetTenantId());

		/// <summary>
		/// Office365 authorization url.
		/// </summary>
		protected override string AuthorizeUrl => UseV2Flow
			? $"https://login.microsoftonline.com/{GetTenantId()}/oauth2/v2.0/authorize"
			: "https://login.microsoftonline.com/common/oauth2/authorize";

		/// <summary>
		/// Office365 token url.
		/// </summary>
		protected override string TokenUrl => UseV2Flow
			? $"https://login.microsoftonline.com/{GetTenantId()}/oauth2/v2.0/token"
			: "https://login.microsoftonline.com/common/oauth2/token";

		/// <summary>
		/// Permission scope that will be passed in query string of <see cref="AuthorizeUrl"/> when getting refresh token.
		/// </summary>
		protected override string Scope => UseV2Flow
			? IsGraphApi
				? "offline_access openid User.Read Mail.ReadWrite Mail.Send Calendars.ReadWrite"
				: "offline_access openid EWS.AccessAsUser.All"
			: null;

		/// <summary>
		/// Default scope that will be passed when getting access token using refresh flow.
		/// </summary>
		protected override string DefaultAccessTokenScope => UseV2Flow
			? IsGraphApi
				? "User.Read Mail.ReadWrite Mail.Send Calendars.ReadWrite"
				: "EWS.AccessAsUser.All"
			: null;

		/// <summary>
		/// The App ID URI of the web API.
		/// </summary>
		protected override string Resource => UseV2Flow
			? string.Empty
			: "https://outlook.office365.com";

		/// <summary>
		/// Flag that indicates is current flow is used as mailbox or as service account.
		/// For service accouts none of mailbox parts are created, only token storage changes applied.
		/// </summary>
		protected bool UseAsServiceAccount { get; set; }

		#endregion

		#region Methods: Private

		/// <summary>
		/// Gets TenantId from OAuthApplications table based on AppClassName.
		/// </summary>
		/// <returns>TenantId string or empty if not configured.</returns>
		private string GetTenantId() {
			if (!string.IsNullOrEmpty(_tenantId)) {
				return _tenantId;
			}
			EntitySchema appSchema = UserConnection.EntitySchemaManager.GetInstanceByName("OAuthApplications");
			Entity application = appSchema.CreateEntity(UserConnection);
			if (application.FetchFromDB(ApplicationId)) {
				_tenantId = application.GetTypedColumnValue<string>("TenantId");
			}
			return _tenantId;
		}

		/// <summary>
		/// Returns true if the current mail server is a Graph API server.
		/// </summary>
		private bool GetIsGraphApi() {
			if (_isGraphApi.HasValue) {
				return _isGraphApi.Value;
			}
			var typeId = GetMailServerTypeId();
			_isGraphApi = typeId == ExchangeConsts.GraphApiMailServerTypeId;
			return _isGraphApi.Value;
		}

		/// <summary>
		/// Retrieves the unique identifier of the mail server type associated with the current configuration.
		/// </summary>
		private Guid GetMailServerTypeId() {
			if (State.TryGetValue("MailServerId", out var mailServerIdString) &&
			    Guid.TryParse(mailServerIdString as string, out var mailServerId)) {
				var mailServerService = ClassFactory.Get<IMailServerService>(new ConstructorArgument("uc", UserConnection));
				var mailServer = mailServerService.GetServer(mailServerId);
				return mailServer.TypeId;
			}

			var select = (Select) new Select(UserConnection)
				.Column("Id")
				.Column("TypeId")
				.From("MailServer")
				.Where("OAuthApplicationId").IsEqual(Column.Parameter(ApplicationId));
			using (var dbExecutor = UserConnection.EnsureDBConnection()) {
				using (var reader = select.ExecuteReader(dbExecutor))
				{
					if (!reader.Read()) {
						return Guid.Empty;
					}
					var typeId = reader.GetColumnValue<Guid>("TypeId");
					if (!reader.Read()) {
						return typeId;
					}
					Log.WarnFormat("More than one mail server found for OAuthApplicationId {0}", ApplicationId);
					return Guid.Empty;
				}
			}
		}

		/// <summary>
		/// Creates a new <see cref="Terrasoft.Configuration.ContactSyncSettings"/> record
		/// for the specific <see cref="Terrasoft.Configuration.MailboxSyncSettings"/> identifier.
		/// </summary>
		/// <param name="mailboxId"><see cref="Terrasoft.Configuration.MailboxSyncSettings"/> identifier.</param>
		private void CreateNewContactSyncSettings(Guid mailboxId) {
			EntitySchema entitySchema = UserConnection.EntitySchemaManager.GetInstanceByName("ContactSyncSettings");
			Entity contact = entitySchema.CreateEntity(UserConnection);
			contact.SetDefColumnValues();
			contact.SetColumnValue("MailboxSyncSettingsId", mailboxId);
			contact.SetColumnValue("ExportContactsAll", true);
			contact.SetColumnValue("ImportContactsAll", true);
			contact.Save();
		}

		/// <summary>
		/// Creates a new <see cref="Terrasoft.Configuration.ActivitySyncSettings"/> record
		/// for the specific <see cref="Terrasoft.Configuration.MailboxSyncSettings"/> identifier.
		/// </summary>
		/// <param name="mailboxId"><see cref="Terrasoft.Configuration.MailboxSyncSettings"/> identifier.</param>
		private void CreateNewActivitySyncSettings(Guid mailboxId) {
			EntitySchema entitySchema = UserConnection.EntitySchemaManager.GetInstanceByName("ActivitySyncSettings");
			Entity activity = entitySchema.CreateEntity(UserConnection);
			activity.SetDefColumnValues();
			activity.SetColumnValue("MailboxSyncSettingsId", mailboxId);
			activity.SetColumnValue("ImportAppointmentsAll", true);
			activity.SetColumnValue("ImportTasksAll", true);
			activity.SetColumnValue("ExportActivitiesAll", true);
			activity.Save();
		}

		/// <summary>
		/// Parses claim part from <paramref name="jwtToken"/> token.
		/// </summary>
		/// <param name="jwtToken"><see ref="https://tools.ietf.org/html/rfc7519">Jwt token</see>.</param>
		/// <returns>Claim part string of <paramref name="jwtToken"/>.</returns>
		private string GetClaimStringFromToken(string jwtToken) {
			string result = jwtToken.Split(new char[] { '.' })[1];
			int mod4 = result.Length % 4;
			if (mod4 > 0) {
				result += new string('=', 4 - mod4);
			}
			result = result.Replace('-', '+').Replace('_', '/');
			return Encoding.UTF8.GetString(Convert.FromBase64String(result));
		}

		/// <summary>
		/// Sets service account login to mail server in case current flow is used for service account.
		/// </summary>
		/// <param name="serviceAccountLogin">Service account login.</param>
		private void UpdateMailServerServiceAccount(string serviceAccountLogin) {
			EntitySchema entitySchema = UserConnection.EntitySchemaManager.GetInstanceByName("MailServer");
			Entity mailServer = entitySchema.CreateEntity(UserConnection);
			if (mailServer.FetchFromDB(new Guid((string)State["MailServerId"]), false)) {
				mailServer.SetColumnValue("ServiceAccountLogin", serviceAccountLogin);
				mailServer.Save();
			}
		}

		/// <summary>
		/// Updates the username of the <see cref="Terrasoft.Configuration.MailboxSyncSettings"/> record.
		/// </summary>
		private void UpdateMailboxSyncSettingsUserName(Guid mailboxId) {
			var userName = IsGraphApi && _userId.IsNotNullOrEmpty() ? _userId : _userMailboxName;
			EntitySchema mailboxSchema = UserConnection.EntitySchemaManager.GetInstanceByName("MailboxSyncSettings");
			Entity mailbox = mailboxSchema.CreateEntity(UserConnection);
			if (mailbox.FetchFromDB(mailboxId) && mailbox.GetTypedColumnValue<string>("UserName") != userName) {
				mailbox.SetColumnValue("UserName", userName);
				mailbox.Save();
			}
		}

		private CredentialsValidationInfo ValidateMailbox(OAuthUserCredentials credentials) {
			var currentUser = UserConnection.CurrentUser;
			var mailServerService = ClassFactory.Get<IMailServerService>(new ConstructorArgument("uc", UserConnection));
			var mailServer = mailServerService.GetServer(Guid.Parse((string)State["MailServerId"]));
			var mailbox = new Mailbox(credentials.UserLogin, mailServer);
			mailbox.SetOwner(currentUser.Name, currentUser.Id, currentUser.ContactName);
			mailbox.SetOauthToken(credentials.UserLogin, credentials.AccessToken);
			mailbox.SetAllowSynchronization(true);
			mailbox.SetAllowEmailSend(false);
			return mailbox.Validate(UserConnection);
		}

		private static string GetGraphUserNameFromValidationData(string validationData) {
			if (validationData.IsNullOrEmpty()) {
				return string.Empty;
			}
			try {
				var validationPayload = JObject.Parse(validationData);
				return validationPayload.Value<string>("UserName") ?? string.Empty;
			} catch {
				return string.Empty;
			}
		}

		protected virtual string GetGraphUserId(string response, CredentialsValidationInfo validationInfo) {
			if (validationInfo?.IsValid == true) {
				string validatedUserName = GetGraphUserNameFromValidationData(validationInfo.Data);
				if (validatedUserName.IsNotNullOrEmpty()) {
					return validatedUserName;
				}
			}
			return GetOidFromToken(response);
		}

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Called at the end of the authorization process.
		/// Creates transaction for write to the DB needed user data.
		/// </summary>
		/// <param name="userLogin">OAuth application user login.</param>
		/// <param name="tokenStorageId">Created token storage identifier.</param>
		protected override void PostprocessAuthentication(string userLogin, Guid tokenStorageId) {
			if (UseAsServiceAccount) {
				UpdateMailServerServiceAccount(userLogin);
				return;
			}
			using (DBExecutor dbExecutor = UserConnection.EnsureDBConnection()) {
				dbExecutor.StartTransaction();
				try {
					var mailboxId = CreateNewMailboxSyncSettings(userLogin, tokenStorageId);
					CreateNewContactCommunications(userLogin);
					CreateNewContactSyncSettings(mailboxId);
					CreateNewActivitySyncSettings(mailboxId);
					dbExecutor.CommitTransaction();
				} catch {
					dbExecutor.RollbackTransaction();
					throw;
				}
			}
		}

		/// <inheritdoc/>
		protected override void ProcessSavingCredentialsFinish(Guid tokenStorageId) {
			base.ProcessSavingCredentialsFinish(tokenStorageId);

			if (!MailboxSyncSettingsId.IsNotEmpty()) {
				return;
			}

			UpdateMailboxSyncSettingsUserName(MailboxSyncSettingsId);
		}

		/// <summary>
		/// Gets a claim value from a JWT token in the OAuth response.
		/// </summary>
		/// <param name="rawOauthToken">Base64 OAuth response string.</param>
		/// <param name="tokenFieldName">Field name in the response data containing the JWT token (e.g., "id_token" or "access_token").</param>
		/// <param name="claimFieldName">Claim field name in the JWT token.</param>
		/// <returns>The claim value if the token and claim are present, <c>string.Empty</c> otherwise.</returns>
		private string GetClaimFromToken(string rawOauthToken, string tokenFieldName, string claimFieldName) {
			JObject responseData = JObject.Parse(rawOauthToken);
			if (responseData[tokenFieldName] != null) {
				string jwtToken = responseData[tokenFieldName].Value<string>();
				string rawClaim = GetClaimStringFromToken(jwtToken);
				JObject claim = JObject.Parse(rawClaim);
				return claim[claimFieldName]?.Value<string>() ?? string.Empty;
			}
			return string.Empty;
		}

		/// <summary>
		/// Parse user name from <see ref="https://blogs.msdn.microsoft.com/exchangedev/2014/03/25/using-oauth2-to-access-calendar-contact-and-mail-api-in-office-365-exchange-online/">id_token</see>.
		/// Id_token property contains user data claim described in <see ref="https://tools.ietf.org/html/rfc7519">standart</see>.
		/// Unique_name claim field used as user email.
		/// </summary>
		/// <param name="rawOauthToken">Base64 OAuth response string.</param>
		/// <returns>User email if id_token valid, <c>string.Empty</c> otherwise.</returns>
		protected virtual string GetUserNameFromToken(string rawOauthToken) {
			var result = GetClaimFromToken(rawOauthToken, "id_token", "unique_name");

			if (result.IsNullOrEmpty()) {
				result = GetClaimFromToken(rawOauthToken, "access_token", "upn");
			}

			return result;
		}

		/// <summary>
		/// Parse oid from <c>access_token</c>.
		/// </summary>
		/// <param name="rawOauthToken">Base64 OAuth response string.</param>
		/// <returns>User oid if access_token valid, <c>string.Empty</c> otherwise.</returns>
		protected virtual string GetOidFromToken(string rawOauthToken) {
			return GetClaimFromToken(rawOauthToken, "access_token", "oid");
		}

		/// <inheritdoc cref="OAuthAuthenticator.GetOAuthUserCredentials"/>
		protected override OAuthUserCredentials GetOAuthUserCredentials(string response) {
			OAuthUserCredentials result = base.GetOAuthUserCredentials(response);
			string userName = GetUserNameFromToken(response);
			CredentialsValidationInfo validationInfo = null;
			if (IsGraphApi && !UseAsServiceAccount) {
				validationInfo = ValidateMailbox(result);
			}
			if (UseAsServiceAccount ||
				(userName.IsNotNullOrEmpty() && userName != result.UserLogin &&
					!(IsGraphApi ? validationInfo?.IsValid ?? false : HasAccessToMailbox(result)))) {
				result.UserLogin = userName;
				if (IsGraphApi && !UseAsServiceAccount) {
					validationInfo = ValidateMailbox(result);
				}
			}
			_userId = string.Empty;
			if (IsGraphApi) {
				_userId = GetGraphUserId(response, validationInfo);
			}
			_userMailboxName = result.UserLogin;
			return result;
		}

		/// <inheritdoc cref="BaseOAuthAuthenticator.ProcessAuthenticationCode"/>
		public override void ProcessAuthenticationCode() {
			var queryString = Request.QueryString;
			var state = GetDeserializedState(queryString["state"]);
			if (state.ContainsKey("UseAsServiceAccount")) {
				UseAsServiceAccount = (bool)state["UseAsServiceAccount"];
			}
			base.ProcessAuthenticationCode();
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Authentications user in the specific OAuth application.
		/// </summary>
		/// <param name="userLogin">User login to the application.</param>
		/// <param name="mailServerId">Mail server unique identifier.</param>
		public override string AuthenticateUser(string userLogin, Guid mailServerId) {
			if (Features.GetIsEnabled("OAuthPromptConsent")) {
				AditionalUrlParams.Add("prompt", "consent");
			}
			return base.AuthenticateUser(userLogin, mailServerId);
		}

		#endregion

	}
}

