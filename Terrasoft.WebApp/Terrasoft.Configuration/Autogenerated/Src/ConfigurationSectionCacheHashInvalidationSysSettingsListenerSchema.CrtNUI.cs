namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: ConfigurationSectionCacheHashInvalidationSysSettingsListenerSchema

	/// <exclude/>
	public class ConfigurationSectionCacheHashInvalidationSysSettingsListenerSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ConfigurationSectionCacheHashInvalidationSysSettingsListenerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ConfigurationSectionCacheHashInvalidationSysSettingsListenerSchema(ConfigurationSectionCacheHashInvalidationSysSettingsListenerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("ede056ac-3208-4fcc-88e6-c2cfbb0e9d0e");
			Name = "ConfigurationSectionCacheHashInvalidationSysSettingsListener";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("a9901a66-d58b-42c5-b270-d8f44a8fd449");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,173,84,93,111,218,48,20,125,166,82,255,195,29,123,73,52,148,31,208,174,211,58,182,118,145,6,84,165,236,101,155,38,55,190,73,60,5,59,178,29,10,66,252,247,222,216,80,18,86,6,18,123,73,226,251,113,238,185,199,7,36,155,162,41,89,130,240,128,90,51,163,82,27,245,149,76,69,86,105,102,133,146,231,103,203,243,179,78,101,132,204,96,188,48,22,167,151,59,231,232,1,231,54,186,199,172,42,152,254,50,47,53,26,67,141,102,91,215,132,214,184,47,30,221,176,196,42,45,112,111,103,228,7,142,209,90,74,154,104,168,172,72,69,226,120,30,219,51,122,252,131,137,173,71,80,195,91,141,25,245,66,191,96,198,92,64,107,241,49,149,209,171,207,146,28,191,50,147,199,114,198,10,193,125,110,97,54,128,223,4,193,75,212,14,239,199,103,76,89,85,216,79,66,114,74,6,118,81,162,74,131,248,149,250,176,7,67,210,30,174,160,123,202,216,110,248,139,230,150,213,99,33,18,72,234,53,78,218,2,46,224,53,178,52,98,233,22,124,81,236,70,96,193,73,178,59,45,102,204,162,79,150,254,0,198,18,126,2,26,25,87,178,88,0,121,3,231,240,59,103,102,32,164,184,99,25,94,115,62,80,28,215,115,250,244,233,107,174,106,152,142,196,39,223,19,124,236,18,233,159,79,239,118,250,186,61,159,31,149,245,30,134,46,122,90,138,2,121,120,185,102,137,146,123,162,109,214,3,180,185,58,68,123,166,4,135,73,73,26,225,86,182,116,136,200,145,183,174,18,204,246,59,132,165,163,46,82,8,222,28,177,105,20,155,1,179,73,30,52,48,162,58,27,110,144,58,26,109,165,157,175,59,157,149,123,206,152,6,130,206,61,57,77,222,113,198,245,191,155,69,116,139,246,125,220,186,253,23,254,235,142,15,65,232,241,26,40,209,206,170,235,146,213,177,74,58,235,173,133,244,54,116,2,142,154,246,234,231,76,102,164,222,196,160,38,130,210,155,18,170,214,177,7,7,196,93,29,152,114,47,178,220,158,58,171,231,197,143,255,194,109,22,249,200,145,180,190,179,162,194,255,195,234,182,34,112,10,95,243,169,144,19,41,108,204,123,160,220,63,90,179,218,77,220,248,104,159,147,155,250,254,227,198,125,180,29,164,216,51,203,134,101,111,56,6,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("ede056ac-3208-4fcc-88e6-c2cfbb0e9d0e"));
		}

		#endregion

	}

	#endregion

}

