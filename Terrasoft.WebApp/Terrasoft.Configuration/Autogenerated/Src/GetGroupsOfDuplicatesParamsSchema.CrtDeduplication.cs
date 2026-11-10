namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: GetGroupsOfDuplicatesParamsSchema

	/// <exclude/>
	public class GetGroupsOfDuplicatesParamsSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public GetGroupsOfDuplicatesParamsSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public GetGroupsOfDuplicatesParamsSchema(GetGroupsOfDuplicatesParamsSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("b7f703a5-c87f-41f4-8e13-77635795a696");
			Name = "GetGroupsOfDuplicatesParams";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("4c53ad23-c903-414d-89cd-b08703861304");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,141,146,61,111,194,48,16,134,103,144,248,15,39,88,218,37,217,75,219,37,180,76,45,168,176,33,6,147,156,35,75,177,29,157,207,3,69,252,247,58,14,32,16,41,138,100,89,186,187,215,207,125,217,8,141,174,22,57,194,26,137,132,179,146,147,204,26,169,74,79,130,149,53,201,12,11,95,87,42,143,214,104,120,24,13,7,222,41,83,194,106,239,24,117,242,227,13,43,141,201,10,73,137,74,253,70,221,116,52,12,186,9,97,25,12,200,42,225,220,11,204,145,231,100,125,237,22,114,118,66,162,91,10,18,218,69,121,56,105,154,194,171,243,90,11,218,191,159,236,168,64,70,114,160,109,129,21,72,75,143,88,201,153,147,94,129,54,51,193,34,52,198,36,114,222,6,71,237,119,225,21,228,77,105,143,43,27,28,98,117,151,110,150,100,107,36,86,24,90,90,70,74,27,143,41,190,80,239,144,158,190,67,197,240,6,99,12,179,225,125,99,141,159,155,172,231,180,142,169,25,225,199,37,12,7,40,145,167,224,154,235,248,63,48,183,149,215,198,117,209,54,91,200,218,104,95,152,149,50,72,110,89,202,48,44,162,191,127,73,225,7,220,67,178,198,221,151,193,182,190,26,60,82,220,198,61,115,221,37,235,155,67,170,170,249,68,157,139,248,108,99,93,168,9,154,162,221,124,180,91,239,173,243,248,7,163,135,107,91,70,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("b7f703a5-c87f-41f4-8e13-77635795a696"));
		}

		#endregion

	}

	#endregion

}

