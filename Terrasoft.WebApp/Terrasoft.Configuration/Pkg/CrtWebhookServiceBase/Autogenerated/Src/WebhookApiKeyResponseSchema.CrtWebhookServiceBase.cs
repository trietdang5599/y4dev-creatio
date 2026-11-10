namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: WebhookApiKeyResponseSchema

	/// <exclude/>
	public class WebhookApiKeyResponseSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public WebhookApiKeyResponseSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public WebhookApiKeyResponseSchema(WebhookApiKeyResponseSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("8fce16ad-5709-43b9-bd14-2a8342248eb7");
			Name = "WebhookApiKeyResponse";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("edc99e2c-9094-4ed6-903f-e907a7c24faf");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,109,146,65,107,131,64,16,133,207,6,242,31,6,115,105,47,122,79,154,64,154,66,9,109,66,72,10,61,148,28,54,58,234,18,221,149,221,177,96,67,255,123,103,53,86,105,227,69,246,241,222,188,249,86,149,40,208,150,34,66,120,67,99,132,213,9,5,43,173,18,153,86,70,144,212,42,120,21,42,150,42,149,107,69,152,182,218,120,116,25,143,188,202,178,12,135,218,18,22,193,190,82,36,11,12,14,104,164,200,229,87,227,155,253,186,250,225,219,74,58,211,167,140,112,163,99,204,131,39,65,130,27,201,136,136,56,48,30,1,63,19,131,41,15,128,85,46,172,157,194,59,158,50,173,207,203,82,190,96,189,231,133,181,178,216,121,195,48,132,7,91,21,133,48,245,162,151,58,27,68,110,6,36,218,176,11,249,104,48,153,251,55,39,250,225,2,152,22,164,202,24,131,48,110,179,104,131,65,83,216,87,121,31,195,229,143,173,169,172,78,185,140,174,173,55,107,96,10,143,194,98,207,225,98,151,14,103,136,191,51,186,68,67,18,249,14,118,205,220,161,235,6,120,39,63,35,89,96,98,235,222,148,33,44,119,107,56,99,29,252,73,135,255,227,13,211,6,139,19,154,187,45,255,29,48,7,95,52,251,251,247,199,222,118,197,180,100,220,247,109,1,225,2,41,210,204,181,206,224,219,173,234,121,19,84,113,75,211,156,91,117,40,178,242,3,117,213,209,45,133,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("8fce16ad-5709-43b9-bd14-2a8342248eb7"));
		}

		#endregion

	}

	#endregion

}

