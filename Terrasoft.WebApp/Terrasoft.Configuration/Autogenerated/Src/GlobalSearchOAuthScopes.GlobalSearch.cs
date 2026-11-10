namespace Terrasoft.Configuration.GlobalSearch
{
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.GlobalSearch.Interfaces;

	#region Class: GlobalSearchOAuthScopes

	public static class GlobalSearchOAuthScopes
	{

		#region Methods: Public

		/// <summary>
		/// Get appropriate scope depending on the user type.
		/// </summary>
		/// <param name="userConnection">User connection instance.</param>
		public static string GetScopeForCurrentUser(UserConnection userConnection) {
			return userConnection.ExternalAccessId.IsNotEmpty() ? GSScopes.Support : GSScopes.Normal;
		}

		#endregion

	}

	#endregion

}

