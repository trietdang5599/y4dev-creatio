namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: IRecordsOperationWorkerSchema

	/// <exclude/>
	public class IRecordsOperationWorkerSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IRecordsOperationWorkerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IRecordsOperationWorkerSchema(IRecordsOperationWorkerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("de0a68c6-78e9-4e0a-a753-aa946a7db874");
			Name = "IRecordsOperationWorker";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("db43ba5c-9334-4bce-a1f8-d5a6f72577ed");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,141,82,193,78,195,48,12,61,15,137,127,176,198,5,46,237,125,43,149,38,52,141,29,16,19,76,226,156,37,110,23,209,38,197,78,134,38,196,191,147,166,107,217,166,33,113,138,108,191,231,247,108,199,136,26,185,17,18,97,141,68,130,109,225,146,7,107,10,93,122,18,78,91,3,95,215,87,35,207,218,148,240,186,103,135,245,244,44,14,240,170,66,217,98,57,89,160,65,210,50,96,2,234,134,176,108,59,44,141,67,42,130,198,4,150,47,40,45,41,126,110,176,107,255,102,233,29,41,194,211,52,133,140,125,93,11,218,231,135,120,160,130,45,192,109,195,211,19,193,89,160,174,89,210,147,211,35,118,227,55,149,150,160,135,6,127,72,183,243,5,248,96,118,190,67,227,120,2,171,200,239,106,231,206,98,98,77,186,44,145,24,62,183,104,64,28,204,128,102,104,200,74,100,70,149,12,228,99,103,35,108,37,58,161,71,97,84,133,148,117,222,86,61,49,214,102,84,114,14,103,149,233,193,45,26,213,25,62,117,255,132,110,107,213,127,236,207,154,166,210,200,167,11,109,55,124,180,212,11,222,99,166,17,36,106,48,225,235,220,143,229,112,253,113,254,251,19,250,115,121,163,63,60,130,86,97,30,93,232,176,174,36,75,35,61,118,219,89,173,162,147,253,112,21,190,93,206,141,175,67,180,169,48,91,120,173,114,248,213,184,187,60,255,119,247,223,78,146,33,247,3,42,103,200,209,221,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("de0a68c6-78e9-4e0a-a753-aa946a7db874"));
		}

		#endregion

	}

	#endregion

}

