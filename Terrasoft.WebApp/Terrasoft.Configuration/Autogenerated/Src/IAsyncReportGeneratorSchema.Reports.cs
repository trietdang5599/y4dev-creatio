namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: IAsyncReportGeneratorSchema

	/// <exclude/>
	public class IAsyncReportGeneratorSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IAsyncReportGeneratorSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IAsyncReportGeneratorSchema(IAsyncReportGeneratorSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("fe187b0f-b6a6-426e-8401-a8fc548ff6d0");
			Name = "IAsyncReportGenerator";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("f8ef1a6f-6619-48e3-9227-afa9b7782f83");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,141,84,77,79,194,64,16,61,75,226,127,152,192,69,19,67,239,138,36,198,3,225,96,66,0,127,192,210,78,97,35,221,109,102,103,53,13,241,191,59,221,165,216,98,37,220,186,243,241,230,205,123,187,53,170,64,87,170,20,97,141,68,202,217,156,199,175,214,228,122,235,73,177,182,230,118,112,184,29,220,120,167,205,22,86,149,99,44,158,78,231,118,11,161,196,37,51,34,220,74,27,204,13,35,229,2,252,8,243,37,150,150,120,134,6,5,211,210,139,171,76,26,138,147,36,129,137,243,69,161,168,154,30,207,11,178,159,58,67,7,170,46,219,145,53,214,187,125,5,20,64,96,27,81,234,241,185,55,105,77,81,237,53,87,227,6,46,105,225,149,126,179,215,41,232,134,11,204,195,236,51,62,82,120,8,116,78,228,223,144,119,54,115,143,176,8,0,49,121,78,54,4,86,172,136,133,235,57,61,1,97,229,62,198,167,198,228,188,115,82,42,82,5,24,49,224,121,232,29,146,200,110,48,44,52,156,174,119,8,117,12,210,83,16,216,54,232,120,156,54,158,36,1,164,31,51,109,219,24,33,59,161,171,0,9,217,147,113,177,155,80,74,179,176,24,216,252,239,202,210,222,212,215,0,29,153,37,189,174,251,130,96,125,153,187,247,142,6,208,149,228,1,250,156,235,220,212,238,118,247,79,23,92,155,225,209,51,231,247,220,187,74,92,114,83,73,149,43,49,213,185,150,197,229,90,26,174,63,233,90,95,107,148,40,253,63,19,130,7,124,100,114,89,254,95,182,234,15,204,151,230,29,176,20,197,233,132,121,139,192,60,27,38,211,54,249,203,54,45,227,28,209,168,63,115,215,235,107,28,212,168,62,66,147,197,183,20,206,223,241,215,208,9,74,236,7,139,130,138,81,125,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("fe187b0f-b6a6-426e-8401-a8fc548ff6d0"));
		}

		#endregion

	}

	#endregion

}

