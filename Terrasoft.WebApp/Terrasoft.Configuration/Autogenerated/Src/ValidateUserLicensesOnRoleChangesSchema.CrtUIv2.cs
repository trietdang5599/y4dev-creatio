namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: ValidateUserLicensesOnRoleChangesSchema

	/// <exclude/>
	public class ValidateUserLicensesOnRoleChangesSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ValidateUserLicensesOnRoleChangesSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ValidateUserLicensesOnRoleChangesSchema(ValidateUserLicensesOnRoleChangesSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("44c6c31c-f2b7-42e8-ace6-4bc0039f060b");
			Name = "ValidateUserLicensesOnRoleChanges";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("d699061b-815e-49b9-8730-21a5e5db2044");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,133,144,193,106,195,48,12,134,207,13,228,29,68,123,217,46,121,128,150,158,210,21,6,27,131,209,245,174,58,170,107,240,228,32,217,167,145,119,159,156,180,231,94,100,244,251,255,63,217,98,252,37,29,209,17,156,72,4,53,93,115,215,39,190,6,95,4,115,72,220,54,127,109,179,42,26,216,67,47,84,181,238,104,71,17,58,37,239,163,233,187,182,49,203,70,200,155,31,250,136,170,91,56,99,12,3,102,250,81,146,143,224,136,149,244,139,191,83,164,254,134,236,73,231,208,88,46,49,56,112,53,243,60,2,91,184,143,254,164,140,102,69,67,212,231,61,56,79,9,47,175,48,251,87,239,250,198,120,137,52,192,30,178,20,218,205,234,129,212,73,24,235,191,77,95,63,112,80,140,7,241,14,4,187,20,67,130,91,152,235,57,59,89,153,150,69,16,15,203,46,106,59,253,3,238,168,183,76,98,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("44c6c31c-f2b7-42e8-ace6-4bc0039f060b"));
		}

		#endregion

	}

	#endregion

}

