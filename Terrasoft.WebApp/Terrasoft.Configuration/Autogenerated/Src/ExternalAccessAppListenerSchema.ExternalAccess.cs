namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: ExternalAccessAppListenerSchema

	/// <exclude/>
	public class ExternalAccessAppListenerSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ExternalAccessAppListenerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ExternalAccessAppListenerSchema(ExternalAccessAppListenerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("22d9fa35-9564-4de9-b89c-b84ecaec99df");
			Name = "ExternalAccessAppListener";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("c3c7809d-fee0-4b66-8bb6-9b3983c2cffd");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,181,86,109,111,219,54,16,254,236,2,253,15,172,182,15,52,144,40,77,155,118,70,155,122,112,83,57,53,208,151,32,90,218,15,195,48,208,212,217,225,38,145,30,73,121,75,131,252,247,30,69,73,53,101,41,29,6,236,147,196,227,241,238,185,231,94,72,201,10,48,27,198,129,252,2,90,51,163,86,54,62,83,114,37,214,165,102,86,40,25,39,255,88,208,146,229,51,206,193,152,11,198,255,100,107,120,248,224,246,225,131,81,105,132,92,147,244,198,88,40,94,182,235,93,67,69,161,100,255,142,134,33,121,232,127,80,235,205,235,193,173,57,227,86,105,1,166,79,227,51,44,239,1,230,118,223,90,187,137,103,75,99,53,218,65,8,206,12,170,254,160,97,141,43,114,150,51,99,94,144,144,151,217,102,243,78,32,15,18,116,165,124,116,116,68,78,133,188,6,45,108,166,248,209,20,101,155,114,153,11,78,184,59,63,124,156,188,32,184,74,182,32,109,35,122,205,12,50,62,186,173,44,183,56,230,2,242,12,129,92,104,177,101,22,252,230,198,47,136,177,200,30,39,26,88,166,100,126,67,206,75,145,145,223,33,112,154,242,107,40,216,213,34,35,175,136,132,191,43,29,26,205,159,78,158,77,146,147,231,135,201,236,233,228,240,228,248,73,114,56,155,159,204,14,159,60,62,62,158,63,158,252,116,60,153,37,209,248,101,141,5,100,230,225,132,216,222,131,189,86,131,224,42,48,231,96,67,14,206,53,147,152,54,122,101,64,99,9,72,168,200,39,101,176,60,240,135,195,64,22,217,152,184,122,28,141,182,76,19,3,57,234,98,76,52,173,254,198,46,54,255,75,67,99,227,234,204,8,203,33,55,52,170,253,47,178,168,145,207,181,42,104,20,162,140,14,72,4,172,85,249,140,25,6,234,36,40,119,71,227,133,73,254,42,89,78,209,104,89,200,248,130,105,108,49,180,64,247,48,59,18,209,134,199,139,125,6,188,180,144,98,61,230,112,9,92,233,140,186,244,97,69,188,154,18,255,23,35,105,222,238,39,150,151,112,234,184,152,6,200,15,136,42,45,113,52,172,27,97,237,70,131,45,181,252,38,174,164,119,97,98,58,212,163,183,80,66,119,121,190,198,54,193,45,139,113,249,144,20,34,245,221,225,27,240,198,193,61,93,188,221,215,155,210,26,84,199,14,158,239,177,234,204,44,36,86,180,228,64,195,104,118,180,127,142,83,212,70,144,191,70,33,232,232,55,194,76,39,180,190,224,183,10,11,235,12,137,182,72,127,33,100,134,153,152,43,29,166,159,226,84,112,19,35,231,95,210,234,239,3,102,183,97,229,222,202,197,216,122,248,244,209,136,21,161,93,109,236,201,50,207,27,211,117,192,94,253,174,229,174,91,83,232,36,180,211,25,223,117,218,43,135,221,179,174,114,139,141,189,161,227,123,156,186,131,143,112,226,167,96,45,70,111,92,110,170,90,164,221,62,237,244,77,157,156,15,202,138,149,224,213,104,79,36,91,230,144,97,231,172,88,110,224,62,183,61,77,223,22,189,39,182,127,150,116,65,237,245,224,16,29,173,245,127,197,74,93,20,25,24,174,197,166,206,182,27,59,239,20,103,185,248,226,226,244,229,210,65,20,95,130,81,165,230,184,171,52,222,171,123,180,237,92,12,209,129,119,255,99,180,103,213,196,183,65,65,222,197,85,78,162,157,46,211,77,73,95,89,145,11,139,151,99,95,179,94,238,105,77,191,117,92,119,43,238,52,203,30,219,142,129,118,215,223,234,116,232,14,106,217,157,149,120,117,232,190,82,62,43,181,198,91,209,181,144,123,35,88,196,189,200,106,82,218,53,30,27,200,100,173,153,150,203,63,160,87,179,85,121,19,228,113,39,171,62,229,227,221,233,241,253,27,176,186,245,253,102,223,171,160,121,22,168,45,62,66,68,86,207,161,143,178,110,152,212,50,109,105,243,34,104,230,36,247,223,134,180,239,78,173,254,102,172,108,67,246,30,87,88,123,81,16,215,127,128,154,200,236,127,2,138,150,7,96,118,232,247,210,80,136,178,175,142,217,10,22,230,10,0,0 };
		}

		protected override void InitializeLocalizableStrings() {
			base.InitializeLocalizableStrings();
			SetLocalizableStringsDefInheritance();
			LocalizableStrings.Add(CreateExternalAccessSessionStartedMessageLocalizableString());
			LocalizableStrings.Add(CreateExternalAccessSessionEndedMessageLocalizableString());
		}

		protected virtual SchemaLocalizableString CreateExternalAccessSessionStartedMessageLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("400920bc-ccb5-41e3-ac22-d74e0dc85be5"),
				Name = "ExternalAccessSessionStartedMessage",
				CreatedInPackageId = new Guid("c3c7809d-fee0-4b66-8bb6-9b3983c2cffd"),
				CreatedInSchemaUId = new Guid("22d9fa35-9564-4de9-b89c-b84ecaec99df"),
				ModifiedInSchemaUId = new Guid("22d9fa35-9564-4de9-b89c-b84ecaec99df")
			};
			return localizableString;
		}

		protected virtual SchemaLocalizableString CreateExternalAccessSessionEndedMessageLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("7f54a547-ff83-45e6-9501-b0794feebae8"),
				Name = "ExternalAccessSessionEndedMessage",
				CreatedInPackageId = new Guid("c3c7809d-fee0-4b66-8bb6-9b3983c2cffd"),
				CreatedInSchemaUId = new Guid("22d9fa35-9564-4de9-b89c-b84ecaec99df"),
				ModifiedInSchemaUId = new Guid("22d9fa35-9564-4de9-b89c-b84ecaec99df")
			};
			return localizableString;
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("22d9fa35-9564-4de9-b89c-b84ecaec99df"));
		}

		#endregion

	}

	#endregion

}

