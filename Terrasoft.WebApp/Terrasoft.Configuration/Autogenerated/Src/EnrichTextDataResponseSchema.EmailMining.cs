namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: EnrichTextDataResponseSchema

	/// <exclude/>
	public class EnrichTextDataResponseSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public EnrichTextDataResponseSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public EnrichTextDataResponseSchema(EnrichTextDataResponseSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("292254cb-473a-40ba-91c0-ffcaaa382dcd");
			Name = "EnrichTextDataResponse";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("c9ff5cbb-cb0e-4041-b483-395260757ab0");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,149,82,77,79,235,48,16,60,23,137,255,176,10,151,246,146,220,161,141,132,248,18,18,32,4,220,158,222,193,56,155,214,194,177,35,123,221,247,0,241,223,89,59,161,74,11,45,112,179,215,179,227,217,217,49,162,65,223,10,137,240,128,206,9,111,107,202,79,172,169,213,60,56,65,202,154,253,189,215,253,189,81,240,202,204,225,254,217,19,54,71,27,119,198,107,141,50,130,125,126,129,6,157,146,159,48,119,193,144,106,48,191,231,87,161,213,75,226,102,20,227,14,28,206,249,2,39,90,120,127,8,103,134,251,23,15,248,159,78,5,137,59,86,199,188,152,144,69,81,192,212,135,166,17,238,185,236,239,29,28,136,241,80,113,3,160,198,6,13,121,144,43,89,249,71,111,49,104,254,19,233,121,84,114,66,210,95,46,180,225,81,43,9,50,202,216,170,98,244,154,148,172,68,223,58,219,162,35,133,172,252,54,17,116,239,155,82,251,2,34,72,135,245,44,235,248,227,247,252,251,37,59,148,65,81,130,226,131,7,173,60,229,171,158,161,230,78,244,53,54,143,232,198,55,188,58,152,65,22,167,206,38,113,130,143,17,174,152,96,186,62,65,252,162,132,120,130,184,207,209,104,142,116,148,14,190,63,188,237,16,126,101,237,83,104,97,41,116,64,15,182,6,33,165,13,209,100,90,8,2,135,154,247,185,68,32,203,174,167,145,126,161,191,102,166,234,184,39,220,58,72,15,232,230,56,31,182,124,51,208,1,154,170,91,214,250,230,216,123,79,46,72,178,110,99,119,253,231,95,71,96,60,233,255,75,94,206,192,224,191,173,126,143,39,63,17,114,141,180,176,213,79,242,115,92,85,30,166,173,112,162,225,16,129,97,3,103,89,204,76,198,217,97,239,7,249,138,26,98,117,71,150,82,37,145,13,153,202,157,33,141,25,101,219,132,145,152,79,139,212,92,14,44,91,90,85,69,149,227,207,102,164,108,15,189,203,35,46,21,183,153,212,215,214,125,123,123,7,175,45,156,55,178,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("292254cb-473a-40ba-91c0-ffcaaa382dcd"));
		}

		#endregion

	}

	#endregion

}

