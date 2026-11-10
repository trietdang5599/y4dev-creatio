namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: SspUserInviteSchema

	/// <exclude/>
	public class SspUserInviteSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public SspUserInviteSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public SspUserInviteSchema(SspUserInviteSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("c0da7f03-8582-4036-b93e-8094a1fe6e41");
			Name = "SspUserInvite";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("7cc31540-fa76-4c79-9b86-a6eabd8e662c");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,165,84,77,107,2,49,16,61,87,240,63,12,120,215,187,182,5,145,34,66,17,113,235,169,244,16,227,104,3,187,201,50,147,88,68,252,239,77,178,126,182,101,141,246,178,108,134,121,243,222,155,73,70,139,2,185,20,18,225,13,137,4,155,165,109,15,140,94,170,149,35,97,149,209,237,44,155,52,27,219,102,227,193,177,210,43,200,54,108,177,232,53,27,62,210,34,92,249,20,24,228,130,185,11,25,151,51,70,26,233,181,178,24,19,58,157,14,60,178,43,10,65,155,231,253,217,87,183,66,105,36,88,26,130,210,144,21,57,168,136,105,31,32,157,51,76,233,230,185,146,32,3,199,37,5,116,97,116,30,136,122,61,34,136,61,106,155,144,41,145,172,66,47,112,18,75,69,101,191,164,197,192,75,33,84,14,102,121,144,229,124,233,246,49,251,92,213,65,22,91,10,93,169,128,91,88,161,237,1,135,207,174,134,102,114,170,94,181,67,218,209,162,158,103,232,212,226,148,251,31,38,208,126,228,73,166,198,62,241,46,38,127,71,250,139,66,233,153,86,105,198,46,1,201,156,97,242,64,38,71,190,206,241,254,17,211,167,33,251,46,83,213,127,95,74,227,116,154,171,31,136,219,108,249,42,168,25,211,167,245,90,1,238,30,218,94,231,144,140,43,147,236,93,2,238,226,28,167,154,11,45,185,201,217,20,217,229,54,60,229,240,252,171,77,86,75,52,55,38,135,204,73,137,252,227,126,192,19,88,114,216,171,219,27,68,126,151,125,125,170,28,171,85,230,53,167,237,141,8,76,53,149,249,21,231,56,152,226,13,139,240,96,156,127,48,64,40,13,93,153,88,180,55,226,208,199,190,180,106,253,103,39,91,168,23,213,218,140,231,42,122,25,220,125,3,156,224,230,225,49,6,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("c0da7f03-8582-4036-b93e-8094a1fe6e41"));
		}

		#endregion

	}

	#endregion

}

