namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: ReportGenerationResultSchema

	/// <exclude/>
	public class ReportGenerationResultSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ReportGenerationResultSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ReportGenerationResultSchema(ReportGenerationResultSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("0ee0c217-8753-49b8-84d4-5d609fc7ae8a");
			Name = "ReportGenerationResult";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("f8ef1a6f-6619-48e3-9227-afa9b7782f83");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,157,144,193,106,195,48,16,68,207,10,228,31,22,114,113,160,228,3,98,114,202,161,244,208,54,216,189,133,28,100,119,227,10,108,201,172,214,20,215,228,223,43,91,162,181,76,122,233,209,163,153,183,227,209,178,65,219,202,18,225,13,137,164,53,87,222,29,141,190,170,170,35,201,202,232,245,106,88,175,68,103,149,174,32,239,45,99,147,46,190,119,79,175,78,114,226,134,176,114,9,56,214,210,218,61,100,216,26,226,71,212,232,73,25,218,174,230,201,121,206,145,148,172,213,151,44,106,188,56,161,237,138,90,149,80,142,201,63,131,98,152,194,191,119,140,182,76,93,201,134,220,185,211,132,240,142,128,187,15,74,92,104,108,79,211,235,139,27,224,1,138,158,241,124,9,146,227,50,106,222,142,36,177,7,254,80,54,153,155,53,126,194,51,54,134,250,156,9,101,147,196,177,45,140,139,137,219,63,171,120,230,162,138,71,138,236,199,7,135,89,40,157,61,134,248,33,6,164,179,70,27,212,239,126,193,120,206,19,153,22,137,21,222,31,51,84,157,85,24,160,66,78,33,254,209,112,63,42,19,27,23,247,189,26,139,183,111,252,52,166,218,151,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("0ee0c217-8753-49b8-84d4-5d609fc7ae8a"));
		}

		#endregion

	}

	#endregion

}

