namespace Terrasoft.Core.Process
{

	using IntegrationApi.Interfaces;
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
	using Terrasoft.Core.Factories;
	using Terrasoft.Core.Process;
	using Terrasoft.Core.Process.Configuration;
	using Terrasoft.Mail;

	#region Class: SyncImapMailSchema

	/// <exclude/>
	public class SyncImapMailSchema : Terrasoft.Core.Process.ProcessSchema
	{

		#region Constructors: Public

		public SyncImapMailSchema(ProcessSchemaManager processSchemaManager)
			: base(processSchemaManager) {
		}

		public SyncImapMailSchema(SyncImapMailSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			Name = "SyncImapMail";
			UId = new Guid("237dd150-53cf-4801-bd72-d517975107f8");
			BackgroundModePriority = BackgroundModePriority.Medium;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
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
			TaskFillDefColor = Color.FromArgb(-1);
			UsageType = ProcessSchemaUsageType.Advanced;
			ZipMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,83,0,0,69,207,108,233,1,0,0,0 };
			ZipCompiledMethodsBody = new byte[] {  };
			RealUId = new Guid("237dd150-53cf-4801-bd72-d517975107f8");
			Version = 0;
			PackageUId = new Guid("06d9ef10-51d8-122c-8933-9212e84236c9");
			UseSystemSecurityContext = false;
		}

