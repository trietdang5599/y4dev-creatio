namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: EnrichmentFeaturesSchema

	/// <exclude/>
	public class EnrichmentFeaturesSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public EnrichmentFeaturesSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public EnrichmentFeaturesSchema(EnrichmentFeaturesSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("b04c4e9f-9c27-4baf-aabc-9d025acb482c");
			Name = "EnrichmentFeatures";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("523e180e-845f-4752-bb0d-120bebcd70d6");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,125,144,65,106,195,48,16,69,215,54,248,14,67,186,105,55,246,62,105,10,33,77,32,139,210,46,210,3,76,228,177,35,176,37,51,35,21,74,200,221,43,75,78,77,40,116,35,193,215,215,211,27,25,236,73,6,84,4,71,98,70,177,141,43,183,214,52,186,245,140,78,91,83,238,12,107,117,238,201,184,34,191,20,121,230,69,155,22,182,76,227,113,185,15,155,103,58,218,182,237,66,190,42,242,80,25,252,169,211,10,84,135,34,48,223,159,186,18,26,35,232,190,246,41,244,190,241,238,12,75,152,122,111,228,176,70,135,99,245,18,185,89,246,192,212,6,41,8,138,226,216,43,103,89,150,240,17,65,83,165,170,42,120,22,223,247,200,223,47,191,73,192,67,226,99,88,130,140,86,113,60,104,44,3,42,69,18,199,154,101,65,136,191,180,162,114,134,86,119,212,201,254,230,253,248,4,113,168,44,59,200,206,224,169,163,26,214,16,28,105,149,226,87,18,197,122,136,143,174,97,241,175,208,95,141,69,162,92,111,255,64,166,78,95,145,130,148,135,245,10,69,254,3,28,237,193,171,212,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("b04c4e9f-9c27-4baf-aabc-9d025acb482c"));
		}

		#endregion

	}

	#endregion

}

