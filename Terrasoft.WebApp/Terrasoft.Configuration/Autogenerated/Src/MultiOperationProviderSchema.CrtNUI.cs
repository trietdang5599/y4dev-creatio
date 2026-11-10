namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: MultiOperationProviderSchema

	/// <exclude/>
	public class MultiOperationProviderSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public MultiOperationProviderSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public MultiOperationProviderSchema(MultiOperationProviderSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("13cc5a20-1dd4-486f-abc0-6d6d0a98a042");
			Name = "MultiOperationProvider";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("6ba26f98-9709-4408-98d0-761f0c4bf2aa");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,149,83,93,79,227,48,16,124,14,18,255,97,197,189,164,18,74,223,175,128,116,130,30,170,196,151,142,123,143,76,188,13,150,28,59,183,182,203,69,136,255,126,78,82,39,78,40,232,120,106,237,217,153,157,221,140,21,171,208,212,172,64,248,141,68,204,232,173,205,46,181,218,138,210,17,179,66,171,227,163,215,227,163,196,25,161,74,120,108,140,197,106,53,59,251,122,41,177,104,139,77,118,141,10,73,20,239,106,110,132,250,51,94,198,189,170,74,43,143,120,236,27,97,233,69,224,82,50,99,190,195,173,147,86,220,215,216,251,120,32,189,19,28,169,171,92,46,151,112,102,92,85,49,106,46,246,231,80,0,91,77,80,181,220,90,34,232,192,55,89,224,45,35,98,237,158,164,40,160,104,59,126,216,48,121,237,154,14,254,126,10,148,220,27,124,32,177,99,22,123,176,238,15,64,200,184,86,178,129,205,84,238,209,250,95,44,27,200,205,254,223,234,32,205,163,237,134,114,84,86,216,230,206,127,158,195,117,55,194,216,179,107,39,248,5,228,132,133,38,110,54,124,181,55,138,138,247,94,167,198,253,135,245,242,174,176,154,90,251,221,236,123,247,253,30,14,111,32,253,104,148,48,201,105,112,61,154,62,141,13,14,254,22,208,134,41,73,196,22,210,64,134,243,115,80,78,202,128,37,246,153,244,11,40,124,129,31,84,186,202,107,222,121,120,253,183,192,186,237,158,158,132,254,39,139,110,53,201,91,172,233,109,100,27,211,50,238,105,93,213,182,73,71,83,139,255,239,177,30,72,239,187,12,227,204,26,125,65,254,87,144,152,170,231,227,82,96,18,147,36,202,131,199,102,225,72,198,4,120,48,78,67,39,252,89,36,110,209,62,107,62,75,195,252,121,117,23,87,122,124,76,217,80,21,63,166,144,162,157,32,235,152,132,157,22,220,211,134,220,164,97,63,195,152,89,140,230,113,122,198,137,22,159,140,209,223,78,47,223,254,1,164,122,197,3,211,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("13cc5a20-1dd4-486f-abc0-6d6d0a98a042"));
		}

		#endregion

	}

	#endregion

}

