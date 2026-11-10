namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: ExcelStylesheetTemplateSchema

	/// <exclude/>
	public class ExcelStylesheetTemplateSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ExcelStylesheetTemplateSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ExcelStylesheetTemplateSchema(ExcelStylesheetTemplateSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("962cb08b-b35b-4310-92bb-ae488ec1da3f");
			Name = "ExcelStylesheetTemplate";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("6ba26f98-9709-4408-98d0-761f0c4bf2aa");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,141,144,61,107,195,48,16,134,103,27,252,31,14,178,203,123,27,186,184,41,221,58,196,148,174,87,229,226,8,244,133,238,4,9,33,255,61,182,156,164,94,90,186,8,157,120,222,71,220,235,209,17,71,212,4,61,165,132,28,246,162,186,224,247,102,200,9,197,4,175,54,199,24,146,244,97,115,212,100,155,250,220,212,77,93,101,54,126,128,215,160,179,35,47,111,33,57,20,245,17,201,127,57,171,182,49,17,238,248,64,36,207,133,94,37,26,70,21,116,22,153,159,160,152,182,114,178,84,152,158,92,180,40,84,208,182,109,97,205,217,57,76,167,151,219,92,98,32,7,20,208,193,11,26,207,64,147,3,248,33,1,185,89,212,93,210,46,44,49,127,91,163,65,23,209,175,223,87,227,110,213,157,253,1,150,215,51,12,227,82,192,211,113,89,208,29,89,59,183,0,159,104,51,45,230,127,68,222,199,186,40,253,145,185,204,53,146,223,205,77,78,99,121,187,2,178,57,73,209,191,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("962cb08b-b35b-4310-92bb-ae488ec1da3f"));
		}

		#endregion

	}

	#endregion

}

