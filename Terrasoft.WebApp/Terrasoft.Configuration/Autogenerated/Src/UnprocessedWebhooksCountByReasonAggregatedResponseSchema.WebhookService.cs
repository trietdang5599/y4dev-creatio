namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: UnprocessedWebhooksCountByReasonAggregatedResponseSchema

	/// <exclude/>
	public class UnprocessedWebhooksCountByReasonAggregatedResponseSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public UnprocessedWebhooksCountByReasonAggregatedResponseSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public UnprocessedWebhooksCountByReasonAggregatedResponseSchema(UnprocessedWebhooksCountByReasonAggregatedResponseSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("6a7ec33d-b2c9-4456-9aa8-9786bd9d8724");
			Name = "UnprocessedWebhooksCountByReasonAggregatedResponse";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("fe674b36-6b4e-4761-be68-f76112863a49");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,173,148,77,111,219,48,12,134,207,45,208,255,64,180,151,237,226,220,219,110,192,146,93,114,104,26,164,13,118,40,122,160,101,218,21,42,75,129,62,50,120,193,254,251,40,127,37,27,138,196,73,6,24,54,36,243,125,201,135,34,164,177,36,183,66,65,240,76,214,162,51,185,79,38,70,231,178,8,22,189,52,250,234,114,115,117,121,17,156,212,5,60,85,206,83,153,44,130,246,178,164,228,137,172,68,37,127,213,113,119,125,212,214,104,22,100,12,90,75,65,15,38,35,149,124,71,143,236,238,45,10,207,2,150,140,70,35,184,119,161,44,209,86,95,219,245,130,43,50,218,17,8,133,206,65,110,44,20,228,125,244,14,122,101,141,32,231,40,131,159,148,190,25,243,238,64,24,46,8,114,169,60,89,222,79,43,176,196,5,104,151,116,9,70,59,25,94,118,139,120,229,141,85,72,149,20,109,178,229,54,193,143,214,127,18,237,199,213,162,246,252,86,20,150,10,244,148,245,85,222,194,24,29,117,75,54,220,212,100,23,55,28,200,141,129,185,53,43,178,94,146,187,133,121,157,171,249,255,47,122,199,238,173,20,236,15,93,126,168,11,72,122,201,46,76,67,243,64,101,74,246,211,140,207,18,190,192,181,237,61,254,66,184,254,28,105,59,92,101,184,157,139,143,35,97,19,27,126,7,46,190,126,239,169,118,169,249,84,229,186,105,59,9,12,220,14,147,195,84,123,42,154,241,1,233,92,160,227,25,228,214,130,251,151,42,42,15,177,76,247,43,206,102,202,136,167,222,87,60,130,184,70,169,48,149,42,46,79,229,107,237,150,157,155,162,161,156,195,148,231,242,42,20,239,241,203,163,91,50,35,119,245,120,72,109,230,91,245,64,188,217,33,205,185,96,19,190,28,120,72,254,211,57,138,198,237,248,99,156,12,18,14,134,125,244,111,100,123,182,19,97,76,52,105,61,166,181,197,33,138,199,253,138,143,202,191,33,157,53,55,99,189,230,93,126,254,0,125,71,141,81,135,6,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("6a7ec33d-b2c9-4456-9aa8-9786bd9d8724"));
		}

		#endregion

	}

	#endregion

}

