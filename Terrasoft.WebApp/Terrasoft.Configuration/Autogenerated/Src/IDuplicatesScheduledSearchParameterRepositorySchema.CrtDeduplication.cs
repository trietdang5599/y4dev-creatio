namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: IDuplicatesScheduledSearchParameterRepositorySchema

	/// <exclude/>
	public class IDuplicatesScheduledSearchParameterRepositorySchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IDuplicatesScheduledSearchParameterRepositorySchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IDuplicatesScheduledSearchParameterRepositorySchema(IDuplicatesScheduledSearchParameterRepositorySchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("99c0874b-e6e1-4d26-9563-bae0f7a8c6d5");
			Name = "IDuplicatesScheduledSearchParameterRepository";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("4c53ad23-c903-414d-89cd-b08703861304");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,197,83,205,78,227,48,16,62,83,169,239,48,130,203,34,161,228,14,221,30,150,174,86,61,128,208,182,47,48,117,38,141,133,107,71,51,78,33,66,251,238,216,110,146,66,43,129,202,97,185,121,38,51,223,223,40,22,55,36,53,42,130,37,49,163,184,210,103,183,206,150,122,221,48,122,237,108,54,163,162,169,141,86,169,26,143,94,198,163,179,11,166,117,40,96,110,61,113,25,150,175,97,62,235,134,72,22,170,10,43,134,138,5,33,171,234,1,57,112,132,193,191,84,59,209,222,113,59,30,5,144,60,207,97,34,205,102,131,220,78,187,58,140,48,9,89,47,128,192,195,60,120,7,168,20,137,196,87,221,3,10,184,18,124,69,32,29,35,20,131,8,144,68,158,245,68,249,27,166,186,89,133,41,208,189,250,83,197,159,197,12,134,16,238,200,87,174,144,107,120,72,176,201,219,145,185,212,184,173,72,61,74,82,140,91,212,6,87,218,104,223,70,23,184,119,245,185,41,88,181,97,65,106,82,186,212,84,244,221,184,176,65,176,1,38,27,52,228,135,34,38,137,40,77,253,60,223,173,220,135,247,249,116,25,57,143,144,98,224,42,234,206,38,121,218,220,3,49,249,134,173,76,151,220,16,232,83,61,60,105,95,117,98,152,202,99,61,249,20,232,89,139,151,43,112,1,138,159,180,16,148,104,132,130,146,158,58,106,89,57,103,224,15,249,185,28,156,76,126,199,253,31,226,89,219,53,236,161,47,111,62,186,17,83,82,249,5,51,5,149,216,24,15,91,52,77,248,244,31,143,244,238,54,91,167,139,206,198,108,167,232,32,151,95,237,98,64,60,49,157,25,25,58,61,157,111,77,98,39,249,75,17,92,144,45,118,63,121,168,254,165,222,219,86,232,188,2,52,17,176,248,62,5,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("99c0874b-e6e1-4d26-9563-bae0f7a8c6d5"));
		}

		#endregion

	}

	#endregion

}

