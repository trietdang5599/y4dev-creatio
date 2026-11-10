namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: IDeduplicationSearchQueryBuilderSchema

	/// <exclude/>
	public class IDeduplicationSearchQueryBuilderSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IDeduplicationSearchQueryBuilderSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IDeduplicationSearchQueryBuilderSchema(IDeduplicationSearchQueryBuilderSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("d41dcdd7-e798-4db1-b723-80024a0e025a");
			Name = "IDeduplicationSearchQueryBuilder";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("4c53ad23-c903-414d-89cd-b08703861304");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,141,146,77,110,131,48,16,133,215,32,113,135,81,186,105,165,10,246,9,101,209,166,173,178,168,250,147,92,192,129,33,177,132,13,157,193,139,40,202,221,107,108,136,220,52,139,238,152,241,247,222,60,143,209,66,33,119,162,68,216,32,145,224,182,238,211,167,86,215,114,103,72,244,178,213,233,18,43,211,53,178,116,85,18,31,147,56,50,44,245,14,214,7,238,81,89,186,105,176,28,14,57,125,69,141,36,203,69,18,91,234,134,112,103,187,176,210,61,82,109,71,204,97,245,203,108,141,130,202,253,167,65,58,60,26,217,84,72,78,151,101,25,228,108,148,18,116,40,198,218,163,240,61,176,176,245,48,212,45,65,21,26,2,161,37,184,79,39,151,44,176,233,204,214,114,32,167,52,255,8,19,29,93,160,243,77,222,176,223,183,21,207,225,195,121,249,195,203,184,174,225,44,24,56,140,93,83,171,96,154,136,12,100,26,228,244,108,145,93,122,228,157,32,161,64,219,23,122,152,57,120,86,44,39,249,168,206,51,7,93,215,212,82,87,103,1,127,249,221,204,138,241,227,175,150,176,55,164,185,8,151,109,169,169,61,112,193,150,252,29,131,198,237,234,89,27,133,36,182,13,230,193,92,27,116,185,121,47,124,226,251,193,37,138,94,174,69,131,171,129,239,22,227,35,160,174,252,59,216,234,228,255,176,160,149,196,167,31,82,38,233,190,204,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("d41dcdd7-e798-4db1-b723-80024a0e025a"));
		}

		#endregion

	}

	#endregion

}

