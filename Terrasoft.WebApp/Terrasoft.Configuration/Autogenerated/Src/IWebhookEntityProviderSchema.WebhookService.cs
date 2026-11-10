namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: IWebhookEntityProviderSchema

	/// <exclude/>
	public class IWebhookEntityProviderSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IWebhookEntityProviderSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IWebhookEntityProviderSchema(IWebhookEntityProviderSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("dd2e4593-dbe9-4b91-9fef-074b97ab2c88");
			Name = "IWebhookEntityProvider";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("e50fad81-60b2-4030-89a7-8b387fd6a892");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,141,146,63,111,194,48,16,197,103,144,248,14,39,186,180,75,178,151,148,165,69,8,169,173,144,138,212,217,36,151,196,34,177,173,179,83,20,33,190,123,253,47,144,86,12,108,177,223,123,119,191,59,71,176,22,181,98,57,194,14,137,152,150,165,73,94,165,40,121,213,17,51,92,138,217,244,52,155,78,58,205,69,5,95,189,54,216,90,189,105,48,119,162,78,214,40,144,120,190,184,120,198,101,8,147,149,48,220,112,212,214,96,45,105,154,66,166,187,182,101,212,47,227,121,87,35,40,146,63,188,64,2,89,194,17,247,181,148,7,64,151,236,147,33,149,142,98,170,219,55,60,7,46,12,82,233,216,55,223,33,228,187,245,219,88,205,58,79,190,237,228,129,176,178,184,96,21,133,228,120,158,97,235,139,4,253,63,151,191,120,231,218,56,32,140,35,128,25,147,30,37,29,52,28,185,169,147,75,133,49,227,100,179,18,93,139,196,246,13,102,218,144,221,205,18,2,223,167,219,57,156,160,66,179,128,115,36,68,81,4,200,191,196,31,104,106,89,220,131,187,70,19,16,175,139,187,65,229,111,20,35,214,130,176,24,47,243,184,238,249,210,189,67,60,36,89,234,45,215,4,161,233,72,104,111,210,10,115,94,114,44,134,78,89,58,200,206,31,102,116,56,225,235,49,190,205,27,234,156,184,114,191,205,208,231,105,113,115,120,187,146,243,47,7,72,16,213,152,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("dd2e4593-dbe9-4b91-9fef-074b97ab2c88"));
		}

		#endregion

	}

	#endregion

}

