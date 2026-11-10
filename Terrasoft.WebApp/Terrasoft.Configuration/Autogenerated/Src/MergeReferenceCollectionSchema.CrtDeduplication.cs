namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: MergeReferenceCollectionSchema

	/// <exclude/>
	public class MergeReferenceCollectionSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public MergeReferenceCollectionSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public MergeReferenceCollectionSchema(MergeReferenceCollectionSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("5a6b80e9-72e3-4e49-9d00-89ee49b01416");
			Name = "MergeReferenceCollection";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("4c53ad23-c903-414d-89cd-b08703861304");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,117,142,65,10,194,48,16,69,215,22,122,135,1,183,210,3,84,233,166,5,55,186,81,47,16,211,223,16,72,211,50,147,44,138,244,238,38,85,112,229,98,96,254,204,155,249,223,171,17,50,43,13,122,128,89,201,52,132,170,157,252,96,77,100,21,236,228,171,14,125,156,157,213,155,42,139,87,89,236,162,88,111,232,190,72,192,152,104,231,160,243,82,170,51,60,216,234,99,89,36,106,207,48,105,74,173,83,34,53,93,193,6,55,12,96,120,141,223,213,198,206,241,153,44,72,103,244,47,73,53,117,118,235,20,47,39,9,156,82,28,232,98,37,124,69,211,164,87,57,224,154,42,39,128,239,63,33,178,201,250,6,183,50,249,21,236,0,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("5a6b80e9-72e3-4e49-9d00-89ee49b01416"));
		}

		#endregion

	}

	#endregion

}

