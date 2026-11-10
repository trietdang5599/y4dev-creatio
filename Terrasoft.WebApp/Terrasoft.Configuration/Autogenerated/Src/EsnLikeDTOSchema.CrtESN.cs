namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: EsnLikeDTOSchema

	/// <exclude/>
	public class EsnLikeDTOSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public EsnLikeDTOSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public EsnLikeDTOSchema(EsnLikeDTOSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("d9ba4548-db18-453f-afd7-0da2ee2c2296");
			Name = "EsnLikeDTO";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("b66b5ae8-46e0-4931-ad78-c2c1ba5fd6ea");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,149,146,193,110,194,48,12,134,207,32,241,14,22,92,182,75,31,96,104,167,130,166,74,131,85,43,59,77,59,132,212,84,214,154,180,178,147,3,67,188,251,146,34,182,117,42,18,92,34,253,246,239,207,177,19,171,12,74,171,52,194,6,153,149,52,59,151,164,141,221,81,229,89,57,106,108,178,44,214,147,241,97,50,30,121,33,91,65,177,23,135,102,254,79,39,175,222,58,50,152,20,200,164,106,250,234,106,131,43,248,102,140,85,16,144,214,74,228,1,150,98,159,233,19,23,155,151,46,251,190,80,78,133,142,142,149,118,31,33,208,250,109,77,26,116,116,247,204,163,120,137,31,90,206,77,139,236,8,3,50,239,74,58,220,137,183,66,179,69,190,91,135,225,224,17,166,84,78,239,35,250,204,126,242,84,66,86,194,1,42,116,115,144,120,28,47,151,75,163,195,76,43,20,81,21,102,67,172,162,239,184,22,236,5,121,144,247,214,37,174,197,232,176,189,176,188,65,82,122,206,221,8,139,178,143,19,199,241,189,211,223,252,141,200,156,201,40,222,103,230,210,22,211,33,223,80,147,25,218,242,244,13,130,58,197,254,134,142,223,212,253,34,125,213,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("d9ba4548-db18-453f-afd7-0da2ee2c2296"));
		}

		#endregion

	}

	#endregion

}

