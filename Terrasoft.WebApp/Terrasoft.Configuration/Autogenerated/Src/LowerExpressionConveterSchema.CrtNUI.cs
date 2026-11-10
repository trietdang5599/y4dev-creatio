namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: LowerExpressionConveterSchema

	/// <exclude/>
	public class LowerExpressionConveterSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public LowerExpressionConveterSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public LowerExpressionConveterSchema(LowerExpressionConveterSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("85ba78c6-496b-4aee-a5ba-e9335cf632be");
			Name = "LowerExpressionConveter";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("14a29563-3c13-443c-a7aa-8d0c90d831c2");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,117,143,63,11,194,64,12,197,103,11,253,14,161,147,130,28,56,137,58,170,155,224,160,155,56,92,107,90,15,218,187,146,228,252,131,246,187,155,234,90,33,203,203,123,249,61,226,109,131,220,218,2,225,136,68,150,67,41,102,29,124,233,170,72,86,92,240,105,242,74,147,81,100,231,43,56,60,89,176,89,169,214,57,237,115,14,53,10,142,179,185,89,152,25,188,97,19,192,7,129,200,8,114,117,12,69,109,153,167,224,188,158,217,203,119,255,167,197,236,194,29,105,251,104,9,153,85,171,121,67,18,164,108,114,214,174,54,230,181,43,126,60,24,138,106,18,150,131,78,15,1,69,244,95,116,105,210,125,0,145,19,108,247,241,0,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("85ba78c6-496b-4aee-a5ba-e9335cf632be"));
		}

		#endregion

	}

	#endregion

}

