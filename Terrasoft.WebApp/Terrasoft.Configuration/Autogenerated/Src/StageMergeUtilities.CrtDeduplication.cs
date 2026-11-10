 namespace Terrasoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using global::Common.Logging;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.Entities;

	#region Class: StageMergeUtilities

	/// <summary>
	/// Stage history merge utilities.
	/// </summary>
	public class StageMergeUtilities
	{

		#region Fields: Protected

		protected readonly UserConnection UserConnection;

		#endregion
		
		#region Consts: Private
		
		private static readonly ILog _log = LogManager.GetLogger("Deduplication");
		
		#endregion
		
		#region Methods: Private
		
		private Update GetStageRecordUpdate(string tableName, string masterColumnName, Guid goldenRecordId,
			Guid primaryColumnValue, bool isHistorical, bool isDueDateEmpty) {
			var update = new Update(UserConnection, tableName)
				.Set(masterColumnName, Column.Parameter(goldenRecordId));
			if (isHistorical) {
				update.Set("Historical", Column.Parameter(true));
			}
			if (isDueDateEmpty) {
				update.Set("DueDate",Column.Parameter(DateTime.UtcNow));
			}
			update.Where("Id").IsEqual(Column.Parameter(primaryColumnValue));
			return update;
		}
		
		#endregion
		
		#region Constructors: Public

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="userConnection">Instance of <see cref="Core.UserConnection"/></param>
		public StageMergeUtilities(UserConnection userConnection) {
			UserConnection = userConnection;
		}

		#endregion
		
		#region Methods: Public

		/// <summary>
		/// Get collection of Stage entities for merge records.
		/// </summary>
		/// <param name="schemaName">Merge entities schema name.</param>
		/// <param name="masterSchemaName">Master entity schema name.</param>
		/// <param name="duplicates">Collection of duplicates entities.</param>
		/// <param name="stageColumnParams">Column parameters for stage object.</param>
		/// <returns>Entity collection.</returns>
		public EntityCollection GetAllStageHistoryRecords(string schemaName, string masterSchemaName, 
			List<Guid> duplicates, KeyValuePair<string, string> stageColumnParams) {
			EntitySchema schema = UserConnection.EntitySchemaManager.GetInstanceByName(schemaName);
			if (stageColumnParams.Key.IsNullOrEmpty() || stageColumnParams.Value.IsNullOrEmpty()) {
				return new EntityCollection(UserConnection, schemaName);
			}
			var esq = new EntitySchemaQuery(schema);
			esq.AddAllSchemaColumns();
			esq.AddColumn(stageColumnParams.Key.Replace("_", "."));
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal,
				masterSchemaName, duplicates.Cast<object>()));
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal,
				stageColumnParams.Value, true));
			EntityCollection entityCollection = esq.GetEntityCollection(UserConnection);
			entityCollection.Order(stageColumnParams.Key, OrderDirection.Ascending);
			return entityCollection;
		}

		/// <summary>
		/// Merge collection of Stage entities by golden entity.
		/// </summary>
		/// <param name="entityCollection">Collection of Stage entities.</param>
		/// <param name="goldenRecordId">Golden entity record identifier.</param>
		/// <param name="masterSchemaName">Master schema name.</param>
		/// <param name="dbExecutor">DBExecutor instance.</param>
		public void MergeStages(EntityCollection entityCollection, Guid goldenRecordId, string masterSchemaName,
			DBExecutor dbExecutor, KeyValuePair<string, string> stageParams) {
			var masterColumnName = masterSchemaName + "Id";
			Entity actualStage = entityCollection
				.OrderByDescending(x => x.GetColumnValue(stageParams.Key))
				.FirstOrDefault(x => x.GetColumnValue("DueDate") == null
					&& x.GetTypedColumnValue<bool>("Historical") == false
					&& x.GetTypedColumnValue<Guid>(masterColumnName) == goldenRecordId);
			if (actualStage == null) {
				return;
			}
			string tableName = entityCollection.Schema.Name;
			Entity previousStageEntity = null;
			bool foundCurrentStage = false;
			bool isHistorical = false;
			bool isDueDateEmpty = false;
			foreach (var entity in entityCollection) {
				if (previousStageEntity == null || previousStageEntity.Equals(actualStage)) {
					previousStageEntity = entity;
					continue;
				}
				isDueDateEmpty = previousStageEntity?.GetColumnValue("DueDate") == null;
				isHistorical = foundCurrentStage ||
					previousStageEntity.GetTypedColumnValue<Guid>(masterColumnName) != goldenRecordId &&
					entityCollection.FirstOrDefault(x => x.GetTypedColumnValue<int>(stageParams.Key) ==
						previousStageEntity.GetTypedColumnValue<int>(stageParams.Key) &&
						x.GetTypedColumnValue<Guid>(masterColumnName) == goldenRecordId) != null;
				var update = GetStageRecordUpdate(tableName, masterColumnName, goldenRecordId,
					previousStageEntity.PrimaryColumnValue, isHistorical, isDueDateEmpty);
				try {
					update.Execute(dbExecutor);
				} catch(Exception e) {
					_log.Error($"Failed MergeStages. tableName: {tableName}, record Id: {previousStageEntity?.PrimaryColumnValue}");
					throw e;
				}
				if (entity.Equals(actualStage)) {
					foundCurrentStage = true;
				}
				previousStageEntity = entity;
			}
			if (!previousStageEntity.Equals(actualStage)) {
				var update = GetStageRecordUpdate(tableName, masterColumnName, goldenRecordId,
					previousStageEntity.PrimaryColumnValue, true, previousStageEntity.GetColumnValue("DueDate") == null);
				try {
					update.Execute(dbExecutor);
				} catch(Exception e) {
					_log.Error($"Failed MergeStages. tableName: {tableName}, record Id: {previousStageEntity?.PrimaryColumnValue}");
					throw e;
				}
			}
		}

		#endregion

	}

	#endregion

}

