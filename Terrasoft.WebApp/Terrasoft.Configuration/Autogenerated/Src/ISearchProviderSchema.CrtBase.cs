namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: ISearchProviderSchema

	/// <exclude/>
	public class ISearchProviderSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ISearchProviderSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ISearchProviderSchema(ISearchProviderSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("ce4a57cc-37d9-4a85-b56a-a7ea95f370e8");
			Name = "ISearchProvider";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,101,145,193,110,131,48,12,134,207,69,226,29,172,238,178,73,19,185,183,140,75,55,77,28,38,117,98,47,16,192,208,72,16,152,157,76,66,85,223,125,33,64,203,186,83,100,255,159,253,59,182,150,45,114,47,11,132,47,36,146,220,85,38,58,116,186,82,181,37,105,84,167,195,224,28,6,27,203,74,215,144,13,108,176,117,122,211,96,49,138,28,189,163,70,82,197,62,12,28,245,64,88,187,44,164,218,32,85,174,233,14,210,12,37,21,167,35,117,63,170,68,242,152,16,2,98,182,109,43,105,72,230,120,194,160,159,185,104,193,196,138,235,109,222,168,2,212,210,253,127,243,205,217,27,92,7,249,64,115,234,74,222,193,209,151,78,226,189,253,202,159,33,31,224,219,34,13,209,149,20,247,104,220,75,146,45,104,183,185,151,45,251,186,207,177,100,155,204,159,152,26,196,194,115,183,50,66,99,73,243,66,17,178,109,12,59,110,17,70,50,125,211,182,69,146,121,131,241,171,242,75,118,222,49,27,114,7,120,134,233,77,146,121,222,199,236,102,15,171,81,158,246,243,30,80,151,211,42,124,124,153,174,244,39,121,249,5,251,245,215,252,2,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("ce4a57cc-37d9-4a85-b56a-a7ea95f370e8"));
		}

		#endregion

	}

	#endregion

}

