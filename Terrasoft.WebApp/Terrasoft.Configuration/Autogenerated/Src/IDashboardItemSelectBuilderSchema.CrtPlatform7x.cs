namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: IDashboardItemSelectBuilderSchema

	/// <exclude/>
	public class IDashboardItemSelectBuilderSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IDashboardItemSelectBuilderSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IDashboardItemSelectBuilderSchema(IDashboardItemSelectBuilderSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("4e4bbf9b-4e63-40a8-8dcf-802e271ecd52");
			Name = "IDashboardItemSelectBuilder";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("eccc4091-3404-497f-94e5-8c10d0f3a0d7");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,125,144,77,78,195,64,12,133,215,173,212,59,120,9,18,74,14,208,170,139,38,8,117,193,170,92,192,73,156,116,208,252,4,123,70,40,138,122,119,156,137,40,108,96,251,236,247,222,103,123,116,36,35,182,4,111,196,140,18,250,88,84,193,247,102,72,140,209,4,191,219,206,187,237,38,137,241,3,92,38,137,228,116,110,45,181,203,80,138,23,242,196,166,221,223,119,170,192,84,212,39,21,84,26,83,99,77,11,198,71,226,126,41,57,215,40,215,38,32,119,103,77,186,208,146,115,74,198,118,196,186,62,103,211,166,44,75,56,72,114,14,121,58,126,11,181,201,141,42,193,167,137,87,104,131,77,206,11,140,200,122,130,230,75,113,247,150,191,205,63,198,131,68,86,196,39,8,205,187,246,30,225,217,71,19,167,106,77,122,197,17,102,24,40,238,225,246,15,71,166,21,144,140,14,31,137,20,168,15,12,29,70,4,27,176,251,3,99,189,117,181,63,60,174,239,201,61,183,47,21,17,11,113,131,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("4e4bbf9b-4e63-40a8-8dcf-802e271ecd52"));
		}

		#endregion

	}

	#endregion

}

