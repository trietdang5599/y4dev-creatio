namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: SectionUITypeConstsSchema

	/// <exclude/>
	public class SectionUITypeConstsSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public SectionUITypeConstsSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public SectionUITypeConstsSchema(SectionUITypeConstsSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("89ad3885-a9d9-42f8-a623-9e90d811b540");
			Name = "SectionUITypeConsts";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("d699061b-815e-49b9-8730-21a5e5db2044");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,165,210,203,106,194,64,20,6,224,181,130,239,112,176,155,118,145,171,49,151,218,22,140,53,197,157,160,62,192,152,140,50,197,76,100,206,100,33,210,119,239,201,68,69,165,165,139,174,194,185,204,63,31,67,36,43,57,238,89,206,97,201,149,98,88,109,180,61,169,228,70,108,107,197,180,168,100,175,123,236,117,59,53,10,185,133,197,1,53,47,71,189,46,117,30,20,223,210,24,38,59,134,248,12,11,158,55,219,171,217,242,176,231,20,128,26,205,154,227,56,240,130,117,89,50,117,120,59,213,52,214,76,72,132,188,217,99,82,35,108,42,117,27,1,213,250,147,106,251,28,225,92,101,236,235,245,78,228,64,71,53,125,242,6,240,243,253,157,163,49,92,172,153,224,187,130,176,115,19,208,206,238,129,166,145,41,206,139,170,132,90,0,182,193,160,27,148,40,236,203,153,107,209,29,233,163,22,197,57,99,37,206,52,209,208,102,5,188,154,185,61,103,10,249,99,63,117,189,48,10,211,192,74,130,65,108,5,113,226,91,227,169,31,91,89,50,12,189,193,32,155,190,71,110,255,105,244,43,213,188,63,221,249,31,234,41,227,47,170,239,79,18,55,8,18,139,188,33,81,27,116,234,198,150,71,68,47,141,198,195,200,243,12,213,188,57,151,69,251,236,166,254,106,127,154,155,38,245,190,1,69,254,215,133,127,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("89ad3885-a9d9-42f8-a623-9e90d811b540"));
		}

		#endregion

	}

	#endregion

}

