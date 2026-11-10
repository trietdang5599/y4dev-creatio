namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: IFullPipelineQueryBuilderSchema

	/// <exclude/>
	public class IFullPipelineQueryBuilderSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IFullPipelineQueryBuilderSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IFullPipelineQueryBuilderSchema(IFullPipelineQueryBuilderSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("72be6cd2-93c1-4725-9a00-7c556867169a");
			Name = "IFullPipelineQueryBuilder";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("eccc4091-3404-497f-94e5-8c10d0f3a0d7");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,125,82,203,78,195,48,16,60,83,169,255,176,10,23,144,80,124,111,211,28,90,10,234,1,84,212,254,128,155,108,90,75,126,132,181,141,20,85,252,59,142,221,148,82,16,135,68,217,217,153,217,201,218,154,43,180,45,175,16,182,72,196,173,105,92,190,48,186,17,123,79,220,9,163,199,163,227,120,116,227,173,208,123,216,116,214,161,10,125,41,177,234,155,54,127,70,141,36,170,233,153,179,48,132,249,227,60,0,1,186,37,220,7,26,172,180,67,106,194,148,9,172,158,188,148,107,209,162,20,26,223,60,82,55,247,66,214,72,81,192,24,131,194,122,165,56,117,229,169,94,147,249,16,53,90,80,232,14,166,6,103,224,189,215,193,46,9,161,49,225,9,174,208,158,108,243,193,137,93,88,181,126,39,69,5,98,136,242,95,146,155,99,76,115,206,255,18,39,219,9,172,163,73,106,94,103,141,64,180,176,224,14,152,66,230,103,38,187,166,22,45,39,174,64,135,19,152,101,85,220,185,205,202,109,80,158,138,188,96,145,242,183,194,86,7,84,252,53,124,103,101,255,6,211,196,177,9,255,173,37,116,158,180,45,11,139,97,2,97,51,203,54,216,159,99,198,202,130,13,221,158,158,224,244,43,113,47,119,171,165,246,10,137,239,36,22,151,91,91,106,39,92,151,238,75,57,196,126,0,235,168,191,10,223,9,239,167,167,125,162,174,211,74,99,253,153,46,201,15,48,96,95,244,136,120,76,148,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("72be6cd2-93c1-4725-9a00-7c556867169a"));
		}

		#endregion

	}

	#endregion

}

