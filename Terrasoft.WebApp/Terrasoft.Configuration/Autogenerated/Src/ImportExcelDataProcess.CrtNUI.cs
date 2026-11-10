namespace Terrasoft.Core.Process
{

	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.ComponentModel;
	using System.Drawing;
	using System.Globalization;
	using System.Linq;
	using System.Text;
	using System.Text.RegularExpressions;
	using Terrasoft.Common;
	using Terrasoft.Common.Json;
	using Terrasoft.Configuration;
	using Terrasoft.Configuration.ImportExcelData;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Process;
	using Terrasoft.Core.Process.Configuration;

	#region Class: ImportExcelDataProcessSchema

	/// <exclude/>
	public class ImportExcelDataProcessSchema : Terrasoft.Core.Process.ProcessSchema
	{

		#region Constructors: Public

		public ImportExcelDataProcessSchema(ProcessSchemaManager processSchemaManager)
			: base(processSchemaManager) {
		}

		public ImportExcelDataProcessSchema(ImportExcelDataProcessSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			Name = "ImportExcelDataProcess";
			UId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64");
			CreatedInPackageId = new Guid("ff6db8c2-aaeb-43c3-ad7c-1d48a4333145");
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
			RealUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64");
			Version = 0;
			PackageUId = new Guid("422cc048-65aa-8f90-e8ed-7fa6d5ab06b1");
			UseSystemSecurityContext = false;
		}

		protected virtual ProcessSchemaParameter CreateIsPrimaryDisplayColumnExistsParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("9a4361f7-ca56-4c89-a1bb-1c5f8f5d53f0"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64"),
				Name = @"IsPrimaryDisplayColumnExists",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean"),
			};
		}

		protected virtual ProcessSchemaParameter CreateSelectedIdentificationColumnsParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("1a42fa28-bcfb-48ee-a10b-66e8962144f8"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64"),
				Name = @"SelectedIdentificationColumns",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MaxSizeText"),
			};
		}

		protected virtual ProcessSchemaParameter CreateNameColumnIndexParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("04e7f954-858c-4d11-8095-05a47ffe3066"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64"),
				Name = @"NameColumnIndex",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Integer"),
			};
		}

		protected virtual ProcessSchemaParameter CreateCaptionsParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("3f3f43c6-d874-4769-8327-eea1ac82943e"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64"),
				Name = @"Captions",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Object"),
			};
		}

		protected virtual ProcessSchemaParameter CreateExcelImportIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("1cf3f54f-a7eb-419b-9ca6-896f1097a9b0"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64"),
				Name = @"ExcelImportId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid"),
			};
		}

		protected virtual ProcessSchemaParameter CreateFileNameParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("84b1fb8a-a77a-4385-89dd-66088e2965d2"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64"),
				Name = @"FileName",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MaxSizeText"),
			};
		}

		protected virtual ProcessSchemaParameter CreateSchemaNameParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("53049422-8db2-4323-b9bb-8ecf8ab0801a"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64"),
				Name = @"SchemaName",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MediumText"),
			};
		}

		protected virtual ProcessSchemaParameter CreateImportModeParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("89f55192-d503-40b4-93a4-cf6fa6a472a3"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64"),
				Name = @"ImportMode",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Integer"),
			};
		}

		protected virtual ProcessSchemaParameter CreateIsOnlyErrorsModeParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("c73b974a-5e91-4d65-8d8f-f38fefcfefc8"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64"),
				Name = @"IsOnlyErrorsMode",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean"),
			};
		}

		protected virtual ProcessSchemaParameter CreateHeaderNamesParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("a8ec71b6-9125-42fa-b2c6-baad509c6725"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64"),
				Name = @"HeaderNames",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Object"),
			};
		}

		protected virtual ProcessSchemaParameter CreateImportExcelDataParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("3ca610ee-f99e-4a6e-9441-e9c5d7bdd6e0"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64"),
				Name = @"ImportExcelData",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Object"),
			};
		}

		protected virtual ProcessSchemaParameter CreateImportRowCountParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("cbb05c77-81a3-4d4f-b084-319b00d9858d"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64"),
				Name = @"ImportRowCount",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Integer"),
			};
		}

		protected override void InitializeParameters() {
			base.InitializeParameters();
			Parameters.Add(CreateIsPrimaryDisplayColumnExistsParameter());
			Parameters.Add(CreateSelectedIdentificationColumnsParameter());
			Parameters.Add(CreateNameColumnIndexParameter());
			Parameters.Add(CreateCaptionsParameter());
			Parameters.Add(CreateExcelImportIdParameter());
			Parameters.Add(CreateFileNameParameter());
			Parameters.Add(CreateSchemaNameParameter());
			Parameters.Add(CreateImportModeParameter());
			Parameters.Add(CreateIsOnlyErrorsModeParameter());
			Parameters.Add(CreateHeaderNamesParameter());
			Parameters.Add(CreateImportExcelDataParameter());
			Parameters.Add(CreateImportRowCountParameter());
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
			ProcessSchemaScriptTask saveimportdata = CreateSaveImportDataScriptTask();
			FlowElements.Add(saveimportdata);
			FlowElements.Add(CreateSequenceFlow1SequenceFlow());
			FlowElements.Add(CreateSequenceFlow2SequenceFlow());
		}

		protected override void InitializeLocalizableStrings() {
			base.InitializeLocalizableStrings();
			SetLocalizableStringsDefInheritance();
			LocalizableStrings.Add(CreateUpdateItemLocalizableStringLocalizableString());
			LocalizableStrings.Add(CreateAddItemLocalizableStringLocalizableString());
			LocalizableStrings.Add(CreateNotUniqueRecordLocalizableString());
			LocalizableStrings.Add(CreateErrorMessageLocalizableString());
			LocalizableStrings.Add(CreateErrorAddItemLocalizableStringLocalizableString());
			LocalizableStrings.Add(CreateImportSuccessMessageLocalizableString());
			LocalizableStrings.Add(CreateImportErrorMessageLocalizableString());
		}

		protected virtual SchemaLocalizableString CreateUpdateItemLocalizableStringLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("ccbf6331-9b8f-4c31-b9b9-e9691351ac69"),
				Name = "UpdateItemLocalizableString",
				CreatedInPackageId = new Guid("fe3149b2-9704-43d8-935e-39b7af42f452"),
				CreatedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64"),
				ModifiedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64")
			};
			return localizableString;
		}

		protected virtual SchemaLocalizableString CreateAddItemLocalizableStringLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("006487b0-19b1-4090-af23-4eb6601a711d"),
				Name = "AddItemLocalizableString",
				CreatedInPackageId = new Guid("fe3149b2-9704-43d8-935e-39b7af42f452"),
				CreatedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64"),
				ModifiedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64")
			};
			return localizableString;
		}

		protected virtual SchemaLocalizableString CreateNotUniqueRecordLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("b19f1299-23d4-44a1-8806-75f90952a493"),
				Name = "NotUniqueRecord",
				CreatedInPackageId = new Guid("fe3149b2-9704-43d8-935e-39b7af42f452"),
				CreatedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64"),
				ModifiedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64")
			};
			return localizableString;
		}

		protected virtual SchemaLocalizableString CreateErrorMessageLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("e86114bf-be71-4e8e-9b53-0b97b089da78"),
				Name = "ErrorMessage",
				CreatedInPackageId = new Guid("fe3149b2-9704-43d8-935e-39b7af42f452"),
				CreatedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64"),
				ModifiedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64")
			};
			return localizableString;
		}

		protected virtual SchemaLocalizableString CreateErrorAddItemLocalizableStringLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("fdd713f7-fec7-4e53-9f67-c0346c36e5cf"),
				Name = "ErrorAddItemLocalizableString",
				CreatedInPackageId = new Guid("fe3149b2-9704-43d8-935e-39b7af42f452"),
				CreatedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64"),
				ModifiedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64")
			};
			return localizableString;
		}

		protected virtual SchemaLocalizableString CreateImportSuccessMessageLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("d5f6cd85-5a1d-4143-8838-bfc00be73318"),
				Name = "ImportSuccessMessage",
				CreatedInPackageId = new Guid("fe3149b2-9704-43d8-935e-39b7af42f452"),
				CreatedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64"),
				ModifiedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64")
			};
			return localizableString;
		}

		protected virtual SchemaLocalizableString CreateImportErrorMessageLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("d50a2059-1cbc-4518-a080-2252f50fdcf4"),
				Name = "ImportErrorMessage",
				CreatedInPackageId = new Guid("fe3149b2-9704-43d8-935e-39b7af42f452"),
				CreatedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64"),
				ModifiedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64")
			};
			return localizableString;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow1SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow1",
				UId = new Guid("3f7496dc-09ea-4bbe-a1d6-1aa6acd5fd6a"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ff6db8c2-aaeb-43c3-ad7c-1d48a4333145"),
				CreatedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64"),
				CurveCenterPosition = new Point(440, 203),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("b485fa8c-08ec-481c-9267-63a57b159e32"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("3ea486ab-5a7e-4d56-8161-9b07e98876c4"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow2SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow2",
				UId = new Guid("782b29fa-1d4e-4449-91ad-627c99ee22a9"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("fe3149b2-9704-43d8-935e-39b7af42f452"),
				CreatedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64"),
				CurveCenterPosition = new Point(440, 203),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("3ea486ab-5a7e-4d56-8161-9b07e98876c4"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("d01663b7-8c62-41be-b627-fff3d92a6896"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaLaneSet CreateLaneSet1LaneSet() {
			ProcessSchemaLaneSet schemaLaneSet1 = new ProcessSchemaLaneSet(this) {
				UId = new Guid("23c30c37-3b35-41c0-b31c-018e48b9a304"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 1,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ff6db8c2-aaeb-43c3-ad7c-1d48a4333145"),
				CreatedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64"),
				Direction = ProcessSchemaPoolDirectionType.Vertical,
				DragGroupName = @"LaneSet",
				ManagerItemUId = new Guid("11a47caf-a0d5-41fa-a274-a0b11f77447a"),
				ModifiedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64"),
				Name = @"LaneSet1",
				Position = new Point(5, 5),
				Size = new Size(1107, 400),
				UseBackgroundMode = false
			};
			return schemaLaneSet1;
		}

		protected virtual ProcessSchemaLane CreateLane1Lane() {
			ProcessSchemaLane schemaLane1 = new ProcessSchemaLane(this) {
				UId = new Guid("e9c6ef1d-9b34-4e60-a22c-524d6edf2df1"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 1,
				ContainerUId = new Guid("23c30c37-3b35-41c0-b31c-018e48b9a304"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("ff6db8c2-aaeb-43c3-ad7c-1d48a4333145"),
				CreatedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64"),
				DragGroupName = @"Lane",
				ManagerItemUId = new Guid("abcd74b9-5912-414b-82ac-f1aa4dcd554e"),
				ModifiedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64"),
				Name = @"Lane1",
				Position = new Point(29, 0),
				Size = new Size(1078, 400),
				UseBackgroundMode = false
			};
			return schemaLane1;
		}

		protected virtual ProcessSchemaStartEvent CreateStart1StartEvent() {
			ProcessSchemaStartEvent schemaStartEvent = new ProcessSchemaStartEvent(this) {
				UId = new Guid("b485fa8c-08ec-481c-9267-63a57b159e32"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = new Guid("e9c6ef1d-9b34-4e60-a22c-524d6edf2df1"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ff6db8c2-aaeb-43c3-ad7c-1d48a4333145"),
				CreatedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsInterrupting = false,
				IsLogging = false,
				ManagerItemUId = new Guid("53818048-7868-48f6-ada0-0ebaa65af628"),
				ModifiedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64"),
				Name = @"Start1",
				Position = new Point(183, 184),
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			
			return schemaStartEvent;
		}

		protected virtual ProcessSchemaTerminateEvent CreateTerminate1TerminateEvent() {
			ProcessSchemaTerminateEvent schemaTerminateEvent = new ProcessSchemaTerminateEvent(this) {
				UId = new Guid("d01663b7-8c62-41be-b627-fff3d92a6896"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = new Guid("e9c6ef1d-9b34-4e60-a22c-524d6edf2df1"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ff6db8c2-aaeb-43c3-ad7c-1d48a4333145"),
				CreatedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsLogging = false,
				ManagerItemUId = new Guid("1bd93619-0574-454e-bb4e-cf53b9eb9470"),
				ModifiedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64"),
				Name = @"Terminate1",
				Position = new Point(600, 184),
				SerializeToDB = false,
				Size = new Size(0, 0),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaTerminateEvent;
		}

		protected virtual ProcessSchemaScriptTask CreateSaveImportDataScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("3ea486ab-5a7e-4d56-8161-9b07e98876c4"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = new Guid("e9c6ef1d-9b34-4e60-a22c-524d6edf2df1"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("fe3149b2-9704-43d8-935e-39b7af42f452"),
				CreatedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = false,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64"),
				Name = @"SaveImportData",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(372, 170),
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,165,85,93,111,155,64,16,124,118,164,252,135,43,79,88,38,40,237,163,157,164,106,93,167,161,194,110,21,187,82,165,36,15,23,88,236,83,225,206,58,206,73,220,200,255,189,123,31,24,8,78,84,169,150,140,128,155,157,155,157,219,93,98,177,140,120,38,252,82,73,198,151,225,165,144,5,85,190,119,171,158,79,119,120,121,143,151,91,53,167,15,64,88,177,22,82,145,148,42,74,214,82,36,80,150,1,41,21,149,202,11,200,37,203,97,70,11,8,200,228,41,129,60,50,216,40,237,247,71,199,71,15,84,18,41,30,75,114,78,236,123,3,249,162,121,104,73,236,198,55,119,55,119,8,101,92,17,37,20,205,175,17,63,22,27,124,60,55,177,97,12,124,169,86,14,98,165,64,218,68,157,226,154,146,91,242,124,124,212,211,59,2,87,76,109,231,201,10,10,58,165,156,46,65,34,234,103,9,114,44,56,135,68,49,193,195,73,23,52,58,16,143,129,7,232,194,175,160,34,142,14,240,4,62,111,117,246,190,93,215,183,253,138,135,41,40,236,54,47,88,194,177,4,170,192,174,249,109,97,251,232,68,228,155,130,99,146,60,99,75,36,224,240,72,98,86,170,51,227,225,216,172,218,197,11,127,31,180,2,154,130,212,42,180,231,87,141,39,244,219,68,91,211,47,218,1,149,147,141,240,208,188,211,176,76,72,226,27,239,121,10,79,198,111,119,123,214,12,119,47,7,131,190,57,136,70,14,173,20,58,234,125,196,147,200,81,91,222,221,168,77,160,5,181,213,221,24,224,221,30,167,173,182,164,154,100,239,123,88,249,109,189,12,47,49,204,157,87,205,108,204,235,177,12,147,172,89,222,161,218,77,158,187,92,122,205,68,92,233,140,155,210,106,182,81,23,63,3,72,109,249,35,82,201,205,33,76,84,198,66,252,222,172,23,219,53,184,20,236,6,173,21,19,184,211,151,86,117,132,159,210,212,111,210,153,148,118,246,236,128,38,43,226,87,189,166,91,10,93,54,157,229,146,171,90,167,215,187,23,34,39,229,38,209,13,142,34,108,149,70,40,197,71,120,208,42,225,224,80,91,4,237,162,181,198,26,103,29,105,101,103,175,211,198,131,129,5,155,228,118,36,161,74,171,214,197,178,214,93,65,160,10,181,137,152,89,180,128,39,237,168,155,95,223,4,227,190,55,34,56,146,80,173,219,219,161,177,98,74,20,88,131,221,176,155,72,41,36,154,167,115,140,69,66,115,246,135,222,231,48,55,160,192,74,237,237,7,156,123,246,110,61,143,12,8,132,83,199,58,32,250,85,123,71,110,235,194,108,80,227,42,213,22,26,139,101,99,100,226,147,239,116,6,38,188,191,63,109,252,191,110,73,252,127,99,124,242,107,242,99,17,125,159,13,201,243,135,221,235,227,60,168,243,53,147,125,71,50,198,105,158,219,210,233,216,236,119,231,52,118,84,123,190,247,117,122,31,95,156,136,251,76,52,108,11,186,51,63,120,193,84,171,54,156,195,131,156,115,91,130,111,177,238,89,180,243,115,224,233,53,20,56,49,144,170,58,25,147,250,241,209,63,120,142,110,190,101,59,146,191,101,54,126,34,97,193,10,8,103,226,49,92,8,91,144,190,183,197,223,201,116,122,146,166,228,234,106,88,20,195,178,12,179,44,243,250,230,76,36,168,141,228,118,194,252,5,220,40,34,12,221,7,0,0 }
			};
			
			return ScriptTask;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
			Methods.Add(CreateCreateItemMethod());
			Methods.Add(CreateSendRemindingMethod());
			Methods.Add(CreateLogInfoMethod());
			Methods.Add(CreateLogExcelImportLogMethod());
		}

		protected override void InitializeUsings() {
			Usings.Add(new SchemaUsing() {
				UId = new Guid("d097e45e-402b-4591-8e36-e9a9d7f1fdb6"),
				Name = "Terrasoft.Configuration",
				Alias = "",
				CreatedInPackageId = new Guid("fe3149b2-9704-43d8-935e-39b7af42f452")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("4c0c881d-c893-46c9-ae2c-25eea7d1fea3"),
				Name = "Terrasoft.Core.DB",
				Alias = "",
				CreatedInPackageId = new Guid("fe3149b2-9704-43d8-935e-39b7af42f452")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("a0a7e2c2-5457-4758-9b94-ea539f7a0bad"),
				Name = "Terrasoft.Common.Json",
				Alias = "",
				CreatedInPackageId = new Guid("fe3149b2-9704-43d8-935e-39b7af42f452")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("3e1b3f83-4e55-4a35-b4dc-9f2dea44c4b6"),
				Name = "System.Globalization",
				Alias = "",
				CreatedInPackageId = new Guid("fe3149b2-9704-43d8-935e-39b7af42f452")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("186f725e-b39f-4507-8a48-6296e282151a"),
				Name = "System.Text.RegularExpressions",
				Alias = "",
				CreatedInPackageId = new Guid("fe3149b2-9704-43d8-935e-39b7af42f452")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("11275c13-d741-4c6b-b3a8-d161309f9823"),
				Name = "System.Text",
				Alias = "",
				CreatedInPackageId = new Guid("fe3149b2-9704-43d8-935e-39b7af42f452")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("ba6abfe0-3eeb-463e-a1da-a47f7d0f18c8"),
				Name = "System.ComponentModel",
				Alias = "",
				CreatedInPackageId = new Guid("fe3149b2-9704-43d8-935e-39b7af42f452")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("614c8862-a10c-426b-a599-7ea3b968f56d"),
				Name = "System.Linq",
				Alias = "",
				CreatedInPackageId = new Guid("fe3149b2-9704-43d8-935e-39b7af42f452")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("383e9e4b-44c4-4b84-8b49-26913e44b669"),
				Name = "Terrasoft.Configuration.ImportExcelData",
				Alias = "",
				CreatedInPackageId = new Guid("811fcb66-130b-4d85-9d3f-7b0df7ea2049")
			});
		}

		protected virtual SchemaMethod CreateCreateItemMethod() {
			SchemaMethod method = new SchemaMethod() {
				UId = new Guid("d27dab11-9089-48b5-86f4-c2618af25368"),
				Name = "CreateItem",
				CreatedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64"),
				CreatedInPackageId = new Guid("fe3149b2-9704-43d8-935e-39b7af42f452"),
				ResultValueTypeName = "bool"
			};
			method.Arguments.Add(new SchemaMethodArgument() {
				UId = new Guid("d64f878d-febb-4e9c-a0ce-d29590025d60"),
				Name = "row",
				CreatedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64"),
				ModifiedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64"),
				Direction = Terrasoft.Common.ParameterDirection.Input,
				ValueTypeName = "string[]",
				CreatedInPackageId = new Guid("fe3149b2-9704-43d8-935e-39b7af42f452")
			});
			method.Arguments.Add(new SchemaMethodArgument() {
				UId = new Guid("9822e0b9-20d7-443b-a191-d27bae29c472"),
				Name = "entitySchema",
				CreatedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64"),
				ModifiedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64"),
				Direction = Terrasoft.Common.ParameterDirection.Input,
				ValueTypeName = "EntitySchema",
				CreatedInPackageId = new Guid("fe3149b2-9704-43d8-935e-39b7af42f452")
			});
			method.Arguments.Add(new SchemaMethodArgument() {
				UId = new Guid("057c7d29-42fc-4930-a4c9-c823e5a4ddd0"),
				Name = "entitySchemaManager",
				CreatedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64"),
				ModifiedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64"),
				Direction = Terrasoft.Common.ParameterDirection.Input,
				ValueTypeName = "EntitySchemaManager",
				CreatedInPackageId = new Guid("fe3149b2-9704-43d8-935e-39b7af42f452")
			});
			method.Arguments.Add(new SchemaMethodArgument() {
				UId = new Guid("67bde463-3490-4770-a508-2419a46af7bc"),
				Name = "columnsConfig",
				CreatedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64"),
				ModifiedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64"),
				Direction = Terrasoft.Common.ParameterDirection.Input,
				ValueTypeName = "List<ExcelColumnConfig>",
				CreatedInPackageId = new Guid("fe3149b2-9704-43d8-935e-39b7af42f452")
			});
			method.ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,197,88,91,79,27,71,20,126,6,137,255,48,245,67,88,75,206,146,86,170,162,150,75,4,54,164,142,130,161,152,180,15,200,15,195,238,24,86,221,139,51,59,11,184,13,82,67,170,190,84,106,165,254,18,90,21,137,54,74,243,23,214,255,168,103,46,187,158,245,142,111,36,162,47,123,153,57,183,57,231,59,103,206,204,25,166,40,196,1,65,235,168,25,239,83,47,192,180,223,240,226,158,143,251,245,200,79,130,112,251,194,139,89,140,158,32,26,157,31,181,128,82,14,55,67,151,92,116,208,151,40,102,212,11,79,236,237,160,199,250,171,75,139,103,92,94,116,190,143,41,144,50,66,65,110,72,206,209,215,9,161,253,124,208,170,0,73,165,134,26,152,145,67,47,32,246,11,230,180,162,243,26,170,100,35,149,170,146,229,36,148,146,144,189,136,9,173,71,33,195,14,107,186,211,132,107,60,77,23,212,40,230,144,56,204,139,66,187,62,156,182,115,153,153,62,47,222,33,204,57,37,46,200,238,98,63,38,106,28,251,126,211,5,46,175,235,57,152,139,17,110,136,55,41,105,134,59,158,207,253,199,104,194,169,151,22,183,129,140,245,145,199,72,160,62,215,17,17,31,109,144,28,96,187,78,9,172,83,206,89,69,235,50,59,116,122,177,62,181,214,237,209,113,75,167,220,197,33,62,33,180,86,84,199,163,198,229,150,120,101,40,53,67,155,174,26,90,47,27,96,111,186,106,182,160,210,126,74,152,194,141,156,229,218,172,42,215,183,178,82,63,64,71,159,62,126,244,248,243,47,58,168,177,183,180,232,117,145,245,137,66,76,51,110,37,190,191,71,5,114,172,54,241,193,1,196,53,56,57,140,171,85,244,195,210,226,130,136,143,154,39,202,150,24,76,125,22,67,84,27,4,252,232,97,223,251,158,76,17,134,112,140,158,109,82,138,57,94,133,208,83,130,93,66,185,225,92,220,87,218,31,144,62,7,252,175,73,155,55,50,134,88,44,125,104,193,208,131,118,22,98,57,199,25,186,17,132,219,57,69,150,192,179,114,121,88,94,137,92,228,130,84,85,154,110,201,36,45,184,126,199,11,221,182,102,202,86,127,151,48,188,143,217,169,37,245,28,85,2,53,80,233,216,135,81,91,136,134,224,8,72,112,219,196,106,32,179,69,58,131,120,205,19,182,24,219,235,90,38,75,170,130,153,135,51,103,94,67,143,96,5,104,101,37,253,125,240,58,189,65,233,219,244,22,165,127,14,126,73,255,24,252,152,94,167,239,210,119,240,13,227,239,211,127,211,183,131,223,80,250,151,124,221,194,199,13,76,94,165,183,131,159,224,239,159,244,122,240,51,188,129,251,61,112,222,14,94,15,222,12,174,224,121,5,210,222,12,126,29,92,129,88,4,164,215,233,223,160,228,230,9,55,101,97,134,4,205,242,25,168,29,200,123,47,76,228,223,101,230,8,114,225,16,95,46,242,27,236,39,156,135,87,189,108,137,29,65,61,54,139,114,55,233,163,147,19,105,188,107,75,40,208,132,42,40,24,231,134,145,229,193,41,224,84,192,101,171,47,242,211,168,24,82,242,121,20,125,151,244,14,251,61,162,208,184,48,62,101,71,189,85,205,88,132,47,65,182,239,234,190,42,21,193,89,173,58,32,93,2,5,219,33,146,113,21,13,149,196,201,113,41,28,243,21,202,146,153,246,48,6,147,98,157,135,215,100,130,22,225,178,252,241,245,146,107,52,138,3,252,194,198,22,115,177,150,36,51,211,201,125,69,82,127,235,177,211,124,79,140,51,182,5,57,89,143,130,30,166,30,212,77,30,106,123,251,101,130,253,90,70,82,54,217,212,23,8,63,229,60,163,88,80,227,85,249,46,186,19,200,124,185,217,13,157,167,141,141,113,41,184,109,148,212,176,117,46,40,196,26,4,3,224,146,144,161,13,81,166,148,125,229,220,52,184,218,64,53,131,163,39,121,26,229,68,99,243,91,163,49,172,229,232,81,135,59,132,139,116,53,175,175,61,77,60,119,195,202,208,41,161,156,201,201,62,50,55,93,34,2,229,112,70,87,140,115,129,172,8,146,210,26,187,152,28,221,162,210,142,104,190,15,197,66,111,65,237,44,145,191,75,220,103,136,250,244,152,155,179,73,6,176,154,111,89,151,170,25,33,229,12,42,91,62,99,250,240,220,25,149,55,76,28,244,224,193,212,70,88,37,151,222,71,107,221,145,24,220,161,81,208,216,42,233,153,2,234,82,147,106,15,35,12,174,208,162,187,178,242,240,33,239,54,197,106,38,157,106,138,29,87,207,64,103,234,186,198,86,195,188,161,10,243,99,210,148,253,127,156,74,25,228,187,101,134,17,157,147,96,57,180,86,214,116,49,160,50,167,84,157,63,38,216,166,160,45,239,64,238,21,74,80,38,56,160,224,113,169,206,43,185,126,105,144,222,235,19,214,32,93,77,65,108,201,44,42,144,104,243,86,69,28,72,185,25,118,139,156,243,183,220,250,65,151,225,152,0,254,234,122,39,252,176,32,255,99,57,32,237,80,168,117,116,156,234,108,118,30,2,53,191,58,202,164,247,184,5,206,97,183,43,28,80,152,107,17,56,87,5,189,136,50,244,234,21,164,151,248,220,141,92,16,180,142,62,227,21,194,216,44,106,26,171,89,163,168,55,225,165,98,86,78,30,83,199,232,20,83,70,36,252,93,44,82,69,11,216,139,142,48,53,196,99,131,235,104,149,60,4,77,25,158,180,109,103,60,179,190,240,2,187,64,163,16,49,139,121,147,91,111,133,118,99,71,253,129,55,14,147,26,105,121,112,159,169,34,206,215,47,223,83,133,156,167,35,70,5,92,229,203,255,63,234,230,140,88,155,179,120,154,74,102,17,163,5,172,9,94,46,139,103,35,131,119,212,181,218,253,24,108,179,179,203,190,44,253,220,40,57,134,131,58,243,212,86,154,205,35,23,62,242,133,55,4,149,125,40,174,252,98,162,231,49,0,27,194,225,16,107,217,94,174,161,229,218,114,181,134,162,132,9,137,213,249,242,55,191,154,228,59,204,222,38,255,181,164,24,61,169,133,61,25,165,201,34,169,159,219,63,167,126,193,114,39,231,54,136,3,216,244,51,125,234,23,185,242,45,56,132,220,122,226,179,132,119,109,221,40,187,101,85,67,128,205,73,87,166,146,72,191,165,112,228,80,187,7,58,160,45,204,246,149,3,114,66,46,242,152,20,188,82,57,170,217,29,216,9,139,138,237,86,18,28,19,186,19,209,0,51,245,163,236,111,19,200,75,204,34,58,204,0,53,163,249,221,96,134,10,128,182,248,121,3,161,179,222,41,32,199,81,228,87,249,54,100,190,70,49,237,67,51,89,166,51,174,206,105,147,180,228,163,232,251,16,9,178,201,210,120,241,25,17,45,20,37,16,201,80,94,169,255,7,114,161,171,140,163,24,0,0 };
			return method;
		}

		protected virtual SchemaMethod CreateSendRemindingMethod() {
			SchemaMethod method = new SchemaMethod() {
				UId = new Guid("bc0df034-fe1f-479d-8895-3302db57a211"),
				Name = "SendReminding",
				CreatedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64"),
				CreatedInPackageId = new Guid("fe3149b2-9704-43d8-935e-39b7af42f452"),
				ResultValueTypeName = "void"
			};
			method.Arguments.Add(new SchemaMethodArgument() {
				UId = new Guid("7cdb378a-d9d9-4190-b3dd-edb4c7a01322"),
				Name = "message",
				CreatedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64"),
				ModifiedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64"),
				Direction = Terrasoft.Common.ParameterDirection.Input,
				ValueTypeName = "string",
				CreatedInPackageId = new Guid("fe3149b2-9704-43d8-935e-39b7af42f452")
			});
			method.ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,69,141,193,10,194,48,16,68,239,130,255,16,114,106,33,20,245,104,111,86,11,5,17,177,244,150,75,104,215,178,208,36,178,89,68,41,253,119,131,90,189,188,203,188,153,57,250,190,114,87,159,4,38,116,125,86,122,178,134,19,169,121,92,77,17,235,8,205,53,184,78,16,88,116,93,148,132,133,16,76,15,91,161,229,184,153,180,148,74,148,56,192,201,88,80,226,240,104,97,168,236,205,19,87,157,154,221,52,205,151,139,203,188,80,3,221,129,26,198,1,25,33,100,5,129,97,248,197,187,231,153,124,27,139,73,19,128,10,239,28,180,140,222,41,33,63,195,239,143,189,97,243,245,228,255,39,127,1,219,192,214,246,209,0,0,0 };
			return method;
		}

		protected virtual SchemaMethod CreateLogInfoMethod() {
			SchemaMethod method = new SchemaMethod() {
				UId = new Guid("a01dec9a-023e-4323-b5b2-dda71fad05e6"),
				Name = "LogInfo",
				CreatedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64"),
				CreatedInPackageId = new Guid("fe3149b2-9704-43d8-935e-39b7af42f452"),
				ResultValueTypeName = "void"
			};
			method.Arguments.Add(new SchemaMethodArgument() {
				UId = new Guid("df3ed52c-43ff-4c7e-8c78-880167a52d8e"),
				Name = "message",
				CreatedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64"),
				ModifiedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64"),
				Direction = Terrasoft.Common.ParameterDirection.Input,
				ValueTypeName = "string",
				CreatedInPackageId = new Guid("fe3149b2-9704-43d8-935e-39b7af42f452")
			});
			method.ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,203,76,83,208,112,173,72,78,205,9,45,201,204,201,44,201,76,45,214,243,201,79,87,80,180,85,200,43,205,201,209,84,168,230,229,226,196,148,215,243,204,75,203,215,200,77,45,46,78,76,79,213,180,230,229,170,5,0,51,238,221,68,72,0,0,0 };
			return method;
		}

		protected virtual SchemaMethod CreateLogExcelImportLogMethod() {
			SchemaMethod method = new SchemaMethod() {
				UId = new Guid("aad222b4-7528-45c2-9e78-52ac71f3fca1"),
				Name = "LogExcelImportLog",
				CreatedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64"),
				CreatedInPackageId = new Guid("5124eccf-c1be-4f38-a8ca-c1c899ca35a8"),
				ResultValueTypeName = "void"
			};
			method.Arguments.Add(new SchemaMethodArgument() {
				UId = new Guid("a26b8482-c202-46c5-8b7c-01a05e3054d9"),
				Name = "message",
				CreatedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64"),
				ModifiedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64"),
				Direction = Terrasoft.Common.ParameterDirection.Input,
				ValueTypeName = "string",
				CreatedInPackageId = new Guid("5124eccf-c1be-4f38-a8ca-c1c899ca35a8")
			});
			method.Arguments.Add(new SchemaMethodArgument() {
				UId = new Guid("f69ac4c6-8250-46a3-a0d4-8df5a71d9efa"),
				Name = "name",
				CreatedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64"),
				ModifiedInSchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64"),
				Direction = Terrasoft.Common.ParameterDirection.Input,
				ValueTypeName = "string",
				CreatedInPackageId = new Guid("5124eccf-c1be-4f38-a8ca-c1c899ca35a8")
			});
			method.ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,149,145,209,106,195,48,12,69,159,87,232,63,24,63,37,16,252,3,99,47,203,74,9,172,233,198,218,15,48,142,22,12,141,60,28,185,73,255,126,114,187,52,41,11,29,123,18,88,231,94,73,215,71,237,5,186,238,77,123,221,0,129,23,79,2,161,19,239,1,252,233,250,152,72,70,100,38,94,52,193,206,54,160,246,100,74,215,101,66,14,47,50,125,92,46,142,236,101,130,247,128,180,111,193,231,14,73,27,42,170,191,204,39,154,162,146,217,114,241,240,35,71,48,100,29,170,124,4,212,213,117,152,88,7,91,177,241,154,139,42,161,139,53,137,189,56,169,64,150,80,114,107,151,242,0,85,32,185,68,174,122,3,135,162,249,114,158,94,93,45,207,157,15,160,68,198,61,68,238,14,161,65,53,110,26,71,165,35,148,123,224,243,171,45,50,59,205,240,23,241,124,58,251,221,205,102,20,109,92,101,63,237,93,223,1,249,167,49,180,173,174,97,7,61,205,93,215,92,218,147,3,39,241,204,7,114,3,76,132,37,247,231,120,228,122,193,86,61,152,64,192,63,245,13,17,153,73,69,130,2,0,0 };
			return method;
		}

		#endregion

		#region Methods: Public

		public override Process CreateProcess(UserConnection userConnection) {
			return new ImportExcelDataProcess(userConnection);
		}

		public override object Clone() {
			return new ImportExcelDataProcessSchema(this);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64"));
		}

		#endregion

	}

	#endregion

	#region Class: ImportExcelDataProcess

	/// <exclude/>
	public class ImportExcelDataProcess : Terrasoft.Core.Process.Process
	{

		#region Class: ProcessLane1

		/// <exclude/>
		public class ProcessLane1 : ProcessLane
		{

			public ProcessLane1(UserConnection userConnection, ImportExcelDataProcess process)
				: base(userConnection) {
				Owner = process;
				IsUsedParentUserContexts = false;
			}

		}

		#endregion

		public ImportExcelDataProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ImportExcelDataProcess";
			SchemaUId = new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64");
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
				return new Guid("19daac7e-fc8a-4b3e-9925-a735c6a9dd64");
			}
		}

		private string ConditionalExpressionLogMessage {
			get {
				return "Process: ImportExcelDataProcess, Source element: {0}, Conditional flow: {1}, Expression: {2}, Result: {3}";
			}
		}

		private string DeadEndGatewayLogMessage {
			get {
				return "Process: ImportExcelDataProcess, Source element: {0}, None of the exclusive gateway conditions are met!";
			}
		}

		#endregion

		#region Properties: Public

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

		public virtual Guid ExcelImportId {
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

		public virtual Object ImportExcelData {
			get;
			set;
		}

		public virtual int ImportRowCount {
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
					SchemaElementUId = new Guid("b485fa8c-08ec-481c-9267-63a57b159e32"),
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
					SchemaElementUId = new Guid("d01663b7-8c62-41be-b627-fff3d92a6896"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _saveImportData;
		public ProcessScriptTask SaveImportData {
			get {
				return _saveImportData ?? (_saveImportData = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "SaveImportData",
					SchemaElementUId = new Guid("3ea486ab-5a7e-4d56-8161-9b07e98876c4"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					Script = SaveImportDataExecute,
				});
			}
		}

		private LocalizableString _updateItemLocalizableString;
		public LocalizableString UpdateItemLocalizableString {
			get {
				return _updateItemLocalizableString ?? (_updateItemLocalizableString = new LocalizableString(Storage, Schema.GetResourceManagerName(), "LocalizableStrings.UpdateItemLocalizableString.Value"));
			}
		}

		private LocalizableString _addItemLocalizableString;
		public LocalizableString AddItemLocalizableString {
			get {
				return _addItemLocalizableString ?? (_addItemLocalizableString = new LocalizableString(Storage, Schema.GetResourceManagerName(), "LocalizableStrings.AddItemLocalizableString.Value"));
			}
		}

		private LocalizableString _notUniqueRecord;
		public LocalizableString NotUniqueRecord {
			get {
				return _notUniqueRecord ?? (_notUniqueRecord = new LocalizableString(Storage, Schema.GetResourceManagerName(), "LocalizableStrings.NotUniqueRecord.Value"));
			}
		}

		private LocalizableString _errorMessage;
		public LocalizableString ErrorMessage {
			get {
				return _errorMessage ?? (_errorMessage = new LocalizableString(Storage, Schema.GetResourceManagerName(), "LocalizableStrings.ErrorMessage.Value"));
			}
		}

		private LocalizableString _errorAddItemLocalizableString;
		public LocalizableString ErrorAddItemLocalizableString {
			get {
				return _errorAddItemLocalizableString ?? (_errorAddItemLocalizableString = new LocalizableString(Storage, Schema.GetResourceManagerName(), "LocalizableStrings.ErrorAddItemLocalizableString.Value"));
			}
		}

		private LocalizableString _importSuccessMessage;
		public LocalizableString ImportSuccessMessage {
			get {
				return _importSuccessMessage ?? (_importSuccessMessage = new LocalizableString(Storage, Schema.GetResourceManagerName(), "LocalizableStrings.ImportSuccessMessage.Value"));
			}
		}

		private LocalizableString _importErrorMessage;
		public LocalizableString ImportErrorMessage {
			get {
				return _importErrorMessage ?? (_importErrorMessage = new LocalizableString(Storage, Schema.GetResourceManagerName(), "LocalizableStrings.ImportErrorMessage.Value"));
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[Start1.SchemaElementUId] = new Collection<ProcessFlowElement> { Start1 };
			FlowElements[Terminate1.SchemaElementUId] = new Collection<ProcessFlowElement> { Terminate1 };
			FlowElements[SaveImportData.SchemaElementUId] = new Collection<ProcessFlowElement> { SaveImportData };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "Start1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("SaveImportData", e.Context.SenderName));
						break;
					case "Terminate1":
						CompleteProcess();
						break;
					case "SaveImportData":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("Terminate1", e.Context.SenderName));
						break;
			}
		}

		private void WritePropertyValues(DataWriter writer, bool useAllValueSources) {
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
			if (!HasMapping("ExcelImportId")) {
				writer.WriteValue("ExcelImportId", ExcelImportId, Guid.Empty);
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
			if (ImportExcelData != null) {
				if (ImportExcelData.GetType().IsSerializable ||
					ImportExcelData.GetType().GetInterface("ISerializable") != null) {
					WriteSerializableObject(writer, "ImportExcelData", ImportExcelData, null);
				}
			}
			if (!HasMapping("ImportRowCount")) {
				writer.WriteValue("ImportRowCount", ImportRowCount, 0);
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
			MetaPathParameterValues.Add("9a4361f7-ca56-4c89-a1bb-1c5f8f5d53f0", () => IsPrimaryDisplayColumnExists);
			MetaPathParameterValues.Add("1a42fa28-bcfb-48ee-a10b-66e8962144f8", () => SelectedIdentificationColumns);
			MetaPathParameterValues.Add("04e7f954-858c-4d11-8095-05a47ffe3066", () => NameColumnIndex);
			MetaPathParameterValues.Add("3f3f43c6-d874-4769-8327-eea1ac82943e", () => Captions);
			MetaPathParameterValues.Add("1cf3f54f-a7eb-419b-9ca6-896f1097a9b0", () => ExcelImportId);
			MetaPathParameterValues.Add("84b1fb8a-a77a-4385-89dd-66088e2965d2", () => FileName);
			MetaPathParameterValues.Add("53049422-8db2-4323-b9bb-8ecf8ab0801a", () => SchemaName);
			MetaPathParameterValues.Add("89f55192-d503-40b4-93a4-cf6fa6a472a3", () => ImportMode);
			MetaPathParameterValues.Add("c73b974a-5e91-4d65-8d8f-f38fefcfefc8", () => IsOnlyErrorsMode);
			MetaPathParameterValues.Add("a8ec71b6-9125-42fa-b2c6-baad509c6725", () => HeaderNames);
			MetaPathParameterValues.Add("3ca610ee-f99e-4a6e-9441-e9c5d7bdd6e0", () => ImportExcelData);
			MetaPathParameterValues.Add("cbb05c77-81a3-4d4f-b084-319b00d9858d", () => ImportRowCount);
		}

		protected override void ApplyPropertiesDataValues(DataReader reader) {
			base.ApplyPropertiesDataValues(reader);
			bool hasValueToRead = reader.HasValue();
			switch (reader.CurrentName) {
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
				case "ExcelImportId":
					if (!hasValueToRead) break;
					ExcelImportId = reader.GetValue<System.Guid>();
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
				case "ImportExcelData":
					if (!hasValueToRead) break;
					ImportExcelData = GetSerializableObject(reader);
				break;
				case "ImportRowCount":
					if (!hasValueToRead) break;
					ImportRowCount = reader.GetValue<System.Int32>();
				break;
			}
		}

		protected override void WritePropertyValues(DataWriter writer) {
			base.WritePropertyValues(writer);
			WritePropertyValues(writer, true);
		}

		#endregion

		#region Methods: Public

		public virtual bool SaveImportDataExecute(ProcessExecutingContext context) {
			LogInfo(string.Format("\t{0}\t{1}\t\tSave import data process, start", FileName, ExcelImportId));
			var rows = ImportExcelData as string[][];
			int totalRowsCount = rows.Length;
			int importedRowsCount = 0;
			try {
				var entitySchemaManager = UserConnection.EntitySchemaManager;
				var entitySchema = entitySchemaManager.GetInstanceByName(SchemaName);
				var itemEntity = entitySchema.CreateEntity(UserConnection);
				var columnsConfig = new List<ExcelColumnConfig>();
				var headerNames = HeaderNames as List<string>;
				var headerCount = headerNames.Count;
				for (int index = 0; index < headerCount; index++) {
					var columnConfig = new ExcelColumnConfig() { Index = index };
					var columnName = headerNames[index];
					var itemColumn = itemEntity.Schema.Columns.FindByName(columnName);
					if (itemColumn != null) {
						columnConfig.EntityColumnName = columnName;
						columnConfig.NeedImport = true;
						columnConfig.IsLookupType = itemColumn.IsLookupType;
					}
					columnsConfig.Add(columnConfig);
				}
				foreach (string[] row in rows) {
					try {
						bool success = CreateItem(row, entitySchema, entitySchemaManager, columnsConfig);
						if (success) {
							importedRowsCount++;
						}
					} catch (Exception e) {
						string dataText = string.Join("; ", row);
						string message = string.Format(ErrorAddItemLocalizableString,
								FileName,
								"\"" + e.Message + "\"");
						string name = ErrorMessage + dataText;
						LogExcelImportLog(message, name);
					}
				}
			} catch (Exception e) {
				LogInfo(string.Format("\t{0}\t{1}\t\tSave import data process, EXEPTION: {2}", FileName, ExcelImportId, e.Message));
			} finally {
				string message = (importedRowsCount != totalRowsCount)
					? string.Format(ImportErrorMessage, importedRowsCount, totalRowsCount, FileName)
					: string.Format(ImportSuccessMessage, importedRowsCount, FileName);
				SendReminding(message);
			}
			LogInfo(string.Format("\t{0}\t{1}\t{2}\tSave import data process, end", FileName, ExcelImportId, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")));
			return true;
		}

		public virtual bool CreateItem(string[] row, EntitySchema entitySchema, EntitySchemaManager entitySchemaManager, List<ExcelColumnConfig> columnsConfig) {
			var name = IsPrimaryDisplayColumnExists ? row[NameColumnIndex] : string.Empty;
			var nowParameter = new QueryParameter("now", DateTime.UtcNow, "DateTime");
			var currentUserContactIdParameter = new QueryParameter("currentUserId", UserConnection.CurrentUser.ContactId);
			var isFetched = false;
			var allIdentificationColumsAreInFile = true;
			
			Entity itemEntity = entitySchema.CreateEntity(UserConnection);
			var entitySchemaQuery = new EntitySchemaQuery(entitySchemaManager, entitySchema.Name);
			EntitySchemaQueryColumn itemEntityIdColumn = entitySchemaQuery.AddColumn(entitySchema.GetPrimaryColumnName());
			//CR [170759] DO
			if (!string.IsNullOrEmpty(SelectedIdentificationColumns)) {
				var identifiedColumns = Json.Deserialize(SelectedIdentificationColumns) as JArray;
				var headerNames = HeaderNames as List<string>;
				var schemaColumns = itemEntity.Schema.Columns;
				foreach (var column in identifiedColumns) {
					string identifiedColumnName = entitySchema.FindSchemaColumnByMetaPath(column["metaPath"].ToString()).Name;
					var rowIndex = headerNames.IndexOf(identifiedColumnName);
					if (rowIndex < 0) { //Все ли выбранные поля для идентификации присутствуют в файле?
						allIdentificationColumsAreInFile = false;
						continue;
					}
					var excelColumnValue = row[rowIndex];
					EntitySchemaQueryColumn identifiedQueryColumn = entitySchemaQuery.AddColumn(identifiedColumnName);
					string identifiedQueryColumnName = identifiedQueryColumn.Name;
					if (schemaColumns.FindByName(identifiedColumnName).IsLookupType) {
						if (!string.IsNullOrEmpty(excelColumnValue)) {
							var fieldEntitySchema = entitySchema.Columns.FindByName(identifiedColumnName).ReferenceSchema; 
							var subEntitySchemaQuery = new EntitySchemaQuery(entitySchemaManager, fieldEntitySchema.Name);
							EntitySchemaQueryColumn idColumn = subEntitySchemaQuery.AddColumn(fieldEntitySchema.GetPrimaryColumnName());
							subEntitySchemaQuery.Filters.Add(
								subEntitySchemaQuery.CreateFilterWithParameters(
									FilterComparisonType.Equal,
									fieldEntitySchema.PrimaryDisplayColumn.Name,
									excelColumnValue
								)
							);
							EntityCollection subEntityCollection = subEntitySchemaQuery.GetEntityCollection(UserConnection);
							if (subEntityCollection.Count > 0) {
								entitySchemaQuery.Filters.Add(
									entitySchemaQuery.CreateFilterWithParameters(
										FilterComparisonType.Equal, 
										identifiedQueryColumnName, 
										subEntityCollection[0].GetTypedColumnValue<Guid>(idColumn.Name)
									)
								);
							} else {
								entitySchemaQuery.Filters.Add(entitySchemaQuery.CreateIsNullFilter(identifiedQueryColumnName));
							}
						} else {
							entitySchemaQuery.Filters.Add(entitySchemaQuery.CreateIsNullFilter(identifiedQueryColumnName));
						}
					} else {
						entitySchemaQuery.Filters.Add(
							entitySchemaQuery.CreateFilterWithParameters(
								FilterComparisonType.Equal, 
								identifiedQueryColumnName, 
								excelColumnValue
							)
						);
					}
				}
				var entityCollection = entitySchemaQuery.GetEntityCollection(UserConnection);
				if (entityCollection.Count > 0 && allIdentificationColumsAreInFile) {
					isFetched = itemEntity.FetchFromDB(entityCollection[0].GetTypedColumnValue<Guid>(itemEntityIdColumn.Name));
				}
			} else {
				//--DO
				if (IsPrimaryDisplayColumnExists) {
					string primaryDisplayColumnName = entitySchema.PrimaryDisplayColumn.Name;
					var nameColumn = entitySchemaQuery.AddColumn(primaryDisplayColumnName);
					entitySchemaQuery.Filters.Add(entitySchemaQuery.CreateFilterWithParameters(FilterComparisonType.Equal, nameColumn.Name, name));
					EntityCollection entityCollection = entitySchemaQuery.GetEntityCollection(UserConnection);
					if (entityCollection.Count > 0) {
						isFetched = itemEntity.FetchFromDB(entityCollection[0].GetTypedColumnValue<Guid>(itemEntityIdColumn.Name));
					} 
				} 
			}
			if (!isFetched) {
				itemEntity.SetDefColumnValues();
				itemEntity.SetColumnValue("Id", Guid.NewGuid());
			}
			foreach (var columnConfig in columnsConfig) {
				string columnName = columnConfig.EntityColumnName;
				string columnValue = row[columnConfig.Index];
				if (!columnConfig.NeedImport || (ImportMode == 2 && string.IsNullOrEmpty(columnValue))) {
					continue;
				}
				var entityColumn = entitySchema.Columns.FindByName(columnName);
				if (ImportMode == 2 && string.IsNullOrEmpty(columnValue)) {
					if (columnConfig.IsLookupType) {
						itemEntity.SetColumnValue(columnName, null);
					} else {
						itemEntity.SetColumnValue(entityColumn, null);
					}
				} else if (columnConfig.IsLookupType) {
					var fieldEntitySchema = entityColumn.ReferenceSchema; 
					entitySchemaQuery = new EntitySchemaQuery(entitySchemaManager, fieldEntitySchema.Name);
					var idColumn = entitySchemaQuery.AddColumn(fieldEntitySchema.GetPrimaryColumnName());
					entitySchemaQuery.Filters.Add(entitySchemaQuery.CreateFilterWithParameters(FilterComparisonType.Equal, fieldEntitySchema.PrimaryDisplayColumn.Name, columnValue));
					var entityCollection = entitySchemaQuery.GetEntityCollection(UserConnection);
					if (entityCollection.Count > 0) {
						itemEntity.SetColumnValue(entityColumn, entityCollection[0].GetTypedColumnValue<Guid>(idColumn.Name));
					}
				} else if (entityColumn.ValueType == typeof(System.DateTime)) {
					double time;
					DateTime date;
					if (Double.TryParse(columnValue.Replace('.', ','), out time)) {
						itemEntity.SetColumnValue(columnName, DateTime.FromOADate(time));
					} else if (DateTime.TryParse(columnValue, out date)) {
						itemEntity.SetColumnValue(columnName, date);
					}
				} else if (entityColumn.ValueType == typeof(Decimal)) {
					Decimal decimalValue;
					CultureInfo currentCulture = UserConnection.CurrentUser.Culture;
					string cultureSpecificValue = Regex.Replace(columnValue, "[,.]", currentCulture.NumberFormat.NumberDecimalSeparator);
					if (Decimal.TryParse(cultureSpecificValue, out decimalValue)) {
						itemEntity.SetColumnValue(columnName, decimalValue);
					}
				} else if (entityColumn.ValueType == typeof(bool) && !string.IsNullOrEmpty(columnValue)) {
					itemEntity.SetColumnValue(columnName, columnValue);
				} else if (entityColumn.ValueType == typeof(string)) {
					itemEntity.SetColumnValue(columnName, columnValue);
				} else {
					itemEntity.SetColumnValue(columnName, columnValue);
				}
			}
			itemEntity.Save();
			return true;
		}

		public virtual void SendReminding(string message) {
			LogInfo(string.Format("\t{0}\t{1}\t\tSend reminding message: \"{2}\"", FileName, ExcelImportId, message));
			RemindingServerUtilities.CreateRemindingByProcess(UserConnection, "ImportExcelDataProcess", message);
		}

		public virtual void LogInfo(string message) {
			if (ExcelUtilities.Log != null) {
				ExcelUtilities.Log.Info(message);
			}
		}

		public virtual void LogExcelImportLog(string message, string name) {
			var nowParameter = new QueryParameter("now", DateTime.UtcNow, "DateTime");
			var currentUserContactIdParameter = new QueryParameter("currentUserId",
				UserConnection.CurrentUser.ContactId);
			var guid = Guid.NewGuid();
			new Insert(UserConnection)
				.Into("ExcelImportLog")
				.Set("Id", Column.Parameter(guid))
				.Set("CreatedOn", nowParameter)
				.Set("CreatedById", currentUserContactIdParameter)
				.Set("ModifiedOn", nowParameter)
				.Set("ModifiedById", currentUserContactIdParameter)
				.Set("MessageText", Column.Parameter(message))
				.Set("ExcelImportId", Column.Parameter(ExcelImportId))
				.Set("Name", Column.Parameter(name))
				.Execute();
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
			var cloneItem = (ImportExcelDataProcess)base.CloneShallow();
			cloneItem.ExecutedEventHandler = ExecutedEventHandler;
			cloneItem.Captions = Captions;
			cloneItem.HeaderNames = HeaderNames;
			cloneItem.ImportExcelData = ImportExcelData;
			return cloneItem;
		}

		#endregion

	}

	#endregion

}

