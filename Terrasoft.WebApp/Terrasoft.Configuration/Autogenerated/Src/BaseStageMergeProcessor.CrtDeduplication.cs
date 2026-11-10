namespace Terrasoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Terrasoft.Core;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.Entities;

	/// <summary>
	/// Base merge detail preprocessor. 
	/// </summary>
	public abstract class BaseStageMergeProcessor
	{
		/// <summary>
		/// Process merge actions.
		/// </summary>
		/// <param name="duplicates">Duplicates collection.</param>
		/// <param name="goldenRecord">Gold record Id</param>
		/// <param name="dbExecutor">DBExecutor instance.</param>
		/// <param name="entitySchemaName">Parent object schema name.</param>
		/// <param name="stageParams">Stage history object binding column parameters.</param>
		/// <param name="stageSchemaName">Stage history object schema name.</param>
		public virtual void Process(List<Guid> duplicates, Guid goldenRecord, DBExecutor dbExecutor, string entitySchemaName,
			KeyValuePair<string, string> stageParams, string stageSchemaName) {
			var allDuplicates = new List<Guid> {
				goldenRecord
			};
			allDuplicates.AddRange(duplicates);
			var stageMergeUtilities = new StageMergeUtilities(dbExecutor.UserConnection);
			EntityCollection stageHistoryCollection = stageMergeUtilities.GetAllStageHistoryRecords(stageSchemaName,
				entitySchemaName, allDuplicates, stageParams);
			if (stageHistoryCollection.Any()) {
				stageMergeUtilities.MergeStages(stageHistoryCollection, goldenRecord, entitySchemaName, dbExecutor, stageParams);
			}
		}
	}
}
