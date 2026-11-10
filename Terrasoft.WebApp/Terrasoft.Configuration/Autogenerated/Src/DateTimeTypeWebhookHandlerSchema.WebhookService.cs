namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: DateTimeTypeWebhookHandlerSchema

	/// <exclude/>
	public class DateTimeTypeWebhookHandlerSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public DateTimeTypeWebhookHandlerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public DateTimeTypeWebhookHandlerSchema(DateTimeTypeWebhookHandlerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("f6423a49-1ee5-458c-ab0f-20db6e65c91d");
			Name = "DateTimeTypeWebhookHandler";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("d7950703-7230-445f-b3e5-fcd99a7a2e60");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,141,146,77,107,220,48,16,134,207,27,200,127,24,156,203,26,130,125,223,15,67,187,161,180,135,150,133,93,232,161,244,160,181,199,187,106,109,201,140,164,20,83,242,223,59,150,37,103,219,196,161,23,99,141,222,121,103,230,25,41,209,162,233,68,137,112,68,34,97,116,109,179,157,86,181,60,59,18,86,106,117,123,243,251,246,102,225,140,84,103,56,244,198,98,187,158,206,215,41,132,217,7,81,90,77,18,13,43,88,115,71,120,102,3,216,53,194,152,21,60,8,139,71,217,226,177,239,240,43,158,46,90,255,252,40,84,213,32,121,117,158,231,176,49,174,109,5,245,69,56,7,25,92,70,29,212,154,88,131,8,37,97,189,77,162,99,146,23,96,217,53,139,54,249,63,62,67,142,104,140,14,121,51,147,102,159,118,206,88,221,190,108,48,129,124,176,250,246,128,181,112,141,125,47,85,197,227,47,135,154,186,94,206,166,165,247,240,133,241,194,22,146,249,225,147,244,59,91,119,238,212,200,18,202,1,213,27,164,96,5,179,213,216,101,216,212,132,125,79,186,67,178,188,142,21,236,189,189,231,252,2,180,15,176,248,81,86,92,64,113,195,217,36,187,6,25,123,52,150,134,221,199,140,113,194,34,238,234,160,29,149,200,92,141,21,202,154,236,157,234,215,111,212,245,189,15,118,113,127,243,117,135,137,199,207,118,92,55,163,143,164,210,80,227,14,85,53,142,31,206,129,197,103,180,23,93,253,15,136,169,161,95,225,237,117,130,120,66,203,104,30,69,227,230,122,244,17,47,245,4,183,137,84,157,179,73,113,24,97,249,84,208,245,43,174,195,155,142,69,179,77,238,47,158,45,9,173,35,101,138,77,30,255,174,136,232,211,15,44,237,152,141,203,176,23,95,56,5,255,20,22,178,134,137,81,118,164,126,47,200,224,210,75,238,65,59,59,61,53,32,52,252,178,211,152,184,24,203,133,240,218,199,158,252,55,92,40,215,52,62,252,244,42,249,49,250,119,144,99,127,0,166,221,26,181,110,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("f6423a49-1ee5-458c-ab0f-20db6e65c91d"));
		}

		#endregion

	}

	#endregion

}

