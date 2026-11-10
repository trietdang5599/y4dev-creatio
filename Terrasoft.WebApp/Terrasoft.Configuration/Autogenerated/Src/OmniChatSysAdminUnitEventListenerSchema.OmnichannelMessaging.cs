namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: OmniChatSysAdminUnitEventListenerSchema

	/// <exclude/>
	public class OmniChatSysAdminUnitEventListenerSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public OmniChatSysAdminUnitEventListenerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public OmniChatSysAdminUnitEventListenerSchema(OmniChatSysAdminUnitEventListenerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("ceedabab-ed65-4dad-9918-f7388dcfce4f");
			Name = "OmniChatSysAdminUnitEventListener";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("08afff10-3d0c-4f3d-b6a0-28a42952a988");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,133,146,193,74,195,64,16,134,207,41,244,29,134,122,73,64,246,1,90,42,212,224,65,176,42,212,122,17,15,219,236,36,89,73,102,235,238,166,182,148,190,187,147,221,90,45,40,94,66,242,79,102,190,127,255,29,146,45,186,181,44,16,158,208,90,233,76,233,69,110,168,212,85,103,165,215,134,196,67,75,186,168,37,17,54,98,142,206,201,74,83,53,28,236,135,131,164,115,252,10,139,157,243,216,138,59,77,239,147,147,152,27,139,226,134,188,246,26,221,31,178,184,217,32,249,190,202,245,11,139,21,227,32,111,164,115,99,232,169,121,45,61,15,159,169,86,211,146,180,15,191,223,105,166,17,218,208,244,18,70,237,206,10,233,162,168,177,149,247,124,48,152,194,232,231,128,81,246,202,77,235,110,213,232,2,138,30,244,63,7,198,112,45,29,254,2,226,81,251,224,226,228,125,142,190,54,138,221,63,6,68,44,30,113,102,195,249,106,133,176,49,90,193,3,45,215,74,122,84,169,89,189,97,225,193,33,41,180,151,16,57,179,210,163,13,176,153,173,28,96,6,125,220,73,178,98,39,226,187,247,171,9,179,73,40,235,18,82,20,115,163,116,169,81,229,166,233,90,122,150,77,199,81,207,104,151,110,97,122,5,91,17,147,137,209,228,93,227,59,139,183,106,148,125,49,146,141,180,128,193,6,231,151,70,67,89,68,69,76,66,248,1,63,214,34,110,5,206,101,97,141,91,120,190,226,52,246,139,165,67,203,219,68,124,66,206,39,19,121,131,210,230,146,47,40,61,90,62,244,207,195,49,70,102,196,36,195,119,84,207,69,214,62,1,38,148,175,193,178,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("ceedabab-ed65-4dad-9918-f7388dcfce4f"));
		}

		#endregion

	}

	#endregion

}

