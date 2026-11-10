namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: ICustomWebhookDefaultValueProviderSchema

	/// <exclude/>
	public class ICustomWebhookDefaultValueProviderSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ICustomWebhookDefaultValueProviderSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ICustomWebhookDefaultValueProviderSchema(ICustomWebhookDefaultValueProviderSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("185c9850-ecb4-4aef-90d7-f60a1c3acd22");
			Name = "ICustomWebhookDefaultValueProvider";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("b87a5b49-8965-4e3b-9f48-2dc1c2176364");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,141,82,207,107,194,48,20,62,43,248,63,60,220,101,3,105,239,83,11,67,157,120,27,56,230,57,182,175,53,91,154,148,188,23,135,200,254,247,37,105,149,14,61,236,152,228,123,223,175,60,45,106,164,70,228,8,239,104,173,32,83,114,178,48,186,148,149,179,130,165,209,163,225,121,52,28,56,146,186,130,237,137,24,107,255,174,20,230,225,145,146,53,106,180,50,159,94,49,125,26,139,201,74,179,100,137,228,1,30,242,96,177,242,99,176,209,140,182,244,170,207,176,89,56,98,83,239,112,127,48,230,107,137,165,112,138,63,132,114,248,102,205,81,22,104,227,100,154,166,48,35,87,215,194,158,178,238,220,1,8,148,169,100,14,108,128,144,161,104,41,224,24,56,8,74,99,225,187,37,135,82,162,42,40,185,208,165,61,190,198,237,149,231,144,23,99,255,242,53,8,213,220,88,139,23,107,100,2,62,224,85,155,140,179,57,38,215,129,190,248,128,216,134,238,58,177,109,132,194,25,42,228,41,252,196,252,247,85,94,154,70,249,114,175,153,115,163,92,173,251,209,131,5,106,48,151,62,123,113,167,136,59,102,226,77,35,172,168,65,251,237,152,143,49,252,225,105,156,109,52,177,208,222,153,41,35,111,110,81,176,103,157,17,198,67,57,31,175,90,104,154,37,179,52,82,220,103,236,124,188,6,27,177,83,26,103,187,190,183,174,174,46,201,31,178,163,145,5,108,145,251,95,66,143,173,48,180,86,39,176,89,202,184,160,62,211,172,45,119,2,102,255,233,183,54,131,91,241,167,176,190,190,231,65,88,81,212,69,187,165,161,119,127,249,11,10,161,7,46,34,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("185c9850-ecb4-4aef-90d7-f60a1c3acd22"));
		}

		#endregion

	}

	#endregion

}

