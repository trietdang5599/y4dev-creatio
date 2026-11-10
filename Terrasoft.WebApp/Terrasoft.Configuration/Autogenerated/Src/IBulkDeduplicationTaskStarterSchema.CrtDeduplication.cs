namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: IBulkDeduplicationTaskStarterSchema

	/// <exclude/>
	public class IBulkDeduplicationTaskStarterSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IBulkDeduplicationTaskStarterSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IBulkDeduplicationTaskStarterSchema(IBulkDeduplicationTaskStarterSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("34bd4c3a-5be2-45e6-81db-f052a01f9932");
			Name = "IBulkDeduplicationTaskStarter";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("4c53ad23-c903-414d-89cd-b08703861304");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,133,145,49,79,195,48,16,133,231,70,202,127,56,181,11,44,241,14,161,67,97,233,130,144,218,63,224,196,151,96,53,182,163,59,27,9,161,254,119,46,14,69,161,29,144,188,60,251,125,207,207,103,175,29,242,168,91,132,35,18,105,14,93,172,158,131,239,108,159,72,71,27,124,245,130,38,141,131,109,179,42,139,175,178,88,201,218,16,246,162,97,239,35,82,39,252,3,236,119,105,56,253,113,31,53,159,14,81,147,88,202,66,32,165,20,212,156,156,211,244,185,253,209,111,20,62,172,65,6,135,241,61,24,232,2,1,79,140,245,61,52,146,8,102,25,9,35,133,22,153,171,75,156,90,228,141,169,17,31,216,75,167,255,42,173,166,199,220,180,202,27,217,195,87,119,71,129,171,95,68,93,51,245,168,73,59,240,50,210,167,53,99,59,49,175,34,214,219,195,44,242,81,85,171,236,203,88,19,194,48,223,117,211,242,142,35,77,51,88,4,221,63,10,115,206,163,220,160,55,243,23,76,242,252,13,144,34,241,78,199,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("34bd4c3a-5be2-45e6-81db-f052a01f9932"));
		}

		#endregion

	}

	#endregion

}

