namespace OmnichannelMessaging.Telegram
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using Terrasoft.Common;
	using Terrasoft.Configuration;
	using Terrasoft.Configuration.Omnichannel.Messaging;
	using Terrasoft.Core;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Factories;

	/// <summary>
	/// Handles errors related to Telegram channels in the Omnichannel Messaging system.
	/// </summary>
	public class TelegramChannelErrorHandler
	{
		private readonly UserConnection _userConnection;
		private List<Guid> _chatsManageUsersCache;
		private readonly RemindingUtilities _remindingUtilities;


		/// <summary>
		/// Initializes a new instance of the <see cref="TelegramChannelErrorHandler"/> class.
		/// </summary>
		/// <param name="userConnection">The user connection instance.</param>
		public TelegramChannelErrorHandler(UserConnection userConnection) {
			_userConnection = userConnection;
			_remindingUtilities = ClassFactory.Get<RemindingUtilities>();
		}

		private Entity GetActiveChannelByBot(string botId) {
			var conditions = new Dictionary<string, object> {
				{ "Provider", OmnichannelMessagingConsts.TelegramProvider},
				{ "IsActive", true },
				{ "Source", botId },
			};
			var schema = _userConnection.EntitySchemaManager.GetInstanceByName("Channel");
			var entity = schema.CreateEntity(_userConnection);
			entity.FetchFromDB(conditions);
			return entity;
		}

		private void CreateReminding(Guid contactId, string message) {
			Guid baseEntityUId = _userConnection.EntitySchemaManager.GetItemByName("BaseEntity").UId;
			var config = new RemindingConfig(baseEntityUId) {
				ContactId = contactId,
				RemindTime = DateTime.UtcNow,
				SourceId = RemindingConsts.RemindingSourceAuthorId,
				SubjectId = Guid.Empty,
				Description = message,
				AuthorId = _userConnection.CurrentUser.ContactId

			};
			_remindingUtilities.CreateReminding(_userConnection, config);
		}

		private string GetActiveWebhookMessage(string channelName) {
			string localizableString = new LocalizableString(_userConnection.Workspace.ResourceStorage,
				"TelegramChannelErrorHandler", "LocalizableStrings.ActiveWebhookErrorMessage.Value");
			return string.Format(localizableString, channelName);
		}

		private string GetPollingConflictMessage(string channelName) {
			string localizableString = new LocalizableString(_userConnection.Workspace.ResourceStorage,
				"TelegramChannelErrorHandler", "LocalizableStrings.PollingConflictErrorMessage.Value");
			return string.Format(localizableString, channelName);
		}

		private string GetRevokedTokenMessage(string channelName) {
			string localizableString = new LocalizableString(_userConnection.Workspace.ResourceStorage,
				"TelegramChannelErrorHandler", "LocalizableStrings.RevokedTokenErrorMessage.Value");
			return string.Format(localizableString, channelName);
		}

		private List<Guid> GetChatManageContacts() {
			if (_chatsManageUsersCache != null) {
				return _chatsManageUsersCache;
			}
			_chatsManageUsersCache = new List<Guid>();
			var select = new Select(_userConnection)
				.Column("SAU", "ContactId")
				.From("SysAdminOperationGrantee", "SAOG")
					.InnerJoin("SysAdminUnitInRole").As("SAUIR").On("SAOG", "SysAdminUnitId").IsEqual("SAUIR", "SysAdminUnitRoleId")
					.InnerJoin("SysAdminUnit").As("SAU").On("SAU", "Id").IsEqual("SAUIR", "SysAdminUnitId")
					.InnerJoin("SysAdminOperation").As("SAO").On("SAO", "Id").IsEqual("SAOG", "SysAdminOperationId")
				.Where("SAO", "Code").IsEqual(Column.Const("CanManageChats"))
				.And("SAOG", "CanExecute").IsEqual(Column.Const(true))
				.And("SAU", "Active").IsEqual(Column.Const(true)) as Select;
			using (var dbExecutor = _userConnection.AppConnection.SystemUserConnection.EnsureDBConnection()) {
				using (IDataReader reader = select.ExecuteReader(dbExecutor)) {
					while (reader.Read()) {
						_chatsManageUsersCache.Add(reader.GetColumnValue<Guid>("ContactId"));
					}
				}
			}
			return _chatsManageUsersCache;
		}

		#region Methods: Protected

		protected virtual void DeactivateChannel(string settingId) {
			TelegramClientFactory.Instance.DeactivateChannel(settingId);
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Deactivates the Telegram channel associated with the specified bot ID.
		/// </summary>
		/// <param name="botId">The unique identifier of the Telegram bot.</param>
		public virtual void DeactivateChannelByBotId(string botId) {
			Entity entity = GetActiveChannelByBot(botId);
			DeactivateChannel(entity.GetTypedColumnValue<Guid>("MsgSettingsId").ToString());
			entity.SetColumnValue("IsActive", false);
			entity.SetColumnValue("ErrorCode", "ActiveWebhook");
			entity.Save(false);
			NotifyOmnichannelAdministrators(GetActiveWebhookMessage(entity.GetTypedColumnValue<string>("Name")));
		}

		/// <summary>
		/// Sets polling conflict error without deactivation.
		/// </summary>
		/// <param name="botId">Telegram bot identifier.</param>
		public virtual void SetPollingConflictError(string botId) {
			Entity entity = GetActiveChannelByBot(botId);
			entity.SetColumnValue("ErrorCode", "PollingConflict");
			entity.Save(false);
			NotifyOmnichannelAdministrators(GetPollingConflictMessage(entity.GetTypedColumnValue<string>("Name")));
		}

		/// <summary>
		/// Deactivates the Telegram channel whose bot token was revoked (Unauthorized).
		/// </summary>
		/// <param name="botId">The unique identifier of the Telegram bot.</param>
		public virtual void DeactivateChannelByRevokedToken(string botId) {
			Entity entity = GetActiveChannelByBot(botId);
			DeactivateChannel(entity.GetTypedColumnValue<Guid>("MsgSettingsId").ToString());
			entity.SetColumnValue("IsActive", false);
			entity.SetColumnValue("ErrorCode", "RevokedToken");
			entity.Save(false);
			NotifyOmnichannelAdministrators(GetRevokedTokenMessage(entity.GetTypedColumnValue<string>("Name")));
		}

		/// <summary>
		/// Notifies Omnichannel administrators by creating reminders with a specified message.
		/// </summary>
		/// <param name="message">The notification message to be sent.</param>
		public void NotifyOmnichannelAdministrators(string message) {
			var contactIds = GetChatManageContacts();
			foreach (var contact in contactIds) {
				CreateReminding(contact, message);
			}
		}

		/// <summary>
		/// Resets error for given channel.
		/// </summary>
		/// <param name="channelId">Channel identifier.</param>
		public void ResetError(Guid channelId) {
			new Update(_userConnection, "Channel")
				.Set("ErrorCode", Column.Parameter(string.Empty))
				.Where("Id").IsEqual(Column.Parameter(channelId))
				.Execute();
		}

		#endregion

	}
}

