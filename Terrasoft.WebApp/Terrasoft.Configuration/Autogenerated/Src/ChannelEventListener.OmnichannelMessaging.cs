namespace Terrasoft.Configuration.Omnichannel.Messaging
{
	using CreatioTelegramConnector.Exceptions;
	using global::Common.Logging;
	using OmnichannelMessaging;
	using OmnichannelMessaging.Telegram;
	using OmnichannelProviders.Domain.Entities;
	using OmnichannelProviders.ProviderResolver;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Terrasoft.Common;
	using Terrasoft.Configuration.BpmonlineCloudIntegration;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Entities.Events;
	using Terrasoft.Core.Factories;

	#region Class: ChannelEventListener
	/// <summary>
	/// Class provides Channel entity events handling.
	/// </summary>
	[EntityEventListener(SchemaName = "Channel")]
	public class ChannelEventListener : BaseEntityEventListener
	{

		#region Enums: Private

		enum ChannelActions
		{
			Unregister,
			Activate,
			Deactivate
		}

		#endregion

		#region Fields: Private

		private readonly Dictionary<ChannelActions, Dictionary<Guid, Action<string>>> _actions =
			new Dictionary<ChannelActions, Dictionary<Guid, Action<string>>>();

		#endregion

		#region Constructors: Public

		public ChannelEventListener() {
			LoggerWrapper.Logger = LogManager.GetLogger("OmnichannelMessagingLib");
			InitActions();
		}

		#endregion

		#region Methods: Private

		private void InitActions() {
			_actions.Add(ChannelActions.Unregister, new Dictionary<Guid, Action<string>> {
				 { OmnichannelMessagingConsts.TelegramProvider, TelegramClientFactory.Instance.UnregisterChannel }
			});

			_actions.Add(ChannelActions.Activate, new Dictionary<Guid, Action<string>> {
				 { OmnichannelMessagingConsts.TelegramProvider, TelegramClientFactory.Instance.ActivateChannel }
			});

			_actions.Add(ChannelActions.Deactivate, new Dictionary<Guid, Action<string>> {
				 { OmnichannelMessagingConsts.TelegramProvider, TelegramClientFactory.Instance.DeactivateChannel }
			});
		}

		private void DoAction(Entity channel, ChannelActions action) {
			var providerId = channel.GetTypedColumnValue<Guid>("ProviderId");
			if (_actions.TryGetValue(action, out var actions) && actions.TryGetValue(providerId, out var callAction)) {
				var id = channel.GetTypedColumnValue<Guid>("MsgSettingsId").ToString();
				callAction(id);
			}
		}

		private void ValidateChannelBeforeDeleting(Entity channel) {
			var channelId = channel.PrimaryColumnValue;
			var userConnection = channel.UserConnection;
			var chatProvider = ClassFactory.Get<OmnichannelChatProvider>(
				new ConstructorArgument("userConnection", userConnection));
			if (chatProvider.GetHasUncompletedChats(channelId)) {
				var resourceStorage = userConnection.ResourceStorage;
				var message = new LocalizableString(resourceStorage, "ChannelEventListener",
					"LocalizableStrings.ActiveChannelChatsValidationError.Value");
				throw new Exception(message);
			}
		}

		private void RemoveChannel(Entity channel) {
			try {
				var manager = new MessageManager(channel.UserConnection);
				if (TryGetDeletionData(channel, out MessengerDeletionData data)) {
					manager.RemoveChannel(data);
				} else {
					LoggerWrapper.Logger.Warn($"Channel '{channel.PrimaryDisplayColumnValue}' " +
						$"with provider '{channel.GetTypedColumnValue<Guid>("ProviderId")}' was not found.");
				}
			} catch (Exception e) {
				LoggerWrapper.Logger.Error($"Channel '{channel.PrimaryDisplayColumnValue}' " +
							$"with provider '{channel.GetTypedColumnValue<Guid>("ProviderId")}' was not removed.", e);
			}
		}

		private bool TryGetDeletionData(Entity channel, out MessengerDeletionData data) {
			var provider = GetChannelProviderResolver(channel);
			data = provider?.GetDeletionData(channel.PrimaryColumnValue.ToString());
			return data != null;
		}

		private ChannelProviderResolver GetChannelProviderResolver(Entity channel) {
			var providerId = channel.GetTypedColumnValue<Guid>("ProviderId");
			var providers = ClassFactory.GetAll<ChannelProviderResolver>(new ConstructorArgument("uc", channel.UserConnection));
			return providers.FirstOrDefault(p => p.ProviderId == providerId);
		}

		private void EnsureMsgSettingsIdLoaded(Entity channel) {
			if (channel.GetTypedColumnValue<Guid>("MsgSettingsId") != Guid.Empty) {
				return;
			}
			channel.FetchFromDB(new[] { "MsgSettingsId" });
		}

		#endregion

		#region Methods: Public

		/// <inheritdoc cref="BaseEntityEventListener.OnDeleted"/>
		public override void OnDeleted(object sender, EntityAfterEventArgs e) {
			base.OnDeleted(sender, e);
			var entity = (Entity)sender;
			DoAction(entity, ChannelActions.Unregister);
		}

		/// <inheritdoc cref="BaseEntityEventListener.OnDeleting"/>
		public override void OnDeleting(object sender, EntityBeforeEventArgs e) {
			var entity = (Entity)sender;
			ValidateChannelBeforeDeleting(entity);
			EnsureMsgSettingsIdLoaded(entity);
			RemoveChannel(entity);
			base.OnDeleting(sender, e);
		}

		public override void OnUpdating(object sender, EntityBeforeEventArgs e) {
			base.OnUpdating(sender, e);
			var entity = (Entity)sender;
			var isActive = entity.GetChangedColumnValues().FirstOrDefault(ccv => ccv.Name == "IsActive");
			if (isActive != null) {
				if ((bool)isActive.Value == true) {
					try {
						DoAction(entity, ChannelActions.Activate);
						if (!string.IsNullOrEmpty(entity.GetTypedColumnValue<string>("ErrorCode"))) {
							var errorHandler = ClassFactory.Get<TelegramChannelErrorHandler>(
								new ConstructorArgument("userConnection", entity.UserConnection));
							errorHandler.ResetError(entity.GetTypedColumnValue<Guid>("Id"));
							var botId = entity.GetTypedColumnValue<string>("Source");
							if (botId.IsNullOrEmpty()) {
								if (entity.FetchFromDB(new[] { "Source" })) {
									botId = entity.GetTypedColumnValue<string>("Source");
								}
							}
							TelegramMessageReceiver.ResetPollingConflictFlag(botId);
						}
					} catch (ActiveWebhookException) {
						var resourceStorage = entity.UserConnection.ResourceStorage;
						var message = new LocalizableString(resourceStorage, "ChannelEventListener",
							"LocalizableStrings.ActiveWebhookChannelActivationError.Value");
						throw new Exception(message);
					} catch (Exception) {
						throw;
					}
				} else {
					DoAction(entity, ChannelActions.Deactivate);
				}
			}
		}

		#endregion

	}

	#endregion

}
