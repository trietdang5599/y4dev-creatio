namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: AccessControlWhitelistConstantsSchema

	/// <exclude/>
	public class AccessControlWhitelistConstantsSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public AccessControlWhitelistConstantsSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public AccessControlWhitelistConstantsSchema(AccessControlWhitelistConstantsSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("f56217ca-60b7-4c68-9e7d-44e676ced639");
			Name = "AccessControlWhitelistConstants";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("acb004d0-c421-4dff-b075-f4fdc1c90074");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,133,144,193,14,130,48,12,134,207,146,240,14,13,156,245,1,48,30,12,23,19,141,241,96,226,185,214,2,139,115,144,117,28,136,225,221,29,67,140,156,232,101,233,191,254,223,223,205,224,139,165,65,98,184,178,181,40,117,225,54,121,109,10,85,182,22,157,170,77,28,189,227,40,142,86,169,229,210,183,144,107,20,201,96,79,196,34,126,210,217,90,223,42,229,88,43,113,190,23,135,198,73,176,52,237,93,43,2,175,56,127,208,96,92,246,129,175,144,8,223,250,5,79,51,25,92,2,56,100,76,33,52,220,250,40,171,76,9,129,123,26,184,72,21,159,253,19,97,7,9,146,94,211,32,36,219,127,254,50,224,128,82,29,185,155,49,214,79,238,230,156,148,205,99,92,53,44,214,143,191,54,19,251,15,191,79,162,28,110,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("f56217ca-60b7-4c68-9e7d-44e676ced639"));
		}

		#endregion

	}

	#endregion

}

