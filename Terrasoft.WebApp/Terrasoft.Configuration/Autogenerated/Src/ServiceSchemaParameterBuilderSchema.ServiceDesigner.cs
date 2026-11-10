namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: ServiceSchemaParameterBuilderSchema

	/// <exclude/>
	public class ServiceSchemaParameterBuilderSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ServiceSchemaParameterBuilderSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ServiceSchemaParameterBuilderSchema(ServiceSchemaParameterBuilderSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("5f037ecb-feb6-462e-a7ed-458ad1f12252");
			Name = "ServiceSchemaParameterBuilder";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("73951534-6fa4-4e40-b925-a1e2e4e079e3");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,173,83,77,107,194,64,20,60,175,224,127,120,208,75,2,146,31,224,39,85,219,34,72,17,148,94,74,15,235,230,69,183,196,77,250,118,147,34,197,255,222,77,86,73,252,32,94,60,25,179,179,243,102,230,77,20,223,161,78,185,64,88,33,17,215,73,100,130,73,162,34,185,201,136,27,153,168,96,137,148,75,129,75,177,197,29,111,183,254,218,173,118,139,101,90,170,13,44,247,218,224,206,226,227,24,69,1,214,193,27,42,36,41,122,151,152,185,84,63,213,203,250,44,194,224,149,11,147,144,68,221,43,201,159,8,55,150,12,102,202,32,69,86,91,23,102,103,42,22,156,172,108,123,56,206,100,28,34,149,183,210,108,29,75,1,242,116,233,238,29,102,173,48,54,149,165,114,78,251,190,54,100,197,117,32,89,127,91,59,67,40,145,222,236,69,101,59,36,190,142,177,127,155,113,8,233,233,81,251,133,201,131,179,129,42,116,78,236,159,154,173,73,204,181,238,194,125,71,159,83,140,120,22,155,177,84,161,21,230,153,125,138,73,228,53,251,242,253,175,42,12,81,140,106,158,4,247,195,101,110,231,44,37,153,115,131,160,141,109,134,128,7,39,215,41,70,52,238,67,59,142,69,21,54,148,43,100,145,45,17,23,91,240,114,78,21,163,173,66,125,49,71,44,115,108,144,243,56,67,24,84,136,224,29,109,83,195,138,125,100,171,95,244,218,83,231,7,48,24,58,38,230,108,94,28,119,64,225,111,67,56,158,239,251,193,42,153,75,109,60,31,70,163,154,130,143,66,83,207,145,95,153,13,158,195,208,171,176,147,36,196,142,115,225,187,43,7,40,127,8,77,70,234,58,172,18,116,56,110,210,213,227,209,221,63,70,124,84,224,40,106,11,190,31,204,73,227,141,47,168,221,58,252,3,81,24,21,89,172,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("5f037ecb-feb6-462e-a7ed-458ad1f12252"));
		}

		#endregion

	}

	#endregion

}

