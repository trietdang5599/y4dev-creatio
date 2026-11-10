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
	using System.Security;
	using System.Text.RegularExpressions;
	using Terrasoft.Common;
	using Terrasoft.Common.Json;
	using Terrasoft.Configuration;
	using Terrasoft.Configuration.ESN;
	using Terrasoft.Configuration.RightsService;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.DcmProcess;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Factories;
	using Terrasoft.Core.Process;
	using Terrasoft.Core.Process.Configuration;
	using Terrasoft.GlobalSearch.Indexing;
	using Terrasoft.Messaging.Common;
	using Terrasoft.UI.WebControls.Controls;
	using Terrasoft.UI.WebControls.Utilities.Json.Converters;

	#region Class: SocialMessage_CrtESNEventsProcess

	public partial class SocialMessage_CrtESNEventsProcess<TEntity>
	{
		
		#region Properties: Private

		private ISocialMentionExecutor _socialMentionExecutor;
		private ISocialMentionExecutor SocialMentionExecutor => _socialMentionExecutor ?? (
			_socialMentionExecutor = ClassFactory.Get<SocialMentionExecutor>(
				new ConstructorArgument("userConnection", UserConnection))
			);

		private FeedNotifier _feedNotifier;
		private FeedNotifier FeedNotifier => _feedNotifier ?? (
			_feedNotifier = ClassFactory.Get<FeedNotifier>(new ConstructorArgument("entity", Entity))
			);

		#endregion

		#region Methods: Public

		public Guid GetEntityId() {
			return FeedNotifier.GetEntityId();
		}

		public virtual void SendUpdateDeleteSocialMessage(string operation) {
			FeedNotifier.SendUpdateDeleteSocialMessage(operation);
		}

		public virtual SimpleMessage CreateSimpleMessage(string operation) {
			return FeedNotifier.CreateSimpleMessage(operation);
		}

		public virtual bool GetIsComment() {
			return FeedNotifier.GetIsComment();
		}

		public virtual List<Guid> GetSubscriptors() {
			return FeedNotifier.GetSubscriptors();
		}

		public virtual List<Guid> GetChannelSubscriptors(Guid channelId, string subscriptionTable, string columnPath) {
			return FeedNotifier.GetChannelSubscriptors(channelId, subscriptionTable, columnPath);
		}

		public virtual List<Guid> GetUsersWithoutRightsForMessage(List<Guid> channelSubscriptors) {
			return FeedNotifier.GetUsersWithoutRightsForMessage(channelSubscriptors);
		}

		public virtual bool IsAllAllowedChannelPost(Guid channelId) {
			Select select = new Select(UserConnection)
				.Column("PublisherRightKind")
				.From("SocialChannel")
				.Where("Id").IsEqual(Column.Parameter(channelId)) as Select;
			return select.ExecuteScalar<bool>();
		}

		public virtual Guid GetParentEntitySchemaUId(Guid parentId) {
			return FeedNotifier.GetParentEntitySchemaUId(parentId);
		}

		public virtual Guid GetEntitySchemaUId() {
			return FeedNotifier.GetEntitySchemaUId();
		}

		public virtual string GetTargetSchemaName() {
			return FeedNotifier.GetTargetSchemaName();
		}

		public virtual void CheckSchemaRecordRightLevels(string targetSchemaName, Guid recordId) {
			SchemaRecordRightLevels canEditRight = SchemaRecordRightLevels.CanEdit;
			SchemaRecordRightLevels schemaRightLevel = UserConnection.DBSecurityEngine.GetEntitySchemaRecordRightLevel(targetSchemaName, recordId);
			if ((schemaRightLevel & canEditRight) != canEditRight) {
				throw new SecurityException(string.Format(new LocalizableString("Terrasoft.Core",
						"DBSecurityEngine.Exception.CurrentUserHasNotRightsForObject"), targetSchemaName));
			}
		}

		public virtual void CheckInsertRights() {
			Guid recordId = Entity.GetTypedColumnValue<Guid>("EntityId");
			string targetSchemaName = GetTargetSchemaName();
			if (recordId.IsNotEmpty() && targetSchemaName == "SocialChannel") {
				if (IsAllAllowedChannelPost(recordId)) {
					return;
				}
				else {
					CheckSchemaRecordRightLevels(targetSchemaName, recordId);
				}
			}
		}

		public virtual Dictionary<Guid,Guid> GetConnectedNotifications(Guid socialMessageId) {
			EntitySchemaQuery esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "ESNNotification");
			esq.PrimaryQueryColumn.IsAlwaysSelect = true;
			var sysAdminUnitIdColumn = esq.AddColumn("[SysAdminUnit:Contact:Owner].Id");
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "SocialMessage", socialMessageId));
			return esq.GetEntityCollection(UserConnection).ToDictionary(e=>e.PrimaryColumnValue, 
				e=>e.GetTypedColumnValue<Guid>(sysAdminUnitIdColumn.Name));
		}

		public virtual void PublishDeleteNotificationsMessage() {
			var manager = MsgChannelManager.Instance;
			Dictionary<Guid, Guid> notificationsByOwner = GetConnectedNotifications(Entity.PrimaryColumnValue);
			foreach (var notification in notificationsByOwner) {
				Guid recordId = notification.Key;
				Guid recordOwnerSysAdminUnitId = notification.Value;
				var channel = manager.FindItemByUId(recordOwnerSysAdminUnitId);
				if (channel == null) {
					continue;
				}
				var message = new {
					recordId = recordId,
					notificationGroup = NotificationGroupConst.ESNNotification,
					operation = "delete",
				};
				var simpleMessage = new SimpleMessage {
					Body = JsonConvert.SerializeObject(message),
					Id = recordOwnerSysAdminUnitId,
					Header = {
						Sender = "UpdateReminding"
					}
				};
				channel.PostMessage(simpleMessage);
			}
		}

		public virtual bool IsURLValid(string url) {
			Uri uriResult;
			return Uri.TryCreate(url, UriKind.Absolute, out uriResult) && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
		}

		public virtual string StripHtmlTags(string text) {
			return Regex.Replace(text, "\\<[^\\>]*\\>", String.Empty);
		}

		public virtual void DeleteLinkPreviewInfo() {
		}

		public virtual void DeleteLinkPreviewInfoIfUpdated() {
		}

		public virtual void AddLinkPreviewInfo() {
		}
		
		public virtual void MentionUsers() {
			if (UserConnection.GetIsFeatureEnabled("AddSocialMentionOnUI")) {
				return;
			}
			var message = Entity.GetTypedColumnValue<string>("Message");
			var messageId = Entity.GetTypedColumnValue<Guid>("Id");
			SocialMentionExecutor.MentionContacts(messageId, message);
		}

		#endregion

	}

	#endregion

}

