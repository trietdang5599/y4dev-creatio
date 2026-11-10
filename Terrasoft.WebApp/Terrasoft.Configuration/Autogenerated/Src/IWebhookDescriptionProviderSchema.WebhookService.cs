namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: IWebhookDescriptionProviderSchema

	/// <exclude/>
	public class IWebhookDescriptionProviderSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IWebhookDescriptionProviderSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IWebhookDescriptionProviderSchema(IWebhookDescriptionProviderSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("96f3414e-d8a1-4585-8da8-b94ccc3c921b");
			Name = "IWebhookDescriptionProvider";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("c57d96f3-f6a9-41c3-a651-44ed58ea0c9a");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,125,145,77,107,132,64,12,134,207,10,254,135,96,47,45,44,122,111,173,151,45,148,30,150,74,17,246,60,106,212,105,117,70,50,99,139,148,253,239,157,241,99,107,215,178,151,129,76,222,39,201,155,8,214,162,234,88,142,144,34,17,83,178,212,193,94,138,146,87,61,49,205,165,240,220,111,207,117,194,48,132,72,245,109,203,104,136,231,56,33,249,201,11,36,248,194,172,150,242,3,10,84,57,241,206,82,80,146,108,207,9,20,154,235,97,41,19,174,234,116,125,214,240,28,184,208,72,165,157,226,229,56,49,79,191,181,150,62,70,110,70,49,175,115,67,88,217,38,7,212,181,44,212,61,36,99,153,41,121,57,234,248,177,39,100,26,255,155,52,56,51,225,37,20,117,140,88,11,194,172,232,209,159,81,63,62,254,49,21,68,225,168,186,10,173,204,248,241,27,170,190,209,215,57,115,10,73,7,84,138,85,232,199,105,141,208,78,1,140,153,45,76,168,123,18,42,78,24,41,44,22,159,70,183,36,172,50,147,178,129,148,134,103,212,219,45,223,206,95,175,217,251,130,239,64,246,26,182,82,216,218,218,129,109,224,88,189,210,196,69,5,107,11,119,15,243,221,80,20,211,233,198,248,228,185,167,31,77,43,212,153,128,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("96f3414e-d8a1-4585-8da8-b94ccc3c921b"));
		}

		#endregion

	}

	#endregion

}

