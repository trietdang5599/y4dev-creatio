namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: SysProcessElementDataOwnerInfoSchema

	/// <exclude/>
	public class SysProcessElementDataOwnerInfoSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public SysProcessElementDataOwnerInfoSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public SysProcessElementDataOwnerInfoSchema(SysProcessElementDataOwnerInfoSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("6f11982c-9819-47d8-bc8d-e74e12e283ba");
			Name = "SysProcessElementDataOwnerInfo";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,165,145,77,106,195,48,16,133,215,54,248,14,3,217,219,251,166,116,147,134,226,77,19,72,47,160,90,35,87,96,73,70,35,97,140,201,221,171,159,36,152,82,154,210,110,132,53,243,244,222,55,99,205,20,210,200,58,132,55,180,150,145,17,174,222,25,45,100,239,45,115,210,232,170,92,170,178,240,36,117,15,167,153,28,170,109,85,134,202,198,98,31,218,176,27,24,209,67,108,29,173,233,144,104,63,160,66,237,158,153,99,135,73,163,109,181,48,233,69,211,52,240,72,94,41,102,231,167,203,253,228,140,69,2,25,52,86,165,60,208,24,93,130,6,156,129,238,131,233,30,193,68,35,48,2,198,156,1,152,67,128,135,148,250,234,221,172,204,71,255,62,200,14,186,72,119,23,174,88,18,224,109,166,32,30,209,58,137,97,176,99,50,202,253,175,19,164,66,203,131,161,20,50,3,198,111,55,215,55,245,154,233,10,245,226,37,135,125,18,182,28,22,232,209,109,129,226,113,190,147,35,164,187,228,152,129,127,187,140,188,170,95,228,31,6,158,55,240,87,2,141,211,255,8,94,113,250,129,96,131,154,231,223,145,238,185,186,46,22,85,121,254,4,170,181,65,161,190,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("6f11982c-9819-47d8-bc8d-e74e12e283ba"));
		}

		#endregion

	}

	#endregion

}

