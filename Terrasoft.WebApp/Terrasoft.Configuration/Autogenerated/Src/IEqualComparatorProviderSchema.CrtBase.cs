namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: IEqualComparatorProviderSchema

	/// <exclude/>
	public class IEqualComparatorProviderSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IEqualComparatorProviderSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IEqualComparatorProviderSchema(IEqualComparatorProviderSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("16767ff9-f891-4a8b-8bb0-10d7f21c7208");
			Name = "IEqualComparatorProvider";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,141,143,193,10,130,96,16,132,207,10,190,195,15,93,234,226,3,212,209,36,188,5,246,2,127,186,218,130,238,234,186,127,96,209,187,247,167,68,32,20,29,103,152,249,134,33,219,194,208,217,2,204,9,68,236,192,149,198,9,83,133,181,19,171,200,20,167,164,168,99,62,82,113,17,38,188,77,110,20,222,163,48,10,131,149,64,237,165,201,72,65,42,143,217,154,44,237,157,109,18,110,59,235,9,44,71,225,43,150,32,83,190,115,231,6,11,131,239,248,143,116,48,47,4,139,229,132,27,215,210,167,96,14,160,185,10,82,189,32,173,55,187,191,1,123,171,240,165,254,152,127,2,149,243,213,151,244,222,19,207,226,238,218,56,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("16767ff9-f891-4a8b-8bb0-10d7f21c7208"));
		}

		#endregion

	}

	#endregion

}

