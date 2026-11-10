namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: ILlmModelCategoryRepositorySchema

	/// <exclude/>
	public class ILlmModelCategoryRepositorySchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ILlmModelCategoryRepositorySchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ILlmModelCategoryRepositorySchema(ILlmModelCategoryRepositorySchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("54505e0d-2abe-4f16-8644-fe8aec731ba5");
			Name = "ILlmModelCategoryRepository";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("e8ce15e9-1e70-4be4-81f7-3d2e4afa30e7");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,125,206,65,10,194,48,16,5,208,117,2,185,67,192,77,221,244,0,186,210,128,82,208,77,241,2,177,153,196,64,58,41,147,84,40,210,187,27,91,186,117,55,124,254,227,15,234,30,210,160,59,144,15,32,210,41,218,92,171,136,214,187,145,116,246,17,235,43,224,169,17,252,35,184,224,108,71,224,74,40,27,204,64,182,176,131,108,110,161,191,71,3,65,233,12,46,210,212,194,16,147,207,229,90,200,48,62,131,239,164,223,196,127,192,202,14,99,91,163,5,11,4,88,208,197,163,57,79,155,168,82,38,143,78,118,165,180,63,46,51,236,29,189,145,42,128,38,165,187,23,84,191,156,205,235,215,128,102,125,92,240,249,11,96,226,200,178,242,0,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("54505e0d-2abe-4f16-8644-fe8aec731ba5"));
		}

		#endregion

	}

	#endregion

}

