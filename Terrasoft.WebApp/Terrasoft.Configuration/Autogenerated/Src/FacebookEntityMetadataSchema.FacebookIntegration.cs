namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: FacebookEntityMetadataSchema

	/// <exclude/>
	public class FacebookEntityMetadataSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public FacebookEntityMetadataSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public FacebookEntityMetadataSchema(FacebookEntityMetadataSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("e3e1645a-bfb9-4c64-806f-498f877105d0");
			Name = "FacebookEntityMetadata";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("eff9ab8e-fb1d-46f5-bbeb-f2b4e8220404");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,133,81,193,106,195,48,12,61,167,208,127,48,237,165,131,145,15,88,217,97,116,235,97,144,17,150,222,70,15,74,162,4,179,196,54,178,114,200,74,255,125,138,147,118,172,16,122,147,222,211,123,122,150,13,180,232,29,20,168,14,72,4,222,86,28,239,172,169,116,221,17,176,182,38,206,108,161,161,89,46,78,203,69,212,121,109,106,149,245,158,177,221,222,244,241,103,103,88,183,24,103,72,34,208,63,65,254,55,181,151,37,185,181,223,130,8,182,38,172,133,86,187,6,188,127,186,146,111,98,193,125,130,12,37,48,132,201,175,87,169,36,18,19,20,124,20,192,117,121,163,11,85,12,202,25,161,186,117,20,217,41,184,93,23,167,100,29,18,107,148,237,105,112,28,249,176,46,193,54,71,218,124,200,113,212,179,90,85,26,155,210,175,30,142,97,224,226,156,128,115,242,176,205,133,126,84,41,16,26,30,20,237,20,100,210,76,145,223,189,53,47,114,229,94,237,131,68,13,55,141,162,26,121,27,10,63,21,231,249,40,220,59,156,13,18,200,251,49,60,211,240,33,7,153,190,147,96,141,166,28,239,21,250,17,253,15,158,127,1,97,90,83,250,66,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("e3e1645a-bfb9-4c64-806f-498f877105d0"));
		}

		#endregion

	}

	#endregion

}

