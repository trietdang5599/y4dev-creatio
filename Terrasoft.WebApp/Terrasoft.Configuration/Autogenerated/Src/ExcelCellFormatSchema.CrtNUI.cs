namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: ExcelCellFormatSchema

	/// <exclude/>
	public class ExcelCellFormatSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ExcelCellFormatSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ExcelCellFormatSchema(ExcelCellFormatSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("5521b4a2-bdcb-488d-b088-5f4a850b95ea");
			Name = "ExcelCellFormat";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("6ba26f98-9709-4408-98d0-761f0c4bf2aa");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,149,146,93,75,195,48,24,133,175,59,216,127,8,120,179,65,105,187,110,126,77,39,232,54,153,32,42,110,138,32,94,100,221,219,46,152,143,154,38,56,149,253,119,147,116,194,80,106,245,162,165,233,123,206,201,195,225,229,152,65,145,227,4,208,12,164,196,133,72,85,48,20,60,37,153,150,88,17,193,131,241,42,23,82,205,196,120,149,0,109,54,62,154,141,102,195,211,5,225,25,26,137,68,51,224,234,92,72,134,85,112,157,3,127,96,52,152,230,18,240,162,88,2,168,35,167,222,145,144,153,40,52,230,154,245,145,11,26,2,165,165,205,41,194,48,68,199,133,102,12,203,183,147,205,217,233,144,121,40,74,157,18,129,241,7,95,234,112,75,158,235,57,37,137,155,255,140,247,12,178,231,61,186,255,87,154,205,65,150,147,86,138,105,1,237,39,59,61,19,130,162,1,234,248,21,82,37,53,248,40,142,58,119,230,221,45,61,35,172,192,120,226,26,143,117,68,62,106,17,174,218,19,33,201,187,224,10,211,83,74,50,110,187,187,199,84,67,17,220,146,108,169,54,185,144,16,134,45,78,183,42,218,145,251,232,69,11,5,55,18,82,178,234,35,123,93,25,48,49,237,131,52,254,222,239,104,157,127,163,93,112,101,98,119,107,176,94,201,66,45,251,168,23,85,18,78,149,180,251,51,64,123,117,133,71,223,10,159,17,102,75,223,255,27,66,220,173,68,184,20,226,89,231,38,234,160,14,33,222,66,216,92,127,104,190,215,229,106,3,95,148,219,109,143,235,79,48,240,16,123,79,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("5521b4a2-bdcb-488d-b088-5f4a850b95ea"));
		}

		#endregion

	}

	#endregion

}

