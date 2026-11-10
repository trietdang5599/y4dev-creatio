namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: BoolExcelCellWriterSchema

	/// <exclude/>
	public class BoolExcelCellWriterSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public BoolExcelCellWriterSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public BoolExcelCellWriterSchema(BoolExcelCellWriterSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("bb306662-1573-42f1-9db8-66a8d68b57c0");
			Name = "BoolExcelCellWriter";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("6ba26f98-9709-4408-98d0-761f0c4bf2aa");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,141,146,77,111,194,48,12,134,207,69,226,63,88,236,2,210,212,222,199,199,164,33,56,13,52,105,108,59,135,214,99,153,210,184,114,82,216,135,248,239,75,19,58,40,99,108,135,74,117,252,218,126,243,56,90,228,104,10,145,34,44,144,89,24,122,182,241,152,244,179,92,149,44,172,36,29,79,222,10,98,187,160,201,91,138,170,221,250,108,183,162,210,72,189,106,20,228,57,233,126,187,229,114,23,140,43,87,6,99,37,140,185,130,123,203,78,235,107,199,168,212,19,75,139,236,133,73,146,192,192,148,121,46,248,125,180,139,131,26,176,146,131,251,20,108,124,65,92,235,147,131,130,162,92,42,153,66,90,13,130,27,34,117,52,5,126,157,30,125,122,7,123,175,164,141,21,218,58,191,119,44,215,194,98,200,23,33,128,180,202,131,9,230,230,165,156,9,45,86,200,115,199,14,134,208,217,131,112,185,78,255,76,237,130,75,12,158,30,133,42,177,110,16,248,61,88,169,76,124,36,57,219,110,42,148,249,171,223,177,166,110,120,129,58,11,215,111,178,184,99,42,144,173,196,10,134,39,28,242,14,255,64,234,23,116,8,51,74,33,25,121,87,97,5,180,118,4,100,134,240,77,122,74,156,11,251,35,30,142,142,143,226,106,113,127,88,154,161,125,161,204,47,135,44,166,22,179,115,150,106,205,222,85,77,203,15,244,16,186,180,124,117,34,88,87,65,15,170,55,29,69,107,193,176,116,110,188,194,97,236,86,65,47,104,250,94,193,104,75,214,135,162,33,88,183,47,159,140,174,65,227,6,110,41,21,74,126,136,165,218,81,239,54,31,204,229,169,71,208,139,253,111,232,115,245,207,62,167,182,191,107,228,237,110,79,82,13,167,205,195,237,23,113,182,204,32,6,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("bb306662-1573-42f1-9db8-66a8d68b57c0"));
		}

		#endregion

	}

	#endregion

}

