namespace OmnichannelMessaging
{
	using System;

	#region Interface: IAgentTypingNotifier

	/// <summary>
	/// Channel-agnostic seam for surfacing an "agent is typing" indicator to the
	/// chat visitor while a reply is being prepared by either a human operator or
	/// an AI assistant.
	///
	/// Implementations are resolved via <c>ClassFactory.Get</c> and are expected to
	/// translate the abstract chat identifier into whatever the underlying channel
	/// transport needs (for WebChat: deployment + conversation + a gateway call).
	/// The default binding (<see cref="AgentTypingNotifier"/>) is a no-op, so
	/// channels without a typing transport degrade silently and the callers
	/// (operator desktop endpoint, AI message interceptor) stay channel-agnostic.
	///
	/// Notifications are best-effort: an implementation must never throw back into
	/// the caller nor alter the message-delivery path.
	/// </summary>
	public interface IAgentTypingNotifier
	{

		/// <summary>
		/// Signals that the assigned agent has started or stopped typing in the
		/// given chat.
		///
		/// The transport routes the visitor's widget session by its gateway
		/// <c>visitorId</c> (the chat id is not the gateway conversation id), so the
		/// caller may supply <paramref name="channelId"/> and <paramref name="visitorId"/>
		/// directly. This is required on the very first AI turn, when the
		/// <c>OmniChat</c> row does not exist yet (<paramref name="chatId"/> is
		/// <see cref="System.Guid.Empty"/>) and the implementation therefore cannot
		/// resolve them from the chat. When they are not supplied (operator desktop /
		/// an already-persisted chat), the implementation resolves them from
		/// <paramref name="chatId"/>.
		/// </summary>
		/// <param name="chatId">
		/// Identifier of the active <c>OmniChat</c>; <see cref="System.Guid.Empty"/>
		/// before the chat exists (first AI turn).
		/// </param>
		/// <param name="channelId">
		/// Channel of the conversation; <see cref="System.Guid.Empty"/> to let the
		/// implementation resolve it from <paramref name="chatId"/>.
		/// </param>
		/// <param name="visitorId">
		/// Gateway visitor identity the typing signal targets; <c>null</c>/empty to let
		/// the implementation resolve it from <paramref name="chatId"/>.
		/// </param>
		/// <param name="isTyping">
		/// <c>true</c> when the agent started typing; <c>false</c> when typing
		/// stopped (reply sent, idle, or hand-off).
		/// </param>
		void NotifyTyping(Guid chatId, Guid channelId, string visitorId, bool isTyping);

	}

	#endregion
}

