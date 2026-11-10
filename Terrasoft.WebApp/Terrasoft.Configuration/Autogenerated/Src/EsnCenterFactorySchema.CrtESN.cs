namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: EsnCenterFactorySchema

	/// <exclude/>
	public class EsnCenterFactorySchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public EsnCenterFactorySchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public EsnCenterFactorySchema(EsnCenterFactorySchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("04389b5a-20dc-4773-ad27-ab521c1b58a1");
			Name = "EsnCenterFactory";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("b66b5ae8-46e0-4931-ad78-c2c1ba5fd6ea");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,149,148,193,78,227,48,16,134,207,69,226,29,172,114,73,164,42,189,83,168,4,161,69,149,0,173,150,229,132,56,152,100,18,44,130,93,141,237,221,173,86,188,251,142,227,54,169,211,150,134,156,226,223,51,159,199,227,223,150,252,3,244,146,103,192,126,1,34,215,170,48,73,170,100,33,74,139,220,8,37,147,217,227,195,233,201,191,211,147,129,213,66,150,44,85,8,147,96,148,204,121,102,20,10,208,164,211,204,25,66,73,137,140,165,21,215,250,156,205,180,76,65,26,64,31,183,170,131,198,227,49,187,16,242,13,80,152,92,101,108,60,37,241,249,6,10,110,43,115,45,100,78,244,200,172,150,160,138,104,209,37,196,241,11,69,47,237,107,37,50,150,185,85,118,22,97,231,108,39,141,114,220,62,154,2,239,193,188,169,156,42,252,81,147,234,186,246,23,182,89,171,69,178,20,129,27,104,198,209,147,6,164,198,73,200,92,215,152,13,134,49,171,23,30,252,230,216,153,185,194,210,126,16,129,93,50,9,127,168,159,82,27,180,174,220,205,76,52,12,51,134,163,46,124,210,176,43,241,14,63,97,169,180,168,123,112,233,143,96,189,253,228,22,204,133,219,193,93,16,53,141,246,87,180,133,45,68,213,3,59,15,162,122,96,65,203,123,208,154,151,148,198,115,234,233,1,112,16,244,77,110,94,179,142,146,125,88,63,246,35,100,150,204,177,154,201,82,72,56,132,14,163,122,144,43,85,210,188,129,191,27,47,184,147,106,53,111,160,250,35,117,38,249,107,5,57,69,134,92,183,252,66,207,201,154,22,97,29,20,13,27,151,82,102,9,184,214,135,241,168,101,58,251,46,246,240,82,139,72,169,110,58,89,228,157,132,7,122,60,190,78,113,17,109,206,231,100,243,143,64,5,202,221,206,53,149,78,163,131,215,1,186,14,166,27,17,26,127,123,99,131,175,56,129,179,8,211,149,190,15,242,70,234,160,188,216,27,22,90,199,179,66,173,31,42,188,182,196,9,133,126,144,99,143,79,47,72,235,109,119,86,205,32,246,246,255,244,47,239,25,200,220,191,204,52,242,218,182,68,202,127,244,73,161,56,173,6,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("04389b5a-20dc-4773-ad27-ab521c1b58a1"));
		}

		#endregion

	}

	#endregion

}

