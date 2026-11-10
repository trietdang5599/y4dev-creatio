namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: DateTimeExpressionConveterSchema

	/// <exclude/>
	public class DateTimeExpressionConveterSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public DateTimeExpressionConveterSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public DateTimeExpressionConveterSchema(DateTimeExpressionConveterSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("35da4edf-d91a-423a-87ed-e938ea1f0686");
			Name = "DateTimeExpressionConveter";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("14a29563-3c13-443c-a7aa-8d0c90d831c2");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,117,143,49,11,194,64,12,133,103,11,253,15,161,147,130,28,56,137,58,218,206,14,118,19,135,107,77,107,160,189,43,151,156,40,218,255,110,170,115,33,75,222,123,249,30,113,182,71,30,108,141,80,98,8,150,125,35,230,232,93,67,109,12,86,200,187,52,121,167,201,34,50,185,22,206,47,22,236,15,186,235,92,78,21,251,14,5,151,217,214,236,204,6,62,144,123,112,94,32,50,130,220,137,161,238,44,243,26,200,233,153,189,253,244,153,22,147,91,193,146,122,44,158,67,64,102,149,212,127,96,16,12,217,234,170,117,67,172,58,170,255,72,152,73,107,24,246,115,230,132,82,206,244,205,152,38,227,23,223,202,44,170,249,0,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("35da4edf-d91a-423a-87ed-e938ea1f0686"));
		}

		#endregion

	}

	#endregion

}

