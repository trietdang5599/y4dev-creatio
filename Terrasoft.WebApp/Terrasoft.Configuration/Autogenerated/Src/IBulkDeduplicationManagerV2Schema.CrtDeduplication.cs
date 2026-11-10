namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: IBulkDeduplicationManagerV2Schema

	/// <exclude/>
	public class IBulkDeduplicationManagerV2Schema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IBulkDeduplicationManagerV2Schema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IBulkDeduplicationManagerV2Schema(IBulkDeduplicationManagerV2Schema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("3b690585-6925-4a7e-949f-0578a80311b8");
			Name = "IBulkDeduplicationManagerV2";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("4c53ad23-c903-414d-89cd-b08703861304");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,181,84,75,79,220,48,16,62,131,196,127,24,45,23,144,170,68,234,17,182,57,176,108,87,123,160,69,60,122,247,38,147,212,37,113,82,143,93,41,66,252,247,78,236,205,115,105,68,145,56,68,242,60,190,153,111,62,59,163,68,129,84,137,24,225,1,181,22,84,166,38,88,149,42,149,153,213,194,200,82,5,215,152,216,42,151,177,179,78,142,159,79,142,143,44,73,149,193,125,77,6,139,203,137,205,232,60,199,184,73,166,96,131,10,181,140,57,135,179,78,53,102,236,133,173,50,168,83,110,121,1,219,43,155,63,141,26,220,8,37,50,212,63,62,59,72,24,134,176,36,91,20,66,215,209,222,110,32,144,12,49,80,120,16,200,182,114,208,98,195,1,184,178,59,70,244,73,115,221,97,134,27,151,122,118,236,186,137,110,208,252,44,19,186,128,91,215,194,7,167,220,157,99,131,134,32,211,165,173,8,202,20,218,226,8,168,140,52,18,41,232,160,225,20,187,172,132,22,5,40,190,177,47,11,119,70,158,132,22,209,109,119,134,114,247,139,181,15,150,161,139,247,80,141,198,106,69,209,102,174,245,50,108,211,26,156,27,191,77,34,7,188,227,167,194,215,138,205,24,190,210,247,180,79,57,123,213,235,200,17,244,124,207,155,23,115,52,175,80,71,142,96,87,123,189,62,88,152,235,87,58,30,234,177,110,164,170,87,185,100,205,38,218,52,196,59,215,122,47,233,85,237,98,103,51,177,119,233,99,149,252,109,17,52,198,165,78,8,36,127,169,46,11,160,10,99,153,74,76,134,10,114,244,173,226,185,167,80,127,227,243,34,242,179,186,192,161,108,67,80,223,106,155,176,232,143,67,110,32,120,169,212,255,150,253,241,127,7,25,223,201,118,173,108,129,90,236,114,92,110,172,76,162,70,30,95,243,206,151,100,74,95,185,224,224,149,146,209,205,182,234,71,253,4,135,101,70,51,157,95,206,252,209,43,161,98,204,39,11,201,8,122,122,171,230,228,151,165,23,253,222,27,135,170,255,41,101,178,239,53,218,73,15,220,169,29,105,80,169,165,124,138,42,241,75,202,217,47,126,17,143,156,47,127,1,171,91,207,183,3,6,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("3b690585-6925-4a7e-949f-0578a80311b8"));
		}

		#endregion

	}

	#endregion

}

