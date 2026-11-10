namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: AccountLanguageIteratorSchema

	/// <exclude/>
	public class AccountLanguageIteratorSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public AccountLanguageIteratorSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public AccountLanguageIteratorSchema(AccountLanguageIteratorSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("e46324f1-8f69-4be3-9d3a-1af95158ae46");
			Name = "AccountLanguageIterator";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("d5fe5418-b108-401a-ba83-ff1213a966db");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,141,145,203,106,195,64,12,69,215,14,228,31,132,179,73,160,216,251,188,160,77,55,129,46,66,105,86,165,11,101,42,155,129,241,56,204,131,146,150,252,123,53,99,231,97,135,64,22,198,140,116,117,116,37,105,172,200,238,81,16,124,144,49,104,235,194,101,171,90,23,178,244,6,157,172,245,112,240,55,28,36,222,74,93,118,36,134,102,195,1,103,70,134,74,150,193,74,161,181,83,120,22,162,246,218,189,161,46,61,150,180,118,196,152,218,68,105,158,231,48,183,190,170,208,28,150,237,251,36,128,130,63,37,173,11,125,118,7,192,134,3,170,5,217,236,4,200,175,8,123,191,83,82,128,8,189,239,181,134,41,188,160,165,91,71,73,24,236,226,191,214,214,25,47,56,197,99,108,34,56,186,190,177,221,248,214,210,73,84,242,151,44,104,250,1,201,213,168,121,141,117,193,98,34,16,134,138,69,122,199,83,154,47,51,56,179,243,62,124,190,71,131,21,104,190,205,34,245,150,12,155,211,36,194,57,210,229,150,223,32,206,129,108,158,71,117,44,110,247,113,167,235,120,219,65,65,151,60,9,128,100,10,59,94,214,184,151,130,184,170,228,4,124,247,138,199,94,196,193,215,215,193,207,175,86,153,132,212,198,200,138,152,226,80,184,181,238,153,10,242,158,161,201,211,165,246,149,10,244,234,1,245,113,22,126,199,230,84,35,210,223,205,61,227,187,137,118,131,199,127,132,211,208,138,242,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("e46324f1-8f69-4be3-9d3a-1af95158ae46"));
		}

		#endregion

	}

	#endregion

}

