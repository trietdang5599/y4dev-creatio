namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: ISyncStrategySchema

	/// <exclude/>
	public class ISyncStrategySchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ISyncStrategySchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ISyncStrategySchema(ISyncStrategySchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("b771ff15-a14f-4f39-be65-1b31aa728594");
			Name = "ISyncStrategy";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("e0bd8020-de17-4815-83cd-c2dac7bbc324");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,181,82,193,106,195,48,12,61,55,144,127,16,237,101,187,36,151,157,186,174,48,54,54,122,8,116,164,251,0,47,81,83,67,98,103,146,83,22,70,255,125,114,210,134,144,173,199,29,12,178,44,61,189,247,44,163,42,228,90,101,8,59,36,82,108,247,46,74,148,46,195,224,59,12,102,13,107,83,64,218,178,195,234,62,12,36,179,32,44,180,53,176,49,14,105,47,125,75,216,164,173,201,82,71,202,97,209,118,69,113,28,195,138,155,170,82,212,174,207,247,45,217,163,206,145,161,66,119,176,57,195,222,18,20,232,224,179,65,106,193,89,96,84,148,29,252,64,99,29,176,128,98,46,213,204,170,64,142,46,176,241,8,183,110,62,74,157,65,173,200,105,85,130,190,112,154,82,154,121,45,3,245,164,39,176,132,109,215,238,159,252,153,146,238,18,79,132,130,193,103,110,128,95,53,9,33,143,162,197,131,228,113,123,7,165,50,69,35,20,163,1,36,158,162,172,8,93,67,134,135,68,58,133,27,53,143,107,217,145,247,227,21,221,187,241,134,36,92,244,173,111,222,180,155,219,254,79,254,149,186,152,171,42,48,178,38,15,115,217,134,12,159,5,117,190,78,125,8,185,196,112,84,101,131,209,42,238,42,127,107,254,67,236,53,145,47,178,120,246,136,52,145,233,39,238,116,133,48,204,191,8,95,160,201,251,95,149,219,169,95,208,81,42,12,78,63,232,185,99,216,224,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("b771ff15-a14f-4f39-be65-1b31aa728594"));
		}

		#endregion

	}

	#endregion

}

