namespace Terrasoft.EmailDomain
{
	using System;
	using System.Collections.Concurrent;

	#region Class: PendingEmailDeduplicationStore

	internal static class PendingEmailDeduplicationStore
	{

		#region Fields: Private

		private static readonly ConcurrentDictionary<string, Guid> _pendingEmails =
			new ConcurrentDictionary<string, Guid>();

		#endregion

		#region Methods: Internal

		internal static string NormalizeMessageId(string messageId) {
			return string.IsNullOrEmpty(messageId)
				? string.Empty
				: messageId.ToUpperInvariant();
		}

		internal static bool TryGetActivityId(string messageId, out Guid activityId) {
			return _pendingEmails.TryGetValue(NormalizeMessageId(messageId), out activityId);
		}

		internal static void Set(string messageId, Guid activityId) {
			var normalizedMessageId = NormalizeMessageId(messageId);
			if (string.IsNullOrEmpty(normalizedMessageId) || activityId == Guid.Empty) {
				return;
			}
			_pendingEmails[normalizedMessageId] = activityId;
		}

		internal static void Remove(string messageId) {
			var normalizedMessageId = NormalizeMessageId(messageId);
			if (string.IsNullOrEmpty(normalizedMessageId)) {
				return;
			}
			_pendingEmails.TryRemove(normalizedMessageId, out _);
		}

		#endregion

	}

	#endregion

}
