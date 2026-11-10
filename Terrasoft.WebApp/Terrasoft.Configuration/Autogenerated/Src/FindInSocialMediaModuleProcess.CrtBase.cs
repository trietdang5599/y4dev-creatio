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
	using Terrasoft.Core.Store;
	using Terrasoft.Social;

	#region Class: FindInSocialMediaModuleProcessSchema

	/// <exclude/>
	public class FindInSocialMediaModuleProcessSchema : Terrasoft.Core.Process.ProcessSchema
	{

		#region Constructors: Public

		public FindInSocialMediaModuleProcessSchema(ProcessSchemaManager processSchemaManager)
			: base(processSchemaManager) {
		}

		public FindInSocialMediaModuleProcessSchema(FindInSocialMediaModuleProcessSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			Name = "FindInSocialMediaModuleProcess";
			UId = new Guid("d389027a-6008-40cd-b17b-623d1d1344c1");
			BackgroundModePriority = BackgroundModePriority.Medium;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			CreatedInSchemaUId = Guid.Empty;
			CreatedInVersion = @"0.0.0.0";
			CultureName = @"en-US";
			EntitySchemaUId = Guid.Empty;
			IsCreatedInSvg = true;
			IsLogging = false;
			MaxLoopCount = 101;
			ModifiedInSchemaUId = Guid.Empty;
			ParametersEditPageSchemaUId = Guid.Empty;
			ParentSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d");
			SequenceFlowStrokeDefColor = Color.FromArgb(-4473925);
			SerializeToDB = false;
			SerializeToMemory = true;
			TaskFillDefColor = Color.FromArgb(-1);
			UsageType = ProcessSchemaUsageType.Advanced;
			ZipMethodsBody = new byte[] {  };
			ZipCompiledMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,165,146,193,110,194,48,12,134,207,139,212,119,200,56,181,18,234,11,84,59,12,182,162,74,219,52,49,182,203,180,131,73,93,136,72,157,201,117,64,8,241,238,43,148,105,192,97,211,68,14,81,98,199,223,47,255,78,164,62,195,212,89,163,151,150,37,128,211,19,100,134,198,87,146,14,61,85,118,22,24,196,122,218,221,4,140,232,17,202,225,24,39,122,19,169,171,37,176,54,93,228,197,204,177,6,125,163,95,27,228,246,21,161,217,215,222,147,88,89,119,217,71,32,152,33,167,45,167,160,70,128,12,14,214,79,80,99,220,59,112,123,73,166,142,160,45,238,4,159,14,25,65,176,99,198,167,74,137,134,230,175,14,50,53,245,222,233,10,197,204,199,216,4,119,164,144,230,187,104,206,190,190,27,196,167,170,207,108,107,224,245,208,187,80,83,95,223,182,122,75,156,48,226,136,109,57,12,204,72,50,246,171,162,236,107,194,213,251,135,222,40,253,251,58,235,106,15,110,210,220,82,57,56,200,188,129,11,216,121,179,219,123,73,95,93,117,235,191,229,147,149,21,65,46,202,11,24,15,150,22,88,22,116,17,36,7,131,173,255,139,14,114,110,201,182,29,189,173,116,124,125,52,157,100,111,228,207,103,160,224,92,166,182,138,81,2,211,119,34,139,212,54,82,145,250,2,105,44,15,116,208,2,0,0 };
			RealUId = new Guid("d389027a-6008-40cd-b17b-623d1d1344c1");
			Version = 0;
			PackageUId = new Guid("06d9ef10-51d8-122c-8933-9212e84236c9");
			UseSystemSecurityContext = false;
		}

		protected virtual ProcessSchemaParameter CreatePageInstanceIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("5395b142-e19d-4404-9832-d0dd0018dc8a"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("d389027a-6008-40cd-b17b-623d1d1344c1"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("d389027a-6008-40cd-b17b-623d1d1344c1"),
				Name = @"PageInstanceId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Text"),
			};
		}

		protected virtual ProcessSchemaParameter CreateActiveTreeGridCurrentRowIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("b16d44d3-07fb-4a3f-9150-1d70ebfcc516"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("d389027a-6008-40cd-b17b-623d1d1344c1"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("d389027a-6008-40cd-b17b-623d1d1344c1"),
				Name = @"ActiveTreeGridCurrentRowId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid"),
			};
		}

		protected virtual ProcessSchemaParameter CreateSocialUsersKeyParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("cec9d094-514a-47ec-943c-abcaee182be1"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("d389027a-6008-40cd-b17b-623d1d1344c1"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("d389027a-6008-40cd-b17b-623d1d1344c1"),
				Name = @"SocialUsersKey",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Text"),
			};
		}

		protected virtual ProcessSchemaParameter CreateSocialNetworksParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("856f4570-e2c1-421a-8b36-1ca4fdc9ffca"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("d389027a-6008-40cd-b17b-623d1d1344c1"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("d389027a-6008-40cd-b17b-623d1d1344c1"),
				Name = @"SocialNetworks",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Text"),
			};
		}

		protected virtual ProcessSchemaParameter CreateSearchCriteriaParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("24e84ec1-16cf-46da-8db6-13db647a3fd2"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("d389027a-6008-40cd-b17b-623d1d1344c1"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("d389027a-6008-40cd-b17b-623d1d1344c1"),
				Name = @"SearchCriteria",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Text"),
			};
		}

		protected virtual ProcessSchemaParameter CreateMatchesFoundPageUIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("fa5b71ac-faa8-480c-863b-78eedcb9e206"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("d389027a-6008-40cd-b17b-623d1d1344c1"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("d389027a-6008-40cd-b17b-623d1d1344c1"),
				Name = @"MatchesFoundPageUId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid"),
			};
		}

		protected virtual ProcessSchemaParameter CreateHeightParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("d9c957b1-ccc6-4858-98d6-88e8e3300945"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("d389027a-6008-40cd-b17b-623d1d1344c1"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("d389027a-6008-40cd-b17b-623d1d1344c1"),
				Name = @"Height",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Integer"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.Script,
					Value = @"350",
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("d389027a-6008-40cd-b17b-623d1d1344c1"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateWidthParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("353019c4-47a0-4f83-b00f-3c00a7c5e9be"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("d389027a-6008-40cd-b17b-623d1d1344c1"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("d389027a-6008-40cd-b17b-623d1d1344c1"),
				Name = @"Width",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Integer"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.Script,
					Value = @"550",
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("d389027a-6008-40cd-b17b-623d1d1344c1"),
				},
			};
		}

		protected override void InitializeParameters() {
			base.InitializeParameters();
			Parameters.Add(CreatePageInstanceIdParameter());
			Parameters.Add(CreateActiveTreeGridCurrentRowIdParameter());
			Parameters.Add(CreateSocialUsersKeyParameter());
			Parameters.Add(CreateSocialNetworksParameter());
			Parameters.Add(CreateSearchCriteriaParameter());
			Parameters.Add(CreateMatchesFoundPageUIdParameter());
			Parameters.Add(CreateHeightParameter());
			Parameters.Add(CreateWidthParameter());
		}

		protected virtual void InitializeOpenMatchFoundWindowUserTaskParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var pageUIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("e2e21ba3-bb6d-4e10-bce5-4bf650d7b7ba"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerUId = new Guid("e1632db6-b725-48a3-8c30-3e992b0923af"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b7042ef4-f468-443e-b3ea-39ebbda1c828"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b7042ef4-f468-443e-b3ea-39ebbda1c828"),
				Name = @"PageUId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid")
			};
			pageUIdParameter.SourceValue = new ProcessSchemaParameterValue(pageUIdParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(pageUIdParameter);
			var pageUrlParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("e594e5b0-c983-486b-9113-8c72c303d9e0"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerUId = new Guid("e1632db6-b725-48a3-8c30-3e992b0923af"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b7042ef4-f468-443e-b3ea-39ebbda1c828"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b7042ef4-f468-443e-b3ea-39ebbda1c828"),
				Name = @"PageUrl",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Text")
			};
			pageUrlParameter.SourceValue = new ProcessSchemaParameterValue(pageUrlParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(pageUrlParameter);
			var openerInstanceIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("7452b4c9-d854-4ac1-9357-9fef2d645f5b"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerUId = new Guid("e1632db6-b725-48a3-8c30-3e992b0923af"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b7042ef4-f468-443e-b3ea-39ebbda1c828"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b7042ef4-f468-443e-b3ea-39ebbda1c828"),
				Name = @"OpenerInstanceId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Text")
			};
			openerInstanceIdParameter.SourceValue = new ProcessSchemaParameterValue(openerInstanceIdParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(openerInstanceIdParameter);
			var closeOpenerOnLoadParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("c02dadae-f305-4ee0-b2a3-d048ef78be5b"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerUId = new Guid("e1632db6-b725-48a3-8c30-3e992b0923af"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b7042ef4-f468-443e-b3ea-39ebbda1c828"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b7042ef4-f468-443e-b3ea-39ebbda1c828"),
				Name = @"CloseOpenerOnLoad",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean")
			};
			closeOpenerOnLoadParameter.SourceValue = new ProcessSchemaParameterValue(closeOpenerOnLoadParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(closeOpenerOnLoadParameter);
			var pageParametersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("54158a13-96c0-4e28-bfee-17cd7c98e909"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerUId = new Guid("e1632db6-b725-48a3-8c30-3e992b0923af"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b7042ef4-f468-443e-b3ea-39ebbda1c828"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b7042ef4-f468-443e-b3ea-39ebbda1c828"),
				Name = @"PageParameters",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Object")
			};
			pageParametersParameter.SourceValue = new ProcessSchemaParameterValue(pageParametersParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(pageParametersParameter);
			var widthParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("9862e552-2baf-420c-84aa-51b1c5b87a08"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerUId = new Guid("e1632db6-b725-48a3-8c30-3e992b0923af"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b7042ef4-f468-443e-b3ea-39ebbda1c828"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b7042ef4-f468-443e-b3ea-39ebbda1c828"),
				Name = @"Width",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Integer")
			};
			widthParameter.SourceValue = new ProcessSchemaParameterValue(widthParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Parameter:{353019c4-47a0-4f83-b00f-3c00a7c5e9be}]#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("d389027a-6008-40cd-b17b-623d1d1344c1")
			};
			parametrizedElement.Parameters.Add(widthParameter);
			var closeMessageParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("4f217434-6d17-4938-b1bf-a28f71b418b5"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerUId = new Guid("e1632db6-b725-48a3-8c30-3e992b0923af"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b7042ef4-f468-443e-b3ea-39ebbda1c828"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b7042ef4-f468-443e-b3ea-39ebbda1c828"),
				Name = @"CloseMessage",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Text")
			};
			closeMessageParameter.SourceValue = new ProcessSchemaParameterValue(closeMessageParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"MatchFoundWindowClosed",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("d389027a-6008-40cd-b17b-623d1d1344c1")
			};
			parametrizedElement.Parameters.Add(closeMessageParameter);
			var heightParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("f7c8b17a-e5aa-40eb-845f-3655c06d1dc1"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerUId = new Guid("e1632db6-b725-48a3-8c30-3e992b0923af"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b7042ef4-f468-443e-b3ea-39ebbda1c828"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b7042ef4-f468-443e-b3ea-39ebbda1c828"),
				Name = @"Height",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Integer")
			};
			heightParameter.SourceValue = new ProcessSchemaParameterValue(heightParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Parameter:{d9c957b1-ccc6-4858-98d6-88e8e3300945}]#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("d389027a-6008-40cd-b17b-623d1d1344c1")
			};
			parametrizedElement.Parameters.Add(heightParameter);
			var centeredParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("22fbda9a-a82c-4aeb-a709-630d00e56f66"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerUId = new Guid("e1632db6-b725-48a3-8c30-3e992b0923af"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b7042ef4-f468-443e-b3ea-39ebbda1c828"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b7042ef4-f468-443e-b3ea-39ebbda1c828"),
				Name = @"Centered",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Object")
			};
			centeredParameter.SourceValue = new ProcessSchemaParameterValue(centeredParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(centeredParameter);
			var useOpenerRegisterScriptParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("4a197821-213b-4f40-95f9-76b973066fe0"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerUId = new Guid("e1632db6-b725-48a3-8c30-3e992b0923af"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b7042ef4-f468-443e-b3ea-39ebbda1c828"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b7042ef4-f468-443e-b3ea-39ebbda1c828"),
				Name = @"UseOpenerRegisterScript",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean")
			};
			useOpenerRegisterScriptParameter.SourceValue = new ProcessSchemaParameterValue(useOpenerRegisterScriptParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(useOpenerRegisterScriptParameter);
			var useCurrentActivePageParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("7b935efe-de49-4f8b-9fc5-6a0df3434963"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerUId = new Guid("e1632db6-b725-48a3-8c30-3e992b0923af"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b7042ef4-f468-443e-b3ea-39ebbda1c828"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b7042ef4-f468-443e-b3ea-39ebbda1c828"),
				Name = @"UseCurrentActivePage",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean")
			};
			useCurrentActivePageParameter.SourceValue = new ProcessSchemaParameterValue(useCurrentActivePageParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(useCurrentActivePageParameter);
			var ignoreProfileParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("55f3d967-cdbc-4274-a41b-a3b1936260fa"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerUId = new Guid("e1632db6-b725-48a3-8c30-3e992b0923af"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b7042ef4-f468-443e-b3ea-39ebbda1c828"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b7042ef4-f468-443e-b3ea-39ebbda1c828"),
				Name = @"IgnoreProfile",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean")
			};
			ignoreProfileParameter.SourceValue = new ProcessSchemaParameterValue(ignoreProfileParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(ignoreProfileParameter);
		}

		protected override void InitializeBaseElements() {
			base.InitializeBaseElements();
			ProcessSchemaLaneSet schemaLaneSet31 = CreateLaneSet31LaneSet();
			LaneSets.Add(schemaLaneSet31);
			ProcessSchemaLane schemaLane94 = CreateLane94Lane();
			schemaLaneSet31.Lanes.Add(schemaLane94);
			ProcessSchemaEventSubProcess eventsubprocess1 = CreateEventSubProcess1EventSubProcess();
			FlowElements.Add(eventsubprocess1);
			ProcessSchemaStartEvent start1 = CreateStart1StartEvent();
			FlowElements.Add(start1);
			ProcessSchemaScriptTask prepareopenmatchfoundwindowscripttask = CreatePrepareOpenMatchFoundWindowScriptTaskScriptTask();
			FlowElements.Add(prepareopenmatchfoundwindowscripttask);
			ProcessSchemaUserTask openmatchfoundwindowusertask = CreateOpenMatchFoundWindowUserTaskUserTask();
			FlowElements.Add(openmatchfoundwindowusertask);
			ProcessSchemaStartMessageEvent matchfoundwindowclosedmessage = CreateMatchFoundWindowClosedMessageStartMessageEvent();
			eventsubprocess1.FlowElements.Add(matchfoundwindowclosedmessage);
			ProcessSchemaScriptTask setsocialuserscripttask = CreateSetSocialUserScriptTaskScriptTask();
			eventsubprocess1.FlowElements.Add(setsocialuserscripttask);
			FlowElements.Add(CreateSequenceFlow329SequenceFlow());
			FlowElements.Add(CreateSequenceFlow1SequenceFlow());
			FlowElements.Add(CreateSequenceFlow2SequenceFlow());
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow329SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow329",
				UId = new Guid("18e153ad-338d-47ee-9a38-8f0643fcabfb"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("d389027a-6008-40cd-b17b-623d1d1344c1"),
				CurveCenterPosition = new Point(458, 352),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("d389027a-6008-40cd-b17b-623d1d1344c1"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("b4f8958c-2ef7-4cbd-9859-beabc5f460b9"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("e1632db6-b725-48a3-8c30-3e992b0923af"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow1SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow1",
				UId = new Guid("2c881e09-aade-4636-a438-52845d440ee3"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("d389027a-6008-40cd-b17b-623d1d1344c1"),
				CurveCenterPosition = new Point(181, 196),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("d389027a-6008-40cd-b17b-623d1d1344c1"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("74c6050a-d695-4efc-aa2f-1f3106bfaa82"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("b4f8958c-2ef7-4cbd-9859-beabc5f460b9"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow2SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow2",
				UId = new Guid("482ac04a-5f7d-4f0e-85f2-3f6e8262a1dd"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("d389027a-6008-40cd-b17b-623d1d1344c1"),
				CurveCenterPosition = new Point(220, 349),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("d389027a-6008-40cd-b17b-623d1d1344c1"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("90430d45-296a-4ef2-b727-db8ba2de0d37"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("85d15b6f-b750-4a1e-8403-d7b4d9aa285b"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaLaneSet CreateLaneSet31LaneSet() {
			ProcessSchemaLaneSet schemaLaneSet31 = new ProcessSchemaLaneSet(this) {
				UId = new Guid("05e99a05-3dd4-4940-b564-1e6281152e95"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 1,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("d389027a-6008-40cd-b17b-623d1d1344c1"),
				Direction = ProcessSchemaPoolDirectionType.Vertical,
				DragGroupName = @"LaneSet",
				ManagerItemUId = new Guid("11a47caf-a0d5-41fa-a274-a0b11f77447a"),
				ModifiedInSchemaUId = new Guid("d389027a-6008-40cd-b17b-623d1d1344c1"),
				Name = @"LaneSet31",
				Position = new Point(5, 5),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLaneSet31;
		}

		protected virtual ProcessSchemaLane CreateLane94Lane() {
			ProcessSchemaLane schemaLane94 = new ProcessSchemaLane(this) {
				UId = new Guid("17373d58-8938-4877-beee-b6dd74a95f65"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 1,
				ContainerUId = new Guid("05e99a05-3dd4-4940-b564-1e6281152e95"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("d389027a-6008-40cd-b17b-623d1d1344c1"),
				DragGroupName = @"Lane",
				ManagerItemUId = new Guid("abcd74b9-5912-414b-82ac-f1aa4dcd554e"),
				ModifiedInSchemaUId = new Guid("d389027a-6008-40cd-b17b-623d1d1344c1"),
				Name = @"Lane94",
				Position = new Point(29, 0),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLane94;
		}

		protected virtual ProcessSchemaStartEvent CreateStart1StartEvent() {
			ProcessSchemaStartEvent schemaStartEvent = new ProcessSchemaStartEvent(this) {
				UId = new Guid("74c6050a-d695-4efc-aa2f-1f3106bfaa82"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = new Guid("17373d58-8938-4877-beee-b6dd74a95f65"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("d389027a-6008-40cd-b17b-623d1d1344c1"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsInterrupting = false,
				IsLogging = true,
				ManagerItemUId = new Guid("53818048-7868-48f6-ada0-0ebaa65af628"),
				ModifiedInSchemaUId = new Guid("d389027a-6008-40cd-b17b-623d1d1344c1"),
				Name = @"Start1",
				Position = new Point(49, 39),
				SerializeToDB = false,
				Size = new Size(27, 27),
				UseBackgroundMode = false
			};
			
			return schemaStartEvent;
		}

		protected virtual ProcessSchemaScriptTask CreatePrepareOpenMatchFoundWindowScriptTaskScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("b4f8958c-2ef7-4cbd-9859-beabc5f460b9"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = new Guid("17373d58-8938-4877-beee-b6dd74a95f65"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("d389027a-6008-40cd-b17b-623d1d1344c1"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("d389027a-6008-40cd-b17b-623d1d1344c1"),
				Name = @"PrepareOpenMatchFoundWindowScriptTask",
				Position = new Point(160, 25),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,141,146,111,79,194,48,16,198,95,203,167,104,250,138,69,88,248,35,130,65,77,200,20,66,20,36,1,226,235,163,61,160,217,104,73,219,177,16,227,119,183,27,232,192,204,224,171,237,238,158,223,115,215,94,197,146,148,71,96,217,26,77,95,197,146,79,96,133,243,33,247,135,230,121,179,181,251,178,231,145,143,210,85,129,130,60,16,137,9,25,196,130,151,105,189,81,171,45,88,163,85,133,197,109,187,122,211,98,157,234,221,114,1,213,70,187,214,4,214,105,213,154,173,58,245,186,165,207,210,14,52,97,74,90,96,214,57,12,208,6,135,160,236,170,105,109,11,26,54,104,81,155,99,131,39,193,172,80,18,244,254,222,88,45,228,170,66,14,223,199,20,153,42,38,32,154,27,167,127,193,189,67,168,201,51,148,92,103,243,249,99,76,178,57,61,127,166,166,25,156,178,121,43,191,199,221,33,78,188,104,133,156,59,23,201,17,52,91,7,90,184,148,0,71,28,143,229,143,157,236,79,251,49,218,68,233,208,201,105,47,138,104,129,110,150,8,235,162,33,63,177,252,201,21,232,251,192,112,161,84,120,6,228,201,2,226,85,200,16,249,80,158,17,121,210,17,111,91,148,217,206,179,141,191,11,201,85,146,94,197,12,76,232,231,15,160,224,89,252,131,157,156,174,56,159,237,2,153,22,221,13,72,99,65,50,204,218,127,7,151,219,186,159,32,214,26,165,237,185,215,180,195,116,12,103,96,117,140,23,200,32,82,6,71,104,204,129,160,191,133,89,157,211,110,73,163,141,181,60,88,126,1,245,183,166,38,85,3,0,0 }
			};
			
			return ScriptTask;
		}

		protected virtual ProcessSchemaUserTask CreateOpenMatchFoundWindowUserTaskUserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("e1632db6-b725-48a3-8c30-3e992b0923af"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = new Guid("17373d58-8938-4877-beee-b6dd74a95f65"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("d389027a-6008-40cd-b17b-623d1d1344c1"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("1418e61a-82c3-403e-8221-01088f52c125"),
				ModifiedInSchemaUId = new Guid("d389027a-6008-40cd-b17b-623d1d1344c1"),
				Name = @"OpenMatchFoundWindowUserTask",
				Position = new Point(291, 25),
				SchemaUId = new Guid("b7042ef4-f468-443e-b3ea-39ebbda1c828"),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] {  }
			};
			InitializeOpenMatchFoundWindowUserTaskParameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaEventSubProcess CreateEventSubProcess1EventSubProcess() {
			ProcessSchemaEventSubProcess schemaEventSubProcess1 = new ProcessSchemaEventSubProcess(this) {
				UId = new Guid("6efae6cc-9cc3-4eb3-9ab6-a849f8b0980a"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = new Guid("17373d58-8938-4877-beee-b6dd74a95f65"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("d389027a-6008-40cd-b17b-623d1d1344c1"),
				DragGroupName = @"EventSubProcess",
				EntitySchemaUId = Guid.Empty,
				IsExpanded = true,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0824af03-1340-47a3-8787-ef542f566992"),
				ModifiedInSchemaUId = new Guid("d389027a-6008-40cd-b17b-623d1d1344c1"),
				Name = @"EventSubProcess1",
				Position = new Point(49, 126),
				SchemaUId = Guid.Empty,
				SerializeToDB = false,
				Size = new Size(294, 154),
				TriggeredByEvent = true,
				UseBackgroundMode = false,
				UseLastSchemaVersion = false
			};
			
			return schemaEventSubProcess1;
		}

		protected virtual ProcessSchemaStartMessageEvent CreateMatchFoundWindowClosedMessageStartMessageEvent() {
			ProcessSchemaStartMessageEvent schemaStartMessageEvent = new ProcessSchemaStartMessageEvent(this) {
				UId = new Guid("90430d45-296a-4ef2-b727-db8ba2de0d37"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = new Guid("6efae6cc-9cc3-4eb3-9ab6-a849f8b0980a"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("d389027a-6008-40cd-b17b-623d1d1344c1"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				ImageList = null,
				ImageName = null,
				IsInterrupting = false,
				IsLogging = true,
				ManagerItemUId = new Guid("02340c80-8e75-4f7a-917b-04125bc07192"),
				Message = @"MatchFoundWindowClosed",
				ModifiedInSchemaUId = new Guid("d389027a-6008-40cd-b17b-623d1d1344c1"),
				Name = @"MatchFoundWindowClosedMessage",
				Position = new Point(35, 56),
				SerializeToDB = false,
				Size = new Size(27, 27),
				UseBackgroundMode = false
			};
			
			return schemaStartMessageEvent;
		}

		protected virtual ProcessSchemaScriptTask CreateSetSocialUserScriptTaskScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("85d15b6f-b750-4a1e-8403-d7b4d9aa285b"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = new Guid("6efae6cc-9cc3-4eb3-9ab6-a849f8b0980a"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("d389027a-6008-40cd-b17b-623d1d1344c1"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("d389027a-6008-40cd-b17b-623d1d1344c1"),
				Name = @"SetSocialUserScriptTask",
				Position = new Point(182, 42),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,157,147,81,107,194,48,20,133,159,21,252,15,193,167,132,73,254,128,115,176,85,29,101,195,7,219,237,101,236,33,182,183,26,108,147,113,147,180,200,240,191,47,105,149,41,108,99,250,218,156,115,190,115,185,183,181,64,98,192,24,169,213,84,88,65,38,228,197,0,70,90,41,200,172,255,200,147,239,199,241,160,47,11,122,162,126,75,116,38,69,25,28,230,9,118,239,100,50,33,202,149,37,251,28,244,123,8,214,161,34,133,40,13,120,231,126,208,175,61,43,211,202,138,204,122,142,130,134,164,128,40,140,46,44,247,196,66,174,29,138,22,26,117,42,122,222,133,181,5,8,61,100,240,57,216,108,51,71,93,77,31,232,189,87,212,144,34,192,35,202,60,114,136,160,236,82,55,113,206,24,9,117,2,220,133,162,30,77,227,153,114,21,160,88,149,112,27,119,67,44,192,54,26,183,129,120,199,254,152,209,119,232,29,11,36,96,35,93,186,74,189,138,210,1,29,166,141,180,22,112,56,34,198,162,84,107,62,171,62,236,142,253,195,18,231,151,152,230,34,131,149,214,219,107,60,151,145,158,165,218,66,30,171,107,60,63,147,10,141,32,178,13,161,199,133,16,169,186,197,116,123,250,45,54,72,248,217,170,120,170,147,54,157,178,81,155,192,23,162,130,22,114,85,8,185,33,195,182,115,171,242,135,19,146,246,167,131,138,26,40,235,110,249,228,66,248,18,42,237,95,206,15,37,232,14,191,128,69,7,227,47,248,18,250,79,105,3,0,0 }
			};
			
			return ScriptTask;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeUsings() {
			Usings.Add(new SchemaUsing() {
				UId = new Guid("8c7ea91a-2e8f-4052-a58a-93461fb4d6ec"),
				Name = "Terrasoft.Social",
				Alias = "",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("7df23a63-f721-4310-b255-a7cb6cc4e6d6"),
				Name = "Terrasoft.Core.Store",
				Alias = "",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			});
		}

		#endregion

		#region Methods: Public

		public override Process CreateProcess(UserConnection userConnection) {
			return new FindInSocialMediaModuleProcess(userConnection);
		}

		public override object Clone() {
			return new FindInSocialMediaModuleProcessSchema(this);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("d389027a-6008-40cd-b17b-623d1d1344c1"));
		}

		#endregion

	}

	#endregion

	#region Class: FindInSocialMediaModuleProcess

	/// <exclude/>
	public class FindInSocialMediaModuleProcess : Terrasoft.Core.Process.Process
	{

		#region Class: ProcessLane94

		/// <exclude/>
		public class ProcessLane94 : ProcessLane
		{

			public ProcessLane94(UserConnection userConnection, FindInSocialMediaModuleProcess process)
				: base(userConnection) {
				Owner = process;
				IsUsedParentUserContexts = false;
			}

		}

		#endregion

		#region Class: OpenMatchFoundWindowUserTaskFlowElement

		/// <exclude/>
		public class OpenMatchFoundWindowUserTaskFlowElement : OpenPageUserTask
		{

			#region Constructors: Public

			public OpenMatchFoundWindowUserTaskFlowElement(UserConnection userConnection, FindInSocialMediaModuleProcess process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "OpenMatchFoundWindowUserTask";
				IsLogging = true;
				SchemaElementUId = new Guid("e1632db6-b725-48a3-8c30-3e992b0923af");
				CreatedInSchemaUId = process.InternalSchemaUId;
				_width = () => (int)((process.Width));
				_height = () => (int)((process.Height));
			}

			#endregion

			#region Properties: Public

			internal Func<int> _width;
			public override int Width {
				get {
					return (_width ?? (_width = () => 0)).Invoke();
				}
				set {
					_width = () => { return value; };
				}
			}

			private string _closeMessage;
			public override string CloseMessage {
				get {
					return _closeMessage ?? (_closeMessage = GetLocalizableString("d389027a600840cdb17b623d1d1344c1",
						 "BaseElements.OpenMatchFoundWindowUserTask.Parameters.CloseMessage.Value"));
				}
				set {
					_closeMessage = value;
				}
			}

			internal Func<int> _height;
			public override int Height {
				get {
					return (_height ?? (_height = () => 0)).Invoke();
				}
				set {
					_height = () => { return value; };
				}
			}

			#endregion

		}

		#endregion

		public FindInSocialMediaModuleProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "FindInSocialMediaModuleProcess";
			SchemaUId = new Guid("d389027a-6008-40cd-b17b-623d1d1344c1");
			Caption = Schema.Caption;
			SchemaManagerName = "ProcessSchemaManager";
			SerializeToDB = false;
			SerializeToMemory = true;
			IsLogging = false;
			UseSystemSecurityContext = false;
			_notificationCaption = () => { return new LocalizableString((Caption)); };
			_height = () => { return (int)(350); };
			_width = () => { return (int)(550); };
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("d389027a-6008-40cd-b17b-623d1d1344c1");
			}
		}

		private string ConditionalExpressionLogMessage {
			get {
				return "Process: FindInSocialMediaModuleProcess, Source element: {0}, Conditional flow: {1}, Expression: {2}, Result: {3}";
			}
		}

		private string DeadEndGatewayLogMessage {
			get {
				return "Process: FindInSocialMediaModuleProcess, Source element: {0}, None of the exclusive gateway conditions are met!";
			}
		}

		#endregion

		#region Properties: Public

		public override int MaxLoopCount {
			get {
				return 101;
			}
		}

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

		public virtual string SocialUsersKey {
			get;
			set;
		}

		public virtual string SocialNetworks {
			get;
			set;
		}

		public virtual string SearchCriteria {
			get;
			set;
		}

		public virtual Guid MatchesFoundPageUId {
			get;
			set;
		}

		private Func<int> _height;
		public virtual int Height {
			get {
				return (_height ?? (_height = () => 0)).Invoke();
			}
			set {
				_height = () => { return value; };
			}
		}

		private Func<int> _width;
		public virtual int Width {
			get {
				return (_width ?? (_width = () => 0)).Invoke();
			}
			set {
				_width = () => { return value; };
			}
		}

		private ProcessLane94 _lane94;
		public ProcessLane94 Lane94 {
			get {
				return _lane94 ?? ((_lane94) = new ProcessLane94(UserConnection, this));
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
					SchemaElementUId = new Guid("74c6050a-d695-4efc-aa2f-1f3106bfaa82"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
				});
			}
		}

		private ProcessScriptTask _prepareOpenMatchFoundWindowScriptTask;
		public ProcessScriptTask PrepareOpenMatchFoundWindowScriptTask {
			get {
				return _prepareOpenMatchFoundWindowScriptTask ?? (_prepareOpenMatchFoundWindowScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "PrepareOpenMatchFoundWindowScriptTask",
					SchemaElementUId = new Guid("b4f8958c-2ef7-4cbd-9859-beabc5f460b9"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = PrepareOpenMatchFoundWindowScriptTaskExecute,
				});
			}
		}

		private OpenMatchFoundWindowUserTaskFlowElement _openMatchFoundWindowUserTask;
		public OpenMatchFoundWindowUserTaskFlowElement OpenMatchFoundWindowUserTask {
			get {
				return _openMatchFoundWindowUserTask ?? (_openMatchFoundWindowUserTask = new OpenMatchFoundWindowUserTaskFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private ProcessFlowElement _eventSubProcess1;
		public ProcessFlowElement EventSubProcess1 {
			get {
				return _eventSubProcess1 ?? (_eventSubProcess1 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "EventSubProcess1",
					SchemaElementUId = new Guid("6efae6cc-9cc3-4eb3-9ab6-a849f8b0980a"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
				});
			}
		}

		private ProcessFlowElement _matchFoundWindowClosedMessage;
		public ProcessFlowElement MatchFoundWindowClosedMessage {
			get {
				return _matchFoundWindowClosedMessage ?? (_matchFoundWindowClosedMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "MatchFoundWindowClosedMessage",
					SchemaElementUId = new Guid("90430d45-296a-4ef2-b727-db8ba2de0d37"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
				});
			}
		}

		private ProcessScriptTask _setSocialUserScriptTask;
		public ProcessScriptTask SetSocialUserScriptTask {
			get {
				return _setSocialUserScriptTask ?? (_setSocialUserScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "SetSocialUserScriptTask",
					SchemaElementUId = new Guid("85d15b6f-b750-4a1e-8403-d7b4d9aa285b"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = SetSocialUserScriptTaskExecute,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[Start1.SchemaElementUId] = new Collection<ProcessFlowElement> { Start1 };
			FlowElements[PrepareOpenMatchFoundWindowScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { PrepareOpenMatchFoundWindowScriptTask };
			FlowElements[OpenMatchFoundWindowUserTask.SchemaElementUId] = new Collection<ProcessFlowElement> { OpenMatchFoundWindowUserTask };
			FlowElements[EventSubProcess1.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess1 };
			FlowElements[MatchFoundWindowClosedMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { MatchFoundWindowClosedMessage };
			FlowElements[SetSocialUserScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { SetSocialUserScriptTask };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "Start1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("PrepareOpenMatchFoundWindowScriptTask", e.Context.SenderName));
						break;
					case "PrepareOpenMatchFoundWindowScriptTask":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("OpenMatchFoundWindowUserTask", e.Context.SenderName));
						break;
					case "OpenMatchFoundWindowUserTask":
						break;
					case "EventSubProcess1":
						break;
					case "MatchFoundWindowClosedMessage":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("SetSocialUserScriptTask", e.Context.SenderName));
						break;
					case "SetSocialUserScriptTask":
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
			if (!HasMapping("SocialUsersKey")) {
				writer.WriteValue("SocialUsersKey", SocialUsersKey, null);
			}
			if (!HasMapping("SocialNetworks")) {
				writer.WriteValue("SocialNetworks", SocialNetworks, null);
			}
			if (!HasMapping("SearchCriteria")) {
				writer.WriteValue("SearchCriteria", SearchCriteria, null);
			}
			if (!HasMapping("MatchesFoundPageUId")) {
				writer.WriteValue("MatchesFoundPageUId", MatchesFoundPageUId, Guid.Empty);
			}
			if (!HasMapping("Height")) {
				writer.WriteValue("Height", Height, 0);
			}
			if (!HasMapping("Width")) {
				writer.WriteValue("Width", Width, 0);
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
			ActivatedEventElements.Add("MatchFoundWindowClosedMessage");
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
			MetaPathParameterValues.Add("5395b142-e19d-4404-9832-d0dd0018dc8a", () => PageInstanceId);
			MetaPathParameterValues.Add("b16d44d3-07fb-4a3f-9150-1d70ebfcc516", () => ActiveTreeGridCurrentRowId);
			MetaPathParameterValues.Add("cec9d094-514a-47ec-943c-abcaee182be1", () => SocialUsersKey);
			MetaPathParameterValues.Add("856f4570-e2c1-421a-8b36-1ca4fdc9ffca", () => SocialNetworks);
			MetaPathParameterValues.Add("24e84ec1-16cf-46da-8db6-13db647a3fd2", () => SearchCriteria);
			MetaPathParameterValues.Add("fa5b71ac-faa8-480c-863b-78eedcb9e206", () => MatchesFoundPageUId);
			MetaPathParameterValues.Add("d9c957b1-ccc6-4858-98d6-88e8e3300945", () => Height);
			MetaPathParameterValues.Add("353019c4-47a0-4f83-b00f-3c00a7c5e9be", () => Width);
			MetaPathParameterValues.Add("e2e21ba3-bb6d-4e10-bce5-4bf650d7b7ba", () => OpenMatchFoundWindowUserTask.PageUId);
			MetaPathParameterValues.Add("e594e5b0-c983-486b-9113-8c72c303d9e0", () => OpenMatchFoundWindowUserTask.PageUrl);
			MetaPathParameterValues.Add("7452b4c9-d854-4ac1-9357-9fef2d645f5b", () => OpenMatchFoundWindowUserTask.OpenerInstanceId);
			MetaPathParameterValues.Add("c02dadae-f305-4ee0-b2a3-d048ef78be5b", () => OpenMatchFoundWindowUserTask.CloseOpenerOnLoad);
			MetaPathParameterValues.Add("54158a13-96c0-4e28-bfee-17cd7c98e909", () => OpenMatchFoundWindowUserTask.PageParameters);
			MetaPathParameterValues.Add("9862e552-2baf-420c-84aa-51b1c5b87a08", () => OpenMatchFoundWindowUserTask.Width);
			MetaPathParameterValues.Add("4f217434-6d17-4938-b1bf-a28f71b418b5", () => OpenMatchFoundWindowUserTask.CloseMessage);
			MetaPathParameterValues.Add("f7c8b17a-e5aa-40eb-845f-3655c06d1dc1", () => OpenMatchFoundWindowUserTask.Height);
			MetaPathParameterValues.Add("22fbda9a-a82c-4aeb-a709-630d00e56f66", () => OpenMatchFoundWindowUserTask.Centered);
			MetaPathParameterValues.Add("4a197821-213b-4f40-95f9-76b973066fe0", () => OpenMatchFoundWindowUserTask.UseOpenerRegisterScript);
			MetaPathParameterValues.Add("7b935efe-de49-4f8b-9fc5-6a0df3434963", () => OpenMatchFoundWindowUserTask.UseCurrentActivePage);
			MetaPathParameterValues.Add("55f3d967-cdbc-4274-a41b-a3b1936260fa", () => OpenMatchFoundWindowUserTask.IgnoreProfile);
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
				case "SocialUsersKey":
					if (!hasValueToRead) break;
					SocialUsersKey = reader.GetValue<System.String>();
				break;
				case "SocialNetworks":
					if (!hasValueToRead) break;
					SocialNetworks = reader.GetValue<System.String>();
				break;
				case "SearchCriteria":
					if (!hasValueToRead) break;
					SearchCriteria = reader.GetValue<System.String>();
				break;
				case "MatchesFoundPageUId":
					if (!hasValueToRead) break;
					MatchesFoundPageUId = reader.GetValue<System.Guid>();
				break;
				case "Height":
					if (!hasValueToRead) break;
					Height = reader.GetValue<System.Int32>();
				break;
				case "Width":
					if (!hasValueToRead) break;
					Width = reader.GetValue<System.Int32>();
				break;
			}
		}

		protected override void WritePropertyValues(DataWriter writer) {
			base.WritePropertyValues(writer);
			WritePropertyValues(writer, true);
		}

		#endregion

		#region Methods: Public

		public virtual bool PrepareOpenMatchFoundWindowScriptTaskExecute(ProcessExecutingContext context) {
			if (MatchesFoundPageUId.IsEmpty()) {
				MatchesFoundPageUId = new Guid("1200bc25-ab67-45c8-9fba-2703ac850351");
			}
			var contact = GetContact();
			var parameters = new Dictionary<string, string>();
			SocialUsersKey = "socialUsers" + Guid.NewGuid().ToString();
			parameters.Add("SocialUsers", SocialUsersKey);
			parameters.Add("SearchCriteria", contact.Name);
			parameters.Add("SocialNetwork", "All");
			parameters.Add("TwitterId", contact.TwitterId);
			parameters.Add("FacebookId", contact.FacebookId);
			parameters.Add("LinkedInId", contact.LinkedInId);
			OpenMatchFoundWindowUserTask.PageUId = MatchesFoundPageUId;
			OpenMatchFoundWindowUserTask.PageParameters = parameters;
			OpenMatchFoundWindowUserTask.OpenerInstanceId = InstanceUId;
			OpenMatchFoundWindowUserTask.UseCurrentActivePage = true;
			OpenMatchFoundWindowUserTask.CloseMessage = "MatchFoundWindowClosed";
			return true;
		}

		public virtual bool SetSocialUserScriptTaskExecute(ProcessExecutingContext context) {
			var sessionData = UserConnection.SessionData;
			if(sessionData[SocialUsersKey] == null){
				return false;
			}
			var contact = new Terrasoft.Configuration.Contact(UserConnection);
			if (contact.FetchFromDB(ActiveTreeGridCurrentRowId)) {
				var users = (IEnumerable<ISocialNetworkUser>)sessionData[SocialUsersKey];
				contact.SetColumnValue("Twitter", string.Empty);
				contact.SetColumnValue("TwitterId", string.Empty);
				contact.SetColumnValue("Facebook", string.Empty);
				contact.SetColumnValue("FacebookId", string.Empty);
				contact.SetColumnValue("LinkedIn", string.Empty);
				contact.SetColumnValue("LinkedInId", string.Empty);
				foreach (var user in users) {
					contact.SetColumnValue(user.SocialNetwork.ToString(), user.Name);
					contact.SetColumnValue(user.SocialNetwork.ToString() + "Id", user.Id);
				}
				contact.Save();
			}
			sessionData.Remove(SocialUsersKey);
			return true;
		}

			
			public virtual Terrasoft.Configuration.Contact GetContact() {
				var contactSchema = UserConnection.EntitySchemaManager.GetInstanceByName("Contact");
			var contact = contactSchema.CreateEntity(UserConnection) as Terrasoft.Configuration.Contact;
			bool fetchResult = contact.FetchFromDB(contactSchema.PrimaryColumn, ActiveTreeGridCurrentRowId, new[] {
			                               contactSchema.Columns.FindByColumnValueName("Name"),
										   contactSchema.Columns.FindByColumnValueName("TwitterId"),
										   contactSchema.Columns.FindByColumnValueName("LinkedInId"),
										   contactSchema.Columns.FindByColumnValueName("FacebookId"),
			                });
			if (!fetchResult){
			   contact = null;
			}
			return contact;
			}
			

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "MatchFoundWindowClosed":
							if (ActivatedEventElements.Contains("MatchFoundWindowClosedMessage")) {
							context.QueueTasksV2.Enqueue(new ProcessQueueElement("MatchFoundWindowClosedMessage", "MatchFoundWindowClosedMessage"));
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
			var cloneItem = (FindInSocialMediaModuleProcess)base.CloneShallow();
			cloneItem.ExecutedEventHandler = ExecutedEventHandler;
			return cloneItem;
		}

		#endregion

	}

	#endregion

}

