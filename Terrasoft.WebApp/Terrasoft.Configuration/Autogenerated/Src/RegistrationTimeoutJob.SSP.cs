namespace Terrasoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using Terrasoft.Core;
	using Terrasoft.Core.DB;

	#region Class: RegistrationTimeoutJob 

	/// <summary>
	/// Deletes expired registration or password recovery links.
	/// </summary>
	public class RegistrationTimeoutJob : IJobExecutor
	{

		#region Methods: Private

		private void DeleteExpiredLinks(UserConnection userConnection) {
			DateTime currentDateTime = userConnection.CurrentUser.GetCurrentDateTime();
			var delete =
				new Delete(userConnection)
				.From("SysRegistrationData")
				.Where("LinkExpireDate").IsLess(Column.Parameter(currentDateTime));
			delete.Execute();
		}

		#endregion

		#region Methods: Public

		/// <inheritdoc cref="IJobExecutor.Execute(UserConnection, IDictionary{string, object})"/>
		public void Execute(UserConnection userConnection, IDictionary<string, object> parameters) {
			DeleteExpiredLinks(userConnection);
		}

		#endregion

	}

	#endregion

}
