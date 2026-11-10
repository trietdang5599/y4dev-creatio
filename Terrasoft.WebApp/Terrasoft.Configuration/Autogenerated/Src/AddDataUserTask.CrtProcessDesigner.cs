namespace Terrasoft.Core.Process.Configuration
{
	using System;
	using System.Linq;
	using System.Collections.Generic;
	using System.Runtime.ExceptionServices;
	using Creatio.FeatureToggling;
	using Terrasoft.Common;
	using Terrasoft.Configuration;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Process;

	#region Class: AddDataUserTask

	/// <exclude/>
	public partial class AddDataUserTask
	{

		#region Class: EnableChunkSelection

		/// <summary>
		/// Feature metadata that enables chunk selection for processing entities in user tasks.
		/// When enabled, entities are processed in chunks to optimize performance and resource usage.
		/// </summary>
		public class EnableChunkSelection : FeatureMetadata
		{

			#region Constructors: Public

			/// <summary>
			/// Initializes a new instance of the <see cref="AddDataUserTask.EnableChunkSelection"/>.
			/// </summary>
			public EnableChunkSelection() {
				IsEnabled = false;
			}

			#endregion

		}

		#endregion

		#region Class: EnableForeignKeyExceptionDetails

		/// <summary>
		/// Feature that enables detailed information for foreign key exceptions during entity inserts in processes.
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

		private const int DefaultSelectSize = 10_000;
		private const int DefaultChunkSize = 100;

		#endregion

		#region Properties: Public

		private IDBExceptionHandler _dbExceptionHandler;

		/// <summary>
		/// Gets or sets the database exception handler used to process and enrich exceptions during entity inserts.
		/// If not set, a new instance of <see cref="DBExceptionHandler"/> is returned by default.
		/// </summary>
		public IDBExceptionHandler DBExceptionHandler {
			get => _dbExceptionHandler ?? new DBExceptionHandler();
			set => _dbExceptionHandler = value;
		}

		#endregion

		#region Methods: Private

		private static EntitySchemaQuery GetEntitySchemaQuery(EntitySchema entitySchema, bool useUserPermissions) {
			return new EntitySchemaQuery(entitySchema) {
				UseAdminRights = useUserPermissions
			};
		}

		private Entity GetNewEntity(bool useUserPermissions) {
			EntitySchema entitySchema = GetEntitySchema(EntitySchemaId);
			Entity newEntity = entitySchema.CreateEntity(UserConnection);
			newEntity.SetDefColumnValues();
			newEntity.UseAdminRights = useUserPermissions;
			return newEntity;
		}

		private Dictionary<string, string> GetQueryColumnMap(EntitySchemaQuery entitySchemaQuery,
				EntitySchema entitySchema) {
			Dictionary<string, string> entityColumnMap = null;
			if (RecordDefValues.FetchMetaPathes == null || RecordDefValues.FetchMetaPathes.Count == 0) {
				entitySchemaQuery.PrimaryQueryColumn.IsAlwaysSelect = true;
			} else {
				entityColumnMap = new Dictionary<string, string>();
				foreach (KeyValuePair<string, string> columnValue in RecordDefValues.FetchMetaPathes) {
					string columnPath = entitySchema.GetSchemaColumnPathByMetaPath(columnValue.Value);
					EntitySchemaQueryColumn queryColumn;
					if (columnPath == entitySchema.PrimaryColumn.Name) {
						queryColumn = entitySchemaQuery.PrimaryQueryColumn;
						queryColumn.IsAlwaysSelect = true;
					} else {
						queryColumn = entitySchemaQuery.AddColumn(columnPath);
					}
					entityColumnMap[columnValue.Value] = queryColumn.Name;
				}
			}
			return entityColumnMap;
		}

		private void SetFilters(EntitySchema entitySchema, EntitySchemaQuery entitySchemaQuery) {
			if (!FilterEntitySchemaId.Equals(Guid.Empty) && DataSourceFilters.IsNotNullOrEmpty()) {
				ProcessUserTaskUtilities.SpecifyESQFilters(UserConnection, this, entitySchema, entitySchemaQuery,
					DataSourceFilters);
			}
		}

		private IList<object> GetEntityIds(EntitySchemaQuery esq) {
			var entityIds = new List<object>();
			esq.ChunkSize = DefaultSelectSize;
			esq.PrimaryQueryColumn.IsAlwaysSelect = true;
			foreach (EntityCollection collection in esq.GetEntityCollectionIterator(UserConnection)) {
				foreach (Entity entity in collection) {
					entityIds.Add(entity.PrimaryColumnValue);
				}
			}
			return entityIds;
		}

		private void CreateNewEntitiesFromSelected(ProcessExecutingContext context, EntitySchema entitySchema,
				IList<object> ids) {
			EntitySchemaQuery esq = GetEntitySchemaQuery(entitySchema, context.UseUserPermissions);
			Dictionary<string, string> entityColumnMap = GetQueryColumnMap(esq, entitySchema);
			string primaryColumnName = entitySchema.PrimaryColumn.Name;
			EntitySchemaQueryFilterCollection filters = esq.Filters;
			IEnumerable<IEnumerable<object>> chunks = ids.SplitOnChunks(DefaultChunkSize);
			foreach (IEnumerable<object> chunk in chunks) {
				IEntitySchemaQueryFilterItem filter =
					esq.CreateFilterWithParameters(FilterComparisonType.Equal, primaryColumnName, chunk);
				filters.Add(filter);
				EntityCollection entities = esq.GetEntityCollection(UserConnection);
				foreach (Entity entity in entities) {
					Entity newEntity = GetNewEntity(context.UseUserPermissions);
					FillRowWithDataByFilter(newEntity, entity, entityColumnMap);
					SaveEntityWithExceptionHandling(newEntity);
				}
				esq.ResetSelectQuery();
				filters.Clear();
			}
		}

		private void CreateEntity(ProcessExecutingContext context) {
			Entity newEntity = GetNewEntity(context.UseUserPermissions);
			FillRowWithData(newEntity);
			SaveEntityWithExceptionHandling(newEntity);
			RecordId = newEntity.PrimaryColumnValue;
		}

		private void SaveEntityWithExceptionHandling(Entity newEntity) {
			try {
				newEntity.Save(false);
			} catch (Exception e) {
				if (Features.GetIsDisabled<EnableForeignKeyExceptionDetails>() ||
						!DBExceptionHandler.GetIsForeignKeyException(e)) {
					throw;
				}
				Exception enrichedException = DBExceptionHandler.EnrichExceptionWithForeignKeyInfo(e, UserConnection,
					newEntity.Schema, newEntity);
				ExceptionDispatchInfo.Capture(enrichedException).Throw();
			}
		}

		private void CreateEntitiesFromSelected(ProcessExecutingContext context) {
			if (Features.GetIsEnabled<EnableChunkSelection>()) {
				EntitySchema entitySchema = GetEntitySchema(FilterEntitySchemaId);
				EntitySchemaQuery entitySchemaQuery = GetEntitySchemaQuery(entitySchema, context.UseUserPermissions);
				SetFilters(entitySchema, entitySchemaQuery);
				IList<object> ids = GetEntityIds(entitySchemaQuery);
				CreateNewEntitiesFromSelected(context, entitySchema, ids);
				return;
			}
			EntityCollection filterResultEntityCollection =
				GetFilterResultEntityCollection(out Dictionary<string, string> entityColumnMap,
					context.UseUserPermissions);
			foreach (Entity filterResultEntity in filterResultEntityCollection) {
				Entity newEntity = GetNewEntity(context.UseUserPermissions);
				FillRowWithDataByFilter(newEntity, filterResultEntity, entityColumnMap);
				SaveEntityWithExceptionHandling(newEntity);
			}
		}

		#endregion

		#region Methods: Protected

		protected override bool InternalExecute(ProcessExecutingContext context) {
			RecordId = Guid.Empty;
			if (EntitySchemaId.Equals(Guid.Empty)) {
				return true;
			}
			try {
				if (FilterEntitySchemaId != Guid.Empty) {
					CreateEntitiesFromSelected(context);
				} else {
					CreateEntity(context);
				}
			} catch (Exception e) {
				string debugInfo = GetEntitySchema(EntitySchemaId).Name;
				Log.Error($"An error occurred during process element {this} when adding an entity {debugInfo}", e);
				throw;
			}
			return true;
		}

		#endregion

		#region Methods: Public


		/// <summary>
		/// Gets filter result entity collection. Will not be used if EnableChunkSelection feature is enabled.
		/// </summary>
		/// <param name="entityColumnMap">Entity column map.</param>
		/// <param name="useUserPermissions">Use user permissions.</param>
		/// <returns>Entity collection.</returns>
		public virtual EntityCollection GetFilterResultEntityCollection(out Dictionary<string,
				string> entityColumnMap, bool useUserPermissions) {
			entityColumnMap = null;
			if (FilterEntitySchemaId.Equals(Guid.Empty)) {
				return null;
			}
			EntitySchema entitySchema = GetEntitySchema(FilterEntitySchemaId);
			if (entitySchema == null) {
				return null;
			}
			EntitySchemaQuery entitySchemaQuery = GetEntitySchemaQuery(entitySchema, useUserPermissions);
			entityColumnMap = GetQueryColumnMap(entitySchemaQuery, entitySchema);
			SetFilters(entitySchema, entitySchemaQuery);
			return entitySchemaQuery.GetEntityCollection(UserConnection);
		}

		public virtual EntitySchema GetEntitySchema(Guid entitySchemaId) {
			return UserConnection.EntitySchemaManager.GetInstanceByUId(entitySchemaId);
		}

		[Obsolete("8.1.5 | Method is not in use and will be removed in upcoming releases.")]
		public virtual Entity GetNewEntity() {
			return GetNewEntity(false);
		}

		public virtual void FillRowWithDataByFilter(Entity entity, Entity filterEntity,
				Dictionary<string, string> entityColumnMap) {
			FillRowWithData(entity);
			foreach (KeyValuePair<string, string> columnValue in RecordDefValues.FetchMetaPathes) {
				EntitySchemaColumn column = entity.Schema.GetSchemaColumnByMetaPath(columnValue.Key);
				EntitySchemaColumn filterColumn =
					filterEntity.Schema.GetSchemaColumnByPath(entityColumnMap[columnValue.Value]);
				object filterValue = filterEntity.GetColumnValue(filterColumn);
				if (filterValue == null) {
					continue;
				}
				if (ProcessUserTaskUtilities.GetIsEmptyLookupOrDateTimeValue(filterValue, column.DataValueType)) {
					continue;
				}
				entity.SetColumnValue(column, filterValue);
			}
		}

		public virtual void FillRowWithData(Entity entity) {
			foreach (KeyValuePair<string, object> columnValue in RecordDefValues.Values) {
				EntitySchemaColumn column = entity.Schema.GetSchemaColumnByMetaPath(columnValue.Key);
				object value = columnValue.Value;
				if (ProcessUserTaskUtilities.GetIsEmptyLookupOrDateTimeValue(value, column.DataValueType)) {
					continue;
				}
				entity.SetColumnValue(column, value);
			}
		}

		#endregion

	}

	#endregion

	#region Class: AddDataUserTaskSchemaExtension

	/// <exclude/>
	public class AddDataUserTaskSchemaExtension : ProcessUserTaskSchemaExtension
	{

		#region Methods: Private

		private static EntitySchemaManager GetEntitySchemaManager(BaseProcessSchema baseProcessSchema) {
			return (EntitySchemaManager)baseProcessSchema.SchemaManagerProvider.GetManager(nameof(EntitySchemaManager));
		}

		private static EntitySchema FindEntitySchema(ProcessSchemaUserTask schemaElement, Guid entitySchemaUId) {
			var baseProcessSchema = (BaseProcessSchema)schemaElement.ParentMetaSchema;
			EntitySchemaManager entitySchemaManager = GetEntitySchemaManager(baseProcessSchema);
			return entitySchemaManager.FindInstanceByUId(entitySchemaUId);
		}

		#endregion

		#region Methods: Public

		/// <inheritdoc cref="ProcessUserTaskSchemaExtension.AnalyzePackageDependencies"/>
		public override void AnalyzePackageDependencies(ProcessSchemaUserTask schemaElement,
				IProcessSchemaPackageDependencyReporter dependencyReporter) {
			base.AnalyzePackageDependencies(schemaElement, dependencyReporter);
			ProcessSchemaParameterCollection parameters = schemaElement.Parameters;
			ProcessSchemaParameter filterEntitySchemaIdParameter = parameters.GetByName("FilterEntitySchemaId");
			Guid.TryParse(filterEntitySchemaIdParameter.SourceValue.Value, out Guid entitySchemaUId);
			string reasonSource = $"{schemaElement.Name}.{filterEntitySchemaIdParameter.Name}";
			dependencyReporter.ReportSchemaDependency(entitySchemaUId, nameof(EntitySchemaManager), reasonSource);
			ProcessSchemaParameter recordDefValuesParameter = parameters.GetByName("RecordDefValues");
			ProcessSchemaParameterValue sourceValue = recordDefValuesParameter.SourceValue;
			if (sourceValue.Value.IsNullOrEmpty()) {
				return;
			}
			EntityColumnMappingCollection mappingCollection = EntityColumnMappingCollection.DeserializeValue(
				sourceValue);
			reasonSource = $"{schemaElement.Name}.{recordDefValuesParameter.Name}";
			var mappingColumns = mappingCollection
				.Where(mapping => mapping.Value.Source == ProcessSchemaParameterValueSource.EntityMapping)
				.Select(mapping => mapping.Value.Value);
			var columnsLocator = SchemaColumnsLocator.CreateFromMetaPaths(mappingColumns);
			dependencyReporter.ReportSchemaColumnsDependency(entitySchemaUId, columnsLocator, reasonSource);
		}

		#endregion

	}

	#endregion

}
