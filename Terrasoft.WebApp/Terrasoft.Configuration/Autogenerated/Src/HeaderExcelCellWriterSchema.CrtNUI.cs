namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: HeaderExcelCellWriterSchema

	/// <exclude/>
	public class HeaderExcelCellWriterSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public HeaderExcelCellWriterSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public HeaderExcelCellWriterSchema(HeaderExcelCellWriterSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("881c36f8-3731-4978-a3c3-2634f94cdae3");
			Name = "HeaderExcelCellWriter";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("6ba26f98-9709-4408-98d0-761f0c4bf2aa");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,109,144,203,10,194,48,16,69,215,22,250,15,3,238,155,189,175,77,81,92,10,10,174,99,58,214,64,154,41,147,84,43,197,127,55,77,85,124,65,18,152,153,123,231,30,98,101,133,174,150,10,97,135,204,210,209,209,103,57,217,163,46,27,150,94,147,205,150,109,77,236,119,180,108,21,154,52,233,210,100,20,206,152,177,12,83,200,141,116,110,2,107,148,5,114,148,228,104,204,158,181,71,78,147,32,20,66,192,204,53,85,37,249,186,120,212,131,26,176,151,67,184,6,46,209,144,61,245,226,205,80,55,7,163,21,168,62,232,127,14,76,96,235,89,219,242,39,127,212,69,134,23,237,134,169,70,246,26,3,242,38,238,29,230,33,116,166,237,9,131,173,32,5,162,207,125,6,211,57,124,140,46,16,94,219,87,196,149,244,63,245,124,241,221,202,6,220,233,3,2,109,49,112,196,250,22,223,207,230,237,14,71,10,163,48,143,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("881c36f8-3731-4978-a3c3-2634f94cdae3"));
		}

		#endregion

	}

	#endregion

}

