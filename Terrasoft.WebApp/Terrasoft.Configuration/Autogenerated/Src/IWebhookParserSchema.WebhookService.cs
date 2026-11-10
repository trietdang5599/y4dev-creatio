namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: IWebhookParserSchema

	/// <exclude/>
	public class IWebhookParserSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IWebhookParserSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IWebhookParserSchema(IWebhookParserSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("df265d20-80da-4a1e-8545-4bd85da8db16");
			Name = "IWebhookParser";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("c57d96f3-f6a9-41c3-a651-44ed58ea0c9a");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,141,146,203,110,194,48,16,69,215,32,245,31,70,116,211,74,21,217,151,52,139,62,132,64,125,32,129,212,181,19,38,193,52,241,164,227,177,80,132,248,247,58,15,74,218,178,232,210,115,239,29,159,25,219,168,2,109,169,18,132,21,50,43,75,169,140,31,200,164,58,115,172,68,147,185,24,238,47,134,3,103,181,201,96,89,89,193,194,235,121,142,73,45,218,241,20,13,178,78,38,223,158,87,220,137,23,234,62,115,75,102,252,172,205,167,87,189,30,4,1,132,214,21,133,226,42,234,206,239,24,111,136,62,32,166,117,5,165,98,139,124,116,6,61,107,233,226,92,39,160,141,32,167,53,236,172,11,46,142,145,125,115,197,224,146,49,243,92,176,96,42,145,69,163,189,133,69,19,110,245,223,12,77,97,233,202,146,88,112,13,82,149,104,33,37,62,177,252,133,25,204,158,140,43,144,85,156,99,104,133,253,212,209,169,199,170,105,177,135,12,101,2,135,142,10,205,186,5,251,73,249,130,178,161,245,127,16,155,57,97,215,219,214,121,180,166,226,217,85,1,198,191,236,221,168,139,220,251,196,40,234,231,195,160,177,157,82,140,226,216,216,168,126,181,71,74,252,132,70,194,224,88,173,109,49,81,14,43,174,166,40,111,241,214,255,128,171,118,122,232,93,114,3,228,4,230,173,14,219,94,175,235,201,217,101,248,21,29,190,0,239,207,200,21,133,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("df265d20-80da-4a1e-8545-4bd85da8db16"));
		}

		#endregion

	}

	#endregion

}

