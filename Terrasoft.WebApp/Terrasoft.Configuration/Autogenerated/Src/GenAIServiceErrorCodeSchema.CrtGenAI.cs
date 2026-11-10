namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: GenAIServiceErrorCodeSchema

	/// <exclude/>
	public class GenAIServiceErrorCodeSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public GenAIServiceErrorCodeSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public GenAIServiceErrorCodeSchema(GenAIServiceErrorCodeSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("2c8ba8dd-b291-4ffb-89f1-3346066bacf9");
			Name = "GenAIServiceErrorCode";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("e8ce15e9-1e70-4be4-81f7-3d2e4afa30e7");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,141,146,205,78,195,48,12,199,207,84,234,59,228,8,151,189,0,226,48,85,21,154,196,118,97,125,0,47,117,55,107,153,61,57,105,249,18,239,78,54,132,250,1,27,57,36,82,254,254,231,231,216,49,195,1,253,17,44,154,53,170,130,151,38,204,10,225,134,182,173,66,32,225,217,35,242,124,145,103,31,121,118,115,108,55,142,172,241,33,70,172,177,14,188,55,231,240,51,106,71,22,75,85,209,66,106,140,222,147,127,114,65,17,106,97,247,22,207,74,188,53,21,239,89,94,248,124,203,60,24,142,79,145,230,118,168,222,221,255,79,89,176,21,85,180,97,244,236,158,247,119,60,133,124,170,10,117,37,97,222,1,57,216,56,236,169,191,99,41,196,39,58,80,40,95,45,98,141,117,15,27,201,41,156,138,161,13,59,81,122,31,98,134,106,90,231,58,112,84,87,74,195,110,253,104,41,132,149,148,28,40,16,250,158,208,107,41,132,98,7,10,54,160,142,122,48,25,137,43,166,148,28,107,17,87,128,115,62,22,39,123,244,23,126,225,170,45,37,207,50,78,190,27,77,217,164,142,11,134,111,118,92,159,121,150,103,113,251,2,197,250,59,195,149,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("2c8ba8dd-b291-4ffb-89f1-3346066bacf9"));
		}

		#endregion

	}

	#endregion

}

