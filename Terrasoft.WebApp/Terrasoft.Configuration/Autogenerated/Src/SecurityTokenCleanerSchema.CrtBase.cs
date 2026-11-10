namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: SecurityTokenCleanerSchema

	/// <exclude/>
	public class SecurityTokenCleanerSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public SecurityTokenCleanerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public SecurityTokenCleanerSchema(SecurityTokenCleanerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("0104f03c-a574-4da3-bbd9-fc323cbac58a");
			Name = "SecurityTokenCleaner";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,125,82,65,110,194,48,16,60,7,169,127,88,209,11,72,40,185,183,52,23,64,21,149,42,161,2,15,48,201,66,77,29,59,218,117,40,8,241,247,58,118,154,146,22,245,182,59,51,30,143,119,173,69,129,92,138,12,97,133,68,130,205,214,198,19,163,183,114,87,145,176,210,232,187,222,249,174,23,85,44,245,14,150,39,182,88,56,94,41,204,106,146,227,103,212,72,50,123,108,53,215,54,132,14,119,204,61,225,206,169,97,162,4,51,60,192,18,179,138,164,61,173,204,7,234,137,66,225,60,188,48,73,18,24,115,85,20,130,78,105,211,191,97,73,200,168,45,131,128,44,136,97,111,54,176,53,4,120,44,37,97,14,220,56,130,173,45,57,254,246,74,174,204,202,106,163,100,230,44,234,16,183,34,184,100,243,23,179,153,29,29,103,141,75,20,157,125,170,54,255,43,218,119,147,215,47,88,120,175,192,254,14,237,129,41,42,180,200,255,5,252,155,48,32,165,32,81,128,118,139,121,234,87,140,228,214,161,195,184,251,233,218,245,144,181,64,60,78,188,250,246,97,95,187,20,196,253,116,209,214,157,51,205,76,14,146,108,37,20,28,140,204,33,188,31,7,235,206,221,208,141,50,130,249,84,250,202,101,31,179,37,183,251,17,152,205,222,209,41,252,220,60,132,250,251,68,145,198,207,238,204,215,86,42,105,37,242,160,107,60,140,195,232,102,97,112,94,203,131,97,253,193,162,75,179,14,212,121,216,136,239,3,218,5,47,95,111,167,53,82,216,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("0104f03c-a574-4da3-bbd9-fc323cbac58a"));
		}

		#endregion

	}

	#endregion

}

