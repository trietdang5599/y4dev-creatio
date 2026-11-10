namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: AsyncAcceptChatNotifierExecutorSchema

	/// <exclude/>
	public class AsyncAcceptChatNotifierExecutorSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public AsyncAcceptChatNotifierExecutorSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public AsyncAcceptChatNotifierExecutorSchema(AsyncAcceptChatNotifierExecutorSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("de6fad3b-1ad3-c490-fb1b-04c758b887d2");
			Name = "AsyncAcceptChatNotifierExecutor";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("08afff10-3d0c-4f3d-b6a0-28a42952a988");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,117,82,77,111,218,64,16,61,19,41,255,97,228,30,106,36,100,223,27,64,66,4,69,169,154,16,181,161,247,101,61,152,141,236,89,107,63,72,172,136,255,222,241,218,24,140,210,203,106,190,222,155,153,157,71,162,68,91,9,137,240,138,198,8,171,119,46,89,106,218,169,220,27,225,148,166,100,93,146,146,123,65,132,69,242,132,214,138,92,81,126,123,243,121,123,51,242,150,77,248,83,91,135,229,221,149,207,44,69,129,178,161,176,201,3,18,26,37,207,53,151,205,202,82,211,215,25,131,28,231,204,55,131,57,243,192,178,16,214,194,15,88,216,154,228,66,74,172,220,114,47,220,179,118,106,167,208,132,218,52,77,97,106,125,89,10,83,207,59,255,55,86,6,45,146,179,32,8,68,131,222,27,77,218,91,224,205,28,80,71,144,156,240,233,5,65,229,183,133,146,32,67,239,255,116,94,125,160,244,78,27,158,237,241,167,222,158,92,70,127,134,161,250,13,158,208,237,117,214,236,240,18,104,219,236,245,204,33,208,113,91,208,21,242,41,180,225,225,183,218,187,48,50,15,174,61,185,193,46,69,157,244,100,233,53,219,180,18,70,148,64,124,238,89,228,45,26,62,50,181,231,137,230,27,246,153,240,20,72,166,105,168,254,26,28,108,116,104,108,52,127,233,237,1,166,251,178,131,50,206,139,2,14,90,101,208,254,9,198,155,65,111,24,142,50,129,199,123,21,44,158,125,106,157,97,69,76,64,111,223,56,61,135,115,231,49,52,242,27,141,212,14,226,115,20,102,51,32,95,20,167,236,200,241,207,188,3,225,59,44,76,238,75,22,192,51,167,215,102,85,86,174,94,125,52,87,228,86,241,197,74,32,5,125,119,176,197,64,20,141,239,2,209,49,188,191,148,117,211,7,175,178,249,197,73,102,23,83,177,204,221,95,81,120,140,163,190,32,154,132,254,103,108,60,238,72,15,194,244,194,99,154,166,170,145,212,186,67,158,164,21,15,127,168,3,247,138,221,144,65,145,53,64,187,108,20,17,96,117,220,247,111,235,143,157,10,145,178,86,136,193,111,163,195,224,241,31,224,192,156,192,17,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("de6fad3b-1ad3-c490-fb1b-04c758b887d2"));
		}

		#endregion

	}

	#endregion

}

