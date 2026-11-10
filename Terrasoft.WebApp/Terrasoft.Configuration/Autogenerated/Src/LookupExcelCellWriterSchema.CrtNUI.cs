namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: LookupExcelCellWriterSchema

	/// <exclude/>
	public class LookupExcelCellWriterSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public LookupExcelCellWriterSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public LookupExcelCellWriterSchema(LookupExcelCellWriterSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("434dfe6c-8e8d-4e15-b08d-b3f5add4566b");
			Name = "LookupExcelCellWriter";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("6ba26f98-9709-4408-98d0-761f0c4bf2aa");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,109,144,49,143,194,48,12,133,103,42,245,63,88,186,189,217,11,199,82,193,196,128,4,210,205,33,53,37,34,141,35,39,5,78,136,255,126,105,2,232,238,96,240,240,236,103,191,79,182,178,71,239,164,66,216,34,179,244,180,15,85,67,118,175,187,129,101,208,100,171,197,197,17,135,45,45,46,10,77,89,92,203,162,44,38,31,140,93,28,66,99,164,247,53,172,136,142,131,75,142,6,141,249,98,29,144,147,81,8,1,51,63,244,189,228,239,249,93,103,55,224,104,135,88,6,206,105,161,122,248,197,175,5,55,236,140,86,160,198,160,247,57,80,195,38,176,182,221,75,254,36,195,62,105,215,76,14,57,104,140,200,235,116,55,207,99,232,76,219,3,198,181,150,20,136,49,247,17,76,167,248,23,221,34,60,175,47,137,123,25,94,244,231,252,127,171,202,184,211,59,4,218,54,115,36,125,203,127,252,211,188,253,0,50,191,157,81,142,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("434dfe6c-8e8d-4e15-b08d-b3f5add4566b"));
		}

		#endregion

	}

	#endregion

}

