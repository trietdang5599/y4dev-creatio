namespace Terrasoft.Configuration
{
	using Creatio.FeatureToggling;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.DB;
	using Terrasoft.Social.Google;
	using Terrasoft.Social.OAuth;

	#region Class: BaseGoogleOAuthAuthenticator

	/// <summary>
	/// Represents an base Google OAuth authenticator.
	/// </summary>
	public class BaseGoogleOAuthAuthenticator : BaseOAuthAuthenticator
	{

		#region Constructors: Public

		/// <summary><see cref="OAuthAuthenticator(UserConnection)"/></summary>
		public BaseGoogleOAuthAuthenticator(UserConnection userConnection) : base(userConnection) {
		}

		/// <summary><see cref="OAuthAuthenticator()"/></summary>
		public BaseGoogleOAuthAuthenticator() : base() {
		}

		#endregion

		#region Properties: Protected

		/// <summary>
		/// Google authorization url.
		/// </summary>
		protected override string AuthorizeUrl {
			get {
				return "https://accounts.google.com/o/oauth2/v2/auth";
			}
		}

		/// <summary>
		/// Google token url.
		/// </summary>
		protected override string TokenUrl {
			get {
				return "https://www.googleapis.com/oauth2/v4/token";
			}
		}

		private readonly IEnumerable<string> _scopes = new[] {
			"https://www.googleapis.com/auth/admin.directory.resource.calendar",
			"https://mail.google.com/",
			"https://www.googleapis.com/auth/userinfo.profile",
			"https://www.googleapis.com/auth/userinfo.email"
		};

		/// <summary>
		/// Impersonation permissions granted to the Google client application.
		/// </summary>
		protected override string Scope
		{
			get {
				var scopes = _scopes.ToList();
				if (Features.GetIsEnabled("GoogleMultidomain")) {
					scopes.AddRangeIfNotExists(GoogleConsumer.Scopes);
				}
				if (Features.GetIsEnabled("GoogleContactsSyncEnabled")) {
					scopes.Add("https://www.googleapis.com/auth/contacts");
				}
				return string.Join(" ", scopes);
			}
		}

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Called at the end of the authorization process.
		/// </summary>
		/// <param name="userLogin">OAuth application user login.</param>
		/// <param name="tokenStorageId">Created token storage identifier.</param>
		protected override void PostprocessAuthentication(string userLogin, Guid tokenStorageId) {
			using (DBExecutor dbExecutor = UserConnection.EnsureDBConnection()) {
				dbExecutor.StartTransaction();
				try {
					CreateNewMailboxSyncSettings(userLogin, tokenStorageId);
					CreateNewContactCommunications(userLogin);
					CreateNewSocialAccount();
					dbExecutor.CommitTransaction();
				} catch {
					dbExecutor.RollbackTransaction();
					throw;
				}
			}
		}

		/// <summary>
		/// Returns user email from google, using <see cref="GoogleConsumer.GetUserEmail"/> method.
		/// </summary>
		/// <param name="credentials">User oauth credentials.</param>
		/// <returns>User email from google</returns>
		protected virtual string GetUserEmailFromGoogle(OAuthUserCredentials credentials) {
			return GoogleConsumer.GetUserEmail(credentials.AccessToken);
		}

		/// <summary>
		/// <see cref="OAuthAuthenticator.SaveCredentials"/> 
		/// </summary>
		protected override void SaveCredentials(OAuthUserCredentials credentials) {
			if (!HasAccessToMailbox(credentials)) {
				credentials.UserLogin = GetUserEmailFromGoogle(credentials);
			}
			base.SaveCredentials(credentials);
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Authentications user in the specific OAuth application.
		/// </summary>
		/// <param name="userLogin">User login to the application.</param>
		/// <param name="mailServerId">Mail server unique identifier.</param>
		public override string AuthenticateUser(string userLogin, Guid mailServerId) {
			AditionalUrlParams.Add("prompt", "consent");
			return base.AuthenticateUser(userLogin, mailServerId);
		}

		#endregion

	}

	#endregion

}

