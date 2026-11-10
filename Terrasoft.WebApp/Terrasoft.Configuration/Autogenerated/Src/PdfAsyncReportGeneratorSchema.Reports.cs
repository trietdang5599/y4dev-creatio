namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: PdfAsyncReportGeneratorSchema

	/// <exclude/>
	public class PdfAsyncReportGeneratorSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public PdfAsyncReportGeneratorSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public PdfAsyncReportGeneratorSchema(PdfAsyncReportGeneratorSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("e562fee6-cd50-43d6-8ac4-36911be07fee");
			Name = "PdfAsyncReportGenerator";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("f8ef1a6f-6619-48e3-9227-afa9b7782f83");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,173,84,77,107,219,64,16,61,59,144,255,48,168,23,25,194,250,30,199,134,196,174,67,14,45,166,73,233,161,148,178,149,70,246,130,188,43,102,71,110,76,232,127,239,172,86,9,150,145,157,166,237,205,154,157,247,222,188,249,176,213,27,244,149,206,16,30,144,72,123,87,176,154,57,91,152,85,77,154,141,179,231,103,79,231,103,131,218,27,187,130,133,41,81,30,183,72,140,20,62,222,63,50,90,47,89,48,233,62,170,89,105,208,178,10,193,241,11,126,95,130,142,198,213,66,103,236,200,160,239,207,216,43,78,125,194,202,17,223,35,109,77,22,8,5,240,142,112,21,42,154,149,218,251,75,88,230,197,181,223,217,44,102,222,162,69,129,58,106,82,71,163,17,92,249,122,179,209,180,155,182,223,146,71,232,165,118,15,26,168,1,193,234,25,5,198,2,175,17,150,243,5,20,142,54,154,213,51,205,104,143,231,235,28,11,93,151,124,99,108,46,213,167,188,171,208,21,233,93,95,33,195,11,248,40,51,144,6,38,194,154,12,191,9,190,170,127,148,38,131,44,56,56,102,0,46,225,70,123,236,247,54,120,106,252,189,244,98,97,176,204,67,51,200,108,53,99,124,172,226,135,152,212,185,179,229,14,238,14,37,190,255,116,148,31,4,199,45,51,218,60,146,119,149,100,60,158,169,14,3,12,122,141,145,86,46,154,58,98,39,29,66,216,179,193,160,79,83,154,211,76,51,46,198,78,221,34,95,29,22,59,77,147,47,130,76,134,97,105,6,191,78,87,185,36,87,201,158,202,138,133,158,56,198,140,49,143,41,205,48,141,93,35,25,206,157,12,129,176,152,36,199,90,173,238,93,77,25,118,110,33,25,77,99,123,91,94,112,114,19,100,114,60,113,63,170,123,77,61,172,48,153,254,49,94,205,93,246,56,254,43,63,15,154,86,200,255,219,79,15,235,155,252,200,210,188,178,119,31,144,215,46,255,231,113,46,229,226,53,97,12,167,159,61,146,212,103,133,79,52,46,224,32,187,243,87,52,60,222,166,8,155,107,214,112,138,31,234,55,200,65,214,17,111,143,135,144,107,178,189,119,171,218,95,152,30,202,116,153,78,156,79,140,118,131,18,251,13,18,51,229,153,67,6,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("e562fee6-cd50-43d6-8ac4-36911be07fee"));
		}

		#endregion

	}

	#endregion

}

