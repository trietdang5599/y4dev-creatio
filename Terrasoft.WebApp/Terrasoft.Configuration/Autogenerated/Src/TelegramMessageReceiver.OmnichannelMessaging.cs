namespace OmnichannelMessaging.Telegram
{
	using Common.Logging;
	using CreatioTelegramConnector;
	using CreatioTelegramConnector.Contracts;
	using global::Telegram.Bot;
	using global::Telegram.Bot.Polling;
	using global::Telegram.Bot.Types;
	using OmnichannelProviders.Domain.Entities;
	using System;
	using System.Collections.Generic;
	using System.Threading;
	using System.Threading.Tasks;
	using Terrasoft.Configuration.Omnichannel.Messaging;
	using Terrasoft.Core;
	using System.Collections.Concurrent;

	#region Class : SizedQueue<T>

	public sealed class FixedSizeQueue<T> : Queue<T>
	{

		#region Properties: Protected

		private int _size { get; }

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Initializes new instance of <see cref="FixedSizeQueue<T>"/>.
		/// </summary>
		/// <param name="fixedSize">Size of queue.</param>
		public FixedSizeQueue(int fixedSize) {
			_size = fixedSize;
		}

		#endregion

		/// <summary>
		/// If the total number of item exceed the capacity, the oldest ones automatically dequeues.
		/// </summary>
		/// <returns>The dequeued value, if any.</returns>
		public new T Enqueue(T item) {
			base.Enqueue(item);
			if (base.Count > _size) {
				return base.Dequeue();
			}
			return default;
		}
	}

	#endregion

	/// <summary>
	/// Receive messages from telegram bot api.
	/// </summary>
	public class TelegramMessageReceiver : IUpdateHandler
	{
		#region Constants: Private

		private int _messagesCount = 10;
		private static readonly ConcurrentDictionary<string, bool> _oneTimeErrors = new ConcurrentDictionary<string, bool>();
		private const string PollingConflictKey = "PollingConflict";
		private const string BadGatewayKey = "BadGateway";
		private const string RequestTimedOutKey = "RequestTimedOut";
		private const string UnauthorizedKey = "Unauthorized";

		#endregion

		#region Properties: Protected

		/// <summary>
		/// User connection.
		/// </summary>
		protected UserConnection UserConnection { get; }

		/// <summary>
		/// Last messages data received through the channel.
		/// </summary>
		protected Dictionary<string, FixedSizeQueue<string>> LastChannelMessages = new Dictionary<string, FixedSizeQueue<string>>();

		/// <summary>
		/// User connection.
		/// </summary>
		protected TelegramOmnichannelMessagingService TelegramService { get; }

		private ILog _log;
		/// <summary>
		/// Creatio logger.
		/// </summary>
		protected ILog Log => _log ?? (_log = LogManager.GetLogger("OmnichannelMessageHandler"));

		private TelegramChannelErrorHandler _telegramChannelErrorHandler;
		private TelegramChannelErrorHandler TelegramChannelErrorHandler =>
			_telegramChannelErrorHandler ?? (_telegramChannelErrorHandler = new TelegramChannelErrorHandler(UserConnection));

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Initializes new instance of <see cref="TelegramOmnichannelMessagingService"/>.
		/// </summary>
		public TelegramMessageReceiver(UserConnection userConnection) {
			UserConnection = userConnection;
			TelegramService = new TelegramOmnichannelMessagingService(UserConnection);
		}

		/// <summary>
		/// Initializes new instance of <see cref="TelegramOmnichannelMessagingService"/>.
		/// </summary>
		public TelegramMessageReceiver(UserConnection userConnection, ILog logger) : this(userConnection) {
			_log = logger;
		}

		/// <summary>
		/// Initializes new instance of <see cref="TelegramOmnichannelMessagingService"/>.
		/// </summary>
		public TelegramMessageReceiver(UserConnection userConnection, ILog logger,
			TelegramChannelErrorHandler telegramChannelErrorHandler) : this(userConnection, logger) {
			_telegramChannelErrorHandler = telegramChannelErrorHandler;
		}

		#endregion

		#region Methods: Private

		/// <summary>
		/// Sends message to Creatio.
		/// </summary>
		/// <param name="message">Message <see cref="IncomingMessage"/>.</param>
		private void OnReceivedMessage(IncomingMessage message) {
			TelegramService.ReceiveMessage(TelegramIncomeMessageWorker.Convert(message));
		}

		/// <summary>
		/// Sends message to Creatio.
		/// </summary>
		/// <param name="message">Message <see cref="FileIncomingMessage"/>.</param>
		private void OnReceivedFile(FileIncomingMessage message) {
			TelegramService.ReceiveMessage(TelegramIncomeMessageWorker.Convert(message));
		}

		private void ProccessMessage(FileIncomingMessage message, bool isMessageTypeAvaliable) {
			if (TelegramUtilities.IsTextMessageType(message)) {
				OnReceivedMessage(message);
			} else if (isMessageTypeAvaliable) {
				OnReceivedFile(message);
			}
		}

		private bool IsMessageNotDuplicate(FileIncomingMessage message) {
			string messageData = GetUniqueMessageData(message);
			var result = true;
			if (LastChannelMessages.TryGetValue(message.ChannelId, out FixedSizeQueue<string> messages)) {
				result = !messages.Contains(messageData);
				messages.Enqueue(messageData);
				LastChannelMessages[message.ChannelId] = messages;
			} else {
				var channelMessages = new FixedSizeQueue<string>(_messagesCount);
				channelMessages.Enqueue(messageData);
				LastChannelMessages.Add(message.ChannelId, channelMessages);
			}
			return result;
		}

		private string GetUniqueMessageData(FileIncomingMessage message) =>
			message.FileId ?? (message.Date.ToString() + message.UserId + message.Text);

		private void LogUnknownError(ITelegramBotClient botClient, Exception exception, HandleErrorSource source) {
			string errorMessage = $"Error in Telegram channel, botId: {botClient.BotId}. Error message: {exception.Message}";
			switch (source) {
				case HandleErrorSource.HandleUpdateError:
					Log.Error("Error receiving the message. " + errorMessage);
					break;
				case HandleErrorSource.PollingError:
					Log.Error("Polling error. " + errorMessage);
					break;
				case HandleErrorSource.FatalError:
					Log.Error("Fatal error. " + errorMessage);
					break;
				default:
					Log.Error(errorMessage);
					break;
			}
		}

		private static bool Contains(string src, string token) =>
			!string.IsNullOrEmpty(src) && src.IndexOf(token, StringComparison.OrdinalIgnoreCase) >= 0;

		private string DetectErrorKey(Exception exception) {
			if (exception == null || string.IsNullOrEmpty(exception.Message)) {
				return null;
			}
			string msg = exception.Message;
			bool isPollingConflict = Contains(msg, "terminated by other getUpdates request") ||
				(Contains(msg, "Conflict") && Contains(msg, "getUpdates"));
			if (isPollingConflict) {
				return PollingConflictKey;
			}
			if (Contains(msg, "Bad Gateway")) {
				return BadGatewayKey;
			}
			if (Contains(msg, "Request timed out")) {
				return RequestTimedOutKey;
			}
			if (Contains(msg, "Unauthorized")) {
				return UnauthorizedKey;
			}
			return null;
		}

		private bool TryLogOneTime(long botId, string errorKey, Action logAction) {
			string compositeKey = botId + ":" + errorKey;
			if (_oneTimeErrors.TryAdd(compositeKey, true)) {
				logAction?.Invoke();
				return true;
			}
			return false;
		}

		#endregion

		#region Methods: Public

		/// <inheritdoc cref="IUpdateHandler"/>
		public Task HandleUpdateAsync(ITelegramBotClient botClient, Update e, CancellationToken cancellationToken) {
			var message = TelegramUtilities.GetIncomnigMessage(botClient, e, out bool isMessageTypeAvaliable);
			if (IsMessageNotDuplicate(message)) {
				ProccessMessage(message, isMessageTypeAvaliable);
			} else {
				Log.Info($"Duplicate message in channel {message.ChannelId}: {message.Text}");
			}
			return Task.CompletedTask;
		}

		/// <inheritdoc cref="IUpdateHandler"/>
		public Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, HandleErrorSource source, CancellationToken cancellationToken) {
			if (exception?.Message?.Contains("webhook is active") == true) {
				Log.Error($"Active webhook for botId: {botClient.BotId}. Message {exception.Message}");
				TelegramChannelErrorHandler.DeactivateChannelByBotId(botClient.BotId.ToString());
				return Task.CompletedTask;
			}

			string errorKey = DetectErrorKey(exception);
			if (errorKey == null) {
				LogUnknownError(botClient, exception, source);
				return Task.CompletedTask;
			}

			if (errorKey == PollingConflictKey) {
				TryLogOneTime(botClient.BotId, errorKey, () => {
					Log.Error($"Polling conflict detected for botId {botClient.BotId}. Error: {exception.Message}");
					TelegramChannelErrorHandler.SetPollingConflictError(botClient.BotId.ToString());
				});
			} else if (errorKey == BadGatewayKey) {
				TryLogOneTime(botClient.BotId, errorKey, () =>
					Log.Error($"Bad Gateway for botId {botClient.BotId}. Error: {exception.Message}"));
			} else if (errorKey == RequestTimedOutKey) {
				TryLogOneTime(botClient.BotId, errorKey, () =>
					Log.Error($"Request timed out for botId {botClient.BotId}. Error: {exception.Message}"));
			} else if (errorKey == UnauthorizedKey) {
				TryLogOneTime(botClient.BotId, errorKey, () => {
					Log.Error($"Unauthorized token (revoked) for botId {botClient.BotId}. Error: {exception.Message}");
					TelegramChannelErrorHandler.DeactivateChannelByRevokedToken(botClient.BotId.ToString());
				});
			}
			return Task.CompletedTask;
		}

		/// <summary>
		/// Resets one-time error flags for specified bot id.
		/// <param name="botId">Bot identifier.</param>
		/// </summary>
		public static void ResetPollingConflictFlag(string botId) {
			if (!long.TryParse(botId, out long id)) {
				return;
			}
			string prefix = id + ":";
			foreach (var key in _oneTimeErrors.Keys) {
				if (key.StartsWith(prefix, StringComparison.Ordinal)) {
					_oneTimeErrors.TryRemove(key, out _);
				}
			}
		}

		#endregion

	}
}

