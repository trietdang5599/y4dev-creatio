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
	using Terrasoft.Social;

	#region Class: FindUsersInSocialNetworksSchema

	/// <exclude/>
	public class FindUsersInSocialNetworksSchema : Terrasoft.Core.Process.ProcessSchema
	{

		#region Constructors: Public

		public FindUsersInSocialNetworksSchema(ProcessSchemaManager processSchemaManager)
			: base(processSchemaManager) {
		}

		public FindUsersInSocialNetworksSchema(FindUsersInSocialNetworksSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			Name = "FindUsersInSocialNetworks";
			UId = new Guid("6ba7daa7-8f3a-4201-9308-97774cd319fc");
			CreatedInPackageId = new Guid("7f924b56-df05-4eb1-9ff1-3618e0fcf55f");
			CreatedInSchemaUId = Guid.Empty;
			CreatedInVersion = @"8.2.3.1351";
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
			RealUId = new Guid("6ba7daa7-8f3a-4201-9308-97774cd319fc");
			Version = 0;
			PackageUId = new Guid("422cc048-65aa-8f90-e8ed-7fa6d5ab06b1");
			UseSystemSecurityContext = false;
		}

		protected virtual ProcessSchemaParameter CreateSearchCriteriaParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("d2eee179-ad16-455d-8147-63165813c33a"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("6ba7daa7-8f3a-4201-9308-97774cd319fc"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("6ba7daa7-8f3a-4201-9308-97774cd319fc"),
				Name = @"SearchCriteria",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MediumText"),
			};
		}

		protected virtual ProcessSchemaParameter CreateSocialNetworksParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("1418805c-fd9b-4e83-9dfb-3e550995e3e5"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("6ba7daa7-8f3a-4201-9308-97774cd319fc"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("6ba7daa7-8f3a-4201-9308-97774cd319fc"),
				Name = @"SocialNetworks",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MediumText"),
			};
		}

		protected virtual ProcessSchemaParameter CreateSearchResultParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("7adb7cd7-6067-43c1-8295-c7f3eac4a985"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("6ba7daa7-8f3a-4201-9308-97774cd319fc"),
				Direction = ProcessSchemaParameterDirection.Out,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("6ba7daa7-8f3a-4201-9308-97774cd319fc"),
				Name = @"SearchResult",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MaxSizeText"),
			};
		}

		protected virtual ProcessSchemaParameter CreateExceptionNetworksParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("e6c00e48-9350-4fc2-b412-ec33613180d4"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("6ba7daa7-8f3a-4201-9308-97774cd319fc"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("6ba7daa7-8f3a-4201-9308-97774cd319fc"),
				Name = @"ExceptionNetworks",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Object"),
			};
		}

		protected virtual ProcessSchemaParameter CreateAccessTokenExceptionNetworksParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("e6450af3-54ad-4fd0-93ab-2a819e0601d6"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("6ba7daa7-8f3a-4201-9308-97774cd319fc"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("6ba7daa7-8f3a-4201-9308-97774cd319fc"),
				Name = @"AccessTokenExceptionNetworks",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Object"),
			};
		}

		protected override void InitializeParameters() {
			base.InitializeParameters();
			Parameters.Add(CreateSearchCriteriaParameter());
			Parameters.Add(CreateSocialNetworksParameter());
			Parameters.Add(CreateSearchResultParameter());
			Parameters.Add(CreateExceptionNetworksParameter());
			Parameters.Add(CreateAccessTokenExceptionNetworksParameter());
		}

		protected override void InitializeBaseElements() {
			base.InitializeBaseElements();
			ProcessSchemaLaneSet schemaLaneSet1 = CreateLaneSet1LaneSet();
			LaneSets.Add(schemaLaneSet1);
			ProcessSchemaLane schemaLane1 = CreateLane1Lane();
			schemaLaneSet1.Lanes.Add(schemaLane1);
			ProcessSchemaStartEvent startsearchsocialusersmessage = CreateStartSearchSocialUsersMessageStartEvent();
			FlowElements.Add(startsearchsocialusersmessage);
			ProcessSchemaEndEvent endsearchsocialusersmessage = CreateEndSearchSocialUsersMessageEndEvent();
			FlowElements.Add(endsearchsocialusersmessage);
			ProcessSchemaScriptTask searchsocialusersscripttask = CreateSearchSocialUsersScriptTaskScriptTask();
			FlowElements.Add(searchsocialusersscripttask);
			FlowElements.Add(CreateSequenceFlow1SequenceFlow());
			FlowElements.Add(CreateSequenceFlow2SequenceFlow());
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow1SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow1",
				UId = new Guid("9cf9158a-a7a7-4386-9591-2c3988b13e58"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("7f924b56-df05-4eb1-9ff1-3618e0fcf55f"),
				CreatedInSchemaUId = new Guid("6ba7daa7-8f3a-4201-9308-97774cd319fc"),
				CurveCenterPosition = new Point(373, 203),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("6ba7daa7-8f3a-4201-9308-97774cd319fc"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("b2ad761d-b8d0-4e79-9cda-3ad4bbe8ea49"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("ecd6952e-cb98-4f10-ad26-adf801c905b3"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow2SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow2",
				UId = new Guid("fa6dfbb8-7b2c-49c0-9874-fa36ddd43aa1"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("7f924b56-df05-4eb1-9ff1-3618e0fcf55f"),
				CreatedInSchemaUId = new Guid("6ba7daa7-8f3a-4201-9308-97774cd319fc"),
				CurveCenterPosition = new Point(373, 203),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("6ba7daa7-8f3a-4201-9308-97774cd319fc"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("ecd6952e-cb98-4f10-ad26-adf801c905b3"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("4c86d02b-fcb8-49f2-9c13-38f0a0574809"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaLaneSet CreateLaneSet1LaneSet() {
			ProcessSchemaLaneSet schemaLaneSet1 = new ProcessSchemaLaneSet(this) {
				UId = new Guid("4df67273-36a7-4d16-8308-63da81a4189f"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 1,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("7f924b56-df05-4eb1-9ff1-3618e0fcf55f"),
				CreatedInSchemaUId = new Guid("6ba7daa7-8f3a-4201-9308-97774cd319fc"),
				Direction = ProcessSchemaPoolDirectionType.Vertical,
				DragGroupName = @"LaneSet",
				ManagerItemUId = new Guid("11a47caf-a0d5-41fa-a274-a0b11f77447a"),
				ModifiedInSchemaUId = new Guid("6ba7daa7-8f3a-4201-9308-97774cd319fc"),
				Name = @"LaneSet1",
				Position = new Point(5, 5),
				Size = new Size(513, 400),
				UseBackgroundMode = false
			};
			return schemaLaneSet1;
		}

		protected virtual ProcessSchemaLane CreateLane1Lane() {
			ProcessSchemaLane schemaLane1 = new ProcessSchemaLane(this) {
				UId = new Guid("24844802-3984-48cd-a11e-d042fed29ec6"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 1,
				ContainerUId = new Guid("4df67273-36a7-4d16-8308-63da81a4189f"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("7f924b56-df05-4eb1-9ff1-3618e0fcf55f"),
				CreatedInSchemaUId = new Guid("6ba7daa7-8f3a-4201-9308-97774cd319fc"),
				DragGroupName = @"Lane",
				ManagerItemUId = new Guid("abcd74b9-5912-414b-82ac-f1aa4dcd554e"),
				ModifiedInSchemaUId = new Guid("6ba7daa7-8f3a-4201-9308-97774cd319fc"),
				Name = @"Lane1",
				Position = new Point(29, 0),
				Size = new Size(484, 400),
				UseBackgroundMode = false
			};
			return schemaLane1;
		}

		protected virtual ProcessSchemaStartEvent CreateStartSearchSocialUsersMessageStartEvent() {
			ProcessSchemaStartEvent schemaStartEvent = new ProcessSchemaStartEvent(this) {
				UId = new Guid("b2ad761d-b8d0-4e79-9cda-3ad4bbe8ea49"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = new Guid("24844802-3984-48cd-a11e-d042fed29ec6"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("7f924b56-df05-4eb1-9ff1-3618e0fcf55f"),
				CreatedInSchemaUId = new Guid("6ba7daa7-8f3a-4201-9308-97774cd319fc"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsInterrupting = false,
				IsLogging = false,
				ManagerItemUId = new Guid("53818048-7868-48f6-ada0-0ebaa65af628"),
				ModifiedInSchemaUId = new Guid("6ba7daa7-8f3a-4201-9308-97774cd319fc"),
				Name = @"StartSearchSocialUsersMessage",
				Position = new Point(141, 184),
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			
			return schemaStartEvent;
		}

		protected virtual ProcessSchemaEndEvent CreateEndSearchSocialUsersMessageEndEvent() {
			ProcessSchemaEndEvent schemaEndEvent = new ProcessSchemaEndEvent(this) {
				UId = new Guid("4c86d02b-fcb8-49f2-9c13-38f0a0574809"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = new Guid("24844802-3984-48cd-a11e-d042fed29ec6"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("7f924b56-df05-4eb1-9ff1-3618e0fcf55f"),
				CreatedInSchemaUId = new Guid("6ba7daa7-8f3a-4201-9308-97774cd319fc"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsLogging = false,
				ManagerItemUId = new Guid("45ceaae2-4e1f-4c0c-86aa-cd4aeb4da913"),
				ModifiedInSchemaUId = new Guid("6ba7daa7-8f3a-4201-9308-97774cd319fc"),
				Name = @"EndSearchSocialUsersMessage",
				Position = new Point(442, 184),
				SerializeToDB = false,
				Size = new Size(0, 0),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaEndEvent;
		}

		protected virtual ProcessSchemaScriptTask CreateSearchSocialUsersScriptTaskScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("ecd6952e-cb98-4f10-ad26-adf801c905b3"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = new Guid("24844802-3984-48cd-a11e-d042fed29ec6"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("7f924b56-df05-4eb1-9ff1-3618e0fcf55f"),
				CreatedInSchemaUId = new Guid("6ba7daa7-8f3a-4201-9308-97774cd319fc"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = false,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("6ba7daa7-8f3a-4201-9308-97774cd319fc"),
				Name = @"SearchSocialUsersScriptTask",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(239, 170),
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,141,83,77,79,2,49,16,61,67,194,127,24,185,208,141,155,141,122,196,112,48,4,19,61,128,17,253,1,181,12,88,237,182,100,218,21,112,221,255,110,247,3,100,249,146,83,147,233,235,123,111,166,111,228,20,152,117,36,245,44,122,176,195,68,169,17,13,226,185,91,177,49,114,18,239,125,146,14,73,242,32,128,180,213,108,16,186,132,52,56,74,240,182,213,204,90,205,177,17,146,171,33,186,133,161,79,208,213,217,131,90,61,186,83,202,195,229,148,93,28,150,218,6,219,74,234,143,171,126,31,12,116,18,71,79,156,44,50,183,154,163,153,238,220,135,117,113,27,22,118,131,210,239,23,39,16,38,142,19,199,157,33,79,174,113,81,225,251,155,50,123,181,72,125,163,53,10,39,141,14,215,125,229,28,131,165,192,121,94,93,211,239,53,59,52,58,31,206,157,16,104,237,139,249,68,125,246,155,63,103,209,230,205,72,136,132,8,39,112,217,131,9,42,156,113,135,236,97,103,238,33,108,240,128,229,252,164,255,88,4,105,161,102,100,46,61,85,9,104,252,227,112,103,172,39,209,63,185,22,63,168,21,213,104,124,147,141,12,80,89,111,109,109,176,6,216,112,87,38,207,112,118,220,206,17,230,163,150,10,69,247,78,102,1,88,148,125,102,110,203,208,36,62,18,185,246,163,53,218,71,227,11,201,69,227,124,51,148,252,198,209,219,135,143,10,219,250,190,123,169,39,121,138,236,222,30,121,190,178,244,140,54,81,206,83,86,59,113,111,40,230,142,181,211,180,208,234,66,122,149,133,192,183,39,186,110,176,219,73,175,179,78,8,184,172,55,238,235,55,89,39,203,218,97,233,55,132,83,191,22,189,152,113,33,205,130,173,252,28,184,205,61,215,55,255,23,173,126,63,242,54,4,0,0 }
			};
			
			return ScriptTask;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeUsings() {
			Usings.Add(new SchemaUsing() {
				UId = new Guid("3853e2c8-0670-4b9e-a285-37e84b65b4b1"),
				Name = "Terrasoft.Social",
				Alias = "",
				CreatedInPackageId = new Guid("7f924b56-df05-4eb1-9ff1-3618e0fcf55f")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("fbf2b1fd-1ae8-4544-8b6d-968bafccf538"),
				Name = "Newtonsoft.Json",
				Alias = "",
				CreatedInPackageId = new Guid("7f924b56-df05-4eb1-9ff1-3618e0fcf55f")
			});
		}

		#endregion

		#region Methods: Public

		public override Process CreateProcess(UserConnection userConnection) {
			return new FindUsersInSocialNetworks(userConnection);
		}

		public override object Clone() {
			return new FindUsersInSocialNetworksSchema(this);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("6ba7daa7-8f3a-4201-9308-97774cd319fc"));
		}

		#endregion

	}

	#endregion

	#region Class: FindUsersInSocialNetworks

	/// <exclude/>
	public class FindUsersInSocialNetworks : Terrasoft.Core.Process.Process
	{

		#region Class: ProcessLane1

		/// <exclude/>
		public class ProcessLane1 : ProcessLane
		{

			public ProcessLane1(UserConnection userConnection, FindUsersInSocialNetworks process)
				: base(userConnection) {
				Owner = process;
				IsUsedParentUserContexts = false;
			}

		}

		#endregion

		public FindUsersInSocialNetworks(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "FindUsersInSocialNetworks";
			SchemaUId = new Guid("6ba7daa7-8f3a-4201-9308-97774cd319fc");
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
				return new Guid("6ba7daa7-8f3a-4201-9308-97774cd319fc");
			}
		}

		private string ConditionalExpressionLogMessage {
			get {
				return "Process: FindUsersInSocialNetworks, Source element: {0}, Conditional flow: {1}, Expression: {2}, Result: {3}";
			}
		}

		private string DeadEndGatewayLogMessage {
			get {
				return "Process: FindUsersInSocialNetworks, Source element: {0}, None of the exclusive gateway conditions are met!";
			}
		}

		#endregion

		#region Properties: Public

		public virtual string SearchCriteria {
			get;
			set;
		}

		public virtual string SocialNetworks {
			get;
			set;
		}

		public virtual string SearchResult {
			get;
			set;
		}

		public virtual Object ExceptionNetworks {
			get;
			set;
		}

		public virtual Object AccessTokenExceptionNetworks {
			get;
			set;
		}

		private ProcessLane1 _lane1;
		public ProcessLane1 Lane1 {
			get {
				return _lane1 ?? ((_lane1) = new ProcessLane1(UserConnection, this));
			}
		}

		private ProcessFlowElement _startSearchSocialUsersMessage;
		public ProcessFlowElement StartSearchSocialUsersMessage {
			get {
				return _startSearchSocialUsersMessage ?? (_startSearchSocialUsersMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartEvent",
					Name = "StartSearchSocialUsersMessage",
					SchemaElementUId = new Guid("b2ad761d-b8d0-4e79-9cda-3ad4bbe8ea49"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessEndEvent _endSearchSocialUsersMessage;
		public ProcessEndEvent EndSearchSocialUsersMessage {
			get {
				return _endSearchSocialUsersMessage ?? (_endSearchSocialUsersMessage = new ProcessEndEvent() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEndEvent",
					Name = "EndSearchSocialUsersMessage",
					SchemaElementUId = new Guid("4c86d02b-fcb8-49f2-9c13-38f0a0574809"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _searchSocialUsersScriptTask;
		public ProcessScriptTask SearchSocialUsersScriptTask {
			get {
				return _searchSocialUsersScriptTask ?? (_searchSocialUsersScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "SearchSocialUsersScriptTask",
					SchemaElementUId = new Guid("ecd6952e-cb98-4f10-ad26-adf801c905b3"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					Script = SearchSocialUsersScriptTaskExecute,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[StartSearchSocialUsersMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { StartSearchSocialUsersMessage };
			FlowElements[EndSearchSocialUsersMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { EndSearchSocialUsersMessage };
			FlowElements[SearchSocialUsersScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { SearchSocialUsersScriptTask };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "StartSearchSocialUsersMessage":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("SearchSocialUsersScriptTask", e.Context.SenderName));
						break;
					case "EndSearchSocialUsersMessage":
						CompleteProcess();
						break;
					case "SearchSocialUsersScriptTask":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("EndSearchSocialUsersMessage", e.Context.SenderName));
						break;
			}
		}

		private void WritePropertyValues(DataWriter writer, bool useAllValueSources) {
			if (!HasMapping("SearchCriteria")) {
				writer.WriteValue("SearchCriteria", SearchCriteria, null);
			}
			if (!HasMapping("SocialNetworks")) {
				writer.WriteValue("SocialNetworks", SocialNetworks, null);
			}
			if (!HasMapping("SearchResult")) {
				writer.WriteValue("SearchResult", SearchResult, null);
			}
			if (ExceptionNetworks != null) {
				if (ExceptionNetworks.GetType().IsSerializable ||
					ExceptionNetworks.GetType().GetInterface("ISerializable") != null) {
					WriteSerializableObject(writer, "ExceptionNetworks", ExceptionNetworks, null);
				}
			}
			if (AccessTokenExceptionNetworks != null) {
				if (AccessTokenExceptionNetworks.GetType().IsSerializable ||
					AccessTokenExceptionNetworks.GetType().GetInterface("ISerializable") != null) {
					WriteSerializableObject(writer, "AccessTokenExceptionNetworks", AccessTokenExceptionNetworks, null);
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
			context.QueueTasksV2.Enqueue(new ProcessQueueElement("StartSearchSocialUsersMessage", string.Empty));
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
			MetaPathParameterValues.Add("d2eee179-ad16-455d-8147-63165813c33a", () => SearchCriteria);
			MetaPathParameterValues.Add("1418805c-fd9b-4e83-9dfb-3e550995e3e5", () => SocialNetworks);
			MetaPathParameterValues.Add("7adb7cd7-6067-43c1-8295-c7f3eac4a985", () => SearchResult);
			MetaPathParameterValues.Add("e6c00e48-9350-4fc2-b412-ec33613180d4", () => ExceptionNetworks);
			MetaPathParameterValues.Add("e6450af3-54ad-4fd0-93ab-2a819e0601d6", () => AccessTokenExceptionNetworks);
		}

		protected override void ApplyPropertiesDataValues(DataReader reader) {
			base.ApplyPropertiesDataValues(reader);
			bool hasValueToRead = reader.HasValue();
			switch (reader.CurrentName) {
				case "SearchCriteria":
					if (!hasValueToRead) break;
					SearchCriteria = reader.GetValue<System.String>();
				break;
				case "SocialNetworks":
					if (!hasValueToRead) break;
					SocialNetworks = reader.GetValue<System.String>();
				break;
				case "SearchResult":
					if (!hasValueToRead) break;
					SearchResult = reader.GetValue<System.String>();
				break;
				case "ExceptionNetworks":
					if (!hasValueToRead) break;
					ExceptionNetworks = GetSerializableObject(reader);
				break;
				case "AccessTokenExceptionNetworks":
					if (!hasValueToRead) break;
					AccessTokenExceptionNetworks = GetSerializableObject(reader);
				break;
			}
		}

		protected override void WritePropertyValues(DataWriter writer) {
			base.WritePropertyValues(writer);
			WritePropertyValues(writer, true);
		}

		#endregion

		#region Methods: Public

		public virtual bool SearchSocialUsersScriptTaskExecute(ProcessExecutingContext context) {
			if (string.IsNullOrEmpty(SearchCriteria)) {
				return true;
			}
			SocialNetwork network = SocialNetwork.All;
			if(!string.IsNullOrEmpty(SocialNetworks)) {
				network = (SocialNetwork)Enum.Parse(typeof(SocialNetwork), SocialNetworks, true);
			}
			var commutator = new SocialCommutator(UserConnection, network);
			ExceptionNetworks = SocialNetwork.None;
			AccessTokenExceptionNetworks = SocialNetwork.None;
			commutator.ExceptionOccurred += delegate(ISocialNetwork n, Exception e) {
				if (e is AccessTokenExpired) {
					AccessTokenExceptionNetworks = (SocialNetwork)AccessTokenExceptionNetworks | (e as AccessTokenExpired).SocialNetwork;
				} else if (e is SocialNetworkException) {
					ExceptionNetworks = (SocialNetwork)ExceptionNetworks | (e as SocialNetworkException).SocialNetwork;
				} else {
					throw e;
				}
			};
			var users = JsonConvert.SerializeObject(commutator.FindUsers(SearchCriteria));
			SearchResult = string.Format("{{users: {0}, accessTokenExNetworks:'{1}', exeptionNetworks:'{2}'}}", users, AccessTokenExceptionNetworks.ToString(), ExceptionNetworks.ToString());
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
			var cloneItem = (FindUsersInSocialNetworks)base.CloneShallow();
			cloneItem.ExecutedEventHandler = ExecutedEventHandler;
			cloneItem.ExceptionNetworks = ExceptionNetworks;
			cloneItem.AccessTokenExceptionNetworks = AccessTokenExceptionNetworks;
			return cloneItem;
		}

		#endregion

	}

	#endregion

}

