namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: WebhookSubAccountsResponseSchema

	/// <exclude/>
	public class WebhookSubAccountsResponseSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public WebhookSubAccountsResponseSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public WebhookSubAccountsResponseSchema(WebhookSubAccountsResponseSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("95258480-3f8d-4085-a822-2deac2e3e86d");
			Name = "WebhookSubAccountsResponse";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("8e07ad5d-ca48-4dfc-8107-c7bee2abec1b");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,101,144,193,106,195,48,12,134,207,11,244,29,244,4,201,125,41,133,109,135,50,232,169,45,236,236,56,74,106,150,72,193,146,55,74,233,187,79,89,146,18,182,139,177,127,89,159,62,155,92,143,50,56,143,112,198,24,157,112,163,249,27,83,19,218,20,157,6,166,252,224,168,14,212,134,119,82,108,167,108,147,221,54,217,83,18,139,225,116,21,197,222,122,186,14,253,88,148,124,143,132,49,248,114,147,217,173,162,40,96,43,169,239,93,188,238,230,243,17,135,136,130,164,2,122,65,176,253,96,125,8,77,228,30,190,177,186,48,127,130,243,158,19,41,8,198,175,96,126,72,245,192,129,52,95,160,197,138,58,164,170,11,30,124,231,68,224,99,34,156,82,245,50,49,228,184,76,120,134,87,39,56,199,75,106,253,227,123,254,169,254,6,123,52,75,142,166,49,219,118,65,20,184,121,120,46,126,54,153,125,112,138,53,72,170,102,123,201,31,224,181,238,226,123,48,214,118,214,253,35,181,131,149,63,220,160,69,45,71,137,18,238,6,184,143,127,107,203,15,81,131,66,193,191,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("95258480-3f8d-4085-a822-2deac2e3e86d"));
		}

		#endregion

	}

	#endregion

}

