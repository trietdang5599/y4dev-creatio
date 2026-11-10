namespace Terrasoft.Configuration.Omnichannel.Messaging
{
	using System;
	using System.Collections.Generic;
	using Terrasoft.Common;
	using Terrasoft.Core;

	#region Class : AsyncAcceptChatNotifier

	/// <summary>
	/// Represents an asynchronous chat notifier.
	/// </summary>
	public class AsyncAcceptChatNotifierExecutor : IJobExecutor
	{

		#region Methods : Public

		/// <summary>
		/// Notifies operators about chats count asynchronously.
		/// </summary>
		/// <param name="userConnection">User connection.</param>
		/// <param name="parameters">Parameters.</param>
		public virtual void Execute(UserConnection userConnection, IDictionary<string, object> parameters) {
			if (parameters == null) {
				throw new ArgumentNullOrEmptyException("parameters can't be null");
			}
			List<Guid> operators = parameters.GetValue("operators", new List<Guid>());
			var notifier = new ChatOperatorNotifier(userConnection);
			notifier.UnreadChatsCountNotify(operators);
		}

		#endregion

	}

	#endregion

}
