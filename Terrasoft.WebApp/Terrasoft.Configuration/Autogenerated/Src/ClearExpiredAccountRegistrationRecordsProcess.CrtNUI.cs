namespace Terrasoft.Core.Process
{

	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
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

	#region Class: ClearExpiredAccountRegistrationRecordsProcessSchema

	/// <exclude/>
	public class ClearExpiredAccountRegistrationRecordsProcessSchema : Terrasoft.Core.Process.ProcessSchema
	{

		#region Constructors: Public

		public ClearExpiredAccountRegistrationRecordsProcessSchema(ProcessSchemaManager processSchemaManager)
			: base(processSchemaManager) {
		}

		public ClearExpiredAccountRegistrationRecordsProcessSchema(ClearExpiredAccountRegistrationRecordsProcessSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			Name = "ClearExpiredAccountRegistrationRecordsProcess";
			UId = new Guid("543e009e-301f-4c1c-9a3b-fc59d3b4f6b3");
			BackgroundModePriority = BackgroundModePriority.Medium;
			CreatedInPackageId = new Guid("3c93b4fc-319f-49fe-8429-00b509e48e53");
			CreatedInSchemaUId = Guid.Empty;
			CreatedInVersion = @"8.0.5.2483";
			CultureName = @"en-US";
			EntitySchemaUId = Guid.Empty;
			ModifiedInSchemaUId = Guid.Empty;
			ParametersEditPageSchemaUId = Guid.Empty;
			ParentSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d");
			SequenceFlowStrokeDefColor = Color.FromArgb(-4473925);
			SerializeToDB = true;
			SerializeToMemory = true;
			TaskFillDefColor = Color.FromArgb(-1);
			UsageType = ProcessSchemaUsageType.Advanced;
			ZipMethodsBody = new byte[] {  };
			ZipCompiledMethodsBody = new byte[] {  };
			RealUId = new Guid("543e009e-301f-4c1c-9a3b-fc59d3b4f6b3");
			Version = 0;
			PackageUId = new Guid("422cc048-65aa-8f90-e8ed-7fa6d5ab06b1");
			UseSystemSecurityContext = false;
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
			ProcessSchemaStartEvent start1 = CreateStart1StartEvent();
			FlowElements.Add(start1);
			ProcessSchemaTerminateEvent terminate1 = CreateTerminate1TerminateEvent();
			FlowElements.Add(terminate1);
			ProcessSchemaScriptTask clearexpiredrecordsscripttask = CreateClearExpiredRecordsScriptTaskScriptTask();
			FlowElements.Add(clearexpiredrecordsscripttask);
			FlowElements.Add(CreateSequenceFlow1SequenceFlow());
			FlowElements.Add(CreateSequenceFlow2SequenceFlow());
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow1SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow1",
				UId = new Guid("d9ce71e8-042b-4ac7-ae0f-dd046f79f044"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("3c93b4fc-319f-49fe-8429-00b509e48e53"),
				CreatedInSchemaUId = new Guid("543e009e-301f-4c1c-9a3b-fc59d3b4f6b3"),
				CurveCenterPosition = new Point(373, 203),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("543e009e-301f-4c1c-9a3b-fc59d3b4f6b3"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("bc076a86-2773-4e7a-b8d1-6bad41a79fe4"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("53a2efdd-03a6-487b-b8be-fd99d8290a7e"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow2SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow2",
				UId = new Guid("1bc7b5da-8a0b-41ad-bb85-292aba094f55"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("3c93b4fc-319f-49fe-8429-00b509e48e53"),
				CreatedInSchemaUId = new Guid("543e009e-301f-4c1c-9a3b-fc59d3b4f6b3"),
				CurveCenterPosition = new Point(373, 203),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("543e009e-301f-4c1c-9a3b-fc59d3b4f6b3"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("53a2efdd-03a6-487b-b8be-fd99d8290a7e"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("2c48f762-51b2-4186-a19d-93988449d9ab"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaLaneSet CreateLaneSet1LaneSet() {
			ProcessSchemaLaneSet schemaLaneSet1 = new ProcessSchemaLaneSet(this) {
				UId = new Guid("6b6d4e4d-fb12-4892-a7f0-9f439ca93c27"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 1,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("3c93b4fc-319f-49fe-8429-00b509e48e53"),
				CreatedInSchemaUId = new Guid("543e009e-301f-4c1c-9a3b-fc59d3b4f6b3"),
				Direction = ProcessSchemaPoolDirectionType.Vertical,
				DragGroupName = @"LaneSet",
				ManagerItemUId = new Guid("11a47caf-a0d5-41fa-a274-a0b11f77447a"),
				ModifiedInSchemaUId = new Guid("543e009e-301f-4c1c-9a3b-fc59d3b4f6b3"),
				Name = @"LaneSet1",
				Position = new Point(5, 5),
				Size = new Size(1201, 400),
				UseBackgroundMode = false
			};
			return schemaLaneSet1;
		}

		protected virtual ProcessSchemaLane CreateLane1Lane() {
			ProcessSchemaLane schemaLane1 = new ProcessSchemaLane(this) {
				UId = new Guid("0b69eee9-a311-4df3-ae5b-675e15c8474a"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 1,
				ContainerUId = new Guid("6b6d4e4d-fb12-4892-a7f0-9f439ca93c27"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("3c93b4fc-319f-49fe-8429-00b509e48e53"),
				CreatedInSchemaUId = new Guid("543e009e-301f-4c1c-9a3b-fc59d3b4f6b3"),
				DragGroupName = @"Lane",
				ManagerItemUId = new Guid("abcd74b9-5912-414b-82ac-f1aa4dcd554e"),
				ModifiedInSchemaUId = new Guid("543e009e-301f-4c1c-9a3b-fc59d3b4f6b3"),
				Name = @"Lane1",
				Position = new Point(29, 0),
				Size = new Size(1172, 400),
				UseBackgroundMode = false
			};
			return schemaLane1;
		}

		protected virtual ProcessSchemaStartEvent CreateStart1StartEvent() {
			ProcessSchemaStartEvent schemaStartEvent = new ProcessSchemaStartEvent(this) {
				UId = new Guid("bc076a86-2773-4e7a-b8d1-6bad41a79fe4"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = new Guid("0b69eee9-a311-4df3-ae5b-675e15c8474a"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("3c93b4fc-319f-49fe-8429-00b509e48e53"),
				CreatedInSchemaUId = new Guid("543e009e-301f-4c1c-9a3b-fc59d3b4f6b3"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsInterrupting = false,
				IsLogging = false,
				ManagerItemUId = new Guid("53818048-7868-48f6-ada0-0ebaa65af628"),
				ModifiedInSchemaUId = new Guid("543e009e-301f-4c1c-9a3b-fc59d3b4f6b3"),
				Name = @"Start1",
				Position = new Point(50, 184),
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			
			return schemaStartEvent;
		}

		protected virtual ProcessSchemaTerminateEvent CreateTerminate1TerminateEvent() {
			ProcessSchemaTerminateEvent schemaTerminateEvent = new ProcessSchemaTerminateEvent(this) {
				UId = new Guid("2c48f762-51b2-4186-a19d-93988449d9ab"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = new Guid("0b69eee9-a311-4df3-ae5b-675e15c8474a"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("3c93b4fc-319f-49fe-8429-00b509e48e53"),
				CreatedInSchemaUId = new Guid("543e009e-301f-4c1c-9a3b-fc59d3b4f6b3"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsLogging = false,
				ManagerItemUId = new Guid("1bd93619-0574-454e-bb4e-cf53b9eb9470"),
				ModifiedInSchemaUId = new Guid("543e009e-301f-4c1c-9a3b-fc59d3b4f6b3"),
				Name = @"Terminate1",
				Position = new Point(600, 184),
				SerializeToDB = false,
				Size = new Size(0, 0),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaTerminateEvent;
		}

		protected virtual ProcessSchemaScriptTask CreateClearExpiredRecordsScriptTaskScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("53a2efdd-03a6-487b-b8be-fd99d8290a7e"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = new Guid("0b69eee9-a311-4df3-ae5b-675e15c8474a"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("3c93b4fc-319f-49fe-8429-00b509e48e53"),
				CreatedInSchemaUId = new Guid("543e009e-301f-4c1c-9a3b-fc59d3b4f6b3"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = false,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("543e009e-301f-4c1c-9a3b-fc59d3b4f6b3"),
				Name = @"ClearExpiredRecordsScriptTask",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(281, 170),
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,149,146,193,106,195,48,12,134,207,45,244,29,140,79,14,20,191,64,217,161,164,41,235,40,203,216,214,237,108,28,117,49,36,114,39,219,73,31,127,137,99,2,27,99,116,39,35,233,215,247,203,178,59,69,12,109,191,83,30,216,29,27,143,87,211,130,60,121,253,104,251,205,106,217,13,245,10,26,136,101,132,158,237,98,32,78,14,40,183,136,160,189,177,152,173,150,11,185,39,219,10,254,4,228,44,170,102,171,181,13,232,159,225,195,56,79,106,84,241,40,123,175,129,64,240,67,197,51,121,64,49,50,95,6,166,246,191,48,23,50,183,77,104,81,240,139,34,190,142,77,49,125,131,151,220,186,169,109,234,56,194,217,151,193,3,61,88,51,240,222,128,204,217,232,168,205,109,5,73,95,119,58,233,75,156,162,53,75,163,186,226,51,168,38,77,194,248,189,114,245,60,206,109,112,247,13,238,254,128,255,4,204,70,105,121,105,176,226,122,49,4,174,196,136,56,130,115,98,218,215,176,54,116,94,164,135,205,146,41,205,166,255,105,204,134,95,48,253,0,89,92,65,15,183,20,99,138,192,7,66,230,41,192,230,11,153,90,142,194,69,2,0,0 }
			};
			
			return ScriptTask;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Process CreateProcess(UserConnection userConnection) {
			return new ClearExpiredAccountRegistrationRecordsProcess(userConnection);
		}

		public override object Clone() {
			return new ClearExpiredAccountRegistrationRecordsProcessSchema(this);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("543e009e-301f-4c1c-9a3b-fc59d3b4f6b3"));
		}

		#endregion

	}

	#endregion

	#region Class: ClearExpiredAccountRegistrationRecordsProcess

	/// <exclude/>
	public class ClearExpiredAccountRegistrationRecordsProcess : Terrasoft.Core.Process.Process
	{

		#region Class: ProcessLane1

		/// <exclude/>
		public class ProcessLane1 : ProcessLane
		{

			public ProcessLane1(UserConnection userConnection, ClearExpiredAccountRegistrationRecordsProcess process)
				: base(userConnection) {
				Owner = process;
				IsUsedParentUserContexts = false;
			}

		}

		#endregion

		public ClearExpiredAccountRegistrationRecordsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ClearExpiredAccountRegistrationRecordsProcess";
			SchemaUId = new Guid("543e009e-301f-4c1c-9a3b-fc59d3b4f6b3");
			Caption = Schema.Caption;
			SchemaManagerName = "ProcessSchemaManager";
			SerializeToDB = true;
			SerializeToMemory = true;
			IsLogging = true;
			UseSystemSecurityContext = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("543e009e-301f-4c1c-9a3b-fc59d3b4f6b3");
			}
		}

		private string ConditionalExpressionLogMessage {
			get {
				return "Process: ClearExpiredAccountRegistrationRecordsProcess, Source element: {0}, Conditional flow: {1}, Expression: {2}, Result: {3}";
			}
		}

		private string DeadEndGatewayLogMessage {
			get {
				return "Process: ClearExpiredAccountRegistrationRecordsProcess, Source element: {0}, None of the exclusive gateway conditions are met!";
			}
		}

		#endregion

		#region Properties: Public

		private ProcessLane1 _lane1;
		public ProcessLane1 Lane1 {
			get {
				return _lane1 ?? ((_lane1) = new ProcessLane1(UserConnection, this));
			}
		}

		private ProcessFlowElement _start1;
		public ProcessFlowElement Start1 {
			get {
				return _start1 ?? (_start1 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartEvent",
					Name = "Start1",
					SchemaElementUId = new Guid("bc076a86-2773-4e7a-b8d1-6bad41a79fe4"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessTerminateEvent _terminate1;
		public ProcessTerminateEvent Terminate1 {
			get {
				return _terminate1 ?? (_terminate1 = new ProcessTerminateEvent() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaTerminateEvent",
					Name = "Terminate1",
					SchemaElementUId = new Guid("2c48f762-51b2-4186-a19d-93988449d9ab"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _clearExpiredRecordsScriptTask;
		public ProcessScriptTask ClearExpiredRecordsScriptTask {
			get {
				return _clearExpiredRecordsScriptTask ?? (_clearExpiredRecordsScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ClearExpiredRecordsScriptTask",
					SchemaElementUId = new Guid("53a2efdd-03a6-487b-b8be-fd99d8290a7e"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					Script = ClearExpiredRecordsScriptTaskExecute,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[Start1.SchemaElementUId] = new Collection<ProcessFlowElement> { Start1 };
			FlowElements[Terminate1.SchemaElementUId] = new Collection<ProcessFlowElement> { Terminate1 };
			FlowElements[ClearExpiredRecordsScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { ClearExpiredRecordsScriptTask };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "Start1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ClearExpiredRecordsScriptTask", e.Context.SenderName));
						break;
					case "Terminate1":
						CompleteProcess();
						break;
					case "ClearExpiredRecordsScriptTask":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("Terminate1", e.Context.SenderName));
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
			context.QueueTasksV2.Enqueue(new ProcessQueueElement("Start1", string.Empty));
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

		public virtual bool ClearExpiredRecordsScriptTaskExecute(ProcessExecutingContext context) {
			var nowDate = DateTime.UtcNow;
			var delete = new Delete(UserConnection)
				.From("PersonalAccountRegistration")
				.Where("Id").In(new Select(UserConnection)
					.Column("par","Id")
					.From("PersonalAccountRegistration").As("par")
					.LeftOuterJoin("VerificationCode").As("hvc")
					.On("hvc", "Id").IsEqual("par", "HashId")
					.LeftOuterJoin("VerificationCode").As("svc")
					.On("svc", "Id").IsEqual("par", "VerificationCodeId")
					.Where("hvc", "ExpiresOn").IsLess(Column.Const(nowDate))
					.Or("svc", "ExpiresOn").IsLess(Column.Const(nowDate))
				);
			delete.Execute();
			return true;
		}

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
			var cloneItem = (ClearExpiredAccountRegistrationRecordsProcess)base.CloneShallow();
			cloneItem.ExecutedEventHandler = ExecutedEventHandler;
			return cloneItem;
		}

		#endregion

	}

	#endregion

}

