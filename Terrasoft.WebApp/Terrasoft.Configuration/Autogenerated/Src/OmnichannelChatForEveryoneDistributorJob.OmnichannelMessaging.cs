namespace Terrasoft.Configuration.Omnichannel.Messaging
{
	using System;
	using System.Collections.Generic;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.DB;

	#region Class: OmnichannelChatForFreeDistributorJob 

	/// <summary>
	/// Job that redistribute previously distributed chats.
	/// </summary>
	public class OmnichannelChatForFreeDistributorJob : IJobExecutor
	{

		#region Methods: Private

		private DateTime GetTimeToTakeChat(UserConnection userConnection) {
			return DateTime.UtcNow.AddMinutes(-Terrasoft.Core.Configuration.SysSettings.GetValue<int>(userConnection,
				OmnichannelMessagingConsts.Scheduler.OperatorTimeoutJob.TimeoutSettingCode,
				OmnichannelMessagingConsts.Scheduler.OperatorTimeoutJob.DefOperatorTimeoutInMinutes));
		}

		private void RedistributeChats(UserConnection userConnection) {
			Select selectChat = GetChatsSelect(userConnection);
			var operatorManager = new OperatorManager(userConnection);
			selectChat.ExecuteReader(dataReader => {
				var chatId = dataReader.GetColumnValue<Guid>("Id");
				var queueId = dataReader.GetColumnValue<Guid>("QueueId");
				var operatorId = dataReader.GetColumnValue<Guid>("DirectedOperatorId");
				operatorManager.ChangeOperatorState(operatorId, OmnichannelMessagingConsts.OperatorState.Inactive.Code);
				var operatorNotifier = new ChatOperatorNotifier(userConnection);
				operatorNotifier.AcceptChatNotify(new List<Guid> { operatorId }, chatId);
				operatorManager.TryReDistributeOperatorChat(chatId.ToString(), queueId);
			});
		}

		private Select GetChatsSelect(UserConnection userConnection) {
			return (new Select(userConnection)
				.Column("Id")
				.Column("StatusId")
				.Column("DirectedOperatorId")
				.Column("QueueId")
				.From("OmniChat")
				.Where("StatusId").IsEqual(Column.Parameter(OmnichannelMessagingConsts.WaitingForProcessing))
				.And("DirectedOperatorId").Not().IsNull()
				.And("ModifiedOn").IsLessOrEqual(Column.Parameter(GetTimeToTakeChat(userConnection))) as Select);
		}

		#endregion

		#region Methods: Public

		/// <inheritdoc cref="IJobExecutor.Execute(UserConnection, IDictionary{string, object})"/>
		public void Execute(UserConnection userConnection, IDictionary<string, object> parameters) {
			RedistributeChats(userConnection);
		}

		#endregion

	}

	#endregion

}  
