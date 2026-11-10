namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: AddressTypeConstsSchema

	/// <exclude/>
	public class AddressTypeConstsSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public AddressTypeConstsSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public AddressTypeConstsSchema(AddressTypeConstsSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("e7b21208-c42d-4094-802d-89e094c04cb6");
			Name = "AddressTypeConsts";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("45b7d114-643d-4217-a8b2-b9950d3eddb7");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,165,146,79,75,195,48,24,135,207,45,244,59,132,157,244,16,151,172,105,146,34,30,212,131,10,130,135,13,60,231,207,155,174,216,181,165,105,145,33,126,119,211,202,14,150,97,15,131,92,242,254,158,228,225,71,50,248,178,46,208,246,232,123,56,220,38,113,18,215,234,0,190,85,6,208,14,186,78,249,198,245,55,143,77,237,202,98,232,84,95,54,117,18,127,37,113,212,14,186,42,13,242,125,152,25,100,42,229,61,186,183,182,3,239,119,199,22,194,9,223,251,192,141,108,180,94,159,50,212,135,16,97,244,222,116,31,99,242,247,154,14,148,109,234,234,136,158,134,210,78,204,139,69,119,168,134,207,105,114,181,18,146,104,199,165,193,76,115,192,214,81,138,117,46,37,38,132,90,78,32,79,165,225,171,235,169,199,57,235,190,57,192,146,245,57,48,51,43,115,82,111,44,23,88,80,75,48,203,156,198,50,23,128,141,101,42,37,82,229,194,144,127,172,175,80,168,106,73,59,65,243,182,226,162,182,219,125,217,182,225,117,151,212,39,110,110,231,23,217,31,134,240,179,194,126,201,126,226,102,118,167,133,74,29,87,216,165,92,99,202,40,193,220,73,138,169,225,142,103,144,145,148,165,147,61,138,206,251,223,250,61,116,75,242,9,154,153,13,208,76,140,109,29,219,100,152,201,177,183,34,128,33,149,148,131,4,3,54,251,53,127,39,113,88,63,92,86,32,166,66,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("e7b21208-c42d-4094-802d-89e094c04cb6"));
		}

		#endregion

	}

	#endregion

}

