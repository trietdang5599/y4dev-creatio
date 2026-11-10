namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: ConfigurationSectionCacheHashInvalidationEventListenerSchema

	/// <exclude/>
	public class ConfigurationSectionCacheHashInvalidationEventListenerSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ConfigurationSectionCacheHashInvalidationEventListenerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ConfigurationSectionCacheHashInvalidationEventListenerSchema(ConfigurationSectionCacheHashInvalidationEventListenerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("fdddd35b-2cec-43ec-8ee6-0ee22ca07325");
			Name = "ConfigurationSectionCacheHashInvalidationEventListener";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("c302261e-8f3d-4933-bbe5-b7b61ee66faa");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,189,83,193,106,219,64,16,61,219,224,127,24,148,139,92,138,116,79,227,64,234,26,106,104,218,130,155,246,80,66,89,239,142,165,109,229,93,177,35,169,152,144,127,239,104,215,82,227,180,137,177,10,61,45,187,243,222,155,121,163,39,35,182,72,165,144,8,159,208,57,65,118,83,37,115,107,54,58,171,157,168,180,53,147,241,221,100,60,170,73,155,236,0,226,48,89,152,74,87,26,233,213,49,64,178,104,208,84,45,142,145,103,14,51,214,133,121,33,136,206,225,160,217,10,101,123,204,133,204,241,173,160,124,105,26,81,104,229,107,94,227,157,166,10,13,58,175,148,166,41,92,80,189,221,10,183,187,220,223,123,6,18,200,135,210,64,65,27,100,43,14,57,171,3,223,86,59,186,182,170,46,240,5,224,126,90,144,185,48,25,38,93,135,244,81,139,11,66,20,5,89,144,14,55,179,232,121,207,201,107,65,232,223,118,7,6,34,72,91,189,175,127,41,197,43,30,112,43,222,243,151,129,25,68,253,132,209,244,246,68,198,66,233,106,0,203,67,79,231,125,214,36,78,103,45,205,23,235,126,148,5,71,48,144,203,122,93,104,9,178,141,199,192,116,192,57,60,177,118,214,191,243,217,25,149,78,55,156,18,112,40,148,53,197,14,150,7,189,250,38,55,101,27,38,7,223,228,227,151,25,24,252,9,207,178,226,105,200,124,31,250,107,172,114,171,56,246,31,189,203,80,244,161,210,38,71,167,43,101,229,62,87,79,56,72,62,152,32,174,34,159,160,110,95,182,225,28,106,133,208,88,173,160,7,197,118,253,157,215,198,233,55,10,221,75,8,138,87,27,30,206,203,94,185,140,0,167,208,254,228,163,209,154,123,254,110,16,119,36,108,109,112,249,143,29,36,225,236,109,199,1,120,63,204,215,27,44,240,168,175,61,104,144,175,142,251,159,125,45,13,161,59,106,172,67,13,114,214,147,255,209,218,25,211,67,84,249,22,222,30,62,77,198,247,191,0,151,67,215,55,49,6,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("fdddd35b-2cec-43ec-8ee6-0ee22ca07325"));
		}

		#endregion

	}

	#endregion

}

