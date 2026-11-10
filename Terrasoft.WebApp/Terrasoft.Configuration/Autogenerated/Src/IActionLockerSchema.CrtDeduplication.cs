namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: IActionLockerSchema

	/// <exclude/>
	public class IActionLockerSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IActionLockerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IActionLockerSchema(IActionLockerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("cb40de33-e3f6-43df-ac5e-ea49b9ed783e");
			Name = "IActionLocker";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("b5c46c08-cc76-4157-b24b-44267444e258");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,165,83,193,106,195,48,12,61,175,208,127,16,217,165,131,82,223,215,46,80,178,49,10,99,151,236,7,92,71,105,77,19,59,88,118,89,25,251,247,217,78,186,54,100,180,133,93,18,75,122,210,147,158,108,71,82,109,32,63,144,197,122,62,30,141,71,138,215,72,13,23,8,31,104,12,39,93,218,89,166,85,41,55,206,112,43,181,130,175,0,187,187,55,184,9,214,74,89,52,165,199,63,194,106,41,2,224,77,139,29,154,8,98,140,193,130,92,93,115,115,72,59,219,23,179,70,87,4,92,8,36,2,171,1,63,81,184,88,91,151,160,27,108,137,104,118,172,192,206,74,52,110,93,73,1,242,72,219,103,237,154,27,16,71,71,128,48,167,42,255,187,68,57,228,108,61,13,55,188,134,160,207,83,34,180,218,163,161,152,180,42,146,52,59,179,65,22,179,5,139,232,191,147,73,108,177,230,239,254,156,164,121,60,199,192,229,164,223,30,3,221,51,22,174,241,50,112,123,234,253,42,173,164,32,64,146,134,47,144,229,182,207,184,215,178,128,28,109,8,231,33,58,121,117,222,211,159,116,234,19,77,184,49,167,25,166,16,113,103,253,77,97,173,117,5,45,223,195,252,194,70,178,45,138,157,191,9,107,89,73,123,232,150,130,189,149,220,186,145,255,235,115,243,90,12,90,103,20,165,203,171,23,120,193,142,216,144,28,85,201,184,122,105,199,156,12,117,27,136,219,169,247,221,62,57,84,69,251,234,130,233,125,63,182,133,10,200,189,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("cb40de33-e3f6-43df-ac5e-ea49b9ed783e"));
		}

		#endregion

	}

	#endregion

}

