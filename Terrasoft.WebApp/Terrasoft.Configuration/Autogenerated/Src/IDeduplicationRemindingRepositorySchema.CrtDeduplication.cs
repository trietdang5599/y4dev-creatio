namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: IDeduplicationRemindingRepositorySchema

	/// <exclude/>
	public class IDeduplicationRemindingRepositorySchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IDeduplicationRemindingRepositorySchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IDeduplicationRemindingRepositorySchema(IDeduplicationRemindingRepositorySchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("de0d4303-7aff-4f8a-be80-67a2241441e9");
			Name = "IDeduplicationRemindingRepository";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("4c53ad23-c903-414d-89cd-b08703861304");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,141,146,77,110,194,48,16,133,215,32,113,135,81,86,173,132,146,3,52,205,6,54,221,84,21,148,3,56,241,36,24,213,118,52,182,145,80,197,221,59,14,33,36,5,85,221,121,254,222,124,243,100,35,52,186,86,84,8,159,72,36,156,173,125,186,178,166,86,77,32,225,149,53,233,26,101,104,191,84,213,69,139,249,247,98,62,11,78,153,102,50,64,248,178,152,115,37,203,50,200,93,208,90,208,169,232,227,15,178,71,37,209,129,70,191,183,18,106,75,160,133,17,77,20,145,99,117,32,212,202,72,206,187,244,42,150,141,212,218,80,114,43,40,227,145,234,200,252,54,129,219,92,167,55,216,90,167,188,165,19,15,69,224,59,174,46,177,34,20,158,185,186,173,29,77,121,130,70,29,113,4,194,128,174,34,213,70,253,37,184,80,30,176,242,32,140,156,146,95,37,93,181,71,45,192,176,171,233,176,55,251,189,56,111,5,9,221,117,189,38,193,33,177,227,134,117,89,40,41,118,28,67,53,36,210,60,235,186,31,15,15,156,235,27,102,82,108,30,209,255,83,104,123,57,113,44,210,95,253,183,192,229,242,119,126,39,197,118,228,194,120,232,104,149,236,93,31,212,159,118,147,251,97,106,7,91,238,41,50,60,58,244,190,216,195,47,227,178,89,95,188,129,61,243,31,157,157,227,63,61,255,0,218,147,52,42,247,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("de0d4303-7aff-4f8a-be80-67a2241441e9"));
		}

		#endregion

	}

	#endregion

}

