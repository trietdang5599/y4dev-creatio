namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: CallMessagePublisherSchema

	/// <exclude/>
	public class CallMessagePublisherSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public CallMessagePublisherSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public CallMessagePublisherSchema(CallMessagePublisherSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("7614e58c-2fc5-4196-ab0f-e9195ef944f6");
			Name = "CallMessagePublisher";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("e1e897dc-76f3-4978-8d04-4d8824362a32");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,109,144,209,106,195,48,12,69,159,19,200,63,136,238,165,131,210,15,72,183,65,151,110,123,218,24,116,251,0,213,85,83,131,227,20,203,30,132,208,127,159,108,23,70,214,66,192,185,215,71,87,150,2,107,219,194,118,96,79,221,178,233,141,33,229,117,111,121,249,70,150,156,86,171,170,12,9,249,34,231,144,251,131,23,202,145,216,85,105,177,35,62,161,162,201,165,61,232,54,56,140,41,85,57,86,101,33,223,157,163,86,52,52,6,153,107,104,208,152,119,98,198,150,62,195,206,104,62,146,139,129,197,41,42,5,42,98,55,41,168,225,25,153,174,139,139,49,5,252,117,146,25,188,11,202,247,174,134,196,169,12,92,90,220,10,159,127,51,57,41,180,121,7,16,38,114,1,27,157,126,208,13,15,146,45,75,89,64,62,159,128,172,215,126,120,213,100,246,188,65,143,247,177,85,81,195,78,30,59,255,159,115,5,195,152,240,151,228,111,213,145,58,252,144,221,194,35,204,214,82,243,35,238,108,21,145,243,101,72,178,251,60,103,210,217,157,154,231,95,94,204,122,139,217,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("7614e58c-2fc5-4196-ab0f-e9195ef944f6"));
		}

		#endregion

	}

	#endregion

}

