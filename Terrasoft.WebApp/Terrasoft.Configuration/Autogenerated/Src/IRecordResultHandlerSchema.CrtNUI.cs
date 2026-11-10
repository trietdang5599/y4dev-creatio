namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: IRecordResultHandlerSchema

	/// <exclude/>
	public class IRecordResultHandlerSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IRecordResultHandlerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IRecordResultHandlerSchema(IRecordResultHandlerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("52df6bf9-2697-4d65-9203-47d8c0b2315b");
			Name = "IRecordResultHandler";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("db43ba5c-9334-4bce-a1f8-d5a6f72577ed");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,109,144,189,10,194,48,16,128,103,11,125,135,3,23,93,218,189,138,139,139,29,4,145,190,64,76,46,54,208,38,229,146,136,34,190,187,49,177,165,136,67,8,247,243,221,125,156,102,61,218,129,113,132,6,137,152,53,210,21,123,163,165,186,122,98,78,25,157,103,207,60,203,179,197,146,240,26,66,168,181,67,146,1,168,160,62,35,55,36,206,104,125,231,14,76,139,14,41,246,150,101,9,91,235,251,158,209,99,247,141,39,14,140,4,215,34,80,132,195,247,161,161,77,120,49,210,229,12,31,252,165,83,28,212,52,225,223,98,72,154,147,231,17,93,107,132,173,224,20,233,84,252,21,139,137,38,200,244,177,27,148,5,188,35,247,14,5,48,25,214,141,150,161,48,144,225,104,45,138,98,154,52,151,92,220,140,18,144,196,78,99,235,106,189,249,90,161,22,73,236,19,133,247,74,71,157,165,243,44,230,222,165,217,130,93,145,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("52df6bf9-2697-4d65-9203-47d8c0b2315b"));
		}

		#endregion

	}

	#endregion

}

