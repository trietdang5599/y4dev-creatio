namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: SocialAccountInfoSchema

	/// <exclude/>
	public class SocialAccountInfoSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public SocialAccountInfoSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public SocialAccountInfoSchema(SocialAccountInfoSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("1f043ea0-5608-4609-9088-37f2047f71ad");
			Name = "SocialAccountInfo";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("4e5fe717-963e-416c-b3c1-b2bb720a6449");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,149,146,77,106,195,48,16,133,215,14,228,14,34,221,36,27,31,160,161,139,146,66,9,180,37,212,233,170,100,33,203,99,35,176,37,163,159,69,26,124,247,202,26,181,141,108,151,224,157,245,244,205,155,241,27,9,218,128,110,41,3,114,4,165,168,150,165,73,119,82,148,188,178,138,26,46,69,154,73,198,105,189,92,92,150,139,196,106,46,42,146,157,181,129,102,59,56,167,239,86,24,222,64,154,129,114,5,252,203,151,59,202,113,119,10,42,119,32,187,154,106,125,79,208,242,145,49,233,74,246,162,148,30,250,124,162,134,186,222,70,81,102,78,78,104,109,94,115,70,88,95,52,85,147,92,124,221,159,187,20,218,40,203,140,84,174,201,193,87,35,17,156,70,30,235,72,33,250,250,180,33,253,31,39,201,139,172,184,32,15,241,101,234,213,173,7,176,209,136,64,25,17,108,179,47,70,208,207,5,98,199,115,11,19,16,202,136,124,104,80,19,8,202,30,233,66,40,32,10,204,37,14,233,160,100,11,202,112,24,68,228,211,127,133,38,7,181,126,115,143,194,181,88,89,239,186,218,156,174,50,124,182,188,32,97,10,12,168,2,131,179,233,240,209,253,239,88,247,177,197,134,110,101,253,35,194,152,231,59,26,31,206,196,140,33,204,249,142,58,236,100,114,204,223,77,206,247,229,26,243,142,125,115,41,235,176,136,27,158,131,141,162,26,139,221,55,2,177,164,113,207,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("1f043ea0-5608-4609-9088-37f2047f71ad"));
		}

		#endregion

	}

	#endregion

}

