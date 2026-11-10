namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: BooleanTypeWebhookHandlerSchema

	/// <exclude/>
	public class BooleanTypeWebhookHandlerSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public BooleanTypeWebhookHandlerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public BooleanTypeWebhookHandlerSchema(BooleanTypeWebhookHandlerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("f16699b7-b1d3-41a0-8e54-4983dfa47e58");
			Name = "BooleanTypeWebhookHandler";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("d7950703-7230-445f-b3e5-fcd99a7a2e60");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,141,83,77,107,220,48,16,61,111,32,255,97,112,46,107,8,246,125,63,12,201,150,144,30,90,22,178,208,67,233,65,107,143,55,78,101,201,140,164,20,19,242,223,59,146,229,205,230,195,33,23,97,207,188,121,111,230,141,164,68,139,166,19,37,194,14,137,132,209,181,205,54,90,213,205,193,145,176,141,86,231,103,79,231,103,51,103,26,117,128,187,222,88,108,151,199,255,211,18,194,236,70,148,86,83,131,134,17,140,185,32,60,48,1,108,164,48,102,1,215,90,75,20,106,215,119,248,11,247,247,90,255,189,21,170,146,72,1,156,231,57,172,140,107,91,65,125,17,255,35,12,34,14,106,77,140,65,132,146,176,94,39,123,38,76,242,2,44,51,142,12,249,27,10,15,23,210,232,88,50,49,99,246,125,227,140,213,237,251,222,18,200,61,213,239,111,88,11,39,237,117,163,42,30,124,238,37,117,61,159,44,75,47,225,39,27,11,107,72,38,199,78,210,63,204,220,185,189,108,74,40,189,71,211,22,193,2,38,181,152,228,41,88,120,52,124,75,186,67,178,188,136,5,108,3,255,144,127,235,113,8,48,248,177,169,88,66,113,195,217,17,118,106,228,216,164,177,228,183,62,86,12,19,22,227,154,238,180,163,18,217,87,99,133,178,38,187,82,253,242,19,221,208,189,167,243,94,126,174,235,103,30,142,245,176,109,182,222,47,63,141,252,23,168,170,97,244,215,62,252,64,123,175,171,175,152,112,108,230,95,188,114,157,32,158,206,178,45,143,66,186,169,254,66,36,64,131,123,235,164,81,157,179,73,17,141,10,165,160,235,15,88,253,85,30,69,179,85,30,18,47,148,132,214,145,50,197,42,31,191,78,220,208,251,7,44,109,124,20,243,40,21,132,83,240,79,117,54,107,106,8,254,100,59,234,183,130,12,206,67,250,18,180,179,224,19,64,104,248,54,167,99,193,108,144,137,225,101,136,61,135,51,38,148,147,50,132,159,63,116,124,136,190,14,114,236,63,182,80,74,211,92,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("f16699b7-b1d3-41a0-8e54-4983dfa47e58"));
		}

		#endregion

	}

	#endregion

}

