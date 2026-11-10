namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: ActivityUserTaskHelperSchema

	/// <exclude/>
	public class ActivityUserTaskHelperSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ActivityUserTaskHelperSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ActivityUserTaskHelperSchema(ActivityUserTaskHelperSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("64a98983-9363-4df0-9a04-3cf2dd6cddc8");
			Name = "ActivityUserTaskHelper";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("3949d191-f356-45da-a437-95abb1839b71");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,125,82,89,107,219,64,16,126,86,32,255,97,234,190,216,96,164,247,248,128,196,56,77,160,9,1,167,125,223,174,70,246,146,61,196,206,174,169,8,249,239,93,237,74,138,149,56,5,33,52,199,119,204,104,52,83,72,53,227,8,207,104,45,35,83,185,124,99,116,37,246,222,50,39,140,190,188,120,189,188,200,60,9,189,135,93,67,14,213,98,136,79,33,74,25,125,190,98,49,223,106,39,156,64,10,13,161,229,187,197,125,96,134,141,100,68,87,112,205,157,56,10,215,252,34,180,207,140,94,238,80,214,104,67,95,120,138,162,128,37,121,165,152,109,214,93,252,100,205,81,148,72,192,252,95,33,69,168,128,66,119,48,37,65,101,44,184,3,2,235,40,193,7,78,112,129,52,239,201,138,19,182,218,255,145,130,3,185,48,41,7,222,218,249,218,205,107,244,62,152,127,72,146,87,240,20,73,82,241,163,221,152,184,21,82,18,112,35,189,210,112,100,210,35,152,42,218,196,118,45,77,62,32,139,143,208,101,205,44,83,160,195,79,90,77,82,247,100,189,77,168,101,17,139,231,123,147,218,99,248,158,172,55,73,185,45,252,31,20,189,13,253,49,26,1,198,235,58,26,81,194,174,70,46,170,166,95,218,79,99,94,124,157,8,126,183,248,105,50,219,77,58,15,88,219,158,199,187,189,57,252,240,129,39,138,205,160,61,181,44,19,21,76,147,250,61,109,85,237,154,233,172,47,101,22,157,183,241,208,178,236,45,190,147,194,142,31,80,177,225,199,119,225,170,95,113,138,23,159,0,201,106,120,75,228,237,181,119,206,40,32,199,84,121,234,164,175,40,58,161,81,106,213,179,229,183,66,151,55,77,59,239,244,125,244,217,98,152,246,12,248,219,10,180,151,114,24,188,31,4,221,233,122,63,3,231,221,46,79,86,244,214,93,46,234,50,29,111,140,83,118,156,12,185,127,114,228,240,119,17,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("64a98983-9363-4df0-9a04-3cf2dd6cddc8"));
		}

		#endregion

	}

	#endregion

}

