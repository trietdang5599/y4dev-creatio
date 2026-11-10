namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: EmailUserTaskMessageProviderFactorySchema

	/// <exclude/>
	public class EmailUserTaskMessageProviderFactorySchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public EmailUserTaskMessageProviderFactorySchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public EmailUserTaskMessageProviderFactorySchema(EmailUserTaskMessageProviderFactorySchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("31e7a4a6-b0cf-4c1c-8657-06e2b3d26b6a");
			Name = "EmailUserTaskMessageProviderFactory";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("da7de29a-d2b3-4248-bf8e-b7a592dc81f6");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,141,146,193,110,130,64,16,134,207,152,248,14,147,244,130,23,30,64,111,181,182,241,96,99,82,250,0,219,101,196,77,97,151,204,12,181,196,248,238,93,22,48,74,27,235,133,48,255,204,247,255,19,6,171,74,228,74,105,132,20,137,20,187,157,36,75,71,152,108,201,105,100,246,133,221,153,188,38,37,198,217,233,228,56,157,68,53,27,155,195,91,195,130,229,226,92,95,242,23,200,96,244,132,108,114,139,228,1,143,60,16,230,190,9,203,66,49,207,97,85,42,83,188,51,82,170,248,115,227,167,85,142,158,251,50,25,210,179,210,226,168,9,88,85,127,20,70,3,139,183,214,160,91,248,62,54,58,6,254,156,187,65,217,187,204,39,111,131,99,215,188,118,95,223,50,134,23,148,208,31,233,113,16,83,44,171,66,9,14,48,212,253,203,12,218,239,23,69,124,48,162,247,16,199,143,46,107,134,233,180,169,112,54,76,38,191,58,61,26,105,197,8,227,110,114,149,59,239,38,35,66,169,201,130,197,3,252,185,215,120,249,243,154,139,91,81,253,65,255,11,27,141,221,155,153,225,78,213,133,12,174,178,39,119,8,166,175,78,214,222,10,75,180,130,217,234,91,99,213,254,95,113,15,158,218,231,169,191,50,218,172,59,116,168,59,245,90,244,218,15,110,43,168,227,251,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("31e7a4a6-b0cf-4c1c-8657-06e2b3d26b6a"));
		}

		#endregion

	}

	#endregion

}

