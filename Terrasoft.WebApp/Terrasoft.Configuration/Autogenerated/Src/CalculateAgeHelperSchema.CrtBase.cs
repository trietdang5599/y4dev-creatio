namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: CalculateAgeHelperSchema

	/// <exclude/>
	public class CalculateAgeHelperSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public CalculateAgeHelperSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public CalculateAgeHelperSchema(CalculateAgeHelperSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("7036e87b-0dda-4a95-ba07-111b121eb842");
			Name = "CalculateAgeHelper";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("1fca9dd8-7af0-4ded-b1a3-aead7ca3b750");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,197,84,77,111,19,49,16,61,39,82,254,195,144,74,85,114,200,46,92,219,52,168,10,80,56,180,66,162,84,234,209,245,78,182,22,94,123,241,71,80,132,242,223,25,219,251,69,154,82,46,136,139,181,30,191,55,243,60,243,188,138,85,104,107,198,17,110,209,24,102,245,198,101,107,173,54,162,244,134,57,161,213,100,252,115,50,30,121,43,84,9,95,118,214,97,117,62,25,83,228,196,96,73,199,0,107,201,172,61,131,53,147,220,75,230,240,178,196,143,40,107,52,17,150,231,57,44,173,175,42,102,118,171,102,31,25,176,209,6,120,75,2,174,149,99,220,1,43,49,3,104,137,249,128,89,251,7,41,56,240,72,62,86,109,20,132,118,186,174,209,61,234,130,132,125,54,98,75,192,168,230,137,156,164,231,17,249,55,40,130,12,165,29,148,6,233,147,196,121,99,80,185,120,144,117,228,252,144,189,172,153,97,21,40,106,228,197,84,168,218,187,119,68,152,174,178,101,30,79,122,160,65,231,141,178,43,103,60,194,2,196,38,213,220,50,41,138,101,222,158,6,120,157,52,195,131,214,18,62,217,27,237,174,146,168,117,210,20,42,204,194,114,43,42,132,174,232,28,98,11,70,41,85,31,207,194,2,203,11,104,41,217,87,199,111,244,143,24,63,15,148,253,223,183,7,191,123,38,97,122,45,212,29,147,30,167,25,252,239,222,188,15,138,90,61,47,183,229,85,223,151,200,180,29,37,107,147,204,135,77,57,65,85,36,83,53,251,198,97,244,76,44,201,229,78,155,96,179,104,207,132,104,172,250,212,164,179,70,202,11,153,123,239,14,146,30,157,205,21,58,216,120,41,97,135,204,208,155,50,186,250,119,190,165,107,28,140,34,221,115,43,140,11,158,16,84,148,4,125,32,61,4,189,15,138,254,48,13,26,241,236,57,107,15,192,167,167,199,134,220,3,218,116,163,174,18,239,19,193,192,242,191,249,157,202,171,248,179,33,196,0,159,5,209,193,126,157,67,66,160,97,52,246,25,194,47,139,34,93,115,65,169,230,205,51,59,124,119,111,97,22,10,45,224,205,28,206,66,205,148,111,63,244,228,235,231,12,23,97,195,192,254,23,80,164,120,197,178,5,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("7036e87b-0dda-4a95-ba07-111b121eb842"));
		}

		#endregion

	}

	#endregion

}

