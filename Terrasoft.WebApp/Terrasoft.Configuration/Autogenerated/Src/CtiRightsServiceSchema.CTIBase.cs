namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: CtiRightsServiceSchema

	/// <exclude/>
	public class CtiRightsServiceSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public CtiRightsServiceSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public CtiRightsServiceSchema(CtiRightsServiceSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("a6c64027-2137-42ca-b41d-24afcb039a7e");
			Name = "CtiRightsService";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("c124cf91-dc7b-4db8-b77e-ff0b639610dd");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,141,82,203,110,219,48,16,60,43,64,254,129,201,33,144,1,65,31,208,23,224,24,104,226,34,174,11,59,69,14,70,15,180,180,178,9,83,164,202,93,25,16,140,252,123,151,148,44,43,110,224,246,66,129,59,179,179,51,212,26,89,2,86,50,3,241,12,206,73,180,5,165,19,107,10,181,169,157,36,101,205,245,213,225,250,42,170,81,153,141,88,54,72,80,50,174,53,100,30,196,244,1,12,56,149,125,60,231,44,193,237,85,6,51,155,131,190,8,166,47,176,190,76,24,243,168,125,240,242,23,143,123,153,139,200,216,146,36,193,137,112,74,227,57,19,91,150,161,157,241,85,39,206,41,201,201,140,126,249,218,24,171,239,64,76,171,120,208,90,105,69,205,2,126,215,202,65,9,134,48,30,94,188,43,241,89,252,163,197,179,210,174,144,143,252,144,170,94,107,149,137,76,75,68,49,33,181,80,155,45,97,231,230,131,184,151,8,221,37,17,211,5,200,124,110,116,51,76,199,26,135,16,33,90,205,43,104,127,207,48,69,180,226,172,83,179,183,59,136,103,64,91,155,179,205,219,31,243,229,243,109,34,238,109,222,44,169,209,222,58,211,102,172,43,55,208,87,211,23,39,171,10,242,196,235,68,222,55,32,125,181,174,148,244,166,161,45,165,223,208,154,68,44,120,117,120,9,224,50,47,132,63,166,95,91,171,197,3,208,79,4,247,40,177,207,241,196,177,89,41,126,82,72,159,144,28,255,195,47,194,30,81,76,218,70,133,99,211,244,61,35,113,8,110,247,210,9,215,89,97,19,228,234,176,8,81,84,88,7,50,219,138,216,51,122,49,161,204,64,249,40,18,133,1,217,22,178,29,123,153,154,194,178,148,119,201,47,108,218,109,79,25,120,4,205,173,188,246,244,158,251,94,118,212,26,136,84,33,226,155,55,162,119,119,226,230,253,24,81,52,8,81,72,141,93,10,182,198,49,118,221,229,85,156,148,207,133,255,67,247,244,56,103,178,225,211,158,14,168,118,166,127,210,192,120,13,139,23,78,62,254,0,215,182,249,86,54,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("a6c64027-2137-42ca-b41d-24afcb039a7e"));
		}

		#endregion

	}

	#endregion

}

