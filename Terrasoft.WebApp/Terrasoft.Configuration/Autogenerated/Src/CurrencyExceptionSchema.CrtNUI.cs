namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: CurrencyExceptionSchema

	/// <exclude/>
	public class CurrencyExceptionSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public CurrencyExceptionSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public CurrencyExceptionSchema(CurrencyExceptionSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("28996e92-7c7b-4a20-a9f3-7bfa09f7eaaf");
			Name = "CurrencyException";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("6ba26f98-9709-4408-98d0-761f0c4bf2aa");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,205,86,75,111,218,64,16,62,19,41,255,97,228,244,0,18,178,239,132,112,65,73,26,41,73,163,4,245,208,219,98,6,216,214,222,117,119,215,16,18,229,191,119,188,126,96,252,128,208,38,82,145,16,236,122,30,223,204,206,247,173,5,11,81,71,204,71,152,160,82,76,203,185,113,199,82,204,249,34,86,204,112,41,220,113,172,20,10,127,115,249,236,99,148,236,156,158,188,158,158,116,98,205,197,2,158,54,218,96,120,94,172,199,50,12,165,160,53,237,156,41,92,144,57,140,3,166,245,0,138,56,74,73,117,135,90,179,5,126,197,32,66,101,173,61,207,131,161,142,195,144,169,205,40,91,63,40,185,226,51,212,16,27,30,112,179,129,16,205,82,206,52,204,165,130,181,84,191,146,148,107,110,150,128,73,80,122,108,163,130,156,131,89,34,248,89,70,55,15,239,149,226,115,97,80,9,22,128,54,84,167,15,126,130,114,47,200,78,82,118,81,213,93,10,101,64,32,249,138,25,180,69,212,170,176,27,143,104,98,37,52,4,210,103,1,127,97,211,0,41,171,74,192,27,185,11,221,45,130,120,213,40,195,136,41,22,130,160,3,187,112,180,145,138,204,157,209,35,106,25,43,63,9,104,119,220,161,103,237,154,221,74,8,158,44,128,123,218,118,70,183,117,96,137,125,61,150,74,43,25,13,189,252,95,242,40,138,167,1,117,48,107,100,22,224,26,77,185,137,19,12,163,128,218,212,189,201,17,63,165,128,115,224,253,220,177,17,99,15,108,243,59,43,166,210,134,85,194,194,5,8,92,195,109,213,183,91,68,119,106,115,236,244,109,200,206,23,167,230,166,221,215,70,24,111,238,119,22,196,232,244,206,173,107,218,132,70,64,238,68,102,8,82,219,183,116,62,206,80,204,210,1,74,86,244,77,247,203,219,237,204,185,151,230,74,198,98,86,98,98,11,113,38,52,253,152,91,17,23,152,1,174,233,87,201,181,128,245,18,69,193,13,32,126,9,195,231,28,21,204,36,81,77,72,67,244,162,44,64,83,105,210,56,75,38,232,160,84,210,231,194,70,163,105,228,85,54,12,187,116,170,33,135,1,220,199,65,240,77,93,134,145,41,75,75,66,178,50,205,72,139,104,46,98,159,142,49,225,154,13,158,181,174,153,108,55,130,27,158,156,28,225,100,118,40,56,69,96,194,47,100,97,168,145,180,65,225,252,194,105,197,231,120,163,180,132,79,38,100,126,12,55,51,103,52,174,31,201,142,115,214,217,86,204,123,168,117,29,243,25,108,115,245,236,244,14,96,202,52,118,43,68,221,50,166,100,159,209,239,45,239,124,101,94,15,136,98,148,46,114,129,168,177,173,170,21,71,20,114,88,22,246,42,58,125,220,54,161,170,43,71,173,227,153,75,69,14,82,29,115,175,164,10,153,233,54,193,218,233,109,155,60,28,41,14,15,201,156,32,221,105,183,148,139,120,245,59,102,129,254,129,74,94,62,155,143,83,139,40,207,2,1,165,73,36,2,109,34,120,161,76,239,215,131,61,96,183,2,113,180,42,124,172,38,28,198,248,63,138,68,205,185,56,177,244,170,47,170,106,185,225,203,174,43,123,215,141,246,104,208,225,30,189,159,203,217,109,156,189,5,236,192,238,131,156,254,68,223,128,69,212,131,35,229,171,95,141,150,134,217,138,218,63,75,90,243,59,207,167,212,158,10,94,102,249,249,154,119,248,132,255,94,4,109,69,181,195,121,135,52,182,188,57,209,206,31,149,146,174,90,207,12,0,0 };
		}

		protected override void InitializeLocalizableStrings() {
			base.InitializeLocalizableStrings();
			SetLocalizableStringsDefInheritance();
			LocalizableStrings.Add(CreateCurrencyNotFoundExceptionMessageLocalizableString());
			LocalizableStrings.Add(CreateCurrencyParameterLessOrEqualsZeroExceptionMessageLocalizableString());
		}

		protected virtual SchemaLocalizableString CreateCurrencyNotFoundExceptionMessageLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("a74da309-e90a-4cbe-9b82-2327571ebd4e"),
				Name = "CurrencyNotFoundExceptionMessage",
				CreatedInPackageId = new Guid("6ba26f98-9709-4408-98d0-761f0c4bf2aa"),
				CreatedInSchemaUId = new Guid("28996e92-7c7b-4a20-a9f3-7bfa09f7eaaf"),
				ModifiedInSchemaUId = new Guid("28996e92-7c7b-4a20-a9f3-7bfa09f7eaaf")
			};
			return localizableString;
		}

		protected virtual SchemaLocalizableString CreateCurrencyParameterLessOrEqualsZeroExceptionMessageLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("47fc8d47-9788-470a-afd5-51c6e1736e59"),
				Name = "CurrencyParameterLessOrEqualsZeroExceptionMessage",
				CreatedInPackageId = new Guid("6ba26f98-9709-4408-98d0-761f0c4bf2aa"),
				CreatedInSchemaUId = new Guid("28996e92-7c7b-4a20-a9f3-7bfa09f7eaaf"),
				ModifiedInSchemaUId = new Guid("28996e92-7c7b-4a20-a9f3-7bfa09f7eaaf")
			};
			return localizableString;
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("28996e92-7c7b-4a20-a9f3-7bfa09f7eaaf"));
		}

		#endregion

	}

	#endregion

}

