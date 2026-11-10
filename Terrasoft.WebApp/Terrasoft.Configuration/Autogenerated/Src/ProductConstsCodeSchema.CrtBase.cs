namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: ProductConstsCodeSchema

	/// <exclude/>
	public class ProductConstsCodeSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ProductConstsCodeSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ProductConstsCodeSchema(ProductConstsCodeSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("e82d2b87-855b-4382-aac0-c05f66836306");
			Name = "ProductConstsCode";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,93,141,207,10,2,33,24,196,207,187,224,59,124,116,170,131,209,63,148,37,58,88,177,209,33,8,170,7,48,117,67,48,13,63,37,34,122,247,164,232,210,28,230,50,191,153,241,242,106,240,38,149,129,163,137,81,98,232,210,112,21,124,103,47,57,202,100,131,39,245,147,212,85,70,235,47,112,120,96,50,215,57,169,161,232,150,207,206,42,192,84,48,5,202,73,68,216,199,160,179,74,101,0,19,126,177,39,148,122,245,71,71,35,117,240,238,1,155,108,245,175,181,43,238,204,105,171,97,1,222,220,63,89,191,55,21,237,154,243,53,163,237,140,183,116,214,54,19,218,48,49,162,124,42,150,171,241,104,60,17,140,245,6,115,168,170,239,223,139,212,175,55,53,220,91,3,213,0,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("e82d2b87-855b-4382-aac0-c05f66836306"));
		}

		#endregion

	}

	#endregion

}

