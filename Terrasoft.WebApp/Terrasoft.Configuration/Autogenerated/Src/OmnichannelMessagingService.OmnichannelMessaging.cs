namespace Terrasoft.Configuration.Omnichannel.Messaging
{
	using global::Common.Logging;
	using OmnichannelMessaging;
	using OmnichannelMessaging.Utilities;
	using OmnichannelProviders.Domain.Entities;
	using Direction = OmnichannelProviders.Domain.Entities.MessageDirection;
	using System;
	using System.Collections.Generic;
	using System.Runtime.Serialization;
	using Terrasoft.Core.Factories;
	using Terrasoft.Core;
	using Terrasoft.Core.Requests;
	using Terrasoft.Monitoring;
	using Terrasoft.Web.Common;
	using System.Diagnostics;
	using Terrasoft.Configuration.BpmonlineCloudIntegration;
	using System.Linq;
	using Terrasoft.Common;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.Store;
	using Newtonsoft.Json;
	using OmnichannelMessaging.Exceptions;
	using Terrasoft.Configuration.FileUpload;
	using MessageType = OmnichannelProviders.Domain.Entities.MessageType;
	using SysSettings = Core.Configuration.SysSettings;
	using OmnichannelProviders.Exceptions;

	#region Class : ErrorGenerator
	/// <summary>
	/// Class for error keys generation
	/// </summary>
	public class ErrorKeysGenerator
	{
		/// <summary>
		/// Formats sending error key
		/// </summary>
		/// <param name="errorJson">Service response as JSON object</param>
		/// <returns>Error key, depends on errorJson</returns>
		public virtual string GetSendingErrorKey(string errorJson = null) {
			return "SendError";
		}
	}
	
	#endregion
	
	#region Class: OmnichannelMessagingService

	/// <summary>
	/// BaseService for sending and receiving messages from messaging integration api.
	/// </summary>
	public class OmnichannelMessagingService : BaseService
	{

		#region Class: OmnichannelMessagingServiceResponse

		[DataContract]
		public class OmnichannelMessagingServiceResponse
		{
			[DataMember]
			public bool Success { get; set; } = true;
			[DataMember]
			public string ErrorMessage { get; set; }
			[DataMember]
			public string ChatId { get; set; }
		}

		#endregion

		#region Class: AccountRestResponse

		[DataContract]
		public class AccountRestResponse : OmnichannelMessagingServiceResponse
		{

			#region Properties: Public

			/// <summary>
			/// Account id.
			/// </summary>
			[DataMember]
			public Guid AccountId { get; set; }

			/// <summary>
			/// Is account active.
			/// </summary>
			[DataMember]
			public bool IsActive { get; set; }

			/// <summary>
			/// Creatio URL.
			/// </summary>
			[DataMember]
			public string CreatioUrl { get; set; }

			#endregion

		}

		#endregion

		#region Class: MessageSendingError

		public enum MessageSendingError
		{
			None,
			Internal,
			Messenger
		}

		#endregion

		#region Class: OmnichannelMessagingMessageMetric

		/// <summary>
		/// Implementation of <see cref="IMetric"/> for messaging monitoring.
		/// </summary>
		public class OmnichannelMessagingMessageMetric : IMetric
		{

			#region Properties: Public

			/// <summary>
			/// Message source.
			/// </summary>
			public ChannelType Source { get; set; }

			/// <summary>
			/// Message source.
			/// </summary>
			public OmnichannelProviders.Domain.Entities.MessageType Type { get; set; }

			/// <summary>
			/// Sending message duration.
			/// </summary>
			public long Duration { get; set; }

			/// <summary>
			/// Sending message size.
			/// </summary>
			public long Size { get; set; }

			/// <summary>
			/// Direction of message.
			/// </summary>
			public OmnichannelProviders.Domain.Entities.MessageDirection Direction { get; set; }

			/// <summary>
			/// Error type.
			/// </summary>
			public MessageSendingError ErrorType { get; set; }

			/// <summary>
			/// Metric name according to topic https://prometheus.io/docs/practices/naming/.
			/// </summary>
			public string Name => "omnichannel_messaging_message";

			#endregion

			#region Methods: Public

			/// <summary>
			/// Get metric values.
			/// </summary>
			public IDictionary<string, object> GetFieldValues() {
				return new Dictionary<string, object> {
					{ "duration", Duration },
					{ "size", Size },
					{ "direction", (int)Direction },
					{ "type", Type.ToString().ToLowerInvariant() },
					{ "error", (int)ErrorType }
				};
			}

			/// <summary>
			/// Get additional metric tags.
			/// </summary>
			public IDictionary<string, object> GetTags() {
				return new Dictionary<string, object> {
					{ "source", Source.ToString().ToLowerInvariant() }
				};
			}

			#endregion

		}
		
		#region Class: CacheMessage
	
		/// <summary>
		/// Object to store short message info in cache
		/// </summary>
		[Serializable]
		public class CacheMessage
		{

			#region Properties: Public

			public string SourceId { get; set; }
			public long Timestamp { get; set; }

			#endregion

		}
	
		#endregion

		#endregion

		#region Properties: Private

		private readonly ICacheStore _applicationCache;
		private const string _messageCachePrefix = "CacheMessage_";
		
		#endregion
		
		#region Properties: Protected

		protected static IMetricReporter MetricReporter;

		private ILog _log;
		protected ILog Log {
			get {
				return _log ?? (_log = LogManager.GetLogger("OmnichannelMessageHandler"));
			}
		}

		private OmnichannelChatProvider _chatProvider;
		protected OmnichannelChatProvider ChatProvider {
			get {
				return _chatProvider = _chatProvider ?? new OmnichannelChatProvider(UserConnection);
			}
		}

		private IdentityServerProvider _identityServerProvider;
		/// <summary>
		/// Identity server provider instance. Returns established provider.
		/// If established is null then create instance of <see cref="IdentityServerProvider"/> 
		/// from <see cref="ClassFactory"/>.
		/// </summary>
		protected IdentityServerProvider IdentityServerProvider {
			get {
				return _identityServerProvider = _identityServerProvider ?? CreateIdentityServerProvider();
			}
			set {
				_identityServerProvider = value;
			}
		}

		private IHttpRequestClient _requestClient;
		/// <summary>
		/// Gets or sets the rest client for Api calls.
		/// </summary>
		/// <value>
		/// The rest client.
		/// </value>
		protected IHttpRequestClient RequestClient {
			get {
				if (_requestClient == null) {
					_requestClient = ClassFactory.Get<IHttpRequestClient>();
				}
				return _requestClient;
			}
			set {
				_requestClient = value;
			}
		}

		private ChatLocksRepository _chatLockRepository;
		/// <summary>
		/// Class to manage chat quick locks.
		/// </summary>
		protected ChatLocksRepository ChatLocksRepository {
			get {
				return _chatLockRepository = _chatLockRepository ?? new ChatLocksRepository(UserConnection);
			}
		}

		private IMessageInterceptor _messageInterceptor;
		private bool _messageInterceptorResolved;

		/// <summary>
		/// Gets the message interceptor instance. Returns <c>null</c> when no binding is registered.
		/// </summary>
		protected IMessageInterceptor MessageInterceptor {
			get {
				if (!_messageInterceptorResolved) {
					_messageInterceptorResolved = true;
					try {
						_messageInterceptor = ClassFactory.Get<IMessageInterceptor>(
							new ConstructorArgument("userConnection", UserConnection));
					} catch {
						_messageInterceptor = null;
					}
				}
				return _messageInterceptor;
			}
		}

		private IOutboundMessageInterceptor _outboundMessageInterceptor;
		private bool _outboundMessageInterceptorResolved;

		/// <summary>
		/// Gets the outbound message interceptor instance. Returns <c>null</c>
		/// when no binding is registered. Mirrors <see cref="MessageInterceptor"/>
		/// — lazy-resolved once per request, swallows DI failures so the
		/// canonical send path keeps working when no extension is plugged in.
		/// </summary>
		protected IOutboundMessageInterceptor OutboundMessageInterceptor {
			get {
				if (!_outboundMessageInterceptorResolved) {
					_outboundMessageInterceptorResolved = true;
					try {
						_outboundMessageInterceptor = ClassFactory.Get<IOutboundMessageInterceptor>(
							new ConstructorArgument("userConnection", UserConnection));
					} catch {
						_outboundMessageInterceptor = null;
					}
				}
				return _outboundMessageInterceptor;
			}
		}

		#endregion

		#region Properties: Public 

		private OmnichannelContactIdentifier _contactIdentifier;
		/// <summary>
		/// Contact identifier instance of <see cref="OmnichannelContactIdentifier"/> class.
		/// </summary>
		public OmnichannelContactIdentifier ContactIdentifier {
			get {
				return _contactIdentifier ?? (_contactIdentifier = new OmnichannelContactIdentifier(UserConnection));
			}
		}

		private MessageManager _messageManager;
		/// <summary>
		/// Class which save and send messages <see cref="MessageManager"/> class.
		/// </summary>
		protected MessageManager MessageManager {
			get {
				_messageManager = _messageManager ?? new MessageManager(UserConnection);
				return _messageManager;
			}
		}

		private ChatRepository _chatRepository;
		/// <summary>
		/// Chat repository instance of <see cref="ChatRepository"/> class.
		/// </summary>
		public ChatRepository ChatRepository {
			get {
				return _chatRepository ?? (_chatRepository = new ChatRepository(UserConnection));
			}
		}

		private ChatQueueDistributor _chatQueueDistributor;
		/// <summary>
		/// Chat queue distributor instance of <see cref="ChatQueueDistributor"/> class.
		/// </summary>
		public ChatQueueDistributor ChatQueueDistributor {
			get {
				return _chatQueueDistributor ?? (_chatQueueDistributor = new ChatQueueDistributor(UserConnection));
			}
		}

		private OperatorManager _operatorManager;
		/// <summary>
		/// Chat repository instance of <see cref="OperatorManager"/> class.
		/// </summary>
		public OperatorManager OperatorManager {
			get {
				return _operatorManager ?? (_operatorManager = new OperatorManager(UserConnection));
			}
		}

		private ChatOperatorNotifier _operatorNotifier;
		/// <summary>
		/// Instance of <see cref="ChatOperatorNotifier"/> class.
		/// </summary>
		public ChatOperatorNotifier OperatorNotifier {
			get {
				return _operatorNotifier ?? (_operatorNotifier = new ChatOperatorNotifier(UserConnection));
			}
		}

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Initializes new instance of <see cref="OmnichannelMessagingService"/>.
		/// </summary>
		public OmnichannelMessagingService() {
			UserConnection = UserConnection ?? AppConnection?.SystemUserConnection;
			if (UserConnection.Current == null) {
				UserConnection.Current = UserConnection;
			}
			_applicationCache = UserConnection.ApplicationCache;
		}

		public OmnichannelMessagingService(UserConnection userConnection) : base(userConnection) {
			if (UserConnection.Current == null) {
				UserConnection.Current = UserConnection;
			}
			_applicationCache = userConnection.ApplicationCache;
		}

		/// <summary>
		/// Initializes new instance of <see cref="OmnichannelMessagingService"/>.
		/// </summary>
		static OmnichannelMessagingService() {
			MetricReporter = ClassFactory.Get<IMetricReporter>();
		}

		#endregion

		#region Methods: Private

		private IdentityServerProvider CreateIdentityServerProvider() {
			var userConnectionArg = new ConstructorArgument("userConnection", UserConnection);
			return ClassFactory.Get<IdentityServerProvider>(userConnectionArg);
		}

		private HttpRequestConfig CreateRequestConfig(HttpRequestMethod method, string url, string token) {
			return new HttpRequestConfig {
				Url = new Uri(url),
				Method = method,
				Headers = {
					{ "Authorization", $"Bearer {token}" }
				},
				RequestTimeout = 30
			};
		}

		private OmnichannelMessagingServiceResponse CreateErrorResponse<T>(string key) {
			string errorMessage = new Common.LocalizableString(UserConnection.Workspace.ResourceStorage, typeof(T).Name,
				$"LocalizableStrings.{key}.Value").ToString();
			return CreateErrorResponse(errorMessage);
		}

		private OmnichannelMessagingServiceResponse CreateErrorResponse(string errorMessage) {
			return new OmnichannelMessagingServiceResponse {
				Success = false,
				ErrorMessage = errorMessage
			};
		}

		private ErrorKeysGenerator GetErrorGenerator(ChannelType channelType) {
			switch (channelType) {
				case ChannelType.Facebook:
					return new FacebookErrorKeysKeysGenerator();
			}
			
			return new ErrorKeysGenerator();
		}
		
		private bool AddMessage(MessagingMessage messagingMessage) {
			bool isNewChat;
			if (UserConnection.GetIsFeatureEnabled("FixChatMessageId")) {
				messagingMessage.ChatId = FixChatIdIfNeeded(messagingMessage, out isNewChat);
			} else {
				messagingMessage.ChatId = ChatRepository.AddMessage(messagingMessage, out isNewChat).ToString();
			}
			MessageManager.Receive(messagingMessage, messagingMessage.ChannelName);
			if (!messagingMessage.IsStandBy) {
				ChatProvider.DistributeChat(messagingMessage.ChatId, messagingMessage.ChannelQueueId, isNewChat, messagingMessage);
			}
			return isNewChat;
		}

		private void AddErrorMessageToChat(MessagingMessage messagingMessage, string errorMessage) {
			messagingMessage.Attachments = null;
			messagingMessage.MessageType = MessageType.Text;
			if (!string.IsNullOrEmpty(messagingMessage.Message)) {
				AddMessage(messagingMessage);
			}
			messagingMessage.Id = new Guid();
			messagingMessage.Message = errorMessage;
			AddMessage(messagingMessage);
		}
		
		private string FixChatIdIfNeeded(MessagingMessage message, out bool isNewChat) {
			isNewChat = false;
			string chatId;
			string messageSourceId = message.MessageDirection == Direction.Incoming ? message.Sender : message.Recipient;
			CacheMessage previousMessage = _applicationCache[_messageCachePrefix + messageSourceId] as CacheMessage;
			if (previousMessage?.Timestamp > message.Timestamp) {
				Log.Debug($"Found message with wrong time consistency. Message source ID: {messageSourceId}. Current timestamp = {message.Timestamp}, previous timestamp = {previousMessage.Timestamp}");
				chatId = MessageManager.GetNearestMessageChatIdBySender(messageSourceId, message.Timestamp);
				Log.Debug($"Set correct chat ID = {chatId} for message source ID {messageSourceId}");
			} else {
				chatId = ChatRepository.AddMessage(message, out isNewChat).ToString();
				UpdateCacheMessage(previousMessage ?? new CacheMessage(), messageSourceId, message.Timestamp);
			}
			return chatId;
		}
		
		private void UpdateCacheMessage(CacheMessage message, string messageSourceId, long timestamp) {
			message.Timestamp = timestamp;
			message.SourceId = messageSourceId;
			_applicationCache[_messageCachePrefix + messageSourceId] = message;
		}
		private OmnichannelMessagingServiceResponse CreateAttachmentErrorResponse(List<AttachmentError> errors, string messengerName) {
			var fileSizeErrors = errors.Where(e => e.ErrorType == AttachmentErrorType.FileSizeExceeded).ToList();
			var unsupportedTypeErrors = errors.Where(e => e.ErrorType == AttachmentErrorType.UnsupportedFileType).ToList();
			string errorMessage = "";
			if (fileSizeErrors.Any()) {
				var fileNames = string.Join("\n", fileSizeErrors.Select(e => e.FileName));
				var fileSizeErrorTemplate = new LocalizableString(UserConnection.Workspace.ResourceStorage,
					"OmnichannelMessagingService", "LocalizableStrings.FileSizeExceededError.Value").ToString();
				errorMessage += string.Format(fileSizeErrorTemplate, messengerName, fileNames);
			}
			if (unsupportedTypeErrors.Any()) {
				if (errorMessage.Length > 0) {
					errorMessage += "\n\n";
				}
				var extensions = string.Join(", ", unsupportedTypeErrors
					.Select(e => System.IO.Path.GetExtension(e.FileName))
					.Distinct());
				var fileNames = string.Join("\n", unsupportedTypeErrors.Select(e => e.FileName));
				var unsupportedTypeErrorTemplate = new LocalizableString(UserConnection.Workspace.ResourceStorage,
					"OmnichannelMessagingService", "LocalizableStrings.UnsupportedFileTypeError.Value").ToString();
				errorMessage += string.Format(unsupportedTypeErrorTemplate, extensions, messengerName, fileNames);
			}    
			return CreateErrorResponse(errorMessage);
		}

		private OmnichannelMessagingServiceResponse TryParseAttachmentErrors(string errorJson, string messengerName) {
			try {
				var responseObj = JsonConvert.DeserializeObject<Dictionary<string, object>>(errorJson);
				if (responseObj != null && responseObj.ContainsKey("attachmentErrors")) {
					var attachmentErrors = JsonConvert.DeserializeObject<List<AttachmentError>>(
						responseObj["attachmentErrors"].ToString()
					);
					if (attachmentErrors != null && attachmentErrors.Any()) {
						return CreateAttachmentErrorResponse(attachmentErrors, messengerName);
					}
				}
			}
			catch {
			}
			return null;
		}

		/// <summary>
		/// Drains the chat lock queue and releases the lock. Processes all enqueued messages
		/// and transfer signals that accumulated while the lock was held.
		/// </summary>
		/// <param name="channelId">Channel identifier used as lock key.</param>
		/// <param name="sender">Sender identifier used as lock key.</param>
		private void DrainQueueAndReleaseLock(string channelId, string sender) {
			try {
				List<object> queueItems = ChatLocksRepository
					.DequeueLockedChatsQueue(channelId, sender);
				while (queueItems != null) {
					foreach (var item in queueItems) {
						if (item is MessagingMessage message) {
							AddMessage(message);
							Log.Debug($"Chat message was dequeued: {message.Message}");
						} else if (item is List<Guid> list) {
							TransferChatsToQueue(list);
							Log.Debug($"Chat transfer signal from chatId={list.FirstOrDefault()} was dequeued.");
						}
					}
					queueItems = ChatLocksRepository
						.DequeueLockedChatsQueue(channelId, sender);
				}
			} catch (Exception drainEx) {
				Log.ErrorFormat(
					"Error draining message queue: {0}, StackTrace: {1}",
					drainEx.Message, drainEx.StackTrace);
			} finally {
				ChatLocksRepository.ReleaseChatLock(channelId, sender);
			}
		}

		/// <summary>
		/// Attempts to acquire a chat processing lock. When the lock is not available,
		/// enqueues the message for later processing.
		/// </summary>
		/// <param name="messagingMessage">Message to enqueue when lock is unavailable.</param>
		/// <returns><c>true</c> if the lock was acquired; <c>false</c> if the message was enqueued.</returns>
		private bool TryAcquireChatLock(MessagingMessage messagingMessage) {
			ChatLocksRepository.TryLockChat(messagingMessage.ChannelId,
				messagingMessage.SenderIfEcho, out bool lockAcquired);
			if (!lockAcquired) {
				ChatLocksRepository.EnqueueMessage(messagingMessage.ChannelId,
					messagingMessage.SenderIfEcho, messagingMessage);
				Log.Debug($"Chat message was enqueued: {messagingMessage.Message}");
			}
			return lockAcquired;
		}

		/// <summary>
		/// Creates a metric instance for a message.
		/// </summary>
		private OmnichannelMessagingMessageMetric CreateMessageMetric(MessagingMessage messagingMessage,
				Direction direction = Direction.Incoming) {
			return new OmnichannelMessagingMessageMetric {
				Direction = direction,
				Size = messagingMessage.GetSize(),
				Source = messagingMessage.Source,
				Type = messagingMessage.MessageType
			};
		}

		#endregion

		#region Properties: Protected

		protected virtual string MessageReceiverUrl { get; set; }

		protected virtual string MessageRouterUrl { get; set; }

		private string _omnichannelMessagingIntegrationApiUrl;
		protected virtual string OmnichannelMessagingIntegrationApiUrl {
			get {
				return _omnichannelMessagingIntegrationApiUrl.IsNullOrEmpty() ?
					(_omnichannelMessagingIntegrationApiUrl = SysSettings.GetValue<string>(UserConnection, "OmnichannelMessagingIntegrationApiUrl", GlobalAppSettings.OmnichannelMessagingIntegrationApiUrl))
					: _omnichannelMessagingIntegrationApiUrl;
			} 
		}

		#endregion

		#region Methods: Protected

		protected string GetIdentityToken() {
			return IdentityServerProvider.GetAccessToken("social_leadgen_api");
		}

		/// <summary>
		/// Returns a display name for a guest (anonymous) user.
		/// Tries to use ContactIdentification[Name] if available, otherwise falls back to anonymous placeholder.
		/// </summary>
		protected virtual string GetGuestDisplayName(MessagingMessage message) {
			if (message.ContactIdentification != null
					&& message.ContactIdentification.TryGetValue(ContactIdentificationType.Name, out string name)
					&& !string.IsNullOrEmpty(name)) {
				return name;
			}
			return OmnichannelMessagingConsts.AnonymousUserDisplayName;
		}

		/// <summary>
		/// Attempts to intercept an incoming message via <see cref="IMessageInterceptor"/>.
		/// When the interceptor handles the message, a response is sent back
		/// and standard processing is skipped.
		/// Uses chat locking and queue management consistent with <see cref="InternalReceive"/>
		/// to prevent concurrent chat operations for the same sender.
		/// </summary>
		/// <param name="messagingMessage">The incoming message.</param>
		/// <returns><c>true</c> if the message was intercepted; otherwise <c>false</c>.</returns>
		/// <remarks>
		/// When the chat lock is not available, the already-intercepted message is enqueued
		/// and will be persisted (via <see cref="AddMessage"/>) when the lock holder drains
		/// the queue. Note that in this case the AI response message will not be re-sent
		/// for the enqueued item — only the incoming message is persisted.
		/// </remarks>
		protected virtual bool TryInterceptMessage(MessagingMessage messagingMessage) {
			var interceptor = MessageInterceptor;
			if (interceptor == null) {
				return false;
			}
			Stopwatch stopWatch = Stopwatch.StartNew();
			var metric = CreateMessageMetric(messagingMessage);
			bool lockHeld = false;
			try {
				var context = new InterceptorContext {
					ChannelId = new Guid(messagingMessage.ChannelId)
				};
				if (!interceptor.TryIntercept(messagingMessage, context, out UnifiedMessage responseMessage)) {
					return false;
				}
				if (!TryAcquireChatLock(messagingMessage)) {
					return true;
				}
				lockHeld = true;
				try {
					AddMessage(messagingMessage);
				} catch (Exception addEx) {
					metric.ErrorType = MessageSendingError.Internal;
					Log.ErrorFormat(
						"Failed to persist intercepted message: {0}, StackTrace: {1}",
						addEx.Message, addEx.StackTrace);
					return true;
				}
				if (responseMessage != null) {
					try {
						var response = new MessagingMessage(responseMessage) {
							ChannelName = messagingMessage.ChannelName,
							ChannelQueueId = messagingMessage.ChannelQueueId,
							ContactId = messagingMessage.ContactId,
							ContactDisplayValue = messagingMessage.ContactDisplayValue,
							ChatId = messagingMessage.ChatId
						};
						// Let a registered IOutboundMessageInterceptor (e.g. the channel preview) claim the
						// synchronous AI / bot reply first. The preview dispatches this reply inside the inbound
						// InternalReceive and routes it to the admin's WebSocket; without this it fell through to
						// the native per-provider worker, which a preview chat has no valid messenger binding for
						// (ChannelName is the channel display name, not the ChannelType key) — so the AI reply was
						// never delivered. For non-preview chats the interceptor returns false and behaviour is unchanged.
						if (!TryInterceptOutboundMessage(response)) {
							MessageManager.Send(response, response.ChannelName);
						}
					} catch (Exception sendEx) {
						Log.ErrorFormat(
							"Failed to send interceptor response: {0}, StackTrace: {1}",
							sendEx.Message, sendEx.StackTrace);
					}
				}
				try {
					context.PostProcess?.Invoke(messagingMessage.ChatId);
				} catch (Exception postEx) {
					Log.ErrorFormat("Error in interceptor PostProcess: {0}, StackTrace: {1}",
						postEx.Message, postEx.StackTrace);
				}
				return true;
			} catch (Exception e) {
				metric.ErrorType = MessageSendingError.Internal;
				Log.ErrorFormat("Error in message interceptor: {0}, StackTrace: {1}",
					e.Message, e.StackTrace);
			} finally {
				if (lockHeld) {
					DrainQueueAndReleaseLock(messagingMessage.ChannelId, messagingMessage.SenderIfEcho);
				}
				stopWatch.Stop();
				metric.Duration = stopWatch.ElapsedMilliseconds;
				MetricReporter.Report(metric);
			}
			return false;
		}

		protected virtual void InternalReceive(MessagingMessage messagingMessage) {
			if (TryInterceptMessage(messagingMessage)) {
				return;
			}
			Stopwatch stopWatch = Stopwatch.StartNew();
			var metric = CreateMessageMetric(messagingMessage,
				messagingMessage.IsEcho ? Direction.Outcoming : Direction.Incoming);
			bool lockHeld = false;
			try {
				if (messagingMessage.IsGuestUser) {
					messagingMessage.ContactId = null;
					messagingMessage.ContactDisplayValue = GetGuestDisplayName(messagingMessage);
				} else {
					messagingMessage.ContactId = ContactIdentifier.GetContactId(messagingMessage);
					if (messagingMessage.ContactId != null) {
						messagingMessage.ContactDisplayValue = ContactIdentifier.GetContactDisplayValue((Guid)messagingMessage.ContactId);
					}
				}
				if (!TryAcquireChatLock(messagingMessage)) {
					return;
				}
				lockHeld = true;
				AddMessage(messagingMessage);
			} catch (Exception e) {
				if (e is FileTooBigException || e is MaxFileSizeExceededException) {
					Log.Warn(e.Message, e);
					var errorMessage = e is MaxFileSizeExceededException ? 
						new LocalizableString(UserConnection.Workspace.ResourceStorage, "OmnichannelMessagingService",
							"LocalizableStrings.MaxFileSizeExceededError.Value").ToString() :
						new LocalizableString(UserConnection.Workspace.ResourceStorage, "OmnichannelMessagingService",
							"LocalizableStrings.FileTooBigError.Value").ToString();
					AddErrorMessageToChat(messagingMessage, errorMessage);
				} else {
					metric.ErrorType = MessageSendingError.Internal;
					Log.ErrorFormat("Error while receiving the message. Error info: {0}, StackTrace {1}", e.Message, e.StackTrace);
				}
			} finally {
				if (lockHeld) {
					DrainQueueAndReleaseLock(messagingMessage.ChannelId, messagingMessage.SenderIfEcho);
				}
			}
			stopWatch.Stop();
			metric.Duration = stopWatch.ElapsedMilliseconds;
			MetricReporter.Report(metric);
		}
		protected string InternalSend(MessagingMessage messagingMessage) {
			var findChat = ChatRepository.AddOutcomingMessage(messagingMessage);
			string result;
			if (findChat.Success) {
				if(findChat.IsLastChatCompleted) {
					OperatorNotifier.NewChatCreatedNotify(new List<Guid>() { UserConnection.CurrentUser.Id }, findChat.LastChatId.ToString());
				}
				messagingMessage.ChatId = findChat.LastChatId.ToString();
				messagingMessage.Status = messagingMessage.Status ?? MessageDeliveryStatus.Sent;
				if (TryInterceptOutboundMessage(messagingMessage)) {
					// Interceptor handled the message (e.g. preview pushed it
					// to the admin's WebSocket). Skip the per-provider native
					// transport — the canonical OmniChat / OmnichannelMessages
					// rows are already in place. Operator-side notifications
					// still fire below.
					result = (messagingMessage.Status ?? MessageDeliveryStatus.Sent).ToString();
				} else {
					result = MessageManager.Send(messagingMessage, messagingMessage.ChannelName);
				}
				OperatorNotifier.NewConversationMessageNotify(messagingMessage as UnifiedMessage);
			} else {
				result = findChat.ErrorInfo.Message;
			}
			return result;
		}

		/// <summary>
		/// Attempts to hand the outbound message off to a registered
		/// <see cref="IOutboundMessageInterceptor"/>. Exceptions from the
		/// interceptor are logged and treated as "not handled" so a faulty
		/// extension cannot block legitimate provider sends.
		/// </summary>
		protected virtual bool TryInterceptOutboundMessage(MessagingMessage messagingMessage) {
			var interceptor = OutboundMessageInterceptor;
			if (interceptor == null) {
				return false;
			}
			try {
				return interceptor.TryIntercept(messagingMessage);
			} catch (Exception e) {
				Log.ErrorFormat(
					"Error in outbound message interceptor: {0}, StackTrace: {1}",
					e.Message, e.StackTrace);
				return false;
			}
		}


		protected T SendRequestWithToken<T>(HttpRequestMethod method, string url, object bodyObject = default)
			where T : OmnichannelMessagingServiceResponse, new() {
			var requestConfig = CreateRequestConfig(method, url, GetIdentityToken());
			if (bodyObject != default) {
				requestConfig.Body = bodyObject;
			}
			var response = bodyObject != default
				? RequestClient.SendWithJsonBody(requestConfig)
				: RequestClient.Send(requestConfig);
			if (response == null) {
				Log.Error($"OmnichannelMessagingService.SendRequestWithToken: request to url '{url}' returns null");
				return default;
			}
			Log.Debug($"OmnichannelMessagingService.SendRequestWithToken: response.Data = {JsonConvert.SerializeObject(response)}");
			return response.GetResult<T>();
		}

		protected virtual void TransferMessageToQueue(Guid channelId, string sender) {
			string channelIdStr = channelId.ToString();
			var chats = ChatRepository.GetBotProcessingChatIds(channelId, sender);

			ChatLocksRepository.TryLockChat(channelIdStr, sender, out bool lockAcquired);
			if (!lockAcquired) {
				ChatLocksRepository.EnqueueMessage(channelIdStr, sender, chats);
				Log.Debug($"Chat transfer signal message was enqueued. Sender: {sender} Chat: {chats.FirstOrDefault()}");
				return;
			}
			TransferChatsToQueue(chats);
			DrainQueueAndReleaseLock(channelIdStr, sender);
		}

		protected void TransferChatsToQueue(List<Guid> chats) {
			Guid chatId = chats.FirstOrDefault();
			if (chats.Count > 1) {
				MessageManager.UpdateChatIdInMessagesByChats(chats, chatId);
				ChatRepository.DeleteUnnecessaryChats(chats.Skip(1).ToList());
			}
			ChatRepository.CloseActiveChat(chatId, hasChildChat: true, closureReasonId: OmnichannelMessagingConsts.ClosureReason.Transferred);
			var queueId = ChatRepository.GetChatQueueId(chatId);
			var childChatId = ChatRepository.CreateChildChat(chatId, new Dictionary<string, object> {
				{ "QueueId", queueId },
				{ "StatusId", OmnichannelMessagingConsts.WaitingForProcessing }
			});
			ChatRepository.DetectAndSetChatLanguage(chatId, childChatId);
			ChatQueueDistributor.DistributeQueueChatsByChatId(childChatId);
		}

		protected void RegisterAccount() {
			Log.Info($"RegisterAccount: OmnichannelMessagingIntegrationApiUrl is '{OmnichannelMessagingIntegrationApiUrl}'");
			string url = $"{OmnichannelMessagingIntegrationApiUrl.TrimEnd('/')}/api/account/create";
			var creatioUrl = WebUtilities.GetBaseApplicationUrl(HttpContextAccessor.GetInstance().Request);
			Log.Info($"RegisterAccount: creatioUrl is '{creatioUrl}'");
			var data = new {
				CreatioUrl = creatioUrl,
				IsActive = true
			};
			SendRequestWithToken<OmnichannelMessagingServiceResponse>(HttpRequestMethod.POST, url, data);
			Log.Info($"RegisterAccount: done");
		}

		protected AccountRestResponse GetMyAccount() {
			string url = $"{OmnichannelMessagingIntegrationApiUrl.TrimEnd('/')}/api/account/me";
			var response = SendRequestWithToken<AccountRestResponse>(HttpRequestMethod.POST, url, null);
			return response;
		}

		protected bool RegisterAccountIfNotExists() {
			var account = new AccountRestResponse();
			try {
				account = GetMyAccount();
				if (account != null && account.AccountId != null && account.AccountId.IsNotEmpty()) {
					Log.Info($"Account was already found in account service. AccountId={account.AccountId}");
					return true;
				}
				Log.Info("Registering new account in account service");
				RegisterAccount();
				return true;
			} catch (Exception ex) {
				Log.Error($"Could not register account {account.AccountId}. Error message: {account.ErrorMessage}", ex);
				return false;
			}
		}

		protected string GetMessageReceiverUrl() {
			string url =  WebUtilities.GetBaseApplicationUrl(HttpContextAccessor.GetInstance().Request);
			return string.Concat(url.TrimEnd('/'), MessageReceiverUrl);
		}

		protected string GetMessageRouterUrl(string path) {
			string url = OmnichannelMessagingIntegrationApiUrl;
			return string.Concat(url.TrimEnd('/'), MessageRouterUrl, path);
		}

		protected virtual void GetChannelAndQueueBySettingsId(Guid settingsId, MessagingMessage message) {
			Select channelSelect = new Select(UserConnection)
				.Top(1).Column("Id")
				.From("Channel")
				.Where("MsgSettingsId").IsEqual(Column.Parameter(settingsId))
				.And("IsActive").IsEqual(Column.Parameter(true)) as Select;
			channelSelect.ExecuteReader(reader => {
				message.ChannelId = reader.GetColumnValue<Guid>("Id").ToString();
			});
		}

		protected ErrorKeysGenerator GetErrorKeysGenerator(ChannelType channelType) {
			switch (channelType) {
				case ChannelType.Facebook:
					return new FacebookErrorKeysKeysGenerator();
			}

			return new ErrorKeysGenerator();
		}
		
		protected OmnichannelMessagingServiceResponse GetSendingError(ChannelType? channelType = null, string errorJson = null) {
			string errorKey = "SendError";
			if (!string.IsNullOrEmpty(errorJson) && channelType.HasValue) {
				var messengerName = channelType.Value.ToString();
				var attachmentErrorResponse = TryParseAttachmentErrors(errorJson, messengerName);
				if (attachmentErrorResponse != null) {
					return attachmentErrorResponse;
				}
				errorKey = GetErrorGenerator(channelType.Value).GetSendingErrorKey(errorJson);
			}
			
			return CreateErrorResponse<OmnichannelOutcomeMessagingService>(errorKey);
		}

		protected virtual bool UpdateContact(MessagingMessage message, IDictionary<string, object> updateColumnData) {
			return ContactIdentifier.UpdateContact(message, updateColumnData);
		}

		#endregion

	}

	#endregion

}

