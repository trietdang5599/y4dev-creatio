namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: ISearchDuplicatesActionExecutorSchema

	/// <exclude/>
	public class ISearchDuplicatesActionExecutorSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ISearchDuplicatesActionExecutorSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ISearchDuplicatesActionExecutorSchema(ISearchDuplicatesActionExecutorSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("3b0287fd-e228-4668-ae2a-c035310e2343");
			Name = "ISearchDuplicatesActionExecutor";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("4c53ad23-c903-414d-89cd-b08703861304");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,133,144,205,106,195,48,16,132,207,14,228,29,22,122,105,46,246,61,45,129,18,135,144,67,160,144,190,128,42,175,29,129,181,50,187,18,52,132,188,123,21,41,127,46,133,28,119,247,219,153,97,72,89,148,65,105,132,47,100,86,226,90,95,46,29,181,166,11,172,188,113,84,214,216,132,161,55,58,77,211,201,113,58,41,130,24,234,96,119,16,143,246,237,207,28,191,251,30,245,25,150,114,141,132,108,244,157,121,52,177,214,81,188,196,219,11,99,23,121,216,144,71,110,99,152,57,108,118,168,88,239,235,139,53,202,71,146,92,253,160,14,222,113,122,171,170,10,222,37,88,171,248,176,184,204,163,180,96,21,169,14,185,188,194,213,3,61,132,239,200,129,185,122,62,183,44,142,201,246,22,119,139,126,239,26,153,195,103,146,202,199,117,48,13,228,31,188,75,101,233,215,255,29,70,125,131,60,103,102,231,66,139,20,5,169,201,105,146,251,41,215,57,90,158,126,1,203,238,46,251,227,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("3b0287fd-e228-4668-ae2a-c035310e2343"));
		}

		#endregion

	}

	#endregion

}

