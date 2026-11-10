namespace Terrasoft.Configuration.Notifications
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.DB;

	/// <summary>
	/// Base implementation of notification mark-as-read strategy.
	/// </summary>
	public abstract class BaseNotificationMarkAsReadStrategy : INotificationMarkAsReadStrategy
	{
		#region Fields: Protected

		protected readonly UserConnection UserConnection;

		#endregion

		#region Constructors: Protected

		protected BaseNotificationMarkAsReadStrategy(UserConnection userConnection) {
			UserConnection = userConnection;
		}

		#endregion

		#region Properties: Protected

		protected virtual string IsReadColumnName {
			get {
				return "IsRead";
			}
		}

		#endregion

		#region Methods: Protected Abstract

		/// <summary>
		/// Gets the schema name for mark as read operations.
		/// </summary>
		/// <returns>The schema name for the notification table.</returns>
		protected abstract string GetSchemaNameForMarkAsRead();

		#endregion

		#region Methods: Public

		/// <summary>
		/// Retrieves a collection of notifications IDs that should be marked as read.
		/// </summary>
		public abstract IEnumerable<Guid> GetNotificationsToMark(DateTime remindTime, int chunkSize);

		/// <inheritdoc cref="INotificationMarkAsReadStrategy.MarkAsRead"/>
		public void MarkAsRead(IEnumerable<Guid> notificationIds) {
			notificationIds.CheckArgumentNull(nameof(notificationIds));
			var ids = notificationIds.ToArray();
			if (ids.Length == 0) {
				return;
			}
			string schemaName = GetSchemaNameForMarkAsRead();
			new Update(UserConnection, schemaName)
				.Set(IsReadColumnName, Column.Parameter(true))
				.Where("Id").In(Column.Parameters(ids))
				.Execute();
		}

		#endregion
	}
}
