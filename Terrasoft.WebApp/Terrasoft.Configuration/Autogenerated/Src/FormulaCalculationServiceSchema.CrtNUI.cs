namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: FormulaCalculationServiceSchema

	/// <exclude/>
	public class FormulaCalculationServiceSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public FormulaCalculationServiceSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public FormulaCalculationServiceSchema(FormulaCalculationServiceSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("dbc5a0bb-9cca-4395-8de4-81203bdde4cb");
			Name = "FormulaCalculationService";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("6ba26f98-9709-4408-98d0-761f0c4bf2aa");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,205,86,219,110,219,70,16,125,86,128,252,195,66,125,161,0,129,31,224,27,96,59,182,163,182,182,12,209,69,128,186,65,177,34,71,18,155,37,151,221,93,74,81,28,255,123,103,118,151,164,36,234,98,163,113,209,151,56,154,157,219,153,153,51,195,156,103,160,11,30,3,123,0,165,184,150,19,19,94,202,124,146,78,75,197,77,42,243,240,90,170,172,20,252,253,187,167,247,239,58,165,78,243,41,139,150,218,64,118,188,241,27,237,132,128,152,140,116,120,3,57,168,52,110,233,220,129,105,201,70,101,110,210,12,194,8,45,184,72,191,217,184,45,45,124,157,167,49,220,202,4,196,222,199,240,19,140,247,43,156,99,146,243,141,40,13,124,52,71,40,89,182,253,245,82,42,168,106,114,232,61,252,192,13,191,87,114,158,38,160,244,218,47,87,99,189,219,3,143,141,84,41,236,209,240,49,174,190,198,80,216,162,239,7,83,149,96,36,75,131,58,141,242,29,44,12,90,147,246,207,218,130,198,167,159,20,76,209,39,187,20,92,235,35,230,131,93,114,17,227,31,138,86,121,195,233,65,99,176,70,143,132,16,145,25,133,217,127,70,65,81,142,69,26,179,152,156,28,246,193,142,216,218,232,181,66,116,158,108,152,58,185,235,20,68,130,217,221,43,106,167,203,161,83,184,31,76,142,255,194,97,100,127,42,208,165,48,199,222,18,242,196,25,175,123,194,184,218,168,146,106,142,238,108,214,222,155,67,112,48,247,160,199,158,216,243,43,109,234,214,49,168,254,215,35,7,157,35,54,230,248,222,72,27,231,187,16,224,96,21,160,12,78,204,58,0,219,147,91,200,198,160,130,59,36,59,59,101,93,87,146,110,239,243,74,182,190,92,35,251,196,158,108,26,83,192,255,49,5,166,84,121,93,72,74,4,223,52,84,90,157,116,194,130,57,23,37,176,84,51,12,7,15,200,230,94,245,218,241,134,24,152,198,11,43,61,199,60,107,178,195,208,6,118,14,250,44,135,133,85,171,159,85,4,134,230,85,215,254,58,20,130,138,203,205,71,158,39,130,102,248,148,181,133,225,64,203,70,234,141,159,123,225,8,10,129,11,47,232,254,209,237,246,25,182,157,116,175,178,194,44,123,199,78,235,153,129,192,113,108,3,176,73,86,74,246,143,253,119,123,107,156,116,67,248,82,94,121,62,193,132,99,228,21,230,2,245,236,49,210,69,91,230,4,171,244,123,60,215,5,46,92,228,127,129,190,199,169,72,205,114,4,127,151,169,130,12,114,163,131,213,31,180,26,17,226,1,19,210,10,189,32,233,189,156,227,200,237,11,28,233,26,221,38,149,111,193,204,228,78,46,187,38,177,27,74,108,101,65,92,41,37,213,45,104,205,167,16,120,157,47,176,172,70,207,15,238,111,218,174,219,220,157,38,188,76,230,87,25,219,59,51,22,16,89,171,160,187,51,113,28,17,114,121,188,210,231,42,171,195,11,13,99,213,28,175,89,239,205,134,72,87,156,84,199,7,77,104,182,108,131,117,36,68,142,195,91,165,101,221,177,117,26,228,19,137,253,173,134,218,151,13,37,181,126,24,205,164,50,254,97,109,200,127,32,250,45,40,43,18,50,225,251,66,194,95,154,62,206,185,106,148,107,239,167,111,84,142,189,67,182,153,97,187,74,85,175,90,9,31,239,222,20,91,88,176,186,193,237,164,144,171,85,110,119,30,241,180,15,242,185,252,2,129,51,163,205,126,63,140,30,112,98,137,160,160,141,219,124,40,71,85,143,192,137,236,161,39,53,151,218,1,61,11,235,66,38,203,200,44,5,172,169,213,210,240,147,226,69,225,87,194,139,47,32,171,158,106,250,78,156,73,61,18,184,115,112,3,69,241,12,50,78,231,171,207,110,202,52,193,155,20,75,149,12,18,151,219,135,212,82,155,171,229,137,51,235,251,115,118,198,226,25,207,167,128,44,19,101,150,235,106,4,140,90,86,157,167,225,170,247,187,221,202,238,211,107,73,139,226,100,176,1,65,170,179,192,55,189,83,127,39,67,64,147,232,66,180,191,241,130,245,253,211,223,2,169,70,179,153,110,19,170,174,147,47,80,117,170,94,179,25,234,97,31,85,120,29,112,63,196,206,227,51,139,185,137,103,44,104,187,219,186,160,22,51,200,89,67,178,112,128,64,85,163,73,95,4,41,85,227,98,249,59,40,121,213,34,227,46,114,111,93,30,43,43,163,218,216,150,158,20,130,86,168,11,210,173,138,99,102,74,46,108,109,112,98,175,233,146,214,46,79,14,86,235,44,104,165,213,247,245,251,104,76,17,25,110,74,125,73,231,112,144,27,80,57,23,228,0,177,83,66,189,183,42,230,16,35,76,132,92,52,194,239,223,217,62,131,115,53,45,233,114,15,75,51,156,140,104,186,222,168,7,17,126,172,145,54,36,144,252,127,59,240,154,171,251,111,179,223,95,190,222,14,44,23,60,241,235,123,19,194,190,84,127,72,11,241,156,224,117,75,174,190,22,184,24,168,56,255,117,31,219,216,95,247,121,141,178,127,0,49,88,201,184,209,16,0,0 };
		}

		protected override void InitializeLocalizableStrings() {
			base.InitializeLocalizableStrings();
			SetLocalizableStringsDefInheritance();
			LocalizableStrings.Add(CreateFormulaErrorDivisionByZeroLocalizableString());
			LocalizableStrings.Add(CreateFormulaErrorInvalidExpressionLocalizableString());
			LocalizableStrings.Add(CreateFormulaErrorSizeExceededLocalizableString());
		}

		protected virtual SchemaLocalizableString CreateFormulaErrorDivisionByZeroLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("2803ac41-a52f-49a0-9401-5d8ea0a163c6"),
				Name = "FormulaErrorDivisionByZero",
				CreatedInPackageId = new Guid("6ba26f98-9709-4408-98d0-761f0c4bf2aa"),
				CreatedInSchemaUId = new Guid("dbc5a0bb-9cca-4395-8de4-81203bdde4cb"),
				ModifiedInSchemaUId = new Guid("dbc5a0bb-9cca-4395-8de4-81203bdde4cb")
			};
			return localizableString;
		}

		protected virtual SchemaLocalizableString CreateFormulaErrorInvalidExpressionLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("dc7e4609-6ddd-4c7b-8ad4-b56900b4b4d5"),
				Name = "FormulaErrorInvalidExpression",
				CreatedInPackageId = new Guid("6ba26f98-9709-4408-98d0-761f0c4bf2aa"),
				CreatedInSchemaUId = new Guid("dbc5a0bb-9cca-4395-8de4-81203bdde4cb"),
				ModifiedInSchemaUId = new Guid("dbc5a0bb-9cca-4395-8de4-81203bdde4cb")
			};
			return localizableString;
		}

		protected virtual SchemaLocalizableString CreateFormulaErrorSizeExceededLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("9e2fbf3c-ae0a-4801-aa90-f7fb21b38026"),
				Name = "FormulaErrorSizeExceeded",
				CreatedInPackageId = new Guid("6ba26f98-9709-4408-98d0-761f0c4bf2aa"),
				CreatedInSchemaUId = new Guid("dbc5a0bb-9cca-4395-8de4-81203bdde4cb"),
				ModifiedInSchemaUId = new Guid("dbc5a0bb-9cca-4395-8de4-81203bdde4cb")
			};
			return localizableString;
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("dbc5a0bb-9cca-4395-8de4-81203bdde4cb"));
		}

		#endregion

	}

	#endregion

}

