 namespace Terrasoft.Configuration.Omnichannel.Messaging
{
	using global::Common.Logging;
	using System;
	using Terrasoft.Core;
	using Terrasoft.Core.Tasks;
	using SystemSettings = Core.Configuration.SysSettings;

	#region Class: OmnichannelOperatorActivationBackgroundTaskDto

	/// <summary>
	/// Represents parameters for <see cref="OmnichannelOperatorActivationBackgroundTask"/>.
	/// </summary>
	public class OmnichannelOperatorActivationBackgroundTaskDto {
		/// <summary>
		/// New operator state code.
		/// </summary>
		public string NewState { get; set; }
	}

	#endregion

	#region Class: OmnichannelOperatorActivationBackgroundTask

	/// <summary>
	/// Performs operator state change and queue distribution asynchronously.
	/// </summary>
	public class OmnichannelOperatorActivationBackgroundTask :
		IBackgroundTask<OmnichannelOperatorActivationBackgroundTaskDto>, IUserConnectionRequired
	{

		#region Properties: Protected

		protected UserConnection UserConnection { get; set; }

		#endregion

		#region Fields: Private

		private OperatorManager _operatorManager;
		private ChatOperatorCache _chatOperatorCache;
		private int? _simultaneousChats;
		private readonly ILog _log = LogManager.GetLogger("OmnichannelOperatorActivationBackgroundTask");

		#endregion

		#region Properties: Private

		private OperatorManager OperatorManager {
			get {
				return _operatorManager ?? (_operatorManager = new OperatorManager(UserConnection));
			}
		}

		private ChatOperatorCache ChatOperatorCache {
			get {
				return _chatOperatorCache ?? (_chatOperatorCache = new ChatOperatorCache(UserConnection));
			}
		}

		private int SimultaneousChats {
			get {
				if (!_simultaneousChats.HasValue) {
					_simultaneousChats = SystemSettings.GetValue(UserConnection, "SimultaneousChats", 0);
				}
				return _simultaneousChats.Value;
			}
		}

		#endregion

		#region Methods: Private

		protected bool IsChatLimitExceeded(ChatOperator chatOperator) {
			var isSimultaneousChats = SimultaneousChats > 0;
			return isSimultaneousChats
				&& chatOperator.DirectedChatsCount + chatOperator.ActiveChatsCount >= SimultaneousChats;
		}

		private int GetAvailableChatsCount(ChatOperator chatOperator) {
			return Math.Max(SimultaneousChats - (chatOperator.DirectedChatsCount + chatOperator.ActiveChatsCount), 0);
		}

		private void QueuesDistribute(Guid operatorId) {
			var chatOperator = ChatOperatorCache.GetOperator(operatorId);
			if (chatOperator == null) {
				_log.Error($"OmnichannelOperatorActivationBackgroundTask.QueuesDistribute: operator {operatorId} not found.");
				return;
			}
			if (IsChatLimitExceeded(chatOperator)) {
				return;
			}
			var queueDistribution = new ChatQueueDistributor(UserConnection);
			var chatQueueIds = OperatorManager.GetQueuesByOperator(operatorId);
			if (SimultaneousChats < 0) {
				foreach (var chatQueueId in chatQueueIds) {
					queueDistribution.Distribute(chatQueueId);
				}
				return;
			}
			var availableChatsCount = GetAvailableChatsCount(chatOperator);
			foreach (var chatQueueId in chatQueueIds) {
				var distributedChatsCount = queueDistribution.Distribute(chatQueueId, availableChatsCount);
				availableChatsCount -= distributedChatsCount;
				if (availableChatsCount <= 0) {
					break;
				}
			}
		}

		#endregion

		#region Methods: Public

		/// <inheritdoc cref="IBackgroundTask.Run(TParameters)"/>
		public void Run(OmnichannelOperatorActivationBackgroundTaskDto parameters) {
			if (parameters == null || string.IsNullOrWhiteSpace(parameters.NewState)) {
				_log.Error("OmnichannelOperatorActivationBackgroundTask.Run: parameters is null or NewState is empty.");
				return;
			}
			try {
				var currentUserId = UserConnection.CurrentUser.Id;
				OperatorManager.ChangeOperatorState(currentUserId, parameters.NewState);
				if (parameters.NewState == OmnichannelMessagingConsts.OperatorState.Active.Code) {
					QueuesDistribute(currentUserId);
				}
			} catch (Exception ex) {
				_log.Error("OmnichannelOperatorActivationBackgroundTask.Run failed.", ex);
			}
		}

		/// <inheritdoc cref="IUserConnectionRequired.SetUserConnection(UserConnection)"/>
		public void SetUserConnection(UserConnection userConnection) {
			UserConnection = userConnection;
			_simultaneousChats = null;
		}

		#endregion
	}

	#endregion

}

