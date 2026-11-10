namespace Terrasoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Creatio.FeatureToggling;
	using global::Common.Logging;
	using Newtonsoft.Json;
	using Terrasoft.Core;
	using Terrasoft.Common;
	using Terrasoft.Messaging.Common;

	#region Class: WebSocketNotificationSender

	public class WebSocketNotificationSender : INotificationHandler
	{
		#region Constants: Private

		private const string Sender = "NotificationInfo";

		#endregion

		#region Fields: Private

		private readonly MsgChannelManager _channelManager;
		private readonly string _bodyTypeName;
		private readonly UserConnection _userConnection;

		#endregion

		#region Properties: Private

		private ILog _logger;
		private ILog Logger => _logger ?? (_logger = LogManager.GetLogger("WebSocketNotificationSender"));

		#endregion

		#region Construstors: Public

		public WebSocketNotificationSender(UserConnection userConnection): this(userConnection, string.Empty) {
		}

		public WebSocketNotificationSender(UserConnection userConnection, string bodyTypeName) {
			_userConnection = userConnection;
			_channelManager = MsgChannelManager.Instance;
			_bodyTypeName = bodyTypeName;
		}

		#endregion

		#region Methods: Private

		private IMsgChannel GetSysAdminUnitChannel(Guid sysAdminUnit) {
			return _channelManager.FindItemByUId(sysAdminUnit);
		}

		private DateTime RoundDateToSeconds(DateTime dateSource) {
			return dateSource.AddTicks(TimeSpan.TicksPerSecond - dateSource.Ticks % TimeSpan.TicksPerSecond);
		}

		private DateTime GetLastRemindTime(Guid sysAdminUnitId) {
			var sysAdminUniDateTime = NotificationUtilities.GetSysAdminUnitLocalDateTime(_userConnection, sysAdminUnitId);
			return RoundDateToSeconds(sysAdminUniDateTime);
		}

		private NotificationInfoResponse GetNotificationInfoResponse(List<INotificationInfo> notifications) {
			var counters = notifications.Where(n => n.GroupName.IsNotEmpty())
				.GroupBy(n => n.GroupName)
				.Select(group => new {
					group.Key,
					Count = group.Count()
				}).ToDictionary(x => x.Key, x => x.Count);

			var notificationInfoResponse = new NotificationInfoResponse {
				Counters = counters,
				Notifications = notifications
			};
			if (_userConnection.GetIsFeatureEnabled("UseDateForNotificationsQuery") && notifications.Any()) {
				notificationInfoResponse.LastRemindTime =
					GetLastRemindTime(notifications.First().SysAdminUnit);
			}
			return notificationInfoResponse;
		}

		private IMsg GetChannelMessage(Guid sysAdminUnit, NotificationInfoResponse messageBody) {
			Logger.Debug($"Creating message for sysAdminUnit: {sysAdminUnit}");
			var body = Features.GetIsEnabled("SerializeWebSocketNotificationMessage") ?
				JsonConvert.SerializeObject(messageBody) as object : messageBody;
			Logger.Debug("Message body serialized - " + body);
			var message = new SimpleMessage {
				Id = sysAdminUnit,
				Body = body,
				Header = {
					Sender = Sender,
					BodyTypeName = _bodyTypeName
				}
			};
			return message;
		}

		private void SendMessage(Guid sysAdminUnitId, NotificationInfoResponse messageBody) {
			IMsgChannel channel = GetSysAdminUnitChannel(sysAdminUnitId);
			if (channel == null) {
				Logger.Debug($"Channel not found for sysAdminUnit: {sysAdminUnitId}");
				return;
			}
			IMsg message = GetChannelMessage(sysAdminUnitId, messageBody);
			channel.PostMessage(message);
		}

		#endregion

		#region Methods: Public

		public void Handle(IEnumerable<INotificationInfo> notifications) {
			try {
				var notificationsList = notifications?.ToList();
				notificationsList.CheckArgumentNullOrEmpty("notifications");
				Logger.Debug($"Handling {notificationsList.Count} notification(s)");
				var notificationGroups = notificationsList.GroupBy(g => g.SysAdminUnit);
				foreach (var notificationGroup in notificationGroups) {
					Logger.Debug($"Processing notification group for sysAdminUnit: {notificationGroup.Key}, count: {notificationGroup.Count()}");
					var messageBody = GetNotificationInfoResponse(notificationGroup.ToList());
					SendMessage(notificationGroup.Key, messageBody);
				}
			} catch (Exception ex) {
				Logger.Error("Error handling notifications", ex);
				throw;
			}
		}

		#endregion
	}

	#endregion

}
