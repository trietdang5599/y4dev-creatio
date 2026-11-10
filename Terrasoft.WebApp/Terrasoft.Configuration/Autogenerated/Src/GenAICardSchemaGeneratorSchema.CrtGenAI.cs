namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: GenAICardSchemaGeneratorSchema

	/// <exclude/>
	public class GenAICardSchemaGeneratorSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public GenAICardSchemaGeneratorSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public GenAICardSchemaGeneratorSchema(GenAICardSchemaGeneratorSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("6cbc09fe-7a42-47c9-aeda-e4c59cd9ad7d");
			Name = "GenAICardSchemaGenerator";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("ecaffa2e-7d24-4fa3-bf71-1610bb70ac02");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,181,84,77,107,227,48,16,61,187,208,255,48,219,189,56,80,68,207,45,57,164,110,83,124,200,82,182,205,169,148,69,181,199,169,192,145,132,36,151,13,193,255,125,71,146,221,77,140,29,202,194,94,146,204,231,123,243,102,20,144,124,139,86,243,2,225,25,141,225,86,85,142,101,74,86,98,211,24,238,132,146,236,1,229,34,63,63,131,253,249,89,210,88,33,55,71,153,6,111,38,252,108,161,117,45,138,208,196,178,197,155,117,134,23,209,200,12,6,247,100,233,146,50,149,17,104,41,131,114,190,27,220,80,58,228,210,161,169,136,236,53,228,129,86,198,77,249,84,188,227,150,147,137,68,88,153,80,160,155,55,130,6,209,231,159,74,79,246,161,228,19,100,133,238,93,149,246,26,30,67,147,24,252,80,162,132,174,8,125,27,155,30,140,215,5,232,215,79,180,77,237,160,80,132,44,221,208,127,9,36,130,31,151,107,157,169,18,103,55,29,52,202,50,162,7,187,141,67,31,59,123,122,89,205,45,145,59,57,254,203,29,86,156,240,110,133,44,9,46,117,59,141,170,74,39,69,152,205,94,255,138,86,120,128,201,254,112,82,250,161,150,116,73,214,113,233,188,154,70,124,144,118,49,174,163,225,117,178,174,23,229,145,111,240,7,157,227,51,110,117,237,163,115,184,216,95,181,191,150,202,108,125,236,98,92,173,145,197,141,65,117,32,15,232,122,156,116,176,140,112,225,73,210,121,253,195,32,6,209,98,158,3,119,233,144,226,229,225,38,169,86,84,144,174,45,26,154,91,98,56,118,150,53,198,208,41,176,172,22,244,181,150,194,69,213,86,92,82,51,195,150,180,163,60,168,84,224,237,46,240,242,208,51,248,54,7,217,212,117,79,43,249,39,66,109,248,52,232,26,35,195,72,193,221,126,85,200,131,23,208,93,199,127,122,8,221,144,199,218,65,115,108,206,97,92,219,56,234,80,96,192,223,194,58,2,89,113,33,239,165,19,110,231,249,194,60,202,217,12,90,125,125,61,135,39,212,243,239,228,158,24,151,61,69,20,251,114,245,202,124,109,196,88,231,196,102,130,38,163,224,137,93,141,253,69,180,127,0,61,246,182,9,205,5,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("6cbc09fe-7a42-47c9-aeda-e4c59cd9ad7d"));
		}

		#endregion

	}

	#endregion

}

