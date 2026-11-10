namespace Terrasoft.Configuration.SearchFilterQuery
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Terrasoft.Core;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Factories;
	using Terrasoft.Common;
	using CoreSysSettings = Core.Configuration.SysSettings;

	#region Interface: ISearchFilterQueryAnalyzer

	/// <summary>
	/// Interface of search filter query analyzer.
	/// </summary>
	public interface ISearchFilterQueryAnalyzer
	{
		/// <summary>
		/// Returns true if query with current params is difficult for current user.
		/// </summary>
		/// <param name="schemaName">Entity schema name.</param>
		/// <param name="columns">Columns array.</param>
		/// <returns>.</returns>
		bool GetIsNeedOptimization(string schemaName, IEnumerable<string> columns);
	}

	#endregion

	#region Class: SearchFilterQueryAnalizer

	/// <summary>
	/// Search filter query analyzer.
	/// </summary>
	[DefaultBinding(typeof(ISearchFilterQueryAnalyzer), Name = "SearchFilterQueryAnalyzer")]
	public class SearchFilterQueryAnalyzer : ISearchFilterQueryAnalyzer
	{

		#region Constants: Private

		private const int _recordCountLimit = 1000000;
		private const int _recordMinCountLimit = 100000;
		private const int _recordRightsCountLimit = 3000000;
		private const int _columnsCountLimit = 15;
		private const int _sysAdminUnitRolesLimit = 5;
		private const bool _isNeedTypeColumnLimit = true;
		private const string _searchFilterQueryAnalyzerCacheKey = "SearchFilterQueryAnalizer_SysAdminUnitInRoleCount";

		#endregion

		#region Fields: Private

		private IEntitySchemaDbInfoProvider _dbInfoProvider;

		#endregion

		#region Constructors: Public

		public SearchFilterQueryAnalyzer(UserConnection userConnection) {
			this.UserConnection = userConnection;
		}

		#endregion

		#region Properties: Private

		private UserConnection UserConnection { get; set; }

		private IEntitySchemaDbInfoProvider DBInfoProvider =>
			_dbInfoProvider ?? (_dbInfoProvider = ClassFactory.Get<IEntitySchemaDbInfoProvider>());

		private bool IsColumnOfLargeTextDataValueTypes(Guid dataValueTypeUId) =>
			dataValueTypeUId.Equals(DataValueType.MaxSizeTextDataValueTypeUId) ||
			dataValueTypeUId.Equals(DataValueType.RichTextDataValueTypeUId);

		private int RecordCountLimit => CoreSysSettings.GetValue(UserConnection,
				"SearchFilterRecordCountLimit", _recordCountLimit);
		private int RecordMinCountLimit => CoreSysSettings.GetValue(UserConnection,
				"SearchFilterRecordMinCountLimit", _recordMinCountLimit);

		private int RecordRightsCountLimit => CoreSysSettings.GetValue(UserConnection,
				"SearchFilterRecordRightsCountLimit", _recordRightsCountLimit);

		private int ColumnsCountLimit => CoreSysSettings.GetValue(UserConnection,
				"SearchFilterColumnsCountLimit", _columnsCountLimit);

		private int SysAdminUnitRolesLimit => CoreSysSettings.GetValue(UserConnection,
				"SearchFilterSysAdminUnitRolesLimit", _sysAdminUnitRolesLimit);

		private bool IsNeedTypeColumnLimit => CoreSysSettings.GetValue(UserConnection,
				"SearchFilterIsNeedTypeColumnLimit", _isNeedTypeColumnLimit);

		private bool IsDebugMode => CoreSysSettings.GetValue(UserConnection,
			"IsDebug", false);

		#endregion

		#region Methods: Private

		private bool GetIsNeedOptimizationQuery(string schemaName, IEnumerable<string> columns) {
			ClearDbInfoProviderCacheIfNeed();
			var entitySchemaRowCount = GetEntitySchemaRowCount(schemaName);
			if (entitySchemaRowCount <= RecordMinCountLimit) {
				return false;
			}
			return entitySchemaRowCount > RecordCountLimit ||
				CheckRecordRightsCountLimits(schemaName) ||
				CheckColumns(schemaName, columns);
		}

		private bool CheckColumns(string schemaName, IEnumerable<string> columns) {
			return columns.Count() > ColumnsCountLimit || HasTypeColumns(schemaName, columns);
		}

		private bool CheckRecordRightsCountLimits(string schemaName) {
			if (!HasAdministratedByRecords(schemaName)) {
				return false;
			}
			var rightsTableName = $"Sys{schemaName}Right";
			var rightsRowCount = GetEntitySchemaRowCount(rightsTableName);
			if (rightsRowCount <= RecordRightsCountLimit) {
				return false;
			}
			var rolesCount = GetSysAdminUnitInRoleCount();
			return rolesCount > SysAdminUnitRolesLimit;
		}

		private int GetEntitySchemaRowCount(string schemaName) {
			return DBInfoProvider.GetSchemaRowCount(schemaName);
		}

		private bool HasAdministratedByRecords(string schemaName) {
			return UserConnection.DBSecurityEngine.GetIsEntitySchemaAdministratedByRecords(schemaName);
		}

		private bool HasTypeColumns(string schemaName, IEnumerable<string> columns) {
			if (!IsNeedTypeColumnLimit) {
				return false;
			}
			EntitySchema entitySchema =
						UserConnection.EntitySchemaManager.GetInstanceByName(schemaName);
			return columns.Select(column => entitySchema.FindSchemaColumnByPath(column))
				.Any(entityColumn => entityColumn != null &&
				IsColumnOfLargeTextDataValueTypes(entityColumn.DataValueTypeUId));
		}

		private int GetSysAdminUnitInRoleCount() {
			var sysAdminUnitId = UserConnection.CurrentUser.Id;
			var dataCache = GetSearchFilterAnalyzerDataFromCache();
			return dataCache.TryGetValue(sysAdminUnitId, out int result) ? 
				result: 
				GetSysAdminUnitInRoleCountFromDb(sysAdminUnitId);
		}

		private int GetSysAdminUnitInRoleCountFromDb(Guid sysAdminUnitId) {
			Select select = new Select(UserConnection).Distinct()
				.Column(Func.Count("SysAdminUnitRoleId"))
				.From("SysAdminUnitInRole")
				.Where("SysAdminUnitId").IsEqual(Column.Parameter(sysAdminUnitId))
				.And("SysAdminUnitRoleId").IsNotEqual(Column.Parameter(sysAdminUnitId)) as Select;
			var rolesCount = select.ExecuteScalar<int>();
			SetSearchFilterAnalyzerDataToCache(sysAdminUnitId, rolesCount);
			return rolesCount;
		}

		private void SetSearchFilterAnalyzerDataToCache(Guid sysAdminUnitId, int rolesCount) {
			var cache = GetSearchFilterAnalyzerDataFromCache();
			cache[sysAdminUnitId] = rolesCount;
			UserConnection.SessionCache[_searchFilterQueryAnalyzerCacheKey] = cache;
		}

		private IDictionary<Guid, int> GetSearchFilterAnalyzerDataFromCache() {
			return (IDictionary<Guid, int>)UserConnection.SessionCache[_searchFilterQueryAnalyzerCacheKey] ??
				new Dictionary<Guid, int>();
		}

		private void ClearDbInfoProviderCacheIfNeed() {
			if (IsDebugMode) {
				DBInfoProvider.ClearCache();
			}
		}

		#endregion

		#region Methods: Public

		///<inheritdoc />
		public bool GetIsNeedOptimization(string schemaName, IEnumerable<string> columns) {
			schemaName.CheckArgumentNullOrEmpty(nameof(schemaName));
			columns.CheckArgumentNullOrEmpty(nameof(columns));
			if (columns.Count() <= 1) {
				return false;
			}
			return GetIsNeedOptimizationQuery(schemaName, columns);
		}

		#endregion

	}

	#endregion

}
