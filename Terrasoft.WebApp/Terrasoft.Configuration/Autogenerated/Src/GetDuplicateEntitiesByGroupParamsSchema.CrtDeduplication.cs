namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: GetDuplicateEntitiesByGroupParamsSchema

	/// <exclude/>
	public class GetDuplicateEntitiesByGroupParamsSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public GetDuplicateEntitiesByGroupParamsSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public GetDuplicateEntitiesByGroupParamsSchema(GetDuplicateEntitiesByGroupParamsSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("87b86dad-c94c-4ef5-a14c-884f5a2ac989");
			Name = "GetDuplicateEntitiesByGroupParams";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("4c53ad23-c903-414d-89cd-b08703861304");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,141,146,193,78,195,48,12,134,207,155,180,119,176,182,11,92,218,251,6,28,104,71,197,1,152,24,183,105,135,172,117,171,72,77,82,57,201,161,84,123,119,146,116,155,40,12,81,169,138,244,255,182,63,59,110,36,19,168,27,150,35,124,32,17,211,170,52,81,162,100,201,43,75,204,112,37,163,20,11,219,212,60,15,106,54,237,102,211,137,213,92,86,176,109,181,65,177,250,161,163,119,43,13,23,24,109,145,56,171,249,103,168,115,89,46,111,65,88,57,1,73,205,180,94,66,134,38,61,161,113,237,138,12,71,253,216,102,164,108,179,97,196,132,14,69,238,139,227,24,238,180,21,130,81,251,112,210,33,3,13,146,6,161,10,172,161,84,244,63,49,58,211,226,111,184,93,202,12,115,151,54,196,114,179,119,70,99,15,142,1,185,31,115,204,148,147,46,76,122,185,223,134,84,131,228,19,151,176,9,172,62,30,26,189,160,56,32,221,188,186,233,225,30,230,232,145,173,87,243,91,223,251,220,92,27,242,75,93,95,194,208,65,133,102,5,218,31,199,191,129,185,170,173,144,250,26,109,183,135,164,143,142,133,169,178,116,41,67,22,151,6,222,130,63,126,36,247,38,126,67,18,111,143,101,84,126,225,207,197,144,146,89,94,64,214,71,198,130,74,94,251,87,115,117,219,79,125,236,26,106,129,178,232,127,111,208,189,59,52,143,95,200,58,0,96,77,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("87b86dad-c94c-4ef5-a14c-884f5a2ac989"));
		}

		#endregion

	}

	#endregion

}

