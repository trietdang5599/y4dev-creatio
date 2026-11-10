namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: WebhookObjSchema

	/// <exclude/>
	public class WebhookObjSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public WebhookObjSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public WebhookObjSchema(WebhookObjSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("03985297-1a6a-43c1-ac77-0535d189ca09");
			Name = "WebhookObj";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("e50fad81-60b2-4030-89a7-8b387fd6a892");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,173,147,77,79,195,48,12,134,207,171,180,255,96,105,247,245,206,16,7,118,24,156,24,251,16,231,52,113,187,140,54,41,118,34,84,85,251,239,164,205,54,77,8,161,82,113,74,98,251,245,243,90,73,140,168,144,107,33,17,118,72,36,216,230,110,190,180,38,215,133,39,225,180,53,211,164,157,38,19,207,218,20,176,109,216,97,181,152,38,33,146,166,41,220,179,175,42,65,205,195,249,188,193,154,144,209,56,6,1,159,152,29,172,125,7,155,29,81,58,200,45,129,103,4,109,64,90,133,243,75,139,244,166,71,237,179,82,75,144,165,96,134,183,168,127,201,142,33,211,246,204,201,140,176,8,158,96,77,182,70,114,26,249,14,214,189,40,230,191,155,234,3,43,12,126,2,157,187,213,29,16,92,83,35,216,188,223,75,107,92,48,60,191,170,111,253,92,12,177,163,110,252,101,172,221,117,242,22,10,116,139,174,231,2,78,127,129,31,80,40,36,30,4,124,138,181,227,97,31,30,169,129,90,80,184,101,55,148,250,218,137,214,87,205,120,58,97,224,179,131,204,170,102,16,121,19,5,143,161,126,60,213,131,86,225,150,116,174,145,126,167,174,188,86,176,127,86,227,89,151,55,206,214,147,196,65,51,158,159,245,182,87,252,23,25,60,149,131,232,17,187,167,242,39,242,12,141,138,31,172,63,135,232,233,11,230,155,89,219,31,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("03985297-1a6a-43c1-ac77-0535d189ca09"));
		}

		#endregion

	}

	#endregion

}

