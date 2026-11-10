namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: GlobalSearchFeaturesSchema

	/// <exclude/>
	public class GlobalSearchFeaturesSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public GlobalSearchFeaturesSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public GlobalSearchFeaturesSchema(GlobalSearchFeaturesSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("8ce6e5c0-35f8-4d5b-be9a-e16f527da2d1");
			Name = "GlobalSearchFeatures";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("ca3090cb-7cbd-4956-acde-76442c58fa1e");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,173,146,203,78,132,48,20,134,215,144,240,14,39,227,70,55,60,192,76,92,24,188,46,140,38,142,15,80,202,161,52,169,45,233,197,13,241,221,61,180,101,116,136,46,52,179,0,146,255,124,253,114,250,7,205,222,208,141,140,35,236,209,90,230,76,239,235,198,232,94,138,96,153,151,70,215,119,202,180,76,189,32,179,124,168,202,169,42,139,224,164,22,208,88,156,129,250,150,62,193,226,222,8,161,40,223,85,37,33,103,22,5,29,134,70,49,231,182,240,221,145,121,23,185,49,180,74,114,224,51,246,11,85,76,145,92,43,95,29,62,93,5,63,164,225,145,103,25,193,22,178,230,17,61,235,152,103,51,154,117,95,62,163,157,183,129,123,99,73,251,28,69,25,201,214,197,119,126,1,83,204,139,7,119,163,89,171,176,131,75,160,179,184,75,241,53,58,110,229,56,215,70,131,13,157,131,180,8,163,23,106,47,121,172,20,122,99,243,101,33,221,22,28,218,119,201,113,147,68,31,203,138,168,187,180,101,10,114,190,142,87,205,220,75,49,40,122,252,15,213,164,181,15,196,169,26,90,105,255,90,84,98,96,56,172,37,53,53,18,139,161,95,32,40,239,254,85,76,74,143,67,202,62,1,250,195,169,84,243,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("8ce6e5c0-35f8-4d5b-be9a-e16f527da2d1"));
		}

		#endregion

	}

	#endregion

}

