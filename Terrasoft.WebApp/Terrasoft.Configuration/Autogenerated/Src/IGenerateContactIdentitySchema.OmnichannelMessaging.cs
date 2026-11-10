namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: IGenerateContactIdentitySchema

	/// <exclude/>
	public class IGenerateContactIdentitySchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IGenerateContactIdentitySchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IGenerateContactIdentitySchema(IGenerateContactIdentitySchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("94ba7946-d68b-4d6a-a761-56ca9daed747");
			Name = "IGenerateContactIdentity";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("01343ce8-0448-497f-b2c3-9511b4580fa3");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,77,143,193,10,194,64,12,68,207,22,250,15,57,42,72,251,1,138,151,30,74,15,226,65,127,96,221,166,53,208,205,74,54,123,40,226,191,187,181,173,120,203,192,204,203,12,27,135,225,105,44,194,13,69,76,240,157,22,149,231,142,250,40,70,201,115,113,113,76,246,97,152,113,40,206,24,130,233,137,251,60,123,229,217,38,134,116,194,117,12,138,238,144,116,89,150,112,12,209,57,35,227,105,209,13,43,74,55,61,232,188,64,143,140,19,55,197,172,103,53,86,129,90,100,37,29,139,21,80,254,17,158,241,62,144,5,250,65,154,122,38,96,53,199,155,37,157,188,83,163,205,221,251,1,110,50,214,168,23,169,4,147,115,181,108,235,72,45,44,83,154,118,15,179,94,57,123,240,81,33,168,124,203,173,174,57,186,155,214,189,243,236,253,1,226,221,67,167,47,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("94ba7946-d68b-4d6a-a761-56ca9daed747"));
		}

		#endregion

	}

	#endregion

}

