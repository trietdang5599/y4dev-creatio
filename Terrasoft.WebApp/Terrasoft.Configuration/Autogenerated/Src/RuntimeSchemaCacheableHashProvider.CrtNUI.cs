namespace Terrasoft.Configuration
{
	using System.Collections.Generic;
	using Terrasoft.Core.ClientCache;
	using Terrasoft.Core.Factories;
	using static Terrasoft.Core.SystemSettings.ClientCache.Constants;
	using static Terrasoft.Core.FeatureToggling.ClientCache.Constants;
	using static Terrasoft.Core.Applications.ClientCache.Constants;
	using static ConfigurationDataHashProvider.Constants;

	#region Class: RuntimeSchemaCacheableHashProvider

	[DefaultBinding(typeof(ICacheHashProvider), Name = "RuntimeSchemaCacheableHashProvider")]
	public class RuntimeSchemaCacheableHashProvider : RedisCacheableHashProvider, IDependentCacheHashProvider
	{

		#region Constructors: Public

		public RuntimeSchemaCacheableHashProvider(IClientCacheStore clientCacheStore) : base(clientCacheStore) {
		}

		#endregion

		#region Properties: Protected

		protected override string CacheKey => "runtime-freedom-ui-schemas-cache-key";

		#endregion

		#region Properties: Public

		public IEnumerable<string> DependsOnCacheNames { get; } = new List<string> {
			SysSettingCacheHashName,
			FeaturesCacheHashName,
			AppInfoCacheName,
			ConfigurationDataCacheName
		};

		public override string CacheName => "runtime-freedom-ui-schemas-cache";

		#endregion
	}

	#endregion

}

