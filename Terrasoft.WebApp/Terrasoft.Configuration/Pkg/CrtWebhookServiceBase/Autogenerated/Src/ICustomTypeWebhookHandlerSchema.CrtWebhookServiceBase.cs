namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: ICustomTypeWebhookHandlerSchema

	/// <exclude/>
	public class ICustomTypeWebhookHandlerSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ICustomTypeWebhookHandlerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ICustomTypeWebhookHandlerSchema(ICustomTypeWebhookHandlerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("87741c9c-aa61-4ad0-b909-e56eff97f745");
			Name = "ICustomTypeWebhookHandler";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("c57d96f3-f6a9-41c3-a651-44ed58ea0c9a");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,141,80,177,110,194,48,16,157,19,137,127,56,193,210,46,241,222,80,22,150,118,104,133,84,164,206,38,185,4,183,196,142,206,103,170,40,226,223,107,59,129,66,5,85,151,200,185,123,239,221,123,79,203,6,109,43,11,132,53,18,73,107,42,206,150,70,87,170,118,36,89,25,61,73,251,73,154,56,171,116,13,111,157,101,108,242,73,234,39,66,8,152,91,215,52,146,186,197,248,255,142,155,173,49,159,80,56,203,166,1,238,90,132,173,212,229,14,41,59,82,196,25,167,117,155,157,42,64,105,70,170,130,135,231,101,100,174,61,113,212,122,26,232,30,220,199,179,201,140,176,246,182,96,69,166,69,98,133,246,1,86,81,103,216,255,246,21,7,30,188,87,37,18,104,31,55,59,193,206,189,36,150,41,100,60,66,95,61,18,122,168,145,115,56,252,33,29,13,6,98,72,123,67,58,228,129,248,185,20,156,161,46,135,56,151,217,94,144,183,166,252,79,176,211,245,175,177,250,86,146,55,238,251,132,189,220,185,91,134,226,36,66,99,35,143,83,165,91,199,211,197,216,65,164,130,169,174,168,86,134,78,71,179,185,136,139,31,73,66,118,164,237,98,46,142,175,176,50,155,15,44,120,160,225,221,120,35,94,188,207,175,22,225,235,57,124,3,142,62,255,79,153,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("87741c9c-aa61-4ad0-b909-e56eff97f745"));
		}

		#endregion

	}

	#endregion

}

