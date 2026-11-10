namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: IFullPipelineDataRetrieverSchema

	/// <exclude/>
	public class IFullPipelineDataRetrieverSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IFullPipelineDataRetrieverSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IFullPipelineDataRetrieverSchema(IFullPipelineDataRetrieverSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("bab0b7d8-fd3f-4488-b7c0-eec4053f33c3");
			Name = "IFullPipelineDataRetriever";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("eccc4091-3404-497f-94e5-8c10d0f3a0d7");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,125,146,203,110,194,48,16,69,215,68,202,63,140,210,77,187,137,247,16,178,105,105,197,162,18,162,252,128,73,38,193,146,99,71,99,155,42,66,252,123,141,67,72,74,31,75,207,227,232,222,59,86,188,65,211,242,2,97,135,68,220,232,202,166,207,90,85,162,118,196,173,208,42,142,78,113,52,115,70,168,26,62,58,99,177,241,125,41,177,184,52,77,250,134,10,73,20,139,56,242,83,15,132,181,175,194,90,89,164,202,67,231,176,126,117,82,110,68,139,82,40,124,225,150,111,209,146,192,35,82,216,96,140,65,102,92,211,112,234,242,235,123,67,250,40,74,52,32,6,12,232,10,168,223,227,18,42,79,132,246,138,132,210,51,211,129,196,38,168,214,237,165,40,38,144,255,164,204,78,65,206,205,193,59,218,131,46,205,28,54,129,210,55,239,197,134,194,0,185,9,249,169,164,175,180,156,120,3,202,231,189,76,6,245,43,101,133,237,250,188,77,146,239,14,56,26,195,208,131,98,122,12,147,102,44,112,70,172,207,197,145,50,249,120,148,75,90,153,65,132,130,176,90,38,83,215,91,253,153,176,60,99,195,210,133,178,94,41,215,32,241,189,196,236,110,54,135,105,76,143,127,77,78,93,228,240,171,183,167,197,53,95,84,101,31,113,120,159,251,111,243,173,120,254,2,218,137,64,206,147,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("bab0b7d8-fd3f-4488-b7c0-eec4053f33c3"));
		}

		#endregion

	}

	#endregion

}

