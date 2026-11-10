namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: EntityActivityOwnerAsyncExecutorSchema

	/// <exclude/>
	public class EntityActivityOwnerAsyncExecutorSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public EntityActivityOwnerAsyncExecutorSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public EntityActivityOwnerAsyncExecutorSchema(EntityActivityOwnerAsyncExecutorSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("ac041bc6-71d1-475e-a18c-3ab49a0d8e36");
			Name = "EntityActivityOwnerAsyncExecutor";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,173,84,75,107,227,48,16,62,167,208,255,48,116,47,54,20,251,222,166,129,16,66,201,161,237,66,187,123,87,229,177,45,106,75,65,143,100,77,201,127,95,105,100,199,113,119,125,88,216,147,153,199,247,152,145,100,201,90,52,123,198,17,222,80,107,102,84,105,179,141,146,165,168,156,102,86,40,121,125,245,121,125,181,112,70,200,10,94,59,99,177,189,63,199,151,144,182,85,242,239,21,141,115,249,108,43,173,176,2,77,182,54,157,228,47,123,140,154,230,159,1,217,78,90,212,165,159,35,96,61,250,155,198,202,23,96,211,48,99,238,128,112,221,154,91,113,8,95,2,31,37,106,234,205,243,28,150,198,181,45,211,221,170,143,9,7,71,193,107,192,95,200,157,69,3,106,144,131,82,105,224,53,147,85,176,168,2,17,168,18,144,68,128,69,149,224,18,6,246,252,130,126,239,222,27,193,129,147,194,212,24,121,34,119,91,18,245,50,119,176,139,61,219,131,231,159,142,237,201,62,105,130,243,184,79,104,107,85,248,129,191,147,72,44,126,157,175,79,32,2,215,88,62,220,204,11,100,209,6,222,228,35,78,163,231,249,48,171,237,159,107,121,239,192,106,38,77,137,58,44,102,92,196,197,118,226,182,172,2,91,35,72,60,78,242,217,50,31,232,207,122,151,171,27,118,119,80,162,128,222,64,242,195,160,246,87,86,34,39,19,110,18,222,194,236,112,107,93,25,96,186,114,173,47,153,20,194,61,95,44,14,76,143,19,81,203,3,36,145,131,78,103,134,40,61,19,221,143,52,212,79,208,157,44,149,39,10,243,78,78,220,239,134,88,169,30,13,44,122,68,225,251,39,70,178,161,112,27,251,158,241,24,177,115,157,27,213,184,86,254,100,141,243,87,241,17,237,91,183,199,130,194,229,163,19,197,42,153,130,136,44,98,158,253,95,33,237,101,94,154,98,78,198,151,254,167,82,228,122,229,181,191,2,33,63,51,214,216,64,176,83,92,248,236,106,147,233,133,72,179,77,120,184,152,124,57,157,148,104,78,253,115,66,89,196,23,69,113,204,78,147,167,223,12,107,93,108,58,5,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("ac041bc6-71d1-475e-a18c-3ab49a0d8e36"));
		}

		#endregion

	}

	#endregion

}

