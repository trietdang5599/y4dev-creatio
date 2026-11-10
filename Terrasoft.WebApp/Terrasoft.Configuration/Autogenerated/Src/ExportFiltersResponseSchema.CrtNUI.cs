namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: ExportFiltersResponseSchema

	/// <exclude/>
	public class ExportFiltersResponseSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ExportFiltersResponseSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ExportFiltersResponseSchema(ExportFiltersResponseSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("83451a60-7d62-4ce4-941d-7458d5f504cd");
			Name = "ExportFiltersResponse";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("6ba26f98-9709-4408-98d0-761f0c4bf2aa");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,117,144,193,78,195,48,12,134,207,155,180,119,176,182,11,92,250,0,155,56,149,113,65,67,83,199,13,113,200,130,87,89,52,73,229,184,176,82,237,221,113,83,24,42,176,75,36,59,191,191,255,183,189,113,24,107,99,17,30,145,217,196,112,144,44,15,254,64,101,195,70,40,248,172,192,58,176,236,144,223,200,226,108,218,205,166,147,38,146,47,97,215,70,65,151,21,141,23,114,152,169,130,76,69,31,105,106,117,86,93,192,170,64,37,11,198,82,11,200,43,19,227,18,214,199,222,234,142,42,65,142,133,230,10,62,98,18,62,221,26,49,10,16,54,86,158,181,81,55,251,138,44,216,126,240,255,57,88,194,200,241,107,131,31,236,164,75,232,115,136,45,135,26,89,8,53,201,54,225,135,255,228,189,65,183,71,190,122,208,115,193,13,204,95,177,157,95,247,57,190,131,68,225,126,219,123,108,161,43,81,86,16,245,57,93,6,56,115,92,235,221,164,45,194,123,30,244,132,99,28,121,129,205,111,201,95,242,2,253,203,144,62,213,67,119,220,60,125,2,116,13,134,156,226,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("83451a60-7d62-4ce4-941d-7458d5f504cd"));
		}

		#endregion

	}

	#endregion

}

