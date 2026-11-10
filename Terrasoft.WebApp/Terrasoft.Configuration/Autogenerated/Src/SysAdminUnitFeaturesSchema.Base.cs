namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: SysAdminUnitFeaturesSchema

	/// <exclude/>
	public class SysAdminUnitFeaturesSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public SysAdminUnitFeaturesSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public SysAdminUnitFeaturesSchema(SysAdminUnitFeaturesSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("d4b5d629-1e8b-41bd-915a-2e4ffb0cebcd");
			Name = "SysAdminUnitFeatures";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,109,143,193,74,67,49,16,69,215,121,240,254,97,168,27,221,244,3,90,92,72,85,232,66,16,172,31,48,77,230,165,129,52,9,153,4,41,165,255,238,228,229,233,66,132,132,192,157,115,239,220,4,60,19,39,212,4,7,202,25,57,78,101,189,139,97,114,182,102,44,46,134,113,184,142,131,170,236,130,133,93,166,166,173,95,229,169,153,14,209,90,47,250,118,28,4,73,245,232,157,6,237,145,25,62,46,252,100,206,46,124,6,87,22,154,133,105,81,127,192,83,252,146,125,5,117,217,135,95,11,108,96,113,189,81,65,131,5,155,241,58,239,81,234,46,147,149,102,32,62,46,185,234,18,51,111,224,125,142,93,144,101,199,255,233,247,15,48,23,81,106,207,47,1,143,158,12,60,130,36,209,182,203,207,196,58,187,212,190,47,131,85,103,24,140,227,228,241,2,113,2,221,67,129,201,147,158,57,57,229,68,80,153,50,36,180,180,234,89,183,159,206,20,76,175,221,5,209,219,189,193,56,124,3,160,178,171,191,131,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("d4b5d629-1e8b-41bd-915a-2e4ffb0cebcd"));
		}

		#endregion

	}

	#endregion

}

