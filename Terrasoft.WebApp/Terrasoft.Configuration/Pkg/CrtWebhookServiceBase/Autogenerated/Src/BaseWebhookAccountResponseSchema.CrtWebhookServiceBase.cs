namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: BaseWebhookAccountResponseSchema

	/// <exclude/>
	public class BaseWebhookAccountResponseSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public BaseWebhookAccountResponseSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public BaseWebhookAccountResponseSchema(BaseWebhookAccountResponseSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("0327d562-7b53-46be-9ae5-db7a20f892a0");
			Name = "BaseWebhookAccountResponse";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("8e07ad5d-ca48-4dfc-8107-c7bee2abec1b");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,157,81,209,74,195,64,16,124,182,208,127,88,232,123,242,110,69,168,81,172,168,88,108,193,231,205,101,155,28,77,110,195,237,157,37,20,255,221,75,174,45,85,177,136,47,7,55,59,55,51,59,103,176,33,105,81,17,172,200,90,20,94,187,36,99,179,214,165,183,232,52,155,228,9,77,161,77,169,31,140,163,50,98,227,209,110,60,186,240,18,96,88,118,226,168,153,142,71,1,153,88,42,195,24,178,26,69,46,225,6,133,222,40,175,152,55,51,165,216,27,247,26,188,216,8,13,236,52,77,225,74,124,211,160,237,174,247,247,172,102,95,128,221,211,224,118,245,2,91,237,42,208,102,205,182,25,204,1,115,246,14,48,42,38,7,161,244,68,169,245,121,173,21,168,62,198,153,20,16,35,254,200,118,177,27,242,29,215,89,88,110,201,58,77,97,167,197,32,29,231,223,23,24,128,85,69,128,173,134,13,117,201,145,116,26,238,144,78,156,237,251,155,181,250,145,58,216,65,73,110,10,210,31,31,103,228,239,201,9,176,237,137,2,8,239,88,123,10,237,20,90,133,114,130,220,182,34,87,145,133,249,243,44,3,45,64,6,243,154,138,243,81,114,230,26,230,13,170,187,200,254,95,154,224,27,109,133,148,37,247,231,6,122,227,229,240,228,151,34,38,100,138,248,21,195,61,162,95,193,128,125,2,120,214,35,6,202,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("0327d562-7b53-46be-9ae5-db7a20f892a0"));
		}

		#endregion

	}

	#endregion

}

