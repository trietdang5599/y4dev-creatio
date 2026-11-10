namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: WebhookLogWriterSchema

	/// <exclude/>
	public class WebhookLogWriterSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public WebhookLogWriterSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public WebhookLogWriterSchema(WebhookLogWriterSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("e1f5aa0c-1e22-41e9-b051-ad2f74579970");
			Name = "WebhookLogWriter";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("c57d96f3-f6a9-41c3-a651-44ed58ea0c9a");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,141,82,203,78,195,64,12,60,7,137,127,88,133,75,145,170,228,78,75,15,148,135,144,40,66,42,143,179,73,220,116,69,178,91,237,163,40,66,252,59,222,100,147,38,11,66,61,218,158,177,199,99,11,168,80,239,32,67,246,140,74,129,150,27,147,44,165,216,240,194,42,48,92,138,211,147,175,211,147,200,106,46,10,182,174,181,193,106,214,199,67,138,66,202,83,37,77,83,54,215,182,170,64,213,11,31,191,225,251,86,202,15,86,202,130,125,42,110,80,37,29,50,29,64,119,246,189,228,25,203,74,208,186,227,60,200,226,173,97,80,253,171,25,16,157,41,44,72,24,187,229,88,230,250,130,61,41,190,7,131,109,113,215,6,76,33,228,82,148,53,123,209,168,104,33,129,153,219,38,8,103,190,35,138,188,109,58,158,64,64,109,148,205,140,84,110,78,35,175,69,132,91,54,137,1,60,233,65,105,136,154,239,64,65,197,4,25,127,25,219,145,156,120,225,228,177,172,79,36,243,180,65,55,100,111,79,104,204,36,216,112,220,242,156,185,243,69,81,0,186,12,96,238,166,209,247,255,110,172,208,108,101,126,140,17,15,238,206,254,230,244,34,199,219,225,73,247,121,188,232,248,60,31,153,240,139,82,209,179,64,129,241,226,198,13,98,244,205,46,252,203,184,189,228,185,147,230,13,108,240,147,59,75,201,126,236,148,209,1,221,103,251,174,157,123,123,80,12,133,225,166,94,103,91,172,128,252,27,27,154,220,12,170,43,16,196,85,201,29,154,123,250,8,16,25,94,213,143,164,118,18,31,142,23,159,207,130,214,212,116,56,35,89,210,15,27,108,27,7,71,246,220,22,158,172,209,92,227,102,41,75,91,137,87,40,45,234,201,47,192,160,218,171,32,155,167,135,221,255,167,172,90,95,137,208,89,51,134,195,30,253,208,191,191,136,178,223,63,163,139,186,210,108,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("e1f5aa0c-1e22-41e9-b051-ad2f74579970"));
		}

		#endregion

	}

	#endregion

}

