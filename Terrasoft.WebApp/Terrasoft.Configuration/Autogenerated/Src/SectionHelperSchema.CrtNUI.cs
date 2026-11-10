namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: SectionHelperSchema

	/// <exclude/>
	public class SectionHelperSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public SectionHelperSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public SectionHelperSchema(SectionHelperSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("33d4e612-facc-4d4c-9516-d0f60d673446");
			Name = "SectionHelper";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("9defff70-969f-468c-8263-69f6e8af1009");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,197,145,207,106,2,49,16,198,207,43,248,14,1,47,122,217,7,208,214,139,165,127,14,45,133,213,7,72,227,184,59,16,147,101,102,34,20,233,187,155,77,164,52,82,237,177,199,249,102,242,251,190,143,56,189,7,238,181,1,181,6,34,205,126,39,245,202,187,29,182,129,180,160,119,227,209,113,60,170,2,163,107,139,19,130,197,21,189,126,212,70,60,33,240,111,23,111,1,163,28,23,19,130,54,242,213,202,106,230,185,106,192,12,118,207,96,123,160,116,208,135,15,139,70,153,97,95,174,231,234,165,152,213,49,61,248,70,190,130,116,126,27,161,239,9,145,151,103,220,1,73,130,182,138,133,134,96,79,32,69,221,198,16,246,50,221,48,80,212,93,118,81,161,24,103,131,95,85,85,7,77,170,203,1,238,115,141,220,252,179,142,212,187,18,251,51,238,114,58,91,36,0,129,4,114,103,70,125,37,202,133,119,122,249,245,87,37,139,224,100,227,80,26,211,193,94,63,0,39,152,39,254,183,106,55,34,221,168,56,1,183,205,191,154,230,172,150,98,212,78,34,225,250,30,198,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("33d4e612-facc-4d4c-9516-d0f60d673446"));
		}

		#endregion

	}

	#endregion

}

