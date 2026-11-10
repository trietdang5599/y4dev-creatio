namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: UpdateWebhookSubAccountsRequestSchema

	/// <exclude/>
	public class UpdateWebhookSubAccountsRequestSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public UpdateWebhookSubAccountsRequestSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public UpdateWebhookSubAccountsRequestSchema(UpdateWebhookSubAccountsRequestSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("6726d735-6c69-4e53-8f8b-22afa4771cb9");
			Name = "UpdateWebhookSubAccountsRequest";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("fe674b36-6b4e-4761-be68-f76112863a49");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,173,83,223,75,195,48,16,126,222,96,255,195,193,222,219,119,39,130,86,144,194,64,88,55,124,78,219,91,23,92,147,122,151,40,101,248,191,123,77,58,25,10,234,152,47,129,124,119,223,143,187,16,163,90,228,78,85,8,107,36,82,108,183,46,201,172,217,234,198,147,114,218,154,100,169,76,173,77,163,115,227,176,137,216,108,122,152,77,39,158,5,134,162,103,135,237,98,54,21,100,78,216,72,25,178,189,98,190,130,77,87,43,135,79,88,238,172,125,46,124,121,91,85,214,27,199,43,124,241,200,46,80,210,52,133,107,246,109,171,168,191,25,239,43,236,8,25,165,19,220,14,193,7,25,120,139,58,192,190,84,163,16,80,84,74,142,66,233,137,82,231,203,189,174,160,26,178,252,30,101,50,76,244,45,77,0,30,80,156,44,1,227,24,168,34,20,177,26,202,62,249,36,157,58,31,173,217,209,176,161,44,182,223,245,112,128,6,221,98,16,90,192,123,24,255,76,71,121,142,31,29,239,165,107,173,91,60,122,62,154,11,61,181,149,5,106,121,10,208,181,156,122,171,145,254,62,180,182,89,32,231,245,191,197,96,20,192,157,31,161,8,188,203,99,196,53,184,94,42,244,138,4,155,213,242,156,48,249,72,47,2,123,67,251,175,137,38,49,213,28,77,29,63,211,112,21,236,3,227,245,88,169,168,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("6726d735-6c69-4e53-8f8b-22afa4771cb9"));
		}

		#endregion

	}

	#endregion

}

