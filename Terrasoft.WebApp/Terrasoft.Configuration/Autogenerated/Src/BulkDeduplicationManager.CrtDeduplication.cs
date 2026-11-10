namespace Terrasoft.Configuration.Deduplication
{
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Linq;
	using System.Net;
	using DeduplicationElastic.Domain.Deduplication.Task;
	using DeduplicationElastic.WebApi.Contracts.Requests;
	using DeduplicationElastic.WebApi.Contracts.Response;
	using Newtonsoft.Json;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Factories;
	using Terrasoft.Core.Requests;
	using Terrasoft.Nui.ServiceModel.DataContract;
	using Terrasoft.Nui.ServiceModel.Extensions;
	using Terrasoft.Web.Http.Abstractions;
	using EntityCollection = Terrasoft.Nui.ServiceModel.DataContract.EntityCollection;

	#region Class: BulkDeduplicationManager

	/// <summary>
	/// Bulk deduplication manager.
	/// </summary>
	[DefaultBinding(typeof(IBulkDeduplicationManager))]
	[DefaultBinding(typeof(IBulkDeduplicationManagerV2))]
	[DefaultBinding(typeof(IBulkDeduplicationGroupManager))]
	public class BulkDeduplicationManager : BaseDeduplicationManager, IBulkDeduplicationManagerV2, IBulkDeduplicationGroupManager
	{

		#region Fields: Private

		private readonly IStartDeduplicationRequestFactory _startDeduplicationRequestFactory;
		private readonly IBulkDeduplicationTaskClient _bulkDeduplicationTaskClient;
		private readonly IAppSchedulerWraper _appSchedulerWraper;
		private const string IsUniqueAttributeName = "IsUnique";
		private const string IsSourceEntityAttributeName = "IsSourceEntity";
		private const int MaxFetchPages = 100;

		#endregion

		#region Properties: Private

		private int GetGroupsOfDuplicatesRequestTimeoutSec => 
			SysSettings.GetValue(UserConnection, "DeduplicationGetGroupsOfDuplicatesTimeoutSec", 100);

		#endregion

		#region Properties: Protected

		protected virtual int CheckDeduplicationTaskStatusInterval => 1;

		#endregion

		#region Contructors: Public

		public BulkDeduplicationManager(UserConnection userConnection,
				IAppSchedulerWraper appSchedulerWraper) : base(userConnection) {
			if (string.IsNullOrEmpty(DeduplicationWebApiUrl)) {
				Log.Error("DeduplicationWebApiUrl is empty.");
			}
			var userConnectionConstructorArgument = new ConstructorArgument("userConnection", userConnection);
			_startDeduplicationRequestFactory = ClassFactory.Get<IStartDeduplicationRequestFactory>(
				userConnectionConstructorArgument);
			_bulkDeduplicationTaskClient = ClassFactory.Get<IBulkDeduplicationTaskClient>(
				userConnectionConstructorArgument);
			_appSchedulerWraper = appSchedulerWraper;
		}

		#endregion

		#region Methods: Private
		
		private EntitySchemaQuery GetDuplicateEntitiesEsq(string entityName) {
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, entityName) {
				PrimaryQueryColumn = {
					IsAlwaysSelect = true
				},
				UseAdminRights = true
			};
			return esq;
		}

		private Dictionary<string, string> GetServerToClientColumnNameMap(string[] columns, EntitySchemaQuery esq) {
			var serverToClientColumnNameMap = new Dictionary<string, string>();
			var primaryColumnName = esq.PrimaryQueryColumn.Name;
			foreach (var column in columns) {
				serverToClientColumnNameMap[esq.AddColumn(column).Name] = column;
			}
			if (!serverToClientColumnNameMap.Any(x => x.Key == primaryColumnName || x.Value == primaryColumnName)) {
				serverToClientColumnNameMap[esq.PrimaryQueryColumn.Name] = esq.PrimaryQueryColumn.Name;
			}
			serverToClientColumnNameMap.Add(IsUniqueAttributeName, IsUniqueAttributeName);
			return serverToClientColumnNameMap;
		}

		private Guid GetRowRecordId(Dictionary<string, object> row, EntitySchemaQuery esq) {
			var primaryColumnName = esq.PrimaryQueryColumn.Name;
			var primaryColumnStringValue = row[primaryColumnName].ToString();
			return Guid.Parse(primaryColumnStringValue);
		}

		private EntityCollection GetDuplicateEntities(EntitySchemaQuery esq, 
			Dictionary<string, string> serverToClientColumnNameMap, 
			IList<DuplicateInfo> entities,
			IEntitySchemaQueryFilterItem esqFilter = null) {
			if (entities.Count == 0) {
				return new EntityCollection();
			}
			var duplicateRecordIds = entities.Select(entity => entity.RecordId);
			var duplicatesCollection = GetDuplicatesEntityCollection(esq, 
				serverToClientColumnNameMap, 
				duplicateRecordIds, 
				esqFilter);
			foreach (var item in duplicatesCollection) {
				var firstDuplicateInfo = entities.First(x => x.RecordId == GetRowRecordId(item, esq));
				var isSourceEntity = firstDuplicateInfo.SourceRecordId == firstDuplicateInfo.RecordId;
				if (isSourceEntity) {
					item.Add(IsSourceEntityAttributeName, true);
				}
				item.Add(IsUniqueAttributeName, firstDuplicateInfo.IsUnique);
			}
			return duplicatesCollection;
		}

		private EntityCollection GetDuplicatesEntityCollection(EntitySchemaQuery esq,
			Dictionary<string, string> serverToClientColumnNameMap, IEnumerable<Guid> entityIds, 
			IEntitySchemaQueryFilterItem esqFilter = null) {
			esq.ResetSelectQuery();
			esq.Filters.Clear();
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, esq.PrimaryQueryColumn.Path,
				entityIds.Select(id => id.ToString()).Distinct()));
			if (esqFilter != null) {
				esq.Filters.Add(esqFilter);
			}
			return QueryExtension.GetEntityCollection(esq.GetEntityCollection(UserConnection), serverToClientColumnNameMap);
		}

		private static void AddIsUniqueColumn(EntitySchemaQuery esq) {
			esq.Columns.Add(new EntitySchemaQueryColumn {
				ValueExpression = new EntitySchemaQueryExpression(EntitySchemaQueryExpressionType.Parameter) {
					ParameterValue = default(bool)
				},
				Name = IsUniqueAttributeName,
				UId = Guid.NewGuid()
			});
		}

		private void ScheduleDeduplicationTaskStatusCheckingJob(string sectionName) {
			var checkDeduplicationTaskParameters = new Dictionary<string, object> {
				{CheckDeduplicationTaskStatusJobExecutor.EntityNameParamName, sectionName},
				{CheckDeduplicationTaskStatusJobExecutor.IndexNameParamName, IndexName}
			};
			var checkDeduplicationStatusJobGroupName =
				CheckDeduplicationTaskStatusJobExecutor.GetCheckDeduplicationStatusJobGroupName(sectionName);
			_appSchedulerWraper.RemoveGroupJobs(checkDeduplicationStatusJobGroupName);
			_appSchedulerWraper.ScheduleMinutelyJob<CheckDeduplicationTaskStatusJobExecutor>(
				checkDeduplicationStatusJobGroupName,
				UserConnection.Workspace.Name, UserConnection.CurrentUser.Name,
				CheckDeduplicationTaskStatusInterval, checkDeduplicationTaskParameters, false);
		}

		private IList<IGrouping<Guid, DuplicateInfo>> FetchDuplicatesFromService(string entityName, int offset, int count) {
			var duplicatesResponse = ExecuteFetchRequest<DuplicateResponse>(DuplicationControllerPath, new Dictionary<string, object> {
				{ "sourceEntityName", entityName },
				{ "elasticIndexName", IndexName },
				{ "offset", offset },
				{ "count", count },
			});
			return duplicatesResponse.Duplicates?.GroupBy(x => x.GroupId).ToList();
		}

		private List<DuplicateGroupInfo> FetchGroupOfDuplicatesFromService(string entityName, int offset, int count, int topDuplicatesPerGroup) {
			return ExecuteFetchRequest<List<DuplicateGroupInfo>>(DuplicationGroupControllerPath, new Dictionary<string, object> {
				{ "sourceEntityName", entityName },
				{ "elasticIndexName", IndexName },
				{ "offset", offset },
				{ "count", count },
				{ "topDuplicatesCountPerGroup", topDuplicatesPerGroup },
			});
		}

		private DuplicateCountInfo FetchDuplicatesCountFromService(string entityName, bool needGetDuplicatesCount = true) {
			return ExecuteFetchRequest<DuplicateCountInfo>(DuplicatesCountControllerPath, new Dictionary<string, object> {
				{ "sourceEntityName", entityName },
				{ "elasticIndexName", IndexName },
				{ "needGetDuplicatesCount", needGetDuplicatesCount }
			});
		}

		private List<DuplicateInfo> FetchDuplicatesByGroupFromService(Guid groupId, int offset, int count) {
			return ExecuteFetchRequest<List<DuplicateInfo>>($"{DuplicationControllerPath}/{groupId}", new Dictionary<string, object> {
				{ "offset", offset },
				{ "count", count }
			});
		}

		private T ExecuteFetchRequest<T>(string resourcePath, IDictionary<string, object> requestQueryParams)
			 where T : new() {
			var request = new HttpRequestConfig(new Uri(BaseUrl), resourcePath, HttpRequestMethod.GET);
			foreach (var queryParam in requestQueryParams) {
				request.AddQueryParam(queryParam.Key, queryParam.Value.ToString());
			}
			var response = HttpClient.Send(request);
			if (!response.IsSuccessStatusCode) {
				Log.Error($"Fetch for {nameof(T)} failed. Path: {resourcePath}. StatusCode: {response.StatusCode}. " +
					$"QueryParams: {string.Join(", ", requestQueryParams.Keys)}({string.Join(", ", requestQueryParams.Values)})");
				return new T();
			}
			var duplicatesResponse = response.GetResult<T>();
			if (duplicatesResponse == null) {
				Log.Error($"Content for {nameof(T)} is invalid. Path: {resourcePath}. {response.Content}." +
					$"QueryParams: {string.Join(", ", requestQueryParams.Keys)}({string.Join(", ", requestQueryParams.Values)})");
				return new T();
			}
			return duplicatesResponse;
		}

		private BulkEntityClientDuplicatesGroup GetDuplicatesGroupResponse(DuplicateGroupInfo duplicateGroup, EntitySchemaQuery esq,
			Dictionary<string, string> serverToClientColumnNameMap, IEntitySchemaQueryFilterItem esqFilter = null) {
			var minDuplicatesCountPerGroup = 2;
			var isEmptyDuplicatesInGroup = duplicateGroup.Duplicates.Count == 0;
			if (isEmptyDuplicatesInGroup) {
				Log.Info($"Empty duplicate group {duplicateGroup.Id} from service. Source entity: {duplicateGroup.SourceRecordId}.");
				return null;
			}
			var sourceEntity = GetDuplicatesEntityCollection(esq, serverToClientColumnNameMap, new List<Guid> {
						duplicateGroup.SourceRecordId
					}).FirstOrDefault();
			if (sourceEntity == null) {
				Log.Info($"Source entity by group {duplicateGroup.Id} not found. Source entity: {duplicateGroup.SourceRecordId}.");
				return null;
			}
			var duplicateEntities = GetDuplicateEntities(esq, serverToClientColumnNameMap, duplicateGroup.Duplicates, esqFilter);
			bool hasFilters = AreFiltersDefined(esqFilter);
			var isNotFilledDuplicatesGroup = duplicateEntities.Count < minDuplicatesCountPerGroup && !hasFilters;
			if (isNotFilledDuplicatesGroup) {
				Log.Info($"Creation duplicates collection by group {duplicateGroup.Id} not filled. Source entity: {duplicateGroup.SourceRecordId}.");
				return null;
			}
			return new BulkEntityClientDuplicatesGroup {
				DuplicatesCount = duplicateGroup.DuplicatesCount,
				GroupId = duplicateGroup.Id,
				SourceEntityId = duplicateGroup.SourceRecordId,
				Rows = duplicateEntities,
				SourceEntity = sourceEntity
			};
		}

		private bool AreFiltersDefined(IEntitySchemaQueryFilterItem esqFilter) {
			return esqFilter?.GetFilterInstances().Any() == true;
		}

		private IEntitySchemaQueryFilterItem GetESQFilter(EntitySchemaQuery esq, string filtersStr) {
			Filters filters = !filtersStr.IsNullOrEmpty()
				? JsonConvert.DeserializeObject<Filters>(filtersStr)
				: null;
			IEntitySchemaQueryFilterItem esqFilter = null;
			if (filters != null) {
				esqFilter = filters.BuildEsqFilter(esq.RootSchema.Name, UserConnection);
			}
			return esqFilter;
		}

		private Guid[] GetUniqueRecordIds(string entityName, IHttpResponse response) {
			if (response.StatusCode != HttpStatusCode.OK) {
				Log.ErrorFormat("Cannot get unique records for object {0} and index {1}. The message is {2}", entityName,
					IndexName, response.Content);
			}
			Guid[] uniqueDuplicatesIds = { };
			if (response.Content.IsNotNullOrEmpty()) {
				uniqueDuplicatesIds = JsonConvert.DeserializeObject<Guid[]>(response.Content);
			}
			return uniqueDuplicatesIds;
		}

		private HttpRequestConfig CreateGetUniqueRecordsRequest(string entityName, IEnumerable<Guid> duplicatesIds) {
			var getUniqueRecordsFromDuplicatesRequest = new GetOnlyUniqueDuplicatesRequest {
				IndexName = IndexName,
				SourceEntityName = entityName,
				DuplicatesIds = new Collection<Guid>(duplicatesIds.ToList())
			};
			var request = new HttpRequestConfig(new Uri(BaseUrl), GetUniqueRecordsControllerPath) {
				Body = getUniqueRecordsFromDuplicatesRequest
			};
			return request;
		}
		
		private void DecorateFilteredGroup(GetGroupsOfDuplicatesParams parameters, string entityName,
				BulkEntityClientDuplicatesGroup duplicateGroupResponse) {
			var filteredGroupRows = GetDuplicateEntitiesByGroup(new GetDuplicateEntitiesByGroupParams {
				EntityName = entityName,
				Count = 0,
				Offset = 0,
				Columns = parameters.Columns,
				Filters = parameters.Filters,
				GroupId = duplicateGroupResponse.GroupId
			});
			duplicateGroupResponse.DuplicatesCount = filteredGroupRows.Rows.Count;
			if (duplicateGroupResponse.Rows.Count < parameters.TopDuplicatesPerGroup) {
				var collection = new EntityCollection();
				collection.AddRange(filteredGroupRows.Rows.Take(parameters.TopDuplicatesPerGroup));
				duplicateGroupResponse.Rows = collection;
			}
		}

		#endregion

		#region Methods: Public

		/// <inheritdoc cref="IBulkDeduplicationManager.GetDeduplicationInfo"/>
		public BulkDeduplicationInfo GetDeduplicationInfo(string entityName) {
			try {
				var actualDeduplicationTask =
					_bulkDeduplicationTaskClient.GetActualDeduplicationTask(entityName, IndexName);
				if (actualDeduplicationTask == null || actualDeduplicationTask.TaskStatus == null) {
					return new BulkDeduplicationInfo {
						IsFirstRun = true,
						IsRunning = false
					};
				}
				var deduplicationTaskStatus = actualDeduplicationTask.TaskStatus;
				var maxDuplicatesPerRecord = actualDeduplicationTask.MaxDuplicatesPerRecord != null
						&& actualDeduplicationTask.MaxDuplicatesPerRecord.HasValue
						? actualDeduplicationTask.MaxDuplicatesPerRecord.Value
						: -1;
				var processedPercentValue = actualDeduplicationTask.TotalRecordsCount > 0 
					? (double)actualDeduplicationTask.ProcessedRecordsCount / actualDeduplicationTask.TotalRecordsCount * 100
					: 0;
				var isNowRunning = deduplicationTaskStatus == DeduplicationTaskStatus.Pending ||
						deduplicationTaskStatus == DeduplicationTaskStatus.Running;
				var isSuccessRunning = deduplicationTaskStatus != DeduplicationTaskStatus.Canceled
						&& deduplicationTaskStatus != DeduplicationTaskStatus.Failed;
				return new BulkDeduplicationInfo {
					IsFirstRun = false,
					IsRunning = isNowRunning,
					IsSuccess = isSuccessRunning,
					MaxDuplicatesPerRecord = maxDuplicatesPerRecord,
					ProcessedPercent = Convert.ToInt32(processedPercentValue),
					IsCanceled = deduplicationTaskStatus == DeduplicationTaskStatus.Canceled
				};
			}
			catch (HttpException) {
				return null;
			}
		}

		/// <inheritdoc cref="IBulkDeduplicationManager.GetGroupsOfDuplicates"/>
		[Obsolete("Use GetGroupsOfDuplicates with GetGroupsOfDuplicatesParams parameter instead.")]
		public BulkDuplicatesGroupResponse GetGroupsOfDuplicates(string entityName, string[] columns, 
				int offset, int count, int topDuplicatesPerGroup) {
			return GetGroupsOfDuplicates(new GetGroupsOfDuplicatesParams {
				EntityName = entityName,
				Columns = columns,
				Count = count,
				Offset = offset,
				TopDuplicatesPerGroup = topDuplicatesPerGroup
			});
		}
		
		/// <summary>
		/// Gets groups of duplicate entities.
		/// </summary>
		/// <param name="parameters">Parameters object.</param>
		/// <returns>Groups of duplicate entities.</returns>
		public BulkDuplicatesGroupResponse GetGroupsOfDuplicates(GetGroupsOfDuplicatesParams parameters) {
			var response = new BulkDuplicatesGroupResponse { Groups = new Collection<BulkEntityClientDuplicatesGroup>() };
			string entityName = parameters.EntityName;
			int count = parameters.Count;
			int serviceGroupOffset = parameters.Offset;
			int serviceGroupCount = parameters.Count;
			var esq = GetDuplicateEntitiesEsq(entityName);
			var serverToClientColumnNameMap = GetServerToClientColumnNameMap(parameters.Columns, esq);
			IEntitySchemaQueryFilterItem esqFilter = GetESQFilter(esq, parameters.Filters);
			var duplicateCountInfo = FetchDuplicatesCountFromService(entityName, false);
			bool areFiltersDefined = AreFiltersDefined(esqFilter);
			int totalCount = 0;
			var startDate = DateTime.UtcNow;
			bool isExpired = false;
			while (!isExpired && totalCount < duplicateCountInfo.GroupsCount) {
				isExpired = IsExpired(startDate);
				var duplicateGroupsInfo = FetchGroupOfDuplicatesFromService(
					entityName, 
					serviceGroupOffset, 
					serviceGroupCount, 
					parameters.TopDuplicatesPerGroup);
				totalCount += duplicateGroupsInfo.Count; 
				foreach (var duplicateGroup in duplicateGroupsInfo) {
					var duplicateGroupResponse = GetDuplicatesGroupResponse(duplicateGroup, esq, 
						serverToClientColumnNameMap, esqFilter);
					if (duplicateGroupResponse == null) {
						continue;
					}
					if (areFiltersDefined) {
						DecorateFilteredGroup(parameters, entityName, duplicateGroupResponse);
					}
					if (duplicateGroupResponse.Rows.IsNotEmpty()) {
						response.Groups.Add(duplicateGroupResponse);
					}
				}
				var allRowsFetchedFromService = duplicateGroupsInfo.Count < serviceGroupCount;
				if (allRowsFetchedFromService) {
					serviceGroupOffset = -1;
					break;
				}
				serviceGroupOffset += serviceGroupCount;
				serviceGroupCount = areFiltersDefined ? count : count - response.Groups.Count;
				var requestedRowsCountFetched = response.Groups.Count >= count;
				if (requestedRowsCountFetched) {
					break;
				}
			}
			AddIsUniqueColumn(esq);
			response.RowConfig = QueryExtension.GetColumnConfig(esq, serverToClientColumnNameMap);
			response.NextOffset = serviceGroupOffset;
			response.IsExpired = isExpired;
			return response;
		}

		private bool IsExpired(DateTime startDate) {
			if (GetGroupsOfDuplicatesRequestTimeoutSec <= 0) {
				return false;
			}
			double totalSeconds = (DateTime.UtcNow - startDate).TotalSeconds;
			if (totalSeconds > GetGroupsOfDuplicatesRequestTimeoutSec) {
				Log.Warn($"Getting duplicates terminated by timeout {totalSeconds}");
				return true;
			}
			return false;
		}

		/// <summary>
		/// Gets duplicates by group.
		/// </summary>
		/// <param name="parameters">Parameters object.</param>
		/// <returns>Duplicates by group.</returns>
		public BulkEntityClientDuplicatesGroup GetDuplicateEntitiesByGroup(GetDuplicateEntitiesByGroupParams parameters) {
			var response = new BulkEntityClientDuplicatesGroup();
			string entityName = parameters.EntityName;
			var esq = GetDuplicateEntitiesEsq(entityName);
			IEntitySchemaQueryFilterItem esqFilter = GetESQFilter(esq, parameters.Filters);
			var serverToClientColumnNameMap = GetServerToClientColumnNameMap(parameters.Columns, esq);
			var duplicates = FetchDuplicatesByGroupFromService(parameters.GroupId, parameters.Offset, parameters.Count);
			var duplicateEntities = GetDuplicateEntities(esq, serverToClientColumnNameMap, duplicates, esqFilter);
			response.GroupId = parameters.GroupId;
			response.Rows = duplicateEntities;
			return response;
		}

		/// <summary>
		/// Gets unique records identifiers from deduplication service by specifying duplicates identifiers.
		/// </summary>
		/// <param name="entityName">Entity name.</param>
		/// <param name="duplicatesIds">Duplicates identifiers.</param>
		/// <returns>Unique records identifiers.</returns>
		public IEnumerable<Guid> GetUniqueRecordsIdsFromDuplicates(string entityName, IEnumerable<Guid> duplicatesIds) {
			HttpRequestConfig request = CreateGetUniqueRecordsRequest(entityName, duplicatesIds);
			var response = HttpClient.SendWithJsonBody(request);
			var uniqueDuplicatesIds = GetUniqueRecordIds(entityName, response);
			return uniqueDuplicatesIds;
		}

		/// <inheritdoc cref="IBulkDeduplicationManager.GetDuplicateEntitiesByGroup"/>
		[Obsolete("Use GetDuplicateEntitiesByGroup with GetDuplicateEntitiesByGroupParams parameter instead.")]
		public BulkEntityClientDuplicatesGroup GetDuplicateEntitiesByGroup(string entityName, string[] columns, Guid groupId, int offset, int count) {
			return GetDuplicateEntitiesByGroup(new GetDuplicateEntitiesByGroupParams {
				EntityName = entityName,
				Columns = columns,
				GroupId = groupId,
				Offset = offset,
				Count = count
			});
		}
		
		/// <inheritdoc cref="IBulkDeduplicationManager.GetDuplicateCountData"/>
		public BulkDuplicatesCountResponse GetDuplicateCountData(string entityName) {
			var duplicates = FetchDuplicatesCountFromService(entityName);
			var response = new BulkDuplicatesCountResponse() {
				DuplicatesCount = duplicates.DuplicatesCount,
				GroupsCount = duplicates.GroupsCount
			};
			return response;
		}

		/// <inheritdoc cref="IBulkDeduplicationManager.GetDuplicateEntitiesGroups"/>
		public BulkDuplicatesGroupResponse GetDuplicateEntitiesGroups(string entityName, string[] columns,
				int clientOffset, int clientCount) {
			var response = new BulkDuplicatesGroupResponse {Groups = new Collection<BulkEntityClientDuplicatesGroup>()};
			var offset = clientOffset;
			var esq = GetDuplicateEntitiesEsq(entityName);
			var serverToClientColumnNameMap = GetServerToClientColumnNameMap(columns, esq);
			for (int i = 0; i < MaxFetchPages; i++) {
				var duplicateRecordGroups = FetchDuplicatesFromService(entityName, offset, clientCount);
				if (duplicateRecordGroups == null) {
					break;
				}
				foreach (var duplicateRecords in duplicateRecordGroups) {
					var duplicatesGroupId = duplicateRecords.Key;
					var duplicatesOfGroup = duplicateRecords.ToList();
					var existingDuplicates = GetDuplicateEntities(esq, serverToClientColumnNameMap, duplicatesOfGroup);
					var responseGroup = response.Groups.Find(x => x.GroupId == duplicatesGroupId);
					if (responseGroup == null) {
						responseGroup = new BulkEntityClientDuplicatesGroup {
							GroupId = duplicatesGroupId, 
							Rows = new EntityCollection()
						};
						response.Groups.Add(responseGroup);
					}
					responseGroup.Rows.AddRange(existingDuplicates);
				}
				var receivedDuplicatesCount = duplicateRecordGroups.Sum(x => x.Count());
				var existingDuplicatesCount = response.Groups.Sum(x => x.Rows.Count());
				response.NextOffset = offset += receivedDuplicatesCount;
				if (receivedDuplicatesCount < clientCount || existingDuplicatesCount >= clientCount) {
					break;
				}
			}
			if (response.Groups.IsEmpty()) {
				return null;
			}
			AddIsUniqueColumn(esq);
			response.RowConfig = QueryExtension.GetColumnConfig(esq, serverToClientColumnNameMap);
			response.TotalCountRecords = response.Groups.Sum(x => x.Rows.Count);
			return response;
		}

		/// <inheritdoc cref="IBulkDeduplicationManager.StartDeduplicationTask"/>
		public bool StartDeduplicationTask(string sectionName) {
			try {
				var startDeduplicationRequest = _startDeduplicationRequestFactory
					.CreateStartDeduplicationRequest(sectionName, IndexName);
				var request = new HttpRequestConfig(new Uri(BaseUrl), $"{DeduplicationTaskControllerPath}start") {
					Body = startDeduplicationRequest
				};
				var response = HttpClient.SendWithJsonBody(request);
				var data = response.GetResult<DeduplicationTaskResponse>();
				if (data?.TaskStatus != null) {
					DeduplicationTaskStatus? taskStatus = data.TaskStatus;
					if (taskStatus != DeduplicationTaskStatus.Pending) {
						return false;
					}
					ScheduleDeduplicationTaskStatusCheckingJob(sectionName);
					return true;
				}
				Log.Error($"StartDeduplicationTask for '{sectionName}' is invalid. {response.Content}");
				return false;
			} catch (Exception exception) {
				Log.Error($"StartDeduplicationTask for '{sectionName}' is invalid", exception);
				return false;
			}
		}

		/// <inheritdoc cref="IBulkDeduplicationManager.CancelDeduplicationTask"/>
		public void CancelDeduplicationTask(string sectionName) {
			try {
				var actualDeduplicationTask =
					_bulkDeduplicationTaskClient.GetActualDeduplicationTask(sectionName, IndexName);

				if (actualDeduplicationTask.TaskStatus == DeduplicationTaskStatus.Running) {
					var cancelDeduplicationRequest = _startDeduplicationRequestFactory
						.CreateStartDeduplicationRequest(sectionName, IndexName);
					var request = new HttpRequestConfig(new Uri(BaseUrl), $"{DeduplicationTaskControllerPath}cancel") {
						Body = cancelDeduplicationRequest
					};
					var response = HttpClient.SendWithJsonBody(request);
					if (!response.IsSuccessStatusCode) {
						Log.Error($"StopDeduplicationTask for '{sectionName}' is invalid. {response.Content}");
						throw new Exception(response.Content);
					}
				}
			} catch (Exception exception) {
				Log.Error($"StopDeduplicationTask for '{sectionName}' is invalid", exception);
				throw new HttpException(HttpStatusCode.InternalServerError, exception.Message);
			}
		}

		/// <inheritdoc cref="IBulkDeduplicationManager.AddToUniqueList"/>
		public bool AddToUniqueList(string entityName, Guid[] uniqueRecordIds) {
			var addToUniqueListRequest = new AddUniqueRecordsRequest {
				IndexName = IndexName,
				SourceEntityName = entityName,
				UniqueRecordIds = new Collection<Guid>(uniqueRecordIds.ToList())
			};
			var request = new HttpRequestConfig(new Uri(BaseUrl), UniqueControllerPath) {
				Body = addToUniqueListRequest
			};
			var response = HttpClient.SendWithJsonBody(request);
			if (response.StatusCode != HttpStatusCode.OK) {
				Log.ErrorFormat("Cannot add unique records for section {0} and index {1}. The message is {2}",
					entityName, IndexName, response.Content);
			}
			return response.StatusCode == HttpStatusCode.OK;
		}
		
		/// <inheritdoc cref="IBulkDeduplicationGroupManager.AddGroupToUniqueList"/>
		public bool AddGroupToUniqueList(string entityName, Guid groupId) {
			var duplicatesList = FetchDuplicatesByGroupFromService(groupId, 0, Int32.MaxValue);
			return AddToUniqueList(entityName, duplicatesList.Select(x => x.RecordId).ToArray());
		}
		
		#endregion

	}

	#endregion

}
