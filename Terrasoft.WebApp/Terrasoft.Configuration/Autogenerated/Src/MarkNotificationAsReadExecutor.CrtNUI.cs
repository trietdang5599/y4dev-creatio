namespace Terrasoft.Configuration.Notifications
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Factories;
	using CoreSysSettings = Terrasoft.Core.Configuration.SysSettings;

	#region Class: MarkNotificationAsReadExecutor

	[DefaultBinding(typeof(IMarkNotificationAsReadExecutor), Name = "MarkNotificationAsReadExecutor")]
	public class MarkNotificationAsReadExecutor : IMarkNotificationAsReadExecutor
	{

		#region Constants: Private

		private const int MaxAllowedChunkSize = 1000;

		#endregion

		#region Fields: Private

		private readonly UserConnection _userConnection;
		private readonly INotificationMarkAsReadStrategyFactory _strategyFactory;
		private int _notificationSelectChunkSize;

		#endregion

		#region Constructors: Public

		public MarkNotificationAsReadExecutor(UserConnection userConnection)
			: this(userConnection, ClassFactory.Get<INotificationMarkAsReadStrategyFactory>()) { }
		public MarkNotificationAsReadExecutor(UserConnection userConnection, INotificationMarkAsReadStrategyFactory strategyFactory) {
			_userConnection = userConnection;
			_strategyFactory = strategyFactory;
		}

		#endregion

		#region Properties: Private

		private int NotificationSelectChunkSize {
			get {
				if (_notificationSelectChunkSize > 0)
					return _notificationSelectChunkSize;
				InitNotificationSelectChunkSize();
				return _notificationSelectChunkSize;
			}
		}

		#endregion

		#region Methods: Private

		private void InitNotificationSelectChunkSize() {
			if (!CoreSysSettings.TryGetValue(_userConnection, "UpdateNotificationStatusChunkSize",
				out object sysSettingsValue)) {
				_notificationSelectChunkSize = MaxAllowedChunkSize;
				return;
			}
			var sysSettingsChunkSize = Convert.ToInt32(sysSettingsValue);
			_notificationSelectChunkSize = sysSettingsChunkSize <= 0 || sysSettingsChunkSize > MaxAllowedChunkSize
				? MaxAllowedChunkSize
				: sysSettingsChunkSize;
		}

		#endregion

		#region Methods: Public

		public void Execute(Guid notificationTypeId, DateTime remindTime) {
			notificationTypeId.CheckArgumentEmpty(nameof(notificationTypeId));
			var strategy = _strategyFactory.GetStrategy(notificationTypeId);
			IEnumerable<Guid> notificationIds;
			while ((notificationIds = strategy.GetNotificationsToMark(remindTime, NotificationSelectChunkSize)).Any()) {
				strategy.MarkAsRead(notificationIds);
			}
		}

		#endregion

	}

	#endregion

}
