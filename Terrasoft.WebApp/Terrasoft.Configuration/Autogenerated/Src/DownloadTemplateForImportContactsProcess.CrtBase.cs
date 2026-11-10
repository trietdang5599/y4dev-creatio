namespace Terrasoft.Core.Process
{

	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Drawing;
	using System.Globalization;
	using System.IO;
	using System.Text;
	using System.Web;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Process;
	using Terrasoft.Core.Process.Configuration;
	using TSConfiguration = Terrasoft.Configuration;

	#region Class: DownloadTemplateForImportContactsProcessSchema

	/// <exclude/>
	public class DownloadTemplateForImportContactsProcessSchema : Terrasoft.Core.Process.ProcessSchema
	{

		#region Constructors: Public

		public DownloadTemplateForImportContactsProcessSchema(ProcessSchemaManager processSchemaManager)
			: base(processSchemaManager) {
		}

		public DownloadTemplateForImportContactsProcessSchema(DownloadTemplateForImportContactsProcessSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			Name = "DownloadTemplateForImportContactsProcess";
			UId = new Guid("85309378-d6ac-8d35-bf60-cb315df85ea9");
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
			ZipCompiledMethodsBody = new byte[] {  };
			RealUId = new Guid("85309378-d6ac-8d35-bf60-cb315df85ea9");
			Version = 0;
			PackageUId = new Guid("06d9ef10-51d8-122c-8933-9212e84236c9");
			UseSystemSecurityContext = false;
		}

		protected virtual ProcessSchemaParameter CreatePageInstanceIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("07ee176b-7bb7-40cf-9ffa-4bf954aeb744"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("85309378-d6ac-8d35-bf60-cb315df85ea9"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("85309378-d6ac-8d35-bf60-cb315df85ea9"),
				Name = @"PageInstanceId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Text"),
			};
		}

		protected virtual ProcessSchemaParameter CreateActiveTreeGridCurrentRowIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("a6b7b324-3872-4592-919e-2430c72143e7"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("85309378-d6ac-8d35-bf60-cb315df85ea9"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("85309378-d6ac-8d35-bf60-cb315df85ea9"),
				Name = @"ActiveTreeGridCurrentRowId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid"),
			};
		}

		protected virtual ProcessSchemaParameter CreateFileNameParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("97cb0249-71ed-4b15-83ba-ff9002d7f88c"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("85309378-d6ac-8d35-bf60-cb315df85ea9"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("85309378-d6ac-8d35-bf60-cb315df85ea9"),
				Name = @"FileName",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LocalizableStringDataValueType"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.ConstValue,
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("85309378-d6ac-8d35-bf60-cb315df85ea9"),
				},
			};
		}

		protected override void InitializeParameters() {
			base.InitializeParameters();
			Parameters.Add(CreatePageInstanceIdParameter());
			Parameters.Add(CreateActiveTreeGridCurrentRowIdParameter());
			Parameters.Add(CreateFileNameParameter());
		}

		protected override void InitializeBaseElements() {
			base.InitializeBaseElements();
			ProcessSchemaLaneSet schemaLaneSet74 = CreateLaneSet74LaneSet();
			LaneSets.Add(schemaLaneSet74);
			ProcessSchemaLane schemaLane190 = CreateLane190Lane();
			schemaLaneSet74.Lanes.Add(schemaLane190);
			ProcessSchemaStartEvent start1 = CreateStart1StartEvent();
			FlowElements.Add(start1);
			ProcessSchemaEndEvent end1 = CreateEnd1EndEvent();
			FlowElements.Add(end1);
			ProcessSchemaScriptTask downloadtemplatescript = CreateDownloadTemplateScriptScriptTask();
			FlowElements.Add(downloadtemplatescript);
			FlowElements.Add(CreateSequenceFlow594SequenceFlow());
			FlowElements.Add(CreateSequenceFlow595SequenceFlow());
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow594SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow594",
				UId = new Guid("d2d68bc8-db0b-4c70-bb26-ebb200d0b968"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("85309378-d6ac-8d35-bf60-cb315df85ea9"),
				CurveCenterPosition = new Point(373, 199),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("85309378-d6ac-8d35-bf60-cb315df85ea9"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("bbe07d04-17aa-4529-b126-eecd86c61795"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("c162c2c1-9f48-4ce2-ab1c-3980d1ee14de"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow595SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow595",
				UId = new Guid("831ba719-e6e8-4111-808f-b6c625f03eb5"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("85309378-d6ac-8d35-bf60-cb315df85ea9"),
				CurveCenterPosition = new Point(373, 199),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("85309378-d6ac-8d35-bf60-cb315df85ea9"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("66c84dff-1700-4cbf-96b3-53b790f7ba46"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("bbe07d04-17aa-4529-b126-eecd86c61795"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaLaneSet CreateLaneSet74LaneSet() {
			ProcessSchemaLaneSet schemaLaneSet74 = new ProcessSchemaLaneSet(this) {
				UId = new Guid("302a86fe-362f-42ff-8bf5-55db0204deb9"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 1,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("85309378-d6ac-8d35-bf60-cb315df85ea9"),
				Direction = ProcessSchemaPoolDirectionType.Vertical,
				DragGroupName = @"LaneSet",
				ManagerItemUId = new Guid("11a47caf-a0d5-41fa-a274-a0b11f77447a"),
				ModifiedInSchemaUId = new Guid("85309378-d6ac-8d35-bf60-cb315df85ea9"),
				Name = @"LaneSet74",
				Position = new Point(5, 5),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLaneSet74;
		}

		protected virtual ProcessSchemaLane CreateLane190Lane() {
			ProcessSchemaLane schemaLane190 = new ProcessSchemaLane(this) {
				UId = new Guid("29a3acf2-59d3-4a3e-8b9d-e8e245697256"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 1,
				ContainerUId = new Guid("302a86fe-362f-42ff-8bf5-55db0204deb9"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("85309378-d6ac-8d35-bf60-cb315df85ea9"),
				DragGroupName = @"Lane",
				ManagerItemUId = new Guid("abcd74b9-5912-414b-82ac-f1aa4dcd554e"),
				ModifiedInSchemaUId = new Guid("85309378-d6ac-8d35-bf60-cb315df85ea9"),
				Name = @"Lane190",
				Position = new Point(29, 0),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLane190;
		}

		protected virtual ProcessSchemaStartEvent CreateStart1StartEvent() {
			ProcessSchemaStartEvent schemaStartEvent = new ProcessSchemaStartEvent(this) {
				UId = new Guid("66c84dff-1700-4cbf-96b3-53b790f7ba46"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = new Guid("29a3acf2-59d3-4a3e-8b9d-e8e245697256"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("85309378-d6ac-8d35-bf60-cb315df85ea9"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsInterrupting = false,
				IsLogging = true,
				ManagerItemUId = new Guid("53818048-7868-48f6-ada0-0ebaa65af628"),
				ModifiedInSchemaUId = new Guid("85309378-d6ac-8d35-bf60-cb315df85ea9"),
				Name = @"Start1",
				Position = new Point(50, 177),
				SerializeToDB = false,
				Size = new Size(27, 27),
				UseBackgroundMode = false
			};
			
			return schemaStartEvent;
		}

		protected virtual ProcessSchemaEndEvent CreateEnd1EndEvent() {
			ProcessSchemaEndEvent schemaEndEvent = new ProcessSchemaEndEvent(this) {
				UId = new Guid("c162c2c1-9f48-4ce2-ab1c-3980d1ee14de"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = new Guid("29a3acf2-59d3-4a3e-8b9d-e8e245697256"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("85309378-d6ac-8d35-bf60-cb315df85ea9"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsLogging = true,
				ManagerItemUId = new Guid("45ceaae2-4e1f-4c0c-86aa-cd4aeb4da913"),
				ModifiedInSchemaUId = new Guid("85309378-d6ac-8d35-bf60-cb315df85ea9"),
				Name = @"End1",
				Position = new Point(309, 177),
				SerializeToDB = false,
				Size = new Size(27, 27),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaEndEvent;
		}

		protected virtual ProcessSchemaScriptTask CreateDownloadTemplateScriptScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("bbe07d04-17aa-4529-b126-eecd86c61795"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = new Guid("29a3acf2-59d3-4a3e-8b9d-e8e245697256"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("85309378-d6ac-8d35-bf60-cb315df85ea9"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("85309378-d6ac-8d35-bf60-cb315df85ea9"),
				Name = @"DownloadTemplateScript",
				Position = new Point(155, 163),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,197,82,193,110,211,64,16,61,167,82,255,97,228,211,90,114,86,14,169,90,170,8,36,98,66,65,8,212,146,64,145,162,28,214,241,56,93,100,239,134,245,108,139,85,245,223,187,107,39,148,216,185,227,139,101,207,155,247,222,204,188,123,97,0,21,73,170,231,235,59,44,197,23,161,196,6,13,188,129,239,21,154,68,43,133,107,146,90,241,89,31,52,57,61,185,239,180,187,190,35,108,252,10,233,147,170,72,168,53,78,235,175,162,68,22,124,86,250,161,192,108,131,83,81,225,7,89,96,16,78,160,79,120,99,209,212,142,85,225,3,204,186,255,217,17,173,232,160,157,123,177,208,25,109,153,51,65,34,209,133,45,85,199,104,67,199,223,101,89,91,101,193,123,135,12,124,99,31,229,204,18,154,202,163,217,233,201,160,15,72,12,10,194,22,118,43,233,238,90,24,231,194,247,120,252,160,45,36,186,220,10,35,43,173,22,245,22,249,236,183,21,69,4,135,107,9,162,102,110,157,254,114,71,88,174,224,209,127,93,89,153,177,0,179,244,98,148,199,231,195,252,236,60,29,142,206,70,241,16,47,95,199,195,87,241,58,31,199,233,248,114,124,49,14,194,167,240,63,140,224,87,222,115,238,47,236,11,124,161,231,100,164,218,176,157,185,127,79,238,150,95,180,113,59,122,30,151,162,89,7,199,14,83,234,9,101,14,172,75,199,19,109,21,193,91,136,67,120,116,3,236,179,240,87,230,5,186,140,87,94,104,90,19,86,63,68,97,145,189,132,166,77,19,128,168,32,117,245,229,106,2,238,217,241,25,172,182,90,85,232,56,63,18,109,157,41,194,63,196,19,107,140,211,224,223,118,101,31,242,193,98,238,202,185,220,88,35,26,123,215,46,185,123,0,191,53,146,144,237,233,162,198,104,4,251,5,70,208,109,110,148,20,53,55,248,89,22,254,237,247,240,228,119,107,144,172,81,64,198,226,228,25,136,130,182,226,235,3,0,0 }
			};
			
			return ScriptTask;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeUsings() {
			Usings.Add(new SchemaUsing() {
				UId = new Guid("c08810e2-c3e1-47e0-88ca-79f5af1eda7f"),
				Name = "System.IO",
				Alias = "",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("24b3f1a0-f90a-4547-a96d-193f8950f726"),
				Name = "System.Web",
				Alias = "",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("eb054adf-f825-4f38-886d-c3f2c917d9cd"),
				Name = "Terrasoft.Configuration",
				Alias = "TSConfiguration",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			});
		}

		#endregion

		#region Methods: Public

		public override Process CreateProcess(UserConnection userConnection) {
			return new DownloadTemplateForImportContactsProcess(userConnection);
		}

		public override object Clone() {
			return new DownloadTemplateForImportContactsProcessSchema(this);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("85309378-d6ac-8d35-bf60-cb315df85ea9"));
		}

		#endregion

	}

	#endregion

	#region Class: DownloadTemplateForImportContactsProcess

	/// <exclude/>
	public class DownloadTemplateForImportContactsProcess : Terrasoft.Core.Process.Process
	{

		#region Class: ProcessLane190

		/// <exclude/>
		public class ProcessLane190 : ProcessLane
		{

			public ProcessLane190(UserConnection userConnection, DownloadTemplateForImportContactsProcess process)
				: base(userConnection) {
				Owner = process;
				IsUsedParentUserContexts = false;
			}

		}

		#endregion

		public DownloadTemplateForImportContactsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "DownloadTemplateForImportContactsProcess";
			SchemaUId = new Guid("85309378-d6ac-8d35-bf60-cb315df85ea9");
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
				return new Guid("85309378-d6ac-8d35-bf60-cb315df85ea9");
			}
		}

		private string ConditionalExpressionLogMessage {
			get {
				return "Process: DownloadTemplateForImportContactsProcess, Source element: {0}, Conditional flow: {1}, Expression: {2}, Result: {3}";
			}
		}

		private string DeadEndGatewayLogMessage {
			get {
				return "Process: DownloadTemplateForImportContactsProcess, Source element: {0}, None of the exclusive gateway conditions are met!";
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

		private LocalizableString _fileName;
		public virtual LocalizableString FileName {
			get {
				return _fileName ?? (_fileName = GetLocalizableString("85309378d6ac8d35bf60cb315df85ea9",
						 "Parameters.FileName.Value"));
			}
			set {
				_fileName = value;
			}
		}

		private ProcessLane190 _lane190;
		public ProcessLane190 Lane190 {
			get {
				return _lane190 ?? ((_lane190) = new ProcessLane190(UserConnection, this));
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
					SchemaElementUId = new Guid("66c84dff-1700-4cbf-96b3-53b790f7ba46"),
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
					SchemaElementUId = new Guid("c162c2c1-9f48-4ce2-ab1c-3980d1ee14de"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
				});
			}
		}

		private ProcessScriptTask _downloadTemplateScript;
		public ProcessScriptTask DownloadTemplateScript {
			get {
				return _downloadTemplateScript ?? (_downloadTemplateScript = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "DownloadTemplateScript",
					SchemaElementUId = new Guid("bbe07d04-17aa-4529-b126-eecd86c61795"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = DownloadTemplateScriptExecute,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[Start1.SchemaElementUId] = new Collection<ProcessFlowElement> { Start1 };
			FlowElements[End1.SchemaElementUId] = new Collection<ProcessFlowElement> { End1 };
			FlowElements[DownloadTemplateScript.SchemaElementUId] = new Collection<ProcessFlowElement> { DownloadTemplateScript };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "Start1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("DownloadTemplateScript", e.Context.SenderName));
						break;
					case "End1":
						CompleteProcess();
						break;
					case "DownloadTemplateScript":
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
			MetaPathParameterValues.Add("07ee176b-7bb7-40cf-9ffa-4bf954aeb744", () => PageInstanceId);
			MetaPathParameterValues.Add("a6b7b324-3872-4592-919e-2430c72143e7", () => ActiveTreeGridCurrentRowId);
			MetaPathParameterValues.Add("97cb0249-71ed-4b15-83ba-ff9002d7f88c", () => FileName);
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
			}
		}

		protected override void WritePropertyValues(DataWriter writer) {
			base.WritePropertyValues(writer);
			WritePropertyValues(writer, true);
		}

		#endregion

		#region Methods: Public

		public virtual bool DownloadTemplateScriptExecute(ProcessExecutingContext context) {
			var entitySchemaManager = UserConnection.EntitySchemaManager;
			var entitySchema = entitySchemaManager.GetInstanceByName("KnowledgeBaseFile"); 
			var entitySchemaQuery = new EntitySchemaQuery(entitySchemaManager, entitySchema.Name);
			
			var dataColumn = entitySchemaQuery.AddColumn("Data");
			entitySchemaQuery.Filters.Add(
				entitySchemaQuery.CreateFilterWithParameters(
					FilterComparisonType.Equal, "KnowledgeBase", new object[] {new Guid("edb71f06-f46b-1410-e980-20cf30b39373")}));
			entitySchemaQuery.Filters.Add(
				entitySchemaQuery.CreateFilterWithParameters(
					FilterComparisonType.Equal, "Name", new object[] {FileName.ToString()}));
			
			var entityCollection = entitySchemaQuery.GetEntityCollection(UserConnection);
			if (entityCollection.Count > 0) {
				var data = entityCollection[0].GetBytesValue(dataColumn.Name)  as byte[];    
				var response = HttpContext.Current.Response; 
				TSConfiguration.PageResponse.Write(response, data, FileName, TSConfiguration.ContentType.XmlType);
			}
			
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
			var cloneItem = (DownloadTemplateForImportContactsProcess)base.CloneShallow();
			cloneItem.ExecutedEventHandler = ExecutedEventHandler;
			return cloneItem;
		}

		#endregion

	}

	#endregion

}

