 namespace Terrasoft.Configuration.Omnichannel.Messaging
{
	using global::Common.Logging;
	using System;
	using Terrasoft.Core;
	using Terrasoft.Core.Tasks;

	#region Class: OmnichannelAssignChatOperatorBackgroundTaskDto

	/// <summary>
	/// Represents parameters for <see cref="OmnichannelAssignChatOperatorBackgroundTask"/>.
	/// </summary>
	public class OmnichannelAssignChatOperatorBackgroundTaskDto {
		/// <summary>
		/// Chat identifier.
		/// </summary>
		public Guid ChatId { get; set; }

		/// <summary>
		/// Operator identifier.
		/// </summary>
		public Guid OperatorId { get; set; }
	}

	#endregion

	#region Class: OmnichannelAssignChatOperatorBackgroundTask

	/// <summary>
	/// Performs chat distribution and operator notifications after chat assignment asynchronously.
	/// </summary>
	public class OmnichannelAssignChatOperatorBackgroundTask :
		IBackgroundTask<OmnichannelAssignChatOperatorBackgroundTaskDto>, IUserConnectionRequired
	{

		#region Properties: Protected

		protected UserConnection UserConnection { get; set; }

		#endregion

		#region Fields: Private

		private readonly ILog _log = LogManager.GetLogger("OmnichannelDetails");

		#endregion

		#region Methods: Public

		/// <inheritdoc cref="IBackgroundTask.Run(TParameters)"/>
		public void Run(OmnichannelAssignChatOperatorBackgroundTaskDto parameters) {
			if (parameters == null || parameters.ChatId == Guid.Empty || parameters.OperatorId == Guid.Empty) {
				_log.Error("OmnichannelAssignChatOperatorBackgroundTask.Run: parameters is null or contains empty identifiers.");
				return;
			}
			try {
				var chatProvider = new OmnichannelChatProvider(UserConnection);
				chatProvider.DistributeAndNotifyAfterAssignment(parameters.ChatId, parameters.OperatorId);
			} catch (Exception ex) {
				_log.Error("OmnichannelAssignChatOperatorBackgroundTask.Run failed.", ex);
			}
		}

		/// <inheritdoc cref="IUserConnectionRequired.SetUserConnection(UserConnection)"/>
		public void SetUserConnection(UserConnection userConnection) {
			UserConnection = userConnection;
		}

		#endregion
	}

	#endregion
}

