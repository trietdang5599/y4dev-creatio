namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: TimeExcelCellWriterSchema

	/// <exclude/>
	public class TimeExcelCellWriterSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public TimeExcelCellWriterSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public TimeExcelCellWriterSchema(TimeExcelCellWriterSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("7b9f4301-da1a-457b-8c99-61b188d2ca09");
			Name = "TimeExcelCellWriter";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("ee75749b-5184-4f75-a3ec-dd2e096c705e");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,125,145,177,110,194,48,16,134,231,32,241,14,39,177,192,146,236,64,145,16,208,78,85,145,138,218,217,141,47,224,202,177,163,243,153,130,42,222,189,182,73,210,170,84,29,50,220,175,207,254,63,95,140,168,209,53,162,68,216,33,145,112,182,226,124,101,77,165,246,158,4,43,107,242,205,169,177,196,59,187,57,149,168,135,131,207,225,32,243,78,153,61,60,159,29,99,61,27,14,66,50,34,220,7,24,86,90,56,55,133,157,170,49,241,43,212,250,149,20,35,37,172,40,10,152,59,95,215,130,206,139,118,142,44,96,132,33,124,26,62,18,158,119,116,209,225,89,72,26,255,166,85,9,101,108,249,171,4,166,176,22,124,91,157,69,235,94,114,75,182,65,98,133,193,116,155,110,76,114,177,111,174,204,1,195,33,105,75,40,162,97,87,105,143,97,61,74,34,244,119,223,91,170,5,223,204,119,139,223,81,30,69,175,107,202,70,104,228,213,162,157,91,165,71,228,131,149,209,135,44,99,201,40,255,83,234,152,111,171,248,234,180,200,7,228,165,124,247,225,207,200,46,123,17,218,227,184,39,142,113,156,64,218,72,70,200,158,12,72,172,132,215,220,67,147,124,41,229,56,145,201,254,169,90,139,243,100,22,143,92,110,31,210,102,63,163,203,23,55,223,181,179,88,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("7b9f4301-da1a-457b-8c99-61b188d2ca09"));
		}

		#endregion

	}

	#endregion

}

