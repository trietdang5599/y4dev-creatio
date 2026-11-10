namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: OmniChangeOrgStructureListenerSchema

	/// <exclude/>
	public class OmniChangeOrgStructureListenerSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public OmniChangeOrgStructureListenerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public OmniChangeOrgStructureListenerSchema(OmniChangeOrgStructureListenerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("bdfb2777-0dc2-4c71-93b6-742cd8628392");
			Name = "OmniChangeOrgStructureListener";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("01343ce8-0448-497f-b2c3-9511b4580fa3");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,173,83,193,110,219,48,12,61,167,64,255,129,232,46,9,48,56,247,102,43,208,101,25,16,96,93,134,165,61,13,59,40,50,99,107,176,169,128,146,189,101,69,254,125,180,100,55,118,151,162,221,176,75,34,81,36,31,223,227,51,169,18,221,78,105,132,91,100,86,206,110,125,50,183,180,53,89,197,202,27,75,201,170,36,163,115,69,132,69,114,131,206,169,204,80,118,126,118,127,126,54,170,156,28,97,189,119,30,203,217,195,189,223,136,49,89,144,55,222,160,123,54,33,89,212,72,190,201,147,204,87,140,153,160,195,188,80,206,93,66,51,196,92,134,200,112,197,217,218,115,165,125,197,248,209,8,50,33,135,138,233,116,10,111,92,85,150,138,247,87,237,189,75,128,173,101,176,156,41,50,191,2,43,85,128,235,186,128,14,141,29,120,11,186,64,37,153,71,202,160,149,206,101,182,14,96,218,67,248,26,38,223,135,177,59,164,241,90,210,75,245,73,100,133,183,112,33,218,220,57,228,37,125,177,5,94,76,190,189,184,234,67,69,186,169,89,146,16,62,22,239,170,77,97,180,140,41,170,60,35,10,92,194,59,229,240,4,154,244,185,15,146,61,168,124,131,62,183,169,232,252,153,77,173,60,198,215,93,188,136,82,162,153,134,218,154,84,246,33,2,205,27,77,198,177,51,96,248,155,64,99,136,209,200,243,190,61,141,106,81,178,18,242,98,39,66,221,168,46,220,98,118,114,55,136,207,142,5,34,187,95,237,80,188,103,35,140,212,16,254,128,249,227,248,120,216,122,210,246,248,163,62,233,77,60,121,2,232,150,21,185,45,242,90,206,167,0,7,239,47,0,30,228,159,24,224,32,174,242,58,135,241,226,167,198,93,232,210,138,118,104,126,15,237,114,144,210,184,159,167,150,21,204,16,31,131,57,13,229,200,198,167,86,195,244,42,108,48,218,197,214,242,197,153,20,227,10,87,180,36,161,224,49,29,219,205,119,97,1,78,144,144,95,67,220,232,245,214,35,7,195,92,115,230,0,187,217,54,226,166,164,87,220,85,97,203,170,81,53,174,87,36,108,221,49,137,73,49,161,39,68,107,154,89,143,238,95,49,120,143,5,254,43,129,174,246,63,207,255,104,93,49,58,12,30,126,3,195,203,91,118,110,5,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("bdfb2777-0dc2-4c71-93b6-742cd8628392"));
		}

		#endregion

	}

	#endregion

}

