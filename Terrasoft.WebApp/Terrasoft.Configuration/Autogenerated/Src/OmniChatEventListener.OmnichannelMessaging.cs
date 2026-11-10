namespace Terrasoft.Configuration.Omnichannel.Messaging
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Terrasoft.Common;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Entities.Events;

	#region Class: OmniChatEventListener

	/// <summary>
	/// Class provides OmniChat entity events handling.
	/// </summary>
	[EntityEventListener(SchemaName = "OmniChat")]
	public class OmniChatEventListener : BaseEntityEventListener
	{

		#region Methods: Private

		private const string IdColumnName = "Id";
		private const string AcceptDateColumnName = "AcceptDate";
		private const string StatusIdColumnName = "StatusId";
		private const string OperatorIdColumnName = "OperatorId";
		private const string DirectedOperatorIdColumnName = "DirectedOperatorId";
		private const string QueueIdColumnName = "QueueId";

		private Entity GetEntity(object sender) {
			return (Entity)sender;
		}

		private Guid GetCurrentOrOldColumnValue(Entity chat, string columnName) {
			Guid currentValue = chat.GetTypedColumnValue<Guid>(columnName);
			return currentValue.IsNotEmpty()
				? currentValue
				: chat.GetTypedOldColumnValue<Guid>(columnName);
		}

		private Guid GetOldOrCurrentColumnValue(Entity chat, string columnName) {
			Guid oldValue = chat.GetTypedOldColumnValue<Guid>(columnName);
			return oldValue.IsNotEmpty()
				? oldValue
				: chat.GetTypedColumnValue<Guid>(columnName);
		}

		private void SetFieldValues(Entity chat) {
			Guid operatorId = chat.GetTypedColumnValue<Guid>(OperatorIdColumnName);
			Guid oldOperatorId = chat.GetTypedOldColumnValue<Guid>(OperatorIdColumnName);
			if (operatorId == oldOperatorId) {
				return;
			}
			if (operatorId.IsNotEmpty()) {
				chat.SetColumnValue(AcceptDateColumnName, chat.UserConnection.CurrentUser.GetCurrentDateTime());
				chat.SetColumnValue(DirectedOperatorIdColumnName, null);
			} else if (oldOperatorId.IsNotEmpty()) {
				chat.SetColumnValue(AcceptDateColumnName, null);
			}
		}

		private void DeleteOmnichannelMessages(Entity chat) {
			new Delete(chat.UserConnection)
				.From("OmnichannelMessages")
				.Where("ChatId").IsEqual(Column.Parameter(chat.GetTypedColumnValue<Guid>(IdColumnName)))
				.Execute();
		}

		private bool IsWaitingForProcessingStatus(Guid statusId) {
			return statusId == OmnichannelMessagingConsts.WaitingForProcessing;
		}

		private bool IsColumnModified(EntityAfterEventArgs e, string columnName) {
			return e.ModifiedColumnValues.Any(column => column.Name == columnName);
		}

		private bool IsStatusChangedWithWaitingForProcessingTransition(Entity chat, EntityAfterEventArgs e) {
			if (!IsColumnModified(e, StatusIdColumnName)) {
				return false;
			}
			Guid oldStatusId = chat.GetTypedOldColumnValue<Guid>(StatusIdColumnName);
			Guid currentStatusId = chat.GetTypedColumnValue<Guid>(StatusIdColumnName);
			return IsWaitingForProcessingStatus(oldStatusId)
				|| IsWaitingForProcessingStatus(currentStatusId);
		}

		private bool IsInsertedChatWithWaitingForProcessingStatus(Entity chat) {
			Guid statusId = chat.GetTypedColumnValue<Guid>(StatusIdColumnName);
			return IsWaitingForProcessingStatus(statusId);
		}

		private bool IsDeletedChatWithWaitingForProcessingStatus(Entity chat) {
			Guid statusId = GetOldOrCurrentColumnValue(chat, StatusIdColumnName);
			return IsWaitingForProcessingStatus(statusId);
		}

		private bool IsFreeChatsCacheInvalidationRequired(Entity chat, EntityAfterEventArgs e) {
			return IsStatusChangedWithWaitingForProcessingTransition(chat, e)
				|| IsColumnModified(e, OperatorIdColumnName)
				|| IsColumnModified(e, DirectedOperatorIdColumnName)
				|| IsColumnModified(e, QueueIdColumnName);
		}

		private bool IsOptimizationEnabled(Entity entity) {
			return entity.UserConnection.GetIsFeatureEnabled("OmnichannelOptimization");
		}

		private void ResetFreeChatsByQueueCache(Entity chat, List<Guid> chatQueueIds) {
			var processedQueueIds = new HashSet<Guid>();
			foreach (Guid chatQueueId in chatQueueIds) {
				if (chatQueueId.IsEmpty() || !processedQueueIds.Add(chatQueueId)) {
					continue;
				}
				ChatRepository.ResetFreeChatsByQueueCache(chat.UserConnection, chatQueueId);
			}
		}

		private void ResetFreeChatsByQueueCacheOnInserted(Entity chat) {
			if (!IsOptimizationEnabled(chat) || !IsInsertedChatWithWaitingForProcessingStatus(chat)) {
				return;
			}
			ResetFreeChatsByQueueCache(chat, new List<Guid> {
				chat.GetTypedColumnValue<Guid>(QueueIdColumnName)
			});
		}

		private void ResetFreeChatsByQueueCacheOnUpdated(Entity chat, EntityAfterEventArgs e) {
			if (!IsOptimizationEnabled(chat) || !IsFreeChatsCacheInvalidationRequired(chat, e)) {
				return;
			}
			Guid queueId = chat.GetTypedColumnValue<Guid>(QueueIdColumnName);
			if (IsColumnModified(e, QueueIdColumnName)) {
				Guid oldQueueId = chat.GetTypedOldColumnValue<Guid>(QueueIdColumnName);
				ResetFreeChatsByQueueCache(chat, new List<Guid> {
					queueId,
					oldQueueId
				});
				return;
			}
			ResetFreeChatsByQueueCache(chat, new List<Guid> {
				queueId
			});
		}

		private void ResetFreeChatsByQueueCacheOnDeleted(Entity chat) {
			if (!IsOptimizationEnabled(chat) || !IsDeletedChatWithWaitingForProcessingStatus(chat)) {
				return;
			}
			Guid queueId = GetCurrentOrOldColumnValue(chat, QueueIdColumnName);
			ResetFreeChatsByQueueCache(chat, new List<Guid> {
				queueId
			});
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Handles entity Updating event.
		/// </summary>
		/// <param name="sender">Event sender.</param>
		/// <param name="e">The <see cref="T:Terrasoft.Core.Entities.EntityBeforeEventArgs" /> instance containing
		/// event data.</param>
		public override void OnUpdating(object sender, EntityBeforeEventArgs e) {
			Entity entity = GetEntity(sender);
			SetFieldValues(entity);
			base.OnUpdating(sender, e);
		}

		/// <inheritdoc cref="BaseEntityEventListener.OnInserted"/>
		public override void OnInserted(object sender, EntityAfterEventArgs e) {
			base.OnInserted(sender, e);
			Entity entity = GetEntity(sender);
			ResetFreeChatsByQueueCacheOnInserted(entity);
		}

		/// <inheritdoc cref="BaseEntityEventListener.OnUpdated"/>
		public override void OnUpdated(object sender, EntityAfterEventArgs e) {
			base.OnUpdated(sender, e);
			Entity entity = GetEntity(sender);
			ResetFreeChatsByQueueCacheOnUpdated(entity, e);
		}

		/// <inheritdoc cref="BaseEntityEventListener.OnDeleted"/>
		public override void OnDeleted(object sender, EntityAfterEventArgs e) {
			base.OnDeleted(sender, e);
			Entity chat = GetEntity(sender);
			ResetFreeChatsByQueueCacheOnDeleted(chat);
			DeleteOmnichannelMessages(chat);
		}

		#endregion

	}

	#endregion

} 
