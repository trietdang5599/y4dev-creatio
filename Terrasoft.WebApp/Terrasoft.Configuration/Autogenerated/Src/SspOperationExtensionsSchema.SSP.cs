namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: SspOperationExtensionsSchema

	/// <exclude/>
	public class SspOperationExtensionsSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public SspOperationExtensionsSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public SspOperationExtensionsSchema(SspOperationExtensionsSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("63085386-1dd0-42f1-b47d-9c7bcf45cfbd");
			Name = "SspOperationExtensions";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("7cc31540-fa76-4c79-9b86-a6eabd8e662c");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,141,147,193,78,227,48,16,134,207,65,226,29,102,179,151,84,66,206,29,218,74,80,186,123,89,4,82,118,31,192,117,39,137,69,108,71,30,135,182,64,223,125,109,39,141,218,178,172,184,88,137,103,252,207,247,123,198,154,43,164,150,11,132,223,104,45,39,83,58,182,48,186,148,85,103,185,147,70,179,162,120,186,188,120,187,188,72,58,146,186,130,98,71,14,21,43,80,116,86,186,221,205,24,56,62,175,148,209,255,142,88,252,108,159,221,223,249,144,15,126,183,88,249,194,176,104,56,209,53,20,212,62,182,216,195,44,183,14,53,249,15,138,153,121,158,195,148,58,165,184,221,205,135,255,120,10,74,99,97,99,236,115,40,179,145,174,6,254,194,101,195,87,13,130,57,136,17,248,34,68,45,59,40,229,71,82,109,183,106,164,0,114,62,85,128,136,162,159,145,36,111,145,230,3,78,207,83,163,120,38,144,37,184,26,161,35,180,80,115,2,43,171,218,17,56,3,138,107,94,97,0,137,81,98,163,84,126,174,53,109,185,229,10,180,239,217,44,165,161,3,75,93,73,141,233,252,208,17,192,184,225,73,16,65,88,44,103,233,253,93,113,154,156,207,167,121,212,138,210,167,94,95,140,92,247,212,11,174,31,34,156,55,254,39,160,101,174,150,4,231,106,112,74,50,129,48,44,73,178,50,166,1,193,245,237,90,73,45,201,249,123,67,152,157,37,179,159,232,124,153,229,214,239,58,28,111,55,75,199,218,177,112,58,129,247,247,168,154,124,253,252,113,225,39,99,29,111,6,173,155,168,228,59,146,125,59,227,59,176,39,174,182,102,3,26,55,48,122,221,10,108,163,182,79,245,99,197,126,24,171,184,203,66,206,47,35,120,35,95,195,120,21,49,152,165,167,179,157,94,245,178,201,135,86,176,81,151,45,58,107,81,187,0,233,233,181,113,131,171,8,56,90,75,39,87,240,95,119,131,189,125,88,195,178,239,31,21,234,117,255,174,194,239,254,47,191,116,34,149,247,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("63085386-1dd0-42f1-b47d-9c7bcf45cfbd"));
		}

		#endregion

	}

	#endregion

}

