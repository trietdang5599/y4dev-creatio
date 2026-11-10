namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: ContactCommunicationEventListenerSchema

	/// <exclude/>
	public class ContactCommunicationEventListenerSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ContactCommunicationEventListenerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ContactCommunicationEventListenerSchema(ContactCommunicationEventListenerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("e6c1be4d-3981-4ba8-9ed8-474f0e090c47");
			Name = "ContactCommunicationEventListener";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("9cc3d920-8a68-437c-9367-c8131a0a7723");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,141,85,77,79,227,48,16,61,23,137,255,96,178,151,68,170,162,61,243,37,241,81,80,37,96,171,13,236,30,86,123,112,157,105,235,85,98,119,253,81,96,17,255,157,177,157,166,14,164,116,47,136,216,243,222,204,155,121,158,10,90,131,94,82,6,228,30,148,162,90,206,76,126,33,197,140,207,173,162,134,75,177,191,247,178,191,55,176,154,139,57,41,158,181,129,250,168,253,142,33,117,45,69,255,141,130,109,231,249,229,249,214,171,145,48,220,112,208,59,3,242,209,10,132,249,36,238,201,128,18,180,122,208,160,182,71,93,81,102,164,10,249,48,230,139,130,57,138,39,23,21,213,250,144,96,71,12,6,56,149,86,112,230,27,227,211,222,112,236,136,0,229,65,191,124,73,207,157,139,180,96,11,168,233,29,182,153,156,144,164,143,40,201,126,35,120,105,167,21,103,132,185,132,187,243,29,146,115,170,161,39,31,50,189,248,98,90,9,183,96,22,178,68,17,19,197,87,212,64,184,93,134,15,50,149,178,34,215,96,198,58,238,83,39,113,122,109,121,73,88,40,105,92,14,73,136,16,2,152,187,38,182,243,153,17,231,151,193,96,69,21,209,80,225,33,234,22,240,72,10,255,145,190,139,246,177,131,1,14,193,10,147,38,227,50,105,142,242,43,37,235,52,65,203,157,149,53,23,15,130,155,246,234,231,2,20,164,235,102,58,76,142,245,255,181,180,74,47,100,101,107,145,79,168,194,142,163,160,180,173,59,91,163,207,68,233,177,77,9,247,207,75,248,140,192,169,117,49,121,81,76,178,140,80,221,40,57,106,101,66,236,48,47,4,37,7,237,232,62,96,214,64,193,104,69,213,49,23,230,52,205,2,82,129,177,74,244,129,15,78,200,87,31,243,218,76,18,68,25,134,185,109,178,222,59,205,96,131,143,228,10,253,205,75,32,43,137,195,251,38,10,186,66,215,167,114,250,199,77,68,35,35,168,33,9,6,58,135,25,62,1,111,163,51,53,215,4,214,51,156,162,199,242,22,187,6,65,22,73,247,4,40,55,13,84,89,8,218,4,176,216,73,174,141,227,18,163,3,44,71,223,185,163,50,244,252,7,173,44,28,59,179,157,186,249,124,192,37,77,94,62,35,105,31,45,182,205,129,221,232,52,164,31,8,112,226,218,224,182,168,41,175,156,27,26,141,205,28,2,245,107,84,119,99,155,255,172,182,117,226,70,122,215,233,27,158,238,243,217,104,58,216,241,12,163,23,248,238,17,237,208,2,78,242,231,58,180,81,56,98,84,114,103,235,41,168,88,134,71,99,20,47,41,110,72,164,241,59,49,236,75,79,118,60,142,107,246,253,189,148,248,87,180,160,214,243,142,143,235,81,203,232,138,234,208,227,51,244,255,71,44,87,82,197,252,169,7,68,86,56,136,9,219,78,4,65,4,127,220,52,157,67,179,130,110,36,62,67,254,143,78,43,40,252,253,187,109,148,127,7,45,173,98,120,43,21,194,134,205,118,234,93,219,157,181,155,12,73,242,129,29,205,166,148,84,183,161,134,220,119,122,221,217,129,89,40,249,24,22,99,49,193,188,136,96,6,98,225,163,39,6,75,63,249,70,69,22,13,182,127,53,132,211,238,225,235,27,209,140,148,118,227,7,0,0 };
		}

		protected override void InitializeLocalizableStrings() {
			base.InitializeLocalizableStrings();
			SetLocalizableStringsDefInheritance();
			LocalizableStrings.Add(CreateErrorMessageLocalizableString());
		}

		protected virtual SchemaLocalizableString CreateErrorMessageLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("e4acc0dc-d8bb-0687-baa4-abd07ca5eb85"),
				Name = "ErrorMessage",
				CreatedInPackageId = new Guid("9cc3d920-8a68-437c-9367-c8131a0a7723"),
				CreatedInSchemaUId = new Guid("e6c1be4d-3981-4ba8-9ed8-474f0e090c47"),
				ModifiedInSchemaUId = new Guid("e6c1be4d-3981-4ba8-9ed8-474f0e090c47")
			};
			return localizableString;
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("e6c1be4d-3981-4ba8-9ed8-474f0e090c47"));
		}

		#endregion

	}

	#endregion

}

