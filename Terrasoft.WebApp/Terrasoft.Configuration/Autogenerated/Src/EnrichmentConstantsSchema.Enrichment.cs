namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: EnrichmentConstantsSchema

	/// <exclude/>
	public class EnrichmentConstantsSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public EnrichmentConstantsSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public EnrichmentConstantsSchema(EnrichmentConstantsSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("518edb9f-91be-476f-ad2f-ca02cfcabc1e");
			Name = "EnrichmentConstants";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("523e180e-845f-4752-bb0d-120bebcd70d6");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,109,143,193,14,130,48,12,134,207,144,240,14,13,222,121,0,140,7,67,60,107,130,119,51,103,129,37,208,145,181,59,25,222,221,193,80,52,241,212,180,223,223,175,41,169,1,121,84,26,225,138,206,41,182,141,20,149,165,198,180,222,41,49,150,138,19,57,163,187,1,73,178,244,153,165,89,154,236,28,182,129,64,213,43,230,18,182,64,88,100,81,36,188,196,70,127,239,141,134,48,145,80,244,28,254,159,77,162,118,243,190,81,9,151,197,17,241,234,211,51,13,86,103,168,253,242,157,143,94,186,90,219,17,225,0,185,103,188,225,135,229,251,245,0,210,35,222,88,250,41,126,243,51,156,94,148,69,66,175,17,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("518edb9f-91be-476f-ad2f-ca02cfcabc1e"));
		}

		#endregion

	}

	#endregion

}

