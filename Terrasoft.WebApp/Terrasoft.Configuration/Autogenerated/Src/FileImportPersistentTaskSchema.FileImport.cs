namespace Terrasoft.Core.Process.Configuration
{

	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Configuration.FileImport;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Factories;
	using Terrasoft.Core.Process;
	using Terrasoft.UI.WebControls.Controls;

	#region Class: FileImportPersistentTaskSchema

	/// <exclude/>
	public class FileImportPersistentTaskSchema : Terrasoft.Core.Process.ProcessUserTaskSchema
	{

		#region Constructors: Public

		public FileImportPersistentTaskSchema(ProcessUserTaskSchemaManager processUserTaskSchemaManager)
			: base(processUserTaskSchemaManager) {
		}

		public FileImportPersistentTaskSchema(ProcessUserTaskSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("4a4279e7-7ad3-4bc4-a92b-e762eeee9c8e");
			RealUId = new Guid("4a4279e7-7ad3-4bc4-a92b-e762eeee9c8e");
			Name = "FileImportPersistentTask";
			CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8");
			UsageType = ProcessSchemaUsageType.Advanced;
			ParametersEditPageSchemaUId = Guid.Empty;
			ParametersEditPageSchemaV2UId = Guid.Empty;
			DcmParametersEditPageSchemaV2UId = Guid.Empty;
			ZipExecuteBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,117,205,77,10,131,48,16,5,224,189,167,8,174,34,148,92,32,20,10,34,146,85,75,139,7,8,102,42,1,157,132,153,177,63,183,111,74,221,116,225,242,241,120,223,59,213,15,79,42,46,57,145,92,60,249,5,4,136,175,144,19,71,73,244,86,71,213,131,184,221,94,15,12,212,38,68,24,37,38,108,108,181,111,153,33,7,47,176,97,148,70,96,118,65,255,242,173,132,2,184,112,80,253,26,131,41,0,131,62,63,17,104,112,161,41,240,255,147,217,128,14,167,136,96,218,180,228,185,252,117,47,24,87,137,56,233,239,202,86,4,178,18,170,187,159,25,108,253,1,39,194,23,101,238,0,0,0 };
			SerializeToDB = false;
			IsUserTask = false;
			IsPartial = false;
		}

		protected override void InitializeParameters() {
			base.InitializeParameters();
			SetParametersDefInheritance();
			Parameters.Add(CreateImportSessionIdParameter());
		}

		protected virtual ProcessSchemaParameter CreateImportSessionIdParameter() {
			return new ProcessSchemaParameter(SchemaManagerProvider) {
				UId = new Guid("eab23d00-5110-4cc1-a7a6-95fd2039de56"),
				Name = "ImportSessionId",
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid"),
				ReferenceSchemaUId = Guid.Empty,
				IsResult = false,
				IsPerformer = false,
				IsValueSerializable = true,
				IsRequired = false,
				IsLazy = false
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
			Methods.Add(CreateGetResultParameterAllValuesMethod());
			Methods.Add(CreateCompleteExecutingMethod());
			Methods.Add(CreateCancelExecutingMethod());
			Methods.Add(CreateGetExecutionDataMethod());
			Methods.Add(CreateSynchronizeDynamicParametersMethod());
			Methods.Add(CreateSynchronizeParametersMethod());
			Methods.Add(CreateGetNotificationDataMethod());
			Methods.Add(CreateGetPersistentFileImporterMethod());
			Methods.Add(CreateGetImportParametersRepositoryMethod());
		}

		protected override void InitializeUsings() {
			Usings.Add(new SchemaUsing() {
				UId = new Guid("a24fa397-e164-47cb-8cdf-1ed6bc45647b"),
				Name = "Terrasoft.Configuration.FileImport",
				Alias = "",
				CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("e83b02ee-b8b9-4a17-b1e7-9c6dcef373ab"),
				Name = "Terrasoft.Core.Factories",
				Alias = "",
				CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8")
			});
		}

		protected virtual SchemaMethod CreateGetResultParameterAllValuesMethod() {
			SchemaMethod method = new SchemaMethod() {
				UId = new Guid("07a6b118-c311-4363-8968-017ac169fc4c"),
				Name = "GetResultParameterAllValues",
				CreatedInSchemaUId = new Guid("4a4279e7-7ad3-4bc4-a92b-e762eeee9c8e"),
				CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8"),
				ResultValueTypeName = "Dictionary<Guid, string>",
				IsOverride = true,
				IsCustom = true
			};
			method.Arguments.Add(new SchemaMethodArgument() {
				UId = new Guid("cf79ac7e-de8c-4109-bc53-1bf2a3d2a2b4"),
				Name = "userConnection",
				CreatedInSchemaUId = new Guid("4a4279e7-7ad3-4bc4-a92b-e762eeee9c8e"),
				ModifiedInSchemaUId = new Guid("4a4279e7-7ad3-4bc4-a92b-e762eeee9c8e"),
				Direction = Terrasoft.Common.ParameterDirection.Input,
				ValueTypeName = "UserConnection",
				CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8")
			});
			method.Arguments.Add(new SchemaMethodArgument() {
				UId = new Guid("728cb53d-f460-4649-81f3-02c2b27d17c2"),
				Name = "schemaUserTask",
				CreatedInSchemaUId = new Guid("4a4279e7-7ad3-4bc4-a92b-e762eeee9c8e"),
				ModifiedInSchemaUId = new Guid("4a4279e7-7ad3-4bc4-a92b-e762eeee9c8e"),
				Direction = Terrasoft.Common.ParameterDirection.Input,
				ValueTypeName = "ProcessSchemaUserTask",
				CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8")
			});
			method.ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,43,74,45,41,45,202,83,200,75,45,87,112,201,76,46,201,204,207,75,44,170,180,113,47,205,76,209,81,40,46,41,202,204,75,183,211,208,180,6,0,179,24,102,192,38,0,0,0 };
			return method;
		}

		protected virtual SchemaMethod CreateCompleteExecutingMethod() {
			SchemaMethod method = new SchemaMethod() {
				UId = new Guid("9b34bb17-61df-4244-99bc-625b7132fb95"),
				Name = "CompleteExecuting",
				CreatedInSchemaUId = new Guid("4a4279e7-7ad3-4bc4-a92b-e762eeee9c8e"),
				CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8"),
				ResultValueTypeName = "bool",
				IsOverride = true,
				IsCustom = true
			};
			method.Arguments.Add(new SchemaMethodArgument() {
				UId = new Guid("be1b93c8-9ada-4ab9-80bb-d24268fc6577"),
				Name = "parameters",
				CreatedInSchemaUId = new Guid("4a4279e7-7ad3-4bc4-a92b-e762eeee9c8e"),
				ModifiedInSchemaUId = new Guid("4a4279e7-7ad3-4bc4-a92b-e762eeee9c8e"),
				Direction = Terrasoft.Common.ParameterDirection.Input,
				ValueTypeName = "object[]",
				CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8"),
				IsParams = true
			});
			method.ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,109,142,77,14,130,48,16,133,215,114,138,89,98,66,224,0,198,21,65,227,10,19,245,0,181,188,72,99,157,146,118,80,140,225,238,22,216,178,154,73,222,247,126,222,202,83,7,31,76,16,176,28,140,197,233,213,57,47,240,180,167,35,228,188,170,165,183,0,95,58,102,104,49,142,183,187,68,252,151,126,201,102,61,42,95,158,116,57,23,132,16,77,167,38,163,250,195,147,202,145,97,101,99,160,96,144,188,84,172,97,173,154,162,175,238,137,41,127,36,173,68,183,148,214,177,98,86,22,10,77,53,104,116,243,138,105,64,81,208,181,5,153,185,137,62,42,68,223,194,101,212,56,98,39,173,225,71,158,140,137,135,244,158,233,174,2,242,210,189,58,11,65,53,64,247,18,129,148,123,107,99,237,31,61,192,65,64,31,1,0,0 };
			return method;
		}

		protected virtual SchemaMethod CreateCancelExecutingMethod() {
			SchemaMethod method = new SchemaMethod() {
				UId = new Guid("ca2cfe05-4ce9-42cd-a860-c42ef5c4c224"),
				Name = "CancelExecuting",
				CreatedInSchemaUId = new Guid("4a4279e7-7ad3-4bc4-a92b-e762eeee9c8e"),
				CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8"),
				ResultValueTypeName = "void",
				IsOverride = true,
				IsCustom = true
			};
			method.Arguments.Add(new SchemaMethodArgument() {
				UId = new Guid("b844354b-cf97-4036-ae47-417175cff551"),
				Name = "parameters",
				CreatedInSchemaUId = new Guid("4a4279e7-7ad3-4bc4-a92b-e762eeee9c8e"),
				ModifiedInSchemaUId = new Guid("4a4279e7-7ad3-4bc4-a92b-e762eeee9c8e"),
				Direction = Terrasoft.Common.ParameterDirection.Input,
				ValueTypeName = "object[]",
				CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8"),
				IsParams = true
			});
			method.ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,43,75,44,82,200,204,45,200,47,42,9,72,44,74,204,77,45,73,45,42,14,74,45,200,47,206,44,201,47,170,84,176,85,112,79,45,241,196,41,175,17,90,156,90,228,156,159,151,151,154,92,146,153,159,167,105,205,133,219,44,61,231,196,188,228,212,28,136,97,193,169,197,197,64,13,26,40,60,207,20,160,1,73,137,197,169,80,165,174,21,169,201,165,37,153,121,233,26,5,112,243,52,173,1,111,230,58,25,178,0,0,0 };
			return method;
		}

		protected virtual SchemaMethod CreateGetExecutionDataMethod() {
			SchemaMethod method = new SchemaMethod() {
				UId = new Guid("edf02952-d873-4c49-9436-ca8a8843ff68"),
				Name = "GetExecutionData",
				CreatedInSchemaUId = new Guid("4a4279e7-7ad3-4bc4-a92b-e762eeee9c8e"),
				CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8"),
				ResultValueTypeName = "string",
				IsOverride = true,
				IsCustom = true
			};
			method.ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,43,74,45,41,45,202,83,40,46,41,202,204,75,215,115,205,45,40,169,180,6,0,142,207,47,4,20,0,0,0 };
			return method;
		}

		protected virtual SchemaMethod CreateSynchronizeDynamicParametersMethod() {
			SchemaMethod method = new SchemaMethod() {
				UId = new Guid("ae0c320c-3be1-4bd1-86b1-49ddb1985f3e"),
				Name = "SynchronizeDynamicParameters",
				CreatedInSchemaUId = new Guid("4a4279e7-7ad3-4bc4-a92b-e762eeee9c8e"),
				CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8"),
				ResultValueTypeName = "void",
				IsOverride = true,
				IsCustom = true
			};
			method.Arguments.Add(new SchemaMethodArgument() {
				UId = new Guid("9a1cb492-175b-4793-bb82-59e865268018"),
				Name = "userConnection",
				CreatedInSchemaUId = new Guid("4a4279e7-7ad3-4bc4-a92b-e762eeee9c8e"),
				ModifiedInSchemaUId = Guid.Empty,
				Direction = Terrasoft.Common.ParameterDirection.Input,
				ValueTypeName = "UserConnection",
				CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8")
			});
			method.Arguments.Add(new SchemaMethodArgument() {
				UId = new Guid("6b75ba89-6937-48e4-98c8-ae356e116525"),
				Name = "target",
				CreatedInSchemaUId = new Guid("4a4279e7-7ad3-4bc4-a92b-e762eeee9c8e"),
				ModifiedInSchemaUId = Guid.Empty,
				Direction = Terrasoft.Common.ParameterDirection.Input,
				ValueTypeName = "ProcessUserTaskSchema",
				CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8")
			});
			method.ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,75,74,44,78,213,11,174,204,75,206,40,202,207,203,172,74,117,169,204,75,204,205,76,14,72,44,74,204,77,45,73,45,42,214,40,45,78,45,114,206,207,203,75,77,46,201,204,207,211,81,40,73,44,74,79,45,209,180,6,0,220,224,0,174,58,0,0,0 };
			return method;
		}

		protected virtual SchemaMethod CreateSynchronizeParametersMethod() {
			SchemaMethod method = new SchemaMethod() {
				UId = new Guid("d11a52ab-3abb-4de1-9b2a-3fa73593b8c5"),
				Name = "SynchronizeParameters",
				CreatedInSchemaUId = new Guid("4a4279e7-7ad3-4bc4-a92b-e762eeee9c8e"),
				CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8"),
				ResultValueTypeName = "void",
				IsOverride = true,
				IsCustom = true
			};
			method.Arguments.Add(new SchemaMethodArgument() {
				UId = new Guid("f078cf00-8efb-4511-bfa6-057e8f542379"),
				Name = "schemaElement",
				CreatedInSchemaUId = new Guid("4a4279e7-7ad3-4bc4-a92b-e762eeee9c8e"),
				ModifiedInSchemaUId = Guid.Empty,
				Direction = Terrasoft.Common.ParameterDirection.Input,
				ValueTypeName = "ProcessSchemaUserTask",
				CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8")
			});
			method.ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,75,74,44,78,213,11,174,204,75,206,40,202,207,203,172,74,13,72,44,74,204,77,45,73,45,42,214,40,78,206,72,205,77,116,205,73,205,77,205,43,209,180,6,0,231,209,250,48,42,0,0,0 };
			return method;
		}

		protected virtual SchemaMethod CreateGetNotificationDataMethod() {
			SchemaMethod method = new SchemaMethod() {
				UId = new Guid("11ad09be-c56b-4526-9154-71cd7cb29886"),
				Name = "GetNotificationData",
				CreatedInSchemaUId = new Guid("4a4279e7-7ad3-4bc4-a92b-e762eeee9c8e"),
				CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8"),
				ResultValueTypeName = "ProcessElementNotification",
				IsOverride = true,
				IsCustom = true
			};
			method.ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,43,74,45,41,45,202,83,72,74,44,78,213,115,79,45,241,203,47,201,76,203,76,78,44,201,204,207,115,73,44,73,212,208,180,6,0,189,127,96,121,34,0,0,0 };
			return method;
		}

		protected virtual SchemaMethod CreateGetPersistentFileImporterMethod() {
			SchemaMethod method = new SchemaMethod() {
				UId = new Guid("a331f074-6ab9-436e-a542-f13ab2a082d9"),
				Name = "GetPersistentFileImporter",
				CreatedInSchemaUId = new Guid("4a4279e7-7ad3-4bc4-a92b-e762eeee9c8e"),
				CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8"),
				ResultValueTypeName = "IPersistentFileImporter"
			};
			method.Arguments.Add(new SchemaMethodArgument() {
				UId = new Guid("cef9a9ce-f613-477f-a1fa-655ffa0bac5e"),
				Name = "userConnection",
				CreatedInSchemaUId = Guid.Empty,
				ModifiedInSchemaUId = Guid.Empty,
				Direction = Terrasoft.Common.ParameterDirection.Input,
				ValueTypeName = "UserConnection",
				CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8")
			});
			method.ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,43,75,44,82,72,203,204,73,245,204,45,200,47,42,73,45,82,176,85,112,206,73,44,46,118,75,76,46,201,47,170,212,115,79,45,177,9,72,45,42,206,44,46,73,205,43,113,67,82,105,167,145,151,90,174,224,156,159,87,92,82,84,10,82,236,88,148,94,154,11,84,164,161,84,90,156,90,4,148,200,75,77,46,201,204,207,83,210,81,8,69,17,208,212,180,230,42,74,45,41,45,202,67,177,218,26,0,12,168,190,185,140,0,0,0 };
			return method;
		}

		protected virtual SchemaMethod CreateGetImportParametersRepositoryMethod() {
			SchemaMethod method = new SchemaMethod() {
				UId = new Guid("ac79416b-b893-4cea-a5bd-64a4d0cd6246"),
				Name = "GetImportParametersRepository",
				CreatedInSchemaUId = new Guid("4a4279e7-7ad3-4bc4-a92b-e762eeee9c8e"),
				CreatedInPackageId = new Guid("28117f91-27b8-43f6-8b95-0e32534298ab"),
				ResultValueTypeName = "IImportParametersRepository"
			};
			method.Arguments.Add(new SchemaMethodArgument() {
				UId = new Guid("825766c2-7e41-4c95-8672-e04ce680d91a"),
				Name = "userConnection",
				CreatedInSchemaUId = Guid.Empty,
				ModifiedInSchemaUId = Guid.Empty,
				Direction = Terrasoft.Common.ParameterDirection.Input,
				ValueTypeName = "UserConnection",
				CreatedInPackageId = new Guid("28117f91-27b8-43f6-8b95-0e32534298ab")
			});
			method.ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,85,203,49,10,132,64,16,68,209,171,12,70,10,226,5,148,133,69,80,204,196,27,12,82,44,130,211,45,213,61,136,183,87,195,77,255,227,19,158,41,161,223,163,217,16,87,87,94,205,8,239,166,41,29,74,159,35,99,130,131,182,224,80,219,94,255,148,130,51,244,42,230,204,239,241,229,47,39,136,151,69,54,240,1,193,234,155,74,81,135,255,80,85,237,13,222,118,17,211,112,0,0,0 };
			return method;
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new FileImportPersistentTaskSchema(this);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("4a4279e7-7ad3-4bc4-a92b-e762eeee9c8e"));
		}

		public override void InitializePrimaryInfo() {
			InitializeProperties();
			base.InitializePrimaryInfo();
			InitializeLocalizableValues();
		}

		public override ProcessUserTask CreateProcessUserTask(UserConnection userConnection) {
			return new FileImportPersistentTask(userConnection) {
				SchemaUId = new Guid("4a4279e7-7ad3-4bc4-a92b-e762eeee9c8e")
			};
		}

		#endregion

	}

	#endregion

	#region Class: FileImportPersistentTask

	[DesignModeProperty(Name = "ImportSessionId", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "4a4279e77ad34bc4a92be762eeee9c8e", CaptionResourceItem = "Parameters.ImportSessionId.Caption", DescriptionResourceItem = "Parameters.ImportSessionId.Caption", UseSolutionStorage = true)]
	/// <exclude/>
	public class FileImportPersistentTask : ProcessUserTask
	{

		#region Constructors: Public

		public FileImportPersistentTask(UserConnection userConnection)
			: base(userConnection) {
			SchemaUId = new Guid("4a4279e7-7ad3-4bc4-a92b-e762eeee9c8e");
		}

		#endregion

		#region Properties: Public

		public virtual Guid ImportSessionId {
			get;
			set;
		}

		#endregion

		#region Methods: Protected

		protected override bool InternalExecute(ProcessExecutingContext context) {
			var importParametersRepository = GetImportParametersRepository(UserConnection);
			importParametersRepository.UpdateImportProcessId(ImportSessionId, Guid.Parse(OwnerUId));
			UserConnection.ProcessEngine.CompleteExecuting(UId);
			return false;
		}

		#endregion

		#region Methods: Public

		public override bool CompleteExecuting(params object[] parameters) {
			var persistentFileImporter = GetPersistentFileImporter(UserConnection);
			try {
				persistentFileImporter.Import(ImportSessionId, Owner.InternalContext.CancellationToken);
			} catch (OperationCanceledException) {
				// The import was canceled, do nothing.
			}
			return base.CompleteExecuting(null);
		}

		public override void CancelExecuting(params object[] parameters) {
			var importParametersRepository = GetImportParametersRepository(UserConnection);
			importParametersRepository.CancelImportSession(ImportSessionId);
			base.CancelExecuting(parameters);
		}

		public override string GetExecutionData() {
			return string.Empty;
		}

		public override ProcessElementNotification GetNotificationData() {
			return base.GetNotificationData();
		}

		public virtual IPersistentFileImporter GetPersistentFileImporter(UserConnection userConnection) {
			var fileImporter = ClassFactory.Get<PersistentFileImporter>(new ConstructorArgument("userConnection", UserConnection));
			return fileImporter;
		}

		public virtual IImportParametersRepository GetImportParametersRepository(UserConnection userConnection) {
			return ClassFactory.Get<IImportParametersRepository>(new ConstructorArgument("userConnection", userConnection));
		}

		public override void WritePropertiesData(DataWriter writer) {
			writer.WriteStartObject(Name);
			base.WritePropertiesData(writer);
			if (Status == Core.Process.ProcessStatus.Inactive) {
				writer.WriteFinishObject();
				return;
			}
			if (!HasMapping("ImportSessionId")) {
				writer.WriteValue("ImportSessionId", ImportSessionId, Guid.Empty);
			}
			writer.WriteFinishObject();
		}

		#endregion

		#region Methods: Protected

		protected override void ApplyPropertiesDataValues(DataReader reader) {
			base.ApplyPropertiesDataValues(reader);
			switch (reader.CurrentName) {
				case "ImportSessionId":
					ImportSessionId = reader.GetGuidValue();
				break;
			}
		}

		#endregion

	}

	#endregion

}

