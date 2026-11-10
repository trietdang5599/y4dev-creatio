namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: SentSinceAndDraftsSyncStrategySchema

	/// <exclude/>
	public class SentSinceAndDraftsSyncStrategySchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public SentSinceAndDraftsSyncStrategySchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public SentSinceAndDraftsSyncStrategySchema(SentSinceAndDraftsSyncStrategySchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("b6a52f3c-de2d-4d94-bc45-c093e0898f55");
			Name = "SentSinceAndDraftsSyncStrategy";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("50cc600a-f6aa-433b-8a0a-6a453519907c");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,133,84,77,111,218,64,16,61,19,41,255,97,228,94,64,162,184,103,18,144,26,112,165,72,13,74,101,56,85,61,44,246,216,93,213,222,181,102,199,85,44,196,127,239,248,3,98,40,144,139,229,157,125,51,243,230,189,177,141,202,209,21,42,66,88,35,145,114,54,225,201,139,210,217,253,221,238,254,110,80,58,109,210,222,205,194,154,68,167,37,41,214,214,60,92,4,16,94,139,79,2,195,154,53,186,171,128,111,42,98,75,45,66,48,159,8,83,233,3,139,76,57,55,133,16,13,135,218,68,248,213,196,75,82,9,187,176,50,81,200,194,6,211,170,201,240,125,31,30,93,153,231,138,170,249,241,140,8,17,97,50,243,158,251,9,158,63,7,157,23,25,230,82,87,105,182,102,12,49,102,250,47,18,198,144,144,205,251,169,75,201,121,82,14,227,35,139,179,90,147,67,59,255,188,63,161,28,255,184,195,249,246,24,80,74,15,96,11,14,51,140,24,84,150,129,177,252,89,152,33,203,141,184,229,84,138,110,220,85,115,117,37,1,27,134,88,10,188,179,232,117,253,185,196,68,149,25,63,105,19,139,234,67,174,10,180,201,240,68,141,209,24,86,178,10,48,3,239,54,65,111,244,75,74,22,229,54,211,17,68,181,51,31,77,52,133,219,226,73,185,93,227,222,209,240,87,178,5,18,87,211,250,141,69,6,140,91,192,185,191,157,160,138,162,223,128,111,5,137,56,117,62,163,248,218,169,241,191,41,131,226,80,20,172,152,77,58,22,1,153,234,125,220,24,39,196,94,92,218,214,252,81,34,85,80,127,8,131,65,138,220,189,13,8,185,36,3,222,102,181,12,190,7,235,96,9,97,176,90,135,207,171,69,0,187,47,123,239,161,129,237,235,231,190,27,12,77,220,206,118,58,168,124,79,210,185,172,183,94,22,252,181,17,245,198,164,11,66,153,202,245,247,242,3,179,234,29,151,22,74,0,87,196,104,34,133,34,149,131,145,5,152,121,178,128,36,188,140,40,36,20,189,249,70,206,16,29,3,147,71,191,65,95,78,174,229,11,145,89,196,116,222,188,199,179,254,167,108,237,91,216,191,239,147,235,87,237,150,235,246,104,195,205,9,79,56,165,61,134,230,103,83,65,159,208,168,241,101,10,91,89,197,225,57,254,4,216,58,125,217,188,54,218,15,238,255,1,38,12,143,54,69,5,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("b6a52f3c-de2d-4d94-bc45-c093e0898f55"));
		}

		#endregion

	}

	#endregion

}

