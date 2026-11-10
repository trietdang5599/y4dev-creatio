namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: SecFolderTreeFavoriteQueryExecutorSchema

	/// <exclude/>
	public class SecFolderTreeFavoriteQueryExecutorSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public SecFolderTreeFavoriteQueryExecutorSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public SecFolderTreeFavoriteQueryExecutorSchema(SecFolderTreeFavoriteQueryExecutorSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("0eb3a998-3aac-4696-9f2f-3c08a51f388d");
			Name = "SecFolderTreeFavoriteQueryExecutor";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("dd00e878-1009-445f-bd06-4d0e05a51d60");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,173,84,193,78,227,48,16,61,7,137,127,24,202,37,145,80,122,111,89,36,40,141,180,210,238,10,84,56,161,61,24,123,210,90,74,236,48,182,171,141,170,254,251,218,78,91,90,218,2,18,92,172,248,249,205,188,153,231,113,20,171,209,52,140,35,60,32,17,51,186,180,249,72,171,82,78,29,49,43,181,58,61,89,156,158,36,206,72,53,133,73,107,44,214,249,47,169,94,134,27,112,59,142,240,24,158,143,149,149,86,162,57,74,40,24,183,154,58,134,231,156,19,78,189,60,140,42,102,204,0,38,200,11,93,9,164,7,66,44,216,220,51,45,222,59,164,118,252,15,185,243,145,49,234,233,22,75,230,42,123,35,149,240,26,169,109,27,212,101,250,51,170,183,59,252,236,2,254,248,230,225,7,244,62,78,222,203,254,250,236,141,123,174,36,7,30,74,250,68,69,3,184,97,6,61,207,17,138,142,123,164,242,36,120,188,105,249,142,116,131,20,204,26,132,111,139,220,162,136,237,37,253,126,31,46,165,154,161,79,34,52,135,254,85,64,155,53,9,244,220,155,42,5,130,177,20,60,222,85,237,92,152,240,25,214,172,235,253,10,122,251,77,244,134,223,33,54,210,149,171,213,1,153,175,165,223,170,126,1,83,180,67,48,97,89,134,123,220,215,56,71,37,58,87,87,251,149,197,191,209,206,180,248,130,191,115,45,5,92,11,81,200,202,34,153,130,116,61,210,141,68,49,54,47,233,182,207,241,166,129,19,50,27,15,47,224,192,233,58,50,131,56,8,137,44,33,61,219,160,249,74,36,191,86,109,154,173,57,9,161,117,164,134,113,179,140,235,171,202,107,136,16,233,94,162,44,6,45,223,183,200,255,5,188,241,142,199,65,190,139,147,223,17,86,175,224,227,249,79,31,13,146,79,163,188,119,33,163,219,217,102,48,128,103,255,62,210,183,240,226,104,113,30,233,240,93,120,249,31,20,38,23,86,197,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("0eb3a998-3aac-4696-9f2f-3c08a51f388d"));
		}

		#endregion

	}

	#endregion

}

