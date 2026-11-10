namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: IntegrationToolsSchema

	/// <exclude/>
	public class IntegrationToolsSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IntegrationToolsSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IntegrationToolsSchema(IntegrationToolsSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("519fed56-3e17-4fb7-a535-2ce6cf3931cb");
			Name = "IntegrationTools";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,125,82,95,111,211,48,16,127,118,165,126,7,211,7,148,74,40,253,0,99,72,172,27,3,241,130,88,217,235,228,164,151,206,146,107,135,187,243,32,66,249,238,56,177,147,174,105,224,37,137,239,238,247,47,62,79,218,30,228,67,67,12,199,124,7,191,249,106,185,240,125,109,7,136,138,92,197,249,214,33,140,229,52,186,117,198,64,201,218,89,202,239,193,2,234,242,31,200,252,206,178,102,13,20,250,203,69,237,11,163,75,89,26,69,36,191,88,134,3,170,142,101,231,156,33,249,103,185,16,53,234,23,197,32,17,212,222,89,211,200,31,4,184,117,214,70,57,249,228,207,206,129,85,108,54,23,160,48,80,233,131,127,77,254,84,94,212,58,112,39,25,77,77,132,38,199,206,155,56,0,199,15,129,192,30,103,221,136,54,60,218,51,230,105,208,108,194,125,78,178,142,18,19,106,121,45,103,180,54,155,153,88,97,212,194,175,153,127,144,77,56,215,87,23,86,137,177,187,195,123,224,207,204,245,119,248,233,129,248,155,66,117,4,6,164,135,190,157,221,234,30,175,176,121,31,1,239,18,240,131,124,158,131,165,72,47,10,195,21,145,55,28,44,70,64,126,119,172,185,233,179,232,74,102,179,104,249,38,4,242,198,36,150,158,134,138,148,50,58,186,241,218,236,1,179,62,145,16,69,72,43,53,125,210,72,157,20,163,135,216,168,194,70,170,242,89,102,29,71,61,40,72,109,255,235,59,122,75,124,99,77,156,4,42,101,40,41,136,86,66,56,140,67,84,228,31,235,26,236,62,91,189,93,173,135,153,248,58,245,70,43,249,87,104,134,169,87,208,235,213,101,241,132,121,84,198,67,26,104,211,122,14,127,185,200,119,46,221,218,122,92,207,97,125,227,216,105,11,218,191,57,111,125,153,16,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("519fed56-3e17-4fb7-a535-2ce6cf3931cb"));
		}

		#endregion

	}

	#endregion

}

