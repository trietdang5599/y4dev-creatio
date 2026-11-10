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
	using Terrasoft.Configuration;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Process;
	using Terrasoft.Core.Process.Configuration;
	using Terrasoft.Messaging.Common;

	#region Class: GetRemindingCountersSchema

	/// <exclude/>
	public class GetRemindingCountersSchema : Terrasoft.Core.Process.ProcessSchema
	{

		#region Constructors: Public

		public GetRemindingCountersSchema(ProcessSchemaManager processSchemaManager)
			: base(processSchemaManager) {
		}

		public GetRemindingCountersSchema(GetRemindingCountersSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			Name = "GetRemindingCounters";
			UId = new Guid("7e1de80a-7626-454d-9afa-3c0771af5786");
			BackgroundModePriority = BackgroundModePriority.Medium;
			CreatedInPackageId = new Guid("cd322293-860d-4ac9-8e55-034f9e973ce3");
			CreatedInSchemaUId = Guid.Empty;
			CreatedInVersion = @"0.0.0.0";
			CultureName = @"en-US";
			EntitySchemaUId = Guid.Empty;
			IsCreatedInSvg = true;
			IsLogging = false;
			ModifiedInSchemaUId = Guid.Empty;
			ParametersEditPageSchemaUId = Guid.Empty;
			ParentSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d");
			SequenceFlowStrokeDefColor = Color.FromArgb(-4473925);
			SerializeToDB = false;
			SerializeToMemory = true;
			Tag = @"Business Process";
			TaskFillDefColor = Color.FromArgb(-1);
			UsageType = ProcessSchemaUsageType.Advanced;
			ZipMethodsBody = new byte[] {  };
			ZipCompiledMethodsBody = new byte[] {  };
			RealUId = new Guid("7e1de80a-7626-454d-9afa-3c0771af5786");
			Version = 0;
			PackageUId = new Guid("422cc048-65aa-8f90-e8ed-7fa6d5ab06b1");
			UseSystemSecurityContext = false;
		}

		protected override void InitializeParameters() {
			base.InitializeParameters();
		}

		protected override void InitializeBaseElements() {
			base.InitializeBaseElements();
			ProcessSchemaLaneSet schemaGetRemindingCountersLaneSet = CreateGetRemindingCountersLaneSetLaneSet();
			LaneSets.Add(schemaGetRemindingCountersLaneSet);
			ProcessSchemaLane schemaGetRemindingCountersLane = CreateGetRemindingCountersLaneLane();
			schemaGetRemindingCountersLaneSet.Lanes.Add(schemaGetRemindingCountersLane);
			ProcessSchemaStartEvent start1 = CreateStart1StartEvent();
			FlowElements.Add(start1);
			ProcessSchemaEndEvent end1 = CreateEnd1EndEvent();
			FlowElements.Add(end1);
			ProcessSchemaScriptTask getremindingcountersscripttask = CreateGetRemindingCountersScriptTaskScriptTask();
			FlowElements.Add(getremindingcountersscripttask);
			FlowElements.Add(CreateSequenceFlow1SequenceFlow());
			FlowElements.Add(CreateSequenceFlow2SequenceFlow());
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow1SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow1",
				UId = new Guid("595bab57-506e-4a72-ba3b-ddb02fefaa42"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("cd322293-860d-4ac9-8e55-034f9e973ce3"),
				CreatedInSchemaUId = new Guid("7e1de80a-7626-454d-9afa-3c0771af5786"),
				CurveCenterPosition = new Point(373, 203),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("7e1de80a-7626-454d-9afa-3c0771af5786"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("1d7eee7b-2f5a-41fa-b7b2-2dfaf51bf6ba"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("40197e3a-cf2f-4819-a92e-15fdefdc1aa6"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow2SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow2",
				UId = new Guid("7d23619e-0249-456f-94fb-de2f5ea9713e"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("cd322293-860d-4ac9-8e55-034f9e973ce3"),
				CreatedInSchemaUId = new Guid("7e1de80a-7626-454d-9afa-3c0771af5786"),
				CurveCenterPosition = new Point(373, 203),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("7e1de80a-7626-454d-9afa-3c0771af5786"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("40197e3a-cf2f-4819-a92e-15fdefdc1aa6"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("d3e3c68c-167f-497a-b5fa-df3a31fdabd1"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaLaneSet CreateGetRemindingCountersLaneSetLaneSet() {
			ProcessSchemaLaneSet schemaGetRemindingCountersLaneSet = new ProcessSchemaLaneSet(this) {
				UId = new Guid("1d86ee0a-d2f4-407b-b055-fb95b10d07a6"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 1,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("cd322293-860d-4ac9-8e55-034f9e973ce3"),
				CreatedInSchemaUId = new Guid("7e1de80a-7626-454d-9afa-3c0771af5786"),
				Direction = ProcessSchemaPoolDirectionType.Vertical,
				DragGroupName = @"LaneSet",
				ManagerItemUId = new Guid("11a47caf-a0d5-41fa-a274-a0b11f77447a"),
				ModifiedInSchemaUId = new Guid("7e1de80a-7626-454d-9afa-3c0771af5786"),
				Name = @"GetRemindingCountersLaneSet",
				Position = new Point(5, 5),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaGetRemindingCountersLaneSet;
		}

		protected virtual ProcessSchemaLane CreateGetRemindingCountersLaneLane() {
			ProcessSchemaLane schemaGetRemindingCountersLane = new ProcessSchemaLane(this) {
				UId = new Guid("fe4066c8-e30d-4fce-a82e-6c6dab24e720"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 1,
				ContainerUId = new Guid("1d86ee0a-d2f4-407b-b055-fb95b10d07a6"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("cd322293-860d-4ac9-8e55-034f9e973ce3"),
				CreatedInSchemaUId = new Guid("7e1de80a-7626-454d-9afa-3c0771af5786"),
				DragGroupName = @"Lane",
				ManagerItemUId = new Guid("abcd74b9-5912-414b-82ac-f1aa4dcd554e"),
				ModifiedInSchemaUId = new Guid("7e1de80a-7626-454d-9afa-3c0771af5786"),
				Name = @"GetRemindingCountersLane",
				Position = new Point(29, 0),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaGetRemindingCountersLane;
		}

		protected virtual ProcessSchemaStartEvent CreateStart1StartEvent() {
			ProcessSchemaStartEvent schemaStartEvent = new ProcessSchemaStartEvent(this) {
				UId = new Guid("1d7eee7b-2f5a-41fa-b7b2-2dfaf51bf6ba"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = new Guid("fe4066c8-e30d-4fce-a82e-6c6dab24e720"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("cd322293-860d-4ac9-8e55-034f9e973ce3"),
				CreatedInSchemaUId = new Guid("7e1de80a-7626-454d-9afa-3c0771af5786"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsInterrupting = false,
				IsLogging = true,
				ManagerItemUId = new Guid("53818048-7868-48f6-ada0-0ebaa65af628"),
				ModifiedInSchemaUId = new Guid("7e1de80a-7626-454d-9afa-3c0771af5786"),
				Name = @"Start1",
				Position = new Point(50, 184),
				SerializeToDB = false,
				Size = new Size(27, 27),
				UseBackgroundMode = false
			};
			
			return schemaStartEvent;
		}

		protected virtual ProcessSchemaEndEvent CreateEnd1EndEvent() {
			ProcessSchemaEndEvent schemaEndEvent = new ProcessSchemaEndEvent(this) {
				UId = new Guid("d3e3c68c-167f-497a-b5fa-df3a31fdabd1"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = new Guid("fe4066c8-e30d-4fce-a82e-6c6dab24e720"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("cd322293-860d-4ac9-8e55-034f9e973ce3"),
				CreatedInSchemaUId = new Guid("7e1de80a-7626-454d-9afa-3c0771af5786"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsLogging = true,
				ManagerItemUId = new Guid("45ceaae2-4e1f-4c0c-86aa-cd4aeb4da913"),
				ModifiedInSchemaUId = new Guid("7e1de80a-7626-454d-9afa-3c0771af5786"),
				Name = @"End1",
				Position = new Point(309, 184),
				SerializeToDB = false,
				Size = new Size(27, 27),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaEndEvent;
		}

		protected virtual ProcessSchemaScriptTask CreateGetRemindingCountersScriptTaskScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("40197e3a-cf2f-4819-a92e-15fdefdc1aa6"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = new Guid("fe4066c8-e30d-4fce-a82e-6c6dab24e720"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("cd322293-860d-4ac9-8e55-034f9e973ce3"),
				CreatedInSchemaUId = new Guid("7e1de80a-7626-454d-9afa-3c0771af5786"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("7e1de80a-7626-454d-9afa-3c0771af5786"),
				Name = @"GetRemindingCountersScriptTask",
				Position = new Point(141, 170),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,109,83,203,110,219,48,16,60,59,64,254,129,208,73,2,12,34,231,182,78,144,168,105,226,131,3,215,143,246,16,244,64,136,27,155,128,184,84,248,72,32,20,253,247,114,41,37,150,148,24,16,4,174,103,102,103,103,169,23,97,25,184,103,182,96,8,175,236,22,189,242,237,182,58,130,22,63,3,216,54,223,59,176,165,65,132,202,43,131,124,8,88,9,20,7,176,115,150,109,91,119,45,181,194,61,42,159,21,95,207,207,62,232,148,166,14,26,89,99,149,22,239,167,5,117,230,215,82,118,231,156,78,27,99,124,199,227,119,224,215,67,252,131,208,144,23,36,63,166,101,209,159,23,85,215,153,254,250,161,106,15,214,17,36,105,150,22,132,135,174,250,91,249,227,90,216,40,69,144,188,43,150,70,55,194,42,103,112,215,54,192,111,159,131,168,231,231,103,179,140,90,102,115,54,9,161,12,214,2,122,170,114,66,20,167,145,163,165,186,67,49,160,130,2,215,143,25,167,153,66,38,225,146,138,122,98,249,27,145,151,38,160,103,151,236,162,96,127,163,155,187,160,36,115,131,168,151,146,180,123,244,227,197,31,234,65,3,244,193,252,18,117,128,111,196,186,204,71,193,119,166,99,183,217,114,229,14,229,81,68,7,53,171,250,247,130,157,138,253,138,249,210,109,2,162,194,3,139,164,244,187,250,12,133,206,11,172,32,46,0,229,210,131,190,105,247,75,153,143,45,23,111,10,95,24,134,186,38,23,52,244,123,247,69,42,119,19,207,44,248,96,145,121,27,128,128,255,226,179,129,40,37,163,21,119,15,117,3,150,217,105,161,187,202,83,220,39,97,207,156,183,52,211,147,177,90,120,15,242,123,188,38,145,78,175,157,210,192,247,190,122,48,175,124,103,182,9,152,103,38,27,242,52,56,23,7,191,49,178,141,172,169,15,218,198,201,68,218,229,6,92,99,208,193,36,146,249,216,65,106,241,18,191,75,167,116,83,195,170,235,210,143,181,29,213,82,72,233,26,76,20,169,222,251,26,184,164,8,147,255,161,8,191,7,33,163,221,45,160,76,233,101,67,227,201,119,252,82,50,226,245,75,226,107,227,124,207,206,71,90,100,61,46,105,184,182,255,251,202,126,151,97,4,0,0 }
			};
			
			return ScriptTask;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeUsings() {
			Usings.Add(new SchemaUsing() {
				UId = new Guid("1b9f6559-51a0-40df-8314-eeb73998eb93"),
				Name = "Terrasoft.Messaging.Common",
				Alias = "",
				CreatedInPackageId = new Guid("cd322293-860d-4ac9-8e55-034f9e973ce3")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("52c807d3-cd14-4c38-a2f6-b4fa50601032"),
				Name = "Terrasoft.Configuration",
				Alias = "",
				CreatedInPackageId = new Guid("85a972d5-aaea-43a7-af9b-d75884bd785b")
			});
		}

		#endregion

		#region Methods: Public

		public override Process CreateProcess(UserConnection userConnection) {
			return new GetRemindingCounters(userConnection);
		}

		public override object Clone() {
			return new GetRemindingCountersSchema(this);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("7e1de80a-7626-454d-9afa-3c0771af5786"));
		}

		#endregion

	}

	#endregion

	#region Class: GetRemindingCounters

	/// <exclude/>
	public class GetRemindingCounters : Terrasoft.Core.Process.Process
	{

		#region Class: ProcessGetRemindingCountersLane

		/// <exclude/>
		public class ProcessGetRemindingCountersLane : ProcessLane
		{

			public ProcessGetRemindingCountersLane(UserConnection userConnection, GetRemindingCounters process)
				: base(userConnection) {
				Owner = process;
				IsUsedParentUserContexts = false;
			}

		}

		#endregion

		public GetRemindingCounters(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "GetRemindingCounters";
			SchemaUId = new Guid("7e1de80a-7626-454d-9afa-3c0771af5786");
			Caption = Schema.Caption;
			SchemaManagerName = "ProcessSchemaManager";
			SerializeToDB = false;
			SerializeToMemory = true;
			IsLogging = false;
			UseSystemSecurityContext = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("7e1de80a-7626-454d-9afa-3c0771af5786");
			}
		}

		private string ConditionalExpressionLogMessage {
			get {
				return "Process: GetRemindingCounters, Source element: {0}, Conditional flow: {1}, Expression: {2}, Result: {3}";
			}
		}

		private string DeadEndGatewayLogMessage {
			get {
				return "Process: GetRemindingCounters, Source element: {0}, None of the exclusive gateway conditions are met!";
			}
		}

		#endregion

		#region Properties: Public

		private ProcessGetRemindingCountersLane _getRemindingCountersLane;
		public ProcessGetRemindingCountersLane GetRemindingCountersLane {
			get {
				return _getRemindingCountersLane ?? ((_getRemindingCountersLane) = new ProcessGetRemindingCountersLane(UserConnection, this));
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
					SchemaElementUId = new Guid("1d7eee7b-2f5a-41fa-b7b2-2dfaf51bf6ba"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
				});
			}
		}

		private ProcessEndEvent _end1;
		public ProcessEndEvent End1 {
			get {
				return _end1 ?? (_end1 = new ProcessEndEvent() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEndEvent",
					Name = "End1",
					SchemaElementUId = new Guid("d3e3c68c-167f-497a-b5fa-df3a31fdabd1"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
				});
			}
		}

		private ProcessScriptTask _getRemindingCountersScriptTask;
		public ProcessScriptTask GetRemindingCountersScriptTask {
			get {
				return _getRemindingCountersScriptTask ?? (_getRemindingCountersScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "GetRemindingCountersScriptTask",
					SchemaElementUId = new Guid("40197e3a-cf2f-4819-a92e-15fdefdc1aa6"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = GetRemindingCountersScriptTaskExecute,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[Start1.SchemaElementUId] = new Collection<ProcessFlowElement> { Start1 };
			FlowElements[End1.SchemaElementUId] = new Collection<ProcessFlowElement> { End1 };
			FlowElements[GetRemindingCountersScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { GetRemindingCountersScriptTask };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "Start1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("GetRemindingCountersScriptTask", e.Context.SenderName));
						break;
					case "End1":
						CompleteProcess();
						break;
					case "GetRemindingCountersScriptTask":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("End1", e.Context.SenderName));
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

		public virtual bool GetRemindingCountersScriptTaskExecute(ProcessExecutingContext context) {
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "SysAdminUnit");
			EntitySchemaQueryColumn primaryColumn = esq.AddColumn(esq.RootSchema.GetPrimaryColumnName());
			esq.AddColumn("Contact");
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal,
				"Name", UserConnection.CurrentUser.Name));
			EntityCollection entities = esq.GetEntityCollection(UserConnection);
			if (entities.Count > 0) {
				Guid sysAdminUnitId = entities[0].GetTypedColumnValue<Guid>(primaryColumn.Name);
				IMsgChannel channel = MsgChannelManager.IsRunning 
									? MsgChannelManager.Instance.FindItemByUId(sysAdminUnitId)
									: null;
				if (channel == null) {
					return true;
				}
				RemindingsHelper remindingsHelper = new RemindingsHelper(UserConnection);
				string formattedDate = DateTime.UtcNow.ToString("o");
				string messageBody = remindingsHelper.GetRemindingsCountResponse(sysAdminUnitId, formattedDate);
				var simpleMessage = new SimpleMessage {
					Id = sysAdminUnitId,
					Body = messageBody
				};
				simpleMessage.Header.Sender = "GetRemindingCounters";
				channel.PostMessage(simpleMessage);
			}
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
			var cloneItem = (GetRemindingCounters)base.CloneShallow();
			cloneItem.ExecutedEventHandler = ExecutedEventHandler;
			return cloneItem;
		}

		#endregion

	}

	#endregion

}

