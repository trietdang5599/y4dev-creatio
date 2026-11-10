namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: MLBatchRegressorSchema

	/// <exclude/>
	public class MLBatchRegressorSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public MLBatchRegressorSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public MLBatchRegressorSchema(MLBatchRegressorSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("b141c318-5fc2-4336-be2b-b9cb83f27062");
			Name = "MLBatchRegressor";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("97d940bd-1454-46d7-84c7-92245c2594a8");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,117,146,65,107,131,64,16,133,207,9,228,63,12,246,98,160,232,189,53,57,36,165,16,72,66,40,233,169,244,176,110,70,179,160,187,50,187,82,210,208,255,222,113,181,6,45,57,238,243,205,219,55,159,171,69,137,182,18,18,225,136,68,194,154,204,69,107,163,51,149,215,36,156,50,58,218,109,103,211,235,108,58,169,173,210,249,192,69,248,124,71,143,94,133,116,134,20,90,118,176,231,129,48,231,44,88,23,194,218,39,216,109,87,194,201,243,27,230,132,214,26,242,158,56,142,33,177,117,89,10,186,44,187,115,231,104,70,85,89,21,88,162,118,232,124,47,200,12,113,16,164,77,18,84,132,39,37,125,223,191,168,120,148,149,88,68,81,88,3,146,48,91,4,247,215,141,186,122,251,186,68,82,242,208,70,27,10,32,110,178,62,94,48,19,117,225,86,74,159,120,243,208,93,42,52,89,184,233,166,122,251,252,17,246,12,23,22,220,146,175,176,206,70,183,117,14,100,82,94,231,200,179,243,79,14,173,234,180,80,18,100,195,231,31,30,232,137,141,43,241,228,213,195,187,17,110,110,162,186,249,200,160,15,62,182,117,140,249,122,97,163,149,83,162,80,223,104,65,128,198,47,80,60,47,52,191,7,147,129,59,163,199,214,33,27,247,10,226,101,219,56,234,243,227,241,5,73,37,72,148,160,153,196,34,168,45,18,23,212,232,255,84,176,60,114,126,163,129,236,197,40,137,253,132,15,232,168,140,239,13,223,7,57,48,140,157,51,174,84,88,12,199,114,243,136,39,63,29,46,212,167,150,152,63,183,234,80,100,237,23,205,242,222,10,29,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("b141c318-5fc2-4336-be2b-b9cb83f27062"));
		}

		#endregion

	}

	#endregion

}

