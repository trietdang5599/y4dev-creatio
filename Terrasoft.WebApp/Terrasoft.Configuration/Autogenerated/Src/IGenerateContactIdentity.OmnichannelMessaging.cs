namespace Terrasoft.Configuration.Omnichannel.Messaging
{
	using System;
	/// <summary>
	/// Interface for generating contact identity.
	/// </summary>
	public interface IGenerateContactIdentity
	{
		bool TryGetOrCreateIdentity(Guid channelId, Guid contactId, out string channelIdentity);
	}
}
