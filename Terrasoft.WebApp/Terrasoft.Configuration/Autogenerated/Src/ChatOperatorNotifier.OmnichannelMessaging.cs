namespace Terrasoft.Configuration.Omnichannel.Messaging
{
	using global::Common.Logging;
	using Newtonsoft.Json;
	using OmnichannelProviders.Domain.Entities;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.Scheduler;
	using Terrasoft.Messaging.Common;

	#region Class: ChatOperatorNotifier

	/// <summary>
	/// Notifies to chat operator about actions in chat.
	/// </summary>
	public class ChatOperatorNotifier
	{

		#region Consts: Private

		private const string NewMessageInChatSender = "UnreadMessageInChat";
		private const string NewChatCreated = "NewChatCreated";
		private const string NewIncomingChatSender = "NewIncomingChat";
		private const string UpdateIncomingChatSender = "UpdateIncomingChat";
		private const string UnreadChatsCountSender = "UnreadChatsCount";
		private const string NewConversationMessageSender = "NewConversationMessage";
		private const string CompleteChatMessageSender = "CompleteChat";
		private const string OperatorStateChangedSender = "OperatorStateChanged";
		private const string AcceptChatMessageSender = "AcceptChat";
		private const string NewSystemMessageSender = "NewSystemMessage";
		private const string NewTransferredChatSender = "NewTransferredChat";
		private const string CompleteChatByAgentMessageSender = "CompleteChatByAgent";
		private const string LinkChatToContactSender = "LinkChatToContact";
		private const string MessageDeliveryStatusUpdateSender = "MessageDeliveryStatusUpdate";


		#endregion

		#region Properties: Protected 


		private ChatRepository _chatRepository;
		/// <summary>
		/// Instance of <see cref="ChatRepository"/> class.
		/// </summary>
		protected ChatRepository ChatRepository {
			get {
				return _chatRepository = _chatRepository ?? new ChatRepository(_userConnection);
			}
		}

		private OmnichannelChatProvider _omnichannelChatProvider;
		/// <summary>
		/// Class for working with omnichannel chats<see cref="OmnichannelChatProvider"/> class.
		/// </summary>
		protected OmnichannelChatProvider OmnichannelChatProvider {
			get {
				return _omnichannelChatProvider = _omnichannelChatProvider ?? new OmnichannelChatProvider(_userConnection);
			}
		}

		/// <summary>
		/// <see cref="ILog"/> implementation instance.
		/// </summary>
		private ILog _detailsLogger;
		protected ILog DetailsLogger {
			get {
				return _detailsLogger ?? (_detailsLogger = LogManager.GetLogger("OmnichannelDetails"));
			}
		}

		#endregion

		#region Fields: Private

		private readonly IMsgChannelManager _channelManager = MsgChannelManager.Instance;
		private readonly UserConnection _userConnection;

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Initializes new instance of <see cref="ChatOperatorNotifier"/>.
		/// </summary>
		/// <param name="userConnection">User connection.</param>
		public ChatOperatorNotifier(UserConnection userConnection) {
			_userConnection = userConnection;
		}

		#endregion

		#region Methods: Private

		private IMsg GetChannelMessage(Guid sysAdminUnit, string sender, string data) {
			return new SimpleMessage {
				Id = sysAdminUnit,
				Body = data,
				Header = {
					Sender = sender,
					BodyTypeName = "System.String"
				}
			};
		}

		private Guid GetChatOperator(Guid chatId) {
			Guid operatorId = (new Select(_userConnection)
				.Column("OperatorId")
				.From("OmniChat", "oc")
				.Where("oc", "Id").IsEqual(Column.Parameter(chatId))
				 as Select)
				.ExecuteScalar<Guid>();
			return operatorId != Guid.Empty ? operatorId : GetDefaultOperator();
		}

		private string GetChannelMessageData(object data) {
			return JsonConvert.SerializeObject(data);
		}

		private void Notify(IEnumerable<Guid> users, string sender, object data) {
			try {
				MsgChannelManager msgManager = MsgChannelManager.Instance;
				var message = new SimpleMessage {
					Body = GetChannelMessageData(data),
					Header = {
						Sender = sender,
						BodyTypeName = "System.String"
					}
				};
				msgManager.Post(users, message);
			} catch (InvalidOperationException e) {
				DetailsLogger.Error($"Error while posting WS message to the users: {string.Join(", ", users)}.", e);
			}
		}

		private void Notify(Guid sysAdminUnit, string sender, object data) {
			IMsgChannel channel = _channelManager.FindItemByUId(sysAdminUnit);
			if (channel == null) {
				Console.WriteLine($"Empty channel for '{sysAdminUnit}'");
				return;
			}
			IMsg message =
				GetChannelMessage(sysAdminUnit, sender, GetChannelMessageData(data));
			channel.PostMessage(message);
		}

		private Guid GetDefaultOperator() {
			return _userConnection.AppConnection.SystemUserConnection.CurrentUser.Id;
		}

		private void ExecuteAsyncAcceptChatNotify(List<Guid> operators, Guid chatId) {
			DetailsLogger.DebugFormat($"Creating a job for UnreadChatsCountSender notification for chat [{chatId}]");
			SysUserInfo currentUser = _userConnection.CurrentUser;
			string jobGroup = string.Concat("AsyncAcceptChatNotifier", "_", chatId);
			var parameters = new Dictionary<string, object> {
				{"operators", operators}
			};
			AppScheduler.ScheduleImmediateJob<AsyncAcceptChatNotifierExecutor>(jobGroup, _userConnection.Workspace.Name,
				currentUser.Name, parameters);
			DetailsLogger.DebugFormat($"Job for UnreadChatsCountSender notification was created for chat [{chatId}]");
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Notifies operator about new unread message in chat.
		/// </summary>
		/// <param name="operatorIds">Chat operators identifiers collection.</param>
		/// <param name="chatId">Identifier of chat.</param>
		public virtual void NewUnreadMessageNotify(IEnumerable<Guid> operatorIds, string chatId) {
			var chat = ChatRepository.GetChatsById(new List<Guid> { new Guid(chatId) }).FirstOrDefault();
			if (chat != null) {
				Notify(operatorIds, NewMessageInChatSender, new {
					ChatId = chatId,
					Count = chat.GetTypedColumnValue<int>("UnprocessedMsgCount")
				});
			}
		}

		/// <summary>
		/// Notifies operator about new unread message in chat.
		/// </summary>
		/// <param name="chatId">Identifier of chat.</param>
		/// TODO #SD-6874. Pass operatorId instead of chatId.
		public virtual void NewUnreadMessageNotify(MessagingMessage message) {
			NewUnreadMessageNotify(message.OperatorIds, message.ChatId);
		}

		/// <summary>
		/// Notifies operator about new message in chat.
		/// </summary>
		/// <param name="operatorIds">Chat operators identifiers collection.</param>
		/// <param name="chatId">Identifier of chat.</param>
		public virtual void NewMessageInChatNotify(IEnumerable<Guid> operatorIds, string chatId) {
			Notify(operatorIds, UpdateIncomingChatSender, new {
				ChatId = chatId
			});
		}

		/// <summary>
		/// Notifies operator about new message in chat.
		/// </summary>
		/// <param name="chatId">Identifier of chat.</param>
		/// TODO #SD-6874. Pass operatorId and chatId.
		public virtual void NewMessageInChatNotify(MessagingMessage message) {
			NewMessageInChatNotify(message.OperatorIds, message.ChatId);
		}

		/// <summary>
		/// Notifies operator about new conversation message in chat.
		/// </summary>
		/// <param name="operatorIds">Chat operators identifiers collection.</param>
		/// <param name="chatId">Identifier of chat.</param>
		/// <param name="message"><see cref="ChatMessage"/> instance.</param>
		public virtual void NewConversationMessageNotify(IEnumerable<Guid> operatorIds, string chatId, ChatMessage message) {
			object messageObject = new {
				ChatId = chatId,
				Message = message
			};
			Notify(operatorIds, NewConversationMessageSender, messageObject);
		}

		/// <summary>
		/// Notifies operator about new conversation message in chat.
		/// </summary>
		/// <param name="message">New conversation message.</param>
		/// TODO #SD-6874. Pass operatorId and chatId.
		public virtual void NewConversationMessageNotify(MessagingMessage message) {
			NewConversationMessageNotify(message.OperatorIds, message.ChatId,
				OmnichannelChatProvider.GetChatMessage(message));
		}

		/// <summary>
		/// Notifies operator about new conversation message in chat.
		/// </summary>
		/// <param name="message">New conversation message.</param>
		/// TODO #SD-6874. Pass operatorId and chatId.
		public virtual void NewConversationMessageNotify(UnifiedMessage message) {
			var operatorId = GetChatOperator(Guid.Parse(message.ChatId));
			object messageObject = new {
				message.ChatId,
				Message = OmnichannelChatProvider.GetChatMessage(message)
			};
			Notify(new List<Guid> { operatorId }, NewConversationMessageSender, messageObject);
		}

		/// <summary>
		/// Notifies operator about new incmoming chat.
		/// </summary>
		/// <param name="chatId">Identifier of chat.</param>
		/// TODO #SD-6874. Pass operatorId and chatId.
		public virtual void NewIncomingChatNotify(MessagingMessage message) {
			NewIncomingChatNotify(message.OperatorIds, message.ChatId);
		}

		/// <summary>
		/// Notifies operator about new incmoming chat.
		/// </summary>
		/// <param name="operatorIds">Chat operators identifiers collection.</param>
		/// <param name="chatId">Identifier of chat.</param>
		public virtual void NewIncomingChatNotify(IEnumerable<Guid> operatorIds, string chatId) {
			DetailsLogger.Debug($"New incoming chat {chatId} notification will be sent to operators: {string.Join(", ", operatorIds)}.");
			Notify(operatorIds, NewIncomingChatSender, new {
				ChatId = chatId
			});
		}

		/// <summary>
		/// Notifies operator about new created chat.
		/// </summary>
		/// <param name="operatorIds">Chat operators identifiers collection.</param>
		/// <param name="chatId">Identifier of chat.</param>
		public virtual void NewChatCreatedNotify(IEnumerable<Guid> operatorIds, string chatId) {
			Notify(operatorIds, NewChatCreated, new {
				ChatId = chatId
			});
		}

		/// <summary>
		/// Notifies operator about chats with unread messages.
		/// </summary>
		/// <param name="operatorId">Identifier of operator.</param>
		public virtual void UnreadChatsCountNotify(Guid operatorId)	{
			if (_userConnection.GetIsFeatureEnabled("DisableNotifyingAllOperators")) {
				return;
			}
			int msgCount = OmnichannelChatProvider.GetUnreadChatsCount(operatorId);
			Notify(new List<Guid> { operatorId }, UnreadChatsCountSender, new {
				Count = msgCount
			});
		}

		/// <summary>
		/// Notifies operator about chats with unread messages.
		/// </summary>
		/// <param name="message">Unified message.</param>
		public virtual void UnreadChatsCountNotify(MessagingMessage message) {
			UnreadChatsCountNotify(message.OperatorIds);
		}

		/// <summary>
		/// Notifies operator about chats with unread messages.
		/// </summary>
		/// <param name="message">Unified message.</param>
		/// <param name="operatorIds">Chat operators identifiers collection.</param>
		public virtual void UnreadChatsCountNotify(IEnumerable<Guid> operatorIds) {
			foreach (var operatorId in operatorIds) {
				UnreadChatsCountNotify(operatorId);
			}
		}

		/// <summary>
		/// Notifies operator about completed chat.
		/// </summary>
		public virtual void CompleteChatNotify(Guid operatorId, Guid chatId) {
			Notify(new List<Guid> { operatorId }, CompleteChatMessageSender, new {
				ChatId = chatId
			});
		}

		/// <summary>
		/// Notifies operator about completed chat by agent.
		/// </summary>
		public virtual void CompleteChatByAgentNotify(Guid operatorId, Guid chatId) {
			Notify(new List<Guid> { operatorId }, CompleteChatByAgentMessageSender, new {
				ChatId = chatId
			});
		}

		/// <summary>
		/// Notifies operator about server initiates state change.
		/// </summary>
		/// <param name="operatorIds">Chat operators identifiers collection.</param>
		/// <param name="chatId">Identifier of chat.</param>
		public virtual void StatusChangeNotify(Guid operatorId, string stateCode) {
			Notify(new List<Guid> { operatorId }, OperatorStateChangedSender, new {
				StateCode = stateCode
			});
		}

		/// <summary>
		/// Notifies operator about new system message.
		/// </summary>
		/// <param name="operatorId">Operator to notifer.</param>
		/// <param name="chatId">Chat identifier.</param>
		/// <param name="message">System message.</param>
		public virtual void NewSystemMessageNotify(Guid operatorId, Guid chatId, ChatMessage message) {
			object messageObject = new {
				ChatId = chatId,
				Message = message
			};
			Notify(new List<Guid> { operatorId }, NewSystemMessageSender, messageObject);
		}

		/// <summary>
		/// Notifies operators about accepted chat.
		/// </summary>
		/// <param name="operators">List of operators.</param>
		/// <param name="chatId">Chat identifier.</param>
		public virtual void AcceptChatNotify(List<Guid> operators, Guid chatId) {
			UnreadChatsCountNotify(operators);
			Notify(operators, AcceptChatMessageSender, new {
				ChatId = chatId
			});
		}

		/// <summary>
		/// Notifies operators about accepted chat asynchronously.
		/// </summary>
		/// <param name="operators">List of operators.</param>
		/// <param name="chatId">Chat identifier.</param>
		public virtual void AcceptChatNotifyAsync(List<Guid> operators, Guid chatId, Guid? chatOperator = null) {
			DetailsLogger.DebugFormat($"Sending AcceptChatMessageSender notification of chat [{chatId}] to the following operators [{string.Join(", ", operators.ToArray())}]");
			object notifyParams;
			if (chatOperator.HasValue) {
				notifyParams = new {
					ChatId = chatId,
					OperatorId = chatOperator.Value
				};
			} else {
				notifyParams = new {
					ChatId = chatId
				};
			}
			Notify(operators, AcceptChatMessageSender, notifyParams);
			DetailsLogger.DebugFormat($"AcceptChatMessageSender notification of chat [{chatId}] was sent to the operators");
			ExecuteAsyncAcceptChatNotify(operators, chatId);
		}

		/// <summary>
		/// Notifies operator about new transferring chat.
		/// </summary>
		/// <param name="operatorId">Operator to notify.</param>
		/// <param name="chatId">Identifier of chat.</param>
		public virtual void NewTransferredChatNotify(Guid operatorId, Guid chatId) {
			Notify(new List<Guid> { operatorId }, NewTransferredChatSender, new {
				ChatId = chatId
			});
		}

		/// <summary>
		/// Notifies operator about chat linked to contact.
		/// </summary>
		/// <param name="operatorId">Operator to notify.</param>
		/// <param name="chatId">Chat identifier.</param>
		public virtual void LinkChatToContactNotify(Guid operatorId, Guid chatId) {
			Notify(new List<Guid> { operatorId }, LinkChatToContactSender, new {
				ChatId = chatId
			});
		}

		/// <summary>
		/// Notifies operator about message delivery status change.
		/// </summary>
		/// <param name="operatorId">Operator to notify.</param>
		/// <param name="messageId">Identifier of message with updated delivery status.</param>
		/// <param name="status">Updated message delivery status.</param>
		/// <param name="deliveryError">Updated message delivery error.</param>
		public virtual void MessageDeliveryStatusChangedNotify(Guid operatorId, Guid messageId,
				MessageDeliveryStatus? status, MessageDeliveryError? deliveryError) {
			Notify(new List<Guid> { operatorId }, MessageDeliveryStatusUpdateSender, new {
				MessageId = messageId,
				Status = status,
				DeliveryError = deliveryError.HasValue ? (int)deliveryError.Value : 0
			});
		}

		#endregion

	}

	#endregion

}

