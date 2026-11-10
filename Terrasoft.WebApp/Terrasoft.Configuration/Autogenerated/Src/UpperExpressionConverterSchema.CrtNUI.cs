namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: UpperExpressionConverterSchema

	/// <exclude/>
	public class UpperExpressionConverterSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public UpperExpressionConverterSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public UpperExpressionConverterSchema(UpperExpressionConverterSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("610a8b86-38e8-423a-9fde-cc03471e6042");
			Name = "UpperExpressionConverter";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("75f7d434-56de-4d62-8a8c-9fe090e3ebb1");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,117,82,77,107,227,48,16,61,59,144,255,48,168,23,155,22,187,185,166,169,75,9,89,8,236,23,164,123,90,246,160,216,19,199,139,45,155,209,40,109,40,249,239,43,75,182,73,211,236,73,232,205,123,111,230,73,163,100,141,186,149,25,194,11,18,73,221,236,56,94,54,106,87,22,134,36,151,141,154,78,222,167,147,192,232,82,21,176,57,106,198,250,97,58,177,200,13,97,97,203,176,172,164,214,115,248,213,182,72,171,183,150,80,107,11,91,139,3,18,35,57,110,146,36,176,208,166,174,37,29,211,254,238,4,144,73,141,160,153,58,119,28,213,144,13,114,200,58,251,120,240,72,206,76,126,95,233,246,204,214,106,107,24,67,225,252,69,244,199,50,91,179,173,202,204,91,253,119,80,152,195,250,26,108,245,239,46,196,152,248,27,242,190,201,109,230,159,206,215,23,47,35,58,160,119,209,67,194,131,172,12,198,35,61,185,228,47,90,73,178,6,101,255,228,81,56,178,72,55,231,210,69,226,24,215,5,146,10,83,163,98,45,82,120,206,243,178,251,61,89,193,8,127,86,19,178,33,165,211,33,109,254,97,80,224,6,204,248,75,86,61,208,59,125,255,166,61,127,213,9,164,125,246,102,251,23,51,246,250,187,161,58,78,0,143,32,68,4,221,66,5,65,95,180,135,133,67,127,139,156,240,193,213,203,221,128,198,107,253,221,84,213,15,90,213,45,31,59,48,26,76,2,63,83,231,226,85,39,239,253,90,114,182,135,112,236,60,242,221,194,137,47,37,105,94,238,37,137,57,120,252,204,40,222,152,173,111,28,222,223,193,44,138,95,26,183,52,107,117,144,84,74,197,97,4,183,110,182,248,43,170,130,247,144,194,12,158,46,164,179,200,110,148,77,235,199,10,114,220,73,83,241,181,118,159,237,207,162,156,250,221,67,149,251,245,115,119,143,126,4,79,255,0,198,180,205,214,203,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("610a8b86-38e8-423a-9fde-cc03471e6042"));
		}

		#endregion

	}

	#endregion

}

