namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: EntityLiveEditingEventDataSchema

	/// <exclude/>
	public class EntityLiveEditingEventDataSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public EntityLiveEditingEventDataSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public EntityLiveEditingEventDataSchema(EntityLiveEditingEventDataSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("d8a6c3ad-94e8-4f7d-88ed-afb82bbd71ba");
			Name = "EntityLiveEditingEventData";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("02db2e09-2c0a-456c-bd76-55b83817125c");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,173,84,77,79,27,49,16,61,7,137,255,48,18,87,148,220,1,113,104,18,33,84,90,42,145,246,62,89,207,110,92,173,237,149,199,14,90,85,252,247,142,215,155,118,9,33,31,136,139,101,91,111,230,189,55,158,177,69,67,220,96,65,176,32,239,145,93,25,198,83,103,75,93,69,143,65,59,59,126,208,107,154,43,29,180,173,206,207,254,156,159,141,34,203,22,158,90,14,100,4,91,215,84,36,32,143,239,200,146,215,197,245,22,70,206,114,115,225,169,18,20,204,109,52,87,48,72,58,95,147,13,139,182,161,14,54,153,76,224,134,163,49,232,219,219,254,252,85,91,5,174,4,193,233,208,2,165,128,241,6,59,25,128,155,184,172,117,33,184,104,118,50,64,146,63,186,183,76,62,144,186,76,135,159,141,194,205,126,70,53,201,94,182,47,89,50,89,149,85,191,114,48,173,145,249,74,140,36,53,219,52,51,12,248,174,145,249,192,0,52,232,165,246,129,60,195,108,241,184,207,79,145,8,247,242,141,58,99,219,148,123,139,247,150,109,67,183,179,114,91,53,28,85,20,174,129,101,73,167,92,174,221,252,223,197,100,226,231,98,69,6,33,172,48,64,240,186,170,146,241,35,212,176,128,165,149,178,251,167,46,73,151,242,68,25,125,233,27,175,211,53,20,174,142,198,130,149,76,71,209,255,200,113,211,46,236,243,248,215,88,199,3,2,238,162,86,175,233,127,165,160,83,249,239,187,38,136,210,249,240,188,114,96,80,17,96,55,183,71,208,127,115,74,151,154,212,151,86,210,156,72,188,208,242,193,4,52,77,226,239,31,158,212,49,47,47,173,77,41,250,31,253,163,61,149,252,65,115,72,188,131,231,102,192,178,148,31,75,52,44,91,112,13,245,223,220,129,145,224,112,147,91,225,22,254,55,1,127,92,143,181,89,67,45,195,182,153,141,97,83,240,129,218,232,238,237,228,182,151,117,9,110,249,91,82,38,121,125,238,52,199,121,96,178,98,78,241,239,10,222,245,229,189,252,5,229,82,121,14,30,6,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("d8a6c3ad-94e8-4f7d-88ed-afb82bbd71ba"));
		}

		#endregion

	}

	#endregion

}

