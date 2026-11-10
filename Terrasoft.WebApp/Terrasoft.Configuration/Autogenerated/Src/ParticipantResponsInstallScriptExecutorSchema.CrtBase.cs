namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: ParticipantResponsInstallScriptExecutorSchema

	/// <exclude/>
	public class ParticipantResponsInstallScriptExecutorSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ParticipantResponsInstallScriptExecutorSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ParticipantResponsInstallScriptExecutorSchema(ParticipantResponsInstallScriptExecutorSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("82641b93-7f38-4bdb-b4da-504eec4b810c");
			Name = "ParticipantResponsInstallScriptExecutor";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("95a133a1-cd5f-4df8-af8f-ad440775d7d1");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,141,147,207,110,194,48,12,198,207,69,226,29,162,238,210,73,91,31,0,180,195,96,127,84,105,76,211,10,187,135,96,32,82,234,84,137,211,141,33,222,125,105,10,8,88,59,237,130,26,219,223,207,246,39,131,188,0,91,114,1,108,10,198,112,171,151,148,142,53,46,229,202,25,78,82,99,191,183,237,247,34,103,37,174,88,190,177,4,69,250,172,244,156,43,249,29,242,195,99,246,20,80,20,93,25,3,93,241,244,17,73,146,4,235,11,124,201,149,129,149,231,179,177,226,214,14,216,27,55,36,133,44,57,210,187,159,88,163,205,208,18,87,42,23,70,150,244,248,5,194,145,54,65,42,145,192,32,87,76,212,218,255,74,217,128,101,29,204,104,27,184,199,153,38,64,107,189,168,167,114,115,37,69,147,44,195,55,171,180,92,176,70,10,201,204,130,241,118,34,136,218,43,230,206,158,215,172,182,54,138,194,222,155,92,172,161,224,19,142,124,5,134,65,75,236,238,66,159,182,8,135,39,68,86,254,90,28,60,164,5,157,62,3,53,154,209,230,213,95,68,18,255,246,12,226,155,203,249,155,102,114,201,146,150,78,233,19,144,88,63,25,93,60,140,146,123,47,168,60,222,139,45,217,180,133,158,225,131,118,115,202,22,215,7,91,162,138,155,182,21,234,1,253,26,8,159,236,69,139,112,136,115,5,57,25,127,82,201,126,166,160,5,28,59,69,206,28,170,247,175,12,151,58,137,1,111,103,121,124,40,239,104,147,230,64,123,213,7,87,14,146,35,242,134,197,83,111,164,255,11,84,240,23,37,16,180,114,5,54,128,184,198,122,39,59,26,254,73,226,21,28,246,219,213,191,187,253,81,2,46,154,187,12,239,38,122,30,244,177,31,204,121,157,229,233,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("82641b93-7f38-4bdb-b4da-504eec4b810c"));
		}

		#endregion

	}

	#endregion

}

