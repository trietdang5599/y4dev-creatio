namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: CompilationHistoryEventListenerSchema

	/// <exclude/>
	public class CompilationHistoryEventListenerSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public CompilationHistoryEventListenerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public CompilationHistoryEventListenerSchema(CompilationHistoryEventListenerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("043de0df-b9d3-4d42-8dee-a5975e1a3279");
			Name = "CompilationHistoryEventListener";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("9cc3d920-8a68-437c-9367-c8131a0a7723");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,205,82,207,75,195,48,20,62,111,176,255,225,49,47,45,72,123,223,84,112,117,224,64,157,184,121,18,15,89,242,214,70,218,164,36,89,231,24,251,223,77,147,42,86,55,134,7,97,183,54,239,123,223,47,30,8,82,160,46,9,69,152,163,82,68,203,165,137,18,41,150,60,93,41,98,184,20,189,238,182,215,237,172,52,23,105,11,82,20,82,12,247,78,20,70,99,97,184,225,168,143,2,162,113,133,194,212,56,139,60,83,152,90,69,72,114,162,245,0,172,70,201,115,103,226,150,107,35,213,198,129,239,236,55,10,84,110,229,197,17,181,7,193,140,102,88,144,7,155,12,46,161,255,155,166,31,190,218,213,114,181,200,57,5,90,139,29,211,130,1,140,136,198,61,98,150,104,235,156,124,185,191,71,147,73,102,253,63,42,94,17,131,126,90,250,31,208,198,138,80,168,36,103,48,207,148,92,63,33,97,82,228,155,241,59,197,178,214,15,228,226,13,169,1,141,130,161,10,161,174,191,211,169,136,2,237,114,37,196,193,108,180,32,240,134,194,6,26,249,224,81,131,24,186,69,83,139,128,192,53,76,29,239,68,215,138,211,61,138,117,97,131,182,72,232,56,118,77,64,171,226,51,30,10,236,26,245,195,56,142,225,130,139,12,21,55,76,82,136,175,92,11,190,115,89,217,107,224,12,125,13,83,113,131,57,26,123,37,237,232,231,224,227,141,112,105,79,198,181,126,173,82,13,248,217,201,129,254,154,54,190,91,255,147,155,137,208,168,78,199,206,115,201,200,233,184,153,145,234,63,189,252,184,49,255,218,126,220,125,0,134,49,135,215,180,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("043de0df-b9d3-4d42-8dee-a5975e1a3279"));
		}

		#endregion

	}

	#endregion

}

