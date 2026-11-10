namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: IImapClientSchema

	/// <exclude/>
	public class IImapClientSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IImapClientSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IImapClientSchema(IImapClientSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("4eefcdc0-dfe1-496a-a1c1-f92ded0404ac");
			Name = "IImapClient";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("80eb4b00-d20b-4335-a2cc-1f02c0e63f83");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,117,145,239,106,131,48,20,197,63,91,232,59,4,250,165,133,225,3,180,99,95,236,31,132,57,10,243,5,162,158,218,64,76,36,55,118,43,163,239,190,171,113,157,20,10,6,114,79,126,156,156,28,141,108,64,173,44,33,114,56,39,201,158,124,156,73,165,231,179,159,249,44,234,72,153,90,124,94,201,163,217,60,204,113,98,181,70,233,149,53,20,31,96,224,84,201,12,83,11,135,154,85,145,26,15,119,98,239,181,72,211,70,182,137,86,48,158,1,254,218,174,208,170,20,234,15,153,18,140,111,21,181,150,100,161,193,108,159,228,110,154,193,159,109,69,107,113,28,28,134,11,163,194,90,45,114,119,221,66,195,99,111,117,5,183,36,239,250,180,167,97,250,224,119,174,54,119,54,113,144,143,160,193,87,16,142,210,159,3,123,177,170,18,153,189,32,3,145,172,145,219,103,222,47,98,148,154,145,84,94,255,139,21,184,49,35,251,174,130,193,36,202,206,80,231,198,40,187,111,69,158,158,37,127,231,195,215,161,167,64,191,137,3,124,216,210,114,21,186,143,22,48,85,168,170,159,120,221,194,63,153,200,183,95,198,6,107,135,245,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("4eefcdc0-dfe1-496a-a1c1-f92ded0404ac"));
		}

		#endregion

	}

	#endregion

}

