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
	using Terrasoft.Configuration.ImportExcelData;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Process;
	using Terrasoft.Core.Process.Configuration;
	using Terrasoft.Core.Scheduler;

	#region Class: ImportExcelLookupProcessSchema

	/// <exclude/>
	public class ImportExcelLookupProcessSchema : Terrasoft.Core.Process.ProcessSchema
	{

		#region Constructors: Public

		public ImportExcelLookupProcessSchema(ProcessSchemaManager processSchemaManager)
			: base(processSchemaManager) {
		}

		public ImportExcelLookupProcessSchema(ImportExcelLookupProcessSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			Name = "ImportExcelLookupProcess";
			UId = new Guid("4192528f-f376-4d30-bd6b-1358c4ea76e6");
			CreatedInPackageId = new Guid("5124eccf-c1be-4f38-a8ca-c1c899ca35a8");
			CreatedInSchemaUId = Guid.Empty;
			CreatedInVersion = @"7.6.0.0";
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
			RealUId = new Guid("4192528f-f376-4d30-bd6b-1358c4ea76e6");
			Version = 0;
			PackageUId = new Guid("422cc048-65aa-8f90-e8ed-7fa6d5ab06b1");
			UseSystemSecurityContext = false;
		}

		protected virtual ProcessSchemaParameter CreateExcelImportIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("a33a32de-c086-4f92-b20a-2ecb38197547"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("4192528f-f376-4d30-bd6b-1358c4ea76e6"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("4192528f-f376-4d30-bd6b-1358c4ea76e6"),
				Name = @"ExcelImportId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid"),
			};
		}

		protected virtual ProcessSchemaParameter CreateLookupEntitiesParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("32fcd137-5c32-49ff-b621-5ded5a21588e"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("4192528f-f376-4d30-bd6b-1358c4ea76e6"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("4192528f-f376-4d30-bd6b-1358c4ea76e6"),
				Name = @"LookupEntities",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Object"),
			};
		}

		protected virtual ProcessSchemaParameter CreateImportExcelDataParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("bc384458-adcd-49cc-950e-156042eeee69"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("4192528f-f376-4d30-bd6b-1358c4ea76e6"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("4192528f-f376-4d30-bd6b-1358c4ea76e6"),
				Name = @"ImportExcelData",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Object"),
			};
		}

		protected virtual ProcessSchemaParameter CreateIsSyncLookupConflictsParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("38440d1b-38d4-4040-9d9f-c78538332ba0"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("4192528f-f376-4d30-bd6b-1358c4ea76e6"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("4192528f-f376-4d30-bd6b-1358c4ea76e6"),
				Name = @"IsSyncLookupConflicts",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean"),
			};
		}

		protected virtual ProcessSchemaParameter CreateIsPrimaryDisplayColumnExistsParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("efcad133-b57b-4e7c-907c-b9b137a0328c"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("4192528f-f376-4d30-bd6b-1358c4ea76e6"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("4192528f-f376-4d30-bd6b-1358c4ea76e6"),
				Name = @"IsPrimaryDisplayColumnExists",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean"),
			};
		}

		protected virtual ProcessSchemaParameter CreateSelectedIdentificationColumnsParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("b15e2c93-c5cd-4c7a-9267-ecbd73d1a51b"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("4192528f-f376-4d30-bd6b-1358c4ea76e6"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("4192528f-f376-4d30-bd6b-1358c4ea76e6"),
				Name = @"SelectedIdentificationColumns",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MaxSizeText"),
			};
		}

		protected virtual ProcessSchemaParameter CreateNameColumnIndexParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("5aa0b7c4-fad6-4370-a377-741952e2a5cf"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("4192528f-f376-4d30-bd6b-1358c4ea76e6"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("4192528f-f376-4d30-bd6b-1358c4ea76e6"),
				Name = @"NameColumnIndex",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Integer"),
			};
		}

		protected virtual ProcessSchemaParameter CreateCaptionsParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("1d491fcf-7aee-4b68-8c5f-ea6a0e9d34bf"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("4192528f-f376-4d30-bd6b-1358c4ea76e6"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("4192528f-f376-4d30-bd6b-1358c4ea76e6"),
				Name = @"Captions",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Object"),
			};
		}

		protected virtual ProcessSchemaParameter CreateFileNameParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("6bb6fbcc-df17-4639-ae28-867e618449a4"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("4192528f-f376-4d30-bd6b-1358c4ea76e6"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("4192528f-f376-4d30-bd6b-1358c4ea76e6"),
				Name = @"FileName",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MaxSizeText"),
			};
		}

		protected virtual ProcessSchemaParameter CreateSchemaNameParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("86b91419-8758-4026-b1af-32973690a3cb"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("4192528f-f376-4d30-bd6b-1358c4ea76e6"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("4192528f-f376-4d30-bd6b-1358c4ea76e6"),
				Name = @"SchemaName",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MediumText"),
			};
		}

		protected virtual ProcessSchemaParameter CreateImportModeParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("d5788ce6-58ec-4f86-9f22-23bca9e168d9"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("4192528f-f376-4d30-bd6b-1358c4ea76e6"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("4192528f-f376-4d30-bd6b-1358c4ea76e6"),
				Name = @"ImportMode",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Integer"),
			};
		}

		protected virtual ProcessSchemaParameter CreateIsOnlyErrorsModeParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("174730ca-2f45-440f-a606-a20e8f607ddb"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("4192528f-f376-4d30-bd6b-1358c4ea76e6"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("4192528f-f376-4d30-bd6b-1358c4ea76e6"),
				Name = @"IsOnlyErrorsMode",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean"),
			};
		}

		protected virtual ProcessSchemaParameter CreateHeaderNamesParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("a8ad5735-6f37-4d58-977a-852f8c0e76b2"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("4192528f-f376-4d30-bd6b-1358c4ea76e6"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("4192528f-f376-4d30-bd6b-1358c4ea76e6"),
				Name = @"HeaderNames",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Object"),
			};
		}

		protected override void InitializeParameters() {
			base.InitializeParameters();
			Parameters.Add(CreateExcelImportIdParameter());
			Parameters.Add(CreateLookupEntitiesParameter());
			Parameters.Add(CreateImportExcelDataParameter());
			Parameters.Add(CreateIsSyncLookupConflictsParameter());
			Parameters.Add(CreateIsPrimaryDisplayColumnExistsParameter());
			Parameters.Add(CreateSelectedIdentificationColumnsParameter());
			Parameters.Add(CreateNameColumnIndexParameter());
			Parameters.Add(CreateCaptionsParameter());
			Parameters.Add(CreateFileNameParameter());
			Parameters.Add(CreateSchemaNameParameter());
			Parameters.Add(CreateImportModeParameter());
			Parameters.Add(CreateIsOnlyErrorsModeParameter());
			Parameters.Add(CreateHeaderNamesParameter());
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
			ProcessSchemaScriptTask importexcellookupscript = CreateImportExcelLookupScriptScriptTask();
			FlowElements.Add(importexcellookupscript);
			FlowElements.Add(CreateSequenceFlow1SequenceFlow());
			FlowElements.Add(CreateSequenceFlow2SequenceFlow());
		}

		protected override void InitializeLocalizableStrings() {
			base.InitializeLocalizableStrings();
			SetLocalizableStringsDefInheritance();
			LocalizableStrings.Add(CreateAddNewLookupRecordLocalizableStringLocalizableString());
		}

		protected virtual SchemaLocalizableString CreateAddNewLookupRecordLocalizableStringLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("755a1469-e50c-46ab-8441-d4b8cc63ecb2"),
				Name = "AddNewLookupRecordLocalizableString",
				CreatedInPackageId = new Guid("5124eccf-c1be-4f38-a8ca-c1c899ca35a8"),
				CreatedInSchemaUId = new Guid("4192528f-f376-4d30-bd6b-1358c4ea76e6"),
				ModifiedInSchemaUId = new Guid("4192528f-f376-4d30-bd6b-1358c4ea76e6")
			};
			return localizableString;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow1SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow1",
				UId = new Guid("37a349d4-5a55-48d3-a1f7-d5d3b54f0fc5"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("5124eccf-c1be-4f38-a8ca-c1c899ca35a8"),
				CreatedInSchemaUId = new Guid("4192528f-f376-4d30-bd6b-1358c4ea76e6"),
				CurveCenterPosition = new Point(373, 203),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("4192528f-f376-4d30-bd6b-1358c4ea76e6"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("a377f05b-f5de-414d-8be3-1897a148bb94"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("2b2a85f6-eeb3-4fa0-95a6-8fa8274aeebb"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow2SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow2",
				UId = new Guid("55146d14-e829-4625-baeb-639e0a1274ed"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("5124eccf-c1be-4f38-a8ca-c1c899ca35a8"),
				CreatedInSchemaUId = new Guid("4192528f-f376-4d30-bd6b-1358c4ea76e6"),
				CurveCenterPosition = new Point(373, 203),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("4192528f-f376-4d30-bd6b-1358c4ea76e6"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("2b2a85f6-eeb3-4fa0-95a6-8fa8274aeebb"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("fee8d430-0d34-47bd-9381-539a86d3e1f1"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaLaneSet CreateLaneSet1LaneSet() {
			ProcessSchemaLaneSet schemaLaneSet1 = new ProcessSchemaLaneSet(this) {
				UId = new Guid("d0f4f95d-5af6-47f9-8842-f43344ea79a5"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 1,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("5124eccf-c1be-4f38-a8ca-c1c899ca35a8"),
				CreatedInSchemaUId = new Guid("4192528f-f376-4d30-bd6b-1358c4ea76e6"),
				Direction = ProcessSchemaPoolDirectionType.Vertical,
				DragGroupName = @"LaneSet",
				ManagerItemUId = new Guid("11a47caf-a0d5-41fa-a274-a0b11f77447a"),
				ModifiedInSchemaUId = new Guid("4192528f-f376-4d30-bd6b-1358c4ea76e6"),
				Name = @"LaneSet1",
				Position = new Point(5, 5),
				Size = new Size(710, 400),
				UseBackgroundMode = false
			};
			return schemaLaneSet1;
		}

		protected virtual ProcessSchemaLane CreateLane1Lane() {
			ProcessSchemaLane schemaLane1 = new ProcessSchemaLane(this) {
				UId = new Guid("173b2246-e526-42de-8bef-f3ce4656eb80"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 1,
				ContainerUId = new Guid("d0f4f95d-5af6-47f9-8842-f43344ea79a5"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("5124eccf-c1be-4f38-a8ca-c1c899ca35a8"),
				CreatedInSchemaUId = new Guid("4192528f-f376-4d30-bd6b-1358c4ea76e6"),
				DragGroupName = @"Lane",
				ManagerItemUId = new Guid("abcd74b9-5912-414b-82ac-f1aa4dcd554e"),
				ModifiedInSchemaUId = new Guid("4192528f-f376-4d30-bd6b-1358c4ea76e6"),
				Name = @"Lane1",
				Position = new Point(29, 0),
				Size = new Size(681, 400),
				UseBackgroundMode = false
			};
			return schemaLane1;
		}

		protected virtual ProcessSchemaStartEvent CreateStart1StartEvent() {
			ProcessSchemaStartEvent schemaStartEvent = new ProcessSchemaStartEvent(this) {
				UId = new Guid("a377f05b-f5de-414d-8be3-1897a148bb94"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = new Guid("173b2246-e526-42de-8bef-f3ce4656eb80"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("5124eccf-c1be-4f38-a8ca-c1c899ca35a8"),
				CreatedInSchemaUId = new Guid("4192528f-f376-4d30-bd6b-1358c4ea76e6"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsInterrupting = false,
				IsLogging = false,
				ManagerItemUId = new Guid("53818048-7868-48f6-ada0-0ebaa65af628"),
				ModifiedInSchemaUId = new Guid("4192528f-f376-4d30-bd6b-1358c4ea76e6"),
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
				UId = new Guid("fee8d430-0d34-47bd-9381-539a86d3e1f1"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = new Guid("173b2246-e526-42de-8bef-f3ce4656eb80"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("5124eccf-c1be-4f38-a8ca-c1c899ca35a8"),
				CreatedInSchemaUId = new Guid("4192528f-f376-4d30-bd6b-1358c4ea76e6"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsLogging = false,
				ManagerItemUId = new Guid("1bd93619-0574-454e-bb4e-cf53b9eb9470"),
				ModifiedInSchemaUId = new Guid("4192528f-f376-4d30-bd6b-1358c4ea76e6"),
				Name = @"Terminate1",
				Position = new Point(600, 184),
				SerializeToDB = false,
				Size = new Size(0, 0),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaTerminateEvent;
		}

		protected virtual ProcessSchemaScriptTask CreateImportExcelLookupScriptScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("2b2a85f6-eeb3-4fa0-95a6-8fa8274aeebb"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = new Guid("173b2246-e526-42de-8bef-f3ce4656eb80"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("5124eccf-c1be-4f38-a8ca-c1c899ca35a8"),
				CreatedInSchemaUId = new Guid("4192528f-f376-4d30-bd6b-1358c4ea76e6"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = false,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("4192528f-f376-4d30-bd6b-1358c4ea76e6"),
				Name = @"ImportExcelLookupScript",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(288, 170),
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,165,84,93,111,218,48,20,125,78,165,254,7,183,79,65,138,172,173,15,123,225,67,90,129,86,209,88,133,198,186,23,218,7,47,92,168,53,199,102,246,13,52,66,252,247,249,198,20,18,96,154,182,229,193,73,236,115,206,253,246,74,88,6,26,37,74,112,172,203,70,198,252,40,150,195,183,13,225,216,72,58,236,124,45,150,10,58,247,133,156,37,204,161,149,122,241,251,247,229,69,20,125,130,242,155,80,5,140,133,180,13,90,47,97,3,153,161,52,90,216,178,35,53,38,172,111,148,130,106,139,254,123,254,105,95,94,200,57,139,247,110,93,117,153,46,148,106,177,141,215,30,153,69,170,231,38,14,122,252,206,216,92,96,124,253,132,155,119,91,191,188,247,203,19,78,196,10,152,134,53,219,220,108,153,170,98,114,228,130,176,120,157,176,59,169,224,65,228,144,176,225,107,6,42,205,151,198,98,234,125,124,179,200,251,166,208,216,106,121,71,162,21,37,168,14,27,11,235,185,8,214,167,203,251,94,228,154,239,183,226,134,224,129,79,186,229,36,123,129,92,124,22,90,44,42,242,163,3,219,55,90,135,224,249,240,20,116,142,79,85,162,200,106,105,12,9,174,243,123,113,101,123,110,44,136,236,133,197,7,17,38,245,62,204,144,208,136,232,108,65,75,151,209,55,127,128,53,189,131,70,20,18,205,86,84,207,84,223,46,115,15,11,90,60,69,200,111,218,123,141,186,155,143,233,172,137,251,192,125,83,84,216,186,163,13,78,117,74,149,191,106,4,236,171,161,81,72,237,188,64,124,100,163,181,139,33,170,239,239,13,55,146,201,239,1,83,237,123,64,103,112,91,122,238,137,86,251,68,201,241,143,179,19,92,210,80,15,172,45,3,229,224,207,190,184,233,145,216,115,160,211,242,221,24,69,105,150,51,129,240,5,126,22,210,2,37,113,46,188,116,5,163,50,170,195,132,150,71,226,188,239,203,141,16,206,226,102,123,5,55,235,100,62,1,28,192,60,180,112,53,173,46,62,143,170,65,26,185,224,99,43,115,223,128,187,41,8,35,69,141,244,111,50,3,233,150,74,52,213,14,93,119,78,211,79,121,124,156,176,128,243,183,68,109,20,253,223,206,98,117,186,253,191,107,4,244,236,47,47,17,111,144,74,103,205,154,166,55,64,43,214,64,160,160,75,54,120,49,125,158,82,59,12,95,33,43,16,142,96,99,107,50,112,46,38,17,210,180,128,133,213,12,109,1,237,95,112,219,227,133,197,5,0,0 }
			};
			
			return ScriptTask;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
			Methods.Add(CreateLogExcelImportLogMethod());
			Methods.Add(CreateExecuteImportExcelDataProcessMethod());
			Methods.Add(CreateLogInfoMethod());
		}

		protected override void InitializeUsings() {
			Usings.Add(new SchemaUsing() {
				UId = new Guid("904e2760-8199-4f76-b62e-e4c2d9467849"),
				Name = "System.Linq",
				Alias = "",
				CreatedInPackageId = new Guid("5124eccf-c1be-4f38-a8ca-c1c899ca35a8")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("a642d3c5-2e54-430c-89a6-414775ba31b1"),
				Name = "Terrasoft.Core.Scheduler",
				Alias = "",
				CreatedInPackageId = new Guid("5124eccf-c1be-4f38-a8ca-c1c899ca35a8")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("5786d2b1-c8fb-4f01-8af1-471f29ba83bb"),
				Name = "Terrasoft.Configuration.ImportExcelData",
				Alias = "",
				CreatedInPackageId = new Guid("811fcb66-130b-4d85-9d3f-7b0df7ea2049")
			});
		}

		protected virtual SchemaMethod CreateLogExcelImportLogMethod() {
			SchemaMethod method = new SchemaMethod() {
				UId = new Guid("bc5d1600-aade-46f0-8175-e9c2bb41a229"),
				Name = "LogExcelImportLog",
				CreatedInSchemaUId = new Guid("4192528f-f376-4d30-bd6b-1358c4ea76e6"),
				CreatedInPackageId = new Guid("5124eccf-c1be-4f38-a8ca-c1c899ca35a8"),
				ResultValueTypeName = "void"
			};
			method.Arguments.Add(new SchemaMethodArgument() {
				UId = new Guid("1d639ce2-48d5-426e-8b2c-1a3282bf5b28"),
				Name = "entity",
				CreatedInSchemaUId = new Guid("4192528f-f376-4d30-bd6b-1358c4ea76e6"),
				ModifiedInSchemaUId = new Guid("4192528f-f376-4d30-bd6b-1358c4ea76e6"),
				Direction = Terrasoft.Common.ParameterDirection.Input,
				ValueTypeName = "Tuple<Guid, string, string, string, string, KeyValuePair<Guid, string>, Dictionary<int, Collection<int>>>",
				CreatedInPackageId = new Guid("5124eccf-c1be-4f38-a8ca-c1c899ca35a8")
			});
			method.ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,149,82,61,79,195,48,20,156,91,169,255,193,242,148,168,145,7,36,166,138,1,66,65,145,74,249,104,97,98,49,206,107,100,145,216,149,243,66,26,16,255,29,59,105,154,148,86,69,76,150,125,247,46,239,238,34,87,196,139,242,69,165,196,76,235,247,98,29,106,181,74,165,192,220,39,95,163,225,192,0,22,70,77,70,195,239,209,240,131,27,146,20,50,38,23,228,214,30,108,14,165,59,61,127,210,96,74,151,15,220,240,12,16,140,229,40,40,201,99,1,166,218,61,122,212,82,104,64,174,57,194,82,102,192,230,186,12,8,109,175,180,21,18,133,49,160,240,57,7,99,215,65,46,48,138,255,82,238,205,68,49,13,236,234,219,113,5,2,165,86,44,236,8,108,167,234,190,152,163,145,42,33,105,109,223,170,91,146,196,138,69,8,217,249,111,248,133,167,5,236,115,206,58,78,6,121,206,19,135,55,15,236,70,155,140,163,119,25,199,54,171,38,223,39,16,218,196,51,45,120,42,63,249,91,10,139,154,26,16,187,241,128,190,82,74,198,237,42,99,226,238,193,1,208,44,209,160,206,128,139,35,82,214,23,122,251,158,125,59,202,34,133,218,163,211,141,128,52,202,214,218,224,76,39,180,70,22,128,30,117,97,145,80,167,69,166,88,23,167,171,217,239,72,161,1,219,81,124,175,44,183,223,242,1,227,170,170,245,78,22,216,13,221,233,88,174,228,73,221,150,242,79,225,166,136,37,108,240,152,187,109,79,61,131,189,120,142,7,178,71,104,6,167,27,16,5,130,253,253,127,0,38,182,211,47,68,3,0,0 };
			return method;
		}

		protected virtual SchemaMethod CreateExecuteImportExcelDataProcessMethod() {
			SchemaMethod method = new SchemaMethod() {
				UId = new Guid("0485fb01-477a-4349-99e0-e16f5cbf3b0f"),
				Name = "ExecuteImportExcelDataProcess",
				CreatedInSchemaUId = new Guid("4192528f-f376-4d30-bd6b-1358c4ea76e6"),
				CreatedInPackageId = new Guid("5124eccf-c1be-4f38-a8ca-c1c899ca35a8"),
				ResultValueTypeName = "void"
			};
			method.Arguments.Add(new SchemaMethodArgument() {
				UId = new Guid("81de6b2e-307d-4033-9533-6c9c5b042b56"),
				Name = "rows",
				CreatedInSchemaUId = new Guid("4192528f-f376-4d30-bd6b-1358c4ea76e6"),
				ModifiedInSchemaUId = new Guid("4192528f-f376-4d30-bd6b-1358c4ea76e6"),
				Direction = Terrasoft.Common.ParameterDirection.Input,
				ValueTypeName = "string[][]",
				CreatedInPackageId = new Guid("5124eccf-c1be-4f38-a8ca-c1c899ca35a8")
			});
			method.ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,125,82,203,110,194,48,16,60,23,137,127,176,114,10,82,20,181,103,74,165,42,64,155,170,15,164,170,234,133,139,137,23,106,234,216,209,218,225,33,196,191,215,78,28,30,105,203,197,178,119,198,179,235,241,240,121,136,106,173,201,96,64,100,41,68,143,236,186,157,43,4,83,162,236,119,59,251,110,231,89,45,82,57,87,161,54,200,229,34,30,43,204,169,9,131,169,217,93,239,237,114,99,151,169,121,55,20,141,133,137,166,43,32,140,26,74,120,94,40,52,164,64,149,129,214,65,68,198,92,192,43,205,33,34,163,77,6,34,173,240,148,245,122,182,79,45,78,150,106,230,24,100,64,130,26,174,152,67,43,23,156,145,30,80,149,197,31,172,170,126,66,245,205,255,209,156,248,209,44,127,69,177,33,79,40,90,186,1,180,158,16,9,107,50,228,153,225,74,82,220,222,214,178,17,81,179,37,100,230,46,172,221,218,5,103,15,10,90,15,220,71,21,167,253,160,136,56,223,27,80,79,144,231,182,197,144,235,66,208,109,162,68,153,203,209,134,107,227,172,187,4,123,133,119,16,118,36,96,41,3,105,248,156,103,212,13,93,19,157,196,69,220,107,56,159,234,74,42,25,108,236,173,86,197,243,18,90,184,203,78,182,217,122,164,249,227,147,239,110,230,203,190,32,167,30,59,30,206,204,121,81,204,161,199,195,193,157,55,41,182,35,68,133,186,225,180,74,158,249,8,148,1,58,97,55,220,201,201,6,121,111,255,249,190,40,92,111,86,10,192,184,217,165,121,14,140,83,3,62,16,79,106,22,250,36,70,135,180,69,167,97,114,205,62,52,96,162,164,132,42,29,241,167,194,111,93,208,12,226,250,94,11,78,74,68,107,188,171,122,194,175,184,245,250,63,57,105,246,237,140,3,0,0 };
			return method;
		}

		protected virtual SchemaMethod CreateLogInfoMethod() {
			SchemaMethod method = new SchemaMethod() {
				UId = new Guid("dbdf9a53-91fa-490e-b61c-4d8602ffdde6"),
				Name = "LogInfo",
				CreatedInSchemaUId = new Guid("4192528f-f376-4d30-bd6b-1358c4ea76e6"),
				CreatedInPackageId = new Guid("811fcb66-130b-4d85-9d3f-7b0df7ea2049"),
				ResultValueTypeName = "void"
			};
			method.Arguments.Add(new SchemaMethodArgument() {
				UId = new Guid("caa17fc3-34bb-4a6c-ac69-72493042db65"),
				Name = "message",
				CreatedInSchemaUId = new Guid("4192528f-f376-4d30-bd6b-1358c4ea76e6"),
				ModifiedInSchemaUId = new Guid("4192528f-f376-4d30-bd6b-1358c4ea76e6"),
				Direction = Terrasoft.Common.ParameterDirection.Input,
				ValueTypeName = "string",
				CreatedInPackageId = new Guid("811fcb66-130b-4d85-9d3f-7b0df7ea2049")
			});
			method.ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,203,76,211,112,173,72,78,205,9,45,201,204,201,44,201,76,45,214,243,201,79,87,80,180,85,200,43,205,201,209,84,168,230,229,226,196,148,215,243,204,75,203,215,200,77,45,46,78,76,79,213,180,230,229,170,5,0,224,225,217,64,71,0,0,0 };
			return method;
		}

		#endregion

		#region Methods: Public

		public override Process CreateProcess(UserConnection userConnection) {
			return new ImportExcelLookupProcess(userConnection);
		}

		public override object Clone() {
			return new ImportExcelLookupProcessSchema(this);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("4192528f-f376-4d30-bd6b-1358c4ea76e6"));
		}

		#endregion

	}

	#endregion

	#region Class: ImportExcelLookupProcess

	/// <exclude/>
	public class ImportExcelLookupProcess : Terrasoft.Core.Process.Process
	{

		#region Class: ProcessLane1

		/// <exclude/>
		public class ProcessLane1 : ProcessLane
		{

			public ProcessLane1(UserConnection userConnection, ImportExcelLookupProcess process)
				: base(userConnection) {
				Owner = process;
				IsUsedParentUserContexts = false;
			}

		}

		#endregion

		public ImportExcelLookupProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ImportExcelLookupProcess";
			SchemaUId = new Guid("4192528f-f376-4d30-bd6b-1358c4ea76e6");
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
				return new Guid("4192528f-f376-4d30-bd6b-1358c4ea76e6");
			}
		}

		private string ConditionalExpressionLogMessage {
			get {
				return "Process: ImportExcelLookupProcess, Source element: {0}, Conditional flow: {1}, Expression: {2}, Result: {3}";
			}
		}

		private string DeadEndGatewayLogMessage {
			get {
				return "Process: ImportExcelLookupProcess, Source element: {0}, None of the exclusive gateway conditions are met!";
			}
		}

		#endregion

		#region Properties: Public

		public virtual Guid ExcelImportId {
			get;
			set;
		}

		public virtual Object LookupEntities {
			get;
			set;
		}

		public virtual Object ImportExcelData {
			get;
			set;
		}

		public virtual bool IsSyncLookupConflicts {
			get;
			set;
		}

		public virtual bool IsPrimaryDisplayColumnExists {
			get;
			set;
		}

		public virtual string SelectedIdentificationColumns {
			get;
			set;
		}

		public virtual int NameColumnIndex {
			get;
			set;
		}

		public virtual Object Captions {
			get;
			set;
		}

		public virtual string FileName {
			get;
			set;
		}

		public virtual string SchemaName {
			get;
			set;
		}

		public virtual int ImportMode {
			get;
			set;
		}

		public virtual bool IsOnlyErrorsMode {
			get;
			set;
		}

		public virtual Object HeaderNames {
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
					SchemaElementUId = new Guid("a377f05b-f5de-414d-8be3-1897a148bb94"),
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
					SchemaElementUId = new Guid("fee8d430-0d34-47bd-9381-539a86d3e1f1"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _importExcelLookupScript;
		public ProcessScriptTask ImportExcelLookupScript {
			get {
				return _importExcelLookupScript ?? (_importExcelLookupScript = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ImportExcelLookupScript",
					SchemaElementUId = new Guid("2b2a85f6-eeb3-4fa0-95a6-8fa8274aeebb"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					Script = ImportExcelLookupScriptExecute,
				});
			}
		}

		private LocalizableString _addNewLookupRecordLocalizableString;
		public LocalizableString AddNewLookupRecordLocalizableString {
			get {
				return _addNewLookupRecordLocalizableString ?? (_addNewLookupRecordLocalizableString = new LocalizableString(Storage, Schema.GetResourceManagerName(), "LocalizableStrings.AddNewLookupRecordLocalizableString.Value"));
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[Start1.SchemaElementUId] = new Collection<ProcessFlowElement> { Start1 };
			FlowElements[Terminate1.SchemaElementUId] = new Collection<ProcessFlowElement> { Terminate1 };
			FlowElements[ImportExcelLookupScript.SchemaElementUId] = new Collection<ProcessFlowElement> { ImportExcelLookupScript };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "Start1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ImportExcelLookupScript", e.Context.SenderName));
						break;
					case "Terminate1":
						CompleteProcess();
						break;
					case "ImportExcelLookupScript":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("Terminate1", e.Context.SenderName));
						break;
			}
		}

		private void WritePropertyValues(DataWriter writer, bool useAllValueSources) {
			if (!HasMapping("ExcelImportId")) {
				writer.WriteValue("ExcelImportId", ExcelImportId, Guid.Empty);
			}
			if (LookupEntities != null) {
				if (LookupEntities.GetType().IsSerializable ||
					LookupEntities.GetType().GetInterface("ISerializable") != null) {
					WriteSerializableObject(writer, "LookupEntities", LookupEntities, null);
				}
			}
			if (ImportExcelData != null) {
				if (ImportExcelData.GetType().IsSerializable ||
					ImportExcelData.GetType().GetInterface("ISerializable") != null) {
					WriteSerializableObject(writer, "ImportExcelData", ImportExcelData, null);
				}
			}
			if (!HasMapping("IsSyncLookupConflicts")) {
				writer.WriteValue("IsSyncLookupConflicts", IsSyncLookupConflicts, false);
			}
			if (!HasMapping("IsPrimaryDisplayColumnExists")) {
				writer.WriteValue("IsPrimaryDisplayColumnExists", IsPrimaryDisplayColumnExists, false);
			}
			if (!HasMapping("SelectedIdentificationColumns")) {
				writer.WriteValue("SelectedIdentificationColumns", SelectedIdentificationColumns, null);
			}
			if (!HasMapping("NameColumnIndex")) {
				writer.WriteValue("NameColumnIndex", NameColumnIndex, 0);
			}
			if (Captions != null) {
				if (Captions.GetType().IsSerializable ||
					Captions.GetType().GetInterface("ISerializable") != null) {
					WriteSerializableObject(writer, "Captions", Captions, null);
				}
			}
			if (!HasMapping("FileName")) {
				writer.WriteValue("FileName", FileName, null);
			}
			if (!HasMapping("SchemaName")) {
				writer.WriteValue("SchemaName", SchemaName, null);
			}
			if (!HasMapping("ImportMode")) {
				writer.WriteValue("ImportMode", ImportMode, 0);
			}
			if (!HasMapping("IsOnlyErrorsMode")) {
				writer.WriteValue("IsOnlyErrorsMode", IsOnlyErrorsMode, false);
			}
			if (HeaderNames != null) {
				if (HeaderNames.GetType().IsSerializable ||
					HeaderNames.GetType().GetInterface("ISerializable") != null) {
					WriteSerializableObject(writer, "HeaderNames", HeaderNames, null);
				}
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
			MetaPathParameterValues.Add("a33a32de-c086-4f92-b20a-2ecb38197547", () => ExcelImportId);
			MetaPathParameterValues.Add("32fcd137-5c32-49ff-b621-5ded5a21588e", () => LookupEntities);
			MetaPathParameterValues.Add("bc384458-adcd-49cc-950e-156042eeee69", () => ImportExcelData);
			MetaPathParameterValues.Add("38440d1b-38d4-4040-9d9f-c78538332ba0", () => IsSyncLookupConflicts);
			MetaPathParameterValues.Add("efcad133-b57b-4e7c-907c-b9b137a0328c", () => IsPrimaryDisplayColumnExists);
			MetaPathParameterValues.Add("b15e2c93-c5cd-4c7a-9267-ecbd73d1a51b", () => SelectedIdentificationColumns);
			MetaPathParameterValues.Add("5aa0b7c4-fad6-4370-a377-741952e2a5cf", () => NameColumnIndex);
			MetaPathParameterValues.Add("1d491fcf-7aee-4b68-8c5f-ea6a0e9d34bf", () => Captions);
			MetaPathParameterValues.Add("6bb6fbcc-df17-4639-ae28-867e618449a4", () => FileName);
			MetaPathParameterValues.Add("86b91419-8758-4026-b1af-32973690a3cb", () => SchemaName);
			MetaPathParameterValues.Add("d5788ce6-58ec-4f86-9f22-23bca9e168d9", () => ImportMode);
			MetaPathParameterValues.Add("174730ca-2f45-440f-a606-a20e8f607ddb", () => IsOnlyErrorsMode);
			MetaPathParameterValues.Add("a8ad5735-6f37-4d58-977a-852f8c0e76b2", () => HeaderNames);
		}

		protected override void ApplyPropertiesDataValues(DataReader reader) {
			base.ApplyPropertiesDataValues(reader);
			bool hasValueToRead = reader.HasValue();
			switch (reader.CurrentName) {
				case "ExcelImportId":
					if (!hasValueToRead) break;
					ExcelImportId = reader.GetValue<System.Guid>();
				break;
				case "LookupEntities":
					if (!hasValueToRead) break;
					LookupEntities = GetSerializableObject(reader);
				break;
				case "ImportExcelData":
					if (!hasValueToRead) break;
					ImportExcelData = GetSerializableObject(reader);
				break;
				case "IsSyncLookupConflicts":
					if (!hasValueToRead) break;
					IsSyncLookupConflicts = reader.GetValue<System.Boolean>();
				break;
				case "IsPrimaryDisplayColumnExists":
					if (!hasValueToRead) break;
					IsPrimaryDisplayColumnExists = reader.GetValue<System.Boolean>();
				break;
				case "SelectedIdentificationColumns":
					if (!hasValueToRead) break;
					SelectedIdentificationColumns = reader.GetValue<System.String>();
				break;
				case "NameColumnIndex":
					if (!hasValueToRead) break;
					NameColumnIndex = reader.GetValue<System.Int32>();
				break;
				case "Captions":
					if (!hasValueToRead) break;
					Captions = GetSerializableObject(reader);
				break;
				case "FileName":
					if (!hasValueToRead) break;
					FileName = reader.GetValue<System.String>();
				break;
				case "SchemaName":
					if (!hasValueToRead) break;
					SchemaName = reader.GetValue<System.String>();
				break;
				case "ImportMode":
					if (!hasValueToRead) break;
					ImportMode = reader.GetValue<System.Int32>();
				break;
				case "IsOnlyErrorsMode":
					if (!hasValueToRead) break;
					IsOnlyErrorsMode = reader.GetValue<System.Boolean>();
				break;
				case "HeaderNames":
					if (!hasValueToRead) break;
					HeaderNames = GetSerializableObject(reader);
				break;
			}
		}

		protected override void WritePropertyValues(DataWriter writer) {
			base.WritePropertyValues(writer);
			WritePropertyValues(writer, true);
		}

		#endregion

		#region Methods: Public

		public virtual bool ImportExcelLookupScriptExecute(ProcessExecutingContext context) {
			var entities = LookupEntities as List<Tuple<Guid, string, string, string, string, 
					KeyValuePair<Guid, string>, Dictionary<int, Collection<int>>>>;
			if (entities != null) {
				LogInfo(string.Format("\t{0}\t{1}\t\tSave new {2} lookups, start", FileName, ExcelImportId, entities.Count));
				var excelImportIdParameter = Column.Parameter(ExcelImportId);
				var entitySchemaManager = UserConnection.EntitySchemaManager;
				var entitySchemas = new Dictionary<Guid, EntitySchema>();
				foreach (var entity in entities) {
					Guid guid = Guid.NewGuid();
					string valueInBpm = entity.Item2;
					Guid entitySchemaUId = entity.Item6.Key;
					EntitySchema entitySchema;
					if (!entitySchemas.ContainsKey(entitySchemaUId)) {
						entitySchema = entitySchemaManager.GetInstanceByUId(entitySchemaUId);
						entitySchemas.Add(entitySchemaUId, entitySchema);
					} else {
						entitySchema = entitySchemas[entitySchemaUId];
					}
					bool validateRequired = false;
					var lookupEntity = entitySchema.CreateEntity(UserConnection);
					lookupEntity.SetDefColumnValues();
					lookupEntity.SetColumnValue(entitySchema.PrimaryColumn.Name, guid);
					lookupEntity.SetColumnValue(entitySchema.PrimaryDisplayColumn.Name, valueInBpm);
					lookupEntity.Save(validateRequired);
					LogExcelImportLog(entity);
				}
				LogInfo(string.Format("\t{0}\t{1}\t\tSave new {2} lookups, end", FileName, ExcelImportId, entities.Count));
			}
			var rows = ImportExcelData as string[][];
			ExecuteImportExcelDataProcess(rows);
			return true;
		}

		public virtual void LogExcelImportLog(Tuple<Guid, string, string, string, string, KeyValuePair<Guid, string>, Dictionary<int, Collection<int>>> entity) {
			if (IsSyncLookupConflicts) {
				return;
			}
			var guid = Guid.NewGuid();
			var nowParameter = new QueryParameter("now", DateTime.Now, "DateTime");
			var currentUserContactIdParameter = new QueryParameter("currentUserId",
				UserConnection.CurrentUser.ContactId);
			string lookup = entity.Item5;
			string lookupValue = entity.Item2;
			string message = string.Format(AddNewLookupRecordLocalizableString, 
					"\"" + lookup + "\"",
					"\"" + lookupValue + "\"");
			new Insert(UserConnection)
				.Into("ExcelImportLog")
				.Set("Id", Column.Parameter(guid))
				.Set("CreatedOn", nowParameter)
				.Set("CreatedById", currentUserContactIdParameter)
				.Set("ModifiedOn", nowParameter)
				.Set("ModifiedById", currentUserContactIdParameter)
				.Set("MessageText", Column.Parameter(message))
				.Set("ExcelImportId", Column.Parameter(ExcelImportId))
				.Execute();
		}

		public virtual void ExecuteImportExcelDataProcess(string[][] rows) {
			if(rows == null) {
				return;
			}
			LogInfo(string.Format("\t{0}\t{1}\t\tStarting save data import process", FileName, ExcelImportId));
			string jobName = "ImportExcelData";
			string jobGroup = "ImportExcelDataGroup";
			string processName = "ImportExcelDataProcess";
			var processParameters = new Dictionary<string, object>() {
				{"ExcelImportId", ExcelImportId},
				{"ImportExcelData", rows},
				{"IsPrimaryDisplayColumnExists", IsPrimaryDisplayColumnExists},
				{"SelectedIdentificationColumns", SelectedIdentificationColumns},
				{"NameColumnIndex", NameColumnIndex},
				{"Captions", Captions},
				{"FileName", FileName},
				{"SchemaName", SchemaName},
				{"ImportMode", ImportMode},
				{"IsOnlyErrorsMode", IsOnlyErrorsMode},
				{"HeaderNames", HeaderNames}
			};
			AppScheduler.ScheduleImmediateProcessJob(jobName, jobGroup, processName,
				UserConnection.Workspace.Name, UserConnection.CurrentUser.Name, processParameters);
		}

		public virtual void LogInfo(string message) {
			if(ExcelUtilities.Log != null) {
				ExcelUtilities.Log.Info(message);
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
			var cloneItem = (ImportExcelLookupProcess)base.CloneShallow();
			cloneItem.ExecutedEventHandler = ExecutedEventHandler;
			cloneItem.LookupEntities = LookupEntities;
			cloneItem.ImportExcelData = ImportExcelData;
			cloneItem.Captions = Captions;
			cloneItem.HeaderNames = HeaderNames;
			return cloneItem;
		}

		#endregion

	}

	#endregion

}

