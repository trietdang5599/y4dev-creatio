namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: IBulkDeduplicationTaskClientSchema

	/// <exclude/>
	public class IBulkDeduplicationTaskClientSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IBulkDeduplicationTaskClientSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IBulkDeduplicationTaskClientSchema(IBulkDeduplicationTaskClientSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("fef75578-f348-4491-a5ba-51e5ae6801c5");
			Name = "IBulkDeduplicationTaskClient";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("4c53ad23-c903-414d-89cd-b08703861304");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,229,147,77,79,195,48,12,134,207,76,218,127,176,198,5,36,212,222,249,24,2,134,208,46,8,193,36,206,222,234,142,136,54,169,98,7,49,33,254,59,110,218,178,141,242,121,230,22,59,126,236,55,118,108,177,36,174,112,65,48,35,239,145,93,46,201,133,179,185,89,6,143,98,156,77,38,148,133,170,48,139,104,13,7,47,195,193,78,96,99,151,176,117,113,89,32,139,89,36,19,87,162,249,0,37,51,228,199,163,239,185,123,154,159,85,166,46,45,30,23,194,201,173,202,114,150,73,57,37,119,61,45,53,26,166,86,200,231,42,247,16,166,231,161,120,220,202,85,151,185,40,12,89,137,76,154,166,112,204,161,44,209,175,198,173,125,227,221,147,201,136,1,129,73,192,229,144,109,102,0,209,20,12,37,90,92,82,169,137,160,36,121,112,25,39,208,37,76,55,50,86,97,174,36,152,78,212,15,154,118,94,162,174,158,176,232,184,37,241,134,158,84,90,173,1,88,80,2,195,124,5,138,26,89,129,213,65,1,218,76,171,101,244,28,205,164,99,167,121,3,101,78,113,235,4,232,217,176,48,120,146,224,173,186,66,81,188,7,111,189,160,241,84,232,177,140,41,79,70,77,185,107,61,143,198,151,235,210,201,113,26,163,62,135,162,166,134,153,174,229,245,144,86,207,120,210,235,121,251,94,69,186,152,26,234,117,242,46,70,157,194,21,201,23,119,123,172,109,212,79,182,126,198,1,180,174,119,145,251,71,191,154,131,126,195,128,69,35,239,223,204,193,183,107,247,211,36,186,245,172,71,113,22,27,213,11,249,195,40,94,155,37,39,155,53,123,94,155,175,111,165,211,169,59,155,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("fef75578-f348-4491-a5ba-51e5ae6801c5"));
		}

		#endregion

	}

	#endregion

}

