namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: IOpenIdRoleChangeValidatorSchema

	/// <exclude/>
	public class IOpenIdRoleChangeValidatorSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IOpenIdRoleChangeValidatorSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IOpenIdRoleChangeValidatorSchema(IOpenIdRoleChangeValidatorSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("27d79e02-b230-4aff-9431-c743373f79e9");
			Name = "IOpenIdRoleChangeValidator";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("5daf09f1-167a-4d95-90ab-547ed370e530");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,125,79,187,10,195,48,12,156,19,200,63,24,186,180,80,242,1,237,84,50,20,79,133,190,118,39,86,28,131,35,7,217,30,74,201,191,215,78,210,210,46,5,13,58,233,78,186,67,209,131,27,68,3,236,10,68,194,217,214,151,149,197,86,171,64,194,107,139,229,105,0,228,242,16,124,87,228,207,34,207,130,211,168,216,229,225,60,244,251,15,254,86,19,164,121,172,21,129,138,39,24,71,15,212,198,39,59,198,231,115,103,107,160,234,4,42,184,11,163,165,240,150,138,60,42,134,80,27,221,48,253,22,252,229,103,201,78,86,91,107,88,37,112,94,223,28,16,199,68,95,167,54,70,65,104,82,14,22,126,224,150,29,131,150,211,144,203,5,80,84,113,185,73,230,199,37,0,160,156,51,76,120,124,1,212,2,161,140,46,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("27d79e02-b230-4aff-9431-c743373f79e9"));
		}

		#endregion

	}

	#endregion

}

