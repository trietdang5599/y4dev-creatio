namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: RelationshipDesignerConstsSchema

	/// <exclude/>
	public class RelationshipDesignerConstsSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public RelationshipDesignerConstsSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public RelationshipDesignerConstsSchema(RelationshipDesignerConstsSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("718abfbc-0c58-497c-88f9-59343c161b6f");
			Name = "RelationshipDesignerConsts";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("306bd3dc-c1db-4d7d-a14d-6d8f14db70cb");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,165,146,65,107,220,48,16,133,207,49,248,63,136,156,210,195,36,178,36,203,54,161,7,219,26,181,167,82,210,220,131,235,40,91,129,87,50,146,55,97,83,242,223,235,221,108,55,53,52,52,161,23,161,97,222,123,243,49,210,38,90,183,34,223,182,113,50,235,203,52,73,19,215,173,77,28,187,222,144,107,19,66,23,253,221,116,222,122,119,103,87,155,208,77,214,187,243,43,51,236,47,241,135,29,149,137,118,229,76,72,147,159,105,114,50,110,190,15,182,39,113,154,251,61,233,135,46,70,242,55,245,156,55,107,220,20,103,207,206,119,114,113,241,91,70,166,237,104,72,239,157,51,253,75,13,68,251,176,238,134,157,118,57,36,152,238,214,187,97,75,62,109,236,237,113,216,245,108,106,143,25,187,234,230,57,128,124,36,206,60,236,197,103,167,185,84,5,167,141,6,86,232,28,4,83,21,148,92,105,200,118,39,195,150,202,58,59,253,112,249,54,192,47,126,250,111,198,99,198,2,83,170,76,49,38,56,40,161,16,132,146,2,234,186,17,192,56,162,18,148,101,181,164,175,96,142,62,218,125,5,228,179,15,246,209,187,233,237,128,95,15,230,155,23,235,130,171,110,105,133,90,22,32,145,11,16,26,17,42,205,37,52,121,163,139,34,67,158,243,226,223,92,202,134,121,3,239,102,122,182,45,120,40,21,165,46,74,13,162,102,114,230,169,41,148,84,54,160,90,228,85,37,115,204,243,215,158,243,15,158,43,115,111,66,52,239,6,58,248,22,68,25,34,150,168,40,48,153,205,31,12,57,131,74,200,22,56,21,152,85,149,174,203,246,176,161,167,52,121,250,5,40,229,190,108,139,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("718abfbc-0c58-497c-88f9-59343c161b6f"));
		}

		#endregion

	}

	#endregion

}

