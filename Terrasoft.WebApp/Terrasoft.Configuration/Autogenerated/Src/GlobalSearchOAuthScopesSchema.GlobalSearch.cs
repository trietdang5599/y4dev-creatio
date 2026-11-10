namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: GlobalSearchOAuthScopesSchema

	/// <exclude/>
	public class GlobalSearchOAuthScopesSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public GlobalSearchOAuthScopesSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public GlobalSearchOAuthScopesSchema(GlobalSearchOAuthScopesSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("d20499a8-e69d-4f2f-b21b-32f0cd735faa");
			Name = "GlobalSearchOAuthScopes";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("ca3090cb-7cbd-4956-acde-76442c58fa1e");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,117,145,207,110,194,48,12,198,207,69,226,29,44,118,129,75,122,103,140,9,33,134,56,140,77,234,120,128,144,26,90,169,249,35,199,145,134,208,222,125,73,187,49,138,216,49,95,62,255,108,127,54,82,163,119,82,33,124,32,145,244,246,192,98,105,205,161,62,6,146,92,91,35,214,141,221,203,166,64,73,170,26,14,206,195,65,22,124,109,142,61,191,214,214,60,222,253,33,188,167,95,51,197,198,48,210,33,142,224,163,53,154,31,8,143,177,49,44,27,233,253,20,174,189,111,139,192,85,161,172,67,223,90,93,216,55,181,2,207,113,84,5,42,21,252,239,207,206,109,205,133,255,138,92,217,50,118,120,111,41,221,103,158,231,48,243,65,107,73,167,249,175,176,70,6,233,28,89,71,181,100,4,159,136,80,162,67,83,166,197,34,140,43,132,224,145,128,79,14,197,133,148,223,162,102,78,146,212,96,98,236,79,163,84,16,195,54,168,82,210,163,249,46,1,212,69,128,218,196,205,140,66,49,203,219,178,150,210,223,217,51,165,9,226,132,237,154,47,150,150,129,8,13,39,214,120,215,107,0,253,126,19,72,199,204,50,66,14,116,251,41,86,159,241,42,70,54,11,21,15,227,55,165,216,248,173,229,149,118,124,26,79,224,25,214,69,151,171,40,130,115,150,24,166,127,210,214,146,150,77,58,124,246,245,147,121,76,170,139,189,125,119,106,95,140,218,55,212,211,121,130,141,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("d20499a8-e69d-4f2f-b21b-32f0cd735faa"));
		}

		#endregion

	}

	#endregion

}

