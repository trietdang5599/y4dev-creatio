namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: WebhookServiceFeaturesSchema

	/// <exclude/>
	public class WebhookServiceFeaturesSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public WebhookServiceFeaturesSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public WebhookServiceFeaturesSchema(WebhookServiceFeaturesSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("a5912160-2221-4ee9-b381-dc8a590781ee");
			Name = "WebhookServiceFeatures";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("fe674b36-6b4e-4761-be68-f76112863a49");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,117,142,189,14,194,48,12,132,103,42,245,29,44,22,96,233,3,80,49,32,126,36,6,182,34,102,55,53,37,34,196,81,156,8,33,212,119,39,45,84,76,12,182,165,211,125,231,179,120,39,113,168,8,42,242,30,133,47,161,216,176,189,232,54,122,12,154,109,158,189,242,108,18,69,219,22,54,158,122,173,216,167,19,61,85,220,182,38,233,101,158,37,139,139,181,209,10,148,65,17,216,106,113,6,159,39,235,60,43,18,161,230,76,245,149,249,38,176,132,47,126,164,128,13,6,76,108,255,98,12,248,143,206,23,48,24,39,7,217,89,172,13,53,176,130,224,35,149,131,186,37,81,94,187,190,116,210,167,107,99,248,33,16,24,154,79,34,196,95,36,60,198,58,218,194,108,124,48,3,33,213,243,197,116,136,236,210,74,211,189,1,35,120,186,14,37,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("a5912160-2221-4ee9-b381-dc8a590781ee"));
		}

		#endregion

	}

	#endregion

}

