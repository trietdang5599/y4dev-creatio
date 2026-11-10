namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: WebhookAccountInfoResponseSchema

	/// <exclude/>
	public class WebhookAccountInfoResponseSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public WebhookAccountInfoResponseSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public WebhookAccountInfoResponseSchema(WebhookAccountInfoResponseSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("5d7cb793-ed14-40c8-8d27-baec86619d88");
			Name = "WebhookAccountInfoResponse";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("fe674b36-6b4e-4761-be68-f76112863a49");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,157,145,79,79,194,64,16,197,207,144,240,29,38,156,244,210,222,69,77,42,26,33,10,49,96,226,129,120,152,110,135,118,67,187,219,236,110,33,149,240,221,157,182,252,169,26,19,241,208,195,206,190,247,230,215,183,10,51,178,57,10,130,87,50,6,173,94,58,111,168,213,82,198,133,65,39,181,242,158,81,69,82,197,114,172,28,197,205,172,215,221,246,186,157,194,242,24,230,165,117,148,121,179,66,57,153,145,55,39,35,49,149,31,181,110,112,84,157,194,167,133,172,68,107,41,104,162,35,74,189,123,116,200,27,157,65,225,216,192,22,223,247,225,218,22,89,134,166,188,221,159,103,148,27,178,164,156,5,151,16,108,40,76,180,94,1,10,161,121,51,72,181,212,192,130,92,43,75,222,33,195,111,133,44,218,123,222,121,144,23,97,42,5,136,20,173,133,183,38,47,104,226,198,156,54,219,135,193,21,220,161,165,195,145,141,213,191,255,96,172,7,143,196,120,218,128,165,61,102,240,50,134,21,149,222,209,209,38,106,144,38,148,133,100,46,166,252,14,112,3,125,204,229,19,149,253,203,138,240,128,104,157,169,58,12,234,43,216,66,76,110,80,237,24,192,174,238,235,15,48,8,107,76,11,226,158,34,41,248,109,56,110,147,16,35,26,24,77,130,33,72,11,164,48,76,41,58,131,53,201,80,60,52,174,175,192,161,214,41,140,78,183,255,99,174,10,172,225,44,9,67,238,204,34,43,184,121,109,252,173,207,81,91,241,29,177,195,223,238,19,59,167,18,63,29,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("5d7cb793-ed14-40c8-8d27-baec86619d88"));
		}

		#endregion

	}

	#endregion

}

