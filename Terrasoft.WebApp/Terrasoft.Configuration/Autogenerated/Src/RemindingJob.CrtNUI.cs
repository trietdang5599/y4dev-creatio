namespace Terrasoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using global::Common.Logging;
	using Terrasoft.Core.Factories;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using System.Linq;

	#region Class: RemindingJob

	public class RemindingJob : IJobExecutor
	{
		#region Fields: Private

		private UserConnection _userConnection;
		
		#endregion
		
		#region Properties: Private

		private ILog _logger;
		private ILog Logger => _logger ?? (_logger = LogManager.GetLogger("RemindingTracingLogger"));

		#endregion

		#region Properties: Public

		private INotificationSender _notificationSender;
		public INotificationSender NotificationSender {
			get {
				return _notificationSender ?? (_notificationSender = ClassFactory
					       .Get<INotificationSender>(new ConstructorArgument("userConnection", _userConnection)));
			}
			set {
				if (_notificationSender != null) {
					throw new InvalidOperationException();
				}
				_notificationSender = value ?? throw new ArgumentNullException("NotificationSender");
			}
		}

		private IRemindingRepository _remindingRepository;
		public IRemindingRepository RemindingRepository {
			get {
				return _remindingRepository ?? (_remindingRepository = ClassFactory
					       .Get<IRemindingRepository>(new ConstructorArgument("userConnection", _userConnection)));
			}
			set {
				if (_remindingRepository != null) {
					throw new InvalidOperationException();
				}
				_remindingRepository = value ?? throw new ArgumentNullException("RemindingRepository");
			}
		}

		#endregion

		#region Methods: Private

		private void InternalExecute() {
			IEnumerable<INotificationInfo> notificationInfos = RemindingRepository.GetRemindings();
			if (_userConnection.GetIsFeatureEnabled("EnableRemindingTracing")) {
				var message = "User " + _userConnection.CurrentUser.Id + " get such remindings: ";
				LogRemindingInfos(notificationInfos, message);
			}
			if (notificationInfos != null && notificationInfos.IsNotEmpty()) {
				NotificationSender.Send(notificationInfos);
				var notificationsId = notificationInfos.Select(a => a.MessageId);
				RemindingRepository.SetRemindingsIsSent(notificationsId);
				if (_userConnection.GetIsFeatureEnabled("EnableRemindingTracing")) {
					var message = "User " + _userConnection.CurrentUser.Id + " set such remindings as sent: ";
					LogRemindingInfos(notificationInfos, message);
				}
			}
		}

		private void LogRemindingInfos(IEnumerable<INotificationInfo> notificationInfos, string message) {
			string messageInfo = notificationInfos
				.Select(info => "SysAdminUnit:" + info.SysAdminUnit + " entityId:" + info.EntityId + " entitySchemaName:" +
					info.EntitySchemaName + " messageId:" + info.MessageId + " remindTime:" + info.RemindTime + ".\n")
				.Aggregate("", (aggregateMessage, next) => aggregateMessage += next);
			Logger.Info(message + messageInfo);
		}

		#endregion

		#region Methods: Public

		public void Execute(UserConnection userConnection, IDictionary<string, object> parameters) {
			userConnection.CheckArgumentNull(nameof(userConnection));
			_userConnection = userConnection;
			if (_userConnection.GetIsFeatureEnabled("NotificationV2")) {
				InternalExecute();	
			}
		}

		#endregion
	}

	#endregion
}


