namespace OmnichannelMessaging
{
	using Terrasoft.Configuration.Omnichannel.Messaging;

	#region Interface: IOutboundMessageInterceptor

	/// <summary>
	/// Optional outbound-side counterpart to <see cref="IMessageInterceptor"/>.
	/// Implementations are resolved via <c>ClassFactory.Get</c> and given a
	/// chance to handle an outbound message before it reaches the native
	/// per-provider transport (Telegram Bot API, WebChat gateway, …).
	///
	/// Returning <c>true</c> from <see cref="TryIntercept"/> suppresses the
	/// native channel send while leaving the persisted OmniChat /
	/// <c>OmnichannelMessages</c> rows intact, so the conversation history
	/// still records the reply and downstream operator-side notifications
	/// (e.g. Agent Inbox bubble) continue to fire.
	///
	/// Typical use case: a channel-settings preview that hosts a synthetic
	/// "visitor" inside Creatio — outbound replies should reach the admin
	/// via a Creatio WebSocket topic instead of the real provider API.
	/// </summary>
	public interface IOutboundMessageInterceptor
	{

		/// <summary>
		/// Attempts to handle the outbound <paramref name="message"/>.
		/// </summary>
		/// <param name="message">
		/// The outbound message about to be sent through the per-provider
		/// transport. The <c>ChatId</c>, <c>Status</c> and metadata are
		/// already populated by <c>OmnichannelMessagingService.InternalSend</c>.
		/// </param>
		/// <returns>
		/// <c>true</c> when the implementation has fully handled the
		/// message and the canonical transport should be skipped;
		/// <c>false</c> when the message should proceed to the native
		/// provider send as usual.
		/// </returns>
		bool TryIntercept(MessagingMessage message);

	}

	#endregion
}

