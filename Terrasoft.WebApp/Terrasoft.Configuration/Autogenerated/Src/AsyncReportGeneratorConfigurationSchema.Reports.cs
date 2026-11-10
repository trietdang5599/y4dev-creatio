namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: AsyncReportGeneratorConfigurationSchema

	/// <exclude/>
	public class AsyncReportGeneratorConfigurationSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public AsyncReportGeneratorConfigurationSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public AsyncReportGeneratorConfigurationSchema(AsyncReportGeneratorConfigurationSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("320cda9d-04b0-419a-991e-dff36d9fb757");
			Name = "AsyncReportGeneratorConfiguration";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("f8ef1a6f-6619-48e3-9227-afa9b7782f83");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,133,144,65,111,194,48,12,133,207,32,241,31,44,118,167,119,216,144,166,30,184,236,128,208,248,1,33,115,74,180,212,174,236,84,26,170,248,239,75,211,118,218,216,196,142,207,241,139,223,247,200,212,168,141,177,8,175,40,98,148,93,92,149,76,206,87,173,152,232,153,22,243,110,49,159,61,8,86,73,64,25,140,234,26,158,245,66,246,128,13,75,220,33,97,218,100,185,113,37,83,81,20,240,168,109,93,27,185,108,71,157,76,130,138,20,21,12,224,71,68,210,254,95,118,16,207,152,182,17,193,10,186,167,229,189,223,151,197,22,28,11,152,62,198,89,152,184,85,144,108,128,106,112,164,173,213,20,161,248,150,161,105,79,193,91,176,61,199,255,24,176,134,251,148,179,46,147,126,245,179,23,110,80,162,199,84,210,62,159,26,222,111,171,200,131,29,166,22,18,134,98,110,195,154,16,78,198,190,195,241,240,146,241,136,163,119,222,14,73,82,67,150,235,38,224,164,254,228,253,13,60,17,107,20,79,21,148,227,145,163,4,232,146,57,110,250,243,27,184,142,28,72,111,3,74,214,195,244,231,240,250,9,98,240,48,32,51,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("320cda9d-04b0-419a-991e-dff36d9fb757"));
		}

		#endregion

	}

	#endregion

}

