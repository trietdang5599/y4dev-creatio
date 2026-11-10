namespace Terrasoft.Configuration.Omnichannel.Messaging
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using global::Common.Logging;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Store;

	#region Interface: IChatOperatorCache

	/// <summary>
	/// Interface for chat operator cache operations.
	/// </summary>
	public interface IChatOperatorCache
	{
		/// <summary>
		/// Returns <see cref="ChatOperator"/> instance. Loads operators cache if empty.
		/// </summary>
		/// <param name="operatorId">Operator identifier.</param>
		/// <returns><see cref="ChatOperator"/> instance.</returns>
		ChatOperator GetOperator(Guid operatorId);

		/// <summary>
		/// Returns cached chat operators list.
		/// </summary>
		/// <returns><see cref="ChatOperator"/> list.</returns>
		List<ChatOperator> GetOperatorsCache();

		/// <summary>
		/// Updates operator instance in cache.
		/// </summary>
		/// <param name="chatOperator"><see cref="ChatOperator"/> instance.</param>
		void UpdateOperatorInCache(ChatOperator chatOperator);

		/// <summary>
		/// Updates operator accepted chats count in cache.
		/// </summary>
		/// <param name="operatorId">Operator identifier.</param>
		/// <param name="diff">Chats count differnse.</param>
		void UpdateActiveChatsCount(Guid operatorId, int diff);

		/// <summary>
		/// Add operator directed chat in cache.
		/// </summary>
		/// <param name="chatId">Chat identifier.</param>
		/// <param name="operatorId">Operator identifier.</param>
		void AddDirectedChat(Guid chatId, Guid operatorId);

		/// <summary>
		/// Remove operator directed chat from cache.
		/// </summary>
		/// <param name="chatId">Chat identifier.</param>
		/// <param name="operatorId">Operator identifier.</param>
		void RemoveDirectedChat(Guid chatId, Guid operatorId = default);

		/// <summary>
		/// Clears operators cache.
		/// </summary>
		void ClearCache();
	}

	#endregion

	#region Class: ChatOperatorCache

	/// <summary>
	/// Chat operator cache.
	/// </summary>
	public class ChatOperatorCache : IChatOperatorCache
	{

		#region Constants: Private

		/// <summary>
		/// Application cache key for chat operators list.
		/// </summary>
		private const string _operatorsCacheKey = "OmniChatOperators";
		private const string _optimizedOperatorsCacheOperatorsListKey = "Omnichannel_OperatorsList";
		private const string _optimizedOperatorsCacheOperatorDetailsKeyPrefix = "Omnichannel_Operator_";

		#endregion

		#region Fields: Private

		/// <summary>
		/// <see cref="ICacheStore"/> implementation instance.
		/// Represents application level cache.
		/// </summary>
		private readonly ICacheStore _applicationCache;

		/// <summary>
		/// <see cref="IChatRepository"/> instance.
		/// </summary>
		private readonly IChatRepository _chatRepository;

		/// <summary>
		/// <see cref="IChatQueueOperatorRepository"/> instance.
		/// </summary>
		private readonly IChatQueueOperatorRepository _chatQueueOperatorRepository;

		/// <summary>
		/// <see cref="IOperatorSessionRepository"/> instance.
		/// </summary>
		private readonly IOperatorSessionRepository _operatorSessionRepository;

		/// <summary>
		/// <see cref="ILog"/> implementation instance.
		/// </summary>
		private ILog _detailsLogger;
		private ILog DetailsLogger => _detailsLogger ?? (_detailsLogger = LogManager.GetLogger("OmnichannelDetails"));

		private bool _useOptimizedCache = false;

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Initializes new instance of <see cref="ChatOperatorCache"/>.
		/// </summary>
		/// <param name="userConnection">User connection.</param>
		public ChatOperatorCache(UserConnection userConnection) {
			_applicationCache = userConnection.ApplicationCache;
			_chatRepository = new ChatRepository(userConnection, this);
			_chatQueueOperatorRepository = new ChatQueueOperatorRepository(userConnection);
			_operatorSessionRepository = new OperatorSessionRepository(userConnection, this);
			_useOptimizedCache = userConnection.GetIsFeatureEnabled("UseOmnichannelOptimizedOperatorsCache");
		}

		/// <summary>
		/// Initializes new instance of <see cref="ChatOperatorCache"/> with injected dependencies.
		/// </summary>
		/// <param name="chatRepository">Chat repository instance.</param>
		/// <param name="chatQueueOperatorRepository">Chat queue operator repository instance.</param>
		/// <param name="operatorSessionRepository">Operator session repository instance.</param>
		public ChatOperatorCache(UserConnection userConnection, IChatRepository chatRepository, 
				IChatQueueOperatorRepository chatQueueOperatorRepository, IOperatorSessionRepository operatorSessionRepository) {
			_applicationCache = userConnection.ApplicationCache;
			_chatRepository = chatRepository;
			_chatQueueOperatorRepository = chatQueueOperatorRepository;
			_operatorSessionRepository = operatorSessionRepository;
			_useOptimizedCache = userConnection.GetIsFeatureEnabled("UseOmnichannelOptimizedOperatorsCache");
		}

		#endregion

		#region Methods: Private

		/// <summary>
		/// Loads operators from storage and saves in cache.
		/// </summary>
		/// <returns>Cached <see cref="ChatOperator"/> list.</returns>
		private List<ChatOperator> InitOperatorsCache(List<Guid> operatorIds = null) {
			var operatorsCollection = new List<ChatOperator>();
			if (_useOptimizedCache) {
				var allOperators = operatorIds ?? _chatQueueOperatorRepository.GetAllOperatorIds();
				var operatorQueues = _chatQueueOperatorRepository.GetQueuesByOperators(allOperators);
				var operatorStates = _operatorSessionRepository.GetOperatorsStates(allOperators);
				allOperators.ForEach(operatorId => {
					var chatOperator = new ChatOperator(operatorId);
					if(operatorQueues.ContainsKey(operatorId)) {
						chatOperator.ChatQueues.AddRangeIfNotExists(operatorQueues[operatorId]);
					}
					chatOperator.State = operatorStates[operatorId];
					operatorsCollection.Add(chatOperator);
				});
				_chatRepository.LoadOperatorsState(operatorsCollection);
				_applicationCache[_optimizedOperatorsCacheOperatorsListKey] = allOperators;
				operatorsCollection.ForEach(op => {
					_applicationCache[$"{_optimizedOperatorsCacheOperatorDetailsKeyPrefix}{op.UserId}"] = op;
				});
				DetailsLogger.Info($"Optimized cache for operators loaded. Operators count = {operatorsCollection.Count}.");
			} else {
				operatorsCollection = LoadOperators();
				_applicationCache[_operatorsCacheKey] = operatorsCollection;
			}
			return operatorsCollection;
		}

		/// <summary>
		/// Loads operators from storage.
		/// </summary>
		/// <returns>Loaded <see cref="ChatOperator"/> list.</returns>
		private List<ChatOperator> LoadOperators() {
			var collection = new List<ChatOperator>();
			var allOperators = _chatQueueOperatorRepository.GetAllOperatorIds();
			allOperators.Distinct().ForEach(userId => {
				var chatOperator = collection.FirstOrDefault(o => o.UserId.Equals(userId));
				if (chatOperator == null) {
					chatOperator = CreateChatOperator(userId);
					collection.Add(chatOperator);
				}
			});
			return collection;
		}

		/// <summary>
		/// Creates <see cref="ChatOperator"/> instance.
		/// </summary>
		/// <param name="operatorId">Operator identifier.</param>
		/// <returns><see cref="ChatOperator"/> instance.</returns>
		private ChatOperator CreateChatOperator(Guid operatorId) {
			var chatOperator = new ChatOperator(operatorId);
			FillOperatorQueues(chatOperator);
			FillChatParameters(chatOperator);
			FillOperatorState(chatOperator);
			return chatOperator;
		}

		/// <summary>
		/// Loads <paramref name="chatOperator"/> queues identifiers.
		/// </summary>
		/// <param name="chatOperator"><see cref="ChatOperator"/> instance.</param>
		private void FillOperatorQueues(ChatOperator chatOperator) {
			_chatQueueOperatorRepository.LoadOperatorState(chatOperator);
		}

		/// <summary>
		/// Loads <paramref name="chatOperator"/> chat parameters.
		/// </summary>
		/// <param name="chatOperator"><see cref="ChatOperator"/> instance.</param>
		private void FillChatParameters(ChatOperator chatOperator) {
			_chatRepository.LoadOperatorState(chatOperator);
		}

		/// <summary>
		/// Loads <paramref name="chatOperator"/> state.
		/// </summary>
		/// <param name="chatOperator"><see cref="ChatOperator"/> instance.</param>
		private void FillOperatorState(ChatOperator chatOperator) {
			_operatorSessionRepository.LoadOperatorState(chatOperator);
		}

		private List<Guid> GetOperatorIds() {
			if (_useOptimizedCache) {
				var operatorsList = _applicationCache[_optimizedOperatorsCacheOperatorsListKey] as List<Guid>;
				return operatorsList;
			} else {
				var operatorsList = _applicationCache[_operatorsCacheKey] as List<ChatOperator>;
				return operatorsList.Select(op => op.UserId).ToList();
			}
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Returns <see cref="ChatOperator"/> instance. Loads operators cache if empty.
		/// </summary>
		/// <param name="operatorId">Operator identifier.</param>
		/// <returns><see cref="ChatOperator"/> instance.</returns>
		public ChatOperator GetOperator(Guid operatorId) {
			if (!operatorId.IsNotEmpty()) {
				return null;
			}
			if (_useOptimizedCache) {
				var listOfOperators = GetOperatorIds();
				if (listOfOperators == null || !listOfOperators.Contains(operatorId)) {
					var allOperatorsIds = _chatQueueOperatorRepository.GetAllOperatorIds();
					if (allOperatorsIds.IsNullOrEmpty() || !allOperatorsIds.Contains(operatorId)) {
						return null;
					}
					InitOperatorsCache(allOperatorsIds);
				}
				var chatOperator = _applicationCache[$"{_optimizedOperatorsCacheOperatorDetailsKeyPrefix}{operatorId}"] as ChatOperator;
				return chatOperator;
			} else {
				var operatorsList = GetOperatorsCache();
				var chatOperator = operatorsList.FirstOrDefault(o => o.UserId.Equals(operatorId));
				if (chatOperator == null) {
					operatorsList = InitOperatorsCache();
					chatOperator = operatorsList.FirstOrDefault(o => o.UserId.Equals(operatorId));
				}
				return chatOperator;
			}
		}

		/// <summary>
		/// Returns cached chat operators list.
		/// </summary>
		/// <returns><see cref="ChatOperator"/> list.</returns>
		public List<ChatOperator> GetOperatorsCache() {
			if (_useOptimizedCache) {
				var operatorsList = _applicationCache[_optimizedOperatorsCacheOperatorsListKey] as List<Guid>;
				if (operatorsList.IsNullOrEmpty()) {
					operatorsList = InitOperatorsCache().Select(op => op.UserId).ToList();
				}
				return operatorsList.Select(opId => _applicationCache[$"{_optimizedOperatorsCacheOperatorDetailsKeyPrefix}{opId}"] as ChatOperator).ToList();
			} else {
				var operatorsList = _applicationCache[_operatorsCacheKey] as List<ChatOperator>;
				if (operatorsList.IsNullOrEmpty()) {
					operatorsList = InitOperatorsCache();
				}
				return operatorsList;
			}
		}

		/// <summary>
		/// Updates operator instance in cache.
		/// </summary>
		/// <param name="chatOperator"><see cref="ChatOperator"/> instance.</param>
		public void UpdateOperatorInCache(ChatOperator chatOperator) {
			if (_useOptimizedCache) {
				_applicationCache[$"{_optimizedOperatorsCacheOperatorDetailsKeyPrefix}{chatOperator.UserId}"] = chatOperator;
				var allOperatorsIds = GetOperatorIds();
				if (!allOperatorsIds.Contains(chatOperator.UserId)) {
					allOperatorsIds.Add(chatOperator.UserId);
					_applicationCache[_optimizedOperatorsCacheOperatorsListKey] = allOperatorsIds;
				}
			} else {
				var operatorsList = GetOperatorsCache();
				operatorsList.RemoveAll(o => o.UserId.Equals(chatOperator.UserId));
				operatorsList.Add(chatOperator);
				_applicationCache[_operatorsCacheKey] = operatorsList;
			}
			DetailsLogger.Debug($"Cache for operator with id {chatOperator.UserId} changed. ACTIVE = {chatOperator.Active}. Directed chats count = {chatOperator.DirectedChats.Count}. Active chats count = {chatOperator.ActiveChatsCount}");
		}

		/// <summary>
		/// Updates operator accepted chats count in cache.
		/// </summary>
		/// <param name="operatorId">Operator identifier.</param>
		/// <param name="diff">Chats count differnse.</param>
		public void UpdateActiveChatsCount(Guid operatorId, int diff) {
			ChatOperator chatOperator = GetOperator(operatorId);
			if (chatOperator != null) {
				chatOperator.ActiveChatsCount = Math.Max(chatOperator.ActiveChatsCount + diff, 0);
				chatOperator.LastChatAcceptedDate = diff > 0 ? DateTime.UtcNow : chatOperator.LastChatAcceptedDate;
				UpdateOperatorInCache(chatOperator);
			}
		}

		/// <summary>
		/// Add operator directed chat in cache.
		/// </summary>
		/// <param name="chatId">Chat identifier.</param>
		/// <param name="operatorId">Operator identifier.</param>
		public void AddDirectedChat(Guid chatId, Guid operatorId) {
			ChatOperator chatOperator = GetOperator(operatorId);
			if (chatOperator != null) {
				chatOperator.DirectedChats.AddIfNotExists(chatId);
				UpdateOperatorInCache(chatOperator);
			}
		}

		/// <summary>
		/// Remove operator directed chat from cache.
		/// </summary>
		/// <param name="chatId">Chat identifier.</param>
		/// <param name="operatorId">Operator identifier.</param>
		public void RemoveDirectedChat(Guid chatId, Guid operatorId = default) {
			List<ChatOperator> operators = operatorId.IsNotEmpty()
				? new List<ChatOperator> { GetOperator(operatorId) }
				: GetOperatorsCache();
			operators.Where(o => o != null && o.DirectedChats.Contains(chatId)).ToList()
				.ForEach(o => {
					o.DirectedChats.Remove(chatId);
					UpdateOperatorInCache(o);
				});
		}

		/// <summary>
		/// Clears operators cache.
		/// </summary>
		public void ClearCache() {
			if (_useOptimizedCache) {
				_applicationCache.Remove(_optimizedOperatorsCacheOperatorsListKey);
			} else {
				_applicationCache.Remove(_operatorsCacheKey);
			}

		}

		#endregion

	}

	#endregion

}
