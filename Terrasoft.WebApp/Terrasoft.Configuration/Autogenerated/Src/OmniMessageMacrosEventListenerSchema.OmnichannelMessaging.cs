namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: OmniMessageMacrosEventListenerSchema

	/// <exclude/>
	public class OmniMessageMacrosEventListenerSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public OmniMessageMacrosEventListenerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public OmniMessageMacrosEventListenerSchema(OmniMessageMacrosEventListenerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("55ba50f4-3ff7-4abc-96f1-1151a477c317");
			Name = "OmniMessageMacrosEventListener";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("08afff10-3d0c-4f3d-b6a0-28a42952a988");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,133,83,193,106,219,64,16,61,59,144,127,24,212,139,4,101,117,119,108,67,34,2,61,212,77,193,238,41,228,48,150,70,210,22,105,215,236,174,85,76,200,191,119,52,107,27,43,73,233,77,187,251,222,188,247,102,70,6,123,242,123,44,9,182,228,28,122,91,7,85,88,83,235,230,224,48,104,107,212,83,111,116,217,162,49,212,169,53,121,143,141,54,205,237,205,235,237,205,236,224,249,115,66,116,164,30,77,208,65,147,191,251,31,64,61,14,100,194,136,99,228,23,71,13,171,65,209,161,247,115,24,69,139,22,131,64,190,107,31,200,144,19,96,158,231,176,240,135,190,71,119,92,157,206,66,130,189,179,131,174,200,11,57,58,165,53,150,206,122,160,81,242,8,36,130,192,97,170,142,141,169,115,185,252,170,222,179,216,59,78,132,211,77,217,82,143,63,184,87,176,132,228,67,253,36,123,97,230,254,176,235,116,9,165,152,249,128,153,20,132,57,60,160,167,79,164,184,206,171,228,188,116,100,77,161,181,21,247,228,167,212,143,143,239,187,32,23,223,198,92,116,73,187,193,129,170,152,89,93,56,249,123,210,98,143,14,123,48,156,109,153,120,50,21,185,100,37,150,32,158,212,34,23,200,231,12,74,86,219,150,216,11,17,148,142,234,101,178,157,255,115,222,226,235,129,106,190,21,133,123,215,248,4,242,21,104,227,3,26,94,194,210,154,128,218,200,134,69,53,241,15,21,6,156,24,57,53,219,14,172,197,67,135,193,234,10,158,140,100,78,237,238,55,149,103,255,95,33,234,222,215,129,220,69,22,40,131,113,133,103,179,29,15,66,157,153,103,10,101,119,242,104,232,15,92,253,0,147,137,110,2,231,72,211,52,150,207,34,53,83,191,60,57,254,131,12,59,224,241,101,170,232,8,93,129,188,65,105,44,250,118,154,47,227,227,136,229,28,111,167,151,111,127,1,207,149,149,115,158,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("55ba50f4-3ff7-4abc-96f1-1151a477c317"));
		}

		#endregion

	}

	#endregion

}

