namespace Terrasoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using Terrasoft.Common;
	using Terrasoft.Configuration.Omnichannel.Messaging;
	using Terrasoft.Core;
	using Terrasoft.Core.Factories;

	/// <summary>
	/// Represents functionality of transferring chat to queue.
	/// </summary>
	public class TransferChatToQueueProvider : BaseChatTransferProvider
	{		

		#region Methods: Private

		private string GetLczTextMessage(Guid chatId, Guid newChatId) {
			(string operatorName, string queueName) = OmnichannelChatProvider.GetOperatorAndQueueNameByChatId(chatId, newChatId);
			return string.Format(new LocalizableString(UserConnection.Workspace.ResourceStorage, "ChatTransferService",
				"LocalizableStrings.ChatTransferred.Value"), operatorName, queueName);
		}

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Initializes new instance of <see cref="TransferChatToQueueProvider"/>
		/// </summary>
		/// <param name="userConnection">User connection.</param>
		/// <param name="message">Message template to be published.</param>
		public TransferChatToQueueProvider(UserConnection userConnection, MessagingMessage message) : base(userConnection, message) {
		}

		#endregion

		#region Methods: Private

		private void PublishSystemMessage(Guid queueId, MessagingMessage systemMessage) {
			Guid currentOperatorId = ChatRepository.GetOperatorIdByChatId(ChatId);
			Guid operatorContactId = GetContactIdFromOperator(currentOperatorId);
			var metadata = ClassFactory.Get<IChatMessageMetadata<ChatTransferToQueueData>>("ChatTransferToQueueMetadata");
			string messageMetadata = metadata.Generate(new ChatTransferToQueueData { ToQueueId = queueId, FromOperatorId = operatorContactId, TransferDate = DateTime.UtcNow });
			Manager.AddSystemMessage(systemMessage, messageMetadata, MessageMacrosConsts.ChatTransferredToQueue);
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Transfers chat to queue.
		/// </summary>
		/// <param name="queueId">Identifier of queue.</param>
		/// <returns>Result of chat transferring and new chat identifier.</returns>
		public (bool, Guid) Transfer(Guid queueId) {
			if (!ChatQueueRepository.IsQueueExists(queueId)) {
				Log.Error($"Can't set queue for chat with id={ChatId}. Queue {queueId} doesn't exist");
				return (false, Guid.Empty);
			}
			Guid newChatId = ChatRepository.CreateChildChat(ChatId, new Dictionary<string, object> {
				{ "QueueId", queueId },
				{ "UnprocessedMsgCount", 1 },
				{ "StatusId", OmnichannelMessagingConsts.WaitingForProcessing }
			});
			if (newChatId == Guid.Empty) {
				return (false, newChatId);
			}
			try {
				string message = GetLczTextMessage(ChatId, newChatId);
				var systemMessage = GetSystemMessage(message);
				ChatRepository.AddMessage(systemMessage, out _);
				PublishSystemMessage(queueId, systemMessage);
				ChatRepository.CloseTransferringChat(ChatId, newChatId);
				SetChatPreview(newChatId, message);
				ChatQueueDistributor.Distribute(queueId);
				Notifier.NewSystemMessageNotify(UserConnection.CurrentUser.Id, ChatId, GetChatSystemMessage(systemMessage));
			} catch (Exception ex) {
				Log.Error($"An error occurred while transferring Chat {ChatId} to Queue {queueId}. Error {ex.Message}");
				return (false, newChatId);
			}
			Log.Debug($"Chat: {ChatId} was transferred to Queue {queueId}.");
			return (true, newChatId);
		}

		#endregion

	}

}

