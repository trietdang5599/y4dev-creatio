namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: EntityOwnerEventAsyncOperationArgsSchema

	/// <exclude/>
	public class EntityOwnerEventAsyncOperationArgsSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public EntityOwnerEventAsyncOperationArgsSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public EntityOwnerEventAsyncOperationArgsSchema(EntityOwnerEventAsyncOperationArgsSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("6eeec1f5-f32a-4553-8347-9fd59c89add8");
			Name = "EntityOwnerEventAsyncOperationArgs";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,141,83,203,106,195,48,16,60,59,144,127,88,220,75,11,197,190,231,97,8,33,135,92,154,64,251,3,138,178,54,2,91,50,90,169,169,27,242,239,149,228,7,78,73,72,46,70,218,157,157,157,157,149,37,171,144,106,198,17,190,80,107,70,42,55,201,90,201,92,20,86,51,35,148,156,78,206,211,73,100,73,200,2,62,27,50,88,205,135,251,184,68,99,178,145,70,24,129,244,16,144,172,168,145,124,87,99,219,194,23,184,146,23,141,133,187,193,186,100,68,51,8,224,102,119,146,168,55,223,40,205,117,205,74,23,20,170,210,52,133,5,217,170,98,186,201,186,251,234,120,20,30,196,74,80,190,30,152,46,108,229,56,8,140,130,218,209,131,144,238,132,63,200,173,81,58,233,121,210,17,81,109,15,165,224,192,189,154,39,196,244,130,239,106,141,206,65,239,48,230,94,43,7,240,118,204,96,31,122,181,249,255,3,133,192,135,91,19,168,28,48,244,232,166,226,170,180,149,76,134,162,177,250,94,62,25,237,23,17,148,175,3,62,80,157,161,64,51,7,242,159,75,167,11,229,177,149,118,173,211,189,6,71,98,185,243,233,25,165,91,233,172,103,165,248,69,2,137,39,103,52,25,38,121,80,191,32,68,224,26,243,101,252,216,208,56,205,110,79,22,34,53,211,172,2,233,102,89,198,173,41,113,214,114,38,139,52,36,239,96,67,51,79,159,109,101,174,128,29,148,53,195,251,128,144,166,43,138,206,200,199,130,95,91,72,183,163,119,216,244,173,96,104,250,6,51,56,48,194,215,30,51,202,248,223,44,186,189,139,54,58,14,70,211,201,229,15,228,75,27,197,187,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("6eeec1f5-f32a-4553-8347-9fd59c89add8"));
		}

		#endregion

	}

	#endregion

}

