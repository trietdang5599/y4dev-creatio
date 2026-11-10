namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: ActivityEmailSenderSchema

	/// <exclude/>
	public class ActivityEmailSenderSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ActivityEmailSenderSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ActivityEmailSenderSchema(ActivityEmailSenderSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("b1422ac9-6446-43b6-80b8-7d67c06e67e1");
			Name = "ActivityEmailSender";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("acb004d0-c421-4dff-b075-f4fdc1c90074");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,141,83,93,107,227,48,16,124,118,161,255,97,201,61,156,3,193,126,111,154,64,47,164,165,15,129,210,222,253,0,69,89,59,58,108,201,104,229,28,161,244,191,223,74,254,72,156,58,165,143,146,102,103,103,102,87,90,148,72,149,144,8,191,209,90,65,38,115,201,70,168,34,121,67,189,67,123,123,243,126,123,19,213,164,116,14,111,71,114,88,206,251,243,169,96,101,116,166,242,218,10,167,140,30,7,88,188,118,159,172,181,83,78,33,49,128,33,63,44,230,204,2,171,66,16,221,193,131,116,234,160,220,113,93,178,168,78,19,195,210,52,133,123,170,203,82,216,227,18,94,177,178,72,168,29,129,219,35,80,192,129,244,20,96,178,112,103,182,127,81,186,159,4,158,8,216,52,137,28,137,57,16,65,90,204,22,147,174,213,36,93,38,247,105,199,205,189,170,122,91,40,217,210,141,8,130,81,153,191,4,33,23,191,7,185,39,91,70,147,179,181,116,198,18,215,189,4,234,6,50,176,52,162,235,140,155,37,130,167,24,234,108,24,42,97,69,9,154,231,186,152,160,47,89,21,138,147,121,20,190,224,56,89,62,104,80,172,65,104,158,121,155,77,136,68,6,24,100,13,142,153,3,209,56,111,77,104,217,137,230,68,217,212,40,167,135,128,236,49,3,190,54,208,17,99,241,243,250,147,100,248,236,98,6,127,6,10,96,40,104,234,155,68,119,176,229,17,196,99,213,23,112,240,75,30,125,180,147,98,33,205,176,134,147,219,160,219,155,29,175,228,139,53,142,11,113,215,188,87,221,17,14,202,186,90,20,189,47,240,158,226,167,90,237,64,180,87,207,187,217,233,153,76,109,37,118,199,25,4,235,155,102,51,187,13,157,5,43,209,214,152,2,84,174,249,191,188,170,124,207,123,190,224,73,21,132,83,88,132,72,163,184,227,153,122,215,225,251,198,231,93,47,155,117,252,3,214,233,252,154,167,131,97,23,43,83,86,5,58,244,228,252,145,251,150,189,61,175,38,164,158,92,66,123,196,252,187,41,159,253,140,118,95,52,254,251,58,219,208,254,235,32,174,244,111,102,63,188,252,248,15,80,37,29,233,28,5,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("b1422ac9-6446-43b6-80b8-7d67c06e67e1"));
		}

		#endregion

	}

	#endregion

}

