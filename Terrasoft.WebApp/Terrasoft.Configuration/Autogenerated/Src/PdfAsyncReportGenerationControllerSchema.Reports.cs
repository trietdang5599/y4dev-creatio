namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: PdfAsyncReportGenerationControllerSchema

	/// <exclude/>
	public class PdfAsyncReportGenerationControllerSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public PdfAsyncReportGenerationControllerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public PdfAsyncReportGenerationControllerSchema(PdfAsyncReportGenerationControllerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("71fc74a3-8eb1-455a-8bf5-06643861c00c");
			Name = "PdfAsyncReportGenerationController";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("f8ef1a6f-6619-48e3-9227-afa9b7782f83");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,157,82,77,75,195,64,16,61,87,240,63,12,241,162,7,147,171,180,182,80,43,21,15,74,209,122,18,15,235,102,210,46,36,187,235,204,164,16,196,255,238,110,18,75,235,7,138,183,157,229,205,155,55,111,158,85,21,178,87,26,97,137,68,138,93,33,233,204,217,194,172,106,82,98,156,61,60,120,61,60,24,212,108,236,10,238,27,22,172,210,123,164,141,209,120,227,114,44,211,169,22,179,105,145,163,45,110,151,138,48,157,43,45,142,12,114,64,4,204,17,225,42,192,97,86,42,230,33,44,242,98,202,141,213,119,232,29,201,21,90,236,6,7,21,66,174,44,145,98,87,232,123,156,178,191,69,153,185,202,7,192,179,41,141,52,119,248,82,27,194,10,173,240,241,110,17,197,193,24,126,105,137,168,180,255,200,79,158,194,144,44,203,224,156,235,170,82,212,76,250,58,40,35,228,136,7,5,122,43,11,92,1,42,42,95,147,179,174,102,88,92,206,79,169,221,2,86,219,53,128,59,183,210,15,242,108,135,221,215,207,165,209,160,163,19,127,48,2,134,112,161,24,127,181,107,240,218,26,182,117,122,65,206,35,73,184,192,48,190,5,181,96,222,65,90,73,198,174,145,140,228,46,72,33,44,198,201,143,83,250,211,199,136,72,48,100,217,120,76,178,184,201,192,127,240,130,219,132,243,155,96,63,11,197,52,236,96,97,60,129,68,121,31,150,110,233,50,159,23,35,208,107,69,140,50,126,88,206,79,207,146,81,127,238,255,74,219,251,119,244,179,188,235,175,52,142,224,115,29,20,183,65,237,66,220,164,87,40,231,223,118,78,142,147,16,128,228,100,212,123,143,54,239,236,111,235,183,46,250,123,159,111,239,99,50,166,10,125,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("71fc74a3-8eb1-455a-8bf5-06643861c00c"));
		}

		#endregion

	}

	#endregion

}

