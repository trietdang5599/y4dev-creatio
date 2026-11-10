namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: ApplicationEntityQueryExecutorSchema

	/// <exclude/>
	public class ApplicationEntityQueryExecutorSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ApplicationEntityQueryExecutorSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ApplicationEntityQueryExecutorSchema(ApplicationEntityQueryExecutorSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("afadda41-08ff-4cac-864b-dc9f22b7ea37");
			Name = "ApplicationEntityQueryExecutor";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,173,82,203,110,194,48,16,60,131,196,63,172,232,37,72,40,185,3,69,2,74,43,14,84,125,158,170,30,76,178,9,150,192,142,252,168,138,80,255,189,107,59,136,4,1,189,244,16,41,94,207,140,199,51,6,193,182,168,75,150,34,188,161,82,76,203,220,196,51,41,114,94,88,197,12,151,162,211,222,119,218,45,171,185,40,26,16,133,195,11,243,120,82,150,27,158,122,182,142,39,43,109,20,75,253,226,34,99,46,12,55,28,47,3,238,73,65,170,128,32,204,141,194,130,4,97,182,97,90,15,160,118,160,87,218,61,91,84,187,249,55,166,150,88,158,145,36,9,140,180,221,110,153,218,141,171,181,71,1,86,48,200,233,67,79,7,157,174,113,203,52,200,28,216,81,59,62,232,36,53,161,143,59,204,153,221,152,41,23,25,25,143,204,174,68,153,71,139,51,70,122,125,120,164,184,225,22,186,215,29,119,123,159,164,92,218,21,97,32,117,119,252,227,138,48,128,41,211,88,3,189,250,27,52,64,163,64,12,59,206,250,222,39,115,12,147,26,50,202,186,160,41,211,39,127,122,64,84,78,174,123,136,222,53,42,210,16,232,203,6,219,88,246,97,65,244,37,19,172,64,229,66,173,126,123,78,191,53,128,21,217,143,78,41,53,24,184,87,216,250,169,28,163,200,130,233,230,13,150,104,214,50,115,230,149,52,36,130,89,216,63,45,63,12,184,88,163,226,38,147,41,36,199,105,189,219,86,121,208,1,249,69,15,146,103,8,20,145,123,159,47,168,169,244,122,162,161,218,241,153,110,187,195,255,183,17,206,172,210,105,54,11,15,104,26,219,81,207,249,106,214,19,215,41,21,110,120,54,221,144,121,115,72,179,95,75,192,127,123,58,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("afadda41-08ff-4cac-864b-dc9f22b7ea37"));
		}

		#endregion

	}

	#endregion

}

