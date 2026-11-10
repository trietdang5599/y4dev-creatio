namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: ContactMLangBinderSchema

	/// <exclude/>
	public class ContactMLangBinderSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ContactMLangBinderSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ContactMLangBinderSchema(ContactMLangBinderSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("28c6993a-5103-498a-bc0d-ef34c1059002");
			Name = "ContactMLangBinder";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("d5fe5418-b108-401a-ba83-ff1213a966db");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,109,81,77,107,195,48,12,61,183,208,255,32,186,75,7,35,185,183,165,176,150,13,10,41,27,108,176,179,147,168,153,33,182,131,45,135,149,210,255,62,197,118,70,187,237,100,164,247,33,61,89,11,133,174,19,21,194,59,90,43,156,57,82,182,51,250,40,27,111,5,73,163,103,211,243,108,58,241,78,234,230,134,98,49,123,22,21,25,43,209,173,254,97,124,96,201,44,165,140,102,148,241,59,139,13,219,193,174,21,206,45,129,103,16,203,15,133,208,205,86,234,26,109,96,229,121,14,107,231,149,18,246,180,73,117,162,130,242,45,201,150,249,94,52,8,213,224,3,101,144,102,163,50,191,146,118,190,108,101,149,120,127,199,193,18,30,187,238,169,71,77,133,116,132,26,237,86,56,100,225,57,108,242,179,240,1,233,211,212,188,242,107,48,140,96,50,55,61,231,149,53,66,111,100,13,47,154,29,223,72,88,90,140,214,195,92,252,34,168,226,123,15,195,49,39,147,146,39,101,87,244,17,94,5,52,156,40,30,247,148,13,219,174,247,69,138,189,39,228,111,49,246,97,76,244,27,216,44,230,9,153,71,183,75,74,131,186,142,129,66,29,187,183,205,203,55,163,43,50,144,12,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("28c6993a-5103-498a-bc0d-ef34c1059002"));
		}

		#endregion

	}

	#endregion

}

