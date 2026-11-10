namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: UnprocessedWebhooksCountResponseSchema

	/// <exclude/>
	public class UnprocessedWebhooksCountResponseSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public UnprocessedWebhooksCountResponseSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public UnprocessedWebhooksCountResponseSchema(UnprocessedWebhooksCountResponseSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("0d79f3be-e088-4f37-acbd-96c6997fcf5c");
			Name = "UnprocessedWebhooksCountResponse";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("fe674b36-6b4e-4761-be68-f76112863a49");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,101,145,77,79,195,48,12,64,207,155,180,255,96,141,11,92,218,251,6,28,40,215,77,211,6,226,128,56,164,169,91,34,154,164,178,19,166,81,241,223,73,250,177,21,184,68,178,99,63,63,39,70,104,228,70,72,132,39,36,18,108,75,151,100,214,148,170,242,36,156,178,102,49,111,23,243,153,103,101,42,56,156,216,161,78,246,222,56,165,49,57,32,41,81,171,175,174,110,125,174,186,128,182,94,197,162,79,37,113,99,11,172,147,71,225,68,160,59,18,210,133,134,208,146,166,41,220,178,215,90,208,233,126,136,247,193,200,26,70,144,181,96,134,210,18,84,232,92,100,123,211,144,149,200,140,5,28,49,127,183,246,131,65,218,32,148,140,176,116,66,123,157,14,124,11,137,198,231,181,146,3,248,249,2,123,25,88,89,68,157,231,175,224,65,48,142,97,104,111,59,231,217,21,97,21,86,134,29,217,6,201,41,228,21,236,58,114,127,255,119,169,46,49,142,128,108,212,253,239,219,11,111,80,231,72,215,219,240,53,112,7,203,227,212,109,121,19,215,24,247,168,109,120,147,95,238,208,198,183,90,3,199,227,123,208,69,83,244,198,93,220,101,195,241,3,216,173,189,250,251,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("0d79f3be-e088-4f37-acbd-96c6997fcf5c"));
		}

		#endregion

	}

	#endregion

}

