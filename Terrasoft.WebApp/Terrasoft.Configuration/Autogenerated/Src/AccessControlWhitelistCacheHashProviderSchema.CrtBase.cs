namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: AccessControlWhitelistCacheHashProviderSchema

	/// <exclude/>
	public class AccessControlWhitelistCacheHashProviderSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public AccessControlWhitelistCacheHashProviderSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public AccessControlWhitelistCacheHashProviderSchema(AccessControlWhitelistCacheHashProviderSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("4fc5510f-13ec-4062-8e0b-a0a78533e843");
			Name = "AccessControlWhitelistCacheHashProvider";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("acb004d0-c421-4dff-b075-f4fdc1c90074");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,149,146,193,74,195,64,16,134,207,13,244,29,6,188,52,32,125,128,148,10,26,17,69,145,162,130,7,241,176,217,76,218,133,117,55,236,76,10,165,248,238,206,38,150,54,182,149,118,47,9,179,51,243,127,243,239,56,245,133,84,43,141,240,134,33,40,242,21,143,115,239,42,51,111,130,98,227,221,48,89,15,19,144,211,144,113,243,94,86,192,113,110,13,58,206,149,94,224,228,159,180,59,165,217,7,131,36,73,195,100,112,17,112,46,173,33,183,138,40,131,107,173,145,72,84,57,120,251,190,48,140,214,80,215,244,94,209,98,22,252,210,148,24,98,105,84,248,184,197,74,53,150,111,140,43,69,107,196,171,26,125,53,122,216,43,72,47,225,89,198,131,41,56,249,72,202,137,66,105,250,217,41,213,77,97,141,6,29,49,79,165,132,12,94,176,52,212,94,168,194,254,25,33,182,93,183,38,108,93,240,142,56,52,209,33,49,99,214,106,110,102,221,161,56,81,95,124,216,190,201,171,244,68,225,239,7,210,109,239,120,50,40,20,225,104,47,43,114,14,6,223,191,176,232,202,142,183,15,47,178,53,6,150,167,205,226,63,163,102,44,123,244,155,32,248,165,44,133,32,130,76,27,119,164,149,122,196,21,76,175,142,13,23,157,81,142,105,220,134,158,118,231,149,194,201,25,104,199,92,61,8,213,109,205,185,84,177,234,48,82,231,97,63,40,177,31,71,18,5,248,124,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("4fc5510f-13ec-4062-8e0b-a0a78533e843"));
		}

		#endregion

	}

	#endregion

}

