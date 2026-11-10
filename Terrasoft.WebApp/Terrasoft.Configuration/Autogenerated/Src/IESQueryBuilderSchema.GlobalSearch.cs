namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: IESQueryBuilderSchema

	/// <exclude/>
	public class IESQueryBuilderSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IESQueryBuilderSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IESQueryBuilderSchema(IESQueryBuilderSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("88313c62-0396-406c-abf5-3debda333fb2");
			Name = "IESQueryBuilder";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("3c3a921b-299a-4f38-a040-5c0154a25bee");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,101,145,191,110,131,48,16,135,231,32,241,14,86,186,180,11,222,19,202,208,42,170,50,84,74,69,95,224,128,131,88,242,31,122,182,135,168,202,187,215,177,33,33,233,134,207,191,239,238,243,161,65,161,29,161,69,246,141,68,96,77,239,138,119,163,123,49,120,2,39,140,46,62,164,105,64,214,8,212,30,243,236,55,207,242,108,229,173,208,195,130,216,73,176,78,180,41,180,141,145,39,194,33,224,108,175,29,82,31,6,108,216,126,87,127,121,164,211,155,23,178,67,138,49,206,57,43,173,87,10,232,84,77,231,169,27,179,177,29,251,185,48,172,153,161,132,240,5,51,250,70,134,184,152,39,253,31,180,74,218,87,169,79,116,71,211,217,13,59,68,52,93,62,170,196,66,108,97,25,78,74,201,165,39,163,130,157,196,214,165,74,113,229,249,99,131,114,4,2,197,116,216,243,235,58,189,40,186,173,171,122,241,188,162,228,49,119,195,8,157,39,109,171,3,12,8,141,196,123,133,144,159,3,23,98,14,77,155,139,3,146,122,252,124,174,111,115,217,194,225,101,59,173,5,117,151,54,19,207,231,244,3,239,138,231,63,204,180,221,183,41,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("88313c62-0396-406c-abf5-3debda333fb2"));
		}

		#endregion

	}

	#endregion

}

