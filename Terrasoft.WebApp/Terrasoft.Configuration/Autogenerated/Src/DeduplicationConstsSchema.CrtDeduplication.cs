namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: DeduplicationConstsSchema

	/// <exclude/>
	public class DeduplicationConstsSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public DeduplicationConstsSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public DeduplicationConstsSchema(DeduplicationConstsSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("2f63d953-bd1e-490d-81f5-9a26e360c7c0");
			Name = "DeduplicationConsts";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("a2cb4b0a-72d7-4fbf-b57c-bc3bae7898e7");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,157,146,77,78,195,48,16,133,215,84,234,29,172,178,129,133,155,159,166,77,66,1,137,154,8,177,64,44,202,5,38,241,36,88,106,156,200,118,132,42,196,221,177,221,22,10,136,5,172,70,51,243,222,188,111,49,18,90,212,61,84,72,158,80,41,208,93,109,166,172,147,181,104,6,5,70,116,146,188,142,71,39,131,22,178,33,235,173,54,216,46,199,35,59,57,85,216,184,45,219,128,214,23,228,22,249,80,110,68,229,45,214,175,141,246,178,32,8,200,165,30,218,22,212,246,122,223,219,181,1,33,53,169,156,14,164,209,164,86,93,235,218,163,88,46,42,87,65,9,212,211,195,165,224,232,84,239,3,137,189,96,108,169,28,135,199,232,191,98,56,126,171,254,65,226,7,159,122,36,93,143,251,104,74,214,8,170,122,158,126,248,142,115,191,5,43,4,222,201,205,150,220,13,130,239,141,143,135,83,247,156,92,17,137,47,126,121,54,41,162,116,150,134,140,81,182,40,50,154,68,73,76,111,138,85,78,179,85,92,68,243,21,11,51,150,77,206,151,46,228,207,200,15,168,26,252,7,177,247,253,6,156,228,60,92,228,113,76,231,33,32,77,120,206,105,201,121,73,163,100,193,103,49,212,81,153,166,30,216,166,188,237,254,2,37,223,189,134,107,237,236,29,173,154,96,89,97,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("2f63d953-bd1e-490d-81f5-9a26e360c7c0"));
		}

		#endregion

	}

	#endregion

}

