namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: ExcelCellWriterConfigSchema

	/// <exclude/>
	public class ExcelCellWriterConfigSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ExcelCellWriterConfigSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ExcelCellWriterConfigSchema(ExcelCellWriterConfigSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("346c17cb-c7b3-4b13-89c8-26d13a32c8da");
			Name = "ExcelCellWriterConfig";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("6ba26f98-9709-4408-98d0-761f0c4bf2aa");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,133,208,205,106,195,48,12,0,224,115,11,125,7,193,238,201,101,236,176,142,93,178,22,118,217,96,235,126,174,142,167,6,15,203,10,178,76,91,74,222,125,137,147,142,194,24,61,216,70,248,147,100,43,24,194,216,26,139,176,65,17,19,121,171,69,197,97,235,154,36,70,29,135,98,181,111,89,116,195,171,189,69,191,152,31,23,243,89,138,46,52,240,122,136,138,180,252,141,31,216,38,194,160,107,22,50,90,60,183,24,62,201,247,247,189,184,18,108,250,98,80,121,19,227,45,228,90,21,122,255,33,78,81,198,134,25,150,101,9,119,49,17,25,57,220,79,113,214,208,47,15,187,236,193,230,132,226,228,203,179,132,54,213,222,89,176,67,163,255,250,204,134,79,156,228,244,206,81,192,116,28,161,65,93,66,28,182,238,12,191,61,6,189,185,134,23,222,61,37,170,47,195,138,125,162,112,193,114,253,141,86,225,221,248,132,127,80,55,206,15,195,215,56,194,33,236,126,0,55,38,128,177,182,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("346c17cb-c7b3-4b13-89c8-26d13a32c8da"));
		}

		#endregion

	}

	#endregion

}

