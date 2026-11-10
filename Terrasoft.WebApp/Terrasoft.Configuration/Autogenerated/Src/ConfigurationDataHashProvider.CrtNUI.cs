namespace Terrasoft.Configuration
{
	using global::Common.Logging;
	using Terrasoft.Configuration.CachingSupport;
	using System.Linq;
	using System.Threading;
	using Terrasoft.Core;
	using Terrasoft.Core.ClientCache;
	using Terrasoft.Core.Factories;
	using System;

	#region Class: ConfigurationDataHashProvider

	[DefaultBinding(typeof(ICacheHashProvider), Name = "ConfigurationDataHashProvider")]
	public class ConfigurationDataHashProvider : UserScopedCacheableHashProvider
	{

		#region Class: Constants

		public static class Constants
		{

			#region Constants: Public

			public const string ConfigurationDataCacheHashKey = "configuration-data-cache-key";

			public const string ConfigurationDataCacheName = "configuration-data-cache";

			#endregion

		}

		#endregion

		#region Fields: Private

		private readonly ILog _log = LogManager.GetLogger("ConfigurationDataHashProvider");
		private readonly IClientCacheStore _clientCacheStore;

		#endregion

		#region Properties: Private

		private bool HasNonCachedBuilderImplementations {
			get {
				var nonCachingBuilders = ClassFactory.GetAll<ISectionStructureBuilder>()
					.Where(builder => !(builder is ICachingSupport))
					.ToList();
				if (nonCachingBuilders.Any()) {
					var typeNames = string.Join(", ", nonCachingBuilders
						.Select(b => b.GetType().FullName));
					_log.Warn("The following ISectionStructureBuilder implementations do not support ICachingSupport:"
					+ $"{typeNames}. The application may work slower.");
					return true;
				}
				return false;
			}
		}

		#endregion

		#region Properties: Public

		public override string CacheName => Constants.ConfigurationDataCacheName;

		#endregion

		#region Constructors: Public

		public ConfigurationDataHashProvider(UserConnection userConnection, IClientCacheStore clientCacheStore)
			: base(userConnection, clientCacheStore) {
			_clientCacheStore = clientCacheStore;
		}

		#endregion

		#region Properties: Protected

		protected override string CacheKey => Constants.ConfigurationDataCacheHashKey;

		#endregion

		#region Methods: Public

		public override ClientHash Generate(CancellationToken cancellationToken = default) {
			if (HasNonCachedBuilderImplementations) {
				_clientCacheStore.SetHashValue(CacheKey, Guid.NewGuid().ToString("N"));
			}
			return base.Generate(cancellationToken);
		}

		#endregion

	}

	#endregion

}
