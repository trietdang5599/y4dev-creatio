namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: PortalColumnAccessListEventListenerSchema

	/// <exclude/>
	public class PortalColumnAccessListEventListenerSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public PortalColumnAccessListEventListenerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public PortalColumnAccessListEventListenerSchema(PortalColumnAccessListEventListenerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("67f28e51-44e9-4af8-8454-8ad240db235e");
			Name = "PortalColumnAccessListEventListener";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("d7352345-17a4-46e8-b32e-306ac0453d7a");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,229,83,77,139,219,48,16,61,103,97,255,195,224,61,108,2,69,190,103,147,64,234,46,244,208,143,5,111,79,165,135,137,60,118,84,228,81,144,228,148,176,244,191,87,150,226,101,19,156,118,233,169,208,155,53,154,247,230,205,123,22,99,75,110,135,146,224,145,172,69,103,106,47,10,195,181,106,58,139,94,25,190,190,122,186,190,154,116,78,113,115,210,98,233,238,66,93,220,179,87,94,145,251,99,131,184,223,19,251,203,125,165,79,99,194,253,141,165,38,168,129,66,163,115,115,120,48,214,163,46,140,238,90,94,75,73,206,125,80,206,71,186,254,131,152,108,132,229,121,14,11,215,181,45,218,195,234,120,30,26,160,54,22,110,199,153,110,129,122,141,7,160,168,80,12,84,249,25,215,194,17,161,118,6,164,165,122,153,253,126,79,241,22,29,197,218,225,68,105,6,121,207,247,117,228,106,90,202,45,181,248,41,164,4,75,200,198,197,102,179,111,1,190,235,54,90,73,144,189,65,175,241,7,230,112,65,79,32,123,138,238,61,187,254,145,252,214,84,189,239,113,72,186,60,247,54,22,222,35,87,154,220,96,95,137,123,170,146,137,226,25,147,159,131,22,59,180,216,2,135,45,151,153,35,174,130,39,171,40,9,210,73,44,242,216,50,142,160,108,245,184,165,152,197,144,195,252,98,18,81,215,186,246,100,227,128,181,109,92,239,63,40,118,30,57,188,3,105,216,163,226,254,119,244,91,26,6,198,21,160,66,143,39,90,142,166,155,125,24,167,42,130,189,81,21,124,230,184,246,212,108,190,147,28,86,120,3,99,163,129,102,208,191,175,201,100,19,178,16,3,114,128,208,236,46,94,38,40,236,94,164,26,126,135,105,42,207,82,119,234,44,203,135,146,100,103,251,76,185,81,76,162,208,132,182,192,240,31,85,107,173,205,15,170,18,129,155,190,164,19,95,28,217,240,240,57,40,14,137,167,185,63,95,31,244,59,210,228,255,199,168,143,139,255,85,216,3,246,223,138,251,38,240,167,119,31,207,169,122,90,12,181,95,200,88,189,61,57,6,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("67f28e51-44e9-4af8-8454-8ad240db235e"));
		}

		#endregion

	}

	#endregion

}

