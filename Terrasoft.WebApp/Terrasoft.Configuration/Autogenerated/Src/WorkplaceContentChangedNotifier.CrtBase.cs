  namespace Terrasoft.Configuration
{
	using System;
	using Core.Factories;
	using Terrasoft.Common;
	using Terrasoft.Messaging.Common;

	/// <summary>
	/// Implements <see cref="IWorkplaceContentChangedNotifier"/>.
	/// </summary>
	[DefaultBinding(typeof(IWorkplaceContentChangedNotifier), Name = "WorkplaceContentChangedNotifier")]
	public class WorkplaceContentChangedNotifier : IWorkplaceContentChangedNotifier
	{

		#region Fields: Private

		private readonly IServerClientOperationNotifier _serverClientOperationNotifier;
		
		#endregion

		#region Constructor: Public

		public WorkplaceContentChangedNotifier() {
			_serverClientOperationNotifier = ClassFactory.Get<IServerClientOperationNotifier>();
		}

		public WorkplaceContentChangedNotifier(IServerClientOperationNotifier serverClientOperationNotifier) {
			_serverClientOperationNotifier = serverClientOperationNotifier;
		}
		
		#endregion

		#region Methods: Public

		/// <inheritdoc />
		public void Notify(Guid[] userIds) {
			userIds.CheckArgumentNullOrEmpty(nameof(userIds));
			var message = new ServerClientNotificationData {
				OperationType = "WorkplaceContentChanged",
				UserIds = userIds
			};
			_serverClientOperationNotifier.Notify(message);
		}
		
		#endregion
	}
}

