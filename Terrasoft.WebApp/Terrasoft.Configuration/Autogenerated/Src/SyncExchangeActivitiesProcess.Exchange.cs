namespace Terrasoft.Core.Process
{

	using IntegrationApi.Interfaces;
	using IntegrationApi.MailboxDomain;
	using IntegrationApi.MailboxDomain.Interfaces;
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
	using Terrasoft.Configuration;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Factories;
	using Terrasoft.Core.Process;
	using Terrasoft.Core.Process.Configuration;
	using Terrasoft.EmailDomain;
	using Terrasoft.Sync;
	using Terrasoft.Sync.Exchange;

	#region Class: SyncExchangeActivitiesProcessSchema

	/// <exclude/>
	public class SyncExchangeActivitiesProcessSchema : Terrasoft.Core.Process.ProcessSchema
	{

		#region Constructors: Public

		public SyncExchangeActivitiesProcessSchema(ProcessSchemaManager processSchemaManager)
			: base(processSchemaManager) {
		}

		public SyncExchangeActivitiesProcessSchema(SyncExchangeActivitiesProcessSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			Name = "SyncExchangeActivitiesProcess";
			UId = new Guid("e5873837-7f4e-4bce-93c3-0179fb72eb6a");
			CreatedInPackageId = new Guid("3033db6d-23fb-435c-94e5-8f4806c46ba3");
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
			SerializeToMemory = false;
			Tag = @"Business Process";
			TaskFillDefColor = Color.FromArgb(-1);
			UsageType = ProcessSchemaUsageType.Advanced;
			ZipMethodsBody = new byte[] {  };
			ZipCompiledMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,205,87,75,111,34,71,16,62,19,41,255,161,220,138,86,131,22,161,68,81,114,176,99,71,44,198,27,36,63,86,102,173,28,66,14,13,83,192,200,61,211,163,238,30,88,194,206,127,79,117,207,224,121,98,67,146,67,228,131,161,187,250,171,231,87,85,196,201,76,4,115,88,7,202,36,92,192,90,6,62,76,182,209,124,165,100,20,252,133,94,23,118,223,126,211,185,149,203,107,156,37,75,239,59,86,186,4,252,50,95,241,104,137,192,231,38,88,7,38,64,13,218,112,101,208,135,133,84,176,155,96,228,163,26,133,60,16,3,223,87,168,117,202,186,23,4,184,230,10,236,233,76,126,153,160,90,7,115,132,75,24,10,174,245,13,97,73,181,237,127,68,243,203,248,174,34,114,229,69,184,129,161,140,180,81,137,149,26,168,101,18,98,100,60,150,204,89,15,158,52,42,186,141,144,172,145,81,183,174,136,52,84,85,90,29,185,134,15,219,166,169,94,243,168,7,11,46,52,58,228,96,1,222,89,14,216,31,242,136,180,143,242,120,12,178,112,108,109,172,188,110,22,194,83,98,184,9,132,128,25,130,126,14,226,24,253,30,125,158,243,68,99,107,64,33,208,16,73,83,0,153,109,140,253,44,204,29,133,38,81,145,253,152,230,38,55,17,250,99,125,159,8,241,64,135,177,217,254,19,123,81,41,155,237,123,68,127,130,198,166,161,154,237,206,141,84,33,55,143,168,19,97,188,166,88,155,173,54,113,43,20,49,42,202,155,205,251,40,50,121,72,115,83,212,111,238,218,115,175,51,209,254,80,32,87,77,73,175,86,26,246,197,62,89,79,38,16,36,222,191,70,129,6,93,12,246,249,187,81,50,44,231,242,0,92,15,246,66,174,54,117,255,51,215,207,159,41,11,79,99,63,43,149,200,0,143,99,73,255,109,185,222,202,57,23,67,167,92,15,101,18,153,94,249,246,17,67,105,176,124,109,33,168,228,131,104,89,149,179,209,188,163,240,241,165,101,79,38,209,119,14,92,28,195,217,2,234,88,214,218,250,169,186,110,41,52,214,55,200,41,117,56,138,248,76,160,239,177,123,220,220,33,26,50,103,28,25,92,42,110,69,89,75,97,145,32,4,97,44,149,57,210,2,87,22,154,220,153,208,25,129,182,118,141,73,113,127,229,177,33,23,132,198,21,53,136,211,219,71,167,164,171,63,177,38,102,229,150,2,10,203,71,43,82,47,36,171,126,127,54,54,24,234,70,185,180,53,22,139,212,161,118,123,121,213,244,232,3,47,122,139,69,255,164,228,58,32,4,242,238,165,229,20,217,44,75,176,158,195,237,28,246,188,98,90,51,10,111,189,215,13,87,88,155,127,221,28,72,38,230,96,13,247,160,118,219,194,147,198,251,58,87,242,64,214,115,82,102,49,197,102,78,26,239,121,152,53,242,52,103,168,33,214,182,168,180,199,175,114,50,19,120,157,140,182,108,3,253,81,241,120,117,87,159,70,25,135,220,221,32,14,242,107,175,91,60,27,109,180,237,40,214,246,129,16,114,67,44,185,132,179,210,107,202,217,195,32,49,43,175,107,157,255,250,21,206,142,97,233,117,160,237,167,135,197,130,102,225,143,63,255,84,82,83,208,253,172,102,245,187,119,173,6,29,57,51,108,168,142,109,54,255,13,175,254,37,173,246,110,254,239,248,244,54,142,177,253,215,190,142,104,184,151,249,215,168,215,140,86,7,202,191,120,209,160,218,233,76,43,117,77,215,200,105,191,121,68,174,93,31,175,22,154,195,254,21,152,59,131,193,167,241,158,45,180,110,248,210,45,60,58,137,221,228,176,214,185,153,144,149,155,27,54,96,232,75,178,92,193,193,68,58,5,231,192,178,242,7,170,127,24,253,62,105,7,163,13,203,207,200,226,195,108,11,175,16,7,22,25,201,216,197,9,116,200,182,188,131,116,56,135,93,17,168,52,223,236,210,162,255,168,114,46,237,157,170,53,163,67,13,247,133,227,121,183,170,238,129,141,50,217,207,239,42,252,251,75,96,23,192,224,125,179,174,202,107,103,187,14,213,134,95,138,218,168,237,7,70,45,57,25,198,107,209,171,104,105,93,73,171,118,180,108,163,167,44,195,100,194,27,189,141,16,237,95,220,242,219,171,98,86,158,224,48,183,203,133,167,45,233,197,192,201,158,123,108,183,155,178,103,220,78,217,57,76,217,238,251,116,74,125,96,202,114,160,252,244,7,58,77,211,30,115,35,179,109,37,9,139,120,220,74,238,103,70,181,233,34,180,220,18,109,177,255,32,133,127,66,154,18,114,35,176,233,33,199,95,34,220,230,116,189,201,144,112,63,147,14,43,208,127,3,45,113,112,0,206,14,0,0 };
			RealUId = new Guid("e5873837-7f4e-4bce-93c3-0179fb72eb6a");
			Version = 0;
			PackageUId = new Guid("b8c22230-2173-426f-959e-be736709a63f");
			UseSystemSecurityContext = false;
		}

		protected virtual ProcessSchemaParameter CreateSenderEmailAddressParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("1706a8e4-a8db-40dd-bcfe-70083813c584"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("e5873837-7f4e-4bce-93c3-0179fb72eb6a"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("e5873837-7f4e-4bce-93c3-0179fb72eb6a"),
				Name = @"SenderEmailAddress",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MediumText"),
			};
		}

		protected virtual ProcessSchemaParameter CreateLoadResultParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("f363e086-ca54-4a07-b6a4-f2d793380738"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("e5873837-7f4e-4bce-93c3-0179fb72eb6a"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("e5873837-7f4e-4bce-93c3-0179fb72eb6a"),
				Name = @"LoadResult",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MaxSizeText"),
			};
		}

		protected virtual ProcessSchemaParameter CreateCreateRemindingParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("f4f43cc4-e123-4ce2-9acd-20ddaba5c641"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("e5873837-7f4e-4bce-93c3-0179fb72eb6a"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("e5873837-7f4e-4bce-93c3-0179fb72eb6a"),
				Name = @"CreateReminding",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean"),
			};
		}

		protected virtual ProcessSchemaParameter CreateNeedSetUserAddressParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("264bbae8-6f36-4dcf-94e7-82abf4ec9e24"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("3033db6d-23fb-435c-94e5-8f4806c46ba3"),
				CreatedInSchemaUId = new Guid("e5873837-7f4e-4bce-93c3-0179fb72eb6a"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("e5873837-7f4e-4bce-93c3-0179fb72eb6a"),
				Name = @"NeedSetUserAddress",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LocalizableStringDataValueType"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.ConstValue,
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("e5873837-7f4e-4bce-93c3-0179fb72eb6a"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateSyncActivitySuccessMessageParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("d17b41bd-be12-494e-934a-ba442230f54f"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("3033db6d-23fb-435c-94e5-8f4806c46ba3"),
				CreatedInSchemaUId = new Guid("e5873837-7f4e-4bce-93c3-0179fb72eb6a"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("e5873837-7f4e-4bce-93c3-0179fb72eb6a"),
				Name = @"SyncActivitySuccessMessage",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LocalizableStringDataValueType"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.ConstValue,
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("e5873837-7f4e-4bce-93c3-0179fb72eb6a"),
				},
			};
		}

		protected override void InitializeParameters() {
			base.InitializeParameters();
			Parameters.Add(CreateSenderEmailAddressParameter());
			Parameters.Add(CreateLoadResultParameter());
			Parameters.Add(CreateCreateRemindingParameter());
			Parameters.Add(CreateNeedSetUserAddressParameter());
			Parameters.Add(CreateSyncActivitySuccessMessageParameter());
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
				UId = new Guid("41f16446-2ae5-4ea4-ac7d-30b3c1e71a02"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("3033db6d-23fb-435c-94e5-8f4806c46ba3"),
				CreatedInSchemaUId = new Guid("e5873837-7f4e-4bce-93c3-0179fb72eb6a"),
				CurveCenterPosition = new Point(373, 203),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("e5873837-7f4e-4bce-93c3-0179fb72eb6a"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("01fff802-295f-4649-9bca-a1af184a280f"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("143c11fd-593c-4449-b58c-0f5cf0393adb"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow2SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow2",
				UId = new Guid("e4a99538-e8d9-4f6d-a8d2-c4de8277151e"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("3033db6d-23fb-435c-94e5-8f4806c46ba3"),
				CreatedInSchemaUId = new Guid("e5873837-7f4e-4bce-93c3-0179fb72eb6a"),
				CurveCenterPosition = new Point(373, 203),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("e5873837-7f4e-4bce-93c3-0179fb72eb6a"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("143c11fd-593c-4449-b58c-0f5cf0393adb"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("49cf4a4b-4e8c-49da-a7bb-669368c326fc"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaLaneSet CreateLaneSet1LaneSet() {
			ProcessSchemaLaneSet schemaLaneSet1 = new ProcessSchemaLaneSet(this) {
				UId = new Guid("9fc02540-1342-4ae4-bf1f-3768b697dea1"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 1,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("3033db6d-23fb-435c-94e5-8f4806c46ba3"),
				CreatedInSchemaUId = new Guid("e5873837-7f4e-4bce-93c3-0179fb72eb6a"),
				Direction = ProcessSchemaPoolDirectionType.Vertical,
				DragGroupName = @"LaneSet",
				ManagerItemUId = new Guid("11a47caf-a0d5-41fa-a274-a0b11f77447a"),
				ModifiedInSchemaUId = new Guid("e5873837-7f4e-4bce-93c3-0179fb72eb6a"),
				Name = @"LaneSet1",
				Position = new Point(5, 5),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLaneSet1;
		}

		protected virtual ProcessSchemaLane CreateLane1Lane() {
			ProcessSchemaLane schemaLane1 = new ProcessSchemaLane(this) {
				UId = new Guid("0744a239-2513-49f9-b6fa-459d7ee83ba3"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 1,
				ContainerUId = new Guid("9fc02540-1342-4ae4-bf1f-3768b697dea1"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("3033db6d-23fb-435c-94e5-8f4806c46ba3"),
				CreatedInSchemaUId = new Guid("e5873837-7f4e-4bce-93c3-0179fb72eb6a"),
				DragGroupName = @"Lane",
				ManagerItemUId = new Guid("abcd74b9-5912-414b-82ac-f1aa4dcd554e"),
				ModifiedInSchemaUId = new Guid("e5873837-7f4e-4bce-93c3-0179fb72eb6a"),
				Name = @"Lane1",
				Position = new Point(29, 0),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLane1;
		}

		protected virtual ProcessSchemaStartEvent CreateStart1StartEvent() {
			ProcessSchemaStartEvent schemaStartEvent = new ProcessSchemaStartEvent(this) {
				UId = new Guid("01fff802-295f-4649-9bca-a1af184a280f"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = new Guid("0744a239-2513-49f9-b6fa-459d7ee83ba3"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("3033db6d-23fb-435c-94e5-8f4806c46ba3"),
				CreatedInSchemaUId = new Guid("e5873837-7f4e-4bce-93c3-0179fb72eb6a"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsInterrupting = false,
				IsLogging = true,
				ManagerItemUId = new Guid("53818048-7868-48f6-ada0-0ebaa65af628"),
				ModifiedInSchemaUId = new Guid("e5873837-7f4e-4bce-93c3-0179fb72eb6a"),
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
				UId = new Guid("49cf4a4b-4e8c-49da-a7bb-669368c326fc"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = new Guid("0744a239-2513-49f9-b6fa-459d7ee83ba3"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("3033db6d-23fb-435c-94e5-8f4806c46ba3"),
				CreatedInSchemaUId = new Guid("e5873837-7f4e-4bce-93c3-0179fb72eb6a"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsLogging = true,
				ManagerItemUId = new Guid("1bd93619-0574-454e-bb4e-cf53b9eb9470"),
				ModifiedInSchemaUId = new Guid("e5873837-7f4e-4bce-93c3-0179fb72eb6a"),
				Name = @"Terminate1",
				Position = new Point(600, 184),
				SerializeToDB = false,
				Size = new Size(27, 27),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaTerminateEvent;
		}

		protected virtual ProcessSchemaScriptTask CreateMainScriptTaskScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("143c11fd-593c-4449-b58c-0f5cf0393adb"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = new Guid("0744a239-2513-49f9-b6fa-459d7ee83ba3"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("3033db6d-23fb-435c-94e5-8f4806c46ba3"),
				CreatedInSchemaUId = new Guid("e5873837-7f4e-4bce-93c3-0179fb72eb6a"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("e5873837-7f4e-4bce-93c3-0179fb72eb6a"),
				Name = @"MainScriptTask",
				Position = new Point(295, 170),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,11,174,204,75,206,40,202,207,203,172,74,213,208,180,230,229,42,74,45,41,45,202,83,40,41,42,77,181,6,0,209,75,113,44,28,0,0,0 }
			};
			
			return ScriptTask;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeUsings() {
			Usings.Add(new SchemaUsing() {
				UId = new Guid("ccf59d5b-a728-418e-9389-ed5f74140b3b"),
				Name = "Terrasoft.Sync.Exchange",
				Alias = "",
				CreatedInPackageId = new Guid("3033db6d-23fb-435c-94e5-8f4806c46ba3")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("e1699d33-d81c-428e-ab95-b9519e811946"),
				Name = "Terrasoft.Sync",
				Alias = "",
				CreatedInPackageId = new Guid("3033db6d-23fb-435c-94e5-8f4806c46ba3")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("2cc2de4d-4a49-4023-84e0-87f513f606fd"),
				Name = "System.Linq",
				Alias = "",
				CreatedInPackageId = new Guid("3033db6d-23fb-435c-94e5-8f4806c46ba3")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("7d06a26f-7484-42fa-a34a-a289a78da842"),
				Name = "System.Collections.Generic",
				Alias = "",
				CreatedInPackageId = new Guid("3033db6d-23fb-435c-94e5-8f4806c46ba3")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("7835e741-23c7-4f92-bfad-db3d847fa2ad"),
				Name = "Terrasoft.Configuration",
				Alias = "",
				CreatedInPackageId = new Guid("3033db6d-23fb-435c-94e5-8f4806c46ba3")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("c25553c6-8f82-4df6-aa2e-7aa7bdef3c27"),
				Name = "Terrasoft.Common",
				Alias = "",
				CreatedInPackageId = new Guid("405cd56e-8293-41da-83e9-a9cf9867a065")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("23df5e27-0cfa-4ef6-b0b4-19e72992cfcc"),
				Name = "Terrasoft.Core.Factories",
				Alias = "",
				CreatedInPackageId = new Guid("3033db6d-23fb-435c-94e5-8f4806c46ba3")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("43f3a715-af06-427b-b896-54d69dab34cd"),
				Name = "IntegrationApi.Interfaces",
				Alias = "",
				CreatedInPackageId = new Guid("3033db6d-23fb-435c-94e5-8f4806c46ba3")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("a99de5b7-18c7-49cc-b244-09677b2ee5bf"),
				Name = "IntegrationApi.MailboxDomain.Interfaces",
				Alias = "",
				CreatedInPackageId = new Guid("3033db6d-23fb-435c-94e5-8f4806c46ba3")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("a338592b-d544-4317-b131-b73481f40bba"),
				Name = "Terrasoft.EmailDomain",
				Alias = "",
				CreatedInPackageId = new Guid("3033db6d-23fb-435c-94e5-8f4806c46ba3")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("68d27e4c-f0a9-4285-b949-c3ce049a40d8"),
				Name = "IntegrationApi.MailboxDomain",
				Alias = "",
				CreatedInPackageId = new Guid("3033db6d-23fb-435c-94e5-8f4806c46ba3")
			});
		}

		#endregion

		#region Methods: Public

		public override Process CreateProcess(UserConnection userConnection) {
			return new SyncExchangeActivitiesProcess(userConnection);
		}

		public override object Clone() {
			return new SyncExchangeActivitiesProcessSchema(this);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("e5873837-7f4e-4bce-93c3-0179fb72eb6a"));
		}

		#endregion

	}

	#endregion

	#region Class: SyncExchangeActivitiesProcess

	/// <exclude/>
	public class SyncExchangeActivitiesProcess : Terrasoft.Core.Process.Process
	{

		#region Class: ProcessLane1

		/// <exclude/>
		public class ProcessLane1 : ProcessLane
		{

			public ProcessLane1(UserConnection userConnection, SyncExchangeActivitiesProcess process)
				: base(userConnection) {
				Owner = process;
				IsUsedParentUserContexts = false;
			}

		}

		#endregion

		public SyncExchangeActivitiesProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SyncExchangeActivitiesProcess";
			SchemaUId = new Guid("e5873837-7f4e-4bce-93c3-0179fb72eb6a");
			Caption = Schema.Caption;
			SchemaManagerName = "ProcessSchemaManager";
			SerializeToDB = false;
			SerializeToMemory = false;
			IsLogging = false;
			UseSystemSecurityContext = false;
			_notificationCaption = () => { return new LocalizableString((Caption)); };
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("e5873837-7f4e-4bce-93c3-0179fb72eb6a");
			}
		}

		private string ConditionalExpressionLogMessage {
			get {
				return "Process: SyncExchangeActivitiesProcess, Source element: {0}, Conditional flow: {1}, Expression: {2}, Result: {3}";
			}
		}

		private string DeadEndGatewayLogMessage {
			get {
				return "Process: SyncExchangeActivitiesProcess, Source element: {0}, None of the exclusive gateway conditions are met!";
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

		public virtual string SenderEmailAddress {
			get;
			set;
		}

		public virtual string LoadResult {
			get;
			set;
		}

		public virtual bool CreateReminding {
			get;
			set;
		}

		private LocalizableString _needSetUserAddress;
		public virtual LocalizableString NeedSetUserAddress {
			get {
				return _needSetUserAddress ?? (_needSetUserAddress = GetLocalizableString("e58738377f4e4bce93c30179fb72eb6a",
						 "Parameters.NeedSetUserAddress.Value"));
			}
			set {
				_needSetUserAddress = value;
			}
		}

		private LocalizableString _syncActivitySuccessMessage;
		public virtual LocalizableString SyncActivitySuccessMessage {
			get {
				return _syncActivitySuccessMessage ?? (_syncActivitySuccessMessage = GetLocalizableString("e58738377f4e4bce93c30179fb72eb6a",
						 "Parameters.SyncActivitySuccessMessage.Value"));
			}
			set {
				_syncActivitySuccessMessage = value;
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
					SchemaElementUId = new Guid("01fff802-295f-4649-9bca-a1af184a280f"),
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
					SchemaElementUId = new Guid("49cf4a4b-4e8c-49da-a7bb-669368c326fc"),
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
					SchemaElementUId = new Guid("143c11fd-593c-4449-b58c-0f5cf0393adb"),
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
			if (!HasMapping("SenderEmailAddress")) {
				writer.WriteValue("SenderEmailAddress", SenderEmailAddress, null);
			}
			if (!HasMapping("LoadResult")) {
				writer.WriteValue("LoadResult", LoadResult, null);
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
			MetaPathParameterValues.Add("1706a8e4-a8db-40dd-bcfe-70083813c584", () => SenderEmailAddress);
			MetaPathParameterValues.Add("f363e086-ca54-4a07-b6a4-f2d793380738", () => LoadResult);
			MetaPathParameterValues.Add("f4f43cc4-e123-4ce2-9acd-20ddaba5c641", () => CreateReminding);
			MetaPathParameterValues.Add("264bbae8-6f36-4dcf-94e7-82abf4ec9e24", () => NeedSetUserAddress);
			MetaPathParameterValues.Add("d17b41bd-be12-494e-934a-ba442230f54f", () => SyncActivitySuccessMessage);
		}

		protected override void ApplyPropertiesDataValues(DataReader reader) {
			base.ApplyPropertiesDataValues(reader);
			bool hasValueToRead = reader.HasValue();
			switch (reader.CurrentName) {
				case "SenderEmailAddress":
					if (!hasValueToRead) break;
					SenderEmailAddress = reader.GetValue<System.String>();
				break;
				case "LoadResult":
					if (!hasValueToRead) break;
					LoadResult = reader.GetValue<System.String>();
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

		public virtual bool MainScriptTaskExecute(ProcessExecutingContext context) {
			Synchronize();
			return true;
		}

			public virtual void Synchronize() {
				LogDebug($"Synchronize exchange activities started for {SenderEmailAddress}");
				var mailboxService = ClassFactory.Get<IMailboxService>(new ConstructorArgument("uc", UserConnection));
				var mailbox = mailboxService.GetMailboxBySenderEmailAddress(SenderEmailAddress, false);
				if (!mailbox.CanUseExchangeActivitySync()) {
					LogDebug($"Synchronize exchange activities will be skipped, because {SenderEmailAddress} is not exchange type.");
					return;
				}
				if (SenderEmailAddress.IsNullOrEmpty()) {
					LogDebug($"Synchronize exchange activities error {NeedSetUserAddress}");
					FormatResult(NeedSetUserAddress);
					return;
				}
				var helper = new EntitySynchronizerHelper();
				helper.ClearEntitySynchronizer(UserConnection);
				ExchangeUtility.DeleteEmptyActivityFromActivitySynchronizer(UserConnection, ActivityConsts.TaskTypeUId);
				int appointmentLocalChangesCount, appointmentRemoteChangesCount;
				string appointmentResultMessage = string.Empty;
				LogDebug($"Synchronize exchange appointments started for {SenderEmailAddress}");
				if (UserConnection.GetIsFeatureEnabled("NewMeetingIntegration")) {
					LogDebug($"New import started for {SenderEmailAddress}");
					var syncSession = ClassFactory.Get<ISyncSession>("Calendar", new ConstructorArgument("uc", UserConnection));
					syncSession.Start();
				} else {
					ExchangeUtility.SyncExchangeItems(UserConnection, SenderEmailAddress, 
						() => ClassFactory.Get<BaseExchangeSyncProvider>("ExchangeAppointmentSyncProvider",
							new ConstructorArgument("userConnection", UserConnection),
							new ConstructorArgument("senderEmailAddress", SenderEmailAddress)),
						out appointmentResultMessage, out appointmentLocalChangesCount, out appointmentRemoteChangesCount, 
						ExchangeUtility.ActivitySyncProcessName);
				}
				int taskLocalChangesCount, taskRemoteChangesCount;
				string taskResultMessage = string.Empty;
				var isGraphMailbox = mailbox.GetIsGraphApiMailbox();
				var isEwsTaskSyncAllowed = !mailbox.GetUseOAuth()
					|| !UserConnection.GetIsFeatureEnabled("DisableOffice365EwsTaskSync");
				if (!isGraphMailbox && isEwsTaskSyncAllowed) {
					LogDebug($"Synchronize exchange tasks started for {SenderEmailAddress}");
					ExchangeUtility.SyncExchangeItems(UserConnection, SenderEmailAddress,
						() => ClassFactory.Get<BaseExchangeSyncProvider>("ExchangeTaskSyncProvider",
							new ConstructorArgument("userConnection", UserConnection),
							new ConstructorArgument("senderEmailAddress", SenderEmailAddress),
							new ConstructorArgument("settings", null)),
						out taskResultMessage, out taskLocalChangesCount, out taskRemoteChangesCount,
						ExchangeUtility.ActivitySyncProcessName);
				} else {
					var skipReason = isGraphMailbox
						? "Graph API mailboxes do not support task synchronization through ExchangeTaskSyncProvider"
						: "Office 365 EWS task synchronization is disabled by DisableOffice365EwsTaskSync feature";
					LogDebug($"Synchronize exchange tasks skipped for {SenderEmailAddress}: {skipReason}.");
				}
				string resultMessage;
				resultMessage = appointmentResultMessage;
				if (!string.IsNullOrEmpty(taskResultMessage)) {
					resultMessage += "; " + taskResultMessage;
				}
				if (!string.IsNullOrEmpty(resultMessage)) {
					LogDebug($"Exchange activities synchronization result for {SenderEmailAddress}: {resultMessage}");
					FormatResult(resultMessage);
					return;
				}
				LogDebug($"Synchronize exchange activities ended for {SenderEmailAddress}");
			}
			
			
			public virtual void FormatResult(string message) {
				string resultMessage = string.Format("{{\"key\": \"{0}\", \"message\": \"{1}\"}},", 
				SenderEmailAddress, message);
			LoadResult = string.Format("{{ \"Messages\": [{0}] }}", resultMessage);
			}
			
			public virtual void LogDebug(string message) {
				ExchangeUtility.Log.Debug(message);
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
			var cloneItem = (SyncExchangeActivitiesProcess)base.CloneShallow();
			cloneItem.ExecutedEventHandler = ExecutedEventHandler;
			return cloneItem;
		}

		#endregion

	}

	#endregion

}

