namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: SysCultureServiceSchema

	/// <exclude/>
	public class SysCultureServiceSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public SysCultureServiceSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public SysCultureServiceSchema(SysCultureServiceSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("a4865d94-8357-4f78-a417-9cd6dcdf4fff");
			Name = "SysCultureService";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("0b3cc894-bd0d-4e1b-bb7d-87203708d013");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,133,146,205,78,235,64,12,133,215,65,226,29,172,178,105,165,222,100,15,5,9,122,117,209,69,42,84,180,21,139,138,197,52,113,202,136,100,38,140,103,82,69,136,119,103,126,210,180,80,84,150,227,57,254,108,31,91,176,18,169,98,41,194,28,149,98,36,115,29,143,165,200,249,218,40,166,185,20,167,39,239,167,39,145,33,46,214,48,107,72,99,121,241,237,29,207,80,213,60,197,137,204,176,56,250,25,95,167,154,215,30,123,92,247,132,171,157,96,215,152,13,219,230,202,210,167,219,255,51,133,107,203,130,113,193,136,206,29,105,108,10,109,20,182,48,47,74,146,4,70,100,202,146,169,230,170,125,79,149,172,121,134,4,27,92,253,161,32,134,92,42,216,72,245,10,27,174,95,32,71,230,72,20,111,17,201,30,99,217,22,176,78,105,197,82,253,236,98,215,84,221,163,182,253,85,118,194,21,47,184,110,30,241,205,112,133,37,10,77,253,253,135,27,19,46,225,151,20,167,138,219,64,54,112,69,42,179,42,120,10,169,27,248,112,94,56,135,27,70,187,233,35,183,186,206,165,9,234,23,153,89,159,166,30,226,205,57,112,199,7,30,209,66,5,65,134,57,179,5,32,13,85,192,8,254,102,208,26,39,52,207,57,170,184,35,36,223,17,35,21,24,87,127,127,99,140,146,173,212,229,46,31,42,12,135,183,239,109,180,180,171,255,47,106,249,138,253,48,134,53,175,55,125,152,205,123,67,88,40,62,199,178,42,152,118,150,246,110,81,183,53,91,115,172,228,70,102,205,76,55,133,19,88,210,4,137,216,26,187,104,252,164,88,85,97,54,116,165,34,103,56,146,254,39,85,201,244,151,132,16,138,239,72,138,161,53,137,42,41,8,143,235,252,214,182,107,187,53,60,131,131,254,250,3,240,123,138,106,166,128,186,157,46,180,187,7,110,143,244,18,4,110,246,182,221,253,244,23,246,118,173,79,2,83,231,216,224,194,99,130,157,63,145,226,31,106,251,156,143,112,12,103,40,178,112,44,254,29,162,95,131,31,159,132,100,143,63,49,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("a4865d94-8357-4f78-a417-9cd6dcdf4fff"));
		}

		#endregion

	}

	#endregion

}

