namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: IExternalApplicationHubProviderSchema

	/// <exclude/>
	public class IExternalApplicationHubProviderSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IExternalApplicationHubProviderSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IExternalApplicationHubProviderSchema(IExternalApplicationHubProviderSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("4225fc58-dff7-420e-a9bf-ba24da81cc90");
			Name = "IExternalApplicationHubProvider";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("cb307258-3a76-44c9-ba03-f25bdd404252");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,133,145,221,74,3,49,16,133,175,187,176,239,48,224,141,222,108,238,235,82,16,41,90,104,161,72,251,0,217,238,100,55,176,155,132,73,34,138,244,221,157,102,127,212,130,122,151,153,156,243,205,156,196,200,30,189,147,39,132,3,18,73,111,85,40,30,173,81,186,137,36,131,182,38,207,62,242,44,207,22,55,132,13,151,176,49,1,73,177,97,9,155,245,27,159,141,236,30,156,235,244,41,201,159,99,181,39,251,170,107,164,100,19,66,64,233,99,223,75,122,95,141,245,140,0,101,9,92,146,107,211,128,54,92,247,9,3,178,178,49,0,142,3,64,126,77,128,54,86,197,68,22,223,208,46,86,172,97,202,68,255,119,191,197,16,109,206,182,195,208,218,218,47,97,159,80,195,229,117,130,212,120,194,224,33,180,248,235,134,112,124,217,22,179,93,92,251,75,194,16,201,248,213,129,25,44,5,171,254,196,21,165,152,28,23,132,15,116,121,48,222,226,72,221,237,221,253,24,3,77,61,36,73,245,121,248,183,31,205,243,39,81,196,171,87,240,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("4225fc58-dff7-420e-a9bf-ba24da81cc90"));
		}

		#endregion

	}

	#endregion

}

