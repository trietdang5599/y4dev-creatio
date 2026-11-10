namespace IntegrationV2.MailboxDomain.Interfaces
{
	using System;
	using System.Collections.Generic;
	using IntegrationApi.MailboxDomain.Model;

	#region Interface: IMailboxRepository

	/// <summary>
	/// Mailbox storage repository interface.
	/// </summary>
	internal interface IMailboxRepository
	{

		#region Methods: Internal

		/// <summary>
		/// Returns all mailboxes list.
		/// </summary>
		/// <param name="isUserMailboxesOnly">Select current user mailboxes only or all mailboxes flag.</param>
		/// <param name="useForSynchronization">Sign is synchronization mode or not.</param>
		/// <returns><see cref="Mailbox"/> collection.</returns>
		IEnumerable<Mailbox> GetAll(bool isUserMailboxesOnly = true, bool useForSynchronization = true);

		/// <summary>
		/// Returns concrete mailbox.
		/// </summary>
		/// <param name="mailboxId">Mailbox Id.</param>
		/// <param name="isUserMailboxesOnly">Select current user mailboxes only flag.<</param>
		/// <returns><see cref="Mailbox"/> instance.</returns>
		Mailbox GetById(Guid mailboxId, bool isUserMailboxesOnly = true);

		/// <summary>
		/// Returns a mailbox by sender email address. When the mailbox cache feature is enabled,
		/// the lookup first inspects the cached mailbox list and falls back to a targeted database
		/// query if the mailbox is not present. A database hit after a cache miss invalidates the
		/// shared cache so subsequent reads pick up the up-to-date data. When the feature is
		/// disabled, the call always queries the database.
		/// </summary>
		/// <param name="senderEmailAddress">Mailbox sender email address.</param>
		/// <param name="isUserMailboxesOnly">Select current user mailboxes only flag.</param>
		/// <param name="useForSynchronization">Sign is synchronization mode or not.</param>
		/// <returns><see cref="Mailbox"/> instance or <c>null</c> when no matching record exists.</returns>
		Mailbox GetBySenderEmailAddress(string senderEmailAddress, bool isUserMailboxesOnly = true,
			bool useForSynchronization = true);

		/// <summary>
		/// Returns mailbox email address collection.
		/// </summary>
		/// <param name="mailboxId"><see cref="MailboxSyncSettings"/> instance identifier.</param>
		/// <returns>Mailbox email address collection.</returns>
		IEnumerable<string> GetEmails(Guid mailboxId);

		#endregion

	}

	#endregion

}
