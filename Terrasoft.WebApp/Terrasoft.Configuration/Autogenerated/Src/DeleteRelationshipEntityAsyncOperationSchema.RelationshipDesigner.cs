namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: DeleteRelationshipEntityAsyncOperationSchema

	/// <exclude/>
	public class DeleteRelationshipEntityAsyncOperationSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public DeleteRelationshipEntityAsyncOperationSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public DeleteRelationshipEntityAsyncOperationSchema(DeleteRelationshipEntityAsyncOperationSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("2810347f-8d41-bc89-5b74-bf02880df2b3");
			Name = "DeleteRelationshipEntityAsyncOperation";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("ac9dec01-f305-4a8c-bd6f-7a943e292d3e");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,149,82,205,106,2,49,16,62,175,224,59,4,123,89,65,242,0,218,22,172,110,203,30,164,101,105,31,32,205,142,49,176,38,203,76,98,187,72,223,189,49,17,113,133,133,246,150,124,153,239,103,102,98,196,30,168,21,18,216,59,32,10,178,91,199,87,214,108,181,242,40,156,182,134,87,208,196,3,237,116,187,6,210,202,0,142,71,199,241,40,243,164,141,234,241,16,22,3,56,47,140,211,78,3,241,37,117,70,190,182,144,228,233,223,4,94,26,7,184,13,145,135,185,207,66,58,139,58,86,132,154,59,4,21,168,108,213,8,162,57,91,67,3,14,174,251,138,94,93,223,40,50,91,255,217,104,201,228,137,248,71,30,155,179,50,225,197,1,140,187,21,205,142,81,248,146,105,3,110,103,235,144,234,45,90,165,199,179,237,193,234,154,21,223,32,189,131,252,131,0,195,102,12,200,232,226,123,215,25,27,180,92,162,34,38,80,249,125,120,162,41,59,109,46,203,14,2,25,94,111,86,11,133,98,191,17,70,40,64,246,144,102,149,230,216,241,23,112,247,101,53,88,254,152,71,205,204,192,23,11,153,200,161,63,241,150,103,211,124,210,15,59,153,221,164,159,78,23,81,96,56,16,79,179,79,77,62,117,21,72,139,117,89,231,151,190,210,119,233,202,58,73,253,156,135,12,166,78,115,142,247,132,94,131,1,249,5,115,5,118,184,2,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("2810347f-8d41-bc89-5b74-bf02880df2b3"));
		}

		#endregion

	}

	#endregion

}

