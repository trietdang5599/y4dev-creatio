namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: OmniAfterDeduplicationActionSchema

	/// <exclude/>
	public class OmniAfterDeduplicationActionSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public OmniAfterDeduplicationActionSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public OmniAfterDeduplicationActionSchema(OmniAfterDeduplicationActionSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("a70187d1-6bbf-4710-ba7a-8c8f800e7324");
			Name = "OmniAfterDeduplicationAction";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("08afff10-3d0c-4f3d-b6a0-28a42952a988");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,141,82,203,106,195,48,16,60,59,208,127,216,166,151,228,98,223,243,130,144,166,144,67,218,64,219,15,80,229,181,45,176,100,179,146,66,67,233,191,87,146,29,98,155,36,244,98,216,209,236,204,104,44,171,133,202,225,3,137,152,174,50,19,111,42,149,137,220,18,51,162,82,241,51,166,182,46,5,15,211,252,97,100,239,178,223,164,18,188,96,74,97,25,239,81,107,150,59,246,213,45,194,27,112,188,85,70,24,129,218,157,63,140,158,8,115,39,12,155,146,105,61,3,175,191,206,12,82,47,214,154,251,175,167,215,246,203,129,192,61,251,46,25,102,176,187,45,244,227,181,162,179,247,129,170,26,201,71,154,193,33,24,132,227,214,235,83,35,185,18,20,54,186,131,209,41,69,81,142,102,14,53,137,35,51,8,218,13,14,252,109,44,80,165,141,139,31,59,158,78,66,27,178,220,84,116,213,245,222,221,38,131,12,182,55,78,155,76,3,206,114,192,250,71,196,61,154,162,74,251,233,146,36,129,133,182,82,50,58,173,218,185,151,16,120,37,235,18,93,15,238,149,164,37,82,124,222,74,6,107,139,154,17,147,160,152,196,229,88,34,229,152,134,151,113,26,175,246,97,2,66,109,75,3,24,208,120,145,132,133,213,165,163,99,37,82,216,126,35,183,6,39,205,46,116,133,218,38,68,6,147,46,28,191,243,2,37,123,117,198,240,184,132,177,43,197,48,110,198,45,61,34,52,150,66,65,190,161,40,234,188,249,150,186,75,125,166,76,184,219,189,148,86,23,45,172,55,204,41,15,254,206,244,86,211,1,187,64,127,98,46,210,84,166,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("a70187d1-6bbf-4710-ba7a-8c8f800e7324"));
		}

		#endregion

	}

	#endregion

}

