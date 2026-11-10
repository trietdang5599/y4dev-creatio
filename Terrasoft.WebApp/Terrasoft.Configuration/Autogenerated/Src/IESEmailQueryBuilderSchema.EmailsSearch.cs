namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: IESEmailQueryBuilderSchema

	/// <exclude/>
	public class IESEmailQueryBuilderSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IESEmailQueryBuilderSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IESEmailQueryBuilderSchema(IESEmailQueryBuilderSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("4081e055-d76f-47e7-9b25-ec1eafad61ee");
			Name = "IESEmailQueryBuilder";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("a23b23cb-9341-4081-891a-73b7d61e02fc");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,117,142,49,10,195,48,12,69,103,27,124,7,67,246,28,160,221,90,66,201,88,210,11,40,142,236,10,28,59,200,241,80,74,238,94,39,33,67,161,213,38,244,222,255,10,48,98,154,192,160,126,32,51,164,104,231,250,26,131,37,151,25,102,138,161,110,70,32,159,58,4,54,79,37,223,74,234,50,57,81,112,127,149,155,143,61,248,93,57,43,185,43,21,163,43,71,221,134,25,217,150,198,147,110,155,110,75,191,103,228,215,37,147,31,144,15,124,202,189,39,163,233,160,127,194,122,203,248,214,69,121,81,44,107,140,168,48,12,123,235,186,46,31,53,211,212,193,236,0,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("4081e055-d76f-47e7-9b25-ec1eafad61ee"));
		}

		#endregion

	}

	#endregion

}

