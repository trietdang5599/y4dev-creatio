namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: BaseStorableEntitySchema

	/// <exclude/>
	public class BaseStorableEntitySchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public BaseStorableEntitySchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public BaseStorableEntitySchema(BaseStorableEntitySchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("29c15305-d044-47a9-b58f-c7d81b88fdca");
			Name = "BaseStorableEntity";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("6ba26f98-9709-4408-98d0-761f0c4bf2aa");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,109,144,203,106,195,48,16,69,215,50,228,31,6,178,73,54,246,62,169,83,104,8,165,155,18,112,119,165,20,197,158,184,3,182,100,244,72,112,75,254,189,210,216,46,166,237,66,24,29,221,185,62,146,146,45,218,78,150,8,47,104,140,180,250,236,210,189,86,103,170,189,145,142,180,90,36,95,139,68,120,75,170,134,162,183,14,219,237,34,9,100,105,176,14,199,176,111,164,181,27,120,144,22,11,167,141,60,53,120,80,142,92,207,169,44,203,224,206,250,182,149,166,223,141,251,24,5,59,102,1,57,12,87,114,31,32,189,211,53,42,12,127,198,10,168,74,167,134,108,86,241,90,160,33,217,208,103,28,127,11,160,243,167,134,74,40,163,200,191,30,34,222,64,196,53,73,31,141,238,208,56,194,96,126,228,241,41,241,91,152,193,80,52,10,253,53,18,157,161,75,80,134,71,79,21,188,83,181,101,56,104,49,123,170,128,29,68,141,14,242,93,204,64,158,243,89,122,104,187,208,125,15,43,134,3,123,198,107,252,174,214,107,216,252,20,10,59,27,134,139,108,60,50,191,241,75,139,37,170,106,184,30,239,7,58,135,55,248,6,100,162,10,33,237,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("29c15305-d044-47a9-b58f-c7d81b88fdca"));
		}

		#endregion

	}

	#endregion

}

