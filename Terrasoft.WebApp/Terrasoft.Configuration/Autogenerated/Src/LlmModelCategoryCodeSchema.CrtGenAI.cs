namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: LlmModelCategoryCodeSchema

	/// <exclude/>
	public class LlmModelCategoryCodeSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public LlmModelCategoryCodeSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public LlmModelCategoryCodeSchema(LlmModelCategoryCodeSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("82790a03-bb19-4a34-ab10-1f3e745033bb");
			Name = "LlmModelCategoryCode";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("e8ce15e9-1e70-4be4-81f7-3d2e4afa30e7");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,125,139,193,10,194,48,16,68,239,129,252,195,210,15,232,15,136,7,137,32,130,189,249,3,107,187,9,129,100,183,36,155,131,136,255,110,164,10,158,28,6,102,6,222,48,102,170,43,206,4,87,42,5,171,120,29,157,176,143,161,21,212,40,60,158,136,15,103,107,30,214,64,215,218,110,41,206,48,39,172,21,46,41,79,178,80,114,168,20,164,220,93,31,27,246,161,127,31,194,85,161,106,137,28,224,72,30,91,82,216,195,176,108,117,216,253,127,76,145,227,27,207,61,191,236,211,154,238,23,198,86,12,128,194,0,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("82790a03-bb19-4a34-ab10-1f3e745033bb"));
		}

		#endregion

	}

	#endregion

}

