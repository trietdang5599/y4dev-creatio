namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: SysSettingsValueEventListenerSchema

	/// <exclude/>
	public class SysSettingsValueEventListenerSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public SysSettingsValueEventListenerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public SysSettingsValueEventListenerSchema(SysSettingsValueEventListenerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("b87f92fc-2bfc-4aea-b3b7-8872e42ad5ac");
			Name = "SysSettingsValueEventListener";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,149,146,77,75,195,64,16,134,207,41,244,63,12,237,165,133,146,220,107,21,52,244,166,34,180,122,17,15,107,50,77,23,146,221,176,179,27,137,197,255,238,238,198,148,36,182,126,156,194,124,61,121,223,153,21,172,64,42,89,130,176,69,165,24,201,157,14,99,41,118,60,51,138,105,46,197,120,116,24,143,2,67,92,100,189,22,133,23,103,242,225,90,104,174,57,210,175,13,225,186,66,161,59,125,174,186,169,105,131,90,219,144,224,114,56,217,147,22,118,90,207,50,158,88,110,240,31,32,223,111,105,150,55,85,152,217,42,196,57,35,90,194,176,201,139,191,229,164,81,160,242,3,81,20,193,138,76,81,48,85,95,125,197,126,24,74,37,43,158,34,1,122,199,176,103,34,205,157,218,157,84,64,181,101,20,64,173,235,202,209,41,108,129,81,135,248,236,87,87,247,126,61,219,36,123,44,216,189,189,164,245,57,25,202,156,204,95,236,96,105,94,115,158,64,226,213,252,232,4,150,112,195,168,187,194,94,121,117,106,191,78,218,193,175,224,184,180,59,212,123,153,218,181,61,40,169,49,209,152,54,245,178,13,65,86,246,36,118,41,167,47,22,43,100,26,93,169,177,60,123,36,84,246,106,194,14,59,190,233,133,115,112,175,52,8,20,106,163,4,8,124,59,73,157,13,166,220,171,9,62,206,10,171,36,79,225,58,209,134,229,252,253,207,90,22,94,73,112,210,85,114,100,44,160,249,198,246,41,100,184,173,75,4,28,36,90,83,3,82,120,84,228,153,52,48,181,232,253,228,27,179,107,121,138,34,109,206,229,227,38,219,79,218,28,124,2,2,227,211,56,36,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("b87f92fc-2bfc-4aea-b3b7-8872e42ad5ac"));
		}

		#endregion

	}

	#endregion

}

