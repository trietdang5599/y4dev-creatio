namespace Terrasoft.Configuration
{
    using Terrasoft.Core.ClientCache;
    using Terrasoft.Core.Factories;

	#region Class: AccessControlWhitelistCacheHashProvider

    [DefaultBinding(typeof(ICacheHashProvider), Name = nameof(AccessControlWhitelistCacheHashProvider))]
    public class AccessControlWhitelistCacheHashProvider : RedisCacheableHashProvider
    {

		#region Constructors: Public

        public AccessControlWhitelistCacheHashProvider(IClientCacheStore clientCacheStore)
            : base(clientCacheStore) {
		}

		#endregion

		#region Properties: Protected

        protected override string CacheKey => AccessControlWhitelistConstants.WhiteListCacheHashKey;

		#endregion

		#region Properties: Public

        public override string CacheName => AccessControlWhitelistConstants.WhiteListCacheName;

		#endregion

	}

	#endregion

}

