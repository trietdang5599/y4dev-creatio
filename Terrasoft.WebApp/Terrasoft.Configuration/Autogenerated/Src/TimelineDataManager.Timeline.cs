namespace Terrasoft.Configuration.Timeline
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Nui.ServiceModel.Extensions;
	using DataValueType = Nui.ServiceModel.DataContract.DataValueType;

	#region Class: TimelineDataManager

	/// <summary>
	/// Timeline load manager.
	/// </summary>
	public class TimelineDataManager
	{
		#region Constants: Public 

		public int MaxSizeColumnValue = 1024 * 10;

		#endregion

		#region Properties: Protected

		private TimelineDataLoaderFactory<ITimelineDataLoader> _loaderFactory;
		protected TimelineDataLoaderFactory<ITimelineDataLoader> LoaderFactory => _loaderFactory ?? 
			(_loaderFactory = new TimelineDataLoaderFactory<ITimelineDataLoader>(UserConnection));

		private TimelineDataCacheRepository _cacheRepository;
		protected TimelineDataCacheRepository CacheRepository => _cacheRepository ??
			(_cacheRepository = new TimelineDataCacheRepository(UserConnection));

		protected UserConnection UserConnection;

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Initializes a new instance of the <see cref="TimelineDataManager"/> class.
		/// <param name="userConnection">Instance of the <see cref="UserConnection"/>.</param>
		/// </summary>
		public TimelineDataManager(UserConnection userConnection) {
			UserConnection = userConnection;
		}

		#endregion

		#region Methods: Private

		private IOrderedEnumerable<BoundTimelineEntity> GetOrderedBoundEntities(List<BoundTimelineEntity> response, TimelineRequestConfig config) {
			if (config.OrderDirection == OrderDirection.Ascending) {
				return response.OrderBy(r => r.SortColumn);
			}
			return response.OrderByDescending(r => r.SortColumn);
		}

		private TimelineDataResponse NewLoadingData(TimelineRequestConfig config){
			List<BoundTimelineEntity> boundTimelineEntities = new List<BoundTimelineEntity>();
			foreach (var boundEntity in config.BoundEntities) {
				ITimelineDataLoader loader = LoaderFactory.GetLoaderByName(boundEntity.EntitySchemaDataSource);
				boundTimelineEntities.AddRange(loader.LoadData(boundEntity, config));
			}
			CacheRepository.SetTimelineDataCache(config.MasterRecordId, config.OrderDirection, boundTimelineEntities);
			var orderedEntities = GetOrderedBoundEntities(boundTimelineEntities, config).Take(config.RowCount).ToList();
			return new TimelineDataResponse { Entities = orderedEntities };
		}

		private TimelineDataResponse LoadMoreData(TimelineRequestConfig config, List<BoundTimelineEntity> entitiesFromCache) {
			var globalOffset = config.Offset;
			var preorderedEntities = GetOrderedBoundEntities(entitiesFromCache, config).Take(config.RowCount + globalOffset).ToList();
			foreach (var boundEntity in config.BoundEntities) {
				var entitiesCount = preorderedEntities.Where(x => x.BoundEntityName.Equals(boundEntity.BoundEntityName)).Count();
				if (entitiesCount == globalOffset || IsLoadedLessPagesThenNeed(entitiesCount, config.RowCount, globalOffset)) {
					config.Offset = entitiesFromCache.Where(x => x.BoundEntityName.Equals(boundEntity.BoundEntityName)).Count();
					ITimelineDataLoader loader = LoaderFactory.GetLoaderByName(boundEntity.EntitySchemaDataSource);
					entitiesFromCache.AddRange(loader.LoadData(boundEntity, config));
				}
			}
			config.Offset = globalOffset;
			CacheRepository.SetTimelineDataCache(config.MasterRecordId, config.OrderDirection, entitiesFromCache);
			return GetTimeLineResponse(config, entitiesFromCache);
		}

		private bool IsLoadedLessPagesThenNeed(int loadedRecordCount, int recordInPage, int totalLoadedRecordCount) {
			int requiredRecordCount = totalLoadedRecordCount + recordInPage;
			return loadedRecordCount % recordInPage == 0 && loadedRecordCount < requiredRecordCount;
		}

		private TimelineDataResponse GetTimeLineResponse(TimelineRequestConfig config, List<BoundTimelineEntity> entities) {
			return new TimelineDataResponse {
				Entities = GetOrderedBoundEntities(entities, config).Skip(config.Offset).Take(config.RowCount).ToList()
			};
		}

		private TimelineDataResponse RemoveUnnecessaryColumns(TimelineDataResponse timelineDataResponse,  Predicate<BoundEntityColumn> predicate) {
			foreach (var entity in timelineDataResponse.Entities) {
				if(entity.ColumnValues != null && entity.ColumnValues.RemoveAll(predicate) > 0) {
					timelineDataResponse.HasPostponedColumns = true;
				}
			}
			return timelineDataResponse;
		}

		private bool IsLargeColumn(BoundEntityColumn column) {
			if (column.ColumnDataType != null && (column.ColumnDataType?.DataValueType == DataValueType.MaxSizeText ||
				column.ColumnDataType?.DataValueType == DataValueType.Text)) {
				var sizeValue = ASCIIEncoding.ASCII.GetByteCount(column.ColumnValue.Value);
				if (sizeValue >= MaxSizeColumnValue) {
					return true;
				}
			}
			return false;
		}

		private bool IsSmallColumn(BoundEntityColumn column) {
			return !IsLargeColumn(column);			
		}

		private TimelineDataResponse GetData(TimelineRequestConfig config) {
			return config.Offset > 0 && CacheRepository.TryGetTimelineDataFromCache(config.MasterRecordId, config.OrderDirection, out var entitiesFromCache) ?
				LoadMoreData(config, entitiesFromCache) : NewLoadingData(config);
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Loads Timeline data without large columns.
		/// </summary>
		/// <param name="config">Timeline load config.</param>
		public TimelineDataResponse GetDataWithoutLargeColumns(TimelineRequestConfig config) {
			return RemoveUnnecessaryColumns(GetData(config), IsLargeColumn);
		}


		/// <summary>
		/// Loads Timeline large columns data.
		/// </summary>
		/// <param name="config">Timeline load config.</param>
		public TimelineDataResponse GetLargeColumns(TimelineRequestConfig config) {
			var data = CacheRepository.TryGetTimelineDataFromCache(config.MasterRecordId, config.OrderDirection, out var entitiesFromCache) ?
				GetTimeLineResponse(config, entitiesFromCache) : GetData(config);
			return RemoveUnnecessaryColumns(data, IsSmallColumn);
		}

		/// <summary>
		/// Loads Timeline single record data.
		/// </summary>
		/// <param name="config">Timeline load config.</param>
		public TimelineDataResponse GetSingleEntityData(TimelineRequestConfig config) {
			List<BoundTimelineEntity> boundTimelineEntities = new List<BoundTimelineEntity>();
			foreach (var boundEntity in config.BoundEntities) {
				ITimelineDataLoader loader = LoaderFactory.GetLoaderByName(boundEntity.EntitySchemaDataSource);
				boundTimelineEntities.AddRange(loader.LoadData(boundEntity, config));
				if (boundTimelineEntities.Count > 0) {
					break;
				}
			}
			return new TimelineDataResponse { Entities = boundTimelineEntities };
		}

		#endregion

	}

	#endregion
} 
