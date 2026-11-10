namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: AdminUtilitiesSchema

	/// <exclude/>
	public class AdminUtilitiesSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public AdminUtilitiesSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public AdminUtilitiesSchema(AdminUtilitiesSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("170e19f8-c937-4f98-aec0-9d08e2acf0d5");
			Name = "AdminUtilities";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,117,82,201,110,219,48,16,61,203,128,255,129,208,137,60,152,144,208,34,105,96,244,16,91,114,32,160,40,10,199,73,14,69,15,140,52,118,8,80,164,202,197,173,81,228,223,203,197,173,42,183,61,72,67,190,153,121,111,22,58,195,229,1,221,159,140,133,126,57,159,185,120,221,129,214,204,168,189,165,107,213,247,74,254,211,161,225,63,48,173,86,222,51,159,73,214,131,25,88,11,19,191,220,243,131,211,204,114,37,231,179,31,243,89,54,184,103,193,91,100,172,199,90,212,10,102,12,186,237,122,46,31,44,23,220,114,48,62,40,4,94,68,106,96,157,146,226,132,238,28,239,80,5,251,181,18,174,151,91,126,120,177,31,224,8,162,233,208,123,36,225,91,12,192,121,81,92,111,138,183,117,189,40,55,117,185,168,54,101,185,184,185,46,87,139,162,40,171,171,162,190,121,243,110,125,149,147,101,150,101,65,235,111,189,40,115,7,118,171,148,77,245,73,110,155,14,63,24,208,190,45,9,109,232,9,185,201,149,160,88,121,118,15,194,3,200,36,147,202,74,24,190,72,160,59,53,224,146,208,212,13,206,155,46,39,116,163,85,143,115,191,165,223,194,30,140,196,217,211,11,104,152,250,118,167,1,30,153,112,224,131,26,83,127,117,76,224,68,23,230,111,44,46,8,161,183,210,207,228,19,211,32,125,71,2,162,76,99,62,58,33,48,65,204,156,171,91,70,145,180,101,124,100,26,117,207,245,119,104,157,85,218,119,49,45,157,214,210,56,13,213,106,132,48,249,53,128,9,7,179,108,235,183,7,129,35,141,132,38,86,72,48,30,85,70,130,140,239,17,30,83,105,48,127,240,103,153,6,235,244,229,2,252,99,12,227,240,192,17,180,245,105,213,42,142,102,167,226,171,24,249,62,135,73,127,33,203,51,219,107,178,103,19,255,233,124,86,9,217,180,238,7,123,138,25,193,231,191,215,159,45,84,32,219,79,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("170e19f8-c937-4f98-aec0-9d08e2acf0d5"));
		}

		#endregion

	}

	#endregion

}

