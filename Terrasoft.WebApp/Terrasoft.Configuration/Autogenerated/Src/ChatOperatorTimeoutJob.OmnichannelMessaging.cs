namespace Terrasoft.Configuration.Omnichannel.Messaging
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.DB;

	#region Class: ChatOperatorTimeoutJob 

	/// <summary>
	/// Switch chat operators state to inactive.
	/// Called after chat accept timeout.
	/// </summary>
	public class ChatOperatorTimeoutJob : IJobExecutor
	{

		#region Methods: Private

		private bool IsWaitingForResponseChatStatus(UserConnection userConnection, Guid chatId) {
			var statusSelect = (new Select(userConnection).Top(1)
				.Column("StatusId")
				.From("OmniChat")
				.Where("Id").IsEqual(Column.Parameter(chatId)) as Select);
			statusSelect.ExecuteSingleRecord(reader => reader.GetColumnValue<Guid>("StatusId"), out Guid chatStatus);
			return chatStatus == OmnichannelMessagingConsts.WaitingForProcessing;
		}

		#endregion

		#region Methods: Public

		/// <inheritdoc cref="IJobExecutor.Execute(UserConnection, IDictionary{string, object})"/>
		public void Execute(UserConnection userConnection, IDictionary<string, object> parameters) {
			var chatId = (string)parameters["ChatId"];
			if (IsWaitingForResponseChatStatus(userConnection, Guid.Parse(chatId))) {
				var operatorIds = (IEnumerable<Guid>)parameters["OperatorIds"];
				var operatorManager = new OperatorManager(userConnection);
				operatorIds.ForEach(operatorId => {
					operatorManager.ChangeOperatorState(operatorId, OmnichannelMessagingConsts.OperatorState.Inactive.Code);
				});
				var operatorNotifier = new ChatOperatorNotifier(userConnection);
				operatorNotifier.AcceptChatNotify(operatorIds.ToList(), Guid.Parse(chatId));
				var queueId = (Guid)parameters["QueueId"];
				operatorManager.TryReDistributeOperatorChat(chatId, queueId);
			}
		}

		#endregion

	}

	#endregion

}
