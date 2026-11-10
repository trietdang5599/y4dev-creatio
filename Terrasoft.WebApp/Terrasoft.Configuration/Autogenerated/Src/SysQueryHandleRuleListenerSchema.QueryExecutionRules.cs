namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: SysQueryHandleRuleListenerSchema

	/// <exclude/>
	public class SysQueryHandleRuleListenerSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public SysQueryHandleRuleListenerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public SysQueryHandleRuleListenerSchema(SysQueryHandleRuleListenerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("6fabf0d1-6f2f-4d52-b60e-7db0f3d645ff");
			Name = "SysQueryHandleRuleListener";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("24377658-5c78-47a6-b5ee-e5beab1bcee6");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,213,88,221,111,219,54,16,127,118,129,253,15,172,11,4,54,96,200,217,107,227,24,112,156,164,51,144,172,93,147,174,15,195,48,208,18,109,115,149,68,143,164,146,120,169,255,247,29,63,36,83,18,229,56,105,210,185,15,9,44,242,238,120,159,63,222,17,165,56,33,98,137,67,130,174,9,231,88,176,153,12,198,44,157,209,121,198,177,164,44,13,126,203,8,95,157,221,145,48,83,159,31,179,152,136,159,94,221,255,244,170,149,9,154,206,209,213,74,72,146,28,85,190,65,70,28,147,80,113,136,224,29,73,9,167,97,141,230,130,166,255,212,22,175,224,32,78,229,106,179,225,42,150,36,44,245,239,112,210,180,30,156,158,52,110,157,165,146,74,74,196,131,4,193,217,13,73,101,51,221,57,14,37,227,219,36,121,252,8,180,64,253,134,147,57,172,160,113,140,133,120,171,252,160,73,127,193,105,20,19,69,119,65,193,51,224,66,77,221,239,247,209,64,100,73,130,249,106,104,191,33,96,146,179,88,32,185,32,104,22,179,91,196,102,40,228,4,2,8,122,128,28,148,176,136,206,86,214,205,21,241,65,46,181,95,17,59,16,132,224,88,48,37,106,118,220,222,238,153,224,4,11,162,215,86,122,33,87,186,141,250,74,222,31,158,173,206,85,184,32,9,254,21,82,16,29,163,118,93,179,118,247,79,96,93,102,211,152,134,40,84,238,217,226,29,244,22,53,168,0,50,238,181,239,10,87,95,18,185,96,17,56,251,3,167,55,88,18,181,167,254,150,230,19,209,84,162,191,18,154,126,100,183,99,150,129,36,118,75,248,239,56,206,148,162,63,31,30,30,30,161,156,229,13,73,35,35,181,88,105,60,196,61,226,134,209,8,66,78,48,215,246,40,75,70,203,101,76,9,31,99,112,75,231,147,128,95,44,77,77,17,161,172,244,217,69,170,0,91,173,27,204,17,223,112,130,114,58,137,76,50,174,160,240,228,96,82,21,63,236,116,143,52,179,195,24,104,69,236,198,186,172,232,148,177,24,129,164,137,24,193,217,55,218,231,167,25,176,133,176,27,117,234,1,65,162,182,148,235,171,101,81,43,8,180,173,83,42,157,175,87,75,18,1,128,100,73,170,125,62,80,108,195,78,59,215,160,109,13,160,51,212,121,157,75,203,143,104,113,34,51,158,162,25,100,46,49,116,107,253,223,36,134,73,57,207,193,118,195,171,147,217,59,114,196,120,168,206,57,75,78,167,94,1,134,63,24,171,138,180,9,218,241,28,83,14,185,53,178,233,32,69,61,138,84,142,210,249,66,10,56,215,88,220,50,73,168,83,35,100,105,68,53,6,195,118,74,110,209,41,213,162,161,198,7,66,114,128,131,30,98,211,191,225,188,97,238,189,123,180,113,115,15,73,14,25,191,238,21,91,151,155,146,128,221,29,163,7,197,4,193,115,89,187,174,204,60,129,78,137,36,42,109,119,23,252,46,163,17,72,174,10,152,68,229,3,38,194,92,45,187,11,46,242,205,50,118,77,6,173,77,68,212,177,74,146,137,234,36,218,61,143,55,10,231,188,110,42,187,34,95,31,35,69,28,156,37,75,185,42,82,123,19,207,96,20,69,142,32,99,90,206,109,101,174,17,129,132,216,133,55,205,226,184,235,214,138,85,199,159,120,231,68,134,11,253,251,164,179,145,218,51,249,215,69,7,7,230,192,230,204,5,60,84,215,140,227,25,101,175,199,135,117,194,106,149,171,4,117,21,175,21,255,218,135,186,11,18,126,209,181,243,126,73,76,151,99,138,104,119,208,141,166,121,159,114,150,206,105,170,176,172,76,12,77,71,153,194,129,172,42,179,202,149,49,78,77,111,64,10,157,58,109,88,188,196,41,158,147,43,240,128,90,106,119,11,7,212,132,104,171,182,139,41,174,2,145,231,221,186,101,241,162,209,79,147,20,236,146,30,111,237,161,179,140,174,112,247,243,149,92,0,186,57,238,106,142,121,230,67,221,245,86,159,124,90,70,176,240,99,248,196,232,250,242,62,57,37,49,249,81,124,98,116,125,78,159,148,219,71,167,122,252,77,211,86,151,244,60,77,238,150,158,74,89,223,220,158,121,248,10,91,149,207,161,167,103,252,146,8,1,240,96,155,132,11,22,226,152,254,139,167,208,184,232,38,161,98,122,240,145,8,150,241,16,118,25,7,182,158,175,117,47,218,127,123,15,183,218,53,177,194,54,68,70,239,141,206,26,160,38,226,3,103,11,58,165,176,16,104,232,111,119,131,107,102,21,178,222,111,201,5,135,97,71,41,93,4,255,46,36,75,29,104,215,178,29,163,229,244,40,15,133,72,77,8,206,128,224,6,195,89,70,131,134,49,98,91,12,76,103,22,156,51,158,96,217,249,63,34,162,200,63,83,185,112,252,113,1,234,93,47,224,34,161,230,34,174,71,167,215,100,234,183,197,170,58,99,249,39,44,61,34,154,205,234,128,172,23,140,27,124,227,35,186,194,55,36,66,68,13,140,65,193,223,175,10,24,44,49,199,9,82,207,37,199,109,1,250,128,35,135,122,202,68,230,43,24,244,53,137,159,131,180,135,215,48,155,171,137,58,159,166,223,54,206,211,122,64,24,205,36,225,250,128,17,159,11,53,69,67,206,9,137,211,144,168,190,94,98,154,170,113,30,38,254,252,64,109,2,2,180,199,37,93,236,248,204,0,237,56,141,108,186,191,183,119,165,202,37,51,1,88,51,122,200,28,127,66,102,160,84,113,62,82,25,235,142,22,117,92,129,204,245,12,131,93,35,214,196,116,107,77,249,219,232,50,139,17,243,64,95,226,5,106,59,121,154,134,94,73,46,236,127,194,24,154,143,5,155,235,199,43,121,223,128,214,81,209,65,87,171,211,243,130,108,171,134,167,85,0,125,250,240,216,117,179,192,127,235,61,124,88,158,22,88,144,192,45,134,188,10,114,130,45,47,52,190,60,91,63,13,131,116,147,166,114,113,239,96,168,130,3,77,56,148,159,166,30,32,31,135,67,185,233,187,195,208,254,96,80,243,28,224,197,32,253,36,3,119,232,60,79,113,209,136,61,99,151,76,87,130,232,248,144,76,111,89,98,16,86,150,30,140,210,85,231,14,29,15,209,93,96,30,89,143,81,13,189,106,192,88,228,226,183,226,162,50,23,115,167,83,176,106,53,170,251,121,65,56,41,41,252,26,20,190,96,243,43,137,195,47,215,28,135,10,159,12,156,116,209,16,29,214,241,183,228,143,175,95,203,192,92,88,118,112,176,77,177,61,106,144,207,34,42,253,168,253,204,112,109,179,192,193,217,71,37,85,9,159,221,168,212,5,150,39,173,23,189,33,214,207,126,79,20,96,245,136,107,98,199,135,222,39,222,28,122,148,253,62,55,71,190,254,141,55,200,163,26,217,141,61,15,94,36,185,39,126,196,139,164,249,241,196,123,145,248,159,103,119,195,230,253,1,55,99,244,247,108,74,109,21,23,153,242,34,85,108,134,164,39,213,241,62,206,161,47,222,0,90,203,253,101,91,158,130,33,80,247,181,64,170,71,174,74,28,159,92,211,207,6,227,149,23,11,179,90,94,132,181,255,0,196,7,20,134,126,33,0,0 };
		}

		protected override void InitializeLocalizableStrings() {
			base.InitializeLocalizableStrings();
			SetLocalizableStringsDefInheritance();
			LocalizableStrings.Add(CreateCreateActiveDuplicatedRulesIsProhibitedLocalizableString());
			LocalizableStrings.Add(CreateDeleteSystemRuleIsProhibitedMessageLocalizableString());
			LocalizableStrings.Add(CreateEditSystemRuleIsProhibitedLocalizableString());
			LocalizableStrings.Add(CreateCreateSystemRuleIsProhibitedMessageLocalizableString());
			LocalizableStrings.Add(CreateCreateRuleWithMinRowCountLessThanMinValueProhibitedLocalizableString());
		}

		protected virtual SchemaLocalizableString CreateCreateActiveDuplicatedRulesIsProhibitedLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("b4ab4cb4-79e2-a790-cdf9-1e29d6a4693b"),
				Name = "CreateActiveDuplicatedRulesIsProhibited",
				CreatedInPackageId = new Guid("24377658-5c78-47a6-b5ee-e5beab1bcee6"),
				CreatedInSchemaUId = new Guid("6fabf0d1-6f2f-4d52-b60e-7db0f3d645ff"),
				ModifiedInSchemaUId = new Guid("6fabf0d1-6f2f-4d52-b60e-7db0f3d645ff")
			};
			return localizableString;
		}

		protected virtual SchemaLocalizableString CreateDeleteSystemRuleIsProhibitedMessageLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("fbeac549-ba21-9164-332e-1c2b6e5a086d"),
				Name = "DeleteSystemRuleIsProhibitedMessage",
				CreatedInPackageId = new Guid("24377658-5c78-47a6-b5ee-e5beab1bcee6"),
				CreatedInSchemaUId = new Guid("6fabf0d1-6f2f-4d52-b60e-7db0f3d645ff"),
				ModifiedInSchemaUId = new Guid("6fabf0d1-6f2f-4d52-b60e-7db0f3d645ff")
			};
			return localizableString;
		}

		protected virtual SchemaLocalizableString CreateEditSystemRuleIsProhibitedLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("654dcd12-b490-703e-31f7-66b56cd63ec4"),
				Name = "EditSystemRuleIsProhibited",
				CreatedInPackageId = new Guid("24377658-5c78-47a6-b5ee-e5beab1bcee6"),
				CreatedInSchemaUId = new Guid("6fabf0d1-6f2f-4d52-b60e-7db0f3d645ff"),
				ModifiedInSchemaUId = new Guid("6fabf0d1-6f2f-4d52-b60e-7db0f3d645ff")
			};
			return localizableString;
		}

		protected virtual SchemaLocalizableString CreateCreateSystemRuleIsProhibitedMessageLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("3ced39a4-9f25-4e0d-ec88-30df6d43c472"),
				Name = "CreateSystemRuleIsProhibitedMessage",
				CreatedInPackageId = new Guid("24377658-5c78-47a6-b5ee-e5beab1bcee6"),
				CreatedInSchemaUId = new Guid("6fabf0d1-6f2f-4d52-b60e-7db0f3d645ff"),
				ModifiedInSchemaUId = new Guid("6fabf0d1-6f2f-4d52-b60e-7db0f3d645ff")
			};
			return localizableString;
		}

		protected virtual SchemaLocalizableString CreateCreateRuleWithMinRowCountLessThanMinValueProhibitedLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("b7776b09-484f-5813-d9b7-a509e23eff9f"),
				Name = "CreateRuleWithMinRowCountLessThanMinValueProhibited",
				CreatedInPackageId = new Guid("4e6ccfb8-9251-4fde-a337-f61d1d253a58"),
				CreatedInSchemaUId = new Guid("6fabf0d1-6f2f-4d52-b60e-7db0f3d645ff"),
				ModifiedInSchemaUId = new Guid("6fabf0d1-6f2f-4d52-b60e-7db0f3d645ff")
			};
			return localizableString;
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("6fabf0d1-6f2f-4d52-b60e-7db0f3d645ff"));
		}

		#endregion

	}

	#endregion

}

