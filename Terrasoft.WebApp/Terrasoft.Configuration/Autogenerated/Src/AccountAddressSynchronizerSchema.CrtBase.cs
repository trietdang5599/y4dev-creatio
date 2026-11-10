namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: AccountAddressSynchronizerSchema

	/// <exclude/>
	public class AccountAddressSynchronizerSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public AccountAddressSynchronizerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public AccountAddressSynchronizerSchema(AccountAddressSynchronizerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("74191a0d-e4ee-4056-8a11-3e962a99a246");
			Name = "AccountAddressSynchronizer";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,181,83,193,110,219,48,12,61,187,64,255,129,72,47,14,16,56,247,164,43,208,101,65,176,67,139,0,217,62,64,149,153,68,128,45,121,148,148,34,27,242,239,163,108,37,177,3,39,27,10,244,40,242,241,241,145,143,210,162,68,91,9,137,240,3,137,132,53,107,151,205,140,94,171,141,39,225,148,209,247,119,127,238,239,18,111,149,222,192,92,59,229,246,171,189,150,91,50,90,253,174,1,211,83,122,181,183,14,75,46,47,10,148,33,101,179,5,106,36,37,207,152,118,23,194,107,241,172,238,164,208,50,128,33,15,132,27,166,131,89,33,172,157,192,179,148,198,107,247,156,231,132,214,158,229,32,213,232,241,120,12,143,214,151,165,160,253,83,124,47,201,236,84,142,22,74,116,91,147,91,88,27,2,123,170,12,10,68,195,10,162,161,133,119,229,182,199,96,118,164,29,183,120,43,255,86,40,9,50,136,186,161,9,38,240,85,88,236,85,155,132,221,158,199,227,141,57,242,210,16,15,185,172,217,235,129,142,157,174,247,72,127,90,36,46,215,205,222,193,119,158,163,104,220,113,180,230,53,132,73,224,78,222,88,92,122,89,208,65,142,96,16,91,15,134,80,43,62,52,186,30,80,231,141,246,248,142,131,188,52,75,158,132,181,59,166,196,60,206,113,124,130,217,177,223,108,8,124,63,95,203,227,197,97,113,198,151,250,69,84,21,219,243,4,11,116,183,0,54,141,218,146,94,212,204,148,149,224,139,14,182,59,98,252,252,151,23,69,43,250,5,46,34,241,100,40,11,141,251,74,210,225,180,238,183,19,4,97,137,93,57,76,24,130,217,191,101,79,79,54,116,51,25,27,157,106,124,135,91,245,113,230,100,101,60,201,72,240,202,127,154,219,15,22,203,213,235,96,212,228,191,161,117,74,183,234,251,64,157,117,244,174,169,198,29,62,85,242,252,127,36,207,63,40,153,208,121,210,61,118,77,175,156,117,140,181,67,135,191,42,40,98,108,52,5,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("74191a0d-e4ee-4056-8a11-3e962a99a246"));
		}

		#endregion

	}

	#endregion

}

