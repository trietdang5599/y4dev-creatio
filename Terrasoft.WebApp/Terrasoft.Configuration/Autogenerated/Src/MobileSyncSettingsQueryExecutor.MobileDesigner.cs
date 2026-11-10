namespace Terrasoft.MobileSyncSettings {
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Linq.Expressions;
	using System.Reflection;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using Terrasoft.Common;
	using global::Common.Logging;
	using Terrasoft.Configuration.SerializedEsqFilterConvertation;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Factories;

	using Terrasoft.Mobile;

	#region Class: MobileSyncSettingsQueryExecutor

	[DefaultBinding(typeof(IEntityQueryExecutor), Name = "MobileSyncSettQueryExecutor")]
	public class MobileSyncSettingsQueryExecutor : IEntityQueryExecutor {

		#region Class: FiltersInfo

		private class FiltersInfo {
			
			private List<string> FilterColumns { get; } = new List<string>();
			
			private List<EntitySchemaQueryFilter> ItemFilters { get; } = new List<EntitySchemaQueryFilter>();
			
			#region Properties: Public

			public string WorkplaceCode { get; set; } = "DefaultWorkplace";

			public string PrimaryValue { get; set; }

			#endregion

			private bool matchValue(FilterComparisonType comparisonType, object paramValue, object propertyValue) {
				if (!(paramValue is string filterTextValue) || !(propertyValue is string textValue)) {
					return true;
				}
				bool result = true;
				switch (comparisonType) {
					case FilterComparisonType.Equal:
					case FilterComparisonType.NotEqual:
						result = textValue.Equals(filterTextValue,
							StringComparison.OrdinalIgnoreCase);
						break;
					case FilterComparisonType.Contain:
					case FilterComparisonType.NotContain:
						result = textValue.IndexOf(filterTextValue,
							StringComparison.OrdinalIgnoreCase) > -1;
						break;
					case FilterComparisonType.StartWith:
					case FilterComparisonType.NotStartWith:
						result = textValue.StartsWith(filterTextValue,
							StringComparison.OrdinalIgnoreCase);
						break;
					case FilterComparisonType.EndWith:
					case FilterComparisonType.NotEndWith:
						result = textValue.EndsWith(filterTextValue,
							StringComparison.OrdinalIgnoreCase);
						break;
				}
				switch (comparisonType) {
					case FilterComparisonType.NotEqual:
					case FilterComparisonType.NotContain:
					case FilterComparisonType.NotStartWith:
					case FilterComparisonType.NotEndWith:
						result = !result;
						break;
				}
				return result;
			}

			public void AddFilter(EntitySchemaQueryFilter filter) {
				ItemFilters.Add(filter);
				FilterColumns.Add(filter.LeftExpression.Path);
			}

			public bool HasColumn(string columnName) {
				return FilterColumns.Contains(columnName);
			}

			public bool Match(ModelDescriptor descriptor) {
				if (PrimaryValue != null) {
					return descriptor.EntityName.Equals(PrimaryValue);
				}
				foreach (EntitySchemaQueryFilter filter in ItemFilters) {
					string propertyName = filter.LeftExpression.Path;
					PropertyInfo propertyInfo = typeof(ModelDescriptor).GetProperty(propertyName);
					if (propertyInfo != null) {
						EntitySchemaQueryExpression param = filter.RightExpressions.Find(expression =>
							expression.ExpressionType == EntitySchemaQueryExpressionType.Parameter &&
							expression.ParameterValue != null);
						if (param != null) {
							object value = propertyInfo.GetValue(descriptor);
							if (!matchValue(filter.ComparisonType, param.ParameterValue, value)) {
								return false;
							}
						}
					}
				}
				return true;
			}
		}

		#endregion
		
		#region Class: ModelDescriptor

		private class ModelDescriptor {

			public string EntityName { get; set; }

			public string EntityCaption { get; set; }

			public bool IsEnabled { get; set; }

			public int Count { get; set; }

			public int TotalCount { get; set; }

			public string FilterData { get; set; }

		}

		#endregion

		#region Fields: Private

		private readonly EntitySchema _entitySchema;
		private readonly UserConnection _userConnection;
		private SortedDictionary<string, string> _workplaceInfo;

		#endregion

		#region Constructors: Public

		public MobileSyncSettingsQueryExecutor(UserConnection userConnection) {
			_userConnection = userConnection;
			_entitySchema = userConnection.EntitySchemaManager.GetInstanceByName("MobileSyncSett");
		}

		#endregion

		#region Properties: Protected

		/// <summary>
		/// Error logger.
		/// </summary>
		private ILog _log;
		protected ILog Log => _log ?? (_log = LogManager.GetLogger("MobileSyncSettings"));

		#endregion

		#region Methods: Private

		private string GetPrimaryValue(string code, string entityName) {
			return FileUtilities.GetMD5HashFromString(code + "_" + entityName);
		}

		private void GetItemByHash(string hash, out string code, out string entityName) {
			EntitySchemaManager manager = _userConnection.EntitySchemaManager;
			string hashString = hash.Replace("-", "").ToLower();
			SortedDictionary<string, string> codes = GetWorkplacesInfo();
			foreach (ISchemaManagerItem<EntitySchema> item in manager.GetItems()) {
				foreach (string workplaceCode in codes.Keys) {
					if (hashString.Equals(GetPrimaryValue(workplaceCode, item.Name))) {
						code = workplaceCode;
						entityName = item.Name;
						return;
					}
				}
			}
			code = null;
			entityName = null;
		}

		private SortedDictionary<string, OrderDirection> GetSortingInfo(EntitySchemaQuery query) {
			var map = new SortedDictionary<string, OrderDirection>();
			query.Columns.Where(c => c.OrderDirection != OrderDirection.None).OrderBy(c => c.OrderPosition)
				.Select(c => (c.Path, c.OrderDirection)).ForEach(item => map.Add(item.Path, item.OrderDirection));
			return map;
		}

		private SortedDictionary<string, string> GetWorkplacesInfo() {
			if (_workplaceInfo == null) {
				_workplaceInfo = new SortedDictionary<string, string>();
				JArray mobileWorkplaces = MobileDataUtilities.GetMobileWorkplaces(_userConnection, false);
				foreach (JToken workplace in mobileWorkplaces) {
					_workplaceInfo.Add((string)workplace["Code"], (string)workplace["Name"]);
				}
			}
			return _workplaceInfo;
		}

		private IQueryable<ModelDescriptor> GetOrderedDescriptors(IQueryable<ModelDescriptor> items,
				SortedDictionary<string, OrderDirection> sortingInfo) {
			IReadOnlyDictionary<string, Expression<Func<ModelDescriptor, object>>> columnToPropertyMap =
				new Dictionary<string, Expression<Func<ModelDescriptor, object>>> {
					{ "Id", descriptor => descriptor.EntityName },
					{ "EntityName", descriptor => descriptor.EntityName },
					{ "EntityCaption", descriptor => descriptor.EntityCaption },
					{ "IsEnabled", descriptor => descriptor.IsEnabled },
					{ "FilterData", descriptor => descriptor.FilterData },
					{ "Count", descriptor => descriptor.Count },
					{ "TotalCount", descriptor => descriptor.TotalCount }
				};
			IOrderedQueryable<ModelDescriptor> ordered = null;
			foreach (string path in sortingInfo.Keys) {
				if (!columnToPropertyMap.TryGetValue(path, out var sortExpression)) {
					continue;
				}
				if (ordered == null) {
					ordered = sortingInfo[path] == OrderDirection.Ascending
						? items.OrderBy(sortExpression)
						: items.OrderByDescending(sortExpression);
				} else {
					ordered = sortingInfo[path] == OrderDirection.Ascending
						? ordered.ThenBy(sortExpression)
						: ordered.ThenByDescending(sortExpression);
				}
			}
			return ordered ?? items;
		}

		private int GetCount(string entityName, String queryFilter) {
			var query = new EntitySchemaQuery(_userConnection.EntitySchemaManager, entityName);
			var columnCount = query.AddColumn(query.CreateAggregationFunction(AggregationTypeStrict.Count, query.PrimaryQueryColumn.Name));
			query.AddSerializedFilter(_userConnection, queryFilter);
			var countEntity = query.GetEntityCollection(_userConnection)[0];
			var count = countEntity.GetTypedColumnValue<int>(columnCount.Name);
			return count;
		}

		private int GetTotalCount(string entityName) {
			var query = new EntitySchemaQuery(_userConnection.EntitySchemaManager, entityName);
			var columnCount = query.AddColumn(query.CreateAggregationFunction(AggregationTypeStrict.Count, query.PrimaryQueryColumn.Name));
			var countEntity = query.GetEntityCollection(_userConnection)[0];
			var count = countEntity.GetTypedColumnValue<int>(columnCount.Name);
			return count;
		}

		private void ExtractFilters(IEntitySchemaQueryFilterItem filterItem, FiltersInfo filtersInfo) {
			if (filterItem is EntitySchemaQueryFilter filter) {
				EntitySchemaQueryExpressionCollection expressions = filter.RightExpressions;
				if (expressions.Count == 1 && expressions.All(e =>
						e.ExpressionType == EntitySchemaQueryExpressionType.Parameter)) {
					string filterValue = expressions.First().ParameterValue.ToString();
					if (filter.LeftExpression.Path == "WorkplaceCode") {
						filtersInfo.WorkplaceCode = filterValue;
					} else if (filter.LeftExpression.Path == "Id") {
						GetItemByHash(filterValue, out string workplaceCode, out string entityName);
						filtersInfo.WorkplaceCode = workplaceCode;
						filtersInfo.PrimaryValue = entityName;
					} else {
						filtersInfo.AddFilter(filter);
					}
				} else if (filter.LeftExpression.Path == "Id") {
					filtersInfo.PrimaryValue = "";
				}
				return;
			}
			if (!(filterItem is EntitySchemaQueryFilterCollection collection)) {
				return;
			}
			foreach (IEntitySchemaQueryFilterItem item in collection) {
				ExtractFilters(item, filtersInfo);
			}
		}

		private ModelDescriptor GetDescriptor(ModelDataImportConfigModel item, FiltersInfo filtersInfo,
				SortedDictionary<string, OrderDirection> sortingInfo) {
			string entityName = item.Name;
			string entityCaption = null;
			string filterData = null;
			if (sortingInfo.ContainsKey("EntityCaption") || filtersInfo.HasColumn("EntityCaption")) {
				IManagerItem schema = _userConnection.EntitySchemaManager.GetItemByName(entityName);
				entityCaption = schema.Caption;
			}
			JObject queryFilter = item.QueryFilter;
			if (queryFilter != null) {
				filterData = queryFilter.ToString(Formatting.None);
			}
			var descriptor = new ModelDescriptor {
				EntityName = entityName,
				EntityCaption = entityCaption,
				IsEnabled = item.IsEnabled,
				FilterData = filterData
			};
			if (!filtersInfo.Match(descriptor)) {
				return null;
			}
			int count = -1;
			int totalCount = -1;
			if (item.IsEnabled) {
				if (sortingInfo.ContainsKey("TotalCount")) {
					totalCount = GetTotalCount(entityName);
				}
				if (sortingInfo.ContainsKey("Count")) {
					if (filterData != null) {
						count = GetCount(entityName, filterData);
					} else {
						count = totalCount == -1 ? GetTotalCount(entityName) : totalCount;
					}
				}
			} else {
				count = 0;
				totalCount = 0;
			}
			descriptor.Count = count;
			descriptor.TotalCount = totalCount;
			return descriptor;
		}

		private IQueryable<ModelDescriptor> GetItems(MobileManifest manifest, FiltersInfo filtersInfo,
				SortedDictionary<string, OrderDirection> sortingInfo) {
			List<ModelDescriptor> filteredItems = new List<ModelDescriptor>();
			foreach (ModelDataImportConfigModel item in manifest.ModelDataImportConfig) {
				var descriptor = GetDescriptor(item, filtersInfo, sortingInfo);
				if (descriptor != null) {
					filteredItems.Add(descriptor);
					if (filtersInfo.PrimaryValue != null) {
						break;
					}
				}
			}
			return filteredItems.AsQueryable();
		}

		private Entity CreateEntity(EntitySchemaQuery esq, ModelDescriptor item, string workplaceCode, string workplaceName) {
			string entityName = item.EntityName;
			if (esq.Columns.ExistsByPath("EntityCaption") && item.EntityCaption == null) {
				item.EntityCaption = _userConnection.EntitySchemaManager.GetItemByName(entityName).Caption;
			}
			if (esq.Columns.ExistsByPath("TotalCount") && item.TotalCount == -1) {
				try {
					item.TotalCount = GetTotalCount(entityName);
				} catch (Exception e) {
					Log.Error($"Calculating total count for item '{entityName}' failed. Exception: {e}");
				}
			}
			if (esq.Columns.ExistsByPath("Count") && item.Count == -1) {
				try {
					if (item.FilterData != null) {
						item.Count = GetCount(entityName, item.FilterData);
					} else {
						item.Count = item.TotalCount == -1 ? GetTotalCount(entityName) : item.TotalCount;
					}
				} catch (Exception e) {
					Log.Error($"Calculating count for item '{entityName}' failed. FilterData: {item.FilterData}, Exception: {e}");
				}
			}
			Entity row = _entitySchema.CreateEntity(_userConnection);
			row.SetColumnValue("Id", Guid.Parse(GetPrimaryValue(workplaceCode, entityName)));
			row.SetColumnValue("EntityName", entityName);
			row.SetColumnValue("EntityCaption", item.EntityCaption);
			row.SetColumnValue("IsEnabled", item.IsEnabled);
			row.SetColumnValue("Count", item.Count);
			row.SetColumnValue("TotalCount", item.TotalCount);
			row.SetColumnValue("FilterData", item.FilterData);
			row.SetColumnValue("WorkplaceCode", workplaceCode);
			row.SetColumnValue("WorkplaceName", workplaceName);
			return row;
		}

		#endregion

		#region Methods: Public

		public virtual MobileManifest GetManifest(string code) {
			var utilities = new MobileUtilities(_userConnection);
			return utilities.GetLoadedManifest(code, false, false);
		}

		public EntityCollection GetEntityCollection(EntitySchemaQuery esq) {
			EntitySchemaQuery parentQuery = esq.Filters.ParentQuery;
			var collection = new EntityCollection(_userConnection, _entitySchema);
			FiltersInfo filtersInfo = new FiltersInfo();
			ExtractFilters(esq.Filters, filtersInfo);
			MobileManifest manifest;
			try {
				manifest = GetManifest(filtersInfo.WorkplaceCode);
			} catch (ItemNotFoundException) {
				return collection;
			}
			var sortingInfo = GetSortingInfo(parentQuery);
			IQueryable<ModelDescriptor> items = GetItems(manifest, filtersInfo, sortingInfo);
			items = GetOrderedDescriptors(items, sortingInfo);
			IEnumerable<ModelDescriptor> descriptors = items.Skip(parentQuery.SkipRowCount);
			descriptors = parentQuery.RowCount == -1 ? descriptors : descriptors.Take(parentQuery.RowCount);
			string workplaceName = null;
			if (parentQuery.Columns.ExistsByPath("WorkplaceName")) {
				SortedDictionary<string, string> codes = GetWorkplacesInfo();
				workplaceName = codes[filtersInfo.WorkplaceCode];
			}
			foreach (ModelDescriptor item in descriptors) {
				collection.Add(CreateEntity(parentQuery, item, filtersInfo.WorkplaceCode, workplaceName));
			}
			return collection;
		}

		#endregion

	}

	#endregion

}

