namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: RuntimeSchemaCacheableHashProviderSchema

	/// <exclude/>
	public class RuntimeSchemaCacheableHashProviderSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public RuntimeSchemaCacheableHashProviderSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public RuntimeSchemaCacheableHashProviderSchema(RuntimeSchemaCacheableHashProviderSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("99cc4b0c-9078-4ba2-ac68-06bcae2028e3");
			Name = "RuntimeSchemaCacheableHashProvider";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("c302261e-8f3d-4933-bbe5-b7b61ee66faa");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,157,83,193,110,219,48,12,61,167,64,255,65,200,46,9,16,231,3,154,181,64,151,172,91,176,97,43,150,222,138,29,20,153,118,133,217,146,33,82,29,130,160,255,62,74,114,157,120,73,145,108,55,91,124,124,124,124,36,141,172,1,27,169,64,60,128,115,18,109,65,211,185,53,133,46,189,147,164,173,185,188,216,94,94,12,60,106,83,138,213,6,9,106,142,87,21,168,16,196,233,39,48,224,180,154,117,152,125,26,7,211,121,165,193,208,92,170,39,120,19,115,39,21,89,167,1,119,8,36,46,174,254,6,166,250,43,32,98,12,238,115,7,205,156,99,232,36,199,29,72,242,14,30,108,89,86,140,250,63,146,219,166,169,180,146,201,130,243,24,122,166,46,36,201,207,18,159,238,157,125,214,57,184,94,30,103,190,115,80,50,76,204,43,137,120,37,126,120,67,186,134,21,87,168,101,44,36,215,21,236,19,196,172,199,5,20,210,87,244,65,155,156,43,143,104,211,128,45,70,203,152,177,143,30,79,196,55,158,187,184,22,195,211,212,195,241,79,230,110,252,154,59,22,42,8,58,67,143,96,209,144,107,60,26,156,136,229,2,26,48,249,171,109,253,78,6,219,216,205,206,132,224,141,243,97,71,216,139,251,40,36,33,90,81,167,229,176,7,187,33,173,152,8,184,147,254,195,152,37,175,37,194,232,48,16,14,96,240,210,138,98,217,73,87,95,36,87,106,192,17,47,241,85,248,38,190,15,200,91,149,175,191,194,62,243,26,177,30,222,9,23,86,35,22,249,2,27,113,125,35,134,46,117,145,21,14,32,183,117,230,117,134,177,35,204,84,192,101,191,96,51,156,253,131,138,67,163,150,31,141,175,193,5,119,222,39,9,55,34,77,2,191,155,40,38,172,5,138,173,40,129,102,226,133,23,196,192,111,241,85,35,117,248,104,198,128,47,177,61,195,110,128,33,117,18,131,237,137,225,145,16,31,206,210,20,182,171,149,94,15,110,163,139,71,231,103,189,38,142,154,152,214,249,12,23,143,57,216,206,182,111,42,191,253,1,2,155,190,137,28,5,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("99cc4b0c-9078-4ba2-ac68-06bcae2028e3"));
		}

		#endregion

	}

	#endregion

}

