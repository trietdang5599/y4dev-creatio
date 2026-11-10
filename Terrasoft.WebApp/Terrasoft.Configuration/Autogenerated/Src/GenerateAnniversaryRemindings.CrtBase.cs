namespace Terrasoft.Core.Process
{

	using global::Common.Logging;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Drawing;
	using System.Globalization;
	using System.Linq;
	using System.Reflection;
	using System.Text;
	using System.Threading.Tasks;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Factories;
	using Terrasoft.Core.Process;
	using Terrasoft.Core.Process.Configuration;

	#region Class: GenerateAnniversaryRemindingsSchema

	/// <exclude/>
	public class GenerateAnniversaryRemindingsSchema : Terrasoft.Core.Process.ProcessSchema
	{

		#region Constructors: Public

		public GenerateAnniversaryRemindingsSchema(ProcessSchemaManager processSchemaManager)
			: base(processSchemaManager) {
		}

		public GenerateAnniversaryRemindingsSchema(GenerateAnniversaryRemindingsSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			Name = "GenerateAnniversaryRemindings";
			UId = new Guid("ea728d44-cef0-4c18-8017-0e0532c7338e");
			CreatedInPackageId = new Guid("1cba1048-8bb6-403f-9352-2c23d14f5429");
			CreatedInSchemaUId = Guid.Empty;
			CreatedInVersion = @"7.7.0.0";
			CultureName = @"ru-RU";
			EntitySchemaUId = Guid.Empty;
			IsCreatedInSvg = true;
			IsLogging = false;
			ModifiedInSchemaUId = Guid.Empty;
			ParametersEditPageSchemaUId = Guid.Empty;
			ParentSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d");
			SequenceFlowStrokeDefColor = Color.FromArgb(-4473925);
			SerializeToDB = false;
			SerializeToMemory = true;
			TaskFillDefColor = Color.FromArgb(-1);
			UsageType = ProcessSchemaUsageType.Advanced;
			UseForceCompile = true;
			ZipMethodsBody = new byte[] {  };
			ZipCompiledMethodsBody = new byte[] {  };
			RealUId = new Guid("ea728d44-cef0-4c18-8017-0e0532c7338e");
			Version = 0;
			PackageUId = new Guid("06d9ef10-51d8-122c-8933-9212e84236c9");
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
			ProcessSchemaScriptTask generatereminding = CreateGenerateRemindingScriptTask();
			FlowElements.Add(generatereminding);
			FlowElements.Add(CreateSequenceFlow1SequenceFlow());
			FlowElements.Add(CreateSequenceFlow2SequenceFlow());
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow1SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow1",
				UId = new Guid("fa41dea9-7551-47ab-9e2c-1763bd583484"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("1cba1048-8bb6-403f-9352-2c23d14f5429"),
				CreatedInSchemaUId = new Guid("ea728d44-cef0-4c18-8017-0e0532c7338e"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("ea728d44-cef0-4c18-8017-0e0532c7338e"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("528e9bac-1ed2-4e52-8225-6cb1c5f70e0e"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("c4cc0ca4-aabf-45e6-af76-18930d341b4c"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow2SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow2",
				UId = new Guid("3d5af550-2a17-4078-8ba4-35edf569ca6f"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("1cba1048-8bb6-403f-9352-2c23d14f5429"),
				CreatedInSchemaUId = new Guid("ea728d44-cef0-4c18-8017-0e0532c7338e"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("ea728d44-cef0-4c18-8017-0e0532c7338e"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("c4cc0ca4-aabf-45e6-af76-18930d341b4c"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("621e8ff4-222d-4239-a838-9104b30d406d"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaLaneSet CreateLaneSet1LaneSet() {
			ProcessSchemaLaneSet schemaLaneSet1 = new ProcessSchemaLaneSet(this) {
				UId = new Guid("22f42928-141f-4715-8685-d8996ebbbd4f"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 1,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("1cba1048-8bb6-403f-9352-2c23d14f5429"),
				CreatedInSchemaUId = new Guid("ea728d44-cef0-4c18-8017-0e0532c7338e"),
				Direction = ProcessSchemaPoolDirectionType.Vertical,
				DragGroupName = @"LaneSet",
				ManagerItemUId = new Guid("11a47caf-a0d5-41fa-a274-a0b11f77447a"),
				ModifiedInSchemaUId = new Guid("ea728d44-cef0-4c18-8017-0e0532c7338e"),
				Name = @"LaneSet1",
				Position = new Point(5, 5),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLaneSet1;
		}

		protected virtual ProcessSchemaLane CreateLane1Lane() {
			ProcessSchemaLane schemaLane1 = new ProcessSchemaLane(this) {
				UId = new Guid("2a8d5978-d804-4c5e-9392-eef26de94931"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 1,
				ContainerUId = new Guid("22f42928-141f-4715-8685-d8996ebbbd4f"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("1cba1048-8bb6-403f-9352-2c23d14f5429"),
				CreatedInSchemaUId = new Guid("ea728d44-cef0-4c18-8017-0e0532c7338e"),
				DragGroupName = @"Lane",
				ManagerItemUId = new Guid("abcd74b9-5912-414b-82ac-f1aa4dcd554e"),
				ModifiedInSchemaUId = new Guid("ea728d44-cef0-4c18-8017-0e0532c7338e"),
				Name = @"Lane1",
				Position = new Point(29, 0),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLane1;
		}

		protected virtual ProcessSchemaStartEvent CreateStart1StartEvent() {
			ProcessSchemaStartEvent schemaStartEvent = new ProcessSchemaStartEvent(this) {
				UId = new Guid("528e9bac-1ed2-4e52-8225-6cb1c5f70e0e"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = new Guid("2a8d5978-d804-4c5e-9392-eef26de94931"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("1cba1048-8bb6-403f-9352-2c23d14f5429"),
				CreatedInSchemaUId = new Guid("ea728d44-cef0-4c18-8017-0e0532c7338e"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsInterrupting = false,
				IsLogging = true,
				ManagerItemUId = new Guid("53818048-7868-48f6-ada0-0ebaa65af628"),
				ModifiedInSchemaUId = new Guid("ea728d44-cef0-4c18-8017-0e0532c7338e"),
				Name = @"Start1",
				Position = new Point(50, 184),
				SerializeToDB = false,
				Size = new Size(27, 27),
				UseBackgroundMode = false
			};
			
			return schemaStartEvent;
		}

		protected virtual ProcessSchemaTerminateEvent CreateTerminate1TerminateEvent() {
			ProcessSchemaTerminateEvent schemaTerminateEvent = new ProcessSchemaTerminateEvent(this) {
				UId = new Guid("621e8ff4-222d-4239-a838-9104b30d406d"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = new Guid("2a8d5978-d804-4c5e-9392-eef26de94931"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("1cba1048-8bb6-403f-9352-2c23d14f5429"),
				CreatedInSchemaUId = new Guid("ea728d44-cef0-4c18-8017-0e0532c7338e"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsLogging = true,
				ManagerItemUId = new Guid("1bd93619-0574-454e-bb4e-cf53b9eb9470"),
				ModifiedInSchemaUId = new Guid("ea728d44-cef0-4c18-8017-0e0532c7338e"),
				Name = @"Terminate1",
				Position = new Point(353, 184),
				SerializeToDB = false,
				Size = new Size(27, 27),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaTerminateEvent;
		}

		protected virtual ProcessSchemaScriptTask CreateGenerateRemindingScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("c4cc0ca4-aabf-45e6-af76-18930d341b4c"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = new Guid("2a8d5978-d804-4c5e-9392-eef26de94931"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("1cba1048-8bb6-403f-9352-2c23d14f5429"),
				CreatedInSchemaUId = new Guid("ea728d44-cef0-4c18-8017-0e0532c7338e"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("ea728d44-cef0-4c18-8017-0e0532c7338e"),
				Name = @"GenerateReminding",
				Position = new Point(171, 170),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = true,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,109,83,203,110,227,48,12,60,203,95,161,250,164,0,129,127,32,15,96,91,100,11,3,109,119,177,73,183,135,98,15,138,67,59,106,29,41,160,232,180,65,145,127,95,74,202,27,189,73,34,57,156,25,82,158,208,216,70,118,30,238,193,2,106,50,206,78,9,229,40,19,211,173,159,2,17,135,125,113,15,244,87,183,29,12,125,204,31,171,202,89,130,79,42,158,61,224,157,179,22,170,80,217,151,249,243,17,9,126,88,107,54,128,94,227,246,15,172,140,93,4,168,156,115,8,59,200,123,131,108,163,241,178,179,28,73,6,227,26,42,102,238,214,185,22,180,85,215,220,184,208,212,82,221,92,188,247,228,87,38,16,168,67,43,3,252,32,219,69,248,170,213,222,63,233,21,48,116,62,3,68,237,93,77,5,119,169,77,211,165,218,226,86,251,111,201,230,137,226,10,104,233,22,7,144,163,186,138,58,221,158,9,75,201,180,93,195,111,116,27,179,0,12,114,66,255,159,186,34,135,219,224,226,176,124,113,248,238,215,186,130,217,89,230,88,177,170,240,144,8,199,211,232,2,43,20,135,103,117,84,196,21,229,196,118,43,102,51,111,97,24,130,99,105,236,18,208,144,191,170,206,196,161,222,171,30,95,94,56,11,20,197,54,227,152,89,148,126,218,205,35,248,175,90,29,89,244,246,99,210,216,4,76,11,31,210,205,223,120,218,175,255,228,215,247,75,176,27,100,147,207,10,214,113,160,140,67,167,27,3,116,109,59,200,106,135,160,171,165,84,81,104,164,97,236,145,123,156,101,234,194,111,158,180,173,130,27,108,184,217,104,54,178,184,227,106,130,114,31,138,50,250,145,33,147,21,143,113,90,165,173,221,126,112,241,152,236,8,38,164,184,58,13,181,31,84,5,57,33,195,213,106,206,123,215,219,5,168,176,102,231,24,137,126,164,39,130,118,99,195,162,137,93,38,8,183,241,245,148,93,148,118,227,222,65,29,4,244,175,188,171,117,235,33,118,225,242,74,83,112,227,100,20,164,38,193,249,214,53,204,254,193,53,143,218,234,38,45,2,223,248,164,242,39,71,166,54,85,220,98,31,126,148,16,156,94,76,16,29,42,72,247,171,1,36,194,187,248,133,46,99,55,103,242,104,137,238,227,114,120,252,163,132,16,217,249,31,251,15,25,162,249,59,61,4,0,0 }
			};
			
			return ScriptTask;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeUsings() {
			Usings.Add(new SchemaUsing() {
				UId = new Guid("fb29449b-948a-42d8-9ce4-d8a2a70cb237"),
				Name = "System.Linq",
				Alias = "",
				CreatedInPackageId = new Guid("1cba1048-8bb6-403f-9352-2c23d14f5429")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("ae5cf1a1-fd3c-4e1a-a803-58809bfaee7d"),
				Name = "System.Threading.Tasks",
				Alias = "",
				CreatedInPackageId = new Guid("1cba1048-8bb6-403f-9352-2c23d14f5429")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("49c070a0-632a-4ee3-85de-d059e293c3ee"),
				Name = "System.Collections.Generic",
				Alias = "",
				CreatedInPackageId = new Guid("1cba1048-8bb6-403f-9352-2c23d14f5429")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("a4f930e4-62bd-4e84-96b4-2c761af4d3d3"),
				Name = "System.Reflection",
				Alias = "",
				CreatedInPackageId = new Guid("1cba1048-8bb6-403f-9352-2c23d14f5429")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("0db02f09-1196-4f60-80e9-5e7f08e20706"),
				Name = "global::Common.Logging",
				Alias = "",
				CreatedInPackageId = new Guid("1cba1048-8bb6-403f-9352-2c23d14f5429")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("7bb09134-f66a-45bf-b8a0-743695fdcaf8"),
				Name = "Terrasoft.Core.Factories",
				Alias = "",
				CreatedInPackageId = new Guid("1cba1048-8bb6-403f-9352-2c23d14f5429")
			});
		}

		#endregion

		#region Methods: Public

		public override Process CreateProcess(UserConnection userConnection) {
			return new GenerateAnniversaryRemindings(userConnection);
		}

		public override object Clone() {
			return new GenerateAnniversaryRemindingsSchema(this);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("ea728d44-cef0-4c18-8017-0e0532c7338e"));
		}

		#endregion

	}

	#endregion

	#region Class: GenerateAnniversaryRemindingsMethodsWrapper

	/// <exclude/>
	public class GenerateAnniversaryRemindingsMethodsWrapper : ProcessModel
	{

		public GenerateAnniversaryRemindingsMethodsWrapper(Process process)
			: base(process) {
			AddScriptTaskMethod("GenerateRemindingExecute", GenerateRemindingExecute);
		}

		#region Methods: Private

		private bool GenerateRemindingExecute(ProcessExecutingContext context) {
			string useGenerationStr =
				SysSettings.GetValue<string>(context.UserConnection, "UseGenerateAnniversaryRemindings", "true");
			var useGeneration = Convert.ToBoolean(useGenerationStr);
			if (!useGeneration) {
				return true;
			}
			var className = "Terrasoft.Configuration.BaseAnniversaryReminding";
			var methodName = "GenerateActualRemindings";
			var typeProvider = ClassFactory.Get<IWorkspaceTypeProvider>();
			Type classType = typeProvider.GetType(className);
			IEnumerable<Type> inherits = typeProvider
				.GetTypes()
				.Where(type => type.IsSubclassOf(classType));
			var args = new object[] {context.UserConnection};
			Exception lastException = null;
			foreach (Type type in inherits) {
				object instance = Activator.CreateInstance(type, args);
				MethodInfo methodInfo = type.GetMethod(methodName, new[] {typeof(bool)});
				if (methodInfo == null) {
					continue;
				}
				try {
					methodInfo.Invoke(instance, new object[] {false});
				}
				catch (Exception e) {
					var log = LogManager.GetLogger("Notifications");
					log.Error(e);
					lastException = e;
				}
			}
			if (lastException != null) {
				throw lastException;
			}			
			return true;
		}

		#endregion

	}

	#endregion

	#region Class: GenerateAnniversaryRemindings

	/// <exclude/>
	public class GenerateAnniversaryRemindings : Terrasoft.Core.Process.Process
	{

		#region Class: ProcessLane1

		/// <exclude/>
		public class ProcessLane1 : ProcessLane
		{

			public ProcessLane1(UserConnection userConnection, GenerateAnniversaryRemindings process)
				: base(userConnection) {
				Owner = process;
				IsUsedParentUserContexts = false;
			}

		}

		#endregion

		public GenerateAnniversaryRemindings(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "GenerateAnniversaryRemindings";
			SchemaUId = new Guid("ea728d44-cef0-4c18-8017-0e0532c7338e");
			Caption = Schema.Caption;
			SchemaManagerName = "ProcessSchemaManager";
			SerializeToDB = false;
			SerializeToMemory = true;
			IsLogging = false;
			UseSystemSecurityContext = false;
			_notificationCaption = () => { return new LocalizableString((Caption)); };
			ProcessModel = new GenerateAnniversaryRemindingsMethodsWrapper(this);
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("ea728d44-cef0-4c18-8017-0e0532c7338e");
			}
		}

		private string ConditionalExpressionLogMessage {
			get {
				return "Process: GenerateAnniversaryRemindings, Source element: {0}, Conditional flow: {1}, Expression: {2}, Result: {3}";
			}
		}

		private string DeadEndGatewayLogMessage {
			get {
				return "Process: GenerateAnniversaryRemindings, Source element: {0}, None of the exclusive gateway conditions are met!";
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

		private ProcessFlowElement _start1;
		public ProcessFlowElement Start1 {
			get {
				return _start1 ?? (_start1 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartEvent",
					Name = "Start1",
					SchemaElementUId = new Guid("528e9bac-1ed2-4e52-8225-6cb1c5f70e0e"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
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
					SchemaElementUId = new Guid("621e8ff4-222d-4239-a838-9104b30d406d"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
				});
			}
		}

		private ProcessScriptTask _generateReminding;
		public ProcessScriptTask GenerateReminding {
			get {
				return _generateReminding ?? (_generateReminding = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "GenerateReminding",
					SchemaElementUId = new Guid("c4cc0ca4-aabf-45e6-af76-18930d341b4c"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = ProcessModel.GetScriptTaskMethod("GenerateRemindingExecute"),
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[Start1.SchemaElementUId] = new Collection<ProcessFlowElement> { Start1 };
			FlowElements[Terminate1.SchemaElementUId] = new Collection<ProcessFlowElement> { Terminate1 };
			FlowElements[GenerateReminding.SchemaElementUId] = new Collection<ProcessFlowElement> { GenerateReminding };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "Start1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("GenerateReminding", e.Context.SenderName));
						break;
					case "Terminate1":
						CompleteProcess();
						break;
					case "GenerateReminding":
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
			var cloneItem = (GenerateAnniversaryRemindings)base.CloneShallow();
			cloneItem.ExecutedEventHandler = ExecutedEventHandler;
			return cloneItem;
		}

		#endregion

	}

	#endregion

}

