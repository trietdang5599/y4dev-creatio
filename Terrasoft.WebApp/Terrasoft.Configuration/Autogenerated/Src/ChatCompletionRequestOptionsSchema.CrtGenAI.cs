namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: ChatCompletionRequestOptionsSchema

	/// <exclude/>
	public class ChatCompletionRequestOptionsSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ChatCompletionRequestOptionsSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ChatCompletionRequestOptionsSchema(ChatCompletionRequestOptionsSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("1d0dc732-ad0b-4af0-b756-634f6fd942b5");
			Name = "ChatCompletionRequestOptions";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("5931fdb4-cda3-48d2-808d-e41a5d931036");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,125,81,77,107,2,49,16,61,43,248,31,6,188,180,151,221,123,109,11,98,65,60,85,108,233,61,102,103,215,208,108,146,206,100,21,17,255,123,39,187,174,181,133,46,132,132,36,111,222,199,140,83,53,114,80,26,225,29,137,20,251,50,102,11,239,74,83,53,164,162,241,46,91,162,155,175,38,227,211,100,60,202,243,28,30,185,169,107,69,199,231,203,125,131,129,144,209,69,6,31,82,1,67,233,9,244,133,195,184,10,244,78,69,121,168,131,197,4,0,194,175,6,89,10,140,3,97,199,36,180,71,152,175,128,145,246,70,35,103,189,88,126,163,22,154,173,53,26,180,85,204,176,16,206,197,149,114,211,49,190,118,6,4,43,110,101,31,77,9,171,164,184,38,31,144,162,65,126,128,117,75,211,253,255,13,212,62,188,96,169,26,27,127,199,249,39,66,118,101,185,117,218,91,229,40,201,180,128,85,225,157,61,14,154,190,202,62,129,195,195,32,244,238,126,54,96,127,137,105,20,36,189,148,83,193,94,217,6,165,211,133,209,98,70,166,113,216,97,220,33,65,244,192,159,38,36,128,41,218,81,131,47,65,190,250,112,125,3,134,51,110,189,183,240,38,68,31,63,60,39,168,48,206,146,131,25,156,37,80,169,44,227,197,243,20,93,209,77,165,189,159,39,99,89,223,119,1,76,190,134,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("1d0dc732-ad0b-4af0-b756-634f6fd942b5"));
		}

		#endregion

	}

	#endregion

}

