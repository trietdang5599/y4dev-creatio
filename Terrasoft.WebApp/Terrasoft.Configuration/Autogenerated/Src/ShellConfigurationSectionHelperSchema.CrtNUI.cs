namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: ShellConfigurationSectionHelperSchema

	/// <exclude/>
	public class ShellConfigurationSectionHelperSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ShellConfigurationSectionHelperSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ShellConfigurationSectionHelperSchema(ShellConfigurationSectionHelperSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("54838e95-4506-4fcf-bab9-4cc062984a4c");
			Name = "ShellConfigurationSectionHelper";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("0c6d5769-8079-4d44-b72c-713dda089a12");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,237,85,77,107,227,48,16,61,187,208,255,48,208,75,10,198,63,32,217,45,164,73,55,237,33,16,54,91,122,86,228,105,34,170,72,102,52,222,110,40,253,239,59,182,210,15,183,137,147,64,96,89,232,81,79,111,230,61,205,216,51,78,45,49,20,74,35,252,66,34,21,252,61,103,3,239,238,205,188,36,197,198,187,211,147,167,211,147,164,12,198,205,97,186,10,140,203,222,135,179,240,173,69,93,145,67,54,66,135,100,244,27,103,75,218,236,206,211,67,97,69,120,26,67,251,90,99,8,155,227,8,55,225,119,56,203,174,153,139,172,63,11,76,42,26,16,162,80,207,8,231,114,130,129,85,33,116,97,186,64,107,27,242,107,209,107,180,5,82,29,82,148,51,107,52,232,42,98,87,0,116,161,45,91,242,84,103,124,115,33,190,152,74,205,158,196,204,164,22,138,140,181,232,14,185,206,109,64,146,107,23,65,40,27,199,243,42,81,210,133,153,10,216,249,112,5,85,239,146,231,227,137,165,112,83,149,92,0,198,63,28,123,230,9,22,159,177,22,91,233,70,254,63,244,154,214,94,111,6,214,160,227,91,103,120,170,23,184,84,67,212,94,84,37,70,111,187,57,244,149,105,75,170,255,178,0,47,145,239,45,14,21,171,159,104,21,99,62,81,115,12,253,162,144,112,73,178,7,233,136,5,141,214,146,189,84,191,106,47,164,117,190,75,41,253,230,233,60,86,78,232,4,143,109,183,199,236,224,1,182,147,118,83,141,6,159,161,203,227,108,110,14,234,9,121,105,44,27,172,198,52,121,150,68,152,175,191,137,151,35,248,223,178,129,76,142,48,243,222,130,124,4,27,190,19,77,166,96,248,126,1,50,246,177,215,46,58,70,94,248,124,47,197,161,169,95,166,104,245,109,84,154,60,133,43,199,134,87,211,122,185,148,132,23,48,66,174,49,121,194,43,186,99,125,196,202,36,132,194,117,224,240,113,183,76,231,188,247,254,119,105,53,42,155,79,214,118,10,99,159,151,22,155,86,35,118,28,167,219,116,154,94,119,55,225,243,118,126,125,85,148,168,140,79,8,173,87,57,230,63,80,85,42,225,32,231,49,79,118,181,44,120,213,98,46,162,77,240,249,47,126,208,75,113,176,9,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("54838e95-4506-4fcf-bab9-4cc062984a4c"));
		}

		#endregion

	}

	#endregion

}

