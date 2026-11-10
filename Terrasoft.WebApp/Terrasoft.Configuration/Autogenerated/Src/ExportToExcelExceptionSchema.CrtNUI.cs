namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: ExportToExcelExceptionSchema

	/// <exclude/>
	public class ExportToExcelExceptionSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ExportToExcelExceptionSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ExportToExcelExceptionSchema(ExportToExcelExceptionSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("091dd986-6c16-40af-a793-56676e4cbe11");
			Name = "ExportToExcelException";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("6ba26f98-9709-4408-98d0-761f0c4bf2aa");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,109,143,193,10,131,48,16,68,207,10,254,195,226,73,65,66,207,45,61,149,22,122,232,169,254,64,76,87,9,104,34,217,8,22,241,223,155,196,86,17,122,89,54,203,204,155,137,226,29,82,207,5,66,137,198,112,210,181,101,23,173,106,217,12,134,91,169,21,187,142,189,54,182,212,215,81,96,155,196,83,18,71,3,73,213,192,243,77,22,187,83,18,187,75,63,84,173,20,32,90,78,4,59,135,31,189,7,193,17,214,221,57,60,103,181,105,69,22,200,26,143,125,32,17,111,240,166,77,199,45,156,33,221,8,175,33,40,48,240,193,106,183,185,4,6,119,165,208,132,199,162,155,14,115,186,244,250,37,252,175,148,109,104,28,115,87,176,226,132,217,210,131,45,5,178,93,157,194,233,216,247,146,23,158,31,121,99,248,203,236,198,236,67,231,15,120,46,164,241,84,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("091dd986-6c16-40af-a793-56676e4cbe11"));
		}

		#endregion

	}

	#endregion

}

