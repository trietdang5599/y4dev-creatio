namespace Terrasoft.Configuration.Notifications
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.Factories;

	[DefaultBinding(typeof(INotificationMarkAsReadStrategy), Name = "RemindingNotificationMarkAsReadStrategy")]
	public class RemindingNotificationMarkAsReadStrategy : BaseNotificationMarkAsReadStrategy
	{
        #region Constants: Private

		private const string RemindingTableName = "Reminding";

        #endregion

        #region Fields: Private

		private readonly Guid _notificationTypeId;

        #endregion

        #region Constructors: Public

		public RemindingNotificationMarkAsReadStrategy(UserConnection userConnection, Guid notificationTypeId)
			: base(userConnection) {
			_notificationTypeId = notificationTypeId;
		}

        #endregion

        #region Methods: Protected Override

		protected override string GetSchemaNameForMarkAsRead() {
			return RemindingTableName;
		}

        #endregion

        #region Methods: Public Override

		/// <inheritdoc />
		public override IEnumerable<Guid> GetNotificationsToMark(DateTime remindTime, int chunkSize) {
			var notificationIdsQuery = new Select(UserConnection)
				.Top(chunkSize)
				.Column("Id")
				.From(RemindingTableName)
				.Where("ContactId").IsEqual(Column.Parameter(UserConnection.CurrentUser.ContactId))
				.And("NotificationTypeId").IsEqual(Column.Parameter(_notificationTypeId))
				.And("RemindTime").IsLessOrEqual(Column.Parameter(remindTime))
				.And(IsReadColumnName).IsEqual(Column.Parameter(false)) as Select;
			return notificationIdsQuery.ExecuteEnumerable(reader => reader.GetColumnValue<Guid>("Id")).ToList();
		}

        #endregion
	}
}

