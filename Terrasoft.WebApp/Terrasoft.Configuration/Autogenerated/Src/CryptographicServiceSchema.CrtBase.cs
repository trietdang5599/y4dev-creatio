namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: CryptographicServiceSchema

	/// <exclude/>
	public class CryptographicServiceSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public CryptographicServiceSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public CryptographicServiceSchema(CryptographicServiceSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("ba8f2b10-80c4-416c-92db-1fe39960f378");
			Name = "CryptographicService";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("55f82158-5486-4bb7-b202-c8f84f805cfa");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,133,83,77,107,227,48,16,61,187,208,255,32,146,139,3,65,190,111,210,66,155,166,75,23,210,132,186,108,15,97,15,138,61,73,69,173,143,29,201,46,166,244,191,87,178,229,216,13,75,214,216,198,122,243,230,205,147,102,44,153,0,163,89,6,228,25,16,153,81,123,75,23,74,238,249,161,68,102,185,146,151,23,31,151,23,81,105,184,60,144,180,54,22,4,77,1,43,158,193,74,229,80,204,206,5,233,11,236,206,19,110,50,203,171,166,78,207,235,141,184,116,103,70,136,127,71,23,10,129,46,101,134,181,14,2,142,180,13,242,110,15,22,89,102,255,120,236,198,232,71,176,78,73,187,82,59,94,112,91,63,193,223,146,35,8,144,214,196,195,133,247,69,174,200,127,82,60,139,6,32,159,248,34,186,220,21,60,35,89,193,140,33,11,239,73,29,144,233,87,158,5,71,228,7,185,101,6,186,149,63,213,104,187,214,208,30,243,208,111,180,117,27,127,144,149,122,131,120,5,246,85,229,206,208,104,179,78,159,71,83,114,171,242,58,181,117,225,77,58,218,10,140,97,7,56,162,244,197,21,213,144,79,189,78,228,29,130,177,247,10,5,179,223,18,90,136,254,50,74,78,201,147,27,1,37,13,156,231,249,109,122,213,36,73,200,220,148,66,48,172,175,59,96,60,188,200,201,7,25,64,99,114,183,76,233,81,39,57,21,154,107,134,76,16,233,230,242,106,164,221,97,190,43,204,71,215,189,222,160,20,157,39,13,187,79,70,176,37,74,19,232,211,239,182,198,39,203,110,237,100,186,60,47,20,58,105,44,250,121,251,233,167,64,86,128,22,242,77,176,243,155,21,37,196,129,208,121,156,180,45,141,248,158,132,16,125,48,143,101,81,172,113,41,180,173,227,35,177,99,70,109,213,80,137,54,172,89,19,249,108,222,21,67,162,81,85,60,7,116,77,105,135,106,19,128,123,55,44,10,107,234,252,133,127,160,139,196,147,217,49,29,193,148,133,239,104,167,211,253,48,189,155,150,28,172,180,252,6,242,30,220,227,238,47,155,41,220,153,36,4,0,0 };
		}

		protected override void InitializeLocalizableStrings() {
			base.InitializeLocalizableStrings();
			SetLocalizableStringsDefInheritance();
			LocalizableStrings.Add(CreateCryptoServiceKeyExceptionMessageLocalizableString());
		}

		protected virtual SchemaLocalizableString CreateCryptoServiceKeyExceptionMessageLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("7264c8f8-6a12-42f2-b6d0-3a6bc04b2a99"),
				Name = "CryptoServiceKeyExceptionMessage",
				CreatedInPackageId = new Guid("55f82158-5486-4bb7-b202-c8f84f805cfa"),
				CreatedInSchemaUId = new Guid("ba8f2b10-80c4-416c-92db-1fe39960f378"),
				ModifiedInSchemaUId = new Guid("ba8f2b10-80c4-416c-92db-1fe39960f378")
			};
			return localizableString;
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("ba8f2b10-80c4-416c-92db-1fe39960f378"));
		}

		#endregion

	}

	#endregion

}

