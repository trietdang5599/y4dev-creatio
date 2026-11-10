namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: IBulkDeduplicationSchedulerSchema

	/// <exclude/>
	public class IBulkDeduplicationSchedulerSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IBulkDeduplicationSchedulerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IBulkDeduplicationSchedulerSchema(IBulkDeduplicationSchedulerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("ddfb5587-be3e-400d-bba5-ff6929417fb9");
			Name = "IBulkDeduplicationScheduler";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("4c53ad23-c903-414d-89cd-b08703861304");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,141,147,77,79,195,48,12,134,207,171,180,255,96,109,23,184,180,247,49,118,128,93,134,4,154,216,238,40,109,220,54,208,38,85,146,130,166,137,255,78,62,150,118,31,133,113,169,98,199,126,243,248,149,203,73,141,170,33,25,194,22,165,36,74,228,58,126,20,60,103,69,43,137,102,130,199,75,164,109,83,177,204,69,227,104,63,142,70,83,137,133,9,96,197,53,202,220,52,207,224,109,245,208,86,31,39,181,27,36,50,43,55,89,105,146,21,202,113,100,58,147,36,129,185,106,235,154,200,221,226,16,191,98,35,81,33,215,10,8,168,80,14,185,144,80,19,78,10,198,11,8,178,168,64,57,89,120,23,169,138,131,98,114,36,217,180,169,41,5,22,216,96,128,172,103,26,237,29,87,55,210,51,234,82,80,53,131,181,147,241,151,231,212,46,17,68,44,245,32,30,124,49,93,218,145,26,204,88,206,144,66,67,164,177,219,112,197,157,106,114,46,59,119,69,192,77,225,253,164,215,13,175,81,239,234,58,40,77,22,219,18,123,97,16,57,104,147,8,54,14,144,89,95,45,157,210,68,106,227,109,60,79,92,187,35,248,20,140,118,147,249,167,158,68,122,179,188,202,1,215,81,111,239,254,112,115,137,21,106,60,222,128,95,76,77,119,39,150,30,110,108,83,77,156,107,255,245,214,183,188,152,179,247,240,82,169,179,138,90,56,251,47,92,88,229,177,123,163,148,150,118,93,123,237,48,244,20,57,245,43,230,226,111,247,61,78,154,204,15,217,149,162,53,140,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("ddfb5587-be3e-400d-bba5-ff6929417fb9"));
		}

		#endregion

	}

	#endregion

}

