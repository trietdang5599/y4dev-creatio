namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: MergeableColumnSchema

	/// <exclude/>
	public class MergeableColumnSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public MergeableColumnSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public MergeableColumnSchema(MergeableColumnSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("130e3881-b742-42e2-8cd7-66092d66a439");
			Name = "MergeableColumn";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,141,78,49,14,194,48,12,156,27,41,127,200,11,248,64,39,212,5,6,88,224,3,78,235,70,145,146,184,138,19,85,21,234,223,73,10,12,72,128,24,108,157,125,119,62,103,182,193,168,203,194,9,125,43,69,222,198,43,198,8,76,99,218,117,228,61,133,143,68,196,178,150,34,128,71,158,160,199,55,50,140,214,228,8,201,82,144,226,38,69,51,101,237,108,175,122,7,204,234,132,209,32,104,135,29,185,236,139,162,169,146,151,134,83,172,89,15,174,131,169,30,81,155,160,49,152,218,13,240,19,172,181,125,243,158,203,107,255,26,53,145,83,71,222,187,25,22,62,216,97,192,159,153,165,214,59,203,55,130,245,59,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("130e3881-b742-42e2-8cd7-66092d66a439"));
		}

		#endregion

	}

	#endregion

}

