namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: AccountMLangBinderSchema

	/// <exclude/>
	public class AccountMLangBinderSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public AccountMLangBinderSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public AccountMLangBinderSchema(AccountMLangBinderSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("2b2c9475-0367-40a6-8f73-d4237f998eae");
			Name = "AccountMLangBinder";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("d5fe5418-b108-401a-ba83-ff1213a966db");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,109,81,193,106,195,48,12,61,167,208,127,48,221,165,131,145,220,215,82,88,203,6,133,148,13,54,216,217,113,212,204,144,200,193,150,195,74,233,191,79,181,157,209,110,61,25,233,61,61,189,39,163,236,192,245,82,129,248,0,107,165,51,123,202,55,6,247,186,241,86,146,54,56,157,28,167,147,204,59,141,205,21,197,66,254,34,21,25,171,193,45,110,48,62,161,98,86,215,25,100,148,241,59,11,13,203,137,77,43,157,123,20,79,74,25,143,180,43,37,54,107,141,53,216,192,42,138,66,44,157,239,58,105,15,171,84,39,170,232,124,75,186,101,190,151,13,8,117,214,17,85,24,205,199,201,226,98,180,247,85,171,85,226,253,95,39,216,67,223,63,15,128,84,106,71,128,96,215,210,1,15,30,131,147,95,195,59,160,47,83,179,229,183,32,24,193,36,110,6,206,171,107,16,131,209,181,120,69,86,124,39,105,105,62,74,243,41,9,190,73,168,248,222,139,243,49,179,172,226,77,249,5,125,132,23,1,13,39,138,199,61,228,103,183,203,109,153,98,111,9,248,91,140,125,24,19,253,5,86,243,89,66,102,81,237,148,210,0,214,49,80,168,99,247,186,121,250,1,83,78,45,213,12,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("2b2c9475-0367-40a6-8f73-d4237f998eae"));
		}

		#endregion

	}

	#endregion

}

