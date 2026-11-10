namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: InvalidAccessTokenExceptionSchema

	/// <exclude/>
	public class InvalidAccessTokenExceptionSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public InvalidAccessTokenExceptionSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public InvalidAccessTokenExceptionSchema(InvalidAccessTokenExceptionSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("3f0c6f0e-7021-41f4-a539-8f0ca0bda259");
			Name = "InvalidAccessTokenException";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("34c57733-6570-402b-8e25-5c50c5be2b38");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,125,141,49,14,131,48,12,69,103,144,114,7,75,221,57,0,157,42,212,161,51,92,192,53,6,69,13,78,20,19,212,170,226,238,77,202,210,169,131,135,111,189,255,159,224,194,26,144,24,6,142,17,213,79,107,211,121,153,236,156,34,174,214,75,211,123,178,232,76,253,54,117,149,212,202,12,253,75,87,94,206,166,206,159,83,228,57,83,208,57,84,109,225,38,27,58,59,94,136,88,117,240,15,150,235,147,56,148,161,47,30,210,221,89,2,42,244,63,24,90,248,41,86,197,93,229,219,15,39,203,120,104,75,220,63,179,60,115,40,195,0,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("3f0c6f0e-7021-41f4-a539-8f0ca0bda259"));
		}

		#endregion

	}

	#endregion

}

