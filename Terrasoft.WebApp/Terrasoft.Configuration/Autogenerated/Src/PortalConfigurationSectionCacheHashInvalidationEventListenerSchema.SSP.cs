namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: PortalConfigurationSectionCacheHashInvalidationEventListenerSchema

	/// <exclude/>
	public class PortalConfigurationSectionCacheHashInvalidationEventListenerSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public PortalConfigurationSectionCacheHashInvalidationEventListenerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public PortalConfigurationSectionCacheHashInvalidationEventListenerSchema(PortalConfigurationSectionCacheHashInvalidationEventListenerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("54cef7a1-963d-4fb0-a8c8-29a776adcccb");
			Name = "PortalConfigurationSectionCacheHashInvalidationEventListener";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("6e774b28-4cf2-458d-872b-08ef49cd87a7");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,165,146,193,74,196,64,12,134,207,45,244,29,66,189,232,165,189,175,187,30,44,11,46,184,139,80,111,226,33,78,211,118,96,58,179,76,166,11,69,246,221,157,105,171,88,81,15,122,26,66,242,127,249,147,12,104,236,136,143,40,8,30,201,90,100,83,187,172,48,186,150,77,111,209,73,163,147,248,53,137,163,158,165,110,22,37,150,178,173,118,210,73,226,108,123,34,237,248,58,137,125,229,133,165,198,203,160,80,200,188,130,7,99,29,170,5,177,36,17,158,2,69,75,119,200,237,78,159,80,201,106,204,141,164,123,201,142,52,217,145,151,231,57,172,185,239,58,180,195,205,28,127,40,136,65,124,70,3,79,108,16,1,14,173,167,131,143,202,129,247,166,234,21,141,142,135,157,158,92,1,205,3,128,104,81,55,148,189,183,203,191,244,91,51,17,42,54,32,44,213,155,244,247,53,100,183,200,115,163,197,52,41,228,129,247,244,77,234,178,244,110,59,60,248,91,192,6,210,31,236,166,87,207,94,127,236,95,148,20,32,194,122,255,185,221,40,90,193,159,181,225,87,156,167,139,147,174,166,163,135,240,252,6,12,202,208,30,83,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("54cef7a1-963d-4fb0-a8c8-29a776adcccb"));
		}

		#endregion

	}

	#endregion

}

