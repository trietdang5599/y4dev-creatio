namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: ServerInfoProviderSchema

	/// <exclude/>
	public class ServerInfoProviderSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ServerInfoProviderSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ServerInfoProviderSchema(ServerInfoProviderSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("2935beff-9218-4465-a00f-9cf4abce22f6");
			Name = "ServerInfoProvider";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,149,82,77,111,219,48,12,61,59,64,254,3,215,94,218,139,125,79,155,28,214,174,128,129,13,13,144,126,1,195,48,168,54,149,9,144,37,131,162,178,26,105,255,123,37,219,73,221,204,69,177,131,1,147,124,122,124,124,36,128,17,21,186,90,20,8,55,72,36,156,149,156,94,88,35,213,218,147,96,101,205,116,178,157,78,18,239,148,89,195,170,113,140,213,217,62,30,62,33,76,175,68,193,150,20,186,136,128,240,29,19,174,3,5,228,134,145,100,104,50,131,124,133,180,65,202,141,180,75,178,27,85,34,77,39,1,154,101,25,156,59,95,85,130,154,69,31,247,0,7,158,149,86,220,64,133,252,199,150,14,216,194,26,25,92,75,5,42,112,165,59,138,108,192,81,251,71,173,138,80,239,187,143,55,79,182,173,128,189,216,80,169,145,56,140,1,51,88,182,20,29,224,209,90,13,185,251,174,140,127,130,109,84,112,6,47,239,74,247,202,148,246,175,59,40,30,163,41,59,238,54,238,178,195,100,235,213,208,175,11,45,156,155,193,127,88,149,87,181,198,10,13,183,59,3,43,3,2,17,10,66,57,63,26,25,251,40,91,140,90,246,243,18,165,240,154,191,134,73,194,134,79,184,169,209,202,147,17,134,211,211,95,111,22,23,81,240,136,94,248,96,225,135,158,95,41,212,101,152,120,73,106,35,24,187,98,221,5,224,226,80,5,16,138,210,26,221,192,82,11,150,150,170,252,18,126,23,158,40,76,189,75,193,28,190,153,141,34,107,162,23,233,245,234,14,201,133,6,233,14,16,47,51,25,89,202,200,246,223,150,223,189,232,71,125,127,5,177,144,196,91,236,254,18,66,246,100,70,116,205,7,178,211,91,163,158,224,249,249,51,216,15,81,92,175,30,90,201,241,106,146,254,116,14,148,236,143,238,3,45,95,122,177,255,242,124,122,152,211,201,203,43,63,210,2,202,34,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("2935beff-9218-4465-a00f-9cf4abce22f6"));
		}

		#endregion

	}

	#endregion

}

