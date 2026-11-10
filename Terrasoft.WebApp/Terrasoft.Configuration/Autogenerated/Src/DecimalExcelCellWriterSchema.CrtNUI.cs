namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: DecimalExcelCellWriterSchema

	/// <exclude/>
	public class DecimalExcelCellWriterSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public DecimalExcelCellWriterSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public DecimalExcelCellWriterSchema(DecimalExcelCellWriterSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("11e09c36-5811-41ad-acea-44711f05f95b");
			Name = "DecimalExcelCellWriter";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("6ba26f98-9709-4408-98d0-761f0c4bf2aa");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,133,83,77,79,195,48,12,61,23,137,255,96,193,101,187,180,119,6,28,24,31,226,192,135,180,9,184,102,173,59,130,242,81,57,233,24,160,253,119,220,164,171,70,203,224,80,41,118,252,236,247,94,92,35,52,186,74,228,8,115,36,18,206,150,62,157,90,83,202,101,77,194,75,107,210,171,117,101,201,207,237,213,58,71,117,120,240,117,120,144,212,78,154,37,204,62,156,71,61,233,197,233,141,178,11,161,228,103,64,243,45,223,31,19,46,57,128,169,18,206,157,192,37,230,82,11,21,26,78,81,169,107,75,90,120,143,20,138,179,44,131,83,87,107,45,232,227,188,141,91,4,96,3,1,254,20,188,147,100,68,186,5,100,59,136,170,94,40,153,67,222,76,27,12,123,14,56,56,129,11,225,176,151,101,108,35,175,227,251,72,182,66,242,18,153,52,159,61,230,30,139,64,114,192,178,73,36,15,21,26,88,107,5,174,226,169,37,115,48,181,94,240,180,50,40,4,105,74,155,118,232,93,202,73,181,109,15,247,1,18,61,185,101,0,52,93,95,180,26,228,191,96,137,126,2,155,72,232,24,77,17,105,183,241,111,26,130,49,157,128,83,105,94,145,133,23,54,135,44,178,136,206,217,21,239,130,44,16,122,79,52,136,207,206,251,169,180,245,123,242,55,43,94,49,231,169,206,189,165,30,175,150,194,239,207,54,26,67,120,160,100,159,39,103,96,240,125,104,97,4,37,49,223,182,158,97,37,120,197,45,49,232,40,61,10,21,155,102,155,147,127,28,189,67,255,106,139,221,149,128,191,44,237,138,58,87,89,121,243,191,68,126,79,66,213,56,178,139,55,46,130,85,19,108,53,174,4,65,17,185,134,34,230,201,182,113,19,159,206,109,43,98,20,17,129,118,66,232,107,50,63,48,92,57,11,211,70,123,28,27,239,83,220,230,118,83,155,111,110,83,53,82,45,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("11e09c36-5811-41ad-acea-44711f05f95b"));
		}

		#endregion

	}

	#endregion

}

