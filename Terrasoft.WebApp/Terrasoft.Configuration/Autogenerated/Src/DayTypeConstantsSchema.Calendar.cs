namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: DayTypeConstantsSchema

	/// <exclude/>
	public class DayTypeConstantsSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public DayTypeConstantsSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public DayTypeConstantsSchema(DayTypeConstantsSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("e4a46baa-a9bf-4def-a556-bd42551ffe45");
			Name = "DayTypeConstants";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,149,143,203,106,195,48,16,69,215,49,248,31,134,116,211,44,84,59,74,44,75,125,129,31,74,233,186,129,174,85,91,9,38,177,108,36,139,98,74,255,189,202,195,193,164,155,118,152,25,152,203,133,115,71,137,90,154,86,20,18,214,82,107,97,154,77,119,151,53,106,83,109,173,22,93,213,40,223,251,242,189,137,53,149,218,194,91,111,58,89,63,248,158,83,130,32,128,71,99,235,90,232,254,249,124,223,12,5,151,61,56,131,145,181,181,31,251,170,0,211,57,64,1,197,94,24,3,185,232,215,125,43,29,218,201,170,51,206,118,224,254,194,12,156,195,220,195,24,119,113,143,81,87,172,23,91,149,240,222,232,157,195,189,150,240,4,74,126,30,197,219,41,15,51,66,72,146,163,36,98,28,45,9,142,16,101,156,160,136,135,233,42,142,242,36,199,201,116,118,250,253,111,169,254,27,75,202,29,87,229,85,172,48,166,25,75,231,28,177,197,28,163,229,130,175,80,74,89,136,120,132,25,205,83,130,41,142,143,177,38,223,190,231,250,7,178,165,4,152,208,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("e4a46baa-a9bf-4def-a556-bd42551ffe45"));
		}

		#endregion

	}

	#endregion

}

