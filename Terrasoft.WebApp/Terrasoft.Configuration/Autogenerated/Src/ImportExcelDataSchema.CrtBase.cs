namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: ImportExcelDataSchema

	/// <exclude/>
	public class ImportExcelDataSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ImportExcelDataSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ImportExcelDataSchema(ImportExcelDataSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("f0c56b32-3373-4f0c-9885-a983759de99d");
			Name = "ImportExcelData";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("380e5823-e58a-46ec-aacb-19be835fa110");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,141,146,93,107,131,48,20,134,175,45,236,63,28,218,155,237,70,239,117,219,141,43,67,232,74,161,221,245,72,245,52,132,197,68,146,56,42,165,255,125,249,80,177,29,91,39,24,207,73,222,188,57,231,49,130,212,168,27,82,34,236,80,41,162,229,193,196,185,20,7,70,91,69,12,147,34,46,234,70,42,179,60,150,200,95,136,33,119,179,211,221,44,106,53,19,20,182,157,54,88,103,99,78,185,220,19,158,166,185,172,107,187,115,37,41,181,211,118,221,42,22,10,169,181,131,156,19,173,83,8,174,185,228,109,45,182,104,172,204,171,146,36,129,71,221,214,53,81,221,115,159,47,250,103,12,166,9,140,159,113,198,151,26,15,102,201,196,173,105,247,156,149,80,186,18,130,44,20,16,26,182,2,215,218,160,98,194,64,33,42,60,194,9,40,154,12,180,27,206,19,133,54,202,117,157,147,198,129,186,37,91,10,195,76,23,14,92,91,234,191,234,247,82,114,40,244,74,202,207,182,217,117,205,13,229,26,177,10,52,127,232,206,129,60,138,234,95,240,175,126,145,7,244,110,24,103,134,161,246,138,177,35,123,53,46,56,142,50,24,40,14,102,27,37,27,84,110,41,133,141,223,238,157,162,70,177,47,98,112,240,82,72,42,41,120,7,133,189,53,240,193,237,240,4,54,124,35,130,80,84,241,43,26,119,157,80,221,207,253,129,243,135,172,247,185,40,201,239,118,175,175,33,178,56,250,40,82,104,90,37,188,115,230,103,60,200,64,104,130,232,15,106,215,60,206,223,225,87,52,18,60,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("f0c56b32-3373-4f0c-9885-a983759de99d"));
		}

		#endregion

	}

	#endregion

}

