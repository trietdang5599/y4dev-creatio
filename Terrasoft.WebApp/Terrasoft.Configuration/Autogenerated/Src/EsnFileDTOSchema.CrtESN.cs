namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: EsnFileDTOSchema

	/// <exclude/>
	public class EsnFileDTOSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public EsnFileDTOSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public EsnFileDTOSchema(EsnFileDTOSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("2758fa81-89e1-4095-893e-aa49fad22cb4");
			Name = "EsnFileDTO";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("f0db0304-dc6c-40c0-a3bb-97ab97632500");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,141,144,207,110,194,48,12,198,207,32,241,14,22,92,182,75,31,0,180,83,129,137,3,127,180,114,155,118,48,141,169,44,181,105,229,56,135,129,120,247,37,169,134,6,98,18,151,68,223,231,207,191,216,1,139,13,185,14,75,130,61,137,160,107,143,154,229,173,61,114,229,5,149,91,155,45,138,205,104,120,30,13,7,222,177,173,160,248,118,74,205,236,78,103,31,222,42,55,148,21,36,140,53,159,82,111,72,133,220,68,168,10,2,242,26,157,155,194,194,217,37,215,52,223,111,83,245,115,142,138,225,69,21,44,245,43,24,157,63,212,92,66,25,211,55,225,65,28,226,74,219,73,219,145,40,83,64,238,82,75,194,245,188,53,53,7,146,151,77,88,14,222,96,188,50,227,215,136,254,101,191,123,54,176,50,112,134,138,116,6,46,30,151,255,219,227,125,11,112,42,113,247,20,120,18,82,240,233,14,194,86,33,186,207,18,114,33,84,50,91,251,112,150,107,245,17,110,66,214,244,255,22,84,239,253,181,46,63,41,226,222,77,7,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("2758fa81-89e1-4095-893e-aa49fad22cb4"));
		}

		#endregion

	}

	#endregion

}

