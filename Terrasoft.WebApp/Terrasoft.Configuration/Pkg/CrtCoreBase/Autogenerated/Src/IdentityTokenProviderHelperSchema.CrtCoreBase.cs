namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: IdentityTokenProviderHelperSchema

	/// <exclude/>
	public class IdentityTokenProviderHelperSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IdentityTokenProviderHelperSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IdentityTokenProviderHelperSchema(IdentityTokenProviderHelperSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("1b0f2af0-c41a-41f0-8be2-0699721fe873");
			Name = "IdentityTokenProviderHelper";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("1e78c195-217a-4877-a718-71dfe1dfe442");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,205,146,65,78,195,48,16,69,215,173,212,59,120,153,110,114,129,2,82,137,4,100,3,168,244,2,198,153,6,139,96,135,153,113,80,132,122,119,198,77,90,218,16,22,136,77,35,103,99,255,255,253,230,203,202,233,55,160,90,27,80,107,64,212,228,55,156,102,222,109,108,25,80,179,245,110,54,253,156,77,39,129,172,43,79,36,8,139,95,246,211,27,109,216,163,5,26,83,60,44,3,191,228,142,161,236,242,69,35,170,58,60,87,214,40,98,217,51,202,84,154,72,229,5,56,182,220,174,253,43,184,71,244,141,45,0,239,160,170,1,197,17,169,6,182,124,212,161,110,129,115,39,18,103,32,153,171,157,111,210,104,84,218,24,32,242,168,46,85,22,47,236,176,219,84,244,23,135,168,125,202,178,23,95,37,243,197,46,1,129,3,186,67,72,116,157,92,155,56,248,80,195,148,21,144,175,66,28,123,5,239,1,136,5,168,203,219,238,106,248,251,64,196,24,251,37,192,198,26,200,124,1,231,54,98,143,35,223,211,55,164,0,29,33,247,130,237,191,170,184,110,239,229,45,239,11,177,3,172,120,118,190,205,28,83,10,209,24,252,143,142,226,47,235,11,196,231,66,223,194,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("1b0f2af0-c41a-41f0-8be2-0699721fe873"));
		}

		#endregion

	}

	#endregion

}

