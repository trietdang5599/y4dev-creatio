namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: ReportGeneratorConfigurationSchema

	/// <exclude/>
	public class ReportGeneratorConfigurationSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ReportGeneratorConfigurationSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ReportGeneratorConfigurationSchema(ReportGeneratorConfigurationSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("bd36e74f-9114-4b76-b9c4-17f67f21a2f8");
			Name = "ReportGeneratorConfiguration";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("6ba26f98-9709-4408-98d0-761f0c4bf2aa");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,133,145,65,106,195,48,16,69,215,9,228,14,3,217,150,28,160,41,221,164,37,100,103,146,244,0,19,121,226,170,200,146,152,25,47,140,233,221,59,150,77,161,105,105,54,130,249,122,250,95,250,138,216,146,100,116,4,103,98,70,73,87,221,236,82,188,250,166,99,84,159,226,106,57,172,150,139,78,124,108,224,212,139,82,187,189,153,141,15,129,220,8,203,102,79,145,216,59,99,140,90,51,53,166,194,46,160,200,35,28,41,39,214,66,160,38,190,137,49,62,119,151,224,29,184,17,191,67,47,134,114,226,59,162,226,148,137,213,147,229,84,197,102,218,159,45,247,157,175,103,199,51,181,57,160,210,161,134,1,26,210,45,200,184,124,254,230,95,163,122,237,79,238,157,90,124,187,143,31,201,37,174,255,229,94,124,169,9,185,127,18,101,171,240,1,210,229,195,186,123,158,47,87,33,219,135,40,177,252,229,178,166,88,79,239,45,243,164,254,20,77,251,2,52,253,246,25,211,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("bd36e74f-9114-4b76-b9c4-17f67f21a2f8"));
		}

		#endregion

	}

	#endregion

}

