namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: EntityProcessElementDataOwnerAsyncExecutorSchema

	/// <exclude/>
	public class EntityProcessElementDataOwnerAsyncExecutorSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public EntityProcessElementDataOwnerAsyncExecutorSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public EntityProcessElementDataOwnerAsyncExecutorSchema(EntityProcessElementDataOwnerAsyncExecutorSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("232b7840-ec6e-489d-a023-bb9b694170a3");
			Name = "EntityProcessElementDataOwnerAsyncExecutor";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,173,84,75,107,220,48,16,62,111,32,255,97,72,47,54,4,249,158,108,22,194,214,132,61,52,9,52,237,93,145,199,94,81,91,50,122,236,214,132,253,239,149,71,246,238,58,137,11,133,30,71,51,223,67,159,30,138,55,104,91,46,16,94,208,24,110,117,233,216,90,171,82,86,222,112,39,181,186,188,120,187,188,88,120,43,85,5,223,59,235,176,185,61,214,231,144,166,209,234,243,142,193,185,117,150,43,39,157,68,203,238,109,167,196,83,139,81,211,254,51,128,109,148,67,83,134,125,244,216,128,254,98,176,10,13,88,215,220,218,27,32,92,247,108,116,24,176,121,141,13,42,247,149,59,30,105,246,10,13,161,178,44,131,165,245,77,195,77,183,26,106,98,128,189,20,91,192,223,40,188,67,11,122,20,134,82,27,16,91,174,170,222,172,238,137,64,151,128,36,7,109,212,3,140,130,22,138,32,201,96,20,202,206,148,90,255,90,75,1,130,196,230,220,146,81,178,156,147,147,160,125,3,155,56,157,239,194,208,52,149,64,251,70,219,58,166,241,13,221,86,23,33,143,103,146,139,205,247,155,30,22,16,65,24,44,239,174,230,5,88,180,129,87,217,9,103,48,240,252,178,171,252,99,86,175,221,41,170,79,163,137,1,178,101,54,146,28,89,207,163,26,179,218,105,89,192,32,147,252,176,104,194,189,85,40,72,202,79,202,107,152,221,194,189,169,44,112,83,121,114,145,66,127,217,23,139,29,55,39,223,52,114,7,73,228,160,51,152,33,74,143,68,183,39,154,126,126,56,202,141,42,117,96,82,184,239,159,210,204,249,210,80,180,177,136,146,155,34,128,38,118,216,216,184,142,115,143,184,143,216,185,201,181,174,125,163,126,242,218,135,183,243,128,238,165,107,177,160,114,249,224,101,177,74,166,32,34,139,152,199,240,65,164,131,204,83,93,204,201,132,214,127,84,58,196,252,254,30,84,50,61,228,148,173,251,203,133,201,251,196,83,34,59,12,47,1,85,17,31,3,213,113,117,186,120,248,3,65,102,59,131,20,5,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("232b7840-ec6e-489d-a023-bb9b694170a3"));
		}

		#endregion

	}

	#endregion

}

