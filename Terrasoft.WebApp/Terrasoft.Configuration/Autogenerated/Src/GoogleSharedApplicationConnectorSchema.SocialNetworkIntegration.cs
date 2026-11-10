namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: GoogleSharedApplicationConnectorSchema

	/// <exclude/>
	public class GoogleSharedApplicationConnectorSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public GoogleSharedApplicationConnectorSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public GoogleSharedApplicationConnectorSchema(GoogleSharedApplicationConnectorSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("052166b4-a428-48fe-9cd6-6ad37cc6b8ec");
			Name = "GoogleSharedApplicationConnector";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,133,145,193,106,195,48,12,134,207,9,228,29,4,187,180,151,228,222,102,133,173,135,178,195,96,172,123,1,213,81,82,67,98,7,217,238,24,165,239,62,215,78,178,46,43,236,104,233,255,126,253,150,20,118,100,122,20,4,31,196,140,70,215,54,223,106,85,203,198,49,90,169,85,190,215,66,98,155,165,231,44,77,156,145,170,185,81,238,180,110,90,218,19,159,136,61,165,72,88,205,235,44,245,210,7,166,198,227,32,90,52,102,5,131,242,136,76,213,83,223,183,82,4,247,9,10,76,239,14,190,17,145,127,9,88,193,51,154,249,112,239,114,14,94,83,128,87,178,71,93,249,8,111,193,61,54,139,162,128,210,184,174,67,254,218,140,133,119,178,142,149,1,161,149,111,17,131,84,181,230,46,140,5,60,104,103,161,9,161,192,132,84,128,63,177,242,201,181,152,219,150,28,125,55,219,59,190,121,89,140,237,171,126,216,64,252,251,168,127,241,114,216,145,189,125,47,150,112,61,72,146,156,144,135,84,179,77,192,35,40,250,132,187,39,90,44,215,1,142,163,239,243,249,159,137,129,185,12,219,37,85,197,5,135,119,172,254,46,94,190,1,202,180,60,157,92,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("052166b4-a428-48fe-9cd6-6ad37cc6b8ec"));
		}

		#endregion

	}

	#endregion

}

