namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: IIncludeEntitiesInFolderExecutorSchema

	/// <exclude/>
	public class IIncludeEntitiesInFolderExecutorSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IIncludeEntitiesInFolderExecutorSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IIncludeEntitiesInFolderExecutorSchema(IIncludeEntitiesInFolderExecutorSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("fc490832-b2c8-4995-9b6d-4c38bf371f49");
			Name = "IIncludeEntitiesInFolderExecutor";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("6ba26f98-9709-4408-98d0-761f0c4bf2aa");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,133,144,65,75,3,49,16,133,207,22,250,31,134,122,177,151,205,93,215,66,41,21,246,222,155,120,136,201,100,9,100,39,203,100,2,150,210,255,222,52,187,85,81,193,227,155,188,247,242,241,72,15,152,70,109,16,14,200,172,83,116,210,236,34,57,223,103,214,226,35,193,105,185,88,46,238,238,25,251,171,242,36,200,174,248,31,161,235,200,132,108,113,79,226,197,99,234,232,37,6,139,188,255,64,147,37,114,205,41,165,160,77,121,24,52,31,55,179,238,110,29,165,173,54,0,206,21,32,17,92,45,73,205,45,172,190,165,199,252,30,188,249,130,248,151,97,166,255,133,81,15,91,107,33,97,64,35,104,255,64,104,62,131,234,103,178,29,53,235,1,168,140,247,188,114,62,20,156,52,173,182,218,180,170,62,86,111,1,133,9,5,31,146,176,167,254,245,13,24,77,100,155,14,177,252,191,126,42,182,243,180,48,146,157,70,190,202,114,187,0,229,214,194,10,155,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("fc490832-b2c8-4995-9b6d-4c38bf371f49"));
		}

		#endregion

	}

	#endregion

}

