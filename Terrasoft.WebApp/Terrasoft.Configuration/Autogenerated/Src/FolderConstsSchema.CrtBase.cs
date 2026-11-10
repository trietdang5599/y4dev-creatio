namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: FolderConstsSchema

	/// <exclude/>
	public class FolderConstsSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public FolderConstsSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public FolderConstsSchema(FolderConstsSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("76859cd8-136b-4004-a6d6-9dceeb8425ee");
			Name = "FolderConsts";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("a99d7388-fb0e-4870-87fc-76975bec5847");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,149,208,221,78,131,48,20,7,240,107,72,120,135,147,237,70,47,10,173,200,132,248,145,108,5,22,47,188,114,47,208,65,183,52,129,150,180,16,37,102,239,46,67,198,208,197,68,123,213,143,115,250,255,229,52,70,200,61,188,182,166,230,229,189,99,59,182,100,37,55,21,203,56,108,184,214,204,168,93,237,82,37,119,98,223,104,86,11,37,193,177,63,142,133,150,231,121,240,96,154,178,100,186,125,26,206,243,97,141,155,233,30,190,223,95,20,206,221,211,175,222,228,219,170,217,22,34,3,83,119,233,25,100,5,51,6,82,85,228,92,119,44,83,155,206,99,117,32,235,194,115,2,13,17,128,206,144,4,149,76,20,238,216,53,205,251,17,168,57,203,149,44,90,88,55,34,135,228,216,247,149,190,105,43,254,156,195,35,72,254,214,63,94,205,86,209,221,50,8,253,5,34,52,198,40,33,132,160,8,211,5,194,152,4,65,140,131,91,138,253,217,117,63,230,63,115,207,3,130,113,70,255,68,191,116,230,173,122,255,149,29,69,244,198,15,8,69,41,78,195,129,29,175,150,35,155,132,152,244,108,235,224,216,135,79,252,14,120,19,50,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("76859cd8-136b-4004-a6d6-9dceeb8425ee"));
		}

		#endregion

	}

	#endregion

}

