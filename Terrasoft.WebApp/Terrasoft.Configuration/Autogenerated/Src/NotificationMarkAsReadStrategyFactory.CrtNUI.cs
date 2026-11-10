namespace Terrasoft.Configuration.Notifications
{
    using System;
    using Terrasoft.Common;
    using Terrasoft.Core;
    using Terrasoft.Core.Factories;

    #region Class: NotificationMarkAsReadStrategyFactory

    [DefaultBinding(typeof(INotificationMarkAsReadStrategyFactory))]
    public class NotificationMarkAsReadStrategyFactory : INotificationMarkAsReadStrategyFactory
    {
        #region Fields: Private

        private readonly UserConnection _userConnection;

        #endregion

        #region Constructors: Public

        public NotificationMarkAsReadStrategyFactory(UserConnection userConnection) {
            _userConnection = userConnection;
        }

        #endregion

        #region Methods: Public

        /// <inheritdoc cref="INotificationMarkAsReadStrategyFactory.GetStrategy"/>
        public INotificationMarkAsReadStrategy GetStrategy(Guid notificationTypeId) {
            notificationTypeId.CheckArgumentEmpty(nameof(notificationTypeId));
            if (notificationTypeId == RemindingConsts.NotificationTypeEsnSocialMessageSchemaUId) {
                return ClassFactory.Get<EsnNotificationMarkAsReadStrategy>(new ConstructorArgument("userConnection", _userConnection));
            }
            return ClassFactory.Get<RemindingNotificationMarkAsReadStrategy>(
                new ConstructorArgument("userConnection", _userConnection),
                new ConstructorArgument("notificationTypeId", notificationTypeId));
        }

        #endregion
    }

    #endregion
}


