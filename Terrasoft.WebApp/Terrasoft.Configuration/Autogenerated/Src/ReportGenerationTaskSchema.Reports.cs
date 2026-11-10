namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: ReportGenerationTaskSchema

	/// <exclude/>
	public class ReportGenerationTaskSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ReportGenerationTaskSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ReportGenerationTaskSchema(ReportGenerationTaskSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("68544e27-681d-4cfb-9b4f-a820834261f0");
			Name = "ReportGenerationTask";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("f8ef1a6f-6619-48e3-9227-afa9b7782f83");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,149,80,61,111,131,48,16,157,65,226,63,156,148,165,149,170,176,151,182,75,6,212,165,138,18,182,170,131,3,7,178,10,54,58,219,67,138,242,223,123,24,39,33,81,218,170,19,232,249,125,220,123,74,116,104,122,81,34,20,72,36,140,174,237,114,165,85,45,27,71,194,74,173,146,120,72,226,200,25,169,26,216,238,141,197,46,75,98,70,22,132,13,63,195,170,21,198,60,194,6,123,77,54,71,133,147,172,16,230,211,243,222,183,72,82,180,242,75,236,90,252,96,160,119,187,86,150,80,142,186,31,100,209,224,165,231,12,173,140,37,87,90,77,28,181,246,6,19,35,152,221,178,185,187,135,241,242,232,240,55,51,119,178,2,203,127,175,213,3,112,210,216,149,60,241,141,231,9,62,81,225,9,240,28,152,153,7,55,39,26,63,156,53,217,44,121,129,170,154,138,92,182,90,147,238,145,172,196,171,78,105,154,194,147,113,93,39,104,255,114,4,114,180,6,52,129,25,191,2,154,169,0,134,72,232,73,151,200,123,142,167,129,172,80,89,89,75,164,229,201,47,157,27,134,45,124,237,208,106,96,75,155,141,246,25,28,254,127,71,117,60,68,113,249,223,83,195,190,179,225,110,100,95,109,54,161,151,32,99,223,179,253,108,181,189,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("68544e27-681d-4cfb-9b4f-a820834261f0"));
		}

		#endregion

	}

	#endregion

}

