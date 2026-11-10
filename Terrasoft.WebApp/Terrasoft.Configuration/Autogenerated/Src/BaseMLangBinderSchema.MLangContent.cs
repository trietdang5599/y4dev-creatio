namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: BaseMLangBinderSchema

	/// <exclude/>
	public class BaseMLangBinderSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public BaseMLangBinderSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public BaseMLangBinderSchema(BaseMLangBinderSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("4367ba23-e656-4615-8c59-3352d06c36d8");
			Name = "BaseMLangBinder";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("16e592d3-2033-426b-b620-6aa2b1f8eec0");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,133,82,75,107,2,49,16,62,43,248,31,6,123,177,32,187,119,21,161,90,11,82,165,5,133,158,179,187,227,54,144,199,146,204,74,69,252,239,157,205,198,86,165,210,83,200,247,202,228,75,140,208,232,43,145,35,108,209,57,225,237,142,146,185,53,59,89,214,78,144,180,166,215,61,246,186,157,218,75,83,94,73,28,38,47,34,39,235,36,250,241,31,138,15,204,88,165,181,53,204,50,255,224,176,228,56,152,43,225,253,8,102,194,227,122,37,76,57,147,166,64,23,36,105,154,194,196,215,90,11,119,152,198,125,163,3,93,43,146,138,197,181,40,17,242,38,1,178,224,75,206,182,244,194,87,213,153,146,121,212,221,28,4,35,120,170,170,197,30,13,173,164,39,52,232,26,5,187,142,97,134,159,57,215,72,159,182,224,73,223,67,90,75,198,100,187,231,107,202,2,97,111,101,1,111,134,19,55,36,28,13,206,209,220,32,225,23,65,222,174,143,208,116,216,233,100,124,82,114,33,63,211,227,192,134,102,218,78,15,73,51,237,100,25,114,12,189,74,26,66,184,196,47,48,29,252,107,219,48,132,67,88,104,33,213,182,82,151,232,116,208,111,97,212,149,18,132,253,251,97,171,216,251,146,144,127,132,117,67,120,198,157,224,23,185,37,56,51,50,49,237,20,27,69,83,180,165,134,125,139,94,131,167,111,52,164,234,86,135,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("4367ba23-e656-4615-8c59-3352d06c36d8"));
		}

		#endregion

	}

	#endregion

}

