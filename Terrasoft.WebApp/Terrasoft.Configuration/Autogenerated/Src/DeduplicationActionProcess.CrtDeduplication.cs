namespace Terrasoft.Core.Process
{

	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Data;
	using System.Drawing;
	using System.Globalization;
	using System.Linq;
	using System.Text;
	using Terrasoft.Common;
	using Terrasoft.Configuration;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Factories;
	using Terrasoft.Core.Process;
	using Terrasoft.Core.Process.Configuration;

	#region Class: DeduplicationActionProcessSchema

	/// <exclude/>
	public class DeduplicationActionProcessSchema : Terrasoft.Core.Process.ProcessSchema
	{

		#region Constructors: Public

		public DeduplicationActionProcessSchema(ProcessSchemaManager processSchemaManager)
			: base(processSchemaManager) {
		}

		public DeduplicationActionProcessSchema(DeduplicationActionProcessSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			Name = "DeduplicationActionProcess";
			UId = new Guid("21b965c8-37af-4e87-ae30-b6cc5866d666");
			CreatedInPackageId = new Guid("a2cb4b0a-72d7-4fbf-b57c-bc3bae7898e7");
			CreatedInSchemaUId = Guid.Empty;
			CreatedInVersion = @"7.7.0.0";
			CultureName = @"en-US";
			EntitySchemaUId = Guid.Empty;
			IsCreatedInSvg = true;
			ModifiedInSchemaUId = Guid.Empty;
			ParametersEditPageSchemaUId = Guid.Empty;
			ParentSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d");
			SequenceFlowStrokeDefColor = Color.FromArgb(-4473925);
			SerializeToDB = true;
			SerializeToMemory = true;
			TaskFillDefColor = Color.FromArgb(-1);
			UsageType = ProcessSchemaUsageType.Advanced;
			ZipMethodsBody = new byte[] {  };
			ZipCompiledMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,237,83,77,111,218,64,16,61,131,196,127,152,228,144,172,37,203,202,185,1,163,20,90,74,213,4,41,86,148,67,149,195,198,30,96,43,179,182,246,131,138,126,252,247,142,119,13,152,24,210,92,122,171,132,145,118,118,222,155,183,51,111,122,221,210,62,231,34,133,181,80,198,242,28,214,133,200,224,150,11,201,2,248,217,235,118,196,28,216,172,68,197,141,40,228,52,131,193,0,198,152,217,146,48,46,52,42,164,54,58,74,144,171,116,217,72,244,232,78,146,46,113,197,239,248,10,97,0,141,195,112,8,218,40,33,23,209,135,85,105,54,215,85,174,15,124,125,2,189,203,211,7,168,40,161,178,134,93,254,186,12,28,96,94,40,228,233,18,152,71,54,112,32,100,147,37,122,92,162,66,38,157,140,24,206,18,95,122,170,239,108,158,207,212,227,82,24,76,74,158,250,148,32,168,197,119,220,227,148,77,77,161,110,212,194,174,80,154,6,237,46,52,0,137,223,225,72,50,59,223,103,159,135,13,168,215,127,148,223,106,84,20,151,152,86,141,124,75,141,67,4,213,121,56,8,212,181,14,166,118,227,110,62,97,78,3,3,222,60,12,96,148,115,173,63,242,170,198,38,154,160,233,159,68,198,172,221,140,208,21,235,28,127,69,45,165,89,48,122,143,11,33,189,125,152,191,255,77,127,213,247,118,247,221,162,90,96,219,124,95,132,54,253,137,21,89,12,91,12,234,42,72,175,28,111,3,247,152,22,42,155,102,26,184,134,61,194,41,25,11,167,148,171,77,223,91,44,172,93,27,131,66,93,228,107,204,72,193,156,136,76,229,212,251,86,140,40,79,115,92,239,52,30,201,41,158,191,81,239,226,24,172,212,156,56,189,204,90,252,67,43,118,70,254,32,47,195,16,62,107,215,150,53,42,19,141,145,198,32,120,46,126,224,204,241,245,255,86,46,102,45,238,0,222,57,110,39,87,144,21,23,170,176,101,53,12,96,116,12,118,157,156,248,184,207,163,193,189,178,102,251,157,14,224,226,226,229,116,182,143,161,27,239,166,109,69,186,184,106,231,71,163,194,146,172,24,174,254,209,222,38,255,247,246,196,222,186,197,99,245,120,194,23,115,9,219,75,18,182,237,124,176,243,244,235,117,255,0,87,184,20,118,148,6,0,0 };
			RealUId = new Guid("21b965c8-37af-4e87-ae30-b6cc5866d666");
			Version = 0;
			PackageUId = new Guid("438290c5-0107-b9b9-a78e-74fa3af92817");
			UseSystemSecurityContext = false;
		}

		protected virtual ProcessSchemaParameter CreateSchemaNameParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("b3039b1a-323a-4fee-b5d7-437acd810775"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("21b965c8-37af-4e87-ae30-b6cc5866d666"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("21b965c8-37af-4e87-ae30-b6cc5866d666"),
				Name = @"SchemaName",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("ShortText"),
			};
		}

		protected virtual ProcessSchemaParameter CreateOperationIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("f007b958-c46e-4876-8331-220fd44c5f13"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("21b965c8-37af-4e87-ae30-b6cc5866d666"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("21b965c8-37af-4e87-ae30-b6cc5866d666"),
				Name = @"OperationId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid"),
			};
		}

		protected virtual ProcessSchemaParameter CreateDuplicateRecordIdsParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("8a830a8e-6b86-43e9-9f30-0bee4ad0ab01"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("21b965c8-37af-4e87-ae30-b6cc5866d666"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("21b965c8-37af-4e87-ae30-b6cc5866d666"),
				Name = @"DuplicateRecordIds",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Object"),
			};
		}

		protected virtual ProcessSchemaParameter CreateDuplicateGroupIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("12e32a26-3adb-4e83-8022-cee5d7aca001"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("21b965c8-37af-4e87-ae30-b6cc5866d666"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("21b965c8-37af-4e87-ae30-b6cc5866d666"),
				Name = @"DuplicateGroupId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Object"),
			};
		}

		protected virtual ProcessSchemaParameter CreateResolvedConflictsParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("3872c3e8-715d-44c8-9718-782b83aca273"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("21b965c8-37af-4e87-ae30-b6cc5866d666"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("21b965c8-37af-4e87-ae30-b6cc5866d666"),
				Name = @"ResolvedConflicts",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Object"),
			};
		}

		protected virtual ProcessSchemaParameter CreateUnsavedRecordListParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("52e4fe66-7ec4-44ac-9583-3d5d5cdd5be8"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("21b965c8-37af-4e87-ae30-b6cc5866d666"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("21b965c8-37af-4e87-ae30-b6cc5866d666"),
				Name = @"UnsavedRecordList",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MaxSizeText"),
			};
		}

		protected override void InitializeParameters() {
			base.InitializeParameters();
			Parameters.Add(CreateSchemaNameParameter());
			Parameters.Add(CreateOperationIdParameter());
			Parameters.Add(CreateDuplicateRecordIdsParameter());
			Parameters.Add(CreateDuplicateGroupIdParameter());
			Parameters.Add(CreateResolvedConflictsParameter());
			Parameters.Add(CreateUnsavedRecordListParameter());
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
			ProcessSchemaScriptTask mainscripttask = CreateMainScriptTaskScriptTask();
			FlowElements.Add(mainscripttask);
			FlowElements.Add(CreateSequenceFlow1SequenceFlow());
			FlowElements.Add(CreateSequenceFlow2SequenceFlow());
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow1SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow1",
				UId = new Guid("799ada9b-5721-4a7d-ad52-8698e17b1669"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("a2cb4b0a-72d7-4fbf-b57c-bc3bae7898e7"),
				CreatedInSchemaUId = new Guid("21b965c8-37af-4e87-ae30-b6cc5866d666"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("21b965c8-37af-4e87-ae30-b6cc5866d666"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("ee9e24df-15f7-43b8-bc2f-fda897bde191"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("df8220cf-a667-4938-ba9b-5e4a19232e43"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow2SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow2",
				UId = new Guid("b4fd70d0-fa55-42b7-806f-e2402e3ee028"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("a2cb4b0a-72d7-4fbf-b57c-bc3bae7898e7"),
				CreatedInSchemaUId = new Guid("21b965c8-37af-4e87-ae30-b6cc5866d666"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("21b965c8-37af-4e87-ae30-b6cc5866d666"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("df8220cf-a667-4938-ba9b-5e4a19232e43"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("884985ea-3105-49b0-9fa8-d7bab09690f3"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaLaneSet CreateLaneSet1LaneSet() {
			ProcessSchemaLaneSet schemaLaneSet1 = new ProcessSchemaLaneSet(this) {
				UId = new Guid("d90ef81b-0a9d-4bf1-8858-6d5856b6c40d"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("a2cb4b0a-72d7-4fbf-b57c-bc3bae7898e7"),
				CreatedInSchemaUId = new Guid("21b965c8-37af-4e87-ae30-b6cc5866d666"),
				Direction = ProcessSchemaPoolDirectionType.Vertical,
				DragGroupName = @"LaneSet",
				ManagerItemUId = new Guid("11a47caf-a0d5-41fa-a274-a0b11f77447a"),
				ModifiedInSchemaUId = new Guid("21b965c8-37af-4e87-ae30-b6cc5866d666"),
				Name = @"LaneSet1",
				Position = new Point(0, 0),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLaneSet1;
		}

		protected virtual ProcessSchemaLane CreateLane1Lane() {
			ProcessSchemaLane schemaLane1 = new ProcessSchemaLane(this) {
				UId = new Guid("6cb6819d-e37b-4f6d-a546-d74bbdb40e8b"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = new Guid("d90ef81b-0a9d-4bf1-8858-6d5856b6c40d"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("a2cb4b0a-72d7-4fbf-b57c-bc3bae7898e7"),
				CreatedInSchemaUId = new Guid("21b965c8-37af-4e87-ae30-b6cc5866d666"),
				DragGroupName = @"Lane",
				ManagerItemUId = new Guid("abcd74b9-5912-414b-82ac-f1aa4dcd554e"),
				ModifiedInSchemaUId = new Guid("21b965c8-37af-4e87-ae30-b6cc5866d666"),
				Name = @"Lane1",
				Position = new Point(0, 0),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLane1;
		}

		protected virtual ProcessSchemaStartEvent CreateStart1StartEvent() {
			ProcessSchemaStartEvent schemaStartEvent = new ProcessSchemaStartEvent(this) {
				UId = new Guid("ee9e24df-15f7-43b8-bc2f-fda897bde191"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = new Guid("6cb6819d-e37b-4f6d-a546-d74bbdb40e8b"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("a2cb4b0a-72d7-4fbf-b57c-bc3bae7898e7"),
				CreatedInSchemaUId = new Guid("21b965c8-37af-4e87-ae30-b6cc5866d666"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsInterrupting = false,
				IsLogging = true,
				ManagerItemUId = new Guid("53818048-7868-48f6-ada0-0ebaa65af628"),
				ModifiedInSchemaUId = new Guid("21b965c8-37af-4e87-ae30-b6cc5866d666"),
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
				UId = new Guid("884985ea-3105-49b0-9fa8-d7bab09690f3"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = new Guid("6cb6819d-e37b-4f6d-a546-d74bbdb40e8b"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("a2cb4b0a-72d7-4fbf-b57c-bc3bae7898e7"),
				CreatedInSchemaUId = new Guid("21b965c8-37af-4e87-ae30-b6cc5866d666"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsLogging = true,
				ManagerItemUId = new Guid("1bd93619-0574-454e-bb4e-cf53b9eb9470"),
				ModifiedInSchemaUId = new Guid("21b965c8-37af-4e87-ae30-b6cc5866d666"),
				Name = @"Terminate1",
				Position = new Point(680, 184),
				SerializeToDB = false,
				Size = new Size(27, 27),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaTerminateEvent;
		}

		protected virtual ProcessSchemaScriptTask CreateMainScriptTaskScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("df8220cf-a667-4938-ba9b-5e4a19232e43"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = new Guid("6cb6819d-e37b-4f6d-a546-d74bbdb40e8b"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("a2cb4b0a-72d7-4fbf-b57c-bc3bae7898e7"),
				CreatedInSchemaUId = new Guid("21b965c8-37af-4e87-ae30-b6cc5866d666"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("21b965c8-37af-4e87-ae30-b6cc5866d666"),
				Name = @"MainScriptTask",
				Position = new Point(340, 170),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,243,77,204,204,211,208,180,230,229,42,74,45,41,45,202,83,40,41,42,77,181,6,0,176,217,148,41,21,0,0,0 }
			};
			
			return ScriptTask;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeUsings() {
			Usings.Add(new SchemaUsing() {
				UId = new Guid("e7af5a8c-13a2-430e-9323-59fa83ba2875"),
				Name = "Terrasoft.Configuration",
				Alias = "",
				CreatedInPackageId = new Guid("a2cb4b0a-72d7-4fbf-b57c-bc3bae7898e7")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("99f8556b-9d3f-42f2-823e-784708f4f25b"),
				Name = "System.Data",
				Alias = "",
				CreatedInPackageId = new Guid("a2cb4b0a-72d7-4fbf-b57c-bc3bae7898e7")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("3669c994-a9bd-4e68-be31-75ce83e8ebbb"),
				Name = "Terrasoft.Core.Factories",
				Alias = "",
				CreatedInPackageId = new Guid("a2cb4b0a-72d7-4fbf-b57c-bc3bae7898e7")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("c8636092-31d5-4e58-a47f-ac2a3230646c"),
				Name = "System",
				Alias = "",
				CreatedInPackageId = new Guid("a2cb4b0a-72d7-4fbf-b57c-bc3bae7898e7")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("203753cd-b2e5-42a2-ae80-455ece8c8a7a"),
				Name = "System.Linq",
				Alias = "",
				CreatedInPackageId = new Guid("a2cb4b0a-72d7-4fbf-b57c-bc3bae7898e7")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("8a0cfab0-46b1-4a58-842c-a08e72ee8d96"),
				Name = "Newtonsoft.Json",
				Alias = "",
				CreatedInPackageId = new Guid("a2cb4b0a-72d7-4fbf-b57c-bc3bae7898e7")
			});
		}

		#endregion

		#region Methods: Public

		public override Process CreateProcess(UserConnection userConnection) {
			return new DeduplicationActionProcess(userConnection);
		}

		public override object Clone() {
			return new DeduplicationActionProcessSchema(this);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("21b965c8-37af-4e87-ae30-b6cc5866d666"));
		}

		#endregion

	}

	#endregion

	#region Class: DeduplicationActionProcess

	/// <exclude/>
	public class DeduplicationActionProcess : Terrasoft.Core.Process.Process
	{

		#region Class: ProcessLane1

		/// <exclude/>
		public class ProcessLane1 : ProcessLane
		{

			public ProcessLane1(UserConnection userConnection, DeduplicationActionProcess process)
				: base(userConnection) {
				Owner = process;
				IsUsedParentUserContexts = false;
			}

		}

		#endregion

		public DeduplicationActionProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "DeduplicationActionProcess";
			SchemaUId = new Guid("21b965c8-37af-4e87-ae30-b6cc5866d666");
			Caption = Schema.Caption;
			SchemaManagerName = "ProcessSchemaManager";
			SerializeToDB = true;
			SerializeToMemory = true;
			IsLogging = true;
			UseSystemSecurityContext = false;
			_notificationCaption = () => { return new LocalizableString((Caption)); };
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("21b965c8-37af-4e87-ae30-b6cc5866d666");
			}
		}

		private string ConditionalExpressionLogMessage {
			get {
				return "Process: DeduplicationActionProcess, Source element: {0}, Conditional flow: {1}, Expression: {2}, Result: {3}";
			}
		}

		private string DeadEndGatewayLogMessage {
			get {
				return "Process: DeduplicationActionProcess, Source element: {0}, None of the exclusive gateway conditions are met!";
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

		public virtual string SchemaName {
			get;
			set;
		}

		public virtual Guid OperationId {
			get;
			set;
		}

		public virtual Object DuplicateRecordIds {
			get;
			set;
		}

		public virtual Object DuplicateGroupId {
			get;
			set;
		}

		public virtual Object ResolvedConflicts {
			get;
			set;
		}

		public virtual string UnsavedRecordList {
			get;
			set;
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
					SchemaElementUId = new Guid("ee9e24df-15f7-43b8-bc2f-fda897bde191"),
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
					SchemaElementUId = new Guid("884985ea-3105-49b0-9fa8-d7bab09690f3"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
				});
			}
		}

		private ProcessScriptTask _mainScriptTask;
		public ProcessScriptTask MainScriptTask {
			get {
				return _mainScriptTask ?? (_mainScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "MainScriptTask",
					SchemaElementUId = new Guid("df8220cf-a667-4938-ba9b-5e4a19232e43"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = MainScriptTaskExecute,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[Start1.SchemaElementUId] = new Collection<ProcessFlowElement> { Start1 };
			FlowElements[Terminate1.SchemaElementUId] = new Collection<ProcessFlowElement> { Terminate1 };
			FlowElements[MainScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { MainScriptTask };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "Start1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("MainScriptTask", e.Context.SenderName));
						break;
					case "Terminate1":
						CompleteProcess();
						break;
					case "MainScriptTask":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("Terminate1", e.Context.SenderName));
						break;
			}
		}

		private void WritePropertyValues(DataWriter writer, bool useAllValueSources) {
			if (!HasMapping("SchemaName")) {
				writer.WriteValue("SchemaName", SchemaName, null);
			}
			if (!HasMapping("OperationId")) {
				writer.WriteValue("OperationId", OperationId, Guid.Empty);
			}
			if (DuplicateRecordIds != null) {
				if (DuplicateRecordIds.GetType().IsSerializable ||
					DuplicateRecordIds.GetType().GetInterface("ISerializable") != null) {
					WriteSerializableObject(writer, "DuplicateRecordIds", DuplicateRecordIds, null);
				}
			}
			if (DuplicateGroupId != null) {
				if (DuplicateGroupId.GetType().IsSerializable ||
					DuplicateGroupId.GetType().GetInterface("ISerializable") != null) {
					WriteSerializableObject(writer, "DuplicateGroupId", DuplicateGroupId, null);
				}
			}
			if (ResolvedConflicts != null) {
				if (ResolvedConflicts.GetType().IsSerializable ||
					ResolvedConflicts.GetType().GetInterface("ISerializable") != null) {
					WriteSerializableObject(writer, "ResolvedConflicts", ResolvedConflicts, null);
				}
			}
			if (!HasMapping("UnsavedRecordList")) {
				writer.WriteValue("UnsavedRecordList", UnsavedRecordList, null);
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
			MetaPathParameterValues.Add("b3039b1a-323a-4fee-b5d7-437acd810775", () => SchemaName);
			MetaPathParameterValues.Add("f007b958-c46e-4876-8331-220fd44c5f13", () => OperationId);
			MetaPathParameterValues.Add("8a830a8e-6b86-43e9-9f30-0bee4ad0ab01", () => DuplicateRecordIds);
			MetaPathParameterValues.Add("12e32a26-3adb-4e83-8022-cee5d7aca001", () => DuplicateGroupId);
			MetaPathParameterValues.Add("3872c3e8-715d-44c8-9718-782b83aca273", () => ResolvedConflicts);
			MetaPathParameterValues.Add("52e4fe66-7ec4-44ac-9583-3d5d5cdd5be8", () => UnsavedRecordList);
		}

		protected override void ApplyPropertiesDataValues(DataReader reader) {
			base.ApplyPropertiesDataValues(reader);
			bool hasValueToRead = reader.HasValue();
			switch (reader.CurrentName) {
				case "SchemaName":
					if (!hasValueToRead) break;
					SchemaName = reader.GetValue<System.String>();
				break;
				case "OperationId":
					if (!hasValueToRead) break;
					OperationId = reader.GetValue<System.Guid>();
				break;
				case "DuplicateRecordIds":
					if (!hasValueToRead) break;
					DuplicateRecordIds = GetSerializableObject(reader);
				break;
				case "DuplicateGroupId":
					if (!hasValueToRead) break;
					DuplicateGroupId = GetSerializableObject(reader);
				break;
				case "ResolvedConflicts":
					if (!hasValueToRead) break;
					ResolvedConflicts = GetSerializableObject(reader);
				break;
				case "UnsavedRecordList":
					if (!hasValueToRead) break;
					UnsavedRecordList = reader.GetValue<System.String>();
				break;
			}
		}

		protected override void WritePropertyValues(DataWriter writer) {
			base.WritePropertyValues(writer);
			WritePropertyValues(writer, true);
		}

		#endregion

		#region Methods: Public

		public virtual bool MainScriptTaskExecute(ProcessExecutingContext context) {
			Main();
			return true;
		}

			
			public virtual void Main() {
				if (OperationId == DeduplicationConsts.SearchOperationId) {
					SchemaName = SchemaName ?? string.Empty;
					string[] schemaNames = SchemaName.Split('|');
					foreach (string schemaName in schemaNames.Where(name => !String.IsNullOrWhiteSpace(name))) {
						ConstructorArgument schemaNameArgument = new ConstructorArgument("schemaName", schemaName);
						ConstructorArgument userConnectionArgument = new ConstructorArgument("userConnection", UserConnection);
						DeduplicationActionHelper actionHelper = ClassFactory.Get<DeduplicationActionHelper>(schemaNameArgument,
							userConnectionArgument);
						actionHelper.BeginSearch();
					}
				}
				
				if (OperationId == DeduplicationConsts.MergeOperationId) {
					List<Guid> duplicatesList = DuplicateRecordIds as List<Guid>;
					Dictionary<string, string> resolvedConflicts = ResolvedConflicts as Dictionary<string, string>;
					List<Dictionary<string, object>> unsavedRecordList = UnsavedRecordList != null ? JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(UnsavedRecordList) : null;
					int groupId = (int)DuplicateGroupId;
					if (!String.IsNullOrWhiteSpace(SchemaName) && duplicatesList != null && 
							groupId != 0 && duplicatesList.Count > 0) {
						ConstructorArgument schemaNameArgument = new ConstructorArgument("schemaName", SchemaName);
						ConstructorArgument userConnectionArgument = new ConstructorArgument("userConnection", UserConnection);
						DeduplicationActionHelper actionHelper = ClassFactory.Get<DeduplicationActionHelper>(schemaNameArgument,
							userConnectionArgument);
						actionHelper.BeginMerge(groupId, duplicatesList, resolvedConflicts, unsavedRecordList);
					}
				}
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
			var cloneItem = (DeduplicationActionProcess)base.CloneShallow();
			cloneItem.ExecutedEventHandler = ExecutedEventHandler;
			cloneItem.DuplicateRecordIds = DuplicateRecordIds;
			cloneItem.DuplicateGroupId = DuplicateGroupId;
			cloneItem.ResolvedConflicts = ResolvedConflicts;
			return cloneItem;
		}

		#endregion

	}

	#endregion

}

