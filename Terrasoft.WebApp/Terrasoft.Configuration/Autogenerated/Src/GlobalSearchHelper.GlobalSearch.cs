namespace Terrasoft.Configuration.GlobalSearchHelper
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text.RegularExpressions;
	using global::Common.Logging;
	using Creatio.FeatureToggling;
	using Terrasoft.Configuration.GlobalSearchDto;
	using Terrasoft.Core;
	using Terrasoft.GlobalSearch;
	using Terrasoft.Nui.ServiceModel.DataContract;
	using EntitySchemaColumn = Terrasoft.Core.Entities.EntitySchemaColumn;
	using Terrasoft.Configuration.GlobalSearchColumnUtils;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Factories;
	using Terrasoft.Core.Store;
	using EntityCollection = Terrasoft.Core.Entities.EntityCollection;
	using EntitySchema = Terrasoft.Core.Entities.EntitySchema;
	using Terrasoft.Monitoring;
	using System.Diagnostics;
	using Terrasoft.Common;
	using Terrasoft.Configuration.GlobalSearch;
	using Terrasoft.GlobalSearch.Monitoring;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.Configuration;

	#region Class: GlobalSearchHelper

	public class GlobalSearchHelper
	{

		#region Constants: Private
		private const string FileEntityNameSuffix = "File";
		private const string SysFileEntityName = "SysFile";
		private const string LeadFileEntityName = "FileLead";
		private const string SysFileRecordIdColumnName = "RecordId";
		private const string SysFileRecordSchemaName = "RecordSchemaName";

		#endregion

		#region Fields: Private

		private string _entityName;
		private EntitySchema _entitySchema;
		private GlobalSearchColumnUtils _globalSearchColumnUtils;
		private readonly Regex _replaceHighlightRegex = new Regex(@"[{}]");
		private static readonly ILog _log = LogManager.GetLogger("GlobalSearch");
		private readonly string[] _defaultScoreSectionNames = { "Contact", "Account" };
		private readonly IMetricReporter _metricReporter = ClassFactory.Get<IMetricReporter>();

		#endregion

		#region Properties: Private

		private int ShouldMatchPercent => SysSettings.GetValue(UserConnection, "GlobalSearchShouldMatchPercent", 0);

		private bool UseInexactSearch => SysSettings.GetValue(UserConnection, "UseInexactGlobalSearch", false);

		private bool UseLocalizableGlobalSearchResult => SysSettings.GetValue(UserConnection, "UseLocalizableGlobalSearchResult", false);

		private int PrimaryColumnDefaultWeight => SysSettings.GetValue(UserConnection, "GlobalSearchDefaultPrimaryColumnWeight", 5);

		private int EntityDefaultWeight => SysSettings.GetValue(UserConnection, "GlobalSearchDefaultEntityWeight", 2);

		private int AdditionalRecordsCount => 
			SysSettings.GetValue(UserConnection, "GlobalSearchAdditionalRecordsCount", 20);

		private bool? _isHighlightEnabled;
		private bool IsHighlightEnabled =>
			_isHighlightEnabled ?? (_isHighlightEnabled = Features.GetIsEnabled<GlobalSearchFeatures.EnableHighlight>()).Value;

		private GlobalSearchColumnUtils GlobalSearchColumnUtils =>
			_globalSearchColumnUtils ?? (_globalSearchColumnUtils = ClassFactory.Get<GlobalSearchColumnUtils>());

		#endregion

		#region Properties: Protected

		protected UserConnection UserConnection { get; }

		#endregion

		#region Constructors: Public

		/// <summary>Initializes a new instance of the class <see cref="GlobalSearchHelper"/>,
		/// using the specified user connection.</summary>
		/// <param name="userConnection"><see cref="UserConnection"/> instance.</param>
		public GlobalSearchHelper(UserConnection userConnection) {
			UserConnection = userConnection;
		}

		#endregion

		#region Methods: Private

		private Dictionary<string, List<string>> PrepareRightsCondition(ESSearchResponse esResponse, string entityName, List<string> recordsId) {
			var conditions = new Dictionary<string, List<string>> {
				{entityName, recordsId}
			};
			var isSchemaUsedMasterRecordRights = UserConnection.DBSecurityEngine.GetSchemaUseMasterRecordRights(entityName);
			if (IsSysFileEntity(entityName) && !isSchemaUsedMasterRecordRights) {
				conditions = GetSysFileParentEntityRightsConditions(esResponse, recordsId);
			}
			if (IsRelationFileEntity(entityName) && !isSchemaUsedMasterRecordRights) {
				conditions = PrepareFileRightsConditions(esResponse, conditions);
			}
			return conditions;
		}

		private (string RecordId, string RecordSchemaName) GetSysFileRecordColumnValues(ESHit esHit) {
			EntitySchema fileSchema = UserConnection.EntitySchemaManager.FindInstanceByName(SysFileEntityName);
			if (fileSchema == null) {
				return (string.Empty, string.Empty);
			}
			var recordIdColumn = fileSchema.Columns.FindByName(SysFileRecordIdColumnName);
			var recordSchemaNameColumn = fileSchema.Columns.FindByName(SysFileRecordSchemaName);
			if (recordSchemaNameColumn == null || recordIdColumn == null) {
				return (string.Empty, string.Empty);
			}
			var recordSchemaNameColumnAlias = GlobalSearchColumnUtils.GetAlias(recordSchemaNameColumn, fileSchema);
			var source = esHit.Source;
			var recordSchemaName = source.ContainsKey(recordSchemaNameColumnAlias)
				? source[recordSchemaNameColumnAlias]
				: string.Empty;
			var recordIdColumnAlias = GlobalSearchColumnUtils.GetPrimaryColumnAlias(recordIdColumn, SysFileEntityName);
			var recordId = source.ContainsKey(recordIdColumnAlias)
				? source[recordIdColumnAlias]
				: string.Empty;
			return (recordId, recordSchemaName);
		}

		private string GetEntityDisplayName(string entityName, string id) {
			EntitySchema entitySchema = UserConnection.EntitySchemaManager.FindInstanceByName(entityName);
			var primaryDisplayColumn = entitySchema?.PrimaryDisplayColumn;
			if (primaryDisplayColumn == null || id.IsNullOrEmpty()) {
				return string.Empty;
			}
			var esq = new EntitySchemaQuery(entitySchema);
			esq.AddColumn(primaryDisplayColumn.Name);
			var entity = esq.GetEntity(UserConnection, id);
			return entity?.PrimaryDisplayColumnValue;
		}

		private Dictionary<string, List<string>> GetSysFileParentEntityRightsConditions(ESSearchResponse esResponse, List<string> recordsId) {
			var conditions = new Dictionary<string, List<string>>();
			var sysFileHits = esResponse.SearchResult.Hits.Where(x => recordsId.Contains(x.Id)).ToList();
			foreach (var sysFileHit in sysFileHits) {
				var (parentId, parentEntityName) = GetSysFileRecordColumnValues(sysFileHit);
				if (parentEntityName.IsEmpty() || parentId.IsEmpty()) {
					continue;
				}
				if (conditions.ContainsKey(parentEntityName)) {
					conditions[parentEntityName].Add(parentId);
				} else {
					conditions[parentEntityName] = new List<string> { parentId };
				}
			}
			return conditions;
		}

		private Dictionary<string, List<string>> PrepareFileRightsConditions(ESSearchResponse esResponse, Dictionary<string, List<string>> conditions) {
			var entityName = conditions.First().Key;
			var listOfIds = conditions.First().Value;
			var parentEntityName = entityName.Replace(FileEntityNameSuffix, "");
			var parentEntity = UserConnection.EntitySchemaManager.FindInstanceByName(parentEntityName);
			if (parentEntity != null) {
				try {
					var currentFileHits = esResponse.SearchResult.Hits.Where(x => listOfIds.Contains(x.Id)).ToList();
					EntitySchema fileSchema = UserConnection.EntitySchemaManager.FindInstanceByName(entityName);
					var column = fileSchema.Columns.FindByName(parentEntityName);
					if (column != null) {
						var masterPrimaryColumnAlias = GlobalSearchColumnUtils.GetPrimaryColumnAlias(column, entityName);
						var parentEntityIds = currentFileHits
							.Where(x => x.Source.ContainsKey(masterPrimaryColumnAlias))
							.Select(x => x.Source[masterPrimaryColumnAlias]).ToList();
						return new Dictionary<string, List<string>> {
							{ parentEntityName, parentEntityIds }
						};
					}
				} catch (Exception ex) {
					_log.ErrorFormat(@"Entity name: {0}, Identifiers: {1} 
						Exception: {2}", entityName, string.Join(", ", listOfIds), ex.Message);
				}
			}
			return conditions;
		}

		private void AppendAvailableRecordIds(List<string> availableRecordIdentifiers, List<string> availableIds,
			string entityName, ESSearchResponse esResponse) {
			if (IsRelationFileEntity(entityName) || IsSysFileEntity(entityName)) {
				try {
					EntitySchema fileSchema = UserConnection.EntitySchemaManager.GetInstanceByName(entityName);
					var parentColumnName = IsSysFileEntity(entityName)
						? SysFileRecordIdColumnName
						: entityName.Replace(FileEntityNameSuffix, "");
					var column = fileSchema.Columns.FindByName(parentColumnName);
					if (column != null) {
						var masterPrimaryColumnAlias = GlobalSearchColumnUtils.GetPrimaryColumnAlias(column, entityName);
						var availableFileHits =
							UserConnection.DBSecurityEngine.GetSchemaUseMasterRecordRights(entityName) ?
								esResponse.SearchResult.Hits.Where(
									x => x.Type == entityName && availableIds.Contains(x.Id.ToLower())).ToList() :
								esResponse.SearchResult.Hits.Where(
									x => x.Source.ContainsKey(masterPrimaryColumnAlias)
									     && x.Type == entityName
									     && availableIds.Contains(x.Source[masterPrimaryColumnAlias].ToLower())).ToList();
						availableRecordIdentifiers.AddRange(availableFileHits.Select(x => x.Id.ToLower()));
					}
				} catch (Exception ex) {
					_log.ErrorFormat(@"Entity name: {0}, Identifiers: {1} 
						Exception: {2}", entityName, string.Join(", ", availableIds), ex.Message);
				}
				return;
			}
			availableRecordIdentifiers.AddRange(availableIds);
		}

		private bool IsRelationFileEntity(string entityName) {
			if (IsSysFileEntity(entityName)) {
				return false;
			}
			return entityName.EndsWith(FileEntityNameSuffix) || entityName == LeadFileEntityName;
		}

		private bool IsSysFileEntity(string entityName) {
			return entityName.Equals(SysFileEntityName);
		}

		private bool IsSysFileRecordIdColumn(string columnName) {
			return _entityName == SysFileEntityName && columnName == SysFileRecordIdColumnName;
		}

		private BpmSearchResponseEntity FillBpmResponseEntity(ESHit esHit, EntitySchema entitySchema) {
			_entityName = esHit.Type;
			_entitySchema = entitySchema;
			var responseEntity = new BpmSearchResponseEntity {
				Id = esHit.Id,
				EntityName = _entityName,
				ColumnValues = new Dictionary<string, object>(),
				FoundColumns = new Dictionary<string, string[]>()
			};
			var columnValues = responseEntity.ColumnValues;
			var foundColumns = responseEntity.FoundColumns;
			var availableColumns = GetAvailableColumnsCollection(_entityName).ToArray();
			Dictionary<string, object> entityValues = null;
			if (UseLocalizableGlobalSearchResult) {
				entityValues = GetLocalizableEntityValues(_entitySchema, Guid.Parse(esHit.Id), availableColumns);
			}
			foreach (EntitySchemaColumn column in availableColumns) {
				if (UseLocalizableGlobalSearchResult && entityValues != null) {
					ApplyLocalizableColumnValues(esHit, column, columnValues, entityValues);
				} else {
					ApplyColumnValues(esHit, column, columnValues);
				}
				AddHighlights(esHit, column, foundColumns, columnValues);
			}
			AddDetailsHighlight(responseEntity, esHit);
			return responseEntity;
		}

		private void ApplyLocalizableColumnValues(ESHit esHit, EntitySchemaColumn column,
				Dictionary<string, object> columnValues, IReadOnlyDictionary<string, object> entityValues) {
			if (IsSysFileRecordIdColumn(column.Name)) {
				AddSysFileRecordColumnValue(esHit, column, columnValues);
			} else {
				columnValues.Add(column.Name, entityValues[column.Name]);
			}
		}

		private void ApplyColumnValues(ESHit esHit, EntitySchemaColumn column,
				Dictionary<string, object> columnValues) {
			if (column.IsLookupType) {
				AddLookupColumnValue(esHit, column, columnValues);
			} else if (IsSysFileRecordIdColumn(column.Name)) {
				AddSysFileRecordColumnValue(esHit, column, columnValues);
			} else {
				AddColumnValue(esHit, column, columnValues);
			}
		}

		private Dictionary<string, object> GetLocalizableEntityValues(EntitySchema entitySchema,
			Guid recordId,
			IEnumerable<EntitySchemaColumn> availableColumns) {
			var esq = new EntitySchemaQuery(entitySchema);
			esq.PrimaryQueryColumn.IsAlwaysSelect = true;
			var serverClientColumnMap = new Dictionary<string, string>();
			foreach (var c in availableColumns) {
				esq.AddColumn(c.Name);
				serverClientColumnMap.Add(c.Name, c.Name);
			}
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal,
				esq.RootSchema.GetPrimaryColumnName(), recordId));
			return Nui.ServiceModel.Extensions.QueryExtension
				.GetEntityCollection(esq.GetEntityCollection(UserConnection), serverClientColumnMap)
				.FirstOrDefault();
		}

		private void AddDetailsHighlight(BpmSearchResponseEntity responseEntity, ESHit esHit) {
			var highlights = esHit.Highlight;
			if (highlights != null) {
				var detailsHighlights = esHit.Highlight.Where(s => s.Key.StartsWith(ESConstants.DetailsPrefix)
					&& !s.Key.EndsWith("id"));
				IEnumerable<IGrouping<string, string[]>> groupedDetailsHighlights =
					detailsHighlights.GroupBy(x => GetDetailNameByKey(x.Key), x => x.Value);
				foreach (var detailsHighlight in groupedDetailsHighlights) {
					var detailEntityName = detailsHighlight.Key.Replace($"{ESConstants.DetailsPrefix}.", "");
					var highlightValues = detailsHighlight.Select(x => string.Join(" ... ", x)).ToArray();
					var detailCaption = GetDetailCaption(detailEntityName);
					var highLightMatches = GetHighLightMatches(highlightValues);
					responseEntity.FoundColumns.Add(detailEntityName, highLightMatches);
					responseEntity.ColumnValues.Add(detailEntityName, new {
						caption = detailCaption,
						displayValue = _replaceHighlightRegex.Replace(string.Join(" ... ", highlightValues), "")
					});
				}
			}
		}

		/// <summary>
		/// Gets detail name by key with suffix.
		/// </summary>
		/// <param name="keyWithSuffix">Key name with suffix.</param>
		/// <returns>Detail name.</returns>
		private string GetDetailNameByKey(string keyWithSuffix) {
			Regex detailPattern = new Regex("^([^.]+\\.[^.]+)\\..*$");
			var key = detailPattern.Replace(keyWithSuffix, "$1");
			Regex detailSuffixPattern = new Regex("^([^_]+)_.*$");
			return detailSuffixPattern.Replace(key, "$1");
		}

		private string GetDetailCaption(string detailName) {
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "SysDetail");
			esq.IsDistinct = true;
			esq.Cache = UserConnection.SessionCache.WithLocalCaching("GlobalSearchDetails");
			esq.CacheItemName = "GlobalSearchDetailList";
			var captionColumn = esq.AddColumn("Caption");
			var entityNameColumn = esq.AddColumn("[SysSchema:UId:EntitySchemaUId].Name");
			var detailSchemaNameColumn = esq.AddColumn("[SysSchema:UId:DetailSchemaUId].Name");
			var detailSchemaIdColumn = esq.AddColumn("[SysSchema:UId:DetailSchemaUId].Id");
			var detailSchemaParentColumn = esq.AddColumn("[SysSchema:UId:DetailSchemaUId].Parent");
			var matchingRows = esq.GetEntityCollection(UserConnection)
				.Where(x => x.GetTypedColumnValue<string>(entityNameColumn.Name) == detailName)
				.ToList();
			if (matchingRows.Count == 0) {
				return "Unknown detail";
			}
			// Multiple SysDetail rows can share the same entity (e.g. ContactCommunication has both
			// base ContactCommunicationDetail and SSP's SspContactCommunicationDetail). The canonical
			// detail is the root of the parent-graph among candidates: its DetailSchema.Parent does
			// NOT resolve to another candidate's DetailSchema.Id. SysSchema.Parent is the FK to the
			// parent row's Id (PK), not its UId — confirmed via OData on a live env. Tiebreak by
			// ordinal sort on detail schema name so the result is deterministic.
			var candidateSchemaIds = matchingRows
				.Select(r => r.GetTypedColumnValue<Guid>(detailSchemaIdColumn.Name))
				.ToHashSet();
			var roots = matchingRows
				.Where(r => !candidateSchemaIds.Contains(r.GetTypedColumnValue<Guid>(detailSchemaParentColumn.Name)))
				.ToList();
			var chosen = (roots.Count > 0 ? roots : matchingRows)
				.OrderBy(r => r.GetTypedColumnValue<string>(detailSchemaNameColumn.Name), StringComparer.Ordinal)
				.First();
			// TrimEnd guards against historical typos in seed captions (e.g. CrtBase r68173
			// stored "Contact communication options " with a trailing space, which renders as
			// "Contact communication options :" in the search highlight).
			return (chosen.GetTypedColumnValue<string>(captionColumn.Name) ?? string.Empty).TrimEnd();
		}

		private void AddHighlights(ESHit esHit, EntitySchemaColumn column, Dictionary<string, string[]> foundColumns,
				Dictionary<string, object> columnValues) {
			var columnName = column.Name;
			string[] highlight = GetColumnHighlight(esHit, column);
			if (highlight != null && highlight.Length > 0) {
				foundColumns[columnName] = highlight;
				if (!columnValues.ContainsKey(columnName)) {
					AppendAdditionalHighLightColumn(columnValues, esHit, column);
				}
			}
		}

		private void AddColumnValue(ESHit esHit, EntitySchemaColumn column, Dictionary<string, object> columnValues) {
			var value = GetColumnValue(esHit, column);
			if (!string.IsNullOrEmpty(value)) {
				columnValues[column.Name] = value;
			}
		}

		private void AddLookupColumnValue(ESHit esHit, EntitySchemaColumn column, Dictionary<string, object> columnValues) {
			var lookupValue = GetLookupColumnValue(esHit, column);
			if (lookupValue == null) {
				return;
			}
			if (column.DataValueType is ImageLookupDataValueType && !Guid.TryParse(lookupValue.Value, out _)) {
				lookupValue.Value = null;
				lookupValue.DisplayValue = null;
			}
			columnValues[column.Name] = lookupValue;
		}

		private void AddSysFileRecordColumnValue(ESHit esHit, EntitySchemaColumn column, Dictionary<string, object> columnValues) {
			var lookupValue = GetSysFileColumnValue(esHit, column);
			if (lookupValue == null) {
				return;
			}
			var sysFileRecordColumnValues = GetSysFileRecordColumnValues(esHit);
			var recordSchemaName = sysFileRecordColumnValues.RecordSchemaName;
			if (recordSchemaName.IsNullOrEmpty()) {
				return;
			}
			columnValues[recordSchemaName] = lookupValue;
		}

		private string[] GetColumnHighlight(ESHit esHit, EntitySchemaColumn column) {
			string[] result = Array.Empty<string>();
			if (esHit.Highlight != null) {
				var columnAlias = GlobalSearchColumnUtils.GetAlias(column, _entitySchema);
				var columnHighlightValue = esHit.Highlight.FirstOrDefault(x => string.Equals(x.Key, columnAlias)).Value;
				if (columnHighlightValue == null) {
					return result;
				}
				result = GetHighLightMatches(columnHighlightValue);
				if (result.IsNullOrEmpty() && columnHighlightValue.IsNotEmpty()) {
					return new[] { string.Empty };
				}
			}
			return result;
		}

		private string[] GetHighLightMatches(string[] columnHighlightValue) {
			var highlightPattern = $"{Regex.Escape("{{{")}(.*?){Regex.Escape("}}}")}";
			var regexp = new Regex(highlightPattern);
			var matches = regexp.Matches(string.Join("", columnHighlightValue));
			if (matches.Count == 0) {
				return new string[] {};
			}
			return matches.Cast<Match>().Select(m => _replaceHighlightRegex.Replace(m.Value, "")).ToArray();
		}

		private void AppendAdditionalHighLightColumn(Dictionary<string, object> columnValues, ESHit esHit, EntitySchemaColumn column) {
			var columnAlias = GlobalSearchColumnUtils.GetAlias(column, _entitySchema);
			var columnHighlightValue = esHit.Highlight.FirstOrDefault(x => string.Equals(x.Key, columnAlias)).Value;
			if (columnHighlightValue != null) {
				columnValues.Add(column.Name, _replaceHighlightRegex.Replace(string.Join("...", columnHighlightValue), ""));
			}
		}

		private LookupColumnValue GetLookupColumnValue(ESHit esHit, EntitySchemaColumn column) {
			LookupColumnValue resultValue = null;
			var columnAlias = GlobalSearchColumnUtils.GetAlias(column, _entitySchema);
			string displayValue = esHit.Source.FirstOrDefault(x => string.Equals(x.Key, columnAlias)).Value;
			var hasDisplayValue = !string.IsNullOrEmpty(displayValue);
			var isSysImageLookupColumn = GlobalSearchColumnUtils.GetIsSysImageLookupColumn(column);
			if (hasDisplayValue || isSysImageLookupColumn) {
				var displayColumnAlias = GlobalSearchColumnUtils.GetPrimaryColumnAlias(column, _entityName);
				resultValue = new LookupColumnValue {
					Value = esHit.Source.FirstOrDefault(x => string.Equals(x.Key, displayColumnAlias)).Value,
					DisplayValue = displayValue
				};
				var imageColumn = column.ReferenceSchema?.PrimaryImageColumn;
				if (imageColumn != null && imageColumn.DataValueType is ImageLookupDataValueType) {
					var primaryImageColumnAlias = GlobalSearchColumnUtils.GetPrimaryImageColumnAlias(column, _entityName);
					resultValue.PrimaryImageValue = esHit.Source
						.FirstOrDefault(x => string.Equals(x.Key, primaryImageColumnAlias)).Value;
				}
			}
			return resultValue;
		}

		private LookupColumnValue GetSysFileColumnValue(ESHit esHit, EntitySchemaColumn column) {
			var displayColumnAlias = GlobalSearchColumnUtils.GetPrimaryColumnAlias(column, _entityName);
			var recordId = esHit.Source.FirstOrDefault(x => string.Equals(x.Key, displayColumnAlias)).Value;
			if (recordId.IsNullOrEmpty()) {
				return null;
			}
			var (parentId, parentEntityName) = GetSysFileRecordColumnValues(esHit);
			var displayValue = GetEntityDisplayName(parentEntityName, parentId);
			return new LookupColumnValue {
				Value = recordId,
				DisplayValue = displayValue
			};
		}

		private string GetColumnValue(ESHit esHit, EntitySchemaColumn column) {
			var columnAlias = GlobalSearchColumnUtils.GetAlias(column, _entitySchema);
			return esHit.Source.FirstOrDefault(x => string.Equals(x.Key, columnAlias,
				StringComparison.InvariantCultureIgnoreCase)).Value;
		}

		private SearchRequestQuery GetDefaultSearchRequestQuery(int countRecord, int pageNum, int from) {
			var size = countRecord + AdditionalRecordsCount;
			var highlight = new EShighlight {
				IsEnabled = IsHighlightEnabled
			};
			var searchRequestQuery = new SearchRequestQuery {
				From = from + pageNum * size,
				Size = size,
				Source = new ESSource(),
				Highlight = highlight
			};
			return searchRequestQuery;
		}

		private HashSet<string> GetQueryFields(bool exactQuery) {
			var fields = new HashSet<string> { exactQuery ? $"{ESConstants.AllField}^5" : ESConstants.AllField,
				$"*{ESConstants.NumberColumnSuffix}^10",
				$"*{ESConstants.PrimaryColumnsSuffix}^5",
				$"{ESConstants.TextDetailColumnsPattern}^5"
			};
			return fields;
		}

		private void ApplySectionScoreSettings(string sectionEntityName, List<ESMultiMatchQuery> multiMatchQueries,
			EntitySchema currentSectionEntity, List<ESFunction> functions) {
			foreach (var esMultiMatchQuery in multiMatchQueries) {
				AppendDefaultPrimaryColumnField(currentSectionEntity, esMultiMatchQuery);
			}
			AppendDefaultFunction(functions, sectionEntityName);
		}

		private List<ESMultiMatchQuery> GetMultiMatchQueries(string query) {
			var multiMatchQueries = new List<ESMultiMatchQuery>();
			if (UseInexactSearch) {
				multiMatchQueries.Add(new ESMultiMatchQuery {
					Query = query,
					Fields = GetQueryFields(false),
					MinimumShouldMatch = ShouldMatchPercent == 0
						? ESConstants.MinShouldMatch
						: $"{ShouldMatchPercent}%"
				});
			} else {
				multiMatchQueries.Add(new ESMultiMatchQuery
				{
					Query = query,
					Type = "cross_fields",
					Operator = "and",
					Fields = GetQueryFields(true)
				});
			}
			return multiMatchQueries;
		}

		private void AppendDefaultPrimaryColumnField(EntitySchema entitySchema, ESMultiMatchQuery multiMatchQuery) {
			var primaryColumn = entitySchema.PrimaryDisplayColumn;
			if (primaryColumn != null) {
				var alias = GlobalSearchColumnUtils.GetAlias(primaryColumn, entitySchema);
				if (!multiMatchQuery.Fields.Any(x => x.Contains(alias))) {
					multiMatchQuery.Fields.Add($"{alias}^{PrimaryColumnDefaultWeight}");
				}
			}
		}

		private void AppendDefaultFunction(List<ESFunction> functions, string sectionEntityName) {
			functions.Add(new ESFunction { Type = sectionEntityName, Weight = EntityDefaultWeight });
		}

		private void AddFileItemToGroup(List<BpmSearchAggregation> group, ESAggregation esAggregation) {
			var fileItem = group.FirstOrDefault(x => x.TypeAlias == FileEntityNameSuffix);
			if (fileItem == null) {
				fileItem = new BpmSearchAggregation {
					Count = esAggregation.Count,
					TypeAlias = FileEntityNameSuffix,
					Type = esAggregation.Type
				};
				group.Add(fileItem);
				return;
			}
			fileItem.Count += esAggregation.Count;
			fileItem.Type += $",{esAggregation.Type}";
		}

		private ESScoreQuery GetSearchScoreQuery(string query, string sectionEntityName, bool useScoreSettings = true) {
			var functions = new List<ESFunction>();
			var multiMatchQueries = GetMultiMatchQueries(query);
			if (!useScoreSettings) {
				return new ESScoreQuery(functions, multiMatchQueries);
			}
			if (string.IsNullOrEmpty(sectionEntityName)) {
				ApplyDefaultScoreSettings(functions, multiMatchQueries);
				return new ESScoreQuery(functions, multiMatchQueries);
			}
			var currentSectionEntity = UserConnection.EntitySchemaManager.FindInstanceByName(sectionEntityName);
			if (currentSectionEntity != null) {
				ApplySectionScoreSettings(sectionEntityName, multiMatchQueries, currentSectionEntity, functions);
			}
			return new ESScoreQuery(functions, multiMatchQueries);
		}

		#endregion

		#region Methods: Protected


		/// <summary>
		/// Get available column colection.
		/// </summary>
		/// <param name="entityName"> entity schema name.</param>
		/// <returns><see cref="IEnumerable<EntitySchemaColumn>"/>.</returns>
		protected virtual IEnumerable<EntitySchemaColumn> GetAvailableColumnsCollection(string entityName) {
			var entitySchema = UserConnection.EntitySchemaManager.GetInstanceByName(entityName);
			return entitySchema.Columns
				.Where(column => CanReadColumn(entityName, column)
					&& !(column.DataValueType is BinaryDataValueType));
		}

		/// <summary>
		/// Check if can read column.
		/// </summary>
		/// <param name="schemaName"> entity schema name. </param>
		/// <param name="column"> column name. </param>
		/// <returns><see cref="bool"/>.</returns>
		protected virtual bool CanReadColumn(string schemaName, EntitySchemaColumn column) {
			var operation = UserConnection.DBSecurityEngine
						.GetEntitySchemaColumnRightLevel(schemaName, column.ColumnValueName, SchemaOperationRightLevels.CanRead);
			return operation != EntitySchemaColumnRightLevel.Deny;
		}

		/// <summary>
		/// Get aggregation groups.
		/// </summary>
		/// <param name="esAggsResponse"><see cref="ESAggregationResponse"/> instance. </param>
		/// <returns><see cref="List<ESAggregation>"/> collection elastic search aggregation.</returns>
		protected virtual List<ESAggregation> GetEsAggregationGroups(ESAggregationResponse esAggsResponse) {
			return esAggsResponse.Aggregations.GroupedAggregations.Groups;
		}


		/// <summary>
		/// Get search response groups.
		/// </summary>
		/// <param name="esResponse"><see cref="ESSearchResponse"/> search response. </param>
		/// <returns><see cref="IEnumerable<IGrouping<string, string>>>"/> grouped elastic search response.</returns>
		protected virtual IEnumerable<IGrouping<string, string>> GetEsSearchResponseGroups(ESSearchResponse esResponse) {
			return esResponse.SearchResult.Hits.GroupBy(x => x.Type, x => x.Id);
		}

		/// <summary>
		/// Get records with read rights.
		/// </summary>
		/// <param name="esResponse"><see cref="ESSearchResponse"/> search response. </param>
		/// <returns><see cref="List<string>"/> grouped elastic search response.</returns>
		protected virtual List<string> GetAvailableRecordIdentifiers(ESSearchResponse esResponse) {
			IEnumerable<IGrouping<string, string>> groupedTypes = GetEsSearchResponseGroups(esResponse);
			List<string> resultAvailableIds = new List<string>();
			Stopwatch sw = new Stopwatch();
			sw.Start();
			foreach (var groupedType in groupedTypes) {
				var groupedTypeName = groupedType.Key;
				var conditions = PrepareRightsCondition(esResponse, groupedTypeName, groupedType.ToList());
				foreach (var condition in conditions) {
					var entityName = condition.Key;
					var recordIds = condition.Value;
					var hasEntity = UserConnection.EntitySchemaManager.FindInstanceByName(entityName) != null;
					if (!hasEntity || recordIds.Count == 0) {
						_log.ErrorFormat("Instance of entity with name {0} was not found while checking record permissions.",
							entityName);
						continue;
					}
					var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, entityName);
					esq.PrimaryQueryColumn.IsAlwaysSelect = true;
					foreach (string column in UserConnection.DBSecurityEngine.GetSchemaSignificantColumns(entityName)) {
						if (esq.RootSchema.Columns.FindByName(column) != null) {
							esq.AddColumn(column);
						}
					}
					esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal,
						esq.PrimaryQueryColumn.Name, recordIds));
					EntityCollection collection = esq.GetEntityCollection(UserConnection);
					var availableIds = collection.Select(e => e.PrimaryColumnValue.ToString().ToLower()).ToList();
					AppendAvailableRecordIds(resultAvailableIds, availableIds, groupedTypeName, esResponse);
				}
			}
			sw.Stop();
			_metricReporter.Report(new SearchMetric { Duration = sw.ElapsedMilliseconds, Source = SearchSource.Bpm });
			return resultAvailableIds;
		}

		/// <summary>
		/// Add default score settings.
		/// </summary>
		/// <param name="functions">.</param>
		/// <param name="multiMatchQueries">.</param>
		protected virtual void ApplyDefaultScoreSettings(List<ESFunction> functions,
				List<ESMultiMatchQuery> multiMatchQueries) {
			foreach (var defaultSectionName in _defaultScoreSectionNames) {
				AppendDefaultFunction(functions, defaultSectionName);
			}
			foreach (var esMultiMatchQuery in multiMatchQueries) {
				foreach (var defaultSectionName in _defaultScoreSectionNames) {
					var sectionEntity = UserConnection.EntitySchemaManager.FindInstanceByName(defaultSectionName);
					AppendDefaultPrimaryColumnField(sectionEntity, esMultiMatchQuery);
				}
			}
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Process elastic search response.
		/// </summary>
		/// <param name="esResponse"><see cref="ESSearchResponse"/> instance.</param>
		/// <returns><see cref="BpmSearchResponse"/> instance.</returns>
		[Obsolete("Use ProcessEsSearchResponse(esResponse)")]
		public virtual BpmSearchResponse ProccessEsSearchResponse(ESSearchResponse esResponse) {
			return ProcessEsSearchResponse(esResponse);
		}

		/// <summary>
		/// Process elastic search response.
		/// </summary>
		/// <param name="esResponse"><see cref="ESSearchResponse"/> instance.</param>
		/// <returns><see cref="BpmSearchResponse"/> instance.</returns>
		public virtual BpmSearchResponse ProcessEsSearchResponse(ESSearchResponse esResponse) {
			var availableRecordIdentifiers = GetAvailableRecordIdentifiers(esResponse);
			BpmSearchResponse searchResponse = new BpmSearchResponse();
			searchResponse.Took = esResponse.Took;
			searchResponse.Total = esResponse.SearchResult.Total;
			searchResponse.Data = new List<BpmSearchResponseEntity>();
			searchResponse.Success = true;
			var availableHits = esResponse.SearchResult.Hits
				.Where(x => availableRecordIdentifiers.Contains(x.Id.ToLower())).ToList();
			foreach (ESHit esHit in availableHits) {
				var entitySchema = UserConnection.EntitySchemaManager.FindInstanceByName(esHit.Type);
				if (entitySchema != null) {
					var responseEntity = FillBpmResponseEntity(esHit, entitySchema);
					if (responseEntity.ColumnValues.Any() &&
							(responseEntity.FoundColumns.Any() || !IsHighlightEnabled)) {
						searchResponse.Data.Add(responseEntity);
					}
				}
			}
			return searchResponse;
		}

		/// <summary>
		/// Process elastic search aggregations response.
		/// </summary>
		/// <param name="esAggsResponse"><see cref="ESAggregationResponse"/> instance.</param>
		/// <returns>List of <see cref="BpmSearchAggregation"/> instances.</returns>
		[Obsolete("Use ProcessEsAggregationResponse(esAggsResponse)")]
		public virtual List<BpmSearchAggregation> ProccessEsAggregationResponse(ESAggregationResponse esAggsResponse) {
			return ProcessEsAggregationResponse(esAggsResponse);
		}

		/// <summary>
		/// Process elastic search aggregations response.
		/// </summary>
		/// <param name="esAggsResponse"><see cref="ESAggregationResponse"/> instance.</param>
		/// <returns>List of <see cref="BpmSearchAggregation"/> instances.</returns>
		public virtual List<BpmSearchAggregation> ProcessEsAggregationResponse(ESAggregationResponse esAggsResponse) {
			var group = new List<BpmSearchAggregation>();
			try {
				List<ESAggregation> esAggregationGroups = GetEsAggregationGroups(esAggsResponse);
				foreach (var esAggregation in esAggregationGroups) {
					var type = esAggregation.Type;
					if (!UserConnection.DBSecurityEngine.GetIsEntitySchemaReadingAllowed(type)) {
						continue;
					}
					if (IsRelationFileEntity(type) || IsSysFileEntity(type)) {
						AddFileItemToGroup(group, esAggregation);
						continue;
					}
					group.Add(new BpmSearchAggregation {
						Type = type,
						TypeAlias = type,
						Count = esAggregation.Count
					});
				}
			} catch (Exception ex) {
				_log.ErrorFormat("ProcessESAggregationResponse. {0}\r\n{1}", ex.Message, ex.StackTrace);
			}
			return group;
		}

		/// <summary>
		/// Prepare <see cref="SearchRequestQuery"/> instance.
		/// </summary>
		/// <param name="queryString">Query string.</param>
		/// <param name="recordCount">Count of selected records.</param>
		/// <param name="pageNum">Number of selected page.</param>
		/// <param name="from"></param>
		/// <returns><see cref="SearchRequestQuery"/> instance.</returns>
		public virtual SearchRequestQuery GetSearchRequestQuery(string queryString, int recordCount, int pageNum, int from) {
			var searchRequestQuery = GetDefaultSearchRequestQuery(recordCount, pageNum, from);
			searchRequestQuery.Query = new ESMatchQuery { Query = queryString };
			return searchRequestQuery;
		}

		/// <summary>
		/// Prepare <see cref="SearchRequestQuery"/> instance with custom score settings.
		/// </summary>
		/// <param name="queryString">Query string.</param>
		/// <param name="sectionEntityName">Current section entity name.</param>
		/// <param name="recordCount">Count of selected records.</param>
		/// <param name="pageNum">Number of search page.</param>
		/// <param name="from"></param>
		/// <returns><see cref="SearchRequestQuery"/> instance.</returns>
		public virtual SearchRequestQuery GetSearchScoreRequestQuery(string queryString, string sectionEntityName,
				int recordCount, int pageNum, int from) {
			var searchRequestQuery = GetDefaultSearchRequestQuery(recordCount, pageNum, from);
			searchRequestQuery.Query = GetSearchScoreQuery(queryString, sectionEntityName);
			return searchRequestQuery;
		}

		/// <summary>
		/// Prepare <see cref="AggsSearchRequestQuery"/> instance with custom score settings.
		/// </summary>
		/// <param name="queryString">Query string.</param>
		/// <param name="sectionEntityName">Current section entity name.</param>
		/// <returns><see cref="AggsSearchRequestQuery"/> instance.</returns>
		public virtual AggsSearchRequestQuery GetAggsSearchScoreRequestQuery(string queryString, string sectionEntityName) {
			var aggsSearchRequestQuery = new AggsSearchRequestQuery {
				Query = GetSearchScoreQuery(queryString, sectionEntityName, false)
			};
			return aggsSearchRequestQuery;
		}

		#endregion

	}

	#endregion

}

