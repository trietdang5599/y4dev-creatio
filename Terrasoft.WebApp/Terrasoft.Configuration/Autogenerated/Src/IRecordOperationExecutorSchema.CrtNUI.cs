namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: IRecordOperationExecutorSchema

	/// <exclude/>
	public class IRecordOperationExecutorSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IRecordOperationExecutorSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IRecordOperationExecutorSchema(IRecordOperationExecutorSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("ca04445c-be77-4cfb-a8da-af3e457c1459");
			Name = "IRecordOperationExecutor";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("db43ba5c-9334-4bce-a1f8-d5a6f72577ed");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,117,145,77,110,195,32,16,133,215,141,148,59,140,210,77,187,129,125,226,102,83,101,145,69,213,168,234,5,136,61,56,72,1,172,1,162,88,81,239,94,126,108,43,113,213,5,66,12,239,125,188,25,140,208,232,58,81,35,124,35,145,112,86,122,246,110,141,84,109,32,225,149,53,112,91,46,158,130,83,166,125,80,16,178,157,241,202,43,116,155,229,34,74,158,9,219,36,223,27,143,36,35,112,13,251,47,172,45,53,159,29,22,212,238,138,117,240,150,178,158,115,14,149,11,90,11,234,183,195,121,242,130,149,224,79,113,27,173,128,131,23,100,92,148,185,108,164,240,59,76,23,142,103,85,131,154,72,255,133,72,125,69,253,148,251,3,253,201,54,110,13,135,76,40,151,243,144,185,80,8,232,102,9,83,48,76,35,233,217,100,229,115,111,213,9,18,26,76,156,250,219,74,121,212,171,109,30,99,255,167,99,86,241,172,205,214,139,85,205,248,238,203,96,72,238,215,205,208,4,154,166,244,145,207,63,229,71,30,138,177,246,11,40,178,17,166,236,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("ca04445c-be77-4cfb-a8da-af3e457c1459"));
		}

		#endregion

	}

	#endregion

}

