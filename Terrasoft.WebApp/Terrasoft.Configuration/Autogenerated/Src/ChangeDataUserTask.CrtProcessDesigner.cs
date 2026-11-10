namespace Terrasoft.Core.Process.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Runtime.ExceptionServices;
	using System.Text;
	using Creatio.FeatureToggling;
	using global::Common.Logging;
	using Terrasoft.Common;
	using Terrasoft.Configuration;
	using Terrasoft.Core;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Process;
	using Terrasoft.Core.UsageContext;
	using Terrasoft.UI.WebControls.Controls;

	#region Class: ChangeDataUserTask

	/// <exclude/>
	public partial class ChangeDataUserTask
	{

		#region Class: EnableForeignKeyExceptionDetails

		/// <summary>
		/// Feature that enables detailed information for foreign key exceptions during entity updates in processes.
		/// </summary>
		public class EnableForeignKeyExceptionDetails : FeatureMetadata
		{

			#region Constructors: Public

			/// <summary>
			/// Initializes a new instance of the <see cref="EnableForeignKeyExceptionDetails"/>.
			/// </summary>
			public EnableForeignKeyExceptionDetails() {
				IsEnabled = true;
			}

			#endregion

		}

		#endregion

		#region Fields: Private

		private ILog _traceLog;

		#endregion

		#region Properties: Private

		private Exception InnerException {
			get;
			set;
		}

		#endregion

		#region Properties: Public

		private IDBExceptionHandler _dbExceptionHandler;

		/// <summary>
		/// Gets or sets the database exception handler used to process and enrich exceptions during entity updates.
		/// If not set, a new instance of <see cref="DBExceptionHandler"/> is returned by default.
		/// </summary>
		public IDBExceptionHandler DBExceptionHandler {
			get => _dbExceptionHandler ?? new DBExceptionHandler();
			set => _dbExceptionHandler = value;
		}

		#endregion

		#region Methods: Private

		private static string GetDebugInfo(Entity entity) {
			var sb = new StringBuilder();
			try {
				sb.Append(entity.SchemaName);
				sb.Append($" ({entity.Schema.PrimaryColumn.Name}: [{entity.PrimaryColumnValue}])");
			} catch (Exception) { }
			return entity.ToString();
		}

		private static void ThrowExceptionIfEmptyFilters(EntitySchemaQueryFilterCollection filters) {
			var message = new LocalizableString("Terrasoft.Core",
				"ProcessSchemaChangeDataUserTask.Exception.ChangeDataWithEmptyFilter");
			ProcessUserTaskUtilities.ThrowExceptionIfEmptyFilters(filters, message);
		}

		private static EntitySchemaQuery GetEntitySchemaQuery(EntitySchemaManager entitySchemaManager,
				EntitySchema entitySchema, bool useUserPermissions) {
			return new EntitySchemaQuery(entitySchemaManager, entitySchema.Name) {
				UseAdminRights = useUserPermissions,
				IgnoreDisplayValues = GlobalAppSettings.FeatureIgnoreDisplayValuesInDataUserTasks
			};
		}

		private static bool GetShouldCatchUpdatingException(Exception exception) {
			return !(exception is RecursionDepthLimitExceededException);
		}

		private static string GetSqlTextWithParameters(Guid uId, Entity entity, string message) {
			Update updateQuery = null;
			try {
				updateQuery = entity.CreateUpdate();
				updateQuery.BuildParametersAsValue = true;
				string sqlText = updateQuery.GetSqlText();
				return $"{uId} {message}{Environment.NewLine}{sqlText}";
			} finally {
				if (updateQuery != null) {
					updateQuery.BuildParametersAsValue = false;
					updateQuery.ResetCachedSqlText();
				}
			}
		}

		private void TraceLog(Func<Guid, string> message) {
			if (_traceLog.IsTraceEnabled) {
				_traceLog.Trace(message(UId));
			}
		}

		private void SetupTraceLogger() {
			string name = nameof(ChangeDataUserTask);
			try {
				name += ":" + Owner?.Schema?.Name;
			} catch (Exception e) {
				Log.Warn(e);
			}
			_traceLog = LogManager.GetLogger(name);
		}

		private string GetSqlTextWithParameters(EntitySchemaQuery esq, Guid uId) {
			Select select = null;
			try {
				select = esq.GetSelectQuery(UserConnection);
				select.BuildParametersAsValue = true;
				string query = select.GetSqlText();
				return $"{uId} Sql-query: {query}";
			} finally {
				if (select != null) {
					select.BuildParametersAsValue = false;
					select.ResetCachedSqlText();
				}
			}
		}

		private void UpdateEntities(EntitySchema entitySchema, bool useUserPermissions) {
			EntitySchemaQuery esq = GetEntitySchemaQuery(UserConnection.EntitySchemaManager, entitySchema,
				useUserPermissions);
			esq.AddAllSchemaColumns();
			if (IsMatchConditions) {
				ProcessUserTaskUtilities.SpecifyESQFilters(UserConnection, this, entitySchema, esq, DataSourceFilters);
				EntitySchemaQueryFilterCollection filters = esq.Filters;
				ThrowExceptionIfEmptyFilters(filters);
			}
			EntityCollection entityCollection = esq.GetEntityCollection(UserConnection);
			TraceLog(uId => GetSqlTextWithParameters(esq, uId));
			UpdateEntityCollection(entityCollection, entitySchema, useUserPermissions);
		}

		private void UpdateEntity(EntitySchema entitySchema, Entity entity, bool useUserPermissions) {
			try {
				foreach (KeyValuePair<string, object> columnValue in RecordColumnValues.Values) {
					EntitySchemaColumn column = entitySchema.GetSchemaColumnByMetaPath(columnValue.Key);
					object value = columnValue.Value;
					if (ProcessUserTaskUtilities.GetIsEmptyLookupOrDateTimeValue(value, column.DataValueType)) {
						value = null;
					}
					entity.SetColumnValue(column, value);
				}
				entity.UseAdminRights = useUserPermissions;
				TraceLog(uId => GetSqlTextWithParameters(uId, entity, "Update query before saving:"));
				entity.Save(false);
				TraceLog(uId => GetSqlTextWithParameters(uId, entity, "Update query after saving:"));
			} catch (Exception e) when(GetShouldCatchUpdatingException(e)) {
				string debugInfo = GetDebugInfo(entity);
				Log.Error($"An error occurred during process element {this} when updating an entity {debugInfo}", e);
				if (IgnoreErrors) {
					return;
				}
				if (InnerException == null) {
					InnerException = e;
				}
				if (Features.GetIsEnabled<EnableForeignKeyExceptionDetails>() &&
						DBExceptionHandler.GetIsForeignKeyException(e)) {
					InnerException = DBExceptionHandler.EnrichExceptionWithForeignKeyInfo(InnerException,
						UserConnection, entitySchema, entity);
				}
			}
		}

		private void UpdateEntitiesByChunks(EntitySchema entitySchema, bool useUserPermissions) {
			EntitySchemaManager entitySchemaManager = UserConnection.EntitySchemaManager;
			EntitySchemaQuery esq = GetEntitySchemaQuery(entitySchemaManager, entitySchema, useUserPermissions);
			esq.PrimaryQueryColumn.IsAlwaysSelect = true;
			if (IsMatchConditions) {
				ProcessUserTaskUtilities.SpecifyESQFilters(UserConnection, this, entitySchema, esq, 
					DataSourceFilters);
				EntitySchemaQueryFilterCollection filters = esq.Filters;
				ThrowExceptionIfEmptyFilters(filters);
			}
			TraceLog(uId => GetSqlTextWithParameters(esq, uId));
			IList<object> entityIds = GetEntityIds(esq);
			UpdateEntities(entitySchemaManager, entitySchema, entityIds, useUserPermissions);
		}

		private IList<object> GetEntityIds(EntitySchemaQuery esq) {
			var entityIds = new List<object>();
			esq.ChunkSize = 10_000;
			foreach (EntityCollection collection in esq.GetEntityCollectionIterator(UserConnection)) {
				foreach (Entity entity in collection) {
					entityIds.Add(entity.PrimaryColumnValue);
				}
			}
			return entityIds;
		}

		private void UpdateEntities(EntitySchemaManager entitySchemaManager, EntitySchema entitySchema,
				IList<object> entityIds, bool useUserPermissions) {
			using (UsageContext context = CreateUsageContext()) {
				EntitySchemaQuery esq = GetEntitySchemaQuery(entitySchemaManager, entitySchema, useUserPermissions);
				esq.SetUsageContext(context, CrudOperationType.Update);
				esq.AddAllSchemaColumns();
				string primaryColumnName = entitySchema.PrimaryColumn.Name;
				EntitySchemaQueryFilterCollection filters = esq.Filters;
				IEnumerable<IEnumerable<object>> chunks = entityIds.SplitOnChunks(100);
				foreach (IEnumerable<object> chunk in chunks) {
					IEntitySchemaQueryFilterItem filter =
						esq.CreateFilterWithParameters(FilterComparisonType.Equal, primaryColumnName, chunk);
					filters.Add(filter);
					TraceLog(uId => GetSqlTextWithParameters(esq, uId));
					EntityCollection entities = esq.GetEntityCollection(UserConnection);
					UpdateEntityCollection(entities, entitySchema, useUserPermissions);
					esq.ResetSelectQuery();
					filters.Clear();
				}
			}
		}

		private void UpdateEntityCollection(EntityCollection entityCollection, EntitySchema entitySchema,
				bool useUserPermissions) {
			foreach (Entity entity in entityCollection) {
				UpdateEntity(entitySchema, entity, useUserPermissions);
			}
		}

		#endregion

		#region Methods: Protected

		/// <inheritdoc />
		protected override bool InternalExecute(ProcessExecutingContext context) {
			SetupTraceLogger();
			if (EntitySchemaUId.IsEmpty()) {
				TraceLog(uId => $"{uId} Exit and Stop executing: entity schema UId is empty");
				return false;
			}
			EntitySchema entitySchema = UserConnection.EntitySchemaManager.GetInstanceByUId(EntitySchemaUId);
			if (RecordColumnValues.Values.Count == 0) {
				TraceLog(uId => $"{uId} Exit and Continue executing: RecordColumnValues is empty");
				return true;
			}
			if (GlobalAppSettings.FeatureUseEntityCollectionChunksInProcessUserTask) {
				TraceLog(uId => $"{uId} FeatureUseEntityCollectionChunksInProcessUserTask: is enabled");
				UpdateEntitiesByChunks(entitySchema, context.UseUserPermissions);
			} else {
				TraceLog(uId => $"{uId} FeatureUseEntityCollectionChunksInProcessUserTask: is disabled");
				UpdateEntities(entitySchema, context.UseUserPermissions);
			}
			if (InnerException != null) {
				ExceptionDispatchInfo.Capture(InnerException).Throw();
			}
			return true;
		}

		#endregion

		#region Methods: Public

		public virtual void UpdateFiltersRightExprMetaDataByParameterValue(Process process,
				DataSourceFilterCollection filters) {
			foreach (IDataSourceFilterItem filter in filters) {
				if (filter is DataSourceFilterCollection dataSourceFilterCollection) {
					UpdateFiltersRightExprMetaDataByParameterValue(process, dataSourceFilterCollection);
					continue;
				}
				var dataSourceFilter = (DataSourceFilter)filter;
				DataSourceFilterExpression rightExpression = dataSourceFilter.RightExpression;
				if (rightExpression?.Type != DataSourceFilterExpressionType.Custom) {
					continue;
				}
				rightExpression.Type = DataSourceFilterExpressionType.Parameter;
				if (rightExpression.Parameters.Count == 2) {
					DataSourceFilterExpressionParametersCollection parameters = rightExpression.Parameters;
					object metaPath = parameters[1].Value;
					parameters[1].Value = process.GetParameterValueByMetaPath((string)metaPath);
					parameters.RemoveAt(0);
				}
				if (dataSourceFilter.SubFilters?.Count > 0) {
					UpdateFiltersRightExprMetaDataByParameterValue(process, dataSourceFilter.SubFilters);
				}
			}
		}

		[Obsolete("8.1.5 | Method is not in use and will be removed in upcoming releases.")]
		public virtual void UpdateEntityCollection(EntityCollection entityCollection, EntitySchema entitySchema) {
			UpdateEntityCollection(entityCollection, entitySchema, false);
		}

		#endregion

	}

	#endregion

}
