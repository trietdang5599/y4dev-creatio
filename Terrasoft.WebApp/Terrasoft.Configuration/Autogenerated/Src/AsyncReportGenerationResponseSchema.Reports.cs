namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: AsyncReportGenerationResponseSchema

	/// <exclude/>
	public class AsyncReportGenerationResponseSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public AsyncReportGenerationResponseSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public AsyncReportGenerationResponseSchema(AsyncReportGenerationResponseSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("59415005-e6b4-4fec-b04e-4cda4c279496");
			Name = "AsyncReportGenerationResponse";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("f8ef1a6f-6619-48e3-9227-afa9b7782f83");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,125,143,65,107,195,48,12,133,207,45,244,63,8,118,79,238,77,41,140,30,66,97,135,210,246,15,120,142,146,137,37,118,144,148,65,8,253,239,179,157,46,91,123,216,201,232,249,211,211,123,206,116,40,189,177,8,87,100,54,226,107,205,14,222,213,212,12,108,148,188,219,172,167,205,122,53,8,185,6,46,163,40,118,197,211,28,248,182,69,27,97,201,74,116,200,100,3,19,168,23,198,38,168,112,104,141,200,22,94,101,116,246,140,189,103,77,88,242,63,135,243,97,17,211,66,63,188,183,100,193,70,254,127,28,182,240,16,243,130,252,69,22,127,221,86,83,114,92,50,156,216,247,200,74,24,130,156,210,153,249,63,207,115,216,201,208,117,134,199,253,143,80,162,10,120,6,137,175,126,32,216,165,34,248,26,168,66,167,84,19,178,196,145,83,70,104,150,144,160,70,62,37,91,236,243,191,254,247,142,199,55,18,221,149,3,85,123,120,46,121,13,235,199,74,96,10,158,90,196,20,5,220,238,117,208,85,115,163,52,207,234,163,120,251,6,122,178,151,186,212,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("59415005-e6b4-4fec-b04e-4cda4c279496"));
		}

		#endregion

	}

	#endregion

}

