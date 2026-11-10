namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: IWebhookJobDispatcherSchema

	/// <exclude/>
	public class IWebhookJobDispatcherSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IWebhookJobDispatcherSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IWebhookJobDispatcherSchema(IWebhookJobDispatcherSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("f88bd532-c1ef-4062-8d6a-629a16ac98df");
			Name = "IWebhookJobDispatcher";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("465cad42-ff63-4d73-9a55-2ad1421a09f5");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,149,82,203,78,195,48,16,60,183,82,255,97,213,30,40,151,228,222,134,92,64,170,138,64,66,180,18,103,39,217,36,134,216,14,94,27,168,42,254,157,141,211,84,80,137,215,113,199,179,243,176,173,133,66,106,69,142,176,69,107,5,153,210,69,151,70,151,178,242,86,56,105,244,100,188,159,140,71,158,164,174,96,179,35,135,106,121,50,51,191,105,48,239,200,20,173,80,163,149,57,115,152,53,179,88,49,10,107,237,208,150,108,178,128,245,3,102,181,49,79,215,38,187,146,108,236,242,26,109,32,199,113,12,9,121,165,132,221,165,135,249,30,91,139,132,218,17,40,116,181,41,8,74,99,225,209,100,116,6,74,104,81,161,226,211,104,88,143,63,237,183,62,107,100,14,114,240,254,206,122,180,15,246,199,176,183,189,209,2,238,130,64,127,120,26,46,0,27,22,40,124,131,160,241,205,117,161,66,56,87,35,80,139,185,44,37,22,240,218,123,18,100,157,95,116,212,138,79,197,146,86,88,161,64,243,123,92,76,3,121,93,76,211,45,139,121,45,159,61,130,44,184,105,39,106,193,148,7,185,36,14,91,65,228,197,200,226,24,137,59,206,87,158,129,131,210,249,242,47,61,186,123,253,181,3,210,63,91,208,52,253,41,39,205,111,36,185,164,75,155,14,113,105,200,59,67,93,244,239,18,230,247,254,91,125,1,25,251,0,151,196,108,18,197,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("f88bd532-c1ef-4062-8d6a-629a16ac98df"));
		}

		#endregion

	}

	#endregion

}

