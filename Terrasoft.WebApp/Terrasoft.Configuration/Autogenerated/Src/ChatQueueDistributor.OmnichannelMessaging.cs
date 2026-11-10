namespace Terrasoft.Configuration.Omnichannel.Messaging
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Terrasoft.Core;
	using Terrasoft.Core.Factories;

	#region Class: ChatQueueDistribution
 
	/// <summary>
	/// Represents a mechanism for distributing chats from the queue.
	/// </summary>
	public class ChatQueueDistributor
	{

		#region Fields: Private

		/// <summary>
		/// <see cref="ChatRepository"/> instance.
		/// </summary>
		private readonly ChatRepository _chatRepository;

		/// <summary>
		/// <see cref="OmnichannelChatProvider"/> instance.
		/// </summary>
		private readonly OmnichannelChatProvider _chatProvider;

		#endregion

		#region Constructors: Public

		/// <summary>
		/// .ctor.
		/// </summary>
		/// <param name="userConnection">User connection.</param>
		public ChatQueueDistributor(UserConnection userConnection) {
			_chatRepository = new ChatRepository(userConnection);
			_chatProvider = ClassFactory.Get<OmnichannelChatProvider>(new ConstructorArgument("userConnection", userConnection));
		}

		#endregion

		#region Methods: Private

		private int DistributeChats(Guid chatQueueId, int chatCount, List<Guid> freeChats) {
			var distributedChatsCount = 0;
			foreach (var freeChatId in freeChats) {
				if (!_chatProvider.DistributeChat(freeChatId.ToString(), chatQueueId) || distributedChatsCount == chatCount) {
					break;
				}
				distributedChatsCount++;
			}
			return distributedChatsCount;
		}

		#endregion

		#region Methods: Public		

		/// <summary>
		/// Distribute chats to operators by <paramref name="chatQueueId"/>.
		/// </summary>
		/// <param name="chatQueueId">Chat queue identifier.</param>
		/// <param name="chatCount">Count of chats that must be distributed.</param>
		/// <returns>Count off distributed chats<see cref="int"/></returns>
		public virtual int Distribute(Guid chatQueueId, int chatCount = -1) {
			var freeChats = _chatRepository.GetFreeChatsByQueue(chatQueueId);
			return DistributeChats(chatQueueId, chatCount, freeChats);
		}

		/// <summary>
		/// Distribute after closed chat to operator by queue from <paramref name="chatQueueId"/>.
		/// </summary>
		/// <param name="chatQueueId">Chat queue identifier.</param>
		/// <param name="chatId">Chat identifier to skip.</param>
		/// <param name="chatCount">Count of chats that must be distributed.</param>
		public virtual void DistributeAfterClosedChat(Guid chatQueueId, Guid chatId, int chatCount = -1) {
			var freeChats = _chatRepository.GetFreeChatsByQueue(chatQueueId);
			var chatsToDistribute = freeChats.Where(x => !x.Equals(chatId)).ToList();
			DistributeChats(chatQueueId, chatCount, chatsToDistribute);
		}

		/// <summary>
		/// Distribute chats to operators by queue from <paramref name="chatId"/>.
		/// </summary>
		/// <param name="chatId">Chat identifier.</param>
		/// <param name="chatCount">Count of chats that must be distributed.</param>
		public virtual void DistributeQueueChatsByChatId(Guid chatId, int chatCount = -1) {
			var chatQueueId = _chatRepository.GetChatQueueId(chatId);
			Distribute(chatQueueId, chatCount);
		}

		#endregion

	}

	#endregion

}
