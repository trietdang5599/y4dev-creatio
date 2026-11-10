namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: EmailAttachmentUploaderSchema

	/// <exclude/>
	public class EmailAttachmentUploaderSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public EmailAttachmentUploaderSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public EmailAttachmentUploaderSchema(EmailAttachmentUploaderSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("e7453c0f-fd21-4f21-8c73-c15c9fdbf8ae");
			Name = "EmailAttachmentUploader";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("5e01e2a5-733f-47cc-a4c2-452cdff090f0");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,125,82,93,107,220,48,16,124,190,66,255,131,112,95,108,56,236,247,92,114,112,77,227,112,208,180,165,73,158,66,40,138,188,246,9,108,201,72,171,43,38,228,191,119,101,221,151,156,94,222,164,213,236,236,204,104,21,239,192,246,92,0,123,0,99,184,213,53,230,215,90,213,178,113,134,163,212,138,189,126,254,52,115,86,170,134,221,15,22,161,91,76,238,249,250,231,177,180,86,8,77,104,92,245,50,247,87,83,19,187,61,66,206,204,201,75,217,194,99,223,106,94,253,31,107,224,92,61,47,185,64,109,228,56,133,48,95,12,52,94,249,117,203,173,189,96,55,29,151,237,10,145,139,77,7,10,195,12,48,35,244,233,27,212,220,181,248,85,170,138,136,83,28,122,208,117,186,62,138,1,147,205,217,15,74,137,93,177,228,12,85,146,61,19,87,239,94,90,41,152,240,83,207,13,101,23,44,226,166,182,215,81,200,65,116,41,161,173,72,245,47,35,183,28,33,60,22,69,193,46,173,235,58,110,134,229,177,0,192,132,129,250,42,121,180,96,40,77,5,194,71,153,20,75,38,149,69,174,4,228,7,116,113,218,223,7,118,22,55,178,63,46,186,47,118,210,64,85,65,93,44,149,128,22,141,243,217,123,193,163,253,128,216,69,113,38,132,116,50,213,137,108,220,178,217,108,50,159,34,119,194,255,250,236,237,99,37,119,128,27,93,77,68,140,174,165,218,128,145,88,105,177,139,42,138,63,15,135,32,49,189,117,178,154,51,178,68,155,48,103,47,3,194,211,115,70,97,158,56,218,106,89,177,119,77,172,38,206,245,161,151,41,90,151,61,1,171,56,242,189,191,45,55,35,246,55,244,218,74,202,109,32,139,227,154,134,21,30,242,91,192,203,50,66,44,83,5,127,79,179,94,153,198,249,56,211,36,78,43,153,79,255,47,203,22,209,216,27,133,18,135,181,170,53,141,245,172,229,161,24,60,249,167,52,89,81,243,150,106,254,149,72,247,230,188,171,189,145,25,13,65,210,176,227,185,131,142,148,222,163,1,222,165,163,225,121,128,61,104,228,173,231,249,14,170,193,13,193,253,107,30,110,35,228,45,72,140,83,217,253,139,111,76,99,225,36,135,183,22,178,15,182,34,84,227,34,213,254,1,246,38,199,254,234,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("e7453c0f-fd21-4f21-8c73-c15c9fdbf8ae"));
		}

		#endregion

	}

	#endregion

}

