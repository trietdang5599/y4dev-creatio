namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: BulkDeduplicationInfoSchema

	/// <exclude/>
	public class BulkDeduplicationInfoSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public BulkDeduplicationInfoSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public BulkDeduplicationInfoSchema(BulkDeduplicationInfoSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("e14ddd74-99f1-4f32-b2b4-b4a8b303f9e2");
			Name = "BulkDeduplicationInfo";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("3066e968-6ad0-45b5-bf2b-b9af469e0d31");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,173,148,77,111,194,48,12,134,207,84,226,63,88,236,178,93,202,125,108,59,12,52,137,3,19,2,110,211,14,105,234,86,17,109,82,217,137,52,134,248,239,75,63,96,80,122,160,218,46,149,28,191,126,253,196,174,162,69,142,92,8,137,176,65,34,193,38,177,225,212,232,68,165,142,132,85,70,135,51,140,93,145,41,89,69,195,96,63,12,134,193,192,177,210,41,172,119,108,49,15,87,78,91,149,99,184,70,82,34,83,223,149,114,82,233,238,8,83,31,192,52,19,204,143,240,234,178,237,133,223,92,39,166,18,142,199,99,120,98,151,231,130,118,47,77,92,170,33,62,151,131,170,244,181,122,124,38,255,152,9,43,60,183,37,33,237,167,63,40,92,228,139,64,150,125,187,219,66,125,147,171,206,213,193,134,28,130,74,90,221,181,177,192,86,144,197,24,34,76,12,97,120,114,56,167,169,113,22,152,71,72,247,239,126,194,240,12,35,197,111,138,216,250,97,141,30,74,194,35,98,100,76,6,243,83,18,246,144,162,157,0,151,159,67,111,68,197,64,78,107,191,157,94,104,171,186,166,147,172,201,221,12,182,36,35,145,217,207,168,64,146,168,45,152,54,165,21,188,237,193,87,28,29,151,181,225,37,166,242,29,150,45,197,205,176,179,134,10,25,164,241,255,49,68,59,96,227,188,9,16,74,67,113,15,204,92,124,253,218,121,144,85,101,112,13,187,232,212,253,113,241,229,72,129,157,44,199,208,107,245,235,186,166,115,245,77,238,63,208,164,208,18,51,236,51,79,197,211,166,168,19,238,152,108,211,13,14,80,191,61,168,227,250,249,241,193,48,56,252,0,1,89,131,189,235,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("e14ddd74-99f1-4f32-b2b4-b4a8b303f9e2"));
		}

		#endregion

	}

	#endregion

}

