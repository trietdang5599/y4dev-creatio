namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: RelationshipDiagramConfigProviderSchema

	/// <exclude/>
	public class RelationshipDiagramConfigProviderSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public RelationshipDiagramConfigProviderSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public RelationshipDiagramConfigProviderSchema(RelationshipDiagramConfigProviderSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("dd23d878-8d9c-8ece-5b7d-37cf027c27fd");
			Name = "RelationshipDiagramConfigProvider";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("32e5a92e-2a79-472b-b08d-f730aa69067f");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,157,84,77,111,155,64,16,61,59,82,254,195,138,147,45,5,7,176,113,156,90,62,216,94,28,89,138,34,43,110,123,169,122,216,192,128,87,130,93,180,31,169,172,202,255,189,203,71,18,136,105,157,70,66,192,46,239,189,153,183,51,3,35,25,200,156,132,128,190,130,16,68,242,88,13,87,156,197,52,209,130,40,202,217,240,17,210,242,69,238,105,142,65,210,132,129,184,188,248,125,121,209,211,146,178,4,237,14,82,65,54,123,93,55,117,4,12,215,36,84,92,80,144,6,97,48,185,126,74,105,136,194,148,72,137,48,37,137,32,89,43,158,193,20,218,47,192,128,41,170,14,45,4,90,83,33,213,61,60,67,90,237,163,146,208,75,64,205,144,52,183,98,117,60,163,177,131,144,179,232,3,34,199,211,180,59,244,222,101,125,167,105,132,118,225,30,50,242,109,19,157,203,79,42,81,28,28,166,50,79,201,225,59,73,53,172,120,170,51,246,23,226,41,117,147,145,228,223,156,182,15,202,20,136,184,168,250,166,85,222,102,61,182,130,63,211,168,168,117,101,173,171,88,232,14,84,107,163,63,152,189,198,250,129,33,38,58,85,75,202,34,147,100,95,29,114,224,113,255,124,196,193,224,231,251,35,63,203,65,95,254,195,74,45,253,65,71,245,137,10,80,90,48,196,224,87,55,177,66,245,78,154,115,94,82,186,122,176,102,244,222,26,101,94,118,206,112,75,132,132,190,229,249,248,102,229,46,150,182,139,3,199,30,251,142,107,47,199,142,103,59,94,224,4,254,226,198,195,147,192,26,92,161,235,107,18,134,92,51,85,235,117,52,210,28,89,15,102,210,173,171,26,210,108,24,243,109,81,241,239,121,194,55,145,85,97,142,53,246,116,82,62,239,200,157,44,131,209,196,119,237,233,58,240,236,177,235,223,218,83,140,29,123,49,117,70,120,60,153,142,48,30,85,142,76,76,101,254,28,159,118,180,221,115,213,240,82,62,142,205,97,48,215,31,75,121,192,91,252,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("dd23d878-8d9c-8ece-5b7d-37cf027c27fd"));
		}

		#endregion

	}

	#endregion

}

