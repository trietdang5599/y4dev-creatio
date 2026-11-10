namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: SecuredFolderFavoriteQueryExecutorSchema

	/// <exclude/>
	public class SecuredFolderFavoriteQueryExecutorSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public SecuredFolderFavoriteQueryExecutorSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public SecuredFolderFavoriteQueryExecutorSchema(SecuredFolderFavoriteQueryExecutorSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("f7c6e626-3da4-4dd0-a413-a934aea09181");
			Name = "SecuredFolderFavoriteQueryExecutor";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("dd00e878-1009-445f-bd06-4d0e05a51d60");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,189,86,223,111,219,54,16,126,118,129,254,15,156,87,20,50,224,40,235,107,92,27,72,60,187,8,144,108,89,221,181,15,65,48,48,210,201,38,42,145,42,73,185,241,2,255,239,61,254,144,45,89,150,237,161,237,252,96,73,228,241,238,251,238,62,30,201,105,6,42,167,17,144,15,32,37,85,34,209,225,88,240,132,205,11,73,53,19,252,229,139,231,151,47,58,133,98,124,78,102,43,165,33,27,236,124,163,125,154,66,100,140,85,248,14,56,72,22,53,108,110,24,255,178,29,172,198,202,50,193,247,207,72,104,27,15,39,92,51,205,64,181,26,76,105,164,133,116,22,104,243,171,132,57,226,35,227,148,42,117,65,102,16,21,18,226,169,72,99,144,83,186,68,75,13,127,21,32,87,147,39,156,194,149,118,213,253,239,144,208,34,213,87,140,199,24,35,208,171,28,68,18,92,219,232,171,154,125,175,79,254,192,84,146,33,233,30,119,222,237,61,160,247,188,120,76,89,68,34,3,233,4,68,228,130,92,81,5,167,64,239,60,91,248,27,214,83,6,105,140,180,239,36,91,82,13,110,50,119,31,68,2,141,5,79,87,68,105,105,18,249,79,98,93,59,142,179,104,1,25,53,204,176,200,69,198,75,142,211,189,54,221,129,143,11,60,118,161,235,56,238,164,200,65,154,186,25,44,66,163,104,32,118,38,231,231,231,228,45,227,11,20,143,142,69,68,206,71,14,163,55,34,98,137,245,101,49,148,40,235,252,119,129,144,225,168,196,88,154,148,216,190,47,80,53,11,155,16,215,241,247,57,175,224,126,38,115,208,3,162,204,223,250,112,50,113,151,162,151,194,200,28,179,105,181,228,11,235,116,117,92,40,193,223,10,36,186,225,110,243,146,162,246,217,67,193,61,162,224,130,221,97,211,15,58,71,192,221,130,94,136,86,201,85,203,101,17,77,89,170,77,144,178,143,144,119,160,239,36,228,20,9,140,69,206,32,158,168,47,206,72,5,141,213,36,42,77,60,184,206,146,74,2,59,154,80,168,91,14,95,201,13,83,250,173,203,255,40,232,13,172,253,20,55,248,37,143,223,67,134,21,242,113,174,86,119,84,47,130,141,239,208,143,247,143,239,144,126,51,184,15,52,94,64,244,25,35,205,64,239,214,62,104,91,35,65,23,146,147,6,144,65,165,14,101,102,151,130,197,228,0,155,227,153,143,54,175,253,82,165,220,82,170,230,13,155,134,194,190,88,166,59,193,238,20,48,174,9,195,28,111,29,96,39,46,112,240,140,188,25,224,204,104,72,126,195,231,217,89,185,202,86,9,53,153,213,22,221,179,7,71,187,195,18,116,106,166,153,106,83,12,73,220,227,245,107,255,22,222,64,162,39,79,57,226,83,6,129,33,77,134,67,75,97,19,183,227,208,135,151,113,28,248,101,239,217,124,81,89,167,48,199,82,233,160,135,14,36,46,69,147,143,52,45,128,80,229,147,226,107,211,233,84,232,186,132,91,204,229,244,218,61,32,85,64,78,224,83,169,131,42,30,183,95,91,232,7,106,91,91,209,247,85,243,133,170,193,89,183,42,231,144,60,107,245,111,106,213,35,52,36,127,105,204,134,151,124,21,244,54,44,62,44,164,248,234,192,79,178,92,175,38,82,98,55,242,32,215,27,63,77,55,78,80,35,242,102,159,171,91,60,247,255,228,181,179,96,143,227,70,203,29,54,201,148,213,111,205,83,11,129,106,247,49,35,183,168,38,58,135,178,241,136,136,166,236,95,250,152,194,204,166,113,167,255,134,159,132,252,108,239,98,168,36,37,10,25,161,157,144,232,160,239,139,111,126,167,92,47,250,164,219,8,134,164,246,118,173,10,139,208,106,188,235,211,165,13,71,11,124,242,20,65,110,16,6,85,86,39,101,167,189,38,255,67,174,126,78,170,60,165,31,149,44,108,66,147,39,220,90,206,249,213,106,127,232,125,135,30,94,220,116,237,212,219,142,148,71,132,109,113,149,225,177,125,181,241,148,51,9,94,117,239,159,119,247,196,250,226,58,190,40,239,54,15,33,222,111,122,53,2,39,156,250,181,203,221,158,11,80,201,221,3,157,74,145,109,14,250,131,100,251,205,222,217,60,255,109,23,106,28,152,255,189,11,25,117,58,55,222,5,202,243,208,213,100,11,100,112,176,34,85,151,222,244,68,29,84,170,222,86,17,63,86,47,210,250,27,244,245,148,198,233,13,0,0 };
		}

		protected override void InitializeLocalizableStrings() {
			base.InitializeLocalizableStrings();
			SetLocalizableStringsDefInheritance();
			LocalizableStrings.Add(CreateFolderEntitySchemaNameFilterMoreOneLocalizableString());
			LocalizableStrings.Add(CreateFolderEntitySchemaNameEmptyLocalizableString());
		}

		protected virtual SchemaLocalizableString CreateFolderEntitySchemaNameFilterMoreOneLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("b28e4545-600d-8706-087b-bdaa3d310cce"),
				Name = "FolderEntitySchemaNameFilterMoreOne",
				CreatedInPackageId = new Guid("dd00e878-1009-445f-bd06-4d0e05a51d60"),
				CreatedInSchemaUId = new Guid("f7c6e626-3da4-4dd0-a413-a934aea09181"),
				ModifiedInSchemaUId = new Guid("f7c6e626-3da4-4dd0-a413-a934aea09181")
			};
			return localizableString;
		}

		protected virtual SchemaLocalizableString CreateFolderEntitySchemaNameEmptyLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("a5f60912-7e06-3944-37d4-8c73cbfb9aca"),
				Name = "FolderEntitySchemaNameEmpty",
				CreatedInPackageId = new Guid("dd00e878-1009-445f-bd06-4d0e05a51d60"),
				CreatedInSchemaUId = new Guid("f7c6e626-3da4-4dd0-a413-a934aea09181"),
				ModifiedInSchemaUId = new Guid("f7c6e626-3da4-4dd0-a413-a934aea09181")
			};
			return localizableString;
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("f7c6e626-3da4-4dd0-a413-a934aea09181"));
		}

		#endregion

	}

	#endregion

}

