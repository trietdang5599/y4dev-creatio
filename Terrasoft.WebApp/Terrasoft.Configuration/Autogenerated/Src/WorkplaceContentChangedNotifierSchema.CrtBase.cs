namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: WorkplaceContentChangedNotifierSchema

	/// <exclude/>
	public class WorkplaceContentChangedNotifierSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public WorkplaceContentChangedNotifierSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public WorkplaceContentChangedNotifierSchema(WorkplaceContentChangedNotifierSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("4e1eb09a-725e-40f7-b51f-b222d3dfeaee");
			Name = "WorkplaceContentChangedNotifier";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("9229ed18-5614-47df-8744-72b0c7198840");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,149,84,75,107,219,64,16,62,43,144,255,48,184,23,9,130,116,207,195,208,42,77,240,33,78,33,41,57,132,80,182,210,72,94,178,15,177,15,23,17,252,223,59,218,149,29,23,90,41,5,93,102,103,118,190,199,236,8,64,49,137,182,99,21,194,35,26,195,172,110,92,94,106,213,240,214,27,230,184,86,167,39,111,167,39,137,183,92,181,240,208,91,135,242,226,16,151,218,96,126,195,42,167,13,71,251,126,126,220,74,74,173,254,150,185,67,107,89,75,103,239,53,84,85,20,5,92,90,47,37,51,253,114,140,87,178,19,40,81,57,75,41,68,168,12,54,87,139,213,147,54,175,157,32,230,68,215,81,182,220,48,213,98,189,214,142,55,28,205,162,88,230,251,134,197,81,199,231,107,108,152,23,238,11,87,53,161,167,174,239,80,55,233,92,187,236,12,214,100,21,92,193,98,14,56,123,33,152,206,255,20,188,130,74,48,107,97,230,6,156,195,28,60,117,124,11,6,37,159,12,182,52,22,184,225,40,106,123,14,223,12,223,50,135,49,217,197,0,12,178,90,43,209,195,234,1,205,22,77,41,56,245,188,239,48,206,244,0,252,195,78,165,135,177,37,1,19,85,29,97,255,228,64,92,173,51,126,152,63,17,9,138,71,30,81,253,140,168,52,131,225,109,37,201,52,13,242,188,28,108,140,15,173,207,111,209,93,78,235,90,166,89,224,190,251,47,54,51,94,77,114,252,176,146,121,195,119,115,174,223,161,219,232,48,250,35,199,195,59,231,106,131,134,187,90,87,80,44,143,148,111,53,175,33,128,244,233,173,231,245,243,11,120,34,178,170,237,158,247,24,230,229,6,171,215,207,166,245,195,190,173,189,16,247,230,171,236,92,159,14,255,9,90,147,253,181,232,111,178,101,6,100,88,228,97,51,20,254,130,99,15,163,172,42,72,188,102,142,141,88,201,65,247,35,237,222,196,70,45,206,98,253,247,8,74,149,35,124,56,222,93,124,192,241,124,84,61,146,204,254,237,240,112,74,223,111,193,94,214,232,18,5,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("4e1eb09a-725e-40f7-b51f-b222d3dfeaee"));
		}

		#endregion

	}

	#endregion

}

