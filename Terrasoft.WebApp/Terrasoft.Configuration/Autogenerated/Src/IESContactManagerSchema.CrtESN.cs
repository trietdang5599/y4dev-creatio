namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: IESContactManagerSchema

	/// <exclude/>
	public class IESContactManagerSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IESContactManagerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IESContactManagerSchema(IESContactManagerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("d67308e4-6320-4c6b-bc57-690f1d4497fe");
			Name = "IESContactManager";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("f0db0304-dc6c-40c0-a3bb-97ab97632500");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,133,82,205,74,195,64,16,62,91,240,29,134,122,81,144,196,179,166,1,41,85,10,86,197,246,5,182,219,73,186,152,236,214,153,221,74,17,223,221,217,36,141,90,21,79,203,204,124,63,243,179,86,213,200,27,165,17,22,72,164,216,21,62,25,59,91,152,50,144,242,198,217,100,50,191,63,30,188,29,15,142,2,27,91,194,124,199,30,107,193,84,21,234,8,224,228,22,45,146,209,87,135,152,197,154,80,173,36,145,44,20,63,179,212,5,113,66,88,10,11,166,214,35,21,98,124,9,211,201,124,82,43,83,205,148,85,37,146,128,210,52,133,140,67,93,43,218,229,93,252,72,110,107,86,200,80,163,95,187,21,67,225,8,180,179,94,105,207,192,168,72,175,163,215,158,158,126,225,111,194,178,50,26,204,222,51,90,142,91,234,167,233,91,211,95,223,224,172,181,185,132,199,134,220,22,15,27,107,18,243,198,187,239,37,233,129,233,33,50,219,40,82,53,88,89,250,104,72,248,18,144,253,48,191,51,236,193,21,221,12,192,158,100,14,78,178,180,65,255,65,118,175,99,23,172,176,155,39,210,37,197,50,34,16,250,64,22,182,170,10,248,175,8,63,20,5,163,200,60,69,182,107,130,40,82,198,155,170,74,196,120,35,55,254,69,168,181,225,190,251,140,17,65,19,22,163,97,183,218,27,71,51,180,241,143,12,211,92,4,246,140,40,17,127,68,54,157,216,80,139,205,178,194,236,7,39,207,187,197,118,21,190,230,157,213,167,209,46,107,87,148,67,183,194,243,120,89,216,175,4,70,112,209,103,186,249,98,238,236,170,59,48,218,85,123,227,38,126,111,191,229,183,228,251,7,24,73,253,245,23,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("d67308e4-6320-4c6b-bc57-690f1d4497fe"));
		}

		#endregion

	}

	#endregion

}

