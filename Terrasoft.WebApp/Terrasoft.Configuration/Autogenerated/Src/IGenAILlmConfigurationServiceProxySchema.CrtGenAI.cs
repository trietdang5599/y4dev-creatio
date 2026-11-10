namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: IGenAILlmConfigurationServiceProxySchema

	/// <exclude/>
	public class IGenAILlmConfigurationServiceProxySchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IGenAILlmConfigurationServiceProxySchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IGenAILlmConfigurationServiceProxySchema(IGenAILlmConfigurationServiceProxySchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("6c3074a3-05c9-4772-b7cb-2bf6723d585f");
			Name = "IGenAILlmConfigurationServiceProxy";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("e8ce15e9-1e70-4be4-81f7-3d2e4afa30e7");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,181,84,219,106,220,48,16,125,78,32,255,48,36,47,9,20,251,61,217,6,66,83,202,194,46,4,118,251,1,83,107,108,139,90,35,87,151,77,150,208,127,239,72,74,182,241,110,72,75,104,95,140,52,210,156,57,231,204,200,140,134,252,136,13,193,154,156,67,111,219,80,125,178,220,234,46,58,12,218,114,245,133,248,102,126,114,252,120,114,124,20,189,230,14,86,91,31,200,84,235,222,17,42,9,84,107,244,223,253,213,238,252,55,208,103,118,186,233,13,113,168,230,28,200,181,82,199,23,192,106,105,21,13,146,36,105,103,142,58,169,4,187,59,151,48,207,151,22,131,153,112,89,145,219,232,134,238,156,125,216,230,204,186,174,97,230,163,49,232,182,215,79,251,91,106,53,147,7,59,82,201,242,208,90,7,6,25,187,68,111,129,174,35,249,114,23,81,22,153,7,156,47,22,203,11,104,94,22,243,79,120,161,119,54,118,61,32,248,82,30,198,84,191,130,85,28,71,235,130,7,84,201,134,15,16,71,37,153,105,133,172,64,96,41,237,192,228,10,83,236,234,153,124,253,130,253,24,191,13,186,1,253,108,195,95,185,112,244,152,157,216,153,184,164,208,91,229,47,225,46,163,149,195,125,159,114,224,70,41,225,14,76,247,32,234,167,4,33,88,17,78,224,75,175,119,24,245,62,200,108,68,135,6,88,198,232,227,233,48,152,108,231,233,245,90,114,19,232,43,218,19,180,56,86,205,234,156,154,145,54,86,171,196,103,95,234,121,134,155,132,166,96,23,87,111,8,252,154,250,33,147,128,12,244,160,125,110,198,161,82,205,255,77,233,189,14,125,153,10,82,176,193,33,202,244,31,200,46,44,255,173,242,219,52,123,127,84,222,58,107,222,161,61,43,157,171,34,61,178,254,17,9,180,146,71,174,91,77,14,108,155,49,223,232,126,126,25,116,232,68,97,253,110,39,206,136,85,121,4,121,255,179,252,91,38,65,137,253,2,29,10,235,163,241,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("6c3074a3-05c9-4772-b7cb-2bf6723d585f"));
		}

		#endregion

	}

	#endregion

}

