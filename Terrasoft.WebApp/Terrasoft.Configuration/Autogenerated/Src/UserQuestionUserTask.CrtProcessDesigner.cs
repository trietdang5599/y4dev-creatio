namespace Terrasoft.Core.Process.Configuration
{
	using System;
	using System.Collections.Generic;
	using Newtonsoft.Json;
	using Terrasoft.Common;
	using Terrasoft.Configuration;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Process;

	#region Class: UserQuestionUserTask

	/// <summary>
	/// Represents user dialog which is a one of the process interactive element.
	/// </summary>
	public partial class UserQuestionUserTask : IUserTaskActivityInfo
	{

		#region Properties: Private

		private bool CreateActivityFix => CreateActivity || !(Owner is ProcessComponentSet);

		#endregion

		#region Methods: Private

		private List<Dictionary<string, object>> GetDecisionOptionItems() {
			LocalizableParameterValuesList decisionOptionItems = null;
			if (BranchingDecisions.Value.IsNotNullOrEmpty()) {
				Process process = Owner;
				ProcessSchema processSchema = process.ProcessSchema;
				string resourceManagerName = processSchema.OwnerSchema == null
					? processSchema.GetResourceManagerName()
					: processSchema.OwnerSchema.GetResourceManagerName();
				ProcessSchemaBaseElement element = processSchema.GetBaseElementByUId(SchemaElementUId);
				string resourceItemName = "BaseElements." + element.Name + ".Parameters.BranchingDecisions.Value";
				var localizableString = new LocalizableString(Storage, resourceManagerName, resourceItemName);
				string value = localizableString.Value;
				if (value.IsNotNullOrEmpty()) {
					decisionOptionItems = LocalizableParameterValuesList.DeserializeFrom77FormatData(value, "Caption");
				} else {
					decisionOptionItems = LocalizableParameterValuesList.DeserializeData(BranchingDecisions.Value);
					decisionOptionItems.SetupDefaultLocalizableValues("Caption", NoCaptionLocalizableString.Value);
				}
			}
			return decisionOptionItems?.To77FormatList();
		}

		private bool CreateTechnicalActivityIfNeeded() {
			if (!CreateActivityFix) {
				return false;
			}
			bool isRedo = GlobalAppSettings.FeatureResetParameterValuesBeforeReExecuteProcessElement &&
				Status == ProcessStatus.Error && CurrentActivityId.IsEmpty() &&
				!ProcessUserTaskUtilities.GetIsActivityCreated(UserConnection, UId);
			bool activityExists = CurrentActivityId.IsNotEmpty() && !IsActivityCompleted;
			if (!activityExists || isRedo) {
				CreateTechnicalActivity();
			}
			return activityExists;
		}

		#endregion

		#region Methods: Protected

		/// <inheritdoc />
		protected override bool InternalExecute(ProcessExecutingContext context) {
			bool canSkipPerformerCheck = CreateTechnicalActivityIfNeeded();
			InteractWithUser(context, canSkipPerformerCheck, ShowExecutionPage);
			return false;
		}

		/// <inheritdoc />
		protected override void WriteExecutionData(IProcessExecutionDataWriter dataWriter) {
			base.WriteExecutionData(dataWriter);
			dataWriter.Write("urlToken", "ProcessCardModuleV2/UserQuestionProcessPageV2");
			dataWriter.Write("recommendation", GetActivityTitle());
			string informationOnStep = LocalizableString.IsNullOrEmpty(InformationOnStep)
				? GetParameterValue("InformationOnStep")?.ToString() ?? string.Empty
				: InformationOnStep.Value;
			dataWriter.Write("informationOnStep", informationOnStep);
			dataWriter.Write("activityRecordId", CurrentActivityId);
			dataWriter.Write("questionText", Question.ToString());
			dataWriter.Write("decisionMode", DecisionMode);
			dataWriter.Write("isDecisionRequired", IsDecisionRequired);
			List<Dictionary<string, object>> decisionOptionItems = GetDecisionOptionItems();
			dataWriter.WriteObject("decisionOptions", decisionOptionItems, false);
			dataWriter.Write("executionContext", ExecutionContext);
			dataWriter.Write("nextProcElUId", "nextProcElUIdValue");
		}

		#endregion

		#region Methods: Public

		/// <inheritdoc />
		public override bool CompleteExecuting(params object[] parameters) {
			if (CurrentActivityId.IsEmpty()) {
				return base.CompleteExecuting(parameters);
			}
			this.SynchronizeCompletedUserTaskActivity(new UserTaskActivitySyncOptions {
				RemoveListener = true,
				SynchronizeParameterValues = false
			});
			return base.CompleteExecuting(parameters);
		}

		/// <inheritdoc />
		public override void CancelExecuting(params object[] parameters) {
			base.CancelExecuting(parameters);
			if (CurrentActivityId.IsNotEmpty()) {
				IProcessEngine processEngine = UserConnection.IProcessEngine;
				processEngine.RemoveActivityProcessListener(CurrentActivityId, UId, ActivityConsts.CanceledStatusUId);
			}
		}

		/// <inheritdoc />
		public override string GetResultAllowedValues() {
			Dictionary<Guid, string> resultAllowedValues = GetResultParameterAllowedValues();
			return JsonConvert.SerializeObject(resultAllowedValues, Formatting.None);
		}

		/// <inheritdoc />
		public override ProcessElementNotification GetNotificationData() {
			ProcessElementNotification notification = base.GetNotificationData();
			ProcessUserTaskUtilities.AssignNotificationData(notification, Recommendation, StartIn, StartInPeriod);
			return notification;
		}

		/// <summary>
		/// Returns date and time with the specified offset period.
		/// </summary>
		/// <param name="dateTime">Date time.</param>
		/// <param name="offset">Offset value.</param>
		/// <param name="offsetPeriod">Offset period.</param>
		/// <returns>Modified date and time.</returns>
		public virtual DateTime GetDateTime(DateTime dateTime, int offset, ProcessDurationPeriod offsetPeriod) {
			return BaseProcessUserTaskUtilities.AddOffsetToDate(dateTime, offset, offsetPeriod);
		}

		public virtual string GetActivityTitle() {
			return ProcessUserTaskUtilities.GetActivityTitle(this, Recommendation, CurrentActivityId);
		}

		public virtual string GetConditionData(Guid resultColumnUId, Entity activity) {
			return ProcessUserTaskUtilities.GetConditionData(UserConnection, resultColumnUId, activity);
		}

		public virtual Guid GetActivityEntitySchemaUId() {
			return ActivityConsts.ActivityEntitySchemaUId;
		}

		public Entity CreateTechnicalActivity() {
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
			AfterActivitySaveScriptExecute(activity);
			return activity;
		}

		#endregion

	}

	#endregion

	#region Class: UserQuestionUserTaskSchemaExtension

	/// <exclude/>
	public class UserQuestionUserTaskSchemaExtension : ProcessUserTaskSchemaExtension
	{

		#region Methods: Public

		/// <inheritdoc />
		public override Dictionary<Guid, string> GetResultParameterAllValues(UserConnection userConnection,
				ProcessSchemaUserTask schemaUserTask) {
			var conditionValues = new Dictionary<Guid, string>();
			ProcessSchemaParameterCollection parameters = schemaUserTask.Parameters;
			ProcessSchemaParameter branchingDecisionsParameter = parameters.GetByName("BranchingDecisions");
			ProcessSchemaParameterValue sourceValue = branchingDecisionsParameter.SourceValue;
			LocalizableParameterValuesList items = sourceValue.LocalizableCollectionValue;
			if (items == null) {
				items = new LocalizableParameterValuesList();
			} else {
				items.SetupDefaultLocalizableValues("Caption", "No caption");
			}
			foreach (LocalizableParameterValues item in items) {
				conditionValues[new Guid(item["Id"].Value)] = item["Caption"].Value;
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
