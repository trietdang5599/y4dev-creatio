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
	using Terrasoft.Common.Json;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Process;
	using Terrasoft.Core.Process.Configuration;
	using Terrasoft.Social;

	#region Class: CreateSocialAccountProcessSchema

	/// <exclude/>
	public class CreateSocialAccountProcessSchema : Terrasoft.Core.Process.ProcessSchema
	{

		#region Constructors: Public

		public CreateSocialAccountProcessSchema(ProcessSchemaManager processSchemaManager)
			: base(processSchemaManager) {
		}

		public CreateSocialAccountProcessSchema(CreateSocialAccountProcessSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			Name = "CreateSocialAccountProcess";
			UId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78");
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
			RealUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78");
			Version = 0;
			PackageUId = new Guid("06d9ef10-51d8-122c-8933-9212e84236c9");
			UseSystemSecurityContext = false;
		}

		protected virtual ProcessSchemaParameter CreateNewSocialAccountIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("f263dd85-d3cd-4c40-b168-ae8daff43524"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"),
				Name = @"NewSocialAccountId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid"),
			};
		}

		protected virtual ProcessSchemaParameter CreatePageParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("b1d146ff-40e8-4a5d-8b94-206a62e7f944"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = true,
				IsResult = false,
				IsValueSerializable = false,
				ModifiedInSchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"),
				Name = @"Page",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Object"),
			};
		}

		protected virtual ProcessSchemaParameter CreateSocialNetworkParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("4e3fdba2-8339-42ed-860d-a7d96d66d755"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"),
				Name = @"SocialNetwork",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Text"),
			};
		}

		protected virtual ProcessSchemaParameter CreateApplyAccountPublicLSParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("bce9a8f0-f858-4156-8a65-8715d4c703dc"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"),
				Name = @"ApplyAccountPublicLS",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LocalizableStringDataValueType"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.ConstValue,
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"),
				},
			};
		}

		protected override void InitializeParameters() {
			base.InitializeParameters();
			Parameters.Add(CreateNewSocialAccountIdParameter());
			Parameters.Add(CreatePageParameter());
			Parameters.Add(CreateSocialNetworkParameter());
			Parameters.Add(CreateApplyAccountPublicLSParameter());
		}

		protected virtual void InitializeOpenMessageWindowParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var pageParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("ffaca191-2916-4e64-80ef-3d900be58e07"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerUId = new Guid("a076b343-35fb-4593-b863-c0008611e92e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("496a664f-3aab-43d7-ab1b-2521ab601aab"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = true,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("496a664f-3aab-43d7-ab1b-2521ab601aab"),
				Name = @"Page",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Object")
			};
			pageParameter.SourceValue = new ProcessSchemaParameterValue(pageParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(pageParameter);
			var iconParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("0c05c81a-1734-431a-88b8-61dc5472c229"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerUId = new Guid("a076b343-35fb-4593-b863-c0008611e92e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("496a664f-3aab-43d7-ab1b-2521ab601aab"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("496a664f-3aab-43d7-ab1b-2521ab601aab"),
				Name = @"Icon",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Text")
			};
			iconParameter.SourceValue = new ProcessSchemaParameterValue(iconParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(iconParameter);
			var buttonsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("68b45479-94c9-49fb-8c83-4703bccc4fcd"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerUId = new Guid("a076b343-35fb-4593-b863-c0008611e92e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("496a664f-3aab-43d7-ab1b-2521ab601aab"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("496a664f-3aab-43d7-ab1b-2521ab601aab"),
				Name = @"Buttons",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Text")
			};
			buttonsParameter.SourceValue = new ProcessSchemaParameterValue(buttonsParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(buttonsParameter);
			var windowCaptionParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("559e2e0e-1702-4631-8932-e2df756aa0c6"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerUId = new Guid("a076b343-35fb-4593-b863-c0008611e92e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("496a664f-3aab-43d7-ab1b-2521ab601aab"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("496a664f-3aab-43d7-ab1b-2521ab601aab"),
				Name = @"WindowCaption",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Text")
			};
			windowCaptionParameter.SourceValue = new ProcessSchemaParameterValue(windowCaptionParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(windowCaptionParameter);
			var messageTextParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("34aec6b7-5646-46a9-b104-d0fda1835eab"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerUId = new Guid("a076b343-35fb-4593-b863-c0008611e92e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("496a664f-3aab-43d7-ab1b-2521ab601aab"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = true,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("496a664f-3aab-43d7-ab1b-2521ab601aab"),
				Name = @"MessageText",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Text")
			};
			messageTextParameter.SourceValue = new ProcessSchemaParameterValue(messageTextParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(messageTextParameter);
			var responseMessagesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("3348ed5e-3ee7-4dc4-8334-1f5ad4953e28"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerUId = new Guid("a076b343-35fb-4593-b863-c0008611e92e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("496a664f-3aab-43d7-ab1b-2521ab601aab"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("496a664f-3aab-43d7-ab1b-2521ab601aab"),
				Name = @"ResponseMessages",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Object")
			};
			responseMessagesParameter.SourceValue = new ProcessSchemaParameterValue(responseMessagesParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(responseMessagesParameter);
			var processInstanceIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("a0058817-6d78-4f09-bad5-d0162d5a9dfa"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerUId = new Guid("a076b343-35fb-4593-b863-c0008611e92e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("496a664f-3aab-43d7-ab1b-2521ab601aab"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("496a664f-3aab-43d7-ab1b-2521ab601aab"),
				Name = @"ProcessInstanceId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Text")
			};
			processInstanceIdParameter.SourceValue = new ProcessSchemaParameterValue(processInstanceIdParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(processInstanceIdParameter);
			var pageParametersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("751da741-9f8e-4532-a1a1-f34181368335"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerUId = new Guid("a076b343-35fb-4593-b863-c0008611e92e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("496a664f-3aab-43d7-ab1b-2521ab601aab"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("496a664f-3aab-43d7-ab1b-2521ab601aab"),
				Name = @"PageParameters",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Object")
			};
			pageParametersParameter.SourceValue = new ProcessSchemaParameterValue(pageParametersParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(pageParametersParameter);
		}

		protected virtual void InitializeCreateSocialAccountUserTaskParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var userIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("1000931d-1c32-448b-ba0e-c66614e147a8"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerUId = new Guid("71febcbb-2f80-4258-9e38-210a2188c99f"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("4c647b90-1d28-415a-8393-3699e8ed5e25"),
				Direction = ProcessSchemaParameterDirection.In,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = true,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("4c647b90-1d28-415a-8393-3699e8ed5e25"),
				Name = @"UserId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid")
			};
			userIdParameter.SourceValue = new ProcessSchemaParameterValue(userIdParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(userIdParameter);
			var socialNetworkParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("a7b8a6fa-cf86-4400-90f5-45a23bd10537"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerUId = new Guid("71febcbb-2f80-4258-9e38-210a2188c99f"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("4c647b90-1d28-415a-8393-3699e8ed5e25"),
				Direction = ProcessSchemaParameterDirection.In,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = true,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("4c647b90-1d28-415a-8393-3699e8ed5e25"),
				Name = @"SocialNetwork",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Text")
			};
			socialNetworkParameter.SourceValue = new ProcessSchemaParameterValue(socialNetworkParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(socialNetworkParameter);
			var openerPageIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("96037c02-c530-4081-ab43-d03411c92f27"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerUId = new Guid("71febcbb-2f80-4258-9e38-210a2188c99f"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("4c647b90-1d28-415a-8393-3699e8ed5e25"),
				Direction = ProcessSchemaParameterDirection.In,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = true,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("4c647b90-1d28-415a-8393-3699e8ed5e25"),
				Name = @"OpenerPageId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Text")
			};
			openerPageIdParameter.SourceValue = new ProcessSchemaParameterValue(openerPageIdParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(openerPageIdParameter);
			var successEventNameParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("af330e9a-f3cb-4089-83f8-c51d5ecdc938"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerUId = new Guid("71febcbb-2f80-4258-9e38-210a2188c99f"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("4c647b90-1d28-415a-8393-3699e8ed5e25"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("4c647b90-1d28-415a-8393-3699e8ed5e25"),
				Name = @"SuccessEventName",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Text")
			};
			successEventNameParameter.SourceValue = new ProcessSchemaParameterValue(successEventNameParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("4c647b90-1d28-415a-8393-3699e8ed5e25")
			};
			parametrizedElement.Parameters.Add(successEventNameParameter);
			var failedEventNameParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("fdbe7b1a-f0fd-4541-b4fd-f3aa818a61e4"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerUId = new Guid("71febcbb-2f80-4258-9e38-210a2188c99f"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("4c647b90-1d28-415a-8393-3699e8ed5e25"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("4c647b90-1d28-415a-8393-3699e8ed5e25"),
				Name = @"FailedEventName",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Text")
			};
			failedEventNameParameter.SourceValue = new ProcessSchemaParameterValue(failedEventNameParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("4c647b90-1d28-415a-8393-3699e8ed5e25")
			};
			parametrizedElement.Parameters.Add(failedEventNameParameter);
		}

		protected override void InitializeBaseElements() {
			base.InitializeBaseElements();
			ProcessSchemaLaneSet schemaLaneSet1 = CreateLaneSet1LaneSet();
			LaneSets.Add(schemaLaneSet1);
			ProcessSchemaLane schemaLane1 = CreateLane1Lane();
			schemaLaneSet1.Lanes.Add(schemaLane1);
			ProcessSchemaEventSubProcess eventsubprocess2 = CreateEventSubProcess2EventSubProcess();
			FlowElements.Add(eventsubprocess2);
			ProcessSchemaEventSubProcess eventsubprocess3 = CreateEventSubProcess3EventSubProcess();
			FlowElements.Add(eventsubprocess3);
			ProcessSchemaEventSubProcess eventsubprocess4 = CreateEventSubProcess4EventSubProcess();
			FlowElements.Add(eventsubprocess4);
			ProcessSchemaStartMessageEvent socialaccountcreatedsuccessfullyeventstartmessage = CreateSocialAccountCreatedSuccessfullyEventStartMessageStartMessageEvent();
			eventsubprocess2.FlowElements.Add(socialaccountcreatedsuccessfullyeventstartmessage);
			ProcessSchemaScriptTask scripttask6 = CreateScriptTask6ScriptTask();
			eventsubprocess2.FlowElements.Add(scripttask6);
			ProcessSchemaUserTask openmessagewindow = CreateOpenMessageWindowUserTask();
			eventsubprocess2.FlowElements.Add(openmessagewindow);
			ProcessSchemaStartMessageEvent socialaccountcreationfailedeventstartmessage = CreateSocialAccountCreationFailedEventStartMessageStartMessageEvent();
			eventsubprocess3.FlowElements.Add(socialaccountcreationfailedeventstartmessage);
			ProcessSchemaScriptTask scripttask5 = CreateScriptTask5ScriptTask();
			eventsubprocess3.FlowElements.Add(scripttask5);
			ProcessSchemaEndEvent end1 = CreateEnd1EndEvent();
			eventsubprocess3.FlowElements.Add(end1);
			ProcessSchemaStartMessageEvent startmessage1 = CreateStartMessage1StartMessageEvent();
			eventsubprocess4.FlowElements.Add(startmessage1);
			ProcessSchemaStartMessageEvent startmessage2 = CreateStartMessage2StartMessageEvent();
			eventsubprocess4.FlowElements.Add(startmessage2);
			ProcessSchemaScriptTask scripttask7 = CreateScriptTask7ScriptTask();
			eventsubprocess4.FlowElements.Add(scripttask7);
			ProcessSchemaScriptTask scripttask8 = CreateScriptTask8ScriptTask();
			eventsubprocess4.FlowElements.Add(scripttask8);
			ProcessSchemaEndEvent end2 = CreateEnd2EndEvent();
			eventsubprocess4.FlowElements.Add(end2);
			ProcessSchemaStartEvent start1 = CreateStart1StartEvent();
			FlowElements.Add(start1);
			ProcessSchemaScriptTask scripttask4 = CreateScriptTask4ScriptTask();
			FlowElements.Add(scripttask4);
			ProcessSchemaUserTask createsocialaccountusertask = CreateCreateSocialAccountUserTaskUserTask();
			FlowElements.Add(createsocialaccountusertask);
			FlowElements.Add(CreateSequenceFlow7SequenceFlow());
			FlowElements.Add(CreateSequenceFlow8SequenceFlow());
			FlowElements.Add(CreateSequenceFlow9SequenceFlow());
			FlowElements.Add(CreateSequenceFlow10SequenceFlow());
			FlowElements.Add(CreateSequenceFlow11SequenceFlow());
			FlowElements.Add(CreateSequenceFlow12SequenceFlow());
			FlowElements.Add(CreateSequenceFlow13SequenceFlow());
			FlowElements.Add(CreateSequenceFlow1SequenceFlow());
			FlowElements.Add(CreateSequenceFlow2SequenceFlow());
			FlowElements.Add(CreateSequenceFlow3SequenceFlow());
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow7SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow7",
				UId = new Guid("a850d536-caca-483e-8b4d-ca37434e27af"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"),
				CurveCenterPosition = new Point(466, 162),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("e0108a76-0864-455f-ac82-95521b00e280"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("71febcbb-2f80-4258-9e38-210a2188c99f"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow8SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow8",
				UId = new Guid("7f80060c-d0bf-4ae2-b310-1a4a2ad3b4e5"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"),
				CurveCenterPosition = new Point(766, 260),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("f4b0a237-00b7-4e35-b604-f9d844eaa29e"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("a9c60992-1b92-42f9-8053-8089951711ca"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow9SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow9",
				UId = new Guid("f5d50557-7007-470d-92b3-df6e4acb8062"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"),
				CurveCenterPosition = new Point(768, 94),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("7816b0d8-3bb7-4490-ba7b-51b52c04338f"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("f62fedb3-46b3-4d33-8de6-90196a27368a"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow10SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow10",
				UId = new Guid("7f2757b4-9ccf-4844-8f2c-913090f72fdc"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"),
				CurveCenterPosition = new Point(902, 92),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("f62fedb3-46b3-4d33-8de6-90196a27368a"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("a076b343-35fb-4593-b863-c0008611e92e"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow11SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow11",
				UId = new Guid("70ddb426-9614-422b-839f-2ee510834c75"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"),
				CurveCenterPosition = new Point(1152, 56),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("92871b4f-382d-42ab-8800-564ecaba2f0a"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("caceadab-4ab9-4bac-ae41-dcfa07e60739"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow12SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow12",
				UId = new Guid("7f081a69-8405-4e59-853d-85cd5b3816ee"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"),
				CurveCenterPosition = new Point(1274, 66),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("caceadab-4ab9-4bac-ae41-dcfa07e60739"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("2103381a-b1fb-45ae-aebb-3a17c470d89e"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow13SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow13",
				UId = new Guid("7ec8ba54-0df7-4cd1-9c27-1a75de00f7f1"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"),
				CurveCenterPosition = new Point(1300, 100),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("b359fd68-27be-4b79-b92b-9e9d94ab5dd6"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("2103381a-b1fb-45ae-aebb-3a17c470d89e"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow1SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow1",
				UId = new Guid("f3b81b12-edd7-45ee-a82c-ed07e0041e76"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"),
				CurveCenterPosition = new Point(192, 432),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("f2cfd8e7-b706-4cdc-ab23-ca9d82dbb0c3"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("e0108a76-0864-455f-ac82-95521b00e280"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow2SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow2",
				UId = new Guid("47479406-f8b6-4963-b4f9-77838c3efcaf"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"),
				CurveCenterPosition = new Point(708, 258),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("a9c60992-1b92-42f9-8053-8089951711ca"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("68617c70-36fb-4a3a-a32e-cc51ec4a95d2"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow3SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow3",
				UId = new Guid("cf3e71d5-d5a8-4f13-8ebe-e24eb2297f37"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"),
				CurveCenterPosition = new Point(1261, 199),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("2103381a-b1fb-45ae-aebb-3a17c470d89e"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("5246cd69-4c89-426f-a40c-94980486f720"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaLaneSet CreateLaneSet1LaneSet() {
			ProcessSchemaLaneSet schemaLaneSet1 = new ProcessSchemaLaneSet(this) {
				UId = new Guid("467afb00-02d5-4ba1-bebc-cb5f05c10da0"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 1,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"),
				Direction = ProcessSchemaPoolDirectionType.Vertical,
				DragGroupName = @"LaneSet",
				ManagerItemUId = new Guid("11a47caf-a0d5-41fa-a274-a0b11f77447a"),
				ModifiedInSchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"),
				Name = @"LaneSet1",
				Position = new Point(5, 5),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLaneSet1;
		}

		protected virtual ProcessSchemaLane CreateLane1Lane() {
			ProcessSchemaLane schemaLane1 = new ProcessSchemaLane(this) {
				UId = new Guid("56df13cc-24aa-4d5f-8160-0460b9161acd"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 1,
				ContainerUId = new Guid("467afb00-02d5-4ba1-bebc-cb5f05c10da0"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"),
				DragGroupName = @"Lane",
				ManagerItemUId = new Guid("abcd74b9-5912-414b-82ac-f1aa4dcd554e"),
				ModifiedInSchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"),
				Name = @"Lane1",
				Position = new Point(29, 0),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLane1;
		}

		protected virtual ProcessSchemaEventSubProcess CreateEventSubProcess2EventSubProcess() {
			ProcessSchemaEventSubProcess schemaEventSubProcess2 = new ProcessSchemaEventSubProcess(this) {
				UId = new Guid("11ff12e8-b36f-4c21-bb0b-7abd0d9184c1"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = new Guid("56df13cc-24aa-4d5f-8160-0460b9161acd"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"),
				DragGroupName = @"EventSubProcess",
				EntitySchemaUId = Guid.Empty,
				IsExpanded = true,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0824af03-1340-47a3-8787-ef542f566992"),
				ModifiedInSchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"),
				Name = @"EventSubProcess2",
				Position = new Point(435, 9),
				SchemaUId = Guid.Empty,
				SerializeToDB = false,
				Size = new Size(364, 154),
				TriggeredByEvent = true,
				UseBackgroundMode = false,
				UseLastSchemaVersion = false
			};
			
			return schemaEventSubProcess2;
		}

		protected virtual ProcessSchemaStartMessageEvent CreateSocialAccountCreatedSuccessfullyEventStartMessageStartMessageEvent() {
			ProcessSchemaStartMessageEvent schemaStartMessageEvent = new ProcessSchemaStartMessageEvent(this) {
				UId = new Guid("7816b0d8-3bb7-4490-ba7b-51b52c04338f"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = new Guid("11ff12e8-b36f-4c21-bb0b-7abd0d9184c1"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				ImageList = null,
				ImageName = null,
				IsInterrupting = false,
				IsLogging = true,
				ManagerItemUId = new Guid("02340c80-8e75-4f7a-917b-04125bc07192"),
				Message = @"SocialAccountCreatedSuccessfullyEvent",
				ModifiedInSchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"),
				Name = @"SocialAccountCreatedSuccessfullyEventStartMessage",
				Position = new Point(28, 63),
				SerializeToDB = false,
				Size = new Size(27, 27),
				UseBackgroundMode = false
			};
			
			return schemaStartMessageEvent;
		}

		protected virtual ProcessSchemaScriptTask CreateScriptTask6ScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("f62fedb3-46b3-4d33-8de6-90196a27368a"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = new Guid("11ff12e8-b36f-4c21-bb0b-7abd0d9184c1"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"),
				Name = @"ScriptTask6",
				Position = new Point(120, 51),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,157,86,93,79,219,48,20,125,110,126,133,151,39,71,171,130,246,92,64,130,18,88,25,20,182,180,67,104,218,131,73,47,197,35,177,131,237,80,50,196,127,223,245,71,75,91,90,144,86,9,210,196,231,220,235,123,239,241,73,181,81,92,76,73,81,50,94,145,61,82,72,97,224,201,164,163,59,37,103,217,35,8,115,160,166,58,29,201,220,225,104,210,139,162,71,166,200,159,57,129,158,142,228,61,136,228,84,75,145,30,129,6,197,89,201,255,2,117,0,132,91,180,177,16,11,166,167,63,89,217,64,226,233,191,98,199,141,127,39,169,123,188,146,198,242,52,20,10,204,38,98,238,86,222,97,202,2,247,49,152,108,228,134,181,237,236,6,203,112,220,49,126,233,75,33,160,48,28,235,235,55,74,97,75,236,211,116,48,9,173,240,169,134,96,102,82,221,35,167,175,128,25,240,73,14,138,66,54,158,48,98,250,62,205,151,177,189,183,116,191,97,1,51,146,67,137,73,233,234,6,18,220,105,77,191,36,81,39,237,203,178,169,4,141,177,12,123,123,172,100,69,227,190,172,170,70,240,130,89,240,168,173,193,173,93,221,129,2,26,15,89,133,247,233,64,103,15,13,43,169,15,144,94,50,133,207,13,40,186,178,145,36,33,76,135,77,216,24,217,19,20,13,86,85,176,146,169,221,147,134,79,246,109,179,58,209,113,35,138,93,237,186,215,37,254,186,79,116,171,13,84,174,183,174,30,204,144,144,189,125,242,28,117,136,173,249,49,172,228,173,206,193,24,228,232,244,4,140,35,172,149,220,93,235,239,103,226,162,97,106,194,111,9,245,145,62,237,17,209,148,101,98,19,116,8,10,163,81,194,39,89,25,109,135,188,224,159,177,210,38,182,199,40,237,166,194,121,14,145,123,161,178,170,54,109,246,84,64,109,243,210,56,127,45,34,141,49,239,150,125,188,160,12,124,221,164,148,83,110,101,30,168,177,31,176,88,40,195,79,223,13,201,48,35,85,186,44,149,16,248,253,242,147,30,137,140,106,177,206,121,174,16,221,182,239,82,201,91,94,2,157,107,63,73,237,200,113,135,4,5,81,220,61,71,47,65,176,197,29,84,236,173,186,51,97,184,105,115,183,122,206,4,155,162,202,49,236,64,104,195,68,1,135,173,13,71,227,21,101,199,225,196,128,227,98,76,31,60,84,230,35,174,139,184,23,121,116,138,179,63,130,91,47,68,215,103,77,87,22,151,86,104,60,118,103,50,238,134,195,185,29,120,102,59,131,56,215,161,237,48,44,0,180,246,6,212,245,14,245,17,216,155,206,156,226,205,105,59,103,97,51,221,133,27,109,7,219,195,186,4,93,216,193,118,6,54,84,163,122,213,55,104,45,237,85,172,171,75,201,82,4,246,8,206,192,135,48,91,25,162,115,157,0,186,84,188,98,170,93,74,133,4,123,88,142,208,11,204,250,233,76,130,241,172,105,226,213,116,194,212,222,177,157,48,78,203,57,16,19,52,52,157,61,213,92,193,187,36,163,208,207,151,124,201,149,117,81,131,56,199,49,161,112,175,184,152,200,25,18,166,214,102,236,165,183,97,57,220,141,240,133,135,168,131,186,46,219,80,194,101,115,83,242,226,44,223,196,26,224,59,210,30,242,239,227,44,31,13,46,134,241,38,208,97,99,12,78,193,226,174,179,124,120,177,17,244,3,116,141,32,8,79,181,59,206,216,105,238,122,139,83,120,99,172,207,17,241,159,231,184,5,141,115,143,175,65,227,56,110,185,170,66,148,248,165,251,10,18,210,98,134,114,29,66,254,255,19,17,116,60,252,191,179,67,188,205,165,87,112,147,126,53,166,238,135,223,14,225,45,185,40,15,191,76,112,160,248,54,251,144,240,128,30,128,87,54,27,171,210,142,52,88,185,29,119,239,31,95,3,113,217,170,8,0,0 }
			};
			
			return ScriptTask;
		}

		protected virtual ProcessSchemaUserTask CreateOpenMessageWindowUserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("a076b343-35fb-4593-b863-c0008611e92e"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = new Guid("11ff12e8-b36f-4c21-bb0b-7abd0d9184c1"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("1418e61a-82c3-403e-8221-01088f52c125"),
				ModifiedInSchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"),
				Name = @"OpenMessageWindow",
				Position = new Point(266, 49),
				SchemaUId = new Guid("496a664f-3aab-43d7-ab1b-2521ab601aab"),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] {  }
			};
			InitializeOpenMessageWindowParameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaEventSubProcess CreateEventSubProcess3EventSubProcess() {
			ProcessSchemaEventSubProcess schemaEventSubProcess3 = new ProcessSchemaEventSubProcess(this) {
				UId = new Guid("d948e393-a56e-49a8-ae90-e9609779fea6"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = new Guid("56df13cc-24aa-4d5f-8160-0460b9161acd"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"),
				DragGroupName = @"EventSubProcess",
				EntitySchemaUId = Guid.Empty,
				IsExpanded = true,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0824af03-1340-47a3-8787-ef542f566992"),
				ModifiedInSchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"),
				Name = @"EventSubProcess3",
				Position = new Point(434, 168),
				SchemaUId = Guid.Empty,
				SerializeToDB = false,
				Size = new Size(315, 158),
				TriggeredByEvent = true,
				UseBackgroundMode = false,
				UseLastSchemaVersion = false
			};
			
			return schemaEventSubProcess3;
		}

		protected virtual ProcessSchemaStartMessageEvent CreateSocialAccountCreationFailedEventStartMessageStartMessageEvent() {
			ProcessSchemaStartMessageEvent schemaStartMessageEvent = new ProcessSchemaStartMessageEvent(this) {
				UId = new Guid("f4b0a237-00b7-4e35-b604-f9d844eaa29e"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = new Guid("d948e393-a56e-49a8-ae90-e9609779fea6"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				ImageList = null,
				ImageName = null,
				IsInterrupting = false,
				IsLogging = true,
				ManagerItemUId = new Guid("02340c80-8e75-4f7a-917b-04125bc07192"),
				Message = @"SocialAccountCreationFailedEvent",
				ModifiedInSchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"),
				Name = @"SocialAccountCreationFailedEventStartMessage",
				Position = new Point(29, 72),
				SerializeToDB = false,
				Size = new Size(27, 27),
				UseBackgroundMode = false
			};
			
			return schemaStartMessageEvent;
		}

		protected virtual ProcessSchemaScriptTask CreateScriptTask5ScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("a9c60992-1b92-42f9-8053-8089951711ca"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = new Guid("d948e393-a56e-49a8-ae90-e9609779fea6"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"),
				Name = @"ScriptTask5",
				Position = new Point(134, 58),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,43,74,45,41,45,202,83,40,41,42,77,181,6,0,0,22,62,211,12,0,0,0 }
			};
			
			return ScriptTask;
		}

		protected virtual ProcessSchemaEndEvent CreateEnd1EndEvent() {
			ProcessSchemaEndEvent schemaEndEvent = new ProcessSchemaEndEvent(this) {
				UId = new Guid("68617c70-36fb-4a3a-a32e-cc51ec4a95d2"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = new Guid("d948e393-a56e-49a8-ae90-e9609779fea6"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsLogging = true,
				ManagerItemUId = new Guid("45ceaae2-4e1f-4c0c-86aa-cd4aeb4da913"),
				ModifiedInSchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"),
				Name = @"End1",
				Position = new Point(253, 72),
				SerializeToDB = false,
				Size = new Size(27, 27),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaEndEvent;
		}

		protected virtual ProcessSchemaEventSubProcess CreateEventSubProcess4EventSubProcess() {
			ProcessSchemaEventSubProcess schemaEventSubProcess4 = new ProcessSchemaEventSubProcess(this) {
				UId = new Guid("2fc7d8c0-3543-41ee-bebc-75fa4ce6ec80"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = new Guid("56df13cc-24aa-4d5f-8160-0460b9161acd"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"),
				DragGroupName = @"EventSubProcess",
				EntitySchemaUId = Guid.Empty,
				IsExpanded = true,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0824af03-1340-47a3-8787-ef542f566992"),
				ModifiedInSchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"),
				Name = @"EventSubProcess4",
				Position = new Point(813, 114),
				SchemaUId = Guid.Empty,
				SerializeToDB = false,
				Size = new Size(511, 158),
				TriggeredByEvent = true,
				UseBackgroundMode = false,
				UseLastSchemaVersion = false
			};
			
			return schemaEventSubProcess4;
		}

		protected virtual ProcessSchemaStartMessageEvent CreateStartMessage1StartMessageEvent() {
			ProcessSchemaStartMessageEvent schemaStartMessageEvent = new ProcessSchemaStartMessageEvent(this) {
				UId = new Guid("92871b4f-382d-42ab-8800-564ecaba2f0a"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = new Guid("2fc7d8c0-3543-41ee-bebc-75fa4ce6ec80"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				ImageList = null,
				ImageName = null,
				IsInterrupting = false,
				IsLogging = true,
				ManagerItemUId = new Guid("02340c80-8e75-4f7a-917b-04125bc07192"),
				Message = @"NoConfirmMessage",
				ModifiedInSchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"),
				Name = @"StartMessage1",
				Position = new Point(22, 37),
				SerializeToDB = false,
				Size = new Size(27, 27),
				UseBackgroundMode = false
			};
			
			return schemaStartMessageEvent;
		}

		protected virtual ProcessSchemaStartMessageEvent CreateStartMessage2StartMessageEvent() {
			ProcessSchemaStartMessageEvent schemaStartMessageEvent = new ProcessSchemaStartMessageEvent(this) {
				UId = new Guid("b359fd68-27be-4b79-b92b-9e9d94ab5dd6"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = new Guid("2fc7d8c0-3543-41ee-bebc-75fa4ce6ec80"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				ImageList = null,
				ImageName = null,
				IsInterrupting = false,
				IsLogging = true,
				ManagerItemUId = new Guid("02340c80-8e75-4f7a-917b-04125bc07192"),
				Message = @"YesConfirmMessage",
				ModifiedInSchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"),
				Name = @"StartMessage2",
				Position = new Point(183, 100),
				SerializeToDB = false,
				Size = new Size(27, 27),
				UseBackgroundMode = false
			};
			
			return schemaStartMessageEvent;
		}

		protected virtual ProcessSchemaScriptTask CreateScriptTask7ScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("caceadab-4ab9-4bac-ae41-dcfa07e60739"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = new Guid("2fc7d8c0-3543-41ee-bebc-75fa4ce6ec80"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"),
				Name = @"ScriptTask7",
				Position = new Point(92, 23),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,101,206,177,10,194,48,20,64,209,185,249,138,103,166,4,74,126,160,56,72,41,210,69,10,165,56,199,228,21,3,105,82,211,23,170,136,255,174,232,36,221,239,129,235,70,16,39,92,251,104,156,246,7,99,98,14,212,90,216,237,225,152,157,85,205,52,211,67,194,147,21,1,87,24,102,171,9,197,176,96,170,99,8,104,200,197,80,2,255,211,92,178,162,80,61,146,224,93,190,120,103,120,9,117,244,121,10,170,211,73,79,72,152,196,168,253,130,242,91,158,175,152,80,240,214,114,169,218,165,185,101,237,197,166,223,46,254,112,115,71,147,63,75,178,98,47,150,144,114,10,64,41,99,245,6,210,7,197,195,216,0,0,0 }
			};
			
			return ScriptTask;
		}

		protected virtual ProcessSchemaScriptTask CreateScriptTask8ScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("2103381a-b1fb-45ae-aebb-3a17c470d89e"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = new Guid("2fc7d8c0-3543-41ee-bebc-75fa4ce6ec80"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"),
				Name = @"ScriptTask8",
				Position = new Point(315, 49),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,11,174,44,46,73,205,213,11,79,77,210,243,40,41,41,112,206,207,43,73,173,40,209,115,46,45,42,74,205,43,209,11,74,45,46,200,207,43,78,5,50,82,50,139,82,147,75,52,130,9,105,40,44,77,45,6,210,137,229,161,69,57,154,214,92,69,169,37,165,69,121,10,37,69,165,169,214,0,4,250,253,74,109,0,0,0 }
			};
			
			return ScriptTask;
		}

		protected virtual ProcessSchemaEndEvent CreateEnd2EndEvent() {
			ProcessSchemaEndEvent schemaEndEvent = new ProcessSchemaEndEvent(this) {
				UId = new Guid("5246cd69-4c89-426f-a40c-94980486f720"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = new Guid("2fc7d8c0-3543-41ee-bebc-75fa4ce6ec80"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsLogging = true,
				ManagerItemUId = new Guid("45ceaae2-4e1f-4c0c-86aa-cd4aeb4da913"),
				ModifiedInSchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"),
				Name = @"End2",
				Position = new Point(427, 63),
				SerializeToDB = false,
				Size = new Size(27, 27),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaEndEvent;
		}

		protected virtual ProcessSchemaStartEvent CreateStart1StartEvent() {
			ProcessSchemaStartEvent schemaStartEvent = new ProcessSchemaStartEvent(this) {
				UId = new Guid("f2cfd8e7-b706-4cdc-ab23-ca9d82dbb0c3"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = new Guid("56df13cc-24aa-4d5f-8160-0460b9161acd"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsInterrupting = false,
				IsLogging = true,
				ManagerItemUId = new Guid("53818048-7868-48f6-ada0-0ebaa65af628"),
				ModifiedInSchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"),
				Name = @"Start1",
				Position = new Point(78, 156),
				SerializeToDB = false,
				Size = new Size(27, 27),
				UseBackgroundMode = false
			};
			
			return schemaStartEvent;
		}

		protected virtual ProcessSchemaScriptTask CreateScriptTask4ScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("e0108a76-0864-455f-ac82-95521b00e280"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = new Guid("56df13cc-24aa-4d5f-8160-0460b9161acd"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"),
				Name = @"ScriptTask4",
				Position = new Point(190, 142),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,149,141,177,14,194,48,16,67,247,126,69,190,32,253,128,136,1,101,202,2,72,208,15,56,93,45,84,21,221,161,203,69,252,62,132,78,44,149,216,108,203,246,203,6,114,92,149,23,122,28,153,181,137,79,21,118,163,186,198,45,61,193,95,106,107,56,132,31,159,134,188,51,237,162,204,159,77,23,89,69,192,190,168,196,220,204,176,245,98,153,211,48,142,97,239,230,15,226,249,9,129,93,232,142,47,183,72,117,18,198,212,41,6,111,38,193,173,33,189,1,202,16,158,172,241,0,0,0 }
			};
			
			return ScriptTask;
		}

		protected virtual ProcessSchemaUserTask CreateCreateSocialAccountUserTaskUserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("71febcbb-2f80-4258-9e38-210a2188c99f"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = new Guid("56df13cc-24aa-4d5f-8160-0460b9161acd"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("1418e61a-82c3-403e-8221-01088f52c125"),
				ModifiedInSchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"),
				Name = @"CreateSocialAccountUserTask",
				Position = new Point(316, 142),
				SchemaUId = new Guid("4c647b90-1d28-415a-8393-3699e8ed5e25"),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] {  }
			};
			InitializeCreateSocialAccountUserTaskParameters(schemaTask);
			return schemaTask;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeUsings() {
			Usings.Add(new SchemaUsing() {
				UId = new Guid("c6d99c62-8eeb-4c4a-a003-fd57aa3ad9b8"),
				Name = "Terrasoft.Common",
				Alias = "",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("e5c0f419-1ac4-460f-94ff-1cd00ef81561"),
				Name = "Terrasoft.Common.Json",
				Alias = "",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("faff42c8-6ee8-4c83-8a52-58fbf3f70692"),
				Name = "Terrasoft.Core.Configuration",
				Alias = "",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("8ba21389-7e56-4bdf-93f2-ce66cfd49c73"),
				Name = "Terrasoft.Social",
				Alias = "",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			});
		}

		#endregion

		#region Methods: Public

		public override Process CreateProcess(UserConnection userConnection) {
			return new CreateSocialAccountProcess(userConnection);
		}

		public override object Clone() {
			return new CreateSocialAccountProcessSchema(this);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"));
		}

		#endregion

	}

	#endregion

	#region Class: CreateSocialAccountProcess

	/// <exclude/>
	public class CreateSocialAccountProcess : Terrasoft.Core.Process.Process
	{

		#region Class: ProcessLane1

		/// <exclude/>
		public class ProcessLane1 : ProcessLane
		{

			public ProcessLane1(UserConnection userConnection, CreateSocialAccountProcess process)
				: base(userConnection) {
				Owner = process;
				IsUsedParentUserContexts = false;
			}

		}

		#endregion

		#region Class: OpenMessageWindowFlowElement

		/// <exclude/>
		public class OpenMessageWindowFlowElement : QuestionUserTask
		{

			#region Constructors: Public

			public OpenMessageWindowFlowElement(UserConnection userConnection, CreateSocialAccountProcess process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "OpenMessageWindow";
				IsLogging = true;
				SchemaElementUId = new Guid("a076b343-35fb-4593-b863-c0008611e92e");
				CreatedInSchemaUId = process.InternalSchemaUId;
			}

			#endregion

		}

		#endregion

		#region Class: CreateSocialAccountUserTaskFlowElement

		/// <exclude/>
		public class CreateSocialAccountUserTaskFlowElement : CreateSocialAccountUserTask
		{

			#region Constructors: Public

			public CreateSocialAccountUserTaskFlowElement(UserConnection userConnection, CreateSocialAccountProcess process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "CreateSocialAccountUserTask";
				IsLogging = true;
				SchemaElementUId = new Guid("71febcbb-2f80-4258-9e38-210a2188c99f");
				CreatedInSchemaUId = process.InternalSchemaUId;
			}

			#endregion

		}

		#endregion

		public CreateSocialAccountProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "CreateSocialAccountProcess";
			SchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78");
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
				return new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78");
			}
		}

		private string ConditionalExpressionLogMessage {
			get {
				return "Process: CreateSocialAccountProcess, Source element: {0}, Conditional flow: {1}, Expression: {2}, Result: {3}";
			}
		}

		private string DeadEndGatewayLogMessage {
			get {
				return "Process: CreateSocialAccountProcess, Source element: {0}, None of the exclusive gateway conditions are met!";
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

		public virtual Guid NewSocialAccountId {
			get;
			set;
		}

		public virtual Object Page {
			get;
			set;
		}

		public virtual string SocialNetwork {
			get;
			set;
		}

		private LocalizableString _applyAccountPublicLS;
		public virtual LocalizableString ApplyAccountPublicLS {
			get {
				return _applyAccountPublicLS ?? (_applyAccountPublicLS = GetLocalizableString("e6eba3a093894e9384325c0d5f2a6a78",
						 "Parameters.ApplyAccountPublicLS.Value"));
			}
			set {
				_applyAccountPublicLS = value;
			}
		}

		private ProcessLane1 _lane1;
		public ProcessLane1 Lane1 {
			get {
				return _lane1 ?? ((_lane1) = new ProcessLane1(UserConnection, this));
			}
		}

		private ProcessFlowElement _eventSubProcess2;
		public ProcessFlowElement EventSubProcess2 {
			get {
				return _eventSubProcess2 ?? (_eventSubProcess2 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "EventSubProcess2",
					SchemaElementUId = new Guid("11ff12e8-b36f-4c21-bb0b-7abd0d9184c1"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
				});
			}
		}

		private ProcessFlowElement _socialAccountCreatedSuccessfullyEventStartMessage;
		public ProcessFlowElement SocialAccountCreatedSuccessfullyEventStartMessage {
			get {
				return _socialAccountCreatedSuccessfullyEventStartMessage ?? (_socialAccountCreatedSuccessfullyEventStartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "SocialAccountCreatedSuccessfullyEventStartMessage",
					SchemaElementUId = new Guid("7816b0d8-3bb7-4490-ba7b-51b52c04338f"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
				});
			}
		}

		private ProcessScriptTask _scriptTask6;
		public ProcessScriptTask ScriptTask6 {
			get {
				return _scriptTask6 ?? (_scriptTask6 = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ScriptTask6",
					SchemaElementUId = new Guid("f62fedb3-46b3-4d33-8de6-90196a27368a"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = ScriptTask6Execute,
				});
			}
		}

		private OpenMessageWindowFlowElement _openMessageWindow;
		public OpenMessageWindowFlowElement OpenMessageWindow {
			get {
				return _openMessageWindow ?? (_openMessageWindow = new OpenMessageWindowFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private ProcessFlowElement _eventSubProcess3;
		public ProcessFlowElement EventSubProcess3 {
			get {
				return _eventSubProcess3 ?? (_eventSubProcess3 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "EventSubProcess3",
					SchemaElementUId = new Guid("d948e393-a56e-49a8-ae90-e9609779fea6"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
				});
			}
		}

		private ProcessFlowElement _socialAccountCreationFailedEventStartMessage;
		public ProcessFlowElement SocialAccountCreationFailedEventStartMessage {
			get {
				return _socialAccountCreationFailedEventStartMessage ?? (_socialAccountCreationFailedEventStartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "SocialAccountCreationFailedEventStartMessage",
					SchemaElementUId = new Guid("f4b0a237-00b7-4e35-b604-f9d844eaa29e"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
				});
			}
		}

		private ProcessScriptTask _scriptTask5;
		public ProcessScriptTask ScriptTask5 {
			get {
				return _scriptTask5 ?? (_scriptTask5 = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ScriptTask5",
					SchemaElementUId = new Guid("a9c60992-1b92-42f9-8053-8089951711ca"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = ScriptTask5Execute,
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
					SchemaElementUId = new Guid("68617c70-36fb-4a3a-a32e-cc51ec4a95d2"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
				});
			}
		}

		private ProcessFlowElement _eventSubProcess4;
		public ProcessFlowElement EventSubProcess4 {
			get {
				return _eventSubProcess4 ?? (_eventSubProcess4 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "EventSubProcess4",
					SchemaElementUId = new Guid("2fc7d8c0-3543-41ee-bebc-75fa4ce6ec80"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
				});
			}
		}

		private ProcessFlowElement _startMessage1;
		public ProcessFlowElement StartMessage1 {
			get {
				return _startMessage1 ?? (_startMessage1 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "StartMessage1",
					SchemaElementUId = new Guid("92871b4f-382d-42ab-8800-564ecaba2f0a"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
				});
			}
		}

		private ProcessFlowElement _startMessage2;
		public ProcessFlowElement StartMessage2 {
			get {
				return _startMessage2 ?? (_startMessage2 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "StartMessage2",
					SchemaElementUId = new Guid("b359fd68-27be-4b79-b92b-9e9d94ab5dd6"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
				});
			}
		}

		private ProcessScriptTask _scriptTask7;
		public ProcessScriptTask ScriptTask7 {
			get {
				return _scriptTask7 ?? (_scriptTask7 = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ScriptTask7",
					SchemaElementUId = new Guid("caceadab-4ab9-4bac-ae41-dcfa07e60739"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = ScriptTask7Execute,
				});
			}
		}

		private ProcessScriptTask _scriptTask8;
		public ProcessScriptTask ScriptTask8 {
			get {
				return _scriptTask8 ?? (_scriptTask8 = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ScriptTask8",
					SchemaElementUId = new Guid("2103381a-b1fb-45ae-aebb-3a17c470d89e"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = ScriptTask8Execute,
				});
			}
		}

		private ProcessEndEvent _end2;
		public ProcessEndEvent End2 {
			get {
				return _end2 ?? (_end2 = new ProcessEndEvent() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEndEvent",
					Name = "End2",
					SchemaElementUId = new Guid("5246cd69-4c89-426f-a40c-94980486f720"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
				});
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
					SchemaElementUId = new Guid("f2cfd8e7-b706-4cdc-ab23-ca9d82dbb0c3"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
				});
			}
		}

		private ProcessScriptTask _scriptTask4;
		public ProcessScriptTask ScriptTask4 {
			get {
				return _scriptTask4 ?? (_scriptTask4 = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ScriptTask4",
					SchemaElementUId = new Guid("e0108a76-0864-455f-ac82-95521b00e280"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = ScriptTask4Execute,
				});
			}
		}

		private CreateSocialAccountUserTaskFlowElement _createSocialAccountUserTask;
		public CreateSocialAccountUserTaskFlowElement CreateSocialAccountUserTask {
			get {
				return _createSocialAccountUserTask ?? (_createSocialAccountUserTask = new CreateSocialAccountUserTaskFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[EventSubProcess2.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess2 };
			FlowElements[SocialAccountCreatedSuccessfullyEventStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { SocialAccountCreatedSuccessfullyEventStartMessage };
			FlowElements[ScriptTask6.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptTask6 };
			FlowElements[OpenMessageWindow.SchemaElementUId] = new Collection<ProcessFlowElement> { OpenMessageWindow };
			FlowElements[EventSubProcess3.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess3 };
			FlowElements[SocialAccountCreationFailedEventStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { SocialAccountCreationFailedEventStartMessage };
			FlowElements[ScriptTask5.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptTask5 };
			FlowElements[End1.SchemaElementUId] = new Collection<ProcessFlowElement> { End1 };
			FlowElements[EventSubProcess4.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess4 };
			FlowElements[StartMessage1.SchemaElementUId] = new Collection<ProcessFlowElement> { StartMessage1 };
			FlowElements[StartMessage2.SchemaElementUId] = new Collection<ProcessFlowElement> { StartMessage2 };
			FlowElements[ScriptTask7.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptTask7 };
			FlowElements[ScriptTask8.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptTask8 };
			FlowElements[End2.SchemaElementUId] = new Collection<ProcessFlowElement> { End2 };
			FlowElements[Start1.SchemaElementUId] = new Collection<ProcessFlowElement> { Start1 };
			FlowElements[ScriptTask4.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptTask4 };
			FlowElements[CreateSocialAccountUserTask.SchemaElementUId] = new Collection<ProcessFlowElement> { CreateSocialAccountUserTask };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "EventSubProcess2":
						break;
					case "SocialAccountCreatedSuccessfullyEventStartMessage":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ScriptTask6", e.Context.SenderName));
						break;
					case "ScriptTask6":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("OpenMessageWindow", e.Context.SenderName));
						break;
					case "OpenMessageWindow":
						break;
					case "EventSubProcess3":
						break;
					case "SocialAccountCreationFailedEventStartMessage":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ScriptTask5", e.Context.SenderName));
						break;
					case "ScriptTask5":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("End1", e.Context.SenderName));
						break;
					case "End1":
						CompleteProcess();
						break;
					case "EventSubProcess4":
						break;
					case "StartMessage1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ScriptTask7", e.Context.SenderName));
						break;
					case "StartMessage2":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ScriptTask8", e.Context.SenderName));
						break;
					case "ScriptTask7":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ScriptTask8", e.Context.SenderName));
						break;
					case "ScriptTask8":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("End2", e.Context.SenderName));
						break;
					case "End2":
						CompleteProcess();
						break;
					case "Start1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ScriptTask4", e.Context.SenderName));
						break;
					case "ScriptTask4":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("CreateSocialAccountUserTask", e.Context.SenderName));
						break;
					case "CreateSocialAccountUserTask":
						break;
			}
		}

		private void WritePropertyValues(DataWriter writer, bool useAllValueSources) {
			if (!HasMapping("NewSocialAccountId")) {
				writer.WriteValue("NewSocialAccountId", NewSocialAccountId, Guid.Empty);
			}
			if (!HasMapping("SocialNetwork")) {
				writer.WriteValue("SocialNetwork", SocialNetwork, null);
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
			ActivatedEventElements.Add("SocialAccountCreatedSuccessfullyEventStartMessage");
			ActivatedEventElements.Add("SocialAccountCreationFailedEventStartMessage");
			ActivatedEventElements.Add("StartMessage1");
			ActivatedEventElements.Add("StartMessage2");
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
			MetaPathParameterValues.Add("f263dd85-d3cd-4c40-b168-ae8daff43524", () => NewSocialAccountId);
			MetaPathParameterValues.Add("b1d146ff-40e8-4a5d-8b94-206a62e7f944", () => Page);
			MetaPathParameterValues.Add("4e3fdba2-8339-42ed-860d-a7d96d66d755", () => SocialNetwork);
			MetaPathParameterValues.Add("bce9a8f0-f858-4156-8a65-8715d4c703dc", () => ApplyAccountPublicLS);
			MetaPathParameterValues.Add("ffaca191-2916-4e64-80ef-3d900be58e07", () => OpenMessageWindow.Page);
			MetaPathParameterValues.Add("0c05c81a-1734-431a-88b8-61dc5472c229", () => OpenMessageWindow.Icon);
			MetaPathParameterValues.Add("68b45479-94c9-49fb-8c83-4703bccc4fcd", () => OpenMessageWindow.Buttons);
			MetaPathParameterValues.Add("559e2e0e-1702-4631-8932-e2df756aa0c6", () => OpenMessageWindow.WindowCaption);
			MetaPathParameterValues.Add("34aec6b7-5646-46a9-b104-d0fda1835eab", () => OpenMessageWindow.MessageText);
			MetaPathParameterValues.Add("3348ed5e-3ee7-4dc4-8334-1f5ad4953e28", () => OpenMessageWindow.ResponseMessages);
			MetaPathParameterValues.Add("a0058817-6d78-4f09-bad5-d0162d5a9dfa", () => OpenMessageWindow.ProcessInstanceId);
			MetaPathParameterValues.Add("751da741-9f8e-4532-a1a1-f34181368335", () => OpenMessageWindow.PageParameters);
			MetaPathParameterValues.Add("1000931d-1c32-448b-ba0e-c66614e147a8", () => CreateSocialAccountUserTask.UserId);
			MetaPathParameterValues.Add("a7b8a6fa-cf86-4400-90f5-45a23bd10537", () => CreateSocialAccountUserTask.SocialNetwork);
			MetaPathParameterValues.Add("96037c02-c530-4081-ab43-d03411c92f27", () => CreateSocialAccountUserTask.OpenerPageId);
			MetaPathParameterValues.Add("af330e9a-f3cb-4089-83f8-c51d5ecdc938", () => CreateSocialAccountUserTask.SuccessEventName);
			MetaPathParameterValues.Add("fdbe7b1a-f0fd-4541-b4fd-f3aa818a61e4", () => CreateSocialAccountUserTask.FailedEventName);
		}

		protected override void ApplyPropertiesDataValues(DataReader reader) {
			base.ApplyPropertiesDataValues(reader);
			bool hasValueToRead = reader.HasValue();
			switch (reader.CurrentName) {
				case "NewSocialAccountId":
					if (!hasValueToRead) break;
					NewSocialAccountId = reader.GetValue<System.Guid>();
				break;
				case "SocialNetwork":
					if (!hasValueToRead) break;
					SocialNetwork = reader.GetValue<System.String>();
				break;
			}
		}

		protected override void WritePropertyValues(DataWriter writer) {
			base.WritePropertyValues(writer);
			WritePropertyValues(writer, true);
		}

		#endregion

		#region Methods: Public

		public virtual bool ScriptTask6Execute(ProcessExecutingContext context) {
			string claim = context.ThrowEventArgs.ToString();
			
			var jclaim = (JToken)Json.Deserialize(claim);
			var token = ((JValue)jclaim["Token"]).Value.ToString();
			var secret = ((JValue)jclaim["Secret"]).Value.ToString();
			var socialId = ((JValue)jclaim["SocialId"]).Value.ToString();
			var userId = UserConnection.CurrentUser.Id;
			
			var socialNetwork = CreateSocialAccountUserTask.SocialNetwork;
			var socialNetworkId = (new Select(UserConnection).Top(1)
				.Column("Id")
				.From("CommunicationType")
				.Where("Name").IsEqual(Column.Parameter(socialNetwork)) as Select)
				.ExecuteScalar<Guid>();
				
			Func<string, string> systemValue = (name) => {
				 var value = SysSettings.GetValue(UserConnection, socialNetwork + name);
				 if (value != null) {
					 return value.ToString();
				 }
				 throw new ArgumentNullOrEmptyException("SystemValue." + socialNetwork + name);
			};
			
			string login = "System";
			var network = SocialCommutator.CreateSocialNetwork(UserConnection, socialNetwork); 
			try {
			login = network.GetProfile(socialId).Name;
			} catch{
			}
			
			var schema = UserConnection.EntitySchemaManager.GetInstanceByName("SocialAccount");
			var entity = schema.CreateEntity(UserConnection);
			entity.SetDefColumnValues();
			entity.SetColumnValue("UserId", userId);
			entity.SetColumnValue("Login", login);
			entity.SetColumnValue("AccessToken", token);
			entity.SetColumnValue("AccessSecretToken", secret);
			entity.SetColumnValue("SocialId", socialId);
			entity.SetColumnValue("TypeId", socialNetworkId);
			entity.SetColumnValue("ConsumerKey", systemValue("ConsumerKey"));
			entity.Save();
			
			NewSocialAccountId = entity.PrimaryColumnValue;
			
			new Delete(UserConnection).From("SocialAccount")
				.Where("UserId").IsEqual(Column.Parameter(userId))
				.And("IsExpired").IsEqual(Column.Parameter(true))
				.Execute();
			
			OpenMessageWindow.Page = Page;
			OpenMessageWindow.MessageText = ApplyAccountPublicLS;
			OpenMessageWindow.Icon = "QUESTION";
			OpenMessageWindow.Buttons = "YESNO";
			OpenMessageWindow.ResponseMessages = new Dictionary<string, string> {
			       {"yes", "YesConfirmMessage"},
			       {"no", "NoConfirmMessage"}                                                           
			 };
			 
			 // System.Web.HttpContext.Current.Response.Redirect(System.Web.HttpContext.Current.Request.RawUrl);
			
			return true;
		}

		public virtual bool ScriptTask5Execute(ProcessExecutingContext context) {
			return true;
		}

		public virtual bool ScriptTask7Execute(ProcessExecutingContext context) {
			if (NewSocialAccountId != Guid.Empty) {
				new Update(UserConnection, "SocialAccount")
					.Set("Public", Column.Parameter(false))
					.Where("Id").IsEqual(Column.Parameter(NewSocialAccountId))
					.Execute();
			}
			return true;
		}

		public virtual bool ScriptTask8Execute(ProcessExecutingContext context) {
			System.Web.HttpContext.Current.Response.Redirect(System.Web.HttpContext.Current.Request.RawUrl);
			return true;
		}

		public virtual bool ScriptTask4Execute(ProcessExecutingContext context) {
			CreateSocialAccountUserTask.SocialNetwork = SocialNetwork;
			CreateSocialAccountUserTask.UserId = UserConnection.CurrentUser.Id;
			// CreateSocialAccountUserTask.SocialNetwork;
			CreateSocialAccountUserTask.OpenerPageId = InstanceUId;
			return true;
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "SocialAccountCreatedSuccessfullyEvent":
							if (ActivatedEventElements.Contains("SocialAccountCreatedSuccessfullyEventStartMessage")) {
							context.QueueTasksV2.Enqueue(new ProcessQueueElement("SocialAccountCreatedSuccessfullyEventStartMessage", "SocialAccountCreatedSuccessfullyEventStartMessage"));
						}
						break;
					case "SocialAccountCreationFailedEvent":
							if (ActivatedEventElements.Contains("SocialAccountCreationFailedEventStartMessage")) {
							context.QueueTasksV2.Enqueue(new ProcessQueueElement("SocialAccountCreationFailedEventStartMessage", "SocialAccountCreationFailedEventStartMessage"));
						}
						break;
					case "NoConfirmMessage":
							if (ActivatedEventElements.Contains("StartMessage1")) {
							context.QueueTasksV2.Enqueue(new ProcessQueueElement("StartMessage1", "StartMessage1"));
						}
						break;
					case "YesConfirmMessage":
							if (ActivatedEventElements.Contains("StartMessage2")) {
							context.QueueTasksV2.Enqueue(new ProcessQueueElement("StartMessage2", "StartMessage2"));
						}
						break;
			}
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
			var cloneItem = (CreateSocialAccountProcess)base.CloneShallow();
			cloneItem.ExecutedEventHandler = ExecutedEventHandler;
			cloneItem.Page = Page;
			return cloneItem;
		}

		#endregion

	}

	#endregion

}

