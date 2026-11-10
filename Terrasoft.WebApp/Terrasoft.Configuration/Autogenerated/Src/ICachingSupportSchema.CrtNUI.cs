namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: ICachingSupportSchema

	/// <exclude/>
	public class ICachingSupportSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ICachingSupportSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ICachingSupportSchema(ICachingSupportSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("c9e2bb74-352b-4e4f-8b51-1e046b4ca6de");
			Name = "ICachingSupport";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("c302261e-8f3d-4933-bbe5-b7b61ee66faa");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,93,204,61,10,128,48,12,134,225,89,193,59,4,220,61,128,171,147,179,94,32,214,180,6,52,45,177,157,196,187,251,135,131,142,33,207,247,2,8,46,180,6,52,4,61,169,226,234,109,172,26,47,150,93,82,140,236,165,106,208,76,44,174,75,33,120,141,176,21,121,145,103,165,146,59,159,208,74,36,181,231,188,134,246,11,111,22,210,48,179,1,126,213,31,93,181,108,127,138,36,227,19,189,206,253,0,224,165,18,220,154,0,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("c9e2bb74-352b-4e4f-8b51-1e046b4ca6de"));
		}

		#endregion

	}

	#endregion

}

