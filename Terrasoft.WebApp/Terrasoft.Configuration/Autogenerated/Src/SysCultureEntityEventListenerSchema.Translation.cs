namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: SysCultureEntityEventListenerSchema

	/// <exclude/>
	public class SysCultureEntityEventListenerSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public SysCultureEntityEventListenerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public SysCultureEntityEventListenerSchema(SysCultureEntityEventListenerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("b328d2b1-036c-437d-aad7-35487fc8a461");
			Name = "SysCultureEntityEventListener";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("2f244451-ec5e-494f-9790-8d930a80007c");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,141,84,77,111,26,49,16,61,111,164,252,135,17,189,108,36,100,14,149,122,128,36,82,178,162,85,170,208,47,104,47,81,15,198,59,128,219,93,155,142,189,164,52,202,127,239,172,189,100,89,74,211,94,64,120,222,188,55,239,121,12,24,89,162,91,75,133,48,67,34,233,236,194,139,204,154,133,94,86,36,189,182,230,244,228,225,244,36,169,156,54,203,14,164,44,173,25,29,173,16,138,177,241,218,107,116,255,4,136,241,6,141,175,113,140,124,65,184,100,69,200,10,233,220,16,166,91,151,85,133,175,8,3,122,27,160,183,218,121,52,72,161,225,238,72,33,157,170,21,150,242,29,251,130,11,232,181,36,189,179,175,220,178,174,230,133,86,160,106,137,231,21,96,8,215,210,29,215,78,30,130,126,59,177,53,206,75,54,50,132,15,164,55,210,99,172,175,227,15,80,117,29,180,241,208,232,101,182,226,31,23,240,242,213,168,97,66,147,71,178,46,243,4,253,202,230,127,227,101,81,207,110,54,86,231,144,173,80,125,111,29,185,32,145,198,241,1,195,215,25,212,119,153,36,27,73,80,57,36,30,219,160,170,111,153,71,137,16,241,185,115,62,122,194,163,251,193,32,131,247,16,41,99,204,31,43,164,109,218,229,18,251,128,137,52,114,137,212,239,222,68,164,101,74,113,149,231,153,45,170,210,164,189,155,124,87,168,245,148,45,138,118,54,70,190,65,31,137,179,167,202,129,112,211,173,23,144,182,221,34,70,125,222,73,126,23,68,66,200,103,141,203,199,214,43,145,165,25,150,235,162,14,57,186,190,181,74,22,250,151,156,23,56,245,196,43,125,232,250,19,58,91,145,226,170,37,182,220,113,124,100,137,122,253,56,65,239,15,98,39,50,94,165,58,152,216,44,190,200,162,226,208,196,204,54,202,123,49,133,81,39,232,28,75,242,164,46,0,196,107,75,165,244,105,199,71,127,87,124,107,53,167,205,243,245,187,153,52,172,126,69,246,62,88,102,93,157,115,231,248,167,194,117,200,123,95,45,194,31,255,119,125,195,187,139,197,193,96,0,231,218,172,144,180,207,173,26,92,134,149,142,15,211,110,88,67,231,24,119,250,189,185,49,156,178,175,77,219,249,55,78,26,28,43,213,251,20,35,189,198,5,255,157,132,96,175,104,233,0,119,55,59,231,167,43,246,219,119,125,205,220,201,241,231,18,81,32,93,195,255,156,201,120,122,112,88,127,132,194,111,234,223,20,253,90,5,0,0 };
		}

		protected override void InitializeLocalizableStrings() {
			base.InitializeLocalizableStrings();
			SetLocalizableStringsDefInheritance();
			LocalizableStrings.Add(CreateCantAddCultureLocalizableString());
		}

		protected virtual SchemaLocalizableString CreateCantAddCultureLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("116140f6-d9b9-3bcb-5745-5a043b86275e"),
				Name = "CantAddCulture",
				CreatedInPackageId = new Guid("2f244451-ec5e-494f-9790-8d930a80007c"),
				CreatedInSchemaUId = new Guid("b328d2b1-036c-437d-aad7-35487fc8a461"),
				ModifiedInSchemaUId = new Guid("b328d2b1-036c-437d-aad7-35487fc8a461")
			};
			return localizableString;
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("b328d2b1-036c-437d-aad7-35487fc8a461"));
		}

		#endregion

	}

	#endregion

}

