namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: IDuplicateDeletionManagerSchema

	/// <exclude/>
	public class IDuplicateDeletionManagerSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IDuplicateDeletionManagerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IDuplicateDeletionManagerSchema(IDuplicateDeletionManagerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("a1767778-661d-431a-a382-dbbf65e7e3a2");
			Name = "IDuplicateDeletionManager";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("3066e968-6ad0-45b5-bf2b-b9af469e0d31");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,125,81,75,75,195,64,16,62,55,144,255,48,196,139,130,36,247,54,230,98,68,114,168,72,213,147,120,24,179,147,184,208,221,141,251,40,132,210,255,238,118,147,198,54,136,183,121,125,15,190,145,40,200,116,88,19,188,146,214,104,84,99,211,123,37,27,222,58,141,150,43,153,150,196,92,183,229,117,232,226,104,31,71,11,103,184,108,225,165,55,150,196,42,142,252,228,74,83,235,215,80,73,75,186,241,116,75,168,202,17,70,37,109,233,8,94,163,196,150,116,0,100,89,6,185,113,66,160,238,139,177,159,0,192,70,68,122,186,204,206,78,59,247,233,207,128,159,164,254,83,90,236,131,218,228,111,77,246,75,49,179,132,231,64,50,44,231,94,194,96,67,66,237,200,128,166,90,105,102,160,209,74,120,95,103,89,0,67,139,233,68,144,205,25,242,14,53,10,144,62,225,187,132,164,229,182,127,242,117,82,60,132,58,44,210,60,11,87,127,131,156,228,223,142,54,193,65,197,76,82,188,133,193,232,9,208,63,172,191,96,216,41,206,32,132,64,215,198,234,227,151,126,133,111,225,209,113,246,254,1,51,218,155,213,152,17,73,54,196,20,250,195,240,216,139,225,225,7,175,45,95,67,47,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("a1767778-661d-431a-a382-dbbf65e7e3a2"));
		}

		#endregion

	}

	#endregion

}

