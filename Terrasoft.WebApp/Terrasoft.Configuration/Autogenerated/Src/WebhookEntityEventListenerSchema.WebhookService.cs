namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: WebhookEntityEventListenerSchema

	/// <exclude/>
	public class WebhookEntityEventListenerSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public WebhookEntityEventListenerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public WebhookEntityEventListenerSchema(WebhookEntityEventListenerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("943ad47a-d664-4f8c-b3d1-0ac5f567bfe1");
			Name = "WebhookEntityEventListener";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("fe674b36-6b4e-4761-be68-f76112863a49");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,173,146,93,79,194,48,20,134,175,187,100,255,225,232,21,36,102,220,43,144,32,130,49,49,122,129,137,23,198,152,178,158,177,106,215,146,126,140,16,195,127,119,91,135,2,3,140,134,155,165,235,233,121,206,199,251,58,195,229,12,158,80,107,106,84,98,163,161,146,9,159,57,77,45,87,242,42,12,92,35,174,49,26,73,203,45,71,243,91,60,26,229,40,237,193,103,99,26,91,165,61,39,12,58,157,14,116,141,203,50,170,151,125,255,251,148,114,3,177,160,198,64,113,112,6,25,88,5,41,149,76,32,96,197,134,68,105,176,41,194,51,78,83,165,62,170,210,203,168,198,117,126,120,47,62,82,117,116,207,141,69,137,186,53,137,83,204,232,3,205,16,122,112,190,133,56,111,191,134,193,220,77,5,143,235,22,182,194,91,28,184,132,107,106,112,79,36,12,62,195,128,204,53,207,169,69,184,171,17,19,212,57,143,113,48,231,240,182,216,189,42,150,65,224,120,82,243,166,172,66,102,104,253,129,240,4,90,77,50,156,245,64,58,33,218,245,43,162,209,58,45,15,244,64,200,170,250,238,225,244,96,88,110,196,235,183,140,110,209,118,155,93,246,91,109,143,57,94,165,44,178,42,245,39,59,6,32,223,14,200,208,166,138,149,22,136,169,16,133,9,22,41,74,160,219,130,84,14,153,179,98,99,44,90,195,54,228,39,181,148,42,47,60,200,25,66,174,56,131,71,57,161,57,178,150,154,190,99,108,193,160,100,168,47,192,19,7,137,69,93,169,57,208,51,3,88,175,109,90,40,29,173,19,215,25,232,103,109,44,33,26,11,103,210,205,70,11,187,15,105,97,59,191,157,83,77,206,80,224,31,39,191,241,41,255,153,125,157,122,130,233,87,95,99,10,106,168,129,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("943ad47a-d664-4f8c-b3d1-0ac5f567bfe1"));
		}

		#endregion

	}

	#endregion

}

