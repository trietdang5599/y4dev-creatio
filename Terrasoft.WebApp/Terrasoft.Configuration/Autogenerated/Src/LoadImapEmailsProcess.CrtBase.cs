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
	using Terrasoft.Mail;

	#region Class: LoadImapEmailsProcessSchema

	/// <exclude/>
	public class LoadImapEmailsProcessSchema : Terrasoft.Core.Process.ProcessSchema
	{

		#region Constructors: Public

		public LoadImapEmailsProcessSchema(ProcessSchemaManager processSchemaManager)
			: base(processSchemaManager) {
		}

		public LoadImapEmailsProcessSchema(LoadImapEmailsProcessSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			Name = "LoadImapEmailsProcess";
			UId = new Guid("2f9740b2-eaba-4296-af86-64b5692d7435");
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
			ZipCompiledMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,221,89,91,111,219,54,20,126,118,129,254,7,85,79,82,97,171,78,226,220,144,11,16,59,118,235,173,109,210,58,89,158,105,137,78,132,201,146,75,82,73,188,33,255,125,231,144,148,117,163,28,117,24,54,96,45,80,75,226,225,119,14,207,229,227,33,251,246,205,42,157,71,161,111,61,134,76,164,36,178,166,227,56,93,82,70,230,17,61,253,152,134,193,185,245,145,138,81,202,24,141,197,45,167,236,11,9,163,121,242,60,91,199,254,3,75,226,240,15,34,194,36,158,81,33,194,248,158,223,78,3,238,184,214,159,111,223,116,30,9,179,150,91,133,199,177,8,197,122,230,63,208,37,177,206,44,68,31,37,113,76,125,20,242,138,163,95,72,76,238,41,243,192,148,105,204,5,137,125,58,92,127,37,75,234,216,5,123,50,92,219,61,209,250,105,1,227,91,74,217,26,212,196,244,201,26,87,191,59,175,43,239,90,237,117,141,146,40,93,198,160,172,102,128,119,17,4,106,212,105,239,28,92,247,53,11,151,132,173,213,92,185,116,87,170,174,107,152,132,145,160,140,163,38,7,4,12,18,35,70,137,160,74,238,46,20,15,215,132,1,32,78,114,212,199,81,178,92,17,22,242,36,190,89,175,168,55,254,1,153,209,181,16,172,99,207,214,252,34,88,134,241,109,28,10,187,91,141,90,33,83,188,105,240,31,153,136,113,154,81,246,8,54,224,32,88,137,65,199,108,118,236,163,193,96,210,63,218,59,236,141,47,46,250,189,193,100,208,239,13,143,15,246,123,135,59,147,253,203,225,241,248,98,124,48,182,93,119,19,214,31,104,206,119,202,211,72,112,99,64,33,54,42,86,16,154,72,121,161,146,77,18,139,81,145,178,216,90,176,100,105,49,9,103,133,113,25,157,83,156,175,71,17,23,141,215,217,242,27,137,82,93,144,78,61,211,60,76,8,84,243,242,246,13,254,173,212,52,250,3,28,26,224,68,18,113,172,232,220,69,133,1,7,241,101,209,170,33,168,230,188,150,181,209,170,128,42,136,142,92,98,184,176,156,210,100,235,221,153,244,186,55,94,174,196,90,65,213,106,69,151,87,157,0,192,202,146,132,99,27,170,210,118,45,194,45,195,192,73,166,43,183,168,194,55,6,35,154,8,70,205,87,181,190,5,180,86,163,160,197,44,217,80,209,63,131,223,140,173,198,57,234,208,139,104,105,110,174,223,87,101,156,175,93,199,253,134,50,70,120,178,16,160,36,94,132,247,41,147,164,229,229,130,166,220,87,144,27,53,252,38,153,80,225,63,104,204,207,33,23,167,92,48,96,189,115,149,34,29,27,136,1,242,141,219,93,245,122,157,48,145,61,3,254,108,246,57,123,155,242,153,32,76,220,68,220,198,15,47,21,117,38,85,227,90,249,156,107,207,47,18,96,29,16,118,202,246,98,161,214,173,215,233,220,41,43,146,148,214,58,46,57,170,34,156,206,11,254,131,117,84,11,128,39,225,39,64,31,151,195,54,241,236,150,235,184,91,113,136,155,153,175,217,230,83,194,177,182,235,106,117,36,78,138,194,24,14,163,48,14,148,36,49,88,60,50,202,170,56,150,164,179,80,26,229,243,72,111,60,245,146,243,170,66,104,100,192,95,233,90,50,232,53,9,217,169,97,27,239,86,25,237,188,76,146,50,169,77,68,185,181,21,170,146,231,246,222,169,64,173,21,235,76,53,85,70,45,216,214,130,160,183,26,109,36,109,156,217,102,13,181,44,221,238,159,114,18,86,183,169,179,230,141,170,149,45,249,84,80,117,210,172,8,83,145,105,186,110,5,156,201,191,134,121,77,56,127,74,88,240,51,184,217,156,109,216,51,26,7,80,250,232,95,93,158,109,53,212,103,150,138,169,182,207,255,141,186,65,188,86,241,233,154,243,183,216,45,85,171,250,195,251,74,93,63,38,80,135,215,140,66,43,72,183,107,187,134,253,253,106,69,99,120,118,240,23,223,209,223,55,132,255,110,37,149,15,109,79,48,114,206,52,208,206,82,13,230,194,167,71,71,7,3,218,59,156,247,119,122,131,221,99,218,59,222,221,161,189,254,254,193,158,127,184,187,31,192,111,126,106,216,142,255,145,133,129,73,135,127,228,211,157,61,210,239,237,29,237,29,244,6,115,114,216,155,239,29,29,195,211,49,221,237,239,12,250,59,123,190,210,81,93,153,135,47,121,51,173,81,47,67,73,44,176,121,232,141,184,107,233,13,217,217,88,186,202,38,226,164,215,96,161,39,107,198,204,168,8,3,54,76,158,39,73,20,96,137,90,103,37,226,145,204,96,212,163,188,209,218,115,50,195,115,235,229,14,109,167,28,85,190,118,126,241,110,146,153,180,89,31,182,94,44,26,113,42,147,195,250,251,182,109,179,139,81,31,138,95,90,166,201,15,112,166,65,213,87,110,205,50,83,172,49,207,65,90,55,180,210,178,236,69,235,175,77,129,7,237,130,11,112,200,35,197,65,152,38,88,138,108,247,242,254,67,67,33,230,141,225,237,212,187,163,115,112,169,96,9,112,213,230,225,11,144,141,92,108,76,35,189,54,169,186,248,189,124,117,16,107,229,112,226,20,116,137,168,222,39,33,86,136,72,159,69,22,42,239,19,137,131,8,58,84,200,185,70,43,16,105,83,114,5,133,90,0,148,108,157,10,7,214,56,208,95,134,235,81,20,130,222,169,236,243,164,141,93,203,30,18,94,90,9,196,15,125,230,154,148,98,130,24,108,216,102,191,209,139,5,162,92,150,63,111,226,100,162,203,217,67,242,52,14,66,145,165,163,134,212,190,255,240,193,96,110,99,184,78,170,51,64,88,85,185,55,73,216,146,8,231,43,165,193,140,54,108,5,26,172,107,189,206,221,183,197,106,180,135,182,171,117,23,45,197,18,202,86,211,70,111,25,243,171,237,118,161,62,22,210,110,16,26,145,21,254,116,179,165,73,133,142,83,224,53,100,171,13,171,185,26,148,187,178,146,43,5,219,181,218,24,84,169,106,115,47,43,131,120,153,60,197,81,66,2,185,149,115,108,184,180,194,82,107,90,108,65,121,181,137,170,246,87,213,30,55,199,240,100,15,144,209,246,187,250,57,125,202,39,148,64,34,210,113,140,23,135,192,99,87,145,50,109,10,181,122,175,14,137,182,91,184,1,224,178,137,224,28,190,131,29,163,8,186,158,9,241,69,162,46,84,78,167,179,124,252,28,14,254,8,165,175,113,64,51,120,60,69,217,11,118,159,46,193,92,160,115,191,70,229,174,58,33,54,78,225,181,86,8,32,106,78,50,116,76,250,168,86,88,129,58,184,232,67,164,170,200,140,147,5,91,171,69,167,28,194,170,78,150,112,74,91,205,94,89,255,180,44,115,46,175,201,154,151,95,90,121,131,43,26,103,251,249,114,77,46,120,101,118,148,220,135,113,70,119,155,142,190,178,70,15,159,113,77,152,110,218,81,157,172,96,70,73,26,99,195,89,157,243,157,46,19,65,71,15,36,206,132,242,102,213,242,9,30,235,29,196,28,63,251,84,150,170,69,65,125,7,101,126,158,197,244,148,39,194,176,69,212,181,175,219,163,111,41,229,248,154,237,146,213,243,152,119,87,154,165,225,154,152,169,172,162,107,81,47,167,65,245,32,111,52,53,166,50,174,53,237,108,138,182,128,107,232,21,204,204,34,169,163,212,118,200,47,139,172,233,40,112,73,164,93,51,147,119,150,85,135,160,201,250,186,195,124,67,15,59,38,244,56,74,14,201,171,225,30,95,142,127,166,11,113,149,66,91,249,75,18,2,156,236,75,66,177,86,204,106,187,222,85,253,35,192,227,249,76,1,116,188,41,151,215,195,141,166,232,207,249,20,239,238,129,50,106,130,69,171,55,120,250,242,117,211,247,58,27,79,201,91,73,229,27,244,120,161,248,131,249,248,153,250,41,148,144,233,191,60,56,112,232,229,48,255,228,232,130,178,224,143,222,234,193,247,158,130,160,51,159,68,132,233,91,225,28,120,123,144,85,222,20,194,92,103,56,231,159,141,116,93,193,255,47,242,213,254,252,95,77,128,236,172,214,144,2,127,1,179,245,56,231,228,27,0,0 };
			RealUId = new Guid("2f9740b2-eaba-4296-af86-64b5692d7435");
			Version = 0;
			PackageUId = new Guid("06d9ef10-51d8-122c-8933-9212e84236c9");
			UseSystemSecurityContext = false;
		}

		protected virtual ProcessSchemaParameter CreatePageInstanceIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("4fe53caa-18f6-4c4b-b63b-d475fe7b8a0f"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("2f9740b2-eaba-4296-af86-64b5692d7435"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("2f9740b2-eaba-4296-af86-64b5692d7435"),
				Name = @"PageInstanceId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Text"),
			};
		}

		protected virtual ProcessSchemaParameter CreateActiveTreeGridCurrentRowIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("b9ae9fb7-09a7-4689-89fe-c1c439f10368"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("2f9740b2-eaba-4296-af86-64b5692d7435"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("2f9740b2-eaba-4296-af86-64b5692d7435"),
				Name = @"ActiveTreeGridCurrentRowId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid"),
			};
		}

		protected virtual ProcessSchemaParameter CreateCurrentUserMailboxSynchronizationSettingsUIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("ff591096-1b06-47b0-a988-cbd658b46fef"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("2f9740b2-eaba-4296-af86-64b5692d7435"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("2f9740b2-eaba-4296-af86-64b5692d7435"),
				Name = @"CurrentUserMailboxSynchronizationSettingsUId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid"),
			};
		}

		protected virtual ProcessSchemaParameter CreateMailboxSynchronizationSettingsPageUIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("be94aa4b-5b04-442f-88b6-6841d5c40218"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("2f9740b2-eaba-4296-af86-64b5692d7435"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("2f9740b2-eaba-4296-af86-64b5692d7435"),
				Name = @"MailboxSynchronizationSettingsPageUId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.ConstValue,
					Value = @"fce8864e-7b01-429e-921e-0563c725d563",
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("2f9740b2-eaba-4296-af86-64b5692d7435"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateNeedSetMailboxSynchronizationMessageUIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("9891be68-d59b-4533-9be3-85e194af599f"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("2f9740b2-eaba-4296-af86-64b5692d7435"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("2f9740b2-eaba-4296-af86-64b5692d7435"),
				Name = @"NeedSetMailboxSynchronizationMessageUId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.ConstValue,
					Value = @"{E9D59B5B-D6D0-47D6-9F8E-C475806C019C}",
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("2f9740b2-eaba-4296-af86-64b5692d7435"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateMailBoxFolderIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("3be2837e-0163-4330-836b-ffca8a2909be"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("2f9740b2-eaba-4296-af86-64b5692d7435"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("2f9740b2-eaba-4296-af86-64b5692d7435"),
				Name = @"MailBoxFolderId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid"),
			};
		}

		protected virtual ProcessSchemaParameter CreateLoadResultParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("532cb61b-8379-42bc-9a48-99fd98f7801b"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("2f9740b2-eaba-4296-af86-64b5692d7435"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("2f9740b2-eaba-4296-af86-64b5692d7435"),
				Name = @"LoadResult",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MaxSizeText"),
			};
		}

		protected virtual ProcessSchemaParameter CreateMessagesParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("574326c8-1b08-4af9-9e49-7da640ea2c9e"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("2f9740b2-eaba-4296-af86-64b5692d7435"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("2f9740b2-eaba-4296-af86-64b5692d7435"),
				Name = @"Messages",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Object"),
			};
		}

		protected virtual ProcessSchemaParameter CreateMessagesCountParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("562516d4-4d62-4421-b65f-3924fb92a101"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("2f9740b2-eaba-4296-af86-64b5692d7435"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("2f9740b2-eaba-4296-af86-64b5692d7435"),
				Name = @"MessagesCount",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Integer"),
			};
		}

		protected virtual ProcessSchemaParameter CreateSenderEmailAddressParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("9df9ed0b-1c24-40f3-94dc-f7cfa995d7db"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("2f9740b2-eaba-4296-af86-64b5692d7435"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("2f9740b2-eaba-4296-af86-64b5692d7435"),
				Name = @"SenderEmailAddress",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MediumText"),
			};
		}

		protected virtual ProcessSchemaParameter CreateNeedSetMailboxSynchronizationMessageParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("21444bbc-5fee-4669-9cb3-26a7af386911"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("2f9740b2-eaba-4296-af86-64b5692d7435"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("2f9740b2-eaba-4296-af86-64b5692d7435"),
				Name = @"NeedSetMailboxSynchronizationMessage",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LocalizableStringDataValueType"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.ConstValue,
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("2f9740b2-eaba-4296-af86-64b5692d7435"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateInformationCaptionParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("c7cc5b5d-0efd-428c-80d5-c6feea55dec6"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("2f9740b2-eaba-4296-af86-64b5692d7435"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("2f9740b2-eaba-4296-af86-64b5692d7435"),
				Name = @"InformationCaption",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LocalizableStringDataValueType"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.ConstValue,
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("2f9740b2-eaba-4296-af86-64b5692d7435"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateSuccessLoadEmailsMessageParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("e255669d-4628-4d24-b91e-f4e34a99cc0a"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("a99d7388-fb0e-4870-87fc-76975bec5847"),
				CreatedInSchemaUId = new Guid("2f9740b2-eaba-4296-af86-64b5692d7435"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("2f9740b2-eaba-4296-af86-64b5692d7435"),
				Name = @"SuccessLoadEmailsMessage",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LocalizableStringDataValueType"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.ConstValue,
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("2f9740b2-eaba-4296-af86-64b5692d7435"),
				},
			};
		}

		protected override void InitializeParameters() {
			base.InitializeParameters();
			Parameters.Add(CreatePageInstanceIdParameter());
			Parameters.Add(CreateActiveTreeGridCurrentRowIdParameter());
			Parameters.Add(CreateCurrentUserMailboxSynchronizationSettingsUIdParameter());
			Parameters.Add(CreateMailboxSynchronizationSettingsPageUIdParameter());
			Parameters.Add(CreateNeedSetMailboxSynchronizationMessageUIdParameter());
			Parameters.Add(CreateMailBoxFolderIdParameter());
			Parameters.Add(CreateLoadResultParameter());
			Parameters.Add(CreateMessagesParameter());
			Parameters.Add(CreateMessagesCountParameter());
			Parameters.Add(CreateSenderEmailAddressParameter());
			Parameters.Add(CreateNeedSetMailboxSynchronizationMessageParameter());
			Parameters.Add(CreateInformationCaptionParameter());
			Parameters.Add(CreateSuccessLoadEmailsMessageParameter());
		}

		protected override void InitializeBaseElements() {
			base.InitializeBaseElements();
			ProcessSchemaLaneSet schemaLoadImapEmailsUserTaskLaneSet = CreateLoadImapEmailsUserTaskLaneSetLaneSet();
			LaneSets.Add(schemaLoadImapEmailsUserTaskLaneSet);
			ProcessSchemaLane schemaLoadImapEmailsUserTaskLane = CreateLoadImapEmailsUserTaskLaneLane();
			schemaLoadImapEmailsUserTaskLaneSet.Lanes.Add(schemaLoadImapEmailsUserTaskLane);
			ProcessSchemaStartEvent loadimapemailsusertaskstart = CreateLoadImapEmailsUserTaskStartStartEvent();
			FlowElements.Add(loadimapemailsusertaskstart);
			ProcessSchemaEndEvent loadimapemailsusertaskend = CreateLoadImapEmailsUserTaskEndEndEvent();
			FlowElements.Add(loadimapemailsusertaskend);
			ProcessSchemaScriptTask scripttask1 = CreateScriptTask1ScriptTask();
			FlowElements.Add(scripttask1);
			FlowElements.Add(CreateSequenceFlow2SequenceFlow());
			FlowElements.Add(CreateSequenceFlow1SequenceFlow());
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow2SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow2",
				UId = new Guid("336acfd9-6be3-4f8e-9ee0-842af3c10118"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("2f9740b2-eaba-4296-af86-64b5692d7435"),
				CurveCenterPosition = new Point(374, 210),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("2f9740b2-eaba-4296-af86-64b5692d7435"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("fb4cf670-1ecc-4fbe-ad34-44ab952d9f62"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("9ddd22ce-1f21-454f-8dff-aa6510f4434e"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow1SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow1",
				UId = new Guid("4fcbcae3-6713-47fc-ade0-561c841d572b"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("2f9740b2-eaba-4296-af86-64b5692d7435"),
				CurveCenterPosition = new Point(440, 212),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("2f9740b2-eaba-4296-af86-64b5692d7435"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("9ddd22ce-1f21-454f-8dff-aa6510f4434e"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("279c7f52-7577-4bf9-a283-8d6621415e69"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaLaneSet CreateLoadImapEmailsUserTaskLaneSetLaneSet() {
			ProcessSchemaLaneSet schemaLoadImapEmailsUserTaskLaneSet = new ProcessSchemaLaneSet(this) {
				UId = new Guid("21cd00c5-c917-4b96-a25b-d555ef360329"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 1,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("2f9740b2-eaba-4296-af86-64b5692d7435"),
				Direction = ProcessSchemaPoolDirectionType.Vertical,
				DragGroupName = @"LaneSet",
				ManagerItemUId = new Guid("11a47caf-a0d5-41fa-a274-a0b11f77447a"),
				ModifiedInSchemaUId = new Guid("2f9740b2-eaba-4296-af86-64b5692d7435"),
				Name = @"LoadImapEmailsUserTaskLaneSet",
				Position = new Point(5, 5),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLoadImapEmailsUserTaskLaneSet;
		}

		protected virtual ProcessSchemaLane CreateLoadImapEmailsUserTaskLaneLane() {
			ProcessSchemaLane schemaLoadImapEmailsUserTaskLane = new ProcessSchemaLane(this) {
				UId = new Guid("a105506e-8d97-4c59-8fb8-a2e5b037ce28"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 1,
				ContainerUId = new Guid("21cd00c5-c917-4b96-a25b-d555ef360329"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("2f9740b2-eaba-4296-af86-64b5692d7435"),
				DragGroupName = @"Lane",
				ManagerItemUId = new Guid("abcd74b9-5912-414b-82ac-f1aa4dcd554e"),
				ModifiedInSchemaUId = new Guid("2f9740b2-eaba-4296-af86-64b5692d7435"),
				Name = @"LoadImapEmailsUserTaskLane",
				Position = new Point(29, 0),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLoadImapEmailsUserTaskLane;
		}

		protected virtual ProcessSchemaStartEvent CreateLoadImapEmailsUserTaskStartStartEvent() {
			ProcessSchemaStartEvent schemaStartEvent = new ProcessSchemaStartEvent(this) {
				UId = new Guid("fb4cf670-1ecc-4fbe-ad34-44ab952d9f62"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = new Guid("a105506e-8d97-4c59-8fb8-a2e5b037ce28"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("2f9740b2-eaba-4296-af86-64b5692d7435"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsInterrupting = false,
				IsLogging = true,
				ManagerItemUId = new Guid("53818048-7868-48f6-ada0-0ebaa65af628"),
				ModifiedInSchemaUId = new Guid("2f9740b2-eaba-4296-af86-64b5692d7435"),
				Name = @"LoadImapEmailsUserTaskStart",
				Position = new Point(50, 191),
				SerializeToDB = false,
				Size = new Size(27, 27),
				UseBackgroundMode = false
			};
			
			return schemaStartEvent;
		}

		protected virtual ProcessSchemaEndEvent CreateLoadImapEmailsUserTaskEndEndEvent() {
			ProcessSchemaEndEvent schemaEndEvent = new ProcessSchemaEndEvent(this) {
				UId = new Guid("279c7f52-7577-4bf9-a283-8d6621415e69"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = new Guid("a105506e-8d97-4c59-8fb8-a2e5b037ce28"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("2f9740b2-eaba-4296-af86-64b5692d7435"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsLogging = true,
				ManagerItemUId = new Guid("45ceaae2-4e1f-4c0c-86aa-cd4aeb4da913"),
				ModifiedInSchemaUId = new Guid("2f9740b2-eaba-4296-af86-64b5692d7435"),
				Name = @"LoadImapEmailsUserTaskEnd",
				Position = new Point(547, 191),
				SerializeToDB = false,
				Size = new Size(27, 27),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaEndEvent;
		}

		protected virtual ProcessSchemaScriptTask CreateScriptTask1ScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("9ddd22ce-1f21-454f-8dff-aa6510f4434e"),
				BackgroundModePriority = BackgroundModePriority.Inherited,
				ContainerItemIndex = 0,
				ContainerUId = new Guid("a105506e-8d97-4c59-8fb8-a2e5b037ce28"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("2f9740b2-eaba-4296-af86-64b5692d7435"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("2f9740b2-eaba-4296-af86-64b5692d7435"),
				Name = @"ScriptTask1",
				Position = new Point(267, 177),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,133,147,81,79,219,48,20,133,159,139,196,127,184,228,1,37,162,137,18,141,78,176,173,147,70,147,162,10,10,18,21,123,89,247,224,53,151,214,82,98,79,182,67,233,170,252,119,236,216,77,186,138,141,183,216,185,247,220,239,156,220,76,81,74,178,68,9,67,96,184,134,148,46,20,229,140,136,205,151,235,138,230,125,144,74,80,182,252,234,7,159,143,143,158,137,0,193,185,202,74,66,139,49,47,114,20,147,220,53,154,106,223,75,46,146,241,101,250,225,60,28,164,89,22,102,113,146,132,223,46,62,94,133,113,156,12,6,105,124,62,138,147,212,51,82,244,9,252,169,86,185,226,47,157,208,176,81,137,178,242,183,218,4,176,61,62,234,205,86,124,157,229,84,205,80,41,141,33,167,150,182,161,233,9,84,149,96,160,68,133,250,88,91,209,55,248,134,112,48,201,106,27,55,52,55,198,175,81,141,42,33,144,169,71,137,194,20,255,226,47,179,13,91,172,4,103,244,15,49,137,236,8,30,39,185,180,227,205,52,221,31,141,120,197,148,31,152,57,177,85,254,63,182,6,237,61,113,129,100,177,242,45,3,80,102,72,92,115,202,215,172,224,36,111,92,200,177,224,165,195,215,211,172,0,104,183,128,133,196,214,71,105,153,155,175,161,221,76,119,199,195,140,91,240,174,225,100,63,117,56,61,133,191,94,177,170,40,222,229,106,59,28,94,139,246,110,16,181,93,170,178,91,66,187,111,150,70,23,237,7,229,170,76,90,254,191,246,52,112,19,92,152,173,240,89,171,60,230,162,36,202,247,182,219,185,71,243,185,247,9,230,222,54,174,231,94,95,63,184,122,119,155,232,219,186,238,235,55,238,62,186,193,77,119,248,78,138,10,131,110,245,78,220,132,137,188,211,169,221,139,198,131,191,67,8,14,136,134,173,235,232,1,75,254,140,109,101,116,139,108,169,86,16,66,226,212,111,117,236,15,40,171,66,193,27,62,52,234,206,181,1,255,161,221,252,132,186,238,176,165,145,217,255,91,94,1,75,100,250,205,245,3,0,0 }
			};
			
			return ScriptTask;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeUsings() {
			Usings.Add(new SchemaUsing() {
				UId = new Guid("276b5906-88fa-4d43-a6ea-8d6213245d72"),
				Name = "Terrasoft.Core.Entities",
				Alias = "",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("3e068d19-8d8c-4768-b6a9-83bd4995c9bc"),
				Name = "Terrasoft.Mail",
				Alias = "",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("b6da2fd2-6cc9-4667-ab57-4f614f3fc9ca"),
				Name = "Terrasoft.Configuration",
				Alias = "",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("ef7eb62b-f609-42c2-af07-585c5670410d"),
				Name = "System.Linq",
				Alias = "",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("a973b80b-c06f-4f64-b532-26268ad871c3"),
				Name = "Terrasoft.Core.Factories",
				Alias = "",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("997719b8-45ce-4814-939a-6ff72a85e213"),
				Name = "IntegrationApi.Interfaces",
				Alias = "",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			});
		}

		#endregion

		#region Methods: Public

		public override Process CreateProcess(UserConnection userConnection) {
			return new LoadImapEmailsProcess(userConnection);
		}

		public override object Clone() {
			return new LoadImapEmailsProcessSchema(this);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("2f9740b2-eaba-4296-af86-64b5692d7435"));
		}

		#endregion

	}

	#endregion

	#region Class: LoadImapEmailsProcess

	/// <exclude/>
	public class LoadImapEmailsProcess : Terrasoft.Core.Process.Process
	{

		#region Class: ProcessLoadImapEmailsUserTaskLane

		/// <exclude/>
		public class ProcessLoadImapEmailsUserTaskLane : ProcessLane
		{

			public ProcessLoadImapEmailsUserTaskLane(UserConnection userConnection, LoadImapEmailsProcess process)
				: base(userConnection) {
				Owner = process;
				IsUsedParentUserContexts = false;
			}

		}

		#endregion

		public LoadImapEmailsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "LoadImapEmailsProcess";
			SchemaUId = new Guid("2f9740b2-eaba-4296-af86-64b5692d7435");
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
				return new Guid("2f9740b2-eaba-4296-af86-64b5692d7435");
			}
		}

		private string ConditionalExpressionLogMessage {
			get {
				return "Process: LoadImapEmailsProcess, Source element: {0}, Conditional flow: {1}, Expression: {2}, Result: {3}";
			}
		}

		private string DeadEndGatewayLogMessage {
			get {
				return "Process: LoadImapEmailsProcess, Source element: {0}, None of the exclusive gateway conditions are met!";
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

		public virtual Guid CurrentUserMailboxSynchronizationSettingsUId {
			get;
			set;
		}

		private Guid _mailboxSynchronizationSettingsPageUId = new Guid("fce8864e-7b01-429e-921e-0563c725d563");
		public Guid MailboxSynchronizationSettingsPageUId {
			get {
				return _mailboxSynchronizationSettingsPageUId;
			}
			set {
				_mailboxSynchronizationSettingsPageUId = value;
			}
		}

		private Guid _needSetMailboxSynchronizationMessageUId = new Guid("{E9D59B5B-D6D0-47D6-9F8E-C475806C019C}");
		public Guid NeedSetMailboxSynchronizationMessageUId {
			get {
				return _needSetMailboxSynchronizationMessageUId;
			}
			set {
				_needSetMailboxSynchronizationMessageUId = value;
			}
		}

		public virtual Guid MailBoxFolderId {
			get;
			set;
		}

		public virtual string LoadResult {
			get;
			set;
		}

		public virtual Object Messages {
			get;
			set;
		}

		public virtual int MessagesCount {
			get;
			set;
		}

		public virtual string SenderEmailAddress {
			get;
			set;
		}

		private LocalizableString _needSetMailboxSynchronizationMessage;
		public virtual LocalizableString NeedSetMailboxSynchronizationMessage {
			get {
				return _needSetMailboxSynchronizationMessage ?? (_needSetMailboxSynchronizationMessage = GetLocalizableString("2f9740b2eaba4296af8664b5692d7435",
						 "Parameters.NeedSetMailboxSynchronizationMessage.Value"));
			}
			set {
				_needSetMailboxSynchronizationMessage = value;
			}
		}

		private LocalizableString _informationCaption;
		public virtual LocalizableString InformationCaption {
			get {
				return _informationCaption ?? (_informationCaption = GetLocalizableString("2f9740b2eaba4296af8664b5692d7435",
						 "Parameters.InformationCaption.Value"));
			}
			set {
				_informationCaption = value;
			}
		}

		private LocalizableString _successLoadEmailsMessage;
		public virtual LocalizableString SuccessLoadEmailsMessage {
			get {
				return _successLoadEmailsMessage ?? (_successLoadEmailsMessage = GetLocalizableString("2f9740b2eaba4296af8664b5692d7435",
						 "Parameters.SuccessLoadEmailsMessage.Value"));
			}
			set {
				_successLoadEmailsMessage = value;
			}
		}

		private ProcessLoadImapEmailsUserTaskLane _loadImapEmailsUserTaskLane;
		public ProcessLoadImapEmailsUserTaskLane LoadImapEmailsUserTaskLane {
			get {
				return _loadImapEmailsUserTaskLane ?? ((_loadImapEmailsUserTaskLane) = new ProcessLoadImapEmailsUserTaskLane(UserConnection, this));
			}
		}

		private ProcessFlowElement _loadImapEmailsUserTaskStart;
		public ProcessFlowElement LoadImapEmailsUserTaskStart {
			get {
				return _loadImapEmailsUserTaskStart ?? (_loadImapEmailsUserTaskStart = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartEvent",
					Name = "LoadImapEmailsUserTaskStart",
					SchemaElementUId = new Guid("fb4cf670-1ecc-4fbe-ad34-44ab952d9f62"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
				});
			}
		}

		private ProcessEndEvent _loadImapEmailsUserTaskEnd;
		public ProcessEndEvent LoadImapEmailsUserTaskEnd {
			get {
				return _loadImapEmailsUserTaskEnd ?? (_loadImapEmailsUserTaskEnd = new ProcessEndEvent() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEndEvent",
					Name = "LoadImapEmailsUserTaskEnd",
					SchemaElementUId = new Guid("279c7f52-7577-4bf9-a283-8d6621415e69"),
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
					SchemaElementUId = new Guid("9ddd22ce-1f21-454f-8dff-aa6510f4434e"),
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
			FlowElements[LoadImapEmailsUserTaskStart.SchemaElementUId] = new Collection<ProcessFlowElement> { LoadImapEmailsUserTaskStart };
			FlowElements[LoadImapEmailsUserTaskEnd.SchemaElementUId] = new Collection<ProcessFlowElement> { LoadImapEmailsUserTaskEnd };
			FlowElements[ScriptTask1.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptTask1 };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "LoadImapEmailsUserTaskStart":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ScriptTask1", e.Context.SenderName));
						break;
					case "LoadImapEmailsUserTaskEnd":
						CompleteProcess();
						break;
					case "ScriptTask1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("LoadImapEmailsUserTaskEnd", e.Context.SenderName));
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
			if (!HasMapping("CurrentUserMailboxSynchronizationSettingsUId")) {
				writer.WriteValue("CurrentUserMailboxSynchronizationSettingsUId", CurrentUserMailboxSynchronizationSettingsUId, Guid.Empty);
			}
			if (!HasMapping("MailboxSynchronizationSettingsPageUId")) {
				writer.WriteValue("MailboxSynchronizationSettingsPageUId", MailboxSynchronizationSettingsPageUId, Guid.Empty);
			}
			if (!HasMapping("NeedSetMailboxSynchronizationMessageUId")) {
				writer.WriteValue("NeedSetMailboxSynchronizationMessageUId", NeedSetMailboxSynchronizationMessageUId, Guid.Empty);
			}
			if (!HasMapping("MailBoxFolderId")) {
				writer.WriteValue("MailBoxFolderId", MailBoxFolderId, Guid.Empty);
			}
			if (!HasMapping("LoadResult")) {
				writer.WriteValue("LoadResult", LoadResult, null);
			}
			if (Messages != null) {
				if (Messages.GetType().IsSerializable ||
					Messages.GetType().GetInterface("ISerializable") != null) {
					WriteSerializableObject(writer, "Messages", Messages, null);
				}
			}
			if (!HasMapping("MessagesCount")) {
				writer.WriteValue("MessagesCount", MessagesCount, 0);
			}
			if (!HasMapping("SenderEmailAddress")) {
				writer.WriteValue("SenderEmailAddress", SenderEmailAddress, null);
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
			context.QueueTasksV2.Enqueue(new ProcessQueueElement("LoadImapEmailsUserTaskStart", string.Empty));
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
			MetaPathParameterValues.Add("4fe53caa-18f6-4c4b-b63b-d475fe7b8a0f", () => PageInstanceId);
			MetaPathParameterValues.Add("b9ae9fb7-09a7-4689-89fe-c1c439f10368", () => ActiveTreeGridCurrentRowId);
			MetaPathParameterValues.Add("ff591096-1b06-47b0-a988-cbd658b46fef", () => CurrentUserMailboxSynchronizationSettingsUId);
			MetaPathParameterValues.Add("be94aa4b-5b04-442f-88b6-6841d5c40218", () => MailboxSynchronizationSettingsPageUId);
			MetaPathParameterValues.Add("9891be68-d59b-4533-9be3-85e194af599f", () => NeedSetMailboxSynchronizationMessageUId);
			MetaPathParameterValues.Add("3be2837e-0163-4330-836b-ffca8a2909be", () => MailBoxFolderId);
			MetaPathParameterValues.Add("532cb61b-8379-42bc-9a48-99fd98f7801b", () => LoadResult);
			MetaPathParameterValues.Add("574326c8-1b08-4af9-9e49-7da640ea2c9e", () => Messages);
			MetaPathParameterValues.Add("562516d4-4d62-4421-b65f-3924fb92a101", () => MessagesCount);
			MetaPathParameterValues.Add("9df9ed0b-1c24-40f3-94dc-f7cfa995d7db", () => SenderEmailAddress);
			MetaPathParameterValues.Add("21444bbc-5fee-4669-9cb3-26a7af386911", () => NeedSetMailboxSynchronizationMessage);
			MetaPathParameterValues.Add("c7cc5b5d-0efd-428c-80d5-c6feea55dec6", () => InformationCaption);
			MetaPathParameterValues.Add("e255669d-4628-4d24-b91e-f4e34a99cc0a", () => SuccessLoadEmailsMessage);
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
				case "CurrentUserMailboxSynchronizationSettingsUId":
					if (!hasValueToRead) break;
					CurrentUserMailboxSynchronizationSettingsUId = reader.GetValue<System.Guid>();
				break;
				case "MailboxSynchronizationSettingsPageUId":
					if (!hasValueToRead) break;
					MailboxSynchronizationSettingsPageUId = reader.GetValue<System.Guid>();
				break;
				case "NeedSetMailboxSynchronizationMessageUId":
					if (!hasValueToRead) break;
					NeedSetMailboxSynchronizationMessageUId = reader.GetValue<System.Guid>();
				break;
				case "MailBoxFolderId":
					if (!hasValueToRead) break;
					MailBoxFolderId = reader.GetValue<System.Guid>();
				break;
				case "LoadResult":
					if (!hasValueToRead) break;
					LoadResult = reader.GetValue<System.String>();
				break;
				case "Messages":
					if (!hasValueToRead) break;
					Messages = GetSerializableObject(reader);
				break;
				case "MessagesCount":
					if (!hasValueToRead) break;
					MessagesCount = reader.GetValue<System.Int32>();
				break;
				case "SenderEmailAddress":
					if (!hasValueToRead) break;
					SenderEmailAddress = reader.GetValue<System.String>();
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
			Messages = new Dictionary<Guid, string>();
			var rootEmailFolderId = new Guid("181F9D34-5DEE-E011-A86B-00155D04C01D");
			if (MailBoxFolderId == Guid.Empty) {
				ShowEditSettingsMessage();
				return true;
			}
			if (rootEmailFolderId == MailBoxFolderId) {
				var ids = GetCurrentUserMailboxSynchronizationSettingsUIds();
				if (ids.Count() == 0) {
					ShowEditSettingsMessage();
				}
				foreach(var id in ids) {
					DownloadEmailsFromMailBox(id);
				} 
			} else {
				var mailboxId = GetMailboxId(MailBoxFolderId);
				if (mailboxId != Guid.Empty && mailboxId != null) {
					DownloadEmailsFromMailBox(mailboxId);
				} else {
					ShowEditSettingsMessage();
				}
			}
			var messages = string.Empty;
			foreach(var message in (Dictionary<Guid, string>)Messages) {
				messages += string.Format("{{\"id\": \"{0}\", \"message\": \"{1}\"}},", message.Key, message.Value);
			}
			if (!string.IsNullOrEmpty(messages)) {
				messages = messages.Remove(messages.Length - 1);
			}
			LoadResult = string.Format("{{ \"Messages\": [{0}] }}", messages);
			return true;
		}

			
			public virtual IEnumerable<Guid> GetCurrentUserMailboxSynchronizationSettingsUIds() {
				var mailboxSynchronizationSettingsEntitySchema = UserConnection.EntitySchemaManager.GetInstanceByName("MailboxSyncSettings");
				var entitySchemaQuery = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "MailboxSyncSettings");
				var entitySchemaColumn = entitySchemaQuery.AddColumn(mailboxSynchronizationSettingsEntitySchema.GetPrimaryColumnName());
				entitySchemaQuery.Filters.Add(
					entitySchemaQuery.CreateFilterWithParameters(FilterComparisonType.Equal, 
						"SysAdminUnit", UserConnection.CurrentUser.Id));
				entitySchemaQuery.Filters.Add(
					entitySchemaQuery.CreateFilterWithParameters(FilterComparisonType.Equal, 
						"MailServer.Type", new Guid("844F0837-EAA0-4F40-B965-71F5DB9EAE6E")));
				var queryResults = entitySchemaQuery.GetEntityCollection(UserConnection);
				return from result in queryResults select result.GetTypedColumnValue<Guid>(entitySchemaColumn.Name);
			}
			
			
			public virtual MailCredentials GetMailServerCredentials(Guid mailServerUId) {
				var result = new MailCredentials();
				if (mailServerUId != Guid.Empty) {
					var entitySchemaManager = UserConnection.GetSchemaManager("EntitySchemaManager") as EntitySchemaManager;
					var mailServerEntitySchema = entitySchemaManager.GetInstanceByName("MailServer");
					var mailServerEntitySchemaPrimaryColumnName = mailServerEntitySchema.GetPrimaryColumnName();
					var mailServerEntitySchemaPrimaryColumn = mailServerEntitySchema.Columns.GetByName(mailServerEntitySchemaPrimaryColumnName);
					var currentMailServer = new Terrasoft.Configuration.MailServer(UserConnection);
					var columnNamesToFetch = new List<string> {
						"Address",
						"Port",
						"UseSSL",
						"IsStartTls"
					};
					var columnsToFetch = new List<EntitySchemaColumn>();
					foreach (var columnName in columnNamesToFetch) {
						columnsToFetch.Add(mailServerEntitySchema.Columns.GetByName(columnName));
					}
					if (currentMailServer.FetchFromDB(mailServerEntitySchemaPrimaryColumn, mailServerUId, columnsToFetch)) {
						result.Host = currentMailServer.Address;
						result.Port = currentMailServer.Port;
						result.UseSsl = currentMailServer.UseSSL;
						result.StartTls = currentMailServer.IsStartTls;
					}
				}
				return result;
			}
			
			
			public virtual KeyValuePair<MailboxSyncSettings, MailCredentials> GetMailServerUserCredentials(Guid mailboxSynchronizationSettingsUId) {
				var resultMailboxSynchronizationSettings = new MailboxSyncSettings(UserConnection);
				var resultMailCredentials= new MailCredentials();
				if (mailboxSynchronizationSettingsUId != Guid.Empty) {
					if (resultMailboxSynchronizationSettings.FetchFromDB(mailboxSynchronizationSettingsUId)) {
						resultMailCredentials = GetMailServerCredentials(resultMailboxSynchronizationSettings.MailServerId);
						resultMailCredentials.UserName = resultMailboxSynchronizationSettings.UserName;
						resultMailCredentials.UserPassword = resultMailboxSynchronizationSettings.UserPassword;
						resultMailCredentials.SenderEmailAddress = resultMailboxSynchronizationSettings.SenderEmailAddress;
					}
				}
				var result = new KeyValuePair<MailboxSyncSettings, MailCredentials> 
					(resultMailboxSynchronizationSettings, resultMailCredentials);
				return result;
			}
			
			
			/*public virtual void PrepareMailboxSynchronizationSettingsPageOpening(OpenPageUserTask openPageUserTask) {
				var mailboxSynchronizationSettingsPageUId = new Guid("fce8864e-7b01-429e-921e-0563c725d563");
				var mailboxSynchronizationSettingsGridPageUId = new Guid("c8ce13a0-3836-4ba7-b389-4b9e2014013c");
				openPageUserTask.PageParameters = new Dictionary<string, string>();
				var pageParams = openPageUserTask.PageParameters as Dictionary<string, string>;
				if (MailBoxFolderId == Guid.Empty){
					openPageUserTask.PageUId = mailboxSynchronizationSettingsGridPageUId;
					pageParams.Add("userId", UserConnection.CurrentUser.Id.ToString());
				} else {
				 	openPageUserTask.PageUId = mailboxSynchronizationSettingsPageUId;
					pageParams.Add("recordId", GetMailboxId(MailBoxFolderId).ToString());
				}
				openPageUserTask.OpenerInstanceId = InstanceUId;
				openPageUserTask.UseCurrentActivePage = true;
			}*/
			
			
			/*public virtual Terrasoft.UI.WebControls.Controls.MessagePanel GetMainPageMessagePanel() {
				var mainPage = System.Web.HttpContext.Current.Handler as Terrasoft.UI.WebControls.Page;
				var messagePanelControl = Terrasoft.UI.WebControls.Page.FindControlByClientId(mainPage, "BaseMessagePanel", true);
				var messagePanel = messagePanelControl as Terrasoft.UI.WebControls.Controls.MessagePanel;
				return messagePanel;
			}*/
			
			
			public virtual void ShowEditSettingsMessage() {
				//var messagePanel = GetMainPageMessagePanel();
				//var message = string.Format(NeedSetMailboxSynchronizationMessage, MailboxSynchronizationSettingsPageUId.ToString("B"));
				//messagePanel.AddMessage(NeedSetMailboxSynchronizationMessageUId.ToString("N"), InformationCaption, message);
				((Dictionary<Guid, string>)Messages).Add(MailBoxFolderId, NeedSetMailboxSynchronizationMessage.ToString());
			}
			
			
			public virtual void DownloadEmailsFromMailBox(Guid mailboxId) {
				var serverCredentials = GetMailServerUserCredentials(mailboxId).Value;
				if (!UserConnection.GetIsFeatureEnabled("OldEmailIntegration")) {
					var syncSession = ClassFactory.Get<ISyncSession>("Email", new ConstructorArgument("uc", UserConnection),
						new ConstructorArgument("senderEmailAddress", serverCredentials.SenderEmailAddress));
					syncSession.Start();
					return;
				}
				try {
					using (var imapSyncSession = ClassFactory.Get<IImapSyncSession>(
					new ConstructorArgument("userConnection", UserConnection),
					new ConstructorArgument("credentials", serverCredentials),
					new ConstructorArgument("login", true))) {
						imapSyncSession.SyncImapMail();
						MessagesCount = imapSyncSession.RemoteChangesCount;
					}
				} catch (ImapException e) {	
					//var messagePanel = GetMainPageMessagePanel();
					//var warningCaption = new QuestionUserTask(UserConnection).WarningCaption;
					//messagePanel.AddMessage(warningCaption, e.Message, MessageType.Warning);
					((Dictionary<Guid, string>)Messages).Add(mailboxId, e.Message.ToString());
				}
			}
			
			
			public virtual Guid GetMailboxId(Guid folderId) {
				var sel = new Select(UserConnection)
					.Column("MailboxSyncSettings", "Id")
					.From("MailboxSyncSettings")
					.LeftOuterJoin("ActivityFolder").On("ActivityFolder", "Name")
						.IsEqual("MailboxSyncSettings", "MailboxName")
					.Where("ActivityFolder", "Id").IsEqual(Column.Parameter(folderId)) as Select;
				using (var dbExecutor = UserConnection.EnsureDBConnection()) {
				    return sel.ExecuteScalar<Guid>(dbExecutor);
				}
			}
			
			
			public virtual string GetMailboxSenderEmailAddress() {
				var sel = new Select(UserConnection)
					.Column("MailboxSyncSettings", "SenderEmailAddress")
					.From("MailboxSyncSettings")
					.LeftOuterJoin("ActivityFolder").On("ActivityFolder", "Name")
						.IsEqual("MailboxSyncSettings", "MailboxName")
					.Where("ActivityFolder", "Id").IsEqual(Column.Parameter(MailBoxFolderId)) as Select;
				using (var dbExecutor = UserConnection.EnsureDBConnection()) {
				    return sel.ExecuteScalar<string>(dbExecutor);
				}
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
			var cloneItem = (LoadImapEmailsProcess)base.CloneShallow();
			cloneItem.ExecutedEventHandler = ExecutedEventHandler;
			cloneItem.Messages = Messages;
			return cloneItem;
		}

		#endregion

	}

	#endregion

}

