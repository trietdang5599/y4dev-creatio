namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: ApplicationServiceQueryExecutorSchema

	/// <exclude/>
	public class ApplicationServiceQueryExecutorSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ApplicationServiceQueryExecutorSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ApplicationServiceQueryExecutorSchema(ApplicationServiceQueryExecutorSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("c0ae10d6-8124-4581-913a-ac8fe338fb3a");
			Name = "ApplicationServiceQueryExecutor";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,181,84,77,143,155,48,16,61,179,210,254,135,17,189,128,20,193,61,217,174,148,77,183,85,14,169,182,237,110,47,85,15,14,12,137,37,176,145,63,162,70,171,254,247,142,109,162,64,18,54,61,180,7,132,61,188,121,126,243,102,140,96,13,234,150,21,8,207,168,20,211,178,50,217,66,138,138,111,172,98,134,75,113,123,243,122,123,19,89,205,197,102,0,81,56,27,137,103,243,182,173,121,225,179,117,54,95,107,163,88,225,55,163,25,143,194,112,195,113,28,240,145,24,164,26,65,124,67,181,227,133,255,70,95,223,41,220,208,97,176,168,153,214,83,232,137,233,112,95,44,170,253,227,47,44,44,81,250,148,60,207,225,78,219,166,97,106,127,223,237,61,10,176,131,65,69,143,14,249,160,139,45,54,76,131,172,128,29,217,179,3,81,222,99,250,241,1,43,102,107,243,192,69,73,162,19,179,111,81,86,201,210,23,188,31,40,73,39,240,153,154,1,239,33,190,162,57,78,127,18,117,107,215,4,130,194,149,121,173,74,152,194,3,211,216,71,249,26,6,160,187,115,71,15,139,128,118,5,189,122,195,142,38,83,87,141,178,174,57,228,245,147,151,20,16,157,188,43,194,146,23,50,149,72,4,250,9,1,59,216,78,96,73,249,43,38,216,6,149,243,186,91,166,238,128,104,10,107,170,41,57,77,233,193,192,141,110,244,187,147,140,162,12,170,135,37,60,41,217,162,114,211,55,117,107,67,60,88,6,200,233,92,132,0,23,91,84,220,148,178,128,252,24,237,119,61,106,15,60,32,119,100,42,47,105,104,140,114,83,251,21,53,141,67,104,127,112,53,52,253,254,82,215,227,217,219,210,87,104,182,178,252,191,186,131,200,206,209,235,35,2,159,208,12,82,146,148,138,243,253,74,6,200,67,143,134,3,144,157,165,199,151,178,226,116,246,239,43,221,73,94,194,138,181,243,178,228,78,11,171,23,178,182,141,208,73,104,23,160,127,77,124,49,209,114,32,104,105,176,249,11,115,244,105,78,55,162,81,160,38,184,9,103,126,103,181,197,36,126,166,223,69,60,57,79,203,150,116,237,152,40,48,115,8,103,198,56,135,187,248,47,138,191,77,211,129,2,211,229,11,19,162,195,32,197,254,0,155,190,140,191,65,6,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("c0ae10d6-8124-4581-913a-ac8fe338fb3a"));
		}

		#endregion

	}

	#endregion

}

