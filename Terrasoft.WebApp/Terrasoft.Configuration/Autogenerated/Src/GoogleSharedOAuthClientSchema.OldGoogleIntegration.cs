namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: GoogleSharedOAuthClientSchema

	/// <exclude/>
	public class GoogleSharedOAuthClientSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public GoogleSharedOAuthClientSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public GoogleSharedOAuthClientSchema(GoogleSharedOAuthClientSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("b6e2a4fc-fe7f-4b18-9691-d148df804de7");
			Name = "GoogleSharedOAuthClient";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("79d5e1e4-18af-4001-8dc1-26f09fca92c2");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,157,83,203,78,195,64,12,60,7,137,127,176,194,37,149,80,114,111,211,74,165,8,132,196,75,60,78,136,195,146,56,233,74,233,110,228,221,5,33,196,191,227,108,250,72,74,195,129,83,179,246,120,236,25,187,74,172,208,212,34,67,120,66,34,97,116,97,227,133,86,133,44,29,9,43,181,58,62,250,58,62,10,156,145,170,236,65,8,39,3,241,248,66,100,86,147,68,115,8,241,168,51,41,170,248,110,238,236,146,243,140,56,33,44,185,17,44,42,97,204,24,46,181,46,43,124,92,10,194,220,163,22,149,68,101,61,52,73,18,72,141,91,173,4,125,206,214,239,7,172,9,13,35,12,8,181,174,6,95,8,153,175,132,66,19,24,207,7,101,155,22,117,93,201,204,235,139,55,180,73,135,247,229,28,11,225,42,123,38,85,206,227,71,246,179,70,93,68,157,113,70,167,112,203,214,193,20,194,129,129,195,209,43,51,213,238,141,59,241,36,172,109,72,26,108,68,247,228,6,95,94,242,206,30,173,140,37,215,88,203,46,221,123,222,22,177,239,138,15,116,224,241,22,148,236,163,210,90,144,88,129,98,41,211,208,25,164,107,93,74,21,206,210,196,39,60,110,45,97,96,248,136,187,52,27,222,22,159,194,51,127,114,123,133,89,99,176,207,236,158,163,134,50,24,195,155,48,24,117,138,246,80,208,92,93,240,189,182,0,85,222,186,208,183,228,6,237,82,231,141,27,164,45,23,98,254,135,33,15,104,29,41,62,18,30,157,231,110,214,207,119,209,220,6,191,255,119,55,67,166,82,219,106,150,26,68,200,8,139,105,120,248,15,16,95,249,159,121,119,164,48,153,129,228,221,9,149,97,156,38,27,46,191,137,141,76,208,239,204,39,115,132,3,4,112,137,182,23,136,254,94,72,107,117,208,54,2,133,31,191,87,221,167,219,171,159,12,111,170,141,246,131,28,251,1,75,84,114,159,117,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("b6e2a4fc-fe7f-4b18-9691-d148df804de7"));
		}

		#endregion

	}

	#endregion

}

