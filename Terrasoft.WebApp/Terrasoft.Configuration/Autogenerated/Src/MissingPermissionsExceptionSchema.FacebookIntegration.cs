namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: MissingPermissionsExceptionSchema

	/// <exclude/>
	public class MissingPermissionsExceptionSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public MissingPermissionsExceptionSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public MissingPermissionsExceptionSchema(MissingPermissionsExceptionSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("043db2ab-b0d2-4dfd-bff1-3c2b2eba32a5");
			Name = "MissingPermissionsException";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("34c57733-6570-402b-8e25-5c50c5be2b38");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,125,141,49,10,195,48,12,69,103,27,124,7,65,247,28,32,29,67,199,66,33,189,128,234,42,193,96,203,198,178,33,165,228,238,181,155,165,83,7,129,36,222,255,143,49,144,36,180,4,119,202,25,37,46,101,152,34,47,110,173,25,139,139,60,204,209,58,244,70,191,141,86,85,28,175,48,191,164,80,56,27,221,62,167,76,107,163,96,242,40,50,194,213,73,71,110,148,67,223,34,203,101,179,148,122,209,23,79,245,225,157,5,219,233,127,48,140,240,19,84,221,173,218,236,135,147,248,121,104,251,185,127,0,184,220,249,254,195,0,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("043db2ab-b0d2-4dfd-bff1-3c2b2eba32a5"));
		}

		#endregion

	}

	#endregion

}

