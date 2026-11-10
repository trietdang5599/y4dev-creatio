namespace Terrasoft.Configuration.SSP
{
	using System.Security;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.DB;

	#region Class: SspOperationExtensions

	/// <summary>
	/// Class for working with available operations on ssp.
	/// </summary>
	public static class SspOperationExtensions
	{

		/// <summary>
		/// Checks if the user has rights to manage ssp users.
		/// </summary>
		/// <param name="securityEngine">Security engine <see cref="DBSecurityEngine"/></param>
		public static void CheckCanManageSspUsers(this DBSecurityEngine securityEngine) {
			bool canAdministrate = securityEngine.GetCanExecuteOperation("CanManageUsers") ||
				securityEngine.GetCanExecuteOperation("CanAdministratePortalUsers");
			if (!canAdministrate) {
				throw new SecurityException(string.Format(new LocalizableString("Terrasoft.Core",
					"DBSecurityEngine.Exception.CurrentUserCannotExecuteAdminOperation"), "CanAdministratePortalUsers"));
			}
		}
	}

	#endregion

}
