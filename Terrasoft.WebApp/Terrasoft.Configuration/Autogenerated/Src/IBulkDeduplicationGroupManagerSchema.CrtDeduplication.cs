namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: IBulkDeduplicationGroupManagerSchema

	/// <exclude/>
	public class IBulkDeduplicationGroupManagerSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IBulkDeduplicationGroupManagerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IBulkDeduplicationGroupManagerSchema(IBulkDeduplicationGroupManagerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("4f12816d-d543-4f86-9793-07195211c781");
			Name = "IBulkDeduplicationGroupManager";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("dcfefe5b-65e2-4411-92b0-7b05d81d9c9b");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,133,144,193,106,195,48,16,68,207,54,248,31,22,114,105,33,216,247,180,20,218,4,130,161,9,133,166,31,160,68,107,85,196,146,92,105,247,96,66,254,189,178,212,20,247,212,227,172,244,118,102,7,172,48,24,6,113,66,56,160,247,34,184,142,234,181,179,157,86,236,5,105,103,235,13,74,30,122,125,74,170,42,47,85,89,112,208,86,193,251,24,8,205,67,85,198,201,194,163,138,207,208,90,66,223,197,117,43,104,95,184,63,255,129,183,222,241,176,19,86,40,244,137,106,154,6,30,3,27,35,252,248,244,163,39,10,228,28,3,53,113,96,50,88,223,184,102,6,14,124,140,191,65,223,220,255,53,47,166,51,126,83,239,144,62,157,12,43,120,75,123,82,182,226,232,92,15,207,82,38,240,224,62,172,254,98,124,213,129,238,2,249,233,126,180,164,105,220,199,2,151,176,101,45,115,206,86,222,231,74,138,5,90,153,13,162,186,230,154,102,163,170,188,126,3,45,210,139,161,126,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("4f12816d-d543-4f86-9793-07195211c781"));
		}

		#endregion

	}

	#endregion

}

