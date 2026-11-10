namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: BulkDuplicatesGroupResponseSchema

	/// <exclude/>
	public class BulkDuplicatesGroupResponseSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public BulkDuplicatesGroupResponseSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public BulkDuplicatesGroupResponseSchema(BulkDuplicatesGroupResponseSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("eb44fa4e-3083-461b-a753-81b61ff52720");
			Name = "BulkDuplicatesGroupResponse";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("3066e968-6ad0-45b5-bf2b-b9af469e0d31");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,157,84,201,110,194,48,20,60,131,196,63,60,193,165,149,42,114,7,202,161,161,66,28,104,37,210,91,213,131,73,30,145,91,199,70,94,90,81,196,191,247,197,17,75,194,22,122,113,98,103,102,52,30,123,34,89,134,102,201,98,132,55,212,154,25,181,176,221,80,201,5,79,157,102,150,43,217,106,174,91,205,134,51,92,166,16,173,140,197,172,95,153,19,94,8,140,115,176,233,142,81,162,230,241,69,204,235,252,147,94,167,42,65,113,132,155,57,105,121,134,221,136,84,152,224,191,222,3,161,8,215,209,152,210,4,66,193,140,233,193,147,19,95,207,4,182,171,80,112,148,118,228,150,130,199,204,162,25,107,229,150,158,242,62,98,150,209,118,172,102,177,253,160,133,165,155,19,8,226,92,226,154,2,244,224,162,126,35,15,166,17,4,1,12,140,203,50,166,87,195,237,194,36,33,2,95,112,212,160,22,144,230,248,238,14,28,28,162,189,195,41,102,115,212,119,47,116,22,240,8,109,143,159,36,237,251,220,241,214,178,196,31,24,59,158,192,184,248,10,107,72,209,246,193,228,195,198,239,182,142,23,163,156,166,195,70,191,177,27,60,21,188,34,143,170,53,111,43,42,1,106,187,11,21,29,120,110,44,217,197,11,92,222,28,217,158,237,5,203,254,132,162,251,53,42,35,106,27,140,14,3,219,62,190,153,112,104,254,25,95,217,220,136,251,86,16,121,96,172,166,38,60,128,242,253,24,150,34,61,225,183,24,59,40,147,162,24,231,74,82,185,184,51,234,59,181,16,107,22,228,12,155,202,113,86,247,66,49,246,191,129,93,49,110,137,177,32,28,23,99,47,59,184,82,234,97,209,31,83,205,243,100,154,155,63,7,78,143,19,30,5,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("eb44fa4e-3083-461b-a753-81b61ff52720"));
		}

		#endregion

	}

	#endregion

}

