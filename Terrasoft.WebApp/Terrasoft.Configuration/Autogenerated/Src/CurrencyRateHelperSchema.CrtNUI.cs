namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: CurrencyRateHelperSchema

	/// <exclude/>
	public class CurrencyRateHelperSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public CurrencyRateHelperSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public CurrencyRateHelperSchema(CurrencyRateHelperSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("10302f70-95a4-407b-9a13-247da73bf707");
			Name = "CurrencyRateHelper";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("d9c4378b-4458-41ff-9d84-e4b071fcce18");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,173,82,193,110,219,48,12,61,39,64,254,129,240,201,198,60,185,59,55,201,37,67,187,1,235,80,36,193,238,140,75,39,6,100,201,160,164,21,217,144,127,159,36,71,174,59,172,59,21,136,17,136,124,124,143,228,163,51,173,58,194,238,108,44,117,183,139,185,155,60,197,189,212,7,148,237,47,180,173,86,62,185,152,43,236,200,244,88,19,236,137,25,141,110,172,216,104,213,180,71,199,17,181,152,255,94,204,103,189,59,200,182,134,90,162,49,176,113,204,164,234,243,22,45,125,33,217,19,123,68,64,205,170,170,130,165,113,93,135,124,94,167,192,61,89,3,246,68,80,59,11,29,42,219,26,131,160,27,255,30,120,192,43,145,24,235,171,191,9,150,61,50,118,16,90,93,101,1,155,173,131,180,88,86,49,241,130,99,178,142,149,89,111,38,66,203,42,69,3,236,58,135,177,126,182,240,199,97,57,190,193,192,247,112,173,200,159,168,110,59,148,177,173,2,226,96,179,20,107,24,235,176,22,88,197,52,124,132,220,73,173,142,69,120,221,70,232,79,100,240,11,244,8,69,207,240,221,117,7,226,59,205,29,218,175,170,209,87,190,217,16,255,60,208,238,40,76,98,53,251,162,172,204,34,226,50,176,13,221,143,186,98,175,119,177,235,220,75,20,98,75,189,244,230,229,217,77,153,149,144,101,69,44,186,4,103,223,112,99,23,220,24,93,176,250,221,150,63,197,37,254,108,157,150,250,182,89,219,255,57,148,214,238,187,78,76,123,29,244,95,153,84,38,39,147,110,114,173,109,32,15,238,136,61,159,31,145,13,229,9,81,130,246,71,18,114,99,209,15,148,142,138,84,250,47,199,95,33,161,130,212,68,241,128,246,36,30,245,115,254,233,166,28,81,226,27,169,163,61,13,150,120,35,195,185,172,32,66,239,164,214,156,199,251,154,100,63,172,70,177,33,122,153,94,192,120,96,33,234,63,255,251,3,53,140,159,202,235,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("10302f70-95a4-407b-9a13-247da73bf707"));
		}

		#endregion

	}

	#endregion

}

