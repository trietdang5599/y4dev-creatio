namespace Terrasoft.Configuration.Omnichannel.Messaging
{
	using System;
	using System.Linq;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Entities.Events;
	using Terrasoft.Core.Factories;

	#region Class: ChangeChatSettingsEventListener

	/// <summary>
	/// Class provides ChatQueueOperator entity events handling.
	/// </summary>
	[EntityEventListener(SchemaName = "ChatQueueOperator")]
	[EntityEventListener(SchemaName = "Channel")]
	public class ChangeChatSettingsEventListener : BaseEntityEventListener
	{

		#region Methods: Protected

		/// <summary>
		/// Clears chat operators repository <see cref="ICacheStore"/> instance.
		/// </summary>
		/// <param name="uc"><see cref="UserConnection"/> instance.</param>
		protected void ClearOperatorsCache(UserConnection uc) {
			var cache = new ChatOperatorCache(uc);
			cache.ClearCache();
			new ChatOperatorTransferStore(uc).ClearCache();
		}

		/// <summary>
		/// Distribute chats to operators by chat queue.
		/// </summary>
		/// <param name="uc"><see cref="UserConnection"/> instance.</param>
		/// <param name="chatQueueId">Chat queueu identifier.</param>
		protected void QueueDistribute(UserConnection uc, Guid chatQueueId) {
			var queueDistribution = new ChatQueueDistributor(uc);
			queueDistribution.Distribute(chatQueueId);
		}

		/// <summary>
		/// Re-distribute chats to operators for all active queues.
		/// </summary>
		/// <param name="uc"><see cref="UserConnection"/> instance.</param>
		protected void ReDistributeAllQueues(UserConnection uc) {
			var queueRepository = ClassFactory.Get<ChatQueueRepository>(
				new ConstructorArgument("userConnection", uc));
			var queueIds = queueRepository.GetActiveQueueIds();
			var queueDistributor = ClassFactory.Get<ChatQueueDistributor>(
				new ConstructorArgument("userConnection", uc));
			foreach (var queueId in queueIds) {
				queueDistributor.Distribute(queueId);
			}
		}

		#endregion

		#region Methods: Public

		/// <inheritdoc cref="BaseEntityEventListener.OnInserted"/>
		public override void OnInserted(object sender, EntityAfterEventArgs e) {
			base.OnInserted(sender, e);
			var entity = (Entity)sender;
			ClearOperatorsCache(entity.UserConnection);
			ReDistributeAllQueues(entity.UserConnection);
		}

		/// <inheritdoc cref="BaseEntityEventListener.OnUpdated"/>
		public override void OnUpdated(object sender, EntityAfterEventArgs e) {
			base.OnUpdated(sender, e);
			var entity = (Entity)sender;
			if (entity.SchemaName == "Channel" && entity.GetChangedColumnValues().Any(ccv => ccv.Name == "IsActive")) {
				ClearOperatorsCache(entity.UserConnection);
			}
			if (entity.SchemaName == "Channel" && entity.GetChangedColumnValues()
					.Any(ccv => ccv.Name == "ChatQueueId" || (ccv.Name == "IsActive" && (bool)ccv.Value))) {
				ClearOperatorsCache(entity.UserConnection);
				ReDistributeAllQueues(entity.UserConnection);
			}
		}

		/// <inheritdoc cref="BaseEntityEventListener.OnDeleted"/>
		public override void OnDeleted(object sender, EntityAfterEventArgs e) {
			base.OnDeleted(sender, e);
			var entity = (Entity)sender;
			var userConnection = entity.UserConnection;
			ClearOperatorsCache(userConnection);
			ReDistributeAllQueues(userConnection);
		}

		#endregion

	}
	#endregion

}
