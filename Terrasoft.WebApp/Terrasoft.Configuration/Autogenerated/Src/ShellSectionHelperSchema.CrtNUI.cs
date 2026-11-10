namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: ShellSectionHelperSchema

	/// <exclude/>
	public class ShellSectionHelperSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ShellSectionHelperSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ShellSectionHelperSchema(ShellSectionHelperSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("26da630d-0433-429a-bdec-0bbe54e8f49a");
			Name = "ShellSectionHelper";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("0c6d5769-8079-4d44-b72c-713dda089a12");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,197,145,65,75,3,49,16,133,207,91,232,127,8,244,210,94,246,7,88,245,82,169,94,4,97,237,15,136,217,215,221,64,154,44,51,179,5,41,254,119,179,73,17,35,182,30,61,206,203,155,111,222,35,94,31,192,131,54,80,175,32,210,28,246,82,111,130,223,219,110,36,45,54,248,249,236,52,159,85,35,91,223,21,22,194,250,130,94,111,181,145,64,22,28,29,209,179,32,116,17,164,54,78,51,223,168,166,135,115,13,204,4,127,130,27,64,201,53,140,111,206,26,101,38,211,47,30,21,23,139,249,148,182,190,224,207,144,62,180,17,255,146,56,249,241,204,12,199,152,207,182,80,44,52,197,125,132,20,21,27,67,118,144,229,142,65,81,247,249,140,26,139,113,53,29,172,170,234,168,73,245,57,193,93,110,148,219,190,215,145,122,155,114,151,236,239,161,239,151,171,117,162,16,100,36,127,6,213,23,242,252,8,144,54,63,254,44,230,44,188,236,188,149,198,244,56,232,7,112,162,5,226,255,45,120,37,215,149,162,11,248,54,255,112,154,179,90,138,81,251,4,90,182,218,54,197,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("26da630d-0433-429a-bdec-0bbe54e8f49a"));
		}

		#endregion

	}

	#endregion

}

