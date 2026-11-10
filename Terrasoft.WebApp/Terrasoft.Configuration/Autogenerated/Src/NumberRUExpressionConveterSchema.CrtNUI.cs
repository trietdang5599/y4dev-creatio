namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: NumberRUExpressionConveterSchema

	/// <exclude/>
	public class NumberRUExpressionConveterSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public NumberRUExpressionConveterSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public NumberRUExpressionConveterSchema(NumberRUExpressionConveterSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("d1467aa9-7149-4dab-9d97-0660599142d3");
			Name = "NumberRUExpressionConveter";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("14a29563-3c13-443c-a7aa-8d0c90d831c2");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,117,143,63,11,194,64,12,197,103,11,253,14,161,147,130,28,56,137,58,170,171,130,127,38,113,184,214,180,30,180,119,37,201,137,162,253,238,166,58,23,178,228,189,151,223,35,222,54,200,173,45,16,78,72,100,57,148,98,214,193,151,174,138,100,197,5,159,38,239,52,25,69,118,190,130,227,139,5,155,149,238,58,151,125,206,161,70,193,113,54,55,11,51,131,15,108,2,248,32,16,25,65,238,142,161,168,45,243,20,156,215,51,123,251,233,3,45,102,23,155,28,233,112,222,62,91,66,102,149,212,127,32,9,82,54,185,106,93,27,243,218,21,127,36,12,164,53,12,203,33,179,71,129,130,250,119,186,52,233,190,228,230,90,139,250,0,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("d1467aa9-7149-4dab-9d97-0660599142d3"));
		}

		#endregion

	}

	#endregion

}

