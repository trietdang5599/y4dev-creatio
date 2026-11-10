namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: NumberDigitExpressionConverterSchema

	/// <exclude/>
	public class NumberDigitExpressionConverterSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public NumberDigitExpressionConverterSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public NumberDigitExpressionConverterSchema(NumberDigitExpressionConverterSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("f1dacd9b-b93b-430e-89f3-3ee26a40f8d8");
			Name = "NumberDigitExpressionConverter";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("75f7d434-56de-4d62-8a8c-9fe090e3ebb1");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,133,83,75,111,218,64,16,62,19,41,255,97,106,46,182,132,214,61,39,132,40,162,20,113,104,26,9,110,81,15,139,61,152,141,236,93,107,31,105,105,196,127,239,236,174,109,133,135,212,3,216,243,205,124,223,60,45,121,131,166,229,5,194,6,181,230,70,237,44,155,43,185,19,149,211,220,10,37,111,111,62,110,111,70,206,8,89,193,250,96,44,54,247,103,54,91,214,106,203,107,241,55,196,95,120,55,123,141,188,36,128,60,228,27,107,172,40,12,230,53,55,230,14,158,93,179,69,253,77,84,194,46,254,180,26,141,33,39,21,240,142,218,162,14,140,60,207,97,106,92,211,112,125,152,117,118,164,65,233,121,128,3,17,138,158,9,133,215,103,61,61,255,196,127,189,146,232,201,90,45,182,206,98,154,124,170,40,201,126,81,124,235,182,181,40,162,224,127,234,133,59,88,93,131,73,229,35,244,50,180,255,3,237,94,149,52,128,151,160,30,157,231,157,6,96,141,45,167,85,160,1,98,56,195,101,105,224,183,176,123,144,113,6,149,86,174,5,19,163,148,102,131,80,126,174,52,245,33,13,72,90,249,67,242,206,107,135,201,172,27,100,176,216,52,15,17,215,9,92,87,174,65,105,77,50,131,167,178,20,126,217,188,134,1,190,100,107,180,78,75,51,235,231,80,246,85,250,55,154,55,221,72,159,183,15,245,220,110,222,93,196,194,135,16,37,85,219,55,44,108,100,76,122,239,144,29,30,32,129,36,3,127,172,163,81,137,133,104,168,56,122,222,7,64,236,32,253,210,161,108,163,15,47,92,27,76,211,168,146,117,154,202,89,207,200,122,149,81,172,170,203,197,22,77,107,15,81,238,24,254,227,236,190,43,221,112,187,146,59,5,244,217,80,29,231,48,91,34,61,141,229,178,192,52,126,13,108,238,180,166,178,79,173,185,171,41,31,102,108,94,43,137,105,6,220,92,136,197,252,148,136,69,207,210,111,127,221,47,159,178,119,197,174,204,179,171,235,159,58,20,157,14,99,202,224,209,207,137,238,116,128,162,98,215,42,181,207,54,106,29,52,210,100,60,30,79,78,127,95,217,25,150,76,124,215,25,205,84,52,105,22,180,142,221,165,163,44,227,177,7,59,162,167,224,241,31,197,217,131,237,126,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("f1dacd9b-b93b-430e-89f3-3ee26a40f8d8"));
		}

		#endregion

	}

	#endregion

}

