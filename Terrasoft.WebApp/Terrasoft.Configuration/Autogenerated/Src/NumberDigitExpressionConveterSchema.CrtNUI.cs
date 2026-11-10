namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: NumberDigitExpressionConveterSchema

	/// <exclude/>
	public class NumberDigitExpressionConveterSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public NumberDigitExpressionConveterSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public NumberDigitExpressionConveterSchema(NumberDigitExpressionConveterSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("f5ab4edf-58fd-4173-bee4-f6489fa39530");
			Name = "NumberDigitExpressionConveter";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("14a29563-3c13-443c-a7aa-8d0c90d831c2");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,125,143,49,11,194,48,16,133,103,3,249,15,71,39,5,9,56,137,58,90,87,29,116,19,135,180,94,235,65,155,148,220,69,20,237,127,55,213,185,174,223,189,247,61,206,217,22,185,179,37,194,9,67,176,236,43,49,91,239,42,170,99,176,66,222,105,245,210,106,18,153,92,13,199,39,11,182,27,173,18,57,31,10,246,13,10,78,179,165,89,153,5,188,33,247,224,188,64,100,4,185,17,67,217,88,230,57,144,75,45,123,253,242,145,17,179,143,109,129,33,167,154,100,247,232,2,50,39,154,34,119,12,130,33,155,93,210,98,23,139,134,202,159,21,198,11,41,15,235,63,247,65,8,73,55,188,213,107,213,127,0,37,229,10,77,2,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("f5ab4edf-58fd-4173-bee4-f6489fa39530"));
		}

		#endregion

	}

	#endregion

}

