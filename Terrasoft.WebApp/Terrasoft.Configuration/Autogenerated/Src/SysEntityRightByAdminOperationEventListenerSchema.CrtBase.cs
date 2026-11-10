namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: SysEntityRightByAdminOperationEventListenerSchema

	/// <exclude/>
	public class SysEntityRightByAdminOperationEventListenerSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public SysEntityRightByAdminOperationEventListenerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public SysEntityRightByAdminOperationEventListenerSchema(SysEntityRightByAdminOperationEventListenerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("043420fb-2a3b-4a10-bbe5-469835248027");
			Name = "SysEntityRightByAdminOperationEventListener";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("9cc3d920-8a68-437c-9367-c8131a0a7723");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,157,82,203,110,194,48,16,60,39,82,254,97,69,47,68,170,242,1,32,42,241,186,181,5,53,237,169,234,193,36,75,112,21,214,145,215,137,132,16,255,94,199,38,18,41,45,7,114,241,99,119,102,103,198,169,89,82,1,239,168,181,96,181,53,201,92,105,76,150,100,164,145,200,227,40,172,111,213,147,101,131,100,218,182,40,36,177,71,174,68,134,189,102,218,202,162,214,194,72,69,81,120,140,66,128,40,12,62,29,254,224,192,207,146,13,18,234,97,154,237,112,47,94,45,11,76,96,144,30,216,55,189,201,98,103,102,135,105,190,151,180,170,208,83,13,226,47,75,35,201,160,38,81,66,86,10,102,184,13,233,13,131,17,204,4,227,31,50,44,237,177,117,19,4,15,26,11,139,131,23,52,59,149,243,8,214,90,54,194,96,91,133,243,87,249,43,104,148,204,97,94,162,208,115,97,109,12,61,49,160,91,98,152,60,157,183,201,7,163,182,161,16,102,173,166,100,49,75,49,171,117,43,130,10,73,152,56,142,11,23,188,214,170,145,57,230,191,237,176,31,20,143,59,49,78,50,82,238,85,247,110,175,140,212,155,82,102,222,101,229,246,160,26,251,102,118,142,119,178,162,84,52,152,15,213,230,219,10,5,182,180,168,31,193,235,154,110,109,234,46,179,169,46,24,48,134,99,75,20,108,108,160,73,135,236,32,216,10,180,197,139,108,206,225,196,190,197,215,79,23,161,254,163,104,129,37,154,59,53,117,216,123,84,245,83,181,231,147,255,137,79,63,231,190,136,30,57,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("043420fb-2a3b-4a10-bbe5-469835248027"));
		}

		#endregion

	}

	#endregion

}

