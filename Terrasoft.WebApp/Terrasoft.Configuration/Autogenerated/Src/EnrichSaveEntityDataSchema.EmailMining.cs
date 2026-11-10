namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: EnrichSaveEntityDataSchema

	/// <exclude/>
	public class EnrichSaveEntityDataSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public EnrichSaveEntityDataSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public EnrichSaveEntityDataSchema(EnrichSaveEntityDataSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("8a0b8b3a-216a-4b0e-a0df-953fd0dac922");
			Name = "EnrichSaveEntityData";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("c9ff5cbb-cb0e-4041-b483-395260757ab0");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,157,146,77,107,2,49,16,134,207,10,254,135,65,47,45,148,221,187,85,47,186,148,82,218,74,45,189,136,135,152,29,53,116,147,72,146,149,110,165,255,189,147,100,21,149,126,160,183,204,204,59,147,103,62,20,147,104,215,140,35,188,162,49,204,234,133,75,134,90,45,196,178,52,204,9,173,90,205,109,171,217,40,173,80,75,152,84,214,161,164,120,81,32,247,65,155,220,161,66,35,248,237,169,230,165,84,78,72,76,38,20,101,133,248,12,181,72,69,186,142,193,37,25,48,44,152,181,93,200,20,229,175,38,108,131,25,165,184,106,196,28,11,186,52,77,161,103,75,41,153,169,6,181,61,54,122,35,114,180,144,147,10,184,86,142,113,7,107,163,215,244,143,35,255,92,168,220,99,44,180,1,12,149,49,167,7,21,22,20,181,108,67,193,100,87,60,61,168,62,245,255,82,231,206,80,197,25,57,214,229,188,16,28,184,167,252,5,178,177,13,160,251,142,198,129,195,255,212,133,113,72,143,241,211,78,106,7,34,112,131,139,126,59,214,156,16,171,100,217,135,67,101,169,90,52,219,233,0,20,237,40,217,167,29,66,71,234,71,148,115,52,87,79,36,131,62,180,67,183,149,183,218,215,190,145,93,39,214,25,63,153,108,31,6,191,217,70,99,137,238,54,60,108,253,248,250,131,250,158,150,91,143,17,180,201,209,156,1,22,244,199,76,66,57,120,246,238,139,89,184,46,74,169,96,195,138,18,237,25,48,49,225,152,102,36,194,85,83,90,47,14,235,166,30,218,0,222,130,252,18,202,236,67,88,231,199,69,247,41,233,4,145,25,190,170,177,207,1,126,199,106,24,147,126,90,235,116,6,15,123,193,63,152,29,84,121,188,216,96,71,239,177,147,124,223,101,139,56,104,26,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("8a0b8b3a-216a-4b0e-a0df-953fd0dac922"));
		}

		#endregion

	}

	#endregion

}

