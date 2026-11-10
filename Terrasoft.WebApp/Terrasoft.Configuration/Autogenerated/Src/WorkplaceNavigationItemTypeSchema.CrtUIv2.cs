namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: WorkplaceNavigationItemTypeSchema

	/// <exclude/>
	public class WorkplaceNavigationItemTypeSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public WorkplaceNavigationItemTypeSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public WorkplaceNavigationItemTypeSchema(WorkplaceNavigationItemTypeSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("9b393990-221c-457a-9bfd-2fd41b58b907");
			Name = "WorkplaceNavigationItemType";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("5df7d265-a1f7-4784-81fd-c9d07be16831");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,203,75,204,77,45,46,72,76,78,85,8,73,45,42,74,44,206,79,43,209,115,206,207,75,203,76,47,45,74,44,201,204,207,211,243,75,44,203,76,7,51,125,83,243,74,121,185,170,121,185,120,185,56,149,139,82,211,129,66,10,174,121,165,185,86,10,225,249,69,217,5,57,64,83,16,138,61,75,82,115,67,42,11,82,193,170,11,74,147,114,50,147,21,128,250,115,241,171,229,4,154,206,201,25,156,156,145,154,155,168,3,98,250,230,167,148,230,128,36,106,33,214,166,230,165,64,108,6,113,107,1,224,185,19,47,190,0,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("9b393990-221c-457a-9bfd-2fd41b58b907"));
		}

		#endregion

	}

	#endregion

}

