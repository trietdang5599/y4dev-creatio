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
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Process;
	using Terrasoft.Core.Process.Configuration;
	using Terrasoft.UI.WebControls.Controls;

	#region Class: ClearChangeLogProcessSchema

	/// <exclude/>
	public class ClearChangeLogProcessSchema : Terrasoft.Core.Process.ProcessSchema
	{

		#region Constructors: Public

		public ClearChangeLogProcessSchema(ProcessSchemaManager processSchemaManager)
			: base(processSchemaManager) {
		}

		public ClearChangeLogProcessSchema(ClearChangeLogProcessSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			Name = "ClearChangeLogProcess";
			UId = new Guid("3977290d-f2e7-4b06-8ae3-6fed38f3facc");
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
			ZipMethodsBody = new byte[] {  };
			ZipCompiledMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,101,82,219,106,2,49,16,125,94,193,127,8,121,74,64,150,190,139,47,186,182,8,210,155,90,161,165,15,113,119,212,224,110,98,39,89,173,148,254,123,39,123,147,182,176,27,230,146,57,115,114,102,250,189,99,185,201,117,202,78,26,125,169,114,118,178,58,99,147,28,20,206,237,238,214,226,212,120,237,47,226,174,164,48,84,246,34,221,67,161,102,217,128,37,202,195,82,23,192,54,176,181,8,146,125,245,123,209,2,114,72,61,243,106,147,195,189,42,160,241,71,204,192,153,213,142,88,57,192,137,53,134,108,109,141,140,19,237,188,54,148,144,241,196,230,101,97,4,15,165,92,198,183,104,11,193,95,206,139,139,107,250,154,181,197,131,59,170,52,164,215,123,64,16,124,53,203,200,153,185,233,7,61,65,132,70,79,37,224,229,81,33,161,120,64,241,155,185,148,76,185,134,203,144,40,151,78,155,29,19,201,120,250,9,105,233,45,178,108,211,153,35,246,155,109,60,53,174,68,72,198,215,144,144,245,211,91,160,147,34,132,80,249,71,132,184,6,133,103,80,25,145,186,54,105,235,163,243,94,231,32,50,140,195,149,14,54,138,156,199,128,220,225,17,118,29,34,189,76,170,188,224,36,16,31,80,215,183,155,247,120,105,23,85,82,200,1,227,52,70,46,135,53,76,69,140,168,120,104,230,145,84,206,191,121,84,170,119,205,58,153,39,123,101,118,176,68,149,30,32,123,48,92,214,168,81,68,210,207,193,57,81,15,47,190,234,30,182,227,213,26,152,153,173,13,84,79,128,62,196,150,118,229,83,209,172,13,145,108,55,137,203,150,106,77,179,85,76,52,225,239,112,134,131,126,250,250,189,31,245,5,10,79,192,2,0,0 };
			RealUId = new Guid("3977290d-f2e7-4b06-8ae3-6fed38f3facc");
			Version = 0;
			PackageUId = new Guid("06d9ef10-51d8-122c-8933-9212e84236c9");
			UseSystemSecurityContext = false;
		}

		protected virtual ProcessSchemaParameter CreatePageInstanceIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("88798994-3a8b-4d20-854a-17028f8d0de8"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("3977290d-f2e7-4b06-8ae3-6fed38f3facc"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("3977290d-f2e7-4b06-8ae3-6fed38f3facc"),
				Name = @"PageInstanceId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Text"),
			};
		}

		protected virtual ProcessSchemaParameter CreatePageParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("b4246ed2-6dca-4604-a398-78215b1b7eb7"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("3977290d-f2e7-4b06-8ae3-6fed38f3facc"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("3977290d-f2e7-4b06-8ae3-6fed38f3facc"),
				Name = @"Page",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Object"),
			};
		}

		protected virtual ProcessSchemaParameter CreateNeedShowMessageParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("f347d6a7-bc75-4d05-a5c6-3efae0852c5b"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("3977290d-f2e7-4b06-8ae3-6fed38f3facc"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("3977290d-f2e7-4b06-8ae3-6fed38f3facc"),
				Name = @"NeedShowMessage",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean"),
			};
		}

		protected virtual ProcessSchemaParameter CreateLoggedEntitySchemasPresentParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("939c77c0-50c2-4e54-8262-b9916a10eaa0"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("3977290d-f2e7-4b06-8ae3-6fed38f3facc"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("3977290d-f2e7-4b06-8ae3-6fed38f3facc"),
				Name = @"LoggedEntitySchemasPresent",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean"),
			};
		}

		protected virtual ProcessSchemaParameter CreateCurrentSchemaUIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("88784240-8faa-4042-87d6-4b0cc3bc1a2a"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("3977290d-f2e7-4b06-8ae3-6fed38f3facc"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("3977290d-f2e7-4b06-8ae3-6fed38f3facc"),
				Name = @"CurrentSchemaUId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid"),
			};
		}

		protected virtual ProcessSchemaParameter CreateGridProcessUIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("5f56e336-ffea-4d08-814e-11d712a6b3e3"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("3977290d-f2e7-4b06-8ae3-6fed38f3facc"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("3977290d-f2e7-4b06-8ae3-6fed38f3facc"),
				Name = @"GridProcessUId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Text"),
			};
		}

		protected virtual ProcessSchemaParameter CreateClearingSuccessfulMessageParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("d8451c10-cf36-470a-b74e-1cc7774c2e43"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("3977290d-f2e7-4b06-8ae3-6fed38f3facc"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("3977290d-f2e7-4b06-8ae3-6fed38f3facc"),
				Name = @"ClearingSuccessfulMessage",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LocalizableStringDataValueType"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.ConstValue,
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("3977290d-f2e7-4b06-8ae3-6fed38f3facc"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateNoLoggedEntitySchemasMessageParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("4936d7ab-ede1-440e-a617-4f6b6df29680"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("3977290d-f2e7-4b06-8ae3-6fed38f3facc"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("3977290d-f2e7-4b06-8ae3-6fed38f3facc"),
				Name = @"NoLoggedEntitySchemasMessage",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LocalizableStringDataValueType"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.ConstValue,
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("3977290d-f2e7-4b06-8ae3-6fed38f3facc"),
				},
			};
		}

		protected override void InitializeParameters() {
			base.InitializeParameters();
			Parameters.Add(CreatePageInstanceIdParameter());
			Parameters.Add(CreatePageParameter());
			Parameters.Add(CreateNeedShowMessageParameter());
			Parameters.Add(CreateLoggedEntitySchemasPresentParameter());
			Parameters.Add(CreateCurrentSchemaUIdParameter());
			Parameters.Add(CreateGridProcessUIdParameter());
			Parameters.Add(CreateClearingSuccessfulMessageParameter());
			Parameters.Add(CreateNoLoggedEntitySchemasMessageParameter());
		}

		protected virtual void InitializeOpenSettingsPageUserTaskParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var pageUIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("947ae31b-cd23-430a-bb8f-7241b4720103"),
				ContainerUId = new Guid("e7fb1ce8-d9a7-4c82-b432-c1907a9dd517"),
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
				UId = new Guid("9bde68e7-06a7-4751-9781-06b3754b48b7"),
				ContainerUId = new Guid("e7fb1ce8-d9a7-4c82-b432-c1907a9dd517"),
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
				UId = new Guid("49358ca4-34c7-47b5-a5aa-b5b67550d216"),
				ContainerUId = new Guid("e7fb1ce8-d9a7-4c82-b432-c1907a9dd517"),
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
				UId = new Guid("34038892-d974-4aba-8314-f1dd674ad0fe"),
				ContainerUId = new Guid("e7fb1ce8-d9a7-4c82-b432-c1907a9dd517"),
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
				UId = new Guid("8df2aea7-612c-4bad-84e9-e30ea7f09e8f"),
				ContainerUId = new Guid("e7fb1ce8-d9a7-4c82-b432-c1907a9dd517"),
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
				UId = new Guid("5cade72b-85a0-49fe-816c-1b22e2dc0d8a"),
				ContainerUId = new Guid("e7fb1ce8-d9a7-4c82-b432-c1907a9dd517"),
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
				UId = new Guid("4bb355ef-5767-4f36-bef7-76b3d4588aa7"),
				ContainerUId = new Guid("e7fb1ce8-d9a7-4c82-b432-c1907a9dd517"),
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
				UId = new Guid("f6b3d22f-3018-4520-b406-1cf86fccae76"),
				ContainerUId = new Guid("e7fb1ce8-d9a7-4c82-b432-c1907a9dd517"),
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
				UId = new Guid("91b530ef-ca1d-4eff-8d4f-3fefeb154b34"),
				ContainerUId = new Guid("e7fb1ce8-d9a7-4c82-b432-c1907a9dd517"),
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
				UId = new Guid("af84ebdf-f659-46b1-87f8-a4dcbe9855ca"),
				ContainerUId = new Guid("e7fb1ce8-d9a7-4c82-b432-c1907a9dd517"),
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
				UId = new Guid("828fea8b-d25c-476a-90a0-7236d248165c"),
				ContainerUId = new Guid("e7fb1ce8-d9a7-4c82-b432-c1907a9dd517"),
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
				UId = new Guid("618752b8-186d-44cf-8461-9fe563281840"),
				ContainerUId = new Guid("e7fb1ce8-d9a7-4c82-b432-c1907a9dd517"),
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

		protected virtual void InitializeShowNoTrackedMessageUserTaskParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var pageParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("b1f8890e-49f8-483e-8367-ca7b2e363461"),
				ContainerUId = new Guid("de7acea9-fd3f-47a2-ba11-fff451705433"),
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
				UId = new Guid("43ffb68a-6415-4275-82e2-25b8642ab04f"),
				ContainerUId = new Guid("de7acea9-fd3f-47a2-ba11-fff451705433"),
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
				UId = new Guid("4138a7e3-d8a8-4c07-b0fb-dd2eca81d036"),
				ContainerUId = new Guid("de7acea9-fd3f-47a2-ba11-fff451705433"),
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
				UId = new Guid("7c854a73-1b08-403b-8bd1-55a745b98e2d"),
				ContainerUId = new Guid("de7acea9-fd3f-47a2-ba11-fff451705433"),
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
				UId = new Guid("c997df75-4855-4ae6-817a-bcb2aeb43b42"),
				ContainerUId = new Guid("de7acea9-fd3f-47a2-ba11-fff451705433"),
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
				UId = new Guid("81ed9542-b4ee-4d60-9fd7-2b4018da7bba"),
				ContainerUId = new Guid("de7acea9-fd3f-47a2-ba11-fff451705433"),
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
				UId = new Guid("e03fddf1-410e-4633-b63a-8e999b3af86b"),
				ContainerUId = new Guid("de7acea9-fd3f-47a2-ba11-fff451705433"),
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
				UId = new Guid("c99bed8c-3a2a-43b0-98b2-ff8eefbb783a"),
				ContainerUId = new Guid("de7acea9-fd3f-47a2-ba11-fff451705433"),
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
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(pageParametersParameter);
		}

		protected virtual void InitializeShowClearedMessageUserTaskParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var pageParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("91f526be-f71a-451c-877a-4a7e236e3d67"),
				ContainerUId = new Guid("52564b96-a184-4562-b0fc-98b0c83b3909"),
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
				UId = new Guid("27d1ec03-d4cb-4a35-9477-ad537ff7e28e"),
				ContainerUId = new Guid("52564b96-a184-4562-b0fc-98b0c83b3909"),
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
				UId = new Guid("9b66906c-369a-4fc8-bb76-d789c5c13b03"),
				ContainerUId = new Guid("52564b96-a184-4562-b0fc-98b0c83b3909"),
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
				UId = new Guid("21615c4d-7cd2-4de7-922d-d8653ae3eda3"),
				ContainerUId = new Guid("52564b96-a184-4562-b0fc-98b0c83b3909"),
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
				UId = new Guid("4eb22089-e449-43fe-a117-92ca5b74c36a"),
				ContainerUId = new Guid("52564b96-a184-4562-b0fc-98b0c83b3909"),
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
				UId = new Guid("4f87cb10-e46e-4dec-bcd6-3008131751ae"),
				ContainerUId = new Guid("52564b96-a184-4562-b0fc-98b0c83b3909"),
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
				UId = new Guid("d82c9d90-c135-401c-b232-9f50aea2ba7f"),
				ContainerUId = new Guid("52564b96-a184-4562-b0fc-98b0c83b3909"),
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
				UId = new Guid("8a4dab2c-626e-4002-91e8-e38f45505adf"),
				ContainerUId = new Guid("52564b96-a184-4562-b0fc-98b0c83b3909"),
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
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(pageParametersParameter);
		}

		protected override void InitializeBaseElements() {
			base.InitializeBaseElements();
			ProcessSchemaLaneSet schemaLaneSet42 = CreateLaneSet42LaneSet();
			LaneSets.Add(schemaLaneSet42);
			ProcessSchemaLane schemaLane124 = CreateLane124Lane();
			schemaLaneSet42.Lanes.Add(schemaLane124);
			ProcessSchemaStartEvent start1 = CreateStart1StartEvent();
			FlowElements.Add(start1);
			ProcessSchemaEndEvent end1 = CreateEnd1EndEvent();
			FlowElements.Add(end1);
			ProcessSchemaScriptTask prepareparametersscripttask = CreatePrepareParametersScriptTaskScriptTask();
			FlowElements.Add(prepareparametersscripttask);
			ProcessSchemaUserTask opensettingspageusertask = CreateOpenSettingsPageUserTaskUserTask();
			FlowElements.Add(opensettingspageusertask);
			ProcessSchemaUserTask shownotrackedmessageusertask = CreateShowNoTrackedMessageUserTaskUserTask();
			FlowElements.Add(shownotrackedmessageusertask);
			ProcessSchemaIntermediateCatchMessageEvent settingswindowclosedintermediatecatchmessageevent1 = CreateSettingsWindowClosedIntermediateCatchMessageEvent1IntermediateCatchMessageEvent();
			FlowElements.Add(settingswindowclosedintermediatecatchmessageevent1);
			ProcessSchemaScriptTask clearifnecessaryscripttask = CreateClearIfNecessaryScriptTaskScriptTask();
			FlowElements.Add(clearifnecessaryscripttask);
			ProcessSchemaUserTask showclearedmessageusertask = CreateShowClearedMessageUserTaskUserTask();
			FlowElements.Add(showclearedmessageusertask);
			ProcessSchemaExclusiveGateway needshowmessageexclusivegateway = CreateNeedShowMessageExclusiveGatewayExclusiveGateway();
			FlowElements.Add(needshowmessageexclusivegateway);
			FlowElements.Add(CreateSequenceFlow411SequenceFlow());
			FlowElements.Add(CreateSequenceFlow412SequenceFlow());
			FlowElements.Add(CreateSequenceFlow413SequenceFlow());
			FlowElements.Add(CreateLoggedEntitySchemasPresentConditionalFlowConditionalFlow());
			FlowElements.Add(CreateSequenceFlow415SequenceFlow());
			FlowElements.Add(CreateSequenceFlow416SequenceFlow());
			FlowElements.Add(CreateSequenceFlow419SequenceFlow());
			FlowElements.Add(CreateNeedShowMessageConditionalFlowConditionalFlow());
			FlowElements.Add(CreateSequenceFlow1SequenceFlow());
			FlowElements.Add(CreateSequenceFlow2SequenceFlow());
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow411SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow411",
				UId = new Guid("71002e41-aea3-4652-828f-ce1a68353a97"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("3977290d-f2e7-4b06-8ae3-6fed38f3facc"),
				CurveCenterPosition = new Point(406, 147),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("3977290d-f2e7-4b06-8ae3-6fed38f3facc"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("2167cf96-f197-444f-971b-a5a77fc7ff57"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("222ace1f-663b-41f4-b450-4d244b45013d"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow412SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Default) {
				Name = "SequenceFlow412",
				UId = new Guid("8d2ca9a5-aead-447d-b403-f4026a4974a0"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("3977290d-f2e7-4b06-8ae3-6fed38f3facc"),
				CurveCenterPosition = new Point(295, 98),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Default,
				ManagerItemUId = new Guid("573ed909-e069-4161-b193-ae8dd9437c68"),
				ModifiedInSchemaUId = new Guid("3977290d-f2e7-4b06-8ae3-6fed38f3facc"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("222ace1f-663b-41f4-b450-4d244b45013d"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("e7fb1ce8-d9a7-4c82-b432-c1907a9dd517"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow413SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow413",
				UId = new Guid("5f756cee-0c22-4f0d-929e-c43ca191a136"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("3977290d-f2e7-4b06-8ae3-6fed38f3facc"),
				CurveCenterPosition = new Point(490, 220),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("3977290d-f2e7-4b06-8ae3-6fed38f3facc"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("de7acea9-fd3f-47a2-ba11-fff451705433"),
				SourceSequenceFlowPointLocalPosition = new Point(0, -1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("1de13ccc-8965-4159-818b-5449cac1fc0b"),
				TargetSequenceFlowPointLocalPosition = new Point(0, -1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateLoggedEntitySchemasPresentConditionalFlowConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "LoggedEntitySchemasPresentConditionalFlow",
				UId = new Guid("7f103fb4-92a5-4d9e-a378-f3cfc7d50992"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ConditionExpression = @"!LoggedEntitySchemasPresent",
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("3977290d-f2e7-4b06-8ae3-6fed38f3facc"),
				CurveCenterPosition = new Point(216, 166),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("3977290d-f2e7-4b06-8ae3-6fed38f3facc"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("222ace1f-663b-41f4-b450-4d244b45013d"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("de7acea9-fd3f-47a2-ba11-fff451705433"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow415SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow415",
				UId = new Guid("339d6c0b-6049-4bff-a09e-ad5f37249a0c"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("3977290d-f2e7-4b06-8ae3-6fed38f3facc"),
				CurveCenterPosition = new Point(371, 173),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("3977290d-f2e7-4b06-8ae3-6fed38f3facc"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("e7fb1ce8-d9a7-4c82-b432-c1907a9dd517"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("b00da5b8-c91d-499d-99fe-93e3b0516cfb"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow416SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow416",
				UId = new Guid("69dc689f-11c1-4c2f-87ee-6b3d3fa3529a"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("3977290d-f2e7-4b06-8ae3-6fed38f3facc"),
				CurveCenterPosition = new Point(442, 232),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("3977290d-f2e7-4b06-8ae3-6fed38f3facc"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("b00da5b8-c91d-499d-99fe-93e3b0516cfb"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("baa0dd0f-5632-4baa-891d-5847954a2b64"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow419SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow419",
				UId = new Guid("d02022bf-f1bb-4e00-885e-e25323ef8b8d"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("3977290d-f2e7-4b06-8ae3-6fed38f3facc"),
				CurveCenterPosition = new Point(648, 159),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("3977290d-f2e7-4b06-8ae3-6fed38f3facc"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("52564b96-a184-4562-b0fc-98b0c83b3909"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("1de13ccc-8965-4159-818b-5449cac1fc0b"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateNeedShowMessageConditionalFlowConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "NeedShowMessageConditionalFlow",
				UId = new Guid("7db831e0-9d0f-40b6-b9ae-58be8fe89325"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ConditionExpression = @"NeedShowMessage",
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("3977290d-f2e7-4b06-8ae3-6fed38f3facc"),
				CurveCenterPosition = new Point(530, 156),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("3977290d-f2e7-4b06-8ae3-6fed38f3facc"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("9da7d414-98f0-403e-9bca-03052a544554"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("52564b96-a184-4562-b0fc-98b0c83b3909"),
				TargetSequenceFlowPointLocalPosition = new Point(0, -1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow1SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Default) {
				Name = "SequenceFlow1",
				UId = new Guid("4ac801fc-2d36-4b71-999b-d7f579866954"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("3977290d-f2e7-4b06-8ae3-6fed38f3facc"),
				CurveCenterPosition = new Point(645, 222),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Default,
				ManagerItemUId = new Guid("573ed909-e069-4161-b193-ae8dd9437c68"),
				ModifiedInSchemaUId = new Guid("3977290d-f2e7-4b06-8ae3-6fed38f3facc"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("9da7d414-98f0-403e-9bca-03052a544554"),
				SourceSequenceFlowPointLocalPosition = new Point(0, -1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("1de13ccc-8965-4159-818b-5449cac1fc0b"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow2SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow2",
				UId = new Guid("578aca5d-d441-484a-980e-4efa94bde409"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("3977290d-f2e7-4b06-8ae3-6fed38f3facc"),
				CurveCenterPosition = new Point(598, 194),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("3977290d-f2e7-4b06-8ae3-6fed38f3facc"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("baa0dd0f-5632-4baa-891d-5847954a2b64"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("9da7d414-98f0-403e-9bca-03052a544554"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaLaneSet CreateLaneSet42LaneSet() {
			ProcessSchemaLaneSet schemaLaneSet42 = new ProcessSchemaLaneSet(this) {
				UId = new Guid("a0cf982f-1416-4d32-b099-0591539c3e11"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 1,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("3977290d-f2e7-4b06-8ae3-6fed38f3facc"),
				Direction = ProcessSchemaPoolDirectionType.Vertical,
				DragGroupName = @"LaneSet",
				ManagerItemUId = new Guid("11a47caf-a0d5-41fa-a274-a0b11f77447a"),
				ModifiedInSchemaUId = new Guid("3977290d-f2e7-4b06-8ae3-6fed38f3facc"),
				Name = @"LaneSet42",
				Position = new Point(5, 5),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLaneSet42;
		}

		protected virtual ProcessSchemaLane CreateLane124Lane() {
			ProcessSchemaLane schemaLane124 = new ProcessSchemaLane(this) {
				UId = new Guid("b6ee5a9e-7eac-4a88-8074-6ac2ba479369"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 1,
				ContainerUId = new Guid("a0cf982f-1416-4d32-b099-0591539c3e11"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("3977290d-f2e7-4b06-8ae3-6fed38f3facc"),
				DragGroupName = @"Lane",
				ManagerItemUId = new Guid("abcd74b9-5912-414b-82ac-f1aa4dcd554e"),
				ModifiedInSchemaUId = new Guid("3977290d-f2e7-4b06-8ae3-6fed38f3facc"),
				Name = @"Lane124",
				Position = new Point(29, 0),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLane124;
		}

		protected virtual ProcessSchemaStartEvent CreateStart1StartEvent() {
			ProcessSchemaStartEvent schemaStartEvent = new ProcessSchemaStartEvent(this) {
				UId = new Guid("2167cf96-f197-444f-971b-a5a77fc7ff57"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = new Guid("b6ee5a9e-7eac-4a88-8074-6ac2ba479369"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("3977290d-f2e7-4b06-8ae3-6fed38f3facc"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsInterrupting = false,
				IsLogging = true,
				ManagerItemUId = new Guid("53818048-7868-48f6-ada0-0ebaa65af628"),
				ModifiedInSchemaUId = new Guid("3977290d-f2e7-4b06-8ae3-6fed38f3facc"),
				Name = @"Start1",
				Position = new Point(36, 79),
				SerializeToDB = false,
				Size = new Size(27, 27),
				UseBackgroundMode = false
			};
			
			return schemaStartEvent;
		}

		protected virtual ProcessSchemaEndEvent CreateEnd1EndEvent() {
			ProcessSchemaEndEvent schemaEndEvent = new ProcessSchemaEndEvent(this) {
				UId = new Guid("1de13ccc-8965-4159-818b-5449cac1fc0b"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = new Guid("b6ee5a9e-7eac-4a88-8074-6ac2ba479369"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("3977290d-f2e7-4b06-8ae3-6fed38f3facc"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsLogging = true,
				ManagerItemUId = new Guid("45ceaae2-4e1f-4c0c-86aa-cd4aeb4da913"),
				ModifiedInSchemaUId = new Guid("3977290d-f2e7-4b06-8ae3-6fed38f3facc"),
				Name = @"End1",
				Position = new Point(680, 212),
				SerializeToDB = false,
				Size = new Size(27, 27),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaEndEvent;
		}

		protected virtual ProcessSchemaScriptTask CreatePrepareParametersScriptTaskScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("222ace1f-663b-41f4-b450-4d244b45013d"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = new Guid("b6ee5a9e-7eac-4a88-8074-6ac2ba479369"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("3977290d-f2e7-4b06-8ae3-6fed38f3facc"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("3977290d-f2e7-4b06-8ae3-6fed38f3facc"),
				Name = @"PrepareParametersScriptTask",
				Position = new Point(148, 65),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,141,86,77,111,218,64,16,61,131,196,127,176,220,139,145,192,9,105,8,137,40,145,192,129,4,53,33,52,144,112,168,122,216,216,3,184,49,187,238,238,58,20,53,253,239,157,181,151,79,27,232,9,239,238,155,55,95,111,70,188,19,110,4,108,50,1,175,77,165,47,23,3,119,10,51,242,220,245,132,209,48,40,204,141,123,95,200,47,183,145,239,93,91,197,122,33,255,190,131,119,72,40,125,70,183,208,66,114,159,78,214,120,216,96,126,32,148,76,128,35,252,89,0,119,24,165,224,42,2,251,22,228,22,194,50,219,105,51,179,104,16,97,100,60,160,167,147,19,231,233,83,165,118,86,171,156,22,242,105,199,223,34,224,11,29,101,123,247,222,202,8,177,100,152,47,243,123,54,121,124,253,137,33,10,115,153,141,96,65,164,34,238,248,129,4,222,72,249,176,29,14,68,66,242,60,242,229,180,79,56,153,1,30,132,149,92,58,108,22,18,238,11,70,135,139,16,236,246,175,136,4,37,115,176,16,35,198,223,68,72,92,48,75,59,213,89,189,216,93,79,5,146,206,15,91,230,96,100,51,138,57,166,99,106,122,250,213,50,17,104,110,119,70,247,240,255,204,53,216,76,162,72,67,147,20,133,50,177,182,75,165,44,180,104,88,16,36,137,37,190,124,16,153,110,81,19,187,6,214,118,97,20,231,152,97,193,221,169,149,64,53,141,225,175,185,139,198,159,66,62,151,173,242,56,206,196,68,185,83,13,209,169,190,144,32,2,173,252,204,66,219,61,108,107,81,69,144,203,154,136,99,204,203,41,201,232,193,154,249,111,33,239,143,173,61,161,59,44,162,210,104,52,140,83,227,227,195,112,34,206,145,107,245,174,30,84,244,118,123,22,202,69,82,131,251,20,145,232,115,16,160,104,140,49,9,4,212,115,57,196,13,166,108,222,99,67,78,220,55,240,30,64,8,28,8,85,248,33,17,111,118,159,51,23,175,186,84,72,66,93,232,122,141,229,39,122,173,31,55,199,3,122,67,185,75,152,217,35,120,181,239,164,12,177,165,18,126,75,91,103,177,252,189,35,212,11,112,93,224,212,15,129,115,34,216,88,218,207,93,101,166,44,56,11,68,76,88,63,230,85,159,135,232,3,157,247,88,70,37,52,228,40,85,215,101,106,74,204,81,243,169,215,237,221,154,71,13,90,145,148,201,138,52,31,191,198,112,14,50,226,212,144,60,130,164,201,7,27,163,97,55,126,44,121,194,23,90,59,37,22,175,166,107,35,92,109,24,189,224,246,66,227,157,188,134,127,55,211,142,81,89,230,15,228,217,35,186,33,107,98,31,22,7,137,150,35,144,226,89,205,198,62,22,221,246,237,120,98,154,93,121,239,24,246,0,167,43,0,194,99,112,34,229,61,136,102,16,28,7,181,64,173,149,24,119,131,219,124,232,207,192,238,177,185,26,234,7,20,222,84,88,229,138,10,126,103,79,15,176,245,248,139,38,4,147,81,68,206,148,208,9,96,117,6,32,37,118,66,172,123,19,179,175,189,35,219,99,8,116,137,235,111,74,72,61,0,95,143,28,26,110,14,221,1,203,248,16,27,40,97,168,133,96,153,151,157,78,171,85,109,158,149,107,87,78,171,124,238,84,106,229,166,83,107,149,59,231,213,139,234,229,213,197,231,211,170,19,47,248,189,172,78,192,4,104,157,43,93,199,169,98,146,241,189,121,200,18,63,146,100,158,96,130,127,22,128,15,92,238,135,27,50,223,156,141,127,245,152,159,161,158,8,0,0 }
			};
			
			return ScriptTask;
		}

		protected virtual ProcessSchemaUserTask CreateOpenSettingsPageUserTaskUserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("e7fb1ce8-d9a7-4c82-b432-c1907a9dd517"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = new Guid("b6ee5a9e-7eac-4a88-8074-6ac2ba479369"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("3977290d-f2e7-4b06-8ae3-6fed38f3facc"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("1418e61a-82c3-403e-8221-01088f52c125"),
				ModifiedInSchemaUId = new Guid("3977290d-f2e7-4b06-8ae3-6fed38f3facc"),
				Name = @"OpenSettingsPageUserTask",
				Position = new Point(302, 65),
				SchemaUId = new Guid("b7042ef4-f468-443e-b3ea-39ebbda1c828"),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] {  }
			};
			InitializeOpenSettingsPageUserTaskParameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaUserTask CreateShowNoTrackedMessageUserTaskUserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("de7acea9-fd3f-47a2-ba11-fff451705433"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = new Guid("b6ee5a9e-7eac-4a88-8074-6ac2ba479369"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("3977290d-f2e7-4b06-8ae3-6fed38f3facc"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("1418e61a-82c3-403e-8221-01088f52c125"),
				ModifiedInSchemaUId = new Guid("3977290d-f2e7-4b06-8ae3-6fed38f3facc"),
				Name = @"ShowNoTrackedMessageUserTask",
				Position = new Point(149, 200),
				SchemaUId = new Guid("496a664f-3aab-43d7-ab1b-2521ab601aab"),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] {  }
			};
			InitializeShowNoTrackedMessageUserTaskParameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaIntermediateCatchMessageEvent CreateSettingsWindowClosedIntermediateCatchMessageEvent1IntermediateCatchMessageEvent() {
			ProcessSchemaIntermediateCatchMessageEvent schemaCatchMessageEvent = new ProcessSchemaIntermediateCatchMessageEvent(this) {
				UId = new Guid("b00da5b8-c91d-499d-99fe-93e3b0516cfb"),
				AttachedToUId = Guid.Empty,
				BackgroundModePriority = BackgroundModePriority.Inherited,
				BoundaryItemAlignment = ProcessSchemaEditItemAlignment.None,
				CancelActivity = false,
				ContainerItemIndex = 0,
				ContainerUId = new Guid("b6ee5a9e-7eac-4a88-8074-6ac2ba479369"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("3977290d-f2e7-4b06-8ae3-6fed38f3facc"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				ImageList = null,
				ImageName = null,
				IsLogging = true,
				ManagerItemUId = new Guid("3cb9d737-779e-4085-ab4b-db590853e266"),
				Message = @"ClearLogClose",
				ModifiedInSchemaUId = new Guid("3977290d-f2e7-4b06-8ae3-6fed38f3facc"),
				Name = @"SettingsWindowClosedIntermediateCatchMessageEvent1",
				Position = new Point(323, 198),
				SerializeToDB = false,
				Size = new Size(27, 27),
				UseBackgroundMode = false
			};
			
			return schemaCatchMessageEvent;
		}

		protected virtual ProcessSchemaScriptTask CreateClearIfNecessaryScriptTaskScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("baa0dd0f-5632-4baa-891d-5847954a2b64"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = new Guid("b6ee5a9e-7eac-4a88-8074-6ac2ba479369"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("3977290d-f2e7-4b06-8ae3-6fed38f3facc"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("3977290d-f2e7-4b06-8ae3-6fed38f3facc"),
				Name = @"ClearIfNecessaryScriptTask",
				Position = new Point(442, 184),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,133,82,95,111,218,48,16,127,78,165,126,7,43,79,70,66,249,2,45,149,10,165,52,90,7,211,18,212,7,196,131,137,143,224,45,216,200,190,148,161,105,223,125,103,227,12,49,182,242,128,130,207,191,127,119,190,41,128,44,54,102,255,25,156,19,53,176,1,91,139,198,193,221,237,205,147,170,80,25,45,236,225,222,161,85,186,238,155,213,55,168,240,129,237,132,21,91,64,176,110,192,255,139,234,205,29,216,145,209,26,2,32,43,200,128,190,79,2,197,34,29,53,32,236,104,35,116,13,175,166,46,0,145,152,238,164,149,46,41,128,90,115,190,50,166,233,157,252,22,233,148,242,6,118,186,236,177,159,183,55,201,171,114,120,63,105,149,124,96,174,218,192,86,184,210,4,0,9,15,52,236,217,9,192,123,119,9,49,62,214,125,108,154,78,58,185,16,204,30,165,252,234,83,115,238,21,23,203,51,13,2,212,32,199,26,21,30,138,64,205,165,35,49,234,37,249,69,63,160,193,126,32,124,212,60,83,28,181,214,130,198,115,201,78,209,247,66,227,132,82,109,129,173,96,109,172,127,62,222,149,254,221,222,48,224,104,190,137,167,251,255,162,218,4,99,6,103,46,76,233,203,129,198,185,116,199,103,99,143,209,248,57,183,31,227,252,233,252,93,88,182,179,166,162,29,160,136,127,109,70,254,229,120,51,214,181,210,144,77,0,99,97,120,152,231,146,79,172,146,177,64,199,172,52,69,216,51,222,11,234,81,53,43,55,214,236,199,239,148,131,119,165,92,83,239,90,52,100,133,240,3,251,44,157,133,213,60,238,157,76,3,127,122,177,255,104,91,191,254,137,175,134,70,65,198,75,159,187,20,238,123,22,227,228,218,161,208,21,208,176,6,172,59,80,198,107,236,163,79,113,112,8,219,236,13,86,217,11,226,46,166,204,226,147,119,223,23,161,101,3,150,9,199,74,176,86,56,179,198,108,158,123,154,103,88,211,184,32,120,197,51,158,75,114,32,235,0,162,25,22,109,229,251,88,183,77,188,191,162,146,87,70,19,61,205,167,207,179,244,10,118,216,34,26,237,159,59,157,125,242,96,218,3,11,216,90,221,77,248,55,72,214,81,248,123,4,0,0 }
			};
			
			return ScriptTask;
		}

		protected virtual ProcessSchemaUserTask CreateShowClearedMessageUserTaskUserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("52564b96-a184-4562-b0fc-98b0c83b3909"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = new Guid("b6ee5a9e-7eac-4a88-8074-6ac2ba479369"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("3977290d-f2e7-4b06-8ae3-6fed38f3facc"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("1418e61a-82c3-403e-8221-01088f52c125"),
				ModifiedInSchemaUId = new Guid("3977290d-f2e7-4b06-8ae3-6fed38f3facc"),
				Name = @"ShowClearedMessageUserTask",
				Position = new Point(464, 67),
				SchemaUId = new Guid("496a664f-3aab-43d7-ab1b-2521ab601aab"),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] {  }
			};
			InitializeShowClearedMessageUserTaskParameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaExclusiveGateway CreateNeedShowMessageExclusiveGatewayExclusiveGateway() {
			ProcessSchemaExclusiveGateway gateway = new ProcessSchemaExclusiveGateway(this) {
				UId = new Guid("9da7d414-98f0-403e-9bca-03052a544554"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = new Guid("b6ee5a9e-7eac-4a88-8074-6ac2ba479369"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("3977290d-f2e7-4b06-8ae3-6fed38f3facc"),
				DragGroupName = @"Gateway",
				ImageList = null,
				ImageName = null,
				IsLogging = true,
				ManagerItemUId = new Guid("bd9f7570-6c97-4f16-90e5-663a190c6c7c"),
				ModifiedInSchemaUId = new Guid("3977290d-f2e7-4b06-8ae3-6fed38f3facc"),
				Name = @"NeedShowMessageExclusiveGateway",
				Position = new Point(568, 135),
				SerializeToDB = false,
				Size = new Size(55, 55),
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
				UId = new Guid("6c62ab5d-9e27-4000-8ca4-81181c25c776"),
				Name = "System.Data",
				Alias = "",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("df193006-9f76-43bc-ab1a-6aec4e5ce5ad"),
				Name = "Terrasoft.UI.WebControls.Controls",
				Alias = "",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("22b30d13-e760-4258-9b8a-fc8c307e26b7"),
				Name = "Terrasoft.Core.Entities",
				Alias = "",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			});
		}

		#endregion

		#region Methods: Public

		public override Process CreateProcess(UserConnection userConnection) {
			return new ClearChangeLogProcess(userConnection);
		}

		public override object Clone() {
			return new ClearChangeLogProcessSchema(this);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("3977290d-f2e7-4b06-8ae3-6fed38f3facc"));
		}

		#endregion

	}

	#endregion

	#region Class: ClearChangeLogProcess

	/// <exclude/>
	public class ClearChangeLogProcess : Terrasoft.Core.Process.Process
	{

		#region Class: ProcessLane124

		/// <exclude/>
		public class ProcessLane124 : ProcessLane
		{

			public ProcessLane124(UserConnection userConnection, ClearChangeLogProcess process)
				: base(userConnection) {
				Owner = process;
				IsUsedParentUserContexts = false;
			}

		}

		#endregion

		#region Class: OpenSettingsPageUserTaskFlowElement

		/// <exclude/>
		public class OpenSettingsPageUserTaskFlowElement : OpenPageUserTask
		{

			#region Constructors: Public

			public OpenSettingsPageUserTaskFlowElement(UserConnection userConnection, ClearChangeLogProcess process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "OpenSettingsPageUserTask";
				IsLogging = true;
				SchemaElementUId = new Guid("e7fb1ce8-d9a7-4c82-b432-c1907a9dd517");
				CreatedInSchemaUId = process.InternalSchemaUId;
			}

			#endregion

		}

		#endregion

		#region Class: ShowNoTrackedMessageUserTaskFlowElement

		/// <exclude/>
		public class ShowNoTrackedMessageUserTaskFlowElement : QuestionUserTask
		{

			#region Constructors: Public

			public ShowNoTrackedMessageUserTaskFlowElement(UserConnection userConnection, ClearChangeLogProcess process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "ShowNoTrackedMessageUserTask";
				IsLogging = true;
				SchemaElementUId = new Guid("de7acea9-fd3f-47a2-ba11-fff451705433");
				CreatedInSchemaUId = process.InternalSchemaUId;
			}

			#endregion

		}

		#endregion

		#region Class: ShowClearedMessageUserTaskFlowElement

		/// <exclude/>
		public class ShowClearedMessageUserTaskFlowElement : QuestionUserTask
		{

			#region Constructors: Public

			public ShowClearedMessageUserTaskFlowElement(UserConnection userConnection, ClearChangeLogProcess process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "ShowClearedMessageUserTask";
				IsLogging = true;
				SchemaElementUId = new Guid("52564b96-a184-4562-b0fc-98b0c83b3909");
				CreatedInSchemaUId = process.InternalSchemaUId;
			}

			#endregion

		}

		#endregion

		public ClearChangeLogProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ClearChangeLogProcess";
			SchemaUId = new Guid("3977290d-f2e7-4b06-8ae3-6fed38f3facc");
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
				return new Guid("3977290d-f2e7-4b06-8ae3-6fed38f3facc");
			}
		}

		private string ConditionalExpressionLogMessage {
			get {
				return "Process: ClearChangeLogProcess, Source element: {0}, Conditional flow: {1}, Expression: {2}, Result: {3}";
			}
		}

		private string DeadEndGatewayLogMessage {
			get {
				return "Process: ClearChangeLogProcess, Source element: {0}, None of the exclusive gateway conditions are met!";
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

		public virtual Object Page {
			get;
			set;
		}

		public virtual bool NeedShowMessage {
			get;
			set;
		}

		public virtual bool LoggedEntitySchemasPresent {
			get;
			set;
		}

		public virtual Guid CurrentSchemaUId {
			get;
			set;
		}

		public virtual string GridProcessUId {
			get;
			set;
		}

		private LocalizableString _clearingSuccessfulMessage;
		public virtual LocalizableString ClearingSuccessfulMessage {
			get {
				return _clearingSuccessfulMessage ?? (_clearingSuccessfulMessage = GetLocalizableString("3977290df2e74b068ae36fed38f3facc",
						 "Parameters.ClearingSuccessfulMessage.Value"));
			}
			set {
				_clearingSuccessfulMessage = value;
			}
		}

		private LocalizableString _noLoggedEntitySchemasMessage;
		public virtual LocalizableString NoLoggedEntitySchemasMessage {
			get {
				return _noLoggedEntitySchemasMessage ?? (_noLoggedEntitySchemasMessage = GetLocalizableString("3977290df2e74b068ae36fed38f3facc",
						 "Parameters.NoLoggedEntitySchemasMessage.Value"));
			}
			set {
				_noLoggedEntitySchemasMessage = value;
			}
		}

		private ProcessLane124 _lane124;
		public ProcessLane124 Lane124 {
			get {
				return _lane124 ?? ((_lane124) = new ProcessLane124(UserConnection, this));
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
					SchemaElementUId = new Guid("2167cf96-f197-444f-971b-a5a77fc7ff57"),
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
					SchemaElementUId = new Guid("1de13ccc-8965-4159-818b-5449cac1fc0b"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
				});
			}
		}

		private ProcessScriptTask _prepareParametersScriptTask;
		public ProcessScriptTask PrepareParametersScriptTask {
			get {
				return _prepareParametersScriptTask ?? (_prepareParametersScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "PrepareParametersScriptTask",
					SchemaElementUId = new Guid("222ace1f-663b-41f4-b450-4d244b45013d"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = PrepareParametersScriptTaskExecute,
				});
			}
		}

		private OpenSettingsPageUserTaskFlowElement _openSettingsPageUserTask;
		public OpenSettingsPageUserTaskFlowElement OpenSettingsPageUserTask {
			get {
				return _openSettingsPageUserTask ?? (_openSettingsPageUserTask = new OpenSettingsPageUserTaskFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private ShowNoTrackedMessageUserTaskFlowElement _showNoTrackedMessageUserTask;
		public ShowNoTrackedMessageUserTaskFlowElement ShowNoTrackedMessageUserTask {
			get {
				return _showNoTrackedMessageUserTask ?? (_showNoTrackedMessageUserTask = new ShowNoTrackedMessageUserTaskFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private ProcessIntermediateCatchMessageEvent _settingsWindowClosedIntermediateCatchMessageEvent1;
		public ProcessIntermediateCatchMessageEvent SettingsWindowClosedIntermediateCatchMessageEvent1 {
			get {
				return _settingsWindowClosedIntermediateCatchMessageEvent1 ?? (_settingsWindowClosedIntermediateCatchMessageEvent1 = new ProcessIntermediateCatchMessageEvent() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaIntermediateCatchMessageEvent",
					Name = "SettingsWindowClosedIntermediateCatchMessageEvent1",
					SchemaElementUId = new Guid("b00da5b8-c91d-499d-99fe-93e3b0516cfb"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
						Message = "ClearLogClose",
				});
			}
		}

		private ProcessScriptTask _clearIfNecessaryScriptTask;
		public ProcessScriptTask ClearIfNecessaryScriptTask {
			get {
				return _clearIfNecessaryScriptTask ?? (_clearIfNecessaryScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ClearIfNecessaryScriptTask",
					SchemaElementUId = new Guid("baa0dd0f-5632-4baa-891d-5847954a2b64"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = ClearIfNecessaryScriptTaskExecute,
				});
			}
		}

		private ShowClearedMessageUserTaskFlowElement _showClearedMessageUserTask;
		public ShowClearedMessageUserTaskFlowElement ShowClearedMessageUserTask {
			get {
				return _showClearedMessageUserTask ?? (_showClearedMessageUserTask = new ShowClearedMessageUserTaskFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private ProcessExclusiveGateway _needShowMessageExclusiveGateway;
		public ProcessExclusiveGateway NeedShowMessageExclusiveGateway {
			get {
				return _needShowMessageExclusiveGateway ?? (_needShowMessageExclusiveGateway = new ProcessExclusiveGateway() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaExclusiveGateway",
					Name = "NeedShowMessageExclusiveGateway",
					SchemaElementUId = new Guid("9da7d414-98f0-403e-9bca-03052a544554"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
						Question = GetLocalizableString(Schema.GetResourceManagerName(),
					"BaseElements.NeedShowMessageExclusiveGateway.Question"),
						IsDecisionRequired = false,
						BranchingMode = GatewayBranchingMode.Auto,
						DecisionMode = GetewayDecisionSelectionMode.Single,
						ShowUserDecisionDialog = (processId, gatewayName) => {},
				});
			}
		}

		private ProcessConditionalFlow _loggedEntitySchemasPresentConditionalFlow;
		public ProcessConditionalFlow LoggedEntitySchemasPresentConditionalFlow {
			get {
				return _loggedEntitySchemasPresentConditionalFlow ?? (_loggedEntitySchemasPresentConditionalFlow = new ProcessConditionalFlow() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaConditionalFlow",
					Name = "LoggedEntitySchemasPresentConditionalFlow",
					SchemaElementUId = new Guid("7f103fb4-92a5-4d9e-a378-f3cfc7d50992"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						MatchBranchingDecisions = new BranchingDecisionCollection() {
				},
				});
			}
		}

		private ProcessConditionalFlow _needShowMessageConditionalFlow;
		public ProcessConditionalFlow NeedShowMessageConditionalFlow {
			get {
				return _needShowMessageConditionalFlow ?? (_needShowMessageConditionalFlow = new ProcessConditionalFlow() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaConditionalFlow",
					Name = "NeedShowMessageConditionalFlow",
					SchemaElementUId = new Guid("7db831e0-9d0f-40b6-b9ae-58be8fe89325"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						MatchBranchingDecisions = new BranchingDecisionCollection() {
				},
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[Start1.SchemaElementUId] = new Collection<ProcessFlowElement> { Start1 };
			FlowElements[End1.SchemaElementUId] = new Collection<ProcessFlowElement> { End1 };
			FlowElements[PrepareParametersScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { PrepareParametersScriptTask };
			FlowElements[OpenSettingsPageUserTask.SchemaElementUId] = new Collection<ProcessFlowElement> { OpenSettingsPageUserTask };
			FlowElements[ShowNoTrackedMessageUserTask.SchemaElementUId] = new Collection<ProcessFlowElement> { ShowNoTrackedMessageUserTask };
			FlowElements[SettingsWindowClosedIntermediateCatchMessageEvent1.SchemaElementUId] = new Collection<ProcessFlowElement> { SettingsWindowClosedIntermediateCatchMessageEvent1 };
			FlowElements[ClearIfNecessaryScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { ClearIfNecessaryScriptTask };
			FlowElements[ShowClearedMessageUserTask.SchemaElementUId] = new Collection<ProcessFlowElement> { ShowClearedMessageUserTask };
			FlowElements[NeedShowMessageExclusiveGateway.SchemaElementUId] = new Collection<ProcessFlowElement> { NeedShowMessageExclusiveGateway };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "Start1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("PrepareParametersScriptTask", e.Context.SenderName));
						break;
					case "End1":
						CompleteProcess();
						break;
					case "PrepareParametersScriptTask":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("OpenSettingsPageUserTask", e.Context.SenderName));
						if (LoggedEntitySchemasPresentConditionalFlowExpressionExecute()) {
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ShowNoTrackedMessageUserTask", e.Context.SenderName));
							break;
						}
						Log.ErrorFormat(DeadEndGatewayLogMessage, "PrepareParametersScriptTask");
						break;
					case "OpenSettingsPageUserTask":
						ActivatedEventElements.Add("SettingsWindowClosedIntermediateCatchMessageEvent1");
						break;
					case "ShowNoTrackedMessageUserTask":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("End1", e.Context.SenderName));
						break;
					case "SettingsWindowClosedIntermediateCatchMessageEvent1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ClearIfNecessaryScriptTask", e.Context.SenderName));
						break;
					case "ClearIfNecessaryScriptTask":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("NeedShowMessageExclusiveGateway", e.Context.SenderName));
						break;
					case "ShowClearedMessageUserTask":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("End1", e.Context.SenderName));
						break;
					case "NeedShowMessageExclusiveGateway":
						if (NeedShowMessageConditionalFlowExpressionExecute()) {
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ShowClearedMessageUserTask", e.Context.SenderName));
							break;
						}
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("End1", e.Context.SenderName));
						break;
			}
		}

		private bool LoggedEntitySchemasPresentConditionalFlowExpressionExecute() {
			bool result = Convert.ToBoolean(!LoggedEntitySchemasPresent);
			Log.InfoFormat(ConditionalExpressionLogMessage, "PrepareParametersScriptTask", "LoggedEntitySchemasPresentConditionalFlow", "!LoggedEntitySchemasPresent", result);
			return result;
		}

		private bool NeedShowMessageConditionalFlowExpressionExecute() {
			bool result = Convert.ToBoolean(NeedShowMessage);
			Log.InfoFormat(ConditionalExpressionLogMessage, "NeedShowMessageExclusiveGateway", "NeedShowMessageConditionalFlow", "NeedShowMessage", result);
			return result;
		}

		private void WritePropertyValues(DataWriter writer, bool useAllValueSources) {
			if (!HasMapping("PageInstanceId")) {
				writer.WriteValue("PageInstanceId", PageInstanceId, null);
			}
			if (Page != null) {
				if (Page.GetType().IsSerializable ||
					Page.GetType().GetInterface("ISerializable") != null) {
					WriteSerializableObject(writer, "Page", Page, null);
				}
			}
			if (!HasMapping("NeedShowMessage")) {
				writer.WriteValue("NeedShowMessage", NeedShowMessage, false);
			}
			if (!HasMapping("LoggedEntitySchemasPresent")) {
				writer.WriteValue("LoggedEntitySchemasPresent", LoggedEntitySchemasPresent, false);
			}
			if (!HasMapping("CurrentSchemaUId")) {
				writer.WriteValue("CurrentSchemaUId", CurrentSchemaUId, Guid.Empty);
			}
			if (!HasMapping("GridProcessUId")) {
				writer.WriteValue("GridProcessUId", GridProcessUId, null);
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
			MetaPathParameterValues.Add("88798994-3a8b-4d20-854a-17028f8d0de8", () => PageInstanceId);
			MetaPathParameterValues.Add("b4246ed2-6dca-4604-a398-78215b1b7eb7", () => Page);
			MetaPathParameterValues.Add("f347d6a7-bc75-4d05-a5c6-3efae0852c5b", () => NeedShowMessage);
			MetaPathParameterValues.Add("939c77c0-50c2-4e54-8262-b9916a10eaa0", () => LoggedEntitySchemasPresent);
			MetaPathParameterValues.Add("88784240-8faa-4042-87d6-4b0cc3bc1a2a", () => CurrentSchemaUId);
			MetaPathParameterValues.Add("5f56e336-ffea-4d08-814e-11d712a6b3e3", () => GridProcessUId);
			MetaPathParameterValues.Add("d8451c10-cf36-470a-b74e-1cc7774c2e43", () => ClearingSuccessfulMessage);
			MetaPathParameterValues.Add("4936d7ab-ede1-440e-a617-4f6b6df29680", () => NoLoggedEntitySchemasMessage);
			MetaPathParameterValues.Add("947ae31b-cd23-430a-bb8f-7241b4720103", () => OpenSettingsPageUserTask.PageUId);
			MetaPathParameterValues.Add("9bde68e7-06a7-4751-9781-06b3754b48b7", () => OpenSettingsPageUserTask.PageUrl);
			MetaPathParameterValues.Add("49358ca4-34c7-47b5-a5aa-b5b67550d216", () => OpenSettingsPageUserTask.OpenerInstanceId);
			MetaPathParameterValues.Add("34038892-d974-4aba-8314-f1dd674ad0fe", () => OpenSettingsPageUserTask.CloseOpenerOnLoad);
			MetaPathParameterValues.Add("8df2aea7-612c-4bad-84e9-e30ea7f09e8f", () => OpenSettingsPageUserTask.PageParameters);
			MetaPathParameterValues.Add("5cade72b-85a0-49fe-816c-1b22e2dc0d8a", () => OpenSettingsPageUserTask.Width);
			MetaPathParameterValues.Add("4bb355ef-5767-4f36-bef7-76b3d4588aa7", () => OpenSettingsPageUserTask.CloseMessage);
			MetaPathParameterValues.Add("f6b3d22f-3018-4520-b406-1cf86fccae76", () => OpenSettingsPageUserTask.Height);
			MetaPathParameterValues.Add("91b530ef-ca1d-4eff-8d4f-3fefeb154b34", () => OpenSettingsPageUserTask.Centered);
			MetaPathParameterValues.Add("af84ebdf-f659-46b1-87f8-a4dcbe9855ca", () => OpenSettingsPageUserTask.UseOpenerRegisterScript);
			MetaPathParameterValues.Add("828fea8b-d25c-476a-90a0-7236d248165c", () => OpenSettingsPageUserTask.UseCurrentActivePage);
			MetaPathParameterValues.Add("618752b8-186d-44cf-8461-9fe563281840", () => OpenSettingsPageUserTask.IgnoreProfile);
			MetaPathParameterValues.Add("b1f8890e-49f8-483e-8367-ca7b2e363461", () => ShowNoTrackedMessageUserTask.Page);
			MetaPathParameterValues.Add("43ffb68a-6415-4275-82e2-25b8642ab04f", () => ShowNoTrackedMessageUserTask.Icon);
			MetaPathParameterValues.Add("4138a7e3-d8a8-4c07-b0fb-dd2eca81d036", () => ShowNoTrackedMessageUserTask.Buttons);
			MetaPathParameterValues.Add("7c854a73-1b08-403b-8bd1-55a745b98e2d", () => ShowNoTrackedMessageUserTask.WindowCaption);
			MetaPathParameterValues.Add("c997df75-4855-4ae6-817a-bcb2aeb43b42", () => ShowNoTrackedMessageUserTask.MessageText);
			MetaPathParameterValues.Add("81ed9542-b4ee-4d60-9fd7-2b4018da7bba", () => ShowNoTrackedMessageUserTask.ResponseMessages);
			MetaPathParameterValues.Add("e03fddf1-410e-4633-b63a-8e999b3af86b", () => ShowNoTrackedMessageUserTask.ProcessInstanceId);
			MetaPathParameterValues.Add("c99bed8c-3a2a-43b0-98b2-ff8eefbb783a", () => ShowNoTrackedMessageUserTask.PageParameters);
			MetaPathParameterValues.Add("91f526be-f71a-451c-877a-4a7e236e3d67", () => ShowClearedMessageUserTask.Page);
			MetaPathParameterValues.Add("27d1ec03-d4cb-4a35-9477-ad537ff7e28e", () => ShowClearedMessageUserTask.Icon);
			MetaPathParameterValues.Add("9b66906c-369a-4fc8-bb76-d789c5c13b03", () => ShowClearedMessageUserTask.Buttons);
			MetaPathParameterValues.Add("21615c4d-7cd2-4de7-922d-d8653ae3eda3", () => ShowClearedMessageUserTask.WindowCaption);
			MetaPathParameterValues.Add("4eb22089-e449-43fe-a117-92ca5b74c36a", () => ShowClearedMessageUserTask.MessageText);
			MetaPathParameterValues.Add("4f87cb10-e46e-4dec-bcd6-3008131751ae", () => ShowClearedMessageUserTask.ResponseMessages);
			MetaPathParameterValues.Add("d82c9d90-c135-401c-b232-9f50aea2ba7f", () => ShowClearedMessageUserTask.ProcessInstanceId);
			MetaPathParameterValues.Add("8a4dab2c-626e-4002-91e8-e38f45505adf", () => ShowClearedMessageUserTask.PageParameters);
		}

		protected override void ApplyPropertiesDataValues(DataReader reader) {
			base.ApplyPropertiesDataValues(reader);
			bool hasValueToRead = reader.HasValue();
			switch (reader.CurrentName) {
				case "PageInstanceId":
					if (!hasValueToRead) break;
					PageInstanceId = reader.GetValue<System.String>();
				break;
				case "Page":
					if (!hasValueToRead) break;
					Page = GetSerializableObject(reader);
				break;
				case "NeedShowMessage":
					if (!hasValueToRead) break;
					NeedShowMessage = reader.GetValue<System.Boolean>();
				break;
				case "LoggedEntitySchemasPresent":
					if (!hasValueToRead) break;
					LoggedEntitySchemasPresent = reader.GetValue<System.Boolean>();
				break;
				case "CurrentSchemaUId":
					if (!hasValueToRead) break;
					CurrentSchemaUId = reader.GetValue<System.Guid>();
				break;
				case "GridProcessUId":
					if (!hasValueToRead) break;
					GridProcessUId = reader.GetValue<System.String>();
				break;
			}
		}

		protected override void WritePropertyValues(DataWriter writer) {
			base.WritePropertyValues(writer);
			WritePropertyValues(writer, true);
		}

		#endregion

		#region Methods: Public

		public virtual bool PrepareParametersScriptTaskExecute(ProcessExecutingContext context) {
			var loggedEntitySchemaUIds = new List<Guid>();
			var loggedEntityCaptions = new List<string>();
			var entitySchemaManager = UserConnection.GetSchemaManager("EntitySchemaManager") as EntitySchemaManager;
			//CR#172710
			
			var entitySchemaQuery = new EntitySchemaQuery(entitySchemaManager, "VwLogObjects");
			var solutionFilter=entitySchemaQuery.CreateFilterWithParameters(FilterComparisonType.Equal,"SysWorkspace",UserConnection.Workspace.Id);
			
			var entitySchemaUIdColumn = entitySchemaQuery.AddColumn("UId");
			var entityCaptionColumn = entitySchemaQuery.AddColumn("Caption");
			
			entitySchemaQuery.Filters.Add(solutionFilter);
			EntityCollection entities = entitySchemaQuery.GetEntityCollection(UserConnection);
			foreach(Entity entity in entities) {
				loggedEntitySchemaUIds.Add(entity.GetTypedColumnValue<Guid>(entitySchemaUIdColumn.Name));
				loggedEntityCaptions.Add(entity.GetTypedColumnValue<string>(entityCaptionColumn.Name));
			}
			if(loggedEntitySchemaUIds.Count == 0 || CurrentSchemaUId == Guid.Empty) {
				LoggedEntitySchemasPresent = false;		
				ShowNoTrackedMessageUserTask.ProcessInstanceId=InstanceUId;	
				ShowNoTrackedMessageUserTask.Page = System.Web.HttpContext.Current.CurrentHandler as Terrasoft.UI.WebControls.Page;
				ShowNoTrackedMessageUserTask.MessageText = NoLoggedEntitySchemasMessage;
				ShowNoTrackedMessageUserTask.Icon = "WARNING";
				ShowNoTrackedMessageUserTask.Buttons = "OK";
				return true;
			}
			LoggedEntitySchemasPresent = true;
			Dictionary<string,object> parameters = new Dictionary<string,object>();
			parameters["LoggedEntitySchemaIds"] = loggedEntitySchemaUIds.ToArray();
			parameters["LoggedEntityCaptions"] = loggedEntityCaptions.ToArray();
			parameters["CurrentEntitySchemaId"] = CurrentSchemaUId;
			parameters["NeedClear"] = false;
			parameters["NeedClearAll"] = false;
			parameters["NeedClearBefore"] = DateTime.Now.AddMonths(-1);
			UserConnection.SessionData["ClearChangeLogSettingsDictionary"] = parameters;
			OpenSettingsPageUserTask.OpenerInstanceId = InstanceUId;
			OpenSettingsPageUserTask.PageUId = new Guid("8FFBB5A2-79CB-4C17-AC7B-F4565896305C");
			OpenSettingsPageUserTask.CloseMessage = "ClearLogClose";
			OpenSettingsPageUserTask.UseOpenerRegisterScript = true;
			return true;
		}

		public virtual bool ClearIfNecessaryScriptTaskExecute(ProcessExecutingContext context) {
			NeedShowMessage = false;
			Dictionary<string,object> parameters=(Dictionary<string,object>)UserConnection.SessionData["ClearChangeLogSettingsDictionary"];
			if((bool)parameters["NeedClear"]) {
				List<Guid> schemasToClearLog=new List<Guid>();	
				if((bool)parameters["NeedClearAll"]) {
					schemasToClearLog.AddRange((Guid[])parameters["LoggedEntitySchemaIds"]);
				}
				else {
					schemasToClearLog.Add((Guid)parameters["CurrentEntitySchemaId"]);
				}	
				DateTime before = (DateTime)parameters["NeedClearBefore"];		
				foreach(Guid entitySchemaId in schemasToClearLog) {
					ClearLogForEntity(entitySchemaId, before);
				}
				var process = UserConnection.IProcessEngine.GetProcessByUId(GridProcessUId.ToString());
				process.ThrowEvent(process.InternalContext, "ObjectChanged");
				NeedShowMessage = true;
				ShowClearedMessageUserTask.ProcessInstanceId = InstanceUId;
				ShowClearedMessageUserTask.Page = System.Web.HttpContext.Current.CurrentHandler as Terrasoft.UI.WebControls.Page;
				ShowClearedMessageUserTask.MessageText = ClearingSuccessfulMessage;
				ShowClearedMessageUserTask.Icon = "INFO";
				ShowClearedMessageUserTask.Buttons = "OK";
			}
			return true;
		}

			
			public virtual void ClearLogForEntity(Guid entitySchemaId, DateTime before) {
				Select tableNameSelect = new Select(UserConnection).Distinct().Column("Name").From("VwSysSchemaInWorkspace").Where("UId").IsEqual(new QueryParameter(entitySchemaId)) as Select;
				using (DBExecutor dbExecutor = UserConnection.EnsureDBConnection()) {
					using (var dr = tableNameSelect.ExecuteReader(dbExecutor)) {
						while(dr.Read()) {
							string tableName = string.Concat("Sys", dr[0].ToString(), "Log");
							var delete = new Delete(UserConnection).From(tableName).Where("ChangeTrackedOn")
									.IsLess(Column.Parameter(TimeZoneInfo.ConvertTimeToUtc(before), "DateTime"));
							delete.Execute();
						}
					}
				}
			}
			

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "ClearLogClose":
					if (ActivatedEventElements.Remove("SettingsWindowClosedIntermediateCatchMessageEvent1")) {
						context.QueueTasksV2.Enqueue(new ProcessQueueElement("SettingsWindowClosedIntermediateCatchMessageEvent1", "SettingsWindowClosedIntermediateCatchMessageEvent1"));
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
			var cloneItem = (ClearChangeLogProcess)base.CloneShallow();
			cloneItem.ExecutedEventHandler = ExecutedEventHandler;
			cloneItem.Page = Page;
			return cloneItem;
		}

		#endregion

	}

	#endregion

}

