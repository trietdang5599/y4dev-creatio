namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: WebhookHmacUpdateRequestSchema

	/// <exclude/>
	public class WebhookHmacUpdateRequestSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public WebhookHmacUpdateRequestSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public WebhookHmacUpdateRequestSchema(WebhookHmacUpdateRequestSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("cc3ae670-9a2d-4b79-86f8-d07f17cbe6f2");
			Name = "WebhookHmacUpdateRequest";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("fe674b36-6b4e-4761-be68-f76112863a49");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,141,144,93,107,131,64,16,69,159,35,248,31,6,242,174,239,73,41,136,148,38,180,5,9,45,125,94,245,70,151,232,238,118,63,26,36,228,191,119,117,147,32,180,132,62,206,101,230,204,225,10,214,195,40,86,129,222,161,53,51,114,111,147,92,138,61,111,156,102,150,75,145,188,50,81,115,209,240,173,176,104,66,22,71,167,56,90,44,53,26,63,80,222,49,99,86,244,137,178,149,242,176,233,89,245,161,106,102,177,195,151,131,177,113,228,119,211,52,165,7,227,250,158,233,225,241,50,239,160,52,12,132,53,100,91,208,49,220,211,230,45,203,201,77,4,210,1,145,92,9,233,12,161,92,217,241,138,170,241,251,157,231,139,81,245,230,90,104,169,160,45,135,23,46,38,192,164,247,203,111,10,158,225,213,164,38,131,139,98,86,108,233,128,33,185,93,204,125,174,66,198,106,95,23,101,138,191,96,160,19,53,176,235,17,177,166,243,127,127,49,250,102,157,3,113,223,124,229,27,247,184,99,11,111,160,67,59,220,16,4,43,59,212,247,85,74,41,59,26,59,121,10,219,127,217,44,33,234,80,142,159,66,54,143,206,63,172,24,243,86,33,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("cc3ae670-9a2d-4b79-86f8-d07f17cbe6f2"));
		}

		#endregion

	}

	#endregion

}

