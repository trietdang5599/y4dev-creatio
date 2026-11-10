namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: SchemaUIdConstsSchema

	/// <exclude/>
	public class SchemaUIdConstsSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public SchemaUIdConstsSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public SchemaUIdConstsSchema(SchemaUIdConstsSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("5dcd2477-a927-4f24-b4d0-93f8657dbaa4");
			Name = "SchemaUIdConsts";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("e98ccaae-0bf0-40d8-a40d-46418c204c90");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,141,206,65,111,131,32,24,6,224,115,77,252,15,164,187,180,7,166,86,81,72,179,3,34,44,59,152,44,235,186,59,83,218,145,40,54,162,105,154,165,255,125,180,221,97,158,58,14,16,94,94,242,61,163,213,102,15,54,39,59,168,118,237,123,190,103,100,171,236,65,86,10,188,171,190,151,182,219,13,143,172,51,59,189,31,123,57,232,206,248,222,183,239,205,14,227,103,163,43,96,7,151,85,160,106,164,181,96,83,125,169,86,110,95,106,215,183,131,117,173,75,115,22,4,224,225,239,186,221,0,156,164,193,53,91,76,138,203,203,239,233,160,94,201,186,51,205,9,60,143,186,6,31,71,7,167,117,171,205,214,232,1,60,1,163,142,215,151,197,188,64,69,24,9,86,192,180,192,12,38,249,138,64,194,17,134,140,209,88,8,158,174,226,52,153,47,215,255,241,221,206,123,22,39,41,187,122,108,148,232,154,90,245,19,12,198,130,98,130,17,68,121,94,192,132,100,8,18,148,71,16,69,140,114,22,133,4,103,244,30,38,127,45,221,48,109,20,96,111,229,61,76,41,181,41,149,25,39,10,196,145,32,148,112,72,105,230,20,161,219,8,143,56,140,216,42,97,177,32,57,34,191,138,179,239,157,127,0,205,28,21,2,25,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("5dcd2477-a927-4f24-b4d0-93f8657dbaa4"));
		}

		#endregion

	}

	#endregion

}

