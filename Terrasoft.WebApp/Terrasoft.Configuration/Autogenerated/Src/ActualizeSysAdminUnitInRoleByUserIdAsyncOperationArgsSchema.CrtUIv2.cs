namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: ActualizeSysAdminUnitInRoleByUserIdAsyncOperationArgsSchema

	/// <exclude/>
	public class ActualizeSysAdminUnitInRoleByUserIdAsyncOperationArgsSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ActualizeSysAdminUnitInRoleByUserIdAsyncOperationArgsSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ActualizeSysAdminUnitInRoleByUserIdAsyncOperationArgsSchema(ActualizeSysAdminUnitInRoleByUserIdAsyncOperationArgsSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("6d43cba9-541f-42d7-a5df-e7f70b2a6b36");
			Name = "ActualizeSysAdminUnitInRoleByUserIdAsyncOperationArgs";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("0e576ff0-735c-4a01-b30c-0954381d02e8");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,157,147,219,106,195,48,12,134,175,91,232,59,136,238,166,131,145,220,247,4,89,41,163,87,43,219,250,0,110,162,100,134,196,46,146,189,145,149,189,251,108,167,9,233,232,14,244,38,96,73,254,245,253,146,163,68,133,124,16,41,194,11,18,9,214,185,137,86,90,229,178,176,36,140,212,106,52,60,142,134,3,203,82,21,240,92,179,193,106,214,157,251,87,8,163,181,50,210,72,228,63,11,162,132,107,149,62,30,176,105,225,47,184,43,55,132,133,59,193,170,20,204,83,72,82,99,69,41,63,208,117,77,178,74,170,157,146,102,163,158,116,137,247,245,142,145,54,217,185,76,66,5,7,161,56,142,97,206,182,170,4,213,203,211,57,201,50,233,139,68,9,130,10,91,161,50,12,185,166,223,218,128,240,250,160,219,6,81,171,29,247,196,15,118,95,202,20,82,15,125,29,51,76,33,12,166,94,191,57,170,75,158,6,199,224,171,155,208,150,60,147,159,228,20,182,161,127,147,255,110,60,4,54,153,83,149,185,68,2,157,131,121,69,232,195,129,117,84,96,52,136,22,29,200,209,134,217,68,157,102,223,112,235,248,193,202,12,26,79,112,132,2,205,12,216,127,62,79,172,168,178,6,247,156,221,61,46,54,100,83,163,233,95,244,142,81,6,46,6,133,239,32,221,109,161,220,115,117,94,230,140,8,41,97,190,24,95,53,248,113,188,188,236,48,68,14,130,68,5,202,253,31,139,49,134,253,140,151,205,158,162,121,28,146,63,212,134,45,122,249,229,70,229,110,176,123,109,77,247,232,32,164,249,76,226,52,208,171,60,76,26,36,104,8,239,96,221,118,135,142,227,214,61,176,189,96,156,180,53,189,140,255,183,7,151,55,214,68,207,131,46,246,5,121,163,111,48,49,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("6d43cba9-541f-42d7-a5df-e7f70b2a6b36"));
		}

		#endregion

	}

	#endregion

}

