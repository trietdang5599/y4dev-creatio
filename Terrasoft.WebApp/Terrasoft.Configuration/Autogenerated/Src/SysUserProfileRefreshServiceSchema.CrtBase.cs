namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: SysUserProfileRefreshServiceSchema

	/// <exclude/>
	public class SysUserProfileRefreshServiceSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public SysUserProfileRefreshServiceSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public SysUserProfileRefreshServiceSchema(SysUserProfileRefreshServiceSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("803ab10e-c8ad-4b9b-b660-c988f5e60033");
			Name = "SysUserProfileRefreshService";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("b5578e4f-2732-4fb5-8de7-483c06c796b9");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,141,83,77,143,218,48,20,60,103,165,253,15,22,189,4,9,229,7,236,170,7,160,173,186,149,232,34,178,85,15,104,15,38,153,128,213,196,78,253,28,186,8,241,223,251,156,15,32,187,109,218,75,132,199,243,230,189,25,63,132,150,5,168,148,9,196,19,172,149,100,50,23,205,141,206,212,182,178,210,41,163,111,111,142,183,55,65,69,74,111,69,124,32,135,226,254,213,57,138,97,247,42,193,194,164,200,7,47,163,239,216,12,19,166,137,83,251,186,239,133,119,25,140,203,121,184,162,248,251,237,103,231,202,104,186,33,103,101,226,85,104,88,166,107,190,50,149,99,14,147,153,254,206,98,203,165,98,158,75,162,59,63,230,55,130,93,90,147,169,28,43,100,22,180,107,235,106,254,250,3,50,89,229,238,74,11,207,30,111,1,142,179,30,167,193,168,124,195,155,82,249,21,142,39,42,217,249,70,229,202,29,86,248,89,41,139,2,218,81,120,125,240,49,137,247,226,31,37,158,21,181,64,58,246,77,202,106,147,171,68,36,222,211,160,37,113,39,102,146,112,54,24,28,107,147,231,84,22,112,59,147,114,46,203,90,177,185,92,63,150,104,214,229,218,108,176,230,164,31,244,222,252,64,216,148,241,228,163,229,99,252,52,154,8,63,29,200,125,50,182,144,142,113,166,46,64,36,183,104,160,232,11,25,61,17,51,147,30,98,119,200,209,163,156,209,104,38,45,38,190,87,176,226,61,230,7,199,176,98,29,70,151,70,111,209,187,103,105,101,68,27,203,188,178,150,35,245,121,133,99,113,172,91,57,123,104,127,5,30,103,25,141,122,221,162,183,69,15,58,51,225,248,254,143,236,152,159,240,194,156,243,14,85,22,103,178,223,101,31,39,94,248,47,217,208,184,130,136,43,215,163,190,210,232,153,253,246,161,86,196,130,53,181,208,248,53,232,182,107,122,18,137,116,201,78,132,31,95,18,148,158,40,208,185,254,111,45,116,98,245,215,127,78,237,14,65,167,205,26,213,231,6,237,131,167,223,240,157,253,162,146,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("803ab10e-c8ad-4b9b-b660-c988f5e60033"));
		}

		#endregion

	}

	#endregion

}

