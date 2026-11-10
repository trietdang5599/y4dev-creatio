namespace Terrasoft.Configuration.Omnichannel.Messaging
{
	using System;
	using Terrasoft.Core;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.Factories;

	#region Class: OperatorLogoutEventHandler

	/// <summary>
	/// Set operator state on user logout.
	/// </summary>
	/// <seealso cref="ILogoutEventHandler"/>.
	[DefaultBinding(typeof(ILogoutEventHandler), Name = "OperatorLogoutEventHandler")]
	public class OperatorLogoutEventHandler : ILogoutEventHandler
	{

		#region Methods: Private

		private bool HasMultipleActiveSessions(UserConnection userConnection) {
			var select = new Select(userConnection)
				.Top(2)
				.Column("Id")
				.From("SysUserSession")
				.Where("SysUserId").IsEqual(Column.Parameter(userConnection.CurrentUser.Id))
				.And("SessionEndDate").IsNull() as Select;
			int count = 0;
			using (var dbExecutor = userConnection.EnsureDBConnection()) {
				using (var reader = select.ExecuteReader(dbExecutor)) {
					while (reader.Read()) {
						count++;
					}
				}
			}
			return count > 1;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Changes operator state to inactive.
		/// </summary>
		/// <param name="userConnection">User connection.</param>
		/// <param name="currentUserId">Current user identifier.</param>
		public virtual void SetOperatorInactive(UserConnection userConnection, Guid currentUserId) {
			var operatorManager = new OperatorManager(userConnection);
			operatorManager.ChangeOperatorState(currentUserId, OmnichannelMessagingConsts.OperatorState.Inactive.Code);
		}

		/// <inheritdoc cref="ILogoutEventHandler.HandleEvent(UserConnection)"/>
		public void HandleEvent(UserConnection uc) {
			var currentUserId = uc.CurrentUser.Id;
			if (HasMultipleActiveSessions(uc)) {
				return;
			}
			SetOperatorInactive(uc, currentUserId);
		}

		#endregion

	}

	#endregion

}

