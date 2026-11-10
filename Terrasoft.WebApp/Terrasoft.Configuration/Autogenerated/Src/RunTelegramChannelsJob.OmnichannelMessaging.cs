namespace Terrasoft.Configuration.Omnichannel.Messaging
{
	using CreatioTelegramConnector.Exceptions;
	using global::Common.Logging;
	using OmnichannelMessaging.Telegram;
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Linq;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.DB;

	#region Class : RunTelegramChannelsJob

	/// <summary>
	/// Job represents a runner of Telegram channels.
	/// </summary>
	public class RunTelegramChannelsJob : IJobExecutor
	{
		#region Constants : Private

		public static string CacheChannelsName = "TelegramChannelsList";

		#endregion

		#region Properties : Private

		private UserConnection _userConnection;
		private List<string> _channelsCache;

		/// <summary>
		/// <see cref="ILog"/> implementation instance.
		/// </summary>
		private ILog _log;
		private ILog Log {
			get {
				return _log ?? (_log = LogManager.GetLogger("OmnichannelMessaging"));
			}
		}

		private TelegramChannelErrorHandler _telegramChannelErrorHandler;
		private TelegramChannelErrorHandler TelegramChannelErrorHandler {
			get
			{
				return _telegramChannelErrorHandler ?? (_telegramChannelErrorHandler = new TelegramChannelErrorHandler(_userConnection));
			}
		}


		#endregion

		#region Methods : Private

		private List<string> GetAllActiveTelegramChannels() {
			List<string> list = new List<string>();
			Select channelSelect = new Select(_userConnection)
				.Column("Id")
				.From("Channel")
				.Where("ProviderId").IsEqual(Column.Parameter(OmnichannelMessagingConsts.TelegramProvider))
					.And("IsActive").IsEqual(Column.Parameter(true)) as Select;
			channelSelect.ExecuteReader(reader => {
				list.Add(reader.GetColumnValue<Guid>("Id").ToString());
			});
			return list;
		}

		private List<string> GetAllActiveTelegramChannelMsgSettingsIds() {
			List<string> list = new List<string>();
			Select channelSelect = new Select(_userConnection)
				.Column("MsgSettingsId")
				.From("Channel")
				.Where("ProviderId").IsEqual(Column.Parameter(OmnichannelMessagingConsts.TelegramProvider))
				.And("IsActive").IsEqual(Column.Parameter(true)) as Select;
			channelSelect.ExecuteReader(reader => {
				list.Add(reader.GetColumnValue<Guid>("MsgSettingsId").ToString());
			});
			return list;
		}

		private void RunTelegramChannels() {
			var channels = GetAllActiveTelegramChannels();
			_channelsCache = _userConnection.ApplicationCache[CacheChannelsName] as List<string> ?? new List<string>();
			var notRanChannelIDs = channels.Where(c => !_channelsCache.Contains(c)).ToList();
			foreach (var channelId in notRanChannelIDs) {
				try {
					TelegramClientFactory.Instance.RunChannel(channelId);
					AddToCache(channelId);
				} catch (InvalidTokenException) {
					Log.ErrorFormat($"Can't run telegram channel {channelId}. Token is not valid. Channel will be disabled.");
					DisableTelegramChannel(Guid.Parse(channelId));
				} catch	(ActiveWebhookException ex) {
					TelegramChannelErrorHandler.DeactivateChannelByBotId(ex.BotId.ToString());
				}
				catch (Exception ex) {
					Log.ErrorFormat($"Can't run telegram channel {channelId}. {ex.Message} {ex.StackTrace}");
				}
			}
		}

		private void CheckTelegramChannels() {
			var clientReceivingStatuses = TelegramClientFactory.Instance.GetClientsReceivingStatus();
			List<string> msgSettingsIds = GetAllActiveTelegramChannelMsgSettingsIds();
			if (!clientReceivingStatuses.Any() && msgSettingsIds.Any() || clientReceivingStatuses.Values.Contains(false)) {
				string reason = !clientReceivingStatuses.Any() ? "is empty" : "has broken clients";
				Log.ErrorFormat($"Telegram client collection {reason}. Reactivating channels...");
				foreach (var settingsId in msgSettingsIds) {
					try {
						TelegramClientFactory.Instance.DeactivateChannel(settingsId);
						TelegramClientFactory.Instance.ActivateChannel(settingsId);
					}
					catch (Exception ex) {
						Log.Error($"An error occured while activating channel: ${ex.Message}");
					}
				}
			}
		}

		private void AddToCache(string channelId) {
			_channelsCache.AddIfNotExists(channelId);
			_userConnection.ApplicationCache[CacheChannelsName] = _channelsCache;
		}

		private void DisableTelegramChannel(Guid channelId) {
			var channelEntity = _userConnection.EntitySchemaManager.GetInstanceByName("Channel").CreateEntity(_userConnection);
			channelEntity.FetchFromDB(channelId);
			string channelName = channelEntity.GetColumnValue("Name").ToString();
			channelEntity.SetColumnValue("IsActive", false);
			channelEntity.Save();
			NotifyOmnichannelAdministrators(channelName);
		}

		private void NotifyOmnichannelAdministrators(string chatName) {
			string message = GetChannelDisabledMessage(chatName);
			TelegramChannelErrorHandler.NotifyOmnichannelAdministrators(message);
		}

		private string GetChannelDisabledMessage(string chatName) {
			string localizableString = new LocalizableString(_userConnection.Workspace.ResourceStorage,
				"RunTelegramChannelsJob", "LocalizableStrings.ChannelDisabledMessageTemplate.Value");
			return string.Format(localizableString, chatName);
		}

		#endregion

		#region Methods : Public

		/// <summary>
		/// Run Telegram channels.
		/// </summary>
		/// <param name="userConnection">User connection.</param>
		/// <param name="parameters">Parameters.</param>
		public virtual void Execute(UserConnection userConnection, IDictionary<string, object> parameters) {
			Log.DebugFormat("RunTelegramChannelsJob have been started");
			_userConnection = userConnection;
			RunTelegramChannels();
			CheckTelegramChannels();
			Log.DebugFormat("RunTelegramChannelsJob finished");
		}

		#endregion

	}

	#endregion

}

