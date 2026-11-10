namespace Terrasoft.Core.Process.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Dynamic;
	using System.Linq;
	using Creatio.FeatureToggling;
	using Terrasoft.Common;
	using Terrasoft.Configuration;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Process;
	using Terrasoft.Nui.ServiceModel.Extensions;
	using CoreEntitySchemaColumn = Terrasoft.Core.Entities.EntitySchemaColumn;
	using EntityCollection = Terrasoft.Core.Entities.EntityCollection;
	using EntitySchema = Terrasoft.Core.Entities.EntitySchema;
	using Utilities = Terrasoft.Configuration.ProcessUserTaskUtilities;

	#region Class: PreconfiguredPageUserTask

	/// <summary>
	/// Represents preconfigured page which is a one of the process interactive element.
	/// </summary>
	public partial class PreconfiguredPageUserTask : IUserTaskActivityInfo
	{

		#region Class: AllowSkipValidation

		/// <summary>
		/// Indicates whether to allow skipping of validation during completion of the page.
		/// </summary>
		/// <inheritdoc cref="Creatio.FeatureToggling.FeatureMetadata" />
		public class AllowSkipValidation: FeatureMetadata
		{

			#region Constructors: Public

			/// <summary>
			/// Initializes a new instance of the <see cref="AllowSkipValidation" /> type.
			/// </summary>
			public AllowSkipValidation() {
				Description = "Allow skipping of validation during completion of the page.";
				IsEnabled = true;
			}

			#endregion

		}

		#endregion

		#region Class: DataSourceParameterInfo

		private class DataSourceParameterInfo
		{

			#region Properties: Public

			public string ParameterName { get; set; }
			public string DataSourceName { get; set; }
			public string DataSourceAttributeName { get; set; }

			#endregion

		}

		#endregion

		#region Constants: Private

		private const string Action = "add";
		private const string DefUrlTemplate = "[Module]/[Page]/" + Action;
		private const string DataSourceParameterTagPrefix = "DataSource";
		private const string UncomputedColumnName = "PrimaryColumnValue";

		#endregion

		#region Properties: Private

		private ClientUnitSchemaManager ClientUnitSchemaManager => UserConnection.ClientUnitSchemaManager;

		private EntitySchemaManager EntitySchemaManager => UserConnection.EntitySchemaManager;

		#endregion

		#region Methods: Private

		private static ExpandoObject GetClientLookupLinkValue(Entity entity, CoreEntitySchemaColumn pageTypeColumn) {
			var value = new ExpandoObject() as IDictionary<string, object>;
			value.Add("value", entity.PrimaryColumnValue.ToString());
			value.Add("displayValue", entity.PrimaryDisplayColumnValue);
			if (pageTypeColumn != null) {
				value.Add(pageTypeColumn.Name, new {
					value = entity.GetTypedColumnValue<Guid>(pageTypeColumn.ColumnValueName)
				});
			}
			return (ExpandoObject)value;
		}

		private static bool GetIsAngularSchema(ISchemaManagerItem<ClientUnitSchema> schemaManagerItem) {
			return schemaManagerItem.GetPropertyValue(p => p.SchemaType) == ClientUnitSchemaType.AngularSchema;
		}

		private static DataSourceParameterInfo GetDataSourceParameterInfo(ParameterValueDescriptor valueDescriptor) {
			string[] tagParts = valueDescriptor.Tag.Split(':');
			if (tagParts.Length != 3) {
				return null;
			}
			string dataSourcePrefixPart = tagParts[0];
			string dataSourceNamePart  = tagParts[1];
			if (dataSourcePrefixPart != DataSourceParameterTagPrefix) {
				return null;
			}
			return new DataSourceParameterInfo {
				ParameterName = valueDescriptor.Name,
				DataSourceName = dataSourceNamePart,
				DataSourceAttributeName = tagParts[2]
			};
		}

		private static ModelInitConfig CreateModelInitConfig(ParameterValueDescriptor valueDescriptor) {
			return new ModelInitConfig {
				Name = GetDataSourceParameterInfo(valueDescriptor)?.DataSourceName,
				ModelInPageAction = ModelInPageAction.Edit,
				RecordId = (Guid)valueDescriptor.Value
			};
		}

		private string GetEntitySchemaName(Guid uid) {
			return uid.IsEmpty() ? string.Empty : EntitySchemaManager.GetItemByUId(uid).Name;
		}

		private string GetUrlToken(string pageName) {
			var module = ClientUnitSchemaManager.FindItemByUId(Module);
			string moduleName = module?.Name ?? "ProcessCardModuleV2";
			string template = Url.IsNullOrEmpty() ? DefUrlTemplate : Url;
			return template.Replace("[Module]", moduleName).Replace("[Page]", pageName);
		}

		private object GetParameterLookupValue(ProcessSchemaParameter parameter,
				IReadOnlyDictionary<Guid, Guid> sysModuleEntityPageType) {
			object value = GetParameterValue(parameter);
			var primaryColumnValue = (Guid?)value;
			if (primaryColumnValue?.IsEmpty() != false) {
				return null;
			}
			if (parameter.ParentMetaSchema == null) {
				parameter.ParentMetaSchema = Owner.Schema;
				Log.Warn("[PreconfiguredPageUserTask]. Parameter metadata modified at runtime.");
			}
			EntitySchema referenceSchema = parameter.ReferenceSchema;
			if (referenceSchema.PrimaryDisplayColumn == null) {
				return new {
					value = primaryColumnValue.Value.ToString()
				};
			}
			Entity entity = referenceSchema.CreateEntity(UserConnection);
			entity.UseAdminRights = false;
			var columnsToFetch = new Collection<CoreEntitySchemaColumn> {
				referenceSchema.PrimaryColumn,
				referenceSchema.PrimaryDisplayColumn,
			};
			var hasPageTypeColumn = sysModuleEntityPageType.ContainsKey(referenceSchema.UId);
			CoreEntitySchemaColumn pageTypeColumn = null;
			if (hasPageTypeColumn) {
				Guid typeColumnUId = sysModuleEntityPageType[referenceSchema.UId];
				pageTypeColumn = referenceSchema.Columns.FindByUId(typeColumnUId);
				if (pageTypeColumn != null) {
					columnsToFetch.Add(pageTypeColumn);
				}
			}
			bool isFetched = entity.FetchFromDB(referenceSchema.PrimaryColumn, primaryColumnValue.Value, columnsToFetch,
				false);
			if (!isFetched) {
				Log.Warn($"Could not initialize lookup value for parameter {parameter.Name} " +
					$"of the element {this} due to value {primaryColumnValue.Value} does not exist " +
					$"in the object {referenceSchema.Name}");
				return null;
			}
			ExpandoObject lookupValue = GetClientLookupLinkValue(entity, pageTypeColumn);
			return lookupValue;
		}

		private Dictionary<Guid,Guid> GetLegacySysModuleEntityPageTypes() {
			var result = new Dictionary<Guid,Guid>();
			var esq = new EntitySchemaQuery(EntitySchemaManager, "SysModuleEntity") {
				IgnoreDisplayValues = true,
				UseAdminRights = false,
				UseLocalization = false
			};
			esq.AddColumn("SysEntitySchemaUId");
			esq.AddColumn("TypeColumnUId");
			EntityCollection entityCollection = esq.GetEntityCollection(UserConnection);
			entityCollection.ForEach(e => {
				var sysEntitySchemaUId = e.GetTypedColumnValue<Guid>("SysEntitySchemaUId");
				var typeColumnUId = e.GetTypedColumnValue<Guid>("TypeColumnUId");
				result[sysEntitySchemaUId] = typeColumnUId;
			});
			return result;
		}

		private object GetParameterDateTimeValue(ProcessSchemaParameter parameter) {
			object value = GetParameterValue(parameter);
			if (value == null) {
				return null;
			}
			var dateTime = (DateTime)value;
			if (dateTime == DateTime.MinValue) {
				return null;
			}
			if (dateTime.Kind == DateTimeKind.Local) {
				value = DateTime.SpecifyKind(dateTime, DateTimeKind.Unspecified);
			}
			var dataValueType = (DateTimeDataValueType)parameter.DataValueType;
			return new {
				dataValueType = (int)dataValueType.ToEnum(),
				value = DateTimeDataValueType.Serialize(value, TimeZoneInfo.Utc)
			};
		}

		private void FillPageParametersLookupValues(IDictionary<string, object> parametersValues,
				IList<ProcessSchemaParameter> lookupSchemaParameters) {
			if (lookupSchemaParameters.Count == 0) {
				return;
			}
			Dictionary<Guid, Guid> sysModuleEntityPageType =
				Features.GetIsEnabled("LegacyLoadingOfProcessPageLookupsTypedColumnValues")
					? GetLegacySysModuleEntityPageTypes()
					: new Dictionary<Guid, Guid>();
			lookupSchemaParameters.ForEach(p => parametersValues
				.Add(p.Name, GetParameterLookupValue(p, sysModuleEntityPageType)));
		}

		private ProcessSchemaParameterCollection GetParameters(ProcessSchema processSchema) {
			var userTask = (ProcessSchemaUserTask)processSchema.GetBaseElementByUId(SchemaElementUId);
			return userTask.Parameters;
		}

		private Dictionary<string, object> GetPageParametersValues(ProcessSchemaParameterCollection parameters,
				Guid schemaUId, bool useLookupValues, bool skipButtons = false) {
			var result = new Dictionary<string, object>();
			var lookupSchemaParameters = new List<ProcessSchemaParameter>();
			foreach (ProcessSchemaParameter schemaParameter in parameters) {
				if (schemaParameter.CreatedInSchemaUId != schemaUId) {
					continue;
				}
				if (skipButtons && schemaParameter.Name == "Buttons") {
					continue;
				}
				DataValueType dataValueType = schemaParameter.DataValueType;
				if (useLookupValues && dataValueType.IsLookup) {
					lookupSchemaParameters.Add(schemaParameter);
					continue;
				}
				object parameterValue = dataValueType.IsDateTime
					? GetParameterDateTimeValue(schemaParameter)
					: GetParameterValue(schemaParameter);
				result.Add(schemaParameter.Name, parameterValue); 
			}
			FillPageParametersLookupValues(result, lookupSchemaParameters);
			return result;
		}

		private Dictionary<string, object> GetAttributes() {
			var result = new Dictionary<string, object>();
			ClientUnitSchema instance = ClientUnitSchemaManager.GetInstanceByUId(ClientUnitSchemaUId);
			ClientUnitSchemaParameterCollection parameters = instance.Parameters;
			parameters.ForEach(p => {
				var precision = (p.DataValueType as FloatDataValueType)?.Precision;
				var value = new {
					caption = p.Caption?.Value,
					dataValueType = (int)p.DataValueType.ToEnum(),
					isLookup = p.DataValueType.IsLookup,
					referenceSchemaName = GetEntitySchemaName(p.ReferenceSchemaUId),
					isRequired = p.IsRequired,
					precision,
					isProcessUserTaskParameterAttribute = true
				};
				result.Add(p.Name, value);
			});
			return result;
		}

		private string GetActivityTitle() {
			return ProcessUserTaskUtilities.GetActivityTitle(this, Recommendation, CurrentActivityId);
		}

		private void CreateTechnicalActivity() {
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
		}

		private bool CreateTechnicalActivityIfNeeded() {
			if (!CreateActivity) {
				return IsRunning;
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

		private static bool GetPerformValidation(LocalizableParameterValues button) {
			if (Features.GetIsDisabled<AllowSkipValidation>()) {
				return true;
			}
			if (!button.TryGetValue("PerformValidation", out var performValidationValue)) {
				return true;
			}
			string raw = performValidationValue?.Value;
			if (!raw.IsNullOrEmpty() && bool.TryParse(raw, out bool parsed)) {
				return parsed;
			}
			return true;
		}

		private CompletionInfo GetCompletionInfo() {
			string buttonsValueString = GetParameterValue("Buttons", string.Empty);
			LocalizableParameterValuesList buttons =
				LocalizableParameterValuesList.DeserializeData(buttonsValueString) ??
				new LocalizableParameterValuesList();
			CompletionHandler[] completionHandlers = buttons
				.Where(button => bool.Parse(button["PerformClosePage"].Value))
				.Select(button => new CompletionHandler {
					Name = button["Name"].Value,
					Tag = button["Tag"].Value,
					Event = button["Event"].Value,
					PerformValidation = GetPerformValidation(button)
				}).ToArray();
			return new CompletionInfo {
				Handlers = completionHandlers,
				ParameterName = nameof(PressedButtonCode)
			};
		}

		private IEnumerable<ParameterValueDescriptor> FindDataSourceParameters() {
			return FindParameterValuesByTag(t => t?.StartsWith(DataSourceParameterTagPrefix));
		}

		private List<ModelInitConfig> GetModelInitConfigs() {
			return FindDataSourceParameters()
				.Where(p => p.IsValueDefined)
				.Select(CreateModelInitConfig)
				.ToList();
		}

		private void WriteOutputParametersInfo(IProcessExecutionDataWriter dataWriter,
				ProcessSchemaParameterCollection parameters) { 
			var parameterInfos = FindDataSourceParameters()
				.Select(GetDataSourceParameterInfo)
				.Select(info => ProcessDataSourceAttributeName(info, parameters));
			dataWriter.WriteObject("outputParameterInfos", parameterInfos);
		}

		private DataSourceParameterInfo ProcessDataSourceAttributeName(DataSourceParameterInfo parameterInfo,
				ProcessSchemaParameterCollection parameters) {
			if (!parameterInfo.DataSourceAttributeName
					.Equals(UncomputedColumnName, StringComparison.InvariantCultureIgnoreCase)) {
				return parameterInfo;
			}
			ProcessSchemaParameter parameter = parameters.FindByName(parameterInfo.ParameterName);
			if (!parameter?.DataValueType.IsLookup ?? false) {
				return parameterInfo;
			}
			var entitySchema = EntitySchemaManager.FindInstanceByUId(parameter.ReferenceSchemaUId);
			parameterInfo.DataSourceAttributeName =
				entitySchema?.PrimaryColumn.Name ?? parameterInfo.DataSourceAttributeName;
			return parameterInfo;
		}

		#endregion

		#region Methods: Protected

		/// <inheritdoc/>
		protected override bool InternalExecute(ProcessExecutingContext context) {
			if (EntryPointId.IsEmpty()) {
				EntryPointId = Utilities.AddProcessEntryPoint(UserConnection, EntitySchemaUId, EntityId, UId);
			}
			bool canSkipPerformerCheck = CreateTechnicalActivityIfNeeded();
			InteractWithUser(context, canSkipPerformerCheck, ShowExecutionPage);
			IsRunning = true;
			return false;
		}

		/// <inheritdoc />
		protected override void WriteExecutionData(IProcessExecutionDataWriter dataWriter) {
			base.WriteExecutionData(dataWriter);
			var page = ClientUnitSchemaManager.GetItemByUId(ClientUnitSchemaUId);
			string recommendation = LocalizableString.IsNullOrEmpty(Recommendation)
				? GetParameterValue("Recommendation")?.ToString() ?? string.Empty
				: Recommendation.Value;
			dataWriter.Write("recommendation", recommendation);
			string informationOnStep = LocalizableString.IsNullOrEmpty(InformationOnStep)
				? GetParameterValue("InformationOnStep")?.ToString() ?? string.Empty
				: InformationOnStep.Value;
			dataWriter.Write("informationOnStep", informationOnStep);
			dataWriter.Write("activityRecordId", CurrentActivityId);
			dataWriter.Write("header", Title.Value);
			dataWriter.Write("pageCaption", page.Caption.ToString());
			dataWriter.Write("nextProcElUId", "nextProcElUIdValue");
			dataWriter.Write("urlToken", GetUrlToken(page.Name));
			dataWriter.Write("recordId", EntityId);
			dataWriter.Write("preconfiguredPage", true);
			dataWriter.Write("action", Action);
			var processSchema = (ProcessSchema)Owner.Schema;
			var parameters = GetParameters(processSchema);
			if (GetIsAngularSchema(page)) {
				dataWriter.WriteObject("parameters", GetPageParametersValues(parameters, processSchema.UId, false, true));
				CompletionInfo completionInfo = GetCompletionInfo();
				dataWriter.WriteObject("completionInfo", completionInfo);
				dataWriter.WriteObject("modelInitConfigs", GetModelInitConfigs());
				WriteOutputParametersInfo(dataWriter, parameters);
			} else {
				bool isInheritedFromTemplate = ClientUnitSchemaManager.IsInheritedFrom(ClientUnitSchemaUId, Template);
				dataWriter.WriteObject("parameters",
					GetPageParametersValues(parameters, processSchema.UId, isInheritedFromTemplate));
				dataWriter.WriteObject("attributes", isInheritedFromTemplate ? GetAttributes() : null);
			}
		}

		#endregion

		#region Methods: Public

		/// <inheritdoc/>
		public override bool CompleteExecuting(params object[] parameters) {
			Utilities.DeactivateProcessEntryPoint(UserConnection, EntryPointId, EntitySchemaUId, EntityId);
			if (CurrentActivityId.IsNotEmpty()) {
				this.SynchronizeCompletedUserTaskActivity(new UserTaskActivitySyncOptions {
					RemoveListener = true,
					SynchronizeParameterValues = false
				});
			}
			GenerateSignal();
			return base.CompleteExecuting(parameters);
		}

		/// <inheritdoc/>
		public override void CancelExecuting(params object[] parameters) {
			Utilities.DeactivateProcessEntryPoint(UserConnection, EntryPointId, EntitySchemaUId, EntityId);
			if (CurrentActivityId.IsNotEmpty()) {
				IProcessEngine processEngine = UserConnection.IProcessEngine;
				processEngine.RemoveActivityProcessListener(CurrentActivityId, UId, ActivityConsts.CanceledStatusUId);
			}
			base.CancelExecuting(parameters);
		}

		/// <inheritdoc/>
		public override ProcessElementNotification GetNotificationData() {
			ProcessElementNotification notification = base.GetNotificationData();
			if (Recommendation != null && Recommendation.HasValue && !Recommendation.Value.IsNullOrEmpty()) {
				notification.Title = Recommendation;
			}
			return notification;
		}

		public virtual void GenerateSignal() {
			if (string.IsNullOrEmpty(PressedButtonCode)) {
				return;
			}
			ProcessSchema processSchema = (ProcessSchema)Owner.Schema;
			var userTask = (ProcessSchemaUserTask)processSchema.GetBaseElementByUId(SchemaElementUId);
			ProcessSchemaParameter buttonsParameter = userTask.Parameters.FindByName("Buttons");
			LocalizableParameterValuesList buttons = buttonsParameter?.SourceValue.LocalizableCollectionValue;
			LocalizableParameterValues pressedButton = buttons?.Find(button => button["Tag"].Value == PressedButtonCode);
			LocalizableParameterValue generateSignalValue = null;
			pressedButton?.TryGetValue("GenerateSignal", out generateSignalValue);
			string generateSignal = generateSignalValue?.Value;
			if (string.IsNullOrEmpty(generateSignal)) {
				return;
			}
			var context = new ProcessExecutingContext(UserConnection) { Process = Owner };
			UserConnection.IProcessEngine.ThrowSignal(context, generateSignal);
		}

		#endregion

	}

	#endregion

	#region Class: PreconfiguredPageUserTaskSchemaExtension

	/// <exclude/>
	public class PreconfiguredPageUserTaskSchemaExtension : ProcessUserTaskSchemaExtension
	{

		#region Methods: Public

		public override Dictionary<Guid, string> GetResultParameterAllValues(UserConnection userConnection,
				ProcessSchemaUserTask schemaUserTask) {
			var conditionValues = new Dictionary<Guid, string>();
			ProcessSchemaParameterValue sourceValue = schemaUserTask.Parameters.GetByName("Buttons").SourceValue;
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
