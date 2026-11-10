namespace Terrasoft.Configuration.Omnichannel.Messaging
{
	using global::Common.Logging;
	using Newtonsoft.Json;
	using OmnichannelMessaging;
	using OmnichannelProviders.Domain.Entities;
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Diagnostics;
	using System.Linq;
	using Terrasoft.Common;
	using Terrasoft.Configuration.Translating;
	using Terrasoft.Core;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Factories;
	using Terrasoft.Core.Store;
	using OmnichannelDirection = OmnichannelProviders.Domain.Entities;
	using SystemSettings = Terrasoft.Core.Configuration.SysSettings;

	#region Interface: IChatRepository

	/// <summary>
	/// Interface for repository for working with chats.
	/// </summary>
	public interface IChatRepository
	{

		/// <summary>
		/// Adds message to chat.
		/// </summary>
		/// <param name="message">Messaging message which will be added to chat.</param>
		/// <param name="isNewChat">Flag indicating if this is a new chat.</param>
		/// <returns>Identifier of chat.</returns>
		Guid AddMessage(MessagingMessage message, out bool isNewChat);

		/// <summary>
		/// Adds outcoming message to chat.
		/// </summary>
		/// <param name="message">Messaging message which will be added to chat.</param>
		/// <returns><see cref="GetLastChatResponse"/> instance.</returns>
		GetLastChatResponse AddOutcomingMessage(MessagingMessage message);

		/// <summary>
		/// Close OmnichannelChat when it is time.
		/// </summary>
		void CloseExpiredChats();

		/// <summary>
		/// Check if chat has closed by bot parent chat in hierarchy.
		/// </summary>
		/// <param name="chatId">Chat identifier.</param>
		/// <returns><c>true</c> if element in hierarchy</returns>
		bool IsParentBotChatExists(Guid chatId);

		/// <summary>
		/// Close active chat.
		/// </summary>
		/// <param name="chatId">Chat identifier.</param>
		/// <param name="createSystemMessage">Flag to create system message.</param>
		/// <param name="hasChildChat">Flag indicating if chat has child chat.</param>
		/// <param name="closureReasonId">Closure reason identifier.</param>
		void CloseActiveChat(Guid chatId, bool createSystemMessage = false, bool hasChildChat = false, Guid closureReasonId = default);

		/// <summary>
		/// Close active chat by end user.
		/// </summary>
		/// <param name="chatId">Chat identifier.</param>
		void CloseActiveChatByEndUser(Guid chatId);

		/// <summary>
		/// Close chat which is transferring.
		/// </summary>
		/// <param name="chatId">Chat identifier.</param>
		/// <param name="chatIdToSkip">Chat identifier to skip.</param>
		void CloseTransferringChat(Guid chatId, Guid chatIdToSkip);

		/// <summary>
		/// Get a collection of active chats by operator identifier.
		/// </summary>
		/// <param name="operatorId">Operator identifier.</param>
		/// <param name="applyColumns">Flag to apply columns.</param>
		/// <returns><see cref="EntityCollection"/> collection of operators chats.</returns>
		EntityCollection GetChatsByOperator(Guid operatorId, bool applyColumns = true);

		/// <summary>
		/// Get a collection of possible operator chats by identifiers.
		/// </summary>
		/// <param name="ids">Collection of IDs of distributed operator omnichats.</param>
		/// <param name="applyColumns">Flag to apply columns.</param>
		/// <returns><see cref="EntityCollection"/> collection of chats.</returns>
		EntityCollection GetChatsById(List<Guid> ids, bool applyColumns = true);

		/// <summary>
		/// Loads <paramref name="chatOperator"/> fields from database.
		/// </summary>
		/// <param name="chatOperator"><see cref="ChatOperator"/> instance.</param>
		void LoadOperatorState(ChatOperator chatOperator);

		/// <summary>
		/// Loads multiple operators' state from database.
		/// </summary>
		/// <param name="chatOperators">Collection of <see cref="ChatOperator"/> instances.</param>
		void LoadOperatorsState(IEnumerable<ChatOperator> chatOperators);

		/// <summary>
		/// Get chat queue identifier by chat identifier.
		/// </summary>
		/// <param name="chatId">Chat identifier.</param>
		/// <returns>Chat queue identifier.</returns>
		Guid GetChatQueueId(Guid chatId);

		/// <summary>
		/// Gets channel queue identifier by chat identifier.
		/// </summary>
		/// <param name="chatId">Chat identifier.</param>
		/// <returns>Chat channel queue identifier.</returns>
		Guid GetChatChannelQueueId(Guid chatId);

		/// <summary>
		/// Get chat queue identifier by channel identifier.
		/// </summary>
		/// <param name="channelId">Channel identifier.</param>
		/// <returns>Chat queue identifier.</returns>
		Guid GetChatQueueIdFromChannel(Guid channelId);

		/// <summary>
		/// Get free chats by chat queue identifier.
		/// </summary>
		/// <param name="chatQueueId">Chat queue identifier.</param>
		/// <returns>Free chat identifier by chat queue ID.</returns>
		List<Guid> GetFreeChatsByQueue(Guid chatQueueId);

		/// <summary>
		/// Set chat status.
		/// </summary>
		/// <param name="chatId">Chat identifier.</param>
		/// <param name="chatStatus">Chat status identifier.</param>
		void SetChatStatus(Guid chatId, Guid chatStatus);

		/// <summary>
		/// Mark all chat messages as processed.
		/// </summary>
		/// <param name="chatId">Id of chat.</param>
		void MarkChatAsRead(Guid chatId);

		/// <summary>
		/// Returns identifiers of related chats by the given chat identifier.
		/// </summary>
		/// <param name="chatId">Identifier of primary chat.</param>
		/// <returns>List of related chats.</returns>
		IEnumerable<Guid> GetRelatedChatsId(Guid chatId);

		/// <summary>
		/// Returns conversation by chat identifier.
		/// </summary>
		/// <param name="chatId">Identifier of chat.</param>
		/// <returns>Chat conversation.</returns>
		IEnumerable<UnifiedMessage> GetChatConversation(Guid chatId);

		/// <summary>
		/// Create child chat for chat with specified Id.
		/// </summary>
		/// <param name="parentChatId">Id of parent chat.</param>
		/// <param name="additionalColumns">Additional columns to set.</param>
		/// <returns>Identifier of created child chat.</returns>
		Guid CreateChildChat(Guid parentChatId, Dictionary<string, object> additionalColumns = default);

		/// <summary>
		/// Detects the conversation language from the source chat's end-user messages and,
		/// when chat translation is enabled, sets it on the target chat. No-op when the
		/// <c>EnableChatTranslation</c> setting is off or no end-user text is available.
		/// </summary>
		/// <param name="sourceChatId">Chat whose end-user (incoming) messages are analyzed.</param>
		/// <param name="targetChatId">Chat whose <c>LanguageId</c> is updated.</param>
		void DetectAndSetChatLanguage(Guid sourceChatId, Guid targetChatId);

		/// <summary>
		/// Get chats with bot by channel and sender identifiers.
		/// </summary>
		/// <param name="channelId">Id of channel.</param>
		/// <param name="sender">Sender identifier.</param>
		/// <returns>List of chats guids.</returns>
		List<Guid> GetBotProcessingChatIds(Guid channelId, string sender);

		/// <summary>
		/// Get chats with bot by channel.
		/// </summary>
		/// <param name="channelId">Id of channel.</param>
		/// <returns>List of chats guids.</returns>
		IEnumerable<UnifiedMessage> GetBotProcessingMessages(Guid channelId);

		/// <summary>
		/// Delete unnecessary chats.
		/// </summary>
		/// <param name="chatsId">Identifiers of chats.</param>
		void DeleteUnnecessaryChats(IEnumerable<Guid> chatsId);

		/// <summary>
		/// Returns operator's identifier by chat identifier
		/// </summary>
		/// <param name="chatId">Identifier of chat</param>
		/// <returns>Operator's identifier</returns>
		Guid GetOperatorIdByChatId(Guid chatId);

		/// <summary>
		/// Set close date for chat.
		/// </summary>
		/// <param name="chat">Chat entity.</param>
		void SetCloseDate(Entity chat);
	}

	#endregion

	#region Class: ChatRepository

	/// <summary>
	/// Provides repository for working with chats.
	/// </summary>
	public class ChatRepository : IChatRepository
	{

		#region Constants: Private

		private const int CLOSE_DEAD_CHAT_TIMEOUT_IN_MINUTES = 60;
		private const string FREE_CHATS_BY_QUEUE_CACHE_KEY_MASK = "OmnichannelFreeChatsByQueue_{0}";

		#endregion

		#region Fields: Private

		/// <summary>
		/// <see cref="UserConnection"/> instance.
		/// </summary>
		private readonly UserConnection _userConnection;

		/// <summary>
		/// <see cref="ChatOperatorCache"/> instance.
		/// </summary>
		private readonly ChatOperatorCache _chatOperatorCache;

		/// <summary>
		/// Maximum number of expired chats that can be closed in a single operation.
		/// This limit prevents performance issues when processing large batches.
		/// </summary>
		private readonly int maxChatsToCloseAtOnce = 2000;

		#endregion

		#region Properties: Protected 


		private OpenChatFromContactVerifier _openChatFromContactVerifier;
		/// <summary>
		/// Contact data verifier for chat opening.
		/// </summary>
		protected OpenChatFromContactVerifier OpenChatFromContactVerifier {
			get
			{
				return _openChatFromContactVerifier = _openChatFromContactVerifier ?? new OpenChatFromContactVerifier(_userConnection);
			}
		}

		private TranslateProviderFactory _translateProviderFactory;
		/// <summary>
		/// Factory for creating and managing instances of ITranslateProvider..
		/// </summary>
		protected TranslateProviderFactory TranslateProviderFactory {
			get
			{
				return _translateProviderFactory = _translateProviderFactory ?? new TranslateProviderFactory(_userConnection);
			}
		}

		private MessageManager _messageManager;
		/// <summary>
		/// Class which save and send messages <see cref="MessageManager"/> class.
		/// </summary>
		protected MessageManager MessageManager {
			get
			{
				return _messageManager = _messageManager ?? new MessageManager(_userConnection);
			}
		}

		private ChatQueueRepository _chatQueueRepository;
		/// <summary>
		/// Repository of chats queue.
		/// </summary>
		protected ChatQueueRepository ChatQueueRepository {
			get
			{
				return _chatQueueRepository = _chatQueueRepository ?? new ChatQueueRepository(_userConnection);
			}
		}

		private ChatOperatorNotifier _operatorNotifier;
		/// <summary>
		/// Instance of <see cref="ChatOperatorNotifier"/> class.
		/// </summary>
		protected ChatOperatorNotifier OperatorNotifier {
			get
			{
				return _operatorNotifier = _operatorNotifier ?? new ChatOperatorNotifier(_userConnection);
			}
		}

		private OperatorManager _operatorManager;
		/// <summary>
		/// Instance of <see cref="OperatorManager"/> class.
		/// </summary>
		protected OperatorManager OperatorManager {
			get
			{
				return _operatorManager = _operatorManager ?? new OperatorManager(_userConnection);
			}
		}

		private ChatQueueDistributor _queueDistribution;
		/// <summary>
		/// Distributors of chats queue.
		/// </summary>
		protected ChatQueueDistributor QueueDistribution {
			get
			{
				return _queueDistribution = _queueDistribution ?? new ChatQueueDistributor(_userConnection);
			}
		}

		/// <summary>
		/// <see cref="ILog"/> implementation instance.
		/// </summary>
		private ILog _log;
		protected ILog Log {
			get
			{
				return _log ?? (_log = LogManager.GetLogger("OmnichannelChat"));
			}
		}

		private ILog _translateProviderLog;
		protected ILog TranslateProviderLog {
			get
			{
				return _translateProviderLog ?? (_translateProviderLog = LogManager.GetLogger("TranslateProvider"));
			}
		}

		#endregion

		#region Delegate: Protected

		protected delegate void SetAdditionalColumns(Entity entity);

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Initializes new instance of <see cref="ChatRepository"/>.
		/// </summary>
		/// <param name="userConnection">User connection.</param>
		public ChatRepository(UserConnection userConnection) : this(userConnection, new ChatOperatorCache(userConnection)) {
		}

		/// <summary>
		/// Initializes new instance of <see cref="ChatRepository"/>.
		/// </summary>
		/// <param name="userConnection">User connection.</param>
		/// <param name="cache">Operators cache instance.</param>
		public ChatRepository(UserConnection userConnection, ChatOperatorCache cache) {
			_userConnection = userConnection;
			_chatOperatorCache = cache;
		}

		#endregion

		#region Methods: Private

		private static string GetFreeChatsByQueueCacheKey(Guid chatQueueId) {
			return string.Format(FREE_CHATS_BY_QUEUE_CACHE_KEY_MASK, chatQueueId);
		}

		private static List<Guid> ApplyChatsLimit(IEnumerable<Guid> chats, int chatsLimit) {
			return chatsLimit > 0
				? chats.Take(chatsLimit).ToList()
				: chats.ToList();
		}

		private bool UseNewChatsDescOrder() {
			return SystemSettings.GetValue(_userConnection, "UseNewChatsDescOrder", false);
		}

		private List<Guid> GetFreeChatsByQueueFromDb(Guid chatQueueId, int chatsLimit = -1) {
			var select = new Select(_userConnection);
			if (chatsLimit > 0) {
				select.Top(chatsLimit);
			}
			select
				.Column("Id").As("ChatId")
				.From("OmniChat")
				.Where("QueueId").IsEqual(Column.Parameter(chatQueueId))
					.And("OperatorId").IsNull()
					.And("DirectedOperatorId").IsNull()
					.And("StatusId").Not().In(
				Column.Parameters(new[] {
					OmnichannelMessagingConsts.BotProcessingChatStatus,
					OmnichannelMessagingConsts.CompletedByBotChatStatus,
					OmnichannelMessagingConsts.HandedOverToAgent,
					OmnichannelMessagingConsts.CompletedChatStatus}));
			if (UseNewChatsDescOrder()) {
				select.OrderByDesc("CreatedOn");
			} else {
				select.OrderByAsc("CreatedOn");
			}
			return select.ExecuteEnumerable(r => r.GetColumnValue<Guid>("ChatId")).ToList();
		}

		private List<Guid> GetFreeChatsByQueueFromCache(Guid chatQueueId) {
			string cacheKey = GetFreeChatsByQueueCacheKey(chatQueueId);
			return _userConnection.ApplicationCache.GetValue<List<Guid>>(cacheKey);
		}

		private void SetFreeChatsByQueueCache(Guid chatQueueId, List<Guid> freeChats) {
			string cacheKey = GetFreeChatsByQueueCacheKey(chatQueueId);
			_userConnection.ApplicationCache.SetOrRemoveValue(cacheKey, freeChats);
		}

		private void AddBaseColumns(EntitySchemaQuery esq) {
			esq.AddColumn("Contact");
			esq.AddColumn("CloseDate");
			esq.AddColumn("ChatPreview");
			esq.AddColumn("Channel");
			esq.AddColumn("Channel.ChatQueue");
			esq.AddColumn("Status");
			esq.AddColumn("UnprocessedMsgCount");
			esq.AddColumn("LastMessageDirection");
			esq.AddColumn("LastMessageDate");
			esq.AddColumn("Queue");
			esq.AddColumn("FirstReplyTime");
			esq.AddColumn("SenderIdentity");
			esq.AddColumn("ModifiedBy");
			esq.AddColumn("CreatedBy");
			esq.AddColumn("CreatedOn").OrderByDesc();
			esq.AddColumn("ModifiedOn").OrderByDesc();
		}

		private Entity FindActiveChat(MessagingMessage message) {
			var esq = CreateOmnichannelEsq();
			OmnichatEsqColumnsAppender.AddLoggedColumns(esq);
			if (message.IsGuestUser && (message.ContactId == null || message.ContactId == Guid.Empty)) {
				esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "SenderIdentity",
					message.SenderIfEcho));
			} else {
				esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Contact",
					message.ContactId));
			}
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Channel",
				message.ChannelId));
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.NotEqual, "Status",
				OmnichannelMessagingConsts.CompletedChatStatus));
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.NotEqual, "Status",
				OmnichannelMessagingConsts.CompletedByBotChatStatus));
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.NotEqual, "Status",
				OmnichannelMessagingConsts.HandedOverToAgent));
			EntityCollection collection = esq.GetEntityCollection(_userConnection);
			if (collection.IsEmpty()) {
				return null;
			}
			if (collection.Count > 1) {
				Log.Error($"Multiple active chats for sender: {message.SenderIfEcho}, channelId: {message.ChannelId}");
			}
			return collection[0];
		}

		private int GetFirstReplyTime(IEnumerable<UnifiedMessage> unifiedMessages, DateTime chatStartDate) {
			var firstReplyMessageTimeCollection = unifiedMessages.Where(message => message.MessageDirection
				== OmnichannelDirection.MessageDirection.Outcoming);
			if (firstReplyMessageTimeCollection.Any()) {
				TimeSpan result = GetTimeInUserTimeZone(firstReplyMessageTimeCollection.Min(message => message.Timestamp)) -
					chatStartDate;
				return Convert.ToInt32(result.TotalSeconds);
			}
			return default(int);
		}

		private int GetChatDuration(DateTime startDate, DateTime endDate) {
			TimeSpan result = endDate - startDate;
			return Convert.ToInt32(result.TotalMinutes);
		}

		private DateTime GetTimeInUserTimeZone(long timestamp) {
			DateTime dt = DateTimeOffset.FromUnixTimeMilliseconds(timestamp).UtcDateTime;
			dt = TimeZoneInfo.ConvertTimeFromUtc(dt, _userConnection.CurrentUser.TimeZone);
			return dt;
		}

		private DateTime GetChatEndDate(IEnumerable<UnifiedMessage> unifiedMessages) {
			return GetTimeInUserTimeZone(unifiedMessages.Max(message => message.Timestamp));
		}

		private DateTime GetChatStartDate(IEnumerable<UnifiedMessage> unifiedMessages) {
			return GetTimeInUserTimeZone(unifiedMessages.Min(message => message.Timestamp));
		}

		private EntitySchemaQuery CreateOmnichannelEsq(bool applyColumns = true) {
			var esq = new EntitySchemaQuery(_userConnection.EntitySchemaManager, "OmniChat");
			esq.PrimaryQueryColumn.IsAlwaysSelect = true;
			esq.AddColumn("Operator");
			if (applyColumns) {
				AddBaseColumns(esq);
			}
			return esq;
		}

		private EntitySchemaQuery CreateActualOperatorChatsEsq(bool applyColumns = true) {
			var esq = CreateOmnichannelEsq(applyColumns);
			if (applyColumns) {
				esq.AddColumn("Contact.Name");
				esq.AddColumn("Contact.Account");
				esq.AddColumn("Contact.Account.Name");
				esq.AddColumn("Channel.MsgSettingsId");
				esq.AddColumn("Channel.Provider");
				esq.AddColumn("Channel.Source");
				esq.AddColumn("Channel");
				esq.AddColumn("ModifiedOn");
				esq.AddColumn("LastMessageDirection");
				esq.Columns.FindByName("CreatedOn").OrderByAsc();
			}
			var chatFilter = new EntitySchemaQueryFilterCollection(esq);
			chatFilter.LogicalOperation = LogicalOperationStrict.And;
			chatFilter.Add(esq.CreateFilterWithParameters(FilterComparisonType.NotEqual, "Status",
				OmnichannelMessagingConsts.CompletedChatStatus));
			chatFilter.Add(esq.CreateFilterWithParameters(FilterComparisonType.NotEqual, "Status",
				OmnichannelMessagingConsts.CompletedByBotChatStatus));
			chatFilter.Add(esq.CreateFilterWithParameters(FilterComparisonType.NotEqual, "Status",
				OmnichannelMessagingConsts.BotProcessingChatStatus));
			chatFilter.Add(esq.CreateFilterWithParameters(FilterComparisonType.NotEqual, "Status",
				OmnichannelMessagingConsts.HandedOverToAgent));
			esq.Filters.Add(chatFilter);
			return esq;
		}

		private Entity GetOmnichannelChat(Guid? chatId) {
			var esq = CreateOmnichannelEsq();
			OmnichatEsqColumnsAppender.AddLoggedColumns(esq);
			return esq.GetEntity(_userConnection, chatId);
		}

		private void SetCloseDate(Entity chat, MessagingMessage message) {
			bool isIncomning = message.MessageDirection == OmnichannelDirection.MessageDirection.Incoming;
			if (isIncomning && !_userConnection.GetIsFeatureEnabled("SetCloseDateOnOutgoingMessage")
					&& !message.IsStandBy) {
				chat.SetColumnValue("CloseDate", null);
			} else {
				var channelQueueId = chat.GetTypedColumnValue<Guid>("QueueId");
				int timeout = ChatQueueRepository.GetSettings(channelQueueId).Timeout;
				if (message.IsStandBy) {
					chat.SetColumnValue("CloseDate", DateTime.UtcNow.AddMinutes(CLOSE_DEAD_CHAT_TIMEOUT_IN_MINUTES));
					return;
				}
				if (timeout >= 1) {
					chat.SetColumnValue("CloseDate", DateTime.UtcNow.AddMinutes(timeout));
				}
			}
		}

		public void SetCloseDate(Entity chat) {
			var channelQueueId = chat.GetTypedColumnValue<Guid>("QueueId");
			int timeout = ChatQueueRepository.GetSettings(channelQueueId).Timeout;
			if (timeout >= 1) {
				chat.SetColumnValue("CloseDate", DateTime.UtcNow.AddMinutes(timeout));
			}
		}

		private void AddExpiredOmnichannelChatColumns(EntitySchemaQuery esq) {
			esq.AddColumn("Operator");
			esq.AddColumn("Parent");
			esq.AddColumn("Status");
			esq.AddColumn("CloseDate");
			esq.AddColumn("ChatStartDate");
			esq.AddColumn("ChatEndDate");
			esq.AddColumn("FirstReplyTime");
			esq.AddColumn("ChatDuration");
			esq.AddColumn("Conversation");
			esq.AddColumn("CompletionDate");
			esq.AddColumn("ClosureReason");
		}

		private void AddExpiredOmnichannelChatFilters(EntitySchemaQuery esq) {
			var filters = new[] {
				esq.CreateFilterWithParameters(FilterComparisonType.LessOrEqual, "CloseDate", DateTime.UtcNow),
				esq.CreateFilterWithParameters(FilterComparisonType.NotEqual, "Status", OmnichannelMessagingConsts.CompletedChatStatus),
				esq.CreateFilterWithParameters(FilterComparisonType.NotEqual, "Status", OmnichannelMessagingConsts.CompletedByBotChatStatus),
				esq.CreateFilterWithParameters(FilterComparisonType.NotEqual, "Status", OmnichannelMessagingConsts.HandedOverToAgent),
				esq.CreateFilterWithParameters(FilterComparisonType.NotEqual, "Status", OmnichannelMessagingConsts.WaitingForProcessing),
			};
			esq.Filters.AddRange(filters);
		}

		private string GetChatPreview(MessagingMessage message) {
			if (message.Attachments != null) {
				return new LocalizableString(_userConnection.Workspace.ResourceStorage, "ChatRepository",
					"LocalizableStrings.FileChatPreview.Value").ToString();
			}
			return message.Message;
		}

		private bool TryGetChatEntity(Guid chatId, out Entity chat, bool IsEmptyEntity = false) {
			EntitySchema schema = _userConnection.EntitySchemaManager.GetInstanceByName("OmniChat");
			chat = schema.CreateEntity(_userConnection);
			if (IsEmptyEntity) {
				return IsEmptyEntity;
			} else {
				return chat.FetchFromDB(chatId);
			}
		}

		private Select GetRelatedChatsSelect() {
			return new Select(_userConnection)
					.Column("OC", "Id").As("Id")
					.Column("OC", "ParentId").As("ParentId")
				.From("OmniChat").As("OC") as Select;
		}

		private HierarchicalSelectOptions GetRelatedChatsHierarchicalOptions(Guid chatId) {
			var options = new HierarchicalSelectOptions {
				PrimaryColumnName = "Id",
				ParentColumnName = "ParentId",
				SelectType = HierarchicalSelectType.Parents
			};
			var startingIdParameter = new QueryParameter("Id", chatId);
			QueryCondition startingCondition = options.StartingPrimaryColumnCondition;
			startingCondition.LeftExpression = new QueryColumnExpression("Id");
			startingCondition.ConditionType = QueryConditionType.Equal;
			startingCondition.RightExpressions.Add(startingIdParameter);
			return options;
		}

		private IEnumerable<Guid> FindRelatedChats(Guid chatId) {
			Select select = GetRelatedChatsSelect();
			select.HierarchicalOptions = GetRelatedChatsHierarchicalOptions(chatId);
			return select.ExecuteEnumerable(r => r.GetColumnValue<Guid>("Id")).ToArray();
		}

		private Guid GetParentChatId(Guid chatId) {
			return (new Select(_userConnection).Top(1)
				.Column("ParentId")
				.From("OmniChat")
				.Where("Id").IsEqual(Column.Parameter(chatId)) as Select).ExecuteScalar<Guid>();
		}

		private Guid GetChannelProvider(string channelId) {
			return (new Select(_userConnection).Top(1)
				.Column("ProviderId")
				.From("Channel")
				.Where("Id").IsEqual(Column.Parameter(Guid.Parse(channelId))) as Select).ExecuteScalar<Guid>();
		}

		private EntitySchemaQuery GetChatConversationEsq() {
			var chatEsq = new EntitySchemaQuery(_userConnection.EntitySchemaManager, "OmniChat");
			chatEsq.PrimaryQueryColumn.IsAlwaysSelect = true;
			chatEsq.AddColumn("Conversation");
			return chatEsq;
		}

		private IEnumerable<UnifiedMessage> GetParentChatConversation(Guid chatId) {
			Guid parentChatId = GetParentChatId(chatId);
			if (parentChatId == default(Guid)) {
				return null;
			}
			IEnumerable<UnifiedMessage> conversation = GetChatConversation(parentChatId);
			return conversation;
		}

		private void PassControlToBotIfNeeded(UnifiedMessage message, Guid chatId) {
			if (message.IsStandBy || (_userConnection.GetIsFeatureEnabled("CheckIsParentChatFromBot")
					&& IsParentBotChatExists(chatId))) {
				try {
					var result = MessageManager.PassControlToBot(message);
					Log.DebugFormat("Control was passed to external bot with recipient {0}. Result = {1}", message.Sender, result);
				} catch (Exception ex) when (ex is NotImplementedException || ex is NotSupportedException) {
					Log.DebugFormat("Channel '{0}' does not support passing control to a primary receiver; skipping handover. {1}", message.Source, ex.Message);
				}
			}
		}

		private void SaveChatMessages(IEnumerable<UnifiedMessage> unifiedMessages) {
			var textMessages = unifiedMessages.Where(mes => mes.MessageType == OmnichannelDirection.MessageType.Text);
			foreach (var message in textMessages) {
				var insert = new Insert(_userConnection)
				.Into("ChatMessages")
				.Set("Timestamp", Column.Parameter(message.Timestamp.ToString()))
				.Set("Sender", Column.Parameter(message.Sender))
				.Set("Recipient", Column.Parameter(message.Recipient))
				.Set("Source", Column.Parameter(message.Source))
				.Set("OmniChatId", Column.Parameter(Guid.Parse(message.ChatId)))
				.Set("Message", Column.Parameter(message.Message))
				.Set("MessageDirection", Column.Parameter(message.MessageDirection))
				.Set("ChannelId", Column.Parameter(Guid.Parse(message.ChannelId)))
				.Set("CreatedDate", Column.Parameter(DateTimeOffset.FromUnixTimeMilliseconds(message.Timestamp).UtcDateTime))
				as Insert;
				insert.Execute();
			}
		}

		private IEnumerable<UnifiedMessage> GetMessagesByChannelId(Guid channelId) {
			Select chatSelect = new Select(_userConnection)
				.Column("Id")
				.From("OmniChat").As("OC")
				.Where("OC", "ChannelId").IsEqual(Column.Parameter(channelId))
				.And("OC", "StatusId").IsEqual(Column.Const(OmnichannelMessagingConsts.BotProcessingChatStatus)) as Select;
			List<Guid> botChats = new List<Guid>();
			chatSelect.ExecuteReader(r => {
				botChats.Add(r.GetColumnValue<Guid>("Id"));
			});
			var messages = MessageManager.GetMessagesByChatId(botChats);
			return messages;
		}

		private IEnumerable<UnifiedMessage> InnerCloseChat(Entity chat, bool createSystemMessage = false, bool hasChildChat = false, Guid closureReasonId = default) {
			var oldStatus = chat.GetTypedColumnValue<Guid>("StatusId");
			if (oldStatus == OmnichannelMessagingConsts.CompletedChatStatus
					|| oldStatus == OmnichannelMessagingConsts.CompletedByBotChatStatus
					|| oldStatus == OmnichannelMessagingConsts.HandedOverToAgent) {
				return new List<UnifiedMessage>();
			}
			var chatId = chat.GetTypedColumnValue<Guid>("Id");
			IEnumerable<UnifiedMessage> unifiedMessages = MessageManager.GetMessagesByChatId(chatId);
			SaveChatMessages(unifiedMessages);
			string serializedConversation = JsonConvert.SerializeObject(unifiedMessages);
			chat.SetColumnValue("Conversation", serializedConversation);
			if (!unifiedMessages.Any()) {
				unifiedMessages = LoadMessagesFromParentChat(chat);
			}
			var chatStartDate = GetChatStartDate(unifiedMessages);
			var chatEndDate = GetChatEndDate(unifiedMessages);
			var completionDate = DateTime.UtcNow;
			chat.SetColumnValue("ChatStartDate", chatStartDate);
			chat.SetColumnValue("ChatEndDate", chatEndDate);
			chat.SetColumnValue("CompletionDate", completionDate);
			var firstReplyTime = GetFirstReplyTime(unifiedMessages, chatStartDate);
			if (firstReplyTime != default(int)) {
				chat.SetColumnValue("FirstReplyTime", firstReplyTime);
			}
			int chatDuration = GetChatDuration(chatStartDate, chatEndDate);
			chat.SetColumnValue("ChatDuration", chatDuration);
			var botCompletedStatus = hasChildChat
				? OmnichannelMessagingConsts.HandedOverToAgent
				: OmnichannelMessagingConsts.CompletedByBotChatStatus;
			chat.SetColumnValue("StatusId", oldStatus == OmnichannelMessagingConsts.BotProcessingChatStatus
				? botCompletedStatus
				: OmnichannelMessagingConsts.CompletedChatStatus);
			if (closureReasonId != default) {
				chat.SetColumnValue("ClosureReasonId", closureReasonId);
			}
			chat.Save(false);
			if (createSystemMessage &&
					chat.GetTypedColumnValue<Guid>("OperatorId").IsNotEmpty()) {
				CreateChatClosedSystemMessage(unifiedMessages.LastOrDefault(), "ChatCompletedMetadata",
					new ChatCompletedData { CloseDate = completionDate }, MessageMacrosConsts.ChatCompleted);
			}
			return unifiedMessages;
		}

		private IEnumerable<UnifiedMessage> LoadMessagesFromParentChat(Entity chat) {
			var parentChatId = chat.GetTypedColumnValue<Guid>("ParentId");
			return MessageManager.GetMessagesByChatId(parentChatId);
		}

		private MessagingMessage GetClosedSystemMessage(UnifiedMessage lastMessage,
				string messageResourceName = "ChatWasClosedSystemMessage") {
			string messageText = new LocalizableString(_userConnection.Workspace.ResourceStorage, "ChatRepository",
				$"LocalizableStrings.{messageResourceName}.Value").ToString();
			var systemMessage = new MessagingMessage {
				Message = messageText,
				ChatId = lastMessage.ChatId.ToString(),
				MessageType = OmnichannelDirection.MessageType.System,
				Timestamp = GetCurrentTime(),
				Recipient = lastMessage.Recipient,
				Sender = lastMessage.Sender,
				MessageDirection = OmnichannelDirection.MessageDirection.Outcoming,
				ChannelId = lastMessage.ChannelId,
				Source = lastMessage.Source
			};
			return systemMessage;
		}

		private void CreateChatClosedSystemMessage<TData>(UnifiedMessage lastMessage, string metadataBindingName,
				TData data, Guid macrosId, string messageResourceName = "ChatWasClosedSystemMessage") {
			MessagingMessage systemMessage = GetClosedSystemMessage(lastMessage, messageResourceName);
			var metadata = ClassFactory.Get<IChatMessageMetadata<TData>>(metadataBindingName);
			string messageMetadata = metadata.Generate(data);
			MessageManager.AddSystemMessage(systemMessage, messageMetadata, macrosId);
		}

		private long GetCurrentTime() {
			return (long)(DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalMilliseconds;
		}

		private Select GetDirectedChatsInfoQueryBaseSelect(UserConnection userConnection) {
			return new Select(userConnection)
					.Column("Id")
					.Column("DirectedOperatorId")
				.From("OmniChat")
				.Where("StatusId").In(
				Column.Parameters(new[] {
					OmnichannelMessagingConsts.WaitingForProcessing,
					OmnichannelMessagingConsts.InProgressChatStatus})) as Select;
		}

		private void SetSysLanguageIdIfNeeded(Entity omniChatEntity, MessagingMessage message) {
			if (!SystemSettings.GetValue(omniChatEntity.UserConnection, "EnableChatTranslation", false)) {
				return;
			}
			if (TryDetectLanguageId(message.Message, out Guid languageId)) {
				omniChatEntity.SetColumnValue("LanguageId", languageId);
			}
		}

		private bool TryDetectLanguageId(string text, out Guid languageId) {
			languageId = Guid.Empty;
			var provider = TranslateProviderFactory.Get();
			if (provider == null) {
				return false;
			}
			var detectResult = provider.DetectLanguage(text);
			if (string.IsNullOrEmpty(detectResult?.LanguageCode)) {
				TranslateProviderLog.Debug("Language detection returned empty language code.");
				return false;
			}
			if (LanguageRegistry.TryGetPreferredByShort(detectResult.LanguageCode, out LanguageInfo info)) {
				languageId = info.Id;
				TranslateProviderLog.Debug($"Language '{detectResult.LanguageCode}' detected and set for chat.");
				return true;
			}
			TranslateProviderLog.Debug($"Detected language code '{detectResult.LanguageCode}' is not registered in LanguageRegistry.");
			return false;
		}

		private void SetFirstReplyTimeIfNeeded(Entity chat) {
			var currentFirstReplyTime = chat.GetTypedColumnValue<int>("FirstReplyTime");
			if (currentFirstReplyTime != default(int)) {
				return;
			}
			try {
				var chatCreatedOn = chat.GetTypedColumnValue<DateTime>("CreatedOn");
				var currentTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, _userConnection.CurrentUser.TimeZone);
				TimeSpan result = currentTime - chatCreatedOn;
				int firstReplyTime = Convert.ToInt32(result.TotalSeconds);
				if (firstReplyTime > 0) {
					chat.SetColumnValue("FirstReplyTime", firstReplyTime);
				}
			} catch (Exception ex) {
				Log.Error($"Error calculating FirstReplyTime for chat {chat.GetTypedColumnValue<Guid>("Id")}", ex);
			}
		}

		#endregion

		#region Methods: Protected

		protected virtual Guid CreateChat(MessagingMessage message, SetAdditionalColumns setAdditionalColumns) {
			Guid chatId = Guid.NewGuid();
			TryGetChatEntity(chatId, out Entity omniChatEntity, true);
			omniChatEntity.SetDefColumnValues();
			omniChatEntity.SetColumnValue("Id", chatId);
			omniChatEntity.SetColumnValue("ChatPreview", GetChatPreview(message));
			if (message.ContactId != null && (Guid)message.ContactId != Guid.Empty) {
				omniChatEntity.SetColumnValue("ContactId", message.ContactId);
			} else {
				var contactIdentifier = new OmnichannelContactIdentifier(_userConnection);
				Guid contactIdFromIdentity = contactIdentifier.FindExistingContactBySenderIdentity(
					message.SenderIfEcho, message.ChannelId);
				if (contactIdFromIdentity != Guid.Empty) {
					omniChatEntity.SetColumnValue("ContactId", contactIdFromIdentity);
				}
			}
			omniChatEntity.SetColumnValue("ChannelId", message.ChannelId);
			omniChatEntity.SetColumnValue("SenderIdentity", message.SenderIfEcho);
			omniChatEntity.SetColumnValue("CloseDate", null);
			omniChatEntity.SetColumnValue("LastMessageDirection", message.MessageDirection);
			omniChatEntity.SetColumnValue("LastMessageDate", DateTime.UtcNow);
			SetSysLanguageIdIfNeeded(omniChatEntity, message);
			setAdditionalColumns(omniChatEntity);
			omniChatEntity.Save(false);
			Log.InfoFormat("Chat (id={0}) with Contact {1} was created", chatId, message.ContactId);
			return chatId;
		}

		protected virtual Guid UpdateChat(MessagingMessage message, Entity chat) {
			Guid chatId = chat.GetTypedColumnValue<Guid>("Id");
			if (message.MessageDirection == OmnichannelDirection.MessageDirection.Incoming) {
				UpdateUnreadMsgCount(chat);
			}
			if (message.MessageDirection == OmnichannelDirection.MessageDirection.Outcoming) {
				SetFirstReplyTimeIfNeeded(chat);
			}
			SetCloseDate(chat, message);
			chat.SetColumnValue("ChatPreview", GetChatPreview(message));
			chat.SetColumnValue("LastMessageDirection", message.MessageDirection);
			chat.SetColumnValue("LastMessageDate", DateTime.UtcNow);
			chat.Save(false);
			return chatId;
		}

		protected virtual void UpdateUnreadMsgCount(Entity chat) {
			int msgCount = chat.GetTypedColumnValue<int>("UnprocessedMsgCount");
			msgCount += 1;
			chat.SetColumnValue("UnprocessedMsgCount", msgCount);
		}

		/// <summary>
		/// Get esq to OmnichannelChat.
		/// </summary>
		/// <param name="userConnection">The user connection.</param>
		protected virtual EntitySchemaQuery GetExpiredOmnichannelChatEsq(UserConnection userConnection) {
			var esq = new EntitySchemaQuery(userConnection.EntitySchemaManager, "OmniChat");
			esq.PrimaryQueryColumn.IsAlwaysSelect = true;
			esq.RowCount = maxChatsToCloseAtOnce;
			AddExpiredOmnichannelChatColumns(esq);
			AddExpiredOmnichannelChatFilters(esq);
			return esq;
		}

		/// <summary>
		/// Close OmnichannelChat.
		/// </summary>
		/// <param name="chat">OmnichannelChat entity.</param>
		protected virtual void CloseOmnichannelChat(Entity chat, bool createSystemMessage = false, bool hasChildChat = false, bool closedByAgent = false, Guid closureReasonId = default) {
			var oldStatus = chat.GetTypedColumnValue<Guid>("StatusId");
			var chatId = chat.GetTypedColumnValue<Guid>("Id");
			var unifiedMessages = InnerCloseChat(chat, createSystemMessage, hasChildChat, closureReasonId);
			if (!unifiedMessages.Any()) {
				return;
			}
			if (oldStatus == OmnichannelMessagingConsts.InProgressChatStatus) {
				PassControlToBotIfNeeded(unifiedMessages.First(m => !m.IsEcho), chatId);
			}
			var operatorId = chat.GetTypedColumnValue<Guid>("OperatorId");
			if (operatorId.IsEmpty()) {
				// Waiting/unassigned chat lives in every queue operator's inbox (added there via
				// NewIncomingChatNotify), so send those operators the same queue-removal signal a
				// take-into-work sends to the *other* operators (AcceptChat with no owner) and drop it
				// from the directed-chats cache. The Agent Inbox removes a "New items" row on AcceptChat
				// (OperatorId != me) but ignores CompleteChat for that list, so CompleteChatNotify -
				// besides reaching nobody at Guid.Empty - would not clear the row even if delivered.
				NotifyQueueOperatorsAboutClosedWaitingChat(chatId);
			} else if (closedByAgent) {
				OperatorNotifier.CompleteChatByAgentNotify(operatorId, chatId);
			} else {
				OperatorNotifier.CompleteChatNotify(operatorId, chatId);
			}
			_chatOperatorCache.UpdateActiveChatsCount(operatorId, -1);
			QueueDistribution.DistributeQueueChatsByChatId(chatId, 1);
			Log.InfoFormat("Chat (id={0}) was closed", chatId);
		}

		private void NotifyQueueOperatorsAboutClosedWaitingChat(Guid chatId) {
			_chatOperatorCache.RemoveDirectedChat(chatId);
			var chatQueueId = GetChatQueueId(chatId);
			var operators = _chatOperatorCache.GetOperatorsCache()
				.Where(op => op.ChatQueues.Contains(chatQueueId))
				.Select(op => op.UserId)
				.ToList();
			if (operators.Any()) {
				OperatorNotifier.AcceptChatNotify(operators, chatId);
			}
		}

		protected virtual void ClosePreviousChat(Entity chat, Guid closureReasonId = default) {
			InnerCloseChat(chat, closureReasonId: closureReasonId);
			var operatorId = chat.GetTypedColumnValue<Guid>("OperatorId");
			_chatOperatorCache.UpdateActiveChatsCount(operatorId, -1);
		}

		/// <summary>
		/// Get a collection of active operator chats.
		/// </summary>
		/// <param name="operatorId">Operator identifier.</param>
		/// <returns><see cref="EntityCollection"/> collection of active operator chats.</returns>
		protected virtual EntityCollection InternalGetChatsByOperator(Guid operatorId, bool applyColumns = true) {
			var esq = CreateActualOperatorChatsEsq(applyColumns);
			OmnichatEsqColumnsAppender.AddLoggedColumns(esq);
			var operatorFilter = esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Operator", operatorId);
			esq.Filters.Add(operatorFilter);
			return esq.GetEntityCollection(_userConnection);
		}

		/// <summary>
		/// Get a collection of possible operator chats.
		/// </summary>
		/// <param name="ids">Collection of IDs of distributed operator omnichats.</param>
		/// <returns><see cref="EntityCollection"/> collection of distributed operator omnichats.</returns>
		protected virtual EntityCollection InternalGetChatsById(List<Guid> ids, bool applyColumns = true) {
			var esq = CreateActualOperatorChatsEsq(applyColumns);
			OmnichatEsqColumnsAppender.AddLoggedColumns(esq);
			var primaryColumnFilter = esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Id",
				ids.Cast<object>().ToArray());
			esq.Filters.Add(primaryColumnFilter);
			return esq.GetEntityCollection(_userConnection);
		}

		/// <summary>
		/// Get operator accepted chats information query.
		/// </summary>
		/// <param name="userConnection">The user connection.</param>
		/// <param name="operatorId">Operator identifier.</param>
		/// <returns><see cref="Select"/> instance.</returns>
		protected virtual Select GetAcceptedChatsInfoQuery(UserConnection userConnection, Guid operatorId) {
			return new Select(userConnection)
					.Column(Func.Count("Id")).As("Count")
					.Column(Func.Max("AcceptDate")).As("LatestChat")
				.From("OmniChat")
				.Where("OperatorId").IsEqual(Column.Parameter(operatorId))
					.And("StatusId").IsEqual(Column.Parameter(OmnichannelMessagingConsts.InProgressChatStatus))
					.GroupBy("OperatorId") as Select;
		}

		/// <summary>
		/// Get operator accepted chats information query for multiple operators.
		/// </summary>
		/// <param name="userConnection">The user connection.</param>
		/// <param name="operatorIds">Operator identifiers.</param>
		/// <returns><see cref="Select"/> instance.</returns>
		protected virtual Select GetAcceptedChatsInfoQuery(UserConnection userConnection, IEnumerable<Guid> operatorIds) {
			return new Select(userConnection)
					.Column("OperatorId")
					.Column(Func.Count("Id")).As("Count")
					.Column(Func.Max("AcceptDate")).As("LatestChat")
				.From("OmniChat")
				.Where("OperatorId").In(Column.Parameters(operatorIds))
					.And("StatusId").IsEqual(Column.Parameter(OmnichannelMessagingConsts.InProgressChatStatus))
					.GroupBy("OperatorId") as Select;
		}

		/// <summary>
		/// Get operator directed chats information query.
		/// </summary>
		/// <param name="userConnection">The user connection.</param>
		/// <param name="operatorId">Operator identifier.</param>
		/// <returns><see cref="Select"/> instance.</returns>
		protected virtual Select GetDirectedChatsInfoQuery(UserConnection userConnection, Guid operatorId) {
			return GetDirectedChatsInfoQueryBaseSelect(userConnection)
				.And("DirectedOperatorId").IsEqual(Column.Parameter(operatorId)) as Select;
		}

		/// <summary>
		/// Get operator directed chats information query for multiple operators.
		/// </summary>
		/// <param name="userConnection">The user connection.</param>
		/// <param name="operatorIds">Operator identifiers.</param>
		/// <returns><see cref="Select"/> instance.</returns>
		protected virtual Select GetDirectedChatsInfoQuery(UserConnection userConnection, IEnumerable<Guid> operatorIds) {
			return GetDirectedChatsInfoQueryBaseSelect(userConnection)
				.And("DirectedOperatorId").In(Column.Parameters(operatorIds)) as Select;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Clears cached free chats for a queue.
		/// </summary>
		/// <param name="userConnection">User connection.</param>
		/// <param name="chatQueueId">Chat queue identifier.</param>
		public static void ResetFreeChatsByQueueCache(UserConnection userConnection, Guid chatQueueId) {
			if (userConnection == null
					|| chatQueueId.IsEmpty()
					|| !userConnection.GetIsFeatureEnabled("OmnichannelOptimization")) {
				return;
			}
			var cache = userConnection.ApplicationCache;
			cache.SetOrRemoveValue(GetFreeChatsByQueueCacheKey(chatQueueId), null);
		}

		/// <summary>
		/// Adds message to chat.
		/// </summary>
		/// <param name="message">Messaging message which will be added to chat.</param>
		/// <returns>Identifier of chat.</returns>
		public Guid AddMessage(MessagingMessage message, out bool isNewChat) {
			Entity activeChat = string.IsNullOrEmpty(message.ChatId)
				? FindActiveChat(message)
				: GetOmnichannelChat(Guid.Parse(message.ChatId));
			if (activeChat == null) {
				message.ChannelQueueId = GetChatQueueIdFromChannel(Guid.Parse(message.ChannelId));
				isNewChat = true;
				return CreateChat(message, chat => {
					Guid chatStatus = message.IsStandBy
						? OmnichannelMessagingConsts.BotProcessingChatStatus
						: OmnichannelMessagingConsts.WaitingForProcessing;
					chat.SetColumnValue("StatusId", chatStatus);
					chat.SetColumnValue("UnprocessedMsgCount", 1);
					chat.SetColumnValue("QueueId", message.ChannelQueueId);
				});
			}
			message.ChannelQueueId = activeChat.GetTypedColumnValue<Guid>("QueueId");
			isNewChat = false;
			return UpdateChat(message, activeChat);
		}

		/// <summary>
		/// Adds outcomning message to chat.
		/// </summary>
		/// <param name="message">Messaging message which will be added to chat.</param>
		/// <returns><see cref="GetLastChatResponse"/> instance.</returns>
		public GetLastChatResponse AddOutcomingMessage(MessagingMessage message) {
			Entity activeChat = string.IsNullOrEmpty(message.ChatId)
				? FindActiveChat(message)
				: GetOmnichannelChat(Guid.Parse(message.ChatId));
			var result = new GetLastChatResponse();
			var statusId = activeChat?.GetTypedColumnValue<Guid>("StatusId");
			if (activeChat == null
					|| statusId == OmnichannelMessagingConsts.CompletedChatStatus
					|| statusId == OmnichannelMessagingConsts.CompletedByBotChatStatus
					|| statusId == OmnichannelMessagingConsts.HandedOverToAgent) {
				var lastChat = OpenChatFromContactVerifier.CheckContactDataAndGetChatId(activeChat.GetTypedColumnValue<Guid>("ContactId"), GetChannelProvider(message.ChannelId));
				if (lastChat.Success) {
					message.ChannelQueueId = GetChatQueueIdFromChannel(Guid.Parse(message.ChannelId));
					result.LastChatId = lastChat.IsLastChatCompleted ? CreateChat(message, chat => {
						chat.SetColumnValue("StatusId", OmnichannelMessagingConsts.InProgressChatStatus);
						chat.SetColumnValue("OperatorId", _userConnection.CurrentUser.Id);
						chat.SetColumnValue("ContactId", activeChat.GetTypedColumnValue<Guid>("ContactId"));
						chat.SetColumnValue("AcceptDate", DateTime.UtcNow);
						chat.SetColumnValue("QueueId", message.ChannelQueueId);
					}) : lastChat.LastChatId;
					result.IsLastChatCompleted = lastChat.IsLastChatCompleted;
					return result;
				} else {
					return lastChat;
				}
			}
			message.ChannelQueueId = activeChat.GetTypedColumnValue<Guid>("QueueId");
			result.LastChatId = UpdateChat(message, activeChat);
			return result;
		}

		/// <summary>
		/// Close OmnichannelChat when it is time.
		/// </summary>
		public void CloseExpiredChats() {
			var esq = GetExpiredOmnichannelChatEsq(_userConnection);
			OmnichatEsqColumnsAppender.AddLoggedColumns(esq);
			EntityCollection chats = esq.GetEntityCollection(_userConnection);
			foreach (Entity chat in chats) {
				Log.DebugFormat("Try to close expired chat {0}", chat.GetTypedColumnValue<Guid>("Id"));
				CloseOmnichannelChat(chat, true, closureReasonId: OmnichannelMessagingConsts.ClosureReason.CompletedByTimeout);
			}
		}

		/// <summary>
		/// Check if chat has closed by bot parent chat in hierarchy.
		/// </summary>
		/// <returns><c>true</c> if element in hierarchy</returns>
		public bool IsParentBotChatExists(Guid chatId) {
			var select = new Select(_userConnection).Top(1)
				.Column("Id")
				.From("VwCompletedByBotChain")
				.Where("Id").IsEqual(Column.Parameter(chatId)) as Select;
			select.SpecifyNoLockHints();
			return select.ExecuteScalar<Guid>() == chatId;
		}

		/// <summary>
		/// Close active chat.
		/// </summary>
		/// <param name="chatId">Chat identifier.</param>
		/// <param name="createSystemMessage">Flag to create system message.</param>
		/// <param name="hasChildChat">Flag indicating if chat has child chat.</param>
		public void CloseActiveChat(Guid chatId, bool createSystemMessage = false, bool hasChildChat = false, Guid closureReasonId = default) {
			Log.DebugFormat("Try to close chat by id {0}", chatId);
			if (TryGetChatEntity(chatId, out Entity omniChat)) {
				CloseOmnichannelChat(omniChat, createSystemMessage, hasChildChat, closureReasonId: closureReasonId);
			}
		}

		/// <summary>
		/// Close active chat by operator and publish system message.
		/// </summary>
		/// <param name="chatId"></param>
		public void CloseActiveChatByOperator(Guid chatId) {
			Log.DebugFormat("Try to close chat by id {0} by operator", chatId);
			if (TryGetChatEntity(chatId, out Entity omniChat)) {
				CloseOmnichannelChat(omniChat, closedByAgent: true, closureReasonId: OmnichannelMessagingConsts.ClosureReason.CompletedByAgent);
				IEnumerable<UnifiedMessage> unifiedMessages = MessageManager.GetMessagesByChatId(chatId);
				if (!unifiedMessages.Any()) {
					unifiedMessages = LoadMessagesFromParentChat(omniChat);
				}
				CreateChatClosedSystemMessage(unifiedMessages.LastOrDefault(), "ChatAgentClosedMetadata",
					new ChatAgentClosedData { CloseDate = DateTime.UtcNow, AgentId = _userConnection.CurrentUser.ContactId },
					MessageMacrosConsts.ChatCompletedByAgent);
			}
		}

		/// <summary>
		/// Close chat which is transferring.
		/// </summary>
		/// <param name="chatId">Chat identifier.</param>
		/// <param name="chatIdToSkip">Chat identifier to skip.</param>
		public void CloseTransferringChat(Guid chatId, Guid chatIdToSkip) {
			if (TryGetChatEntity(chatId, out Entity omniChat)) {
				ClosePreviousChat(omniChat, OmnichannelMessagingConsts.ClosureReason.Transferred);
				var chatQueueId = GetChatQueueId(chatId);
				QueueDistribution.DistributeAfterClosedChat(chatQueueId, chatIdToSkip, 1);
			}
		}

		/// <summary>
		/// Close active chat by end user.
		/// </summary>
		/// <param name="chatId">Chat identifier.</param>
		public void CloseActiveChatByEndUser(Guid chatId) {
			Log.DebugFormat("Try to close chat by id {0} by end user", chatId);
			if (TryGetChatEntity(chatId, out Entity omniChat)) {
				CloseOmnichannelChat(omniChat, closureReasonId: OmnichannelMessagingConsts.ClosureReason.CompletedByEndUser);
				IEnumerable<UnifiedMessage> unifiedMessages = MessageManager.GetMessagesByChatId(chatId);
				if (!unifiedMessages.Any()) {
					unifiedMessages = LoadMessagesFromParentChat(omniChat);
				}
				CreateChatClosedSystemMessage(unifiedMessages.LastOrDefault(), "ChatEndUserClosedMetadata",
					new ChatEndUserClosedData { CloseDate = DateTime.UtcNow },
					MessageMacrosConsts.ChatCompletedByEndUser, "ChatClosedByEndUserSystemMessage");
			}
		}

		/// <summary>
		/// Get a collection of active chats by operator identifier.
		/// </summary>
		/// <param name="operatorId">Operator identifier.</param>
		/// <returns><see cref="EntityCollection"/> collection of operators chats.</returns>
		public EntityCollection GetChatsByOperator(Guid operatorId, bool applyColumns = true) {
			return InternalGetChatsByOperator(operatorId, applyColumns);
		}

		/// <summary>
		/// Get a collection of possible operator chats by identifiers.
		/// </summary>
		/// <param name="ids">Collection of IDs of distributed operator omnichats.</param>
		/// <returns><see cref="EntityCollection"/> collection of chats.</returns>
		public EntityCollection GetChatsById(List<Guid> ids, bool applyColumns = true) {
			return InternalGetChatsById(ids, applyColumns);
		}

		/// <summary>
		/// Loads <paramref name="chatOperator"/> fields from database.
		/// </summary>
		/// <param name="chatOperator"><see cref="ChatOperator"/> instance.</param>
		public void LoadOperatorState(ChatOperator chatOperator) {
			Select acceptedChatSelect = GetAcceptedChatsInfoQuery(_userConnection, chatOperator.UserId);
			acceptedChatSelect.ExecuteReader(reader => {
				chatOperator.ActiveChatsCount = reader.GetColumnValue<int>("Count");
				Log.DebugFormat($"Init ActiveChatsCount {chatOperator.ActiveChatsCount} for operator {chatOperator.UserId}");
				chatOperator.LastChatAcceptedDate = reader.GetColumnValue<DateTime>("LatestChat");
			});
			Select directedChatSelect = GetDirectedChatsInfoQuery(_userConnection, chatOperator.UserId);
			directedChatSelect.ExecuteReader(reader => {
				chatOperator.DirectedChats.AddIfNotExists(reader.GetColumnValue<Guid>("Id"));
			});
		}

		public void LoadOperatorsState(IEnumerable<ChatOperator> chatOperators) {
			var acceptedChatsSelect = GetAcceptedChatsInfoQuery(_userConnection, chatOperators.Select(co => co.UserId));
			using (DBExecutor executor = _userConnection.EnsureDBConnection()) {
				using (IDataReader reader = acceptedChatsSelect.ExecuteReader(executor)) {
					while (reader.Read()) {
						Guid operatorId = reader.GetColumnValue<Guid>("OperatorId");
						ChatOperator chatOperator = chatOperators.FirstOrDefault(co => co.UserId == operatorId);
						if (chatOperator != null) {
							chatOperator.ActiveChatsCount = reader.GetColumnValue<int>("Count");
							Log.DebugFormat($"Init ActiveChatsCount {chatOperator.ActiveChatsCount} for operator {chatOperator.UserId}");
							chatOperator.LastChatAcceptedDate = reader.GetColumnValue<DateTime>("LatestChat");
						}
					}
				}
			}
			var directedChatsSelect = GetDirectedChatsInfoQuery(_userConnection, chatOperators.Select(co => co.UserId));
			using (DBExecutor executor = _userConnection.EnsureDBConnection()) {
				using (IDataReader reader = directedChatsSelect.ExecuteReader(executor)) {
					while (reader.Read()) {
						var operatorId = reader.GetColumnValue<Guid>("DirectedOperatorId");
						ChatOperator chatOperator = chatOperators.FirstOrDefault(co => co.UserId == operatorId);
						if (chatOperator != null) {
							chatOperator.DirectedChats.AddIfNotExists(reader.GetColumnValue<Guid>("Id"));
						}
					}
				}
			}
		}
		/// <summary>
		/// Get chat queue identifier by chat identifier.
		/// </summary>
		/// <param name="chatId">Chat identifier.</param>
		/// <returns>Chat queue identifier.</returns>
		public Guid GetChatQueueId(Guid chatId) {
			var select = new Select(_userConnection).Top(1)
					.Column("QueueId")
				.From("OmniChat")
					.Where("Id").IsEqual(Column.Parameter(chatId)) as Select;
			return select.ExecuteScalar<Guid>();
		}

		/// <summary>
		/// Gets channel queue identifier by chat identifier.
		/// </summary>
		/// <param name="chatId">Chat identifier.</param>
		/// <returns>Chat channel queue identifier.</returns>
		public Guid GetChatChannelQueueId(Guid chatId) {
			var select = new Select(_userConnection)
				.Top(1)
					.Column("Channel", "ChatQueueId")
					.From("OmniChat")
						.InnerJoin("Channel")
							.On("OmniChat", "ChannelId")
								.IsEqual("Channel", "Id")
					.Where("OmniChat", "Id")
						.IsEqual(Column.Parameter(chatId))
					 as Select;
			return select.ExecuteScalar<Guid>();
		}

		/// <summary>
		/// Get chat queue identifier by channel identifier.
		/// </summary>
		/// <param name="channelId">Channel identifier.</param>
		/// <returns>Chat queue identifier.</returns>
		public Guid GetChatQueueIdFromChannel(Guid channelId) {
			var select = new Select(_userConnection).Top(1)
				.Column("ChatQueueId")
				.From("Channel")
				.Where("Id").IsEqual(Column.Parameter(channelId)) as Select;
			return select.ExecuteScalar<Guid>();
		}

		/// <summary>
		/// Get free chats by chat queue identifier.
		/// </summary>
		/// <param name="chatQueueId">Chat queue identifier.</param>
		/// <returns>Free chat identifier by chat queue ID.</returns>
		public List<Guid> GetFreeChatsByQueue(Guid chatQueueId) {
			return GetFreeChatsByQueue(chatQueueId, -1);
		}

		/// <summary>
		/// Get free chats by chat queue identifier with chats limit.
		/// </summary>
		/// <param name="chatQueueId">Chat queue identifier.</param>
		/// <param name="chatsLimit">
		/// Maximum count of free chats.
		/// Use a value less than or equal to zero to disable limit.
		/// </param>
		/// <returns>Free chat identifier by chat queue ID.</returns>
		public List<Guid> GetFreeChatsByQueue(Guid chatQueueId, int chatsLimit) {
			if (_userConnection.GetIsFeatureEnabled("OmnichannelOptimization")) {
				List<Guid> cachedChats = GetFreeChatsByQueueFromCache(chatQueueId);
				if (cachedChats != null) {
					return ApplyChatsLimit(cachedChats, chatsLimit);
				}
				List<Guid> allFreeChats = GetFreeChatsByQueueFromDb(chatQueueId);
				SetFreeChatsByQueueCache(chatQueueId, allFreeChats);
				return ApplyChatsLimit(allFreeChats, chatsLimit);
			}
			return GetFreeChatsByQueueFromDb(chatQueueId, chatsLimit);
		}

		/// <summary>
		/// Set chat status.
		/// </summary>
		/// <param name="chatId">Chat identifier.</param>
		/// <param name="chatStatus">Chat status identifier.</param>
		public void SetChatStatus(Guid chatId, Guid chatStatus) {
			if (TryGetChatEntity(chatId, out Entity omniChat)) {
				omniChat.SetColumnValue("StatusId", chatStatus);
				omniChat.Save(false);
			}
		}

		/// <summary>
		/// Mark all chat messages as processed.
		/// </summary>
		/// <param name="ChatId">Id of chat.</param>
		public void MarkChatAsRead(Guid chatId) {
			var update = new Core.DB.Update(_userConnection, "OmniChat")
				.Set("UnprocessedMsgCount", Column.Parameter(0))
				.Where("Id")
				.IsEqual(Column.Parameter(chatId));
			update.Execute();
		}

		/// <summary>
		/// Returns identifiers of related chats by the given chat identifier.
		/// </summary>
		/// <param name="chatId">Identifier of primary chat.</param>
		/// <returns>List of related chats.</returns>
		public IEnumerable<Guid> GetRelatedChatsId(Guid chatId) {
			IEnumerable<Guid> chats = FindRelatedChats(chatId);
			return chats;
		}

		/// <summary>
		/// Returns conversation by chat identifier.
		/// </summary>
		/// <param name="chatId">Identifier of chat.</param>
		/// <returns>Chat conversation.</returns>
		public IEnumerable<UnifiedMessage> GetChatConversation(Guid chatId) {
			var esq = GetChatConversationEsq();
			OmnichatEsqColumnsAppender.AddLoggedColumns(esq);
			var chat = esq.GetEntity(_userConnection, chatId);
			string conversationSerialized = chat?.GetTypedColumnValue<string>("Conversation");
			if (conversationSerialized.IsNullOrEmpty()) {
				IEnumerable<UnifiedMessage> unifiedMessages = MessageManager.GetMessagesByChatId(chatId);
				return unifiedMessages;
			}
			return
				JsonConvert
				.DeserializeObject<List<UnifiedMessage>>(conversationSerialized);
		}

		/// <summary>
		/// Create child chat for chat with specified Id.
		/// </summary>
		/// <param name="parentChatId">Id of parent chat.</param>
		/// <param name="queueId">Id of queue for chat</param>
		/// <returns></returns>
		public Guid CreateChildChat(Guid parentChatId, Dictionary<string, object> additionalColumns = default) {
			bool parentChatExists = TryGetChatEntity(parentChatId, out var parentChat);
			if (!parentChatExists) {
				Log.Error($"Can't create child chat for chat with id={parentChatId}. Parent chat doesn't exist");
				return Guid.Empty;
			}
			Guid childChatId = Guid.NewGuid();
			TryGetChatEntity(childChatId, out var childChat, true);
			childChat.SetDefColumnValues();
			childChat.SetColumnValue("Id", childChatId);
			childChat.SetColumnValue("ChannelId", parentChat.GetColumnValue("ChannelId"));
			childChat.SetColumnValue("SenderIdentity", parentChat.GetColumnValue("SenderIdentity"));
			childChat.SetColumnValue("ContactId", parentChat.GetColumnValue("ContactId"));
			childChat.SetColumnValue("ChatPreview", parentChat.GetColumnValue("ChatPreview"));
			childChat.SetColumnValue("ParentId", parentChatId);
			childChat.SetColumnValue("UnprocessedMsgCount", MessageManager.GetMessagesByChatId(parentChatId).Count());
			childChat.SetColumnValue("LanguageId", parentChat.GetColumnValue("LanguageId"));
			if (additionalColumns == null || !additionalColumns.ContainsKey("QueueId")) {
				childChat.SetColumnValue("QueueId", parentChat.GetColumnValue("QueueId"));
			}
			if (additionalColumns != null) {
				foreach (var column in additionalColumns) {
					childChat.SetColumnValue(column.Key, column.Value);
				}
			}
			childChat.Save(false);
			return childChatId;
		}

		/// <inheritdoc />
		public void DetectAndSetChatLanguage(Guid sourceChatId, Guid targetChatId) {
			if (!SystemSettings.GetValue(_userConnection, "EnableChatTranslation", false)) {
				return;
			}
			const int maxDetectMessages = 20;
			const int maxDetectTextLength = 1000;
			var text = string.Join(" ", MessageManager.GetMessagesByChatId(sourceChatId)
				.Where(m => m.MessageDirection == OmnichannelDirection.MessageDirection.Incoming
					&& !m.IsEcho
					&& !string.IsNullOrWhiteSpace(m.Message))
				.Reverse()
				.Take(maxDetectMessages)
				.Select(m => m.Message));
			if (string.IsNullOrWhiteSpace(text)) {
				TranslateProviderLog.Debug($"No end-user text to detect language for chat {targetChatId}.");
				return;
			}
			if (text.Length > maxDetectTextLength) {
				text = text.Substring(0, maxDetectTextLength);
			}
			if (TryDetectLanguageId(text, out Guid languageId)) {
				new Update(_userConnection, "OmniChat")
					.Set("LanguageId", Column.Parameter(languageId))
					.Where("Id").IsEqual(Column.Parameter(targetChatId))
					.Execute();
			}
		}

		/// <summary>
		/// Get chats with bot by channel and sender identifiers.
		/// </summary>
		/// <param name="channelId">Id of channel.</param>
		/// <param name="sender">Sender identifier.</param>
		/// <returns>List of chats guids.</returns>
		public List<Guid> GetBotProcessingChatIds(Guid channelId, string sender) {
			IEnumerable<UnifiedMessage> messages = GetMessagesByChannelId(channelId);
			return messages.Where(m => m.Sender == sender)
				.Select(m => Guid.Parse(m.ChatId)).Distinct()
				.ToList();
		}

		/// <summary>
		/// Get chats with bot by channel.
		/// </summary>
		/// <param name="channelId">Id of channel.</param>
		/// <returns>List of chats guids.</returns>
		public IEnumerable<UnifiedMessage> GetBotProcessingMessages(Guid channelId) {
			return GetMessagesByChannelId(channelId);
		}

		/// <summary>
		/// Delete unnecessary chats .
		/// </summary>
		/// <param name="chatsId">Identifiers of chats.</param>
		public void DeleteUnnecessaryChats(IEnumerable<Guid> chatsId) {
			if (chatsId.Any()) {
				Query delete = new Delete(_userConnection)
					.From("OmniChat")
					.Where("Id")
						.In(Column.Parameters(chatsId));
				delete.Execute();
			}
		}

		/// <summary>
		/// Returns operator's identifier by chat identifier
		/// </summary>
		/// <param name="chatId">Identifier of chat</param>
		/// <returns>Operator's identifier</returns>
		public Guid GetOperatorIdByChatId(Guid chatId) {
			var select = new Select(_userConnection).Top(1)
				.Column("OperatorId")
				.From("OmniChat")
				.Where("Id").IsEqual(Column.Parameter(chatId)) as Select;
			return select.ExecuteScalar<Guid>();
		}

		#endregion

	}

	#endregion

}
