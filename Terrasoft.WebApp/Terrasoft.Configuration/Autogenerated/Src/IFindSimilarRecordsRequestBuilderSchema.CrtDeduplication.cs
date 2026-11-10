namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: IFindSimilarRecordsRequestBuilderSchema

	/// <exclude/>
	public class IFindSimilarRecordsRequestBuilderSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IFindSimilarRecordsRequestBuilderSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IFindSimilarRecordsRequestBuilderSchema(IFindSimilarRecordsRequestBuilderSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("3f0cc1cb-f956-4f6e-ba88-abeb40ffc587");
			Name = "IFindSimilarRecordsRequestBuilder";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("4c53ad23-c903-414d-89cd-b08703861304");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,173,84,77,75,3,49,16,61,87,240,63,12,235,197,130,100,81,4,65,219,30,84,4,15,162,88,61,137,135,116,51,219,6,186,201,58,147,32,162,254,119,179,159,253,80,233,86,60,78,38,243,222,188,121,147,24,153,33,231,50,65,120,64,34,201,54,117,226,194,154,84,79,61,73,167,173,17,151,168,124,62,215,73,25,237,238,188,239,238,244,60,107,51,133,241,27,59,204,206,218,120,25,128,48,156,135,204,30,225,52,148,193,181,113,72,105,160,57,133,235,43,109,212,88,103,122,46,233,30,19,75,138,239,241,197,35,187,115,175,231,10,169,44,140,227,24,6,236,179,76,210,219,168,142,235,60,216,20,220,12,67,26,17,18,194,116,24,21,144,151,117,151,216,192,69,241,8,82,75,192,40,41,153,21,29,134,66,174,136,107,68,52,78,59,141,44,26,198,120,137,50,247,147,0,8,186,105,189,75,231,189,247,178,251,86,247,13,186,153,85,124,10,119,37,88,149,92,215,182,16,199,221,133,145,205,64,2,231,152,232,84,163,90,47,90,109,243,42,220,30,187,224,138,90,130,112,182,30,13,168,150,65,180,253,197,235,13,14,114,73,50,3,19,22,102,24,165,29,40,70,15,65,11,85,65,65,54,41,20,150,2,13,190,54,212,117,94,12,226,18,126,193,70,232,60,25,46,65,180,97,39,77,112,96,11,231,127,84,55,136,27,216,130,231,199,218,202,136,58,216,239,48,74,232,48,139,254,217,102,231,155,73,45,86,246,15,190,120,70,10,207,215,96,82,188,214,104,244,24,98,72,218,131,239,99,222,218,212,70,181,146,78,254,238,218,120,93,64,115,127,121,254,79,183,19,182,115,116,184,31,157,136,195,35,113,12,31,245,131,1,29,10,48,39,44,106,149,128,32,99,243,235,19,219,58,215,143,250,207,29,247,224,113,101,174,176,58,230,3,40,80,122,255,188,43,123,104,84,245,139,148,241,103,245,159,174,28,126,126,1,79,137,135,212,190,5,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("3f0cc1cb-f956-4f6e-ba88-abeb40ffc587"));
		}

		#endregion

	}

	#endregion

}

