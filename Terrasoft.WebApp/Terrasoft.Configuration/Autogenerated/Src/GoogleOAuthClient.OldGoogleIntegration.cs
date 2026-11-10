namespace Terrasoft.Configuration
{
	using Terrasoft.Core;
	using Terrasoft.Core.Factories;
	using Terrasoft.Social.OAuth;

	/// <summary>
	/// Represents an Google OAuth client.
	/// </summary>
	[DefaultBinding(typeof(OAuthClient), Name = "GoogleOAuthClient")]
	public class GoogleOAuthClient : OAuthClient
	{
		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="userLogin"></param>
		public GoogleOAuthClient(string userLogin, UserConnection userConnection) 
			: base(userLogin, userConnection) {
		}

		/// <summary>
		/// Returns authenticator for the Google OAuth client.
		/// </summary>
		/// <returns><see cref="Terrasoft.Social.OAuth.IOAuthAuthenticator"/> instance.</returns>
		protected override IOAuthAuthenticator GetAuthenticator(UserConnection userConnection) {
			return new GoogleOAuthAuthenticator(userConnection);
		}
	}
}

