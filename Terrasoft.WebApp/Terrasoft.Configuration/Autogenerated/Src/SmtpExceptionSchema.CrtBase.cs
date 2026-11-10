namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: SmtpExceptionSchema

	/// <exclude/>
	public class SmtpExceptionSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public SmtpExceptionSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public SmtpExceptionSchema(SmtpExceptionSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("f9b38078-c13e-40e2-9656-40242891b8a4");
			Name = "SmtpException";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,173,81,205,106,195,48,12,62,39,144,119,16,244,210,65,216,3,164,236,48,182,30,11,133,236,5,92,79,11,134,196,54,146,60,54,70,223,125,182,147,172,75,40,99,140,29,12,214,39,233,251,65,86,13,200,94,105,132,39,36,82,236,94,228,246,160,76,95,149,31,85,89,4,54,182,131,246,157,5,135,93,85,70,100,67,216,25,103,225,161,87,204,13,180,131,248,253,155,70,47,17,204,3,62,156,122,163,65,167,254,178,13,13,220,123,31,155,42,85,23,56,9,21,233,205,220,71,114,30,73,12,70,129,99,72,27,153,121,166,102,161,228,106,63,68,155,45,218,231,86,148,4,30,105,138,14,101,151,63,158,204,171,18,4,158,128,243,200,177,137,11,163,204,84,207,121,156,141,188,65,139,163,235,170,139,40,219,201,3,46,61,212,112,29,127,68,214,100,242,230,77,54,215,192,73,49,110,127,24,155,226,172,67,222,173,169,191,103,251,95,167,53,92,78,100,172,69,250,42,127,153,161,94,175,253,37,211,234,94,35,186,4,207,159,178,113,135,152,196,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("f9b38078-c13e-40e2-9656-40242891b8a4"));
		}

		#endregion

	}

	#endregion

}

