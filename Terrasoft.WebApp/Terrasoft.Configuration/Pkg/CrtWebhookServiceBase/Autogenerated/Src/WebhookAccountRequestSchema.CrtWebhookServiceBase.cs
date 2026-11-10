namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: WebhookAccountRequestSchema

	/// <exclude/>
	public class WebhookAccountRequestSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public WebhookAccountRequestSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public WebhookAccountRequestSchema(WebhookAccountRequestSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("3176958d-017e-4009-868d-c2180693d9ea");
			Name = "WebhookAccountRequest";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("8e07ad5d-ca48-4dfc-8107-c7bee2abec1b");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,181,85,193,110,219,48,12,61,55,64,254,129,64,239,201,125,25,6,164,222,48,24,13,176,32,105,177,179,44,51,14,81,91,242,68,41,133,17,236,223,71,203,118,208,13,93,154,186,237,205,122,226,243,123,18,31,109,163,42,228,90,105,132,59,116,78,177,221,249,89,98,205,142,138,224,148,39,107,102,43,101,114,50,5,165,198,99,209,97,211,201,113,58,185,10,44,48,108,27,246,88,45,166,19,65,174,29,22,178,13,73,169,152,63,193,79,204,246,214,62,44,181,182,193,248,13,254,10,200,62,22,206,231,115,248,204,161,170,148,107,190,244,235,13,214,14,25,141,103,240,123,132,199,142,12,170,99,131,235,232,179,129,61,127,66,175,67,86,146,6,221,202,254,79,245,234,24,149,79,30,215,206,214,232,60,161,24,93,71,126,183,255,175,181,8,124,71,113,101,29,48,246,238,150,235,20,30,176,153,157,24,79,237,12,126,216,187,246,134,150,53,221,98,3,71,40,208,47,218,87,44,224,247,107,180,180,67,229,49,135,236,50,185,164,43,191,121,7,69,233,254,89,197,175,82,117,71,21,14,154,63,204,56,77,5,7,85,6,4,146,164,105,73,152,156,226,113,143,226,196,137,29,98,193,217,43,35,25,149,103,165,61,29,240,188,175,204,218,18,82,94,198,210,241,215,32,97,71,40,169,34,127,94,142,36,158,27,169,93,181,165,227,229,134,196,179,13,78,191,112,194,190,215,125,214,183,145,49,94,153,114,25,59,242,141,76,16,201,83,191,222,17,186,139,92,164,61,61,137,236,52,127,99,240,200,142,244,145,116,236,119,183,193,40,192,11,25,120,206,194,54,242,222,110,227,212,30,70,119,144,153,184,223,172,94,99,102,104,207,54,178,239,93,249,49,67,58,124,168,57,212,181,117,66,200,148,215,123,168,157,213,200,237,175,226,130,153,189,105,41,82,250,205,168,172,196,103,59,120,141,38,239,62,225,113,221,161,127,131,130,253,1,9,102,223,195,215,6,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("3176958d-017e-4009-868d-c2180693d9ea"));
		}

		#endregion

	}

	#endregion

}

