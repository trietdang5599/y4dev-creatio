namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: UidSinceSyncStrategySchema

	/// <exclude/>
	public class UidSinceSyncStrategySchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public UidSinceSyncStrategySchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public UidSinceSyncStrategySchema(UidSinceSyncStrategySchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("ea1a0baf-434e-4325-bd23-753efc693955");
			Name = "UidSinceSyncStrategy";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,125,83,77,143,218,48,16,61,7,137,255,48,74,47,32,33,210,51,187,112,88,186,149,246,176,171,173,82,78,85,15,38,153,164,86,19,59,26,79,42,34,196,127,239,56,1,54,161,161,23,136,199,111,62,222,123,99,163,74,116,149,74,16,190,35,145,114,54,227,229,171,210,197,116,114,156,78,130,218,105,147,247,110,182,214,100,58,175,73,177,182,230,97,20,64,120,47,190,124,54,172,89,163,187,11,248,170,18,182,212,33,4,243,137,48,151,62,176,45,148,115,43,216,233,52,214,38,193,184,49,73,204,50,3,230,77,139,139,162,8,30,93,93,150,138,154,205,245,140,8,9,97,182,14,95,250,9,97,180,1,93,86,5,150,104,88,105,182,102,1,41,22,250,15,18,166,144,145,45,251,169,210,242,73,57,76,111,42,44,47,77,162,219,174,132,114,252,237,46,231,177,124,168,37,0,108,193,97,129,9,131,42,10,16,15,156,202,209,129,54,41,30,228,191,29,196,121,182,2,51,12,169,164,126,116,237,117,249,241,5,51,85,23,252,36,153,162,232,140,155,10,109,54,27,112,158,47,224,77,108,134,53,132,99,26,134,243,159,82,168,170,247,133,78,32,241,90,143,74,13,171,81,58,146,122,108,93,184,218,245,78,182,66,226,102,229,191,88,40,98,218,1,110,125,106,3,49,42,74,126,1,30,42,18,17,124,62,163,248,115,230,251,175,204,65,117,41,10,86,76,35,157,138,68,76,126,155,118,198,201,96,175,46,239,106,126,171,145,26,240,107,28,4,57,242,249,43,32,228,154,12,132,241,203,219,246,25,142,159,79,225,67,123,113,242,191,167,51,21,52,105,199,102,72,77,246,95,122,213,126,75,101,33,223,91,201,254,195,109,233,129,119,104,180,145,74,145,42,193,136,57,235,80,214,130,164,190,17,110,210,42,220,236,228,12,201,53,176,124,140,90,244,120,178,39,30,35,179,200,224,194,77,111,131,253,91,222,219,67,220,191,247,79,64,120,40,49,120,80,245,188,2,99,230,207,118,131,233,96,56,236,2,218,167,221,64,127,140,121,171,234,10,246,178,49,179,91,252,0,216,57,51,46,125,23,237,7,131,233,228,244,23,23,21,130,4,182,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("ea1a0baf-434e-4325-bd23-753efc693955"));
		}

		#endregion

	}

	#endregion

}

