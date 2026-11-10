namespace Terrasoft.Configuration.Timeline
{
	using Newtonsoft.Json;
	using System.Collections.Generic;
	using Terrasoft.Common;
	using Terrasoft.Core;

	#region Class: TimelineDataCacheRepository

	/// <summary>
	/// Timeline data cache repository.
	/// </summary>
	public class TimelineDataCacheRepository
	{

		#region Constants: Private

		private const string TimelineCacheKeyPrefix = "TimelineData_";

		#endregion

		#region Properties: Protected

		protected UserConnection UserConnection;

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Initializes a new instance of the <see cref="TimelineDataCacheRepository"/> class.
		/// <param name="userConnection">Instance of the <see cref="UserConnection"/>.</param>
		/// </summary>
		public TimelineDataCacheRepository(UserConnection userConnection) {
			UserConnection = userConnection;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Get cache key for timeline data.
		/// </summary>
		/// <param name="masterRecordId">Timeline record identifier.</param>
		/// <param name="orderDirection">Order direction.</param>
		public static string GetCacheKey(string masterRecordId, OrderDirection orderDirection) {
			return $"{TimelineCacheKeyPrefix}_{masterRecordId}_{orderDirection}";
		}

		/// <summary>
		/// Get BoundTimelineEntity`s from cache.
		/// </summary>
		/// <param name="masterRecordId">Identifier of cached record.</param>
		/// <param name="orderDirection">Order direction.</param>
		/// <param name="resultEntities">Timeline data from cache.</param>
		public bool TryGetTimelineDataFromCache(string masterRecordId, OrderDirection orderDirection, out List<BoundTimelineEntity> resultEntities) {
			var cacheValue = UserConnection.SessionCache[GetCacheKey(masterRecordId, orderDirection)] as string;
			resultEntities = cacheValue != null ? JsonConvert.DeserializeObject<List<BoundTimelineEntity>>(cacheValue) : null;
			return resultEntities != null;
		}

		/// <summary>
		/// Set BoundTimelineEntity`s to cache.
		/// </summary>
		/// <param name="masterRecordId">Identifier of cached record.</param>
		/// <param name="orderDirection">Order direction.</param>
		/// <param name="entities">Timeline data.</param>
		public void SetTimelineDataCache(string masterRecordId, OrderDirection orderDirection, List<BoundTimelineEntity> entities) {
			UserConnection.SessionCache[GetCacheKey(masterRecordId, orderDirection)] = JsonConvert.SerializeObject(entities);
		}

		/// <summary>
		/// Remove BoundTimelineEntity`s from cache.
		/// </summary>
		/// <param name="masterRecordId">Identifier of cached record.</param>
		/// <param name="orderDirection">Order direction.</param>
		public void RemoveTimelineDataCache(string masterRecordId, OrderDirection orderDirection) {
			UserConnection.SessionCache.Remove(GetCacheKey(masterRecordId, orderDirection));
		}

		#endregion

	}

	#endregion
}
