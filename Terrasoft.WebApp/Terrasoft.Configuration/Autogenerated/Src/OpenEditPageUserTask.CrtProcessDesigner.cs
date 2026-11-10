namespace Terrasoft.Core.Process.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Linq;
	using Creatio.FeatureToggling;
	using Terrasoft.Common;
	using Terrasoft.Configuration;
	using Terrasoft.Core;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Process;
	using Terrasoft.Nui.ServiceModel.Extensions;
	using RecordEditMode = Terrasoft.Configuration.RecordEditMode;
	using CoreEntityCollection = Terrasoft.Core.Entities.EntityCollection;
	using CoreEntitySchema = Terrasoft.Core.Entities.EntitySchema;
	using CoreEntitySchemaColumn = Terrasoft.Core.Entities.EntitySchemaColumn;

	#region Class: OpenEditPageUserTask

	/// <summary>
	/// Represents user task to open edit page.
	/// </summary>
	public partial class OpenEditPageUserTask : IUserTaskActivityInfo, IProcessElementExtraDataBuilder
	{

		#region Class: CompleteOnlyBySaveButton

		/// <summary>
		/// Indicates whether to complete element only when save button is clicked.
		/// </summary>
		/// <inheritdoc cref="FeatureMetadata"/>
		public class CompleteOnlyBySaveButton : FeatureMetadata
		{

			#region Constructors: Public

			/// <summary>
			/// Initializes a new instance of the <see cref="CompleteOnlyBySaveButton"/>.
			/// </summary>
			public CompleteOnlyBySaveButton() {
				IsEnabled = true;
			}

			#endregion

		}

		#endregion

		#region Properties: Private

		private CoreEntitySchema _entitySchema;
		private CoreEntitySchema EntitySchema => _entitySchema ??
			(_entitySchema = UserConnection.EntitySchemaManager.GetInstanceByUId(ObjectSchemaId));

		private bool CreateActivityFix => CreateActivity || !(Owner is ProcessComponentSet);

		#endregion

		#region Methods: Private

		private static object GetDataSourcesConfig() {
			return new[] {
				new {
					expectedTypes = new[] {
						"crt.EntityDataSource"
					},
					config = new {
						isForceUpdate = true
					}
				}
			};
		}

		private static void WriteDataSourcesConfig(IProcessExecutionDataWriter dataWriter) {
			object config = GetDataSourcesConfig();
			dataWriter.WriteObject("dataSourcesConfig", config);
		}

		private static CompletionInfo GetCompletionInfo() {
			return new CompletionInfo {
				Handlers = new [] {
					new CompletionHandler {
						Event = "clicked",
						RequestName = "crt.SaveRecordRequest"
					}
				}
			};
		}

		private static void WriteCompletionInfo(IProcessExecutionDataWriter dataWriter) {
			CompletionInfo config = GetCompletionInfo();
			dataWriter.WriteObject("completionInfo", config);
		}

		private Dictionary<string, object> GetDefaultValues(EntitySchema entitySchema) {
			var defaultColumnValues = new Dictionary<string, object>();
			foreach (KeyValuePair<string, object> columnValue in RecordColumnValues.Values) {
				EntitySchemaColumn column = entitySchema.GetSchemaColumnByMetaPath(columnValue.Key);
				bool isLookup = column.DataValueType is LookupDataValueType ||
					column.DataValueType is MultiLookupDataValueType;
				if (isLookup &&((Guid)columnValue.Value).IsEmpty()) {
					continue;
				}
				defaultColumnValues[column.Name] = SerializeEntityColumn(column, columnValue.Value);
			}
			RecordEditMode editMode = GetRecordEditMode();
			if (editMode == RecordEditMode.New) {
				EntitySchemaColumnCollection columns = entitySchema.Columns;
				defaultColumnValues["ProcessListeners"] =
					SerializeEntityColumn(columns.GetByName("ProcessListeners"), (int)EntityChangeType.Inserted);
			}
			return defaultColumnValues.Count > 0 ? defaultColumnValues : null;
		}

		private void AddProcessListenerForEntityInsert() {
			IProcessEngine processEngine = UserConnection.ProcessEngine;
			processEngine.AddProcessListener(RecordId, ObjectSchemaId, UId, null, null, EntityChangeType.Inserted);
		}

		private void PrepareRecord(RecordEditMode editMode) {
			if (CreateActivityFix) {
				CreateAccompanyingActivity(false);
			}
			if (editMode == RecordEditMode.New) {
				RecordId = Guid.NewGuid();
			}
		}

		private void ObsoletePrepareRecord(RecordEditMode editMode) {
			if (CreateActivityFix) {
				CreateAccompanyingActivity();
			}
			if (editMode == RecordEditMode.New) {
				RecordId = Guid.NewGuid();
				AddProcessListenerForEntityInsert();
			} else {
				AddProcessListenerForEntityChange();
			}
		}

		private void ObsoletePrepareActivityRecord(RecordEditMode editMode) {
			if (editMode == RecordEditMode.New) {
				CreateTechnicalActivity();
				RecordId = CurrentActivityId;
			} else {
				CurrentActivityId = RecordId;
				AddProcessListenerForEntityChange();
			}
		}

		private void PrepareActivityRecord(RecordEditMode editMode) {
			if (editMode == RecordEditMode.New) {
				CreateTechnicalActivity(false, false);
				RecordId = CurrentActivityId;
			} else {
				CurrentActivityId = RecordId;
			}
		}

		private void AddProcessListenerForEntityChange() {
			string serializedFilters = GetProcessListenerFilters();
			IProcessEngine processEngine = UserConnection.ProcessEngine;
			processEngine.AddProcessListener(RecordId, ObjectSchemaId, UId, serializedFilters);
		}

		private string GetProcessListenerFilters() {
			return IsMatchConditions && DataSourceFilters.IsNotNullOrEmpty()
				? ConvertToProcessDataSourceFilters(ObjectSchemaId, DataSourceFilters)
				: null;
		}

		private Entity CreateTechnicalActivity(bool isAccompanying, bool isSetProcessListener = true) {
			var info = new UserTaskActivityInfo {
				Title = GetActivityTitle(),
				TypeId = ActivityConsts.TaskTypeUId,
				StartOffset = new ProcessDateOffset(StartIn, (ProcessDurationPeriod)StartInPeriod),
				Duration = new ProcessDateOffset(Duration, (ProcessDurationPeriod)DurationPeriod),
				RemindOffset = new ProcessDateOffset(RemindBefore, (ProcessDurationPeriod)RemindBeforePeriod),
				PriorityId = ActivityPriority
			};
			if (!isAccompanying) {
				info.CompletionFilter = Option.Some(GetProcessListenerFilters());
				info.ColumnValues = GetEntityColumnValues(GetActivityEntitySchema());
			}
			if (!isSetProcessListener) {
				info.IsSetProcessListener = false;
				info.NeedSetProcessElementId = true;
			}
			Entity activity = this.CreateUserTaskActivity(info);
			IsActivityCompleted = false;
			CurrentActivityId = activity.PrimaryColumnValue;
			return activity;
		}

		private Dictionary<string, object> GetEntityColumnValues(EntitySchema schema) {
			var result = new Dictionary<string, object>();
			foreach (KeyValuePair<string, object> columnValue in RecordColumnValues.Values) {
				CoreEntitySchemaColumn column = schema.GetSchemaColumnByMetaPath(columnValue.Key);
				if ((column.DataValueType is LookupDataValueType || column.DataValueType is MultiLookupDataValueType) &&
					((Guid)columnValue.Value).IsEmpty()) {
					continue;
				}
				result[column.ColumnValueName] = columnValue.Value;
			}
			return result;
		}

		private void FillResultParameter() {
			if (GenerateDecisionsFromColumn) {
				ResultParameter = GetResultParameter();
			}
		}

		private void ObsoleteContinueExecution() {
			RecordEditMode editMode = GetRecordEditMode();
			if (editMode == RecordEditMode.New) {
				string serializedFilters = IsMatchConditions && DataSourceFilters.IsNotNullOrEmpty()
					? ConvertToProcessDataSourceFilters(ObjectSchemaId, DataSourceFilters)
					: null;
				UserConnection.ProcessEngine.AddProcessListener(RecordId, ObjectSchemaId, UId, serializedFilters);
				EditMode = (int)RecordEditMode.Existing;
			}
			SetInProgressActivityStatus();
		}

		private void SetInProgressActivityStatus() {
			if (CurrentActivityId.IsEmpty()) {
				return;
			}
			Guid activityStatusId = ProcessUserTaskUtilities.GetActivityStatus(UserConnection, CurrentActivityId);
			if (activityStatusId == ActivityConsts.NewStatusUId) {
				ProcessUserTaskUtilities.SetActivityStatus(UserConnection, CurrentActivityId,
					ActivityConsts.InProgressUId);
			}
		}

		private void ObsoleteCompleteExecution() {
			bool isActivityRecord = GetIsActivityEntitySchema();
			if (CurrentActivityId.IsEmpty()) {
				RemoveObjectProcessListener(isActivityRecord);
				return;
			}
			this.SynchronizeCompletedUserTaskActivity(new UserTaskActivitySyncOptions {
				RemoveListener = !isActivityRecord,
				UseEntityComplete = isActivityRecord,
				SynchronizeParameterValues = false
			});
		}

		private void CompleteExecution() {
			if (CurrentActivityId.IsEmpty()) {
				return;
			}
			if (GetIsActivityEntitySchema()) {
				if (GetRecordEditMode() == RecordEditMode.New) {
					this.UnlinkActivity(statusId: null);
				}
				return;
			}
			this.SynchronizeCompletedUserTaskActivity(new UserTaskActivitySyncOptions {
				RemoveListener = false,
				UseEntityComplete = true,
				NeedUpdateActivityStatus = true,
				SynchronizeParameterValues = false,
			});
		}

		private void RemoveObjectProcessListener(bool isActivityRecord) {
			if (!isActivityRecord) {
				IProcessEngine processEngine = UserConnection.ProcessEngine;
				processEngine.RemoveProcessListener(RecordId, ObjectSchemaId, UId);
			}
		}

		private RecordEditMode GetRecordEditMode() {
			return (RecordEditMode)Enum.ToObject(typeof(RecordEditMode), EditMode);
		}

		private void ObsoleteInternalExecute(ProcessExecutingContext context) {
			bool activityExists = CurrentActivityId.IsNotEmpty() && !IsActivityCompleted;
			if (!activityExists) {
				RecordEditMode editMode = GetRecordEditMode();
				if (GetIsActivityEntitySchema()) {
					ObsoletePrepareActivityRecord(editMode);
				} else {
					ObsoletePrepareRecord(editMode);
				}
			}
			InteractWithUser(context, activityExists, ShowExecutionPage);
		}

		private void ObsoleteCancelExecuting() {
			IProcessEngine processEngine = UserConnection.ProcessEngine;
			if (CurrentActivityId.IsNotEmpty()) {
				processEngine.RemoveActivityProcessListener(CurrentActivityId, UId, ActivityConsts.CanceledStatusUId);
			}
			if (GetIsActivityEntitySchema()) {
				return;
			}
			RecordEditMode editMode = GetRecordEditMode();
			EntityChangeType entityChangeType = editMode == RecordEditMode.New
				? EntityChangeType.Inserted
				: EntityChangeType.Updated;
			processEngine.RemoveProcessListener(RecordId, ObjectSchemaId, UId, entityChangeType);
		}

		private bool ObsoleteCompleteExecuting(params object[] parameters) {
			if (GetIsActivityEntitySchema() || GetIsMatchedConditions()) {
				ObsoleteCompleteExecution();
				FillResultParameter();
				return base.CompleteExecuting(parameters);
			}
			ObsoleteContinueExecution();
			return false;
		}

		#endregion

		#region Methods: Protected

		/// <inheritdoc />
		protected override bool InternalExecute(ProcessExecutingContext context) {
			if (Features.GetIsDisabled<CompleteOnlyBySaveButton>()) {
				ObsoleteInternalExecute(context);
				return false;
			}
			RecordEditMode editMode = GetRecordEditMode();
			if (GetIsActivityEntitySchema()) {
				PrepareActivityRecord(editMode);
			} else {
				PrepareRecord(editMode);
			}
			InteractWithUser(context, false, ShowExecutionPage);
			return false;
		}

		/// <inheritdoc />
		protected override void WriteExecutionData(IProcessExecutionDataWriter dataWriter) {
			base.WriteExecutionData(dataWriter);
			string actionName = GetActionName();
			dataWriter.Write("action", actionName);
			dataWriter.Write("completeExecution", actionName == "add");
			dataWriter.Write("entitySchemaName", EntitySchema.Name);
			dataWriter.Write("recordId", RecordId);
			dataWriter.Write("activityRecordId", CurrentActivityId);
			dataWriter.Write("recommendation", GetActivityTitle());
			string informationOnStep = LocalizableString.IsNullOrEmpty(InformationOnStep)
				? GetParameterValue("InformationOnStep")?.ToString() ?? string.Empty
				: InformationOnStep.Value;
			dataWriter.Write("informationOnStep", informationOnStep);
			dataWriter.Write("executionContext", ExecutionContext);
			dataWriter.Write("pageTypeId", PageTypeUId == Guid.Empty ? string.Empty : PageTypeUId.ToString());
			dataWriter.Write("nextProcElUId", "nextProcElUIdValue");
			Dictionary<string, object> defaultValues = GetDefaultValues(EntitySchema);
			dataWriter.WriteObject("defaultValues", defaultValues);
			if (Features.GetIsEnabled<CompleteOnlyBySaveButton>()) {
				WriteCompletionInfo(dataWriter);
			} else {
				WriteDataSourcesConfig(dataWriter);
			}
			dataWriter.Write("userTaskName", nameof(OpenEditPageUserTask));
		}

		#endregion

		#region Methods: Public

		/// <inheritdoc />
		public override bool CompleteExecuting(params object[] parameters) {
			bool isDisabled = Features.GetIsDisabled<CompleteOnlyBySaveButton>();
			if (isDisabled) {
				return ObsoleteCompleteExecuting(parameters);
			}
			if (parameters != null && parameters.OfType<Entity>().Any()) {
				return false;
			}
			if (!GetIsMatchedConditions()) {
				return false;
			}
			CompleteExecution();
			FillResultParameter();
			return base.CompleteExecuting(parameters);
		}

		/// <inheritdoc />
		public override ProcessElementNotification GetNotificationData() {
			ProcessElementNotification notification = base.GetNotificationData();
			ProcessUserTaskUtilities.AssignNotificationData(notification, Recommendation, StartIn, StartInPeriod);
			return notification;
		}

		/// <inheritdoc />
		public override void CancelExecuting(params object[] parameters) {
			base.CancelExecuting(parameters);
			if (Features.GetIsDisabled<CompleteOnlyBySaveButton>()) {
				ObsoleteCancelExecuting();
				return;
			}
			if (CurrentActivityId.IsNotEmpty()) {
				this.UnlinkActivity(ActivityConsts.CanceledStatusUId);
			}
		}

		/// <summary>
		/// Determines whether the conditions is satisfied.
		/// </summary>
		/// <returns><c>true</c> when conditions are successfully checked; otherwise - <c>false</c>.</returns>
		public virtual bool GetIsMatchedConditions() {
			if (!IsMatchConditions || DataSourceFilters.IsNullOrEmpty()) {
				return true;
			}
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, EntitySchema.Name) {
				UseAdminRights = false
			};
			esq.AddColumn(EntitySchema.PrimaryColumn.Name);
			ProcessUserTaskUtilities.SpecifyESQFilters(UserConnection, this, EntitySchema, esq, DataSourceFilters);
			if (esq.Filters.Count == 0) {
				return true;
			}
			if (esq.Filters.Count == 1) {
				if (esq.Filters[0] is EntitySchemaQueryFilterCollection filterGroup && filterGroup.Count == 0) {
					return true;
				}
			}
			Entity entity = esq.GetEntity(UserConnection, RecordId);
			return entity != null;
		}

		/// <summary>
		/// Returns value of the result parameter.
		/// </summary>
		/// <returns></returns>
		public virtual Guid GetResultParameter() {
			if (string.IsNullOrEmpty(DecisionalColumnMetaPath)) {
				return Guid.Empty;
			}
			Guid resultParameterId = Guid.Empty;
			EntitySchemaColumn columnSchema = EntitySchema.GetSchemaColumnByMetaPath(DecisionalColumnMetaPath);
			var esq = new EntitySchemaQuery(EntitySchema) {
				UseAdminRights = false
			};
			EntitySchemaQueryColumn column = esq.AddColumn(columnSchema.Name);
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Id", RecordId));
			CoreEntityCollection resultCollection = esq.GetEntityCollection(UserConnection);
			if (resultCollection.Count != 0) {
				resultParameterId = resultCollection.First.Value.GetTypedColumnValue<Guid>(column.ValueQueryAlias);
			}
			return resultParameterId;
		}

		/// <summary>
		/// Returns entity of the accompanying Activity.
		/// </summary>
		/// <returns>A new instance of the entity.</returns>
		public Entity CreateAccompanyingActivity(bool isSetProcessListener = true) {
			return CreateTechnicalActivity(true, isSetProcessListener);
		}

		/// <summary>
		/// Returns type of the activity.
		/// </summary>
		/// <returns>Lookup value.</returns>
		public virtual Guid GetActivityType() {
			foreach (KeyValuePair<string, object> columnValue in RecordColumnValues.Values) {
				CoreEntitySchemaColumn column = EntitySchema.GetSchemaColumnByMetaPath(columnValue.Key);
				if (column.Name == "Type" && columnValue.Value != null) {
					var typeId = (Guid)columnValue.Value;
					if (typeId != Guid.Empty) {
						return typeId;
					}
				}
			}
			return PageTypeUId;
		}

		/// <summary>
		/// Returns title of the activity.
		/// </summary>
		/// <returns>Activity title.</returns>
		public virtual string GetActivityTitle() {
			return ProcessUserTaskUtilities.GetActivityTitle(this, Recommendation, CurrentActivityId);
		}

		/// <summary>
		/// Serializes value of the entity column.
		/// </summary>
		/// <param name="schemaColumn">Schema column.</param>
		/// <param name="columnValue">Column value.</param>
		/// <returns></returns>
		public virtual object SerializeEntityColumn(CoreEntitySchemaColumn schemaColumn, object columnValue) {
			if (schemaColumn == null || columnValue == null) {
				return string.Empty;
			}
			if (schemaColumn.DataValueType is BooleanDataValueType) {
				return DataTypeUtilities.ValueAsType<bool>(columnValue);
			}
			if (schemaColumn.IsLookupType) {
				QueryColumnExpression primaryColumnValue =
					Column.Parameter(DataTypeUtilities.ValueAsType<Guid>(columnValue));
				EntitySchema referenceSchema = schemaColumn.ReferenceSchema;
				var displayValueSelect =
					(Select)new Select(UserConnection)
						.Column(referenceSchema.PrimaryDisplayColumn.Name)
					.From(referenceSchema.Name).WithHints(Hints.NoLock)
					.Where(referenceSchema.PrimaryColumn.Name).IsEqual(primaryColumnValue);
				return new {
					value = columnValue,
					displayValue = displayValueSelect?.ExecuteScalar<string>()
				};
			}
			if (schemaColumn.DataValueType is DateTimeDataValueType dateTimeDataValueType) {
				var dateTime = (DateTime)columnValue;
				if (dateTime == DateTime.MinValue) {
					return null;
				}
				if (dateTime.Kind != DateTimeKind.Unspecified) {
					columnValue = DateTime.SpecifyKind(dateTime, DateTimeKind.Unspecified);
				}
				string value = DateTimeDataValueType.Serialize(columnValue, TimeZoneInfo.Utc);
				return new {
					dataValueType = (int)dateTimeDataValueType.ToEnum(),
					value
				};
			}
			return DataTypeUtilities.ValueAsType<string>(columnValue);
		}

		/// <summary>
		/// Determines whether the current entity schema is Activity.
		/// </summary>
		/// <returns></returns>
		public virtual bool GetIsActivityEntitySchema() {
			return ObjectSchemaId == GetActivityEntitySchemaUId();
		}

		/// <summary>
		/// Record edit mode.
		/// </summary>
		/// <returns>Edit mode of the record.</returns>
		public virtual string GetActionName() {
			RecordEditMode editMode = GetRecordEditMode();
			if (editMode != RecordEditMode.New) {
				return "edit";
			}
			return GetIsActivityEntitySchema() || GetIsExecuted() ? "edit" : "add";
		}

		/// <summary>
		/// Returns UId of the Activity schema.
		/// </summary>
		public virtual Guid GetActivityEntitySchemaUId() {
			return ActivityConsts.ActivityEntitySchemaUId;
		}

		/// <summary>
		/// Creates entity of the Activity.
		/// </summary>
		/// <returns>A new instance of the entity.</returns>
		public Entity CreateTechnicalActivity() {
			return CreateTechnicalActivity(false);
		}

		/// <summary>
		/// Returns instance of the Activity schema.
		/// </summary>
		/// <returns>Activity schema.</returns>
		public virtual CoreEntitySchema GetActivityEntitySchema() {
			return UserConnection.EntitySchemaManager.GetInstanceByName("Activity");
		}

		/// <summary>
		/// Determines whether the current process element is executed.
		/// </summary>
		/// <returns></returns>
		public virtual bool GetIsExecuted() {
			var select =
				(Select)new Select(UserConnection)
					.Column("Id")
				.From(EntitySchema.Name).WithHints(Hints.NoLock)
				.Where("Id").IsEqual(Column.Parameter(RecordId));
			using (DBExecutor dbExecutor = UserConnection.EnsureDBConnection()) {
				using (IDataReader dataReader = select.ExecuteReader(dbExecutor)) {
					return dataReader.Read();
				}
			}
		}

		/// <inheritdoc />
		public IDictionary<string, object> GetExtraDataValues() {
			return new Dictionary<string, object> {
				{ ProcessElementExtraDataKeys.UserTaskEntitySchemaNameKey, EntitySchema.Name }
			};
		}

		#endregion

	}

	#endregion

	#region Class: OpenEditPageUserTaskSchemaExtension

	/// <exclude/>
	public class OpenEditPageUserTaskSchemaExtension : ProcessUserTaskSchemaExtension
	{

		#region Methods: Public

		public override Dictionary<Guid, string> GetResultParameterAllValues(UserConnection userConnection,
				ProcessSchemaUserTask schemaUserTask) {
			var conditionValues = new Dictionary<Guid, string>();
			ProcessSchemaParameterCollection parameters = schemaUserTask.Parameters;
			ProcessSchemaParameter metaPath = parameters.GetByName("DecisionalColumnMetaPath");
			if (string.IsNullOrEmpty(metaPath.SourceValue.Value)) {
				return conditionValues;
			}
			ProcessSchemaParameter objectSchemaId = parameters.GetByName("ObjectSchemaId");
			EntitySchemaManager entitySchemaManager = userConnection.EntitySchemaManager;
			var entitySchemaUId = new Guid(objectSchemaId.SourceValue.Value);
			EntitySchema entitySchema = entitySchemaManager.GetInstanceByUId(entitySchemaUId);
			EntitySchemaColumn column = entitySchema.GetSchemaColumnByMetaPath(metaPath.SourceValue.Value);
			var esq = new EntitySchemaQuery(column.ReferenceSchema) {
				UseAdminRights = false
			};
			EntitySchemaQueryColumn primaryColumn = esq.AddColumn(column.ReferenceSchema.PrimaryColumn.Name);
			EntitySchemaQueryColumn displayColumn = esq.AddColumn(column.ReferenceSchema.PrimaryDisplayColumn.Name);
			EntityCollection entities = esq.GetEntityCollection(userConnection);
			foreach (Entity entity in entities) {
				EntitySchemaColumnCollection columns = entity.Schema.Columns;
				string columnValueName = columns.GetByName(primaryColumn.Name).ColumnValueName;
				Guid primaryValue = entity.GetTypedColumnValue<Guid>(columnValueName);
				string displayValue = entity.GetTypedColumnValue<string>(
					columns.GetByName(displayColumn.Name).ColumnValueName);
				conditionValues[primaryValue] = displayValue;
			}
			return conditionValues;
		}

		/// <inheritdoc />
		public override void SynchronizeDynamicParameters(UserConnection userConnection, ProcessUserTaskSchema target) {
			base.SynchronizeDynamicParameters(userConnection, target);
			ProcessUserTaskUtilities.SynchronizeActivityConnectionParameters(userConnection, target);
		}

		/// <inheritdoc />
		public override void AnalyzePackageDependencies(ProcessSchemaUserTask schemaElement,
				IProcessSchemaPackageDependencyReporter dependencyReporter) {
			base.AnalyzePackageDependencies(schemaElement, dependencyReporter);
			AnalyzeActivityColumnDependencies(schemaElement, dependencyReporter);
		}

		#endregion

	}

	#endregion

}
