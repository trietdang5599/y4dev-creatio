namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: AccountConstsSchema

	/// <exclude/>
	public class AccountConstsSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public AccountConstsSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public AccountConstsSchema(AccountConstsSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("a6894da9-d220-412d-8d46-9dc9c008ba69");
			Name = "AccountConsts";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("912fb492-38c7-4dbe-88b2-46a261777d72");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,85,143,177,106,195,48,24,132,103,11,244,14,63,201,146,14,74,106,98,83,149,210,33,86,212,208,41,67,242,2,170,172,4,129,45,25,253,18,193,20,191,123,109,147,20,114,219,221,125,28,92,66,235,174,112,234,49,154,246,131,18,74,156,106,13,118,74,27,56,155,16,20,250,75,92,11,239,46,246,154,130,138,214,59,74,126,41,201,186,244,211,88,13,24,199,76,131,110,20,34,236,180,246,201,197,145,198,136,35,51,113,217,102,3,203,135,128,193,108,254,147,9,120,94,10,70,213,222,53,61,28,146,173,225,152,130,240,109,167,92,127,223,254,174,225,19,156,185,205,245,106,33,183,175,188,122,227,57,219,138,178,98,133,20,21,227,239,242,139,149,34,151,251,98,191,43,56,151,139,151,241,87,54,80,50,252,1,10,54,57,117,236,0,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("a6894da9-d220-412d-8d46-9dc9c008ba69"));
		}

		#endregion

	}

	#endregion

}

