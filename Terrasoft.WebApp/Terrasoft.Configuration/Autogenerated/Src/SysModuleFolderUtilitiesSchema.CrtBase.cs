namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: SysModuleFolderUtilitiesSchema

	/// <exclude/>
	public class SysModuleFolderUtilitiesSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public SysModuleFolderUtilitiesSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public SysModuleFolderUtilitiesSchema(SysModuleFolderUtilitiesSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("da6824aa-e582-4158-850d-dede529eb3c0");
			Name = "SysModuleFolderUtilities";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,189,82,81,107,194,48,16,126,86,216,127,8,62,41,72,216,187,236,65,4,197,135,141,161,142,61,142,152,158,46,172,77,74,238,42,136,248,223,151,38,181,179,181,29,125,152,131,182,73,239,46,249,190,239,190,211,34,1,76,133,4,182,1,107,5,154,29,241,153,209,59,181,207,172,32,101,244,67,255,244,208,239,101,168,244,158,173,143,72,144,76,202,255,235,35,73,98,116,115,198,66,91,156,175,41,100,93,62,205,182,177,146,12,201,161,74,38,99,129,152,227,61,155,40,139,97,110,226,8,236,27,169,88,145,2,116,229,57,169,198,51,51,33,63,97,233,104,190,228,202,242,42,95,90,171,69,178,133,160,0,128,175,130,8,172,102,161,184,183,7,186,108,123,22,40,115,153,193,204,130,32,184,38,180,17,219,143,211,227,121,48,9,149,103,191,132,111,7,204,169,204,251,219,5,185,126,164,5,244,236,27,89,67,61,24,21,177,21,32,208,187,177,95,222,106,244,61,26,46,253,226,45,96,178,220,142,10,244,159,8,95,65,98,14,48,108,25,16,238,175,41,189,225,37,140,143,47,172,201,210,209,164,3,189,194,136,192,109,145,185,48,86,237,95,70,99,246,59,231,131,176,33,122,241,159,61,21,93,231,115,99,19,65,195,234,116,240,27,255,199,183,160,129,124,67,63,42,72,165,196,96,125,155,200,154,147,77,98,239,41,179,58,114,227,107,208,63,149,57,213,34,62,186,16,174,32,53,150,238,58,111,77,88,29,105,6,237,255,192,49,64,96,141,155,123,221,243,13,65,60,44,47,130,5,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("da6824aa-e582-4158-850d-dede529eb3c0"));
		}

		#endregion

	}

	#endregion

}

