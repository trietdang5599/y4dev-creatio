namespace Terrasoft.Configuration
{

	using DataContract = Terrasoft.Nui.ServiceModel.DataContract;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Data;
	using System.Drawing;
	using System.Globalization;
	using System.IO;
	using System.Linq;
	using global::Common.Logging;
	using Terrasoft.Common;
	using Terrasoft.Common.Json;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.DcmProcess;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Factories;
	using Terrasoft.Core.Process;
	using Terrasoft.Core.Process.Configuration;
	using Terrasoft.Core.Store;
	using Terrasoft.GlobalSearch.Indexing;
	using Terrasoft.Messaging.Common;
	using Terrasoft.UI.WebControls.Controls;
	using Terrasoft.UI.WebControls.Utilities.Json.Converters;

	#region Class: Reminding_CrtBaseEventsProcess

	public partial class Reminding_CrtCoreBaseEventsProcess<TEntity>
	{
		#region Properties: Private

		private ILog _logger;
		private ILog Logger => _logger ?? (_logger = LogManager.GetLogger("RemindingTracingLogger"));

		#endregion

		#region Methods: Public

		public virtual void PublishClientRemindingInfo(string operation) {
			string notificationGroup = TryGeNotificationTypeName();
			var remindTime = Entity.GetTypedColumnValue<DateTime>("RemindTime");
			if (remindTime > UserConnection.CurrentUser.GetCurrentDateTime() && !IsRemindingPostponed) {
				return;
			}
			var contactId = Entity.GetTypedColumnValue<Guid>("ContactId");
			var sysAdminUnit = GetSysAdminUnitIdByContactId(contactId);
			var isReadOld = Entity.GetTypedOldColumnValue<bool>("IsRead");
			var message = new {
				recordId = Entity.Id,
				operation,
				notificationGroup,
				markAsRead = !isReadOld && Entity.IsRead
			};
			var simpleMessage = new SimpleMessage {
				Body = JsonConvert.SerializeObject(message),
				Id = sysAdminUnit
			};
			simpleMessage.Header.Sender = "UpdateReminding";
			if (MsgChannelManager.Instance == null) {
				Logger.Warn($"MsgChannelManager.Instance is null, so can't publish client reminding");
				return;
			}
			var manager = MsgChannelManager.Instance;
			var channel = manager.FindItemByUId(sysAdminUnit);
			channel?.PostMessage(simpleMessage);
		}

		public virtual Guid GetSysAdminUnitIdByContactId(Guid contactId) {
			var currentUser = UserConnection.CurrentUser;
			if (currentUser.ContactId == contactId) {
				return currentUser.Id;
			}
			var entitySchemaManager = UserConnection.EntitySchemaManager;
			var esq = new EntitySchemaQuery(entitySchemaManager, "SysAdminUnit") {
				UseAdminRights = false,
				IgnoreDisplayValues = true,
				CanReadUncommitedData = true,
				Cache = UserConnection.ApplicationCache.WithLocalCaching("NotificationUsers"),
				CacheItemName = contactId.ToString()
			};
			esq.PrimaryQueryColumn.IsAlwaysSelect = true;
			var queryFilterItem = esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Contact", contactId);
			esq.Filters.Add(queryFilterItem);
			var entities = esq.GetEntityCollection(UserConnection);
			if (entities.IsEmpty()) {
				return Guid.Empty;
			}
			var entity = entities.First.Value;
			return entity.GetTypedColumnValue<Guid>(esq.PrimaryQueryColumn.Name);
		}

		public virtual string GetSchemaName(ISchemaManager schemaManager, Guid entitySchemaId) {
			var schemaManagerItem = schemaManager.FindItemByUId(entitySchemaId);
			return schemaManagerItem != null ? schemaManagerItem.Name : string.Empty;
		}

		public virtual void OnInsertedHandle() {
			if (Entity.NotificationTypeId != RemindingConsts.NotificationTypeRemindingId ||
					IsRemindingForImmediateSend) {
				SendNotification();
				IsRemindingForImmediateSend = false;
			}
		}

		public virtual void OnInsertingHandle() {
			IsNew = true;
		}

		public virtual void OnSavingHandler() {
			if (Entity.NotificationTypeId == RemindingConsts.NotificationTypeRemindingId) {
				IsRemindingPostponed = GetIsRemindingPostponed();
				if (IsChangedTargetColumns()) {
					Entity.IsNeedToSend = true;
					if (UserConnection.GetIsFeatureEnabled("EnableRemindingTracing")) {
						string message = "Remindings " + Entity.Id + " IsNeedToSend column sets to true";
						Logger.Info("User " + UserConnection.CurrentUser.Id + " has such changes: " + message);
					}
				}
				if (!IsCorrectRemindTime()) {
					Entity.IsNeedToSend = false;
					if (UserConnection.GetIsFeatureEnabled("EnableRemindingTracing")) {
						string message = "Remindings " + Entity.Id + " IsNeedToSend column sets to false";
						Logger.Info("User " + UserConnection.CurrentUser.Id + " has such changes: " + message);
					}
					IsRemindingForImmediateSend = true;
				}
			} else if (Entity.StoringState == StoringObjectState.Changed) {
				var changedColumns = Entity.GetChangedColumnValues();
				if (changedColumns.Any(column => column.Name == "IsRead")) {
					PublishClientRemindingInfo("update");
				}
				if (IsChangedTargetColumns()) {
					IsRemindingForImmediateSend = true;
				}
			}
		}

		public virtual bool IsChangedTargetColumns() {
			IEnumerable<string> targetColumns = GetTargetColumnsForChange();
			var changedColumns = Entity.GetChangedColumnValues();
			return changedColumns.Any(column => targetColumns.Contains(column.Name));
		}

		public virtual IEnumerable<string>  GetTargetColumnsForChange() {
			return new[] {"RemindTime", "ContactId", "Description", "SubjectCaption"};
		}

		public virtual void OnSavedHandler() {
			if (IsRemindingForImmediateSend) {
				if (!Entity.IsRead) {
					PublishClientRemindingInfo("delete");
				}
				SendNotification();
				return;
			}
			if (Entity.NotificationTypeId == RemindingConsts.NotificationTypeRemindingId || !Entity.IsRead) {
				var operation = !IsCorrectRemindTime() ? "update" : "delete";
				if (UserConnection.GetIsFeatureEnabled("NotificationV2")) {
					if (IsNew) {
						return;
					}
				}
				PublishClientRemindingInfo(operation);
			}
		}

		public virtual bool IsCorrectRemindTime() {
			var currentDateTime = UserConnection.CurrentUser.GetCurrentDateTime();
			if (Entity.RemindTime <= currentDateTime) {
				return false;
			}
			return true;
		}

		public virtual void SendNotification() {
		}

		public virtual string TryGeNotificationTypeName() {
			var entitySchema = UserConnection.EntitySchemaManager.FindInstanceByName("NotificationType");
			var entity = entitySchema.CreateEntity(UserConnection);
			entity.FetchFromDB(entitySchema.PrimaryColumn.Name, Entity.NotificationTypeId,
				new[] {entitySchema.PrimaryDisplayColumn.Name});
			return entity.PrimaryDisplayColumnValue;
		}

		public virtual bool GetIsRemindingPostponed() {
			DateTime currentDateTime = UserConnection.CurrentUser.GetCurrentDateTime();
			bool oldNeedToSend = Entity.GetTypedOldColumnValue<bool>("IsNeedToSend");
			DateTime oldRemindTime = Entity.GetTypedOldColumnValue<DateTime>("RemindTime");
			DateTime newRemindTime = Entity.GetTypedColumnValue<DateTime>("RemindTime");
			bool oldRemindTimePassed = currentDateTime >= oldRemindTime && oldRemindTime != default(DateTime);
			bool remindTimeChanged = oldRemindTime != newRemindTime;
			return oldRemindTimePassed && remindTimeChanged && !oldNeedToSend;
		}

		#endregion

	}

	#endregion

}

