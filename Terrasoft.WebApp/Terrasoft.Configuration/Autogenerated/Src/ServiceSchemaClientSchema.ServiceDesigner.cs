namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: ServiceSchemaClientSchema

	/// <exclude/>
	public class ServiceSchemaClientSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ServiceSchemaClientSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ServiceSchemaClientSchema(ServiceSchemaClientSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("3c738511-5733-4fc5-9114-2b98f15b5f10");
			Name = "ServiceSchemaClient";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("73951534-6fa4-4e40-b925-a1e2e4e079e3");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,149,147,193,78,195,48,12,134,207,157,180,119,136,198,165,149,166,62,192,96,28,214,1,218,1,132,24,156,16,135,44,115,187,160,54,45,78,58,81,161,189,59,73,211,110,13,237,52,113,154,106,255,254,109,127,241,4,205,64,22,148,1,121,5,68,42,243,88,133,81,46,98,158,148,72,21,207,69,184,6,220,115,6,107,182,131,140,142,71,63,227,145,87,74,46,18,178,174,164,130,76,171,211,20,152,145,202,240,1,4,32,103,215,71,77,215,20,225,92,60,188,167,76,229,200,65,14,41,154,1,76,78,103,175,16,18,221,139,172,132,2,140,245,224,51,178,114,70,140,82,14,66,213,218,162,220,164,156,17,222,74,207,40,61,179,147,215,230,108,244,69,83,209,27,1,185,251,6,86,42,240,141,196,123,147,128,154,142,176,251,146,210,249,156,146,90,35,21,154,249,165,117,123,210,124,221,68,6,106,151,111,59,241,37,175,203,41,86,55,86,50,37,249,230,83,123,222,146,130,162,214,233,233,101,96,200,28,44,1,16,91,11,65,127,116,136,68,41,149,114,70,206,193,120,95,66,76,203,84,45,184,216,234,38,190,170,10,200,99,127,8,73,16,124,156,232,49,99,59,228,74,206,145,183,60,155,242,11,88,47,16,29,130,217,231,248,15,140,164,158,205,219,83,36,25,21,52,1,36,243,58,226,249,253,139,115,111,255,209,234,3,119,70,125,243,202,201,251,147,161,170,73,253,128,182,177,236,230,87,66,42,42,244,109,206,219,129,140,99,27,93,84,102,65,191,179,127,223,167,121,141,249,176,111,24,33,80,5,206,43,248,238,10,125,203,23,248,42,65,118,60,109,93,227,213,100,253,211,11,52,14,110,117,216,252,62,31,233,107,191,211,83,216,18,4,85,162,248,211,166,61,14,215,207,54,57,12,254,15,198,163,195,47,144,26,70,78,202,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("3c738511-5733-4fc5-9114-2b98f15b5f10"));
		}

		#endregion

	}

	#endregion

}

