namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: CloudDataResponseSchema

	/// <exclude/>
	public class CloudDataResponseSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public CloudDataResponseSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public CloudDataResponseSchema(CloudDataResponseSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("db4128e4-39dd-4160-97b6-b20928a12b20");
			Name = "CloudDataResponse";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("c9ff5cbb-cb0e-4041-b483-395260757ab0");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,141,146,207,107,194,48,20,199,207,21,252,31,30,221,69,47,237,125,182,133,225,198,24,204,33,186,219,216,33,166,207,26,104,147,146,164,27,78,252,223,247,146,214,81,117,138,167,38,223,188,31,159,247,125,149,172,66,83,51,142,240,142,90,51,163,214,54,154,42,185,22,69,163,153,21,74,14,7,187,225,32,104,140,144,5,44,183,198,98,69,239,101,137,220,61,154,232,25,37,106,193,39,167,49,139,70,90,81,97,180,164,87,86,138,31,95,139,162,40,238,78,99,65,23,152,150,204,152,123,250,168,38,127,100,150,45,8,132,74,162,15,138,227,24,18,211,84,21,211,219,172,187,63,73,234,180,1,174,164,101,220,2,150,88,161,180,134,132,3,79,116,200,140,123,169,31,174,56,205,100,53,101,125,146,80,55,171,82,112,224,174,255,127,237,131,157,71,248,3,157,107,85,163,182,2,137,118,238,115,219,247,83,198,78,64,4,174,113,157,134,45,239,180,197,125,33,87,66,136,51,16,116,48,80,10,99,163,191,156,62,110,203,59,195,106,133,122,244,70,235,129,20,194,156,164,112,236,224,15,244,175,84,32,57,235,144,129,75,6,183,178,32,40,208,78,252,193,116,135,125,55,23,202,188,29,237,120,78,170,99,172,110,184,85,250,100,210,174,231,153,87,163,113,215,202,119,77,65,226,247,37,176,209,248,22,132,25,218,141,202,111,241,249,33,207,13,36,53,211,172,34,179,65,146,81,105,232,188,13,201,99,171,250,123,112,112,78,189,226,185,87,124,177,126,165,236,234,50,221,46,201,48,38,57,70,73,236,147,179,158,89,95,74,228,142,114,116,150,233,127,129,190,115,145,11,243,226,37,143,58,237,216,182,253,47,225,139,124,69,189,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("db4128e4-39dd-4160-97b6-b20928a12b20"));
		}

		#endregion

	}

	#endregion

}

