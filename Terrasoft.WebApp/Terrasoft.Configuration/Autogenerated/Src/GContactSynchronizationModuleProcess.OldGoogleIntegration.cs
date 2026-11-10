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
	using System.Net;
	using System.Reflection;
	using System.Text;
	using System.Text.RegularExpressions;
	using Terrasoft.Common;
	using Terrasoft.Configuration;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Factories;
	using Terrasoft.Core.Process;
	using Terrasoft.Core.Process.Configuration;
	using Terrasoft.GoogleServices;
	using Terrasoft.UI.WebControls.Controls;
	using Terrasoft.UI.WebControls.Utilities;
	using Terrasoft.UI.WebControls.Utilities.Json.Converters;

	#region Class: GContactSynchronizationModuleProcessSchema

	/// <exclude/>
	public class GContactSynchronizationModuleProcessSchema : Terrasoft.Core.Process.ProcessSchema
	{

		#region Constructors: Public

		public GContactSynchronizationModuleProcessSchema(ProcessSchemaManager processSchemaManager)
			: base(processSchemaManager) {
		}

		public GContactSynchronizationModuleProcessSchema(GContactSynchronizationModuleProcessSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			Name = "GContactSynchronizationModuleProcess";
			UId = new Guid("2e4ae0af-2b8a-446f-bd58-7a66e3848de2");
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
			Tag = @"Business Process";
			TaskFillDefColor = Color.FromArgb(-1);
			UsageType = ProcessSchemaUsageType.Advanced;
			ZipMethodsBody = new byte[] {  };
			ZipCompiledMethodsBody = new byte[] {  };
			RealUId = new Guid("2e4ae0af-2b8a-446f-bd58-7a66e3848de2");
			Version = 0;
			PackageUId = new Guid("8d48ade0-350e-7694-49aa-2a913c356ce1");
			UseSystemSecurityContext = false;
		}

		protected virtual ProcessSchemaParameter CreateSyncResultParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("0e5d2134-8209-4bec-b476-d8fb22b794cd"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("2e4ae0af-2b8a-446f-bd58-7a66e3848de2"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("2e4ae0af-2b8a-446f-bd58-7a66e3848de2"),
				Name = @"SyncResult",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MaxSizeText"),
			};
		}

		protected virtual ProcessSchemaParameter CreateSynchronizationSummaryLSParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("3ae43962-9462-4f13-97ce-dfed8f1f6f5b"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("2e4ae0af-2b8a-446f-bd58-7a66e3848de2"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("2e4ae0af-2b8a-446f-bd58-7a66e3848de2"),
				Name = @"SynchronizationSummaryLS",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LocalizableStringDataValueType"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.ConstValue,
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("2e4ae0af-2b8a-446f-bd58-7a66e3848de2"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateSynchronizationAuthenticationErrorMessageParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("7479f56f-7647-4eec-9bb8-5156739027c1"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("c76e9f6c-3172-4749-93d6-bda8576827e7"),
				CreatedInSchemaUId = new Guid("2e4ae0af-2b8a-446f-bd58-7a66e3848de2"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("2e4ae0af-2b8a-446f-bd58-7a66e3848de2"),
				Name = @"SynchronizationAuthenticationErrorMessage",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LocalizableStringDataValueType"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.ConstValue,
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("2e4ae0af-2b8a-446f-bd58-7a66e3848de2"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateAddContactLogMessageParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("01a280b5-95d3-4e4d-8cad-d58a487b428e"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("c76e9f6c-3172-4749-93d6-bda8576827e7"),
				CreatedInSchemaUId = new Guid("2e4ae0af-2b8a-446f-bd58-7a66e3848de2"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("2e4ae0af-2b8a-446f-bd58-7a66e3848de2"),
				Name = @"AddContactLogMessage",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LocalizableStringDataValueType"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.ConstValue,
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("2e4ae0af-2b8a-446f-bd58-7a66e3848de2"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateSynchronizationSummaryParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("e5dcc874-23f5-4844-a3c2-1f954f1a2d7f"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("2e3e95a4-2024-4552-b820-30e9633c8933"),
				CreatedInSchemaUId = new Guid("2e4ae0af-2b8a-446f-bd58-7a66e3848de2"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("2e4ae0af-2b8a-446f-bd58-7a66e3848de2"),
				Name = @"SynchronizationSummary",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LocalizableStringDataValueType"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.ConstValue,
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("2e4ae0af-2b8a-446f-bd58-7a66e3848de2"),
				},
			};
		}

		protected override void InitializeParameters() {
			base.InitializeParameters();
			Parameters.Add(CreateSyncResultParameter());
			Parameters.Add(CreateSynchronizationSummaryLSParameter());
			Parameters.Add(CreateSynchronizationAuthenticationErrorMessageParameter());
			Parameters.Add(CreateAddContactLogMessageParameter());
			Parameters.Add(CreateSynchronizationSummaryParameter());
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
			ProcessSchemaScriptTask gcontactsinchronizationscripttask = CreateGContactSinchronizationScriptTaskScriptTask();
			FlowElements.Add(gcontactsinchronizationscripttask);
			FlowElements.Add(CreateSequenceFlow1SequenceFlow());
			FlowElements.Add(CreateSequenceFlow2SequenceFlow());
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow1SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow1",
				UId = new Guid("a15ffe1c-59dd-4c92-bf6c-ab6aafa9ab5e"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("2e4ae0af-2b8a-446f-bd58-7a66e3848de2"),
				CurveCenterPosition = new Point(373, 203),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("2e4ae0af-2b8a-446f-bd58-7a66e3848de2"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("5777cab7-8b56-432f-9ca9-c8ffd2dce588"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("64499a36-2472-445c-af6d-dcbab5fb91c9"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow2SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow2",
				UId = new Guid("ab5c1f9f-aec2-4a52-842f-00780dff640e"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("2e4ae0af-2b8a-446f-bd58-7a66e3848de2"),
				CurveCenterPosition = new Point(373, 203),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("2e4ae0af-2b8a-446f-bd58-7a66e3848de2"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("64499a36-2472-445c-af6d-dcbab5fb91c9"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("a0327592-5363-4585-ba88-339e4725f496"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaLaneSet CreateLaneSet1LaneSet() {
			ProcessSchemaLaneSet schemaLaneSet1 = new ProcessSchemaLaneSet(this) {
				UId = new Guid("326c6e76-5843-4dc2-80da-d1988c53a164"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 1,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("2e4ae0af-2b8a-446f-bd58-7a66e3848de2"),
				Direction = ProcessSchemaPoolDirectionType.Vertical,
				DragGroupName = @"LaneSet",
				ManagerItemUId = new Guid("11a47caf-a0d5-41fa-a274-a0b11f77447a"),
				ModifiedInSchemaUId = new Guid("2e4ae0af-2b8a-446f-bd58-7a66e3848de2"),
				Name = @"LaneSet1",
				Position = new Point(5, 5),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLaneSet1;
		}

		protected virtual ProcessSchemaLane CreateLane1Lane() {
			ProcessSchemaLane schemaLane1 = new ProcessSchemaLane(this) {
				UId = new Guid("ad24b9b1-e744-47bc-aeb3-e52df9793c39"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 1,
				ContainerUId = new Guid("326c6e76-5843-4dc2-80da-d1988c53a164"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("2e4ae0af-2b8a-446f-bd58-7a66e3848de2"),
				DragGroupName = @"Lane",
				ManagerItemUId = new Guid("abcd74b9-5912-414b-82ac-f1aa4dcd554e"),
				ModifiedInSchemaUId = new Guid("2e4ae0af-2b8a-446f-bd58-7a66e3848de2"),
				Name = @"Lane1",
				Position = new Point(29, 0),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLane1;
		}

		protected virtual ProcessSchemaStartEvent CreateStart1StartEvent() {
			ProcessSchemaStartEvent schemaStartEvent = new ProcessSchemaStartEvent(this) {
				UId = new Guid("5777cab7-8b56-432f-9ca9-c8ffd2dce588"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = new Guid("ad24b9b1-e744-47bc-aeb3-e52df9793c39"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("2e4ae0af-2b8a-446f-bd58-7a66e3848de2"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsInterrupting = false,
				IsLogging = true,
				ManagerItemUId = new Guid("53818048-7868-48f6-ada0-0ebaa65af628"),
				ModifiedInSchemaUId = new Guid("2e4ae0af-2b8a-446f-bd58-7a66e3848de2"),
				Name = @"Start1",
				Position = new Point(50, 184),
				SerializeToDB = false,
				Size = new Size(27, 27),
				UseBackgroundMode = false
			};
			
			return schemaStartEvent;
		}

		protected virtual ProcessSchemaEndEvent CreateEnd1EndEvent() {
			ProcessSchemaEndEvent schemaEndEvent = new ProcessSchemaEndEvent(this) {
				UId = new Guid("a0327592-5363-4585-ba88-339e4725f496"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = new Guid("ad24b9b1-e744-47bc-aeb3-e52df9793c39"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("2e4ae0af-2b8a-446f-bd58-7a66e3848de2"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsLogging = true,
				ManagerItemUId = new Guid("45ceaae2-4e1f-4c0c-86aa-cd4aeb4da913"),
				ModifiedInSchemaUId = new Guid("2e4ae0af-2b8a-446f-bd58-7a66e3848de2"),
				Name = @"End1",
				Position = new Point(631, 184),
				SerializeToDB = false,
				Size = new Size(27, 27),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaEndEvent;
		}

		protected virtual ProcessSchemaScriptTask CreateGContactSinchronizationScriptTaskScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("64499a36-2472-445c-af6d-dcbab5fb91c9"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = new Guid("ad24b9b1-e744-47bc-aeb3-e52df9793c39"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("2e4ae0af-2b8a-446f-bd58-7a66e3848de2"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("2e4ae0af-2b8a-446f-bd58-7a66e3848de2"),
				Name = @"GContactSinchronizationScriptTask",
				Position = new Point(251, 170),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,141,147,223,75,195,48,16,199,159,43,236,127,56,245,165,131,82,134,175,58,161,110,58,124,216,24,235,246,44,33,61,187,64,155,200,229,162,86,241,127,55,173,115,107,231,166,66,75,146,187,239,229,243,205,175,115,245,8,167,179,219,101,186,76,102,227,100,49,190,120,24,244,78,130,103,65,144,27,147,23,152,86,90,174,201,104,245,134,4,67,24,21,194,218,59,33,217,80,21,79,144,175,38,35,163,217,143,219,186,235,80,227,11,248,132,101,114,181,52,161,220,149,168,57,60,115,22,201,39,52,74,86,70,159,69,176,234,4,250,253,75,79,103,170,224,221,183,193,79,11,113,107,16,54,226,160,142,44,208,186,130,97,88,143,61,84,233,60,190,51,84,10,14,235,72,176,43,18,53,37,117,101,41,168,138,154,220,1,70,146,101,152,45,80,26,202,236,189,190,153,79,141,46,148,198,145,113,154,163,3,251,18,175,158,50,193,199,75,142,113,198,88,224,47,101,135,72,93,107,147,70,176,81,31,163,236,155,235,20,253,195,85,75,223,32,154,93,255,0,41,88,174,33,156,236,77,208,108,240,237,171,196,167,186,3,249,182,219,255,58,210,246,105,193,94,89,226,120,237,111,137,146,95,147,16,25,154,162,181,34,199,191,145,99,193,34,145,210,203,255,11,239,222,147,35,87,4,6,123,95,119,245,59,22,30,66,96,220,246,239,255,5,150,74,103,30,155,34,61,35,173,88,21,138,21,218,120,68,232,15,105,155,190,169,230,100,234,197,132,221,247,17,129,244,207,13,95,57,222,228,191,219,84,174,177,20,241,76,148,24,193,206,67,4,218,21,69,4,254,29,98,237,252,28,253,244,143,65,239,132,144,29,233,38,126,249,9,85,20,33,244,3,4,0,0 }
			};
			
			return ScriptTask;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeUsings() {
			Usings.Add(new SchemaUsing() {
				UId = new Guid("26e265b0-008d-4548-9346-e525a8c417b3"),
				Name = "Terrasoft.GoogleServices",
				Alias = "",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("7bd85a1f-fa4a-42e7-86cc-925d2631df62"),
				Name = "Terrasoft.Core.Entities",
				Alias = "",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("c8b6df16-d44f-40e8-afbd-444b2eb97dbb"),
				Name = "System.Data",
				Alias = "",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("bc416dde-eaee-4763-9ebd-8b93397ba899"),
				Name = "Terrasoft.Configuration",
				Alias = "",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("b1dd2c7b-feb4-49ad-8ceb-5be16d1c13b1"),
				Name = "System.Linq",
				Alias = "",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("90e61ce7-ddb7-4ba0-be3a-ca3ced9dd680"),
				Name = "Terrasoft.UI.WebControls.Utilities",
				Alias = "",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("1eb03ebe-0935-42e9-b5dd-06949c46dba3"),
				Name = "Terrasoft.UI.WebControls.Utilities.Json.Converters",
				Alias = "",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("68998bdf-dbe7-4fdb-8607-a10949a5a129"),
				Name = "Terrasoft.UI.WebControls.Controls",
				Alias = "",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("b766e772-3606-4e2d-bfbf-de3f9cac8be9"),
				Name = "System.Reflection",
				Alias = "",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("8f51eb06-1e20-40d2-a422-e335e47122bc"),
				Name = "System.Net",
				Alias = "",
				CreatedInPackageId = new Guid("ed1e25d0-4a91-4242-add0-f9ed221a63db")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("c2ff373f-e87f-4a5e-81bd-e05883f44a05"),
				Name = "System.Text.RegularExpressions",
				Alias = "",
				CreatedInPackageId = new Guid("ed1e25d0-4a91-4242-add0-f9ed221a63db")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("6ac5a1a7-f898-4959-adcc-493edf22bc66"),
				Name = "Terrasoft.Core.Factories",
				Alias = "",
				CreatedInPackageId = new Guid("2e3e95a4-2024-4552-b820-30e9633c8933")
			});
		}

		#endregion

		#region Methods: Public

		public override Process CreateProcess(UserConnection userConnection) {
			return new GContactSynchronizationModuleProcess(userConnection);
		}

		public override object Clone() {
			return new GContactSynchronizationModuleProcessSchema(this);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("2e4ae0af-2b8a-446f-bd58-7a66e3848de2"));
		}

		#endregion

	}

	#endregion

	#region Class: GContactSynchronizationModuleProcess

	/// <exclude/>
	public class GContactSynchronizationModuleProcess : Terrasoft.Core.Process.Process
	{

		#region Class: ProcessLane1

		/// <exclude/>
		public class ProcessLane1 : ProcessLane
		{

			public ProcessLane1(UserConnection userConnection, GContactSynchronizationModuleProcess process)
				: base(userConnection) {
				Owner = process;
				IsUsedParentUserContexts = false;
			}

		}

		#endregion

		public GContactSynchronizationModuleProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "GContactSynchronizationModuleProcess";
			SchemaUId = new Guid("2e4ae0af-2b8a-446f-bd58-7a66e3848de2");
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
				return new Guid("2e4ae0af-2b8a-446f-bd58-7a66e3848de2");
			}
		}

		private string ConditionalExpressionLogMessage {
			get {
				return "Process: GContactSynchronizationModuleProcess, Source element: {0}, Conditional flow: {1}, Expression: {2}, Result: {3}";
			}
		}

		private string DeadEndGatewayLogMessage {
			get {
				return "Process: GContactSynchronizationModuleProcess, Source element: {0}, None of the exclusive gateway conditions are met!";
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

		public virtual string SyncResult {
			get;
			set;
		}

		private LocalizableString _synchronizationSummaryLS;
		public virtual LocalizableString SynchronizationSummaryLS {
			get {
				return _synchronizationSummaryLS ?? (_synchronizationSummaryLS = GetLocalizableString("2e4ae0af2b8a446fbd587a66e3848de2",
						 "Parameters.SynchronizationSummaryLS.Value"));
			}
			set {
				_synchronizationSummaryLS = value;
			}
		}

		private LocalizableString _synchronizationAuthenticationErrorMessage;
		public virtual LocalizableString SynchronizationAuthenticationErrorMessage {
			get {
				return _synchronizationAuthenticationErrorMessage ?? (_synchronizationAuthenticationErrorMessage = GetLocalizableString("2e4ae0af2b8a446fbd587a66e3848de2",
						 "Parameters.SynchronizationAuthenticationErrorMessage.Value"));
			}
			set {
				_synchronizationAuthenticationErrorMessage = value;
			}
		}

		private LocalizableString _addContactLogMessage;
		public virtual LocalizableString AddContactLogMessage {
			get {
				return _addContactLogMessage ?? (_addContactLogMessage = GetLocalizableString("2e4ae0af2b8a446fbd587a66e3848de2",
						 "Parameters.AddContactLogMessage.Value"));
			}
			set {
				_addContactLogMessage = value;
			}
		}

		private LocalizableString _synchronizationSummary;
		public virtual LocalizableString SynchronizationSummary {
			get {
				return _synchronizationSummary ?? (_synchronizationSummary = GetLocalizableString("2e4ae0af2b8a446fbd587a66e3848de2",
						 "Parameters.SynchronizationSummary.Value"));
			}
			set {
				_synchronizationSummary = value;
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
					SchemaElementUId = new Guid("5777cab7-8b56-432f-9ca9-c8ffd2dce588"),
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
					SchemaElementUId = new Guid("a0327592-5363-4585-ba88-339e4725f496"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
				});
			}
		}

		private ProcessScriptTask _gContactSinchronizationScriptTask;
		public ProcessScriptTask GContactSinchronizationScriptTask {
			get {
				return _gContactSinchronizationScriptTask ?? (_gContactSinchronizationScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "GContactSinchronizationScriptTask",
					SchemaElementUId = new Guid("64499a36-2472-445c-af6d-dcbab5fb91c9"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = GContactSinchronizationScriptTaskExecute,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[Start1.SchemaElementUId] = new Collection<ProcessFlowElement> { Start1 };
			FlowElements[End1.SchemaElementUId] = new Collection<ProcessFlowElement> { End1 };
			FlowElements[GContactSinchronizationScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { GContactSinchronizationScriptTask };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "Start1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("GContactSinchronizationScriptTask", e.Context.SenderName));
						break;
					case "End1":
						CompleteProcess();
						break;
					case "GContactSinchronizationScriptTask":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("End1", e.Context.SenderName));
						break;
			}
		}

		private void WritePropertyValues(DataWriter writer, bool useAllValueSources) {
			if (!HasMapping("SyncResult")) {
				writer.WriteValue("SyncResult", SyncResult, null);
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
			MetaPathParameterValues.Add("0e5d2134-8209-4bec-b476-d8fb22b794cd", () => SyncResult);
			MetaPathParameterValues.Add("3ae43962-9462-4f13-97ce-dfed8f1f6f5b", () => SynchronizationSummaryLS);
			MetaPathParameterValues.Add("7479f56f-7647-4eec-9bb8-5156739027c1", () => SynchronizationAuthenticationErrorMessage);
			MetaPathParameterValues.Add("01a280b5-95d3-4e4d-8cad-d58a487b428e", () => AddContactLogMessage);
			MetaPathParameterValues.Add("e5dcc874-23f5-4844-a3c2-1f954f1a2d7f", () => SynchronizationSummary);
		}

		protected override void ApplyPropertiesDataValues(DataReader reader) {
			base.ApplyPropertiesDataValues(reader);
			bool hasValueToRead = reader.HasValue();
			switch (reader.CurrentName) {
				case "SyncResult":
					if (!hasValueToRead) break;
					SyncResult = reader.GetValue<System.String>();
				break;
			}
		}

		protected override void WritePropertyValues(DataWriter writer) {
			base.WritePropertyValues(writer);
			WritePropertyValues(writer, true);
		}

		#endregion

		#region Methods: Public

		public virtual bool GContactSinchronizationScriptTaskExecute(ProcessExecutingContext context) {
			#if !NETSTANDARD2_0
				var googleSynchronizer = ClassFactory.Get<GContactSynchronizer>(new ConstructorArgument("userConnection", UserConnection));
				try {
					googleSynchronizer.Synchronize();
					SyncResult =
					string.Format(
						SynchronizationSummary,
						googleSynchronizer.AddedRecordsInBPMonlineCount, googleSynchronizer.UpdatedRecordsInBPMonlineCount,
						googleSynchronizer.DeletedRecordsInBPMonlineCount, googleSynchronizer.AddedRecordsInGoogleCount, 
						googleSynchronizer.UpdatedRecordsInGoogleCount, googleSynchronizer.DeletedRecordsInGoogleCount
						);
				} catch (GoogleSynchronizationException gException) {
					SyncResult = SynchronizationAuthenticationErrorMessage;
				} catch (GoogleSynchronizationDataAccessException gException) {
					SyncResult = string.Format(SynchronizationSummary, 0, 0, 0, 0, 0, 0);
				} catch (Exception e) {
					SyncResult = e.Message;
				}
				RemindingServerUtilities.CreateRemindingByProcess(UserConnection, context.Process.ProcessSchema.Name, SyncResult, null, true);
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
			var cloneItem = (GContactSynchronizationModuleProcess)base.CloneShallow();
			cloneItem.ExecutedEventHandler = ExecutedEventHandler;
			return cloneItem;
		}

		#endregion

	}

	#endregion

}

