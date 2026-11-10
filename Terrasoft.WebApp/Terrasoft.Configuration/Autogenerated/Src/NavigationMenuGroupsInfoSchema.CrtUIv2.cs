namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: NavigationMenuGroupsInfoSchema

	/// <exclude/>
	public class NavigationMenuGroupsInfoSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public NavigationMenuGroupsInfoSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public NavigationMenuGroupsInfoSchema(NavigationMenuGroupsInfoSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("a55f40b7-13c7-4e83-afa2-c626b579e2d1");
			Name = "NavigationMenuGroupsInfo";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("d699061b-815e-49b9-8730-21a5e5db2044");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,125,145,65,107,195,48,12,133,207,45,244,63,136,246,158,220,215,46,48,186,81,10,219,40,219,96,103,199,85,130,153,99,7,201,222,40,161,255,125,142,211,102,205,8,185,24,235,89,239,233,195,50,162,66,174,133,68,248,64,34,193,182,112,201,214,154,66,149,158,132,83,214,36,175,226,91,149,241,250,130,198,47,230,205,98,62,243,172,76,9,239,39,118,88,133,118,173,81,182,13,156,236,208,32,41,185,238,123,62,45,125,213,58,228,63,212,42,168,65,95,17,150,161,23,182,90,48,223,1,12,243,119,100,125,205,123,83,216,216,156,166,41,108,216,87,149,160,83,118,169,31,145,37,169,28,25,76,111,133,42,120,161,140,102,80,209,221,121,211,27,115,237,115,173,36,200,118,240,196,216,89,19,71,247,160,7,178,53,146,83,24,104,15,49,162,123,255,207,22,133,191,207,0,91,132,103,68,144,132,197,253,114,100,222,50,205,146,62,232,22,244,74,186,127,50,190,66,18,185,198,205,136,63,131,14,27,26,40,209,173,129,219,227,60,1,247,134,236,181,107,193,180,21,199,118,61,63,215,245,0,59,242,210,121,194,105,164,126,159,207,93,194,37,114,88,141,240,172,208,28,187,255,140,117,167,14,197,243,47,250,206,228,95,140,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("a55f40b7-13c7-4e83-afa2-c626b579e2d1"));
		}

		#endregion

	}

	#endregion

}

