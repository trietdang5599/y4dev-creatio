namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: SearchDuplicatesActionConfigurationSchema

	/// <exclude/>
	public class SearchDuplicatesActionConfigurationSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public SearchDuplicatesActionConfigurationSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public SearchDuplicatesActionConfigurationSchema(SearchDuplicatesActionConfigurationSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("c9a4d829-6614-4e72-91b0-9433556c337c");
			Name = "SearchDuplicatesActionConfiguration";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("4c53ad23-c903-414d-89cd-b08703861304");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,149,82,205,138,194,48,16,62,43,248,14,3,222,219,187,138,176,232,34,194,30,196,238,11,100,147,105,13,52,73,201,36,11,165,248,238,166,105,237,182,34,187,238,165,240,205,124,127,19,170,153,66,170,24,71,248,68,107,25,153,220,37,59,163,115,89,120,203,156,52,58,217,163,240,85,41,121,68,139,121,179,152,207,60,73,93,64,86,147,67,181,126,192,65,93,150,200,91,50,37,7,212,104,37,255,225,140,67,148,50,250,249,198,98,114,178,134,35,81,216,7,198,210,98,17,252,96,87,50,162,21,100,200,44,191,236,251,86,72,111,49,109,210,58,202,210,52,133,13,121,165,152,173,183,61,14,190,223,82,32,1,69,19,16,131,11,176,104,3,124,114,253,221,38,29,249,84,254,43,104,128,183,109,94,43,51,107,98,161,225,144,208,162,66,235,36,134,107,78,209,173,219,63,54,142,131,119,237,164,171,225,40,146,129,50,110,115,175,115,240,82,244,220,163,128,6,10,116,235,112,101,248,92,255,54,39,126,65,197,64,135,191,225,229,148,44,106,254,145,245,33,201,129,201,193,250,18,233,247,152,150,186,105,179,182,112,110,217,81,250,36,103,137,90,116,111,26,113,55,157,14,175,55,248,234,101,142,227,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("c9a4d829-6614-4e72-91b0-9433556c337c"));
		}

		#endregion

	}

	#endregion

}

