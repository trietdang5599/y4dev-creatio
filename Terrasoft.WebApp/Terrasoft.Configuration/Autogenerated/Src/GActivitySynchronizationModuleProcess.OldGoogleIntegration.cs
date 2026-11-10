namespace Terrasoft.Core.Process
{

	using Google;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Data;
	using System.Drawing;
	using System.Globalization;
	using System.Linq;
	using System.Net;
	using System.Text;
	using Terrasoft.Common;
	using Terrasoft.Common.Json;
	using Terrasoft.Configuration;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Factories;
	using Terrasoft.Core.Process;
	using Terrasoft.Core.Process.Configuration;
	using Terrasoft.GoogleServices;

	#region Class: GActivitySynchronizationModuleProcessSchema

	/// <exclude/>
	public class GActivitySynchronizationModuleProcessSchema : Terrasoft.Core.Process.ProcessSchema
	{

		#region Constructors: Public

		public GActivitySynchronizationModuleProcessSchema(ProcessSchemaManager processSchemaManager)
			: base(processSchemaManager) {
		}

		public GActivitySynchronizationModuleProcessSchema(GActivitySynchronizationModuleProcessSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			Name = "GActivitySynchronizationModuleProcess";
			UId = new Guid("0eceffe6-2795-439f-b915-118580947959");
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
			ZipCompiledMethodsBody = new byte[] {  };
			RealUId = new Guid("0eceffe6-2795-439f-b915-118580947959");
			Version = 0;
			PackageUId = new Guid("8d48ade0-350e-7694-49aa-2a913c356ce1");
			UseSystemSecurityContext = false;
		}

		protected virtual ProcessSchemaParameter CreatePageInstanceIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("6a170f99-0994-46d9-8dd1-983048f8a5da"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("0eceffe6-2795-439f-b915-118580947959"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("0eceffe6-2795-439f-b915-118580947959"),
				Name = @"PageInstanceId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Text"),
			};
		}

		protected virtual ProcessSchemaParameter CreateActiveTreeGridCurrentRowIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("53ff815d-bf48-4c18-92ed-065c25e47d7e"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("0eceffe6-2795-439f-b915-118580947959"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("0eceffe6-2795-439f-b915-118580947959"),
				Name = @"ActiveTreeGridCurrentRowId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid"),
			};
		}

		protected virtual ProcessSchemaParameter CreateModifiedGEntitiesParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("b53b4501-8253-47d0-af2f-1e41a8b9cfb2"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("0eceffe6-2795-439f-b915-118580947959"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("0eceffe6-2795-439f-b915-118580947959"),
				Name = @"ModifiedGEntities",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Object"),
			};
		}

		protected virtual ProcessSchemaParameter CreateModifiedBPMEntitiesParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("3d2a46ec-1719-423b-a9cf-568038f56080"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("0eceffe6-2795-439f-b915-118580947959"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("0eceffe6-2795-439f-b915-118580947959"),
				Name = @"ModifiedBPMEntities",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Object"),
			};
		}

		protected virtual ProcessSchemaParameter CreateCurrentSyncDateTimeParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("6181b599-3bb7-434a-bd13-b10613943f8f"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("0eceffe6-2795-439f-b915-118580947959"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("0eceffe6-2795-439f-b915-118580947959"),
				Name = @"CurrentSyncDateTime",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("DateTime"),
			};
		}

		protected virtual ProcessSchemaParameter CreateSyncProviderParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("a3699fdc-c28f-4afe-808f-096cd393ca2e"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("0eceffe6-2795-439f-b915-118580947959"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("0eceffe6-2795-439f-b915-118580947959"),
				Name = @"SyncProvider",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Object"),
			};
		}

		protected virtual ProcessSchemaParameter CreateBPMIsAConflictResolverParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("41e320fe-fd3e-4926-942f-cc7facb78796"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("0eceffe6-2795-439f-b915-118580947959"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("0eceffe6-2795-439f-b915-118580947959"),
				Name = @"BPMIsAConflictResolver",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean"),
			};
		}

		protected virtual ProcessSchemaParameter CreateDefActivityCategoryParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("0ba82835-fceb-4bad-b75d-d52fe03fa461"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("0eceffe6-2795-439f-b915-118580947959"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("0eceffe6-2795-439f-b915-118580947959"),
				Name = @"DefActivityCategory",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.ConstValue,
					Value = @"2365ae4f-58e6-df11-971b-001d60e938c6",
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("0eceffe6-2795-439f-b915-118580947959"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateResolvedConflictUIdsParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("8d1cdb9f-5c88-40f3-80ba-69dd9d1d9be2"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("0eceffe6-2795-439f-b915-118580947959"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("0eceffe6-2795-439f-b915-118580947959"),
				Name = @"ResolvedConflictUIds",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Object"),
			};
		}

		protected virtual ProcessSchemaParameter CreateLastSyncDateParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("97062d45-0d38-4cee-ba3c-9fece6c0a6f9"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("0eceffe6-2795-439f-b915-118580947959"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("0eceffe6-2795-439f-b915-118580947959"),
				Name = @"LastSyncDate",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("DateTime"),
			};
		}

		protected virtual ProcessSchemaParameter CreateGoogleAccountNameParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("5b7f83bc-6e12-4a54-b45d-bc3970a3f965"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("0eceffe6-2795-439f-b915-118580947959"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("0eceffe6-2795-439f-b915-118580947959"),
				Name = @"GoogleAccountName",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MediumText"),
			};
		}

		protected virtual ProcessSchemaParameter CreateAccessTokenParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("efefea24-99b5-4886-8785-53d0204c42ff"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("0eceffe6-2795-439f-b915-118580947959"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("0eceffe6-2795-439f-b915-118580947959"),
				Name = @"AccessToken",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MaxSizeText"),
			};
		}

		protected virtual ProcessSchemaParameter CreateActiveTreeGridClientIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("749d5d34-d42d-4f8b-857d-fbc373706b93"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("0eceffe6-2795-439f-b915-118580947959"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("0eceffe6-2795-439f-b915-118580947959"),
				Name = @"ActiveTreeGridClientId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MediumText"),
			};
		}

		protected virtual ProcessSchemaParameter CreateSyncResultParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("3e8350ee-ed3a-4f83-8ed9-c1084d8f7bb9"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("0eceffe6-2795-439f-b915-118580947959"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("0eceffe6-2795-439f-b915-118580947959"),
				Name = @"SyncResult",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MaxSizeText"),
			};
		}

		protected virtual ProcessSchemaParameter CreateSynchronizationSummaryLSParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("e6c70236-656b-4a05-aab8-4b0cdf5536d0"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("0eceffe6-2795-439f-b915-118580947959"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("0eceffe6-2795-439f-b915-118580947959"),
				Name = @"SynchronizationSummaryLS",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LocalizableStringDataValueType"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.ConstValue,
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("0eceffe6-2795-439f-b915-118580947959"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateSynchronizationSummaryParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("b4593900-7bc9-44b1-9dff-438141dd5fd1"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("2e3e95a4-2024-4552-b820-30e9633c8933"),
				CreatedInSchemaUId = new Guid("0eceffe6-2795-439f-b915-118580947959"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("0eceffe6-2795-439f-b915-118580947959"),
				Name = @"SynchronizationSummary",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LocalizableStringDataValueType"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.ConstValue,
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("0eceffe6-2795-439f-b915-118580947959"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateGoogleModificationDateLiesTooFarInThePastErrorParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("4643ae2d-19f0-4db8-860b-87461d18677c"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("2e3e95a4-2024-4552-b820-30e9633c8933"),
				CreatedInSchemaUId = new Guid("0eceffe6-2795-439f-b915-118580947959"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("0eceffe6-2795-439f-b915-118580947959"),
				Name = @"GoogleModificationDateLiesTooFarInThePastError",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LocalizableStringDataValueType"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.ConstValue,
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("0eceffe6-2795-439f-b915-118580947959"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateSenderEmailAddressParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("cffd6276-ceaa-493f-b08a-08dcfc52765a"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("0eceffe6-2795-439f-b915-118580947959"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("0eceffe6-2795-439f-b915-118580947959"),
				Name = @"SenderEmailAddress",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LongText"),
			};
		}

		protected override void InitializeParameters() {
			base.InitializeParameters();
			Parameters.Add(CreatePageInstanceIdParameter());
			Parameters.Add(CreateActiveTreeGridCurrentRowIdParameter());
			Parameters.Add(CreateModifiedGEntitiesParameter());
			Parameters.Add(CreateModifiedBPMEntitiesParameter());
			Parameters.Add(CreateCurrentSyncDateTimeParameter());
			Parameters.Add(CreateSyncProviderParameter());
			Parameters.Add(CreateBPMIsAConflictResolverParameter());
			Parameters.Add(CreateDefActivityCategoryParameter());
			Parameters.Add(CreateResolvedConflictUIdsParameter());
			Parameters.Add(CreateLastSyncDateParameter());
			Parameters.Add(CreateGoogleAccountNameParameter());
			Parameters.Add(CreateAccessTokenParameter());
			Parameters.Add(CreateActiveTreeGridClientIdParameter());
			Parameters.Add(CreateSyncResultParameter());
			Parameters.Add(CreateSynchronizationSummaryLSParameter());
			Parameters.Add(CreateSynchronizationSummaryParameter());
			Parameters.Add(CreateGoogleModificationDateLiesTooFarInThePastErrorParameter());
			Parameters.Add(CreateSenderEmailAddressParameter());
		}

		protected override void InitializeBaseElements() {
			base.InitializeBaseElements();
			ProcessSchemaLaneSet schemaGCalendarLaneSet = CreateGCalendarLaneSetLaneSet();
			LaneSets.Add(schemaGCalendarLaneSet);
			ProcessSchemaLane schemaGCalendarLane = CreateGCalendarLaneLane();
			schemaGCalendarLaneSet.Lanes.Add(schemaGCalendarLane);
			ProcessSchemaStartEvent gcalendarsyncstart = CreateGCalendarSyncStartStartEvent();
			FlowElements.Add(gcalendarsyncstart);
			ProcessSchemaEndEvent gcalendarend = CreateGCalendarEndEndEvent();
			FlowElements.Add(gcalendarend);
			ProcessSchemaScriptTask scriptaftersynchronizationactions = CreateScriptAfterSynchronizationActionsScriptTask();
			FlowElements.Add(scriptaftersynchronizationactions);
			FlowElements.Add(CreateSequenceFlow1SequenceFlow());
			FlowElements.Add(CreateSequenceFlow2SequenceFlow());
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow1SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow1",
				UId = new Guid("00920ff3-cc66-428f-a197-c73b0fdabf68"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("0eceffe6-2795-439f-b915-118580947959"),
				CurveCenterPosition = new Point(373, 203),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("0eceffe6-2795-439f-b915-118580947959"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("dfb20310-345a-4cff-8ffb-b0bcd8b45909"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("2c97b53d-c716-4254-952b-6c9d5300bc6b"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow2SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow2",
				UId = new Guid("dd952b34-b543-4d41-8d3f-40dc21e3b090"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("f9ecdc95-9cb8-443d-ba94-66f513ca3a49"),
				CreatedInSchemaUId = new Guid("0eceffe6-2795-439f-b915-118580947959"),
				CurveCenterPosition = new Point(416, 196),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("0eceffe6-2795-439f-b915-118580947959"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("2c97b53d-c716-4254-952b-6c9d5300bc6b"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("7b47ad9d-d5fb-40b6-ac42-a7171812ede0"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaLaneSet CreateGCalendarLaneSetLaneSet() {
			ProcessSchemaLaneSet schemaGCalendarLaneSet = new ProcessSchemaLaneSet(this) {
				UId = new Guid("6837e75c-f237-434b-8c69-6044a6fa68de"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 1,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("0eceffe6-2795-439f-b915-118580947959"),
				Direction = ProcessSchemaPoolDirectionType.Vertical,
				DragGroupName = @"LaneSet",
				ManagerItemUId = new Guid("11a47caf-a0d5-41fa-a274-a0b11f77447a"),
				ModifiedInSchemaUId = new Guid("0eceffe6-2795-439f-b915-118580947959"),
				Name = @"GCalendarLaneSet",
				Position = new Point(5, 5),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaGCalendarLaneSet;
		}

		protected virtual ProcessSchemaLane CreateGCalendarLaneLane() {
			ProcessSchemaLane schemaGCalendarLane = new ProcessSchemaLane(this) {
				UId = new Guid("3928caa6-d858-4f5f-8d47-110e6d6ee5df"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 1,
				ContainerUId = new Guid("6837e75c-f237-434b-8c69-6044a6fa68de"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("0eceffe6-2795-439f-b915-118580947959"),
				DragGroupName = @"Lane",
				ManagerItemUId = new Guid("abcd74b9-5912-414b-82ac-f1aa4dcd554e"),
				ModifiedInSchemaUId = new Guid("0eceffe6-2795-439f-b915-118580947959"),
				Name = @"GCalendarLane",
				Position = new Point(29, 0),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaGCalendarLane;
		}

		protected virtual ProcessSchemaStartEvent CreateGCalendarSyncStartStartEvent() {
			ProcessSchemaStartEvent schemaStartEvent = new ProcessSchemaStartEvent(this) {
				UId = new Guid("dfb20310-345a-4cff-8ffb-b0bcd8b45909"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = new Guid("3928caa6-d858-4f5f-8d47-110e6d6ee5df"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("0eceffe6-2795-439f-b915-118580947959"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsInterrupting = false,
				IsLogging = true,
				ManagerItemUId = new Guid("53818048-7868-48f6-ada0-0ebaa65af628"),
				ModifiedInSchemaUId = new Guid("0eceffe6-2795-439f-b915-118580947959"),
				Name = @"GCalendarSyncStart",
				Position = new Point(57, 51),
				SerializeToDB = false,
				Size = new Size(27, 27),
				UseBackgroundMode = false
			};
			
			return schemaStartEvent;
		}

		protected virtual ProcessSchemaEndEvent CreateGCalendarEndEndEvent() {
			ProcessSchemaEndEvent schemaEndEvent = new ProcessSchemaEndEvent(this) {
				UId = new Guid("7b47ad9d-d5fb-40b6-ac42-a7171812ede0"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = new Guid("3928caa6-d858-4f5f-8d47-110e6d6ee5df"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("0eceffe6-2795-439f-b915-118580947959"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsLogging = true,
				ManagerItemUId = new Guid("45ceaae2-4e1f-4c0c-86aa-cd4aeb4da913"),
				ModifiedInSchemaUId = new Guid("0eceffe6-2795-439f-b915-118580947959"),
				Name = @"GCalendarEnd",
				Position = new Point(295, 51),
				SerializeToDB = false,
				Size = new Size(27, 27),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaEndEvent;
		}

		protected virtual ProcessSchemaScriptTask CreateScriptAfterSynchronizationActionsScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("2c97b53d-c716-4254-952b-6c9d5300bc6b"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = new Guid("3928caa6-d858-4f5f-8d47-110e6d6ee5df"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("0eceffe6-2795-439f-b915-118580947959"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("0eceffe6-2795-439f-b915-118580947959"),
				Name = @"ScriptAfterSynchronizationActions",
				Position = new Point(171, 37),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,141,146,209,106,194,64,16,69,159,21,252,135,197,167,8,33,63,96,91,208,168,65,168,69,140,126,192,178,153,198,133,205,172,204,78,172,105,233,191,119,147,218,54,177,90,250,148,236,206,61,115,47,51,123,148,36,114,107,115,3,105,133,106,79,22,245,43,144,184,23,177,145,206,45,164,98,75,85,148,0,223,37,177,52,128,153,164,182,240,33,64,120,17,177,69,199,84,214,218,9,229,101,1,200,193,176,116,64,190,128,160,88,91,28,134,98,215,185,24,141,198,131,62,83,37,222,6,253,222,239,4,81,235,16,212,210,94,125,177,1,87,26,246,233,188,157,198,60,90,88,42,36,7,63,90,89,183,78,203,162,144,84,133,194,83,215,90,79,178,12,178,13,40,75,153,91,226,116,189,178,104,52,66,108,75,228,240,202,52,162,221,33,147,124,27,185,97,51,3,3,127,80,215,140,186,201,146,70,112,86,223,48,185,140,214,97,254,17,170,165,175,167,252,46,148,100,181,23,65,114,129,54,131,157,159,20,28,234,31,1,39,53,106,54,215,217,202,39,180,178,153,126,214,170,33,102,62,220,163,6,183,181,118,33,105,137,219,61,172,165,227,57,145,165,182,93,171,243,149,190,16,173,192,57,153,67,141,12,250,27,40,52,102,126,255,41,208,17,104,199,218,104,246,38,81,76,224,253,190,203,211,106,77,86,121,50,232,62,189,80,40,139,12,39,142,206,245,175,111,170,246,80,200,232,73,22,16,138,159,4,161,192,210,152,80,248,39,14,245,144,8,184,36,108,142,227,15,224,253,28,57,64,3,0,0 }
			};
			
			return ScriptTask;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeUsings() {
			Usings.Add(new SchemaUsing() {
				UId = new Guid("02a2c391-b9e5-458f-97be-5f31bfb34fdd"),
				Name = "Terrasoft.GoogleServices",
				Alias = "",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("d781d71c-c204-4235-b9a7-5e63cc91fa88"),
				Name = "System.Linq",
				Alias = "",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("09812775-15d2-4b28-8dfa-1247c6e09efc"),
				Name = "System.Data",
				Alias = "",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("96fe1089-e710-4448-a36d-026252f860d4"),
				Name = "Terrasoft.Common.Json",
				Alias = "",
				CreatedInPackageId = new Guid("d96ae870-4bfc-40ec-921c-ada84236f3fa")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("03482141-0ed0-4738-9956-3b23bd2b8a52"),
				Name = "Terrasoft.Common",
				Alias = "",
				CreatedInPackageId = new Guid("54856cde-81f7-468d-b20f-cb4c9b5ac12a")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("69ea79be-f47b-4328-9ee9-47ca3fb10939"),
				Name = "Terrasoft.Configuration",
				Alias = "",
				CreatedInPackageId = new Guid("2e3e95a4-2024-4552-b820-30e9633c8933")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("58f026cd-7097-44c3-b0b4-b701d5441970"),
				Name = "Google",
				Alias = "",
				CreatedInPackageId = new Guid("2e3e95a4-2024-4552-b820-30e9633c8933")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("03dd0606-0cb6-4aea-b109-17228eeea122"),
				Name = "System.Net",
				Alias = "",
				CreatedInPackageId = new Guid("2e3e95a4-2024-4552-b820-30e9633c8933")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("9e903017-569a-4c4b-a511-9dd65a193b2f"),
				Name = "Terrasoft.Core.Factories",
				Alias = "",
				CreatedInPackageId = new Guid("2e3e95a4-2024-4552-b820-30e9633c8933")
			});
		}

		#endregion

		#region Methods: Public

		public override Process CreateProcess(UserConnection userConnection) {
			return new GActivitySynchronizationModuleProcess(userConnection);
		}

		public override object Clone() {
			return new GActivitySynchronizationModuleProcessSchema(this);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("0eceffe6-2795-439f-b915-118580947959"));
		}

		#endregion

	}

	#endregion

	#region Class: GActivitySynchronizationModuleProcess

	/// <exclude/>
	public class GActivitySynchronizationModuleProcess : Terrasoft.Core.Process.Process
	{

		#region Class: ProcessGCalendarLane

		/// <exclude/>
		public class ProcessGCalendarLane : ProcessLane
		{

			public ProcessGCalendarLane(UserConnection userConnection, GActivitySynchronizationModuleProcess process)
				: base(userConnection) {
				Owner = process;
				IsUsedParentUserContexts = false;
			}

		}

		#endregion

		public GActivitySynchronizationModuleProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "GActivitySynchronizationModuleProcess";
			SchemaUId = new Guid("0eceffe6-2795-439f-b915-118580947959");
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
				return new Guid("0eceffe6-2795-439f-b915-118580947959");
			}
		}

		private string ConditionalExpressionLogMessage {
			get {
				return "Process: GActivitySynchronizationModuleProcess, Source element: {0}, Conditional flow: {1}, Expression: {2}, Result: {3}";
			}
		}

		private string DeadEndGatewayLogMessage {
			get {
				return "Process: GActivitySynchronizationModuleProcess, Source element: {0}, None of the exclusive gateway conditions are met!";
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

		public virtual string PageInstanceId {
			get;
			set;
		}

		public virtual Guid ActiveTreeGridCurrentRowId {
			get;
			set;
		}

		public virtual Object ModifiedGEntities {
			get;
			set;
		}

		public virtual Object ModifiedBPMEntities {
			get;
			set;
		}

		public virtual DateTime CurrentSyncDateTime {
			get;
			set;
		}

		public virtual Object SyncProvider {
			get;
			set;
		}

		public virtual bool BPMIsAConflictResolver {
			get;
			set;
		}

		private Guid _defActivityCategory = new Guid("2365ae4f-58e6-df11-971b-001d60e938c6");
		public Guid DefActivityCategory {
			get {
				return _defActivityCategory;
			}
			set {
				_defActivityCategory = value;
			}
		}

		public virtual Object ResolvedConflictUIds {
			get;
			set;
		}

		public virtual DateTime LastSyncDate {
			get;
			set;
		}

		public virtual string GoogleAccountName {
			get;
			set;
		}

		public virtual string AccessToken {
			get;
			set;
		}

		public virtual string ActiveTreeGridClientId {
			get;
			set;
		}

		public virtual string SyncResult {
			get;
			set;
		}

		private LocalizableString _synchronizationSummaryLS;
		public virtual LocalizableString SynchronizationSummaryLS {
			get {
				return _synchronizationSummaryLS ?? (_synchronizationSummaryLS = GetLocalizableString("0eceffe62795439fb915118580947959",
						 "Parameters.SynchronizationSummaryLS.Value"));
			}
			set {
				_synchronizationSummaryLS = value;
			}
		}

		private LocalizableString _synchronizationSummary;
		public virtual LocalizableString SynchronizationSummary {
			get {
				return _synchronizationSummary ?? (_synchronizationSummary = GetLocalizableString("0eceffe62795439fb915118580947959",
						 "Parameters.SynchronizationSummary.Value"));
			}
			set {
				_synchronizationSummary = value;
			}
		}

		private LocalizableString _googleModificationDateLiesTooFarInThePastError;
		public virtual LocalizableString GoogleModificationDateLiesTooFarInThePastError {
			get {
				return _googleModificationDateLiesTooFarInThePastError ?? (_googleModificationDateLiesTooFarInThePastError = GetLocalizableString("0eceffe62795439fb915118580947959",
						 "Parameters.GoogleModificationDateLiesTooFarInThePastError.Value"));
			}
			set {
				_googleModificationDateLiesTooFarInThePastError = value;
			}
		}

		public virtual string SenderEmailAddress {
			get;
			set;
		}

		private ProcessGCalendarLane _gCalendarLane;
		public ProcessGCalendarLane GCalendarLane {
			get {
				return _gCalendarLane ?? ((_gCalendarLane) = new ProcessGCalendarLane(UserConnection, this));
			}
		}

		private ProcessFlowElement _gCalendarSyncStart;
		public ProcessFlowElement GCalendarSyncStart {
			get {
				return _gCalendarSyncStart ?? (_gCalendarSyncStart = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartEvent",
					Name = "GCalendarSyncStart",
					SchemaElementUId = new Guid("dfb20310-345a-4cff-8ffb-b0bcd8b45909"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
				});
			}
		}

		private ProcessEndEvent _gCalendarEnd;
		public ProcessEndEvent GCalendarEnd {
			get {
				return _gCalendarEnd ?? (_gCalendarEnd = new ProcessEndEvent() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEndEvent",
					Name = "GCalendarEnd",
					SchemaElementUId = new Guid("7b47ad9d-d5fb-40b6-ac42-a7171812ede0"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
				});
			}
		}

		private ProcessScriptTask _scriptAfterSynchronizationActions;
		public ProcessScriptTask ScriptAfterSynchronizationActions {
			get {
				return _scriptAfterSynchronizationActions ?? (_scriptAfterSynchronizationActions = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ScriptAfterSynchronizationActions",
					SchemaElementUId = new Guid("2c97b53d-c716-4254-952b-6c9d5300bc6b"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = ScriptAfterSynchronizationActionsExecute,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[GCalendarSyncStart.SchemaElementUId] = new Collection<ProcessFlowElement> { GCalendarSyncStart };
			FlowElements[GCalendarEnd.SchemaElementUId] = new Collection<ProcessFlowElement> { GCalendarEnd };
			FlowElements[ScriptAfterSynchronizationActions.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptAfterSynchronizationActions };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "GCalendarSyncStart":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ScriptAfterSynchronizationActions", e.Context.SenderName));
						break;
					case "GCalendarEnd":
						CompleteProcess();
						break;
					case "ScriptAfterSynchronizationActions":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("GCalendarEnd", e.Context.SenderName));
						break;
			}
		}

		private void WritePropertyValues(DataWriter writer, bool useAllValueSources) {
			if (!HasMapping("PageInstanceId")) {
				writer.WriteValue("PageInstanceId", PageInstanceId, null);
			}
			if (!HasMapping("ActiveTreeGridCurrentRowId")) {
				writer.WriteValue("ActiveTreeGridCurrentRowId", ActiveTreeGridCurrentRowId, Guid.Empty);
			}
			if (ModifiedGEntities != null) {
				if (ModifiedGEntities.GetType().IsSerializable ||
					ModifiedGEntities.GetType().GetInterface("ISerializable") != null) {
					WriteSerializableObject(writer, "ModifiedGEntities", ModifiedGEntities, null);
				}
			}
			if (ModifiedBPMEntities != null) {
				if (ModifiedBPMEntities.GetType().IsSerializable ||
					ModifiedBPMEntities.GetType().GetInterface("ISerializable") != null) {
					WriteSerializableObject(writer, "ModifiedBPMEntities", ModifiedBPMEntities, null);
				}
			}
			if (!HasMapping("CurrentSyncDateTime")) {
				writer.WriteValue("CurrentSyncDateTime", CurrentSyncDateTime, DateTime.ParseExact("01.01.0001 0:00", "dd.MM.yyyy H:mm", CultureInfo.InvariantCulture));
			}
			if (SyncProvider != null) {
				if (SyncProvider.GetType().IsSerializable ||
					SyncProvider.GetType().GetInterface("ISerializable") != null) {
					WriteSerializableObject(writer, "SyncProvider", SyncProvider, null);
				}
			}
			if (!HasMapping("BPMIsAConflictResolver")) {
				writer.WriteValue("BPMIsAConflictResolver", BPMIsAConflictResolver, false);
			}
			if (!HasMapping("DefActivityCategory")) {
				writer.WriteValue("DefActivityCategory", DefActivityCategory, Guid.Empty);
			}
			if (ResolvedConflictUIds != null) {
				if (ResolvedConflictUIds.GetType().IsSerializable ||
					ResolvedConflictUIds.GetType().GetInterface("ISerializable") != null) {
					WriteSerializableObject(writer, "ResolvedConflictUIds", ResolvedConflictUIds, null);
				}
			}
			if (!HasMapping("LastSyncDate")) {
				writer.WriteValue("LastSyncDate", LastSyncDate, DateTime.ParseExact("01.01.0001 0:00", "dd.MM.yyyy H:mm", CultureInfo.InvariantCulture));
			}
			if (!HasMapping("GoogleAccountName")) {
				writer.WriteValue("GoogleAccountName", GoogleAccountName, null);
			}
			if (!HasMapping("AccessToken")) {
				writer.WriteValue("AccessToken", AccessToken, null);
			}
			if (!HasMapping("ActiveTreeGridClientId")) {
				writer.WriteValue("ActiveTreeGridClientId", ActiveTreeGridClientId, null);
			}
			if (!HasMapping("SyncResult")) {
				writer.WriteValue("SyncResult", SyncResult, null);
			}
			if (!HasMapping("SenderEmailAddress")) {
				writer.WriteValue("SenderEmailAddress", SenderEmailAddress, null);
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
			context.QueueTasksV2.Enqueue(new ProcessQueueElement("GCalendarSyncStart", string.Empty));
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
			MetaPathParameterValues.Add("6a170f99-0994-46d9-8dd1-983048f8a5da", () => PageInstanceId);
			MetaPathParameterValues.Add("53ff815d-bf48-4c18-92ed-065c25e47d7e", () => ActiveTreeGridCurrentRowId);
			MetaPathParameterValues.Add("b53b4501-8253-47d0-af2f-1e41a8b9cfb2", () => ModifiedGEntities);
			MetaPathParameterValues.Add("3d2a46ec-1719-423b-a9cf-568038f56080", () => ModifiedBPMEntities);
			MetaPathParameterValues.Add("6181b599-3bb7-434a-bd13-b10613943f8f", () => CurrentSyncDateTime);
			MetaPathParameterValues.Add("a3699fdc-c28f-4afe-808f-096cd393ca2e", () => SyncProvider);
			MetaPathParameterValues.Add("41e320fe-fd3e-4926-942f-cc7facb78796", () => BPMIsAConflictResolver);
			MetaPathParameterValues.Add("0ba82835-fceb-4bad-b75d-d52fe03fa461", () => DefActivityCategory);
			MetaPathParameterValues.Add("8d1cdb9f-5c88-40f3-80ba-69dd9d1d9be2", () => ResolvedConflictUIds);
			MetaPathParameterValues.Add("97062d45-0d38-4cee-ba3c-9fece6c0a6f9", () => LastSyncDate);
			MetaPathParameterValues.Add("5b7f83bc-6e12-4a54-b45d-bc3970a3f965", () => GoogleAccountName);
			MetaPathParameterValues.Add("efefea24-99b5-4886-8785-53d0204c42ff", () => AccessToken);
			MetaPathParameterValues.Add("749d5d34-d42d-4f8b-857d-fbc373706b93", () => ActiveTreeGridClientId);
			MetaPathParameterValues.Add("3e8350ee-ed3a-4f83-8ed9-c1084d8f7bb9", () => SyncResult);
			MetaPathParameterValues.Add("e6c70236-656b-4a05-aab8-4b0cdf5536d0", () => SynchronizationSummaryLS);
			MetaPathParameterValues.Add("b4593900-7bc9-44b1-9dff-438141dd5fd1", () => SynchronizationSummary);
			MetaPathParameterValues.Add("4643ae2d-19f0-4db8-860b-87461d18677c", () => GoogleModificationDateLiesTooFarInThePastError);
			MetaPathParameterValues.Add("cffd6276-ceaa-493f-b08a-08dcfc52765a", () => SenderEmailAddress);
		}

		protected override void ApplyPropertiesDataValues(DataReader reader) {
			base.ApplyPropertiesDataValues(reader);
			bool hasValueToRead = reader.HasValue();
			switch (reader.CurrentName) {
				case "PageInstanceId":
					if (!hasValueToRead) break;
					PageInstanceId = reader.GetValue<System.String>();
				break;
				case "ActiveTreeGridCurrentRowId":
					if (!hasValueToRead) break;
					ActiveTreeGridCurrentRowId = reader.GetValue<System.Guid>();
				break;
				case "ModifiedGEntities":
					if (!hasValueToRead) break;
					ModifiedGEntities = GetSerializableObject(reader);
				break;
				case "ModifiedBPMEntities":
					if (!hasValueToRead) break;
					ModifiedBPMEntities = GetSerializableObject(reader);
				break;
				case "CurrentSyncDateTime":
					if (!hasValueToRead) break;
					CurrentSyncDateTime = reader.GetValue<System.DateTime>();
				break;
				case "SyncProvider":
					if (!hasValueToRead) break;
					SyncProvider = GetSerializableObject(reader);
				break;
				case "BPMIsAConflictResolver":
					if (!hasValueToRead) break;
					BPMIsAConflictResolver = reader.GetValue<System.Boolean>();
				break;
				case "DefActivityCategory":
					if (!hasValueToRead) break;
					DefActivityCategory = reader.GetValue<System.Guid>();
				break;
				case "ResolvedConflictUIds":
					if (!hasValueToRead) break;
					ResolvedConflictUIds = GetSerializableObject(reader);
				break;
				case "LastSyncDate":
					if (!hasValueToRead) break;
					LastSyncDate = reader.GetValue<System.DateTime>();
				break;
				case "GoogleAccountName":
					if (!hasValueToRead) break;
					GoogleAccountName = reader.GetValue<System.String>();
				break;
				case "AccessToken":
					if (!hasValueToRead) break;
					AccessToken = reader.GetValue<System.String>();
				break;
				case "ActiveTreeGridClientId":
					if (!hasValueToRead) break;
					ActiveTreeGridClientId = reader.GetValue<System.String>();
				break;
				case "SyncResult":
					if (!hasValueToRead) break;
					SyncResult = reader.GetValue<System.String>();
				break;
				case "SenderEmailAddress":
					if (!hasValueToRead) break;
					SenderEmailAddress = reader.GetValue<System.String>();
				break;
			}
		}

		protected override void WritePropertyValues(DataWriter writer) {
			base.WritePropertyValues(writer);
			WritePropertyValues(writer, true);
		}

		#endregion

		#region Methods: Public

		public virtual bool ScriptAfterSynchronizationActionsExecute(ProcessExecutingContext context) {
			var googleSynchronizer = ClassFactory.Get<GCalendarSynchronizer>(new ConstructorArgument("userConnection", UserConnection));
			try {
				googleSynchronizer.Synchronize();
				SyncResult = string.Format(SynchronizationSummary, 
					googleSynchronizer.AddedRecordsInBPMonlineCount, googleSynchronizer.UpdatedRecordsInBPMonlineCount,
					googleSynchronizer.DeletedRecordsInBPMonlineCount, googleSynchronizer.AddedRecordsInGoogleCount, 
					googleSynchronizer.UpdatedRecordsInGoogleCount, googleSynchronizer.DeletedRecordsInGoogleCount);
			} catch (GoogleSynchronizationException exc) {
				SyncResult = GoogleModificationDateLiesTooFarInThePastError;
			} catch (Exception e) {
				SyncResult = e.Message;
			}
			RemindingServerUtilities.CreateRemindingByProcess(UserConnection, context.Process.ProcessSchema.Name, SyncResult, null, true);
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
			var cloneItem = (GActivitySynchronizationModuleProcess)base.CloneShallow();
			cloneItem.ExecutedEventHandler = ExecutedEventHandler;
			cloneItem.ModifiedGEntities = ModifiedGEntities;
			cloneItem.ModifiedBPMEntities = ModifiedBPMEntities;
			cloneItem.SyncProvider = SyncProvider;
			cloneItem.ResolvedConflictUIds = ResolvedConflictUIds;
			return cloneItem;
		}

		#endregion

	}

	#endregion

}

