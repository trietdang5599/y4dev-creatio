namespace Terrasoft.Configuration.Timeline
{
	using global::Common.Logging;
	using Newtonsoft.Json;
	using System;
	using System.Collections.Generic;
	using System.Diagnostics;
	using System.Linq;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Factories;
	using Terrasoft.Nui.ServiceModel.DataContract;
	using Terrasoft.Nui.ServiceModel.Extensions;
	using DataValueType = Nui.ServiceModel.DataContract.DataValueType;
	using DCEntityCollection = Nui.ServiceModel.DataContract.EntityCollection;

	#region EsqTimelineDataLoader

	/// <summary>
	/// Timeline data loader for binded entities.
	/// </summary>
	[DefaultBinding(typeof(ITimelineDataLoader), Name = "EntitySchemaQuery")]
	public class EsqTimelineDataLoader : ITimelineDataLoader
	{

		#region Constants: Private

		private readonly string _replacementSortColumnName = "ModifiedOn";
		private readonly string _columnToSortAlias = "ColumnToSort";

		#endregion

		#region Constants: Protected

		protected readonly string _idColumnName = "Id";

		#endregion

		#region Constructors: Public

		public EsqTimelineDataLoader(UserConnection userConnection) {
			UserConnection = userConnection;
		}

		#endregion

		#region Properties: Protected

		protected UserConnection UserConnection { get; }

		/// <summary>
		/// <see cref="ILog"/> implementation instance.
		/// </summary>
		private ILog _timelineLogger;
		protected ILog TimelineLogger {
			get {
				return _timelineLogger ?? (_timelineLogger = LogManager.GetLogger("TimelineLoader"));
			}
		}

		#endregion

		#region Methods: Private

		private EntitySchemaQuery BuildEsq(TimelineBoundEntity entity, TimelineRequestConfig config) {
			var select = new SelectQuery {
				RootSchemaName = entity.SchemaName
			};
			if (!string.IsNullOrEmpty(config.Filters)) {
				var filters = JsonConvert.DeserializeObject<Filters>(config.Filters);
				select.Filters = filters;
			}
			EntitySchemaQuery esq = select.BuildEsq(UserConnection);
			return esq;
		}

		private void AddColumnIfNotExists(Dictionary<string, string> columnAliases, EntitySchemaQuery esq, string columnName) {
			if (!columnAliases.ContainsKey(columnName)) {
				columnAliases.Add(esq.AddColumn(columnName).Name, columnName);
			}
		}

		private (EntitySchemaQuery, Dictionary<string, string>) GetBoundEntityQuery(TimelineBoundEntity entity, TimelineRequestConfig config) {
			EntitySchemaQuery esq = BuildEsq(entity, config);
			var columnAliases = new Dictionary<string, string>() {
				{ _idColumnName, _idColumnName },
				{ _columnToSortAlias, _columnToSortAlias }
			};
			esq.PrimaryQueryColumn.IsAlwaysSelect = true;
			esq.UseLocalization = true;
			columnAliases.Add(esq.AddColumn(entity.DateColumnName).Name, entity.DateColumnName);
			columnAliases.Add(esq.AddColumn(entity.AuthorColumnName).Name, entity.AuthorColumnName);
			AddColumnIfNotExists(columnAliases, esq, entity.SortColumnName);
			AddColumnIfNotExists(columnAliases, esq, _replacementSortColumnName);
			AddQueryColumns(entity, config, esq, columnAliases);
			var primaryDisplayColumnName = esq.RootSchema.PrimaryDisplayColumn?.Name;
			if (primaryDisplayColumnName != null && !columnAliases.Values.Contains(primaryDisplayColumnName)) {
				columnAliases.Add(esq.AddColumn(primaryDisplayColumnName).Name, primaryDisplayColumnName);
			}
			AddEsqFilters(entity, config, esq);
			SetEsqOrderDirection(entity, config, esq);
			return (esq, columnAliases);
		}

		private IEntitySchemaQueryFilterItem GetSearchFilterByColumn(TimelineRequestConfig config, EntitySchemaQuery esq, TimelineColumnConfig column, EntitySchemaQueryColumn esqColumn) {
			if (config.Search.IsNotNullOrEmpty() && IsSearchColumn(esqColumn)) {
				var columnName = esqColumn.IsLookup ? esqColumn.DisplayExpression.Path : column.ColumnName;
				if (IsNumericColumn(esqColumn)) {
					if (int.TryParse(config.Search, out int numericValue)) {
						return esq.CreateFilterWithParameters(FilterComparisonType.Equal, columnName, numericValue);
					}
					return null;
				}
				return esq.CreateFilterWithParameters(FilterComparisonType.Contain, columnName, config.Search);
			}
			return null;
		}

		private bool IsNumericColumn(EntitySchemaQueryColumn esqColumn) {
			return esqColumn.ValueExpression.SchemaColumn.DataValueType is NumericDataValueType;
		}

		private bool IsSearchColumn(EntitySchemaQueryColumn esqColumn) {
			return
				esqColumn.ValueExpression.SchemaColumn.DataValueType is TextDataValueType ||
				esqColumn.ValueExpression.SchemaColumn.DataValueType is LookupDataValueType ||
				IsNumericColumn(esqColumn);
		}

		private FilterComparisonType GetComparisonType(TimelineFilter filter) {
			if (filter == null || filter.ComparisonType == null || !Enum.IsDefined(typeof(FilterComparisonType), filter.ComparisonType)) {
				return FilterComparisonType.Equal;
			}
			return (FilterComparisonType)filter.ComparisonType;
		}

		private void AddEsqFilters(TimelineBoundEntity entity, TimelineRequestConfig config, EntitySchemaQuery esq) {
			if (entity.TimelineFilter != null) {
				FilterComparisonType comparisonType = GetComparisonType(entity.TimelineFilter);
				esq.Filters.Add(esq.CreateFilterWithParameters(comparisonType, entity.TimelineFilter.ColumnName, entity.TimelineFilter.ColumnValue));
			}
			if (config.RecordId != null) {
				esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Id", config.RecordId));
			}
			if (!string.IsNullOrEmpty(entity.Filters)) {
				var filters = JsonConvert.DeserializeObject<Filters>(entity.Filters);
				IEntitySchemaQueryFilterItem esqFilters
					= filters.BuildEsqFilter(esq.RootSchema.UId, UserConnection);
				esq.Filters.Add(esqFilters);
			}
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, entity.MasterEntityColumnName, config.MasterRecordId));
		}

		private void SetEsqOrderDirection(TimelineBoundEntity entity, TimelineRequestConfig config, EntitySchemaQuery esq) {
			EntitySchemaQueryColumn columnToSort = esq.AddColumn(new EntitySchemaIsNullQueryFunction(esq,
					esq.CreateSchemaColumnExpression(entity.SortColumnName),
					esq.CreateSchemaColumnExpression(_replacementSortColumnName)));
			columnToSort.Name = _columnToSortAlias;
			if (config.OrderDirection == OrderDirection.Ascending) {
				columnToSort.OrderByAsc();
			} else {
				columnToSort.OrderByDesc();
			}
		}

		private LookupColumnValue GetBoundEntityColumnValue(TimelineEntityCollection entityColumnValues, string columnName) {
			var columnValue = entityColumnValues.FirstOrDefault(e => e.ColumnName == columnName).ColumnValue;
			return columnValue;
		}

		private TimelineColumnDataType GetColumnDataType(string columnName, EntitySchemaQuery esq) {
			var column = esq.Columns.FirstOrDefault(f => (f.Path ?? f.Name) == columnName);
			var resultItem = new TimelineColumnDataType();
			if (column != null) {
				DataValueType dataValueType = (DataValueType)Enum.Parse(typeof(DataValueType), column.GetResultDataValueType(esq.DataValueTypeManager).Name);
				resultItem.DataValueType = dataValueType;
				if (column.IsLookup) {
					resultItem.IsLookup = true;
					resultItem.ReferenceSchemaName = column.ValueExpression.SchemaColumn.ReferenceSchema.Name;
				}
			}
			return resultItem;
		}

		private EntitySchemaQueryOptions GetEsqOptions(TimelineRequestConfig config) {
			return new EntitySchemaQueryOptions {
				PageableDirection = PageableSelectDirection.First,
				PageableRowCount = config.RowCount,
				RowsOffset = config.Offset,
				PageableConditionValues = new Dictionary<string, object>()
			};
		}

		private LookupColumnValue GetColumnValueByItemColumnValue(object value) {
			LookupColumnValue lookupValue = value as LookupColumnValue;
			return lookupValue != null ? lookupValue : new LookupColumnValue { Value = value?.ToString() ?? string.Empty };
		}

		private BoundTimelineEntity GetTimelineEntity(TimelineBoundEntity entity, TimelineEntityCollection entityColumnValues) {
			var id = Guid.Parse(GetBoundEntityColumnValue(entityColumnValues, _idColumnName).Value.ToString());
			return new BoundTimelineEntity {
				SchemaName = entity.SchemaName,
				BoundEntityName = entity.BoundEntityName,
				Id = id,
				EntityId = Guid.Parse(GetBoundEntityColumnValue(entityColumnValues, _idColumnName).Value.ToString()),
				Author = GetBoundEntityColumnValue(entityColumnValues, entity.AuthorColumnName),
				SortColumn = GetBoundEntityColumnValue(entityColumnValues, _columnToSortAlias).Value.ToString(),
				Date = GetBoundEntityColumnValue(entityColumnValues, _columnToSortAlias).Value.ToString(),
				ColumnValues = GetEntityColumnValuesWithoutExtraColumns(entityColumnValues),
				UserAccess = entity.IsNeedToCheckUserAccess ? GetUserAccess(entity.SchemaName, id) : UserType.General,
			};
		}

		private UserType GetUserAccess(string schemaName, Guid id) {
			if (UserConnection.DBSecurityEngine.GetIsEntitySchemaAdministratedByRecords(schemaName)) {
				return IsAnyExternalSysAdminUnitHasRecordRights(schemaName, id);
			} else if (UserConnection.DBSecurityEngine.GetIsEntitySchemaAdministratedByOperations(schemaName)) {
				return IsAnyExternalSysAdminUnitHasOperationRights(schemaName);
			}
			return UserType.General;
		}

		private UserType IsAnyExternalSysAdminUnitHasOperationRights(string schemaName) {
			var tableName = "SysEntitySchemaOperationRight";
			var sysOperationRightsSelect = new Select(UserConnection)
				.Column("SysAdminUnit", "ConnectionType")
				.From(tableName)
				.InnerJoin("SysAdminUnit")
				.On(tableName, "SysAdminUnitId")
				.IsEqual("SysAdminUnit", "Id")
				.InnerJoin("SysSchema")
				.On(tableName, "SubjectSchemaUId")
				.IsEqual("SysSchema", "UId")
				.Where("SysSchema", "Name")
				.IsEqual(Column.Parameter(schemaName))
				.And("CanRead").IsEqual(Column.Parameter(true))
				.And("ConnectionType").IsEqual(Column.Parameter(UserType.SSP))
				.And("Position")
				.IsGreater(Column.Parameter(-1)) as Select;
			return sysOperationRightsSelect.ExecuteScalar<int>() != 0 ? UserType.SSP : UserType.General;
		}

		private UserType IsAnyExternalSysAdminUnitHasRecordRights(string schemaName, Guid id) {
			var tableName = "Sys" + schemaName + "Right";
			var sysRecordRightsSelect = new Select(UserConnection)
				.Column("SysAdminUnit", "ConnectionType")
				.From(tableName)
				.InnerJoin("SysAdminUnit")
				.On(tableName, "SysAdminUnitId")
				.IsEqual("SysAdminUnit", "Id")
				.Where(tableName, "RecordId")
				.IsEqual(Column.Parameter(id, UserConnection.DataValueTypeManager.GetInstanceByName("Guid")))
				.And("Operation").IsEqual(Column.Parameter(0))
				.And("ConnectionType").IsEqual(Column.Parameter(UserType.SSP))
				.And("Position")
				.IsGreater(Column.Parameter(-1)) as Select;
			return sysRecordRightsSelect.ExecuteScalar<int>() != 0 ? UserType.SSP : UserType.General;
		}

		private TimelineEntityCollection GetEntityColumnValuesWithoutExtraColumns(TimelineEntityCollection entityColumnValues) {
			entityColumnValues.Remove(entityColumnValues.FirstOrDefault(e => e.ColumnName == _idColumnName));
			return entityColumnValues;
		}

		private string[] GetIdsToFetchAsAdmin(DCEntityCollection entityCollection, 
			IEnumerable<string> adminRightsColums,
			string primaryColumnName,
			out IEnumerable<string> actualColumnsToFetch) {
			List<string> idsToFetch = new List<string>();
			actualColumnsToFetch = new List<string>();
			foreach (var entity in entityCollection) {
				var emptyColumns = adminRightsColums
						.Select(c => new { Column = c, Value = entity[c] as string })
						.Where(c => c.Value.IsNullOrEmpty())
						.Select(c => c.Column);
					if (emptyColumns.Any()) {
						idsToFetch.Add((string)entity[primaryColumnName]);
						actualColumnsToFetch = actualColumnsToFetch.Union(emptyColumns);
					}
			}
			return idsToFetch.ToArray();
		}

		private BoundEntityColumn GetBoundEntityColumn(EntitySchemaQuery esq, KeyValuePair<string, object> itemColumnValue) {
			return new BoundEntityColumn {
				ColumnName = itemColumnValue.Key,
				ColumnValue = GetColumnValueByItemColumnValue(itemColumnValue.Value),
				ColumnCaption = GetCaption(esq, itemColumnValue),
				ColumnDataType = GetColumnDataType(itemColumnValue.Key, esq)
			};
		}

		private string GetCaption(EntitySchemaQuery esq, KeyValuePair<string, object> itemColumnValue) {
			var column = esq.Columns.FirstOrDefault(f => (f.Path ?? f.Name) == itemColumnValue.Key);
			if (column != null) {
				return column.Caption;
			}
			return string.Empty;
		}

		#endregion

		#region Methods: Protected

		protected virtual void AddQueryColumns(TimelineBoundEntity entity, TimelineRequestConfig config, EntitySchemaQuery esq, Dictionary<string, string> columnAliases) {
			var searchFilterCollection = new EntitySchemaQueryFilterCollection(esq, LogicalOperationStrict.Or);
			foreach (var column in entity.Columns) {
				if (!columnAliases.Values.Contains(column.ColumnName)) {
					var esqColumn = esq.AddColumn(column.ColumnName);
					columnAliases.Add(esqColumn.Name, column.ColumnName);
					var searchFilter = GetSearchFilterByColumn(config, esq, column, esqColumn);
					if (searchFilter != null) {
						searchFilterCollection.Add(searchFilter);
					}
				}
			}
			if (searchFilterCollection.Count > 0) {
				esq.Filters.Add(searchFilterCollection);
			}
		}

		protected virtual DCEntityCollection GetMappedItems(Dictionary<string, string> columnAliases,
			Core.Entities.EntityCollection boundEntityCollection) {
			return QueryExtension.GetEntityCollection(boundEntityCollection, columnAliases);
		}

		protected virtual DCEntityCollection ModifyMappedItems(Dictionary<string, string> columnAliases,
			DCEntityCollection mappedItems, TimelineRequestConfig config) {
			return mappedItems;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Loads Timeline data for specific entity.
		/// </summary>
		/// <param name="entity">entity.</param>
		/// <param name="config">Timeline load config.</param>
		public List<BoundTimelineEntity> LoadData(TimelineBoundEntity entity, TimelineRequestConfig config) {
			List<BoundTimelineEntity> boundTimelineEntities = new List<BoundTimelineEntity>();
			try	{
				EntitySchemaQueryOptions options = GetEsqOptions(config);
				(EntitySchemaQuery esq, Dictionary<string, string> columnAliases) = GetBoundEntityQuery(entity, config);
				Stopwatch watch = Stopwatch.StartNew();
				var boundEntityCollection = esq.GetEntityCollection(UserConnection, options);
				if (config.Search.IsNotNullOrEmpty()) {
					TimelineLogger.DebugFormat($"LoadDate performance: Filter with search = {config.Search} elapsed = {watch.Elapsed}");
				}
				else {
					TimelineLogger.DebugFormat($"LoadDate performance: Filter without search elapsed = {watch.Elapsed}");
				}
				if (watch.IsRunning) {
					watch.Stop();
				}
				var mappedItems = GetMappedItems(columnAliases, boundEntityCollection);
				mappedItems = ModifyMappedItems(columnAliases, mappedItems, config);
				ApplyUseAdminRightsColumns(mappedItems, entity);
				foreach (var item in mappedItems) {
					var entityColumnValues = new TimelineEntityCollection();
					foreach (var itemColumnValue in item) {
						var boundEntityColumn = GetBoundEntityColumn(esq, itemColumnValue);
						if (boundEntityColumn != null)	{
							entityColumnValues.Add(boundEntityColumn);
						}
					}
					var boundEntity = GetTimelineEntity(entity, entityColumnValues);
					boundEntity.PrimaryDisplayColumnName = esq.RootSchema.PrimaryDisplayColumn?.Name;
					boundTimelineEntities.Add(boundEntity);
				}
			}
			catch (Exception ex){
				TimelineLogger.Error("An error occurred while loading timeline data.", ex);
			}
			return boundTimelineEntities.DistinctBy(t => t.Id).ToList();
		}

		public void ApplyUseAdminRightsColumns(DCEntityCollection boundEntityCollection, TimelineBoundEntity entity) {
			var columnsToFetchAsAdmin = entity.Columns.Where(c => c.NoRightsCheck).Select(c => c.ColumnName);
			if (!columnsToFetchAsAdmin.Any()) {
				return;
			}
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, entity.SchemaName);
			esq.UseAdminRights = false;
			Dictionary<string, string> esqColumnAliases = new Dictionary<string, string>();
			string primaryColumnName = esq.RootSchema.GetPrimaryColumnName();
			esqColumnAliases.Add(primaryColumnName, esq.AddColumn(primaryColumnName).Name);
			var idList = GetIdsToFetchAsAdmin(boundEntityCollection, columnsToFetchAsAdmin,
					primaryColumnName, out IEnumerable<string> columnsToFetch);
			if (idList.Length == 0) {
				return;
			}
			columnsToFetch.ForEach(ctf => esqColumnAliases.Add(ctf, esq.AddColumn(ctf).Name));
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, primaryColumnName, idList));
			var adminRightsEntityCollection = esq.GetEntityCollection(UserConnection);
			adminRightsEntityCollection.ForEach(adminRightEntity => {
				var targetEntity = boundEntityCollection.First(
					boundEntity => (string)boundEntity[primaryColumnName] == adminRightEntity
						.GetTypedColumnValue<Guid>(esqColumnAliases[primaryColumnName]).ToString()
				);
				columnsToFetch.ForEach(ctf => {
					targetEntity[ctf] = adminRightEntity.GetColumnValue(esqColumnAliases[ctf]);
				});
			});
		}

		#endregion

	}

	#endregion

}
