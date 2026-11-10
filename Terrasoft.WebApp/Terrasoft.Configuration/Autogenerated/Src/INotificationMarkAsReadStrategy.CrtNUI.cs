namespace Terrasoft.Configuration.Notifications
{
	using System;
	using System.Collections.Generic;

    #region Interface: INotificationMarkAsReadStrategy

	/// <summary>
	/// Defines a strategy for marking notifications as read.
	/// </summary>
	public interface INotificationMarkAsReadStrategy {
		/// <summary>
		/// Retrieves a collection of notifications IDs that should be marked as read.
		/// </summary>
		/// <param name="remindTime">The date and time threshold for notifications to be considered.</param>
		/// <param name="chunkSize">The maximum number of notifications to retrieve in a single batch.</param>
		/// <returns>A collection of notifications IDs to mark as read.</returns>
		IEnumerable<Guid> GetNotificationsToMark(DateTime remindTime, int chunkSize);

		/// <summary>
		/// Marks the specified notifications as read.
		/// </summary>
		/// <param name="notificationIds">The collection of notification IDs to mark as read.</param>
		void MarkAsRead(IEnumerable<Guid> notificationIds);
	}

    #endregion
}
