namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: ISynchronizationControllerSchema

	/// <exclude/>
	public class ISynchronizationControllerSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ISynchronizationControllerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ISynchronizationControllerSchema(ISynchronizationControllerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("1d2bb6b3-89a8-4d3d-b77f-083b86d861c6");
			Name = "ISynchronizationController";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("77ff850a-3558-415d-9b34-1a36190e74f6");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,117,144,193,110,194,64,12,68,207,137,148,127,176,212,59,185,151,170,23,196,1,174,244,7,156,141,147,172,180,235,141,108,175,68,64,252,123,151,80,36,56,244,56,178,253,102,198,140,145,116,70,71,240,67,34,168,105,176,205,46,241,224,199,44,104,62,113,83,95,155,186,169,171,172,158,199,183,37,161,237,58,249,16,26,203,34,28,216,72,134,130,250,132,195,105,97,55,73,98,127,89,33,133,104,146,66,32,89,47,218,182,133,47,205,49,162,44,223,127,122,23,80,149,20,108,66,3,31,231,64,145,216,238,218,43,248,39,26,28,50,116,4,74,129,156,81,15,168,160,239,94,48,33,247,197,73,55,79,167,246,197,106,206,93,240,238,5,248,127,84,40,61,142,169,219,159,201,101,75,37,121,85,62,81,221,30,157,137,251,71,237,187,188,253,2,87,95,183,162,70,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("1d2bb6b3-89a8-4d3d-b77f-083b86d861c6"));
		}

		#endregion

	}

	#endregion

}

