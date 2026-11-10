namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: IRecordProcessedHandlerSchema

	/// <exclude/>
	public class IRecordProcessedHandlerSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IRecordProcessedHandlerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IRecordProcessedHandlerSchema(IRecordProcessedHandlerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("19ec078f-2d2a-4581-b154-931f817b018f");
			Name = "IRecordProcessedHandler";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("db43ba5c-9334-4bce-a1f8-d5a6f72577ed");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,117,145,221,106,195,48,12,133,175,87,232,59,136,236,102,131,17,223,119,89,160,140,194,122,49,40,99,47,224,218,74,226,146,88,65,118,74,199,216,187,207,113,126,232,66,7,38,32,69,231,243,209,177,149,13,186,86,42,132,79,100,150,142,10,159,190,146,45,76,217,177,244,134,44,124,175,87,119,225,220,51,150,125,185,183,30,185,8,130,13,236,63,80,17,235,3,147,66,231,80,191,73,171,107,228,245,42,140,11,33,32,115,93,211,72,254,202,199,122,150,2,21,224,43,4,142,122,104,39,0,84,3,33,157,0,226,138,208,118,199,218,40,48,51,228,159,235,123,195,97,124,54,252,142,190,34,237,54,112,136,128,225,231,210,94,108,76,128,130,248,182,61,60,163,245,233,172,23,75,64,214,74,150,13,216,144,233,75,226,208,106,228,36,223,93,80,117,49,73,69,193,251,197,167,153,136,115,183,101,146,75,151,228,91,173,77,175,145,117,88,56,248,105,134,183,24,115,91,44,62,250,186,198,158,201,232,113,159,197,240,3,29,79,168,60,12,246,158,150,172,93,143,218,6,15,208,27,121,124,30,179,12,195,67,156,177,254,137,223,191,205,208,251,5,131,245,204,25,76,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("19ec078f-2d2a-4581-b154-931f817b018f"));
		}

		#endregion

	}

	#endregion

}

