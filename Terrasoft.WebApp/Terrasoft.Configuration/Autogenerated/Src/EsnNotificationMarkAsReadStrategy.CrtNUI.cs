namespace Terrasoft.Configuration.Notifications
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.Factories;

	[DefaultBinding(typeof(INotificationMarkAsReadStrategy), Name = "EsnNotificationMarkAsReadStrategy")]
	public class EsnNotificationMarkAsReadStrategy : BaseNotificationMarkAsReadStrategy
	{
        #region Constants: Private

		private const string EsnNotificationSchemaName = "ESNNotification";

        #endregion

        #region Constructors: Public

		public EsnNotificationMarkAsReadStrategy(UserConnection userConnection)
			: base(userConnection) {
		}

        #endregion

        #region Methods: Protected Override

		protected override string GetSchemaNameForMarkAsRead() {
			return EsnNotificationSchemaName;
		}

        #endregion

        #region Methods: Public Override

		/// <inheritdoc />
		public override IEnumerable<Guid> GetNotificationsToMark(DateTime remindTime, int chunkSize) {
			var notificationIdsQuery = new Select(UserConnection)
				.Top(chunkSize)
				.Column("Id")
				.From(EsnNotificationSchemaName)
				.Where("OwnerId").IsEqual(Column.Parameter(UserConnection.CurrentUser.ContactId))
				.And(IsReadColumnName).IsEqual(Column.Parameter(false)) as Select;
			return notificationIdsQuery.ExecuteEnumerable(reader => reader.GetColumnValue<Guid>("Id")).ToList();
		}

        #endregion
	}
}

