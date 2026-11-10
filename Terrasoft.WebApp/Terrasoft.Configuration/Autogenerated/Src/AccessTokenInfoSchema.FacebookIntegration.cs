namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: AccessTokenInfoSchema

	/// <exclude/>
	public class AccessTokenInfoSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public AccessTokenInfoSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public AccessTokenInfoSchema(AccessTokenInfoSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("edcf69f4-2a5f-419d-9855-0d3c0ba8478a");
			Name = "AccessTokenInfo";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("34c57733-6570-402b-8e25-5c50c5be2b38");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,157,148,205,110,194,48,12,199,207,32,237,29,34,184,176,75,31,96,108,147,16,251,80,165,49,161,193,118,153,80,149,166,6,101,132,36,138,211,105,12,241,238,75,211,22,40,80,38,245,150,216,127,251,103,59,31,146,174,0,53,101,64,166,96,12,69,53,183,193,80,201,57,95,164,134,90,174,100,48,81,140,83,113,213,222,92,181,91,41,114,185,32,147,53,90,88,245,143,246,46,76,8,96,89,12,6,207,32,193,112,118,162,121,75,165,229,43,8,38,206,75,5,255,245,136,189,234,201,21,18,43,181,116,22,103,235,26,88,56,55,25,10,138,120,67,6,140,1,226,84,45,65,134,114,174,188,228,115,151,40,22,48,203,12,15,212,82,215,128,53,148,217,204,160,211,88,112,70,88,150,227,52,69,107,227,211,236,80,99,163,52,24,203,193,241,198,62,50,247,251,180,35,88,197,96,122,175,110,100,228,142,116,232,62,89,231,122,230,85,101,253,35,170,181,235,167,87,104,34,123,32,42,10,66,107,178,142,15,42,34,217,132,91,173,5,216,190,95,96,177,216,94,40,65,235,48,169,135,107,29,241,228,60,54,11,108,6,116,89,252,169,93,194,30,105,78,216,165,191,65,5,240,163,185,1,28,216,90,126,161,136,168,173,226,133,114,240,199,50,188,57,58,172,111,189,68,115,89,143,14,155,116,205,241,195,221,242,250,163,230,24,125,31,8,10,172,147,8,18,230,161,141,160,152,66,114,97,210,185,224,252,160,195,34,184,1,23,153,123,132,88,75,173,184,11,228,11,71,123,171,226,47,247,255,220,147,137,23,52,0,251,103,58,93,107,168,101,123,69,100,247,146,234,213,158,150,9,26,192,83,4,115,225,49,103,238,186,215,252,238,67,255,97,118,65,38,249,47,231,247,185,181,106,220,254,1,167,4,218,2,14,6,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("edcf69f4-2a5f-419d-9855-0d3c0ba8478a"));
		}

		#endregion

	}

	#endregion

}

