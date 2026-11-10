namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: DcmSchemaManagerCacheResetMonitorSchema

	/// <exclude/>
	public class DcmSchemaManagerCacheResetMonitorSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public DcmSchemaManagerCacheResetMonitorSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public DcmSchemaManagerCacheResetMonitorSchema(DcmSchemaManagerCacheResetMonitorSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("7423b104-b70f-44cd-84df-a49eeb7f38d6");
			Name = "DcmSchemaManagerCacheResetMonitor";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("c302261e-8f3d-4933-bbe5-b7b61ee66faa");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,197,82,77,111,163,48,16,61,83,169,255,97,196,94,140,20,241,3,154,166,85,75,191,162,42,217,42,164,123,169,170,149,11,3,177,4,54,178,77,86,81,213,255,190,182,33,89,40,66,201,109,79,48,227,153,121,239,205,60,78,75,84,21,77,16,214,40,37,85,34,211,97,36,120,198,242,90,82,205,4,15,239,146,50,78,54,88,210,5,229,52,71,25,81,19,173,80,161,94,8,206,180,144,231,103,159,231,103,94,173,24,207,33,222,41,141,229,244,16,119,135,74,28,203,135,81,193,144,107,55,121,180,230,129,38,6,140,161,50,21,166,230,135,196,220,208,131,168,160,74,93,192,9,44,77,211,219,29,102,180,46,244,45,227,169,129,32,122,87,161,200,200,220,42,238,183,111,40,207,113,110,180,180,237,193,4,150,102,85,48,3,255,40,148,31,188,27,172,170,254,40,88,2,137,229,119,156,30,92,192,9,44,224,211,201,56,136,127,96,88,164,70,253,139,100,91,170,177,121,172,154,0,18,193,149,6,165,165,93,102,59,113,76,131,63,237,118,206,59,247,136,13,44,194,239,228,91,102,218,18,65,158,54,92,250,196,94,164,168,80,106,115,173,17,114,67,136,65,98,118,53,132,181,35,188,235,107,32,131,23,163,202,89,161,177,201,46,124,68,125,57,0,185,34,65,112,132,249,2,245,70,140,238,116,43,88,10,175,85,106,254,221,212,39,170,54,36,176,103,49,188,190,163,133,49,106,91,240,139,22,53,146,200,158,131,114,173,194,85,205,53,43,177,57,128,43,167,31,133,27,229,130,103,220,77,220,60,239,177,102,105,184,196,63,246,75,130,112,45,98,119,76,226,47,125,167,195,243,190,78,21,227,204,216,106,105,140,233,164,252,228,141,199,82,210,250,164,252,231,147,9,220,111,141,158,27,153,43,192,253,223,94,43,203,128,244,60,53,235,182,238,171,188,193,170,28,107,75,251,192,189,79,103,133,165,216,254,79,58,221,85,182,185,254,118,191,254,2,102,8,224,122,51,5,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("7423b104-b70f-44cd-84df-a49eeb7f38d6"));
		}

		#endregion

	}

	#endregion

}

