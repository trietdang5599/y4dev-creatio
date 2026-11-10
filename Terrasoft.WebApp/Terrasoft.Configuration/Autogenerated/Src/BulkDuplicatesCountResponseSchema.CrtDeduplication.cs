namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: BulkDuplicatesCountResponseSchema

	/// <exclude/>
	public class BulkDuplicatesCountResponseSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public BulkDuplicatesCountResponseSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public BulkDuplicatesCountResponseSchema(BulkDuplicatesCountResponseSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("1b8e96c8-ec0b-4b5d-87fb-133c37e8eac7");
			Name = "BulkDuplicatesCountResponse";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("3066e968-6ad0-45b5-bf2b-b9af469e0d31");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,157,145,77,79,195,48,12,134,207,155,212,255,96,109,23,184,180,119,90,118,96,147,122,26,76,219,110,136,67,154,122,37,144,38,85,62,144,198,180,255,142,211,106,27,148,10,164,157,18,59,239,107,251,137,21,171,209,54,140,35,108,209,24,102,245,206,197,115,173,118,162,242,134,57,161,85,52,62,68,227,145,183,66,85,176,217,91,135,117,218,139,73,47,37,242,32,182,113,142,10,141,224,127,106,158,138,55,186,46,117,137,242,151,110,237,149,19,53,198,27,170,194,164,248,108,103,32,21,233,166,6,43,10,96,46,153,181,119,240,224,229,251,194,55,82,112,230,208,230,70,251,102,77,40,212,0,91,249,243,130,57,70,40,206,48,238,94,40,209,248,130,196,192,131,189,231,158,107,106,123,113,143,2,242,185,223,202,232,6,141,19,72,77,87,109,141,182,254,40,73,18,200,172,175,107,102,246,179,83,34,71,103,65,27,176,225,116,175,8,202,215,5,26,208,59,168,194,136,54,62,91,147,190,55,251,96,210,227,108,59,228,202,146,238,49,104,91,178,37,6,197,205,35,237,15,238,97,210,201,90,142,201,109,160,61,225,74,77,159,155,95,94,225,0,21,186,52,12,152,194,241,58,146,242,252,113,32,212,149,92,131,53,254,163,44,127,110,108,128,180,183,211,33,218,41,170,178,91,45,69,93,238,123,42,26,31,191,0,16,247,61,82,21,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("1b8e96c8-ec0b-4b5d-87fb-133c37e8eac7"));
		}

		#endregion

	}

	#endregion

}

