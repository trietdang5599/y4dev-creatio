namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: OAuthResourceListenerSchema

	/// <exclude/>
	public class OAuthResourceListenerSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public OAuthResourceListenerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public OAuthResourceListenerSchema(OAuthResourceListenerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("5df6ce04-ddc6-56cc-e05b-a60552c68db2");
			Name = "OAuthResourceListener";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("c966bd43-e9f4-4f60-86c2-6f60723d4eee");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,229,86,75,111,219,70,16,62,43,64,254,195,128,189,80,128,64,21,61,58,182,0,69,86,83,1,177,29,68,74,123,8,114,88,147,35,137,45,185,75,236,46,21,187,134,255,123,103,95,124,40,82,45,33,8,80,160,39,155,171,121,126,243,205,131,179,18,85,197,82,132,21,74,201,148,88,235,100,38,248,58,223,212,146,233,92,240,228,110,90,235,237,47,63,191,126,245,244,250,213,160,86,57,223,192,242,81,105,44,223,236,125,147,94,81,96,106,148,84,242,14,57,202,60,109,101,186,230,203,82,240,195,191,72,76,230,92,231,58,71,245,162,64,50,223,33,215,7,229,108,204,11,174,113,227,147,184,94,221,157,36,55,127,72,177,50,255,145,52,201,255,36,113,67,31,48,43,152,82,23,96,197,63,162,18,181,76,241,125,78,73,83,146,86,240,179,13,234,209,70,20,126,136,151,233,22,75,118,75,8,195,21,68,61,229,104,248,133,180,170,250,190,200,83,72,141,245,195,198,225,2,222,50,133,246,183,105,149,207,24,33,76,30,7,79,214,107,27,31,65,174,101,157,106,33,41,204,15,214,172,147,240,46,14,26,143,135,100,254,158,204,199,28,191,194,117,110,75,199,228,227,229,234,177,194,17,144,69,66,107,66,82,166,242,131,193,19,104,122,23,235,152,2,89,162,220,161,108,208,26,142,32,122,47,82,86,228,127,179,251,2,151,86,83,37,193,225,71,138,146,92,154,199,185,148,66,222,160,82,108,131,201,239,172,168,49,130,231,209,17,251,148,22,55,132,218,25,104,95,240,21,100,5,63,232,194,120,120,166,76,158,61,112,200,51,135,93,31,200,27,212,91,145,25,12,101,190,99,26,61,136,238,3,40,176,144,210,130,175,5,188,67,221,121,250,85,138,210,209,32,118,127,0,237,159,81,23,90,7,106,3,46,84,82,84,40,13,157,137,35,188,46,138,128,246,142,73,144,222,178,167,144,51,71,173,165,77,129,50,106,183,186,228,54,193,203,80,171,200,136,70,195,55,223,152,184,206,85,85,176,199,51,44,117,52,186,6,89,155,176,137,152,136,179,143,138,139,127,224,93,117,115,112,117,30,244,99,57,16,161,151,251,208,197,166,5,202,254,248,236,34,146,168,107,201,187,65,217,247,211,171,44,52,145,6,179,80,103,255,9,130,216,39,243,12,97,39,242,12,86,91,41,190,54,4,140,29,68,128,150,103,106,51,132,171,9,104,35,98,225,232,181,90,171,212,72,191,57,53,182,78,23,143,199,99,184,84,117,89,18,133,38,225,225,55,198,179,130,176,113,197,132,37,219,81,224,104,38,80,210,232,140,247,149,46,43,38,89,9,156,80,190,138,20,197,128,50,154,216,177,5,238,43,185,28,91,145,195,26,24,77,86,91,164,88,16,33,149,184,190,138,86,23,71,199,179,141,107,186,166,198,183,14,166,114,163,34,24,79,32,167,97,197,56,241,39,21,92,179,156,27,48,245,22,131,67,155,2,100,76,179,94,44,126,146,245,43,115,199,23,92,25,90,240,77,44,238,255,164,226,249,52,70,224,220,191,197,53,5,213,248,7,12,253,53,219,98,250,215,140,241,27,198,105,78,44,169,3,92,109,173,182,231,187,153,141,73,215,69,176,141,157,134,240,240,95,129,239,250,161,19,106,5,250,45,222,159,180,251,227,192,247,206,19,68,166,49,35,26,117,211,170,162,180,237,118,154,166,41,77,53,63,204,66,7,236,119,95,191,63,143,78,168,48,154,218,224,124,74,243,7,76,107,141,126,217,196,177,101,119,223,232,34,115,218,102,72,231,41,254,33,89,69,54,146,105,150,5,161,184,163,48,2,218,76,72,83,219,15,157,79,170,29,236,130,183,88,250,159,151,168,59,227,40,142,236,50,32,170,105,2,163,99,53,105,222,135,221,142,63,177,81,108,251,254,215,58,101,143,170,223,209,42,54,24,12,163,199,187,119,71,218,29,85,202,146,137,128,36,206,153,97,215,204,168,104,50,171,165,52,22,107,170,17,101,169,148,81,207,149,177,192,204,88,116,247,19,62,80,75,115,86,0,179,132,236,96,216,248,252,183,142,117,248,255,184,118,245,246,247,122,245,12,130,92,99,129,250,255,72,145,5,223,209,89,149,53,28,233,48,163,193,132,113,183,225,154,189,109,248,193,133,6,82,42,115,77,44,57,151,15,193,244,153,140,56,105,246,134,32,151,116,25,19,111,218,211,167,63,133,154,75,213,203,57,3,126,207,151,238,148,244,195,251,155,211,51,222,243,49,218,59,245,195,181,109,134,121,120,11,41,119,79,213,112,100,181,151,196,209,114,196,62,164,30,179,143,160,251,169,162,218,255,208,126,107,60,156,189,29,191,107,119,117,156,40,187,8,78,188,107,219,133,226,45,228,107,136,157,133,100,161,110,133,190,165,43,252,78,206,203,138,92,13,3,30,29,63,126,141,127,254,2,79,193,179,223,197,135,151,231,145,117,105,97,195,195,27,211,59,122,121,105,250,3,216,125,60,31,95,224,103,199,240,162,235,195,39,182,123,237,63,210,219,63,52,36,177,67,102,16,0,0 };
		}

		protected override void InitializeLocalizableStrings() {
			base.InitializeLocalizableStrings();
			SetLocalizableStringsDefInheritance();
			LocalizableStrings.Add(CreateConnectionErrorMessageLocalizableString());
			LocalizableStrings.Add(CreateResourceRegisteringErrorMessageLocalizableString());
			LocalizableStrings.Add(CreateResourceModifyingErrorMessageLocalizableString());
			LocalizableStrings.Add(CreateResourceDeletingErrorMessageLocalizableString());
		}

		protected virtual SchemaLocalizableString CreateConnectionErrorMessageLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("e03aaebb-193b-8726-710a-929627d6b105"),
				Name = "ConnectionErrorMessage",
				CreatedInPackageId = new Guid("c966bd43-e9f4-4f60-86c2-6f60723d4eee"),
				CreatedInSchemaUId = new Guid("5df6ce04-ddc6-56cc-e05b-a60552c68db2"),
				ModifiedInSchemaUId = new Guid("5df6ce04-ddc6-56cc-e05b-a60552c68db2")
			};
			return localizableString;
		}

		protected virtual SchemaLocalizableString CreateResourceRegisteringErrorMessageLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("21597b70-844d-8f8f-62df-ff422643519c"),
				Name = "ResourceRegisteringErrorMessage",
				CreatedInPackageId = new Guid("c966bd43-e9f4-4f60-86c2-6f60723d4eee"),
				CreatedInSchemaUId = new Guid("5df6ce04-ddc6-56cc-e05b-a60552c68db2"),
				ModifiedInSchemaUId = new Guid("5df6ce04-ddc6-56cc-e05b-a60552c68db2")
			};
			return localizableString;
		}

		protected virtual SchemaLocalizableString CreateResourceModifyingErrorMessageLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("592cb685-553c-4598-8deb-f17e38c2101e"),
				Name = "ResourceModifyingErrorMessage",
				CreatedInPackageId = new Guid("1cbe3766-af85-4075-b77c-3de2d413d0be"),
				CreatedInSchemaUId = new Guid("5df6ce04-ddc6-56cc-e05b-a60552c68db2"),
				ModifiedInSchemaUId = new Guid("5df6ce04-ddc6-56cc-e05b-a60552c68db2")
			};
			return localizableString;
		}

		protected virtual SchemaLocalizableString CreateResourceDeletingErrorMessageLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("12e7cc28-c036-6369-e37b-184500b360e6"),
				Name = "ResourceDeletingErrorMessage",
				CreatedInPackageId = new Guid("49af2168-effb-4b7f-bce2-28e45d430d96"),
				CreatedInSchemaUId = new Guid("5df6ce04-ddc6-56cc-e05b-a60552c68db2"),
				ModifiedInSchemaUId = new Guid("5df6ce04-ddc6-56cc-e05b-a60552c68db2")
			};
			return localizableString;
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("5df6ce04-ddc6-56cc-e05b-a60552c68db2"));
		}

		#endregion

	}

	#endregion

}

