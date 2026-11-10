namespace Terrasoft.Core.Process
{

	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using Quartz.Impl.Triggers;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Drawing;
	using System.Globalization;
	using System.Text;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Process;
	using Terrasoft.Core.Process.Configuration;
	using Terrasoft.Core.Scheduler;

	#region Class: ContactAgeActualizationJobRestartProcessSchema

	/// <exclude/>
	public class ContactAgeActualizationJobRestartProcessSchema : Terrasoft.Core.Process.ProcessSchema
	{

		#region Constructors: Public

		public ContactAgeActualizationJobRestartProcessSchema(ProcessSchemaManager processSchemaManager)
			: base(processSchemaManager) {
		}

		public ContactAgeActualizationJobRestartProcessSchema(ContactAgeActualizationJobRestartProcessSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			Name = "ContactAgeActualizationJobRestartProcess";
			UId = new Guid("eef8c5e7-6f65-472e-9dff-b6f9abc54191");
			BackgroundModePriority = BackgroundModePriority.Medium;
			CreatedInPackageId = new Guid("42c464a9-9677-4bbd-86c1-308caea3de84");
			CreatedInSchemaUId = Guid.Empty;
			CreatedInVersion = @"0.0.0.0";
			CultureName = null;
			EntitySchemaUId = Guid.Empty;
			IsCreatedInSvg = true;
			ModifiedInSchemaUId = Guid.Empty;
			ParametersEditPageSchemaUId = Guid.Empty;
			ParentSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d");
			SequenceFlowStrokeDefColor = Color.FromArgb(-4473925);
			SerializeToDB = true;
			SerializeToMemory = true;
			Tag = @"Business Process";
			TaskFillDefColor = Color.FromArgb(-1);
			UsageType = ProcessSchemaUsageType.Advanced;
			UseSystemSecurityContext = true;
			ZipMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,157,82,75,79,2,49,16,62,239,254,138,102,79,64,72,131,103,95,33,75,68,76,36,6,80,207,165,12,107,117,183,221,76,167,16,37,252,119,219,5,148,213,149,131,151,38,157,153,175,243,61,90,186,121,174,36,91,25,181,96,19,40,204,10,250,25,244,37,57,145,171,15,65,202,232,59,51,111,181,217,38,142,250,101,57,149,47,176,112,57,32,223,205,134,94,146,26,77,66,82,3,46,233,178,164,161,60,68,227,202,164,125,30,111,227,184,60,218,127,120,125,12,235,38,18,143,22,208,239,210,32,67,133,185,218,181,98,184,18,200,196,49,108,166,10,96,151,108,6,136,194,154,37,241,212,32,248,67,47,85,230,176,26,225,211,119,59,5,34,165,51,203,135,64,79,34,119,112,49,16,4,1,124,213,138,163,168,190,41,104,114,100,10,143,150,63,105,6,136,23,125,64,243,123,165,171,247,188,214,104,71,239,213,204,7,64,66,229,158,86,205,208,20,193,163,30,208,72,176,54,200,245,139,79,90,27,250,127,154,219,61,129,158,56,47,5,247,155,170,201,186,64,254,108,240,205,150,66,2,31,139,2,26,6,82,135,8,154,66,32,213,72,144,23,196,73,244,22,160,202,50,64,47,79,195,154,165,223,149,81,81,230,255,254,44,129,132,37,244,33,241,27,131,222,251,86,210,99,155,222,150,109,206,182,236,154,117,88,199,195,127,69,31,252,119,4,77,157,91,227,176,29,120,215,66,24,105,75,66,123,225,135,82,8,226,43,178,238,177,192,234,251,126,2,253,54,156,14,62,3,0,0 };
			ZipCompiledMethodsBody = new byte[] {  };
			RealUId = new Guid("eef8c5e7-6f65-472e-9dff-b6f9abc54191");
			Version = 0;
			PackageUId = new Guid("06d9ef10-51d8-122c-8933-9212e84236c9");
			UseSystemSecurityContext = true;
		}

		protected override void InitializeParameters() {
			base.InitializeParameters();
		}

		protected override void InitializeBaseElements() {
			base.InitializeBaseElements();
			ProcessSchemaLaneSet schemaLaneSet1 = CreateLaneSet1LaneSet();
			LaneSets.Add(schemaLaneSet1);
			ProcessSchemaLane schemaLane1 = CreateLane1Lane();
			schemaLaneSet1.Lanes.Add(schemaLane1);
			ProcessSchemaTerminateEvent terminateevent1 = CreateTerminateEvent1TerminateEvent();
			FlowElements.Add(terminateevent1);
			ProcessSchemaScriptTask removeoldjobscripttask = CreateRemoveOldJobScriptTaskScriptTask();
			FlowElements.Add(removeoldjobscripttask);
			ProcessSchemaScriptTask schedulenewjobscripttask = CreateScheduleNewJobScriptTaskScriptTask();
			FlowElements.Add(schedulenewjobscripttask);
			ProcessSchemaStartEvent startevent1 = CreateStartEvent1StartEvent();
			FlowElements.Add(startevent1);
			FlowElements.Add(CreateSequenceFlow4SequenceFlow());
			FlowElements.Add(CreateSequenceFlow1SequenceFlow());
			FlowElements.Add(CreateSequenceFlow2SequenceFlow());
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow4SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow4",
				UId = new Guid("9feded6c-1ad9-4fc8-ad68-ab26829b95ca"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("524f976c-dc16-4613-afcd-8360daff9aa0"),
				CreatedInSchemaUId = new Guid("eef8c5e7-6f65-472e-9dff-b6f9abc54191"),
				CurveCenterPosition = new Point(0, 0),
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("eef8c5e7-6f65-472e-9dff-b6f9abc54191"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("9b477604-e16a-4138-babf-dc4d45021576"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("5a8cd4ba-de14-4b74-a9a8-4e3749e90577"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow1SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow1",
				UId = new Guid("c12367c3-452d-4949-bec2-3e771ef47b90"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("0f1116a2-88a9-4a2c-b333-bb375de9976f"),
				CreatedInSchemaUId = new Guid("eef8c5e7-6f65-472e-9dff-b6f9abc54191"),
				CurveCenterPosition = new Point(0, 0),
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("eef8c5e7-6f65-472e-9dff-b6f9abc54191"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("0c19837c-e427-4b2c-95f0-8539375a7de3"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("226ed5c6-81db-464a-a5cc-9ad05b8f46f9"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow2SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow2",
				UId = new Guid("a59cfb8b-9d1f-478c-a486-241344290bf6"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("0f1116a2-88a9-4a2c-b333-bb375de9976f"),
				CreatedInSchemaUId = new Guid("eef8c5e7-6f65-472e-9dff-b6f9abc54191"),
				CurveCenterPosition = new Point(0, 0),
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("eef8c5e7-6f65-472e-9dff-b6f9abc54191"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("226ed5c6-81db-464a-a5cc-9ad05b8f46f9"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("9b477604-e16a-4138-babf-dc4d45021576"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaLaneSet CreateLaneSet1LaneSet() {
			ProcessSchemaLaneSet schemaLaneSet1 = new ProcessSchemaLaneSet(this) {
				UId = new Guid("0a579010-5a4b-4f8b-919a-a841aa7c77c5"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("524f976c-dc16-4613-afcd-8360daff9aa0"),
				CreatedInSchemaUId = new Guid("eef8c5e7-6f65-472e-9dff-b6f9abc54191"),
				Direction = ProcessSchemaPoolDirectionType.Vertical,
				ManagerItemUId = new Guid("11a47caf-a0d5-41fa-a274-a0b11f77447a"),
				ModifiedInSchemaUId = new Guid("eef8c5e7-6f65-472e-9dff-b6f9abc54191"),
				Name = @"LaneSet1",
				Position = new Point(0, 0),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLaneSet1;
		}

		protected virtual ProcessSchemaLane CreateLane1Lane() {
			ProcessSchemaLane schemaLane1 = new ProcessSchemaLane(this) {
				UId = new Guid("7ce62765-1da7-4255-8d55-60a3aeab2b20"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = new Guid("0a579010-5a4b-4f8b-919a-a841aa7c77c5"),
				CreatedInOwnerSchemaUId = new Guid("eef8c5e7-6f65-472e-9dff-b6f9abc54191"),
				CreatedInPackageId = new Guid("524f976c-dc16-4613-afcd-8360daff9aa0"),
				CreatedInSchemaUId = new Guid("eef8c5e7-6f65-472e-9dff-b6f9abc54191"),
				ManagerItemUId = new Guid("abcd74b9-5912-414b-82ac-f1aa4dcd554e"),
				ModifiedInSchemaUId = new Guid("eef8c5e7-6f65-472e-9dff-b6f9abc54191"),
				Name = @"Lane1",
				Position = new Point(0, 0),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLane1;
		}

		protected virtual ProcessSchemaTerminateEvent CreateTerminateEvent1TerminateEvent() {
			ProcessSchemaTerminateEvent schemaTerminateEvent = new ProcessSchemaTerminateEvent(this) {
				UId = new Guid("5a8cd4ba-de14-4b74-a9a8-4e3749e90577"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = new Guid("7ce62765-1da7-4255-8d55-60a3aeab2b20"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("524f976c-dc16-4613-afcd-8360daff9aa0"),
				CreatedInSchemaUId = new Guid("eef8c5e7-6f65-472e-9dff-b6f9abc54191"),
				EntitySchemaUId = Guid.Empty,
				IsLogging = true,
				ManagerItemUId = new Guid("1bd93619-0574-454e-bb4e-cf53b9eb9470"),
				ModifiedInSchemaUId = new Guid("eef8c5e7-6f65-472e-9dff-b6f9abc54191"),
				Name = @"TerminateEvent1",
				Position = new Point(518, 184),
				SerializeToDB = false,
				Size = new Size(27, 27),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaTerminateEvent;
		}

		protected virtual ProcessSchemaScriptTask CreateRemoveOldJobScriptTaskScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("226ed5c6-81db-464a-a5cc-9ad05b8f46f9"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = new Guid("7ce62765-1da7-4255-8d55-60a3aeab2b20"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("524f976c-dc16-4613-afcd-8360daff9aa0"),
				CreatedInSchemaUId = new Guid("eef8c5e7-6f65-472e-9dff-b6f9abc54191"),
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("eef8c5e7-6f65-472e-9dff-b6f9abc54191"),
				Name = @"RemoveOldJobScriptTask",
				Position = new Point(220, 170),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = true,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,11,74,205,205,47,75,117,76,79,117,76,46,41,77,204,201,172,74,44,201,204,207,243,202,79,210,208,180,230,42,74,45,41,45,202,83,40,41,42,77,181,230,2,0,113,236,245,29,42,0,0,0 }
			};
			
			return ScriptTask;
		}

		protected virtual ProcessSchemaScriptTask CreateScheduleNewJobScriptTaskScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("9b477604-e16a-4138-babf-dc4d45021576"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = new Guid("7ce62765-1da7-4255-8d55-60a3aeab2b20"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("524f976c-dc16-4613-afcd-8360daff9aa0"),
				CreatedInSchemaUId = new Guid("eef8c5e7-6f65-472e-9dff-b6f9abc54191"),
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("eef8c5e7-6f65-472e-9dff-b6f9abc54191"),
				Name = @"ScheduleNewJobScriptTask",
				Position = new Point(369, 170),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = true,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,43,75,44,82,40,45,78,45,114,206,207,203,75,77,46,201,204,207,83,176,85,112,79,45,177,9,69,17,180,211,80,66,21,80,210,180,230,10,78,206,72,77,41,205,73,245,75,45,119,76,79,117,76,46,41,77,204,201,172,74,4,73,123,229,39,105,160,26,11,84,95,148,90,82,90,148,167,80,82,84,154,106,205,5,0,40,222,232,212,121,0,0,0 }
			};
			
			return ScriptTask;
		}

		protected virtual ProcessSchemaStartEvent CreateStartEvent1StartEvent() {
			ProcessSchemaStartEvent schemaStartEvent = new ProcessSchemaStartEvent(this) {
				UId = new Guid("0c19837c-e427-4b2c-95f0-8539375a7de3"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = new Guid("7ce62765-1da7-4255-8d55-60a3aeab2b20"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("0f1116a2-88a9-4a2c-b333-bb375de9976f"),
				CreatedInSchemaUId = new Guid("eef8c5e7-6f65-472e-9dff-b6f9abc54191"),
				EntitySchemaUId = Guid.Empty,
				IsInterrupting = false,
				IsLogging = true,
				ManagerItemUId = new Guid("53818048-7868-48f6-ada0-0ebaa65af628"),
				ModifiedInSchemaUId = new Guid("eef8c5e7-6f65-472e-9dff-b6f9abc54191"),
				Name = @"StartEvent1",
				Position = new Point(113, 184),
				SerializeToDB = false,
				Size = new Size(27, 27),
				UseBackgroundMode = false
			};
			
			return schemaStartEvent;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeUsings() {
			Usings.Add(new SchemaUsing() {
				UId = new Guid("abd4bd9a-9cb7-4e0c-9340-f09d961bbeff"),
				Name = "Terrasoft.Core.Scheduler",
				Alias = "",
				CreatedInPackageId = new Guid("42c464a9-9677-4bbd-86c1-308caea3de84")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("d84579bc-b5ea-4f20-94c5-78667e4e4699"),
				Name = "Quartz.Impl.Triggers",
				Alias = "",
				CreatedInPackageId = new Guid("42c464a9-9677-4bbd-86c1-308caea3de84")
			});
		}

		#endregion

		#region Methods: Public

		public override Process CreateProcess(UserConnection userConnection) {
			return new ContactAgeActualizationJobRestartProcess(userConnection);
		}

		public override object Clone() {
			return new ContactAgeActualizationJobRestartProcessSchema(this);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("eef8c5e7-6f65-472e-9dff-b6f9abc54191"));
		}

		#endregion

	}

	#endregion

	#region Class: ContactAgeActualizationJobRestartProcessMethodsWrapper

	/// <exclude/>
	public class ContactAgeActualizationJobRestartProcessMethodsWrapper : ProcessModel
	{

		public ContactAgeActualizationJobRestartProcessMethodsWrapper(Process process)
			: base(process) {
			AddScriptTaskMethod("RemoveOldJobScriptTaskExecute", RemoveOldJobScriptTaskExecute);
			AddScriptTaskMethod("ScheduleNewJobScriptTaskExecute", ScheduleNewJobScriptTaskExecute);
		}

		#region Methods: Private

		private bool RemoveOldJobScriptTaskExecute(ProcessExecutingContext context) {
			RemoveAgeActualizationJob();
			return true;
		}

		private bool ScheduleNewJobScriptTaskExecute(ProcessExecutingContext context) {
			var userConnection = Get<UserConnection>("UserConnection");
			ScheduleNewAgeActualizationJob(userConnection);
			return true;
		}

			public void RemoveAgeActualizationJob() {
				AppScheduler.RemoveJob("ContactAgeActualizationJob", "AgeActualizationJobGroup");
			}
			
			public void ScheduleNewAgeActualizationJob(UserConnection userConnection) {
				var actualizationTime = Terrasoft.Core.Configuration.SysSettings.GetValue<DateTime>(
					userConnection, "AutomaticAgeActualizationTime", DateTime.MinValue);
				
				var jobDetail = AppScheduler.CreateProcessJob(
					"ContactAgeActualizationJob",
					"AgeActualizationJobGroup",
					"ContactAgeActualizationRunnerProcess",
					userConnection.Workspace.Name,
					userConnection.CurrentUser.Name);
				var cronTrigger = new CronTriggerImpl("ContactAgeActualizationJob", "AgeActualizationJobGroup",
					string.Format("0 {0} {1} ? * *", actualizationTime.Minute, actualizationTime.Hour));
				AppScheduler.Instance.ScheduleJob(jobDetail, cronTrigger);
			}

		#endregion

	}

	#endregion

	#region Class: ContactAgeActualizationJobRestartProcess

	/// <exclude/>
	public class ContactAgeActualizationJobRestartProcess : Terrasoft.Core.Process.Process
	{

		#region Class: ProcessLane1

		/// <exclude/>
		public class ProcessLane1 : ProcessLane
		{

			public ProcessLane1(UserConnection userConnection, ContactAgeActualizationJobRestartProcess process)
				: base(userConnection) {
				Owner = process;
				IsUsedParentUserContexts = false;
			}

		}

		#endregion

		public ContactAgeActualizationJobRestartProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ContactAgeActualizationJobRestartProcess";
			SchemaUId = new Guid("eef8c5e7-6f65-472e-9dff-b6f9abc54191");
			Caption = Schema.Caption;
			SchemaManagerName = "ProcessSchemaManager";
			SerializeToDB = true;
			SerializeToMemory = true;
			IsLogging = true;
			UseSystemSecurityContext = true;
			_notificationCaption = () => { return new LocalizableString((Caption)); };
			ProcessModel = new ContactAgeActualizationJobRestartProcessMethodsWrapper(this);
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("eef8c5e7-6f65-472e-9dff-b6f9abc54191");
			}
		}

		private string ConditionalExpressionLogMessage {
			get {
				return "Process: ContactAgeActualizationJobRestartProcess, Source element: {0}, Conditional flow: {1}, Expression: {2}, Result: {3}";
			}
		}

		private string DeadEndGatewayLogMessage {
			get {
				return "Process: ContactAgeActualizationJobRestartProcess, Source element: {0}, None of the exclusive gateway conditions are met!";
			}
		}

		#endregion

		#region Properties: Public

		private Func<string> _notificationCaption;
		public virtual string NotificationCaption {
			get {
				return (_notificationCaption ?? (_notificationCaption = () => null)).Invoke();
			}
			set {
				_notificationCaption = () => { return value; };
			}
		}

		private ProcessLane1 _lane1;
		public ProcessLane1 Lane1 {
			get {
				return _lane1 ?? ((_lane1) = new ProcessLane1(UserConnection, this));
			}
		}

		private ProcessTerminateEvent _terminateEvent1;
		public ProcessTerminateEvent TerminateEvent1 {
			get {
				return _terminateEvent1 ?? (_terminateEvent1 = new ProcessTerminateEvent() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaTerminateEvent",
					Name = "TerminateEvent1",
					SchemaElementUId = new Guid("5a8cd4ba-de14-4b74-a9a8-4e3749e90577"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
				});
			}
		}

		private ProcessScriptTask _removeOldJobScriptTask;
		public ProcessScriptTask RemoveOldJobScriptTask {
			get {
				return _removeOldJobScriptTask ?? (_removeOldJobScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "RemoveOldJobScriptTask",
					SchemaElementUId = new Guid("226ed5c6-81db-464a-a5cc-9ad05b8f46f9"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = ProcessModel.GetScriptTaskMethod("RemoveOldJobScriptTaskExecute"),
				});
			}
		}

		private ProcessScriptTask _scheduleNewJobScriptTask;
		public ProcessScriptTask ScheduleNewJobScriptTask {
			get {
				return _scheduleNewJobScriptTask ?? (_scheduleNewJobScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ScheduleNewJobScriptTask",
					SchemaElementUId = new Guid("9b477604-e16a-4138-babf-dc4d45021576"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = ProcessModel.GetScriptTaskMethod("ScheduleNewJobScriptTaskExecute"),
				});
			}
		}

		private ProcessFlowElement _startEvent1;
		public ProcessFlowElement StartEvent1 {
			get {
				return _startEvent1 ?? (_startEvent1 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartEvent",
					Name = "StartEvent1",
					SchemaElementUId = new Guid("0c19837c-e427-4b2c-95f0-8539375a7de3"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[TerminateEvent1.SchemaElementUId] = new Collection<ProcessFlowElement> { TerminateEvent1 };
			FlowElements[RemoveOldJobScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { RemoveOldJobScriptTask };
			FlowElements[ScheduleNewJobScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { ScheduleNewJobScriptTask };
			FlowElements[StartEvent1.SchemaElementUId] = new Collection<ProcessFlowElement> { StartEvent1 };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "TerminateEvent1":
						CompleteProcess();
						break;
					case "RemoveOldJobScriptTask":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ScheduleNewJobScriptTask", e.Context.SenderName));
						break;
					case "ScheduleNewJobScriptTask":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("TerminateEvent1", e.Context.SenderName));
						break;
					case "StartEvent1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("RemoveOldJobScriptTask", e.Context.SenderName));
						break;
			}
		}

		private void WritePropertyValues(DataWriter writer, bool useAllValueSources) {
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			if (IsProcessExecutedBySignal) {
				return;
			}
			context.QueueTasksV2.Enqueue(new ProcessQueueElement("StartEvent1", string.Empty));
		}

		protected override void CompleteApplyingFlowElementsPropertiesData() {
			base.CompleteApplyingFlowElementsPropertiesData();
			foreach (var item in FlowElements) {
				foreach (var itemValue in item.Value) {
					if (Guid.Equals(itemValue.CreatedInSchemaUId, InternalSchemaUId)) {
						itemValue.ExecutedEventHandler = OnExecuted;
					}
				}
			}
		}

		protected override void InitializeMetaPathParameterValues() {
			base.InitializeMetaPathParameterValues();
		}

		protected override void WritePropertyValues(DataWriter writer) {
			base.WritePropertyValues(writer);
			WritePropertyValues(writer, true);
		}

		#endregion

		#region Methods: Public

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			base.ThrowEvent(context, message);
		}

		public override void WritePropertiesData(DataWriter writer, bool writeFlowElements = true) {
			if (Status == Core.Process.ProcessStatus.Inactive) {
				return;
			}
			writer.WriteStartObject(Name);
			base.WritePropertiesData(writer, writeFlowElements);
			WritePropertyValues(writer, false);
			writer.WriteFinishObject();
		}

		public override object CloneShallow() {
			var cloneItem = (ContactAgeActualizationJobRestartProcess)base.CloneShallow();
			cloneItem.ExecutedEventHandler = ExecutedEventHandler;
			return cloneItem;
		}

		#endregion

	}

	#endregion

}

