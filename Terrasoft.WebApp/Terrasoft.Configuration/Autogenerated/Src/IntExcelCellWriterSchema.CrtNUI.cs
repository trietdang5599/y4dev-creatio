namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: IntExcelCellWriterSchema

	/// <exclude/>
	public class IntExcelCellWriterSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IntExcelCellWriterSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IntExcelCellWriterSchema(IntExcelCellWriterSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("61d5eba2-33cc-431f-aed3-08714edf99a5");
			Name = "IntExcelCellWriter";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("6ba26f98-9709-4408-98d0-761f0c4bf2aa");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,125,144,79,79,195,48,12,197,207,155,212,239,96,137,75,123,105,239,251,119,96,12,137,3,210,36,42,56,103,169,215,5,165,113,229,164,99,104,218,119,39,73,183,194,6,226,16,41,182,223,243,251,37,70,52,104,91,33,17,74,100,22,150,182,46,95,146,217,170,186,99,225,20,153,124,117,104,137,93,73,171,131,68,157,140,143,201,56,25,143,238,24,107,63,132,165,22,214,78,224,1,165,106,132,142,146,37,106,253,72,220,8,231,144,163,184,40,10,152,217,174,105,4,127,46,206,245,147,113,88,35,3,6,11,248,163,225,131,149,119,228,23,67,241,195,209,118,27,173,36,200,144,22,172,67,208,91,244,192,4,238,133,197,155,174,247,245,176,3,237,154,169,69,118,10,61,242,58,174,236,231,62,111,166,204,14,189,173,34,9,69,136,188,100,210,222,255,139,170,16,110,30,247,171,158,47,110,91,185,39,157,158,9,208,84,61,196,53,209,51,186,29,85,1,135,201,161,116,88,253,71,116,209,124,67,89,199,202,212,208,231,189,10,221,97,74,155,119,47,130,125,40,50,56,6,227,104,47,24,148,233,5,48,135,212,223,179,40,152,198,49,163,235,216,12,138,188,164,151,184,55,205,226,252,244,231,27,250,238,117,243,244,5,132,121,189,255,79,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("61d5eba2-33cc-431f-aed3-08714edf99a5"));
		}

		#endregion

	}

	#endregion

}

