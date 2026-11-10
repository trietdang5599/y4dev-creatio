namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: EmailProcessTemplateUserTaskMessageProviderSchema

	/// <exclude/>
	public class EmailProcessTemplateUserTaskMessageProviderSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public EmailProcessTemplateUserTaskMessageProviderSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public EmailProcessTemplateUserTaskMessageProviderSchema(EmailProcessTemplateUserTaskMessageProviderSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("0b79b40c-b679-49a4-ace9-9049573f8669");
			Name = "EmailProcessTemplateUserTaskMessageProvider";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("da7de29a-d2b3-4248-bf8e-b7a592dc81f6");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,149,145,65,110,194,48,16,69,215,65,226,14,150,186,73,55,57,0,136,5,80,212,21,18,45,244,0,38,153,4,171,137,29,102,108,164,8,113,247,142,157,132,146,66,23,236,236,241,255,243,223,120,180,172,128,106,153,130,216,1,162,36,147,219,100,105,16,146,13,154,20,136,248,162,115,85,56,148,86,25,61,30,157,199,163,200,145,210,197,64,127,35,233,141,111,64,170,208,128,211,135,6,14,88,105,171,172,2,98,1,75,94,16,10,118,139,101,41,137,38,98,85,73,85,118,157,118,80,213,165,180,240,69,128,59,73,223,107,174,201,2,248,245,164,50,192,96,175,221,190,84,169,72,189,251,25,179,152,136,133,36,232,196,193,120,215,62,58,135,136,95,68,163,201,162,75,173,65,38,221,132,228,86,209,81,60,145,31,7,237,95,145,112,221,225,213,119,141,38,98,207,140,241,181,40,252,18,162,75,71,5,58,107,193,134,148,107,176,7,147,121,64,52,22,82,11,89,199,216,95,133,57,241,66,24,66,240,52,126,63,239,96,3,205,194,100,77,220,133,68,8,214,161,110,71,234,241,18,175,152,222,48,60,232,25,182,219,108,211,3,84,242,195,1,54,190,253,150,89,1,87,116,188,182,191,151,1,29,197,44,12,156,12,29,33,48,82,185,136,135,48,94,210,254,98,83,131,152,205,68,172,180,125,29,84,147,185,179,166,143,140,56,33,97,247,60,171,148,254,84,197,193,18,7,230,178,36,104,35,46,183,131,179,120,250,255,111,183,213,97,241,242,3,220,94,197,116,83,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("0b79b40c-b679-49a4-ace9-9049573f8669"));
		}

		#endregion

	}

	#endregion

}

