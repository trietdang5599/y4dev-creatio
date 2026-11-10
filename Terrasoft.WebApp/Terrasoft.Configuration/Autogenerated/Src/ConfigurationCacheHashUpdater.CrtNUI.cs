namespace Terrasoft.Configuration
{
	using System;
	using Terrasoft.Core.ClientCache;
	using Terrasoft.Core.Factories;
	using static Terrasoft.Configuration.ConfigurationDataHashProvider.Constants;

	#region Interface: IConfigurationCacheHashUpdater

	public interface IConfigurationCacheHashUpdater
	{
		void UpdateCacheHash();
	}

	#endregion

	#region Class: ConfigurationCacheHashUpdater

	[DefaultBinding(typeof(IConfigurationCacheHashUpdater))]
	public class ConfigurationCacheHashUpdater : IConfigurationCacheHashUpdater
	{

		#region Methods: Public

		public void UpdateCacheHash() {
			IClientCacheStore clientCacheStore = ClassFactory.Get<IClientCacheStore>();
			clientCacheStore.SetHashValue(ConfigurationDataCacheHashKey, Guid.NewGuid().ToString("N"));
		}

		#endregion

	}

	#endregion

}

