namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: SysLicPackageInRoleEventListenerSchema

	/// <exclude/>
	public class SysLicPackageInRoleEventListenerSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public SysLicPackageInRoleEventListenerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public SysLicPackageInRoleEventListenerSchema(SysLicPackageInRoleEventListenerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("f56389cb-3571-4cd8-a2dc-f7c4e393fd13");
			Name = "SysLicPackageInRoleEventListener";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("acb004d0-c421-4dff-b075-f4fdc1c90074");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,205,86,75,111,219,56,16,62,187,64,255,3,215,123,81,0,67,222,115,19,7,72,92,167,13,144,182,222,186,217,61,44,22,11,70,26,219,220,82,164,59,164,220,117,31,255,189,195,135,108,73,150,211,44,154,20,185,216,224,112,30,223,12,191,25,141,226,5,152,21,207,128,189,3,68,110,244,220,166,99,173,230,98,81,34,183,66,171,167,79,62,63,125,210,43,141,80,11,54,219,24,11,197,241,246,92,55,41,10,173,186,111,16,14,201,211,137,178,194,10,48,223,85,72,39,107,80,214,233,145,230,175,8,11,66,198,198,146,27,243,204,161,186,18,217,148,103,239,249,2,46,213,91,45,193,107,95,9,66,171,0,189,205,112,56,100,39,166,44,10,142,155,211,120,126,201,85,46,1,217,92,99,151,19,6,46,248,134,129,15,157,86,78,134,45,47,39,6,128,75,163,89,134,48,31,245,111,79,32,61,231,6,188,108,211,192,216,103,67,231,239,175,142,171,100,150,45,161,224,175,233,161,216,136,245,59,128,246,143,254,38,219,85,121,35,69,198,50,87,148,239,214,132,61,99,7,144,144,167,207,190,98,219,50,95,8,144,57,213,121,138,98,205,45,132,203,85,56,176,107,3,72,124,81,144,57,178,176,127,202,198,249,56,122,2,149,7,103,77,207,175,192,46,245,65,215,107,45,114,54,94,66,246,158,82,1,101,224,221,102,5,201,139,146,164,166,145,94,126,196,28,71,123,61,95,241,6,123,211,80,8,103,201,100,252,31,177,23,96,163,112,138,218,18,84,200,147,182,203,99,239,81,204,89,82,217,253,50,98,183,6,72,167,128,70,43,46,43,56,61,99,209,113,154,58,204,144,83,10,172,224,35,187,210,25,151,226,19,191,145,48,243,247,73,171,104,233,91,48,186,196,140,174,53,146,221,32,56,235,117,61,125,147,68,3,214,223,243,110,210,55,74,110,42,104,177,146,102,130,168,49,253,131,203,146,216,19,82,237,217,37,234,143,30,226,228,191,12,86,14,74,18,161,71,149,175,238,247,235,161,87,34,120,103,121,33,212,181,18,182,241,84,91,233,238,165,214,28,25,152,15,177,36,129,134,129,231,191,151,128,155,189,146,212,53,94,113,69,144,112,224,123,97,235,187,74,131,188,166,103,121,62,214,178,44,84,210,191,204,15,92,180,209,54,106,225,116,47,132,180,84,53,103,147,184,243,24,129,242,13,210,63,133,93,78,57,82,75,58,149,36,8,105,6,174,56,10,170,179,103,195,228,67,201,37,129,36,4,131,118,21,238,49,204,107,109,171,72,221,41,69,250,120,234,62,63,79,219,74,169,235,224,71,5,104,6,114,62,3,92,19,85,167,26,45,151,117,132,129,8,244,136,50,78,28,136,3,150,168,228,208,82,107,183,85,218,100,170,181,118,101,76,61,93,42,203,70,35,246,219,35,108,94,175,251,0,13,123,161,241,121,185,162,241,70,98,211,213,173,3,214,53,109,163,84,220,127,51,239,127,216,238,208,211,247,213,167,20,223,199,124,200,102,173,197,218,229,26,34,54,62,62,15,211,142,126,18,137,252,167,180,210,233,163,235,164,29,213,127,188,151,238,176,208,196,189,162,234,189,120,100,107,129,150,94,227,246,77,162,115,65,185,109,241,65,176,37,238,109,95,41,169,190,4,185,2,116,111,73,238,163,93,116,189,191,242,176,255,149,162,223,55,195,165,223,131,133,90,2,10,155,235,44,44,179,213,70,170,215,180,18,139,60,78,158,55,106,198,215,238,185,245,205,191,4,147,25,138,227,250,63,80,237,28,104,25,15,207,121,134,11,195,160,202,240,134,182,213,116,107,91,25,65,131,202,213,194,62,98,73,16,28,5,189,160,211,42,142,35,185,87,74,175,219,43,107,28,105,205,49,176,211,167,90,186,242,197,113,228,105,116,226,30,231,52,169,102,200,110,64,69,63,245,50,223,213,81,221,166,95,107,180,38,172,244,210,76,138,149,221,36,71,236,203,151,118,168,221,229,182,23,3,83,106,140,238,117,239,110,173,25,120,188,83,173,47,227,221,75,179,75,58,43,17,41,205,59,166,187,203,176,227,195,212,254,38,237,125,142,182,177,130,143,110,2,7,105,83,72,178,111,97,176,216,148,0,15,0,0 };
		}

		protected override void InitializeLocalizableStrings() {
			base.InitializeLocalizableStrings();
			SetLocalizableStringsDefInheritance();
			LocalizableStrings.Add(CreateDuplicatesErrorLocalizableString());
			LocalizableStrings.Add(CreateOnlyRoleErrorLocalizableString());
			LocalizableStrings.Add(CreateOnlyPersonalLicensesErrorLocalizableString());
		}

		protected virtual SchemaLocalizableString CreateDuplicatesErrorLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("b47699c9-0637-b858-a6e2-fc299dc18530"),
				Name = "DuplicatesError",
				CreatedInPackageId = new Guid("acb004d0-c421-4dff-b075-f4fdc1c90074"),
				CreatedInSchemaUId = new Guid("f56389cb-3571-4cd8-a2dc-f7c4e393fd13"),
				ModifiedInSchemaUId = new Guid("f56389cb-3571-4cd8-a2dc-f7c4e393fd13")
			};
			return localizableString;
		}

		protected virtual SchemaLocalizableString CreateOnlyRoleErrorLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("daf4d4b7-213c-3ef2-9a86-2ed15e9a56a1"),
				Name = "OnlyRoleError",
				CreatedInPackageId = new Guid("acb004d0-c421-4dff-b075-f4fdc1c90074"),
				CreatedInSchemaUId = new Guid("f56389cb-3571-4cd8-a2dc-f7c4e393fd13"),
				ModifiedInSchemaUId = new Guid("f56389cb-3571-4cd8-a2dc-f7c4e393fd13")
			};
			return localizableString;
		}

		protected virtual SchemaLocalizableString CreateOnlyPersonalLicensesErrorLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("bfb43b91-5655-d0fd-efe1-7671146130ef"),
				Name = "OnlyPersonalLicensesError",
				CreatedInPackageId = new Guid("acb004d0-c421-4dff-b075-f4fdc1c90074"),
				CreatedInSchemaUId = new Guid("f56389cb-3571-4cd8-a2dc-f7c4e393fd13"),
				ModifiedInSchemaUId = new Guid("f56389cb-3571-4cd8-a2dc-f7c4e393fd13")
			};
			return localizableString;
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("f56389cb-3571-4cd8-a2dc-f7c4e393fd13"));
		}

		#endregion

	}

	#endregion

}

