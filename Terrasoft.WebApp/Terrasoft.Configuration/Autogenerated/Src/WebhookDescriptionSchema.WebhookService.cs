namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: WebhookDescriptionSchema

	/// <exclude/>
	public class WebhookDescriptionSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public WebhookDescriptionSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public WebhookDescriptionSchema(WebhookDescriptionSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("020f1299-16ac-4e29-87a6-9d2c2c565cca");
			Name = "WebhookDescription";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("c57d96f3-f6a9-41c3-a651-44ed58ea0c9a");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,165,147,75,79,195,48,12,199,207,69,226,59,88,227,194,36,212,222,217,24,18,15,129,38,4,3,38,56,103,157,183,5,186,164,179,19,166,106,226,187,147,71,87,85,136,135,24,151,62,108,255,237,159,29,71,137,37,114,41,114,132,49,18,9,214,51,147,158,107,53,147,115,75,194,72,173,246,247,54,251,123,137,101,169,230,240,88,177,193,165,243,23,5,230,222,201,233,21,42,36,153,247,154,152,91,92,27,231,240,121,134,172,85,122,35,213,202,121,157,63,203,50,232,179,93,46,5,85,131,250,127,36,136,113,10,107,156,44,180,126,77,183,81,89,43,172,180,147,66,230,144,23,130,25,158,99,224,5,114,78,178,140,124,201,38,164,79,14,8,231,206,0,35,210,37,146,145,200,199,48,10,226,232,255,92,63,24,174,208,48,104,2,246,111,179,64,88,160,152,34,113,218,40,218,44,91,152,11,25,218,119,214,62,27,114,109,31,65,124,15,224,58,234,97,3,115,52,61,159,183,7,239,127,1,88,89,164,10,74,65,238,100,204,127,72,238,125,162,81,147,103,119,34,66,199,196,6,38,122,90,253,76,51,188,155,188,184,205,128,135,168,56,115,130,221,203,178,182,228,246,178,181,27,223,23,174,247,194,149,135,199,32,171,13,95,85,63,64,53,141,171,242,27,141,167,48,85,137,160,103,225,27,149,145,230,187,17,4,75,56,54,80,110,228,39,157,117,195,212,25,140,23,77,35,160,195,140,210,126,22,130,219,93,188,73,50,86,20,245,9,122,134,203,80,113,236,24,14,187,224,47,98,146,16,26,75,170,61,226,211,244,73,20,22,235,5,24,28,118,162,234,214,81,116,186,254,102,38,177,243,240,124,255,0,243,137,0,157,242,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("020f1299-16ac-4e29-87a6-9d2c2c565cca"));
		}

		#endregion

	}

	#endregion

}

