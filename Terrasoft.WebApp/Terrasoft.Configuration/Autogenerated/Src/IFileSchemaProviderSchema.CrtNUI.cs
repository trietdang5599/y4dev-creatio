namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: IFileSchemaProviderSchema

	/// <exclude/>
	public class IFileSchemaProviderSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IFileSchemaProviderSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IFileSchemaProviderSchema(IFileSchemaProviderSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("c19fcb3d-30cc-4889-b3ff-cadcced57d1c");
			Name = "IFileSchemaProvider";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("ee75749b-5184-4f75-a3ec-dd2e096c705e");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,141,83,219,106,194,64,16,125,174,224,63,12,250,98,161,36,239,154,10,165,180,34,244,34,181,63,176,110,38,102,203,102,87,102,54,21,145,254,123,119,55,209,122,105,139,47,129,185,157,115,230,204,6,140,168,144,87,66,34,188,35,145,96,91,184,228,222,154,66,45,107,18,78,89,211,237,108,187,157,171,154,149,89,194,124,195,14,43,95,215,26,101,40,114,50,65,131,164,228,168,219,241,93,125,194,165,207,194,212,56,164,194,131,14,97,250,96,156,114,155,88,78,211,20,50,174,171,74,208,102,220,198,51,178,159,42,71,6,101,10,75,85,164,4,177,176,181,3,140,147,192,178,196,74,48,8,66,223,84,122,54,135,57,20,100,43,232,61,42,141,220,75,118,216,233,1,248,170,94,104,37,253,68,43,5,166,161,121,30,193,90,82,242,109,219,168,108,175,252,25,93,105,115,30,194,44,142,55,197,83,221,49,241,134,174,38,195,224,74,4,173,216,129,45,64,104,125,129,220,182,229,198,151,165,174,243,96,172,200,115,21,54,23,250,208,135,100,79,158,158,178,103,212,208,143,127,110,17,4,4,130,189,130,128,148,100,233,174,51,140,62,121,161,217,143,15,83,223,49,134,9,186,59,173,155,12,15,174,71,23,44,125,126,172,34,48,31,93,12,214,165,146,37,40,6,66,45,130,9,206,2,175,80,170,66,249,128,80,90,202,143,71,254,91,120,37,72,84,16,158,235,109,175,153,109,20,191,248,76,111,28,190,193,128,112,141,95,145,179,52,2,156,27,248,186,248,240,254,193,90,185,242,175,181,246,16,135,86,30,187,232,157,55,173,160,1,59,10,55,61,21,185,51,182,143,38,111,94,91,140,191,154,63,231,40,233,115,223,51,177,95,189,153,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("c19fcb3d-30cc-4889-b3ff-cadcced57d1c"));
		}

		#endregion

	}

	#endregion

}

