namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: PropertyDefinitionContractResolverSchema

	/// <exclude/>
	public class PropertyDefinitionContractResolverSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public PropertyDefinitionContractResolverSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public PropertyDefinitionContractResolverSchema(PropertyDefinitionContractResolverSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("5e7878b0-1806-41d9-8bfa-8302e7d86d2c");
			Name = "PropertyDefinitionContractResolver";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("efe6ccd0-4801-4cb7-acb1-e0c434c41931");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,149,83,77,107,220,48,16,61,59,144,255,48,228,16,118,161,216,247,166,27,8,222,20,82,218,180,100,147,83,233,65,43,143,118,85,100,201,29,201,73,221,210,255,222,145,98,237,103,26,40,248,75,51,154,247,222,188,145,173,104,209,119,66,34,220,35,145,240,78,133,178,118,86,233,85,79,34,104,103,203,107,75,90,174,91,180,225,244,228,247,233,73,209,123,109,87,176,24,124,192,246,226,96,93,206,181,88,89,231,131,150,158,97,26,188,178,194,12,94,251,237,198,91,124,10,206,38,158,15,222,217,127,38,202,5,146,22,70,255,74,42,142,136,238,80,25,148,251,169,109,7,91,205,229,141,13,72,138,27,100,65,107,17,106,215,118,6,115,29,95,85,85,193,59,223,183,173,160,225,114,92,215,189,15,174,5,233,108,32,33,3,16,122,103,30,145,64,57,226,205,136,32,9,213,236,236,11,185,14,41,12,115,84,218,234,8,122,86,93,66,112,176,22,182,49,8,190,67,169,149,150,224,119,123,97,184,31,189,38,140,242,124,153,37,84,59,26,190,94,255,148,166,111,240,61,185,54,186,88,59,38,23,43,252,198,185,174,95,26,70,148,70,120,15,199,2,234,81,243,93,150,252,22,56,41,122,19,14,51,140,21,199,249,204,174,237,154,37,134,198,73,168,162,130,162,35,23,216,95,108,32,114,147,110,16,226,84,50,33,212,132,34,96,94,78,62,97,187,68,186,177,202,65,155,62,223,192,115,104,111,138,99,110,47,54,133,164,162,120,20,4,76,218,193,12,150,194,99,121,64,144,81,95,66,184,72,0,90,193,36,2,148,115,100,115,136,15,196,253,208,33,204,102,16,248,237,212,228,216,172,105,42,44,206,207,19,115,249,96,27,36,51,112,229,45,255,21,177,210,242,251,197,202,50,98,127,212,62,76,179,254,34,65,176,201,108,23,159,56,110,195,226,19,196,109,139,16,197,124,166,43,62,157,195,102,195,100,148,253,39,61,9,67,79,54,201,72,97,142,254,247,108,242,128,199,217,228,229,36,217,224,150,223,185,36,126,238,26,190,57,225,123,166,111,42,119,138,182,30,111,131,175,123,187,49,38,147,28,153,115,92,52,182,241,138,67,25,44,187,20,111,190,254,2,86,111,72,181,199,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("5e7878b0-1806-41d9-8bfa-8302e7d86d2c"));
		}

		#endregion

	}

	#endregion

}

