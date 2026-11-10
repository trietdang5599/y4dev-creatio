namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: IStartDeduplicationRequestFactorySchema

	/// <exclude/>
	public class IStartDeduplicationRequestFactorySchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IStartDeduplicationRequestFactorySchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IStartDeduplicationRequestFactorySchema(IStartDeduplicationRequestFactorySchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("317ae3ca-74ff-401a-9e48-5d31d65af269");
			Name = "IStartDeduplicationRequestFactory";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("4c53ad23-c903-414d-89cd-b08703861304");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,141,146,65,79,2,49,16,133,207,144,240,31,38,120,209,196,236,222,21,73,20,53,217,139,49,96,226,185,108,103,177,97,183,93,103,166,70,98,252,239,182,91,64,8,16,189,237,155,153,247,246,107,59,86,53,200,173,42,17,94,144,72,177,171,36,155,56,91,153,133,39,37,198,217,236,30,181,111,107,83,118,106,208,255,26,244,123,158,141,93,192,94,227,161,86,44,166,204,94,113,126,219,154,24,33,164,74,225,108,138,239,30,89,248,122,208,15,206,51,194,69,152,134,194,10,82,21,126,123,5,197,157,175,151,123,89,83,95,227,99,48,59,90,117,166,60,207,97,196,190,105,20,173,198,107,253,76,238,195,104,100,104,80,222,156,134,202,17,204,189,169,117,36,99,81,36,65,214,75,208,187,193,64,9,38,219,132,230,59,169,173,159,135,57,48,27,50,40,102,49,102,159,44,249,183,112,189,120,27,7,124,93,97,66,168,36,240,253,135,229,16,38,85,90,69,170,1,27,158,232,102,200,88,70,219,83,16,195,241,44,137,174,149,141,242,110,238,184,205,88,141,159,201,84,196,207,19,22,66,241,100,121,60,251,139,118,148,111,70,163,247,228,13,173,143,127,178,127,206,66,221,75,253,158,234,18,214,181,45,242,69,216,153,222,119,218,27,180,58,173,78,148,161,246,3,80,207,48,174,184,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("317ae3ca-74ff-401a-9e48-5d31d65af269"));
		}

		#endregion

	}

	#endregion

}

