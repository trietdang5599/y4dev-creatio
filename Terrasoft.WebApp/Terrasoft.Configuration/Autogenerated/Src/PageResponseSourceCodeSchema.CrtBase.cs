namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: PageResponseSourceCodeSchema

	/// <exclude/>
	public class PageResponseSourceCodeSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public PageResponseSourceCodeSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public PageResponseSourceCodeSchema(PageResponseSourceCodeSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("7282cd51-6666-41a7-9651-efa983edf92b");
			Name = "PageResponseSourceCode";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,133,82,77,111,226,48,16,61,23,137,255,96,229,210,176,128,123,173,20,113,96,89,118,169,212,109,81,49,234,74,85,15,198,158,128,37,127,68,246,164,106,84,241,223,107,135,210,178,145,80,79,182,103,222,204,188,247,198,117,80,118,75,86,77,64,48,69,191,87,159,60,41,131,87,236,198,102,78,107,16,168,156,13,244,15,88,240,74,116,33,143,176,137,161,126,207,114,3,161,226,2,8,3,239,121,112,37,198,114,91,170,109,237,121,234,208,239,189,245,123,23,85,189,209,74,144,128,49,38,136,208,60,4,18,97,8,22,89,83,1,137,144,4,235,224,2,250,118,36,122,224,166,197,77,72,54,93,46,111,111,102,83,118,115,127,119,117,63,99,115,54,94,177,135,249,244,111,86,156,109,240,207,232,99,53,175,170,152,111,153,93,189,88,73,93,5,246,213,232,210,121,195,49,140,93,89,42,1,210,137,218,68,106,52,84,113,178,12,59,0,52,154,182,39,53,92,217,97,44,105,231,237,207,104,91,242,45,60,68,99,162,131,231,196,189,56,37,201,163,87,8,249,2,177,250,68,251,143,203,136,108,26,132,167,103,34,57,242,209,81,74,169,52,220,69,207,63,3,226,203,197,65,59,229,226,216,128,78,165,92,68,250,224,243,236,195,235,241,47,21,115,65,37,249,217,40,186,129,200,197,46,73,45,218,206,105,155,63,38,107,246,123,124,125,121,153,145,225,201,182,105,34,185,70,165,21,54,116,237,245,146,227,110,110,133,147,144,31,57,13,98,65,150,13,138,255,89,156,174,121,114,74,183,248,150,237,45,216,45,238,34,209,100,1,61,188,40,115,171,86,121,62,232,78,250,169,44,247,205,193,210,84,209,205,207,173,204,15,177,253,97,117,251,244,131,223,1,103,132,143,124,29,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("7282cd51-6666-41a7-9651-efa983edf92b"));
		}

		#endregion

	}

	#endregion

}

