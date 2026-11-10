namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: WebhookAccountResponseSchema

	/// <exclude/>
	public class WebhookAccountResponseSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public WebhookAccountResponseSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public WebhookAccountResponseSchema(WebhookAccountResponseSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("cbf385ce-188b-4c9c-b713-0b0178ffc565");
			Name = "WebhookAccountResponse";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("8e07ad5d-ca48-4dfc-8107-c7bee2abec1b");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,157,82,93,107,194,64,16,124,86,240,63,236,47,72,222,155,82,80,11,69,16,10,42,244,121,115,174,241,104,114,23,110,247,148,32,253,239,221,124,21,105,139,165,66,2,201,220,206,205,236,238,56,172,136,107,52,4,59,10,1,217,31,36,89,122,119,176,69,12,40,214,187,100,141,110,111,93,97,87,78,168,232,177,217,244,50,155,78,34,43,12,219,134,133,170,108,54,85,36,77,83,120,228,88,85,24,154,167,225,127,67,117,32,38,39,12,114,36,56,83,126,244,254,29,208,24,31,157,128,158,213,222,49,37,35,61,189,226,215,49,47,173,1,83,34,51,188,245,204,121,79,220,12,60,120,128,5,50,253,126,168,87,180,70,127,248,234,128,23,82,75,62,0,211,96,205,4,66,161,61,228,77,242,69,186,118,51,218,97,9,109,227,203,190,124,209,192,5,10,146,172,189,40,131,143,110,16,255,84,212,41,223,84,124,214,170,157,173,104,212,124,117,247,105,34,156,176,140,4,86,55,106,116,147,218,197,249,72,234,36,168,29,203,138,179,160,211,44,232,55,26,177,39,186,237,43,247,190,132,21,207,187,210,251,199,160,161,34,40,109,101,229,182,156,213,188,108,180,118,221,150,222,47,55,70,144,125,12,230,143,14,135,93,15,241,218,118,140,239,202,19,125,245,249,4,133,252,77,66,74,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("cbf385ce-188b-4c9c-b713-0b0178ffc565"));
		}

		#endregion

	}

	#endregion

}

