namespace Terrasoft.Configuration.Omnichannel.Messaging
{
	using System;
	using System.Collections.Generic;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.DB;

	#region Class: ChatOperatorLastActivityJob 

	/// <summary>
	/// Job that deactivate inactive operators.
	/// </summary>
	public class ChatOperatorLastActivityJob : IJobExecutor
	{

		#region Methods: Private

		private DateTime GetLastActivityTime(UserConnection userConnection) {
			return DateTime.UtcNow.AddMinutes(-Terrasoft.Core.Configuration.SysSettings.GetValue<int>(userConnection,
				OmnichannelMessagingConsts.Scheduler.OperatorTimeoutJob.LastActivityTimeoutSettingCode,
				OmnichannelMessagingConsts.Scheduler.OperatorTimeoutJob.DefLastActivityOperatorTimeoutInMinutes));
		}

		private Select GetOperatorsSelect(UserConnection userConnection) {
			return (new Select(userConnection)
				.Column("SysUserId")
				.From("OperatorSession")
				.Where("SessionEndDate").IsNull()
				.And("LastActivityDate").IsLessOrEqual(Column.Parameter(GetLastActivityTime(userConnection)))
				.And("OperatorStateId").IsEqual(Column.Parameter(OmnichannelMessagingConsts.OperatorState.Active.Id)) as Select);
		}

		#endregion

		#region Methods: Public

		/// <inheritdoc cref="IJobExecutor.Execute(UserConnection, IDictionary{string, object})"/>
		public void Execute(UserConnection userConnection, IDictionary<string, object> parameters) {
			var users = GetOperatorsSelect(userConnection).ExecuteEnumerable(reader => reader.GetColumnValue<Guid>("SysUserId"));
			var operatorManager = new OperatorManager(userConnection);
			users.ForEach(userId => operatorManager.ChangeOperatorState(userId, OmnichannelMessagingConsts.OperatorState.Inactive.Code));	
		}

		#endregion

	}

	#endregion

}
