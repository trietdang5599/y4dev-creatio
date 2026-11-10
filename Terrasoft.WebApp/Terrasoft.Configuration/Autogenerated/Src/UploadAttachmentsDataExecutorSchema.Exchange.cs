namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: UploadAttachmentsDataExecutorSchema

	/// <exclude/>
	public class UploadAttachmentsDataExecutorSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public UploadAttachmentsDataExecutorSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public UploadAttachmentsDataExecutorSchema(UploadAttachmentsDataExecutorSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("2e5d4ef8-77c1-49cb-9a08-7abb85fd5ce3");
			Name = "UploadAttachmentsDataExecutor";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("77ff850a-3558-415d-9b34-1a36190e74f6");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,125,82,209,106,194,48,20,125,174,224,63,92,186,23,11,210,190,187,90,16,149,225,96,48,80,159,198,30,174,233,85,51,210,68,146,84,236,100,255,190,52,85,187,138,236,45,185,231,230,156,123,79,14,72,44,200,28,144,17,172,72,107,52,106,107,227,169,146,91,190,43,53,90,174,100,191,119,238,247,130,210,112,185,131,101,101,44,21,14,23,130,88,13,154,248,133,36,105,206,158,111,61,127,105,52,185,186,67,158,52,237,92,55,76,5,26,51,130,245,65,40,204,39,214,34,219,23,36,173,153,161,197,249,137,88,105,149,246,15,14,229,70,112,6,172,238,255,191,29,70,176,120,85,155,246,117,112,246,12,55,205,55,178,123,149,59,213,119,207,217,128,73,146,64,106,202,162,64,93,101,215,66,195,65,6,232,196,246,40,119,4,84,32,23,128,173,50,228,78,26,76,37,217,94,43,201,191,189,67,241,141,49,185,167,76,15,168,177,128,218,228,113,88,26,210,206,90,217,88,23,102,169,33,2,166,105,59,14,215,93,40,201,128,75,99,81,50,138,211,196,115,60,166,244,103,178,164,77,152,45,187,83,221,79,9,131,90,255,186,82,158,107,114,214,146,101,113,212,145,184,56,127,228,218,150,40,224,168,120,126,53,102,208,157,18,186,251,12,97,49,227,254,228,12,72,141,213,46,12,67,80,155,47,7,103,208,14,26,65,157,167,32,152,95,76,94,91,46,184,173,226,135,191,60,184,215,104,121,62,188,105,243,122,157,73,179,77,248,25,175,212,210,11,15,162,168,78,100,240,115,201,2,201,188,137,131,191,55,213,110,209,215,126,1,111,80,141,232,14,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("2e5d4ef8-77c1-49cb-9a08-7abb85fd5ce3"));
		}

		#endregion

	}

	#endregion

}

