namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: FeedReadingModeSchema

	/// <exclude/>
	public class FeedReadingModeSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public FeedReadingModeSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public FeedReadingModeSchema(FeedReadingModeSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("4107594a-c86e-44d6-bd5e-1ba25da2e163");
			Name = "FeedReadingMode";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("7668a8ba-5512-48e2-a8b3-83e08e0d46dc");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,83,200,75,204,77,45,46,72,76,78,85,8,73,45,42,74,44,206,79,43,209,115,206,207,75,203,76,47,45,74,44,201,204,207,211,115,13,246,227,229,170,230,229,226,44,40,77,202,201,76,86,72,205,43,205,85,112,75,77,77,9,74,77,76,201,204,75,247,205,79,73,5,202,130,84,112,58,230,228,40,216,42,24,232,128,216,174,21,37,169,69,121,137,32,1,67,176,128,103,30,92,192,8,200,175,229,229,2,34,0,100,205,142,180,129,0,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("4107594a-c86e-44d6-bd5e-1ba25da2e163"));
		}

		#endregion

	}

	#endregion

}