		protected virtual ProcessSchemaParameter CreatePageInstanceIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("a54165a0-7744-4599-95de-a742bd292b40"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("237dd150-53cf-4801-bd72-d517975107f8"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("237dd150-53cf-4801-bd72-d517975107f8"),
				Name = @"PageInstanceId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Text"),
			};
		}

		protected virtual ProcessSchemaParameter CreateActiveTreeGridCurrentRowIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("57e04ecc-eb57-43da-bb56-54c46c31c8d3"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("237dd150-53cf-4801-bd72-d517975107f8"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("237dd150-53cf-4801-bd72-d517975107f8"),
				Name = @"ActiveTreeGridCurrentRowId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid"),
			};
		}

		protected virtual ProcessSchemaParameter CreateMailUserNameParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("97325781-b945-49f7-8732-c6cfdd3aebc1"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("237dd150-53cf-4801-bd72-d517975107f8"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("237dd150-53cf-4801-bd72-d517975107f8"),
				Name = @"MailUserName",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LongText"),
			};
		}

		protected virtual ProcessSchemaParameter CreateSenderEmailAddressParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("5cda26a9-50cc-4292-9c8a-84b7533a2e06"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("237dd150-53cf-4801-bd72-d517975107f8"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("237dd150-53cf-4801-bd72-d517975107f8"),
				Name = @"SenderEmailAddress",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MediumText"),
			};
		}

		protected virtual ProcessSchemaParameter CreateCurrentUserIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("294c50f3-a39f-4a40-a91e-58e6766978b9"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("237dd150-53cf-4801-bd72-d517975107f8"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("237dd150-53cf-4801-bd72-d517975107f8"),
				Name = @"CurrentUserId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid"),
			};
		}

		protected virtual ProcessSchemaParameter CreateLoadEmailsFromDateParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("ed3fa5d3-4777-4bfb-95e1-e80decf6e0a9"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("237dd150-53cf-4801-bd72-d517975107f8"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("237dd150-53cf-4801-bd72-d517975107f8"),
				Name = @"LoadEmailsFromDate",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("DateTime"),
			};
		}

		protected virtual ProcessSchemaParameter CreateCreateRemindingParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("7f27c14c-c3e5-4e1c-9b16-b0f669ff0e28"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("237dd150-53cf-4801-bd72-d517975107f8"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("237dd150-53cf-4801-bd72-d517975107f8"),
				Name = @"CreateReminding",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean"),
			};
		}

		protected override void InitializeParameters() {
			base.InitializeParameters();
			Parameters.Add(CreatePageInstanceIdParameter());
			Parameters.Add(CreateActiveTreeGridCurrentRowIdParameter());
			Parameters.Add(CreateMailUserNameParameter());
			Parameters.Add(CreateSenderEmailAddressParameter());
			Parameters.Add(CreateCurrentUserIdParameter());
			Parameters.Add(CreateLoadEmailsFromDateParameter());
			Parameters.Add(CreateCreateRemindingParameter());
		}

		protected override void InitializeBaseElements() {
			base.InitializeBaseElements();
			ProcessSchemaLaneSet schemaLaneSet1 = CreateLaneSet1LaneSet();
			LaneSets.Add(schemaLaneSet1);
			ProcessSchemaLane schemaLane1 = CreateLane1Lane();
			schemaLaneSet1.Lanes.Add(schemaLane1);
			ProcessSchemaStartEvent start1 = CreateStart1StartEvent();
			FlowElements.Add(start1);
			ProcessSchemaEndEvent end1 = CreateEnd1EndEvent();
			FlowElements.Add(end1);
			ProcessSchemaScriptTask scripttask1 = CreateScriptTask1ScriptTask();
			FlowElements.Add(scripttask1);
			FlowElements.Add(CreateSequenceFlow1SequenceFlow());
			FlowElements.Add(CreateSequenceFlow2SequenceFlow());
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow1SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow1",
				UId = new Guid("adfc9151-77b2-4fe4-a87b-92ae60725da1"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("237dd150-53cf-4801-bd72-d517975107f8"),
				CurveCenterPosition = new Point(373, 199),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("237dd150-53cf-4801-bd72-d517975107f8"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("1edb1620-1236-4a0a-91ef-2612ae3a0993"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("8727a659-1a61-4eec-87bc-f4e360329497"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow2SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow2",
				UId = new Guid("1910142d-434b-41cb-9592-e2c24eee63bd"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("237dd150-53cf-4801-bd72-d517975107f8"),
				CurveCenterPosition = new Point(373, 199),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("237dd150-53cf-4801-bd72-d517975107f8"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("9ac7eaae-3d0b-4972-89fe-e58baaedcc67"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("1edb1620-1236-4a0a-91ef-2612ae3a0993"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaLaneSet CreateLaneSet1LaneSet() {
			ProcessSchemaLaneSet schemaLaneSet1 = new ProcessSchemaLaneSet(this) {
				UId = new Guid("5d241632-5559-4887-b0c1-a279e8a744cf"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 1,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("237dd150-53cf-4801-bd72-d517975107f8"),
				Direction = ProcessSchemaPoolDirectionType.Vertical,
				DragGroupName = @"LaneSet",
				ManagerItemUId = new Guid("11a47caf-a0d5-41fa-a274-a0b11f77447a"),
				ModifiedInSchemaUId = new Guid("237dd150-53cf-4801-bd72-d517975107f8"),
				Name = @"LaneSet1",
				Position = new Point(5, 5),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLaneSet1;
		}

		protected virtual ProcessSchemaLane CreateLane1Lane() {
			ProcessSchemaLane schemaLane1 = new ProcessSchemaLane(this) {
				UId = new Guid("13ec4d62-a0e8-4c2f-8f8a-cfefd74363e3"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 1,
				ContainerUId = new Guid("5d241632-5559-4887-b0c1-a279e8a744cf"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("237dd150-53cf-4801-bd72-d517975107f8"),
				DragGroupName = @"Lane",
				ManagerItemUId = new Guid("abcd74b9-5912-414b-82ac-f1aa4dcd554e"),
				ModifiedInSchemaUId = new Guid("237dd150-53cf-4801-bd72-d517975107f8"),
				Name = @"Lane1",
				Position = new Point(29, 0),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLane1;
		}

		protected virtual ProcessSchemaStartEvent CreateStart1StartEvent() {
			ProcessSchemaStartEvent schemaStartEvent = new ProcessSchemaStartEvent(this) {
				UId = new Guid("9ac7eaae-3d0b-4972-89fe-e58baaedcc67"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = new Guid("13ec4d62-a0e8-4c2f-8f8a-cfefd74363e3"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("237dd150-53cf-4801-bd72-d517975107f8"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsInterrupting = false,
				IsLogging = true,
				ManagerItemUId = new Guid("53818048-7868-48f6-ada0-0ebaa65af628"),
				ModifiedInSchemaUId = new Guid("237dd150-53cf-4801-bd72-d517975107f8"),
				Name = @"Start1",
				Position = new Point(57, 44),
				SerializeToDB = false,
				Size = new Size(27, 27),
				UseBackgroundMode = false
			};
			
			return schemaStartEvent;
		}

		protected virtual ProcessSchemaEndEvent CreateEnd1EndEvent() {
			ProcessSchemaEndEvent schemaEndEvent = new ProcessSchemaEndEvent(this) {
				UId = new Guid("8727a659-1a61-4eec-87bc-f4e360329497"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = new Guid("13ec4d62-a0e8-4c2f-8f8a-cfefd74363e3"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("237dd150-53cf-4801-bd72-d517975107f8"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsLogging = true,
				ManagerItemUId = new Guid("45ceaae2-4e1f-4c0c-86aa-cd4aeb4da913"),
				ModifiedInSchemaUId = new Guid("237dd150-53cf-4801-bd72-d517975107f8"),
				Name = @"End1",
				Position = new Point(246, 44),
				SerializeToDB = false,
				Size = new Size(27, 27),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaEndEvent;
		}

		protected virtual ProcessSchemaScriptTask CreateScriptTask1ScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("1edb1620-1236-4a0a-91ef-2612ae3a0993"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = new Guid("13ec4d62-a0e8-4c2f-8f8a-cfefd74363e3"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("237dd150-53cf-4801-bd72-d517975107f8"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("237dd150-53cf-4801-bd72-d517975107f8"),
				Name = @"ScriptTask1",
				Position = new Point(134, 30),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,181,86,77,111,219,56,16,61,187,64,255,3,163,94,100,192,85,187,217,180,135,77,227,133,107,59,93,45,154,143,70,110,123,92,208,210,36,225,130,34,93,146,138,163,45,242,223,59,36,101,75,150,173,109,93,52,64,96,196,228,204,123,51,143,195,71,63,99,215,228,224,124,58,75,102,163,243,201,232,106,114,248,207,75,242,226,5,153,93,76,46,200,248,234,236,249,209,225,171,163,215,228,233,147,59,170,136,134,180,80,48,131,123,67,78,8,249,168,65,141,165,16,144,26,38,69,52,161,134,126,162,188,128,89,185,128,51,42,232,13,168,232,29,152,88,104,67,69,10,111,203,115,154,67,24,36,107,144,160,79,168,38,245,247,13,132,99,79,137,123,10,132,177,92,113,134,172,227,141,239,7,39,228,93,193,178,104,154,47,76,73,254,108,237,254,209,46,177,177,29,197,25,50,76,133,97,166,76,210,91,200,233,135,2,84,73,190,184,207,19,34,96,73,182,118,195,22,94,51,160,234,120,128,82,245,122,193,25,101,124,46,239,147,82,164,9,24,195,196,141,14,250,72,232,224,163,81,150,141,37,47,114,17,6,22,209,234,210,189,123,73,181,94,74,149,237,142,176,68,9,168,59,236,8,87,21,232,14,158,70,220,165,84,230,187,65,200,156,36,239,191,27,22,235,196,80,101,102,188,131,54,1,145,129,154,230,152,177,93,222,41,227,6,148,182,241,161,95,25,43,160,6,252,250,103,102,110,47,169,66,109,108,80,232,23,199,50,95,80,197,180,20,118,70,162,233,151,130,114,39,121,144,148,122,148,229,76,124,20,204,224,225,6,131,205,209,233,63,18,109,83,127,206,229,210,181,58,145,75,193,37,205,240,216,177,14,163,10,120,44,250,169,160,115,14,174,136,82,220,42,41,216,127,212,142,230,35,211,238,56,214,1,217,94,116,244,222,56,56,94,25,188,86,158,25,93,33,113,43,187,110,149,205,65,18,219,19,86,152,225,9,50,202,53,73,27,255,251,235,217,138,8,109,98,161,81,115,18,90,206,108,62,189,71,107,49,82,97,252,214,197,213,232,57,147,183,245,82,216,239,147,175,216,90,3,0,229,193,126,48,217,87,31,121,56,184,114,203,97,13,95,101,246,208,72,195,3,159,20,217,160,21,100,175,103,209,22,107,117,171,242,39,204,17,83,85,190,209,70,33,235,128,200,249,191,72,52,172,178,122,95,201,143,10,77,30,6,235,148,13,15,108,95,3,242,224,226,30,142,215,117,105,116,175,172,224,174,209,49,71,175,57,165,41,54,229,14,233,205,12,148,162,90,94,155,200,138,29,197,113,78,23,214,211,254,150,243,100,149,55,116,194,35,218,26,9,187,207,229,29,84,129,173,227,29,52,148,168,18,13,14,238,210,105,50,82,55,69,142,197,78,239,83,88,184,99,9,10,204,38,153,4,77,132,52,228,150,222,1,177,141,19,154,166,178,16,222,200,176,33,251,209,24,145,104,229,171,216,85,117,36,216,143,119,37,247,196,84,154,15,195,122,215,61,79,47,251,30,208,111,19,69,151,43,255,221,23,233,183,10,201,143,69,141,131,158,121,94,112,126,161,220,163,85,15,73,187,250,6,111,253,238,90,116,199,122,42,213,123,116,152,45,113,27,68,253,104,38,19,87,91,216,33,210,95,82,155,125,219,58,172,218,106,226,216,23,165,19,135,9,179,5,242,251,14,16,251,226,104,222,9,51,151,146,111,225,28,237,192,89,61,72,251,33,189,218,133,180,125,207,246,20,235,181,71,69,225,241,239,25,194,177,235,167,79,220,64,180,12,201,254,78,210,167,232,199,120,206,222,211,179,48,184,224,153,35,143,133,129,27,229,125,189,26,151,159,114,148,125,252,196,86,125,92,17,253,42,139,248,73,131,112,37,184,31,82,90,227,254,174,34,226,164,222,31,134,129,107,5,27,179,162,32,48,138,81,216,216,149,187,160,169,164,184,219,122,118,156,131,118,102,232,61,94,188,94,163,90,63,142,190,127,5,120,188,194,61,204,199,126,34,126,228,183,247,198,163,198,42,117,255,79,139,120,51,102,24,34,117,183,18,27,34,236,86,165,51,185,113,89,236,67,83,127,235,87,99,218,42,55,178,255,219,242,236,168,56,77,26,215,162,169,206,55,248,124,82,191,149,12,0,0 }
			};
			
			return ScriptTask;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeUsings() {
			Usings.Add(new SchemaUsing() {
				UId = new Guid("699b2038-adc5-418a-bdd1-d4d0f094a7b3"),
				Name = "Terrasoft.Mail",
				Alias = "",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("2a014b6d-9ec5-48df-a642-6190afc95cc5"),
				Name = "Terrasoft.Core",
				Alias = "",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("d3124134-245b-4f52-9d71-d7d3dc858b19"),
				Name = "Terrasoft.Core.Entities",
				Alias = "",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("8ebced27-c4ad-4322-bdc4-d34ece6c78e1"),
				Name = "Terrasoft.Configuration",
				Alias = "",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("fb1fe6c6-00d9-494f-a471-a3a73bc90279"),
				Name = "Terrasoft.Core.Factories",
				Alias = "",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("411c2ea8-1b30-46ea-8e80-a814bd7b2e00"),
				Name = "IntegrationApi.Interfaces",
				Alias = "",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			});
		}

		#endregion

		#region Methods: Public

		public override Process CreateProcess(UserConnection userConnection) {
			return new SyncImapMail(userConnection);
		}

		public override object Clone() {
			return new SyncImapMailSchema(this);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("237dd150-53cf-4801-bd72-d517975107f8"));
		}

		#endregion

	}

	#endregion

	#region Class: SyncImapMailMethodsWrapper

	/// <exclude/>
	public class SyncImapMailMethodsWrapper : ProcessModel
	{

		public SyncImapMailMethodsWrapper(Process process)
			: base(process) {
		}

		#region Methods: Private

			 

		#endregion

	}

	#endregion

	#region Class: SyncImapMail

	/// <exclude/>
	public class SyncImapMail : Terrasoft.Core.Process.Process
	{

		#region Class: ProcessLane1

		/// <exclude/>
		public class ProcessLane1 : ProcessLane
		{

			public ProcessLane1(UserConnection userConnection, SyncImapMail process)
				: base(userConnection) {
				Owner = process;
				IsUsedParentUserContexts = false;
			}

		}

		#endregion

		public SyncImapMail(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SyncImapMail";
			SchemaUId = new Guid("237dd150-53cf-4801-bd72-d517975107f8");
			Caption = Schema.Caption;
			SchemaManagerName = "ProcessSchemaManager";
			SerializeToDB = false;
			SerializeToMemory = true;
			IsLogging = false;
			UseSystemSecurityContext = false;
			_notificationCaption = () => { return new LocalizableString((Caption)); };
			ProcessModel = new SyncImapMailMethodsWrapper(this);
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("237dd150-53cf-4801-bd72-d517975107f8");
			}
		}

		private string ConditionalExpressionLogMessage {
			get {
				return "Process: SyncImapMail, Source element: {0}, Conditional flow: {1}, Expression: {2}, Result: {3}";
			}
		}

		private string DeadEndGatewayLogMessage {
			get {
				return "Process: SyncImapMail, Source element: {0}, None of the exclusive gateway conditions are met!";
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

		public virtual string MailUserName {
			get;
			set;
		}

		public virtual string SenderEmailAddress {
			get;
			set;
		}

		public virtual Guid CurrentUserId {
			get;
			set;
		}

		public virtual DateTime LoadEmailsFromDate {
			get;
			set;
		}

		public virtual bool CreateReminding {
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
					SchemaElementUId = new Guid("9ac7eaae-3d0b-4972-89fe-e58baaedcc67"),
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
					SchemaElementUId = new Guid("8727a659-1a61-4eec-87bc-f4e360329497"),
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
					SchemaElementUId = new Guid("1edb1620-1236-4a0a-91ef-2612ae3a0993"),
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
			if (!HasMapping("PageInstanceId")) {
				writer.WriteValue("PageInstanceId", PageInstanceId, null);
			}
			if (!HasMapping("ActiveTreeGridCurrentRowId")) {
				writer.WriteValue("ActiveTreeGridCurrentRowId", ActiveTreeGridCurrentRowId, Guid.Empty);
			}
			if (!HasMapping("MailUserName")) {
				writer.WriteValue("MailUserName", MailUserName, null);
			}
			if (!HasMapping("SenderEmailAddress")) {
				writer.WriteValue("SenderEmailAddress", SenderEmailAddress, null);
			}
			if (!HasMapping("CurrentUserId")) {
				writer.WriteValue("CurrentUserId", CurrentUserId, Guid.Empty);
			}
			if (!HasMapping("LoadEmailsFromDate")) {
				writer.WriteValue("LoadEmailsFromDate", LoadEmailsFromDate, DateTime.ParseExact("01.01.0001 0:00", "dd.MM.yyyy H:mm", CultureInfo.InvariantCulture));
			}
			if (!HasMapping("CreateReminding")) {
				writer.WriteValue("CreateReminding", CreateReminding, false);
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
			MetaPathParameterValues.Add("a54165a0-7744-4599-95de-a742bd292b40", () => PageInstanceId);
			MetaPathParameterValues.Add("57e04ecc-eb57-43da-bb56-54c46c31c8d3", () => ActiveTreeGridCurrentRowId);
			MetaPathParameterValues.Add("97325781-b945-49f7-8732-c6cfdd3aebc1", () => MailUserName);
			MetaPathParameterValues.Add("5cda26a9-50cc-4292-9c8a-84b7533a2e06", () => SenderEmailAddress);
			MetaPathParameterValues.Add("294c50f3-a39f-4a40-a91e-58e6766978b9", () => CurrentUserId);
			MetaPathParameterValues.Add("ed3fa5d3-4777-4bfb-95e1-e80decf6e0a9", () => LoadEmailsFromDate);
			MetaPathParameterValues.Add("7f27c14c-c3e5-4e1c-9b16-b0f669ff0e28", () => CreateReminding);
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
				case "MailUserName":
					if (!hasValueToRead) break;
					MailUserName = reader.GetValue<System.String>();
				break;
				case "SenderEmailAddress":
					if (!hasValueToRead) break;
					SenderEmailAddress = reader.GetValue<System.String>();
				break;
				case "CurrentUserId":
					if (!hasValueToRead) break;
					CurrentUserId = reader.GetValue<System.Guid>();
				break;
				case "LoadEmailsFromDate":
					if (!hasValueToRead) break;
					LoadEmailsFromDate = reader.GetValue<System.DateTime>();
				break;
				case "CreateReminding":
					if (!hasValueToRead) break;
					CreateReminding = reader.GetValue<System.Boolean>();
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
			#if !NETSTANDARD2_0 // TODO CRM-42546 
			var secureText =  UserConnection.DataValueTypeManager.GetInstanceByName("SecureText") as SecureTextDataValueType;
			var currentUserId = CurrentUserId != Guid.Empty ? CurrentUserId : UserConnection.CurrentUser.Id;
			EntitySchemaQuery query = new EntitySchemaQuery(UserConnection.EntitySchemaManager, 
					"MailboxSyncSettings");
			query.AddColumn("UserName");
			query.AddColumn("UserPassword");
			query.AddColumn("MailServer.Address");
			query.AddColumn("MailServer.Port");
			query.AddColumn("MailServer.UseSSL");
			query.AddColumn("MailServer.IsStartTls");
			query.AddColumn("SenderEmailAddress");
			query.Filters.Add(query.CreateFilterWithParameters(FilterComparisonType.Equal, 
				"SysAdminUnit.Id", currentUserId));
			query.Filters.Add(query.CreateFilterWithParameters(FilterComparisonType.Equal, 
				"MailServer.AllowEmailDownloading", true));
			query.Filters.Add(query.CreateFilterWithParameters(FilterComparisonType.Equal, 
				"EnableMailSynhronization", true));
			query.Filters.Add(query.CreateFilterWithParameters(FilterComparisonType.Equal, 
				"SenderEmailAddress", SenderEmailAddress));
			var select = query.GetSelectQuery(UserConnection);
			 
			MailCredentials credentials = new MailCredentials();
			using (var dbExecutor = UserConnection.EnsureDBConnection()) {
				using (var reader = select.ExecuteReader(dbExecutor)) {
					if (!reader.Read()) {
						var parameters = new Dictionary<string, object> {
							{ "SenderEmailAddress", SenderEmailAddress },
							{ "CurrentUserId", currentUserId }
						};
						var scheduler = ClassFactory.Get<Terrasoft.Mail.IImapSyncJobScheduler>();
						scheduler.RemoveSyncJob(UserConnection, parameters);
						throw new ArgumentException("user does not have mail account");
					}
					credentials.UserName = reader.GetColumnValue<string>(reader.GetName(0));
					string rawPassword = reader.GetColumnValue<string>(reader.GetName(1));
					if (!rawPassword.IsNullOrEmpty()) {
						credentials.UserPassword = secureText.GetValueForLoad(UserConnection, rawPassword).ToString();
					}
					credentials.Host = reader.GetColumnValue<string>(reader.GetName(2));
					credentials.Port = reader.GetColumnValue<int>(reader.GetName(3));
					credentials.UseSsl = reader.GetColumnValue<bool>(reader.GetName(4));
					credentials.StartTls = reader.GetColumnValue<bool>(reader.GetName(5));
					credentials.SenderEmailAddress = reader.GetColumnValue<string>(reader.GetName(6));
				}
			}
			#endif
			if (!UserConnection.GetIsFeatureEnabled("OldEmailIntegration")) {
				var parameters = new Dictionary<string, object> {
					{ "SenderEmailAddress", SenderEmailAddress }
				};
				var scheduler = ClassFactory.Get<Terrasoft.Mail.IImapSyncJobScheduler>();
				scheduler.RemoveSyncJob(UserConnection, parameters);
				var syncSession = ClassFactory.Get<ISyncSession>("Email", new ConstructorArgument("uc", UserConnection),
					new ConstructorArgument("senderEmailAddress", SenderEmailAddress));
				syncSession.Start();
				return true;
			}
			#if !NETSTANDARD2_0 // TODO CRM-42546
			using (var imapSyncSession = ClassFactory.Get<IImapSyncSession>(
				new ConstructorArgument("userConnection", UserConnection),
				new ConstructorArgument("credentials", credentials))) {
				imapSyncSession.SyncImapMail();
			}
			#endif
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
			var cloneItem = (SyncImapMail)base.CloneShallow();
			cloneItem.ExecutedEventHandler = ExecutedEventHandler;
			return cloneItem;
		}

		#endregion

	}

	#endregion

}

