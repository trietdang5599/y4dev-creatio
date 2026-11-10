namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: SortedMessageColumnSchema

	/// <exclude/>
	public class SortedMessageColumnSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public SortedMessageColumnSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public SortedMessageColumnSchema(SortedMessageColumnSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("30b258b3-0c5b-490b-b91d-de724d484aa6");
			Name = "SortedMessageColumn";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("7668a8ba-5512-48e2-a8b3-83e08e0d46dc");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,83,200,75,204,77,45,46,72,76,78,85,8,73,45,42,74,44,206,79,43,209,115,206,207,75,203,76,47,45,74,44,201,204,207,211,115,13,246,227,229,170,230,229,226,44,40,77,202,201,76,86,72,205,43,205,85,8,206,47,42,73,77,241,77,45,46,78,76,79,117,206,207,41,205,205,3,170,0,169,226,116,46,74,77,4,202,249,231,41,216,42,24,232,128,68,124,18,139,75,28,147,65,134,129,5,13,129,98,181,188,92,64,4,0,216,113,210,70,126,0,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("30b258b3-0c5b-490b-b91d-de724d484aa6"));
		}

		#endregion

	}

	#endregion

}

