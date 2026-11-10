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
	using System.Text;
	using System.Web;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Process;
	using Terrasoft.Core.Process.Configuration;
	using Terrasoft.Core.Store;

	#region Class: ImportAccountsProcessSchema

	/// <exclude/>
	public class ImportAccountsProcessSchema : Terrasoft.Core.Process.ProcessSchema
	{

		#region Constructors: Public

		public ImportAccountsProcessSchema(ProcessSchemaManager processSchemaManager)
			: base(processSchemaManager) {
		}

		public ImportAccountsProcessSchema(ImportAccountsProcessSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			Name = "ImportAccountsProcess";
			UId = new Guid("efa082e9-bf97-485c-8119-d83fcea67000");
			BackgroundModePriority = BackgroundModePriority.Medium;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			CreatedInSchemaUId = Guid.Empty;
			CreatedInVersion = @"8.0.5.2483";
			CultureName = @"en-US";
			EntitySchemaUId = Guid.Empty;
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
			RealUId = new Guid("efa082e9-bf97-485c-8119-d83fcea67000");
			Version = 0;
			PackageUId = new Guid("06d9ef10-51d8-122c-8933-9212e84236c9");
			UseSystemSecurityContext = false;
		}

		protected virtual ProcessSchemaParameter CreatePageInstanceIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("3ec751f0-af40-4740-9c61-3617b8554dd7"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("efa082e9-bf97-485c-8119-d83fcea67000"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("efa082e9-bf97-485c-8119-d83fcea67000"),
				Name = @"PageInstanceId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Text"),
			};
		}

		protected virtual ProcessSchemaParameter CreateActiveTreeGridCurrentRowIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("681c9fc0-2334-4643-9930-f5d0d7260820"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("efa082e9-bf97-485c-8119-d83fcea67000"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("efa082e9-bf97-485c-8119-d83fcea67000"),
				Name = @"ActiveTreeGridCurrentRowId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid"),
			};
		}

		protected override void InitializeParameters() {
			base.InitializeParameters();
			Parameters.Add(CreatePageInstanceIdParameter());
			Parameters.Add(CreateActiveTreeGridCurrentRowIdParameter());
		}

		protected virtual void InitializeOpenImportAccountsSettingsPageUserTaskParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var pageUIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("e0634bad-72ae-4801-9e80-b822574d093d"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerUId = new Guid("d59e914c-18e5-44a0-a814-8d227b31bf03"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
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
				UId = new Guid("ec7bb597-9b2d-4cf6-9430-b409a6faa4d5"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerUId = new Guid("d59e914c-18e5-44a0-a814-8d227b31bf03"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
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
				UId = new Guid("dc750ab4-8a3f-41fa-8c98-d124d1247b73"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerUId = new Guid("d59e914c-18e5-44a0-a814-8d227b31bf03"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
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
				UId = new Guid("0b13449a-9e25-4bf8-a861-9a5c29f8c985"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerUId = new Guid("d59e914c-18e5-44a0-a814-8d227b31bf03"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
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
				UId = new Guid("f0a43a33-2b73-4ebc-a2ba-d522649c9254"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerUId = new Guid("d59e914c-18e5-44a0-a814-8d227b31bf03"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
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
				UId = new Guid("b5c50ef0-a69e-4e7d-8ff8-c892179eaf1b"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerUId = new Guid("d59e914c-18e5-44a0-a814-8d227b31bf03"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
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
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(widthParameter);
			var closeMessageParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("1f151e71-a5e3-4460-ae1f-c3eff5b102b6"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerUId = new Guid("d59e914c-18e5-44a0-a814-8d227b31bf03"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
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
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(closeMessageParameter);
			var heightParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("111d0351-174d-41b4-9d95-673c6ad02b3a"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerUId = new Guid("d59e914c-18e5-44a0-a814-8d227b31bf03"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
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
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(heightParameter);
			var centeredParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("88599d55-e180-4f50-89a6-2563f00b2280"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerUId = new Guid("d59e914c-18e5-44a0-a814-8d227b31bf03"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
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
				UId = new Guid("064f8776-02c0-4075-a7e3-b9577e0cda88"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerUId = new Guid("d59e914c-18e5-44a0-a814-8d227b31bf03"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
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
				UId = new Guid("ca3be5f6-4e72-4b80-8d20-7e54494a5b92"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerUId = new Guid("d59e914c-18e5-44a0-a814-8d227b31bf03"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
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
				UId = new Guid("93c7606d-a7ac-48c8-a7e4-f6580f9884fc"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerUId = new Guid("d59e914c-18e5-44a0-a814-8d227b31bf03"),
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

		protected virtual void InitializeConfirmOpenLogFileParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var pageParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("cd591e56-723a-40c7-9733-036d0045056c"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerUId = new Guid("d71f4ce6-8c48-4ddf-b776-35bd36caf06e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
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
				UId = new Guid("6f44a7b8-3b96-4e70-9399-203d4ee90a0c"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerUId = new Guid("d71f4ce6-8c48-4ddf-b776-35bd36caf06e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
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
				UId = new Guid("fa399ae2-4047-43c9-9d9d-6f7cac053ccf"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerUId = new Guid("d71f4ce6-8c48-4ddf-b776-35bd36caf06e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
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
				UId = new Guid("ceba56fe-a733-4709-8f2e-1e0350d2dd59"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerUId = new Guid("d71f4ce6-8c48-4ddf-b776-35bd36caf06e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
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
				UId = new Guid("07b516b8-4f6a-4755-9026-d02f0c21394f"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerUId = new Guid("d71f4ce6-8c48-4ddf-b776-35bd36caf06e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
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
				UId = new Guid("af3df3f7-b3da-4c6d-a6e2-cca4c25a3d53"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerUId = new Guid("d71f4ce6-8c48-4ddf-b776-35bd36caf06e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
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
				UId = new Guid("a784059e-1330-4d73-9737-56598eda7da2"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerUId = new Guid("d71f4ce6-8c48-4ddf-b776-35bd36caf06e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
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
				UId = new Guid("2048e785-35b0-4abf-83de-a7e8ec8af308"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerUId = new Guid("d71f4ce6-8c48-4ddf-b776-35bd36caf06e"),
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

		protected override void InitializeBaseElements() {
			base.InitializeBaseElements();
			ProcessSchemaLaneSet schemaLaneSet84 = CreateLaneSet84LaneSet();
			LaneSets.Add(schemaLaneSet84);
			ProcessSchemaLane schemaLane210 = CreateLane210Lane();
			schemaLaneSet84.Lanes.Add(schemaLane210);
			ProcessSchemaStartEvent start1 = CreateStart1StartEvent();
			FlowElements.Add(start1);
			ProcessSchemaEndEvent end1 = CreateEnd1EndEvent();
			FlowElements.Add(end1);
			ProcessSchemaScriptTask setparametersscript = CreateSetParametersScriptScriptTask();
			FlowElements.Add(setparametersscript);
			ProcessSchemaUserTask openimportaccountssettingspageusertask = CreateOpenImportAccountsSettingsPageUserTaskUserTask();
			FlowElements.Add(openimportaccountssettingspageusertask);
			ProcessSchemaIntermediateCatchMessageEvent showmessageboxstartmessage = CreateShowMessageBoxStartMessageIntermediateCatchMessageEvent();
			FlowElements.Add(showmessageboxstartmessage);
			ProcessSchemaScriptTask showmessageboxscript = CreateShowMessageBoxScriptScriptTask();
			FlowElements.Add(showmessageboxscript);
			ProcessSchemaUserTask confirmopenlogfile = CreateConfirmOpenLogFileUserTask();
			FlowElements.Add(confirmopenlogfile);
			ProcessSchemaIntermediateCatchMessageEvent nomessagestartmessage = CreateNoMessageStartMessageIntermediateCatchMessageEvent();
			FlowElements.Add(nomessagestartmessage);
			ProcessSchemaIntermediateCatchMessageEvent yesmessagestartmessage = CreateYesMessageStartMessageIntermediateCatchMessageEvent();
			FlowElements.Add(yesmessagestartmessage);
			ProcessSchemaScriptTask clearparametersscript = CreateClearParametersScriptScriptTask();
			FlowElements.Add(clearparametersscript);
			ProcessSchemaScriptTask prepareuploadscript = CreatePrepareUploadScriptScriptTask();
			FlowElements.Add(prepareuploadscript);
			ProcessSchemaIntermediateCatchMessageEvent savelogintermediatecatchmessageevent = CreateSaveLogIntermediateCatchMessageEventIntermediateCatchMessageEvent();
			FlowElements.Add(savelogintermediatecatchmessageevent);
			ProcessSchemaScriptTask savelogscripttask = CreateSaveLogScriptTaskScriptTask();
			FlowElements.Add(savelogscripttask);
			ProcessSchemaExclusiveGateway exclusivegateway1 = CreateExclusiveGateway1ExclusiveGateway();
			FlowElements.Add(exclusivegateway1);
			FlowElements.Add(CreateSequenceFlow678SequenceFlow());
			FlowElements.Add(CreateSequenceFlow679SequenceFlow());
			FlowElements.Add(CreateSequenceFlow680SequenceFlow());
			FlowElements.Add(CreateSequenceFlow1SequenceFlow());
			FlowElements.Add(CreateSequenceFlow2SequenceFlow());
			FlowElements.Add(CreateSequenceFlow3SequenceFlow());
			FlowElements.Add(CreateSequenceFlow4SequenceFlow());
			FlowElements.Add(CreateSequenceFlow5SequenceFlow());
			FlowElements.Add(CreateSequenceFlow6SequenceFlow());
			FlowElements.Add(CreateSequenceFlow7SequenceFlow());
			FlowElements.Add(CreateSequenceFlow8SequenceFlow());
			FlowElements.Add(CreateSequenceFlow9SequenceFlow());
			FlowElements.Add(CreateSequenceFlow10SequenceFlow());
			FlowElements.Add(CreateSequenceFlow11SequenceFlow());
			FlowElements.Add(CreateConditionalFlow1ConditionalFlow());
		}

		protected override void InitializeLocalizableStrings() {
			base.InitializeLocalizableStrings();
			SetLocalizableStringsDefInheritance();
			LocalizableStrings.Add(CreateOpenLogFileMessageLocalizableString());
			LocalizableStrings.Add(CreateAccountsImportFileLogLocalizableString());
		}

		protected virtual SchemaLocalizableString CreateOpenLogFileMessageLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("627e41e2-4313-40c2-b28d-1773faefa782"),
				Name = "OpenLogFileMessage",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("efa082e9-bf97-485c-8119-d83fcea67000"),
				ModifiedInSchemaUId = new Guid("efa082e9-bf97-485c-8119-d83fcea67000")
			};
			return localizableString;
		}

		protected virtual SchemaLocalizableString CreateAccountsImportFileLogLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("8f50000f-5686-4fc8-af5e-9de93d6a8a55"),
				Name = "AccountsImportFileLog",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("efa082e9-bf97-485c-8119-d83fcea67000"),
				ModifiedInSchemaUId = new Guid("efa082e9-bf97-485c-8119-d83fcea67000")
			};
			return localizableString;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow678SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow678",
				UId = new Guid("3ab441c9-a101-4cc7-a8e2-ef42ba85aeb5"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("efa082e9-bf97-485c-8119-d83fcea67000"),
				CurveCenterPosition = new Point(563, 196),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("efa082e9-bf97-485c-8119-d83fcea67000"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("00093309-c412-427c-a76e-1c501b54f41e"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("d59e914c-18e5-44a0-a814-8d227b31bf03"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow679SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow679",
				UId = new Guid("644930c9-4554-41a3-8d40-b83324acb28e"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("efa082e9-bf97-485c-8119-d83fcea67000"),
				CurveCenterPosition = new Point(672, 196),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("efa082e9-bf97-485c-8119-d83fcea67000"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("d59e914c-18e5-44a0-a814-8d227b31bf03"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("0584b546-ea6f-42c3-8d9e-17ad59288656"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow680SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow680",
				UId = new Guid("b34bf302-9a7b-48a8-8b30-b747f76b29ff"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("efa082e9-bf97-485c-8119-d83fcea67000"),
				CurveCenterPosition = new Point(162, 200),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("efa082e9-bf97-485c-8119-d83fcea67000"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("710fed7e-da4b-4fa1-a33f-33a4230d63c4"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("00093309-c412-427c-a76e-1c501b54f41e"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow1SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow1",
				UId = new Guid("a03f4a9f-4d73-4f21-851f-e7b397878f70"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("efa082e9-bf97-485c-8119-d83fcea67000"),
				CurveCenterPosition = new Point(672, 196),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("efa082e9-bf97-485c-8119-d83fcea67000"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("0584b546-ea6f-42c3-8d9e-17ad59288656"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("dad3b3cf-bea3-4d41-aec2-829a7aa31789"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow2SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow2",
				UId = new Guid("f429d223-e3ed-455d-89b6-576191c83fa9"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("efa082e9-bf97-485c-8119-d83fcea67000"),
				CurveCenterPosition = new Point(677, 198),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("efa082e9-bf97-485c-8119-d83fcea67000"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("76225e24-c77e-40c9-99c6-31ad52bd9e3b"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("d71f4ce6-8c48-4ddf-b776-35bd36caf06e"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow3SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow3",
				UId = new Guid("effe7988-c52e-437f-ae8b-714dd814a5e7"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("efa082e9-bf97-485c-8119-d83fcea67000"),
				CurveCenterPosition = new Point(798, 135),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("efa082e9-bf97-485c-8119-d83fcea67000"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("d71f4ce6-8c48-4ddf-b776-35bd36caf06e"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("d192afe0-3b1e-477a-a587-c0d72aa901ca"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow4SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow4",
				UId = new Guid("da2170c6-1bb4-405c-b111-80db1cb85a10"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("efa082e9-bf97-485c-8119-d83fcea67000"),
				CurveCenterPosition = new Point(810, 274),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("efa082e9-bf97-485c-8119-d83fcea67000"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("d71f4ce6-8c48-4ddf-b776-35bd36caf06e"),
				SourceSequenceFlowPointLocalPosition = new Point(0, -1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("5ffeb80c-9ef2-4e94-ab16-609d69c57952"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow5SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow5",
				UId = new Guid("7ff5d054-a272-4ce2-9a8c-272ac9c95089"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("efa082e9-bf97-485c-8119-d83fcea67000"),
				CurveCenterPosition = new Point(941, 318),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("efa082e9-bf97-485c-8119-d83fcea67000"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("5ffeb80c-9ef2-4e94-ab16-609d69c57952"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("66487450-4f86-4433-9a48-4def22adb103"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow6SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow6",
				UId = new Guid("5cb63efd-6d95-4d24-ac4b-ab8fb78d459d"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("efa082e9-bf97-485c-8119-d83fcea67000"),
				CurveCenterPosition = new Point(953, 104),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("efa082e9-bf97-485c-8119-d83fcea67000"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("d192afe0-3b1e-477a-a587-c0d72aa901ca"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("b1769401-f0a4-4c8c-8cc0-46c596c79f60"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow7SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow7",
				UId = new Guid("de83af84-eb91-41be-96ef-a0d99eb68c0f"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("efa082e9-bf97-485c-8119-d83fcea67000"),
				CurveCenterPosition = new Point(1108, 326),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("efa082e9-bf97-485c-8119-d83fcea67000"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("66487450-4f86-4433-9a48-4def22adb103"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("229f7fb8-3718-44a8-90b8-4814dc6f208e"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow8SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow8",
				UId = new Guid("5425f301-62f0-4319-b085-25b03fb95fd3"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("efa082e9-bf97-485c-8119-d83fcea67000"),
				CurveCenterPosition = new Point(1224, 320),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("efa082e9-bf97-485c-8119-d83fcea67000"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("229f7fb8-3718-44a8-90b8-4814dc6f208e"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("75674dae-6ac3-4d04-ab7d-8f45a8407d1c"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow9SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow9",
				UId = new Guid("b95fd4aa-c36c-4dc4-a1cc-8e8609205ad5"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("efa082e9-bf97-485c-8119-d83fcea67000"),
				CurveCenterPosition = new Point(1376, 272),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("efa082e9-bf97-485c-8119-d83fcea67000"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("75674dae-6ac3-4d04-ab7d-8f45a8407d1c"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("e8a8b078-7284-4bcb-a57a-0e7ea31c10f9"),
				TargetSequenceFlowPointLocalPosition = new Point(0, -1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow10SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow10",
				UId = new Guid("f37ef40b-baf5-49ff-bd4b-ae92f9385178"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("efa082e9-bf97-485c-8119-d83fcea67000"),
				CurveCenterPosition = new Point(1248, 152),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("efa082e9-bf97-485c-8119-d83fcea67000"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("b1769401-f0a4-4c8c-8cc0-46c596c79f60"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("e8a8b078-7284-4bcb-a57a-0e7ea31c10f9"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow11SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Default) {
				Name = "SequenceFlow11",
				UId = new Guid("efdd02cc-f908-4e7d-9626-fab9b2c2fabe"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("efa082e9-bf97-485c-8119-d83fcea67000"),
				CurveCenterPosition = new Point(656, 198),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Default,
				ManagerItemUId = new Guid("573ed909-e069-4161-b193-ae8dd9437c68"),
				ModifiedInSchemaUId = new Guid("efa082e9-bf97-485c-8119-d83fcea67000"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("dad3b3cf-bea3-4d41-aec2-829a7aa31789"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("76225e24-c77e-40c9-99c6-31ad52bd9e3b"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateConditionalFlow1ConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "ConditionalFlow1",
				UId = new Guid("a1ba68e6-ef05-469d-a409-2b7d2660708d"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ConditionExpression = @"UserConnection.SessionData[""ImportedRowsCount""] == null",
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("efa082e9-bf97-485c-8119-d83fcea67000"),
				CurveCenterPosition = new Point(865, 124),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("efa082e9-bf97-485c-8119-d83fcea67000"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("dad3b3cf-bea3-4d41-aec2-829a7aa31789"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("b1769401-f0a4-4c8c-8cc0-46c596c79f60"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaLaneSet CreateLaneSet84LaneSet() {
			ProcessSchemaLaneSet schemaLaneSet84 = new ProcessSchemaLaneSet(this) {
				UId = new Guid("be035f23-84ea-45eb-a57f-1d53ee1fcc33"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 1,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("efa082e9-bf97-485c-8119-d83fcea67000"),
				Direction = ProcessSchemaPoolDirectionType.Vertical,
				DragGroupName = @"LaneSet",
				ManagerItemUId = new Guid("11a47caf-a0d5-41fa-a274-a0b11f77447a"),
				ModifiedInSchemaUId = new Guid("efa082e9-bf97-485c-8119-d83fcea67000"),
				Name = @"LaneSet84",
				Position = new Point(5, 5),
				Size = new Size(1461, 430),
				UseBackgroundMode = false
			};
			return schemaLaneSet84;
		}

		protected virtual ProcessSchemaLane CreateLane210Lane() {
			ProcessSchemaLane schemaLane210 = new ProcessSchemaLane(this) {
				UId = new Guid("336d75bc-f426-4e4f-bd37-b8f1ac0c1d9f"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 1,
				ContainerUId = new Guid("be035f23-84ea-45eb-a57f-1d53ee1fcc33"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("efa082e9-bf97-485c-8119-d83fcea67000"),
				DragGroupName = @"Lane",
				ManagerItemUId = new Guid("abcd74b9-5912-414b-82ac-f1aa4dcd554e"),
				ModifiedInSchemaUId = new Guid("efa082e9-bf97-485c-8119-d83fcea67000"),
				Name = @"Lane210",
				Position = new Point(29, 0),
				Size = new Size(1432, 430),
				UseBackgroundMode = false
			};
			return schemaLane210;
		}

		protected virtual ProcessSchemaStartEvent CreateStart1StartEvent() {
			ProcessSchemaStartEvent schemaStartEvent = new ProcessSchemaStartEvent(this) {
				UId = new Guid("710fed7e-da4b-4fa1-a33f-33a4230d63c4"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = new Guid("336d75bc-f426-4e4f-bd37-b8f1ac0c1d9f"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("efa082e9-bf97-485c-8119-d83fcea67000"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsInterrupting = false,
				IsLogging = false,
				ManagerItemUId = new Guid("53818048-7868-48f6-ada0-0ebaa65af628"),
				ModifiedInSchemaUId = new Guid("efa082e9-bf97-485c-8119-d83fcea67000"),
				Name = @"Start1",
				Position = new Point(50, 177),
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			
			return schemaStartEvent;
		}

		protected virtual ProcessSchemaEndEvent CreateEnd1EndEvent() {
			ProcessSchemaEndEvent schemaEndEvent = new ProcessSchemaEndEvent(this) {
				UId = new Guid("e8a8b078-7284-4bcb-a57a-0e7ea31c10f9"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = new Guid("336d75bc-f426-4e4f-bd37-b8f1ac0c1d9f"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("efa082e9-bf97-485c-8119-d83fcea67000"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsLogging = false,
				ManagerItemUId = new Guid("45ceaae2-4e1f-4c0c-86aa-cd4aeb4da913"),
				ModifiedInSchemaUId = new Guid("efa082e9-bf97-485c-8119-d83fcea67000"),
				Name = @"End1",
				Position = new Point(1373, 191),
				SerializeToDB = false,
				Size = new Size(0, 0),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaEndEvent;
		}

		protected virtual ProcessSchemaScriptTask CreateSetParametersScriptScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("00093309-c412-427c-a76e-1c501b54f41e"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = new Guid("336d75bc-f426-4e4f-bd37-b8f1ac0c1d9f"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("efa082e9-bf97-485c-8119-d83fcea67000"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = false,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("efa082e9-bf97-485c-8119-d83fcea67000"),
				Name = @"SetParametersScript",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(141, 163),
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,141,141,189,14,130,48,20,70,103,120,138,166,147,14,24,132,42,38,196,65,25,12,131,129,4,125,128,210,94,144,168,45,233,143,248,248,86,196,157,237,158,155,47,231,20,61,136,252,217,75,101,14,140,73,43,140,174,192,152,78,180,186,164,45,92,53,168,11,213,247,213,8,57,71,123,36,96,64,39,219,241,5,142,195,100,23,213,97,28,52,77,83,7,164,102,113,64,73,20,6,9,35,124,77,160,225,27,186,197,203,212,47,230,37,190,51,80,185,208,134,10,6,99,235,15,174,156,122,8,205,53,101,15,169,225,12,90,187,167,179,224,234,38,135,9,143,242,141,83,111,174,200,29,153,85,10,132,155,153,238,5,229,79,104,148,133,212,87,96,172,18,19,124,0,15,115,250,146,71,1,0,0 }
			};
			
			return ScriptTask;
		}

		protected virtual ProcessSchemaUserTask CreateOpenImportAccountsSettingsPageUserTaskUserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("d59e914c-18e5-44a0-a814-8d227b31bf03"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = new Guid("336d75bc-f426-4e4f-bd37-b8f1ac0c1d9f"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("efa082e9-bf97-485c-8119-d83fcea67000"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = false,
				ManagerItemUId = new Guid("1418e61a-82c3-403e-8221-01088f52c125"),
				ModifiedInSchemaUId = new Guid("efa082e9-bf97-485c-8119-d83fcea67000"),
				Name = @"OpenImportAccountsSettingsPageUserTask",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(274, 163),
				SchemaUId = new Guid("b7042ef4-f468-443e-b3ea-39ebbda1c828"),
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] {  }
			};
			InitializeOpenImportAccountsSettingsPageUserTaskParameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaIntermediateCatchMessageEvent CreateShowMessageBoxStartMessageIntermediateCatchMessageEvent() {
			ProcessSchemaIntermediateCatchMessageEvent schemaCatchMessageEvent = new ProcessSchemaIntermediateCatchMessageEvent(this) {
				UId = new Guid("0584b546-ea6f-42c3-8d9e-17ad59288656"),
				AttachedToUId = Guid.Empty,
				BackgroundModePriority = BackgroundModePriority.Inherited,
				BoundaryItemAlignment = ProcessSchemaEditItemAlignment.None,
				CancelActivity = true,
				ContainerItemIndex = 0,
				ContainerUId = new Guid("336d75bc-f426-4e4f-bd37-b8f1ac0c1d9f"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("efa082e9-bf97-485c-8119-d83fcea67000"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				ImageList = null,
				ImageName = null,
				IsLogging = false,
				ManagerItemUId = new Guid("3cb9d737-779e-4085-ab4b-db590853e266"),
				Message = @"ShowMessageBox",
				ModifiedInSchemaUId = new Guid("efa082e9-bf97-485c-8119-d83fcea67000"),
				Name = @"ShowMessageBoxStartMessage",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(421, 177),
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			
			return schemaCatchMessageEvent;
		}

		protected virtual ProcessSchemaScriptTask CreateShowMessageBoxScriptScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("76225e24-c77e-40c9-99c6-31ad52bd9e3b"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = new Guid("336d75bc-f426-4e4f-bd37-b8f1ac0c1d9f"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("efa082e9-bf97-485c-8119-d83fcea67000"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = false,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("efa082e9-bf97-485c-8119-d83fcea67000"),
				Name = @"ShowMessageBoxScript",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(645, 163),
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,125,81,201,110,194,48,16,61,23,137,127,112,125,10,82,20,113,135,114,40,139,20,181,77,40,155,212,163,27,6,228,42,204,68,182,3,69,17,255,222,9,13,21,106,93,46,150,252,230,205,91,236,189,50,66,239,10,50,14,214,51,58,216,33,149,232,196,131,64,56,136,39,56,174,84,94,194,84,105,211,215,232,66,193,199,32,232,134,162,219,233,181,91,123,223,234,28,172,213,132,35,229,20,171,44,45,152,33,33,66,230,24,140,174,134,209,148,138,62,189,127,240,100,16,200,248,183,140,172,13,244,70,4,55,13,238,57,103,153,231,29,81,137,118,235,206,87,35,240,119,232,220,146,101,231,83,187,197,177,55,218,236,210,2,240,153,182,19,157,67,244,194,28,181,133,5,124,214,210,214,25,141,219,104,66,102,167,92,112,197,107,104,225,223,199,137,56,141,15,62,39,172,27,123,76,227,140,144,221,228,235,114,60,95,196,105,34,253,180,199,210,57,66,91,51,223,198,243,36,253,135,54,3,91,48,237,146,209,54,63,61,210,231,15,82,230,216,255,174,21,54,245,6,162,170,228,17,172,12,89,23,108,179,38,79,161,168,36,82,141,38,244,3,158,252,158,83,67,25,83,98,180,78,97,6,241,154,77,47,151,101,188,230,37,3,174,52,40,156,41,161,247,5,137,216,180,149,145,2,0,0 }
			};
			
			return ScriptTask;
		}

		protected virtual ProcessSchemaUserTask CreateConfirmOpenLogFileUserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("d71f4ce6-8c48-4ddf-b776-35bd36caf06e"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = new Guid("336d75bc-f426-4e4f-bd37-b8f1ac0c1d9f"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("efa082e9-bf97-485c-8119-d83fcea67000"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = false,
				ManagerItemUId = new Guid("1418e61a-82c3-403e-8221-01088f52c125"),
				ModifiedInSchemaUId = new Guid("efa082e9-bf97-485c-8119-d83fcea67000"),
				Name = @"ConfirmOpenLogFile",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(806, 163),
				SchemaUId = new Guid("496a664f-3aab-43d7-ab1b-2521ab601aab"),
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] {  }
			};
			InitializeConfirmOpenLogFileParameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaIntermediateCatchMessageEvent CreateNoMessageStartMessageIntermediateCatchMessageEvent() {
			ProcessSchemaIntermediateCatchMessageEvent schemaCatchMessageEvent = new ProcessSchemaIntermediateCatchMessageEvent(this) {
				UId = new Guid("d192afe0-3b1e-477a-a587-c0d72aa901ca"),
				AttachedToUId = Guid.Empty,
				BackgroundModePriority = BackgroundModePriority.Inherited,
				BoundaryItemAlignment = ProcessSchemaEditItemAlignment.None,
				CancelActivity = true,
				ContainerItemIndex = 0,
				ContainerUId = new Guid("336d75bc-f426-4e4f-bd37-b8f1ac0c1d9f"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("efa082e9-bf97-485c-8119-d83fcea67000"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				ImageList = null,
				ImageName = null,
				IsLogging = false,
				ManagerItemUId = new Guid("3cb9d737-779e-4085-ab4b-db590853e266"),
				Message = @"NoMessage",
				ModifiedInSchemaUId = new Guid("efa082e9-bf97-485c-8119-d83fcea67000"),
				Name = @"NoMessageStartMessage",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(911, 86),
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			
			return schemaCatchMessageEvent;
		}

		protected virtual ProcessSchemaIntermediateCatchMessageEvent CreateYesMessageStartMessageIntermediateCatchMessageEvent() {
			ProcessSchemaIntermediateCatchMessageEvent schemaCatchMessageEvent = new ProcessSchemaIntermediateCatchMessageEvent(this) {
				UId = new Guid("5ffeb80c-9ef2-4e94-ab16-609d69c57952"),
				AttachedToUId = Guid.Empty,
				BackgroundModePriority = BackgroundModePriority.Inherited,
				BoundaryItemAlignment = ProcessSchemaEditItemAlignment.None,
				CancelActivity = true,
				ContainerItemIndex = 0,
				ContainerUId = new Guid("336d75bc-f426-4e4f-bd37-b8f1ac0c1d9f"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("efa082e9-bf97-485c-8119-d83fcea67000"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				ImageList = null,
				ImageName = null,
				IsLogging = false,
				ManagerItemUId = new Guid("3cb9d737-779e-4085-ab4b-db590853e266"),
				Message = @"YesMessage",
				ModifiedInSchemaUId = new Guid("efa082e9-bf97-485c-8119-d83fcea67000"),
				Name = @"YesMessageStartMessage",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(904, 303),
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			
			return schemaCatchMessageEvent;
		}

		protected virtual ProcessSchemaScriptTask CreateClearParametersScriptScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("b1769401-f0a4-4c8c-8cc0-46c596c79f60"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = new Guid("336d75bc-f426-4e4f-bd37-b8f1ac0c1d9f"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("efa082e9-bf97-485c-8119-d83fcea67000"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = false,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("efa082e9-bf97-485c-8119-d83fcea67000"),
				Name = @"ClearParametersScript",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(1093, 72),
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,117,142,177,14,130,48,20,69,103,73,248,135,103,167,118,233,15,40,46,128,134,141,196,24,231,10,207,136,41,45,190,182,74,98,252,119,203,6,3,235,189,185,231,220,183,34,192,177,65,93,245,131,37,95,181,103,116,174,179,166,80,94,65,6,23,135,148,91,99,176,241,49,148,179,82,214,118,216,219,219,51,54,7,206,202,57,130,137,93,154,116,119,224,171,224,109,6,38,104,45,224,11,105,178,49,248,129,2,53,122,228,75,159,144,71,178,253,130,206,132,140,139,205,245,129,132,156,77,46,89,185,242,21,148,230,185,213,161,55,178,86,164,250,200,34,206,79,161,107,197,218,9,33,100,57,98,19,162,117,250,251,75,147,52,33,244,129,12,120,10,24,163,63,216,145,95,98,28,1,0,0 }
			};
			
			return ScriptTask;
		}

		protected virtual ProcessSchemaScriptTask CreatePrepareUploadScriptScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("66487450-4f86-4433-9a48-4def22adb103"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = new Guid("336d75bc-f426-4e4f-bd37-b8f1ac0c1d9f"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("efa082e9-bf97-485c-8119-d83fcea67000"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = false,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("efa082e9-bf97-485c-8119-d83fcea67000"),
				Name = @"PrepareUploadScript",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(995, 289),
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,69,143,77,10,194,64,12,133,215,22,122,135,208,77,21,101,14,96,113,33,69,176,160,32,104,113,29,157,88,71,202,76,201,164,173,32,222,221,105,5,93,228,15,242,94,190,116,200,208,96,69,176,130,173,72,147,59,43,244,20,149,183,204,100,127,117,139,86,215,196,128,30,78,196,140,222,221,68,149,133,58,211,101,80,176,171,189,58,4,151,44,142,226,200,11,27,91,129,191,178,105,36,248,38,189,177,218,245,234,175,92,63,240,185,39,185,59,237,213,233,206,174,207,107,19,174,108,186,144,166,105,2,115,136,163,73,97,189,160,189,82,89,104,152,135,57,73,23,144,30,177,163,157,171,134,54,196,11,140,47,155,218,161,134,37,8,183,4,239,89,150,100,65,61,188,164,214,90,31,71,136,233,151,101,54,226,49,73,203,118,92,207,62,44,150,92,184,254,0,0,0 }
			};
			
			return ScriptTask;
		}

		protected virtual ProcessSchemaIntermediateCatchMessageEvent CreateSaveLogIntermediateCatchMessageEventIntermediateCatchMessageEvent() {
			ProcessSchemaIntermediateCatchMessageEvent schemaCatchMessageEvent = new ProcessSchemaIntermediateCatchMessageEvent(this) {
				UId = new Guid("229f7fb8-3718-44a8-90b8-4814dc6f208e"),
				AttachedToUId = Guid.Empty,
				BackgroundModePriority = BackgroundModePriority.Inherited,
				BoundaryItemAlignment = ProcessSchemaEditItemAlignment.None,
				CancelActivity = true,
				ContainerItemIndex = 0,
				ContainerUId = new Guid("336d75bc-f426-4e4f-bd37-b8f1ac0c1d9f"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("efa082e9-bf97-485c-8119-d83fcea67000"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				ImageList = null,
				ImageName = null,
				IsLogging = false,
				ManagerItemUId = new Guid("3cb9d737-779e-4085-ab4b-db590853e266"),
				Message = @"SaveLog",
				ModifiedInSchemaUId = new Guid("efa082e9-bf97-485c-8119-d83fcea67000"),
				Name = @"SaveLogIntermediateCatchMessageEvent",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(1135, 303),
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			
			return schemaCatchMessageEvent;
		}

		protected virtual ProcessSchemaScriptTask CreateSaveLogScriptTaskScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("75674dae-6ac3-4d04-ab7d-8f45a8407d1c"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = new Guid("336d75bc-f426-4e4f-bd37-b8f1ac0c1d9f"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("efa082e9-bf97-485c-8119-d83fcea67000"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = false,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("efa082e9-bf97-485c-8119-d83fcea67000"),
				Name = @"SaveLogScriptTask",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(1254, 289),
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,165,83,77,111,219,48,12,61,59,64,255,131,166,147,12,116,90,239,94,6,228,115,13,176,161,197,154,161,135,117,7,213,102,19,15,182,228,73,84,155,162,200,127,31,101,217,141,179,160,187,236,98,3,226,227,227,35,249,248,168,44,131,93,14,213,170,110,140,197,85,113,3,206,149,70,207,21,42,54,102,223,29,216,153,209,26,114,164,71,57,8,202,107,211,124,52,247,191,40,242,73,240,197,144,130,167,217,217,168,124,96,226,77,226,119,99,166,125,85,165,236,133,157,141,146,71,210,224,208,150,122,51,245,101,85,128,165,194,26,158,216,205,240,77,4,210,22,90,153,205,87,226,82,27,112,61,16,42,146,33,142,197,166,114,102,42,95,107,193,59,244,26,118,200,83,185,180,166,62,18,252,197,108,120,74,220,137,188,221,130,133,147,102,228,202,45,126,123,85,137,200,39,175,149,85,53,32,73,18,159,125,89,164,111,117,153,70,210,43,75,234,167,207,19,151,11,62,179,160,16,138,43,29,11,42,215,73,15,173,121,71,205,50,17,58,44,238,23,59,200,61,26,123,186,130,133,118,222,194,124,122,120,18,41,205,49,208,117,12,171,80,252,27,168,48,200,58,182,78,52,131,169,201,200,14,17,35,14,213,122,162,228,105,91,86,192,68,151,45,3,240,181,74,146,132,213,118,161,31,23,63,7,203,140,225,228,104,151,114,210,52,160,139,65,130,92,155,184,89,162,204,254,149,194,239,236,157,230,61,102,223,254,218,111,248,236,59,55,60,144,210,206,172,199,36,135,42,189,113,44,184,198,104,23,166,113,137,216,208,4,145,44,33,103,222,90,208,72,93,198,112,22,60,217,99,101,139,210,184,126,110,66,30,15,25,31,154,74,149,154,103,67,216,164,40,46,227,56,121,151,241,126,94,82,204,149,97,69,252,188,19,39,151,198,214,10,5,87,136,42,223,214,132,203,218,22,52,89,106,252,114,177,151,72,38,61,103,147,60,55,94,163,139,182,90,18,128,92,26,199,245,90,242,214,150,8,162,239,255,56,182,160,241,181,47,225,60,230,228,49,66,254,125,30,39,135,64,86,15,211,237,174,224,255,172,223,123,172,85,65,187,58,27,89,64,111,53,67,235,33,251,3,245,203,113,130,118,4,0,0 }
			};
			
			return ScriptTask;
		}

		protected virtual ProcessSchemaExclusiveGateway CreateExclusiveGateway1ExclusiveGateway() {
			ProcessSchemaExclusiveGateway gateway = new ProcessSchemaExclusiveGateway(this) {
				UId = new Guid("dad3b3cf-bea3-4d41-aec2-829a7aa31789"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = new Guid("336d75bc-f426-4e4f-bd37-b8f1ac0c1d9f"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("efa082e9-bf97-485c-8119-d83fcea67000"),
				DragGroupName = @"Gateway",
				ImageList = null,
				ImageName = null,
				IsLogging = false,
				ManagerItemUId = new Guid("bd9f7570-6c97-4f16-90e5-663a190c6c7c"),
				ModifiedInSchemaUId = new Guid("efa082e9-bf97-485c-8119-d83fcea67000"),
				Name = @"ExclusiveGateway1",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(505, 163),
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return gateway;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeUsings() {
			Usings.Add(new SchemaUsing() {
				UId = new Guid("9b095569-4558-4824-bd58-f17d8549e109"),
				Name = "System.Web",
				Alias = "",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("fe2e2ee6-c766-4c27-a2d8-cb9aa6dd3e3a"),
				Name = "System.Data",
				Alias = "",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("e763a3fa-3237-4c4e-bd2e-3a61a525a5c6"),
				Name = "System.Text",
				Alias = "",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("e3642f19-4e7d-41ea-969e-af5535676926"),
				Name = "Terrasoft.Core.Store",
				Alias = "",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			});
		}

		#endregion

		#region Methods: Public

		public override Process CreateProcess(UserConnection userConnection) {
			return new ImportAccountsProcess(userConnection);
		}

		public override object Clone() {
			return new ImportAccountsProcessSchema(this);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("efa082e9-bf97-485c-8119-d83fcea67000"));
		}

		#endregion

	}

	#endregion

	#region Class: ImportAccountsProcess

	/// <exclude/>
	public class ImportAccountsProcess : Terrasoft.Core.Process.Process
	{

		#region Class: ProcessLane210

		/// <exclude/>
		public class ProcessLane210 : ProcessLane
		{

			public ProcessLane210(UserConnection userConnection, ImportAccountsProcess process)
				: base(userConnection) {
				Owner = process;
				IsUsedParentUserContexts = false;
			}

		}

		#endregion

		#region Class: OpenImportAccountsSettingsPageUserTaskFlowElement

		/// <exclude/>
		public class OpenImportAccountsSettingsPageUserTaskFlowElement : OpenPageUserTask
		{

			#region Constructors: Public

			public OpenImportAccountsSettingsPageUserTaskFlowElement(UserConnection userConnection, ImportAccountsProcess process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "OpenImportAccountsSettingsPageUserTask";
				IsLogging = false;
				SchemaElementUId = new Guid("d59e914c-18e5-44a0-a814-8d227b31bf03");
				CreatedInSchemaUId = process.InternalSchemaUId;
			}

			#endregion

		}

		#endregion

		#region Class: ConfirmOpenLogFileFlowElement

		/// <exclude/>
		public class ConfirmOpenLogFileFlowElement : QuestionUserTask
		{

			#region Constructors: Public

			public ConfirmOpenLogFileFlowElement(UserConnection userConnection, ImportAccountsProcess process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "ConfirmOpenLogFile";
				IsLogging = false;
				SchemaElementUId = new Guid("d71f4ce6-8c48-4ddf-b776-35bd36caf06e");
				CreatedInSchemaUId = process.InternalSchemaUId;
			}

			#endregion

		}

		#endregion

		public ImportAccountsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ImportAccountsProcess";
			SchemaUId = new Guid("efa082e9-bf97-485c-8119-d83fcea67000");
			Caption = Schema.Caption;
			SchemaManagerName = "ProcessSchemaManager";
			SerializeToDB = false;
			SerializeToMemory = true;
			IsLogging = true;
			UseSystemSecurityContext = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("efa082e9-bf97-485c-8119-d83fcea67000");
			}
		}

		private string ConditionalExpressionLogMessage {
			get {
				return "Process: ImportAccountsProcess, Source element: {0}, Conditional flow: {1}, Expression: {2}, Result: {3}";
			}
		}

		private string DeadEndGatewayLogMessage {
			get {
				return "Process: ImportAccountsProcess, Source element: {0}, None of the exclusive gateway conditions are met!";
			}
		}

		#endregion

		#region Properties: Public

		public virtual string PageInstanceId {
			get;
			set;
		}

		public virtual Guid ActiveTreeGridCurrentRowId {
			get;
			set;
		}

		private ProcessLane210 _lane210;
		public ProcessLane210 Lane210 {
			get {
				return _lane210 ?? ((_lane210) = new ProcessLane210(UserConnection, this));
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
					SchemaElementUId = new Guid("710fed7e-da4b-4fa1-a33f-33a4230d63c4"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
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
					SchemaElementUId = new Guid("e8a8b078-7284-4bcb-a57a-0e7ea31c10f9"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _setParametersScript;
		public ProcessScriptTask SetParametersScript {
			get {
				return _setParametersScript ?? (_setParametersScript = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "SetParametersScript",
					SchemaElementUId = new Guid("00093309-c412-427c-a76e-1c501b54f41e"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					Script = SetParametersScriptExecute,
				});
			}
		}

		private OpenImportAccountsSettingsPageUserTaskFlowElement _openImportAccountsSettingsPageUserTask;
		public OpenImportAccountsSettingsPageUserTaskFlowElement OpenImportAccountsSettingsPageUserTask {
			get {
				return _openImportAccountsSettingsPageUserTask ?? (_openImportAccountsSettingsPageUserTask = new OpenImportAccountsSettingsPageUserTaskFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private ProcessIntermediateCatchMessageEvent _showMessageBoxStartMessage;
		public ProcessIntermediateCatchMessageEvent ShowMessageBoxStartMessage {
			get {
				return _showMessageBoxStartMessage ?? (_showMessageBoxStartMessage = new ProcessIntermediateCatchMessageEvent() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaIntermediateCatchMessageEvent",
					Name = "ShowMessageBoxStartMessage",
					SchemaElementUId = new Guid("0584b546-ea6f-42c3-8d9e-17ad59288656"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Message = "ShowMessageBox",
				});
			}
		}

		private ProcessScriptTask _showMessageBoxScript;
		public ProcessScriptTask ShowMessageBoxScript {
			get {
				return _showMessageBoxScript ?? (_showMessageBoxScript = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ShowMessageBoxScript",
					SchemaElementUId = new Guid("76225e24-c77e-40c9-99c6-31ad52bd9e3b"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					Script = ShowMessageBoxScriptExecute,
				});
			}
		}

		private ConfirmOpenLogFileFlowElement _confirmOpenLogFile;
		public ConfirmOpenLogFileFlowElement ConfirmOpenLogFile {
			get {
				return _confirmOpenLogFile ?? (_confirmOpenLogFile = new ConfirmOpenLogFileFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private ProcessIntermediateCatchMessageEvent _noMessageStartMessage;
		public ProcessIntermediateCatchMessageEvent NoMessageStartMessage {
			get {
				return _noMessageStartMessage ?? (_noMessageStartMessage = new ProcessIntermediateCatchMessageEvent() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaIntermediateCatchMessageEvent",
					Name = "NoMessageStartMessage",
					SchemaElementUId = new Guid("d192afe0-3b1e-477a-a587-c0d72aa901ca"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Message = "NoMessage",
				});
			}
		}

		private ProcessIntermediateCatchMessageEvent _yesMessageStartMessage;
		public ProcessIntermediateCatchMessageEvent YesMessageStartMessage {
			get {
				return _yesMessageStartMessage ?? (_yesMessageStartMessage = new ProcessIntermediateCatchMessageEvent() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaIntermediateCatchMessageEvent",
					Name = "YesMessageStartMessage",
					SchemaElementUId = new Guid("5ffeb80c-9ef2-4e94-ab16-609d69c57952"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Message = "YesMessage",
				});
			}
		}

		private ProcessScriptTask _clearParametersScript;
		public ProcessScriptTask ClearParametersScript {
			get {
				return _clearParametersScript ?? (_clearParametersScript = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ClearParametersScript",
					SchemaElementUId = new Guid("b1769401-f0a4-4c8c-8cc0-46c596c79f60"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					Script = ClearParametersScriptExecute,
				});
			}
		}

		private ProcessScriptTask _prepareUploadScript;
		public ProcessScriptTask PrepareUploadScript {
			get {
				return _prepareUploadScript ?? (_prepareUploadScript = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "PrepareUploadScript",
					SchemaElementUId = new Guid("66487450-4f86-4433-9a48-4def22adb103"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					Script = PrepareUploadScriptExecute,
				});
			}
		}

		private ProcessIntermediateCatchMessageEvent _saveLogIntermediateCatchMessageEvent;
		public ProcessIntermediateCatchMessageEvent SaveLogIntermediateCatchMessageEvent {
			get {
				return _saveLogIntermediateCatchMessageEvent ?? (_saveLogIntermediateCatchMessageEvent = new ProcessIntermediateCatchMessageEvent() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaIntermediateCatchMessageEvent",
					Name = "SaveLogIntermediateCatchMessageEvent",
					SchemaElementUId = new Guid("229f7fb8-3718-44a8-90b8-4814dc6f208e"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Message = "SaveLog",
				});
			}
		}

		private ProcessScriptTask _saveLogScriptTask;
		public ProcessScriptTask SaveLogScriptTask {
			get {
				return _saveLogScriptTask ?? (_saveLogScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "SaveLogScriptTask",
					SchemaElementUId = new Guid("75674dae-6ac3-4d04-ab7d-8f45a8407d1c"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					Script = SaveLogScriptTaskExecute,
				});
			}
		}

		private ProcessExclusiveGateway _exclusiveGateway1;
		public ProcessExclusiveGateway ExclusiveGateway1 {
			get {
				return _exclusiveGateway1 ?? (_exclusiveGateway1 = new ProcessExclusiveGateway() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaExclusiveGateway",
					Name = "ExclusiveGateway1",
					SchemaElementUId = new Guid("dad3b3cf-bea3-4d41-aec2-829a7aa31789"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Question = GetLocalizableString(Schema.GetResourceManagerName(),
					"BaseElements.ExclusiveGateway1.Question"),
						IsDecisionRequired = false,
						BranchingMode = GatewayBranchingMode.Auto,
						DecisionMode = GetewayDecisionSelectionMode.Single,
						ShowUserDecisionDialog = (processId, gatewayName) => {},
				});
			}
		}

		private ProcessConditionalFlow _conditionalFlow1;
		public ProcessConditionalFlow ConditionalFlow1 {
			get {
				return _conditionalFlow1 ?? (_conditionalFlow1 = new ProcessConditionalFlow() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaConditionalFlow",
					Name = "ConditionalFlow1",
					SchemaElementUId = new Guid("a1ba68e6-ef05-469d-a409-2b7d2660708d"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						MatchBranchingDecisions = new BranchingDecisionCollection() {
				},
				});
			}
		}

		private LocalizableString _openLogFileMessage;
		public LocalizableString OpenLogFileMessage {
			get {
				return _openLogFileMessage ?? (_openLogFileMessage = new LocalizableString(Storage, Schema.GetResourceManagerName(), "LocalizableStrings.OpenLogFileMessage.Value"));
			}
		}

		private LocalizableString _accountsImportFileLog;
		public LocalizableString AccountsImportFileLog {
			get {
				return _accountsImportFileLog ?? (_accountsImportFileLog = new LocalizableString(Storage, Schema.GetResourceManagerName(), "LocalizableStrings.AccountsImportFileLog.Value"));
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[Start1.SchemaElementUId] = new Collection<ProcessFlowElement> { Start1 };
			FlowElements[End1.SchemaElementUId] = new Collection<ProcessFlowElement> { End1 };
			FlowElements[SetParametersScript.SchemaElementUId] = new Collection<ProcessFlowElement> { SetParametersScript };
			FlowElements[OpenImportAccountsSettingsPageUserTask.SchemaElementUId] = new Collection<ProcessFlowElement> { OpenImportAccountsSettingsPageUserTask };
			FlowElements[ShowMessageBoxStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { ShowMessageBoxStartMessage };
			FlowElements[ShowMessageBoxScript.SchemaElementUId] = new Collection<ProcessFlowElement> { ShowMessageBoxScript };
			FlowElements[ConfirmOpenLogFile.SchemaElementUId] = new Collection<ProcessFlowElement> { ConfirmOpenLogFile };
			FlowElements[NoMessageStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { NoMessageStartMessage };
			FlowElements[YesMessageStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { YesMessageStartMessage };
			FlowElements[ClearParametersScript.SchemaElementUId] = new Collection<ProcessFlowElement> { ClearParametersScript };
			FlowElements[PrepareUploadScript.SchemaElementUId] = new Collection<ProcessFlowElement> { PrepareUploadScript };
			FlowElements[SaveLogIntermediateCatchMessageEvent.SchemaElementUId] = new Collection<ProcessFlowElement> { SaveLogIntermediateCatchMessageEvent };
			FlowElements[SaveLogScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { SaveLogScriptTask };
			FlowElements[ExclusiveGateway1.SchemaElementUId] = new Collection<ProcessFlowElement> { ExclusiveGateway1 };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "Start1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("SetParametersScript", e.Context.SenderName));
						break;
					case "End1":
						CompleteProcess();
						break;
					case "SetParametersScript":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("OpenImportAccountsSettingsPageUserTask", e.Context.SenderName));
						break;
					case "OpenImportAccountsSettingsPageUserTask":
						ActivatedEventElements.Add("ShowMessageBoxStartMessage");
						break;
					case "ShowMessageBoxStartMessage":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ExclusiveGateway1", e.Context.SenderName));
						break;
					case "ShowMessageBoxScript":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ConfirmOpenLogFile", e.Context.SenderName));
						break;
					case "ConfirmOpenLogFile":
						ActivatedEventElements.Add("NoMessageStartMessage");
						ActivatedEventElements.Add("YesMessageStartMessage");
						break;
					case "NoMessageStartMessage":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ClearParametersScript", e.Context.SenderName));
						break;
					case "YesMessageStartMessage":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("PrepareUploadScript", e.Context.SenderName));
						break;
					case "ClearParametersScript":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("End1", e.Context.SenderName));
						break;
					case "PrepareUploadScript":
						if (!ActivatedEventElements.Contains("SaveLogIntermediateCatchMessageEvent")) {
							ActivatedEventElements.Add("SaveLogIntermediateCatchMessageEvent");
						}
						break;
					case "SaveLogIntermediateCatchMessageEvent":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("SaveLogScriptTask", e.Context.SenderName));
						break;
					case "SaveLogScriptTask":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("End1", e.Context.SenderName));
						break;
					case "ExclusiveGateway1":
						if (ConditionalFlow1ExpressionExecute()) {
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ClearParametersScript", e.Context.SenderName));
							break;
						}
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ShowMessageBoxScript", e.Context.SenderName));
						break;
			}
		}

		private bool ConditionalFlow1ExpressionExecute() {
			bool result = Convert.ToBoolean(UserConnection.SessionData["ImportedRowsCount"] == null);
			Log.InfoFormat(ConditionalExpressionLogMessage, "ExclusiveGateway1", "ConditionalFlow1", "UserConnection.SessionData[\"ImportedRowsCount\"] == null", result);
			return result;
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
			MetaPathParameterValues.Add("3ec751f0-af40-4740-9c61-3617b8554dd7", () => PageInstanceId);
			MetaPathParameterValues.Add("681c9fc0-2334-4643-9930-f5d0d7260820", () => ActiveTreeGridCurrentRowId);
			MetaPathParameterValues.Add("e0634bad-72ae-4801-9e80-b822574d093d", () => OpenImportAccountsSettingsPageUserTask.PageUId);
			MetaPathParameterValues.Add("ec7bb597-9b2d-4cf6-9430-b409a6faa4d5", () => OpenImportAccountsSettingsPageUserTask.PageUrl);
			MetaPathParameterValues.Add("dc750ab4-8a3f-41fa-8c98-d124d1247b73", () => OpenImportAccountsSettingsPageUserTask.OpenerInstanceId);
			MetaPathParameterValues.Add("0b13449a-9e25-4bf8-a861-9a5c29f8c985", () => OpenImportAccountsSettingsPageUserTask.CloseOpenerOnLoad);
			MetaPathParameterValues.Add("f0a43a33-2b73-4ebc-a2ba-d522649c9254", () => OpenImportAccountsSettingsPageUserTask.PageParameters);
			MetaPathParameterValues.Add("b5c50ef0-a69e-4e7d-8ff8-c892179eaf1b", () => OpenImportAccountsSettingsPageUserTask.Width);
			MetaPathParameterValues.Add("1f151e71-a5e3-4460-ae1f-c3eff5b102b6", () => OpenImportAccountsSettingsPageUserTask.CloseMessage);
			MetaPathParameterValues.Add("111d0351-174d-41b4-9d95-673c6ad02b3a", () => OpenImportAccountsSettingsPageUserTask.Height);
			MetaPathParameterValues.Add("88599d55-e180-4f50-89a6-2563f00b2280", () => OpenImportAccountsSettingsPageUserTask.Centered);
			MetaPathParameterValues.Add("064f8776-02c0-4075-a7e3-b9577e0cda88", () => OpenImportAccountsSettingsPageUserTask.UseOpenerRegisterScript);
			MetaPathParameterValues.Add("ca3be5f6-4e72-4b80-8d20-7e54494a5b92", () => OpenImportAccountsSettingsPageUserTask.UseCurrentActivePage);
			MetaPathParameterValues.Add("93c7606d-a7ac-48c8-a7e4-f6580f9884fc", () => OpenImportAccountsSettingsPageUserTask.IgnoreProfile);
			MetaPathParameterValues.Add("cd591e56-723a-40c7-9733-036d0045056c", () => ConfirmOpenLogFile.Page);
			MetaPathParameterValues.Add("6f44a7b8-3b96-4e70-9399-203d4ee90a0c", () => ConfirmOpenLogFile.Icon);
			MetaPathParameterValues.Add("fa399ae2-4047-43c9-9d9d-6f7cac053ccf", () => ConfirmOpenLogFile.Buttons);
			MetaPathParameterValues.Add("ceba56fe-a733-4709-8f2e-1e0350d2dd59", () => ConfirmOpenLogFile.WindowCaption);
			MetaPathParameterValues.Add("07b516b8-4f6a-4755-9026-d02f0c21394f", () => ConfirmOpenLogFile.MessageText);
			MetaPathParameterValues.Add("af3df3f7-b3da-4c6d-a6e2-cca4c25a3d53", () => ConfirmOpenLogFile.ResponseMessages);
			MetaPathParameterValues.Add("a784059e-1330-4d73-9737-56598eda7da2", () => ConfirmOpenLogFile.ProcessInstanceId);
			MetaPathParameterValues.Add("2048e785-35b0-4abf-83de-a7e8ec8af308", () => ConfirmOpenLogFile.PageParameters);
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

		public virtual bool SetParametersScriptExecute(ProcessExecutingContext context) {
			OpenImportAccountsSettingsPageUserTask.PageUId = new Guid("30782b03-fffb-4bc3-a420-7c4d14efd5a6");
			OpenImportAccountsSettingsPageUserTask.OpenerInstanceId = InstanceUId;	  
			OpenImportAccountsSettingsPageUserTask.CloseMessage = "ShowMessageBox";	
			OpenImportAccountsSettingsPageUserTask.UseCurrentActivePage = true;
			return true;
		}

		public virtual bool ShowMessageBoxScriptExecute(ProcessExecutingContext context) {
			var importedRowsCount = new KeyValuePair<int, int>(0, 0);
			var importedRowsCountSessionData = UserConnection.SessionData.Pop<object>("ImportedRowsCount");
			if (importedRowsCountSessionData != null) { 
				importedRowsCount = (KeyValuePair<int, int>)importedRowsCountSessionData;
			}
			ConfirmOpenLogFile.MessageText = string.Format(OpenLogFileMessage, importedRowsCount.Key, importedRowsCount.Value);
			ConfirmOpenLogFile.Icon = "QUESTION";
			ConfirmOpenLogFile.Buttons = "YESNO";
			ConfirmOpenLogFile.ResponseMessages = new Dictionary<string, string> {{"yes", "YesMessage"}, {"no", "NoMessage"}};
			ConfirmOpenLogFile.ProcessInstanceId = InstanceUId;
			return true;
		}

		public virtual bool ClearParametersScriptExecute(ProcessExecutingContext context) {
			var excelImportIdSessionData = UserConnection.SessionData.Pop<object>("ExcelImportId");
			if (excelImportIdSessionData != null) { 
				new Delete(UserConnection).From("ExcelImport").
					Where("Id").IsEqual(Column.Parameter((Guid)excelImportIdSessionData)).Execute();
			}
			
			return true;
		}

		public virtual bool PrepareUploadScriptExecute(ProcessExecutingContext context) {
			var page = HttpContext.Current.CurrentHandler as Terrasoft.UI.WebControls.Page;
			
			string script = "window.Terrasoft.AjaxMethods.ThrowClientEvent('" + 
				InstanceUId +
				"', 'SaveLog', '', { isUpload : true });"; 
			page.AddScript(script);
			
			return true;
		}

		public virtual bool SaveLogScriptTaskExecute(ProcessExecutingContext context) {
			var excelImportIdSessionData = UserConnection.SessionData.Pop<object>("ExcelImportId");
			if (excelImportIdSessionData != null) { 
				var stringBuilder = new StringBuilder();
				var logMessages = new Select(UserConnection).Column("MessageText").From("ExcelImportLog")
					.Where("ExcelImportId").IsEqual(Column.Parameter((Guid)excelImportIdSessionData))
					.OrderByAsc("CreatedOn")
					as Select;
				using (var dbExecutor = UserConnection.EnsureDBConnection()) {
					using (IDataReader message = logMessages.ExecuteReader(dbExecutor)) {
						while (message.Read()) {
							if (message[0] != null) {
								stringBuilder.Append(message[0].ToString());
								stringBuilder.Append("\r\n");
							}
						}
					}
				}
				var fileData = stringBuilder.ToString();
				var response = HttpContext.Current.Response; 
				response.ContentType = "text/plain";
				response.AddHeader("Content-Disposition", string.Format("attachment; filename={0}.txt", AccountsImportFileLog));
				response.Write(fileData);
				response.End();
				new Delete(UserConnection).From("ExcelImport").
					Where("Id").IsEqual(Column.Parameter((Guid)excelImportIdSessionData)).Execute();
			}
			
			return true;
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "ShowMessageBox":
					if (ActivatedEventElements.Remove("ShowMessageBoxStartMessage")) {
						context.QueueTasksV2.Enqueue(new ProcessQueueElement("ShowMessageBoxStartMessage", "ShowMessageBoxStartMessage"));
					}
					break;
					case "NoMessage":
					if (ActivatedEventElements.Remove("NoMessageStartMessage")) {
						context.QueueTasksV2.Enqueue(new ProcessQueueElement("NoMessageStartMessage", "NoMessageStartMessage"));
					}
					break;
					case "YesMessage":
					if (ActivatedEventElements.Remove("YesMessageStartMessage")) {
						context.QueueTasksV2.Enqueue(new ProcessQueueElement("YesMessageStartMessage", "YesMessageStartMessage"));
					}
					break;
					case "SaveLog":
					if (ActivatedEventElements.Remove("SaveLogIntermediateCatchMessageEvent")) {
						context.QueueTasksV2.Enqueue(new ProcessQueueElement("SaveLogIntermediateCatchMessageEvent", "SaveLogIntermediateCatchMessageEvent"));
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
			var cloneItem = (ImportAccountsProcess)base.CloneShallow();
			cloneItem.ExecutedEventHandler = ExecutedEventHandler;
			return cloneItem;
		}

		#endregion

	}

	#endregion

}

