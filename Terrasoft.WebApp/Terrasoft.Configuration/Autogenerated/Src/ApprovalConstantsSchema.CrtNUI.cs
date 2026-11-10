namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: ApprovalConstantsSchema

	/// <exclude/>
	public class ApprovalConstantsSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ApprovalConstantsSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ApprovalConstantsSchema(ApprovalConstantsSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("96d50106-6c2d-4bb1-9f14-582f073e5e34");
			Name = "ApprovalConstants";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("be1f674b-cdb4-46e4-8c46-23cae20b9205");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,165,147,95,75,195,48,20,197,159,55,216,119,8,243,69,31,178,46,77,218,44,78,7,178,7,95,69,5,159,111,210,219,81,233,63,154,84,17,241,187,27,55,91,91,157,32,216,151,208,195,185,231,252,18,146,18,10,180,53,24,36,247,216,52,96,171,212,45,182,85,153,102,187,182,1,151,85,229,108,250,58,155,18,255,181,54,43,119,228,238,197,58,44,214,179,233,65,60,105,112,231,77,100,155,131,181,231,228,170,174,155,234,9,114,159,96,29,148,206,118,190,32,8,200,133,109,139,2,154,151,205,151,212,249,201,96,160,183,7,99,127,221,234,60,51,196,219,156,95,204,71,225,177,190,15,235,107,87,59,68,188,105,170,26,27,151,161,231,188,217,103,13,93,71,0,59,249,1,50,183,223,186,111,110,237,226,219,76,240,115,104,76,122,221,102,73,159,113,185,33,37,62,239,181,211,57,23,113,24,41,145,80,41,65,82,161,151,64,87,82,0,141,147,149,142,132,14,21,215,102,126,182,254,35,230,149,49,88,59,76,254,197,217,135,140,64,81,170,20,140,230,148,27,30,82,193,81,82,136,20,82,22,106,96,97,132,49,227,225,223,65,111,241,17,205,127,65,251,144,17,40,40,14,122,169,21,53,192,99,127,162,42,162,74,135,156,226,146,1,176,88,25,206,87,159,160,147,35,148,189,182,245,15,34,31,18,78,142,225,77,126,97,219,66,121,24,31,177,41,22,46,211,4,83,26,43,141,84,176,120,69,117,148,114,26,49,41,153,208,18,4,170,142,109,114,130,101,114,184,183,254,239,109,175,13,165,217,244,237,29,47,131,74,15,185,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("96d50106-6c2d-4bb1-9f14-582f073e5e34"));
		}

		#endregion

	}

	#endregion

}

