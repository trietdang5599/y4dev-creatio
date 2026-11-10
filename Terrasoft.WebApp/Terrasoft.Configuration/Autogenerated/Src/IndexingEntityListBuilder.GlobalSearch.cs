namespace Terrasoft.Configuration.GlobalSearch
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using global::Common.Logging;
	using Terrasoft.Common;
	using Terrasoft.Configuration.GlobalSearchColumnUtils;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Factories;
	using Terrasoft.GlobalSearch.Interfaces;

	#region Class: IndexingEntityListBuilder

	/// <summary>
	/// Builds an indexable entity.
	/// </summary>
	public abstract class IndexingEntityListBuilder
	{

		#region Constants: Protected

		/// <summary>
		/// Log manager.
		/// </summary>
		protected static readonly ILog _log = LogManager.GetLogger("GlobalSearch");

		/// <summary>
		/// Offset fetch next macro.
		/// </summary>
		protected static readonly string _topFetchMacro = "##offsetNext##";

		/// <summary>
		/// From sql time macro.
		/// </summary>
		protected readonly string _fromSqlDateTimeMacro = "##fromSqlDateTime##";

		/// <summary>
		/// To sql time macro.
		/// </summary>
		protected readonly string _toSqlDateTimeMacro = "##toSqlDateTime##";
		
		/// <summary>
		/// Id list macro.
		/// </summary>
		protected static readonly string _idListMacro = $"'{{{Guid.Empty}}}'";

		/// <summary>
		/// Sql column wrap macro.
		/// </summary>
		protected readonly string _sqlColumnWrapMacro = "##";

		#endregion

		#region Fields: Private

		/// <summary>
		/// Dictionary of sections which will be indexed.
		/// </summary>
		private Dictionary<string, EntitySchemaQuery> _entityQueries;

		#endregion

		#region Fields: Protected

		/// <summary>
		/// <see cref="UserConnection"/> instance.
		/// </summary>
		protected UserConnection _userConnection;

		#endregion

		#region Properties: Private

		/// <summary>
		/// Gets the CultureId of the system settings.
		/// The value is retrieved from the system settings once and then cached.
		/// </summary>
		private Guid? _indexingCultureId;
		private Guid? IndexingCultureId => _indexingCultureId ?? (_indexingCultureId = GetGlobalSearchIndexationCultureId());

		#endregion

		#region Properties: Protected

		/// <summary>
		/// Simple indexation details.
		/// </summary>
		protected Dictionary<string, string> _simpleDetails;
		protected virtual Dictionary<string, string> SimpleDetails {
			get {
				return _simpleDetails ?? (_simpleDetails = new Dictionary<string, string> {
					{ "ContactAddress", "Contact" },
					{ "AccountAddress", "Account" },
					{ "AccountBillingInfo", "Account" }
				});
			}
		}

		/// <summary>
		/// Communication indexation details.
		/// </summary>
		protected Dictionary<string, string>  _communicationDetails;
		protected virtual Dictionary<string, string> CommunicationDetails {
			get {
				return _communicationDetails ?? (_communicationDetails = new Dictionary<string, string> {
					{ "ContactCommunication", "Contact" },
					{ "AccountCommunication", "Account" }
				});
			}
		}

		/// <summary>
		/// Combined list of keys from SimpleDetails and CommunicationDetails dictionaries.
		/// </summary>
		protected List<string> _detailsKeys;
		protected virtual List<string> DetailsKeys {
			get {
				if (_detailsKeys != null) {
					return _detailsKeys;
				}
				_detailsKeys = new List<string>();
				_detailsKeys.AddRange(SimpleDetails.Keys);
				_detailsKeys.AddRange(CommunicationDetails.Keys);
				return _detailsKeys;
			}
		}

		/// <summary>
		/// List of global search entity options.
		/// </summary>
		private List<IndexingEntityConfig> _indexingEntities;
		protected virtual List<IndexingEntityConfig> IndexingEntities {
			get => _indexingEntities ?? (_indexingEntities = new List<IndexingEntityConfig>());
			set => _indexingEntities = value;
		}

		/// <summary>
		/// <see cref="IgnoredEntityList"/> Ignore items manager.
		/// </summary>
		private IgnoredEntityList _ignoredEntityList;
		protected virtual IgnoredEntityList IgnoredEntityList {
			get {
				if (_ignoredEntityList != null) {
					return _ignoredEntityList;
				}
				var userConnection = new ConstructorArgument("userConnection", _userConnection);
				_ignoredEntityList = ClassFactory.Get<ConfigurableIndexingEntities>(userConnection);
				return _ignoredEntityList;
			}
			set => _ignoredEntityList = value;
		}

		/// <summary>
		/// Dictionary of the indexing types.
		/// </summary>
		private Dictionary<string, IndexingType> _indexingTypes;
		protected virtual Dictionary<string, IndexingType> IndexingTypes {
			get => _indexingTypes ?? (_indexingTypes = new Dictionary<string, IndexingType>());
			set => _indexingTypes = value;
		}

		/// <summary>
		/// Default indexing type of the entity.
		/// </summary>
		protected virtual IndexingType DefaultIndexingType => IndexingType.Index;

		/// <summary>
		/// List of the filter actions for entity schema query.
		/// </summary>
		private List<Action<EntitySchemaQuery>> _esqFuncFilterList;
		protected virtual List<Action<EntitySchemaQuery>> EsqFuncFilterList => 
			_esqFuncFilterList ?? (_esqFuncFilterList = new List<Action<EntitySchemaQuery>>());

		private bool? _modifiedOnLookupFilterEnabled;
		protected bool ModifiedOnLookupFilterEnabled {
			get {
				if (_modifiedOnLookupFilterEnabled.HasValue) {
					return _modifiedOnLookupFilterEnabled.Value;
				}
				if (SysSettings.TryGetValue(_userConnection, "GlobalSearchLookupFilterEnabled", out object value)) {
					_modifiedOnLookupFilterEnabled = (bool)value;
				} else {
					_modifiedOnLookupFilterEnabled = false;
				}
				return _modifiedOnLookupFilterEnabled.Value;
			}
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Entity queries of the sections.
		/// </summary>
		public Dictionary<string, EntitySchemaQuery> EntityQueries {
			get {
				return _entityQueries ?? (_entityQueries = new Dictionary<string, EntitySchemaQuery>());
			}
			set {
				_entityQueries = value;
			}
		}
		/// <summary>
		/// <see cref="GlobalSearchColumnUtils"/> instance.
		/// </summary>
		private GlobalSearchColumnUtils _globalSearchColumnUtils;
		public GlobalSearchColumnUtils GlobalSearchColumnUtils => 
			_globalSearchColumnUtils ?? (_globalSearchColumnUtils = new GlobalSearchColumnUtils());

		/// <summary>
		/// Id list of objects that are indexed.
		/// </summary>
		public List<Guid> IndexingSectionsUIds { get; set; }

		#endregion

		#region Constructors: Public

		/// <summary>Initializes a new instance of the IndexingEntityListBuilder class.</summary>
		public IndexingEntityListBuilder(UserConnection userConnection) {
			_userConnection = userConnection;
		}

		#endregion

		#region Methods: Private

		/// <summary>
		/// Retrieves the CultureId from the system settings.
		/// </summary>
		/// <returns>The CultureId of the system user or empty if not found.</returns>
		private Guid? GetGlobalSearchIndexationCultureId() {
			return SysSettings.GetValue<Guid?>(_userConnection, "GlobalSearchIndexationLocalization", null);
		}

		/// <summary>
		/// Sets the localization culture for the specified <see cref="EntitySchemaQuery"/> 
		/// using the system settings CultureId.
		/// </summary>
		/// <param name="esq">The <see cref="EntitySchemaQuery"/> to apply the culture.</param>
		private void SetGlobalSearchIndexationCulture(EntitySchemaQuery esq) {
			if (!IndexingCultureId.IsNullOrEmpty()) {
				esq.SetLocalizationCultureId(IndexingCultureId.Value);
				_log.Debug($"CultureId is set to {IndexingCultureId}. Localization culture will be applied to Global Search indexation.");
			}
		}

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Applies and return  entity schema query modifiedOn filter collection.
		/// </summary>
		/// <param name="esq"><see cref="EntitySchemaQuery"/> esq.</param>
		/// <returns><see cref="EntitySchemaQueryFilterCollection"/> entity schema query modifiedOn filter collection.
		/// </returns>
		protected virtual EntitySchemaQueryFilterCollection ApplyModifiedOnFilters(EntitySchemaQuery esq) {
			var entitySchema = esq.RootSchema;
			var esqFilters = new EntitySchemaQueryFilterCollection(esq, LogicalOperationStrict.Or);
			var modifiedOnColumn = entitySchema.ModifiedOnColumn;
			if (modifiedOnColumn != null) {
				esqFilters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Between, modifiedOnColumn.Name,
					_fromSqlDateTimeMacro, _toSqlDateTimeMacro));
			}
			foreach (var column in entitySchema.Columns.Where(x => ModifiedOnLookupFilterEnabled
						&& x.DataValueType.IsLookup && x.ReferenceSchema.ModifiedOnColumn != null)) {
				try {
					if (GetIsIndexedColumn(column, entitySchema)) {
						esqFilters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Between,
							$"{column.Name}.{column.ReferenceSchema.ModifiedOnColumn.Name}", _fromSqlDateTimeMacro,
							_toSqlDateTimeMacro));
					}
				} catch (Exception ex) {
					_log.Error($"Add lookup column {column.Name} ModifiedOn filter. Error: {ex.Message}");
				}
			}
			esq.Filters.Add(esqFilters);
			return esqFilters;
		}

		/// <summary>
		/// Returns default esq for indexation.
		/// </summary>
		/// <param name="entitySchema"><see cref="EntitySchema"/> instance.</param>
		/// <returns><see cref="EntitySchemaQuery"/> instance.</returns>
		protected EntitySchemaQuery GetDefEsq(EntitySchema entitySchema) {
			var esq = new EntitySchemaQuery(entitySchema) { RowCount = GetDefEsqRowCount() };
			EntitySchemaColumnCollection columns = entitySchema.Columns;
			foreach (EntitySchemaColumn column in columns) {
				AddIndexingEsqColumns(entitySchema, column, esq);
			}
			SetGlobalSearchIndexationCulture(esq);
			ApplyUserInfoColumns(entitySchema, esq);
			ApplyEsqFilters(esq);
			return esq;
		}

		/// <summary>
		/// Gets default row count of the esq.
		/// </summary>
		/// <returns>Default row count of the esq.</returns>
		protected virtual int GetDefEsqRowCount() {
			return int.MaxValue;
		}

		/// <summary>
		/// Adds indexing columns to entity schema query.
		/// </summary>
		/// <param name="entitySchema"><see cref="EntitySchema"/> schema.</param>
		/// <param name="column"><see cref="EntitySchemaColumn"/> column.</param>
		/// <param name="esq"><see cref="EntitySchemaQuery"/> esq.</param>
		protected void AddIndexingEsqColumns(EntitySchema entitySchema, EntitySchemaColumn column,
				EntitySchemaQuery esq) {
			if (!GetIsIndexedColumn(column, entitySchema)) {
				return;
			}
			string columnName = GlobalSearchColumnUtils.GetColumnName(column);
			if (string.IsNullOrEmpty(columnName)) {
				return;
			}
			if (!GlobalSearchColumnUtils.GetIsSysImageLookupColumn(column)) {
				string alias = GlobalSearchColumnUtils.GetAlias(column, entitySchema);
				EntitySchemaQueryColumn esqColumn = esq.AddColumn(columnName);
				if (GetIsPrimaryColumn(entitySchema, column)) {
					ApplyPrimaryColumnRule(esqColumn, esq, alias);
				}
				esqColumn.SetForcedQueryColumnValueAlias(GetColumnAliasWrapper(alias));
			}
			AddPrimaryLookupColumn(entitySchema, column, esq);
			AddPrimaryImageLookupColumn(entitySchema, column, esq);
		}

		/// <summary>
		/// When <paramref name="entitySchema"/> is Contact adds related user information columns to <paramref name="esq"/>.
		/// </summary>
		/// <remarks>
		/// Contact search results are filtered by existing user (or existing active user) in multiple cases,
		/// this data will exclude need for additional DB request. 
		/// <see href="https://creatio.atlassian.net/l/cp/AsX6Xdp2"/> as intended usage example.
		/// </remarks>
		/// <param name="entitySchema"><see cref="EntitySchema"/> schema.</param>
		/// <param name="esq"><see cref="EntitySchemaQuery"/> esq.</param>
		protected virtual void ApplyUserInfoColumns(EntitySchema entitySchema, EntitySchemaQuery esq) {
			if (entitySchema.Name != "Contact") {
				return;
			}
			var activeColumn = esq.AddColumn("[SysAdminUnit:Contact:Id].Active");
			activeColumn
				.SetForcedQueryColumnValueAlias($"##Contact_SysAdminUnit_Active##".ToLowerInvariant());
		}

		/// <summary>
		/// Apply order by rule to primary column.
		/// </summary>
		/// <param name="primaryEsqColumn"><see cref="EntitySchemaColumn"/> column.</param>
		/// <param name="esq"><see cref="EntitySchemaQuery"/> esq.</param>
		/// <param name="primaryEsqColumnAlias">primary esq column alias.</param>
		protected virtual void ApplyPrimaryColumnRule(EntitySchemaQueryColumn primaryEsqColumn,
			EntitySchemaQuery esq, string primaryEsqColumnAlias) {
				primaryEsqColumn.OrderByAsc();
		}

		/// <summary>
		/// Gets column is primary.
		/// </summary>
		/// <param name="entitySchema"><see cref="EntitySchema"/> schema.</param>
		/// <param name="column"><see cref="EntitySchemaColumn"/> column.</param>
		/// <returns>True if column is primary.</returns>
		protected bool GetIsPrimaryColumn(EntitySchema entitySchema, EntitySchemaColumn column) {
			return GlobalSearchColumnUtils.IsPrimaryColumn(entitySchema, column);
		}

		/// <summary>
		/// Gets column alias name with wrapper.
		/// </summary>
		/// <param name="columnAlias">Column alias name.</param>
		/// <returns>Column alias name with wrapper.</returns>
		protected string GetColumnAliasWrapper(string columnAlias) {
			return $"{_sqlColumnWrapMacro}{columnAlias}{_sqlColumnWrapMacro}";
		}

		/// <summary>
		/// Gets sql text.
		/// </summary>
		/// <param name="esq"><see cref="EntitySchemaQuery"/>esq.</param>
		/// <returns>Sql text.</returns>
		protected virtual string GetSqlText(EntitySchemaQuery esq) {
			Select select = GetSelectQuery(esq);
			select.BuildParametersAsValue = true;
			string sqlText = select.GetSqlText();
			sqlText = ReplaceTopFetch(sqlText);
			return sqlText;
		}

		/// <summary>
		/// Gets select query from ESQ.
		/// </summary>
		/// <param name="esq"><see cref="EntitySchemaQuery"/>esq.</param>
		/// <returns>Select query from ESQ.</returns>
		protected Select GetSelectQuery(EntitySchemaQuery esq) {
			Select select = esq.GetSelectQuery(_userConnection);
			return select;
		}

		/// <summary>
		/// Replace offset fetch to macros.
		/// </summary>
		/// <param name="sqlText">Text of the select query with offset fetch.</param>
		/// <returns>Sql text with replaced offset top fetch.</returns>
		protected string ReplaceTopFetch(string sqlText) {
			sqlText = sqlText.Replace(Int32.MaxValue.ToString(), _topFetchMacro);
			return sqlText;
		}

		/// <summary>
		/// Prepares entities queries. 
		/// </summary>
		protected abstract void PrepareEntityQueries();

		/// <summary>
		/// Adds filters to <see cref="EntitySchemaQuery"/> instance for concretization of indexable sections.
		/// </summary>
		/// <param name="esq">
		///  <see cref="EntitySchemaQuery"/> instance  containing all sections which will be indexed.
		/// </param>
		protected virtual void ApplyFiltersToEsq(EntitySchemaQuery esq) {}

		/// <summary>
		/// Removes empty entity queries. 
		/// </summary>
		/// <param name="entityQueries">Entity queries. </param>
		protected void RemoveEmptyEsqList(Dictionary<string, EntitySchemaQuery> entityQueries) {
			foreach (var entityQuery in entityQueries.ToArray()) {
				var esq = entityQuery.Value;
				if (esq.Columns.GroupBy(column => column.Path).Count() <= 1) {
					entityQueries.Remove(entityQuery.Key);
				}
			}
		}

		/// <summary>
		/// Adds primary lookup column to entity schema query.
		/// </summary>
		/// <param name="entitySchema"><see cref="EntitySchema"/>entitySchema.</param>
		/// <param name="column"><see cref="EntitySchemaColumn"/>column.</param>
		/// <param name="esq"><see cref="EntitySchemaQuery"/>esq.</param>
		protected virtual void AddPrimaryLookupColumn(EntitySchema entitySchema, EntitySchemaColumn column,
				EntitySchemaQuery esq) {
			string primaryLookupColumn =
				column.DataValueType.IsLookup ? GlobalSearchColumnUtils.GetPrimaryLookupColumn(column) : null;
			if (string.IsNullOrEmpty(primaryLookupColumn)) {
				return;
			}
			var primaryLookupColumnAlias = GlobalSearchColumnUtils.GetPrimaryColumnAlias(column, entitySchema.Name);
			esq.AddColumn(primaryLookupColumn).SetForcedQueryColumnValueAlias(
				GetColumnAliasWrapper(primaryLookupColumnAlias));
		}

		/// <summary>
		/// Adds primary image lookup column to entity schema query.
		/// </summary>
		/// <param name="entitySchema"><see cref="EntitySchema"/>entitySchema.</param>
		/// <param name="column"><see cref="EntitySchemaColumn"/>column.</param>
		/// <param name="esq"><see cref="EntitySchemaQuery"/>esq.</param>
		protected virtual void AddPrimaryImageLookupColumn(EntitySchema entitySchema, EntitySchemaColumn column, EntitySchemaQuery esq) {
			string primaryImageLookupColumn = column.DataValueType.IsLookup ? GlobalSearchColumnUtils.GetImageLookupColumn(column) : null;
			if (string.IsNullOrEmpty(primaryImageLookupColumn)) {
				return;
			}
			var primaryImageLookupColumnAlias = GlobalSearchColumnUtils.GetPrimaryImageColumnAlias(column, entitySchema.Name);
			esq.AddColumn(primaryImageLookupColumn).SetForcedQueryColumnValueAlias(GetColumnAliasWrapper(primaryImageLookupColumnAlias));
		}

		/// <summary>
		/// Check column is a indexed.
		/// </summary>
		/// <param name="column"><see cref="EntitySchemaColumn"/>Checking column.</param>
		/// <param name="entitySchema"><see cref="EntitySchema"/>entitySchema.</param>
		/// <returns>True if column is indexed.</returns>
		protected virtual bool GetIsIndexedColumn(EntitySchemaColumn column, EntitySchema entitySchema) {
			if (IgnoredEntityList.GetIsIgnoredColumn(entitySchema, column)) {
				return false;
			}
			bool isPrimary = GetIsPrimaryColumn(entitySchema, column);
			bool isIndexedColumnType = GlobalSearchColumnUtils.IsIndexedColumnType(column);
			return isIndexedColumnType || isPrimary;
		}

		/// <summary>
		/// Appends searching entity options.
		/// </summary>
		/// <param name="entityQuery">Prepared entity query key value pair.</param>
		protected void AppendIndexingEntity(KeyValuePair<string, EntitySchemaQuery> entityQuery) {
			var indexingEntity = GetIndexingEntity(entityQuery);
			IndexingEntities.Add(indexingEntity);
		}

		/// <summary>
		/// Gets indexing entity with properties.
		/// </summary>
		/// <param name="entityQuery">Prepared entity query key value pair.</param>
		/// <returns>Indexing entity with properties.</returns>
		protected virtual IndexingEntityConfig GetIndexingEntity(KeyValuePair<string, EntitySchemaQuery> entityQuery) {
			EntitySchemaQuery esq = entityQuery.Value;
			EntitySchema schema = esq.RootSchema;
			string entityNameWithSuffix = entityQuery.Key;
			var sqlText = GetSqlText(esq);
			var protectedDataConfig = GetProtectedDataConfig(schema);
			var indexingEntity = new IndexingEntityConfig {
				Key = entityNameWithSuffix,
				EntityName = schema.Name,
				ParentEntityName = GetParentSchemaName(schema),
				ProtectedDataConfig = protectedDataConfig,
				SqlText = sqlText,
				IndexingType = GetIndexingType(schema),
				TrackingColumnName = GetTrackingColumnName(schema)
			};
			return indexingEntity;
		}

		/// <summary>
		/// Gets parent schema.
		/// </summary>
		/// <param name="schema"><see cref="EntitySchema"/>schema.</param>
		/// <returns>Parent schema if schema is a detail.</returns>
		protected abstract string GetParentSchemaName(EntitySchema schema);

		/// <summary>
		/// Gets searching indexing type.
		/// </summary>
		/// <param name="schema"><see cref="EntitySchema"/>schema.</param>
		/// <returns>Searching indexing type</returns>
		protected virtual IndexingType GetIndexingType(EntitySchema schema) {
			return IndexingTypes.GetValueOrDefault(schema.Name, DefaultIndexingType);
		}

		/// <summary>
		/// Gets tracking column name of the modified on.
		/// </summary>
		/// <param name="schema"><see cref="EntitySchema"/>schema.</param>
		/// <returns>Tracking column name.</returns>
		protected virtual string GetTrackingColumnName(EntitySchema schema) {
			var modifiedOnColumn = schema.ModifiedOnColumn;
			return modifiedOnColumn == null ? null : modifiedOnColumn.Name;
		}

		/// <summary>
		/// Apply delegates filters to esq.
		/// </summary>
		/// <param name="esq"><see cref="EntitySchemaQuery"/>esq.</param>
		protected virtual void ApplyEsqFilters(EntitySchemaQuery esq) {
			foreach (var action in EsqFuncFilterList) {
				action(esq);
			}
		}

		/// <summary>
		/// Finds reference file schema by section entity schema.
		/// </summary>
		/// <param name="entitySchema"><see cref="EntitySchema"/> section entity schema.</param>
		/// <returns><see cref="EntitySchema"/>File entity schema.</returns>
		protected virtual EntitySchema FindReferenceFileSchema(EntitySchema entitySchema) {
			var entitySchemaName = entitySchema.Name;
			var fileSchemaManagerItem = _userConnection.EntitySchemaManager.FindItem(
				es => es.Name == $"{entitySchemaName}File" || es.Name == $"File{entitySchemaName}");
			return fileSchemaManagerItem?.Instance;
		}

		/// <summary>
		/// Apply next primary column filter.
		/// </summary>
		/// <param name="esq"><see cref="EntitySchemaQuery"/>esq.</param>
		/// <param name="columnName">Filtered column name.</param>
		protected virtual void ApplyNextPrimaryColumnFilter(EntitySchemaQuery esq, string columnName) {
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Greater, columnName, Guid.Empty));
		}

		/// <summary>
		/// Gets config for protected data.
		/// </summary>
		/// <param name="entitySchema"><see cref="EntitySchema"/>schema.</param>
		/// <returns>Config for protected data.</returns>
		protected virtual ProtectedDataConfig GetProtectedDataConfig(EntitySchema entitySchema) {
			ProtectedDataConfig config = new ProtectedDataConfig();
			foreach (var column in entitySchema.Columns) {
				if (!GetIsIndexedColumn(column, entitySchema)) {
					continue;
				}
				var columnIsSensitive = column.IsSensitiveData;
				if (!GlobalSearchColumnUtils.GetIsSysImageLookupColumn(column) && columnIsSensitive) {
					var alias = GlobalSearchColumnUtils.GetAlias(column, entitySchema);
					config.AddColumnConfig(alias);
				}
				if (column.DataValueType.IsLookup) {
					var refSchema = column.ReferenceSchema;
					if (refSchema.PrimaryColumn?.IsSensitiveData == true || columnIsSensitive) {
						var primaryAlias = GlobalSearchColumnUtils.GetPrimaryColumnAlias(column, entitySchema.Name);
						config.AddColumnConfig(primaryAlias);
					}
					if (refSchema.PrimaryDisplayColumn?.IsSensitiveData == true || columnIsSensitive) {
						var primaryDisplayAlias = GlobalSearchColumnUtils.GetAlias(column, entitySchema);
						config.AddColumnConfig(primaryDisplayAlias);
					}
					if (refSchema.PrimaryImageColumn?.IsSensitiveData == true || columnIsSensitive) {
						var imageAlias = GlobalSearchColumnUtils.GetPrimaryImageColumnAlias(column, entitySchema.Name);
						config.AddColumnConfig(imageAlias);
					}
				}
			}
			return config;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Adds force indexing types.
		/// </summary>
		/// <param name="schemas">List of the schema name.</param>
		/// <param name="indexingType">Indexing type.</param>
		public void SetIndexingType(List<string> schemas, IndexingType indexingType) {
			schemas.Distinct().ForEach(schema => IndexingTypes.Add(schema, indexingType));
		}

		/// <summary>
		/// Adds filter actions for entity schema query.
		/// </summary>
		/// <param name="action">EntitySchemaQuery action.</param>
		public void AddEsqFuncFilter(Action<EntitySchemaQuery> action) {
			EsqFuncFilterList.Add(action);
		}

		/// <summary>
		/// Gets need indexing entities list.
		/// </summary>
		/// <returns>List of the need indexing entities.</returns>
		public List<IndexingEntityConfig> Build() {
			PrepareEntityQueries();
			EntityQueries.ForEach(AppendIndexingEntity);
			return IndexingEntities;
		}

		#endregion

	}

	#endregion

}

