namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: MLTextSimilarityProblemTypeFeaturesSchema

	/// <exclude/>
	public class MLTextSimilarityProblemTypeFeaturesSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public MLTextSimilarityProblemTypeFeaturesSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public MLTextSimilarityProblemTypeFeaturesSchema(MLTextSimilarityProblemTypeFeaturesSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("9fc5d315-3ac5-48a3-af06-cad122142a03");
			Name = "MLTextSimilarityProblemTypeFeatures";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("d4e7fe16-4978-48c7-8486-0391de2e8fa7");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,109,145,193,110,194,48,12,134,207,84,234,59,248,8,210,212,222,199,182,195,152,208,38,193,134,52,110,211,14,166,117,80,164,52,169,28,103,26,66,188,251,92,40,140,49,164,228,16,219,249,126,251,183,199,134,98,139,21,193,146,152,49,6,35,197,36,120,99,215,137,81,108,240,197,124,150,103,219,60,27,164,104,253,250,79,21,83,49,197,74,2,91,138,227,60,211,154,178,44,225,46,166,166,65,222,60,244,239,5,178,216,42,57,100,48,132,146,152,34,4,163,160,111,129,119,219,88,77,88,217,64,203,97,229,168,1,217,180,84,28,81,229,25,235,227,137,12,38,39,143,214,215,218,201,176,43,12,102,248,50,159,45,14,95,151,26,152,246,10,163,27,120,213,201,224,30,230,179,78,233,87,104,193,84,219,174,233,226,50,126,130,140,62,85,174,77,43,103,43,168,28,198,120,5,242,79,17,110,181,170,111,241,74,90,137,157,137,131,238,94,186,180,15,60,163,218,146,164,77,2,67,65,94,147,140,160,10,46,53,30,76,96,104,66,77,14,132,209,122,29,190,56,97,206,29,58,246,28,190,116,73,182,38,88,133,224,58,240,219,158,59,57,208,182,160,236,49,236,212,27,131,46,146,110,110,176,203,51,61,63,186,212,161,149,12,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("9fc5d315-3ac5-48a3-af06-cad122142a03"));
		}

		#endregion

	}

	#endregion

}

