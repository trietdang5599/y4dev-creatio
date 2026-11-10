namespace Terrasoft.Core.Process.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using Terrasoft.Common;
	using Terrasoft.Configuration;
	using Terrasoft.Core;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Process;

	#region Class: ActivityUserTask

	public partial class ActivityUserTask : IUserTaskActivityInfo, IProcessElementExtraDataBuilder
	{

		#region Methods: Protected

		/// <inheritdoc />
		protected override bool InternalExecute(ProcessExecutingContext context) {
			if (GlobalAppSettings.FeatureResetParameterValuesBeforeReExecuteProcessElement &&
					Status == ProcessStatus.Error) {
				if (CurrentActivityId == Guid.Empty &&
						!ProcessUserTaskUtilities.GetIsActivityCreated(UserConnection, UId)) {
					Entity activity = CreateActivity();
					AfterActivitySaveScriptExecute(activity);
				}
			}
			bool isRunning = CurrentActivityId.IsNotEmpty() && !IsActivityCompleted;
			if (!isRunning) {
				Entity activity = CreateActivity();
				AfterActivitySaveScriptExecute(activity);
			}
			InteractWithUser(context, isRunning, ShowExecutionPage);
			return false;
		}

		#endregion

		#region Methods: Public

		public virtual Guid GetActivityType() {
			var select = (Select)new Select(UserConnection)
				.Column("Id")
				.From("ActivityType")
				.Where("Code").IsEqual(Column.Parameter("Activity"));
			using (DBExecutor dbExecutor = UserConnection.EnsureDBConnection()) {
				using (IDataReader dr = select.ExecuteReader(dbExecutor)) {
					if (dr.Read()) {
						return UserConnection.DBTypeConverter.DBValueToGuid(dr[0]);
					}
				}
			}
			return Guid.Empty;
		}

		public virtual DateTime NewDate(DateTime oldDate, int offset, ProcessDurationPeriod offsetPeriod) {
			switch (offsetPeriod) {
				default:
					return oldDate.AddMinutes(offset);
				case ProcessDurationPeriod.Hours:
					return oldDate.AddHours(offset);
				case ProcessDurationPeriod.Days:
					return oldDate.AddDays(offset);
				case ProcessDurationPeriod.Weeks:
					return oldDate.AddDays(offset * 7);
				case ProcessDurationPeriod.Months:
					return oldDate.AddMonths(offset);
			}
		}

		/// <inheritdoc />
		public override bool CompleteExecuting(params object[] parameters) {
			var activity = parameters[0] as Activity;
			this.SynchronizeCompletedUserTaskActivity(new UserTaskActivitySyncOptions {
				UseEntityComplete = true,
				Activity = activity,
				RemoveListener = false
			});
			return base.CompleteExecuting(parameters);
		}

		public virtual string GetConditionData(Guid resultColumnUId, Entity activity) {
			return ProcessUserTaskUtilities.GetConditionData(UserConnection, resultColumnUId, activity);
		}

		public virtual string GetActivityTitle() {
			return ProcessUserTaskUtilities.GetActivityTitle(this, Recommendation, CurrentActivityId);
		}

		/// <inheritdoc />
		public override void CancelExecuting(params object[] parameters) {
			base.CancelExecuting(parameters);
			UserConnection.IProcessEngine
				.RemoveActivityProcessListener(CurrentActivityId, UId, ActivityConsts.CanceledStatusUId);
		}

		/// <inheritdoc />
		protected override void WriteExecutionData(IProcessExecutionDataWriter dataWriter) {
			base.WriteExecutionData(dataWriter);
			dataWriter.Write("entitySchemaName", "Activity");
			dataWriter.Write("activityRecordId", CurrentActivityId);
			dataWriter.Write("pageTypeId", ActivityConsts.TaskTypeUId);
			dataWriter.Write("nextProcElUId", "nextProcElUIdValue");
			dataWriter.Write("allowedResults",
				ProcessUserTaskUtilities.GetAllowedActivityResults(UserConnection, CurrentActivityId));
			dataWriter.Write("executionContext", ExecutionContext);
			dataWriter.Write("recommendation", GetActivityTitle());
			dataWriter.Write("informationOnStep", GetParameterValue("InformationOnStep", string.Empty));
		}

		/// <inheritdoc />
		public override string GetExecutionData() {
			if (UserConnection.GetIsFeatureEnabled("UseProcessPerformerAssignment")) {
				return base.GetExecutionData();
			}
			var element = (IProcessElementMetaInfo)GetSchemaElement();
			ProcessSchemaParameter informationOnStepParameter = element.Parameters.GetByName("InformationOnStep");
			object informationOnStep = GetParameterValue(informationOnStepParameter) ?? string.Empty;
			return SerializeToString(new {
				procElUId = UId,
				name = Name,
				processId = ProcessUserTaskUtilities.GetParentProcessId(Owner),
				isProcessExecutedBySignal = ProcessUserTaskUtilities.GetIsProcessExecutedBySignal(Owner),
				processName = Owner.Name,
				entitySchemaName = "Activity",
				recommendation = GetActivityTitle(),
				informationOnStep = informationOnStep.ToString(),
				pageTypeId = ActivityConsts.TaskTypeUId,
				activityRecordId = CurrentActivityId,
				executionContext = ExecutionContext,
				nextProcElUId = "nextProcElUIdValue",
				allowedResults = ProcessUserTaskUtilities.GetAllowedActivityResults(UserConnection, CurrentActivityId)
			});
		}

		public virtual Guid GetActivityEntitySchemaUId() {
			return ActivityConsts.ActivityEntitySchemaUId;
		}

		public Entity CreateActivity() {
			if (ActivityCategory.IsEmpty()) {
				ActivityCategory = ActivityConsts.TaskCategoryId;
			}
			var info = new UserTaskActivityInfo {
				Title = GetActivityTitle(),
				TypeId = ActivityConsts.TaskTypeUId,
				StartOffset = new ProcessDateOffset(StartIn, (ProcessDurationPeriod)StartInPeriod),
				Duration = new ProcessDateOffset(Duration, (ProcessDurationPeriod)DurationPeriod),
				RemindOffset = new ProcessDateOffset(RemindBefore, (ProcessDurationPeriod)RemindBeforePeriod),
				PriorityId = ActivityPriority
			};
			Entity activity = this.CreateUserTaskActivity(info);
			IsActivityCompleted = false;
			CurrentActivityId = activity.PrimaryColumnValue;
			return activity;
		}

		/// <inheritdoc />
		public override ProcessElementNotification GetNotificationData() {
			ProcessElementNotification notification = base.GetNotificationData();
			ProcessUserTaskUtilities.AssignNotificationData(notification, Recommendation, StartIn, StartInPeriod);
			return notification;
		}

		/// <inheritdoc />
		public IDictionary<string, object> GetExtraDataValues() {
			return new Dictionary<string, object> {
				{ ProcessElementExtraDataKeys.UserTaskEntitySchemaNameKey, "Activity"}
			};
		}

		#endregion

	}

	#endregion

	#region Class: ActivityUserTaskSchemaExtension

	/// <inheritdoc />
	public class ActivityUserTaskSchemaExtension : ProcessUserTaskSchemaExtension
	{

		#region Methods: Public

		/// <inheritdoc />
		public override Dictionary<Guid, string> GetResultParameterAllValues(UserConnection userConnection,
				ProcessSchemaUserTask schemaUserTask) {
			var results = new Dictionary<Guid, string>();
			ProcessSchemaParameter paramActivityCategory = schemaUserTask.Parameters.GetByName("ActivityCategory");
			string taskActivityCategoryId = "F51C4643-58E6-DF11-971B-001D60E938C6";
			if (paramActivityCategory.SourceValue.Source == ProcessSchemaParameterValueSource.ConstValue) {
				taskActivityCategoryId = paramActivityCategory.SourceValue.Value;
			}
			var select = (Select)new Select(userConnection).Distinct()
					.Column("ActivityResult", "Id")
					.Column("ActivityResult", "Name")
				.From("ActivityResult").WithHints(Hints.NoLock)
				.Join(JoinType.Inner, "ActivityCategoryResultEntry")
					.On("ActivityResult", "Id").IsEqual("ActivityCategoryResultEntry", "ActivityResultId")
				.Where("ActivityCategoryResultEntry", "ActivityCategoryId")
					.IsEqual(Column.Parameter(taskActivityCategoryId, "Guid"));
			using (DBExecutor dbExecutor = userConnection.EnsureDBConnection()) {
				using (IDataReader dr = select.ExecuteReader(dbExecutor)) {
					while (dr.Read()) {
						results.Add(userConnection.DBTypeConverter.DBValueToGuid(dr[0]), dr.GetString(1));
					}
				}
			}
			return results;
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
			AnalyzeEntityColumnDependencies(schemaElement, dependencyReporter, "Activity");
		}

		#endregion

	}

	#endregion

}
