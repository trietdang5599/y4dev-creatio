namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: MatchesFoundUtilitiesSchema

	/// <exclude/>
	public class MatchesFoundUtilitiesSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public MatchesFoundUtilitiesSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public MatchesFoundUtilitiesSchema(MatchesFoundUtilitiesSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("e78d9172-c1ff-4b6b-b8de-32a4d56c58f1");
			Name = "MatchesFoundUtilities";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,149,83,193,78,195,48,12,61,183,210,254,33,210,238,124,0,59,65,209,16,18,133,73,29,39,196,33,77,220,98,41,77,42,199,61,140,137,127,39,77,202,96,32,68,123,115,94,252,252,158,29,199,202,14,124,47,21,136,61,16,73,239,26,190,40,156,109,176,29,72,50,58,187,202,143,171,124,149,103,131,71,219,138,234,224,25,186,77,68,214,4,109,72,16,133,145,222,95,138,82,178,122,5,191,117,131,213,241,254,185,2,66,105,240,77,214,6,94,2,208,15,181,65,37,212,152,255,35,61,75,34,167,154,59,114,61,16,35,132,194,187,72,75,247,83,137,219,1,181,184,211,199,17,202,90,224,77,12,252,20,188,159,229,222,72,134,61,118,32,10,130,16,234,71,59,139,22,37,38,202,245,97,166,150,103,26,167,116,162,61,132,233,46,51,89,58,141,13,46,115,249,201,89,106,243,139,55,219,39,90,30,223,70,129,247,247,24,86,193,2,249,191,137,89,246,91,180,114,42,44,197,149,82,225,225,121,126,143,137,86,130,70,185,172,201,111,196,217,93,214,206,25,81,1,111,29,133,191,192,82,205,51,58,41,166,125,13,83,106,208,192,19,153,229,110,255,235,112,13,86,167,143,18,207,9,61,7,3,246,1,24,83,228,51,219,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("e78d9172-c1ff-4b6b-b8de-32a4d56c58f1"));
		}

		#endregion

	}

	#endregion

}

