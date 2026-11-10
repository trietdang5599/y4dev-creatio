namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: DateTimeExcelCellWriterSchema

	/// <exclude/>
	public class DateTimeExcelCellWriterSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public DateTimeExcelCellWriterSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public DateTimeExcelCellWriterSchema(DateTimeExcelCellWriterSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("2cb26043-42ca-4c84-9e87-fb66c4e44a45");
			Name = "DateTimeExcelCellWriter";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("6ba26f98-9709-4408-98d0-761f0c4bf2aa");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,125,145,205,78,195,48,16,132,207,169,148,119,88,169,23,184,36,119,90,42,161,80,56,33,85,34,130,179,137,183,173,145,99,71,235,117,105,133,250,238,216,249,163,34,42,7,31,118,52,227,249,188,54,162,70,215,136,10,161,68,34,225,236,150,179,194,154,173,218,121,18,172,172,201,214,199,198,18,151,118,125,172,80,167,179,239,116,150,120,167,204,14,94,79,142,177,94,164,179,160,204,9,119,193,12,133,22,206,221,193,163,96,44,85,141,109,166,64,173,223,73,49,82,107,205,243,28,150,206,215,181,160,211,170,159,7,63,96,12,64,56,26,190,218,72,54,36,242,139,72,227,63,180,170,160,138,101,215,186,160,163,152,16,36,241,1,35,239,134,108,131,196,10,3,244,166,189,181,101,140,149,75,101,246,24,66,210,86,144,199,214,161,214,30,194,166,148,68,24,239,126,178,84,11,158,204,247,171,191,82,54,192,118,91,75,230,104,100,71,210,207,61,214,11,242,222,202,200,68,150,177,98,148,255,97,13,158,95,178,113,159,207,200,15,242,211,135,143,146,131,246,38,180,199,155,209,113,136,227,45,180,91,73,8,217,147,233,180,69,84,206,83,206,94,187,148,206,63,231,246,167,225,70,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("2cb26043-42ca-4c84-9e87-fb66c4e44a45"));
		}

		#endregion

	}

	#endregion

}

