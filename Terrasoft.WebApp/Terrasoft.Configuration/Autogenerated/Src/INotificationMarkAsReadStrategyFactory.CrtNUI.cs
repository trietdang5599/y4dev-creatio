namespace Terrasoft.Configuration.Notifications
{
	using System;

    #region Interface: INotificationMarkAsReadStrategyFactory

	/// <summary>
	/// Factory for creating notification mark-as-read strategy implementations.
	/// </summary>
	public interface INotificationMarkAsReadStrategyFactory
	{
		/// <summary>
		/// Gets the appropriate notification mark-as-read strategy for the specified notification type.
		/// </summary>
		/// <param name="notificationTypeId">The unique identifier of the notification type.</param>
		/// <returns>An implementation of <see cref="INotificationMarkAsReadStrategy"/> for the specified notification type.</returns>
		INotificationMarkAsReadStrategy GetStrategy(Guid notificationTypeId);
	}

    #endregion
}
