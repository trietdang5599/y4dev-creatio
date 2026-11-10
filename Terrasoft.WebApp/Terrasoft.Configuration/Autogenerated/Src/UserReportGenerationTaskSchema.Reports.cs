namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: UserReportGenerationTaskSchema

	/// <exclude/>
	public class UserReportGenerationTaskSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public UserReportGenerationTaskSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public UserReportGenerationTaskSchema(UserReportGenerationTaskSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("bd121194-abe4-482b-9424-0b625f81bd05");
			Name = "UserReportGenerationTask";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("f8ef1a6f-6619-48e3-9227-afa9b7782f83");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,141,81,177,110,194,48,16,157,131,196,63,156,196,2,18,34,59,105,187,48,68,44,21,42,48,85,29,76,114,73,173,38,118,116,119,30,40,234,191,215,118,82,10,21,72,93,108,233,249,189,123,239,157,141,106,145,59,85,32,236,144,72,177,173,100,177,178,166,210,181,35,37,218,154,241,232,52,30,37,142,181,169,97,123,100,193,54,27,143,60,50,33,172,253,51,172,26,197,188,132,61,35,189,96,103,73,114,52,216,75,119,138,63,34,247,117,139,164,85,163,63,213,161,193,55,15,116,238,208,232,2,138,160,189,43,133,37,220,158,152,156,226,212,223,8,214,176,144,43,196,146,79,178,137,179,123,198,224,115,207,97,58,131,80,46,249,250,31,251,102,72,241,199,28,114,167,75,112,94,184,46,103,97,84,178,132,131,98,156,134,215,69,224,173,203,121,164,46,250,33,207,126,237,131,121,178,143,50,120,28,244,217,69,162,9,154,178,47,121,221,120,67,182,67,18,141,127,250,166,105,10,15,236,218,86,209,241,233,7,200,81,24,44,1,135,91,25,208,37,26,209,149,70,2,91,69,83,144,119,37,160,141,150,248,75,8,20,67,66,125,174,218,103,63,91,164,151,30,195,218,226,10,134,46,39,47,149,44,56,102,112,187,74,143,94,131,30,251,6,127,43,108,246,143,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("bd121194-abe4-482b-9424-0b625f81bd05"));
		}

		#endregion

	}

	#endregion

}

