namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: SysSettingsRightsEventListenerSchema

	/// <exclude/>
	public class SysSettingsRightsEventListenerSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public SysSettingsRightsEventListenerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public SysSettingsRightsEventListenerSchema(SysSettingsRightsEventListenerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("42f59b37-f248-46d7-8658-207f7a813139");
			Name = "SysSettingsRightsEventListener";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,149,82,77,107,131,64,16,61,27,200,127,24,146,75,2,65,239,105,90,104,37,183,182,148,38,61,149,30,54,58,209,5,221,149,221,213,98,67,255,123,199,181,6,53,218,143,211,50,31,239,205,123,51,43,88,138,58,99,1,194,30,149,98,90,30,141,235,75,113,228,81,174,152,225,82,76,39,167,233,196,201,53,23,81,167,69,225,213,72,222,221,10,195,13,71,253,107,131,187,45,80,152,86,95,85,221,149,122,135,198,80,168,225,186,143,236,72,115,91,173,163,28,207,60,138,205,127,152,106,0,241,17,227,92,97,68,101,240,19,166,245,26,46,186,172,254,123,174,13,10,84,22,225,121,30,108,116,158,166,76,149,55,223,177,69,67,166,100,193,67,212,128,214,52,196,76,132,73,37,248,40,21,232,146,56,82,208,141,113,101,233,221,134,208,107,49,190,218,237,149,157,209,139,93,16,99,202,30,233,152,228,116,118,161,115,182,124,35,100,150,31,18,30,64,96,229,252,236,5,214,112,199,116,123,143,157,242,102,112,201,149,186,147,221,194,121,113,15,104,98,25,210,234,158,148,52,24,24,12,235,122,214,132,32,11,186,11,237,101,228,110,190,66,102,176,170,213,182,23,47,26,21,221,78,16,186,26,144,119,194,37,84,159,213,113,20,154,92,9,16,248,62,76,187,232,193,170,223,227,124,142,74,43,36,15,225,54,48,57,75,248,199,159,197,172,192,106,113,134,141,5,103,150,21,212,175,79,63,34,194,125,153,33,96,47,209,248,234,81,185,103,77,131,182,86,157,33,23,156,109,211,115,20,97,125,50,27,215,217,110,146,114,240,5,27,233,210,109,46,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("42f59b37-f248-46d7-8658-207f7a813139"));
		}

		#endregion

	}

	#endregion

}

