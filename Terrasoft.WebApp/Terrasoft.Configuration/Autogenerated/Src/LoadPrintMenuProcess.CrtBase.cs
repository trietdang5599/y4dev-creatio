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
	using Terrasoft.Core.Store;
	using Terrasoft.Reports;
	using TSConfiguration = Terrasoft.Configuration;

	#region Class: LoadPrintMenuProcessSchema

	/// <exclude/>
	public class LoadPrintMenuProcessSchema : Terrasoft.Core.Process.ProcessSchema
	{

		#region Constructors: Public

		public LoadPrintMenuProcessSchema(ProcessSchemaManager processSchemaManager)
			: base(processSchemaManager) {
		}

		public LoadPrintMenuProcessSchema(LoadPrintMenuProcessSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			Name = "LoadPrintMenuProcess";
			UId = new Guid("b7e6c182-5e8a-42d3-9de3-0e739f6632f4");
			BackgroundModePriority = BackgroundModePriority.Medium;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			CreatedInSchemaUId = Guid.Empty;
			CreatedInVersion = @"0.0.0.0";
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
			ZipMethodsBody = new byte[] {  };
			ZipCompiledMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,149,86,109,111,226,56,16,254,220,149,246,63,120,253,225,20,212,16,181,148,150,114,92,239,14,2,84,72,109,183,106,224,250,161,90,157,12,49,52,219,16,71,142,195,150,189,237,127,191,177,157,87,66,216,110,95,146,216,158,121,102,230,153,25,219,31,63,132,241,220,247,22,104,227,113,17,19,31,109,152,231,162,27,70,220,91,26,196,70,3,253,247,241,195,209,134,112,180,134,33,186,66,114,22,145,8,77,41,231,36,98,75,97,205,38,214,35,157,219,44,16,156,249,145,149,125,72,201,1,137,168,205,124,159,46,132,199,130,30,64,121,75,100,40,168,79,87,40,136,125,95,27,80,22,72,24,218,100,241,76,193,202,44,162,28,128,2,173,103,57,52,138,224,173,86,173,71,79,60,223,176,5,241,229,208,11,86,198,212,1,209,165,183,138,57,81,210,74,108,38,60,223,19,30,141,172,71,198,95,162,144,44,168,154,191,230,44,14,27,189,212,38,167,33,227,34,202,125,4,227,121,104,59,184,108,189,102,65,14,124,77,133,67,165,218,144,8,98,148,93,54,127,5,229,150,185,177,79,31,180,43,26,210,204,216,0,164,195,241,37,122,106,86,7,22,9,14,188,160,5,9,165,60,196,22,175,131,59,178,166,191,22,219,205,226,123,174,90,9,15,59,219,168,232,55,134,41,91,27,196,57,189,33,89,81,7,252,90,147,91,18,192,55,175,230,86,178,88,148,48,240,253,174,18,110,28,172,184,138,188,50,95,201,172,229,192,216,112,129,222,21,17,212,24,122,106,150,240,237,31,154,47,19,177,249,87,16,253,19,133,167,38,58,180,220,130,162,69,210,6,24,17,49,15,64,225,169,66,246,23,107,202,28,165,105,52,36,189,33,225,116,202,140,176,117,88,180,209,123,211,244,45,25,167,144,82,100,228,101,138,188,160,90,176,73,3,29,93,199,208,183,81,154,148,137,11,76,7,244,27,146,211,134,86,122,194,133,101,92,54,170,32,100,111,58,69,132,171,34,96,106,72,91,210,144,63,49,243,144,8,237,51,166,97,196,54,172,241,85,175,236,213,44,215,55,40,39,58,7,137,45,235,62,83,63,148,5,68,95,117,12,169,213,210,60,222,163,47,57,74,157,46,120,141,207,90,227,78,203,238,218,77,120,118,154,237,246,232,164,121,105,95,182,155,103,109,187,59,26,158,118,236,254,249,9,110,100,28,22,73,212,181,59,171,229,242,161,44,181,151,146,44,253,159,21,5,81,222,19,179,82,124,53,18,248,139,140,102,56,184,131,29,217,250,135,248,49,69,127,41,63,172,209,58,20,91,244,251,94,199,246,35,237,243,78,178,86,235,220,85,209,210,143,31,213,77,195,26,123,129,59,17,116,61,216,130,66,29,80,99,231,72,145,63,242,164,177,250,174,107,216,208,76,130,202,35,73,226,24,73,165,152,187,25,40,248,158,66,28,29,163,191,241,111,24,29,215,177,91,208,65,153,108,169,142,204,12,11,223,131,160,208,9,77,157,249,23,31,167,205,148,67,97,216,69,77,36,120,76,115,18,223,244,251,13,81,63,162,168,174,16,47,7,118,235,188,59,26,55,219,173,206,69,179,221,61,185,104,14,58,253,139,102,235,108,104,159,119,7,163,206,120,212,42,22,226,59,41,170,56,247,147,152,128,131,186,168,150,4,252,207,194,210,81,169,167,124,192,63,252,201,223,157,123,201,251,46,28,210,56,218,137,36,105,249,116,108,167,129,237,204,79,201,42,155,147,164,76,134,38,154,51,230,35,47,26,210,205,232,53,228,112,11,209,97,150,111,69,202,166,78,193,251,157,212,27,74,170,110,77,134,128,160,173,246,142,138,11,186,125,85,131,220,209,111,42,197,101,77,59,219,5,119,2,220,39,5,91,35,147,103,176,122,91,99,206,214,125,190,154,27,39,102,203,236,116,204,211,243,139,50,54,80,82,192,133,81,105,181,255,149,188,142,54,52,16,16,30,100,234,197,114,188,85,64,252,228,166,81,101,13,182,20,252,57,164,129,170,151,221,197,91,248,130,174,194,176,213,224,36,127,14,220,220,220,242,106,122,131,252,84,151,147,3,222,77,162,89,232,195,189,22,124,147,125,213,211,197,150,30,225,169,94,175,174,254,212,189,88,186,175,205,201,45,32,173,44,56,218,33,102,65,121,148,23,198,11,221,38,68,20,251,227,62,147,84,161,236,191,230,202,235,228,83,162,15,251,114,1,62,117,238,127,50,129,72,192,181,11,0,0 };
			RealUId = new Guid("b7e6c182-5e8a-42d3-9de3-0e739f6632f4");
			Version = 0;
			PackageUId = new Guid("06d9ef10-51d8-122c-8933-9212e84236c9");
			UseSystemSecurityContext = false;
		}

		protected virtual ProcessSchemaParameter CreateMenuParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("8d814a0f-f49c-47b8-811a-9d7fcedd7c1f"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b7e6c182-5e8a-42d3-9de3-0e739f6632f4"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = false,
				ModifiedInSchemaUId = new Guid("b7e6c182-5e8a-42d3-9de3-0e739f6632f4"),
				Name = @"Menu",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Object"),
			};
		}

		protected virtual ProcessSchemaParameter CreateSysModuleIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("720ead89-8627-4304-a359-d709a91ead74"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b7e6c182-5e8a-42d3-9de3-0e739f6632f4"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b7e6c182-5e8a-42d3-9de3-0e739f6632f4"),
				Name = @"SysModuleId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid"),
			};
		}

		protected override void InitializeParameters() {
			base.InitializeParameters();
			Parameters.Add(CreateMenuParameter());
			Parameters.Add(CreateSysModuleIdParameter());
		}

		protected override void InitializeBaseElements() {
			base.InitializeBaseElements();
			ProcessSchemaLaneSet schemaLaneSet4 = CreateLaneSet4LaneSet();
			LaneSets.Add(schemaLaneSet4);
			ProcessSchemaLane schemaLane8 = CreateLane8Lane();
			schemaLaneSet4.Lanes.Add(schemaLane8);
			ProcessSchemaStartEvent start1 = CreateStart1StartEvent();
			FlowElements.Add(start1);
			ProcessSchemaEndEvent end1 = CreateEnd1EndEvent();
			FlowElements.Add(end1);
			ProcessSchemaScriptTask scripttask1 = CreateScriptTask1ScriptTask();
			FlowElements.Add(scripttask1);
			FlowElements.Add(CreateSequenceFlow17SequenceFlow());
			FlowElements.Add(CreateSequenceFlow18SequenceFlow());
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow17SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow17",
				UId = new Guid("f1217494-1fb3-445d-9f17-0fcfc701b6f6"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("b7e6c182-5e8a-42d3-9de3-0e739f6632f4"),
				CurveCenterPosition = new Point(174, 92),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("b7e6c182-5e8a-42d3-9de3-0e739f6632f4"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("97ae99d0-c2e3-47dd-a4dd-8a6878366ee1"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("776ac1f3-00bb-472b-a5ee-8a9a1b2a43be"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow18SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow18",
				UId = new Guid("99284bf7-21f1-4235-9ee8-97831b800760"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("b7e6c182-5e8a-42d3-9de3-0e739f6632f4"),
				CurveCenterPosition = new Point(324, 96),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("b7e6c182-5e8a-42d3-9de3-0e739f6632f4"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("776ac1f3-00bb-472b-a5ee-8a9a1b2a43be"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("b0634007-ed0b-46c9-860c-e2819299abfb"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaLaneSet CreateLaneSet4LaneSet() {
			ProcessSchemaLaneSet schemaLaneSet4 = new ProcessSchemaLaneSet(this) {
				UId = new Guid("22a03e1e-7d55-4798-a4f9-8501cbfc71d1"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 1,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("b7e6c182-5e8a-42d3-9de3-0e739f6632f4"),
				Direction = ProcessSchemaPoolDirectionType.Vertical,
				DragGroupName = @"LaneSet",
				ManagerItemUId = new Guid("11a47caf-a0d5-41fa-a274-a0b11f77447a"),
				ModifiedInSchemaUId = new Guid("b7e6c182-5e8a-42d3-9de3-0e739f6632f4"),
				Name = @"LaneSet4",
				Position = new Point(5, 5),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLaneSet4;
		}

		protected virtual ProcessSchemaLane CreateLane8Lane() {
			ProcessSchemaLane schemaLane8 = new ProcessSchemaLane(this) {
				UId = new Guid("b499f499-2977-45ce-aa15-281af0a76bba"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 1,
				ContainerUId = new Guid("22a03e1e-7d55-4798-a4f9-8501cbfc71d1"),
				CreatedInOwnerSchemaUId = new Guid("b7e6c182-5e8a-42d3-9de3-0e739f6632f4"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("b7e6c182-5e8a-42d3-9de3-0e739f6632f4"),
				DragGroupName = @"Lane",
				ManagerItemUId = new Guid("abcd74b9-5912-414b-82ac-f1aa4dcd554e"),
				ModifiedInSchemaUId = new Guid("b7e6c182-5e8a-42d3-9de3-0e739f6632f4"),
				Name = @"Lane8",
				Position = new Point(29, 0),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLane8;
		}

		protected virtual ProcessSchemaStartEvent CreateStart1StartEvent() {
			ProcessSchemaStartEvent schemaStartEvent = new ProcessSchemaStartEvent(this) {
				UId = new Guid("97ae99d0-c2e3-47dd-a4dd-8a6878366ee1"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = new Guid("b499f499-2977-45ce-aa15-281af0a76bba"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("b7e6c182-5e8a-42d3-9de3-0e739f6632f4"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsInterrupting = false,
				IsLogging = true,
				ManagerItemUId = new Guid("53818048-7868-48f6-ada0-0ebaa65af628"),
				ModifiedInSchemaUId = new Guid("b7e6c182-5e8a-42d3-9de3-0e739f6632f4"),
				Name = @"Start1",
				Position = new Point(57, 72),
				SerializeToDB = false,
				Size = new Size(27, 27),
				UseBackgroundMode = false
			};
			
			return schemaStartEvent;
		}

		protected virtual ProcessSchemaEndEvent CreateEnd1EndEvent() {
			ProcessSchemaEndEvent schemaEndEvent = new ProcessSchemaEndEvent(this) {
				UId = new Guid("b0634007-ed0b-46c9-860c-e2819299abfb"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = new Guid("b499f499-2977-45ce-aa15-281af0a76bba"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("b7e6c182-5e8a-42d3-9de3-0e739f6632f4"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsLogging = true,
				ManagerItemUId = new Guid("45ceaae2-4e1f-4c0c-86aa-cd4aeb4da913"),
				ModifiedInSchemaUId = new Guid("b7e6c182-5e8a-42d3-9de3-0e739f6632f4"),
				Name = @"End1",
				Position = new Point(316, 72),
				SerializeToDB = false,
				Size = new Size(27, 27),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaEndEvent;
		}

		protected virtual ProcessSchemaScriptTask CreateScriptTask1ScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("776ac1f3-00bb-472b-a5ee-8a9a1b2a43be"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = new Guid("b499f499-2977-45ce-aa15-281af0a76bba"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("b7e6c182-5e8a-42d3-9de3-0e739f6632f4"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("b7e6c182-5e8a-42d3-9de3-0e739f6632f4"),
				Name = @"ScriptTask1",
				Position = new Point(169, 58),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,243,201,79,76,241,77,205,43,213,208,180,230,229,2,49,20,108,21,242,74,115,114,128,188,162,212,146,210,162,60,133,146,162,210,84,107,0,71,19,235,36,39,0,0,0 }
			};
			
			return ScriptTask;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeUsings() {
			Usings.Add(new SchemaUsing() {
				UId = new Guid("7a147170-d041-4a67-b3b1-c7ff2b70fef8"),
				Name = "Terrasoft.Core.Entities",
				Alias = "",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("1ea5759e-7be8-45c7-a793-b66f77ab8b4f"),
				Name = "Terrasoft.Core.Store",
				Alias = "",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("b00609b8-3139-4513-8337-2a8cafd4a7fb"),
				Name = "Terrasoft.Configuration",
				Alias = "TSConfiguration",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("15406e8e-7657-422a-9d4c-760556f1a647"),
				Name = "Terrasoft.Reports",
				Alias = "",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			});
		}

		#endregion

		#region Methods: Public

		public override Process CreateProcess(UserConnection userConnection) {
			return new LoadPrintMenuProcess(userConnection);
		}

		public override object Clone() {
			return new LoadPrintMenuProcessSchema(this);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("b7e6c182-5e8a-42d3-9de3-0e739f6632f4"));
		}

		#endregion

	}

	#endregion

	#region Class: LoadPrintMenuProcess

	/// <exclude/>
	public class LoadPrintMenuProcess : Terrasoft.Core.Process.Process
	{

		#region Class: ProcessLane8

		/// <exclude/>
		public class ProcessLane8 : ProcessLane
		{

			public ProcessLane8(UserConnection userConnection, LoadPrintMenuProcess process)
				: base(userConnection) {
				Owner = process;
				IsUsedParentUserContexts = false;
			}

		}

		#endregion

		public LoadPrintMenuProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "LoadPrintMenuProcess";
			SchemaUId = new Guid("b7e6c182-5e8a-42d3-9de3-0e739f6632f4");
			Caption = Schema.Caption;
			SchemaManagerName = "ProcessSchemaManager";
			SerializeToDB = false;
			SerializeToMemory = true;
			IsLogging = false;
			UseSystemSecurityContext = false;
			_notificationCaption = () => { return new LocalizableString((Caption)); };
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("b7e6c182-5e8a-42d3-9de3-0e739f6632f4");
			}
		}

		private string ConditionalExpressionLogMessage {
			get {
				return "Process: LoadPrintMenuProcess, Source element: {0}, Conditional flow: {1}, Expression: {2}, Result: {3}";
			}
		}

		private string DeadEndGatewayLogMessage {
			get {
				return "Process: LoadPrintMenuProcess, Source element: {0}, None of the exclusive gateway conditions are met!";
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

		public virtual Object Menu {
			get;
			set;
		}

		public virtual Guid SysModuleId {
			get;
			set;
		}

		private ProcessLane8 _lane8;
		public ProcessLane8 Lane8 {
			get {
				return _lane8 ?? ((_lane8) = new ProcessLane8(UserConnection, this));
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
					SchemaElementUId = new Guid("97ae99d0-c2e3-47dd-a4dd-8a6878366ee1"),
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
					SchemaElementUId = new Guid("b0634007-ed0b-46c9-860c-e2819299abfb"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
				});
			}
		}

		private ProcessScriptTask _scriptTask1;
		public ProcessScriptTask ScriptTask1 {
			get {
				return _scriptTask1 ?? (_scriptTask1 = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ScriptTask1",
					SchemaElementUId = new Guid("776ac1f3-00bb-472b-a5ee-8a9a1b2a43be"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = ScriptTask1Execute,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[Start1.SchemaElementUId] = new Collection<ProcessFlowElement> { Start1 };
			FlowElements[End1.SchemaElementUId] = new Collection<ProcessFlowElement> { End1 };
			FlowElements[ScriptTask1.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptTask1 };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "Start1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ScriptTask1", e.Context.SenderName));
						break;
					case "End1":
						CompleteProcess();
						break;
					case "ScriptTask1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("End1", e.Context.SenderName));
						break;
			}
		}

		private void WritePropertyValues(DataWriter writer, bool useAllValueSources) {
			if (!HasMapping("SysModuleId")) {
				writer.WriteValue("SysModuleId", SysModuleId, Guid.Empty);
			}
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
			MetaPathParameterValues.Add("8d814a0f-f49c-47b8-811a-9d7fcedd7c1f", () => Menu);
			MetaPathParameterValues.Add("720ead89-8627-4304-a359-d709a91ead74", () => SysModuleId);
		}

		protected override void ApplyPropertiesDataValues(DataReader reader) {
			base.ApplyPropertiesDataValues(reader);
			bool hasValueToRead = reader.HasValue();
			switch (reader.CurrentName) {
				case "SysModuleId":
					if (!hasValueToRead) break;
					SysModuleId = reader.GetValue<System.Guid>();
				break;
			}
		}

		protected override void WritePropertyValues(DataWriter writer) {
			base.WritePropertyValues(writer);
			WritePropertyValues(writer, true);
		}

		#endregion

		#region Methods: Public

		public virtual bool ScriptTask1Execute(ProcessExecutingContext context) {
			LoadMenu();
			Menu = null;
			return true;
		}

			
			public virtual void LoadMenu() {
				var menu = Menu as Terrasoft.UI.WebControls.Controls.MenuBaseCollection;
				if (menu != null) {
					var appCache = UserConnection.SessionCache.WithLocalCaching(TSConfiguration.CacheUtilities.WorkspaceCacheGroup);
					var reportsCollection = Terrasoft.Configuration.CommonUtilities.GetSelectData(UserConnection, Terrasoft.Configuration.CommonUtilities.GetModuleReportsSelect, appCache, TSConfiguration.CacheUtilities.ReportsCache);
					string captionColumnName = Terrasoft.Configuration.CommonUtilities.GetLczColumnName(UserConnection, "SysModuleReport", "Caption");
					var pageSchemaManager = UserConnection.GetSchemaManager("PageSchemaManager") as Terrasoft.UI.WebControls.PageSchemaManager;
					reportsCollection.Sort(delegate(Dictionary<string, object> p1, Dictionary<string, object> p2) { 
						return p1[captionColumnName].ToString().CompareTo(p2[captionColumnName].ToString());});
					foreach (var report in reportsCollection) {
						Guid sysModuleId = new Guid(report["sysModuleId"].ToString());
						if (SysModuleId == sysModuleId) {
							Guid reportId = new Guid(report["sysModuleReportId"].ToString());
							Guid typeId = new Guid(report["typeId"].ToString());
							string caption = report[captionColumnName].ToString();
							string helpContextId = report["helpContextId"].ToString();
							if (typeId == new Guid("32F72C9C-72C7-44E0-8C84-34C9ED17CA50")) {
								Guid reportSchemaUId = new Guid(report["sysReportSchemaUId"].ToString());
								Guid sysOptionsPageSchemaUId = report["sysOptionsPageSchemaUId"] == DBNull.Value ? Guid.Empty : new Guid(report["sysOptionsPageSchemaUId"].ToString());
								if (sysOptionsPageSchemaUId == Guid.Empty || pageSchemaManager.FindItemByUId(sysOptionsPageSchemaUId) != null) {
									menu.Add(CreateMenuItem(caption, reportSchemaUId.ToString()
										+ @"&" + sysOptionsPageSchemaUId.ToString() + @"&" + helpContextId,
										"PrintReportMenuItem_"+reportId.ToString("n"), true));
								}
							} else if (typeId == new Guid("8BC259EF-4276-4906-B7A6-23DC59BE7FE2")) {
								menu.Add(CreateMenuItem(caption, reportId.ToString("n"),
										"PrintReportMenuItem_" + reportId.ToString("n"), false));
							}
						}
					}
				}
			}
			
			
			public virtual Terrasoft.UI.WebControls.Controls.MenuItem CreateMenuItem(string MenuItemCaption, string MenuItemTag, string menuID, bool isDevExpressReport) {
				var menuItem = new Terrasoft.UI.WebControls.Controls.MenuItem();
				menuItem.ID = menuID;	
				menuItem.UId = Guid.NewGuid();
				menuItem.Caption = MenuItemCaption;
				menuItem.CaptionColor = Color.FromArgb(0,2,77,156);
				menuItem.Tag = MenuItemTag;
				menuItem.AjaxEvents.Click.SignalName = isDevExpressReport ? "OpenPrintDevExpressReportMessage" : "CreateMSWordReportMessage";
				if (!isDevExpressReport) {
					menuItem.AjaxEvents.Click.IsUpload = true;
				}
				return menuItem;
			}
			
			
			public virtual void OpenReportPage(string parameters) {
				var keyName = "PrintReportParameters";
				UserConnection.SessionData[keyName] = parameters;
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
			var cloneItem = (LoadPrintMenuProcess)base.CloneShallow();
			cloneItem.ExecutedEventHandler = ExecutedEventHandler;
			cloneItem.Menu = Menu;
			return cloneItem;
		}

		#endregion

	}

	#endregion

}

