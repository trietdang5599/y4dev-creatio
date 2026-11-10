namespace Terrasoft.Configuration.Omnichannel.Messaging
{
	using global::Common.Logging;
	using OmnichannelMessaging;
	using OmnichannelProviders.Domain.Entities;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Terrasoft.Common;
	using Terrasoft.Configuration.Omnichannel.Translating;
	using Terrasoft.Configuration.RightsService;
	using Terrasoft.Configuration.Translating;
	using Terrasoft.Core;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Factories;
	using Terrasoft.Core.ServiceModelContract;
	using Terrasoft.Core.Tasks;
	using MessageDirection = OmnichannelProviders.Domain.Entities.MessageDirection;

	/// <summary>
	/// Class container for chat Chat data.
	/// </summary>
	public class ChatData
	{
		/// <summary>
		/// Indicates whether the chat message requires translation.
		/// </summary>
		public bool NeedsTranslation;

		/// <summary>
		/// The chat's language identifier.
		/// </summary>
		public Guid LanguageId;

		/// <summary>
		/// The identifier of the language to which the message should be translated.
		/// </summary>
		public Guid TranslatedLangId;
	}

	/// <summary>
	/// Encapsulates contact, operator, and chat data for omnichannel chat context.
	/// </summary>
	public class ChatContextData
	{
		/// <summary>
		/// Gets or sets the contact information associated with the chat.
		/// </summary>
		public ChatContact Contact {
			get; set;
		}

		/// <summary>
		/// Gets or sets the operator information associated with the chat.
		/// </summary>
		public ChatContact Operator {
			get; set;
		}

		/// <summary>
		/// Gets or sets the translation-related data for the chat.
		/// </summary>
		public ChatData ChatData {
			get; set;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ChatContextData"/> class.
		/// </summary>
		/// <param name="contact">The contact information for the chat.</param>
		/// <param name="operator">The operator information for the chat.</param>
		/// <param name="chatData">The translation-related data for the chat.</param>
		public ChatContextData(ChatContact contact, ChatContact @operator, ChatData chatData) {
			Contact = contact;
			Operator = @operator;
			ChatData = chatData;
		}
	}

	#region Class: OmnichannelChatProvider

	/// <summary>
	/// Provides a class for working with omnichannel chats.
	/// </summary>
	public class OmnichannelChatProvider
	{

		#region Fields: Private	

		private readonly UserConnection _userConnection;

		private static readonly string _dateFormat = "yyyy'-'MM'-'ddTHH':'mm':'ss";

		private readonly ChatOperatorCache _chatOperatorCache;

		private readonly ChatRepository _chatRepository;

		private readonly List<string> _contactColumns = new List<string> {
			"Contact.Id",
			"Contact.Name",
			"Contact.Photo",
			"Contact.Email",
			"Contact.Account.Id",
			"Contact.Account.Name"
		};

		private readonly List<string> _operatorColumns = new List<string> {
			"Operator",
			"Operator.SysCulture.Id",
			"Operator.Contact.Id",
			"Operator.Contact.Name",
			"Operator.Contact.Photo"
		};

		#endregion

		#region Constructors: Public

		public OmnichannelChatProvider(UserConnection userConnection) {
			_userConnection = userConnection;
			_chatOperatorCache = new ChatOperatorCache(userConnection);
			_chatRepository = new ChatRepository(userConnection);
		}

		#endregion

		#region Properties: Protected

		private ChatOperatorNotifier _operatorNotifier;
		protected ChatOperatorNotifier OperatorNotifier {
			get	{
				return _operatorNotifier = _operatorNotifier ?? new ChatOperatorNotifier(_userConnection);
			}
		}

		private OmnichannelMessageConverterResolver _messageConverterResolver;
		protected OmnichannelMessageConverterResolver MessageConverterResolver {
			get	{
				return _messageConverterResolver = _messageConverterResolver ?? new OmnichannelMessageConverterResolver(_userConnection);
			}
		}

		private OperatorManager _operatorManager;
		protected OperatorManager OperatorManager {
			get
			{
				return _operatorManager ?? (_operatorManager = new OperatorManager(_userConnection));
			}
		}

		private TranslateProviderFactory _translateProviderFactory;
		/// <summary>
		/// Factory for creating and managing instances of ITranslateProvider..
		/// </summary>
		protected TranslateProviderFactory TranslateProviderFactory {
			get	{
				return _translateProviderFactory = _translateProviderFactory ?? new TranslateProviderFactory(_userConnection);
			}
		}

		private ITranslatedChatCache _translatedChatCache;
		/// <summary>
		/// Cache for storing translated chat messages <see cref="TranslatedChatCache"/> class.
		/// </summary>
		protected ITranslatedChatCache TranslatedChatCache {
			get	{
				return _translatedChatCache = _translatedChatCache ?? new TranslatedChatCache();
			}
		}

		private MessageManager _messageManager;
		/// <summary>
		/// Class which save and send messages <see cref="MessageManager"/> class.
		/// </summary>
		protected MessageManager MessageManager {
			get	{
				return _messageManager = _messageManager ?? new MessageManager(_userConnection);
			}
		}

		/// <summary>
		/// <see cref="ILog"/> implementation instance.
		/// </summary>
		private ILog _detailsLogger;
		protected ILog DetailsLogger {
			get	{
				return _detailsLogger ?? (_detailsLogger = LogManager.GetLogger("OmnichannelDetails"));
			}
		}

		private RightsHelper _rightsHelper;
		protected RightsHelper RightsHelper =>
			_rightsHelper ?? (_rightsHelper = ClassFactory.Get<RightsHelper>(
				new ConstructorArgument("userConnection", _userConnection)));

		#endregion

		#region Methods: Private

		private static Func<UnifiedMessage, bool> NotSystemMessage() {
			return m => m.MessageType != OmnichannelProviders.Domain.Entities.MessageType.System;
		}

		private bool AssignOperator(Guid chatId, Guid operatorId, Predicate<Entity> predicate) {
			var chatEsq = CreateEsqWithColumns(new List<string> {
				"Status",
				"Operator",
				"AcceptDate",
				"DirectedOperator",
				"CloseDate",
				"Queue"
			});
			var chat = chatEsq.GetEntity(_userConnection, chatId);
			if (predicate(chat)) {
				chat.SetColumnValue("StatusId", OmnichannelMessagingConsts.InProgressChatStatus);
				chat.SetColumnValue("OperatorId", operatorId);
				if (_userConnection.GetIsFeatureEnabled("SetCloseDateOnOutgoingMessage")) {
					_chatRepository.SetCloseDate(chat);
				} else {
					chat.SetColumnValue("CloseDate", null);
				}
				_chatOperatorCache.UpdateActiveChatsCount(operatorId, 1);
				_chatOperatorCache.RemoveDirectedChat(chatId);
				return chat.Save(false);
			}
			return false;
		}

		private ChatContextData GetContactAndOperatorDataByChatId(Guid chatId, bool isNeedToCheckTranslate = false) {
			List<string> contactAndOperatorColumns = _contactColumns.Concat(_operatorColumns).ToList();
			var chatEsq = CreateEsqWithColumns(contactAndOperatorColumns);
			chatEsq.AddColumn("NeedsTranslation");
			chatEsq.AddColumn("Language");
			chatEsq.AddColumn("TranslatedLang");
			var chat = chatEsq.GetEntity(_userConnection, chatId);
			ChatData chatData = null;
			if (isNeedToCheckTranslate) {
				chatData = new ChatData {
					NeedsTranslation = chat.GetTypedColumnValue<bool>("NeedsTranslation"),
					LanguageId = chat.GetTypedColumnValue<Guid>("LanguageId"),
					TranslatedLangId = chat.GetTypedColumnValue<Guid>("TranslatedLangId"),
				};
			}
			return new ChatContextData(GetContactDataByEntity(chat), GetOperatorDataByEntity(chat), chatData);
		}

		private ChatContact GetContactDataByChatId(Guid chatId) {
			var chatEsq = CreateEsqWithColumns(_contactColumns);
			var chat = chatEsq.GetEntity(_userConnection, chatId);
			return GetContactDataByEntity(chat);
		}

		private Dictionary<Guid, ChatContextData> GetChatContextsByChatIds(IEnumerable<Guid> chatIds) {
			var distinctChatIds = chatIds.Distinct().ToList();
			if (!distinctChatIds.Any()) {
				return new Dictionary<Guid, ChatContextData>();
			}
			var contactData = GetContactDataByChatId(distinctChatIds.First());
			var operators = GetOperatorsDataByChatId(distinctChatIds);
			return distinctChatIds.ToDictionary(
				id => id,
				id => new ChatContextData(contactData,
					operators.ContainsKey(id) ? operators[id] : new ChatContact(), null));
		}

		private Dictionary<Guid, ChatContact> GetOperatorsDataByChatId(List<Guid> chatIds) {
			var chatEsq = CreateEsqWithColumns(_operatorColumns);
			var primaryColumnFilter = chatEsq.CreateFilterWithParameters(FilterComparisonType.Equal, "Id",
				chatIds.Cast<object>().ToArray());
			chatEsq.Filters.Add(primaryColumnFilter);
			var chats = chatEsq.GetEntityCollection(_userConnection);
			var result = new Dictionary<Guid, ChatContact>();
			foreach (Guid chatId in chatIds) {
				var chat = chats.Find(chatId);
				result.Add(chatId, GetOperatorDataByEntity(chat));
			}
			return result;
		}

		private ChatContact GetContactDataByEntity(Entity chat) {
			var contactId = chat.GetTypedColumnValue<Guid>("Contact_Id");
			if (contactId == Guid.Empty) {
				return new ChatContact {
					Id = Guid.Empty,
					Name = OmnichannelMessagingConsts.AnonymousUserDisplayName,
					PhotoId = Guid.Empty
				};
			}
			return new ChatContact {
				Id = contactId,
				Name = chat.GetTypedColumnValue<string>("Contact_Name"),
				PhotoId = chat.GetTypedColumnValue<Guid>("Contact_PhotoId"),
				Email = chat.GetTypedColumnValue<string>("Contact_Email"),
				Account = new LookupValue {
					Value = chat.GetTypedColumnValue<Guid>("Contact_Account_Id"),
					DisplayValue = chat.GetTypedColumnValue<string>("Contact_Account_Name")
				}
			};
		}

		private ChatContact GetOperatorDataByEntity(Entity chat) {
			var chatContact = chat.GetTypedColumnValue<Guid>("OperatorId") != default ? new ChatContact {
				Id = chat.GetTypedColumnValue<Guid>("Operator_Contact_Id"),
				Name = chat.GetTypedColumnValue<string>("Operator_Contact_Name"),
				PhotoId = chat.GetTypedColumnValue<Guid>("Operator_Contact_PhotoId"),
				SysCultureId = chat.GetTypedColumnValue<Guid>("Operator_SysCulture_Id")
			} : new ChatContact();
			return chatContact;
		}

		private EntitySchemaQuery CreateEsqWithColumns(List<string> chatColumns) {
			var chatEsq = new EntitySchemaQuery(_userConnection.EntitySchemaManager, "OmniChat");
			chatEsq.UseAdminRights = false;
			chatEsq.PrimaryQueryColumn.IsAlwaysSelect = true;
			foreach (var column in chatColumns) {
				chatEsq.AddColumn(column);
			}
			OmnichatEsqColumnsAppender.AddLoggedColumns(chatEsq);
			return chatEsq;
		}

		private string GetOperatorDisplayName(Entity chat) {
			string contactName = chat.GetTypedColumnValue<string>("Operator_Contact_Name");
			if (!string.IsNullOrEmpty(contactName)) {
				return contactName;
			}
			return chat.GetTypedColumnValue<string>("Operator_Name");
		}

		private bool TryGetOperatorLanguageShortCode(ChatContextData contextData, out string shortCode) {
			shortCode = null;
			if (contextData.ChatData?.TranslatedLangId != Guid.Empty) {
				if (LanguageRegistry.TryGetById(contextData.ChatData.TranslatedLangId, out var langInfo) && langInfo != null) {
					shortCode = langInfo.ShortCode;
					return true;
				}
			} else {
				var translatedLanguage = contextData.Operator?.SysCultureId ?? Guid.Empty;
				if (translatedLanguage != Guid.Empty &&
					LanguageRegistry.TryGetShortByCultureId(translatedLanguage, out string targetCode)) {
					shortCode = targetCode;
					return true;
				}
			}
			return false;
		}

		private ChatMessage MapChatMessage(UnifiedMessage message, ChatContextData contextData) {
			var chatMessage = new ChatMessage {
				Id = message.Id,
				Author = message.MessageDirection == MessageDirection.Incoming ?
							contextData.Contact : contextData.Operator,
				Time = GetTimeInUserTimeZone(message.Timestamp).ToString(_dateFormat),
				OriginalText = IsTranslationRequired(contextData) ? message.Message : string.Empty,
				Text = TranslateTextIfNeeded(message, contextData),
				Direction = message.MessageDirection,
				Type = message.MessageType,
				Attachments = message.Attachments,
				IsBotMessage = message.IsEcho,
				ChatId = Guid.Parse(message.ChatId),
				Status = message.Status,
				DeliveryError = message.DeliveryError.HasValue ? (int)message.DeliveryError.Value : 0
			};
			if (message.MacrosId != Guid.Empty) {
				try {
					IOmnichannelMessageMacrosConverter converter = MessageConverterResolver.GetConverterByMacros(message.MacrosId);
					chatMessage.MacrosTempale = converter?.Convert(message.MacrosId, message.Metadata);
				} catch (Exception ex) {
					DetailsLogger.ErrorFormat($"An error occured while converting macros template: MacrosId={message.MacrosId}, Metadata={message.Metadata}, Exception: {ex}");
				}
			}
			if (IsTranslationRequired(contextData) &&
				TryGetOperatorLanguageShortCode(contextData, out string targetCode)) {
				try {
					Guid chatId = Guid.Parse(message.ChatId);
					TranslatedChatCache.AddTranslatedMessage(chatId, targetCode, chatMessage);
					chatMessage.IsTranslated = true;
				} catch (Exception ex) {
					DetailsLogger.ErrorFormat($"An error occurred while adding translated message to cache: Exception {ex.Message}");
				}
			}
			return chatMessage;
		}

		private bool IsTranslationRequired(ChatContextData contextData) {
			return contextData.ChatData != null && contextData.ChatData.NeedsTranslation;
		}

		private string TranslateTextIfNeeded(UnifiedMessage message, ChatContextData contextData) {
			if (IsTranslationRequired(contextData) &&
				TryGetOperatorLanguageShortCode(contextData, out string targetCode) &&
				LanguageRegistry.TryGetShortById(contextData.ChatData.LanguageId, out string sourceCode)) {
				var provider = TranslateProviderFactory.Get();
				if (provider == null) {
					return message.Message;
				}
				return provider.TranslateText(message.Message, targetCode, sourceCode);
			}
			return message.Message;
		}

		private Guid GetParentChatId(Guid chatId) {
			var chatQuery = new Select(_userConnection)
				.Column("ParentId")
				.From("OmniChat", "oc")
				.Where("oc", "Id").IsEqual(Column.Parameter(chatId))
				 as Select;
			return chatQuery.ExecuteScalar<Guid>();
        }

        private List<string> GetContactIdentity(Guid contactId, Guid channelId)
        {
			var select = new Select(_userConnection)
				.Column("ChannelIdentity")
				.Column("AlternateChannelIdentity")
				.From("ContactIdentity", "ci")
				.InnerJoin("Channel").As("c").On("c", "Id").IsEqual(Column.Parameter(channelId))
				.InnerJoin("Channel").As("cc").On("cc", "ProviderId").IsEqual("c", "ProviderId")
				.Where("ci", "ChannelId").In(Column.SourceColumn("cc", "Id"))
					.And("ci", "ContactId").IsEqual(Column.Parameter(contactId)) as Select;
			List<string> identities = new List<string>();
            using (DBExecutor dbExecutor = _userConnection.EnsureDBConnection())
            {
                using (var dataReader = select.ExecuteReader(dbExecutor))
                {
                    while (dataReader.Read())
                    {
						var alternateIdentity = dataReader.GetColumnValue<string>("AlternateChannelIdentity");
						if (!string.IsNullOrWhiteSpace(alternateIdentity))
						{
							identities.Add(alternateIdentity);
						}
                        var mainIdentity = dataReader.GetColumnValue<string>("ChannelIdentity");
						if (!string.IsNullOrWhiteSpace(mainIdentity))
						{
							identities.Add(mainIdentity);
						}
                    }
                }
            }
			return identities.Distinct().ToList();
        }

		private List<Guid> GetOperatorsIds(string chatId, Guid queueId) {
			List<Guid> operatorIds = new List<Guid>();
			if (queueId == Guid.Empty) {
				Guid operatorId = _chatRepository.GetOperatorIdByChatId(Guid.Parse(chatId));
				if (operatorId != Guid.Empty) {
					operatorIds.Add(operatorId);
				}
			} else {
				operatorIds = OperatorManager.GetOperatorIds(chatId, queueId);
				DetailsLogger.DebugFormat($"Get operatorIds for chat {chatId} Operators: {string.Join(", ", operatorIds)}");
			}

			return operatorIds;
		}

		private ChatMessage GetMessageByChatId(string chatId, MessagingMessage message) {
			ChatMessage msg;
			if (message == null) {
				msg = GetChatMessages(Guid.Parse(chatId)).LastOrDefault();
			} else {
				var contextData = GetContactAndOperatorDataByChatId(new Guid(chatId), true);
				msg = MapChatMessage(message, contextData);
			}
			return msg;
		}

		private UnifiedMessage GetLastNonSystemMessageInChatHierarchy(Guid chatId, int currentHiearachyLevel = 1) {
			Guid parentChatId = GetParentChatId(chatId);
			if (parentChatId == Guid.Empty) {
				return null;
			}
			var lastMessage = MessageManager.GetMessagesByChatId(parentChatId).Where(NotSystemMessage()).LastOrDefault();
			return (lastMessage != null || currentHiearachyLevel > 10) ? lastMessage : GetLastNonSystemMessageInChatHierarchy(parentChatId, ++currentHiearachyLevel);
		}

		private (List<Guid> chatIds, List<UnifiedMessage> messages) GetAccessibleChatsAndMessages(
			IEnumerable<UnifiedMessage> allMessages, Guid contactId, Guid channelId) {
			var allContactChatIds = allMessages
				.Select(m => Guid.Parse(m.ChatId))
				.Distinct()
				.ToList();
			var chatIds = allContactChatIds
				.Where(chatId => RightsHelper.GetCanReadSchemaRecordRight("OmniChat", chatId))
				.ToList();
			var deniedChatIds = allContactChatIds.Except(chatIds).ToList();
			if (deniedChatIds.Any()) {
				DetailsLogger.ErrorFormat(
					"User {0} does not have read rights for the following OmniChat records: {1}, for Contact {2} in channel {3}",
					_userConnection.CurrentUser.Name, string.Join(", ", deniedChatIds), contactId, channelId);
			}
			var accessibleMessages = allMessages
				.Where(m => !deniedChatIds.Contains(Guid.Parse(m.ChatId)))
				.ToList();
			return (chatIds, accessibleMessages);
		}

		private string GetTargetLanguageCode(string translationLanguageCode, ChatContact operatorData) {
			if (!string.IsNullOrWhiteSpace(translationLanguageCode) &&
				LanguageRegistry.TryGetByCode(translationLanguageCode, out var langInfo)) {
				return langInfo.ShortCode;
			}
			if (operatorData != null && operatorData.SysCultureId != Guid.Empty &&
				LanguageRegistry.TryGetShortByCultureId(operatorData.SysCultureId, out string sysCultureTarget)) {
				return sysCultureTarget;
			}
			return null;
		}
		
		/// <summary>
		/// Retrieves all messages for an anonymous (guest) chat using sender identity directly,
		/// bypassing the ContactIdentity table lookup.
		/// </summary>
		/// <param name="senderIdentity">The sender identity string (e.g. WebChat visitorId).</param>
		/// <param name="channelId">The channel identifier.</param>
		/// <param name="chatId">The chat identifier to get context data from.</param>
		/// <param name="rowCount">Number of rows to retrieve.</param>
		/// <param name="rowOffset">Number of rows to skip.</param>
		/// <returns>Collection of chat messages.</returns>
		private IEnumerable<ChatMessage> GetAllMessagesBySender(string senderIdentity, Guid channelId,
				Guid chatId, int rowCount = 50, int rowOffset = 0) {
			var result = new List<ChatMessage>();
			List<UnifiedMessage> allMessages =
				MessageManager.GetMessagesBySender(senderIdentity, channelId, rowCount, rowOffset).ToList();
			if (allMessages.Any()) {
				List<Guid> messageChatIds = allMessages
					.Select(message => {
						Guid messageChatId;
						return Guid.TryParse(message.ChatId, out messageChatId) ? messageChatId : Guid.Empty;
					})
					.Where(id => id != Guid.Empty)
					.Distinct()
					.ToList();
				var chatContexts = GetChatContextsByChatIds(messageChatIds);
				ChatContextData defaultContextData = chatContexts.ContainsKey(chatId)
					? chatContexts[chatId]
					: GetContactAndOperatorDataByChatId(chatId);
				foreach (var message in allMessages) {
					Guid messageChatId;
					ChatContextData contextData;
					if (!Guid.TryParse(message.ChatId, out messageChatId) ||
							!chatContexts.TryGetValue(messageChatId, out contextData)) {
						contextData = defaultContextData;
					}
					result.Add(MapChatMessage(message, contextData));
				}
			}
			return result;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Assigns operator to the chat.
		/// </summary>
		/// <param name="chatId">Identifier of chat.</param>
		/// <param name="operatorId">Identifier of operator.</param>
		/// <param name="assigningCondition">Operator assigning condition.</param>
		/// <returns>True if operator was assigned, otherwise returns false.</returns>
		public virtual bool AssignChatOperator(Guid chatId, Guid operatorId, Predicate<Entity> assigningCondition) {
			DetailsLogger.DebugFormat($"Assigning chat with id {chatId} to operator {operatorId}");
			var isOperatorAssigned = AssignOperator(chatId, operatorId, assigningCondition);
			if (isOperatorAssigned) {
				if (_userConnection.GetIsFeatureEnabled("OmnichannelOptimization")) {
					Task.StartNewWithUserConnection<OmnichannelAssignChatOperatorBackgroundTask,
							OmnichannelAssignChatOperatorBackgroundTaskDto>(
						new OmnichannelAssignChatOperatorBackgroundTaskDto {
							ChatId = chatId,
							OperatorId = operatorId
						}
					);
				} else {
					DistributeAndNotifyAfterAssignment(chatId, operatorId);
				}
			}
			return isOperatorAssigned;
		}

		/// <summary>
		/// Distributes chat to queue and notifies operators after chat assignment.
		/// </summary>
		/// <param name="chatId">Identifier of chat.</param>
		/// <param name="operatorId">Identifier of operator.</param>
		public virtual void DistributeAndNotifyAfterAssignment(Guid chatId, Guid operatorId) {
			DetailsLogger.DebugFormat($"Chat with id {chatId} was assigned to operator {operatorId}");
			var chatDistributor = new ChatQueueDistributor(_userConnection);
			DetailsLogger.DebugFormat($"Distributing chat with id {chatId}");
			var chatQueue = _chatRepository.GetChatQueueId(chatId);
			if (chatDistributor.Distribute(chatQueue, 1) == 0) {
				var chatQueueIds = OperatorManager.GetQueuesByOperator(operatorId)
					.Where(id => id != chatQueue)
					.ToList();
				foreach (var chatQueueId in chatQueueIds) {
					if (chatDistributor.Distribute(chatQueueId, 1) > 0) {
						break;
					}
				}
			}
			DetailsLogger.DebugFormat($"Chat with id {chatId} was distributed to queue {chatQueue}");
			DetailsLogger.DebugFormat($"Loading operators for chat {chatId} from cache");
			var operators = _chatOperatorCache.GetOperatorsCache()
				.Where(op => op.ChatQueues.Contains(chatQueue))
				.Select(o => o.UserId)
				.ToList();
			DetailsLogger.DebugFormat($"Operators for chat {chatId} were loaded from cache");
			OperatorNotifier.AcceptChatNotifyAsync(operators, chatId, operatorId);
		}

		/// <summary>
		/// Get count of unread chats.
		/// </summary>
		/// <param name="operatorId">Id of operator.</param>
		/// <returns>Count of unread chats.</returns>
		public virtual int GetUnreadChatsCount(Guid operatorId) {
			var chats = OperatorManager.GetChatsByOperator(operatorId, false);
			var chatsId = chats.Select((record) => record.GetTypedColumnValue<Guid>("Id")).ToList();
			var count = 0;
			if (chatsId.Any()) {
				count = (new Select(_userConnection)
				.Column(Func.Count("Id"))
				.From("OmniChat", "oc")
				.Where("oc", "UnprocessedMsgCount").IsGreater(Column.Const(0))
					.And("oc", "Id").In(Column.Parameters(chatsId))
				.CloseBlock() as Select)
				.ExecuteScalar<int>();
			}
			return count;
		}

		/// <summary>
		/// Get count of unread messages in current user and unassigned chats.
		/// </summary>
		/// <returns>Key-value pair array with chat id and unread messages count.</returns>
		public virtual Dictionary<Guid, int> GetUnreadMessagesCount() {
			Select newMessagesSelect = new Select(_userConnection)
				.Column("Id")
				.Column("UnprocessedMsgCount")
				.From("OmniChat", "oc")
				.Where()
				.OpenBlock("oc", "OperatorId").IsNull()
					.Or("oc", "OperatorId").IsEqual(Column.Parameter(_userConnection.CurrentUser.Id))
				.CloseBlock() as Select;
			return newMessagesSelect.ExecuteEnumerable(
				reader => new KeyValuePair<Guid, int>(
					reader.GetColumnValue<Guid>("Id"),
					reader.GetColumnValue<int>("UnprocessedMsgCount")))
				.ToDictionary(x => x.Key, x => x.Value);
		}

		/// <summary>
		/// Get chat messages.
		/// </summary>
		/// <param name="chatId">Id of chat.</param>
		/// <returns>Collection with messages.</returns>
		public virtual IEnumerable<ChatMessage> GetChatMessages(Guid chatId) {
			List<ChatMessage> result = new List<ChatMessage>();
			if (chatId != default(Guid)) {
				List<Guid> chatsId = _chatRepository.GetRelatedChatsId(chatId).ToList();
				if (!chatsId.Any()) {
					return result;
				}
				List<UnifiedMessage> unifiedMessages = MessageManager.GetMessagesByChatId(chatsId).ToList();
				var chatContexts = GetChatContextsByChatIds(chatsId);
				ChatContextData defaultContextData = chatContexts.ContainsKey(chatId)
					? chatContexts[chatId]
					: GetContactAndOperatorDataByChatId(chatId);
				foreach (var message in unifiedMessages) {
					Guid messageChatId;
					ChatContextData contextData;
					if (!Guid.TryParse(message.ChatId, out messageChatId) ||
							!chatContexts.TryGetValue(messageChatId, out contextData)) {
						contextData = defaultContextData;
					}
					result.Add(MapChatMessage(message, contextData));
				}
			}
			return result;
		}

		/// <summary>
		/// Get contact messages.
		/// </summary>
		/// <param name="contactId">Id of contact.</param>
		/// <param name="channelId">Id of channel.</param>
		/// <param name="rowCount">Count of rows.</param>
		/// <param name="rowOffset">Rows offset.</param>
		/// <param name="translationLanguageCode">
		/// Optional language code (e.g., "en-US") for message translation. 
		/// If specified, messages will be translated to this language if available; 
		/// otherwise, operator's system culture will be used.
		/// </param>
		/// <returns>Collection with messages.</returns>
		public virtual IEnumerable<ChatMessage> GetAllMessages(Guid contactId, Guid channelId, int rowCount = 50, int rowOffset = 0, string translationLanguageCode = null) {
			List<ChatMessage> result = new List<ChatMessage>();
			var sender = GetContactIdentity(contactId, channelId);
			if (sender.IsNullOrEmpty()) {
				DetailsLogger.ErrorFormat($"Contact identity was not found by ContactId [{contactId}] and ChannelId [{channelId}]");
				return result;
			}
			var allMessages = MessageManager.GetMessagesBySender(sender, channelId, rowCount, rowOffset);
			if (allMessages.Any()) {
				var (chatIds, accessibleMessages) = GetAccessibleChatsAndMessages(allMessages, contactId, channelId);
				allMessages = accessibleMessages;
				ChatContact contactData = GetContactDataByChatId(chatIds.FirstOrDefault());
				Dictionary<Guid, ChatContact> operators = GetOperatorsDataByChatId(chatIds);
				foreach (KeyValuePair<Guid, ChatContact> entry in operators) {
					var chatId = entry.Key;
					var operatorData = entry.Value;
					ChatContextData contextData = new ChatContextData(contactData, operatorData, null);
					IEnumerable<UnifiedMessage> messages = allMessages.Where(m => chatId.Equals(Guid.Parse(m.ChatId))).ToList();
					var chatMessages = messages.Select(m => MapChatMessage(m, contextData)).ToList();

					string targetLanguage = GetTargetLanguageCode(translationLanguageCode, operatorData);
					if (!string.IsNullOrEmpty(targetLanguage)) {
						var cachedMessages = TranslatedChatCache.GetTranslatedChat(chatId, targetLanguage);
						if (cachedMessages?.Any() == true) {
							ChatMessageTranslationMapper.ApplyTranslations(chatMessages, cachedMessages);
						}
					}
					result.AddRange(chatMessages);
				}
			}
			return result;
		}

		/// <summary>
		/// Retrieves all messages associated with a specific chat.
		/// </summary>
		/// <param name="chatId">The unique identifier of the chat.</param>
		/// <param name="rowCount">The number of rows to retrieve. Default is 50.</param>
		/// <param name="rowOffset">The number of rows to skip. Default is 0.</param>
		/// <returns>An enumerable collection of chat messages.</returns>
		public virtual IEnumerable<ChatMessage> GetAllMessagesByChat(Guid chatId, int rowCount = 50, int rowOffset = 0) {
			var chatEsq = CreateEsqWithColumns(new List<string> {
				"Contact.Id",
				"Channel.Id",
				"SenderIdentity"
			});
			var chat = chatEsq.GetEntity(_userConnection, chatId);
			var contactId = chat.GetTypedColumnValue<Guid>("Contact_Id");
			var channelId = chat.GetTypedColumnValue<Guid>("Channel_Id");
			if (contactId != Guid.Empty) {
				return GetAllMessages(contactId, channelId, rowCount, rowOffset);
			}
			// For anonymous (guest) chats without a contact, use SenderIdentity directly
			var senderIdentity = chat.GetTypedColumnValue<string>("SenderIdentity");
			if (string.IsNullOrEmpty(senderIdentity)) {
				DetailsLogger.ErrorFormat($"No ContactId or SenderIdentity found for chat [{chatId}]");
				return new List<ChatMessage>();
			}
			return GetAllMessagesBySender(senderIdentity, channelId, chatId, rowCount, rowOffset);
		}

		/// <summary>
		/// Retrieves the previous chat ID based on the current chat ID.
		/// </summary>
		/// <param name="chatId">The unique identifier of the current chat.</param>
		/// <returns>The unique identifier of the previous chat, or Guid.Empty if not found.</returns>
		public virtual Guid GetPreviousChatId(Guid chatId) {
			EntitySchema chatSchema = _userConnection.EntitySchemaManager.GetInstanceByName("OmniChat");
			Entity currentChat = chatSchema.CreateEntity(_userConnection);
			if (!currentChat.FetchFromDB(chatId)) {
				return Guid.Empty;
			}
			var currentChannelId = currentChat.GetTypedColumnValue<Guid>("ChannelId");
			var currentContactId = currentChat.GetTypedColumnValue<Guid>("ContactId");
			var currentSenderIdentity = currentChat.GetTypedColumnValue<string>("SenderIdentity");
			var currentChatStartDate = currentChat.GetTypedColumnValue<DateTime>("CreatedOn");
			var chatEsq = new EntitySchemaQuery(chatSchema);
			chatEsq.RowCount = 1;
			chatEsq.PrimaryQueryColumn.IsAlwaysSelect = true;
			chatEsq.AddColumn("CreatedOn").OrderByDesc();
			chatEsq.Filters.Add(chatEsq.CreateFilterWithParameters(FilterComparisonType.Equal, "Channel", currentChannelId));
			if (currentContactId != Guid.Empty) {
				chatEsq.Filters.Add(chatEsq.CreateFilterWithParameters(FilterComparisonType.Equal, "Contact", currentContactId));
			} else if (!string.IsNullOrEmpty(currentSenderIdentity)) {
				chatEsq.Filters.Add(chatEsq.CreateFilterWithParameters(FilterComparisonType.Equal, "SenderIdentity", currentSenderIdentity));
			} else {
				return Guid.Empty;
			}
			chatEsq.Filters.Add(chatEsq.CreateFilterWithParameters(FilterComparisonType.Less, "CreatedOn", currentChatStartDate));
			var previousChatCollection = chatEsq.GetEntityCollection(_userConnection);
			if (previousChatCollection.Count == 0) {
				return Guid.Empty;
			}
			return previousChatCollection[0].PrimaryColumnValue;
		}

		/// <summary>
		/// Get chat message from unified message.
		/// </summary>
		/// <param name="message">Unified message.</param>
		/// <returns>Collection with messages.</returns>
		public virtual ChatMessage GetChatMessage(UnifiedMessage message) {
			var contextData = GetContactAndOperatorDataByChatId(Guid.Parse(message.ChatId), true);
			return MapChatMessage(message, contextData);
		}

		/// <summary>
		/// Gets history by chat identifier.
		/// </summary>
		/// <param name="chatId">Chat identifier</param>
		/// <returns>Collection of chat messages.</returns>
		public virtual IEnumerable<ChatMessage> GetChatHistory(Guid chatId) {
			List<UnifiedMessage> unifiedMessages = _chatRepository.GetChatConversation(chatId).ToList();
			List<Guid> messageChatIds = unifiedMessages
				.Select(message => {
					Guid messageChatId;
					return Guid.TryParse(message.ChatId, out messageChatId) ? messageChatId : Guid.Empty;
				})
				.Where(id => id != Guid.Empty)
				.Distinct()
				.ToList();
			var chatContexts = GetChatContextsByChatIds(messageChatIds);
			ChatContextData defaultContextData = chatContexts.ContainsKey(chatId)
				? chatContexts[chatId]
				: GetContactAndOperatorDataByChatId(chatId);
			var result = new List<ChatMessage>(unifiedMessages.Count);
			foreach (var message in unifiedMessages) {
				Guid messageChatId;
				ChatContextData contextData;
				if (!Guid.TryParse(message.ChatId, out messageChatId) ||
						!chatContexts.TryGetValue(messageChatId, out contextData)) {
					contextData = defaultContextData;
				}
				result.Add(MapChatMessage(message, contextData));
			}
			return result;
		}

		/// <summary>
		/// Get pre-filled Unified message template.
		/// </summary>
		/// <param name="ChatId">Chat identifier.</param>
		public virtual UnifiedMessage GetOutcomingMessageTemplate(Guid chatId) {
			if (chatId != default(Guid)) {
				var messages = MessageManager.GetMessagesByChatId(chatId).Where(NotSystemMessage());
				var unifiedMessage = messages.Any() ? messages.LastOrDefault() : GetLastNonSystemMessageInChatHierarchy(chatId);
				if (unifiedMessage != null) {
					return new UnifiedMessage {
						Recipient = unifiedMessage.MessageDirection == MessageDirection.Incoming ?
						unifiedMessage.Sender : unifiedMessage.Recipient,
						Sender = unifiedMessage.MessageDirection == MessageDirection.Incoming ?
						unifiedMessage.Recipient : unifiedMessage.Sender,
						MessageDirection = MessageDirection.Outcoming,
						ChatId = chatId.ToString(),
						ChannelId = unifiedMessage.ChannelId,
						Source = unifiedMessage.Source,
						MessageType = OmnichannelProviders.Domain.Entities.MessageType.Text
					};
				}
				DetailsLogger.Error($"Cannot get Outcoming message template for chat {chatId}: no template found.");
			} else {
				DetailsLogger.Error("Cannot get Outcoming message template: chatID is empty.");
			}
			return new UnifiedMessage();
		}

		/// <summary>
		/// Mark all chat messages as processed.
		/// </summary>
		/// <param name="ChatId">Id of chat.</param>
		public virtual void MarkChatAsRead(Guid chatId) {
			_chatRepository.MarkChatAsRead(chatId);
		}

		/// <summary>
		/// Sends all new chat notifications to available operators from <paramref name="queueId"/>.
		/// </summary>
		/// <param name="chatId">Chat identifier.</param>
		/// <param name="queueId">Channel queue identifier.</param>
		/// <param name="isNewChat">Is chat new flag.</param>
		/// <returns><c>True</c> if notification sent to any of operators. Otherwise returns <c>false</c>.</returns>
		public virtual bool DistributeChat(string chatId, Guid queueId, bool isNewChat = true, MessagingMessage message = null) {
			List<Guid> operatorIds = GetOperatorsIds(chatId, queueId);
			if (operatorIds.IsNullOrEmpty()) {
				DetailsLogger.DebugFormat($"Get operatorIds for chat {chatId} and queue {queueId} returned empty list");
				return false;
			}
			if (isNewChat) {
				foreach (var operatorId in operatorIds) {
					_chatOperatorCache.AddDirectedChat(new Guid(chatId), operatorId);
				}
				OperatorNotifier.NewIncomingChatNotify(operatorIds, chatId);
			} else {
				OperatorNotifier.NewMessageInChatNotify(operatorIds, chatId);
			}
			OperatorNotifier.NewUnreadMessageNotify(operatorIds, chatId);
			var msg = GetMessageByChatId(chatId, message);
			OperatorNotifier.NewConversationMessageNotify(operatorIds, chatId, msg);
			OperatorNotifier.UnreadChatsCountNotify(operatorIds);
			return true;
		}

		/// <summary>
		/// Returns operator name and queue name
		/// </summary>
		/// <param name="closedChatId">ID of closed chat</param>
		/// <param name="newChatId">ID of new created chat</param>
		/// <returns>Pair of operator name for closed chat and queue name for new chat</returns>
		public (string, string) GetOperatorAndQueueNameByChatId(Guid closedChatId, Guid newChatId) {
			var columns = new List<string> { "Operator.Name", "Queue.Name", "Operator.Contact.Name" };
			var chatEsq = CreateEsqWithColumns(columns);
			var oldChat = chatEsq.GetEntity(_userConnection, closedChatId);
			var newChat = chatEsq.GetEntity(_userConnection, newChatId);
			string operatorName = GetOperatorDisplayName(oldChat);
			string queueName = newChat.GetTypedColumnValue<string>("Queue_Name");
			return (operatorName, queueName);
		}

		/// <summary>
		/// Returns operator and directed operator names.
		/// </summary>
		/// <param name="closedChatId">Identifier of closed chat.</param>
		/// <param name="newChatId">Identified of new created chat.</param>
		/// <returns>Pair of operator names.</returns>
		public (string, string) GetOperatorAndDirectedOperatorNameByChatId(Guid closedChatId, Guid newChatId) {
			var columns = new List<string> { "Operator.Name", "Operator.Contact.Name" };
			var chatEsq = CreateEsqWithColumns(columns);
			var oldChat = chatEsq.GetEntity(_userConnection, closedChatId);
			var newChat = chatEsq.GetEntity(_userConnection, newChatId);
			string operatorName = GetOperatorDisplayName(oldChat);
			string directedOperatorName = GetOperatorDisplayName(newChat);
			return (operatorName, directedOperatorName);
		}

		/// <summary>
		/// Converts time to current user time zone.
		/// </summary>
		/// <param name="timestamp">Time to convert.</param>
		/// <returns>Converted time.</returns>
		public DateTime GetTimeInUserTimeZone(long timestamp) {
			DateTime dt = DateTimeOffset.FromUnixTimeMilliseconds(timestamp).UtcDateTime;
			return dt;
		}

		/// <summary>
		/// Checks if there are any uncompleted chats by channel.
		/// </summary>
		/// <param name="channelId">Id of channel.</param>
		/// <returns><c>True</c> if there are uncompleted chats. Otherwise returns <c>false</c>.</returns>
		public bool GetHasUncompletedChats(Guid channelId) {
			var omniChatEsq = CreateEsqWithColumns(new List<string> { });
			var countColumn = omniChatEsq.AddColumn("Id");
			countColumn.SummaryType = AggregationType.Count;
			omniChatEsq.Filters.Add(omniChatEsq.CreateFilterWithParameters(FilterComparisonType.Equal,
				"Channel", channelId));
			omniChatEsq.Filters.Add(omniChatEsq.CreateFilterWithParameters(FilterComparisonType.NotEqual,
				"Status", OmnichannelMessagingConsts.CompletedChatStatus));
			omniChatEsq.Filters.Add(omniChatEsq.CreateFilterWithParameters(FilterComparisonType.NotEqual,
				"Status", OmnichannelMessagingConsts.CompletedByBotChatStatus));
			omniChatEsq.Filters.Add(omniChatEsq.CreateFilterWithParameters(FilterComparisonType.NotEqual,
				"Status", OmnichannelMessagingConsts.HandedOverToAgent));
			var activeChats = omniChatEsq.GetSummaryEntity(_userConnection);
			return activeChats.GetTypedColumnValue<int>(countColumn.Name) > 0;
		}

		#endregion

	}

	#endregion

}

