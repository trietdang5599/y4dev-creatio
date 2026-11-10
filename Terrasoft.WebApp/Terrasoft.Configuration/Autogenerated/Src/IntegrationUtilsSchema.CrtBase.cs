namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: IntegrationUtilsSchema

	/// <exclude/>
	public class IntegrationUtilsSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IntegrationUtilsSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IntegrationUtilsSchema(IntegrationUtilsSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("d4eda3c2-a9cc-455c-a6b6-3d2187c88a64");
			Name = "IntegrationUtils";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("912fb492-38c7-4dbe-88b2-46a261777d72");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,141,146,223,74,195,48,20,198,175,87,232,59,132,93,117,48,242,2,195,155,173,42,3,157,96,55,189,142,233,89,13,180,73,57,73,38,69,246,238,166,73,55,23,177,208,155,150,243,231,119,206,151,124,177,90,200,138,20,157,54,208,172,210,196,250,112,15,136,76,171,163,161,27,133,48,146,166,249,250,90,9,60,205,153,97,46,151,38,146,53,160,91,198,33,98,228,81,84,22,153,17,74,166,201,119,154,204,90,251,81,11,78,120,205,180,38,91,105,160,10,213,131,17,181,118,245,190,231,210,164,141,43,113,114,82,162,36,239,40,12,20,157,228,175,160,109,109,178,131,6,116,227,37,240,158,38,54,10,151,228,209,58,70,123,137,67,80,10,140,138,232,231,12,129,106,33,200,88,186,165,216,31,175,4,205,81,180,125,110,209,75,242,186,102,39,134,183,162,159,84,85,240,79,104,24,185,251,163,128,222,75,35,76,23,170,207,76,178,10,144,62,8,89,110,165,59,149,228,176,238,118,238,194,178,121,60,109,190,88,141,236,113,27,254,91,76,55,8,204,64,216,150,197,26,134,89,49,70,11,48,57,28,55,170,182,141,124,99,181,5,157,141,54,222,116,69,74,131,247,219,114,190,28,238,120,218,132,252,98,129,39,175,134,76,131,131,239,158,12,214,77,195,94,46,206,122,242,234,243,52,248,30,81,97,254,251,18,122,213,55,239,98,218,161,157,61,142,235,127,123,209,0,61,24,190,83,95,35,44,59,193,224,198,217,125,206,179,52,57,255,0,34,254,199,86,174,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("d4eda3c2-a9cc-455c-a6b6-3d2187c88a64"));
		}

		#endregion

	}

	#endregion

}

