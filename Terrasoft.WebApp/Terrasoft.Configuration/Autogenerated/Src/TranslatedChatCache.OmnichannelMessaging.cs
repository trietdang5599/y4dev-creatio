namespace Terrasoft.Configuration.Omnichannel.Translating
{
	using global::Common.Logging;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Runtime.Serialization;
	using Terrasoft.Configuration.Omnichannel.Messaging;
	using Terrasoft.Core.Store;

	#region Class: TranslatedChatMessage

	/// <summary>
	/// Lightweight container for cached translated chat message containing only essential translation properties.
	/// </summary>
	[DataContract]
	[Serializable]
	public class TranslatedChatMessage
	{
		[DataMember(Name = "id")]
		public Guid Id { get; set; }

		[DataMember(Name = "text")]
		public string Text { get; set; }
	}

	#endregion

	#region Class: ChatMessageTranslationMapper

	/// <summary>
	/// Utility class for mapping translation data between ChatMessage and TranslatedChatMessage collections.
	/// </summary>
	public static class ChatMessageTranslationMapper
	{
		/// <summary>
		/// Applies translation data from TranslatedChatMessage collection to existing ChatMessage collection.
		/// Updates Text and OriginalText properties of matching ChatMessage objects based on Id.
		/// </summary>
		/// <param name="chatMessages">Collection of ChatMessage objects to update.</param>
		/// <param name="translatedMessages">Collection of TranslatedChatMessage objects containing translation data.</param>
		/// <returns>The original ChatMessage collection with updated Text and OriginalText properties.</returns>
		public static IEnumerable<ChatMessage> ApplyTranslations(IEnumerable<ChatMessage> chatMessages, IEnumerable<TranslatedChatMessage> translatedMessages) {
			if (chatMessages == null || translatedMessages == null) {
				return chatMessages ?? Enumerable.Empty<ChatMessage>();
			}
			var translationLookup = translatedMessages.Where(tm => tm != null).ToDictionary(tm => tm.Id, tm => tm);
			foreach (var chatMessage in chatMessages.Where(cm => cm != null)) {
				if (translationLookup.TryGetValue(chatMessage.Id, out var translatedMessage)) {
					chatMessage.OriginalText = chatMessage.Text;
					chatMessage.Text = translatedMessage.Text;
					chatMessage.IsTranslated = true;
				}
			}
			return chatMessages;
		}

		/// <summary>
		/// Converts ChatMessage collection to TranslatedChatMessage collection for caching.
		/// </summary>
		/// <param name="messages">Source ChatMessage collection.</param>
		/// <returns>Collection of TranslatedChatMessage objects.</returns>
		public static IEnumerable<TranslatedChatMessage> ToTranslatedMessages(IEnumerable<ChatMessage> messages) {
			return messages?.Where(m => m != null).Select(m => new TranslatedChatMessage {
				Id = m.Id,
				Text = m.Text
			}) ?? Enumerable.Empty<TranslatedChatMessage>();
		}
	}

	#endregion

	#region Interface: ITranslatedChatCache

	/// <summary>
	/// Interface for translated chat cache operations.
	/// </summary>
	public interface ITranslatedChatCache
	{
		/// <summary>
		/// Retrieves translated chat messages from cache.
		/// </summary>
		/// <param name="chatId">Chat identifier.</param>
		/// <param name="targetLanguage">Target language code.</param>
		/// <returns>Cached translated messages or null if not found.</returns>
		IEnumerable<TranslatedChatMessage> GetTranslatedChat(Guid chatId, string targetLanguage);

		/// <summary>
		/// Stores translated chat messages in cache.
		/// </summary>
		/// <param name="chatId">Chat identifier.</param>
		/// <param name="targetLanguage">Target language code.</param>
		/// <param name="translatedMessages">Translated messages to cache.</param>
		void SetTranslatedChat(Guid chatId, string targetLanguage, IEnumerable<ChatMessage> translatedMessages);

		/// <summary>
		/// Adds a single translated message to the cached collection.
		/// </summary>
		/// <param name="chatId">Chat identifier.</param>
		/// <param name="targetLanguage">Target language code.</param>
		/// <param name="message">Chat message to add to cache.</param>
		void AddTranslatedMessage(Guid chatId, string targetLanguage, ChatMessage message);
	}

	#endregion

	#region Class: TranslatedChatCache

	/// <summary>
	/// Distributed cache for translated chat messages optimized for large data.
	/// Uses distributed cache providers and stores only essential translation properties.
	/// </summary>
	public class TranslatedChatCache : ITranslatedChatCache
	{

		#region Constants: Private

		private const string TranslatedChatCacheKeyPrefix = "OmniChat_Translation_";

		#endregion

		#region Fields: Private

		private readonly ICacheStore _distributedCache;
		private ILog _log;

		#endregion

		#region Properties: Private

		protected ILog Log {
			get {
				return _log ?? (_log = LogManager.GetLogger("TranslationService"));
			}
		}

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Initializes a new instance of the <see cref="TranslatedChatCache"/> class.
		/// </summary>
		public TranslatedChatCache() {
			_distributedCache = Store.Cache[CacheLevel.Workspace];	
			if (_distributedCache == null) {
				var errorMessage = "Distributed cache storage is not available. Session cache store is null.";
				Log.Error(errorMessage);
			}
		}

		/// <summary>
		/// Initializes a new instance with custom cache store for testing.
		/// </summary>
		/// <param name="cacheStore">Custom cache store implementation.</param>
		public TranslatedChatCache(ICacheStore cacheStore) {
			_distributedCache = cacheStore;
		}

		#endregion

		#region Methods: Private

		private string GetTranslationCacheKey(Guid chatId, string targetLanguage) {
			return $"{TranslatedChatCacheKeyPrefix}{chatId}_{targetLanguage}";
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Retrieves translated chat messages from distributed cache.
		/// </summary>
		/// <param name="chatId">Chat identifier.</param>
		/// <param name="targetLanguage">Target language code.</param>
		/// <returns>Cached translated messages or null if not found.</returns>
		public IEnumerable<TranslatedChatMessage> GetTranslatedChat(Guid chatId, string targetLanguage) {
			if (chatId == Guid.Empty || string.IsNullOrEmpty(targetLanguage)) {
				return null;
			}
			try {
				string cacheKey = GetTranslationCacheKey(chatId, targetLanguage);
				var cachedMessages = _distributedCache.GetValue<List<TranslatedChatMessage>>(cacheKey);		
				if (cachedMessages != null && cachedMessages.Count > 0) {
					Log.Debug($"Retrieved translated chat from distributed cache: chatId={chatId}, targetLanguage={targetLanguage}, messageCount={cachedMessages.Count}");
					return cachedMessages;
				}
			} catch (Exception ex) {
				Log.Error($"Error retrieving translated chat from distributed cache: chatId={chatId}, targetLanguage={targetLanguage}, error={ex.Message}", ex);
			}
			
			return null;
		}

		/// <summary>
		/// Stores translated chat messages in distributed cache.
		/// </summary>
		/// <param name="chatId">Chat identifier.</param>
		/// <param name="targetLanguage">Target language code.</param>
		/// <param name="translatedMessages">Translated messages to cache.</param>
		public void SetTranslatedChat(Guid chatId, string targetLanguage, IEnumerable<ChatMessage> translatedMessages) {
			if (chatId == Guid.Empty || string.IsNullOrEmpty(targetLanguage) || translatedMessages == null) {
				return;
			}
			try {
				string cacheKey = GetTranslationCacheKey(chatId, targetLanguage);
				var lightweightMessages = ChatMessageTranslationMapper.ToTranslatedMessages(translatedMessages).ToList();		
				_distributedCache[cacheKey] = lightweightMessages;
				Log.Debug($"Stored translated chat in distributed cache: chatId={chatId}, targetLanguage={targetLanguage}, messageCount={lightweightMessages.Count}");
			} catch (Exception ex) {
				Log.Error($"Error storing translated chat to distributed cache: chatId={chatId}, targetLanguage={targetLanguage}, error={ex.Message}", ex);
			}
		}

		/// <summary>
		/// Adds a single translated message to the cached collection.
		/// </summary>
		/// <param name="chatId">Chat identifier.</param>
		/// <param name="targetLanguage">Target language code.</param>
		/// <param name="message">Chat message to add to cache.</param>
		public void AddTranslatedMessage(Guid chatId, string targetLanguage, ChatMessage message) {
			if (chatId == Guid.Empty || string.IsNullOrEmpty(targetLanguage) || message == null) {
				return;
			}
			try {
				string cacheKey = GetTranslationCacheKey(chatId, targetLanguage);
				var cachedMessages = _distributedCache.GetValue<List<TranslatedChatMessage>>(cacheKey) ?? new List<TranslatedChatMessage>();			
				cachedMessages.Add(new TranslatedChatMessage {
					Id = message.Id,
					Text = message.Text
				});
				_distributedCache[cacheKey] = cachedMessages;
				Log.Debug($"Added translated message to distributed cache: chatId={chatId}, targetLanguage={targetLanguage}, messageId={message.Id}, totalMessages={cachedMessages.Count}");
			} catch (Exception ex) {
				Log.Error($"Error adding translated message to distributed cache: chatId={chatId}, targetLanguage={targetLanguage}, messageId={message?.Id}, error={ex.Message}", ex);
			}
		}

		#endregion

	}

	#endregion

}
