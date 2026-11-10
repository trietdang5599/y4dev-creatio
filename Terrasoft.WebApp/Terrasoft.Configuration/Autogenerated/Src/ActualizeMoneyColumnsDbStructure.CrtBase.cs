namespace Terrasoft.Core.Process
{

	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Drawing;
	using System.Globalization;
	using System.Linq;
	using System.Text;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Packages;
	using Terrasoft.Core.Process;
	using Terrasoft.Core.Process.Configuration;

	#region Class: ActualizeMoneyColumnsDbStructureSchema

	/// <exclude/>
	public class ActualizeMoneyColumnsDbStructureSchema : Terrasoft.Core.Process.ProcessSchema
	{

		#region Constructors: Public

		public ActualizeMoneyColumnsDbStructureSchema(ProcessSchemaManager processSchemaManager)
			: base(processSchemaManager) {
		}

		public ActualizeMoneyColumnsDbStructureSchema(ActualizeMoneyColumnsDbStructureSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			Name = "ActualizeMoneyColumnsDbStructure";
			UId = new Guid("da145d55-9e13-4850-b793-d144131e3849");
			CreatedInPackageId = new Guid("5e3d1956-5f66-4b70-a038-d893b5276a26");
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
			SerializeToMemory = false;
			TaskFillDefColor = Color.FromArgb(-1);
			UsageType = ProcessSchemaUsageType.Advanced;
			UseForceCompile = true;
			ZipMethodsBody = new byte[] {  };
			ZipCompiledMethodsBody = new byte[] {  };
			RealUId = new Guid("da145d55-9e13-4850-b793-d144131e3849");
			Version = 0;
			PackageUId = new Guid("06d9ef10-51d8-122c-8933-9212e84236c9");
			UseSystemSecurityContext = false;
		}

		protected virtual ProcessSchemaParameter CreateWriteMessageActionParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("9cded1e6-41ef-478e-a34b-0c9477d7d2d4"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("da145d55-9e13-4850-b793-d144131e3849"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("da145d55-9e13-4850-b793-d144131e3849"),
				Name = @"WriteMessageAction",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Object"),
			};
		}

		protected virtual ProcessSchemaParameter CreateNotUpdateMoneyStructureStartDateParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("81396900-691f-4903-8800-fa97fb6e90b4"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("da145d55-9e13-4850-b793-d144131e3849"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("da145d55-9e13-4850-b793-d144131e3849"),
				Name = @"NotUpdateMoneyStructureStartDate",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("DateTime"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.Script,
					Value = @"[#DateValue.06.08.2016#]",
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("da145d55-9e13-4850-b793-d144131e3849"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateResultStringParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("d765c621-e06e-42c3-9fe3-5ab78d8dcb6b"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("da145d55-9e13-4850-b793-d144131e3849"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("da145d55-9e13-4850-b793-d144131e3849"),
				Name = @"ResultString",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MetaDataTextDataValueType"),
			};
		}

		protected virtual ProcessSchemaParameter CreateExcludedSchemasParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("63ceb59f-2bfb-4ece-b672-61602e2bfd57"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("da145d55-9e13-4850-b793-d144131e3849"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("da145d55-9e13-4850-b793-d144131e3849"),
				Name = @"ExcludedSchemas",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MetaDataTextDataValueType"),
			};
		}

		protected override void InitializeParameters() {
			base.InitializeParameters();
			Parameters.Add(CreateWriteMessageActionParameter());
			Parameters.Add(CreateNotUpdateMoneyStructureStartDateParameter());
			Parameters.Add(CreateResultStringParameter());
			Parameters.Add(CreateExcludedSchemasParameter());
		}

		protected override void InitializeBaseElements() {
			base.InitializeBaseElements();
			ProcessSchemaLaneSet schemaLaneSet1 = CreateLaneSet1LaneSet();
			LaneSets.Add(schemaLaneSet1);
			ProcessSchemaLane schemaLane1 = CreateLane1Lane();
			schemaLaneSet1.Lanes.Add(schemaLane1);
			ProcessSchemaStartEvent startevent1 = CreateStartEvent1StartEvent();
			FlowElements.Add(startevent1);
			ProcessSchemaTerminateEvent terminateevent1 = CreateTerminateEvent1TerminateEvent();
			FlowElements.Add(terminateevent1);
			ProcessSchemaScriptTask scripttask1 = CreateScriptTask1ScriptTask();
			FlowElements.Add(scripttask1);
			FlowElements.Add(CreateSequenceFlow1SequenceFlow());
			FlowElements.Add(CreateSequenceFlow2SequenceFlow());
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow1SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow1",
				UId = new Guid("ba7d21c9-d4bb-4ff8-a549-5b15f80982bc"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("92407950-4ff4-47a3-be70-ffefec778136"),
				CreatedInSchemaUId = new Guid("da145d55-9e13-4850-b793-d144131e3849"),
				CurveCenterPosition = new Point(0, 0),
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("da145d55-9e13-4850-b793-d144131e3849"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("9b8acda0-6cd5-4437-b641-254a5f98b191"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("d8f2ee75-819e-4154-96b8-b2c435063954"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow2SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow2",
				UId = new Guid("9a48ca51-5d97-4a66-a28d-2f2b4b98bb91"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("92407950-4ff4-47a3-be70-ffefec778136"),
				CreatedInSchemaUId = new Guid("da145d55-9e13-4850-b793-d144131e3849"),
				CurveCenterPosition = new Point(0, 0),
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("da145d55-9e13-4850-b793-d144131e3849"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("d8f2ee75-819e-4154-96b8-b2c435063954"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("113d9d4f-fa38-4872-9caf-37636da9d452"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaLaneSet CreateLaneSet1LaneSet() {
			ProcessSchemaLaneSet schemaLaneSet1 = new ProcessSchemaLaneSet(this) {
				UId = new Guid("3dc9702d-8b43-479a-9ec1-ac5a8282935b"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("92407950-4ff4-47a3-be70-ffefec778136"),
				CreatedInSchemaUId = new Guid("da145d55-9e13-4850-b793-d144131e3849"),
				Direction = ProcessSchemaPoolDirectionType.Vertical,
				ManagerItemUId = new Guid("11a47caf-a0d5-41fa-a274-a0b11f77447a"),
				ModifiedInSchemaUId = new Guid("da145d55-9e13-4850-b793-d144131e3849"),
				Name = @"LaneSet1",
				Position = new Point(0, 0),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLaneSet1;
		}

		protected virtual ProcessSchemaLane CreateLane1Lane() {
			ProcessSchemaLane schemaLane1 = new ProcessSchemaLane(this) {
				UId = new Guid("d3e3c893-0c1d-403b-853b-bf21225ccc3b"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = new Guid("3dc9702d-8b43-479a-9ec1-ac5a8282935b"),
				CreatedInOwnerSchemaUId = new Guid("da145d55-9e13-4850-b793-d144131e3849"),
				CreatedInPackageId = new Guid("92407950-4ff4-47a3-be70-ffefec778136"),
				CreatedInSchemaUId = new Guid("da145d55-9e13-4850-b793-d144131e3849"),
				ManagerItemUId = new Guid("abcd74b9-5912-414b-82ac-f1aa4dcd554e"),
				ModifiedInSchemaUId = new Guid("da145d55-9e13-4850-b793-d144131e3849"),
				Name = @"Lane1",
				Position = new Point(0, 0),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLane1;
		}

		protected virtual ProcessSchemaStartEvent CreateStartEvent1StartEvent() {
			ProcessSchemaStartEvent schemaStartEvent = new ProcessSchemaStartEvent(this) {
				UId = new Guid("9b8acda0-6cd5-4437-b641-254a5f98b191"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = new Guid("d3e3c893-0c1d-403b-853b-bf21225ccc3b"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("92407950-4ff4-47a3-be70-ffefec778136"),
				CreatedInSchemaUId = new Guid("da145d55-9e13-4850-b793-d144131e3849"),
				EntitySchemaUId = Guid.Empty,
				IsInterrupting = false,
				IsLogging = true,
				ManagerItemUId = new Guid("53818048-7868-48f6-ada0-0ebaa65af628"),
				ModifiedInSchemaUId = new Guid("da145d55-9e13-4850-b793-d144131e3849"),
				Name = @"StartEvent1",
				Position = new Point(50, 184),
				SerializeToDB = false,
				Size = new Size(27, 27),
				UseBackgroundMode = false
			};
			
			return schemaStartEvent;
		}

		protected virtual ProcessSchemaTerminateEvent CreateTerminateEvent1TerminateEvent() {
			ProcessSchemaTerminateEvent schemaTerminateEvent = new ProcessSchemaTerminateEvent(this) {
				UId = new Guid("113d9d4f-fa38-4872-9caf-37636da9d452"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = new Guid("d3e3c893-0c1d-403b-853b-bf21225ccc3b"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("92407950-4ff4-47a3-be70-ffefec778136"),
				CreatedInSchemaUId = new Guid("da145d55-9e13-4850-b793-d144131e3849"),
				EntitySchemaUId = Guid.Empty,
				IsLogging = true,
				ManagerItemUId = new Guid("1bd93619-0574-454e-bb4e-cf53b9eb9470"),
				ModifiedInSchemaUId = new Guid("da145d55-9e13-4850-b793-d144131e3849"),
				Name = @"TerminateEvent1",
				Position = new Point(600, 184),
				SerializeToDB = false,
				Size = new Size(27, 27),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaTerminateEvent;
		}

		protected virtual ProcessSchemaScriptTask CreateScriptTask1ScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("d8f2ee75-819e-4154-96b8-b2c435063954"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = new Guid("d3e3c893-0c1d-403b-853b-bf21225ccc3b"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("92407950-4ff4-47a3-be70-ffefec778136"),
				CreatedInSchemaUId = new Guid("da145d55-9e13-4850-b793-d144131e3849"),
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("da145d55-9e13-4850-b793-d144131e3849"),
				Name = @"ScriptTask1",
				Position = new Point(291, 170),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = true,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,141,87,217,110,219,56,20,125,78,129,254,3,171,135,130,66,13,161,157,199,36,118,225,45,133,7,89,138,218,73,30,6,131,1,35,221,200,68,37,202,67,82,118,60,129,255,125,46,23,109,182,225,4,168,81,155,188,235,57,119,97,214,76,18,9,170,204,244,117,145,166,32,73,159,8,216,144,185,150,92,164,163,146,103,9,72,26,94,124,252,48,140,53,47,196,165,178,23,61,114,3,74,177,20,22,219,21,12,72,86,164,139,98,92,8,85,100,128,6,126,128,190,60,33,62,160,193,163,228,26,252,153,147,12,222,225,3,77,211,220,157,245,136,198,211,144,244,7,228,245,227,135,51,254,76,104,39,136,79,152,70,153,101,161,189,61,107,95,237,89,64,175,103,59,252,180,49,136,134,171,21,136,228,170,144,57,211,52,120,253,186,59,39,175,223,118,175,127,236,2,167,21,45,10,7,16,13,123,164,182,55,21,107,46,11,145,131,208,209,45,108,174,185,176,230,119,248,185,87,32,209,191,0,155,32,41,187,63,29,98,93,25,4,169,123,96,1,114,200,16,120,137,179,50,129,100,30,47,33,103,202,27,112,151,168,56,237,94,91,205,53,242,188,167,118,205,149,70,85,167,22,205,212,45,2,118,39,31,151,72,205,124,197,98,160,123,242,33,194,244,221,86,135,209,172,221,153,227,243,125,219,209,124,149,113,77,81,248,175,191,201,43,9,122,1,217,245,124,85,217,171,187,149,73,74,69,191,32,47,214,48,205,87,122,59,21,120,13,42,68,116,141,3,26,70,152,253,26,164,30,102,25,85,134,106,21,45,36,207,105,104,18,50,148,31,73,40,26,138,45,10,88,222,145,118,26,44,150,32,129,48,252,84,210,68,57,241,115,18,144,47,85,250,127,22,92,80,164,23,255,29,177,26,118,138,49,154,137,103,91,27,152,129,101,216,193,171,126,243,21,102,88,198,186,148,112,191,74,152,134,9,60,51,44,171,185,102,82,79,240,183,103,202,124,93,240,28,144,171,219,66,59,209,155,66,192,182,86,175,53,44,121,149,252,49,23,109,219,243,173,154,131,214,152,143,138,208,207,3,203,74,160,221,98,235,33,46,193,56,227,88,164,78,255,159,55,35,232,189,39,51,19,38,18,200,245,214,193,118,195,4,51,227,4,142,156,245,247,26,32,58,162,136,230,174,74,17,95,254,40,121,210,35,53,96,36,5,237,228,174,153,170,210,166,142,208,251,89,82,15,4,195,71,92,100,101,46,140,21,148,49,255,249,26,167,99,123,17,205,139,82,198,224,126,208,160,206,239,166,72,248,51,135,228,14,91,174,71,142,202,182,69,236,4,145,128,154,130,80,58,135,12,115,10,237,8,181,95,247,224,55,197,189,162,223,76,207,156,157,69,222,94,19,168,63,191,146,69,142,17,33,155,54,177,192,31,223,73,28,198,163,237,4,84,124,168,243,104,234,28,135,198,44,169,196,103,106,250,111,201,234,116,127,50,201,114,208,56,206,27,184,194,48,154,190,64,92,98,25,197,44,99,178,85,153,213,232,178,189,222,38,104,208,225,84,61,114,189,28,151,82,130,136,183,206,19,162,125,132,117,83,144,51,13,185,162,77,131,99,156,237,30,231,134,189,99,170,87,92,36,51,161,52,19,49,140,182,24,56,229,145,13,223,24,112,137,91,93,94,205,125,242,249,51,249,196,17,129,7,46,53,98,80,255,158,140,30,56,108,14,244,60,19,202,78,143,216,28,197,17,66,193,108,7,153,150,39,92,17,219,31,157,211,131,0,62,29,155,72,152,161,102,92,40,12,250,22,25,168,198,224,184,200,87,56,150,164,161,149,11,150,205,82,81,72,24,51,229,205,86,32,85,195,187,13,250,162,168,154,223,23,173,95,219,135,100,89,125,156,86,192,226,37,161,118,76,217,11,194,197,91,60,134,117,39,177,216,128,200,255,131,196,119,220,65,23,250,154,178,172,92,248,133,188,167,53,56,57,189,252,166,246,11,14,39,183,159,183,205,130,170,214,177,115,140,27,249,235,142,176,12,19,75,182,164,180,198,18,130,203,20,23,117,68,230,232,41,138,34,51,186,92,92,14,248,110,68,54,80,187,36,26,119,39,231,252,217,142,64,166,192,69,122,154,143,104,152,36,30,147,234,137,177,171,122,233,37,6,187,252,6,102,211,184,175,170,195,95,45,64,235,69,247,134,179,102,231,121,0,115,149,30,34,55,25,153,19,95,48,27,142,109,242,4,53,116,152,169,197,52,232,53,60,116,182,226,233,16,252,180,243,237,100,224,14,221,104,52,248,98,52,167,129,53,69,198,77,131,103,217,189,230,248,60,192,119,128,135,228,39,139,127,163,218,108,239,118,127,174,218,162,219,147,137,188,82,85,74,95,204,170,192,42,144,105,189,39,108,120,120,16,189,143,255,83,94,166,82,22,242,168,143,134,102,91,22,198,93,205,177,43,194,86,95,246,223,66,218,12,195,10,103,108,55,210,239,27,111,117,231,181,108,25,22,154,245,104,4,221,155,248,123,165,208,122,199,146,243,118,171,92,180,122,17,76,94,55,199,234,201,101,188,89,242,172,42,163,86,125,33,114,222,162,45,171,30,89,57,34,237,83,186,110,76,219,151,118,93,153,144,60,215,182,122,234,230,172,252,119,169,177,190,79,144,50,103,107,112,16,78,70,53,118,111,245,145,47,98,255,214,52,136,226,123,95,150,238,25,223,244,190,125,87,206,52,81,128,235,140,232,37,211,56,136,50,162,217,83,134,101,219,64,128,59,163,153,56,213,172,50,67,233,244,91,18,159,112,52,248,101,255,30,113,236,160,70,231,207,147,134,181,214,67,184,174,176,102,22,232,165,44,54,182,137,134,105,42,33,197,92,235,186,195,57,90,96,117,88,112,21,41,226,24,3,78,60,151,85,208,134,253,228,169,73,200,189,141,189,35,31,172,127,249,24,148,46,254,7,185,209,76,83,76,14,0,0 }
			};
			
			return ScriptTask;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeUsings() {
			Usings.Add(new SchemaUsing() {
				UId = new Guid("ca866da1-7106-4d5c-95d0-4b083397d6da"),
				Name = "System.Linq",
				Alias = "",
				CreatedInPackageId = new Guid("5e3d1956-5f66-4b70-a038-d893b5276a26")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("355e532d-aa5f-467b-a432-d3a32262ebad"),
				Name = "Terrasoft.Core.Packages",
				Alias = "",
				CreatedInPackageId = new Guid("5e3d1956-5f66-4b70-a038-d893b5276a26")
			});
		}

		#endregion

		#region Methods: Public

		public override Process CreateProcess(UserConnection userConnection) {
			return new ActualizeMoneyColumnsDbStructure(userConnection);
		}

		public override object Clone() {
			return new ActualizeMoneyColumnsDbStructureSchema(this);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("da145d55-9e13-4850-b793-d144131e3849"));
		}

		#endregion

	}

	#endregion

	#region Class: ActualizeMoneyColumnsDbStructureMethodsWrapper

	/// <exclude/>
	public class ActualizeMoneyColumnsDbStructureMethodsWrapper : ProcessModel
	{

		public ActualizeMoneyColumnsDbStructureMethodsWrapper(Process process)
			: base(process) {
			AddScriptTaskMethod("ScriptTask1Execute", ScriptTask1Execute);
		}

		#region Methods: Private

		private bool ScriptTask1Execute(ProcessExecutingContext context) {
			var resultLogger = new StringBuilder();
			Action<string, MessageType> logToConsole = Get<Action<string, MessageType>>("WriteMessageAction");
			Action<string, MessageType> log = (message, type) => {
				if (logToConsole != null) {
					logToConsole(message, type);
				}
				resultLogger.AppendFormat("{0}: {1}{2}", type.ToString(), message, Environment.NewLine);
			};
			UserConnection userConnection = Get<UserConnection>("UserConnection");
			string excludedSchemas = Get<string>("ExcludedSchemas");
			var excludedSchemasList = string.IsNullOrWhiteSpace(excludedSchemas)
				? new List<string>()
				: excludedSchemas.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries).ToList().ConvertAll(s => s.Trim());
			if (excludedSchemasList.Any()) {
				log("There are excluded schemas: " + string.Join(", ", excludedSchemasList), MessageType.Information);
			}
			var skipStructureUpdateDefaultStartDate = Get<DateTime>("NotUpdateMoneyStructureStartDate");
			DateTime skipStructureUpdateStartDate = SysSettings.GetValue(userConnection,
				"ClientUpdate_NotUpdateMoneyStructureStartDate", skipStructureUpdateDefaultStartDate);
			EntitySchemaManager entitySchemaManager = userConnection.EntitySchemaManager;
			Func<Guid, DateTime> getSchemaLastDate = (schemaUId) => {
				var columnFunc = Func.IsNull(Column.SourceColumn("StructureModifiedOn"), Column.SourceColumn("ModifiedOn"));
				return ((Select)new Select(userConnection).Top(1)
						.Column(columnFunc)
						.From("SysSchema")
						.OrderByDesc(columnFunc)
						.Where("UId")
						.IsEqual(Column.Parameter(schemaUId))).ExecuteScalar<DateTime>();
			};
			List<EntitySchema> entitySchemasWithCurrencyColumn = entitySchemaManager.GetItems().ToList()
				.ConvertAll(i => entitySchemaManager.FindInstanceByUId(i.UId))
				.Where(i => i != null && !i.IsVirtual && !i.IsDBView)
				.Where(i => i.Columns.Any(c => c.DataValueType is MoneyDataValueType))
				.Where(i => !excludedSchemasList.Contains(i.Name, StringComparer.OrdinalIgnoreCase))
				.ToList();
			var entitySchemasToUpdateStructure = new List<EntitySchema>();
			foreach (var schema in entitySchemasWithCurrencyColumn) {
				var actualizedDate = getSchemaLastDate(schema.UId);
				if (actualizedDate > skipStructureUpdateStartDate) {
					string logMessage = string.Format("Schema: {0} already updated on {1}. Skip...", schema.Name, actualizedDate);
					log(logMessage, MessageType.Information);
				} else {
					entitySchemasToUpdateStructure.Add(schema);
				}
			}
			List<Exception> exceptions = new List<Exception>();
			if (entitySchemasToUpdateStructure.Any()) {
				string msg = string.Format("DB structure will be updated for: {0}",
					string.Join(", ", entitySchemasToUpdateStructure.Select(i => i.Name)));
				log(msg, MessageType.Information);
				var installUtilities = new PackageInstallUtilities(userConnection);
				installUtilities.InstallMessage += (s, arg) => {
					log(arg.Message, MessageType.Information);
				};
				installUtilities.InstallError += (s, arg) => {
					exceptions.Add(arg.Exception);
					var schema = entitySchemasToUpdateStructure.Find(i => i.UId == arg.UId);
					var schemaName = (schema == null) ? arg.UId.ToString() : schema.Name;
					string errorMsg = string.Format("Error while update structure for schema: {0}, package: {1}", schemaName,
						arg.PackageName);
					log(errorMsg, MessageType.Error);
				};
				installUtilities.SaveSchemaDBStructure(entitySchemasToUpdateStructure.Select(s => s.UId), true);
			} else {
				log("It seems that all tables structure is actualized already.", MessageType.Information);
			}
			Set("ResultString", resultLogger.ToString());
			if (exceptions.Any()) {
				throw new AggregateException("Some errors occured while actualizing db structure", exceptions);
			}
			return true;
		}

		#endregion

	}

	#endregion

	#region Class: ActualizeMoneyColumnsDbStructure

	/// <exclude/>
	public class ActualizeMoneyColumnsDbStructure : Terrasoft.Core.Process.Process
	{

		#region Class: ProcessLane1

		/// <exclude/>
		public class ProcessLane1 : ProcessLane
		{

			public ProcessLane1(UserConnection userConnection, ActualizeMoneyColumnsDbStructure process)
				: base(userConnection) {
				Owner = process;
				IsUsedParentUserContexts = false;
			}

		}

		#endregion

		public ActualizeMoneyColumnsDbStructure(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ActualizeMoneyColumnsDbStructure";
			SchemaUId = new Guid("da145d55-9e13-4850-b793-d144131e3849");
			Caption = Schema.Caption;
			SchemaManagerName = "ProcessSchemaManager";
			SerializeToDB = false;
			SerializeToMemory = false;
			IsLogging = false;
			UseSystemSecurityContext = false;
			_notUpdateMoneyStructureStartDate = () => { return (DateTime)(DateTime.ParseExact("06.08.2016", "dd.MM.yyyy", CultureInfo.InvariantCulture)); };
			ProcessModel = new ActualizeMoneyColumnsDbStructureMethodsWrapper(this);
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("da145d55-9e13-4850-b793-d144131e3849");
			}
		}

		private string ConditionalExpressionLogMessage {
			get {
				return "Process: ActualizeMoneyColumnsDbStructure, Source element: {0}, Conditional flow: {1}, Expression: {2}, Result: {3}";
			}
		}

		private string DeadEndGatewayLogMessage {
			get {
				return "Process: ActualizeMoneyColumnsDbStructure, Source element: {0}, None of the exclusive gateway conditions are met!";
			}
		}

		#endregion

		#region Properties: Public

		public virtual Object WriteMessageAction {
			get;
			set;
		}

		private Func<DateTime> _notUpdateMoneyStructureStartDate;
		public virtual DateTime NotUpdateMoneyStructureStartDate {
			get {
				return (_notUpdateMoneyStructureStartDate ?? (_notUpdateMoneyStructureStartDate = () => DateTime.ParseExact("01.01.0001 0:00", "dd.MM.yyyy H:mm", CultureInfo.InvariantCulture))).Invoke();
			}
			set {
				_notUpdateMoneyStructureStartDate = () => { return value; };
			}
		}

		public virtual string ResultString {
			get;
			set;
		}

		public virtual string ExcludedSchemas {
			get;
			set;
		}

		private ProcessLane1 _lane1;
		public ProcessLane1 Lane1 {
			get {
				return _lane1 ?? ((_lane1) = new ProcessLane1(UserConnection, this));
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
					SchemaElementUId = new Guid("9b8acda0-6cd5-4437-b641-254a5f98b191"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
				});
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
					SchemaElementUId = new Guid("113d9d4f-fa38-4872-9caf-37636da9d452"),
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
					SchemaElementUId = new Guid("d8f2ee75-819e-4154-96b8-b2c435063954"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = ProcessModel.GetScriptTaskMethod("ScriptTask1Execute"),
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[StartEvent1.SchemaElementUId] = new Collection<ProcessFlowElement> { StartEvent1 };
			FlowElements[TerminateEvent1.SchemaElementUId] = new Collection<ProcessFlowElement> { TerminateEvent1 };
			FlowElements[ScriptTask1.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptTask1 };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "StartEvent1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ScriptTask1", e.Context.SenderName));
						break;
					case "TerminateEvent1":
						CompleteProcess();
						break;
					case "ScriptTask1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("TerminateEvent1", e.Context.SenderName));
						break;
			}
		}

		private void WritePropertyValues(DataWriter writer, bool useAllValueSources) {
			if (WriteMessageAction != null) {
				if (WriteMessageAction.GetType().IsSerializable ||
					WriteMessageAction.GetType().GetInterface("ISerializable") != null) {
					WriteSerializableObject(writer, "WriteMessageAction", WriteMessageAction, null);
				}
			}
			if (!HasMapping("ResultString")) {
				writer.WriteValue("ResultString", ResultString, null);
			}
			if (!HasMapping("ExcludedSchemas")) {
				writer.WriteValue("ExcludedSchemas", ExcludedSchemas, null);
			}
			if (!HasMapping("NotUpdateMoneyStructureStartDate")) {
				writer.WriteValue("NotUpdateMoneyStructureStartDate", NotUpdateMoneyStructureStartDate, DateTime.ParseExact("01.01.0001 0:00", "dd.MM.yyyy H:mm", CultureInfo.InvariantCulture));
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
			MetaPathParameterValues.Add("9cded1e6-41ef-478e-a34b-0c9477d7d2d4", () => WriteMessageAction);
			MetaPathParameterValues.Add("81396900-691f-4903-8800-fa97fb6e90b4", () => NotUpdateMoneyStructureStartDate);
			MetaPathParameterValues.Add("d765c621-e06e-42c3-9fe3-5ab78d8dcb6b", () => ResultString);
			MetaPathParameterValues.Add("63ceb59f-2bfb-4ece-b672-61602e2bfd57", () => ExcludedSchemas);
		}

		protected override void ApplyPropertiesDataValues(DataReader reader) {
			base.ApplyPropertiesDataValues(reader);
			bool hasValueToRead = reader.HasValue();
			switch (reader.CurrentName) {
				case "WriteMessageAction":
					if (!hasValueToRead) break;
					WriteMessageAction = GetSerializableObject(reader);
				break;
				case "ResultString":
					if (!hasValueToRead) break;
					ResultString = reader.GetValue<System.String>();
				break;
				case "ExcludedSchemas":
					if (!hasValueToRead) break;
					ExcludedSchemas = reader.GetValue<System.String>();
				break;
				case "NotUpdateMoneyStructureStartDate":
					if (!hasValueToRead) break;
					NotUpdateMoneyStructureStartDate = reader.GetValue<System.DateTime>();
				break;
			}
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
			var cloneItem = (ActualizeMoneyColumnsDbStructure)base.CloneShallow();
			cloneItem.ExecutedEventHandler = ExecutedEventHandler;
			cloneItem.WriteMessageAction = WriteMessageAction;
			return cloneItem;
		}

		#endregion

	}

	#endregion

}

