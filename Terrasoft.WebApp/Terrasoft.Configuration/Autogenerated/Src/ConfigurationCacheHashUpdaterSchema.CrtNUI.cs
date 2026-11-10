namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: ConfigurationCacheHashUpdaterSchema

	/// <exclude/>
	public class ConfigurationCacheHashUpdaterSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ConfigurationCacheHashUpdaterSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ConfigurationCacheHashUpdaterSchema(ConfigurationCacheHashUpdaterSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("375c519a-386e-4b03-b483-e8308654dd8a");
			Name = "ConfigurationCacheHashUpdater";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("c302261e-8f3d-4933-bbe5-b7b61ee66faa");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,133,82,201,106,195,48,16,61,59,144,127,16,233,197,134,226,15,72,151,67,29,154,134,210,16,112,218,75,201,97,106,141,19,129,35,25,105,156,98,74,254,189,146,149,205,89,79,66,163,121,243,22,141,132,37,154,18,50,100,83,212,26,140,202,41,78,148,204,197,188,210,64,66,201,110,231,175,219,9,42,35,228,156,165,181,33,92,62,236,238,135,16,141,113,82,8,148,148,64,182,192,139,61,175,144,145,210,2,205,190,195,144,37,202,46,241,183,111,3,32,120,3,179,152,104,181,18,28,181,123,181,120,73,110,158,157,120,167,113,110,219,216,72,18,234,220,218,234,179,81,107,64,163,206,77,248,44,57,216,158,6,85,86,63,133,85,32,182,160,155,152,192,101,18,172,148,224,204,215,118,45,97,228,140,173,189,24,148,220,235,105,105,75,10,48,166,207,110,203,250,30,96,14,85,65,47,66,114,27,84,72,117,137,42,15,175,139,139,162,217,222,81,230,168,174,51,177,219,9,57,183,206,239,214,192,7,210,66,113,107,97,210,176,248,199,13,227,249,76,88,147,87,48,58,216,144,212,174,1,90,129,71,133,39,31,143,95,147,58,30,34,61,158,160,158,125,200,65,112,140,142,83,36,71,248,5,69,133,225,201,226,236,4,189,99,125,207,134,149,224,241,24,127,221,25,70,241,84,165,164,93,202,189,113,47,242,243,215,27,219,237,111,60,247,183,182,246,15,145,173,147,36,73,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("375c519a-386e-4b03-b483-e8308654dd8a"));
		}

		#endregion

	}

	#endregion

}

