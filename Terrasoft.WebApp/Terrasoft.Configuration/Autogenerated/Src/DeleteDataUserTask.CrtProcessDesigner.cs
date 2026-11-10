namespace Terrasoft.Core.Process.Configuration
{
	using System;
	using System.Collections.Generic;
	using Creatio.FeatureToggling;
	using global::Common.Logging;
	using Terrasoft.Common;
	using Terrasoft.Configuration;
	using Terrasoft.Core;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Factories;
	using Terrasoft.Core.Process;
	using Terrasoft.Core.UsageContext;

	#region Class: DeleteDataUserTask

	/// <exclude/>
	public partial class DeleteDataUserTask
	{

		#region Class: UseSpecificSchemaLogging

		/// <summary>
		/// Represents a feature flag that controls whether schema-specific logger names
		/// should be used for trace logging in delete data operations.
		/// </summary>
		public class UseSpecificSchemaLogging : FeatureMetadata
		{

			#region Constructors: Public

			/// <summary>
			/// Initializes a new instance of the <see cref="UseSpecificSchemaLogging"/> class.
			/// The feature is enabled by default.
			/// </summary>
			public UseSpecificSchemaLogging() {
				IsEnabled = true;
			}

			#endregion

		}

		#endregion

		#region Fields: Private

		private ILog _traceLog;

		#endregion

		#region Methods: Private

		private static void ThrowExceptionIfEmptyFilters(EntitySchemaQueryFilterCollection filters) {
			var message = new LocalizableString("Terrasoft.Core",
				"ProcessSchemaDeleteDataUserTask.Exception.DeleteDataWithEmptyFilter");
			ProcessUserTaskUtilities.ThrowExceptionIfEmptyFilters(filters, message);
		}

		private static EntitySchemaQuery GetEntitySchemaQuery(EntitySchemaManager entitySchemaManager,
				EntitySchema entitySchema, bool useUserPermissions) {
			return new EntitySchemaQuery(entitySchemaManager, entitySchema.Name) {
				UseAdminRights = useUserPermissions,
				IgnoreDisplayValues = GlobalAppSettings.FeatureIgnoreDisplayValuesInDataUserTasks
			};
		}

		private void DeleteEntities(EntityCollection entities, bool useUserPermissions) {
			string GetDebugInfo(Entity source) {
				var info = new System.Text.StringBuilder();
				try {
					info.Append(source.SchemaName);
					info.Append($" ({source.Schema.PrimaryColumn.Name}: [{source.PrimaryColumnValue}])");
				} catch (Exception) { }
				return info.ToString();
			}
			while (entities.Count > 0) {
				Entity entity = entities.First.Value;
				try {
					entity.UseAdminRights = useUserPermissions;
					entities.RemoveFirst();
					entity.Delete();
					TraceLog(uId => $"{uId} Deleted entity: Id={entity.PrimaryColumnValue}, " +
						$"Schema={entity.Schema.Name}, Element={Name}, Process={Owner?.Schema?.Name}");
				} catch (Exception e) {
					string debugInfo = GetDebugInfo(entity);
					Log.Error(
						$"An error occurred during process element {this} when deleting an entity {debugInfo}", e);
					throw;
				}
			}
		}

		private void TraceLog(Func<Guid, string> message) {
			if (_traceLog.IsTraceEnabled) {
				_traceLog.Trace(message(UId));
			}
		}

		private void SetupTraceLogger() {
			string name = nameof(DeleteDataUserTask);
			try {
				if (Features.GetIsEnabled<UseSpecificSchemaLogging>()) {
					name += ":" + Owner?.Schema?.Name;
				}
			} catch (Exception ex) {
				Log.Warn(ex);
			}
			_traceLog = LogManager.GetLogger(name);
		}

		private void DeleteEntities(EntitySchemaManager entitySchemaManager, EntitySchema entitySchema,
				bool useUserPermissions) {
			EntitySchemaQuery esq = GetEntitySchemaQuery(entitySchemaManager, entitySchema, useUserPermissions);
			esq.AddAllSchemaColumns();
			ProcessUserTaskUtilities.SpecifyESQFilters(UserConnection, this, entitySchema, esq, DataSourceFilters);
			EntitySchemaQueryFilterCollection filters = esq.Filters;
			ThrowExceptionIfEmptyFilters(filters);
			EntityCollection entities = esq.GetEntityCollection(UserConnection);
			DeleteEntities(entities, useUserPermissions);
		}

		private void DeleteEntitiesByChunks(EntitySchemaManager entitySchemaManager, EntitySchema entitySchema,
				bool useUserPermissions) {
			EntitySchemaQuery esq = GetEntitySchemaQuery(entitySchemaManager, entitySchema, useUserPermissions);
			esq.PrimaryQueryColumn.IsAlwaysSelect = true;
			ProcessUserTaskUtilities.SpecifyESQFilters(UserConnection, this, entitySchema, esq, DataSourceFilters);
			EntitySchemaQueryFilterCollection filters = esq.Filters;
			ThrowExceptionIfEmptyFilters(filters);
			var entityIds = new List<object>();
			esq.ChunkSize = 10_000;
			foreach (EntityCollection collection in esq.GetEntityCollectionIterator(UserConnection)) {
				foreach (Entity entity in collection) {
					entityIds.Add(entity.PrimaryColumnValue);
				}
			}
			DeleteEntities(entitySchemaManager, entitySchema, entityIds, useUserPermissions);
		}

		private void DeleteEntities(EntitySchemaManager entitySchemaManager, EntitySchema entitySchema,
				IList<object> entityIds, bool useUserPermissions) {
			using (UsageContext context = CreateUsageContext()) {
				EntitySchemaQuery esq = GetEntitySchemaQuery(entitySchemaManager, entitySchema, useUserPermissions);
				esq.SetUsageContext(context, CrudOperationType.Delete);
				esq.AddAllSchemaColumns();
				string primaryColumnName = entitySchema.PrimaryColumn.Name;
				EntitySchemaQueryFilterCollection filters = esq.Filters;
				IEnumerable<IEnumerable<object>> chunks = entityIds.SplitOnChunks(100);
				foreach (IEnumerable<object> chunk in chunks) {
					IEntitySchemaQueryFilterItem filter =
						esq.CreateFilterWithParameters(FilterComparisonType.Equal, primaryColumnName, chunk);
					filters.Add(filter);
					EntityCollection entities = esq.GetEntityCollection(UserConnection);
					DeleteEntities(entities, useUserPermissions);
					esq.ResetSelectQuery();
					filters.Clear();
				}
			}
		}

		#endregion

		#region Methods: Protected

		/// <inheritdoc />
		protected override bool InternalExecute(ProcessExecutingContext context) {
			SetupTraceLogger();
			EntitySchemaId.CheckArgumentEmpty(nameof(EntitySchemaId));
			EntitySchemaManager entitySchemaManager = UserConnection.EntitySchemaManager;
			EntitySchema entitySchema = entitySchemaManager.GetInstanceByUId(EntitySchemaId);
			if (GlobalAppSettings.FeatureUseEntityCollectionChunksInProcessUserTask) {
				DeleteEntitiesByChunks(entitySchemaManager, entitySchema, context.UseUserPermissions);
			} else {
				DeleteEntities(entitySchemaManager, entitySchema, context.UseUserPermissions);
			}
			return true;
		}

		#endregion

	}

	#endregion

}

