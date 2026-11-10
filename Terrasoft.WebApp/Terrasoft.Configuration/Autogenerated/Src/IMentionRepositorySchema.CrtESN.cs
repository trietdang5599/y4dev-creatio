namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: IMentionRepositorySchema

	/// <exclude/>
	public class IMentionRepositorySchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IMentionRepositorySchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IMentionRepositorySchema(IMentionRepositorySchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("4e27ff36-28e0-a0f4-308c-766147bea603");
			Name = "IMentionRepository";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("f0db0304-dc6c-40c0-a3bb-97ab97632500");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,109,82,77,79,131,64,16,61,183,137,255,97,66,47,154,24,184,87,36,81,99,12,7,147,218,242,7,182,116,104,81,216,197,153,37,134,52,253,239,206,178,133,86,226,113,223,190,121,239,205,135,86,53,114,163,114,132,12,137,20,155,194,134,47,70,23,229,190,37,101,75,163,111,230,199,155,249,172,229,82,239,97,211,177,197,58,204,14,132,106,39,64,152,41,254,226,135,241,255,34,241,86,153,173,170,54,168,40,63,132,169,182,72,133,120,56,170,144,23,132,123,81,134,17,95,66,250,186,121,71,237,252,62,90,164,238,185,45,171,29,82,207,142,162,8,98,110,235,90,81,151,156,223,103,46,16,54,134,75,107,168,131,114,16,187,119,40,33,11,5,158,86,41,20,134,96,143,214,186,128,102,251,137,185,229,30,171,189,70,56,88,68,87,30,77,187,173,202,252,162,9,233,217,113,61,26,10,235,216,231,27,219,121,71,123,48,59,94,194,170,175,246,159,211,244,61,240,134,22,170,146,45,152,2,50,113,97,171,180,76,7,10,50,53,96,165,216,138,57,251,225,141,34,209,84,37,182,93,131,141,34,85,131,150,45,62,6,89,144,100,2,57,85,223,168,239,83,53,110,85,113,52,210,47,10,215,213,223,110,240,65,18,51,34,228,132,197,99,240,234,147,244,27,9,162,100,12,42,90,19,29,66,219,146,230,127,138,215,114,93,70,51,78,234,135,2,167,224,142,40,246,167,50,176,227,44,73,220,148,158,184,211,185,60,110,135,111,9,41,99,235,163,222,193,207,1,73,238,22,150,144,139,217,249,184,102,11,212,59,191,17,247,22,228,228,143,238,15,124,250,5,108,130,137,47,248,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("4e27ff36-28e0-a0f4-308c-766147bea603"));
		}

		#endregion

	}

	#endregion

}

