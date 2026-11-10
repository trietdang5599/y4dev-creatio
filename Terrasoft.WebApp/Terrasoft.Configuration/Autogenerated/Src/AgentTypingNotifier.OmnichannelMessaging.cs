namespace OmnichannelMessaging
{
	using System;
	using Terrasoft.Core;
	using Terrasoft.Core.Factories;

	#region Class: AgentTypingNotifier

	/// <summary>
	/// Default no-op binding for <see cref="IAgentTypingNotifier"/>. Guarantees that
	/// <c>ClassFactory.Get&lt;IAgentTypingNotifier&gt;</c> always resolves, so the
	/// channel-agnostic callers never have to null-check or special-case channels
	/// that have no typing transport. Channels that support a typing indicator
	/// (e.g. WebChat) rebind the seam to their own implementation.
	/// </summary>
	[DefaultBinding(typeof(IAgentTypingNotifier))]
	public class AgentTypingNotifier : IAgentTypingNotifier
	{

		#region Constructors: Public

		/// <summary>
		/// Initializes a new instance of the <see cref="AgentTypingNotifier"/> class.
		/// </summary>
		/// <param name="userConnection">
		/// User connection supplied by <c>ClassFactory</c>. Unused by the no-op
		/// default; accepted so the resolve contract matches channel-specific
		/// implementations that need it.
		/// </param>
		public AgentTypingNotifier(UserConnection userConnection) {
		}

		#endregion

		#region Methods: Public

		/// <inheritdoc cref="OmnichannelMessaging.IAgentTypingNotifier" />
		public void NotifyTyping(Guid chatId, Guid channelId, string visitorId, bool isTyping) {
			// No-op: the base channel has no typing transport. Channel-specific
			// packages rebind IAgentTypingNotifier to emit the signal.
		}

		#endregion

	}

	#endregion
}

