namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: SysWorkspaceFeaturesSchema

	/// <exclude/>
	public class SysWorkspaceFeaturesSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public SysWorkspaceFeaturesSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public SysWorkspaceFeaturesSchema(SysWorkspaceFeaturesSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("f433f309-ae33-4c7e-b563-db6b55384ed9");
			Name = "SysWorkspaceFeatures";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,109,144,65,75,195,64,16,133,207,41,244,63,12,61,41,216,246,110,85,208,128,165,32,245,80,209,163,108,55,147,186,184,217,9,51,19,101,145,254,119,55,177,209,214,246,178,176,243,205,123,143,55,193,84,40,181,177,8,79,200,108,132,74,157,228,20,74,183,105,216,168,163,48,28,124,13,7,89,35,46,108,96,21,69,177,74,220,123,180,45,148,201,28,3,178,179,179,223,157,125,27,198,52,79,164,110,214,222,89,176,222,136,192,11,241,123,151,120,143,70,27,70,129,75,88,228,84,213,41,110,237,188,211,216,131,164,108,179,179,154,221,135,81,4,209,180,98,129,209,20,20,124,132,197,131,19,189,18,229,148,123,3,175,101,239,119,13,1,63,225,0,118,62,217,116,58,122,12,152,19,249,93,196,232,162,159,175,208,82,40,96,153,132,71,236,54,144,190,33,159,212,45,73,199,207,200,113,124,146,182,181,60,42,250,120,103,138,99,237,255,176,237,207,185,250,123,29,246,155,163,246,135,57,59,223,21,98,76,255,240,87,125,214,185,116,38,233,221,126,3,69,103,252,210,221,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("f433f309-ae33-4c7e-b563-db6b55384ed9"));
		}

		#endregion

	}

	#endregion

}

