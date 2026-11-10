namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: DummyForModulesLoadSchema

	/// <exclude/>
	public class DummyForModulesLoadSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public DummyForModulesLoadSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public DummyForModulesLoadSchema(DummyForModulesLoadSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("be6b597e-2758-49e0-b6d7-c2a371cdad22");
			Name = "DummyForModulesLoad";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("bb927652-946c-46e9-92ec-d4e247692a1b");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,83,208,215,119,73,205,73,45,73,85,72,76,43,73,45,82,112,14,242,213,53,177,52,52,176,84,72,201,207,75,5,0,238,97,212,42,30,0,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("be6b597e-2758-49e0-b6d7-c2a371cdad22"));
		}

		#endregion

	}

	#endregion

}

